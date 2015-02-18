using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

public partial class Admin_InstallExam : System.Web.UI.Page
{

    public delegate void Worker();
    private static Thread worker;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (fuUploadExam.HasFile)
        {

            fuUploadExam.SaveAs(Server.MapPath("~/Admin/Uploads/") + fuUploadExam.FileName);

            var NewThread = new Thread(() => ProcessExam(fuUploadExam.FileName));
            NewThread.Start();

        }


    }



    public void ProcessExam(string strFileName)
    {

    }

}