<%@ Page Language="C#" MasterPageFile="~/Admin/QMS/MasterPage.master" AutoEventWireup="true" CodeFile="TicketAssignment.aspx.cs" Inherits="Admin_QMS_TicketAssignment" Title="Untitled Page" Theme="SkinFile" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

<table style="width: 338px">
    <tr>
        <td id="TD5" runat="server" colspan="6" style="width: 120px; height: 16px;">
            <asp:Label ID="lblMessage" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="650px"></asp:Label></td>
    </tr>
    <tr>
        <td id="Td1" runat="server" class="tta" colspan="6">
            Requested Ticket Assignment</td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 82px">
            <strong>Ticket No.</strong></td>
        <td class="Info" style="width: 11px">
            <asp:TextBox ID="txtTicketNo" runat="server" SkinID="txtSkin" Width="170px"></asp:TextBox></td>
        <td class="reportTitleIncome" style="width: 8px">
            <strong>
            Department</strong></td>
        <td class="Info" style="width: 11px">
            <asp:TextBox ID="txtDepartment" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        <td class="reportTitleIncome">
            <strong>Request By</strong></td>
        <td class="Info" style="width: 23px">
            <asp:TextBox ID="txtRequestBy" runat="server" SkinID="txtSkin" Width="170px"></asp:TextBox></td>
    </tr>

    <tr>
        <td class="reportTitleIncome" style="width: 82px;">
            <strong>Centre</strong></td>
        <td class="Info" style="width: 11px;">
            <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin" Width="177px">
            </asp:DropDownList></td>
        <td class="reportTitleIncome" style="width: 8px;">
            <strong>Promblem Type</strong></td>
        <td class="Info" style="width: 11px;">
            <asp:DropDownList ID="ddlProblemTypeList" runat="server" SkinID="ddlSkin" Width="300px" >
            </asp:DropDownList></td>
        <td class="reportTitleIncome">
            <strong>Assigned By</strong></td>
        <td class="Info" style="width: 23px;">
            <asp:DropDownList ID="ddlAssignedBy" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 82px">
            <strong>Request From</strong></td>
        <td class="Info" style="width: 11px">
            <asp:TextBox ID="txtRequestFromDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox><img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" style="width: 18px; height: 18px" /></td>
        <td class="reportTitleIncome" style="width: 8px">
            <strong>Request To</strong></td>
        <td class="Info" style="width: 11px">
            <asp:TextBox ID="txtRequestToDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox><img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" style="width: 18px; height: 18px" /></td>
        <td class="reportTitleIncome">
            <strong>Assigned To</strong></td>
        <td class="Info" style="width: 23px">
            <asp:DropDownList ID="ddlAssignedTo" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 82px">
            <strong>Ticket Status</strong></td>
        <td class="Info" colspan="5" style="width: 120px">
        <asp:DropDownList ID="ddlTicketStatus" runat="server" SkinID="ddlSkin" Width="172px">
            <asp:ListItem>Open</asp:ListItem>
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Close</asp:ListItem>
            <asp:ListItem Value="FollowUp">FollowUp</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    
    <tr>
        <td class="Info" colspan="6">
            <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" />&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="Reset" Width="53px" SkinID="btnResetSkin" OnClick="btnReset_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="64px" SkinID="btnCancelSkin" OnClick="btnCancel_Click" />
            <asp:Button ID="btnExport" runat="server" Text="Export" Width="65px" SkinID="btnExportSkin" Visible="False" OnClick="btnExport_Click" /></td>
    </tr>
    <tr>
        <td class="tta" colspan="6" style="height: 27px">
            Requested Ticket Search Details</td>
    </tr>
    <tr>
        <td colspan="6" >
            <div style="overflow: scroll; width: 998px; height: 220px">
                <asp:GridView ID="grv_TicketList" runat="server" AutoGenerateColumns="False" OnRowDataBound="grv_TicketList_RowDataBound" Font-Overline="False" Font-Size="7.5pt" CssClass="mGrid" SkinID="gridviewNoSort">
                    <Columns>
                        <asp:TemplateField HeaderText="TicketNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TicketNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTicketNo" runat="server" OnClick="lnkTicketNo_Click" Text='<%# (DataBinder.Eval(Container.DataItem,"TicketNo")) %>' Width="170px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:BoundField DataField="Centre_Name" HeaderText="CentreName" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                        <asp:BoundField DataField="Department" HeaderText="Department" />
                        <asp:BoundField DataField="problem_detail" HeaderText="ProblemDetail" />
                        <asp:TemplateField HeaderText="Remark">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' ToolTip='<%# Bind("RemarkComplete") %>' Width="189px"></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" />
                        <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                        <asp:BoundField DataField="TicketCloseDate" HeaderText="TicketCloseDate" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                    <tr>
                                        <td style="width: 100px">
                                            <img alt="Down" src="../../Images/Download.JPG" /></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"DownloadFilePath"))%>'
                                               OnClick="lnkDownloadFile_Click" ToolTip="Click to Download Attach Documents">Download</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </div>
            <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true" width="100%">
                <tr>
                    <td style="height: 207px">
                    <div style="overflow: scroll; width: 995px; height: 220px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort" Width="455px">
                        <Columns>
                            <asp:BoundField DataField="TicketNo" HeaderText="TicketNo" />                           
                            <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" />
                            <asp:BoundField DataField="Centre_Name" HeaderText="CentreName" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="problem_detail" HeaderText="ProblemDetail" />
                            <asp:BoundField DataField="RemarkComplete" HeaderText="Remark" />
                            <asp:BoundField DataField="UpdateRemark" HeaderText="UpdateRemark" />
                            <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" />
                            <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                            <asp:BoundField DataField="TicketCloseDate" HeaderText="TicketCloseDate" />
                      </Columns>   
                      </asp:GridView>
                      </div>
                    </td>
                </tr>
            </table>
    </td>
    </tr>

</table>


</asp:Content>