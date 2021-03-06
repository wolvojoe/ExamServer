﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Collections.Generic;

/// <summary>
/// Summary description for Result_Answer
/// </summary>
public class Result_Answer
{

    public int ResultAnswerID;
    public string ResultAnswerText;
    public int ResultID;
    public int AnswerID;

	public Result_Answer()
	{

	}

    public bool SelectResultAnswerByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Result_Answer "
                + "WHERE pkResult_Answer_ID = @ResultAnswerID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ResultAnswerID", AnswerID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            ResultAnswerID = Convert.ToInt32(dt.Rows[0]["pkResult_Answer_ID"]);
            ResultAnswerText = Convert.ToString(dt.Rows[0]["Result_Answer_Text"]);
            ResultID = Convert.ToInt32(dt.Rows[0]["fkResult_ID"]);
            AnswerID = Convert.ToInt32(dt.Rows[0]["fkQuestion_ID"]);


            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateResultAnswer()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Result_Answer "
                + "SET "
                + "Result_Answer_Text = @ResultAnswerText, "
                + "fkResult_ID = @ResultID, "
                + "fkAnswer_ID = @AnswerID "
                + "WHERE pkResult_Answer_ID = @ResultAnswerID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ResultAnswerText", ResultAnswerText);
        cmd.Parameters.AddWithValue("@ResultID", ResultID);
        cmd.Parameters.AddWithValue("@AnswerID", AnswerID);
        cmd.Parameters.AddWithValue("@ResultAnswerID", ResultAnswerID);

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



    public bool InsertResultAnswer()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Result_Answer (Result_Answer_Text, fkResultID, fkAnswerID) "
                + "VALUES "
                + "(@ResultAnswerText, @ResultID, @AnswerID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ResultAnswerText", ResultAnswerText);
        cmd.Parameters.AddWithValue("@ResultID", ResultID);
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



    public List<int> SelectAnswerByResultID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT fkAnswer_ID "
                + "FROM Result_Answer "
                + "WHERE fkResult_ID = @ResultID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ResultID", ResultID);
            adapter.Fill(dt);
        }

        List<int> AllResultAnswerIDs = new List<int>();

        foreach(DataRow x in dt.Rows)
        {
            AllResultAnswerIDs.Add(Convert.ToInt32(x["fkAnswer_ID"]));
        }

        return AllResultAnswerIDs;

    }


}