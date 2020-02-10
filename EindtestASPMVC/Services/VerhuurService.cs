using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EindtestASPMVC.Models;

namespace EindtestASPMVC.Services
{
    public class VerhuurService
    {
        public Klant GetKlant(string naam, int postcode)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return (from klant in db.Klanten
                        where klant.Naam.ToLower() == naam.ToLower() &&
                        klant.PostCode == postcode
                        select klant).FirstOrDefault();
            }
        }
        public List<Genre> GetGenres()
        {
            using (var db = new VideoVerhuurEntities())
            {
                return (from genre in db.Genres
                        select genre).ToList();
            }
        }
        public List<Film> GetFilmsVanGenre(int genreNr)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return (from film in db.Films
                        where film.GenreNr == genreNr
                        orderby film.Titel
                        select film).ToList();
            }
        }
        public Film GetFilm(int filmNr)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return db.Films.Find(filmNr);
            }
        }
        public Klant GetKlantOpNummer(int klantNummer)
        {
            using (var db = new VideoVerhuurEntities())
            {
                return (from klant in db.Klanten
                        where klant.KlantNr == klantNummer
                        select klant).FirstOrDefault();
            }
        }
        public void BewaarVerhuurdeFilms(Verhuur verhuur)
        {
            using (var db = new VideoVerhuurEntities())
            {
                var film = db.Films.Find(verhuur.BandNr);
                film.InVoorraad -= 1;
                film.UitVoorraad += 1;
                db.Verhuur.Add(verhuur);
                db.SaveChanges();
            }
        }
    }
}