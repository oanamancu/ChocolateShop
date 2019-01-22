using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_ChangeForgottenPassword : System.Web.UI.Page
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
        //get variables from URL
        string linkClient = Request.QueryString["user"];
        string linkCode = Request.QueryString["code"];

        //retrieve code & date from DB
        DateTime dateSent = new DateTime();
        string code = "", email = "";
        ConnectionClass.DateCodeActivateAccount(linkClient, ref dateSent, ref code, ref email);

        if (code == linkCode && DateTime.Now <= dateSent.AddDays(3))
            lblResult.Text = ConnectionClass.ChangeForgottenPassword(linkClient, AccountFunctions.getMd5Hash(txtNewPassword.Text));
        else lblResult.Text = "The link has expired or is wrong!";
    }
}