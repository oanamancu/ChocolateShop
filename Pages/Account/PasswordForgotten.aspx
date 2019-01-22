<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="PasswordForgotten.aspx.cs" Inherits="Pages_Account_PasswordForgotten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="4" cellspacing="4">
        <tr>
            <td style="font-weight: 700">Name: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Button ID="btnChange" runat="server" 
                    Text="Change Password" onclick="btnChange_Click" />
            </td>
            <td>
             <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
          </td>
        </tr>
    </table>
</asp:Content>

