<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Pages_Orders" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="900px">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>Open Orders</HeaderTemplate>
            <ContentTemplate>Show orders between: <asp:TextBox ID="txtOpenOrders1" runat="server" AutoPostBack="True" autocomplete = "Off"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtOpenOrders1_CalendarExtender" 
                    runat="server" TargetControlID="txtOpenOrders1" 
                     Enabled="True" />&nbsp;and <asp:TextBox ID="txtOpenOrders2" runat="server" AutoPostBack="True" autocomplete = "Off"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtOpenOrders2_CalendarExtender" 
                    runat="server" TargetControlID="txtOpenOrders2" Enabled="True"
                /><br /><br /><asp:Label ID="lblOpenOrders" runat="server"></asp:Label><br /></ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>Closed Orders</HeaderTemplate>
            <ContentTemplate>Show orders between: <asp:TextBox ID="txtClosedOrders1" runat="server" AutoPostBack="True" autocomplete = "Off"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtClosedOrders1_CalendarExtender" 
                    runat="server" BehaviorID="_content_txtOpenOrders1_CalendarExtender" 
                    TargetControlID="txtClosedOrders1" />&nbsp;and <asp:TextBox ID="txtClosedOrders2" runat="server" AutoPostBack="True" autocomplete = "Off"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtClosedOrders2_CalendarExtender" 
                    runat="server" BehaviorID="_content_txtOpenOrders2_CalendarExtender" 
                    TargetControlID="txtClosedOrders2" /><br /><br /><asp:Label ID="lblClosedOrders" runat="server"></asp:Label></ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>Analytics</HeaderTemplate>
            <ContentTemplate><ajaxToolkit:LineChart ID="LineChart1" runat="server" 
                    ValueAxisLines="0" AreaDataLabel="" BaseLineColor="" BorderStyle="None" 
                    CategoriesAxis="" CategoryAxisLineColor="" ChartTitle="" ChartTitleColor="" 
                    Theme="" TooltipBackgroundColor="" TooltipBorderColor="" TooltipFontColor="" 
                    ValueAxisLineColor="" styele="border-style: none; border-width: 0px;" BorderWidth="0"></ajaxToolkit:LineChart>
                    <br />
                    <ajaxToolkit:LineChart 
                    ID="LineChart2" runat="server" AreaDataLabel="" BaseLineColor="" 
                    BorderColor="White" BorderStyle="None" CategoriesAxis="" 
                    CategoryAxisLineColor="" ChartTitle="" ChartTitleColor="" Theme="" 
                    TooltipBackgroundColor="" TooltipBorderColor="" TooltipFontColor="" 
                    ValueAxisLineColor="" ValueAxisLines="0"></ajaxToolkit:LineChart></ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>


