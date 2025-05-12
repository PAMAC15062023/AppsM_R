<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master"
    AutoEventWireup="true" CodeFile="Assets_InventoryReport.aspx.cs" Inherits="Admin_Assets_Inventory_Assets_InventoryReport"
    Title="Assets Inventory Report" StylesheetTheme="SkinFile" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

    <script language="javascript" type="text/javascript">

function funValidateFromToDate()
{
    debugger;
    var strFromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //===split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

    //==Converting the string to date format
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);

    //declareing the date variable
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();
    //setTime 
    date1.setTime(dtFromDate.getTime());
    date2.setTime(dtToDate.getTime());
    var add_one_day = date2.getTime()+(1000 * 60 * 60 * 24);
    diff.setTime(Math.floor(add_one_day-date1.getTime()));
    var dateDiff = diff.getTime();
    
    if (parseInt(dateDiff) <= 0 )
    {
         alert("To Date should not be less then From Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  
    </script>

    <table>
        <tr>
            <td class="tta" colspan="7">
                <span style="font-size: 10pt">Assets Inventory Report</span></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Crimson"
                    SkinID="lblError"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 144px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 144px; height: 16px;">
            </td>
            <td style="height: 16px;">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Center Name</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlCenterList" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px">
                Subcentre Name</td>
            <%--<td colspan="2">
                &nbsp; &nbsp;&nbsp;</td>--%>
            <td colspan="1" class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlsubcentrelist" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 31px;">
            </td>
            <td style="width: 100px; height: 31px;" class="reportTitleIncome">
                From Date</td>
            <td style="width: 100px; height: 31px;" class="Info">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" ValidationGroup="grpSearch"
                    Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 31px;">
                To Date</td>
            <td class="Info" style="width: 100px; height: 31px;">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" ValidationGroup="grpSearch"
                    Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td style="height: 31px;">
            </td>
            <td style="width: 100px; height: 31px;">
            </td>
            <td style="width: 100px; height: 31px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Select Report</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="DdlSp" runat="server" SkinID="ddlSkin" Width="190px" OnSelectedIndexChanged="DdlSp_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="Get_AssetsInventoryReport">AssetsCount</asp:ListItem>
                    <asp:ListItem Value="Get_AssetsMISOwnedRented">AssetsOwnedRented</asp:ListItem>
                    <asp:ListItem Value="Get_AssetsInventoryReport_BranchWise2">Count MIS</asp:ListItem>
                    <asp:ListItem Value="Count_pc_own_Rented">Count MISOwnedRented</asp:ListItem>
                    <asp:ListItem Value="SP_AssetsDescriptoin12">AssetsDescriptionReport</asp:ListItem>
                    <asp:ListItem Value="SummaryMIS_ForAssets">All Zone Summary MIS</asp:ListItem>
                    <asp:ListItem Value="Sp_GetAssetsTransferReport">Assets Transfer Report</asp:ListItem>
                    <asp:ListItem Value="Sp_GetAssetsTransferReportSCrap">Assets Scrap/Sold Report</asp:ListItem>
                    <asp:ListItem Value="Sp_EMpAssetsTransfr">Assets Transfer Pending</asp:ListItem>
                    <asp:ListItem Value="Get_AssetsInventoryReport_scan">Assets barcode  scaning </asp:ListItem>
                    <asp:ListItem Value="Get_AssetsInventoryReportTotal">Total AssetsCount</asp:ListItem>
                    <asp:ListItem Value="PC">PC Asset MIS</asp:ListItem>
                    <asp:ListItem Value="Assets Status Report">Assets Status Report</asp:ListItem>
					<asp:ListItem Value="ALLZone_AssetsBarcodeScaningReport">All Assets Barcode Scaning Report</asp:ListItem>
                    <asp:ListItem Value="SP_Assets_Descriptoin_All_URL_Report">All Zone Assets Description</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px">
                Report PC</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlreportpc" runat="server" SkinID="ddlSkin" Width="190px">
                    <asp:ListItem Value="SP_AssetsDescriptoinForPC">AssetsDescriptionReport</asp:ListItem>
                    <asp:ListItem Value="SummaryMIS_ForAssets">All Zone Summary MIS</asp:ListItem>
                    <asp:ListItem Value="Sp_GetAssetsTransferReport_PC">Assets Transfer Report</asp:ListItem>
                    <asp:ListItem Value="Sp_GetAssetsTransferReportSCrap_All">Assets Scrap/Sold Report</asp:ListItem>
					
                  
                </asp:DropDownList></td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px;">
            </td>
            <td style="height: 16px;" class="tta" colspan="5">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btn"
                    Text="Search" ValidationGroup="grpSearch" />
                <asp:Button ID="btnCan" runat="server" OnClick="btnCan_Click" SkinID="btn" Text="Cancel" /></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px">
            </td>
            <td colspan="5" rowspan="3">
                <asp:Panel ID="Panel1" runat="server" Height="236px" ScrollBars="Both" Width="1300px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="1px" Width="79%"
                        SkinID="gridviewNoSort">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </asp:Panel>
                <br />
            </td>
            <td colspan="1" style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 45px">
            </td>
            <td style="width: 100px; height: 45px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px">
            </td>
            <td style="height: 16px" class="tta" colspan="5">
                <asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" SkinID="btn"
                    Text="Export To Excel" Visible="False" Height="21px" Width="117px" /></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
                <asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtFromDate"
                    Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True"
                    ValidationGroup="grpSearch"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                        ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None"
                        ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="revFromDateSearch" runat="server" ControlToValidate="txtFromDate" Display="None"
                            ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpSearch"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                ID="revToDateSearch" runat="server" ControlToValidate="txtToDate" Display="None"
                                ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="grpSearch"></asp:RegularExpressionValidator><asp:ValidationSummary
                                    ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="grpSearch" />
            </td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="height: 22px; width: 144px;">
            </td>
            <td style="height: 22px;">
            </td>
            <td style="width: 100px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 144px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 144px; height: 16px;">
            </td>
            <td style="height: 16px;">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
    </table>
</asp:Content>
