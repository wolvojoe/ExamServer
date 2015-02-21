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
    public string StudentLogin(string strStudentEmail, string strStudentPassword)
    {
        var Student = new Student();
        Hash HashPassword = new Hash();

        Student.StudentEmail = strStudentEmail;
        Student.StudentPassword = HashPassword.HashString(strStudentPassword);

        Student.SelectStudentByLogin();

        var StudentToken = new Student_Token();

        StudentToken.StudentID = Student.StudentID;

        StudentToken.InsertStudentToken();

        StudentToken.SelectStudentTokenByID();

        return StudentToken.StudentToken;
    }






}
