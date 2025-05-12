<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="Case_Entry.aspx.cs" Inherits="DCR_DCR_Case_Entry" Title="Untitled Page"  Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var ddlclustername = document.getElementById("<%=ddlclustername.ClientID%>");
    var ddlcenter = document.getElementById("<%=ddlcenter.ClientID%>");
    var ddlverificationtype = document.getElementById("<%=ddlverificationtype.ClientID%>");
    var txtPincode = document.getElementById("<%=txtPincode.ClientID%>");
    var txtContactNo = document.getElementById("<%=txtContactNo.ClientID%>");
    var txtInitiationDate = document.getElementById("<%=txtInitiationDate.ClientID%>");
    var ddlLeadType = document.getElementById("<%=ddlLeadType.ClientID%>");
    var txtAmount = document.getElementById("<%=txtAmount.ClientID%>");
    var txtCaseReceivedDate = document.getElementById("<%=txtCaseReceivedDate.ClientID%>");
    var txtCaseReceivedTime = document.getElementById("<%=txtCaseReceivedTime.ClientID%>");
    
    if(txtCaseReceivedTime.value == '')
    {
        ErrorMsg = "Please Select Case-Received Time.";
        ReturnValue = false;
        txtCaseReceivedTime.focus();
    }    
    if(txtCaseReceivedDate.value == '')
    {
        ErrorMsg = "Please Select Case-Received Date.";
        ReturnValue = false;
        txtCaseReceivedDate.focus();
    }    
 
    if(isNaN(txtAmount.value))
    {
        ErrorMsg = "Please Enter Valid Amount.";
        ReturnValue = false;
        txtAmount.focus();
    }
    
    if(ddlLeadType.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Lead Type.";
        ReturnValue = false;
        ddlLeadType.focus();
    }
    if(txtInitiationDate.value == '')
    {
        ErrorMsg = "Please Select Initiation Date.";
        ReturnValue = false;
        txtInitiationDate.focus();
    }    
    
    if(isNaN(txtContactNo.value))
    {
        ErrorMsg = "Enter Valid Contact No.";
        ReturnValue = false;
        txtContactNo.focus(); 
    }
    if((txtPincode.value == '') || isNaN(txtPincode.value) || (txtPincode.value.length !=6))
    {
        ErrorMsg = "Please Enter Valid 6 digit Pincode.";
        ReturnValue = false;
        txtPincode.focus();
    }
    if(ddlverificationtype.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Verification Type.";
        ReturnValue = false;
        ddlverificationtype.focus();
    }
    if(ddlcenter.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Location.";
        ReturnValue = false;
        ddlcenter.focus();
    }
    if(ddlclustername.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster Name.";
        ReturnValue = false;
        ddlclustername.focus();
    }
        
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}
</script>



<asp:Panel ID="pnlCaseEntry" runat="server" Width="800px" Height="351px">
    <table style="width: 800px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="880px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tta">
                <span style="font-size: 10pt">CASE ENTRY</span>
            </td>
        </tr>        
        <tr>
            <td class="reportTitleIncome" style="width: 164px; height: 16px">
                <strong>Cluster Name</strong></td>        
            <td style="width: 105px" class="Info" colspan="3">
                <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="120px">
                </asp:DropDownList>                
            </td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Location</strong></td>
            <td style="width: 400px" class="Info">
                <asp:DropDownList ID="ddlcenter" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Verification Type</strong></td>
            <td style="width: 125px" class="Info">
                <asp:DropDownList ID="ddlverificationtype" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Lead ID</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtLeadID" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Policy No.</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtPolicyNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Call Center Group</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtCallCenter" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Team Leader</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtTeamLeader" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Customer Name</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Customer Address</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>PIN Code</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtPincode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Contact No.</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Initiation Date</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtInitiationDate" runat="server" SkinID="txtSkin" Width="70px" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtInitiationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Lead Type</strong></td>
            <td style="width: 125px" class="Info">
                &nbsp;<asp:DropDownList ID="ddlLeadType" runat="server" SkinID="ddlSkin" Width="130px">
                    <asp:ListItem >--Select--</asp:ListItem>
                    <asp:ListItem >Fresh Cases</asp:ListItem>
                    <asp:ListItem >Online Cases</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Appointment Date</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtAppointmentDate" runat="server" SkinID="txtSkin" Width="70px" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAppointmentDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Appointment Time</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtAppointmentTime" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>&nbsp;<asp:DropDownList ID="ddlAppointmentTime" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
                [hh:mm]</td>
        </tr>
        <tr>
            <td style="width: 105px" class="reportTitleIncome">
                <strong>Amount (Rs.)</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtAmount" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Remarks</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="300px" MaxLength="1000"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 803px;" class="reportTitleIncome">
                <strong>Case Received Date</strong></td>
            <td style="width: 400px;" class="Info">
                <asp:TextBox ID="txtCaseReceivedDate" runat="server" SkinID="txtSkin" Width="70px" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCaseReceivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td style="width: 701px;" class="reportTitleIncome">
                <strong>Case Received Time</strong></td>
            <td style="width: 225px;" class="Info">
                <asp:TextBox ID="txtCaseReceivedTime" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
                <asp:DropDownList ID="ddlCaseReceivedTime" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                </asp:DropDownList>
                [hh:mm]</td>
        </tr>
        <tr>
            <td class="Info" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnsaveskin" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:HiddenField ID="HdnclusterID" runat="server" />    
            </td>
        </tr>
    </table>

</asp:Panel>



</asp:Content>

