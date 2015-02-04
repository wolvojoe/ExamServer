using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
	public Subject()
	{

	}

    public bool SelectSubjectByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Student "
                + "WHERE pkStudent_ID = @StudentID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@StudentID", StudentID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            StudentID = Convert.ToInt32(dt.Rows[0]["pkStudent_ID"]);
            StudentFirstName = Convert.ToString(dt.Rows[0]["Student_First_Name"]);
            StudentLastName = Convert.ToString(dt.Rows[0]["Student_Last_Name"]);
            StudentEmail = Convert.ToString(dt.Rows[0]["Student_Email"]);
            StudentPassword = Convert.ToString(dt.Rows[0]["Student_Password"]);
            StudentActive = Convert.ToBoolean(dt.Rows[0]["Student_Active"]);
            StudentGroupID = Convert.ToInt32(dt.Rows[0]["fkGroup_ID"]);
            return true;
        }
        else
        {
            return false;
        }

    }

}