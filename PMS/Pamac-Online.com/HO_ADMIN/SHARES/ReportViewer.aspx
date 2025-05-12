<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportViewer.aspx.cs" Inherits="HO_ADMIN_SHARES_ReportViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Report View</title>
    <link href="../../StyleSheet_EBC.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 532px">
            <tr>
                <td style="width: 100px" class="tta">
                    <table>
                        <tr>
                            <td style="width: 100px; height: 34px;">
                                <asp:ImageButton ID="imgPrevious" runat="server" ImageUrl="~/Images/8.png" OnClick="imgPrevious_Click" /></td>
                            <td style="width: 100px; height: 34px;">
                                <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/Images/7.png" OnClick="imgNext_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center">
                    <iframe id="IFrame1" runat="server" frameborder="0" style="width: 512px; height: 414px"></iframe>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center; height: 21px;">
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
