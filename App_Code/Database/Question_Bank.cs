using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Question_Bank
/// </summary>
public class Question_Bank
{

    public int QuestionBankID;
    public int QuestionID;
    public int ExamID;

    public Question_Bank()
    {

    }


    public bool SelectQuestionBankByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question_Bank "
                + "WHERE pkQuestion_Bank_ID = @QuestionBankID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@QuestionBankID", QuestionBankID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            QuestionBankID = Convert.ToInt32(dt.Rows[0]["pkQuestion_Bank_ID"]);
            QuestionID = Convert.ToInt32(dt.Rows[0]["fkQuestion_ID"]);
            ExamID = Convert.ToInt32(dt.Rows[0]["fkExam_ID"]);


            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateQuestionBank()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Question_Bank "
                + "SET "
                + "fkQuestion_ID = @QuestionID, "
                + "fkExam_ID = @ExamID "
                + "WHERE pkQuestion_Bank_ID = @QuestionBankID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);
        cmd.Parameters.AddWithValue("@QuestionBankID", QuestionBankID);

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




    public bool InsertQuestionBank()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Question_Bank (fkQuestion_ID, fkExam_ID) "
                + "VALUES "
                + "(@QuestionID, @ExamID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);

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



    public bool DeleteQuestionBank()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "DELETE FROM Question_Bank "
                + "WHERE pkQuestion_Bank_ID = @QuestionBankID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@QuestionBankID", QuestionBankID);

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



    public DataTable SelectQuestionBankByExam()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Question_Bank "
                + "JOIN Exam "
                + "ON pkExam_ID = fkExam_ID "
                + "JOIN Question "
                + "ON pkQuestion_ID = fkQuestion_ID "
                + "JOIN Module "
                + "ON pkModule_ID = fkModule_ID "
                + "JOIN Subject "
                + "ON pkSubject_ID = fkSubject_ID "
                + "WHERE pkExam_ID = @ExamID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ExamID", ExamID);
            adapter.Fill(dt);
        }

        return dt;

    }



}