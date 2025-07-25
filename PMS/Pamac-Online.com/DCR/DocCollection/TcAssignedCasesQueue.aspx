<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" Theme="SkinFile" CodeFile="~/DCR/DocCollection/TcAssignedCasesQueue.aspx.cs" Inherits="CPV_CC_TcAssignedCasesQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
</script>
<%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px">--%>
<fieldset><legend class="FormHeading">Tc Assigned Cases Queue</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td style="height: 38px"> From Date:</td><td style="width: 200px; height: 38px;"><asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]
</td><td style="height: 38px">To Date: </td>
<td style="width: 187px; height: 38px;"><asp:TextBox ID="txttodate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txttodate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy] &nbsp;</td>
<td style="width: 144px; height: 38px;">
    <strong>Centre</strong><asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter"
        DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin">
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;
    </td>
<td style="width: 244px; height: 38px;"><asp:Button ID="Button1" Text="Search" runat="server" OnClick="btnsearch_Click" />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" Width="110px" />
    <asp:Button ID="BtnRefresh" Text="Refresh" runat="server" OnClick="BtnRefresh_Click" Width="60px"/></td>
</tr>
<tr> <td><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>

<asp:GridView ID="gvtc" runat="server" SkinID="gridviewSkin" Width="99%" AutoGenerateColumns="False" OnRowDataBound="gvtc_RowDataBound">
<Columns>
<asp:BoundField HeaderText="Case ID" DataField="case_id" />
<asp:BoundField HeaderText ="Ref No" DataField ="ref_no" />
<asp:BoundField HeaderText="Client Name" DataField="client_name" />
<asp:BoundField HeaderText="Centre Name" DataField="Centre_name" />
<asp:BoundField HeaderText="Applicant Name" DataField="applicant_name" />
<asp:BoundField HeaderText="Verification Type" DataField="verification_type_code" />
<asp:BoundField DataField="Remark" HeaderText="Feedback Status" />    
<asp:BoundField DataField="SubRemark" HeaderText="Remark" />
     <asp:TemplateField HeaderText="Updation Link">
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
                   <%-- <asp:Label ID="lblPRTV" runat="server" Text="PRTV" Visible="false" />                 --%>
                </ItemTemplate>
            </asp:TemplateField>
</Columns>
</asp:GridView>

</td>
</tr>
</table>


 <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    <asp:SqlDataSource ID="sdsCenter" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="Select CENTRE_ID, CENTRE_NAME from centre_master order by CENTRE_NAME">
    </asp:SqlDataSource>
</fieldset>
<%--</td></tr>
</table>--%>
</asp:Content>