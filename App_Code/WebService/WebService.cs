using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


 [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {


    }


    [WebMethod]
    public Student ValidateStudent(string strStudentEmail, string strStudentPassword)
    {
        var Student = new Student();

        Student.StudentEmail = strStudentEmail;
        Student.StudentPassword = strStudentPassword;

        return Student;
    }


    [WebMethod]
    public Machine ValidateMachine(string strMachineAuthCode)
    {
        var Machine = new Machine();

        Machine.MachineAuthCode = strMachineAuthCode;
        Machine.SelectMachineByCode();

        return Machine;
    }


    [WebMethod]
    public Exam SelectExam(int intExamID)
    {
        var Exam = new Exam();

        Exam.ExamID = intExamID;
        Exam.SelectExamByID();

        return Exam;
    }



}
