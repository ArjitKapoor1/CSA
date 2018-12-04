using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Cybersecurity Awareness Portal
/// This Portal allows training of employees in the field of Cybersecurity
/// Employees are evaluated in the form of a quiz game 
/// The admin can track server stats, reigster employees etc. 
/// Author: Arjit Kapoor
/// </summary>
namespace CybersecurityAwarenessPortal.Controllers
{
    /// <summary>
    /// The controller is the class that binds the model and the view
    /// It handles all the form post and get action
    /// All the user entered values are handled here
    /// </summary>
    public class QuizOptionsController : Controller
    {
        /// <summary>
        /// This View is called when the admin selects update quiz options 
        /// </summary>
        /// <returns></returns>
        public ActionResult QuizOptionsView()
        {
            return View();
        }

        /// <summary>
        /// This method is called when the admin submits the update request
        /// Extracts and stores the admin entered data
        /// Calls the update method defined in the model
        /// </summary>
        /// <param name="obj"> Takes an object of the Quiz Options Model </param>
        /// <returns>
        /// Update pass or fail alert
        /// </returns>
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