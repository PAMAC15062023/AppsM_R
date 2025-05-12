<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" Theme="SkinFile"  AutoEventWireup="true" CodeFile="IDOC_Paasport.aspx.cs" Inherits="IDOC_IDOC_IDOC_Paasport" Title="Untitled Page" %>
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
    <table style="width: 993px; height: 359px">
        <tr>
            <td colspan="5" style="height: 15px; background-color: #d0d5d8;" align="center" class="txtBold">
                &nbsp;<asp:Label ID="lblhead" runat="server" SkinID="lblSkin"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 113px; height: 17px; background-color: #e7f6ff;">
                <asp:Label ID="labdateofreceipt" runat="server" Text="Date of Receipt" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff;">
                <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, <%=txtDate.ClientID %>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]</td>
            <td style="width: 17px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff;">
                <asp:Label ID="labref_No" runat="server" Text="CPA Reference Number " Width="124px" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 100px; background-color: #e7f6ff;">
                <asp:TextBox ID="txtCPARef" runat="server" MaxLength="20" SkinID="txtSkin" ValidationGroup="grpAttempts"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 113px; height: 10px; background-color: #e7f6ff;">
                <asp:Label ID="labRef" runat="server" Text="Bank Reference Number" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; height: 10px; background-color: #e7f6ff;">
                <asp:TextBox ID="txtbankref" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff;">
                <asp:Label ID="labName" runat="server" Text="Name of the Owner " SkinID="lblSkin"></asp:Label></td>
            <td style="width: 100px; background-color: #e7f6ff;">
                <asp:TextBox ID="txtnameofowner" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="5" style="background-color: #d0d5d8; height: 16px;">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" SkinID="lblSkin" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 19px;">
                <asp:Label ID="lblNameofseviceprovider" runat="server" Text="Name of the Service provider/supplier" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 19px;">
                <asp:TextBox ID="txtServicProvide" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff;">
                <asp:Label ID="Label6" runat="server" Text="Label" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff;">
                <asp:TextBox ID="txtnum" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; background-color: #e7f6ff;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 19px;">
                <asp:Label ID="labdateofissue" runat="server" Text="Date of Issue" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 19px;">
                <asp:TextBox ID="txtdateofissue" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, <%=txtdateofissue.ClientID %>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />dd/MM/yyyy]</td>
            <td style="width: 17px; background-color: #e7f6ff; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px; background-color: #e7f6ff;">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="labbankofficeremark" runat="server" Text="Bank Office Remark" SkinID="lblSkin"></asp:Label></td>
            <td colspan="4" style="background-color: #e7f6ff">
                <asp:TextBox ID="txtbankofficeremarks" runat="server" TextMode="MultiLine" Width="297px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="5" style="background-color: #d0d5d8">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label17" runat="server" SkinID="lblSkin" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 113px; height: 22px; background-color: #e7f6ff">
                <asp:Label ID="labnameofperson" runat="server" Text="Name of the person Contact" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; height: 22px; background-color: #e7f6ff">
                <asp:TextBox ID="txtpersoncontact" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; height: 22px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 22px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 22px; background-color: #e7f6ff">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="labdesignation" runat="server" Text="Designation & Department of person contact" Width="141px" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff">
                <asp:TextBox ID="txtDesignation" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 30px;">
                <asp:Label ID="labdoesformatofthebillmatch" runat="server" Text="Does the format of the bill match with standard format" Width="146px" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 30px;">
                <asp:DropDownList ID="ddlbillformat" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 20px;">
                <asp:Label ID="labNumbermatch" runat="server" Text="Does the Number match with supplier records" SkinID="lblSkin" Width="158px"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 20px;">
                <asp:DropDownList ID="ddlnumbermatch" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 20px;">
            </td>
            <td style="width: 100px; height: 20px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 21px;">
                <asp:Label ID="labnamematch" runat="server" Text="Does the name & address of the owner match with records" Width="169px" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 21px;">
                <asp:DropDownList ID="ddladdressmatch" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="labfinalstatus" runat="server" Text="Final status" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff">
                <asp:DropDownList ID="ddlFinalStatus" runat="server" AutoPostBack="false" DataSourceID="sdsCaseStatus"
                    DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID" SkinID="ddlSkin"
                    TabIndex="41">
                </asp:DropDownList></td>
            <td style="width: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFinalStatus"
                    ErrorMessage="Please Select Final Status" ValidationGroup="GET_Attempt" Width="54px" Display="None"></asp:RequiredFieldValidator></td>
            <td style="width: 100px; background-color: #e7f6ff">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="Label16" runat="server" Text="Remarks(Clearly spcify reson for Not okay case and Not Confirm case)" Width="185px" SkinID="lblSkin"></asp:Label></td>
            <td colspan="4" style="background-color: #e7f6ff">
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="294px" SkinID="txtSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRemarks"
                    ErrorMessage="Please Enter Remark" ValidationGroup="GET_Attempt" Width="54px" Display="None"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="CLERK CONFIRMED THE DETAILS"></asp:Label></td>
            <td colspan="4" style="background-color: #e7f6ff">
                <asp:TextBox ID="txtclearkconfirmed" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="294px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="5" style="background-color: #d0d5d8; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 26px;">
                <asp:Label ID="txtverifer" runat="server" SkinID="lblSkin">Name of the verifer</asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 26px;">
                <asp:TextBox ID="txtVerifier" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 26px;">
                <asp:Label ID="labdate" runat="server" SkinID="lblSkin">Date</asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff; height: 26px;">
                <asp:TextBox ID="txtdate1" runat="server" Width="143px" SkinID="txtSkin"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, <%=txtdate1.ClientID %>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]</td>
            <td style="width: 17px; background-color: #e7f6ff; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px; background-color: #e7f6ff">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdate1"
                    ErrorMessage="Please Select Date" ValidationGroup="GET_Attempt" Width="54px" Display="None"></asp:RequiredFieldValidator></td>
            <td style="width: 100px; background-color: #e7f6ff; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; height: 26px; background-color: #e7f6ff">
                <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Width="86px">Supervisor Name</asp:Label></td>
            <td style="width: 111px; height: 26px; background-color: #e7f6ff">
                <asp:DropDownList ID="ddlSupervisorName" runat="server" OnSelectedIndexChanged="ddlSupervisorName_SelectedIndexChanged" AutoPostBack="true"
                    SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:Label ID="lblvalid" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"
                    Text="Supervisor Name Is Mandatory" Width="173px"></asp:Label></td>
            <td style="width: 17px; height: 26px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 26px; background-color: #e7f6ff">
                <asp:CustomValidator ID="cvSupervisorName" runat="server" ClientValidationFunction="ClientValidate"
                    ControlToValidate="ddlSupervisorName" Display="None" ErrorMessage="Please select Supervisor Name."
                    SetFocusOnError="true" ValidationGroup="gvValidate">
       </asp:CustomValidator></td>
            <td style="width: 100px; height: 26px; background-color: #e7f6ff">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff; height: 26px;">
            </td>
            <td style="width: 111px; background-color: #e7f6ff; height: 26px;">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" SkinID="btnSubmitSkin"
                    Text="Submit" ValidationGroup="GET_Attempt" /></td>
            <td style="width: 17px; background-color: #e7f6ff; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px; background-color: #e7f6ff">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btnCancelSkin"
                    Text="Cancel" /></td>
            <td style="width: 100px; background-color: #e7f6ff; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            <td style="width: 111px; background-color: #e7f6ff">
            </td>
            <td style="width: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; background-color: #e7f6ff">
            </td>
        </tr>
        <tr>
            <td style="width: 113px; background-color: #e7f6ff">
                <asp:SqlDataSource ID="sdsCaseStatus" runat="server" ProviderName="System.Data.OleDb"
                    SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY CASE_STATUS_ID">
                    <SelectParameters>
                        <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td style="width: 111px; background-color: #e7f6ff">
                <asp:HiddenField ID="hdnTransStart" runat="server" />
            </td>
            <td style="width: 17px; background-color: #e7f6ff">
            </td>
            <td style="width: 100px; height: 17px; background-color: #e7f6ff"><asp:HiddenField ID="hdnSupID" runat="server" />
            </td>
            <td style="width: 100px; background-color: #e7f6ff">
            </td>
        </tr>
    </table>
</asp:Content>

