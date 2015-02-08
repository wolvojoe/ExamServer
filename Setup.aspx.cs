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
        var SiteName = new Setting();

        SiteName.SettingID = 2;
        SiteName.SelectSettingByID();

        if(SiteName.SettingValue != "0")
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {

    }


}