<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Invoice Upload Details.aspx.cs" Inherits="ERGO_ERGO_Invoice_Upload_Details" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tta" colspan="3" rowspan="" style="width: 357px">
                &nbsp;Invoice Excel Data Import</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 157px" class="reportTitleIncome">
                Select Excel File Data</td>
            <td colspan="2" class="Info">
                <asp:FileUpload ID="FileUpload_Xls" runat="server" Width="230px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" class="TableTitle">
                <asp:Button ID="btnImportData" runat="server" onclick="btnImportData_Click" 
                    Text="Import Excel" BorderWidth="1px" />
&nbsp;
                <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" 
                    BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <asp:GridView ID="GridView1" runat="server" 
    Height="79px" SkinID="gridviewNoSort">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>


