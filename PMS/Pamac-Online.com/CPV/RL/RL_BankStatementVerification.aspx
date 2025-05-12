<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="RL_BankStatementVerification.aspx.cs" Inherits="CPV_RL_RL_BankStatementVerification" Title="Bank Statement Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function ValidateTextLength(DisplayName, ControlName, xLength)
{
    if (ControlName.value.length > parseInt(xLength))
    {
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
         ControlName.focus();   
    }      
}

</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset ><legend class="FormHeading">BANK STATEMENT VERIFICATION REPORT</legend>
<table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblMain" style="background-color:#E7F6FF">
    <tr>
        <td ><asp:Label ID="lblMsg" runat="server" SkinID="lblSkin"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblBankStatement">
        <tr>
            <td style="width: 18%">
                <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server">Date of Receipt</asp:Label></td>
            <td style="width: 2%">
                :</td>
            <td colspan="3">
                <asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 18%; height: 16px">
                <asp:Label ID="Label1" runat="server" SkinID="lblSkin">CPA Reference No</asp:Label></td>
            <td style="width: 2%; height: 16px">
            </td>
            <td colspan="3" style="height: 16px">
                <asp:TextBox ID="txtCpvRefNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 18%; height: 16px">
                <asp:Label ID="bllRefNo" runat="server" SkinID="lblSkin">Bank Reference No</asp:Label></td>
            <td style="width: 2%; height: 16px">
            </td>
            <td colspan="3" style="height: 16px">
                <asp:TextBox ID="txtRefNo" runat="server" ReadOnly="true" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
    <tr>
    <td style="width:18%; height: 26px;"><asp:Label SkinID="lblSkin" ID="lblAppName" runat="server" Width="119px">Name of the FD Holder</asp:Label></td>        
        <td style="width:2%; height: 26px;">:</td>
        
    <td colspan="3" style="height: 26px"><asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>    
    </tr>
    <tr>
    <td></td>
        <td>
            :</td>
    <td style="width: 256px"></td>    
    <td></td>
    <td>
        &nbsp;</td>
  
    </tr>
    </table>
    </td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblBankStatementDetail">
    <tr>
    <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" colspan="6">
            <asp:Label SkinID="lblSkin" ID="lblBankStatDtlHead" runat="server" ForeColor="blue" Text="Detail of Bank statement" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="width:25%"><asp:Label SkinID="lblSkin" ID="lblBankName" runat="server" >Name of the Bank</asp:Label></td>
        <td style="width: 2%">:
        </td>
    <td colspan="4">
        <asp:TextBox SkinID="txtSkin" ID="txtBankName" runat="server" Width="80%" ReadOnly="true" ></asp:TextBox></td>
    </tr>
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="lblBankAddress" runat="server">Address of the Bank</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td colspan="4">
        <asp:TextBox SkinID="txtSkin" ID="txtBankAddress" runat="server" Width="80%" ReadOnly="true" ></asp:TextBox></td>
    </tr>
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="lblNameOfContPerson" runat="server" >Name of the contacted person</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td colspan="4">
        <asp:TextBox SkinID="txtSkin" ID="txtNameOfContPerson" runat="server" Width="80%"></asp:TextBox></td>
    </tr>
    <tr>
    <td style="width:20%"><asp:Label SkinID="lblSkin" ID="lblDesgnOfContPerson" runat="server">Designation of contacted person</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td style="width:20%">
        <asp:TextBox SkinID="txtSkin" ID="txtDesgnOfContPerson" runat="server" ></asp:TextBox></td>
    
    <td style="width:25%"><asp:Label SkinID="lblSkin" ID="lblDeptOfContPerson" runat="server">Department of the contacted person</asp:Label></td>
        <td style="width: 2%">:
        </td>
    <td style="width:30%">
        <asp:TextBox SkinID="txtSkin" ID="txtDeptOfContPerson" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="lblIsAcctNo" runat="server">Is account number correct</asp:Label></td>
        <td style="width: 2%">:
        </td>
    <td>
    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsCorrectAcctNo" runat="server"  AutoPostBack="false">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
        <asp:ListItem>Not confirmed</asp:ListItem>                
    </asp:DropDownList></td>
    <td><asp:Label SkinID="lblSkin" ID="lblBankStatAsPerFormat" runat="server">Is Bank statement as per Bank's Format</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td>
    <asp:DropDownList SkinID="ddlSkin" ID="ddlBankStatAsPerFormat" runat="server"  AutoPostBack="false">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
        <asp:ListItem>Not confirmed</asp:ListItem>                
    </asp:DropDownList>
    </td>
    </tr>
    
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="lblCorrectAmtAsPerBankStat" runat="server">Is Amt. shown in the Bank Statement is Correct</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td colspan="4">
    <asp:DropDownList SkinID="ddlSkin" ID="ddlCorrectAmtAsPerBankStat" runat="server"  AutoPostBack="false">
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
        <asp:ListItem>Not confirmed</asp:ListItem>                
    </asp:DropDownList></td>    
    </tr>    
    </table>    
    </td>
    </tr>
    <tr>    
    <td >
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblRemark">
    <tr>
    <td style="width:42%">
    <asp:Label SkinID="lblSkin" ID="lblRemarks" runat="server">REMARKS (Clerarly specify reason for not okay cases and not confirmed cases.)</asp:Label>
    </td>
        <td style="width: 2%">:
        </td>
    <td style="width:58%">
    <asp:TextBox SkinID="txtSkin" ID="txtRemarks" runat="server" Width="92%" TextMode="multiLine" onkeyPress="ValidateTextLength('Remark', this, 600);"></asp:TextBox>
    </td>
    </tr>
    </table>
    </td>
    </tr>    
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblFooter" >
    <tr>
    <td style="width:10%"><asp:Label SkinID="lblSkin" ID="lblFEName" runat="server">Name of FE</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td style="width:20%"> 
        <asp:TextBox SkinID="txtSkin"  ID="txtFEName" runat="server" ReadOnly="true"></asp:TextBox>        
    </td>
    <td style="width:10%"><asp:Label SkinID="lblSkin" ID="lblVerificationDate" runat="server">Date of Verification</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td style="width:25%">
      
        <asp:TextBox SkinID="txtSkin"  ID="txtVerificationDate" runat="server" MaxLength="10"></asp:TextBox> 
        <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtVerificationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
        </td>
        <td class="TDWidth" style="width: 7%">
                    <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server" Text="Case Status"></asp:Label>
                </td>
         <td style="width: 2%">:
        </td>
                <td>                     
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server" DataSourceID="sdsCaseStatus"
                          DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID" >
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID],[STATUS_NAME], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY CASE_STATUS_ID">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
                     </asp:SqlDataSource>
                </td>
    </tr>
    </table>
        <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtVerificationDate"
            Display="None" ErrorMessage="Please enter valid date format for verification date."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" />   
            </td>    
    </tr>
    <tr>
    <td align="center"><asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" ValidationGroup="grValidateDate" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />        
    <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
    </td>
    </tr>
    <tr><td>&nbsp;<asp:HiddenField ID="hdnTransStart" runat="server" /></td></tr>
</table>
</fieldset>
</td></tr>
</table>
</asp:Content>


