<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="~/FRC/Employee Background Check/EBC_New_CaseStatusView.aspx.cs" Inherits="EBC_New_EBC_New_EBC_New_CaseStatusView" Title="Case Status View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
 function switchViews(obj,row)
        {
        //debugger;
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);
            
            if (div.style.display=="none")
                {
                    div.style.display = "inline";
                    if (row=='alt')
                       {
                           img.src="../../Images/close.png" ;
                            mce_src="../../Images/close.png";
                       }
                   else 
                    
                       {
                           img.src="../../Images/close.png" ;
                           mce_src="../../Images/close.png";
                       }
                   img.alt = "Close to view other customers";
               }
           else
               {
                   div.style.display = "none";
                   if (row=='alt')
                       {
                          
                           img.src="../../Images/open.png" ;
                           mce_src="../../Images/open.png";
                      }
                   else
                       {
                        img.src="../../Images/open.png";
                         mce_src="../../Images/open.png";
                           
                       }
                   img.alt = "Expand to show Transactions";
               }
       }

</script>   
    <table>
        <tr>
            <td colspan="12">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="12" style="height: 35px">
                &nbsp; EBC Case Status View</td>
        </tr>
        <tr>
            <td style="width: 50px; height: 4px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 4px">
                Case ID</td>
            <td class="Info" colspan="2" style="height: 4px">
                <asp:TextBox ID="txtCaseID" runat="server"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 4px">
                Ref. No.</td>
            <td class="Info" colspan="2" style="height: 4px">
                <asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 4px">
                Applicant Name</td>
            <td class="Info" colspan="2" style="height: 4px">
                <asp:TextBox ID="txtApplicantName" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 4px">
            </td>
            <td style="width: 100px; height: 4px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="12" style="height: 22px">
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" Font-Bold="True" OnClick="btnSearch_Click" />&nbsp;<asp:Button ID="btnReset"
                    runat="server" Text="Reset" Font-Bold="True" /></td>
        </tr>
        <tr>
            <td colspan="12" style="height: 183px">
            <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="4" DataKeyNames="Case_ID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20" ForeColor="Black" GridLines="Horizontal" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("Case_ID") %>', 'one');" style="border-top-style: none;
                                        border-right-style: none; border-left-style: none; background-color: #ffffff;
                                        border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("Case_ID") %>' alt="Click to show/hide transaction details"
                                            src="../../Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" /></a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("Case_ID") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("Case_ID") %>' alt="Click to show/hide transaction details"
                                            src="../../Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Case_ID" HeaderText="Case ID" SortExpression="Case ID" />
                            <asp:BoundField DataField="Receive_Case" HeaderText="Receive Date" SortExpression="RequestedAmount" />
                            <asp:BoundField DataField="Ref_NO" HeaderText="Ref No" SortExpression="Region_Name" />
                            <asp:BoundField DataField="Applicant_Name" HeaderText="Applicant" SortExpression="BranchName" />
                            <asp:BoundField DataField="Verification_Code" HeaderText="Verification Code" SortExpression="PaymentRequestDate" />
                            <asp:BoundField DataField="Send_Date" HeaderText="Send Date" SortExpression="Status" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("Case_ID") %>' style="display: none; position: inherit; left:15px; overflow: scroll;">
                                       <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="SubNormal"
                    DataKeyNames="Case_ID" EmptyDataText="No Records." Font-Names="Verdana" OnRowDataBound="grvDetails_RowDataBound"
                    Font-Size="7.5pt" ForeColor="Black" GridLines="Horizontal" Width="80%">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Case_id" HeaderText="Case ID" />
                        <asp:BoundField DataField="Verification_Type" HeaderText="Verification Type" />
                        <asp:BoundField DataField="Sub_Verification" HeaderText="Type" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                &nbsp;
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"Sub_Verification"))%>'></asp:LinkButton></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"Sub_Verification"))%>'></asp:LinkButton></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"Sub_Verification"))%>'></asp:LinkButton></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"Sub_Verification"))%>'></asp:LinkButton></td>
                                        <td style="width: 100px">
                                            <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"Sub_Verification"))%>'></asp:LinkButton></td>
                                    </tr>
                                </table>
                                &nbsp; &nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Names="Verdana"
                        Font-Overline="False" Font-Size="7.5pt" Font-Underline="False" ForeColor="White" />
                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle Font-Names="Tahoma" Font-Size="8pt" />
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                            ForeColor="White" />
                        
                    </asp:GridView>
                &nbsp;
                
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

