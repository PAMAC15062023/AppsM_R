<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="Productivity.aspx.cs" Inherits="HR_HR_Productivity" Title="Productivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript" >
function SearchMaster()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtSearchEmpMaster = document.getElementById("<%=txtSearchEmpMaster.ClientID%>");
    var ddlclustername = document.getElementById("<%=ddlclustername.ClientID%>");

    if(txtSearchEmpMaster.value == '')
    {
        ErrorMsg = "Please Enter Employee Code.";
        ReturnValue = false;
        txtSearchEmpMaster.focus();
    }
    if(ddlclustername.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster.";
        ReturnValue = false;
        ddlclustername.focus();
    }
       
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}

function SearchUpdate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtSearchEmpUpdate = document.getElementById("<%=txtSearchEmpUpdate.ClientID%>");
    var ddlclustername1 = document.getElementById("<%=ddlclustername1.ClientID%>");

    if(txtSearchEmpUpdate.value == '')
    {
        ErrorMsg = "Please Enter Employee Code to update OJT record.";
        ReturnValue = false;
        txtSearchEmpUpdate.focus();
    }
    if(ddlclustername1.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster.";
        ReturnValue = false;
        ddlclustername1.focus();
    }
       
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}

function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>");
    var txtEmpName = document.getElementById("<%=txtEmpName.ClientID%>");
    var txtUpdateCode = document.getElementById("<%=txtUpdateCode.ClientID%>");
    var txtMinProd = document.getElementById("<%=txtMinProd.ClientID%>");

    if(txtMinProd.value == '' || isNaN(txtMinProd.value))
    {
        ErrorMsg = "Please Enter Employee's valid Minimum Productivity.";
        ReturnValue = false;
        txtMinProd.focus();
    }
    if(txtUpdateCode.value == '')
    {
        ErrorMsg = "Please Enter Updating Authority Employee Code.";
        ReturnValue = false;
        txtUpdateCode.focus();
    }
    if(txtEmpName.value == '')
    {
        ErrorMsg = "Please Enter Employee Name.";
        ReturnValue = false;
        txtEmpName.focus();
    }
    if(txtEmpCode.value == '')
    {
        ErrorMsg = "Please Enter Employee Code.";
        ReturnValue = false;
        txtEmpCode.focus();
    }
   
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}


function ValidateRemove()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtEmpCode = document.getElementById("<%=txtEmpCode.ClientID%>");
    var txtEmpName = document.getElementById("<%=txtEmpName.ClientID%>");
    var txtUpdateCode = document.getElementById("<%=txtUpdateCode.ClientID%>");
    var txtMinProd = document.getElementById("<%=txtMinProd.ClientID%>");
    var txtRemark = document.getElementById("<%=txtRemark.ClientID%>");

    if(txtRemark.value == '')
    {
        ErrorMsg = "Please Enter the Reason for Removing.";
        ReturnValue = false;
        txtRemark.focus();
    }
    if(txtMinProd.value != '')
    {
        ErrorMsg = "Please Remove Employee's Minimum Productivity.";
        ReturnValue = false;
        txtMinProd.focus();
    }
    if(txtUpdateCode.value != '')
    {
        ErrorMsg = "Please Remove Updating Authority Employee Code.";
        ReturnValue = false;
        txtUpdateCode.focus();
    }
    if(txtEmpName.value == '')
    {
        ErrorMsg = "Please Enter Employee Name.";
        ReturnValue = false;
        txtEmpName.focus();
    }
    if(txtEmpCode.value == '')
    {
        ErrorMsg = "Please Enter Employee Code.";
        ReturnValue = false;
        txtEmpCode.focus();
    }
   
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}

function SearchBackUp()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtUpdateEmp = document.getElementById("<%=txtUpdateEmp.ClientID%>");
    var ddlclustername2 = document.getElementById("<%=ddlclustername2.ClientID%>");

    if(txtUpdateEmp.value == '')
    {
        ErrorMsg = "Please Enter Updating Authority Employee Code.";
        ReturnValue = false;
        txtUpdateEmp.focus();
    }
    if(ddlclustername2.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster.";
        ReturnValue = false;
        ddlclustername2.focus();
    }
       
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}


function ValidateBackUp()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var txtUpdate_EmpCode = document.getElementById("<%=txtUpdate_EmpCode.ClientID%>");
    var txtBackUp_EmpCode = document.getElementById("<%=txtBackUp_EmpCode.ClientID%>");

    if(txtBackUp_EmpCode.value == '')
    {
        ErrorMsg = "Please Enter BackUp Employee Code.";
        ReturnValue = false;
        txtBackUp_EmpCode.focus();
    }
    if(txtUpdate_EmpCode.value == '')
    {
        ErrorMsg = "Please Enter Updating Authority Employee Code.";
        ReturnValue = false;
        txtUpdate_EmpCode.focus();
    }
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;    
}


</script>

<asp:Panel ID="pnlMsg" runat="server" Width="900px">
    <table style="width: 900px;">
        <tr>
            <td colspan="4" class="tta" style="width: 892px">
                OJT  PRODUCTIVITY MASTER</td>
        </tr>
        <tr>
            <td colspan="4" style="width: 892px;">
                <asp:Label ID="lblMsg" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="877px" Height="20px"></asp:Label>
                <asp:Label ID="lblUpdate" runat="server" Font-Bold="True" ForeColor="Red" Height="20px" SkinID="lblError" Visible="False" Width="877px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlCategory" runat="server" Width="900px" Visible="false">
    <table style="width: 900px;">
        <tr>
            <td class="reportTitleIncome" >  
                <strong>Select Category</strong>
            </td>
            <td colspan="3" class="Info" style="width: 716px;" >                
                <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">--SELECT--</asp:ListItem>    
                    <asp:ListItem Value="1">New Entry in OJT</asp:ListItem>    
                    <asp:ListItem Value="2">Update Entry in OJT</asp:ListItem>    
                    <asp:ListItem Value="3">Add/Update BackUp</asp:ListItem>    
                </asp:DropDownList >
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlSearchMaster" runat="server" Width="900px" Visible="false">
    <table style="width: 900px;">
        <tr>
            <td style="width: 139px" class="reportTitleIncome">
                <strong>Cluster Name</strong></td>
            <td style="width: 120px" class="Info" colspan="3">
                <asp:DropDownList ID="ddlclustername" runat="server" SkinID="ddlSkin" Width="120px" AutoPostBack="true">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 157px;" class="reportTitleIncome">
                <strong>Search Employee from PAMAC</strong>
            </td>
            <td  class="Info" >
                <asp:TextBox ID="txtSearchEmpMaster" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td colspan="2" class="Info">
                <asp:Button ID="btnSearch1" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch1_Click" />
                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click1" />
            </td>
        </tr>
        <tr></tr>
        <tr>
            <td colspan="4">
                    <asp:GridView ID="GridSearchMaster" runat="server" AutoGenerateColumns="False" OnRowCommand="GridSearchMaster_RowCommand" OnRowEditing="GridSearchMaster_RowEditing" SkinID="gridviewSkin" Width="891px">
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditTele" runat="server"  CommandArgument='<%#Eval("Emp_Code")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                                                           
                            <asp:BoundField DataField="emp_code" HeaderText="Employee Code"/>
                            <asp:BoundField DataField="fullname" HeaderText="Name"/>
                            <asp:BoundField DataField="centre_name" HeaderText="Centre"/>
                            <asp:BoundField DataField="subcentrename" HeaderText="SubCentre"/>
                            <asp:BoundField DataField="DOJ" HeaderText="DOJ"/>
                            <asp:BoundField DataField="emp_type" HeaderText="Employee Type"/>
                            <asp:BoundField DataField="activity_name" HeaderText="Activity"/>
                            <asp:BoundField DataField="department" HeaderText="Department"/>
                            <asp:BoundField DataField="Designation" HeaderText="Designation"/>
                        </Columns>
                    </asp:GridView>
                &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlData" runat="server" Width="900px" Visible="false">
    <table style="width: 900px; height: 340px">
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Employee Code</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" Width="115px" ReadOnly="True"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Employee Name</strong></td>
            <td style="width: 266px" class="Info">
                <asp:TextBox ID="txtEmpName" runat="server" Width="200px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Centre</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtCentre" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Sub-Centre</strong></td>
            <td style="width: 266px" class="Info">
                <asp:TextBox ID="txtSubCentre" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>DOJ</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtDOJ" runat="server" Width="70px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox>&nbsp;
                <strong>[dd/MM/yyyy]</strong></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Employee Type</strong></td>
            <td style="width: 266px" class="Info">
                <asp:TextBox ID="txtEmpType" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Activity</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtActivity" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Department</strong></td>
            <td style="width: 266px" class="Info">
                <asp:TextBox ID="txtDepartment" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Designation</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtDesignation" runat="server" SkinID="txtSkin" Width="200px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Intro Training Required</strong></td>
            <td style="width: 266px" class="Info">
                <asp:DropDownList ID="ddlTraining" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Updating Authority<br />
                    (Employee Code)</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtUpdateCode" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td style="width: 161px" class="reportTitleIncome">
                <strong>Minimum Productivity</strong></td>
            <td style="width: 266px" class="Info">
                <asp:TextBox ID="txtMinProd" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox><br />
                <strong>[Only Integer Value]</strong></td>
        </tr>
        <tr>
            <td style="width: 225px" class="reportTitleIncome">
                <strong>Remark</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" Width="200px" TextMode="MultiLine"></asp:TextBox></td>
            <td colspan="2" class="Info">
                <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnSaveSkin" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel1" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel1_Click" />
                <asp:Button ID="btnRemove" runat="server" SkinID="btnSaveSkin" OnClick="btnRemove_Click" Text="Remove" /></td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlSearchUpdate" runat="server" Width="900px" Visible="false">
    <table style="width: 900px;">
        <tr>
            <td style="width: 139px; height: 32px;" class="reportTitleIncome">
                <strong>Cluster Name</strong></td>
            <td style="width: 120px; height: 32px;" class="Info" colspan="3">
                <asp:DropDownList ID="ddlclustername1" runat="server" SkinID="ddlSkin" Width="120px" AutoPostBack="true">
                </asp:DropDownList></td>
        </tr>        
        <tr>
            <td style="width: 157px;" class="reportTitleIncome">
                <strong>Search Employee</strong>
            </td>
            <td  class="Info" >
                <asp:TextBox ID="txtSearchEmpUpdate" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td colspan="2" class="Info">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnSearchSkin" />
                <asp:Button ID="btnCancel2" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                    <asp:GridView ID="GridSearchUpdate" runat="server" AutoGenerateColumns="False" OnRowCommand="GridSearchUpdate_RowCommand" OnRowEditing="GridSearchUpdate_RowEditing" SkinID="gridviewSkin">
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditTele" runat="server"  CommandArgument='<%#Eval("Emp_Code")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>
                                                           
                            <asp:BoundField DataField="Emp_Code" HeaderText="Employee Code"/>
                            <asp:BoundField DataField="Emp_Name" HeaderText="Name"/>
                            <asp:BoundField DataField="Centre" HeaderText="Centre"/>
                            <asp:BoundField DataField="SubCentre" HeaderText="SubCentre"/>
                            <asp:BoundField DataField="DOJ" HeaderText="DOJ"/>
                            <asp:BoundField DataField="Category" HeaderText="Employee Type"/>
                            <asp:BoundField DataField="Activity" HeaderText="Activity"/>
                            <asp:BoundField DataField="Department" HeaderText="Department"/>
                            <asp:BoundField DataField="Designation" HeaderText="Designation"/>
                            <asp:BoundField DataField="Intro_Training_Required" HeaderText="Intro Training Required"/>
                            <asp:BoundField DataField="Update_Emp_Name" HeaderText="Updating Authority"/>
                            <asp:BoundField DataField="Min_Productivity" HeaderText="Minimum Productivity"/>
                        </Columns>
                    </asp:GridView>
                &nbsp;
                <asp:HiddenField ID="HDNEmpCode1" runat="server" />
                <asp:HiddenField ID="HDNID" runat="server" />
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>


<asp:Panel ID="pnlBackupSearch" runat="server" Width="900px" Visible="false">
    <table style="width: 900px;">
        <tr>
            <td style="width: 139px; height: 32px;" class="reportTitleIncome">
                <strong>Cluster Name</strong></td>
            <td style="width: 120px; height: 32px;" class="Info" colspan="3">
                <asp:DropDownList ID="ddlclustername2" runat="server" SkinID="ddlSkin" Width="120px" AutoPostBack="true">
                </asp:DropDownList></td>
        </tr>        
        <tr>
            <td style="width: 157px;" class="reportTitleIncome">
                <strong>Search Employee</strong>
            </td>
            <td  class="Info" >
                <asp:TextBox ID="txtUpdateEmp" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td colspan="2" class="Info">
                <asp:Button ID="btnSearch2" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch2_Click" />
                <asp:Button ID="btnCancel3" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel3_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                    <asp:GridView ID="GridBackUp" runat="server" AutoGenerateColumns="False" OnRowCommand="GridBackUp_RowCommand" OnRowEditing="GridBackUp_RowEditing" SkinID="gridviewSkin" Width="888px">
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                           <ItemTemplate>
                                <asp:LinkButton ID="lnkEditTele" runat="server"  CommandArgument='<%#Eval("Update_EmpCode")%>'
                                 CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                           </ItemTemplate>
                           </asp:TemplateField>                                                           
                            <asp:BoundField DataField="Update_EmpCode" HeaderText="Updating Authority"/>
                            <asp:BoundField DataField="Update_EmpName" HeaderText="Updating Authority Name"/>
                            <asp:BoundField DataField="BackUp_EmpCode" HeaderText="BackUp"/>
                            <asp:BoundField DataField="BackUp_EmpName" HeaderText="BackUp Name"/>
                        </Columns>
                    </asp:GridView>
                &nbsp;
                <asp:HiddenField ID="HdnUA" runat="server" />
                <asp:HiddenField ID="HdnUA_ID" runat="server" />
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlBackupSave" runat="server" Width="900px" Visible="false">
    <table style="width: 900px;">
        <tr>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>Updating Authority Employee Code</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtUpdate_EmpCode" runat="server" SkinID="txtSkin" Width="115px"></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
            <td style="width: 148px" class="reportTitleIncome">
                <strong>BackUp Employee Code</strong></td>
            <td style="width: 225px" class="Info">
                <asp:TextBox ID="txtBackUp_EmpCode" runat="server" SkinID="txtSkin" Width="115px" ></asp:TextBox>
                <strong>Eg: P-10101</strong></td>
        </tr>
        <tr>
            <td class="Info" style="width: 148px" colspan="4">
                <asp:Button ID="btnSaveBackUp" runat="server" Text="Save" SkinID="btnSaveSkin" OnClick="btnSaveBackUp_Click" />
                <asp:Button ID="btnCancel4" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel4_Click" /></td>
        </tr>
    </table>
</asp:Panel>



</asp:Content>

