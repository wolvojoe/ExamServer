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

        if(IsPostBack == false)
        {
            GetModules();
            GetSubjectList();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int ModuleValue = Convert.ToInt32(Request.QueryString["ID"]);
            GetModule(ModuleValue);
            btnSave.Text = "Update";

        }
        else
        {

        }

    }

    private void GetSubjectList()
    {
        var SubjectList = new Subject();
        dpSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSubject.DataTextField = "Subject_Name";
        dpSubject.DataValueField = "pkSubject_ID";
        dpSubject.DataBind();

        dpSearchSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSearchSubject.DataTextField = "Subject_Name";
        dpSearchSubject.DataValueField = "pkSubject_ID";
        dpSearchSubject.DataBind();


    }



    private void GetModules()
    {
        var AllModules = new Module();

        gvModules.DataSource = AllModules.SelectAllModules(Convert.ToInt32(dpSearchSubject.SelectedValue));
        gvModules.DataBind();

    }




    private void GetModule(int ModuleID)
    {
        var GetModule = new Module();

        GetModule.ModuleID = ModuleID;
        GetModule.SelectModuleByID();

        txtName.Text = GetModule.ModuleName;
        chkActive.Checked = GetModule.ModuleActive;
        dpSubject.SelectedValue = Convert.ToString(GetModule.SubjectID);

    }

    private void InsertModule()
    {
        var NewModule = new Module();
        NewModule.ModuleName = txtName.Text.Trim();
        NewModule.ModuleActive = chkActive.Checked;
        NewModule.SubjectID = Convert.ToInt32(dpSubject.SelectedValue);
        NewModule.InsertModule();
    }

    private void UpdateModule(int ModuleID)
    {
        var NewModule = new Module();
        NewModule.ModuleID = ModuleID;
        NewModule.SelectModuleByID();
        NewModule.ModuleName = txtName.Text.Trim();
        NewModule.ModuleActive = chkActive.Checked;
        NewModule.SubjectID = Convert.ToInt32(dpSubject.SelectedValue);
        NewModule.UpdateModule();

        Response.Redirect(Request.Path);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int ModuleValue = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateModule(ModuleValue);

        }
        else
        {
            InsertModule();
        }

        GetModules();

    }

    protected void Search(object sender, EventArgs e)
    {
        GetModules();
    }

}