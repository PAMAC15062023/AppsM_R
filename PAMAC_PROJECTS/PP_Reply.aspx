<%@ Page Title="" Language="C#" MasterPageFile="~/PP_Master.Master" AutoEventWireup="true" CodeBehind="PP_Reply.aspx.cs" Inherits="Pamac_Projects.PP_Reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 970px;">
 <tr>
                <td colspan="4" style="width: 268435392px">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
               <tr>
            <td class="TableHeader" colspan="5">
                <asp:Label ID="lblHeader" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
         
                </td>
                   </tr>
                   

                <tr>
                    <td class="TableTitle" style="height: 27px; width: 260px;" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Assign To</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlAssignedTo" runat="server" Width="478px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlAssignedTo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td class="TableTitle" style="height: 27px; width: 268435392px;" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Subject</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtSubject" Width="470px" runat="server" Enabled="true"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td class="TableTitle" style="height: 27px; width: 268435392px;" colspan="8">
                        <asp:Label runat="server" Width="173px" Font-Size="10pt" Height="27px" Style= "text-align: center;" >Summary</asp:Label>
                    </td>
                          <td>
                        <asp:Button ID="btnBold" runat="server" BorderWidth="1px" Text="Bold" 
                                    Width="67px" Font-Bold="True" OnClick="btnBold_Click"/>
                             
                       </td>
                   </tr>
            </table>
            <table>
                  <tr>
     
                 
                    <td class="TableTitle" style="height: 200px" >
                        <asp:TextBox ID="TxtSummary" Width="965px" runat="server" Enabled="True" Height="200px" Font-Names="Arial" Font-Size="Medium" TextMode="MultiLine"></asp:TextBox>
                        

                    </td>
                </tr>
           </table>

            <table>
            <tr>
                <td style="width: 90px;" class="TableTitle">
                    <strong>Attachment 1</strong>
                </td>
                <td style="width: 90px;" class="TableTitle">
                    <strong>Attachment 2</strong>
                </td>
               <td style="width: 90px;" class="TableTitle">
                    <strong>Attachment 3</strong>
                </td>
            </tr>
                <tr>
                <td style="width: 90px;" class="TableGrid">
                    <asp:FileUpload ID="FileUpload_1" runat="server" />
                </td>
                    <td style="width: 90px;" class="TableGrid">
                    <asp:FileUpload ID="FileUpload_2" runat="server" />
                </td>
                     <td style="width: 90px;" class="TableGrid">
                    <asp:FileUpload ID="FileUpload_3" runat="server" />
                </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label runat="server" Width="173px" Font-Size="8pt" Height="27px" Style= "text-align: center;" >Allowed File size max 10MB</asp:Label>
                        </td>
                      <td>
                    <asp:Label runat="server" Width="173px" Font-Size="8pt" Height="27px" Style= "text-align: center;" >Allowed File size max 10MB</asp:Label>
                        </td>
                      <td>
                    <asp:Label runat="server" Width="173px" Font-Size="8pt" Height="27px" Style= "text-align: center;" >Allowed File size max 10MB</asp:Label>
                        </td>
                        </tr>
                <tr>
                    
                    <td style="width: 90px;" class="TableGrid">
                        <asp:Label runat="server" Width="250px" Font-Size="10" Height="20" Style="text-align: center;">Attachment Informtion 1</asp:Label>
                    </td>
                    <td style="width: 90px;" class="TableGrid">
                        <asp:Label runat="server" Width="250px" Font-Size="10" Height="20" Style="text-align: center;">Attachment Informtion 2</asp:Label>
                    </td>
                    <td style="width: 90px;" class="TableGrid">
                        <asp:Label runat="server" Width="250px" Font-Size="10" Height="20" Style="text-align: center;">Attachment Informtion 3</asp:Label>
                    </td>
                           </tr>
                <tr>
                    
                    <td style="width: 90px;" class="TableGrid">
                        <asp:TextBox ID="txtAttachinfo1" Width="312px" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                       <td style="width: 90px;" class="TableGrid">
                        <asp:TextBox ID="txtAttachinfo2" Width="312px" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                        <td style="width: 90px;" class="TableGrid">
                        <asp:TextBox ID="txtAttachinfo3" Width="313px" runat="server" Enabled="True"></asp:TextBox>
                    </td>
                </tr>

              </table>
          <table>
                 <tr>  
           
                 <td>
                   <asp:Button ID="btnSubmit" runat="server" BorderWidth="1px" Text="Submit" 
                    Width="67px" Font-Bold="True" OnClick="btnSubmit_Click"/>

                 </td>
                          
                <td>
                   <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="CANCEL" 
                    Width="67px" Font-Bold="True" OnClick="btnCancel_Click" /></td>
            

             </tr>

             </table>
    </asp:Panel>
</asp:Content>
