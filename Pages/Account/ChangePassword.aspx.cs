using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {    
        string oldPassword = AccountFunctions.getMd5Hash(txtOldPassword.Text);
        string newPassword = AccountFunctions.getMd5Hash(txtNewPassword.Text);
        lblResult.Text = ConnectionClass.ChangePassword((string)Session["login"], oldPassword, newPassword);
    }
}