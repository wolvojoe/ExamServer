using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if(Session["Admin"] == "1")
            {

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
                
        }
        catch
        {
            Response.Redirect("~/Login.aspx");
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
