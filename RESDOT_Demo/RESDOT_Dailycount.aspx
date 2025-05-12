<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RESDOT_Dailycount.aspx.cs" Inherits="RESDOT.RESDOT_Dailycount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pan1" runat="server" BorderStyle="solid" BorderWidth="1px" Width="150px" >
               <table cellpadding="2" cellspacing="1"  border="0"
                   <tr>
                       <td colspan="6" style="height: 26px">
                          <b style="text-align: center"> Daywise case allocated details</b>
                       </td>
                    </tr>

                    <asp:GridView ID="grv1" runat="server"  CssClass="mGrid"  Visible="true" >
                  <%-- <Columns>
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" 
                                    OnClick="lnkWIP_Click"   >
                                <img src="editing.jpg" /> </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>--%>
                   </asp:GridView>
                   <%--  AllowPaging="True" PageSize="20"  >--  onpageindexchanging="grv1_PageIndexChanging">                     --%>
                   <%--<tr>--%>
                      <%--   <td style="width: 133px; height: 22px; border:thick";>
                          <b style="text-align: center"> count</b>
                                        </td>--%>
                                        <%--<td style="height: 22px">--%>
                                       
                                         <%--   <asp:TextBox ID="txtUserName" runat="server" SkinID="txtSkin"
                                                Style="margin-left: 0px" Width="104px"></asp:TextBox--%>
                                        </td>
                                    
                                        <%--<td style="width: 6px; height: 22px;"></td>--%>
                                    <%--</tr>--%>
        </asp:Panel>
          
    </form>
</body>
</html>

