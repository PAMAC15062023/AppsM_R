<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true"
    CodeFile="EBC_New_VerificationView.aspx.cs" Inherits="EBC_New_EBC_New_EBC_New_VerificationView"
    Title="EBC_New_VerificationView" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<script language="javascript" type="text/javascript">

function Validate_CaseViewSearch()
{
    var txtCaseID=document.getElementById("<%=txtCaseID.ClientID%>");                                                 
    var txtRefNo=document.getElementById("<%=txtRefNo.ClientID%>");                                                 
    var ddlVerificationTypeID=document.getElementById("<%=ddlVerificationTypeID.ClientID%>");    
    var ddlSubVerificationTypeID=document.getElementById("<%=ddlSubVerificationTypeID.ClientID%>");    
    
    var ReturnValue=true;
    var ErrorMessage="";      
    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
     if (ddlSubVerificationTypeID.selectedIndex==0)
     {
        ErrorMessage='Please select Sub Verification Type to continue!';
        ReturnValue=false;
        ddlSubVerificationTypeID.focus();
     }
     if (ddlVerificationTypeID.selectedIndex==0)
     {
        ErrorMessage='Please Verification Type to continue!';
        ReturnValue=false;
        ddlVerificationTypeID.focus();
     }
     
     
    if ((txtCaseID.value=='')&&(txtRefNo.value==''))
    {
        ErrorMessage='Please Enter CaseID or RefNo to continue!';
        ReturnValue=false;
        txtCaseID.focus();
    }
    
    lblMessage.innerText=ErrorMessage;
    window.scrollBy(0,0);
    
    return ReturnValue;
}

</script>
        <table style="width: 100%;"  >
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ErrorMessage"></asp:Label></td>
            </tr>
            <tr>
                <td class="tta" colspan="6" style="height: 16px">
                     Verification View</td>
            </tr>
            <tr>
                <td class="bx" style="width: 20px">
                </td>
                <td style="width: 295px" class="reportTitleIncome">
                    <span>Case ID</span></td>
                <td colspan="2" class="Info">
                    <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="132px"></asp:TextBox></td>
                <td colspan="1">
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td class="bx" style="width: 20px">
                </td>
                <td class="reportTitleIncome" style="width: 295px">
                    <span>
                    Ref No</span></td>
                <td class="Info" colspan="2">
                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" Width="132px"></asp:TextBox></td>
                <td colspan="1" style="font-size: 10pt; font-family: Arial">
                </td>
                <td colspan="1" style="font-size: 10pt; font-family: Arial">
                </td>
            </tr>
            <tr style="font-size: 10pt; font-family: Arial">
                <td class="bx" style="width: 20px; height: 24px">
                </td>
                <td style="width: 295px; height: 24px" class="reportTitleIncome">
                    <span>Verification Type</span></td>
                <td colspan="2" class="Info">
                    <asp:DropDownList ID="ddlVerificationTypeID" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlVerificationTypeID_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="height: 24px">
                </td>
                <td colspan="1" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td class="bx" style="width: 20px; height: 22px">
                </td>
                <td style="width: 295px; height: 22px;" class="reportTitleIncome">
                    <span>Sub Verification Type</span></td>
                <td colspan="2" class="Info">
                    <asp:DropDownList ID="ddlSubVerificationTypeID" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="1" style="height: 22px">
                </td>
                <td colspan="1" style="height: 22px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="6" style="height: 22px">
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Font-Bold="True" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td class="bx" colspan="1" style="width: 20px; height: 16px">
                </td>
                <td colspan="2" style="width: 126px; height: 16px;">
                </td>
                <td style="width: 345px; height: 16px">
                </td>
                <td style="width: 345px; height: 16px">
                </td>
                <td style="width: 345px; height: 16px">
                </td>
            </tr>
        </table>
</asp:Content>
