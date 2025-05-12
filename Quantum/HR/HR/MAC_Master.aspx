<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="MAC_Master.aspx.cs" Inherits="HR_HR_MAC_Master" Title="MAC Master" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <fieldset ><legend class="FormHeading" style="color: #663300">MAC Master</legend>   
    <table>
        <tr>
            <td colspan="1" style="width: 10px">
            </td>
            <td colspan="9">
                </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 15px;">
            </td>
            <td style="width: 116px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 10px">
            </td>
            <td colspan="3">
                <asp:Label ID="Lblmsg" runat="server" SkinID="lblSkin" Font-Bold="True" ForeColor="#004000"></asp:Label></td>
            <td colspan="6" align="left">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="#004000"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td align="left" colspan="6" rowspan="9">
                <asp:Panel ID="pnlmac" runat="server" Height="400px" ScrollBars="Vertical" Width="450px">
                    <asp:GridView ID="grdMAC" runat="server" BackColor="#DEBA84" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" ForeColor="#400040">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <RowStyle BackColor="#FFF7E7" BorderStyle="None" ForeColor="#400000" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#FFE0C0" Font-Bold="True" ForeColor="#400040" HorizontalAlign="Center" />
                    </asp:GridView>
                </asp:Panel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 10px; height: 28px">
            </td>
            <td style="width: 116px; height: 28px;" colspan="1">
               <strong style="color: #663300">Employee Name :</strong></td>
            <td colspan="2" style="height: 28px">
                <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="combo"
                    DataSourceID="sdsEmp" DataTextField="FULLNAME" DataValueField="EMP_ID" Width="250px" SkinID="ddlSkin">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 10px; height: 9px">
            </td>
            <td style="width: 116px; height: 9px" colspan="1">
                <strong><span style="color: #663300">MAC Details&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;:</span></strong>
            </td>
            <td style="height: 9px" colspan="2">
                <asp:DropDownList ID="ddlmacadd" runat="server" Width="150px" CssClass="combo" DataTextField="MACAddress" DataValueField="MACAddress" SkinID="ddlSkin" AutoPostBack="True">
                </asp:DropDownList>
                <asp:TextBox ID="txtmacsearch" runat="server" AutoPostBack="True" OnTextChanged="txtmacsearch_TextChanged"
                    SkinID="txtSkin_New"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px;">
                <strong><span style="color: #663300"></span></strong>
            </td>
            <td colspan="2">
                <asp:ImageButton ID="btnSub" runat="server" Height="25px" ImageUrl="~/Images/Sub.bmp"
                    Width="110px" OnClick="btnSub_Click" /></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px;">
            </td>
            <td style="width: 100px;">
                </td>
            <td style="width: 100px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 15px">
            </td>
            <td style="width: 116px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
                &nbsp;</td>
            <td style="width: 100px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px">
            </td>
            <td style="width: 100px">
                &nbsp;<asp:SqlDataSource ID="sdsMACAdd" runat="server" ProviderName="System.Data.OleDb" SelectCommand="select distinct macaddress   from dat Dt left outer join MAC_master MC on Dt.macaddress=mc.mac_info &#13;&#10;where macaddress  not in (select mac_info from mac_master M where M.Edol is null) &#13;&#10;and status='in' and macaddress<>' ' "></asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsEmp" runat="server" ProviderName="System.Data.OleDb" SelectCommand="Select '--Select--' As EMP_ID, '--Select--' as FULLNAME FROM EMPLOYEE_MASTER where emp_id='101103517' &#13;&#10;Union&#13;&#10;SELECT EMP_ID,(FULLNAME) as FULLNAME FROM EMPLOYEE_MASTER WHERE dol is null &#13;&#10;and Emp_id not in (Select Emp_id from mac_master)  &#13;&#10;ORDER BY FULLNAME">
                    <SelectParameters>
                        <asp:SessionParameter Name="?" SessionField="CENTREID" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 116px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 10px">
            </td>
            <td colspan="9">
            </td>
        </tr>
    </table>
    </fieldset >
</asp:Content>

