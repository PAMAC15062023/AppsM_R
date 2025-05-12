<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile"AutoEventWireup="true" CodeFile="CC_BusinessVerification.aspx.cs" Inherits="CC_CC_BusinessVerification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
      
         function openwindow(imgType)
        {        
            
           var hidCaseID=document.getElementById("<%=hidCaseID.ClientID%>");
           var hidVerificationTypeID=document.getElementById("<%=hidVerificationTypeID.ClientID%>");
          
            window.open('CC_RenderImage.aspx?CaseId='+hidCaseID.value +'&Veri='+hidVerificationTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
        
       function ValidateStatus()
       {
              var statusIndex=document.getElementById("<%=ddlCaseStatus.ClientID%>").selectedIndex;
              var status=document.getElementById("<%=ddlCaseStatus.ClientID%>").options[statusIndex].text;
              var outcome=document.getElementById("<%=ddlOutcome.ClientID%>");
              var declineReason=document.getElementById("<%=txtDeclineReason.ClientID%>");
              
              if(status =='DECLINE' || status =='NEGATIVE' || status =='Decline' || status =='Negative')
              {       
                    outcome.disabled=false;
                    declineReason.disabled=false;                  
              }
              
              if(status =='Accept' || status =='ACCEPT' || status =='Positive' || status =='POSITIVE' || status =='Refer To Bank' || status =='REFER TO BANK' || status =='Neutral' || status =='NEUTRAL')
              {
                    outcome.disabled=true;
                    declineReason.disabled=true;
                    statusIndex=0;
              }
       }
       
      
       
       function ValidateDeclineStatus(source, arguments)
       {
              var statusIndex=document.getElementById("<%=ddlCaseStatus.ClientID%>").selectedIndex;
              var status=document.getElementById("<%=ddlCaseStatus.ClientID%>").options[statusIndex].text;
              var outcome=document.getElementById("<%=ddlOutcome.ClientID%>");
              var declineReason=document.getElementById("<%=txtDeclineReason.ClientID%>");
              
              if(status =='DECLINE' || status =='NEGATIVE' || status =='Decline' || status =='Negative')
              {       
                    outcome.disabled=false;
                    declineReason.disabled=false;  
                           
                     if(outcome.selectedIndex == 0)
                    {                        
                        arguments.IsValid=false;
                    }
                    if(declineReason.value == '')
                    {                        
                        arguments.IsValid=false;                      
                    }
              }
       }
  function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 249)
     {
       getControlsId.value = getControlsId.value.substring( 0, 249 );            
       return false;
     }          
   }
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
       
       function ValidateAttempts(source, arguments)
       {
           if((document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length == 0) && (document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length == 0) && (document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length ==0))
           {
                arguments.IsValid = false;
           }
           else
           {
                arguments.IsValid = true;
           }
       }
 /*-----------------------Modified By Gargi Srivastava on 31-May-2007----------------------------------*/
////      function ValidateTime1(source, arguments)
////       { 
////          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
////          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length >0)
////          {            
////            if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length ==0)
////            {
////                document.aspnetForm.ctl00$C1$txtAttemptRemark1.focus();
////                arguments.IsValid=false;
////            }              
////          }
////       }
        function ValidateTime1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length ==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime1.focus();
                arguments.IsValid=false;
                        
          }
       }
//       function ValidateRemark1(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime1.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
//       function ValidateTime2(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark2.focus();
//                arguments.IsValid=false;
//            }   
//          }
//       }
        function ValidateTime2(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime2.focus();
                arguments.IsValid=false;
               
          }
       }
//       function ValidateRemark2(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime2.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
//       function ValidateTime3(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark3.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark3.focus();
//                arguments.IsValid=false;
//            }   
//          }
//       }

        function ValidateTime3(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime3.focus();
                arguments.IsValid=false;
             
          }
       }
//       function ValidateRemark3(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime3.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
// -->
 /*-----------------------End----------------------------------*/


</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Business Verification</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" style="background-color:#E7F6FF">
<tr><td style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
<tr><td></td><td>
 <!--Start ErrorMessgage-->
    <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth" style="height: 14px">
            <asp:Label SkinID="lblErrorMsg" ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
        </td>        
        </tr>
       </table>
   </asp:Panel>   
   <!--END ErrorMessgage-->  
   <!--Place holder Start-->
   <asp:Table ID="tblBusiVeri" runat="server"  Width="100%">
    <asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >  
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder21" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder22" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder23" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder24" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder25" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder26" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder27" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder28" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder29" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder30" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder31" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder32" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder33" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder34" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder35" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder36" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder37" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder38" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder39" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder40" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder41" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder42" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder43" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder44" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder45" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder46" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder47" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder48" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder49" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder50" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder51" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder52" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder53" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder54" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder55" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder56" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder57" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder58" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder59" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder60" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder61" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder62" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder63" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder64" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder65" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder66" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder67" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder68" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder69" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder70" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder71" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder72" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder73" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder74" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder75" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder76" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder77" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder78" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder79" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder80" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder81" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder82" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder83" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder84" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder85" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder86" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder87" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder88" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder89" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder90" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder91" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder92" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder93" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder94" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder95" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder96" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder97" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder98" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder99" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder100" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder101" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder102" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder103" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder104" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder105" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder106" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder107" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder108" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder109" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder110" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder111" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder112" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder113" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder114" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder115" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder116" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder117" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder118" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder119" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder120" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder121" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder122" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder123" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder124" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder125" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder126" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder127" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder128" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder129" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder130" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder131" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder132" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder133" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder134" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder135" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder136" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder137" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder138" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder139" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder140" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder141" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder142" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder143" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder144" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder145" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder146" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder147" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder148" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder149" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder150" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder151" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder152" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder153" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder154" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder155" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder156" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder157" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder158" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder159" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder160" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder161" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder162" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder163" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder164" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder165" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder166" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder167" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder168" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder169" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder170" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder171" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder172" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder173" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder174" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder175" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder176" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder177" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder178" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder179" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder180" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder181" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder182" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder183" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder184" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder185" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder186" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder187" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder188" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder189" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder190" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder191" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder192" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder193" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder194" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder195" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder196" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder197" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder198" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder199" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder200" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder201" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder202" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder203" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder204" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder205" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder206" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder207" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder208" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder209" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder210" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder211" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder212" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder213" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder214" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder215" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder216" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder217" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder218" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder219" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder220" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder221" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder222" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder223" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder224" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder225" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder226" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder227" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder228" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder229" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder230" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder231" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder232" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder233" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder234" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder235" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder236" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder237" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder238" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder239" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder240" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder241" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder242" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder243" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder244" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder245" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder246" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder247" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder248" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder249" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder250" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder251" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder252" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder253" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder254" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder255" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder256" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder257" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder258" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder259" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder260" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder261" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder262" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder263" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder264" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder265" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder266" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder267" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder268" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder269" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder270" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder271" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder272" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder273" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder274" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder275" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder276" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder277" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder278" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder279" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder280" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder281" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder282" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder283" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder284" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder285" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder286" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder287" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder288" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder289" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder290" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder291" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder292" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder293" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder294" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder295" runat="server"></asp:PlaceHolder>
     </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >
   <!--Place holder End-->
    <!--Start Heading-->
    <asp:Panel ID="pnlBusVerHead" runat="server" Width="100%" Visible="false">
    <table>
    <tr>
    <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
        <asp:Label SkinID="lblSkin" ID="lblBusVerHead" runat="server" ForeColor="blue" Text="BUSINESS VERIFICATION REPORT" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
    <!--END Heading-->
    <!--Start Personal Detail-->    
    <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAppName" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin"  ID="lblAppName" runat="server" Text=" Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtAppName" runat="server" ReadOnly="True" Width="60%"></asp:TextBox>
            </td>
          
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth"><asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtRefNo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlInitiationDate" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox>
             <img id="imgInitiationDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtInitiationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlAgencyCode" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAgencyCode" style="width:100%" runat="server">      
           <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server" Text="Agency Code"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtAgencyCode" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeAddress" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAddress" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeAddress" runat="server" Text="Address (Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeAddress" TextMode="MultiLine" runat="server"  Width="80%" MaxLength="500" ></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    
    <%--Mashrque Bank cod start --%>
       <asp:Panel ID="pnlEmirates" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblEmirates" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblEmirates" runat="server" Text="Emirates"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtEmirates" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlPoboxNo" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPoboxNo" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPoboxNo" runat="server" Text="Pobox No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtPoboxNo" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlSignboardDoor" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSignboardDoor" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSignboardDoor" runat="server" Text="Type of Signboard Door"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtSignboardDoor" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlModeSalary" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblModeSalary" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblModeSalary" runat="server" Text="Mode of Salary(for all employees)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtModeSalary" runat="server"  Width="80%"></asp:TextBox>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlModeSalary" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>WPS</asp:ListItem> 
                    <asp:ListItem>Bank Transfer</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>Cash</asp:ListItem>                               
                                                  
                </asp:DropDownList>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlBusiTo" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblBusiTo" runat="server" Text="Business T/O"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtBusiTo" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlCompClients" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblCompClients" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblCompClients" runat="server" Text="Company Clients"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtCompClients" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlCompBank" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblCompBank" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblCompBank" runat="server" Text="Company Banking With"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtCompBank" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOffice1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOffice1" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOffice1" runat="server" Text="Office1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtOffice1" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOffice2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOffice2" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOffice2" runat="server" Text="Office2"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOffice2" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOffice3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOffice3" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOffice3" runat="server" Text="Office3"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOffice3" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOffice4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOffice4" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOffice4" runat="server" Text="Office4"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOffice4" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlDateJoin" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblDateJoin" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDateJoin" runat="server" Text="Date Of Joining"></asp:Label>

            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtDateJoin" runat="server"  Width="15%"></asp:TextBox>
                <img id="img8"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateJoin.ClientID%>, 'dd/mm/yyyy', 0, 0);" />

            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlApplicantReport" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantReport" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblApplicantReport" runat="server" Text="Applicant Reports to"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtApplicantReport" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlDesig" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblDesig" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDesig" runat="server" Text="Designation:"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtDesig" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
     <asp:Panel ID="pnlApplicantOwner" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantOwner" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="iblApplicantOwner" runat="server" Text="Whether the applicant is related to the OWNER or AUTHORIZED SIGNATORY"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantOwner" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
    <asp:Panel ID="pnlYesRelation" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblYesRelation" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblYesRelation" runat="server" Text="IF Yes Relation"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtYesRelation" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetailsVerified" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblDetailsVerified" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDetailsVerified" runat="server" Text="Details Verified With"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtDetailsVerified" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    
    
    
    
    
    
    
    
    <asp:Panel ID="pnlLoanNumber" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLoanNumber" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLoanNumber" runat="server" Text="Loan account Number"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtLoanNumber" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    
    
    <%--Start of Fields for Dubai---ENBDABHI--%>
         
          
           <asp:Panel ID="PnlphysicalAdreess" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table139" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label120" runat="server" Text="Does the registeredn address match the physical Address ?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlphysicaladdress" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
           
             <asp:Panel ID="PnlreasonsOfmailing" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table140" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label121" runat="server" Text="Reason For Differences in Mailing Address & Site Visit Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtreasonsOfmailing" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
              <asp:Panel ID="Pnlnatureofbussinessactivityobserved" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table141" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label122" runat="server" Text="Describe Nature Of Business & Activity Observed"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtnatureofbussinessactivityobserved" runat="server" TextMode="MultiLine"  Width="80%" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
           
         
         
         
         
           <!--End of Fields For ENBD_SME (Dubai)-->
           
    
    
    
    
    <%--Add for Dubai new utility 01/10/2010 santosh--%>
    <asp:Panel ID="pnlUploadAttach" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblUploadAttach" style="width:100%" runat="server">
    <tr>
           <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label8" Font-Bold="true" Font-Size="Small" runat="server" Text="UPLOAD DOCUMENTS"></asp:Label>
            </td>
    </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label6" runat="server" Text="1st Attachment"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:FileUpload ID="FileUpload1" Width="70%"  runat="server"  SkinID="flup"/>
                 <a href="javascript:openwindow('1');" title="View Uploaded Image1">View Uploaded Image1</a>            
            </td>
           
        </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label7" runat="server" Text="2nd Attachment"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                 <asp:FileUpload ID="FileUpload2" Width="70%"  runat="server" SkinID="flup" />
                  <a href="javascript:openwindow('2');" title="View Uploaded Image2">View Uploaded Image2</a>
 
            </td>
           
        </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label9" runat="server" Text="3rd Attachment"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                 <asp:FileUpload ID="FileUpload3" Width="70%"  runat="server" SkinID="flup"/>
                 <a href="javascript:openwindow('3');" title="View Uploaded Image3">View Uploaded Image3</a>

            </td>           
        </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label10" runat="server" Text="4th Attachment"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                 <asp:FileUpload ID="FileUpload4" Width="70%" runat="server" SkinID="flup"/>
                  <a href="javascript:openwindow('4');" title="View Uploaded Image4">View Uploaded Image4</a>

            </td>           
        </tr>
        <tr>         
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label11" runat="server" Text="5th Attachment"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                 <asp:FileUpload ID="FileUpload5" Width="70%"  runat="server" SkinID="flup"/>
                  <a href="javascript:openwindow('5');" title="View Uploaded Image5">View Uploaded Image5</a>
            </td>           
        </tr>
         </table>
    </asp:Panel>
    <%--End Code--%>
    
    <asp:Panel ID="pnlRefTelNumber" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblRefTelNumber" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRefTelNumber" runat="server" Text="Personal Reference Tel Number"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRefTelNumber" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
    <asp:Panel ID="pnlRefCont" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblRefCont" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRefCont" runat="server" Text="Personal reference contacted"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtRefCont" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlArea" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblArea" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblArea" runat="server" Text="Area"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtArea" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlEmirate1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblEmirate1" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblEmirate1" runat="server" Text="Emirate1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtEmirate1" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlLoanAppli" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLoanAppli" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLoanAppli" runat="server" Text="Is the office location same as the original loan application"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
               <%-- <asp:TextBox SkinID="txtSkin"  ID="txtLoanAppli" runat="server"  Width="80%"></asp:TextBox>--%>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlLoanAppli" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlLocation" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLocation" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLocation" runat="server" Text="Location"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtLocation" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    
     <%--Mashrque Bank cod End--%>
          
    <asp:Panel ID="pnlPinCode" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPinCode" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPincode" runat="server" Text="Pincode"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtPincode" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlLandmark" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  >
                <asp:TextBox SkinID="txtSkin"  ID="txtLandmark" runat="server" MaxLength="250"></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeTel" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeTel" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeTel" runat="server" Text="Telephone No(Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeTel" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlPPNormal" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPPNormal" style="width:100%" runat="server">             
    <tr>
         <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPPNormal" runat="server" Text="Telehone No (Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtPPNormal" runat="server"></asp:TextBox>
            
            <asp:DropDownList SkinID="ddlSkin" ID="ddlPPNormal" runat="server"  AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>PP</asp:ListItem>
                <asp:ListItem>Normal</asp:ListItem>
            </asp:DropDownList></td>
            
             </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeExtn" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeExtn" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeExtn" runat="server" Text="Extn No (If any)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeExtn" runat="server" MaxLength="5"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblMobile" style="width:100%" runat="server">             
    <tr>
    <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMobile" runat="server" Text="Mobile No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtMobile" runat="server" ></asp:TextBox></td>
            
        </tr>
    </table>
    </asp:Panel>
    
    <!--END Personal Detail-->
    <!--Start Verification Head-->
    <asp:Panel ID="pnlVerDtlHead" runat="server" Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center" style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold">
        <asp:Label SkinID="lblSkin" ID="lblVerDtlHead" runat="server" ForeColor="blue" Text="VERIFICATION DETAILS" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
    <!--END Verification Head-->
    <!--Start Verification Details-->    
        <asp:Panel ID="pnlContactPersonName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblContactPersonName" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContactPersonName" runat="server" Text="Name of person contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtContactPersonName" runat="server" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlContPersonDesgn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblContPersonDesgn" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContPersonDesgn" runat="server" Text="Designation of person contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtContPersonDesgn" runat="server" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlPersonContact" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPersonContact" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonContact" runat="server" Text="Person Contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtPersonContact" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
        <asp:Panel ID="pnlCompanyName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblCompanyName" runat="server" Text="Name of Firm/Company"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtCompanyName" runat="server" MaxLength="100" ></asp:TextBox>
            </td>
            </tr>
          </table>
        </asp:Panel>                
        <asp:Panel ID="pnlNoOfYrCompany" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrCompany" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblNoOfYrCompany" runat="server" Text="No of years of existence of company"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrCompany" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDesgnOfApplicant" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDesgnOfApplicant" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDesgnOfApplicant" runat="server" Text="Designation of applicant"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtDesgnOfApplicant" runat="server" MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>        
        <asp:Panel ID="pnlTimeCurr" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurr" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblTimeCurrOffYrs" runat="server" Text="Time at curr empl/business (Yrs/mths)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtTimeCurrOffYrs" runat="server"  MaxLength="2"></asp:TextBox>Yrs             
             <asp:TextBox SkinID="txtSkin" Width="5%"   ID="txtTimeCurrOffMths" runat="server"  MaxLength="2"></asp:TextBox>Mths
             </td>            
             
            </tr>
            </table>
        </asp:Panel>                
        <asp:Panel ID="pnlTypeOfJob" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfJob" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblTypeOfJob" runat="server" Text="Type of Job/emp"></asp:Label>    
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfJob" runat="server"  AutoPostBack="false">
                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Contract Worker" Value="Contract Worker"></asp:ListItem>
                <asp:ListItem Text="Permanent" Value="Permanent"></asp:ListItem>
                <asp:ListItem Text="Probation" Value="Probation"></asp:ListItem>
                <asp:ListItem Text="Temporary Worker" Value="Temporary Worker"></asp:ListItem>            
            </asp:DropDownList>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlOffPrmises" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblOffPrmises" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOffPrmises" runat="server" Text="Office/Business premises"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin" ID="ddlOffPrmises" runat="server"  AutoPostBack="false">
            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>        
                <asp:ListItem Text="Self owned" Value="Self owned"></asp:ListItem>
                <asp:ListItem Text="Family owned" Value="Family owned"></asp:ListItem>
                <asp:ListItem Text="Friend owned" Value="Friend owned"></asp:ListItem>
                <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                <asp:ListItem Text="Pagdi" Value="Pagdi"></asp:ListItem>
                <asp:ListItem Text="Leased" Value="Leased"></asp:ListItem>
                </asp:DropDownList>    
            </td>
            </tr>
            </table>
         </asp:Panel>  
         <asp:Panel ID="pnlOtherOffPrmises" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherOffPrmises" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOffPrmises" runat="server" Text="If Others spcify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtOtherOffPrmises" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>       
         <!--End Verification Detail-->
          <!--Start Heading-->
        <asp:Panel ID="pnlAdditonalInfoHead" runat="server" Width="100%" Visible="false">
        <table> <tr>
        <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">         
        <asp:Label SkinID="lblSkin" ID="lblAdditonalInfoHead" runat="server" ForeColor="blue" Text="IF APPLICANT IS CONTACTED (ADDITIONAL INFORMATION TO BE OBTAINED)" Font-Bold="True"></asp:Label>
        </td>
        </tr>  
        </table>

        </asp:Panel>
        <!--END Heading-->
        <!--Start Additional Information-->
        <asp:Panel ID="pnlAddTrace" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAddTrace" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAddTrace" runat="server" Text="Address Difficult to Trace"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtAddTrace" Width="80%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpokeTo" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpokeTo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpokeTo" runat="server" Text="Spoke To"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpokeTo" Width="80%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlAddRec" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAddRec" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAddRec" runat="server" Text="Address as Received"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtAddRec" Width="80%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlAddDiff" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAddDiff" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAddDiff" runat="server" Text="Address Received Completely Different"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtAddDiff" Width="80%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
        
        
        <asp:Panel ID="pnlNameEmp" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNameEmp" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblNameEmp" runat="server" Text="Name & Employee"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameEmp" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel> 
         <asp:Panel ID="pnlResiBuss" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblResiBuss" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblResiBuss" runat="server" Text="Resi Cum Business"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtResiBuss" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel> 
        <asp:Panel ID="pnlDateTimeVisit" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDateTimeVisit" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDateTimeVisit" runat="server"  Text="Date of Visit"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin" ID="txtDateTimeVisit" runat="server"></asp:TextBox>
             <img id="img3"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateTimeVisit.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            <asp:Label SkinID="lblSkin" ID="lblVisit" runat="server"  Text="Time of Visit"></asp:Label>
           <asp:TextBox SkinID="txtSkin" ID="txtVisit" runat="server"></asp:TextBox> 
           </td>
           </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlAddUpd" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAddUpd" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAddUpd" runat="server" Text="Address Updation"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddUpd" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel> 
        <asp:Panel ID="pnlDocVeri" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDocVeri" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDocVeri" runat="server" Text="Document Verified"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDocVeri" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel> 
        <asp:Panel ID="pnlVisitProofDet" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVisitProofDet" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblVisitProofDet" runat="server" Text="Visit Proof Details"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtVisitProofDet" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel> 
        
        
        <asp:Panel ID="pnlDOB" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin"  ID="txtDOB" runat="server" MaxLength="11" ></asp:TextBox>
             <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
           </td>
           </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlIncomeDoc" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIncomeDoc" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIncomeDoc" runat="server" Text="Income document submitted with application"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlIncomeDoc" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPerAddress" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddress" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPerAddress" runat="server" Text="Permanent Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtPerAddress" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlVerPhoneNo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVerPhoneNo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblVerPhoneNo" runat="server" Text="Phone No"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtVerPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlAddOnApplication" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAddOnApplication" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAddOnApplication" runat="server" Text="Given Resi Add On Application(Y/N)"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtAddOnApplication"  Width="80%" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPhOnApplication" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPhOnApplication" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblPhOnApplication" runat="server" Text="Phone No"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtPhOnApplication" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <!--End Additional Information-->                         
        <!--Start Observation Head-->
        <asp:Panel ID="pnlObservationHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
            <asp:Label SkinID="lblSkin" ID="lblObservationHead" runat="server" ForeColor="blue" Text="OBSERVATIONS" Font-Bold="True"></asp:Label>
        </td>
        </tr>
        </table>
        </asp:Panel>        
        <!--END Observation Head-->
        <!--Start OBSERVATIONS-->
        <asp:Panel ID="pnlVisibleNameBoard" runat="server" Width="100%" Visible="false">                
        <table cellpadding="0" cellspacing="0" border="0" id="tblVisibleNameBoard" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisibleNameBoard" runat="server" Text="Visibility of the name board / Business Board Seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisibleNameBoard" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Visible</asp:ListItem>
                    <asp:ListItem>Non Visible</asp:ListItem>                    
                    <asp:ListItem>Others</asp:ListItem>   
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVisibleNameBoard" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVisibleNameBoard" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNonVisibleReason" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNonVisibleReason" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNonVisibleReason" runat="server" Text="If non visible then the reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNonVisibleReason" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOfficeSize" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeSize" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeSize" runat="server" Text="Size of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td   >
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeSize" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Very small</asp:ListItem>
                    <asp:ListItem>Small</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Large</asp:ListItem>                    
                    <asp:ListItem>Very Large</asp:ListItem>                    
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlApproxArea" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblApproxArea" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server" Text="Approx. area (sq ft)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtApproxArea" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlNoOfEmployee" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployee" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfEmployee" runat="server" Text="No. of employees"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtNoOfEmployee" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlGenAppearance" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblGenAppearance" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblGenAppearance" runat="server" Text="General appearance of the office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlGenAppearance" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>shabby</asp:ListItem>
                    <asp:ListItem>unfurnished</asp:ListItem>
                    <asp:ListItem>semifurnished</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                     <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Not Acceptable</asp:ListItem>  
                    <asp:ListItem>Fair</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>                    
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlLocalityOffice" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocalityOffice" runat="server" Text="Locality of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityOffice" runat="server"  AutoPostBack="false">
                     <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Commercial Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Shop/Office Complex</asp:ListItem>
                    <asp:ListItem>Small Scale Industrial Area</asp:ListItem>
                    <asp:ListItem>Plant</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Godown</asp:ListItem>
                    <asp:ListItem>Shopping Mall</asp:ListItem>  
                    <asp:ListItem>Negative Location</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherLocalityOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherLocalityOffice" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlReputationOffice" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblReputationOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblReputationOffice" runat="server" Text="Reputation of off in the locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlReputationOffice" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Fair</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        
        <asp:Panel ID="pnlLocatingOfficeAdd" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocatingOfficeAdd" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocatingOfficeAdd" runat="server" Text="Locating the office address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingOfficeAdd" runat="server"  AutoPostBack="false">
                    <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                    <asp:ListItem>Untraceable</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
       <asp:Panel ID="pnlOfficeIsIn" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeIsIn" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeIsIn" runat="server" Text="Office is in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeIsIn" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Commercial Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Shop/Office Complex</asp:ListItem>
                    <asp:ListItem>Small Scale Industrial Area</asp:ListItem>
                    <asp:ListItem>Plant</asp:ListItem>
                    <%--asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem--%>
                    <asp:ListItem>Others</asp:ListItem>                                 
                </asp:DropDownList>   
                </td>                
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherOfficeIsIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherOfficeIsIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOfficeIsIn" Width="80%" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherOfficeIsIn"  Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlBusinessType" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessType" runat="server" Text="Type of business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessType" runat="server"  AutoPostBack="false">
                   <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Partnership</asp:ListItem>
                    <asp:ListItem>Public Ltd.</asp:ListItem>
                    <asp:ListItem>Proprietorship</asp:ListItem>
                    <asp:ListItem>Private Ltd.</asp:ListItem>    
                    <asp:ListItem>Govt/Public sector</asp:ListItem>
                    <asp:ListItem>MNC</asp:ListItem>
                    <asp:ListItem>PSU</asp:ListItem>
                    <asp:ListItem>Software</asp:ListItem>
                    <asp:ListItem>Bank</asp:ListItem>
                    <asp:ListItem>Rlys</asp:ListItem>
                    <asp:ListItem>Colleges</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlOtherBusinessType" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherBusinessType" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherBusinessType" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherBusinessType" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
          <asp:Panel ID="pnlAffPolParty" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAffPolParty" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAffPolParty" runat="server" Text="Affiliation of Political party seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAffPolParty" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
        <asp:Panel ID="pnlEquipInOffice" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblEquipInOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEquipInOffice" runat="server" Text="Equipments sighted in office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkEquipInOffice" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                    <asp:ListItem>A/C</asp:ListItem>
                    <asp:ListItem>Computers</asp:ListItem> 
                    <asp:ListItem>Fax</asp:ListItem> 
                    <asp:ListItem>Photocopier</asp:ListItem>
                    <asp:ListItem>Telephone</asp:ListItem>
                    <asp:ListItem>Machinery</asp:ListItem>
                    <asp:ListItem>Others(specify)</asp:ListItem>
                </asp:CheckBoxList>                           
                </td>                
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnltOtherEquipInOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tbltOtherEquipInOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbltOtherEquipInOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherEquipInOffice" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlBusinessStock" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessStock" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessStock" runat="server" Text="Business stock seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessStock" runat="server"  AutoPostBack="false">
                    <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Very Good</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlStockType" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblStockType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblStockType" runat="server" Text="Type of stock"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtStockType" runat="server"></asp:TextBox>
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
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>   
                    <asp:ListItem>Low</asp:ListItem>   
                    <asp:ListItem>None</asp:ListItem> 
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Very High Activity</asp:ListItem>           
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        
        
        
        
        
        <asp:Panel ID="pnlVisitProof" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblVisitProof" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisitProof" runat="server" Text="Proof of Visit Collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitProof" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVisitProof" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVisitProof" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlRouteMap" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRouteMap" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRouteMap" runat="server" Text="Route map drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRouteMap" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>            
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNegativeArea" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeArea" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNegativeArea" runat="server" Text="Negative area"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNegativeArea" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOCL" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOCL" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOCL" runat="server" Text="OCL"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlOCL" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>    
        </asp:Panel>  
        <!--END OBSERVATIONS-->
        <!--Start Rating HEAD-->
       <asp:Panel ID="pnlTPCHead" runat="server" Width="100%" Visible="false">
       <table>
       <tr>
       <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblTPCHead" runat="server" ForeColor="blue" Text="Third Party Confirmation" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Rating HEAD-->
       
       
       
        <asp:Panel ID="pnlFERemark" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFERemark" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFERemark" runat="server" width="100%" Text="FE Remark "></asp:Label>
                </td><td style="width:2%">:</td>
                <td align="left">
                     <asp:TextBox SkinID="txtSkin"  ID="txtFERemark" runat="server"  Width="80%" TextMode="MultiLine" onkeyPress="ValidateTextLength('FE Remark', this, 10000);"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <!--Start Internal TPC HEAD-->
        
        
        
       <asp:Panel ID="pnlInternalHead" runat="server" Width="100%" Visible="false">
          <table>
          <tr>
          <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblInternalHead" ForeColor="blue" runat="server" Text="INTERNAL"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Internal TPC HEAD-->
        <!--Start Third Party Confirmation-->        
         <asp:Panel ID="pnlTPCDone" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDone" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCDone" runat="server" Text="TPC Done"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCDone" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                    <%--<asp:ListItem>+ve</asp:ListItem>
                    <asp:ListItem>-ve</asp:ListItem>--%>
                    <asp:ListItem>Not Possible</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlTPCDetail" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDetail" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCDetail" runat="server" Text="Details of TPC"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtTPCDetail" runat="server" MaxLength="500" Width="80%"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>  
         <asp:Panel ID="pnlEntryRestricted" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblEntryRestricted" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEntryRestricted" runat="server" Text="Entry Restricted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlEntryRestricted" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel> 
        <asp:Panel ID="pnlAnyInfo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAnyInfo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAnyInfo" runat="server" Text="Any other information obtained"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                <asp:TextBox SkinID="txtSkin"  ID="txtAnyInfo" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
         <!--Start External TPC HEAD-->
       <asp:Panel ID="pnlExternalHead" runat="server" Width="100%" Visible="false">
          <table>
          <tr>
          <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblExternalHead" ForeColor="blue" runat="server" Text="EXTERNAL"></asp:Label>
          </td>
          </tr>
          </table>    
       </asp:Panel>
      <!--END External TPC HEAD-->        
        <asp:Panel ID="pnlTPCNameCompanyName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="yblTPCNameCompanyName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCNameCompanyName" runat="server" Text="Name of the TPC with Company/shop name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtTPCNameCompanyName" runat="server" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
         <asp:Panel ID="pnlNoOfYrsPresentAddress" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrsPresentAddress" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfYrsPresentAddress" runat="server" Text="No of years at the present address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrsPresentAddress" runat="server" MaxLength="9" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusinessNature" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessNature" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessNature" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtBusinessNature"  Width="80%" TextMode="MultiLine"  runat="server"  ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNoOfEmployeeTPC" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployeeTPC" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfEmployeeTPC" runat="server" Text="No. of employee Sighted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmployeeTPC" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <%--<asp:Panel ID="pnlFERemark" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFERemark" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblFERemark" runat="server" Text="FE Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtFERemark" runat="server" TextMode="MultiLine"   onkeyPress="ValidateTextLength('FE Remark', this, 3000);" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>--%>
       
        
       <!--END Third Party Confirmation-->
       <!--Start Rating HEAD-->
       <asp:Panel ID="pnlRatingHead" runat="server" Width="100%" Visible="false">
       <table>
       <tr>
       <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%">
          <asp:Label SkinID="lblSkin" ID="lblRatingHead" runat="server" ForeColor="blue" Text="RATING" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Rating HEAD-->
       <!--Start RATING-->    
             
         <asp:Panel ID="pnlAddConfirmation" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfirmation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblAddConfirmation" runat="server" Text="Address Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAddConfirmation" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
               </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlContactability" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblContactability" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblContactability" runat="server" Text="Contactability"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlContactability" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlConfirmationApp" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConfirmationApp" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConfirmationApp" runat="server" Text="Confirmation of Application"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlConfirmationApp" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
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
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlProfile" runat="server"  AutoPostBack="false">
                     <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlReputationTPC" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblRepurationTPC" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReputationTPC" runat="server" Text="Reputation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                       <asp:DropDownList SkinID="ddlSkin" ID="ddlReputationTPC" runat="server"  AutoPostBack="false">
                            <asp:ListItem>NA</asp:ListItem>
                            <asp:ListItem>a</asp:ListItem>
                            <asp:ListItem>b</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
           </table>
           </asp:Panel>                            
           <asp:Panel ID="pnlOverallAsst" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOverallAsst" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOverallAsst" runat="server" Text="Overall Assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtOverallAsst" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlAsstReason" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAsstReason" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAsstReason" runat="server" Text="Reasons for the above assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAsstReason" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <!--END RATING-->
            <!--Start to ADD Additional Field-->
            <asp:Panel ID="pnlCoAppName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCoAppName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCoAppName" runat="server" Text="Co-App Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtCoAppName" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>           
           <asp:Panel ID="pnlExtNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExtNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExtNo" runat="server" Text="Ext. No."></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtExtNo" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlParticulars" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblParticulars" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblParticulars" runat="server" Text="Particulars"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtParticulars" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAverageMonthlyTurnover" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAverageMonthlyTurnover" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAverageMonthlyTurnover" runat="server" Text="( FOR SELF Employed) Average Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAverageMonthlyTurnover" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoCustomersPerDay" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoCustomersPerDay" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoCustomersPerDay" runat="server" Text="No. of Customers per day"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNoCustomersPerDay" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlApplicantJobTransferable" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantJobTransferable" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicantJobTransferable" runat="server" Text="Applicant Job Transferable"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                    
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantJobTransferable" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlPreviousEmploymentDetails" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPreviousEmploymentDetails" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPreviousEmploymentDetails" runat="server" Text="Previous Employment details( if working for< 1 year in current employment)"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtPreviousEmploymentDetails" runat="server"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameofCompany" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameofCompany" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameofCompany" runat="server" Text="Name of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtNameofCompany" runat="server"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlYearsWorkedIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsWorkedIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsWorkedIn" runat="server" Text="Years worked in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtYearsWorkedIn" runat="server" MaxLength="2"></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtMthsWorkedIn"  runat="server" MaxLength="2"></asp:TextBox>Mths                      
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSalaryDrawn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSalaryDrawn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSalaryDrawn" runat="server" Text="Salary Drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin"  ID="txtSalaryDrawn" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlConstructionOfOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConstructionOfOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConstructionOfOffice" runat="server" Text="Construction of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlConstructionOfOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem>N/C</asp:ListItem>
                        <asp:ListItem>Pukka</asp:ListItem>
                        <asp:ListItem>Semi-Pukka</asp:ListItem> 
                        <asp:ListItem>Temporary</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlNoOfCustomersSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfCustomersSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfCustomersSeen" runat="server" Text="No. of Customers Seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfCustomersSeen" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlPriorityCustomer" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPriorityCustomer" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPriorityCustomer" runat="server" Text="Priority Customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtPriorityCustomer" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSegmentation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSegmentation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSegmentation" runat="server" Text="Segmentation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSegmentation" runat="server" MaxLength="1000" Width="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlInfoRequired" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRequired" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRequired" runat="server" Text="Info. Required"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtInfoRequired" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlChangeAddress" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblChangeAddress" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblChangeAddress" runat="server" Text="Change Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlChangeAddress" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlReasonForChanges" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForChanges" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForChanges" runat="server" Text="If yes, Reason for Changes"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonForChanges" runat="server" Width="80%" MaxLength="50"></asp:TextBox>                    
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelationofPersonContacted" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationofPersonContacted" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblRelationofPersonContacted" runat="server" Text="Relation of Person Contacted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlRelationofPersonContacted" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>ABNR</asp:ListItem>
                        <asp:ListItem>Brother</asp:ListItem>
                        <asp:ListItem>Childern</asp:ListItem>
                        <asp:ListItem>Father</asp:ListItem>
                        <asp:ListItem>Friends</asp:ListItem>
                        <asp:ListItem>Grandfather</asp:ListItem>
                        <asp:ListItem>Grandmother</asp:ListItem>
                        <asp:ListItem>Husband</asp:ListItem>                        
                        <asp:ListItem>Inlaws</asp:ListItem>                        
                        <asp:ListItem>Mother</asp:ListItem>
                        <asp:ListItem>Sister</asp:ListItem>
                        <asp:ListItem>Wife</asp:ListItem>
                        <asp:ListItem>Colleague</asp:ListItem>
                        <asp:ListItem>Manager</asp:ListItem>
                        <asp:ListItem>Security</asp:ListItem>
                        <asp:ListItem>Asst Manager</asp:ListItem>
                        <asp:ListItem>PROP</asp:ListItem>
                        <asp:ListItem>Senior</asp:ListItem>
                        <asp:ListItem>Junior</asp:ListItem>
                        <asp:ListItem>Receptionist</asp:ListItem>
                        <asp:ListItem>Peon</asp:ListItem>
                        <asp:ListItem>Partner</asp:ListItem>
                        <asp:ListItem>Others(Pl.Specify)</asp:ListItem>
                    </asp:DropDownList>
                </td>                 
            </tr>
            </table>               
           </asp:Panel>
           <asp:Panel ID="pnlOtherRelation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherRelation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherRelation" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherRelation" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlDeatailsOfProofCollected" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDeatailsOfProofCollected" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDeatailsOfProofCollected" runat="server" Text="(If Proof collect =Yes) Deatails of Proof collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDeatailsOfProofCollected" runat="server" Width="80%" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="pnlOthers1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOthers1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOthers1" runat="server" Text="others1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOthers1" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             <asp:Panel ID="pnlOthers2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOthers2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOthers2" runat="server" Text="others2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOthers2" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            
           <asp:Panel ID="pnlCPVscore" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCPVscore" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCPVscore" runat="server" Text="CPV score"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCPVscore" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResiCumoff" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResiCumoff" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResiCumoff" runat="server" Text="If Nature of Busi Resi Cum off"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResiCumoff" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoofYrsatthisAdd" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoofYrsatthisAdd" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoofYrsatthisAdd" runat="server" Text="No. of Yrs at this Add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoofYrsatthisAdd" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoofResidents" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoofResidents" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoofResidents" runat="server" Text="No. of Residents"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtNoofResidents" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlTypeofResi" runat="server" Width="100%" Visible="false">
             <table id="tblTypeofResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblTypeofResi" runat="server" Text="Type of Resi"></asp:Label>
                </td>
                <td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                 <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofResi" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem> 
                    <asp:ListItem Text="Bachelor acco" Value="Bachelor acco"></asp:ListItem>                
                    <asp:ListItem Text="Co.Provided" Value="Co.Provided"></asp:ListItem>
                    <asp:ListItem Text="Family/Ancestral" Value="Family/Ancestral"></asp:ListItem>
                    <asp:ListItem Text="Own" Value="Own"></asp:ListItem>                
                    <asp:ListItem Text="Leased" Value="Paying guest"></asp:ListItem>                
                    <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
            </table>
           </asp:Panel>
            <asp:Panel ID="pnlResicomoffOwned" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResicomoffOwned" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResicomoffOwned" runat="server" Text="IF Resi. cum off Owned ( Fly/ Self owned)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResicomoffOwned" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Fly</asp:ListItem>
                        <asp:ListItem>Self owned</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlSeparateareforOff" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateareforOff" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateareforOff" runat="server" Text="Separate are for Off"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateareforOff" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlTypeofacco" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeofacco" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeofacco" runat="server" Text="Type of acco."></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofacco" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlInformationRefused" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInformationRefused" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInformationRefused" runat="server" Text="Information refused"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin"  ID="txtInformationRefused" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAssetsSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAssetsSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAssetsSeen" runat="server" Text="Assets seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                   
                    <asp:CheckBoxList ID="chkAssetsSeen" runat="server" RepeatColumns="8" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                        <asp:ListItem>AC</asp:ListItem>
                        <asp:ListItem>PC</asp:ListItem>
                        <%--asp:ListItem>Cooler</asp:ListItem>
                        <asp:ListItem>Music System</asp:ListItem>
                        <asp:ListItem>Refrigerator</asp:ListItem>
                        <asp:ListItem>TV</asp:ListItem--%>                       
                        <asp:ListItem>Xerox</asp:ListItem>
                        <asp:ListItem>Telephone</asp:ListItem>
                        <asp:ListItem>Fax</asp:ListItem>
                        <asp:ListItem>Printer</asp:ListItem>
                        <asp:ListItem>Tables</asp:ListItem>
                        <asp:ListItem>Stocks</asp:ListItem>               
                        <asp:ListItem>Cabins</asp:ListItem>
                        <asp:ListItem>Chairs</asp:ListItem>
                        <asp:ListItem>Others(specify)</asp:ListItem>
                    </asp:CheckBoxList> 
                </td>
                </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlOtherAssestSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherAssestSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherAssetsSeen" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherAssestSeen" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             <asp:Panel ID="pnlBranches" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranches" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranches" runat="server" Text="Branches"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtBranches" runat="server" Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlIfAppFullTimeEmp" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfAppFullTimeEmp" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfAppFullTimeEmp" runat="server" Text="If the Applicant is a full time Employee"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfAppFullTimeEmp" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
           
           
                             <!--Aixis Merchant Added By Rupesh-->    
                             
                             
       <asp:Panel ID="pnlifbusactntseen" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="Table15" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblifbusactntseen" runat="server" Text="If Business activity not seen remarks :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtifbusactntseen" Width="80%" runat="server" ></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
           
              <asp:Panel ID="pnlNegtvInfrmMerinfrn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table10" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNegtvInfrmMerinfrn" runat="server" Text="Any Negative Information about the Merchant Establishment :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlNgtvinfabtmerchant" runat="server"  AutoPostBack="false">
                             <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Multiple Business</asp:ListItem>
                        <asp:ListItem>Market Feedback not satisfactory</asp:ListItem>   
                        <asp:ListItem>Shop not existing at the address</asp:ListItem>
                        <asp:ListItem>Low Business Profile/ Profile not Satisfactory</asp:ListItem>
                        <asp:ListItem>Shop closed past few days</asp:ListItem>
                        <asp:ListItem>Under Construction</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
            <asp:Panel ID="PnlRecommendation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table11" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblRecommendation" runat="server"  Text="Recommendation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlRecommendation" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                        <asp:ListItem Text="Refer" Value="Refer"></asp:ListItem>
                     <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="PnlInfrastructureRemarks" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table12" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfrastructureRemarks" runat="server" Text="Infrastructure Remarks / Approx Value:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtInfrastructureRemarks" runat="server" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="PnlNameBoardType" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table13" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblNameBoardType" runat="server"  Text="Type Of Name Board" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlNameBoardType" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem>Digital Name board</asp:ListItem>
                        <asp:ListItem>Regular</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="PnlCurrentntAdd" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table14" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblCurrentntAdd" runat="server"  Text="Current Address Info :" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlCurrntAddInfo" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem>Single Outlet</asp:ListItem>
                        <asp:ListItem>Branch</asp:ListItem>
                        <asp:ListItem>Head Office</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Pnlmerchantcategory" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblmerch" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblmerchantcategry" runat="server" Text="Merchant Category :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtMerchantCategry" runat="server" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
                       <!--Aixis Merchant Added By Rupesh-->    
           
           
           
           
           
           
           <asp:Panel ID="pnlApproximateAppAge" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproximateAppAge" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproximateAppAge" runat="server" Text="Approximate Applicant age"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtApproximateAppAge" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <asp:Panel ID="pnlTPCTypeofCompany" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCTypeofCompany" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPCTypeofCompany" runat="server" Text="TPC Type of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCTypeofCompany" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlTPCTypeofBusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCTypeofBusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPCTypeofBusiness" runat="server" Text="TPC Type of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCTypeofBusiness" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResonsAddrnotconfirmed" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResonsAddrnotconfirmed" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResonsAddrnotconfirmed" runat="server" Text="Reasons for address not confirmed"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResonsAddrnotconfirmed" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
                 <asp:Panel ID="pnlUntreaceablereason" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblUntreaceablereason" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblUntreaceablereason" runat="server" Text="If Adress not confirmed = Untreaceable reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtUntreaceablereason" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocality" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocality" runat="server" Text="Locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocality" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Low class area</asp:ListItem>
                    <asp:ListItem>Lower Middle class</asp:ListItem>
                    <asp:ListItem>Middle class</asp:ListItem>
                    <asp:ListItem>Upper Middle class</asp:ListItem>
                    <asp:ListItem>Posh</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlResultofCalling" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResultofCalling" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResultofCalling" runat="server" Text="Result of Calling"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtResultofCalling" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
              <asp:Panel ID="pnlMismatchresidenceadd" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMismatchresidenceadd" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMismatchresidenceadd" runat="server" Text="Mismatch In residence add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtMismatchresidenceadd" runat="server" Width="80%" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
               <asp:Panel ID="pnlIsApplicantknowntotheperson" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsApplicantknowntotheperson" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsApplicantknowntotheperson" runat="server" Text="is Applicant known to the person"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsApplicantknowntotheperson" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="pnlwhomdoesaddbelong" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblwhomdoesaddbelong" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblwhomdoesaddbelong" runat="server" Text="To whom does the add belong"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtwhomdoesaddbelong" runat="server" Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            
               <asp:Panel ID="pnlApplMetat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplMetat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplMetat" runat="server" Text="Appl. Met at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlApplMetat" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>His Desk</asp:ListItem>
                        <asp:ListItem>Reception</asp:ListItem>            
                        <asp:ListItem>Others</asp:ListItem> 
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlOtherApplMetat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherApplMetat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherApplMetat" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherApplMetat" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
               <asp:Panel ID="pnlVerificationconductedat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVerificationconductedat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVerificationconductedat" runat="server" Text="Verification conducted at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlVerificationconductedat" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Applicant's Address</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlOtherVerificationconductedat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVerificationconductedat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVerificationconductedat" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVerificationconductedat" Width="80%" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDirectoryCheck" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDirectoryCheck" runat="server" Text="Directory Check"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:CheckBoxList ID="chkDirectoryCheck" runat="Server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                        <asp:ListItem>W01-Both Matched</asp:ListItem>
                        <asp:ListItem>W02-Both Mismatches</asp:ListItem>
                        <asp:ListItem>W03-Name Matched Address Mismatched</asp:ListItem>
                        <asp:ListItem>W04-Address Matched Name Mismatched</asp:ListItem>
                        <asp:ListItem>W05-Not Found in Web Check, Invalid No.</asp:ListItem>
                        <asp:ListItem>W06-PVT Checked</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                </tr>
               </table>
            </asp:Panel>
            
            <asp:Panel ID="pnlSupervisorReamarks" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorReamarks" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSupervisorReamarks" runat="server" Text="Supervisor Reamarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtSupervisorReamarks" runat="server" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlWhoareyourcustomer" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblWhoareyourcustomer" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblWhoareyourcustomer" runat="server" Text="Who are your customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtWhoareyourcustomer" runat="server" MaxLength="1000" Width="500"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlNeighbour2Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbour2Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbour2Name" runat="server" Text="Neighbour 2 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbour2Name" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlNeighbour2Add" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbour2Add" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbour2Add" runat="server" Text="Neighbour 2 Add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbour2Add" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlCoEstabilshedIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCoEstabilshedIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCoEstabilshedIn" runat="server" Text="Co. Estabilshed in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtCoEstabilshedIn" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <!--START Added New Panels-->
           <asp:Panel ID="pnlVerifiedFrom" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVerifiedFrom" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblVerifiedFrom" runat="server"  Text="Verified from"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlVerifiedFrom" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
                        <asp:ListItem Text="Receptionist" Value="Receptionist"></asp:ListItem>
                        <asp:ListItem Text="Security" Value="Security"></asp:ListItem>   
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    </tr>
                    </table>
            </asp:Panel>             
            <asp:Panel ID="pnlInterior" runat="server"  Width="100%" Visible="false"> 
                <table cellpadding="0" cellspacing="0" border="0" id="tblInterior" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblInterior" runat="server"  Text="Interior" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                    
                    <asp:CheckBoxList ID="chkInterior" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="horizontal">                    
                        <asp:ListItem>Painted</asp:ListItem>
                        <asp:ListItem>Carpeted</asp:ListItem>                 
                        <asp:ListItem>Curtains</asp:ListItem>
                        <asp:ListItem>Clean</asp:ListItem>                                               
                        <asp:ListItem>N/C</asp:ListItem>
                        <asp:ListItem>Others(P1. Specify)</asp:ListItem>                
                </asp:CheckBoxList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherInterior" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherInterior" Width="80%" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlExterior" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExterior" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblExterior" runat="server"  Text="Exterior" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlExterior" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                        <asp:ListItem Text="Average" Value="Average"></asp:ListItem>
                        <asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>                                                            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOtherVerified" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVerified" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVerified" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVerified" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
              <asp:Panel ID="pnlTypeOfOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTypeOfOffice" runat="server" Text="Type of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfOffice" runat="server"  AutoPostBack="false">
                     <asp:ListItem>NA</asp:ListItem>
                   <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Office Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residence cum Office</asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Clinic</asp:ListItem>
                    <asp:ListItem>Shared Office</asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                     <asp:ListItem>Leased</asp:ListItem>
                    <asp:ListItem>Independent Office</asp:ListItem>
                    <asp:ListItem>Small Scale/Shed</asp:ListItem>
                    <asp:ListItem>Undeveloped</asp:ListItem>
                    <asp:ListItem>Office in Commerical Bldg</asp:ListItem>                    
                    <%--asp:ListItem>Plant</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem--%>
                    <asp:ListItem>Others</asp:ListItem>    
                                           
                </asp:DropDownList>   
                </td>                
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherTypeOfOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherTypeOfOffice" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlApplicantWorkingAs" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantWorkingAs" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApplicantWorkingAs" runat="server" Text="Applicant working as"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantWorkingAs" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Sr/Mid. Management</asp:ListItem>
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>Jr.Management</asp:ListItem>
                    <asp:ListItem>Assistant</asp:ListItem>
                    <asp:ListItem>Clerk</asp:ListItem>
                    <asp:ListItem>Typist</asp:ListItem>
                    <asp:ListItem>Middle Management</asp:ListItem>
                    <asp:ListItem>Stenographer</asp:ListItem>
                    <asp:ListItem>Skilled Labor</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>                   
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherApplicantWorkingAs" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherApplicantWorkingAs" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
            <!--END Added New Panels-->                  
            <!--END to ADD Additional Field-->
            
           <!--Start of ATTEMPT DETAIL-->
            
         <!--Start of Fields For City Bank (Dubai)-->
         
          <asp:Panel ID="pnlFaxNumber" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFaxNumber" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFaxNumber" runat="server" Text="Fax Number"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFaxNumber" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsThereSecurityGuardForBuildingOffice" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsThereSecurityGuardForBuildingOffice" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsThereSecurityGuardForBuildingOffice" runat="server"  Text="Is there a security guard for the building / office" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsThereSecurityGuardForBuildingOffice" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsThereReceptionDesk" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsThereReceptionDesk" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsThereReceptionDesk" runat="server"  Text="Is there a reception desk" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsThereReceptionDesk" runat="server"   AutoPostBack="false"> 
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>               
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
          <asp:Panel ID="pnlHowManyDesksWorkStationsTables" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblHowManyDesksWorkStationsTables" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblHowManyDesksWorkStationsTables" runat="server" Text="How many desks / workstations / tables?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtHowManyDesksWorkStationsTables" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsTradeLicenseOfCompanyDisplayedOnPremises" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"  Text="Is the trade license of the company displayed on the premises" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"   AutoPostBack="false"> 
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>               
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>                                                                                
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label1" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherIsTradeLicenseOfCompanyDisplayedOnPremises"  Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNumberOfEmployees" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfEmployees" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNumberOfEmployees" runat="server" Text="Number of employees?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfEmployees" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
      <!--Start of Head For Number of Branches / Offices / Warehouses?-->      
        <asp:Panel ID="pnlNumberOfBranchesOfficesWarehousesHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblNumberOfBranchesOfficesWarehousesHead" runat="server" ForeColor="blue" Text="NUMBER OF BRANCHES / OFFICES / WAREHOUSES?" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Number of Branches / Offices / Warehouses?---> 
       <asp:Panel ID="pnlBranch1Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Location" runat="server" Text="Branch 1 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Location" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1Telephoneno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Telephoneno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Telephoneno" runat="server" Text="Branch 1 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Telephoneno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1RentalAmt" runat="server" Text="Branch 1 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Faxno" runat="server" Text="Branch 1 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="pnlBranch1ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1ManagerName" runat="server" Text="Branch 1 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2Location" runat="server" Text="Branch 2 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2TelephoneNo" runat="server" Text="Branch 2 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2RentalAmt" runat="server" Text="Branch 2 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2Faxno" runat="server" Text="Branch 2 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2ManagerName" runat="server" Text="Branch 2 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3Location" runat="server" Text="Branch 3 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3TelephoneNo" runat="server" Text="Branch 3 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3RentalAmt" runat="server" Text="Branch 3 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3FaxNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3FaxNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3FaxNo" runat="server" Text="Branch 3 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlBranch3ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3ManagerName" runat="server" Text="Branch 3 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlBranch4Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4Location" runat="server" Text="Branch 4 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4Telephoneno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Telephoneno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4Telephoneno" runat="server" Text="Branch 4 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Telephoneno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4RentalAmt" runat="server" Text="Branch 4 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Branch 4 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="pnlBranch4ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4ManagerName" runat="server" Text="Branch 4 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlApplicationNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicationNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicationNo" runat="server" Text="Application No"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtApplicationNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNumberOfBranchesOfficeWarehouse" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfBranchesOfficeWarehouse" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNumberOfBranchesOfficeWarehouse" runat="server" Text="Number Of Branches/Office/Warehouse"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfBranchesOfficeWarehouse" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
       <!--Start of Head For Sponsor’s / Other Partners’ Details-->      
        <asp:Panel ID="pnlSponsorsOtherPartnersDetailsHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblSponsorsOtherPartnersDetailsHead" runat="server" ForeColor="blue" Text="SPONSOR’S / OTHER PARTNERS’ DETAILS" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Sponsor’s / Other Partners’ Details--->  
     
     <asp:Panel ID="pnlSponsor1Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1Name" runat="server" Text="Sponsor 1 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
      </asp:Panel>
           
           <asp:Panel ID="pnlType1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType1" runat="server" Text="Type 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType1" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor1TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1TelephoneNo" runat="server" Text="Sponsor 1 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1TelephoneNo" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor1Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1Address" runat="server" Text="Sponsor 1 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor1Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor1Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2Name" runat="server" Text="Sponsor 2 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlType2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType2" runat="server" Text="Type 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType2" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2TelephoneNo" runat="server" Text="Sponsor 2 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2Address" runat="server" Text="Sponsor 2 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor2Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor2Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3Name" runat="server" Text="Sponsor 3 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlType3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType3" runat="server" Text="Type 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType3" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3TelephoneNo" runat="server" Text="Sponsor 3 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3Address" runat="server" Text="Sponsor 3 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor3Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor3Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNoOfEmpsInSeniorPosition" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmpsInSeniorPosition" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfEmpsInSeniorPosition" runat="server" Text="No of Emps in Senior Position"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmpsInSeniorPosition" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNatureOfBusinessSponsor" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNatureOfBusinessSponsor" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNatureOfBusinessSponsor" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNatureOfBusinessSponsor" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtNatureOfBusinessSponsor')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtNatureOfBusinessSponsor');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlProductDealtWith" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductDealtWith" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductDealtWith" runat="server" Text="Product Dealt With"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtProductDealtWith" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtProductDealtWith')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtProductDealtWith');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
       <!--Start of Head For Banking Relationships?-->      
        <asp:Panel ID="pnlBankingRelationships" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblBankingRelationships" runat="server" ForeColor="blue" Text="BANKING RELATIONSHIPS?" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Banking Relationships?--->  
        <asp:Panel ID="pnlBankName1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName1" runat="server" Text="BankName 1"></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount1" runat="server" Text="Type of Account 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount1" runat="server"  Width="80%"  MaxLength="50"  ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities1" runat="server" Text="Facilities 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities1" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlBankName2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName2" runat="server" Text="BankName 2"></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount2" runat="server" Text="Type of Account 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities2" runat="server" Text="Facilities 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlBankName3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName3" runat="server" Text="BankName 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlTypeOfAccount3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount3" runat="server" Text="Type of Account 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities3" runat="server" Text="Facilities 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlSalesIn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSalesIn" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSalesIn" runat="server" Text="Sales in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkSalesIn" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                    <asp:ListItem>Local Market</asp:ListItem>
                    <asp:ListItem>GCC</asp:ListItem> 
                    <asp:ListItem>Exports</asp:ListItem> 
                   
                </asp:CheckBoxList>                           
                </td>                
                </tr>
                </table>
        </asp:Panel> 
        
        <asp:Panel ID="pnlAvgMonthlyTurnover" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAvgMonthlyTurnover" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAvgMonthlyTurnover" runat="server" Text="Avg Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAvgMonthlyTurnover" runat="server"  Width="80%" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
           <asp:Panel ID="pnlClientList" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblClientList" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblClientList" runat="server" Text="Client List"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtClientList" runat="server"  Width="80%" MaxLength="250" TextMode="multiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtClientList')"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
           <asp:Panel ID="pnlImpressionOfOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblImpressionOfOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblImpressionOfOffice" runat="server" Text="Impression of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtImpressionOfOffice" runat="server"  Width="80%" MaxLength="250" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtImpressionOfOffice')" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystDecision" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystDecision" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblCreditAnalystDecision" runat="server"  Text="Credit Analyst Decision" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlCreditAnalystDecision" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Ok to Process" Value="Ok to Process"></asp:ListItem>
                        <asp:ListItem Text="Declined" Value="Declined"></asp:ListItem>
                                                                                   
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCreditAnalystName" runat="server" Text="Credit Analyst Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditAnalystName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystDate" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystDate" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCreditAnalystDate" runat="server" Text="Credit Analyst Date"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditAnalystDate" runat="server"  Width="20%" MaxLength="10"></asp:TextBox>
                     <img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtCreditAnalystDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />

                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlOfficeVerificationNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeVerificationNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeVerificationNo" runat="server" Text="Office Verification No."></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOfficeVerificationNo" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTelephoneBill" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTelephoneBill" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTelephoneBill" runat="server" Text="Telephone Bill"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTelephoneBill" runat="server"  Width="80%" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            
           
           
           <asp:Panel ID="pnlEmploymentStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblEmploymentStatus" runat="server"  Text="Employment Status" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlEmploymentStatus" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Permanent Employee ( STL )" Value="Permanent Employee ( STL )"></asp:ListItem>
                        <asp:ListItem Text="Permanent Employee ( PIL)" Value="Permanent Employee ( PIL)"></asp:ListItem>
                        <asp:ListItem Text="Temp" Value="Temp"></asp:ListItem>                                                            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlYearsInEmploymentBusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsInEmploymentBusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsInEmploymentBusiness" runat="server" Text="Years in Employment/Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtYearsInEmploymentBusiness" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCmDesign" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCmDesign" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCmDesign" runat="server" Text="Cm Design"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCmDesign" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBasicSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBasicSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBasicSalary" runat="server" Text="Salary Range/Basic Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBasicSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTransportAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTransportAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTransportAllowance" runat="server" Text="Transport Allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTransportAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlHouseRentAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblHouseRentAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblHouseRentAllowance" runat="server" Text="House Rent Allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtHouseRentAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlFixedAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFixedAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFixedAllowance" runat="server" Text="Fixed allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFixedAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTotalFixedSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTotalFixedSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTotalFixedSalary" runat="server" Text="Total Fixed Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTotalFixedSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlAdditionalComments" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAdditionalComments" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAdditionalComments" runat="server" Text="Additional Comments"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAdditionalComments" runat="server" TextMode="multiLine" Width="80%" MaxLength="250" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtAdditionalComments')" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEmploymentConfirmedWith" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentConfirmedWith" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmploymentConfirmedWith" runat="server" Text="Employment confirmed with"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmploymentConfirmedWith" runat="server"  Width="80%" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEmploymentConfirmedWithDesignation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentConfirmedWithDesignation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmploymentConfirmedWithDesignation" runat="server" Text="Employment Confirmed with Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmploymentConfirmedWithDesignation" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfApplicant" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfApplicant" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfApplicant" runat="server" Text="Type of Applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfApplicant" runat="server"  Width="80%" ReadOnly="true" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfLoan" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table64" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfLoan" runat="server" Text="Type of Loan"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfLoan" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="pnlDetailsOfTradeLicense" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDetailsOfTradeLicense" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDetailsOfTradeLicense" runat="server" Text="Details of Trade License"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDetailsOfTradeLicense" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfSalary" runat="server" Text="Type of Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <!--End of Fields For City Bank (Dubai)-->
         
         <%--Start of Fields for Dubai---NIKHIL--%>
         
         <asp:Panel ID="PnlAuthorizedSignatoryName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblauthorizedsignatoryname" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAuthorizedSignatoryName" runat="server" Text="Name of Autorized Signatory :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAuthorizedSignatoryName" runat="server"  Width="80%" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlNeighSecurityCheck" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighSecurityCheck" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighSecurityCheck" runat="server" Text="Neighbour/Security Check :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNeighSecurityCheck" runat="server"  Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlProductTypeDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductTypeDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductTypeDubai" runat="server" Text="Product Type :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlProductTypeDubai" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Cards</asp:ListItem>
                    <asp:ListItem>Smart Loan</asp:ListItem>
                    <asp:ListItem>Auto Loan</asp:ListItem>
                    <asp:ListItem>Mortgage</asp:ListItem>
                    <asp:ListItem>Business Loan</asp:ListItem>
                    <asp:ListItem>Personal Loan</asp:ListItem>            
                </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlLocalityOfficeDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityOfficeDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblLocalityOfficeDubai" runat="server" Text="Office Type :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityOfficeDubai" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Shopping Mall</asp:ListItem>
                    <asp:ListItem>Virtual Office</asp:ListItem>
                    <asp:ListItem>Office in Residence Bldg</asp:ListItem>
                    <asp:ListItem>Warehouse</asp:ListItem>
                    <asp:ListItem>Desk Only</asp:ListItem> 
                    <asp:ListItem>Office In Flat</asp:ListItem>
                    <asp:ListItem>Office in Commerical Bldg</asp:ListItem>
                    <asp:ListItem>Villa</asp:ListItem>
                    <asp:ListItem>Yard/Full Floor</asp:ListItem>
                    <asp:ListItem>Showroom</asp:ListItem> 
                    <asp:ListItem>Residence cum Office</asp:ListItem>
                    <asp:ListItem>Building</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlClientTypeCITI" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblClientTypeCITI" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblClientTypeCITI" runat="server" Text="CITI Client Type :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlClientTypeCITI" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Salaried</asp:ListItem>
                    <asp:ListItem>Business Loan</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlSalaryConfirm" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSalaryConfirm" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSalaryConfirm" runat="server" Text="Salary Confirmation :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSalaryConfirm" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlPersonMetCooperative" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPersonMetCooperative" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonMetCooperative" runat="server" Text="Person Met Co-operative?:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlPersonMetCooperative" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEmpTypeDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmpTypeDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmpTypeDubai" runat="server" Text="Employee Type :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEmpTypeDubai" runat="server"  OnSelectedIndexChanged="ddlEmpTypeDubai_SelectedIndexChanged"   AutoPostBack="true" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Self Employed</asp:ListItem>
                    <asp:ListItem>Salaried</asp:ListItem>
                    </asp:DropDownList> </td>                  
                    
                        <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlemptypesubtype" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Proprietor</asp:ListItem>
                    <asp:ListItem>Partner</asp:ListItem>
                    <asp:ListItem>Director</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCompanyTypeDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyTypeDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCompanyTypeDubai" runat="server" Text="Company Type :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlCompanyTypeDubai" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>Approved</asp:ListItem>
                    <asp:ListItem>Target</asp:ListItem>
                    <asp:ListItem>Payroll</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlSalaryRangeDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table17" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSalaryRangeDubai" runat="server" Text="Salary Range "></asp:Label>
                </td><td style="width:2%">:</td>
                    <td>
                    <asp:Label SkinID="lblSkin" ID="lblminsalary" runat="server"   Text="Min "></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox SkinID="txtSkin"  ID="txtMinSalaryDubai" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                    <asp:Label SkinID="lblSkin" ID="lblmaxsalary" runat="server"  Text="Max "></asp:Label>
                    </td>
                    <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtMaxSalaryDubai" runat="server"  ></asp:TextBox>
                    </td>
                </tr>
               </table>
           </asp:Panel>
          <%--  Emirates NBD Start NIKHIL 27 june 2013--%>
           <asp:Panel ID="pnlSisterOrGroupCompanyDetails" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSisterOrGroupCompanyDetails" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSisterOrGroupCompanyDetails" runat="server" Text="if Sister Concern Company / Group Co. Owenrship details :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSisterOrGroupCompanyDetails" runat="server"  Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlExternalAuditor" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExternalAuditor" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExternalAuditor" runat="server" Text="External Audit done, if Yes Auditor are : "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtExternalAuditor" runat="server"  Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlAnnualRevenueAndProfit" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAnnualRevenueAndProfit" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAnnualRevenueAndProfit" runat="server" Text="Annual Revenue and Annual Profite :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAnnualRevenueAndProfit" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlProfitPercentage" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProfitPercentage" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfitPercentage" runat="server" Text="Profit % (if owner/partner) : "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtProfitPercentage" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlOriginalSeenDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOriginalSeenDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOriginalSeenDubai" runat="server" Text="Original Seen :"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOriginalSeenDubai" runat="server"  AutoPostBack="false" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem>TL</asp:ListItem>
                    <asp:ListItem>T.C</asp:ListItem>
                    <asp:ListItem>POA</asp:ListItem>
                    <asp:ListItem>Labor Card</asp:ListItem>
                    <asp:ListItem>Passport</asp:ListItem>
                    <asp:ListItem>Bills</asp:ListItem> 
                    <asp:ListItem>Import & Export Docs</asp:ListItem>
                    <asp:ListItem>Custom Paper</asp:ListItem>
                    </asp:DropDownList> </td>
                </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="pnlDocsCollectedDubai" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDocsCollectedDubai" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDocsCollectedDubai" runat="server" Text="Documents Colected: "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDocsCollectedDubai" runat="server"  Width="80%" TextMode="MultiLine"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
        <%-- NBD End --%>
         
         <%--End of Fields for Dubai---NIKHIL--%>
            
         
         <!--START Below New Fields for HSBC Bank-->
         <asp:Panel ID="pnlOfficeCumResidence" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeCumResidence" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeCumResidence" runat="server" Text="Office Cum Residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeCumResidence" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOfficeCumResidence" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherOfficeCumResidence" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlPhotographOfLocation" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblPhotographOfLocation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPhotographOfLocation" runat="server" Text="Photograph of Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPhotographOfLocation" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherPhotographOfLocation" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherPhotographOfLocation" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlEmirate" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmirate" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmirate" runat="server" Text="Emirate"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmirate" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppReportToName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppReportToName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppReportToName" runat="server" Text="Applicant Report to Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppReportToName" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppReportToDesignation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppReportToDesignation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppReportToDesignation" runat="server" Text="Applicant Report to Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppReportToDesignation" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppHomeCountryPhoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppHomeCountryPhoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppHomeCountryPhoneNo" runat="server" Text="Applicant Home Country Phone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppHomeCountryPhoneNo" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlIsCompanyPartOfGroupCompanies" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsCompanyPartOfGroupCompanies" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsCompanyPartOfGroupCompanies" runat="server" Text="Is the company part of Group Companies"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtIsCompanyPartOfGroupCompanies" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlMainBusiOrCompanyActivity" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMainBusiOrCompanyActivity" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMainBusiOrCompanyActivity" runat="server" Text="Main business or Company Activity"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtMainBusiOrCompanyActivity" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameOfOwner" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfOwner" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOfOwner" runat="server" Text="Name of Owner / TPC2 name confirm"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNameOfOwner" runat="server"  Width="80%" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranchesWareHouseCompanyHaveInUAE" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranchesWareHouseCompanyHaveInUAE" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranchesWareHouseCompanyHaveInUAE" runat="server" Text="How many more Branches/Offices/Ware house/associated concerns does the company have in UAE"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranchesWareHouseCompanyHaveInUAE" runat="server"  Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
          
     <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="DDLNatureOfBusiness" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>  
                    <asp:ListItem>Trading</asp:ListItem>  
                    <asp:ListItem>Service</asp:ListItem>
                    <asp:ListItem>Trade shopkeeper</asp:ListItem>
                    <asp:ListItem>Broker</asp:ListItem>
                    <asp:ListItem>STD PCO</asp:ListItem>
                    <asp:ListItem>Software</asp:ListItem>
                    <asp:ListItem>BPO</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                <asp:DropDownList SkinID="ddlSkin" ID="DDLServiceProvider" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Commission Agent</asp:ListItem>
                    <asp:ListItem>Broker</asp:ListItem>  
                    <asp:ListItem>Tutor/Personal Care</asp:ListItem>  
                    <asp:ListItem>LIC Agent</asp:ListItem>  
                    <asp:ListItem>STD-PCO Booth</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
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
      
      <%--added by kamal matekar for SCB Bank--%>
     <asp:Panel ID="pnlVisitingCard" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblVisitingCard" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisitingCard" runat="server" Text="Visiting card collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitingCard" runat="server"  AutoPostBack="false" >
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
          
         <asp:Panel ID="pnlBusinessOwnership" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessOwnership" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessOwnership" runat="server" Text="Business Ownership"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessOwnership" runat="server"  AutoPostBack="false" >
                    <asp:ListItem>Self owned</asp:ListItem>
                    <asp:ListItem>Family owned</asp:ListItem>     
                    <asp:ListItem>Partnership</asp:ListItem>       
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
          
          <asp:Panel ID="pnlSeparateOfficeArea" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label5" runat="server" Text="If residence cum office, then separate office area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateOfficeArea" runat="server"  AutoPostBack="false" >
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
          
           
    <asp:Panel ID="pnlCommentsOnBusinessActivitiesSeenStock" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table4" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblCommentOnBusinessActivity" runat="server" Text="Comments on business activities seen,stock and machinery"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtCommentOnBusinessActivity" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
          
          <%---ended by kamal matekar for scb--%>

      
      
      <!-------added by kamal matekar--------->
      <!------Required for femu-------------------->
      
      
      <%--SCB Start--%>
      <%-- Rupesh--%>
           
           <asp:Panel ID="pnlNeighbourFeedback" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table16" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourFeedback" runat="server" Text="Any Other Feedback"></asp:Label>
                </td><td style="width:2%">:</td>
          
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbourFeedback" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                
                </tr>
               </table>
            </asp:Panel>
            
            
            <asp:Panel ID="PnlTotalYears" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label12" runat="server" Text="If Salaried-Years In Business"></asp:Label>
                </td><td style="width:2%">:</td>
          
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtTotalYears" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                
                </tr>
               </table>
            </asp:Panel>
            
           
            <asp:Panel ID="PnlVerification" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="LblVerification" runat="server" Text="Verification"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="DdlVerification" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Recommended</asp:ListItem>
                        <asp:ListItem>Not Recommended</asp:ListItem>  
                        <asp:ListItem>Referred</asp:ListItem> 
                        <asp:ListItem>Verification Unsuccessful</asp:ListItem>           
                    </asp:DropDownList>
                </td>
                </tr>
                       <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblreason" runat="server" Text="Reasons for not recommended/referred"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin" ID="txtreasonrecommended" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
              <%-- Rupesh--%>
           
            <asp:Panel ID="PnlOfficersDecision" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table6" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficerDecision" runat="server" Text="Officers Decision"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficersDecision" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Declined</asp:ListItem>  
                        <asp:ListItem>Hold To Discuss</asp:ListItem>           
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <%-- Rupesh--%>
           
            <asp:Panel ID="PnlCityLimitYN" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCityLimitYN" runat="server" Text="CityLimitYN"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="DdlCityLimitYN" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>                           
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlOfficeOutsidethenarea" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table8" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeOutsidethenarea" runat="server" Text="OfficeOutsidethenarea"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOfficeOutsidethenarea" Width="80%" runat="server" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
       <%--    Rupesh--%>
     <%-- SCB End--%>

       <asp:Panel ID="pnlAddressApporch" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressApporch" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddressApporch" runat="server" Text="Address Apporch"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAddressApporch" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
           
      <asp:Panel ID="pnlIfAddressNotFound" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfAddressNotFound" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfAddressNotFound" runat="server" Text="If address not found"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtIfAddressNotFound" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
         <!--------------------This field should add in the CPV_CC_VERI_DESCRIPTION(NAME_SOCIETY_BOARD)------------------>
      <asp:Panel ID="pnlNameDisplayedInNameBoardOfTheSociety" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameDisplayedInNameBoardOfTheSociety" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameDisplayedInNameBoardOfTheSociety" runat="server" Text="Name displayed in name board of the society"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNameDisplayedInNameBoardOfTheSociety" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
      
      
      <asp:Panel ID="pnlDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer" runat="server"  Text="Do Neighbour/Neighboring shops or offices know the customer" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
          <!--------------------This field should add in the CPV_CC_VERI_DESCRIPTION1(NEIGHBOUR_REFERENCE)------------------>
      <asp:Panel ID="pnlNeighbourReference" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourReference" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblNeighbourReference" runat="server"  Text="Neighbour reference" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlNeighbourReference" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
                        <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlDoesTheApplicantWorkHere" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDoesTheApplicantWorkHere" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblDoesTheApplicantWorkHere" runat="server"  Text="Does the applicant Work here" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlDoesTheApplicantWorkHere" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
      
      <asp:Panel ID="pnlBriefJobResponsibilities" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBriefJobResponsibilities" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBriefJobResponsibilities" runat="server" Text="Brief Job Responsibilities"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtBriefJobResponsibilities" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
           
        <asp:Panel ID="pnlReasonForApplicantNotMet" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForApplicantNotMet" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForApplicantNotMet" runat="server" Text="Reason for applicant not met"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonForApplicantNotMet" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
               
            <asp:Panel ID="pnlShiftOfWork" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblShiftOfWork" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblShiftOfWork" runat="server"  Text="Shift of work" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlShiftOfWork" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Day" Value="Day"></asp:ListItem>
                        <asp:ListItem Text="Night" Value="Night"></asp:ListItem>
                        <asp:ListItem Text="General" Value="General"></asp:ListItem>
                        <asp:ListItem Text="OnField" Value="OnField"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
        
          <asp:Panel ID="pnlEmail" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmail" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtEmail" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfOrganization" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfOrganization" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfOrganization" runat="server" Text="Type Of Organization"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfOrganization" runat="server" Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
         
         <asp:Panel ID="pnlIfOtherSpecify" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherSpecify" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherSpecify" runat="server" Text="If Other specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherSpecify" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
      
      <asp:Panel ID="pnlTypeOfOccupation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfOccupation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfOccupation" runat="server" Text="Type of occupation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfOccupation" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="pnlHeadOfficebranch" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblHeadOfficebranch" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblHeadOfficebranch" runat="server" Text="Head office / branch"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtHeadOfficebranch" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
           
           
     <%--Mashrque Bank cod start for femu--%>
           
            <asp:Panel ID="pnlSponsor1Designation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1Designation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1Designation" runat="server" Text="Sponsor 1 Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1Designation" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
          <asp:Panel ID="pnlSponsor2Designation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2Designation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2Designation" runat="server" Text="Sponsor 2 Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2Designation" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>        
             
          <asp:Panel ID="pnlFavouritePlace" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFavouritePlace" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFavouritePlace" runat="server" Text="Favourite Place"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFavouritePlace" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>     
           
         <asp:Panel ID="pnlReferenceNoInUAE" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReferenceNoInUAE" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReferenceNoInUAE" runat="server" Text="Reference No In UAE"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtReferenceNoInUAE" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>     
           
          <asp:Panel ID="pnlAnyOtherBankCcFinancialfacility" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOtherBankCcFinancialfacility" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAnyOtherBankCcFinancialfacility" runat="server" Text="Any Other Bank Cc/Financial facility"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAnyOtherBankCcFinancialfacility" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        
          <asp:Panel ID="pnlVehicalOwned" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVehicalOwned" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVehicalOwned" runat="server" Text="Vehical Owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtVehicalOwned" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlVehicalFinanced" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVehicalFinanced" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVehicalFinanced" runat="server" Text="Vehical Financed"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtVehicalFinanced" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
   
           <asp:Panel ID="pnlBreakUpOfNumberOfEmployeesWithDesignations" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBreakUpOfNumberOfEmployeesWithDesignations" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBreakUpOfNumberOfEmployeesWithDesignations" runat="server" Text="Breakup of number of employees with designations"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBreakUpOfNumberOfEmployeesWithDesignations" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlIstheOfficePremisesSharedWithAnyOtherOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIstheOfficePremisesSharedWithAnyOtherOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIstheOfficePremisesSharedWithAnyOtherOffice" runat="server" Text="Is the office premises shared with any other office?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin" ID="txtIstheOfficePremisesSharedWithAnyOtherOffice" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
 <%--Mashrque Bank cod End--%>
 <%--Added by Manoj for Axis Change address --%>
          <asp:Panel ID="PnlApplicantfound" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantfound" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblApplicantfound" runat="server"  Text="Is the Applicant found in your Negative Customer Database ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlApplicantfound" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlApplicantdefault" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table18" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label14" runat="server" Text="Applicant defaulted with"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtApplicantdefaulted" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="PnlProductdefault" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductdefault" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label15" runat="server" Text="Product Defaulted on"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtProductdefault" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlProduct" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProduct" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductName" runat="server" Text="Product"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtProductName" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
          <asp:Panel ID="Pnlamountofdefault" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabamountofdefault" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Labamountofdefault" runat="server" Text="Amount of Default"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtamountofdefault" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlIscompanynegative" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="TabIscompanynegative" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labIscompanynegative" runat="server"  Text="Is the company negative as defined by the Bank" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIscompanynegative" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlIsdesignationnagative" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="TabIsdesignationnagative" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labIsdesignationnagative" runat="server"  Text="Is the designation negative as provided by the Bank" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsdesignationnagative" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Pnlfloorseparateresidence" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Tabfloorseparateresidence" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblfloorseparateresidence" runat="server"  Text="Is Office located in a floor separate to residence ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlfloorseparateresidence" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
          <asp:Panel ID="Pnlroomseparateresidence" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabroomseparateresidence" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labroomseparateresidence" runat="server"  Text="Is Office located in a room separate to residence ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlroomseparateresidence" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Pnlentrancetoresidence" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabentrancetoresidence" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labentrancetoresidence" runat="server"  Text="Is entrance to office different from entrance to residence ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlentrancetoresidence" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlAddressvisted" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabAddressvisted" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="LabAddressvisted" runat="server"  Text="Address visited" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlAddressvisted" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="Registered(Mailing Address)" Value="Registered(Mailing Address)"></asp:ListItem>
                        <asp:ListItem Text="Physical (Site visit Address)" Value="Physical (Site visit Address)"></asp:ListItem>
                        <asp:ListItem Text="OTHER" Value="OTHER"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="LabOtheraddress" runat="server" Text="If OTHER address, please specify the address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOtheraddress" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlOtheraddressobtained" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabOtheraddressobtained" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labOtheraddressobtained" runat="server" Text="How was this OTHER address obtained? "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOtheraddressobtained" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
       <asp:Panel ID="Pnldateofdefault" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table19" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label13" runat="server"  Text="Date of Visit"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin" ID="txtdateofdefault" runat="server"></asp:TextBox>
             <img id="img4"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtdateofdefault.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            <asp:Label SkinID="lblSkin" ID="Label16" runat="server"  Text="Time of Visit"></asp:Label>
           <asp:TextBox SkinID="txtSkin" ID="txtTimeOfdefault" runat="server"></asp:TextBox> 
           </td>
           </tr>
           </table>
        </asp:Panel>
<%--Ended by Manoj for Axis Change address --%>
<%--Added by Manoj for HDFC Merchant --%>
       <asp:Panel ID="Pnltradingname" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabTradingname" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labtradingname" runat="server" Text="Trading Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txttradingname" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="PnlNoofyearrelationship" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNoOfyearRelationshop" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNoofyearrelationship" runat="server" Text="No Of the year Relationship"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoofyearrelationship" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="PnlNoOfEDCinshop" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNoOfEDCinshop" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNoofEDCinshop" runat="server" Text="No Of EDC in the shop"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEDCinshop" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="PnlNoofpersonhandlingEDCmachine" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNoOfpersonhandlingEDCMachine" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNoOfpersonhandlingEDCmachine" runat="server" Text="No Of person handling EDC Machine"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfpersonhandlingEDCmachine" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="PnlMCCType" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabMCCType" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labMCCType" runat="server" Text="MCC Type"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtMCCType" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="Pnlcarddetalis" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCarddetalis" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCarddetalis" runat="server" Text="Card detalis"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCardetalis" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
         
         <asp:Panel ID="PnlcardLimit" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table20" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labcardlimit" runat="server" Text="Card Limit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtcardlimit" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>
            
         <asp:Panel ID="PnlMarketinformationchangebackhistroy" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabMarketinformationchangebackhistroy" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label17" runat="server" Text="Market information change back histroy"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtMarketinformationchangebackhistroy" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
         </asp:Panel>      
          
        <asp:Panel ID="PnlKnowledgelevalofstaff" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabKnowledgelevalofstaff" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labKnowledgelevalofstaff" runat="server"  Text="Knowledge leval of staff in card acceptance" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlKnowledgelevalofstaff" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Poor</asp:ListItem>
                        <asp:ListItem>Average</asp:ListItem>
                        <asp:ListItem>Good</asp:ListItem>
                        <asp:ListItem>Excellent</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>  
                  
         <asp:Panel ID="PnlPartOfChain" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabpartOfchain" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labpartofchain" runat="server"  Text="Part Of Chain" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlpartofchain" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>          
           
         <asp:Panel ID="PnlAcceptingcard" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabAcceptingcard" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labAcceptingcard" runat="server"  Text="Already Accepting Card" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlAcceptingcard" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>    
           
           <asp:Panel ID="PnlTypeOfcard" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabtypeofcard" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labTypeOfcard" runat="server"  Text="Type Of Card" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlTypeOfcard" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Master cards</asp:ListItem>
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Diners</asp:ListItem>
                        <asp:ListItem>Amex</asp:ListItem>
                        <asp:ListItem>JCB</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
       
            
           <asp:Panel ID="PnlHDFCbankcreditcard" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabHDFCbankcreditcard" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labHDFCbankcreditcard" runat="server"  Text="Does the properitors(s) Of the establishment hold a HDFC Bank credit card" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlHDFCBankcreditcard" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
             
    <%-- Ended by MAnoj --%>     
<%--Ended by Manoj for HDFC Merchant--%>
<%--start nikhil 04 sept 2013 SBI Change address--%>

<asp:Panel ID="pnlApplicantConfirmation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantConfirmation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblApplicantConfirmation" runat="server"  Text="ID/App Name Confirm?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlApplicantConfirmation" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>CONFIRMED</asp:ListItem>
                        <asp:ListItem>NOT CONFIRMED/REFUSED</asp:ListItem>
                        <asp:ListItem>NO SUCH PERSON</asp:ListItem>
                        <asp:ListItem>ENTRY RESTRICTED</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlEmploymentConf" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentConf" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblEmploymentConf" runat="server"  Text="Employment Confirmed?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlEmploymentConf" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                         <asp:ListItem>CONFIRMED</asp:ListItem>
                          <asp:ListItem>NOT CONFIRMED/REFUSED</asp:ListItem>
                           <asp:ListItem>TRANSFERRED</asp:ListItem>
                            <asp:ListItem>LEFT JOB</asp:ListItem>
                             <asp:ListItem>RETIRED</asp:ListItem>
                              <asp:ListItem>OFFICE SHIFTED</asp:ListItem>
                               <asp:ListItem>DEPUTED/ CLINT SITE</asp:ListItem>
                                <asp:ListItem>OWNER/ PROPRIETOR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSBItpc1" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSBItpc1" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSBItpc1" runat="server"  Text="TPC 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlSBItpc1" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>CONFIRMED</asp:ListItem>
                    <asp:ListItem>NOT CONFIRMED/REFUSED</asp:ListItem> 
                    <asp:ListItem>NOT POSSIBLE</asp:ListItem>
                    <asp:ListItem>NO SUCH PERSON</asp:ListItem>
                    <asp:ListItem>RETIRED</asp:ListItem>
                    <asp:ListItem>WORKING ELSEWHERE</asp:ListItem>
                    <asp:ListItem>RARELY VISITS AT GIVEN ADDRESS</asp:ListItem>
                    <asp:ListItem>DEPUTED/ CLIENT SITE</asp:ListItem>
                    <asp:ListItem>LEFT JOB/ TRANSFER</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlSBItpc2" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSBItpc2" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSBItpc2" runat="server"  Text="TPC 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlSBItpc2" runat="server"   AutoPostBack="false">
                  <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>CONFIRMED</asp:ListItem>
                    <asp:ListItem>NOT CONFIRMED/REFUSED</asp:ListItem> 
                    <asp:ListItem>NOT POSSIBLE</asp:ListItem>
                    <asp:ListItem>NO SUCH PERSON</asp:ListItem>
                    <asp:ListItem>RETIRED</asp:ListItem>
                    <asp:ListItem>WORKING ELSEWHERE</asp:ListItem>
                    <asp:ListItem>RARELY VISITS AT GIVEN ADDRESS</asp:ListItem>
                    <asp:ListItem>DEPUTED/ CLIENT SITE</asp:ListItem>
                    <asp:ListItem>LEFT JOB/ TRANSFER</asp:ListItem>       
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel> 
<%--end nikhil 04 sept 2013 SBI Change address--%>
<%--Added by manoj for First gulf bank--%>
          <asp:Panel ID="PnlBuildingstatus" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabBuildingstatus" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBuildingStatus" runat="server" Text="Building Status"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBuildingStatus" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
                
            <asp:Panel ID="PnlLegalstructureofbusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabLegalstructureofbusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labLegalstructureofbusiness" runat="server" Text="Legal Structure of business:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtLegalstructureofbusiness" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>    
           
           <asp:Panel ID="pnlRelatedpartyinfo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabRelatedpartyinfo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labRelatedpartyinfo" runat="server" Text="Related party info (Do partners hold share in other Co’s)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtRelatedpartyinfo" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="PnlNameofpersonwhoactivelymanages" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNameofpersonwhoactivelymanages" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNameofpersonwhoactivelymanages" runat="server" Text="Name of person who actively manages the business & % share"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNameofpersonwhoactivelymanages" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            
           <asp:Panel ID="PnlCurrentactivepartnerinvolvement" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCurrentactivepartnerinvolvement" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCurrentactivepartnerinvolvement" runat="server" Text="Current active partner’s involvement in the business since when?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCurrentactivepartnerinvolvement" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
          <asp:Panel ID="PnlDateofbusincorporation" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tabDateofbusincorporation" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="labDateofbusincorporation" runat="server"  Text="Date of business incorporation"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
              <asp:TextBox SkinID="txtSkin" ID="txtDateofbusincorporation" runat="server"></asp:TextBox>
              <img id="img5"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateofbusincorporation.ClientID%>, 'dd/mm/yyyy', 0, 0);" />

           </td>
           </tr>
           </table>
         </asp:Panel>
          
          <asp:Panel ID="PnlLoanamountapplied" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabLoanamountapplied" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labLoanamountapplied" runat="server" Text="Loan Amount Applied "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtLoanamountapplied" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlLoantenor" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabLoantenor" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labLoantenor" runat="server" Text="Loan Tenor"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtLoantenor" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEnduseoffunds" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabEnduseoffunds" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labEnduseoffunds" runat="server" Text="End use of Funds"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEnduseoffunds" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="PnlINTERVIEWERCONCERNS" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabINTERVIEWERCONCERNS" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labINTERVIEWERCONCERNS" runat="server" Text="INTERVIEWER'S CONCERNS "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtINTERVIEWERCONCERNS" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="PnlINTERVIEWERMITIGANTS" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabINTERVIEWERMITIGANTS" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labINTERVIEWERMITIGANTS" runat="server" Text="INTERVIEWER'S MITIGANTS "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtINTERVIEWERMITIGANTS" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlBusinessrefdetails" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabBusinessrefdetails" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBusinessrefdetails" runat="server" Text="Business Reference Details" Font-Bold="true"></asp:Label>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            
           <asp:Panel ID="PnlBusinesssupplier" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabBusinesssupplier" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBusinesssupplier" runat="server" Text="Reference 1:Supplier(Name of Key Person):"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBusinesssupplier" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlSuppliercompanyname" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabSuppliercompanyname" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labSuppliercompanyname" runat="server" Text="Company Name:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSuppliercompanyname" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlSuplierlandline" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabSuplierlandline" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labSuplierlandline" runat="server" Text="Land line / Mobile Number:"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSuplierlandline" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Pnlsupplierremarks" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabsupplierremarks" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labsupplierremarks" runat="server" Text="Remarks "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtsupplierremarks" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlBusinesscustomername" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabBusinesscustomername" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBusinesscustomername" runat="server" Text="Customer (Name of Key Person)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBusinesscustomername" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlCutomercompanyname" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCutomercompanyname" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCutomercompanyname" runat="server" Text="Company Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCutomercompanyname" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="PnlCustomermobile" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCustomermobile" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCustomermobile" runat="server" Text="Land line / Mobile Number"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCustomermobile" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
          <asp:Panel ID="PnlCustomerRemarks" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCustomerRemark" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCustomerRemark" runat="server" Text="Remarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCustomerRemark" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlPurchases" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabPurchases" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labPurchases" runat="server" Text="Purchases" Font-Bold ="true"></asp:Label>
                </td><td style="width:2%">:</td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlPurchasesaveragepurchaseterms" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabPurchasesaveragepurchaseterms" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labPurchasesaveragepurchaseterms" runat="server" Text="Average purchase terms"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtPurchasesaveragepurchaseterms" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            
           <asp:Panel ID="PnlPurchaseLocal" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabPurchaseLocal" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labPurchaseLocal" runat="server" Text="Local (percentage of total)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtPurchaseLocal" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlPurchaseImport" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabPurchaseImport" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labPurchaseImport" runat="server" Text="Import  (percentage of total)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtPurchaseImport" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlCountriesimportedfrom" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCountriesimportedfrom" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCountriesimportedfrom" runat="server" Text="Countries imported from"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCountriesimportedfrom" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlTotalNoOfsupplier" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabTotalNoOfsupplier" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labTotalNoOfsupplier" runat="server" Text="Total No. of suppliers"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTotalNoOfsupplier" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             
          <asp:Panel ID="PnlNoOfactivesuppliers" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNoOfactivesuppliers" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNoOfactivesuppliers" runat="server" Text="No. of Active (regular) suppliers"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfactivesuppliers" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlNamesofkeysuppliers" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNamesofkeysuppliers" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNamesofkeysuppliers" runat="server" Text="Names of key suppliers"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNamesofkeysuppliers" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Pnlsales" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabsales" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labsales" runat="server" Text="Sales"></asp:Label>
                </td><td style="width:2%">:</td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="PnlAveragesalesterms" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabAveragesalesterms" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labAveragesalesterms" runat="server" Text="Average Sales terms"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAveragesalesterms" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="PnlLocalTransport" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabLocalTransport" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labLocalTransport" runat="server" Text="Local(percentage of total)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtLocalTransport" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="PnlOtherCountriesPercentage" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabOtherCountriesPercentage" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labOtherCountriesPercentage" runat="server" Text="Export(percentage of total)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOtherCountriesPercentage" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlOtherCountries" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabOthercountries" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label18" runat="server" Text="Key Export Countries"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOtherCountries" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>      
             
           <asp:Panel ID="PnlTotalNoofcustomers" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabTotalNoofcustomers" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labTotalNoofcustomers" runat="server" Text="Total No. of customers"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTotalNoofcustomers" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
           <asp:Panel ID="PnlNoofActivecustomers" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNoofActivecustomers" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNoofActivecustomers" runat="server" Text="No. of Active (regular) customers"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoofActivecustomers" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>    
           
          <asp:Panel ID="PnlNamesofkeycustomers" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabNamesofkeycustomers" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labNamesofkeycustomers" runat="server" Text="Names of key customers (minimum five):"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNamesofkeycustomers" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             
           <asp:Panel ID="PnlCreditRemarksPostFieldVisit" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabCreditRemarksPostFieldVisit" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCreditRemarksPostFieldVisit" runat="server" Text="Credit Remarks Post Field Visit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditRemarksPostFieldVisit" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
 
<!--Added by Manoj for FGB_SME-->
      <asp:Panel ID="PnlSellingterms" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabSellingterms" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labSellingterms" runat="server"  Text="Selling terms" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td class="TDWidth">
                    <asp:Label ID="labCash" runat="server"  Text="% Cash" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtcash" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCredit" runat="server" Text="Credit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCredit" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labCreditperiod" runat="server" Text="Credit period"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditperiod" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
       </asp:Panel>

       <asp:Panel ID="PnlBuyingterms" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table21" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labBuying" runat="server"  Text="Buying terms" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td class="TDWidth">
                    <asp:Label ID="labBuyingcash" runat="server"  Text="% Cash" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBuyingcash" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBuyingCredit" runat="server" Text="Credit"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBuyingCredit" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labBuyCreditperiod" runat="server" Text="Credit period"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBuyCreditperiod" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
       </asp:Panel>

      <asp:panel ID="Pnlfinancedata" runat="server"  width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="Table22" style="width:100%" runat="server">
              <tr>
                 <th>
                    <asp:Label ID="labdata" runat="server" Text="D.FINANCIAL DATA" SkinID="lblSkin"></asp:Label>
                 </th>
                 <th class="TDWidth" colspan="3" style="height: 14px">
                    <asp:Label ID="labAmt" runat="server" Text="(Amt in AED 000's)" SkinID="lblSkin"></asp:Label>
                 </th>
               </tr> 
               <tr>
                 <td class="TDWidth">
                     <asp:Label ID="labKeyindicators" runat="server" Text="Key indicators" SkinID="lblSkin"></asp:Label>
                 </td>  
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtKeyindicators1" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtKeyindicators2" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtKeyindicators3" runat="server"  Width="100"></asp:TextBox>
                 </td>
               </tr>
               <tr>
                 <td class="TDWidth">
                     <asp:Label ID="labAnnualTurnover" runat="server" Text="Annual Turnover" SkinID="lblSkin"></asp:Label>
                 </td>  
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtAnnualTurnover1" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtAnnualTurnover2" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtAnnualTurnover3" runat="server"  Width="100"></asp:TextBox>
                 </td>
               </tr>  
               <tr>
                 <td class="TDWidth">
                     <asp:Label ID="labProfitMargin" runat="server" Text="Profit margin (%)" SkinID="lblSkin"></asp:Label>
                 </td>  
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtProfitMargin1" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtProfitMargin2" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtProfitMargin3" runat="server"  Width="100"></asp:TextBox>
                 </td>
               </tr>  
               <tr>
                 <td class="TDWidth">
                     <asp:Label ID="labCapitalinvested" runat="server" Text="Capital invested" SkinID="lblSkin"></asp:Label>
                 </td>  
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtCapitalInvest1" runat="server"  Width="100"></asp:TextBox>
                 </td>
                 <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtCapitalInvest2" runat="server"  Width="100"></asp:TextBox>
                 </td>
                  <td class="TDWidth">
                     <asp:TextBox SkinID="txtSkin" ID="txtCapitalInvest3" runat="server"  Width="100"></asp:TextBox>
                 </td>
               </tr>    
           </table>
     </asp:panel>     
    
      <asp:Panel ID="PnlDetalisOfBankingFacilities" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table23" style="width:100%" runat="server">
                <tr>
                   <th align="center">
                        <asp:Label ID="labDetalisOfBankingFacilities" runat="server" Text="DETAILS OF BANKING FACILITIES" SkinID="lblSkin"></asp:Label>
                   </th>
                </tr>
                <tr>
                   <td class="TDWidth">
                        <asp:Label ID="labFacilitytype" runat="server" Text="Facility Type" Width="100"> </asp:Label>
                   </td>
                   <td class="TDWidth">
                        <asp:Label ID="labBankname" runat="server" Text="Bank Name" Width="100"> </asp:Label>
                   </td>
                   <td class="TDWidth">
                        <asp:Label ID="labFacilityamount" runat="server" Text="Facility Amount" Width="100"> </asp:Label>
                   </td>
                   <td class="TDWidth">
                        <asp:Label ID="labSecurity" runat="server" Text="Security" Width="100"> </asp:Label>
                   </td>
                   <td class="TDWidth">
                        <asp:Label ID="labEMI" runat="server" Text="EMI" Width="100"> </asp:Label>
                   </td>
                </tr>
                <tr>
                   <td class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtFacilityType" runat="server"  Width="230" TextMode="MultiLine"></asp:TextBox>
                   </td>
                   <td class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtbankName" runat="server"  Width="230" TextMode="MultiLine"></asp:TextBox>
                   </td>
                   <td class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtFacilityamount" runat="server"  Width="230" TextMode="MultiLine"></asp:TextBox>
                   </td>
                   <td class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtSecurity" runat="server"  Width="230" TextMode="MultiLine"></asp:TextBox>
                   </td>
                   <td class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtEMI" runat="server"  Width="230" TextMode="MultiLine"></asp:TextBox>
                   </td>                   
                </tr>
               </table>
    </asp:Panel>  
    
    
    
     <asp:Panel ID="PnlQueries" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="TabQueries" style="width:100%" runat="server">
                <tr>
                   <td align="center">
                        <asp:Label ID="Label31" runat="server" Text="K.CAM QUERIES (IF ANY) & CLARIFICATIONS" SkinID="lblSkin"></asp:Label>
                   </td>
                </tr>
                <tr>
                   <th class="TDWidth">
                        <asp:Label ID="labQueries" runat="server" Text="Queries" Width="50%"> </asp:Label>
                   </th>
                   <th class="TDWidth">
                        <asp:Label ID="labClarification" runat="server" Text="Clarifications" Width="50%" > </asp:Label>
                   </th>
                </tr>
                <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                          <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>
               <tr>    
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries1" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification1" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr> 
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries2" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification2" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>   
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries3" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                    <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification3" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>  
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries4" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                    <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification4" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr> 
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries5" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification5" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries6" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                    <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification6" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>
                <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries7" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification7" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
               </tr>
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries8" runat="server"  Width="500" TextMode="MultiLine" ></asp:TextBox>
                   </th>
                    <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification8" runat="server"  Width="500" TextMode="MultiLine"></asp:TextBox>
                   </th>
               </tr>  
               <tr>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtQueries9" runat="server"  Width="500" TextMode="MultiLine"></asp:TextBox>
                   </th>
                   <th class="TDWidth">
                        <asp:TextBox SkinID="txtSkin" ID="txtClarification9" runat="server"  Width="500" TextMode="MultiLine"></asp:TextBox>
                   </th>
               </tr>  
         </table>
    </asp:Panel>                           
<%--Ended by manoj for First gulf bank--%>  
<%--started by abhijeet for  Axis bank dubai--%>  

 <asp:Panel ID="Pnlfradulentdocument" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table24" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="Label19" runat="server"  Text="Fradulent Doccument" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                </tr>
                <tr>
                 <td class="TDWidth">
                    <asp:Label ID="lbldoc1" runat="server"  Text="Doccument name1" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtdocname1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbldoc2" runat="server" Text="Doccument name2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtdocname2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbldoc3" runat="server" Text="Doccument name3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtdocname3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
       </asp:Panel>
       
       
         <asp:Panel ID="PnlFraudulentProfile" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table25" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblfraudulentprofile" runat="server"  Text="Fradulent profile" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                </tr>
                <tr>
                 <td class="TDWidth">
                    <asp:Label ID="lblobservation1" runat="server"  Text="Observation1" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtobs1" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblobservation2" runat="server" Text="Observation2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtobs2" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblobservation3" runat="server" Text="Observation3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtobs3" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
       </asp:Panel>
       
       
          <asp:Panel ID="Pnlotherobservation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table26" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblotherobservation" runat="server"  Text="Other Observation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                </tr>
<tr>
                 <td class="TDWidth">
                    <asp:Label ID="lblsetupcompany" runat="server"  Text="Set-Up Company" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                
                 <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtsetup" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblnegmarketinfo" runat="server" Text="Negative Market Info"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtnegmarinfo" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblantisoc" runat="server" Text="Anti-Social / PEP"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtantisoc" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
       </asp:Panel>
       
          <asp:Panel ID="PnlRacname" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table27" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblracname" runat="server" Text="RAC Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtracname" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="PnlFileNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table28" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblfileno" runat="server" Text="FileNo"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtfileno" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="PnlDSACode" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table29" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbldsacode" runat="server" Text="DSA Code"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtdsacode" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="Pnlsalesmanagercode" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table30" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblsalesmanagrcode" runat="server" Text="Sales Manager Code"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtsalesmanagercode" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="Pnlfculocation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table31" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblfculocation" runat="server" Text="FCU Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtfculocation" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="Pnlproduct1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table32" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblproduct" runat="server" Text="Office Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtproduct" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="Pnldsecode" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table33" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbldsecode" runat="server" Text="DSE Code"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtdsecode" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="Pnlpickupprofile" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table34" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblpickupdoc" runat="server" Text="Pick-Up Profile/Doccument"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtpickupprofile" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
             <%--   
           --Added by abhijeet for ENBD----%>
            <asp:Panel ID="Pnlregistrddetails1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table39" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label20" runat="server" Text="Registered Details 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
             <asp:Panel ID="Pnlregistrddetails2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table40" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label21" runat="server" Text="Registered Details 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="Pnlregistrddetails3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table41" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label22" runat="server" Text="Registered Details 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="Pnlregistrddetails4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table42" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label23" runat="server" Text="Registered Details 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             
            <asp:Panel ID="Pnlregistrddetails5" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table43" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label24" runat="server" Text="Registered Details 5"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails5" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="Pnlregistrddetails6" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table44" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label25" runat="server" Text="Registered Details 6"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtregdetails6" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              
             <asp:Panel ID="Pnlphysicaldetails1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table45" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label26" runat="server" Text="Physical Details 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="Pnlphysicaldetails2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table46" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label27" runat="server" Text="Physical Details 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
                <asp:Panel ID="Pnlphysicaldetails3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table47" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label28" runat="server" Text="Physical Details 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                <asp:Panel ID="Pnlphysicaldetails4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table48" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label29" runat="server" Text="Physical Details 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
             <asp:Panel ID="Pnlphysicaldetails5" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table49" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label30" runat="server" Text="Physical Details 5"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails5" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="Pnlphysicaldetails6" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table50" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label32" runat="server" Text="Physical Details 6"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphysicaldetails6" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                <asp:Panel ID="PnlInternationaldetails1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table51" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label33" runat="server" Text="International Details 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlInternationaldetails2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table52" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label34" runat="server" Text="International Details 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlInternationaldetails3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table53" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label35" runat="server" Text="International Details 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="PnlInternationaldetails4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table54" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label36" runat="server" Text="International Details 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="PnlInternationaldetails5" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table55" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label37" runat="server" Text="International Details 5"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails5" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="PnlInternationaldetails6" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table56" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label38" runat="server" Text="International Details 6"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtinternationaldetails6" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            
             <asp:Panel ID="PnlregisteredBusinessoffice1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table57" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label39" runat="server" Text="Registered Business Office 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtregisteredBusinessoffice1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="PnlregisteredBusinessoffice2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table58" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label40" runat="server" Text="Registered Business Office 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtregisteredBusinessoffice2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
             
             <asp:Panel ID="PnlregisteredBusinessoffice3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table59" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label41" runat="server" Text="Registered Business Office 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtregisteredBusinessoffice3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlregisteredBusinessoffice4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table60" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label42" runat="server" Text="Registered Business Office 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtregisteredBusinessoffice4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            
             <asp:Panel ID="PnlothersBussinessdetails1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table61" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label43" runat="server" Text="Other Business Office 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtothersBussinessdetails1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlothersBussinessdetails2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table62" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label44" runat="server" Text="Other Business Office 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtothersBussinessdetails2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlothersBussinessdetails3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table63" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label45" runat="server" Text="Other Business Office 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtothersBussinessdetails3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlothersBussinessdetails4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table65" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label46" runat="server" Text="Other Business Office 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtothersBussinessdetails4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="Pnlmob1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table66" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label47" runat="server" Text="Mobile number of Proprietor 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtmob1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="Pnlmob2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table67" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label48" runat="server" Text="Mobile number of Proprietor 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtmob2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
               <asp:Panel ID="Pnlmob3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table68" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label49" runat="server" Text="Mobile number of Proprietor 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtmob3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="Pnlmob4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table69" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label50" runat="server" Text="Mobile number of Proprietor 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtmob4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
                 <asp:Panel ID="Pnlclient1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table70" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label51" runat="server" Text="Client 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtclient1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
              <asp:Panel ID="Pnlclient2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table71" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label52" runat="server" Text="Client 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtclient2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="Pnlclient3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table72" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label53" runat="server" Text="Client 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtclient3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
             
              <asp:Panel ID="Pnlclient4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table73" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label54" runat="server" Text="Client 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtclient4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="Pnlownership11" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table74" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label55" runat="server" Text="Ownership1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtownership11" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                <asp:Panel ID="Pnlownership12" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table75" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label56" runat="server" Text="Ownership2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtownership12" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
                <asp:Panel ID="Pnlownership13" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table76" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label57" runat="server" Text="Ownership3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtownership13" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             
                <asp:Panel ID="Pnlownership14" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table77" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label58" runat="server" Text="Ownership4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtownership14" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                <asp:Panel ID="PnlNationality1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table78" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label59" runat="server" Text="Nationality 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtnationality1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlNationality2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table79" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label60" runat="server" Text="Nationality 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtnationality2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="PnlNationality3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table80" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label61" runat="server" Text="Nationality 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtnationality3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
              <asp:Panel ID="PnlNationality4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table81" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label62" runat="server" Text="Nationality 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtnationality4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
           <asp:Panel ID="PnlInvolvedInBussiness1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table82" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label63" runat="server" Text="Involved In Bussiness 1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlInvolvedInBussiness1" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
        <asp:Panel ID="PnlInvolvedInBussiness2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table83" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label64" runat="server" Text="Involved In Bussiness 2"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlInvolvedInBussiness2" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
        
          <asp:Panel ID="PnlInvolvedInBussiness3" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table84" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label65" runat="server" Text="Involved In Bussiness 3"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlInvolvedInBussiness3" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
      
      
       
          <asp:Panel ID="PnlInvolvedInBussiness4" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table85" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label66" runat="server" Text="Involved In Bussiness 4"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlInvolvedInBussiness4" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
          <asp:Panel ID="PnlDteailremark1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table86" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label67" runat="server" Text="Remark 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDteailremark1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            
          <asp:Panel ID="PnlDteailremark2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table87" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label68" runat="server" Text="Remark 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDteailremark2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="PnlDteailremark3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table88" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label69" runat="server" Text="Remark 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDteailremark3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
                
            <asp:Panel ID="PnlDteailremark4" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table89" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label70" runat="server" Text="Remark 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDteailremark4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlRegistration1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table90" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label71" runat="server" Text="Registration 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtRegistration1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                  <asp:Panel ID="PnlExpiryDate" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table91" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label72" runat="server" Text="Expiry Date"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="TxtExpiryDate" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img9"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=TxtExpiryDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    
    
                  <asp:Panel ID="PnlLineofBussiness" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table92" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label73" runat="server" Text="Line of Bussiness"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtLineofBussiness" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlIssuingAuthority" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table93" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label74" runat="server" Text="Issuing Authority"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtIssuingAuthority" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
             <asp:Panel ID="PnlTypeofProduct1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table94" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label75" runat="server" Text="Type of Product 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtTypeofProduct1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlTypeofProduct2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table95" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label76" runat="server" Text="Type of Product 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtTypeofProduct2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                  
               <asp:Panel ID="PnlTypeofProduct3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table96" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label77" runat="server" Text="Type of Product 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtTypeofProduct3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                       <asp:Panel ID="PnlTypeofProduct4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table97" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label78" runat="server" Text="Type of Product 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtTypeofProduct4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            
                       <asp:Panel ID="PnlTypeofProduct5" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table98" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label79" runat="server" Text="Type of Product 5"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtTypeofProduct5" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
                   
                       <asp:Panel ID="PnlSalesPOSPrevious1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table99" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label80" runat="server" Text=" Total POS Previous 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxttotalPOSPrevious1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
              <asp:Panel ID="PnlSalesPOSPrevious2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table100" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label81" runat="server" Text=" Total POS Previous 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxttotalPOSPrevious2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="PnlSalesPOSCurrent1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table101" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label82" runat="server" Text=" Total POS Current 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxttotalPOSCurrent1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlSalesPOSCurrent2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table102" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label83" runat="server" Text=" Total POS Current 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxttotalPOSCurrent2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="PnlDirectorName1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table103" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label84" runat="server" Text=" Director Name 1"></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="Label85" runat="server" Text=" Director Name 2"></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="Label86" runat="server" Text=" Director Name 3"></asp:Label>
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
                    <asp:Label SkinID="lblSkin" ID="Label87" runat="server" Text=" Director Name 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorName4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            <asp:Panel ID="PnlDirectorAdd1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table107" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label88" runat="server" Text=" Director Residential Address 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorAdd1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           <asp:Panel ID="PnlDirectorAdd2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table108" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label89" runat="server" Text=" Director Residential Address 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorAdd2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="PnlDirectorAdd3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table109" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label90" runat="server" Text=" Director Residential Address 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorAdd3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
               <asp:Panel ID="PnlDirectorAdd4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table110" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label91" runat="server" Text=" Director Residential Address 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorAdd4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
               <asp:Panel ID="PnlDirectorpermAdd1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table111" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label92" runat="server" Text=" Director Permanent Address 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorpermntAdd1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="PnlDirectorpermAdd2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table136" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label117" runat="server" Text=" Director Permanent Address 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorpermntAdd2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
        
        
        <asp:Panel ID="PnlDirectorpermAdd3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table137" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label118" runat="server" Text=" Director Permanent Address 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorpermntAdd3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="PnlDirectorpermAdd4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table138" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label119" runat="server" Text=" Director Permanent Address 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtDirectorpermntAdd4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
       
        
        
        
        
         <asp:Panel ID="PnlDirectorGender1" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table112" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label93" runat="server" Text="Director Gender 1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlDirectorGender1" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Male" ></asp:ListItem>
                 <asp:ListItem Text="Female"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
        <asp:Panel ID="PnlDirectorGender2" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table113" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label94" runat="server" Text="Director Gender 2"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlDirectorGender2" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Male" ></asp:ListItem>
                 <asp:ListItem Text="Female"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
         <asp:Panel ID="PnlDirectorGender3" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table114" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label95" runat="server" Text="Director Gender 3"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlDirectorGender3" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Male" ></asp:ListItem>
                 <asp:ListItem Text="Female"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
        
         <asp:Panel ID="PnlDirectorGender4" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table115" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label96" runat="server" Text="Director Gender 4"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlDirectorGender4" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Male" ></asp:ListItem>
                 <asp:ListItem Text="Female"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        
        
          <asp:Panel ID="pnlDirectorDOB1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table116" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label97" runat="server" Text="Director DOB 1"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="TxtDirectorDOB1" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img10"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=TxtDirectorDOB1.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    
    
     <asp:Panel ID="pnlDirectorDOB2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table117" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label98" runat="server" Text="Director DOB 2"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="TxtDirectorDOB2" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img11"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=TxtDirectorDOB2.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
       
       
       
        <asp:Panel ID="pnlDirectorDOB3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table118" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label99" runat="server" Text="Director DOB 3"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="TxtDirectorDOB3" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img12"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=TxtDirectorDOB3.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    
    
       <asp:Panel ID="pnlDirectorDOB4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table119" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label100" runat="server" Text="Director DOB 4"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="TxtDirectorDOB4" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img13"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=TxtDirectorDOB4.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    
    
    
    <asp:Panel ID="pnlDirectorEducation1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table120" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label101" runat="server" Text=" Director Education 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txteducation1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlDirectorEducation2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table121" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label102" runat="server" Text=" Director Education 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txteducation2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
                     
            <asp:Panel ID="pnlDirectorEducation3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table122" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label103" runat="server" Text=" Director Education 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txteducation3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="pnlDirectorEducation4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table123" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label104" runat="server" Text=" Director Education 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txteducation4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="pnlDirectorPhone1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table124" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label105" runat="server" Text=" Director Phone 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphone1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="pnlDirectorPhone2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table125" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label106" runat="server" Text=" Director Phone 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphone2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
              <asp:Panel ID="pnlDirectorPhone3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table126" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label107" runat="server" Text=" Director Phone 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphone3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
          
          
           <asp:Panel ID="pnlDirectorPhone4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table127" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label108" runat="server" Text=" Director Phone 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="Txtphone4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
           
            <asp:Panel ID="pnlDirectorMobile1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table128" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label109" runat="server" Text=" Director Mobile 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtMobile1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
          
          
              <asp:Panel ID="pnlDirectorMobile2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table129" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label110" runat="server" Text=" Director Mobile 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtMobile2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlDirectorMobile3" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table130" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label111" runat="server" Text=" Director Mobile 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtMobile3" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
        
        
           <asp:Panel ID="pnlDirectorMobile4" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table131" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label112" runat="server" Text=" Director Mobile 4"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtMobile4" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
               <asp:Panel ID="pnlPrimaryContact" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table132" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label113" runat="server" Text="Primary Contact"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtPrimaryContact" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
            <asp:Panel ID="pnlPrimaryContactDegignation" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table133" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label114" runat="server" Text="Primary Contact Degignation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtPrimaryContactDegignation" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlContactDetails1" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table134" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label115" runat="server" Text="Contact Details 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtContactDetails1" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
             <asp:Panel ID="pnlContactDetails2" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table135" style="width:100%" runat="server"> 
        <tr>
         <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label116" runat="server" Text="Contact Details 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="TxtContactDetails2" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
<%--           //ended by abhijeet for ENBD//--%>
        
      
           
              <asp:Panel ID="Pnlsamplername" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table35" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblsamplername" runat="server" Text="Sampler Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtsamplername" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
              <asp:Panel ID="Pnlagencyremark" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table36" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblagencyremark" runat="server" Text="Agency Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtagencyremark" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="Pnlpickupdate" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table37" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblpickupdate" runat="server" Text="Pickup Date"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="txtpickupdate" runat="server" MaxLength="11"  ></asp:TextBox>
             <img id="img6"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtpickupdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
      <asp:Panel ID="Pnlreportsubdate" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="Table38" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblreportsubdate" runat="server" Text="Report Submited Date"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="txtreportdate" runat="server" MaxLength="11" ></asp:TextBox>
             <img id="img7"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtreportdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
           



<%--Ended by abhijeet Axis bank--%>  
  <asp:Panel ID="PnlAreaname" runat="server" Width="100%" Visible="true">
       <table cellpadding="0" cellspacing="0" border="0" id="tabareaname" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="labAreaname" runat="server" Text="Area Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false"  ValidationGroup="grValidateDate"></asp:DropDownList>
                    <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                    <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />

               
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
          
              
                <table cellpadding="0" cellspacing="0" border="0" id="tblCaseStatus" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server" Text="Case Status"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                     
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server" DataSourceID="sdsCaseStatus"
                          DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID" OnDataBound="ddlCaseStatus_DataBound">
                     </asp:DropDownList>
                    <%-- <asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
                     </asp:SqlDataSource>--%>
                </td>
                </tr>
               </table>
          
                <table cellpadding="0" cellspacing="0" border="0" id="tblOutcome" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOutcome" runat="server" Text="Outcome"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                     
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlOutcome" runat="server" DataSourceID="sdsOutcome"
                          DataTextField="DESCRIPTION" DataValueField="DECLINED_CODE" OnDataBound="ddlOutcome_DataBound"  >
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="sdsOutcome" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [ID],[DECLINED_CODE],[DESCRIPTION] FROM [DECLINED_CODE_MASTER] WHERE ([CLIENT_ID] = ?) ORDER BY DECLINED_CODE">
                         <SelectParameters>
                             <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                </td>
                </tr>
               </table>
          
                <table cellpadding="0" cellspacing="0" border="0" id="tblDeclineReason" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDeclineReason" runat="server" Text="Decline Reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDeclineReason" runat="server" MaxLength="255" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
               
           <!--Start of ATTEMPT DETAIL-->
           
                <table id="tblAttempt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">

                <tr>
                <td class="TDWidth" style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblLogin" runat="server" Text="Attempts"></asp:Label>
                </td>                
                <td style="height: 14px" >
                <asp:Label SkinID="lblSkin" ID="lblDate" runat="server" Text="Date [dd/mm/yyyy]"></asp:Label>
                </td>
                <td style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="Time [hh:mm]"></asp:Label>
                </td>
                <td style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblRemark" runat="server" Text="Verifier Remark"></asp:Label>
                </td>
                <td style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblSubStatus" runat="server" Text="Sub Status"></asp:Label>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server" Text="First Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11"  Width="100"  ID="txtAttemptDate1" runat="server"></asp:TextBox>
                    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime1" Width="50" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType1" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin"   ID="txtAttemptRemark1" runat="server"></asp:TextBox>
                </td>
                <td>
                <asp:DropDownList ID="ddlSubSat1" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:Label SkinID="lblSkin" ID="lblsat1" runat="server" Text=""></asp:Label>
                </td>

                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSecondAttempt" runat="server" Text="Second Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11" Width="100" ID="txtAttemptDate2" runat="server"></asp:TextBox>
                    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime2" Width="50" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType2" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="50"  ID="txtAttemptRemark2" runat="server"></asp:TextBox>
                </td>
                <td>
                <asp:DropDownList ID="ddlSubSat2" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:Label SkinID="lblSkin" ID="lblsat2" runat="server" Text=""></asp:Label>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblThirdAttempt" runat="server" Text="Third Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11" Width="100" ID="txtAttemptDate3" runat="server"></asp:TextBox>
                    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="5" Width="50" ID="txtAttemptTime3" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType3" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark3" runat="server"></asp:TextBox>
                </td>
                <td>
                <asp:DropDownList ID="ddlSubSat3" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:Label SkinID="lblSkin" ID="lblsat3" runat="server" Text=""></asp:Label>
                </td>
                </tr>
                </table>
                
                
                
                 <asp:Panel runat="server" ID="pnlSupNameOld" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSupName" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSupName" runat="server"  Text="Supervisor Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                     <asp:TextBox SkinID="txtSkin" ID="txtSupervisorName" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
                </td>
                </tr></table> </asp:Panel>
                
                
                
                
                <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorName" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblSupervisorName" runat="server"  Text="Supervisor Name"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin"  ID="ddlSupervisorName" runat="server" >
                      </asp:DropDownList><asp:Label id="lblvalid" runat="server" Font-Bold="true" ForeColor="Red" Text="Supervisor Name Is Mandatory" SkinID="lblSkin"></asp:Label>
    </td>
    </tr>
</table>   
                
                
                
                
                <table id="tblSupervisorRemark"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSupervisorRemark" runat="server" Text="Supervisor Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSupervisorRemark" runat="server" Width="80%" MaxLength="3000" TextMode="MultiLine" onkeyPress="ValidateTextLength('Supervisor Remark', this, 3000);"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td colspan="2">
                </td>
                </tr>
                </table>
                <br />
<!--End of ATTEMPT DETAIL-->
             
        <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" runat="server" Text="Submit"  ValidationGroup="grValidateDate" OnClick="btnSubmit_Click"/>    
                <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hidCaseID" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
            <asp:HiddenField ID="hidMode" runat="server"/>
            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
        </asp:Panel>
        <asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select case status." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus" OnServerValidate="cvSelectCaseStatus_ServerValidate">
       </asp:CustomValidator> 
      <asp:CustomValidator ID="cvAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
             Display="None" ErrorMessage="Enter time in first attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime1"></asp:CustomValidator>
        <%--Modified By Gargi Srivastava 31-May-2007--%> 
        <%--<asp:CustomValidator ID="cvAttemptRemark1" runat="server" ClientValidationFunction="ValidateRemark1"
                ControlToValidate="txtAttemptRemark1" Display="None" ErrorMessage="Enter time in first attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
        <%--End--%>         
     <asp:CustomValidator ID="cvAttemptTime2" runat="server" ControlToValidate="txtAttemptTime2"
             Display="None" ErrorMessage="Enter time in second attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime2"></asp:CustomValidator>
      <%--Modified By Gargi Srivastava 31-May-2007--%> 
      <%-- <asp:CustomValidator ID="cvAttemptRemark2" runat="server" ClientValidationFunction="ValidateRemark2"
                ControlToValidate="txtAttemptRemark2" Display="None" ErrorMessage="Enter time in second attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
      <%--End--%> 
       <asp:CustomValidator ID="cvAttemptTime3" runat="server" ControlToValidate="txtAttemptTime3"
                 Display="None" ErrorMessage="Enter time in third attempt." 
                 ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime3"></asp:CustomValidator>
      <%--Modified By Gargi Srivastava 31-May-2007--%> 
      <%-- <asp:CustomValidator ID="cvAttemptRemark3" runat="server" ClientValidationFunction="ValidateRemark3"
                    ControlToValidate="txtAttemptRemark3" Display="None" ErrorMessage="Enter time in third attempt."
                    ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
      <%--End--%> 
      <asp:CustomValidator ID="cvValidate" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateStatus" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus">
       </asp:CustomValidator> 
       <asp:CustomValidator ID="cvValidateDeclineStatus" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateDeclineStatus" SetFocusOnError="true"
                   OnServerValidate="ValidateDeclineCaseStatus">
       </asp:CustomValidator> 

        <asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="txtSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grValidateDate"></asp:RequiredFieldValidator>
    
    
       <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server" ControlToValidate="txtAttemptDate1"
                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server" ControlToValidate="txtAttemptDate2"
                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate3" runat="server" ControlToValidate="txtAttemptDate3"
                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server" ControlToValidate="txtAttemptTime2"
                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revAttemptTime3" runat="server" ControlToValidate="txtAttemptTime3"
                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>                    
         <asp:RegularExpressionValidator ID="revInitiationDate" runat="server" ControlToValidate="txtInitiationDate"
                    Display="None" ErrorMessage="Please enter valid initiation date." SetFocusOnError="True"
                     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCreditAnalystDate"
                    Display="None" ErrorMessage="Please enter valid Credit Analyst Date." SetFocusOnError="True"
                     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
         </asp:RegularExpressionValidator>  
         
<%--added by sanket on 13/02/2014--%>         
        <asp:RequiredFieldValidator ID="rfvAreaname" runat="server"
             ErrorMessage="Please Select Area Name." ControlToValidate="ddlAreaname"
            InitialValue="0" Display="None" ValidationGroup="grValidateDate"  >
        </asp:RequiredFieldValidator>
<%--End by sanket--%>         
         
         
         
                  
         <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" /> 
                    
         <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtAttemptDate1"
            ClientValidationFunction="ValidateAttempts"  ValidationGroup="grValidateDate"  
            ErrorMessage="Enter atleast one Attempt." Display="None">
          </asp:CustomValidator>      
          
        <asp:CompareValidator ID="cmpValYrsWorkedIn" runat="server"  ControlToValidate="txtMthsWorkedIn"  SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12" Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
        <asp:CompareValidator ID="cmpCurrYrsWorkedIn" runat="server"  ControlToValidate="txtTimeCurrOffMths" SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12" Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>          
        <asp:CompareValidator ID="valYrsWorkedIn" runat="server" ControlToValidate="txtYearsWorkedIn"
            Display="None" ErrorMessage="Please Enter numeric only in Months for years lived in" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valMthsWorkedIn" runat="server" ControlToValidate="txtMthsWorkedIn"
            Display="None" ErrorMessage="Please Enter numeric only in Months for months lived in" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrYrsWorkedIn" runat="server" ControlToValidate="txtTimeCurrOffYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr empl/business" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrMtsWorkedIn" runat="server" ControlToValidate="txtTimeCurrOffMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr empl/business" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>        
         </asp:TableCell></asp:TableRow></asp:Table>
</td><td></td>
</tr>
<tr><td></td><td></td><td></td></tr>
</table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
     <asp:HiddenField ID="Hdn_OccupationType" runat="server" />
     <asp:HiddenField ID="hdnSupID" runat="server" />
       
    <asp:SqlDataSource ID="sdsFE" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        
        
            <asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb"  
                          SelectCommand="sp_GetStatus" SelectCommandType="StoredProcedure">
                          
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                              <asp:SessionParameter Name="clientId" SessionField="ClientId" />
                              <asp:SessionParameter Name="Verification_code" SessionField="verification_code" />
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
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRTV" runat="server" Text="PRTV" Width="22px" Visible="False" OnClick="lbPRTV_Click"></asp:LinkButton>
    </td>
    </tr>
    
    </table>
</fieldset>
</td>
</tr>
</table>
</asp:Content>

