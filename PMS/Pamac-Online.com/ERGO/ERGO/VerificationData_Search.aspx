<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="VerificationData_Search.aspx.cs" Inherits="ERGO_ERGO_VerificationData_Search" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 22px">
                &nbsp;Branch Payment Request View</td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="TableTitle">
                &nbsp; Bridge Code</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtTransactionID" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Total Amount</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtTotalAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Bill No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBillNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="TableTitle">
                &nbsp;Branch</td>
            <td style="width: 100px" class="TableGrid">
                <asp:DropDownList ID="ddlBranchList" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="TableTitle">
                &nbsp;Payee Name</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtPayeeName" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Bill Date</td>
            <td style="width: 100px" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="TableTitle">
                &nbsp;Request Date</td>
            <td style="width: 100px" class="TableGrid">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtRequestDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRequestDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="TableTitle">
                &nbsp;ServiceTaxReg.No</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtServiceTaxRegNo" runat="server" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TableTitle">
                &nbsp;Bill Amount</td>
            <td style="width: 100px" class="TableGrid">
                <asp:TextBox ID="txtBillAmount" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="92px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:HiddenField ID="hdnTransID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 31px;" class="TableTitle" colspan="7">
                &nbsp;<asp:Button ID="btnSearch" runat="server" BorderWidth="1px" Font-Bold="False"
                    Text="Search" />&nbsp;<asp:Button ID="btnReset" runat="server"
                        BorderWidth="1px" Text="Reset" Width="54px" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 16px">
                Billing Details View</td>
        </tr>
        <tr>
            <td colspan="7">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td>
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
            <td class="TableGrid" colspan="7" style="height: 28px">
                &nbsp;
                <asp:Button ID="btnView" runat="server" BorderWidth="1px" Font-Bold="False" 
                    Text="View" Width="67px" />&nbsp;<asp:Button ID="btnAddNew" runat="server" BorderWidth="1px"  
                         Text="Add New" Width="75px" />&nbsp;<asp:Button ID="btnModify"
                            runat="server" BorderWidth="1px" Text="Modify" Width="75px"  />
                <asp:Button ID="btnCancel" runat="server"
                            BorderWidth="1px" Text="Cancel" /></td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td>
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

