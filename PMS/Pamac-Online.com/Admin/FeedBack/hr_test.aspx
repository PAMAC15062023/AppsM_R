<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true"
    CodeFile="hr_test.aspx.cs" Inherits="Admin_FeedBack_hr_test" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    
    <asp:Panel ID="pnlPDF" runat="server" Height="50px" Width="530px">
        <table>
            <tr>
                <td style="width: 513px; height: 10px;">
                    <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                        SkinID="lblSkin">Please Go through the PDF and then take the Questionnaire</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left" style="height: 20px; width: 185px;">
                    <asp:LinkButton ID="lnkbtnDnlD" runat="server" OnClick="lnkbtnDnlD_Click" Height="27px">Download NEO PPT</asp:LinkButton>
                </td>
            </tr>
            <tr>
             <td colspan="6" align="left" style="height: 20px; width: 185px;">
             <asp:LinkButton ID="lnkbtnDnldQue" runat="server" Height ="24px" OnClick="lnkbtnDnldQue_Click">Download Questionnaire</asp:LinkButton>
             </td>
            </tr>
        </table>
    </asp:Panel>


    <asp:Panel ID="pnleng30" runat="server" Height="520px" Width="942px">
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
                    <strong><span style="font-size: 10pt; font-family: Trebuchet MS">Induction Questionnaire</span></strong></td>
                <td align="center" colspan="4" style="height: 20px; background-color: silver; width: 112871px;">
                    <strong><span style="font-size: 10pt; font-family: 'Trebuchet MS'">Please Choose One</span></strong></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt; height: 44px;">
                    1</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                    How many branches does PAMAC have across India</td>
                <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 112871px; height: 44px;">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">33</asp:ListItem>
                        <asp:ListItem Value="2">35</asp:ListItem>
                        <asp:ListItem Value="3">43</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt; height: 44px;">
                    2</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: silver; height: 44px;">
                    What is the P in "PAMAC" stands for ?</td>
                <td style="background-color: silver; font-size: 10pt; width: 112871px; height: 44px;" colspan="4">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">Perpetual</asp:ListItem>
                        <asp:ListItem Value="2">Productive</asp:ListItem>
                        <asp:ListItem Value="3">Persistent</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt; height: 44px;">
                    3</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                    <span style="color: black">How many Board &amp; Directors does PAMAC &nbsp;have ?</span></td>
                <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 112871px; height: 44px;">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">4</asp:ListItem>
                        <asp:ListItem Value="2">3</asp:ListItem>
                        <asp:ListItem Value="3">5</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                    4</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                    Where is the Head Office of PAMAC located ?</td>
                <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">Mumbai</asp:ListItem>
                        <asp:ListItem Value="2">Delhi</asp:ListItem>
                        <asp:ListItem Value="3">Bangalore</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;
                    height: 44px;">
                    5</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                    Who is our Board of Advisor ?</td>
                <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 112871px;
                    height: 44px;">
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="404px">
                        <asp:ListItem Value="1">Mr. Devashish Parikh</asp:ListItem>
                        <asp:ListItem Value="2">Mr. Paryank Shah</asp:ListItem>
                        <asp:ListItem Value="3">Mr. Divesh Sheth</asp:ListItem>
                        <asp:ListItem Value="4">All</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                    6</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                    Which ISO Certification does PAMAC have ?</td>
                <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">ISO 9001:2008</asp:ListItem>
                        <asp:ListItem Value="2">ISO 14001</asp:ListItem>
                        <asp:ListItem Value="3">ISO 27001</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                    7</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                    Are you allowed to take leaves during your probation?</td>
                <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                    8</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                    What tool would you use to solve your queries ?</td>
                <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">Email</asp:ListItem>
                        <asp:ListItem Value="2">Query Management System</asp:ListItem>
                        <asp:ListItem Value="3">Verbally</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                    9</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                    which of these is not a Quality Objective of PAMAC?</td>
                <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">TAT should be achieved</asp:ListItem>
                        <asp:ListItem Value="2">Reduce overall cost</asp:ListItem>
                        <asp:ListItem Value="3">Reduce Productivity</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                    10</td>
                <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                    Which of the following is not a policy of PAMAC?</td>
                <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;">
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal"
                        Font-Bold="True" Width="400px">
                        <asp:ListItem Value="1">Long Service Award</asp:ListItem>
                        <asp:ListItem Value="2">Whistle Blower Policy</asp:ListItem>
                        <asp:ListItem Value="3">Harrasement Policy   &nbsp&nbsp</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td align="center" style="height: 50px;" colspan="6">
                    <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin"
                        Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
