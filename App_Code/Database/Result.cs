using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Result
/// </summary>
public class Result
{

    public int ResultID;
    public DateTime ResultDateFrom;
    public DateTime ResultDateTo;
    public bool ResultComplete;
    public int StudentID;
    public int MachineID;
    public int ExamID;

	public Result()
	{

	}


    public bool SelectResultByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Result "
                + "WHERE pkResult_ID = @ResultID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ResultID", ResultID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            ResultID = Convert.ToInt32(dt.Rows[0]["pkResult_ID"]);
            ResultDateFrom = Convert.ToDateTime(dt.Rows[0]["Result_Date_From"]);
            ResultDateTo = Convert.ToDateTime(dt.Rows[0]["Result_Date_To"]);
            ResultComplete = Convert.ToBoolean(dt.Rows[0]["Result_Complete"]);
            StudentID = Convert.ToInt32(dt.Rows[0]["fkStudent_ID"]);
            MachineID = Convert.ToInt32(dt.Rows[0]["fkMachine_ID"]);
            ExamID = Convert.ToInt32(dt.Rows[0]["fkExam_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }




    public bool UpdateResult()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Result "
                + "SET "

                + "Result_Date_From = @ResultDateFrom, "
                + "Result_Date_To = @ResultDateTo, "
                + "Result_Complete = @ResultComplete, "
                + "fkStudent_ID = @StudentID, "
                + "fkMachine_ID = @MachineID, "
                + "fkExam_ID = @ExamID "

                + "WHERE pkMachine_ID = @ResultID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ResultDateFrom", ResultDateFrom);
        cmd.Parameters.AddWithValue("@ResultDateTo", ResultDateTo);
        cmd.Parameters.AddWithValue("@ResultComplete", ResultComplete);
        cmd.Parameters.AddWithValue("@StudentID", StudentID);
        cmd.Parameters.AddWithValue("@MachineID", MachineID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);
        cmd.Parameters.AddWithValue("@ResultID", ResultID);

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



    public bool InsertResult()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Result (Result_Date_From, Result_Complete, fkStudent_ID, "
                + " fkMachine_ID, fkExam_ID) "
                + "VALUES "
                + "(getdate(), false, @StudentID, @ExamID)"
                + "select CAST(Scope_Identity() AS int) ";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@StudentID", StudentID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);

        try
        {
            connObj.Open();
            ResultID = (int)cmd.ExecuteScalar();
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


    public DataTable SelectAllResult(int DepartmentID)
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM RESULT "
                + "JOIN EXAM "
                + "ON pkExam_ID = fkExam_ID "
                + "JOIN Student "
                + "ON pkStudent_ID = fkStudent_ID "
                + "join Department "
                + "ON fkDepartment_ID = pkDepartment_ID ";

                if (StudentID > 0)
                {
                    sqlText = sqlText + "WHERE pkDepartment_ID = @DepartmentID ";
                }

                sqlText = sqlText + "order by Exam_Date_Created desc ";



        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            adapter.Fill(dt);
        }

        return dt;

    }




}