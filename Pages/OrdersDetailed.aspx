<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="OrdersDetailed.aspx.cs" Inherits="Pages_OrdersDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataSourceID="sds_ordersDetailed" ForeColor="#333333" GridLines="None" 
        style="margin-right: 717px" Width="1256px" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="product" HeaderText="product" 
                SortExpression="product" />
            <asp:BoundField DataField="amount" HeaderText="amount" ReadOnly="True" 
                SortExpression="amount" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:CheckBoxField DataField="orderShipped" HeaderText="orderShipped" 
                SortExpression="orderShipped" />
            <asp:BoundField DataField="total" HeaderText="total" ReadOnly="True" 
                SortExpression="total" />
            <asp:BoundField DataField="deliveryAddress" HeaderText="deliveryAddress" 
                SortExpression="deliveryAddress" />
        </Columns>
        <EditRowStyle Width="1260px" />
        <FooterStyle BackColor="#34000D" BorderColor="#34000D" ForeColor="White" />
        <HeaderStyle BackColor="#34000D" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E9E9E9" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Height="30px" />
        <SortedAscendingCellStyle BackColor="#FFFFF8" />
        <SortedAscendingHeaderStyle BackColor="#34000D" ForeColor="White" />
        <SortedDescendingCellStyle BackColor="#FFFFF8" />
        <SortedDescendingHeaderStyle BackColor="#34000D" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="sds_ordersDetailed" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionChocolate %>" SelectCommand="SELECT  product, SUM(amount) AS amount, price, orderShipped, SUM(amount * price) AS total,  deliveryAddress 
FROM orders
WHERE clientName = @client AND date = @date AND orderShipped= @shipped
GROUP BY product, price, orderShipped,deliveryAddress
">
        <SelectParameters>
            <asp:QueryStringParameter Name="client" QueryStringField="client" />
            <asp:QueryStringParameter DbType="Date" Name="date" QueryStringField="date" />
            <asp:QueryStringParameter Name="shipped" QueryStringField="shipped" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Button ID="btnShip" runat="server" onclick="btnShip_Click" 
        Text="Ship Order" />
</asp:Content>

