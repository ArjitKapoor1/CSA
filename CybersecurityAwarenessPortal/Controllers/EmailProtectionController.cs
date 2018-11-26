using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class EmailProtectionController : Controller
    {
        // GET: EmailProtection
        public ActionResult EmailProtectionView()
        {
            Session["moduleid"] = 4;
            return View();
        }
    }
}