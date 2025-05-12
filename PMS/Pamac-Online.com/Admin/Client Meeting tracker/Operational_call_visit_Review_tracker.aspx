<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Client Meeting tracker/MasterPage.master" AutoEventWireup="true" CodeFile="Operational_call_visit_Review_tracker.aspx.cs" Inherits="Admin_Client_Meeting_tracker_Operational_call_visit_Review_tracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../popcalendar.js">
    </script>


    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 8pt;
        }

        .GridPager a, .GridPager span {
            display: block;
            height: 10px;
            width: 10px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #0c0c99;
            color: #000;
            border: 1px solid #3AC0F2;
        }
    </style>


    <table style="width: 160px">
        <tr>
            <td class="tta" colspan="8" style="height: 19px; width: 97%;">
                <span style="font-size: 10pt">Client Meeting Tracker&nbsp;</span></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="PnlInsert" runat="server">
                    <table style="width: 1004px">
                        <tr>
                            <td style="height: 21px;" colspan="6">
                                <span>
                                    <asp:Label ID="lblmessage" runat="server" SkinID="lblErrorMsg" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 195px">Date</td>
                            <td class="Info" style="width: 205px">
                                <asp:TextBox ID="txtdate" runat="server" Width="70px" SkinID="txtSkin" ValidationGroup="VLDGRP" TabIndex="1"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                            <td class="reportTitleIncome" style="width: 173px">Centre</td>
                            <td class="Info" style="width: 231px">
                                <asp:DropDownList ID="ddlbranch" runat="server" SkinID="ddlSkin" Width="123px">
                                </asp:DropDownList></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate"
                                    ErrorMessage="Please Insert Date" ValidationGroup="VLDGRP" ForeColor="White">*</asp:RequiredFieldValidator></td>
                            <td>
                                <asp:RequiredFieldValidator ID="Rfvbranch" runat="server" ControlToValidate="ddlbranch"
                                    ErrorMessage="Please Select Branch" ValidationGroup="VLDGRP" ForeColor="White" InitialValue="0">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 195px;" class="reportTitleIncome">Client</td>
                            <td style="width: 205px;" class="Info">
                                <asp:DropDownList ID="ddlclient" runat="server" Width="123px" SkinID="ddlSkin" ValidationGroup="VLDGRP" TabIndex="2">
                                </asp:DropDownList></td>
                            <td style="width: 173px;" class="reportTitleIncome">Meeting</td>
                            <td style="width: 231px;" class="Info">
                                <asp:DropDownList ID="ddlvisitcall" runat="server" Width="123px" SkinID="ddlSkin" ValidationGroup="VLDGRP" TabIndex="3" AutoPostBack="True">
                                    <asp:ListItem>Meeting</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RfvDDlclint" runat="server" ControlToValidate="ddlclient"
                                    ErrorMessage="Please Select Client Name" ValidationGroup="VLDGRP" ForeColor="White" InitialValue="0">*</asp:RequiredFieldValidator></td>
                            <td style="width: 43px;">
                                <asp:RequiredFieldValidator ID="Rfvvistcal" runat="server" ControlToValidate="ddlvisitcall"
                                    ErrorMessage="Please Select Meeting" ValidationGroup="VLDGRP" ForeColor="White" InitialValue="0">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="height: 20px; width: 195px;" class="reportTitleIncome">Name of the officials</td>
                            <td style="height: 20px; width: 205px;" class="Info">
                                <asp:TextBox ID="txtname" runat="server" Width="123px" SkinID="txtSkin" ValidationGroup="VLDGRP" TabIndex="4"></asp:TextBox></td>
                            <td style="height: 20px; width: 173px;" class="reportTitleIncome">Time Spent(hh:mm)</td>
                            <td style="height: 20px; width: 231px;" class="Info">
                                <asp:TextBox ID="txtTime" runat="server" Width="123px" SkinID="txtSkin" ValidationGroup="VLDGRP" TabIndex="5"></asp:TextBox></td>
                            <td style="height: 20px;">
                                <asp:RequiredFieldValidator ID="RfvName" runat="server" ControlToValidate="txtname"
                                    ErrorMessage="Please Insert Name Of Officiels" ValidationGroup="VLDGRP" ForeColor="White">*</asp:RequiredFieldValidator></td>
                            <td style="height: 20px; width: 43px;">
                                <asp:RequiredFieldValidator ID="RfvTimespent" runat="server" ControlToValidate="txtTime"
                                    ErrorMessage="Please Select TimeSpent" ValidationGroup="VLDGRP" ForeColor="White">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="height: 21px; width: 195px;">Vertical</td>
                            <td class="Info" style="height: 21px; width: 205px;">
                                <asp:DropDownList ID="ddlvertical" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="VLDGRP" TabIndex="6">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>PCPV</asp:ListItem>
                                    <asp:ListItem>PCPA</asp:ListItem>
                                    <asp:ListItem>PTPU</asp:ListItem>
                                    <asp:ListItem>PDCR</asp:ListItem>
                                    <asp:ListItem>PCRU</asp:ListItem>
                                    <asp:ListItem>EBC</asp:ListItem>
                                    <asp:ListItem>RCU</asp:ListItem>
                                    <asp:ListItem>DCR</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 173px; height: 21px">
                                <asp:Label ID="lblVH" runat="server" Text="DCH / VH Name" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 231px; height: 21px">
                                <asp:DropDownList ID="ddlVH" runat="server" SkinID="ddlSkin" Visible="False" Width="123px">
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
                            <td style="height: 21px;">
                                <asp:RequiredFieldValidator ID="RfvVertical" runat="server" ControlToValidate="ddlvertical"
                                    ErrorMessage="Please Select Vertical Name" ValidationGroup="VLDGRP" ForeColor="White" InitialValue="0">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 173px; height: 21px">
                                <asp:Label ID="lblVenue" runat="server" Text="Venue"></asp:Label></td>
                            <td class="Info" style="width: 231px; height: 21px">
                                <asp:TextBox ID="txtVenue" runat="server" Width="123px" SkinID="txtSkin" ValidationGroup="VLDGRP" TabIndex="4"></asp:TextBox>
                            </td>
                            <td class="reportTitleIncome" style="width: 195px; height: 21px"></td>
                            <td class="Info" style="width: 205px; height: 21px"></td>

                        </tr>
                       <%-- <tr>
                            <td class="reportTitleIncome" style="width: 195px; height: 21px">
                                <asp:Label ID="lblDCH" runat="server" Text="DCH / VH" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 205px; height: 21px">
                                <asp:DropDownList ID="ddlDCH" runat="server" SkinID="ddlSkin" Visible="False" Width="125px">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>VAS DCH</asp:ListItem>
                                    <asp:ListItem>Central CPV DCH</asp:ListItem>
                                    <asp:ListItem>Central CPA DCH</asp:ListItem>
                                    <asp:ListItem>M&amp;G</asp:ListItem>
                                    <asp:ListItem>MP</asp:ListItem>
                                    <asp:ListItem>Gujarat</asp:ListItem>
                                    <asp:ListItem>East</asp:ListItem>
                                    <asp:ListItem>KTK</asp:ListItem>
                                    <asp:ListItem>AP</asp:ListItem>
                                    <asp:ListItem>South</asp:ListItem>
                                    <asp:ListItem>Rest of Delhi</asp:ListItem>
                                    <asp:ListItem>ROTN</asp:ListItem>
                                    <asp:ListItem>Delhi</asp:ListItem>
                                    <asp:ListItem>PCPV Vertical</asp:ListItem>
                                    <asp:ListItem>PCPA Vertical</asp:ListItem>
                                    <asp:ListItem>VAS Vertical</asp:ListItem>

                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="height: 21px; width: 173px;">Activity</td>
                            <td class="Info" style="height: 21px; width: 231px;">
                                <asp:DropDownList ID="ddlActivity" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="VLDGRP" TabIndex="7">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Income Dox Verification</asp:ListItem>
                                    <asp:ListItem>CPV</asp:ListItem>
                                    <asp:ListItem>KYC</asp:ListItem>
                                    <asp:ListItem>File Processing</asp:ListItem>
                                    <asp:ListItem>PD</asp:ListItem>
                                    <asp:ListItem>EBC</asp:ListItem>
                                    <asp:ListItem>Mystery Shopping</asp:ListItem>
                                    <asp:ListItem>Recon</asp:ListItem>
                                    <asp:ListItem>Cheque Processing</asp:ListItem>
                                    <asp:ListItem>Document Collection</asp:ListItem>
                                </asp:DropDownList></td>

                            <td style="height: 21px; width: 43px;">
                                <asp:RequiredFieldValidator ID="RfvActivity" runat="server" ControlToValidate="ddlActivity"
                                    ErrorMessage="Please Select Activity Name" ValidationGroup="VLDGRP" ForeColor="White" InitialValue="0">*</asp:RequiredFieldValidator></td>
                            <td style="height: 21px"></td>
                            <td style="width: 43px; height: 21px"></td>
                        </tr>--%>

                        <tr>
                            <td align="left" colspan="4">&nbsp;<asp:Button ID="BtnSave" runat="server" Text="SAVE" OnClick="BtnSave_Click" SkinID="btnSaveSkin" Width="114px" ValidationGroup="VLDGRP" TabIndex="14" Height="27px" Font-Bold="True" />
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                            <td>
                                <asp:CompareValidator ID="CMPVCloseDate" runat="server" ControlToCompare="txtdatecomm"
                                    ControlToValidate="txtclosedate" ErrorMessage="Close Date Should Be Greater Than Committed Date"
                                    ForeColor="White" Type="Date" ValidationGroup="VlDS" Height="5px" Operator="GreaterThan" Width="1px">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Panel ID="pnlRemark" runat="server">
                                    <table style="width: 892px">
                                        <tr>
                                            <td style="width: 44px; height: 15px" class="reportTitleIncome">&nbsp;Point &nbsp;Discussed</td>
                                            <td style="width: 87px; height: 15px" class="reportTitleIncome">&nbsp;Action Required
                                            </td>
                                            <td style="width: 125px; height: 15px" class="reportTitleIncome">&nbsp;Date Committed
                                            </td>
                                            <td style="width: 88px; height: 15px" class="reportTitleIncome">&nbsp;Status Postn Commitment</td>
                                            <td style="width: 103px; height: 15px" class="reportTitleIncome">Date Close</td>
                                            <td style="width: 41px;" class="reportTitleIncome" rowspan="2">
                                                <br />
                                                <br />
                                                <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" SkinID="btnSaveSkin"
                                                    Text="ADD" Width="100px" Height="24px" TabIndex="13" ValidationGroup="GRPADD" /><br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 44px;" class="Info">
                                                <asp:TextBox ID="txtpoint1" runat="server" SkinID="txtSkin" Width="151px" ValidationGroup="GRPADD" TextMode="MultiLine" TabIndex="8" Height="35px"></asp:TextBox></td>
                                            <td style="width: 87px;" class="Info">
                                                <asp:DropDownList ID="ddlactnreq" runat="server" Width="100px" SkinID="ddlSkin" ValidationGroup="GRPADD" TabIndex="9" OnSelectedIndexChanged="ddlactnreq_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="Sp_opeartional_Call_Remark_inser">Yes</asp:ListItem>
                                                    <asp:ListItem Value="Sp_Operational_Call_Remark_inser_ActionNO">No</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td style="width: 125px;" class="Info">
                                                <asp:TextBox ID="txtdatecomm" runat="server" SkinID="txtSkin"
                                                    Width="70px" TabIndex="10"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdatecomm.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                                        src="../../Images/SmallCalendar.png" /></td>
                                            <td style="width: 88px;" class="Info">
                                                <asp:TextBox ID="txtstatuspostn" runat="server" SkinID="txtSkin" Width="100px" ValidationGroup="VlDS" TabIndex="11" Enabled="False"></asp:TextBox></td>
                                            <td style="width: 103px;" class="Info">
                                                <asp:TextBox ID="txtclosedate" runat="server" SkinID="txtSkin" Width="70px" ValidationGroup="VlDS" TabIndex="12" Enabled="False"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtclosedate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                                    src="../../Images/SmallCalendar.png" /></td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GV_Visit_Call_Points" HeaderStyle-BackColor="#c8d0e7" HeaderStyle-ForeColor="#0606a3"
                                        RowStyle-BackColor="#c8d0e7" runat="server" AutoGenerateColumns="false" Width="893px">
                                        <Columns>
                                            <asp:BoundField DataField="PointsDiscussed" HeaderText="Points Discussed" ItemStyle-Width="150px" />
                                            <asp:BoundField DataField="ActionRequired" HeaderText="Action Required" ItemStyle-Width="100px" />
                                            <asp:BoundField DataField="DateCommitted" HeaderText="Date Committed" ItemStyle-Width="100px" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="100px" />
                                            <asp:BoundField DataField="CloseDate" HeaderText="Close Date" ItemStyle-Width="100px" />
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                                    </asp:GridView>


                                </asp:Panel>
                                <asp:Button ID="BtnDone" runat="server" Text="DONE" SkinID="btnSubmitSkin" Width="100px" OnClick="BtnDone_Click" TabIndex="18" Height="24px" />&nbsp;
                                <asp:Button
                                    ID="BtnCancel" runat="server" Height="24px" OnClick="BtnCancel_Click" SkinID="btnCancelSkin"
                                    Text="CANCEL" Width="100px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstatuspostn"
                                    ErrorMessage="Please Enter Status Position Commitment" ForeColor="White" ValidationGroup="VlDS">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtclosedate"
                                    ErrorMessage="Please Enter Closing Date" ForeColor="White" ValidationGroup="VlDS">*</asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="RFVactionReq" runat="server" ControlToValidate="ddlactnreq"
                                    ErrorMessage="Please Select Action Required" ForeColor="White" InitialValue="0" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVpntdis" runat="server" ControlToValidate="txtpoint1"
                                    ErrorMessage="Please Enter Point Discussed" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7">&nbsp;&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableViewState="False"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="VLDGRP" />
                &nbsp;
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" EnableViewState="False"
                    ShowMessageBox="True" ValidationGroup="VlDS" ShowSummary="False" />
                &nbsp;
                <asp:ValidationSummary ID="VLDsumADD" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="GRPADD" />
            </td>
        </tr>

        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px">
                <asp:HiddenField ID="HidnVisit_call_No" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HDNUPDATE" runat="server" />
            </td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 44px">
                <asp:Label ID="lblUID" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"
                    Width="46px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

