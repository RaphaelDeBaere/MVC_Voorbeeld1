using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EindtestASPMVC.Services;
using EindtestASPMVC.Models;

namespace EindtestASPMVC.Controllers
{
    public class HomeController : Controller
    {
        private VerhuurService db = new VerhuurService();
        public ActionResult Aanmelden()
        {
            return View("Aanmelden");
        }
        public ActionResult Index()
        {
            return View(db.GetGenres());
        }
        public ActionResult ValidatieKlant()
        {
                var naam = Request["naam"];
                var postcode = int.Parse(Request["postcode"]);
                var klant = db.GetKlant(naam, postcode);
                if (klant != null)
                {
                    Session["klant"] = klant.Voornaam + " " + klant.Naam + " " + klant.KlantNr;
                    return RedirectToAction("ValidatieKlantJuist");
                }
            
            return RedirectToAction("ValidatieKlantFout");
        }
        public ActionResult ValidatieKlantFout()
        {
            return View();
        }
        public ActionResult ValidatieKlantJuist()
        {
            return View();
        }
        public ActionResult Uitloggen()
        {
            if (Session["klant"] != null)
                Session["klant"] = null;
            return RedirectToAction("Aanmelden");
        }
        public ActionResult GetFilmsVanGenre(int genreNr, string genreSoort)
        {
            var filmLijst = db.GetFilmsVanGenre(genreNr);
            ViewBag.genreSoort = genreSoort;
            return View(filmLijst);
        }
        public ActionResult Huur(int filmNummer)
        {
            var filmInfo = db.GetFilm(filmNummer);

            Session[filmNummer.ToString()] = filmInfo.BandNr;
            return RedirectToAction("Winkelmandje", "Home");
        }

        public ActionResult Winkelmandje()
        {
            List<WinkelmandItem> mandjeItems = new List<WinkelmandItem>();
            foreach (string nummer in Session)
            {
                int filmNr;
                if (int.TryParse(nummer, out filmNr))
                {
                    Film film = db.GetFilm(filmNr);
                    if (film != null)
                    {
                        WinkelmandItem mandjeItem = new WinkelmandItem(film.Titel,
                            film.Prijs, Convert.ToInt16(Session[nummer]));
                        mandjeItems.Add(mandjeItem);
                    }
                }
            }
            return View(mandjeItems);
        }
        public ActionResult FilmVerwijderen(int filmNummer)
        {
            var teVerwijderenFilm = db.GetFilm(filmNummer);
            return View(teVerwijderenFilm);
        }

        public ActionResult VerwijderFilmVanMandje(int bandNr)
        {
            foreach (string nummer in Session)
            {
                int filmNr;
                if (int.TryParse(nummer, out filmNr))
                {
                    if (filmNr == bandNr)
                    {
                        Session.Remove(nummer);
                        break;
                    }
                }
            }
            return RedirectToAction("Winkelmandje", "Home");
        }
        public ActionResult Afrekenen()
        {
            decimal teBetalen = 0;
            var klantenNummer = int.Parse(@Session["klant"].ToString().Substring(@Session["klant"].ToString().LastIndexOf(" ") + 1));
            Klant klant = db.GetKlantOpNummer(klantenNummer);
            ViewBag.Voornaam = klant.Voornaam;
            ViewBag.Naam = klant.Naam;
            ViewBag.Straat = klant.Straat_Nr;
            ViewBag.Postcode = klant.PostCode;
            ViewBag.Gemeente = klant.Gemeente;

            List<WinkelmandItem> mandjeItems = new List<WinkelmandItem>();
            foreach (string nummer in Session)
            {
                int filmNr;
                if (int.TryParse(nummer, out filmNr))
                {
                    Film film = db.GetFilm(filmNr);
                    if (film != null)
                    {
                        WinkelmandItem mandjeItem = new WinkelmandItem(film.Titel, film.Prijs, Convert.ToInt16(Session[nummer]));
                        mandjeItems.Add(mandjeItem);
                        Verhuur verhuurItem = new Verhuur();
                        verhuurItem.KlantNr = klant.KlantNr;
                        verhuurItem.BandNr = film.BandNr;
                        verhuurItem.VerhuurDatum = DateTime.Today;
                        if (film.InVoorraad > 0)
                        {
                            teBetalen += film.Prijs;
                            db.BewaarVerhuurdeFilms(verhuurItem);
                        }
                        else
                        {
                                mandjeItems.Remove(mandjeItem);
                                System.Windows.Forms.MessageBox.Show("De laatste film van \"" + film.Titel + "\" is net verhuurd en kan niet meer uitgeleend worden.");
                        }
                    }
                }
            }
            Session.RemoveAll();
            ViewBag.teBetalen = teBetalen;
            return View(mandjeItems);
        }
    }
}