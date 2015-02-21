using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Departments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Departments";

        if (IsPostBack == false)
        {
            GetDepartments();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int SubjectID = Convert.ToInt32(Request.QueryString["ID"]);
            GetDepartment(SubjectID);
            btnSave.Text = "Update";

        }
        else
        {

        }
    }

    private void GetDepartments()
    {
        var AllDepartments = new Department();

        gvDepartments.DataSource = AllDepartments.SelectAllDepartments();
        gvDepartments.DataBind();

    }

    private void GetDepartment(int DepartmentID)
    {
        var GetDepartment = new Department();

        GetDepartment.DepartmentID = DepartmentID;
        GetDepartment.SelectDepartmentByID();

        txtName.Text = GetDepartment.DepartmentName;
        chkActive.Checked = GetDepartment.DepartmentActive;

    }

    private void InsertDepartment()
    {
        var NewDepartment = new Department();
        NewDepartment.DepartmentName = txtName.Text.Trim();
        NewDepartment.DepartmentActive = chkActive.Checked;
        NewDepartment.InsertDepartment();
    }

    private void UpdateDepartment(int DepartmentID)
    {
        var UpdateDepartment = new Department();
        UpdateDepartment.DepartmentID = DepartmentID;
        UpdateDepartment.SelectDepartmentByID();
        UpdateDepartment.DepartmentName = txtName.Text.Trim();
        UpdateDepartment.DepartmentActive = chkActive.Checked;
        UpdateDepartment.UpdateDepartment();

        Response.Redirect(Request.Path);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int DepartmentID = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateDepartment(DepartmentID);

        }
        else
        {
            InsertDepartment();
        }

        GetDepartments();

    }



    protected void gvDepartments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDepartments.PageIndex = e.NewPageIndex;
        GetDepartments();
    }

}