<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_PancardVerification.aspx.cs" Inherits="FRC_Employee_Background_Check_EBC_PancardVerification" Title="Pancard Verifaction" StylesheetTheme ="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

    <table style="width: 843px; height: 157px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td colspan="6" style="height: 27px">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="570px"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="6" style="height: 27px">
                PAN CARD VERIFICATION</td>
        </tr>
        <tr>
            <td style="width: 2px; height: 34px">
            </td>
            <td style="width: 117px; height: 34px" class="reportTitleIncome">
                Date of Receipt</td>
            <td style="height: 34px" class="Info">
                <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin"></asp:TextBox>
              <img id="imgDateOfVerification"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                <td class="reportTitleIncome" style="height: 34px">
                CPA Refernce Number</td>
            <td class="Info" style="height: 34px">
                <asp:TextBox ID="txtCPArefNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 34px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 117px" class="reportTitleIncome">
                Name of the PAN Card Holder</td>
            <td class="Info">
                <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td class="reportTitleIncome">
                Bank Refernce Number</td>
            <td class="Info">
                <asp:TextBox ID="txtBankRefNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 117px" class="reportTitleIncome">
                PAN No</td>
            <td class="Info">
                <asp:TextBox ID="txtPANno" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 27px">
                Back Office Check</td>
            <td style="height: 27px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 30px;">
            </td>
            <td style="width: 117px; height: 30px;" class="reportTitleIncome">
                PAN ( Permanent Account Number ) logic and correctness</td>
            <td class="Info" style="height: 30px">
                <asp:DropDownList ID="ddlPANcorrectness" runat="server" Height="17px" Width="131px" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Available</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 30px;">
                1. Is it 10 digits :
            </td>
            <td class="Info" style="height: 30px">
                <asp:DropDownList ID="ddlchk10digits" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 30px">
            </td>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 23px">
                2. Is tenth digit alphabetic :</td>
            <td class="Info" style="height: 23px">
                <asp:DropDownList ID="ddlIsAlphanum" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 30px;">
                3. Are the 6th,7th,8th,and 9th digits numeric :
            </td>
            <td class="Info" style="height: 30px">
                <asp:DropDownList ID="ddlChkdigit6789" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 30px">
            </td>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 117px">
                4. Is the fourth digit "P" for individuals, "H" for HUF, "C" for companies and "F"
                for firms : Yes / No</td>
            <td class="Info">
                <asp:DropDownList ID="ddlChkdigit4" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 73px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 73px">
                Other Observation ( Highlight details for any "No" above)</td>
            <td class="Info" colspan="2" style="height: 73px">
                <asp:TextBox ID="txtObservation" runat="server" Height="64px" TextMode="MultiLine" Width="454px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 73px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5">
                Field Verification Of PAN
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 117px">
                PAN Details Verified with</td>
            <td class="Info">
                <asp:DropDownList ID="ddlPanVerify" runat="server" Height="14px" Width="130px" SkinID="ddlSkin">
                    <asp:ListItem>Internet</asp:ListItem>
                    <asp:ListItem>Income Tax Department</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 21px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 21px">
                Does the PAN # match with records</td>
            <td class="Info" style="height: 21px">
                <asp:DropDownList ID="ddlPanNoMAtch" runat="server" Height="17px" Width="130px" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 16px">
                Does the name of the PAN Card holder match with records</td>
            <td class="Info" style="height: 16px">
                <asp:DropDownList ID="ddlNameMatch" runat="server" Height="17px" Width="131px" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 23px">
                Does the name of the Father / Husband match with records</td>
            <td class="Info" style="height: 23px">
                <asp:DropDownList ID="ddlRealtionMatch" runat="server" Height="17px" Width="131px" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 7px">
                Does the Date of Birth March with records</td>
            <td class="Info" style="height: 7px">
                <asp:DropDownList ID="ddlDOBMatch" runat="server" Height="17px" Width="131px" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 7px">
            </td>
            <td style="height: 7px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 23px;">
            </td>
            <td style="width: 117px; height: 23px;" class="reportTitleIncome">
                Final Status</td>
            <td style="height: 23px" class="Info" colspan="">
                <asp:TextBox ID="txtStatus" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 23px" colspan="">
            </td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 117px" class="reportTitleIncome">
                REMARKS ( Clearly specify reason for not okay cases and not confirmed cases.)</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtRemarks" runat="server" Height="66px" TextMode="MultiLine" Width="459px" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 117px">
                OK CASE AS PER COMPUTER RECORD.</td>
            <td class="Info">
                <asp:TextBox ID="txtRecord" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 23px">
                Name Of the Verifier</td>
            <td class="Info" style="height: 23px">
                <asp:TextBox ID="txtNameVerifier" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
                </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 23px">
                Supervisor's Name</td>
            <td class="Info" style="height: 23px">
                <asp:TextBox ID="txtSName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="width: 117px; height: 16px">
                Date of visit</td>
            <td class="Info" style="height: 16px">
                <asp:TextBox ID="txtDateTime" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtDateTime.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                    
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 117px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td class="tta" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="Save" Height="27px" SkinID="btnSaveSkin" Width="87px" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="27px" SkinID="btnCancelSkin" Width="87px" OnClick="btnCancel_Click" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 2px">
            </td>
            <td style="width: 117px">
                <asp:HiddenField ID="hdnCaseID" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

