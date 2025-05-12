<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_AllTrackerReport.aspx.cs" Inherits="HR_HR_HR_AllTrackerReport" Title="PA Tracker Report" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript">
  
  </script>  

        <table id="tblExport" align="center" width="100%" style="height: 312px">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="topbar" colspan="14" style="height: 35px">
                    &nbsp;All HR-PA Report</td>
            </tr>
            <tr>
                <td colspan="9">
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" SkinID="lblErrorMsg" Font-Bold="True" Font-Size="9pt" Width="468px"></asp:Label></td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    Cluster Name</td>
                <td>
                </td>
                <td class="Info">
                    <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster"
                        DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluter_DataBound"
                        OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" SkinID="ddlSkin" Width="123px">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome">
                    Centre Name</td>
                <td>
                    :</td>
                <td class="Info">
                    <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre"
                        DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" OnDataBound="ddlCentre_DataBound"
                        OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" SkinID="ddlSkin" Width="123px">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome">
                </td>
                <td class="Info">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    Select Report <span style="color: #ff0000">*</span></td>
                <td>
                    :</td>
                <td class="Info">
                    <asp:DropDownList ID="ddlSelectReport" runat="server" SkinID="ddlSkin">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="PA_YearlyPerformanceTracker_MIS">Yearly Performance Tracker</asp:ListItem>
                        <asp:ListItem Value="PA_TrainingEffective_MIS">Training Effective MIS</asp:ListItem>
                        <asp:ListItem Value="Get_OjtDetailsData">Daily Productivity Tracker</asp:ListItem>
                        <asp:ListItem Value="Get_QMSInductionDetailsData">Induction / QMS Training Tracker</asp:ListItem>
                    </asp:DropDownList></td>
                <td class="reportTitleIncome">
                    SubCentre Name</td>
                <td>
                    :</td>
                <td class="Info">
                    <asp:DropDownList ID="ddlSubcentre" runat="server" DataSourceID="sdsSubcetre" DataTextField="SubCentreName"
                        DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound" SkinID="ddlSkin"
                        Width="123px">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome">
                </td>
                <td class="Info">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td class="Info" >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td class="reportTitleIncome" >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td class="Info">
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
                </td>
                <td class="reportTitleIncome">
                    </td>
                <td class="Info">
                    </td>
                <td></td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    Employee Code</td>
                <td>
                </td>
                <td class="Info">
                    <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td class="reportTitleIncome">
                </td>
                <td>
                </td>
                <td class="Info">
                </td>
                <td class="reportTitleIncome">
                </td>
                <td class="Info">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    </td>
                <td>
                    :</td>
                <td class="Info">
                    <asp:Button ID="btnSearch" ValidationGroup="grValidateDate" runat="server" Text="Search" OnClick="btnSearch_Click" Font-Bold="True" Width="153px" /></td>
                <td class="reportTitleIncome">
                </td>
                <td>
                </td>
                <td class="Info">
                    </td>
                <td class="reportTitleIncome">
                </td>
                <td class="Info">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="9" style="height: 21px">
                    <span style="color: #ff0033">* </span><strong><span style="font-size: 8pt">Indicate mandatory fields</span></strong>.</td>
            </tr>
            <tr>
                <td colspan="9" style="height: 21px">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="100%" Height="178px">
                        <asp:GridView ID="GvPaMis" runat="server" Width="851px" Height="31px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <RowStyle ForeColor="#000066" />
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="9" style="height: 21px">
                        <asp:Button ID="btnExportExcel" runat="server" Font-Bold="True" Text="Export To Excel" OnClick="btnExportExcel_Click" /></td>
            </tr>
        </table>
         <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True" ValidationGroup="grValidateDate"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>&nbsp;
        <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate" ValidationGroup="grValidateDate"
            ErrorMessage="Please Enter To Date" Width="4px" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RFVSelectReport" runat="server" ControlToValidate="ddlSelectReport"
        Display="None" ErrorMessage="Please Select Atleast 1 Report" ValidationGroup="grValidateDate"
        Width="4px"></asp:RequiredFieldValidator>

        <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ValidationGroup="grValidateDate" ShowSummary="False" Width="205px" />
    <asp:SqlDataSource ID="sdsSubcetre" runat="server" 
        ProviderName="System.Data.OleDb"></asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sdsCentre" runat="server" 
        ProviderName="System.Data.OleDb"></asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sdsCluster" runat="server" 
        ProviderName="System.Data.OleDb" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME">
    </asp:SqlDataSource>
    

                   
        </fieldset>
        </td></tr></table>
</asp:Content>

