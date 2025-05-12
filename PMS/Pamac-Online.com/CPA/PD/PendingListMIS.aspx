<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="PendingListMIS.aspx.cs" Inherits="CPA_PD_PendingListMIS" Title="Untitled Page" StylesheetTheme="SkinFile" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">

function funValidateFromToDate()
{
    var strFromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //==split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replacing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate = arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

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
    
    if (parseInt(dateDiff) <= 0) 
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

<table style="width:690px;">  <%--height: 419px--%>
<tr>
    <td style="width: 691px; height: 475px;">  <%--height: 15px; --%>
    <asp:Panel ID="pnlPendingReport" runat="server" Width="688px"> 
        <table style="width:686px;">
        <tr>
            <td class="tta" colspan="4" style="width: 679px;">
                <span style="font-size: 10pt">REPORT</span></td> 
        </tr>
        <tr>
            <td colspan="4" style="width: 679px;">
                <asp:Label runat="server" ID="lblMsg" SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="651px"></asp:Label></td>
        </tr>
        <tr>
            <td  style="width: 100px;" class="reportTitleIncome">
                <strong>From Date</strong></td>
            <td style="width: 100px;" class="Info">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td style="width: 100px;" class="reportTitleIncome">
                <strong>To Date</strong></td>
            <td style="width: 100px;" class="Info">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
        </tr>
        <tr>
            <td class="reportTitleIncome">
                <strong>MIS Type</strong></td>
            <td class="Info" colspan="3" style="width: 100px">
                <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddlSkin" Width="200px" ValidationGroup="grpSearch">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="get_pd_pending_data123">Pending Report</asp:ListItem>
                    <asp:ListItem Value="sp_BillingMis">Billing MIS</asp:ListItem>
                      <asp:ListItem Value="sp_PD_FEProductivity_mis">FE Productivity MIS</asp:ListItem>
                  <%--  <asp:ListItem Value="stp_OverALLTATMIS">Lead to Deposit TAT MIS</asp:ListItem>
                    <asp:ListItem Value="DCR_Get_PickUpToDepositTAT">Pick Up to Deposit TAT MIS</asp:ListItem>
                    <asp:ListItem Value="stp_ChequeScanTATMIS">Cheque Scan TAT MIS</asp:ListItem>
                    <asp:ListItem Value="stp_DepositScanTATMIS">Deposit Scan TAT MIS</asp:ListItem>
                    <asp:ListItem Value="DCR_Get_Billing_MIS">Billing MIS</asp:ListItem>
                    <asp:ListItem Value="DCR_Get_MasterFile">Master File</asp:ListItem>--%>
<%--                <asp:ListItem>Perfomance MIS</asp:ListItem>--%>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="Info" colspan="4">
                <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpSearch"/>
                <asp:Button ID ="btnExport" runat="server" Text="Export" SkinID="btnexportskin" OnClick="btnExport_Click" Visible="False" />
                <asp:Button ID="btnCancel" runat="server"  Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
        </tr>

        <tr>
            <td colspan="4" style="height: 107px">
                <div style="overflow: scroll; width: 935px; height: 350px">
                    <asp:GridView ID="grdExcelReport" runat="server" SkinID="gridviewNoSort" AutoGenerateColumns="false"  >  
                    
                    <%--<Columns>
                <asp:BoundField DataField="Case ID" HeaderText="Case ID"  SortExpression="case_id"/>
                <asp:BoundField DataField="File Ref No" HeaderText="File Ref No"  />
                <asp:BoundField DataField="Customer Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Company Name" HeaderText="Company Name"  />
                <asp:BoundField DataField="Contact Person Name" HeaderText="Contact Person Name"  />
                <asp:BoundField DataField="Contact Number" HeaderText="Contact Number"  />
                <asp:BoundField DataField="Pamac Location" HeaderText="Pamac location" />
                <asp:BoundField DataField="Address" HeaderText="Address"  />
             
                 <asp:BoundField DataField="Allocation Date" HeaderText="Allocation Date"  />
                    <asp:BoundField DataField="APPOINTMENT DATE" HeaderText="APPOINTMENT DATE"  />
                 <asp:BoundField DataField="Tele Status" HeaderText="Tele_Status"  />
                <asp:BoundField DataField="Tele Remark" HeaderText="Tele Remark" />
                   <asp:BoundField DataField="Visit Date" HeaderText="Visit Date"  />
                <asp:BoundField DataField="FE Status" HeaderText="FE Status"  />
                <asp:BoundField DataField="FE Remark" HeaderText="FE Remark"  />
                 <asp:BoundField DataField="Supervisior Remark" HeaderText="Supervisior Remark"  />
                  <asp:BoundField DataField="Area" HeaderText="Area"  />
                   <asp:BoundField DataField="Report Send Date" HeaderText="Report Send Date"  />
                  <asp:BoundField DataField="Send_date" HeaderText="Send_date"  />
                 <asp:BoundField DataField="client_name" HeaderText="client_name"  />
                    
                         </Columns>
                    
                    
                    --%>
                    </asp:GridView>
                    <asp:GridView ID="grddemo" runat="server">
                    </asp:GridView>
                    
                     <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin">
                    </asp:GridView>
                </div>
            </td>
        
        </tr>



        </table>
    </asp:Panel>
            
                    
            <asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtfromdate"
                Display="None" ErrorMessage="Please Enter From Date." SetFocusOnError="True"
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate"
                Display="None" ErrorMessage="Please Enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtfromdate"
                Display="None" ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txttoDate"
                Display="None" ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="cvDateSearch" runat="server" ClientValidationFunction="funValidateFromToDate"
                ControlToValidate="txtToDate" Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="reqValReportType" runat="server" ControlToValidate="ddlReportType" InitialValue="0" Display="None"
                ErrorMessage="Please Select Report Type." SetFocusOnError="true" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>       
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpSearch" />
                
            <asp:HiddenField ID="Hdnmaster" runat="server" />
    </td>
</tr>
</table>



</asp:Content>

