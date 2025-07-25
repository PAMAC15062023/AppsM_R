        <%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" 
AutoEventWireup="true" CodeFile="CC_ResidenceVerification.aspx.cs" Inherits="CC_CC_ResidenceVerification"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server" >
<script type="text/javascript" language="javascript">
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
      
//       function ValidateTime1(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark1.focus();
//                arguments.IsValid=false;
//            }              
//          }
//       }
        function ValidateTime1(source, arguments)
       { 
                    
          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length==0)
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
<fieldset><legend class="FormHeading"><asp:Label ID="lblHead" runat="server"></asp:Label> </legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server"  width="100%" style="background-color:#E7F6FF" >
<tr><td style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
<tr><td></td>
<td>
    <asp:Panel ID="pnlMsg" runat="server"  Width="100%">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server" >
        <tr>
        <td class="TDWidth" style="height: 14px">
            <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label></td>               
        </tr>
       </table>
   </asp:Panel> 
   
    <asp:Table ID="tblResiVeri" runat="server"  Width="100%">
    <asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"  EnableViewState="false"></asp:PlaceHolder>
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
    <asp:PlaceHolder ID="PlaceHolder78" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder79" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder80" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder81" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder82" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder83" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder84" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder85" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder86" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder87" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder88" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder89" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder90" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder91" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder92" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder93" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder94" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder95" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder96" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder97" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder98" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder99" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder100" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder101" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder102" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder103" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder104" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder105" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder106" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder107" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder108" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder109" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder110" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder111" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder112" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder113" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder114" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder115" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder116" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder117" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder118" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder119" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder120" runat="server"  EnableViewState="false"></asp:PlaceHolder>        
    <asp:PlaceHolder ID="PlaceHolder121" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder122" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder123" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder124" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder125" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder126" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder127" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder128" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder129" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder130" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder131" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder132" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder133" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder134" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder135" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder136" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder137" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >
       
    <asp:Panel ID="pnlResiVerHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
       <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%"  >
       <asp:Label SkinID="lblSkin" ID="lblResVerHead" runat="server" ForeColor="blue"  Text="RESIDENCE VERIFICATION REPORT" Font-Bold="True"></asp:Label>
        </td>
       </tr>
       
       </table>
    </asp:Panel>
       <asp:Panel ID="pnlAppName" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAppName" style="width:100%" runat="server" >
        <tr>
            <td  class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server"  Text=" Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="60%" ReadOnly="true"></asp:TextBox>
                <%--<asp:Label SkinID="lblSkin" ID="lblIsCase" runat="server"></asp:Label>--%>
            </td>
          
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlRefNo" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth" style="height: 25px"><asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server"  Text="CDM Referance No"></asp:Label>
            </td>
            <td style="width:2%; height: 25px;">:</td>
            <td style="height: 25px" >
                <asp:TextBox  SkinID="txtSkin" ID="txtRefNo" runat="server"  ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel  ID="pnlInitiationDate" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server" > 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server"  Text="Date of Initiation"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td >
        <asp:TextBox SkinID="txtSkin" ID="txtInitiationDate" runat="server"  MaxLength="11"  ReadOnly="true"></asp:TextBox>
             
        </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlAgencyCode" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAgencyCode" style="width:100%" runat="server" >      
           <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server"  Text="Agency Code"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAgencyCode" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlResAddress" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblResAddress" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblResAddress" runat="server"  Text="Address (Residence)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtResAddress" runat="server"  Width="80%" ReadOnly="true" ></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlBldgColor" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblBldgColor" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblBldgColor" runat="server"  Text="Bldg Color"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtBldgColor" runat="server"  Width="80%" ReadOnly="true" ></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlPinCode" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPinCode" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPincode" runat="server"  Text="Pincode" ReadOnly="true"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtPincode" runat="server" ></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlLandmark" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server"  Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  ><asp:TextBox SkinID="txtSkin" ID="txtLandmark" runat="server" ></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    
    
    <asp:Panel ID="pnlTelPPNormal" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblTelPPNormal" style="width:100%" runat="server" >             
    <tr>
         <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTelPPNormal" runat="server"  Text="Telephone No (Resi.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
             <td><asp:TextBox SkinID="txtSkin" ID="txtTelPPNormal" runat="server" ></asp:TextBox>
             <asp:DropDownList SkinID="ddlSkin"  ID="ddlTelPPNormal" runat="server"   AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>PP</asp:ListItem>
                <asp:ListItem>Normal</asp:ListItem>
                <asp:ListItem>Own</asp:ListItem>
                <asp:ListItem>Company Prov</asp:ListItem>
             </asp:DropDownList>
            </td>
             </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlMobile" runat="server"  Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblMobile" style="width:100%" runat="server" >             
    <tr>
    <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblMobile" runat="server"  Text="Mobile No" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtMobile" runat="server"  ReadOnly="true"></asp:TextBox></td>
            
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
    
    <asp:Panel ID="pnlVeriScore" runat="server"  Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblVeriScore" style="width:100%" runat="server" >             
    <tr>
    <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblVeriScore" runat="server"  Text="Verification - Score" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtVeriScore" runat="server"></asp:TextBox></td>
            
        </tr>
    </table>
    </asp:Panel> 
       
    <asp:Panel ID="pnlVerDtlHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%" >
        <asp:Label ID="lblVerDtlHead" runat="server" ForeColor="blue"  Text="VERIFICATION DETAILS" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
  
        <asp:Panel ID="pnlPerAddress" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddress" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPerAddress" runat="server"  Text="Permanent Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPerAddress" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPerAddPinCode" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddPinCode" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblPerAddPinCode" runat="server"  Text="Pincode"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtPerAddPinCode" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPerAddLandmark" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddLandmark" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblPerAddLandmark" runat="server"  Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtPerAddLandmark" runat="server"  MaxLength="25"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>        
        <asp:Panel ID="pnlDOB" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server"  Text="Date of Birth"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin" ID="txtDOB" runat="server"  MaxLength="10" ></asp:TextBox>
             <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            
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
             <img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateTimeVisit.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            <asp:Label SkinID="lblSkin" ID="lblVisit" runat="server"  Text="Time of Visit"></asp:Label>
           <asp:TextBox SkinID="txtSkin" ID="txtVisit" runat="server"></asp:TextBox> 
           </td>
           </tr>
           </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlQualification" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblQualification" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" id="lblQualification" runat="server"  Text="Qualification"></asp:Label>
           </td>
           <td style="width:2%">:</td>
           <td>            
            <asp:DropDownList SkinID="ddlSkin"  ID="ddlQualification" runat="server" AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Matric</asp:ListItem>
                <asp:ListItem>Undergraduate</asp:ListItem>
                <asp:ListItem>Post graduate</asp:ListItem>
                <asp:ListItem>Professional</asp:ListItem>
                <asp:ListItem>Graduate</asp:ListItem>
                <asp:ListItem>10+2</asp:ListItem>
                <asp:ListItem><=10th</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
             </asp:DropDownList>            
            </td>
            </tr>
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherQualification" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherQualification" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
            </table>
        </asp:Panel>        
       
        <asp:Panel ID="pnlTimeCurr" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurr" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblTimeCurr" runat="server"  Text="Time at curr"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" Width="5%" ID="txtTimeCurrYrs" runat="server"  MaxLength="2"  ></asp:TextBox>Yrs
                <asp:TextBox SkinID="txtSkin" Width="5%" ID="txtTimeCurrMths" runat="server"  MaxLength="2"  ></asp:TextBox>Mths
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
            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>            
            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
            </asp:DropDownList>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherMaritalStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherMaritalStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherMaritalStatus" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherMaritalStatus" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlIfSpouseWorking" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblIfSpouseWorking" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblpnlIfSpouseWorking" runat="server"  Text="If Spouse working"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:DropDownList SkinID="ddlSkin" ID="ddlIfSpouseWorking" runat="server" AutoPostBack="false">
            <asp:ListItem>NA</asp:ListItem>
            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
            <asp:ListItem Text="No" Value="No"></asp:ListItem>
           </asp:DropDownList>
            </td>
            </tr>            
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseCompanyName" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseCompanyName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseCompanyName" runat="server"  Text="Company Name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseCompanyName" Width="60%" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         
         <%--add code as new requirement by santosh shelar--%>
         <asp:Panel ID="pnlAppResi" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAppResi" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblAppResi" runat="server"  Text="Approch to Residence"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAppResi" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Kaccharoad</asp:ListItem>
                    <asp:ListItem>Congested Street-On Foot Approach</asp:ListItem>
                    <asp:ListItem>SmallStreet-2 Wheeler Approach</asp:ListItem>
                    <asp:ListItem>Tamac Road-Car Approach</asp:ListItem>
                    <asp:ListItem>On Foot Only</asp:ListItem>
                     </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlNoWin" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblNoWin" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblNoWin" runat="server" Text="No. of Windows"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtNoWin" Width="80%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlRoomType" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblRoomType" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblRoomType" runat="server"  Text="Room Type"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRoomType" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>1 room</asp:ListItem>
                    <asp:ListItem>1 room Kitchen with Loft</asp:ListItem>
                    <asp:ListItem>2 Bed room Hall Kitchen</asp:ListItem>
                    </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
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
         
         
         
         
         <asp:Panel ID="pnlSpouseOccu" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseOccu" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseOccu" runat="server"  Text="Spouse Occupation"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseOccu" Width="60%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseName" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseName" runat="server" Text="Spouse / Father Name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseName" Width="60%" runat="server"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlCarPark" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblCarPark" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblCarPark" runat="server"  Text="Car Park"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlCarPark" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlEntranceMotorable" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblEntranceMotorable" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblEntranceMotorable" runat="server"  Text="Is the entrance of the house motarable:"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlEntranceMotorable" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                  
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
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlResidenceInternal" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceInternal" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblResidenceInternal" runat="server"  Text="Residence Internal"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlResidenceInternal" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Well furnnished</asp:ListItem>
                    <asp:ListItem>Avg furnished</asp:ListItem>                  
                    <asp:ListItem>Poor furnished</asp:ListItem>                  
                    <asp:ListItem>Unfurnished</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlFlooring" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblFlooring" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblFlooring" runat="server"  Text="Type of Flooring"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlFlooring" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Small Tiles</asp:ListItem>
                    <asp:ListItem>Mud</asp:ListItem>                  
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
         <asp:Panel ID="pnlRoofing" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblRoofing" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblRoofing" runat="server"  Text="Type of Roofing"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRoofing" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Tile</asp:ListItem>
                    <asp:ListItem>Asbestos</asp:ListItem>                  
                    <asp:ListItem>Concrete</asp:ListItem>                  
                    <asp:ListItem>Thatched</asp:ListItem>                  
                    <asp:ListItem>Pukka Roof</asp:ListItem>                  
                    <asp:ListItem>Manglore</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlStanLiving" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblStanLiving" style="width:100%" runat="server">          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblStanLiving" runat="server"  Text="Standard of living"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlStanLiving" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>                  
                    <asp:ListItem>Average</asp:ListItem>                  
                    <asp:ListItem>Poor</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlBuildSeen" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblBuildSeen" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblBuildSeen" runat="server" Text="Building Name Seen" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtBuildSeen" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlAddUpd" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAddUpd" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAddUpd" runat="server" Text="Address Updation" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAddUpd" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlNatureRel" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblNatureRel" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblNatureRel" runat="server" Text="Nature of Relantionship" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtNatureRel" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelSince" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblRelSince" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblRelSince" runat="server" Text="Relantionship Since" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtRelSince" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlAccNo" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAccNo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAccNo" runat="server" Text="Accounant No." ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAccNo" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlDocVeri" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblDocVeri" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDocVeri" runat="server" Text="Document Verified" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtDocVeri" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlBankObli" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblBankObli" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblBankObli" runat="server" Text="Bank's Obligation" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtBankObli" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlDateAmtLoan" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblDateAmtLoan" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDateAmtLoan" runat="server" Text="Date of loan taken & Loan Amt" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtDateAmtLoan" runat="server" Width="80%"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           
         <%--end code--%>
         
         <asp:Panel ID="pnlSpouseTelephoneNo" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseTelephoneNo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseTelephoneNo" runat="server"  Text="Telephone No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseTelephoneNo" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseSalary" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseSalary" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseSalary" runat="server"  Text="Salary"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseSalary" runat="server"  MaxLength="12"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlNoDependent" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblNoDependent" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblNoDependent" runat="server"  Text="No of dependent"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtNoDependent" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
          <asp:Panel ID="pnlDesignationAtOffice" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblDesignationAtOffice" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDesignationAtOffice" runat="server"  Text="Designation at Office" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtDesignationAtOffice" runat="server"  MaxLength="100"></asp:TextBox>            
            </td>
            </tr>
            </table>
          </asp:Panel>
          <asp:Panel ID="pnlAppCompName" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAppCompName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAppCompName" runat="server"  Text="Company Name" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAppCompName" runat="server" Width="60%" MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlOfficeAddress" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAddress" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblOfficeAddress" runat="server"  Text="Office Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtOfficeAddress" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
            </td>
            </tr>
            </table>            
           </asp:Panel>
           <asp:Panel ID="pnlVerOfficePhone" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVerOfficePhone" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblVerOfficePhone" runat="server"  Text="Office Phone No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtVerOfficePhone" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlOfficeExtn" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeExtn" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblOfficeExtn" runat="server"  Text="Office Extn"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtOfficeExtn" runat="server"  MaxLength="5"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlVehicleType" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleType" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblVehicleType" runat="server"  Text="Vehicle Type"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList  SkinID="ddlSkin" ID="ddlVehicleType" runat="server"   AutoPostBack="false">
                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Two wheeler" Value="Two wheeler"></asp:ListItem>
                <asp:ListItem Text="Three wheeler" Value="Three wheeler"></asp:ListItem>
                <asp:ListItem Text="Four wheeler" Value="Four wheeler"></asp:ListItem>            
            </asp:DropDownList>
            </td>
            </tr>
            </table>                
           </asp:Panel>
                  <asp:Panel ID="PnlTypeofSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label1" runat="server"  Text="Type of Society"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkTypeofSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Govt Approved (DDA/BMP)</asp:ListItem>
                    <asp:ListItem>Other Private Builders</asp:ListItem>
                    <asp:ListItem>Top Private Builders</asp:ListItem> 
                    <asp:ListItem>None</asp:ListItem>
                </asp:CheckBoxList>   
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
                        <asp:ListItem>W06-PVT Operator</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                </tr>
               </table>
            </asp:Panel>
       <asp:Panel ID="PnlOtherFacilities" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label2" runat="server"  Text="Other Facilities"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkOtherFacilities" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Maintenance Charges</asp:ListItem>
                    <asp:ListItem>Supermart/parking</asp:ListItem>
                    <asp:ListItem>Gym</asp:ListItem> 
                    <asp:ListItem>Swimming Pool</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
<%--start santosh--%>         
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNamePlateonDoor" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
<%--end santosh--%>
       <asp:Panel ID="PnlMarketValue" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label3" runat="server"  Text="Market Value of Property"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkMarketValue" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>35 Lacs</asp:ListItem>
                    <asp:ListItem>35-50 Lacs</asp:ListItem>
                    <asp:ListItem>50-75 Lacs</asp:ListItem> 
                    <asp:ListItem>>75 Lacs</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlBuiltupArea" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table4" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label4" runat="server"  Text="Built up Area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkBuiltupArea" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>400-700 sq ft</asp:ListItem>
                    <asp:ListItem>800-1300 sq ft</asp:ListItem>
                    <asp:ListItem>1300-3000 sq ft</asp:ListItem> 
                    <asp:ListItem>>300 sq ft</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNoOfFlatsSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label5" runat="server"  Text="No. of flats in the Society"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkNoOfFlatsSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem><20</asp:ListItem>
                    <asp:ListItem>20-50</asp:ListItem>
                    <asp:ListItem>50-100</asp:ListItem> 
                    <asp:ListItem>>100</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlBedroom" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table6" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label6" runat="server"  Text="Does the Society have 1 bedroom flats?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkBedroom" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNegativeAreaSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label7" runat="server"  Text="Is Scoiety in negative area?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkNegativeAreaSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlDetailstakenbytpc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table8" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label8" runat="server"  Text="Details taken by - TPC"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtDetailstakenbytpc" runat="server"  SkinID="txtSkin" MaxLength="500"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlPhoneNumbersoftpc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label9" runat="server"  Text="Phone Numbers of TPC"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtPhoneNumbersoftpc" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlHistory" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table10" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label10" runat="server"  Text="History"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtHistory" runat="server" width="80%" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNoOfEmployeesSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table11" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label11" runat="server"  Text="No of Employees in the Society"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtNoOfEmployeesSociety" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlRemarkSociey" runat="server"  Width="80%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table12" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label12" runat="server"  Text="Any Addidtional Remarks"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtRemarkSociey" runat="server" Width="100%" SkinID="txtSkin" MaxLength="500"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>

           <asp:Panel ID="pnlVehicleMake" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleMake" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblVehicleMake" runat="server"  Text="Vehicle Make"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtVehicleMake" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlVehicleIs" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                <asp:Label ID="lblVehicleIs" runat="server"  Text="Vehicle is"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td style="width: 145px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVehicleIs" runat="server"   AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Co provided" Value="Co provided"></asp:ListItem>
                    <asp:ListItem Text="Financed" Value="Financed"></asp:ListItem>
                    <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                    <asp:ListItem Text="Others(specify)" Value="Others(specify)"></asp:ListItem>
                </asp:DropDownList>
                </td>                
                </tr>
            </table>                
             </asp:Panel>
             <asp:Panel ID="pnlOtherVehicleIs" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVehicleIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVehicleIs" runat="server"  Text="If Others specify"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVehicleIs" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>             
            <asp:Panel ID="pnlIncomeDoc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIncomeDoc" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin"  ID="lblIncomeDoc" runat="server"  Text="Income Docs submitted with application(only if applicant contacted)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtIncomeDoc" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCreditCards" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblCreditCards" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblCreditCards" runat="server"  Text="Any CreditCards"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlCreditCards" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>                    
                </asp:DropDownList>
            </td>
            </tr>
            </table>
            </asp:Panel> 
            <asp:Panel ID="pnlIfCreditCard" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblIfCreditCard" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIfYes" runat="server"  Text="If Yes then"></asp:Label>   
            </td>            
            </tr>
            </table>            
            </asp:Panel>
            <asp:Panel ID="pnlCardType" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardType" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardType" runat="server"  Text="a) Card Type"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardType" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCardNo" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardNo" style="width:100%" runat="server" >
            <tr>
            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardNo" runat="server"  Text="b) Card No."></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardNo" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCardLimit" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardLimit" style="width:100%" runat="server" >
            <tr>            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardLimit" runat="server"  Text="c) Card Limit"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardLimit" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            
            
        <%--Added for ING Vysya--%>
        <asp:Panel ID="pnlIssuing" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblIssuing" style="width:100%" runat="server" >
            <tr>            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIssuing" runat="server"  Text=" d) Card Issuing Bank/Date"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox  SkinID="txtSkin" ID="txtIssuing" runat="server"  MaxLength="12"></asp:TextBox>
            </td>
            </tr>
            </table>
       </asp:Panel>
       <%--End for ING Vysya--%>              
            
            
            <asp:Panel ID="pnlCardExpiry" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardExpiry" style="width:100%" runat="server" >
            <tr>            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardExpiry" runat="server"  Text=" e) Card Expiry"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox  SkinID="txtSkin" ID="txtCardExpiry" runat="server"  MaxLength="12"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            
                        
   
    <asp:Panel ID="pnlNeghContactHead" runat="server"  Width="100%" Visible="false">
    <table>
    <tr>
    <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%" >
    <asp:Label SkinID="lblSkin" ID="lblNeghContactHead" runat="server" ForeColor="blue"  Text="IF NEIGHBOUR HAS BEEN CONTACTED" Font-Bold="True"></asp:Label>
    </td>
    </tr>    
    </table>
        
    </asp:Panel>
         
         <asp:Panel  ID="pnlAppAvailableAt" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAppAvailable" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label  SkinID="lblSkin" ID="lblAppAvailbleAt" runat="server"  Text="Applicant is usually available at"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAppAvailbleAt" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlTimeCurrRes" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurrRes" style="width:100%" runat="server" >
            <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblTimeCurrRes" runat="server"  Text="Time at curr res"></asp:Label>
                    </td>
               <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" id="txtTimeCurrResYrs" Width="5%"  runat="server"  MaxLength="2" ></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" id="txtTimeCurrResMths" Width="5%"  runat="server"   MaxLength="2" ></asp:TextBox>Mths
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlNeighResidenceIs" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblNeighResidenceIs" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNeighResidenceIs" runat="server"  Text="Residence is"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNeighResidenceIs" runat="server"   AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Company Accommodation" Value="Company Accommodation"></asp:ListItem>
                        <asp:ListItem Text="Lodging" Value="Lodging"></asp:ListItem>
                        <asp:ListItem Text="Owned by Friend" Value="Owned by Friend"></asp:ListItem>
                        <asp:ListItem Text="Owned by Parents" Value="Owned by Parents"></asp:ListItem>
                        <asp:ListItem Text="Owned by Relative" Value="Owned by Relative"></asp:ListItem>
                        <asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
                        <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                        <asp:ListItem Text="Self Owned" Value="Self Owned"></asp:ListItem>
                        <asp:ListItem Text="Parental" Value="Parental"></asp:ListItem>
                        <asp:ListItem Text="Bachelor Accomodation" Value="Bachelor Accomodation"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOtherNeighResidenceIs" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherNeighResidenceIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherNeighResidenceIs" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherNeighResidenceIs" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
        </asp:Panel>
        <asp:Panel ID="pnlIfNeighRentedthenAmt" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblIfNeighRentedthenAmt" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIfNeighRentedthenAmt" runat="server"  Text="If Rented then Amount"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtIfNeighRentedthenAmt" runat="server"  MaxLength="15"></asp:TextBox>
            </td>
            </tr>
        </table>
        </asp:Panel>        
         <asp:Panel ID="pnlApplicantWorkAt" runat="server"  Width="100%" Visible="false"> 
         <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantWorkAt" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblApplicantWorkAt" runat="server"  Text="Applicant works at"></asp:Label>            
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtApplicantWorkAt" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlVerifiedFrom" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVerifiedFrom" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblVerifiedFrom" runat="server"  Text="Verified from"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID ="ddlSkin" ID="ddlVerifiedFrom" runat="server"   AutoPostBack="false">                
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Name plate," Value="Name plate,"></asp:ListItem>
                    <asp:ListItem Text="Neighbour," Value="Neighbour,"></asp:ListItem>
                    <asp:ListItem Text="Society Board," Value="Society Board,"></asp:ListItem>
                    <asp:ListItem Text="Watchman," Value="Watchman,"></asp:ListItem> 
                    <asp:ListItem Text="Company Board," Value="Company Board,"></asp:ListItem>                                    
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
        <asp:Panel ID="pnlObservationHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
         <asp:Label ID="lblObservationHead" runat="server"  ForeColor="blue" Text="OBSERVATIONS" Font-Bold="True"></asp:Label>
        </td></tr>
        </table>
           
        </asp:Panel>
             
        <asp:Panel ID="pnlTypeOfResidence" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfResidence" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTypeOfResidence" runat="server"  Text="Type of residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfResidence" runat="server"   AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Bungalow" Value="Bungalow"></asp:ListItem>
                    <asp:ListItem Text="Flat" Value="Flat"></asp:ListItem>
                    <asp:ListItem Text="Independent House" Value="Independent House"></asp:ListItem>
                    <asp:ListItem Text="Multi tenant House" Value="Multi tenant House"></asp:ListItem>
                    <asp:ListItem Text="Part of Independent House" Value="Part of Independent House"></asp:ListItem>
                    <asp:ListItem Text="Row House" Value="Row House"></asp:ListItem>
                    <asp:ListItem Text="Hutment/Sitting Chawl" Value="Hutment/Sitting Chawl"></asp:ListItem>
                    <asp:ListItem Text="Standing Chawl/Janta Flat" Value="Standing Chawl/Janta Flat"></asp:ListItem>
                    <%--Added for ING Vysya--%>
                    <asp:ListItem Text="Temporary Shed" Value="Temporary Shed"></asp:ListItem>
                    <%--End for ING Vysya--%>
                    <asp:ListItem Text="Company Accommodation" Value="Company Accommodation"></asp:ListItem>
                    <asp:ListItem Text="Bach Accommodation" Value="Bach Accommodation"></asp:ListItem>
                    <asp:ListItem Text="Govt or Company Provided" Value="Govt or Company Provided"></asp:ListItem>
                    <asp:ListItem Text="Lodging" Value="Lodging"></asp:ListItem>
                    <asp:ListItem Text="Owned by Friend" Value="Owned by Friend"></asp:ListItem>
                    <asp:ListItem Text="Owned by Parents" Value="Owned by Parents"></asp:ListItem>
                    <asp:ListItem Text="Owned by Relative" Value="Owned by Relative"></asp:ListItem>
                    <asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
                    <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                    <asp:ListItem Text="Self Owned" Value="Self Owned"></asp:ListItem>
                    <asp:ListItem Text="Slum" Value="Slum"></asp:ListItem>
                    <asp:ListItem Text="Staff Quarters" Value="Staff Quarters"></asp:ListItem>
                    <asp:ListItem Text="Annexe To House" Value="Annexe To House"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>  
                    </asp:DropDownList>
                </td>                
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOtherResiType" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherResiType" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherResiType" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherResiType" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlApproxArea" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblApproxArea" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server"  Text="Approximate Area(in sq ft)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtApproxArea" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlGeneralApp" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralApp" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblGeneralApp" runat="server"  Text="General appearance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlGeneralApp" runat="server"   AutoPostBack="false">
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
         <asp:Panel ID="pnlLocality" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocality" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label ID="lblLocality" runat="server"  Text="Locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin"  ID="ddlLocality" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Lower class area</asp:ListItem>
                    <asp:ListItem>Lower Middle Class</asp:ListItem>
                    <asp:ListItem>Middle Class</asp:ListItem>
                    <asp:ListItem>Upper Middle Class</asp:ListItem>
                    <asp:ListItem>Posh</asp:ListItem>
                    <asp:ListItem>Village Area</asp:ListItem>
                    <asp:ListItem>Slums</asp:ListItem>
                    <asp:ListItem>Residential Complex</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherLocality" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherLocality" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlLocatingAdd" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocatingAdd" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLocatingAdd" runat="server"  Text="Locating the address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingAdd" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Easy to Locate</asp:ListItem>
                    <asp:ListItem>Difficult to Locate</asp:ListItem>
                    <asp:ListItem>Very Difficult</asp:ListItem>
                    <asp:ListItem>Little Difficult</asp:ListItem>
                    <asp:ListItem>Untraceable</asp:ListItem>
                    <asp:ListItem>Need Assistance</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlStandLive" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblStandLive" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblStandLive" runat="server"  Text="Standard of Living"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlStandLive" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Upper Class</asp:ListItem>
                    <asp:ListItem>U Middle</asp:ListItem>
                    <asp:ListItem>Middle</asp:ListItem>
                    <asp:ListItem>L Middle</asp:ListItem>
                    <asp:ListItem>Lower</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlTypeProof" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTypeProof" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTypeProof" runat="server"  Text="Type of Proof"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeProof" runat="server" AutoPostBack="false">
                    <asp:ListItem>ID Card</asp:ListItem>
                    <asp:ListItem>Voter's Card</asp:ListItem>
                    <asp:ListItem>D. Licence</asp:ListItem>
                    <asp:ListItem>Passport</asp:ListItem>
                    <asp:ListItem>Ration Card</asp:ListItem>
                    <asp:ListItem>Utility Bill</asp:ListItem>
                    <asp:ListItem>Letter</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
       <asp:Panel ID="pnlAssets" runat="server"  Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblAssets" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAssets" runat="server"  Text="Assets visible"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkAssetsVisible" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Air Conditioner</asp:ListItem>
                    <asp:ListItem>Television</asp:ListItem>
                    <asp:ListItem>Two Wheeler</asp:ListItem>
                    <asp:ListItem>Refrigerator</asp:ListItem>
                    <asp:ListItem>Car</asp:ListItem> 
                    <asp:ListItem>Music System</asp:ListItem>
                    <asp:ListItem>PC</asp:ListItem>                    
                    <asp:ListItem>Phone</asp:ListItem>                    
                    <asp:ListItem>Sofa Set</asp:ListItem>                    
                    <asp:ListItem>Washing Machine</asp:ListItem>                    
                    <asp:ListItem>Microwave</asp:ListItem>                    
                    <asp:ListItem>Four Wheeler</asp:ListItem> 
                    <asp:ListItem>Cooler</asp:ListItem> 
                    <asp:ListItem>AC</asp:ListItem> 
                    <asp:ListItem>Photocopier</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>                    
                    </asp:CheckBoxList>   
                </td>                
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherAssetVisible" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherAssetVisible" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherAssetVisible" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherAssetVisible" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlPoliticalPic" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblPoliticalPic" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblPoliticalPic" runat="server"  Text="Portrait/picture of political leader Sighted"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPoliticalPic" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
          <asp:Panel ID="pnlVisitProof" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblVisitProof" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblVisitProof" runat="server"  Text="Proof of Visit Collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitProof" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
        <asp:Panel ID="pnlRouteMap" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRouteMap" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRouteMap" runat="server"  Text="Route map drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRouteMap" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>            
                </td>
                </tr>
                </table>
        </asp:Panel>
       <asp:Panel ID="pnlNegativeArea" runat="server"  Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeArea" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNegativeArea" runat="server"  Text="Negative area"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNegativeArea" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOCL" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOCL" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOCL" runat="server"  Text="OCL"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlOCL" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>    
        </asp:Panel>  
         <asp:Panel ID="pnlTPCDone" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDone" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTPCDone" runat="server"  Text="TPC Done"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCDone" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlTPCDetail" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDetail" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTPCDetail" runat="server"  Text="Details of TPC"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtTPCDetail" runat="server" Width="80%" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>   
        <asp:Panel ID="pnlAnyInfo" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAnyInfo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAnyInfo" runat="server"  Text="Any other information obtained"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                <asp:TextBox SkinID="txtSkin" ID="txtAnyInfo" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNewInfoFERemark" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNewInfoFERemark" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNewInfoFERemark" runat="server"  Text="New Info Obtained (FE Remarks)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtNewInfoFERemark" runat="server" TextMode="MultiLine" Width="80%" MaxLength="1000"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>        
   
       <asp:Panel ID="pnlRatingHead" runat="server"  Width="100%" Visible="false">
           <table>
    <tr>
    <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%">
    <asp:Label SkinID="lblSkin" ID="lblRatingHead" runat="server" ForeColor="blue"  Text="RATING" Font-Bold="True"></asp:Label></td>
    </tr>
    </table>
          
       </asp:Panel>
                  
         <asp:Panel ID="pnlAddConfirmation" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfirmation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddConfirmation" runat="server"  Text="Address Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAddConfirmation" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Confirmed</asp:ListItem>
                        <asp:ListItem>Not Confirmed</asp:ListItem> 
                        <asp:ListItem>Refused</asp:ListItem>              
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
               </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlContactability" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblContactability" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContactability" runat="server"  Text="Contactability"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtContactability" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlConfirmationApp" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConfirmationApp" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConfirmationApp" runat="server"  Text="Confirmation of Application"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtConfirmationApp" runat="server"  MaxLength="15"></asp:TextBox>
                </td>            
                </tr>        
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlProfile" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProfile" style="width:100%" runat="server" >
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfile" runat="server"  Text="Profile"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtProfile" runat="server"  MaxLength="200"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlReputation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReputation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReputation" runat="server"  Text="Reputation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtReputation" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlOverallAsst" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOverallAsst" style="width:100%" runat="server" >
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOverallAsst" runat="server"  Text="Overall Assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOverallAsst" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlAsstReason" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAsstReason" style="width:100%" runat="server" >
                <tr>
           
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblAsstReason" runat="server"  Text="Reasons for the above assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAsstReason" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlPersonContacted" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPersonContacted" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonContacted" runat="server"  Text="Person contacted/Met"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPersonContacted" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelationApplicant" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationApplicant" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblRelationApplicant" runat="server"  Text="Relation with applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtRelationApplicant" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResidenceIsStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceIsStatusk" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblResidenceIsStatus" runat="server"  Text="Residence is (Status)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlResidenceIsStatus" runat="server"   AutoPostBack="false">
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Family/Ancestral" Value="Family/Ancestral"></asp:ListItem>
                        <asp:ListItem Text="Bachelor Acco" Value="Bachelor Acco"></asp:ListItem>
                        <asp:ListItem Text="Company Accommodation" Value="Company Accommodation"></asp:ListItem>
                        <asp:ListItem Text="Lodging" Value="Lodging"></asp:ListItem>
                        <asp:ListItem Text="Owned by Friend" Value="Owned by Friend"></asp:ListItem>
                        <asp:ListItem Text="Owned by Parents" Value="Owned by Parents"></asp:ListItem>
                        <asp:ListItem Text="Owned by Relative" Value="Owned by Relative"></asp:ListItem>
                        <asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
                        <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                        <asp:ListItem Text="Self Owned" Value="Self Owned"></asp:ListItem>
                        </asp:DropDownList>
                </td>                
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlOtherResidenceIsStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherResidenceIsStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherResidenceIsStatus" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherResidenceIsStatus" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlCooperativeCustomer" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCooperativeCustomer" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblCooperativeCustomer" runat="server"  Text="How Cooperative was customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                    
                    <asp:DropDownList SkinID="ddlSkin"  ID="ddlCooperativeCustomer" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Polite</asp:ListItem>
                        <asp:ListItem>Rude</asp:ListItem>
                     </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlIssuingBank" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIssuingBank" style="width:100%" runat="server" >
                <tr>
                <td  class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIssuingBank" runat="server"  Text="Issuing Bank"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIssuingBank" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNeighbourRef" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourRef" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourRef" runat="server"  Text="Neighbour reference"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                    
                    <asp:DropDownList SkinID="ddlSkin"  ID="ddlNeighbourRef" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                       <%-- <asp:ListItem>+ve</asp:ListItem>
                        <asp:ListItem>-ve</asp:ListItem>--%>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>
                     </asp:DropDownList>
                    
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlConstructionOfResi" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConstructionOfResi" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConstructionOfResi" runat="server"  Text="Construction of residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" Id="ddlConstructionOfResi" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Pukka</asp:ListItem>
                        <asp:ListItem>Semi-Pukka</asp:ListItem> 
                        <asp:ListItem>Temporary</asp:ListItem>           
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlExteriorComments" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExteriorComments" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExteriorComments" runat="server"  Text="Comments of exteriors"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:CheckBoxList ID="chkExteriorComments" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="Horizontal">
                        <asp:ListItem>Garden</asp:ListItem> 
                        <asp:ListItem>Security</asp:ListItem>  
                        <asp:ListItem>Building Wall</asp:ListItem>
                        <asp:ListItem>Fenced/Compound Wall</asp:ListItem>
                        <asp:ListItem>Elevator</asp:ListItem>      
                        <asp:ListItem>Car Park</asp:ListItem>      
                        <asp:ListItem>Others</asp:ListItem>                              
                    </asp:CheckBoxList>                    
                </td>                
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlIfOtherExteriorComments" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherExteriorComments" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherExteriorComments" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherExteriorComments" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlDoesAppStay" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDoesAppStay" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblDoesAppStay" runat="server"  Text="Does the app stay at this residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesAppStay" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Confirmed</asp:ListItem>
                        <asp:ListItem>Not Confirmed</asp:ListItem>            
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                    
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlApproxAgeOfApp" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproxAgeOfApp" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproxAgeOfApp" runat="server"  Text="Approximate age of applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                   <asp:TextBox SkinID="txtSkin" ID="txtApproxAgeOfApp" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfFamilyMem" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfFamilyMem" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfFamilyMem" runat="server"  Text="Number of family member in the house"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtNoOfFamilyMem" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlAppNameplateSight" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppNameplateSight" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppNameplateSight" runat="server"  Text="App nameplate sighted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAppNameplateSight" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOwenershipApp1" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOwenershipApp1" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOwenershipApp1" runat="server"  Text="Ownership of residence of applicant-1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOwenershipApp1" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlEmpStatus1" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmpStatus1" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmpStatus1" runat="server"  Text="Employment status-1 / Details"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEmpStatus1" runat="server" Width="80%" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlOwenershipApp2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOwenershipApp2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOwenershipApp2" runat="server"  Text="Ownership of residence of applicant-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOwenershipApp2" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlEmpStatus2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmpStatus2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmpStatus2" runat="server"  Text="Employment status-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEmpStatus2" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>     
           
            <asp:Panel ID="pnlBankNameCC" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankNameCC" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankNameCC" runat="server"  Text="Bank Name(CC)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtBankNameCC" runat="server"  MaxLength="100" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            <asp:Panel ID="pnlProductName" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductName" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductName" runat="server"  Text="Product / Mother Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtProductName" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAmountDefault" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAmountDefault" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAmountDefault" runat="server"  Text="Amount Default"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAmountDefault" runat="server"  MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlPriorityCustomer" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPriorityCustomer" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPriorityCustomer" runat="server"  Text="Priority Customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPriorityCustomer" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlSegment" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSegment" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSegment" runat="server"  Text="Segment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtSegment" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlInfoRequired" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRequired" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRequired" runat="server"  Text="Info required"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtInfoRequired" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlChangeAdd" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblChangeAdd" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblChangeAdd" runat="server"  Text="Change in add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtChangeAdd" runat="server"  MaxLength="300"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlReasonForChange" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForChange" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForChange" runat="server"  Text="Reason for change"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtReasonForChange" runat="server"  Width="80%" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           
           <asp:Panel ID="pnlCPVScore" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCPVScore" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblCPVScore" runat="server"  Text="CPV Score"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtCPVScore" runat="server"  MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTrackNo" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTrackNo" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTrackNo" runat="server"  Text="Track No"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtTrackNo" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlEntryPermitted" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEntryPermitted" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEntryPermitted" runat="server"  Text="Entry Permitted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEntryPermitted" runat="server"  MaxLength="10"></asp:TextBox>
                    
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAddConfBy" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfBy" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblAddConfBy" runat="server"  Text="Add Conf By"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAddConfBy" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfFamMemEarning" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfFamMemEarning" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfFamMemEarning" runat="server"  Text="No of earning family member"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtNoOfFamMemEarning" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOfficeTelephone" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeTelephone" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeTelephone" runat="server"  Text="Telephone no office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOfficeTelephone" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlApproxValIfOwned" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproxValIfOwned" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproxValIfOwned" runat="server"  Text="Approx value if owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtApproxValIfOwned" runat="server"  MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlBranch" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch" runat="server"  Text="Branch"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtBranch" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlInfoRefused" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRefused" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRefused" runat="server"  Text="Information refused"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtInfoRefused" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPC2" runat="server"  Text="TPC2" ></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtTPC2" runat="server"  ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlPersonMet2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPersonMet2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonMet2" runat="server"  Text="Person met-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPersonMet2" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAdd2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAdd2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAdd2" runat="server"  Text="add-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAdd2" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAppAvaAtHome" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppAvaAtHome" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppAvaAtHome" runat="server"  Text="app is available at home-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAppAvaAtHome" runat="server"  MaxLength="20" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAppAge2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppAge2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppAge2" runat="server"  Text="app age-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAppAge2" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfResAtHome2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfResAtHome2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label ID="lblNoOfResAtHome2" runat="server"  Text="No of residents at home-2"></asp:Label>
                </td> 
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtNoOfResAtHome2" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            <asp:Panel ID="pnlYearLiveAtAdd2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearLiveAtAdd2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblYearLiveAtAdd2" runat="server"  Text="Years lived at this add-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtYearLiveAtAdd2" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlResStatus2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResStatus2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblResStatus2" runat="server"  Text="Residents status-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtResStatus2" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOccupation2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOccupation2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblOccupation2" runat="server"  Text="Occupation-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtOccupation2" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlReasonForAddNotConfirm" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForAddNotConfirm" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblReasonForAddNotConfirm" runat="server"  Text="Reason for add not confirmed" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtReasonForAddNotConfirm" runat="server"  Width="80%" SkinID="txtSkin" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlUntraceableReason" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblUntraceableReason"  style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblUntraceableReason" runat="server"   SkinID="lblSkin" Text="Untraceable reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtUntraceableReason" runat="server"  Width="80%" SkinID="txtSkin" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlLocalityInfo" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityInfo" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblLocalityInfo" runat="server"  Text="Locality" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtLocalityInfo" runat="server"  SkinID="txtSkin" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlResultOfCalling" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResultOfCalling" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblResultOfCalling" runat="server"  Text="Result of calling" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtResultOfCalling" runat="server"  SkinID="txtSkin" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlMismatchInResAdd" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMismatchInResAdd" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblMismatchInResAdd" runat="server"  Text="Mismatched in resi add" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtMismatchInResAdd" runat="server"  MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlIsAppKnownToPerson" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsAppKnownToPerson" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsAppKnownToPerson" runat="server"  Text="Is app known to the person(Y/N)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtIsAppKnownToPerson" runat="server"  SkinID="txtSkin" MaxLength="1"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlToWhomAddBelong" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblToWhomAddBelong" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblToWhomAddBelong" runat="server"  Text="To whom does the add belong" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtToWhomAddBelong" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlVerificationContactAt" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVerificationContactAt" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblVerificationContactAt" runat="server"  Text="Verification conducted at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtVerificationContactAt" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAccomodation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAccomodation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblAccomodation" runat="server"  Text="Accomodation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtAccomodation" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
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
                        <asp:ListItem>Sofa</asp:ListItem>
                        <asp:ListItem>Clean</asp:ListItem>
                        <asp:ListItem>Painted</asp:ListItem>
                        <asp:ListItem>Carpeted</asp:ListItem>                 
                        <asp:ListItem>Venetian Blinds</asp:ListItem>
                        <asp:ListItem>Curtains</asp:ListItem>       
                        </asp:CheckBoxList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherInteriorConditions" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherInteriorConditions" runat="server"  MaxLength="100"></asp:TextBox>
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
                    <asp:TextBox ID="txtExterior" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTPCBy" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCBy" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblTPCBy" runat="server"  Text="TPC By" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtTPCBy" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNameTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblNameTPC2" runat="server"  Text="Name_TPC2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                  <asp:TextBox ID="txtNameTPC2" runat="server"  SkinID="txtSkin" MaxLength="500"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlStayTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblStayTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblStayTPC2" runat="server"  Text="Stay_TPC2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtStayTPC2" runat="server"  SkinID="txtSkin" MaxLength="500"></asp:TextBox>
                 </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlObservation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblObservation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblObservation" runat="server"  Text="Observation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtObservation" runat="server"  SkinID="txtSkin" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlWorkingChildren" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblWorkingChildren" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblWorking" runat="server"  Text="Working" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtWorking" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblChildren" runat="server"  Text="Children" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtChildren" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>    
           
           <!----add by kamal matekar required for femu------>
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
           
           
            <%--      //  Rupesh SCB //--%>
     
            <asp:Panel ID="PnlOfficersDecision" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table15" style="width:100%" runat="server">
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
            
             <asp:Panel ID="pnlNeighbourFeedback" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table16" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourFeedback" runat="server" Text="Any Other Feedback"></asp:Label>
                </td><td style="width:2%">:</td>
          
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbourFeedback" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                
                </tr>
               </table>
            </asp:Panel>
            
  
                  <asp:Panel ID="PnlVerification" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table14" style="width:100%" runat="server">
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
            
           <%-- Rupesh SCB--%>
           <asp:Panel ID="pnlNearnessArea" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table17" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNearnessArea" runat="server" Text="Nearness To Negative Area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNearnessArea" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
                                    <table id="Table18" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label14" runat="server" Text="Name Plate on Door"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNamePlateDoor" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
           
           <asp:Panel ID="pnlNeighbour2Add" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbour2Add" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbour2Add" runat="server" Text="Address Of Neighbour"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbour2Add" runat="server" MaxLength="500"></asp:TextBox>
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
                     <asp:TextBox SkinID="txtSkin"  ID="txtAdditionalComments" runat="server" TextMode="multiLine" Width="80%" MaxLength="500" ></asp:TextBox>
                     <%--<asp:TextBox SkinID="txtSkin"  ID="TextBox1" runat="server" TextMode="multiLine" Width="80%" MaxLength="250" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtAdditionalComments')" ></asp:TextBox>--%>
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
           
           <asp:Panel ID="pnlAverageMonthlyTurnover" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAverageMonthlyTurnover" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAverageMonthlyTurnover" runat="server" Text="(FOR SELF Employed) Average Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAverageMonthlyTurnover" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
        <asp:Panel ID="pnlVisibleNameBoard" runat="server" Width="100%" Visible="false">                
        <table cellpadding="0" cellspacing="0" border="0" id="tblVisibleNameBoard" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisibleNameBoard" runat="server" Text="Visibility of the name board"></asp:Label>
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
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="Table13" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label13" runat="server" Text="Nature of Business"></asp:Label>
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
                    <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNatureOfBusiness" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtNatureOfBusiness" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>
      
        <asp:Panel ID="pnlApplicantLivesWith" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantLivesWith" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApplicantLivesWith" runat="server" Text="Applicant Lives With"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantLivesWith" runat="server" AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Applicant</asp:ListItem>
                    <asp:ListItem>Family Member</asp:ListItem>
                    <asp:ListItem>Neighbor</asp:ListItem>
                    <asp:ListItem>Parents</asp:ListItem>
                    <asp:ListItem>Spouse</asp:ListItem>  
                    <asp:ListItem>Security</asp:ListItem> 
                    <asp:ListItem>Staff</asp:ListItem>
                    <asp:ListItem>Relatives</asp:ListItem>  
                    <asp:ListItem>Friends</asp:ListItem>
                    <asp:ListItem>Collegue</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicantLivesWithOthers" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtApplicantLivesWithOthers" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>
      
           <asp:Panel ID="pnlResidenceAddressUpdatedbyFE" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceAddressUpdatedbyFE" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResidenceAddressUpdatedbyFE" runat="server" Text="Residence Address/Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtResidenceAddressUpdatedbyFE" runat="server" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
               <asp:Panel ID="pnlAddressOfCompany" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressOfCompany" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddressOfCompany" runat="server" Text="Address Of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAddressOfCompany" runat="server" MaxLength="150"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
         <asp:Panel ID="pnlRelationshipWithBank" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationshipWithBank" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblRelationshipWithBank" runat="server" Text="Relationship With Bank"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtRelationshipWithBank" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlRoofType" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRoofType" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblRoofType" runat="server" Text="Roof Type"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtRoofType" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="pnlNumberOfRooms" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfRooms" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNumberOfRooms" runat="server" Text="Number Of Rooms"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfRooms" runat="server" MaxLength="15"></asp:TextBox>
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
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtFamilySeen" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <!--Added by Manoj for Axis bank Change address-->
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
                <table cellpadding="0" cellspacing="0" border="0" id="Table19" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label15" runat="server" Text="Applicant defaulted with"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtApplicantdefaulted" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
          <asp:Panel ID="Pnldateofdefault" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table20" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="Label16" runat="server"  Text="Date of Visit"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin" ID="txtdateofdefault" runat="server"></asp:TextBox>
             <img id="img4"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtdateofdefault.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            <asp:Label SkinID="lblSkin" ID="Label17" runat="server"  Text="Time of Visit"></asp:Label>
           <asp:TextBox SkinID="txtSkin" ID="txtTimeOfdefault" runat="server"></asp:TextBox> 
           </td>
           </tr>
           </table>
        </asp:Panel>
           
        <asp:Panel ID="Pnlapplicantresidelocation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabapplicantresidelocation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labapplicantresidelocation" runat="server"  Text="Does the applicant reside at the location of the address visited ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlapplicantresidelocation" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
          <asp:Panel ID="Pnladdressmatch" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabaddressmatch" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labaddressmatch" runat="server"  Text="Does this address match the resi. address provided by the Bank ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddladdressmatch" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="PnlSocityboard" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabSocityboard" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labSocityboard" runat="server"  Text="Does the society board feature the applicant's name?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlSocityboard" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
           <asp:Panel ID="PnlAddressvisited" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabAddressvisited" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="labAddressvisited" runat="server"  Text="Address visited ?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlAddressvisited" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="OTHER" Value="OTHER"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label19" runat="server" Text="If OTHER address, please specify the address ?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAddressvisted" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="PnlOtherAddressobtained" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tabOtherAddressobtained" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label18" runat="server" Text="How was this OTHER address obtained?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOtherAddressobtained" runat="server"  Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <!--Ended by Manoj for Axis bank Change address-->         
     
           
           
           <!-----end by kamal matekar------------>
                    <%-- start nikhil 04 sept 2013 SBI Change Address--%>
           
           <asp:Panel ID="pnlLocation" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLocation" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLocation" runat="server" Text="Location/City"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtLocation" runat="server"  Width="80%"></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlApplicantConfirmation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantConfirmation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblApplicantConfirmation" runat="server"  Text="Does the society board feature the applicant's name?" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlApplicantConfirmation" runat="server"   AutoPostBack="false">                
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>CONFIRMED</asp:ListItem>
                        <asp:ListItem>NO SUCH PERSON</asp:ListItem>
                        <asp:ListItem>NOT CONFIRMED</asp:ListItem>
                        <asp:ListItem>REFUSED DETAILS</asp:ListItem>
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
                    <asp:ListItem>STAYS ELSEWHERE/ SHIFTED</asp:ListItem>
                    <asp:ListItem>CORRESSPONDENCE ADDRESS</asp:ListItem>
                    <asp:ListItem>RARELY VISITS AT GIVEN ADDRESS</asp:ListItem>           
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
                    <asp:ListItem>STAYS ELSEWHERE/ SHIFTED</asp:ListItem>
                    <asp:ListItem>CORRESSPONDENCE ADDRESS</asp:ListItem>
                    <asp:ListItem>RARELY VISITS AT GIVEN ADDRESS</asp:ListItem>         
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel> 
         
          <asp:Panel ID="pnlSbiConfirmedStay" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSbiConfirmedStay" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSbiConfirmedStay" runat="server"  Text="Stay Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlSbiConfirmedStay" runat="server"   AutoPostBack="false">
                  <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>CONFIRMED</asp:ListItem>
                    <asp:ListItem>DOOR LOCKED</asp:ListItem> 
                    <asp:ListItem>REFUSED DETAILS/NOT CONFD</asp:ListItem>
                    <asp:ListItem>SHIFTED</asp:ListItem>
                    <asp:ListItem>DOESN'T STAY HERE</asp:ListItem>
                    <asp:ListItem>CORRESSPONDENCE ADDRESS</asp:ListItem>   
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel> 
         
         <asp:Panel ID="pnlWeekendVisit" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblWeekendVisit" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblWeekendVisit" runat="server"  Text="Weekend Visit" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlWeekendVisit" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
            <asp:Panel ID="PnlAreaname" runat="server" Width="100%" Visible="true">
               <table cellpadding="0" cellspacing="0" border="0" id="tabareaname" style="width:100%" runat="server">
                    <tr>
                        <td class="TDWidth">
                            <asp:Label SkinID="lblSkin" ID="labAreaname" runat="server" Text="Area Name"></asp:Label>
                        </td><td style="width:2%">:</td>
                        <td>
                             <asp:DropDownList SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false" ValidationGroup="grValidateDate">
                              </asp:DropDownList>
                              
                              <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                              <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />

               
                        </td>
                   </tr>            
               </table>
            </asp:Panel>
           
           <%--end nikhil 04 sept 2013 SBI Change Address--%> 
         <!--START FE DETAIL-->
         
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
           

    <table cellpadding="0" cellspacing="0" border="0" id="tblCaseStatus" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server"  Text="Case Status"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server"  DataSourceID="sdsCaseStatus"
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

    <table cellpadding="0" cellspacing="0" border="0" id="tblOutcome" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblOutcome" runat="server"  Text="Outcome"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin" ID="ddlOutcome"  runat="server"  DataSourceID="sdsOutcome"
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

    <table cellpadding="0" cellspacing="0" border="0" id="tblDeclineReason" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin"  ID="lblDeclineReason" runat="server"  Text="Decline Reason"></asp:Label>
    </td><td style="width:2%">:</td>
    <td >
        <asp:TextBox SkinID="txtSkin" ID="txtDeclineReason" runat="server" TextMode="MultiLine" Width="80%" MaxLength="500"></asp:TextBox>
    </td>
    </tr>
   </table>

<!--Start of ATTEMPT DETAIL-->

<table id="tblAttempt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >

<tr>
<td class="TDWidth" style="height: 14px">
<asp:Label SkinID="lblSkin" ID="lblLogin" runat="server" Text="Attempts"></asp:Label>
</td>
<td style="height: 14px" >
<asp:Label SkinID="lblSkin" ID="lblDate" runat="server" Text="Date [dd/MM/yyyy]"></asp:Label>
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
<%--<td style="height: 14px">
<asp:Label SkinID="lblSkin" ID="lblFeName" runat="server"  Text="Fe Name"></asp:Label>
</td>--%>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server"  Text="First Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate1" runat="server" ></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
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
    <asp:DropDownList ID="ddlSubSat1" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
    </asp:DropDownList>
    <asp:Label SkinID="lblSkin" ID="lblsat1" runat="server" Text=""></asp:Label>
    </td>
 <%--<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblsat1" runat="server"  Text=""></asp:Label>
</td>--%>
    <%--<td>
    <asp:DropDownList ID="ddlFE1" runat="server" OnDataBound="ddlFE_DataBound" DataSourceID="sdsFE" DataTextField="FULLNAME" DataValueField="FE_ID" SkinID="ddlSkin">
    </asp:DropDownList>
    </td>--%>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSecondAttempt" runat="server"  Text="Second Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate2" runat="server" ></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="5"   ID="txtAttemptTime2" Width="50" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType2" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAttemptRemark2" runat="server" ></asp:TextBox>
</td>
<td>
    <asp:DropDownList ID="ddlSubSat2" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
    </asp:DropDownList>
    <asp:Label SkinID="lblSkin" ID="lblsat2" runat="server" Text=""></asp:Label>
    </td>
   <%-- <td>
    <asp:DropDownList ID="ddlFE2" runat="server" OnDataBound="ddlFE_DataBound" DataSourceID="sdsFE" DataTextField="FULLNAME" DataValueField="FE_ID" SkinID="ddlSkin">
    </asp:DropDownList>
    </td>--%>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblThirdAttempt" runat="server"  Text="Third Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10" Width="100" ID="txtAttemptDate3" runat="server" ></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime3" Width="50" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType3" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAttemptRemark3" runat="server" ></asp:TextBox>
</td>
<td>
    <asp:DropDownList ID="ddlSubSat3" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
    </asp:DropDownList>
    <asp:Label SkinID="lblSkin" ID="lblsat3" runat="server" Text=""></asp:Label>
    </td>
    <%--<td>
    <asp:DropDownList ID="ddlFE3" runat="server" OnDataBound="ddlFE_DataBound" DataSourceID="sdsFE" DataTextField="FULLNAME" DataValueField="FE_ID" SkinID="ddlSkin">
    </asp:DropDownList>
    </td>--%>
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
</tr>
</table>
</asp:Panel>

<table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorName" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblSupervisorName" runat="server"  Text="Supervisor Name"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin"  ID="ddlSupervisorName" runat="server">
         </asp:DropDownList>
                     <strong> <asp:Label SkinID="lblSkin" ID="Label20" runat="server" ForeColor="red" Text="Supervisor Name is Mandatory"></asp:Label></strong> 
    </td>
    </tr>
   </table>   
<%--///////////////////add by santosh shelar increase lenth 255 to 700 ///23/08/08////////////////--%>            
<table id="tblSupervisorRemark"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSupervisorRemark" runat="server"  Text="Supervisor Remark"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   MaxLength="3000" ID="txtSupervisorRemark" TextMode="MultiLine" runat="server"  Width="80%"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
</td>
</tr>
</table>
<br />
<!--End of ATTEMPT DETAIL-->
         <!--END FE DETAIL-->
            <asp:Panel ID="pnlSubmit" runat="server"  Width="100%">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" runat="server"  Text="Submit" SkinID="btnSubmitSkin" ValidationGroup="grValidateDate" OnClick="btnSubmit_Click" />        
                <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hidCaseID" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
    
            <asp:HiddenField ID="hidMode" runat="server" />
           
            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
        </asp:Panel>
        
        
        <asp:CustomValidator ID="cvAttemptTime1" runat="server"  ControlToValidate="txtAttemptTime1"
             Display="None" ErrorMessage="Enter time in first attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime1"></asp:CustomValidator>
       <%--Modified By Gargi Srivastava 31-May-2007--%>   
       <%-- <asp:CustomValidator ID="cvAttemptRemark1" runat="server"  ClientValidationFunction="ValidateRemark1"
                ControlToValidate="txtAttemptRemark1" Display="None" ErrorMessage="Enter time in first attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>
                
        <asp:CustomValidator ID="cvAttemptTime2" runat="server"  ControlToValidate="txtAttemptTime2"
             Display="None" ErrorMessage="Enter time in second attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime2"></asp:CustomValidator>
       <%--Modified By Gargi Srivastava 31-May-2007--%>      
       <%--<asp:CustomValidator ID="cvAttemptRemark2" runat="server"  ClientValidationFunction="ValidateRemark2"
                ControlToValidate="txtAttemptRemark2" Display="None" ErrorMessage="Enter time in second attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>         
       <asp:CustomValidator ID="cvAttemptTime3" runat="server"  ControlToValidate="txtAttemptTime3"
                 Display="None" ErrorMessage="Enter time in third attempt." 
                 ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime3"></asp:CustomValidator>
       <%--Modified By Gargi Srivastava 31-May-2007--%>         
       <%--<asp:CustomValidator ID="cvAttemptRemark3" runat="server"  ClientValidationFunction="ValidateRemark3"
                    ControlToValidate="txtAttemptRemark3" Display="None" ErrorMessage="Enter time in third attempt."
                    ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>   
       <asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select case status." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus" OnServerValidate="cvSelectCaseStatus_ServerValidate">
       </asp:CustomValidator>         
       
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
    
                   
       <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server"  ControlToValidate="txtAttemptDate1"
                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server"  ControlToValidate="txtAttemptDate2"
                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate3" runat="server"  ControlToValidate="txtAttemptDate3"
                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime1" runat="server"  ControlToValidate="txtAttemptTime1"
                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server"  ControlToValidate="txtAttemptTime2"
                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revAttemptTime3" runat="server"  ControlToValidate="txtAttemptTime3"
                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>                    
        <asp:RegularExpressionValidator ID="revInitiationDate" runat="server"  ControlToValidate="txtInitiationDate"
                    Display="None" ErrorMessage="Please enter valid initiation date." SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtAttemptDate1"
            ClientValidationFunction="ValidateAttempts"  ValidationGroup="grValidateDate"  
            ErrorMessage="Enter atleast one Attempt." Display="None">
          </asp:CustomValidator> 
          
          
<%--added by sanket on 13/02/2014--%>         
        <asp:RequiredFieldValidator ID="rfvAreaname" runat="server"
             ErrorMessage="Please Select Area Name." ControlToValidate="ddlAreaname"
            InitialValue="0" Display="None" ValidationGroup="grValidateDate"  >
        </asp:RequiredFieldValidator>
<%--End by sanket--%>            
                  
         <asp:ValidationSummary ID="vsValidateDate" runat="server"   
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" /> 
        
        <asp:CompareValidator ID="valCurrYrs" runat="server" ControlToValidate="txtTimeCurrYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrMths" runat="server" ControlToValidate="txtTimeCurrMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator> 
        <asp:CompareValidator ID="valCurrYrsResi" runat="server" ControlToValidate="txtTimeCurrResYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr resi." Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTimeCurrResMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr resi." Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator> 
              
        <asp:CompareValidator ID="cmpValCurrMths" runat="server"  ControlToValidate="txtTimeCurrMths"  SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12 for Time at curr." Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
        <asp:CompareValidator ID="cmpValCurrMthsResi" runat="server"  ControlToValidate="txtTimeCurrResMths" SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12 for Time at curr resi." Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
              
         </asp:TableCell></asp:TableRow></asp:Table>
</td><td></td>
</tr>
<tr><td></td><td></td><td></td></tr>
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
    </tr>
    
    </table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
    <asp:HiddenField ID="hdnSupID" runat="server" />
    <asp:SqlDataSource ID="sdsFE" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
     <asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb"  
                          SelectCommand="sp_GetStatus" SelectCommandType="StoredProcedure">
                          
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                              <asp:SessionParameter Name="clientId" SessionField="ClientId" />
                              <asp:SessionParameter Name="Verification_code" SessionField="verification_code" />
                          </SelectParameters>
                     </asp:SqlDataSource>
</fieldset>
</td></tr></table>
</asp:Content>