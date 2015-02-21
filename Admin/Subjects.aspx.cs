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

        if (IsPostBack == false)
        {
            GetSubjects();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int SubjectID = Convert.ToInt32(Request.QueryString["ID"]);
            GetSubject(SubjectID);
            btnSave.Text = "Update";

        }
        else
        {

        }


        
    }

    private void GetSubjects()
    {
        var AllSubjects = new Subject();

        gvSubjects.DataSource = AllSubjects.SelectAllSubjects();
        gvSubjects.DataBind();

    }

    private void GetSubject(int SubjectID)
    {
        var GetSubject = new Subject();

        GetSubject.SubjectID = SubjectID;
        GetSubject.SelectSubjectByID();

        txtName.Text = GetSubject.SubjectName;
        chkActive.Checked = GetSubject.SubjectActive;

    }

    private void InsertSubject()
    {
        var NewSubject = new Subject();
        NewSubject.SubjectName = txtName.Text.Trim();
        NewSubject.SubjectActive = chkActive.Checked;
        NewSubject.InsertSubject();
    }

    private void UpdateSubject(int SubjectID)
    {
        var UpdateSubject = new Subject();
        UpdateSubject.SubjectID = SubjectID;
        UpdateSubject.SelectSubjectByID();
        UpdateSubject.SubjectName = txtName.Text.Trim();
        UpdateSubject.SubjectActive = chkActive.Checked;
        UpdateSubject.UpdateSubject();

        Response.Redirect(Request.Path);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ID"] != null)
        {
            int SubjectID = Convert.ToInt32(Request.QueryString["ID"]);
            UpdateSubject(SubjectID);

        }
        else
        {
            InsertSubject();
        }

        GetSubjects();

    }



    protected void gvSubjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubjects.PageIndex = e.NewPageIndex;
        GetSubjects();
    }

}