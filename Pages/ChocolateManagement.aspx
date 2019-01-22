<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="ChocolateManagement.aspx.cs" Inherits="Pages_ChocolateManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="LinkbtnDelete" runat="server" onclick="LinkbtnDelete_Click">Delete Unused Images</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" 
        PostBackUrl="~/Pages/ChocolateAdd.aspx">Add new Chocolate Product</asp:LinkButton>
    <h3> Available chocolate: </h3>
    <p> 
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="id" DataSourceID="sds_chocolate" ForeColor="#333333" 
            GridLines="None" Width="1256px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
                <asp:BoundField DataField="description" HeaderText="description" 
                    SortExpression="description" />
                <asp:BoundField DataField="weight" HeaderText="weight" 
                    SortExpression="weight" />
                <asp:BoundField DataField="dimensions" HeaderText="dimensions" 
                    SortExpression="dimensions" />
                <asp:BoundField DataField="ingredients" HeaderText="ingredients" 
                    SortExpression="ingredients" />
                <asp:BoundField DataField="holiday" HeaderText="holiday" 
                    SortExpression="holiday" />
            </Columns>
            <EditRowStyle Width="1260px" Wrap="True" />
            <FooterStyle BackColor="#34000D" BorderColor="#34000D" Font-Bold="True" 
                ForeColor="White" />
            <HeaderStyle BackColor="#34000D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E9E9E9" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" 
                Height="30px" />
            <SortedAscendingCellStyle BackColor="#FFFFF8" />
            <SortedAscendingHeaderStyle BackColor="#34000D" ForeColor="White" />
            <SortedDescendingCellStyle BackColor="#FFFFF8" />
            <SortedDescendingHeaderStyle BackColor="#34000D" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="sds_chocolate" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionChocolate %>" 
            DeleteCommand="DELETE FROM [Chocolate] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [Chocolate] ([name], [type], [price], [image], [description], [weight], [dimensions], [ingredients], [holiday]) VALUES (@name, @type, @price, @image, @description, @weight, @dimensions, @ingredients, @holiday)" 
            SelectCommand="SELECT * FROM [Chocolate] ORDER BY [type], [holiday]" 
            UpdateCommand="UPDATE [Chocolate] SET [name] = @name, [type] = @type, [price] = @price, [image] = @image, [description] = @description, [weight] = @weight, [dimensions] = @dimensions, [ingredients] = @ingredients, [holiday] = @holiday WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="weight" Type="Double" />
                <asp:Parameter Name="dimensions" Type="String" />
                <asp:Parameter Name="ingredients" Type="String" />
                <asp:Parameter Name="holiday" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="type" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="weight" Type="Double" />
                <asp:Parameter Name="dimensions" Type="String" />
                <asp:Parameter Name="ingredients" Type="String" />
                <asp:Parameter Name="holiday" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
</p>
</asp:Content>

