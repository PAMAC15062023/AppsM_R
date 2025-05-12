<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="AddExaminees.aspx.cs" Inherits="OnlineTest.AddExaminees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;
    <table style="width: 1170px;">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" id="header1" runat="server" style="font-size: medium">Add Examinee</td>
        </tr>
    </table>
    <asp:Panel ID="Mainpanel" runat="server">
        <table>

            <tr>
                <td class="TableTitle"><strong><span style="font-size: small">User ID:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="txtUserID" runat="server" Width="348px" OnTextChanged="txtUserID_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td class="TableTitle"><strong><span style="font-size: small">User Name:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtUserName" runat="server" Width="348px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="lblQuestionpaper" runat="server" Text="Select Question Paper "
                        Style="font-weight: 700; font-size: small"></asp:Label></td>

                <td style="width: 66px" class="TableGrid">

                    <asp:DropDownList ID="ddlQuestionpaper" runat="server" OnSelectedIndexChanged="ddlQuestionpaper_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="1" class="TableTitle">
                    <strong><span style="font-size: small">Is Active :</span></strong>
                    <td style="width: 100px; height: 22px;">
                        <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="370px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList></td>
                </td>

            </tr>
            <tr>
                <td style="width: 71px;" class="TableTitle">
                    <strong>Select File</strong>
                </td>
                <td style="width: 95px;" class="TableGrid">
                    <asp:FileUpload ID="xslFileUpload" runat="server" />
                </td>
            </tr>
            <tr>

                <td colspan="4" class="TableGrid">
                    <asp:Button ID="btnsubmit" runat="server"
                        OnClick="btnsubmit_Click" Text="SAVE" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server"
                    OnClick="btncancel_Click" Text="Cancel" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" Text="Update Question"
                    OnClick="btnupdate_Click" />

                    <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" />

                    <asp:Button ID="btnDownloadUploadFormat" runat="server" Text="Download Excel Upload Format" BorderColor="#400000"
                         OnClick="btnDownloadUploadFormat_Click" BorderWidth="1px" Font-Bold="False" Width="220px"/>
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnqnno" runat="server" />
    </asp:Panel>
</asp:Content>

