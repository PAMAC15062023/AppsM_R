<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true"
    CodeFile="Import.aspx.cs" Inherits="HR_HR_Import" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <table>
        <tr>
            <td style="height: 25px; width: 871px;">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    <table border="2px">
        <tr style="color: #000000">
            <td style="width: 113px; height: 41px">
                <strong>File To Import :</strong></td>
            <td style="width: 315px; height: 41px">
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="281px" Height="25px"
                    SkinID="flup" />
            </td>
            <td style="width: 94px; height: 41px">
                <strong>Import Date :</strong></td>
            <td style="width: 337px; height: 41px">
                <asp:TextBox ID="txtdate" runat="server" Width="161px" Height="21px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]
            </td>
        </tr>
        <tr>
            <td style="width: 113px; height: 41px">
                <asp:Button ID="BtnImport" runat="server" Text="Import" BorderColor="black" BorderWidth="1Px"
                    Font-Bold="true" Width="105px" Height="25px" OnClick="BtnImport_Click1" />
                <%--  <asp:Button ID="BtnImport" runat="server" Text="Import"  BorderColor="#400000" BorderWidth="1px" Font-Bold="True"  Width="105px" Height="25px" OnClick="BtnImport_Click"  />--%>
            </td>
            <td style="width: 315px">
            </td>
        </tr>
    </table>
</asp:Content>
