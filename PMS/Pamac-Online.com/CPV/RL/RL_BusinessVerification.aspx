<%@ Page Language="C#" MasterPageFile="RL_MasterPage.master" AutoEventWireup="true" CodeFile="RL_BusinessVerification.aspx.cs" Inherits="RL_BusinessVerification" Theme="SkinFile" %>
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
          //alert(arguments.Value);Quadra InfoTech
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
                    <asp:PlaceHolder ID="PlaceHolder151" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder152" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder153" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder154" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder155" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder156" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder157" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder158" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder159" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder160" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder161" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder162" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder163" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder164" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder165" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder166" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder167" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder168" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder169" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder170" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder171" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder172" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder173" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder174" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder175" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder176" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder177" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder178" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder179" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder180" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder181" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder182" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder183" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder184" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder185" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder186" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder187" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder188" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder189" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder190" runat="server" EnableViewState="false"></asp:PlaceHolder>
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
                <asp:Label SkinID="lblSkin" ID="llLanNo" runat="server" Text="Lan No / Ref. No."></asp:Label>
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
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPersonMet" runat="server" MaxLength="500"></asp:TextBox>                
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
                <asp:TextBox SkinID="txtSkin"  ID="txtPersonMetDesgn" runat="server" MaxLength="100" Width="80%" ></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>  
     <asp:Panel ID="pnlAppConfirm" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAppConfirm" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAppConfirm" runat="server" Text="Person contacted at office telephone confirms that applicant worked at given address(Yes/No)"></asp:Label>
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
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBusinessName" runat="server" MaxLength="500" ></asp:TextBox>                
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
        <tr><td colspan="3" align="center">
        <asp:Label ID="Label14" runat="server" SkinID="lblSkin" Text="FOR SALARIED ONLY"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAppDesgn" runat="server" Text="Designation of the Applicant"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtAppDesgn" runat="server" MaxLength="100"  Width="80%" ></asp:TextBox>                
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
                <%--<asp:TextBox SkinID="txtSkin"  ID="txtNumberOfEmployee" runat="server" MaxLength="50" ></asp:TextBox>--%>
                <asp:DropDownList ID="ddlNumberOfEmployee" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem><5</asp:ListItem>
                            <asp:ListItem>5-10</asp:ListItem>
                            <asp:ListItem>11-15</asp:ListItem>
                            <asp:ListItem>16-20</asp:ListItem>
                            <asp:ListItem>20-50</asp:ListItem>
                            <asp:ListItem>>50</asp:ListItem>
                 <asp:ListItem>others</asp:ListItem>
                </asp:DropDownList>                
            </td>
            </tr>
               <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="Label109" runat="server" Text="If Other (Ple.Specify)"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtotherNumberOfEmployee" runat="server" MaxLength="50" ></asp:TextBox>
                             
            </td>
            </tr>
            </table>    
     </asp:Panel>
     
     <%--add by santosh shelar as per new requirmet--%>
     <asp:Panel ID="pnlResiStatus" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResiStatus" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResiStatus" runat="server" Text="Residence Status :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResiStatus" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Self owned</asp:ListItem>
                        <asp:ListItem>Parent owned</asp:ListItem>            
                        <asp:ListItem>Company Leased</asp:ListItem>
                        <asp:ListItem>Rented</asp:ListItem>            
                        <asp:ListItem>Govt allotment</asp:ListItem>            
                        <asp:ListItem>Finance Co</asp:ListItem>            
                        <asp:ListItem>Other</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                 <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblFinanceBank" runat="server" Text="If Financed,name of bank"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtFinanceBank" runat="server"></asp:TextBox>
                    </td>          
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="pnlOutstanding" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOutstanding" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOutstanding" runat="server" Text="Outstanding if any :"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOutstanding" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>     
     <asp:Panel ID="pnlFamilyMember" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFamilyMember" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblFamilyMember" runat="server" Text="Family Member :"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFamilyMember" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlSignSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSignSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSignSeen" runat="server" Text="Signage / SecurityGuard Seen "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSignSeen" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
      <asp:Panel ID="pnlWorkExp" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblWorkExp" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblWorkExp" runat="server" Text="Total Work Experiance"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtWorkExp" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlOrgCov" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOrgCov" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOrgCov" runat="server" Text="Is the Organization covered under PF / ESI :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOrgCov" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="pnlOemfName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOemfName" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOemfName" runat="server" Text="Name(Other Earning member):"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOemfName" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlOemfRelation" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOemfRelation" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOemfRelation" runat="server" Text="Relation(Other Earning member):"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOemfRelation" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlOemfOccu" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOemfOccu" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOemfOccu" runat="server" Text="Occupation(Other Earning member):"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOemfOccu" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlOemfIncome" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOemfIncome" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOemfIncome" runat="server" Text="Income(Other Earning member):"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOemfIncome" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlDependent" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDependent" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDependent" runat="server" Text="Dependents :"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDependent" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlTwoWh" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTwoWh" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblTwoWh" runat="server" Text="Two wheeler details :"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtTwoWh" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlFourWh" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFourWh" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblFourWh" runat="server" Text="Four wheeler details :"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFourWh" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     
      <asp:Panel ID="pnlSalary" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSalary" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblSalary" runat="server" Text="Salary Details- P/M-P/A"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSalary" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
    <asp:Panel ID="pnlNamePerson2" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNamePerson2" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblNamePerson2" runat="server" Text="Name of person met(2):"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNamePerson2" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlRelantionApp2" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRelantionApp2" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblRelantionApp2" runat="server" Text="Relationship with applicant(2):"></asp:Label><asp:Label ID="Label48" runat="server"> <span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>

            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelantionApp2" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlForm16" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblForm16" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblForm16" runat="server" Text="Form 16 / PF statement"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtForm16" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
      <asp:Panel ID="pnlProfileConfIssu" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProfileConfIssu" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfileConfIssu" runat="server" Text="The profile / Financials confirmed by the issuer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlProfileConfIssu" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="pnlProfileConfColle" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProfileConfColle" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfileConfColle" runat="server" Text="The profile / Financials confirmed by the Colleague"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlProfileConfColle" runat="server" AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
   <%--  new added--%>
                             
                                  <asp:Panel ID="Pnlproductdealingin" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table88" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label107" runat="server" Text="Product Dealing in  :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtproductdealingin" runat="server" MaxLength="50" Width="488px" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>  
   <%--comp--%>
     <asp:Panel ID="pnlInfoProvide" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblInfoProvide" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblInfoProvide" runat="server" Text="Information provided in the profile"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtInfoProvide" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlCustAppPrev" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCustAppPrev" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCustAppPrev" runat="server" Text="Did the customer apply previously:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlCustAppPrev" runat="server" AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="pnlDatePrev" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDatePrev" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDatePrev" runat="server" Text="Date of Previous FI:"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDatePrev" runat="server"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     <asp:Panel ID="pnlOffDeci" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOffDeci" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOffDeci" runat="server" Text="CAU officers decision:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOffDeci" runat="server" AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Declined</asp:ListItem>            
                        <asp:ListItem>Hold to discuss</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     
    <asp:Panel ID="pnlCustomerSeen" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblCustomerSeen" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblCustomerSeen" runat="server" Text="Number of Customer Seen"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <%--<asp:TextBox SkinID="txtSkin"  ID="txtCustomerSeen" runat="server" MaxLength="50" ></asp:TextBox>--%>  
                <asp:DropDownList ID="ddlCustomerSeen" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem><5</asp:ListItem>
                            <asp:ListItem>5-10</asp:ListItem>
                            <asp:ListItem>11-15</asp:ListItem>
                            <asp:ListItem>16-20</asp:ListItem>
                            <asp:ListItem>20-50</asp:ListItem>
                            <asp:ListItem>>50</asp:ListItem>
                </asp:DropDownList>              
            </td>
            </tr>
            </table>    
     </asp:Panel>
     
      <asp:Panel ID="pnlTypeJob" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeJob" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeJob" runat="server" Text="Type of Job"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeJob" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Permanent</asp:ListItem>
                        <asp:ListItem>Contract worker</asp:ListItem>            
                        <asp:ListItem>Probation</asp:ListItem>
                        <asp:ListItem>Temporary worker</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlAplliWork" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAplliWork" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAplliWork" runat="server" Text="Applicant Working As:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAplliWork" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Assistant</asp:ListItem>
                        <asp:ListItem>Skilled labour</asp:ListItem>            
                        <asp:ListItem>Junior management</asp:ListItem>
                        <asp:ListItem>Clerk</asp:ListItem>            
                        <asp:ListItem>Typist</asp:ListItem>
                        <asp:ListItem>Peon/Office boy</asp:ListItem>            
                        <asp:ListItem>Stenographer</asp:ListItem>
                        <asp:ListItem>Supervisor</asp:ListItem>            
                        <asp:ListItem>Senior/middle mgmt</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlAppliJobTrans" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppliJobTrans" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppliJobTrans" runat="server" Text="Applicant Job Transferable"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAppliJobTrans" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlOffExit" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOffExit" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOffExit" runat="server" Text="Knows company and confirms office existence:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOffExit" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
     <asp:Panel ID="pnlVehiOwn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVehiOwn" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblVehiOwn" runat="server" Text="Vehicles owned/Make:"></asp:Label><asp:Label ID="Label49" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>

            </td><td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtVehiOwn" runat="server" MaxLength="100"></asp:TextBox>                
            </td>
            </tr>
            </table>    
     
     </asp:Panel> 
         <asp:Panel ID="pnlBussPrem" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBussPrem" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBussPrem" runat="server" Text="Business Premises:"></asp:Label><asp:Label ID="Label50" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlBussPrem" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Self owned</asp:ListItem>
                        <asp:ListItem>Family owned</asp:ListItem>            
                        <asp:ListItem>Friend owned</asp:ListItem>            
                        <asp:ListItem>Rented</asp:ListItem>            
                        <asp:ListItem>Company leased</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppType" runat="server" Width="100%" Visible="false">
                                    <table id="tblAppType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                    <tr>
                                    <td class="TDWidth" >
                                    <asp:Label SkinID="lblSkin" ID="lblAppType" runat="server" Text="Applicant Type"></asp:Label>
                                    </td>
                                    <td style="width:2%">:</td>
                                    <td>
                                    <asp:DropDownList ID="ddlAppType" SkinID="ddlSkin" Enabled="false" runat="server">
                                            <asp:ListItem>Applicant</asp:ListItem>
                                            <asp:ListItem>Co-Applicant</asp:ListItem>
                                            <asp:ListItem>Guarantor</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
        <asp:Panel ID="pnlRefName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRefName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRefName" runat="server" Text="Name of referance no 1"></asp:Label><asp:Label ID="Label54" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRefName" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>    
      <asp:Panel ID="pnlRefAdd" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRefAdd" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRefAdd" runat="server" Text="Address of referance no 1"></asp:Label><asp:Label ID="Label55" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRefAdd" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>    
      <asp:Panel ID="pnlMonthTurnover" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMonthTurnover" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMonthTurnover" runat="server" Text="Average Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtMonthTurnover" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>    
      <asp:Panel ID="pnlNumberBeds" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNumberBeds" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNumberBeds" runat="server" Text="Number of beds(if nursing home):"></asp:Label><asp:Label ID="Label61" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNumberBeds" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>    
      <asp:Panel ID="pnlNeighChek" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNeighChek" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNeighChek" runat="server" Text="Neighbourthood check with closest chemist:(name and address):"></asp:Label><asp:Label ID="Label62" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNeighChek" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>     
      <asp:Panel ID="pnlNeighbourCheckedBy" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourCheckedBy" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblNeighbourCheckedBy" runat="server" Text="Neighbourhood checked by"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNeighbourCheckedBy" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
       <asp:Panel ID="pnlClinicYear" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblClinicYear" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblClinicYear" runat="server" Text="How long has the clinic been existing:"></asp:Label><asp:Label ID="Label63" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtClinicYear" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>   
      
      <asp:Panel ID="pnlDetailsOfWorkingMembersSpouse" runat="server" Width="100%" Visible="false">
            <table id="tblDetailsOfWorkingMembersSpouse" cellpadding="0" cellspacing="0" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label8" runat="server" Text="Is spouse working"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:DropDownList ID="ddlSpouseWork" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblDetailsOfWorkingMembersSpouse" runat="server"
                            Text="Details Of Working Members (Spouse)"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsOfWorkingMembersSpouse" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label10" runat="server" Text="Spouse Address"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSpouseAdd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label9" runat="server" Text="Spouse Designation"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSpouseDesg" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
      
      <asp:Panel ID="pnlSeparateResi" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateResi" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateResi" runat="server" Text="If residence cum office, then separate office area?"></asp:Label><asp:Label ID="Label69" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateResi" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <!--Update by MAnoj-->
                <tr>
                   <td class="TDWidth">
                           <asp:Label SkinID="lblSkin" ID="Label25" runat="server" Text="If YES Primises Distinct"></asp:Label>
                   </td>
                   <td style="width: 2%">
                           :</td>
                   <td>
                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPrimisesRem" runat="server"></asp:TextBox>
                   </td>
              </tr>
               <!--Update by MAnoj-->
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlSeparateFactory" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateFactory" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateFactory" runat="server" Text="Is there a separate factory?"></asp:Label><asp:Label ID="Label70" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateFactory" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSeparateEntrance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateEntrance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateEntrance" runat="server" Text="Separate entrances seen to office and residence?"></asp:Label><asp:Label ID="Label71" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateEntrance" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSeparateOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateOffice" runat="server" Text="Was there a separate office earlier OR Setup relevant to business?"></asp:Label><asp:Label ID="Label72" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                    <asp:Label SkinID="lblSkin" ID="lblSeparateOffice1" runat="server" Text="If No, please explain/Estimate rent"></asp:Label>
                   <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtSeparateOffice" runat="server"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlOfficeLimit" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeLimit" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeLimit" runat="server" Text="Office within city limits:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeLimit" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
        <asp:Panel ID="pnlNoDoctor" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoDoctor" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoDoctor" runat="server" Text="No. of Doctors working in the Hospital"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoDoctor" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
        <asp:Panel ID="pnlGrossReceipt" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblGrossReceipt" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblGrossReceipt" runat="server" Text="Daily Gross Receipts (Approximately)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtGrossReceipt" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
      <asp:Panel ID="pnlMedicalShop" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMedicalShop" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMedicalShop" runat="server" Text="Whether own medical shop in the Hospital or rented out of Third Party"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtMedicalShop" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
            <asp:Panel ID="pnlAmtRent" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAmtRent" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAmtRent" runat="server" Text="If rented out to third party then mention the amount of rent received"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAmtRent" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlNameHospital" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNameHospital" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameHospital" runat="server" Text="Whether the applicant provides visit to some other hospital's, If yes the mention the name of such Hospital "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameHospital" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlNameMachine" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNameMachine" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameMachine" runat="server" Text="Name the machine install the in the Hospital"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameMachine" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlAuditTax" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAuditTax" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAuditTax" runat="server" Text="Mention major services rendered like Audit Taxations etc"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAuditTax" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlNoOfTax" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfTax" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfTax" runat="server" Text="No. of tax audits done in the last year"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoOfTax" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlGrossMonthReceipt" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblGrossMonthReceipt" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblGrossMonthReceipt" runat="server" Text="Gross Monthly Receipts (Average)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtGrossMonthReceipt" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  

<asp:Panel ID="pnlNoOperation" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOperation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOperation" runat="server" Text="No of Years in Operations"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoOperation" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlSoleOwner" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSoleOwner" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSoleOwner" runat="server" Text="Whether Sole owner or Joint owner of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSoleOwner" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlAmtInvt" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAmtInvt" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAmtInvt" runat="server" Text="Amount of Investment in stocks and Assets/Where will the asset be located"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAmtInvt" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlBussPremises" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBussPremises" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBussPremises" runat="server" Text="Whether business premises is rented or owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBussPremises" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlFixAss" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFixAss" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblFixAss" runat="server" Text="Name the fixed Assets used for Business Purpose/For whom is the asset being purchased"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFixAss" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlBussManuf" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBussManuf" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBussManuf" runat="server" Text="Nature of Business Manufaturing or Trading mention the items manufatured or traded as the case may be."></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBussManuf" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlRegiSale" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRegiSale" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRegiSale" runat="server" Text="Whether Registered in Sales Tax / PF Excise, If yes give details of registration"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRegiSale" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlMajorClient" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMajorClient" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMajorClient" runat="server" Text="Major clients Name (Minimum 5) clients name to be mentioned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtMajorClient" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlAvgProfit" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAvgProfit" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAvgProfit" runat="server" Text="Last 3 years Average Profit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAvgProfit" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlAvgSale" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAvgSale" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAvgSale" runat="server" Text="Last 3 years Average Sale"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAvgSale" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  
<asp:Panel ID="pnlSourceIncome" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSourceIncome" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSourceIncome" runat="server" Text="Any other Source of Income"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSourceIncome" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>  


    <%--End code--%>
    
     
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
                    <asp:ListItem>Comm complex</asp:ListItem>
                    <asp:ListItem>Shared Office</asp:ListItem>
                    <asp:ListItem>Clinic</asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Undeveloped</asp:ListItem>
                    <asp:ListItem>Showroom</asp:ListItem>
                    <asp:ListItem>Multi Stored</asp:ListItem>
                    <asp:ListItem>Single Stored</asp:ListItem>
                    <asp:ListItem>Applican’t Co–owned  Building</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>                    
                </asp:DropDownList>
                </td>  
                </tr>
                <tr>
                <td class="TDWidth">If Others(Pls.Specify)</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOtherOfficeType" runat="server" MaxLength="50"  Width="80%" ></asp:TextBox>
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
                <%--<asp:TextBox SkinID="txtSkin"  ID="txtLocatingOffice" runat="server" MaxLength="100"></asp:TextBox>--%>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
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
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem> 
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>   
                    <asp:ListItem>Low</asp:ListItem>   
                    <asp:ListItem>IDLE</asp:ListItem>            
                    <asp:ListItem>No Activity</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>                        
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>bussy</asp:ListItem>
                    <asp:ListItem>brisk</asp:ListItem>           
                </asp:DropDownList>
                </td>
                </tr>
                </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlLandmark" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark / Street Name"></asp:Label>
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
                <asp:Label SkinID="lblSkin" ID="lblRemarks" runat="server" Text="Remarks"></asp:Label><asp:Label ID="Label73" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('Remarks', this, 2000);"  ID="txtRemarks" runat="server" MaxLength="2000" ></asp:TextBox>
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
                                 <asp:ListItem>Sstisfactory</asp:ListItem>
                                     <asp:ListItem>UnSstisfactory</asp:ListItem>
                                                 
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
                <asp:Label SkinID="lblSkin" ID="lblNameOfBankDefaultWith" runat="server" Text="If Yes Name of the bank defaulted with"></asp:Label><asp:Label ID="Label53" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  Width="80%"  ID="txtNameOfBankDefaultWith" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      
      
       <asp:Panel ID="pnlNegProduct" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblIfNegProduct" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblIfNegProduct" runat="server" Text="Product "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtIfNegProduct" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      <asp:Panel ID="pnlProductName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblProductName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblProductName" runat="server" Text="Name of the Product/Finance Company"></asp:Label>
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
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDefaultInWhichBucket" runat="server" MaxLength="100" ></asp:TextBox>
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
                <asp:TextBox SkinID="txtSkin"  ID="txtAmountOfDefaultINR" runat="server"></asp:TextBox>
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
                <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label12" runat="server" Text="Fax No" Visible="false"></asp:Label>
                </td><%--<td style="width:2%">:</td>--%>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtFaxNo" runat="server" MaxLength="100" Visible="false"></asp:TextBox>                
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
                     <asp:ListItem >UnderGrad</asp:ListItem>
                    <asp:ListItem >Grad(General)</asp:ListItem>
                    <asp:ListItem >Grad(Professional)</asp:ListItem>   
                    <asp:ListItem >Some College</asp:ListItem>
                    <asp:ListItem >SSC/MSC</asp:ListItem>
                    <asp:ListItem >PG(General)</asp:ListItem>
                    <asp:ListItem >PG(Professional)</asp:ListItem>
                    <asp:ListItem >Other</asp:ListItem>
                </asp:DropDownList>   
                </td>
                </tr>
                  <tr>
                           <td class="TDWidth">
                                   If Others(Pls.Specify)</td>
                                   <td style="width: 2%">
                                   :</td>
                                   <td>
                                   <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtEducationBackgroud" runat="server"></asp:TextBox>
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
                        <asp:ListItem>PhotoStat</asp:ListItem>
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
                        <asp:ListItem>Machinery</asp:ListItem>
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
                        <asp:ListItem>Pagdi</asp:ListItem>   
                        <asp:ListItem>Rented</asp:ListItem>   
                        <asp:ListItem>LEASED</asp:ListItem>    
                        <%--Added for SBI--%>
                        <asp:ListItem>Company Owned</asp:ListItem>   
                         <%--END for SBI--%>
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
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLocationOfOffice" runat="server" MaxLength="500" ></asp:TextBox>                
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
                <asp:Label SkinID="lblSkin" ID="lblAreaAroundOffice" runat="server" Text="Area around office OR Which area"></asp:Label>
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
                <asp:Label SkinID="lblSkin" ID="lblOfficeAmbience" runat="server" Text="Office Ambience / Setup"></asp:Label>
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
                        <asp:ListItem>Excellent</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>
                        <asp:ListItem>Average</asp:ListItem>
                        <asp:ListItem>Poor</asp:ListItem>                                                            
                        <asp:ListItem>Plastered</asp:ListItem>
                        <asp:ListItem>Brick wall</asp:ListItem>
                        <asp:ListItem>Mud/Thatched wall</asp:ListItem>
                        <asp:ListItem>Satisfactory</asp:ListItem>
                        <asp:ListItem>Bad</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
             <!---Added by kamal matekar for fedfina Finance------>
      <asp:Panel ID="pnlMainlineBusiness" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMainlineBusiness" runat="server" Text="Mainline Business of the Co"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
<%--                <asp:DropDownList SkinID="ddlSkin" ID="ddlMainlineBusiness" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                 </asp:DropDownList>--%>
                 
                 
                 <%--SANKET 13MARCH,2014--%>
                    <asp:TextBox ID="txtMainlineBusiness" runat="server" SkinID="txtSkin" MaxLength="100" Width="80%" ></asp:TextBox>
                 <%--END--%>                 
                </td>
                </tr>
                </table>
      </asp:Panel>      
     
       <asp:Panel ID="pnlValueofNostocksighted" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblValueofNostocksighted" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblValueofNostocksighted" runat="server" Text="Value of No stock sighted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtValueofNostocksighted" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel> 
      
        <asp:Panel ID="pnlCategoryofCompany" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblCategoryofCompany" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblCategoryofCompany" runat="server" Text="Category of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlCategoryofCompany" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>psu/software/list 1184/pub lt</asp:ListItem>
                    <asp:ListItem>pvt ltd</asp:ListItem>
                    <asp:ListItem>partneship</asp:ListItem>    
                    <asp:ListItem>univ</asp:ListItem>
                    <asp:ListItem>propritory</asp:ListItem>
                    <asp:ListItem>bank</asp:ListItem>      
                    <asp:ListItem>rlys</asp:ListItem>
                    <asp:ListItem>colleges</asp:ListItem>
                    <asp:ListItem>Public Ltd</asp:ListItem>
                    <asp:ListItem>MNC</asp:ListItem>
                    <asp:ListItem>NGO</asp:ListItem>
                    <asp:ListItem>others pls specify</asp:ListItem>                                    
                </asp:DropDownList>
                </td>  
                </tr>               
          </table>
     </asp:Panel>
     
      <asp:Panel ID="pnlNormalOfficeJob" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNormalOfficeJob" runat="server" Text="Normal Office Job"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNormalOfficeJob" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                     <asp:ListItem>Normal Office Job</asp:ListItem>
                    <asp:ListItem>In Shift</asp:ListItem>
                    <asp:ListItem>Field Staff</asp:ListItem>
                    <asp:ListItem>Others (Pls specify)</asp:ListItem>    
               </asp:DropDownList>
                </td>  
                </tr>               
          </table>
     </asp:Panel>
     
      <!---Ended by kamal matekar-------------->
   
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
                    <asp:Label SkinID="lblSkin" ID="lblCompanyNameBoardSeen" runat="server" Text="Company Name board / Reception seen"></asp:Label>
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
                <asp:Label SkinID="lblSkin" ID="lblNoOfMember" runat="server" Text="No. of Members/Employee"></asp:Label>
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
                <asp:Label SkinID="lblSkin" ID="lblThirdPartyComment" runat="server" Text="Third party Comment / office colleague feedback"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('third party comment', this, 2000);"  ID="txtThirdPartyComment" runat="server" MaxLength="2000" ></asp:TextBox>                
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
                        <asp:ListItem>Approved Pincode</asp:ListItem>
                        <asp:ListItem>HRA</asp:ListItem>
                        <asp:ListItem>Negative Pincode</asp:ListItem>
                        <asp:ListItem>Negative Area</asp:ListItem>
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
                    <asp:Label SkinID="lblSkin" ID="lblProfile" runat="server" Text="Profile / EmailID"></asp:Label>
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
         
         <asp:Panel ID="pnlPurpose" runat="server" Width="100%" Visible="false">
                                    <table id="Table10" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label20" runat="server" Text="Purpose"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlPurpose" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Diversification</asp:ListItem>
                                                    <asp:ListItem>Expansion</asp:ListItem>
                                                    <asp:ListItem>Replacement</asp:ListItem>
                                                    <asp:ListItem>Others</asp:ListItem>                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtPurpose" runat="server"></asp:TextBox>
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
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourComments1" runat="server" Text="Comments of Neighbour1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 500);"  ID="txtNeighbourComments1" runat="server" MaxLength="500" ></asp:TextBox> 
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
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourComments2" runat="server" Text="Comments of Neighbour2 / Any other comment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 2000);" ID="txtNeighbourComments2" runat="server" MaxLength="2000" ></asp:TextBox> 
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
                        <asp:ListItem>Posh</asp:ListItem>
                        <asp:ListItem>Lower Middle</asp:ListItem> 
                        <asp:ListItem>Upper Class</asp:ListItem>
                        <asp:ListItem>Under developed</asp:ListItem>
                        <asp:ListItem>Middle Class</asp:ListItem>
                        <asp:ListItem>Lower Class</asp:ListItem>
                        <asp:ListItem>Lower Middle Class</asp:ListItem>
                        <asp:ListItem>Residencial area</asp:ListItem>
                        <asp:ListItem>Shopping complex</asp:ListItem>
                        <asp:ListItem>Commercial complex</asp:ListItem>
                        <asp:ListItem>LMC</asp:ListItem>
                        <asp:ListItem>Godown</asp:ListItem>
                        <asp:ListItem>Small scale industrial area</asp:ListItem>
                        <asp:ListItem>Industry/factory</asp:ListItem>
                        <asp:ListItem>Plant</asp:ListItem>
                        <asp:ListItem>Business center</asp:ListItem>
                        <asp:ListItem>Shopping center</asp:ListItem>
                        <asp:ListItem>City center</asp:ListItem>
                        <asp:ListItem>Bunglow</asp:ListItem>
                        <asp:ListItem>Estate</asp:ListItem>
                        <asp:ListItem>Village</asp:ListItem>
                        <asp:ListItem>Bad</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>
                        <asp:ListItem>Satisfactory</asp:ListItem>
                        <asp:ListItem>Chawl</asp:ListItem>
                        <asp:ListItem>Common area</asp:ListItem>
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
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <!--Update by MAnoj-->
                <tr>         
                 <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label26" runat="server" Text="If No Pls Remarks"></asp:Label>
                 </td><td style="width:2%">:</td>
                 <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtEntryPermittedRemaks" runat="server" MaxLength="50" ></asp:TextBox> 
                 </td>
                 </tr>
                <!--Update by MAnoj-->
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
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBriefJobResponsibility" runat="server" MaxLength="500" ></asp:TextBox> 
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
                        <asp:ListItem>Rude</asp:ListItem>
                        <asp:ListItem>Arrogant</asp:ListItem>
                        <asp:ListItem>Trying to Impress</asp:ListItem>
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
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfIndustry" runat="server" Text="Type of Industry / Status Of App."></asp:Label>
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
                        <asp:ListItem>Capative</asp:ListItem> 
                        <asp:ListItem>Company</asp:ListItem>   
                        <asp:ListItem>Self Employed</asp:ListItem>   
                        <asp:ListItem>Relatives</asp:ListItem>
                        <asp:ListItem>NGO</asp:ListItem>    
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
                      <%--  <asp:ListItem>Trading</asp:ListItem>    --%>        
                        <asp:ListItem>Professional</asp:ListItem>   <%--New added/Updated for CHOLA--%>           
                        <asp:ListItem>BPO</asp:ListItem>            
                        <asp:ListItem>Services</asp:ListItem>  
                        
                                   
                    </asp:DropDownList>
                    
                    
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlServiceProvider" runat="server"  AutoPostBack="false">
                        <asp:ListItem>Commission Agent</asp:ListItem>     
                      <asp:ListItem>Broker</asp:ListItem>
                       <asp:ListItem>Tutor/Personal Care</asp:ListItem>
                        <asp:ListItem>LIC Agent</asp:ListItem> 
                         <asp:ListItem>STD-PCO Booth</asp:ListItem>    
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
      <%--New added/Updated for Capri Global--%>
                <tr>
                <td class="TDWidth">Nature of Business in Details</td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtNatureOfBusiness" runat="server" MaxLength="800" Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
     <%--END--%>                
                
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoOfBranches" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfBranches" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfBranches" runat="server" Text="No. of Branches / Official Vehicle"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <%--<asp:TextBox SkinID="txtSkin"  ID="txtNoOfBranches" runat="server"  MaxLength="50"></asp:TextBox>--%> 
                   <asp:DropDownList ID="ddlNoOfBranches" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem><3</asp:ListItem>
                            <asp:ListItem>4-10</asp:ListItem>
                            <asp:ListItem>11-15</asp:ListItem>
                            <asp:ListItem>16-20</asp:ListItem>
                            <asp:ListItem>20-50</asp:ListItem>
                            <asp:ListItem>>50</asp:ListItem>
                </asp:DropDownList>
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
                    <asp:Label SkinID="lblSkin" ID="lblIfDoctors" runat="server" Text="If Doctors"></asp:Label><asp:Label ID="Label56" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblNoOfPatientsPerDay" runat="server" Text="No of Patients per day"></asp:Label><asp:Label ID="Label57" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblAvgFeesPerPatients" runat="server" Text="Avg. fees per patient"></asp:Label><asp:Label ID="Label58" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherClinicVisited" runat="server" Text="Other Clinic Visited"></asp:Label><asp:Label ID="Label59" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblNameOfClinicVisted" runat="server" Text="If Yes, Name of the clinic visited"></asp:Label><asp:Label ID="Label60" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblIfArchitectureCA" runat="server" Text="If Architecture/CA"></asp:Label><asp:Label ID="Label64" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblIndependentlyYrs" runat="server" Text="Independently (Yrs)"></asp:Label><asp:Label ID="Label65" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName1" runat="server" Text="Key Clients name(1)"></asp:Label><asp:Label ID="Label66" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName2" runat="server" Text="Key Clients name(2)"></asp:Label><asp:Label ID="Label67" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblKeyClientName3" runat="server" Text="Key Clients name(3)"></asp:Label><asp:Label ID="Label68" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblRelationWithApplicant" runat="server" Text="Relationship with applicant"></asp:Label><asp:Label ID="Label47" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>

                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationWithApplicant" runat="server" MaxLength="100" ></asp:TextBox> 
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
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfOrganization" runat="server" Text="Type of Organization / Constitutency Buss"></asp:Label>
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
                        <asp:ListItem>Family Business</asp:ListItem>          
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
       
       
         <%--  Added by abhijeet for FULLTern--%>
    
     <asp:Panel ID="PnlFamilyStructure" runat="server" Width="100%" Visible="false">
        <table id="Table31" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label80" runat="server" Text="Family Structure :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtFamilyStructure" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
       <asp:Panel ID="pnlsalescredit" runat="server" Width="100%" Visible="false">
        <table id="Table32" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label81" runat="server" Text="What % sales is done on credit :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtsalescredit" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    
       <asp:Panel ID="Pnlsalesconcentration" runat="server" Width="100%" Visible="false">
        <table id="Table33" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label82" runat="server" Text="Whether sales concentration is >50% on one party. If yes name of Party and contact no :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtsalesconcentration" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
         <asp:Panel ID="PnlBusinessCycledebtors" runat="server" Width="100%" Visible="false">
        <table id="Table34" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label83" runat="server" Text="Business Cycle -How many days credit allowed to Debtors and what are actual debtors amount as on date:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtBusinessCycledebtors" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    
      <asp:Panel ID="PnlBusinessCyclecreditors" runat="server" Width="100%" Visible="false">
        <table id="Table35" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label84" runat="server" Text="Business Cycle - How many days credit allowed by creditors to CM and what are actual Creditors amount as on date:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtBusinessCyclecreditors" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
          <asp:Panel ID="Pnlstockvaluation" runat="server" Width="100%" Visible="false">
        <table id="Table36" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label85" runat="server" Text="Business Cycle – What is stock valuation as on date:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="Txtstockvaluation" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
         <asp:Panel ID="PnlGrossMargin" runat="server" Width="100%" Visible="false">
        <table id="Table37" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label86" runat="server" Text="Gross & Net margins % in Business:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtGrossMargin" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
     <asp:Panel ID="PnlMonthlyNetSaving" runat="server" Width="100%" Visible="false">
        <table id="Table38" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label87" runat="server" Text="Monthly Net saving after all expenses in Rs:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtMonthlyNetSaving" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    
     <asp:Panel ID="pnlNameofSupplierscontactNo" runat="server" Width="100%" Visible="false">
        <table id="Table39" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label88" runat="server" Text="Name and contact no of two major suppliers:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtNameofSuppliers1" runat="server" MaxLength="2"></asp:TextBox>&nbsp;NameofSuppliers1
                       <asp:TextBox SkinID="txtSkin"  ID="TxtNameofSuppliers2" runat="server" MaxLength="2"></asp:TextBox>&nbsp;NameofSuppliers2
                &nbsp;
                 <asp:TextBox SkinID="txtSkin"  ID="TxtcontactNoSuppliers1" runat="server" MaxLength="2"></asp:TextBox>&nbsp;contactNoSuppliers1
            <asp:TextBox SkinID="txtSkin"  ID="TxtcontactNoSuppliers2" runat="server" MaxLength="2"></asp:TextBox>&nbsp;contactNoSuppliers2

                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    
     <asp:Panel ID="pnlNameofbuyerscontactNo" runat="server" Width="100%" Visible="false">
        <table id="Table40" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label89" runat="server" Text="Name and contact no of two major buyers:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtNameofbuyers1" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Nameofbuyers1
                       <asp:TextBox SkinID="txtSkin"  ID="TxtNameofbuyers2" runat="server" MaxLength="2"></asp:TextBox>&nbsp;Nameofbuyers2
                &nbsp;
                 <asp:TextBox SkinID="txtSkin"  ID="TxtcontactNobuyers1" runat="server" MaxLength="2"></asp:TextBox>&nbsp;contactNobuyers1
            <asp:TextBox SkinID="txtSkin"  ID="TxtcontactNobuyers2" runat="server" MaxLength="2"></asp:TextBox>&nbsp;contactNobuyers2

                </td>
            </tr>
        </table>
    </asp:Panel>
    
      <asp:Panel ID="PnlApplicabilityofVAT" runat="server" Width="100%" Visible="false">
        <table id="Table41" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label90" runat="server" Text="Applicability of VAT / Excise / Service tax and rate of same:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtApplicabilityofVAT" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
     <asp:Panel ID="PnlLatestQtrVAT" runat="server" Width="100%" Visible="false">
        <table id="Table42" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label91" runat="server" Text="Latest Qtr VAT return value/Service tax paid:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtLatestQtrVAT" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    <asp:Panel ID="PnlIstheentityinvolvedinanycommercialpestcontrol" runat="server" Width="100%" Visible="false">
        <table id="Table43" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label92" runat="server" Text="Is the entity involved in any commercial pest control operation,  use any Ozone depleting substance, hazardous chemicals, bio medical waste, Dyes, forest products, tobacco, alcohol, weapons, gambling, radioactive materials, unbounded asbestos, harmful fishing practice, commercial logging.:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtIstheentityinvolvedinanycommercialpestcontrol" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
     <asp:Panel ID="PnlDoestheentityinvolveinChildorforcedLabour" runat="server" Width="100%" Visible="false">
        <table id="Table44" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label93" runat="server" Text="Does the entity involve in Child or forced Labour or business involve displacement of people, impact on indigenous people or established in land designated as forest or forest products:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtDoestheentityinvolveinChildorforcedLabour" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
     
     <asp:Panel ID="PnlDoesestablishmentfromStatepollutioncontrol" runat="server" Width="100%" Visible="false">
        <table id="Table45" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label94" runat="server" Text="Does the entity have required consent of establishment from State pollution control board and other government authorities on establishment in  Wetland Area, near National Park, Sanctuaries or Forest areas, ASI certificate for establishment up to 300 meters near a protected monument or cultural heritage, 500 meters near Coastal Regulation Zone :">  </asp:Label>
                </td>              <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtDoesestablishmentfromStatepollutioncontrol" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    <asp:Panel ID="PnlDoesairwaternoisepollutants" runat="server" Width="100%" Visible="false">
        <table id="Table46" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label95" runat="server" Text="Does the entity involves in proper mechanism for treatment or disposal of waste and does not emit air, water or noise pollutants.:"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtDoesairwaternoisepollutants" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
      <asp:Panel ID="PnlDoestheEntitycomplywiththeaboveESSguidelines" runat="server" Width="100%" Visible="false">
        <table id="Table47" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label96" runat="server" Text="Does the Entity comply with the above ESS guidelines :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtDoestheEntitycomplywiththeaboveESSguidelines" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="PnlVintageofaccount1" runat="server" Width="100%" Visible="false">
        <table id="Table48" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label97" runat="server" Text="Vintage of account1 :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtVintageofaccount1" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
     <asp:Panel ID="PnlVintageofaccount2" runat="server" Width="100%" Visible="false">
        <table id="Table49" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label98" runat="server" Text="Vintage of account2 :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtVintageofaccount2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
     <asp:Panel ID="PnlIfCCODlimitwhatislimit1" runat="server" Width="100%" Visible="false">
        <table id="Table50" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label99" runat="server" Text="If CC/OD limit- what is limit 1 :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtIfCCODlimitwhatislimit1" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
      <asp:Panel ID="PnlIfCCODlimitwhatislimit2" runat="server" Width="100%" Visible="false">
        <table id="Table51" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label100" runat="server" Text="If CC/OD limit- what is limit 2 :"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtIfCCODlimitwhatislimit2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
       <asp:Panel ID="PnlCustomerBehavior" runat="server" Width="100%" Visible="false">
        <table id="Table52" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label101" runat="server" Text="Customer Behavior"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:DropDownList ID="ddlCustomerBehavior" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                <asp:ListItem>Very Good </asp:ListItem>
                <asp:ListItem>Satisfactory</asp:ListItem>
                <asp:ListItem>Poor</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        </table>
     </asp:Panel>
     
     
        <asp:Panel ID="PnlDetailedpurposeEnduseofLoanAmount" runat="server" Width="100%" Visible="false">
        <table id="Table53" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label102" runat="server" Text="Detailed purpose/End use of Loan Amount :"></asp:Label>
        </td>
         <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtDetailedpurposeEnduseofLoanAmount" runat="server"></asp:TextBox>
                </td>
        </tr>
        </table>
     </asp:Panel>
    
    
    
        <asp:Panel ID="PnlDetailedobservationsPositiveandNegative" runat="server" Width="100%" Visible="false">
        <table id="Table54" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label103" runat="server" Text="Detailed observations (Positive and Negative) :"></asp:Label>
        </td>
         <td style="width: 2%">
                    :</td>
                
                <td>
                  <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="TxtDetailedobservation" runat="server"></asp:TextBox>
                </td>
        </tr>
        </table>
     </asp:Panel>
     
     
     <asp:Panel ID="PnlDirectorName1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table103" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label104" runat="server" Text="Director Name 1 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorName1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
              <asp:Panel ID="PnlDirectorName2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table104" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label105" runat="server" Text=" Director Name 2 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorName2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
         
         
           <asp:Panel ID="PnlDirectorName3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table105" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label106" runat="server" Text=" Director Name 3 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorName3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlDirectorName4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table106" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label1034" runat="server" Text=" Director Name 4 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorName4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
  
    
    
      <asp:Panel ID="pnlBankName1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName1" runat="server" Text="BankName 1 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName1" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
           
           
            
           
           
            <asp:Panel ID="pnlTypeOfAccount1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount1" runat="server" Text="Type of Account 1 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount1" runat="server"  Width="80%"  MaxLength="50"  ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            <asp:Panel ID="pnlBankName2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName2" runat="server" Text="BankName 2 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlTypeOfAccount2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount2" runat="server" Text="Type of Account 2 :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
           
            <asp:Panel ID="PnlTypeofcustmor" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table5455" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label104446" runat="server" Text="Type of Custmor"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofcustmor" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>wholesaler</asp:ListItem>
                        <asp:ListItem>Retailer</asp:ListItem>
                          <asp:ListItem>Distributor </asp:ListItem>     
                             <asp:ListItem>c &  f agent </asp:ListItem>     
                              <asp:ListItem>Manufacturer</asp:ListItem> 
                                <asp:ListItem>Serviceprovider</asp:ListItem>              
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
   
   
   
   
   <asp:Panel ID="pnlLoanDetails" runat="server" Width="100%" Visible="false">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table55">
    <tr>
    <td >
        Loan Type</td>
    <td >
        Loan Financier</td>
    <td>
        Loan Amount</td>
    <td>
        Loan Tenure</td>
     <td>
        Loan Monthly EMI</td>
     <td>
        Loan No.Of EMI/Paid</td>                                            
    </tr>
    <%--/////////////////////////////First Type///////////////////////////////////--%>
    <tr>                                            
    <td >
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanType1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanFinancier1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanAmt1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanTenure1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanEmi1" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanPaid1" runat="server"></asp:TextBox>
    </td>
    </tr>
    <%--///////////////////////Second Type////////////////////////////--%>
    <tr>                                            
    <td >
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanType2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanFinancier2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanAmt2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanTenure2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanEmi2" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanPaid2" runat="server"></asp:TextBox>
    </td>
    </tr>
    <%--////////////////////////Third Type////////////////--%>
    <tr>                                            
    <td >
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanType3" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanFinancier3" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanAmt3" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanTenure3" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanEmi3" runat="server"></asp:TextBox>
    </td>
    <td>
    <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtLoanPaid3" runat="server"></asp:TextBox>
    </td>
    </tr>
                             
</table>
</asp:Panel> 
    
     <%--  ended by abhijeet for FULLTern--%>
 
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
                    <asp:Label SkinID="lblSkin" ID="lblBusinessProof" runat="server" Text="Business Proof seen"></asp:Label><asp:Label ID="Label51" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
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
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtResidenceAddress" runat="server" MaxLength="2000" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <%--Added by kamal matekar for Barclay finance PL--%>
         <asp:Panel ID="pnlPlaceOfBirth" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblPlaceOfBirth" style="width: 100%"
            runat="server">
              <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPlaceOfBirth" runat="server" Text="Place of Birth"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtPlaceOfBirth" runat="server"></asp:TextBox>
                </td>
                </tr>
            </table>
      </asp:Panel>
        <asp:Panel ID="pnlState" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblState" style="width: 100%"
                          runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblState" runat="server" Text="STATE"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtstate" runat="server"></asp:TextBox>
                </td>
            </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlPermanentAddressIfDifferent" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width: 100%"
                          runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblPermanentAddressIfDifferent" runat="server" Text="Address OR Permanent Address If Different"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                            <asp:TextBox SkinID="txtSkin" MaxLength="1000" Width="80%" ID="txtPermanentAddressIfDifferent" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
              <asp:Panel ID="pnlTypeOfAccomodation" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccomodation" style="width: 100%"
                          runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblTypeOfAccomodation" runat="server" Text="Type Of Accomodation"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtTypeOfAccomodation" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlApproxTimeWhenAppIsAvailableatHome" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblApproxTimeWhenAppIsAvailableatHome" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblApproxTimeWhenAppIsAvailableatHome" runat="server" Text="Approx Time When App Is Available at Home"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtApproxTimeWhenAppIsAvailableatHome" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlSourcingDsaDealer" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblSourcingDsaDealer" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblSourcingDsaDealer" runat="server" Text="Sourcing Dsa/Dealer"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtSourcingDsaDealer" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlExistingRelationshipwithBarclays" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblExistingRelationshipwithBarclays" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblExistingRelationshipwithBarclays" runat="server" Text="Existing Relationship with Barclays"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtExistingRelationshipwithBarclays" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
              <asp:Panel ID="pnlApplicantCategory" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="Table4" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblApplicantCategory" runat="server" Text="Applicant Category"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantCategory" runat="server"  AutoPostBack="false">
                                <asp:ListItem>Salaried</asp:ListItem>
                                <asp:ListItem>Self Employed</asp:ListItem>            
                        </asp:DropDownList>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlIfSalariedEmployerName" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblIfSalariedEmployerName" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblIfSalariedEmployerName" runat="server" Text="If Salaried Employers Name"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtIfSalariedEmployerName" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlMainClient" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblMainClient" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblMainClient" runat="server" Text="Main Client/Tenure"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtMainClient" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlSizeOfOffice" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblSizeOfOffice" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblSizeOfOffice" runat="server" Text="Size Of Office"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlSizeOfOffice" runat="server"  AutoPostBack="false">
                                 <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>BIG</asp:ListItem>
                                <asp:ListItem>MEDIUM</asp:ListItem>            
                                <asp:ListItem>SMALL</asp:ListItem>            
                        </asp:DropDownList>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlSelfOwnedRentedIfRentedPMRent" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblSelfOwnedRentedIfRentedPMRent" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblSelfOwnedRentedIfRentedPMRent" runat="server" Text="Self Owned/Rented/If Rented P.M Rent"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtSelfOwnedRentedIfRentedPMRent" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlNoOfYrsAtCurrentOfficeAddress" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrsAtCurrentOfficeAddress" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblNoOfYrsAtCurrentOfficeAddress" runat="server" Text="No Of Yrs At Current Office Address"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtNoOfYrsAtCurrentOfficeAddress" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlOtherOfficeLocationDetails" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblOtherOfficeLocationDetails" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblOtherOfficeLocationDetails" runat="server" Text="Other Office Location Details"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtOtherOfficeLocationDetails" runat="server" Width="80%" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlAutomationLevel" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblAutomationLevel" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblAutomationLevel" runat="server" Text="Automation Level"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <%--<asp:DropDownList SkinID="ddlSkin" ID="ddlAutomationLevel" runat="server"  AutoPostBack="false">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>FAX</asp:ListItem>
                                <asp:ListItem>TELEPHONE</asp:ListItem>            
                                <asp:ListItem>PHOTOSTAT</asp:ListItem> 
                                <asp:ListItem>COMPUTERS</asp:ListItem>           
                        </asp:DropDownList>--%>
                        <asp:CheckBoxList SkinID="chkListSkin" ID="chkAutomationLevel" runat="server" RepeatDirection="Horizontal" RepeatColumns="8" AutoPostBack="false">
                        <asp:ListItem>Fax</asp:ListItem>
                        <asp:ListItem>Telephone</asp:ListItem>
                        <asp:ListItem>Photostat</asp:ListItem>            
                        <asp:ListItem>Computers</asp:ListItem>
                        <asp:ListItem>Machinery</asp:ListItem>                        
                        <asp:ListItem>Printer</asp:ListItem>
                        </asp:CheckBoxList>  
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlAPPROACHABILITY" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblAPPROACHABILITY" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblAPPROACHABILITY" runat="server" Text="Accessibility/Approachability"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlAPPROACHABILITY" runat="server"  AutoPostBack="false">
                                <asp:ListItem>BY ALL MODES OF TRANSPORT</asp:ListItem>
                                <asp:ListItem>BY 2W ONLY</asp:ListItem>            
                                <asp:ListItem>OTHERS</asp:ListItem> 
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblIfOthers" runat="server" Text="If Others Approachability"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                     <td>
                        <asp:TextBox ID="txtApprochbilityifOthers" runat="server" SkinID="txtSkin"></asp:TextBox>
                    </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlWithinMunicipalLimit" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblWithinMunicipalLimit" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblWithinMunicipalLimit" runat="server" Text="Within Municipal Limit"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtWithinMunicipalLimit" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
             <asp:Panel ID="pnlAnyOtherFormOfbusiness" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOtherFormOfbusiness" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblAnyOtherFormOfbusiness" runat="server" Text="Any Other Form Of business(If Yes Details & Location)"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtAnyOtherFormOfbusiness" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlYearsAtCurrentAddress" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblYearsAtCurrentAddress" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblYearsAtCurrentAddress" runat="server" Text="Years At Current Address"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtYearsAtCurrentAddress" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlNoOfYearsInCity" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblNOOFYEARSINCITY" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblNOOFYEARSINCITY" runat="server" Text="No Of Years In City"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtNoOfYearsInCity" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
              <asp:Panel ID="pnlVehicalOwned" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblVehicalOwned" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblVehicalOwned" runat="server" Text="Vehical Owned"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlVehicalOwned" runat="server" AutoPostBack="false">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>Two Wheeler</asp:ListItem>
                                <asp:ListItem>Four Wheeler</asp:ListItem>            
                        </asp:DropDownList>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            
            <asp:Panel ID="pnlUseOfAssets" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="Label11" runat="server" Text="Use of asset for"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlUseOfAssets" runat="server" AutoPostBack="false">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>Personal use</asp:ListItem>
                                <asp:ListItem>Official use</asp:ListItem>            
                        </asp:DropDownList>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            
            <asp:Panel ID="pnlAnyOtherAssets" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOtherAssets" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblAnyOtherAssets" runat="server" Text="Any Other Assets"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtAnyOtherAssets" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="Label13" runat="server" Text="Finance Company Name"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtFinanceCompName" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
            <asp:Panel ID="pnlBankParticular" runat="server" Width="100%" Visible="false">
              <table cellpadding="0" cellspacing="0" border="0" id="tbllblBankParticular" style="width: 100%" runat="server">
                     <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblBankParticular" runat="server" Text="Bank Particulars OR Type of A/C"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                        <asp:TextBox ID="txtBankParticular" runat="server" Width="80%" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                  </table>
            </asp:Panel>
           <%--Ended by kamal matekar--%>
           <%--Added by kamal matekar for federal finance PL On Dated 29 July 2010--%>
                <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width: 100%"
                        runat="server">
                        <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="Label1" runat="server" Text="Place of Birth"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                  </asp:Panel>
                   <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="Table6" style="width: 100%"
                        runat="server">
                        <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="STATE"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                    <asp:Panel ID="pnlNameVerifiedFrom" runat="server" Width="100%" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width: 100%"
                            runat="server">
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblNameVerifiedFrom" runat="server" Text="Name Verified From"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:DropDownList ID="ddlNameVerifiedForm" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>NAMEPLATE</asp:ListItem>
                                    <asp:ListItem>WATCHMAN</asp:ListItem>
                                    <asp:ListItem>NEIGHBOUR</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                     <asp:Panel ID="Panel3" runat="server" Width="100%" Visible="False">
                        <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantCategory" style="width: 100%"
                            runat="server">
                            <tr>
                            <td colspan="3" align="center">
                            <asp:Label ID="lblEmployeeDetails" runat="server" SkinID="lblSkin" Text="Employment Details"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="Label5" runat="server" Text="Applicant Category"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>Salaried</asp:ListItem>
                                    <asp:ListItem>Self Employed</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblIfSalariedDesignation" runat="server" Text="If Salaried Designation"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtIfSalariedDesignation" runat="server" SkinID="txtSkin"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblIfSelfEmployed" runat="server" Text="If SelfEmployed Designation"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtIfSelfEmployed" runat="server" SkinID="txtSkin"></asp:TextBox>
                                </td>
                            </tr>
                              <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblOfficeTelNumber" runat="server" Text="Office Tel Number"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtOfficeTelNumber" runat="server" SkinID="txtSkin"></asp:TextBox>
                                </td>
                            </tr>
                              <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblNoOfEmployeesSeen" runat="server" Text="No Of Employees Seen"></asp:Label>
                                </td>
                                <td style="width: 2%">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtNoOfEmployeesSeen" runat="server" SkinID="txtSkin"></asp:TextBox>
                                </td>
                            </tr>
                         </table>
                    </asp:Panel>                                                                                              
                    <%--Ended by kamal matekar--%>
                                <%---Started by kamal matekar fro Federal Finance--%>
                                <asp:Panel ID="pnlGeneralInformationCo_Applicant" runat="server" Width="100%" Visible="False">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralInformationCo_Applicant" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td colspan="3" align="center">
                                        <asp:Label ID="lblCoApplicant" runat="server" SkinID="lblSkin" Text="GENERAL INFORMATION-CO-APPLICANT"></asp:Label>
                                        </td>
                                        </tr>
                                           <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblComapnyName" runat="server" Text="Company Name Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtComapnyNameCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOffAddCoApp" runat="server" Text="Office Add Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtOffAddCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLandMarkCoApp" runat="server" Text="Land Mark Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtLandMarkCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTelNoCoApp" runat="server" Text="Tel No Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtTelNoCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPerContCoApp" runat="server" Text="Person Contacted Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtPerCotCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDesignationCoApp" runat="server" Text="Designation Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDesignationCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDateOfVisitCoApp" runat="server" Text="Date of Visit"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDateofVisitCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                     </table>
                                </asp:Panel>
                 <asp:Panel ID="pnlComStructure" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblComStructure" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblComStructure" runat="server" Text="Com.Structure"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtComStructure" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                  <asp:Panel ID="pnlTurnOver" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblTurnOver" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblTurnOver" runat="server" Text="Turn Over"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtTurnOver" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlStock" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblStock" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblStock" runat="server" Text="Stock & Machinery"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <%--<asp:TextBox ID="txtStock" runat="server" SkinID="txtSkin"></asp:TextBox>--%>
                            <asp:DropDownList SkinID="ddlSkin" ID="ddlStock" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                 <asp:Panel ID="pnlITReturn" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblITReturn" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblITReturn" runat="server" Text="I.T.Return"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtITReturn" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                 <asp:Panel ID="pnlProfitMargin" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblProfitMargin" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblProfitMargin" runat="server" Text="Profit Margin"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtProfitMargin" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlDeptClaimed" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblDeptClaimed" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblDeptClaimed" runat="server" Text="Dept Claimed"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtDeptClaimed" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlWife" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblWife" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblWife" runat="server" Text="Wife"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtWife" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlSon" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblSon" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblSon" runat="server" Text="Son / Fax No"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtSon" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                
                  <asp:Panel ID="pnlLoanType" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblLoanType" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblLoanType" runat="server" Text="Loan Type"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtLoanType" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                 <asp:Panel ID="pnlEMI" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblEMI" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblEMI" runat="server" Text="EMI"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtEMI" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlPaid" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblPaid" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblPaid" runat="server" Text="Paid / PANno"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtPaid" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlCrLimit" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblCrLimit" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblCrLimit" runat="server" Text="Cr.Limit"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtCrLimit" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                <asp:Panel ID="pnlCardNo" runat="server" Width="100%" Visible="false">
                         <table cellpadding="0" cellspacing="0" border="0" id="tblCardNo" style="width: 100%" runat="server">
                         <tr>
                            <td class="TDWidth">
                                <asp:Label SkinID="lblSkin" ID="lblCardNo" runat="server" Text="Card No / EmployeeID"></asp:Label>
                            </td>
                            <td style="width: 2%">
                                :</td>
                            <td>
                            <asp:TextBox ID="txtCardNo" runat="server" Width="80%" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                      </table>
                </asp:Panel>
                    
           <%--Ended by kamal matekar--%>
           
           <%--Start by Nikhil 9 april 2013--%>
           
           <asp:Panel ID="pnlNeighCheck" runat="server" Width="100%" Visible="false">
                <table id="tblNeighCheck" cellpadding="0" cellspacing="0" style="width: 100%"
                    runat="server">
                    <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblNeighCheck" runat="server" Text="Neighbour Check"></asp:Label>
                        </td>
                        <td style="width: 2%">
                            :</td>
                        <td>
                            <asp:DropDownList ID="ddlNeighCheck" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                                <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>                                                    
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
              <asp:Panel ID="pnlCustSameOffice" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="tblCustSameOffice" style="width:100%" runat="server">
                    <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblCustSameOffice" runat="server" Text="Customers sits in same office"></asp:Label>
                    </td><td style="width:2%">:</td>
                    <td>
                        <asp:DropDownList SkinID="ddlSkin" ID="ddlCustSameOffice" runat="server"  AutoPostBack="false">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                   </table>
               </asp:Panel>
           
            <asp:Panel ID="pnlOfficeOrStock" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeOrStock" style="width:100%" runat="server">
                        <tr>         
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="lblOfficeOrStock" runat="server" Text="Only office/ If Trader  Stock seen/ Factory operational "></asp:Label>
                        </td><td style="width:2%">:</td>
                        <td >
                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtOfficeOrStock" runat="server" ></asp:TextBox> 
                        </td>
                        </tr>
                   </table>
               </asp:Panel>
           
           <asp:Panel ID="pnlOfficeAmenities" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAmenities" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOfficeAmenities" runat="server" Text="Good office with required amenities"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeAmenities" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlShadyOffice" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblShadyOffice" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblShadyOffice" runat="server" Text="Very small / shady office"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlShadyOffice" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
    
    <asp:Panel ID="pnlMultiCompanyFromPremises" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMultiCompanyFromPremises" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMultiCompanyFromPremises" runat="server" Text="Multiple companies operating from this premise"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlMultiCompanyFromPremises" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
    </asp:Panel>
                  <asp:Panel ID="pnlAddressSetup" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAddressSetup" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAddressSetup" runat="server" Text="Address seems to be a setup"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressSetup" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Okay</asp:ListItem>
                                            <asp:ListItem>Suspicious</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlMetCust" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMetCust" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMetCust" runat="server" Text="Met Customer"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlMetCust" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="PnlMetRecep" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMetRecep" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMetRecep" runat="server" Text="Met Reception"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlMetRecep" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlMetColleague" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMetColleague" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMetColleague" runat="server" Text="Met Customer"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlMetColleague" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlMetSecurityGuard" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMetSecurityGuard" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMetSecurityGuard" runat="server" Text="Met Security Guard"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlMetSecurityGuard" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlDesgnConf" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDesgnConf" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDesgnConf" runat="server" Text="Designation Confirmed"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlDesgnConf" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
            <%--End by Nikhil 9 april 2013--%>
            
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
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="2000" onkeyPress="ValidateTextLength('verifier comments', this, 2000);"  ID="txtVerifierComments" runat="server" ></asp:TextBox> 
                </td>                
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label6" runat="server" Text="Any other Feedback"></asp:Label><asp:Label ID="Label74" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="2000" ID="txtOtherFeedback" runat="server" ></asp:TextBox> 
                </td>
                </tr> 
           </table>
       </asp:Panel>
       <asp:Panel ID="pnlProofOfBusinessActivity" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProofOfBusinessActivity" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProofOfBusinessActivity" runat="server" Text="Proof of Business Activity details"></asp:Label><asp:Label ID="Label52" runat="server"><span style="font-size:larger; font-weight:bolder; color:Red"> *</span></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProofOfBusinessActivity" runat="server" MaxLength="500" ></asp:TextBox> 
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
   <%--added by nikhil 17 oct 2013--%>
   <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorNameForSign" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSupervisorNameForSign" runat="server" Text="Supervisor's Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlSupervisorName" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                
               </asp:DropDownList><asp:Label id="lblvalid" runat="server" Font-Bold="true" ForeColor="Red" Text="Supervisor Name Is Mandatory" SkinID="lblSkin"></asp:Label>
                
                </td>
                </tr>
                </table>                     
       <%--end by nikhil--%>
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
                   <%--<asp:TextBox SkinID="txtSkin"  ID="txtTotalNoOfEmployees" runat="server" MaxLength="10" ></asp:TextBox> --%>
                   <asp:DropDownList ID="ddlTotalNoOfEmployees" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                            <asp:ListItem><5</asp:ListItem>
                            <asp:ListItem>5-10</asp:ListItem>
                            <asp:ListItem>11-15</asp:ListItem>
                            <asp:ListItem>16-20</asp:ListItem>
                            <asp:ListItem>20-50</asp:ListItem>
                            <asp:ListItem>>50</asp:ListItem>
                            <asp:ListItem>others</asp:ListItem>
                </asp:DropDownList>
                </td>
                
                </tr>
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label108" runat="server" Text="If Others(Ple.Specify)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin"  ID="txtotherTotalNoOfEmployees" runat="server" MaxLength="10" ></asp:TextBox> 
                   
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
                    <asp:Label SkinID="lblSkin" ID="lblWhereContacted" runat="server" Text="Where Contacted / Report To"></asp:Label>
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
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPrevOccupationDtl" runat="server" MaxLength="2000" ></asp:TextBox> 
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
                        <asp:ListItem>Permament Avg</asp:ListItem>  
                        <asp:ListItem>Permament Plush</asp:ListItem>  
                        <asp:ListItem>Slum</asp:ListItem>  
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
                        <asp:ListItem>Very Difficult</asp:ListItem>            
                        <asp:ListItem>Not Found</asp:ListItem>    
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
                   <asp:TextBox SkinID="txtSkin"  ID="txtIfOCLDistance" runat="server" MaxLength="500"></asp:TextBox> 
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
      <!--Added by MAnoj-->    
    <asp:Panel ID="PnlResidenceDetails" runat="server" Width="100%" Visible="false">
            <table id="Table11" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label16" runat="server" Text="Residence Details"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtResidenceDetails" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
    </asp:Panel>
        <asp:Panel ID="PnlAccountType" runat="server" Width="100%" Visible="false">
            <table id="Table12" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label17" runat="server" Text="Account Type & No"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtAccountType" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
    </asp:Panel>
      <asp:Panel ID="PnlBusinessConfirmed" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table13" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label18" runat="server" Text="Business / Employment Confirmed"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessConfirmed" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label19" runat="server" Text="If No Pls Remaks"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtBusinessConfirmedRem" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
               </table>
    </asp:Panel>
    <asp:Panel ID="PnlConfirmationSetup" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table14" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label21" runat="server" Text="Confirmation Of Setup"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlConfirmationSetup" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label22" runat="server" Text="If No Pls Remaks"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtConfirmationSetup" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
               </table>
    </asp:Panel>
     <asp:Panel ID="PnlDedupMatch" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDedupMatch" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDedupMatch" runat="server" Text="Dedup Match Found"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDedupMatch" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label24" runat="server" Text="If Yes,Remaks"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtDedupMatch" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
               </table>
    </asp:Panel>
     <asp:Panel ID="PnlGeneralAppearance" runat="server" Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table16" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label27" runat="server" Text="General Appearance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlGeneralAppearance" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Excellent</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>    
                        <asp:ListItem>Fair</asp:ListItem>     
                        <asp:ListItem>Poor</asp:ListItem> 
                        <asp:ListItem>Fast moving</asp:ListItem> 
                        <asp:ListItem>Slow moving</asp:ListItem> 
                        <asp:ListItem>No visible movement</asp:ListItem> 
                        <asp:ListItem>Empty</asp:ListItem> 
                        <asp:ListItem>Not Applicable</asp:ListItem>             
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="PnlInducementoffered" runat="server" Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table17" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label28" runat="server" Text="Any Inducement offered"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlInducementoffered" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     
         <asp:Panel ID="pnlDoesbranchesn" runat="server" Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table18" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label29" runat="server" Text="Does the office/ Co have branches"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesbranches" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="PnlNeighbourCheckn" runat="server" Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table19" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label30" runat="server" Text="Neighbour Check"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlNeighbourCheck" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
     </asp:Panel>
     <asp:Panel ID="PnlNameVerifierNAmen" runat="server" Width="100%" Visible="false">
            <table id="Table20" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label31" runat="server" Text="Name Verifier Name"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtNameVerifierNAme" Width="80%" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
    </asp:Panel>
     <asp:Panel ID="pnlInteriors" runat="server" Width="100%" Visible="false">
             <table cellpadding="0" cellspacing="0" border="0" id="tblInteriors" style="width:100%" runat="server">
                       <tr>
                            <td class="TDWidth">
                                  <asp:Label SkinID="lblSkin" ID="lblInteriors" runat="server" Text="Interiors"></asp:Label>
                            </td><td style="width:2%">:</td>
                            <td>
                                  <asp:CheckBoxList ID="chkInteriors" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="horizontal" RepeatColumns="4">                    
                                            <asp:ListItem>Painted</asp:ListItem>
                                            <asp:ListItem>Carpeted</asp:ListItem>  
                                            <asp:ListItem>Curtains</asp:ListItem>
                                            <asp:ListItem>Clean</asp:ListItem>
                                  </asp:CheckBoxList>
                             </td>
                         </tr>
                      </table>
         </asp:Panel>
    <!--Ended by Manoj-->
     
    <!--Start Additional Fields on 23-Aug-2007-->
    <asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="false">
        <table id="tblLevelOfBusinessActivity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblLevelOfBusinessActivity" runat="server" Text="Level of Business Activity"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td>
        <asp:DropDownList ID="ddlLevelOfBusinessActivity" runat="server" AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>High</asp:ListItem>
        <asp:ListItem>Average</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
        <asp:ListItem>V Busy</asp:ListItem>
        <asp:ListItem>Busy</asp:ListItem>
        <asp:ListItem>Medium</asp:ListItem>
        <asp:ListItem>Low</asp:ListItem>
        <asp:ListItem>No Activity</asp:ListItem>
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
    
    <asp:Panel ID="pnlPropertyIsRentedtoSomeone" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="Table8" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="Label7" runat="server"  Text="Property Is Rented to Someone/Common Office & Resi"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlProperty" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                               
                </asp:DropDownList>
                </td>   
                </tr>
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblRentPermonth" runat="server" Text="If Yes ,Rent per month-RS/Whether Distinct"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtRentPerMonth" runat="server"></asp:TextBox>
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
        <asp:ListItem>Very small</asp:ListItem>
        <asp:ListItem>small</asp:ListItem>
        <asp:ListItem>High</asp:ListItem>
        <asp:ListItem>Average</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
        <asp:ListItem>No stock</asp:ListItem>
        <asp:ListItem>Not Applicable</asp:ListItem>
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
        <%--<asp:TextBox SkinID="txtSkin"   ID="txtMonthsOfWorkatCurrentOffice" Width="80%" runat="server" MaxLength="50"></asp:TextBox>--%>
        <asp:DropDownList ID="ddlMonthsOfWorkatCurrentOffice" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem><1yr</asp:ListItem>
        <asp:ListItem>1-2yr</asp:ListItem>
        <asp:ListItem>2-5yr</asp:ListItem>
        <asp:ListItem>6-10yr</asp:ListItem>
        <asp:ListItem>>10yrs</asp:ListItem>
        </asp:DropDownList>
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
                    <asp:Label SkinID="lblSkin" ID="lblNameOfCollegue" runat="server" Text="Name of Item/Collegue"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtNameOfCollegue" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDesgnDeptOfCollegue" runat="server" Width="100%" Visible="false">
        <table id="tblDesgnDeptOfCollegue" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
             <tr><td colspan="3" align="center">
             <asp:Label ID="Label15" runat="server" SkinID="lblSkin" Text="FOR BUSINESS CATEGORY"></asp:Label>
             </td>
             </tr>
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
                <asp:Label SkinID="lblSkin" ID="lblAppNameVerifiedFrom" runat="server" Text="Applicant's name verified from / Job Confirm from"></asp:Label>
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
                <asp:TextBox SkinID="txtSkin"  Width="80%"  ID="txtOtherAppNameVerifiedFrom" runat="server" MaxLength="50" ></asp:TextBox>
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
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="2000" onkeyPress="ValidateTextLength('verifier comments', this, 2000);"  ID="txtSupervisorComments" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>    
        <!--Add Additional Fields for city bank-->
      <asp:Panel ID="PnlFurnishingseen" runat="server" Width="100%" Visible="false">
        <table id="Table21" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label32" runat="server" Text="Furnishing seen"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:DropDownList ID="ddlFurnishingseen" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                <asp:ListItem>Plush</asp:ListItem>
                <asp:ListItem>Good</asp:ListItem>
                <asp:ListItem>Fair</asp:ListItem>
                <asp:ListItem>Poor</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        </table>
     </asp:Panel>
         <asp:Panel ID="PnlSecretary" runat="server" Width="100%" Visible="false">
        <table id="Table22" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label33" runat="server" Text="Secretary / Typist"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:DropDownList ID="ddlSecretary" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Pnlthereaphoneonhisdesk" runat="server" Width="100%" Visible="false">
        <table id="Table23" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin"   ID="Label34" runat="server" Text="If met at his desk , was there a phone on his desk"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:DropDownList ID="ddlthereaphoneonhisdesk" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
       <asp:Panel ID="PnlCrossinformation" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tabCrossinformation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="labcrossinformation" runat="server" Text="Cross Verified Information:"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlcrossinformation" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
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
     
      <asp:Panel ID="pnlExactCompanyNameAddress" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblExactAddress" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExactCompanyNameAddress" runat="server" Text="Exact Company Name and Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtExactCompanyNameAddress" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
     </asp:Panel>
    <%--    Added by MAnoj for Future bank--%>      
    
    <%-- Start Nikhil ING Vysya 04 july 2013--%>
           
             <asp:Panel ID="pnlCoApplicantName" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblCoApplicantName" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblCoApplicantName" runat="server" Text="Co-Applicant Name(if any)"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtCoApplicantName" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlAddressonfirmed" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAddressonfirmed" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblAddressonfirmed" runat="server" Text="Address Confirmed"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                          <%-- <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtAddressonfirmed" runat="server" ></asp:TextBox> --%>
                                           
                                           <%--Changed by Sanket for CHOLA--%>
                                           <asp:DropDownList ID="ddlAddressConfirmed" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:DropDownList> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlRouteMap" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRouteMap" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblRouteMap" runat="server" Text="Route Map"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtRouteMap" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlAverageBillingPerCustomer" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAverageBillingPerCustomer" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblAverageBillingPerCustomer" runat="server" Text="Average Billing per Customer"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtAverageBillingPerCustomer" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlPeakBusinessHours" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblPeakBusinessHours" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblPeakBusinessHours" runat="server" Text="Peak Business Hours"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtPeakBusinessHours" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlMarketHoliday" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMarketHoliday" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblMarketHoliday" runat="server" Text="Market Holiday"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtMarketHoliday" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlVehicleRegNo" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleRegNo" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblVehicleRegNo" runat="server" Text="Vehicle Reg no."></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtVehicleRegNo" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlVehicleFreeOrFinance" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleFreeOrFinance" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblVehicleFreeOrFinance" runat="server" Text="Vehicle Free/Finance"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtVehicleFreeOrFinance" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlExistingLoanDetails" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblExistingLoanDetails" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblExistingLoanDetails" runat="server" Text="Existing loan obligations"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtExistingLoanDetails" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlAnyConcerningIssue" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAnyConcerningIssue" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblAnyConcerningIssue" runat="server" Text="Any concerning Issue noticed  during verification"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtAnyConcerningIssue" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlReportingTo" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblReportingTo" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblReportingTo" runat="server" Text="Reporting to"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtReportingTo" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
           
           <asp:Panel ID="pnlUploadAttach" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblUploadAttach" style="width:100%" runat="server">
    <tr>
           <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblUploadAttach" Font-Bold="true" Font-Size="Small" runat="server" Text="UPLOAD DOCUMENTS"></asp:Label>
            </td>
    </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Upload" runat="server" Text="Route Map"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:FileUpload ID="FileUpload1" Width="70%"  runat="server"  SkinID="flup"/>
                 <a href="javascript:openwindow('1');" title="View Uploaded Image">View Uploaded Image</a>            
            </td>
           
        </tr>
        </table>
        </asp:Panel>
           <%--End ING Vysya--%>
      <asp:Panel ID="Pnlearning" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table24" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label35" runat="server" Text="Earning members other than applicant"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtEaringmembers" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label36" runat="server" Text="Relationship with applicant"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtRelationshipe" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label37" runat="server" Text="Monthly Earning(approx)"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtmonthlyearing" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label38" runat="server" Text="Verified Through"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtVerifierthrough" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="PnlThiredpartyConfimation" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table25" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label39" runat="server" Text="Applicant’s Standing in Locality"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantstaandinginLocality" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>V. Good</asp:ListItem>
                                            <asp:ListItem>Good</asp:ListItem>
                                            <asp:ListItem>Fair</asp:ListItem>  
                                            <asp:ListItem>Poor</asp:ListItem>  
                                        </asp:DropDownList>
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label40" runat="server" Text="Name :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtnamee" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label41" runat="server" Text="Phone :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtphonee" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label42" runat="server" Text="Pls elaborate on the standing :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtelaborateonthestanding" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel> 
     <asp:Panel ID="PnlBusinessdealingseen" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="Table26" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label43" runat="server" Text="Business dealing seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessdealingseen" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Credit</asp:ListItem>
                    <asp:ListItem>Cash and Credit both</asp:ListItem>                                   
                </asp:DropDownList>
                </td>  
                </tr>               
          </table>
     </asp:Panel>
           <asp:Panel ID="PnlFinanciar" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table27" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label44" runat="server" Text="Financier"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtFinancier" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
            </asp:Panel>
             <asp:Panel ID="PnlFinanceAmount" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="Table28" style="width:100%" runat="server">
                        <tr>         
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="Label45" runat="server" Text="Finance Amount"></asp:Label>
                        </td><td style="width:2%">:</td>
                        <td >
                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtFinanceAmount" runat="server" ></asp:TextBox> 
                        </td>
                        </tr>
                   </table>
            </asp:Panel>  
             <asp:Panel ID="PnlNoOfbranchtext" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table29" style="width:100%" runat="server">
                    <tr>         
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label46" runat="server" Text="No Of Branch:"></asp:Label>
                    </td><td style="width:2%">:</td>
                    <td >
                       <asp:TextBox SkinID="txtSkin" ID="txtNoOfbranch" runat="server" ></asp:TextBox> 
                    </td>
                    </tr>
               </table>
            </asp:Panel>                         
    <!--End Additional Fields on 03-Oct-2007-->
    
 <%--Added  by Manoj for Area --%>                                
  <asp:Panel ID="PnlAreaname" runat="server" Width="100%" Visible="true">
       <table cellpadding="0" cellspacing="0" border="0" id="tabareaname" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labAreaname" runat="server" Text="Area Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false" ValidationGroup="gvValidate"></asp:DropDownList>
                  <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                              <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />

                
                </td>
           </tr>            
       </table>
   </asp:Panel>
                               
 <%--Ended  by Manoj for Area --%>      
 
 
        <%--New added/Updated for CHOLA--%>
      
  <asp:Panel ID="pnlSalaryDrawn" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="Table15" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label75" runat="server" Text="Salary Drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" ID="txtSalaryDrawn" runat="server" ></asp:TextBox> 
                </td>
           </tr>            
       </table>
   </asp:Panel>      
      
      
      <%--End--%> 

       <%--New added/Updated for Capri Global--%>

  <asp:Panel ID="Pnl_Original_Seen_Verified" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="Table30" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label76" runat="server" Text="Photo ID Details"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPhotoIDdetails" runat="server" ></asp:TextBox> 
                </td>
           </tr>            
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label77" runat="server" Text="Address Proof Details"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddrProofdetails" runat="server" ></asp:TextBox> 
                </td>
           </tr>            
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label78" runat="server" Text="Income Proof Details"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtIncomeProofdetails" runat="server" ></asp:TextBox> 
                </td>
           </tr>            
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label79" runat="server" Text="Supporting Doc Details"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSupportingDoc" runat="server" ></asp:TextBox> 
                </td>
           </tr>            

       </table>
   </asp:Panel>

      <%--End--%> 

 
       <br />
      <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" ValidationGroup="gvValidate" SkinID="btnSubmitSkin" runat="server" Text="Submit" OnClick="btnSubmit_Click" />    
                <asp:Button ID="btnCancel"  runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            </tr>
            <%--SANKET--%>
            <tr>
                <td>
                   <strong><asp:Label ID="Label23" runat="server">Items marked with <span style="font-size:larger; font-weight:bolder; color:Red">*</span> are for "Self Employed".</asp:Label></strong>
                </td>
            </tr>
            <%--SANKET--%>            
            
            
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
       <%--added by nikhil for supervisor sign--%>
       <asp:CustomValidator ID="cvSupervisorName" runat="server" 
                   ErrorMessage="Please select Supervisor Name." ValidationGroup="gvValidate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlSupervisorName" OnServerValidate="cvSelectddlSupervisorName_ServerValidate">
       </asp:CustomValidator>
                 <%--end nikhil--%>     
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
                    
<%--added by sanket on 13/02/2014--%>         
        <asp:RequiredFieldValidator ID="rfvAreaname" runat="server"
             ErrorMessage="Please Select Area Name." ControlToValidate="ddlAreaname"
            InitialValue="0" Display="None" ValidationGroup="gvValidate"  >
        </asp:RequiredFieldValidator>
<%--End by sanket--%>                      
                    
    <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="gvValidate" ShowMessageBox="True" ShowSummary="False" /> 
    </td>
</tr>
<tr><td style="height: 38px"></td><td style="height: 38px">
<asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
        </asp:SqlDataSource>
</td><td style="height: 38px"></td></tr>
</table>
 <asp:HiddenField ID="hdnTransStart" runat="server" />
    <asp:SqlDataSource ID="sdsFE" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:HiddenField ID="hdnSupID" runat="server" />
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

