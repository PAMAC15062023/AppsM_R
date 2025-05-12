<%@ Page Language="C#" MasterPageFile="~/HO_ADMIN/SHARES/MasterPage.master" AutoEventWireup="true" CodeFile="ShareHolderDetails_view.aspx.cs" Inherits="HO_ADMIN_SHARES_ShareHolderDetails_view" Title="Share Holder Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
 <script type="text/javascript" src="../../popcalendar.js"></script>
 <script type="text/javascript" language="javascript">

        function Validate_modify(Value)
        {
        
        var CheckCount=0;
        //debugger;
        var grvTransactionInfo=document.getElementById("<%=grvTransactionInfo.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
          
        var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[1];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {
                                                                  
                             CheckCount=CheckCount+1;
                            }
                            
                            
                        }
                    }
                }
            
             }
            
           var ErrorMessage='';
           var returnValue=true;
           
             if (CheckCount==0)      
                {                
                    ErrorMessage='Please select atleast one record to modify!';
                    returnValue=false;
                }
                
            if (Value=='1')
           {
                  
             if (CheckCount>1)      
                {                
                    ErrorMessage='You can not select more than one record to modify!';
                    returnValue=false;
                }
            }
            
        
            
            lblMessage.innerText=ErrorMessage;
            return returnValue;
        }
        
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
                   img.alt = "Close to view Shares Details";
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
                         mce_src="Images/open.png";
                           
                       }
                   img.alt = "Expand to show Share Details";
               }
       }


             function SelectAll()
                {

                    var MainTab=document.getElementById("MainTab");
                    var chkSelectAll=document.getElementById("chkSelectAll");            
                    var i=0;

                    for(i=0;i<=MainTab.rows.length-1;i++)
                    {                  
                        var row = MainTab.rows[i];                
                        var chkObj=row.cells[0].childNodes[0];              
                       
                        if (chkObj!=null)
                        {  
                             chkObj.checked= chkSelectAll.checked; 
                        }
                    }
                     
                }
 </script>
    <table>
        <tr>
            <td colspan="9">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="9">
                &nbsp; Share Holder Details View</td>
        </tr>
        <tr>
            <td style="width: 36px; height: 23px">
                &nbsp;
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 23px">
                <asp:Label ID="Label1" runat="server" Text="Share Holder Name" Width="120px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:TextBox ID="txtShareHolderName" runat="server"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 23px">
                Folio No</td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:TextBox ID="txtFolioNo" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 36px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Dist No</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtDistNo" runat="server"></asp:TextBox></td>
            <td class="reportTitleIncome">
                &nbsp;Certificate No</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtCertificateNo" runat="server"></asp:TextBox></td>
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
            <td style="width: 36px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Allotment From Date</td>
            <td class="Info" style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtAllotmentFromDate" runat="server" MaxLength="10" Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAllotmentFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome">
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Allotment To Date " Width="119px"></asp:Label></td>
            <td class="Info" style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 98px; height: 20px">
                    <tr>
                        <td style="width: 94px; height: 20px">
                            <asp:TextBox ID="txtAllotmentToDate" runat="server" MaxLength="10" Width="62px"></asp:TextBox>&nbsp;</td>
                        <td style="width: 100px; height: 20px">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAllotmentToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 18px" /></td>
                    </tr>
                </table>
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
            <td class="tta" colspan="9">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />&nbsp;</td>
        </tr>
        <tr>
            <td colspan="9" style="height: 9px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9">
                &nbsp;Share Certificate Details</td>
        </tr>
        <tr>
            <td colspan="9">
                <div style="overflow: scroll; width: 100%; height: 265px">
                <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="ShareHolder_ID" Font-Size="8pt" OnRowDataBound="grv_RowDataBound"
                        PageSize="20" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("ShareHolder_ID") %>', 'one');" style="border-top-style: none;
                                        border-right-style: none; border-left-style: none; background-color: #ffffff;
                                        border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("ShareHolder_ID") %>' alt="Click to show/hide transaction details"
                                            src="../../Images/open.png"
                                            style="border-top-style: none; border-right-style: none; border-left-style: none;
                                            border-bottom-style: none" /></a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("ShareHolder_ID") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("ShareHolder_ID") %>' alt="Click to show/hide transaction details"
                                            src="../../Images/open.png"
                                            style="border-top-style: none; border-right-style: none; border-left-style: none;
                                            border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField DataField="ShareHolderName" HeaderText="ShareHolder Name" />
                                <asp:BoundField DataField="Father/Husband Name" HeaderText="Father /Husband Name" />
                                <asp:BoundField DataField="Residence" HeaderText="Residence" />
                                <asp:BoundField DataField="Folio_No" HeaderText="Folio No" /> 
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("ShareHolder_ID") %>' style="display: none; position: inherit; left: 15px;
                                                overflow: scroll;">
                                                <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="DetailID"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                                        <asp:BoundField DataField="Allotment_Date" DataFormatString="{0:MMM-dd-yyyy}" HeaderText="Allotment_Date"
                                                            HtmlEncode="False" />
                                                        <asp:BoundField DataField="Certificate_No" HeaderText="Certificate_No" />
                                                        <asp:BoundField DataField="Dist_No" HeaderText="Dist_No" />
                                                        <asp:BoundField DataField="No_of_Shares" HeaderText="No_of_Shares" />
                                                        <asp:BoundField DataField="Rate_Per_Share" HeaderText="Rate_Per_Share" />
                                                         <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                         <asp:BoundField DataField="AmountInWord" HeaderText="AmountInWord" />                                                         
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
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
                        <HeaderStyle Font-Names="Tahoma" Font-Size="8pt" CssClass="topbar" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 24px" class="tta">
                &nbsp;
                <asp:Button
                    ID="btnModify" runat="server" Text="Modify" OnClick="btnModify_Click" Width="79px" />
                <asp:Button
                    ID="btnView" runat="server" Text="View" OnClick="btnView_Click" Width="74px" />
                <asp:Button
                    ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" Width="68px" />
                <asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="73px" /></td>
        </tr>
        <tr>
            <td style="width: 36px">
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="ShareHolderID" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td>
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
            <td style="width: 36px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
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
            <td style="width: 36px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
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
            <td style="width: 36px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
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

