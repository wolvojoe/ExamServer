using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Exams";


        if (IsPostBack == false)
        {

        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int ExamID = Convert.ToInt32(Request.QueryString["ID"]);
            GetExam(ExamID);
            btnSave.Text = "Update";

        }
        else
        {

        }

    }

    private void GetExam(int ExamID)
    {
        var GetExam = new Exam();
        GetExam.ExamID = ExamID;
        GetExam.SelectExamByID();

        txtName.Text = GetExam.ExamName;
        txtDescription.Text = GetExam.ExamDescription;

        chkEnableOpenDate.Checked = GetExam.ExamOpenDateEnabled;
        txtOpenDate.Text = Convert.ToString(GetExam.ExamOpenDate);

        chkEnableClosedDate.Checked = GetExam.ExamClosedDateEnabled;
        txtClosedDate.Text = Convert.ToString(GetExam.ExamClosedDate);

        chkEnableTimeLimit.Checked = GetExam.ExamTimeLimitEnabled;
        txtTimeLimit.Text = Convert.ToString(GetExam.ExamTimeLimit);

        txtNumberOfAttempts.Text = Convert.ToString(GetExam.ExamAttemptsAllowed);
        chkOrderQuestions.Checked = GetExam.ExamQuestionsOrdered;
        chkShuffleAnswers.Checked = GetExam.ExamShuffleAnswers;
        chkLearningMode.Checked = GetExam.ExamLearningMode;
        txtPassword.Text = GetExam.ExamPassword;
    }


    private void InsertExam()
    {
        var NewExam = new Exam();
        NewExam.ExamName = txtName.Text.Trim();
        NewExam.ExamDescription = txtDescription.Text.Trim();

        NewExam.ExamOpenDateEnabled = chkEnableOpenDate.Checked;

        if (txtOpenDate.Text.Length > 0)
        {
            NewExam.ExamOpenDate = Convert.ToDateTime(txtOpenDate.Text.Trim());
        }

        NewExam.ExamClosedDateEnabled = chkEnableClosedDate.Checked;

        if (txtClosedDate.Text.Length > 0)
        {
            NewExam.ExamClosedDate = Convert.ToDateTime(txtClosedDate.Text.Trim());
        }

        NewExam.ExamTimeLimitEnabled = chkEnableTimeLimit.Checked;

        if (txtTimeLimit.Text.Length > 0)
        {
            NewExam.ExamTimeLimit = Convert.ToInt32(txtTimeLimit.Text.Trim());
        }

        if (txtNumberOfAttempts.Text.Length > 0)
        {
            NewExam.ExamAttemptsAllowed = Convert.ToInt32(txtNumberOfAttempts.Text.Trim());
        }
        
        NewExam.ExamQuestionsOrdered = Convert.ToBoolean(chkOrderQuestions.Checked);
        NewExam.ExamShuffleAnswers = Convert.ToBoolean(chkShuffleAnswers.Checked);
        NewExam.ExamLearningMode = Convert.ToBoolean(chkLearningMode.Checked);
        NewExam.ExamPassword = txtPassword.Text.Trim();

        NewExam.InsertExam();

    }

    private void UpdateExam(int ExamID)
    {
        var UpdateExam = new Exam();
        UpdateExam.ExamID = ExamID;
        UpdateExam.SelectExamByID();

        UpdateExam.ExamName = txtName.Text.Trim();
        UpdateExam.ExamDescription = txtDescription.Text.Trim();

        UpdateExam.ExamOpenDateEnabled = chkEnableOpenDate.Checked;
        UpdateExam.ExamOpenDate = Convert.ToDateTime(txtOpenDate.Text.Trim());

        UpdateExam.ExamClosedDateEnabled = chkEnableClosedDate.Checked;
        UpdateExam.ExamClosedDate = Convert.ToDateTime(txtClosedDate.Text.Trim());

        UpdateExam.ExamTimeLimitEnabled = chkEnableTimeLimit.Checked;
        UpdateExam.ExamTimeLimit = Convert.ToInt32(txtTimeLimit.Text.Trim());

        UpdateExam.ExamAttemptsAllowed = Convert.ToInt32(txtNumberOfAttempts.Text.Trim());
        UpdateExam.ExamQuestionsOrdered = Convert.ToBoolean(chkOrderQuestions.Checked);
        UpdateExam.ExamShuffleAnswers = Convert.ToBoolean(chkShuffleAnswers.Checked);
        UpdateExam.ExamLearningMode = Convert.ToBoolean(chkLearningMode.Checked);
        UpdateExam.ExamPassword = txtPassword.Text.Trim();

        UpdateExam.UpdateExam();

    }


    protected void btnQuestions_Click(object sender, EventArgs e)
    {

        int ExamID = Convert.ToInt32(Request.QueryString["ID"]);
        UpdateExam(ExamID);


        Response.Redirect("examquestions.aspx?ID=" + Convert.ToString(ExamID));
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int ExamID = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateExam(ExamID);
        }
        else
        {
            InsertExam();
        }

        Response.Redirect("exams.aspx");
    }

}