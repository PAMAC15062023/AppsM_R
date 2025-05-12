<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_TrainingMandaysTracker_Updation.aspx.cs" Inherits="HR_HR_HR_TrainingMandaysTracker_Updation" Title="Training Mandays Tracker Updation" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    
    
</script>
    <table class="br">
        <tr>
            <td class="tta" colspan="8">
                <span style="font-size: 10pt">Training Mandays Tracker Format</span></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td colspan="3" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Crimson" SkinID="lblError" Visible="False"></asp:Label></td>
            <td colspan="2" style="height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                Employee Code</td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                Name</td>
            <td style="height: 15px" colspan="2" class="Info">
                <asp:TextBox ID="txtName" runat="server" Width="233px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Designation</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtDesig" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Date Of Training</td>
            <td class="Info" colspan="2" style="height: 30px">
                <asp:TextBox ID="txtDateTrain" runat="server" SkinID="txtSkin"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateTrain.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 72px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                Topic</td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtTopic" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                Trainer Name</td>
            <td class="Info" colspan="2" style="height: 15px">
                <asp:TextBox ID="txtInductionTrainer" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;" class="reportTitleIncome">
                Venue</td>
            <td class="Info" style="height: 23px">
                <asp:TextBox ID="txtVenue" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 23px;" class="reportTitleIncome">
                Duration (Hrs.)</td>
            <td class="Info" colspan="2" style="height: 23px">
                <asp:TextBox ID="txtDura" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                Evaluation</td>
            <td style="width: 100px; height: 15px" class="Info">
                <asp:TextBox ID="txtEva" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px;">
            </td>
            <td style="height: 15px;" colspan="6">
                <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" /></td>
            <td style="width: 72px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfCluster" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfSubcentre" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfCentre" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnEmpId" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 72px">
            </td>
        </tr>
    </table>
</asp:Content>
