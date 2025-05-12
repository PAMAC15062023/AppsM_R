<%@ Page Language="C#" MasterPageFile="~/ISO/ISO Mandatory Registers/MasterPage.master" AutoEventWireup="true" CodeFile="Tracker.aspx.cs" Inherits="ISO_ISO_Mandatory_Registers_Tracker" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
    <table style="width: 947px">
        <tr>
            <td colspan="6" style="font-size: 10pt; height: 25px;" class="tta">
                &nbsp;MIS REPORT</td>
        </tr>
        <tr>
            <td colspan="6" style="height: 20px">
                <asp:Label ID="Lblmessage" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="PnlExport" runat="server" Visible="False">
                    <table id="TABLE1"  style="width: 771px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 65px; height: 30px">
                                From Date</td>
                            <td class="Info" style="width: 24px; height: 22px">
                                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="75px" ValidationGroup="vldGrp"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.gif" /></td>
                            <td class="reportTitleIncome" style="width: 44px; height: 30px">
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
                                <asp:Button ID="BtnExprtExl" runat="server" OnClick="BtnExprtExl_Click" SkinID="btnExpToExlSkin"
                                    Text="Export To Exel" Width="100px" />&nbsp;
                                <asp:Button ID="BTNFIND" runat="server" OnClick="BTNFIND_Click" SkinID="btnSearchSkin"
                                    Text="Find" Width="100px" ValidationGroup="vldGrp" />&nbsp;
                                <asp:Button ID="BTNCancel" runat="server" SkinID="btnCancelSkin"
                                    Text="Cancel" Width="100px" OnClick="BTNCancel_Click" /></td>
                            <td style="width: 48px">
                            </td>
                            <td style="width: 50px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 144px">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="280px" Width="750px">
                    <asp:GridView ID="GrdvwReport" runat="server" SkinID="gridviewNoSort" Width="730px">
                    </asp:GridView>
                </asp:Panel>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
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
    </table>
</asp:Content>

