<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="15" class="chocolateTable1" style="margin-right: 30px; margin-top: 16px;">
        <tr>
            <td style="width: 170px"><b>E-mail Address:&nbsp;&nbsp; </b></td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtLogin" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 170px"><b>Password: </b></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtPassword" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 170px">
                <asp:Button ID="btnLogin" runat="server" Text="Sign in" 
                    onclick="btnLogin_Click" Width="107px" /><br/>  
            </td>
            <td>
              <asp:LinkButton ID="LinkButton2" runat="server" 
                    PostBackUrl="~/Pages/Account/Registration.aspx" CausesValidation="False">Register</asp:LinkButton>
               
            &nbsp;&nbsp;
              <asp:LinkButton ID="lBtnPasswordForgotten" runat="server" 
                    PostBackUrl="~/Pages/Account/PasswordForgotten.aspx?user=null&code=null" CausesValidation="False">Forgot password?</asp:LinkButton>
               
            </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblError" runat="server" ForeColor="#34000D"></asp:Label>  
          </td>
        </tr>
    </table>

</asp:Content>

