<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="Reopen.aspx.cs" Inherits="IDOC_IDOC_Reopen" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script language="javascript" type="text/javascript">
  function validate()
    {
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var ErrorMsg = "";
        var ReturnValue = true;
        var txtcaseid = document.getElementById("<%=txtcaseid.ClientID%>");

  
  
  
  
  
  
          if(txtcaseid.value == '')
        {
            ErrorMsg="Please Select Case Id.";
            ReturnValue=false;
            txtcaseid.focus();
        }


        window.scrollTo(0,0);
        lblMessage.innerText = ErrorMsg;
        return ReturnValue;
    }
    
     function validateall()
    {
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");
        var ErrorMsg = "";
        var ReturnValue = true;
        var txtcaseid = document.getElementById("<%=txtcaseid.ClientID%>");


  
          if(txtcaseid.value == '')
        {
            ErrorMsg="Please Enter Case Id for Reopen case.";
            ReturnValue=false;
            txtcaseid.focus();
        }


        window.scrollTo(0,0);
        lblMessage.innerText = ErrorMsg;
        return ReturnValue;
    }
    
    
    
</script>
    


    <asp:Panel ID="pnlCategory" runat="server" Height="405px" Width="746px">
        <table style="width: 764px">
        
         <tr>
        <td class="tta" colspan="8" style="height: 4px; width: 690px;">
            <span style="font-size: 10pt">CASE RE-OPEN</span></td>
             </tr>
             </table>
        <asp:Image ID="Image1" runat="server" Height="104px" ImageUrl="~/Images/PamacLogo1.jpg"
            Width="120px" /><br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Size="10" ForeColor="red"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;
        <div style="text-align: center">
            <table style="width: 412px">
                <tr>
                    <td style="width: 134px; height: 30px;" class="reportTitleIncome">
                        <strong>
                 
                        Case Id:</strong></td>
                    <td style="width: 67px; height: 30px;" class="Info"><asp:TextBox ID="txtcaseid" runat="server" SkinID="txtSkin" Width="189px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="reportTitleIncome" style="width: 134px; height: 30px">
                        <strong>&nbsp;&nbsp; &nbsp;Ref No:</strong></td>
                    <td style="width: 67px; height: 30px" class="Info">
                        <asp:TextBox ID="txtrefno" runat="server" SkinID="txtSkin" Width="187px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 134px; height: 30px" class="reportTitleIncome">
                        <strong>&nbsp; &nbsp;&nbsp; &nbsp;Applicant Name:</strong></td>
                    <td style="width: 67px; height: 27px" class="Info">
                        <asp:TextBox ID="txtappname" runat="server" SkinID="txtSkin" Width="189px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 29px;" class="Info" colspan="2">
                        <asp:Button ID="btnsearch" runat="server" Text="Search"
                            Width="72px" OnClick="btnsearch_Click1" SkinID="btnSearchSkin" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnReopen" runat="server" Text="ReOpen" SkinID="btn" OnClick="btnReopen_Click1" /></td>
                </tr>
            </table>
        </div>
             </asp:Panel>



</asp:Content>

