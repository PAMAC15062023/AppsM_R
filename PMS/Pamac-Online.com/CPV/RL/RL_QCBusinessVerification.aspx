<%@ Page Language="C#" MasterPageFile="RL_MasterPage.master" AutoEventWireup="true" CodeFile="RL_QCBusinessVerification.aspx.cs" Inherits="RL_QCBusinessVerification" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading"><asp:Label ID="lblHead" runat="server"></asp:Label></legend>
<script language="javascript" type="text/jscript">
function ValidateTextLength(DisplayName, ControlName, xLength)
{   
    if (ControlName.value.length > parseInt(xLength)-2)
    {                      
         ControlName.value = ControlName.value.substring( 0, parseInt(xLength)-1 ); 
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
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

 function ValidateVerificationTime(source, arguments)
 { 
      //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
      if(document.aspnetForm.ctl00$C1$txtTimeOfVerification.value.length ==0)
      {            
        
            document.aspnetForm.ctl00$C1$txtTimeOfVerification.focus();
            arguments.IsValid=false;
                    
      }
 }

 function ValidateVerificationDate(source, arguments)
 { 
      //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
      if(document.aspnetForm.ctl00$C1$txtDateOfVerification.value.length ==0)
      {            
        
            document.aspnetForm.ctl00$C1$txtDateOfVerification.focus();
            arguments.IsValid=false;
                    
      }
 }
</script>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" style="background-color:#E7F6FF">
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
<tr><td></td><td>
 <asp:Table ID="tblBusiVerification" runat="server" Width="100%">
            <asp:TableRow ID="tblrowPlace" runat="server">
                <asp:TableCell ID="tblCellPlace" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder5" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder6" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder7" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder8" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder9" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder10" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder11" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder12" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder13" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder14" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder15" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder16" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder17" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder18" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder19" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder20" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder21" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder22" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder23" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder24" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder25" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder26" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder27" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder28" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder29" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder30" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder31" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder32" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder33" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder34" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder35" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder36" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder37" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder38" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder39" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder40" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder41" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder42" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder43" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder44" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder45" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder46" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder47" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder48" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder49" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder50" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder51" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder52" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder53" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder54" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder55" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder56" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder57" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder58" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder59" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder60" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder61" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder62" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder63" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder64" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder65" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder66" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder67" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder68" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder69" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder70" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder71" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder72" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder73" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder74" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder75" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder76" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder77" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder78" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder79" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder80" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder81" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder82" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder83" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder84" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder85" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder86" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder87" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder88" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder89" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder90" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder91" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder92" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder93" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder94" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder95" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder96" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder97" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder98" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder99" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder100" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder101" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder102" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder103" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder104" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder105" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder106" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder107" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder108" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder109" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder110" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder111" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder112" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder113" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder114" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder115" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder116" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder117" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder118" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder119" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder120" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder121" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder122" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder123" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder124" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder125" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder126" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder127" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder128" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder129" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder130" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder131" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder132" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder133" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder134" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder135" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder136" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder137" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder138" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder139" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder140" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder141" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder142" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder143" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder144" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder145" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder146" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder147" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder148" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder149" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder150" runat="server" EnableViewState="false"></asp:PlaceHolder>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server">
    <asp:TableCell ID="tblCell" runat="server"> 
    <!--Start ErrorMessgage-->
    
    <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ></asp:Label>
        </td>        
        </tr>
       </table>
   </asp:Panel>   
   <!--END ErrorMessgage--> 
   
 
   <asp:Panel ID="pnlDateTimeOfVerification" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDateTimeOfVerification" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDateTimeOfVerification" runat="server" Text="Date and Time Of Verification"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtDateOfVerification" runat="server" MaxLength="10" ></asp:TextBox>
                   <img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
                   <asp:TextBox SkinID="txtSkin" Width="5%" MaxLength="5" ID="txtTimeOfVerification" runat="server" ></asp:TextBox>[hh:mm]
                   
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDateTimeOfVerification" runat="server"  AutoPostBack="false">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>                                    
                </asp:DropDownList>
                </td>
                </tr>
           </table>
    </asp:Panel>
    
   <asp:Panel ID="pnlLanNo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLanNo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLanNo" runat="server" Text="Lan No"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtLanNo" runat="server" ReadOnly="true" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>     
     
      <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAppName" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server" Text="Name of the Applicant"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAppName" runat="server" ReadOnly="true"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>  
     <asp:Panel ID="pnlPersonMet" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPersonMet" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblPersonMet" runat="server" Text="Name of Person met"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPersonMet" runat="server" MaxLength="50"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>  
      <asp:Panel ID="pnlPersonMetDesgn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPersonMetDesgn" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblPersonMetDesgn" runat="server" Text="Designation of Person met"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtPersonMetDesgn" runat="server" MaxLength="100"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>  
     <asp:Panel ID="pnlAppConfirm" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAppConfirm" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAppConfirm" runat="server" Text="Person contacted at office telephone confirms that applicant worked at given address"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtAppConfirm" runat="server" MaxLength="50"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel> 
     <asp:Panel ID="pnlBusinessName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessName" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblBusinessName" runat="server" Text="Name of business/Profession"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBusinessName" runat="server" MaxLength="100" ></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlServiceYearMths" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblServiceYearMths" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth"   >
            <asp:Label SkinID="lblSkin" ID="lblServiceYearMths" runat="server" Text="Number of years in service"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtServiceYear" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Yrs
            &nbsp;
             <asp:TextBox SkinID="txtSkin"  ID="txtServiceMths" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Mths
             </td>           
            
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlAppDesgn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAppDesgn" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAppDesgn" runat="server" Text="Designation of the Applicant"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtAppDesgn" runat="server" MaxLength="100" ></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlNumberOfEmployee" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfEmployee" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblNumberOfEmployee" runat="server" Text="Number of Employees seen"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfEmployee" runat="server" MaxLength="50" ></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
      <asp:Panel ID="pnlBusinessConstitutency" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessConstitutency" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblBusinessConstitutency" runat="server" Text="Constitutency of the business"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtBusinessConstitutency" runat="server" MaxLength="100"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>     
     <asp:Panel ID="pnlOfficeType" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeType" runat="server" Text="Type of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeType" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Shared</asp:ListItem>
                    <asp:ListItem>Business Centre</asp:ListItem>
                    <asp:ListItem>Independent Office</asp:ListItem>                    
                    <asp:ListItem>Industry</asp:ListItem>
                    <asp:ListItem>Resi cum Office</asp:ListItem>
                    <asp:ListItem>Small scale/shed</asp:ListItem>
                    <asp:ListItem>Office complex</asp:ListItem>
                    <asp:ListItem>Shared Office</asp:ListItem>
                    <asp:ListItem>Clinic</asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Undeveloped</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>                    
                </asp:DropDownList>
                </td>  
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOtherOfficeType" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
     </asp:Panel>
     
     <asp:Panel ID="pnlLocatingOffice" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocatingOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocatingOffice" runat="server" Text="Locating Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtLocatingOffice" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlResiCumoff" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResiCumoff" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResiCumoff" runat="server" Text="Indicate if residence-cum-Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResiCumoff" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlNameBoardSighted" runat="server" Width="100%" Visible="false">                
        <table cellpadding="0" cellspacing="0" border="0" id="tblNameBoardSighted" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameBoardSighted" runat="server" Text="Name Plate sighted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNameBoardSighted" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                                    
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
     
      <asp:Panel ID="pnlBusinessActivity" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessActivity" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessActivity" runat="server" Text="Business activity seen"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessActivity" runat="server"  AutoPostBack="false">                    
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>   
                    <asp:ListItem>Low</asp:ListItem>   
                    <asp:ListItem>IDLE</asp:ListItem>            
                    <asp:ListItem>No Activity</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>                        
                    <asp:ListItem>Average</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlLandmark" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  >
                <asp:TextBox SkinID="txtSkin"  ID="txtLandmark" runat="server" MaxLength="100"></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlEquipStockSighted" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblEquipStockSighted" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblEquipStockSighted" runat="server" Text="Equipment/Stock sighted"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtEquipStockSighted" runat="server" MaxLength="100" ></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlJobNature" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblJobNature" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblJobNature" runat="server" Text="Nature of the job"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtJobNature" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlVisitCardProof" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVisitCardProof" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVisitCardProof" runat="server" Text="Visiting Card obtained as proof of visit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitCardProof" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
            </tr>
           </table>
       </asp:Panel>
      <asp:Panel ID="pnlRemarks" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRemarks" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('Remarks', this, 255);"  ID="txtRemarks" runat="server" MaxLength="255" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRating" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRating" runat="server" Text="Rating"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRating" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>            
                        <asp:ListItem>Referred</asp:ListItem>            
                        <asp:ListItem>Recommended</asp:ListItem>            
                        <asp:ListItem>Non-Recommended</asp:ListItem>            
                        <asp:ListItem>Neutral</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                </table>
      </asp:Panel>        
      <asp:Panel ID="pnlVerifierName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVerifierName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVerifierName" runat="server" Text="Verifier Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtVerifierName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>       
      <asp:Panel ID="pnlSupervisorName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSupervisorName" runat="server" Text="Supervisor's Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSupervisorName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>       
      <asp:Panel ID="pnlMatchinNegativeList" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMatchinNegativeList" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMatchinNegativeList" runat="server" Text="Match in the Negative List"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlMatchinNegativeList" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                 </asp:DropDownList>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlNameOfBankDefaultWith" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfBankDefaultWith" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameOfBankDefaultWith" runat="server" Text="If Yes Name of the bank defaulted with"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  Width="80%"  ID="txtNameOfBankDefaultWith" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlProductName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblProductName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblProductName" runat="server" Text="Name of the Product"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProductName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlDefaultInWhichBucket" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDefaultInWhichBucket" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblDefaultInWhichBucket" runat="server" Text="Default in which bucket"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDefaultInWhichBucket" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlAmountOfDefaultINR" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAmountOfDefaultINR" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAmountOfDefaultINR" runat="server" Text="Amount of Default INR"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtAmountOfDefaultINR" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlTelCDRomCheck" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTelCDRomCheck" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTelCDRomCheck" runat="server" Text="Telephone CD Rom check"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTelCDRomCheck" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Match</asp:ListItem>
                        <asp:ListItem>Not Match</asp:ListItem>            
                 </asp:DropDownList>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlOffTelNoInNameOf" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOffTelNoInNameOf" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOffTelNoInNameOf" runat="server" Text="Office Telephone number in the Name of"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOffTelNoInNameOf" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      
      <asp:Panel ID="pnlTelNo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTelNo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="TelNo"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtTelNo" runat="server" MaxLength="100" ></asp:TextBox>                            
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlMobileNo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMobileNo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Mobile No./Type of Phone"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtMobileNo" runat="server" MaxLength="100" ></asp:TextBox>                
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlLoanAmount" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLoanAmount" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLoanAmount" runat="server" Text="Loan Amount"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtLoanAmount" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlUseOfLoan" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblUseOfLoan" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblUseOfLoan" runat="server" Text="Use of Loan"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtUseOfLoan" runat="server" MaxLength="100" ></asp:TextBox>                
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlProduct" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblProduct" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblProduct" runat="server" Text="Product"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProduct" runat="server" MaxLength="100" ></asp:TextBox>                
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlLocationOfProduct" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocationOfProduct" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocationOfProduct" runat="server" Text="Location of Product"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtLocationOfProduct" runat="server" MaxLength="100" ></asp:TextBox>                
                </td>
                </tr>
                </table>
      </asp:Panel>
      <asp:Panel ID="pnlDOB" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtDOB" runat="server" MaxLength="50"></asp:TextBox> 
                <img id="imgDOB"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
                </td>
                </tr>
                </table>
      </asp:Panel>
      <asp:Panel ID="pnlMaritalStatus" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMaritalStatus" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblMaritalStatus" runat="server"  Text="Marital Status"></asp:Label>    
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin"  ID="ddlMaritalStatus" runat="server"   AutoPostBack="false"> 
            <asp:ListItem Text="NA" Value=""></asp:ListItem>
            <asp:ListItem>Married</asp:ListItem>
            <asp:ListItem>Single</asp:ListItem>
            <asp:ListItem>Divorced</asp:ListItem>   
            </asp:DropDownList>         
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlEducation" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblEducation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEducation" runat="server" Text="Education"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin"  ID="ddlEducation" runat="server"   AutoPostBack="false">                     
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem >Under SSC</asp:ListItem>
                    <asp:ListItem >Grad(General)</asp:ListItem>
                    <asp:ListItem >Grad(Professional)</asp:ListItem>   
                    <asp:ListItem >Some College</asp:ListItem>
                    <asp:ListItem >SSC/MSC</asp:ListItem>
                    <asp:ListItem >PG(General)</asp:ListItem>
                    <asp:ListItem >PG(Professional)</asp:ListItem>
                </asp:DropDownList>   
                </td>
                </tr>
           </table>
        </asp:Panel>
         <asp:Panel ID="pnlApplicantIncome" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantIncome" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApplicantIncome" runat="server" Text="Applicant Income"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtApplicantIncome" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
      <asp:Panel ID="pnlNoOfYrsAtPrevEmployment" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrsAtPrevEmployment" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfYrsAtPrevEmployment" runat="server" Text="No of yrs at previous employment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrsAtPrevEmployment" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
       <asp:Panel ID="pnlLoanCancellation" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblLoanCancellation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLoanCancellation" runat="server" Text="Loan Cancellation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtLoanCancellation" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlAnyCreditCard" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAnyCreditCard" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAnyCreditCard" runat="server" Text="Any Credit card"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAnyCreditCard" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>                
                </td>
                </tr>
           </table>
        </asp:Panel>
       <asp:Panel ID="pnlAnyOtherLoan" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOtherLoan" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Any other Loan"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAnyOtherLoan" runat="server" MaxLength="100"></asp:TextBox>                              
                </td>
                </tr>
           </table>
        </asp:Panel>        
        <asp:Panel ID="pnlAssets" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAssets" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAssets" runat="server" Text="Assets"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList SkinID="chkListSkin" ID="chkAssets" runat="server" RepeatDirection="Horizontal" 
                 RepeatColumns="8" AutoPostBack="false">
                        <asp:ListItem>Fax</asp:ListItem>
                        <asp:ListItem>Photo Stat</asp:ListItem>
                        <asp:ListItem>Telephone</asp:ListItem>            
                        <asp:ListItem>A/C</asp:ListItem>
                        <asp:ListItem>Computer</asp:ListItem>                        
                        <asp:ListItem>Printer</asp:ListItem>
                        <asp:ListItem>Xerox</asp:ListItem>
                        <asp:ListItem>Cabins</asp:ListItem>
                        <asp:ListItem>Table</asp:ListItem>
                        <asp:ListItem>Stock</asp:ListItem>
                        <asp:ListItem>Stock shelf</asp:ListItem>
                        <asp:ListItem>Business counter</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:CheckBoxList>  
                </td>
                </tr>
                <tr>
                <td class="TDWidth">If Other(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherAssets" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlDetailsOfFurniture" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDetailsOfFurniture" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblDetailsOfFurniture" runat="server" Text="Details of furniture seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsOfFurniture" runat="server" MaxLength="100"></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlOwnership" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOwnership" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOwnership" runat="server" Text="Ownership"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnership" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Self Owned</asp:ListItem>
                        <asp:ListItem>Family Owned</asp:ListItem>            
                        <asp:ListItem>Partnership</asp:ListItem>            
                        <asp:ListItem>Other</asp:ListItem>            
                    </asp:DropDownList>                
                </td>
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherOwnership" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlLocationOfOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblLocationOfOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocationOfOffice" runat="server" Text="Location of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLocationOfOffice" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlApproachToOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblApproachToOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApproachToOffice" runat="server" Text="Approach to office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtApproachToOffice" runat="server" MaxLength="50"></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlAreaAroundOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAreaAroundOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAreaAroundOffice" runat="server" Text="Area around office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAreaAroundOffice" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>       
        <asp:Panel ID="pnlOfficeAmbience" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAmbience" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeAmbience" runat="server" Text="Office Ambience"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOfficeAmbience" runat="server" MaxLength="100"></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlOfficeOCL" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeOCL" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeOCL" runat="server" Text="Office OCL"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeOCL" runat="server" MaxLength="50"></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlExteriorCondition" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExteriorCondition" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblExterior" runat="server"  Text="Exterior Conditions" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlExteriorCondition" runat="server"   AutoPostBack="false">                                        
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>
                        <asp:ListItem>Average</asp:ListItem>
                        <asp:ListItem>Poor</asp:ListItem>                                                            
                        <asp:ListItem>Plastered</asp:ListItem>
                        <asp:ListItem>Brick wall</asp:ListItem>
                        <asp:ListItem>Mud/Thatched wall</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
         <asp:Panel ID="pnlInteriorCondition" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblInteriorCondition" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label ID="lblInteriorCondition" runat="server"  Text="Interior Condition" SkinID="lblSkin"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>                    
                <asp:DropDownList ID="ddlInteriorCondition" runat="server" SkinID="ddlSkin"  AutoPostBack="false">                    
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Fair</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Painted</asp:ListItem>
                    <asp:ListItem>Carpeted</asp:ListItem>
                    <asp:ListItem>Curtains/Blinds</asp:ListItem>                    
                    <asp:ListItem>Clean</asp:ListItem>    
                    <asp:ListItem>Painted</asp:ListItem>   
                    <asp:ListItem>Unpainted</asp:ListItem>   
                    <asp:ListItem>Plastered</asp:ListItem>   
                    <asp:ListItem>Unplastered</asp:ListItem> 
            </asp:DropDownList>
            </td>
            </tr>        
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlCompanyNameBoardSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyNameBoardSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCompanyNameBoardSeen" runat="server" Text="Company Name board seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlCompanyNameBoardSeen" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOtherCompanyNameBoardSeen" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
        <asp:Panel ID="pnlIsAddOfAppSame" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsAddOfAppSame" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsAddOfAppSame" runat="server" Text="Is the address of Applicant Same?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsAddOfAppSame" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
         <asp:Panel ID="pnlNoOfMember" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfMember" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfMember" runat="server" Text="No. of Members"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfMember" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlNoOfYrsAtCurrentOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrsAtCurrentOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfYrsAtCurrentOffice" runat="server" Text="No. of years at current office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrsAtCurrentOffice" runat="server" MaxLength="50"></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlAgeOfApplicant" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAgeOfApplicant" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAgeOfApplicant" runat="server" Text="Age of Applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtAgeOfApplicant" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlNameAddressOfThirdParty" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNameAddressOfThirdParty" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameAddressOfThirdParty" runat="server" Text="Name & address of third party"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameAddressOfThirdParty" runat="server" MaxLength="255" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlTimeWhenAppIsInOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTimeWhenAppIsInOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTimeWhenAppIsInOffice" runat="server" Text="Time when applicant is in office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtTimeWhenAppIsInOffice" runat="server" MaxLength="50" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
       <asp:Panel ID="pnlThirdPartyComment" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyComment" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblThirdPartyComment" runat="server" Text="Third party Comment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('third party comment', this, 255);"  ID="txtThirdPartyComment" runat="server" MaxLength="255" ></asp:TextBox>                
                </td>
                </tr>
           </table>
        </asp:Panel>
       <asp:Panel ID="pnlIsNegativeArea" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsNegativeArea" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsNegativeArea" runat="server" Text="Is it a Negative Area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsNegativeArea" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
        <asp:Panel ID="pnlIsAffilatedToPoliticalParty" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsAffilatedToPoliticalParty" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsAffilatedToPoliticalParty" runat="server" Text="Is he affilated to any political party"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsAffilatedToPoliticalParty" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel> 
         <asp:Panel ID="pnlIsBlackArea" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsBlackArea" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsBlackArea" runat="server" Text="Is it a Black area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsBlackArea" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>       
        <asp:Panel ID="pnlProfile" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProfile" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProfile" runat="server"  MaxLength="100"></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlAgencyRecommandation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAgencyRecommandation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAgencyRecommandation" runat="server" Text="Agency Recommandation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAgencyRecommandation" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>            
                        <asp:ListItem>Referred</asp:ListItem>            
                        <asp:ListItem>Recommended</asp:ListItem>            
                        <asp:ListItem>Non-recommended</asp:ListItem>            
                        <asp:ListItem>Neutral</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
        <asp:Panel ID="pnlScoretoolRecomandation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblScoretoolRecomandation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblScoretoolRecomandation" runat="server" Text="Scoretool Recommandation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtScoretoolRecomandation" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
               </table>
         </asp:Panel>
        <asp:Panel ID="pnlNeighbourName1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourName1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourName1" runat="server" Text="Name of Neighbour1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNeighbourName1" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlAddOfNeighbour1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddOfNeighbour1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddOfNeighbour1" runat="server" Text="Address of Neighbour"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddOfNeighbour1" runat="server" MaxLength="255"></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
        <asp:Panel ID="pnlDoesApplicantWorkHere1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDoesApplicantWorkHere1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDoesApplicantWorkHere1" runat="server" Text="Does the applicant Work here"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesApplicantWorkHere1" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
        <asp:Panel ID="pnlMthsOfWorkAtOffice1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblMthsOfWorkAtOffice1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMthsOfWorkAtOffice1" runat="server" Text="Months of work at office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtMthsOfWorkAtOffice1" runat="server" MaxLength="10" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIsOfficeSelfOwnNeigh1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsOfficeSelfOwnNeigh1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsOfficeSelfOwnNeigh1" runat="server" Text="Is the office self owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsOfficeSelfOwnNeigh1" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
       <asp:Panel ID="pnlMarketReputation1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblMarketReputation1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMarketReputation1" runat="server" Text="Market Reputation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlMarketReputation1" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>V Good</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>            
                        <asp:ListItem>Fair</asp:ListItem>            
                        <asp:ListItem>Poor</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlNeighbourComments1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourComments1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourComments1" runat="server" Text="Comments of Neighbour"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 255);"  ID="txtNeighbourComments1" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlNeighbourName2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourName2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourName2" runat="server" Text="Name of Neighbour2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNeighbourName2" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlAddOfNeighbour2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddOfNeighbour2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddOfNeighbour2" runat="server" Text="Address of Neighbour"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddOfNeighbour2" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlDoesApplicantWorkHere2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDoesApplicantWorkHere2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDoesApplicantWorkHere2" runat="server" Text="Does the applicant Work here"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesApplicantWorkHere2" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlMthsOfWorkAtOffice2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblMthsOfWorkAtOffice2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMthsOfWorkAtOffice2" runat="server" Text="Months of work at office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtMthsOfWorkAtOffice2" runat="server" MaxLength="10" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlMarketReputation2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblMarketReputation2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMarketReputation2" runat="server" Text="Market Reputaion"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlMarketReputation2" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>V Good</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>            
                        <asp:ListItem>Fair</asp:ListItem>            
                        <asp:ListItem>Poor</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIsOfficeSelfOwnNeigh2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsOfficeSelfOwnNeigh2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsOfficeSelfOwnNeigh2" runat="server" Text="Is the office self owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsOfficeSelfOwnNeigh2" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
         </asp:Panel>
       <asp:Panel ID="pnlNeighbourComments2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourComments2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourComments2" runat="server" Text="Comments of Neighbour"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 255);" ID="txtNeighbourComments2" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblLocality" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblLocality" runat="server" Text="Locality/Surrounding"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlLocality" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Slum</asp:ListItem>
                        <asp:ListItem>Lower Middle</asp:ListItem> 
                        <asp:ListItem>Upper Class</asp:ListItem>
                        <asp:ListItem>Under developed</asp:ListItem>
                        <asp:ListItem>Middle Class</asp:ListItem>
                        <asp:ListItem>Residencial area</asp:ListItem>
                        <asp:ListItem>Shopping complex</asp:ListItem>
                        <asp:ListItem>Commercial</asp:ListItem>
                        <asp:ListItem>LMC</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>    
                </td>
                </tr>
                 <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherLocality" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlAccessibility" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAccessibility" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAccessibility" runat="server" Text="Accessibility"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlAccessibility" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>By All Means</asp:ListItem>
                        <asp:ListItem>By Two wheeler only</asp:ListItem>
                        <asp:ListItem>By Foot only</asp:ListItem>
                    </asp:DropDownList>    
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlBusinesBoardSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinesBoardSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBusinesBoardSeen" runat="server" Text="Business board sigghted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinesBoardSeen" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlEntryPermitted" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEntryPermitted" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEntryPermitted" runat="server" Text="Entry Permitted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEntryPermitted" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlApproxArea" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblApproxArea" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server" Text="Apporx Area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtApproxArea" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
         </asp:Panel>
         <asp:Panel ID="pnlBriefJobResponsibility" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblBriefJobResponsibility" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBriefJobResponsibility" runat="server" Text="Brief Job Responsibilities"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBriefJobResponsibility" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlBehavourOfPersonContacted" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblBehavourOfPersonContacted" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBehavourOfPersonContacted" runat="server" Text="Behavour of person contacted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList ID="ddlBehavourOfPersonContacted" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Polite</asp:ListItem>
                        <asp:ListItem>Rute</asp:ListItem>
                        <asp:ListItem>Doubtful</asp:ListItem>                                                   
                    </asp:DropDownList>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlColourOfDoor" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblColourOfDoor" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblColourOfDoor" runat="server" Text="Colour of Door"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtColourOfDoor" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlTypeOfIndustry" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfIndustry" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfIndustry" runat="server" Text="Type of Industry"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfIndustry" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Huf</asp:ListItem>
                        <asp:ListItem>Partnership</asp:ListItem>            
                        <asp:ListItem>Propritorship</asp:ListItem>            
                        <asp:ListItem>Pvt Ltd</asp:ListItem>                                              
                        <asp:ListItem>PSU</asp:ListItem>   
                        <asp:ListItem>Govt.</asp:ListItem>            
                        <asp:ListItem>MNC</asp:ListItem>  
                        <asp:ListItem>Public Ltd</asp:ListItem>  
                        <asp:ListItem>Other</asp:ListItem>  
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherTypeOfIndustry" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNatureOfBusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNatureOfBusiness" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlNatureOfBusiness" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Manufacturing</asp:ListItem>
                        <asp:ListItem>Software</asp:ListItem>            
                        <asp:ListItem>Trading</asp:ListItem>            
                        <asp:ListItem>BPO</asp:ListItem>            
                        <asp:ListItem>Services</asp:ListItem>            
                        <asp:ListItem>Other</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOtherNatureOfBusiness" runat="server" MaxLength="100" Width="80%" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoOfBranches" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfBranches" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfBranches" runat="server" Text="No. of Branches"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtNoOfBranches" runat="server"  MaxLength="50"></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlNoOfCustomerPerDay" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfCustomerPerDay" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfCustomerPerDay" runat="server" Text="No of customer/day"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtNoOfCustomerPerDay" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIfDoctors" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfDoctors" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfDoctors" runat="server" Text="If Doctors"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfDoctors" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoOfPatientsPerDay" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfPatientsPerDay" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfPatientsPerDay" runat="server" Text="No of Patients per day"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtNoOfPatientsPerDay" runat="server" MaxLength="10" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlAvgFeesPerPatients" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAvgFeesPerPatients" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAvgFeesPerPatients" runat="server" Text="Avg. fees per patient"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtAvgFeesPerPatients" runat="server" MaxLength="10" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIfOtherClinicVisited" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherClinicVisited" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherClinicVisited" runat="server" Text="Other Clinic Visited"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfOtherClinicVisited" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
       <asp:Panel ID="pnlNameOfClinicVisted" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfClinicVisted" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOfClinicVisted" runat="server" Text="If Yes, Name of the clinic visited"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfClinicVisted" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIfArchitectureCA" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfArchitectureCA" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfArchitectureCA" runat="server" Text="If Architecture/CA"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfArchitectureCA" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
       <asp:Panel ID="pnlIndependentlyYrs" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIndependentlyYrs" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIndependentlyYrs" runat="server" Text="Independently (Yrs)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtIndependentlyYrs" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlKeyClientName1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblKeyClientName1" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName1" runat="server" Text="Key Clients name(1)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtKeyClientName1" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlKeyClientName2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblKeyClientName2" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName2" runat="server" Text="Key Clients name(2)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtKeyClientName2" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlKeyClientName3" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblKeyClientName3" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName3" runat="server" Text="Key Clients name(3)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtKeyClientName3" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
           
           
       <asp:Panel ID="pnlOfficeName" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeName" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeName" runat="server" Text="Office Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOfficeName" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlOfficeAddress" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAddress" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeAddress" runat="server" Text="Office Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOfficeAddress" runat="server" MaxLength="100"></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlTypeOfBusinessActivity" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfBusinessActivity" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfBusinessActivity" runat="server" Text="Type of Business Activity"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtTypeOfBusinessActivity" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlEntraceMotorable" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEntraceMotorable" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEntraceMotorable" runat="server" Text="Entrance Motorable"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEntraceMotorable" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
       <asp:Panel ID="pnlRelationWithApplicant" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblRelationWithApplicant" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblRelationWithApplicant" runat="server" Text="Relationship with applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationWithApplicant" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIdentityProof" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIdentityProof" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIdentityProof" runat="server" Text="Identity Proof Seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIdentityProof" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
            </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlTypeOfOrganization" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfOrganization" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfOrganization" runat="server" Text="Type of Organization"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfOrganization" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Govt.</asp:ListItem>
                        <asp:ListItem>PSU</asp:ListItem>            
                        <asp:ListItem>MNC</asp:ListItem>            
                        <asp:ListItem>Pvt. Ltd</asp:ListItem>            
                        <asp:ListItem>Public Ltd.</asp:ListItem>            
                        <asp:ListItem>Propertorship</asp:ListItem> 
                        <asp:ListItem>Partnership</asp:ListItem>           
                        <asp:ListItem>HUF</asp:ListItem>  
                        <asp:ListItem>Others</asp:ListItem>  
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherTypeOfOrganization" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlStatusOfOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblStatusOfOffice" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblStatusOfOffice" runat="server" Text="Status of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlStatusOfOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Industrial</asp:ListItem>
                        <asp:ListItem>Residential</asp:ListItem>            
                        <asp:ListItem>Small Shop / Shed</asp:ListItem>            
                        <asp:ListItem>Business Complex</asp:ListItem>            
                        <asp:ListItem>Underdeveloped</asp:ListItem>            
                        <asp:ListItem>Commercial</asp:ListItem> 
                        <asp:ListItem>Godown</asp:ListItem>           
                        <asp:ListItem>Plant</asp:ListItem>  
                        <asp:ListItem>Independent office</asp:ListItem> 
                        <asp:ListItem>Clinic</asp:ListItem> 
                        <asp:ListItem>Others</asp:ListItem>  
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherStatusOfOffice" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlShiftOfWork" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblShiftOfWork" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblShiftOfWork" runat="server" Text="Shift of work"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlShiftOfWork" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Day</asp:ListItem>
                        <asp:ListItem>Night</asp:ListItem>            
                        <asp:ListItem>General</asp:ListItem>            
                        <asp:ListItem>On Field</asp:ListItem>                                     
                    </asp:DropDownList>
                </td>
            </tr>            
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlBusinessProof" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessProof" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBusinessProof" runat="server" Text="Business Proof seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessProof" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
            </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlResidenceAddress" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceAddress" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtResidenceAddress" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlOtherInvestment" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOtherInvestment" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherInvestment" runat="server" Text="Other Investments"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOtherInvestment" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>FD</asp:ListItem>
                        <asp:ListItem>Shares</asp:ListItem>            
                        <asp:ListItem>Mutual Funds</asp:ListItem>            
                        <asp:ListItem>Jewelry</asp:ListItem>            
                        <asp:ListItem>Real Estate</asp:ListItem>            
                        <asp:ListItem>Others</asp:ListItem>            
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherOtherInvestment" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlVerifierComments" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVerifierComments" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVerifierComments" runat="server" Text="Verifier comments"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="750" onkeyPress="ValidateTextLength('verifier comments', this, 750);"  ID="txtVerifierComments" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlProofOfBusinessActivity" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProofOfBusinessActivity" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProofOfBusinessActivity" runat="server" Text="Proof of Business Activity"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProofOfBusinessActivity" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <table cellpadding="0" cellspacing="0" border="0" id="tblCityLimit" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblCityLimit" runat="server"  Text="City Limit"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin"  ID="ddlCityLimit" runat="server" AutoPostBack="false">
                        <asp:ListItem>ICL</asp:ListItem>
                        <asp:ListItem>OCL</asp:ListItem>
                        <asp:ListItem>Beyound OCL</asp:ListItem>
                     </asp:DropDownList>
    </td>
    </tr>
   </table>                          
       
       <asp:Panel ID="pnlOverallVerification" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblOverallVerification" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOverallVerification" runat="server" Text="Overall Verification"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOverallVerification" runat="server" DataSourceID="sdsCaseStatus"
              DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID" OnDataBound="ddlOverallVerification_DataBound" AutoPostBack="false">
                        
                    </asp:DropDownList>
                    
                </td>
            </tr>            
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlTotalNoOfEmployees" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTotalNoOfEmployees" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTotalNoOfEmployees" runat="server" Text="Total no of Employees"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtTotalNoOfEmployees" runat="server" MaxLength="10" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlReasonNotCollectingVistingCard" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblReasonNotCollectingVistingCard" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonNotCollectingVistingCard" runat="server" Text="Reason for not collecting Visiting card"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtReasonNotCollectingVistingCard" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIsOfficeDoorLocked" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsOfficeDoorLocked" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsOfficeDoorLocked" runat="server" Text="Office Door Locked"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsOfficeDoorLocked" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
       <asp:Panel ID="pnlWhereContacted" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblWhereContacted" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblWhereContacted" runat="server" Text="Where Contacted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtWhereContacted" runat="server" Width="80%" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlSendDate" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSendDate" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSendDate" runat="server" Text="Send Date"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtSendDate" runat="server" ></asp:TextBox> 
                   <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSendDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlNameOfBank" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfBank" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOfBank" runat="server" Text="Name of Bank"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfBank" runat="server" MaxLength="50" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlPrevOccupationDtl" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblPrevOccupationDtl" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPrevOccupationDtl" runat="server" Text="Details of previous occupation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPrevOccupationDtl" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlPrevEmploymentDesgn" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblPrevEmploymentDesgn" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPrevEmploymentDesgn" runat="server" Text="Previous Employment designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPrevEmploymentDesgn" runat="server" MaxLength="100" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlConstructionOfOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblConstructionOfOffice" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConstructionOfOffice" runat="server" Text="Construction of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlConstructionOfOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Pukka</asp:ListItem>
                        <asp:ListItem>Semi-Pukka</asp:ListItem>            
                        <asp:ListItem>Temporary</asp:ListItem>  
                    </asp:DropDownList>
                </td>
            </tr>            
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlEasyOfLocatingOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblEasyOfLocatingOffice" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEasyOfLocatingOffice" runat="server" Text="Easy of Locating Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEasyOfLocatingOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Easy</asp:ListItem>
                        <asp:ListItem>Difficult</asp:ListItem>            
                        <asp:ListItem>Untracable</asp:ListItem>  
                    </asp:DropDownList>
                </td>
            </tr>            
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlNegmatch" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNegmatch" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNegmatch" runat="server" Text="Negmatch"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlNegmatch" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
       
       <asp:Panel ID="pnlReasonForNotRecomdNReferred" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForNotRecomdNReferred" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForNotRecomdNReferred" runat="server" Text="Reason for not recommended & referred"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtReasonForNotRecomdNReferred" runat="server" MaxLength="255" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlIfOCLDistance" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIfOCLDistance" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOCLDistance" runat="server" Text="If OCL Than distance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtIfOCLDistance" runat="server" MaxLength="50"></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
        <asp:Panel ID="pnlAgencyName" runat="server" Width="100%" Visible="false">
            <table id="tblAgencyName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblAgencyName" runat="server" Text="Agency Name"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtAgencyName" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
    <!--Start Additional Fields on 23-Aug-2007-->
    <asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="false">
        <table id="tblLevelOfBusinessActivity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="lblLevelOfBusinessActivity" runat="server" Text="Level of Business Activity"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td>
        <asp:DropDownList ID="ddlLevelOfBusinessActivity" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>High</asp:ListItem>
        <asp:ListItem>Average</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
        </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlIsResiCumOfficeSelfOwned" runat="server" Width="100%" Visible="false">
        <table id="tblIsResiCumOfficeSelfOwned" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="lblIsResiCumOfficeSelfOwned" runat="server" Text="Is the resi cum office self owned"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:DropDownList ID="ddlIsResiCumOfficeSelfOwned" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlStockSeen" runat="server" Width="100%" Visible="false">
        <table id="tblStockSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="lblStockSeen" runat="server" Text="Stock Seen"></asp:Label>
        </td>
        <td style="width:2%"  >:</td>
        <td>
        <asp:DropDownList ID="ddlStockSeen" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>High</asp:ListItem>
        <asp:ListItem>Average</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
        </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlMonthsOfWorkatCurrentOffice" runat="server" Width="100%" Visible="false">
        <table id="tblMonthsOfWorkatCurrentOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="lblMonthsOfWorkatCurrentOffice" runat="server" Text="Months Of Work at Current Office"></asp:Label>
        </td>
        <td style="width:2%"  >:</td>
        <td>
        <asp:TextBox SkinID="txtSkin"   ID="txtMonthsOfWorkatCurrentOffice" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
        </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlPurposeOfLoanTaken" runat="server" Width="100%" Visible="false">
        <table id="tblPurposeOfLoanTaken" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPurposeOfLoanTaken" runat="server" Text="Purpose of loan being taken"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtPurposeOfLoanTaken" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <!--End Additional Fields on 23-Aug-2007-->
    <!--Start Additional Fields on 03-Oct-2007-->    
    <asp:Panel ID="pnlNameOfCollegue" runat="server" Width="100%" Visible="false">
        <table id="tblNameOfCollegue" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOfCollegue" runat="server" Text="Name of Collegue"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtNameOfCollegue" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDesgnDeptOfCollegue" runat="server" Width="100%" Visible="false">
        <table id="tblDesgnDeptOfCollegue" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDesgnDeptOfCollegue" runat="server" Text="Designation / Department of Collegue"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtDesgnDeptOfCollegue" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlMonthofCompExistance" runat="server" Width="100%" Visible="false">
        <table id="tblMonthofCompExistance" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMonthofCompExistance" runat="server" Text="Months of Company's Existance at given address"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtYearOfCompExistance" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Yrs
                &nbsp;
                 <asp:TextBox SkinID="txtSkin"  ID="txtMthOfCompExistance" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Mths
                 </td> 
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlProfileCoAsPerNeighbour" runat="server" Width="100%" Visible="false">
        <table id="TabtblProfileCoAsPerNeighbourle1" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfileCoAsPerNeighbour" runat="server" Text="Profile of Co.as per Neighbour"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtProfileCoAsPerNeighbour" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlAppNameVerifiedFrom" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAppNameVerifiedFrom" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAppNameVerifiedFrom" runat="server" Text="Applicant's name verified from"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAppNameVerifiedFrom" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Colleauge</asp:ListItem>
                    <asp:ListItem>Receptionist</asp:ListItem>
                    <asp:ListItem>Owner</asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>                    
                    <asp:ListItem>Others</asp:ListItem>                    
                </asp:DropDownList>
                </td>  
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOtherAppNameVerifiedFrom" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
     </asp:Panel>
     <asp:Panel ID="pnlSupervisorComments" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorComments" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSupervisorComments" runat="server" Text="Supervisor comments"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="250" onkeyPress="ValidateTextLength('verifier comments', this, 250);"  ID="txtSupervisorComments" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>    
       
       <asp:Panel ID="pnlAttemptsHead" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblpnlAttemptsHead" runat="server" Text="ATTEMPTS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                <asp:Panel ID="pnlAttempts" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAttempts">
                                        <tr>
                                            <td class="TDWidth">
                                                Attempts</td>
                                            <td >
                                                Date</td>
                                            <td>
                                                Time</td>
                                            <td>
                                                Remark</td>
                                                <td>
                                                SubStatus</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                1st Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate1" runat="server" Width="80" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td>
                                                <asp:TextBox ID="txtTime1" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType1" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark1" runat="server"   SkinID="txtSkin"></asp:TextBox></td>
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat1" runat="server" SkinID="ddlSkin">
                                                 <asp:ListItem Text="(Select)" Value="(Select)"></asp:ListItem>
                                                 <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
                                                 <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                                                 <asp:ListItem Text="Untraceble" Value="Untraceble"></asp:ListItem>
                                                 <asp:ListItem Text="Door Lock" Value="Door Lock"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat1" runat="server" Text=""></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                2nd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate2" runat="server" Width="80" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate2" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td>
                                                <asp:TextBox ID="txtTime2" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType2" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark2" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat2" runat="server" SkinID="ddlSkin">
                                                 <asp:ListItem Text="(Select)" Value="(Select)"></asp:ListItem>
                                                 <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
                                                 <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                                                 <asp:ListItem Text="Untraceble" Value="Untraceble"></asp:ListItem>
                                                 <asp:ListItem Text="Door Lock" Value="Door Lock"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat2" runat="server" Text=""></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                3rd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate3" runat="server" Width="80" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate3" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td >
                                                <asp:TextBox ID="txtTime3" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType3" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark3" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat3" runat="server" SkinID="ddlSkin">
                                                 <asp:ListItem Text="(Select)" Value="(Select)"></asp:ListItem>
                                                 <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
                                                 <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                                                 <asp:ListItem Text="Untraceble" Value="Untraceble"></asp:ListItem>
                                                 <asp:ListItem Text="Door Lock" Value="Door Lock"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat3" runat="server" Text=""></asp:Label>
                                        </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
        
     <asp:Panel ID="pnlRoofType" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblRoofType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRoofType" runat="server" Text="Roof Type"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRoofType" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Cemented</asp:ListItem>
                    <asp:ListItem>Tin shed</asp:ListItem>
                    <asp:ListItem>Tiled roof</asp:ListItem>                                   
                </asp:DropDownList>
                </td>  
                </tr>               
          </table>
     </asp:Panel>
            <!-----Added by Manoj Jadhav------------>    
           
        <asp:Panel ID="PnlDifferncesfound" runat="server"  Width="100%" Visible="true">
                <table cellpadding="0" cellspacing="0" border="0" id="tabDifferncesfound" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labDifferncesfound" runat="server"  Text="Differnces found"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDifferncesfound" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            
           <asp:Panel ID="PnlActiontaken" runat="server" Width="100%" Visible="true">
                <table cellpadding="0" cellspacing="0" border="0" id="tabActiontaken" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labActiontaken" runat="server" Text="Action taken"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtActiontaken" runat="server" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
                                
           <asp:Panel ID="PnlNATUREOFDSCREPANCY" runat="server" Width="100%" Visible="true">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNATUREOFDSCREPANCY" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNATUREOFDSCREPANCY" runat="server" Text="NATURE OF DSCREPANCY"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNATUREOFDSCREPANCY" runat="server" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <!-----end by Manoj Jadhav------------>
    <!--End Additional Fields on 03-Oct-2007-->
       <br />
      <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" ValidationGroup="gvValidate" SkinID="btnSubmitSkin" runat="server" Text="Submit" OnClick="btnSubmit_Click" />    
                <asp:Button ID="btnCancel"  runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hidCaseID" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
            <asp:HiddenField ID="hidMode" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
            <asp:HiddenField ID="hidVerifierID" runat="server" />
      </asp:Panel>
      
       </asp:TableCell></asp:TableRow>
                    </asp:Table>
       <asp:CustomValidator ID="cvOverallVerification" runat="server" 
                   ErrorMessage="Please select Overall Verification." ValidationGroup="gvValidate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlOverallVerification" OnServerValidate="cvSelectddlOverallVerification_ServerValidate">
       </asp:CustomValidator>  
                      
     <asp:CustomValidator ID="cvVerificationDate" runat="server" ControlToValidate="txtDateOfVerification"
             Display="None" ErrorMessage="Enter verification time." 
             ValidationGroup="gvValidate" ClientValidationFunction="ValidateVerificationTime"></asp:CustomValidator>               
     <asp:CustomValidator ID="cvVerificationTime" runat="server" ControlToValidate="txtTimeOfVerification"
             Display="None" ErrorMessage="Enter verification date." 
             ValidationGroup="gvValidate" ClientValidationFunction="ValidateVerificationDate"></asp:CustomValidator>  
      
     <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtDateOfVerification"
                    Display="None" ErrorMessage="Please enter valid date format for verification."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="gvValidate"></asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="revVerificationTime" runat="server" ControlToValidate="txtTimeOfVerification"
                    Display="None" ErrorMessage="Please enter valid time format for verification."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="gvValidate">  </asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="gvValidate" ShowMessageBox="True" ShowSummary="False" /> 
    </td>
</tr>
<tr><td></td><td>
<asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
        </asp:SqlDataSource>
</td><td></td></tr>
</table>
 <asp:HiddenField ID="hdnTransStart" runat="server" />
    <asp:SqlDataSource ID="sdsFE" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
    <td><asp:LinkButton ID="lbREF1" runat="server" Text="REF1" Width="22px" Visible="False" OnClick="lbREF1_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbREF2" runat="server" Text="REF2" Width="22px" Visible="False" OnClick="lbREF2_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbRCO" runat="server" Text="RCO" Width="22px" Visible="False" OnClick="lbRCO_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    
    </tr>
    
    </table>
</fieldset>
    </td></tr></table>
</asp:Content>

