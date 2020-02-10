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
    public class BrouwerController : Controller
    {
        private MVCBierenEntities db = new MVCBierenEntities();

        // GET: Brouwer
        public ActionResult Index()
        {
            return View(db.Brouwers.ToList());
        }

        // GET: Brouwer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwers brouwers = db.Brouwers.Find(id);
            if (brouwers == null)
            {
                return HttpNotFound();
            }
            return View(brouwers);
        }

        // GET: Brouwer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brouwer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrouwerNr,BrNaam,Adres,PostCode,Gemeente,Omzet")] Brouwers brouwers)
        {
            if (ModelState.IsValid)
            {
                db.Brouwers.Add(brouwers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brouwers);
        }

        // GET: Brouwer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwers brouwers = db.Brouwers.Find(id);
            if (brouwers == null)
            {
                return HttpNotFound();
            }
            return View(brouwers);
        }

        // POST: Brouwer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrouwerNr,BrNaam,Adres,PostCode,Gemeente,Omzet")] Brouwers brouwers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brouwers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brouwers);
        }

        // GET: Brouwer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brouwers brouwers = db.Brouwers.Find(id);
            if (brouwers == null)
            {
                return HttpNotFound();
            }
            return View(brouwers);
        }

        // POST: Brouwer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brouwers brouwers = db.Brouwers.Find(id);
            db.Brouwers.Remove(brouwers);
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
