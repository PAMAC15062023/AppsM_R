<%@ Page Language="C#" MasterPageFile="~/BSC/BSC/MasterPage.master" AutoEventWireup="true"
    CodeFile="BSCEntry.aspx.cs" Inherits="BSC_BSC_BSCEntry" Title="Untitled Page"
    StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <table width="100%">
        <tr>
            <td colspan="4" style="height: 16px">
                <asp:Label ID="Label1" runat="server" EnableViewState="true" SkinID="lblErrorMsg"
                    ForeColor="Crimson"></asp:Label></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 160px">
                For Month :</td>
            <td class="Info" style="width: 160px">
                <asp:DropDownList ID="ddlForMonth" runat="server" SkinID="ddlSkin" Width="120px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>January</asp:ListItem>
                    <asp:ListItem>February</asp:ListItem>
                    <asp:ListItem>March</asp:ListItem>
                    <asp:ListItem>April</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>August</asp:ListItem>
                    <asp:ListItem>September</asp:ListItem>
                    <asp:ListItem>October</asp:ListItem>
                    <asp:ListItem>November</asp:ListItem>
                    <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 160px">
                For Year :</td>
            <td class="Info">
                <asp:DropDownList ID="ddlForYear" runat="server" SkinID="ddlSkin" Width="120px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" class="Info" colspan="4">
                &nbsp;
                <asp:Button ID="btnshow" runat="server" SkinID="btn" Text="Search" ValidationGroup="ValDate"
                    Width="123px" OnClick="btnshow_Click" />&nbsp;
            </td>
        </tr>
        <tr>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <table width="100%">
            <tr>
                <td class="tta" style="width: 80%;">
                    <span style="font-size: 10pt">PERFORMANCE REPORT&nbsp;</span></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort"
                        AllowPaging="True" AutoGenerateColumns="False" PageSize="5">
                        <Columns>
                           <%-- <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="Centre_Name" HeaderText="Location">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SubCentreName" HeaderText="Sub Location">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="Team Leader Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Client_Name" HeaderText="Client Name ">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Volume">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVolume" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WithIn TAT">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWithInTAT" SkinID="txtSkin" Width="80%" runat="server" AutoPostBack="true"
                                        OnTextChanged="txtWithInTAT_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TAT %">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPercentage" SkinID="txtSkin" Width="80%" runat="server" ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Performance Report Status">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlReportStatus" runat="server" Width="80%" SkinID="ddlSkin"
                                        OnSelectedIndexChanged="ddlReportStatus_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add Remark">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" Visible="false" OnTextChanged="txtRemark_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Performance Report Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDate" SkinID="txtSkin" Width="80%" runat="server" OnTextChanged="txtDate_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>(dd/mm/yyyy)
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  Complaint  ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCompliment" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  Error Input ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtError" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Date Of Bill">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBillingDate" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>(dd/mm/yyyy)
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Billing(Amount)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBAmount" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Collection Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBCollectionDate" SkinID="txtSkin" Width="80%" runat="server"></asp:TextBox>(dd/mm/yyyy)
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click"
                        ValidationGroup="VLD" UseSubmitBehavior="false"/>&nbsp;
                    <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
