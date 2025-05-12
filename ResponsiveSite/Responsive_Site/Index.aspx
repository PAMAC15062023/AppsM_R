<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Responsive_Site.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Foundation/js/foundation.min.js" type="text/javascript"></script>
    <link href="Foundation/css/foundation.min.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <br /><br />
    <div class="row" style="border:2px solid blue">
    <div class="large-12 columns">
     <br /><br />
    <div class="row">
   <div class="large-12 columns text-center">
   <b>Signup Form</b>
   </div>
    </div><br /><br />
     <div class="row">
   <div class="large-12 columns">
   Name:
   </div>
    </div>
     <div class="row">
   <div class="large-12 columns">
  <asp:TextBox ID="txtUName" runat="server" placeholder="User name"></asp:TextBox>
   </div>
    </div>
    <br /><br />
     <div class="row">
   <div class="large-12 columns">
   Email id:
   </div>
    </div>
     <div class="row">
   <div class="large-12 columns">
  <asp:TextBox ID="txtEmail" runat="server" placeholder="Email id"></asp:TextBox>
   </div>
    </div>
      <br /><br />
     <div class="row">
   <div class="large-12 columns">
   Phone no:
   </div>
    </div>
     <div class="row">
   <div class="large-12 columns">
  <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone number"></asp:TextBox>
   </div>
    </div>
      <br /><br />
     <div class="row">
   <div class="large-12 columns">
   Address:
   </div>
    </div>
     <div class="row">
   <div class="large-12 columns">
  <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
   </div>
    </div>
    <br /><br />
     <div class="row">
   <div class="large-6 columns">
   <asp:Button ID="btnSubmit" runat="server" Text="Submit"></asp:Button>
   </div>
   <div class="large-6 columns">
  <asp:Button ID="btnCancel" runat="server" Text="Cancel"></asp:Button>
   </div>
    </div>
    </div> 
    </div>
    </form>
</body>
</html>
