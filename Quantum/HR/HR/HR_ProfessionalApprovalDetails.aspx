<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_ProfessionalApprovalDetails.aspx.cs" Inherits="HR_HR_HR_ProfessionalApprovalDetails" Title="Professional Approval Details" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="JAVASCRIPT" type="text/javascript"> 
   function CheckAll() 
        {
        chequeBoxSelectedCount = 0;
        var GV_EMP_VEIW = document.getElementById("<%=GV_EMP_VEIW.ClientID%>");
        var chkSelectAll = document.getElementById('chkSelectAll');
        var cell;
        for (i = 0; i <= GV_EMP_VEIW.rows.length - 1; i++) 
        {
            cell = GV_EMP_VEIW.rows[i].cells[0];
            if (cell != null) 
            {
                for (j = 0; j < cell.childNodes.length; j++) 
                {

                    if (cell.childNodes[j].type == "checkbox") 
                    {
                        cell.childNodes[j].checked = chkSelectAll.checked;
                        chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                    }
                }
            }

        }

    } 
</script>
    <table style="width: 949px">
        <tr>
            <td colspan="6">
                <span style="font-size: 12pt; font-family: Arial; text-decoration: underline;"><strong>
                    Profession Approval Request
                    Details</strong></span></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblmsg" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Crimson"
                    SkinID="lblErrorMsg"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px" class="reportTitleIncome">
                Centre Name</td>
            <td style="width: 100px; height: 15px" class="Info">
                <asp:DropDownList ID="ddlCentre" runat="server" 
                    DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Width="164px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btn" /></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td colspan="8" rowspan="5">
                &nbsp;<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="163px" Width="904px">
                <asp:GridView ID="GV_EMP_VEIW" runat="server"
                    SkinID="gridviewNoSort"
                    Width="90%">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectAll" onclick="javascript:CheckAll();" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>               
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td colspan="3">
                <asp:Button ID="btnUpd" runat="server" OnClick="btnUpd_Click" SkinID="btn" Text="Update Status" />
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnCan" runat="server" OnClick="btnCan_Click" SkinID="btn" Text="Cancel" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

