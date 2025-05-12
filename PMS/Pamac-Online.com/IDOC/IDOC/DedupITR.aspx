<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DedupITR.aspx.cs" Inherits="IDOC_IDOC_DedupITR" StylesheetTheme="SkinFile"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>DedupITR Search</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width ="100%">
            <tr>
                <td align="center" >
                    <strong><span style="font-family:Frutiger 47LightCn,Arial ">&nbsp;ITR Dedup Search</span></strong></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" style="height: 21px">
                    &nbsp;<asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td >
                    &nbsp;<asp:GridView ID="gvDedup" runat="server" SkinID="gridviewNoSort">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export" SkinID="btnExportSkin" Width="81px" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
