using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using System.Collections.Generic;

/// <summary>
/// Summary description for Module
/// </summary>
public class Module
{

    public int ModuleID { get; set; }
    public string ModuleName { get; set; }
    public bool ModuleActive { get; set; }
    public int SubjectID { get; set; }


	public Module()
	{

	}

    public bool SelectModuleByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Module "
                + "WHERE pkModule_ID = @ModuleID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ModuleID", ModuleID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            ModuleID = Convert.ToInt32(dt.Rows[0]["pkModule_ID"]);
            ModuleName = Convert.ToString(dt.Rows[0]["Module_Name"]);
            ModuleActive = Convert.ToBoolean(dt.Rows[0]["Module_Active"]);
            SubjectID = Convert.ToInt32(dt.Rows[0]["fkSubject_ID"]);

            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateModule()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Module "
                + "SET "
                + "Module_Name = @ModuleName, "
                + "Module_Active = @ModuleActive, "
                + "fkSubject_ID = @SubjectID "
                + "WHERE pkModule_ID = @ModuleID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
        cmd.Parameters.AddWithValue("@ModuleActive", ModuleActive);
        cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
        cmd.Parameters.AddWithValue("@ModuleID", ModuleID);
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


    public bool InsertModule()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Module (Module_Name,Module_Active,fkSubject_ID) "
                + "VALUES "
                + "(@ModuleName,@ModuleActive,@SubjectID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
        cmd.Parameters.AddWithValue("@ModuleActive", ModuleActive);
        cmd.Parameters.AddWithValue("@SubjectID", SubjectID);

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


    public DataTable SelectAllModules(int SubjectID)
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Module "
                + "JOIN Subject "
                + "ON fkSubject_ID = pkSubject_ID ";

                if(SubjectID > 0)
                {
                    sqlText = sqlText + "WHERE pkSubject_ID = @SubjectID ";
                }

         sqlText = sqlText + "ORDER BY Module_Name";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@SubjectID", SubjectID);
            adapter.Fill(dt);
        }

        dt.TableName = "Module";
        return dt;

    }


}