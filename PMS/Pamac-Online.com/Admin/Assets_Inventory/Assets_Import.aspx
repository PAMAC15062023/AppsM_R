<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="Assets_Import.aspx.cs" Inherits="Admin_Assets_Import" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table style="width: 438px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="325px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5" class="tta">
                Asset Upload</td>
        </tr>
        <tr>
            <td style="width: 86px" class="reportTitleIncome">
                Centre</td>
            <td style="width: 88px" class="Info">
                <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" SkinID="ddlSkin" Width="120px">
                </asp:DropDownList></td>
            <td class="reportTitleIncome">
                Subcentre</td>
            <td style="width: 123px" class="Info">
                <asp:DropDownList ID="ddlSubCentre" runat="server" SkinID="ddlSkin" Width="129px">
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 86px; height: 11px" class="reportTitleIncome">
                Upload File</td>
            <td colspan="3" style="height: 11px" class="Info">
                <asp:FileUpload ID="FileUpload1" runat="server" Height="23px" Width="244px" SkinID="flup" /></td>
            <td style="height: 11px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 7px" class="tta">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="68px" OnClick="btnUpload_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="71px" /></td>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td style="width: 86px; height: 21px">
            </td>
            <td style="height: 21px; width: 88px;">
            </td>
            <td style="height: 21px">
            </td>
            <td style="width: 123px; height: 21px">
            </td>
            <td style="height: 21px">
            </td>
        </tr>
    </table>
</asp:Content>

