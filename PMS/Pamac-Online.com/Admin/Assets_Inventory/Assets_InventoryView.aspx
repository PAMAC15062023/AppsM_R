<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master"
    AutoEventWireup="true" CodeFile="Assets_InventoryView.aspx.cs" Inherits="Admin_Assets_Inventory_Assets_InventoryView"
    Title="Assets Inventory View" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <script language="JAVASCRIPT" type="text/javascript"> 
function ClientValidate(source, arguments)
       {
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       
       
    </script>

    <fieldset>
        <table width="100%">
            <tr>
                <td class="tta" colspan="9">
                    <span style="font-size: 10pt">ASSETS INVENTORY DESCRIPTION</span></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"
                        ForeColor="#FF3300"></asp:Label></td>
                <td style="width: 87px; height: 21px;">
                </td>
                <td style="width: 227px; height: 21px;">
                </td>
                <td style="width: 103px; height: 21px;">
                </td>
                <td align="right" style="height: 21px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" SkinID="lblSkin" Text="[View]"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 134px; height: 22px;" class="reportTitleIncome">
                    &nbsp;Centre Name</td>
                <td style="width: 228px; height: 22px;" class="Info">
                    <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" SkinID="ddlSkin"
                        OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="164px">
                    </asp:DropDownList></td>
                <td style="width: 87px; height: 22px" class="reportTitleIncome">
                    Sub Centre Name</td>
                <td style="width: 227px; height: 22px;" class="Info">
                    <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre"
                        DataTextField="SubCentreName" DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound"
                        Width="164px">
                    </asp:DropDownList></td>
                <td style="width: 103px; height: 22px; text-align: center;" class="reportTitleIncome">
                    <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="Search" ValidationGroup="ValDate"
                        Width="60px" Font-Bold="True" /></td>
                <td align="right" style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 134px; height: 31px;">
                    Assets Name</td>
                <td class="Info" style="width: 100px; height: 31px;">
                    <asp:DropDownList ID="ddlAssetName" runat="server" SkinID="ddlSkin" Width="166px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 31px;" class="reportTitleIncome">
                    Employee Code</td>
                <td style="width: 100px; height: 31px;" align="center" class="Info">
                    <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" Width="159px"></asp:TextBox></td>
               
                <td style="width: 100px; height: 31px;" class="reportTitleIncome">
                    Transaction Ref No.</td>
                <td style="width: 100px; height: 31px;" align="center" class="Info">
                    <asp:TextBox ID="txtTransactionID" runat="server" SkinID="txtSkin" Width="159px"></asp:TextBox></td>
                <td style="width: 100px; height: 31px;">
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView ID="GV_EMP_VEIW" Width="99%" runat="server" SkinID="gridviewNoSort"
                        AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging"
                        PageSize="20" OnRowCommand="GV_EMP_VEIW_RowCommand" Height="1px" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="EMP CODE" HeaderText="User Code">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="User Name" HeaderText="User Name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DEPARTMENT" HeaderText="Department">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIT" HeaderText="Unit">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TransRefNo" HeaderText="TransRefNo">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Assets_Type" HeaderText="Assets_Type">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompName" HeaderText="Company Name" SortExpression="CompName" />
                            <asp:BoundField DataField="Assets_SubType" HeaderText="Sub Asset Type" SortExpression="Assets_SubType" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("TransRefNo")+","+ Eval("Assets_Type") %>'
                                        CommandName="Ed"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:CheckBoxField />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:SqlDataSource ID="sdsSubcetre" runat="server" ProviderName="System.Data.OleDb">
    </asp:SqlDataSource>
    <asp:HiddenField ID="hdnCentre" runat="server" />
    <asp:HiddenField ID="hdnAssetType" runat="server" />
    <asp:HiddenField ID="hdnSubcentre" runat="server" />
    <asp:HiddenField ID="hdnEmpCode" runat="server" />
    <asp:CustomValidator ID="ValCentre" runat="server" ControlToValidate="ddlCentre"
        Display="None" ErrorMessage="Please select the centre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValSubcentre" runat="server" ControlToValidate="ddlSubcentre"
        Display="None" ErrorMessage="Please select the SubCentre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:ValidationSummary ID="ValSummarry" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="ValAddNew" DisplayMode="List" />
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</asp:Content>
