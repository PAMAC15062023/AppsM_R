<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="CaseAssign.aspx.cs" Inherits="CPA_PD_CaseAssign" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>



 <%-- <asp:Panel ID="pnlCategory" runat="server"  Width="149px">--%>
 
        <table style="width: 900px">
        
           <tr>
        <td class="tta" colspan="8" style="height: 4px; width: 690px;">
            <span style="font-size: 10pt">CASE ASSIGNMENT</span></td>   </tr>
             <tr>
                 <td colspan="7" style="height: 1px; width: 690px;">
                    <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
             </tr>

            <tr>
                <td style="width: 164px; height: 16px;" class="reportTitleIncome">
                    <strong>&nbsp;Cluster Name</strong></td>
                <td style="width: 92px; height: 16px;" class="Info">
                    <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="120px">
                    </asp:DropDownList></td>
                <td style="width: 193px; height: 16px" class="reportTitleIncome">
                    <strong>
                    Centre</strong></td>
                <td style="width: 123px; height: 16px;" class="Info">
                    <asp:DropDownList ID="ddlcenter" runat="server" SkinID="ddlSkin" Width="120px">
                    </asp:DropDownList></td>
                <td style="width: 132px; height: 16px;" class="reportTitleIncome">
                    </td>
                <td class="Info" colspan="2" rowspan="3">
                    <asp:Button ID="btnshowdata" runat="server"  Text="Show Data" Width="95px" OnClick="btnshowdata_Click" SkinID="btnSearchSkin" /></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 164px; height: 16px">
                    <strong>Case Assign To</strong></td>
                <td class="Info" style="height: 16px" colspan="4">
                    <asp:DropDownList ID="ddlCase" runat="server" SkinID="ddlSkin" Width="163px" >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="PD_RecordToAssign_TELE">Tele Caller</asp:ListItem>
                       <asp:ListItem Value="PD_RecordToAssign_FE">FE Caller</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <%--NEW ADDED--%>
            <tr>
                <td class="reportTitleIncome">
                    <strong>From Date</strong></td>
                <td class="Info">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.png" /></td>
                <td class="reportTitleIncome">
                    <strong>To Date</strong></td>
                <td class="Info">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="70px"></asp:TextBox>
                    <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.png" /></td>
                <td class="reportTitleIncome"></td>
            </tr>
            <%--END--%>
            
            <tr>
                <td colspan="7" style="height: 16px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 164px; height: 16px">
                    <strong>
                    FE / Telecaller Name</strong></td>
                <td class="Info" style="width: 92px; height: 16px">
                    <asp:DropDownList ID="ddlFENAME" runat="server" Width="176px"  ValidationGroup="grValidateDate" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 193px; height: 16px">
                </td>
                <td class="Info" style="width: 123px; height: 16px">
                </td>
                <td class="reportTitleIncome" style="width: 132px; height: 16px">
                </td>
                <td class="Info" style="height: 16px" colspan="2">
                    <asp:Button ID="btnAssign" runat="server" Text="FE/TeleCaller Assign" Width="172px" ValidationGroup="grValidateDate"  OnClick="btnAssign_Click" SkinID="btnAssingSkin" /></td>
            </tr>

            <tr>
            </tr>
            <tr>
            </tr>
        </table>
        <div style="overflow: scroll; width: 900px; height: 350px">
            <asp:GridView ID="Grvcasedata" runat="server" SkinID="gridviewSkin" Width="761px" Height="141px" 
                   AutoGenerateColumns="False" AllowSorting="true" OnSorting="Grvcasedata_Sorting" >
            <Columns>
              <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:CheckBox ID="chkCaseId" runat="server" /><asp:HiddenField ID="hidCaseId" runat="server"
                            Value='<%# DataBinder.Eval(Container.DataItem, "case_id") %>' />
                </ItemTemplate>
                <HeaderTemplate>
                    <asp:CheckBox ID="ChkAll" runat="server"   onClick="javascript:SelectAllCheckboxes(this);" /><strong>All</strong>
                </HeaderTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="case_id" HeaderText="Case ID"  SortExpression="case_id"/>
                <asp:BoundField DataField="File_Ref_No" HeaderText="File_Ref_No"  />
                <asp:BoundField DataField="Customer_Name" HeaderText="Customer_Name" />
                <asp:BoundField DataField="Company_Name" HeaderText="Company_Name"  />
                <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact_Person_Name"  />
                <asp:BoundField DataField="Contact_Number" HeaderText="Contact_Number"  />
                <asp:BoundField DataField="pamac_location" HeaderText="pamac_location" />
                <asp:BoundField DataField="Address" HeaderText="Address"  />
                <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation_Date"  />
           <%--    <asp:BoundField DataField="Callback Date" HeaderText="Callback_Date"  />--%>
            <asp:BoundField DataField="APPOINTMENT_DATE" HeaderText="APPOINTMENT_DATE"  /> 
           <%--     <asp:BoundField DataField="Final_Remark" HeaderText="Final_Remark"  />
--%>
              
    
        
        
        
        
<%--End by sanket--%>       
               
            </Columns>
            </asp:GridView>
        </div>
    <br />
    <asp:HiddenField ID="Hdnmaster" runat="server" />
    &nbsp;&nbsp;
<%--    </asp:Panel>--%>

          <%--added by sanket on 13/02/2014--%>         
        <asp:RequiredFieldValidator ID="rfvAreaname" runat="server"
             ErrorMessage="Please Select FE/Telecaller Name." ControlToValidate="ddlFENAME"
            InitialValue="0" Display="None" ValidationGroup="grValidateDate"  >
        </asp:RequiredFieldValidator>
        
                 
         <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" /> 
        

</asp:Content>

