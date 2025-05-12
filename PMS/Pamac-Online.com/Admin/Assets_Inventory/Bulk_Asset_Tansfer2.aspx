<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="Bulk_Asset_Tansfer2.aspx.cs" Inherits="Admin_Assets_Inventory_Bulk_Asset_Tansfer2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 688px;">
        <tr>
            <td class="tta" colspan="9">
                <span style="font-size: 10pt">Bulk Asset Transfer Employee To Employee</span></td>
        </tr>
    </table>

    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 94px; height: 42px">Select File&nbsp;</td>

                <td class="Info" style="width: 111px; height: 42px">
                    <asp:FileUpload ID="xslFileUpload" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="9" style="height: 6px">
                    <asp:Button ID="btnImportPost" runat="server" Text="Import" ValidationGroup="validdata"
                        Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo" OnClick="btnImportPost_Click" />&nbsp; 
                    <asp:Button ID="btnCancelPost" runat="server" Text="Cancel" Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo" />&nbsp;
                    <asp:Button ID="btnBackPost" runat="server" Text="Back" Font-Bold="True" ForeColor="Indigo" Width="90px" OnClick="btnBackPost_Click" />&nbsp;
                     <asp:Button ID="btnDownloadUploadFormatPost" runat="server" Text="Download Excel Upload Format"
                         Height="24px" Width="270px" Font-Bold="True" ForeColor="Indigo" OnClick="btnDownloadUploadFormatPost_Click"   />
                    &nbsp;&nbsp;&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="xslFileUpload"
        Display="None" ErrorMessage="Select Import File" SetFocusOnError="True" ValidationGroup="validdata"></asp:RequiredFieldValidator>
    &nbsp;<asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="validdata" />
</asp:Content>

