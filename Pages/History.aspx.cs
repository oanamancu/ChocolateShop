using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Globalization;

public partial class Pages_History : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if (Session["login"] == null)
            Response.Redirect("~/Pages/Home.aspx");

        StringBuilder sb = new StringBuilder();
        ArrayList orderList = ConnectionClass.GetGroupedOrders((string)Session["login"]);

        if (orderList.Count == 0)
            sb.Append("No orders yet!<br/><br/>");
        else
        {
          sb.Append(@"<table class='orderTable'>
                               <tr><th>Date</th><th>Total</th><th>Shipped</tn></tr>");

          foreach (GroupedOrder groupedOrder in orderList)
          {
           sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                   (groupedOrder.Date).ToString("dd/M/yyyy", CultureInfo.InvariantCulture), groupedOrder.Total, groupedOrder.Shipped,
                   string.Format("<a href='OrdersDetailed.aspx?client={0}&date={1}&shipped={2}'>View detail</a>", groupedOrder.Client, (groupedOrder.Date).ToString("M/dd/yyyy", CultureInfo.InvariantCulture), groupedOrder.Shipped)));
          }
          sb.Append("</table>");
        }

        lblHistory.Text = sb.ToString();
    }
}