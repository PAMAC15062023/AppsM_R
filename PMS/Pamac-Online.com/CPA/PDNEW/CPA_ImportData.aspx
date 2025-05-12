<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_ImportData.aspx.cs" StylesheetTheme="SkinFile" Inherits="CPA_PD_CPA_ImportData" Title="Import Data File" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
     
    <table>
        <tr>
            <td colspan="9">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" SkinID="lblSkin" Width="100%" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 17px">
                &nbsp;Centralise Import Excel File</td>
        </tr>
        <tr>
            <td style="width: 2px">
                &nbsp;
            </td>
            <td class="reportTitleIncome" style="width: 194px">
                &nbsp;Import File (.xls)</td>
            <td colspan="5">
                <asp:FileUpload ID="FileUpload_Xls" runat="server" SkinID="flup" TabIndex="1" Width="469px" />
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr src="../../Images/SmallCalendar.png">
            <td style="width: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 194px">
                &nbsp;Case Received Date</td>
            <td class="Info" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtCaseReceivedDate" runat="server" Width="64px" SkinID="txtSkin" TabIndex="2"></asp:TextBox></td>
                        <td style="width: 100px">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCaseReceivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 194px">
                &nbsp;Case Received Time</td>
            <td class="Info" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 83px">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                <asp:TextBox ID="txtCaseReceivedTime" runat="server" Width="40px" SkinID="txtSkin" TabIndex="3"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                            &nbsp;[hh:mm]</td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 25px">
                &nbsp;
                <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" SkinID="btn" TabIndex="4" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btn" TabIndex="5" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="9" style="height: 16px">
                <asp:Label ID="lblCount" runat="server" ForeColor="Red" SkinID="lblSkin" Width="100%" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="9">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="980px" Height="300px">
                <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin">
                </asp:GridView>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 194px">
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
            <td style="width: 99px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

