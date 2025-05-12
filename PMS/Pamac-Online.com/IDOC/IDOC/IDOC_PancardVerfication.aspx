<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_PancardVerfication.aspx.cs" Inherits="IDOC_IDOC_IDOC_PancardVerfication" Title="Untitled Page" Theme="SkinFile" StylesheetTheme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {

          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
    </script>
<fieldset>
<%--<legend class="FormHeading">PAN CARD VERIFICATION REPORT</legend>--%>
    <table style="width: 990px; height: 173px; background-color: #e7f6ff;" >
        <tr>
            <td align="left" colspan="5">
                <asp:Label ID="lblMsg" runat="server" SkinID="lblSkin" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="background-color: #d0d5d8" class="txtBold">
                <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="labdateoFRecipt" runat="server" Text="Date of Receipt "></asp:Label></td>
            <td style="height: 26px">
                <asp:TextBox ID="txtdateofrecipt" runat="server" SkinID="txtSkinWidth"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, <%=txtdateofrecipt.ClientID %>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
            <td style="height: 26px">
                <asp:Label ID="LabcparefNo" runat="server" Text="CPA Reference Number"></asp:Label></td>
            <td style="height: 26px">
                <asp:TextBox ID="txtcparefNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="labnameofapplicant" runat="server" Text="Name of the Applicant"></asp:Label></td>
            <td style="height: 26px">
                <asp:TextBox ID="txtnameofapplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 26px">
                <asp:Label ID="labbankrefNo" runat="server" Text="Bank Reference Number"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td style="height: 26px">
                <asp:TextBox ID="txtbankrefno" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="background-color: #d0d5d8; height: 17px;" class="txtBold">
                BACK OFFICE CHECK</td>
        </tr>
        <tr>
            <td style="height: 23px">
                <asp:Label ID="labPanNo" runat="server" Text="PAN ( Permanent Account Number ) logic and correctness"></asp:Label></td>
            <td style="height: 23px">
                <asp:DropDownList ID="ddlpan" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="labdigit" runat="server" Text="Is it 10 digits"></asp:Label></td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddldigit" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
            </td>
        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="labalphabet" runat="server" Text="Is tenth digit alphabetic"></asp:Label></td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlalphabet" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
                <asp:Label ID="labnumeric" runat="server" Text=" Are the 6th,7th,8th,and 9th digits numeric"></asp:Label></td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlnumeric" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labalphabetmatch" runat="server" Text='Is the fourth digit "P" for individuals, "H" for HUF,  "C" for companies and "F" for firms' Width="289px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlmatch" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labobervation" runat="server" Text='Other Observation ( Highlight details for any "No" above)'></asp:Label></td>
            <td>
                <asp:TextBox ID="txtobervation" runat="server" TextMode="MultiLine" Width="246px" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 16px; background-color: #d0d5d8;" align="center" class="txtBold" colspan="5">
                <asp:Label ID="lblFieldVerification" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labpanverified" runat="server" Text="Pan details verified with "></asp:Label></td>
            <td style="height: 16px">
                <asp:TextBox ID="txtverifier" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labpanmatch" runat="server" Text="Does the Pan # Match with record"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlpanmatch" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labpancardholdermatch" runat="server" Text="Does the Name of  the Pan card holder Match with record"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlpancardholder" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labFathermatch" runat="server" Text="Does the Name of  the Father / Husband Match with record"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlFathermatch" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labbirthmatch" runat="server" Text="Does the Date of Birth Match with record"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddldateofbirth" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labfinalstatus" runat="server" Text="Final Status"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlstatus" runat="server" SkinID="ddlSkin" DataSourceID="SqlDataSource1"  DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID">
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labremarks" runat="server" Text="REMARKS ( Clerarly specify reason for not okay cases and not confirmed cases.)"
                    Width="257px"></asp:Label></td>
            <td colspan="4" style="height: 16px">
                <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" Width="555px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labnameofverifier" runat="server" Text=" Name of the Verifier"></asp:Label></td>
            <td style="height: 16px">
                <asp:TextBox ID="txtnameofverifier" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labdatevisit" runat="server" Text="Date & Time of visit"></asp:Label></td>
            <td style="height: 16px">
                <asp:TextBox ID="txtdateofvisit" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, <%=txtdateofvisit.ClientID %>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="labSupervisorname" runat="server" Text="Supervisor's Name"></asp:Label></td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlSupervisorName" runat="server" OnSelectedIndexChanged="ddlSupervisorName_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="199px">
                </asp:DropDownList><asp:Label ID="lblvalid" runat="server" Font-Bold="true" ForeColor="Red"
                    SkinID="lblSkin" Text="Supervisor Name Is Mandatory"></asp:Label></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
                <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" ValidationGroup="grpValidate" SkinID="btnSaveSkin" /></td>
            <td style="height: 16px">
                <asp:Button ID="btncancel" runat="server" Text="CANCEL" OnClick="btncancel_Click" SkinID="btnCancelSkin" /></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT [CASE_STATUS_ID],[STATUS_NAME], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY CASE_STATUS_ID" ProviderName="System.Data.OleDb">
                    <SelectParameters>
                        <asp:SessionParameter Name="ProductId" SessionField="ProductId" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td style="height: 16px">
                <asp:HiddenField ID="hdnTransStart" runat="server" />
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:HiddenField ID="hdnSupID" runat="server" />
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        
         <asp:RequiredFieldValidator ID="RFV_SupervisorName" runat="server" ControlToValidate="ddlSupervisorName" 
        Display="None" ErrorMessage="Please select Supervisor Name." SetFocusOnError="true"  
        InitialValue="--Select--" ValidationGroup="grpValidate" >
       </asp:RequiredFieldValidator><asp:ValidationSummary ID="vsValidate" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="grpValidate" />
    </table>
    </fieldset>
</asp:Content>

