<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="CC_BusinessVerificationTelephonic.aspx.cs" Inherits="CPV_CC_BusinessVerificationTelephonic" %>
<asp:Content ID="Contant1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {
          //alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       
       function ValidateAttempts(source, arguments)
       {
           if((document.aspnetForm.ctl00$C1$txtTime1stCall.value.length == 0) && (document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length == 0) && (document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length ==0) && (document.aspnetForm.ctl00$C1$txtTime4thCall.value.length ==0) && (document.aspnetForm.ctl00$C1$txtTime5thCall.value.length ==0))
           {
                arguments.IsValid = false;
           }
           else
           {
                arguments.IsValid = true;
           }
       }
       function ValidateTime1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length >0)
          {    
            //alert("time");         
            if(document.aspnetForm.ctl00$C1$txtTelNo1stCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo1stCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel1(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo1stCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks1stCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks1stCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark1(source, arguments)
       {           
           if(document.aspnetForm.ctl00$C1$ddlRemarks1stCall.value != 'Select')
           {              
                if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length ==0)
                {
                
                    document.aspnetForm.ctl00$C1$txtTime1stCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //2nd Telecalling
       function ValidateTime2(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo2ndCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo2ndCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel2(source, arguments)
       {
           //alert(document.aspnetForm.ctl00$C1$txtTel2.value);    
           if(document.aspnetForm.ctl00$C1$txtTelNo2ndCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark2(source, arguments)
       {           
           if(document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime2ndCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //3rd Telecalling
       function ValidateTime3(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo3rdCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo3rdCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel3(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo3rdCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark3(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime3rdCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //4th Telecalling
       function ValidateTime4(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime4thCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo4thCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo4thCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel4(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo4thCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks4thCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks4thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark4(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks4thCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime4thCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime4thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //5th Telecalling
       function ValidateTime5(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime5thCall.value.length >0) 
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo5thCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo5thCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel5(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo5thCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks5thCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks5thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark5(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks5thCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime5thCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime5thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
// -->


</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">BUSINESS TELE VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
<!--Start Heading-->
<asp:Panel ID="pnlBusVerTelHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ID="lblBusinessVerifiReport" runat="server" Text="BUSINESS TELE VERIFICATION REPORT"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>
<!--END Heading-->
<!--- Start of Personal Detail-->
<asp:Table ID="tblBusinessTelVeri" runat="server"  Width="100%">
<asp:TableRow ID="tblrowPlace" runat="server" >
<asp:TableCell ID="tblCellPlace" runat="server" >
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder9" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder10" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder11" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder12" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder13" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder14" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder15" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder16" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder17" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder18" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder19" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder20" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder21" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder22" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder23" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder24" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder25" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder26" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder27" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder28" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder29" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder30" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder31" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder32" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder33" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder34" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder35" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder36" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder37" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder38" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder39" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder40" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder41" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder42" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder43" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder44" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder45" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder46" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder47" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder48" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder49" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder50" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder51" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder52" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder53" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder54" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder55" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder56" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder57" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder58" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder59" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder60" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder61" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder62" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder63" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder64" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder65" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder66" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder67" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder68" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder69" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder70" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder71" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder72" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder73" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder74" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder75" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder76" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder77" runat="server"  EnableViewState="false"></asp:PlaceHolder>
        </asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="tblrow" runat="server" >
<asp:TableCell ID="tblCell" runat="server" >

<asp:Panel ID ="pnlAppName" runat="server" Width="100%">
<table id="tblAppName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAppName" runat="server" Text="Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtAppName" runat="server" Width="60%" ReadOnly="True" MaxLength="150"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRefNo" runat="server" Width="100%"  Visible="false">
<table id="tblRefNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtRefNo" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlInitiationDate" runat="server" Width="100%" Visible="false">
<table id="tblInitiationDate" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="true"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAgencyCode" runat="server" Width="100%" Visible="false">
<table id="tblAgencyCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server" Text="Agency Code" >
</asp:Label></td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtAgencyCode" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--- End of Personal Detail-->
<!--- Start of Office Head-->
<asp:Panel ID="pnlOffice" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%" align="center">
<asp:Label SkinID="lblSkin" ID="lblOffice" runat="server" ForeColor="blue" Text="OFFICE"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--- End of Office Head-->
<!--- Start of Office-->

<asp:Panel ID ="pnlContactedNo" runat="server" Width="100%" Visible="false">
<table id="tblContactedNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactedNo" runat="server" Text="Contacted No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"    ID="txtContactedNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlExtnNumber" runat="server" Width="100%" Visible="false">
<table id="tblExtnNumber"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblExtnNumber" runat="server" Text="Extn Number" ></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"    ID="txtExtnNumber" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAddressOffice" runat="server" Width="100%" Visible="false">
<table id="tblAddressOffice"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAddressOffice" runat="server" Text="Address(Office)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtAddressOffice" runat="server" Width="80%" MaxLength="300"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--- End of Office-->
<%--<Santosh Shelar : Start>--%>
<asp:Panel ID="pnlChangeAdd" runat="server"  Width="100%" Visible="false">
<table cellpadding="0" cellspacing="0" border="0" id="tblChangeAdd" style="width:100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblChangeAdd" runat="server"  Text="Address confirmed during calling"></asp:Label>
</td><td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtChangeAdd" Width="80%" TextMode="MultiLine" runat="server" MaxLength="500"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--<Santosh Shelar : End>--%>
<!--- Start of Applicant Has been Contacted Head-->
<asp:Panel ID="pnlAppBeenContacted" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ID="lblAppBeenContacted" ForeColor="blue" runat="server" Text="APPLICANT HAS BEEN CONTACTED"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--- End of Applicant Has been Contacted Head-->
<!--- Start of Applicant Has been Contacted-->

<asp:Panel ID ="pnlDOB" runat="server" Width="100%" Visible="false">
<table id="tblDOB"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDOB" runat="server" Text="Date Of Birth"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDOB" runat="server" MaxLength="50"></asp:TextBox>
<img id="ImgDOB"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />

</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlQualification" runat="server" Width="100%" Visible="false">
<table id="tblQualification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtQualification" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlDesignation" runat="server" Width="100%" Visible="false">
<table id="tblDesignation"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:TextBox SkinID="txtSkin"    ID="txtDesignation" runat="server" MaxLength="50"></asp:TextBox>

</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlTimeCurrEmpl" runat="server" Width="100%" Visible="false">
<table id="tblTimeCurrEmpl"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTimeCurrEmpl" runat="server" Text="Time at curr empl"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTimeCurrEmplYrs" runat="server"  MaxLength="2"></asp:TextBox>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrEmplYrs" runat="server" Text="Yrs"></asp:Label>
</td>            
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTimeCurrEmplMths" runat="server"  MaxLength="2"></asp:TextBox>
</td>             
<td>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrEmplMths" runat="server" Text="Mths"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlIncomeDocsSub" runat="server" Width="100%" Visible="false">
<table id="tblIncomeDocsSub" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblIncomeDocsSub" runat="server" Text="Income Docs submitted with application"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIncomeDocsSub" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlResiCumOffice" runat="server" Width="100%" Visible="false">
<table id="tblResiCumOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResiCumOffice" runat="server" Text="Resi Cum Office"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlResiCumOffice" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlTimeCurrResi" runat="server" Width="100%" Visible="false">
<table id="tblTimeCurrResi"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTimeCurrResi" runat="server" Text="Time at curr resi(Yrs/mths)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTimeCurrResiYears" runat="server"></asp:TextBox>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrResiYears" runat="server" Text="Yrs"></asp:Label>
</td>            
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTimeCurrResiMonth" runat="server"  MaxLength="2"></asp:TextBox>
</td>             
<td>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrResiMonth" runat="server" Text="Mths"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlResiPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblResiPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResiPhoneNo" runat="server" Text="Resi Phone No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtResiPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlResidenceIs" runat="server" Width="100%" Visible="false">
<table id="tblResidenceIs" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResidenceIs" runat="server" Text="Residence is"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlResidenceIs" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
<asp:ListItem Text="Own" Value="Own"></asp:ListItem>
<asp:ListItem Text="Co.Provided" Value="Co.Provided"></asp:ListItem>
<asp:ListItem Text="Paying guest" Value="Paying guest"></asp:ListItem>
<asp:ListItem Text="Bachelor acco" Value="Bachelor acco"></asp:ListItem>
<asp:ListItem Text="Family/Ancestral" Value="Family/Ancestral"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlMailingAddress" runat="server" Width="100%" Visible="false">
<table id="tblMailingAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblMailingAddress" runat="server" Text="Mailing address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlMailingAddress" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Residence" Value="Residence"></asp:ListItem>
<asp:ListItem Text="Office" Value="Office"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<!--- End of Applicant Has been Contacted-->
<!--- Start of If Someone other than the Applicant is Contacted Head-->
<asp:Panel ID="pnlIfSomeOneOtherContacted" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ID="lblIfSomeOneOtherContacted" ForeColor="blue" runat="server" Text="IF SOMEONE OTHER THAN THEN APPLICANT IS CONTACTED"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--- End of If Someone other than the Applicant is Contacted Head-->
<!--- Start of If Someone other than the Applicant is Contacted-->

<asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblNameOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameOfPersonContacted" runat="server" Text="Name Of Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<%--<asp:DropDownList ID="ddlPersonContacted" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
    <asp:ListItem Text="Applicant" Value="Applicant"></asp:ListItem>
    <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
    <asp:ListItem Text="Family Member" Value="Family Member"></asp:ListItem>
    <asp:ListItem Text="Friend" Value="Friend"></asp:ListItem>
    <asp:ListItem Text="Neighbour" Value="Neighbour"></asp:ListItem>
    <asp:ListItem Text="Security" Value="Security"></asp:ListItem>
    <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
</asp:DropDownList>--%>
<asp:TextBox SkinID="txtSkin"    ID="txtPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOtherContactedDesignation" runat="server" Width="100%" Visible="false">
<table id="tblOtherContactedDesignation"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblOtherContactedDesignation" runat="server" Text="Designation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtOtherContactedDesignation" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBusinessNature" runat="server" Width="100%" Visible="false">
<table id="tblBusinessNature" border="0" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblBusinessNature" runat="server" Text="Nature of business"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlBusinessNature" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Trading" Value="Trading"></asp:ListItem>
        <asp:ListItem Text="Building" Value="Building"></asp:ListItem>
        <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem> 
        <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem> 
        <asp:ListItem Text="Contractor" Value="Contractor"></asp:ListItem> 
        <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem> 
        <asp:ListItem Text="Consultancy" Value="Consultancy"></asp:ListItem> 
        <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem> 
        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>            
</asp:DropDownList>
</td>
</tr>
<%--//////////add by santosh shelar 27/08/08////////////////////////--%>
         <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="TextBox1" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAppDesignation" runat="server" Width="100%" Visible="false">
<table id="tblAppDesignation"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAppDesignation" runat="server" Text="Applicant's designation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtAppDesignation" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTimeatCurrEmplApp" runat="server" Width="100%" Visible="false">
<table id="tblTimeatCurrEmplApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTimeatCurrEmplApp" runat="server" Text="Time at curr empl of applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTimeatCurrEmplApp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAuthoSign" runat="server"  Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblAuthoSign" style="width:100%" runat="server" >             
    <tr>
    <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAuthoSign" runat="server"  Text="Authorised Signtory" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAuthoSign" runat="server" ></asp:TextBox></td>
            
        </tr>
    </table>
    </asp:Panel> 

<asp:Panel ID="pnlAppAvailable" runat="server" Width="100%" Visible="false">
<table id="tblAppAvailable" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAppAvailable" runat="server" Text="Applicant is usually available at"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtAppAvailable" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAgeApproxApp" runat="server" Width="100%" Visible="false">
<table id="tblAgeApproxApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAgeApproxApp" runat="server" Text="Age/ Approx age of applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtAgeApproxApp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTeleComments" runat="server" Width="100%" Visible="false">
<table id="tblTeleComments"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTeleComments" runat="server" Text="Tele comments"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTeleComments" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNewDetailObt" runat="server" Width="100%" Visible="false">
<table id="tblNewDetailObt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNewDetailObt" runat="server" Text="New Details Obtained"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtNewDetailObt" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--- End of If Someone other than the Applicant is Contacted-->

<!--Start of Rating Head-->

<asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%" align="center">
<asp:Label SkinID="lblSkin" ID="lblRating" runat="server" ForeColor="blue" Text="RATING"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End of Rating Head-->
<!--Start of Rating-->

<asp:Panel ID="pnlAddrConfirmation" runat="server" Width="100%" Visible="false">
<table id="tblAddrConfirmation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAddrConfirmation" runat="server" Text="Address Confirmation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlAddrConfirmation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Not Confirmed" Value="Not Confirmed"></asp:ListItem>
<asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
<asp:ListItem Text="Refused to provide" Value="Refused to provide"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlContactability" runat="server" Width="100%" Visible="false">
<table id="tblContactability"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactability" runat="server" Text="Contactability"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlContactability" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlConfirmationApplication" runat="server" Width="100%" Visible="false">
<table id="tblConfirmationApplication"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblConfirmationApplication" runat="server" Text="Confirmation of Application"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlConfirmationApplication" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Applied" Value="Applied"></asp:ListItem>
<asp:ListItem Text="Not Applied" Value="Not Applied"></asp:ListItem>
<asp:ListItem Text="Not Known" Value="Not Known"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlProfile" runat="server" Width="100%" Visible="false">
<table id="tblProfile" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblProfile" runat="server" Text="Profile"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlProfile" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
<asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
<asp:ListItem Text="Good" Value="Good"></asp:ListItem>
<asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
<asp:ListItem Text="Average" Value="Average"></asp:ListItem>
<asp:ListItem Text="Failure" Value="Failure"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReputation" runat="server" Width="100%" Visible="false">
<table id="tblReputation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblReputation" runat="server" Text="Reputation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlReputation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
<asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
<asp:ListItem Text="Good" Value="Good"></asp:ListItem>
<asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
<asp:ListItem Text="Average" Value="Average"></asp:ListItem>
<asp:ListItem Text="Failure" Value="Failure"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNegmatch" runat="server" Width="100%" Visible="false">
<table id="tblNegmatch" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNegmatch" runat="server" Text="Negmatch"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlNegmatch" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDetailsNegmatch" runat="server" Width="100%" Visible="false">
<table id="tblDetailsNegmatch" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDetailsNegmatch" runat="server" Text="Details of Negmatch"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"    ID="txtDetailsNegmatch" runat="server" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOverallAssessment" runat="server" Width="100%" Visible="false">
<table id="tblOverallAssessment"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblOverallAssessment" runat="server" Text="Overall Assessment"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlOverallAssessment" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="RCC Request" Value="RCC Request"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="Neutral"></asp:ListItem>
<asp:ListItem Text="Not Recommended" Value="Not Recommended"></asp:ListItem>
<asp:ListItem Text="Recommended" Value="Recommended"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReasonsforAssessment" runat="server" Width="100%" Visible="false">
<table id="tblReasonsforAssessment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblReasonsforAssessment" runat="server" Text="Reasons for the above assessment(Decline Reasons)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtReasonsforAssessment" runat="server" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<!--End of Rating-->
<!---Start of adding Additional Fields---->

<asp:Panel ID="pnlSpecialInstructions" runat="server" Width="100%" Visible="false">
<table id="tblSpecialInstructions" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSpecialInstructions" runat="server" Text="Special Instructions"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtSpecialInstructions" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlIsofficeAreaNegativeArea" runat="server" Width="100%" Visible="false">
<table id="tblIsofficeAreaNegativeArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblIsofficeAreaNegativeArea" runat="server" Text="Is office Area is in a Negative Area"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIsofficeAreaNegativeArea" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlIsResidenceAddressNegativeArea" runat="server" Width="100%" Visible="false">
<table id="tblIsResidenceAddressNegativeArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblIsResidenceAddressNegativeArea" runat="server" Text="Is Residence Address is in a Negative Area"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIsResidenceAddressNegativeArea" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDesigDeptContactedPerson" runat="server" Width="100%" Visible="false">
<table id="tblDesigDeptContactedPerson" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDesigDeptContactedPerson" runat="server" Text="Design/Dept of Contacted Person"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDesigDeptContactedPerson" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmployersName" runat="server" Width="100%" Visible="false">
<table id="tblEmployersName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmployersName" runat="server" Text="Employers Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtEmployersName" runat="server" Width="60%" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBusinessContactNo" runat="server" Width="100%" Visible="false">
<table id="tblBusinessContactNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblBusinessContactNo" runat="server" Text="Mobile No."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtBusiContactNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNatureofBusinessofCompany" runat="server" Width="100%" Visible="false">
<table id="tblNatureofBusinessofCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNatureofBusinessofCompany" runat="server" Text="Nature of Business of the Company"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlNatureofBusinessofCompany" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Trading" Value="Trading"></asp:ListItem>
        <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem> 
        <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem> 
        <asp:ListItem Text="Building" Value="Building"></asp:ListItem> 
        <asp:ListItem Text="Contractor" Value="Contractor"></asp:ListItem> 
        <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem> 
        <asp:ListItem Text="Consultancy" Value="Consultancy"></asp:ListItem> 
        <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem> 
        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>            
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDeptofApp" runat="server" Width="100%" Visible="false">
<table id="tblDeptofApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDeptofApp" runat="server" Text="Dept. of App."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDeptofApp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNoOfYearscurrEmployment" runat="server" Width="100%" Visible="false">
<table id="tblNoOfYearscurrEmployment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNoOfYearscurrEmployment" runat="server" Text="No. of Years at current Employment"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtNoOfYearscurrEmployment" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlApplicantResidentialAddress" runat="server" Width="100%" Visible="false">
<table id="tblApplicantResidentialAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblApplicantResidentialAddress" runat="server" Text="Applicant's Residential Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtApplicantResidentialAddress" width="80%" runat="server" MaxLength="300"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAppliResiAdd" runat="server" Width="100%" Visible="false">
<table id="tblAppliResiAdd" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAppliResiAdd" runat="server" Text="Appli Resi Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtAppliResiAdd" TextMode="MultiLine" runat="server" MaxLength="300"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResidencePhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblResidencePhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResidencePhoneNo" runat="server" Text="Residence Phone No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtResidencePhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlApplicantDOBApproxAge" runat="server" Width="100%" Visible="false">
<table id="tblApplicantDOBApproxAge" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblApplicantDOBApproxAge" runat="server" Text="Applicant DOB / Approx Age"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtApplicantDOBApproxAge" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%-- New Field Added by Sunny Chauhan : Start>--%>
<asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
    <table id="tblDirectoryCheck" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
    <tr>
    <td class="TDWidth">
    <asp:Label SkinID="lblSkin"   ID="lblDirectoryCheck" runat="server" Text="CD ROM(Address Confirmed)"></asp:Label>
    </td>
    <td style="width:2%"  >:</td>
    <td>
    <asp:DropDownList SkinID="ddlSkin" ID="ddlDirectoryCheck" runat="server" >
    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
    <asp:ListItem Text="No" Value="No"></asp:ListItem>
    <asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
    </asp:DropDownList>
    </td>
    <td class="TDWidth">
    <asp:Label SkinID="lblSkin" ID="lblCDROMAddress" runat="server" Text="If No (Then Update the Details)"></asp:Label>
    </td>
    <td style="width:0.5%"  >:</td>
    <td>
    <asp:TextBox SkinID="txtSkin" ID="txtNoReason" runat="server" MaxLength="150"></asp:TextBox>
    </td>
    </tr>
    </table>
</asp:Panel> 
<%-- New Field Added By Sunny Chauhan : End>--%>
<asp:Panel ID="pnlNameofApplicantConfirmedatgivenPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblNameofApplicantConfirmedatgivenPhoneNo1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameofApplicantConfirmedatgivenPhoneNo1" runat="server" Text="Name of Applicant Confirmed at given PhoneNo"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlNameofApplicantConfirmedatgivenPhoneNo1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr> 
</table>
</asp:Panel>  
<%-- New Field Added by Sunny Chauhan : Start>--%>
<asp:Panel ID="pnlCDNameCon" runat="server" Width="100%" Visible="false">
<table id="tblNameofApplicantConfirmedatgivenPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameofApplicantConfirmedatgivenPhoneNo" runat="server" Text="CD ROM (Name Confirmed)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlNameofApplicantConfirmedatgivenPhoneNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblMismatchInAddTelNo" runat="server" Text="If No (Reason)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
        <%--asp:DropDownList ID="ddlMismatchedInAddTelNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employer Ph.No." Value="Employer Ph.No."></asp:ListItem>               
    </asp:DropDownList--%>
    <asp:TextBox SkinID="txtSkin" ID="txtMismatchedInAddTelNo" runat="server" MaxLength="150"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlMisMatch" runat="server" Width="100%" Visible="false">
<table id="tblMisMatch" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblMisMatch" runat="server" Text="Mismatched in"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlmismatch" runat="server" AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employment Ph.No." Value="Employer Ph.No."></asp:ListItem>               
</asp:DropDownList>

 <%--<asp:DropDownList ID ="ddlMismatch" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employment Ph.No." Value="Employer Ph.No."></asp:ListItem>               
    </asp:DropDownList>--%>
</td>
</tr> 
</table>
</asp:Panel> 
<%-- New Field Added By Sunny Chauhan : End>--%>
<%--<asp:Panel ID="pnlTelecallerName" runat="server" Width="100%" Visible="false">
<table id="tblTelecallerName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTelecallerName" runat="server" Text="Tele caller Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlTelecallerName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>--%>
<asp:Panel ID="pnlTelCallName" runat="server" Width="100%" Visible="true">
<table id="tblTelCallName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTelCallName" runat="server" Text="Tele Caller Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlTeleName" runat="server" AutoPostBack="false" SkinID="ddlSkin"></asp:DropDownList>
<%--<asp:DropDownList ID="ddlTelecallerName" runat="server" AppendDataBoundItems="true"  AutoPostBack="false" SkinID="ddlSkin">
<%--<asp:ListItem Value="0">---SELECT---</asp:ListItem>--%>
<%--</asp:DropDownList>--%>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlCalledupOffTelNo" runat="server" Width="100%" Visible="false">
<table id="tblCalledupOffTelNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCalledupOffTelNo" runat="server" Text="Called up on Off Tel. No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtCalledupOffTelNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlExtNo" runat="server" Width="100%" Visible="false">
<table id="tblExtNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblExtNo" runat="server" Text="Ext. No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtExtNo" runat="server" MaxLength="5"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlSpkToAppReceiptColleague" runat="server" Width="100%" Visible="false">
<table id="tblSpkToAppReceiptColleague" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSpkToAppReceiptColleague" runat="server" Text="Spk to app/ receipt/ colleague"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtSpkToAppReceiptColleague" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmpConfirmedNotconfirmed" runat="server" Width="100%" Visible="false">
<table id="tblEmpConfirmedNotconfirmed" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmpConfirmedNotconfirmed" runat="server" Text="Emp. Confirmed/ Not confirmed"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtEmpConfirmedNotconfirmed" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlYCR" runat="server" Width="100%" Visible="false">
<table id="tblYCR" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblYCR" runat="server" Text="YCR"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtYCR" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmpPermanentTemp" runat="server" Width="100%" Visible="false">
<table id="tblEmpPermanentTemp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmpPermanentTemp" runat="server" Text="Emp. Permanent/ Temp."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtEmpPermanentTemp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRecommendation" runat="server" Width="100%" Visible="false">
<table id="tblRecommendation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRecommendation" runat="server" Text="Recommendation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlRecommendation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
        <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
        <asp:ListItem Text="Defaulter" Value="Defaulter"></asp:ListItem>     
        <asp:ListItem Text="Referral" Value="Referral"></asp:ListItem> 
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDirCheck" runat="server" Width="100%" Visible="false">
<table id="tblDirCheck"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDirCheck" runat="server" Text="Directory Check"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlDirCheck" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="W01 - Both Match" Value="W01 - Both Match"></asp:ListItem>
<asp:ListItem Text="W02 - Both Mismatch" Value="W02 - Both Mismatch"></asp:ListItem>
<asp:ListItem Text="W03 - Name Match Address Mismatch" Value="W03 - Name Match Address Mismatch"></asp:ListItem>
<asp:ListItem Text="W04 - Address Match Name Mismatch" Value="W04 - Address Match Name Mismatch"></asp:ListItem>
<asp:ListItem Text="W05 - Number Not Found in Web check, Invalid No" Value="W05 - Number Not Found in Web check, Invalid No"></asp:ListItem>
<asp:ListItem Text="W06 - PVT Operator" Value="W06 - PVT Operator"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNegativeCode" runat="server" Width="100%" Visible="false">
<table id="tblNegativeCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNegativeCode" runat="server" Text="Negative Code"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtNegativeCode" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPriorityCustomer" runat="server" Width="100%" Visible="false">
<table id="tblPriorityCustomer" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblPriorityCustomer" runat="server" Text="Priority Customer"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlPriorityCustomer" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="a" Value="a"></asp:ListItem>
<asp:ListItem Text="b" Value="b"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlSegmentation" runat="server" Width="100%" Visible="false">
<table id="tblSegmentation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSegmentation" runat="server" Text="Segmentation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtSegmentation" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlInfoRequired" runat="server" Width="100%" Visible="false">
<table id="tblInfoRequired" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblInfoRequired" runat="server" Text="Info Required"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtInfoRequired" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlChangeinPhoneNumber" runat="server" Width="100%" Visible="false">
<table id="tblChangeinPhoneNumber" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblChangeinPhoneNumber" runat="server" Text="Change in Phone Number"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlChangeinPhoneNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReasonsforchange" runat="server" Width="100%" Visible="false">
<table id="tblReasonsforchange" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblReasonsforchange" runat="server" Text="Reasons for change"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlReasonforchange" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Customer Shifted" Value="Customer Shifted"></asp:ListItem>
        <asp:ListItem Text="Not Known" Value="Not Known"></asp:ListItem> 
        <asp:ListItem Text="Transferred PP No" Value="Transferred PP No"></asp:ListItem> 
        <asp:ListItem Text="Neighbor" Value="Neighbor"></asp:ListItem> 
        <asp:ListItem Text="PCO" Value="PCO"></asp:ListItem> 
        <asp:ListItem Text="Relative" Value="Relative"></asp:ListItem> 
        <asp:ListItem Text="STD Booth" Value="STD Booth"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlCurrentResidencePeriod" runat="server" Width="100%" Visible="false">
<table id="tblCurrentResidencePeriod" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCurrentResidencePeriod" runat="server" Text="Current Residence Period"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtCurrentResidencePeriod" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlApplicantQualification" runat="server" Width="100%" Visible="false">
<table id="tblApplicantQualification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblApplicantQualification" runat="server" Text="Applicant's Qualification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtApplicantQualification" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPermanentAdd" runat="server" Width="100%" Visible="false">
<table id="tblPermanentAdd" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblPermanentAdd" runat="server" Text="Permanent Add"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtPermanentAdd" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTeleCallerCode" runat="server" Width="100%" Visible="false">
<table id="tblTeleCallerCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTeleCallerCode" runat="server" Text="Tele Caller Code"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTeleCallerCode" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlForSelfEmployedTypeOrganisation" runat="server" Width="100%" Visible="false">
<table id="tblForSelfEmployedTypeOrganisation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblForSelfEmployedTypeOrganisation" runat="server" Text="For Self Employed- Type of Organisation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlForSelfEmployedTypeOrganisation" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Proprietorship" Value="Proprietorship"></asp:ListItem>
        <asp:ListItem Text="Partnership" Value="Partnership"></asp:ListItem> 
        <asp:ListItem Text="Pvt. Ltd." Value="Pvt. Ltd."></asp:ListItem> 
        <asp:ListItem Text="Public Ltd." Value="Public Ltd."></asp:ListItem> 
        <asp:ListItem Text="Others" Value="Others"></asp:ListItem> 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlContactedpersonRelationshipWithApplicant" runat="server" Width="100%" Visible="false">
<table id="tblContactedpersonRelationshipWithApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactedpersonRelationshipWithApplicant" runat="server" Text="Contacted person Relationship With Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList SkinID="ddlSkin" ID="ddlContactedpersonRelationshipWithApplicant" runat="server" AutoPostBack="false">
    <asp:ListItem Text=" " Value=" "></asp:ListItem>
    <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
    <asp:ListItem Text="Partner" Value="Partner"></asp:ListItem>
    <asp:ListItem Text="Superior" Value="Superior"></asp:ListItem>
    <asp:ListItem Text="Relative" Value="Relative"></asp:ListItem>
    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
    <asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
</asp:DropDownList> 
</td>
</tr>
</table>
</asp:Panel>
<!---End of adding Additional Fields---->
<!---Start Of Included Fields After Testing----->

<asp:Panel ID="pnlAdditionalRemark" runat="server" Width="100%" Visible="false">
<table id="tblAdditionalRemark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAdditionalRemark" runat="server" Text="Additional Remark"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAdditionalRemark" runat="server" MaxLength="250" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNameOfCompany" runat="server" Width="100%" Visible="false">
<table id="tblNameOfCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfCompany" runat="server" Text="Name Of Company"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%"  ID="txtNameOfCompany" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlLandmarkObserved" runat="server" Width="100%" Visible="false">
<table id="tblLandmarkObserved" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLandmarkObserved" runat="server" Text="Landmark Observed"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLandmarkObserved" runat="server" MaxLength="500"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--///////////////add by mshrque bank//////////////--%>
<asp:Panel ID="pnlRefCheckLog" runat="server" Width="100%" Visible="false">
<table id="tblAttempt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center" colspan="5">
<asp:Label SkinID="lblSkin" ID="Label6" ForeColor="blue" runat="server" Text="Reference Check"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth" style="height: 14px">
<asp:Label SkinID="lblSkin" ID="Label1" runat="server" Text="Attempts"></asp:Label>
</td>
<td style="height: 14px" >
<asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Date [dd/MM/yyyy]"></asp:Label>
</td>
<td style="height: 14px">
<asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Time [hh:mm]"></asp:Label>
</td>
<td style="height: 14px">
<asp:Label SkinID="lblSkin" ID="Label5" runat="server" Text="Verifier Remark"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server"  Text="First Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate1" runat="server" ></asp:TextBox>
    <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="5" ID="txtAttemptTime1" Width="50" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType1" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
    <td>
<asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark1" runat="server" ></asp:TextBox>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSecondAttempt" runat="server"  Text="Second Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate2" runat="server" ></asp:TextBox>
    <img id="Img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="5"   ID="txtAttemptTime2" Width="50" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType2" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAttemptRemark2" runat="server" ></asp:TextBox>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblThirdAttempt" runat="server"  Text="Third Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate3" runat="server" ></asp:TextBox>
    <img id="Img3"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime3" Width="50" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType3" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAttemptRemark3" runat="server" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--//////////////////////////end code///////////////////////////////////////////////////--%>

<table id="tblTeleverificationResults" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTeleverificationResults" runat="server" Text="Televerification Result"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>                     
         <asp:DropDownList SkinID="ddlSkin" ID="ddlTeleverificationResults" runat="server" DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID"  OnDataBound="ddlTeleverificationResults_DataBound">
         </asp:DropDownList>
    </td>
</tr>
</table>
<%--////////////add by santosh shelar add decliene reason code 23/08/08////////////////////////--%>
<table id="tblDeclineReasons" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDeclineReasons" runat="server" Text="Decline Reasons"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDeclineReasons" runat="server" MaxLength="500" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
<%--/////////////////end code/////////////////////--%>

<table id="tblLogin" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center" colspan="5">
<asp:Label SkinID="lblSkin" ID="lblTelecallLog" ForeColor="blue" runat="server" Text="TELECALL LOG"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblLogin" runat="server" Text="Login"></asp:Label>
</td>
<td >
<asp:Label SkinID="lblSkin" ID="lblDate" runat="server" Text="Date [dd/mm/yyyy]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTime" runat="server" Text="Time [hh:mm]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="Tel No."></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblRemark" runat="server" Text="Remark"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl1stCall" runat="server" Text="1st call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate1stCall" runat="server" MaxLength="11"></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1stCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime1stCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime1stCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo1stCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks1stCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl2ndCall" runat="server" Text="2nd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtDate2ndCall" runat="server" MaxLength="11"></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2ndCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime2ndCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime2ndCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo2ndCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks2ndCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl3rdCall" runat="server" Text="3rd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate3rdCall" runat="server" MaxLength="11"></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3rdCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime3rdCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime3rdCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo3rdCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks3rdCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl4thCall" runat="server" Text="4th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate4thCall" runat="server" MaxLength="11"></asp:TextBox>
    <img id="ImgDate4thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate4thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime4thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime4thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo4thCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks4thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl5thCall" runat="server" Text="5th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate5thCall" runat="server" MaxLength="11"></asp:TextBox>
    <img id="ImgDate5thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate5thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime5thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime5thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo5thCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks5thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
<%--Added By Sunny Chauhan : Start --%>
<table id="tblContactNumberDetail" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label ID="lblActContDet" SkinID="lblSkin" runat="server" Text="Actual Contacted Number Type"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlActContNum" SkinID="ddlSkin" runat="server" AutoPostBack="false">
<asp:ListItem Text="New" Value="New"></asp:ListItem>
<asp:ListItem Text="Mobile" Value="Mobile"></asp:ListItem>
<asp:ListItem Text="Landline" Value="Landline"></asp:ListItem>
</asp:DropDownList>
</td>
<td class="TDWidth">
<asp:Label ID="lblNumber" SkinID="lblSkin" runat="server" Text="Actual Number"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox ID="txtActualNumber" SkinID="txtSkin" runat="server" MaxLength="15"></asp:TextBox>
</td></tr>
</table>
<%--Addition Done Sunny Chauhan : End --%>
<table id="tblNewInfoObt"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNewInfoObt" runat="server" Text="New Info Obtained (TCRemarks)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtNewInfoObt" runat="server" TextMode="MultiLine" Width="90%" Height="90%" MaxLength="750"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
</td>
</tr>
</table>
<%--/////////////add by santosh shelar//////////////--%>
<table id="tblSupervisorName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSupervisorName" runat="server" Text="Supervisor Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlSupervisorName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>
<table id="tblSupervisorRemark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSupervisorRemark" runat="server" Text="Supervisor Remark"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSupervisorRemark" runat="server" TextMode="MultiLine"  MaxLength="500" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
<br />
<!--End of TeleLog-->
<!---End Of Included Fields After Testing----->
 <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server" SkinID="btnSubmitSkin" ValidationGroup="grpAttempts" Text="Submit" OnClick="btnSubmit_Click" />          
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
        </td>
      </tr>
    </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
     <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
     <asp:HiddenField ID="hidMode" runat="server" />
     <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
     <asp:Label ID="lblMessage" ForeColor="Red" runat="server" SkinID="lblErrorMsg" Width="672px"></asp:Label></asp:Panel>

</asp:TableCell></asp:TableRow></asp:Table>

<asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select televerification result." ValidationGroup="grpAttempts" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlTeleverificationResults" OnServerValidate="cvSelectCaseStatus_ServerValidate">
 </asp:CustomValidator>
 
 <%--asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="txtSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grpAttempts"></asp:RequiredFieldValidator--%>
    
<asp:RequiredFieldValidator ID="refDate1" runat="server" ControlToValidate="txtDate1stCall" Display="None" ErrorMessage="Enter Date in 1st call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate2" runat="server" ControlToValidate="txtDate2ndCall" Display="None" ErrorMessage="Enter Date in 2nd call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate3" runat="server" ControlToValidate="txtDate3rdCall" Display="None" ErrorMessage="Enter Date in 3rd call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate4" runat="server" ControlToValidate="txtDate4thCall" Display="None" ErrorMessage="Enter Date in 4th call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate5" runat="server" ControlToValidate="txtDate5thCall" Display="None" ErrorMessage="Enter Date in 5th call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 
 
 <asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtTime1stCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 1st call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime2" runat="server" ControlToValidate="txtTime2ndCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 2nd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime3" runat="server" ControlToValidate="txtTime3rdCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 3rd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime4" runat="server" ControlToValidate="txtTime4thCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 4th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime5" runat="server" ControlToValidate="txtTime5thCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 5th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator> 
 <asp:RegularExpressionValidator ID="revDate1" runat="server" ControlToValidate="txtDate1stCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 1st call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate2" runat="server" ControlToValidate="txtDate2ndCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 2nd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate3" runat="server" ControlToValidate="txtDate3rdCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 3rd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate4" runat="server" ControlToValidate="txtDate4thCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 4th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate5" runat="server" ControlToValidate="txtDate5thCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 5th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
    
 <%--<asp:CustomValidator ID="cv1stTelCall" runat="server" ClientValidationFunction="ValidateTime1"
    ControlToValidate="txtTime1stCall" Display="None" ErrorMessage="Enter telephone no in 1st call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv2ndTelCall" runat="server" ClientValidationFunction="ValidateTime2"
    ControlToValidate="txtTime2ndCall" Display="None" ErrorMessage="Enter telephone no in 2nd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv3rdTelCall" runat="server" ClientValidationFunction="ValidateTime3"
    ControlToValidate="txtTime3rdCall" Display="None" ErrorMessage="Enter telephone no in 3rd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv4thTelCall" runat="server" ClientValidationFunction="ValidateTime4"
    ControlToValidate="txtTime4thCall" Display="None" ErrorMessage="Enter telephone no in 4th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv5thTelCall" runat="server" ClientValidationFunction="ValidateTime5"
    ControlToValidate="txtTime5thCall" Display="None" ErrorMessage="Enter telephone no in 5th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>--%>
    
   
 <asp:CustomValidator ID="cvAttemptRemark1" runat="server" ClientValidationFunction="ValidateRemark1"
    ControlToValidate="ddlRemarks1stCall" Display="None" ErrorMessage="Enter time in 1st call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark2" runat="server" ClientValidationFunction="ValidateRemark2"
    ControlToValidate="ddlRemarks2ndCall" Display="None" ErrorMessage="Enter time in 2nd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark3" runat="server" ClientValidationFunction="ValidateRemark3"
    ControlToValidate="ddlRemarks3rdCall" Display="None" ErrorMessage="Enter time in 3rd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark4" runat="server" ClientValidationFunction="ValidateRemark4"
    ControlToValidate="ddlRemarks4thCall" Display="None" ErrorMessage="Enter time in 4th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark5" runat="server" ClientValidationFunction="ValidateRemark5"
    ControlToValidate="ddlRemarks5thCall" Display="None" ErrorMessage="Enter time in 5th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
    
<asp:CustomValidator ID="cvTel1" runat="server"
    ControlToValidate="txtTelNo1stCall" Display="None" ErrorMessage="Enter remark in 1st call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel1"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel2" runat="server"
    ControlToValidate="txtTelNo2ndCall" Display="None" ErrorMessage="Enter remark in 2nd call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel2"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel3" runat="server"
    ControlToValidate="txtTelNo3rdCall" Display="None" ErrorMessage="Enter remark in 3rd call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel3"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel4" runat="server"
    ControlToValidate="txtTelNo4thCall" Display="None" ErrorMessage="Enter remark in 4th call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel4"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel5" runat="server"
    ControlToValidate="txtTelNo5thCall" Display="None" ErrorMessage="Enter remark in 5th call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel5"></asp:CustomValidator> 
    
    <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtDate1stCall"
        ClientValidationFunction="ValidateAttempts"  ValidationGroup="grpAttempts"  
        ErrorMessage="Enter atleast one Attempt." Display="None">
      </asp:CustomValidator>    
   
  
 <asp:ValidationSummary ID="vsAttempt" runat="server" ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />
</td>
</tr>
</table>
<table>
    <tr>
    <td><asp:LinkButton ID="lbRV" runat="server" Text="RV" Width="22px"  Visible="False" OnClick="lbRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBV" runat="server" Text="BV" Width="22px" Visible="False" OnClick="lbBV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbRT" runat="server" Text="RT" Width="22px" Visible="False" OnClick="lbRT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBT" runat="server" Text="BT" Width="22px" Visible="False" OnClick="lbBT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRTV" runat="server" Text="PRTV" Width="22px" Visible="False" OnClick="lbPRTV_Click"></asp:LinkButton>
    </td>
    <td><asp:TextBox ID="txtfdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txttdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox></td>
     
    </tr>
    
    </table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
    &nbsp;
</fieldset>
</td></tr></table>
</asp:Content>
