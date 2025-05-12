<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Discrepancy_Data_New.aspx.cs" Inherits="ERGO_ERGO_Discrepancy_Data_New" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js">
    </script>
    <script language="javascript" type="text/javascript">

        function Validate_Generate() {
            var ReturnValue = true;
            var strErrorMessage = "";
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
            var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
            var txtToDate = document.getElementById("<%=txtToDate.ClientID%>");
            var ddlDiscrepancy = document.getElementById("<%=ddlDiscrepancy.ClientID%>");


            if (txtFromDate.value == '') {
                strErrorMessage = "Please Select From Date!";
                txtFromDate.focus();
                ReturnValue = false;
            }
            if (txtToDate.value == '') {
                strErrorMessage = "Please Select To Date!";
                txtToDate.focus();
                ReturnValue = false;
            }


            lblMessage.innerText = strErrorMessage;
            window.scrollTo(0, 0);

            return ReturnValue;
        }
            

    
    </script>
    <table style="width: 100%">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="6">
                &nbsp;Discrepancy Report</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px">
               <strong> FromDate</strong></td>
            <td class="reportTitleIncome" style="width: 100px">
                <strong>ToDate</strong></td>
            <td style="width: 100px" class="reportTitleIncome">
               <strong> Discrepancy</strong></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="Info">
                            <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="69px"></asp:TextBox>
                            <img id="ImgFromDt" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" 
                    style="width: 17px; height: 16px" /></td>
            <td class="Info">
                            <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" 
                    SkinID="txtSkin" Width="72px"></asp:TextBox>
                            <img id="ImgToDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                           src="../../Images/SmallCalendar.png" 
                    style="width: 17px; height: 16px" /></td>
            <td class="Info">
                <asp:DropDownList ID="ddlDiscrepancy" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>-All Okay-</asp:ListItem>
                    <asp:ListItem>BIS Discrepancy</asp:ListItem>
                    <asp:ListItem>ST - Copy Pending</asp:ListItem>
                    <asp:ListItem>ST - Invoice Pending</asp:ListItem>
                    <asp:ListItem>PAN Pending</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="height: 17px" class="reportTitleIncome">
                &nbsp;&nbsp;<asp:Button ID="btnGetReport" runat="server" OnClick="btnGetReport_Click" 
                   Text="Generate" />
                </td>
        </tr>
        <tr>
            <td colspan="6">
                <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="true" width="100%">
                    <tr>
                        <td style="height: 13px">
                            <asp:GridView ID="GridView1" runat="server" SkinID="gridviewNoSort">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 26px" class="reportTitleIncome">
                &nbsp;<asp:Button ID="btnRetrive" runat="server" OnClick="btnRetrive_Click" 
                    Text="Export to Excel" />
                &nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="53px" 
                    onclick="btnClear_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
        <tr>
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

