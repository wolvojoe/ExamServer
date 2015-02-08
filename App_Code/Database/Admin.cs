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


    public bool SelectAdminByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Admin "
                + "WHERE pkAdmin_ID = @AdminID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@AdminID", AdminID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            AdminID = Convert.ToInt32(dt.Rows[0]["pkAdmin_ID"]);
            AdminFirstName = Convert.ToString(dt.Rows[0]["Admin_First_Name"]);
            AdminLastName = Convert.ToString(dt.Rows[0]["Admin_Last_Name"]);
            AdminEmail = Convert.ToString(dt.Rows[0]["Admin_Email"]);
            AdminPassword = Convert.ToString(dt.Rows[0]["Admin_Password"]);
            AdminActive = Convert.ToBoolean(dt.Rows[0]["Admin_Active"]);

            return true;
        }
        else
        {
            return false;
        }

    }


    public bool SelectAdminByEmailAndPassword()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Admin "
                + "WHERE Admin_Email = @AdminEmail and Admin_Password = @AdminPassword";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@AdminEmail", AdminEmail);
            adapter.SelectCommand.Parameters.AddWithValue("@AdminPassword", AdminPassword);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            AdminID = Convert.ToInt32(dt.Rows[0]["pkAdmin_ID"]);
            AdminFirstName = Convert.ToString(dt.Rows[0]["Admin_First_Name"]);
            AdminLastName = Convert.ToString(dt.Rows[0]["Admin_Last_Name"]);
            AdminEmail = Convert.ToString(dt.Rows[0]["Admin_Email"]);
            AdminPassword = Convert.ToString(dt.Rows[0]["Admin_Password"]);
            AdminActive = Convert.ToBoolean(dt.Rows[0]["Admin_Active"]);

            return true;
        }
        else
        {
            return false;
        }

    }






}