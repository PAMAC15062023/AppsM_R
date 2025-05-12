<%@ Page Language="C#" MasterPageFile="~/QMS/QMS/masterpage.master" AutoEventWireup="true"
    CodeFile="QMSRequest.aspx.cs" Inherits="QMS_QMS_QMSRequest" Title="Untitled Page" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

    <table style="width: 816px;border-color:Navy" frame="border" >
        <tr>
            <td colspan="4" style="width: 700px; height: 21px;" class="tta">
                <asp:Label runat="server" ID="lblMsg" SkinID="lblError" Font-Bold="True" ForeColor="Blue"
                    Width="815px"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="4" style="width: 700px; height: 17px; background-color:ActiveBorder; border-color:Navy">
                <span style="font-size: 20pt">Generate Ticket Request</span></td>
        </tr>
        <tr>
            <td style="width: 223px; height: 21px; border-width:1px;" class="reportTitleIncome">
                <strong> <span style="font-size: 12pt;"> Ticket No.</span></strong>
          
            </td>
            <td class="Info" colspan="3" style="height: 21px;  border-width:inherit;">
                <asp:Label ID="lblTicketNo" runat="server" Width="470px" ForeColor="Red" SkinID="lblSkin"
                    Font-Bold="True" Font-Size="Small"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 223px; height: 26px;  border-width:inherit;" class="reportTitleIncome">
            
                 <strong> <span style="font-size: 12pt;"> FOS Name</span></strong>
           
            </td>
            <td style="width: 167px; height: 26px; border-color:Gray; border-width:inherit;" class="Info">
                <asp:TextBox ID="txtUserName" runat="server" Width="180px" SkinID="txtSkin"></asp:TextBox></td>
            
            <td style="width: 223px; height: 26px; border-width:inherit;" class="reportTitleIncome">
      
                     <strong> <span style="font-size: 12pt;"> Query Type </span></strong>
                </td>
            <td class="Info" style="width: 176px; height: 26px; border-width:inherit;">
                <asp:DropDownList ID="ddlProblemType" runat="server" SkinID="ddlSkin" Width="330px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlProblemType_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList></td>
           
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 223px; height: 26px;  border-width:inherit;">
            
        <strong> <span style="font-size: 12pt;"> Assign To</span></strong>
              
            </td>
            <td class="Info" colspan="3" style="height: 26px; border-width:inherit;">
                <asp:DropDownList ID="ddlQMSUser" runat="server" SkinID="ddlSkin" Width="175px">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="P-00001">Nitin Pednekar</asp:ListItem>
                </asp:DropDownList></td>
           
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 223px;  border-width:inherit;">
              <strong> <span style="font-size: 12pt;">Comments </span></strong>
              
            </td>
            <td class="Info" colspan="3" style=" border-width:inherit;">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="470px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 223px; height: 26px;  border-width:inherit;">
             <strong> <span style="font-size: 12pt;">Attachment</span></strong>
             
            </td>
            <td class="Info" colspan="3" style="height: 26px;  border-width:inherit;">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="480px" SkinID="flup" /></td>
        </tr>
        <tr>
            <td class="Info" colspan="4" style="height: 41px; border-color:Gray; border-width:inherit;">
                <asp:Button ID="btnSave" runat="server"  Text="Save" OnClick="btnSave_Click"  SkinID="btnsaveskin" Height="30px" width="60px"/>
                &nbsp;<asp:Button ID="btnCancel" runat="server"  Text="Cancel" OnClick="btnCancel_Click" SkinID="btncancelskin" Height="30px" width="60px"/>&nbsp;<asp:Button
                        ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" SkinID="btnexportskin"
                        Visible="false" Height="30px" width="60px"/>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="btn"
                    Text="mail" /></td>
        </tr>
        <tr>
            <td class="tta" colspan="4" style="width: 700px; background-color:ActiveBorder;border-color:Navy" >
                <span style="font-size: 20pt">Ticket Details</span></td>
        </tr>
        <tr>
            <td colspan="4" >
                <asp:GridView ID="grdTicketFill" runat="server" SkinID="gridviewNoSort" Width="719px"
                    Height="152px" AutoGenerateColumns="false" GridLines="None" CssClass="grid" OnRowCommand="grdTicketFill_RowCommand1">
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
                                <asp:LinkButton ID="lnkClose" runat="server" Text="Edit" CommandArgument='<%# Eval("Ticket_No") %>' CommandName="Edit1"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkFollowUp" runat="server" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtNewRemark" runat="server" SkinID="txtSkin" TextMode="SingleLine"
                                    Width="100px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="FollowUp Attachment">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                    <tr>
                                        <td style="width: 100px">
                                           <%-- <img alt="Down" src="../../Images/Download.JPG" />--%>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%#Eval("DownloadFilePath")%>'
                                                OnClick="lnkDownloadFile_Click" ToolTip="Click to Download Attach Documents">Download</asp:LinkButton></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:BoundField HeaderText="Ticket No." DataField="Ticket_No" />
                       <%-- <asp:BoundField HeaderText="ID" DataField="ID" />--%>
                        <asp:BoundField DataField="Centre" HeaderText="Hub" />
                        <asp:BoundField DataField="User_Name" HeaderText="FOS Name" />
                        <%--<asp:BoundField DataField="QMS_Department" HeaderText="QMS_Department" />--%>
                        <asp:BoundField DataField="QMS_User" HeaderText="QMS_User" />
                        <asp:BoundField DataField="Problem" HeaderText="Problem" />
                       <%-- <asp:BoundField DataField="QMS_User" HeaderText="QMS_User" />--%>
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="File_Attached" HeaderText="File_Attached" />
                        <asp:BoundField DataField="Created_Date" HeaderText="Created_Date" />
                        <asp:BoundField DataField="TicketStatus" HeaderText="TicketStatus" />
                        <asp:BoundField DataField="QMS_Remark" HeaderText="QMS_Remark" />
                      <%--  <asp:BoundField DataField="FollowRemark" HeaderText="FollowRemark" />--%>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:GridView ID="grdExportTicket" runat="server">
                </asp:GridView>
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <br />
                <asp:HiddenField ID="hdnEmpCode" runat="server" />
                <asp:HiddenField ID="hdnemp_code" runat="server" />
                <asp:HiddenField ID="hdnfullname" runat="server" />
                <asp:HiddenField ID="hdnamount" runat="server" />
                <asp:HiddenField ID="hdnemail" runat="server" />
                <asp:HiddenField ID="hdnyrmonth" runat="server" />
            </td>
        </tr>
    </table>
    

</asp:Content>
