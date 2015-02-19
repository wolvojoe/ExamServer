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

            var NewThread = new Thread(() => ProcessExam(fuUploadQuestions.FileName));
            NewThread.Start();

        }


    }

    public void ProcessExam(string strFileName)
    {
        XmlDocument XMLExam = new XmlDocument();

        string strxml;

        strxml = LoadFile(strFileName);

        if (strxml.Length > 0)
        {
            XMLExam.LoadXml(strxml);
        }

    }

    private string LoadFile(string strFileName)
    {
        StreamReader textReader = new StreamReader(strUploadsFolder + strFileName);
        string strxml;

        strxml = textReader.ReadToEnd();

        return strxml;
    }





    private void GetSubject(XmlDocument XMLExam)
    {


        XmlNode AllExams;
        AllExams = XMLExam.DocumentElement.SelectSingleNode("Exam");


        foreach (XmlNode ExamDetails in AllExams.SelectNodes("Exams"))
        {
            Exam NewExam = new Exam();


            if (ExamDetails.SelectSingleNode("Name") != null)
            {
                NewExam.ExamName = ExamDetails.SelectSingleNode("Name").InnerText;
            }



            NewExam.InsertExam();
        }


    }


}