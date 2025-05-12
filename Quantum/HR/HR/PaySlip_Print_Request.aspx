<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="PaySlip_Print_Request.aspx.cs" Inherits="HR_HR_PaySlip_Print_Request" StylesheetTheme="SkinFile" Theme="SkinFile" Title="Request Salary Slip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/jscript">

 
function Validation_On_Accept_Case(ID)
    {
        debugger;
        var GridSerch=document.getElementById("<%=GridSerch.ClientID%>");
        var hdnUID=document.getElementById("<%=hdnUID.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var ReturnValue=true;
        var ErrorMessage='';
        
    
            var cell;
           for (i=0;i<=GridSerch.rows.length - 1; i++)
            {
                cell = GridSerch.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                          if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {    
                                   
                                    if((GridSerch.rows[i].cells[6].innerText!='Pending')&&(ID==1))
                                    {
                                        ErrorMessage="you cannot modify selected entry!";
                                        ReturnValue=false;
                                    }
                                   
                                     hdnUID.value=GridSerch.rows[i].cells[1].innerText;                                                                      
                                    
                                     break;
                            }
                        }
                    }
                }
            
             }
        
        
        
        if (hdnUID.value=='')
        {
            ErrorMessage="Please select atleast one record to continue!";
            ReturnValue=false;    
        
        }       
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);
        return ReturnValue;
        
    }


</script>
 <fieldset style="width: 956px; height: 494px"><legend class="FormHeading">SALARY SLIP REQUEST</legend>
    <table style="width: 948px; height: 78px;">
        <tr>
            <td colspan="5" style="width: 109px; height: 16px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="930px" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td class="TDBGColor">
                EmpCode :</td>
            <td style="width: 134px">
                &nbsp;<asp:TextBox ID="txtEmpCode" runat="server" Width="117px" Height="15px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="TDBGColor">
                Year :</td>
            <td style="width: 131px">
                <asp:TextBox ID="txtYear" runat="server" Width="116px" Height="15px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 8px">
            </td>
        </tr>
        <tr>
            <td class="TDBGColor" style="height: 10px">
                Status :</td>
            <td style="width: 134px; height: 10px">
                &nbsp;<asp:DropDownList ID="ddlStatus" runat="server" Width="123px" SkinID="ddlSkin">
                    <asp:ListItem Value="4">All</asp:ListItem>
                    <asp:ListItem Value="0">Pending</asp:ListItem>
                    <asp:ListItem Value="1">Accept</asp:ListItem>
                    <asp:ListItem Value="2">Reject</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TDBGColor" style="height: 10px">
             Month :</td>
            <td style="height: 10px">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="124px" SkinID="ddlSkin">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 10px; width: 8px;">
            </td>
        </tr>
        <tr>
            <td class="TDBGColor">
                Cluster :</td>
            <td style="width: 134px">
               <asp:DropDownList ID="ddlCluster" runat="server" Width="125px" SkinID="ddlSkin">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>West</asp:ListItem>
                    <asp:ListItem>North</asp:ListItem>
                    <asp:ListItem>South</asp:ListItem>
                    <asp:ListItem>East</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td style="width: 131px">
            </td>
            <td style="height: 22px; width: 8px;">
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Width="91px" OnClick="btnSearch_Click" Font-Bold="True" Height="29px" />&nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="77px" OnClick="btnClear_Click" Font-Bold="True" Height="29px" /></td>
        </tr>
        <tr>
            <td colspan="5" style="width: 109px; height: 257px;">
                &nbsp;<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="925px" Height="227px">
                <asp:GridView ID="GridSerch" runat="server" Width="1px" AutoGenerateColumns="False"  OnRowDataBound="GridSerch_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" Height="142px" SkinID="gridviewNoSort" >
                    <Columns>
                      <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                           <asp:CheckBox ID="chkSelect" runat="server" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"RequestID"))%>'/>                        
                        </ItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:BoundField DataField="Employee Name" HeaderText="EmployeeName" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Employee Code" HeaderText="EmployeeCode" >
                      
                    </asp:BoundField>
                    <asp:BoundField DataField="Month of PaySlip" HeaderText="MonthofPaySlip" >
                     
                    </asp:BoundField>
                    <asp:BoundField DataField="Salary Slip Printed" HeaderText="Salary Slip Printed" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Last Print Date" HeaderText="LastPrintDate" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Remark" HeaderText="Remark" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="Request Date" HeaderText="RequestDate" >
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="AuthorizeBy" HeaderText="AuthorizeBy" >
                       
                    </asp:BoundField>
                    <asp:BoundField DataField ="Authorize Date" HeaderText ="AuthorizeDate" >
                       
                    </asp:BoundField>                    
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 26px">
                <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClick="btnAccept_Click" Font-Bold="True" Width="70px" Height="32px" />
                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" Font-Bold="True" Width="67px" Height="32px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Font-Bold="True" Width="71px" Height="32px" />
            </td>
        </tr>
        <tr>
            <td colspan="5" style="width: 109px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td colspan="5" style="width: 109px; height: 58px;">
                <asp:HiddenField ID="hdnUID" runat="server" Value="0" />
            </td>
        </tr>
    </table>
    </fieldset>
</asp:Content>

