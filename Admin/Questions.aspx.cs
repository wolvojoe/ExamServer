using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Questions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageTitle.Text = "Modules";

        if (IsPostBack == false)
        {
            GetModules();
            GetSubjectList();
        }

        if (Request.QueryString["ID"] != null && IsPostBack == false)
        {
            int ModuleValue = Convert.ToInt32(Request.QueryString["ID"]);
            GetModule(ModuleValue);
            btnSave.Text = "Update";

        }
        else
        {

        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {


    }


}