using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Pages_Account_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsSecureConnection)
       {
         // redirect visitor to SSL connection
         Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"));
       }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
      if(Page.IsValid == true && IsReCaptchValid()){

        string whatEmail = txtEmail.Text;
        whatEmail = whatEmail.Replace("'", "");
        whatEmail = whatEmail.Replace("\"", "");

        string whatName = txtName.Text;
        whatName = whatName.Replace("'", "");
        whatName = whatName.Replace("\"", "");

        string password = AccountFunctions.getMd5Hash(txtPassword.Text);

        //Create a new user
        User user = new User(whatName, password, whatEmail, "user");

        string activationCode = Membership.GeneratePassword(12, 1);
        activationCode = Regex.Replace(activationCode, "[^0-9A-Za-z]+", ",");
        DateTime dateCodeSent = DateTime.Now;

        //Register the user and return a result message
        lblResult.Text = ConnectionClass.RegisterUser(user,activationCode,dateCodeSent);

        if (lblResult.Text == "User registered! Please check your e-mail for the activation link.")
        {
            AccountFunctions.SendEmailActivateAccount(user.name, user.email, activationCode, Server.MapPath("../../Images/"));
        }
      }
    }


    protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        e.IsValid = cbAgree.Checked;
    }


    public bool IsReCaptchValid()
    {
        var result = false;
        var captchaResponse = Request.Form["g-recaptcha-response"];
        var secretKey = ConfigurationManager.AppSettings["recaptchaPrivatekey"];
        var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
        var request = (HttpWebRequest)WebRequest.Create(requestUri);

        using (WebResponse response = request.GetResponse())
        {
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                JObject jResponse = JObject.Parse(stream.ReadToEnd());
                var isSuccess = jResponse.Value<bool>("success");
                result = (isSuccess) ? true : false;
            }
        }
        return result;
    }  
}