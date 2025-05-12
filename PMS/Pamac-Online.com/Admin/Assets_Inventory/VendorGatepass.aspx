<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="VendorGatepass.aspx.cs" Inherits="Admin_Assets_Inventory_VendorGatepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
    </table>

    <table style="width: 688px;">
        <tr>
            <td class="tta" colspan="9">
                <span style="font-size: 10pt">Vendor Gatepass</span></td>
        </tr>
    </table>

    <table style="width: 850px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">Transaction ID
                    &nbsp;</td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:TextBox ID="txtTransRefNo" runat="server" OnTextChanged="txtTransRefNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
            </tr> 
        </table>

        <table style="width: 688px;">
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">Gate Pass
                    &nbsp;</td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:TextBox ID="txtGatePass" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">
                    <asp:Label ID="lblMachineCollectedBy" runat="server">Name of the vendor who collected the machine</asp:Label>
                </td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:TextBox ID="txtMachineCollectedBy" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">
                    <asp:Label ID="lblDate" runat="server">Date on which system collected by vendor</asp:Label>
                </td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" ValidationGroup="grpSearch"
                        Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">
                    <asp:Label ID="lblRegister" runat="server">Is the outward register updated</asp:Label>
                </td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:DropDownList ID="ddlRegister" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 344px; height: 42px">
                    <asp:Label ID="lblRegisterUpdatedBy" runat="server">Name of the person who updated outward register</asp:Label>
                </td>
                <td class="Info" style="width: 344px; height: 42px">
                    <asp:TextBox ID="txtRegisterUpdatedBy" runat="server" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="tta" colspan="9" style="height: 6px">
                    <asp:Button ValidationGroup="validdata" Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo"
                        ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ValidationGroup="validdata" Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo"
                         ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                     <asp:Button ValidationGroup="validdata" Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo"
                         ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

