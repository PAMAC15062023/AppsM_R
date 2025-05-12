<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="CPA_PD_Verification" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>


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
                <td colspan="6" style="width: 750px; height: 40px;">
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
                    <asp:GridView ID="grdVeri" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="false" Height="100px" AllowSorting="true"
                        OnRowCommand="grdVeri_RowCommand" OnRowEditing="grdVeri_RowEditing" OnSorting="grdVeri_Sorting">    <%--AllowSorting="true"--%>
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditVeri" runat="server"  CommandArgument='<%#Eval("Case_id")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                           
                <asp:BoundField DataField="case_id" HeaderText="Case ID"  SortExpression="case_id"/>
                <asp:BoundField DataField="File_Ref_No" HeaderText="File Ref No"  />
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Company_Name" HeaderText="Company Name"  />
                <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact Person Name"  />
                <asp:BoundField DataField="Contact_Number" HeaderText="Contact Number"  />
                <asp:BoundField DataField="pamac_location" HeaderText="pamac location" />
                <asp:BoundField DataField="Address" HeaderText="Address"  />
                <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation Date"  />
                    <asp:BoundField DataField="Appointment_Date" HeaderText="Appointment Date"  />
                  <asp:BoundField DataField="cluster_id" HeaderText="cluster"  />
                      <asp:BoundField DataField="centre_id" HeaderText="centre"  />

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
            <table style="width: 685px; height: 77px">
                <tr>
                    <td style="width: 129px; height: 11px;" class="reportTitleIncome">
                        <strong>Case ID</strong></td>
                    <td style="width: 100px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 129px; height: 11px;" class="reportTitleIncome">
                        <strong>File Ref No</strong></td>
                    <td style="width: 80px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtfilerefno" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Customer Name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtCustomerName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 129px; height: 1px;" class="reportTitleIncome">
                        <strong>Company Name</strong></td>
                    <td style="width: 80px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtCompanynae" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Contact person name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtcontactperson" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 129px; height: 1px;" class="reportTitleIncome">
                        <strong>Contact Number</strong></td>
                    <td style="width: 80px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtcontactno" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                </tr>
                
                   
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Pamac Location</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtpamacloc" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 129px; height: 1px;" class="reportTitleIncome">
                        <strong>Address</strong></td>
                    <td style="width: 80px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtaddress" runat="server" SkinID="txtSkin" Width="150px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Allocation Date</strong></td>

                      <td class="Info" colspan="1" style="height: 20px">
                        <strong>
                            <asp:TextBox ID="txtallocationdate" runat="server" SkinID="txtSkin" Width="70px" ReadOnly="True"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtallocationdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" /><br />
                            [dd/mm/yyyy]</strong></td>
                      <td class="reportTitleIncome" style="width: 129px; height: 20px">
                          <strong>Appointment Date</strong></td>
                      <td class="Info" colspan="1" style="height: 20px">
                          <strong>
                              <asp:TextBox ID="txtAppointmentdate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox><img
                                  alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAppointmentdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
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


    <%--Tele Status--%>
    <asp:Panel ID="pnlStatus" runat="server" Width="688px"> 
       <table style="width: 685px; height: 14px;">
             <tr>
                <td style="width: 51px;" class="reportTitleIncome">
                    <strong>Status</strong></td>
                <td style="width: 115px;" class="Info">
                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" Width="186px" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Pick Up</asp:ListItem>
                        <asp:ListItem Value="2">Appointment Rescheduled</asp:ListItem>
                        <asp:ListItem Value="3">Cancelled</asp:ListItem>
                        <asp:ListItem Value="4">Report Send</asp:ListItem>
                         <asp:ListItem Value="5">Visit Done</asp:ListItem>
                      
                    </asp:DropDownList></td>
            </tr>
        </table>
    </asp:Panel>
      






    <%--Pick Up panel--%>
    
    
        <%--Appo panel--%>
        <asp:Panel ID="pnlAppoFixed" runat="server" Width="700px">
            <table style="width: 685px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 20px; height: 18px;">
                        <strong>AppoDate</strong></td>
                    <td class="Info" style="width: 167px; height: 18px;">
                        <asp:TextBox ID="txtAppoDate" runat="server" Width="60px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAppoDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</td>
                </tr>
            </table>
        </asp:Panel>
   <%--Appo panel close--%>
   
   
   
       <%--Appo panel--%>
        <asp:Panel ID="Pnlvisitdone" runat="server" Width="700px">
            <table style="width: 685px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 23px; height: 18px;">
                        <strong>Visitdone Date</strong></td>
                    <td class="Info" style="width: 167px; height: 18px;">
                        <asp:TextBox ID="Txtvisitdone" runat="server" Width="60px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=Txtvisitdone.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</td>
                </tr>
            </table>
        </asp:Panel>
   <%--Appo panel close--%>
   
        <asp:Panel ID="pnlPickUp" runat="server" Width="700px">
            <table style="width: 685px; height: 14px;">
                <tr>
                    <td class="reportTitleIncome" style="width: 186px; height: 14px;">
                        <strong>Pick-Up Date</strong></td>
                    <td class="Info" colspan="3" style="width: 544px; height: 14px;">
                        <asp:TextBox ID="txtPickUpDate" runat="server" Width="60px" SkinID="txtSkin" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickUpDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />
                        [dd/mm/yyyy]</td>
                </tr>
            </table>
        </asp:Panel>
    <%--Pick Up panel close--%>
                        

   
      <%--Final Remark panel--%> 
    <asp:Panel ID="pnlFinalRemark" runat="server" Width="700px">                   
        <table style="width: 685px;">
            <tr>
                <td colspan="2" class="reportTitleIncome" style="width: 19px; height: 43px;">
                      <strong>Remark</strong></td>
                <td class="Info" colspan="2" style="width: 465px; height: 43px;">
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

