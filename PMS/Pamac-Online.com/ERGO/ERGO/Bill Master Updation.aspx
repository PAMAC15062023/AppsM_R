<%@ Page Language="C#" MasterPageFile="~/ERGO/ERGO/MasterPage.master" AutoEventWireup="true" CodeFile="Bill Master Updation.aspx.cs" Inherits="ERGO_ERGO_Bill_Master_Updation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>    
<script language="javascript" type="text/javascript">


    function UpperLetter(ID) {
        ID.value = ID.value.toUpperCase();
    }

    function Validate_Generate()
     {
        var ReturnValue = true;
        var strErrorMessage = "";
        var lblError = document.getElementById("<%=lblError.ClientID%>");
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate = document.getElementById("<%=txtToDate.ClientID%>");

        if (txtFromDate.value == '') 
        {
            strErrorMessage = "Please Select From Date!";
            txtFromDate.focus();
            ReturnValue = false;
        }
        if (txtToDate.value == '')
         {
            strErrorMessage = "Please Select To Date!";
            txtToDate.focus();
            ReturnValue = false;
        }

        lblError.innerText = strErrorMessage;
        window.scrollTo(0, 0);

        return ReturnValue;
    }

    function Validate_On_Save() 
    {
        var ReturnValue = true;
        var strErrorMessage = "";
        var lblError = document.getElementById("<%=lblError.ClientID%>");
        var txtBillNo = document.getElementById("<%=txtBillNo.ClientID%>");
        var txtBillDate = document.getElementById("<%=txtBillDate.ClientID%>");

        if (txtBillNo.value == '') 
        {
            strErrorMessage = "Please Select Bill No!";
            txtBillNo.focus();
            ReturnValue = false;
        }
        if (txtBillDate.value == '') 
        {
            strErrorMessage = "Please Select Bill Date!";
            txtBillDate.focus();
            ReturnValue = false;
        }

        lblError.innerText = strErrorMessage;
        window.scrollTo(0, 0);

        return ReturnValue;
    }
         


    function CheckAll() {
        chequeBoxSelectedCount = 0;
        var GVBillUpd = document.getElementById("<%=GVBillUpd.ClientID%>");
        var chkSelectAll = document.getElementById('chkSelectAll');
        var cell;
        for (i = 0; i <= GVBillUpd.rows.length - 1; i++) 
        {
            cell = GVBillUpd.rows[i].cells[0];
            if (cell != null) {
                for (j = 0; j < cell.childNodes.length; j++) 
                {

                    if (cell.childNodes[j].type == "checkbox") 
                    {
                        cell.childNodes[j].checked = chkSelectAll.checked;
                        chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                    }
                }
            }

        }

   }    
    

   
    
</script>
    <table>
        <tr>
            <td colspan="10">
                <asp:Label ID="lblError" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="10" style="height: 46px">
                <table style="width: 854px">
                    <tr>
                        <td class="tta" colspan="9" style="width: 723px; height: 21px">
                            &nbsp;<strong> Billing Updation Details</strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 118px">
                <strong>Bridge Code</strong></td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtBridgeCode" runat="server"></asp:TextBox>
            </td>
            <td class="reportTitleIncome">
                            &nbsp;</td>
            <td class="Info" colspan="2">
            
                            <asp:DropDownList ID="ddlSTapp" runat="server" SkinID="ddlSkin" Visible="False">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                <asp:ListItem Value="1">No</asp:ListItem>
                            </asp:DropDownList>
            
            </td>
            <td colspan="2">
            
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 118px; height: 23px;">
                <strong>Location</strong></td>
            <td class="Info" style="width: 100px; height: 23px;" colspan="2">
                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" Width="126px" 
                    OnKeyup="UpperLetter(this);"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 132px; height: 23px;">
                <strong>Payee Name</strong></td>
            <td class="Info" colspan="2" style="height: 23px">
                <asp:TextBox ID="txtAltPayeeName" runat="server" Width="202px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 118px; height: 23px;">
                <strong>Month-From Date</strong></td>
            <td class="Info" style="width: 100px; height: 23px;" colspan="2">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="69px"></asp:TextBox>
                                                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
            <td class="reportTitleIncome" style="width: 132px; height: 23px;">
                                        <strong>Month-To Date</strong></td>
            <td class="Info" colspan="2" style="height: 23px">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="84px"></asp:TextBox>
                                                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
            <td style="width: 100px; height: 23px;">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 118px">
                <asp:HiddenField ID="hdnUID" runat="server" />
            </td>
            <td style="width: 100px" colspan="2">
                &nbsp;</td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnBridgeCode" runat="server" />
            </td>
            <td style="width: 132px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="10" class="reportTitleIncome">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" 
                    OnClick="btnSearch_Click" BorderWidth="1px" />&nbsp;
                <asp:Button ID="btnReset" runat="server" BorderWidth="1px" Text="Reset" 
                    onclick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="10" style="height: 15px" class="TableHeader">
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
            <td colspan="10">
                <div style="overflow: scroll; width: 854px; height: 200px">
                    <asp:Panel ID="pnlExport" runat="server" Height="200px" Width="850px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                               
                 <asp:GridView ID="GVBillUpd" runat="server" OnRowDataBound="GVBillUpd_RowDataBound" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="2" AutoGenerateColumns="False">
                 <Columns>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="Bridge_Code" HeaderText="Bridge Code"/>
                 <asp:BoundField DataField="Bill_No" HeaderText="BillNo"/> 
                 <asp:BoundField DataField="Bill_Date" HeaderText="BillDate"/> 
                 <asp:BoundField DataField="Payee_Name" HeaderText="Payee Name"/>                 
                 <asp:BoundField DataField="Location" HeaderText="Location"/>
                 <asp:BoundField DataField="ServiceTaxApplicable" HeaderText="ST Applicable" />                 
                 <asp:BoundField DataField="ServiceTaxNo" HeaderText="ST No" />
                 <asp:BoundField DataField="ServiceCopyRecd" HeaderText="ServiceCopyRecd" />
                 <asp:BoundField DataField="Gross_Amt" HeaderText="Gross Amt" />
                 <asp:BoundField DataField="Pan_No" HeaderText="PAN" />
                 <asp:BoundField DataField="Month" HeaderText="Month" />  
                  <asp:BoundField DataField="UID">
                 <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                 </asp:BoundField>     
                   <asp:BoundField DataField="ReMonth">
                 <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                    <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                 </asp:BoundField>  
                   <asp:BoundField DataField="LotNo">
                     <HeaderStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" />
                     <ItemStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" CssClass="grv_Column_hidden" />
                   </asp:BoundField>        
                  </Columns>              
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>               
                               </td>
                        </tr>
                    </table>
                </asp:Panel>
                </div>
            </td>
        </tr>
        
        <tr>
            <td colspan="10" class="Info">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="1" class="Info" style="width: 118px">
                            <strong>Bill No</strong></td>
            <td colspan="1" class="Info">
                <asp:TextBox ID="txtBillNo" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox>
            </td>
            <td colspan="1" class="Info">
                            <strong>
                Bill Date</strong></td>
            <td class="Info">
                            <asp:TextBox ID="txtBillDate" runat="server" BorderWidth="1px" MaxLength="10" SkinID="txtSkin"
                                Width="96px"></asp:TextBox>
                            <img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" 
                    style="width: 19px; height: 18px" /></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="10" class="Info">
                &nbsp;<asp:Button ID="btnSave" runat="server" 
                    Text="Save" onclick="btnSave_Click" Width="63px"  />
&nbsp;
                <asp:Button ID="btnCan" runat="server" Text="Cancel" OnClick="btnCan_Click" 
                    BorderWidth="1px" />
            </td>
        </tr>
        
        <tr>
            <td colspan="10" class="Info">
                &nbsp;</td>
        </tr>
        
      </table>
</asp:Content>


