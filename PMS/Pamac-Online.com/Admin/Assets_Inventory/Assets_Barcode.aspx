<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="Assets_Barcode.aspx.cs" Inherits="Admin_Assets_Inventory_Assets_Barcode" Title="Assets Barcode" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table style="width: 949px">
        <tr>
            <td class="topbar" colspan="8" style="height: 28px">
                Assets Inventory Barcode Tracker</td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Employee ID</td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:TextBox ID="txtempid" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                Center Name</td>
            <td style="width: 100px; height: 16px;" class="Info">
                <asp:DropDownList ID="ddlCentreList" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlCentreList_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
                <asp:Button ID="btnGenBarcode" runat="server" Font-Bold="True" OnClick="btnGenBarcode_Click"
                    SkinID="btn" Text="Genrate Barcode" /></td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 100px" class="reportTitleIncome">
                Subcentre Name</td>
            <td style="width: 100px" class="Info"><asp:DropDownList ID="ddlsubcentrelist" runat="server" SkinID="ddlSkin">
            </asp:dropdownlist></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Assets Name</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlverticalname" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 16px">
            </td>
            <td colspan="3" style="height: 16px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
    </table>
</asp:Content>

