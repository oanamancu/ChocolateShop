using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class Pages_Account_Activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        //get variables from URL
        string linkClient = Request.QueryString["user"];
        string linkCode = Request.QueryString["code"];

        DateTime dateSent=new DateTime();
        string code="", email="";
        ConnectionClass.DateCodeActivateAccount(linkClient, ref dateSent, ref code, ref email);

        if (code == linkCode && DateTime.Now <= dateSent.AddDays(3) && linkCode!="null")
        {
            ConnectionClass.ActivateAccount(email);
            lblResult.Text = "Your account has been successfully activated!";
            lBtnCodeRequest.Visible = false;
        }
        else{
            if (DateTime.Now > dateSent.AddDays(3))
                lblResult.Text = "Your activation link has expired!";
            else
                lblResult.Text = "Please register your account! <br /><br />" +
                      "An email was sent to you when you registered with this addres.<br />" +
                      "If you cannot find it, please check your spam folder too!<br />" +
                      "If you still cannot find it:";
                lBtnCodeRequest.Visible = true;
           }
    }
    protected void lBtnCodeRequest_Click(object sender, EventArgs e)
    {   
        //generate new code
        string activationCode = Membership.GeneratePassword(12, 1);
        activationCode = Regex.Replace(activationCode, "[^0-9A-Za-z]+", ",");
        DateTime dateCodeSent = DateTime.Now;
        ConnectionClass.UpdateCode(Request.QueryString["user"], activationCode, dateCodeSent);
        lBtnCodeRequest.Visible = false;
        lblResult.Text = "A new activation link was sent to you!";
        User user = ConnectionClass.GetUserDetails(Request.QueryString["user"]);
        AccountFunctions.SendEmailActivateAccount(user.name, user.email, activationCode, Server.MapPath("../../Images/"));
    }
}