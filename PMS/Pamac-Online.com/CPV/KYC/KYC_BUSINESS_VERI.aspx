<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" Theme="skinFile" CodeFile="KYC_BUSINESS_VERI.aspx.cs" Inherits="CPV_KYC_KYC_BUSINESS_VERI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
 <fieldset>
        <legend class="FormHeading">Business Verification</legend>
         <table cellpadding="0" cellspacing="0" border="0" id="Table1" runat="server" width="100%"
            style="background-color: #e7f6ff">
             <tr>
                <td>
                </td>
                <td>    
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
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblrow" runat="server">
                            <asp:TableCell ID="tblCell" runat="server">
                                <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtRefNo" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label32" runat="server" Text="Employee Type"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEmpType"  Enabled="false"  runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>MSP</asp:ListItem>
                                        <asp:ListItem>POS</asp:ListItem>                                                    
                                    </asp:DropDownList>
                                    </td>
                                    </tr>                                        
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlInitiationDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="15" ReadOnly="True" ></asp:TextBox>
                                         
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlDetailsOfCustomer" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDetailsOfCustomer" runat="server" Text="DETAILS OF CUSTOMER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlCompanyType" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyType" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Company Type"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlCompanyType" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Govt.</asp:ListItem>
                                        <asp:ListItem>PSU</asp:ListItem>            
                                        <asp:ListItem>MNC</asp:ListItem>            
                                        <asp:ListItem>Pvt. Ltd</asp:ListItem>            
                                        <asp:ListItem>Public Ltd.</asp:ListItem>            
                                        <asp:ListItem>Proprietorship</asp:ListItem> 
                                        <asp:ListItem>Partnership</asp:ListItem>           
                                        <asp:ListItem>HUF</asp:ListItem>  
                                        <asp:ListItem>Others</asp:ListItem>  
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEntityType" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblEntityType" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblEntityType" runat="server" Text="Entity Type"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEntityType" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Proprietorship</asp:ListItem> 
                                        <asp:ListItem>Partnership</asp:ListItem>           
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfFirm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lnlNameOfFirm" runat="server" Text="Name of firm/Establishment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
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
                                                    Constitutions</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlConstitution" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Prop</asp:ListItem>
                                                    <asp:ListItem>Partnership</asp:ListItem>
                                                    <asp:ListItem>Pvt Ltd Co</asp:ListItem>            
                                                    <asp:ListItem>Public Ltd Co</asp:ListItem> 
                                                    <asp:ListItem>HUF</asp:ListItem>
                                                    <asp:ListItem>Others (pls specify)</asp:ListItem>            
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
                                                <asp:Label ID="lblLocalityType" runat="server" SkinID="lblSkin">
                                                    Area/Locality Type</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Residential</asp:ListItem>
                                                    <asp:ListItem>Commercial</asp:ListItem>                                                
                                                    <asp:ListItem>Industrial</asp:ListItem>            
                                                    <asp:ListItem>Business Centre</asp:ListItem> 
                                                    <asp:ListItem>Resi cum Comm</asp:ListItem>
                                                    <asp:ListItem>Slum/Chawl</asp:ListItem> 
                                                    <asp:ListItem>Underdeveloped</asp:ListItem>      
                                                    <asp:ListItem>Shop Office Complex</asp:ListItem>                                                 
                                                    <%--Added by SANKET for Kunverji--%>
                                                    <asp:ListItem>Godown</asp:ListItem>
                                                    <asp:ListItem>Small Scale Industrial Area</asp:ListItem>
                                                    <asp:ListItem>Plant</asp:ListItem>
                                                    <asp:ListItem>Others</asp:ListItem>
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
                                    <asp:TextBox SkinID="txtSkin"  ID="txtfurniture" runat="server" MaxLength="500"></asp:TextBox>                                    
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
                                                <asp:Label ID="lblIfNotRecommended"  runat="server" SkinID="lblSkin">
                                                   Observations of Employee conducting CPV if Not recommended</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin"  ID="ddlIfNotRecommended" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>                                              
                                                    <asp:ListItem>Address not traceable</asp:ListItem>
                                                    <asp:ListItem>Detail mismatch</asp:ListItem>
                                                    <asp:ListItem>Applicant does not exist</asp:ListItem>            
                                                    <asp:ListItem>Defaulter/Bad market reputation</asp:ListItem> 
                                                    <asp:ListItem>Entry not allowed</asp:ListItem>            
                                                    <%--Added by SANKET for Kunverji--%>
                                                    <asp:ListItem>Incorrect address</asp:ListItem>
                                                    <asp:ListItem>Address/Business doubtful</asp:ListItem>  
                                                    <asp:ListItem>Poor Business conditions</asp:ListItem>   
                                                    <asp:ListItem>Residence cum office</asp:ListItem>   
                                                    <asp:ListItem>Politically connected</asp:ListItem>
                                                       <asp:ListItem>Positve observation</asp:ListItem>   
                                                       <asp:ListItem>Negative observation</asp:ListItem>   
                                                    <%--END for Kunverji--%>
                                                    <asp:ListItem>Others</asp:ListItem> 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfOtherRecommended" Visible="false" runat="server" SkinID="lblSkin">
                                                   if Recommended OtherSpecify</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                            <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherRecommended" Visible="false" runat="server" MaxLength="255">
                                            </asp:TextBox>                                    
                                        </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label36" runat="server" Visible="false" SkinID="lblSkin">Documents Verified</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDocVeri" Visible="false" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                                
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label37" runat="server" Visible="false" SkinID="lblSkin">Neighbour is Aware</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" Visible="false" ID="ddlNeighAware" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                                
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label38" runat="server" SkinID="lblSkin">Authorised Signatory Met in Person</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlAuthoSign" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                                
                                                </asp:DropDownList>
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
                                
                                
                                 <%--///Added by kamal matekar for Hdfc_Liab PDf format//--%>

                                <asp:Panel ID="pnlLocalityTypeForFemu" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table8">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocalityTypeForFemu" runat="server" SkinID="lblSkin">Locality Type</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityTypeForFemu" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Lower Middle Class</asp:ListItem>
                                                    <asp:ListItem>Middle Class</asp:ListItem>
                                                    <asp:ListItem>Upper Middle Class</asp:ListItem>
                                                    <asp:ListItem>Posh</asp:ListItem>
                                                    <asp:ListItem>Village Area</asp:ListItem>
                                                    <asp:ListItem>Slums</asp:ListItem>
                                                    <asp:ListItem>Average</asp:ListItem> 
                                                    <asp:ListItem>Good</asp:ListItem> 
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlDoNeighbourShopsKnowTheCustomer" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table9">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDoNeighbourShopsKnowTheCustomer" runat="server" SkinID="lblSkin">Do Neighbour/Neighboring shops or offices know the customer</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDoNeighbourShopsKnowTheCustomer" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAddressOfNeighbour" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table10">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblAddressOfNeighbour" runat="server" SkinID="lblSkin">Name & Address Neighbours</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td >
                                                <asp:TextBox ID="txtAddressOfNeighbour" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="80%" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                                             
                               <asp:Panel ID="pnlOfficeEquipmentSeen" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeEquipmentSeen" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOfficeEquipmentSeen" runat="server" Text="Office Equipments Seen"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="chkOfficeEquipmentSeen" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
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
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOfficeEquipmentSeenOther" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtOfficeEquipmentSeenOther" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>

                           <%--///ended by kamal matekar for Hdfc_Liab PDf format//--%>
                                
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
                                
                                <asp:Panel ID="pnlApperance" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table15">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label7" runat="server" SkinID="lblSkin" Text="Appearance/Describe Building"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDesBuild" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Posh</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>                                                   
                                                    <asp:ListItem>Average</asp:ListItem>                                                   
                                                    <asp:ListItem>Poor</asp:ListItem>                                                    
                                                    <asp:ListItem>Shabby</asp:ListItem>                                                   
                                                    <asp:ListItem>Unfurnished</asp:ListItem>                                                    
                                                    <asp:ListItem>Semi-furnished</asp:ListItem>                                                    
                                                    <asp:ListItem>Excellent</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>                                                                           
                                    </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlAutoSign" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table14">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label10" runat="server" SkinID="lblSkin">Authorised Signatory met in person (Yes/No)If No, reason :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtIfNamePLate" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>     
                                    </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlBuilding" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table13">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label9" runat="server" SkinID="lblSkin" Text="Building"></asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlBuilding" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Easy</asp:ListItem>
                                                    <asp:ListItem>Difficult</asp:ListItem>                                                                                                       
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <%--************************************--%>
                                
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
                                                <asp:Label ID="lblBranchCode" runat="server" SkinID="lblSkin">Branch Code :</asp:Label></td>
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
                                                <asp:Label ID="lblRmName" runat="server" SkinID="lblSkin">Name of Sourcing RM / Derector :</asp:Label></td>
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
                                 <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table11">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label5" runat="server" SkinID="lblSkin">Name of the Person contacted during Verification :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>   
                                
                                
                                 <%--Added by Rupesh--%> 
                                
                                
                                 <asp:Panel ID="Pnlcomputerseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblcomputerseen">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblcomputerseen" runat="server" SkinID="lblSkin">No Of Computer seen</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtcomputerseen" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="PnlTelphoneseen" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblTelphoneseen">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTelphoneseen" runat="server" SkinID="lblSkin">No Of Tele phone seen</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtTelephoneseen" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>
                               
                               <asp:Panel ID="PnlfloorOfbuliding" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblfloorOfbuliding">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblfloorOfbuliding" runat="server" SkinID="lblSkin">Total floor of the buliding</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txttotalfloorofbuliding" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel>     
                               
                               <asp:Panel ID="Pnlcustomerexiswhichfloor" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblcustomerexiswhichfloor">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblcustomerexiswhichfloor" runat="server" SkinID="lblSkin">customer resi or office existing on which floor</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtcustomerexiswhichfloor" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                               </asp:Panel> 
                                
                                <%--Added by Rupesh--%> 
                                
                                
                                
                                
                                
                                
                                
                                
                                
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
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label8" runat="server" SkinID="lblSkin">Name of BSP doing telephonic verification :</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtBspName" runat="server" Width="80%" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
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
                                
                                <asp:Panel ID="pnlNameBankOfficerCoduct" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table16">
                                        <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label11" runat="server" Text="Name of Bank Officer Conducting Verification"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfficer" runat="server"  Width="80%"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
                                            
                               <asp:Panel ID="pnlSscCode" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table17">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label12" runat="server" Text="Site Verifier SSC Code"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtSiteVerifier" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlDesgBankOff" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table18">
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label20" runat="server" Text="Designation of Bank Officer"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" ID="txtDesgBO" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    </table>
                                </asp:Panel>
                                                                                                                            
                                <asp:Panel ID="pnlNameBankOfficer" runat="server" Width="100%" Visible="false">
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
                                
                                <asp:Panel ID="pnlTimeReturn" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table31" style="width:100%" runat="server"> 
                                     <tr>
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="Label13" runat="server"  Text="At The Time Of RETURNED DELIVERABLES"></asp:Label>
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
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlBblSign" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table32" style="width:100%" runat="server"> 
                                     <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label14" runat="server" SkinID="lblSkin">Confirmation from BBL/BSDL Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign1" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>                  
                                </table>
                                </asp:Panel>

                                <asp:Panel ID="pnlConfSite" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table33" style="width:100%" runat="server"> 
                                      <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label15" runat="server" SkinID="lblSkin">Confirmation of Site verifier Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign2" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>               
                                </table>
                                </asp:Panel>
                                
                              <asp:Panel ID="pnlBsdlSign" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table34" style="width:100%" runat="server"> 
                                       <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label16" runat="server" SkinID="lblSkin">Confirmation from BSDL Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign3" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>            
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlBblDecSign" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table35" style="width:100%" runat="server"> 
                                     <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label17" runat="server" SkinID="lblSkin">BBL Declaration Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign4" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>          
                                </table>
                                </asp:Panel>

                                <asp:Panel ID="pnlConfBblBsdlAll" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table36" style="width:100%" runat="server"> 
                                      <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label18" runat="server" SkinID="lblSkin">Confirmation from BBL/BSDL-required in all cases Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign5" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>        
                                </table>
                                </asp:Panel>

                                <asp:Panel ID="pnlBblDecSourceSign" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table37" style="width:100%" runat="server"> 
                                       <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label19" runat="server" SkinID="lblSkin">BBL Declaration-required at the time of sourcing Signature</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSign6" runat="server" SkinID="txtSkin" MaxLength="500"></asp:TextBox></td>
                                        </tr>    
                                </table>
                                </asp:Panel>

                               <%-- *******************************--%>
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
                                        </table>
                                     </asp:Panel>             
                                
                                                                          
                                <%--end code--%>                                                          
                                
                                 <%--added by TCM client releted by santosh--%>
                                <asp:Panel ID="pnlWebsite" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblWebsite" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblWebsite" runat="server" Text="Website"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtwebsite" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckSince" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckSince" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckSince" runat="server" Text="Company Registration Check Since"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckSince" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckSinceRegNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckSinceRegNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckSinceRegNo" runat="server" Text="Company Registration Check Regd No."></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckSinceRegNo" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckRemark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckRemark" runat="server" Text="Company Registration Check Remarks"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckRemark" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlLocProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblLocProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblLocProfile" runat="server" Text="Site Visit Location Profile & general description"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLocProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlbldgProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblbldgProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblbldgProfile" runat="server" Text="Site Visit Building Profile with general description"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtbldgProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfile" runat="server" Text="Site Visit Floor Profile Right neighbour"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileLeftNeigh" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfileLeftNeigh" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileLeftNeigh" runat="server" Text="Site Visit Floor Profile left neighbour"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileLeftNeigh" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileFlrAb" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileFlrAb" runat="server" Text="Site Visit Floor Profile Floor Above"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileFlrAb" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileFlrBl" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfileFlrBl" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileFlrBl" runat="server" Text="Site Visit Floor Profile Floor Below"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileFlrBl" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlNameBoardOutOffice" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameBoardOutOffice" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameBoardOutOffice" runat="server" Text="Name Board Details Outside office"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameBoardOutOffice" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                
                                
                                     
                                  <%--    added by Abhijeet--%>
      
                         <asp:Panel ID="PnlTelecallername" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table12" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lbltelecallername" runat="server" Text="Telecaller Name :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txttelecalname" runat="server" MaxLength="50" Width="60%"></asp:TextBox>                                    
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
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtteleaddress" runat="server" MaxLength="50" TextMode="MultiLine" Width="60%"></asp:TextBox>                                    
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
                                        <asp:Label SkinID="lblSkin" ID="Label6" runat="server" Text="Location :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txttelecallerloc" runat="server" MaxLength="50" Width="60%"></asp:TextBox>                                    
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
                                                  <%--  <asp:ListItem>NA</asp:ListItem>--%>
                                                  
                                                   <asp:ListItem>-Select-</asp:ListItem>
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
                                            <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtpersonmet" runat="server"   TextMode="SingleLine" Width="60%"   ValidationGroup="grValidate"></asp:TextBox>                                    
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
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtvisitreason" runat="server"   TextMode="MultiLine" Width="60%"></asp:TextBox>                                    
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
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtpersonmetreason" runat="server"   TextMode="MultiLine" Width="60%"  ValidationGroup="grValidate"></asp:TextBox>                                    
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
                                    <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlsetupdetails" runat="server" AutoPostBack="false">
                                                 <asp:ListItem>-Select-</asp:ListItem>
                                                    <asp:ListItem>Residential</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                </asp:DropDownList>
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
                                   <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlassociatehdfc" runat="server" AutoPostBack="false">
                                                     <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
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
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtpersonnotassociateofHDFCBank" runat="server"  Width="60%"></asp:TextBox>                                    
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
                                    <asp:TextBox SkinID="txtSkin"  ID="TxttheReasonofCallingBehalfofHDFCBank" runat="server"   TextMode="MultiLine"></asp:TextBox>                                    
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
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtanyothrinformation" runat="server"  TextMode="MultiLine" Width="60%"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
      
                                                       <%--      ended by Abhijeet--%>
                                                       
                                                       
                                                       
                                             <%--      added by Abhijeet--%>
                                             
                                             
                                   <asp:Panel ID="Pnllegalname" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table52" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Lbllegalname" runat="server" Text="Legal Name :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="Txtlegalname" runat="server" MaxLength="50" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                                        
                                <asp:Panel ID="Pnlvisitno" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table53">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Lblvisitno" runat="server" SkinID="lblSkin">Visit Numbers :</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="Ddlvisitno" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                     <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                     <asp:ListItem>Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                   <asp:Panel ID="PnlReachable" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table54">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="LblReachable" runat="server" SkinID="lblSkin"> Reachable:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlreachable" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                
                                   <asp:Panel ID="Pnlsetuplocation" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table55">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblsetuplocation" runat="server" SkinID="lblSkin"> Workspace Setup Location:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlsetuplocation" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Commercial Space</asp:ListItem>
                                                    <asp:ListItem>Residential Area</asp:ListItem>
                                                    <asp:ListItem>No Setup/Home</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                   <asp:Panel ID="Pnlboardtype" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table56">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblboardtype" runat="server" SkinID="lblSkin"> If Yes,Board Type:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlboardtype" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Permanent</asp:ListItem>
                                                    <asp:ListItem>Temprory</asp:ListItem>
                                               
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                     <asp:Panel ID="Pnlconnectivity" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table57" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label42" runat="server" Text="Connectivity:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="Chklconnectivity" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem>Landline Number</asp:ListItem>
                                        <asp:ListItem>Fax</asp:ListItem> 
                                        <asp:ListItem>Internet</asp:ListItem>
                                                                        
                                    </asp:CheckBoxList>                              
                                  
                                    </td>
                                    </tr>
                                    
                                    
                                </table>
                                </asp:Panel>
                                          
                                          
                             <%--        
                                   <asp:Panel ID="Pnlconnectivity" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table57">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label42" runat="server" SkinID="lblSkin"> Connectivity:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlconnectivity" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Landline Number</asp:ListItem>
                                                    <asp:ListItem>Fax</asp:ListItem>
                                                    <asp:ListItem>Internet</asp:ListItem>
                                               
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>         --%>
                                
                                
                                
                                
                                          
                                          
                                                                             <asp:Panel ID="pnlproperarea" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table58">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblproperarea" runat="server" SkinID="lblSkin"> Proper reception area? :</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlproperarea" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                               
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                                                              <asp:Panel ID="Pnlestablishmentcertificate" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table59">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblestablishmentcertificate" runat="server" SkinID="lblSkin"> Shops & Establishment Certificate display:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlestablishmentcertificate" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Clear Display</asp:ListItem>
                                                    <asp:ListItem>Hidden Display</asp:ListItem>
                                                    <asp:ListItem>No Display</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                                          
                                                                              <asp:Panel ID="Pnltypeoffurnishing" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table60">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lbltypeoffurnishing" runat="server" SkinID="lblSkin"> Type of furnishing & fixtures:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddltypeoffurnishing" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                    <asp:Panel ID="PnlPremisesMaintenanceQuality" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table61" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label46" runat="server" Text="Premises Maintenance & Quality:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="ChklPremisesMaintenanceQuality" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                                                     
                                                    <asp:ListItem>Clean & Hygienic</asp:ListItem>
                                                    <asp:ListItem>Proper Lighting</asp:ListItem>
                                                    <asp:ListItem>Sturdy Built</asp:ListItem>
                                                                        
                                    </asp:CheckBoxList>                             
                                  
                                    </td>
                                    </tr>
                                    
                                    
                                </table>
                                </asp:Panel>
                                
                               <%-- 
                                                                                <asp:Panel ID="PnlPremisesMaintenanceQuality" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table61">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="LblPremisesMaintenanceQuality" runat="server" SkinID="lblSkin"> Premises Maintenance & Quality:</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlPremisesMaintenanceQuality" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Clean & Hygienic</asp:ListItem>
                                                    <asp:ListItem>Proper Lighting</asp:ListItem>
                                                    <asp:ListItem>Sturdy Built</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>--%>
                                          
                                          
                                          
                                          
                                                                                <asp:Panel ID="Pnlchildlabourmarchant" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table62">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblchildlabourmarchant" runat="server" SkinID="lblSkin">Presence of Child Labour (As per Merchant) </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlchildlabourmarchant" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                           
                                                                                <asp:Panel ID="Pnlchildlabourneighbours" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table63">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblchildlabourneighbours" runat="server" SkinID="lblSkin">Presence of Child Labour (As per Neighbour(s)) </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlchildlabourneighbours" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                
                                
                                              
                                                                                <asp:Panel ID="Pnlchildlabouremployees" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table64">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblchildlabouremployees" runat="server" SkinID="lblSkin">Presence of Child Labour (As per Employee(s)) </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlchildlabouremployees" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                
                                
                                                
                                                                                <asp:Panel ID="Pnlproducttype" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table65">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblproducttype" runat="server" SkinID="lblSkin">Product Type </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlproducttype" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Physical Goods</asp:ListItem>
                                                    <asp:ListItem>Services</asp:ListItem>
                                                   <asp:ListItem>Digital Goods</asp:ListItem>
                                                   <asp:ListItem>Unsure</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                
                                
                                
                                
                                                
                                                                                <asp:Panel ID="Pnllogistics" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table66">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLogistics" runat="server" SkinID="lblSkin">Logistics : </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLogistics" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Owned</asp:ListItem>
                                                    <asp:ListItem>3rd Party</asp:ListItem>
                                                   <asp:ListItem>None</asp:ListItem>
                                                   <asp:ListItem>Not Applicable</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                
                                
                                          
                                                                                <asp:Panel ID="pnlInventory" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table67">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblInventory" runat="server" SkinID="lblSkin">Inventory : </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlInventory" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes (Separate Warehouse)</asp:ListItem>
                                                    <asp:ListItem>Yes(at Office)</asp:ListItem>
                                                   <asp:ListItem>No (Just in time Procurement)</asp:ListItem>
                                                   <asp:ListItem>Not Applicable</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                
                                
                                
                                                                       <asp:Panel ID="pnlInventorySize" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table68">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblInventorySize" runat="server" SkinID="lblSkin">Inventory Size: </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlInventorySize" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>0-50</asp:ListItem>
                                                    <asp:ListItem>50-100</asp:ListItem>
                                                   <asp:ListItem>100-500</asp:ListItem>
                                                   <asp:ListItem>500+</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                      <asp:Panel ID="PnlREGISTERATIONPROOF" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table69" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label44" runat="server" Text="REGISTERATION PROOF:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="ChklREGISTERATIONPROOF" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                                 
                                                    <asp:ListItem>Certificate of Incorporation</asp:ListItem>
                                                    <asp:ListItem>MoA & AoA</asp:ListItem>
                                                   <asp:ListItem>Registered Partnership Deed</asp:ListItem>
                                                   <asp:ListItem>Registered Trust Deed</asp:ListItem>
                                                                        
                                    </asp:CheckBoxList>                              
                                  
                                    </td>
                                    </tr>
                                    
                                    
                                </table>
                                </asp:Panel>
                                <%--
                                              <asp:Panel ID="PnlREGISTERATIONPROOF" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table69">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblREGISTERATIONPROOF" runat="server" SkinID="lblSkin">REGISTERATION PROOF: </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlREGISTERATIONPROOF" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Certificate of Incorporation</asp:ListItem>
                                                    <asp:ListItem>MoA & AoA</asp:ListItem>
                                                   <asp:ListItem>Registered Partnership Deed</asp:ListItem>
                                                   <asp:ListItem>Registered Trust Deed</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  --%>
                                
                                
                                
                               <%--      <asp:Panel ID="PnlADDITIONALDOCUMENTS" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table70">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblADDITIONALDOCUMENTS" runat="server" SkinID="lblSkin">ADDITIONAL DOCUMENTS: </asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlADDITIONALDOCUMENTS" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Jewelry/ High Value Goods of any sort</asp:ListItem>
                                                    <asp:ListItem>Health Supplements / Food / Edible Products</asp:ListItem>
                                                   <asp:ListItem>Courses affiliated to an education establishment</asp:ListItem>
                                                   <asp:ListItem>Professional Advisories</asp:ListItem> 
                                                  <asp:ListItem>Transit Insurance</asp:ListItem>
                                                   <asp:ListItem>Food and Drug License</asp:ListItem>
                                                   <asp:ListItem>UGC Certificate</asp:ListItem>
                                                      <asp:ListItem>Qualifying Certificate</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  --%>
                                
                                     <asp:Panel ID="PnlADDITIONALDOCUMENTS" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table70" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label45" runat="server" Text="ADDITIONAL DOCUMENTS:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="ChklADDITIONALDOCUMENTS" runat="server" RepeatDirection="Horizontal" RepeatColumns="8" >
                                                   <asp:ListItem>Jewelry | High Value Goods of any sort</asp:ListItem>
                                                    <asp:ListItem>Health Supplements | Food | Edible Products</asp:ListItem>
                                                   <asp:ListItem>Courses affiliated to an education establishment</asp:ListItem>
                                                <%--   <asp:ListItem>Professional Advisories</asp:ListItem> 
                                                  <asp:ListItem>Transit Insurance</asp:ListItem>
                                                   <asp:ListItem>Food and Drug License</asp:ListItem>--%>
                                                   <asp:ListItem>UGC Certificate</asp:ListItem>
                                                     <%-- <asp:ListItem>Qualifying Certificate</asp:ListItem>--%>
                                                                        
                                    </asp:CheckBoxList>                              
                                  
                                    </td>
                                    </tr>
                                    
                                    
                                </table>
                                </asp:Panel>
                                          
                                          
                                            <asp:Panel ID="Pnlwarehouseaddress" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table71" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblwarehouseaddress" runat="server" Text="If Warehouse, Address :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtwarehouseaddress" runat="server" MaxLength="50" TextMode="MultiLine" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                                   
                                            <asp:Panel ID="PnlTop1Item" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table72" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTop1Item" runat="server" Text="Top 1st Item :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtTop1Item" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                          
                                            <asp:Panel ID="PnlTop2Item" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table73" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTop2Item" runat="server" Text="Top 2nd Item :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtTop2Item" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                               <asp:Panel ID="PnlTop3Item" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table74" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTop3Item" runat="server" Text="Top 3rd Item :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtTop3Item" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                                          
                                               <asp:Panel ID="PnlTop4Item" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table75" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTop4Item" runat="server" Text="Top 4th Item :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtTop4Item" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                                          
                                          
                                          
                                 
                                   
                                             <asp:Panel ID="pnlYearsWorkedInmarchant" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsWorkedInmarchant" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsWorkedInmarchant" runat="server" Text="Age of occupation of current location(marchant)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtYearsWorkedInmarchant" runat="server" MaxLength="2"></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtMthsWorkedInmarchant"  runat="server" MaxLength="2"></asp:TextBox>Mths                      
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
                                
                                             <asp:Panel ID="pnlYearsWorkedInnei" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsWorkedInnei" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsWorkedInnei" runat="server" Text="Age of occupation of current location(nei)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtYearsWorkedInnei" runat="server" MaxLength="2"></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtMthsWorkedInnei"  runat="server" MaxLength="2"></asp:TextBox>Mths                      
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
           
           
           
               <asp:Panel ID="pnlYearsWorkedInemp" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsWorkedInemp" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsWorkedInemp" runat="server" Text="Age of occupation of current location(employee)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtYearsWorkedInemp" runat="server" MaxLength="2"></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtMthsWorkedInemp"  runat="server" MaxLength="2"></asp:TextBox>Mths                      
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           
           
           
 <asp:Panel ID="pnlnameboardpremises" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table76">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblnameboard" runat="server" SkinID="lblSkin">Name board outside premises?</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlnameboard" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
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
                            <asp:ListItem>1-10</asp:ListItem>
                            <asp:ListItem>10-50</asp:ListItem>
                            <asp:ListItem>50+</asp:ListItem>
                           
                </asp:DropDownList>                
            </td>
            </tr>
            </table>    
     </asp:Panel>
     
     
     
         
                                               <asp:Panel ID="Pnlidproofs" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table77" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblidproof" runat="server" Text="ID Proof :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtidproof" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                      
                                               <asp:Panel ID="Pnladdressprrof" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table78" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lbladdressprrof" runat="server" Text="Address Proof :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtaddressproof" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                      
                                               <asp:Panel ID="pnlworktimedurationfrom" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table79" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblworktimedurationfrom" runat="server" Text="Work Timings/ Duration (from) :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtworktimedurationfrom" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                      
                                               <asp:Panel ID="pnlworktimedurationto" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table80" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblworktimedurationto" runat="server" Text="Work Timings/ Duration (To) :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtworktimedurationto" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                      
                           
                      
                                               <asp:Panel ID="pnlworktimedurationdays" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table81" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblworktimedurationdays" runat="server" Text="Work Timings/ Duration (Days) :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtworktimedurationdays" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                                          
                                          
                                                                              <asp:Panel ID="pnlfireextinguisher" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table51">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblfire" runat="server" SkinID="lblSkin"> Fire Extinguisher present ?</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlfire" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                          
                                          
                                          
                                             
                                                <%--      ended by Abhijeet--%>
                                                
                                                
                                                
                                                
                                                  <%--     added  by Abhijeet for Kotak--%>
                                                  
                                                  
                                                                      <asp:Panel ID="Pnlproductdealingin" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table88" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label52" runat="server" Text="Product Dealing in  :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtproductdealingin" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                      
                                         
                                                                      <asp:Panel ID="Pnlturnover" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table89" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label53" runat="server" Text=" Turnover :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtturnover" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                                                                                        <asp:Panel ID="Pnldoccumentryprrof" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table90">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label54" runat="server" SkinID="lblSkin">Doccumentry Proof :</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddldoccumentryproof" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>TIN</asp:ListItem>
                                                    <asp:ListItem>ITR</asp:ListItem>
                                                    <asp:ListItem>PAN</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                                       <asp:Panel ID="PnlNameofindividual" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table91" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label55" runat="server" Text=" Name of individual :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtNameofindividual" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                      
                                                <asp:Panel ID="Pnlindividualpersonmet" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table92" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label56" runat="server" Text=" Name of individual Person Met:"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtIndividualPersonMet" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                               
                               
                               
                                         <asp:Panel ID="PnldoccumentryProofFurnished" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table93" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label57" runat="server" Text="Documentary proof furnished  if any: PAN CARD :"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="TxtdoccumentryProofFurnished" runat="server" MaxLength="50"  ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                          </table>
                      </asp:Panel>    
                               
                                   <asp:Panel ID="PnlRecommondation" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table94">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label58" runat="server" SkinID="lblSkin">Recommendation : Ok to Process/Not OK to process</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRecommondation" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Ok to Process</asp:ListItem>
                                                    <asp:ListItem>Not OK to process</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                                  
                                                  
                                                <%--      ended by Abhijeet  Kotak --%>
                                                
                                                
                                
                                
                                <asp:Panel ID="pnlNameBoardLobbyArea" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameBoardLobbyArea" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameBoardLobbyArea" runat="server" Text="Name Board Details Lobby Area"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameBoardLobbyArea" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAssoCompany" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAssoCompany" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAssoCompany" runat="server" Text="Associate comapny/other occupation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAssoCompany" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                  <asp:Panel ID="pnlGenInterior" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblGenInterior" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblGenInterior" runat="server" Text="General Interior Profile"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtGenInterior" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                   <asp:Panel ID="pnlNoWorkstations" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoWorkstations" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoWorkstations" runat="server" Text="No. of Workstations"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoWorkstations" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlOwnerCabin" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOwnerCabin" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOwnerCabin" runat="server" Text="Whether Owner has a separate cabin"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOwnerCabin" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnllandloard" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tbllandloard" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lbllandloard" runat="server" Text="Landlord(if any)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtlandloard" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyResi" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyResi" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyResi" runat="server" Text="Propery valuation Residential"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyResi" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyComm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyComm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyComm" runat="server" Text="Propery valuation Commercial"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyComm" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyShop" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyShop" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyShop" runat="server" Text="Propery valuation Shoppinng"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyShop" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <%--///////////////////////end of code/////////////////////--%>
                                                        
                                <asp:Panel ID="pnlBusinessAddress" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessAddress" runat="server" Text="Business Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtBusinessAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlBusinessPincode" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessPincode" runat="server" Text="Business Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusinessPincode" runat="server" MaxLength="20"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlBusinessTelNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessTelNo" runat="server" Text="Business Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusinessTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                 
                                <asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false"> 
                                
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table4">
                                        <tr>
                                       
                                        <td class="TDWidth">
                                           <asp:Label SkinID="lblSkin" ID="Label1" Visible="false" runat="server">Proprietor/Partner</asp:Label>
                                           </td>                                            
                                           <td style="width:2%">:</td>
                                           <td>
                                     <asp:DropDownList SkinID="ddlSkin" Visible="false" ID="ddlproperietorpartener" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList> 
                                    </td>
                                    </tr>
                                    </table>
                                    
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNameOfPersonContacted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameOfPersonContacted" runat="server">Name of Person contacted/Proprotor</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfPersonContacted" runat="server" MaxLength="500"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblDesignation" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtDesignation" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoOfYearsInCurrentEmployment" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYearsInCurrentEmployment" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoOfYearsInCurrentEmployment" runat="server" Text="Number of Years in Current Employment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYearsInCurrentEmployment" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlBusinessAddressVerification" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblBusinessAddressVerification" runat="server" Text="BUSINESS ADDRESS VERIFICATION"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>        
                                <asp:Panel ID="pnlPremiseLocation" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPremiseLocation" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPremiseLocation" runat="server" Text="Premise Location"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlPremiseLocation" runat="server" AutoPostBack="false">
                                          <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Easy to Locate</asp:ListItem>
                                        <asp:ListItem>Difficult to Locate</asp:ListItem>
                                        <asp:ListItem>Untraceable</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProminentLandmark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProminentLandmark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProminentLandmark" runat="server" Text="Prominent Landmark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtProminentLandmark" runat="server" MaxLength="500"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlAddressVerifiedIs" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressVerifiedIs" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAddressVerifiedIs" runat="server" Text="Address verified is"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressVerifiedIs" runat="server" AutoPostBack="false">
                                          <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Trading Address</asp:ListItem>
                                        <asp:ListItem>Registered Address</asp:ListItem>
                                        <asp:ListItem>Both</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlHowLongInBusiness" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblHowLongInBusiness" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblHowLongInBusiness" runat="server" Text="How long in Business from this Premises"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtHowLongInBusiness" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlProductSold" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table19" style="width:100%" runat="server"> 
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label22" runat="server" Text="Product Sold"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtProductSold" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                  
                                  <asp:Panel ID="pnlIfFranch" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table20" style="width:100%" runat="server"> 
                                      <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label23" runat="server" Text="If Franchisee of a large corporate, Name"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtLargeCorporate" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                 
                                <asp:Panel ID="pnlCurrAcq" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table21" style="width:100%" runat="server"> 
                                       <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label24" runat="server" Text="Current Acquiring details"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCurrentAcq" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>                                         
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label33" runat="server" Text="If Yes"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCurrentAcqYes" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Manual</asp:ListItem>
                                        <asp:ListItem>Electronic</asp:ListItem>                                         
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                  
                                  <asp:Panel ID="pnlBankName" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table22" style="width:100%" runat="server"> 
                                   <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label25" runat="server" Text="Bank Name"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" ID="txtBankName" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                  
                                    <asp:Panel ID="pnlMID" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table23" style="width:100%" runat="server"> 
                                   <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label26" runat="server" Text="MID"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtMID" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                  
                                <asp:Panel ID="pnlNoOutlet" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table24" style="width:100%" runat="server"> 
                                   <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label34" runat="server" Text="No of Outlets"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoOutlets" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlNoTerminals" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table25" style="width:100%" runat="server"> 
                                   <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label35" runat="server" Text="No of Terminals"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoTerminals" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlPeriodRelation" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table26" style="width:100%" runat="server"> 
                                   <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label27" runat="server" Text="Period of relationship(months)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" ID="txtPeriodRelationship" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>                                    
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlReasonChange" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table27" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label28" runat="server" Text="Reason for changes"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonChanges" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlNeighFeed" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table28" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label29" runat="server" Text="Neighbour's Feedback"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlNeighFeed" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Positive</asp:ListItem>
                                        <asp:ListItem>Negative</asp:ListItem>                                         
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlNeighCont" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table29" style="width:100%" runat="server"> 
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label30" runat="server" Text="Neighbour Contact No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbourContact" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlNeighDesg" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table30" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label31" runat="server" Text="Neighbour Designation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighDesig" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                <asp:Panel ID="pnlAreaPremises" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAreaPremises" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAreaPremises" runat="server" Text="Area of Premises/Establishment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAreaPremises" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>                                   
                                    </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlAnyOthDet" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOthDet" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAnyOthDet" runat="server" Text="Any Othere Details"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAnyOthDet" runat="server" Width="80%" MaxLength="500"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlOwnershipOfPremises" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOwnershipOfPremises" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOwnershipOfPremises" runat="server" Text="Ownership of Premises"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnershipOfPremises" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Owned</asp:ListItem>
                                        <asp:ListItem>Rented</asp:ListItem>
                                         <asp:ListItem>Leased</asp:ListItem>
                                          <asp:ListItem>Pagdi</asp:ListItem>
                                        <asp:ListItem>Group Company Owned</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherPlzSpecify" Visible="false" runat="server" Text="If Others (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherPlzSpecify" Visible="false" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                               
                                  <asp:Panel ID="pnlLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Text="LEVEL OF BUSINESS ACTIVITY AND NATURE OF BUSINESS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>           
                                <asp:Panel ID="pnlTypeOfPremise" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfPremise" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTypeOfPremise" runat="server" Text="Type of Premise"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfPremise" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                         <asp:ListItem>Residence</asp:ListItem>
                                        <asp:ListItem>Office</asp:ListItem>
                                         <asp:ListItem>Industrial</asp:ListItem>
                                        <asp:ListItem>Factory</asp:ListItem>
                                        <asp:ListItem>Workship</asp:ListItem>
                                        <asp:ListItem>Godown / Warehouse</asp:ListItem>
                                        <asp:ListItem>Cabin</asp:ListItem>
                                        <asp:ListItem>Table Space</asp:ListItem>
                                        <asp:ListItem>RetailShop</asp:ListItem>
                                        <asp:ListItem>Wholesaleshop</asp:ListItem>
                                        <asp:ListItem>Showroom</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOtherTypeOfPremise" runat="server" Text="If Others specify"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtOtherTypeOfPremise" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                  
                                <asp:Panel ID="pnlContactPerson" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblContactPerson" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblContactPerson" runat="server" Text="Contact Person"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlContactPerson" runat="server" AutoPostBack="false">
                                         <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Neighbour</asp:ListItem>
                                        <asp:ListItem>Watchman</asp:ListItem>
                                        <asp:ListItem>others</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherProvideDetail" runat="server" Text="If Others (Please Provide Details)"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtIfOtherProvideDetail" runat="server" ></asp:TextBox>
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
                                         <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Trading in</asp:ListItem>
                                        <asp:ListItem>Manufacturing of</asp:ListItem>
                                        <asp:ListItem>Consultancy in</asp:ListItem>
                                        <asp:ListItem>Service Rendered of</asp:ListItem>
                                        <asp:ListItem>Professional</asp:ListItem>
                                        <asp:ListItem>Manufacturer</asp:ListItem>
                                        <asp:ListItem>Trader</asp:ListItem>
                                        <asp:ListItem>Shopkeeper</asp:ListItem>
                                        <asp:ListItem>Service Provider</asp:ListItem>
                                        <asp:ListItem>Comm Agent</asp:ListItem>
                                        <asp:ListItem>Broker</asp:ListItem>
                                        <asp:ListItem>Tutor Personal Care</asp:ListItem>
                                        <asp:ListItem>LIC Agent</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>  
                                    <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtNatureBuss" runat="server" MaxLength="300"></asp:TextBox>                            
                                    </td>
                                  </tr>
                                </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlNameBoard" runat="server" Width="100%" Visible="false">
                                 <table>
                                <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOnSignBoard" runat="server" Text="Name On Sign Board"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtNameOnSignBoard" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                  </table>
                               </asp:Panel>    
                                
                                <asp:Panel ID="pnlIfNotSome" runat="server" Width="100%" Visible="false">
                                 <table>
                               <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfNotSameConcernDetails" runat="server" Text="If not of the same concern details of how the concern is related"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                     <td >
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlProprietorPartner" runat="server" >
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem Value="Same Proprietor" Text="Same Proprietor"></asp:ListItem>
                                        <asp:ListItem Value="Common Partner" Text="Common Partner"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                  </table>
                               </asp:Panel>    
                               
                                <asp:Panel ID="pnlName" runat="server" Width="100%" Visible="false">
                                 <table>
                              <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblName" runat="server" Text="Name"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtName" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                  </table>
                               </asp:Panel>    
                               
                               <asp:Panel ID="pnlFamMem" runat="server" Width="100%" Visible="false">
                                 <table>
                            <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFamilyMemberIs" runat="server" Text="Family Member Is"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                  
                                    <td >
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlFamilyMemberIs" runat="server" >
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem Value="Proprietor" Text="Proprietor"></asp:ListItem>
                                        <asp:ListItem Value="Partner" Text="Partner"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                  </table>
                               </asp:Panel>  
                               
                               <asp:Panel ID="pnlRelan" runat="server" Width="100%" Visible="false">
                                 <table>
                                  <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblRelationshipIs" runat="server" Text="Relationship"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtRelationshipIs" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                  </table>
                               </asp:Panel>  
                               <%-- *********************************--%>
                                <asp:Panel ID="pnlFirmSignBoardSighted" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFirmSignBoardSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFirmSignBoardSighted" runat="server" Text="Firm Signboard sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlFirmSignBoardSighted" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>                                                                      
                                    <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameIs" Visible="false" runat="server" Text="Name"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" Visible="false" ID="txtNameIs" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>                                   
                                    </table>
                                    </asp:Panel>
                             
                                <asp:Panel ID="pnlSignBoardSightedRemark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblSignBoardSightedRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblSignBoardSightedRemark" runat="server" Text="Neighbour/Sign Board Sighted Remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtSignBoardSightedRemark" Width="80%"  TextMode="MultiLine" runat="server" MaxLength="1000"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDocumentSightedWithNameandAddressofthefirm" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDocumentSightedWithNameandAddressofthefirm" runat="server" Text="DOCUMENTS SIGHTED WITH NAME AND ADDRESS OF THE FIRM"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlTypeOfDocSighted" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfDocSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTypeOfDocSighted" runat="server" Text="Type of document sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfDocSighted" runat="server" AutoPostBack="false">
                                     <asp:ListItem>NA</asp:ListItem>
                                       <asp:ListItem>Bill Book</asp:ListItem>
                                       <asp:ListItem>Order Book</asp:ListItem>
                                       <asp:ListItem>Invoice Book</asp:ListItem>
                                       <asp:ListItem>Delivery Challan Book</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIfOtherDocSightedRemark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherDocSightedRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherDocSightedRemark" runat="server" Text="If other document sighted remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherDocSightedRemark" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlUsedPageSightDate" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblUsedPageSightDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblUsedPageSightDate" runat="server" Text="Used pages sighted date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtUsedPageSightDate" runat="server" MaxLength="50"></asp:TextBox>
                                    <img id="img4" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtUsedPageSightDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlIssuedTo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIssuedTo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIssuedTo" runat="server" Text="Issued To"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIssuedTo" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedNo" runat="server" Text="Initial invoice sighted no"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedDate" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedDate" runat="server" Text="Initial invoice sighted date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedDate" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    <img id="img1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtInitialInvoiceSightedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedIssuedTo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedIssuedTo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedIssuedTo" runat="server" Text="Initial invoice sighted issued to"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedIssuedTo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                
                                <asp:Panel ID="pnlThirdPartyInvoiceNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceNo" runat="server" Text="Third Party invoice no"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyInvoiceDate" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceDate" runat="server" Text="Third Party invoice date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceDate" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    <img id="img2" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtThirdPartyInvoiceDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyInvoiceIssuedBy" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceIssuedBy" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceIssuedBy" runat="server" Text="Third Party invoice issued by"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceIssuedBy" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyAddress" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyAddress" runat="server" Text="Third Party Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                  
                                <asp:Panel ID="pnlRelationshipBtnEntity" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationshipBtnEntity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblRelationshipBtnEntity" runat="server" Text="Relationship between entity whose Signane and entity being verified"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlRelationshipBtnEntity" runat="server" AutoPostBack="false">
                                       <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Same Proprietor</asp:ListItem>
                                        <asp:ListItem>Common Partner</asp:ListItem>
                                        <asp:ListItem>Other Relationship</asp:ListItem>                                        
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherRelationship" runat="server" Text="If Other Relationship(Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherRelationship" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                   <asp:Panel ID="pnlBusinessOwnership" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessOwnership" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessOwnership" runat="server" Text="Business ownership"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessOwnership" runat="server" AutoPostBack="false">
                                      <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Owned by Self</asp:ListItem>
                                        <asp:ListItem>Family Owned</asp:ListItem>
                                        <asp:ListItem>By Others</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblplspecify" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtplsSpecify" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblLevelOfBusinessActivity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblLevelOfBusinessActivity" runat="server" Text="Level of Business Activity"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlLevelOfBusinessActivity" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Busy</asp:ListItem>
                                        <asp:ListItem>Empty / Vacant</asp:ListItem>
                                        <asp:ListItem>Locked</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoOfEmployee" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployee" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoOfEmployee" runat="server" Text="No of employees"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmployee" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlBusinessEquipSighted" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessEquipSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessEquipSighted" runat="server" Text="Business equipment sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="chklBusinessEquipSighted" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                                        <asp:ListItem>Fax Machine</asp:ListItem>
                                        <asp:ListItem>Telex</asp:ListItem> 
                                        <asp:ListItem>Computer</asp:ListItem>
                                        <asp:ListItem>Photostat Machine</asp:ListItem> 
                                        <asp:ListItem>Other Equipment</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>                                       
                                    </asp:CheckBoxList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherBusinessEquipment" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherBusinessEquipment" Width="80%" runat="server"></asp:TextBox>                                    
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
                                <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAppName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server">Applicant's Name(Mr./Ms./Mrs.)</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
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
                                                <asp:TextBox SkinID="txtSkin" ID="txtAddress" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPhone" runat="server" Width="100%" Visible="false" >
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblPhone">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblPhone" runat="server" SkinID="lblSkin">Phone</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server" ReadOnly="true" SkinID="txtSkin"></asp:TextBox></td>
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
                                                <asp:Label ID="lblNamePlateDisplay" runat="server" SkinID="lblSkin">Name displayed in name board of the society</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateDisplay" runat="server" AutoPostBack="false">
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
                                                <asp:TextBox ID="txtRelationshipWithApp" runat="server" SkinID="txtSkin" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlStayingSinceAtResi" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStayingSinceAtResi">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStayingSinceAtResi" runat="server" SkinID="lblSkin">Staying since at Business</asp:Label></td>
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
                                
                                     <asp:Panel ID="pnlNameOfDematAcct" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfDematAcct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfDematAcct" runat="server" SkinID="lblSkin">Name of Demat Account(If Status is Yes)</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfDematAcct" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnlHavingDematAcwithOtherInstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table2">
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
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table3">
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
                                <asp:Panel ID="pnlBuisinessActivity" runat="server" Width="100%" Visible="false">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table5">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label4" runat="server" SkinID="lblSkin">
                                            Business Activity</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlbusinessActivity" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Bad</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                    <asp:ListItem>High</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Low</asp:ListItem>
                                                    <asp:ListItem>None</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label21" Visible="false" runat="server" SkinID="lblSkin">Business Stock Level</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" Visible="false"  ID="ddlStock" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Average</asp:ListItem>
                                                    <asp:ListItem>Low</asp:ListItem>
                                                    <asp:ListItem>None</asp:ListItem>
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
                            <%--Adding by Manoj for....Induand bank--%> 
                                <asp:Panel ID="Pnlconfirmation" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table38">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label39" runat="server" SkinID="lblSkin">Confirmation on Address existence:</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlconfirmation" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="PnlThiredparty" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table39">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label40" runat="server" SkinID="lblSkin">3rd Party confirmation on proprietor’s existence:</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlThiredparty" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <%--Added by hdfcergo --%> 
                                <asp:Panel ID="PnlMettoapplicant" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabMettoapplicant">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labMettoapplicant" runat="server" SkinID="lblSkin">Met / Spoke to applicant at office</asp:Label></td>
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
                                 
                                <asp:Panel ID="PnlRationcardavailable" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabRationcardavailable">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="labRationcardavailable" runat="server" SkinID="lblSkin">Ration Card available for same address:</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRationcardavailable" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                 
                                 
                        <%--Ended by Manoj--%>  
                        
                        
<%--added by sanket--%>
<asp:Panel ID="pnlddlSupervisorName" runat="server" Width="100%">
   <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorNameForSign" style="width:100%" runat="server">
        <tr id="Tr1" runat="server">
            <td id="Td1" class="TDWidth" runat="server"  >
                <asp:Label SkinID="lblSkin" ID="lblSupervisorNameForSign" runat="server" Text="Supervisor's Name"></asp:Label>
            </td>
            <td id="Td2" style="width:2%" runat="server">:</td>
            <td id="Td3" runat="server">
               <asp:DropDownList ValidationGroup="grValidate" SkinID="ddlSkin" ID="ddlSupervisorName" runat="server" AutoPostBack="False" OnSelectedIndexChanged="ddlSupervisorName_SelectedIndexChanged">
               </asp:DropDownList> <asp:Label SkinID="lblSkin" ForeColor="red" ID="lblSupError" Text="Supervisor Name is Mandatory." runat="server"></asp:Label>

               <asp:RequiredFieldValidator ID="rfvSupervisorNameForSign" runat="server"
                 ErrorMessage="Please select Supervisor Name." ControlToValidate="ddlSupervisorName"
                InitialValue="0" Display="Dynamic" ValidationGroup="grValidate"  >
                </asp:RequiredFieldValidator>
            </td>
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
                     <asp:DropDownList ValidationGroup="grValidate" SkinID="ddlSkin" ID="ddlAreaname" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlAreaname_SelectedIndexChanged">
                      </asp:DropDownList>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                     <asp:Button ID="btnPincode" runat="server" OnClick="btnPincode_Click" Text="Search Pincode" />

                </td>
           </tr>            
       </table>
   </asp:Panel>
     

                                   
                                               
    <%--Ended  by Manoj for Area --%>  
         
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
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStatus" runat="server" AutoPostBack="false">
  
                                                </asp:DropDownList>
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
                                                <asp:Label ID="lblVerifierDate" runat="server" SkinID="lblSkin">Date</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierDate" runat="server" SkinID="txtSkin"   ValidationGroup="grValidate"></asp:TextBox>
                                                <img id="imgVerifierDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtVerifierDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                <asp:TextBox ID="txtVerifierTime" runat="server" SkinID="txtSkin" MaxLength="5" Width="4%"   ValidationGroup="grValidate"></asp:TextBox>
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
                                                <asp:TextBox ID="txtDate3" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <asp:Label ID="lblTeleRemark" runat="server" SkinID="lblSkin">Tele Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 1000);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnloverallRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table6">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblremark" runat="server" SkinID="lblSkin">Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtoverallRemark" TextMode="MultiLine" runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                        
                                        
                                          <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label43" runat="server" SkinID="lblSkin">Standard Remark</asp:Label>
                                            </td>                                            
                                           <td style="width:2%">:</td>
                                            <td>
                                            <%--added by SANKET for HDFC Ergo--%>
                                            <asp:DropDownList ID="ddlStandardRemark" runat="server" SkinID="ddlSkin" ValidationGroup="grValidate" >
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



     <%--Added by SANKET for Kunverji--%>
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
       
     <asp:Panel  ID="Pnlcarpark" Width="100%" Visible="false" runat="server">
           <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table82">
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
                                    <asp:ListItem>Ac</asp:ListItem>
                                    <asp:ListItem>Phone</asp:ListItem> 
                                    <asp:ListItem>Sofa set</asp:ListItem> 
                                    <asp:ListItem>Fridge</asp:ListItem>
                                    <asp:ListItem>2 Wheeler</asp:ListItem>
                                    <asp:ListItem>Music System</asp:ListItem>
                                    <asp:ListItem>Washing m/c</asp:ListItem>
                                    <asp:ListItem>Computer</asp:ListItem>
                                    <asp:ListItem>Reception Desk/Area</asp:ListItem>
                                    <asp:ListItem>other</asp:ListItem>
                                </asp:CheckBoxList>
                    </td>
               </tr>
           </table>
       </asp:Panel> 
       
     <asp:Panel ID="PnlAnydisplayofpoliticalpartyseen" runat="server" Width="100%" Visible="false">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table83">
                <tr>
                    <td class="TDWidth">
                        <asp:Label ID="Label47" runat="server" SkinID="lblSkin">Any display of political party seen</asp:Label>
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
               </tr>
                    <tr>
                      <td class="TDWidth">
                             <asp:Label ID="labIf" runat="server" SkinID="lblskin">If yes,the appearance of person matches with provided photograph for registration </asp:Label>
                    </td>
                     <td style="width:2%">:</td>
                    <td>
                             <asp:TextBox ID="txtIfyes"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox>
                   </td>
               </tr>
                    <tr>
                      <td class="TDWidth">
                             <asp:Label ID="Label51" runat="server" SkinID="lblskin">Name of the person</asp:Label>
                    </td>
                     <td style="width:2%">:</td>
                    <td>
                             <asp:TextBox ID="txtNameofPerson"  runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox>
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
       
     <asp:Panel runat="server" ID="PnlTradingexperience" Width="100%" Visible="false">
       <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabTradingexperience">
           <tr>
                <td class="TDWidth">
                   <asp:Label ID="labTradingexperience" runat="server" SkinID="lblskin">Trading Experience</asp:Label>
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
           <tr>
            <td class="TDWidth">
                <asp:Label ID="lblTradingExp_Years" runat="server" SkinID="lblSkin">If Yes, then no. of years</asp:Label>
            </td>
           <td style="width:2%">:</td>
            <td>
                <asp:TextBox ID="txtTradingExp_Years" runat="server" SkinID="txtSkin" ></asp:TextBox>
           </td>
           </tr>
       </table>
   </asp:Panel>

     <asp:Panel ID="pnlNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers" runat="server" Width="100%" Visible="false">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table84">
            <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers" runat="server" SkinID="lblSkin">No. of members having trading account with stock brokers/commodity brokers</asp:Label>
                </td>
               <td style="width:2%">:</td>
                <td>
                 <asp:TextBox ID="txtNoofmembershavingtradingaccontwithstockbrokerscommoditybrokers"  runat="server" SkinID="txtSkin" ></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>

     <asp:Panel  ID="PnlProducts" Width="100%" Visible="false" runat="server">
           <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table85">
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

     <asp:Panel  ID="Pnladdressproof" Width="100%" Visible="false" runat="server">
           <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table86">
               <tr>
                    <td class="TDWidth">
                       <asp:Label ID="Label48" runat="server" SkinID="lblskin">Address Proof Sighted</asp:Label>
                    </td>
                    <td style="width:2%">:</td>
                    <td>
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressProofSighted" runat="server" AutoPostBack="false">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                       </asp:DropDownList>
                    </td>
               </tr>
            <tr>
                <td class="TDWidth">
                    <asp:Label ID="Label50" runat="server" SkinID="lblSkin">Specify the Type of Proof</asp:Label>
                </td>
               <td style="width:2%">:</td>
                <td>
                 <asp:TextBox ID="txtTypeofAddressProof" runat="server" SkinID="txtSkin" Width="80%" MaxLength="500"></asp:TextBox></td>
            </tr>                       
           </table>
       </asp:Panel>   

     <asp:Panel  ID="PnlApplicantBusiness" Width="100%" Visible="false" runat="server">
           <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table87">
               <tr>
                    <td class="TDWidth">
                       <asp:Label ID="Label49" runat="server" SkinID="lblskin">Does Applicant do Business from here</asp:Label>
                    </td>
                    <td style="width:2%">:</td>
                    <td>
                      <asp:DropDownList SkinID="ddlSkin" ID="ddlAppicantBusiness" runat="server" AutoPostBack="false">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                       </asp:DropDownList>
                    </td>
               </tr>
           </table>
       </asp:Panel> 
                      
     <%--END for Kunverji--%>

                                                                
                                <br/>
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
                                          <asp:HiddenField ID="hdnTransStart" runat="server" />
                                          <asp:HiddenField ID="hidMode" runat="server" />
                                          <asp:HiddenField ID="hdnSupID" runat="server" /> 
                                          <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
                                          
                                          <%--added by sanket on 13/02/2014--%>        
                                          <asp:RequiredFieldValidator ID="rfvArea"  InitialValue="0" ControlToValidate="ddlAreaname" runat="server" Display="None"
                                             ErrorMessage="Area Name IS Mandatory" ValidationGroup="grValidate" ></asp:RequiredFieldValidator>

                                    <asp:RequiredFieldValidator ID="rfvStandardRemark" runat="server"
                                         ErrorMessage="Please Select Standard Remark." ControlToValidate="ddlStandardRemark"
                                        InitialValue="--SELECT--" Display="None" ValidationGroup="grValidate"  >
                                        
                                      
                                        
                                    </asp:RequiredFieldValidator> 
                                    
                                    
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                         ErrorMessage="Please Insert Person Met." ControlToValidate="Txtpersonmet"
                                        InitialValue=" " Display="None" ValidationGroup="grValidate"  >
                                        
                                  
                                    </asp:RequiredFieldValidator> 
                                    
                                    
                                          
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="Please Insert Person Met Reason ." ControlToValidate="Txtpersonmetreason"
                                        InitialValue=" " Display="None" ValidationGroup="grValidate"  >
                                          </asp:RequiredFieldValidator> 
                                          
                                          
                                          
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                         ErrorMessage="Please Insert verification date ." ControlToValidate="txtVerifierDate"
                                        InitialValue=" " Display="None" ValidationGroup="grValidate"  >
                                          </asp:RequiredFieldValidator> 
                                          
                                          
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                         ErrorMessage="Please Insert verification date ." ControlToValidate="txtVerifierTime"
                                        InitialValue=" " Display="None" ValidationGroup="grValidate"  >
                                          </asp:RequiredFieldValidator> 
                                          
                                          
                                          
                                          
                                                 
                                         <%--End by sanket--%>        
                                          
                                </asp:Panel>
 <%--added by SANKET for supervisor sign--%>
        <asp:ValidationSummary ID="vsValidate" runat="server" ValidationGroup="grValidate" ShowMessageBox="True" ShowSummary="False" />  
<%--ended SANKET--%>
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




        
 </fieldset>
</asp:Content>
