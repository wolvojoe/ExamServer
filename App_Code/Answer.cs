using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Answer
/// </summary>
public class Answer
{

    public int AnswerID;
    public string AnswerName;
    public string AnswerDescription;
    public int AnswerOrder;
    public int AnswerCorrect;
    public int QuestionID;

	public Answer()
	{

	}


    public bool SelectAnswerByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Answer "
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


}