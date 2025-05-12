<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_CentreUpdatedCase.aspx.cs" Inherits="CPA_PD_CPA_CentreUpdatedCase" StylesheetTheme="SkinFile" Theme="SkinFile" Title="Centre Updated Cases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>   
<script language="javascript" type="text/javascript" >
    
    function UpdateCaseDetails(CaseID)
    {
    
            window.open("CPA_CentreUpdatedCase_View.aspx?Id=" +CaseID ,  "_blank", "height=600,width=700,status=yes,resizable=no");
         
            return false;
    }
    
    
    function ValidControl()
    {
        var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
        var ddlCentreName=document.getElementById("<%=ddlCentreName.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");   
        
        var ReturnValue=true;
        var ErrorMsg="";
                
        if(ddlCentreName.selectedIndex==0)
        {
            ErrorMsg='Please select Centre.....'
            ddlCentreName.focus();
            ReturnValue=false;
        }
        if(txtToDate.value=='')
        {
            ErrorMsg='Please select To Date.....'
            txtToDate.focus();
            ReturnValue=false;
        }
        if(txtFromDate.value=='')
        {
            ErrorMsg='Please select From Date.....'
            txtFromDate.focus();
            ReturnValue=false;
        }
        
        lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {
            window.scroll(0,0); 
        }
      return ReturnValue;  
    } 
    

</script>   
    <table style="width: 100%">
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 128px">
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
            <td class="topbar" colspan="8" style="height: 28px">
                &nbsp;Centre Updated Cases View</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td style="height: 21px" colspan="3">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="9pt"></asp:Label></td>
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
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 10px">
            </td>
            <td colspan="3" style="height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
            <td style="width: 100px; height: 10px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 42px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 42px;">
                Recieved From Date
            </td>
            <td class="Info" style="width: 128px; height: 42px;">
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
            <td class="reportTitleIncome" style="width: 100px; height: 42px;">
                Recieved To Date</td>
            <td class="Info" style="width: 100px; height: 42px;">
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
            <td style="width: 100px; height: 42px;" class="reportTitleIncome">
                Cenetre Name</td>
            <td style="width: 100px; height: 42px;" class="Info">
                <asp:DropDownList ID="ddlCentreName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 42px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 128px; height: 21px">
            </td>
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
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="8">
                <asp:Button ID="btnSearch" runat="server" Font-Bold="True" OnClick="btnSearch_Click"
                    Text="Search" />
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Font-Bold="True" OnClick="btnReset_Click"
                    Text="Reset" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 128px; height: 21px">
            </td>
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
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td colspan="7" rowspan="5">
                <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" Width="100%" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LBUpdateDoc" runat="server" OnClick="LBUpdateDoc_Click" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"Case_Id"))%>' Font-Bold="False" ForeColor="Blue" >Update</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 128px">
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

