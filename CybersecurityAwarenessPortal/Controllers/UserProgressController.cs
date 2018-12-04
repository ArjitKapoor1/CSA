using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CybersecurityAwarenessPortal.Models;
using Newtonsoft.Json;
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
    public class UserProgressController : Controller
    {
        /// <summary>
        /// This View is called when the user selects to view its progress
        /// Creates an object of the User Progress Model
        /// Gets the number of completed modules of the logged in employee and calcuates the percentage for the progress bar
        /// Creates a new graph object with number of attempts for each module being the datapoints.
        /// </summary>
        /// <returns></returns>
        public ActionResult UserProgressView()
        { 
            Models.UserProgressModel upm = new Models.UserProgressModel();
            upm.EmployeeEmail = Session["username"].ToString();
            upm.EmployeeID = upm.GetEmployeeID();
            upm.numOfCompletedModules = upm.GetNumOfModulesCompleted();
            upm.percentage = ((double)upm.numOfCompletedModules / 4 )* 100;
            Session["perc"] = upm.percentage;

            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint("Threats OverView", upm.GetMaxAttemptsM1()));
            dataPoints.Add(new DataPoint("Password Safety", upm.GetMaxAttemptsM2()));
            dataPoints.Add(new DataPoint("Internet Protection", upm.GetMaxAttemptsM3()));
            dataPoints.Add(new DataPoint("Email Protection", upm.GetMaxAttemptsM4()));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}