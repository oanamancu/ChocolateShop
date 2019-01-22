<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="Pages_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h3>Add new Admin</h3>
    <table cellspacing="15" class="chocolateTable1">
       <tr>
          <td style="width: 157px">

              Name:</td>
          <td>

              <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtName" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>

          </td>
       </tr>
       <tr>
          <td style="width: 157px; height: 47px">

              Password:</td>
          <td style="height: 47px">

              <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
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
          <td style="width: 157px">

              Confirm Password:</td>
          <td>

              <asp:TextBox ID="txtConfirm" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtConfirm" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>

          </td>
       </tr>
       <tr>
          <td style="width: 157px">

              E-mail Address:</td>
          <td>

              <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Not a valid e-mail address!" 
                    ForeColor="#34000D" 
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)"></asp:RegularExpressionValidator>

          </td>
       </tr>
       <tr>
          <td style="width: 157px">

              User Type:</td>
          <td>

              <asp:DropDownList ID="ddUserType" runat="server" Height="20px" 
                  style="margin-left: 0px" Width="200px">
                  <asp:ListItem>admin</asp:ListItem>
                  <asp:ListItem>root_admin</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                  ControlToValidate="ddUserType" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>

          </td>
       </tr>
        <tr>
            <td>
               <br />
                <asp:Button ID="btnRegister" runat="server" Text="Create" 
                    onclick="btnRegister_Click" Width="66px" />
            </td>
            <td>
               <br />
               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtConfirm" ControlToValidate="txtPassword" 
               ErrorMessage="Passwords must match!" ForeColor="#34000D"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
              <asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>
        </tr>
    </table>
</asp:Content>

