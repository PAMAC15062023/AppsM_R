<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_TeleAssignment.aspx.cs" StylesheetTheme="SkinFile" Inherits="CPA_PD_CPA_TeleAssignment" Title="CPA Tele Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script src="../../popcalendar.js" language="javascript" type="text/javascript"></script>

<script  language="javascript" type="text/javascript">


    function Validate_Assignment()
    {
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var grvTransactionInfo=document.getElementById("<%=gvFEAssignmentCases.ClientID%>");
        var ddlFE=document.getElementById("<%=ddlFE.ClientID%>");
         
         var ReturnValue=true;
         var ErrorMessage='';
         var CheckCount=0;
         
     if (grvTransactionInfo!=null)
     {
        var chkSelectAll=document.getElementById('chkSelectAll');    
        var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[0];
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
         if (ddlFE.selectedIndex==0)
         {
            ErrorMessage='Please select Field Executive!';
            ReturnValue=false;
            ddlFE.focus();    
         }         
         
         window.scrollTo(0,0);    
         lblMessage.innerText=ErrorMessage;
         return ReturnValue;
    }   

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

    function CheckAll()
    {    
      
     var grvTransactionInfo=document.getElementById("<%=gvFEAssignmentCases.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[0];
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
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="8" style="height: 28px">
                &nbsp;Tele Caller Name Case&nbsp; Assignment Tray</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Recieved From Date
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
            <td class="Info" style="width: 100px">
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
                Applicant Name</td>
            <td class="Info" colspan="2" style="font-weight: bold; font-size: 8pt">
                &nbsp;<asp:TextBox ID="txtCustName" runat="server" MaxLength="200" SkinID="txtSkin" Width="191px"></asp:TextBox></td>
            <td class="reportTitleIncome">
                &nbsp;Tele Caller Name</td>
            <td class="Info" style="width: 100px; color: #ff0000">
                &nbsp;<asp:DropDownList ID="ddlFENameList" runat="server"  SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                <span style="font-size: 8pt">Verification Type</span></td>
            <td class="Info" colspan="2" style="font-weight: bold; font-size: 8pt; height: 30px;">
                <asp:DropDownList ID="ddlType" runat="server"
                    SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="height: 30px">
                </td>
            <td class="Info" style="width: 100px; color: #ff0000; height: 30px;">
                </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="8">
                &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Font-Bold="True" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" Font-Bold="True" OnClick="btnReset_Click" /></td>
        </tr>
        <tr>
            <td colspan="8">
                <div style="width: 900px; height: 200px; overflow: scroll;">
                <asp:GridView ID="gvFEAssignmentCases" runat="server" BackColor="White" BorderColor="#3366CC"
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
            <td class="tta" colspan="8">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 338px">
                    <tr>
                        <td style="height: 20px">
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Tele Caller Name" Width="131px"></asp:Label></td>
                        <td style="height: 20px">
                            <asp:DropDownList ID="ddlFE" runat="server" SkinID="ddlSkin"  
                                 >
                            </asp:DropDownList></td>
                        <td align="right" style="height: 20px">
                            <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" SkinID="btnAssingSkin"
                                ValidationGroup="vgrpFE" Text="Assignment" Font-Bold="True" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:HiddenField ID="hdnCaseDetails" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
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
    </table>
</asp:Content>

