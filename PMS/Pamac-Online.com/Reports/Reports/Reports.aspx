<%@ Page Language="C#" MasterPageFile="~/Reports/Reports/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports_Reports_Reports" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>    
 
 <script language="javascript" type="text/javascript">
    
        function OnSearch_Validation()
        {
            var ReturnValue=true;
            var ErrorMessage ='';
            var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>"); 
            var txtToDate = document.getElementById("<%=txtToDate.ClientID%>") 
            var ddlMisType = document.getElementById("<%=ddlMisType.ClientID%>")
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>") 
            
          if(txtFromDate.value == '')
          {
            ErrorMessage='Plz Select From Date';
            ReturnValue=false;
          }  
          
          if(txtToDate.value == '')
          {
            ErrorMessage='Plz Select To Date';
            ReturnValue=false;
          }
          
          if(ddlMisType.selectedIndex == 0)
          {
            ErrorMessage='Plz Select MIS';
            ReturnValue=false;
          }
          
          lblMessage.innerText = ErrorMessage;
          return ReturnValue;
          
        } 
 </script> 
 
    <table>
        <tr>
            <td style="width: 102px; height: 15px">
                </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 84px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 183px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px" colspan="6">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblErrorMsg"
                    Width="814px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px" class="reportTitleIncome">
                Cluster Name :</td>
            <td style="width: 100px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlCluster" runat="server" AutoPostBack="True" DataSourceID="SDScluster"
                    DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluster_DataBound"
                    OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged" SkinID="ddlSkin" Width="154px">
                </asp:DropDownList></td>
            <td style="width: 84px; height: 16px" class="reportTitleIncome">
                Center Name :</td>
            <td class="Info" colspan="" rowspan="">
                <asp:DropDownList ID="ddlCenter" runat="server" AutoPostBack="True" OnDataBound="ddlCenter_DataBound"
                    OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" SkinID="ddlSkin" Width="154px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px" class="reportTitleIncome">
                Suncenter Name :</td>
            <td style="width: 183px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlSubcenter" runat="server" AutoPostBack="True" OnDataBound="ddlSubcenter_DataBound"
                    OnSelectedIndexChanged="ddlSubcenter_SelectedIndexChanged" SkinID="ddlSkin" Width="209px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 102px; height: 26px" class="reportTitleIncome">
                From Date :</td>
            <td style="width: 100px; height: 26px" class="Info">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="105px"></asp:TextBox><img id="Img1" alt="Calendar" height="0" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" style="width: 19px; height: 21px" width="0" /></td>
            <td style="width: 84px; height: 26px" class="reportTitleIncome">
                To Date :</td>
            <td style="width: 100px; height: 26px" class="Info">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="105px"></asp:TextBox><img id="Img2" alt="Calendar" height="0" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" style="width: 19px; height: 21px" width="0" /></td>
            <td style="width: 100px; height: 26px" class="reportTitleIncome">
                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name :" Visible="False"
                    Width="93px" SkinID="lblSkin"></asp:Label></td>
            <td style="width: 183px; height: 26px" class="Info">
                <asp:DropDownList ID="ddlEmpName" runat="server" OnDataBound="ddlEmpName_DataBound"
                    SkinID="ddlSkin" Visible="False" Width="209px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px" class="reportTitleIncome">
                Select MIS Type :</td>
            <td style="width: 100px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlMisType" runat="server"  OnSelectedIndexChanged="ddlMisType_SelectedIndexChanged"
                   SkinID="ddlSkin" Width="198px">
                   <asp:ListItem>-Select-</asp:ListItem>
                   <asp:ListItem Value="Sp_IDAutomation">IDCard MIS</asp:ListItem>
                   <asp:ListItem Value="Get_LeftPamacian_Details"> Left Pamacian MIS</asp:ListItem>
                   <asp:ListItem Value="Sp_Resigned_Details">Resigned  Pamacian MIS</asp:ListItem>
                   <asp:ListItem Value="Sp_EmpRefDetails">Pamacian Reference MIS</asp:ListItem>
                   <asp:ListItem Value="Sp_ClientVisiExportToExelAllUrl">Client Call Visit Tracker</asp:ListItem>
                   <asp:ListItem Value="SP_AssetsDescriptoinAllURL">Assets Description MIS</asp:ListItem>
                   <asp:ListItem Value="Get_AssetsMISOwnedRented_BranchWiseALLURL_123">PC Own/Rented MIS</asp:ListItem>
                   <asp:ListItem Value="SummaryMIS_ForAssetsALLURL">Assets Summery MIS</asp:ListItem>
                   <asp:ListItem Value="PA_YearlyPerformanceTracker_MISAllURL">Yearly Performance Tracker</asp:ListItem>
                   <asp:ListItem Value="Get_OjtDetailsDataALLURL">Daily Productivity Tracker</asp:ListItem>                   
                   <asp:ListItem Value="ITR_case_wise_panindia">ITR Payout Casewise Details</asp:ListItem> 
                   
                   <asp:ListItem Value="SP_ITRCountMIS_clientWise_Amount_26May2014_KanchanPCPVFinal1">PCPV FINAL ITR Payout MIS Client Wise</asp:ListItem>  
                   <asp:ListItem Value="SP_ITRCountMIS_FEWise_Amount_26May2014_KanchanPCPVFinal1">PCPV FINAL ITR Payout MIS FE Wise</asp:ListItem>  
                   <asp:ListItem Value="SP_GET_ITRCountMIS_FEWise_Amount_16Sep_PCPV">PCPV SUMMARY ITR Payout MIS</asp:ListItem>  
                   <asp:ListItem Value="casewise_details_rc_pc_PCPV">PCPV  RC/PC Casewise Details</asp:ListItem> 
                   <asp:ListItem Value="sp_idoc_rc_pc_PCPV11">PCPV SUMMARY RC/PC Payout MIS</asp:ListItem>
                   <asp:ListItem Value="Sp_RCPCFE_WiseDetails_Backup">PCPV RC/PC FE Wise Details</asp:ListItem>
                   <asp:ListItem Value="Sp_RCPCClient_WiseDetails_backup">PCPV RC/PC Client Wise Details</asp:ListItem>
                               
                    <asp:ListItem Value="SP_ITRCountMIS_ClientWise_Amount_26May2014_KanchanPFRCFinal1">PFRC FINAL ITR Payout MIS Client Wise</asp:ListItem>  
                    <asp:ListItem Value="SP_ITRCountMIS_FEWise_Amount_26May2014_KanchanPFRCFinal1">PFRC FINAL ITR Payout MIS FE Wise</asp:ListItem>  
                    <asp:ListItem Value="SP_GET_ITRCountMIS_FEWise_Amount_16Sep">PFRC SUMMARY ITR Payout MIS</asp:ListItem>                    
                    <asp:ListItem Value="casewise_details_rc_pc_pfrc">PFRC  RC/PC Casewise Details</asp:ListItem>  
                    <asp:ListItem Value="sp_idoc_rc_pc_PFRC11">PFRC SUMMARY RC/PC Payout MIS</asp:ListItem>                    
                    <asp:ListItem Value="Sp_RCPCFE_WiseDetails_PFRC_backup">PFRC RC/PC FE Wise Details</asp:ListItem>
                    <%-- <asp:ListItem Value="Sp_RCPCClient_WiseDetails_PFRC">PFRC RC/PC Client Wise Details</asp:ListItem>--%>
                    <asp:ListItem Value="Sp_RCPCClient_WiseDetails_PFRC_backup">PFRC RC/PC Client Wise Details</asp:ListItem>
                    
                                               
                    
                    <asp:ListItem Value="ISOMIS">ISO Consolidated MIS</asp:ListItem> 
                    <asp:ListItem Value="SP_CountMIS">PANINDIA-PMS Count MIS</asp:ListItem> 
                    <asp:ListItem Value="SP_CountMISDUBAI">DUBAI-PMS Count MIS</asp:ListItem> 
                    <asp:ListItem Value="Sp_FinalConsolidatedTrackerALLURL">ISO Consolidated Count MIS</asp:ListItem> 
                    <asp:ListItem Value="Sp_Hold_MIS">HOLD MIS</asp:ListItem> 
                    <asp:ListItem Value="Sp_Count_SixHr">TAT MIS CC</asp:ListItem> 
                    <asp:ListItem Value="Repository">Repository</asp:ListItem> 
                    <asp:ListItem Value="Sp_GetAssetsTransferReportSCrap_PnIndia">Assets Scrap/Sold Report</asp:ListItem>
					<asp:ListItem Value="Get_ALL_Zone_AssetsBarcodeScaningReport">All_Zone_AssetsBarcodeScaning_Report</asp:ListItem>
					<asp:ListItem Value="Sp_operationalVisiExportToExel_AllPMS">Client Meeting Tracker Consolidated Report</asp:ListItem>
                              
                    
                   
                </asp:DropDownList></td>
            <td style="width: 84px; height: 16px" class="reportTitleIncome">
            </td>
            <td style="width: 100px; height: 16px" class="Info">
            </td>
            <td style="width: 100px; height: 16px" class="reportTitleIncome">
                </td>
            <td style="width: 183px; height: 16px" class="Info">
                </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin"
                    Text="Search" Width="96px" /></td>
            <td style="width: 100px; height: 16px">
                <asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" SkinID="btnExpToExlSkin"
                    Text="Export To Excel" Width="121px" /></td>
            <td style="width: 84px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 183px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 21px" colspan="6">
                <asp:GridView ID="GV" runat="server" SkinID="gridviewNoSort" Width="766px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                </td>
            <td style="width: 100px">
                </td>
            <td style="width: 84px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 183px">
            <asp:SqlDataSource ID="SDScluster" runat="server" ProviderName="System.Data.OleDb"
                    SelectCommand="Get_ClusterMaster;1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

