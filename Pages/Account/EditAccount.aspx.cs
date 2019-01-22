using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_EditAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        if(!IsPostBack)
           if (Session["login"] == null)
             {
               Response.Redirect("~/Pages/Home.aspx");
             }
           else if (!Request.IsSecureConnection)
           {
               // redirect visitor to SSL connection
               Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
           }
        
    }
    protected void lBtnDelete_Click(object sender, EventArgs e)
    {
        ConnectionClass.DeleteAccount((string)Session["login"]);
        lblResult.Text = "You account was successfully deleted!";
        Session.Clear();
    }
    protected void lBtnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Account/ChangePassword.aspx");
    }
}