using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Question_Type
/// </summary>
public class Question_Type
{

    public int QuestionTypeID;
    public string QuestionTypeName;
    public string QuestionTypeDescription;

	public Question_Type()
	{

	}


    public bool SelectQuestionTypeByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question_Type "
                + "WHERE pkQuestion_Type_ID = @QuestionTypeID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@QuestionTypeID", QuestionTypeID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            QuestionTypeID = Convert.ToInt32(dt.Rows[0]["pkQuestion_Type_ID"]);
            QuestionTypeName = Convert.ToString(dt.Rows[0]["Question_Type_Name"]);
            QuestionTypeDescription = Convert.ToString(dt.Rows[0]["Question_Type_Description"]);

            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateQuestionType()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Question_Type "
                + "SET "
                + "Question_Type_Name = @QuestionTypeName, "
                + "Question_Type_Description = @QuestionTypeDescription "
                + "WHERE pkQuestion_Type_ID = @QuestionTypeID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionTypeName", QuestionTypeName);
        cmd.Parameters.AddWithValue("@QuestionTypeDescription", QuestionTypeDescription);
        cmd.Parameters.AddWithValue("@QuestionTypeID", QuestionTypeID);

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



    public bool InsertQuestionType()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Question_Type (Question_Type_Name,Question_Type_Description) "
                + "VALUES "
                + "(@QuestionTypeName,@QuestionTypeDescription)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionTypeName", QuestionTypeName);
        cmd.Parameters.AddWithValue("@QuestionTypeDescription", QuestionTypeDescription);

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



    public DataTable SelectAllQuestionTypes()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question_Type "
                + "ORDER BY Question_Type_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.Fill(dt);
        }

        return dt;

    }


}