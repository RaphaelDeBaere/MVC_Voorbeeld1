using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_BierenWebAplli.Models;

namespace MVC_BierenWebAplli.Controllers
{
    public class BierenController : Controller
    {
        private MVCBierenEntities db = new MVCBierenEntities();

        // GET: Bieren
        public ActionResult Index()
        {
            var bieren = db.Bieren.Include(b => b.Brouwers).Include(b => b.Soorten);
            return View(bieren.ToList());
        }

        // GET: Bieren/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bieren bieren = db.Bieren.Find(id);
            if (bieren == null)
            {
                return HttpNotFound();
            }
            return View(bieren);
        }
        [Authorize(Roles = "Administrators")]
        // GET: Bieren/Create
        public ActionResult Create()
        {
            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam");
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort");
            return View();
        }

        // POST: Bieren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BierNr,Naam,BrouwerNr,SoortNr,Alcohol")] Bieren bieren)
        {
            if (ModelState.IsValid)
            {
                db.Bieren.Add(bieren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrouwerNr = new SelectList(db.Brouwers, "BrouwerNr", "BrNaam", bieren.BrouwerNr);
            ViewBag.SoortNr = new SelectList(db.Soorten, "SoortNr", "Soort", bieren.SoortNr);
            return View(bieren);
        }
        [Authorize(Roles = "Administrators")]
        // GET: Bieren/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bieren bieren = db.Bieren.Find(id);
            if (bieren == null)
            {
                return HttpNotFound();
            }
            return View(bieren);
        }

        // POST: Bieren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bieren bieren = db.Bieren.Find(id);
            db.Bieren.Remove(bieren);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
