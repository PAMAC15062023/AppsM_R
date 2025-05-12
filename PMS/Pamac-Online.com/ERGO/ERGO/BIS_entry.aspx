<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="BIS_entry.aspx.cs" Inherits="ERGO_ERGO_BIS_entry" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script language="javascript" type="text/javascript" src="../../popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">


        function UpperLetter(ID) 
        {
            ID.value = ID.value.toUpperCase();
        }

        function Validate_Generate() {
            var ReturnValue = true;
            var strErrorMessage = "";
            var lblErrorMessage = document.getElementById("<%=lblErrorMessage.ClientID%>");
            var txtBridgeCode = document.getElementById("<%=txtBridgeCode.ClientID%>");
            var txtPanNo = document.getElementById("<%=txtPanNo.ClientID%>");
            var ddlServiceTaxApplicable = document.getElementById("<%=ddlServiceTaxApplicable.ClientID%>");

            var txtServiceTaxNo = document.getElementById("<%=txtServiceTaxNo.ClientID%>");
            var ddlServiceTaxRecd = document.getElementById("<%=ddlServiceTaxRecd.ClientID%>");
            var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");

            var txtApartmentName = document.getElementById("<%=txtApartmentName.ClientID%>");
            var txtStreetLocalityName = document.getElementById("<%=txtStreetLocalityName.ClientID%>");
            var txtAreaVillage = document.getElementById("<%=txtAreaVillage.ClientID%>");

            var txtReceivedDate = document.getElementById("<%=txtReceivedDate.ClientID%>");
            var txtCityDistrict = document.getElementById("<%=txtCityDistrict.ClientID%>");
            var ddlState = document.getElementById("<%=ddlState.ClientID%>");

            var ddlBIS_Status = document.getElementById("<%=ddlBIS_Status.ClientID%>");
            var ddlDiscrepancy = document.getElementById("<%=ddlDiscrepancy.ClientID%>");
            var txtdiscrepancyType = document.getElementById("<%=txtdiscrepancyType.ClientID%>");
            var txtPinCode = document.getElementById("<%=txtPinCode.ClientID%>");
            var txtTDSRate = document.getElementById("<%=txtTDSRate.ClientID%>");

            var txtPayableLocation = document.getElementById("<%=txtPayableLocation.ClientID%>");

            if (txtBridgeCode.value == '')
             {
                strErrorMessage = "Please Enter Bridge Code!";
                txtBridgeCode.focus();
                ReturnValue = false;
              }

                    
            if (txtPanNo.value == '')
             {
                strErrorMessage = "Please Enter 10 digit PAN No!";
                returnValue = false;
                txtPanNo.focus();
            }
            else
             {

                var regex1 = /^[A-Z]{5}\d{4}[A-Z]{1}$/;  //this is the pattern of regular expersion
                if (regex1.test(txtPanNo.value) == false)
                 {
                    strErrorMessage = "Please enter valid PAN No.";
                    ReturnValue = false;
                    txtPanNo.focus();
                }
            }
             
            if (txtTDSRate.value == '') 
            {
                strErrorMessage = "Please Enter TDS Rate!";
                txtPanNo.focus();
                ReturnValue = false;

            }

            if (txtReceivedDate.value == '')
             {
                strErrorMessage = "Please Enter BIS Received Date!";
                txtReceivedDate.focus();
                ReturnValue = false;

            }
            
            if (ddlServiceTaxApplicable.selectedIndex == 1) 
            {
                if (txtServiceTaxNo.value == '') 
                {
                    strErrorMessage = "Please Enter Service Tax No!";
                    txtServiceTaxNo.focus();
                    ReturnValue = false;
                   
                }
            }

            if (ddlServiceTaxApplicable.selectedIndex == 1)
             {
                 if (ddlServiceTaxRecd.selectedIndex == 0)
                 {
                     strErrorMessage = "Please Enter ServiceTax Copy Recd OR Not !";
                     ddlServiceTaxRecd.focus();
                     ReturnValue = false;
                    
                }
            }

            if (ddlDiscrepancy.selectedIndex == 1)
             {
                 if (txtdiscrepancyType.value == '')
                 {
                     strErrorMessage = "Please update Discrepancy Remarks!";
                     txtdiscrepancyType.focus();
                     ReturnValue = false;
                     
                }
             }

               if (ddlDiscrepancy.selectedIndex == 0)
                 {        
                     strErrorMessage = "Please select Discrepancy !";
                     ddlDiscrepancy.focus();
                     ReturnValue = false;
                 }

                 if (ddlBIS_Status.selectedIndex == 0) 
                 {

                     strErrorMessage = "Please select BIS Status!";
                     ddlBIS_Status.focus();
                     ReturnValue = false;
                 }

             if (txtPayeeName.value == '') 
             {
                 strErrorMessage = "Please Enter Payee Name!";
                 txtPayeeName.focus();
                 ReturnValue = false;

             }


             if (txtApartmentName.value == '' && txtStreetLocalityName.value=='' && txtAreaVillage.value=='')
             {
                strErrorMessage = "Please Enter All Address Fields!";
                ReturnValue = false;
               
            }

            if (txtPinCode.value == '')
             {
                strErrorMessage = "Please Enter Dealer PinCode!";
                txtPinCode.focus();
                ReturnValue = false;
               
            }

            lblErrorMessage.innerText = strErrorMessage;
            window.scrollTo(0, 0);

            return ReturnValue;
        }



        function CatchValuePayableLocation()
         {
             //debugger;
             
             var txtCityDistrict = document.getElementById("<%=txtCityDistrict.ClientID%>");
             var txtPayableLocation = document.getElementById("<%=txtPayableLocation.ClientID%>");
                               
             if (txtCityDistrict.value != '') 
             {
                 txtPayableLocation.value = txtCityDistrict.value;
             }

         }

         function CatchValueDealerName()
          {
             //debugger;

             var txtPayeeName = document.getElementById("<%=txtPayeeName.ClientID%>");
             var txtDealerName = document.getElementById("<%=txtDealerName.ClientID%>");
        
             if (txtPayeeName.value != '') 
             {
                 txtDealerName.value = txtPayeeName.value;
             }

         }

         function CatchValueDiscrepancy()
          {
             debugger;

             var ddlBIS_Status = document.getElementById("<%=ddlBIS_Status.ClientID%>");
             var ddlDiscrepancy = document.getElementById("<%=ddlDiscrepancy.ClientID%>");

             if (ddlBIS_Status.SelectedIndex == 1) 
             {
                 ddlDiscrepancy.SelectedIndex = 2;
             }
             else
              {
                 ddlDiscrepancy.SelectedIndex = 1;
             }
         }


    </script>

     <table>
        <tr>
            <td colspan="6" style="height: 15px">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
            <td colspan="1" style="height: 15px; width: 100px;">
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 9px" class="tta">
                &nbsp;<strong>BIS Entry Form</strong> </td>
        </tr>
        <tr>
            <td style="height: 17px">
            </td>
            <td class="reportTitleIncome" style="height: 17px">
                &nbsp;<strong>Bridge Code</strong></td>
            <td class="Info" style="width: 246px; height: 17px;">
                <table style="width: 195px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtBridgeCode" runat="server" SkinID="txtSkin" Width="140px" 
                                TabIndex="1"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnSearchExist" runat="server" BorderWidth="1px" CssClass="TableHeader"
                                Height="18px" OnClick="btnSearchExist_Click" Text="Go" Width="37px" 
                                TabIndex="2" Visible="False" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 1272px; height: 17px;">
                </td>
            <td style="width: 744px; height: 17px;">
                </td>
        </tr>
        <tr>
            <td style="height: 33px">
                &nbsp;</td>
            <td class="reportTitleIncome" style="height: 33px">
                &nbsp;<strong>BIS Recd Date</strong></td>
            <td class="Info" style="width: 246px; height: 33px;">
                            <asp:TextBox ID="txtReceivedDate" runat="server" BorderWidth="1px" MaxLength="10"
                                SkinID="txtSkin" Width="109px" TabIndex="3"></asp:TextBox>
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtReceivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
            <td style="width: 1272px; height: 33px;">
                &nbsp;</td>
            <td style="width: 744px; height: 33px;">
                &nbsp;</td>
        </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Payee Name</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtPayeeName" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="4"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Dealer Name</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtDealerName" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="5"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>House Apartment Name</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtApartmentName" runat="server" SkinID="txtSkin" 
                     Width="298px" TabIndex="6"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Street Name_VicinityName_LocalityName</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtStreetLocalityName" runat="server" SkinID="txtSkin" 
                     Width="298px" TabIndex="7"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 17px;">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 17px;">
                 &nbsp;<strong>Area Village</strong></td>
             <td class="Info" style="height: 17px" colspan="2">
                 <asp:TextBox ID="txtAreaVillage" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="8"></asp:TextBox></td>
             <td style="width: 756px; height: 17px;">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 17px;">
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px; height: 17px;">
                 &nbsp;<strong>City District</strong></td>
             <td class="Info" style="height: 17px" colspan="2">
                 <asp:TextBox ID="txtCityDistrict" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="9"></asp:TextBox></td>
             <td style="width: 756px; height: 17px;">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 25px;">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 25px;">
                 &nbsp;<strong>Dealer Pin Code</strong></td>
             <td class="Info" style="height: 25px">
                 <asp:TextBox ID="txtPinCode" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="10" MaxLength="6"></asp:TextBox></td>
             <td style="width: 1272px; height: 25px;">
                 &nbsp;</td>
             <td style="width: 756px; height: 25px;">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 25px;">
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px; height: 25px;">
                 &nbsp;<strong>State</strong></td>
             <td class="Info" style="height: 25px">
                 <asp:DropDownList ID="ddlState" runat="server" SkinID="ddlSkin" TabIndex="11" 
                     Width="142px">
                     <asp:ListItem>NA</asp:ListItem>
                     <asp:ListItem>AASAM</asp:ListItem>
                     <asp:ListItem>AGRA</asp:ListItem>
                     <asp:ListItem>AHMEDABAD</asp:ListItem>
                     <asp:ListItem>ANDHRA PRADESH</asp:ListItem>
                     <asp:ListItem>BIHAR</asp:ListItem>
                     <asp:ListItem>CHHATTISGARH</asp:ListItem>
                     <asp:ListItem>CHANDIGARH</asp:ListItem>
                     <asp:ListItem>DELHI</asp:ListItem>
                     <asp:ListItem>GOA</asp:ListItem>
                     <asp:ListItem>GUJRAT</asp:ListItem>
                     <asp:ListItem>GANGA NAGAR</asp:ListItem>
                     <asp:ListItem>HARYANA</asp:ListItem>
                     <asp:ListItem>HIMACHAL PRADESH</asp:ListItem>
                     <asp:ListItem>HYDRABAD</asp:ListItem>
                     <asp:ListItem>JAMMU & KASHMIR</asp:ListItem>
                     <asp:ListItem>JHARKHAND</asp:ListItem>
                     <asp:ListItem>KARNATAKA</asp:ListItem>
                     <asp:ListItem>KERALA</asp:ListItem>
                     <asp:ListItem>KOLHAPUR</asp:ListItem>
                     <asp:ListItem>KOLKATTA</asp:ListItem>
                     <asp:ListItem>MADHYA PRADESH</asp:ListItem>
                     <asp:ListItem>MAHARASHTRA</asp:ListItem>
                     <asp:ListItem>MANIPUR</asp:ListItem>
                     <asp:ListItem>MEGHALAYA</asp:ListItem>
                     <asp:ListItem>MIZORAM</asp:ListItem>
                     <asp:ListItem>NEW DELHI</asp:ListItem>
                     <asp:ListItem>NAGALAND</asp:ListItem>
                     <asp:ListItem>ORISSA</asp:ListItem>
                     <asp:ListItem>PATNA</asp:ListItem>
                     <asp:ListItem>PONDICHERRY</asp:ListItem>
                     <asp:ListItem>PUNJAB</asp:ListItem>
                     <asp:ListItem>RAJASTHAN</asp:ListItem>
                     <asp:ListItem>SIKKIM</asp:ListItem>
                     <asp:ListItem>TAMIL NADU</asp:ListItem>
                     <asp:ListItem>TRIPURA</asp:ListItem>
                     <asp:ListItem>UTTAR PRADESH</asp:ListItem>
                     <asp:ListItem>UTTARAKHAND</asp:ListItem>
                     <asp:ListItem>UTTRANCHAL</asp:ListItem>
                     <asp:ListItem>WEST BENGAL</asp:ListItem>
                     <asp:ListItem>ANDAMAN & NICOBAR ISLANDS</asp:ListItem>
                     <asp:ListItem>DADRA & NAGAR HAVELI</asp:ListItem>
                     <asp:ListItem>DAMAN & DIU</asp:ListItem>
                     <asp:ListItem>LAKSHADWEEP</asp:ListItem>
                     </asp:DropDownList></td>
             <td style="width: 1272px; height: 25px;">
                 <asp:HiddenField ID="hdnBridgeCode" runat="server" />
             </td>
             <td style="width: 756px; height: 25px;">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 17px;">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 17px;">
                 &nbsp;<strong>Payable Location</strong></td>
             <td class="Info" style="height: 17px">
                 <asp:TextBox ID="txtPayableLocation" runat="server" SkinID="txtSkin" 
                     Width="142px" TabIndex="12"></asp:TextBox></td>
             <td style="width: 1272px; height: 17px;">
                 <asp:HiddenField ID="hdnPayeeName" runat="server" />
             </td>
             <td style="width: 756px; height: 17px;">
             </td>
         </tr>

        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 2674px; height: 24px;" class="reportTitleIncome">
                &nbsp;<strong>Type Of Organisation</strong></td>
            <td class="Info" colspan="1" style="height: 24px">
                <asp:DropDownList ID="ddlTypeOfOrganisation" runat="server" TabIndex="13" SkinID="ddlSkin">
                    <asp:ListItem>INDIVIDUAL</asp:ListItem>
                    <asp:ListItem>PROPRIETORSHIP</asp:ListItem>
                    <asp:ListItem>PARTNERSHIP</asp:ListItem>
                    <asp:ListItem>PVT LTD</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 756px; height: 24px;">
                </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 2674px" class="reportTitleIncome">
                &nbsp;<strong>PAN No</strong></td>
            <td style="width: 100px" class="Info">
                <asp:TextBox ID="txtPanNo" runat="server" AutoPostBack="True" MaxLength="10" 
                    SkinID="txtSkin" Width="142px" TabIndex="14" 
                    ontextchanged="txtPanNo_TextChanged"></asp:TextBox></td>
            <td style="width: 1272px">
                <asp:Label ID="lblApplicantPANno" runat="server" EnableTheming="True" ForeColor="White"
                    Width="183px" BackColor="Maroon" Height="16px"></asp:Label></td>
            <td style="width: 756px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 2674px" class="reportTitleIncome">
                &nbsp;<strong>MICR Code</strong></td>
            <td style="width: 100px" class="Info">
                 <asp:TextBox ID="txtMICRCode" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="15" MaxLength="9"></asp:TextBox></td>
            <td style="width: 1272px">
                &nbsp;</td>
            <td style="width: 756px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 2674px" class="reportTitleIncome">
                &nbsp;<strong>IFSC CODE</strong>&nbsp;</td>
            <td style="width: 100px" class="Info">
                 <asp:TextBox ID="txtIFSCCode" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="16" MaxLength="16"></asp:TextBox></td>
            <td style="width: 1272px">
                &nbsp;</td>
            <td style="width: 756px">
                &nbsp;</td>
        </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Account No</strong></td>
             <td class="Info" style="width: 100px">
                 <asp:TextBox ID="txtAccountNo" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="17" MaxLength="20"></asp:TextBox></td>
             <td style="width: 1272px">
                 &nbsp;</td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Bank Name</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="18" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
             <td style="width: 756px">
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Bank Branch Name</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtBranchName" runat="server" SkinID="txtSkin" Width="298px" 
                     TabIndex="19"></asp:TextBox></td>
             <td style="width: 756px">
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Mobile No</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtMobileNo" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="20"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 30px">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 30px;">
                 &nbsp;<strong>Service Tax Applicable</strong></td>
             <td class="Info" colspan="2" style="height: 30px">
                 <asp:DropDownList ID="ddlServiceTaxApplicable" runat="server" SkinID="ddlSkin" 
                     Width="142px" TabIndex="21">
                     <asp:ListItem Value="1">No</asp:ListItem>
                     <asp:ListItem Value="0">Yes</asp:ListItem>
                 </asp:DropDownList></td>
             <td style="width: 756px; height: 30px;">
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Service Tax No</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtServiceTaxNo" runat="server" SkinID="txtSkin" Width="142px" 
                     TabIndex="22" MaxLength="20"></asp:TextBox></td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
         <tr>
             <td style="height: 30px">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 30px;">
                 &nbsp;<strong>Service Tax Copy Recd</strong></td>
             <td class="Info" colspan="2" style="height: 30px">
                 <asp:DropDownList ID="ddlServiceTaxRecd" runat="server" SkinID="ddlSkin" 
                     Width="142px" TabIndex="23">
                     <asp:ListItem Value="1">No</asp:ListItem>
                     <asp:ListItem Value="0">Yes</asp:ListItem>
                 </asp:DropDownList></td>
             <td style="width: 756px; height: 30px;">
                 &nbsp;</td>
         </tr>
        
         <tr>
             <td>
                 &nbsp;</td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong> TDS Rate</strong></td>
             <td class="Info" colspan="2">
                 <asp:TextBox ID="txtTDSRate" runat="server" Width="138px" TabIndex="24" SkinID="txtSkin">10.00</asp:TextBox>
             </td>
             <td style="width: 756px">
                 &nbsp;</td>
         </tr>
        
         <tr>
             <td style="height: 17px;">
             </td>
             <td class="reportTitleIncome" style="width: 2674px; height: 17px;">
                 &nbsp;<strong>BIS Status</strong></td>
             <td class="Info" style="height: 17px" abbr="Info">
                 <asp:DropDownList ID="ddlBIS_Status" runat="server" SkinID="ddlSkin" 
                     Width="142px" TabIndex="25">
                     <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Value="0">Okay</asp:ListItem>
                 <asp:ListItem Value="1">Not Okay</asp:ListItem>
             </asp:DropDownList></td>
             <td style="width: 1272px; height: 17px;">
                <asp:HiddenField ID="hdnPanNoPostBack" runat="server" Value="0" />
             </td>
             <td style="width: 756px; height: 17px;">
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td class="reportTitleIncome" style="width: 2674px">
                 &nbsp;<strong>Discrepancy</strong></td>
             <td class="Info" abbr="Info" colspan="2">
                 <asp:DropDownList ID="ddlDiscrepancy" 
                     runat="server" SkinID="ddlSkin" Width="79px" TabIndex="26" >
                     <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Value="0">Yes</asp:ListItem>
                 <asp:ListItem Value="1">No</asp:ListItem>
             </asp:DropDownList>
                 <asp:TextBox ID="txtdiscrepancyType" runat="server" Width="286px" TabIndex="27" SkinID="txtSkin"></asp:TextBox>
             </td>
             <td style="width: 756px">
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td style="width: 2674px">
             </td>
             <td abbr="Info">
             </td>
             <td style="width: 1272px">
             </td>
             <td style="width: 756px">
             </td>
         </tr>
        <tr>
            <td class="reportTitleIncome" colspan="7" style="height: 28px">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" OnClick="btnSave_Click"
                    Text="Save" Width="69px" TabIndex="28" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" BorderWidth="1px" Text="ADD New" 
                    Width="72px" onclick="btnAddNew_Click" TabIndex="29" />
&nbsp; <asp:Button ID="btnClose" runat="server" BorderWidth="1px"
                        Text="Cancel" Width="69px" OnClick="btnClose_Click" 
                    ToolTip="Click to go to Main Menu." TabIndex="30" />
                &nbsp;
                <asp:Button ID="btnDiscrepancy" runat="server" BorderWidth="1px" Text="TDS Calculation"
                    Width="179px" OnClick="btnDiscrepancy_Click" TabIndex="31" />
                </td>
        </tr>
        <tr>
            <td style="height: 15px;">
            </td>
            <td style="width: 2674px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 1272px; height: 15px;">
            </td>
            <td style="width: 756px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
        </tr>
    </table>



</asp:Content>

