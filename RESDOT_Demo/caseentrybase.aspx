<%@ Page Title="" Language="C#" MasterPageFile="~/RESDOT_Master.Master" AutoEventWireup="true" CodeBehind="caseentrybase.aspx.cs" Inherits="RESDOT.caseentrybase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="60%"></asp:Label>
            </td>
        </tr>
        </table>
     <asp:UpdatePanel ID="pnlArea" runat="server"  align="left" > <%--align add on 18/12/23--%>
                <ContentTemplate>
                       <asp:PlaceHolder ID="PlaceholderControls" runat="server">
                       </asp:PlaceHolder> 
                     <%--  <asp:DropDownList ID ="ddArea" runat="server" AutoPostBack="true" 
                       OnSelectedIndexChanged="ddArea_SelectedIndexChanged1">
                       <asp:ListItem Value="0" Text="Selected"></asp:ListItem>
                       <asp:ListItem Value="1" Text="1"></asp:ListItem>
                     </asp:DropDownList>--%>
          
                </ContentTemplate>
              
  
           </asp:UpdatePanel>

     <asp:HiddenField ID="hdnMenuId" runat="server" />
</asp:Content>
