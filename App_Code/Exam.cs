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
    public DateTime ExamTimeLimit;
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
            ExamTimeLimit = Convert.ToDateTime(dt.Rows[0]["Exam_Time_Limit"]);
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



}