using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Students";

        if (IsPostBack == false)
        {
            GetStudents();
            GetDepartmentList();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int StudentID = Convert.ToInt32(Request.QueryString["ID"]);
            GetStudent(StudentID);
            btnSave.Text = "Update";

        }
        else
        {

        }
    }


    private void GetDepartmentList()
    {
        var DepartmentList = new Department();
        dpDepartment.DataSource = DepartmentList.SelectAllDepartments();
        dpDepartment.DataTextField = "Department_Name";
        dpDepartment.DataValueField = "pkDepartment_ID";
        dpDepartment.DataBind();

        dpSearchDepartment.DataSource = DepartmentList.SelectAllDepartments();
        dpSearchDepartment.DataTextField = "Department_Name";
        dpSearchDepartment.DataValueField = "pkDepartment_ID";
        dpSearchDepartment.DataBind();


    }



    private void GetStudents()
    {
        var AllStudents = new Student();

        gvStudents.DataSource = AllStudents.SelectAllStudents(Convert.ToInt32(dpSearchDepartment.SelectedValue));
        gvStudents.DataBind();

    }




    private void GetStudent(int StudentID)
    {
        var GetStudent = new Student();

        GetStudent.StudentID = StudentID;
        GetStudent.SelectStudentByID();

        txtFirstName.Text = GetStudent.StudentFirstName;
        txtLastName.Text = GetStudent.StudentLastName;
        txtEmailUpdate.Text = GetStudent.StudentEmail;
        txtPasswordUpdate.Text = "";
        chkActive.Checked = GetStudent.StudentActive;
        dpDepartment.SelectedValue = Convert.ToString(GetStudent.StudentDepartmentID);

    }

    private void InsertStudent()
    {
        var NewStudent = new Student();
        var Hash = new Hash();

        NewStudent.StudentFirstName = txtFirstName.Text.Trim();
        NewStudent.StudentLastName = txtLastName.Text.Trim();
        NewStudent.StudentEmail = txtEmailUpdate.Text.Trim();
        NewStudent.StudentPassword = Hash.HashString(txtPasswordUpdate.Text.Trim());

        NewStudent.StudentActive = chkActive.Checked;
        NewStudent.StudentDepartmentID = Convert.ToInt32(dpDepartment.SelectedValue);
        NewStudent.InsertStudent();
    }

    private void UpdateStudent(int StudentID)
    {
        var UpdateStudent = new Student();
        var Hash = new Hash();

        UpdateStudent.StudentID = StudentID;
        UpdateStudent.SelectStudentByID();

        UpdateStudent.StudentFirstName = txtFirstName.Text.Trim();
        UpdateStudent.StudentLastName = txtLastName.Text.Trim();
        UpdateStudent.StudentEmail = txtEmailUpdate.Text.Trim();

        if (txtPasswordUpdate.Text.Trim().Length > 0)
        {
            UpdateStudent.StudentPassword = Hash.HashString(txtPasswordUpdate.Text.Trim());
        }
        
        UpdateStudent.StudentActive = chkActive.Checked;
        UpdateStudent.StudentDepartmentID = Convert.ToInt32(dpDepartment.SelectedValue);

        UpdateStudent.UpdateStudent();

        Response.Redirect(Request.Path);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int StudentID = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateStudent(StudentID);

        }
        else
        {
            InsertStudent();
        }

        GetStudents();

    }

    protected void Search(object sender, EventArgs e)
    {
        GetStudents();
    }

    protected void gvStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudents.PageIndex = e.NewPageIndex;
        GetStudents();
    }

}