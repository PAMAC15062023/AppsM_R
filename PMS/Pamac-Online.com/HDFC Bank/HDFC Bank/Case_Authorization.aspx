<%@ Page Language="C#" MasterPageFile="~/HDFC/HDFC/MasterPage.master" AutoEventWireup="true" CodeFile="Case_Authorization.aspx.cs" Inherits="HDFC_HDFC_Case_Authorization" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function vaidation(source, arguments)
{

var gvID=document.getElementById("<%=gvFEAssignmentCases.ClientID %>");
var length=gvID.rows.length;
var i;
var nCount="Y";
for(i=1;i<length;i++)
{

if( document.getElementById(gvID.rows[i].cells[0].firstChild.id).checked )
{

nCount="N";
break;
}

}
if(nCount=="Y")
{
arguments.IsValid=false;
}
else
{
arguments.IsValid=true;
}
}
 
</script>
<fieldset style="background-color: #e6ffff"><legend class="FormHeading">FE Assignment</legend>
    <table>
        <tr>
            <td align="right" colspan="8" style="height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 26px">
 <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 30px; height: 26px">
                Date :</td>
            <td style="width: 271px; height: 26px">
        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>
            <td style="width: 100px; height: 26px">
                Verification Type :</td>
            <td style="width: 100px; height: 26px">
                <asp:DropDownList ID="ddlType" runat="server" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Value="1">Residence Address</asp:ListItem>
                                                    <asp:ListItem Value="2">Office address</asp:ListItem>
                                                     <asp:ListItem Value="2">Current account CPV</asp:ListItem>
               
                </asp:DropDownList></td>
            <td style="width: 100px; height: 26px">
                Applicant Name :</td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txtCustName" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox></td>
            <td align="center" colspan="2" style="height: 26px">
                <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="FEAssign" /></td>
        </tr>
        <tr>
            <td style="height: 26px" colspan="8">
                <asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="8" rowspan="7">
    <asp:Button ID="btnAssign" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" Width="122px" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="BtnReject" runat="server" OnClick="BtnReject_Click"
                    Text="Reject" Width="127px" SkinID="btn" />
        <asp:GridView ID="gvFEAssignmentCases" runat="server" DataSourceID="sdsGV" OnPageIndexChanging="gvFEAssignmentCases_PageIndexChanging" Width="100%" OnSorting="gvFEAssignmentCases_Sorting" SkinID="gridviewSkin" OnDataBound="gvFEAssignmentCases_DataBound">           
            <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                </HeaderTemplate>

                <ItemTemplate>
                    <asp:CheckBox ID="chkCaseId" runat="server" /><asp:HiddenField ID="hidCaseId" runat="server"
                        Value='<%# DataBinder.Eval(Container.DataItem, "Case ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <asp:Button ID="btnAssign1" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" Width="122px" Visible="False" /></td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    </fieldset>
     <asp:SqlDataSource ID="sdsVeriType" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER WHERE (ACTIVITY_ID = '1011')AND VERIFICATION_TYPE_ID IN('1','2') AND (PARENT_TYPE_CODE = 'VV')"></asp:SqlDataSource>
         <asp:SqlDataSource ID="sdsPincode" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FPM.PINCODE FROM FE_PINCODE_MAPPING AS FPM INNER JOIN FE_VW AS FV ON FPM.FE_ID = FV.EMP_ID WHERE (FV.CENTRE_ID = ?) ORDER BY FPM.PINCODE">
            <SelectParameters>
                <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGV" runat="server"  ProviderName="System.Data.OleDb"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsFE" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID  where ([Centre_ID]=?)  order by FULLNAME" >
         <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
        <asp:SqlDataSource ID="sdsSearchFE" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID  where ([Centre_ID]=?)  order by FULLNAME">
         <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
    &nbsp;
        <asp:RegularExpressionValidator ID="revDate" runat="server" ErrorMessage="Please enter valid date format for Date" Display="None" SetFocusOnError="True" ValidationGroup="FEAssign" ControlToValidate="txtDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vgrpFE" />
    &nbsp;&nbsp;
        <script type="text/javascript" language="javascript">
            <!--
               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }
            -->
        </script>

        <asp:CustomValidator ID="valgv" runat="server" ClientValidationFunction="vaidation" ValidationGroup="vgrpFE" Display="None" ErrorMessage="Please select at least one Case. " SetFocusOnError="True"></asp:CustomValidator>

    
</asp:Content>


