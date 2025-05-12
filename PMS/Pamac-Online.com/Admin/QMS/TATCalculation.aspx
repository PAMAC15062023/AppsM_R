<%@ Page Language="C#" MasterPageFile="~/Admin/QMS/MasterPage.master" AutoEventWireup="true" CodeFile="TATCalculation.aspx.cs" Inherits="Admin_QMS_TATCalculation" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript" src="../../popcalendar.js"></script>
<script type="text/javascript" language="javascript">

function funValidateFromToDate()
{
    var strFromDate = document.getElementById("<%=txtfromdate.ClientID%>").value;
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


<table style="width: 942px">
    <tr>
        <td colspan="4" class="tta">
            <strong >TAT Calculation</strong></td>
    </tr>
    <tr>
        <td colspan="4" style="height: 16px">
            <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Width="896px" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 136px;" class="reportTitleIncome">
            <strong>From Date</strong></td>
        <td style="width: 170px;" class="Info">
            <asp:TextBox ID="txtfromdate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>&nbsp;
            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" />
            dd/mm/yyyy]</td>
        <td style="width: 131px;" class="reportTitleIncome">
            <strong>To Date</strong></td>
        <td style="height: 9px; width: 195px;" class="Info">
            <asp:TextBox ID="txtToDate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>&nbsp;
            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" /> [dd/mm/yyyy]</td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 136px">
            <strong>Reports</strong></td>
        <td class="Info" style="width: 170px">
            <asp:DropDownList ID="ddlreport" runat="server" SkinID="ddlSkin" Width="179px"  AutoPostBack="True" OnSelectedIndexChanged="ddlreport_SelectedIndexChanged">
                <asp:ListItem Value="Get_QMS_TAT">TAT MIS FOR COMPLETED REQUEST</asp:ListItem>
                <asp:ListItem Value="Get_QMS_EmployeeWise">EMPLOYEE WISE TAT</asp:ListItem>
        
            </asp:DropDownList></td>
        <td class="reportTitleIncome" style="width: 131px">
            <strong>SPOC Name</strong></td>
        <td class="Info" style="width: 195px; height: 9px">
            <asp:DropDownList ID="ddlSPOC" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="Info" colspan="4">
            <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpSearch"/>&nbsp;<asp:Button
                ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btnExportSkin"
                Text="Export" Visible="False" /></td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Panel ID="pnlTATcalc" runat="server" Height="137px" Width="935px">
                <asp:GridView ID="grvTAT" runat="server" SkinID="gridviewNoSort" Width="936px" CssClass="mGrid">
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
    
    <tr>
        <td colspan="4">
            <asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtfromdate" Display="None" ErrorMessage="Please Enter From Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None" ErrorMessage="Please Enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtfromdate" Display="None"
                ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True" ValidationGroup="grpSearch"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
                
            <asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txttoDate" Display="None"
                ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True" ValidationGroup="grpSearch"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>

            <asp:CustomValidator ID="cvDateSearch" runat="server" ClientValidationFunction="funValidateFromToDate"
                ControlToValidate="txtToDate" Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" 
                ShowSummary="False" ValidationGroup="grpSearch" />
        </td>
    </tr>
</table>


</asp:Content>

