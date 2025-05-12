<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_ImportToData.aspx.cs"  Inherits="HR_HR_HR_ImportToData" Title="Biometric Entry"    %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> <script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
    <table style="width: 740px; height: 188px">
        <tr>
            <td colspan="6" class="tta">
                HR Data Entry Biometric</td>
        </tr>
        <tr>
            <td colspan="6" style="height: 15px">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#C00000"
                    SkinID="lblSkin"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 146px" class="reportTitleIncome">
                From Date</td>
            <td style="width: 238px" class="Info">
                <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td class="reportTitleIncome">
                &nbsp;ToDate &nbsp;&nbsp;
            </td>
            <td class="Info">
                <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTodate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td style="width: 4px">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Button ID="Button1" runat="server" Height="36px" Text="Proceed" Width="96px" SkinID="btnUploadSkin" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 146px">
            </td>
            <td style="width: 238px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 4px">
            </td>
        </tr>
    </table>
</asp:Content>

