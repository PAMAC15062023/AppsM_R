<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset><legend class="FormHeading"><b>Data Download</b></legend>   
   
<table>


 <tr>
        <td colspan="8">
            <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
           
              </tr>
<tr>
 <asp:GridView ID="grd1" runat="server" Visible="true">
  <Columns>
   <asp:TemplateField HeaderText="Download">
    <ItemTemplate>
                    <asp:LinkButton ID="lnkdownload" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilePath")%>'
                        CommandName="download" OnClick="lnkdownload_Click"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
            </Columns>
    </asp:GridView>
    
        <asp:Button ID="Btncancel" runat="server"
                   Text="cancel" OnClick="Btncancel_Click" />
</tr>


</table>


</fieldset>
</asp:Content>

