using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class QuizOptionsController : Controller
    {
        // GET: QuizOptions
        public ActionResult QuizOptionsView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuizOptionsView(Models.QuizOptionsModel obj)
        {
            Models.QuizOptionsModel qom = new Models.QuizOptionsModel();
            qom.numOfAttempts = obj.numOfAttempts;
            qom.PassingPercentage = obj.PassingPercentage;

            string result = qom.UpdateOptions();
            if (result == "Success")
            {
                if(qom.numOfAttempts <= 0 || qom.PassingPercentage <= 0 || qom.PassingPercentage > 100)
                {
                    TempData["Options"] = "fail";
                    return View();
                }
                TempData["Options"] = "pass";
                ModelState.Clear();
                return View(qom);
            }
            else
            {
                TempData["Options"] = "fail";
                return View();
            }
        }
    }
}