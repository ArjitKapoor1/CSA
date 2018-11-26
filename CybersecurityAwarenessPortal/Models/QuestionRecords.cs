using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CybersecurityAwarenessPortal.Models
{
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
        //public String questionID { get; set; }
        //public String question { get; set; }
        //public String optionA { get; set; }
        //public String optionB { get; set; }
        //public String optionC { get; set; }
        //public String optionD { get; set; }
        //public String answer { get; set; }

        //public int attemptCount { get; set; }

        //public int empNum { get; set; }

        //public int mod { get; set; }

        //public String empEmail { get; set; }

        //public String userCorrectCount { get; set; }

        //public String[,] questionnaire { get; set; }

        public String[] questionTest { get; set; }

        //public int Counter { get; set; }

        //public int questionCounter { get; set; }

        //public List<QuestionRecords> questionInfo { get; set; }

        public int numOfCompletedModules { get; set; }
        public int passPercent { get; set; }

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

        //public int GetNumOfModulesCompleted()
        //{
        //    int id = new int();
        //    string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = "SELECT completed_modules FROM completeModules WHERE employee_id=@id";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.Parameters.AddWithValue("@id", empNum);
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