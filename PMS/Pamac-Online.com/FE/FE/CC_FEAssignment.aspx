<%@ Page Language="C#" MasterPageFile="~/FE/FE/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_FEAssignment.aspx.cs" Inherits="CPV_CC_CC_FEAssignment" Theme="SkinFile" %>
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
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend  class="FormHeading">FE Auto Assignment</legend>

<table id="tblMain"  cellpadding="0" cellspacing="0" width="100%">
 <tr>   
<td >&nbsp;
<asp:Label SkinID="lblSkin"  ID="Label1" runat="server" Text="From Date"></asp:Label></td>
<td style="width:5px" align="center">:</td>
<td><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
<img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Label SkinID="lblSkin"  ID="Label3" runat="server" Text="To Date"></asp:Label>
</td>
<td style="width:5px" align="center">:</td>
<td  ><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
<img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="Label4" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
    &nbsp;</td>
</tr>
    <tr>
        <td>
        </td>
        <td align="center" style="width: 5px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td align="center" style="width: 5px">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="height: 22px">
            &nbsp;<asp:Label ID="lblVerificationType" runat="server" SkinID="lblSkin" Text="Verification Type"></asp:Label></td>
        <td align="center" style="width: 5px; height: 22px;">
            :</td>
        <td style="height: 22px">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" DataSourceID="SqlDataSource1"
                DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID"
                SkinID="ddlSkin" ValidationGroup="grpDates" Width="120px">
            </asp:DropDownList></td>
        <td style="height: 22px">
            Product</td>
        <td align="center" style="width: 5px; height: 22px;">
            :</td>
        <td style="height: 22px">
            <asp:DropDownList ID="ddlproduct" runat="server" SkinID="ddlSkin" Width="120px">
                <asp:ListItem Value="0">--ALL--</asp:ListItem>
                <asp:ListItem Value="CC">CC</asp:ListItem>
                <asp:ListItem Value="RL">RL</asp:ListItem>
                <asp:ListItem Value="KYC">KYC</asp:ListItem>
            </asp:DropDownList></td>
        <td style="height: 22px">
        </td>
    </tr>
    <tr>
        <td colspan="6" height="8px">
        </td>        
    </tr>
    <tr>
        <td align="right" style="height: 24px">
            <asp:Button ID="btSearch" runat="server" OnClick="btSearch_Click" SkinID="btn" Text="Search"
                Width="104px" /></td>
        <td align="center" style="width: 5px; height: 24px;">
        </td>
        <td align="center" style="height: 24px">
            <asp:Button ID="btnFEAutoAssignmet" runat="server" CssClass="button" OnClick="btnFEAutoAssignmet_Click"
                SkinID="btn" Text="Auto FE Assignment" /></td>
        <td colspan="3" style="height: 24px">
            &nbsp; &nbsp; &nbsp;&nbsp; <asp:Button
                ID="BtnExport" runat="server" OnClick="BtnExport_Click" SkinID="btn" Text="Export" Width="85px" /></td>
    </tr>
<tr>
<td colspan="6" style="height: 14px"><asp:Label ID="Label5" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label></td>
</tr>
<tr>
    <td colspan="6" style="height: 52px">&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ProviderName="System.Data.OleDb" SelectCommand="&#13;&#10;Select '0' As  [VERIFICATION_TYPE_ID],  '--Select--'  As  [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER&#13;&#10;Union&#13;&#10;Select  [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER &#13;&#10;WHERE VERIFICATION_TYPE_ID IN (1,2,3,4,5,6,7,8,9,10,31,32,36,43) AND PARENT_TYPE_CODE in  ( 'DV','VV','RL')&#13;&#10;Order By VERIFICATION_TYPE_ID&#13;&#10;&#13;&#10;&#13;&#10;&#13;&#10;">
        </asp:SqlDataSource>
    </td>
</tr>
 
</table>
<asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select From Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select To Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="vsValidateDate" runat="server" ShowMessageBox="True"
         ShowSummary="False" ValidationGroup="grpDates"/>
</fieldset>

<fieldset><legend class="FormHeading">FE Assignment</legend>
 <table border="0" cellpadding="1" cellspacing="0" width="100%">   
     <tr>
         <td>
             <asp:Label ID="lblmesa" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
     </tr>
    <tr><td><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr> 
    <tr><td style="height: 88px">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
     <tr>
        <td style="width: 17px" >
                Client Name</td>
         <td colspan="2">
             :&nbsp;
         </td>
        <td >
        <asp:DropDownList ID="ddlclientname" runat="server" Width="168px" 
            DataSourceID="sdsClient" DataTextField="Client_Name" DataValueField="Client_id" 
            onselectedindexchanged="ddlclientname_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList></td><td style="width: 2px"></td><td></td>
        <td>
                </td>
        <td ></td><td style="width: 2px"></td><td>
            </td>   
            <td align="right"></td>         
        </tr>
    <tr>
        <td colspan="3" style="width: 34px; height: 44px;">
            Date :</td>
        <td style="width: 166px; height: 44px;">
        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>
        <td style="width: 2px; height: 44px;">
        </td>
        <td style="width: 34px; height: 44px;">Applicant Name</td><td style="height: 44px">:</td>
        <td style="width: 114px; height: 44px;"><asp:TextBox ID="txtCustName" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox><asp:CheckBox ID="chkAbsolute" runat="server" Text="Absolute" Checked="false" SkinID="chkSkin" /></td>
        <td style="height: 44px">Verification Type</td><td style="width: 2px; height: 44px;">:</td><td style="height: 44px">
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin" Visible="False">
                </asp:DropDownList></td>
                <td style="height: 44px">
                </td>
                <td style="height: 44px">
                    FE Name</td><td style="width: 2px; height: 44px;">:</td><td style="height: 44px">
                    <asp:DropDownList ID="ddlSearchFE" runat="server" DataSourceID="sdsSearchFE"
                        DataTextField="FULLNAME" DataValueField="FE_ID" OnDataBound="ddlSearchFE_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                    <td style="height: 44px"><asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="FEAssign" /></td>
            </tr>
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
    <tr><td>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td >From Pincode</td><td style="width: 2px">:</td><td>
        <asp:DropDownList ID="ddlFromPin" runat="server" DataSourceID="sdsPincode" DataTextField="PINCODE" DataValueField="PINCODE" OnDataBound="ddlFromPin_DataBound" SkinID="ddlSkin">
        </asp:DropDownList></td>
        <td >To Pincode</td><td style="width: 2px">:</td><td><asp:DropDownList ID="ddlToPin" runat="server" DataSourceID="sdsPincode" DataTextField="PINCODE" DataValueField="PINCODE" OnDataBound="ddlToPin_DataBound" SkinID="ddlSkin">
        </asp:DropDownList></td>
        <td>
                <asp:Button ID="btnSearchFE" runat="server" SkinID="btnSearchSkin" OnClick="btnSearchFE_Click" /></td>
        <td >FE Name<span style="color:Red;">*</span></td><td style="width: 2px">:</td><td>
            <asp:DropDownList ID="ddlFE" runat="server" OnDataBound="ddlFE_DataBound" DataSourceID="sdsFE" DataTextField="FULLNAME" DataValueField="FE_ID" SkinID="ddlSkin">
            </asp:DropDownList></td>   
            <td align="right"><asp:Button ID="btnAssign" runat="server" SkinId="btnAssingSkin" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" /></td>         
        </tr>
    </table></td></tr>  
    <tr><td>        
        <asp:GridView ID="gvFEAssignmentCases" runat="server" DataSourceID="sdsGV" OnPageIndexChanging="gvFEAssignmentCases_PageIndexChanging" Width="100%" OnSorting="gvFEAssignmentCases_Sorting" OnDataBound="gvFEAssignmentCases_DataBound" SkinID="gridviewNoSort">           
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
    <tr><td align="right" style="height: 26px"><asp:Button ID="btnAssign1" runat="server" SkinId="btnAssingSkin" OnClick="btnAssign_Click" ValidationGroup="vgrpFE" /></td></tr>
    </table>
    </fieldset>
    </td></tr>
</table>
     <asp:SqlDataSource ID="sdsVeriType" runat="server"  ProviderName="System.Data.OleDb"
     SelectCommand="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE],* from VERIFICATION_TYPE_MASTER &#13;&#10;WHERE VERIFICATION_TYPE_ID IN(1,2,3,4,5,6,7,8,9,31,32,43) AND PARENT_TYPE_CODE in  ( 'DV','VV','RL')&#13;&#10;Order By Activity_id&#13;&#10;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsPincode" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FPM.PINCODE FROM FE_PINCODE_MAPPING AS FPM INNER JOIN FE_VW AS FV ON FPM.FE_ID = FV.EMP_ID WHERE (FV.CENTRE_ID = ?) ORDER BY FPM.PINCODE">
            <SelectParameters>
                <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGV" runat="server"  ProviderName="System.Data.OleDb"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsFE" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID where ([Centre_ID]=?) order by FULLNAME ">
        <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
        
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
        <asp:SqlDataSource ID="sdsSearchFE" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID where ([Centre_ID]=?) order by FULLNAME ">
         <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsClient" runat="server"  ProviderName="System.Data.OleDb"
                    SelectCommand="SELECT '0' as [CLIENT_ID],'--All--' as [CLIENT_NAME]  UNION &#13;&#10; SELECT DISTINCT [CLIENT_ID], [CLIENT_NAME] FROM [HierCeToCtView] &#13;&#10;WHERE [CENTRE_ID]=?   And&#13;&#10;CLIENT_ID IS NOT NULL order by CLIENT_NAME">
                     <SelectParameters>
                        <asp:SessionParameter Name="?" SessionField="CENTREID" />
                    </SelectParameters>
                    </asp:SqlDataSource>
        <asp:RegularExpressionValidator ID="revDate" runat="server" ErrorMessage="Please enter valid date format for Date" Display="None" SetFocusOnError="True" ValidationGroup="FEAssign" ControlToValidate="txtDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup='vgrpFE' />
        <asp:RequiredFieldValidator ID="rfvFE" runat="server" ErrorMessage="Please select FE to assign" ControlToValidate="ddlFE" Display="None" SetFocusOnError="True" ValidationGroup="vgrpFE"></asp:RequiredFieldValidator>
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

    <asp:CustomValidator ID="valgv" runat="server" ClientValidationFunction="vaidation"
        Display="None" ErrorMessage="Please select at least one Case. " SetFocusOnError="True"
        ValidationGroup="vgrpFE"></asp:CustomValidator>
</asp:Content>


