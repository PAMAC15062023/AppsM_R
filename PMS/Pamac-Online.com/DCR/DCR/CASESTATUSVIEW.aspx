<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="CASESTATUSVIEW.aspx.cs" Inherits="DCR_DCR_CASESTATUSVIEW" Title="Untitled Page" theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
function TABLE1_onclick() 
{
}
</script>
    
<table style="width:900px;">    
<tr>
<td style="width: 900px;">
    <asp:Panel ID="pnlCategory" runat="server" Width="900px">  <%--Height="132px" --%>
    <table style="width: 690px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td class="tta" colspan="4" style="width: 80%;">
                <span style="font-size: 10pt">CASE STATUS VIEW</span></td>
        </tr>
        <tr>
            <td colspan="4" style="width: 80%;">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="685px" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 142px;" class="reportTitleIncome">
                <strong>Case ID</strong></td>
            <td style="width: 200px;" class="Info">
                <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" MaxLength="15" Width="150px"></asp:TextBox></td>
            <td style="width: 132px;" class="reportTitleIncome">
                <strong>Lead ID</strong></td>
            <td style="width: 213px;" class="Info">
                <asp:TextBox ID="txtLeadID" runat="server" MaxLength="15" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 142px;">
                <strong>Cheque No.</strong></td>
            <td class="Info" style="width: 200px;">
                <asp:TextBox ID="txtChequeNo" runat="server" SkinID="txtSkin" MaxLength="150" Width="150px"></asp:TextBox></td>
            <td class="reportTitleIncome" >
                <strong>Policy No.</strong></td>
            <td class="Info" >
                <asp:TextBox ID="txtPolicyNo" runat="server" MaxLength="15" SkinID="txtSkin" Width="150px"></asp:TextBox></td>    
        </tr>
       
        <tr>
            <td class="reportTitleIncome" style="width: 142px">
                <strong>Mobile No.</strong></td>
            <td class="Info" style="width: 200px">
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="15" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td class="Info" colspan="2" >
                   <center><asp:Button ID="btnSearch" runat="server" Text="Search" Width="102px" SkinID="btnSearchSkin" OnClick="btnSearch_Click" /></center> 
            </td>
        </tr>
    <tr>
       <td colspan="4" >    <%--style="height: 107px"--%>
            <div style="overflow: scroll; width: 900px; height: 500px">
                <asp:GridView ID="gvCaseStatusView" runat="server" Width="659px" SkinID="gridviewSkin" OnRowDataBound="gvCaseStatusView_RowDataBound" 
                    AutoGenerateColumns="false" AllowSorting="true" OnSorting="gvCaseStatusView_Sorting">
                <Columns>
                     <asp:TemplateField HeaderText="Cheque Scan Image" SortExpression="Cheque_ScanImage">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                <tr>
                                    <td style="width: 100px"><img alt="Down" src="../../Images/Download.JPG" /></td>
                                    <td style="width: 100px">
                                    <asp:LinkButton ID="lnkDownloadFile" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"Cheque_ScanImage"))%>'
                                     OnClick="lnkDownloadFile_Click" ToolTip="Click to Download Attached Documents.">Cheque Image</asp:LinkButton></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Deposit Scan Image" SortExpression="Deposit_ScanImage">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 73px">
                                <tr>
                                    <td style="width: 100px"><img alt="Down" src="../../Images/Download.JPG" /></td>
                                    <td style="width: 100px">
                                    <asp:LinkButton ID="lnkDownloadFile_1" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"Deposit_ScanImage"))%>'
                                     OnClick="lnkDownloadFile_1_Click" ToolTip="Click to Download Attached Documents.">Deposit Image</asp:LinkButton></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:BoundField DataField="CASE_ID" HeaderText="Case ID" SortExpression="CASE_ID"/>
                    <asp:BoundField DataField="verification_type_id" HeaderText="Verification Type" SortExpression="verification_type_id"/>
                    <asp:BoundField DataField="CENTRE_Name" HeaderText="Center" SortExpression="CENTRE_Name"/>
                    <asp:BoundField DataField="Lead_ID" HeaderText="Lead ID" SortExpression="Lead_ID"/>
                    <asp:BoundField DataField="Policy_no" HeaderText="Policy No." SortExpression="Policy_no"/>
                    <asp:BoundField DataField="CUST_FULLNAME" HeaderText="Customer Name" SortExpression="CUST_FULLNAME"/>
                    <asp:BoundField DataField="CUST_ADD_LINE_1" HeaderText="Address" SortExpression="CUST_ADD_LINE_1"/>
                    <asp:BoundField DataField="CUST_PIN" HeaderText="PIN Code" SortExpression="CUST_PIN"/>
                    <asp:BoundField DataField="CUST_CONTACT_NO" HeaderText="Contact No." SortExpression="CUST_CONTACT_NO"/>
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"/>
                    <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark"/>

                    <asp:BoundField DataField="Initiation_Date" HeaderText="Initiation Date" SortExpression="Initiation_Date"/>
                    <asp:BoundField DataField="Upload_Date" HeaderText="Upload Date" SortExpression="Upload_Date"/>

                    <asp:BoundField DataField="SupervisorStatus" HeaderText="Supervisor Status" SortExpression="SupervisorStatus"/>
                    <asp:BoundField DataField="SupervisorSubStatus" HeaderText="Supervisor Sub-Status" SortExpression="SupervisorSubStatus"/>
                    <asp:BoundField DataField="SupervisorRemark" HeaderText="Supervisor Remark" SortExpression="SupervisorRemark"/>
                    <asp:BoundField DataField="DepositDate" HeaderText="Deposit Date" SortExpression="DepositDate"/>
                    <asp:BoundField DataField="SlipNo" HeaderText="Slip No." SortExpression="SlipNo"/>
                    <asp:BoundField DataField="Deposit_ScanImage_1" HeaderText="Deposit Scan Image" SortExpression="Deposit_ScanImage_1"/>
                    <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" SortExpression="SubmissionDate"/>
                    <asp:BoundField DataField="DispatchDate" HeaderText="Dispatch Date" SortExpression="DispatchDate"/>
                    <asp:BoundField DataField="PODNo" HeaderText="POD No." SortExpression="PODNo"/>
                    <asp:BoundField DataField="CourierName" HeaderText="Courier Name" SortExpression="CourierName"/>
                    
                    <asp:BoundField DataField="Status" HeaderText="Field Status" SortExpression="Status"/>
                    <asp:BoundField DataField="Substatus" HeaderText="Field Sub-Status" SortExpression="Substatus"/>
                    <asp:BoundField DataField="Remark" HeaderText="Verification Remark" SortExpression="Remark"/>
                    <asp:BoundField DataField="PickupDate" HeaderText="PickUp Date" SortExpression="PickupDate"/>
                    <asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" SortExpression="ChequeDate"/>
                    <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." SortExpression="ChequeNo"/>
                    <asp:BoundField DataField="ChequeAmount" HeaderText="Cheque Amount" SortExpression="ChequeAmount"/>
                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" SortExpression="BankName"/>
                    <asp:BoundField DataField="BankBranch" HeaderText="Bank Branch" SortExpression="BankBranch"/>
                    <asp:BoundField DataField="Cheque_ScanImage_1" HeaderText="Cheque Scan Image" SortExpression="Cheque_ScanImage_1"/>
                    
                    <asp:BoundField DataField="Final_Status" HeaderText="Tele Status" SortExpression="Final_Status"/>
                    <asp:BoundField DataField="Final_Substatus" HeaderText="Tele SubStatus" SortExpression="Final_Substatus"/>
                    <asp:BoundField DataField="Final_Remark" HeaderText="Tele Remark" SortExpression="Final_Remark"/>
                    
                    <asp:BoundField DataField="Case_Sent" HeaderText="Case Sent" SortExpression="Case_Sent"/>
                    <asp:BoundField DataField="Send_Datetime" HeaderText="Case Send Date" SortExpression="Send_Datetime"/>
                </Columns>
                </asp:GridView>
            </div>
        </td>
    </tr>
    </table>
    </asp:Panel>
</td>
    <asp:HiddenField ID="hidCurrentIndex" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"  />
</tr>
</table>


</asp:Content>
