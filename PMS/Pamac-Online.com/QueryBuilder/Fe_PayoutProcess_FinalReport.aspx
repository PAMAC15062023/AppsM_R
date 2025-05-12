<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true" CodeFile="Fe_PayoutProcess_FinalReport.aspx.cs" Inherits="QueryBuilder_Fe_PayoutProcess_FinalReport" Title="Fe Payout Process Final Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 94px">
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px">
            </td>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" BackColor="White" Font-Bold="True" Font-Size="Larger"
                    ForeColor="Red" Width="280px"></asp:Label></td>
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
            <td style="width: 8px">
            </td>
            <td style="width: 94px">
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 8px; height: 18px">
            </td>
            <td colspan="5" style="height: 18px">
                <strong><span style="font-size: 10pt">FE - PAYOUT PROCESS FINAL REPORT</span></strong></td>
            <td style="width: 100px; height: 18px;">
            </td>
            <td style="width: 100px; height: 18px;">
            </td>
            <td style="width: 100px; height: 18px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
            <td style="width: 94px; height: 16px">
            </td>
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
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
            <td style="width: 94px; height: 16px">
            </td>
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
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
            <td style="width: 94px; height: 16px">
                From Date :</td>
            <td style="width: 100px; height: 16px">
                <asp:TextBox ID="txtFromDate" runat="server" Width="104px"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.png" /></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
                To Date :</td>
            <td style="width: 100px; height: 16px">
                <asp:TextBox ID="txtToDate" runat="server" Width="104px"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.png" /></td>
            <td style="width: 100px; height: 16px">
                </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
            <td style="width: 94px; height: 16px">
            </td>
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
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 16px">
            </td>
            <td style="width: 94px; height: 16px">
                <asp:Button ID="btnGenRepo" runat="server" Font-Bold="True" Text="Genrate Report"
                    Width="129px" OnClick="btnGenRepo_Click" /></td>
            <td style="width: 100px; height: 16px">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="102px" Font-Bold="True" OnClick="btnCancel_Click" /></td>
            <td style="width: 100px; height: 16px"><asp:Button ID="Button1" runat="server" Font-Bold="True" Text="Genrate Report Old"
                    Width="154px" OnClick="Button1_Click" /></td>
            <td style="width: 100px; height: 16px">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generate Report Clientwise" /></td>
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
            <td style="width: 8px">
            </td>
            <td style="width: 94px">
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 94px">
                <asp:GridView ID="GV1" runat="server">
                </asp:GridView>
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td style="width: 94px">
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

