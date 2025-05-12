<%@ Page Language="VB" Theme="SkinFile" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="false" CodeFile="~/FRC/Employee Background Check/EBC_SendDateNull.aspx.vb" Inherits="CPV_EBC_EBC_SendDateNull" title="Send Date Null Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table>
        <tr>
            <td colspan="9" style="height: 18px">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="9">
                EBC Case Reopen</td>
        </tr>
        <tr>
            <td style="width: 15px">
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
            <td style="width: 15px">
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
            <td style="width: 15px">
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
            Text="Search" />
    <asp:Button ID="btnReopen"  runat="server"
                Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Text="Reopen" /></td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 82px">
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 15px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 82px">
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    &nbsp;


</asp:Content>

