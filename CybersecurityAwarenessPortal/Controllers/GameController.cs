﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CybersecurityAwarenessPortal.Models;
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
    public class GameController : Controller
    {
        // GET: Game


        [HttpPost]
        public ActionResult question(QuestionRecords qr)
        {

            String[] nextQuestion = new String[200];

            qr.Counter = qr.Counter + 1;
            if (qr.Counter < qr.questionCounter)
            {
                nextQuestion[0] = qr.questionnaire[qr.Counter, 0];
                nextQuestion[1] = qr.questionnaire[qr.Counter, 1];
                nextQuestion[2] = qr.questionnaire[qr.Counter, 2];
                nextQuestion[3] = qr.questionnaire[qr.Counter, 3];
                nextQuestion[4] = qr.questionnaire[qr.Counter, 4];
                nextQuestion[5] = qr.questionnaire[qr.Counter, 5];
                nextQuestion[6] = qr.questionnaire[qr.Counter, 6];
            }
            qr.questionTest = nextQuestion;

            return View("question", qr);


        }
        /// <summary>
        /// This View is called when the take the quiz option is selected
        /// </summary>
        /// <returns></returns>
        public ActionResult GamePage2(QuestionRecords qr)
        {
            string mainConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(mainConnection);

            string empemail = Session["username"].ToString();// put session here or FAKE IT!!!

            string empQuery = "SELECT * from empvalidation where userEmail = '" + empemail + "'";

            SqlCommand SqlCom = new SqlCommand(empQuery);
            SqlCom.Connection = sqlCon;

            sqlCon.Open();

            SqlDataReader sdr = SqlCom.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    qr.empNum = (int)sdr["employeeid"];
                    qr.empEmail = sdr["userEmail"].ToString();
                }
            }

            sqlCon.Close();
            qr.mod = Convert.ToInt32(Session["moduleid"]);
            //-----------------------------------------------------------------//
            //int empN = qr.empNum;
            int empN = qr.GetEmployeeID();
            qr.empNum = qr.GetEmployeeID();
            qr.attemptCount = qr.GetMaxAttemptsM1();

            //-----------------------------------------------------------------//

            string adminPassMarkQuery = "SELECT * from quizOptions";

            SqlCom = new SqlCommand(adminPassMarkQuery);
            SqlCom.Connection = sqlCon;

            sqlCon.Open();

            sdr = SqlCom.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    qr.adminPassMark = (int)sdr["passPercentage"];
                }
            }

            sqlCon.Close();

            //***************************************
            //***************************************
            //***************************************
            //***************************************
            Random radNum = new Random();
            string QuestionQuery = "SELECT * FROM questions where sectionID = " + qr.mod + "";

            SqlCom = new SqlCommand(QuestionQuery);
            SqlCom.Connection = sqlCon;

            sqlCon.Open();
            int counter = 0;
            String[,] quest = new String[200, 200];
            String[] questionTest = new String[200];
            sdr = SqlCom.ExecuteReader();
            List<QuestionRecords> objmodel = new List<QuestionRecords>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var detail = new QuestionRecords();
                    //detail.questionID = sdr["QuestionID"].ToString();
                    detail.question = sdr["questionContent"].ToString();
                    detail.optionA = sdr["optionA"].ToString();
                    detail.optionB = sdr["optionB"].ToString();
                    detail.optionC = sdr["optionC"].ToString();
                    detail.optionD = sdr["optionD"].ToString();
                    detail.answer = sdr["correct"].ToString();
                    counter++;
                    objmodel.Add(detail);
                }


                qr.Counter = 0;
                qr.questionCounter = counter;
                qr.questionInfo = objmodel;
                sqlCon.Close();
            }
            return View("GamePage2", qr);
        }

        [HttpPost]
        public ActionResult GameStat(QuestionRecords qr)
        {
            try

            {
                string mainConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(mainConnection);

                string empemail = "fake@hotmail.com";// put session here or FAKE IT!!!

                string empQuery = "SELECT * from empvalidation where userEmail = '" + empemail + "'";

                SqlCommand SqlCom = new SqlCommand(empQuery);
                SqlCom.Connection = sqlCon;

                sqlCon.Open();

                SqlDataReader sdr = SqlCom.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        qr.empNum = (int)sdr["employeeid"];
                        qr.empEmail = sdr["userEmail"].ToString();
                    }
                }

                sqlCon.Close();
                //-----------------------------------------------------------------//
                //int empN = qr.empNum;
                qr.empEmail = Session["username"].ToString();
                qr.empNum = qr.GetEmployeeID();
                int empN = qr.GetEmployeeID();
                qr.mod = Convert.ToInt32(Session["moduleid"]);
                qr.attemptCount = qr.GetMaxAttemptsM1() + 1;
                

                string QuestionQuery = "SELECT * FROM questions where sectionID = " + qr.mod + "";

                SqlCom = new SqlCommand(QuestionQuery);
                SqlCom.Connection = sqlCon;

                sqlCon.Open();
                int counter = 0;
                String[,] quest = new String[200, 200];
                String[] questionTest = new String[200];
                sdr = SqlCom.ExecuteReader();
                List<QuestionRecords> objmodel = new List<QuestionRecords>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var detail = new QuestionRecords();
                        //detail.questionID = sdr["QuestionID"].ToString();
                        detail.question = sdr["questionContent"].ToString();
                        detail.optionA = sdr["optionA"].ToString();
                        detail.optionB = sdr["optionB"].ToString();
                        detail.optionC = sdr["optionC"].ToString();
                        detail.optionD = sdr["optionD"].ToString();
                        detail.answer = sdr["correct"].ToString();

                        //quest[counter, 0] = detail.questionID;
                        quest[counter, 1] = detail.question;
                        quest[counter, 2] = detail.optionA;
                        quest[counter, 3] = detail.optionB;
                        quest[counter, 4] = detail.optionC;
                        quest[counter, 5] = detail.optionD;
                        quest[counter, 6] = detail.answer;
                        //ViewBag.optionC = detail.optionC;
                        counter++;
                        objmodel.Add(detail);
                    }

                    questionTest[0] = quest[0, 0];
                    questionTest[1] = quest[0, 1];
                    questionTest[2] = quest[0, 2];
                    questionTest[3] = quest[0, 3];
                    questionTest[4] = quest[0, 4];
                    questionTest[5] = quest[0, 5];
                    questionTest[6] = quest[0, 6];

                    qr.Counter = 0;
                    qr.questionCounter = counter;
                    qr.questionTest = questionTest;
                    qr.questionInfo = objmodel;
                    qr.questionnaire = quest;
                    sqlCon.Close();
                }
                //----------------------------------------------------------//



                

                SqlParameter empID = new SqlParameter("@employee_id", SqlDbType.Int, 10);
                empID.Value = qr.GetEmployeeID();

                SqlParameter modNum = new SqlParameter("@module_num", SqlDbType.Int, 10);
                modNum.Value = qr.mod;
                // qr.mod = qr.mod + 1;

                SqlParameter pointNum = new SqlParameter("@pointNum", SqlDbType.Int, 10);

                SqlParameter scoreNum = new SqlParameter("@score", SqlDbType.Int, 10);

                var keys = Request.Form.AllKeys;
                string[] test1 = Request.Form.AllKeys;

                string item1 = Array.Find(test1, element => element.Contains("userCorrectLabel"));
                scoreNum.Value = Request.Form.Get(keys[0]);
                //scoreNum.Value = Request.Form.Get(keys[0]);
                //qr.userCorrectCount =(int) Request.Form.Get(keys[0]) + 1;
                //scoreNum.Value = 60;

                string[] test2 = Request.Form.AllKeys;

                string item2 = Array.Find(test2, element => element.Contains("currentAttemptLabel"));
                string item3 = Array.Find(test2, element => element.Contains("pointEndGamePageLabel"));

                SqlParameter temptNum = new SqlParameter("@attemptNum", SqlDbType.Int, 10);
                qr.attemptCount = qr.GetMaxAttemptsM1() + 1;
                temptNum.Value = qr.attemptCount;

                string query = "INSERT INTO userProgress (employee_id,module_num,score,attempt_num) values(@employee_id,@module_num,@score,@attemptNum)";



                /*
                int modSelect = 2;
                int empNum = 2;
                string query = "SELECT * FROM questions where sectionID = " + empNum + "";
                */


                SqlCom = new SqlCommand(query);
                SqlCom.Connection = sqlCon;

                sqlCon.Open();
               
                SqlCom = new SqlCommand(query, sqlCon);

                //SqlCom.Parameters.Add(testP2);

                SqlCom.Parameters.Add(empID);
                SqlCom.Parameters.Add(modNum);
                SqlCom.Parameters.Add(scoreNum);
                SqlCom.Parameters.Add(temptNum);
                SqlCom.Prepare();
                SqlCom.ExecuteNonQuery();
                /*}
                else { }*/
                sqlCon.Close();
                qr.passPercent = qr.GetPassPercent();
                if (Convert.ToInt32(scoreNum.Value) >= qr.passPercent)
                {

                    string result = qr.InsertNumOfModulesCompleted();
                }
            }
            catch (SqlException)
            {

            };
            return RedirectToAction("ContentView","Content", qr);
        }
    }
}