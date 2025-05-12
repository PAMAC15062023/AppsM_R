<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master"
    AutoEventWireup="true" CodeFile="Assets_DescriptionFormat.aspx.cs" Inherits="Admin_Assets_Inventory_Assets_DescriptionFormat"
    Title="Assets Description Format" StylesheetTheme="SkinFile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <%--<script language="javascript" type="text/javascript">
function SaveValidationControl()
                {
                    var txtCompName=document.getElementById("<%=txtCompName.ClientID%>");
                   
                    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
                    
                    var ErrorMsg="";
                    
                    if(txtCompName.value=='')
                    {
                        ErrorMsg='Please Enter Company Name......!!!!!';
                        ReturnValue=false;
                        txtCompName.focus();
                    }
                  
                    
                    lblMessage.innerText=ErrorMsg;
                   if(ErrorMsg!='')
                    {
                        window.scrollTo(0,0);
                    }
                           return ReturnValue; 
                }                       

    </script>--%>

    <table style="width: 949px">
        <tr>
            <td class="tta" colspan="9">
                <span style="font-size: 10pt">Assets Inventory Description Format</span></td>
        </tr>
        <tr>
            <td style="width: 2px; height: 21px;">
            </td>
            <td colspan="8" style="height: 21px">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                Centre Name</td>
            <td style="width: 100px; height: 16px;" class="Info">
                <asp:Label ID="lblCentreName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                SubCentre Name</td>
            <td style="width: 51px; height: 16px;" class="Info">
                <asp:Label ID="lblSubcentreName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                Vertical Name</td>
            <td style="width: 100px; height: 16px;" class="Info">
                <asp:Label ID="lblVerticalName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 86px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                User Name</td>
            <td style="height: 16px;" colspan="4" class="Info">
                <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 86px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Assets Type</td>
            <td style="width: 100px; height: 16px" class="Info">
                <asp:Label ID="lblAssetsType" runat="server"></asp:Label></td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Assets Sub Type</td>
            <td style="width: 51px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlAssetsSubType" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                    Width="121px">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Label ID="Lblassetssubtype" runat="server" Text="Label" Width="119px"></asp:Label></td>
            <td style="width: 100px; height: 16px">
                &nbsp;&nbsp;
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 86px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
                <asp:HiddenField ID="hdnCentre" runat="server" />
            </td>
            <td style="width: 100px; height: 16px;">
                <asp:HiddenField ID="hdnSubcentre" runat="server" />
            </td>
            <td style="width: 100px; height: 16px;">
                <asp:HiddenField ID="hdnTranRefNo" runat="server" />
            </td>
            <td style="width: 51px; height: 16px;">
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnAssetType" runat="server" />
            </td>
            <td style="width: 100px; height: 16px;">
                <asp:HiddenField ID="hdnEmpCode" runat="server" />
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 86px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 16px;">
            </td>
            <td colspan="8" style="height: 16px">
                <asp:Panel ID="pnlDescripData" runat="server" Width="100%">
                    <table>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblCompName" runat="server" Text="Company Name :" SkinID="lblPanelSkin"
                                    Visible="False" Width="101px"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtCompName" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblModelName" runat="server" SkinID="lblPanelSkin" Text="Model Name :"
                                    Visible="False" Width="76px"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtModelName" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblWarrantyType" runat="server" SkinID="lblPanelSkin" Text="Warranty Type :"
                                    Visible="False" Width="87px"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlWarrantyType" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>OnSite</asp:ListItem>
                                    <asp:ListItem>OffSite</asp:ListItem>
                                </asp:DropDownList></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblCassetteCD" runat="server" SkinID="lblPanelSkin" Text="Cassette / CD / DataCard :"
                                    Visible="False" Width="88px"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtCassetteCD" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblUsbPortAvil" runat="server" SkinID="lblPanelSkin" Text="USB Port Available :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:DropDownList ID="ddlUsbPortAvil" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTotalRacks" runat="server" SkinID="lblPanelSkin" Text="Total Racks To Store :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtTotalRacks" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblLockerAvil" runat="server" SkinID="lblPanelSkin" Text="Locker Available :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlLockerAvil" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblPrintCapacity" runat="server" SkinID="lblPanelSkin" Text="Print Capacity - Pages per min :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtPrintCapacity" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblOthFeature" runat="server" SkinID="lblPanelSkin" Text="Other Features :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtOthFeature" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblCountDraw" runat="server" SkinID="lblPanelSkin" Text="Count of Drawer :"
                                    Visible="False" Width="79px"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtCountDraw" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBlockingLock" runat="server" SkinID="lblPanelSkin" Text="Blocking lock available :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtBlockingLock" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblSensorResu" runat="server" SkinID="lblPanelSkin" Text="Sensor resulation :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtSensorResu" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblSensorType" runat="server" SkinID="lblPanelSkin" Text="Seonsor Type :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtSensorType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblManualFocus" runat="server" SkinID="lblPanelSkin" Text="Manual Focus :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtManualFocus" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblScreenSize" runat="server" SkinID="lblPanelSkin" Text="Screen Size :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtScreenSize" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblRechargeBett" runat="server" SkinID="lblPanelSkin" Text="Recharegeable Battaries :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlRechargeBett" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblConnectivity" runat="server" SkinID="lblPanelSkin" Text="Connectivity :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:DropDownList ID="ddlConnectivity" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>WIFI</asp:ListItem>
                                    <asp:ListItem>BlueTooth</asp:ListItem>
                                    <asp:ListItem>GPRS</asp:ListItem>
                                    <asp:ListItem>WAP</asp:ListItem>
                                    <asp:ListItem>3G</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTotalBatt" runat="server" SkinID="lblPanelSkin" Text="Total Battaries :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtTotalBatt" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblPushBack" runat="server" SkinID="lblPanelSkin" Text="Push Back :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtPushBack" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblFoldingChair" runat="server" SkinID="lblPanelSkin" Text="Folding Chair / Weel Chair :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtFoldingChair" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 52px;" class="reportTitleIncome">
                                <asp:Label ID="lblPlainPaper" runat="server" SkinID="lblPanelSkin" Text="Plain or Thermal Paper :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px; height: 52px;" class="Info">
                                <asp:TextBox ID="txtPlainPaper" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 52px;" class="reportTitleIncome">
                                <asp:Label ID="lblColour" runat="server" SkinID="lblPanelSkin" Text="Colour Black & White :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px; height: 52px;" class="Info">
                                <asp:TextBox ID="txtColour" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 52px;" class="reportTitleIncome">
                                <asp:Label ID="lblPowerOffDial" runat="server" SkinID="lblPanelSkin" Text="Power Off Dialing :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 52px;" class="Info">
                                <asp:TextBox ID="txtPowerOffDial" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome" style="height: 52px">
                                <asp:Label ID="lblFaxPrintSpeed" runat="server" SkinID="lblPanelSkin" Text="Fax Printing Speed per min :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 52px;" class="Info">
                                <asp:TextBox ID="txtFaxPrintSpeed" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblCompPrintCap" runat="server" SkinID="lblPanelSkin" Text="Computer Printer Compatibility :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtCompPrintCap" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblPrintCartg" runat="server" SkinID="lblPanelSkin" Text="Type of Printing Cartridge :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtPrintCartg" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblSpeakerPH" runat="server" SkinID="lblPanelSkin" Text="Speaker Phone :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtSpeakerPH" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome" style="height: 40px">
                                <asp:Label ID="lblMaxPaperCap" runat="server" SkinID="lblPanelSkin" Text="Maximum Paper Capacity (Sheets/Roll) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtMaxPaperCap" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblAlarmIndi" runat="server" SkinID="lblPanelSkin" Text="Alarm Indicator :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtAlarmIndi" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblInbuiltAnsMach" runat="server" SkinID="lblPanelSkin" Text="Inbuilt Answering Machine :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtInbuiltAnsMach" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblProcessorName" runat="server" SkinID="lblPanelSkin" Text="Processor Name :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtProcessorName" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblPassUserRestric" runat="server" SkinID="lblPanelSkin" Text="Password User Restriction :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtPassUserRestric" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblProcessorSpeed" runat="server" SkinID="lblPanelSkin" Text="Processor Speed (MHz) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtProcessorSpeed" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblStandardRam" runat="server" SkinID="lblPanelSkin" Text="Standard RAM (MB) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtStandardRam" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 40px;" class="reportTitleIncome">
                                <asp:Label ID="lblUpgradeRam" runat="server" SkinID="lblPanelSkin" Text="Upgradeable RAM (MB) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtUpgradeRam" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" style="height: 40px" class="reportTitleIncome">
                                <asp:Label ID="lblHardDiskDriveCap" runat="server" SkinID="lblPanelSkin" Text="Inbuilt Hard Disk Drive Capacity (GB) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 40px;" class="Info">
                                <asp:TextBox ID="txtHardDiskDriveCap" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBatteryType" runat="server" SkinID="lblPanelSkin" Text="Battery (Type) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtBatteryType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBatteryLife" runat="server" SkinID="lblPanelSkin" Text="Battery Life (Hours) :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtBatteryLife" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblCameraBuilt" runat="server" SkinID="lblPanelSkin" Text="Built in Camera :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtCameraBuilt" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblSpeaker" runat="server" SkinID="lblPanelSkin" Text="Speaker :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtSpeaker" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBluetooth" runat="server" SkinID="lblPanelSkin" Text="Bluetooth :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtBluetooth" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblSmartPh" runat="server" SkinID="lblPanelSkin" Text="Smart phone / Normal :"
                                    Visible="False" Width="92px"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtSmartPh" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTouchScreen" runat="server" SkinID="lblPanelSkin" Text="Touch Screen / Normal :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtTouchScreen" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblConfCall" runat="server" SkinID="lblPanelSkin" Text="Conference Call :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtConfCall" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblMemCard" runat="server" SkinID="lblPanelSkin" Text="Memory Card :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtMemCard" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblMemCardSize" runat="server" SkinID="lblPanelSkin" Text="Size of the memory card :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtMemCardSize" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblRouterSpeed" runat="server" SkinID="lblPanelSkin" Text="Speed of the Router :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtRouterSpeed" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblProcessor" runat="server" SkinID="lblPanelSkin" Text="Processesor / Model Speed :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlProcessor" runat="server" SkinID="ddlSkin" Width="130px"
                                    Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>1.7GHZ</asp:ListItem>
                                    <asp:ListItem>2.2GHz</asp:ListItem>
                                    <asp:ListItem>2.3GHz</asp:ListItem>
                                    <asp:ListItem>2.4GHz</asp:ListItem>
                                    <asp:ListItem>2.5GHz</asp:ListItem>
                                    <asp:ListItem>2.6GHz</asp:ListItem>
                                    <asp:ListItem>2.7GHz</asp:ListItem>
                                    <asp:ListItem>2.8GHz</asp:ListItem>
                                    <asp:ListItem>2.9GHz</asp:ListItem>
                                    <asp:ListItem>3.0GHz</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblRamType" runat="server" SkinID="lblPanelSkin" Text="RAM Type :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:DropDownList ID="ddlRam" runat="server" SkinID="ddlSkin" Width="130px" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>256 MB</asp:ListItem>
                                    <asp:ListItem>512 MB</asp:ListItem>
                                    <asp:ListItem>1 GB</asp:ListItem>
                                    <asp:ListItem>2 GB</asp:ListItem>
                                    <asp:ListItem>4 GB</asp:ListItem>
									<asp:ListItem>8 GB</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblHddGb" runat="server" SkinID="lblPanelSkin" Text="HDD In GB :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:DropDownList ID="ddlHdd" runat="server" SkinID="ddlSkin" Width="130px" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>40 GB</asp:ListItem>
                                    <asp:ListItem>80 GB</asp:ListItem>
                                    <asp:ListItem>160 GB</asp:ListItem>
                                    <asp:ListItem>250 GB</asp:ListItem>
                                    <asp:ListItem>320 GB</asp:ListItem>
                                    <asp:ListItem>500 GB</asp:ListItem>
                                    <asp:ListItem>256 GB SSD</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblMotherBoardMake" runat="server" SkinID="lblPanelSkin" Text="Mother Board Make By :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtMotherBoardMake" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblAutomaticDocu" runat="server" SkinID="lblPanelSkin" Text="Automatic Document Feeder :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtAutomaticDocu" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTotalPort" runat="server" SkinID="lblPanelSkin" Text="Total Port :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtTotalPort" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblModelType" runat="server" SkinID="lblPanelSkin" Text="Model Type :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:DropDownList ID="ddlModelType" runat="server" SkinID="ddlSkin" Width="130px"
                                    Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>USB</asp:ListItem>
                                    <asp:ListItem>ADSL</asp:ListItem>
                                    <asp:ListItem>WIFI</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblSpeakerType" runat="server" SkinID="lblPanelSkin" Text="Speaker Type :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtSpeakerType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblOpticalCharReco" runat="server" SkinID="lblPanelSkin" Text="Optical Character Recongnition :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtOpticalCharReco" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblSpeakerPorts" runat="server" SkinID="lblPanelSkin" Text="Speaker Ports :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtSpeakerPorts" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblWatt" runat="server" SkinID="lblPanelSkin" Text="Watt :" Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtWatt" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTonn" runat="server" SkinID="lblPanelSkin" Text="Tonn :" Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtTonn" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" class="reportTitleIncome">
                                <asp:Label ID="lblTextEnhanTech" runat="server" SkinID="lblPanelSkin" Text="Text Enhanced Technology :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtTextEnhanTech" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 22px;" class="reportTitleIncome">
                                <asp:Label ID="lblTelephone" runat="server" SkinID="lblPanelSkin" Text="Telephone # :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px; height: 22px;" class="Info">
                                <asp:TextBox ID="txtTelephone" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 22px;" class="reportTitleIncome">
                                <asp:Label ID="lblCallerID" runat="server" SkinID="lblPanelSkin" Text="Caller ID :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px; height: 22px;" class="Info">
                                <asp:TextBox ID="txtCallerID" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px; height: 22px;" class="reportTitleIncome">
                                <asp:Label ID="lblStd" runat="server" SkinID="lblPanelSkin" Text="STD :" Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 22px;" class="Info">
                                <asp:TextBox ID="txtStd" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td colspan="2" style="height: 22px" class="reportTitleIncome">
                                <asp:Label ID="lblRouter" runat="server" SkinID="lblPanelSkin" Text="Router :" Visible="False"></asp:Label></td>
                            <td style="width: 100px; height: 22px;" class="Info">
                                <asp:TextBox ID="txtRouter" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblValidity" runat="server" SkinID="lblPanelSkin" Text="Validity :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="txtValidity" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblCartridge" runat="server" SkinID="lblPanelSkin" Text="Cartridge :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtCartridge" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblEncodingType" runat="server" SkinID="lblPanelSkin" Text="Encoding Type:"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlEncodingType" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>Manual</asp:ListItem>
                                    <asp:ListItem>Automatic</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="Label1" runat="server" SkinID="lblPanelSkin" Text="Encoding Type:"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>Manual</asp:ListItem>
                                    <asp:ListItem>Automatic</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblKeyBoard" runat="server" SkinID="lblPanelSkin" Text="KeyBoard:"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:DropDownList ID="ddlKeyboard" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>PS2</asp:ListItem>
                                    <asp:ListItem>USB</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblMouse" runat="server" SkinID="lblPanelSkin" Text="Mouse:" Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:DropDownList ID="ddlMouse" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>PS2</asp:ListItem>
                                    <asp:ListItem>USB</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBackupTime" runat="server" SkinID="lblPanelSkin" Text="Backup Time"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtBackupTime" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblbatteryCount" runat="server" SkinID="lblPanelSkin" Text="No of Batteries"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlbatteryCount" runat="server" SkinID="ddlSkin" Visible="False">
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
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 100px">
                                <asp:Label ID="labtable" runat="server" SkinID="lblPanelSkin" Text="Table:" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 87px">
                                <asp:DropDownList ID="ddltable" runat="server" SkinID="ddlSkin" Visible="False">
                                    <asp:ListItem Value="Full">Top</asp:ListItem>
                                    <asp:ListItem>USB</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 100px">
                                <asp:Label ID="Lblcapacity" runat="server" SkinID="lblPanelSkin" Text="Capacity :" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 87px">
                                  <asp:TextBox ID="txtcapacity" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox>
                                
                                </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 179px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 2px; height: 5px">
            </td>
            <td colspan="8" style="font-size: 10pt">
                &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btn"
                    Text="Save" />
                &nbsp; &nbsp;<asp:Button ID="btnCan" runat="server" OnClick="btnCan_Click" SkinID="btn"
                    Text="Cancel" /></td>
        </tr>
    </table>
</asp:Content>
