using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Data;

public partial class Pages_Orders : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        CheckIfAdmin();
        
        if (txtOpenOrders1.Text != "" && txtOpenOrders2.Text != "")
            printOrders(txtOpenOrders1.Text, txtOpenOrders2.Text, false);
        if (txtClosedOrders1.Text != "" && txtClosedOrders2.Text != "")
            printOrders(txtClosedOrders1.Text, txtClosedOrders2.Text, true);
        else
        {
            GenerateLineChart("amount","clientName","Orders per customer",LineChart1);
            GenerateLineChart("amount", "DATENAME(month, date) + ' ' + DATENAME(year, date)", "Units sold per month", LineChart2);
        }
    }

    private void CheckIfAdmin()
    {
        if ((string)Session["type"] != "admin" && (string)Session["type"] != "root_admin")
            Response.Redirect("~/Pages/Account/Login.aspx");
    }

    private void printOrders(string begindate, string endDate, bool shipped)
    {   
        StringBuilder sb= OutputFunctions.GenerateOrders(begindate, endDate, shipped);
        if (shipped == false)
            lblOpenOrders.Text = sb.ToString();
        else
            lblClosedOrders.Text = sb.ToString(); 
    }


    private void GenerateLineChart(string sumObject, string groupByObject, string title, AjaxControlToolkit.LineChart chart)
    {
        string query = string.Format("SELECT SUM({0}), {1} FROM orders GROUP BY {1}", sumObject, groupByObject);

        DataTable dt = ConnectionClass.GetChartDate(query);

        decimal[] x = new decimal[dt.Rows.Count];
        string[] y = new string[dt.Rows.Count];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = Convert.ToInt32(dt.Rows[i][0].ToString());
            y[i] = dt.Rows[i][1].ToString();
        }

        chart.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = x });
        chart.CategoriesAxis = string.Join(",", y);
        chart.ChartTitle = title;

        if (x.Length > 3)
            chart.ChartWidth = (x.Length * 75).ToString();
    }



}