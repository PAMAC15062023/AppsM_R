<%@ Page Title="" Language="C#" MasterPageFile="~/RESDOT_Master.Master" AutoEventWireup="true" CodeBehind="RESDOT_UserMaster.aspx.cs" Inherits="RESDOT.RESDOT_UserMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script language="javascript" type="text/javascript"> </script>

     <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;User Master</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Employee Code</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtLoginName" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="7" OnTextChanged="txtLoginName_TextChanged" AutoPostBack="true"></asp:TextBox></td>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Employee Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtUserName" runat="server" BorderWidth="1px" MaxLength="50" ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 26px">&nbsp;Password</td>
            <td style="width: 100px; height: 26px">
                <asp:TextBox ID="txtPassword" runat="server" BorderWidth="1px" ValidationGroup="BranchENtry" MaxLength="100" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
                <asp:LinkButton ID="lnkAutoGenetae" runat="server" ToolTip="Click to Auto Generate" OnClick="lnkAutoGenetae_Click"> Auto Generate</asp:LinkButton></td>
            <td style="width: 100px; height: 26px"></td>
            <td style="width: 100px; height: 26px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px; height: 22px;">&nbsp;Is Active</td>
            <td style="width: 100px; height: 22px;">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
            <td style="width: 100px; height: 22px;"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Role Id</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlRoleId" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry" Width="170px">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save"
                ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click"
                    ValidationGroup="BranchENtry" Width="67px" Font-Bold="False" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="False" OnClick="btnCancel_Click" />&nbsp;
                <asp:Label ID="lblWait" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="8pt"></asp:Label>
                <%--<img src="Images/loading35.gif" style="visibility: hidden" id="imgLoading" />--%> </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;<strong>Search UserId</strong></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtSearchUserID" runat="server" BorderWidth="1px" MaxLength="50"
                    ValidationGroup="BranchENtry"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnGo" runat="server" BorderWidth="1px" Text="Search" 
                    Width="67px" Font-Bold="True" OnClick="btnGo_Click"/></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:HiddenField runat="server" ID="hdnUserId" Value="0" />
                <asp:GridView ID="grv_GroupInfo" runat="server" AutoGenerateColumns="False" >
                  <%--  OnRowDataBound="grv_GroupInfo_RowDataBound">--%>
                    <Columns>
                        <asp:BoundField DataField="USERNAME" HeaderText="User Name" />
                        <asp:BoundField DataField="LoginName" HeaderText="User Id" />
                        <asp:BoundField DataField="RoleId" HeaderText="Role Id" />
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                          <asp:BoundField DataField="ID" HeaderText="ID" />
                        
                    </Columns>
                </asp:GridView>

                
            </td>
        </tr>
    </table>
</asp:Content>

