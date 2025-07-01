<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard2.aspx.cs" Inherits="Pamac_Projects.Dashboard2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script>
    function errorCheckChanged(chkBox){  
    var gridView = document.getElementById('<% =grdcases.ClientID %>');   
    var Elements = gridView.getElementsByTagName('input');   
    
    for(var i = 0; i < Elements.length; i++){
        if(Elements[i].type == 'checkbox' && Elements[i].id != chkBox.id && chkBox.checked)
            Elements[i].checked = false;
    }
        }
    </script>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Height="16px"
                            Visible="True" Width="100%" Font-Bold="True"></asp:Label>
        </div>

           <asp:GridView ID="grdcases" runat="server" AutoGenerateColumns="true" Visible="true"   
                    CssClass="mGrid" Width="711px" Height="37px">
                  <%--  <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectALL" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" onclick="errorCheckChanged(this)" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">GeneratePDF</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdelete" runat="server" Font-Bold="True" OnClick="lnkdelete_Click">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                      <%--  <asp:BoundField DataField="question" HeaderText="Question" />
                        <asp:BoundField DataField="Answer" HeaderText="Correct Answer" />
                        <asp:BoundField DataField="que_id" HeaderText="Question ID" />--%>
                    <%--</Columns>--%>
                </asp:GridView>
    </form>
</body>
</html>
