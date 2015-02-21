using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebStudent
/// </summary>
public class WebStudent
{

    public int StudentID;
    public string StudentFirstName;
    public string StudentLastName;
    public string StudentEmail;
    public int StudentDepartmentID;

	public WebStudent()
	{

	}

    public void SelectStudentByID()
    {
        var StudentDetails = new Student();

        StudentDetails.StudentID = StudentID;

        StudentDetails.SelectStudentByID();

        StudentID = StudentDetails.StudentID;
        StudentFirstName = StudentDetails.StudentFirstName;
        StudentLastName = StudentDetails.StudentLastName;
        StudentEmail = StudentDetails.StudentEmail;
        StudentDepartmentID = StudentDetails.StudentDepartmentID;

    }

}