<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Case_Revist.aspx.cs" Inherits="CPA_PD_Case_Revist" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript">
function validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
    var txtcase_id = document.getElementById("<%=txtcase_id.ClientID%>");

    if(txtcase_id.value == '')
    {
        ErrorMsg="Please Enter Case ID.";
        ReturnValue=false;
        txtcase_id.focus();
    }
    window.scrollTo(0,0);
    lblMessage.innerText = ErrorMsg;
    return ReturnValue;
}
</script>
    

<asp:Panel ID="pnlCategory" runat="server" Width="700px">
    <table style="width: 700px">
    <tr>
        <td class="tta" style="width: 700px; height: 4px;">
            <span style="font-size: 10pt">CASE RE-OPEN</span></td>
    </tr>
    <tr>
        <td style="width:700px;">
            <asp:Label ID="lblMessage" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
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
                    <strong>FE NAME</strong></td>
                <td style="width: 100px;" class="Info">
                    <asp:DropDownList ID="ddlFE" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="Info" colspan="4">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnsearch_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnReAssign" runat="server" Text="Reassign" SkinID="btn" OnClick="btnReAssign_Click" /></td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="Gridsearch" runat="server"   OnRowCommand="Gridsearch_RowCommand" OnRowEditing="Gridsearch_RowEditing">
          <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>     
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="sdsVerifyType" runat="server" ProviderName="System.Data.OleDb"
            SelectCommand="Select [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE], [VERIFICATION_TYPE_CODE] &#13;&#10;from VERIFICATION_TYPE_MASTER &#13;&#10;WHERE VERIFICATION_TYPE_ID IN(62,63)">
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdnFEID" runat="server" />
        <asp:HiddenField ID="hdnCaseID" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdnvery" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="hdnID" runat="server" />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Panel>

</asp:Content>

