<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="SalaryImport_Data.aspx.cs" Inherits="QueryBuilder_SalaryImport_Data" Title="HR_Salary_Import" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <fieldset><legend class="FormHeading">Salary Import Data</legend>
    <table style="width: 564px; height: 59px">
        <tr>
            <td colspan="3" style="height: 16px; width: 853px;">
                <asp:Label ID="lblMessage" runat="server" Width="705px" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 3px; width: 853px;">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 27px; width: 853px;">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="450px" Font-Bold="True" Height="27px" SkinID="flup" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="103px" OnClick="btnUpload_Click" Font-Bold="True" Height="25px" /></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 129px; width: 853px;">
              <asp:Panel ID="PnlData" runat="server" ScrollBars="Both" Width="850px" Height="162px">
                <asp:GridView ID="GrdSalary" runat="server" Width="829px" SkinID="gridviewExportSkin" CellPadding="4" ForeColor="#333333" GridLines="None" Height="137px">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                  <br />
               </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 26px; width: 853px;">
                <asp:Button ID="btnSave" runat="server" Text="Save & Update" Width="141px" OnClick="btnSave_Click" Font-Bold="True" Height="26px" />
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:HiddenField ID="hdnfile" runat="server" Value="0" Visible="False" />
            </td>
        </tr>
    </table>
    </fieldset> 
</asp:Content>

