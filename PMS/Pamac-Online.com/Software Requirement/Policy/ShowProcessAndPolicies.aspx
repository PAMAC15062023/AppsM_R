<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Policy/MasterPage.master" AutoEventWireup="true" CodeFile="ShowProcessAndPolicies.aspx.cs" Inherits="Pages_SBM_ShowProcessAndPolicies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
         <tr>
            <td class="TableGrid" colspan="9" style="height: 22px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span
                style="font-size: medium"> <span style="color: #FF0000">View Process And Policies </span>
            </span></strong>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_Click" Width="10%" ForeColor="Black" Font-Bold="true" />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvFile" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvFile_RowDataBound"
                   BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="80%">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr.No"  ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Topic" HeaderText="Topic" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="FileName" HeaderText="File Name"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="FilePath" HeaderText="File Path"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField DataField="UploadDate" HeaderText="Upload Date"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbtnViewFile" runat="server" Text="View File" OnClick="lkbtnViewFile_Click" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   <FooterStyle BorderColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
