<%@ Page Title="" Language="C#" MasterPageFile="~/PP_Master.Master" AutoEventWireup="true" CodeBehind="PP_Dashboard.aspx.cs" Inherits="Pamac_Projects.PP_Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script language="javascript" type="text/javascript"> </script>

     <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">&nbsp;DASHBOARD</td>
        </tr>
          </table>
    <table>
    <td>           
        <asp:Panel ID="Pnlreq" runat="server" BorderColor="Black" Height="240px" ScrollBars="Both" Width="513px">
         
                <asp:Label ID="lblHeader1" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
            
            <asp:GridView ID="grv1" runat="server"  CssClass="mGrid"  style="overflow:scroll" Visible="true" 
                  AutoGenerateColumns="False"   AllowPaging="True" PageSize="20" Width="484px" >
                 <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                            <HeaderTemplate>
                                   <asp:label    ID="chkhead"  runat="server">EDIT</asp:label>
                                <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                         
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect1" runat="server" ItemStyle-Width="10px" AutoPostBack="true" onCheckedChanged="chkSelect1_CheckedChanged"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                            <%--<ItemTemplate>
                                  <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                              Action</asp:LinkButton>
                                
                            </ItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Act_no" HeaderText="ITEM nO."  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE"  ItemStyle-Width="110px"/>
                            <asp:BoundField DataField="PostedBy" HeaderText="Posted By"  ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Subject" HeaderText="Subject "  ItemStyle-Width="300px"/>
                           <asp:BoundField DataField="Act_Status" HeaderText="Current Status "  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                   </Columns>
                    </asp:GridView>
        
        </asp:Panel>
     </td>   
     <td>       <asp:Panel ID="PnlDiscussion" runat="server" BorderColor="Black" Height="240px" ScrollBars="Both" Width="487px">
                <asp:Label ID="lblHeader2" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
            
            <asp:GridView ID="grv2" runat="server"  CssClass="mGrid"  style="overflow:scroll" Visible="true" 
                             AllowPaging="True" PageSize="20" >
                  <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                            <HeaderTemplate>
                                   <asp:label    ID="chkhead"  runat="server">EDIT</asp:label>
                                <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                         
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect2" runat="server" ItemStyle-Width="10px" AutoPostBack="true" onCheckedChanged="chkSelect2_CheckedChanged"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                            <%--<ItemTemplate>
                                  <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                              Action</asp:LinkButton>
                                
                            </ItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Act_no" HeaderText="ITEM nO."  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE"  ItemStyle-Width="110px"/>
                            <asp:BoundField DataField="PostedBy" HeaderText="Posted By"  ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Subject" HeaderText="Subject "  ItemStyle-Width="300px"/>
                           <asp:BoundField DataField="Act_Status" HeaderText="Current Status "  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                   </Columns>
                    </asp:GridView>
         
    </asp:Panel>
      </td>  
    </table>
    <table>
        <td>
             <asp:Panel ID="PnlChanges" runat="server" BorderColor="Black" Height="240px" ScrollBars="Both" Width="508px">
                          <asp:Label ID="lblHeader3" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
            
            <asp:GridView ID="grv3" runat="server"  CssClass="mGrid"  style="overflow:scroll" Visible="true" 
                             AllowPaging="True" PageSize="20" Width="483px" >
                  <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                            <HeaderTemplate>
                                   <asp:label    ID="chkhead"  runat="server">EDIT</asp:label>
                                <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                         
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect3" runat="server" ItemStyle-Width="10px" AutoPostBack="true" onCheckedChanged="chkSelect3_CheckedChanged"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                            <%--<ItemTemplate>
                                  <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                              Action</asp:LinkButton>
                                
                            </ItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Act_no" HeaderText="ITEM nO."  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE"  ItemStyle-Width="110px"/>
                            <asp:BoundField DataField="PostedBy" HeaderText="Posted By"  ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Subject" HeaderText="Subject "  ItemStyle-Width="300px"/>
                           <asp:BoundField DataField="Act_Status" HeaderText="Current Status "  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                   </Columns>
                    </asp:GridView>
            
                   
                </asp:Panel>

        </td>
          <td>
                <asp:Panel ID="PnlBugs" runat="server" BorderColor="Black" Height="240px" ScrollBars="Both" Width="494px">
                <asp:Label ID="lblHeader4" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
            
            <asp:GridView ID="grv4" runat="server"  CssClass="mGrid"  style="overflow:scroll" Visible="true" 
                             AllowPaging="True" PageSize="20" Width="457px" >
                 <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px">
                            <HeaderTemplate>
                                   <asp:label    ID="chkhead"  runat="server">EDIT</asp:label>
                                <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                         
                            </HeaderTemplate>
                           
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect4" runat="server" ItemStyle-Width="10px" AutoPostBack="true" onCheckedChanged="chkSelect4_CheckedChanged"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                            <%--<ItemTemplate>
                                  <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                              Action</asp:LinkButton>
                                
                            </ItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Act_no" HeaderText="ITEM nO."  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE"  ItemStyle-Width="110px"/>
                            <asp:BoundField DataField="PostedBy" HeaderText="Posted By"  ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Subject" HeaderText="Subject "  ItemStyle-Width="300px"/>
                           <asp:BoundField DataField="Act_Status" HeaderText="Current Status "  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
                   </Columns>
                    </asp:GridView>
                     </asp:Panel>

          </td>
      </table>        
              

    

</asp:Content>
