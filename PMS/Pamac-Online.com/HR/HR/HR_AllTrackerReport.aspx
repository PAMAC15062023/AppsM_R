<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true"
    CodeFile="HR_AllTrackerReport.aspx.cs" Inherits="HR_HR_HR_AllTrackerReport" Title="PA Tracker Report"
    StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
        <tr>
            <td>
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
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" SkinID="lblErrorMsg" Font-Bold="True"
                                    Font-Size="9pt" Width="468px"></asp:Label></td>
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
                                    <asp:ListItem>-Select-</asp:ListItem>
                                    <%--<asp:ListItem Value="Sp_IDAutomation">Pamacian MIS</asp:ListItem>--%>
                                    <asp:ListItem Value="PA_YearlyPerformanceTracker_MIS">Yearly Performance Tracker</asp:ListItem>
                                    <asp:ListItem Value="PA_TrainingEffective_MIS">Training Effective MIS</asp:ListItem>
                                    <asp:ListItem Value="Get_OjtDetailsData">Daily Productivity Tracker</asp:ListItem>
                                    <asp:ListItem Value="Get_OjtDetailsData_AllCentre">Daily Productivity Tracker All Cluster</asp:ListItem>
                                    <asp:ListItem Value="Sp_Pivot_OJT">Productivity Analysis MI Cluster</asp:ListItem>
                                    <asp:ListItem Value="Sp_Pivot_OJT_PANINDA">Productivity Analysis MI PANINDIA</asp:ListItem>
                                    <asp:ListItem Value="OJT_MIS_New">Daily Productivity Tracker NEW</asp:ListItem>
                                    <asp:ListItem Value="Get_OjtDetailsDataNotUpdated_Allcentre">Daily Productivity NOT Updated All Cluster</asp:ListItem>
                                    <asp:ListItem Value="GET_OJTCOUNTReport">Daily Productivity Count MIS</asp:ListItem>
                                    <%--<asp:ListItem Value="Get_QMSInductionDetailsData">Induction / QMS Training Tracker</asp:ListItem>--%>
                                    <asp:ListItem Value="Get_QMSInductionDetailsDataNew">Induction / QMS Training Tracker</asp:ListItem>
                                    <asp:ListItem Value="Get_InductionDumpReport">Induction Dump Report</asp:ListItem>
                                    <%--<asp:ListItem Value="Get_QMSInductionDetailsDataNull">Induction / QMS Training Pending Tracker</asp:ListItem>--%>
                                    <asp:ListItem Value="Get_Engage90DetailsDataNew">Engage 90 Training Report</asp:ListItem>
                                    <asp:ListItem Value="Get_Engage90DetailsData">Engage 90 Dump Tracker</asp:ListItem>
                                    <asp:ListItem Value="Get_EngageInductionData">Induction / Engage 90 Combined Tracker</asp:ListItem>
                                    <asp:ListItem Value="sp_timetrackerouttime">Attendance OutTime Deviation Tracker</asp:ListItem>
                                    <%--<asp:ListItem Value="sp_timetrackerout">Attendance Intime Deviation Tracker</asp:ListItem>--%>
                                    <asp:ListItem Value="Sp_TimetrackerOutabhi_new_16jul2016_New">Attendance Intime Deviation Tracker</asp:ListItem>
                                    <asp:ListItem Value="Sp_attendancelist">Attendance Tracker</asp:ListItem>
                                    <asp:ListItem Value="dolUpdationReport12">Dol Updation Report</asp:ListItem>
                                    <asp:ListItem Value="get_induction">Induction Data Report</asp:ListItem>
                                    <asp:ListItem Value="get_induction12">Induction Pending Data Report</asp:ListItem>
                                    <asp:ListItem Value="get_PMSComplate">Pmt Data</asp:ListItem>
                                    <%--<asp:ListItem Value="c_satreport">C-SAT DATA</asp:ListItem>--%>
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
                            <td class="reportTitleIncome">
                                From Date <font color="red">* </font>
                            </td>
                            <td>
                                :</td>
                            <td class="Info">
                                <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10"></asp:TextBox>
                                <img id="imgFromDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
                            </td>
                            <td class="reportTitleIncome">
                                To Date <font color="red">*</font></td>
                            <td>
                                :</td>
                            <td class="Info">
                                <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                                    Text=""></asp:TextBox>
                                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.gif" style="width: 19px;" height="16" />[dd/MM/yyyy]
                            </td>
                            <td class="reportTitleIncome">
                            </td>
                            <td class="Info">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="height: 30px">
                                Employee Code</td>
                            <td style="height: 30px">
                                :
                            </td>
                            <td class="Info" style="height: 30px">
                                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="height: 30px">
                                Vertical</td>
                            <td style="height: 30px">
                                :</td>
                            <td class="Info" style="height: 30px">
                                <asp:DropDownList ID="ddlVertical" runat="server" SkinID="ddlSkin" Width="136px">
                                    <asp:ListItem>ALL</asp:ListItem>
                                    <asp:ListItem>PTPU</asp:ListItem>
                                    <asp:ListItem>PFRC</asp:ListItem>
                                    <asp:ListItem>PCPV</asp:ListItem>
                                    <asp:ListItem>PDCR</asp:ListItem>
                                    <asp:ListItem>PCPA</asp:ListItem>
                                    <asp:ListItem>ADMIN</asp:ListItem>
                                    <asp:ListItem>DCH</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="height: 30px">
                            </td>
                            <td class="Info" style="height: 30px">
                            </td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="reportTitleIncome" style="height: 30px">
                                DCH</td>
                            <td style="height: 30px">
                                :</td>
                            <td class="Info" style="height: 30px">
                                <asp:DropDownList ID="ddlDCH" runat="server" SkinID="ddlSkin" Width="136px">
                                    <asp:ListItem Value='ALL'>ALL</asp:ListItem>
                                    <asp:ListItem Value='102083'>ABHIJIT MITRA</asp:ListItem>
                                    <asp:ListItem Value='101106947'>AMIT GULATI</asp:ListItem>
                                    <asp:ListItem Value='102979'>AMIT MISHRA</asp:ListItem>
                                    <asp:ListItem Value='101147759'>BABAR MIAN</asp:ListItem>
                                    <asp:ListItem Value='101103516'>GANESH SAWANT</asp:ListItem>
                                    <asp:ListItem Value='103390'>MAHENDRA JADHAV</asp:ListItem>
                                    <asp:ListItem Value='101318'>MAULIK TIKARIYA</asp:ListItem>
                                    <asp:ListItem Value='101103522'>MURUGAN ODIYAR</asp:ListItem>
                                    <asp:ListItem Value='102077'>PRAMOD PATIL</asp:ListItem>
                                    <asp:ListItem Value='101144721'>PRASHANT ASHAR</asp:ListItem>
                                    <asp:ListItem Value='101566'>PRAVIN SHINDE</asp:ListItem>
                                    <asp:ListItem Value='102118'>PRITHVIRAJ P JOSHI</asp:ListItem>
                                    <asp:ListItem Value='101104314'>RAJAGOPALAN RAGAVAN</asp:ListItem>
                                    <asp:ListItem Value='101920'>RAJESH AGRAWAL</asp:ListItem>
                                    <asp:ListItem Value='10133'>RAJESH M PATEL</asp:ListItem>
                                    <asp:ListItem Value='101106219'>RAVI KIRAN SAGI</asp:ListItem>
                                    <asp:ListItem Value='101146474'>SACHIN PANDHARINATH SAWANT</asp:ListItem>
                                    <asp:ListItem Value='103376'>SACHIN TIRLOTKAR</asp:ListItem>
                                    <asp:ListItem Value='101889'>SAMEER KUDALKAR</asp:ListItem>
                                    <asp:ListItem Value='101738'>SANSAR CHAND</asp:ListItem>
                                    <asp:ListItem Value='101144593'>SANTOSH LAXMAN MORAJKAR</asp:ListItem>
                                    <asp:ListItem Value='101151574'>SEEMA MOHAN APIL</asp:ListItem>
                                    <asp:ListItem Value='101103928'>SHANKAR VARISH KAMAT</asp:ListItem>
                                    <asp:ListItem Value='101150227'>VINOD KUTTY</asp:ListItem>
                                    <asp:ListItem Value='103386'>VIPUL Z GOGRI</asp:ListItem>
                                    <asp:ListItem Value='101104959'>ZAKIR HUSSAIN E</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="reportTitleIncome" style="height: 30px">
                            </td>
                            <td style="height: 30px">
                            </td>
                            <td class="Info" style="height: 30px">
                            </td>
                            <td class="reportTitleIncome" style="height: 30px">
                            </td>
                            <td class="Info" style="height: 30px">
                            </td>
                            <td style="height: 30px">
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="reportTitleIncome">
                            </td>
                            <td>
                            </td>
                            <td class="Info">
                                <asp:Button ID="btnSearch" ValidationGroup="grValidateDate" runat="server" Text="Search"
                                    OnClick="btnSearch_Click" Font-Bold="True" Width="153px" /></td>
                            <td class="reportTitleIncome">
                                <asp:Button ID="btnHrFinalPenalty" ValidationGroup="grValidateDate" runat="server"
                                    Text="Final Penalty" OnClick="btnHrFinalPenalty_Click" Font-Bold="True" Width="153px"
                                    Visible="False" /></td>
                            <td>
                            </td>
                            <td class="Info">
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/Employeemanagement/Birthdayemail.aspx">HyperLink</asp:HyperLink></td>
                            <td class="reportTitleIncome">
                            </td>
                            <td class="Info">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server"  Multiple="Multiple" SkinID="flup" Width="330px" Height="23px" Visible="False" />
                            </td>
                            <td colspan="2">
                                <asp:Button ID="BtnUploadImg" runat="server"  Text="Button" OnClick="BtnUploadImg_Click" Visible="False" />
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="height: 21px">
                                <span style="color: #ff0033">* </span><strong><span style="font-size: 8pt">Indicate
                                    mandatory fields</span></strong>.</td>
                        </tr>
                        <tr>
                            <td colspan="9" style="height: 21px">
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="950px" Height="178px">
                                    <asp:GridView ID="GvPaMis" runat="server" Width="851px" Height="31px" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="GvPaMis_RowDataBound">
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
                                <asp:Button ID="btnExportExcel" runat="server" Font-Bold="True" Text="Export To Excel"
                                    OnClick="btnExportExcel_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="9" style="height: 23px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="height: 21px">
                                <asp:FileUpload ID="xslFileUpload" runat="server" Width="205px" SkinID="flup" />&nbsp;
                                &nbsp;<asp:Label ID="Label1" runat="server" Text="[Only *.xls]"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9" style="height: 21px">
                                <asp:Button ID="btnUplaod" runat="server" CssClass="button" SkinID="btnImport" OnClick="btnUplaod_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
                        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
                        ValidationGroup="grValidateDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
                        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
                        ValidationGroup="grValidateDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>&nbsp;
                    <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtFromDate"
                        ValidationGroup="grValidateDate" ErrorMessage="Please Enter From Date" Display="None"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtToDate"
                        ValidationGroup="grValidateDate" ErrorMessage="Please Enter To Date" Width="4px"
                        Display="None"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RFVSelectReport" runat="server" ControlToValidate="ddlSelectReport"
                        Display="None" ErrorMessage="Please Select Atleast 1 Report" ValidationGroup="grValidateDate"
                        Width="4px"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="vsum" runat="server" ShowMessageBox="True" ValidationGroup="grValidateDate"
                        ShowSummary="False" Width="205px" />
                    <asp:SqlDataSource ID="sdsSubcetre" runat="server" ProviderName="System.Data.OleDb">
                    </asp:SqlDataSource>
                    <br />
                    <asp:SqlDataSource ID="sdsCentre" runat="server" ProviderName="System.Data.OleDb"></asp:SqlDataSource>
                    <br />
                    <asp:SqlDataSource ID="sdsCluster" runat="server" ProviderName="System.Data.OleDb"
                        SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME">
                    </asp:SqlDataSource>
                    <br />
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
