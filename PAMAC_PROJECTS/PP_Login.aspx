<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PP_Login.aspx.cs" Inherits="Pamac_Projects.PP_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PAMAC PROJECTS</title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" style="width: 728px">
            <tr>
                <td style="width: 214px" align="center">

                    <td style="width: 513px">&nbsp;<table cellpadding="0" cellspacing="0"
                        style="width: 600px; background-image: url('Images/LoginScreen.jpg'); height: 204px; background-repeat: no-repeat;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <table cellpadding="2" cellspacing="1">
                                    <tr>
                                        <td colspan="6" style="height: 26px">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px; height: 31px;"></td>
                                        <td style="height: 31px; width: 9px"></td>
                                        <td style="height: 31px; width: 133px"></td>
                                        <%--<td class="TableHeader"><b>PAMAC PROJECTS (PP) </b></td>--%>
                                        <td style="height: 31px"></td>
                                        <td style="width: 14px; text-align: center; height: 31px;"></td>
                                        <td style="width: 6px; height: 31px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px; height: 22px;">&nbsp;&nbsp;
                                        </td>
                                        <td style="width: 9px; height: 22px"></td>
                                        <td style="width: 133px; height: 22px;">
                                            <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; User ID</b>
                                        </td>
                                        <td style="height: 22px">
                                            <asp:TextBox ID="txtUserName" runat="server" SkinID="txtSkin"
                                                Style="margin-left: 0px" Width="104px"></asp:TextBox>
                                        </td>
                                        <td style="width: 6px; height: 22px;"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 13px"></td>
                                        <td style="width: 9px"></td>
                                        <td style="width: 133px;">
                                            <b style="text-align: center">&nbsp; &nbsp; &nbsp; Password</b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" SkinID="txtSkin"
                                                TextMode="Password" Width="105px"></asp:TextBox>
                                        </td>
                                        <td style="width: 6px"></td>
                                    </tr>
                            </td>

                            <tr>
                                <td style="width: 13px; height: 33px;"></td>
                                <td style="height: 33px; width: 9px; text-align: left;">&nbsp;</td>
                                <td style="height: 33px; width: 133px; text-align: center;">
                                    <asp:Button ID="btnLogin" runat="server" BorderWidth="1px" CssClass="button"
                                        Font-Bold="False" Height="29px" Text="Login" OnClick="btnLogin_Click"
                                        Width="100px" />
                                </td>
                                <%--<td style="height: 33px; text-align: center;">
                                            <asp:LinkButton ID="lkbtnChangePassowrd" runat="server" ForeColor="Yellow"
                                             OnClick="lkbtnChangePassowrd_Click" CausesValidation="false">Change Password</asp:LinkButton>
                                        </td>--%>
                                <td style="height: 50px;">
                                    <asp:LinkButton ID="lkbtnforgotPassword" runat="server" ForeColor="RED" OnClick="lkbtnforgotPassword_Click"
                                        CausesValidation="false">Forgot Password</asp:LinkButton>
                                </td>
                                <td style="width: 6px; height: 33px;"></td>
                            </tr>
                            <tr>
                                <td style="width: 13px; height: 25px"></td>
                                <td style="height: 25px; width: 9px;"></td>
                                <td colspan="4" style="height: 25px;"></td>
                                <td style="height: 25px;"></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">&nbsp;</td>
                                <td style="text-align: left">&nbsp;</td>
                                <td colspan="4" style="text-align: left">&nbsp;</td>
                                <td></td>
                            </tr>
                    </table>
                    </td>
                    <td style="width: 100px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 133px"></td>
                <td style="height: 133px">
            &nbsp;
        </table>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Height="16px"
            Visible="False" Width="100%" Font-Bold="True"></asp:Label>
    </form>
</body>
</html>

