using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

public partial class Pages_ChocolateAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
        {
            // redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
        }

        if ( (string)Session["type"] != "admin" && (string)Session["type"] != "root_admin")
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
        else
        {
            string selectedValue = ddImage.SelectedValue;
            ShowImages();
            ddImage.SelectedValue = selectedValue;
        }
       
    }

    private void ShowImages()
    {
        //Get all filepaths
        string[] images = Directory.GetFiles(Server.MapPath("../Images/"));

        //Get all filenames and add them to an arraylist
        ArrayList imageList = new ArrayList();

        foreach(string image in images){
          string imageName=image.Substring(image.LastIndexOf(@"\")+1);
          imageList.Add(imageName); 
        }

        //Set the arrayList as the dropdownview's datasource and refresh
        ddImage.DataSource=imageList;
        ddImage.DataBind();
    }

    private void ClearTextFields()
    {
        txtDescription.Text = "";
        txtDimensions.Text = "";
        txtIngredients.Text="";
        txtName.Text = "";
        txtPrice.Text = "";
        txtWeight.Text = "";
    }


    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("../Images/") + filename);
            lblResult.Text = filename + " was succesfully uploaded!";
            Page_Load(sender, e);
        }
        catch (Exception)
        {
            lblResult.Text = "Upload failed!";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           string name=txtName.Text;
           string type=ddType.SelectedValue;
           double price=Convert.ToDouble(txtPrice.Text); 
           string image=ddImage.SelectedValue; 
           string description=txtDescription.Text;
           double weight; 
             if (txtWeight.Text.Equals("")) weight = 0; 
             else weight = Convert.ToDouble(txtWeight.Text); 
           string dimensions = txtDimensions.Text;
           string ingredients =txtDimensions.Text;
           string holiday = ddHoliday.SelectedValue;

           Chocolate chocolate = new Chocolate(name, type, price, image, description, weight, dimensions, ingredients, holiday);
           ConnectionClass.AddChocolate(chocolate);
           lblResult.Text = "Upload succesful!";
           ClearTextFields();           
        }
        catch (Exception)
        {
           lblResult.Text = "Upload failed!";
        }
    }
}