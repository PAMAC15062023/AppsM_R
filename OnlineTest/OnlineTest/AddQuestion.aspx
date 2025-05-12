<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="OnlineTest.AddQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="MultiSelectDDL/jquery.min.js"></script>
    <link href="MultiSelectDDL/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="MultiSelectDDL/bootstrap.min.js"></script>
    <%--<link href="MultiSelectDDL/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
        <script src="MultiSelectDDL/bootstrap-multiselect.js" type="text/javascript"></script>--%>
    <link rel="stylesheet" href="MultiSelectDDL/bootstrap-multiselect.css2.css">
    <script src="MultiSelectDDL/bootstrap-multiselect.js2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lstbAns3]').multiselect({
                includeSelectAllOption: true
                // maxHeight: 5000;
            });
        });
    </script>


    &nbsp;&nbsp;
    <table style="width: 950px;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="2" id="header1" runat="server" style="font-size: medium">Add New Questions</td>
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
                <asp:Label ID="lblquestions" runat="server" Text="Select Question"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

            <td style="width: 50px" class="TableGrid">

                <asp:DropDownList ID="ddlQuestions" runat="server" OnSelectedIndexChanged="ddlQuestions_SelectedIndexChanged" 
                  Width="110px" BorderWidth="1px"   AutoPostBack="true">
                </asp:DropDownList>
            </td>

        </tr>
    </table>
    <asp:Panel ID="Mainpanel" runat="server">
        <table style="width: 1500">
            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="lblvertical" runat="server" Text="Vertical:"
                        Style="font-weight: 700; font-size: small"></asp:Label></td>

                <td style="width: 129px" class="TableGrid">
                    <asp:DropDownList ID="ddlv" runat="server">
                    </asp:DropDownList>

                </td>

                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="Label2" runat="server" Text="Product"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                    :</td>

                <td style="width: 356px" class="TableGrid">
                    <asp:DropDownList ID="ddlp" runat="server">
                    </asp:DropDownList>

                </td>

                <td style="width: 122px">&nbsp;</td>

                <td style="width: 72px">&nbsp;</td>

            </tr>



            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="Label4" runat="server" Text="Designation :"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 129px" class="TableGrid">

                    <asp:DropDownList ID="ddlDesignation" runat="server">
                        <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                   <asp:ListItem Value="Level1">Level1</asp:ListItem>
                    <asp:ListItem Value="Level2">Level2</asp:ListItem>
                    <asp:ListItem Value="Level3">Level3</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
                <td style="width: 120px" class="TableTitle">

                    <asp:Label ID="Label5" runat="server" Text="Activity:"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>
                <td style="width: 356px" class="TableGrid">

                    <asp:DropDownList ID="ddlActivity" runat="server">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="Level1">Level1</asp:ListItem>
                        <asp:ListItem Value="Level2">Level2</asp:ListItem>
                        <asp:ListItem Value="Level3">Level3</asp:ListItem>
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
                <td class="TableGrid" style="width: 129px">
                    <asp:DropDownList ID="ddlClientlist" runat="server"></asp:DropDownList>
                </td>
                <td class="TableTitle">
                    <strong><span style="font-size: small">Topic:</span></strong>&nbsp;
                </td>
                <td class="TableGrid" style="width: 356px">
                    <asp:TextBox ID="txttopic" runat="server" Width="348px"></asp:TextBox>
                </td>

                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 122px" class="TableTitle">
                    <asp:Label ID="Label1" runat="server" Text="Qn_Type"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                    : &nbsp;&nbsp;</td>

                <td style="width: 129px" class="TableGrid">
                    <asp:DropDownList ID="ddlqntype" runat="server"
                        OnSelectedIndexChanged="ddlqntype_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>

                <td style="width: 120px" class="TableTitle">
                    <asp:Label ID="lbllevel" runat="server" Text="Level :"
                        Style="font-weight: 700; font-size: small"></asp:Label>
                </td>



                <td style="width: 356px" class="TableGrid">

                    <asp:DropDownList ID="ddllevel" runat="server">
                    </asp:DropDownList>
                </td>
                <tr>
                    <td style="width: 122px" class="TableTitle">
                        <asp:Label ID="LblIsActive" runat="server" Text="IsActive :"
                            Style="font-weight: 700; font-size: small"></asp:Label>
                    </td>



                    <td style="width: 129px" class="TableGrid">

                        <asp:DropDownList ID="ddlIsactive" runat="server">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem Value="False">False</asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td style="width: 120px" class="TableTitle">
                        <asp:Label ID="LblQueId" runat="server" Text="QuesID :"
                            Style="font-weight: 700; font-size: small"></asp:Label>
                    </td>
                    <td class="TableGrid" style="width: 356px">
                        <asp:TextBox ID="TxtQuesId" runat="server" Width="348px"></asp:TextBox>
                    </td>

                </tr>
            <%-- <tr>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                  </tr>--%>
            <tr>
                <td class="TableHeader" colspan="4">
                    <asp:Label ID="Label3" runat="server" Style="font-weight: 700; font-size: small; text-decoration: underline;" Text="Enter Question"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:TextBox ID="txtque" runat="server" TextMode="MultiLine" Width="900" Font-Size="Medium"></asp:TextBox>
                </td>
            </tr>

            <asp:Panel ID="Pnloptions" runat="server">
                <tr>
                    <td class="TableHeader" colspan="4" style="font-size: small; text-decoration: underline"><strong>Options:</strong></td>
                </tr>
                <tr>
                    <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 1:</span></strong></td>
                    <td class="TableGrid">
                        <asp:TextBox ID="txtoption1" runat="server" OnTextChanged="txtoption1_TextChanged" Width="348px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 2:</span></strong>&nbsp;</td>
                    <td class="TableGrid">
                        <asp:TextBox ID="txtoption2" runat="server" Width="348px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 3:</span></strong></td>
                    <td class="TableGrid">
                        <asp:TextBox ID="txtoption3" runat="server" Width="348px"></asp:TextBox>
                    </td>
                    <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 4:</span></strong></td>
                    <td class="TableGrid">
                        <asp:TextBox ID="txtoption4" runat="server" Width="348px"></asp:TextBox>
                    </td>

                </tr>
            </asp:Panel>

            <tr>

                <asp:Panel ID="PnlCheckBox" runat="server">
                    <%--  <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                <asp:ListItem  Value="Option 1"></asp:ListItem>
                <asp:ListItem  Value="Option 2"></asp:ListItem>
                <asp:ListItem  Value="Option 3"></asp:ListItem>
                <asp:ListItem  Value="Option 4"></asp:ListItem>
            </asp:CheckBoxList>--%>
                    <tr>
                        <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 1</span></strong></td>
                        <td class="TableGrid">
                            <asp:TextBox ID="TxtChans1" runat="server" Width="348px"></asp:TextBox>
                        </td>
                        <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 2</span></strong></td>
                        <td class="TableGrid">
                            <asp:TextBox ID="TxtChans2" runat="server" Width="348px"></asp:TextBox>
                        </td>
                        <tr>
                            <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 3</span></strong></td>
                            <td class="TableGrid">
                                <asp:TextBox ID="TxtChans3" runat="server" Width="348px"></asp:TextBox>
                            </td>
                            <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 4</span></strong></td>
                            <td class="TableGrid">
                                <asp:TextBox ID="TxtChans4" runat="server" Width="348px"></asp:TextBox>
                            </td>
                        </tr>
                    </tr>


                </asp:Panel>


            </tr>
            <tr>
                <td>
                    <%-- <asp:Panel ID="PnlTrueorFalse" runat="server">
                <asp:RadioButton ID="RDTrue" Text="True" runat="server" />
                <asp:RadioButton ID="RDFlase" Text="False" runat="server" />

            </asp:Panel>--%>
                </td>
            </tr>
            <tr>
                <asp:Panel ID="PnlCorrectAns1" runat="server">
                    <td class="TableTitle" colspan="1"><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
                    <td class="TableGrid" colspan="1"><%--<asp:TextBox ID="txtanswer" runat="server" Width="348px"></asp:TextBox>--%>
                        <asp:DropDownList ID="DDlAns" runat="server" Width="442px">
                        </asp:DropDownList>
                    </td>
                </asp:Panel>

                <asp:Panel ID="PnlCorrectAns2" runat="server">
                    <td class="TableTitle" colspan="1"><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
                    <td class="TableGrid" colspan="1"><%--<asp:TextBox ID="txtanswer" runat="server" Width="348px"></asp:TextBox>--%>
                        <asp:DropDownList ID="DDlAns2" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="True" Text="True"></asp:ListItem>
                            <asp:ListItem Value="False" Text="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlCorrectAns3" runat="server">
                    <td class="TableTitle" colspan="1"><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
                    <%-- <td class="TableTitle" style="height: 27px" colspan="1">
                    <asp:ListBox ID="lstbAns3" runat="server" SelectionMode="Multiple" Width="442px">
                    </asp:ListBox>
                </td>--%>
                    <td>
                        <asp:CheckBoxList ID="chklistoptions" runat="server">
                            <asp:ListItem Text="Option1">Option 1</asp:ListItem>
                            <asp:ListItem Text="Option2">Option 2</asp:ListItem>
                            <asp:ListItem Text="Option3">Option 3</asp:ListItem>
                            <asp:ListItem Text="Option4">Option 4</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>

                </asp:Panel>
                <td class="TableTitle" style="width: 120px">
                    <asp:Label ID="LblMarks" runat="server" Style="font-weight: 700; font-size: small" Text="Marks :"></asp:Label>
                </td>
                <td class="TableGrid">
                    <asp:DropDownList ID="ddlmarks" runat="server" Width="50px">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                    <%-- </td>
                      <td class="TableGrid"></td>--%>
            </tr>
            <tr>
                <td class="TableGrid" colspan="4">
                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Save" />

                    &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update" />
                </td>
                <td colspan="2">&nbsp;</td>

                <td style="width: 4px">&nbsp;</td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnqnno" runat="server" />
    </asp:Panel>

    <table>
        <tr>
            <td style="width: 120px" class="TableTitle">&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;
                          <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Back" />
            </td>
        </tr>
    </table>

</asp:Content>

