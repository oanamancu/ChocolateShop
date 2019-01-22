<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="ChocolateAdd.aspx.cs" Inherits="Pages_ChocolateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h3>Add new Chocolate Product</h3>
   <table cellspacing="15" class="chocolateTable1">
      <tr>
         <td style="width: 122px">
             <b>Name:</b></td>
         <td>
             <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="txtName" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Type:</b></td>
         <td>
             <asp:DropDownList ID="ddType" runat="server" Width="300px">
                 <asp:ListItem>Tablet</asp:ListItem>
                 <asp:ListItem>Gift Box</asp:ListItem>
                 <asp:ListItem>Pralines</asp:ListItem>
                 <asp:ListItem>Seasonal</asp:ListItem>
             </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="ddType" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Price:</b></td>
         <td>
             <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
         &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 ControlToValidate="txtPrice" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                 ControlToValidate="txtPrice" ErrorMessage="Please insert numbers only!" 
                 ValidationExpression="[0-9]*\.?[0-9]+" ForeColor="#34000D"></asp:RegularExpressionValidator>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Description:</b></td>
         <td>
             <asp:TextBox ID="txtDescription" runat="server" Height="50px" 
                 TextMode="MultiLine" Width="300px"></asp:TextBox>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Dimensions:</b></td>
         <td>
             <b>
             <asp:TextBox ID="txtDimensions" runat="server" Width="300px"></asp:TextBox>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Weight:</b></td>
         <td>
             <asp:TextBox ID="txtWeight" runat="server" Width="300px"></asp:TextBox>
         &nbsp;
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                 ControlToValidate="txtWeight" 
                 ErrorMessage="Please leave it empty or insert numbers only!" 
                 ForeColor="#34000D" ValidationExpression="([0-9]*\.?[0-9]+)|(^$)"></asp:RegularExpressionValidator>
         </td>
      </tr>
       <tr>
         <td style="width: 122px">
             <b>Ingredients:</b></td>
         <td>
             <asp:TextBox ID="txtIngredients" runat="server" Height="45px" 
                 TextMode="MultiLine" Width="300px"></asp:TextBox>
         </td>
      </tr>
      <tr>
         <td style="width: 122px">
             <b>Holiday:</b></td>
         <td>
             <asp:DropDownList ID="ddHoliday" runat="server" Width="300px">
                 <asp:ListItem>Christmas</asp:ListItem>
                 <asp:ListItem>Valentine&#39;s Day</asp:ListItem>
                 <asp:ListItem>Easter</asp:ListItem>
                 <asp:ListItem>none</asp:ListItem>
             </asp:DropDownList>
         </td>
      </tr>
      <tr>
         <td style="width: 122px">
             <b>Image:</b></td>
         <td>
             <asp:DropDownList ID="ddImage" runat="server" Width="300px">
             </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                 ControlToValidate="ddImage" ErrorMessage="*" ForeColor="#34000D"></asp:RequiredFieldValidator>
             <br />
             <asp:FileUpload ID="FileUpload1" runat="server" style="margin-top:4px" />
             <br />
             <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" 
                 onclick="btnUploadImage_Click" CausesValidation="False" style="margin-top:4px" />
         </td>
         
      </tr>
   </table>

   <div>
   <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
   </div>
   <div style="margin-top:20px">
   <asp:Button ID="btnSave" runat="server" Text="Save" Width="147px" 
        onclick="btnSave_Click" CausesValidation="False" />
   </div>
</asp:Content>

