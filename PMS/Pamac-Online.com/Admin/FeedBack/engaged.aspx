<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="engaged.aspx.cs" Inherits="Admin_FeedBack_engaged" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<asp:Panel ID="pnleng30" runat="server" Height="496px" Width="941px">
 <table>
        <tr>
            <td colspan="6" align="center" style="height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                    SkinID="lblSkin"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 8893px; height: 20px; background-color: silver">
                <strong>Sr.No</strong></td>
            <td align="center" colspan="1" style="width: 1363727px; height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: Trebuchet MS">
               1st&nbsp; Employee&nbsp; Survey (30&nbsp; Days) </span></strong></td>
            <td align="center" colspan="4" style="height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                Please Choose One</span></strong></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                1</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Were you provided the committed Job Description ?</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>                    
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                2</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                Were you assigned a buddy after your joining ?</td>
            <td style="background-color: silver; font-size: 10pt; width: 112871px;" colspan="4"><asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                3</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Were you imparted proper product training for your profile ?</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                4</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                Does your reporting manager provide you with proper guidance and support</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
             <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt; height: 44px;">
                5</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                Do you attend team meetings regularly ?</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px; height: 44px;"><asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                6</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                Do you have a fair understanding about the targets related to your productivity?</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                7</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                What is your tenure probability with PAMAC</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="363px">
               <asp:ListItem Value="1">6 months</asp:ListItem>
                    <asp:ListItem Value="2">1 Year</asp:ListItem>
                    <asp:ListItem Value="3">1 Plus Year</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                8</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                What would be the reason for you to stay back with PAMAC for a longer tenure ?</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="1">Compensation</asp:ListItem>
                    <asp:ListItem Value="2">Reporting </asp:ListItem>
                    <asp:ListItem Value="3">Manager</asp:ListItem>
                    <asp:ListItem Value="4">Flexibility</asp:ListItem>
                    <asp:ListItem Value="5">Appreciation</asp:ListItem>
                    <asp:ListItem Value="6">Growth</asp:ListItem>
                     <asp:ListItem Value="7">Learning</asp:ListItem>                     
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                9</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Suggest Some areas of improvement</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
            <asp:TextBox ID="txtsugg" runat="server" TextMode="MultiLine" Width="416px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
        <tr>
            <td align="center" style="height: 20px;" colspan="6">
                <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin" Font-Size="Medium"></asp:Label></td>
        </tr>
       
    </table>
    </asp:Panel>
 <asp:Panel ID="pnlsur90" runat="server" Height="672px" Width="941px">
 <table>
        <tr>
            <td colspan="6" align="center" style="height: 21px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                    SkinID="lblSkin"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 8893px; height: 20px; background-color: silver">
                <strong>Sr.No</strong></td>
            <td align="center" colspan="1" style="width: 1363727px; height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: Trebuchet MS">
                2nd&nbsp; Employee&nbsp; Survey(90&nbsp; Days)</span></strong></td>
            <td align="center" colspan="4" style="height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                Please Choose One</span></strong></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                1</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                My manager values the work I do?</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
                <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>                    
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                2</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                Does your reporting manager provide you with proper guidance and support ?</td>
            <td style="background-color: silver; font-size: 10pt; width: 112871px;" colspan="4"><asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                3</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                My immediate Boss gives me regular feedback about my performance </td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                4</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                I have been provided adequate training , tools & resources to do my job well </td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
             <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                5</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Team meetings are useful & productive</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                6</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                My manager always treats me with respect</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt; height: 44px;">
                7</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                I am provided with my performance feedback</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px; height: 44px;"><asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                8</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                I have clear understanding of the targets expected out of my performance</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList16" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">NO</asp:ListItem>
                    <asp:ListItem Value="3">Neutral</asp:ListItem> 
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                9</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
               What would be the reason for you to stay back with PAMAC for a longer tenure ?</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
            <asp:RadioButtonList ID="RadioButtonList17" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="1">Compensation</asp:ListItem>
                    <asp:ListItem Value="2">Reporting </asp:ListItem>
                    <asp:ListItem Value="3">Manager</asp:ListItem>
                    <asp:ListItem Value="4">Flexibility</asp:ListItem>
                    <asp:ListItem Value="5">Appreciation</asp:ListItem>
                    <asp:ListItem Value="6">Growth</asp:ListItem>
                     <asp:ListItem Value="7">Learning</asp:ListItem>                     
            </asp:RadioButtonList>
            </td>
        </tr>
        
         <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                10</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
               What suggestions do you have for the improvement of PAMAC</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
            <asp:TextBox ID="txtsug90" runat="server" TextMode="MultiLine" Width="619px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click"  /></td>
        </tr>
        <tr>
            <td align="center" style="height: 20px;" colspan="6">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin" Font-Size="Medium"></asp:Label>
                <asp:Label ID="lblmsg12" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                    SkinID="lblSkin"></asp:Label></td>
        </tr>
       
    </table>
    </asp:Panel>
</asp:Content>

