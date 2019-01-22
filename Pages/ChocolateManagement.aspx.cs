using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;

public partial class Pages_ChocolateManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if ((string)Session["type"] != "admin" && (string)Session["type"] != "root_admin")
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
    protected void LinkbtnDelete_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("../Images/");

        string[] images = Directory.GetFiles(path);
        IList<string> usedImages = ConnectionClass.UsedImages(path);

        //add  images used in Home + Banner + site icon
        usedImages.Add(path + "chocolate1.jpg");
        usedImages.Add(path + "chocolate3.jpg");
        usedImages.Add(path + "chocolate5.jpg");
        usedImages.Add(path + "banner8.jpg");
        usedImages.Add(path + "pralines7.jpg");

        var result = images.Except(usedImages);
        IList<string> toBeDeleted = result.ToList<string>();

        foreach (string p in toBeDeleted)
        {
            FileInfo file = new FileInfo(p);
            file.Delete();
        }

        lblResult.Text = "All the unnecessary files were deleted!";
    }
}