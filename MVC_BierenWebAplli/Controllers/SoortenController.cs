﻿using System;
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
    public class SoortenController : Controller
    {
        private MVCBierenEntities db = new MVCBierenEntities();

        // GET: Soorten
        public ActionResult Index()
        {
            return View(db.Soorten.ToList());
        }

        // GET: Soorten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soorten soorten = db.Soorten.Find(id);
            if (soorten == null)
            {
                return HttpNotFound();
            }
            return View(soorten);
        }
        [Authorize(Roles = "Administrators")]
        // GET: Soorten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soorten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoortNr,Soort")] Soorten soorten)
        {
            if (ModelState.IsValid)
            {
                db.Soorten.Add(soorten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soorten);
        }
        [Authorize(Roles = "Administrators")]
        // GET: Soorten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soorten soorten = db.Soorten.Find(id);
            if (soorten == null)
            {
                return HttpNotFound();
            }
            return View(soorten);
        }

        // POST: Soorten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soorten soorten = db.Soorten.Find(id);
            db.Soorten.Remove(soorten);
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
