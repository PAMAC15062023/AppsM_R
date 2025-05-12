<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_GlobalDatabaseSearch.aspx.cs" Inherits="FRC_Employee_Background_Check_EBC_GlobalDatabaseSearch" Title="Global Database Search" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <table style="width: 843px">
         <tr>
              
            <td colspan="6">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td>
              </tr>
        <tr>
            <td class="tta" colspan="6">
                &nbsp;Global Database Search</td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Name Of Employee</td>
            <td class="Info" style="width: 157px; height: 16px;">
                <asp:TextBox ID="txtEmpFname" runat="server" SkinID="txtSkin" ReadOnly="True" Width="215px"></asp:TextBox>&nbsp;</td>
            <td style="width: 157px; height: 16px; text-align: center">
            </td>
            <td style="width: 157px; height: 16px; text-align: center">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 2px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 2px">
                Name Of Company</td>
            <td class="Info" style="width: 366px; height: 2px">
                <asp:TextBox ID="txtCompName" runat="server" SkinID="txtSkin" ReadOnly="True" Width="215px"></asp:TextBox></td>
            <td style="width: 366px; height: 2px">
            </td>
            <td style="width: 366px; height: 2px">
            </td>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Name of Person Contacted(Ins)</td>
            <td class="Info" style="width: 366px; height: 15px">
                <asp:TextBox ID="txtPersonContacted" runat="server" SkinID="txtSkin" Width="215px"></asp:TextBox></td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Desigantion&nbsp; Contacted .Person</td>
            <td class="Info" style="width: 366px; height: 15px">
                <asp:TextBox ID="txtPersonDesgn" runat="server" SkinID="txtSkin" Width="215px"></asp:TextBox></td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Contact Details</td>
            <td class="Info" style="width: 366px; height: 15px">
                <asp:TextBox ID="txtContact" runat="server" SkinID="txtSkin" Width="215px"></asp:TextBox></td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Record Found</td>
            <td class="Info" style="height: 15px">
                <asp:DropDownList ID="ddlRecordFound" runat="server" Height="14px" SkinID="ddlSkin" Width="128px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Remark</td>
            <td class="Info" style="height: 15px">
                <asp:TextBox ID="txtRemark" runat="server" Height="48px" TextMode="MultiLine" Width="276px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                STATUS</td>
            <td class="Info" style="height: 15px">
                <asp:TextBox ID="txtStatus" runat="server" Height="50px" TextMode="MultiLine" Width="277px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px;">
            </td>
            <td class="reportTitleIncome" style="width: 288px;">
                Supervisor's Name
            </td>
            <td class="Info">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin" Width="215px"></asp:TextBox></td>
            <td style="width: 366px;">
            </td>
            <td style="width: 366px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 15px">
                Date&nbsp; of visit</td>
            <td class="Info" style="width: 366px; height: 15px">
                <asp:TextBox ID="txtDateTime" runat="server" SkinID="txtSkin" Width="113px"></asp:TextBox>
                <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateTime.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 15px">
                <asp:Button ID="btnSave" runat="server" Height="27px" SkinID="btnSaveSkin" Text="Save"
                    Width="87px" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Height="27px" SkinID="btnCancelSkin" Text="Cancel"
                    Width="87px" OnClick="btnCancel_Click" /></td>
            <td style="height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 1px; height: 15px">
            </td>
            <td style="width: 288px; height: 15px">
                <asp:HiddenField ID="hdnCaseID" runat="server" />
            </td>
            <td style="width: 366px; height: 15px">
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" />
            </td>
            <td style="width: 366px; height: 15px">
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
            </td>
            <td style="width: 366px; height: 15px">
            </td>
            <td style="height: 15px">
            </td>
        </tr>
    </table>
</asp:Content>

