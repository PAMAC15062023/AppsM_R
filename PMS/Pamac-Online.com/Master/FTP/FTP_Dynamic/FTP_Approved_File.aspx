<%@ Page Language="C#" MasterPageFile="~/Master/FTP/FTP_Dynamic/MasterPage.master" AutoEventWireup="true" CodeFile="FTP_Approved_File.aspx.cs" Inherits="FTP_FTP_Dynamic_FTP_Approved_File" Title="Approved Upload File" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
   <script language="javascript" type="text/javascript">
     
     function Get_Validation_On_Search()
     {
         var txtRequestFrom=document.getElementById("<%=txtRequestFrom.ClientID%>");
         var txtRequestTo=document.getElementById("<%=txtRequestTo.ClientID%>");
                  
         var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
    
         var ReturnValue=true;
         var ErrorMessage='';
         
         if (txtRequestFrom.value=='')
         {
            ErrorMessage='Please enter to To Date to continue!';
            ReturnValue=false;
            txtRequestFrom.focus();
         }
         if (txtRequestTo.value=='')
         {
            ErrorMessage='Please enter to From Date to continue!';
            ReturnValue=false;
            txtRequestTo.focus();
         }
     
            window.scrollTo(0,0);    
            lblMessage.innerText=ErrorMessage;
           
           
           return ReturnValue;
    
     }
     
     
    function Get_SelectedTransactionID(ID)
    {
        //debugger;
        var grvFTP_RequestedData=document.getElementById("<%=grvFTP_RequestedData.ClientID%>");
        var hndRequestID=document.getElementById("<%=hndRequestID.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var ReturnValue=true;
        var ErrorMessage='';
        
         var cell;
           for (i=0;i<=grvFTP_RequestedData.rows.length - 1; i++)
            {
                cell = grvFTP_RequestedData.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {    
                                   
                                    if((grvFTP_RequestedData.rows[i].cells[8].innerText!='Pending')&&(ID==1))
                                    {
                                        ErrorMessage="you cannot modify selected entry!";
                                        ReturnValue=false;
                                    }
                                   
                                    if((grvFTP_RequestedData.rows[i].cells[8].innerText!='Pending')&&(ID==2))
                                    {
                                        ErrorMessage="you cannot modify selected entry!";
                                        ReturnValue=false;
                                    }
                                   
                                   
                                     hndRequestID.value=grvFTP_RequestedData.rows[i].cells[1].innerText;                                                                      
                                    
                                     break;
                            }
                        }
                    }
                }
            
             }
        
        
        
        if (hndRequestID.value=='0')
        {
            ErrorMessage="Please select atleast one record to continue!";
            ReturnValue=false;    
        
        }       
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);
        return ReturnValue;
        
    }
   
   
   function checkSelected(chkSelect)
      {
        //debugger;
        var grvFTP_RequestedData=document.getElementById("<%=grvFTP_RequestedData.ClientID%>");
        var chkSelect=document.getElementById(chkSelect);
         
         
        var cell;
           for (i=0;i<=grvFTP_RequestedData.rows.length - 1; i++)
            {
                cell = grvFTP_RequestedData.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {
                            if (cell.childNodes[j].checked ==true)
                            {
                                cell.childNodes[j].checked =false;
                            }
                            
                            
                        }
                    }
                }
            
             }
            
           
            chkSelect.checked=true;  
          
    }   
    
   
   </script>
    <table style="width: 787px">
        <tr>
            <td colspan="4" style="height: 19px">
                <asp:Label ID="lblMessage" runat="server" Width="555px" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 19px" class="topbar">
                Approved Upload File</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 90px; height: 15px;">
                <table style="width: 109px">
                    <tr>
                        <td style="width: 203px; height: 28px">
                Request from Date :</td>
                    </tr>
                </table>
            </td>
            <td class="Info" style="width: 293px; height: 15px;">
                <asp:TextBox ID="txtRequestFrom" runat="server" Width="105px" SkinID="txtSkin" Height="14px"></asp:TextBox>
                  <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtRequestFrom.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.png" style="width: 17px; height: 15px" />   </td>
            <td class="reportTitleIncome" style="width: 99px; height: 15px;">
                Request To Date :</td>
            <td class="Info" style="height: 15px">
                <asp:TextBox ID="txtRequestTo" runat="server" Width="105px" SkinID="txtSkin" Height="14px"></asp:TextBox>
  <img id="Img2" onclick="popUpCalendar(this, document.all.<%=txtRequestTo.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.png" /></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 90px; height: 17px;">
                Request By :</td>
            <td class="Info" style="width: 293px; height: 17px;">
                &nbsp;<table>
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged"
                    SkinID="txtSkin" Width="93px" AutoPostBack="True"></asp:TextBox></td>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlRequestBy" runat="server" SkinID="ddlSkin" Width="219px" Height="20px">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" style="width: 99px; height: 17px;">
                Status :</td>
            <td class="Info" style="height: 17px">
                <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin" Width="112px">
                    <asp:ListItem Value="3">-Select-</asp:ListItem>
                    <asp:ListItem Value="0">Pending</asp:ListItem>
                    <asp:ListItem Value="1">Accept</asp:ListItem>
                    <asp:ListItem Value="2">Reject</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="4" class="tta">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Font-Bold="True" Width="98px" OnClick="btnSearch_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" Font-Bold="True" Font-Italic="False" Width="97px" OnClick="btnReset_Click" /></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 6px">
                <asp:Label ID="lblCount" runat="server" CssClass="ErrorMessage" Text="Count" Visible="False"
                    Width="549px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px" Height="158px">
                <asp:GridView ID="grvFTP_RequestedData" runat="server" Height="1px" Width="996px" AutoGenerateColumns="False" OnRowDataBound="grvFTP_RequestedData_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Size="13pt">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="FTP_Request_ID" HeaderText="RequestID"  />
                                
                            <asp:TemplateField HeaderText="UploadNos">
                                <ItemTemplate>
                                   <asp:TextBox ID="txtUploadNos"  Width="60" runat="server" SkinID="txtSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"Authorize_UploadNos"))%>' ToolTip='<%# (DataBinder.Eval(Container.DataItem,"Authorize_UploadNos"))%>'></asp:TextBox>                                   
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                  
                             <asp:TemplateField HeaderText="ExpireDate">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 87px">
                                        <tr>
                                            <td style="width: 100px">
                                     <asp:TextBox ID="txtExpireDate" runat="server" Width="60" SkinID="txtSkin" Text='<%# (DataBinder.Eval(Container.DataItem,"ExpireDate"))%>' ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ExpireDate"))%>'></asp:TextBox></td>
                                            <td style="width: 100px">
                                     <asp:Image id="ImgExpireDate" runat="server"  AlternateText="Calendar" ImageUrl="~/Images/SmallCalendar.png" /></td>
                                        </tr>
                                    </table>
                                       
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="NoofFile" HeaderText="NoofFile"  />
                            <asp:BoundField DataField="Remark" HeaderText="Remark"  />
                            <asp:BoundField DataField="RequestDate" HeaderText="RequestDate"  />
                            <asp:BoundField DataField="RequestBy" HeaderText="RequestBy"  />
                            <asp:BoundField DataField="Status" HeaderText="Status"  />
                            <asp:BoundField DataField="AuthorizeDate" HeaderText="AuthorizeDate" />
                            <asp:BoundField DataField="AuthorizeBy" HeaderText="AuthorizeBy" />
                          
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <RowStyle Font-Size="8pt" ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Font-Size="X-Small" />
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tta" style="height: 48px">
                <asp:Button ID="btnAccept" runat="server" Text="Accept" Font-Bold="True" Width="89px" OnClick="btnAccept_Click" />
                &nbsp;&nbsp;<asp:Button ID="btnReject" runat="server" Text="Reject" Font-Bold="True" Width="89px" OnClick="btnReject_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="True" Width="104px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:HiddenField ID="hndRequestID" runat="server" Value="0" />
            </td>
            <td style="width: 99px">
            </td>
            <td>
            </td>
        </tr>
    </table>



</asp:Content>

