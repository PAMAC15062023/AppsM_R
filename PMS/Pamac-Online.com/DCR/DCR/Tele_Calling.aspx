<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="Tele_Calling.aspx.cs" Inherits="DCR_DCR_Tele_Calling" Title="Untitled Page" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    
    var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>");
    var txtAppoDate = document.getElementById("<%=txtAppoDate.ClientID%>");
    var txtAppoTime = document.getElementById("<%=txtAppoTime.ClientID%>");
    var txtCallBackDate = document.getElementById("<%=txtCallBackDate.ClientID%>");
    var txtCallBackTime = document.getElementById("<%=txtCallBackTime.ClientID%>");
    var ddlAppoRefused = document.getElementById("<%=ddlAppoRefused.ClientID%>");
    var ddlNonContactable = document.getElementById("<%=ddlNonContactable.ClientID%>");
    
    //NEW ADDED
    var ddlReturn = document.getElementById("<%=ddlReturn.ClientID%>");
    
    if(ddlStatus.selectedIndex == 5)
    {
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
        if(ddlNonContactable.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlNonContactable.focus();
        }
    }   
    if(ddlStatus.selectedIndex == 3)
    {
        if(ddlAppoRefused.selectedIndex == 0)
        {
            ErrorMsg="Please Select Sub-Status.";
            ReturnValue=false;
            ddlAppoRefused.focus();
        }
    }  
    if(ddlStatus.selectedIndex == 2)
    {

        if(txtCallBackTime.value == '')
        {
            ErrorMsg="Please Enter Call-Back Time.";
            ReturnValue=false;
            txtCallBackTime.focus();
        }
        if(txtCallBackDate.value == '')
        {
            ErrorMsg="Please Select Call-Back Date.";
            ReturnValue=false;
            txtCallBackDate.focus();
        }
    }
    if(ddlStatus.selectedIndex == 1)
    {
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
    if(ddlStatus.selectedIndex == 0)
    {
        ErrorMsg=("Please Select Status to continue.");
        ReturnValue=false;
        ddlStatus.focus();
    }
   
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}

function DateAlert()
{     
    var txtAppoDate = document.getElementById("txtAppoDate.ClientID").value;
    var txtAppoTime = document.getElementById("txtAppoTime.ClientID").value;
    var txtCallBackDate = document.getElementById("txtCallBackDate.ClientID").value;
    var txtCallBackTime = document.getElementById("txtCallBackTime.ClientID").value;
    
    alert("Appointment at: "+txtAppoDate+ " "+txtAppoTime);
    window.scrollTo(0,0);
}
</script>


<table style="width: 900px;">  
<tr>
    <td style="width: 900px;">  
    <asp:Panel ID="pnlTeleCalling" runat="server"  Width="900px"> 
        <table style="width: 900px; ">
        <tr>
            <td class="tta" colspan="6" style="width: 900px; height: 4px;">
                <span style="font-size: 10pt">TELE CALLING</span></td>  
        </tr>
        <tr>
            <td colspan="6" style="width: 900px; height: 1px;">
                <asp:Label runat="server" ID="lblMsg"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="651px"></asp:Label></td>
        </tr>
        </table>
    </asp:Panel>

        <%--GRIDVIEW--%>
            <asp:Panel ID="pnlgrdTele" runat="server"  Width="900px"> 
                <table style="width: 900px; height: 83px;">
                    <tr>
                        <td style="height: 29px">
                    	<div style="overflow: scroll; width: 900px; height: 500px">
                        <asp:GridView ID="grdTele" runat="server" SkinID="gridviewSkin" OnRowCommand="grdTele_RowCommand" OnRowEditing="grdTele_RowEditing"
                            Height="100px" AllowSorting="true" OnSorting="grdTele_Sorting" AutoGenerateColumns="false">
                                <Columns>
                                   <asp:TemplateField HeaderText="EDIT">
                                   <ItemTemplate>
                                        <asp:LinkButton ID="lnkEditTele" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                         CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                                   </ItemTemplate>
                                   </asp:TemplateField>
 
                                   <asp:BoundField DataField="Case_id" HeaderText="Case ID" SortExpression="Case_id"/>
                                   <asp:BoundField DataField="CENTRE_Name" HeaderText="Center" SortExpression="CENTRE_Name"/>
                                   <asp:BoundField DataField="verification_type_id" HeaderText="Verification Type" SortExpression="verification_type_id"/>
                                   <asp:BoundField DataField="LEAD_ID" HeaderText="Lead ID" SortExpression="LEAD_ID"/>
                                   <asp:BoundField DataField="Policy_no" HeaderText="Policy No." SortExpression="Policy_no"/>
                                   <asp:BoundField DataField="CUST_FULLNAME" HeaderText="Name" SortExpression="CUST_FULLNAME"/>
                                   <asp:BoundField DataField="CUST_ADD_LINE_1" HeaderText="Address" SortExpression="CUST_ADD_LINE_1"/>
                                   <asp:BoundField DataField="CUST_CONTACT_NO" HeaderText="Contact No." SortExpression="CUST_CONTACT_NO"/>
                                   <asp:BoundField DataField="INITIATION_DATE" HeaderText="Initiation Date" SortExpression="INITIATION_DATE"/>
                                   <asp:BoundField DataField="UPLOAD_DATE" HeaderText="Upload Date"  SortExpression="UPLOAD_DATE"/>
                                   <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"/>
                                   <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark"/>
                                   <asp:BoundField DataField="Final_Status" HeaderText="Tele Status" SortExpression="Final_Status"/>
                                   <asp:BoundField DataField="CallBackDate" HeaderText="CallBack Date" SortExpression="CallBackDate"/>
                                   <asp:BoundField DataField="CallBackTime" HeaderText="CallBack Time" SortExpression="CallBackTime"/>
                                   <asp:BoundField DataField="Cluster_id" HeaderText="Cluster ID" SortExpression="Cluster_id"/>
                                </Columns>
                            </asp:GridView>
            			</div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        <%--GRIDVIEW end--%>
        
        
      <%--DATA --%>
      
        <asp:Panel ID="pnlData" runat="server"  Width="688px"> 
            <table style="width: 685px; height: 77px">
                <tr>
                    <td style="width: 114px; height: 11px;" class="reportTitleIncome">
                        <strong>Case ID</strong></td>
                    <td style="width: 100px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 117px; height: 11px;" class="reportTitleIncome">
                        <strong>Centre</strong></td>
                    <td style="width: 105px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtCentre" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 114px; height: 20px;" class="reportTitleIncome">
                        <strong>Name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Contact No.</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 117px; height: 20px;" class="reportTitleIncome">
                        <strong>Address</strong></td>
                    <td style="width: 105px; height: 20px;" class="Info" colspan="3">
                        <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                    <%--<td style="width: 117px; height: 1px;" class="reportTitleIncome">
                        <strong>Initiation Date</strong></td>
                    <td style="width: 105px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtInitiationDate" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>--%>
                </tr>
                
                <%--<tr>
                    <td style="width: 114px; height: 9px;" class="reportTitleIncome">
                        <strong>Amount</strong></td>
                    <td style="width: 100px; height: 9px;" class="Info">
                        <asp:TextBox ID="txtAmount" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 117px; height: 9px;" class="reportTitleIncome">
                        <strong>Remark</strong></td>
                    <td style="width: 105px; height: 9px;" class="Info">
                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>--%>
                
            </table>            
            </asp:Panel> 

      <%--DATA end--%>


    <%--Tele Status--%>
    <asp:Panel ID="pnlTeleStatus" runat="server" Width="688px"> 
       <table style="width: 686px; height: 12px;">
             <tr>
                <td style="width: 48px; height: 3px;" class="reportTitleIncome">
                    <strong>Status</strong></td>
                <td style="width: 122px; height: 3px;" class="Info">
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="200px" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Appointment Fixed</asp:ListItem>
                        <asp:ListItem Value="2">Call Back</asp:ListItem>
                        <asp:ListItem Value="3">Appointment Refused</asp:ListItem>
                        <asp:ListItem Value="4">Non Contactable</asp:ListItem>
                        <asp:ListItem Value="5">Returned</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
    </asp:Panel>
    <%--Tele Status end--%>
            
                          
    <asp:Panel ID="pnlddlAppoRefused" runat="server" Width="688px"> 
         <table style="width: 687px; height: 4px;">
         <tr>
            <td class="reportTitleIncome" style="width: 48px; height: 7px">
                <strong>Sub-Status</strong></td>
            <td style="width: 128px; height: 7px;" class="Info">
                <asp:DropDownList ID="ddlAppoRefused" runat="server" SkinID="ddlSkin" Width="200px">
                    <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem Value="Not Interested">Not Interested</asp:ListItem>
                    <asp:ListItem Value="Query">Query</asp:ListItem>
                    <asp:ListItem Value="Self Pay">Self Pay</asp:ListItem>
                    <asp:ListItem Value="Already Paid">Already Paid</asp:ListItem>
                </asp:DropDownList></td>
          </tr>
          </table>
    </asp:Panel>      
          
    <asp:Panel ID="pnlddlNonContactable" runat="server" Width="687px"> 
    <table style="width: 686px; height: 11px;">
          <tr>
            <td class="reportTitleIncome" style="width: 48px; height: 5px">
                <strong>Sub-Status</strong></td>
            <td style="width: 100px; height: 5px;" class="Info">
                    <asp:DropDownList ID="ddlNonContactable" runat="server" SkinID="ddlSkin" Width="200px">
                        <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                        <asp:ListItem Value="No Response">No Response</asp:ListItem>
                        <asp:ListItem Value="Not Available">Not Available</asp:ListItem>
                    </asp:DropDownList></td>
           </tr>
          </table> 
    </asp:Panel>          


<%--NEW ADDED--%>

    <asp:Panel ID="pnlReturn" runat="server" Width="687px"> 
    <table style="width: 686px; height: 11px;">
          <tr>
            <td class="reportTitleIncome" style="width: 48px; height: 5px">
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



    <%--Appo panel--%>
        <asp:Panel ID="pnlAppoFixed" runat="server" Width="674px">
            <table style="width: 685px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 104px; height: 10px">
                        <strong>Appointment Date</strong></td>
                    <td class="Info" style="width: 167px; height: 10px">
                        <asp:TextBox ID="txtAppoDate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAppoDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                        [dd/mm/yyyy]</td>
                    <td class="reportTitleIncome" style="width: 104px; height: 10px">
                        <strong>Appointment Time</strong></td>
                    <td class="Info" style="width: 168px; height: 10px">
                        <asp:TextBox ID="txtAppoTime" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                        <asp:DropDownList ID="ddlAppoTime" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList>
                        [hh:mm]</td>
                </tr>
            </table>
        </asp:Panel>
    <%--Appo panel close--%>

                        
   <%--Callback panel--%>
      <asp:Panel ID="pnlCallBack" runat="server" Width="684px">
        <table style="width: 684px; height: 15px;">
            <tr>
                <td class="reportTitleIncome" style="width: 105px; height: 6px">
                    <strong>Call-Back Date</strong></td>
                <td class="Info" style="width: 167px; height: 6px">
                    <asp:TextBox ID="txtCallBackDate" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtCallBackDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" />
                    [dd/mm/yyyy]</td>
                <td class="reportTitleIncome" style="width: 107px; height: 6px">
                    <strong>Call-Back Time</strong></td>
                <td class="Info" style="width: 168px; height: 6px">
                    <asp:TextBox ID="txtCallBackTime" runat="server" Width="70px" SkinID="txtSkin"></asp:TextBox>
                        <asp:DropDownList ID="ddlCallBackTime" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList>
                    [hh:mm]</td>
            </tr>
        </table>
    </asp:Panel>
   <%--Callback panel close--%>
                
   <%--Tele Caller Remark panel--%> 
        <asp:Panel ID="pnlTeleRemark" runat="server" Width="685px">                   
        <table style="width: 684px; height: 22px">
            <tr>
                <td colspan="2" class="reportTitleIncome" style="height: 5px; width: 65px;">
                            <strong>Tele Caller Remark</strong></td>
                <td class="Info" colspan="2" style="width: 465px; height: 5px;">
                    <asp:TextBox ID="txtTeleRemark" runat="server" TextMode="MultiLine" Width="517px" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
        </table>
                  <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnSaveSkin"/>
                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></asp:Panel>
  <%--Tele Caller Remark panel close--%>  

    <asp:Panel ID="pnlSubmit" runat="server" Width="684px">
        <asp:HiddenField ID="hdnTeleCaseID" runat="server" />
        <asp:HiddenField ID="hdnID" runat="server" />
        <asp:HiddenField ID="HdnCluster" runat="server" />
        <asp:HiddenField ID="Hdnmaster" runat="server" />
        <asp:HiddenField ID="HdnVeri" runat="server" />
        
    </asp:Panel>
            </td>
        </tr>

    </table>    
</asp:Content>

