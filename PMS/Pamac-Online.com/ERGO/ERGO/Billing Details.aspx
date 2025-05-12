<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Billing Details.aspx.cs" Inherits="ERGO_ERGO_Billing_Details" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js">
    </script>
    <script language="javascript" type="text/javascript">

   
    </script>
    <table style="width: 100%">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="6">
                &nbsp; 
                Billing Data Report</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px">
                <strong>&nbsp;From Date</strong></td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox><img
                    id="ImgFromDt" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
            <td style="width: 125px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 31px">
                <strong>&nbsp;To Date</strong></td>
            <td class="Info" style="width: 100px; height: 31px">
                <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox><img
                    id="ImgToDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
            <td style="width: 125px; height: 31px">
            </td>
            <td style="height: 31px">
            </td>
            <td style="height: 31px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 31px">
                <strong>
                Type of Report</strong></td>
            <td class="Info" style="width: 100px; height: 31px">
                <asp:DropDownList ID="ddlReportSelection" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlReportSelection_SelectedIndexChanged" SkinID="ddlSkin">
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise_Null">--All--</asp:ListItem>
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise_BISPending">BIS Discrepancy</asp:ListItem>
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise_STCopyPending">ST - Copy Pending</asp:ListItem>
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise_Inv_Pending">ST - Invoice Pending</asp:ListItem>
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise_PanPending">PAN Pending</asp:ListItem>
                    <asp:ListItem Value="Get_BillingData_OkayCases">MaxMonth Bill Data</asp:ListItem>
              <%--       <asp:ListItem Value="Get_BillingData_OkayCasesRupesh">AllMonth Bill Data</asp:ListItem>--%>
                    <asp:ListItem Value="GetBilling_Report_MaxLotWise">Previouc Record</asp:ListItem>
                    <asp:ListItem Value="Sp_ErgoBISReport">BIS DATA</asp:ListItem>
                    <asp:ListItem Value="Get_InvoiceProcessData_New">STInvoice Pending After Billing</asp:ListItem>
                   
                    
                    
                </asp:DropDownList></td>
            <td style="width: 125px; height: 31px">
            </td>
            <td style="height: 31px">
            </td>
            <td style="height: 31px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 17px; font-weight: 700;" class="reportTitleIncome">
                &nbsp;<asp:Button ID="btnRetrive" runat="server" OnClick="btnRetrive_Click" 
                    Text="Export to Excel" SkinID="btn" />
                &nbsp;
                <asp:Button ID="btnGetReport" runat="server" OnClick="btnGetReport_Click" 
                    Text="Generate" SkinID="btn" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="53px" 
                    onclick="btnClear_Click" SkinID="btn" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="btn" /></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 146px">
                <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="true" width="100%">
                    <tr>
                        <td style="height: 13px">
                            <asp:GridView ID="GridView1" runat="server" SkinID="gridviewNoSort">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 26px" class="reportTitleIncome">
                &nbsp;&nbsp;
                &nbsp;
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 125px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>

</asp:Content>

