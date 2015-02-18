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
        }


    }

}