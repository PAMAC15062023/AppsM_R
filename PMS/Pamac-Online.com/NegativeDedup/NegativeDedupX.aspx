<%@ Page Title="" Language="C#" MasterPageFile="~/NegativeDedup/NegativeDedup.master" AutoEventWireup="true" CodeFile="~/NegativeDedup/NegativeDedupX.aspx.cs" Inherits="Pages_NegativeDedupX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">


    function Validate_ImportFile() {

        var ReturnValue = true;
        var ErrorMessage = "";
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var FileImport = document.getElementById("<%=FileImport.ClientID%>");
      
        if (FileImport.value == '') {

            ReturnValue = false;
            ErrorMessage = 'Please select file for Import!';

        }

        



        lblMessage.innerText = ErrorMessage;

        window.scroll(0, 0);
        return ReturnValue;
    
    }


</script>
    <table style="width: 100%">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Negative Data Check</td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td class="TableTitle" style="width: 149px">
                &nbsp;Import Data File (.xls)</td>
            <td class="TableGrid" colspan="3">
                <asp:FileUpload ID="FileImport" runat="server" BorderWidth="1px" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td style="width: 149px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="5" style="height: 28px">
&nbsp;&nbsp;
                <asp:Button ID="btnImport" runat="server" Text="Import" Width="79px" 
                    BorderWidth="1px" onclick="btnImport_Click" Font-Bold="True" />
&nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="79px" BorderWidth="1px" 
                    CssClass="1" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" style="height: 19px">
                &nbsp; Cases Imported for Negative Data&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" style="height: 19px">
                <asp:Panel ID="pnlImport" runat="server" Height="230px" ScrollBars="Both" 
                    Width="900px">
                    <asp:GridView ID="grv_ImportCases" runat="server" 
    CssClass="mGrid" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%" __designer:mapid="a2">
                        <tr __designer:mapid="a3">
                            <td __designer:mapid="a4" style="height: 134px">
                                <asp:GridView ID="gvExportReport" runat="server" Height="100px" Width="98%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <RowStyle CssClass="GridViewRowStyle" BackColor="White" ForeColor="#003399" />
                                    <FooterStyle CssClass="GridViewFooterStyle" BackColor="#99CCCC" ForeColor="#003399" />
                                    <PagerStyle CssClass="GridViewPagerStyle" BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                <br />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 36px;" class="TableTitle" colspan="5">
                &nbsp;
                <asp:Button ID="btnDedepe" runat="server" Text="Dedupe &amp; Export" Width="144px" 
                    BorderWidth="1px" onclick="btnDedepe_Click" Font-Bold="True" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="79px" BorderWidth="1px" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 4px">
                &nbsp;</td>
            <td style="width: 149px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

