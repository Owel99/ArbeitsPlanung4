using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArbeitsPlanung4Web.Models;
using ArbeitsPlanung4Lib;
using ArbeitsPlanungWeb.Controllers;

namespace ArbeitsPlanung4Web.Controllers
{
    public class ZuweisungController : BaseController
    {

        private class ZuweisungOrError
        {
            public ActionResult Error;
            public Zuweisung Zuweisung;
            public ZuweisungOrError(ActionResult error)
            {
                Error = error;
            }
            public ZuweisungOrError(HttpStatusCode errorStatus)
            {
                Error = new HttpStatusCodeResult(errorStatus);
            }
            public ZuweisungOrError(Zuweisung zuweisung)
            {
                Zuweisung = zuweisung;
            }
        }
        private ZuweisungOrError GetZuweisungOrError(
            int? benutzerId, int? arbeitId)
        {
            if (!hasUser())
                return new ZuweisungOrError(HttpStatusCode.Unauthorized);
            if (benutzerId == null)
                return new ZuweisungOrError(HttpStatusCode.BadRequest);
            if (arbeitId == null)
                return new ZuweisungOrError(HttpStatusCode.BadRequest);
            Arbeit arbeit = db.ArbeitSet.Find(arbeitId);
            if (arbeit == null)
                return new ZuweisungOrError(HttpStatusCode.BadRequest);
            Benutzer benutzer = db.BenutzerSet.Find(benutzerId);
            if (benutzer == null)
                return new ZuweisungOrError(HttpStatusCode.BadRequest);
            return new ZuweisungOrError(new Zuweisung()
            {
                Benutzer = benutzer, Arbeit = arbeit
            });

            
        }

        // GET: Zuweisung
        public ActionResult Index()
        {
            var zuweisungen =
                from benutzer in db.BenutzerSet
                from arbeit in db.ArbeitSet
                where benutzer.Zuweisungen.Contains(arbeit)
                select new Zuweisung()
                {
                    Benutzer = benutzer,
                    Arbeit = arbeit
                };
            return View(zuweisungen.ToList());
        }

        // GET: Zuweisung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zuweisung zuweisung = db.Zuweisungs.Find(id);
            if (zuweisung == null)
            {
                return HttpNotFound();
            }
            return View(zuweisung);
        }

        // GET: Zuweisung/Create
        public ActionResult Create()
        {
            ViewBag.ArbeitId = new SelectList(db.ArbeitSet, "ArbeitId", "Name");
            ViewBag.BenutzerId = new SelectList(db.BenutzerSet, "BenutzerId", "Vorname");
            return View();
        }

        // POST: Zuweisung/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BenutzerId,ArbeitId")] Zuweisung zuweisung)
        {
            var tmp = GetZuweisungOrError(
            zuweisung.BenutzerId, zuweisung.ArbeitId);
            if (tmp.Error != null) return tmp.Error;
            if (ModelState.IsValid)
            {
                tmp.Zuweisung.Benutzer.Zuweisungen.Add(tmp.Zuweisung.Arbeit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.BenutzerSet, "ArbeitId", "Name", zuweisung.BenutzerId);
            ViewBag.WorkId = new SelectList(db.ArbeitSet, "BenutzerId", "Vorname", zuweisung.ArbeitId);
            return View(zuweisung);
        }

        // GET: Zuweisung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zuweisung zuweisung = db.Zuweisungs.Find(id);
            if (zuweisung == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArbeitId = new SelectList(db.ArbeitSet, "ArbeitId", "Name", zuweisung.ArbeitId);
            ViewBag.BenutzerId = new SelectList(db.BenutzerSet, "BenutzerId", "Vorname", zuweisung.BenutzerId);
            return View(zuweisung);
        }

        // POST: Zuweisung/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BenutzerId,ArbeitId")] Zuweisung zuweisung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zuweisung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArbeitId = new SelectList(db.ArbeitSet, "ArbeitId", "Name", zuweisung.ArbeitId);
            ViewBag.BenutzerId = new SelectList(db.BenutzerSet, "BenutzerId", "Vorname", zuweisung.BenutzerId);
            return View(zuweisung);
        }

        // GET: Zuweisung/Delete/5
        public ActionResult Delete(int? benutzerId, int? arbeitId)
        {
            var tmp = GetZuweisungOrError(benutzerId, arbeitId);
            if (tmp.Error != null) return tmp.Error;
            return View(tmp.Zuweisung);
        }

        // POST: Zuweisung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? benutzerId, int? arbeitId)
        {
            var tmp = GetZuweisungOrError(benutzerId, arbeitId);
            if (tmp.Error != null) return tmp.Error;
            tmp.Zuweisung.Benutzer.Zuweisungen.Remove(tmp.Zuweisung.Arbeit);
            db.SaveChanges;
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
