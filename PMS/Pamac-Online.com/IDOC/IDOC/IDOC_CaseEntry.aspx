<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="IDOC_CaseEntry.aspx.cs" Inherits="IDOC_IDOC_CaseEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">

function WindowOpen1()
{
// Variable Declaration With value
 var strFirstName=document.getElementById("<%=txtFirstNm.ClientID %>").value;
 var strLastName=document.getElementById("<%=txtLastNm.ClientID %>").value;
 var strPanNo = document.getElementById("<%=txtPanNo.ClientID%>").value;
 
 //New Window Parameter Declaration
 var helpwinparam='width=800px,height=300px,toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,dependent,left=200,top=150';
 
 //Redirect to Dedup Design Page
 var strURL = "DedupITR.aspx?First_Name="+strFirstName+"&Last_Name="+strLastName+"&Pan_No="+strPanNo+"";

 // Pop up window
 var popup = window.open(strURL,'',helpwinparam);
}

function validation()
{  
    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");       
    var ErrorMessage="";
    var ReturnValue=true;
       
    var txtFirstNm = document.getElementById("<%=txtFirstNm.ClientID%>");
    var txtLastNm = document.getElementById("<%=txtLastNm.ClientID%>");

    if(txtLastNm.value=='')
    {
        ErrorMessage="Please Enter Last Name.";
        ReturnValue=false;
        txtLastNm.focus();
    }
    if(txtFirstNm.value=='')
    {
        ErrorMessage="Please Enter First Name.";
        ReturnValue=false;
        txtFirstNm.focus();
    }
    lblMessage.innerText = ErrorMessage;
    window.scrollTo(0,0);   
    return ReturnValue; 
}
//ended by sanket


function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 99)
     {
       getControlsId.value = getControlsId.value.substring( 0, 99 );            
       return false;
     }          
   }

  
     
function PreventCharacterToAdd1()
 { 
  getControlsId = document.getElementById("ctl00_C1_txtBankAddress");
  if(getControlsId.value.length > 255)
  {
    getControlsId.value = getControlsId.value.substring( 0, 254 ); 
   return false;
  } 
}
function PreventCharacterToRto()
{
getControlsId = document.getElementById("ctl00_C1_txtRTOOffice");
  if(getControlsId.value.length > 255)
  {
    getControlsId.value = getControlsId.value.substring( 0, 254 ); 
   return false;
  } 
}


function ClientValidate(source, arguments)
   {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
  
  </script> 

<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset ><legend class="FormHeading">IDOC Case Entry</legend>
<table border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
     <tr>
         <td colspan="11" style="height: 15px">
         <asp:Label ID="lblMessage" runat="server" CssClass="LabelError" Visible="false" SkinID="lblError"></asp:Label></td>
                                            
       </tr>
         <tr>
        <td>
           <asp:Label ID="lblReferenceProduct" runat="server" SkinID="lblSkin">Reference Product</asp:Label> </td>
        <td style="width: 35px">
        <asp:Label ID="lblRef" runat="server" SkinID="lblSkin">:</asp:Label></td>
        <td>
        <asp:DropDownList SkinID="ddlSkin" ID="ddlReferenceProduct" runat="server" OnDataBound="ddlReferenceProduct_DataBound">
        </asp:DropDownList></td>
             <td>
             </td>
        <td style="width: 225px">
        </td>
        <td style="width: 41px">
        </td>
        <td style="width: 18px">
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
            <td><asp:Label ID="lblREFNo" runat="server" SkinID="lblSkin">Bank RefNo </asp:Label></td>
            <td style="width: 35px"><asp:Label ID="lblRN" runat="server" SkinID="lblSkin">:</asp:Label></td>
            <td><asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox>
            </td>
           <td>
               <asp:Label ID="lblRecvDate" runat="server" SkinID="lblSkin">Recv Date :</asp:Label></td>
            <td style="width: 228px" colspan="3" >
             <asp:TextBox ID="txtRecDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtRecDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                [dd/MM/yyyy]
            </td>
              
              <td colspan="4" >
                  <asp:Label ID="lblTimeType" runat="server" SkinID="lblSkin" Width="62px">Recv Time :</asp:Label><asp:TextBox ID="txtRecTime" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
              <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
             </asp:DropDownList> [hh:mm] </td>
       </tr>
       <tr>
        <td><asp:Label ID="lblTitle" runat="server" SkinID="lblSkin">Title</asp:Label></td>
        <td style="width: 35px"><asp:Label ID="Label9" runat="server" SkinID="lblSkin">:</asp:Label></td>
        <td>
         <asp:DropDownList ID="ddlTitle" runat="server" SkinID="ddlSkin">
                <asp:ListItem Text="MR" Value="MR"></asp:ListItem>
                <asp:ListItem Text="MRS" Value="MRS"></asp:ListItem>
                <asp:ListItem Text="MISS" Value="MISS"></asp:ListItem>
                <asp:ListItem Text="M/s" Value="M/s"></asp:ListItem>
             </asp:DropDownList>
            
        </td>
           <td >
               <asp:Label ID="lblFirstNm" runat="server" SkinID="lblSkin" Width="61px">First Name :</asp:Label></td>
        <td style="width: 225px" >
            <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="50" SkinID="txtSkin" Columns="30" Width="171px"></asp:TextBox></td>
        <td ><asp:Label ID="lblMiddleNm" runat="server" SkinID="lblSkin" Width="70px">Middle Name :</asp:Label></td>
<%--        <td style="width: 18px"><asp:Label ID="Label13" runat="server" SkinID="lblSkin">:</asp:Label></td>  --%>
        <td>
            <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="50" SkinID="txtSkin" Columns="30" Width="156px"></asp:TextBox></td>
        
      <td>
        <asp:Label ID="lblLastNm" runat="server" SkinID="lblSkin" Width="64px">Last Name :</asp:Label></td>
<%--        <td><asp:Label ID="Label2" runat="server" SkinID="lblSkin">:</asp:Label></td>--%>
    <td>
         <asp:TextBox ID="txtLastNm" runat="server" MaxLength="50" SkinID="txtSkin" ></asp:TextBox></td>
    </tr>
    <tr>
      
        <td>
        <asp:Label ID="lblDOB" runat="server" SkinID="lblSkin">DOB :</asp:Label></td>
        <td style="width: 35px"><asp:Label ID="Label4" runat="server" SkinID="lblSkin">:</asp:Label></td>
       <td colspan="9">
         <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, <%=txtDOB.ClientID %>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
        <asp:Label id="lblDOBError" runat="server" CssClass="LabelError" SkinID="lblError" Visible="False"></asp:Label>
        </td>
</tr>
<tr>
    <td style="height: 42px" ><asp:Label ID="lblVerDoc" runat="server" SkinID="lblSkin">Verification Doucment</asp:Label></td>
    <td style="height: 42px; width: 35px;" ><asp:Label ID="Label19" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="9" style="height: 42px">
        <asp:DropDownList ID="ddlverificationdoc" runat="server" SkinID="ddlSkin" ValidationGroup="grpValidate">
              
            </asp:DropDownList>
</td>
 </tr>
    <tr>
        <td style="height: 42px">
            <asp:Label ID="lblITRType" runat="server" Text="ITR Type" Height="16px" Width="79px"></asp:Label>
            </td>
        <td style="width: 35px; height: 42px">
            :</td>
        <td colspan="9" style="height: 42px">
            <asp:DropDownList ID="ddlItrType" runat="server" SkinID="ddlSkin">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Manual ICL</asp:ListItem>
                <asp:ListItem>Manual OCL</asp:ListItem>
                <asp:ListItem>Normal E-filing</asp:ListItem>
                <asp:ListItem>OCL E-filing</asp:ListItem>
            </asp:DropDownList>
        <asp:Label ID="lblitrtypeerror" runat="server" ForeColor="Red" Text="*ITR Type is mandatory" Visible="False"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 24px" >
        <asp:Label ID="lblVerificationCharges" runat="server" SkinID="lblSkin" Width="146px">Verification Charges</asp:Label></td>
        <td style="height: 24px; width: 35px;" >
        <asp:Label ID="Label1" runat="server" SkinID="lblSkin">:</asp:Label></td>
        <td style="height: 24px" >
            <asp:DropDownList ID="ddlVerificationCharges" runat="server" SkinID="ddlSkin">
     <asp:ListItem Text="Within City Limit" Value="Normal"></asp:ListItem>
     <asp:ListItem Text="OutSide City Limit" Value="OCL"></asp:ListItem>
     <asp:ListItem Text="Other" Value="Minimum"></asp:ListItem>
     </asp:DropDownList></td>
        <td colspan="2" style="height: 24px">
            <asp:Label ID="Label7" runat="server" SkinID="lblSkin" Width="61px">Pan No :</asp:Label>
            <asp:TextBox ID="txtPanNo" runat="server" Columns="30" MaxLength="10" SkinID="txtSkin" Width="171px" ValidationGroup="grpValidate" OnBlur="WindowOpen1()"></asp:TextBox>
        <asp:Label ID="lblPANError" runat="server" CssClass="LabelError" SkinID="lblError" Visible="False"></asp:Label></td>
        <td colspan="6" style="height: 24px">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPanNo"
                ErrorMessage="Please Enter Valid Pan No." ValidationExpression="[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}"
                ValidationGroup="grpValidate"></asp:RegularExpressionValidator>&nbsp;
            </td>
    </tr>
 <tr>
        <td colspan="11" style="height: 16px" >
            </td>
    </tr>
    <tr>
        <td colspan="11" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">
        <asp:Label ID="lblResiDetails" runat="server" SkinID="lblSkin">Residence Detail</asp:Label></td>
    </tr>
    <tr>
    <td  ><asp:Label ID="lblName" runat="server" SkinID="lblSkin">Name</asp:Label></td>
    <td style="width: 35px" ><asp:Label ID="Label22" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="9"  >
        <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" MaxLength="200" Width="40%" ReadOnly="true"></asp:TextBox></td></tr>
   <tr>
   <td  ><asp:Label ID="lblAdd1" runat="server" SkinID="lblSkin">Add1</asp:Label></td>
   <td style="width: 35px" ><asp:Label ID="Label24" runat="server" SkinID="lblSkin"> :</asp:Label></td>
    <td colspan="9">
    <asp:TextBox ID="txtResAdd1"  TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd1');" SkinID="txtSkin" Width="40%" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
      <td ><asp:Label ID="lblAdd2" runat="server" SkinID="lblSkin">Add2</asp:Label></td>
      <td style="width: 35px" ><asp:Label ID="Label26" runat="server" SkinID="lblSkin">:</asp:Label></td>
      <td colspan="9">
       <asp:TextBox ID="txtResAdd2" runat="server" TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd2');" SkinID="txtSkin" Width="40%"></asp:TextBox></td>
    </tr>
    <tr>
      <td style="height: 40px" ><asp:Label ID="lblAdd3" runat="server" SkinID="lblSkin">Add3</asp:Label></td>
      <td style="width: 35px; height: 40px;" ><asp:Label ID="Label28" runat="server" SkinID="lblSkin">:</asp:Label></td>
      <td colspan="9" style="height: 40px">
        <asp:TextBox ID="txtResAdd3" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd3');" SkinID="txtSkin" Width="40%"></asp:TextBox></td>
    </tr>
    <tr>
      <td ><asp:Label ID="lblCity" runat="server" SkinID="lblSkin">City</asp:Label></td>
      <td style="width: 35px" ><asp:Label ID="Label30" runat="server" SkinID="lblSkin">:</asp:Label></td>
      <td colspan="2">
       <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
      <td style="width: 225px" ><asp:Label ID="lblPin" runat="server" SkinID="lblSkin">Pin</asp:Label></td>
        <td colspan="6">
            <asp:Label ID="Label32" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
      <asp:TextBox ID="txtResPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
   </tr>
   <tr>
    <td style="height: 26px" ><asp:Label ID="lblResLandMark" runat="server" SkinID="lblSkin">Res Land Mark</asp:Label></td>
     <td style="width: 35px; height: 26px;" ><asp:Label ID="Label34" runat="server" SkinID="lblSkin">:</asp:Label></td>
       <td colspan="2" style="height: 26px">
    <asp:TextBox ID="txtLandMark" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
     <td style="width: 225px; height: 26px;" ><asp:Label ID="lblResPhoneNo" runat="server" SkinID="lblSkin" Width="54px">Res Phone</asp:Label></td>
      <td colspan="6" style="height: 26px"><asp:Label ID="Label36" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
          <asp:TextBox ID="txtResPhone" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
   </tr>
   <tr>
      <td ><asp:Label ID="lblITO" runat="server" SkinID="lblSkin">ITO</asp:Label></td>
      <td style="width: 35px" ><asp:Label ID="Label38" runat="server" SkinID="lblSkin">:</asp:Label></td>
       <td colspan="2">
      <asp:TextBox ID="txtITO" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
      <td style="width: 225px" ><asp:Label ID="lblWard" runat="server" SkinID="lblSkin">Ward</asp:Label></td>
       <td colspan="6">
           <asp:Label ID="Label40" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
      <asp:TextBox ID="txtWard" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
   </tr>
   <tr>
      <td style="height: 22px" ><asp:Label ID="lblTotalAmt" runat="server" SkinID="lblSkin" Width="56px">Total  Amt</asp:Label>
          </td>
      <td style="height: 22px; width: 35px;" ><asp:Label ID="Label42" runat="server" SkinID="lblSkin">:</asp:Label></td>
       <td colspan="2" style="height: 22px">
      <asp:TextBox ID="txtTotalAmt" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox>
          <asp:Label ID="lblTotalAmtError" runat="server" CssClass="LabelError" SkinID="lblError"
              Visible="False"></asp:Label></td>
      <td style="width: 225px; height: 22px;" ><asp:Label ID="lblIncomeTaxAmt" runat="server" SkinID="lblSkin" Width="86px">Income Tax Amt</asp:Label></td>
       <td colspan="6" style="height: 22px" >
           <asp:Label ID="Label44" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
      <asp:TextBox ID="txtIncomeTaxAmt" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
   </tr>
    <tr>
        <td style="height: 42px" >
            <asp:Label ID="Label6" runat="server" SkinID="lblSkin">Asst. Year</asp:Label>
            </td>
        <td style="width: 35px; height: 42px"><asp:Label ID="Label10" runat="server" SkinID="lblSkin">:</asp:Label>
        </td>
        <td colspan="2" style="height: 42px" >
            <asp:TextBox ID="txtAsstYear" runat="server" SkinID="txtSkin" MaxLength="7"></asp:TextBox>
            <asp:Label ID="lblAsstYearError" runat="server" CssClass="LabelError" SkinID="lblError"
                Visible="False"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAsstYear"
                ErrorMessage="Please Enter Valid Year" ValidationExpression="[0-9]{4}[-][0-9]{2}"
                ValidationGroup="grpValidate" Width="123px"></asp:RegularExpressionValidator></td>
        <td style="width: 225px; height: 42px;" >
            <asp:Label ID="Label8" runat="server" SkinID="lblSkin" Width="54px">Receipt No</asp:Label></td>
        <td colspan="6" style="height: 42px" >
            <asp:Label ID="Label12" runat="server" SkinID="lblSkin">:</asp:Label>
            <asp:TextBox ID="txtReceiptNo" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
   <tr>
     <td colspan="11" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">
     <asp:Label ID="lblOfficeDetail" runat="server" SkinID="lblSkin">Office Detail</asp:Label></td>
  </tr>
    <tr>
        <td >
            <asp:Label ID="Label5" runat="server" SkinID="lblSkin">Company Name</asp:Label></td>
        <td style="width: 35px"><asp:Label ID="Label11" runat="server" SkinID="lblSkin">:</asp:Label>
        </td>
        <td colspan="9">
            <asp:TextBox ID="txtCompName" runat="server" MaxLength="100" SkinID="txtSkin" Width="40%"></asp:TextBox>
            <asp:Label ID="lblCompanyNameError" runat="server" CssClass="LabelError" SkinID="lblError"
                Visible="False"></asp:Label></td>
    </tr>
  <tr>
    <td ><asp:Label ID="lblOffAdd1" runat="server" SkinID="lblSkin">Add1</asp:Label></td>
    <td style="width: 35px" ><asp:Label ID="Label47" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="9">
    <asp:TextBox ID="txtOffAdd1" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1');" SkinID="txtSkin" Width="40%"></asp:TextBox>&nbsp;
        <asp:Label ID="lblCompanyAddr1" runat="server" CssClass="LabelError" SkinID="lblError"
            Visible="False"></asp:Label></td>
   </tr>
    <tr>
    <td ><asp:Label ID="lblOffAdd2" runat="server" SkinID="lblSkin">Add2</asp:Label></td>
    <td style="width: 35px" ><asp:Label ID="Label49" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="9">
    <asp:TextBox ID="txtOffAdd2" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2');" SkinID="txtSkin" Width="40%"></asp:TextBox>
        <asp:Label ID="lblCompanyAddr2" runat="server" CssClass="LabelError" SkinID="lblError"
            Visible="False"></asp:Label></td>
    </tr>
    <tr>
    <td ><asp:Label ID="lblOffAdd3" runat="server" SkinID="lblSkin">Add3</asp:Label></td>
    <td style="width: 35px" ><asp:Label ID="Label51" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="9">
     <asp:TextBox ID="txtOffAdd3" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3');" SkinID="txtSkin" Width="40%"></asp:TextBox>
        <asp:Label ID="lblCompanyAddr3" runat="server" CssClass="LabelError" SkinID="lblError"
            Visible="False"></asp:Label></td>
   </tr>
   <tr>
    <td ><asp:Label ID="lblOffCity" runat="server" SkinID="lblSkin">City</asp:Label></td>
    <td style="width: 35px" ><asp:Label ID="Label53" runat="server" SkinID="lblSkin">:</asp:Label></td>
       <td colspan="2">
        <asp:TextBox ID="txtOffCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
    <td style="width: 225px" ><asp:Label ID="Label54" runat="server" SkinID="lblSkin">Pin</asp:Label></td>
       <td colspan="6">
           <asp:Label ID="Label55" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
        <asp:TextBox ID="txtOffPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
     <tr>
    <td ><asp:Label ID="lblOffPhone" runat="server" SkinID="lblSkin">Off. Phone</asp:Label></td>
         <td style="width: 35px" ><asp:Label ID="Label57" runat="server" SkinID="lblSkin"> :</asp:Label></td>
         <td colspan="2">
        <asp:TextBox ID="txtOffPhone" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
    <td style="width: 225px" >
        <asp:Label ID="lblOffExtn" runat="server" SkinID="lblSkin" Width="49px">Off. Extn</asp:Label></td>
         <td colspan="6">
             <asp:Label ID="Label59" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
        <asp:TextBox ID="txtOffExtn" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
</tr>
<tr>
<td style="height: 26px" >
    <asp:Label ID="lblDesignation" runat="server" SkinID="lblSkin">Designation</asp:Label></td>
   <td style="width: 35px; height: 26px;" ><asp:Label ID="Label61" runat="server" SkinID="lblSkin">:</asp:Label></td>
    <td colspan="2" style="height: 26px">
    <asp:TextBox ID="txtDesgn" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
<td style="width: 225px; height: 26px;" ><asp:Label ID="lblDepartment" runat="server" SkinID="lblSkin">Department</asp:Label></td>
    <td colspan="6" style="height: 26px">
        <asp:Label ID="Label63" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
    <asp:TextBox ID="txtDept" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
</tr>
    <tr>
        <td>
            <asp:Label ID="lblOccupation" runat="server" SkinID="lblSkin">Occupation</asp:Label></td>
        <td style="width: 35px">
            :</td>
        <td colspan="2">
    <asp:TextBox ID="txtOccupation" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td style="width: 225px">
            <asp:Label ID="Label15" runat="server" SkinID="lblSkin">Pay Slip For The Month</asp:Label></td>
        <td colspan="6">
            <asp:Label ID="Label16" runat="server" Height="8px" SkinID="lblSkin" Width="1px">:</asp:Label>&nbsp;
            <asp:TextBox ID="txtpayslipmonth" runat="server" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
 <tr>
<td >
    </td>
    <td style="width: 35px" ></td>
<td colspan="9">
    </td>
</tr>
 <tr>
   <td colspan="11" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">
    <asp:Label ID="lblBankStatement" runat="server" SkinID="lblSkin">BANK Statement</asp:Label></td>
</tr>
<tr>
<td ><asp:Label ID="lblBankName" runat="server" SkinID="lblSkin">Bank Name</asp:Label></td>
<td style="width: 35px" ><asp:Label ID="Label68" runat="server" SkinID="lblSkin">:</asp:Label></td>
<td colspan="9" rowspan="">
<asp:TextBox ID="txtBankName" runat="server" MaxLength="100" SkinID="txtSkin" Width="40%"></asp:TextBox>
<asp:Label ID="lblBankNameError" runat="server" CssClass="LabelError" SkinID="lblError" Visible="False"></asp:Label></td>
</tr>
<tr>
<td ><asp:Label ID="lblBankAddress" runat="server" SkinID="lblSkin">Bank Address</asp:Label></td>
<td style="width: 35px" > :</td>
<td colspan="9">
<asp:TextBox ID="txtBankAddress" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd1()" onkeyup="return PreventCharacterToAdd1();" SkinID="txtSkin" Width="40%"></asp:TextBox></td>
</tr>
<tr>
<td style="height: 26px" >
    <asp:Label ID="lblBankCity" runat="server" SkinID="lblSkin">Bank City</asp:Label></td>
   <td style="height: 26px; width: 35px;" ><asp:Label ID="Label71" runat="server" SkinID="lblSkin">:</asp:Label></td>
<td colspan="2" style="height: 26px">
    <asp:TextBox ID="txtBankCity" runat="server" MaxLength="100" SkinID="txtSkin" Width="167px"></asp:TextBox></td>
<td style="width: 225px; height: 26px;" >
    <asp:Label ID="lblBankPin" runat="server" SkinID="lblSkin" Width="51px">Bank Pin</asp:Label></td>
    <td colspan="6" style="height: 26px">
        <asp:Label ID="Label73" runat="server" SkinID="lblSkin">:</asp:Label>&nbsp;
    <asp:TextBox ID="txtBankPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
</tr>
    <tr>
        <td style="height: 18px">
            <asp:Label ID="Label14" runat="server" SkinID="lblSkin">Bank Account No</asp:Label></td>
        <td style="height: 18px; width: 35px;">
        </td>
        <td colspan="2" style="height: 18px">
            <asp:TextBox ID="txtAccountNo" runat="server" Width="169px" SkinID="txtSkin"></asp:TextBox>
            <asp:Label ID="lblAccountError" runat="server" CssClass="LabelError" SkinID="lblError" Visible="False"></asp:Label></td>
        <td style="width: 225px; height: 18px">
        </td>
        <td colspan="6" style="height: 18px">
        </td>
    </tr>
<tr>
<td colspan="11" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="Label3" runat="server" Text="RC Details as per RC Book"></asp:Label>
</td>
</tr>
<tr>
<td ><asp:Label SkinID="lblSkin"   ID="lblRegistrationNumberOfVehicle" runat="server" Width="154px">Registration Number Of Vehicle</asp:Label>
</td>
<td style="width: 35px" >:</td>
<td colspan="9">
<asp:TextBox SkinID="txtSkin"   ID="txtRegistrationNumberOfVehicle" MaxLength="50" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td ><asp:Label SkinID="lblSkin"   ID="lblRTOOffice" runat="server">RTO Office</asp:Label>
</td>
<td style="width: 35px" >:</td>
<td colspan="9">
<asp:TextBox SkinID="txtSkin"   ID="txtRTOOffice" runat="server" onkeypress="return PreventCharacterToRto();" onkeyup="return PreventCharacterToRto();" TextMode="MultiLine" Width="335px"></asp:TextBox>
</td>
</tr>
 <tr>
    
    <td colspan="11"></td>
 </tr>
 
  <tr>
   <td colspan="11" align="center">
    <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="grpValidate" />
    <asp:Button ID="btnCancel" SkinID="btnCancelSkin" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
  </tr>
   <tr>
    <td colspan="11"></td>
   </tr>
   <tr>
                    
    <td colspan="11" style="height: 97px">
        <asp:SqlDataSource ID="sdsIDOC" runat="server" ProviderName="System.Data.OleDb"
     SelectCommand="SELECT REF_NO, CASE_REC_DATETIME, TITLE,(ISNULL(FIRST_NAME,'')+' '+ISNULL(MIDDLE_NAME,'')+' '+ISNULL(LAST_NAME,'')) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT FROM CPV_IDOC_CASE_DETAILS"
     >
       
    </asp:SqlDataSource>
        <asp:HiddenField ID="hdnID" runat="server" />
       <%-- <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
            Display="None" ErrorMessage="Please enter valid date format for Date of birth."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
            --%>
            <%--<asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
            Display="None" ErrorMessage="Please enter Date of birth." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
            --%>
            <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
            Display="None" ErrorMessage="Please enter valid date format for Received date."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
            Display="None" ErrorMessage="Please enter valid time format for Received date."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                 
            <%--  Added by abhijeet for ITR TYPE   --%>
           
              <%--     <asp:RequiredFieldValidator ID="rfvverification" runat="server"
             ErrorMessage="Please Select Verification Type." ControlToValidate="ddlverificationdoc"
            InitialValue="0" Display="None" ValidationGroup="grpValidate"  >
        </asp:RequiredFieldValidator>
        --%>
        
        
         <asp:CustomValidator ID="valVeriType" runat="server" ControlToValidate="ddlverificationdoc"
                                                    Display="None" ErrorMessage="Please select Verification Type" SetFocusOnError="True" ClientValidationFunction="ClientValidate" ValidationGroup="grpValidate"></asp:CustomValidator>&nbsp;
              
        
        
        
                 <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="grpValidate" />
        &nbsp;
              
              
              
           <%--   ended by abhijeet for ITR TYPE   --%>
    </td>
                   
 </tr>
 <tr>
        <td colspan="11" >
        </td>
    </tr>
    </table>
</fieldset>
</td></tr></table>
</asp:Content>
   