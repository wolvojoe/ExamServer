using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Questions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Questions";

        if (IsPostBack == false)
        {
            GetQuestions();
            GetSubjectList();
            GetSubjectSearchList();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int QuestionID = Convert.ToInt32(Request.QueryString["ID"]);
            GetQuestion(QuestionID);
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

    }

    private void GetSubjectSearchList()
    {
        var SubjectList = new Subject();
        dpSearchSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSearchSubject.DataTextField = "Subject_Name";
        dpSearchSubject.DataValueField = "pkSubject_ID";
        dpSearchSubject.DataBind();
    }

    private void GetModuleList()
    {
        dpModule.Items.Clear();
        var ModuleList = new Module();
        dpModule.DataSource = ModuleList.SelectAllModules(Convert.ToInt32(dpSubject.SelectedValue));
        dpModule.DataTextField = "Subject_Name";
        dpModule.DataValueField = "pkSubject_ID";
        dpModule.DataBind();

    }

    private void GetModuleSearchList()
    {
        dpSearchModule.Items.Clear();
        var ModuleList = new Module();
        dpSearchModule.DataSource = ModuleList.SelectAllModules(Convert.ToInt32(dpSearchSubject.SelectedValue));
        dpSearchModule.DataTextField = "Subject_Name";
        dpSearchModule.DataValueField = "pkSubject_ID";
        dpSearchModule.DataBind();
    }


    private void GetQuestions()
    {
        var AllQuestions = new Question();

        gvQuestions.DataSource = AllQuestions.SelectAllQuestions(Convert.ToInt32(dpSearchSubject.SelectedValue), Convert.ToInt32(dpSearchModule.SelectedValue));
        gvQuestions.DataBind();

    }



    private void GetQuestion(int QuestionID)
    {
        var GetQuestion = new Question();

        GetQuestion.QuestionID = QuestionID;
        GetQuestion.SelectQuestionByID();

        txtName.Text = GetQuestion.QuestionName;
        txtDescription.Text = GetQuestion.QuestionDescription;
        chkActive.Checked = GetQuestion.QuestionActive;

        dpModule.SelectedValue = Convert.ToString(GetQuestion.ModuleID);

        dpQuestionType.SelectedValue = Convert.ToString(GetQuestion.QuestionTypeID);
    }




    private void InsertQuestion()
    {
        var NewQuestion = new Question();
        NewQuestion.QuestionName = txtName.Text.Trim();
        NewQuestion.QuestionDescription = txtDescription.Text.Trim();

        NewQuestion.QuestionTypeID = Convert.ToInt32(dpQuestionType.SelectedValue);

        NewQuestion.QuestionActive = chkActive.Checked;
        NewQuestion.ModuleID = Convert.ToInt32(dpModule.SelectedValue);

        NewQuestion.InsertQuestion();
    }

    private void UpdateQuestion(int QuestionID)
    {
        var UpdateQuestion = new Question();
        UpdateQuestion.QuestionID = QuestionID;
        UpdateQuestion.SelectQuestionByID();

        UpdateQuestion.QuestionName = txtName.Text.Trim();
        UpdateQuestion.QuestionDescription = txtDescription.Text.Trim();

        UpdateQuestion.QuestionTypeID = Convert.ToInt32(dpQuestionType.SelectedValue);

        UpdateQuestion.QuestionActive = chkActive.Checked;
        UpdateQuestion.ModuleID = Convert.ToInt32(dpModule.SelectedValue);

        UpdateQuestion.UpdateQuestion();

        Response.Redirect(Request.Path);
    }





    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int QuestionID = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateQuestion(QuestionID);

        }
        else
        {
            InsertQuestion();
        }

        GetQuestions();

    }


    protected void Search(object sender, EventArgs e)
    {
        GetQuestions();
    }

    protected void SubjectSelected(object sender, EventArgs e)
    {
        GetModuleList();
    }

    protected void SearchSubjectSelected(object sender, EventArgs e)
    {
        GetModuleSearchList();
    }


}