using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
/// <summary>
/// Cybersecurity Awareness Portal
/// This Portal allows training of employees in the field of Cybersecurity
/// Employees are evaluated in the form of a quiz game 
/// The admin can track server stats, reigster employees etc. 
/// Author: Arjit Kapoor
/// </summary>
namespace CybersecurityAwarenessPortal.Models
{
    /// <summary>
    /// The model class is that which defines all the user and data properties
    /// It is the class where all the methods are defined 
    /// It handles all the database interactions
    /// </summary>
    public class QuizOptionsModel
    {
       // [Range(0, 10, ErrorMessage = "The value must be greater than 0")]
        public int numOfAttempts { get; set; }
        //[Range(0, 100, ErrorMessage = "The value must be between 0 and 100")]
        public int PassingPercentage { get; set; }

        /// <summary>
        /// Creates a contructor for the model and sets default values to defined properties
        /// </summary>
        public QuizOptionsModel()
        {
            numOfAttempts = 3;
            PassingPercentage = 80;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// Updates the number of attemps for a particular module
        /// Updates the passing percentage for each quiz as defined by the admin
        /// </returns>
        public string UpdateOptions()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "UPDATE quizOptions SET numOfAttempts=@num , passPercentage=@pass";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@num", numOfAttempts);
                    cmd.Parameters.AddWithValue("@pass", PassingPercentage);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }
    }
}