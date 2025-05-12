<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" CodeFile="Rejected_Assets.aspx.cs" Inherits="Admin_Assets_Inventory_Rejected_Assets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckSingleCheckbox(ob) {
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>

    <table style="width: 438px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red" Width="325px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5" class="tta">Asset Approver Page</td>
        </tr>
    </table>
    <asp:Panel ID="pnlAssetDetails" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="GVDetailsForAssetApprover" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid" Visible="true" DataKeyNames="UserRemark">  <%--DataKeyNames="UserRemark" add on 29/01/2024--%>
                        <Columns>
                            <asp:BoundField DataField="Emp_Code" HeaderText="Employee Code" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Vertical_Name" HeaderText="Vertical Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Assets_Type" HeaderText="Asset Type" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="TransRefNo" HeaderText="Transaction ID" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Purchase_Date" HeaderText="Purchase Date" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Purchase_Cost" HeaderText="Purchase Cost" ItemStyle-Width="390px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AppAuth_Name" HeaderText="App Auth Name" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="UserRemark" HeaderText="User Remarks" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Center" />
                            

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbox" runat="server" Onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btn_Edit" runat="server" OnClick="btn_Edit_Click" Text="Edit" /><%-- OnClick="btn_Edit_Click1"--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnAssetID" runat="server" />
    </asp:Panel>
</asp:Content>