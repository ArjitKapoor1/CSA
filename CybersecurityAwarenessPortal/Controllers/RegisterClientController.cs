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
    public class RegisterClientController : Controller
    {
        /// <summary>
        /// This View is called when the admin selects register a new client option
        /// Creates an object of the register client model 
        /// Calls the method to get the list of departments to display on page load
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterClientView()
        {
            Models.RegisterClientModel rc = new Models.RegisterClientModel();
            rc.DepartmentList = rc.GetDepartmentList();
            return View(rc);
        }

        /// <summary>
        /// This method is called when the admin submits the create request
        /// Extracts and stores the admin entered data
        /// Calls the register method defined in the model
        /// Creats a new employee in the DB and creates a login for the employee
        /// </summary>
        /// <param name="obj"> Takes in an object of the Register client model</param>
        /// <returns>
        /// Register employee successful or fail alert
        /// </returns>
        [HttpPost]
        public ActionResult RegisterClientView(Models.RegisterClientModel obj)
        {
            Models.RegisterClientModel rc = new Models.RegisterClientModel();
            rc.DepartmentList = rc.GetDepartmentList();

            rc.EmployeeID = rc.GetMaxId() + 1;
            rc.FirstName = obj.FirstName;
            rc.LastName = obj.LastName;
            rc.Department = obj.Department;
            rc.JoiningDate = obj.JoiningDate;
            rc.Password = obj.Password;
            rc.LoginEmail = obj.LoginEmail;

            string result = rc.RegisterClient();
            if (result == "Success")
            {
                string login = rc.CreateLogin();
                TempData["Client"] = "pass";
                ModelState.Clear();
                return View(rc);
            }
            else
            {
                rc.DepartmentList = rc.GetDepartmentList();
                TempData["Client"] = "fail";
                return View();
            }
        }
    }
}