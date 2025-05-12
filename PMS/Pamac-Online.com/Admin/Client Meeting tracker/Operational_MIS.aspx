<%@ Page Language="C#" MasterPageFile="~/Admin/Client Operational Call or  Visit Tracker/MasterPage.master" Title="Untitled Page" StylesheetTheme="SkinFile" AutoEventWireup="true" CodeFile="Operational_MIS.aspx.cs" Inherits="Admin_Operational_call_visit_Review_tracker_Operational_MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js">
    </script>

    <table style="width: 115px">

        <tr>
            <td class="tta" colspan="8" style="height: 19px; width: 100%;">
                <span style="font-size: 10pt">MIS - Client Meeting Tracker&nbsp;</span></td>
        </tr>


        <tr>
            <td colspan="7">&nbsp;<asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red"
                SkinID="lblErrorMsg"></asp:Label>
                <asp:Panel ID="PnlExport" runat="server" Width="880px">
                    <table style="width: 991px; height: 96px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 100px; height: 21px">
                                <asp:Label ID="lblfromdate" runat="server" Text=" From Date" Font-Bold="True" Height="21px" SkinID="lblSkin" Width="100px"></asp:Label></td>
                            <td class="Info" style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100px" SkinID="txtSkin" ValidationGroup="VLD"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                            <td class="reportTitleIncome" style="width: 100px; height: 21px">
                                <asp:Label ID="lbltodate" runat="server" Text="To Date" Font-Bold="True" Height="21px" SkinID="lblSkin" Width="100px"></asp:Label></td>
                            <td class="Info" style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" SkinID="txtSkin" ValidationGroup="VLD"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                            <td style="width: 100px; height: 21px">
                                <asp:RequiredFieldValidator ID="RFVFromdate" runat="server" ControlToValidate="txtFromDate"
                                    ErrorMessage="Please Enter From Date" ValidationGroup="VLD" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <%--<td class="reportTitleIncome" style="width: 100px; height: 21px">&nbsp;<asp:Label ID="lblclntname" runat="server" Font-Bold="True" Height="21px" SkinID="lblSkin"
                                Text="Client Name" Width="100px"></asp:Label></td>
                            <td class="Info" style="width: 100px; height: 21px">
                                <asp:DropDownList ID="DdlSearchClient" runat="server" SkinID="ddlSkin" Width="123px">
                                </asp:DropDownList></td>--%>
                             <td class="reportTitleIncome" style="width: 173px; height: 21px">
                                <asp:Label ID="lblVH" runat="server" Text="DCH / VH Name" ></asp:Label></td>
                            <td class="Info" style="width: 231px; height: 21px">
                                <asp:DropDownList ID="ddlVH" runat="server" SkinID="ddlSkin" Width="123px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Sachin Tirlotkar</asp:ListItem>
                                    <asp:ListItem>Prithvi Joshi </asp:ListItem>
                                    <asp:ListItem>Mahendra Jadhav</asp:ListItem>
                                    <asp:ListItem>Pramod Patil</asp:ListItem>
                                    <asp:ListItem>Zakir Hussain</asp:ListItem>
                                    <asp:ListItem>Maulik Tikariya</asp:ListItem>
                                    <asp:ListItem>Abhijeet Mirtra </asp:ListItem>
                                    <asp:ListItem>Bulu Sahu</asp:ListItem>
                                    <asp:ListItem>Shankar Kamath</asp:ListItem>
                                    <asp:ListItem>Ragavan Rajagopalan</asp:ListItem>
                                    <asp:ListItem>Sansar Chand</asp:ListItem>
                                    <asp:ListItem>Murugan Odiyar</asp:ListItem>
                                    <asp:ListItem>Rajesh Patel</asp:ListItem>
                                    <asp:ListItem>Sameer Kudalkar</asp:ListItem>
									<asp:ListItem>PRASAD DALVI</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 100px; height: 21px">
                                <asp:Label ID="lblvertical" runat="server" Font-Bold="True" Height="21px" SkinID="lblSkin"
                                    Text="Vertical" Width="100px"></asp:Label></td>
                            <td class="Info" style="width: 100px; height: 21px">
                                <asp:DropDownList ID="DDLVerticalsearch" runat="server" SkinID="ddlSkin" TabIndex="6"
                                    ValidationGroup="GRPADD" Width="123px">
                                    <asp:ListItem Value="ALL">--ALL--</asp:ListItem>
                                    <asp:ListItem>PCPV</asp:ListItem>
                                    <asp:ListItem>PCPA</asp:ListItem>
                                    <asp:ListItem>PTPU</asp:ListItem>
                                    <asp:ListItem>PDCR</asp:ListItem>
                                    <asp:ListItem>PCRU</asp:ListItem>
                                    <asp:ListItem>EBC</asp:ListItem>
                                    <asp:ListItem>RCU</asp:ListItem>
                                    <asp:ListItem>DCR</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 21px"></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 26px">
                                <asp:Button ID="BtnFind" runat="server" SkinID="btnSearchSkin" Text="FIND" Width="100px" ValidationGroup="VLD" Height="24px" OnClick="BtnFind_Click" /><asp:Button ID="BtnExportToExel" runat="server" SkinID="btnExpToExlSkin" Text="Export to Excel"
                                    Width="131px" ValidationGroup="VLDGRP" Height="24px" OnClick="BtnExportToExel_Click" />&nbsp;
                                <asp:Button ID="BTReset" runat="server" SkinID="btnResetSkin" Text="RESET" Width="100px" Height="24px" OnClick="BTReset_Click" /></td>
                            <td style="width: 100px; height: 26px">
                                <asp:RequiredFieldValidator ID="RFVToDate" runat="server" ControlToValidate="txtToDate"
                                    ErrorMessage="Please Enter To Date" ValidationGroup="VLD" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 152px">
                <asp:Panel ID="PnlGrid" runat="server" Height="250px" Width="780px" ScrollBars="Both">
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="false" AllowSorting="false"
                        AutoGenerateColumns="true" SkinID="gridviewSkin" Width="100px">
                    </asp:GridView>
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableViewState="False"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="VLD" />
                &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>

        <tr>
            <td style="width: 100px; height: 45px;"></td>
            <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HidnVisit_call_No" runat="server" />
            </td>
            <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td style="width: 100px; height: 45px;">
                <asp:HiddenField ID="HDNUPDATE" runat="server" />
            </td>
            <td style="width: 100px; height: 45px;"></td>
            <td style="width: 100px; height: 45px;"></td>
            <td style="width: 73px; height: 45px;">
                <asp:Label ID="lblUID" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"
                    Width="46px"></asp:Label></td>
        </tr>
    </table>

</asp:Content>
