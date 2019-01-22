using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;


public partial class Pages_Basket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if(Session["login"] == null)
            Response.Redirect("~/Pages/Home.aspx");
        List<Tuple<int, int>> basketItems = (List<Tuple<int, int>>)Session["ordersIds"]; 
        if ( basketItems!= null && basketItems.Count != 0 )
        {
            btnOrder.Visible = true;
            lblResult.Visible = true;
            txtAddress.Visible = true;
            lblResult.Text = "Delivery Address: ";
            GenerateControls();

        }
        else
        {
            lblError.Text = "Your basket is empty!";
            btnOrder.Visible = false;
            lblResult.Visible = false;
            txtAddress.Visible = false;
        }
    }

    public void btn_Remove(object sender, EventArgs e)
    {
        Button button = sender as Button;
        OutputFunctions.removeBasketItem(button);
        GenerateControls();
        List<Tuple<int, int>> basketItems = (List<Tuple<int, int>>)Session["ordersIds"];
        if (basketItems.Count() == 0)
        {
            btnOrder.Visible = false;
            lblResult.Visible = false;
            txtAddress.Visible = false;
            lblError.Text = "Your basket is empty!";
        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        if (txtAddress.Text != "")
        {
            lblError.Visible = false;
            txtAddress.Visible = false;
            GenerateView();
        }
        else
        {
            lblError.Text = "Please write an address!";
            lblError.Visible = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GenerateControls();
        btnOrder.Visible = true;
        lblResult.Text = "Delivery Address: ";
        txtAddress.Visible = true;
        btnOk.Visible = false;
        btnCancel.Visible = false;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        SendOrder();

        lblResult.Text = "Your order has been placed, thank you for shopping at our store!";
        btnOk.Visible = false;
        btnCancel.Visible = false;
        txtAddress.Visible = false;
        btnOrder.Visible = false;

        pnlProducts.Controls.Clear();

    }

    //Fill page with dynamic controls showing products in basket
    private void GenerateControls()
    {
        pnlProducts.Controls.Clear(); 
        foreach (Tuple<int,int> id in (List<Tuple<int, int>>)HttpContext.Current.Session["ordersIds"])
          {
            //Create Controls
            Chocolate chocolate = ConnectionClass.GetChocolateById(id.Item1);
            Panel chocolatePanel = new Panel(); chocolatePanel.CssClass = "BasketChocolatePanel";
            Image image = new Image { ImageUrl = "..\\Images\\" + chocolate.image, CssClass = "ProductsImage" };
            Literal literalBr0 = new Literal { Text = "<br />" };
            Literal literalBr1 = new Literal { Text = "<br />" };
            Literal literalDiv0=new Literal { Text ="<div class=\"BasketEl\">"};
            Literal literalDiv1=new Literal { Text ="</div><div class=\"BasketEl\">"};
            Literal literalDiv2=new Literal { Text ="</div><div class=\"BasketEl\"><b> Quantity: </b>"};
            Literal literalDiv3=new Literal { Text="</div>"};
            Label lblName = new Label { Text = chocolate.name, CssClass = "ProductsName" };
            Label lblPrice = new Label
            {
                Text = String.Format("Price per Item: " + "{0:0.00}$<br />" + "  " + "Total price: " + "{1:0.00}" + "$<br />", chocolate.price, (chocolate.price * id.Item2)),
                CssClass = "ProductsPrice"
            };
            Button btnRemove = new Button();
            btnRemove.ID = "btn" + chocolate.id.ToString();
            btnRemove.Click += new EventHandler(btn_Remove);
            btnRemove.Text = "Remove";
            btnRemove.Style.Value ="margin-top: 5px; ";
            TextBox textBox = new TextBox
            {
                ID = chocolate.id.ToString(),
                CssClass = "ProductsTextBox",
                Width = 60,
                Text = Convert.ToString(id.Item2)
            };

            //Add validation so only numbers can be entered into the textfields
            RegularExpressionValidator regex = new RegularExpressionValidator
            {
                ValidationExpression = "^[0-9]*",
                ControlToValidate = textBox.ID,
                ErrorMessage = "Please enter a number."
            };

            //Add controls to Panels
            chocolatePanel.Controls.Add(image);
            chocolatePanel.Controls.Add(literalDiv0);
            chocolatePanel.Controls.Add(lblName);
            chocolatePanel.Controls.Add(literalDiv1);
            chocolatePanel.Controls.Add(lblPrice);
            chocolatePanel.Controls.Add(literalDiv2);
            chocolatePanel.Controls.Add(textBox);
            chocolatePanel.Controls.Add(literalBr0);
            chocolatePanel.Controls.Add(regex);
            chocolatePanel.Controls.Add(literalBr1);
            chocolatePanel.Controls.Add(btnRemove);
            chocolatePanel.Controls.Add(literalDiv3);

            pnlProducts.Controls.Add(chocolatePanel);
        }
    }

    private void GenerateView()
    {
        double totalAmount = 0;
        ArrayList orderList = getOrders();
        Session["orders"] = orderList;

        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        sb.Append("<h3>Please review your order</h3>");

        foreach (Order order in orderList)
        {
            double totalRow = order.price * order.amount;
            sb.Append(String.Format(@"<tr>
                                          <td width = '50px' >{0} x </td>
                                          <td width = '200px'>{1} ({2}$)</td>
                                          <td>{3}</td><td>$</td>
                                       </tr>"
                                   ,order.amount, order.product, order.price,String.Format("{0:0.00}",totalRow)));
            totalAmount += totalRow;
        }

        sb.Append(String.Format(@"<tr>
                                       <td><b>Total: </b></td>
                                       <td><b>{0} $ </b></td>
                                   </tr>",totalAmount));

        sb.Append("</table>");

        lblResult.Text = sb.ToString();
        btnOk.Visible = true;
        btnCancel.Visible = true;
        pnlProducts.Controls.Clear();
        btnOrder.Visible = false;
    }

    private ArrayList getOrders()
    {
        ArrayList orderList = new ArrayList();
        List<Tuple<int, int>> basketList = (List<Tuple<int, int>>)Session["ordersIds"];
        List<Tuple<int, int>> newBasketList = new List<Tuple<int, int>>();

        if(basketList.Count != 0)
        foreach (Tuple<int, int> t in basketList)
        {
            TextBox textBox = pnlProducts.FindControl(Convert.ToString(t.Item1)) as TextBox;
            string txt = textBox.Text;
            if(txt != "")
              if (Convert.ToInt32(txt) > 0)
                newBasketList.Add( new Tuple<int,int>( t.Item1, Convert.ToInt32(txt) )  );
        }

        foreach(Tuple<int,int> t in newBasketList ){
            int amountOfOrders = t.Item2;
            Chocolate chocolate = ConnectionClass.GetChocolateById(t.Item1);
            Order order = new Order(Session["login"].ToString(), chocolate.name, amountOfOrders, chocolate.price, DateTime.Now, false, txtAddress.Text);
            orderList.Add(order);
        }
        Session["ordersIds"] = newBasketList;
        return orderList;
    }

    private void SendOrder()
    {
        ArrayList orderList = getOrders();
        ConnectionClass.AddOrders(orderList);
        Session["ordersIds"] = null;
    }

}