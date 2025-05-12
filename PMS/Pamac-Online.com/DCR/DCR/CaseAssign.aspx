<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="CaseAssign.aspx.cs" Inherits="DCR_DCR_CaseAssign" Title="Untitled Page" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function SelectAllCheckboxes(spanChk)
 {
    debugger;
    // Added as ASPX uses SPAN for checkbox
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
    xState = theBox.checked;
    elm = theBox.form.elements;

    for (i = 0; i < elm.length; i++)
        if (elm[i].type == "checkbox" &&
                elm[i].id != theBox.id) {
            if (elm[i].checked != xState)
                elm[i].click();
        }
}
            
            
function validate()
{
    var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
    var ErrorMsg = "";
    var ReturnValue = true;
    var ddlCase = document.getElementById("<%=ddlCase.ClientID%>");

    if(ddlCase.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Case Type to continue.";
        ReturnValue = false;
        ddlCaseType.focus();
    }
    window.scrollTo(0,0);
    lblMsgXls.innerText = ErrorMsg;
    return ReturnValue;
}
    
    
function validateall()
{
    var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
    var ErrorMsg = "";
    var ReturnValue = true;
    var ddlCase = document.getElementById("<%=ddlCase.ClientID%>");
    var ddlcenter = document.getElementById("<%=ddlcenter.ClientID%>");
    var ddlverificationtype = document.getElementById("<%=ddlverificationtype.ClientID%>");
    var ddlFENAME = document.getElementById("<%=ddlFENAME.ClientID%>");
    var ddlclustername = document.getElementById("<%=ddlclustername.ClientID%>");

    if(ddlFENAME.selectedIndex == 0)
    {
        ErrorMsg = "Please Select FE Name/Tele Caller Name to continue.";
        ReturnValue = false;
        ddlFENAME.focus();
    }

    if(ddlverificationtype.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Verification Type to continue.";
        ReturnValue = false;
        ddlverificationtype.focus();
    }  

    if(ddlCase.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Case Type.";
        ReturnValue = false;
        ddlCase.focus();
    }
    
    if(ddlcenter.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Center.";
        ReturnValue = false;
        ddlcenter.focus();
    }
    
    if(ddlclustername.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster Name";
        ReturnValue = false;
        ddlclustername.focus();
    }
         
    window.scrollTo(0,0);
    lblMsgXls.innerText = ErrorMsg;
    return ReturnValue;
}


function validate1()
{
    var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
    var ErrorMsg = "";
    var ReturnValue = true;
    var ddlCase = document.getElementById("<%=ddlCase.ClientID%>");
    var ddlcenter = document.getElementById("<%=ddlcenter.ClientID%>");
    var ddlverificationtype = document.getElementById("<%=ddlverificationtype.ClientID%>");
    var ddlclustername = document.getElementById("<%=ddlclustername.ClientID%>");
    var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
    var txtToDate = document.getElementById("<%=txtToDate.ClientID%>");
    
    
    if(ddlverificationtype.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Verification Type to continue.";
        ReturnValue = false;
        ddlverificationtype.focus();
    }

    if(ddlCase.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Case Type.";
        ReturnValue = false;
        ddlCase.focus();
    }
    
//    NEW Added
    if(ddlCase.selectedIndex == 1)
    {
        if(txtToDate.value == '')
        {
            ErrorMsg = "Please Select To Date.";
            ReturnValue = false;
            txtToDate.focus();
        }
        if(txtFromDate.value == '')
        {
            ErrorMsg = "Please Select From Date.";
            ReturnValue = false;
            txtFromDate.focus();
        }
    }
//    END

    if(ddlclustername.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster Name";
        ReturnValue = false;
        ddlclustername.focus();
    }
         
    window.scrollTo(0,0);
    lblMsgXls.innerText = ErrorMsg;
    return ReturnValue;
}
</script>


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
                <td class="Info" style="width: 92px; height: 16px">
                    <asp:DropDownList ID="ddlCase" runat="server" SkinID="ddlSkin" Width="120px"  >
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="DCR_RecordToAssign122">Field Executive</asp:ListItem>
                        <asp:ListItem Value="DCR_RecordToAssign_TELE123">Tele Caller</asp:ListItem>
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 193px; height: 16px">
                    <strong>Verification Type</strong></td>
                <td class="Info" style="width: 123px; height: 16px">
                    <asp:DropDownList ID="ddlverificationtype" runat="server" 
                        SkinID="ddlSkin" Width="120px" >
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 132px; height: 16px">
                </td>
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
                    <asp:DropDownList ID="ddlFENAME" runat="server" Width="176px" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 193px; height: 16px">
                </td>
                <td class="Info" style="width: 123px; height: 16px">
                </td>
                <td class="reportTitleIncome" style="width: 132px; height: 16px">
                </td>
                <td class="Info" style="height: 16px" colspan="2">
                    <asp:Button ID="btnAssign" runat="server" Text="FE Assign" Width="172px" OnClick="btnAssign_Click" SkinID="btnAssingSkin" /></td>
            </tr>

            <tr>
            </tr>
            <tr>
            </tr>
        </table>
        <div style="overflow: scroll; width: 900px; height: 350px">
            <asp:GridView ID="Grvcasedata" runat="server" SkinID="gridviewSkin" Width="761px" Height="141px" 
                   AutoGenerateColumns="False" AllowSorting="true" OnSorting="Grvcasedata_Sorting">
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
                <asp:BoundField DataField="Verification_type_id" HeaderText="Verification Type"  SortExpression="Verification_type_id"/>
                <asp:BoundField DataField="LEAD_ID" HeaderText="Lead ID"  SortExpression="LEAD_ID"/>
                <asp:BoundField DataField="Policy_No" HeaderText="Policy No."  SortExpression="Policy_No"/>
                <asp:BoundField DataField="Call_Center_Group" HeaderText="Call Center Group"  SortExpression="Call_Center_Group"/>
                <asp:BoundField DataField="Team_Leader" HeaderText="Team Leader"  SortExpression="Team_Leader"/>
                <asp:BoundField DataField="CENTRE_name" HeaderText="Centre"  SortExpression="CENTRE_name"/>
                <asp:BoundField DataField="CUST_FULLNAME" HeaderText="Customer Name"  SortExpression="CUST_FULLNAME"/>
                <asp:BoundField DataField="CUST_ADD_LINE_1" HeaderText="Address"  SortExpression="CUST_ADD_LINE_1"/>
                <asp:BoundField DataField="CUST_PIN" HeaderText="PIN Code"  SortExpression="CUST_PIN"/>
                <asp:BoundField DataField="CUST_CONTACT_NO" HeaderText="Contact No."  SortExpression="CUST_CONTACT_NO"/>
                <asp:BoundField DataField="INITIATION_DATE" HeaderText="Initiation Date"  SortExpression="INITIATION_DATE"/>
                <asp:BoundField DataField="UPLOAD_DATE" HeaderText="Upload Date"  SortExpression="UPLOAD_DATE"/>
                <asp:BoundField DataField="APPOINTMENT_DATE" HeaderText="Appointment Date"  SortExpression="APPOINTMENT_DATE"/>
                <asp:BoundField DataField="APPOINTMENT_TIME" HeaderText="Appointment Time"  SortExpression="APPOINTMENT_TIME"/>
                <asp:BoundField DataField="AMOUNT" HeaderText="Amount"  SortExpression="AMOUNT"/>
                <asp:BoundField DataField="REMARK" HeaderText="Remark"  SortExpression="REMARK"/>
                <asp:BoundField DataField="LEAD_TYPE" HeaderText="Lead Type"  SortExpression="LEAD_TYPE"/>
               
            </Columns>
            </asp:GridView>
        </div>
    <br />
    <asp:HiddenField ID="Hdnmaster" runat="server" />
    &nbsp;&nbsp;
<%--    </asp:Panel>--%>

</asp:Content>

