using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class RegisterClientController : Controller
    {
        // GET: RegisterClient
        public ActionResult RegisterClientView()
        {
            Models.RegisterClientModel rc = new Models.RegisterClientModel();
            rc.DepartmentList = rc.GetDepartmentList();
            return View(rc);
        }

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