<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Admins.aspx.cs" Inherits="Pages_Admins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:LinkButton ID="LinkButton1" runat="server" 
        PostBackUrl="~/Pages/AdminAdd.aspx">Add new admin</asp:LinkButton>

    <p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="id" DataSourceID="sdsAdmins" AllowPaging="True" 
    AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" 
        Width="584px">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
            ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="email" HeaderText="email" 
            SortExpression="email" />
        <asp:BoundField DataField="user_type" HeaderText="user_type" 
            SortExpression="user_type" />
    </Columns>
        <FooterStyle BackColor="#34000D" BorderColor="#34000D" ForeColor="White" />
        <HeaderStyle BackColor="#34000D" ForeColor="White" />
        <RowStyle BackColor="#E9E9E9" />
        <SortedAscendingCellStyle BackColor="#FFFFF8" />
        <SortedAscendingHeaderStyle BackColor="#34000D" ForeColor="White" />
        <SortedDescendingCellStyle BackColor="#FFFFF8" />
        <SortedDescendingHeaderStyle BackColor="#34000D" />
</asp:GridView>
<asp:SqlDataSource ID="sdsAdmins" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionChocolate %>" 
    DeleteCommand="DELETE FROM [Users] WHERE [id] = @id" 
    InsertCommand="INSERT INTO [Users] ([name], [email], [user_type]) VALUES (@name, @email, @user_type)" 
    SelectCommand="SELECT [name], [id], [email], [user_type] FROM [Users] WHERE ([user_type] LIKE '%' + @user_type + '%')" 
    
        
        UpdateCommand="UPDATE [Users] SET [name] = @name, [email] = @email, [user_type] = @user_type WHERE [id] = @id">
    <DeleteParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="name" Type="String" />
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="user_type" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:Parameter DefaultValue="%admin%" Name="user_type" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="name" Type="String" />
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="user_type" Type="String" />
        <asp:Parameter Name="id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
</p>

</asp:Content>

