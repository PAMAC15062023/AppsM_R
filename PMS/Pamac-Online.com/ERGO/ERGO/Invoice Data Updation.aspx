<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Invoice Data Updation.aspx.cs" Inherits="ERGO_ERGO_Invoice_Data_Updation" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">

</script>

<script language="javascript" type="text/javascript" src="" >

</script>
    <table style="width: 741px">
        <tr>
            <td colspan="2" style="height: 15px">
                <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="2" style="height: 22px">
                &nbsp;Cheque Clearance Details
            </td>
        </tr>        
        <tr>
            <td style="width: 2px">
            </td>
            <td>                
                    <table style="width: 727px">
                        <tr>
            <td class="reportTitleIncome" style="width: 128px; height: 15px">
                <strong>
                Bridge Code</strong></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                <strong>Month</strong></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                <strong>Bill No</strong></td>
            <td class="reportTitleIncome" style="width: 103px; height: 15px">
                <strong>Bill Date</strong></td>
            <td class="reportTitleIncome" style="height: 15px">
                <strong>Cheque No</strong></td>
            <td class="reportTitleIncome" style="height: 15px">
                <strong>Cheque Date</strong></td>
                        </tr>
                    </table>
                    <table style="width: 727px">
                        <tr>
            <td class="Info" style="width: 128px; height: 15px">
                <asp:TextBox ID="txtBridgeCode" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtMonth" runat="server" SkinID="txtSkin" Width="97px" 
                    Enabled="False"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtBillNo" runat="server" SkinID="txtSkin" Width="98px" 
                    Enabled="False"></asp:TextBox></td>
            <td class="Info" style="width: 103px; height: 15px"><table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                <tr>
                    <td style="width: 94px; height: 20px">
                        <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                            Width="75px" Enabled="False"></asp:TextBox>&nbsp;</td>
                    <td style="width: 100px; height: 20px">
                        <img id="Img5" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                </tr>
            </table>
            </td>
            <td class="Info" style="height: 15px">
                <asp:TextBox ID="txtChqNo" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox></td>
            <td class="Info" style="height: 15px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtChqDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="81px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img6" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChqDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
                        </tr>
                    </table>
                    <table style="width: 727px">
                        <tr>
            <td class="reportTitleIncome" style="width: 128px; height: 15px">
                <strong>
                Loaction</strong></td>
            <td class="reportTitleIncome" style="height: 15px">
                <strong>
                Alternate Payee Name</strong></td>
            <td style="width: 103px; height: 15px" class="reportTitleIncome">
                <strong>
                Gross Amt</strong></td>
            <td style="width: 80px; height: 15px" class="reportTitleIncome">
                <strong>ST Amount</strong></td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                <strong>ST No.</strong></td>
                        </tr>
                    </table>
                    <table style="width: 727px">
                        <tr>
            <td class="Info" style="width: 127px; height: 15px">
                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" Width="109px" 
                    Enabled="False" ReadOnly="True"></asp:TextBox></td>
            <td class="Info" style="height: 15px">
                <asp:TextBox ID="txtAltPayeeName" runat="server" SkinID="txtSkin" Width="207px" 
                    Enabled="False" ReadOnly="True"></asp:TextBox></td>
            <td class="Info" style="width: 103px; height: 15px">
                <asp:TextBox ID="txtGrossFees" runat="server" Width="109px" SkinID="txtSkin" 
                    AutoPostBack="True" Enabled="False" ReadOnly="True"></asp:TextBox></td>
            <td class="Info" style="width: 80px; height: 15px">
                <asp:TextBox ID="txtST" runat="server" SkinID="txtSkin" Width="109px" 
                    Enabled="False" ReadOnly="True"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtStNo" runat="server" SkinID="txtSkin" Width="109px" 
                    Enabled="False" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table style="width: 727px">
                        <tr>
            <td class="reportTitleIncome" style="width: 128px; height: 15px">
                <strong>Invoice Status</strong></td>
            <td class="reportTitleIncome" style="height: 15px">
                <strong>BIS Status</strong></td>
            <td class="reportTitleIncome" style="height: 15px">
                <strong>&nbsp;ST Copy Revd</strong></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                <strong>Invoice Date</strong></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                <strong></strong>
            </td>
                        </tr>
                    </table>
                    <table style="width: 727px">
                        <tr>
            <td class="Info" style="width: 127px; height: 15px">
                <asp:DropDownList ID="ddlInvoiceStatus" runat="server" SkinID="ddlSkin" 
                    Enabled="False" Height="16px" Width="78px">
                <asp:ListItem Value="Invoice Recd">Invoice Recd</asp:ListItem>
                <asp:ListItem Value="Invoice Not Recd">Invoice Not Recd</asp:ListItem>
            </asp:DropDownList></td>
            <td class="Info" style="height: 15px" colspan="2">
                <asp:DropDownList ID="ddlBisStatus" runat="server" SkinID="ddlSkin" 
                    Enabled="False" Height="16px" Width="121px">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem Value="0">Yes</asp:ListItem>
                <asp:ListItem Value="1">No</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px; height: 15px" class="Info">
                <asp:DropDownList ID="ddlStComment" runat="server" SkinID="ddlSkin" 
                    Enabled="False" Height="16px" Width="90px">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem Value="0">Yes</asp:ListItem>
                <asp:ListItem Value="1">No</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px; height: 15px" class="Info">
                        <asp:TextBox ID="txtInvoiceDate" runat="server" BorderWidth="1px" MaxLength="10"
                            SkinID="txtSkin" Width="62px" Enabled="False"></asp:TextBox>
                        <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtInvoiceDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
            <td style="width: 100px; height: 15px">
                &nbsp;</td>
                        </tr>
                        <tr>
            <td class="Info" style="width: 127px; height: 15px">
                <strong>ST Payout Done</strong></td>
            <td class="Info" style="width: 128px; height: 15px">
                <asp:DropDownList ID="ddlPayoutDone" runat="server" SkinID="ddlSkin">
                    <asp:ListItem Value="Payout Done">Payout Done</asp:ListItem>
                    <asp:ListItem Value="Payout Not Done">Payout Not Done</asp:ListItem>
                </asp:DropDownList>
                            </td>
            <td style="width: 100px; height: 15px" colspan="3">
                &nbsp;</td>
            <td style="width: 100px; height: 15px">
                &nbsp;</td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" colspan="2">
                <strong>Previous_Month_ST_Invoice_Copy_Not_Recd</strong></td>
            <td class="Info" colspan="3">
                <asp:DropDownList ID="ddlPrevSTRecd" runat="server" SkinID="ddlSkin" 
                    Enabled="False" Height="16px" Width="111px">
                <asp:ListItem>Invoice Recd</asp:ListItem>
                    <asp:ListItem>Invoice Not Recd</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px; height: 15px">&nbsp;</td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="width: 128px; height: 15px" colspan="2">
                <strong>Remark</strong></td>
            <td style="height: 15px" class="Info" colspan="4">
                <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" Width="370px" 
                    Height="40px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="height: 15px" colspan="6">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Font-Bold="True" />&nbsp;<asp:Button ID="btnCan" runat="server" Text="Cancel" Font-Bold="True" 
                                    onclick="btnCan_Click1" /></td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="height: 15px" colspan="6">
                &nbsp;</td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;               
                <asp:HiddenField ID="hdnUID" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnBridgeCode" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

