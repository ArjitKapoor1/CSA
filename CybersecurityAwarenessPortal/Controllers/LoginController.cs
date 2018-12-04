using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using CybersecurityAwarenessPortal.Models;
using CybersecurityAwarenessPortal.App_Start;
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
    public class LoginController : Controller
    {
        /// <summary>
        /// This View is called when the login page is loaded
        /// This is our web app's landing page
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginView()
        {
            return View();
        }

        /// <summary>
        /// This method is called when the user fills out the details for login
        /// Extracts and stores the values entered by the user
        /// Compares the username and password and checks if it valid or not
        /// </summary>
        /// <returns>
        /// Home page if the login is successful, else returns to the same page
        /// </returns>
        [HttpPost]
        public ActionResult LoginView(Models.LoginModel user)
        {
            user.Username = Request.Form["email"];
            user.Password = Request.Form["pass"];
            string remember = Request.Form["remember-me"];
            if (remember == "on"){
                user.RememberMe = true;
            }
            else user.RememberMe = false;

         
            if (user.IsValid(user.Username, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                Session["username"] = user.Username;
                if (user.Username == "admin@tangerine.ca")
                {
                    Session["username"] = user.Username;
                    return RedirectToAction("AdminView", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            { 
                TempData["LoginFailed"] = "fail";
                ModelState.AddModelError("", "Login data is incorrect!");
            }
            return View(user);

        }
        
        /// <summary>
        /// This view is called when the user selects the logout options 
        /// </summary>
        /// <returns>
        /// The login page
        /// </returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginView", "Login");
        }


    }
}