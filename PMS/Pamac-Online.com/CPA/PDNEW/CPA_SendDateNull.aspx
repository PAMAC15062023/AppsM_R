<%@ Page Language="VB" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="false" CodeFile="CPA_SendDateNull.aspx.vb" Inherits="CPA_PD_CPA_SendDateNull" title="CPA Cases Reopen" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
  <table>
        <tr>
            <td class="topbar" colspan="9">
                CPA Case Reopen</td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class=" reportTitleIncome" style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Case ID" Width="125px"></asp:Label></td>
            <td class="Info" style="width: 82px">
                    <asp:TextBox ID="txtCaseId" runat="server" Width="118px" SkinID="txtSkin" Font-Size="Medium" Height="16px"></asp:TextBox></td>
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                &nbsp;Ref No</td>
            <td class="Info" style="width: 82px">
                    <asp:TextBox ID="txtRefNo" runat="server" Width="118px" SkinID="txtSkin"  Font-Size="Medium" Height="16px"></asp:TextBox></td>
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                &nbsp;Applicant Name</td>
            <td class="Info" style="width: 82px">
                    <asp:TextBox ID="txtAppName" runat="server" Width="160px" SkinID="txtSkin" Font-Size="Medium" Height="16px"></asp:TextBox></td>
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 26px">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Font-Bold="True"
            Text="Search" SkinID="btnSearchSkin" />
    <asp:Button ID="btnReopen"  runat="server"
                Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Text="Reopen" SkinID="btnSearchSkin" /></td>
        </tr>
    </table>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ErrorMessage" Width="430px" Height="20px"></asp:Label><br />
    &nbsp;

</asp:Content>

