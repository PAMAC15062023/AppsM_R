<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" Theme="skinFile" CodeFile="~/FRC/Employee Background Check/EBC_CaseStatusView.aspx.cs" Inherits="CPV_EBC_EBC_CaseStatusView"  StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%" >
<tr>
<td style="padding-left:10px">
<fieldset><legend class="FormHeading"></legend>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
    <tr>
        <td class="topbar" colspan="12" style="height: 35px">
            &nbsp; EBC Case Status View</td>
    </tr>
    <tr>
        <td style="width: 50px; height: 4px">
        </td>
        <td style="width: 100px; height: 4px">
        </td>
        <td colspan="2" style="height: 4px">
        </td>
        <td style="width: 100px; height: 4px">
        </td>
        <td colspan="2" style="height: 4px">
        </td>
        <td style="width: 100px; height: 4px">
        </td>
        <td colspan="2" style="height: 4px">
        </td>
        <td style="width: 100px; height: 4px">
        </td>
        <td style="width: 100px; height: 4px">
        </td>
    </tr>
    <tr>
        <td style="width: 50px; height: 4px">
        </td>
        <td class="reportTitleIncome" style="width: 100px; height: 4px">
Case ID</td>
        <td class="Info" colspan="2" style="height: 4px">
            <asp:TextBox ID="txtCaseID" runat="server"></asp:TextBox></td>
        <td class="reportTitleIncome" style="width: 100px; height: 4px">
            Ref. No.</td>
        <td class="Info" colspan="2" style="height: 4px">
            <asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox></td>
        <td class="reportTitleIncome" style="width: 100px; height: 4px">
Applicant Name</td>
        <td class="Info" colspan="2" style="height: 4px">
            <asp:TextBox ID="txtApplicantName" runat="server"></asp:TextBox></td>
        <td style="width: 100px; height: 4px">
<asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click"/></td>
        <td style="width: 100px; height: 4px">
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btnCancelSkin"
                Text="Cancel" /></td>
    </tr>
    <tr>
        <td style="width: 50px; height: 19px">
        </td>
        <td style="width: 100px; height: 19px">
        </td>
        <td style="height: 19px">
        </td>
        <td style="width: 78px; height: 19px">
        </td>
        <td style="height: 19px">
        </td>
        <td style="height: 19px">
        </td>
        <td style="width: 155px; height: 19px">
        </td>
    </tr>
    <tr>
        <td style="width: 50px">
        </td>
        <td style="width: 100px">
        </td>
        <td>
        </td>
        <td style="width: 78px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 155px">
        </td>
    </tr>
</table>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
<tr></tr>
<tr>
<td>
    <asp:GridView ID="gvCaseStatusView" SkinID="gridviewSkin" runat="server" Width="99%" AutoGenerateColumns="False" OnRowCommand="gvCaseStatusView_RowCommand" OnRowCreated="gvCaseStatusView_RowCreated" OnRowDataBound="gvCaseStatusView_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvCaseStatusView_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" CssClass="mGrid" ForeColor="Black">
        <Columns>
            <asp:BoundField HeaderText="Case ID" DataField="CASE_ID" />
            <asp:BoundField HeaderText="Ref No" DataField="REF_NO" />
            <asp:BoundField HeaderText="Applicant Name" DataField="Applicant_Name" />
            <asp:BoundField HeaderText="Verification Type" DataField="VERIFICATION_CODE" />
            <asp:TemplateField HeaderText="Select Verification Type">
                <ItemTemplate>
                    <asp:Label ID="lblRAV" runat="server" Text="RAV" Visible="false" />
                    <asp:Label ID="lblSlashRAV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblEBC" runat="server" Text="EBC" Visible="false" />
                    <asp:Label ID="lblSlashEBC" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblEMV" runat="server" Text="EMV" Visible="false" />
                    <asp:Label ID="lblSlashEMV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblCRV" runat="server" Text="CRV" Visible="false" />
                    <asp:Label ID="lblSlashCRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblCCV" runat="server" Text="CCV" Visible="false" />
                    <asp:Label ID="lblSlashCCV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblCRCV" runat="server" Text="CRCV" Visible="false" />
                    <asp:Label ID="lblSlashCRCV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblRef_Chk" runat="server" Text="Ref_Chk" Visible="false" />
                    <asp:Label ID="lblSlashRef_Chk" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblKYC" runat="server" Text="KYC" Visible="false" />
                    <asp:Label ID="lblSlashKYC" runat="server" Width="9px" Visible="false" ForeColor="Blue">/</asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
</td>
</tr>
</table>
    <asp:HiddenField ID="hidCurrentIndex" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"  />
</fieldset>
</td>
</tr>
    <tr>
        <td style="padding-left: 10px">
        </td>
    </tr>
</table>
</asp:Content>

