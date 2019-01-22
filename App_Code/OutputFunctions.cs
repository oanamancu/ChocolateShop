using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Linq;
using System.Globalization;


public static class OutputFunctions
{
    public static void listItems(ArrayList chocolateList, Panel pnlProducts)
    {
        List<Tuple<int,int>> orderList = (List<Tuple<int,int>>)HttpContext.Current.Session["ordersIds"];

        foreach (Chocolate chocolate in chocolateList)
        {
            StringBuilder sb = new StringBuilder();
            Label lbl = new Label();
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();
            Label lbl4 = new Label();
            Panel chocolatePnl = new Panel();

            TextBox textBox = new TextBox
            {
                ID = "txt" + chocolate.id.ToString(),
               // CssClass = "ProductsTextBox",
                Width = 60,
                Text = "0"
            };

            //Add validation so only numbers can be entered into the textfields
            RegularExpressionValidator regex = new RegularExpressionValidator
            {
                ValidationExpression = "^[0-9]*",
                ControlToValidate = textBox.ID,
                ForeColor = Color.Red,
                ErrorMessage = "Please enter a number!"
            };

            Button btn = new Button();
            btn.ID="btn" + chocolate.id.ToString();
            btn.Click += new EventHandler(OutputFunctions.btn_AddOrder);
            btn.Text = "Add to Cart";
            if (orderList != null)
                if (orderList.Any(t => t.Item1 == chocolate.id))
                {
                    btn.Text = "Remove from Cart";
                    IEnumerable<int> auxT =  from Tuple<int,int> t in orderList where t.Item1 == chocolate.id 
                                          select t.Item2;
                  textBox.Text = Convert.ToString(auxT.ElementAt(0));
                }
          

            sb.Append(
                string.Format(@"<table class='chocolateTable'>
                   <tr>
                     <th rowspan='6' width='150px'><img runat='server' src='..\Images\{0}'/>
                    <div style=""margin-left: 20px""><small> Quantity: ",
                  chocolate.image)
                  );
            lbl1.Text = sb.ToString();

            chocolatePnl.Controls.Add(lbl1);
            chocolatePnl.Controls.Add(textBox);
            sb.Clear();
            sb.Append(string.Format(@"</small></div>"));
            lbl2.Text = sb.ToString();
            chocolatePnl.Controls.Add(regex);
            chocolatePnl.Controls.Add(lbl2);
            sb.Clear();
            sb.Append(string.Format(@"<div style=""margin-left: 40px ; margin-bottom: 15px ""> "));
            lbl3.Text = sb.ToString();
            chocolatePnl.Controls.Add(lbl3);
            chocolatePnl.Controls.Add(btn);
            sb.Clear();
            sb.Append(string.Format(@"</div>"));
            lbl4.Text = sb.ToString();
            chocolatePnl.Controls.Add(lbl4);

            sb.Clear();
            sb.Append(    
                string.Format(@"  </th>
                     <th width='50px'>Name: </td> 
                     <td>{0}</td>
                  </tr>
  
                  <tr>
                     <th>Price: </th>
                     <td>{1} $</td>
                  </tr>",
              chocolate.name, chocolate.price)
             );
            if (chocolate.weight != 0)
            {
                sb.Append(
                string.Format(@"
                   <tr>
                      <th>Weight: </th>
                      <td>{0} g</td>
                   </tr>",
                chocolate.weight)
                );
            }
            if (chocolate.dimensions != null)
            {
                sb.Append(
                string.Format(@"
                   <tr>
                      <th>Dimensions: </th>
                      <td>{0}</td>
                   </tr>",
                chocolate.dimensions)
                );
            }

            if (chocolate.ingredients != null)
            {
                sb.Append(
                string.Format(@"
                   <tr>
                      <th>Ingredients: </th>
                      <td>{0}</td>
                   </tr>",
                chocolate.ingredients)
                );
            }

            if (chocolate.description != null)
            {
                sb.Append(
                    string.Format(@"
                       <tr>
                          <td colspan='2'>{0}</td>
                       </tr>",
                     chocolate.description)
                  );
            }

            sb.Append(string.Format(@"</table>"));
            lbl.Text = sb.ToString();
            chocolatePnl.Controls.Add(lbl);
            pnlProducts.Controls.Add(chocolatePnl);
           
        }
    }

    public static void removeBasketItem(Button button)
    {
        List<Tuple<int, int>> orderList = (List<Tuple<int, int>>)HttpContext.Current.Session["ordersIds"];
        Tuple<int, int> toBeDeleted = new Tuple<int, int>(-1, 0);
        foreach (Tuple<int, int> item in orderList)
            if (item.Item1 == Convert.ToInt32(button.ID.Substring(3)))
                toBeDeleted = item;
        orderList.Remove(toBeDeleted);
        HttpContext.Current.Session["ordersIds"] = orderList;
    }

    public static void btn_AddOrder(object sender, EventArgs e)
    {
        Button button = sender as Button;
        Tuple<int, int> toBeDeleted = new Tuple<int, int>(-1, 0);
        List<Tuple<int, int>> orderList = null;
        Panel parent = button.Parent as Panel;
        TextBox txtBox = parent.FindControl("txt" + button.ID.Substring(3)) as TextBox;

        if (HttpContext.Current.Session["login"] != null)
        {
            if (button.Text.Equals("Remove from Cart"))
            {
                button.Text = "Add to Cart";
                txtBox.Text = "0";
                removeBasketItem(button);
            }
            else if (txtBox.Text != "0")
            {
                button.Text = "Remove from Cart";
                Tuple<int, int> toBeChanged = new Tuple<int, int>(-1, 0);
                if (HttpContext.Current.Session["ordersIds"] == null)
                    orderList = new List<Tuple<int,int>>();
                else
                    orderList = (List<Tuple<int,int>>)HttpContext.Current.Session["ordersIds"];

                if (orderList.Any(t => t.Item1 == Convert.ToInt32(button.ID.Substring(3)))){
                    removeBasketItem(button);
                }
                orderList.Add(new Tuple<int, int>(Convert.ToInt32(button.ID.Substring(3)), Convert.ToInt32(txtBox.Text)));
                HttpContext.Current.Session["ordersIds"] = orderList;
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }


    public static StringBuilder GenerateOrders(string begindate, string endDate, bool shipped)
    {
        StringBuilder sb = new StringBuilder();
        DateTimeFormatInfo info = new CultureInfo("en-us", false).DateTimeFormat;
        string shippedString = shipped ? "Completed" : "Open";

        DateTime date1 = Convert.ToDateTime(begindate, info);
        DateTime date2 = Convert.ToDateTime(endDate, info);
        DateTime incrementalDate = date1;

        //get grouped orders
        while (incrementalDate <= date2)
        {
            sb.Append(string.Format(@"<b><font color='#34000d'>{0} orders for {1} {2}</font></b><br />", shippedString, info.GetMonthName(incrementalDate.Month), incrementalDate.Year));
            ArrayList orderList = ConnectionClass.GetGroupedOrders(incrementalDate, date2, shipped);

            if (orderList.Count == 0)
            {
                sb.Append("No orders for this period<br/><br/>");
            }
            else
            {
                sb.Append(@"<table class='orderTable'>
                               <tr><th>Date</th><th>Client</tn><th>Total</th></tr>");

                foreach (GroupedOrder groupedOrder in orderList)
                {
                    sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}$</td><td>{3}</td></tr>",
                                            (groupedOrder.Date).ToString("M/dd/yyyy", CultureInfo.InvariantCulture), groupedOrder.Client, groupedOrder.Total,
                                            string.Format("<a href='OrdersDetailed.aspx?client={0}&date={1}&shipped={2}'>View details</a>", groupedOrder.Client, (groupedOrder.Date).ToString("dd/M/yyyy", CultureInfo.InvariantCulture), shipped)));
                }
                sb.Append("</table>");
            }

            //increment date to next month and set first day of new month to 1
            incrementalDate = incrementalDate.AddMonths(1);
            incrementalDate = new DateTime(incrementalDate.Year, incrementalDate.Month, 1);
        }

        return sb;
    }


}
