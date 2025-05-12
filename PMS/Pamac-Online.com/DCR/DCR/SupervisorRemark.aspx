<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="SupervisorRemark.aspx.cs" Inherits="DCR_DCR_SupervisorRemark" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">

function WindowOpen1()
{
 // Variable Declaration With value
 var txtName = document.getElementById("<%=txtName.ClientID%>").value;
 var txtSlipNo = document.getElementById("<%=txtSlipNo.ClientID%>").value;

 //New Window Parameter Declaration
 var helpwinparam='width=800px,height=300px,toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,dependent,left=200,top=150';
 
 //Redirect to Dedup Design Page
 var strURL = "DedupDepositScanImage.aspx?Name="+txtName+"&Slip_No="+txtSlipNo+"";

 // Pop up window
 var popup = window.open(strURL,'',helpwinparam);
}


function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var ddlSupervisorStatus = document.getElementById("<%=ddlSupervisorStatus.ClientID%>");
    var txtDepositDate = document.getElementById("<%=txtDepositDate.ClientID%>");
    var txtSlipNo = document.getElementById("<%=txtSlipNo.ClientID%>");
    var txtSubmissionDate = document.getElementById("<%=txtSubmissionDate.ClientID%>");
    var txtDispatchdate = document.getElementById("<%=txtDispatchdate.ClientID%>");
    var txtPODNo = document.getElementById("<%=txtPODNo.ClientID%>");
    var txtCourierName = document.getElementById("<%=txtCourierName.ClientID%>");
    var ddlPendingDS = document.getElementById("<%=ddlPendingDS.ClientID%>");
    var txtSupervisorRemark = document.getElementById("<%=txtSupervisorRemark.ClientID%>");


    if(ddlSupervisorStatus.selectedIndex == 5)
    {
        if(txtSupervisorRemark.value == '')
        {
            ErrorMsg="Please Enter Supervisor Remark.";
            ReturnValue=false;
            txtSupervisorRemark.focus();
        }
    }
    if(ddlSupervisorStatus.selectedIndex == 4)
    {
        if(txtSupervisorRemark.value == '')
        {
            ErrorMsg="Please Enter Supervisor Remark.";
            ReturnValue=false;
            txtSupervisorRemark.focus();
        }
        if(ddlPendingDS.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlPendingDS.focus();
        }
    } 
    if(ddlSupervisorStatus.selectedIndex == 3)
    {
        if(txtSupervisorRemark.value == '')
        {
            ErrorMsg="Please Enter Supervisor Remark.";
            ReturnValue=false;
            txtSupervisorRemark.focus();
        }
        if(txtCourierName.value == '')
        {
            ErrorMsg="Please Enter Courier Name.";
            ReturnValue=false;
            txtCourierName.focus();
        }
        if(txtPODNo.value == '')
        {
            ErrorMsg="Please Enter POD No.";
            ReturnValue=false;
            txtPODNo.focus();
        }
        if(txtDispatchdate.value == '')
        {
            ErrorMsg="Please Select Dispatch Date.";
            ReturnValue=false;
            txtDispatchdate.focus();
        }
    } 
    if(ddlSupervisorStatus.selectedIndex == 2)
    {
        if(txtSupervisorRemark.value == '')
        {
            ErrorMsg="Please Enter Supervisor Remark.";
            ReturnValue=false;
            txtSupervisorRemark.focus();
        }    
        if(txtSubmissionDate.value == '')
        {
            ErrorMsg="Please Select Submission Date.";
            ReturnValue=false;
            txtSubmissionDate.focus();
        }
    } 
    if(ddlSupervisorStatus.selectedIndex == 1)
    {
        if(txtSupervisorRemark.value == '')
        {
            ErrorMsg="Please Enter Supervisor Remark.";
            ReturnValue=false;
            txtSupervisorRemark.focus();
        }     
        if(txtSlipNo.value == '')
        {
            ErrorMsg="Please Enter Slip No.";
            ReturnValue=false;
            txtSlipNo.focus();
        }
        if(txtDepositDate.value == '')
        {
            ErrorMsg="Please Select Deposit Date.";
            ReturnValue=false;
            txtDepositDate.focus();
        }
    } 
    if(ddlSupervisorStatus.selectedIndex == 0)
    {
        ErrorMsg="Please Select Status.";
        ReturnValue=false;
        ddlSupervisorStatus.focus();
    } 
        
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}

</script>

<table style="width: 900px;"> 
<tr>
    <td style="width: 900px;">

    <%--Supervisor Status--%>
    <asp:Panel ID="pnlMsg" runat="server" Width="900px"> 
       <table style="width: 900px;">
            <tr>
                <td class="tta" colspan="4" style="width: 900px;">
                    <span style="font-size: 10pt">SUPERVISOR REMARK</span></td>
            </tr>   
            <tr>
                <td colspan="4" style="width: 900px;">
                    <asp:Label runat="server" ID="lblMsg" SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="600px"></asp:Label></td>
            </tr>                
        </table>
    </asp:Panel>
    <%--Supervisor Status end--%>
    
    
    
        <%--NEW ADDED--%>
    <asp:Panel id="pnlgrdVeri" runat="server" Width="900px"> 
        <table style="width: 900px;">
            <tr>
                <td style="height: 29px">
                    <div style="overflow: scroll; width: 900px; height: 350px">
                        <asp:GridView ID="grdVeri" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Height="100px" AllowSorting="true" 
                            OnRowCommand="grdVeri_RowCommand" OnRowEditing="grdVeri_RowEditing" OnSorting="grdVeri_Sorting">
                            <Columns>
                               <asp:TemplateField HeaderText="EDIT">
                               <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                     CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                               </ItemTemplate>
                               </asp:TemplateField>
                               
                           <asp:BoundField DataField="Case_ID" HeaderText="Case ID"  SortExpression="Case_id"/>
                           <asp:BoundField DataField="verification_type_id" HeaderText="Verification Type"  SortExpression="verification_type_id"/>
                           <asp:BoundField DataField="CENTRE_Name" HeaderText="Center"  SortExpression="CENTRE_Name"/>
                           <asp:BoundField DataField="Cust_fullname" HeaderText="Name"  SortExpression="Cust_fullname" />
                           <asp:BoundField DataField="CUST_ADD_LINE_1" HeaderText="Address"  SortExpression="CUST_ADD_LINE_1"/>
                           <asp:BoundField DataField="CUST_CONTACT_NO" HeaderText="Contact No."  SortExpression="CUST_CONTACT_NO"/>

                           <asp:BoundField DataField="INITIATION_DATE" HeaderText="Initiation Date" SortExpression="INITIATION_DATE"/>
                           <asp:BoundField DataField="UPLOAD_DATE" HeaderText="Upload Date"  SortExpression="UPLOAD_DATE"/>

                           <asp:BoundField DataField="SupervisorStatus" HeaderText="Supervisor Status"  SortExpression="SupervisorStatus"/>
                           <asp:BoundField DataField="SupervisorSubStatus" HeaderText="Supervisor Sub-Status"  SortExpression="SupervisorSubStatus"/>
                           <asp:BoundField DataField="SupervisorRemark" HeaderText="Supervisor Remark"  SortExpression="SupervisorRemark"/>
                           <asp:BoundField DataField="Status" HeaderText="Field Status"  SortExpression="Status"/>
                           <asp:BoundField DataField="SubStatus" HeaderText="Field Sub-Status"  SortExpression="SubStatus"/>
                           <asp:BoundField DataField="Remark" HeaderText="Field Remark"  SortExpression="Remark"/>
                           <asp:BoundField DataField="pickupdate" HeaderText="PickUp Date"  SortExpression="pickupdate"/>
                           <asp:BoundField DataField="chequedate" HeaderText="Cheque Date"  SortExpression="chequedate"/>
                           <asp:BoundField DataField="chequeno" HeaderText="Cheque No."  SortExpression="chequeno"/>
                           <asp:BoundField DataField="chequeamount" HeaderText="Cheque Amount"  SortExpression="chequeamount"/>
                           <asp:BoundField DataField="bankname" HeaderText="Bank Name"  SortExpression="bankname"/>
                           <asp:BoundField DataField="bankbranch" HeaderText="Bank Branch"  SortExpression="bankbranch"/>
                           <asp:BoundField DataField="appointment_date" HeaderText="Appointment Date"  SortExpression="appointment_date"/>
                           <asp:BoundField DataField="appointment_time" HeaderText="Appointment Time"  SortExpression="appointment_time"/>
                           <asp:BoundField DataField="Cheque_ScanImage" HeaderText="Cheque Scan Image"  SortExpression="Cheque_ScanImage"/>
                           <asp:BoundField DataField="Deposit_ScanImage" HeaderText="Deposit Scan Image"  SortExpression="Deposit_ScanImage"/>
                           <asp:BoundField DataField="Final_Status" HeaderText="Tele Status"  SortExpression="Final_Status"/>
                           <asp:BoundField DataField="Final_SubStatus" HeaderText="Tele Sub-Status"  SortExpression="Final_SubStatus"/>
                           <asp:BoundField DataField="Final_Remark" HeaderText="Tele Remark"  SortExpression="Final_Remark"/>
                           <asp:BoundField DataField="Cluster_id" HeaderText="Cluster ID"  SortExpression="Cluster_id"/>
                           <asp:BoundField DataField="Centre_id" HeaderText="Centre ID"  SortExpression="Centre_id"/>
                           
                           <asp:BoundField DataField="DepositDate" HeaderText="Deposit Date" SortExpression="DepositDate" />
                           <asp:BoundField DataField="SlipNo" HeaderText="Slip No."  SortExpression="SlipNo"/>

                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel> 
    <%--END--%>
    
    
      <%--DATA --%>
      <asp:Panel ID="pnlData" runat="server"  Width="900px"> 
            <table style="width: 900px; ">
            <tr>
                <td style="width: 113px;" class="reportTitleIncome">
                    <strong>Case ID</strong></td>
                <td style="width: 100px;" class="Info">
                    <asp:TextBox id="txtCaseID" runat="server" Width="150px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 117px;" class="reportTitleIncome">
                    <strong>Center</strong></td>
                <td style="width: 417px;" class="Info">
                    <asp:TextBox ID="txtCentre" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
               <td style="width: 113px;" class="reportTitleIncome">
                    <strong>Name</strong></td>
                <td style="width: 100px;" class="Info">
                    <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 117px;" class="reportTitleIncome">
                    <strong>Address</strong></td>
                <td style="width: 417px;" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 113px;">
                    <strong>Contact No.</strong></td>
                <td class="Info" style="width: 100px;">
                    <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px;">
                    <strong>Status</strong></td>
                <td class="Info" style="width: 417px;">
                    <asp:TextBox ID="txtStatus" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Sub-Status</strong></td>
                    <td class="Info" style="width: 100px;">
                        <asp:TextBox ID="txtSubStatus" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>

                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Pick-Up Date</strong></td>
                    <td class="Info" style="width: 417px;">
                        <asp:TextBox ID="txtPickUpDate" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Cheque Date</strong></td>
                    <td class="Info" style="width: 100px;">
                        <asp:TextBox ID="txtChequeDate" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Cheque No.</strong></td>
                    <td class="Info" style="width: 417px;">
                        <asp:TextBox ID="txtChequeNo" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Cheque Amount</strong></td>
                    <td class="Info" style="width: 100px;">
                        <asp:TextBox ID="txtChequeAmt" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Bank Name</strong></td>
                    <td class="Info" style="width: 417px;">
                        <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Bank Branch</strong></td>
                    <td class="Info" style="width: 100px;">
                        <asp:TextBox ID="txtBankBranch" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>

                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Appointment Date</strong></td>
                    <td class="Info" style="width: 417px;">
                        <asp:TextBox ID="txtAppointmentDate" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                   <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Appointment Time</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtAppointmentTime" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                    <td class="reportTitleIncome" style="width: 113px;">
                        <strong>Remark</strong></td>
                    <td class="Info" style="width: 417px" >
                        <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                            Width="300px" ReadOnly="True"></asp:TextBox></td>
                </tr>
        </table>            
     </asp:Panel> 

  <%--DATA end--%>
    
    <asp:Panel ID="pnlStatus" runat="server" Width="900px"> 
       <table style="width: 900px;">
       <tr>
        <td style="width: 40px;" class="reportTitleIncome">
            <strong>Status</strong></td>
        <td style="width: 100px;" class="Info">
            <asp:DropDownList ID="ddlSupervisorStatus" runat="server" SkinID="ddlSkin" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSupervisorStatus_SelectedIndexChanged">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Deposit</asp:ListItem>
                <asp:ListItem Value="2">Submission</asp:ListItem>
                <asp:ListItem Value="3">Courier</asp:ListItem>
                <asp:ListItem Value="4">Pending for Deposit Submission</asp:ListItem>
                <asp:ListItem Value="5">Return to Client</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        </table>
    </asp:Panel>
    
    
    <%--Deposit panel--%>
    <asp:Panel ID="pnlDeposit" runat="server" Width="900px">
        <table style="width: 900px;">
            <tr>
                <td class="reportTitleIncome" style="width: 157px;">
                    <strong>Deposit Date</strong></td>
                <td class="Info">
                    <asp:TextBox ID="txtDepositDate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]</td>
                <td class="reportTitleIncome" style="width: 172px">
                    <strong>Slip No.</strong></td>
                <td class="Info" style="width: 261px">
                    <asp:TextBox ID="txtSlipNo" runat="server" Width="100px" SkinID="txtSkin" OnBlur="WindowOpen1()"></asp:TextBox></td>
            </tr>
            <%--NEW ADDED--%>
            <tr>
                <td class="reportTitleIncome" style="width: 157px">
                    <strong>Scan Image</strong></td>
                <td class="Info" colspan="3">
                    <asp:FileUpload ID="Deposit_ScanImage" runat="server" SkinID="flup" Width="370px" /></td>
            </tr>
            <%--END--%>
        </table>
    </asp:Panel>
    <%--Deposit panel close--%>
    
    
    <%--submission panel--%>
    <asp:Panel ID="pnlSubmission" runat="server" Width="900px">
        <table style="width: 900px;">
            <tr>
              <td class="reportTitleIncome" style="width: 100px;"> <%-- colspan="2"--%>
                    <strong>Submission Date</strong></td>
                <td class="Info" style="width:465px;" colspan="2">
                    <asp:TextBox ID="txtSubmissionDate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSubmissionDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                           src="../../Images/SmallCalendar.png" />
                    [dd/mm/yyyy]</td>
            </tr>
        </table>
   </asp:Panel>
   <%--Submission panel close--%>
    

    <%--Courier panel--%>
    <asp:Panel ID="pnlCourier" runat="server" Width="900px"> 
         <table style="width: 900px;">
         <tr>
           <td class="reportTitleIncome" style="width: 120px; height: 25px;">
                <strong>Dispatch Date</strong></td>
            <td class="Info" style="width: 168px; height: 25px;">
                <asp:TextBox ID="txtDispatchdate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDispatchdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td class="reportTitleIncome" style="width: 55px; height: 25px;">
                    <strong>POD No.</strong></td>
            <td class="Info" style="width: 77px; height: 25px;">
                <asp:TextBox ID="txtPODNo" runat="server" Width="100px" SkinID="txtSkin"></asp:TextBox></td>
           <td class="reportTitleIncome" style="width: 50px; height: 25px;">
                    <strong>Courier Name</strong></td>
            <td class="Info" style="width: 84px; height: 25px;">
                <asp:TextBox ID="txtCourierName" runat="server" Width="132px" SkinID="txtSkin"></asp:TextBox></td>
          </tr>
          </table>
    </asp:Panel>    
   <%--Courier panel close--%>
    
    
    <%--PendingforDepositSubmission panel--%>
    <asp:Panel ID="pnlSubStatus" runat="server" Width="900px"> 
    <table style="width: 900px;">
          <tr>
            <td class="reportTitleIncome" style="width: 101px;">  <%--colspan="2"--%>
                <strong>Sub-Status</strong></td>
            <td style="width:465px;" colspan="2" class="Info">
                    <asp:DropDownList ID="ddlPendingDS" runat="server" SkinID="ddlSkin" Width="130px">
                        <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                        <asp:ListItem Value="PDC">PDC</asp:ListItem>
                        <asp:ListItem Value="Hold by Client">Hold by Client</asp:ListItem>
                    </asp:DropDownList></td>
           </tr>
          </table>  
    </asp:Panel> 
    <%--PendingforDepositSubmission panel End--%>
   
                
   <%--Final Remark panel--%> 
    <asp:Panel ID="pnlFinalRemark" runat="server" Width="900px">                   
    <table style="width: 900px;">
        <tr>
            <td class="reportTitleIncome" style="width: 100px;">  <%--colspan="2"--%>
                  <strong>Remark</strong></td>
            <td class="Info" colspan="2" style="width: 465px;">
                <asp:TextBox ID="txtSupervisorRemark" runat="server" TextMode="MultiLine" Width="400px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
           <td colspan="4" class="Info">
                    <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnSaveSkin" OnClick="btnSave_Click" Width="60px"/>
                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click"/></td>
    </tr>
    </table>
    </asp:Panel>
        &nbsp;
        
        <%--Final Remark panel close--%><%--Submit panel--%> 
       <asp:HiddenField ID="hdncaseID" runat="server" />
        <asp:HiddenField ID="HdnCluster" runat="server" />
        <asp:HiddenField ID="hdnvery" runat="server" />
        <asp:HiddenField ID="hdncentre" runat="server" />
        <asp:HiddenField ID="hdnID" runat="server" />
   <%--Submit panel End--%>
   
   
   </td>
   </tr>
   </table> 


</asp:Content>
