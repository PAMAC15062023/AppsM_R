<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="Case_Revisit.aspx.cs" Inherits="DCR_DCR_Case_Revisit" Title="Untitled Page" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtcase_id = document.getElementById("<%=txtcase_id.ClientID%>");

    if(txtcase_id.value == '')
    {
        ErrorMsg="Please Enter Case ID.";
        ReturnValue=false;
        txtcase_id.focus();
    }
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}
</script>


<asp:Panel ID="pnlRevisit" runat="server" Width="700px">
    <table style="width: 700px">
    <tr>
        <td class="tta" style="width: 700px; height: 4px;">
            <span style="font-size: 10pt">CASE RE-VISIT</span></td>
    </tr>
    <tr>
        <td style="width:700px;">
            <asp:Label ID="lblMsg" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    </table>
    
    <asp:Image ID="Image1" runat="server" Height="120px" ImageUrl="~/Images/PamacLogo1.jpg" Width="120px" />
    <asp:HiddenField ID="hdncentre" runat="server" />
    <asp:HiddenField ID="HdnCluster" runat="server" />
    <br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;
    <div style="text-align: center">
        <table style="width: 400px">
            <tr>
                <td style="width: 100px;" class="reportTitleIncome">
                    <strong>Case ID</strong></td>
                <td style="width: 100px;" class="Info">
                    <asp:TextBox ID="txtcase_id" runat="server" Width="170px" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px;" class="reportTitleIncome">
                    <strong>Applicant Name</strong></td>
                <td style="width: 100px;" class="Info">
                    <asp:TextBox ID="txtappname" runat="server" SkinID="txtSkin" Width="170px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Info" colspan="4" style="width: 396px">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnsearch_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnRevisit" runat="server" Text="Re-Visit" SkinID="btn" OnClick="btnRevisit_Click"/></td>
            </tr>
        </table>
    </div>
</asp:Panel>

</asp:Content>

