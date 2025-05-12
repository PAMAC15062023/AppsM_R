<%@ Page Language="C#" MasterPageFile="~/Admin/QMS/MasterPage.master" AutoEventWireup="true" CodeFile="TicketStatus.aspx.cs" Inherits="Admin_QMS_TicketStatus" Title="Untitled Page" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" >
function Validate_UpdateStatus()
{
    var ReturnValue=true;            
    var ErrorMessage="";
    var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
    var ddlTicketStatus = document.getElementById("<%=ddlTicketStatus.ClientID%>");            
    var ddlAssignedTo = document.getElementById("<%=ddlAssignedTo.ClientID%>");            
    var txtUpdateRemark = document.getElementById("<%=txtUpdateRemark.ClientID%>");

    if (txtUpdateRemark.value == '')
    {
        ErrorMessage='Please Enter Remark.';
        ReturnValue=false;
        txtUpdateRemark.focus();
    }
    if((ddlTicketStatus.selectedIndex==0)||(ddlTicketStatus.selectedIndex==1))
    {
        ErrorMessage='Please Select Ticket Status to continue...';
        ReturnValue=false;
        ddlTicketStatus.focus();
    }

    if (ddlAssignedTo.selectedIndex == 0)
    {
        ErrorMessage='Please Select Assigned To.';
        ReturnValue=false;
        ddlAssignedTo.focus();
    }

    window.scroll(0,0);
    lblMessage.innerText=ErrorMessage;
    return ReturnValue;
}  
</script>

<table style="width: 700">
    <tr>
        <td colspan="4">
            <asp:Label ID="lblMessage" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td class="tta" colspan="4">Ticket Detail Info</td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px;">
            <strong>Ticket No.</strong></td>
        <td class="Info" style="width: 120px;">
            <asp:Label ID="lblTicketNo" runat="server" SkinID="lblSkin" Width="150px"></asp:Label></td>
        <td style="width: 120px;" class="reportTitleIncome">
            <strong>Ticket Raise Date</strong></td>
        <td style="width: 120px;" class="Info">
            <asp:Label ID="lblTicketRaiseDate" runat="server" SkinID="lblSkin" Width="150px"></asp:Label></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px;">
            <strong>Ticket Raise By</strong></td>
        <td class="Info" style="width: 120px;">
            <asp:Label ID="lblUserName" runat="server" SkinID="lblSkin" Width="150px"></asp:Label></td>
        <td style="width: 120px;" class="reportTitleIncome">
            <strong>Centre</strong></td>
        <td style="width: 120px;" class="Info">
            <asp:Label ID="lblBranch" runat="server" SkinID="lblSkin" Width="150px"></asp:Label></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px">
            <strong>Department</strong></td>
        <td class="Info" colspan="3" style="width: 120px">
            <asp:Label ID="lblDepartment" runat="server" SkinID="lblSkin" Width="160px"></asp:Label></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px">
            <strong>Problem Description</strong></td>
        <td class="Info" colspan="3" style="width: 120px">
            <asp:Label ID="lblRemark" runat="server" Height="50px" SkinID="lblSkin" Width="500px"></asp:Label></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px;">
            <strong>Ticket Status</strong></td>
        <td class="Info" colspan="3" style="width: 120px;">
            <asp:Label ID="lblTicketStatus" runat="server" SkinID="lblSkin" Width="150px"></asp:Label></td>
    </tr>
    <tr>
        <td class="tta" colspan="4">Ticket Status Updated</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:DataList ID="DataList1" runat="server" CellPadding="2" ForeColor="#333333" Height="200px" Width="691px">
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <ItemStyle BackColor="#EFF3FB" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width: 120px">
                                <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="Assigned By" Font-Bold="true"></asp:Label>
                            </td>
                            <td style="width: 120px">
                                <asp:Label ID="lblAssignedBy" runat="server" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"AssignedBy")) %>'
                                    Width="131px"></asp:Label></td>
                            <td style="width: 120px">
                                <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="Date" Font-Bold="true"></asp:Label>
                            </td>                                    
                            <td style="width: 120px">
                                <asp:Label ID="lblStatusDate" runat="server" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"StatusDate")) %>'
                                    Width="131px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 120px">
                                <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Assigned To" Font-Bold="true"></asp:Label>
                            </td>                        
                            <td style="width: 120px">
                                <asp:Label ID="lblAssignedTo" runat="server" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"AssignedTo")) %>'
                                    Width="131px"></asp:Label></td>
                            <td style="width: 120px">
                                <asp:Label ID="Label4" runat="server" SkinID="lblSkin" Text="Ticket Status" Font-Bold="true"></asp:Label>
                            </td>  
                            <td style="width: 120px">
                                <asp:Label ID="lblTicketStatus" runat="server" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"TicketStatus")) %>'
                                    Width="147px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 120px">
                                <asp:Label ID="Label6" runat="server" SkinID="lblSkin" Text="FollowUp Remark" Font-Bold="true"></asp:Label>
                            </td>                          
                            <td colspan="3" style="width: 120px">
                                <asp:Label ID="lblFollowUp" runat="server" Height="53px" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"FollowRemark")) %>'
                                    Width="429px"></asp:Label></td>
                        </tr>                        
                        <tr>
                            <td style="width: 120px">
                                <asp:Label ID="Label5" runat="server" SkinID="lblSkin" Text="Update Remark" Font-Bold="true"></asp:Label>
                            </td>                          
                            <td colspan="3" style="width: 120px">
                                <asp:Label ID="lblUpdateRemark" runat="server" Height="53px" SkinID="lblSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Remark")) %>'
                                    Width="429px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="border-bottom: darkred thin dashed">
                                &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemStyle BackColor="White" />
            </asp:DataList></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px;">
            <strong>Assigned To</strong></td>
        <td class="Info" style="width: 120px;">
            <asp:DropDownList ID="ddlAssignedTo" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
        <td style="width: 120px;" class="reportTitleIncome">
            <strong>Ticket Status</strong></td>
        <td style="width: 120px;" class="Info">
            <asp:DropDownList ID="ddlTicketStatus" runat="server" SkinID="ddlSkin">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Open</asp:ListItem>
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>Close</asp:ListItem>
                <asp:ListItem>FollowUp</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    
      <tr>
        <td class="reportTitleIncome" style="width: 243px">
            <strong>Attachment&nbsp;&nbsp;
                </strong></td>
        <td class="Info" colspan="3">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="480px" SkinID="flup" /></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 120px">
            <strong>Update Remark</strong></td>
        <td class="Info" colspan="3" style="width: 120px">
            <asp:TextBox ID="txtUpdateRemark" runat="server" Height="53px" MaxLength="200" SkinID="txtSkin" 
                TextMode="MultiLine" Width="425px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="Info" colspan="4">
            <asp:Button ID="btnSave" runat="server" 
                Text="Save" OnClick="btnSave_Click" SkinID="btnSaveSkin" />
            &nbsp;<asp:Button ID="btnCancel" runat="server"
                Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
    </tr>
</table>
    <br />
    <br />
    <asp:HiddenField ID="HdnClusterId" runat="server" />

</asp:Content>

