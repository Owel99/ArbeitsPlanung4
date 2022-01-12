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
    public class LoginController : BaseController
    {

        // GET: Login
        public ActionResult Index()
        {
            return View(db.BenutzerSet.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Select(int? id)
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
            setUserId(id.Value);
            return RedirectToAction("Index", "Home");
        }
    }
}
