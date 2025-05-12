<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_PendingReport.aspx.cs" Inherits="CPA_PD_CPA_PendingReport" Title="Pending Report" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>   
<script language="javascript" type="text/javascript" >

    function ValidControl()
    {
        var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
        
        var ErrorMsg="";
        var ReturnValue=true;
        
        if(txtToDate.value=='')
        {
           ErrorMsg='Please select To Date......'
           txtToDate.focus(); 
           ReturnValue=false;
        }
        if(txtFromDate.value=='')
        {
           ErrorMsg='Please select From Date......'
           txtFromDate.focus(); 
           ReturnValue=false;
        }
        lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {
            window.scroll(0,0) 
        }
        return ReturnValue;
    }

</script>  
    <table>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
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
        <tr>
            <td colspan="10" style="height: 68px">
                <table border="0" cellpadding="0" cellspacing="0" width="99%">
                    <tr>
                        <td class="topbar" colspan="12" style="height: 35px">
                            &nbsp;Pending Report</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                From Date <span style="color: #ff3300">*</span></td>
            <td class="Info" style="width: 128px; height: 15px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 111px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            &nbsp;<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                &nbsp;To Date <span style="color: #ff3300">*</span></td>
            <td class="Info" style="width: 100px; height: 15px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 111px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            &nbsp;<img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
                <asp:Button ID="btnSearch" runat="server" Height="26px" 
                    SkinID="btnSearchSkin" Text="Search" Width="84px" OnClick="btnSearch_Click" /></td>
            <td style="width: 100px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 21px">
            </td>
            <td colspan="4" style="height: 21px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
    </table>
            
           <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width: 100%">
<tr><td style="width: 100%; height: 125px"><asp:GridView ID="GridView1" runat="server"  AllowSorting="false" AllowPaging="false" AutoGenerateColumns="true" SkinID="gridviewNoSort" Width="100%"  >
                  </asp:GridView>      
</td>
</tr>
</table>

           
          
    <table>
        <td style="width: 100px; height: 28px">
                <asp:Button ID="btnExportExcel" runat="server" Height="26px" OnClick="btnExportExcel_Click"
                    SkinID="btnExportSkin" Text="Export To Excel" Width="119px" Visible="False" /></td>
        <td style="width: 100px; height: 28px">
        </td>
        <td style="width: 100px; height: 28px">
        </td>
    </table>
</asp:Content>

