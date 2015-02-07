using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Group
/// </summary>
public class Group
{

    public int GroupID;
    public string GroupName;
    public bool GroupActive;


	public Group()
	{


	}


    public bool SelectGroupByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Group "
                + "WHERE pkGroup_ID = @GroupID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@GroupID", GroupID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            GroupID = Convert.ToInt32(dt.Rows[0]["pkGroup_ID"]);
            GroupName = Convert.ToString(dt.Rows[0]["Group_Name"]);
            GroupActive = Convert.ToBoolean(dt.Rows[0]["Group_Active"]);
            return true;
        }
        else
        {
            return false;
        }

    }


    public bool UpdateGroup()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Group "
                + "SET "
                + "Group_Name = @GroupName, "
                + "Group_Active = @GroupActive "
                + "WHERE pkGroup_ID = @GroupID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@GroupName", GroupName);
        cmd.Parameters.AddWithValue("@GroupActive", GroupActive);
        cmd.Parameters.AddWithValue("@GroupID", GroupID);

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



    public bool InsertGroup()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Group (Group_Name,Group_Active) "
                + "VALUES "
                + "(@GroupName,@GroupActive)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@GroupName", GroupName);
        cmd.Parameters.AddWithValue("@GroupActive", GroupActive);

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

}