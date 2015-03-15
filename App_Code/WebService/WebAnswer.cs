using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Collections.Generic;

/// <summary>
/// Summary description for WebAnswer
/// </summary>
public class WebAnswer
{

    public int AnswerID;
    public string AnswerName;
    public string AnswerDescription;
    public int AnswerOrder;
    public int QuestionID;

	public WebAnswer()
	{

	}

    public DataTable SelectAllAnswers()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT [pkAnswer_ID], [Answer_Name], [Answer_Description], [Answer_Order], "
                + "[fkQuestion_ID] "
                + "FROM Answer ";

        if (QuestionID > 0)
        {
            sqlText = sqlText + "WHERE fkQuestion_ID = @QuestionID ";
        }

        sqlText = sqlText + "ORDER BY Answer_Order";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@QuestionID", QuestionID);
            adapter.Fill(dt);
        }

        return dt;

    }


    public List<WebAnswer> SelectAllAnswersList()
    {
        List<WebAnswer> ReturnList = new List<WebAnswer>();

        DataTable ListOfQuestions = new DataTable();
        ListOfQuestions = SelectAllAnswers();

        foreach (DataRow x in ListOfQuestions.Rows)
        {
            WebAnswer NewAnswer = new WebAnswer();

            NewAnswer.AnswerID = Convert.ToInt32(x["pkAnswer_ID"]);
            NewAnswer.AnswerName = Convert.ToString(x["Answer_Name"]);
            NewAnswer.AnswerDescription = Convert.ToString(x["Answer_Description"]);
            NewAnswer.AnswerOrder = Convert.ToInt32(x["Answer_Order"]);
            NewAnswer.QuestionID = Convert.ToInt32(x["fkQuestion_ID"]);

            ReturnList.Add(NewAnswer);
        }

        return ReturnList;
    }

}