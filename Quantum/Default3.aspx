<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true"
    CodeFile="Default3.aspx.cs" Inherits="Default3" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td align="center" colspan="1" style="height: 24px">
            </td>
            <td align="center" colspan="5" style="color: #000099; height: 24px">
                <strong>Welcome To  Notification!</strong></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
       
            <tr>
                <td>
                    <strong>&nbsp;Upload Notification :</strong><asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button
                        ID="Button2" runat="server" OnClick="Button1_Click1" Text="upload" />
                    <asp:Button ID="Btncancel" runat="server" Text="cancel" OnClick="Btncancel_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" Width="442px">
                        <Columns>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilePath")%>'
                                        CommandName="download" OnClick="lnkdownload_Click"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <asp:HiddenField ID="hdnempid" runat="server" />
    </table>
</asp:Content>
