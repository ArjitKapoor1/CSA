using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class PasswordResetController : Controller
    {
        // GET: PasswordReset
        public ActionResult PasswordResetView()
        {
            return View();
        }
    }
}