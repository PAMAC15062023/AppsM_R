<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_OJT_InductionTrinForm.aspx.cs" Inherits="HR_HR_HR_OJT_InductionTrinForm" Title="Induction Training Confirmation Format" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    
    function Pro_SelectRow(rowno,id)
    {
        rowno=(parseInt(rowno)+1);
        var hdnUID = document.getElementById("<%=hdnUID.ClientID%>");
        var ddlMinProduct = document.getElementById("<%=ddlMinProduct.ClientID%>");
        var ddlInOut = document.getElementById("<%=ddlInOut.ClientID%>");
        var ddlBehaviour = document.getElementById("<%=ddlBehaviour.ClientID%>");
        var txtCaseAssign = document.getElementById("<%=txtCaseAssign.ClientID%>");
        var txtCaseComplete = document.getElementById("<%=txtCaseComplete.ClientID%>");
        var txtErrorCount = document.getElementById("<%=txtErrorCount.ClientID%>");
        var ddlTraining = document.getElementById("<%=ddlTraining.ClientID%>");
        var GVProdTrack = document.getElementById("<%=GVProdTrack.ClientID%>");        
              
                hdnUID.value = GVProdTrack.rows[rowno].cells[0].innerText;              
                ddlMinProduct.value = GVProdTrack.rows[rowno].cells[3].innerText;              
                ddlInOut.value = GVProdTrack.rows[rowno].cells[4].innerText;
                ddlBehaviour.value=GVProdTrack.rows[rowno].cells[5].innerText;                       
                txtCaseAssign.value=GVProdTrack.rows[rowno].cells[6].innerText;                       
                txtCaseComplete.value=GVProdTrack.rows[rowno].cells[7].innerText;     
                txtErrorCount.value=GVProdTrack.rows[rowno].cells[8].innerText;     
                ddlTraining.value=GVProdTrack.rows[rowno].cells[9].innerText;     
               
                var i=0;
                    for(i=0;i<=GVProdTrack.rows.length-1;i++)       
                    {
                        if (i!=0)
                        {
                            if (hdnUID.value==GVProdTrack.rows[i].cells[0].innerText)
                            {
                             GVProdTrack.rows[i].style.backgroundColor = "DarkGray";
                            }
                            else 
                            {
                               GVProdTrack.rows[i].style.backgroundColor = "white";          
                            }
                        }
                    }      
    }
</script>
    <table>
        <tr>
            <td class="tta" colspan="8">
                <span style="font-size: 10pt">Induction Training Confirmation Format</span></td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td colspan="3" style="height: 15px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Crimson" SkinID="lblError"></asp:Label></td>
            <td colspan="2" style="height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                Employee Code</td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                Name</td>
            <td style="height: 15px" colspan="2" class="Info">
                <asp:TextBox ID="txtName" runat="server" Width="233px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Designation</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtDesig" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                DOJ</td>
            <td class="Info" colspan="2" style="height: 30px">
                <asp:TextBox ID="txtDoj" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 72px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                MOU Issue Date</td>
            <td class="Info" style="width: 100px; height: 15px">
                <asp:TextBox ID="txtMouDate" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 15px">
                Date Of Training</td>
            <td class="Info" colspan="2" style="height: 15px">
                <asp:TextBox ID="txtDateTrain" runat="server" SkinID="txtSkin"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateTrain.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;" class="reportTitleIncome">
                Induction
                Trainer Name</td>
            <td class="Info" style="height: 23px">
                <asp:TextBox ID="txtInductionTrainer" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 23px;" class="reportTitleIncome">
                QMS Trainer Name</td>
            <td style="width: 100px; height: 23px;" class="Info">
                <asp:TextBox ID="txtQmsTrainer" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                Induction Training Given</td>
            <td style="width: 100px; height: 15px" class="Info">
            <asp:DropDownList ID="ddlInducTrain" runat="server" SkinID="ddlSkin">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Not applicable</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
            Remark:
            </td>
            <td style="width: 100px; height: 15px" class="Info">
             <asp:TextBox  ID="txtremark" SkinID="txtSkin" runat="server"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 72px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px;">
            </td>
            <td style="height: 15px;" colspan="6">
                <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" /></td>
            <td style="width: 72px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfCluster" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfSubcentre" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdfCentre" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnEmpId" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 72px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="tta" colspan="7">
                Daily Updation Performance / Productivity Tracker</td>
        </tr>
        <tr>
            <td style="width: 6px; height: 15px;">
            </td>
            <td colspan="2" style="height: 15px">
                <asp:Label ID="lblMessage1" runat="server" ForeColor="Red" SkinID="lblError"></asp:Label></td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 72px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Minimum Productivity</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlMinProduct" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>  
                    <asp:ListItem>30</asp:ListItem>  
                    <asp:ListItem>35</asp:ListItem>  
                    <asp:ListItem>50</asp:ListItem>  
                    <asp:ListItem>60</asp:ListItem>  
                    <asp:ListItem>85</asp:ListItem>        
                    <asp:ListItem>45-50</asp:ListItem>                                                        
                    <asp:ListItem>15-18 Visits</asp:ListItem>  
                    <asp:ListItem>85-100 Tele</asp:ListItem>  
                    <asp:ListItem>85-100 Cases</asp:ListItem>  
                    <asp:ListItem>85-100 Reports</asp:ListItem>                              
                    <asp:ListItem>400 Dual Entry</asp:ListItem>                   
                    <asp:ListItem>Not Applicable</asp:ListItem>  
                    <asp:ListItem>5-6 Dox Collection</asp:ListItem>  
                    <asp:ListItem>80-90 calls per day</asp:ListItem>  
                    <asp:ListItem>Depends on the Area 10 DropBox per person</asp:ListItem>                                                  
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px">
                In / Out Time Correct&nbsp;</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlInOut" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px">
                Behaviour for the Day</td>
            <td class="Info" style="width: 100px">
                <asp:DropDownList ID="ddlBehaviour" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                     <asp:ListItem>Introvert</asp:ListItem>
                    <asp:ListItem>Extrovert</asp:ListItem>                                        
                    <asp:ListItem>Rude</asp:ListItem>                                        
                    <asp:ListItem>Team player</asp:ListItem>  
                </asp:DropDownList></td>
            <td style="width: 72px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Cases Assigned</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtCaseAssign" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px">
                Cases Completed</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtCaseComplete" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px">
                Error Count</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtErrorCount" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 72px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 14px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 14px">
                Training</td>
            <td class="Info" style="width: 100px; height: 14px">
                <asp:DropDownList ID="ddlTraining" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Pre Training</asp:ListItem>
                    <asp:ListItem>Post Training</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 14px">
            </td>
            <td style="width: 100px; height: 14px">
            </td>
            <td style="width: 100px; height: 14px">
            </td>
            <td style="width: 100px; height: 14px">
            </td>
            <td style="width: 72px; height: 14px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td colspan="3">
                &nbsp;
                <asp:Button ID="btnAdd" runat="server" Font-Bold="True" OnClick="btnAdd_Click" Text="Add" />
                &nbsp;
                <asp:Button ID="btnView" runat="server" Font-Bold="True" OnClick="btnView_Click"
                    Text="View" />&nbsp;
                <asp:Button ID="btnCan1" runat="server" Font-Bold="True" OnClick="btnCan1_Click"
                    Text="Cancel" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 72px">
            </td>
        </tr>
        <tr>
            <td style="width: 6px; height: 177px;">
            </td>
            <td colspan="5" style="height: 177px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="96%" Height="118px">
                    <asp:GridView ID="GVProdTrack" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GVProdTrack_RowDataBound" Height="60px">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td colspan="2">
                <asp:HiddenField ID="hdnUID" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 72px">
            </td>
        </tr>
    </table>
</asp:Content>

