<%@ Page Language="C#" MasterPageFile="~/ISO/ISO Mandatory Registers/MasterPage.master" AutoEventWireup="true" CodeFile="MIS Report.aspx.cs" Inherits="ISO_ISO_Mandatory_Registers_MIS_Report" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
    <table style="width: 983px">
        <tr>
            <td colspan="6" style="font-size: 10pt; height: 25px;" class="tta">
                Consolidated DRCR &amp; TR Tracker</td>
        </tr>
        <tr>
            <td colspan="6" style="height: 16px">
                <asp:Label ID="Lblmessage" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 126px">
                <asp:Panel ID="PnlExport" runat="server">
                    <table id="TABLE1"  style="width: 683px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 65px; height: 30px">
                                From Date</td>
                            <td class="Info" style="width: 32px; height: 30px">
                                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="75px" ValidationGroup="vldGrp"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.gif" /></td>
                            <td class="reportTitleIncome" style="width: 38px; height: 30px">
                                To Date</td>
                            <td class="Info" style="width: 75px; height: 30px">
                                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="74px" ValidationGroup="vldGrp"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.gif" /></td>
                            <td style="width: 48px; height: 30px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                                    ErrorMessage="Please Insert From Date" ValidationGroup="vldGrp" ForeColor="White">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                                    ErrorMessage="Please Insert To Dade" ValidationGroup="vldGrp" ForeColor="White">*</asp:RequiredFieldValidator></td>
                            <td style="width: 50px; height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td class="tta" colspan="4">
                                &nbsp;
                                <asp:Button ID="BTNFIND" runat="server"  SkinID="btnSearchSkin"
                                    Text="Find" Width="100px" ValidationGroup="vldGrp" OnClick="BTNFIND_Click" />&nbsp;
                                <asp:Button ID="BTNCancel" runat="server" SkinID="btnCancelSkin"
                                    Text="Cancel" Width="100px" OnClick="BTNCancel_Click"  /></td>
                            <td style="width: 48px; height: 32px;">
                            </td>
                            <td style="width: 50px; height: 32px;">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 144px">
                &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="vldGrp" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 111px">
            </td>
            <td style="width: 108px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 84px">
            </td>
            <td style="width: 77px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 111px">
            </td>
            <td style="width: 108px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 84px">
            </td>
            <td style="width: 77px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            <td style="width: 111px">
            </td>
            <td style="width: 108px">
            </td>
            <td style="width: 103px">
            </td>
            <td style="width: 84px">
            </td>
            <td style="width: 77px">
            </td>
        </tr>
    </table>
</asp:Content>
