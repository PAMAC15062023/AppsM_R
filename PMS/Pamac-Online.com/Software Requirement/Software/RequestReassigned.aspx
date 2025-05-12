<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master"
    AutoEventWireup="true" CodeFile="RequestReassigned.aspx.cs" Inherits="Software_Requirement_Software_RequestReassigned"
    Title="Untitled Page" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

    <asp:Panel ID="Panel1" runat="server">
        <br />
        <br />
        <br />
        <table style="width: 748px">
            <tr>
                <td colspan="8" class="tta">
                    Reassign &nbsp;Ticket
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 142px; height: 19px">
                    <strong>Ticket No :-</strong></td>
                <td class="Info" style="width: 212px; height: 19px">
                    <asp:TextBox ID="txtTicketNo" runat="server" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTicketNo" runat="server" ControlToValidate="txtTicketNo"
                        ValidationGroup="AB" ErrorMessage="Enter Ticket No" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
                <td class="reportTitleIncome" style="width: 100px; height: 19px">
                </td>
                <td class="Info" style="width: 101px; height: 19px">
                </td>
                <td style="width: 161px; height: 19px" class="reportTitleIncome">
                    &nbsp;
                </td>
                <td style="width: 100px; height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="height: 21px;" colspan="8">
                    <asp:Button ID="btnSearch" runat="server" Height="23px" SkinID="btn" Text="Search"
                        Width="121px" OnClick="btnSearch_Click" ValidationGroup="AB" />&nbsp;
                    <asp:Button ID="btnReset" runat="server" Height="23px" SkinID="btn" Text="Reset"
                        Width="121px" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Width="907px">
        <table>
            <tr>
                <td class="tta" colspan="8">
                    Assignment Details</td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="lblReassignedAlter" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>Employee Code</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">
                    &nbsp;<asp:Label ID="lblEmpCode" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Ticket No</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblTicketNumber" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>First Name</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">
                    &nbsp;<asp:Label ID="lblFrstName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Last Name</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblLastName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 22px;">
                    <strong>Centre Name</strong></td>
                <td class="Info" style="width: 234px; height: 22px;">
                    <asp:Label ID="LblCentreName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Approved Status</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblApprovedStatus" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px">
                    <strong>Problem</strong></td>
                <td class="Info" style="width: 234px">
                    <asp:Label ID="lblProblem" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px" class="reportTitleIncome">
                    <strong>Suggestion</strong></td>
                <td style="width: 278px" class="Info">
                    <asp:Label ID="lblSuggestion" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Request Date</strong></td>
                <td class="Info" style="width: 234px; height: 23px">
                    <asp:Label ID="lblRequestDate" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 23px" class="reportTitleIncome">
                    <strong>To be required till date</strong></td>
                <td style="width: 278px; height: 23px" class="Info">
                    <asp:Label ID="lblToberequiredtilldate" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>New Requirement/Error</strong></td>
                <td class="Info" style="height: 23px" colspan="3">
                    <asp:Label ID="lblreqtype" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Application</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lblApplication" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Priority</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lblpriority" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Implemented At</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lblimplementedat" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>Currently Assigned To</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">
                    &nbsp;<asp:Label ID="lblCurrentlyAssignedTo" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Current Status</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblCurrentStatus" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Due Date</strong></td>
                <td class="Info" style="width: 234px; height: 23px">
                    <asp:Label ID="lblDueDate" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 23px" class="reportTitleIncome">
                    <strong>Expected Date</strong></td>
                <td style="width: 278px; height: 25px" class="Info">
                    <asp:TextBox ID="txtExpectedDate" runat="server" SkinID="txtSkin" ValidationGroup="grpSearch"
                        Width="100px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtExpectedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" />
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td style="width: 249px; height: 21px;" class="reportTitleIncome">
                    <span style="font-size: 8pt; color: #000000; font-family: Tahoma; background-color: #e1e9ff;">
                        <strong>Remark :-</strong></span></td>
                <td colspan="3" style="height: 21px" class="Info">
                    <br />
                    <br />
                    <asp:TextBox ID="txtlRemark" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                        Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtlRemark"
                        ValidationGroup="AB" ErrorMessage="Enter Remark" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <br />
                    <strong>Reassign To</strong>
                    <br />
                    <br />
                </td>
                <td class="Info" colspan="3" style="height: 21px">
                    <asp:DropDownList ID="ddlassignedto" runat="server" SkinID="ddlSkin" Width="180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="re1" runat="Server" InitialValue="0" ControlToValidate="ddlassignedto"
                        ErrorMessage="Please Select Some One" ValidationGroup="AB" ForeColor="Red" />
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px;" class="Info" colspan="4" align="center">
                    <br />
                    <br />
                    <asp:Button ID="btnReAssigned" runat="server" Text="Reassign" SkinID="btn" Width="100px"
                        OnClick="btnReAssigned_Click" ValidationGroup="AB" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnBack2" runat="server" SkinID="btnBackSkin" Text="Back" Width="100px"
                        OnClick="btnBack2_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="BtnReset2" runat="server" Text="Reset" SkinID="btn" Width="100px"
                        OnClick="BtnReset2_Click" />
                </td>
                <td style="width: 100px; height: 21px;">
                    &nbsp;</td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HFTicketNo" runat="server" />
                    <asp:HiddenField ID="HFRequestedDate" runat="server" />
                    <asp:HiddenField ID="HFExpectedDate" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
