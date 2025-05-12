<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="HdfcBranchpage.aspx.cs" Inherits="Administrator_HdfcBranchpage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" style="width: 924px">
        <tr>
            <td align="left" colspan="3" rowspan="3" style="width: 676px; height: 151px" valign="top"><table style="width: 925px">
                <tr>
                    <td colspan="3" rowspan="1" style="width: 750px; background-color: #eaeae8" align="center">
                       <strong>  HDFC Branch Master</strong> </td>
                </tr>
                <tr>
                    <td colspan="3" rowspan="1" style="width: 750px">
                        <asp:Label ID="StatusLabel" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" colspan="3" rowspan="1" style="width: 750px; height: 45px" valign="top">
                        <table style="width: 910px">
                            <tr>
                                <td colspan="3">
                                </td>
                                <td colspan="1">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15143px">
                                    HDFC Branch Data</td>
                                <td style="width: 299px">
                                    :</td>
                                <td style="width: 166px">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" Display="None"
                                        ErrorMessage="Please Select File." SetFocusOnError="True" ValidationGroup="vsyupload"></asp:RequiredFieldValidator></td>
                                <td style="width: 166px">
                                    <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload" ValidationGroup="vsyupload" Width="205px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 15143px; height: 26px;">
                                </td>
                                <td style="width: 299px; height: 26px;">
                                </td>
                                <td style="width: 166px; height: 26px;">
                                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="vsyupload" />
                                </td>
                                <td style="width: 166px; height: 26px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="background-color: #eaeae8" align="center">
                                   <strong>PMS Password Change</strong> </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height:5px">
                                </td>
                                <td colspan="1" style="height: 5px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15143px">
                                    Please Enter PMS &nbsp;Employee Code</td>
                                <td style="width: 299px">
                                    :</td>
                                <td style="width: 166px">
                                    <asp:TextBox ID="txtpmsempcode" runat="server"></asp:TextBox>
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="vrsypasspms" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpmsempcode"
                                        Display="None" ErrorMessage="Please Enter PMS Employee Code." SetFocusOnError="True"
                                        ValidationGroup="vrsypasspms"></asp:RequiredFieldValidator></td>
                                <td style="width: 166px">
                                    <asp:Button ID="btnPMS" runat="server" OnClick="btnPMS_Click" Text="PMS Change Password" ValidationGroup="vrsypasspms" />
                                    <asp:Button ID="btnToken" runat="server" OnClick="btnToken_Click" Text="Remove Token" ValidationGroup="vrsypasspms" /></td>
        
                            </tr>
                            <tr>
                                <td colspan="3" style="height:5px">
                                </td>
                                <td colspan="1" style="height: 5px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4"style="background-color: #eaeae8; height: 16px;" align="center">
                                  <strong>   HDFC&nbsp; Password Change</strong> </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height:1px">
                                </td>
                                <td colspan="1" style="height: 1px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15143px; height: 65px;">
                                    Please Enter HDFC Employee Code</td>
                                <td style="width: 299px; height: 65px;">
                                    :</td>
                                <td style="width: 166px; height: 65px;">
                                    <asp:TextBox ID="txtHDFCempcode" runat="server"></asp:TextBox>
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="vsgrpHDFC" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHDFCempcode"
                                        Display="None" ErrorMessage="Please Enter HDFC Employee Code." SetFocusOnError="True"
                                        ValidationGroup="vsgrpHDFC"></asp:RequiredFieldValidator></td>
                                <td style="width: 166px; height: 65px">
                                    <asp:Button ID="btnHDFc" runat="server" Text=" HDFC Change Password" OnClick="btnHDFc_Click" ValidationGroup="vsgrpHDFC" /></td>
                            </tr>
                            <tr>
                                <td style="width: 15143px; height: 65px">
                                </td>
                                <td style="width: 299px; height: 65px">
                                </td>
                                <td style="width: 166px; height: 65px">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="10">Inputter</asp:ListItem>
                                        <asp:ListItem Value="4">Authorizer</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="width: 166px; height: 65px">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rights Assignment"
                                        ValidationGroup="vsgrpHDFC" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" rowspan="1" style="width: 750px; height: 18px">
                    </td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

