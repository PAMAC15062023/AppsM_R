<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master"
    AutoEventWireup="true" CodeFile="Assets_InventoryUpdation.aspx.cs" Inherits="Admin_Assets_Inventory_Assets_InventoryUpdation"
    Title="Assets Inventory Updation" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script src="../../Admin/Assets_Inventory/js_css/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../../Admin/Assets_Inventory/js_css/jquery-ui.js" type="text/javascript"></script>
    <link href="../../Admin/Assets_Inventory/js_css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="popcalendar.js">
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>


    <script type="text/javascript" language="javascript">

        $(function () {
            var selectedvalue = $('[id*=ddlOwneName] :selected').text();

            if (selectedvalue != "Owned") {
                txtDate = $("[id$=txtDate]").datepicker({

                    changeMonth: false,
                    changeYear: false,
                    stepMonths: false,
                    showOn: "both",
                    buttonImage: "../../Admin/Assets_Inventory/js_css/SmallCalendar.gif",
                    buttonImageOnly: true,
                    dateFormat: "dd/mm/yy",
                    maxDate: '0',
                    yearRange: '1945:' + (new Date).getFullYear(),


                });
            }

        });
        $(function () {
            var selectedvalue = $('[id*=ddlOwneName] :selected').text();

            if (selectedvalue != "Rented") {
                txtPurchaseDate = $("[id$=txtPurchaseDate]").datepicker({


                    changeMonth: true,
                    changeYear: true,
                    dateFormat: "dd/mm/yy",
                    showOn: "both",
                    buttonImage: "../../Admin/Assets_Inventory/js_css/SmallCalendar.gif",
                    buttonImageOnly: true,
                    yearRange: '1945:' + (new Date).getFullYear(),

                });
            }

        });
        $(function () {
            txtDepositeDate = $("[id$=txtDepositeDate]").datepicker({


                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                showOn: "both",
                buttonImage: "../../Admin/Assets_Inventory/js_css/SmallCalendar.gif",
                buttonImageOnly: true,
                yearRange: '1945:' + (new Date).getFullYear(),

            });

        });
        $(function () {
            txtSSRDate = $("[id$=txtSSRDate]").datepicker({


                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                showOn: "both",
                buttonImage: "../../Admin/Assets_Inventory/js_css/SmallCalendar.gif",
                buttonImageOnly: true,
                yearRange: '1945:' + (new Date).getFullYear(),

            });

        });
        $(function () {
            txtDateOfApproval = $("[id$=txtDateOfApproval]").datepicker({


                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                showOn: "both",
                buttonImage: "../../Admin/Assets_Inventory/js_css/SmallCalendar.gif",
                buttonImageOnly: true,
                yearRange: '1945:' + (new Date).getFullYear(),

            });

        });
    </script>

    <script language="javascript" type="text/javascript">
        function Pro_SelectRow(rowno, id) {

            debugger;

            rowno = (parseInt(rowno) + 1);
            var hdnEmpId = document.getElementById("<%=hdnEmpId.ClientID%>");
            var ddlEmpName = document.getElementById("<%=ddlEmpName.ClientID%>");
            var txtUnit = document.getElementById("<%=txtUnit.ClientID%>");
            var txtLocation = document.getElementById("<%=txtLocation.ClientID%>");
            var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
            var ddlAssetsType = document.getElementById("<%=ddlAssetsType.ClientID%>");
            var txtPurchaseDate = document.getElementById("<%=txtPurchaseDate.ClientID%>");
            var txtAmc = document.getElementById("<%=txtAmc.ClientID%>");
            var txtAmcInfo = document.getElementById("<%=txtAmcInfo.ClientID%>");
            var ddlOwneName = document.getElementById("<%=ddlOwneName.ClientID%>");
            var txtPurchaseCost = document.getElementById("<%=txtPurchaseCost.ClientID%>");
            var txtRentAmt = document.getElementById("<%=txtRentAmt.ClientID%>");
            var txtVenderName = document.getElementById("<%=txtVenderName.ClientID%>");
            var txtDate = document.getElementById("<%=txtDate.ClientID%>");
            var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>");
            var txtAmtRecvSale = document.getElementById("<%=txtAmtRecvSale.ClientID%>");
            <%--var txtDepositeDate = document.getElementById("<%=txtDepositeDate.ClientID%>");--%>
            var ddlCenterList = document.getElementById("<%=ddlCenterList.ClientID%>");
            var txtApprovalAuth = document.getElementById("<%=txtApprovalAuth.ClientID%>");
            var txtSSRDate = document.getElementById("<%=txtSSRDate.ClientID%>");
            var ddlSubCentre = document.getElementById("<%=ddlSubCentre.ClientID%>");
            var hdnUID = document.getElementById("<%=hdnUID.ClientID%>");
            var GridView1 = document.getElementById("<%=GridView1.ClientID%>");
            var hdnTransRefNo = document.getElementById("<%=hdnTransRefNo.ClientID%>");
            var HdnTransfer = document.getElementById("<%=HdnTransfer.ClientID%>");
            var txtVendorAssetNumber = document.getElementById("<%=txtVendorAssetNumber.ClientID%>");


            hdnEmpId.value = GridView1.rows[rowno].cells[22].innerText;
            ddlEmpName.value = GridView1.rows[rowno].cells[22].innerText;

            txtUnit.value = GridView1.rows[rowno].cells[3].innerText;

            txtLocation.value = GridView1.rows[rowno].cells[2].innerText;

            ddlVerticalName.value = GridView1.rows[rowno].cells[4].innerText;

            ddlAssetsType.value = GridView1.rows[rowno].cells[5].innerText;

            ddlOwneName.value = GridView1.rows[rowno].cells[8].innerText;

            ddlSubCentre.value = GridView1.rows[rowno].cells[21].innerText;

            HdnTransfer.value = GridView1.rows[rowno].cells[6].innerText;

            txtVendorAssetNumber.value = GridView1.rows[rowno].cells[23].innerText;

            GridView1.value = GridView1.rows[rowno].cells[8].innerText;



            var strpurchase = GridView1.rows[rowno].cells[11].innerText;
            if (strpurchase != '') {
                txtPurchaseDate.value = GridView1.rows[rowno].cells[11].innerText;
                txtPurchaseCost.value = GridView1.rows[rowno].cells[12].innerText;
            }
            else {

            }



            txtRentAmt.value = GridView1.rows[rowno].cells[13].innerText;
            txtDate.value = GridView1.rows[rowno].cells[15].innerText;


            txtVenderName.value = GridView1.rows[rowno].cells[14].innerText;
            ddlStatus.value = GridView1.rows[rowno].cells[7].innerText;



            if (ddlStatus.value == "Available") {

                txtDepositeDate.value = GridView1.rows[rowno].cells[16].innerText;
                txtApprovalAuth.value = GridView1.rows[rowno].cells[17].innerText;

                txtAmc.value = GridView1.rows[rowno].cells[9].innerText;
                txtAmcInfo.value = GridView1.rows[rowno].cells[10].innerText;

            }
            if (ddlStatus.value == "Sold") {

                txtDepositeDate.value = GridView1.rows[rowno].cells[16].innerText;
            }
            if (ddlStatus.value == "Scrap") {
                txtApprovalAuth.value = GridView1.rows[rowno].cells[17].innerText;

            }
            if (ddlStatus.value == "Transfer") {

            }
            ddlSubCentre.value = GridView1.rows[rowno].cells[21].innerText;
            ddlOwneName.value = GridView1.rows[rowno].cells[8].innerText;
            hdnUID.value = GridView1.rows[rowno].cells[19].innerText;

            var i = 0;
            for (i = 0; i <= GridView1.rows.length - 1; i++) {
                if (i != 0) {
                    if (hdnUID.value == GridView1.rows[i].cells[19].innerText) {
                        GridView1.rows[i].style.backgroundColor = "Yellow";
                        hdnTransRefNo.value = GridView1.rows[rowno].cells[6].innerText;
                    }
                    else {
                        GridView1.rows[i].style.backgroundColor = "White";

                    }
                }
            }
        }



        function SaveValidationControl() {
            var ddlEmpName = document.getElementById("<%=ddlEmpName.ClientID%>");
            var ddlSubCentre = document.getElementById("<%=ddlSubCentre.ClientID%>");
            var txtUnit = document.getElementById("<%=txtUnit.ClientID%>");
            var txtLocation = document.getElementById("<%=txtLocation.ClientID%>");
            var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
            var ddlAssetsType = document.getElementById("<%=ddlAssetsType.ClientID%>");
            var ddlOwneName = document.getElementById("<%=ddlOwneName.ClientID%>");

            var txtPurchaseDate = document.getElementById("<%=txtPurchaseDate.ClientID%>");
            var txtPurchaseCost = document.getElementById("<%=txtPurchaseCost.ClientID%>");

            var txtRentAmt = document.getElementById("<%=txtRentAmt.ClientID%>");
            var txtVenderName = document.getElementById("<%=txtVenderName.ClientID%>");
            var txtDate = document.getElementById("<%=txtDate.ClientID%>");

            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");

            var ReturnValue = true;
            var ErrorMsg = "";

            //                    if(ddlEmpName.value==0)
            //                    {
            //                        ErrorMsg='Please Select Employee Name';
            //                        ReturnValue=false;
            //                        ddlEmpName.focus();
            //                    }
            if (ddlSubCentre.value == 0) {
                ErrorMsg = 'Please Select SubCentre';
                ReturnValue = false;
                ddlSubCentre.focus();
            }
            if (txtUnit.value == '') {
                ErrorMsg = 'Please Select Unit';
                ReturnValue = false;
                txtUnit.focus();
            }
            if (txtLocation.value == '') {
                ErrorMsg = 'Please Select Location';
                ReturnValue = false;
                txtLocation.focus();
            }
            if (ddlVerticalName.value == '-Select-') {
                ErrorMsg = 'Please Select Vertical Name';
                ReturnValue = false;
                ddlVerticalName.focus();
            }
            if (ddlAssetsType.value == '-Select-') {
                ErrorMsg = 'Please Select Asset Type';
                ReturnValue = false;
                ddlAssetsType.focus();
            }
            if (ddlOwneName.value == '-Select-') {
                ErrorMsg = 'Please Select Owner Name';
                ReturnValue = false;
                ddlOwneName.focus();
            }
            if (ddlOwneName.value == 'Owned') {
                if (txtPurchaseDate.value == '') {
                    ErrorMsg = 'Please Purchase Date';
                    ReturnValue = false;
                    txtPurchaseDate.focus();
                }
                if (txtPurchaseCost.value == '') {
                    ErrorMsg = 'Please Purchase Cost';
                    ReturnValue = false;
                    txtPurchaseCost.focus();
                }
            }
            if (ddlOwneName.value == 'Rented') {
                if (txtRentAmt.value == '') {
                    ErrorMsg = 'Please Rent Amt';
                    ReturnValue = false;
                    txtRentAmt.focus();
                }
                if (txtVenderName.value == '') {
                    ErrorMsg = 'Please Vender Name';
                    ReturnValue = false;
                    txtVenderName.focus();
                }
                if (txtDate.value == '') {
                    ErrorMsg = 'Please  Rent Date';
                    ReturnValue = false;
                    txtDate.focus();
                }
            }


            lblMessage.innerText = ErrorMsg;
            if (ErrorMsg != '') {
                window.scrollTo(0, 0);
            }
            return ReturnValue;
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>

    <table>
        <tr>
            <td class="tta" colspan="9">
                <span style="font-size: 10pt">Assets Inventory Master Format</span></td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="OrangeRed"
                    SkinID="lblError"></asp:Label>
                <asp:Label ID="lblTransCode" runat="server" Font-Bold="True" ForeColor="RoyalBlue"
                    SkinID="lblError"></asp:Label>
                <asp:Label ID="Lblmessage2" runat="server" Font-Bold="True" ForeColor="SeaGreen"
                    SkinID="lblError"></asp:Label></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 42px">Enter Employee/Client code to search user &nbsp;</td>
            <td class="Info" style="width: 111px; height: 42px">
                <asp:TextBox ID="txtsearchcode" runat="server" SkinID="txtSkin"> </asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px; height: 42px">
                <asp:Button ID="btnsearch_empcode" runat="server" Font-Bold="True" ForeColor="Indigo"
                    Height="25px" OnClick="btnsearch_empcode_Click" SkinID="btn" Text="Search" Width="90px" /></td>
            <%--OnClientClick="searchdata();"--%>
            <td class="Info" style="width: 92px; height: 42px"></td>
            <td colspan="5" rowspan="1" style="height: 42px"></td>
        </tr>
        <tr>
            <td style="width: 94px; height: 32px;" class="reportTitleIncome">User Name</td>
            <td style="width: 111px; height: 32px;" class="Info">
                <asp:DropDownList ID="ddlEmpName" runat="server" OnSelectedIndexChanged="ddlEmpName_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="140px" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="width: 113px; height: 32px;" class="reportTitleIncome">Subcentre Name</td>
            <td style="width: 92px; height: 32px;" class="Info">
                <asp:DropDownList ID="ddlSubCentre" runat="server" SkinID="ddlSkin" Width="140px">
                </asp:DropDownList></td>
            <td colspan="5" rowspan="9">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Visible="False" Width="500px"
                    Height="400px">
                    <asp:GridView CellPadding="4" ForeColor="#333333" GridLines="None" Height="81px"
                        ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server" SkinID="gridviewNoSort">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 7px;">Unit /Department</td>
            <td class="Info" style="width: 111px">
                <asp:TextBox ID="txtUnit" runat="server" MaxLength="15" SkinID="txtSkin" Width="135px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 7px; width: 113px;">Location</td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtLocation" runat="server" MaxLength="15" SkinID="txtSkin" Width="135px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px">Vertical Name</td>
            <td class="Info" style="width: 111px">
                <asp:DropDownList ID="ddlVerticalName" runat="server" SkinID="ddlSkin" Width="140px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>ALL UNIT</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>Collection</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 113px">Type Of Assets</td>
            <td class="Info" style="width: 92px">
                <asp:DropDownList ID="ddlAssetsType" runat="server" SkinID="ddlSkin" Width="140px" OnSelectedIndexChanged="ddlAssetsType_SelectedIndexChanged" AutoPostBack="true">
                    <%-- <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                    <asp:ListItem Value='AC'>AC</asp:ListItem>
                    <asp:ListItem Value='CN'>Cabinate</asp:ListItem>
                    <asp:ListItem Value='CM'>Camera</asp:ListItem>
                    <asp:ListItem Value='CH'>Chair</asp:ListItem>
                    <asp:ListItem Value='CB'>CupBoard</asp:ListItem>
                    <asp:ListItem Value='EM'>Encoding Machine</asp:ListItem>
                    <asp:ListItem Value='FN'>Fan</asp:ListItem>
                    <asp:ListItem Value='FX'>Fax</asp:ListItem>
                    <asp:ListItem Value='FW'>Firewall</asp:ListItem>
                    <asp:ListItem Value='LT'>Laptop</asp:ListItem>
                    <asp:ListItem Value='MB'>Mobile</asp:ListItem>
                    <asp:ListItem Value='MD'>Modem</asp:ListItem>
                    <asp:ListItem Value='PC'>PC</asp:ListItem>
                    <asp:ListItem Value='UPS'>UPS</asp:ListItem>
                    <asp:ListItem Value='INV'>Invertor</asp:ListItem>
                    <asp:ListItem Value='PT'>Printer</asp:ListItem>
                    <asp:ListItem Value='RC'>Recorder</asp:ListItem>
                    <asp:ListItem Value='RT'>Router</asp:ListItem>
                    <asp:ListItem Value='SC'>Scanner</asp:ListItem>
                    <asp:ListItem Value='SV'>Server</asp:ListItem>
                    <asp:ListItem Value='SP'>Speaker</asp:ListItem>
                    <asp:ListItem Value='SW'>Switch</asp:ListItem>
                    <asp:ListItem Value='TB'>Table</asp:ListItem>
                    <asp:ListItem Value='TP'>Telephone</asp:ListItem>
                    <asp:ListItem Value='TL'>Tubelight</asp:ListItem>
                    <asp:ListItem Value='BB'>BlackBoard</asp:ListItem>
                    <asp:ListItem Value='WB'>WhiteBoard</asp:ListItem>
                    <asp:ListItem Value='CK'>Clock</asp:ListItem>
                    <asp:ListItem Value='KBT'>KeyBoardTrolly</asp:ListItem>
                    <asp:ListItem Value='PCT'>PaperCutter</asp:ListItem>
                    <asp:ListItem Value='WTK'>WaterTank</asp:ListItem>
                    <asp:ListItem Value='LOC'>Locker</asp:ListItem>
                    <asp:ListItem Value='FEX'>FireExtingusher</asp:ListItem>
                    <asp:ListItem Value='RACK'>Rack</asp:ListItem>
                    <asp:ListItem Value='FAB'>FirstAidBox</asp:ListItem>
                    <asp:ListItem Value='WD'>Water Dispenser</asp:ListItem>
                    <asp:ListItem Value='Prj'>Projector</asp:ListItem>
                    <asp:ListItem Value='AIR_C'>Air Cooler</asp:ListItem>
                    <asp:ListItem Value='BIOM'>Biometric</asp:ListItem>
                    <asp:ListItem Value='PSHM'>PaperShredderMachine</asp:ListItem>
                    <asp:ListItem Value='ELB'>ElectricBlower</asp:ListItem>
                    <asp:ListItem Value='NB'>NoticeBoard</asp:ListItem>
                    <asp:ListItem Value='GEN'>Generator</asp:ListItem>
                    <asp:ListItem Value='DVR'>DVR</asp:ListItem>
                    <asp:ListItem Value='HP'>Headphone</asp:ListItem>
                    <asp:ListItem Value='TVM'>Tea Vending Machine</asp:ListItem>
                    <asp:ListItem Value='SMK'>Smoke Detector</asp:ListItem>
                    <asp:ListItem Value='EHD'>External Hard Disc</asp:ListItem>
                    <asp:ListItem Value='ITM'>Infread Thermometer</asp:ListItem>
                    <asp:ListItem Value='WC'>Water Cooler</asp:ListItem>
                    <asp:ListItem Value='WCam'>Web Cam</asp:ListItem>
                    <asp:ListItem Value='HD'>Hard Disk</asp:ListItem>
                    <asp:ListItem Value='BTY'>Battery</asp:ListItem>
                    <asp:ListItem Value='PTY'>Plastic Trolly</asp:ListItem>--%>
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td class="reportTitleIncome" style="width: 94px">Ownership</td>
            <td class="Info" style="width: 111px">
                <asp:DropDownList ID="ddlOwneName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOwneName_SelectedIndexChanged" SkinID="ddlSkin" Width="140px">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="Owned">Owned</asp:ListItem>
                    <asp:ListItem Value="Rented">Rented</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 113px">Purchase Cost</td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtPurchaseCost" runat="server" SkinID="txtSkin" Width="135px"
                    onkeypress="return isNumber(event)" onpaste="return false;" ondrop="return false;" autocomplete="off"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 38px;">Purchase Date</td>
            <td class="Info" style="width: 111px; height: 38px;">
                <asp:TextBox ID="txtPurchaseDate" runat="server" SkinID="txtSkin" Width="75px"></asp:TextBox><%--<img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPurchaseDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />--%></td>
            <td class="reportTitleIncome" style="width: 113px; height: 38px;">Status</td>
            <td class="Info" style="width: 92px; height: 38px;">
                <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                    AutoPostBack="True" Width="140px">
                    <%-- <asp:ListItem>Available</asp:ListItem>
                    <asp:ListItem>Sold</asp:ListItem>
                    <asp:ListItem>Declare scrap</asp:ListItem>
                    <asp:ListItem>Scrap</asp:ListItem>
                    <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                    <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                    <asp:ListItem>Returned  to Vendor</asp:ListItem> --%>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 6px">
                <asp:Label ID="lblRentAmt" runat="server" Text="Rent Amount" Width="73px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 6px">
                <asp:TextBox ID="txtRentAmt" runat="server" SkinID="txtSkin" Width="135px"
                    onkeypress="return isNumber(event)" onpaste="return false;" ondrop="return false;" autocomplete="off"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 6px; width: 113px;">
                <asp:Label ID="lblApprovalAuth" runat="server" Text="Name of Approval Authority"
                    Visible="False" Width="54px" Height="43px"></asp:Label></td>
            <td class="Info" style="height: 6px; width: 92px;">
                <asp:TextBox ID="txtApprovalAuth" runat="server" SkinID="txtSkin" Visible="False"
                    Width="135px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px">&nbsp;<asp:Label ID="lblDate" runat="server" Text="Rent Date" Width="61px"></asp:Label></td>
            <td class="Info" style="width: 111px">
                <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" Width="75px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px">
                <asp:Label ID="lblVenderName" runat="server" Text="Vendor Name" Width="73px"></asp:Label></td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtVenderName" runat="server" SkinID="txtSkin" Width="135px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 8px">Warranty/AMC</td>
            <td class="Info" style="width: 111px; height: 8px">
                <asp:TextBox ID="txtAmc" runat="server" SkinID="txtSkin" Width="135px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 8px; width: 113px;">AMC Info</td>
            <td class="Info" style="width: 92px; height: 8px">
                <asp:TextBox ID="txtAmcInfo" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="135px"></asp:TextBox></td>
        </tr>
        <%--<tr>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblDepoDate" runat="server" Text="Date of Deposit" Visible="False"
                    Height="27px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtDepositeDate" runat="server" SkinID="txtSkin" Width="75px" Visible="False"></asp:TextBox><%--<img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="height: 3px; width: 113px;">
                <asp:Label ID="lblrentalsystem" runat="server" Text="Rental System No" Visible="False"
                    Height="27px" Width="83px"></asp:Label>
            </td>
            <td class="Info" style="width: 92px; height: 3px">
                <asp:TextBox ID="txtrentalsystem" runat="server" SkinID="txtSkin" Visible="false" Width="135px"></asp:TextBox>
            </td>
        </tr>--%>

        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="Label1" runat="server" Text="Vendor Asset Number/Rental System Number"
                    Height="40px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtVendorAssetNumber" runat="server" SkinID="txtSkin" Width="113px"></asp:TextBox></td>

            <td class="reportTitleIncome" style="width: 113px; height: 38px;">Asset Location</td>
            <td class="Info" style="width: 92px; height: 38px;">
                <asp:DropDownList ID="ddlAssetLocation" runat="server" SkinID="ddlSkin" AutoPostBack="false" Width="140px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 38px;">Date Of Approval</td>
            <td class="Info" style="width: 111px; height: 38px;">
                <asp:TextBox ID="txtDateOfApproval" runat="server" SkinID="txtSkin" Width="75px"></asp:TextBox><%--<img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfApproval.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />--%></td>
        </tr>

        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblAssetsRating" runat="server" Text="Assets Rating"
                    Height="27px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:DropDownList ID="ddlAssetsRating" runat="server" SkinID="ddlSkin" AutoPostBack="false" Width="140px">
                </asp:DropDownList>
            </td>

            <td class="reportTitleIncome" style="width: 113px; height: 38px;">
                <asp:Label ID="lblSecurityRating" runat="server" Text="Security Rating"
                    Height="27px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 92px; height: 38px;">
                <asp:DropDownList ID="ddlSecurityRating" runat="server" SkinID="ddlSkin" AutoPostBack="false" Width="140px">
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblCompName" runat="server" Text="Company name" Visible="false" Height="27px"
                    Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtCompName" runat="server" SkinID="txtSkin" Visible="false" TextMode="MultiLine"
                    Width="135px"></asp:TextBox>
            </td>

            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblModelname" runat="server" Visible="false" Text="Model Name" Height="27px" Width="83px"></asp:Label>
            </td>
            <td class="Info" style="height: 3px; width: 113px;">
                <asp:TextBox ID="txtmodelname" runat="server" Visible="false" SkinID="txtSkin" Width="135px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <%-- <asp:Label ID="lblCompName" runat="server" Text="Company name" visible="false" Height="27px"
                    Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtCompName" runat="server" SkinID="txtSkin" visible="false" TextMode="MultiLine"
                    Width="135px"></asp:TextBox>--%>
            </td>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblCapacity" runat="server" Text="Capacity" Visible="False" Height="27px"
                    Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtCapacity" runat="server" Visible="False" SkinID="txtSkin" Width="135px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" colspan="9" style="height: 6px">
                <asp:Panel ID="Pnlwrnt" runat="server">
                    <table style="width: 760px; height: 11px;" id="tblwarrAmc">
                        <tr>
                            <td class="reportTitleIncome" style="width: 156px; height: 31px" align="center">Scrap /Sold / Return Approved By</td>
                            <td class="Info" style="width: 79px; height: 31px;">
                                <asp:TextBox ID="TxtSSRApproveBy" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="height: 31px; width: 184px;" align="center">Scrap / Sold / Returned &nbsp;Date</td>
                            <td class="Info" style="width: 220px; height: 31px;">
                                <asp:TextBox ID="txtSSRDate" runat="server" SkinID="txtSkin" Width="140px" Visible="False"></asp:TextBox>
                                *DD/MM/YYYY</td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="height: 3px; width: 156px;" align="center">Amount Received</td>
                            <td class="Info" style="width: 79px; height: 3px">
                                <asp:TextBox ID="txtAmtRecvSale" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="height: 3px; width: 184px;"></td>
                            <td class="reportTitleIncome" style="width: 220px; height: 3px">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" colspan="9" style="height: 6px">
                <asp:Panel ID="pnlTransfer" runat="server">
                    <table style="width: 730px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 219px; height: 26px" align="right">&nbsp;<asp:Label ID="lblclustername" runat="server" Height="16px" Text="Cluster Name"
                                Visible="False" Width="75px"></asp:Label></td>
                            <td class="Info" style="width: 258px; height: 26px" align="right">
                                <asp:DropDownList ID="ddlclustername" runat="server" SkinID="ddlSkin" Width="150px"
                                    OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 262px; height: 26px">
                                <asp:Label ID="lblBranchTrans" runat="server" Height="16px" Text="Name of Branch Transfer"
                                    Visible="False" Width="127px"></asp:Label></td>
                            <td class="Info" style="width: 164px; height: 26px">
                                <asp:DropDownList ID="ddlCenterList" runat="server" SkinID="ddlSkin" Visible="False"
                                    Width="150px" OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 219px; height: 15px">
                                <asp:Label ID="lblsubcentrename" runat="server" Height="16px" Text="SubCentre Name"
                                    Visible="False" Width="91px"></asp:Label></td>
                            <td class="Info" style="width: 258px; height: 15px">
                                <asp:DropDownList ID="ddlsubcentrename" runat="server" SkinID="ddlSkin" Width="150px"
                                    OnSelectedIndexChanged="ddlsubcentrename_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" align="left" style="width: 262px; height: 15px">Approved &nbsp;By</td>
                            <td class="Info" style="width: 164px; height: 15px">
                                <asp:TextBox ID="txttrfApprovby" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 219px; height: 3px">Enter Emp Code To Search User&nbsp;</td>
                            <td class="Info" style="width: 258px; height: 3px">
                                <asp:TextBox ID="txtsearch2" runat="server" SkinID="txtSkin"></asp:TextBox><asp:Button
                                    ID="btnsearch" runat="server" Font-Bold="True" ForeColor="Indigo" Height="25px"
                                    OnClick="btnsearch_Click" SkinID="btn" Text="Search" Width="90px" /></td>
                            <%--OnClientClick="searchdata();"--%>
                            <td class="reportTitleIncome" style="width: 262px; height: 3px"></td>
                            <td class="Info" style="width: 164px; height: 3px"></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 219px; height: 3px;">
                                <asp:Label ID="lblpamaciantransfer" runat="server" Text="Transfer To Pamacian" Visible="False"
                                    Width="111px" Height="17px"></asp:Label></td>
                            <td class="Info" style="width: 258px; height: 3px;">
                                <asp:DropDownList ID="ddlpamaciantransfer" runat="server" SkinID="ddlSkin" Visible="False"
                                    Width="150px" OnSelectedIndexChanged="ddlpamaciantransfer_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Lbltraname" runat="server" Visible="False"></asp:Label></td>
                            <td class="reportTitleIncome" style="width: 262px; height: 3px;">
                                <asp:Label ID="lbldateTransfer" runat="server" Text="Date Of Transfer" Visible="False"
                                    Width="87px" Height="16px"></asp:Label></td>
                            <td class="Info" style="width: 164px; height: 3px;">
                                <asp:TextBox ID="txtdateofTrasfer" runat="server" SkinID="txtSkin" Visible="False"
                                    Width="140px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <%-- New--%>
                        <%-- New--%>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 6px">
                <asp:Button ID="btnSave" runat="server" SkinID="btn" Text="Save" OnClick="btnSave_Click"
                    Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo" />&nbsp;
                <asp:Button ID="btnNew" runat="server" SkinID="btnAddNewSkin" Text="Add New" OnClick="btnNew_Click"
                    Height="25px" Width="90px" Font-Bold="True" ForeColor="Indigo" />
                &nbsp;<asp:Button ID="BtnTransfer" runat="server" Height="24px" OnClick="BtnTransfer_Click"
                    SkinID="btn" Text="Transfer" Font-Bold="True" ForeColor="Indigo" Width="90px" />&nbsp;
                &nbsp;<asp:Button ID="btnCan" runat="server" SkinID="btn" Text="Cancel" OnClick="btnCan_Click"
                    Height="24px" Width="90px" Font-Bold="True" ForeColor="Indigo" />
                &nbsp;&nbsp;&nbsp;</td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 3px;"></td>
            <td colspan="8">
                <asp:HiddenField ID="hdnEmpCode" runat="server" />
                <asp:HiddenField ID="HdnEmp" runat="server" />
                <asp:HiddenField ID="HdnTransStatus" runat="server" />
                <asp:HiddenField ID="HdnTransEmpName" runat="server" />
                <asp:HiddenField ID="hdnTransRefNo" runat="server" />
                <asp:HiddenField ID="hdnIsITAssets" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 32px"></td>
            <td colspan="8" style="height: 32px">
                <table style="width: 1px">
                    <tr>
                        <td style="height: 16px; width: 3px;"></td>
                        <td style="width: 146px; height: 16px;">
                            <asp:HiddenField ID="hdfCluster" runat="server" />
                            <asp:HiddenField ID="HdnTrsEMPCODE" runat="server" />
                        </td>
                        <td style="width: 184px; height: 16px;">
                            <asp:HiddenField ID="hdfSubcentre" runat="server" />
                            <asp:HiddenField ID="HdnTransfer" runat="server" />
                        </td>
                        <td style="width: 165px; height: 16px;">
                            <asp:HiddenField ID="hdfCentre" runat="server" />
                            <asp:HiddenField ID="hdnUID" runat="server" />
                        </td>
                        <td style="height: 16px;" colspan="5">
                            <asp:HiddenField ID="hdnEmpId" runat="server" />
                            <asp:HiddenField ID="hdnTransactionID" runat="server" />
                            &nbsp; &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   <%-- <asp:Panel ID="PnlRejectedAssets" runat="Server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsForAssetApprover" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="UserRemark">
                        <Columns>
                            <asp:BoundField DataField="Assets_Type" HeaderText="Asset Type" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Purchase_Date" HeaderText="Purchase Date" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="TransRefNo" HeaderText="Transaction ID" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Centre_Name" HeaderText="Center Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Subcentre_id" HeaderText="Sub Center ID" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Purchase_Cost" HeaderText="Purchase Cost" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vender_Name" HeaderText="Vendor Name" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vender_Date" HeaderText="Vendor Date" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="UserRemark" HeaderText="User Remark" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" Onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAssetID" runat="server" />
    </asp:Panel>--%>

    <asp:HiddenField ID="hdnEmployeeID" runat="server" />
</asp:Content>
