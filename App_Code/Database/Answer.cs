using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Answer
/// </summary>
public class Answer
{

    public int AnswerID;
    public string AnswerName;
    public string AnswerDescription;
    public int AnswerOrder;
    public bool AnswerCorrect;
    public int QuestionID;

	public Answer()
	{

	}


    public bool SelectAnswerByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Answer "
                + "WHERE pkAnswer_ID = @AnswerID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@AnswerID", AnswerID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            AnswerID = Convert.ToInt32(dt.Rows[0]["pkAnswer_ID"]);
            AnswerName = Convert.ToString(dt.Rows[0]["Answer_Name"]);
            AnswerDescription = Convert.ToString(dt.Rows[0]["Answer_Description"]);
            AnswerOrder = Convert.ToInt32(dt.Rows[0]["Answer_Order"]);
            AnswerCorrect = Convert.ToBoolean(dt.Rows[0]["Answer_Correct"]);
            QuestionID = Convert.ToInt32(dt.Rows[0]["fkQuestion_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }


    public bool UpdateAnswer()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Answer "
                + "SET "
                + "Answer_Name = @AnswerName, "
                + "Answer_Description = @AnswerDescription, "
                + "Answer_Order = @AnswerOrder, "
                + "Answer_Correct = @AnswerCorrect, "
                + "fkQuestion_ID = @QuestionID "
                + "WHERE pkAnswer_ID = @AnswerID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@AnswerName", AnswerName);
        cmd.Parameters.AddWithValue("@AnswerDescription", AnswerDescription);
        cmd.Parameters.AddWithValue("@AnswerOrder", AnswerOrder);
        cmd.Parameters.AddWithValue("@AnswerCorrect", AnswerCorrect);
        cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
        cmd.Parameters.AddWithValue("@AnswerID", AnswerID);

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



    public bool InsertAnswer()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Answer (Answer_Name, Answer_Description, Answer_Order, Answer_Correct, fkQuestion_ID) "
                + "VALUES "
                + "(@AnswerName,@AnswerDescription, @AnswerOrder, @AnswerCorrect @QuestionID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@AnswerName", AnswerName);
        cmd.Parameters.AddWithValue("@AnswerDescription", AnswerDescription);
        cmd.Parameters.AddWithValue("@AnswerOrder", AnswerOrder);
        cmd.Parameters.AddWithValue("@AnswerCorrect", AnswerCorrect);
        cmd.Parameters.AddWithValue("@QuestionID", QuestionID);

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


    public DataTable SelectAllAnswers(int QuestionID)
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Answer ";

                if (QuestionID > 0)
                {
                    sqlText = sqlText + "WHERE fkQuestion_ID = @QuestionID ";
                }

                sqlText = sqlText + "ORDER BY Answer_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.Fill(dt);
        }

        return dt;

    }



}