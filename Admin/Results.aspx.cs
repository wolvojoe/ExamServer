using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Results : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblPageTitle.Text = "Results";

        if (IsPostBack == false)
        {
            GetDepartmentList();
            GetResults();
        }

    }


    private void GetResults()
    {
        var AllResults = new Result();

        gvResults.DataSource = AllResults.SelectAllResult(Convert.ToInt32(dpSearchDepartment.SelectedValue));
        gvResults.DataBind();

    }



    private void GetDepartmentList()
    {
        var DepartmentList = new Department();

        dpSearchDepartment.DataSource = DepartmentList.SelectAllDepartments();
        dpSearchDepartment.DataTextField = "Department_Name";
        dpSearchDepartment.DataValueField = "pkDepartment_ID";
        dpSearchDepartment.DataBind();


    }


    protected void SearchDepartmentSelected(object sender, EventArgs e)
    {
        GetResults();

    }

}