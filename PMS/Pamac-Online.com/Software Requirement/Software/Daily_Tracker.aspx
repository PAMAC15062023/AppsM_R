<%@ Page Title="" Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master" AutoEventWireup="true" CodeFile="Daily_Tracker.aspx.cs" Inherits="Software_Requirement_Software_Daily_Tracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
    <script type="text/javascript">
        function ValidateTime(obj) {
            var time_check = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            var txtNumber = obj.value;
            if (txtNumber.match(time_check)) {
                return true;
            }
            else {
                obj.value = '00:00';
                alert("Invalid Time");
                return false;
            }
        }
    </script>

    <asp:Panel ID="Panel2" runat="server" Width="907px">
        <table>
            <tr>
                <td class="tta" colspan="9">Daily Tracker</td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblReassignedAlter" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 214px; height: 23px" class="reportTitleIncome">
                    <strong>Track Date</strong></td>
                <td style="width: 278px; height: 25px" class="Info" colspan="4">
                    <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"
                        Width="100px"></asp:TextBox>
                    <%--  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" />--%>
                </td>

                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <br />
                    <strong>Reason For Delay</strong>
                </td>
                <td class="Info" colspan="1" style="height: 21px">
                    <asp:TextBox ID="txtResionForDelay" runat="server" Height="30px" SkinID="txtSkin" TextMode="MultiLine"
                        Width="450px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Width="907px">
        <table>
            <tr>
                <td class="tta" colspan="9">Details</td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 19px"><strong>Select&nbsp;Ticket&nbsp;No</strong></td>
                <td class="Info" style="width: 101px; height: 19px">
                    <asp:DropDownList ID="ddlTicketNo" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlTicketNo_SelectedIndexChanged"
                        AutoPostBack="true" Width="100px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTicketNo" runat="Server" InitialValue="0" ControlToValidate="ddlTicketNo"
                        ErrorMessage="Please Select At Least One Ticket" ValidationGroup="AB" ForeColor="Red" />
                </td>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>Date of Original Entry</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">&nbsp;
                 <asp:Label ID="lblDateofOriginalEntry" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>Application</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">&nbsp;
                    <asp:Label ID="lblApplication" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
            </tr>

            <tr>

                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Priority</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblPriority" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>

                <td class="reportTitleIncome" style="width: 249px; height: 22px;">
                    <strong>Raised By</strong></td>
                <td class="Info" style="width: 234px; height: 22px;">
                    <asp:Label ID="lblRaisedBy" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Problem</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblProblem" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px">
                    <strong>Suggestion</strong></td>
                <td class="Info" style="width: 234px" colspan="3">
                    <asp:Label ID="lblSuggestion" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px" class="reportTitleIncome">
                    <strong>Due Date</strong></td>
                <td style="width: 278px" class="Info">
                    <asp:Label ID="lblDueDate" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
            </tr>
            <tr>

                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Current Status</strong></td>
                <td class="Info" style="width: 234px; height: 23px">
                    <asp:Label ID="lblCurrentStatus" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 23px" class="reportTitleIncome">
                    <strong>Estimated Development Time</strong></td>
                <td style="width: 278px; height: 23px" class="Info">
                    <asp:Label ID="lblEstimatedDevelopmentTime" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Actual Spent Time Till Now</strong></td>
                <td class="Info" style="height: 23px">
                    <asp:Label ID="lblActualSpentTime" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
            </tr>

            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <br />
                    <strong>Task or Activity Done Today</strong>
                    <br />
                    <br />
                </td>
                <td class="Info" colspan="5" style="height: 21px">
                    <asp:TextBox ID="txtTask" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                        Style="height: 62px; width: 724px; margin: 0px;" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 249px; height: 21px;" class="reportTitleIncome">
                    <span style="font-size: 8pt; color: #000000; font-family: Tahoma; background-color: #e1e9ff;">
                        <strong>Developer Remark</strong></span></td>
                <td colspan="5" style="height: 21px" class="Info">
                    <br />
                    <br />
                    <asp:TextBox ID="txtDeveloperRemark" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                        Style="height: 62px; width: 724px; margin: 0px;" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtDeveloperRemark"
                        ValidationGroup="AB" ErrorMessage="Enter Remark" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <br />
                    <strong>Time Spent H:MM</strong>
                </td>
                <td class="Info" style="width: 234px; height: 23px" colspan="2">
                    <asp:TextBox ID="txtTimeSpent" runat="server" Text="00:00" onblur="ValidateTime(this);"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Ticket Current Status</strong></td>
                <td class="Info" colspan="2" style="height: 21px">
                    <asp:DropDownList ID="ddlTicketCurrentStatus" runat="server">
                        <asp:ListItem Text="Pending" Value="Pending" />
                        <asp:ListItem Text="InProgress" Value="InProgress" />
                        <asp:ListItem Text="Sought For More Clarification" Value="Sought For More Clarification" />
                        <asp:ListItem Text="Sent For UAT" Value="Sent For UAT" />
                        <asp:ListItem Text="UAT Completed" Value="UAT Completed" />
                        <asp:ListItem Text="Resolved" Value="Resolved" />
                        <asp:ListItem Text="On Hold" Value="On Hold" />
                        <asp:ListItem Text="Closed" Value="Closed" />
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>

                <td style="height: 21px;" class="Info" colspan="4" align="center">
                    <br />
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" SkinID="btn" Width="100px" OnClick="btnAdd_Click" />
                    &nbsp; &nbsp;                     
                </td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <asp:GridView ID="gvdis" runat="server" Width="800px" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TicketNo" HeaderText="TicketNo" />
                        <asp:BoundField DataField="TrackDate" HeaderText="TrackDate" />
                        <asp:BoundField DataField="TaskToday" HeaderText="TaskToday" />
                        <asp:BoundField DataField="DeveloperRemark" HeaderText="DeveloperRemark" />
                        <asp:BoundField DataField="TimeSpent" HeaderText="TimeSpent" />
                        <asp:BoundField DataField="TicketCurrentStatus" HeaderText="TicketCurrentStatus" />
                        <asp:BoundField DataField="ResionForDelay" HeaderText="ResionForDelay" />
                    </Columns>
                </asp:GridView>
            </tr>
            <tr>
                <td style="height: 21px;" class="Info" colspan="4" align="center">
                    <br />
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btn" Width="100px" OnClick="btnSave_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnBack" runat="server" SkinID="btnBackSkin" Text="Back" Width="100px" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnReset2" runat="server" Text="Reset" SkinID="btn" Width="100px" />
                </td>
                <td style="width: 100px; height: 21px;">&nbsp;</td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
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

