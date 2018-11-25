using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class PasswordSafetyController : Controller
    {
        // GET: PasswordSafety
        public ActionResult PasswordSafetyView()
        {
            Session["moduleid"] = 2;
            return View();
        }
    }
}