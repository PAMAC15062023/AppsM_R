<%@ Page Language="C#" MasterPageFile="~/PAMAC HOME OFFICE/PAMAC HOME OFFICE/MasterPage.master" AutoEventWireup="true" Theme="SkinFile" StylesheetTheme="SkinFile" CodeFile="FTP_ReviewReport.aspx.cs" Inherits="FTP_FTP_Dynamic_FTP_ReviewReport" Title="FTP Review Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table  border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td style="height: 354px">
<fieldset>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table id="tblExport" align="center" width="100%" style="height: 312px">
            <tr>
                <td class="topbar" colspan="12">
                    &nbsp;FTP Review Report</td>
            </tr>
            <tr>
                <td colspan="7">
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" SkinID="lblErrorMsg" Font-Bold="True" Font-Size="9pt" Width="468px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                    <span style="color: #ff0033">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="165px" SkinID="ddlSkin">
                            <asp:ListItem Value="FTP_ReviewReportWeek">Weekly Report</asp:ListItem>
                            <asp:ListItem Value="FTP_ReviewReportMonth">Monthly Report</asp:ListItem>
                            <asp:ListItem Value="FTP_ReviewReportTreemonthMonth">Quarterly Report</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click1" SkinID="btn" /></span></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="100%" Height="178px">
                        <asp:GridView ID="GridView1" runat="server" Width="851px" Height="31px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <RowStyle ForeColor="#000066" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                        <asp:Button ID="btnExportExcel" runat="server" Font-Bold="True" Text="Export To Excel" OnClick="btnExportExcel_Click" SkinID="btnExportSkin" />&nbsp;<asp:Button
                            ID="btnCancel" runat="server" Height="19px" OnClick="btnCancel_Click" SkinID="btnCancelSkin"
                            Text="Cancel" /></td>
            </tr>
        </table>
    &nbsp; &nbsp; &nbsp;
    

                   
        </fieldset>
        </td></tr></table>
</asp:Content>

