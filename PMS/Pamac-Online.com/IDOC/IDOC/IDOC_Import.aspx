<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_Import.aspx.cs" Inherits="IDOC_IDOC_IDOC_Import" Theme="SkinFile" Title="IDOC Import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
   <!--
   function ClientValidate(source, arguments)
   {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
   function getDisplay()
   {
        btnSub=document.getElementById("<%=btnUpload.ClientID%>");
        btnSub.disabled=true;
   }
   // -->
</script>
<table align="center" width="99%"  border="0" cellpadding="0" cellspacing="0"><tr><td>
<fieldset><legend class="FormHeading">Import</legend>
<table align="center"  border="0" cellpadding="2" cellspacing="1"
    width="100%">
    <tr valign="top">
        <td class="label" colspan="7" align="center"  style="background-color:#E7F6FF">
            <asp:Label ID="lblRecordCount" runat="server" SkinID="lblError"></asp:Label></td>
    </tr>
    <tr valign="top">
        <td class="label" colspan="2">
            Template <span class="txtRed">* </span>
        </td>
        <td align="left" style="width: 341px">
            <asp:DropDownList ID="ddlTemplate" runat="server" OnDataBound="ddlTemplate_DataBound"
                SkinID="ddlSkin">
                <asp:ListItem Value="0">-- Select Template --</asp:ListItem>
            </asp:DropDownList>
            &nbsp; &nbsp; Case Type&nbsp;<asp:DropDownList ID="ddlCaseType" runat="server" OnDataBound="ddlTemplate_DataBound"
                SkinID="ddlSkin">
                <asp:ListItem Value="1">Fresh cases</asp:ListItem>
                <asp:ListItem Value="2">Redo cases</asp:ListItem>
                <asp:ListItem Value="3">RCC cases</asp:ListItem>
            </asp:DropDownList><br />
            <asp:SqlDataSource ID="sdsTemplate" runat="server" ProviderName="System.Data.OleDb">
            </asp:SqlDataSource>
            <asp:CustomValidator ID="cvTemplate" runat="server" ClientValidationFunction="ClientValidate"
                ControlToValidate="ddlTemplate" Display="None" ErrorMessage="Please select Template"
                ValidationGroup="grpImport"></asp:CustomValidator><asp:CheckBox ID="chkRedo" runat="server"
                    SkinID="chkSkin" Text="Redo" /></td>
        <td class="txtError" colspan="1" style="width: 20px">
            Select File <span class="txtRed">* </span>
        </td>
        <td align="left" class="label" colspan="3">
            <asp:FileUpload ID="xslFileUpload" runat="server" CssClass="textbox" 
                Width="300px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.xls]<asp:RequiredFieldValidator ID="RFVImport"
                    runat="server" ControlToValidate="xslFileUpload" CssClass="txtError" Display="None"
                    ErrorMessage="Please select file to Import." SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator></td>
    </tr>
    <tr valign="top">
        <td class="label" colspan="2" >
            Received &nbsp;Date&nbsp;<span class="txtRed">* </span></td>
        <td align="left" style="width: 341px">
            <asp:TextBox ID="txtALC_Date" runat="server" CssClass="textbox" MaxLength="11"
                Text="" SkinID="txtSkin"></asp:TextBox>
                <img src="../../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtALC_Date.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            &nbsp;[dd/mm/yyyy]<asp:RequiredFieldValidator ID="RFVALC_Date" runat="server" ControlToValidate="txtALC_Date"
                CssClass="txtError" Display="None" ErrorMessage="Received Date should not be blank"
                SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="REVALC_Date" runat="server" ControlToValidate="txtALC_Date"
                CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for Received Date"
                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpImport"></asp:RegularExpressionValidator></td>
        <td class="txtError" colspan="1" style="width: 20px" >
            <span class="label">Received Time <span class="txtRed">* </span> </span></td>
        <td align="left" class="label" colspan="3">
            &nbsp;<asp:TextBox ID="txtACT_Time" runat="server" CssClass="textbox" MaxLength="5"
                Text="09:30" Width="40px" SkinID="txtSkin"></asp:TextBox><asp:DropDownList ID="ddlTimeType" runat="server" CssClass="combo" SkinID="ddlSkin">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>[hh:mm]<asp:RequiredFieldValidator ID="RFVACT_Time" runat="server" ControlToValidate="txtACT_Time"
                CssClass="txtError" Display="None" ErrorMessage="Received Time should not be blank"
                SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="REVACT_Time" runat="server" ControlToValidate="txtACT_Time" CssClass="txtError"
                    Display="None" ErrorMessage="Enter valid Received Time" SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpImport"></asp:RegularExpressionValidator><asp:Button ID="btnUpload" runat="server" CssClass="button" OnClick="btnUplaod_Click" ValidationGroup="grpImport" SkinID="btnImport" Text="Upload File"/></td>
    </tr>
    <tr>
        <td colspan="7">
            &nbsp;<span class="txtRed">*</span>&nbsp;Indicate mandatory fields.
        </td>
    </tr>
</table>
    <asp:Label ID="lblMsgXls" runat="server" CssClass="txtRed" Font-Bold="True"></asp:Label><asp:ValidationSummary ID="ValidationSummary1"
        runat="server" CssClass="txtError" DisplayMode="List" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="grpImport" />
    <asp:GridView ID="gvLog" runat="server" SkinID="gridviewNoSort" >
    </asp:GridView>
</fieldset>
</td></tr></table>
</asp:Content>

