<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master"AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="DCR_DCR_Verification" Title="Untitled Page" Theme="SkinFile"  ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function Validate()
{

    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg1 = document.getElementById("<%=lblMsg1.ClientID%>");
    var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>");
    var ddlAppoRefusedProvide = document.getElementById("<%=ddlAppoRefusedProvide.ClientID%>");
    var ddlNonContactable = document.getElementById("<%=ddlNonContactable.ClientID%>");
    var txtPickUpDate = document.getElementById("<%=txtPickUpDate.ClientID%>");
    var txtChequeDate = document.getElementById("<%=txtChequeDate.ClientID%>");
    var txtChequeNo = document.getElementById("<%=txtChequeNo.ClientID%>");
    var txtChequeAmount =  document.getElementById("<%=txtChequeAmount.ClientID%>");
    var txtBankName =  document.getElementById("<%=txtBankName.ClientID%>");
    var txtBankBranch =  document.getElementById("<%=txtBankBranch.ClientID%>");
    var txtAppoDate =  document.getElementById("<%=txtAppoDate.ClientID%>");
    var txtAppoTime =  document.getElementById("<%=txtAppoTime.ClientID%>");
    var txtFinalRemark = document.getElementById("<%=txtFinalRemark.ClientID%>");

    //NEW ADDED
    var ddlReturn = document.getElementById("<%=ddlReturn.ClientID%>");
    
    if(ddlStatus.selectedIndex == 5)
    {
        if(txtFinalRemark.value == '')
        {
            ErrorMsg="Please Enter Verifier Remark.";
            ReturnValue=false;
            txtFinalRemark.focus();
        }
        if(ddlReturn.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlReturn.focus();
        }
    }
    //END

    if(ddlStatus.selectedIndex == 4)
    {
        if(txtFinalRemark.value == '')
        {
            ErrorMsg="Please Enter Verifier Remark.";
            ReturnValue=false;
            txtFinalRemark.focus();
        }
        if(ddlNonContactable.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlNonContactable.focus();
        }
    } 

    if(ddlStatus.selectedIndex == 3)
    {
        if(txtFinalRemark.value == '')
        {
            ErrorMsg="Please Enter Verifier Remark.";
            ReturnValue=false;
            txtFinalRemark.focus();
        }
        if(ddlAppoRefusedProvide.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlAppoRefusedProvide.focus();
        }
    } 

    if(ddlStatus.selectedIndex == 2)
    {
        if(txtFinalRemark.value == '')
        {
            ErrorMsg="Please Enter Verifier Remark.";
            ReturnValue=false;
            txtFinalRemark.focus();
        }   

        if(txtAppoTime.value == '')
        {
            ErrorMsg="Please Enter Appointment Time.";
            ReturnValue=false;
            txtAppoTime.focus();
        }
        if(txtAppoDate.value == '')
        {
            ErrorMsg="Please Select Appointment Date.";
            ReturnValue=false;
            txtAppoDate.focus();
        }
    }

    if(ddlStatus.selectedIndex == 1)
    {
        if(txtFinalRemark.value == '')
        {
            ErrorMsg="Please Enter Verifier Remark.";
            ReturnValue=false;
            txtFinalRemark.focus();
        }
        if(txtBankBranch.value == '')
        {
            ErrorMsg = "Please Enter Bank Branch.";
            ReturnValue=false;
            txtBankBranch.focus();
        }
        if(txtBankName.value == '')
        {
            ErrorMsg = "Please Enter Bank Name.";
            ReturnValue=false;
            txtBankName.focus();
        }
        if((txtChequeAmount.value == '') || isNaN(txtChequeAmount.value))
        {
            ErrorMsg = "Please Enter Cheque Amount.";
            ReturnValue=false;
            txtChequeAmount.focus();
        }
        if((txtChequeNo.value == '') || isNaN(txtChequeNo.value) || (txtChequeNo.value.length !=6))
        {
            ErrorMsg = "Please Enter Valid 6 digit Cheque Number.";
            ReturnValue=false;
            txtChequeNo.focus();
        }
        if(txtChequeDate.value == '')
        {
            ErrorMsg = "Please Select Cheque Date.";
            ReturnValue=false;
            txtChequeDate.focus();
        }
        if(txtPickUpDate.value == '')
        {
            ErrorMsg = "Please Select Pick-Up Date.";
            ReturnValue=false;
            txtPickUpDate.focus();
        }
    }
    if(ddlStatus.selectedIndex == 0)
    {
        ErrorMsg=("Please Select Status to continue.");
        ReturnValue=false;
        ddlStatus.focus();
    }
    
    window.scrollTo(0,0);
    lblMsg1.innerText = ErrorMsg;
    return ReturnValue;
}
</script>

<table style="width: 750px;">  <%--height: 419px--%>
<tr>
    <td style="width: 750px;">  <%--height: 15px;  height: 1167px;"--%>
    
        <asp:Panel ID="pnlMsg" runat="server"  Width="700px"> 
            <table style="width: 950px; ">
            <tr>
                <td class="tta" colspan="6" style="width: 950px;">
                    <span style="font-size: 10pt">CASE VERIFICATION</span></td>  <%--height: 19px;--%> 
            </tr>
            <tr>
                <td colspan="6" style="width: 750px;">
                    <asp:Label ID="lblSave" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin" Width="651px"></asp:Label>
                    <asp:Label runat="server" ID="lblMsg"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="651px"></asp:Label>
                </td>
            </tr>
            </table>
        
    <%--NEW ADDED--%>
    <asp:Panel id="pnlgrdVeri" runat="server" Width="688px"> 
        <table style="width: 686px;">
            <tr>
                <td style="height: 29px">
                    <div style="overflow: scroll; width: 950px; height: 350px">
                  <%--  <asp:GridView ID="grdVeri" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Height="100px" AllowSorting="true"
                        OnRowCommand="grdVeri_RowCommand" OnRowEditing="grdVeri_RowEditing" OnSorting="grdVeri_Sorting">    <%--AllowSorting="true"--%>
                   <%--     <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                           
                           <asp:BoundField DataField="Case_id" HeaderText="Case ID" SortExpression="Case_id"/>
                           <asp:BoundField DataField="verification_type_id" HeaderText="Verification Type" SortExpression="verification_type_id"/>
                           <asp:BoundField DataField="CENTRE_Name" HeaderText="Center" SortExpression="CENTRE_Name"/>
                           <asp:BoundField DataField="CUST_FULLNAME" HeaderText="Name"  SortExpression="CUST_FULLNAME"/>
                           <asp:BoundField DataField="CUST_ADD_LINE_1" HeaderText="Address"  SortExpression="CUST_ADD_LINE_1"/>
                           <asp:BoundField DataField="cust_pin" HeaderText="Pincode"  SortExpression="cust_pin"/>
                           <asp:BoundField DataField="CUST_CONTACT_NO" HeaderText="Contact No."  SortExpression="CUST_CONTACT_NO"/>
                           
                           <asp:BoundField DataField="INITIATION_DATE" HeaderText="Initiation Date" SortExpression="INITIATION_DATE"/>
                           <asp:BoundField DataField="UPLOAD_DATE" HeaderText="Upload Date"  SortExpression="UPLOAD_DATE"/>
                           
                           <asp:BoundField DataField="Fullname" HeaderText="Verifier Name"  SortExpression="Fullname"/>
                           <asp:BoundField DataField="Status" HeaderText="Field Status"  SortExpression="Status"/>
                           <asp:BoundField DataField="SubStatus" HeaderText="Field Sub Status"  SortExpression="SubStatus"/>
                           <asp:BoundField DataField="Cheque_ScanImage" HeaderText="Cheque Scan Image"  SortExpression="Cheque_ScanImage"/>
                           <asp:BoundField DataField="Cluster_id" HeaderText="Cluster ID"  SortExpression="Cluster_id"/>
                           <asp:BoundField DataField="Centre_id" HeaderText="Centre ID"  SortExpression="Centre_id"/>
                           
                           <asp:BoundField DataField="PickUpDate" HeaderText="PickUpDate"  SortExpression="PickUpDate"/>
                           <asp:BoundField DataField="ChequeDate" HeaderText="ChequeDate"  SortExpression="ChequeDate"/>
                           <asp:BoundField DataField="ChequeNo" HeaderText="ChequeNo"  SortExpression="ChequeNo"/>
                           <asp:BoundField DataField="ChequeAmount" HeaderText="ChequeAmount"  SortExpression="ChequeAmount"/>
                           <asp:BoundField DataField="BankName" HeaderText="BankName"  SortExpression="BankName"/>
                           <asp:BoundField DataField="BankBranch" HeaderText="BankBranch"  SortExpression="BankBranch"/>

                        </Columns>--%>
                <%--    </asp:GridView>--%>
                        <asp:GridView ID="GridView1" runat="server"
                        
                          OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnSorting="GridView1_Sorting" SkinID="gridviewSkin">
                          
                           <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel> 
    <%--END--%>
        
        </asp:Panel>
    
     
        <%--DATA --%>
    <asp:Panel ID="pnlData" runat="server"  Width="688px"> 
            <table style="width: 700px; ">
            <tr>
                <td class="tta" colspan="6" style="width: 700px; height: 4px;">
                    <span style="font-size: 10pt">VERIFICATION FORM</span></td>  <%--height: 19px;--%> 
            </tr>
            <tr>
                <td colspan="6" style="width: 700px; height: 1px;">
                    <asp:Label runat="server" ID="lblMsg1"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="651px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 117px; height: 14px;" class="reportTitleIncome">
                    <strong>Case ID</strong></td>
                <td style="width: 105px; height: 14px;" class="Info">
                    <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                <td style="width: 117px; height: 11px;" class="reportTitleIncome">
                    <strong>Center</strong></td>
                <td style="width: 105px; height: 11px;" class="Info">
                    <asp:TextBox ID="txtCentre" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 113px; height: 14px;" class="reportTitleIncome">
                    <strong>Name</strong></td>
                <td style="width: 100px; height: 14px;" class="Info">
                    <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            
                <td style="width: 117px; height: 14px;" class="reportTitleIncome">
                    <strong>Address</strong></td>
                <td style="width: 105px; height: 14px;" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="150px"></asp:TextBox></td>

            </tr>
            <tr>
                <td style="width: 113px; height: 1px;" class="reportTitleIncome">
                    <strong>Pincode</strong></td>
                <td style="width: 100px; height: 1px;" class="Info">
                    <asp:TextBox ID="txtPincode" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>

                <td style="width: 113px; height: 1px;" class="reportTitleIncome">
                    <strong>Contact No.</strong></td>
                <td style="width: 100px; height: 1px;" class="Info">
                    <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
        </table>            
     </asp:Panel> 

  <%--DATA end--%>


    <%--Tele Status--%>
    <asp:Panel ID="pnlStatus" runat="server" Width="700px"> 
       <table style="width: 700px; height: 12px;">
             <tr>
                <td style="width: 50px;" class="reportTitleIncome">
                    <strong>Status</strong></td>
                <td style="width: 122px;" class="Info">
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Pick Up</asp:ListItem>
                        <asp:ListItem Value="2">Appointment Rescheduled</asp:ListItem>
                        <asp:ListItem Value="3">Refused to Provide</asp:ListItem>
                        <asp:ListItem Value="4">Non Contactable</asp:ListItem>
                        <asp:ListItem Value="5">Returned</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
    </asp:Panel>
    <%--Tele Status end--%>
            
                          
    <asp:Panel ID="pnlddlAppoRefusedProvide" runat="server" Width="700px"> 
         <table style="width: 700px; height: 4px;">
         <tr>
            <td class="reportTitleIncome" style="width: 50px;">
                <strong>Sub-Status</strong></td>
            <td style="width: 128px;" class="Info">
                <asp:DropDownList ID="ddlAppoRefusedProvide" runat="server" SkinID="ddlSkin" Width="200px">
                    <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem Value="Not Interested">Not Interested</asp:ListItem>
                    <asp:ListItem Value="Query">Query</asp:ListItem>
                    <asp:ListItem Value="Self Pay">Self Pay</asp:ListItem>
                    <asp:ListItem Value="Already Paid">Already Paid</asp:ListItem>
                </asp:DropDownList></td>
          </tr>
          </table>
    </asp:Panel>      
          
    <asp:Panel ID="pnlddlNonContactable" runat="server" Width="700px"> 
    <table style="width: 700px; height: 11px;">
          <tr>
            <td class="reportTitleIncome" style="width: 50px;">
                <strong>Sub-Status</strong></td>
            <td style="width: 100px;" class="Info">
                    <asp:DropDownList ID="ddlNonContactable" runat="server" SkinID="ddlSkin" Width="200px">
                        <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                        <asp:ListItem Value="Address Untraceable">Address Untraceable</asp:ListItem>
                        <asp:ListItem Value="Not Available">Not Available</asp:ListItem>
                    </asp:DropDownList></td>
           </tr>
          </table> 
    </asp:Panel>          


<%--NEW ADDED--%>

    <asp:Panel ID="pnlReturn" runat="server" Width="687px"> 
    <table style="width: 699px; height: 11px;">
          <tr>
            <td class="reportTitleIncome" style="width: 51px; height: 5px">
                <strong>Sub-Status</strong></td>
            <td style="width: 100px; height: 5px;" class="Info">
                    <asp:DropDownList ID="ddlReturn" runat="server" SkinID="ddlSkin" Width="200px">
                        <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                        <asp:ListItem Value="BOCL">BOCL</asp:ListItem>
                        <asp:ListItem Value="Duplicate Leads">Duplicate Leads</asp:ListItem>
                        <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                    </asp:DropDownList></td>
           </tr>
          </table> 
    </asp:Panel>   

<%--END--%>



    <%--Pick Up panel--%>
        <asp:Panel ID="pnlPickUp" runat="server" Width="700px">
            <table style="width: 700px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 142px;">
                        <strong>Pick-Up Date</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtPickUpDate" runat="server" Width="70px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickUpDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                        [dd/mm/yyyy]</td>
                    <td class="reportTitleIncome" style="width: 156px;">
                        <strong>Cheque Date</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtChequeDate" runat="server" Width="70px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtChequeDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                        [dd/mm/yyyy]</td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 142px;">
                        <strong>Cheque Number</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtChequeNo" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
                    <td class="reportTitleIncome" style="width: 156px;">
                        <strong>Cheque Amount</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtChequeAmount" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 142px;">
                        <strong>Bank Name</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtBankName" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
                    <td class="reportTitleIncome" style="width: 156px;">
                        <strong>Bank Branch</strong></td>
                    <td class="Info">
                        <asp:TextBox ID="txtBankBranch" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 142px">
                        <strong>Scan Image</strong></td>
                    <td class="Info" colspan="3">
                        <asp:FileUpload ID="Cheque_ScanImage" runat="server" SkinID="flup" Width="370px" /></td>
                </tr>
            </table>
        </asp:Panel>
    <%--Pick Up panel close--%>
                        
    <%--Appo panel--%>
        <asp:Panel ID="pnlAppoFixed" runat="server" Width="700px">
            <table style="width: 700px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 130px;">
                        <strong>Appointment Date</strong></td>
                    <td class="Info" style="width: 167px;">
                        <asp:TextBox ID="txtAppoDate" runat="server" Width="70px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAppoDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                        [dd/mm/yyyy]</td>
                    <td class="reportTitleIncome" style="width: 137px;">
                        <strong>Appointment Time</strong></td>
                    <td class="Info" style="width: 168px;">
                        <asp:TextBox ID="txtAppoTime" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                        <asp:DropDownList ID="ddlAppoTime" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList> [hh:mm]
                    </td>
                </tr>
            </table>
        </asp:Panel>
   <%--Appo panel close--%>
   
   
      <%--Final Remark panel--%> 
    <asp:Panel ID="pnlFinalRemark" runat="server" Width="700px">                   
        <table style="width: 700px;">
            <tr>
                <td colspan="2" class="reportTitleIncome" style="width: 19px;">
                      <strong>Remark</strong></td>
                <td class="Info" colspan="2" style="width: 465px;">
                    <asp:TextBox ID="txtFinalRemark" runat="server" TextMode="MultiLine" Width="528px" SkinID="txtSkin" Height="27px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnSaveSkin" OnClick="btnSave_Click" Width="68px"/>
            &nbsp; <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click"/>
    </asp:Panel>
  <%--Final Remark panel close--%> 
   
        <asp:SqlDataSource ID="sdsVerifyType" runat="server" ProviderName="System.Data.OleDb"
            SelectCommand="Select [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE], [VERIFICATION_TYPE_CODE] &#13;&#10;from VERIFICATION_TYPE_MASTER &#13;&#10;WHERE VERIFICATION_TYPE_ID IN(62,63)">
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdnFEID" runat="server" />
        <asp:HiddenField ID="hdnCaseID" runat="server" />
        <asp:HiddenField ID="HdnCluster" runat="server" />
        <asp:HiddenField ID="hdnvery" runat="server" />
        <asp:HiddenField ID="hdncentre" runat="server" />
        <asp:HiddenField ID="hdnID" runat="server" />

            </td>
        </tr>

    </table>

</asp:Content>
