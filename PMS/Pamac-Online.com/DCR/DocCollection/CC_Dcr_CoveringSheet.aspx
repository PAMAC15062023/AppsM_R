<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" Theme="SkinFile" CodeFile="~/DCR/DocCollection/CC_Dcr_CoveringSheet.aspx.cs" Inherits="DCR_DocCollection_CC_Dcr_CoveringSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript"></script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10px; height: 254px;">
<fieldset><legend class="FormHeading">Covering Sheet</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td style="width: 249px">
    <strong>From Date</strong>&nbsp;
    <asp:TextBox ID="txtFDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td style="width: 422px">
    &nbsp;&nbsp; <strong>To Date</strong>&nbsp;
    <asp:TextBox ID="txtTDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtTDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
    <%--&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<strong>Centre &nbsp;
        <asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter" DataTextField="CENTRE_NAME"
            DataValueField="CENTRE_ID" SkinID="ddlSkin">
        </asp:DropDownList></strong>--%></td>
<td><asp:Button ID="btnsearch" Text="Search" SkinID="btnSearchSkin" runat="server" OnClick="btnsearch_Click"/></td>
<td><asp:Button ID="btnExport" runat="server" SkinID="btnGenerateExcelReportSkin" Text="Export To Excel" OnClick="btnExport_Click" /></td>
</tr>
<tr> <td style="width: 249px"><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>
    &nbsp;
    <asp:GridView ID="gvtc" runat="server" SkinID="gridviewSkin" Width="915px" AutoGenerateColumns="True">
        <%--<Columns>
            <asp:BoundField DataField="Application No" HeaderText="Application No" />
            <asp:BoundField DataField="Call Center" HeaderText="Call Center" />
            <asp:BoundField DataField="Bsn Number" HeaderText="Bsn Number" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
            <asp:BoundField DataField="Docs" HeaderText="Docs" />
            <asp:BoundField DataField="Send Date" HeaderText="Send Date" />
            <asp:BoundField DataField="Remark" HeaderText="Remark" />
        </Columns>--%>
    </asp:GridView>
      
</td>
</tr>
</table>


 <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grValidateDate" />
    &nbsp;&nbsp;
    </fieldset>
</td>
</tr>
</table>
</asp:Content>

