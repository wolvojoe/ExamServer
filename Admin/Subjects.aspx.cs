using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Subjects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Subjects";

        GetSubjects();
    }

    private void GetSubjects()
    {
        var AllSubjects = new Subject();

        gvSubjects.DataSource = AllSubjects.SelectAllSubjects();
        gvSubjects.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var NewSubject = new Subject();
        NewSubject.SubjectName = txtName.Text.Trim();
        NewSubject.SubjectActive = chkActive.Checked;
        NewSubject.InsertSubject();

    }

}