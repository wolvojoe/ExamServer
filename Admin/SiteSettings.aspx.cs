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

        if (Page.IsPostBack == false)
        {
            GetSiteSettings();
        }
    }


    private void GetSiteSettings()
    {
        GetSiteName();
        GetSiteExternalReg();
    }

    private void GetSiteName()
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 1;
        AllSettings.SelectSettingByID();

        txtSiteName.Text = AllSettings.SettingValue;
    }

    private void GetSiteExternalReg()
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 3;
        AllSettings.SelectSettingByID();

        chkExternalReg.Checked = Convert.ToBoolean(AllSettings.SettingValue);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSiteName();
        UpdateSiteExternalReg();
    }

    private void UpdateSiteName()
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 1;
        AllSettings.SelectSettingByID();
        AllSettings.SettingValue = txtSiteName.Text;
        AllSettings.UpdateSetting();
    }

    private void UpdateSiteExternalReg()
    {
        var AllSettings = new Setting();
        AllSettings.SettingID = 3;
        AllSettings.SelectSettingByID();
        AllSettings.SettingValue = Convert.ToString(chkExternalReg.Checked);
        AllSettings.UpdateSetting();
    }


    protected void btnInstallExam_Click(object sender, EventArgs e)
    {
        Response.Redirect("InstallExam.aspx");
    }

    protected void btnInstallQuestions_Click(object sender, EventArgs e)
    {
        Response.Redirect("InstallQuestions.aspx");
    }

}