<%@ Page Language="C#" MasterPageFile="~/QMS/QMS/masterpage.master" AutoEventWireup="true"
    CodeFile="QMSAssignedTo.aspx.cs" Inherits="QMS_QMS_QMSAssignedTo" Title="Untitled Page" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

    <table  style="width: 816px;border-color:Navy" frame="border" >
        <tbody>
            <tr>
                <td style="width: 120px; height: 16px" id="TD5" colspan="6" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Width="650px">
                      
                    </asp:Label></td>
            </tr>
            <tr>
             
                <td class="tta" colspan="6"  style="width: 900px; background-color:ActiveBorder; border-color:Navy; height: 35px;">
               <%--  id="Td1" class="tta" colspan="6" runat="server" style="width: 700px; height: 17px; background-color:ActiveBorder; border-color:Navy">--%>
                  <span style="font-size:20pt">Requested Ticket Assignment</span>  </td>
            </tr>
            <tr>
                <td style="width: 253px; height: 26px;" class="reportTitleIncome">
                   <strong> <span style="font-size: 12pt;">Ticket No.</span></strong>
                  </td>
                <td style="width: 12px; height: 26px;" class="Info">
                    <asp:TextBox ID="txtTicketNo" runat="server" Width="170px" SkinID="txtSkin"></asp:TextBox></td>
                <%--<td class="reportTitleIncome" style="width: 8px">
            <strong>
            Department</strong></td>
        <td class="Info" style="width: 11px">
            <asp:TextBox ID="txtDepartment" runat="server" SkinID="txtSkin"></asp:TextBox></td>--%>
                <%--<td class="reportTitleIncome">
            <strong>Request By</strong></td>
        <td class="Info" style="width: 23px">
            <asp:TextBox ID="txtRequestBy" runat="server" SkinID="txtSkin" Width="170px"></asp:TextBox></td>--%>
            </tr>
            <tr>
                <td style="width: 253px; height: 40px;" class="reportTitleIncome">
                   <strong> <span style="font-size: 12pt;">Hub</span></strong>
                   </td>
                  
                <td style="width: 12px; height: 40px;" class="Info">
                    <asp:DropDownList ID="ddlBranchList" runat="server" Width="177px" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td style="width: 31px; height: 40px;" class="reportTitleIncome">
                <strong><span style="font-size: 12pt;">Promblem Type</span></strong>
               </td>
                <td style="width: 11px; height: 40px;" class="Info">
                    <asp:DropDownList ID="ddlProblemTypeList" runat="server" Width="282px" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="height: 40px">
                       <strong><span style="font-size: 12pt;">Request By</span></strong>
               </td>
                <td style="width: 19px; height: 40px;" class="Info">
                    <asp:DropDownList ID="ddlAssignedBy" runat="server" SkinID="ddlSkin">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 253px; height: 44px;" class="reportTitleIncome">
             
                       <strong> <span style="font-size: 12pt;">Request From Date</span></strong>
                    </td>
                <td style="width: 12px; height: 44px;" class="Info">
                    <asp:TextBox ID="txtRequestFromDate" runat="server" Width="167px" SkinID="txtSkin"></asp:TextBox><img
                        style="width: 18px; height: 18px" id="Img2" onclick="popUpCalendar(this, document.all.<%=txtRequestFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        alt="Calendar" src="../../Images/SmallCalendar.png" /></td>
                <td style="width: 31px; height: 44px;" class="reportTitleIncome">
                     <strong><span style="font-size: 12pt;">Request To Date</span></strong>
                    </td>
                <td style="width: 11px; height: 44px;" class="Info">
                    <asp:TextBox ID="txtRequestToDate" runat="server" Width="172px" SkinID="txtSkin"></asp:TextBox><img
                        style="width: 18px; height: 18px" id="Img1" onclick="popUpCalendar(this, document.all.<%=txtRequestToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        alt="Calendar" src="../../Images/SmallCalendar.png" /></td>
               <%-- <td class="reportTitleIncome">
                    <strong>Assigned To</strong></td>--%>
                <td style="width: 29px; height: 44px;" class="Info">
                    <asp:DropDownList ID="ddlAssignedTo" runat="server" SkinID="ddlSkin" Visible="false">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 253px; height: 39px;" class="reportTitleIncome">
                     <strong><span style="font-size: 12pt;">Ticket Status</span></strong>
               </td>
                <td style="width: 13px; height: 39px;" class="Info" colspan="4">
                    <asp:DropDownList ID="ddlTicketStatus" runat="server" Width="177px" SkinID="ddlSkin">
                        <asp:ListItem>Open</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Close</asp:ListItem>
                    </asp:DropDownList></td>
                  
            </tr>
            <tr>
                <td class="tta" colspan="6" style="Width:900px; border-color:Gray; border-width:inherit; height: 34px;">
                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" SkinID="btnSearchSkin"
                        Text="Search" Height="30px" width="60px"></asp:Button>&nbsp;
                    <asp:Button ID="btnReset" OnClick="btnReset_Click" runat="server" SkinID="btnResetSkin"
                        Text="Reset" Height="30px" width="60px"></asp:Button>
                    <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" 
                        SkinID="btnCancelSkin" Text="Cancel" Height="30px" width="60px"></asp:Button>
                    <asp:Button ID="btnExport" OnClick="btnExport_Click" runat="server"
                        SkinID="btnExportSkin" Text="Export" Visible="False" Height="30px" width="60px"></asp:Button></td>
            </tr>
            <tr>
            
                <td  class="tta" colspan="6"  style="width:900px; background-color:ActiveBorder; border-color:Navy">
                   <span style="font-size:20pt">Requested Ticket Search Details</span> </td>
            </tr>
            <tr>
                <td colspan="6">
                    <div style="overflow: scroll; width: 998px; height: 220px">
                        <asp:GridView ID="grv_TicketList" runat="server" Width="593px" SkinID="gridviewNoSort"
                            Font-Overline="False" OnRowDataBound="grv_TicketList_RowDataBound" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="TicketNo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TicketNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkTicketNo" runat="server" OnClick="lnkTicketNo_Click" Text='<%# (DataBinder.Eval(Container.DataItem,"TicketNo")) %>'
                                            Width="170px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Centre_Name" HeaderText="Hub"></asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="FOS Name"></asp:BoundField>
                                <asp:BoundField DataField="problem_detail" HeaderText="ProblemDetail"></asp:BoundField>
                                <asp:TemplateField HeaderText="Remark">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' ToolTip='<%# Bind("RemarkComplete") %>'
                                            Width="189px"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="RequestDate" HeaderText="RequestDate"></asp:BoundField>
                                <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus"></asp:BoundField>
                                <asp:BoundField DataField="TicketCloseDate" HeaderText="TicketCloseDate"></asp:BoundField>
                                <asp:BoundField DataField="QMS_Remark" HeaderText="QMS_Remark" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                            <tr>
                                                <td style="width: 100px">
                                                    <img alt="Down" src="../../Images/down.jpeg" height="25px"/><%--src="../../Images/Download.JPG"--%>
                                                </td>
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
                
                <table id="tbExport" cellspacing="1" cellpadding="0" width="100%" border="1" runat="server"
                    visible="true">
                    <tbody>
                        <tr>
                            <td style="height: 207px">
                                <div style="overflow: scroll; width: 995px; height: 220px">
                                    <asp:GridView ID="GridView1" runat="server" Width="455px" SkinID="gridviewNoSort"
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="TicketNo" HeaderText="TicketNo" />
                                            <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" />
                                            <asp:BoundField DataField="Centre_Name" HeaderText="CentreName" />
                                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                           <%-- <asp:BoundField DataField="Department" HeaderText="Department" />--%>
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
                    </tbody>
                </table>
                </td>
            </tr>
        </tbody>
    </table>
  
</asp:Content>
