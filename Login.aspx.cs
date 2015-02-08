using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Admin AdminLogin = new Admin();
        Hash HashPassword = new Hash();

        AdminLogin.AdminEmail = txtEmail.Text.Trim();
        AdminLogin.AdminPassword = HashPassword.HashString(txtPassword.Text);

        bool LoginResult;
        LoginResult = AdminLogin.SelectAdminByEmailAndPassword();

        if (LoginResult == true)
        {
            Session.Add("Admin", AdminLogin);
            Response.Redirect("admin/dashboard.aspx", false);
        }
        else
        {

        }

    }
}