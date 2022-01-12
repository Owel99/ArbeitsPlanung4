using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArbeitsPlanung4Lib;
using ArbeitsPlanungWeb.Controllers;

namespace ArbeitsPlanung4Web.Controllers
{
    public class BenutzerController : BaseController
    {

        // GET: Benutzer
        public ActionResult Index()
        {
            return View(db.BenutzerSet.ToList());
        }

        // GET: Benutzer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benutzer benutzer = db.BenutzerSet.Find(id);
            if (benutzer == null)
            {
                return HttpNotFound();
            }
            return View(benutzer);
        }

        // GET: Benutzer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benutzer/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BenutzerId,Vorname,Nachname,istAdmin,istBenutzer")] Benutzer benutzer)
        {
            if (ModelState.IsValid)
            {
                db.BenutzerSet.Add(benutzer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benutzer);
        }

        // GET: Benutzer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benutzer benutzer = db.BenutzerSet.Find(id);
            if (benutzer == null)
            {
                return HttpNotFound();
            }
            return View(benutzer);
        }

        // POST: Benutzer/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BenutzerId,Vorname,Nachname,istAdmin,istBenutzer")] Benutzer benutzer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benutzer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benutzer);
        }

        // GET: Benutzer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benutzer benutzer = db.BenutzerSet.Find(id);
            if (benutzer == null)
            {
                return HttpNotFound();
            }
            return View(benutzer);
        }

        // POST: Benutzer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benutzer benutzer = db.BenutzerSet.Find(id);
            db.BenutzerSet.Remove(benutzer);
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
