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

public partial class Admin_InstallExam : System.Web.UI.Page
{

    public delegate void Worker();
    private Thread worker;
    public string strUploadsFolder = "~/Admin/Uploads/";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (fuUploadExam.HasFile)
        {

            fuUploadExam.SaveAs(Server.MapPath(strUploadsFolder) + fuUploadExam.FileName);

            var NewThread = new Thread(() => ProcessExam(fuUploadExam.FileName));
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

    private void GetExam(XmlDocument XMLExam)
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

            if (ExamDetails.SelectSingleNode("Description") != null)
            {
                NewExam.ExamDescription = ExamDetails.SelectSingleNode("Description").InnerText;
            }

            if (ExamDetails.SelectSingleNode("Active") != null)
            {
                NewExam.ExamActive = Convert.ToBoolean(ExamDetails.SelectSingleNode("Active").InnerText);
            }

            if (ExamDetails.SelectSingleNode("OpenDateEnabled") != null)
            {
                NewExam.ExamOpenDateEnabled = Convert.ToBoolean(ExamDetails.SelectSingleNode("OpenDateEnabled").InnerText);
            }

            if (ExamDetails.SelectSingleNode("OpenDate") != null)
            {
                NewExam.ExamOpenDate = Convert.ToDateTime(ExamDetails.SelectSingleNode("OpenDate").InnerText);
            }

            if (ExamDetails.SelectSingleNode("ClosedDateEnabled") != null)
            {
                NewExam.ExamClosedDateEnabled = Convert.ToBoolean(ExamDetails.SelectSingleNode("ClosedDateEnabled").InnerText);
            }

            if (ExamDetails.SelectSingleNode("ClosedDate") != null)
            {
                NewExam.ExamClosedDate = Convert.ToDateTime(ExamDetails.SelectSingleNode("ClosedDate").InnerText);
            }

            if (ExamDetails.SelectSingleNode("TimeLimitEnabled") != null)
            {
                NewExam.ExamTimeLimitEnabled = Convert.ToBoolean(ExamDetails.SelectSingleNode("TimeLimitEnabled").InnerText);
            }

            if (ExamDetails.SelectSingleNode("TimeLimit") != null)
            {
                NewExam.ExamTimeLimit = Convert.ToInt32(ExamDetails.SelectSingleNode("TimeLimit").InnerText);
            }

            if (ExamDetails.SelectSingleNode("AttemptsAllowed") != null)
            {
                NewExam.ExamAttemptsAllowed = Convert.ToInt32(ExamDetails.SelectSingleNode("AttemptsAllowed").InnerText);
            }

            if (ExamDetails.SelectSingleNode("QuestionsOrdered") != null)
            {
                NewExam.ExamQuestionsOrdered = Convert.ToBoolean(ExamDetails.SelectSingleNode("QuestionsOrdered").InnerText);
            }

            if (ExamDetails.SelectSingleNode("ShuffleAnswers") != null)
            {
                NewExam.ExamQuestionsOrdered = Convert.ToBoolean(ExamDetails.SelectSingleNode("ShuffleAnswers").InnerText);
            }

            if (ExamDetails.SelectSingleNode("LearningMode") != null)
            {
                NewExam.ExamLearningMode = Convert.ToBoolean(ExamDetails.SelectSingleNode("LearningMode").InnerText);
            }

            if (ExamDetails.SelectSingleNode("Password") != null)
            {
                NewExam.ExamPassword = Convert.ToString(ExamDetails.SelectSingleNode("Password").InnerText);
            }


            NewExam.InsertExam();
        }


    }



}