<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="Pages_Account_EditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center">
    <asp:LinkButton ID="lBtnChangePassword" runat="server" 
            onclick="lBtnChangePassword_Click">Change Password</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="lBtnDelete" runat="server" onclick="lBtnDelete_Click">Delete Account</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
    </div>
</asp:Content>

