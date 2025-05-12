<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="CaseImport.aspx.cs" Inherits="CPA_PD_CaseImport" Title="Untitled Page" StylesheetTheme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script type="text/javascript" language="javascript">
    function ClientValidate(source, arguments)
    {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
    }
   
    function validate()
    {
        debugger
        var ErrorMsg = "";
        var ReturnValue = true;
        var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
        var ddlCaseType = document.getElementById("<%=ddlCaseType.ClientID%>");
        var xslFileUpload = document.getElementById("<%=xslFileUpload.ClientID%>");
        var txtCaseReceivedDate = document.getElementById("<%=txtCaseReceivedDate.ClientID%>");
        var txtCaseReceivedTime =  document.getElementById("<%=txtCaseReceivedTime.ClientID%>");
        
        if(txtCaseReceivedTime.value == '')
        {
            ErrorMsg = "Please Enter Case Received Time.";
            ReturnValue = false;
            txtCaseReceivedTime.focus();
        }
        if(txtCaseReceivedDate.value == '')
        {
            ErrorMsg = "Please Select Case Received Date & Time.";
            ReturnValue = false;
            txtCaseReceivedDate.focus();
        }
        if(xslFileUpload.value == '')
        {
            ErrorMsg = "Please Select an Excel File.";
            ReturnValue = false;
            xslFileUpload.focus();
        }
        if(ddlCaseType.selectedIndex == 0)
        {
            ErrorMsg = "Please Select Case Type.";
            ReturnValue = false;
            ddlCaseType.focus();
        }
        window.scrollTo(0,0);
        lblMsgXls.innerText = ErrorMsg;
        return ReturnValue;
    }
</script>

<table style="width: 800;">  
  <tr>
  <td style="width: 691px; height: 178px;">
    <table style="width: 686px;">
    <tr>
        <td class="tta" colspan="4" style="height: 4px; width: 690px;">
            <span style="font-size: 10pt">DATA IMPORT</span></td>
    </tr>
    <tr>
        <td colspan="4" style="height: 1px; width: 690px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr >
        <td style="width: 803px; height: 6px;" class="reportTitleIncome">
            <strong>Case Type</strong></td>
        <td style="width: 225px; height: 6px;" class="Info">
            <asp:DropDownList ID="ddlCaseType" runat="server" SkinID="ddlSkin" Width="100px">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Fresh Cases</asp:ListItem>
               
            </asp:DropDownList>
            &nbsp;&nbsp;
        </td>
        <td style="width: 804px; height: 6px;" class="reportTitleIncome" >
            <strong>Select File</strong></td>
        <td style="width: 95px; height: 6px;" class="Info">
            <asp:FileUpload ID="xslFileUpload" runat="server" Width="290px" SkinID="flup" />&nbsp;
            &nbsp;<strong>[Only *.xls]</strong></td>
    </tr>
  
    <tr>
        <td style="width: 803px;" class="reportTitleIncome">
            <strong>Case Received Date</strong></td>

        <td style="width: 225px;" class="Info">
            <asp:TextBox ID="txtCaseReceivedDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCaseReceivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" /></td>


        <td style="width: 804px;" class="reportTitleIncome">
            <strong>Case Received Time</strong></td>

        <td style="width: 225px;" class="Info">
            <asp:TextBox ID="txtCaseReceivedTime" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
            <asp:DropDownList ID="ddlCaseReceivedTime" runat="server" SkinID="ddlSkin">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <strong>[hh:mm]</strong>
        </td>
    </tr>
  
    <tr >
        <td style="width: 225px;" class="Info" colspan="4">
           <asp:Button ID="btnUpload" runat="server" CssClass="button" OnClick="btnUpload_Click" ValidationGroup="grpImport" SkinID="btnImport"/>
           <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
        </td>
    </tr>
    </table>
  
      </td>
</tr>
  </table>

</asp:Content>

