using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class Admin_Answers : System.Web.UI.Page
{

    public int QuestionID;
    public int AnswerID;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Answers";

        GetParams();

        if (IsPostBack == false && QuestionID > 0)
        {
            GetAnswers();
        }

        if (AnswerID > 0 && QuestionID > 0 && IsPostBack == false)
        {
            GetAnswer();
            btnSave.Text = "Update";
        }
        else
        {

        }
    }


    private void GetAnswers()
    {
        var AllAnswers = new Answer();

        gvAnswers.DataSource = AllAnswers.SelectAllAnswers(QuestionID);
        gvAnswers.DataBind();

    }



    private void GetAnswer()
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
        var NewAnswer = new Answer();

        NewAnswer.AnswerName = txtValue.Text.Trim();
        NewAnswer.AnswerDescription = txtDescription.Text.Trim();
        NewAnswer.AnswerCorrect = chkCorrect.Checked;
        NewAnswer.QuestionID = QuestionID;
        NewAnswer.InsertAnswer();
    }

    private void UpdateAnswer()
    {
        var UpdateAnswer = new Answer();

        UpdateAnswer.AnswerID = AnswerID;
        UpdateAnswer.SelectAnswerByID();

        UpdateAnswer.AnswerName = txtValue.Text.Trim();
        UpdateAnswer.AnswerDescription = txtDescription.Text.Trim();
        UpdateAnswer.AnswerCorrect = chkCorrect.Checked;

        UpdateAnswer.UpdateAnswer();



        Response.Redirect(Request.Path + "?ID=" + Convert.ToString(QuestionID));
    }

    private void GetParams()
    {
        if (Request.QueryString["ID"] != null)
        {
            QuestionID = Convert.ToInt32(Request.QueryString["ID"]);
        }

        if (Request.QueryString["AnsID"] != null)
        {
            AnswerID = Convert.ToInt32(Request.QueryString["AnsID"]);
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        GetParams();

        if (AnswerID > 0 && QuestionID > 0)
        {
            UpdateAnswer();

        }
        else if (QuestionID > 0)
        {
            InsertAnswer();
        }


        if (QuestionID > 0)
        {
            GetAnswers();
        }
        

    }

}