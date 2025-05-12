<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" Theme="skinFile" CodeFile="KYC_RV_VERI.aspx.cs" Inherits="CPV_KYC_KYC_RV_VERI" %>

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
    </script>
 <fieldset>
        <legend class="FormHeading">Residence Verification </legend>
        
        <table cellpadding="0" cellspacing="0" border="0" id="Table1" runat="server" width="100%"
            style="background-color: #E7F6FF">
            
            <tr>
                <td>
                </td>
                <td>
                 <!--Start ErrorMessgage-->
                    <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="true">
                        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width: 100%"
                            runat="server">
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <!--END ErrorMessgage-->
                    <!--Place holder Start-->
                    <asp:Table ID="tblKYCVerification" runat="server" Width="100%">
                        <asp:TableRow ID="tblrowPlace" runat="server">
                            <asp:TableCell ID="tblCellPlace" runat="server">  
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
                    </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblrow" runat="server">
                            <asp:TableCell ID="tblCell" runat="server">
                                <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text=" Referance No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtRefNo" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlInitiationDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Received Date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox>                                         
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                  <asp:Panel ID="pnlResiVerTelHead" runat="server" Width="100%" Visible="false">
                                    <table>
                                    <tr>
                                    <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                    <asp:Label SkinID="lblSkin"   ID="lblResidenceVerifiReport" runat="server" Text="RESIDENCE VERIFICATION REPORT"></asp:Label>
                                     </td>
                                     </tr>
                                     </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlSendDate" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSendDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblSendDate" runat="server" SkinID="lblSkin">Send Date</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSendDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="img3" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSendDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProduct" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblProduct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblProduct" runat="server" SkinID="lblSkin" Text="Have you visited on the same address"></asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtProduct" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfVerificationAgent" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNameOfVerificationAgent">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfVerificationAgent" runat="server" SkinID="lblSkin">Name of BSP / Verification Agent</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfVerificationAgent" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlResidenceAddress" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResidenceAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlResiPincode" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiPincode" runat="server" Text="Resi Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiPincode" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlResiTelNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiTelNo" runat="server" Text="Resi Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlResiLandmark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiLandmark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiLandmark" runat="server" Text="Resi Landmark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiLandmark" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                 <%-- add new panel  by kanchan on12 jan 2015--%>
                                
                                 <asp:Panel ID="pnlLandmarkVerify" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table57" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label25" runat="server" Text="Landmark Verified"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtLandmarkVerify" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                
                               <%-- comp--%>
                                
                                
                                
                                
                                
                                
                                <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="Business Equipment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusinessEquipSightedFemu" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlPermanentPincode" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentPincode" runat="server" Text="Permanent Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentPincode" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlPermanentTelNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentTelNo" runat="server" Text="Permanent Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlBusiOccupationDtl" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusiOccupationDtl" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusiOccupationDtl" runat="server" Text="Business/Occupation Details"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusiOccupationDtl" runat="server" MaxLength="500"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblrvComment" runat="server" Visible="false"  Text="RV Comment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"    ID="txtRvComment" MaxLength="1000" Visible="false" TextMode="MultiLine"  onkeyPress="ValidateTextLength('verifier comments', this, 1000);"  runat="server"  Width="488px"></asp:TextBox>                                   
                                    </td>
                                    </tr>
                                    
                                </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlPersonalDetailHead" runat="server" Width="100%" Visible="false">
                            <table>
                                <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblPersonalDetail" runat="server" Text="PERSONAL DETAILS"></asp:Label>
                                  </td>
                                 </tr>
                            </table>
                      </asp:Panel>                          
                                <asp:Panel ID="panelApplicantName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table2">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label1" runat="server">Applicant's Name(Mr./Ms./Mrs.)</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="TextBox1" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddress" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAddress">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddress" runat="server">Address</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAddress" TextMode="MultiLine" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPhone" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblPhone">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblPhone" runat="server" SkinID="lblSkin">Phone</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblMobile">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblMobile" runat="server" SkinID="lblSkin">Mobile</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtMobile" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEmail" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblEmail">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblEmail" runat="server" SkinID="lblSkin">Email</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" SkinID="txtSkin" Width="80%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDateOfBirth" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblDateOfBirth">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDOB" runat="server" SkinID="lblSkin">Date of Birth of Applicant</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtDOB" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDOB" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMaritalStatus" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblMaritalStatus">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblMaritalStatus" runat="server" SkinID="lblSkin">Marital Status</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                               <asp:DropDownList SkinID="ddlSkin" ID="ddlMaritalStatus" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Single</asp:ListItem>
                                                    <asp:ListItem>Married</asp:ListItem>
                                                    <asp:ListItem>Divorce</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlNamePlateDisplay" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNamePlateDisplay">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNamePlateDisplay" runat="server" SkinID="lblSkin" Text="Name plate sighted at Society / Original Verified"></asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateDisplay" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="Label5" runat="server">If Yes, does name match with records</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIfNamePLate" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblPersonContacted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPersonContacted" runat="server">Person contacted</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtPersonContacted" runat="server" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                                                    
                                <asp:Panel ID="pnlRelationshipWithApp" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRelationshipWithApp">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRelationshipWithApp" runat="server" SkinID="lblSkin">Relationship with applicant</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td >
                                                <asp:TextBox ID="txtRelationshipWithApp" runat="server" SkinID="txtSkin" Width="80%" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlStayingSinceAtResi" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStayingSinceAtResi">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStayingSinceAtResi" runat="server" SkinID="lblSkin">Staying since at Resi</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtStayingSinceAtResi" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                    <asp:Panel ID="pnlOtherDetailsHead" runat="server" Width="100%" Visible="false">
                                    <table>
                                        <tr>
                                          <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                           <asp:Label SkinID="lblSkin"   ID="lblOthersDetails" runat="server" Text="OTHER DETAILS"></asp:Label>
                                          </td>
                                         </tr>
                                    </table>
                              </asp:Panel>    
                                 <%--////////add by kamal ddl 28-10-09///////////--%>
                                  <asp:Panel ID="pnlConstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblConstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblConstitution" runat="server" SkinID="lblSkin">
                                                    Constitutions / Company Type</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlConstitution" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Prop</asp:ListItem>
                                                    <asp:ListItem>Partnership</asp:ListItem>
                                                    <asp:ListItem>Pvt Ltd Co</asp:ListItem>            
                                                    <asp:ListItem>Public Ltd Co</asp:ListItem> 
                                                    <asp:ListItem>HUF</asp:ListItem>
                                                    <asp:ListItem>Others (pls specify</asp:ListItem>            
                                                    <asp:ListItem>Individual</asp:ListItem>  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                               <asp:Panel ID="pnlLocalityType" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblLocalityType">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocalityType" runat="server" SkinID="lblSkin">Residence / Locality Type</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                  
                                                    
                                                    <asp:ListItem>Residential</asp:ListItem>
                                                    <asp:ListItem>Commercial</asp:ListItem>
                                                    <asp:ListItem>Industrial</asp:ListItem>            
                                                    <asp:ListItem>Business Centre</asp:ListItem>
                                                     <asp:ListItem>Bungalow</asp:ListItem>
                                                     <asp:ListItem>Apartment</asp:ListItem>
                                                     <asp:ListItem>Housing Society</asp:ListItem>
                                                     <asp:ListItem>Restricted Area</asp:ListItem>
                                                     <asp:ListItem>Hut</asp:ListItem>
                                                     <asp:ListItem>Chawl</asp:ListItem>
                                                       <asp:ListItem>Flat</asp:ListItem>
                                                         <asp:ListItem>Other</asp:ListItem>
                                                     
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                    <asp:Panel ID="pnlWhetherVisitingCardobtained" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblWhetherVisitingCardobtained">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblWhetherVisitingCardobtained" runat="server" SkinID="lblSkin">
                                                    Whether Visiting Card obtained</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlWhetherVisitingCardobtained" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                               <asp:Panel ID="pnlFurniture" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblfurniture" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblfurniture" runat="server" Text="Furniture/fixtures/office equipments seen or was it a make shift arrangement"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtfurniture" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                               <asp:Panel ID="pnlReasonfornothavingavalidBusinessproof" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonfornothavingavalidBusinessproof" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblReasonfornothavingavalidBusinessproof" runat="server" Text="Reason for not having a valid address / Business proof"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonfornothavingavalidBusinessproof" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                 <asp:Panel ID="pnlIfNotRecommended" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblIfNotRecommended">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfNotRecommended" runat="server" SkinID="lblSkin">
                                                   Observations of Employee conducting CPV if Not recommended</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIfNotRecommended" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Address not traceable</asp:ListItem>
                                                    <asp:ListItem>Detail mismatch</asp:ListItem>
                                                    <asp:ListItem>Applicant does not exist</asp:ListItem>            
                                                    <asp:ListItem>Defaulter/Bad market reputation</asp:ListItem> 
                                                    <asp:ListItem>Entry not allowed</asp:ListItem>            
                                                    <asp:ListItem>Others</asp:ListItem> 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfOtherRecommended" runat="server" SkinID="lblSkin">
                                                   if Recommended OtherSpecify</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                            <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherRecommended" runat="server" MaxLength="255">
                                            </asp:TextBox>                                    
                                        </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                               <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNatureOfBusiness" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNatureOfBusiness" runat="server" Text="Nature Of Business"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlNatureOfBusiness" runat="server" AutoPostBack="false">
                                        <asp:ListItem>Professional</asp:ListItem>
                                        <asp:ListItem>Manufacturer</asp:ListItem>
                                        <asp:ListItem>Trader</asp:ListItem>
                                        <asp:ListItem>Shopkeeper</asp:ListItem>
                                        <asp:ListItem>Service Provider</asp:ListItem>
                                        <asp:ListItem>Comm Agent</asp:ListItem>
                                        <asp:ListItem>Broker</asp:ListItem>
                                        <asp:ListItem>Tutor Personal Care</asp:ListItem>
                                        <asp:ListItem>LIC Agent</asp:ListItem>
                                        <asp:ListItem>Other(Specify)</asp:ListItem>
                                    </asp:DropDownList>  
                                    <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtNatureBuss" runat="server" MaxLength="300"></asp:TextBox>                            
                                    </td>
                                  </tr>
                                </table>
                                </asp:Panel>
                                
                                <%--///added by kamal matekar for HDFC_Liab pdf format///--%>
                                
                                 <asp:Panel ID="pnlNameAddressNeighbour" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameAddressNeighbour" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameAddressNeighbour" runat="server" Text="Name & Address Neighbours"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameAddressNeighbour" runat="server" Width="500"></asp:TextBox>                                    
                                    </td>
                                    </tr>                            
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlNameOffice" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table10" style="width:100%" runat="server"> 
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label6" runat="server" Text="Name of Bank Officer Conducting Verification"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfficer" runat="server"  Width="80%"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlSiteVerifier" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table11" style="width:100%" runat="server"> 
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label7" runat="server" Text="Site Verifier SSC Code"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtSiteVerifier" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblLocality">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocality" runat="server" SkinID="lblSkin" Text="Locality"></asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocality" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Lower Middle Class</asp:ListItem>
                                                    <asp:ListItem>Middle Class</asp:ListItem>
                                                    <asp:ListItem>Upper Middle Class</asp:ListItem>
                                                    <asp:ListItem>Posh</asp:ListItem>
                                                    <asp:ListItem>Village Area</asp:ListItem>
                                                    <asp:ListItem>Slums</asp:ListItem>
                                                      <asp:ListItem>Slum Or Chawl</asp:ListItem>
                                                    <asp:ListItem>Decent Middle Class Locality</asp:ListItem>
                                                    <asp:ListItem>Posh Upper Class Locality</asp:ListItem>
                                                    
                                               
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlDoNeighbourKnowTheCustomerForFemu" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table8">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDoNeighbourKnowTheCustomerForFemu" runat="server" SkinID="lblSkin" Text="Do Neighbour/Neighboring shops or offices know the customer"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDoNeighbourKnowTheCustomerForFemu" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Positive</asp:ListItem>
                                                    <asp:ListItem>Negative</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                              
                                <%--////////end code///////////--%>
                                                              
                                
                                <%--add code by santosh shelar for YesBank 12/01/2011--%>                                                               
                                <asp:Panel ID="pnlTrigSVR" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblTrigSVR">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTrigSVR" runat="server" SkinID="lblSkin" Text="Trigger for SVR"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTrigSVR" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>ACCOUNT OPENING</asp:ListItem>
                                                    <asp:ListItem>RETURNED DELIVERBALES</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlBranchName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblBranchName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblBranchName" runat="server" SkinID="lblSkin">Branch Name :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtBranchName" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlBranchCode" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblBranchCode">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblBranchCode" runat="server" SkinID="lblSkin">Branch Code / CAPH ID:</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtBranchCode" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                 
                                <asp:Panel ID="pnlRmName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblRmName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRmName" runat="server" SkinID="lblSkin">Name of Sourcing RM :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtRmName" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                 
                                <asp:Panel ID="pnlRmCode" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblRmCode">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRmCode" runat="server" SkinID="lblSkin">SSC code of Sourcing RM :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtRmCode" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                 
                                 <asp:Panel ID="pnlAccountNo" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblAccountNo">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblAccountNo" runat="server" SkinID="lblSkin">A/C No :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtAccountNo" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>       
                                 <asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfPersonContacted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfPersonContacted" runat="server" SkinID="lblSkin">Name of the Person contacted during Verification :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfPersonContacted" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>   
                                <asp:Panel ID="pnlHowLongInBusiness" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblHowLongInBusiness">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblHowLongInBusiness" runat="server" SkinID="lblSkin">No of years in present occupation :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtHowLongInBusiness" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlRmFormat" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRmFormat">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRmFormat" runat="server" SkinID="lblSkin" Text="Rm code of Site verifier and sourcer different as per above format"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRmFormat" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlBllCase" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblBllCase">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblBllCase" runat="server" SkinID="lblSkin" Text="BBL/BSDL declaration signed for all cases"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlBllCase" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlBllSvr" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblBllSvr">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblBllSvr" runat="server" SkinID="lblSkin" Text="BBL declaration signed for Account opening SVR"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlBllSvr" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                               <asp:Panel ID="pnlNocName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNocName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNocName" runat="server" SkinID="lblSkin">NOC Official Name :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNocName" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>   
                                <asp:Panel ID="pnlTvTele" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblTvTele">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTvTele" runat="server" SkinID="lblSkin">Telephone number called :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTvTele" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>   
                               <asp:Panel ID="pnlTvPerson" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblTvPerson">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTvPerson" runat="server" SkinID="lblSkin">Name of Person Spoken with :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTvPerson" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>        
                                <asp:Panel ID="pnlTvRelation" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblTvRelation">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTvRelation" runat="server" SkinID="lblSkin">Relation of person with Account holder :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTvRelation" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                                            
                                <asp:Panel ID="pnlTvConAdd" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblTvConAdd">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTvConAdd" runat="server" SkinID="lblSkin">Confirmation of address of account holder :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTvConAdd" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                                            
                                <asp:Panel ID="pnlTvCustId" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblTvCustId">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTvCustId" runat="server" SkinID="lblSkin">Cust ID :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTvCustId" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlAccOpen" runat="server"  Width="100%" Visible="false">
                                        <table cellpadding="0" cellspacing="0" border="0" id="tblAccOpen" style="width:100%" runat="server" >
                                        <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblAccOpen" runat="server"  Text="At The Time Of Account Opening"></asp:Label>
                                            </td><td style="width:2%">:</td>
                                            <td>
                                            <asp:CheckBoxList ID="ChkAccOpen" SkinID="chkListSkin" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                                                <asp:ListItem>Account Opening In J and K or cases</asp:ListItem>
                                                <asp:ListItem>Account Opening of Walkin customers</asp:ListItem>
                                                <asp:ListItem>Account Opening with Cash/NIL IP</asp:ListItem>                                                 
                                            </asp:CheckBoxList>   
                                            </td>                
                                        </tr>
                                        <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label8" runat="server"  Text="At The Time Of RETURNED DELIVERABLES"></asp:Label>
                                            </td><td style="width:2%">:</td>
                                            <td>
                                            <asp:CheckBoxList ID="ChkRetDel" SkinID="chkListSkin" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                                                <asp:ListItem>Returned deliverables with critical reason</asp:ListItem>
                                                <asp:ListItem>critical reason For second time return</asp:ListItem>
                                                <asp:ListItem>Returned deliverables with non critical reason</asp:ListItem>                                                 
                                                <asp:ListItem>Welcome KIT/PIN is to be sent DIRECTLY to the branch</asp:ListItem>                                                 
                                                <asp:ListItem>Repeat Deliverables returned with critical reason or returned a second time</asp:ListItem>                                                 
                                                <asp:ListItem>Deliverables returned with non critical reason returned for a second time</asp:ListItem>                                                 
                                            </asp:CheckBoxList>   
                                            </td>                
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label9" runat="server" SkinID="lblSkin">Confirmation from BBL/BSDL Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign1" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label10" runat="server" SkinID="lblSkin">Confirmation of Site verifier Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign2" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label11" runat="server" SkinID="lblSkin">Confirmation from BSDL Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign3" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label12" runat="server" SkinID="lblSkin">BBL Declaration Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign4" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label13" runat="server" SkinID="lblSkin">Confirmation from BBL/BSDL-required in all cases Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign5" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label14" runat="server" SkinID="lblSkin">BBL Declaration-required at the time of sourcing Signature :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign6" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                        </table>
                                     </asp:Panel>                                                           
                                                                        
                                <%--end code--%>                                                          
                                                                                      
                                 <%--////////add by santosh shelar rename demat account agent as fe name 25-08-08///////////--%>
                                     <asp:Panel ID="pnlNameOfDematAcct" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfDematAcct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfDematAcct" runat="server" SkinID="lblSkin">Name of FE</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfDematAcct" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnlHavingDematAcwithOtherInstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table3">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblHavingDematAcwithOtherInstitution" runat="server" SkinID="lblSkin">Having Demat Account With Other Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlHavingDematAcwithOtherInstitution" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem>NA</asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 
                                 <asp:Panel ID="pnlIfYesThenNameOfDP" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table6">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfYesThenNameOfDP" runat="server" SkinID="lblSkin">If Yes,Then Name Of The DP</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtIfYesThenNameOfDP" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlHavingSMEAccountWithOtherInstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblHavingSMEAccountWithOtherInstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblHavingSMEAccountWithOtherInstitution" runat="server" SkinID="lblSkin">Having SME Account With Other Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlHavingSMEAccountWithOtherInstitution" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem>NA</asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnlNameOfInstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfInstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfInstitution" runat="server" SkinID="lblSkin">If Yes; Then Name Of The Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfInstitution" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                        
                                <asp:Panel ID="pnlStatusOfDematAcct" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStatusOfDematAcct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStatusOfDematAcct" runat="server" SkinID="lblSkin">Status of Demat account</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStatusOfDematAcct" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              
                                <asp:Panel ID="pnlDoBrokeOtherThanSSKI" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblDoBrokeOtherThanSSKI">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDoBrokeOtherThanSSKI" runat="server">
                                            Doing Broking through any Broker other than SSKI</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtDoBrokeOtherThanSSKI" runat="server" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAttituteOfContactPerson" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAttituteOfContactPerson">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblAttituteOfContactPerson" runat="server" SkinID="lblSkin">
                                            Attitute of the contact person</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlAttituteOfContactPerson" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Bad</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRating">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRating" runat="server" SkinID="lblSkin">
                                               Rating</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRating" runat="server" AutoPostBack="false">
                                                  <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                </asp:DropDownList>
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
                                
                                <asp:Panel ID="pnlStatus" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStatus">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStatus" runat="server" SkinID="lblSkin">
                                                    Status</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStatus"   runat="server" AutoPostBack="false">
  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlObservation" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblObservation" runat="server" Text="Observation(Not to be asked to the customer)"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlPlaceVisited" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table4">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblPlaceVisited" runat="server" SkinID="lblSkin">
                                                    Place Visited</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlPlaceVisited" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Residence</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                    <asp:ListItem>Others</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlIfOthersSpecify" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOthersSpecify" runat="server" Text="If Others (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOthersSpecify" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                                                
                                <asp:Panel ID="pnlNamePlateOfAppSighted" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNamePlateOfAppSighted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNamePlateOfAppSighted" runat="server" SkinID="lblSkin" Text="Photocopy of pan address proof collected" ></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateOfAppSighted" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlNeighbour" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNeighbour">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNeighbour" runat="server" SkinID="lblSkin" Text="Do Neighbour/Neighboring shops or offices know the customer" ></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="DropDownList1" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               
                                <asp:Panel ID="pnlAreaOfResidence" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAreaOfResidence" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAreaOfResidence" runat="server" Text="Area of Residence"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAreaOfResidence" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlLocatingAddress" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblLocatingAddress">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocatingAddress" runat="server" SkinID="lblSkin">
                                                    Locating Address</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingAddress" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Easy</asp:ListItem>
                                                    <asp:ListItem>Difficult</asp:ListItem>            
                                                    <asp:ListItem>Untraceable</asp:ListItem>  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIfOfficeBusiActivity" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOfficeBusiActivity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOfficeBusiActivity" runat="server" Text="If Office are Business activity seen"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOfficeBusiActivity" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDescriptionOfResi" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblDescriptionOfResi" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDescriptionOfResi" runat="server" Text="General Description Of Resi."></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtDescriptionOfResi" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlGeneralComments" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralComments" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblGeneralComments" runat="server" Text="General Comments"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" TextMode="MultiLine"  ID="txtGeneralComments"  runat="server" Width="488px" MaxLength="1000" onkeyPress="ValidateTextLength('Comment', this, 1000);"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlCommentsRemarkOfVerifierHead" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblCommentsRemarkOfVerifier" runat="server" Text="COMMENTS / REMARKS OF VERIFIER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                 <asp:Panel ID="pnlVerifierName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblVerifierName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblVerifierName" runat="server" SkinID="lblSkin">Verifier Name</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>  
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVerifierDate" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblVerifierDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblVerifierDate" runat="server" SkinID="lblSkin">Verification Date & Time</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgVerifierDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtVerifierDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                <asp:TextBox ID="txtVerifierTime" runat="server" SkinID="txtSkin" MaxLength="5" Width="4%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlVerifierTimeType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                        <asp:Panel ID="pnlSupervisorName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSupervisorName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblSupervisorName" runat="server" SkinID="lblSkin">Supervisor Name</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSupervisorName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>    
                                
                            <%--added by sanket--%>
                                    <asp:Panel ID="pnlddlSupervisorName" runat="server" Width="100%">
                                        <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorNameForSign" style="width:100%" runat="server">
                                            <tr id="Tr1" runat="server">
                                                <td id="Td1" class="TDWidth" runat="server"  >
                                                    <asp:Label SkinID="lblSkin" ID="lblSupervisorNameForSign" runat="server" Text="Supervisor's Name"></asp:Label>
                                                </td><td id="Td2" style="width:2%" runat="server">:</td>
                                                <td id="Td3" runat="server">
                                                    <asp:DropDownList ValidationGroup="grValidate" SkinID="ddlSkin" ID="ddlSupervisorName" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlSupervisorName_SelectedIndexChanged">
                                                    </asp:DropDownList><asp:Label SkinID="lblSkin" ForeColor="red" ID="lblSupError" Text="Supervisor Name is Mandatory." runat="server"></asp:Label>

                                               <asp:RequiredFieldValidator ID="rfvSupervisorNameForSign" runat="server"
                                                 ErrorMessage="Please select Supervisor Name." ControlToValidate="ddlSupervisorName"
                                                InitialValue="0" Display="Dynamic" ValidationGroup="grValidate"  >
                                                </asp:RequiredFieldValidator>     </td>
                                            </tr>
                                        </table>                
                                    </asp:Panel>
                            <%--ended by sanket--%>                                
                                
                    <%--Added  by Manoj for Area --%>                                
                          <asp:Panel ID="PnlAreaname" runat="server" Width="100%" Visible="true">
                               <table cellpadding="0" cellspacing="0" border="0" id="tabareaname" style="width:100%" runat="server">
                                    <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="labAreaname" runat="server" Text="Area Name"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                             <asp:DropDownList SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false"  ValidationGroup="grValidate" OnSelectedIndexChanged="ddlAreaname_SelectedIndexChanged">
                        
                                              </asp:DropDownList>
                                     <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                                     <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />
                </td>
                                   </tr>            
                                </table>
                        </asp:Panel>
                          <%--Ended  by Manoj for Area --%>   
                                
                                
                                                            
                                <asp:Panel ID="pnlSupervisorDate" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSupervisorDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label2" runat="server" SkinID="lblSkin">Date and Time</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSupervisorDate" runat="server" SkinID="txtSkin" ></asp:TextBox>
                                                <img id="imgSupervisorDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSupervisorDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                <asp:TextBox ID="txtSupervisorTime" runat="server" SkinID="txtSkin" MaxLength="5"
                                                    Width="4%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlSupervisorTimeType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                      <%--Added by MAnoj --%> 
                              <asp:Panel ID="PnlEmployeeseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table12">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label15" runat="server" SkinID="lblSkin">No Of Employee seen</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtemployeeseen" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel> 
                               <asp:Panel ID="Pnlcomputerseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table13">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label16" runat="server" SkinID="lblSkin">No Of Computer seen</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtcomputerseen" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>
                               <asp:Panel ID="PnlTelphoneseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table14">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label17" runat="server" SkinID="lblSkin">No Of Tele phone seen</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTelephoneseen" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>
                               <asp:Panel ID="PnlfloorOfbuliding" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table15">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label18" runat="server" SkinID="lblSkin">Total floor of the buliding</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txttotalfloorofbuliding" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>     
                               <asp:Panel ID="Pnlcustomerexiswhichfloor" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table16">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label19" runat="server" SkinID="lblSkin">customer resi or office existing on which floor</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtcustomerexiswhichfloor" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel> 
                               
                               <asp:Panel ID="PnlOwnershipOfResidence" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabOwnershipOfResidence">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labOwnershipOfResidence" runat="server" SkinID="lblSkin">Ownership of Residence</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnershipOfResidence" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Rented</asp:ListItem>
                                                    <asp:ListItem>Parents owned</asp:ListItem>            
                                                    <asp:ListItem>Paying guest</asp:ListItem>  
                                                    <asp:ListItem>Shared Accommodation</asp:ListItem>  
                                                      <asp:ListItem>Other</asp:ListItem>  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="PnlRationcard" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabRationcard">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labRationcard" runat="server" SkinID="lblSkin">Ration Card available for same address</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRationcard" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="PnlMettoapplicant" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabMettoapplicant">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labMettoapplicant" runat="server" SkinID="lblSkin">Met / Spoke to applicant at Residence</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlMettoapplicant" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                         
                                 <%--Ended by MAnoj for Desuch bank--%> 
                                     <%--Added by Manoj for Kanvarji Finstock Pvt Ltd --%>
                                <asp:Panel runat="server" ID="PnlDoesApplicantstayhere" Width="100%" Visible="false">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabdoesapplicantstayheare">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="lbldoesapplicantstayheare" runat="server" SkinID="lblskin">Does Applicant stay here</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlapplicantstayheare" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel runat="server" ID="PnlOwnership" Width="100%" Visible="false">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabOwnership">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labOwership" runat="server" SkinID="lblskin">Ownership</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnership" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Parental</asp:ListItem>
                                                    <asp:ListItem>Self Owned</asp:ListItem>     
                                                    <asp:ListItem>Relative owned</asp:ListItem>
                                                    <asp:ListItem>Friend owned</asp:ListItem>
                                                    <asp:ListItem>Bachelor acco</asp:ListItem>
                                                    <asp:ListItem>Rented</asp:ListItem>       
                                                    <asp:ListItem>Company acco</asp:ListItem>    
                                                    <asp:ListItem>PG</asp:ListItem>  
                                                    <asp:ListItem>Other</asp:ListItem>          
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                               
                               <asp:Panel runat="server" ID="PnlTradingexperience" Width="100%" Visible="false">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabTradingexperience">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labTradingexperience" runat="server" SkinID="lblskin">Trading experience</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlTradingexperience" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                                                     
      
                               
                               <asp:Panel ID="pnlNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table18">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers" runat="server" SkinID="lblSkin">No of members having trading accont with stock brokers/commodity brokers</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel  ID="Pnlvehical" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabvehical">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="Label23" runat="server" SkinID="lblskin">Vehical</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlvehical" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Owned</asp:ListItem>
                                                    <asp:ListItem>Finance</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>   
                               
                               <asp:Panel  ID="PnlOccuption" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table19">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labOccuption" runat="server" SkinID="lblskin">Occuption</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlOccuption" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Government Service</asp:ListItem>
                                                    <asp:ListItem>With Private Enterprise</asp:ListItem>         
                                                    <asp:ListItem>Business</asp:ListItem>      
                                                    <asp:ListItem>Student</asp:ListItem>      
                                                    <asp:ListItem>Retired</asp:ListItem>      
                                                    <asp:ListItem>Housewife</asp:ListItem>         
                                                    <asp:ListItem>Other</asp:ListItem>         
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>   
                               
                               <asp:Panel ID="PnlIfSalnameoftheoragnization" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabIfSalnameoftheoragnization">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labIfSalnameoftheoragnization" runat="server" SkinID="lblSkin">If salaried,name of the organization</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtIfSalnameoftheoragnization"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                             
                                <asp:Panel ID="PnlIfBusinessnatureofbusiness" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabIfBusinessnatureofbusiness">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labIfBusinessnatureofbusiness" runat="server" SkinID="lblSkin">If Business, nature of business</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtIfBusinessnatureofbusiness"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                      
                                
                                <asp:Panel  ID="Pnlcarpark" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table17">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labcarpark" runat="server" SkinID="lblskin">Car park</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlcarpark" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>            
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel  ID="PnlTypeofResidence" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabTypeofResidence">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labTypeofResidence" runat="server" SkinID="lblskin">Type of Residence</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofResidence" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Bungalow</asp:ListItem>
                                                    <asp:ListItem>Flat</asp:ListItem> 
                                                    <asp:ListItem>Individual house</asp:ListItem>
                                                    <asp:ListItem>Standing chawl/janta flat</asp:ListItem>
                                                    <asp:ListItem>Hutment</asp:ListItem>    
                                                    <asp:ListItem>Slum</asp:ListItem>    
                                                    <asp:ListItem>Staff quarter</asp:ListItem>    
                                                    <asp:ListItem>Hotel</asp:ListItem> 
                                                    <asp:ListItem>Annexe to house</asp:ListItem>   
                                                    <asp:ListItem>Tenament</asp:ListItem>   
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                              <asp:Panel  ID="PnlExteriosofresidence" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table20">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="Label20" runat="server" SkinID="lblskin">Type of Residence</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                       <asp:CheckBoxList ID="chkEquipInOffice" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                                                            <asp:ListItem>Gerden</asp:ListItem>
                                                            <asp:ListItem>Building wall (patchy)</asp:ListItem> 
                                                            <asp:ListItem>Elevator</asp:ListItem> 
                                                            <asp:ListItem>Fincing/wall</asp:ListItem>
                                                            <asp:ListItem>Security</asp:ListItem>
                                                        </asp:CheckBoxList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                                <asp:Panel  ID="PnlResidenceInternal" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabResidenceInternal">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labResidenceInternal" runat="server" SkinID="lblskin">Residence Internal</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlResidenceInternal" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Well furnished</asp:ListItem>
                                                    <asp:ListItem>Avg furnished </asp:ListItem>  
                                                    <asp:ListItem>Poorly furnished</asp:ListItem>   
                                                    <asp:ListItem>Unfurnished</asp:ListItem>
                                              </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel  ID="PnlConstruction" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabConstruction">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labConstruction" runat="server" SkinID="lblskin">Construction of house</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlConstruction" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Pukka</asp:ListItem>
                                                    <asp:ListItem>Sami Pukka</asp:ListItem>  
                                                    <asp:ListItem>Temporary</asp:ListItem>   
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel  ID="PnlTypeofflooring" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table21">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labtypeflooring" runat="server" SkinID="lblskin">Type of flooring</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddltypeofflooring" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Mosaic</asp:ListItem>
                                                    <asp:ListItem>Marble</asp:ListItem>  
                                                    <asp:ListItem>Cement</asp:ListItem>   
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel  ID="PnlTypeOfRoofing" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table22">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labTypeOfRoofing" runat="server" SkinID="lblskin">Type of Roofing</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfRoofing" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Tile</asp:ListItem>
                                                    <asp:ListItem>Asbestos</asp:ListItem>  
                                                    <asp:ListItem>Concrete</asp:ListItem>  
                                                    <asp:ListItem>Thached</asp:ListItem>   
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel  ID="PnlStandardofliving" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table23">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labStandardofliving" runat="server" SkinID="lblskin">Standard of living </asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlStandardofliving" runat="server" AutoPostBack="false">
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
                               
                               <asp:Panel  ID="PnlAssets" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabAssets">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labAssets" runat="server" SkinID="lblskin">Assets seen</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                       <asp:CheckBoxList ID="chkAssets" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                                                            <asp:ListItem>TV</asp:ListItem>
                                                            <asp:ListItem>Phone</asp:ListItem> 
                                                            <asp:ListItem>Sofa set</asp:ListItem> 
                                                            <asp:ListItem>Fridge</asp:ListItem>
                                                            <asp:ListItem>2 Wheeler</asp:ListItem>
                                                            <asp:ListItem>Music System</asp:ListItem>
                                                            <asp:ListItem>Washing m/c</asp:ListItem>
                                                            <asp:ListItem>Computer</asp:ListItem>
                                                            <asp:ListItem>Ac</asp:ListItem>
                                                            <asp:ListItem>other</asp:ListItem>
                                                        </asp:CheckBoxList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel> 
                               
                               <asp:Panel ID="PnlAnydisplayofpoliticalpartyseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table24">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label21" runat="server" SkinID="lblSkin">Any display of political party seen</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtAnydisplayofpoliticalpartyseen"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox>
                                           </td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                

                               <asp:Panel  ID="PnlInpersonverificationwiththeapplicant" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabTypeofflooring">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labTypeofflooring" runat="server" SkinID="lblskin">In person verification with the applicant</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlInpersonverificationwiththeapplicant" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>  
                                               </asp:DropDownList>
                                            </td>
                                             <td class="TDWidth">
                                                     <asp:Label ID="labIf" runat="server" SkinID="lblskin">If yes,the appearance of person matches with provided photograph for registration </asp:Label>
                                            </td>
                                            <td>
                                                     <asp:TextBox ID="txtIfyes"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox>
                                           </td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                                              
                            <asp:Panel  ID="PnlProducts" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table25">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labProducts" runat="server" SkinID="lblskin">Products</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlProducts" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Equity cash</asp:ListItem>
                                                    <asp:ListItem>Equity F & O</asp:ListItem>  
                                                    <asp:ListItem>Commodities</asp:ListItem>  
                                                    <asp:ListItem>Currency Derivatives Products</asp:ListItem>   
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>    
                                          
                               <asp:Panel  ID="PnlReasonsfornotrecommended" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table26">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labReasonsfornotrecommended" runat="server" SkinID="lblskin">Reasons for not recommended/referred</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlReasonsfornotrecommended" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Incorrect address</asp:ListItem>
                                                    <asp:ListItem>Residence doubtful</asp:ListItem>  
                                                    <asp:ListItem>Bad reputaion</asp:ListItem>  
                                                    <asp:ListItem>Poor living conditions</asp:ListItem>   
                                                    <asp:ListItem>Residence cum office</asp:ListItem>   
                                                    <asp:ListItem>Politically connected</asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>    
                                   
                             <asp:Panel  ID="PnlMatchinnegativelists" Width="100%" Visible="false" runat="server">
                                   <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabMatchinnegativelists">
                                       <tr>
                                            <td class="TDWidth">
                                               <asp:Label ID="labMatchinnegativelists" runat="server" SkinID="lblskin">Matchin negative lists</asp:Label>
                                            </td>
                                            <td style="width:2%">:</td>
                                            <td>
                                              <asp:DropDownList SkinID="ddlSkin" ID="ddlMatchinnegativelists" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                               </asp:Panel>              
                                <%--Ended by Manoj for Kanvarji Finvest Pvt Ltd --%>
                                
                                
                                          <%--    added by Abhijeet--%>
      
                         <asp:Panel ID="PnlTelecallername" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table27" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lbltelecallername" runat="server" Text="Telecaller Name :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txttelecalname" runat="server" MaxLength="50" Width="80px"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   
                                
                                
                         <asp:Panel ID="Pnltelecalleradd" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table40" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lblteleaddress" runat="server" Text="Telecaller Address :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtteleaddress" runat="server" MaxLength="50" TextMode="MultiLine"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   
                      
                      
                                <%--                                               <asp:Panel ID="Pnltelephone" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table51" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lbltelephone" runat="server" Text="Telecaller Phone No :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txttelephoneno" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   --%>
                      
                      
                      
                      
                      
                      
                                         <asp:Panel ID="Pnltelecallerlocation" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table41" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label24" runat="server" Text="Location :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txttelecallerloc" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   
                      
                    
                        <asp:Panel ID="Pnladdresslocandvisit" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table42">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Lblvisitnloc" runat="server" SkinID="lblSkin">Address Located and Visited :</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="Ddlvisited" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                                    
                        <asp:Panel ID="Pnlpersonmet" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table43">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblpersonmet" runat="server" SkinID="lblSkin">Person Met :</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="Ddlpersonmet" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                       <asp:Panel ID="Pnlvisitreason" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table44" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lblvisitreason" runat="server" Text="If NO, (Give Reaosn ) :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtvisitreason" runat="server" MaxLength="50"  TextMode="MultiLine"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   
                      
                      
                      
                                           
                        <asp:Panel ID="Pnlpersonmetreason" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table45" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lblmetreason" runat="server" Text="If NO / Any other person met:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtpersonmetreason" runat="server" MaxLength="50"  TextMode="MultiLine"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>   
                      
                      
                                            
                      
                                           
                        <asp:Panel ID="Pnlsetupdetails" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table46" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lblsetupdetails" runat="server" Text="Setup Details (Residential/ Office):"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtsetupdetails" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>  
                      
                                                             
                                           <asp:Panel ID="PnlpersonassociateofHDFCBank" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table47" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="LblpersonassociateofHDFCBank" runat="server" Text="Is he / She a associate of HDFC Bank(Put Remarks)"  TextMode="MultiLine"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtpersonassociateofHDFCBank" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                                                         <asp:Panel ID="PnlpersonnotassociateofHDFCBank" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table48" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label41" runat="server" Text="Is he/She Not associate of HDFC Bank(Put Remarks)"  TextMode="MultiLine"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtpersonnotassociateofHDFCBank" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                                            
                       <asp:Panel ID="PnltheReasonofCallingBehalfofHDFCBank" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table49" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="LbltheReasonofCallingBehalfofHDFCBank" runat="server" Text="The Reason of Calling Behalf of HDFC Bank"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxttheReasonofCallingBehalfofHDFCBank" runat="server" MaxLength="50"  TextMode="MultiLine"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                                   <asp:Panel ID="Pnlanyothrinformation" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table50" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lblanyothrinformation" runat="server" Text="Any other Information Gathered"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtanyothrinformation" runat="server" MaxLength="50" TextMode="MultiLine"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
      
                                                       <%--      ended by Abhijeet--%>
                          
                                 
                               
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
                                                <asp:TextBox ID="txtDate1" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <asp:DropDownList ID="ddlSubSat1" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
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
                                                <asp:DropDownList ID="ddlSubSat2" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
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
                                                <asp:DropDownList ID="ddlSubSat3" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat3" runat="server" Text=""></asp:Label>
                                        </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                             
                                
                                <asp:Panel ID="pnlRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRemark">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRemark" runat="server" SkinID="lblSkin">Tele Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 750);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                  <asp:Panel ID="pnloverallRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table7">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label3" runat="server" SkinID="lblSkin">Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                 <asp:TextBox ID="txtoverallRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 750);" SkinID="txtSkin" Width="488px"></asp:TextBox>
                                             </td>
                                            </tr>
                                            
                                            <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label22" runat="server" SkinID="lblSkin">Standard Remark</asp:Label>
                                            </td>                                            
                                           <td style="width:2%">:</td>
                                            <td>
                                            <%--added by SANKET for HDFC Ergo--%>
                                            <asp:DropDownList ID="ddlStandardRemark" runat="server" SkinID="ddlSkin" ValidationGroup="grValidate"  >
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem>Address Incomplete</asp:ListItem>
                                                <asp:ListItem>Address Untraceable</asp:ListItem>
                                                <asp:ListItem>Company Closed</asp:ListItem>
                                                <asp:ListItem>Door Locked Existence Not Confirm</asp:ListItem>
                                                <asp:ListItem>Door Locked Existence Confirm</asp:ListItem>
                                                <asp:ListItem>Entry Not Allowed</asp:ListItem>
                                                <asp:ListItem>Existence Confirm Details Refused</asp:ListItem>
                                                <asp:ListItem>Existence Confirmed</asp:ListItem>
                                                <asp:ListItem>Existence Not Confirmed</asp:ListItem>
                                                <asp:ListItem>Given Address Belongs To Applicant But Given On Rent</asp:ListItem>
                                                <asp:ListItem>Given Address Is Demolished</asp:ListItem>
                                                <asp:ListItem>Given Address Under Construction</asp:ListItem>
                                                <asp:ListItem>Given Address Under Renovation</asp:ListItem>
                                                <asp:ListItem>Met Self Details Refused</asp:ListItem>
                                                <asp:ListItem>No Such Company At Given Address</asp:ListItem>
                                                <asp:ListItem>No Such Person Exist At Given Address</asp:ListItem>
                                                <asp:ListItem>OCL</asp:ListItem>
                                                <asp:ListItem>Person Left The Job</asp:ListItem>
                                                <asp:ListItem>Person Shifted From Given Address</asp:ListItem>
                                                <asp:ListItem>Return Back To Client</asp:ListItem>
                                                <asp:ListItem>Grand Total</asp:ListItem>
                                                <asp:ListItem>Person Is Insurance Holder Not Agent</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--end by SANKET--%>                                             
                                             </td>
                                             </tr>

                                    </table>
                                </asp:Panel>         
                                <br />
                                <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" runat="server" Text="Submit" ValidationGroup="grValidate" OnClick="btnSubmit_Click"/>
                                                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                         
                                        </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidCaseID" runat="server" />
                                         <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                          <asp:HiddenField ID="hidVerifierID" runat="server" />
                                          <asp:HiddenField ID="hidMode" runat="server" />
                                            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
                                </asp:Panel>
            
                                   
                                <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server" ControlToValidate="txtDate1"
                                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server" ControlToValidate="txtDate2"
                                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revDate3" runat="server" ControlToValidate="txtDate3"
                                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtTime1"
                                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server" ControlToValidate="txtTime2"
                                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revTime3" runat="server" ControlToValidate="txtTime3"
                                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revVerifierDate" runat="server" ControlToValidate="txtVerifierDate"
                                    Display="None" ErrorMessage="Please enter valid date format for Verifier." SetFocusOnError="True"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revVerifierTime" runat="server" ControlToValidate="txtVerifierTime"
                                    Display="None" ErrorMessage="Please enter valid time format for Verifier." SetFocusOnError="True"
                                    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revSupervisorDate" runat="server" ControlToValidate="txtSupervisorDate"
                                    Display="None" ErrorMessage="Please enter valid date format for Supervisor."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSupervisorTime"
                                    Display="None" ErrorMessage="Please enter valid time format for Supervisor."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                            <%--added by sanket on 13/02/2014--%>         
                                    <asp:RequiredFieldValidator ID="rfvAreaname" runat="server"
                                         ErrorMessage="Please Select Area Name." ControlToValidate="ddlAreaname"
                                        InitialValue="0" Display="None" ValidationGroup="grValidate"  >
                                    </asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvStandardRemark" runat="server"
                                         ErrorMessage="Please Select Standard Remark." ControlToValidate="ddlStandardRemark"
                                        InitialValue="--SELECT--" Display="None" ValidationGroup="grValidate"  >
                                    </asp:RequiredFieldValidator> 
                            <%--End by sanket--%>                                     
                                <asp:ValidationSummary ID="vsValidate" runat="server" ValidationGroup="grValidate"
                                    ShowMessageBox="True" ShowSummary="False" />


                <asp:HiddenField ID="hdnTransStart" runat="server" />
                               </asp:TableCell></asp:TableRow>
                    </asp:Table>
                </td>
                </tr>
                </table>
                <table>
    <tr>
    <td><asp:LinkButton ID="lbRV" runat="server" Text="RV" Width="22px" OnClick="lbRV_Click" Visible="False"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBV" runat="server" Text="BV" Width="22px" Visible="False" OnClick="lbBV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbCA" runat="server" Text="CA" Width="22px" Visible="False" OnClick="lbCA_Click" ></asp:LinkButton>
    </td>
    </tr>
   
    </table>
     <asp:SqlDataSource ID="sdsFE" runat="server" 
         ProviderName="System.Data.OleDb" SelectCommand="SubStatus_Master;1"
         SelectCommandType="StoredProcedure"></asp:SqlDataSource>
     <br />
     <asp:HiddenField ID="hdnSupID" runat="server" />
        </fieldset>
        </asp:Content>
