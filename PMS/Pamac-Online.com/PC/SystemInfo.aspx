<%@ Page Title="" Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="SystemInfo.aspx.cs" StylesheetTheme="SkinFile" Inherits="PC_SystemInfo" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<head>
    <title>Untitled Page</title>
    
<style type="text/css">
   .hiddencol { display: none; }
</style>
</head>
<body>
    <form id="form1"  >
    <div>
        
         <table style="width: 98%; height: 152px;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
                <asp:Label ID="Label1" runat="server" BackColor="#FFFFCC" Font-Bold="True" 
                    Text="lblmsgstatus" Visible="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="4" style="height: 22px">
                System Report</td>
            </tr>
            <tr>
            <td class="reportTitleIncome"  style="height: 32px; width: 121px;">
            
                <strong>Machine Name </strong> </td>
            <td class="Info" style="height: 32px; width: 122px;">
            
                <asp:TextBox ID="txtmachine" runat="server"></asp:TextBox>
            
            </td>
           <td class="reportTitleIncome" style="width: 126px; height: 32px;">
           
               <strong>Monitor Pamac Id </strong> </td>
               <td class="Info" style="height: 32px">
               
                <asp:TextBox ID="txtmonitor" runat="server"></asp:TextBox>
            
               </td>
            </tr>
            <tr class="TableTitle">
            <td style="height: 38px" class="reportTitleIncome">
            
            
                <strong>Location</strong></td>
            <td class="Info" style="height: 38px; width: 122px;">
            
            
                <asp:DropDownList ID="monitorddl" runat="server" Height="25px" Width="103px" 
                   >
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="reportTitleIncome" style="width: 126px; height: 38px;" visible="False">
            
                </td>
                <td  class="Info" style="height: 38px">
                
            
                <asp:DropDownList ID="OSddl" runat="server" Height="25px" Width="103px" Visible="false">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>WINDOWS 7</asp:ListItem>
                    <asp:ListItem>WINDOWS XP</asp:ListItem>
                </asp:DropDownList>
                
                </td >
        
              </tr>
               <tr>
            <td class="tta" colspan="4" style="height: 30px">
                <asp:Button ID="Button1" BackColor="Black" 
                                            BorderColor="White" CssClass="button" 
                    ForeColor="White" runat="server" Text="Search" Width="111px" 
                    onclick="Button1_Click" style="height:25px"  />
&nbsp;&nbsp;
                <asp:Button ID="Button2" BackColor="Black" BorderColor="White" CssClass="button" ForeColor="White"  style="height: 25px" runat="server" Text="Cancel" OnClick="Button2_Click" Width="111px" />       
                &nbsp;&nbsp;
                                <asp:Button ID="btnexport" BackColor="Black" 
                    BorderColor="White" CssClass="button" ForeColor="White"  style="height: 25px" 
                    runat="server" Text="Export" Width="111px" onclick="btnexport_Click1" />       

                </td>
                
            </tr>
            
               
              </table>
        
         <br />
       
        <div style="overflow: scroll;  width: 887px; height: 217px">
         <asp:GridView ID="GridView1"  runat="server" Height="50px"   
                Font-Overline="False"  Font-Size="7.5pt" 
                AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                BorderStyle="Solid" CellPadding="4" CellSpacing="2" 
                ForeColor="Black" onrowdatabound="GridView1_RowDataBound1" >
             <Columns>
                 <asp:BoundField DataField="Verfy_status" HeaderText="Verfy_status" Visible="false"
                     ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"  >
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField DataField="Machine_Name" HeaderText="Machine_Name" />
                 <asp:BoundField DataField="User_Full_Name" HeaderText="User Full Name" />
                 <asp:BoundField DataField="Department" HeaderText="Department" />
                 <asp:BoundField DataField="Emp_Id" HeaderText="Emp Id" />
                 <asp:BoundField DataField="CPU_PAMAC_ID" HeaderText="CPU PAMAC ID" />
                 <asp:BoundField DataField="Machine_Name_System_Name" 
                     HeaderText="Machine System  Name " />
                 <asp:BoundField DataField="Monitor_Pamac_Id" HeaderText="Monitor Pamac Id" />
            
                 <asp:BoundField DataField="Rentail_Monitor_NO" 
                     HeaderText="Rentail Monitor NO" />
                 <asp:TemplateField>
                     <EditItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" />
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField ShowHeader="False" HeaderText="View">
                     <ItemTemplate>
                         <asp:ImageButton  ID="btnVerfication"  runat="server" CausesValidation="false" 
                             img src="View.png"  Height="20px" Width="20px" 
                             CommandName="" Text="Button" onclick="btnVerfication_click"  ></asp:ImageButton >
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="#424242" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
             <RowStyle BackColor="White" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <%--<SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />--%>
         </asp:GridView>
            <asp:HiddenField ID="hdnmachinename" runat="server" />
            <asp:HiddenField ID="hdnverify" runat="server" />
         </div>
         <br />
         <br />
        
     
       </div>
    </form>
</body>
</html>
    </asp:Content>