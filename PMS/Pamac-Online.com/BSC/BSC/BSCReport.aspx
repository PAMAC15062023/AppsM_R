<%@ Page Language="C#" MasterPageFile="~/BSC/BSC/MasterPage.master" AutoEventWireup="true"
    CodeFile="BSCReport.aspx.cs" Inherits="BSC_BSC_BSCReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <table width="100%">
        <tr>
            <td colspan="5" style="width: 92px; height: 10px;">
                <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"
                    ForeColor="Crimson" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 92px; height: 31px;">
                From Date :
            </td>
            <td class="Info" style="width: 228px; height: 31px;">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="100px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]
            </td>
            <td class="reportTitleIncome" style="width: 92px; height: 31px;">
                To Date :
            </td>
            <td class="Info" style="width: 228px; height: 31px;">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="100px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]
            </td>
            <td style="height: 31px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 92px; height: 21px;">
                Client Name :</td>
            <td class="Info" style="width: 228px; height: 21px;">
                <asp:DropDownList ID="ddlClientName" runat="server" SkinID="ddlSkin" Width="120px">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="reportTitleIncome" style="width: 92px; height: 21px;">
                Select Report :</td>
            <td class="Info" style="width: 228px; height: 21px;">
                <asp:DropDownList ID="ddlReport" runat="server" SkinID="ddlSkin" Width="120px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="BSC_ForReport">BSC Tracker</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btn" OnClick="btnSearch_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 92px; height: 21px;">
                <asp:Button ID="btnExport" runat="server" Text="Export" SkinID="btn" OnClick="btnExport_Click" />
            </td>
            <td class="Info" style="width: 228px; height: 21px;">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btn" OnClick="btnCancel_Click" />
            </td>
            <td class="reportTitleIncome" style="width: 92px; height: 21px;">
            </td>
            <td class="Info" style="width: 228px; height: 21px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="width: 92px; height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" colspan="4" style="width: 92px; height: 21px;">
                <asp:Panel ID="pnlExport" runat="server" Height="284px" ScrollBars="Both" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
