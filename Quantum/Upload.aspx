<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<fieldset><legend class="FormHeading"><b>Data Upload</b></legend>   
<table>

 <tr>
        <td colspan="8">
            <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
           
              </tr>
              <tr>

  <td style="height: 27px">
        &nbsp;<strong>Documents Upload :</strong><asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button2" runat="server"
                    OnClick="Button1_Click1" Text="upload" />
      <asp:Button ID="Btncancel" runat="server"
                   Text="cancel" OnClick="Btncancel_Click" /></td>
                   </tr>
<asp:HiddenField ID="hdnempid" runat="server" />


</table>


</fieldset>




</asp:Content>

