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
    public class ResetAttemptsController : Controller
    {
        /// <summary>
        /// This View is called when the admin selects reset attempts option
        /// Creates an object of the reset attempts model 
        /// Calls the method to get the list of employee names and modules to display on page load
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetAttemptsView()
        {
            Models.ResetAttemptsModel rc = new Models.ResetAttemptsModel();
            rc.NameList = rc.GetNameList();
            rc.ModuleList = rc.GetModuleList();
            return View(rc);
        }

        /// <summary>
        /// This method is called when the admin submits the update request
        /// Extracts and stores the admin entered data
        /// Calls the reset method defined in the model
        /// Deletes the records of the attempts of the selected employee
        /// Checks if the user passed the selected module, if yes deletes that progress as well
        /// </summary>
        /// <param name="obj">Takes in an object of the reset attempts model</param>
        /// <returns>
        /// Reset attempts successful or fail alert
        /// </returns>
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