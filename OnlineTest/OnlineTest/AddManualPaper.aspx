<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="AddManualPaper.aspx.cs" Inherits="OnlineTest.MannualPaper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="../popcalendar.js">
    </script>
    <table>
        <tr>
            <td style="width: 354px" colspan="5">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5" style="font-size: medium">Set Question Paper</td>
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
            <td style="width: 109px" class="TableTitle">
                <asp:Label ID="lblPaperlist" runat="server" Text="PaperList :"></asp:Label>
            </td>
            <td style="width: 90px" class="TableGrid">
                <asp:DropDownList ID="ddlPaperlist" runat="server"
                    OnSelectedIndexChanged="ddlPaperlist_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <asp:Panel ID="Mainpanel" runat="server">
            <tr>
                <td style="width: 109px" class="TableTitle">
                    <asp:Label ID="lblpaper" runat="server" Text="Vertical :"></asp:Label>
                </td>
                <td style="width: 90px" class="TableGrid">
                    <asp:DropDownList ID="ddlvertical" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="Label5" runat="server" Text="Level:"></asp:Label>
                </td>

                <td style="width: 120px" class="TableGrid">

                    <asp:DropDownList ID="ddllevel" runat="server">
                    </asp:DropDownList>
                </td>
                <%--    <td style="width: 120px" class="TableTitle">
                <asp:Label ID="lbllevel" runat="server" Text="Level :"
                    Style="font-weight: 700; font-size: small"></asp:Label>
            </td>--%>


                <%--  <td style="width: 133px" class="TableTitle">
                <asp:Label ID="Label1" runat="server" Text="Select Criteria :"></asp:Label>
            </td>
            <td style="width: 116px" class="TableGrid">
                <asp:DropDownList ID="ddlcriteria" runat="server">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:DropDownList>
            </td>--%>
                <td style="width: 354px">&nbsp;</td>
                <td style="width: 408px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 109px" class="TableTitle">
                    <asp:Label ID="Label2" runat="server" Text="Product"></asp:Label>
                </td>
                <td style="width: 90px" class="TableGrid">
                    <asp:DropDownList ID="ddlproduct" runat="server" Style="margin-left: 0px"></asp:DropDownList>
                </td>
                <td style="width: 133px" class="TableTitle">
                    <asp:Label ID="Label3" runat="server" Text="Designation"></asp:Label>
                </td>
                <td style="width: 116px" class="TableGrid">
                    <asp:DropDownList ID="ddlDesignation" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 354px">&nbsp;</td>
                <td style="width: 408px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 133px" class="TableTitle">
                    <asp:Label ID="lblClient1" runat="server" Text="Client"></asp:Label>
                </td>
                <td style="width: 90px" class="TableGrid">
                    <asp:DropDownList ID="ddlClientList" runat="server"></asp:DropDownList>
                </td>
                <td style="width: 133px" class="TableTitle">
                    <asp:Label ID="Label4" runat="server" Text="Activity"></asp:Label>
                </td>
                <td style="width: 116px" class="TableGrid">
                    <asp:DropDownList ID="ddlActivity" runat="server"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblPapername" runat="server" Text="Paper Name"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">
                    <asp:TextBox ID="txtPaperName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblTotalMarks" runat="server" Text="Total Marks"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">
                    <asp:TextBox ID="txtTotalMarks" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 116px" class="TableTitle">
                    <asp:Label ID="lblPassPercentage" runat="server" Text="Pass Percentage"></asp:Label>
                </td>
                <td style="width: 183px" class="TableGrid">
                    <asp:TextBox ID="txtPassPercentage" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td class="TableTitle" colspan="5">
                    <asp:Button ID="btnfetch" runat="server" Text="Get List of Question" Style="width: 120px"
                        OnClick="btnfetch_Click" ToolTip="Get List of Questions" />&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="TableHeader" style="width: 354px" colspan="5">
                    <b>Select questions to be added to this Question Paper 
                    </b>
                </td>
            </tr>
            <tr>
                <td style="width: 354px" colspan="5">
                    <asp:GridView ID="grdQuestionSet" runat="server" AutoGenerateColumns="true" Visible="true"
                        CssClass="mGrid" Width="711px" Height="37px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chknumber" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:BoundField DataField="question" HeaderText="Question" />
                        <asp:BoundField DataField="Answer" HeaderText="Correct Answer" />
                        <asp:BoundField DataField="que_id" HeaderText="Question ID" />--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 154px; margin-left: 40px;" colspan="5">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click"
                        Text="Submit" ToolTip="Add to qn paper master and details"
                        Width="162px" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 154px; margin-left: 40px;" colspan="5">
                    <asp:Button ID="btnedit" runat="server" OnClick="btnedit_Click"
                        Text="Edit" ToolTip="Add to qn paper master and details"
                        Width="162px" />
                </td>
            </tr>
            <tr>

                <td>&nbsp;</td>
                <td style="width: 408px">&nbsp;</td>
            </tr>
            <%--   <tr>
            <td colspan="2" class="TableTitle">
                <asp:Label ID="lblQuestionLocation" runat="server" Text="Select Location for Test :"></asp:Label>
            </td>
            <td colspan="2" class="TableGrid">
                <asp:DropDownList ID="ddlTestLocation" runat="server" Height="16px" Width="127px"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td style="width: 408px">&nbsp;</td>
        </tr>--%>
            <%--   <tr>

            <td colspan="2" class="TableTitle">
                <asp:Label ID="lblTestDate" runat="server" Text="Select Date for Test :"></asp:Label>
            </td>

            <td colspan="2" class="TableGrid">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <cc1:calendarextender id="txtDate_CalendarExtender" runat="server"
                    enabled="True" targetcontrolid="txtDate">
                </cc1:calendarextender>
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>

            <td>&nbsp;</td>
            <td style="width: 408px">&nbsp;</td>
        </tr>--%>
            <tr>
                <td colspan="5">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
            </tr>
            <tr>
                <td class="TableHeader" style="width: 354px" colspan="5">
                    <b>Questions added to this Question Paper (for information only)
                    </b>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="grvMannualQuestionPaper" runat="server" AutoGenerateColumns="True" CssClass="mGrid" Width="351px">
                        <%--<Columns>
                        <asp:BoundField DataField="question" HeaderText="Question" />
                        <asp:BoundField DataField="Question_level" HeaderText="Qestion Level" />
                        <asp:BoundField DataField="Answer" HeaderText="Correct Answer" />
                    </Columns>--%>
                    </asp:GridView>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td class="TableTitle" style="width: 154px; margin-left: 40px;" colspan="5">
                <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click"
                    ToolTip="Canel and Exists" />
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="hdnqnPno" runat="server" />

</asp:Content>
