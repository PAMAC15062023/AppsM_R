<%@ Page Language="C#" MasterPageFile="~/PAMAC HOME OFFICE/PAMAC HOME OFFICE/MasterPage.master" AutoEventWireup="true"
    CodeFile="FTP_FileView.aspx.cs" Inherits="FTP_FTP_Dynamic_FTP_FileView" Title="FTP File View"
    StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js">

    </script>

    <script language="javascript" type="text/javascript">

    function WindowOpen(FileID)
    {
         
       //window.showModalDialog("FileSharing.aspx?1="+FileID,"_blank", "height=350,width=700,status=yes,resizable=no");
       window.open("FileSharing.aspx?1="+FileID,"_blank", "height=450,width=700,status=yes,resizable=no");
        return false;
    }
    function WindowOpen1(FileID)
    {
         
       //window.showModalDialog("FileSharing.aspx?1="+FileID,"_blank", "height=350,width=700,status=yes,resizable=no");
       window.open("Report.aspx?1="+FileID,"_blank", "height=450,width=700,status=yes,resizable=no");
        return false;
    }
    
    function ValidControl()
    {
        var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
        
        var ErrorMsg="";
        var ReturnValue=true;
        
        if(txtToDate.value=='')
        {
           ErrorMsg='Please select To Date'
           txtToDate.focus(); 
           ReturnValue=false;
        }
        if(txtFromDate.value=='')
        {
           ErrorMsg='Please select From Date'
           txtFromDate.focus(); 
           ReturnValue=false;
        }
        lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {
            window.scroll(0,0) 
        }
        return ReturnValue;
    }
    
    
    
function TABLE1_onclick() {

}

    </script>

    <table width="100%" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="height: 6px" colspan="8">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 6px" class="topbar" colspan="8">
                FTP File Upload Views</td>
        </tr>
        <tr>
            <td colspan="2" style="height: 316px; width: 250px;">
                <table>
                    <tr>
                        <td class="tta" colspan="2" style="height: 36px">
                Redefine your search</td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 123px; height: 36px">
                Upload From Date <span style="color: #ff3300">*</span></td>
                        <td class="Info" style="width: 133px; height: 36px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 111px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 123px; height: 36px">
                Upload To Date <span style="color: #ff3300">*</span></td>
                        <td class="Info" style="width: 133px; height: 36px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 111px">
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="76px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px">
                            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 123px; height: 36px">
                File Name</td>
                        <td class="Info" style="width: 133px; height: 36px">
                <asp:TextBox ID="txtFileName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 123px; height: 36px">
                File Extension</td>
                        <td class="Info" style="width: 133px; height: 36px">
                <asp:TextBox ID="txtFileExt" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="tta" colspan="2" style="height: 36px">
                <asp:Button ID="btnSearch" runat="server" Height="26px" OnClick="btnSearch_Click"
                    Text="Search" Width="84px" Font-Bold="True" />&nbsp;
                <asp:Button ID="btnClear" runat="server" Height="26px" Text="Clear" Width="84px"
                    OnClick="btnClear_Click" Font-Bold="True" /></td>
                    </tr>
                </table>
            </td>
            <td colspan="6" style="width: 100%; height: 316px;" valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both" Width="100%">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" Width="100%" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="File_ID">
                        <ItemTemplate>
                            <table cellpadding="2" cellspacing="1" class="reportTitleIncome">
                                <tr>
                                    <td style="width: 100px; text-align: center" align="center">
                                        <asp:ImageMap ID="IMap" runat="server" ImageUrl='<%# (DataBinder.Eval(Container.DataItem,"FileType"))%>'
                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>'>
                                            <asp:RectangleHotSpot Bottom="1" HotSpotMode="Inactive" Left="1" Right="1" Top="1" />
                                        </asp:ImageMap></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 18px" align="center">
                                        <asp:Label ID="lblFileDetails" runat="server" BorderStyle="None" CssClass="ta" Text='<%# (DataBinder.Eval(Container.DataItem,"FileName"))%>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkShare" runat="server"  CssClass="linkNew" >Share</asp:LinkButton>                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkDownload" runat="server" CssClass="linkNew" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"FilePath"))%>' OnClick="lnkDownload_Click" >Download</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <strong>
                                <table cellpadding="1" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td class="tta" style="width: 7%">
                                            <img src="../../Images/Briefcase1.jpg" style="height: 32px" /></td>
                                        <td class="tta">
                                            My Briefcase</td>
                                        <td class="tta">
                                        </td>
                                    </tr>
                                </table>
                            </strong>
                        </HeaderTemplate>
                    </asp:DataList></asp:Panel>
            </td>
        </tr>
       <%-- <tr>
            <td class="tta" colspan="6" rowspan="1" style="width: 100%">
                Your Shared File</td>
            <td colspan="1" rowspan="1" style="height: 27px; width: 3px;">
            </td>
        </tr>--%>
        
        
        
        
  </table>
    <table style="width: 1162px">
        <tr>
            <td class="topbar" colspan="7" style="height: 21px">
                            Download Files 
            </td>
        </tr>
        <tr>
            <td colspan="7">
              
              
              
                <asp:Panel ID="Panel3" runat="server" Height="335px"  Width="1250px" ScrollBars="vertical">
                                       <asp:DataList ID="DataList2" runat="server" Height="13px" RepeatColumns="4" 
                        Width="1189px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="0" GridLines="Both" >
                        <ItemTemplate>
                            <table cellpadding="1" cellspacing="1" style="width: 57px">
                                <tr>
                                    <td style="height: 25px" align="center" colspan="2">
                                        &nbsp;<asp:ImageMap ID="IMap" runat="server" ImageUrl='<%# (DataBinder.Eval(Container.DataItem,"FileType"))%>'
                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>' Height="18px" OnClick="IMap_Click" Width="18px">
                                            <asp:RectangleHotSpot Bottom="2" HotSpotMode="Inactive" Left="2" Right="2" Top="2" />
                                        </asp:ImageMap>
                                        <asp:LinkButton ID="lnkView" runat="server" Font-Size="7pt" Font-Underline="True"
                                            ForeColor="#0000FF" OnClick="lnkView_Click" Text='<%# (DataBinder.Eval(Container.DataItem,"FileName")) %>' CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"FilePath")) %>'></asp:LinkButton></td>
                      </tr> 
                                <tr>
                                    <td align="center" colspan="2" style="height: 25px">
                                                                
                               <asp:Label ID="lblname" runat="server"  Font-Size="Small" ForeColor="Red" Width="187px" Text='<%# (DataBinder.Eval(Container.DataItem,"fullname")) %>'></asp:Label></td>
                                </tr>
                                
                            </table>
                            &nbsp;&nbsp;
                            <br />
                            <br />
                        </ItemTemplate>
                       
                        
                        
                     
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <ItemStyle ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:DataList></asp:Panel>
                    <asp:GridView ID="GVshareData" runat="server" SkinID="gridviewSkin" Width="100%" Visible="false">
                    </asp:GridView>
            </td>
        </tr>
    </table>
    
</asp:Content>
