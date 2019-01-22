<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Pages_Account_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <div> 
          <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
        </div>

    <table cellspacing="4" cellpadding="4">
        <tr>
            <td style="font-weight: 700">Name: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">Password: </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
                    <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtPassword" 
                    ErrorMessage="Password must contain minimum 8 and  at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character!" 
                    ForeColor="#34000D" 
                    
                    
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,49}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">Confirm Password: </td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtConfirm" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">E-mail Address: </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Not a valid e-mail address!" 
                    ForeColor="#34000D" 
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
    </table>

    <div style="margin-top: 10px">
    <asp:CheckBox ID="cbAgree" runat="server"/>
    I accept the <a href="<%=Page.ResolveUrl("~/Pages/Account/PrivacyPolicy.aspx")%>">PrivacyPolicy</a> of this site.
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*" 
                  ForeColor="#34000D"  OnServerValidate="CheckBoxRequired_ServerValidate"  
                   ></asp:CustomValidator>
    </div>

    <div class="g-recaptcha" data-sitekey="6Lco4IoUAAAAALkr7Z4cEPI-GPcmOUwCAuCten1v" style="margin-top: 10px"></div>

    <div style="margin-top: 10px">
     <asp:Button ID="btnRegister" runat="server" Text="Register" 
                    onclick="btnRegister_Click" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToCompare="txtConfirm" ControlToValidate="txtPassword" 
               ErrorMessage="Passwords must match!" ForeColor="#34000D">
      </asp:CompareValidator>
    </div>
</asp:Content>

