using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Student_Token
/// </summary>
public class Student_Token
{

    public int StudentTokenID;
    public string StudentToken;
    public DateTime StudentTokenDateFrom;
    public DateTime StudentTokenDateTo;
    public int StudentID;


	public Student_Token()
	{

	}


    public bool SelectStudentTokenByStudentID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Student_Token "
                + "WHERE fkStudent_ID = @StudentID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@StudentID", StudentID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            StudentTokenID = Convert.ToInt32(dt.Rows[0]["pkStudent_TokenID"]);
            StudentToken = Convert.ToString(dt.Rows[0]["Student_Token"]);
            StudentTokenDateFrom = Convert.ToDateTime(dt.Rows[0]["Student_Token_Date_From"]);
            StudentTokenDateTo = Convert.ToDateTime(dt.Rows[0]["Student_Token_Date_To"]);
            StudentID = Convert.ToInt32(dt.Rows[0]["fkStudent_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }




    public bool InsertStudentToken()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Student_Token (Student_Token, Student_Token_Date_From, "
                + "Student_Token_Date_To, fkStudent_ID) "
                + "VALUES "
                + "(newid(),getdate(), DATEADD(day, 1, getdate()), @StudentID) "
                + "select CAST(Scope_Identity() AS int) ";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@StudentID", StudentID);

        try
        {
            connObj.Open();
            StudentTokenID = (int)cmd.ExecuteScalar();
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




    public bool SelectStudentTokenByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Student_Token "
                + "WHERE pkStudent_TokenID = @StudentTokenID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@StudentTokenID", StudentTokenID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            StudentTokenID = Convert.ToInt32(dt.Rows[0]["pkStudent_TokenID"]);
            StudentToken = Convert.ToString(dt.Rows[0]["Student_Token"]);
            StudentTokenDateFrom = Convert.ToDateTime(dt.Rows[0]["Student_Token_Date_From"]);
            StudentTokenDateTo = Convert.ToDateTime(dt.Rows[0]["Student_Token_Date_To"]);
            StudentID = Convert.ToInt32(dt.Rows[0]["fkStudent_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }




}