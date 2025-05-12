<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Admin_FeedBack_Report" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
   
    <script language="JAVASCRIPT" type="text/javascript"> 

    function Validate_Search()
    {  
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate= document.getElementById("<%=txtToDate.ClientID%>");     
        var ddlcentre = document.getElementById("<%=ddlcentre.ClientID%>");
        var ddlsubcentre= document.getElementById("<%=ddlsubcentre.ClientID%>");
        
       var lblmsg=document.getElementById("<%=lblmsg.ClientID%>");       
       var ErrorMessage='';
       var ReturnValue=true;
       
       
                
         if (txtToDate.value =='')       
        { 
             ErrorMessage='Please Enter the To Date!';
             ReturnValue=false; 
             txtToDate.focus();
        }  
                
            if (txtFromDate.value ==0)       
        { 
             ErrorMessage='Please Enter The From Date!';
             ReturnValue=false; 
             txtFromDate.focus();
        }   
            
     
//               if (ddlsubcentre.value ==0)       
//        { 
//             ErrorMessage='Please Select The SubCentre!';
//             ReturnValue=false; 
//             ddlsubcentre.focus();
//        }   
        
               if (ddlcentre.value =='0')       
        { 
             ErrorMessage='Please Select The Centre!';
             ReturnValue=false; 
             ddlcentre.focus();
        }   
        
              window.scrollTo(0,0);    
         lblmsg.innerText=ErrorMessage;
         return ReturnValue;
         
    }  
    </script>
        
            
        
   
      <script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
   
    &nbsp;<asp:Panel ID="Panel1" runat="server">
        <table style="width: 748px">
            <tr>
                <td class="tta" colspan="6">
                    Feedback Report</td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr style="color: #000000; font-family: Tahoma">
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    Centre Name</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    Subcentre Name</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:DropDownList ID="ddlsubcentre" runat="server" SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 20px" class="reportTitleIncome">
                    &nbsp; &nbsp;&nbsp;&nbsp; Report:</td>
                <td style="width: 100px; height: 20px">
                    &nbsp;<asp:DropDownList ID="ddlReport" runat="server" SkinID="ddlSkin" Width="199px" >
                        <asp:ListItem Value="Emp_Feedback_Report1">Employee Survey Tracker</asp:ListItem>
                            <asp:ListItem Value="Emp_Feedback_Report_AllCluster">All Cluster EST</asp:ListItem>
                        <asp:ListItem Value="SP_AVG_MIS">AVG MIS</asp:ListItem>
                        <asp:ListItem Value="So_Survey_MIS">Employee Survey MIS</asp:ListItem>
                         <asp:ListItem Value="So_Survey_MIS_Test">Employee Survey MIS2</asp:ListItem>
                        <asp:ListItem Value="SpFeedback_View">SSU Feedback</asp:ListItem>
                        <asp:ListItem Value="So_Survey_MIS_BranchWise">Employee Survey MIS BRANCH WISE</asp:ListItem>
                         <asp:ListItem Value="CSAT_Feedback_Report1">CSAT mis</asp:ListItem>
                        
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    From Date</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                        Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                <td class="reportTitleIncome" style="width: 100px; height: 20px">
                    To Date</td>
                <td class="Info" style="width: 100px; height: 20px">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                        Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.gif" /></td>
                <td style="width: 100px; height: 20px" class="reportTitleIncome">
                    &nbsp; &nbsp;&nbsp;&nbsp;
                </td>
                <td style="width: 100px; height: 20px">
                    <asp:HiddenField ID="HdnUID" runat="server" />
                    <asp:HiddenField ID="HDNUPDATE" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 21px">
                    <asp:Button ID="Btnsearch" runat="server" Height="23px" OnClick="Button1_Click" SkinID="btn"
                        Text="Search" Width="121px" />&nbsp;<asp:Button ID="BtnExport" runat="server" Height="23px"
                            OnClick="BtnExport_Click" SkinID="btn" Text="Export To Excel" Width="121px" />
                    <asp:Button ID="BtnReset" runat="server" Height="23px" OnClick="BtnReset_Click" SkinID="btn"
                        Text="Reset" Width="121px" /></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 178px">
                    <asp:Panel ID="pnlGrd" runat="server" Height="400px" ScrollBars="Both" Width="900px">
                        <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort"
                            Width="650px">
                            <HeaderStyle Height="30px" />
                  
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

