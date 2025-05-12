<%@ Page Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true" CodeFile="ImportSystem.aspx.cs" Inherits="PC_ImportSystem"
    Title="Import System" StylesheetTheme="SkinFile"%> 


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    
    <div>
     <table style="width: 98%; height: 152px;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
                <asp:Label ID="Label1" runat="server" BackColor="#FFFFCC" Font-Bold="True" 
                    Text="lblmsgstatus" Visible="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="14" style="height:22px; width:auto;">
                IMPORT EXCEL DATA</td>
            </tr>
            <tr>
            <td class="reportTitleIncome" style="height: 42px; width: 70px;">
            
               &nbsp;Centre Name</td>
            <td class="Info" style="height: 42px"  >
            
                <asp:FileUpload ID="FileUpload1" runat="server" style="background-color:#F4F8FB;border-color:#476085;border-width:1px;border-style:Solid;font-family:Arial;font-size:8pt;height:23px;width:244px;"/>
            
            </td>
            </tr>
            <tr class="TableGrid">
            <td  class="tta" colspan="14" style="height: 30px">
            
                <asp:Button ID="IMPORT" runat="server"  BackColor="Black" BorderColor="White" 
                    CssClass="button" ForeColor="White" height="26px" Width="135px" Text="IMPORT" 
                    onclick="IMPORT_Click" />
                     <asp:Button id="Cancel" runat="server" Width="135px" CssClass="button" ForeColor="White" Text="Cancel" BackColor="Black" height="26px" BorderColor="White" OnClick="Cancel_Click"></asp:Button>
            
            </td>
            <%--<td class="TableGrid">
                </td>--%>
            </tr>
            </table>
     </div>
   

</asp:Content>
