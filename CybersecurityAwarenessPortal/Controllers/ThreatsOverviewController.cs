using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dropbox.Api;
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
    public class ThreatsOverviewController : Controller
    {
        /// <summary>
        /// This View is called when the threats overview module is selected
        /// It sets the Session value of the current module to the respective ID
        /// </summary>
        /// <returns></returns>
        public ActionResult ThreatsOverviewView()
        {
            Session["moduleid"] = 1;
            return View();
        }
    }
}