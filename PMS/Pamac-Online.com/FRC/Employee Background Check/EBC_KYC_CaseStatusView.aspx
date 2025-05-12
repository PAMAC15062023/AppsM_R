<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_KYC_CaseStatusView.aspx.cs" Inherits="FRC_Employee_Background_Check_EBC_KYC_CaseStatusView" Title="KYC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
  <table style="width: 842px; height: 13px">
        <tr>
            <td>
            </td>
        </tr>
    <tr>
    <td class="topbar">
    KYC SubVerification View
    </td>
    </tr>
        <tr>
            <td>
               <asp:GridView ID="gvCaseStatusView" SkinID="gridviewSkin" runat="server" Width="99%" AutoGenerateColumns="False" OnRowDataBound="gvCaseStatusView_RowDataBound" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" CssClass="mGrid" ForeColor="Black" HorizontalAlign="Justify" OnPageIndexChanging="gvCaseStatusView_PageIndexChanging" OnRowCommand="gvCaseStatusView_RowCommand" OnRowCreated="gvCaseStatusView_RowCreated">
        <Columns>
            <asp:BoundField HeaderText="Case ID" DataField="CASE_ID" />
            <asp:BoundField HeaderText="Ref No" DataField="REF_NO" />
            <asp:BoundField HeaderText="Applicant Name" DataField="Applicant_Name" />
            <asp:BoundField HeaderText="Verification" DataField="SUBVERIFICATION_CODE" />
            <asp:TemplateField HeaderText="SelectSubVerificationType">
                <ItemTemplate>
                    <asp:Label ID="lblVI" runat="server" Text="VI" Visible="false" />
                    <asp:Label ID="lblSlashVI" runat="server" Width="9px" Visible="False" ForeColor="Blue"></asp:Label>
                    
                    <asp:Label ID="lblPP" runat="server" Text="PP" Visible="false" />
                    <asp:Label ID="lblSlashPP" runat="server" Width="9px" Visible="False" ForeColor="Blue"></asp:Label>
                    
                    <asp:Label ID="lblPC" runat="server" Text="PC" Visible="false" />
                    <asp:Label ID="lblSlashPC" runat="server" Width="9px" Visible="False" ForeColor="Blue"></asp:Label>
                    
                    <asp:Label ID="lblDLV" runat="server" Text="DLV" Visible="false" />
                    <asp:Label ID="lblSlashDLV" runat="server" Width="9px" Visible="False" ForeColor="Blue"></asp:Label>
                   
                    <asp:Label ID="lblGDS" runat="server" Text="GDS" Visible="false" />
                    <asp:Label ID="lblSlashGDS" runat="server" Width="9px" Visible="False" ForeColor="Blue"></asp:Label>
                   
                     
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdnCaseID" runat="server" />
                <asp:HiddenField ID="hdnName" runat="server" />
                <asp:HiddenField ID="hdnRefNo" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

