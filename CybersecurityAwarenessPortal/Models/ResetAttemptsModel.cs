using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
namespace CybersecurityAwarenessPortal.Models
{
    /// <summary>
    /// The model class is that which defines all the user and data properties
    /// It is the class where all the methods are defined 
    /// It handles all the database interactions
    /// </summary>
    public class ResetAttemptsModel
    {
        public int EmployeeID { get; set; }
        public int ModuleNum { get; set; }

        public string Name { get; set; }
        public string Module { get; set; }

        public List<SelectListItem> NameList { get; set; }
        public List<SelectListItem> ModuleList { get; set; }
        public int CompleteModules { get; set; }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// The list of all employee names
        /// </returns>
        public List<SelectListItem> GetNameList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT emp_firstName + ' ' +  emp_lastName AS username FROM [employeeInfo] WHERE emp_firstName NOT IN ('Admin')";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["username"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// The list of all modules
        /// </returns>
        public List<SelectListItem> GetModuleList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT section_name FROM dbo.section WHERE section_number NOT IN (5)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["section_name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// The module number for the selected module
        /// </returns>
        public int GetModuleNum()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT section_number FROM [section] WHERE section_name=@mod";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@mod", Module);
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
        /// The employee ID for the selected employee
        /// </returns>
        public int GetEmployeeID()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                string query = "SELECT emp_id FROM employeeInfo WHERE emp_firstName + ' ' + emp_lastName LIKE '%' + @name + '%' ";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", Name);
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
        /// Deletes all attempts for the selected employee for the selected module
        /// </returns>
        public string ResetAttempts()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM userProgress WHERE employee_id=@id AND module_num=@mod";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
                    cmd.Parameters.AddWithValue("@mod", ModuleNum);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }

        /// <summary>
        /// Retreives the connection string stored in the Web.Config file
        /// Defines the query to run and establishes a connection to the database
        /// Gets the query result and stores it in the defined variable
        /// </summary>
        /// <returns>
        /// Deletes the progress for that module
        /// </returns>
        public string ResetCompletedModules()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM completeModule WHERE employee_id=@id AND mod_num=@mod";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
                    cmd.Parameters.AddWithValue("@mod", ModuleNum);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }
    }
}