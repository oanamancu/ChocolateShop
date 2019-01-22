using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Security.Cryptography;

public class AccountFunctions
{
    static string contentID = "a1B38";

    public static String mailStart = @"<div style=""font-weight:normal; font-family:'Helvetica Neue','Segoe UI',Helvetica,Arial,sans-serif; color: #333333"">
            <table bgcolor=""#34000D"" border=""0"" cellspacing=""0"" width=""100%"" height=""64"">
            <tbody>
            <tr>
            <td></td>
            <td align=""center"" valign=""middle"" width=""500"" style=""padding:10px;margin:0"">
            <h1>
            <a href=""https://oanamancu.somee.com/"" style=""color: white""> ChocolateShop </a>
            </h1>
            </td>
            <td></td>
            </tr>
            </tbody>

            </table>
            <table border=""0"" cellspacing=""0"" width=""100%"" bgcolor=""#f0f0f0"" height=""20"">
            <tbody><tr><td></td></tr></tbody>
            </table>

            <table border=""0"" cellspacing=""0"" width=""100%"" bgcolor=""#f0f0f0"">
            <tbody>
            <tr>
            <td></td>
            <td width=""500"" align=""left"" bgcolor=""#ffffff"" valign=""top"" 
               style=""padding:10px; color:#333333; font-size:16px; line-height:1.5; 
               font-family:'Helvetica Neue','Segoe UI',Helvetica,Arial,sans-serif""
            >
           <div style="" text-align:center "">
           <img src=""cid:"+contentID+ @" ""style=""width:70px; height:70px""/>
           </div>
           <p>";

    public static String mailEnd = @"
           <br /><br />
             Kind regards, <br />
             The Chocolate Shop team
             </p>
             </td>
             <td></td>
             </tbody>
             </table>

            </table>
            <table border=""0"" cellspacing=""0"" width=""100%"" bgcolor=""#f0f0f0"" height=""20"">
            <tbody><tr><td></td></tr></tbody>
            </table>
            </div>";


  public static void SendEmailActivateAccount(string client, string eMail, string activationCode, string path)
    {
        MailAddress to = new MailAddress(eMail);
        MailAddress from = new MailAddress("");

        StringBuilder sb = new StringBuilder();

        string siteurl = "https://oanamancu.somee.com/ChocolateShop/Pages/Account/Activation.aspx";

        sb.Append(mailStart);

        sb.AppendFormat(@"
Dear {0}, <br />
<br />
We are happy that you decided to join our site! <br />
To activate your account please click on the link below: <br />
<br />

", client);

        sb.AppendFormat(@" <a href={0}?user={1}&code={2}>{0}?user={1}&code={2}</a> ", siteurl, client, activationCode);

        sb.Append(mailEnd);

        //Set up mail credentials
        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = from;
        mail.IsBodyHtml = true;
        mail.Body = sb.ToString();
        mail.Subject = "Account registration";
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

       // string path = Server.MapPath("../../Images/");
        Attachment oAttachment = new System.Net.Mail.Attachment(path + "pralines7.jpg");
        mail.Attachments.Add(oAttachment);
        oAttachment.ContentId = contentID;
        //Set up SMTP credentials
        try
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("", "");
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    } 
	
 public static void SendEmailRecoverPassword(string client, string eMail, string activationCode, string path){
     MailAddress to = new MailAddress(eMail);
     MailAddress from = new MailAddress("");

     StringBuilder sb = new StringBuilder();

     string siteurl = "https://oanamancu.somee.com/ChocolateShop/Pages/Account/ChangeForgottenPassword.aspx";

     sb.Append(mailStart);

     sb.AppendFormat(@"s
Dear {0}, <br />
<br />
You can change your password and log in into your account by following the next link: <br /> 
<br />
", client);

     sb.AppendFormat(@" <a href={0}?user={1}&code={2}>{0}?user={1}&code={2}</a> ", siteurl, client, activationCode);

     sb.Append(mailEnd);

     //Set up mail credentials
     MailMessage mail = new MailMessage(from, to);
     mail.IsBodyHtml = true;
     mail.Body = sb.ToString();
     mail.Subject = "Password recovery";

     // string path = Server.MapPath("../../Images/");
     Attachment oAttachment = new System.Net.Mail.Attachment(path + "pralines7.jpg");
     mail.Attachments.Add(oAttachment);
     oAttachment.ContentId = contentID;

     //Set up SMTP credentials
     SmtpClient smtp = new SmtpClient();
     smtp.Host = "smtp.gmail.com";
     smtp.Port = 587;
     smtp.Timeout = 10000;
     smtp.Credentials = new NetworkCredential("", "");
     smtp.EnableSsl = true;
     smtp.Send(mail);
 }

 public static string getMd5Hash(string input)
 {
     MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
     byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
     StringBuilder sBuilder = new StringBuilder();
     for (int i = 0; i < data.Length; i++)
     {
         sBuilder.Append(data[i].ToString("x2"));
     }

     return sBuilder.ToString();
 }

public static bool verifyMd5Hash(string input, string hash)
 {
     string hashOfInput = getMd5Hash(input);

     StringComparer comparer = StringComparer.OrdinalIgnoreCase;

     if (0 == comparer.Compare(hashOfInput, hash))
     {
         return true;
     }
     else
     {
         return false;
     }
 }

}