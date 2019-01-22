<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="SeasonalChocolate.aspx.cs" Inherits="Pages_SeasonalChocolate"  MaintainScrollPositionOnPostBack="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:Button ID="btnSearch" runat="server" ForeColor="#34000D" 
        onclick="btnSearch_Click" Text="Search" />
&nbsp;&nbsp;
    <asp:TextBox ID="txtSearch" runat="server" ForeColor="#34000D"></asp:TextBox>
&nbsp;&nbsp;
    <br />
    <br />
    <p>
    Select a holiday:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Easter</asp:ListItem>
        <asp:ListItem>Valentine&#39;s Day</asp:ListItem>
        <asp:ListItem>Christmas</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="sds_holiday" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionChocolate %>" 
        SelectCommand="SELECT DISTINCT holiday FROM Chocolate WHERE (holiday IS NOT NULL) ORDER BY holiday">
    </asp:SqlDataSource>
    <asp:Panel ID="pnlProducts" runat="server">
    </asp:Panel>
</p>
</asp:Content>

