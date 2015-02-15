using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Exam
/// </summary>
public class Exam
{

    public int ExamID;
    public String ExamName;
    public DateTime ExamDateCreated;
    public bool ExamActive;
    public String ExamDescription;
    public DateTime ExamOpenDate;
    public bool ExamOpenDateEnabled;
    public DateTime ExamClosedDate;
    public bool ExamClosedDateEnabled;
    public int ExamTimeLimit;
    public bool ExamTimeLimitEnabled;
    public int ExamAttemptsAllowed;
    public bool ExamQuestionsOrdered;
    public bool ExamShuffleAnswers;
    public bool ExamLearningMode;
    public String ExamPassword;


	public Exam()
	{

	}


    public bool SelectExamByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Exam "
                + "WHERE pkExam_ID = @ExamID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ExamID", ExamID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            ExamID = Convert.ToInt32(dt.Rows[0]["pkExam_ID"]);
            ExamName = Convert.ToString(dt.Rows[0]["Exam_Name"]);
            ExamDateCreated = Convert.ToDateTime(dt.Rows[0]["Exam_Date_Created"]);
            ExamActive = Convert.ToBoolean(dt.Rows[0]["Exam_Active"]);
            ExamDescription = Convert.ToString(dt.Rows[0]["Exam_Description"]);
            ExamOpenDate = Convert.ToDateTime(dt.Rows[0]["Exam_Open_Date"]);
            ExamOpenDateEnabled = Convert.ToBoolean(dt.Rows[0]["Exam_Open_Date_Enabled"]);
            ExamClosedDate = Convert.ToDateTime(dt.Rows[0]["Exam_Closed_Date"]);
            ExamClosedDateEnabled = Convert.ToBoolean(dt.Rows[0]["Exam_Closed_Date_Enabled"]);
            ExamTimeLimit = Convert.ToInt32(dt.Rows[0]["Exam_Time_Limit"]);
            ExamTimeLimitEnabled = Convert.ToBoolean(dt.Rows[0]["Exam_Time_Limit_Enabled"]);
            ExamAttemptsAllowed = Convert.ToInt32(dt.Rows[0]["Exam_Attempts_Allowed"]);
            ExamQuestionsOrdered = Convert.ToBoolean(dt.Rows[0]["Exam_Questions_Ordered"]);
            ExamShuffleAnswers = Convert.ToBoolean(dt.Rows[0]["Exam_Shuffle_Answers"]);
            ExamLearningMode = Convert.ToBoolean(dt.Rows[0]["Exam_Learning_Mode"]);
            ExamPassword = Convert.ToString(dt.Rows[0]["Exam_Password"]);

            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateExam()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Exam "
                + "SET "

                + "Exam_Name = @ExamName, "
                + "Exam_Date_Created = @ExamDateCreated, "
                + "Exam_Active = @ExamActive, "
                + "Exam_Description = @ExamDescription, "
                + "Exam_Open_Date = @ExamOpenDate, "
                + "Exam_Open_Date_Enabled = @ExamOpenDateEnabled, "
                + "Exam_Closed_Date = @ExamClosedDate, "
                + "Exam_Closed_Date_Enabled = @ExamClosedDateEnabled, "
                + "Exam_Time_Limit = @ExamTimeLimit, "
                + "Exam_Time_Limit_Enabled = @ExamTimeLimitEnabled, "
                + "Exam_Attempts_Allowed = @ExamAttemptsAllowed, "
                + "Exam_Questions_Ordered = @ExamQuestionsOrdered, "
                + "Exam_Shuffle_Answers = @ExamShuffleAnswers, "
                + "Exam_Learning_Mode = @ExamLearningMode, "
                + "Exam_Password = @ExamPassword, "

                + "WHERE pkExam_ID = @ExamID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ExamName", ExamName);
        cmd.Parameters.AddWithValue("@ExamDateCreated", ExamDateCreated);
        cmd.Parameters.AddWithValue("@ExamActive", ExamActive);
        cmd.Parameters.AddWithValue("@ExamDescription", ExamDescription);
        cmd.Parameters.AddWithValue("@ExamOpenDate", ExamOpenDate);
        cmd.Parameters.AddWithValue("@ExamOpenDateEnabled", ExamOpenDateEnabled);
        cmd.Parameters.AddWithValue("@ExamClosedDate", ExamClosedDate);
        cmd.Parameters.AddWithValue("@ExamClosedDateEnabled", ExamClosedDateEnabled);
        cmd.Parameters.AddWithValue("@ExamTimeLimit", ExamTimeLimit);
        cmd.Parameters.AddWithValue("@ExamTimeLimitEnabled", ExamTimeLimitEnabled);
        cmd.Parameters.AddWithValue("@ExamAttemptsAllowed", ExamAttemptsAllowed);
        cmd.Parameters.AddWithValue("@ExamQuestionsOrdered", ExamQuestionsOrdered);
        cmd.Parameters.AddWithValue("@ExamShuffleAnswers", ExamShuffleAnswers);
        cmd.Parameters.AddWithValue("@ExamLearningMode", ExamLearningMode);
        cmd.Parameters.AddWithValue("@ExamPassword", ExamPassword);

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



    public bool InsertExam()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Exam (Exam_Name, Exam_Date_Created, Exam_Active, Exam_Description, "
                + "Exam_Open_Date, Exam_Open_Date_Enabled, Exam_Closed_Date, Exam_Closed_Date_Enabled, "
                + "Exam_Time_Limit, Exam_Time_Limit_Enabled, Exam_Attempts_Allowed, Exam_Questions_Ordered, "
                + "Exam_Shuffle_Answers, Exam_Learning_Mode, Exam_Password) "
                + "VALUES "
                + "(@ExamName, getdate(), @ExamActive, @ExamDescription, @ExamOpenDate, @ExamOpenDateEnabled, "
                + "@ExamClosedDate, @ExamClosedDateEnabled, @ExamTimeLimit, @ExamTimeLimitEnabled, @ExamAttemptsAllowed, "
                + "@ExamQuestionsOrdered, @ExamShuffleAnswers, @ExamLearningMode, @ExamPassword)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ExamName", ExamName);
        cmd.Parameters.AddWithValue("@ExamActive", ExamActive);
        cmd.Parameters.AddWithValue("@ExamDescription", ExamDescription);


        if (ExamOpenDate > DateTime.MinValue)
        {
            cmd.Parameters.AddWithValue("@ExamOpenDate", ExamOpenDate);
        }
        else
        {
            cmd.Parameters.AddWithValue("@ExamOpenDate", DBNull.Value);
        }
        
        cmd.Parameters.AddWithValue("@ExamOpenDateEnabled", ExamOpenDateEnabled);


        if (ExamClosedDate > DateTime.MinValue)
        {
            cmd.Parameters.AddWithValue("@ExamClosedDate", ExamClosedDate);
        }
        else
        {
            cmd.Parameters.AddWithValue("@ExamClosedDate", DBNull.Value);
        }

        cmd.Parameters.AddWithValue("@ExamClosedDateEnabled", ExamClosedDateEnabled);
        cmd.Parameters.AddWithValue("@ExamTimeLimit", ExamTimeLimit);
        cmd.Parameters.AddWithValue("@ExamTimeLimitEnabled", ExamTimeLimitEnabled);
        cmd.Parameters.AddWithValue("@ExamAttemptsAllowed", ExamAttemptsAllowed);
        cmd.Parameters.AddWithValue("@ExamQuestionsOrdered", ExamQuestionsOrdered);
        cmd.Parameters.AddWithValue("@ExamShuffleAnswers", ExamShuffleAnswers);
        cmd.Parameters.AddWithValue("@ExamLearningMode", ExamLearningMode);
        cmd.Parameters.AddWithValue("@ExamPassword", ExamPassword);


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



    public DataTable SelectAllExams()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Exam "
                + "ORDER BY Exam_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.Fill(dt);
        }

        return dt;

    }



}