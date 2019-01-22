using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class Pages_Account_PasswordForgotten : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        //user exists?

        string who = txtName.Text;
        who = who.Replace("'", "");
        who = who.Replace("\"", "");

        User user = ConnectionClass.GetUserDetails(who);
        if (user == null)
            lblResult.Text = "User does not exist!";
        else
        {
            string activationCode = Membership.GeneratePassword(12, 1);
            activationCode = Regex.Replace(activationCode, "[^0-9A-Za-z]+", ",");
            DateTime dateCodeSent = DateTime.Now;
            ConnectionClass.UpdateCode(user.name, activationCode, dateCodeSent);
            AccountFunctions.SendEmailRecoverPassword(user.name, user.email, activationCode, Server.MapPath("../../Images/"));
            lblResult.Text = "Please verify your inbox for the recovery link!";
        }
    }
}