<%@ Page Language="C#" MasterPageFile="~/Master/FTP/FTP_Dynamic/MasterPage.master" AutoEventWireup="true" Theme="SkinFile" StylesheetTheme="SkinFile" CodeFile="FTP_ReviewReport.aspx.cs" Inherits="FTP_FTP_Dynamic_FTP_ReviewReport" Title="FTP Review Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table  border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table id="tblExport" align="center" width="100%" style="height: 312px">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="topbar" colspan="12" style="height: 35px">
                    &nbsp;FTP Review Report</td>
            </tr>
            <tr>
                <td colspan="7">
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" SkinID="lblErrorMsg" Font-Bold="True" Font-Size="9pt" Width="468px"></asp:Label></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td class="Info" >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td class="reportTitleIncome" >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td class="Info">
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
                </td>
                <td><asp:Button ID="btnSearch" ValidationGroup="grValidateDate" runat="server" Text="Search" OnClick="btnSearch_Click" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                    <span style="color: #ff0033">* </span><strong><span style="font-size: 8pt">Indicate mandatory fields</span></strong>.</td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="100%" Height="178px">
                        <asp:GridView ID="GridView1" runat="server" Width="851px" Height="31px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <RowStyle ForeColor="#000066" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 21px">
                        <asp:Button ID="btnExportExcel" runat="server" Font-Bold="True" Text="Export To Excel" OnClick="btnExportExcel_Click" /></td>
            </tr>
        </table>
         <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>&nbsp;
        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>

        <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ValidationGroup="grValidateDate" ShowSummary="False" Width="205px" />
    

                   
        </fieldset>
        </td></tr></table>
</asp:Content>

