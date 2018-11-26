using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Models
{
    public class ResetAttemptsModel
    {
        public int EmployeeID { get; set; }
        public int ModuleNum { get; set; }

        public string Name { get; set; }
        public string Module { get; set; }

        public List<SelectListItem> NameList { get; set; }
        public List<SelectListItem> ModuleList { get; set; }
        public int CompleteModules { get; set; }

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

        //public int GetCompletedModules()
        //{
        //    int id = new int();
        //    string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {

        //        string query = "SELECT completed_modules FROM completeModules WHERE employee_id=@id ";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            cmd.Parameters.AddWithValue("@id", EmployeeID);
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    id = sdr.GetInt32(0);
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return id;
        //}
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