<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="CPV_CC_Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#ffffcc">
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 72px"><tr>
    <td style="background-color: #996633; height: 65px;"><img src="../Images/Attendance_Icon_2.jpg" style="width: 79px; height: 70px" /></td>
    <td valign="bottom" align="left" style="background-color: #996633; height: 60px;"><asp:Label ID="lblHierarchy" runat="server" Font-Bold="true"></asp:Label></td>
    <td style="background-color: #996633; height: 65px;"><table border="0" cellpadding="0" cellspacing="0">
    <tr><td style="width: 97px; height: 14px;"><asp:Label ID="lblName" runat="server"></asp:Label></td></tr>
    <tr><td style="width: 97px"><asp:Label ID="lblDate" runat="server"></asp:Label></td></tr>
    <tr><td style="width: 97px; height: 14px" align="center"><a href="" target="_parent" style="color: white">[Change Password]</a></td></tr>
    <tr><td style="width: 97px; color: white; height: 14px" align="center"><a href="../Default.aspx" target="_parent" style="color: white">[Sign Out]</a></td></tr>
    <tr><td style="width: 97px; color: #663300; height: 14px" align="center"><a href="../OrganizationTree.aspx" target="_parent" style="color: white">[My TeamSpace]</a></td></tr>
    </table>
        </td>
    </tr></table>  
    </div>
    </form>
</body>
</html>
