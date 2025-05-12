<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="CSAT.aspx.cs" Inherits="Admin_FeedBack_CSAT" Title="Untitled Page" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table>
        <tr>
            <td align="center" colspan="1" style="height: 24px">
            </td>
            <td align="center" colspan="5" style="color: #000099; height: 24px">
                <strong>Welcome To PAMAC Opinion Survey !</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="height: 24px">
            </td>
            <td align="center" colspan="5" style="color: #000099; height: 24px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                    SkinID="lblSkin"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                    SkinID="lblSkin"></asp:Label>
               
        </tr>
        <tr>
            <td align="center" colspan="1" style="height: 24px">
            </td>
            <td align="center" colspan="5" style="color: #000099; height: 24px">
                Department<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Width="113px"  >                    
                </asp:DropDownList ></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="height: 21px">            
            </td>
            <td align="center" colspan="5" style="height: 21px">
            <asp:Label ID="lblheading" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
              
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
            </td>
            <td align="center" colspan="1" style="width: 397998px">
            </td>
            <td align="center" colspan="4">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 8893px; height: 20px; background-color: silver">
                <strong>Sr.No</strong></td>
            <td align="center" colspan="1" style="width: 397998px; height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: Trebuchet MS">
                Employee Satisfaction Survey</span></strong></td>
            <td align="center" colspan="4" style="height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                Please Choose One</span></strong></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                1</td>
            <td style="width: 397998px; font-size: 10pt; background-color: #99ccff;">
                I receive clear written / verbal communication of information/services that I ask for</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
                    <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                2</td>
            <td style="width: 397998px; font-size: 10pt; background-color: silver;">
               Services/response to queries are always delivered within the agreed TAT</td>
            <td style="background-color: silver; font-size: 10pt; width: 112871px;" colspan="4"><asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                3</td>
            <td style="width: 397998px; font-size: 10pt; background-color: #99ccff;">
                Support services department consistently display's high level of content / knowledge</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                4</td>
            <td style="width: 397998px; font-size: 10pt; background-color: silver;">
                There is an SOP [standard operating procedure] followed </td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
             <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                5</td>
            <td style="width: 397998px; font-size: 10pt; background-color: #99ccff;">
               Support Team is easily accessible and courteous </td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                6</td>
            <td style="width: 397998px; font-size: 10pt; background-color: silver;">
                Overall I would rate their services as</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="430px">
              <asp:ListItem Value="4">Excellent</asp:ListItem>
                    <asp:ListItem Value="3">Good</asp:ListItem>
                    <asp:ListItem Value="2">Average</asp:ListItem>
                    <asp:ListItem Value="1">Poor</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                7</td>
            <td style="width: 397998px; font-size: 10pt; background-color: #99ccff;">
               Pl share 4 ideas/recommendations how we serve you better</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
            
            <%--<asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">1</asp:ListItem>
                    <asp:ListItem Value="3">2</asp:ListItem>
                    <asp:ListItem Value="2">3</asp:ListItem>
                    <asp:ListItem Value="1">4</asp:ListItem>
            </asp:RadioButtonList>--%>
            
            1 <asp:TextBox ID="txtidea1" runat="server" TextMode="MultiLine" Width="382px"></asp:TextBox><br />
            2 <asp:TextBox ID="txtidea2" runat="server" TextMode="MultiLine" Width="382px"></asp:TextBox><br />
            3 <asp:TextBox ID="txtidea3" runat="server" TextMode="MultiLine" Width="382px"></asp:TextBox><br />
            4 <asp:TextBox ID="txtidea4" runat="server" TextMode="MultiLine" Width="382px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
        <tr>
            <td align="center" style="height: 20px;" colspan="6">
                <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin" Font-Size="Medium"></asp:Label>
                <asp:Label ID="lblmsgnews" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin" Font-Size="Medium"></asp:Label>
                </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px">
            </td>
            <td style="width: 397998px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 171px; height: 16px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px;">
            </td>
            <td style="width: 397998px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 171px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px;">
            </td>
            <td style="width: 397998px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 171px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px;">
            </td>
            <td style="width: 397998px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 171px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px">
            </td>
            <td style="width: 397998px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 171px">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px;">
            </td>
            <td style="width: 397998px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 171px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px">
            </td>
            <td style="width: 397998px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 171px">
            </td>
        </tr>
    </table>
</asp:Content>

