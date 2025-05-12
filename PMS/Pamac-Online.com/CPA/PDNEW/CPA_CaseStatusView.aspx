<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_CaseStatusView.aspx.cs" Inherits="CPA_PD_CPA_CaseStatusView" Title="Case Status View" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script> 
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}

    function validationControl()
    {
        var txtCaseReceivedDate=document.getElementById("<%=txtCaseReceivedDate.ClientID%>");
        var txtTodate=document.getElementById("<%=txtTodate.ClientID%>"); 
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>") 
        
        var ReturnValue=true;
        var ErrorMsg="";
        
         if(txtTodate.value =='')
        {
            ErrorMsg='Please Enter ToDate......!!!!!!';
            ReturnValue=false;
            txtTodate.focus();
        }
        
        if(txtCaseReceivedDate.value =='')
        {
            ErrorMsg='Please Enter FromDate......!!!!!!';
            ReturnValue=false;
            txtCaseReceivedDate.focus();
        }
        
        
        lblMessage.innerText=ErrorMsg;
                    if(ErrorMsg!='')
                    {
                        window.scrollTo(0,0);
                    }
                           return ReturnValue;           
    
    }
</script>
    <table style="width: 100%" class="bx">
        <tr>
            <td style="width: 214625px">
            </td>
            <td style="width: 133px">
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
            <td style="height: 21px;" colspan="9">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="topbar" colspan="12" style="height: 35px">
                            &nbsp;Case Status View</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 11px">
            </td>
            <td colspan="5" style="height: 11px">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 11px;">
            </td>
            <td style="width: 133px; height: 11px;" class="reportTitleIncome">
                From Date</td>
            <td style="width: 100px; height: 11px;" class="Info">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtCaseReceivedDate" runat="server" SkinID="txtSkin" TabIndex="2"
                                Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCaseReceivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 11px;" class="reportTitleIncome">
                To Date</td>
            <td style="width: 100px; height: 11px;" class="Info">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 90px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtTodate" runat="server" SkinID="txtSkin" TabIndex="2" Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTodate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 11px;">
            </td>
            <td style="width: 100px; height: 11px;">
                </td>
            <td style="width: 100px; height: 11px;">
                </td>
            <td style="width: 100px; height: 11px">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 11px">
            </td>
            <td class="reportTitleIncome" style="width: 133px; height: 11px">
                Case ID</td>
            <td class="Info" style="width: 100px; height: 11px">
                <asp:TextBox ID="txtCase_ID" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 11px">
                Ref No</td>
            <td class="Info" style="width: 100px; height: 11px">
                <asp:TextBox ID="txtRef_No" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 11px">
            </td>
            <td class="reportTitleIncome" style="width: 133px; height: 11px">
                <span style="font-size: 8pt">Company Name</span></td>
            <td class="Info" style="width: 100px; height: 11px">
                <asp:TextBox ID="txtApplicant_Name" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 11px">
            </td>
            <td class="Info" style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
            <td style="width: 100px; height: 11px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" colspan="9" style="height: 11px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin"
                    Text="Search" Height="26px" Width="79px" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btnCancelSkin"
                    Text="Cancel" Height="26px" Width="76px" /></td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 21px;">
            </td>
            <td style="width: 100%" colspan="8" rowspan="6">
                &nbsp;<asp:GridView ID="gvCaseStatusView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" CssClass="mGrid" ForeColor="Black" OnPageIndexChanging="gvCaseStatusView_PageIndexChanging"
                    OnRowCommand="gvCaseStatusView_RowCommand" OnRowCreated="gvCaseStatusView_RowCreated"
                    OnRowDataBound="gvCaseStatusView_RowDataBound" SkinID="gridviewSkin" Width="99%">
                    <Columns>
                        <asp:BoundField DataField="CASE_ID" HeaderText="Case ID" />
                        <asp:BoundField DataField="REF_NO" HeaderText="Ref No" />
                        <asp:BoundField DataField="Applicant_Name" HeaderText="Company Name" />
                        <asp:BoundField DataField="VERIFICATION_CODE" HeaderText="Verification Type" />
                        <asp:BoundField DataField="Case_Status" HeaderText="Case Status" />
                        <asp:TemplateField HeaderText="Select Verification Type">
                            <ItemTemplate>
                                <asp:Label ID="lblOSVV" runat="server" Text="OSVV" Visible="false"></asp:Label>
                                <asp:Label ID="lblSlashOSVV" runat="server"  ForeColor="Blue" Visible="False" Width="9px">/</asp:Label>
                                
                                <asp:Label ID="lblOSTV" runat="server" Text="OSTV" Visible="false"></asp:Label>
                                <asp:Label ID="lblSlashOSTV" runat="server" ForeColor="Blue" Visible="False" Width="9px">/</asp:Label>
                                                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px; height: 1px;">
            </td>
        </tr>
        <tr>
            <td style="width: 214625px">
            </td>
            <td colspan="3">
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

