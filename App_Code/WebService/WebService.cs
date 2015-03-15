using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


 [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {


    }

    private bool ValidAuth(string strToken)
    {

        if (GetStudentID(strToken) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    private int GetStudentID(string strToken)
    {

        var StudentToken = new Student_Token();
        StudentToken.StudentToken = strToken;
        StudentToken.SelectStudentTokenByToken();
        var StudentDetails = new Student();
        StudentDetails.StudentID = StudentToken.StudentID;
        StudentDetails.SelectStudentByID();

        return StudentDetails.StudentID;
    }




    [WebMethod]
    public string StudentLogin(string strStudentEmail, string strStudentPassword)
    {
        var Student = new Student();
        Hash HashPassword = new Hash();

        Student.StudentEmail = strStudentEmail;
        Student.StudentPassword = HashPassword.HashString(strStudentPassword);
        Student.SelectStudentByLogin();

        if (Student.StudentID == 0)
        {
            return "0";
        }

        var StudentToken = new Student_Token();
        StudentToken.StudentID = Student.StudentID;
        StudentToken.InsertStudentToken();
        StudentToken.SelectStudentTokenByID();

        return StudentToken.StudentToken;
    }



    [WebMethod]
    public WebStudent GetStudentDetails(string strToken)
    {

        var StudentToken = new Student_Token();

        StudentToken.StudentToken = strToken;

        StudentToken.SelectStudentTokenByToken();

        var StudentDetails = new WebStudent();

        StudentDetails.StudentID = StudentToken.StudentID;

        StudentDetails.SelectStudentByID();

        return StudentDetails;
    }

    [WebMethod]
    public Question GetNextQuestion(string strToken, int intResultID)
    {

        Question objReturnQuestion = new Question();
            
        if (ValidAuth(strToken) == true)
        {
            //Get Questions
            List<int> QuestionIDs = new List<int>(); //All questions by Exam
            List<int> AllQuestionIDs = new List<int>(); //All questions answered

            int QuestiontoReturn; //questionID to return

            var objResult = new Result();
            objResult.ResultID = intResultID;
            objResult.SelectResultByID();

            QuestionIDs = GetListOfQuestion(strToken, objResult.ExamID);

            //Get Answered Questions

            //Get AnswerIDs
            var objAnsweredQuestions = new Result_Answer();
            objAnsweredQuestions.ResultID = intResultID;
            List<int> AllResultAnswerIDs = new List<int>();
            AllResultAnswerIDs = objAnsweredQuestions.SelectAnswerByResultID();

            //Get QuestionIDs
                
            foreach(int p in AllResultAnswerIDs)
            {
                var objAnswers = new Answer();
                objAnswers.AnswerID = p;

                objAnswers.SelectAnswerByID();

                AllQuestionIDs.Add(objAnswers.QuestionID);

            }


            foreach (int q in QuestionIDs) //if question not answered use next one
            {
                if (AllQuestionIDs.Contains(q) == false)
                {
                    QuestiontoReturn = q;
                    objReturnQuestion.QuestionID = QuestiontoReturn;
                    objReturnQuestion.SelectQuestionByID();
                }
            }

        }

            return objReturnQuestion;
    }








    [WebMethod]
    public List<int> GetListOfQuestion(string strToken, int intExamID)
    {
        var AllQuestion = new Question_Bank();

        List<int> QuestionIDs = new List<int>();

        if (ValidAuth(strToken) == true)
        {

            AllQuestion.ExamID = intExamID;
            DataTable dtAllQuestions = new DataTable();
            dtAllQuestions = AllQuestion.SelectQuestionBankByExam();

            foreach (DataRow x in dtAllQuestions.Rows)
            {
                QuestionIDs.Add(Convert.ToInt32(x["fkQuestion_ID"]));
            }

            Exam CheckRandom = new Exam();
            CheckRandom.ExamID = intExamID;
            CheckRandom.SelectExamByID();

            if (CheckRandom.ExamQuestionsOrdered == true)
            {

                // Need to add way to order question bank

                //List<KeyValuePair<int,int>> QuestionsOrdered = new List<KeyValuePair<int,int>>();

                //foreach (int l in QuestionIDs)
                //{
                //    Question CheckQuestion = new Question();
                //    CheckQuestion.QuestionID = l;
                //    CheckQuestion.SelectQuestionByID();

                //    if(CheckQuestion.ord)

                //}

            }
            else
            {

            }

        }

        return QuestionIDs;
    }


    [WebMethod]
    public Question GetQuestion(string strToken, int intQuestionID)
    {
        var AllQuestion = new Question();

        if (ValidAuth(strToken) == true)
        {
            
            AllQuestion.QuestionID = intQuestionID;

            AllQuestion.SelectQuestionByID();
        }

        return AllQuestion;
    }


    [WebMethod]
    public List<WebAnswer> GetAnswersList(string strToken, int intQuestionID)
    {
        var AllAnswers = new WebAnswer();
        List<WebAnswer> ListOfAnswers = new List<WebAnswer>();

        if (ValidAuth(strToken) == true)
        {
           AllAnswers.QuestionID = intQuestionID;

           ListOfAnswers = AllAnswers.SelectAllAnswersList();
        }

        return ListOfAnswers;
    }


    [WebMethod]
    public WebExam GetExam(string strToken, int intExamID)
    {
        var objExam = new WebExam();

        if (ValidAuth(strToken) == true)
        {
            objExam.ExamID = intExamID;
            objExam.GetExamByID();
        }

        return objExam;
    }




    [WebMethod]
    public bool ValidatePassword(string strToken, int intExamID, string strPassword)
    {
        var objExam = new Exam();

        if (ValidAuth(strToken) == true)
        {
            objExam.ExamID = intExamID;
            objExam.ExamPassword = strPassword;
            return objExam.ValidatePassword();
        }

        return false;
    }




    [WebMethod]
    public int StartExam(string strToken, int intExam)
    {
        var NewResult = new Result();

        if (ValidAuth(strToken) == true)
        {
            NewResult.ExamID = intExam;
            NewResult.StudentID = GetStudentID(strToken);
            NewResult.InsertResult();

            NewResult.SelectResultByID();

        }

        return NewResult.ResultID;
    }



    [WebMethod]
    public Result GetResult(string strToken, int intResult)
    {
        var NewResult = new Result();
        bool ReturnResult = false;

        if (ValidAuth(strToken) == true)
        {
            NewResult.ResultID = intResult;
            NewResult.SelectResultByID();

            if (GetStudentID(strToken) == NewResult.StudentID)
            {
                ReturnResult = true;
            }
            else
            {
                ReturnResult = false;
            }
        }


        if (ReturnResult == true)
        {
            return NewResult;
        }
        else
        {
            return new Result();
        }
        
    }




    [WebMethod]
    public int EndExam(string strToken, int intResult)
    {
        var NewResult = new Result();

        if (ValidAuth(strToken) == true)
        {
            NewResult.ResultID = intResult;
            NewResult.SelectResultByID();

            if (NewResult.StudentID == GetStudentID(strToken));
            {
                NewResult.ResultDateTo = DateTime.Now;
                NewResult.ResultComplete = true;
                NewResult.UpdateResult();
            }


        }

        return NewResult.ResultID;
    }



    [WebMethod]
    public bool InsertAnswer(string strToken, Result_Answer objAnswer)
    {
        var NewAnswer = new Result_Answer();

        if (ValidAuth(strToken) == true)
        {
            NewAnswer = objAnswer;
            NewAnswer.InsertResultAnswer();

        }

        return true;
    }




    [WebMethod]
    public string GetSiteName()
    {
        var SiteName = new Setting();

        SiteName.SettingID = 1;
        SiteName.SelectSettingByID();
        return SiteName.SettingValue;

    }


    [WebMethod]
    public DataTable GetSubjects(string strToken)
    {
        DataTable Result = new DataTable();

        if (ValidAuth(strToken) == true)
        {
            var AllSubjects = new Subject();

            Result =  AllSubjects.SelectAllSubjects();
        }

        return Result;
    }


    [WebMethod]
    public DataTable GetModules(string strToken, int intSubject)
    {
        DataTable Result = new DataTable();

        if (ValidAuth(strToken) == true)
        {
            var AllModules = new Module();

            Result = AllModules.SelectAllModules(intSubject);
        }

        return Result;
    }


    [WebMethod]
    public DataTable GetExams(string strToken)
    {
        DataTable Result = new DataTable();

        if (ValidAuth(strToken) == true)
        {
            var AllExams = new Exam();

            Result = AllExams.SelectAllExams();
        }

        return Result;
    }


    [WebMethod]
    public DataTable GetListOfQuestions(string strToken, int intExamID)
    {
        DataTable Result = new DataTable();

        if (ValidAuth(strToken) == true)
        {
            var AllQuestions = new Question_Bank();
            AllQuestions.ExamID = intExamID;

            Result = AllQuestions.SelectQuestionBankByExam();
        }

        return Result;
    }


    [WebMethod]
    public DataTable GetAnswers(string strToken, int intQuestionID)
    {
        DataTable Result = new DataTable();

        if (ValidAuth(strToken) == true)
        {
            var AllAnswers = new WebAnswer();
            AllAnswers.QuestionID = intQuestionID;
            Result = AllAnswers.SelectAllAnswers();
        }

        return Result;
    }





}
