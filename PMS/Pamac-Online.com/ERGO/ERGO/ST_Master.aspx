<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="ST_Master.aspx.cs" Inherits="ERGO_ERGO_ST_Master" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>    
<script language="javascript" type="text/javascript">
    
    
    function UpperLetter(ID) 
    {
           ID.value = ID.value.toUpperCase();
    }

    function CheckAll() {
        chequeBoxSelectedCount = 0;
        var GVSearchData = document.getElementById("<%=GVSearchData.ClientID%>");
        var chkSelectAll = document.getElementById('chkSelectAll');
        var cell;
        for (i = 0; i <= GVSearchData.rows.length - 1; i++) {
            cell = GVSearchData.rows[i].cells[0];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) {

                    if (cell.childNodes[j].type == "checkbox") 
                    {
                        cell.childNodes[j].checked = chkSelectAll.checked;
                        chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                    }
                }
            }

        }

    }    
    

        function Get_SelectedTransactionID(ID)
         {
           //debugger;
             var GVSearchData = document.getElementById("<%=GVSearchData.ClientID%>");
             var hdnUID = document.getElementById("<%=hdnUID.ClientID%>");
             var hdnBridgeCode = document.getElementById("<%=hdnBridgeCode.ClientID%>");
             var lblError = document.getElementById("<%=lblError.ClientID%>");
            var ReturnValue = true;
            var ErrorMessage = '';


            var cell;
            for (i = 0; i <= GVSearchData.rows.length - 1; i++) 
            {
                cell = GVSearchData.rows[i].cells[0];
                if (cell != null) {
                    for (j = 0; j < cell.childNodes.length; j++) 
                    {

                        if (cell.childNodes[j].type == "checkbox") 
                        {
                            if (cell.childNodes[j].checked == true)
                             {
                                 hdnUID.value = GVSearchData.rows[i].cells[16].innerText;

                                 hdnBridgeCode.value = GVSearchData.rows[i].cells[1].innerText;

                                break;
                            }
                        }
                    }
                }

            }
            
            if (hdnUID.value == '')
             {
                ErrorMessage = "Please select atleast one record to continue!";
                ReturnValue = false;
             }
            lblError.innerText = ErrorMessage;
            window.scroll(0, 0);
            return ReturnValue;

        }

        
        function checkSelected(chkSelect) {
            //debugger;
            var GVSearchData = document.getElementById("<%=GVSearchData.ClientID%>");
            var chkSelect = document.getElementById(chkSelect);


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


            chkSelect.checked = true;

        }   
    
    
</script>
    <table>
        <tr>
            <td colspan="11">
                <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            
                        <td class="tta" colspan="11">
                            ST Master Details
                        </td>
                  
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px">
                <strong>Bridge Code</strong></td>
            <td class="Info">
                <asp:TextBox ID="txtBridgeCode" runat="server"></asp:TextBox>
            </td>
            <td class="reportTitleIncome">
                <strong>Payee Name</strong></td>
            <td class="Info" style="width: 132px">
                <asp:TextBox ID="txtAltPayeeName" runat="server"></asp:TextBox>
            </td>
            <td class="reportTitleIncome" colspan="2">
                <strong>Location</strong></td>
            <td style="width: 100px" class="Info">
                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" Width="119px" 
                    OnKeyup="UpperLetter(this);"></asp:TextBox>
            </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 23px;">
                <strong>Month-From Date</strong></td>
            <td class="Info" style="width: 100px; height: 23px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img5" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" 
                                style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" style="width: 132px; height: 23px;">
                <strong>Month-To Date</strong></td>
            <td class="Info" colspan="3" style="height: 23px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                               src="../../Images/SmallCalendar.png" 
                                style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 23px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnUID" runat="server" />
            </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnBridgeCode" runat="server" />
            </td>
            <td style="width: 132px">
                <asp:HiddenField ID="hdnInvoiceDate" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="11" class="reportTitleIncome">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" 
                    OnClick="btnSearch_Click" BorderWidth="1px" />&nbsp;
                <asp:Button ID="btnReset" runat="server" BorderWidth="1px" Text="Reset" 
                    onclick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="11" style="height: 15px" class="TableHeader">
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
            <td colspan="11">
                <div style="overflow: scroll; width: 1130px; height: 401px">
                    <asp:Panel ID="pnlExport" runat="server" Height="200px" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                               
                                   <asp:GridView ID="GVSearchData" runat="server" AutoGenerateColumns="False" 
                                       CellPadding="4" Font-Size="8pt" 
                                        OnRowDataBound="grv_RowDataBound" PageSize="20" Width="1226px">
                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                       <Columns>
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                                    <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                                                </HeaderTemplate>
                                               <ItemTemplate>
                                                   <asp:CheckBox ID="chkSelect" runat="server" />
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:BoundField DataField="Bridge_Code" HeaderText="Bridge_Code" />
                                           <asp:BoundField DataField="Month" HeaderText="Month" />
                                           <asp:BoundField DataField="Bill_No" HeaderText="Bill No" />
                                           <asp:BoundField DataField="Bill_Date" HeaderText="Bill Dtd" />
                                           <asp:BoundField DataField="Cheque_No" HeaderText="Chq.No" />
                                           <asp:BoundField DataField="Cheque_Date" HeaderText="Chq. Dtd" />
                                           <asp:BoundField DataField="Location" HeaderText="Payable Location" />
                                           <asp:BoundField DataField="Payee_Name" HeaderText="Payee Name" />
                                           <asp:BoundField DataField="Gross_Amt" HeaderText="Gross Amt" />
                                           <asp:BoundField DataField="ST" HeaderText="ST" />
                                           <asp:BoundField DataField="ServiceTaxNo" HeaderText="ST No" />
                                           <asp:BoundField DataField="STCopyRecdORNot" HeaderText="STCopyRecdORNot"/>
                                           <asp:BoundField DataField="BisStatus" HeaderText="BIS Status" />
                                           <asp:BoundField DataField="Discrepancy" HeaderText="Discrepancy" />
                                            <asp:TemplateField HeaderText="STCopyRecdORNot">
                                                <ItemTemplate>
                                                <asp:DropDownList ID="ddlPrevSTRecd" runat="server"  SkinID="ddlSkin" Width="111px" Text='<%# (DataBinder.Eval(Container.DataItem,"Invoice_Status"))%>'>
                                                            <asp:ListItem>Invoice Not Recd</asp:ListItem>
                                                            <asp:ListItem>Invoice Recd</asp:ListItem>
                                                </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Recd Date">
                                             <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" style="width: 87px">
                                                    <tr>
                                                        <td style="width: 100px">
                                                        <asp:TextBox ID="txtInvoiceDate" runat="server" Width="60" SkinID="txtSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Invoice_Rcvd_Date"))%>' ToolTip='<%# (DataBinder.Eval(Container.DataItem,"Invoice_Rcvd_Date"))%>' ></asp:TextBox></td>
                                                        <td style="width: 100px">
                                                        <asp:Image id="ImgInvoiceDate" runat="server"  AlternateText="Calendar" ImageUrl="~/Images/SmallCalendar.png" /></td>
                                                    </tr>
                                                </table>
                                           </ItemTemplate>
                            </asp:TemplateField>
                                           <asp:BoundField DataField="UID">
                                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                                              <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="Invoice_Status">
                                            <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                                            <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                                           </asp:BoundField>
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
            <td colspan="11" class="Info">
                &nbsp;<asp:Button ID="btnInvoice" runat="server" onclick="btnInvoice_Click" 
                    Text="Save" Width="57px" />
&nbsp;<asp:Button ID="btnViewInvoice" runat="server" onclick="btnViewInvoice_Click" Text="View" 
                    Width="69px" />
&nbsp;<asp:Button ID="btnCan" runat="server" Text="Cancel" OnClick="btnCan_Click" 
                    BorderWidth="1px" />
            </td>
        </tr>
        
        <tr>
            <td colspan="11" class="Info">
                &nbsp;</td>
        </tr>
        
      </table>
</asp:Content>

