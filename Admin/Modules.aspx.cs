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

        var SubjectList = new Subject();
        dpSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSubject.DataTextField = "Subject_Name";
        dpSubject.DataValueField = "pkSubject_ID";
        dpSubject.DataBind();

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
        NewModule.SubjectID = Convert.ToInt32(dpSubject.SelectedValue);
        NewModule.InsertModule();

    }

}