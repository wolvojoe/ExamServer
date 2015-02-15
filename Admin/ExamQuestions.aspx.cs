using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExamQuestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            GetQuestions();
            GetSubjectSearchList();
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
        Button btn = (Button)sender;

        string ID = btn.CommandArgument;

    }

}