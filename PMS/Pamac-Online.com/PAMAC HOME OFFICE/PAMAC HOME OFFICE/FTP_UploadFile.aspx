<%@ Page Language="C#" MasterPageFile="~/PAMAC HOME OFFICE/PAMAC HOME OFFICE/MasterPage.master" AutoEventWireup="true"
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
    <table style="width: 890px">
     
        <tr>
            <td align="center" colspan="3" style="height: 21px">
                <asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" Height="18px" Font-Bold="True" ForeColor="DodgerBlue">New Upload File Request</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
                <asp:LinkButton id="LinkButton2" onclick="LinkButton2_Click" runat="server" Height="18px" Font-Bold="True" ForeColor="DodgerBlue">View Uploaded Files</asp:LinkButton>&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                <asp:LinkButton id="LinkButton3" onclick="LinkButton3_Click" runat="server" Height="18px" Font-Bold="True" Width="139px" ForeColor="DodgerBlue">Download Files</asp:LinkButton>&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp;<asp:LinkButton
                    ID="LinkButton5" runat="server" Font-Bold="True" ForeColor="DodgerBlue" OnClick="LinkButton5_Click" Height="18px" Width="67px">Reports</asp:LinkButton>&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" ForeColor="DodgerBlue"
                    OnClick="LinkButton4_Click" Height="18px" Width="90px">Sign Out</asp:LinkButton>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
              
                    <table style="width: 891px">
                        <tr>
                            <td colspan="3">                            

                                
                                <asp:Panel ID="Panel4" runat="server">
                                    <table style="width: 881px; height: 150px">
                                        <tr>
                                            <td class="tta" colspan="3" style="height: 16px">
                                                <strong><span style="font-size: 9pt">New Upload File Request</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td class="reportTitleIncome" colspan="3">
                                                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="reportTitleIncome" colspan="1" style="width: 85px">
                                                No Of Files :</td>
                                            <td class="Info" colspan="2" style="width: 761px">
                                                <asp:TextBox ID="txtFileNo" runat="server" Height="23px" SkinID="txtSkin"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="reportTitleIncome" style="width: 85px">
                                                Brief Comments :</td>
                                            <td class="Info" colspan="2" style="width: 761px">
                                                <asp:TextBox ID="txtRemark" runat="server" Height="36px" SkinID="txtSkin" TextMode="MultiLine"
                                                    Width="660px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="tta" colspan="3" style="height: 41px">
                                                &nbsp;
                                                <asp:Button ID="btnSave" runat="server" Height="27px" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                                                    Text="Proceed To Upload" />
                                                <asp:Button ID="btnCancel" runat="server" Height="27px" OnClick="btnCancel_Click"
                                                    SkinID="btnCancelSkin" Text="Cancel" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel5" runat="server">
                                    <table class="sidebar" style="width: 104%">
                                        <tr>
                                            <td class="tta" colspan="8" style="height: 17px">
                                                Upload Files</td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="height: 17px">
                                                <asp:Label ID="lblFileUpload" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="bx" colspan="8" style="height: 17px">
                                                <div style="overflow: scroll; width: 864px; height: 302px">
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
                                                                                    <asp:TextBox ID="txtContentExpireDate" runat="server" Visible="true" Width="75px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Image ID="Imgclear" runat="server" ImageUrl="~/Images/close.gif" />
                                                                                    <asp:Image ID="ImgExpireDate" runat="server" AlternateText="Calendar" ImageUrl="~/Images/SmallCalendar.gif"
                                                                                        Visible="false" />
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
                                            <td class="tta" colspan="8" style="height: 1px">
                                                &nbsp;
                                                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" SkinID="btnUploadSkin"
                                                    Text="Upload" />
                                                <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" SkinID="btnCancelSkin"
                                                    Text="Cancel" Width="56px" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server">
                                    <table style="width: 882px">
                                        <tr>
                                            <td class="tta" colspan="3">
                                                Review Uploded Files Earlier</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 6px; height: 171px">
                                                <div style="overflow: scroll; width: 868px; height: 150px">
                                                    <asp:DataList ID="DataList1" runat="server" CellPadding="4" Font-Names="Verdana"
                                                        Font-Size="8pt" ForeColor="#333333" RepeatColumns="3" RepeatLayout="Flow" Width="390px">
                                                        <ItemTemplate>
                                                            <table cellpadding="1" cellspacing="0">
                                                                <tr>
                                                                    <td align="left" style="width: 17px; text-align: center">
                                                                        <asp:ImageMap ID="IMap" runat="server" ImageUrl='<%# (DataBinder.Eval(Container.DataItem,"FileType"))%>'
                                                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>'>
                                                                            <asp:RectangleHotSpot Bottom="1" HotSpotMode="Inactive" Left="1" Right="1" Top="1" />
                                                                        </asp:ImageMap></td>
                                                                    <td align="left" style="text-align: center">
                                                                        <asp:Label ID="lblFileDetails" runat="server" BorderStyle="None" CssClass="ta" Text='<%# (DataBinder.Eval(Container.DataItem,"FileName")) %>'
                                                                            ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip")) %>' Width="176px"></asp:Label></td>
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
                                        </tr>
                                    </table><asp:Button ID="Button2" runat="server" Height="27px" OnClick="btnCancel_Click"
                                                    SkinID="btnCancelSkin" Text="Cancel" /></asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table>
                                        <tr>
                                            <td class="tta" colspan="3">
                                                Download Files</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div style="overflow: scroll; width: 868px; height: 150px">
                                                    <asp:DataList ID="DataList2" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px" CellPadding="0" GridLines="Both" Height="1px"
                                                        RepeatColumns="4" Width="851px">
                                                        <ItemTemplate>
                                                            <table cellpadding="1" cellspacing="1" style="width: 57px">
                                                                <tr>
                                                                    <td align="center" colspan="2" style="height: 25px">
                                                                        &nbsp;<asp:ImageMap ID="IMap" runat="server" Height="18px" ImageUrl='<%# (DataBinder.Eval(Container.DataItem,"FileType"))%>'
                                                                            OnClick="IMap_Click" ToolTip='<%# (DataBinder.Eval(Container.DataItem,"ToolTip"))%>'
                                                                            Width="18px">
                                                                            <asp:RectangleHotSpot Bottom="2" HotSpotMode="Inactive" Left="2" Right="2" Top="2" />
                                                                        </asp:ImageMap>
                                                                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"FilePath")) %>'
                                                                            Font-Size="7pt" Font-Underline="True" ForeColor="#0000FF" OnClick="lnkView_Click"
                                                                            Text='<%# (DataBinder.Eval(Container.DataItem,"FileName")) %>'></asp:LinkButton></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="2" style="height: 25px">
                                                                        <asp:Label ID="lblname" runat="server" Font-Size="Small" ForeColor="Red" Text='<%# (DataBinder.Eval(Container.DataItem,"fullname")) %>'
                                                                            Width="187px"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;&nbsp;
                                                        </ItemTemplate>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <ItemStyle ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    </asp:DataList>
                                                </div><asp:Button ID="Button1" runat="server" Height="27px" OnClick="btnCancel_Click"
                                                    SkinID="btnCancelSkin" Text="Cancel" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#0000C0" GridLines="None" Width="80%">
                                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="White" Font-Bold="True" Font-Italic="True" ForeColor="#0000C0" />
                                    <EditRowStyle BackColor="White" Font-Bold="True" Font-Italic="True" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="#0000C0" />
                                    <PagerStyle BackColor="White" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" Font-Bold="True" ForeColor="#0000C0" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                                              <marquee ><asp:Label id="Label1" runat="server" Height="41px" Font-Bold="True" Width="917px" ForeColor="DarkRed" Font-Size="XX-Large" Text="  Welcome To PAMAC Home Office"></asp:Label></marquee >
                <asp:Panel ID="Panel3" runat="server">
                    <asp:HiddenField ID="hdnSumOfRequestFile" runat="server" />
                    <asp:HiddenField ID="hdnFileID" runat="server" />
                </asp:Panel>
            </td>
        </tr>
    </table>
  
  </asp:Content>