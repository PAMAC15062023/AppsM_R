<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="KYC_MasterPage.master" CodeFile="KYC_PendingList.aspx.cs" Inherits="CPV_KYC_KYC_PendingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Pending List</legend>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table align="center" width="100%">
            <tr>
                <td >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td>
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
                </td>
                <td><asp:Button ID="btnSearch" ValidationGroup="grValidateDate" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnReportSkin" /></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 27px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=" Excel Report" SkinID="btn" />&nbsp;<asp:Button
                        ID="Button2" runat="server" OnClick="Button2_Click" Text="Pending Report As per Authorized date" /></td>
            </tr>
            <tr>
                <td colspan="7" style="height: 27px">
                    <asp:GridView ID="grdvpdrp" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 16px">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
        </table>
         <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" SkinID="lblErrorMsg"></asp:Label>
        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>

        <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ValidationGroup="grValidateDate" ShowSummary="False" Width="205px" />

                   
        </fieldset>
        </td></tr></table>
        </asp:Content>
