using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Pages_Pralines : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        FillPage();
    }

    private void FillPage()
    {
        ArrayList chocolateList = new ArrayList();
        chocolateList = ConnectionClass.GetChocolateByType("type", "pralines");
        OutputFunctions.listItems(chocolateList, pnlProducts);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ArrayList chocolateList = new ArrayList();
        string what = txtSearch.Text;
        what = what.Replace("'", "");
        what = what.Replace("\"", "");
        chocolateList = ConnectionClass.ChocolateSearch(what);
        pnlProducts.Controls.Clear();
        OutputFunctions.listItems(chocolateList, pnlProducts);
        if (pnlProducts.Controls.Count == 0)
        {
            Label lbl = new Label() { Text = "No data found!", ForeColor = System.Drawing.ColorTranslator.FromHtml("#34000D") };
            pnlProducts.Controls.Add(lbl);
        }
    }
}