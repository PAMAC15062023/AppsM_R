<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_MobileVerification.aspx.cs" Inherits="CPV_CC_CC_MobileVerification" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript">
       
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
   </script>
    <fieldset>
        <legend class="FormHeading" style="width: 214px">MOBILE TELE VERIFICATION </legend>
        <table id="tblMain" runat="server" cellpadding="0" cellspacing="0" style="background-color: #e7f6ff"
            width="100%">
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
                    <!--Start Heading-->
                    <asp:Panel ID="pnlBusVerTelHead" runat="server" Visible="false" Width="100%">
                        <table>
                            <tr>
                                <td align="center" class="txtBold" style="width: 5%; height: 16px; background-color: #d0d5d8">
                                    <asp:Label ID="lblmobileVerifiReport" runat="server" SkinID="lblSkin" Text="MOBILE TELE VERIFICATION " Width="170px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <!--END Heading-->
                    <!--- Start of Personal Detail-->
                    <asp:Table ID="tblBusinessTelVeri" runat="server" Width="97%" Height="529px">
                        <asp:TableRow ID="tblrowPlace" runat="server">
                            <asp:TableCell ID="tblCellPlace" runat="server">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder2" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder3" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder4" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder5" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder6" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder7" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder8" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder9" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder10" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder11" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder12" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder13" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder14" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder15" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder16" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder17" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder18" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder19" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder20" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder21" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder22" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder23" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder24" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder25" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder26" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder27" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder28" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder29" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder30" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder31" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder32" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder33" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder34" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder35" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder36" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder37" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder38" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder39" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder40" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder41" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder42" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder43" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder44" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder45" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder46" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder47" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder48" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder49" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder50" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder51" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder52" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder53" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder54" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder55" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder56" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder57" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder58" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder59" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder60" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder61" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder62" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder63" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder64" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder65" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder66" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder67" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder68" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder69" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder70" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder71" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder72" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder73" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder74" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder75" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder76" runat="server" EnableViewState="False"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder77" runat="server" EnableViewState="False"></asp:PlaceHolder>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblrow" runat="server">
                            <asp:TableCell ID="tblCell" runat="server">
                                <asp:Panel ID="pnlAppName" runat="server" Width="100%">
                                    <table id="tblAppName" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr runat="server">
                                            <td class="TDWidth" runat="server">
                                                <asp:Label ID="lblAppName" runat="server" SkinID="lblSkin" Text="Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
                                            </td>
                                            <td style="width: 2%" runat="server">
                                                :</td>
                                                
                                            <td runat="server">
                                                <asp:TextBox ID="txtAppName" runat="server" MaxLength="150" ReadOnly="True" SkinID="txtSkin"
                                                    Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>                                  
                                   </asp:Panel>
                                   
                                   
                                <asp:Panel ID="PnlContact" runat="server" Width="100%">
                                    <table id="tblcontact" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr runat="server">
                                            <td class="TDWidth" runat="server">
                                                <asp:Label ID="Label7" runat="server" SkinID="lblSkin" Text="Contact TO"></asp:Label>
                                            </td>
                                            <td style="width: 2%" runat="server">
                                                :</td>
                                                
                                            <td runat="server">
                                                <asp:TextBox ID="txtContact" runat="server" MaxLength="100"  SkinID="txtSkin"
                                                    Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="Pnlmobileservices" runat="server" Width="100%">
                                    <table id="tblmobilesir" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr runat="server">
                                            <td class="TDWidth" runat="server">
                                                <asp:Label ID="Label8" runat="server" SkinID="lblSkin" Text="Mobile Service"></asp:Label>
                                            </td>
                                            <td style="width: 2%" runat="server">
                                                :</td>
                                                
                                            <td runat="server">
                                                <asp:TextBox ID="txtmobileservi" runat="server" MaxLength="100"  SkinID="txtSkin"
                                                    Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>                                  
                                   </asp:Panel>
                                  
                                    <asp:Panel ID="pnls_cardtype" runat="server" Width="100%">
                                    <table id="tbls_card" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr runat="server">
                                            <td class="TDWidth" runat="server">
                                                <asp:Label ID="Label9" runat="server" SkinID="lblSkin" Text=" Sim Card Type"></asp:Label>
                                            </td>
                                            <td style="width: 2%" runat="server">
                                                :</td>
                                                
                                            <td runat="server">
                                                <asp:TextBox ID="txtsim_card" runat="server" MaxLength="100"  SkinID="txtSkin"
                                                    Width="60%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>                                  
                                   </asp:Panel>                    

                              
                              <asp:Panel ID="pnlTelCallName" runat="server" Width="100%">
                                    <table id="tblTelCallName" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr runat="server">
                                            <td class="TDWidth" runat="server">
                                                <asp:Label ID="lblTelCallName" runat="server" SkinID="lblSkin" Text="Tele Caller Name"></asp:Label>
                                            </td>
                                            <td style="width: 2%" runat="server">
                                                :</td>
                                            <td runat="server">
                                                <asp:DropDownList ID="ddlTeleName" runat="server" SkinID="ddlSkin">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                             
                                <table id="tblTeleverificationResults" runat="server" cellpadding="0" cellspacing="0"
                                    style="width: 100%">
                                    <tr runat="server">
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblTeleverificationResults" runat="server" SkinID="lblSkin" Text="Televerification Result"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:DropDownList ID="ddlTeleverificationResults" runat="server" DataTextField="STATUS_CODE"
                                                DataValueField="CASE_STATUS_ID" 
                                                SkinID="ddlSkin">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                
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
                                
                                <table id="tblContactNumberDetail" runat="server" cellpadding="0" cellspacing="0"
                                    style="width: 100%">
                                    <tr runat="server">
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblActContDet" runat="server" SkinID="lblSkin" Text="Actual Contacted Number Type" Visible="false"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:DropDownList ID="ddlActContNum" runat="server" SkinID="ddlSkin" Visible="false">
                                                <asp:ListItem Text="New" Value="New"></asp:ListItem>
                                                <asp:ListItem Text="Mobile" Value="Mobile"></asp:ListItem>
                                                <asp:ListItem Text="Landline" Value="Landline"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblNumber" runat="server" SkinID="lblSkin" Text="Actual Number" Visible="false"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:TextBox ID="txtActualNumber" runat="server" MaxLength="15" SkinID="txtSkin" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblNewInfoObt" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr runat="server">
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblNewInfoObt" runat="server" SkinID="lblSkin" Text="New Info Obtained (TCRemarks)"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:TextBox ID="txtNewInfoObt" runat="server" Height="90%" MaxLength="750" SkinID="txtSkin"
                                                TextMode="MultiLine" Width="90%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td colspan="2" runat="server">
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblSupervisorName" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr runat="server">
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblSupervisorName" runat="server" SkinID="lblSkin" Text="Supervisor Name"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:DropDownList ID="ddlSupervisorName" runat="server" SkinID="ddlSkin">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblSupervisorRemark" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr runat="server">
                                        <td class="TDWidth" runat="server">
                                            <asp:Label ID="lblSupervisorRemark" runat="server" SkinID="lblSkin" Text="Supervisor Remark"></asp:Label>
                                        </td>
                                        <td style="width: 2%" runat="server">
                                            :</td>
                                        <td runat="server">
                                            <asp:TextBox ID="txtSupervisorRemark" runat="server" MaxLength="500" SkinID="txtSkin"
                                                TextMode="MultiLine" Width="80%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <!--End of TeleLog-->
                                <!---End Of Included Fields After Testing----->
                        <%--    <asp:Panel ID="pnlSubmit" runat="server" Width="100%">--%>
                                    <table id="tblSubmit" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click"  runat="server"  SkinID="btnSubmitSkin"
                                                    Text="Submit" ValidationGroup="grpAttempts"/>
                                                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin"
                                                    Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidCaseID" runat="server" />
                                    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                    <asp:HiddenField ID="hidMode" runat="server" />
                                    <asp:HiddenField ID="hidVerificationTypeCode" runat="server" />
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" SkinID="lblErrorMsg" Width="672px"></asp:Label>
                                    
                                   <%-- </asp:Panel>--%>
                            </asp:TableCell></asp:TableRow>
                    </asp:Table>
                    <asp:CustomValidator ID="cvCaseStatus" runat="server" ClientValidationFunction="ClientValidate"
                        ControlToValidate="ddlTeleverificationResults" Display="None" ErrorMessage="Please select televerification result."
                         SetFocusOnError="true" ValidationGroup="grpAttempts">
 </asp:CustomValidator>
                    <%--asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="txtSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grpAttempts"></asp:RequiredFieldValidator--%>
                    
                    <asp:RequiredFieldValidator ID="refDate2" runat="server" ControlToValidate="txtDate2ndCall"
                        Display="None" ErrorMessage="Enter Date in 2nd call." SetFocusOnError="True"
                        ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="refDate3" runat="server" ControlToValidate="txtDate3rdCall"
                        Display="None" ErrorMessage="Enter Date in 3rd call." SetFocusOnError="True"
                        ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="refDate4" runat="server" ControlToValidate="txtDate4thCall"
                        Display="None" ErrorMessage="Enter Date in 4th call." SetFocusOnError="True"
                        ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="refDate5" runat="server" ControlToValidate="txtDate5thCall"
                        Display="None" ErrorMessage="Enter Date in 5th call." SetFocusOnError="True"
                        ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
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
                    <asp:CustomValidator ID="cvTel1" runat="server" ClientValidationFunction="ValidateTel1"
                        ControlToValidate="txtTelNo1stCall" Display="None" ErrorMessage="Enter remark in 1st call."
                        ValidationGroup="grpAttempts"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvTel2" runat="server" ClientValidationFunction="ValidateTel2"
                        ControlToValidate="txtTelNo2ndCall" Display="None" ErrorMessage="Enter remark in 2nd call."
                        ValidationGroup="grpAttempts"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvTel3" runat="server" ClientValidationFunction="ValidateTel3"
                        ControlToValidate="txtTelNo3rdCall" Display="None" ErrorMessage="Enter remark in 3rd call."
                        ValidationGroup="grpAttempts"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvTel4" runat="server" ClientValidationFunction="ValidateTel4"
                        ControlToValidate="txtTelNo4thCall" Display="None" ErrorMessage="Enter remark in 4th call."
                        ValidationGroup="grpAttempts"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvTel5" runat="server" ClientValidationFunction="ValidateTel5"
                        ControlToValidate="txtTelNo5thCall" Display="None" ErrorMessage="Enter remark in 5th call."
                        ValidationGroup="grpAttempts"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvAtleastOne" runat="server" ClientValidationFunction="ValidateAttempts"
                        ControlToValidate="txtDate1stCall" Display="None" ErrorMessage="Enter atleast one Attempt."
                        ValidationGroup="grpAttempts">
      </asp:CustomValidator>
                    <asp:ValidationSummary ID="vsAttempt" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="grpAttempts" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="lbRV" runat="server"  Text="RV" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbBV" runat="server"  Text="BV" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbRT" runat="server"  Text="RT" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbBT" runat="server"  Text="BT" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbPRV" runat="server"  Text="PRV" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbPRTV" runat="server"  Text="PRTV" Visible="False"
                        Width="22px"></asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="txtfdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txttdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox></td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnTransStart" runat="server" />
<%--        <asp:HiddenField ID="hdncaseid" runat="server" />--%>
        &nbsp;&nbsp;
    </fieldset>

</asp:Content>

