using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Setting
/// </summary>
public class Setting
{

    public int SettingID;
    public string SettingName;
    public string SettingValue;
    public string SettingDescription;

	public Setting()
	{

	}


    public bool SelectSettingByID()
    {
        string sqlText = String.Empty;

        sqlText = "SELECT * "
                + "FROM Setting "
                + "WHERE pkSetting_ID = @SettingID";

        var dt = new DataTable();
        using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sitecontent"].ConnectionString))
        using (var adapter = new SqlDataAdapter(sqlText, con))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@SettingID", SettingID);
            adapter.Fill(dt);
        }

        if (dt.Rows.Count == 1)
        {
            SettingID = Convert.ToInt32(dt.Rows[0]["pkSetting_ID"]);
            SettingName = Convert.ToString(dt.Rows[0]["Setting_Name"]);
            SettingValue = Convert.ToString(dt.Rows[0]["Setting_Value"]);
            SettingDescription = Convert.ToString(dt.Rows[0]["Setting_Description"]);

            return true;
        }
        else
        {
            return false;
        }

    }


}