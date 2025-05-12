<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="BIS_Data_View.aspx.cs" Inherits="ERGO_ERGO_BIS_Data_View" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>    
<script language="javascript" type="text/javascript">


    function UpperLetter(ID) {
        ID.value = ID.value.toUpperCase();
    }

    function checkSelected(chkSelect) {
        //debugger;
        var GVSearchData = document.getElementById("<%=GVSearchData.ClientID%>");
        var chkSelect1 = document.getElementById(chkSelect);


        var cell;
        for (i = 0; i <= GVSearchData.rows.length - 1; i++) {
            cell = GVSearchData.rows[i].cells[0];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) {

                    if (cell.childNodes[j].type == "checkbox") {
                        if (cell.childNodes[j].checked == true) {
                            cell.childNodes[j].checked = false;
                        }

                    }
                }
            }

        }


        chkSelect1.checked = true;

    }

    function Get_SelectedTransactionID(ID) {
        debugger;
        var GVSearchData = document.getElementById("<%=GVSearchData.ClientID%>");
        var hdnUID = document.getElementById("<%=hdnUID.ClientID%>");
        var hdnBridgeCode = document.getElementById("<%=hdnBridgeCode.ClientID%>");
        var lblError = document.getElementById("<%=lblError.ClientID%>");
        var ReturnValue = true;
        var ErrorMessage = '';


        var cell;
        for (i = 0; i <= GVSearchData.rows.length - 1; i++) {
            cell = GVSearchData.rows[i].cells[0];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) {

                    if (cell.childNodes[j].type == "checkbox") {
                        if (cell.childNodes[j].checked == true) {
                            
                              hdnBridgeCode.value = GVSearchData.rows[i].cells[1].innerText;

                            break;
                        }
                    }
                }
            }

        }

        if (hdnBridgeCode.value == '')
         {
            ErrorMessage = "Please select atleast one record to continue!";
            ReturnValue = false;
        }
        lblError.innerText = ErrorMessage;
        window.scroll(0, 0);
        return ReturnValue;

    }
    
</script>
    <table>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="8" style="height: 46px">
                <table style="width: 845px">
                    <tr>
                        <td class="tta" colspan="9" style="width: 723px; height: 21px">
                            &nbsp;BIS Master Data
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px">
                <strong>Bridge Code</strong></td>
            <td class="Info" colspan="2">
                <asp:DropDownList ID="ddlBridgeCode" runat="server" Width="174px" SkinID="ddlSkin">
                </asp:DropDownList>
                <asp:TextBox ID="txtBridgeCode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 132px">
                <strong>BIS Recived Date</strong></td>
            <td class="Info" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtBisDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="100px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBisDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 23px;">
                <strong>Location</strong></td>
            <td class="Info" style="width: 100px; height: 23px;">
                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" Width="109px" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 132px; height: 23px;">
                <strong>Payee Name</strong></td>
            <td class="Info" colspan="3" style="height: 23px">
                <asp:DropDownList ID="ddlPayeeName" runat="server" Width="303px" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" colspan="6" style="height: 23px">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" 
                    OnClick="btnSearch_Click" BorderWidth="1px" />&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" BorderWidth="1px" Text="Reset" 
                    onclick="btnReset_Click" /></td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 15px" class="TableHeader">
            </td>
        </tr>
        <%--<tr>
            <td colspan="8">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="100%">
                    <asp:GridView ID="GVsearch" runat="server" Height="129px">
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td style="width: 100px; height: 65px;">
            </td>
        </tr>--%>
         <tr>
            <td colspan="8">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    <asp:Panel ID="pnlExport" runat="server" Height="200px" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                               
                                   <asp:GridView ID="GVSearchData" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="8pt" 
                                        OnRowDataBound="grv_RowDataBound" PageSize="20" SkinID="gridviewNoSort">
                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                       <Columns>
                                            <asp:TemplateField>
                                               <ItemTemplate>
                                                   <asp:CheckBox ID="chkSelect" runat="server" />
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:BoundField DataField="Bridge_Code" HeaderText="BridgeCode" />
                                           <asp:BoundField DataField="BIS_Recd_Date" HeaderText="BISRecdDate" />
                                           <asp:BoundField DataField="Type_Of_Organisation" HeaderText="TypeOfOrganisation" />
                                           <asp:BoundField DataField="PAN_No" HeaderText="PANNo" />
                                           <asp:BoundField DataField="Account_No" HeaderText="AccountNo" />
                                           <asp:BoundField DataField="Mobile_No" HeaderText="MobileNo" />
                                           <asp:BoundField DataField="Bank_Name" HeaderText="BankName" />
                                           <asp:BoundField DataField="Bank_Branch_Name" HeaderText="BankBranchName" />
                                           <asp:BoundField DataField="MICR_Code" HeaderText="MICRCode" />
                                           <asp:BoundField DataField="ServiceTaxApplicable" HeaderText="ServiceTaxApplicable" />
                                           <asp:BoundField DataField="ServiceTaxNo" HeaderText="ServiceTaxNo" />
                                           <asp:BoundField DataField="ServiceCopyRecd" HeaderText="ServiceCopyRecd"/>
                                           <asp:BoundField DataField="Alternate_Payee_Name" HeaderText="PayeeName"/>
                                           <asp:BoundField DataField="Payable_Location" HeaderText="Payable_Location" />
                                           <asp:BoundField DataField="BIS Status" HeaderText="BIS Status" />
                                            <asp:BoundField DataField="Discrepancy" HeaderText="Discrepancy" />
                                       </Columns>
                                       <RowStyle Font-Names="Tahoma" Font-Size="8pt" BackColor="#F7F6F3" 
                                           ForeColor="#333333" />
                                       <EditRowStyle BackColor="#999999" />
                                       <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                       <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" 
                                           Font-Size="8pt" ForeColor="White" />
                                     </asp:GridView>
               
                               </td>
                        </tr>
                    </table>
                </asp:Panel>
                </div>
            </td>
        </tr>
        
        <tr>
            <td colspan="8" class="Info">
                &nbsp;<asp:Button ID="btnView" runat="server" onclick="btnView_Click" 
                    Text="View" BorderWidth="1px" Width="51px" />
                &nbsp;
                <asp:Button ID="btnCan" runat="server" Text="Cancel" OnClick="btnCan_Click" 
                    BorderWidth="1px" />
            </td>
        </tr>
        
        <tr>
            <td colspan="8" class="Info">
                &nbsp;<asp:HiddenField ID="hdnUID" runat="server" />
                <asp:HiddenField ID="hdnBridgeCode" runat="server" OnValueChanged="hdnBridgeCode_ValueChanged" />
            </td>
        </tr>
        
      </table>
</asp:Content>