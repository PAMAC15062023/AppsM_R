<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HRImport.aspx.cs" Inherits="HR_HR_HRImport" Title="Untitled Page" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script language="javascript" type="text/javascript"src="popcalendar.js"></script>

<script type="text/javascript" language="javascript">
    function ClientValidate(source, arguments)
    {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
    }
   
    function validate()
    {
        var lblMsgXls = document.getElementById("<%=lblMsgXls.ClientID%>");
        var ErrorMsg = "";
        var ReturnValue = true;
           var  txtuploaddate=document.getElementById("<%=txtuploaddate.ClientID%>");
        var xslFileUpload = document.getElementById("<%=xslFileUpload.ClientID%>");
        
        if(xslFileUpload.value=='')
        {
            ErrorMsg = "Please Select an Excel File to continue.";
            ReturnValue = false;
            xslFileUpload.focus();
        }
           
         if(txtuploaddate.value=='')
    {
        ErrorMsg=("Please Enter Upload Date  to continue!");
        ReturnValue=false;
        txtuploaddate.focus();
    }
        

        window.scrollTo(0,0);
        lblMsgXls.innerText = ErrorMsg;
        return ReturnValue;
    }
</script>

<table style="width: 688px;">    <%--height: 66px--%>
  <tr>
  <td style="width: 691px;">
    <table style="width: 686px;">
    <tr>
        <td class="tta" colspan="6" style="height: 4px; width: 690px;">
            <span style="font-size: 10pt">OJT Data Import</span></td>
    </tr>
    <tr>
        <td colspan="6" style="height: 1px; width: 690px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr >
        <td style="width: 317px; height: 1px;" class="reportTitleIncome">
            <span style="background-color: #e1e9ff">&nbsp;<strong> Upload date</strong></span></td>
        <td style="width: 303px; height: 1px;" class="Info">
            &nbsp; &nbsp;
            <asp:TextBox ID="txtuploaddate" runat="server" MaxLength="10" SkinID="txtSkin" Width="128px"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtuploaddate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.gif" /></td>
        <td style="width: 374px; height: 1px;" class="reportTitleIncome" >
            <strong>Upload File</strong></td>
        <td style="width: 95px; height: 1px;" class="Info">
            <asp:FileUpload ID="xslFileUpload" runat="server" Width="205px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.xls]</td>
    </tr>
    <tr >
        <td style="width: 100px; height: 1px;" class="Info" colspan="7">
           <center><asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUpload_Click" ValidationGroup="grpImport" SkinID="btnImport" />&nbsp;
               </center> 
          </td>
    </tr>
    
     
    </table>
     
  </td>
  </tr>
  </table>
</asp:Content>

