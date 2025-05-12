<%@ Page Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true" CodeFile="Adminvisible.aspx.cs" Inherits="PC_Adminvisible"
    Title="Adminvisible." StylesheetTheme="SkinFile"%> 


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<%--
<script language="javascript" type="text/javascript" src="popcalendar.js"></script>--%>

    <script language="JAVASCRIPT" type="text/javascript">

    </script>


    <table style="width: 100%;">
       
        <tr>

            <td class="tta" colspan="4" style="height: 22px">
                SYSTEM REPORT
            </td>
            </tr>
            <tr>
            <td style="width: 20px; height: 16px;" class="reportTitleIncome">
                <strong>Report</strong>    </td>
            <td style="width: 87px" class="Info">
                <asp:DropDownList ID="ddlreport" runat="server" Height="25px" Width="129px" AutoPostBack="true" 
                    onselectedindexchanged="ddlreport_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>Verified</asp:ListItem>
                    <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>OS-Licence</asp:ListItem>
                    <asp:ListItem>Office Licence</asp:ListItem>
                    <asp:ListItem>OS-No Licence</asp:ListItem>
                    <asp:ListItem>Office No Licence</asp:ListItem>
                </asp:DropDownList>
                           </td>
            
            <td style="width: 72px" class="Info">
                <asp:Button ID="btnreport"   BackColor="Black" BorderColor="White" CssClass="button" 
                    ForeColor="White" runat="server" Text="Export" Width="111px" 
                    Height="30px" onclick="btnreport_Click" Visible="false" />
                </td>
                <td style="width: 145px" class="TableGrid">
                
                </td>
        </tr>
       <tr>
        <td style="height: 32px; width: 210px;" class="reportTitleIncome">
        
        
               <strong>Machine Name </strong> </td>
               <td  style="width: 87px" class="Info">
               
                   <asp:TextBox ID="txtmachinename" runat="server"></asp:TextBox>
               
               </td>
               <td style="width: 72px; height: 32px;" class="reportTitleIncome">
               
                   <strong>Location</strong></td>
               <td style="width: 87px" class="Info">
               
                   <asp:DropDownList ID="ddllocation" runat="server" Height="25px" 
                       style="margin-left: 0px" Width="112px">
                       <asp:ListItem Value="0">---Select---</asp:ListItem>
                   </asp:DropDownList>
               </td>
        </tr>
               <tr>
               
               <td class="tta" colspan="9" style="height: 30px">
                   <asp:Button ID="btnSearch" runat="server" Text="Search"  BackColor="Black" 
                       BorderColor="White" CssClass="button" ForeColor="White" Width="111px" 
                    Height="30px" onclick="btnSearch_Click"  />
<%--               </td>
               <td style="width: 127px; height: 11px;" class="TableGrid">--%>
                   <asp:Button ID="btncancel" runat="server" Text="Cancel" BackColor="Black" BorderColor="White" CssClass="button" ForeColor="White" Width="111px" 
                    Height="30px" OnClick="btncancel_Click1"/>
               </td>
               <td style="width: 72px; height: 11px;" class="TableGrid">
               
               
               </td>
               <td style="width: 127px; height: 11px;" class="TableGrid">
               
               
               </td>

               </tr>
      
       
       
        </table>
     <div style="overflow: scroll;  width: 950px; height: 217px">
                
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="#e1e9ff" BorderColor="#484848" BorderStyle="Solid"  
                    CellPadding="1" CellSpacing="1" ForeColor="Black" 
                    Width="773px">
                    <Columns>
                        <asp:BoundField DataField="Machine_Name" HeaderText="Machine Name" />
                        <asp:BoundField DataField="User_Full_Name" HeaderText="User Full Name" />
                        <asp:BoundField DataField="Emp_Id" HeaderText="Emp ID" />
                        <asp:BoundField DataField="Machine_Name_System_Name" 
                            HeaderText="Machine Name System" />
                      
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" Height="20px" Width="20px" OnClick="btnedit_click" img src="../PC/images.png"  CommandName="" Text="Button"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#484848" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099"  ForeColor="White" />
                 <%--   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="Gray" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />--%>
                </asp:GridView>
                
                <br />
                <br />
                
                </div>
              <asp:HiddenField ID="hdnmachinename" runat="server" />
</asp:Content>
