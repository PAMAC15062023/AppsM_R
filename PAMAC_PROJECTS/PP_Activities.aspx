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

            <td colspan="5">
                <asp:Label ID="lblRowCount" runat="server"  Width="100%"></asp:Label>
            </td>
        </tr>

    </table>
    <table>
        <tr>
            <asp:GridView ID="grv1" runat="server" CssClass="mGrid" Style="overflow: scroll" Visible="true" AutoGenerateColumns="False"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="grv1_PageIndexChanging" OnSorting="grv1_Sorting" AllowSorting="true">
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
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2px"></asp:TemplateField>

                    <asp:BoundField DataField="Act_no" HeaderText="ITEM nO." HeaderStyle-ForeColor="White" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" SortExpression="Act_no" />
                    <asp:BoundField DataField="Original_Posted_Date" HeaderText="ORIGINAL POSTED DATE" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="PostedDate" />
                    <asp:BoundField DataField="PostedDate" HeaderText="LAST UPDATED DATE" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="PostedDate" />
                    <asp:BoundField DataField="PostedBy" HeaderText="LAST ASSIGNED TO" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" SortExpression="PostedBy" />
                    <asp:BoundField DataField="Subject" HeaderText="SUBJECT " HeaderStyle-ForeColor="White" ItemStyle-Width="300px" SortExpression="Subject" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:DropDownList ID="ddlCurrentStatus" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlCurrentStatus_SelectedIndexChanged">
                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                            </asp:DropDownList>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("Act_Status")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:GridView ID="grv2" runat="server" CssClass="mGrid" Style="overflow: scroll" Visible="true" AutoGenerateColumns="false"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="grv2_PageIndexChanging" OnSorting="grv2_Sorting" AllowSorting="true">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                        <HeaderTemplate>
                            <asp:Label ID="chkhead" runat="server">EDIT</asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect2" runat="server" ItemStyle-Width="10px" AutoPostBack="true" OnCheckedChanged="chkSelect2_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PostedDate" HeaderText="LAST UPDATED DATE" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="PostedDate" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:DropDownList ID="ddlmodule" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlmodule_SelectedIndexChanged">
                                <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                            </asp:DropDownList>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Eval("module")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Module" HeaderText="Module" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="Module" />
                    <asp:BoundField DataField="Act_no" HeaderText="Act No" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="Act_no" />
                    <asp:BoundField DataField="subject" HeaderText="subject" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="subject" />
                    <asp:BoundField DataField="Filename" HeaderText="Filename" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="Filename" />
                    <asp:BoundField DataField="updatedby" HeaderText="updatedby" HeaderStyle-ForeColor="White" ItemStyle-Width="110px" SortExpression="updatedby" />

                </Columns>
            </asp:GridView>

        </tr>
    </table>
</asp:Content>
