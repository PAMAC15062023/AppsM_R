<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HDFC/HDFC/MasterPage.master"  CodeFile="KYC_FEAssignment.aspx.cs" Inherits="CPV_KYC_KYC_FEAssignment" %>

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
<fieldset><legend class="FormHeading">FE Assignment</legend>
 <table border="0" cellpadding="1" cellspacing="0" width="100%">   
    <tr><td style="height: 15px"><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr> 
    <tr><td>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr><td >Date</td><td style="width: 2px">:</td><td>
        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>
        <td>
        </td>
        <td>Applicant Name</td><td style="width: 2px">:</td>
        <td><asp:TextBox ID="txtCustName" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox></td>
        <td>Verification Type</td><td style="width: 2px">:</td><td>
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin">
                </asp:DropDownList></td>
                <td>
                </td>
                <td>
                    </td><td style="width: 2px">:</td><td>
                    </td>
                    <td><asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="FEAssign" /></td>
            </tr>
            <tr><td height="8px"></td></tr>
            <%--<tr><td >Verification Type</td><td style="width: 2px">:</td><td>
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin">
                </asp:DropDownList></td>
                <td>
                </td>
                <td>
                    FE Name</td><td style="width: 2px">:</td><td>
                    <asp:DropDownList ID="ddlSearchFE" runat="server" DataSourceID="sdsSearchFE"
                        DataTextField="FULLNAME" DataValueField="FE_ID" OnDataBound="ddlSearchFE_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                    <td><asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="FEAssign" /></td></tr>--%>
            </table>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td align="right">
    <asp:Button ID="btnAssign" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" /></td></tr>  
    <tr><td>        
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
    </td></tr>
    <tr><td align="right" style="height: 26px"><asp:Button ID="btnAssign1" runat="server" SkinId="btn" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" Text="Okay" /></td></tr>
    </table>
    </fieldset>
     <asp:SqlDataSource ID="sdsVeriType" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT VERIFICATION_TYPE_ID, VERIFICATION_TYPE_CODE FROM VERIFICATION_TYPE_MASTER WHERE (ACTIVITY_ID = '1011')AND VERIFICATION_TYPE_ID IN('1','2','19') AND (PARENT_TYPE_CODE = 'VV')"></asp:SqlDataSource>
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
