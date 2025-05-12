<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/PTPU/PTPU/MasterPage.master" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="PTPU_PTPU_Import" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

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
        var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
        var ErrorMsg = "";
        var ReturnValue = true;
        var ddlCaseType = document.getElementById("<%=ddlCaseType.ClientID%>");
        var xslFileUpload = document.getElementById("<%=xslFileUpload.ClientID%>");
        
        if(xslFileUpload.value=='')
        {
            ErrorMsg = "Please Select an Excel File to continue.";
            ErrorMsg = false;
            xslFileUpload.focus();
        }
        if(ddlCaseType.selectedIndex == 0)
        {
            ErrorMsg = "Please Select Case Type to continue.";
            ReturnValue = false;
            ddlCaseType.focus();
        }
        window.scrollTo(0,0);
        lblMsgXls.innerText = ErrorMsg;
        return ReturnValue;
    }
</script>

<table style="width: 688px;">    <%--height: 66px--%>
  <tr>
  <td style="width: 691px;">
    <table style="width: 686px;">
    <tr>
        <td class="tta" colspan="4" style="width: 690px;">
            <span style="font-size: 10pt">Data Import</span></td>
    </tr>
    <tr>
        <td colspan="4" style="width: 690px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr >
        <td style="width: 317px;" class="reportTitleIncome">
            <strong>Case Type</strong></td>
        <td style="width: 225px" class="Info">
            <asp:DropDownList ID="ddlCaseType" runat="server" SkinID="ddlSkin" Width="141px">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Fresh Cases</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
        </td>
        <td style="width: 374px;" class="reportTitleIncome" >
            <strong>Select File</strong></td>
        <td style="width: 95px;" class="Info">
            <asp:FileUpload ID="xslFileUpload" runat="server" Width="300px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.xls]</td>
    </tr>
    <tr >
        <td style="width: 100px;" class="Info" colspan="4">
           <asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUpload_Click" ValidationGroup="grpImport" SkinID="btnImport" />
          </td>
    </tr>
    </table>
     
  </td>
  </tr>
  </table>


</asp:Content>

