using System;
using System.Collections.Generic;
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
    public class QuestionRecords
    {
        public String questionID { get; set; }
        public String question { get; set; }
        public String optionA { get; set; }
        public String optionB { get; set; }
        public String optionC { get; set; }
        public String optionD { get; set; }
        public String answer { get; set; }

        public int attemptCount { get; set; }
        public int adminPassMark { get; set; }

        public int empNum { get; set; }

        public int mod { get; set; }

        public String empEmail { get; set; }


        public String userCorrectCount { get; set; }

        public String[,] questionnaire { get; set; }


        public int Counter { get; set; }

        public int questionCounter { get; set; }

        public List<QuestionRecords> questionInfo { get; set; }

        public String[] questionTest { get; set; }


        public int numOfCompletedModules { get; set; }
        public int passPercent { get; set; }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// The employee ID for the logged in employee
        /// </returns>
        public int GetEmployeeID()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT employeeID FROM empValidation WHERE userEmail=@mail";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@mail", empEmail);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            id = sdr.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return id;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// Maximum number of attempts of the selected user and selected module
        /// </returns>
        public int GetMaxAttemptsM1()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(attempt_num) FROM userProgress WHERE employee_id =@id AND module_num=@mod";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", empNum);
                    cmd.Parameters.AddWithValue("@mod",mod);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            if (sdr.IsDBNull((0)))
                            {
                                id = 0;
                            }
                            else id = sdr.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return id;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// The passing percentage stored in the DB
        /// </returns>
        public int GetPassPercent()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT passPercentage FROM quizOptions";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            id = sdr.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return id;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// Insert the number of modules of completed for the selected user 
        /// </returns>
        public string InsertNumOfModulesCompleted()
        {
 
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO completeModule VALUES (@id,@num,1)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", empNum);
                    cmd.Parameters.AddWithValue("@num", mod);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }
    }
}