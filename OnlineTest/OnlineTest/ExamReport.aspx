<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="ExamReport.aspx.cs" Inherits="OnlineTest.ExamReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="App_Assets/js/popcalendar.js"></script>
    &nbsp;&nbsp;
    <table style="width: 1170px;">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" id="header1" runat="server" style="font-size: medium">Exam Report </td>
        </tr>

    </table>
    <asp:Panel ID="Mainpanel" runat="server">
        <table>
            <tr>
                <td style="width: 170px" class="TableTitle">
                    <asp:Label ID="lblUserId" runat="server" Text="User ID"
                        Style="font-weight: 700; font-size: small"></asp:Label></td>
                <td style="width: 170px" class="TableGrid">
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
            </tr>
            <tr>
                <td style="width: 170px" class="TableTitle">
                    <asp:Label ID="lblQuestionpaper" runat="server" Text="Select Question Paper "
                        Style="font-weight: 700; font-size: small"></asp:Label></td>
                <td style="width: 170px" class="TableGrid">
                    <asp:DropDownList ID="ddlQuestionpaper" runat="server" Style="width: 177px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
            </tr>
            <tr>
                <td style="width: 170px" class="TableTitle">
                    <asp:Label ID="lblFromDate" runat="server" Text="From Date"
                        Style="font-weight: 700; font-size: small"></asp:Label></td>
                <td style="width: 170px" class="TableGrid">
                    <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="170px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
            </tr>
            <tr>
                <td style="width: 170px" class="TableTitle">
                    <asp:Label ID="lblToDate" runat="server" Text="To Date"
                        Style="font-weight: 700; font-size: small"></asp:Label></td>
                <td style="width: 170px" class="TableGrid">
                    <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="170px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px" class="TableTitle"></td>
            </tr>
            <tr>
                <td colspan="4" class="TableGrid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnsubmit" runat="server"
                        OnClick="btnsubmit_Click" Text="Search" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server"
                    OnClick="btncancel_Click" Text="Back" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel"
                        OnClick="btnExportToExcel_Click" />
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
        </table>
        <table>
            <tr>
                <td class="TableHeader" style="width: 354px">
                    <b>RESULTS</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcount" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 354px">
                    <asp:GridView ID="grdresults" runat="server" AutoGenerateColumns="true" Visible="true"
                        CssClass="mGrid" Width="711px" Height="37px">
                    </asp:GridView>

                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnqnno" runat="server" />
    </asp:Panel>
</asp:Content>
