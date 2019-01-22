using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check if a user is logged in
        if (Session["login"] != null)
        {
            lblLogin.Text = "Welcome <a style=\" color: #fff;  text-decoration: none \" href= " + Page.ResolveUrl("~/Pages/Account/EditAccount.aspx") +  ">" + Session["login"] + "</a>";
            lblLogin.Visible = true;
            LinkButton1.Text = "Sign out";
        }
        else
        {
            lblLogin.Visible = false;
            LinkButton1.Text = "Sign In | Register";
            LinkButton2.Visible = false;
            btnHistory.Visible = false;
        }

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //User logs in 
        if (LinkButton1.Text == "Sign In | Register")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
        else
        {
            //User logs out
            Session.Clear();
            Response.Redirect("~/Pages/Home.aspx");
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Basket.aspx");
    }
    protected void btnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/History.aspx");
    }
}
