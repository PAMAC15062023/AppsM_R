<%@ Page Title="" Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true"
    CodeFile="SystemInsertRecord.aspx.cs" StylesheetTheme="SkinFile" Inherits="PC_form_SystemInsertRecord" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<%--<style>
.input_text:focus, input.input_text_focus {
    border-color:#646464;
    background-color:#ffffc0;
}

    .reportTitleIncome
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
--%>
<script>
  <script type="text/javascript">
        function resetFields() {
            $("#TextBox1").val(""); //do all the reset work here
             alert('Fill this field');

        };


</script>
<asp:HiddenField ID="hdnmachinename" runat="server" />
    <asp:Label ID="lblmessage" runat="server" Text="Label" Font-Bold="True" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td class="tta" colspan="14" style="height: 22px" >
                MACHINE DETAILS</td>
            </tr>
            <tr>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                Machine Name</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachine" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
                           </td>
            <td style="width: 89px" class="reportTitleIncome">
                User FullName</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtfullname" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
                           </td>


            <td style="width: 88px" class="reportTitleIncome">
                Department</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtdepartment" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td class="reportTitleIncome">
                Emp ID</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtempid" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                CPU PAMAC ID</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtcpupamacid" runat="server"  SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                MACHINE NAME</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachinename" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>

    
        <tr>
        
        <td class="reportTitleIncome">
                Machine On DHCP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineDhcp" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Monitor Make Brand</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmonitormake" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Monitor Model</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmonitormodel" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
                Monitor Inch</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmonitorinch" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Monitor Serial No</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmonitorserial" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Machine IP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineip" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
                Desk IP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtdeskip" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                MAC Address</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtmacaddress" SkinID="txtSkin"  runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Gateway</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtgateway" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome"> 
                Admin Rights</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtadminrights" SkinID="txtSkin" runat="server" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Screen Saver</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtscreen" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Wallpaper</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtwallpaper" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
                OS</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtos" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"> </asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Office Version</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtOffice" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
              AV Name</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtAVname" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
               AV Status</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtAVstatus" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               AV Policy</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtAVpolicy" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               AV updation Date</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtavupdation" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
               Bios Password</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtbios" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Winows Patch Date</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtwindowspatch" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                System DateTime</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtsystemdate" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
                ZIP Client</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtzipclient" runat="server"  SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Adobe Version</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtadobeversion" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Machine Owned</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineowned" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td class="reportTitleIncome">
                Rental CPU No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtrentalcpuno" runat="server"  SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                CPU Make Model</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtcpumakemodel" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                CPU Serial No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpuserialno" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td class="reportTitleIncome">
                CPU Speed</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpuspeed" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                HDD</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txthdd" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               RAM</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtram" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
     

          <tr>
        
        <td class="reportTitleIncome">
                CPU</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpu" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                USB Block</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtusbblock" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               My Dock Picture</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmydockpicture" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>

        </tr>
          <tr>
        
        <td class="reportTitleIncome">
                Email Id</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtemailid" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Type of ID</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txttypeofid" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               PDF Writer</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpdfwriter" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
          <tr>
        
        <td class="reportTitleIncome">
                Skype</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtskype" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Time Synk</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txttimesynk" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               My Dock Picture Remove</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmudoclpicture" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome">
                Maxmimum Password Age 30</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmaxmimumpass" runat="server"  SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Password Lenght</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtpasswordleng" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Password Complexity Enable</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordcomplexity" runat="server"  SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome">
               Account Lokout Threshold</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtaccountlokout" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Prevent Changing Wallpaper Enable</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtpreventchanging" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
               Password protech Screen Saver</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordprotech" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td class="reportTitleIncome">
               Screen Saver Time</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtscreensavertime" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome">
                Prevent Changing</td>
            <td style="width: 357px" class="Info">
                <asp:TextBox ID="txtprevent" runat="server" Width="125px" SkinID="txtSkin" CssClass="input_text"></asp:TextBox>
             </td>
              <td style="width: 88px" class="reportTitleIncome">
                Rental Monitor No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtrentalmonitorno" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text"></asp:TextBox>
             </td>
             
        </tr>
        <tr>
   <td class="reportTitleIncome">
                Monitor Pamac Id</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtMonitorpamacid" runat="server" SkinID="txtSkin" Width="125px" CssClass="input_text" ></asp:TextBox>
             </td>
               <td style="width: 146px" class="reportTitleIncome">OS Licence</td>
                   <td style="width: 383px" class="Info">
                <asp:DropDownList ID="txtOSlicence" runat="server" SkinID="txtSkin" Width="125px" 
                         >
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>NL</asp:ListItem>
                       </asp:DropDownList>
             </td>
                   <td style="width: 146px" class="reportTitleIncome">Office Licence</td>
                   <td style="width: 149px" class="Info">
                <asp:DropDownList ID="txtOfficelicence" runat="server" SkinID="txtSkin" Width="125px" 
                         >
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>NL</asp:ListItem>
                       </asp:DropDownList>
             </td>
  
  </tr>
  <tr>
  
  <td  class="tta" colspan="14" style="height: 30px">
         <asp:Button ID="btnapprove" runat="server" CssClass="button" Text="Submit" Width="111px" Height="28px" BackColor="Black" BorderColor="White" ForeColor="White" Autopostback="true"
             onclick="btnapprove_Click" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button1" runat="server" Text="Cancel" BackColor="Black" 
                    BorderColor="White" CssClass="button" ForeColor="White" 
             Width="111px" Height="28px" OnClick="Button1_Click"/>
            </td>  
  </tr>
        </table>
    <br />
</asp:Content>
