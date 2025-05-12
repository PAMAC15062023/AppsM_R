<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Billing_ImportExcelData.aspx.cs" Inherits="ERGO_ERGO_Billing_ImportExcelData" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tta" colspan="5" rowspan="" style="width: 357px">
                &nbsp; 
                Billing Excel Data Import</td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 157px">
                <strong>Select Type</strong></td>
            <td style="width: 157px" class="Info">
                <asp:DropDownList ID="ddlExcelType" runat="server" Width="104px" SkinID="ddlSkin">
                    <asp:ListItem Value="1">Normal</asp:ListItem>
                    <asp:ListItem Value="2">Split Bill</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="reportTitleIncome" style="width: 157px">
             <strong> Select Excel File Data</strong></td>
            <td class="Info">
                <asp:FileUpload ID="FileUpload_Xls" runat="server" Width="230px" SkinID="flup" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 17px">
                </td>
            <td style="height: 17px">
                </td>
            <td style="height: 17px">
                </td>
        </tr>
        <tr>
            <td colspan="5" class="reportTitleIncome">
                <asp:Button ID="btnImportData" runat="server" onclick="btnImportData_Click" 
                    Text="Import Excel" BorderWidth="1px" />
&nbsp;
                <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" 
                    BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <asp:GridView ID="GridView1" runat="server" 
    Height="79px" SkinID="gridviewNoSort">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

