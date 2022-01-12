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
    public class ArbeitController : BaseController
    {

        // GET: Arbeit
        public ActionResult Index()
        {
            return View(db.ArbeitSet.ToList());
        }

        // GET: Arbeit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbeit arbeit = db.ArbeitSet.Find(id);
            if (arbeit == null)
            {
                return HttpNotFound();
            }
            return View(arbeit);
        }

        // GET: Arbeit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arbeit/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArbeitId,Name")] Arbeit arbeit)
        {
            if (ModelState.IsValid)
            {
                db.ArbeitSet.Add(arbeit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arbeit);
        }

        // GET: Arbeit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbeit arbeit = db.ArbeitSet.Find(id);
            if (arbeit == null)
            {
                return HttpNotFound();
            }
            return View(arbeit);
        }

        // POST: Arbeit/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArbeitId,Name")] Arbeit arbeit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbeit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arbeit);
        }

        // GET: Arbeit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbeit arbeit = db.ArbeitSet.Find(id);
            if (arbeit == null)
            {
                return HttpNotFound();
            }
            return View(arbeit);
        }

        // POST: Arbeit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arbeit arbeit = db.ArbeitSet.Find(id);
            db.ArbeitSet.Remove(arbeit);
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
