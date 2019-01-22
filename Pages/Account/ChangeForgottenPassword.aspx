<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="ChangeForgottenPassword.aspx.cs" Inherits="Pages_Account_ChangeForgottenPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table cellpadding="4" cellspacing="4">
        <tr>
            <td style="font-weight: 700">
                New password:
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtNewPassword" 
                    ErrorMessage="Password must contain minimum 8 and  at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character!" 
                    ForeColor="#34000D" 
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,49}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">
                Confirm New Password:
            </td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtConfirm" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnChange" runat="server" 
                    Text="Change Password" onclick="btnChange_Click" />
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtConfirm" ControlToValidate="txtNewPassword" 
                    ErrorMessage="Passwords must match!" ForeColor="#34000D"></asp:CompareValidator>
            </td>
        </tr>
        <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
    </table>
</asp:Content>

