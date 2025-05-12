<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true"
    CodeFile="FE_PayoutProcess_Monthly.aspx.cs" Inherits="QueryBuilder_FE_PayoutProcess_Monthly"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

    <script language="javascript" type="text/javascript">
function checkSelected(chkSelect, GvDetails)
      {
      
      
        
        var chkSelect1=document.getElementById(chkSelect);
        var GvDetails1=document.getElementById(GvDetails);
         
         
  
                              var cellDetails;
                              for (m=0;m<=GvDetails1.rows.length - 1; m++)
                                {//for gvdetails
                                    cellDetails = GvDetails1.rows[m].cells[0];
                                    if (cellDetails!=null)
                                    {//if cell
                                        for (k=0; k<cellDetails.childNodes.length; k++)
                                            {  //for
                                              if (cellDetails.childNodes[k].type =="checkbox")
                                            {//chk
                                            
                                            cellDetails.childNodes[k].checked =chkSelect1.checked;
                                            
//                                                if (chkSelect1.checked ==true)
//                                                {//if
//                                                 cellDetails.childNodes[k].checked =true;
//                                                }//if
//                                                else if (chkSelect1.checked ==false)
//                                                {
//                                                  cellDetails.childNodes[k].checked=false;
//                                                }
                                                
                                                
                                                }
                                                
                                            } //for
                                    } //if cell                           
                                }//for gvdetails
                       
                    
    }//function  


       
        
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
                           img.src="../Images/close.png" ;
                            mce_src="../Images/close.png";
                       }
                   else 
                    
                       {
                           img.src="../Images/close.png" ;
                           mce_src="../Images/close.png";
                       }
                   img.alt = "Close to view FE Details";
               }
           else
               {
                   div.style.display = "none";
                   if (row=='alt')
                       {
                          
                           img.src="../Images/open.png" ;
                           mce_src="../Images/open.png";
                      }
                   else
                       {
                        img.src="../Images/open.png";
                         mce_src="../Images/open.png";
                           
                       }
                   img.alt = "Expand to show FE Details";
               }
       }
          
    

    </script>

    <table style="height: 179px; width: 1016px;">
        <tr>
            <td colspan="7" style="height: 18px">
                <strong><span style="font-size: 10pt">FE - PAYOUT PROCESS MONTHLY</span></strong></td>
        </tr>
        <tr>
            <td colspan="7" rowspan="" style="height: 23px">
                <asp:Label ID="lblMsg" runat="server" BackColor="White" Font-Bold="True" Font-Size="Larger"
                    ForeColor="Red" Width="1005px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 16px">
                Fe Name :</td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 24px; height: 16px">
            </td>
            <td style="height: 16px; width: 142px;">
                From Date :</td>
            <td colspan="1" style="width: 145px; height: 16px">
                To Date :</td>
            <td colspan="1" style="width: 145px; height: 16px">
            </td>
            <td colspan="1" style="width: 145px; height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 29px">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtFeName" runat="server" Width="98px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text=">>" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlFeName" runat="server">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
            <td style="width: 24px; height: 29px">
            </td>
            <td style="width: 142px; height: 29px">
                <table>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:TextBox ID="txtFromDate" runat="server" Width="104px"></asp:TextBox></td>
                        <td style="width: 100px; height: 26px;">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 145px; height: 29px; text-align: left;">
                <table>
                    <tr>
                        <td style="width: 100px; height: 27px;">
                            <asp:TextBox ID="txtToDate" runat="server" Width="104px"></asp:TextBox></td>
                        <td style="width: 100px; height: 27px;">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 29px">
            </td>
            <td style="width: 100px; height: 29px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    Width="100px" /></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 24px; height: 26px;">
            </td>
            <td style="width: 142px; height: 26px;">
            </td>
            <td style="width: 145px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 24px; height: 26px">
            </td>
            <td style="width: 142px; height: 26px">
            </td>
            <td style="width: 145px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                    <asp:GridView ID="GV1" runat="server" Width="797px" AutoGenerateColumns="False" BackColor="#FFFFC0"
                        OnRowDataBound="GV1_RowDataBound" BorderColor="Blue" BorderStyle="Outset" ForeColor="Maroon">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'one');" style="border-top-style: none;
                                        border-right-style: none; border-left-style: none; background-color: #ffffff;
                                        border-bottom-style: none">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="../Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" /></a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("AutoNo") %>', 'alt');">
                                        <img id='imgdiv<%# Eval("AutoNo") %>' alt="Click to show/hide transaction details"
                                            src="../Images/open.png" style="border-top-style: none; border-right-style: none;
                                            border-left-style: none; border-bottom-style: none" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FE_Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FE_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkFeName" runat="server" CommandArgument='<%#Bind("FE_Id") %>'
                                        Text='<%# Bind("FE_Name") %>' Width="51px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Cases" HeaderText="Cases" />
                            <asp:BoundField DataField="ICL" HeaderText="ICL" />
                            <asp:BoundField DataField="OCL" HeaderText="OCL" />
                            <asp:BoundField DataField="Special_Rate" HeaderText="Special_Rate" />
                            <asp:BoundField DataField="TPC1" HeaderText="TPC1" />
                            <asp:BoundField DataField="TPC2" HeaderText="TPC2" />
                            <asp:BoundField DataField="Documents" HeaderText="Documents" />
                            <asp:BoundField DataField="Penalty" HeaderText="Penalty" />
                            <asp:BoundField DataField="Total_Pay" HeaderText="Total_Pay" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("AutoNo") %>' style="display: none; position: relative; left: 15px;">
                                                <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Fe_Id"
                                                    EmptyDataText="No Records." Font-Names="Verdana" Font-Size="7.5pt" ForeColor="Black"
                                                    GridLines="Horizontal" Width="80%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                        <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Product" HeaderText="Product" />
                                                        <asp:BoundField DataField="Case_id" HeaderText="Case_id" />
                                                        <asp:BoundField DataField="Ref_No" HeaderText="Ref_No" />
                                                        <asp:BoundField DataField="AppliName" HeaderText="AppliName" />
                                                        <asp:BoundField DataField="Verification_type_code" HeaderText="Verification_type_code" />
                                                        <asp:BoundField DataField="Client_Name" HeaderText="Client Name" />
                                                        <asp:BoundField DataField="FeName" HeaderText="FeName" />
                                                        <asp:BoundField DataField="Area_Name" HeaderText="Area_Name" />
                                                        <asp:BoundField DataField="Fixed_ICLRate" HeaderText="Fixed_ICLRate" />
                                                        <asp:BoundField DataField="Fixed_OCLRate" HeaderText="Fixed_OCLRate" />
                                                        <asp:BoundField DataField="Special_Rate" HeaderText="Special_Rate" />
                                                        <asp:BoundField DataField="TPC1_Rate" HeaderText="TPC1_Rate" />
                                                        <asp:BoundField DataField="TPC2_Rate" HeaderText="TPC2_Rate" />
                                                        <asp:BoundField DataField="Is_Document" HeaderText="Is_Document" />
                                                        <asp:BoundField DataField="Penalty" HeaderText="Penalty" />
                                                        <asp:BoundField DataField="TotalPay" HeaderText="TotalPay" />
                                                        <asp:BoundField DataField="AuthorizeBy" HeaderText="AuthorizeBy" />
                                                        <asp:BoundField DataField="AuthorizeDate" HeaderText="AuthorizeDate" />
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
                    </asp:GridView>
                </asp:Panel>
                <asp:HiddenField ID="hdnPayoutData" runat="server" />
                <asp:HiddenField ID="hdnFEID" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" Width="100px">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" /></td>
        </tr>
    </table>
</asp:Content>
