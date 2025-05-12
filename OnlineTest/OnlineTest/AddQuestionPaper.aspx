<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="AddQuestionPaper.aspx.cs" Inherits="OnlineTest.AddQuestionPaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ValidateTime(obj) {
            var time_check = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            var txtNumber = obj.value;
            if (txtNumber.match(time_check)) {
                return true;
            }
            else {
                obj.value = '00:00';
                alert("Invalid Time");
                return false;
            }
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    &nbsp;&nbsp;
    <table style="width: 1170px;">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" id="header1" runat="server" style="font-size: medium">Question Paper New/Edit</td>
        </tr>
        <tr>
            <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lblOption" runat="server" Text="Option:"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

            <td style="width: 120px" class="TableGrid">

                <asp:DropDownList ID="ddlOption" runat="server" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Select Option</asp:ListItem>
                    <asp:ListItem Value="1">NEW</asp:ListItem>
                    <asp:ListItem Value="2">EDIT</asp:ListItem>

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lblquestions" runat="server" Text="Select Question Paper "
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

            <td style="width: 66px" class="TableGrid">

                <asp:DropDownList ID="ddlQuestionPaper" runat="server" OnSelectedIndexChanged="ddlQuestionPaper_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>

        </tr>
    </table>
    <asp:Panel ID="Mainpanel" runat="server">
        <table>
            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="lblvertical" runat="server" Text="Vertical:"
                        Style="font-weight: 700; font-size: small"></asp:Label></td>

                <td style="width: 66px" class="TableGrid">
                    <asp:DropDownList ID="ddlv" runat="server">
                    </asp:DropDownList>

                </td>

                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="Label2" runat="server" Text="Product"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                    :</td>

                <td style="width: 120px" class="TableGrid">
                    <asp:DropDownList ID="ddlp" runat="server">
                    </asp:DropDownList>

                </td>

                <td style="width: 72px">&nbsp;</td>

                <td style="width: 72px">&nbsp;</td>

            </tr>



            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="Label4" runat="server" Text="Designation :"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 66px" class="TableGrid">

                    <asp:DropDownList ID="ddlDesignation" runat="server">
                        <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                   <asp:ListItem Value="Level1">Level1</asp:ListItem>
                    <asp:ListItem Value="Level2">Level2</asp:ListItem>
                    <asp:ListItem Value="Level3">Level3</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
                <td style="width: 120px" class="TableTitle">

                    <asp:Label ID="lblActivity" runat="server" Text="Activity:"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 120px" class="TableGrid">

                    <asp:DropDownList ID="ddlActivity" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="lblClient1" runat="server" Text="Client:" Style="font-weight: 700; font-size: small"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
                <td class="TableGrid" style="width: 66px">
                    <asp:DropDownList ID="ddlClientlist" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="lbllevel" runat="server" Text="Level :"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>

                <td style="width: 120px" class="TableGrid">

                    <asp:DropDownList ID="ddllevel" runat="server">
                    </asp:DropDownList>
                </td>

                <td>&nbsp;</td>

                <td>&nbsp;</td>


            </tr>
            <tr>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblPapername" runat="server" Text="Paper Name"
                        Style="font-weight: 700; font-size: small"> </asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">
                    <asp:TextBox ID="txtPaperName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">

                    <asp:TextBox ID="txtTotalMarks" Width="150px" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>

                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblPassPercentage" runat="server" Text="Pass Percentage"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">

                    <asp:TextBox ID="txtPassPercentage" Width="150px" runat="server"
                        onkeypress="return isNumber(event)"
                        OnTextChanged="txtPassPercentage_TextChanged" AutoPostBack="true"></asp:TextBox>

                </td>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblduration" runat="server" Text="Duration HH:mm"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">
                    <asp:TextBox ID="txtduration" runat="server" Text="00:00" Style="height: 22px" onblur="ValidateTime(this);"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="lblisactive" runat="server" Text="IsActive :"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>

                <td style="width: 120px" class="TableGrid">

                    <asp:DropDownList ID="ddlIsactive" runat="server">

                        <asp:ListItem Value="1">True</asp:ListItem>
                        <asp:ListItem Value="0">False</asp:ListItem>

                    </asp:DropDownList>
                </td>
            </tr>



            <tr>
                <td class="TableGrid" colspan="4">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Save" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update Question Paper" />
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnqnPno" runat="server" />
    </asp:Panel>
    <table>
        <tr>
            <td style="width: 120px" class="TableTitle">&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Back" />
            </td>
        </tr>
    </table>
</asp:Content>

