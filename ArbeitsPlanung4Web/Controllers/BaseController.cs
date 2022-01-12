using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArbeitsPlanung4Lib;

namespace ArbeitsPlanungWeb.Controllers
{
    public class BaseController : Controller
    {
        protected ArbeitsPlaung4ModelContainer db = new ArbeitsPlaung4ModelContainer();

        private static String BenutzerIdKey = "BenutzerId";
        public Benutzer setUser()
        {
            int? BenutzerId = Session[BenutzerIdKey] as int?;
            if (BenutzerId == null) return null;
            Benutzer res = db.BenutzerSet.Find(BenutzerId);
            if (res == null) return null;
            ViewBag.Benutzer = res;
            _LoggedInUser = res;
            return res;
        }

        private Benutzer _LoggedInUser = null;
        protected Benutzer LoggedInUser => _LoggedInUser ?? setUser();

        protected bool hasUser()
        {
            return LoggedInUser != null;
        }

        protected void setUserId(int userID)
        {
            Session[BenutzerIdKey] = userID;
        }

    }
}

