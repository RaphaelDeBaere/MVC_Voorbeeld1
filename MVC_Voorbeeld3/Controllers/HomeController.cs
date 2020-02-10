using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Voorbeeld3.Models;

namespace MVC_Voorbeeld3.Controllers
{
    public class HomeController : Controller
    {
        public PartialViewResult GetTime()
        {
            return PartialView(DateTime.Now);
        }
        public ActionResult Index()
        {
            //sessionvariabele aanpassen
            this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;

            //applicationvariabele aanpassen
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] =
            (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            aantalBezoeken bezoeken = new aantalBezoeken { aantalBezoekenSession = (int)this.Session["aantalBezoeken"], aantalBezoekenTotaal = (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] };
            return View(bezoeken);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Wissen()
        {
            //reset sessionvariabele
            this.Session["aantalBezoeken"] = 0;
            //reset applicationvariabele
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();
            return View();
        }

    }
}