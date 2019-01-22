<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.Master" AutoEventWireup="true" CodeFile="AllProducts.aspx.cs" Inherits="Pages_AllProducts" MaintainScrollPositionOnPostBack="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Button ID="btnSearch" runat="server" ForeColor="#34000D" 
        onclick="btnSearch_Click" Text="Search" />
&nbsp;&nbsp;
    <asp:TextBox ID="txtSearch" runat="server" ForeColor="#34000D"></asp:TextBox>
&nbsp;&nbsp;
    <br />
    <br />
  <asp:Panel ID="pnlProducts" runat="server">
  </asp:Panel>
</asp:Content>

