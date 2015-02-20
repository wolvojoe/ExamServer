using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExamQuestions : System.Web.UI.Page
{

    public int ExamID;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetPara();


        if (IsPostBack == false)
        {
            GetQuestions();
            GetSubjectSearchList();
            GetAllQuestionBanks();
        }

    }




    private void GetSubjectSearchList()
    {
        var SubjectList = new Subject();
        dpSearchSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSearchSubject.DataTextField = "Subject_Name";
        dpSearchSubject.DataValueField = "pkSubject_ID";
        dpSearchSubject.DataBind();

    }

    private void GetModuleSearchList()
    {
        dpSearchModule.Items.Clear();

        ListItem select = new ListItem();
        select.Text = " - Select - ";
        select.Value = "0";

        dpSearchModule.Items.Add(select);

        var ModuleList = new Module();
        dpSearchModule.DataSource = ModuleList.SelectAllModules(Convert.ToInt32(dpSearchSubject.SelectedValue));
        dpSearchModule.DataTextField = "Module_Name";
        dpSearchModule.DataValueField = "pkModule_ID";
        dpSearchModule.DataBind();
    }



    private void GetQuestions()
    {
        var AllQuestions = new Question();

        gvQuestions.DataSource = AllQuestions.SelectAllQuestions(Convert.ToInt32(dpSearchSubject.SelectedValue), Convert.ToInt32(dpSearchModule.SelectedValue));
        gvQuestions.DataBind();

    }

    private void GetPara()
    {
        if (Request.QueryString["ID"] != null)
        {
            ExamID = Convert.ToInt32(Request.QueryString["ID"]);
        }
    }

    protected void Search(object sender, EventArgs e)
    {
        GetQuestions();
    }

    protected void SearchSubjectSelected(object sender, EventArgs e)
    {
        GetModuleSearchList();
        GetQuestions();
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GetPara();

        Button btn = (Button)sender;

        int ID = Convert.ToInt32(btn.CommandArgument);

        InsertQuestionBank(ID);

    }


    protected void btnRemove_Click(object sender, EventArgs e)
    {
        GetPara();

        Button btn = (Button)sender;

        int ID = Convert.ToInt32(btn.CommandArgument);

        DeleteQuestionBank(ID);

    }


    private void InsertModuleBank()
    {

    }

    private void InsertQuestionBank(int QuestionID)
    {
        var NewQuestionBank = new Question_Bank();

        NewQuestionBank.ExamID = ExamID;
        NewQuestionBank.QuestionID = QuestionID;
        NewQuestionBank.InsertQuestionBank();

        GetAllQuestionBanks();

    }


    private void DeleteQuestionBank(int QuestionBankID)
    {
        var DeleteQuestionBank = new Question_Bank();
        DeleteQuestionBank.QuestionBankID = QuestionBankID;
        DeleteQuestionBank.DeleteQuestionBank();

        GetAllQuestionBanks();

    }


    private void GetAllQuestionBanks()
    {
        var AllQuestions = new Question_Bank();

        AllQuestions.ExamID = ExamID;
        gvQuestionBank.DataSource = AllQuestions.SelectQuestionBankByExam();
        gvQuestionBank.DataBind();

    }



    protected void gvQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestions.PageIndex = e.NewPageIndex;
        var AllQuestions = new Question_Bank();

        AllQuestions.ExamID = ExamID;
        gvQuestionBank.DataSource = AllQuestions.SelectQuestionBankByExam();

        

        gvQuestions.DataBind();
    }

}