<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="Assets_ApproverPage.aspx.cs" Inherits="Assets_ApproverPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>

    <table style="width: 438px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red" Width="325px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5" class="tta">Asset Approver Page</td>
        </tr>
    </table>
    <asp:Panel ID="pnlAssetDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsForAssetApprover" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="UserRemark">  <%--DataKeyNames="UserRemark" add on 29/01/2024--%>
                        <Columns>
                            <%--<asp:BoundField DataField="Emp_Id" HeaderText="Employee ID" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" />--%>
                            <asp:BoundField DataField="Emp_Code" HeaderText="Employee Code" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Emp_Name" HeaderText="Employee Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical_Name" HeaderText="Vertical Name" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Assets_Type" HeaderText="Assets Type" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CreateBy" HeaderText="Added By" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Added Date" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="TransRefNo" HeaderText="Transaction ID" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" /> <%--add on 01/02/2024--%>


                            <asp:TemplateField HeaderText="Remark" runat="server">  <%--add on 29/01/2024--%>
                                <ItemTemplate runat="server">
                                    <asp:TextBox ID="UserRemark" runat="server" Text='<%# Eval("UserRemark") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" Onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Show Details" /><%-- OnClick="btn_Edit_Click1"--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAssetID" runat="server" />
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClick="btnAccept_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PNLBasicDetails" runat="server">
        <table>
            <tr>
            <td class="reportTitleIncome" style="width: 94px; height: 42px">Employee Code &nbsp;</td>
            <td class="Info" style="width: 111px; height: 42px">
                <asp:TextBox ID="txtsearchcode" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
        
            <td style="width: 94px; height: 32px;" class="reportTitleIncome">User Name</td>
            <td style="width: 111px; height: 32px;" class="Info">
                <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
                <td style="width: 113px; height: 32px;" class="reportTitleIncome">Subcentre Name</td>
            <td style="width: 92px; height: 32px;" class="Info">
                <asp:TextBox ID="txtSubCenter" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
            </tr>
            <tr>          
                <td class="reportTitleIncome" style="width: 94px; height: 7px;">Unit /Department</td>
            <td class="Info" style="width: 111px">
                <asp:TextBox ID="txtUnit" runat="server" MaxLength="15" SkinID="txtSkin" Width="135px" Enabled="false"></asp:TextBox></td>  
                <td class="reportTitleIncome" style="height: 7px; width: 113px;">Location</td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtLocation" runat="server" MaxLength="15" SkinID="txtSkin" Width="135px" Enabled="false"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 94px">Vertical Name</td>
            <td class="Info" style="width: 111px">
                 <asp:TextBox ID="txtVerticalName" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 113px">Type Of Assets</td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtAssetType" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 94px">Ownership</td>
            <td class="Info" style="width: 111px">
                <asp:TextBox ID="txtOwnership" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px">Purchase Cost</td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtPurchaseCost" runat="server" SkinID="txtSkin" Enabled="false"></asp:TextBox></td>
        </tr>

        <tr>            
            <td class="reportTitleIncome" style="width: 94px; height: 38px;">Purchase Date</td>
            <td class="Info" style="width: 111px; height: 38px;">
                <asp:TextBox ID="txtPurchaseDate" runat="server" SkinID="txtSkin" Width="75px" Enabled="false"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px; height: 38px;">Status</td>
            <td class="Info" style="width: 92px; height: 38px;">
                <asp:TextBox ID="txtStatus" runat="server" SkinID="txtSkin" Enabled="false"> </asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 94px; height: 6px">
                <asp:Label ID="lblRentAmt" runat="server" Text="Rent Amount" Width="73px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 6px">
               <asp:TextBox ID="txtRentAmt" runat="server" SkinID="txtSkin" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            
            <td class="reportTitleIncome" style="height: 6px; width: 113px;">
                <asp:Label ID="lblApprovalAuth" runat="server" Text="Name of Approval Authority"
                    Visible="False" Width="54px" Height="43px"></asp:Label></td>
            <td class="Info" style="height: 6px; width: 92px;">
                <asp:TextBox ID="txtApprovalAuth" runat="server" SkinID="txtSkin" Visible="False"
                    Width="135px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 94px">&nbsp;<asp:Label ID="lblDate" runat="server" Text="Rent Date" Width="61px"></asp:Label></td>
            <td class="Info" style="width: 111px">
                <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" Width="75px" Enabled="false"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px">
                <asp:Label ID="lblVenderName" runat="server" Text="Vendor Name" Width="73px"></asp:Label></td>
            <td class="Info" style="width: 92px">
                <asp:TextBox ID="txtVenderName" runat="server" SkinID="txtSkin" Width="135px" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>           
            <td class="reportTitleIncome" style="width: 94px; height: 8px">Warranty/AMC</td>
            <td class="Info" style="width: 111px; height: 8px">
                <asp:TextBox ID="txtAmc" runat="server" SkinID="txtSkin" Width="135px" Enabled="false"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 8px; width: 113px;">AMC Info</td>
            <td class="Info" style="width: 92px; height: 8px">
                <asp:TextBox ID="txtAmcInfo" runat="server" SkinID="txtSkin" Width="135px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblDepoDate" runat="server" Text="Date of Deposit" Visible="False"
                    Height="27px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtDepositeDate" runat="server" SkinID="txtSkin" Width="75px" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            
            <td class="reportTitleIncome" style="height: 3px; width: 113px;">
                <asp:Label ID="lblrentalsystem" runat="server" Text="Rental System No" Visible="False"
                    Height="27px" Width="83px"></asp:Label>
            </td>
            <td class="Info" style="width: 92px; height: 3px">
                <asp:TextBox ID="txtrentalsystem" runat="server" SkinID="txtSkin" Visible="false" Width="135px"></asp:TextBox>
            </td>
             <td class="reportTitleIncome" style="width: 94px; height: 3px">
                <asp:Label ID="lblVendorAssetNumber" runat="server" Text="Vendor Asset Number"
                    Height="27px" Width="83px"></asp:Label></td>
            <td class="Info" style="width: 111px; height: 3px">
                <asp:TextBox ID="txtVendorAssetNumber" runat="server" SkinID="txtSkin" Width="113px" Enabled="false"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 113px; height: 38px;">Asset Location</td>
            <td class="Info" style="width: 92px; height: 38px;">
                <asp:TextBox ID="txtAssetLocation" runat="server" SkinID="txtSkin" Enabled="false"></asp:TextBox></td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlInventoryDetails" runat="server">
        <table style="width: 830px">
            
            <tr>
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
        </tr>
        <tr>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                User Name</td>
            <td style="height: 16px;" colspan="4" class="Info">
                <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Assets Type</td>
            <td style="width: 100px; height: 16px" class="Info">
                <asp:Label ID="lblAssetsType" runat="server"></asp:Label></td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Assets Sub Type</td>
            <td style="width: 51px; height: 16px" class="Info">
                <asp:TextBox ID="ddlAssetsSubType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox>
                <asp:Label ID="Lblassetssubtype" runat="server" Text="Label" Width="119px"></asp:Label></td>
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
            </td></tr>
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
                                <asp:Label ID="lblWarrantyType" runat="server" SkinID="lblPanelSkin" Text="Warranty Type :"></asp:Label></td>
                                <td style="width: 179px" class="Info">
                                <asp:TextBox ID="ddlWarrantyType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
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
                                <asp:TextBox ID="ddlUsbPortAvil" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblTotalRacks" runat="server" SkinID="lblPanelSkin" Text="Total Racks To Store :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="txtTotalRacks" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblLockerAvil" runat="server" SkinID="lblPanelSkin" Text="Locker Available :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="ddlLockerAvil" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
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
                                <asp:TextBox ID="ddlRechargeBett" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblConnectivity" runat="server" SkinID="lblPanelSkin" Text="Connectivity :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="ddlConnectivity" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
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
                                 <asp:TextBox ID="ddlProcessor" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblRamType" runat="server" SkinID="lblPanelSkin" Text="RAM Type :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="ddlRam" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblHddGb" runat="server" SkinID="lblPanelSkin" Text="HDD In GB :"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="ddlHdd" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
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
                                <asp:TextBox ID="ddlModelType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
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
                                <asp:TextBox ID="ddlEncodingType" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="Label1" runat="server" SkinID="lblPanelSkin" Text="Encoding Type:"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="DropDownList1" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblKeyBoard" runat="server" SkinID="lblPanelSkin" Text="KeyBoard:"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 87px" class="Info">
                                <asp:TextBox ID="ddlKeyboard" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblMouse" runat="server" SkinID="lblPanelSkin" Text="Mouse:" Visible="False"></asp:Label></td>
                            <td style="width: 179px" class="Info">
                                <asp:TextBox ID="ddlMouse" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblBackupTime" runat="server" SkinID="lblPanelSkin" Text="Backup Time"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtBackupTime" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td style="width: 100px" class="reportTitleIncome">
                                <asp:Label ID="lblbatteryCount" runat="server" SkinID="lblPanelSkin" Text="No of Batteries"
                                    Visible="False"></asp:Label></td>
                            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="ddlbatteryCount" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 100px">
                                <asp:Label ID="labtable" runat="server" SkinID="lblPanelSkin" Text="Table:" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 87px">
                                <asp:TextBox ID="ddltable" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="width: 100px">
                                <asp:Label ID="Lblcapacity" runat="server" SkinID="lblPanelSkin" Text="Capacity :" Visible="False"></asp:Label></td>
                            <td class="Info" style="width: 87px">
                                  <asp:TextBox ID="txtcapacity" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox>
                                
                                </td>
                            </tr>
        </table>
    </asp:Panel>
</asp:Content>
