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

namespace CybersecurityAwarenessPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginView()
        {
            return View();
        }

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
                return RedirectToAction("Index", "Home");
            }
            else
            { 
                TempData["LoginFailed"] = "fail";
                ModelState.AddModelError("", "Login data is incorrect!");
            }
            return View(user);

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginView", "Login");
        }


    }
}