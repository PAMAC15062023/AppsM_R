<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_ResidenceTelephonicVerification.aspx.cs" Inherits="CPV_RL_RL_ResidenceTelephonicVerification"  StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript">

 function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 254)
     {
       getControlsId.value = getControlsId.value.substring( 0, 254 );            
       return false;
     }          
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
                   
          if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length >0)
          {    
                   
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
       
       //2nd Telecalling 4213240310796740
       function ValidateTime2(source, arguments)
       { 
           
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



</script>
<fieldset> <legend class="FormHeading">RESIDENCE TELE VERIFICATION REPORT</legend>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">

<table id="Table1" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr></table>
<%--<tr><td></td><%--<td>
 <!--Start Heading-->
<asp:Panel ID="pnlResiVerTelHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblResidenceVerifiReport" runat="server" Text="RESIDENCE VERIFICATION REPORT"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>
 <!--END Heading-->--%>
<!--- Start of Personal Detail-->
<asp:Table ID="tblResiTelVeri" runat="server"  Width="100%">
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
    <asp:PlaceHolder ID="PlaceHolder78" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder79" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder80" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder81" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder82" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder83" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder84" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    </asp:TableCell>
</asp:TableRow>

<asp:TableRow ID="tblrow" runat="server" >
<asp:TableCell ID="tblCell" runat="server" >

<%--<asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label>--%>
<%--</asp:TableCell>
</asp:TableRow>
</asp:Table>--%>

<asp:Panel ID ="pnlDateRecieved" runat="server" Width="100%" Visible="false">
<table id="tblDateRecieved" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateRecieved" runat="server" Text="Date Recieved"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDateRecieved" runat="server"  ReadOnly="True"></asp:TextBox>
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
<asp:Panel ID ="pnlRefNo" runat="server" Width="100%" Visible="false">
<table id="tblRefNo"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRefNo" runat="server" Text="Ref No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRefNo" runat="server" ReadOnly="True" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID ="pnlArea" runat="server" Width="100%" Visible="false">
<table id="tblArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblArea" runat="server" Text="Area" >
</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtArea" runat="server" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<%--/////////add by santosh shelar change readonly item///////////////////////--%>
<asp:Panel ID ="pnlNameCoApp" runat="server" Width="100%" Visible="false">
<table id="tblNameCoApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameCoApp" runat="server" Text="Name of the co Applicant:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameCoApp" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlCoAppDob" runat="server" Width="100%" Visible="false">
<table id="tblCoAppDob" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCoAppDob" runat="server" Text="Age / DOB(2):"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="40%" ID="txtCoAppDob" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAddConf" runat="server" Width="100%" Visible="false">
<table id="tblAddConf" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAddConf" runat="server" Text="OK_PROCEED: /Address Confirmed:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlAddConf" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlNewHomeAddress" runat="server" Width="100%" Visible="false">
<table id="tblNewHomeAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNewHomeAddress" runat="server" Text="New House Address:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNewHomeAddress" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResiType" runat="server" Width="100%" Visible="false">
<table id="tblResiType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResiType" runat="server" Text="Type of Residence:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlResiType" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Flat" Value="Flat"></asp:ListItem>
        <asp:ListItem Text="House" Value="House"></asp:ListItem>            
        <asp:ListItem Text="Plot" Value="Plot"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTranType" runat="server" Width="100%" Visible="false">
<table id="tblTranType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTranType" runat="server" Text="TYPE OF TRANSACTION:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlTranType" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="PURCHASE" Value="PURCHASE"></asp:ListItem>
        <asp:ListItem Text="CONSTRUCT" Value="CONSTRUCT"></asp:ListItem>            
        <asp:ListItem Text="EXTEND" Value="EXTEND"></asp:ListItem>            
        <asp:ListItem Text="RENOVATE" Value="RENOVATE"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlApproxArea" runat="server" Width="100%" Visible="false">
<table id="tblApproxArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server" Text="APPROX BUILT UP AREA IN SQ YARD:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtApproxArea" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlTotalCost" runat="server" Width="100%" Visible="false">
<table id="tblTotalCost" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTotalCost" runat="server" Text="TOTAL COST : Rs"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtTotalCost" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlLoanAmt" runat="server" Width="100%" Visible="false">
<table id="tblLoanAmt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblLoanAmt" runat="server" Text="Loan Amt Required Rs.:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLoanAmt" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPropBought" runat="server" Width="100%" Visible="false">
<table id="tblPropBought" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblPropBought" runat="server" Text="Property to be bought for:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlPropBought" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Self" Value="Self"></asp:ListItem>
        <asp:ListItem Text="Parents" Value="Parents"></asp:ListItem>            
        <asp:ListItem Text="Children" Value="Children"></asp:ListItem>            
        <asp:ListItem Text="Employee" Value="Employee"></asp:ListItem>            
        <asp:ListItem Text="Rent" Value="Rent"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRelantionProp" runat="server" Width="100%" Visible="false">
<table id="tblRelantionProp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelantionProp" runat="server" Text="Relationship, If any with builder / Seller from whom property is being purchased:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlRelantionProp" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlOtherProp" runat="server" Width="100%" Visible="false">
<table id="tblOtherProp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblOtherProp" runat="server" Text="Any other property owned by Applicant:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOtherProp" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlNameGuran1" runat="server" Width="100%" Visible="false">
<table id="tblNameGuran1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameGuran1" runat="server" Text="Name of Guarantor1/Mother Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameGuran1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlContactR1" runat="server" Width="100%" Visible="false">
<table id="tblContactR1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactR1" runat="server" Text="Contact No(R)1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtContactR1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlContactO1" runat="server" Width="100%" Visible="false">
<table id="tblContactO1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactO1" runat="server" Text="Contact No(O)1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtContactO1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlPersonCont1" runat="server" Width="100%" Visible="false">
<table id="tblPersonCont1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblPersonCont1" runat="server" Text="Person Contacted1"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPersonCont1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRelanApp1" runat="server" Width="100%" Visible="false">
<table id="tblRelanApp1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelanApp1" runat="server" Text="Relation with Applicant1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelanApp1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRelationship1" runat="server" Width="100%" Visible="false">
<table id="tblRelationship1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelationship1" runat="server" Text="Relationship1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationship1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAddGurent1" runat="server" Width="100%" Visible="false">
<table id="tblAddGurent1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAddGurent1" runat="server" Text="Address of Guarantor,Office / POA1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddGurent1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlhowLong1" runat="server" Width="100%" Visible="false">
<table id="tblhowLong1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblhowLong1" runat="server" Text="Since how long you know the applicant1"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txthowLong1" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReadyGua1" runat="server" Width="100%" Visible="false">
<table id="tblReadyGua1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblReadyGua1" runat="server" Text="Are you ready to be Guarantor/POA/referee1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlReadyGua1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBeenGua1" runat="server" Width="100%" Visible="false">
<table id="tblBeenGua1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblBeenGua1" runat="server" Text="Have you been Guarantor for anybody else1:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlBeenGua1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlStatus1" runat="server" Width="100%" Visible="false">
<table id="tblStatus1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblStatus1" runat="server" Text="Status1"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlStatus1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Recommended" Value="Recommended"></asp:ListItem>
        <asp:ListItem Text="Not Recommended" Value="Not Recommended"></asp:ListItem>            
        <asp:ListItem Text="Referred" Value="Referred"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlNameGuran2" runat="server" Width="100%" Visible="false">
<table id="tblNameGuran2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameGuran2" runat="server" Text="Name of Guarantor2/Father Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameGuran2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlContactR2" runat="server" Width="100%" Visible="false">
<table id="tblContactR2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactR2" runat="server" Text="Contact No(R)2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtContactR2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlContactO2" runat="server" Width="100%" Visible="false">
<table id="tblContactO2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactO2" runat="server" Text="Contact No(O)2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtContactO2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlPersonCont2" runat="server" Width="100%" Visible="false">
<table id="tblPersonCont2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblPersonCont2" runat="server" Text="Person Contacted2"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPersonCont2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRelanApp2" runat="server" Width="100%" Visible="false">
<table id="tblRelanApp2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelanApp2" runat="server" Text="Relation with Applicant2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelanApp2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRelationship2" runat="server" Width="100%" Visible="false">
<table id="tblRelationship2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelationship2" runat="server" Text="Relationship2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationship2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAddGurent2" runat="server" Width="100%" Visible="false">
<table id="tblAddGurent2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAddGurent2" runat="server" Text="Address of Guarantor / POA2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddGurent2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlhowLong2" runat="server" Width="100%" Visible="false">
<table id="tblhowLong2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblhowLong2" runat="server" Text="Since how long you know the applicant2"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" ID="txthowLong2" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDOBApp" runat="server" Width="100%" Visible="false">
        <table id="tblDOBApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblDOBApp" runat="server" Text="Date of Birth of applicant"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
        <asp:TextBox SkinID="txtSkin" ID="txtDOBApp" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
        </table>
</asp:Panel>

<asp:Panel ID="pnlReadyGua2" runat="server" Width="100%" Visible="false">
<table id="tblReadyGua2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblReadyGua2" runat="server" Text="Are you ready to be Guarantor/POA/referee2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlReadyGua2" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBeenGua2" runat="server" Width="100%" Visible="false">
<table id="tblBeenGua2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblBeenGua2" runat="server" Text="Have you been Guarantor for anybody else2:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlBeenGua2" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlStatus2" runat="server" Width="100%" Visible="false">
<table id="tblStatus2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblStatus2" runat="server" Text="Status2"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
    <asp:DropDownList ID="ddlStatus2" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Recommended" Value="Recommended"></asp:ListItem>
        <asp:ListItem Text="Not Recommended" Value="Not Recommended"></asp:ListItem>            
        <asp:ListItem Text="Referred" Value="Referred"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<%--*************************************************************************************************--%>

<asp:Panel ID ="pnlNameoftheApplicant" runat="server" Width="100%" Visible="false">
<table id="tblNameoftheApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameoftheApplicant" runat="server" Text="Name of the Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtNameoftheApplicant" runat="server" ReadOnly="False"  ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<%---------------------------- Added By RupeshStart  On 18-March-2013 ------------------------------%>

<asp:Panel ID="PnlStatus" runat="server" Width="100%" Visible="false">
<table id="tblstatus" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblstatus" runat="server" Text="Status"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlstatus" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
        <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
        <asp:ListItem Text="Incomplete" Value="Incomplete"></asp:ListItem>  <%--New added/Updated for CHOLA--%>
        <asp:ListItem Text="Waived" Value="Waived"></asp:ListItem>     
                 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="PnlReason" runat="server" Width="100%" Visible="false">
<table id="tblReason" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblReason" runat="server" Text="Reason"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlReason" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
     <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
        <asp:ListItem Text="REF. NOT ANSWERING" Value="REF. NOT ANSWERING"></asp:ListItem>
        <asp:ListItem Text="REF. NO. DISCONNECTED" Value="REF. NO. DISCONNECTED"></asp:ListItem>
        <asp:ListItem Text="REF. CLAIMS HE DOESNT KNOW THE CM" Value="REF. CLAIMS HE DOESNT KNOW THE CM"></asp:ListItem>
        <asp:ListItem Text="REF NO. SWITCHED OFF" Value="REF NO. SWITCHED OFF"></asp:ListItem>
        <asp:ListItem Text="REF REFUSES TO GIVE INFO" Value="REF REFUSES TO GIVE INFO"></asp:ListItem> 
        <asp:ListItem Text="CUSTOMER OUTSIDE THE COUNTRY" Value="CUSTOMER OUTSIDE THE COUNTRY"></asp:ListItem>     
                 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlpersoncontactedRl" runat="server" Width="100%" Visible="false">
<table id="tblpersnontacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblprsoncotacted" runat="server" Text="Person Contacted"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlpersoncontactedRL" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
        <asp:ListItem Text="Reference" Value="Reference"></asp:ListItem>
        <asp:ListItem Text="Wife" Value="Wife"></asp:ListItem>     
        <asp:ListItem Text="Children" Value="Children"></asp:ListItem>
        <asp:ListItem Text="Himself" Value="Himself"></asp:ListItem> 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="PnlResponse" runat="server" Width="100%" Visible="false">
<table id="tblResponse" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResponse" runat="server" Text="Response"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlResponse" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
   <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Unanswered" Value="Unanswered"></asp:ListItem>
        <asp:ListItem Text="Busy" Value="Busy"></asp:ListItem>
       <asp:ListItem Text="Call Back" Value="Call Back"></asp:ListItem>     
        <asp:ListItem Text="Disconnected" Value="Disconnected"></asp:ListItem>
        <asp:ListItem Text="Answered & Provided Full Information" Value="Answered & Provided Full Information"></asp:ListItem>
        <asp:ListItem Text="Waived" Value="Waived"></asp:ListItem>
        <asp:ListItem Text="Answered & Provided No Information" Value="Answered & Provided No Information"></asp:ListItem> 
         <asp:ListItem Text="Answered & Provided Partial Information" Value="Answered & Provided Partial Information"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="PnlResvertyp" runat="server" Width="100%" Visible="false">
<table id="tblResvertyp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResvertyp" runat="server" Text="Residence Verification Type"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlResvertyp" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
      <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="HOME COUNTRY CPV" Value="HOME COUNTRY CPV"></asp:ListItem>
        <asp:ListItem Text="RESIDENCE CPV" Value="RESIDENCE CPV"></asp:ListItem>
        <asp:ListItem Text="REFERENCE CPV" Value="REFERENCE CPV"></asp:ListItem>     
                 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="PnlAgency" runat="server" Width="100%" Visible="false">
<table id="tblAgency" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAgency" runat="server" Text="Agency"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlAgency" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
      <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Agency ONE" Value="Agency ONE"></asp:ListItem>
        <asp:ListItem Text="Agency TWO" Value="Agency TWO"></asp:ListItem>
       
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<%------------------------------Added By RupeshEnd  On 18-March-2013 ---------------------------------%>






<asp:Panel ID="pnlResidentPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblResidentPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidentPhoneNo" runat="server" Text="Resident Phone No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtResidentPhoneNo" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlResidenceAddressasperApplication" runat="server" Width="100%" Visible="false">
<table id="tblResidenceAddressasperApplication" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidenceAddressasperApplication" runat="server" Text="Residence Address as per Application"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtResidenceAddressasperApplication" runat="server" ReadOnly="true" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--////////// add new code by santosh for Guarantor 14/10/2010///////////////--%>
<asp:Panel ID="pnlRefName" runat="server" Width="100%" Visible="false">
<table id="tblRefName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRefName" runat="server" Text="Reference Name / Verified By"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtRefName" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRefTel" runat="server" Width="100%" Visible="false">
<table id="tblRefTel" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRefTel" runat="server" Text="Reference2 Telephone No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtRefTel" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRelRef" runat="server" Width="100%" Visible="false">
<table id="tblRelRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblRelRef" runat="server" Text="Reference2 Relantionship with Guarantor"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtRelRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlKnowGua" runat="server" Width="100%" Visible="false">
<table id="tblKnowGua" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblKnowGua" runat="server" Text="B) How many years they know Guarantor"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtKnowGua" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlKnowRef" runat="server" Width="100%" Visible="false">
<table id="tblKnowRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblKnowRef" runat="server" Text="B) How many years they know Guarantor(Ref2)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtKnowRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmpDetGua" runat="server" Width="100%" Visible="false">
<table id="tblEmpDetGua" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmpDetGua" runat="server" Text="Employment Details(Guarantor)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtEmpDetGua" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmpDetRef" runat="server" Width="100%" Visible="false">
<table id="tblEmpDetRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmpDetRef" runat="server" Text="Employment Details(Ref2)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtEmpDetRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOthLoanGua" runat="server" Width="100%" Visible="false">
<table id="tblOthLoanGua" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblOthLoanGua" runat="server" Text="D) Whether he is guarantor for any other loan(Gua)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtOthLoanGua" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOthLoanRef" runat="server" Width="100%" Visible="false">
<table id="tblOthLoanRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblOthLoanRef" runat="server" Text="D) Whether he is guarantor for any other loan(Ref2)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtOthLoanRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlLibGua" runat="server" Width="100%" Visible="false">
<table id="tblLibGua" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblLibGua" runat="server" Text="E) Whether he is aware of his liability as guarantor(Gua)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtLibGua" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlLibRef" runat="server" Width="100%" Visible="false">
<table id="tblLibRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblLibRef" runat="server" Text="E) Whether he is aware of his liability as guarantor(Ref2)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtLibRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmiGua" runat="server" Width="100%" Visible="false">
<table id="tblEmiGua" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmiGua" runat="server" Text="F) Whether Guarantor is aware of Guarantors loan quantum /EMI(Gua)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtEmiGua" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmiRef" runat="server" Width="100%" Visible="false">
<table id="tblEmiRef" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEmiRef" runat="server" Text="F) Whether Guarantor is aware of Guarantors loan quantum /EMI(Ref2)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtEmiRef" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<%--///////////////////End Code////////////////////////////--%>

<%--////////add by santosh shelar new code////////////////--%>
<asp:Panel ID="pnlCPVScore" runat="server" Width="100%" Visible="false">
<table id="tblCPVScore" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCpvScore" runat="server" Text="CPV Score"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtCpvScore" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNatureofBusiness" runat="server" Width="100%" Visible="false">
<table id="tblNatureofBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNatureofBusiness" runat="server" Text="Nature of Business"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNatureofBusiness" runat="server" MaxLength="200"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlCalleduponResiTel" runat="server" Width="100%" Visible="false">
<table id="tblCallup" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCallup" runat="server" Text="Called up on Resi Tel. No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCallup" runat="server" MaxLength="200"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDept" runat="server" Width="100%" Visible="false">
<table id="tblDept" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDept" runat="server" Text="Dept."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDept" runat="server" MaxLength="200"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBusinessContactNo" runat="server" Width="100%" Visible="false">
<table id="tblBusinessContactNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblBusinessContactNo" runat="server" Text="Business Contact No. & Extn. (If Any)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtBusinessContactNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblNameOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfPersonContacted" runat="server" Text="Name Of Person Contacted"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%"  ID="txtNameOfPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlIfOtherPersonNameContacted" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblIfOtherPersonNameContacted" runat="server" Text="IF SOMEONE OTHER THAN THEN APPLICANT IS CONTACTED"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTimeCurrentEmployment" runat="server" Width="100%" Visible="false">
<table id="tblTimeCurrentEmployment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmployment" runat="server" Text="Work Since"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeCurrentEmploymentYrs" runat="server"  MaxLength="2"></asp:TextBox>

<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmploymentYrs" runat="server" Text="Yrs"></asp:Label>
</td>            
<%--<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeCurrentEmploymentMths" runat="server"  MaxLength="2"></asp:TextBox>
<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmploymentMths" runat="server" Text="Mths."></asp:Label>
</td>--%>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="false">
<table id="tblDesignation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDesignation" runat="server" MaxLength="100"></asp:TextBox>
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
<asp:TextBox SkinID="txtSkin" Width="60%"  ID="txtNameOfCompany" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOfficePhoneNoExtn" runat="server" Width="100%" Visible="false">
<table id="tblOfficePhoneNoExtn" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOfficePhoneNoExtn" runat="server" Text="Office Phone No & Extn"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtOfficePhoneNoExtn" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDetails" runat="server" Width="100%" Visible="false">
<table id="tblDetails" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDetails" runat="server" Text="Employment Details"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtDetails" runat="server" MaxLength="500"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlContactedNo" runat="server" Width="100%" Visible="false">
<table id="tblContactedNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblContactedNo" runat="server" Text="Contacted No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtContactedNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAgencyCode" runat="server" Width="100%" Visible="false">
<table id="tblAgencyCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAgencyCode" runat="server" Text="Agency Code" >
</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAgencyCode" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--////////Add by santosh shelar change read only item//////////////--%>
<asp:Panel ID ="pnlInitiationDate" runat="server" Width="100%" Visible="false">
<table id="tblInitiationDate" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInitiationDate" runat="server" Text="Date of Initiation/Counter Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtInitiationDate" runat="server" MaxLength="10"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<%--Naresh Start 13/06/08 Start--%>
<asp:Panel ID="pnlResiIs" runat="server" Width="100%" Visible="false">
<table id="tblResiIs" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResiIs" runat="server" Text="Residence is"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlResiIs" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
<asp:ListItem Text="Own" Value="Own"></asp:ListItem>
<asp:ListItem Text="Co.Provided" Value="Co.Provided"></asp:ListItem>
<asp:ListItem Text="Paying guest" Value="Paying guest"></asp:ListItem>
<asp:ListItem Text="Bachelor acco" Value="Bachelor acco"></asp:ListItem>
<asp:ListItem Text="Family/Ancestral" Value="Family/Ancestral"></asp:ListItem>
<asp:ListItem Text="Company accomodation" Value="Company accomodation"></asp:ListItem>
<asp:ListItem Text="With Parents" Value="With Parents"></asp:ListItem>
<asp:ListItem Text="With Relatives" Value="With Relatives"></asp:ListItem>
<asp:ListItem Text="With Friends" Value="With Friends"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPPNo" runat="server" Width="100%" Visible="false">
<table id="tblPPNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblPPNo" runat="server" Text="PP.No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td style="height: 24px" >
<asp:TextBox SkinID="txtSkin"   ID="txtPPNo" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlStaying" runat="server" Width="100%" Visible="false">
<table id="tblStaying" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblStaying" runat="server" Text="Staying With"></asp:Label>
</td>
<td style="width:2%">:</td>
<td style="height: 24px" >
<asp:TextBox SkinID="txtSkin"   ID="txtStaying" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAnyotherResiPhoneNo" runat="server" Width="100%" Visible="false">
<table id="Table2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAnyotherResiPhoneNo" runat="server" Text="Any other Resi. Phone No./Mobile"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAnyotherResiPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAppAvailable" runat="server" Width="100%" Visible="false">
<table id="tblAppAvailable"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAppAvailable" runat="server" Text="Applicant is usually available at"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAppAvailable" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
<table id="tblDirectoryCheck" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDirectoryCheck" runat="server" Text="Directory Check"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDirectoryCheck" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNameofApplicantConfirmedatgivenPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblNameofApplicantConfirmedatgivenPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameofApplicantConfirmedatgivenPhoneNo" runat="server" Text="Answered: /Name of Applicant confirmed at given Phone No."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlNameofApplicantConfirmedatgivenPhoneNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlMismatchedInAddTelNo" runat="server" Width="100%" Visible="false">
<table id="tblMismatchedInAddTelNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMismatchedInAddTelNo" runat="server" Text="Mismatched In Add.&Tel.No"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlMismatchedInAddTelNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employer Ph.No." Value="Employer Ph.No."></asp:ListItem>               
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
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

<%--Naresh Start 13/06/08 End --%>

<asp:Panel ID="pnlPersonContactedatResidencetelephoneConfirms" runat="server" Width="100%" Visible="false">
<table id="tblPersonContactedatResidencetelephoneConfirms" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPersonContactedatResidencetelephoneConfirms" runat="server" Text="Person Contacted at Residence telephone Confirms that the applicant stays at given Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlPersonContactedatResidencetelephoneConfirms" runat="server"  AutoPostBack="false" SkinID="ddlSkin">    
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPersonContacted" runat="server" Text="Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlRelationshipwithApplicant" runat="server" Width="100%" Visible="false">
<table id="tblRelationshipwithApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRelationshipwithApplicant" runat="server" Text="Relationship with Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtRelationshipwithApplicant" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlResidenceAddressasperCall" runat="server" Width="100%" Visible="false">
<table id="tblResidenceAddressasperCall" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidenceAddressasperCall" runat="server" Text="Residence Address as per Call"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtResidenceAddressasperCall" runat="server" MaxLength="255" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNumberofYearsatResidence" runat="server" Width="100%" Visible="false">
<table id="tblNumberofYearsatResidence" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNumberofYearsatResidence" runat="server" Text="Number of Years at Residence"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNumberofYearsatResidence" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNameOftheEmployer" runat="server" Width="100%" Visible="false">
<table id="tblNameOftheEmployer" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOftheEmployer" runat="server" Text="Name Of the Employer"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNameOftheEmployer" runat="server" ReadOnly="true" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="false">
<table id="tblPermanentAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtPermanentAddress" runat="server" MaxLength="500" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--Add new code as per requirement 16/07/2011--%>
<asp:Panel ID="pnlRegion" runat="server" Width="100%" Visible="false">
<table id="tblRegion" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRegion" runat="server" Text="Region / Pincode"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtRegion" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEarningMembers" runat="server" Width="100%" Visible="false">
<table id="Table3" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblEarningMembers" runat="server" Text="Earning Members"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtEarningMembers" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDependents" runat="server" Width="100%" Visible="false">
<table id="Table4" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Dependents"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtDependents" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlSpouseWorking" runat="server" Width="100%" Visible="false">
<table id="Table5" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Details of spouse if working"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtSpouseWorking" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlParenteDetails" runat="server" Width="100%" Visible="false">
<table id="Table6" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="Details of Parents in case retired"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtParenteDetails" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReasonDecline" runat="server" Width="100%" Visible="false">
<table id="Table7" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="Label5" runat="server" Text="Reason for Decline / Refer"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtReasonDecline" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<%--end code--%>
<asp:Panel ID="pnlOverallRemarks" runat="server" Width="100%" Visible="false">
<table id="tblOverallRemarks" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOverallRemarks" runat="server" Text="Overall Remarks"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtOverallRemarks" Width="60%" runat="server" TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd('ctl00_C1_OverallRemarks')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOverallRemarks');"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<%--<asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="true">
<table id="tblRating" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRating" runat="server" Text="Rating"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlRating" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>--%>


<%--Changed for SBI--%>
<asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
<table id="tblRating" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
</td>
<td style="width:2%">:</td>
<td >

</td>
</tr>
</table>
</asp:Panel>

<asp:Label SkinID="lblSkin"  ID="Label8" runat="server" Text="Rating" Width="100"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

: &nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlRating" runat="server"   SkinID="ddlSkin">
</asp:DropDownList>

<%--END for SBI--%>


<asp:Panel ID="pnlProvidereasonforunsatisfactoryrating" runat="server" Width="100%" Visible="false">
<table id="tblProvidereasonforunsatisfactoryrating" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblProvidereasonforunsatisfactoryrating" runat="server" Text="Please provide reason for unsatisfactory rating "></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtProvidereasonforunsatisfactoryrating" runat="server" MaxLength="255" Width="60%"></asp:TextBox>

</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlStayingSince" runat="server" Width="100%" Visible="false">
<table id="tblStayingSince" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblStayingSince" runat="server" Text="Staying Since"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtStayingSince" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlTeleCallersName" runat="server" Width="100%" Visible="true">
<table id="tblTeleCallersName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTeleCallersName" runat="server" Text="Tele Caller's Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlTeleCallersName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">

</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<!--END Personal Detail-->

<!--Start of TeleLog Head-->
<asp:Panel ID="pnlTelecallLogResi" runat="server" Width="100%" Visible="True">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblTelecallLog" runat="server" Text="TELECALL LOG"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End of TeleLog Head-->
<!--Start of TeleLog-->

<asp:Panel ID="pnlLoginResi" runat="server" Width="100%" Visible="true">
<table id="tblLogin" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLogin" runat="server" Text="Login"></asp:Label>
</td>
 <td>
<asp:Label SkinID="lblSkin"   ID="lblDate" runat="server" Text="Date [dd/mm/yyyy]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTime" runat="server" Text="Time [hh:mm]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTelNo" runat="server" Text="Tel No."></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblRemark" runat="server" Text="Remark"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl1stCall" runat="server" Text="1st call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate1stCall" runat="server"></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1stCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime1stCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime1stCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo1stCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks1stCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
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
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl2ndCall" runat="server" Text="2nd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate2ndCall" runat="server"></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2ndCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime2ndCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime2ndCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo2ndCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks2ndCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
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
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl3rdCall" runat="server" Text="3rd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate3rdCall" runat="server"></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3rdCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime3rdCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime3rdCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo3rdCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks3rdCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
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
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl4thCall" runat="server" Text="4th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate4thCall" runat="server"></asp:TextBox>
    <img id="ImgDate4thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate4thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime4thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime4thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo4thCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks4thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
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
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl5thCall" runat="server" Text="5th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate5thCall" runat="server"></asp:TextBox>
    <img id="ImgDate5thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate5thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime5thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime5thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo5thCall" runat="server"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks5thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
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
<table id="tblNewInfoObt"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNewInfoObt" runat="server" Text="New Info Obtained (TCRemarks)"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNewInfoObt" runat="server" Width="80%" MaxLength="500"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
</td>
</tr>
</table>
</asp:Panel><br />
<!--Added by Manoj...for YesbankautoLoan-->
<asp:Panel ID="PnlLoanApplied" runat="server" Width="100%" Visible="false">
<table id="Table8" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="Label6" runat="server" Text="Loan Applied:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlLoanapplied" runat="server"  AutoPostBack="false" SkinID="ddlSkin">    
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="PnlTVRdone" runat="server" Width="100%" Visible="false">
<table id="Table9" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="Label7" runat="server" Text="No of which TVR Done:"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtTvrdone" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--End of TeleLog-->
<asp:Panel ID="pnlDateOfVerification" runat="server" Width="100%" Visible="false">
<table id="tblDateOfVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateOfVerification" runat="server" Text="Date Of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfVerification" runat="server" MaxLength="10"></asp:TextBox>
<img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
 <td><asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" Text="Time Of Verification"></asp:Label></td>
<td>:</td>
<td><asp:TextBox id="txtVerificationTime" runat="server" SkinID="txtSkin" MaxLength="5" Columns="8"></asp:TextBox>
<asp:DropDownList id="ddlVerificationTimeType" runat="server" SkinID="ddlSkin">
<asp:ListItem>AM</asp:ListItem>
<asp:ListItem>PM</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

      <%--New added/Updated for CHOLA--%>
      
<asp:Panel ID="pnlApplicationDate" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="Table15" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicationDate" runat="server" Text="Date of Application"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  MaxLength="10" ID="txtApplicationDate" runat="server" ></asp:TextBox> 
                       <img id="Img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtApplicationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
           </tr>            
       </table>
   </asp:Panel>      
      
<asp:Panel ID="pnlIfRented" runat="server" Width="100%" Visible="false">
    <table id="Table13" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="IfRented" runat="server" Text="Rent Amount (If rented)"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
            <asp:TextBox SkinID="txtSkin" ID="txtRentAmount" runat="server" Width="60%"></asp:TextBox>
        </td>
        </tr>
    </table>
</asp:Panel>
      
<asp:Panel ID="pnlLessthan1" runat="server" Width="100%" Visible="false">
    <table id="Table10" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblLessthan1" runat="server" Text="If the applicant is residing in the present address for less than 1yr,pls. specify the previous address details"></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
            <asp:TextBox SkinID="txtSkin" ID="txtLessthan1" runat="server" Width="80%" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlAddressDifferent" runat="server" Width="100%" Visible="false">
    <table id="tblAddressDifferent" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddressDifferent" runat="server" Text="Address Different"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:DropDownList ID="ddlAddressDifferent" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlAddrDiffConf" runat="server" Width="100%" Visible="false">
    <table id="Table18" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAddrDiffConf" runat="server" Text="If No, Specify Confirm Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddrDiffConf" runat="server" ></asp:TextBox> 
            </td>
        </tr>
    </table>
</asp:Panel> 

<asp:Panel ID="pnlRef1Comments" runat="server" Width="100%" Visible="false">
    <table id="Table16" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRef1Comments" runat="server" Text="Reference1 Comments"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtRef1Comments" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<%--CHANGE REference name in main application--%>

<asp:Panel ID="pnlRef2Name" runat="server" Width="100%" Visible="false">
    <table id="Table11" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRef2Name" runat="server" Text="Reference2 Name / Verified By"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtRef2Name" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlRef2Telephone" runat="server" Width="100%" Visible="false">
    <table id="Table12" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblRef2Telephone" runat="server" Text="Reference2 Telephone No."></asp:Label>
        </td>
        <td style="width:2%">:</td>
        <td >
            <asp:TextBox SkinID="txtSkin" ID="txtRef2Telephone" runat="server" Width="60%"></asp:TextBox>
        </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlRef2Relantionship" runat="server" Width="100%" Visible="false">
    <table id="Table14" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRef2Relantionship" runat="server" Text="Reference2 Relantionship with Guarantor"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtRef2Relantionship" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlRef2Comments" runat="server" Width="100%" Visible="false">
    <table id="Table17" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRefComments" runat="server" Text="Reference2 Comments"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtRef2Comments" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlTelephoneExist" runat="server" Width="100%" Visible="false">
    <table id="Table19" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTelephoneExist" runat="server" Text="Telephone No. Exists"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:DropDownList ID="ddlTelephoneExist" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlTeleWhoseName" runat="server" Width="100%" Visible="false">
    <table id="Table20" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTeleWhoseName" runat="server" Text="Telephone on whose name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtTeleWhoseName" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlAdderssCDROM" runat="server" Width="100%" Visible="false">
    <table id="Table21" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAdderssCDROM" runat="server" Text="Adderss as per CD-ROM"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAdderssCDROM" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlddlDedupe" runat="server" Width="100%" Visible="false">
    <table id="Table22" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDedupe" runat="server" Text="Dedupe Check"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:DropDownList ID="ddlDedupe" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>Positive</asp:ListItem>
                            <asp:ListItem>Negative</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlCustomerCIFL" runat="server" Width="100%" Visible="false">
    <table id="Table23" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
        <tr>
            <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCustomerCIFL" runat="server" Text="Existing Customer of CIFL"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:DropDownList ID="ddlCustomerCIFL" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>

      <%--End--%>  

<asp:Panel ID="pnlSubmit" runat="server" Width="100%"  Visible="True">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpAttempts" SkinID="btnSubmitSkin" Text="Submit"  OnClick="btnSubmit_Click" />       
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel"  OnClick="btnCancel_Click" />
        </td>
      </tr>
    </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
     <asp:HiddenField ID="hidMode" runat="server" />
     <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
    
    </asp:Panel>
 
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
    
<%-- <asp:CustomValidator ID="cv1stTelCall" runat="server" ClientValidationFunction="ValidateTime1"
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
    
   </asp:TableCell></asp:TableRow></asp:Table>
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
      
       <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtDateOfVerification"
                    Display="None" ErrorMessage="Please enter valid date format for verification."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="revVerificationTime" runat="server" ControlToValidate="txtVerificationTime"
                    Display="None" ErrorMessage="Please enter valid time format for verification."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grpAttempts">  </asp:RegularExpressionValidator>
    
   
 <asp:ValidationSummary ID="vsAttempt" runat="server" ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />
    &nbsp;
    <asp:Label ID="Label1" runat="server"></asp:Label>
  <asp:HiddenField ID="hdnTransStart" runat="server" /></td>
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
</asp:Content>




