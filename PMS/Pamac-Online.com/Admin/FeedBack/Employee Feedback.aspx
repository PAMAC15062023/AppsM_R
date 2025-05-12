<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="Employee Feedback.aspx.cs" Inherits="Admin_FeedBack_Employee_Feedback" Title="Untitled Page"  Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
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
                Employee Satisfaction Survey</span></strong></td>
            <td align="center" colspan="4" style="height: 20px; background-color: silver">
                <strong><span style="font-size: 10pt; font-family: 'Trebuchet MS'">
                Please Choose One</span></strong></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                1</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Management has created an open and comfortable work environment</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                    <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                2</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                Management is honest and ethical in its business practices</td>
            <td style="background-color: silver; font-size: 10pt; width: 112871px;" colspan="4"><asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                3</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                My job is interesting and enjoyable and I feel motivated to do it</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                4</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                I am provided with the material and equipment necessary to do my job right</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" Font-Bold="True">
             <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                5</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                My performance is continiously tracked and reviewed</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                6</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                I am involved in all decisions related to me by my supervisor</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                7</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                My Manager is regularly interacting with me and provides me feedback on all operational
                issues for improvement</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                8</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                I receive quick recognition/praise from my manager for any good
                work</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                9</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                This organization organizes several programs for continuous learning and development
                of all the employees</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                10</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                The company provides a formal career path for advancement of employees</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 112871px;"><asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
             <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                11</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                Promotions go to those who best deserve them</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
             <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                12</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                The performance appraisal process in this company is transparent</td>
            <td colspan="4" style="background-color: silver; font-size: 10pt; width: 4779px;"><asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
              <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt; height: 44px;">
                13</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff; height: 44px;">
                The company is competitive in the market with respect to its compensation package</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px; height: 44px;"><asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                 <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: silver; font-size: 10pt;">
                14</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: silver;">
                <p class="MsoNormal">
                    <span style="font-size: 9pt; color: black">My work does not extend beyond our working hours</span></p>
            </td>
            <td style="background-color: silver; font-size: 10pt; width: 4779px;" colspan="4"><asp:RadioButtonList ID="RadioButtonList14" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
               <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; background-color: #99ccff; font-size: 10pt;">
                15</td>
            <td style="width: 1363727px; font-size: 10pt; background-color: #99ccff;">
                I refer my best friends to PAMAC to work</td>
            <td colspan="4" style="background-color: #99ccff; font-size: 10pt; width: 4779px;">
                <asp:RadioButtonList ID="RadioButtonList15" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Width="400px">
                  <asp:ListItem Value="4">Strongly Agree</asp:ListItem>
                    <asp:ListItem Value="3">Agree</asp:ListItem>
                    <asp:ListItem Value="2">Disagree</asp:ListItem>
                    <asp:ListItem Value="1">Strongly Disagree</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
        <tr>
            <td align="center" style="height: 20px;" colspan="6">
                <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" ForeColor="Blue" SkinID="lblSkin" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" style="width: 8893px; height: 16px">
            </td>
            <td style="width: 1363727px; height: 16px">
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
            <td style="width: 1363727px; height: 16px;">
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
            <td style="width: 1363727px; height: 16px;">
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
            <td style="width: 1363727px; height: 16px;">
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
            <td style="width: 1363727px">
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
            <td style="width: 1363727px; height: 16px;">
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
            <td style="width: 1363727px">
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

