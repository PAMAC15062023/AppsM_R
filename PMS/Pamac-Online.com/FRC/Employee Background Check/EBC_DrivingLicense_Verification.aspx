<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master"CodeFile="EBC_DrivingLicense_Verification.aspx.cs" Inherits="FRC_Employee_Background_Check_EBC_DrivingLicense_Verification" Title="Driving Licence Verification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <div><table style="width: 844px">
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Driving Licence Verification</td>
        </tr>
        <tr>
            <td style="height: 16px" colspan="5">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="693px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Back Office Verification</td>
        </tr>
        <tr>
            <td style="height: 16px">
                &nbsp;</td>
            <td class="reportTitleIncome" style="height: 16px">
                Date of Receipt</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:TextBox ID="txtReceiptDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtReceiptDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
            </td>
            <td style="height: 16px; width: 125px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Driving Licence #</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:TextBox ID="txtLicenceNo" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px; width: 125px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Name of Driving Licence Holder</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:TextBox ID="txtHolderName" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 16px; width: 125px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Validity of Driving Licence</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:TextBox ID="txtValidity" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px; width: 125px;">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Copy of Driving Licence is clear to send on the field</td>
            <td style="height: 16px; width: 171px;" class="Info">
                <asp:DropDownList ID="ddlClear" runat="server" Height="14px" SkinID="ddlSkin" Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 16px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                Field Verification</td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Driving licence match with RTO records?</td>
            <td style="height: 16px; width: 171px;" class="Info">
                <asp:DropDownList ID="ddlLicenceMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Name of the Driving licence holder match?</td>
            <td style="height: 16px; width: 171px;" class="Info">
                <asp:DropDownList ID="ddlNameMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the Address match with RTO records?</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:DropDownList ID="ddlAddressMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Does the validity period match with the records?</td>
            <td class="Info" style="height: 16px; width: 171px;">
                <asp:DropDownList ID="ddlValidityMatch" runat="server" Height="14px" SkinID="ddlSkin"
                    Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 16px">
            </td>
            <td style="width: 18px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Status</td>
            <td class="Info" style="height: 9px; width: 171px;">
                <asp:DropDownList ID="ddlStatus" runat="server" Height="14px" SkinID="ddlSkin" Width="128px">
                    <asp:ListItem>Ok</asp:ListItem>
                    <asp:ListItem>Not Ok</asp:ListItem>
                    <asp:ListItem>Refer</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 125px; height: 9px">
            </td>
            <td style="height: 9px">
            </td>
        </tr>
        <tr>
            <td style="height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Remark</td>
            <td colspan="3" style="height: 9px">
                <asp:TextBox ID="txtRemark" runat="server" Height="90px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="348px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Date of Submission</td>
            <td class="Info" style="width: 171px; height: 9px">
                <asp:TextBox ID="txtSubDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="imgDateOfVerification" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSubDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
            </td>
            <td class="reportTitleIncome" style="height: 9px; width: 125px;">
                Date of verification</td>
            <td class="Info" style="width: 18px; height: 9px">
                <asp:TextBox ID="txtVerDate" runat="server" SkinID="txtSkin" Width="99px"></asp:TextBox>
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVerDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
            </td>
        </tr>
        <tr>
            <td style="height: 9px">
            </td>
            <td class="reportTitleIncome" style="height: 9px">
                Supervisor's Name</td>
            <td class="Info" style="width: 171px; height: 9px">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 9px; width: 125px;">
                Name of Verifier</td>
            <td class="Info" style="width: 18px; height: 9px">
                <asp:TextBox ID="txtVerName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 9px">
            </td>
            <td style="height: 9px">
            </td>
            <td style="width: 171px; height: 9px">
            </td>
            <td style="height: 9px; width: 125px;">
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
            <td style="height: 9px">
            </td>
            <td style="height: 9px">
                <asp:HiddenField ID="hdnCaseID" runat="server" />
            </td>
            <td style="width: 171px; height: 9px">
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" />
            </td>
            <td style="height: 9px; width: 125px;">
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
            </td>
            <td style="width: 18px; height: 9px">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

