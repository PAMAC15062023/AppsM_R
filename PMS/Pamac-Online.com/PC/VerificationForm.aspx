<%@ Page Title="" Language="C#" MasterPageFile="~/PC/MasterPage.master" AutoEventWireup="true"
    CodeFile="VerificationForm.aspx.cs" StylesheetTheme="SkinFile" Inherits="PC_VerificationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<%--<style>
.input_text:focus, input.input_text_focus {
    border-color:#646464;
    background-color:#ffffc0;
}

    .Info
    {
        border: 1px solid dimgray;
        background-color: lightgrey;
        font-family: Verdana, Tahoma;
        color: #333300;
        font-size: 8pt;
        background-image: url('../Images/bgr.gif');
        width: 331px;
    }--%>


<asp:HiddenField ID="hdnmachinename" runat="server" />
<asp:Label ID="lblmessage"  runat="server" ForeColor="Red" Text="Label" 
        Visible="False" Font-Bold="True"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td class="tta" colspan="14" style="height: 22px" >
                MACHINE DETAILS</td>
            </tr>
            <tr>
            <td style="width: 146px" class="reportTitleIncome ">
                Machine Name</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtmachine" runat="server" Width="125px" ReadOnly="true" 
                    CssClass="" BackColor="#eae4e4" ></asp:TextBox>
                           </td>
            <td style="width: 89px" class="reportTitleIncome">
                User FullName</td>
            <td class="Info">
                <asp:TextBox ID="txtfullname" runat="server" Width="125px" ReadOnly="true" 
                    BackColor="#eae4e4"></asp:TextBox>
                           </td>


            <td style="width: 88px" class="reportTitleIncome ">
                Department</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtdepartment" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Emp ID</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtempid" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                CPU PAMAC ID</td>
            <td class="Info">
                <asp:TextBox ID="txtcpupamacid" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                MACHINE NAME</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachinename" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>

    
        <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Machine On DHCP</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtmachineDhcp" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Monitor Make Brand</td>
            <td class="Info">
                <asp:TextBox ID="txtmonitormake" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Monitor Model</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmonitormodel" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Monitor Inch</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtmonitorinch" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Monitor Serial No</td>
            <td class="Info">
                <asp:TextBox ID="txtmonitorserial" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Machine IP</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineip" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Desk IP</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtdeskip" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                MAC Address</td>
            <td class="Info">
                <asp:TextBox ID="txtmacaddress" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Gateway</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtgateway" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Admin Rights</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtadminrights" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Screen Saver</td>
            <td class="Info">
                <asp:TextBox ID="txtscreen" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Wallpaper</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtwallpaper" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                OS</td>
            <td style="width: 153px" class="Info"> 
                <asp:TextBox ID="txtos" runat="server" Width="125px"  ReadOnly="true"  BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Office Version</td>
            <td class="Info">
                <asp:TextBox ID="txtOffice" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
              AV Name</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtAVname" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
               AV Status</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtAVstatus" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               AV Policy</td>
            <td class="Info">
                <asp:TextBox ID="txtAVpolicy" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               AV updation Date</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtavupdation" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
               Bios Password</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtbios" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Winows Patch Date</td>
            <td class="Info">
                <asp:TextBox ID="txtwindowspatch" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                System DateTime</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtsystemdate" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                ZIP Client</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtzipclient" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Adobe Version</td>
            <td class="Info">
                <asp:TextBox ID="txtadobeversion" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Machine Owned</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmachineowned" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr><tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Rental CPU No</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtrentalcpuno" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                CPU Make Model</td>
            <td class="Info">
                <asp:TextBox ID="txtcpumakemodel" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                CPU Serial No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtcpuserialno" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
        <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                CPU Speed</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtcpuspeed" runat="server" Width="125px"  ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                HDD</td>
            <td class="Info">
                <asp:TextBox ID="txthdd" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               RAM</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtram" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
     

          <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                CPU</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtcpu" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                USB Block</td>
            <td class="Info">
                <asp:TextBox ID="txtusbblock" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               My Dock Picture</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmydockpicture" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>

        </tr>
          <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Email Id</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtemailid" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Type of ID</td>
            <td class="Info">
                <asp:TextBox ID="txttypeofid" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               PDF Writer</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpdfwriter" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
          <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Skype</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtskype" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Time Synk</td>
            <td class="Info">
                <asp:TextBox ID="txttimesynk" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               My Dock Picture Remove</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtmudoclpicture" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
                Maxmimum Password Age 30</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtmaxmimumpass" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Password Lenght</td>
            <td class="Info">
                <asp:TextBox ID="txtpasswordleng" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Password Complexity Enable</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordcomplexity" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
               Account Lokout Threshold</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtaccountlokout" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Prevent Changing Wallpaper Enable</td>
            <td class="Info">
                <asp:TextBox ID="txtpreventchanging" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
               Password protech Screen Saver</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtpasswordprotech" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
        </tr>
  <tr>
        
        <td style="width: 146px" class="reportTitleIncome ">
               Screen Saver Time</td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtscreensavertime" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             <td style="width: 88px" class="reportTitleIncome ">
                Prevent Changing</td>
            <td class="Info">
                <asp:TextBox ID="txtprevent" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
              <td style="width: 88px" class="reportTitleIncome ">
                Rental Monitor No</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtrentalmonitorno" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
             
        </tr>
         <tr>
   <td style="width: 88px" class="reportTitleIncome ">
                Monitor Pamac Id</td>
            <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtMonitorpamacid" runat="server" Width="125px" ReadOnly="true" BackColor="#eae4e4"></asp:TextBox>
             </td>
               <td style="width: 146px" class="reportTitleIncome ">OS Licence</td>
                   <td class="Info">
                <asp:TextBox ID="txtOSlicence" runat="server" Width="125px" ReadOnly="true" 
                           BackColor="#eae4e4"></asp:TextBox>
             </td>
                   <td style="width: 146px" class="reportTitleIncome ">Office Licence</td>
                   <td style="width: 149px" class="Info">
                <asp:TextBox ID="txtOfficelicence" runat="server" Width="125px" ReadOnly="true" 
                           BackColor="#eae4e4"></asp:TextBox>
             </td>
  
  </tr>
  <tr>
  
  <td class="tta" colspan="14" style="height: 30px">
         <asp:Button ID="btnapprove" runat="server" Text="Verify" BackColor="Black" 
                    BorderColor="White" CssClass="button" ForeColor="White" 
             Width="111px" Height="28px" onclick="btnapprove_Click"/>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button1" runat="server" Text="Cancel" BackColor="Black" 
                    BorderColor="White" CssClass="button" ForeColor="White" 
             Width="111px" Height="28px" OnClick="Button1_Click"/>
            </td>  
          
            
  </tr>
 
        </table>
    <br />
</asp:Content>
