using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{

    public int AdminID;
    public string AdminFirstName;
    public string AdminLastName;
    public string AdminEmail;
    public string AdminPassword;
    public bool AdminActive;

	public Admin()
	{


	}


    public bool SelectAnswerByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Admin "
                + "WHERE pkAdmin_ID = @AdminID";

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


}