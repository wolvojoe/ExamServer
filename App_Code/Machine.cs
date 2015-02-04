using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Machine
/// </summary>
public class Machine
{

    public int MachineID;
    public string MachineName;
    public bool MachineActive;
    public string MachineAuthCode;

	public Machine()
	{

	}


    public bool SelectMachineByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Machine "
                + "WHERE pkMachine_ID = @MachineID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@MachineID", MachineID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            MachineID = Convert.ToInt32(dt.Rows[0]["pkMachine_ID"]);
            MachineName = Convert.ToString(dt.Rows[0]["Machine_Name"]);
            MachineActive = Convert.ToBoolean(dt.Rows[0]["Machine_Active"]);
            MachineAuthCode = Convert.ToString(dt.Rows[0]["Machine_Auth_Code"]);
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool SelectMachineByCode()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Machine "
                + "WHERE Machine_Auth_Code = @MachineAuthCode";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@MachineAuthCode", MachineAuthCode);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            MachineID = Convert.ToInt32(dt.Rows[0]["pkMachine_ID"]);
            MachineName = Convert.ToString(dt.Rows[0]["Machine_Name"]);
            MachineActive = Convert.ToBoolean(dt.Rows[0]["Machine_Active"]);
            MachineAuthCode = Convert.ToString(dt.Rows[0]["Machine_Auth_Code"]);
            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateMachine()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Machine "
                + "SET "
                + "Machine_Name = @MachineName, "
                + "Machine_Active = @MachineActive, "
                + "Machine_Auth_Code = @MachineAuthCode "
                + "WHERE pkMachine_ID = @MachineID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@MachineName", MachineName);
        cmd.Parameters.AddWithValue("@MachineActive", MachineActive);
        cmd.Parameters.AddWithValue("@MachineAuthCode", MachineAuthCode);
        cmd.Parameters.AddWithValue("@MachineID", MachineID);

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


    public bool InsertMachine()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Machine (Machine_Name, Machine_Active, Machine_Auth_Code) "
                + "VALUES "
                + "(@MachineName, @MachineActive, newid())";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@MachineName", MachineName);
        cmd.Parameters.AddWithValue("@MachineActive", MachineActive);

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