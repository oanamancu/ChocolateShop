using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Windows.Forms;

public partial class Pages_OrdersDetailed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if (((string)Session["type"] != "admin" && (string)Session["type"] != "root_admin") || Request.QueryString["shipped"] == "True")
            btnShip.Visible = false;
        lblTitle.Text = string.Format("<h2><font color='#34000d'>Client: {0} <br />Date: {1}</font></h2>",
                             Request.QueryString["client"], Request.QueryString["date"]);
    }


    protected void btnShip_Click(object sender, EventArgs e)
    {
        //get variables from URL
        string client = Request.QueryString["client"];
        DateTime date = Convert.ToDateTime(Request.QueryString["date"]);

        //get user info + user's placed orders
        User user = ConnectionClass.GetUserDetails(client);
        ArrayList orderList = ConnectionClass.GetDetailedOrders(client, date);

        // update orders + send confirmation e-mail
        //Then, send user back to 'Orders' Page
        ConnectionClass.UpdateOrders(client, date);
        SendEmail(user.name, user.email, orderList);
        Response.Redirect("~/Pages/Orders.aspx");
    }


    private void SendEmail(string client, string eMail, ArrayList orderList)
    {
        MailAddress to = new MailAddress(eMail);
        MailAddress from = new MailAddress("");

        StringBuilder sb = new StringBuilder();
        double total = 0;
        string contentID = "a1B37";

        sb.Append(AccountFunctions.mailStart);

        sb.AppendFormat(@"
Dear {0}, <br />
<br />
We are pleased to let you know that your order placed on {1} is on its way. <br />
<br />
Your ordered products:<br />", client, Request.QueryString["date"]);

        foreach (Order order in orderList)
        {
            sb.AppendFormat(@" 
 - {0} ({1} $)   x   {2}   =   {3} <br />",
                            order.product, order.price, order.amount, (order.amount*order.price));
            total += (order.amount * order.price);
        }

        sb.AppendFormat(@"
Total amount = " + total);

        sb.Append(AccountFunctions.mailEnd);

        //Set up mail credentials
        MailMessage mail = new MailMessage(from, to);
        mail.IsBodyHtml = true;
        mail.Body = sb.ToString();
        mail.Subject = "Your order is on its way!";

        string path = Server.MapPath("../Images/");
        Attachment oAttachment = new System.Net.Mail.Attachment(path + "pralines7.jpg");
        mail.Attachments.Add(oAttachment);
        oAttachment.ContentId = contentID;

        //Set up SMTP credentials
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new NetworkCredential("", "");
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}