using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class ResetAttemptsController : Controller
    {
        // GET: ResetAttempts
        public ActionResult ResetAttemptsView()
        {
            Models.ResetAttemptsModel rc = new Models.ResetAttemptsModel();
            rc.NameList = rc.GetNameList();
            rc.ModuleList = rc.GetModuleList();
            return View(rc);
        }

        [HttpPost]
        public ActionResult ResetAttemptsView(Models.ResetAttemptsModel obj)
        {
            Models.ResetAttemptsModel rc = new Models.ResetAttemptsModel();
            rc.NameList = rc.GetNameList();
            rc.ModuleList = rc.GetModuleList();

            rc.Module = obj.Module;
            rc.ModuleNum = rc.GetModuleNum();
            rc.Name = obj.Name;
            rc.EmployeeID = rc.GetEmployeeID();

            string result = rc.ResetAttempts();
            if (result == "Success")
            {
                string reset = rc.ResetCompletedModules();
                TempData["Client"] = "pass";
                ModelState.Clear();
                return View(rc);
            }
            else
            {
                rc.NameList = rc.GetNameList();
                rc.ModuleList = rc.GetModuleList();
                TempData["Client"] = "fail";
                return View();
            }
        }
    }
}