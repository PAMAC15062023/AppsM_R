<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_PassportVerification.aspx.cs" Inherits="FRC_Employee_Background_Check_EBC_PassportVerification" Title="Passport Verifcation" StylesheetTheme ="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table style="width: 844px">
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Passport Verification</td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td colspan="4" style="height: 16px">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="520px"></asp:Label></td>
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
                <asp:TextBox ID="txtReceiptDate" runat="server" SkinID="txtSkin">
                </asp:TextBox>
                 <img id="imgDateOfVerification"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtReceiptDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
            <td style="height: 16px; width: 150px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Passport #</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtPassNo" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px; width: 150px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Name of Passport &nbsp;Holder</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtHolderName" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px; width: 150px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Validity of the Passport</td>
            <td class="Info" style="height: 16px; width: 183px;">
                <asp:TextBox ID="txtValidity" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px; width: 150px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Copy of Passport &nbsp;is clear to send on the field</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlCopyMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 235px; height: 16px">
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
                Does the Passport &nbsp;match with &nbsp;records?</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlPassportMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 235px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Name of the Passport holder match?</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlHolderMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 235px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Address match with&nbsp; records?</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlAddressMacth" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 235px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the validity period match with the records?</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlValidity" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 235px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Status</td>
            <td class="Info" style="height: 9px">
                <asp:DropDownList ID="ddlStatus" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Refer</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 9px; width: 150px;">
            </td>
            <td style="height: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 34px; height: 3px">
            </td>
            <td class="reportTitleIncome" style="height: 3px">
                Remark</td>
            <td colspan="3" style="height: 3px">
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
                 <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtSubDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
            <td class="reportTitleIncome" style="height: 9px; width: 150px;">
                Date of verification</td>
            <td class="Info">
                <asp:TextBox ID="txtVerDate" runat="server" SkinID="txtSkin" Width="122px"></asp:TextBox>
                 <img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtVerDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
        </tr>
        <tr>
            <td style="width: 34px; height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Supervisor's Name</td>
            <td class="Info" style="width: 183px; height: 9px">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 9px; width: 150px;">
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
            <td style="height: 9px; width: 150px;">
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
            <td style="height: 9px; width: 150px;">
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
            </td>
            <td style="width: 18px; height: 9px">
            </td>
        </tr>
    </table>
</asp:Content>

