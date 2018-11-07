using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CybersecurityAwarenessPortal.Models
{
    public class QuizOptionsModel
    {
       // [Range(0, 10, ErrorMessage = "The value must be greater than 0")]
        public int numOfAttempts { get; set; }
        //[Range(0, 100, ErrorMessage = "The value must be between 0 and 100")]
        public int PassingPercentage { get; set; }

        public QuizOptionsModel()
        {
            numOfAttempts = 3;
            PassingPercentage = 80;
        }

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