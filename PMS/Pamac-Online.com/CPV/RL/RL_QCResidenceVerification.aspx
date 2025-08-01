<%@ Page Language="C#" MasterPageFile="RL_MasterPage.master" AutoEventWireup="true"
    Theme="SkinFile" CodeFile="RL_QCResidenceVerification.aspx.cs" Inherits="RL_QCResidenceVerification" %>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddress"  MaxLength="255" runat="server" ></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLandmark" MaxLength="100" runat="server" ></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblLoanAmount" runat="server" Text="Loan Amount"></asp:Label>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtUseOfLoan" MaxLength="255" runat="server"></asp:TextBox>
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
                                                </asp:DropDownList>  
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
                                                <asp:Label SkinID="lblSkin" ID="lblDetailsOfWorkingMembersSpouse" runat="server"
                                                    Text="Details Of Working Members (Spouse)"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsOfWorkingMembersSpouse"  MaxLength="255" runat="server"></asp:TextBox>
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
                                                <asp:TextBox SkinID="txtSkin" ID="txtAnyCreditCardsIfYesProvidNameandLimitonEach" MaxLength="255"
                                                    runat="server" Width="80%"></asp:TextBox>
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
                                                    runat="server" Text="Any Other Loans? If Yes,Provide Details Of Amount, Company and EMI"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI" MaxLength="255"
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAreaOfHouse" MaxLength="20" runat="server"></asp:TextBox>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDetailsoffurnitureSeen" MaxLength="255" runat="server"></asp:TextBox>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="50" ID="txtOwnershipOfResidence" runat="server"></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblType" runat="server" Text="Type"></asp:Label>
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
                                                    <asp:ListItem >Rented</asp:ListItem>
                                                    <asp:ListItem >Other</asp:ListItem>
                                                    <asp:ListItem >Govt,Quaters</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtOwnershipDetails" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtPermanentAddress" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlNumberofRooms" runat="server" Width="100%" Visible="false">
                                    <table id="tblNumberofRooms" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNumberofRooms" runat="server" Text="Number of Rooms"></asp:Label>
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
                                                    <asp:ListItem>Poor</asp:ListItem>
                                                    <asp:ListItem>Slum</asp:ListItem>
                                                    <asp:ListItem>Under Developed</asp:ListItem>
                                                    <asp:ListItem>Village area</asp:ListItem>
                                                    <asp:ListItem>Negative Area</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtVehiclesFinancedNFinancerName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
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
                                                    <asp:ListItem>Good</asp:ListItem> 
                                                    <asp:ListItem>Average</asp:ListItem> 
                                                    <asp:ListItem>Poor</asp:ListItem>                                                    
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
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Fair</asp:ListItem>
                                                    <asp:ListItem>Poor</asp:ListItem>                                                    
                                                    <asp:ListItem>Painted</asp:ListItem>
                                                    <asp:ListItem>Unpainted</asp:ListItem>
                                                    <asp:ListItem>Plastered</asp:ListItem>
                                                    <asp:ListItem>Unplastered</asp:ListItem>
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
                                                    <asp:ListItem>Govt.Quarters</asp:ListItem>
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
                                                <asp:Label SkinID="lblSkin" ID="lblCommentsOfNeighbour1" runat="server" Text="Comments of Neighbour"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" TextMode="multiLine" onkeyPress="ValidateTextLength('comments of neighbour', this, 255);" MaxLength="255" Width="80%" ID="txtCommentsOfNeighbour1" runat="server" ></asp:TextBox>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtNameOfCompanyWhereAppEmployed" runat="server"
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="255" ID="txtPurposeOfLoanTaken" runat="server"></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblRoomType" runat="server" Text="Room Type"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoomType" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>a</asp:ListItem>
                                                    <asp:ListItem>b</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTypeOfHouse" runat="server" Width="100%" Visible="false">
                                    <table id="tblTypeOfHouse" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblTypeOfHouse" runat="server" Text="Type of House"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlTypeOfHouse" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Bungalow</asp:ListItem>
                                                    <asp:ListItem>Flat</asp:ListItem>
                                                    <asp:ListItem>Individual House</asp:ListItem>
                                                    <asp:ListItem>Standing Chawl/Janata Flat</asp:ListItem>
                                                    <asp:ListItem>Sitting Chawl/Hutment</asp:ListItem>
                                                    <asp:ListItem>Slum</asp:ListItem>
                                                    <asp:ListItem>Staff Quarters</asp:ListItem>
                                                    <asp:ListItem>Lodge/Hotel</asp:ListItem>
                                                    <asp:ListItem>Annexe To House</asp:ListItem>
                                                    <asp:ListItem>Multi-Tenant House</asp:ListItem>
                                                    <asp:ListItem>Small Independent House</asp:ListItem>
                                                    <asp:ListItem>Chawl</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" MaxLength="100" ID="txtVehicleOwnership" runat="server" Width="80%"></asp:TextBox>
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
                                                <asp:Label SkinID="lblSkin" ID="lblTelCDRomCheck" runat="server" Text="Telephone CD Rom check"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTelCDRomCheck" runat="server" AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
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
                                                <asp:Label SkinID="lblSkin" ID="lblStandardOfLiving" runat="server" Text="Standard of Living"></asp:Label>
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
                                                <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="255" onkeyPress="ValidateTextLength('third party comment', this, 255);" ID="txtThirdPartyComment" runat="server"></asp:TextBox>
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
                                                    <asp:ListItem>Untraceable</asp:ListItem>
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
                                                <asp:Label SkinID="lblSkin" ID="lblAgencyName" runat="server" Text="Agency Name"></asp:Label>
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
                                                <asp:Label SkinID="lblSkin" ID="lblAccessibility" runat="server" Text="Accessibility"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList ID="ddlAccessibility" runat="server" AutoPostBack="false" SkinID="ddlSkin">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>By All Means</asp:ListItem>
                                                    <asp:ListItem>By Two wheeler only</asp:ListItem>
                                                    <asp:ListItem>By Foot only</asp:ListItem>
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
                                                <asp:TextBox SkinID="txtSkin" MaxLength="255" ID="txtAddressOfCompany" Width="80%" runat="server"></asp:TextBox>
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
                                            <asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtNoOfEaringMembers" Width="80%" runat="server" ></asp:TextBox> 
                                        </td>
                                    </tr>            
                                   </table>
                               </asp:Panel>
                                <asp:Panel ID="pnlIfVehicleExist" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblIfVehicleExist" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblIfVehicleExist" runat="server" Text="If vehicle exist"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                            <asp:DropDownList SkinID="ddlSkin" ID="ddlIfVehicleExist" runat="server"  AutoPostBack="false">
                                                <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>                                                            
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
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="250" onkeyPress="ValidateTextLength('verifier comments', this, 250);"  ID="txtSupervisorComments" runat="server" ></asp:TextBox> 
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
                            </asp:TableCell></asp:TableRow>
                    </asp:Table>
                         <asp:CustomValidator ID="cvOverallVerification" runat="server" 
                   ErrorMessage="Please select Overall Verification." ValidationGroup="gvValidate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true" ControlToValidate="ddlOverallVerification"
                    OnServerValidate="cvSelectddlOverallVerification_ServerValidate">
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
                    ValidationGroup="gvValidate" ShowMessageBox="True" ShowSummary="False" /> &nbsp;
                    
                </td>
            </tr>
        </table>
         <asp:HiddenField ID="hdnTransStart" runat="server" />
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
