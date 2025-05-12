<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 250px;">   
  <tr>
  <td style="width: 250px;">
    <table style="width: 686px; height: 76px;">
    <tr>
        <td style="width: 250px; height: 13px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td class="TableHeader" 
            style="width: 126; color: #0066FF; font-size: medium; height: 11px;">
            Calculus Reset Password </td>
    </tr>
    </table>
    <tr >
        <td  class="TableTitle" align="left">
            <table style="width:100%; height: 84px;">
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 136px; font-weight: 700; font-size: small;" 
                                        class="Masterbody">
                                        Enter Employee ID</td>
                                    
                                    <td style="width: 133px" class="TableGrid">
                                        <asp:TextBox ID="txtEmpID_search" runat="server" Width="182px" Height="28px" 
                                            style="margin-right: 17px" autocomplete="off"></asp:TextBox>
                                    </td>
                                    <td class="TableGrid">
                                        <asp:Button ID="btnsearch" runat="server" CssClass="button" SkinID="btnImport"
                                            Text="Search" Width="82px" onclick="btnsearch_Click"  />
                                        <asp:Literal ID="Literal1" runat="server" Text="EMP_id" Visible="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                <td class="Masterbody" style="height: 32px">
                 &nbsp;&nbsp;
                 <asp:Button ID="btnResetPass" runat="server" CssClass="button" SkinID="btnImport"
                                            Text="Reset Password" onclick="btnResetPass_Click"  />


                 &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;

                 <asp:Button ID="btncancel" runat="server" CssClass="button" SkinID="btnImport"
                                            Text="Cancel" Height="25px" Width="77px" 
                        onclick="btncancel_Click"  />

                </td>
                </tr>
                </table>
              </td>
              </tr>
              </td>
              </tr>
</table>

</asp:Content>

