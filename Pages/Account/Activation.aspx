<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Activation.aspx.cs" Inherits="Pages_Account_Activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:Label ID="lblResult" runat="server" ForeColor="#34000D"></asp:Label>

    <br />
    <br />
    <asp:LinkButton ID="lBtnCodeRequest" runat="server" 
        onclick="lBtnCodeRequest_Click">Request another activation link</asp:LinkButton>
    <br />

</asp:Content>

