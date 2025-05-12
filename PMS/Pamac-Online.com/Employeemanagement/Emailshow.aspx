<%@ Page Language="C#" MasterPageFile="~/Employeemanagement/MasterPage2.master" AutoEventWireup="true" CodeFile="Emailshow.aspx.cs" Inherits="Employeemanagement_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
                    
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%">                  
                        <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="White" ForeColor="#284775" Font-Italic="True" Font-Bold="True"  />
                        <EditRowStyle BackColor="White" Font-Italic="True"  Font-Bold="True" />
                        <SelectedRowStyle BackColor="" Font-Bold="True" ForeColor="#284775"  />
                        <PagerStyle BackColor="White" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"  />
                        <HeaderStyle BackColor="White" ForeColor="White" Font-Bold="True"  />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Font-Bold="True" />
                 
                    </asp:GridView>
                    

 </asp:Content>

