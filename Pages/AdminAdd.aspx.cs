using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AdminAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if ((string)Session["type"] != "root_admin")
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string whatEmail = txtEmail.Text;
        whatEmail = whatEmail.Replace("'", "");
        whatEmail = whatEmail.Replace("\"", "");

        string whatName = txtName.Text;
        whatName = whatName.Replace("'", "");
        whatName = whatName.Replace("\"", "");

        //Create a new user
        User user = new User(whatName, txtPassword.Text, whatEmail, ddUserType.Text);

        //Register the user and return a result message
        lblResult.Text = ConnectionClass.RegisterUser(user,null,DateTime.Now);
        ClearTextFields();
    }

    private void ClearTextFields()
    {
        txtName.Text = "";
        txtPassword.Text = "";
        txtEmail.Text = "";
        txtConfirm.Text = "";
    }
}