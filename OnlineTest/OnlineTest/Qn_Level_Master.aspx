<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="Qn_Level_Master.aspx.cs" Inherits="OnlineTest.Qn_Level_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table style="width: 1170px;">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" id="header1" runat="server" style="font-size: medium">Add Level</td>
        </tr>
      <%--  <tr>
            <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lblOption" runat="server" Text="Option:"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

         <%--   <td style="width: 120px" class="TableGrid">

                <asp:DropDownList ID="ddlOption" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged1">
                    <asp:ListItem Value="0">Select Option</asp:ListItem>
                    <asp:ListItem Value="1">NEW</asp:ListItem>
                    <asp:ListItem Value="2">EDIT</asp:ListItem>

                </asp:DropDownList>
            </td>--%>

       <%-- </tr>
        <tr>
            <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lblquestions" runat="server" Text="Select Question"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>--%>

           <%-- <td style="width: 50px" class="TableGrid">

                <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>--%>

        </tr>
        <%-- <tr>
             <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lblOption" runat="server" Text="Option:"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

               <td style="width: 120px" class="TableGrid">

                <asp:DropDownList ID="ddlOption" runat="server" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged" AutoPostBack="true">
                   <asp:ListItem Value="0">Select Option</asp:ListItem>
                    <asp:ListItem Value="1">NEW</asp:ListItem>
                    <asp:ListItem Value="2">EDIT</asp:ListItem>
              
                </asp:DropDownList>
            </td>--%>

        </tr>
       <%-- <tr>
             <td style="width: 122px" class="TableTitle">
                <asp:Label ID="lbluser" runat="server" Text="Select User"
                    Style="font-weight: 700; font-size: small"></asp:Label></td>

            <td style="width: 66px" class="TableGrid">

                <asp:DropDownList ID="ddlusers" runat="server" OnSelectedIndexChanged="ddlusers_SelectedIndexChanged" AutoPostBack="true">
            
                </asp:DropDownList>
            </td>

        </tr>--%>
    </table>
    <asp:Panel ID="Mainpanel" runat="server">
        <table>

            <tr>

                <td class="TableTitle"><strong><span style="font-size: small">Level Name:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtLevel" runat="server" Width="348px"></asp:TextBox>

                </td>
               <%-- <td class="TableTitle"><strong><span style="font-size: small">Designation Code:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtDsigCode" runat="server" Width="348px"></asp:TextBox>--%>
            </tr>
            <tr>
                <td colspan="1" class="TableTitle">
                    <strong><span style="font-size: small">Is Active :</span></strong>
                    <td style="width: 100px; height: 22px;">
                       <asp:CheckBox ID="chbIsactive" runat="server" />
                </td>

            </tr>
            <tr>
                <td colspan="4" class="TableGrid">
                    <asp:Button ID="btnsubmit" runat="server"
                        Text="Save" OnClick="btnsubmit_Click" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server"
                    Text="Back" OnClick="btncancel_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
             <%--   <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />--%>
                </td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnqnno" runat="server" />



    </asp:Panel>

    <asp:GridView ID="GrdLevel" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="351px" BackColor="White" BorderColor="#999999"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataKeyNames="ID">       

        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" OnClick="btn_Edit_Click1" /><%-- OnClick="btn_Edit_Click1"--%>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="LevelID">
                <ItemTemplate>
                    <asp:Label ID="lblLevelID" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Level Name">
                <ItemTemplate>
                    <asp:Label ID="lblLevelName" runat="server" Text='<%#Eval("LevelName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>          

            <asp:TemplateField HeaderText="IsActive">
                <ItemTemplate>
                    <asp:Label ID="LblIsActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>



    </asp:GridView>




</asp:Content>
