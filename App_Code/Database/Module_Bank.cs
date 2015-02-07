using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Module_Bank
/// </summary>
public class Module_Bank
{

    public int ModuleBankID;
    public int ModuleID;
    public int ExamID;

	public Module_Bank()
	{

	}


    public bool SelectModuleBankByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Module_Bank "
                + "WHERE pkModule_Bank_ID = @ModuleBankID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@ModuleBankID", ModuleBankID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            ModuleBankID = Convert.ToInt32(dt.Rows[0]["pkModule_Bank_ID"]);
            ModuleID = Convert.ToInt32(dt.Rows[0]["fkModule_ID"]);
            ExamID = Convert.ToInt32(dt.Rows[0]["fkExam_ID"]);


            return true;
        }
        else
        {
            return false;
        }

    }



    public bool UpdateModuleBank()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "UPDATE Module_Bank "
                + "SET "
                + "fkModule_ID = @ModuleID, "
                + "fkExam_ID = @ExamID "
                + "WHERE pkModule_Bank_ID = @ModuleBankID";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ModuleID", ModuleID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);
        cmd.Parameters.AddWithValue("@ModuleBankID", ModuleBankID);

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




    public bool InsertModuleBank()
    {
        String sqlText;
        String connStr = WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString;

        SqlConnection connObj = new SqlConnection(connStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connObj;

        sqlText = "INSERT INTO Module_Bank (fkModule_ID, fkExam_ID) "
                + "VALUES "
                + "(@ModuleID, @ExamID)";

        cmd.CommandText = sqlText;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@ModuleID", ModuleID);
        cmd.Parameters.AddWithValue("@ExamID", ExamID);

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