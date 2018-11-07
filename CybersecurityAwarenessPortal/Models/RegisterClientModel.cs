using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CybersecurityAwarenessPortal.Models
{
    public class RegisterClientModel
    {
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        public int MaxId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string LoginEmail { get; set; }

        public RegisterClientModel()
        {
            JoiningDate = DateTime.Now;
        }

        public List<SelectListItem> DepartmentList { get; set; }

        public List<SelectListItem> GetDepartmentList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT dep_name FROM departments";
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
                                Text = sdr["dep_Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }



        public int GetMaxId()
        {
            int id = new int();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT MAX(emp_ID) FROM employeeInfo";
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

        public string RegisterClient()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO employeeInfo VALUES(@id,@fname,@lname,@date,@dep,@password)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
                    cmd.Parameters.AddWithValue("@fname", FirstName);
                    cmd.Parameters.AddWithValue("@lname", LastName);
                    cmd.Parameters.AddWithValue("@date", JoiningDate);
                    cmd.Parameters.AddWithValue("@dep", Department);
                    cmd.Parameters.AddWithValue("@password", Password);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }

        public string CreateLogin()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO empValidation VALUES(@id,@mail,@password)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", EmployeeID);
                    cmd.Parameters.AddWithValue("@mail", LoginEmail);
                    cmd.Parameters.AddWithValue("@password", Password);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    con.Close();
                }
            }
            return "Success";
        }

    }
}