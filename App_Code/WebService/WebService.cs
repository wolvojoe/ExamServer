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
