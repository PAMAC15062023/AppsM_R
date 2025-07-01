<%@ Page Title="" Language="C#" MasterPageFile="~/PP_Master.Master" AutoEventWireup="true" CodeBehind="PP_Activities.aspx.cs" Inherits="Pamac_Projects.PP_Activities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript"> </script>

    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                <asp:Label ID="lblHeader" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
                <%--&nbsp;DASHBOARD</td>--%>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" BorderWidth="1px" Text="ADD NEW"
                    Width="67px" Font-Bold="True" OnClick="btnAdd_Click" /></td>
            </td>
        </tr>

    </table>
    <tr>
        <asp:GridView ID="grv1" runat="server" CssClass="mGrid" Style="overflow: scroll" Visible="true" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="20" OnPageIndexChanging="grv1_PageIndexChanging">

            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                    <HeaderTemplate>
                        <asp:Label ID="chkhead" runat="server">EDIT</asp:Label>
                        <%--<input id="chkSelectAll" type="checkbox" />--%>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" ItemStyle-Width="10px" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                    <%--<ItemTemplate>
                                  <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                              Action</asp:LinkButton>
                                
                            </ItemTemplate>--%>
                </asp:TemplateField>
                <asp:BoundField DataField="Act_no" HeaderText="ITEM nO." ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE" ItemStyle-Width="110px" />
                <asp:BoundField DataField="PostedBy" HeaderText="Posted By" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Subject" HeaderText="Subject " ItemStyle-Width="300px" />
                <%--<asp:BoundField DataField="Act_Status" HeaderText="Current Status " ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                <asp:DropDownList ID="ddlCurrentStatus" runat="server" AutoPostBack="true" AppendDataBoundItems="true" 
                   OnSelectedIndexChanged="ddlCurrentStatus_SelectedIndexChanged">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                      <asp:ListItem Text="OPEN" Value="OPEN"></asp:ListItem>
                      <asp:ListItem Text="HOLD" Value="HOLD"></asp:ListItem>
                      <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>
                </asp:DropDownList>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Eval("Act_Status") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </tr>
    <tr>
   <asp:GridView ID="grv2" runat="server" CssClass="mGrid" Style="overflow: scroll" Visible="true" AutoGenerateColumns="true"
            AllowPaging="True" PageSize="20" OnPageIndexChanging="grv2_PageIndexChanging">
            <Columns>
                </Columns>
       </asp:GridView>
    </tr>

</asp:Content>
