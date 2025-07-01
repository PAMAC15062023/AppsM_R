<%@ Page Title="" Language="C#" MasterPageFile="~/PP_Master.Master" AutoEventWireup="true" CodeBehind="PP_ActivityDetails.aspx.cs" Inherits="Pamac_Projects.PP_ActivityDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript"> </script>
    <style>
    .preformatted 
    {
        white-space: pre-line;
    }
</style>
       <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                <asp:Label ID="lblHeader" runat="server" CssClass="TableHeader" Width="100%"></asp:Label>
                <%--&nbsp;DASHBOARD</td>--%>
                </td>
                   </tr>
               </table>

     <asp:GridView ID="grv1" runat="server"  CssClass="mGrid"  style="overflow:scroll" Visible="true"  AutoGenerateColumns="False"
      AllowPaging="True" PageSize="20" onpageindexchanging="grv1_PageIndexChanging" Width="1192px"  >
            <Columns>
                <asp:BoundField DataField="Act_no" HeaderText="ITEM nO."  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                 <asp:BoundField DataField="PostedDate" HeaderText="POSTED DATE"  ItemStyle-Width="110px"/>
                    <asp:BoundField DataField="PostedBy" HeaderText="POSTED BY"  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                 <asp:BoundField DataField="Subject" HeaderText="SUBJECT"  ItemStyle-Width="250px"/>       
                <asp:BoundField DataField="Act_Status" HeaderText="CURRENT STATUS"  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"/>
                 <asp:BoundField DataField="AssignTo" HeaderText="ASSIGN TO" ItemStyle-Width="110px"/>
                  <asp:BoundField DataField="Summary" HeaderText="SUMMARY" ItemStyle-Width="650px" ItemStyle-CssClass="preformatted"/>
                <asp:BoundField DataField="Attachment_file1" HeaderText="ATTACHED FILE 1" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Attachment_file2" HeaderText="ATTACHED FILE 2" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Attachment_file3" HeaderText="ATTACHED FILE 3" ItemStyle-Width="100px"/>
             </Columns>

                </asp:GridView>

 
             <table>
                 <tr>  
           
                  <td>
                   <asp:Button ID="btnReply" runat="server" BorderWidth="1px" Text="REPLY" 
                    Width="67px" Font-Bold="True" OnClick="btnReply_Click"/></td>
                </td>
               <td>
                   <asp:Button ID="btnHold" runat="server" BorderWidth="1px" Text="HOLD" 
                    Width="67px" Font-Bold="True" OnClick="btnHold_Click"/></td>
             
                  <td>
                   <asp:Button ID="btnClose" runat="server" BorderWidth="1px" Text="CLOSE" 
                    Width="67px" Font-Bold="True" OnClick="btnClose_Click"/></td>
        
                <td>
                   <asp:Button ID="btnCancel" runat="server" BorderWidth="1px" Text="CANCEL" 
                    Width="67px" Font-Bold="True" OnClick="btnCancel_Click"/></td>
            

             </tr>

             </table>
</asp:Content>
