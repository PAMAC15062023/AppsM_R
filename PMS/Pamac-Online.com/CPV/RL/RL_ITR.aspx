<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" StylesheetTheme="SkinFile" CodeFile="RL_ITR.aspx.cs" Inherits="CPV_RL_RL_ITR" Title="ITR Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<table border="0" cellpadding="0" cellspacing="0" runat="server">
        <tr>
            <td colspan="1" style="height: 16px;">
            </td>
            <td colspan="4" style="height: 16px">
                <asp:Label ID="lblMessage" runat="server" Width="846px" Visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="height: 21px;">
            </td>
            <td align="left" class="TableHeader" colspan="4" style="height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="9pt" Text="INCOME TAX VERIFICATION REPORT (FOR SELFF EMPLOYED PROFESSIONAL / BUSINESSMEN)"
                    Width="657px" SkinID="lblSkin"></asp:Label></td>
        </tr>
    <tr>
        <td colspan="1" style="height: 16px;">
        </td>
        <td align="left" class="TableTitle" colspan="4" style="height: 16px">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Text="INCOME TAX RETURN (ITR) VERIFICATION REPORT"
                Width="373px" SkinID="lblSkin"></asp:Label></td>
    </tr>
        <tr>
            <td style="height: 21px;">
            </td>
            <td style="font-family: Arial;">
                <span>Name of the Assessee</span></td>
            <td style="font-family: Arial;">
                <asp:TextBox ID="txtApplicantName" runat="server" Width="233px" ReadOnly="True" SkinID="txtSkin" Height="18px"></asp:TextBox></td>
            <td style="font-family: Arial;">
                <span></span></td>
            <td style="width: 312px; height: 21px">
                </td>
        </tr>
        <tr>
            <td style="height: 26px;">
            </td>
            <td style="font-family: Arial;">
                <span>Address :</span></td>
            <td style="font-family: Arial;" colspan="3">
                <asp:TextBox ID="txtAddress" runat="server" Width="601px" TextMode="MultiLine" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
    <tr>
        <td style="height: 26px;">
        </td>
        <td style="font-family: Arial;">
            Referance No :</td>
        <td style="font-family: Arial;">
                <asp:TextBox ID="txtRefNo" runat="server" Width="235px" ReadOnly="True" SkinID="txtSkin" Height="20px"></asp:TextBox></td>
        <td style="font-family: Arial;" align="right">
            App Type</td>
        <td style="width: 312px; height: 26px">
            <asp:TextBox ID="txtAppType" runat="server" ReadOnly="True" SkinID="txtSkin" Font-Bold="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 28px;">
        </td>
        <td style="font-family: Arial; height: 28px;">
                Pan / Bank ref No :</td>
        <td style="font-family: Arial; height: 28px;">
                <asp:TextBox ID="txtPanNo" runat="server" Width="235px" SkinID="txtSkin" Height="20px" TabIndex="1" MaxLength="10"></asp:TextBox></td>
        <td style="font-family: Arial; height: 28px;">
        </td>
        <td style="width: 312px; height: 28px">
        </td>
    </tr>
        <tr>
            <td style="height: 16px;">
            </td>
            <td style="font-family: Arial;">
                <span>Details of income :</span></td>
            <td colspan="3" style="font-family: Arial;">
                <asp:TextBox ID="txtDetailIncome" runat="server" Width="603px" TextMode="MultiLine" SkinID="txtSkin" TabIndex="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 18px;">
            </td>
            <td colspan="4" align="left" class="TableTitle" style="font-family: Arial">
                <asp:Label ID="lblDetails" runat="server" Font-Bold="True" Text="Back Office Details"
                    Width="195px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 18px;">
            </td>
            <td colspan="1" style="font-family: Arial;">
                Assesment Year :</td>
            <td colspan="1" style="font-family: Arial;">
                <asp:TextBox ID="txtAssetYear" runat="server" Width="231px" SkinID="txtSkin" Height="24px" TabIndex="3"></asp:TextBox></td>
            <td colspan="1" style="font-family: Arial;">
                Ward :</td>
            <td colspan="1">
                <asp:TextBox ID="txtWard" runat="server" Width="182px" SkinID="txtSkin" Height="28px" TabIndex="4"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 27px;">
            </td>
            <td colspan="1" style="font-family: Arial; height: 27px;">
                Return Filled On Dated :</td>
            <td colspan="1" style="font-family: Arial; height: 27px;">
                <asp:TextBox ID="txtReturnFilled" runat="server" Width="230px" SkinID="txtSkin" Height="36px" TabIndex="5"></asp:TextBox></td>
            <td colspan="1" style="font-family: Arial; height: 27px;">
                <span>Total income (Amt. as per
                    return filed with IT Department) :</span></td>
            <td colspan="1" style="height: 27px;">
                <asp:TextBox ID="txtTotalIncomeReturn" runat="server" Width="181px" SkinID="txtSkin" Height="37px" TabIndex="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 41px;">
            </td>
            <td colspan="1" style="font-family: Arial; height: 41px;">
                <span>Tax paid on total income (tax amt as per return filed
                    with IT Dept.) :</span></td>
            <td colspan="1" style="font-family: Arial; height: 41px;">
                <asp:TextBox ID="txtTaxPaid" runat="server" Width="231px" SkinID="txtSkin" Height="48px" TabIndex="7"></asp:TextBox></td>
            <td colspan="1" style="font-family: Arial; height: 41px;">
                PAN ( Permanent Account Number ) logic and correctness :</td>
            <td colspan="1" style="height: 41px">
                &nbsp;<asp:DropDownList ID="ddlPanCorr" runat="server" SkinID="ddlSkin" Width="89px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not available</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            1. Is it 10 digits :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlDigit" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            2. Is tenth digit alphabetic :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlAlpha" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            3. Are the 6th,7th,8th,and 9th digits numeric :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlNumeric" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            4. Is the fourth digit "P" for individuals, "H" for HUF, "C" for companies and "F"
            for firms :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlPhcf" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            Computation correct :&nbsp;</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlComp" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            1. Income calculations correct :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlIncomeCalcu" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            2. Tax calculations correct :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlTaxCalcu" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            Alphabet Falls Under Ward / Circle / Range Jurisdiction :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlAlphaFalls" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            Address Falls Under Ward / Circle/ Range Jurisdiction :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlAddressFalls" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            Whether OK to send for field verification :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlFieldVeri" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            CA membersip stamp available :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:DropDownList ID="ddlCaMem" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            If available does the membership details match :</td>
        <td colspan="1" style="height: 41px">
            <asp:DropDownList ID="ddlMemDet" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not available</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="height: 41px">
        </td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            Other Observation ( Highlight details for any "No" above) :</td>
        <td colspan="1" style="font-family: Arial; height: 41px">
            <asp:TextBox ID="txtOthObv" runat="server" Height="48px" SkinID="txtSkin" TabIndex="7"
                Width="231px"></asp:TextBox></td>
        <td colspan="1" style="font-family: Arial; height: 41px">
        </td>
        <td colspan="1" style="height: 41px">
        </td>
    </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" runat="server" style="height: 316px" >
        <tr>
            <td colspan="6" class="TableTitle" align="left">
                <asp:Label ID="lblVerification" runat="server" Font-Bold="True" Height="14px" Text="Field Verification Of ITR"
                    Width="696px"></asp:Label></td>
        </tr>
        <tr style="font-family: Arial">
            <td style="width: 449px; font-family: Arial; height: 30px;">
                <span>Tallied With</span></td>
            <td style="width: 86px; height: 30px; font-family: Arial;">
                <span>Computer Record</span></td>
            <td style="width: 101px; height: 30px; font-family: Arial;">
                <span>Inward Register</span></td>
            <td style="width: 101px; height: 30px; font-family: Arial;">
                <span>Blue Register</span></td>
            <td style="width: 101px; height: 30px; font-family: Arial;">
                <span>Index Register</span></td>
            <td style="width: 159px; height: 30px; font-family: Arial;">
                <span>Orally Ok By Clerk</span></td>
        </tr>
        <tr style="font-size: 8pt">
            <td style="width: 449px; font-family: Arial; height: 20px;">
                <span>Ward Number</span></td>
            <td style="width: 86px; height: 20px;">
                <asp:DropDownList ID="ddlWardNo" runat="server" SkinID="ddlSkin" TabIndex="8">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="111">YES</asp:ListItem>
                    <asp:ListItem Value="110">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 95px; height: 20px;">
                <asp:DropDownList ID="ddlInWard" runat="server" SkinID="ddlSkin" TabIndex="13">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="211">YES</asp:ListItem>
                    <asp:ListItem Value="210">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px; height: 20px;">
                <asp:DropDownList ID="ddlBlueWard" runat="server" SkinID="ddlSkin" Width="73px" TabIndex="18">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="311">YES</asp:ListItem>
                    <asp:ListItem Value="310">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 20px">
                <asp:DropDownList ID="ddlIndexWard" runat="server" Width="76px" SkinID="ddlSkin" TabIndex="23">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="411">YES</asp:ListItem>
                    <asp:ListItem Value="410">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 159px; height: 20px;">
                <asp:DropDownList ID="ddlOrallyWard" runat="server" Width="67px" SkinID="ddlSkin" TabIndex="28">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="511">YES</asp:ListItem>
                    <asp:ListItem Value="510">NO</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td style="width: 449px">
                <span>
                Serial Number &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>&nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;
            </td>
            <td style="width: 86px; height: 17px;">
                <asp:DropDownList ID="ddlSerialNo" runat="server" SkinID="ddlSkin" TabIndex="9" >
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="121">YES</asp:ListItem>
                    <asp:ListItem Value="120">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 95px; height: 17px;">
                <asp:DropDownList ID="ddlInwardSerialNo" runat="server" SkinID="ddlSkin" TabIndex="14">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="221">YES</asp:ListItem>
                    <asp:ListItem Value="220">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px; height: 17px;">
                <asp:DropDownList ID="ddlBlueSerial" runat="server" Width="72px" SkinID="ddlSkin" TabIndex="19">
                    <asp:ListItem Value="322">NA</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 17px;">
                <asp:DropDownList ID="ddlIndexSerial" runat="server" Width="76px" SkinID="ddlSkin" TabIndex="24">
                    <asp:ListItem Value="422">NA</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 159px; height: 17px;">
                <asp:DropDownList ID="ddlOrallySerial" runat="server" Width="66px" SkinID="ddlSkin" TabIndex="29">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="521">YES</asp:ListItem>
                    <asp:ListItem Value="520">NO</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td style="width: 449px; height: 10px; font-family: Arial;">
                <span><span>Date of Filling</span></span></td>
            <td style="width: 86px; height: 10px;">
                <asp:DropDownList ID="ddlDateOfFilling" runat="server" SkinID="ddlSkin" TabIndex="10">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="131">YES</asp:ListItem>
                    <asp:ListItem Value="130">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 95px; height: 10px;">
                <asp:DropDownList ID="ddlInWardDate" runat="server" SkinID="ddlSkin" TabIndex="15">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="231">YES</asp:ListItem>
                    <asp:ListItem Value="230">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px; height: 10px;">
                <asp:DropDownList ID="ddlBlueDate" runat="server" Width="73px" SkinID="ddlSkin" TabIndex="20">
                    <asp:ListItem Value="332">NA</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 10px;">
                <asp:DropDownList ID="ddlIndexDate" runat="server" Width="76px" SkinID="ddlSkin" TabIndex="25">
                    <asp:ListItem Value="432">NA</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 159px; height: 10px;">
                <asp:DropDownList ID="ddlOrallyDate" runat="server" Width="66px" SkinID="ddlSkin" TabIndex="30">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="531">YES</asp:ListItem>
                    <asp:ListItem Value="530">NO</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td style="width: 449px; font-family: Arial; height: 10px;">
                <span>Total Taxable Income </span></td>
            <td style="width: 86px; height: 18px">
                <asp:DropDownList ID="ddlTotalTaxable" runat="server" SkinID="ddlSkin" TabIndex="11">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="141">YES</asp:ListItem>
                    <asp:ListItem Value="140">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 95px; height: 18px">
                <asp:DropDownList ID="ddlInwardTotal" runat="server" SkinID="ddlSkin" TabIndex="16">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="241">YES</asp:ListItem>
                    <asp:ListItem Value="240">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px; height: 18px">
                <asp:DropDownList ID="ddlBlueTotal" runat="server" SkinID="ddlSkin" Width="72px" TabIndex="21">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="341">YES</asp:ListItem>
                    <asp:ListItem Value="340">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 18px">
                <asp:DropDownList ID="ddlIndexTotal" runat="server" Width="76px" SkinID="ddlSkin" TabIndex="26">
                    <asp:ListItem Value="442">NA</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 159px; height: 18px">
                <asp:DropDownList ID="ddlOrallyTotal" runat="server" Width="66px" SkinID="ddlSkin" TabIndex="31">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="541">YES</asp:ListItem>
                    <asp:ListItem Value="540">NO</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td style="width: 449px; font-family: Arial; height: 10px;">
                <span>Applicant’s Name</span></td>
            <td style="width: 86px;">
                <asp:DropDownList ID="ddlAppName" runat="server" SkinID="ddlSkin" TabIndex="12">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="151">YES</asp:ListItem>
                    <asp:ListItem Value="150">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 95px;">
                <asp:DropDownList ID="ddlInwardApp" runat="server" SkinID="ddlSkin" TabIndex="17">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="251">YES</asp:ListItem>
                    <asp:ListItem Value="250">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 101px;">
                <asp:DropDownList ID="ddlBlueApp" runat="server" SkinID="ddlSkin" Width="72px" TabIndex="22">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="351">YES</asp:ListItem>
                    <asp:ListItem Value="350">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:DropDownList ID="ddlIndexApplicant" runat="server" Width="77px" SkinID="ddlSkin" TabIndex="27">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="451">YES</asp:ListItem>
                    <asp:ListItem Value="450">NO</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 159px;">
                <asp:DropDownList ID="ddlOrallyApp" runat="server" Width="66px" SkinID="ddlSkin" TabIndex="32">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="551">YES</asp:ListItem>
                    <asp:ListItem Value="550">NO</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td colspan="1" style="width: 449px; height: 22px;">
                Final Status</td>
            <td colspan="5" style="height: 22px">
                <asp:DropDownList ID="ddlFinalStatus" runat="server" Width="102px" SkinID="ddlSkin" TabIndex="33">
                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value="1">Okay Case </asp:ListItem>
                    <asp:ListItem Value="0">Not Okay</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr style="font-size: 8pt">
            <td colspan="1" style="width: 449px; font-family: Arial; height: 14px;">
                <span>Remarks(Clearly specify reason for not okay cases and not confirmed cases.):-</span></td>
            <td colspan="5" style="width: 336px; height: 14px;">
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="424px" Height="37px" SkinID="txtSkin" TabIndex="34"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr style="font-size: 8pt">
            <td>
                Date Of Verification</td>
            <td colspan="5">
                <asp:TextBox ID="txtDateOfVerification" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="img" src="../../Images/SmallCalendar.gif" alt="Cal"  onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]</td>
        </tr>
        <tr style="font-size: 8pt">
            <td align="center" colspan="6" style="height: 9px">
                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp; 
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr style="font-size: 8pt">
            <td colspan="6" align="left">
                <asp:HiddenField ID="hdnCaseID" runat="server" Visible="False" />
                <asp:HiddenField ID="hidMode" runat="server" />
                <asp:HiddenField ID="hdnVerificationID" runat="server" Visible="False" />
            </td>
        </tr>
    </table>
  </asp:Content>

