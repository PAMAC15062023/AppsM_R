<%@ Page Language="C#" MasterPageFile="~/Employeemanagement/MasterPage2.master" AutoEventWireup="true" CodeFile="Birthdayemail.aspx.cs" Inherits="Employeemanagement_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%">                  
                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="White" ForeColor="#284775" Font-Italic="True" Font-Bold="True"  />
                        <EditRowStyle BackColor="White" Font-Italic="True"  Font-Bold="True" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="#284775"  />
                        <PagerStyle BackColor="White" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"  />
                        <HeaderStyle BackColor="White" ForeColor="White" Font-Bold="True"  />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Font-Bold="True" />
                 
                    </asp:GridView>
  
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:LinkButton ID="Email" runat="server" OnClick="Email_Click">Email</asp:LinkButton>
    <asp:LinkButton ID="Email1" runat="server" OnClick="Email1_Click">Email1</asp:LinkButton>
    <asp:LinkButton ID="Email2" runat="server" OnClick="Email2_Click">Email2</asp:LinkButton>
   
                    

</asp:Content>

