using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.IO;


public partial class Admin_InstallQuestions : System.Web.UI.Page
{

    public delegate void Worker();
    private Thread worker;
    public string strUploadsFolder = "~/Admin/Uploads/";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            GetSubjectList();
        }
    }

    protected void SubjectSelected(object sender, EventArgs e)
    {
        GetModuleList();
    }


    private void GetModuleList()
    {
        dpModule.Items.Clear();

        ListItem select = new ListItem();
        select.Text = " - Select - ";
        select.Value = "0";

        dpModule.Items.Add(select);

        var ModuleList = new Module();
        dpModule.DataSource = ModuleList.SelectAllModules(Convert.ToInt32(dpSubject.SelectedValue));
        dpModule.DataTextField = "Module_Name";
        dpModule.DataValueField = "pkModule_ID";
        dpModule.DataBind();

    }


    private void GetSubjectList()
    {
        var SubjectList = new Subject();
        dpSubject.DataSource = SubjectList.SelectAllSubjects();
        dpSubject.DataTextField = "Subject_Name";
        dpSubject.DataValueField = "pkSubject_ID";
        dpSubject.DataBind();

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (fuUploadQuestions.HasFile)
        {

            fuUploadQuestions.SaveAs(Server.MapPath(strUploadsFolder) + fuUploadQuestions.FileName);

            var NewThread = new Thread(() => ProcessQuestion(fuUploadQuestions.FileName));
            NewThread.Start();

        }


    }

    public void ProcessQuestion(string strFileName)
    {
        XmlDocument XMLQuestion = new XmlDocument();

        string strxml;

        strxml = LoadFile(strFileName);

        if (strxml.Length > 0)
        {
            XMLQuestion.LoadXml(strxml);
            GetQuestions(XMLQuestion);
        }


    }

    private string LoadFile(string strFileName)
    {
        StreamReader textReader = new StreamReader(strUploadsFolder + strFileName);
        string strxml;

        strxml = textReader.ReadToEnd();

        return strxml;
    }





    private void GetQuestions(XmlDocument XMLQuestion)
    {

        XmlNode AllQuestions;
        AllQuestions = XMLQuestion.DocumentElement.SelectSingleNode("Questions");


        foreach (XmlNode QuestionDetails in AllQuestions.SelectNodes("Question"))
        {
            Question NewQuestion = new Question();


            if (QuestionDetails.SelectSingleNode("Name") != null)
            {
                NewQuestion.QuestionName = QuestionDetails.SelectSingleNode("Name").InnerText;
            }

            if (QuestionDetails.SelectSingleNode("Active") != null)
            {
                NewQuestion.QuestionActive = Convert.ToBoolean(QuestionDetails.SelectSingleNode("Active").InnerText);
            }

            if (QuestionDetails.SelectSingleNode("Description") != null)
            {
                NewQuestion.QuestionDescription = QuestionDetails.SelectSingleNode("Description").InnerText;
            }

            if (QuestionDetails.SelectSingleNode("Type") != null)
            {
                NewQuestion.QuestionTypeID = Convert.ToInt32(QuestionDetails.SelectSingleNode("Type").InnerText);
            }


            NewQuestion.ModuleID = Convert.ToInt32(dpModule.SelectedValue);
            

            NewQuestion.InsertQuestion();

            XmlNode Answers = QuestionDetails.SelectSingleNode("Answers");

            GetAnswers(Answers);

        }

    }



    private void GetAnswers(XmlNode XMLAnswers)
    {

        foreach (XmlNode AnswerDetails in XMLAnswers.SelectNodes("Answer"))
        {
            Answer NewAnswer = new Answer();


            if (AnswerDetails.SelectSingleNode("Name") != null)
            {
                NewAnswer.AnswerName = AnswerDetails.SelectSingleNode("Name").InnerText;
            }

            if (AnswerDetails.SelectSingleNode("Description") != null)
            {
                NewAnswer.AnswerDescription = AnswerDetails.SelectSingleNode("Description").InnerText;
            }

            if (AnswerDetails.SelectSingleNode("Order") != null)
            {
                NewAnswer.AnswerOrder = Convert.ToInt32(AnswerDetails.SelectSingleNode("Order").InnerText);
            }

            if (AnswerDetails.SelectSingleNode("Correct") != null)
            {
                NewAnswer.AnswerCorrect = Convert.ToBoolean(AnswerDetails.SelectSingleNode("Correct").InnerText);
            }



            NewAnswer.QuestionID = Convert.ToInt32(0);


            NewAnswer.InsertAnswer();
        }


    }




}