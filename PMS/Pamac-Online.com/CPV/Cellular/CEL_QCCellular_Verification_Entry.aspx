<%@ Page Language="C#"  MasterPageFile="CEL_MasterPage.master" MaintainScrollPositionOnPostBack="true"  AutoEventWireup="true" Theme="SkinFile"  CodeFile="CEL_QCCellular_Verification_Entry.aspx.cs" Inherits="CPV_CC_CEL_QCCELLULAR_VERIFICATION_ENTRY" Title="Cellular Verification Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">

function validation(source, arguments)

{

var remark=document.getElementById("<%=TxtRemark.ClientID%>");
var dropdownID=document.getElementById("<%=ddlSalesFlyersRcd.ClientID%>");
var dropdownIDTariffPlan=document.getElementById("<%=txtTarPlan.ClientID%>");
var dropdownIDFirstBillExplation=document.getElementById("<%=txtBillExp.ClientID%>");
var dropdownIDSubMet =document.getElementById("<%=txtSubMet.ClientID %>")
var dropdownIDContactability =document.getElementById("<%=ddlContactability.ClientID %>")
var dropdownIDWelcomeVisit=document.getElementById("<%=ddlWelcomeVisit.ClientID%>")

//getCaseStatus = document.getElementById("ctl00_C1_ddlCaseStatus");
//getContactability = document.getElementById("ctl00_C1_ddlContactability");
//getNatureOfBusiness = document.getElementById("ctl00_C1_txtNatureOfBusiness");
//getdisconnected = document.getElementById("ctl00_C1_ddldisconnected");
//getOccupation = document.getElementById("ctl00_C1_ddloccupation");

//Please Select Occupation



var str=remark.value;



str = str.toLowerCase();



//if(str.match("sub was received flyer"))
// {
// dropdownID.value="Yes";
// }
// if(str.match("sub was not received flyer"))
// {
//  dropdownID.value="No";
// }
// if(str.match("not aware about flyer"))
// {
//  dropdownID.value="NA";
// }
 if(str.match("tariff plan & bill payment explained"))
 {
    dropdownIDTariffPlan.value="Y";
    dropdownIDFirstBillExplation.value="Y";
    
 }
 else if(str.match("tariff plan not explained but bill payment explained"))
 {
    dropdownIDTariffPlan.value="N";
    dropdownIDFirstBillExplation.value="Y";
 }
 else if(str.match("tariff plan explained but bill payment not explained"))
 {
    dropdownIDTariffPlan.value="Y";
    dropdownIDFirstBillExplation.value="N";
 }
 else
 {
    dropdownIDTariffPlan.value="N";
    dropdownIDFirstBillExplation.value="N";
 }
 
 if(str.match("sub was available"))
 {
    dropdownIDSubMet.value="Y";
 }
 if(str.match("sub was not available"))
 {
    dropdownIDSubMet.value="N";
 }
 if(!(str.match("sub was available")) && (!(str.match("sub was not available"))))
{
    dropdownIDSubMet.value="N";
}

// if(str.match("information obtained from sub at the time of tele calling"))
// {
//    
//    dropdownIDContactability.value="None";
// }
// else if(str.match("sub was available"))   
// {
//    dropdownIDContactability.value="None";
// }
// else if(str.match("sub was not available"))   
// {
//    dropdownIDContactability.value="NM";
// }
// else if((str.match("sub was not available")) && (str.match("information obtained from sub at the time of tele calling")))   
// {
//    dropdownIDContactability.value="None";
// }
 if(str.match("welcome visit not done"))
 {
    
    dropdownIDWelcomeVisit.value="No";
 }
 if(str.match("welcome visit done"))
 {
    
    dropdownIDWelcomeVisit.value="Yes";
 }
//    if(!(str.match("sub was available")) && (!(str.match("sub was not available"))))
//    {
////    remark.focus();
//    alert('Please Enter Sub was available or Sub was not available');
////    arguments.IsValid=false;
//    }
 
 
 }
 function RemarkCheck()
 {
 var remark=document.getElementById("<%=TxtRemark.ClientID%>");
 var str=remark.value;



str = str.toLowerCase();

 if(!(str.match("sub was available")) && (!(str.match("sub was not available"))))
    {
    
   
    alert('Please Enter Sub was available or Sub was not available');
//    arguments.IsValid=false;
    }
 }

function echeck() 
{
       var str = document.getElementById("ctl00_C1_txtEmail"); 

		var at="@"
		var dot="."
		var lat=str.indexOf(at)
		var lstr=str.length
		var ldot=str.indexOf(dot)
		if (str.indexOf(at)==-1)
		{
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
		    alert("Invalid E-mail ID")
		    return false
		}

		 if (str.indexOf(at,(lat+1))!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.indexOf(dot,(lat+2))==-1){
		    alert("Invalid E-mail ID")
		    return false
		 }
		
		 if (str.indexOf(" ")!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

 		 return true					
	}
function ValidateEmail()
{
	var emailID=document.getElementById("ctl00_C1_txtEmail");
	
	if ((emailID.value==null)||(emailID.value==""))
	{
		alert("Please Enter Email ID")
		emailID.focus()
		return false
	}
	if (echeck(emailID.value)==false)
	{
		emailID.value=""
		emailID.focus()
		return false
	}
	return true
 }


function PreventCharacterToAdd()
 { 
  getControlsId = document.getElementById("<%=TxtRemark.ClientID%>");
  if(getControlsId.value.length > 2000)
  {
    getControlsId.value = getControlsId.value.substring( 0, 1999 ); 
    return false;
  } 
}

function checkDdlValue()
{
   
    getControlsIdRemark1 = document.getElementById("ctl00_C1_ddlRemark1");
    getControlIdofSubMet = document.getElementById("ctl00_C1_ddlSubMet") 
    if(getControlsIdRemark1.value=="Sub was available")
    {
        getControlIdofSubMet.value = "Yes"
        
        
    }
 if(getControlsIdRemark1.value=="Disconnected")
    {
         getControlIdofSubMet.value = "Select"
    }
     if(getControlsIdRemark1.value=="Sub was not available")
    {
         getControlIdofSubMet.value = "No"
        
    }
}
function checkNumeric(textBox) 
{
    var textBox = document.getElementById(textBox); 
    if(isNaN(textBox.value)) 
    {
        alert("- Please provide a numeric value."); 
        textBox.value=""; 
        return false; 
    }
}


</script>

    &nbsp;<fieldset><legend class="FormHeading">QC Cellular Verification Entry</legend>
    <table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
     <tr><td><asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label></td></tr>
      <tr><td> <span class="txtRed">* </span>Indicate mandatory fields. 
       
      </td>
      </tr>
     <tr>
     <td style="height: 117px">
         <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="False" Width="632px" SkinID="gridviewSkin" OnRowCommand="gvView_RowCommand">
             <Columns>
                 <asp:TemplateField HeaderText="CaseID">
                     
                     <ItemTemplate>
                         <asp:LinkButton ID="lkCaseID" runat="server" CommandArgument='<%# Eval("Case_ID") %>' CommandName="Select" Text='<%# Eval("Case_ID") %>'></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="REF_NO" HeaderText="Can ID" />
                 <asp:BoundField DataField="CASE_REC_DATETIME" HeaderText="Case Recieved Date" />
                 <asp:BoundField DataField="SEND_DATETIME" HeaderText="Send Date" />
                 <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                 <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                 <asp:BoundField DataField="Status_Name" HeaderText="Status Code" />
                 <asp:BoundField DataField="CELLNO" HeaderText="Mobile No" />
                 <asp:BoundField DataField="Case_Type" HeaderText="Type Of Case" />
             </Columns>
         </asp:GridView>
         <br />
         <table width="100%">
             <tr>
                 <td align="left" valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="lblRef" runat="server">Ref No</asp:Label></td>
                 <td  align="left" valign="top">
                     :</td>
                 <td  align="left" valign="top" style="width: 200px">
                     <asp:Label ID="lblRefNo" SkinID="lblSkin"  runat="server" Font-Bold="True" ForeColor="Black" ></asp:Label></td>
                 <td  align="left" valign="top">
                     Case_Type</td>
                 <td  align="left" valign="top" style="width: 33px">
                     :</td>
                 <td  align="left" valign="top">
                     <asp:Label ID="lblCaseTypeCode" runat="server" Font-Bold="True" ForeColor="Black"
                         SkinID="lblSkin"></asp:Label></td>
                 <td  align="left" valign="top" style="width: 108px"></td>
                 <td align="left" valign="top"></td>
                 <td  align="left" valign="top"></td>
             </tr>
             <tr>
                 <td  align="left" valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="Label21" runat="server">Case Id</asp:Label></td>
                 <td  align="left" valign="top">
                     :</td>
                 <td  align="left" valign="top" style="width: 200px">
                     <asp:Label ID="lblcaseid" SkinID="lblSkin"  runat="server" Font-Bold="True" ForeColor="Black" ></asp:Label></td>
                 <td  align="left" valign="top">
                     <asp:Label SkinID="lblSkin"   ID="Label2" runat="server">Subscriber Name</asp:Label></td>
                 <td  align="left" valign="top" style="width: 33px">
                     :</td>
                 <td  align="left" valign="top">
                <asp:Label ID="lblappname" runat="server" SkinID="lblSkin"  Font-Bold="True" ForeColor="Black" ></asp:Label></td>
                 <td  align="left" valign="top" style="width: 108px">
                     <asp:Label SkinID="lblSkin"   ID="Label4" runat="server">MobileNo.</asp:Label></td>
                 <td align="left" valign="top">
                     :</td>
                 <td  align="left" valign="top">
                <asp:Label ID="lblmobile" runat="server" SkinID="lblSkin"  Font-Bold="True" ForeColor="Black" ></asp:Label></td>
             </tr>
             <tr>
                 <td colspan="9" style="background-color: #d0d5d8; height: 18px;" align="left" class="txtBold" valign="top">
                     Residence Detail</td>
             </tr>
             <tr>
                 <td  align="left" valign="top" style="width: 111px">
                    <asp:Label ID="Label53" runat="server" SkinID="lblSkin"> Address1</asp:Label></td>
                 <td  align="left" valign="top">
                     :</td>
                 <td  align="left" colspan="7" valign="top">
                    <asp:TextBox ID="txtresiadd1" runat="server" SkinID="txtSkin"  Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  align="left" valign="top" style="width: 111px">
                    <asp:Label ID="Label55" runat="server" SkinID="lblSkin"> Address2</asp:Label></td>
                 <td  align="left" valign="top">
                     :</td>
                 <td align="left" colspan="7" valign="top" >
                    <asp:TextBox ID="txtresiadd2" runat="server"  SkinID="txtSkin" Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  align="left" valign="top" style="width: 111px">
                    <asp:Label ID="Label57" runat="server" SkinID="lblSkin"> Address3</asp:Label></td>
                 <td  align="left" valign="top">
                     :</td>
                 <td align="left" colspan="7" valign="top">
                    <asp:TextBox ID="txtresiadd3" runat="server"  SkinID="txtSkin" Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  align="left" valign="top" style="width: 111px; height: 24px;">
                    <asp:Label ID="Label59" runat="server" SkinID="lblSkin"> Street</asp:Label></td>
                 <td  align="left" valign="top" style="height: 24px">
                     :</td>
                 <td align="left" colspan="7" valign="top" style="height: 24px">
                    <asp:TextBox ID="txtresistreet" runat="server" MaxLength="50" SkinID="txtSkin"  Width="868px" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label61" runat="server" SkinID="lblSkin" Width="35px">City</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left"  valign="top" style="width: 200px">
                    <asp:TextBox ID="txtresicity" runat="server" MaxLength="20" SkinID="txtSkin" ></asp:TextBox></td>
                 <td align="left"  valign="top">
                    <asp:Label ID="Label63" runat="server" SkinID="lblSkin">PinCode</asp:Label></td>
                 <td align="left"  valign="top" style="width: 33px">
                     :</td>
                 <td align="left"  valign="top">
                    <asp:TextBox ID="txtresipincode" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtresipincode');"></asp:TextBox></td>
                 <td align="left"  valign="top" style="width: 108px">
                 </td>
                 <td align="left"  valign="top">
                 </td>
                 <td align="left"  valign="top">
                 </td>
             </tr>
              <%--///////////add by santosh shelar 27-08-08////////////////////////////////--%>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label64" runat="server" SkinID="lblSkin">Phone No1</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" valign="top" style="width: 200px">
                    <asp:TextBox ID="txtresiphone1" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtresiphone1');"></asp:TextBox></td>
                 <td align="left"  valign="top">
                    <asp:Label ID="Label66" runat="server" SkinID="lblSkin">Phone No2</asp:Label></td>
                 <td align="left"  valign="top" style="width: 33px">
                     :</td>
                 <td align="left"  valign="top">
                     <asp:TextBox ID="txtresiphone2" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtresiphone2');"></asp:TextBox></td>
                 <td align="left"  valign="top" style="width: 108px">
                 </td>
                 <td align="left"  valign="top">
                     <asp:Label ID="Label1" runat="server" SkinID="lblSkin">Cell No :</asp:Label></td>
                 <td align="left"  valign="top">
                     <asp:TextBox ID="txtCellNo" runat="server" MaxLength="20" Onchange="return checkNumeric('ctl00_C1_txtresiphone2');"
                         SkinID="txtSkin"></asp:TextBox></td>
             </tr>
                                           
             <tr>
                 <td colspan="9" style="background-color: #d0d5d8;" align="left" class="txtBold" valign="top">
                     Office Detail
                 </td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label39" runat="server" SkinID="lblSkin"> Address1</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" valign="top" colspan="7">
                    <asp:TextBox ID="txtcomadd1" runat="server" SkinID="txtSkin"  Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px; height: 34px;">
                    <asp:Label ID="Label40" runat="server" SkinID="lblSkin"> Address2</asp:Label></td>
                 <td align="left"  valign="top" style="height: 34px">
                     :</td>
                 <td align="left" valign="top" colspan="7" style="height: 34px">
                    <asp:TextBox ID="txtcomadd2" runat="server"  SkinID="txtSkin"  Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label41" runat="server" SkinID="lblSkin"> Address3</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" valign="top" colspan="7">
                    <asp:TextBox ID="txtcomadd3" runat="server"  SkinID="txtSkin" Width="868px" MaxLength="100" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label42" runat="server" SkinID="lblSkin"> Street</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" valign="top" colspan="7" style="height: 26px">
                    <asp:TextBox ID="txtcomStreet" runat="server" MaxLength="100" SkinID="txtSkin" Width="868px" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                    <asp:Label ID="Label44" runat="server" SkinID="lblSkin" Width="35px">City</asp:Label></td>
                 <td align="left" valign="top">
                     :</td>
                 <td align="left"  valign="top" style="width: 200px">
                    <asp:TextBox ID="txtcity" runat="server" MaxLength="20" SkinID="txtSkin" ></asp:TextBox></td>
                 <td align="left"  valign="top">
                    <asp:Label ID="Label45" runat="server" SkinID="lblSkin">PinCode</asp:Label></td>
                 <td align="left" valign="top" style="width: 33px">
                     :</td>
                 <td align="left" valign="top">
                    <asp:TextBox ID="txtpincode" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtpincode');"></asp:TextBox></td>
                 <td align="left"  valign="top" style="width: 108px">
                 </td>
                 <td align="left"  valign="top">
                 </td>
                 <td align="left"  valign="top">
                 </td>
             </tr>
             <tr>
                 <td align="left" valign="top" style="width: 111px; height: 33px;">
                    <asp:Label ID="Label46" runat="server" SkinID="lblSkin">Phone No1</asp:Label></td>
                 <td align="left" valign="top" style="height: 33px">
                     :</td>
                 <td align="left"  valign="top" style="width: 200px; height: 33px;">
                    <asp:TextBox ID="txtphone1" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtphone1');"></asp:TextBox></td>
                 <td align="left"  valign="top" style="height: 33px">
                    <asp:Label ID="Label48" runat="server" SkinID="lblSkin">Phone No2</asp:Label></td>
                 <td align="left"  valign="top" style="width: 33px; height: 33px;">
                     :</td>
                 <td align="left"  valign="top" style="height: 33px">
                    <asp:TextBox ID="txtphone2" runat="server" MaxLength="20" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtphone2');"></asp:TextBox></td>
                 <td align="left"  valign="top" style="width: 108px; height: 33px;">
                 </td>
                 <td align="left"  valign="top" style="height: 33px">
                 </td>
                 <td align="left"  valign="top" style="height: 33px">
                 </td>
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin" ID="Label6" runat="server">Credit Status</asp:Label></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left"  valign="top" style="width: 200px">
                     <asp:TextBox ID="txtCredStatus" runat="server"></asp:TextBox></td>
                 <td align="left"  valign="top">
                     <asp:Label SkinID="lblSkin"   ID="Label8" runat="server">Sort Code</asp:Label>
                     
                 </td>
                 <td align="left"  valign="top" style="width: 33px">
                     :</td>
                 <td align="left"  valign="top">
                     <asp:TextBox ID="txtSortCode" runat="server" MaxLength="20" Onchange="return checkNumeric('ctl00_C1_txtphone2');"
                         SkinID="txtSkin"></asp:TextBox></td>
                 <td align="left"  valign="top" style="width: 108px">
                     Comments Code</td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" valign="top">
                     <asp:TextBox ID="txtCommCode" runat="server" MaxLength="20" Onchange="return checkNumeric('ctl00_C1_txtphone2');"
                         SkinID="txtSkin"></asp:TextBox></td>
             </tr>
             <tr>
                 <td align="left" valign="top" style="width: 111px">
                     Comments Code Reason</td>
                 <td align="left" valign="top">
                     :</td>
                 <td colspan="7" align="left" valign="top" style="width: 200px">
                 <%--///////add by santosh shelar increse by lenth 20 to 500/////////--%>
                   <asp:TextBox ID="txtCommentCodeReason" runat="server" MaxLength="500" Onchange="return checkNumeric('ctl00_C1_txtphone1');"
                         SkinID="txtSkin" Width="868px"></asp:TextBox></td>
               
             </tr>
             <tr>
                 <td align="left"  valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="Label37" runat="server" Width="71px">Remark</asp:Label><strong><span
                         style="color: #ff0000">*</span></strong></td>
                 <td align="left"  valign="top">
                     :</td>
                 <td align="left" colspan="7" valign="top" >
                <asp:TextBox ID="TxtRemark"  SkinID="txtSkin"   TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd()" onkeyup="return PreventCharacterToAdd();"   Width="868px" Height="60px" runat="server" ></asp:TextBox></td>
             </tr>
             <tr>
                 
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                    <asp:Label ID="lblDateCasesReceived" runat="server" SkinID="lblSkin">Date Cases received</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top" style="width: 200px">
                    <asp:TextBox ID="txtDateCasesReceived" runat="server" SkinID="txtSkin"  Width="126px" MaxLength="10" ReadOnly="True" ></asp:TextBox></td>
                 <td valign="top">
                     <asp:Label SkinID="lblSkin"   ID="Label12" runat="server" ForeColor="#404040">
            Visit Date</asp:Label><span class="txtRed">*</span></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td valign="top">
                   
                <asp:TextBox ID="TxtDate" SkinID="txtSkin"  runat="server" MaxLength="10" Width="65px" ></asp:TextBox>
                     <img id="date" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=TxtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />
                     [dd/MM/yyyy]</td>
                 <td  valign="top" style="width: 108px">
                     <asp:Label SkinID="lblSkin"   ID="Label10" runat="server" Width="86px">Fe Name</asp:Label></td>
                 <td valign="top">
                     :</td>
                 <td  valign="top">
                
                <asp:TextBox ID="txtFe" SkinID="txtSkin"  runat="server" MaxLength="50" Width="127px" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="Label14" runat="server" ForeColor="Black">
                Additional MTNL 1</asp:Label><strong><span style="color: #ff0000">*</span></strong></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top" style="width: 200px">
                <asp:TextBox ID="TxtAdditionalMtnl"  SkinID="txtSkin"   runat="server" MaxLength="20" Width="126px" ></asp:TextBox></td>
                 <td  valign="top">
                  <asp:Label ID="lblAdditionalMtnl2" runat="server" SkinID="lblSkin">Additional mtnl 2</asp:Label></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td valign="top">
                     <asp:TextBox ID="txtAdditionalMtnl2" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ></asp:TextBox></td>
                 <td  valign="top" style="width: 108px">
                     <asp:Label SkinID="lblSkin"   ID="Label16" runat="server">Additional Cell</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td valign="top">
                <asp:TextBox ID="TxtAdditionCell" SkinID="txtSkin"  runat="server" MaxLength="20" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                     
                     <asp:Label SkinID="lblSkin"   ID="Label18" runat="server" Width="54px">
                SubMet</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
                     <asp:TextBox ID="txtSubMet" runat="server" MaxLength="20" SkinID="txtSkin" Width="126px"></asp:TextBox></td>
                 <td  valign="top">
                     <asp:Label SkinID="lblSkin"   ID="Label20" runat="server">Occupation</asp:Label><strong><span
                         style="color: #ff0000">*</span></strong></td>
                 <td valign="top" style="width: 33px">
                     :</td>
                 <td  valign="top">
                     <asp:TextBox ID="txtOccupation" runat="server" MaxLength="50" SkinID="txtSkin" Width="152px"></asp:TextBox></td>
                 <td valign="top" style="width: 108px">
                     <asp:Label SkinID="lblSkin"   ID="Label23" runat="server">Doc Sighted</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top">
                     <asp:TextBox ID="txtDocSighted" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                   
                    <asp:Label ID="lblSalesFlyersRcd" runat="server" SkinID="lblSkin" Width="101px">Sales Flyers rcd</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
                    <asp:DropDownList ID="ddlSalesFlyersRcd"   Width="70px"  SkinID="ddlSkin"  runat="server" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:DropDownList></td>
                 <td  valign="top">
                     <asp:Label SkinID="lblSkin"   ID="Label25" runat="server">Contactability</asp:Label><strong><span
                         style="color: #ff0000">*</span></strong></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td  valign="top">
                
             <asp:DropDownList ID="ddlContactability"  SkinID="ddlSkin"  runat="server" AutoPostBack="false" Width="132px" OnDataBound="ddlContactability_DataBound" AppendDataBoundItems="True"  >
                        <asp:ListItem Text="None" Value="None"></asp:ListItem>
                        <asp:ListItem Text="SM" Value="SM"></asp:ListItem>
                        <asp:ListItem Text="NM" Value="NM"></asp:ListItem>
                <asp:ListItem Text="TNM" Value="TNM"></asp:ListItem>
            </asp:DropDownList></td>
                 <td  valign="top" style="width: 108px">
                     <asp:Label SkinID="lblSkin"   ID="Label27" runat="server">Welcome Visit</asp:Label></td>
                 <td style="width: 100px; height: 18px" valign="top">
                     :</td>
                 <td  valign="top">
               <asp:DropDownList ID="ddlWelcomeVisit"  Width="70px" SkinID="ddlSkin"  runat="server" >
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:DropDownList></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="Label29" runat="server">Tariff Plan</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top" style="width: 200px">
                     <asp:TextBox ID="txtTarPlan" runat="server" MaxLength="20" SkinID="txtSkin" Width="126px"></asp:TextBox></td>
                 <td  valign="top">
                    <asp:Label ID="lblFirstBillExplation" runat="server" SkinID="lblSkin" Width="101px">First Bill Explanation</asp:Label></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td valign="top">
                     <asp:TextBox ID="txtBillExp" runat="server" MaxLength="20" SkinID="txtSkin" Width="126px"></asp:TextBox></td>
                 <td  valign="top" style="width: 108px">
                    <asp:Label ID="lblVoucherNumber" runat="server" SkinID="lblSkin" Width="59px">Time Slots</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td valign="top">
                    <asp:TextBox ID="txtVoucherNumber" runat="server" SkinID="txtSkin"  Width="152px" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                    
                    <asp:Label ID="lblRiskRatingBilling" runat="server" SkinID="lblSkin" Width="101px">Risk Rating Billing</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top" style="width: 200px">
                <%--<asp:DropDownList ID="ddlBusinessNature" Width="132px" SkinID="ddlSkin" runat="server"  AutoPostBack="false" OnDataBound="ddlBusinessNature_DataBound" >
               <asp:ListItem Value="0">Select</asp:ListItem>
            <asp:ListItem Text="Trading" Value="Trading"></asp:ListItem>
            <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem> 
            <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem> 
            <asp:ListItem Text="Builder" Value="Builder"></asp:ListItem> 
            <asp:ListItem Text="Contractor" Value="Contractor"></asp:ListItem> 
            <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem> 
            <asp:ListItem Text="Consultancy" Value="Consultancy"></asp:ListItem> 
            <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem> 
            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>            
        </asp:DropDownList>--%>
                    <asp:TextBox ID="txtRiskRatingBilling" runat="server" SkinID="txtSkin"  Width="152px" ></asp:TextBox></td>
                 <td valign="top">
                    <asp:Label ID="lblRiskRatingAlt" runat="server" SkinID="lblSkin" Width="101px">Risk Rating Alt</asp:Label></td>
                 <td valign="top" style="width: 33px">
                     :</td>
                 <td valign="top">
                    <asp:TextBox ID="txtRiskRatingAlt" runat="server" SkinID="txtSkin"  Width="152px"  ></asp:TextBox></td>
                 <td  valign="top" style="width: 108px">
                    <asp:Label ID="lblCreditStatus" runat="server" SkinID="lblSkin">Credit Status Desc</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top">
                 <%--/////////add by santosh shelar change by read only option///////////////////--%>
                    <asp:TextBox ID="txtCreditStatus" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ReadOnly="false" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                    <asp:Label ID="Label35" runat="server" SkinID="lblSkin" Width="109px">Nature Of Bussiness</asp:Label><strong><span
                        style="color: #ff0000">*</span></strong></td>
                 <td  valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
        <asp:TextBox ID="txtNatureOfBusiness" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="100" ></asp:TextBox></td>
                 <td  valign="top">
                    <asp:Label ID="lblSimUsedBy" runat="server" SkinID="lblSkin">Sim Used By</asp:Label></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td  valign="top">
                    <asp:TextBox ID="txtSimUsedBy" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ></asp:TextBox></td>
                 <td  valign="top" style="width: 108px">
                    <asp:Label ID="lblEmail" runat="server" SkinID="lblSkin">Email</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top">
                    <asp:TextBox ID="txtEmail" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                     <asp:Label SkinID="lblSkin"   ID="Label33" runat="server">Rater Name</asp:Label></td>
                 <td valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
                     <asp:TextBox ID="txtRaterName" runat="server" MaxLength="100" SkinID="txtSkin" Width="152px"></asp:TextBox></td>
                 <td  valign="top">
                    <asp:Label ID="lblSubInfoAudit" runat="server" SkinID="lblSkin">Sub Info Audit</asp:Label></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td  valign="top">
                    <asp:TextBox ID="txtSubInfoAudit" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ></asp:TextBox></td>
                 <td  valign="top" style="width: 108px">
                     Designation</td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top">
                 <%--///////add by santosh shelar change readonlly fe/////////////////--%>
                     <asp:TextBox ID="txtDesignation" runat="server" MaxLength="50" SkinID="txtSkin" Width="152px" ReadOnly="false"></asp:TextBox></td>
             </tr>
             <tr>
                 <td  valign="top" style="width: 111px">
                    <asp:Label ID="lblAuditJobDesc" runat="server" SkinID="lblSkin">Audit Job Desc</asp:Label></td>
                 <td  valign="top">
                     :</td>
                 <td  valign="top" style="width: 200px">
                    <asp:TextBox ID="txtAuditJobDesc" runat="server" SkinID="txtSkin"  Width="152px" MaxLength="50" ></asp:TextBox></td>
                 <td  valign="top">
                    <asp:Label ID="lblRefCellNo" runat="server" SkinID="lblSkin" Width="65px">Ref cell No</asp:Label></td>
                 <td  valign="top" style="width: 33px">
                     :</td>
                 <td  valign="top">
                    <asp:TextBox ID="txtRefCellNo" runat="server" SkinID="txtSkin"  Width="152px"  ></asp:TextBox></td>
                 <td valign="top" style="width: 108px">
                    <asp:Label ID="lblCustClass" runat="server" SkinID="lblSkin">Cust Class</asp:Label></td>
                 <td valign="top">
                     :</td>
                 <td valign="top">
                    <asp:TextBox ID="txtCustClass" runat="server" SkinID="txtSkin"  Width="152px" ReadOnly="True" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                 <asp:Label ID="Label3" runat="server" SkinID="lblSkin">DEO Name</asp:Label></td>
                 <td valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
                     <asp:TextBox ID="txtDeoName" runat="server" MaxLength="50" SkinID="txtSkin" Width="152px"></asp:TextBox></td>
                 <td valign="top">
                     &nbsp;Applicant Accessibility</td>
                 <td valign="top" style="width: 33px">
                     :</td>
                 <td valign="top">
                 <asp:DropDownList ID="ddlApplicantAccessibility"  Width="102px"   SkinID="ddlSkin"  runat="server" >
                     <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                     <asp:ListItem Text="Door Lock" Value="Door Lock"></asp:ListItem>
                     <asp:ListItem Text="Out Of Station" Value="Out Of Station"></asp:ListItem>
                     <asp:ListItem Text="Entry Not Allowed" Value="Entry Not Allowed"></asp:ListItem>
                     <asp:ListItem Text="Office Closed" Value="Office Closed"></asp:ListItem>
                 </asp:DropDownList></td>
                 <td valign="top" style="width: 108px">
                     TB/FB done during Telecalling</td>
                 <td valign="top">
                     :</td>
                 <td valign="top">
                     <asp:TextBox ID="txtZonal" runat="server"  SkinID="txtSkin" Width="152px"></asp:TextBox></td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                     Preferred Mode of communication</td>
                 <td valign="top">
                     :</td>
                 <td valign="top" colspan="7">
                     <asp:TextBox ID="txtIPComments" runat="server" Height="60px" onkeypress="return PreventCharacterToAdd()"
                         onkeyup="return PreventCharacterToAdd();" SkinID="txtSkin" TextMode="MultiLine"
                         Width="868px"></asp:TextBox></td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                     Preferred language of communication</td>
                 <td valign="top">
                     :</td>
                 <td valign="top" style="width: 200px">
                     <asp:TextBox ID="txtPVTag" runat="server" MaxLength="50" SkinID="txtSkin" Width="152px"></asp:TextBox></td>
                 <td valign="top">
                    </td>
                 <td valign="top" style="width: 33px">
                     </td>
                 <td valign="top">
                    </td>
                 <td valign="top" style="width: 108px">
                    </td>
                 <td valign="top">
                     </td>
                 <td valign="top">
                    </td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                    </td>
                 <td valign="top">
                     </td>
                 <td valign="top" style="width: 200px">
                     </td>
                 <td valign="top">
                 </td>
                 <td valign="top" style="width: 33px">
                     </td>
                 <td valign="top">
                 </td>
                 <td valign="top" style="width: 108px">
                     </td>
                 <td valign="top">
                     &nbsp;</td>
                 <td valign="top">
                    </td>
             </tr>
             <tr>
                 <td valign="top" style="width: 111px">
                 </td>
                 <td valign="top">
                 </td>
                 <td valign="top" style="width: 200px">
                 </td>
                 <td  valign="top">
                     &nbsp;</td>
                 <td valign="top" style="width: 33px">
                 </td>
                 <td valign="top">
                <asp:Button ID="btnSubmit"  runat="server" SkinID="btnSaveSkin" Text="Submit"  OnClick="btnSubmit_Click"/>
                <%--<asp:Button ID="Button1"  runat="server" SkinID="btnSaveSkin" Text="Submit"  ValidationGroup="GrpSend"  OnClick="btnSubmit_Click" OnClientClick="RemarkCheck();"/>--%>
                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"   /></td>
                 <td valign="top" style="width: 108px">
                 </td>
                 <td valign="top">
                 </td>
                 <td valign="top">
                 </td>
             </tr>
             <tr>
                 <td colspan="9" valign="top" style="height: 136px">
                  <asp:HiddenField ID="HiddenFieldFe" runat="server" />
                  <asp:HiddenField ID="hidSelect" runat="server" />
                <asp:SqlDataSource ID="sdsOccupation"   runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT [OCUPATION_ID], [OCCUPATION] FROM [OCCUPATION_MASTER]"></asp:SqlDataSource>
                <asp:HiddenField ID="hidCaseID" runat="server" />
         <asp:SqlDataSource ID="sdsCaseStatus" runat="server" ProviderName="System.Data.OleDb" SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
            <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
           </SelectParameters>  
         </asp:SqlDataSource>
                 </td>
             </tr>
             <tr>
                 <td colspan="9" valign="top">
                 <%--<asp:CompareValidator ID="CompareValidator_CreditStatus" SetFocusOnError="true" runat="server" ControlToValidate="ddlCaseStatus"
                    Display="None"  ErrorMessage="Please Select Credit Status !!" Operator="GreaterThan"
                    ValidationGroup="GrpSend" ValueToCompare="0"></asp:CompareValidator>--%>
                <asp:ValidationSummary ID="vsummary" runat="server" DisplayMode="List" ShowMessageBox="True" 
                    ShowSummary="False" ValidationGroup="GrpSend" Height="57px" Width="138px" />
                <asp:CompareValidator ID="CompareValidator_Contactability" SetFocusOnError="true" runat="server" ControlToValidate="ddlContactability"
                    Display="None"  ErrorMessage="Please Select Contactability !!" Operator="GreaterThan"
                    ValidationGroup="GrpSend" ValueToCompare="0"></asp:CompareValidator>
               <asp:CompareValidator ID="CompareValidator_NatureOfBusiness" SetFocusOnError="true" runat="server" ControlToValidate="txtNatureOfBusiness"
                    Display="None" ErrorMessage="Please Enter Business Nature !!" Operator="GreaterThan"
                    ValidationGroup="GrpSend" ValueToCompare="0"></asp:CompareValidator>
                     <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                Display="None" ErrorMessage="Please Enter a Valid Email " SetFocusOnError="True"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GrpSend"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvvisitdate" runat="server" ControlToValidate="TxtDate"
                    Display="None" ErrorMessage="Please Enter Visit Date" SetFocusOnError="True" TabIndex="0"  ValidationGroup="GrpSend"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rfvvisitdate1" runat="server" ControlToValidate="TxtDate"
                    Display="None" ErrorMessage="Please Enter Valid Date Formate For Visit Date" SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="GrpSend"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="REVDateCasesReceived" runat="server" ControlToValidate="txtDateCasesReceived"
                    Display="None" ErrorMessage="Please Enter Valid Date Formate For Date Cases Received" SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="GrpSend"></asp:RegularExpressionValidator><asp:CompareValidator ID="cfvformtnl" runat="server" ControlToValidate="TxtAdditionalMtnl"
                    Display="None" ErrorMessage="Please Enter Only Numeric Value in  Mtnl TextBox"
                    Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforcell" runat="server" ControlToValidate="TxtAdditionCell"
                 Display="None" ErrorMessage="Please Enter Only Numeric Values in Cell TextBox"
                    Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforoffipincode" runat="server" ErrorMessage="Please Enter Numeric Values For PinCode" ControlToValidate="txtpincode"
                 Display="None" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforresipincode" runat="server" ErrorMessage="Pease Enter Numeric Values For PinCode" ControlToValidate="txtresipincode" 
                Display="None" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforoffiphone2" runat="server" ControlToValidate="txtphone2"
                 Display="None" ErrorMessage="Please Enter Only Numeric Values For Phone No"
                    Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator>
                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" SetFocusOnError="true" ControlToValidate="ddlCaseStatus"
                    Display="None" ErrorMessage="Please Select Credit Status  !! " Operator="GreaterThan"
                    ValidationGroup="GrpSend" ValueToCompare="0"></asp:CompareValidator>--%>
                  
                    <%--<asp:CompareValidator ID="CompareValidator_Occupation" SetFocusOnError="true" runat="server" ControlToValidate="ddloccupation"
                    Display="None" ErrorMessage="Please Select Occupation !!" Operator="GreaterThan" ValidationGroup="GrpSend"
                    ValueToCompare="0"></asp:CompareValidator>--%>
                    
                    <asp:RequiredFieldValidator ID="rfvforremark" runat="server" ControlToValidate="TxtRemark"
                    Display="None" ErrorMessage="Please Enter Remark !!" SetFocusOnError="True"  ValidationGroup="GrpSend"></asp:RequiredFieldValidator><asp:CompareValidator ID="cfvforoffiphone1" runat="server" ControlToValidate="txtphone1"
                    Display="None" ErrorMessage="Please Enter Only Numeric Value For Phone No"
                    Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforresiphone1" runat="server" ErrorMessage="Please Enter Numeric Values For Phone No." ControlToValidate="txtresiphone1"
                 Display="None" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator><asp:CompareValidator ID="cfvforresiphone2" runat="server" ErrorMessage="Pease Enter Numeric Values For Phone No." ControlToValidate="txtresiphone2" 
                Display="None" Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="GrpSend"></asp:CompareValidator></td>
             </tr>
         </table>
         <asp:CustomValidator ID="cvRemark" runat="server"  ValidationGroup="GrpSend" ControlToValidate="TxtRemark" Display="none" ClientValidationFunction="validation" ErrorMessage="Please Enter Sub Was available or Sub was not available in Remark" ></asp:CustomValidator>
         <asp:HiddenField ID="hdnTransStart" runat="server" />
         <asp:HiddenField ID="hidMode" runat="server" />
         </td>
     </tr>
      
 
        <tr>
        <td >

</td></tr>
    
</table>
</fieldset>

</asp:Content>
