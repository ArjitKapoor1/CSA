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
    public class InternetProtectionController : Controller
    {
        /// <summary>
        /// This View is called when the internet protection module is selected
        /// It sets the Session value of the current module to the respective ID
        /// </summary>
        /// <returns></returns>
        public ActionResult InternetProtectionView()
        {
            Session["moduleid"] = 3;
            return View();
        }
    }
}