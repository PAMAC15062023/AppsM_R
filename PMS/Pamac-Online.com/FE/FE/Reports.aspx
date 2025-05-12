<%@ Page Language="C#" MasterPageFile="~/FE/FE/CC_MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="FE_FE_Reports" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
   
    <script language="JAVASCRIPT" type="text/javascript"> 

    function Validate_Search()
    {  
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate= document.getElementById("<%=txtToDate.ClientID%>");     
        
       var lblmsg=document.getElementById("<%=lblmsg.ClientID%>");       
       var ErrorMessage='';
       var ReturnValue=true;
       
       
                
         if (txtToDate.value =='')       
        { 
             ErrorMessage='Please Enter the To Date!';
             ReturnValue=false; 
             txtToDate.focus();
        }  
                
            if (txtFromDate.value ==0)       
        { 
             ErrorMessage='Please Enter The From Date!';
             ReturnValue=false; 
             txtFromDate.focus();
        }   
            
     
              window.scrollTo(0,0);    
         lblmsg.innerText=ErrorMessage;
         return ReturnValue;
         
    }  
    </script>
        
            
        
   
      <script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
   
    &nbsp;<asp:Panel ID="Panel1" runat="server">
        <table style="width: 748px">
            <tr>
                <td class="tta" colspan="6">
                    FE Assignment Count MIS</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    Reports :</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlSkin" Width="149px">
                        <asp:ListItem>--Select--</asp:ListItem>
                       <%-- <asp:ListItem Value="Sp_ProcedureAssignmentCount">FE Assignment Count MIS</asp:ListItem>
                        <asp:ListItem Value="Sp_ProcedureAssignmentCountSenddate">FE Cases Completed Count MIS</asp:ListItem>--%>
                        <asp:ListItem Value="Sp_GESBICC">CC Change Address Case Status Report</asp:ListItem>
                         <asp:ListItem Value="Sp_FEwisecount">New</asp:ListItem>
                        
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                </td>
                <td class="Info" style="width: 100px; height: 20px">
                </td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                </td>
                <td style="width: 100px; height: 20px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    Centre Name :</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:DropDownList ID="ddlcentre" runat="server" SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                </td>
                <td class="Info" style="width: 100px; height: 20px">
                </td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                </td>
                <td style="width: 100px; height: 20px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    From Date :</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                        Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    To Date :</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                        Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                <td style="width: 100px; height: 20px" class="reportTitleIncome">
                    &nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:HiddenField ID="HDNUPDATE" runat="server" />
                </td>
                <td style="width: 100px; height: 20px">
                    <asp:HiddenField ID="HdnUID" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 21px">
                    <asp:Button ID="Btnsearch" runat="server" Height="23px" OnClick="Button1_Click" SkinID="btn"
                        Text="Search" Width="121px" />&nbsp;<asp:Button ID="BtnExport" runat="server" Height="23px"
                            OnClick="BtnExport_Click" SkinID="btn" Text="Export To Excel" Width="121px" />
                    <asp:Button ID="BtnReset" runat="server" Height="23px" OnClick="BtnReset_Click" SkinID="btn"
                        Text="Reset" Width="121px" />&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" style="height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Panel ID="pnlGrd" runat="server" ScrollBars="Horizontal" Width="900px">
                        <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort"
                            Width="650px">
                  
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

