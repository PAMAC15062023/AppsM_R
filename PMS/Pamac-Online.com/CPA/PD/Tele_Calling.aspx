<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Tele_Calling.aspx.cs" Inherits="CPA_PD_Tele_Calling" Title="Untitled Page" StylesheetTheme="SkinFile" %>
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
        <td rowspan="2" style="width: 900px">
            <asp:Panel ID="Panel1" runat="server">
                <asp:Panel ID="pnlTeleCalling" runat="server" Width="900px">
                    <table style="width: 900px">
                        <tr>
                            <td class="tta" colspan="6" style="width: 900px; height: 4px">
                                <span style="font-size: 10pt">TELE CALLING</span></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="width: 900px; height: 1px">
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblError"
                                    Width="651px"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--GRIDVIEW--%>
                <asp:Panel ID="pnlgrdTele" runat="server" Width="900px">
                    <table style="width: 900px; height: 83px">
                        <tr>
                            <td style="height: 29px">
                                <div style="overflow: scroll; width: 900px; height: 500px">
                                    <asp:GridView ID="grdTele" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                                        Height="100px" OnRowCommand="grdTele_RowCommand" OnRowEditing="grdTele_RowEditing"
                                        OnSorting="grdTele_Sorting" SkinID="gridviewSkin">
                                        <Columns>
                                            <asp:TemplateField HeaderText="EDIT">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEditTele" runat="server" CommandArgument='<%#Eval("Case_id")%>'
                                                        CommandName="Edit"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="case_id" HeaderText="Case ID" SortExpression="case_id" />
                                            <asp:BoundField DataField="File_Ref_No" HeaderText="File Ref No" />
                                            <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                                            <asp:BoundField DataField="Company_Name" HeaderText="Company Name" />
                                            <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact Person Name" />
                                            <asp:BoundField DataField="Contact_Number" HeaderText="Contact Number" />
                                            <asp:BoundField DataField="pamac_location" HeaderText="pamac location" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation Date" />
                                            <asp:BoundField DataField="client_name" HeaderText="client_name" />
                                            <asp:BoundField DataField="cluster_id" HeaderText="cluster" />
                                            <asp:BoundField DataField="Call_back_date" HeaderText="Call back date" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--GRIDVIEW end--%>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server">
            
              <%--DATA --%>
      
        <asp:Panel ID="pnlData" runat="server"  Width="688px"> 
            <table style="width: 685px; height: 77px">
                <tr>
                    <td style="width: 129px; height: 11px;" class="reportTitleIncome">
                        <strong>Case ID</strong></td>
                    <td style="width: 100px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 117px; height: 11px;" class="reportTitleIncome">
                        <strong>File Ref No</strong></td>
                    <td style="width: 105px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtfilerefno" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Customer Name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtCustomerName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Company Name</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtCompanynae" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Contact person name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtcontactperson" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Contact Number</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtcontactno" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                
                   
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Pamac Location</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtpamacloc" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Address</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtaddress" runat="server" SkinID="txtSkin" Width="150px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Allocation Date</strong></td>

                      <td class="Info" colspan="1" style="height: 20px">
                        <strong>
                            <asp:TextBox ID="txtallocationdate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtallocationdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</strong></td>
                            
                            
                             <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                                 <strong>Client</strong></td>

                      <td class="Info" colspan="1" style="height: 20px">
                          <asp:TextBox ID="txtclient_name" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                            
                            
                         
                
               </tr>
               
                  <tr>
                   <td style="width: 54px; height: 3px;" class="reportTitleIncome">
                    <strong>Area</strong></td>
                <td style="width: 122px; height: 3px;" class="Info">
                    <asp:DropDownList ID="ddlarea" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="200px" AutoPostBack="True">
                        <asp:ListItem >--Select--</asp:ListItem>
                        <asp:ListItem >ICL</asp:ListItem>
                        <asp:ListItem >OCL</asp:ListItem>
                       <%-- <asp:ListItem Value="3">Hold</asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--
                      <td class="Info" colspan="1" style="height: 20px">
                          <asp:TextBox ID="TextBox2" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                            
                            --%>
                         
                
               </tr>
                    <%--<td style="width: 117px; height: 1px;" class="reportTitleIncome">
                        <strong>Initiation Date</strong></td>
                    <td style="width: 105px; height: 1px;" class="Info">
          
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
                <td style="width: 54px; height: 3px;" class="reportTitleIncome">
                    <strong>Status</strong></td>
                <td style="width: 122px; height: 3px;" class="Info">
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="200px" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Appointment Fixed</asp:ListItem>
                        <asp:ListItem Value="2">Appt Pending</asp:ListItem>
                        <asp:ListItem Value="3">Hold</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
    </asp:Panel>
    <%--Tele Status end--%>
            
                          
    <asp:Panel ID="pnlddlAppoRefused" runat="server" Width="688px"> 
         <table style="width: 687px; height: 4px;">
         <tr>
            <td class="reportTitleIncome" style="width: 53px; height: 7px">
                <strong>Sub-Status</strong></td>
            <td style="width: 128px; height: 7px;" class="Info">
                <asp:DropDownList ID="ddlAppoRefused" runat="server" SkinID="ddlSkin" Width="200px">
                    <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem Value="Not Interested">Not Interested</asp:ListItem>
                    <asp:ListItem Value="Query">Query</asp:ListItem>
                    
                </asp:DropDownList></td>
          </tr>
          </table>
    </asp:Panel>      
          
    <asp:Panel ID="pnlddlNonContactable" runat="server" Width="687px"> 
    <table style="width: 686px; height: 11px;">
          <tr>
            <td class="reportTitleIncome" style="width: 54px; height: 5px">
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
            <td class="reportTitleIncome" style="width: 54px; height: 5px">
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
                    <td class="reportTitleIncome" style="width: 131px; height: 10px">
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
                <td class="reportTitleIncome" style="width: 132px; height: 6px">
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
                <td colspan="2" class="reportTitleIncome" style="height: 5px; width: 64px;">
                            <strong>Tele Caller Remark</strong></td>
                <td class="Info" colspan="2" style="width: 445px; height: 5px;">
                    <asp:TextBox ID="txtTeleRemark" runat="server" TextMode="MultiLine" Width="507px" SkinID="txtSkin"></asp:TextBox></td>
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
            </asp:Panel>
        </td>
    </tr>
    <tr>
    </tr>
<tr>
    <td style="width: 900px;">  
    
        
    
            </td>
        </tr>

    </table>    



</asp:Content>

