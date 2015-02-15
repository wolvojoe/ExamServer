using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Exams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Exams";

        GetExams();
        
    }

    private void GetExams()
    {
        var AllExams = new Exam();

        gvExams.DataSource = AllExams.SelectAllExams();
        gvExams.DataBind();

    }


    protected void btnCreate_Click(object sender, EventArgs e)
    {

        Response.Redirect("exam.aspx");

    }

}