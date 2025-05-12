<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Supervisior_Remark.aspx.cs" Inherits="CPA_PD_Supervisior_Remark" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">



</script>

<table style="width: 750px;"> 
<tr>
     <td style="width: 750px;">

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
      <asp:Panel ID="pnlgrdTele" runat="server"  Width="900px"> 
                <table style="width: 900px; height: 83px;">
                    <tr>
                        <td style="height: 19px">
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
   
                <asp:BoundField DataField="case_id" HeaderText="Case ID"  SortExpression="case_id"/>
                <asp:BoundField DataField="File_Ref_No" HeaderText="File Ref No"  />
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Company_Name" HeaderText="Company Name"  />
                <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact Person Name"  />
                <asp:BoundField DataField="Contact_Number" HeaderText="Contact Number"  />
                <asp:BoundField DataField="pamac_location" HeaderText="Pamac location" />
                <asp:BoundField DataField="Address" HeaderText="Address"  />
                <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation Date"  />
                 <asp:BoundField DataField="cluster_id" HeaderText="cluster"  />
                                </Columns>
                            </asp:GridView>
            			</div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
    <%--END--%>
    
    
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
                    <td style="width: 114px; height: 20px;" class="reportTitleIncome">
                        <strong>Address</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtaddress" runat="server" SkinID="txtSkin" Width="150px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Allocation Date</strong></td>

                      <td class="Info" colspan="1" style="height: 20px">
                        <strong>
                            <asp:TextBox ID="txtallocationdate" runat="server" SkinID="txtSkin" Width="70px" ReadOnly="True"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtallocationdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</strong></td>
                            
                            
                             <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Report Sent Date</strong></td>

                      <td class="Info" colspan="1" style="height: 20px">
                        <strong>
                            <asp:TextBox ID="txtreport" runat="server" SkinID="txtSkin" Width="70px" ReadOnly="True"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtreport.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</strong></td>
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
    
    <asp:Panel ID="pnlStatus" runat="server" Width="900px"> 
    <table style="width: 685px; height: 77px">
       <tr>
        <td style="width: 57px; height: 28px;" class="reportTitleIncome">
            <strong>Status</strong></td>
        <td style="width: 56px; height: 28px;" class="Info">
            <asp:DropDownList ID="ddlSupervisorStatus" runat="server" SkinID="ddlSkin" Width="210px" AutoPostBack="True" OnSelectedIndexChanged="ddlSupervisorStatus_SelectedIndexChanged">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Approve</asp:ListItem>
                <asp:ListItem Value="2">Hold</asp:ListItem>
               
            </asp:DropDownList></td>
            </tr>
            <tr>
             <td style="width: 57px; height: 5px;" class="reportTitleIncome">
            <strong>Quality Check Done</strong></td>
        <td style="width: 100px; height: 5px;" class="Info">
            <asp:DropDownList ID="ddlQualitycheckDone" runat="server" SkinID="ddlSkin" Width="211px"  ValidationGroup="grValidate" AutoPostBack="True" OnSelectedIndexChanged="ddlSupervisorStatus_SelectedIndexChanged" Height="18px">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
               
            </asp:DropDownList></td>
        </tr>
        </table>
    </asp:Panel>
    
    
    
    <%--PendingforDepositSubmission panel End--%>
   
                
   <%--Final Remark panel--%> 
    <asp:Panel ID="pnlFinalRemark" runat="server" Width="900px">                   
    <table style="width: 685px; height: 77px">
        <tr>
            <td class="reportTitleIncome" style="width: 135px;">  <%--colspan="2"--%>
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
    
    
    
        <%--Final Remark panel close--%><%--Submit panel--%> 
       <asp:HiddenField ID="hdncaseID" runat="server" />
        <asp:HiddenField ID="HdnCluster" runat="server" />
        <asp:HiddenField ID="hdnvery" runat="server" />
        <asp:HiddenField ID="hdncentre" runat="server" />
        <asp:HiddenField ID="hdnID" runat="server" />
   <%--Submit panel End--%>
   
   
        <asp:RequiredFieldValidator ID="rfvStandardRemark" runat="server"
                                         ErrorMessage="Please Select Yes For Quality check Done" ControlToValidate="ddlQualitycheckDone"
                                        InitialValue="--Select--" Display="None" ValidationGroup="grValidate"  >
                                    </asp:RequiredFieldValidator> 
    
    
        &nbsp;
         <asp:ValidationSummary ID="vsValidate" runat="server" ValidationGroup="grValidate" ShowMessageBox="True" ShowSummary="False" /> 
   </td>
   </tr>
   </table> 


</asp:Content>

