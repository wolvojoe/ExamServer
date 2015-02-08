using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Base : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var SiteName = new Setting();

        SiteName.SettingID = 1;
        SiteName.SelectSettingByID();

        lblSiteName.Text = SiteName.SettingValue + " - ";
    }
}
