using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        } 
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string password = AccountFunctions.getMd5Hash(txtPassword.Text);

        string whatEmail = txtLogin.Text;
        whatEmail = whatEmail.Replace("'", "");
        whatEmail = whatEmail.Replace("\"", "");

        User user = ConnectionClass.LoginUser(whatEmail, password);

        if (user != null)
        {
            bool activated = ConnectionClass.accountActivated(user.email);

            if (activated == true)
            {
                //Store login variables in session
                Session["login"] = user.name;
                Session["type"] = user.type;
                Response.Redirect("~/Pages/Home.aspx");
            }

            else
            {
                string where = "~/Pages/Account/Activation.aspx?user=" + user.name + "&code=null";
                Response.Redirect(where);
            }
        }
        else
        {
            lblError.Text = "Login failed";
        }

    }
}