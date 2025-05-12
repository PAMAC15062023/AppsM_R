<%@ Page Title="" Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditRecord.aspx.cs" StylesheetTheme="SkinFile" Inherits="PC_EditRecord" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<style type="text/css">
.input_text:focus, input.input_text_focus {
    border-color:#646464;
    background-color:#ffffc0;
}

    .style1
    {
        border: 1px solid #808080;
        font-size: 8pt;
        color: #000000;
        font-family: Verdana, Tahoma;
        background-color: #C0C0C0;
        white-space: no-wrap;
        width: 149px;
    }
    .style2
    {
        border: 1px solid dimgray;
        background-color: lightgrey;
        font-family: Verdana, Tahoma;
        color: #333300;
        font-size: 8pt;
        background-image: url('../../Images/bgr.gif');
        width: 149px;
    }

</style>
<asp:HiddenField ID="hdnmachinename" runat="server" />
    <asp:Label ID="lblmessage" runat="server" Text="Label" Font-Bold="True" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td class="tta" colspan="14" style="height: 22px" >
                MACHINE DETAILS</td>
            </tr>
            <tr>
            <td class="reportTitleIncome" style="width: 89px">
                Machine Name</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachine" runat="server" Width="125px" CssClass="input_text" required="true"></asp:TextBox>
                           </td>
            <td class="reportTitleIncome" style="width: 89px">
                User FullName</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtfullname" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
                           </td>


            <td style="width: 88px" class="reportTitleIncome">
                Department</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtdepartment" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Emp ID</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtempid" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                CPU PAMAC ID</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtcpupamacid" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                MACHINE NAME</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachinename" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>

    
        <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Machine On DHCP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineDhcp" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Monitor Make Brand</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmonitormake" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Monitor Model</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmonitormodel" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Monitor Inch</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmonitorinch" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Monitor Serial No</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmonitorserial" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Machine IP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineip" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Desk IP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtdeskip" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                MAC Address</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmacaddress" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Gateway</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtgateway" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Admin Rights</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtadminrights" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Screen Saver</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtscreen" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Wallpaper</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtwallpaper" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                OS</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtos" runat="server" Width="125px" CssClass="input_text"> </asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Office Version</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtOffice" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
              AV Name</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtAVname" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
               AV Status</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtAVstatus" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               AV Policy</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtAVpolicy" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               AV updation Date</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtavupdation" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
               Bios Password</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtbios" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Winows Patch Date</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtwindowspatch" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                System DateTime</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtsystemdate" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                ZIP Client</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtzipclient" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Adobe Version</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtadobeversion" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Machine Owned</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineowned" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Rental CPU No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtrentalcpuno" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                CPU Make Model</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtcpumakemodel" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                CPU Serial No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpuserialno" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                CPU Speed</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpuspeed" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                HDD</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txthdd" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               RAM</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtram" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
     

          <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                CPU</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpu" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                USB Block</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtusbblock" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               My Dock Picture</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmydockpicture" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>

        </tr>
          <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Email Id</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtemailid" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Type of ID</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txttypeofid" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               PDF Writer</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpdfwriter" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
          <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Skype</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtskype" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Time Synk</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txttimesynk" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               My Dock Picture Remove</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmudoclpicture" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
                Maxmimum Password Age 30</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmaxmimumpass" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Password Lenght</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtpasswordleng" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Password Complexity Enable</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordcomplexity" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
               Account Lokout Threshold</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtaccountlokout" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Prevent Changing Wallpaper Enable</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtpreventchanging" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
               Password protech Screen Saver</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordprotech" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome" style="width: 89px">
               Screen Saver Time</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtscreensavertime" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td class="reportTitleIncome" style="width: 89px">
                Prevent Changing</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtprevent" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
              <td class="reportTitleIncome" style="width: 89px">
                Rental Monitor No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtrentalmonitorno" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             
        </tr>
        <tr>
   <td class="reportTitleIncome" style="width: 89px">
                Monitor Pamac Id</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtMonitorpamacid" runat="server" Width="125px" CssClass="input_text" ></asp:TextBox>
             </td>
               <td class="reportTitleIncome" style="width: 89px">OS Licence</td>
                   <td style="width: 383px" class="Info">
                <asp:DropDownList ID="txtOSlicence" runat="server"  CssClass="input_text" Width="125px" 
                         >
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>NL</asp:ListItem>
                       </asp:DropDownList>
             </td>
                   <td style="width: 146px" class="reportTitleIncome">Office Licence</td>
                   <td style="width: 149px" class="Info">
                <asp:DropDownList ID="txtOfficelicence" runat="server"  CssClass="input_text" Width="125px" 
                         >
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>NL</asp:ListItem>
                       </asp:DropDownList>
             </td>
  
  </tr>
  <tr>
  
  <td  class="tta" colspan="9" style="height: 30px">
         <asp:Button ID="btnapprove" runat="server" CssClass="button" Text="Update" Width="111px" Height="28px" BackColor="Black" BorderColor="White" ForeColor="White" Autopostback="true"
             onclick="btnapprove_Click" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button1" runat="server" Text="Cancel" BackColor="Black" 
                    BorderColor="White" CssClass="button" ForeColor="White"  OnClick="Button1_Click1" 
             Width="111px" Height="28px"/>
            </td>  
  </tr>
        </table>
    <br />
</asp:Content>
