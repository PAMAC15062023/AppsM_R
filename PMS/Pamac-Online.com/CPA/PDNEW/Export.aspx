<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" EnableEventValidation ="false" CodeFile="Export.aspx.cs" Inherits="CPA_PD_Export" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script  language="javascript" type="text/javascript">


    function Validate_Search()
    {    
         var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
         var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
                  
         var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
    
         var ReturnValue=true;
         var ErrorMessage='';
         
         if (txtToDate.value=='')
         {
            ErrorMessage='Please enter to To Date to continue!';
            ReturnValue=false;
            txtToDate.focus();
         }
         if (txtFromDate.value=='')
         {
            ErrorMessage='Please enter to From Date to continue!';
            ReturnValue=false;
            txtFromDate.focus();
         }
     
            window.scrollTo(0,0);    
            lblMessage.innerText=ErrorMessage;
           
           
           return ReturnValue;
            
    }

   

</script>
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>   
  <table>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="8" style="height: 28px">
                &nbsp;Centre Wise Alloatment of Cases</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome" style="width: 110px">
                &nbsp;Recieved From Date
            </td>
            <td class="Info" colspan="2">
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
            <td style="width: 100px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Recieved To Date</td>
            <td class="Info" style="width: 192px">
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
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="8">
                &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Font-Bold="True" />
                <asp:Button ID="btnReset" runat="server"  Text="Reset" Font-Bold="True" OnClick="btnReset_Click" />
                <asp:Button ID="btnExport" runat="server"  Text="Export" Font-Bold="True" OnClick="btnExport_Click" Visible="False" /></td>
        </tr>
    </table>
      
    
        <table border="0" id="tblExport" cellpadding="0" cellspacing="0" runat="server" width="100%">
            <tr><td>
                &nbsp;&nbsp;&nbsp;
                <asp:GridView ID="gvImportedData" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="8pt" SkinID="gridviewSkin">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
             </asp:GridView>
            </td>
            </tr>
        </table>
      
    
   
</asp:Content>

