<%@ Page Language="C#" MasterPageFile="RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_ResidenceVerification.aspx.cs" Inherits="RL_ResidenceVerification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
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
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
    <fieldset>
        <legend class="FormHeading"><asp:Label ID="lblHead" runat="server"></asp:Label></legend>
        <table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color: #E7F6FF">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <!--- Start of Personal Detail-->
                    <asp:Table ID="tblResiVerification" runat="server" Width="100%">
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
                                <asp:PlaceHolder ID="PlaceHolder191" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder192" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder193" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder194" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder195" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder196" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder197" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder198" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder199" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder200" runat="server" EnableViewState="false"></asp:PlaceHolder>    
                                <asp:PlaceHolder ID="PlaceHolder201" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder202" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder203" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder204" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder205" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder206" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder207" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder208" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder209" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder210" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder211" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder212" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder213" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder214" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder215" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder216" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder217" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder218" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder219" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder220" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder221" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder222" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder223" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder224" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder225" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder226" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder227" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder228" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder229" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder230" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder231" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder232" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder233" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder234" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder235" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder236" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder237" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder238" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder239" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder240" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder241" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder242" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder243" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder244" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder245" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder246" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder247" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder248" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder249" runat="server" EnableViewState="false"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder250" runat="server" EnableViewState="false"></asp:PlaceHolder>                                       
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblrow" runat="server">
                       
                            <asp:TableCell ID="tblCell" runat="server">
                                <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ></asp:Label>
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
                               <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="false">
                                    <table id="tblRefNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                    <tr>
                                    <td class="TDWidth" >
                                    <asp:Label SkinID="lblSkin"   ID="lblRefNo" runat="server" Text="Reference No"></asp:Label>
                                    </td>
                                    <td style="width:2%">:</td>
                                    <td>
                                    <asp:TextBox SkinID="txtSkin"   ID="txtRefNo" runat="server" ReadOnly="true" ></asp:TextBox>
                                    </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
                               <asp:Panel ID="pnlDateTimeOfVerification" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblDateTimeOfVerification" style="width:100%" runat="server">
                                    <tr>         
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDateTimeOfVerification" runat="server" Text="Date and Time Of Verification"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                       <asp:TextBox SkinID="txtSkin"  ID="txtDateOfVerification" runat="server" MaxLength="10" ></asp:TextBox>
                                       <img id="img3"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
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
                                    <table id="tblLanNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLanNo" runat="server" Text="Lan No./Ref No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLanNo" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDateAndTime" runat="server" Width="100%" Visible="false">
                                    <table id="tblDateAndTime" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDateAndTime" runat="server" Text="Date"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtDateAndTime" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVerifiersName" runat="server" Width="100%" Visible="false">
                                    <table id="tblVerifiersName" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblVerifiersName" runat="server" Text="Verifier's Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtVerifiersName" ReadOnly="false" runat="server" MaxLength="100" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
                                    <table id="tblAppName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server" Text="App Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAppName" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
                                    <table id="tblPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPersonContacted" runat="server" Text="Person Contacted"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPersonContacted" MaxLength="100" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRelationship" runat="server" Width="100%" Visible="false">
                                    <table id="tblRelationship" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRelationship" runat="server" Text="Relationship with applicant">
                                                </asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationship" MaxLength="100" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddress" runat="server" Width="100%" Visible="false">
                                    <table id="tblAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddress" runat="server" Text="Applicant Address"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddress"  MaxLength="500" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCity" runat="server" Width="100%" Visible="false">
                                    <table id="tblCity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCity" runat="server" Text="Applicant City"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtCity" MaxLength="100" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPincode" runat="server" Width="100%" Visible="false">
                                    <table id="tblPincode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPincode" runat="server" Text="Applicant Pincode"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtPincode" MaxLength="20" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLandmark" runat="server" Width="100%" Visible="false">
                                    <table id="tblLandmark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark / Street Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLandmark" MaxLength="500" runat="server"  Width="80%" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTelNo" runat="server" Width="100%" Visible="false">
                                    <table id="tblTelNo" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td class="TDWidth"  >
                                            <asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="TelNo"></asp:Label>
                                            </td><td style="width:2%">:</td>
                                            <td>
                                            <asp:TextBox SkinID="txtSkin"  ID="txtTelNo" runat="server" MaxLength="96" ></asp:TextBox>
                                           
                                            </td>
                                            </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMobileNoOrTypeOfPhone" runat="server" Width="100%" Visible="false">
                                    <table id="tblMobileNoOrTypeOfPhone" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMobileNoOrTypeOfPhone" runat="server" Text="Mobile No./Type Of Phone"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtMobileNoOrTypeOfPhone" MaxLength="100" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLoanAmount" runat="server" Width="100%" Visible="false">
                                    <table id="tblLoanAmount" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLoanAmount" runat="server" Text="Loan Amount/EMI range"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLoanAmount" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlUseOfLoan" runat="server" Width="100%" Visible="false">
                                    <table id="tblUseOfLoan" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblUseOfLoan" runat="server" Text="Use Of Loan"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtUseOfLoan" MaxLength="500" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProduct" runat="server" Width="100%" Visible="false">
                                    <table id="tblProduct" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblProduct" runat="server" Text="Product"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProduct" MaxLength="100" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLocationOfProduct" runat="server" Width="100%" Visible="false">
                                    <table id="tblLocationOfProduct" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLocationOfProduct" runat="server" Text="Location Of Product"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLocationOfProduct" MaxLength="100" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDateOfBirth" runat="server" Width="100%" Visible="false">
                                    <table id="tblDateOfBirth" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="30" ID="txtDateOfBirth" runat="server"></asp:TextBox>
                                                <img id="Img1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfBirth.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                [dd/mm/yyyy]
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMaritalStatus" runat="server" Width="100%" Visible="false">
                                    <table id="tblMaritalStatus" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMaritalStatus" runat="server" Text="Marital Status"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin"  ID="ddlMaritalStatus" runat="server"   AutoPostBack="false"> 
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Married</asp:ListItem>
                                                    <asp:ListItem>Single</asp:ListItem>
                                                    <asp:ListItem>Divorced</asp:ListItem>
                                                    <asp:ListItem>Widow</asp:ListItem>   
                                                </asp:DropDownList> 
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEducationBackground" runat="server" Width="100%" Visible="false">
                                    <table id="tblEducationBackground" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblEducationBackground" runat="server" Text="Education Background"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin"  ID="ddlEducationBackgroud" runat="server"   AutoPostBack="false">                     
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem >Under SSC</asp:ListItem>
                                                    <asp:ListItem >Undergraduate</asp:ListItem>
                                                    <asp:ListItem >Grad(Professional)</asp:ListItem>   
                                                    <asp:ListItem >Some College</asp:ListItem>
                                                    <asp:ListItem >Matric</asp:ListItem>
                                                    <asp:ListItem >Post graduate</asp:ListItem>
                                                    <asp:ListItem >Professional</asp:ListItem>
                                                    <asp:ListItem >10+2</asp:ListItem>
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
                                <asp:Panel ID="pnlFamilyDetails" runat="server" Width="100%" Visible="false">
                                    <table id="tblFamilyDetails" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblFamilyDetails" runat="server" Text="Family Details"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFamilyDetails" MaxLength="255" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlDetailsOfWorkingMembersSpouse" runat="server" Width="100%" Visible="false">
                                    <table id="tblDetailsOfWorkingMembersSpouse" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label6" runat="server" Text="Is spouse working"></asp:Label>
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
                                                <asp:Label SkinID="lblSkin" ID="Label7" runat="server" Text="Spouse Designation"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSpouseDesg" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlTotalFamilyIncome" runat="server" Width="100%" Visible="false">
                                    <table id="tblTotalFamilyIncome" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTotalFamilyIncome" runat="server" Text="Total Family Income"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtTotalFamilyIncome" MaxLength="50" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDetailsOfWorkingMembersOthers" runat="server" Width="100%" Visible="false">
                                    <table id="tblDetailsOfWorkingMembersOthers" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDetailsOfWorkingMembersOthers" runat="server"
                                                    Text="Details Of Working Members (Others)"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsOfWorkingMembersOthers" MaxLength="255"  runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLoanCancellation" runat="server" Width="100%" Visible="false">
                                    <table id="tblLoanCancellation" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLoanCancellation" runat="server" Text="Loan Cancellation"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlLoanCancellation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlMunicipalLimit" runat="server" Width="100%" Visible="false">
                                    <table id="Table7" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label9" runat="server" Text="Within Muncipipal Limits"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlMunicipalLimit" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAnyCreditCardsIfYesProvidNameandLimitonEach" runat="server" Width="100%"
                                    Visible="false">
                                    <table id="tblAnyCreditCardsIfYesProvidNameandLimitonEach" cellpadding="0" cellspacing="0"
                                        style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAnyCreditCardsIfYesProvidNameandLimitonEach" runat="server"
                                                    Text="Any Credit Cards? If Yes,Provid Name and Limit on Each"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAnyCreditCardsIfYesProvidNameandLimitonEach" MaxLength="500"
                                                    runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Credit card no"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtCreditCardNo" MaxLength="255"
                                                    runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI" runat="server"
                                    Width="100%" Visible="false">
                                    <table id="tblAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI" cellpadding="0"
                                        cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI"
                                                    runat="server" Text="Any Other Investment/Loans? If Yes,Provide Details Of Amount, Company and EMI"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI" MaxLength="500"
                                                    runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoofYearsatCurrentResidence" runat="server" Width="100%" Visible="false">
                                    <table id="tblNoofYearsatCurrentResidence" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTimeCurrResi" runat="server" Text="No of yrs at the Residence"></asp:Label>
                                        </td>
                                        <td style="width:2%">:</td>
                                        <td>
                                        <asp:TextBox SkinID="txtSkin"    ID="txtNoOfYrsAtCurrResi" runat="server" MaxLength="2"></asp:TextBox>
                                        &nbsp;Yrs&nbsp;
                                        <asp:TextBox SkinID="txtSkin"    ID="txtNoOfMthsAtCurrResi" runat="server"  MaxLength="2"></asp:TextBox>
                                        &nbsp;Mths
                                        </td>                                                     
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAreaOfHouse" runat="server" Width="100%" Visible="false">
                                    <table id="tblAreaOfHouse" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAreaOfHouse" runat="server" Text="Area Of House(Sq Ft)"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAreaOfHouse" MaxLength="200" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAssets" runat="server" Width="100%" Visible="false">
                                    <table id="tblAssets" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAssets" runat="server" Text="Assets"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>                                                
                                                <asp:CheckBoxList ID="chkAssets" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">                                                    
                                                    <asp:ListItem>TV</asp:ListItem>
                                                    <asp:ListItem>Refrigerator</asp:ListItem> 
                                                    <asp:ListItem>Stereo</asp:ListItem>
                                                    <asp:ListItem>Car</asp:ListItem>                    
                                                    <asp:ListItem>Washing Machine</asp:ListItem>                                                    
                                                    <asp:ListItem>Furniture seen</asp:ListItem>       
                                                    <asp:ListItem>Cooler</asp:ListItem>       
                                                    <asp:ListItem>Sofa</asp:ListItem>       
                                                    <asp:ListItem>PC</asp:ListItem>       
                                                    <asp:ListItem>Telephone</asp:ListItem>    
                                                    <asp:ListItem>MUSIC SYSTEM</asp:ListItem>    
                                                    <asp:ListItem>AC</asp:ListItem>  
                                                    <asp:ListItem>CUP BOARD</asp:ListItem>  
                                                    <asp:ListItem>BED</asp:ListItem>  
                                                    <asp:ListItem>Wall Unit</asp:ListItem>
                                                    <asp:ListItem>Carpet</asp:ListItem>
                                                    <asp:ListItem>Dining Table</asp:ListItem>
                                                    <asp:ListItem>Two Wheeler</asp:ListItem>
                                                    <asp:ListItem>Four Wheeler</asp:ListItem>
                                                    <asp:ListItem>Others</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOtherAssets" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDetailsoffurnitureSeen" runat="server" Width="100%" Visible="false">
                                    <table id="tblDetailsoffurnitureSeen" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDetailsoffurnitureSeen" runat="server" Text="Details of furniture Seen"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsoffurnitureSeen" MaxLength="500" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlAssetsPurchase" runat="server" Width="100%" Visible="false">
                                    <table id="Table5" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="For whom is the asset begin purchased ?"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAssetsPurchase" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label5" runat="server" Text="Where will asset be located ?"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAssetsLocated" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlOwnershipOfResidence" runat="server" Width="100%" Visible="false">
                                    <table id="tblOwnershipOfResidence" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOwnershipOfResidence" runat="server" Text="Ownership Of Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtOwnershipOfResidence" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label21" runat="server" Text="Actual Owner of Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnershipOfResidence" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Hirer</asp:ListItem>
                                                    <asp:ListItem>Other Specify</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlApplicantLivesWith" runat="server" Width="100%" Visible="false">
                                    <table id="tblApplicantLivesWith" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApplicantLivesWith" runat="server" Text="Applicant lives with"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantLivesWith" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Parents</asp:ListItem>
                                                    <asp:ListItem>Spouse</asp:ListItem>
                                                    <asp:ListItem>Relatives</asp:ListItem>
                                                    <asp:ListItem>Friends</asp:ListItem>
                                                    <asp:ListItem>Collegue</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOtherApplicantLivesWith" runat="server"></asp:TextBox>
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
                                
                                <asp:Panel ID="pnlDSA" runat="server" Width="100%" Visible="false">
                                    <table id="tblDSA" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDSA" runat="server" Text="DSA"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtDSA" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlTenure" runat="server" Width="100%" Visible="false">
                                    <table id="tblTenure" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTenure" runat="server" Text="Tenure"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtTenure" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMonths" runat="server" Width="100%" Visible="false">
                                    <table id="tblMonths" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMonths" runat="server" Text="Months"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="10" ID="txtMonths" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlType" runat="server" Width="100%" Visible="false">
                                    <table id="tblType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblType" runat="server" Text="Ownership Type"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Ownership</asp:ListItem>
                                                    <asp:ListItem >Parental</asp:ListItem>
                                                    <asp:ListItem >Self Owned</asp:ListItem>
                                                    <asp:ListItem >Owned by Relative</asp:ListItem>
                                                    <asp:ListItem >Owned by Friend</asp:ListItem>
                                                    <asp:ListItem >Owned by Parents</asp:ListItem>
                                                    <asp:ListItem >Bachelor Accomodation</asp:ListItem>
                                                    <asp:ListItem >Rented</asp:ListItem>
                                                    <asp:ListItem >Company Accomodation</asp:ListItem>
                                                    <asp:ListItem >Paying Guest</asp:ListItem>
                                                    <asp:ListItem >Lodging</asp:ListItem>
                                                    <asp:ListItem >Co Provided</asp:ListItem>
                                                    <asp:ListItem >Govt,Quaters</asp:ListItem>
                                                    <asp:ListItem >Pagadi</asp:ListItem>
                                                    <asp:ListItem >Lease</asp:ListItem>
                                                    <asp:ListItem >Ancestral</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOtherType" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameontheSocietyAddressboard" runat="server" Width="100%" Visible="false">
                                    <table id="tblNameontheSocietyAddressboard" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameontheSocietyAddressboard" runat="server" Text="Name on the Society Address board"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtNameontheSocietyAddressboard" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNamePlateonDoor" runat="server" Width="100%" Visible="false">
                                    <table id="tblNamePlateonDoor" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNamePlateonDoor" runat="server" Text="Name Plate on Door"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateonDoor" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlOwnershipDetails" runat="server" Width="100%" Visible="false">
                                    <table id="tblOwnershipDetails" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOwnershipDetails" runat="server" Text="Ownership Details"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtOwnershipDetails" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
<%--                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label22" runat="server" Text="Proof Of Ownership"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnershipDetails" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Electricity Bill</asp:ListItem>
                                                    <asp:ListItem>Telephone Bill</asp:ListItem>                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="false">
                                    <table id="tblPermanentAddress" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtPermanentAddress" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlNumberofRooms" runat="server" Width="100%" Visible="false">
                                    <table id="tblNumberofRooms" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNumberofRooms" runat="server" Text="Number of Rooms / Flat"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNumberofRooms" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlApproximateValue" runat="server" Width="100%" Visible="false">
                                    <table id="tblApproximateValue" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApproximateValue" runat="server" Text="Approximate Value"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtApproximateValue" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlBachelorAccomodation" runat="server" Width="100%" Visible="false">
                                    <table id="tblBachelorAccomodation" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblBachelorAccomodation" runat="server" Text="Bachelor Accomodation"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtBachelorAccomodation" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="false">
                                    <table id="tblLocality" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLocality" runat="server" Text="Locality"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlLocality" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Posh</asp:ListItem>
                                                    <asp:ListItem>Upper Middle Class</asp:ListItem>
                                                    <asp:ListItem>Lower Middle Class</asp:ListItem>
                                                    <asp:ListItem>Middle Class</asp:ListItem>
                                                    <asp:ListItem>Lower Class</asp:ListItem>
                                                    <asp:ListItem>Poor</asp:ListItem>
                                                    <asp:ListItem>Slum</asp:ListItem>
                                                    <asp:ListItem>Residential</asp:ListItem>
                                                    <asp:ListItem>Commercial</asp:ListItem>
                                                    <asp:ListItem>Under Developed</asp:ListItem>
                                                    <asp:ListItem>Residential-cum-commercial</asp:ListItem>
                                                    <asp:ListItem>Village area</asp:ListItem>
                                                    <asp:ListItem>Negative Area</asp:ListItem>
                                                    <asp:ListItem>Hilly Tekdi</asp:ListItem>
                                                    <asp:ListItem>Communited Dominated</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Satisfactory</asp:ListItem>
                                                    <asp:ListItem>Bad</asp:ListItem>
                                                    <asp:ListItem>Small/Medium sized shops</asp:ListItem>
                                                    <asp:ListItem>Big Housing Complex</asp:ListItem>
                                                    <asp:ListItem>Chawl Area</asp:ListItem>
                                                    <asp:ListItem>Under Developed</asp:ListItem>
                                                    <asp:ListItem>Vacant Sites</asp:ListItem>
                                                    <asp:ListItem>Other Buildings</asp:ListItem>
                                                    <%--END--%>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOtherLocality" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVehicleCurrenlyUsed" runat="server" Width="100%" Visible="false">
                                    <table id="tblVehicleCurrenlyUsed" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblVehicleCurrenlyUsed" runat="server" Text="Vehicles currently used"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtVehicleCurrenlyUsed" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVehiclesFinancedNFinancerName" runat="server" Width="100%" Visible="false">
                                    <table id="tblVehiclesFinancedNFinancerName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblVehiclesFinancedNFinancerName" runat="server" Text="Vehicles financed & Financer's Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="500" ID="txtVehiclesFinancedNFinancerName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <%--add new code scb hl releted 22/03/2010--%>
                                
                                
                                <%--end code--%>
                                
                <%--////////////Add by santosh shelar add 3 more value in ddl 23/08/08////////--%>
                                <asp:Panel ID="pnlDescribeExteriorPremises" runat="server" Width="100%" Visible="false">
                                    <table id="tblDescribeExteriorPremises" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDescribeExteriorPremises" runat="server" Text="Describe Exterior of Premises"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>                                                
                                                <asp:DropDownList ID="ddlDescribeExteriorPremises" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Plastered</asp:ListItem>
                                                    <asp:ListItem>Brick wall</asp:ListItem>
                                                    <asp:ListItem>Mud/Thatched wall</asp:ListItem> 
                                                    <asp:ListItem>Excellent</asp:ListItem> 
                                                    <asp:ListItem>Good</asp:ListItem> 
                                                    <asp:ListItem>Average</asp:ListItem> 
                                                    <asp:ListItem>Poor</asp:ListItem>            
                                                    <asp:ListItem>Mud/Thatched wall</asp:ListItem> 
                                                    <asp:ListItem>Small Tiles</asp:ListItem>                                                
                                                    <asp:ListItem>Catepeted</asp:ListItem>
                                                    <asp:ListItem>Tiled</asp:ListItem>                                                
                                                    <asp:ListItem>Marble</asp:ListItem>
                                                    <asp:ListItem>Mosiac</asp:ListItem>
                                                    <asp:ListItem>Cement</asp:ListItem>
                                                    <asp:ListItem>Vitrified Tiles</asp:ListItem>                                        
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDescribeInteriorPremises" runat="server" Width="100%" Visible="false">
                                    <table id="tblDescribeInteriorPremises" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDescribeInteriorPremises" runat="server" Text="Describe Interior of Premises"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlDescribeInteriorPremises" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Excellent</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Fair</asp:ListItem>
                                                    <asp:ListItem>Poor</asp:ListItem>                                                    
                                                    <asp:ListItem>Painted</asp:ListItem>
                                                    <asp:ListItem>Unpainted</asp:ListItem>
                                                    <asp:ListItem>Plastered</asp:ListItem>
                                                    <asp:ListItem>Unplastered</asp:ListItem>
                                                    <asp:ListItem>Chuna</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfNeighbour1" runat="server" Width="100%" Visible="false">
                                    <table id="tblNameOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameOfNeighbour1" runat="server" Text="Name Of Neighbour 1"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtNameOfNeighbour1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddressOfNeighbour1" runat="server" Width="100%" Visible="false">
                                    <table id="tblAddressOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddressOfNeighbour1" runat="server" Text="Address Of Neighbour"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtAddressOfNeighbour1" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDoesTheApplicantStayHere1" runat="server" Width="100%" Visible="false">
                                    <table id="tblDoesTheApplicantStayHere1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDoesTheApplicantStayHere1" runat="server" Text="Does the Applicant Stay Here"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                            <asp:DropDownList ID="ddlDoesTheApplicantStayHere1" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>                                                
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFinanceVisible" runat="server" Width="100%" Visible="false">
                                    <table id="Table6" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label8" runat="server" Text="Is the item being financed visible ?"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                            <asp:DropDownList ID="ddlFinanceVisible" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>                                                
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlStatusofResidence1" runat="server" Width="100%" Visible="false">
                                    <table id="tblStatusofResidence1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblStatusofResidence1" runat="server" Text="Status of Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlStatusofResidence1" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Parent/Relative Owned</asp:ListItem>
                                                    <asp:ListItem>Rented/Co.Provided</asp:ListItem>
                                                    <asp:ListItem>Self Owned</asp:ListItem>
                                                    <asp:ListItem>PG Accomodation</asp:ListItem>
                                                    <asp:ListItem>Co.Provided</asp:ListItem>
                                                    <asp:ListItem>Govt.Quarters</asp:ListItem>
                                                    <asp:ListItem>Company Acco</asp:ListItem>
                                                    <asp:ListItem>Owned by Friend</asp:ListItem>
                                                    <asp:ListItem>Owned by Relative</asp:ListItem>
                                                    <asp:ListItem>Finance Co</asp:ListItem>
                                                    <asp:ListItem>Captive</asp:ListItem>
                                                    <asp:ListItem>HUF</asp:ListItem>
                                                    <asp:ListItem>Partnership</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMonthsOfStayAtresidence1" runat="server" Width="100%" Visible="false">
                                    <table id="tblMonthsOfStayAtresidence1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMonthsOfStayAtresidence1" runat="server" Text="Months of Stay at residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtMonthsOfStayAtresidence1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCommentsOfNeighbour1" runat="server" Width="100%" Visible="false">
                                    <table id="tblCommentsOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCommentsOfNeighbour1" runat="server" Text="Comments of Neighbour 1"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 1000);" MaxLength="1000" Width="80%" ID="txtCommentsOfNeighbour1" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfNeighbour2" runat="server" Width="100%" Visible="false">
                                    <table id="tblNameOfNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameOfNeighbour2" runat="server" Text="Name Of Neighbour 2"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" Width="80%" ID="txtNameOfNeighbour2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddressOfNeighbour2" runat="server" Width="100%" Visible="false">
                                    <table id="tblAddressOfNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddressOfNeighbour2" runat="server" Text="Address Of Neighbour"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtAddressOfNeighbour2" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDoestheApplicantStayHere2" runat="server" Width="100%" Visible="false">
                                    <table id="tblDoestheApplicantStayHere2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDoestheApplicantStayHere2" runat="server" Text="Does the Applicant Stay Here"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                            <asp:DropDownList ID="ddlDoestheApplicantStayHere2" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>                                                   
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlStatusofResidence2" runat="server" Width="100%" Visible="false">
                                    <table id="tblStatusofResidence2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblStatusofResidence2" runat="server" Text="Status of Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlStatusofResidence2" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Parent/Relative Owned</asp:ListItem>
                                                    <asp:ListItem>Rented/Co.Provided</asp:ListItem>
                                                    <asp:ListItem>Self Owned</asp:ListItem>
                                                    <asp:ListItem>PG Accomodation</asp:ListItem>
                                                    <asp:ListItem>Govt.Quarters</asp:ListItem>
                                                    <asp:ListItem>Pugree System</asp:ListItem>
                                                    <asp:ListItem>Co.Provided</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>        
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMonthsofStayatresidence2" runat="server" Width="100%" Visible="false">
                                    <table id="tblMonthsofStayatresidence2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMonthsofStayatresidence2" runat="server" Text="Months of Stay at residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtMonthsofStayatresidence2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCommentsofNeighbour2" runat="server" Width="100%" Visible="false">
                                    <table id="tblCommentsofNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCommentsofNeighbour2" runat="server" Text="Comments of Neighbour"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 255);" Width="80%" MaxLength="255" ID="txtCommentsofNeighbour2" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTypeOfAccmodation" runat="server" Width="100%" Visible="false">
                                    <table id="tblTypeOfAccmodation" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTypeOfAccmodation" runat="server" Text="Type of Accmodation"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtTypeOfAccmodation" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlEntryPermitted" runat="server" Width="100%" Visible="false">
                                    <table id="tblEntryPermitted" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblEntryPermitted" runat="server" Text="Entry Permitted"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                 <asp:DropDownList ID="ddlEntryPermitted" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                    <asp:ListItem>Door Locked</asp:ListItem>
                                                </asp:DropDownList>                                                
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIdentityProofSeen" runat="server" Width="100%" Visible="false">
                                    <table id="tblIdentityProofSeen" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblIdentityProofSeen" runat="server" Text="Identity Proof Seen"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlIdentityProofSeen" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>   
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlApplicantIncome" runat="server" Width="100%" Visible="false">
                                    <table id="tblApplicantIncome" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApplicantIncome" runat="server" Text="Applicant's Income"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtApplicantIncome" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfCompanyWhereAppEmployed" runat="server" Width="100%" Visible="false">
                                    <table id="tblNameOfCompanyWhereAppEmployed" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameOfCompanyWhereAppEmployed" runat="server"
                                                    Text="Name of Company where Applicant is Employed"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="300" ID="txtNameOfCompanyWhereAppEmployed" runat="server"
                                                    ></asp:TextBox>
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
                                            <asp:DropDownList ID="ddlPurposeOfLoanTaken" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>PL</asp:ListItem>
                                                    <asp:ListItem>HL</asp:ListItem>
                                                    <asp:ListItem>Auto</asp:ListItem>                                                    
                                                    <asp:ListItem>Credit Card</asp:ListItem>                                                    
                                                </asp:DropDownList>   
                                                <%--<asp:TextBox SkinID="txtSkin" Width="40%" MaxLength="255" ID="txtPurposeOfLoanTaken" runat="server"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlOtherSourceOfIncome" runat="server" Width="100%" Visible="false">
                                    <table id="tblOtherSourceOfIncome" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOtherSourceOfIncome" runat="server" Text="Other Source of Income"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtOtherSourceOfIncome" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlOtherInvestment" runat="server" Width="100%" Visible="false">
                                    <table id="tblOtherInvestment" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOtherInvestment" runat="server" Text="Other Investment"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                 <asp:DropDownList ID="ddlOtherInvestment" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>FD</asp:ListItem>
                                                    <asp:ListItem>Shares</asp:ListItem>
                                                    <asp:ListItem>Mutual Funds</asp:ListItem>                                                    
                                                </asp:DropDownList>       
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlColourOfDoor" runat="server" Width="100%" Visible="false">
                                    <table id="tblColourOfDoor" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblColourOfDoor" runat="server" Text="Colour of Door"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtColourOfDoor" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRoomType" runat="server" Width="100%" Visible="false">
                                    <table id="tblRoomType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRoomType" runat="server" Text="Room Type / House Size"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoomType" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>a</asp:ListItem>
                                                    <asp:ListItem>b</asp:ListItem>
                                                    <asp:ListItem>1 room</asp:ListItem>
                                                    <asp:ListItem>1 room Kitchen with Loft</asp:ListItem>
                                                    <asp:ListItem>3 Bed room Hall Kitchen</asp:ListItem> 
                                                    <asp:ListItem>V Small</asp:ListItem>
                                                    <asp:ListItem>Small</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Large</asp:ListItem>                                                   
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTypeOfHouse" runat="server" Width="100%" Visible="false">
                                    <table id="tblTypeOfHouse" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTypeOfHouse" runat="server" Text="Type of House / Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlTypeOfHouse" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Bungalow</asp:ListItem>
                                                    <asp:ListItem>Flat</asp:ListItem>
                                                    <asp:ListItem>Individual House</asp:ListItem>
                                                    <asp:ListItem>Part of Individual House</asp:ListItem><%--New added/Updated for CHOLA--%>                                                    <asp:ListItem>Standing Chawl/Janata Flat</asp:ListItem>
                                                    <asp:ListItem>Standing Chawl/Janata Flat</asp:ListItem>
                                                    <asp:ListItem>Sitting Chawl/Hutment</asp:ListItem>
                                                    <asp:ListItem>Slum</asp:ListItem>
                                                    <asp:ListItem>Staff Quarters</asp:ListItem>
                                                    <asp:ListItem>Lodge/Hotel</asp:ListItem>
                                                    <asp:ListItem>Annexe To House</asp:ListItem>
                                                    <asp:ListItem>Multi-Tenant House</asp:ListItem>
                                                    <asp:ListItem>Small Independent House</asp:ListItem>
                                                    <asp:ListItem>Large Independent House</asp:ListItem>
                                                    <asp:ListItem>Chawl</asp:ListItem>
                                                    <asp:ListItem>kothi</asp:ListItem>
                                                    <asp:ListItem>Temporary Shed</asp:ListItem>
                                                    <asp:ListItem>Chawl Type Bldg with Common Toilet</asp:ListItem>
                                                    <asp:ListItem>Small unit within a house (Garage/Varsati est)</asp:ListItem> 
                                                    <asp:ListItem>Cottage</asp:ListItem>
                                                    <asp:ListItem>Row House</asp:ListItem>
                                                    <asp:ListItem>Pukka House</asp:ListItem>
                                                    <asp:ListItem>LIG</asp:ListItem>
                                                    <asp:ListItem>HIG</asp:ListItem>
                                                    <asp:ListItem>MIG</asp:ListItem>
                                                    <asp:ListItem>Appartment</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtOtherTypeOfHouse" Width="80%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVehicleOwnership" runat="server" Width="100%" Visible="false">
                                    <table id="tblVehicleOwnership" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblVehicleOwnership" runat="server" Text="Vehicles Ownership"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtVehicleOwnership" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAnyOtherLoanOnApplicantName" runat="server" Width="100%" Visible="false">
                                    <table id="tblAnyOtherLoanOnApplicantName" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAnyOtherLoanOnApplicantName" runat="server" Text="Any Other Loan on Applicant Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtAnyOtherLoanOnApplicantName" runat="server"
                                                    ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlResiAddIsInNegativeArea" runat="server" Width="100%" Visible="false">
                                    <table id="tblResiAddIsInNegativeArea" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblResiAddIsInNegativeArea" runat="server" Text="Residence address is in the Negative Area as per Negative Area List"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlResiAddIsInNegativeArea" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                    <asp:ListItem>Approved Pin code</asp:ListItem>
                                                    <asp:ListItem>HRA</asp:ListItem>
                                                    <asp:ListItem>Negative Pin Code</asp:ListItem>
                                                    <asp:ListItem>Negative Area</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlApproachToResidence" runat="server" Width="100%" Visible="false">
                                    <table id="tblApproachToResidence" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApproachToResidence" runat="server" Text="Approach To Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtApproachToResidence" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTypeOfRoof" runat="server" Width="100%" Visible="false">
                                    <table id="tblTypeOfRoof" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTypeOfRoof" runat="server" Text="Type of Roof"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtTypeOfRoof" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTelCDRomCheck" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTelCDRomCheck" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTelCDRomCheck" runat="server" Text="Telephone CD Rom check/Credit Card"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTelCDRomCheck" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                    <asp:ListItem>Own</asp:ListItem>
                                                    <asp:ListItem>Comp Provided</asp:ListItem>
                                                    <asp:ListItem>PP</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLocationOfHouse" runat="server" Width="100%" Visible="false">
                                    <table id="tblLocationOfHouse" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLocationOfHouse" runat="server" Text="Location of House"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtLocationOfHouse" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlStandardOfLiving" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblStandardOfLiving" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblStandardOfLiving" runat="server" Text="Standard of Living / General appearance of the House/Reputation In Neighbourhood"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStandardOfLiving" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>High</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Average</asp:ListItem>
                                                    <asp:ListItem>Fair</asp:ListItem>
                                                    <asp:ListItem>Poor</asp:ListItem>                                                    
                                                    <asp:ListItem>Bad</asp:ListItem>                                                    
                                                    <asp:ListItem>Excellent</asp:ListItem>                                                    
                                                    <asp:ListItem>Neutral</asp:ListItem>                                                    
                                                    <asp:ListItem>No Idea</asp:ListItem>                                                    
                                                    <asp:ListItem>Below Average</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlWalls" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblWalls" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblWalls" runat="server" Text="Walls"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtWalls" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>     
                                
                                <asp:Panel ID="pnlBackNum" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblBackNum" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblBackNum" runat="server" Text="Back Office Number"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtBackNum" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>   
                                                            
                                <asp:Panel ID="pnlFlooring" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFlooring" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblFlooring" runat="server" Text="Flooring"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtFlooring" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIsAddOfApplicantName" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblIsAddOfApplicantName" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblIsAddOfApplicantName" runat="server" Text="Is the address of Applicant Name?"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIsAddOfApplicantName" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoOfMember" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfMember" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNoOfMember" runat="server" Text="No.of Members/Dependent"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNoOfMember" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlAgeOfApplicant" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAgeOfApplicant" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAgeOfApplicant" runat="server" Text="Age of Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAgeOfApplicant" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameAddressOfThirdParty" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblNameAddressOfThirdParty"
                                        style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameAddressOfThirdParty" runat="server" Text="Name & address of third party"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtNameAddressOfThirdParty" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <%--add new code for deutsch bank releted--%>
                                <asp:Panel ID="pnlOthFeed" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblOthFeed"  style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOthFeed" runat="server" Text="Any other feedback :"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOthFeed" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCustPrev" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblCustPrev" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCustPrev" runat="server" Text="Did the customer apply previously:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlCustPrev" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                    <asp:Panel ID="pnlDatePrev" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDatePrev"  style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDatePrev" runat="server" Text="Date of Previous FI:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDatePrev" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTranType" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTranType" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTranType" runat="server" Text="TYPE OF TRANSACTION:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTranType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>PURCHASE</asp:ListItem>
                                                    <asp:ListItem>CONSTRUCT</asp:ListItem>
                                                    <asp:ListItem>EXTEND</asp:ListItem>
                                                    <asp:ListItem>RENOVATE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPropBought" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblPropBought" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPropBought" runat="server" Text="Property to be bought for:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlPropBought" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Self</asp:ListItem>
                                                    <asp:ListItem>Parents</asp:ListItem>
                                                    <asp:ListItem>Children</asp:ListItem>
                                                    <asp:ListItem>Employee</asp:ListItem>
                                                    <asp:ListItem>Rent</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRelantionProp" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRelantionProp" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRelantionProp" runat="server" Text="Relationship, If any with builder / Seller from whom property is being purchased:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRelantionProp" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlOtherProp" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblOtherProp"  style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOtherProp" runat="server" Text="Any other property owned by Applicant:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherProp" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlOffDeci" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblOffDeci" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblOffDeci" runat="server" Text="CAU officers decision:"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
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
                                <%--end code--%>
                                
                                <%--New panel added by kamal matekar for Barclays finance PL PDF Format--%>
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
                                <asp:Panel ID="pnlCoAppName" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblCoAppName" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCoAppName" runat="server" Text="Name of the Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtCoAppName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameVerifiedFrom" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameVerifiedFrom" runat="server" Text="Name Verified From"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlNameVerifiedForm" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem>NAMEPLATE</asp:ListItem>
                                                <asp:ListItem>WATCHMAN</asp:ListItem>
                                                <asp:ListItem>NEIGHBOUR</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlApplicantCategory" runat="server" Width="100%" Visible="False">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantCategory" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td>
                                        <asp:Label ID="lblEmployeeDetails" runat="server" SkinID="lblSkin" Text="Employment Details"></asp:Label>
                                        </td>
                                         <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtEmpDet" runat="server" Width="80%"  SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApplicantCategory" runat="server" Text="Applicant Category"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlApplicantCategory" runat="server" SkinID="ddlSkin">
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
                                <%---Started by kamal matekar for Federal Finance--%>
                                <asp:Panel ID="pnlGeneralInformationCo_Applicant" runat="server" Width="100%" Visible="False">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralInformationCo_Applicant" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td colspan="3" align="center">
                                        <asp:Label ID="lblCoApplicant" runat="server" SkinID="lblSkin" Text="GENERAL INFORMATION-CO-APPLICANT"></asp:Label>
                                        </td>
                                        </tr>
                                      <%--  <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCoAppName" runat="server" Text="Name of Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtCoAppName" Width="60%"  runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblResiAddCoApp" runat="server" Text="Residence Add Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtResiAddCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblRelationshipCoApp" runat="server" Text="Relationship Co-Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtRelationshipCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
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
                                <asp:Panel ID="pnlDocumentSighted" runat="server" Width="100%" Visible="False">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDocumentSighted" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td colspan="3" align="center">
                                        <asp:Label ID="lblDocumentSighted" runat="server" SkinID="lblSkin" Text="DOCUMENTS SIGHTED"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDLNo" runat="server" Text="DL NO"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtDLNo" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblEillBillResi" runat="server" Text="Eill Bill Resi"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtEillBillResi" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPerAccBankName" runat="server" Text="Personal Account Bank Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtPerAccBankName" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblBranch" runat="server" Text="Branch"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtBranch" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPanNo" runat="server" Text="Pan No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtPanNo" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTeleNo" runat="server" Text="Tele Bill"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtTeleBill" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblODLimit" runat="server" Text="OD Limit"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtODLimit" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAcNo" runat="server" Text="A/c No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtAcNo" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblVoterId" runat="server" Text="Voter ID card"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtVoterId" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRationCard" runat="server" Text="Ration Card"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtRationCard" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                     </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlValueRentAmountFlats" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblValueRentAmountFlat" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblValueRentAmountFlat" runat="server" Text="Value or Rent Amount of Flats"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtValueRentAmountFlat" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                  <asp:Panel ID="pnlLevelofMaintained" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblLevelofMaintained" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLevelofMaintained" runat="server" Text="Level of Maintained"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtLevelofMaintained" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlPolitics" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblPolitics" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPolitics" runat="server" Text="If Any Connection With Politics /Polics /Law"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtPolitics" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAssessmentOff" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAssessmentOff" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAssessmentOff" runat="server" Text="Assessment Off"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAssessmentOff" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRepoCollBy" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRepoCollBy" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRepoCallBy" runat="server" Text="Repo Coll By"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtRepoCallBy" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRepoCollStatus" runat="server" Text="RepoCollBy_Status"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtRepoCallStatus" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTVRDONEBY" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTVRDONEBY" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTVRDONEBY" runat="server" Text="TVR Done By"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtTVRDONEBY" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTVRStatus" runat="server" Text="TVR_Status"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtTVRStatus" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlQcDoneBy" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblQcDoneBy" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblQcDoneBy" runat="server" Text="QC Done By"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtQcDoneBy" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblQcStatus" runat="server" Text="QC_Status"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtQcStatus" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlApprovingOfficer" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblApprovingOfficer" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblApprovingOfficer" runat="server" Text="Approving Officer"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtApprovingOfficer" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlContentWriter" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblContentWriter" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblContentWriter" runat="server" Text="Content Writer"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtContentWriter" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlReportPreparedBy" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblReportPreparedBy" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblReportPreparedBy" runat="server" Text="Report Prepared By"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtReportPreparedBy" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlTVRDetails" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTVRDetails" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTVRDetails" runat="server" Text="TVR Details"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtTVRDetails" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlpersonaldetailsCoApp" runat="server" Width="100%" Visible="False">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td colspan="3" align="center">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="PERSONAL DETAILS-CO-APPLICANT"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMaritalStatusCoApp" runat="server" Text="Marital Status Co_Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                               <asp:TextBox ID="txtMaritalStatusCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDOBCoApp" runat="server" Text="DOB Co_Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDOBCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblQualificationCoApp" runat="server" Text="Qualification Co_Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtQualificationCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNoOfDeptCoApp" runat="server" Text="No Of Dependents Co_Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtNoOfDependentCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblFamilyStructureCoApp" runat="server" Text="Family Structure Co_Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtFamilyStrCoApp" runat="server" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                       </table>
                                </asp:Panel>
                                
                                
                                <%--Ended by kamal matekar--%>
                                
                                <%--added by kamal matekar for Hdfc_HL_RL Residence--%>
                                 <asp:Panel ID="pnlFamilyProperty" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFamilyProperty" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblFamilyProperty" runat="server" Text="Family Property"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtFamilyProperty" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>    
                                </asp:Panel>
                                <asp:Panel ID="pnlSupervisorName" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorName" style="width:100%" runat="server">
                                     <tr>
                                        <td class="TDWidth"  >
                                             <asp:Label SkinID="lblSkin" ID="lblSupervisorName" runat="server" Text="Supervisor Name"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                     <td>
                                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtSupervisorName" runat="server" MaxLength="100" ></asp:TextBox>
                                        </td>
                                     </tr>
                                    </table>
                                </asp:Panel>  
                                 <asp:Panel ID="pnlBankDetail" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblBankDetail" style="width:100%" runat="server">
                                     <tr>
                                        <td class="TDWidth"  >
                                             <asp:Label SkinID="lblSkin" ID="lblBankDetail" runat="server" Text="Bank Details"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                     <td>
                                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBankDetail" runat="server" MaxLength="100" ></asp:TextBox>
                                        </td>
                                     </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlCreditCardType" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblCreditCardType" style="width:100%" runat="server">
                                     <tr>
                                        <td class="TDWidth"  >
                                             <asp:Label SkinID="lblSkin" ID="lblCreditCardType" runat="server" Text="Type"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                     <td>
                                        <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCreditCardType" runat="server" MaxLength="100" ></asp:TextBox>
                                        </td>
                                     </tr>
                                    </table>
                                </asp:Panel>  
                                                            
                                <%--Ended for Hdfc_HL_RL--%>
                                
                                
                                <asp:Panel ID="pnlTimeWhenAppIsInHome" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTimeWhenAppIsInHome" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTimeWhenAppIsInHome" runat="server" Text="Time when applicant is in home"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtTimeWhenAppIsInHome" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlThirdPartyComment" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyComment" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblThirdPartyComment" runat="server" Text="Third party Comment"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="1000" onkeyPress="ValidateTextLength('third party comment', this, 1000);" ID="txtThirdPartyComment" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddressProofSighted" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblAddressProofSighted" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddressProofSighted" runat="server" Text="Address Proof sighted"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressProofSighted" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <%--        Update by Manoj--%>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label29" runat="server" Text="Details"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtResDetails" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <%--  Ended by Manoj--%>  
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTalliesWithCurrentAddress" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTalliesWithCurrentAddress"
                                        style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTalliesWithCurrentAddress" runat="server" Text="Tallies with the current Address"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTalliesWithCurrentAddress" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTypeOfAddProof" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAddProof" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTypeOfAddProof" runat="server" Text="Type of Add. Proof"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtTypeOfAddProof" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlResiOCL" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblResiOCL" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblResiOCL" runat="server" Text="Resi OCL"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                 <asp:DropDownList SkinID="ddlSkin" ID="ddlResiOCL" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlIsAffilatedToPoliticalParty" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblIsAffilatedToPoliticalParty"
                                        style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblIsAffilatedToPoliticalParty" runat="server" Text="Is he affilated to any political party"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIsAffilatedToPoliticalParty" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
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
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtProfile" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddressConfirmed" runat="server" Width="100%" Visible="false">
                                    <table id="tblAddressConfirmed" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddressConfirmed" runat="server" Text="Address Confirmed"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlAddressConfirmed" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlHowCooperativeCustomer" runat="server" Width="100%" Visible="false">
                                    <table id="tblHowCooperativeCustomer" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblHowCooperativeCustomer" runat="server" Text="How Co-operative is the customer"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlHowCooperativeCustomer" runat="server" AutoPostBack="false"
                                                    SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEaseOfLocation" runat="server" Width="100%" Visible="false">
                                    <table id="tblEaseOfLocation" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblEaseOfLocation" runat="server" Text="Ease of Location/Locating address"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlEaseOfLocation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Easily Accessible</asp:ListItem>
                                                    <asp:ListItem>Difficult</asp:ListItem>
                                                    <asp:ListItem>Very Difficult</asp:ListItem>
                                                    <asp:ListItem>Not Found</asp:ListItem>
                                                    <asp:ListItem>Untraceable</asp:ListItem>
                                                    <asp:ListItem>Need Assistance</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOtherEaseOfLocation" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               <!--Add new fields-->
                                <asp:Panel ID="pnlAgencyName" runat="server" Width="100%" Visible="false">
                                    <table id="tblAgencyName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAgencyName" runat="server" Text="Item/Agency Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtAgencyName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               <asp:Panel ID="pnlAccessibility" runat="server" Width="100%" Visible="false">
                                    <table id="tblAccessibility" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAccessibility" runat="server" Text="Accessibility / Approch to Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlAccessibility" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>By All Means</asp:ListItem>
                                                    <asp:ListItem>By Two wheeler only</asp:ListItem>
                                                    <asp:ListItem>By Foot only</asp:ListItem>
                                                    <asp:ListItem>Tamac Road-Car Approach</asp:ListItem>
                                                    <asp:ListItem>Easily accessible</asp:ListItem>
                                                    <asp:ListItem>Difficult</asp:ListItem>
                                                    <asp:ListItem>Untraceable</asp:ListItem>
                                                    <asp:ListItem>Kaccharoad</asp:ListItem>
                                                    <asp:ListItem>Congested Street-On Foot Approach</asp:ListItem>
                                                  <%-- New added/Updated for CHOLA--%>
                                                    <asp:ListItem>Cement Road</asp:ListItem>
                                                    <asp:ListItem>Pukka Road</asp:ListItem>
                                                    <asp:ListItem>Tar Road</asp:ListItem>
                                                    <asp:ListItem>Red Sand Road</asp:ListItem><%--END--%>                                                    
                                                 </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               <asp:Panel ID="pnlEntranceMotorable" runat="server" Width="100%" Visible="false">
                                    <table id="tblEntranceMotorable" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblEntranceMotorable" runat="server" Text="Entrance Motorable"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlEntranceMotorable" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               <asp:Panel ID="pnlSocietyBoardSighted" runat="server" Width="100%" Visible="false">
                                    <table id="tblSocietyBoardSighted" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblSocietyBoardSighted" runat="server" Text="Society Board sighted"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlSocietyBoardSighted" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               <asp:Panel ID="pnlMothersName" runat="server" Width="100%" Visible="false">
                                    <table id="tblMothersName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblMothersName" runat="server" Text="Mother's Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtMothersName" Width="80%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddressOfCompany" runat="server" Width="100%" Visible="false">
                                    <table id="tblAddressOfCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddressOfCompany" runat="server" Text="Address of company"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAddressOfCompany" Width="80%" runat="server"></asp:TextBox>
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
                                                    <asp:ListItem>Doubtful</asp:ListItem>        
                                                    <asp:ListItem>Trying to Impress</asp:ListItem> 
                                                    <asp:ListItem>Arrogant</asp:ListItem>                                            
                                                </asp:DropDownList>
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
                                           <asp:TextBox SkinID="txtSkin" onkeyPress="ValidateTextLength('verifier comments', this, 2000);" MaxLength="2000" TextMode="MultiLine" ID="txtVerifierComments" Width="80%" runat="server" ></asp:TextBox> 
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
                                <asp:DropDownList SkinID="ddlSkin"  ID="ddlCityLimit1" runat="server" AutoPostBack="false">
                                <asp:ListItem>ICL</asp:ListItem>
                                <asp:ListItem>OCL</asp:ListItem>
                                <asp:ListItem>Beyound OCL</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                </tr>
                                </table>           
                               <%--added by nikhil for supervisor sign 17 oct 2013--%>
                               <table cellpadding="0" cellspacing="0" border="0" id="Table14" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label26" runat="server" Text="Supervisor's Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlSupervisorName" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            
               </asp:DropDownList><asp:Label id="lblvalid" runat="server" Font-Bold="true" ForeColor="Red" Text="Supervisor Name Is Mandatory" SkinID="lblSkin"></asp:Label>
                
                </td>
                </tr>
                </table>
                      <%--end nikhil--%>                                        
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
                                <asp:Panel ID="pnlNoOfEaringMembers" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEaringMembers" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblNoOfEaringMembers" runat="server" Text="No. Of Earning Members"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNoOfEaringMembers" runat="server" ></asp:TextBox> 
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                                <asp:Panel ID="pnlIfVehicleExist" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblIfVehicleExist" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblIfVehicleExist" runat="server" Text="If vehicle exist / MakeModel"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlIfVehicleExist" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>     
                                               <asp:ListItem>Owned</asp:ListItem>     
                                               <asp:ListItem>Financed</asp:ListItem>
                                               <asp:ListItem>Comp Provided</asp:ListItem>
                                               <%--New added/Updated for CHOLA--%>
                                               <asp:ListItem>2 Wheeler</asp:ListItem>
                                               <asp:ListItem>Car</asp:ListItem>
                                               <asp:ListItem>Others</asp:ListItem><%--END--%>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                                 <asp:Panel ID="pnlVehicleType" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleType" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblVehicleType" runat="server" Text="Vehicle Type"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlVehicleType" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>2 Wheeler</asp:ListItem>
                                                <asp:ListItem>4 Wheeler</asp:ListItem>                                                            
                                                <asp:ListItem>Cycle</asp:ListItem>                                                            
                                            </asp:DropDownList>
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                                <asp:Panel ID="pnlDoorLocked" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDoorLocked" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblDoorLocked" runat="server" Text="Door Locked"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlDoorLocked" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>                                                            
                                            </asp:DropDownList>
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
                                           <asp:TextBox SkinID="txtSkin" MaxLength="50"  ID="txtSendDate" runat="server" ></asp:TextBox> 
                                           <img id="Img2" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSendDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                [dd/mm/yyyy]
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlTotalYrsInCity" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblTotalYrsInCity" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblTotalYrsInCity" runat="server" Text="Total Yrs in City"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtTotalYrsInCity" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                                <asp:Panel ID="pnlNameAddOf1Reference" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblNameAddOf1Reference" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblNameAddOf1Reference" runat="server" Text="Name address of 1 Reference"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="255"  ID="txtNameAddOf1Reference" Width="80%" runat="server" ></asp:TextBox> 
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
                                           <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtIfOCLDistance" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                                <asp:Panel ID="pnlParkingFacility" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblParkingFacility" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblParkingFacility" runat="server" Text="Parking Facility"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlParkingFacility" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>                                                            
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
                                           <asp:TextBox SkinID="txtSkin" MaxLength="255" Width="80%" ID="txtReasonForNotRecomdNReferred" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlFatherSpouseName" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFatherSpouseName" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblFatherSpouseName" runat="server" Text="Father/Spouse's Name"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="255" Width="80%" ID="txtFatherSpouseName" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               <!--Finish-->
                                <!---added by kamal matekar----for federal finance--->
                               <asp:Panel ID="pnlPagerNo" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblPagerNo" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblPagerNo" runat="server" Text="Pager No"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="255" Width="80%" ID="txtPagerNo" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                                  <asp:Panel ID="pnlVisibleItems" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblVisibleItems" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblVisibleItems" runat="server" Text="Visible Items"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                       <asp:CheckBoxList ID="chkvisibleItems" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="horizontal" RepeatColumns="4">                    
                                            <asp:ListItem>TV</asp:ListItem>
                                            <asp:ListItem>Music System</asp:ListItem>  
                                            <asp:ListItem>Refrigirator</asp:ListItem>
                                            <asp:ListItem>Colour TV</asp:ListItem>
                                            <asp:ListItem>AC</asp:ListItem>  
                                            <asp:ListItem>Washing Machin</asp:ListItem>
                                            <asp:ListItem>Computer</asp:ListItem>
                                            <asp:ListItem>Telephone</asp:ListItem>  
                                            <asp:ListItem>Almirah</asp:ListItem>
                                            <asp:ListItem>Cup Board</asp:ListItem> 
                                            <asp:ListItem>Bed</asp:ListItem>                  
                                            <asp:ListItem>2 Wheeler</asp:ListItem>                  
                                            <asp:ListItem>4 Wheeler</asp:ListItem>
                                            <asp:ListItem>Microwave</asp:ListItem>
                                      </asp:CheckBoxList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlDocVeri" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDocVeri" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDocVeri" runat="server" Text="Document Verified"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                       <asp:CheckBoxList ID="chkDocVeri" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="horizontal" RepeatColumns="4">                    
                                            <asp:ListItem>PAN Card</asp:ListItem>
                                            <asp:ListItem>Ration Card</asp:ListItem>  
                                            <asp:ListItem>Driving License</asp:ListItem>
                                            <asp:ListItem>Election Commission</asp:ListItem>
                                            <asp:ListItem>Identity Card</asp:ListItem>  
                                            <asp:ListItem>Passport</asp:ListItem>
                                            <asp:ListItem>Identity Card issued by employer</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlNoOfWindow" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfWindow" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblNoOfWindow" runat="server" Text="No of Windows"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="255" Width="80%" ID="txtNoOfWindow" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               <%--ended by kamal matekar--%>
                            
                                <%--add new column as per santosh shelar requirement--%>     
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
                                    <asp:Panel ID="pnlLoanNo" runat="server" Width="100%" Visible="false">
                                    <table id="tblLoanNo" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLoanNo" runat="server" Text="Loan Account No."></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLoanNo" runat="server" Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAmbResi" runat="server" Width="100%" Visible="false">
                                    <table id="tblAmbResi" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAmbResi" runat="server" Text="Ambience Residence"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAmbResi" runat="server" Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCheckDet" runat="server" Width="100%" Visible="false">
                                    <table id="tblCheckDet" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCheckDet" runat="server" Text="Check with whom give Details"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtCheckDet" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                    <asp:Panel ID="pnlRelAppForGua" runat="server" Width="100%" Visible="false">
                                    <table id="tblRelAppForGua" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRelAppForGua" runat="server" Text="A) Relationship with Applicant for Guarantor"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtRelAppForGua" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                    <asp:Panel ID="pnlKnowApp" runat="server" Width="100%" Visible="false">
                                    <table id="tblKnowApp" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblKnowApp" runat="server" Text="B) How many years they know the Applicant"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtKnowApp" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLiabGua" runat="server" Width="100%" Visible="false">
                                    <table id="tblLiabGua" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLiabGua" runat="server" Text="E) Whether he/she is aware of his liability as Guarantor"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLiabGua" runat="server" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                                          
                                <asp:Panel ID="pnlChildren" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblChildren" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblChildren" runat="server" Text="Children"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtChildren" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                                 <asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblDesignation" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblDesignation" runat="server" Text="Employment Designation"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDesigation" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlCarPark" runat="server" Width="100%" Visible="false">
                                    <table id="tblCarPark" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblCarPark" runat="server" Text="Car Park"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCarPark" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlResiExti" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblResiExti" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblResiExti" runat="server" Text="Exteriors of Resi"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlResiExti" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Garden</asp:ListItem>
                                                <asp:ListItem>Building wall(patchy)</asp:ListItem>
                                                <asp:ListItem>Elevator</asp:ListItem>
                                                <asp:ListItem>Fevator</asp:ListItem>
                                                <asp:ListItem>Security</asp:ListItem>                                                            
                                            </asp:DropDownList>
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlResiIntl" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblResiIntl" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblResiIntl" runat="server" Text="Residence Internal:"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlResiIntl" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Well furnnished</asp:ListItem>
                                                <asp:ListItem>Avg. furnished</asp:ListItem>
                                                <asp:ListItem>Poor furnished</asp:ListItem>
                                                <asp:ListItem>Poorly Maintained</asp:ListItem>
                                                <asp:ListItem>Unfurnished</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlConsHouse" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblConsHouse" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblConsHouse" runat="server" Text="Construction of house:"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlConsHouse" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Pukka</asp:ListItem>
                                                <asp:ListItem>Semi Pukka</asp:ListItem>
                                                <asp:ListItem>Temporary</asp:ListItem>
                                                <asp:ListItem>Permament Avg</asp:ListItem>
                                                <asp:ListItem>Permament Plush</asp:ListItem>
                                                <asp:ListItem>Slum</asp:ListItem>
                                             </asp:DropDownList>
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                               
     <asp:Panel ID="pnlExteriorPremises" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblExteriorPremises" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblExteriorPremises" runat="server"  Text="Residence External"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlExteriorPremises" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>                  
                    <asp:ListItem>Fair</asp:ListItem>                  
                    <asp:ListItem>Poor</asp:ListItem> 
                    <asp:ListItem>Satisfactory</asp:ListItem> 
                    <asp:ListItem>Bad</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
                               <%--ennd code--%>
<%--add this panel for FullortonPD on 19/07/2011 (santosh shelar)             --%>
<asp:Panel ID="pnlBranchDetails" runat="server" Width="100%" Visible="false">
<table cellpadding="0" cellspacing="0" border="0" id="Table8" style="width: 100%"
    runat="server">
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label10" runat="server" Text="Branch Name"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
            <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtBranchName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label11" runat="server" Text="Branch Code"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
            <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtBranchCode" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlFinanceDetails" runat="server" Width="100%" Visible="false">
<table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width: 100%"
    runat="server">
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label12" runat="server" Text="Net Monthly Salary"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
            <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtMonthSalary" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Label SkinID="lblSkin" ID="Label14" runat="server" Text="Other Income(Net) :"></asp:Label>
            <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtOtherIncome" runat="server"></asp:TextBox>
        </td>       
    </tr>
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label13" runat="server" Text="Source Of Other Income"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
             <asp:DropDownList SkinID="ddlSkin" ID="ddlSourceIncome" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Rent</asp:ListItem>
                    <asp:ListItem>Interest</asp:ListItem>                    
                </asp:DropDownList>
        </td>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label15" runat="server" Text="Verified Of Other Income :"></asp:Label>
                  <asp:DropDownList SkinID="ddlSkin" ID="ddlVeriOther" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Rent</asp:ListItem>
                    <asp:ListItem>Interest</asp:ListItem>                    
                </asp:DropDownList>
        </td>       
    </tr>
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label16" runat="server" Text="Clubbed Income"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
            <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtClubbedIncome" runat="server"></asp:TextBox>
        </td>             
    </tr>
    <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label17" runat="server" Text="Source Of Clubbed Income"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
             <asp:DropDownList SkinID="ddlSkin" ID="ddlSourceClubIncome" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Wife</asp:ListItem>
                    <asp:ListItem>Parents</asp:ListItem>                    
                    <asp:ListItem>Children</asp:ListItem>                    
                </asp:DropDownList>
        </td>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label18" runat="server" Text="Verified Of Clubbed Income :"></asp:Label>
                  <asp:DropDownList SkinID="ddlSkin" ID="ddlVeriClub" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Rent</asp:ListItem>
                    <asp:ListItem>Interest</asp:ListItem>                    
                </asp:DropDownList>
        </td>       
    </tr>
     <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label19" runat="server" Text="Verified Through :"></asp:Label>
        </td>
        <td style="width: 2%">
            :</td>
        <td>
            <asp:TextBox SkinID="txtSkin" ID="txtVeriThrough" Width="100%"  runat="server"></asp:TextBox>
        </td>             
    </tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlLoanDetails" runat="server" Width="100%" Visible="false">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table11">
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

<%--end code santu--%>
            
<!--Added by kamal Matekar for Karvy Financial-->
           <asp:Panel ID="pnlAddressDifferent" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddressDifferent" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblAddDiff" runat="server" Text="If address is different,please specify"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtAddDiff" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlPrevAdd" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblPrevAdd" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblPrevAdd" runat="server" Text="If less than 1 year at current residence then previous address"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="500" ID="txtPrevAdd" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlRentPerMonth" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblRentPerMonth" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblRentPermonth" runat="server" Text="If rented ,Rent per month-RS"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtRentPerMonth" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlFinancedBankName" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblfinanceBank" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblFinanceBank" runat="server" Text="If financed,name of bank"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtFinanceBank" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
        <asp:Panel ID="pnlAppNameVerifiedFrom" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAppNameVerifiedFrom" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblAppNameVerifiedFrom" runat="server"  Text="Applicant name verified from"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAppNameVerifiedFrom" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Name plate</asp:ListItem>
                    <asp:ListItem>Watchman</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>                               
                    <%--New added/Updated for CHOLA--%>
                    <asp:ListItem>Company Board</asp:ListItem>                               
                    <asp:ListItem>Society Board</asp:ListItem>  <%--END--%>                             
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
           <asp:Panel ID="pnlYearOfConstruction" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblYearOfConstruction" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblYearOfConstruction" runat="server" Text="Year Of Construction/Job"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtYearOfConstruction" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
         <asp:Panel ID="pnlPropertyIsRentedtoSomeone" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="Table4" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="Label2" runat="server"  Text="Property Is Rented to Someone"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlProperty" runat="server" AutoPostBack="false">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                               
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlApplicantOccupation" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantOccupation" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblApplicantOccupation" runat="server"  Text="Applicant's Occupation"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAppOccupation" runat="server" AutoPostBack="false">
                    <asp:ListItem>Salaried</asp:ListItem>
                    <asp:ListItem>Self Employed</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>                               
                </asp:DropDownList>
               </td>   
                </tr>
                <tr>
                    <td class="TDWidth">
                         Applicant Occupation Others</td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOccOther" runat="server"></asp:TextBox>
                    </td>
                 </tr>
                </table>
         </asp:Panel>
           <asp:Panel ID="pnlNatureofbusiness" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNatureofbusiness" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblNatureofbusiness" runat="server" Text="Nature of business"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNatureofbusiness" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
            <asp:Panel ID="pnlWorkingsince" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblWorkingsince" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="lblWorkingsince" runat="server" Text="Working since"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtWorkingsince" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
         <asp:Panel ID="pnlProofOfIdentitySeen" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="txtProofOfIdentitySeen" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblProofOfIdentitySeen" runat="server"  Text="Proof Of identity seen"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlProofOfIdentitySeen" runat="server" AutoPostBack="false">
                    <asp:ListItem>Passport</asp:ListItem>
                    <asp:ListItem>PAN Card</asp:ListItem>
                    <asp:ListItem>Driving License</asp:ListItem>  
                    <asp:ListItem>Voter ID</asp:ListItem>
                    <asp:ListItem>Photo debit/credit card</asp:ListItem>
                    <asp:ListItem>Identity Card</asp:ListItem>   
                    <asp:ListItem>Photo Ration Card</asp:ListItem>   
                    <asp:ListItem>Election Commission</asp:ListItem>                              
                    <asp:ListItem>Identity Card issued by employer</asp:ListItem>                              
                    <asp:ListItem>Others</asp:ListItem>                              
                </asp:DropDownList>
               </td>   
                </tr>
                <tr>
                    <td class="TDWidth">
                        Proof Of Identity Others</td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtProofOfIdentityOther" runat="server"></asp:TextBox>
                    </td>
                 </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlAddressProofSeen" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblAddressProofSeen" runat="server"  Text="Address proof seen"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressProofSeen" runat="server" AutoPostBack="false">
                    <asp:ListItem>Passport</asp:ListItem>
                    <asp:ListItem>Utility Bills</asp:ListItem>
                    <asp:ListItem>Allotment letter</asp:ListItem>  
                    <asp:ListItem>Bank Statement</asp:ListItem>
                    <asp:ListItem>Ration Card</asp:ListItem>
                    <asp:ListItem>Insurance Premium Receipt</asp:ListItem>            
                    <asp:ListItem>L& L Agreement/Sale deed</asp:ListItem>                                 
                    <asp:ListItem>Others</asp:ListItem>                              
                </asp:DropDownList>
               </td>   
                </tr>
                <tr>
                    <td class="TDWidth">
                        Address Proof Others</td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtAddressProofOther" runat="server"></asp:TextBox>
                    </td>
                 </tr>
                </table>
         </asp:Panel>
         
         <!--Ended by kamal matekar-->
                              <!--Start Additional Fields on 03-Oct-2007-->     
                                <asp:Panel ID="pnlSepBathroom" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSepBathroom" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblSepBathroom" runat="server" Text="Sep.Bathroom/Kitchen"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlSepBathroom" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>            
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlFamilySeen" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFamilySeen" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFamilySeen" runat="server" Text="Family Seen"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlFamilySeen" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>            
                                        </asp:DropDownList>
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
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="1000" onkeyPress="ValidateTextLength('verifier comments', this, 250);"  ID="txtSupervisorComments" runat="server" ></asp:TextBox> 
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
                                            <asp:ListItem>Tile</asp:ListItem>  
                                            <asp:ListItem>Asbestos</asp:ListItem>  
                                            <asp:ListItem>Concrete</asp:ListItem>                                                                               
                                            <asp:ListItem>Thatched</asp:ListItem>                                                                               
                                            <asp:ListItem>Pukka Roof</asp:ListItem>  
                                            <asp:ListItem>Manglore Roof</asp:ListItem>                                                                                                                      
                                        </asp:DropDownList>
                                        </td>  
                                        </tr>               
                                  </table>
                             </asp:Panel>
     <%--        Added by Manoj--%>
      <asp:Panel ID="PnlConfirmationRes" runat="server" Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table13" style="width:100%" runat="server">
                <tr>
                     <td class="TDWidth">
                          <asp:Label SkinID="lblSkin" ID="Label24" runat="server" Text="Confirmation Of Residence"></asp:Label>
                     </td><td style="width:2%">:</td>
                     <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlConfirmationResid" runat="server"  AutoPostBack="false">
                         <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                  <asp:ListItem>Yes</asp:ListItem>
                                  <asp:ListItem>No</asp:ListItem>            
                     </asp:DropDownList>
                     </td>
                </tr>
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label25" runat="server" Text="IF No Pls Remarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtResRemarks" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
     </asp:Panel>
     <%--modified by nikhil for SHFL on 31st august 2013--%>
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
                    <asp:Label SkinID="lblSkin" ID="lblDedupMatchRemarks" runat="server" Text="IF Yes,Remarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDedupMatchRemaks" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
     </asp:Panel>
     <%--End nikhil shfl--%>
     <%-- addition for ING_VYSYA: Nikhil G. Lad 04 July 2013-----Start  --%>  
   
    <asp:Panel ID="pnlLocalityType" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityType" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblLocalityType" runat="server" Text="Locality Type"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityType" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Normal</asp:ListItem>
                                            <asp:ListItem>Trouble Prone</asp:ListItem>
                                            <asp:ListItem>Communally Sensitive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlFamilyStructure" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFamilyStructure" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFamilyStructure" runat="server" Text="Family Structure"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlFamilyStructure" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Joint Family</asp:ListItem>
                                            <asp:ListItem>Nuclear Family</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlExistingLoanDetails" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblExistingLoanDetails" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblExistingLoanDetails" runat="server" Text="Existing Loan Details"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtExistingLoanDetails" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlExistingVehicleDetails" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblExistingVehicleDetails" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblExistingVehicleDetails" runat="server" Text="Existing Vehicle Details"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtExistingVehicleDetails" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlVehicleRegNo" runat="server" Width="100%" Visible="false">
        <table id="tblVehicleRegNo" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVehicleRegNo" runat="server" Text="Vehicle Reg. No."></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtVehicleRegNo" runat="server"></asp:TextBox>
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
   <%--ING VYSYA End NIKHIL--%>   
     
     <asp:Panel ID="PnlEndUseOfTheFunds" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table15" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label28" runat="server" Text="End Use Of The Funds"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtEndUseOfTheFunds" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       <asp:Panel ID="PnlNoOfPeople" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table12" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label23" runat="server" Text="No Of People"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtpeople" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlRegiationNo" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table16" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label30" runat="server" Text="Registration No."></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtRegiationNo" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="PnlReputationofneighbourhood" runat="server" Width="100%" Visible="false">
                    <table cellpadding="0" cellspacing="0" border="0" id="Table17" style="width:100%" runat="server">
                         <tr>
                              <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="Label31" runat="server" Text="Reputation of applicant in neighbourhood:"></asp:Label>
                              </td><td style="width:2%">:</td>
                              <td>
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlReputationofneighbourhood" runat="server"  AutoPostBack="false">
                                           <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                           <asp:ListItem>Good</asp:ListItem>
                                           <asp:ListItem>Bad</asp:ListItem>
                                           <asp:ListItem>Neutral</asp:ListItem>
                                           <asp:ListItem>No Idea</asp:ListItem>
                                    </asp:DropDownList>
                              </td>
                        </tr>            
                  </table>
           </asp:Panel>   
           <asp:Panel ID="PnlNameVerifiedNamem" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table22" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label34" runat="server" Text="Name Verifier From"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtnameverifedfrom" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel> 
           <asp:Panel ID="PnlInteriorConditions" runat="server" Width="100%" Visible="false">
                                    <table id="Table20" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label32" runat="server" Text="Interior Conditions"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>                                                
                                                <asp:CheckBoxList ID="ChkInteriorConditions" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">                                                    
                                                    <asp:ListItem>Sofa</asp:ListItem>
                                                    <asp:ListItem>Clean</asp:ListItem> 
                                                    <asp:ListItem>Painted</asp:ListItem>
                                                    <asp:ListItem>Carpeted</asp:ListItem>                    
                                                    <asp:ListItem>Venetian Blinds</asp:ListItem>                                                    
                                                    <asp:ListItem>Curtains</asp:ListItem>       
                                                     <%--New added/Updated for CHOLA--%>   
                                                    <asp:ListItem>Pukka</asp:ListItem>       
                                                    <asp:ListItem>Semi Pukka</asp:ListItem>       
                                                    <asp:ListItem>Temporary</asp:ListItem><%--END--%>   
                                                    <asp:ListItem>Others</asp:ListItem>       
                                            </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtInteriorConditions" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
            </asp:Panel>
            <asp:Panel ID="PnlExteriors" runat="server" Width="100%" Visible="false">
                                    <table id="tblExteriors" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblExteriors" runat="server" Text="Comments of Exteriors"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>                                                
                                                <asp:CheckBoxList ID="ChkExteriors" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">                                                    
                                               <%--New added/Updated for CHOLA--%>
                                                    <asp:ListItem>Health Club</asp:ListItem>      
                                                    <asp:ListItem>Swimming Pool</asp:ListItem> 
                                                <%--END--%> 
                                                    <asp:ListItem>Car Park</asp:ListItem>
                                                    <asp:ListItem>Garden</asp:ListItem> 
                                                    <asp:ListItem>Security</asp:ListItem>
                                                    <asp:ListItem>Building Wall</asp:ListItem>                    
                                                    <asp:ListItem>Fenced / Compound Wall</asp:ListItem>                                                    
                                                    <asp:ListItem>Elevator</asp:ListItem> 
                                                    <asp:ListItem>Lift</asp:ListItem>      
                                                    <asp:ListItem>Others</asp:ListItem>       
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                If Others(Pls.Specify)</td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtExteriors" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                </asp:Panel>         
       <%--Added  by Manoj for city bank--%>          
      <asp:Panel ID="PnlNoOfstores" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table23" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth">
                        <asp:Label SkinID="lblSkin" ID="Label35" runat="server" Text="No. of Storyes/Working since"></asp:Label>
                    </td>
                    <td style="width: 2%">
                        :</td>
                    <td>
                        <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNoOfstores" runat="server"></asp:TextBox>
                    </td>          
                </tr>
            </table>
           </asp:Panel>
               <asp:Panel ID="Pnlresidenceappear" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="Table24" style="width:100%" runat="server" >          
                  <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="Label36" runat="server"  Text="*Does the residence appear to be"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlresidenceappear" runat="server" AutoPostBack="false">
                      <asp:ListItem>NA</asp:ListItem>
                      <asp:ListItem>Single Room Unit</asp:ListItem>
                      <asp:ListItem> <=BHK </asp:ListItem>
                      <asp:ListItem> >=1BHK</asp:ListItem>                               
                   </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel> 
         <asp:Panel ID="PnlDomestichelp" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="Table25" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="Label37" runat="server"  Text="*Domestic Help Seen"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlDomestichelp" runat="server" AutoPostBack="false">
                      <asp:ListItem>Yes</asp:ListItem>
                      <asp:ListItem>No</asp:ListItem>
                   </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>  
  
        <asp:Panel ID="Pnlwastheapplicantmetaresidence" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="Table26" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="Label38" runat="server"  Text="* Was the applicant met at residence during his office hours"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlwastheapplicantmetaresidence" runat="server" AutoPostBack="false">
                      <asp:ListItem>Yes</asp:ListItem>
                      <asp:ListItem>No</asp:ListItem>
                   </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel> 
         <asp:Panel ID="Pnlearning" runat="server" Width="100%" Visible="false">
                  <table cellpadding="0" cellspacing="0" border="0" id="Table27" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label39" runat="server" Text="Earning members other than applicant"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtEaringmembers" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label40" runat="server" Text="Relationship with applicant"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtRelationshipe" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label41" runat="server" Text="Monthly Earning(approx)"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtmonthlyearing" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label42" runat="server" Text="Verified Through"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtVerifierthrough" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="PnlThiredpartyConfimation" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table28" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label43" runat="server" Text="Applicant’s Standing in Locality"></asp:Label>
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
                                            <asp:Label SkinID="lblSkin" ID="Label44" runat="server" Text="Name :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtnamee" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label45" runat="server" Text="Phone :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtphonee" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label46" runat="server" Text="Pls elaborate on the standing :"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtelaborateonthestanding" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel> 
                               
                                <asp:Panel ID="pnlPickupdocumnet" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tabPickupdocumnet" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="labPickupdocumnet" runat="server" Text="Pickup Documents"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                            <asp:CheckBoxList ID="chkPickupdocument" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">                                                    
                                            <asp:ListItem>RV</asp:ListItem>
                                            <asp:ListItem>BV</asp:ListItem>
                                            <asp:ListItem>ITR</asp:ListItem>
                                            <asp:ListItem>VOTER ID</asp:ListItem>
                                            <asp:ListItem>bank statement</asp:ListItem>
                                            <asp:ListItem>electricity bill</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                     <td>
                                           <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtother" runat="server" Visible="false"></asp:TextBox>
                                     </td>
                          </tr>
               </table>
      </asp:Panel>
             
             
     <asp:Panel ID="PnlBusinessverification" runat="server" Width="100%" Visible="false">
        <table id="Table31" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBusinessverification" runat="server" Text="Business Verification"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtBusinessverification" TextMode="MultiLine"  runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>   
    
                
   <asp:Panel ID="PnlITR" runat="server" Width="100%" Visible="false">
        <table id="tabITR" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labITR" runat="server" Text="ITR Verification"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" TextMode="MultiLine" ID="txtITR" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>                   
    
    
   <asp:Panel ID="PnlVoterId" runat="server" Width="100%" Visible="false">
        <table id="Table29" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label48" runat="server" Text="Voter ID Verification"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtVoterIDVer" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>   
    
    <asp:Panel ID="pnlbanksatatment" runat="server" Width="100%" Visible="false">
        <table id="Table32" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labbanksatatment" runat="server" Text="Bank statment Verification"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="2000" ID="txtbanksatatment" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>   
    
    <asp:Panel ID="Pnlelectricitybill" runat="server" Width="100%" Visible="false">
        <table id="tabelectricitybill" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labelectricitybill" runat="server" Text="electricity bill Verification"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="2000" ID="txtelectricitybill" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>   

   <%--        Ended by Manoj--%>
   
      <%--start nikhil SCB HL 31 oct2013--%>
   
   <asp:Panel ID="pnlPermAddTelNo" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblPermAddTelNo" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblPermAddTelNo" runat="server"  Text="Permanent Address Telephone No."></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPermAddTelNo" runat="server" ></asp:TextBox> 
                </td>   
                </tr>
                </table>
         </asp:Panel> 
         
         <asp:Panel ID="pnlCreditCardOwnershipSCB" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblCreditCardOwnership" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblCreditCardOwnership" runat="server"  Text="Credit Card Ownership"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlCreditCardOwnershipSCB" runat="server" AutoPostBack="false">
                      <asp:ListItem>Yes</asp:ListItem>
                      <asp:ListItem>No</asp:ListItem>
                   </asp:DropDownList>
                </td>   
                    <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfCCYes" runat="server" Text="If Yes, then"></asp:Label>
                    </td><td style="width:2%">:</td>
                    <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfCCYes" runat="server" AutoPostBack="false">
                      <asp:ListItem>SCB</asp:ListItem>
                      <asp:ListItem>Others</asp:ListItem>
                   </asp:DropDownList>
                    </td>
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlFlooringType" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblFlooringType" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblFlooringType" runat="server"  Text="Type of Flooring"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlFlooringType" runat="server" AutoPostBack="false">
                      <asp:ListItem>Mosiac</asp:ListItem>
                      <asp:ListItem>Marble</asp:ListItem>
                      <asp:ListItem>Cement</asp:ListItem>
                   </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlEarlierVisited" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblEarlierVisited" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblEarlierVisited" runat="server"  Text="Earlier Visited "></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlEarlierVisited" runat="server" AutoPostBack="false">
                      <asp:ListItem>Yes</asp:ListItem>
                      <asp:ListItem>No</asp:ListItem>
                   </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel> 
   
   <asp:Panel ID="pnlNearnessToNegArea" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblNearnessToNegArea" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblNearnessToNegArea" runat="server"  Text="Nearness to Negative Area(in kms)"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNearnessToNegArea" runat="server" ></asp:TextBox> 
                </td>   
                </tr>
                </table>
         </asp:Panel> 
         
          <asp:Panel ID="pnlVehicleTypeAndDetails" runat="server"  Width="100%" Visible="false">
               <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleTypeAndDetails" style="width:100%" runat="server" >          
               <tr>
                   <td class="TDWidth" style="height: 22px">
                     <asp:Label SkinID="lblSkin" ID="lblVehicleTypeAndDetails" runat="server"  Text="Vehicle: 2/4 wheeler, owned/financed, Model"></asp:Label>
                   </td><td style="width:2%; height: 22px;">:</td>
                   <td style="height: 22px">
                      <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtVehicleTypeAndDetails" runat="server" ></asp:TextBox> 
                </td>   
                </tr>
                </table>
         </asp:Panel> 
         
   <%--Added  by Manoj for Area --%>                                
  <asp:Panel ID="PnlAreaname" runat="server" Width="100%" Visible="true">
       <table cellpadding="0" cellspacing="0" border="0" id="tabareaname" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labAreaname" runat="server" Text="Area Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false"  ValidationGroup="gvValidate">
                     </asp:DropDownList>
                      <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                      <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />

                     
                </td>
           </tr>            
      </table>
   </asp:Panel>
                               
 <%--Ended  by Manoj for Area --%> 
   <%--end nikhil SCB HL 31 oct2013--%>
                              <asp:Panel ID="pnlAttempts" runat="server" Width="100%" Visible="true">
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
                                                <asp:TextBox ID="txtDate1" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td>
                                            <asp:TextBox SkinID="txtSkin" MaxLength="5" ID="txtAttemptTime1" Width="50" runat="server" ></asp:TextBox>
                                            <asp:DropDownList ID="ddlAttemptTimeType1" runat="server"  SkinID="ddlSkin">
                                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList></td>

                                            <td>
                                            <asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark1" runat="server" ></asp:TextBox>
                                             </td>
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
                                                <asp:TextBox ID="txtDate2" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <asp:TextBox ID="txtDate3" Width="100" runat="server" SkinID="txtSkin"></asp:TextBox>
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
                             
                                  <!--End Additional Fields on 03-Oct-2007-->
                               
                               
                                                                   <%--Added by Nikhil Lad for Shriram HF On Dated 21-Jan-2013 --%>
          
          <asp:Panel ID="pnlSplInstr" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSplInstr" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSplInstr" runat="server" Text="Special Instruction"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtskin" ID="txtSplInstr" runat="server" ></asp:TextBox>
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlDependentAdults" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDependentAdults" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDependentAdults" runat="server" Text="No. of Dependent Adults"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" ID="txtDependentAdults" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlCreditCardName" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblCCName" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCCName" runat="server" Text="If Yes,Credit Card Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCreditCardName" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlNameOnNamePlate" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNameOnNamePlate" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOnNamePlate" runat="server" Text="If Yes, Name on Name Plate"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOnNamePlate" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
          
          <asp:Panel ID="pnlNegativeFeedbackFromFamily" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeFeedbackFromFamily" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNegativeFeedbackFromFamily" runat="server" Text="Negative feedback from family members,if any "></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNegativeFeedbackFromFamily" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
        <asp:Panel ID="pnlNegativeFeedbackFromNeighbour" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeFeedbackFromNeighbour" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNegativeFeedbackFromNeighbour" runat="server" Text="Negative feedback from Neighbours,if any "></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNegativeFeedbackFromNeighbour" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
        <asp:Panel ID="pnlApplicantCapableOfMaintaining" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantCapableOfMaintaining" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicantCapableOfMaintaining" runat="server" Text="Applicant Capable of maintaining "></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlskin" ID="ddlApplicantCapableOfMaintaining" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                    <asp:ListItem>Small Car</asp:ListItem>
                    <asp:ListItem>Medium-Size Car</asp:ListItem>
                    <asp:ListItem>Big Car</asp:ListItem>
                    <asp:ListItem>No Car</asp:ListItem>                                      
                </asp:DropDownList>
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlIfNegBankName" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIfNegBankName" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfNegBankName" runat="server" Text="If Match in Negative, Bank Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtIfNegBankName" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlNegProduct" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblNegProduct" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNegProduct" runat="server" Text="If Match in Negative, Product"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNegProduct" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlDefaultBucket" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDefaultBucket" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDefaultBucket" runat="server" Text="If Match in Negative, Default Bucket"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDefaultBucket" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>
       
       <asp:Panel ID="pnlDefaultAmount" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblDefaultAmount" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDefaultAmount" runat="server" Text="If Match in Negative, Amount of default in INR"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDefaultAmount" runat="server" ></asp:TextBox> 
                </td>
                </tr>
           </table>
       </asp:Panel>   
          
  <%--4 april 2013 start nikhil--%>
  
  <asp:Panel ID="pnlResTelOwnership" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tbl5" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResTelOwnership" runat="server" Text="Residence Telephone Number Ownership"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlResTelOwnership" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Own</asp:ListItem>
                                            <asp:ListItem>Company Provided</asp:ListItem>
                                            <asp:ListItem>PP</asp:ListItem>            
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                                 
                               <asp:Panel ID="pnlIncomeDocsSub" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tbl7" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblIncomeDocsSub" runat="server" Text="Income Documents Submitted "></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtIncomeDocsSub" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlNoOfPplSeenResidence" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tbl10" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblNoOfPplSeenResidence" runat="server" Text="No. of people seen in residence "></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="SingleLine" ID="txtNoOfPplSeenResidence" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlTypeOfLoan" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table18" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTypeOfLoan" runat="server" Text="Type Of Loan"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfLoan" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>PL</asp:ListItem>
                                            <asp:ListItem>HL</asp:ListItem>
                                            <asp:ListItem>Auto</asp:ListItem>  
                                            <asp:ListItem>Credit Card</asp:ListItem>  
                                            <asp:ListItem>BL</asp:ListItem>          
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlRemarks" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="Table19" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="MultiLine" ID="txtRemarks" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="pnlPincodeAddMatch" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblPincodeAddMatch" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPincodeAddMatch" runat="server" Text="Pincode on address and visit matches :"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlPincodeAddMatch" runat="server"  AutoPostBack="false">
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
                               
                               <asp:Panel ID="pnlCommunityDominated" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblCommunityDominated" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCommunityDominated" runat="server" Text="Negative area/ Community dominated"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlCommunityDominated" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
   <asp:Panel ID="PnlBuildingType" runat="server" Width="100%" Visible="false">
        <table id="Table30" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label47" runat="server" Text="Building Type"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtbuildingtype" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlNoOfYrsstay" runat="server" Width="100%" Visible="false">
                                    <table id="tabNoOfYrsstay" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoOfYrsstay" runat="server" Text="No of yrs Of stay"></asp:Label>
                                        </td>
                                        <td style="width:2%">:</td>
                                        <td>
                                          <asp:TextBox SkinID="txtSkin"    ID="txtyear" runat="server" MaxLength="2"></asp:TextBox>
                                     
                                        </td>                                                     
                                        </tr>
                                    </table>
    </asp:Panel>
    <asp:Panel ID="PnlCrossinformation" runat="server" Width="100%" Visible="false">
                                    <table id="tabCrossinformation" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                        <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="labcrossinformation" runat="server" Text="Cross Verified Information:"></asp:Label>
                                        </td>
                                        <td style="width:2%">:</td>
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

    <%--    4 april 2013    Ended by Nikhil--%>                            


      <%--New added/Updated for CHOLA--%>

    <asp:Panel ID="pnlIssueBank" runat="server" Width="100%" Visible="false">
        <table id="Table33" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblIssueBank" runat="server" Text="Issuing Bank"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin" ID="txtIssueBank" runat="server" Width="80%" ></asp:TextBox>
                </td>                                                     
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlExpiryBank" runat="server" Width="100%" Visible="false">
        <table id="Table34" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblExpiryBank" runat="server" Text="Expiry Bank / Date"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin" ID="txtExpiryBank" runat="server" Width="80%" ></asp:TextBox>
                </td>                                                     
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlAssetUser" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table35" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAssetUser" runat="server" Text="End User of Asset"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAssetUser" runat="server">
                    <asp:ListItem>Applicant</asp:ListItem>
                    <asp:ListItem>Family Member</asp:ListItem>
                    <asp:ListItem>Relative</asp:ListItem>
                    <asp:ListItem>Friend</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>

    <asp:Panel ID="pnlAssetLocation" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table36" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAssetLocation" runat="server" Text="Location of Asset"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAssetLocation" runat="server">
                    <asp:ListItem>Residence</asp:ListItem>
                    <asp:ListItem>Factory</asp:ListItem>
                    <asp:ListItem>Office</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>

    <asp:Panel ID="pnlPlaceRegis" runat="server" Width="100%" Visible="false">
        <table id="Table37" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPlaceRegis" runat="server" Text="Place of Registration"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin" ID="txtPlaceRegis" runat="server" Width="80%" ></asp:TextBox>
                </td>                                                     
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlPropertyAddress" runat="server" Width="100%" Visible="false">
        <table id="Table38" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPropertyAddress" runat="server" Text="Property Address"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin" ID="txtPropertyAddress" runat="server" Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>                                                     
            </tr>
        </table>
    </asp:Panel>      
    
    <asp:Panel ID="pnlPropertyIdentify" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table39" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPropertyIdentify" runat="server" Text="Property Identified By"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPropertyIdentify" runat="server">
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Watchman</asp:ListItem>
                    <asp:ListItem>Society Board</asp:ListItem>
                    <asp:ListItem>Builder Name Board</asp:ListItem>
                    <asp:ListItem>Address Provided by Customer</asp:ListItem>
                    <asp:ListItem>Land Revenue Authority Officer</asp:ListItem>
                    <asp:ListItem>Address is Wrong</asp:ListItem>
                    <asp:ListItem>Property not Traceable</asp:ListItem>
                    <asp:ListItem>Name Plate</asp:ListItem>
                    <asp:ListItem>Passerby</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>    

    <asp:Panel ID="pnlPropertyType" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table40" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPropertyType" runat="server" Text="Property Type"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPropertyType" runat="server">
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Mall</asp:ListItem>
                    <asp:ListItem>Bunglow</asp:ListItem>
                    <asp:ListItem>Office Premises</asp:ListItem>
                    <asp:ListItem>Under Construction</asp:ListItem>
                    <asp:ListItem>Construction yet to start</asp:ListItem>
                    <asp:ListItem>Construction fully completed/>80% completed</asp:ListItem>
                    <asp:ListItem>Old House-Purchase</asp:ListItem>
                    <asp:ListItem>Flat-ready to move in/>80% completed</asp:ListItem>
                    <asp:ListItem>Flat-Under Construction</asp:ListItem>
                    <asp:ListItem>Home improvement</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>       

    <asp:Panel ID="pnlBuildingQuality" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table41" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblBuildingQuality" runat="server" Text="Quality of Building"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBuildingQuality" runat="server">
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Cannot</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel> 

    <asp:Panel ID="pnlPropertyArea" runat="server" Width="100%" Visible="false">
        <table id="Table42" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPropertyArea" runat="server" Text="Area Of Property(Sq. Ft.)"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtPropertyArea" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlBankMortgage" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table43" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblBankMortgage" runat="server" Text="If any board on the propertystating that property is mortgaged to Bank/HFC"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBankMortgage" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label33" runat="server" Text="If Yes,Name of the Banks/HFC"></asp:Label>
            </td>
            <td style="width: 2%">
                :</td>            
            <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtBankMortgage" MaxLength="200" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
       </table>
   </asp:Panel>    
    
    <asp:Panel ID="pnlDistance_KM" runat="server" Width="100%" Visible="false">
        <table id="Table44" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDist_Railway" runat="server" Text="Distance from Railway Station (KM)"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtDist_Railway" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>    
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDist_Highway" runat="server" Text="Distance from Highway (KM)"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtDist_Highway" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>    
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDist_Bus" runat="server" Text="Distance from Bus Stand (KM)"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtDist_Bus" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>    
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDist_TarRoad" runat="server" Text="Distance from Tar Road (KM)"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtDist_TarRoad" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>    

    <asp:Panel ID="pnlAssociateProperty" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table45" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAssociateProperty" runat="server" Text="Associate with Property"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAssociateProperty" runat="server">
                    <asp:ListItem>>3 years</asp:ListItem>
                    <asp:ListItem>>1 year</asp:ListItem>
                    <asp:ListItem>6-12</asp:ListItem>
                    <asp:ListItem>1 to 6 months</asp:ListItem>
                    <asp:ListItem>No Association</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>     

    <asp:Panel ID="pnlPropertyAge" runat="server" Width="100%" Visible="false">
        <table id="Table46" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPropertyAge" runat="server" Text="Age Of Property"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPropertyAge" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlPropertyDisputes" runat="server" Width="100%" Visible="false">
        <table id="Table47" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPropertyDisputes" runat="server" Text="Any disputes of the ownership Of Property"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPropertyDisputes" MaxLength="200" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlPropertyDemand" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table48" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPropertyDemand" runat="server" Text="Demand of Property in the area"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPropertyDemand" runat="server">
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
       </table>
   </asp:Panel>
   
    <asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRating" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblRating" runat="server" Text="Rating"></asp:Label>
                </td>
                <td style="width:2%">:</td>
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
    
    <asp:Panel ID="pnlNameProperty" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table49" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblNameProperty" runat="server" Text="Name of Property as on"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlNameProperty" runat="server"  AutoPostBack="false">
                        <asp:ListItem Text="NA" Value=""></asp:ListItem>
                        <asp:ListItem>Name Plate</asp:ListItem>
                        <asp:ListItem>Society Board</asp:ListItem>            
                        <asp:ListItem>Builder</asp:ListItem>            
                        <asp:ListItem>Display Board</asp:ListItem>            
                       <asp:ListItem>Name</asp:ListItem>            
                     </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>    

    <asp:Panel ID="pnlPhoneNeighbour1" runat="server" Width="100%" Visible="false">
        <table id="Table50" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPhoneNeighbour1" runat="server" Text="Contact Number Of Neighbour 1"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtPhoneNeighbour1" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>    

    <asp:Panel ID="pnlOwnerVisitProperty" runat="server" Width="100%" Visible="false">
        <table id="Table51" cellpadding="0" cellspacing="0" style="width: 100%"
            runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOwnerVisitProperty" runat="server" Text="How often does the owner visits the Property"></asp:Label>
                </td>
                <td style="width: 2%">
                    :</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtOwnerVisitProperty" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>  

    <%--End--%>        


      <%--New added/Updated for Capri Global--%>

  <asp:Panel ID="Pnl_Original_Seen_Verified" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="Table21" style="width:100%" runat="server">
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
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSubmit" ValidationGroup="gvValidate"  runat="server" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidCaseID" runat="server" />
                                    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                    <asp:HiddenField ID="hidVerifierID" runat="server" />
                                    <asp:HiddenField ID="hidMode" runat="server" />
                                    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
                                </asp:Panel>
                            </asp:TableCell>
                            </asp:TableRow>
                    </asp:Table>
                         <asp:CustomValidator ID="cvOverallVerification" runat="server" 
                   ErrorMessage="Please select Overall Verification." ValidationGroup="gvValidate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true" ControlToValidate="ddlOverallVerification"
                    OnServerValidate="cvSelectddlOverallVerification_ServerValidate">
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
                    ValidationGroup="gvValidate" ShowMessageBox="True" ShowSummary="False" /> &nbsp;
                    
                </td>
            </tr>
        </table>
         <asp:HiddenField ID="hdnTransStart" runat="server" />
         <asp:HiddenField ID="hdnSupID" runat="server" />
        <asp:SqlDataSource ID="sdsFE" runat="server" 
            ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1"
            SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
        </asp:SqlDataSource>
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
