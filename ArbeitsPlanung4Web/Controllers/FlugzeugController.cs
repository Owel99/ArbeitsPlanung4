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
    public class FlugzeugController : BaseController
    {

        // GET: Flugzeug
        public ActionResult Index()
        {
            return View(db.FlugzeugSet.ToList());
        }

        // GET: Flugzeug/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flugzeug flugzeug = db.FlugzeugSet.Find(id);
            if (flugzeug == null)
            {
                return HttpNotFound();
            }
            return View(flugzeug);
        }

        // GET: Flugzeug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flugzeug/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlugzeugId,Kennzeichen,Typ")] Flugzeug flugzeug)
        {
            if (ModelState.IsValid)
            {
                db.FlugzeugSet.Add(flugzeug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flugzeug);
        }

        // GET: Flugzeug/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flugzeug flugzeug = db.FlugzeugSet.Find(id);
            if (flugzeug == null)
            {
                return HttpNotFound();
            }
            return View(flugzeug);
        }

        // POST: Flugzeug/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlugzeugId,Kennzeichen,Typ")] Flugzeug flugzeug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flugzeug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flugzeug);
        }

        // GET: Flugzeug/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flugzeug flugzeug = db.FlugzeugSet.Find(id);
            if (flugzeug == null)
            {
                return HttpNotFound();
            }
            return View(flugzeug);
        }

        // POST: Flugzeug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flugzeug flugzeug = db.FlugzeugSet.Find(id);
            db.FlugzeugSet.Remove(flugzeug);
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
