<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BGC_GenerateLabel.aspx.cs" Inherits="BGC_BGC_BGC_GenerateLabel" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <link href="../../StyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body class="BODY">
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        <table id ="table1"  runat = "server"></table>
        <asp:Table ID="tblLabel"   runat="server" Width="612px">
        </asp:Table>
        &nbsp;&nbsp;
        <asp:Label ID="lblMsg" runat="server" Width="203px"></asp:Label>
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </form>
</body>
</html>
