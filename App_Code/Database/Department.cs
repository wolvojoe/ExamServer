using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Department
/// </summary>
public class Department
{

    public int DepartmentID;
    public string DepartmentName;
    public bool DepartmentActive;


	public Department()
	{


	}


    public bool SelectDepartmentByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Department "
                + "WHERE pkDepartment_ID = @DepartmentID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            DepartmentID = Convert.ToInt32(dt.Rows[0]["pkDepartment_ID"]);
            DepartmentName = Convert.ToString(dt.Rows[0]["Department_Name"]);
            DepartmentActive = Convert.ToBoolean(dt.Rows[0]["Department_Active"]);
            return true;
        }
        else
        {
            return false;
        }

    }


    public bool UpdateDepartment()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Department "
                + "SET "
                + "Department_Name = @DepartmentName, "
                + "Department_Active = @DepartmentActive "
                + "WHERE pkDepartment_ID = @DepartmentID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
        cmd.Parameters.AddWithValue("@DepartmentActive", DepartmentActive);
        cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);

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



    public bool InsertDepartment()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Department (Department_Name,Department_Active) "
                + "VALUES "
                + "(@DepartmentName,@DepartmentActive)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
        cmd.Parameters.AddWithValue("@DepartmentActive", DepartmentActive);

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

    public DataTable SelectAllDepartments()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Department "
                + "ORDER BY Department_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.Fill(dt);
        }

        return dt;

    }

}