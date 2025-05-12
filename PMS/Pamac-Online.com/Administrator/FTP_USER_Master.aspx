<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="FTP_USER_Master.aspx.cs" Inherits="Administrator_FTP_USER_Master" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend class="FormHeading">PAMAC HOME OFFICE USER MASTER</legend>
    <table style="width: 941px">
        <tr>
            <td colspan="6">
                <asp:Label ID="StatusLabel" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 11px; height: 16px">
                From</td>
            <td style="width: 100px; height: 16px">
                <asp:TextBox ID="TextBox1" runat="server" Width="97px"></asp:TextBox></td>
            <td colspan="4" rowspan="2">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
                To</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server" Width="97px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" /></td>
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
            <td colspan="6" rowspan="2">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
        </tr>
    </table>

</fieldset>
</asp:Content>

