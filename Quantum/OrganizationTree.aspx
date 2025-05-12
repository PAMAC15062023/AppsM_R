<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationTree.aspx.cs"
    Inherits="OrganizationTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#ffffcc">
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 289px">
                        <fieldset>
                            <legend class="FormHeading"><strong style="color: #663300">My Attendance</strong></legend>
                            <table width="90%">
                                <tr>
                                <td></td>
                                    <td valign="top" align="right">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Visible="False" Font-Bold="True" ForeColor="#663300" />
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>
                                            <asp:Label ID="lblMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="#663300"></asp:Label></strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TreeView runat="Server" ID="tvOrganization" ShowLines="True" OnSelectedNodeChanged="tvOrganization_SelectedNodeChanged"
                                            BorderStyle="Groove" Font-Bold="True" ForeColor="#663300">
                                            <LeafNodeStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="#663300" />
                                            <NodeStyle BackColor="#FFFFCC" />
                                        </asp:TreeView>
                                    </td>
                                    <td valign="top" align="right">
                                        <table>
                                            <tr>
                                                <td style="height: 16px">
                                                    <asp:LinkButton ID="lnkAdmin" runat="server" PostBackUrl="~/Administrator/Default.aspx"
                                                        Font-Bold="True" ForeColor="#FFFFC0">[Admin]</asp:LinkButton>
                                                </td>
                                                <td style="height: 16px; width: 113px; background-color: white;" align="center">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" Font-Bold="True"
                                                        ForeColor="Chocolate" Height="27px" PostBackUrl="~/Demo.aspx" Width="122px">Change Password</asp:LinkButton></td>
                                                <td style="height: 16px">
                                                    &nbsp;</td>
                                                <td style="height: 16px; width: 6px;">
                                                    &nbsp;</td>
                                                <td style="height: 16px">
                                                    &nbsp;</td>
                                                <td style="height: 16px; background-color: white;">
                                                    <asp:LinkButton ID="lnkSalaryView" runat="server" PostBackUrl="~/HR/HR/HR_SalaryView.aspx"
                                                        Font-Bold="True" ForeColor="Chocolate" Visible="true" BackColor="White" BorderColor="White"
                                                        Height="30px">[Salary View]</asp:LinkButton>
                                                </td>
                                                <td style="height: 16px; background-color: white;">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Default2.aspx" Font-Bold="True"
                                                        ForeColor="Chocolate" Visible="true" BackColor="White" BorderColor="White" Height="30px">[MOU]</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server"  Font-Bold="True"
                                                        ForeColor="Chocolate" Visible="true" BackColor="White" BorderColor="White" Height="30px" OnClick="LinkButton3_Click">[Schemes & Offers]</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Upload.aspx" Font-Bold="True"
                                                        ForeColor="Chocolate" Visible="true" BackColor="White" BorderColor="White" Height="30px">[Upload]</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Download.aspx" Font-Bold="True"
                                                        ForeColor="Chocolate" Visible="true" BackColor="White" BorderColor="White" Height="30px">[Download]</asp:LinkButton>
                                                    <asp:LinkButton ID="lnkQMS" runat="server" BackColor="White" Font-Bold="True" ForeColor="Chocolate"
                                                        BorderColor="White" Height="30px" OnClick="lnkQMS_Click">QMS</asp:LinkButton>
                                                         <asp:LinkButton ID="LinkButton6" runat="server" BackColor="White" Font-Bold="True" ForeColor="Chocolate"
                                                        BorderColor="White" Height="30px" OnClick="LinkButton6_Click" Visible="false">Import</asp:LinkButton>
                                                </td>
                                                <%--<td style ="height:18px">
            <asp:LinkButton id="lnkAssets" runat="server" PostBackUrl="~/Assets/Default.aspx">[Assets Summary]</asp:LinkButton>
            </td>--%>
                                                <td style="height: 16px">
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/logout.jpg"
                                                        PostBackUrl="~/Default.aspx" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <!--
        <asp:DataList ID="MyDataList" runat="server">
            <HeaderTemplate>
              The following nodes are checked:
            </HeaderTemplate>
            <ItemTemplate>
              <%# Eval("Text") %>
            </ItemTemplate>
        </asp:DataList>
        -->
        </div>
    </form>
</body>
</html>
