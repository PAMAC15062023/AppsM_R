<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RESDOT_Dashboard.aspx.cs" Inherits="RESDOT.RESDOT_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 305px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" BorderStyle="solid" BorderWidth="1px" Width="550px">
        
              <table cellpadding="2" cellspacing="1"  border="1" width="350px"
                  <tr>
                     <tr>
                         <td style="height: 26px" width:"350px"><b style="text-align: center">Daywise case allocated</b> </td>
                         <%--   <asp:Panel ID="Panel2" runat="server" BorderStyle="solid" BorderWidth="1px" Width="150px">
                          <td style="height: 26px" width:"150px"><b style="text-align: center">Cases Assigned to FE / Vendor</b> </td>
                        </asp:Panel>--%>
                     </tr>
                     <tr>
                         <asp:GridView ID="grv1" runat="server" CssClass="mGrid" Visible="true" Width="307px">
                             <Columns>
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:CheckBox ID="chkSelect" runat="server" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">
                                <img src="editing.jpg" /> </asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </tr>
                      
                     <%--   <asp:Panel ID="Panel2" runat="server" BorderStyle="solid" BorderWidth="1px" Width="150px">
                          <td style="height: 26px" width:"150px"=""><b style="text-align: center">Cases Assigned to FE / Vendor</b> </td>
                        </asp:Panel>--%>
                      <%--     <table cellpadding="2" cellspacing="1"  border="0"--%>
                   </table>

          </asp:Panel>

          <asp:Panel ID="Panel1A" runat="server" BorderStyle="solid" BorderWidth="1px" Width="150px" > 
               <table cellpadding="2" cellspacing="1"  border="0"
                   <tr>
                       <td colspan="6" style="height: 26px">
                          <b style="text-align: center"> case allocated details</b>
                       </td>
                    </tr>
                   <asp:GridView ID="grv2" runat="server"  CssClass="mGrid"  Visible="true" >
                         </asp:GridView>
        </asp:Panel>
    </form>
</body>
</html>

