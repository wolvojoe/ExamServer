using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;


/// <summary>
/// Summary description for Question
/// </summary>
public class Question
{

    public int QuestionID;
    public string QuestionName;
    public string QuestionDescription;
    public bool QuestionActive;
    public int ModuleID;
    public int QuestionTypeID;

	public Question()
	{

	}



    public bool SelectQuestionByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question "
                + "WHERE pkQuestion_ID = @QuestionID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@QuestionID", QuestionID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            QuestionID = Convert.ToInt32(dt.Rows[0]["pkQuestion_ID"]);
            QuestionName = Convert.ToString(dt.Rows[0]["Question_Name"]);
            QuestionDescription = Convert.ToString(dt.Rows[0]["Question_Description"]);
            QuestionActive = Convert.ToBoolean(dt.Rows[0]["Question_Active"]);
            ModuleID = Convert.ToInt32(dt.Rows[0]["fkModule_ID"]);
            QuestionTypeID = Convert.ToInt32(dt.Rows[0]["fkQuestion_Type_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateQuestion()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Question "
                + "SET "
                + "Question_Name = @QuestionName, "
                + "Question_Description = @QuestionDescription, "
                + "Question_Active = @QuestionActive, "
                + "fkModule_ID = @ModuleID, "
                + "fkQuestion_Type_ID = @QuestionTypeID "
                + "WHERE pkQuestion_ID = @QuestionID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionName", QuestionName);
        cmd.Parameters.AddWithValue("@QuestionDescription", QuestionDescription);
        cmd.Parameters.AddWithValue("@QuestionActive", QuestionActive);
        cmd.Parameters.AddWithValue("@ModuleID", ModuleID);
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



    public bool InsertQuestion()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Question (Question_Name,Question_Description, Question_Active, fkModule_ID, fkQuestionType_ID) "
                + "VALUES "
                + "(@QuestionName,@QuestionDescription, @QuestionActive, @ModuleID, @QuestionTypeID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionName", QuestionName);
        cmd.Parameters.AddWithValue("@QuestionDescription", QuestionDescription);
        cmd.Parameters.AddWithValue("@QuestionActive", QuestionActive);
        cmd.Parameters.AddWithValue("@ModuleID", ModuleID);
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


    public DataTable SelectAllQuestions(int SubjectID, int ModuleID)
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question "
                + "JOIN Module "
                + "ON pkModule_ID = fkModule_ID "
                + "JOIN Subject "
                + "ON pkSubject_ID = fkSubject_ID ";

        if (ModuleID > 0)
        {
            sqlText = sqlText + "WHERE pkModule_ID = @ModuleID ";
        }
        else if (SubjectID > 0)
        {
            sqlText = sqlText + "WHERE pkSubject_ID = @SubjectID ";
        }

        sqlText = sqlText + "ORDER BY Subject_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@SubjectID", SubjectID);
            adapter.SelectCommand.Parameters.AddWithValue("@ModuleID", SubjectID);
            adapter.Fill(dt);
        }

        return dt;

    }

}