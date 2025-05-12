<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master" AutoEventWireup="true" CodeFile="SSU_Status.aspx.cs" Inherits="Software_Requirement_Software_SSU_Status" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

 <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
   
    
    <script type="text/javascript">  
        $(function () {  
            $('[id*=lstcolumn]').multiselect({  
                includeSelectAllOption: true  
            });  
        });  
    </script>
 
 <script language="javascript" type="text/javascript">

function funValidateFromToDate()
{
    debugger;
    var strFromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //===split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

    //==Converting the string to date format
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);

    //declareing the date variable
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();
    //setTime 
    date1.setTime(dtFromDate.getTime());
    date2.setTime(dtToDate.getTime());
    var add_one_day = date2.getTime()+(1000 * 60 * 60 * 24);
    diff.setTime(Math.floor(add_one_day-date1.getTime()));
    var dateDiff = diff.getTime();
    
    if (parseInt(dateDiff) <= 0 )
    {
         alert("To Date should not be less then From Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  
</script>


  <asp:Panel ID="Panel1" runat="server" Height="900px">
   
   
   
   <table style="width: 748px">
        <tr>
            <td colspan="8" class="tta">
                Software Requirement &nbsp;&nbsp;Status</td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr style="color: #000000; font-family: Tahoma">
            <td style="width: 142px; height: 20px;" class="reportTitleIncome">
                <strong>Cluster Name</strong></td>
            <td class="Info" style="width: 212px; height: 20px">
                <asp:DropDownList ID="ddlcluster" runat="server" AutoPostBack="True" 
                    SkinID="ddlSkin" Width="150px" ValidationGroup="grpSearch" OnSelectedIndexChanged="ddlcluster_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 139px; height: 20px">
                <strong>Centre Name</strong></td>
            <td style="width: 100px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="150px" ValidationGroup="grpSearch">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                <strong>Subcentre Name</strong></td>
            <td style="width: 101px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlsubcentre" runat="server"
                    SkinID="ddlSkin" Width="150px">
                </asp:DropDownList></td>
            <td style="width: 161px; height: 20px;" class="reportTitleIncome">
                &nbsp;&nbsp;
                </td>
            <td style="width: 100px; height: 20px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 142px; height: 19px">
                <strong>
                From Date</strong></td>
            <td class="Info" style="width: 212px; height: 19px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch" 
                    Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 139px; height: 19px">
                <strong>To Date</strong></td>
            <td class="Info" style="width: 100px; height: 19px">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch" 
                    Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 19px">
             <strong>
               Over All Remark</strong>
                </td>
         <td class="Info" style="width: 101px; height: 19px">
          <asp:DropDownList ID="ddloverallremark" runat="server">
                      <asp:ListItem Text="--ALL--" Value="All" />
                     <asp:ListItem Text="Pending" Value="Pending" />
                     <asp:ListItem Text="InProgress" Value="InProgress" />
                     <asp:ListItem Text="Sought For More Clarification" Value="Sought For More Clarification" />
                     <asp:ListItem Text="Sent For UAT" Value="Sent For UAT" />
                     <asp:ListItem Text="UAT Completed" Value="UAT Completed" />
                     <asp:ListItem Text="Resolved" Value="Resolved" />
                     <asp:ListItem Text="Deleted" Value="Deleted" />
                     <asp:ListItem Text="On Hold" Value="On Hold" />
                     <asp:ListItem Text="Closed" Value="Closed" />
                     </asp:DropDownList>
                </td>
                   
                   <td class="reportTitleIncome" style="width: 100px; height: 19px">
             <strong>
             Hidden/Unidde
               </strong>
                </td>
                 <td class="Info" style="width: 212px; height: 19px">
                   <asp:ListBox ID="lstcolumn" runat="server" Height="240px" SelectionMode="Multiple" Width="190px" BackColor="#CCFFFF"></asp:ListBox> 
                   </td>
            <td style="width: 161px; height: 19px" class="reportTitleIncome">
                &nbsp;
                </td>
            <td style="width: 100px; height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 21px;" colspan="8">
                <asp:Button ID="Btnsearch" runat="server" Height="23px" OnClick="Btnsearch_Click" SkinID="btn"
                    Text="Search" Width="121px"  ValidationGroup="grpSearch" />&nbsp;
                <asp:Button ID="BtnReset" runat="server" Height="23px"  SkinID="btn"
                    Text="Reset" Width="121px" />
                <asp:Button ID="btnExport" runat="server"  OnClick="btnExport_Click" Height="23px"  SkinID="btn"
                    Text="Export" Width="121px"/></td>
        </tr>
        <tr>
            <td colspan="8" style="height: 21px">
                <asp:HiddenField ID="hdncluster" runat="server" />
                <asp:HiddenField ID="HDNUPDATE" runat="server" />
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 178px">
                <asp:Panel ID="pnlGrd" runat="server"  ScrollBars="Both" Width="900px">
                    <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort" Width="850px" Height="450px" >
                       
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        
         <tr>
            <td colspan="8" style="height: 178px">
                <asp:Panel ID="pnlGrdexport" runat="server"  ScrollBars="Both" Width="900px">
                    <asp:GridView ID="Grdexport" runat="server" SkinID="gridviewNoSort" Width="850px" Height="450px" OnSelectedIndexChanged="Grdexport_SelectedIndexChanged" >
                       
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        
        
        
    </table>
    </asp:Panel>
    
    
<asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtFromDate"
                Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True"
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None"
                    ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtFromDate" Display="None"
                        ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
              <asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txtToDate" Display="None"
                            ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
         
         
         
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="grpSearch" />   
  


<%--    <asp:Panel ID="plnExport" runat="server" Width="1000px" Height="3px">
        <table style="width: 1000px; ">
            <tr>
                <td style="width: 120px;" class="Info" colspan="4">
                    <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
                    &nbsp;<asp:Button ID="btnExport" runat="server" SkinID="btnexportskin" Text="Export" Visible="true" OnClick="btnExport_Click" /></td>

            </tr>        
        </table>    
    </asp:Panel> --%>
</asp:Content>

