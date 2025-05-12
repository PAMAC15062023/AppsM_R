<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="PickUp_Reconciliation.aspx.cs" Inherits="DCR_DCR_PickUp_Reconciliation" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
    var txtChequeAmount =  document.getElementById("<%=txtChequeAmount.ClientID%>");

    if(isNaN(txtChequeAmount.value)
    {
        ErrorMsg = "Please Enter Cheque Amount.";
        ReturnValue=false;
        txtChequeAmount.focus();
    }
    if((isNaN(txtChequeNo.value) || (txtChequeNo.value.length !=6))
    {
        ErrorMsg = "Please Enter Valid 6 digit Cheque Number.";
        ReturnValue=false;
        txtChequeNo.focus();
    }
    
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}
</script>

    <asp:Panel ID="pnlMsg" runat="server"  Width="1000px"> 
        <table style="width: 1000px; ">
        <tr>
            <td class="tta" colspan="4" style="width: 1000px; height: 4px;">
                <span style="font-size: 10pt">PICK-UP RECONCILIATION</span></td>
        </tr>
        <tr>
            <td colspan="4" style="width: 1000px; height: 1px;">
                <asp:Label runat="server" ID="lblMsg"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="900px"></asp:Label></td>
        </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlCluster" runat="server" Width="700px">
        <table style="width: 1000px; ">
            <tr>
                <td style="width: 120px;" class="reportTitleIncome" >
                    <strong>Cluster</strong></td>
                <td style="width: 120px" class="Info">
                    <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                        SkinID="ddlSkin" ValidationGroup="grpSearch" Width="120px">
                    </asp:DropDownList></td>
                <td style="width: 120px;" class="reportTitleIncome" >
                    <strong>Centre</strong></td>
                <td style="width: 120px" class="Info">
                    <asp:DropDownList ID="ddlcenter" runat="server" SkinID="ddlSkin" Width="120px" AutoPostBack="True"  
                        OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>        
        </table>    
    </asp:Panel>
    
    
    <asp:Panel id="pnlGrid" runat="server" Width="1000px"> 
       <table style="width: 1000px;">
            <tr>
                <td style="height: 29px">
                    <div style="overflow: scroll; width: 1000px; height: 250px">
                    <asp:GridView ID="grdGrid" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False" Height="100px" AllowSorting="true"
                        OnRowEditing="grdGrid_RowEditing" OnSorting="grdGrid_Sorting" OnRowCommand="grdGrid_RowCommand">    
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_ID")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                           
                           
                           <asp:BoundField DataField="Case_ID" HeaderText="Case ID" SortExpression="Case_ID" />
                           <asp:BoundField DataField="Verification_Type_ID" HeaderText="Verification Type" SortExpression="Verification_Type_ID" />
                           <asp:BoundField DataField="Centre_Name" HeaderText="Centre" SortExpression="Centre_Name" />
                           <asp:BoundField DataField="Cust_Fullname" HeaderText="Name" SortExpression="Cust_Fullname" />
                           <asp:BoundField DataField="Cust_Add_Line_1" HeaderText="Address" SortExpression="Cust_Add_Line_1" />
                           <asp:BoundField DataField="Cust_Contact_No" HeaderText="Contact No." SortExpression="Cust_Contact_No" />
                           <asp:BoundField DataField="INITIATION_DATE" HeaderText="Initiation Date" SortExpression="INITIATION_DATE"/>
                           <asp:BoundField DataField="UPLOAD_DATE" HeaderText="Upload Date"  SortExpression="UPLOAD_DATE"/>
                           <asp:BoundField DataField="PickUpDate" HeaderText="PickUp Date" SortExpression="PickUpDate" />
                           <asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" SortExpression="ChequeDate" />
                           <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." SortExpression="ChequeNo" />
                           <asp:BoundField DataField="ChequeAmount" HeaderText="Cheque Amount" SortExpression="ChequeAmount" />
                           <asp:BoundField DataField="BankName" HeaderText="Bank Name" SortExpression="BankName" />
                           <asp:BoundField DataField="BankBranch" HeaderText="Bank Branch" SortExpression="BankBranch" />
                           <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                           <asp:BoundField DataField="Cluster_ID" HeaderText="Cluster ID" SortExpression="Cluster_ID" />
                           <asp:BoundField DataField="Centre_ID" HeaderText="Centre ID" SortExpression="Centre_ID" />
                           <asp:BoundField DataField="Cheque_ScanImage" HeaderText="Cheque ScanImage" SortExpression="Cheque_ScanImage" />

                        </Columns>
                    </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel> 
    
    
            
    <asp:Panel ID="pnlData" runat="server"  Width="1000px"> 
        <table style="width: 1000px; ">
        <tr>
            <td style="width: 97px;" class="reportTitleIncome" >
                <strong>Case ID</strong></td>
            <td style="width: 190px;" class="Info">
                <asp:TextBox ID="txtCaseID" runat="server" ReadOnly="true" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td class="reportTitleIncome" colspan="2" rowspan="14">
                <asp:Image ID="ImgCheque" runat="server" Width="680px" Height="580px" />  
            </td>
        </tr>
        <tr>
            <td style="width: 97px" class="reportTitleIncome" >
                <strong>Verification Type</strong></td>
            <td style="width: 190px" class="Info">
                <asp:TextBox ID="txtVerificationType" runat="server" ReadOnly="true" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 97px;" class="reportTitleIncome" >
                <strong>Centre</strong></td>
            <td style="width: 190px;" class="Info">
                    <asp:TextBox ID="txtCentre" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="true" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 97px" class="reportTitleIncome" >
                <strong>Name</strong></td>
            <td style="width: 190px" class="Info">
                    <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="true" ></asp:TextBox></td>
        </tr>
            <tr>
                <td style="width: 97px" class="reportTitleIncome" >
                    <strong>Address</strong></td>
                <td style="width: 190px" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="150px" ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 97px" class="reportTitleIncome" >
                    <strong>Contact No.</strong></td>
                <td style="width: 190px" class="Info">
                    <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 97px" class="reportTitleIncome" >
                    <strong>Pick-Up Date</strong></td>
                <td style="width: 190px" class="Info">
                <asp:TextBox ID="txtPickUpDate" runat="server" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"
                    Width="70px" ValidationGroup="grpSend"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickUpDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            </tr>
            <tr>
                <td style="width: 97px" class="reportTitleIncome" >
                    <strong>Cheque Date</strong></td>
                <td style="width: 190px" class="Info">
                <asp:TextBox ID="txtChequeDate" runat="server" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"
                    Width="70px" ValidationGroup="grpSend"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 97px">
                    <strong>Cheque No.</strong></td>
                <td class="Info" style="width: 190px">
                <asp:TextBox ID="txtChequeNo" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 97px">
                    <strong>Cheque Amount</strong></td>
                <td class="Info" style="width: 190px">
                <asp:TextBox ID="txtChequeAmount" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 97px">
                    <strong>Bank Name</strong></td>
                <td class="Info" style="width: 190px">
                    <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 97px">
                    <strong>Bank Branch</strong></td>
                <td class="Info" style="width: 190px">
                    <asp:TextBox ID="txtBankBranch" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 97px">
                    <strong>Scan Image</strong></td>
                <td class="Info" style="width: 190px">
                    <asp:FileUpload id="Cheque_ScanImage" runat="server" Width="170px" SkinID="flup"></asp:FileUpload></td>
            </tr>
            <tr>
                <td class="Info" colspan="2" rowspan="1">
                    <asp:Button ID="btnSave" runat="server" SkinID="btnSaveSkin" Text="Save" Width="68px" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnBack" runat="server" SkinID="btnbackskin" Text="Back" Width="68px" OnClick="btnBack_Click" />
                    <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
    
            <asp:RegularExpressionValidator ID="REVPickUpDate" runat="server" ControlToValidate="txtPickUpDate" Display="None"
                ErrorMessage="Please enter valid date format for PickUp Date" SetFocusOnError="True"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpSend"></asp:RegularExpressionValidator>

            <asp:RegularExpressionValidator ID="REVChequeDate" runat="server" ControlToValidate="txtChequeDate" Display="None"
                ErrorMessage="Please enter valid date format for Cheque Date" SetFocusOnError="True"
                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpSend"></asp:RegularExpressionValidator>
                    
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="grpSend" />       
                
                
            <asp:HiddenField ID="hdnCaseID" runat="server" />                 
            <asp:HiddenField ID="hdnvery" runat="server" />                 
            <asp:HiddenField ID="HdnCluster" runat="server" />                 
            <asp:HiddenField ID="hdncentre" runat="server" />                 
            <asp:HiddenField ID="hdnID" runat="server" />

</asp:Content>

