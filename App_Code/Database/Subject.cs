using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{

    public int SubjectID;
    public string SubjectName;
    public bool SubjectActive;

	public Subject()
	{

	}

    public bool SelectSubjectByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Subject "
                + "WHERE pkSubject_ID = @SubjectID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@SubjectID", SubjectID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            SubjectID = Convert.ToInt32(dt.Rows[0]["pkStudent_ID"]);
            SubjectName = Convert.ToString(dt.Rows[0]["Subject_Name"]);
            SubjectActive = Convert.ToBoolean(dt.Rows[0]["Subject_Active"]);
            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateSubject()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Subject "
                + "SET "

                + "Subject_Name = @SubjectName, "
                + "Subject_Active = @SubjectActive "
                + "WHERE pkSubject_ID = @SubjectID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
        cmd.Parameters.AddWithValue("@SubjectActive", SubjectActive);
        cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

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



    public bool InsertSubject()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Subject (Subject_Name,Subject_Active) "
                + "VALUES "
                + "(@SubjectName,@SubjectActive)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
        cmd.Parameters.AddWithValue("@SubjectActive", SubjectActive);

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


    public DataTable SelectAllSubjects()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Subject "
                + "ORDER BY Subject_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.Fill(dt);
        }

        return dt;

    }
}