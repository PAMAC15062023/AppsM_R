<%@ Page Title="" Language="C#" MasterPageFile="~/RESDOT_Master_M.Master" AutoEventWireup="true" CodeBehind="mysample.aspx.cs" Inherits="RESDOT.mysample" %> <%--RESDOT_Master_M.Master--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <%--<link rel="Stylesheet" type="text/css" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" />--%>

    <script language="javascript" type="text/javascript">

        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };
        //function DisableBackButton() {
        //    window.history.forward()
        //}
        //DisableBackButton();
        //window.onload = DisableBackButton;
        //window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        //window.onunload = function () { void (0) }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        $('#mySelect').change(function () {
            alert('You selected: ' + $(this).val());
        });
        $(function () {
            $(".datepicker").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'SmallCalendar.gif',
                dateFormat: 'dd/mm/yy'

            });

        });
    </script>
    <link rel="stylesheet" href="MultiSelectDDL/bootstrap-multiselect.css2.css">
    <script src="MultiSelectDDL/bootstrap-multiselect.js2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lst]').multiselect({
                includeSelectAllOption: true
                // maxHeight: 5000;
            });
        });
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <table border="0" cellpadding="2" cellspacing="2" style="width: 100px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="300%" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>


    <table width="100px">
        <asp:UpdatePanel ID="pnlArea" runat="server" align="left">
            <%--align add on 18/12/23--%>
            <ContentTemplate>
                <asp:PlaceHolder ID="ControlM" runat="server"></asp:PlaceHolder>

                <div> <%--div add on 22/03/2024--%>
                    <table id="TopMenus"> <%--table add on 22/03/2024--%>
                        <tr align="left">  <%--align="left" add on 11/03/2024--%>
                            <td class='TableTitle' style='width: 100px' id="tdzone" runat="server" visible="false">
                                <asp:Label ID="lblzonenew" runat="server" Text="ZONE" Visible="false" class='TableTitle' Style='width: 100px'></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddAreas" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddAreas_SelectedIndexChanged" Visible="false">
                                </asp:DropDownList>
                            </td>
                            <td width="100px"></td> <%--td add on 22/03/2024--%>
                            <td class='TableTitle' style='width: 100px' id="tdcenter" runat="server" visible="false">
                                <asp:Label ID="lblcenterNew" runat="server" Text="Center" class='TableTitle' Style='width: 100px' Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCenterNew" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCenterNew_SelectedIndexChanged" Visible="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left"><%--align="left" add on 11/03/2024--%>
                            <td class='TableTitle' style='width: 100px' id="tdsubcenter" runat="server" visible="false">
                                <asp:Label ID="lblsubcenternew" runat="server" Text="SubCenter" class='TableTitle' Style='width: 100px' Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlsubcenternew" runat="server" Visible="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table> <%--table add on 22/03/2024--%>
                </div>  <%--div add on 22/03/2024--%>

                <asp:PlaceHolder ID="PlaceholderControls" runat="server">

                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </table>

    <br />
    <%--add on 18/12/23--%>


    <%-- </asp:Panel>--%>

    <table>
        <tr>
            <asp:GridView ID="grv1" runat="server" CssClass="mGrid" Visible="true" Style="text-align: left"
                AllowPaging="True" PageSize="20" OnPageIndexChanging="grv1_PageIndexChanging">

                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            <input id="chkSelectAll" type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            EXCEL
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkexcel" runat="server" Visible="true" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            PDF
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPDF" runat="server" Visible="true" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                        <HeaderTemplate>
                            DOC
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkDOC" runat="server" Visible="true" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px"> <%--150px--%>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkWIP" runat="server"  Font-Bold="True" OnClick="lnkWIP_Click">
                                <img src="edit.png" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lblexcel" runat="server" Text="Excel" Visible="false"></asp:Label><input id="SelectAll" type="checkbox" visible="false"  />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkexcel" runat="server" Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </tr>
    </table>
    <asp:HiddenField ID="hdnMenuId" runat="server" />
    <asp:HiddenField ID="hdnIspostback" runat="server" />

    
    

</asp:Content>
