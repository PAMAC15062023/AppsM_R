<%@ Page Language="C#" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" AutoEventWireup="true" Theme="skinFile" CodeFile="~/DCR/DocCollection/CaseStatusView.aspx.cs" Inherits="CPV_CC_CaseStatusView" %>
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
<fieldset><legend class="FormHeading">Case Status View</legend>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
<tr>
<td>
Ref No.
</td>
<td>
<asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
</td>
<td>
Case ID
</td>
<td>
<asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox>
</td>
<td>
Applicant Name
</td>
<td>
<asp:TextBox ID="txtApplicantName" runat="server" SkinID="txtSkin" MaxLength="150"></asp:TextBox>
</td>
<td>
<asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click"/>
</td>
</tr>
</table>
<table  border="0" cellpadding="0" cellspacing="0" width="99%">
<tr></tr>
<tr>
<td>
    <asp:GridView ID="gvCaseStatusView" SkinID="gridviewSkin" runat="server" Width="99%" AutoGenerateColumns="False" OnRowCommand="gvCaseStatusView_RowCommand" OnRowCreated="gvCaseStatusView_RowCreated" OnRowDataBound="gvCaseStatusView_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvCaseStatusView_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Case ID" DataField="CASE_ID" />
            <asp:BoundField HeaderText="Ref No" DataField="REF_NO" />
            <asp:BoundField HeaderText="Applicant Name" DataField="Applicant_Name" />
            <asp:BoundField HeaderText="Verification Type" DataField="VERIFICATION_CODE" />
            <asp:TemplateField HeaderText="Select Verification Type">
                <ItemTemplate>
                    <asp:Label ID="lblRV" runat="server" Text="Altc" Visible="false" />
                    <asp:Label ID="lblSlashRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblBV" runat="server" Text="PM" Visible="false" />
                    <asp:Label ID="lblSlashBV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblRT" runat="server" Text="Alop" Visible="false" />
                    <asp:Label ID="lblSlashRT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblBT" runat="server" Text="Blop" Visible="false" />
                    <asp:Label ID="lblSlashBT" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                   
                    <asp:Label ID="lblPRV" runat="server" Text="Stock" Visible="false" />
                    <asp:Label ID="lblSlashPRV" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblAegon" runat="server" Text="Aegon" Visible="false" />
                    <asp:Label ID="lblSlashAegon" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblMetlife" runat="server" Text="Metlife" Visible="false" />
                    <asp:Label ID="lblSlashMetlife" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblMetNor" runat="server" Text="MetNor" Visible="false" />
                    <asp:Label ID="lblSlashMetNor" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblMetTopup" runat="server" Text="MetTopup" Visible="false" />
                    <asp:Label ID="lblSlashMetTopup" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblMetECS" runat="server" Text="MetECS" Visible="false" />
                    <asp:Label ID="lblSlashMetECS" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                    <asp:Label ID="lblPB" runat="server" Text="PB" Visible="false" />
                    <asp:Label ID="lblSlashPB" runat="server" Width="9px" Visible="False" ForeColor="Blue">/</asp:Label>
                    
                   <%-- <asp:Label ID="lblPRTV" runat="server" Text="PRTV" Visible="false" />                 --%>
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
</table>
</asp:Content>

