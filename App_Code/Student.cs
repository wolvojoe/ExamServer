﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{

    public int StudentID;
    public string StudentFirstName;
    public string StudentLastName;
    public string StudentEmail;
    public string StudentPassword;
    public bool StudentActive;
    public int StudentGroupID;

	public Student()
	{

	}


    public bool SelectStudentByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Student "
                + "WHERE pkStudent_ID = @StudentID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@StudentID", StudentID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            StudentID = Convert.ToInt32(dt.Rows[0]["pkStudent_ID"]);
            StudentFirstName = Convert.ToString(dt.Rows[0]["Student_First_Name"]);
            StudentLastName = Convert.ToString(dt.Rows[0]["Student_Last_Name"]);
            StudentEmail = Convert.ToString(dt.Rows[0]["Student_Email"]);
            StudentPassword = Convert.ToString(dt.Rows[0]["Student_Password"]);
            StudentActive = Convert.ToBoolean(dt.Rows[0]["Student_Active"]);
            StudentGroupID = Convert.ToInt32(dt.Rows[0]["fkGroup_ID"]);
            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateGroup()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Student "
                + "SET "
                + "Student_First_Name = @StudentFirstName, "
                + "Student_Last_Name = @StudentLastName, "
                + "Student_Email = @StudentEmail, "
                + "Student_Password = @StudentPassword, "
                + "Student_Active = @StudentActive, "
                + "fkGroup_ID = @StudentGroupID "
                + "WHERE pkStudent_ID = @StudentID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@StudentID", StudentID);

        cmd.Parameters.AddWithValue("@StudentFirstName", StudentFirstName);
        cmd.Parameters.AddWithValue("@StudentLastName", StudentLastName);
        cmd.Parameters.AddWithValue("@StudentEmail", StudentEmail);
        cmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
        cmd.Parameters.AddWithValue("@StudentActive", StudentActive);
        cmd.Parameters.AddWithValue("@StudentGroupID", StudentGroupID);

        try
        {
            connObj.Open();
            cmd.ExecuteNonQuery();
        }
        finally
        {
            if (connObj != null)
            {
                connObj.Close();
            }
        }

        return true;
    }




    public bool InsertGroup()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Student (Student_First_Name,Student_Last_Name, Student_Email, Student_Password, Student_Active," 
                + " fkGroup_ID) "
                + "VALUES "
                + "(@StudentFirstName,@StudentLastName, @StudentEmail, @StudentPassword, @StudentActive, @StudentGroupID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@StudentFirstName", StudentFirstName);
        cmd.Parameters.AddWithValue("@StudentLastName", StudentLastName);
        cmd.Parameters.AddWithValue("@StudentEmail", StudentEmail);
        cmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
        cmd.Parameters.AddWithValue("@StudentActive", StudentActive);
        cmd.Parameters.AddWithValue("@StudentGroupID", StudentGroupID);

        try
        {
            connObj.Open();
            cmd.ExecuteNonQuery();
        }
        finally
        {
            if (connObj != null)
            {
                connObj.Close();
            }
        }

        return true;
    }


}