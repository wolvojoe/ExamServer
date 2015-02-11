using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SiteSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Site Settings";

        GetSiteSettings();
    }


    private void GetSiteSettings()
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 1;
        AllSettings.SelectSettingByID();

        txtSiteName.Text = AllSettings.SettingValue;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 1;
        AllSettings.SelectSettingByID();
        AllSettings.SettingValue = txtSiteName.Text;
        AllSettings.UpdateSetting();
    }
}