using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CybersecurityAwarenessPortal.Models
{
    public class UserProgressModel
    {
        public int numOfCompletedModules { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeEmail { get; set; }
        public double percentage { get; set; }
        public int mod { get; set; }
        public int availAttempts { get; set; }

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
                    cmd.Parameters.AddWithValue("@mail", EmployeeEmail);
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

        public int GetNumOfModulesCompleted()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(DISTINCT mod_num) FROM completeModule WHERE employee_id=@id AND completed=1";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
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

        public int GetMaxAttemptsM1()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(attempt_num) FROM userProgress WHERE employee_id =@id AND module_num=1";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            if(sdr.IsDBNull((0)))
                            {
                                id = 0;
                            }
                            else  id = sdr.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            return id;
        }

        public int GetMaxAttemptsM2()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(attempt_num) FROM userProgress WHERE employee_id =@id AND module_num=2";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
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

        public int GetMaxAttemptsM3()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(attempt_num) FROM userProgress WHERE employee_id =@id AND module_num=3";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
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

        public int GetMaxAttemptsM4()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(attempt_num) FROM userProgress WHERE employee_id =@id AND module_num=4";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
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

        public int GetAvailAttempts()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT numOfAttempts FROM quizOptions";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
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

    }
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }     
}