<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="GetResult.aspx.cs" Inherits="OnlineTest.GetResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>

            </td>
        </tr>
         <tr>
            <td class="TableHeader" style="width: 354px">
                <b>RESULTS
                </b>
            </td>
        </tr>
        <tr>
            <td style="width: 354px">
                <asp:GridView ID="grdresults" runat="server" AutoGenerateColumns="true" Visible="true"
                    CssClass="mGrid" Width="711px" Height="37px">
                </asp:GridView>

             <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" />
                  <asp:Button ID="btnCheck" runat="server" Text="Checkanswers" OnClick="btnCheck_Click" />
                
            </td>
        </tr>
          <tr>
            <td style="width: 354px">
                <asp:GridView ID="grdCheckAnswers" runat="server" 
                    AutoGenerateColumns="true" Visible="true" 
                    CssClass="mGrid" Width="711px" Height="37px">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
