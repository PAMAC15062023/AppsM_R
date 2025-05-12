<%@ Page Language="C#" MasterPageFile="~/Admin/Client Operational Call or  Visit Tracker/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Admin_Client_Operational_Call_or__Visit_Tracker_Update" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>


<script language="javascript" type="text/javascript">

function Pro_selectRow(rowno, id)
     {     
       rowno = (parseInt(rowno) + 1);             // Increament By 1
        // Variable Declaration 
         
        var GV_Visit_Call_Edit= document.getElementById("<%=GV_Visit_Call_Edit.ClientID%>");  //Imp
        var HidnVisit_call_No = document.getElementById("<%=HidnVisit_call_No.ClientID%>");       //Imp
        var ddlbranch= document.getElementById("<%=ddlbranch.ClientID%>");
        var ddlvertical= document.getElementById("<%=ddlvertical.ClientID%>");        
        var txtdate = document.getElementById("<%=txtdate.ClientID%>");
          
        var ddlvisitcall= document.getElementById("<%=ddlvisitcall.ClientID%>");         
        var ddlclient= document.getElementById("<%=ddlclient.ClientID%>");
        var txtname= document.getElementById("<%=txtname.ClientID%>");        
        var txtTime= document.getElementById("<%=txtTime.ClientID%>");  
        var ddlActivity= document.getElementById("<%=ddlActivity.ClientID%>");  
        var txtpoint1= document.getElementById("<%=txtpoint1.ClientID%>");  
        var ddlActivity= document.getElementById("<%=ddlActivity.ClientID%>");  
        var txtstatuspostn= document.getElementById("<%=txtstatuspostn.ClientID%>");  
        var txtdatecomm= document.getElementById("<%=txtdatecomm.ClientID%>");  
        var txtclosedate= document.getElementById("<%=txtclosedate.ClientID%>");  
        var ddlactnreq= document.getElementById("<%=ddlactnreq.ClientID%>");  
        var HdnUID= document.getElementById("<%=HdnUID.ClientID%>");  
        
        // Assign Value To Variables 
        
        HidnVisit_call_No.value=GV_Visit_Call_Edit.rows[rowno].cells[0].innerText;
        
        ddlbranch.value = GV_Visit_Call_Edit.rows[rowno].cells[1].innerText;
        ddlvertical.value = GV_Visit_Call_Edit.rows[rowno].cells[15].innerText;
        txtdate.value = GV_Visit_Call_Edit.rows[rowno].cells[3].innerText;
        ddlvisitcall.value=GV_Visit_Call_Edit.rows[rowno].cells[4].innerText;
        ddlclient.value = GV_Visit_Call_Edit.rows[rowno].cells[14].innerText;
        ddlActivity.value = GV_Visit_Call_Edit.rows[rowno].cells[16].innerText;
        txtname.value=GV_Visit_Call_Edit.rows[rowno].cells[7].innerText;
        txtTime.value = GV_Visit_Call_Edit.rows[rowno].cells[8].innerText;    
        txtpoint1.value = GV_Visit_Call_Edit.rows[rowno].cells[9].innerText;
        ddlactnreq.value = GV_Visit_Call_Edit.rows[rowno].cells[10].innerText;
        txtdatecomm.value = GV_Visit_Call_Edit.rows[rowno].cells[11].innerText;
        txtstatuspostn.value = GV_Visit_Call_Edit.rows[rowno].cells[12].innerText;
        txtclosedate.value= GV_Visit_Call_Edit.rows[rowno].cells[13].innerText;
        HdnUID.value=GV_Visit_Call_Edit.rows[rowno].cells[17].innerText;
        
        var i = 0;                          
        for (i = 0; i <= GV_Visit_Call_Edit.rows.length - 1; i++)
         {
             if (i != 0) 
            {
                if (HdnUID.value == GV_Visit_Call_Edit.rows[i].cells[17].innerText) 
                {
                    GV_Visit_Call_Edit.rows[i].style.backgroundColor = "SkyBlue";
                }
                else 
                {
                    GV_Visit_Call_Edit.rows[i].style.backgroundColor = "LightYellow";
                }
            }
         }
      }
        
 
</script> 

<table style="width: 160px">
    
    <tr>
            <td class="tta" colspan="8" style="height: 19px; width: 97%;">
                <span style="font-size: 10pt">Client Operational Call / Visit Tracker </span></td>
        </tr>
        
        <tr>
            <td colspan="7">
               <asp:Panel ID="PnlInsert" runat="server">
                    <table style="width: 1004px">
                    <tr>
            <td style="height: 21px;" colspan="6">
              <span>
              <asp:Label ID="lblmessage" runat="server" SkinID="lblErrorMsg" Font-Bold="True" ForeColor="Red"></asp:Label>
              </span>
              </td>
        </tr>
                    </table>
                  <%-- <asp:Panel ID="Panel1" runat="server">--%>
                       <table style="width: 1030px; height: 275px;">
                           <tr>
                            <td class="reportTitleIncome" style="width: 195px">
                                Date</td>
                            <td class="Info" style="width: 205px">
                                <asp:TextBox ID="txtdate" runat="server" Width="100px" SkinID="txtSkin" ValidationGroup="GRPADD" TabIndex="1" Enabled="False" Font-Bold="False" ForeColor="White"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                            <td class="reportTitleIncome" style="width: 173px">
                                SubCentre(Branch)</td>
                            <td class="Info" style="width: 231px">
                                <asp:DropDownList ID="ddlbranch" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="GRPADD" Enabled="False" Font-Bold="False">
                                </asp:DropDownList></td>
                            <td>
                                </td>
                            <td>
                                </td>
                           </tr>
                           <tr>
                            <td style="width: 195px;" class="reportTitleIncome">
                                Client</td>
                            <td style="width: 205px;" class="Info">
                                <asp:DropDownList ID="ddlclient" runat="server" Width="123px" SkinID="ddlSkin" ValidationGroup="GRPADD" TabIndex="2" Enabled="False" Font-Bold="False">
                                </asp:DropDownList></td>
                            <td style="width: 173px;" class="reportTitleIncome">
                                Visit / Call</td>
                            <td style="width: 231px;" class="Info">
                                <asp:DropDownList ID="ddlvisitcall" runat="server" Width="123px" SkinID="ddlSkin" ValidationGroup="GRPADD" TabIndex="3" Enabled="False" Font-Bold="False">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="Visit">Visit</asp:ListItem>
                                    <asp:ListItem>Call</asp:ListItem>
                                    <asp:ListItem>Meeting</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                </td>
                            <td style="width: 43px;">
                                </td>
                           </tr>
                           <tr>
                            <td style="height: 20px; width: 195px;" class="reportTitleIncome">
                                Name of the officials</td>
                            <td style="height: 20px; width: 205px;" class="Info">
                                <asp:TextBox ID="txtname" runat="server" Width="123px" SkinID="txtSkin" ValidationGroup="GRPADD" TabIndex="4" Enabled="False" Font-Bold="False"></asp:TextBox></td>
                            <td style="height: 20px; width: 173px;" class="reportTitleIncome">
                                Time Spent(hh:mm)</td>
                            <td style="height: 20px; width: 231px;" class="Info">
                                <asp:TextBox ID="txtTime" runat="server" Width="123px" SkinID="txtSkin" ValidationGroup="GRPADD" TabIndex="5" Enabled="False" Font-Bold="False" ></asp:TextBox></td>
                            <td style="height: 20px;">
                                </td>
                            <td style="height: 20px; width: 43px;">
                                </td>
                           </tr>
                           <tr>
                            <td class="reportTitleIncome" style="height: 21px; width: 195px;">
                                Vertical</td>
                            <td class="Info" style="height: 21px; width: 205px;">
                                <asp:DropDownList ID="ddlvertical" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="GRPADD" TabIndex="6" Enabled="False" Font-Bold="False">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem> 

                    <asp:ListItem>PCRU</asp:ListItem>
                                                 
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="height: 21px; width: 173px;">
                                Activity</td>
                            <td class="Info" style="height: 21px; width: 231px;">
                                <asp:DropDownList ID="ddlActivity" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="GRPADD" TabIndex="7" Enabled="False" Font-Bold="False">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Income Dox Verification</asp:ListItem>
                                    <asp:ListItem>CPV</asp:ListItem>
                                    <asp:ListItem>KYC</asp:ListItem>
                                    <asp:ListItem>File Processing</asp:ListItem>
                                    <asp:ListItem>PD</asp:ListItem>
                                    <asp:ListItem>EBC</asp:ListItem>
                                    <asp:ListItem>Mystery Shopping</asp:ListItem>
                                    <asp:ListItem>Recon</asp:ListItem>
                                    <asp:ListItem>Cheque Processing</asp:ListItem>
                                    <asp:ListItem>Document Collection</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 21px;">
                                </td>
                            <td style="height: 21px; width: 43px;">
                                </td>
                           </tr>
                           <tr>
                            <td colspan="6" style="height: 138px">
                                <asp:Panel ID="pnlRemark" runat="server">
                                <table style="width: 846px">
                                    <tr>
                                        <td style="width: 44px; height: 15px" class="reportTitleIncome">
                                            &nbsp;Point &nbsp;Discussed</td>
                                        <td style="width: 87px; height: 15px" class="reportTitleIncome">
                                            &nbsp;Action Required
                                        </td>
                                        <td style="width: 125px; height: 15px" class="reportTitleIncome">
                                            &nbsp;Date Committed
                                        </td>
                                        <td style="width: 88px; height: 15px" class="reportTitleIncome">
                                            &nbsp;Status Postn Commitment</td>
                                        <td style="width: 103px; height: 15px" class="reportTitleIncome">
                                            Date Close</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 44px;" class="Info">
                                            <asp:TextBox ID="txtpoint1" runat="server" SkinID="txtSkin" Width="151px" ValidationGroup="GRPADD" TextMode="MultiLine" TabIndex="8" Height="35px" Font-Bold="False"></asp:TextBox></td>
                                        <td style="width: 87px;" class="Info">
                                            <asp:DropDownList ID="ddlactnreq" runat="server" Width="100px" SkinID="ddlSkin" ValidationGroup="GRPADD" TabIndex="9"  AutoPostBack="True" Font-Bold="False">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Sp_Client_Call_Remark_inser">Yes</asp:ListItem>
                                                <asp:ListItem Value="Sp_Client_Call_Remark_inser_ActionNO">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 125px;" class="Info">
                                            <asp:TextBox ID="txtdatecomm" runat="server" SkinID="txtSkin"
                                                Width="70px" TabIndex="10" ValidationGroup="GRPADD" Font-Bold="False"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdatecomm.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                                        <td style="width: 88px;" class="Info">
                                            <asp:TextBox ID="txtstatuspostn" runat="server" SkinID="txtSkin" Width="100px" ValidationGroup="GRPADD" TabIndex="11" Font-Bold="False"></asp:TextBox></td>
                                        <td style="width: 103px;" class="Info">
                                <asp:TextBox ID="txtclosedate" runat="server" SkinID="txtSkin" Width="70px" ValidationGroup="GRPADD" TabIndex="12" Font-Bold="False"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtclosedate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                &nbsp;<asp:Button ID="BtnUpdate" runat="server" SkinID="btnUploadSkin" Text="UPDATE" Width="100px" ValidationGroup="GRPADD" TabIndex="17" Height="24px" OnClick="BtnUpdate_Click"  />&nbsp;
                                <asp:Button
                                    ID="BtnCancel" runat="server" Height="24px" SkinID="btnCancelSkin"
                                    Text="CANCEL" Width="100px" OnClick="BtnCancel_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate"
                                    ErrorMessage="Please Insert Date" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Rfvbranch" runat="server" ControlToValidate="ddlbranch"
                                    ErrorMessage="Please Select Branch" ForeColor="White" InitialValue="NA" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RfvDDlclint" runat="server" ControlToValidate="ddlclient"
                                    ErrorMessage="Please Select Client Name" ForeColor="White" InitialValue="0" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Rfvvistcal" runat="server" ControlToValidate="ddlvisitcall"
                                    ErrorMessage="Please Select Visit or Call" ForeColor="White" InitialValue="0"
                                    ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RfvName" runat="server" ControlToValidate="txtname"
                                    ErrorMessage="Please Insert Name Of Officiels" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RfvTimespent" runat="server" ControlToValidate="txtTime"
                                    ErrorMessage="Please Select TimeSpent" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RfvVertical" runat="server" ControlToValidate="ddlvertical"
                                    ErrorMessage="Please Select Vertical Name" ForeColor="White" InitialValue="0"
                                    ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RfvActivity" runat="server" ControlToValidate="ddlActivity"
                                    ErrorMessage="Please Select Activity Name" ForeColor="White" InitialValue="0"
                                    ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CMPVCloseDate" runat="server" ControlToCompare="txtdatecomm"
                                    ControlToValidate="txtclosedate" ErrorMessage="Close Date Should Be Greater Than Committed Date"
                                    ForeColor="White" Height="5px" Operator="GreaterThan" Type="Date" ValidationGroup="GRPADD"
                                    Width="1px" Enabled="False">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstatuspostn"
                                    ErrorMessage="Please Enter Status Position Commitment" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtclosedate"
                                    ErrorMessage="Please Enter Closing Date" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVactionReq" runat="server" ControlToValidate="ddlactnreq"
                                    ErrorMessage="Please Select Action Required" ForeColor="White" InitialValue="0"
                                    ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVpntdis" runat="server" ControlToValidate="txtpoint1"
                                    ErrorMessage="Please Enter Point Discussed" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdatecomm"
                                    ErrorMessage="Please Enter Date Committed" ForeColor="White" ValidationGroup="GRPADD">*</asp:RequiredFieldValidator></td>
                           </tr>
                       </table>
                   </asp:Panel>
          <%--      </asp:Panel>--%>
            </td>
        </tr>
        <tr>
            <td colspan="7">
              <asp:Panel ID="PnlView" runat="server" Width="880px">
                    <table style="width: 941px">
                        <tr>
                            <td style="width: 66px; height: 21px" class="reportTitleIncome">
                                Location</td>
                            <td style="width: 79px; height: 21px" class="Info">
                                <asp:DropDownList ID="DDlLocsearch" runat="server" SkinID="ddlSkin" Width="123px" AutoPostBack="True" OnSelectedIndexChanged="DDlLocsearch_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="width: 103px; height: 21px" class="reportTitleIncome">
                                SubCentre(Branch)</td>
                            <td style="width: 116px; height: 21px" class="Info">
                                <asp:DropDownList ID="DDlBranchsearch" runat="server" SkinID="ddlSkin" Width="123px">
                                </asp:DropDownList></td>
                            <td style="width: 70px; height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td class="reportTitleIncome" style="width: 66px; height: 21px">
                                Client Name</td>
                            <td class="Info" style="width: 79px; height: 21px">
                                <asp:DropDownList ID="DdlSearchClient" runat="server" SkinID="ddlSkin" Width="123px">
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 103px; height: 21px">
                                Vertical</td>
                            <td class="Info" style="width: 116px; height: 21px">
                                <asp:DropDownList ID="DDLverticalsearch" runat="server" SkinID="ddlSkin" Width="123px" ValidationGroup="GRPADD" TabIndex="6">
                                    <asp:ListItem Value="ALL">--ALL--</asp:ListItem>
                                    <asp:ListItem>PCPV</asp:ListItem>
                                    <asp:ListItem>PCPA</asp:ListItem>
                                    <asp:ListItem>PTPU</asp:ListItem>
                                    <asp:ListItem>PDCR</asp:ListItem>
                                    <asp:ListItem>PFRC</asp:ListItem>
                                    <asp:ListItem>PCRU</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 70px; height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="height: 9px">
                                &nbsp;<asp:Button ID="BtnSearch" runat="server" SkinID="btnSearchSkin" Text="SEARCH" Width="100px" Height="24px" OnClick="BtnSearch_Click" />&nbsp;
                                <asp:Button ID="BtnReset" runat="server" SkinID="btnResetSkin" Text="RESET" Width="100px" Height="24px" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="#C00000" SkinID="lblErrorMsg"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 152px">
              <asp:Panel ID="PnlGrid" runat="server" Height="280px" Width="850px" ScrollBars="Both">
                    <asp:GridView ID="GV_Visit_Call_Edit" runat="server" SkinID="gridviewNoSort" Width="835px" OnRowCommand="GV_Visit_Call_Edit_RowCommand" >
                        <Columns>
                            <asp:TemplateField HeaderText="EDIT">
                                <ItemTemplate>
                             
                                       <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("UID") %>'
                                CommandName="Edit1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                       
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="GRPADD" />
            </td>
        </tr>
   
        <tr>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HidnVisit_call_No" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="HDNUPDATE" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 44px">
                <asp:Label ID="lblUID" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"
                    Width="46px"></asp:Label></td>
        </tr>
    </table>

</asp:Content>