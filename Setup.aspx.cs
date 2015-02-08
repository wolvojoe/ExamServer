using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup_Setup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var SiteSetup = new Setting();

        SiteSetup.SettingID = 2;
        SiteSetup.SelectSettingByID();

        if (SiteSetup.SettingValue != "0")
        {
            Response.Redirect("~/Login.aspx");
        }

        lblPageTitle.Text = "Initial Setup";
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //Save site name in setting table
        var SiteName = new Setting();
        SiteName.SettingID = 1;
        SiteName.SelectSettingByID();
        SiteName.SettingValue = txtSiteName.Text.Trim();
        SiteName.UpdateSetting();

        //Insert the first admin user
        var AdminUser = new Admin();
        var Hash = new Hash();
        AdminUser.AdminEmail = txtEmail.Text.Trim();
        AdminUser.AdminPassword = Hash.HashString(txtPassword.Text);
        AdminUser.AdminFirstName = txtFirstName.Text.Trim();
        AdminUser.AdminLastName = txtLastName.Text.Trim();
        AdminUser.AdminActive = true;
        AdminUser.InsertAdmin();

        //Set the setup setting to true
        var SiteSetup = new Setting();
        SiteSetup.SettingID = 2;
        SiteSetup.SelectSettingByID();
        SiteSetup.SettingValue = "1";
        SiteSetup.UpdateSetting();


    }


}