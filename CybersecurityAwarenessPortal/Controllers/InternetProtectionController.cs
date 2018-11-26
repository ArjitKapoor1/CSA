using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class InternetProtectionController : Controller
    {
        // GET: InternetProtection
        public ActionResult InternetProtectionView()
        {
            Session["moduleid"] = 3;
            return View();
        }
    }
}