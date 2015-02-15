using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Answers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Answers";

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


    private void GetAnswers()
    {
        var AllAnswers = new Answer();

        gvAnswers.DataSource = AllAnswers.SelectAllAnswers(Convert.ToInt32(Request.QueryString["ID"]));
        gvAnswers.DataBind();

    }



    private void GetAnswer(int AnswerID)
    {
        var GetAnswer = new Answer();

        GetAnswer.AnswerID = AnswerID;
        GetAnswer.SelectAnswerByID();

        txtValue.Text = GetAnswer.AnswerName;
        txtDescription.Text = GetAnswer.AnswerDescription;
        chkCorrect.Checked = GetAnswer.AnswerCorrect;


    }

    private void InsertAnswer()
    {
        var NewAnswer = new Student();
        var Hash = new Hash();

        NewStudent.StudentFirstName = txtFirstName.Text.Trim();
        NewStudent.StudentLastName = txtLastName.Text.Trim();
        NewStudent.StudentEmail = txtEmailUpdate.Text.Trim();
        NewStudent.StudentPassword = Hash.HashString(txtPasswordUpdate.Text.Trim());

        NewStudent.StudentActive = chkActive.Checked;
        NewStudent.StudentDepartmentID = Convert.ToInt32(dpDepartment.SelectedValue);
        NewStudent.InsertStudent();
    }

    private void UpdateAnswer(int AnswerID)
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


}