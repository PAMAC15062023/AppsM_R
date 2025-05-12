<%@ Page Language="C#" MasterPageFile="~/BGC/BGC/MasterPage.master" AutoEventWireup="true" CodeFile="BGC_UploadFile.aspx.cs" Inherits="BGC_BGC_BGC_UploadFile" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<br />

<fieldset><legend class="FormHeading">Data Import</legend>
    &nbsp;<table>
        <%--<tr>
            <td colspan="2" valign="top" style="background-color: silver">
                <span style="font-size: 10pt"><strong>DATA IMPORT<br />
                </strong></span>
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" style="height: 15px">
    <asp:Label ID="lblMsgXls" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr style="font-size: 10pt">
            <td valign="top">
                
                  
                    <strong>Select File </strong>
                
            </td>
            <td style="width: 273px; height: 15px">
    <asp:FileUpload ID="xslFileUpload" runat="server" />
                <br />
                <br />
                </td>
        </tr>
        <tr>
            <td style="width: 109px; height: 16px">
            </td>
            <td style="width: 273px; height: 16px">
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" ValidationGroup="vgUpload" />&nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
        </fieldset>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

