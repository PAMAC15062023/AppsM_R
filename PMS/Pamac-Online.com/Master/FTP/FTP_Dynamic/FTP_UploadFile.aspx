<%@ Page Language="C#" MasterPageFile="~/Master/FTP/FTP_Dynamic/MasterPage.master" AutoEventWireup="true"
    CodeFile="FTP_UploadFile.aspx.cs" Inherits="FTP_FTP_Dynamic_FTP_UploadFile" Title="FTP Upload File"
    StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

    <script language="javascript" type="text/javascript">

    function ValidationControl()
    {
        var txtFileNo=document.getElementById("<%=txtFileNo.ClientID%>");
        var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
       var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
       
        var ReturnValue = true;
        var ErroMsg = "";
              
        if(txtFileNo.value!='' && txtRemark.value=='')
        {
             ErroMsg='Please Type Remark';
             txtRemark.focus();
             ReturnValue=false;   
        }
        if(txtFileNo.value=='')
        {
             ErroMsg='Please Type File No';
             txtFileNo.focus();
             ReturnValue=false;   
        }
        
        lblMessage.innerText=ErroMsg;
        if(ErroMsg!='')
        {
            window.scrollTo(0,0); 
        }
        return ReturnValue;   
    }     
    
   
    </script>

    <table>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="6" style="height: 19px">
                &nbsp;Upload File View Status</td>
        </tr>
        <tr>
            <td class="bx" colspan="3" rowspan="2" valign="top">
                <table>
                    <tr>
                        <td class="tta" colspan="3" style="height: 16px">
                            <strong><span style="font-size: 9pt">New Upload File Request</span></strong></td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" colspan="1" style="width: 178px; height: 36px">
                            <asp:Label ID="Label1" runat="server" Text="File Nos." Width="79px"></asp:Label></td>
                        <td colspan="2" style="height: 36px" class="Info">
                            <asp:TextBox ID="txtFileNo" runat="server" SkinID="txtSkin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 178px; height: 36px">
                            Remark :</td>
                        <td colspan="2" style="height: 36px" class="Info">
                            <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                Width="215px"></asp:TextBox></td>
                    </tr>
                   <%--<tr>
                        <td class="reportTitleIncome" style="width: 178px; height: 36px">
                            Request By&nbsp;</td>
                        <td class="Info" colspan="2" style="height: 36px">
                            <asp:DropDownList ID="ddlEmpName" runat="server" SkinID="ddlSkin" Width="212px">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 178px; height: 36px">
                            Request To :</td>
                        <td class="Info" colspan="2" style="height: 36px">
                            <asp:DropDownList ID="ddlRequestBy" runat="server" Height="20px" SkinID="ddlSkin"
                                Width="219px">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>--%>
                    <tr>
                        <td colspan="3" class="tta">
                            &nbsp;
                            <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnSaveSkin" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td class="tta" colspan="3" style="height: 20px">
                            Recent Uploaded Files</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 20px">
                            <asp:Label ID="lblMessage2" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
                    </tr>
                </table>
                <div style="overflow: scroll; width: 331px; height: 150px">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CellPadding="4" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#333333">
                        <ItemTemplate>
                            <table cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 102px; text-align: center">
                                        <asp:ImageMap ID="IMap" runat="server" ImageUrl='<%# (DataBinder.Eval(Container.DataItem,"FileType"))%>'
                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>'>
                                            <asp:RectangleHotSpot Bottom="1" HotSpotMode="Inactive" Left="1" Right="1" Top="1" />
                                        </asp:ImageMap></td>
                                </tr>
                                <tr>
                                    <td style="width: 102px;" align="center">
                                        <asp:Label ID="lblFileDetails" runat="server" Text='<%# (DataBinder.Eval(Container.DataItem,"FileName"))%>'
                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>' BorderStyle="None"
                                            CssClass="ta"></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList></div>
            </td>
            <td colspan="3" rowspan="2" valign="top">
                <table class="sidebar" style="width: 100%">
                    <tr>
                        <td class="tta" colspan="8" style="height: 17px">
                            FTP File Upload</td>
                    </tr>
                    <tr>
                        <td colspan="8" style="height: 17px">
                            <asp:Label ID="lblFileUpload" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bx" colspan="8" style="height: 17px">
                            <div style="overflow: scroll; width: 603px; height: 302px">
                                <asp:Repeater ID="rptFileUpload" runat="server" OnItemDataBound="rptFileUpload_ItemDataBound">
                                    <HeaderTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="width: 40%">
                                                    <b>Select Upload File</b>
                                                </td>
                                                <td>
                                                </td>
                                               <td style="width: 60%">
                                                    <b>Content ExpireDate</b>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hdnFileID" runat="server" Value='<%# (DataBinder.Eval(Container.DataItem,"FileId"))%>' />
                                                    <asp:HiddenField ID="hdnRequestId" runat="server" Value='<%# (DataBinder.Eval(Container.DataItem,"RequestId"))%>' />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="FileUpload" runat="server" />
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtContentExpireDate" Width="75px" runat="server" Visible="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Image ID="ImgExpireDate" runat="server" AlternateText="Calendar" ImageUrl="~/Images/SmallCalendar.png" Visible="false"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                <hr />
                                                </td>
                                                 
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tta" colspan="8" style="height: 9px">
                            &nbsp;
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" SkinID="btnUploadSkin" OnClick="btnUpload_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="Close" SkinID="btnCancelSkin" Width="56px"
                                OnClick="btnClose_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td class="tta" colspan="6" rowspan="1" style="height: 21px">
                Upload File Request Tracker</td>
        </tr>
        <tr>
            <td colspan="6" rowspan="1">
                <asp:Panel ID="Panel3" runat="server" CssClass="sidebar" Direction="LeftToRight"
                    Height="198px" ScrollBars="Both" Width="96%">
                    <asp:GridView ID="GvUploadReq" runat="server" CellPadding="4" Font-Names="Verdana"
                        Font-Size="8pt" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="1">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnSumOfRequestFile" runat="server" />
</asp:Content>
