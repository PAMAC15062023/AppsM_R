<%@ Page Language="C#" MasterPageFile="~/Admin/QMS/MasterPage.master" AutoEventWireup="true" CodeFile="TicketRequest.aspx.cs" Inherits="Admin_QMS_TicketRequest" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript">


function CheckAll() 
{
    chequeBoxSelectedCount = 0;
    var grdTicketFill = document.getElementById("<%=grdTicketFill.ClientID%>");
    var chkSelectAll = document.getElementById('chkSelectAll');
    var cell;
    for (i = 0; i <= grdTicketFill.rows.length - 1; i++) 
    {
        cell = grdTicketFill.rows[i].cells[0];
        if (cell != null) 
        {
            for (j = 0; j < cell.childNodes.length; j++) 
            {
                if (cell.childNodes[j].type == "checkbox") 
                {
                    cell.childNodes[j].checked = chkSelectAll.checked;
                    chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                }
            }
        }
    }
}    



   function Validate()
   {
        var ErrorMsg = "";
        var ReturnValue = true;
        var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
        var ddlDepartment = document.getElementById("<%=ddlDepartment.ClientID%>");
        var ddlQMSDepartment = document.getElementById("<%=ddlQMSDepartment.ClientID%>");
        var ddlProblemType = document.getElementById("<%=ddlProblemType.ClientID%>");
        var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");

        if(txtRemark.value == '')
        {
            ErrorMsg = "Please Enter Remark.";
            ReturnValue = false;
            txtRemark.focus();
        }    
        if(ddlProblemType.selectedIndex == 0)
        {
            ErrorMsg = "Please Select Problem Type.";
            ReturnValue = false;
            ddlProblemType.focus();
        }

        if(ddlQMSDepartment.selectedIndex == 0)
        {
            ErrorMsg = "Please Select QMS Department.";
            ReturnValue = false;
            ddlQMSDepartment.focus();
        }
        if(ddlDepartment.selectedIndex == 0)
        {
            ErrorMsg = "Please Select Department.";
            ReturnValue = false;
            ddlDepartment.focus();
        }
        
        window.scrollTo(0,0);
        lblMsg.innerText = ErrorMsg;
        return ReturnValue;
    }
    
    
    
    
</script>

<script language="javascript" type="text/javascript">
debugger
       window.onunload = function doCleanup() {
       if (Session.Count == 0)
       {
       var strURL = "Logout.aspx";

 }
 var popup = window.open(strURL);
      
    }
    

</script>


<table style="width: 816px;">
    <tr>
        <td colspan="4" style="width: 700px;">
            <asp:Label runat="server" ID="lblMsg"  SkinID="lblError" Font-Bold="True" ForeColor="Blue" Width="815px"></asp:Label></td>
    </tr>
    <tr>
        <td class="tta" colspan="4" style="width: 700px;">
            <span style="font-size: 10pt">Generate Ticket Request</span></td>
    </tr>
    <tr>
        <td style="width: 243px" class="reportTitleIncome">
            <strong>Ticket No.
                </strong></td>
        <td class="Info" colspan="3">
            <asp:Label ID="lblTicketNo" runat="server" Width="470px" ForeColor="Red" SkinID="lblSkin" Font-Bold="True" Font-Size="Small"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 243px" class="reportTitleIncome">
            <strong>Employee Name&nbsp;
                </strong></td>
        <td style="width: 167px" class="Info">
            <asp:TextBox ID="txtUserName" runat="server" Width="180px" SkinID="txtSkin"></asp:TextBox></td>
        <td style="width: 200px" class="reportTitleIncome">
            <strong>Department Of The Employee</strong></td>
        <td style="width: 176px" class="Info">
            <asp:DropDownList ID="ddlDepartment" runat="server" SkinID="ddlSkin" Width="173px">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>PCPA</asp:ListItem>
                <asp:ListItem>PCPV</asp:ListItem>
                <asp:ListItem>PTPV</asp:ListItem>
                <asp:ListItem>PDCR</asp:ListItem>
                <asp:ListItem>PFRC</asp:ListItem>
                <asp:ListItem>RSP</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>EDP</asp:ListItem>
                <asp:ListItem>SSU</asp:ListItem>
                <asp:ListItem>Account</asp:ListItem>
                <asp:ListItem>HR</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 243px" class="reportTitleIncome">
            <strong>Concern Department
                </strong></td>
        <td style="width: 167px" class="Info">
            <asp:DropDownList ID="ddlQMSDepartment" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlQMSDepartment_SelectedIndexChanged" Width="175px">
            </asp:DropDownList></td>
            
        <td style="width: 243px" class="reportTitleIncome">
            <strong>Query Type &nbsp;&nbsp;</strong></td>
        <td class="Info" style="width: 176px">
            <asp:DropDownList ID="ddlProblemType" runat="server" SkinID="ddlSkin" Width="330px" AutoPostBack="True" OnSelectedIndexChanged="ddlProblemType_SelectedIndexChanged">
            </asp:DropDownList></td>
            
<%--        <td class="reportTitleIncome" style="width: 200px">
            <strong>Assign To
                <img src="../../Images/Employee Name.jpg" style="width: 29px; height: 27px" /></strong></td>
        <td class="Info" style="width: 176px">
            <asp:DropDownList ID="ddlQMSUser" runat="server" SkinID="ddlSkin" Width="175px">
            </asp:DropDownList></td>--%>                
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 200px">
            <strong>Assign To
                </strong></td>
        <td class="Info" colspan="3">
            <asp:DropDownList ID="ddlQMSUser" runat="server" SkinID="ddlSkin" Width="175px">
            </asp:DropDownList></td>    
    
<%--        <td style="width: 243px" class="reportTitleIncome">
            <strong>Query Type &nbsp;<img src="../../Images/comme.jpg" style="width: 29px; height: 27px" /></strong></td>
        <td class="Info" colspan="3">
            <asp:DropDownList ID="ddlProblemType" runat="server" SkinID="ddlSkin" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlProblemType_SelectedIndexChanged">
            </asp:DropDownList></td>--%>
    </tr>
    <tr>   
        <td class="reportTitleIncome" style="width: 243px">
            <strong>Comments &nbsp;&nbsp; </strong></td>
        <td class="Info" colspan="3">
            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="470px" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 243px">
            <strong>Attachment&nbsp;&nbsp;
                </strong></td>
        <td class="Info" colspan="3">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="480px" SkinID="flup" /></td>
    </tr>
    <tr>
        <td class="Info" colspan="4">
            <asp:Button ID="btnSave" runat="server" SkinID="btnSaveSkin" Text="Save" OnClick="btnSave_Click"/>&nbsp;<asp:Button
                ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />&nbsp;<asp:Button
                    ID="btnExport" runat="server" SkinID="btnexportskin" Text="Export" OnClick="btnExport_Click" Visible="false"/></td>
    </tr>
    <tr>
        <td class="tta" colspan="4" style="width: 700px;">
            <span style="font-size: 10pt">Ticket Details</span></td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="grdTicketFill" runat="server" SkinID="gridviewNoSort" Width="719px"  Height="152px" AutoGenerateColumns="false">
                <Columns>
                  <asp:TemplateField>
                      <HeaderTemplate>
                                  <input id="chkSelectAll" onclick="javascript:CheckAll();" type="checkbox" />
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
             
                   <asp:TemplateField>
                        <ItemTemplate>
                                  <asp:LinkButton ID="lnkClose" runat="server"  Text="Completed" OnClick="lnkClose_Click"/>
                           </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                         <asp:TemplateField>
                                <ItemTemplate>
                                <asp:LinkButton ID="lnkFollowUp" runat="server" OnClick="lnkFollowUp_Click">FollowUp</asp:LinkButton>
                                </ItemTemplate>
                          </asp:TemplateField> 
                         
                    
                       <asp:TemplateField HeaderText="Remark">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtNewRemark" runat="server" SkinID="txtSkin" TextMode="SingleLine" Width="100px" ></asp:TextBox>
                               </ItemTemplate>
                          </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="FollowUp Attachment">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                    <tr>
                                        <td style="width: 100px">
                                            <img alt="Down" src="../../Images/Download.JPG" /></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%#Eval("DownloadFilePath")%>'
                                               OnClick="lnkDownloadFile_Click" ToolTip="Click to Download Attach Documents">Download</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField HeaderText="Ticket No." DataField="Ticket_No" />
                         <asp:BoundField HeaderText="ID" DataField="ID" />
                          <asp:BoundField DataField="Centre" HeaderText="Centre" />
                        <asp:BoundField DataField="User_Name" HeaderText="User_Name" />
                        <asp:BoundField DataField="QMS_Department" HeaderText="QMS_Department" />
                        <asp:BoundField DataField="QMS_User" HeaderText="QMS_User" />
                        <asp:BoundField DataField="Problem" HeaderText="Problem" />
                           <asp:BoundField DataField="QMS_User" HeaderText="QMS_User" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                <asp:BoundField DataField="File_Attached" HeaderText="File_Attached" />
                        <asp:BoundField DataField="Created_Date" HeaderText="Created_Date" />
                                     <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                        <asp:BoundField DataField="QMS_Remark" HeaderText="QMS_Remark" />
                            <asp:BoundField DataField="FollowRemark" HeaderText="FollowRemark" />
                       
                       
             </Columns>
            </asp:GridView>
           
            <br />
            <asp:GridView ID="grdExportTicket" runat="server">
            </asp:GridView>
            <br />
            
            <asp:HiddenField ID="hdnEmpCode" runat="server" />
        </td>
    </tr>
</table>



</asp:Content>

