<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"  Inherits="Login" Theme="SkinFile" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<script language="javascript" type="text/javascript">

</script>
<title>Attendance Online Services</title>
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    
 <script language="javascript" type="text/javascript">
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57702266-1', 'auto');
  ga('send', 'pageview');

</script>
    
    
</head>
<body bgcolor="#ffffcc">
<form id="form1" runat="server">
 <table class="style1">
     <tr>
         <td colspan="6" style="background-color: #996633; height: 25px;" rowspan=""  >
             &nbsp; &nbsp;&nbsp; 
          <marquee>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      <STRONG> Welcome  in Quantum </STRONG></marquee >&nbsp;</td>     </tr>
     <tr>
         <td colspan="6" rowspan="1" style="height: 25px; background-color: #ffffcc">
         </td>
     </tr>
     <tr>
         <td style="height: 301px" >
             &nbsp;</td>
         <td style="height: 301px" >
             &nbsp;</td>
         <td align="left" style="height: 301px" >
             &nbsp;<asp:Panel ID="Panel1" runat="server" Width="624px">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <table border="0" cellspacing="0" cellpadding="0" 
    style="background-color: #FFFFCC; width: 99%; color: #663300;">
                     <tr>
                         <td>
                             <table class="style1" align="left">
                                 <tr>
                                     <td align="center" rowspan="9">
                                         &nbsp; &nbsp;
                                         <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Attendance_Icon_2.jpg" Height="180px" Width="200px" />--%>
                                         &nbsp; &nbsp;&nbsp;&nbsp;</td>
                                     <td rowspan="8">
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <strong>
                                             Login</strong> <strong>ID</strong><font 
                                color="red"> *</font></td>
                                     <td align="left">
                                         <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" SkinID="txtSkin" 
                                             ForeColor="#663300" Font-Bold="True" BackColor="#FFFFC0" Width="150px" Height="18px"></asp:TextBox>
                                         <asp:RequiredFieldValidator
                                ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="None"
                                ErrorMessage="Please enter Username" SetFocusOnError="True" 
                                ValidationGroup="grpLogin"></asp:RequiredFieldValidator>
                                     </td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <strong>Password</strong><span style="color: black"><strong></strong></span><font 
                                color="red"><span style="color: #ff3300">*</span></font></td>
                                     <td align="left">
                                         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
                                MaxLength="20"  SkinID="txtSkin" ForeColor="#663300" Font-Bold="True" Width="150px" Height="18px" BackColor="#FFFFC0"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                    ControlToValidate="txtPassword" Display="None" ErrorMessage="Please enter Password"
                                    SetFocusOnError="True" ValidationGroup="grpLogin"></asp:RequiredFieldValidator>
                                     </td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                <%-- <tr>
                                     <td style="height: 24px">
                                         <span><strong>Ce</strong></span><strong>ntre</strong><font color="red"><span 
                                style="color: #000000"> *</span></font></td>
                                     <td align="left" style="height: 24px">
                                         <asp:DropDownList ID="ddlCenter" runat="server" DataSourceID="sdsCenter"
                                DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" 
                                             ForeColor="#663300" Height="24px" Width="155px" BackColor="#FFFFCC" 
                                             Font-Bold="True">
                                         </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="rfvCenter" runat="server" ControlToValidate="ddlCenter"
                                Display="None" ErrorMessage="please select centre" SetFocusOnError="True" 
                                ValidationGroup="grpLogin"></asp:RequiredFieldValidator>
                                     </td>
                                     <td style="height: 24px">
                                         &nbsp;</td>
                                     <td style="height: 24px">
                                         &nbsp;</td>
                                 </tr>--%>
                                 <tr>
                                     <td style="height: 26px">
                                         &nbsp;</td>
                                     <td align="left" style="height: 26px">
                                         <asp:ImageButton ID="ImageButton1"  runat="server" Height="25px" ImageUrl="~/Images/Sub.bmp"
                                             OnClick="ImageButton1_Click" Width="110px" /></td>
                                     <td style="height: 26px">
                                         &nbsp;</td>
                                     <td style="height: 26px">
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td colspan="2" rowspan="2">
                                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                         &nbsp;<font color="Red">* </font>Indicate mandatory fields. &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td colspan="2" rowspan="2">
                                         &nbsp;<asp:ValidationSummary ID="vsLogin" runat="server" DisplayMode="List" 
                                             ShowMessageBox="true" ShowSummary="false" ValidationGroup="grpLogin" 
                                             Visible="true" />
                                         &nbsp;<asp:SqlDataSource ID="sdsCenter" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          
                          SelectCommand="Select CENTRE_ID, CENTRE_NAME from centre_master order by CENTRE_NAME">
                                         </asp:SqlDataSource>
                                         <asp:HiddenField ID="hdnid" runat="server" />
                                         <asp:Label 
                          ID="lblMsg" SkinID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                                     </td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                             </table>
                         </td>
                     </tr>
                     <tr>
                         <td valign="top" >
                             &nbsp;&nbsp;&nbsp;</td>
                     </tr>
                 </table>
             </asp:Panel>
             &nbsp;
         </td>
         <td style="height: 301px; width: 9px;" >
             &nbsp;</td>
         <td style="height: 301px" >
             &nbsp;</td>
         <td style="height: 301px" >
             &nbsp;</td>
     </tr>
     <tr>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
         <td align="center" style="height: 16px">
         </td>
         <td style="height: 16px; width: 9px;">
         </td>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
     </tr>
     <tr>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
         <td align="center" style="height: 16px">
             <asp:Label ID="hfMACAdresa" runat="server" Visible="False"></asp:Label></td>
         <td style="height: 16px; width: 9px;">
         </td>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
     </tr>
       <tr>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
         <td align="center" style="height: 16px">
             </td>
         <td style="height: 16px; width: 9px;">
         </td>
         <td style="height: 16px">
         </td>
         <td style="height: 16px">
         </td>
     </tr>
       <tr>
         <td>
         </td>
         <td>
         </td>
         <td align="center">
         </td>
         <td style="width: 9px">
         </td>
         <td>
         </td>
         <td>
         </td>
     </tr>
       <tr>
         <td>
         </td>
         <td>
         </td>
         <td align="center">
         </td>
         <td style="width: 9px">
         </td>
         <td>
         </td>
         <td>
         </td>
     </tr>
       <tr>
         <td>
         </td>
         <td>
         </td>
         <td align="center">
             </td>
         <td style="width: 9px">
         </td>
         <td>
         </td>
         <td>
         </td>
     </tr>
     

 </table>

</form>
 

</body>
</html>
