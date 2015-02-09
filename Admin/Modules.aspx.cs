using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Modules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Modules";

        GetModules();
    }

    private void GetModules()
    {
        var AllModules = new Module();

        gvModules.DataSource = AllModules.SelectAllModules();
        gvModules.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var NewModule = new Module();
        NewModule.ModuleName = txtName.Text.Trim();
        NewModule.ModuleActive = chkActive.Checked;
        NewModule.SubjectID = "";
        NewModule.InsertModule();

    }

}