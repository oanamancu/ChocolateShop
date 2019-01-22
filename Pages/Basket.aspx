<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="Pages_Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnOrder" runat="server" Text="Confirm" Visible="False" 
        onclick="btnOrder_Click" style="margin-bottom: 0px"
         />
    &nbsp;
    <br />
    <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:TextBox ID="txtAddress" Visible="False" runat="server" Height="39px" TextMode="MultiLine" 
        Width="282px">Please do not write your real address as this is not a real Web Shop!</asp:TextBox>
    <br />
    <asp:Button ID="btnOk" runat="server" Text="Ok" Visible="False" Width="100px" onclick="btnOk_Click" 
         />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" 
        Width="100px" onclick="btnCancel_Click"  />
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="#990033"></asp:Label>
    <asp:Panel ID="pnlProducts" runat="server">
    </asp:Panel>
    <br />
</asp:Content>

