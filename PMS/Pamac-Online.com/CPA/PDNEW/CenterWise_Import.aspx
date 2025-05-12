<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CenterWise_Import.aspx.cs" Inherits="CPA_PD_CenterWise_Import"  StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script src="../../popcalendar.js" language="javascript" type="text/javascript"></script>

<script  language="javascript" type="text/javascript">


    function Validate_Assignment()
    {
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var gvImportedData=document.getElementById("<%=gvImportedData.ClientID%>");
        var ddlAllocatedCentre=document.getElementById("<%=ddlAllocatedCentre.ClientID%>");
        var ddlAllocatedCluster=document.getElementById("<%=ddlAllocatedCluster.ClientID%>");
         
         var ReturnValue=true;
         var ErrorMessage='';
         var CheckCount=0;
         
     if (gvImportedData!=null)
     {
        var chkSelectAll=document.getElementById('chkSelectAll');    
        var cell;
           for (i=0;i<=gvImportedData.rows.length - 1; i++)
            {
                cell = gvImportedData.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             if (cell.childNodes[j].checked==true)
                             {
                             
                                    
                                 CheckCount=CheckCount+1;                          
                             }
                                                        
                        }
                    }
                 }
             }
         
         }    
         
         if (CheckCount==0)
         {
            ErrorMessage='Please select atleast one record!';
            ReturnValue=false;
         }
         if (ddlAllocatedCentre.selectedIndex==0)
         {
            ErrorMessage='Please Select Centre!';
            ReturnValue=false;
            gvImportedData.focus();    
         }   
         if (ddlAllocatedCluster.selectedIndex==0)
         {
            ErrorMessage='Please Select Cluster!';
            ReturnValue=false;
            gvImportedData.focus();    
         }      
         
         window.scrollTo(0,0);    
         lblMessage.innerText=ErrorMessage;
         return ReturnValue;
    }   

    function Validate_Search()
    {    
         var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
         var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
         
         var ddlCluster=document.getElementById("<%=ddlCluster.ClientID%>");
         var ddlCentre=document.getElementById("<%=ddlCentre.ClientID%>");
         
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
          if (ddlCluster.selectedIndex!==0)
         {
            if(ddlCentre.selectedIndex==0)
            {
                ErrorMessage='Please Select Centre to continue!';
                ReturnValue=false;
                ddlCentre.focus();
             }
         }
         
            window.scrollTo(0,0);    
            lblMessage.innerText=ErrorMessage;
           
           
           return ReturnValue;
            
    }

    function CheckAll()
    {    
      
     var gvImportedData=document.getElementById("<%=gvImportedData.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=gvImportedData.rows.length - 1; i++)
            {
                cell = gvImportedData.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             cell.childNodes[j].checked =chkSelectAll.checked;  
                                                        
                        }
                    }
                }

             }
        
        
    }    

</script>
    <table>
        <tr>
            <td colspan="8" style="height: 16px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="8" style="height: 28px">
                &nbsp;Centre Wise Alloatment of Cases</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
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
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                <span style="font-size: 8pt">Cluster</span></td>
            <td class="Info" colspan="2" style="font-weight: bold; font-size: 8pt">
                <asp:DropDownList ID="ddlCluster" runat="server" AutoPostBack="True"
                                  SkinID="ddlSkin" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged" Width="123px">
                </asp:DropDownList></td>
            <td class="reportTitleIncome">
                Centre</td>
            <td class="Info" style="width: 192px; color: #ff0000">
                <asp:DropDownList ID="ddlCentre" runat="server" SkinID="ddlSkin" Width="126px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="8">
                &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Font-Bold="True" />
                <asp:Button ID="btnReset" runat="server"  Text="Reset" Font-Bold="True" OnClick="btnReset_Click" /></td>
        </tr>
        <tr>
            <td colspan="8">
                <div style="width: 900px; height: 200px; overflow: scroll;">
                <asp:GridView ID="gvImportedData" runat="server" BackColor="White" BorderColor="#3366CC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    
                    
                    SkinID="gridviewSkin" Font-Size="8pt">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                  <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCaseId" runat="server" />
                                <asp:HiddenField ID="hidCaseId" runat="server"
                                    Value='<%# DataBinder.Eval(Container.DataItem, "Case_ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle ForeColor="#003399" BackColor="White" />
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
         <td class="tta" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 200px">
                    <tr>
                        <td style="height: 21px; width: 54px;">
                            Cluster
                            </td>
                        
                        <td style="height: 21px">
                            &nbsp;:&nbsp;
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlAllocatedCluster" runat="server" AutoPostBack="True" SkinID="ddlSkin" Width="156px" OnSelectedIndexChanged="ddlAllocatedCluster_SelectedIndexChanged">
                        </asp:DropDownList></td>
                        <td style="height: 21px">
                            &nbsp;</td>
                            </tr>
                </table>
            </td>
               <td class="tta" colspan="6">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 426px">
                    <tr>
                        <td style="height: 15px; width: 44px;">
                            Centre</td>
                        
                        <td style="height: 15px; width: 10px;">
                            &nbsp;:&nbsp;</td>
                        <td style="height: 15px; width: 157px;">
                        <asp:DropDownList ID="ddlAllocatedCentre" runat="server" SkinID="ddlSkin" Width="185px">
                        </asp:DropDownList>
                        </td>
                        <td align="left" style="height: 20px; width: 139px;">
                            <asp:Button ID="btnAssignment" runat="server" SkinID="btnAssingSkin" Text="Assignment" Font-Bold="True" OnClick="btnAssignment_Click" Height="29px" />
                          </td>
                        <td style="height: 15px; width: 11px;">
                            </td>
                            </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 64px">
                &nbsp; 
                <asp:HiddenField ID="hdnCaseDetails" runat="server" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 21px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 192px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
        </tr>
    </table>
   
   

    
    
</asp:Content>

