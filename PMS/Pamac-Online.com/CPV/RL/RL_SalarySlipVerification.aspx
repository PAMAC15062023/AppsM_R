<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_SalarySlipVerification.aspx.cs" Inherits="CPV_RL_RL_SalarySlipVerification" Title="Salary Slip Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript" >
</script>
<fieldset>
<legend class="FormHeading" style="font-size: 8pt; font-family: Arial; width: 300px;">
    <span style="font-size: 12pt"><span style="text-decoration: underline">
    <span style="font-family: Arial">INCOME DOCUMENT VERIFICATION</span>
    </span></span>
</legend>
    <table style="background-color:#E7F6FF; width: 942px; height: 1448px; font-size: 8pt; font-family: Arial;">
        <tr style="font-family: Arial; font-size: 8pt;">
            <td colspan="2" style="height: 16px">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="698px" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <strong>Applicant Type :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtAppType" runat="server" BackColor="#FFE0C0" ForeColor="Black"
                    ReadOnly="True" Width="299px" Font-Bold="True"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt;">
            <td style="width: 352px; height: 16px">
                <strong><span>Observation :</span></strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtObser" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td style="height: 7px; text-align: left;" colspan="2">
              <asp:Label ID="lblBackOffice" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="Blue" Text="Back Office Check For Salary Slip / Salary Certificate / Pay Slip / Form-16" Width="732px" Height="12px" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Total Income as per SS / SC / Pay slip / Form -16 :"
                        Width="269px"></asp:Label></strong></td>
            <td colspan="1" style="height: 16px; width: 378px;">
                <asp:TextBox ID="txtTotalIncome" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label2" runat="server" Text="Overwriting / Tampering of Any Provision in the Salary Slip Dectected :" Font-Bold="True" Width="390px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlSalaryDect" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label3" runat="server" Text="Overall Computation Correct :" Font-Bold="True" Width="355px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlCompCorrect" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label4" runat="server" Text="1. Income calculations correct :" Font-Bold="True" Width="358px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlIncomeCal" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label5" runat="server" Text=" 2. Tax  calculations correct :" Font-Bold="True" Width="360px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlTaxCal" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label6" runat="server" Text="In case of form-16 Tax Payable is correct (For Tax payable cases Tax paid should be = to TDS) :" Font-Bold="True" Width="374px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlTazPay" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label7" runat="server" Text="Whether OK to send for field verification :" Font-Bold="True" Width="359px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;"><asp:DropDownList ID="ddlFeildVeri" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label8" runat="server" Text='Other Observation ( Highlight details for any "No" above) :' Font-Bold="True" Width="356px"></asp:Label></td>
            <td colspan="1" style="height: 16px; width: 378px;">
                <asp:TextBox ID="txtOtherObv" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td colspan="2">
                <asp:Label ID="lblFieldVerification" runat="server" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt" ForeColor="Blue" Text="Field verification of Salary Slip / Pay Slip / Salary Certificate" Width="427px"></asp:Label>
            </td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt;">
            <td colspan="1" style="height: 16px; width: 352px;">
                <strong>Name of the Person Contacted :</strong></td>
            <td style="width: 378px; height: 16px; font-size: 8pt;">
                <asp:TextBox ID="txtPerCon" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt;">
            <td colspan="1" style="height: 15px; width: 352px;">
                <strong>
                Designation &amp; Department :</strong></td>
            <td style="width: 378px; height: 15px">
                <asp:TextBox ID="txtDesig" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
         <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td colspan="2">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt" ForeColor="Blue" Text="As per the Contacted Person"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>Applicant's Designation :</strong></td>
            <td style="width: 378px; height: 16px; font-size: 8pt;">
                <asp:TextBox ID="txtAppDesig" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="height: 16px; width: 352px;">
                <strong>
                Department Applicant working In :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtAppDept" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="height: 16px; width: 352px;">
                <strong>Applicant’s Year in service with the Organization :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtAppYear" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Gross/Mothly Income :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtGrossIn" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Number of Employees :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlNumEmp" runat="server" Width="151px" BackColor="#FFFFC0">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Less than 20</asp:ListItem>
                    <asp:ListItem>20-49</asp:ListItem>
                    <asp:ListItem>50-99</asp:ListItem>
                    <asp:ListItem>100-499</asp:ListItem>
                    <asp:ListItem>Above 500</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <strong>
                Type of Industry :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlTypeInd" runat="server" Width="150px" BackColor="#FFFFC0">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>PSU</asp:ListItem>
                    <asp:ListItem>Software Company</asp:ListItem>
                    <asp:ListItem>Public Ltd</asp:ListItem>
                    <asp:ListItem>Pvt Ltd</asp:ListItem>
                    <asp:ListItem>Partnerhip</asp:ListItem>
                    <asp:ListItem>Proprietory</asp:ListItem>
                    <asp:ListItem>Bank</asp:ListItem>
                    <asp:ListItem>Railway</asp:ListItem>
                    <asp:ListItem>University</asp:ListItem>
                    <asp:ListItem>College</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                I<strong>f Others then :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtOthInd" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td colspan="2">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt" ForeColor="Blue" Text="Deatails in the Document Confirmed as Ok" Width="246px"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Seal of the Organization :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlOrg" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Signature of the Issuing Authority :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlSignAuth" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="height: 16px; width: 352px;">
                <strong>
                Document as per the Standard Format of the Organization :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlDocu" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Date on the SS/ SP/SC :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlSSdate" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Amount on the SS/ SP/SC :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlSSamt" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                Address of the Applicant's Office is correct :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:DropDownList ID="ddlAppAdd" runat="server" Width="147px" BackColor="#FFFFC0">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>Bank Statement Observation :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtBankState" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td colspan="2">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt" ForeColor="Blue" Text="Other Observation" Width="246px"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text=" a) Business Activity Seen :"
                    Width="172px"></asp:Label></td>
            <td colspan="1" style="height: 16px; text-align: left; width: 378px;">
                <asp:TextBox ID="txtBussAct" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="b) Number of Employee Seen :"
                    Width="172px"></asp:Label></td>
            <td colspan="1" style="height: 16px; text-align: left; width: 378px;">
                <asp:TextBox ID="txtEmpSeen" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="c) Equipment / Stock Seen :"
                    Width="172px"></asp:Label></td>
            <td colspan="1" style="height: 16px; text-align: left; width: 378px;">
                <asp:TextBox ID="txtStockSeen" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 16px">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="d) Name Plate Seen :"
                    Width="172px"></asp:Label></td>
            <td colspan="1" style="height: 16px; text-align: left; width: 378px;"><asp:DropDownList ID="ddlNamePlate" runat="server" Width="147px" BackColor="#FFFFC0">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
      <tr style="font-family: Arial; font-size: 8pt; background-color:#d0d5d8">
            <td colspan="2">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Arial"
                        Font-Size="9pt" ForeColor="Blue" Text="Deatails of Bank Statement" Width="246px"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                1) Name of the Bank :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtBankName" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                2) Address of the Bank :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtBankAdd" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                3) Name of the Contacted Person :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtNameConPer" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                4) Designation of the Contacted Person :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtDesigConPer" runat="server" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 16px; width: 352px;" colspan="1">
                <strong>
                5) Department of the Contacted Person :</strong></td>
            <td style="width: 378px; height: 16px">
                <asp:TextBox ID="txtDeptConPer" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 12px; width: 352px;" colspan="1">
                <strong>
                6) Is Account No. is Correct :</strong></td>
            <td style="width: 378px; height: 12px">
                <asp:TextBox ID="txtAccNo" runat="server" Width="300px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="height: 12px; width: 352px;">
                 <strong>
                    7) Is Bank statement is as per Bank’s Format whether font matches :</strong></td>
            <td style="width: 378px; height: 12px">
                <asp:TextBox ID="txtBankFormat" runat="server" Width="299px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="height: 12px; width: 352px;">
                <strong>
                8) Is Amt. shown in the Bank Statement is Correct :</strong></td>
            <td style="width: 378px; height: 12px">
                <asp:TextBox ID="txtStateCorr" runat="server" Width="299px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="2">
                <table style="width: 697px; height: 41px;">
                    <tr>
                        <td style="width: 190px; height: 16px">
                            <strong>
                            Tele Attempts</strong></td>
                        <td style="width: 189px; height: 16px">
                            &nbsp;<strong>DateTime[dd/mm/yyyy]</strong></td>
                        <td style="height: 16px">
                            <strong>
                            Time[hh:mm]</strong></td>
                        <td style="width: 158px; height: 16px">
                            <strong>Remarks</strong></td>
                    </tr>
                    <tr>
                        <td style="width: 190px">
                <asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server" Text="First Attempt" Width="139px" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"></asp:Label></td>
                        <td style="width: 189px">
                <asp:TextBox MaxLength="11"  Width="137px"  ID="txtAttemptDate1" runat="server" BackColor="#FFFFC0"></asp:TextBox><img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        <td>
                <asp:TextBox  MaxLength="5"  ID="txtAttemptTime1" Width="50" runat="server" BackColor="#FFFFC0"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType1" runat="server" BackColor="#FFFFC0">
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                    </asp:DropDownList></td>
                        <td style="width: 158px">
                <asp:TextBox MaxLength="50"   ID="txtAttemptRemark1" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 190px; height: 18px;">
                            <asp:Label ID="lblSecondAttempt" runat="server" SkinID="lblSkin" Text="Second Attempt" Width="139px" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"></asp:Label></td>
                        <td style="width: 189px; height: 18px;">
                            <asp:TextBox ID="txtAttemptDate2" runat="server" MaxLength="11"
                                Width="137px" BackColor="#FFFFC0"></asp:TextBox><img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtAttemptTime2" runat="server" MaxLength="5" Width="50" BackColor="#FFFFC0"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType2" runat="server" BackColor="#FFFFC0">
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 158px; height: 18px;">
                            <asp:TextBox ID="txtAttemptRemark2" runat="server" MaxLength="50" BackColor="#FFFFC0"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 190px; height: 16px;">
                            <asp:Label ID="lblThirdAttempt" runat="server" SkinID="lblSkin" Text="Third Attempt" Width="139px" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"></asp:Label></td>
                        <td style="width: 189px; height: 16px;">
                            <asp:TextBox ID="txtAttemptDate3" runat="server" MaxLength="11" Width="137px" BackColor="#FFFFC0"></asp:TextBox><img id="Img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        <td style="height: 16px">
                            <asp:TextBox ID="txtAttemptTime3" runat="server" MaxLength="5" Width="50" BackColor="#FFFFC0"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType3" runat="server" BackColor="#FFFFC0">
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 158px; height: 16px;">
                            <asp:TextBox ID="txtAttemptRemark3" runat="server" MaxLength="50" BackColor="#FFFFC0"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 190px; height: 16px;">
                            <asp:Label ID="lblFourthAttempt" runat="server" SkinID="lblSkin" Text="Fourth Attempt" Width="139px" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"></asp:Label></td>
                        <td style="width: 189px; height: 16px;">
                            <asp:TextBox ID="txtAttemptDate4" runat="server" MaxLength="11" Width="137px" BackColor="#FFFFC0"></asp:TextBox><img id="Img3"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate4.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        <td style="height: 16px">
                            <asp:TextBox ID="txtAttemptTime4" runat="server" MaxLength="5" Width="50" BackColor="#FFFFC0"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType4" runat="server" BackColor="#FFFFC0">
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 158px; height: 16px;">
                            <asp:TextBox ID="txtAttemptRemark4" runat="server" MaxLength="50" BackColor="#FFFFC0"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
       <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 12px">
                <strong>
                Final Status :</strong></td>
            <td style="width: 378px; height: 12px">
                <asp:DropDownList ID="ddlFinalStat" runat="server" Width="143px" BackColor="#FFFFC0">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Okay Case</asp:ListItem>
                    <asp:ListItem>Not Okay</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="height: 12px; width: 352px;" colspan="1">
                <strong>
                Additional Remarks if any :</strong></td>
            <td style="width: 378px; height: 12px" colspan="1">
                <asp:TextBox ID="txtRemark" runat="server" Width="302px" Height="39px" TextMode="MultiLine" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="1" style="width: 352px; height: 12px">
                <strong>Tele Remarks :</strong></td>
            <td colspan="1" style="width: 378px; height: 12px">
                <asp:TextBox ID="txtTeleRemark" runat="server" Height="29px" TextMode="MultiLine" Width="301px" BackColor="#FFFFC0"></asp:TextBox></td>
        </tr>
      <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin"   ID="lblTeleCallersName" runat="server" Text="Tele Caller's Name :" Font-Bold="True" Font-Names="Arial" Font-Size="8pt" Width="190px"></asp:Label>
            </td>
            <td >
            <asp:DropDownList ID="ddlTeleCallersName" runat="server"  AutoPostBack="false" BackColor="#FFFFC0">
            </asp:DropDownList>
            </td>
      </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td colspan="2" style="height: 12px; width: 381px;">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Font-Bold="True" Width="96px" BackColor="#C0C0FF" Height="33px" />&nbsp;<asp:Button ID="btnCancle"
                    runat="server" Text="Cancle" OnClick="btnCancle_Click" Font-Bold="True" Width="91px" BackColor="#C0C0FF" Height="33px" /></td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 352px; height: 64px">
                <asp:HiddenField ID="hidCaseID" runat="server" Visible="False" />
                <asp:HiddenField ID="hidMode" runat="server" Visible="False" />
            </td>
            <td style="height: 64px; width: 378px;">
                <asp:HiddenField ID="hidVerificationTypeCode" runat="server" Visible="False" />
            </td>
        </tr>
        <tr style="font-size: 8pt; font-family: Arial">
            <td style="width: 381px; height: 12px" colspan="2">
            </td>
        </tr>
    </table>
    </fieldset>
  
</asp:Content>

