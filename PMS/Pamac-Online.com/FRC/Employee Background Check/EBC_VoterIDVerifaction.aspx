<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_VoterIDVerifaction.aspx.cs" Inherits="EBC_VoterIDVerifaction" Title="Voter ID Verifaction" StylesheetTheme ="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table style="width: 844px">
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                VoterID Verification</td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td colspan="4" style="height: 16px">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="489px"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Back Office Verification</td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
                &nbsp;</td>
            <td class="reportTitleIncome" style="height: 16px">
                Date of Receipt</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtReceiptDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtReceiptDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td style="height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                VoterID #</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtVoterID" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Name of VoterID &nbsp;Holder</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtHolderName" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Validity of the VoterID</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtValidity" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Copy of VoterID &nbsp;is clear to send on the field</td>
            <td style="height: 16px;" class="Info">
                <asp:DropDownList ID="ddlVoterIDCopy" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 18px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Field Verification</td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the VoterID &nbsp;match with &nbsp;records?</td>
            <td style="height: 16px;" class="Info">
                <asp:DropDownList ID="ddlVoterIDMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 18px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Name of the VoterID holder match?</td>
            <td style="height: 16px;" class="Info">
                <asp:DropDownList ID="ddlVoterIDName" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 18px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
    <tr>
        <td style="width: 34px; height: 16px">
        </td>
        <td class="reportTitleIncome" style="height: 16px">
            Does the Relation Name of the Voter ID holder match</td>
        <td class="Info" style="height: 16px">
            <asp:DropDownList ID="ddlRelationName" runat="server" Height="14px" SkinID="ddlSkin"
                Width="128px">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList></td>
        <td style="width: 18px; height: 16px">
        </td>
        <td style="width: 18px; height: 16px">
        </td>
    </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Address match with&nbsp; records?</td>
            <td style="height: 16px;" class="Info">
                <asp:DropDownList ID="ddlAddress" runat="server" Height="14px" SkinID="ddlSkin" Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 18px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the age &nbsp;match with the records?</td>
            <td style="height: 16px;" class="Info">
                <asp:DropDownList ID="ddlValidity" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 18px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Status</td>
            <td class="Info" style="height: 9px">
                <asp:DropDownList ID="ddlStatus" runat="server" Height="14px" SkinID="ddlSkin" Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Refer</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 9px">
            </td>
            <td style="height: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 4px">
            </td>
            <td class="reportTitleIncome" style="height: 4px">
                Remark</td>
            <td colspan="3" style="height: 4px">
                <asp:TextBox ID="txtRemark" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="650px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Date of Submission</td>
            <td class="Info" style="width: 183px; height: 9px">
                <asp:TextBox ID="txtSubDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSubDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td class="reportTitleIncome" style="height: 9px">
                Date of verification</td>
            <td class="Info" style="width: 18px; height: 9px">
                <asp:TextBox ID="txtVerDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVerDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Supervisor's Name</td>
            <td class="Info" style="width: 183px; height: 9px">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 9px">
                Name of Verifier</td>
            <td class="Info" style="width: 18px; height: 9px">
                <asp:TextBox ID="txtVerName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td style="height: 9px">
            </td>
            <td style="width: 183px; height: 9px">
            </td>
            <td style="height: 9px">
            </td>
            <td style="width: 18px; height: 9px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 9px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Height="27px" SkinID="btnSaveSkin"
                    Text="Save" Width="87px" OnClick="btnSave_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" Height="27px"
                        SkinID="btnCancelSkin" Text="Cancel" Width="87px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td style="height: 9px">
                <asp:HiddenField ID="hdnCaseID" runat="server" />
            </td>
            <td style="width: 183px; height: 9px">
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" />
            </td>
            <td style="height: 9px">
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
            </td>
            <td style="width: 18px; height: 9px">
            </td>
        </tr>
    </table>
</asp:Content>

