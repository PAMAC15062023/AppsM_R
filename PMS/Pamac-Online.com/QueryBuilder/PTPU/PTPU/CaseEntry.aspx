<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/PTPU/PTPU/MasterPage.master" AutoEventWireup="true" CodeFile="CaseEntry.aspx.cs" Inherits="PTPU_PTPU_CaseEntry" Title="Untitled Page" StylesheetTheme="SkinFile"  EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript">

function checkNumeric(textBox) 
{
    var textBox = document.getElementById(textBox); 
    if(isNaN(textBox.value)) 
    {
        alert("-Please provide a numeric value."); 
        textBox.value=""; 
        return false; 
    }
}


function validate()
{
    var ReturnValue=true;
    var ErrorMessage="";
    var lblMsgXls=document.getElementById("<%=lblMsgXls.ClientID%>");
    
    var txtbatchid=document.getElementById("<%=txtbatchid.ClientID%>");
   var txttotalnocheque=document.getElementById("<%=txttotalnocheque.ClientID%>");

    var txtcardno=document.getElementById("<%=txtcardno.ClientID%>");
    var txtchequeno=document.getElementById("<%=txtchequeno.ClientID%>");
     var txtamount=document.getElementById("<%=txtamount.ClientID%>");



    if(txtamount.value=='')
    {
        ErrorMessage=("Please Insert Amount to continue!");
        ReturnValue=false;
      txtamount.focus();
    }
    
    if(txtchequeno.value=='' || (txtchequeno.value.length !=6))
    {
      ErrorMessage=("Please Enter Cheque No. to continue!");

        ReturnValue=false;
        txtchequeno.focus();
    }
    
    
    if(  txtcardno.value=='' || (txtcardno.value.length !=16))
    {
       ErrorMessage=("Please Enter Card No. to continue!");

        ReturnValue=false;
        txtcardno.focus();
    }

     if(txttotalnocheque.value=='')
    {
        ErrorMessage=("Please Enter Total no. of Cheque(s)  to continue!");
        ReturnValue=false;
       txttotalnocheque.focus();
    }

    
    
    if(txtbatchid.value=='')
    {
          ErrorMessage=("Please Enter Batch  to continue!");

        ReturnValue=false;
       txtbatchid.focus();
    }
    
    
    window.scrollTo(0,0);    
    lblMsgXls.innerText=ErrorMessage;
    return ReturnValue;
}  


  function Check(evt)
    {
        if(evt.keyCode == 32)
        {
            alert("Space not allowed");
            return false;
        }
        return true;
    }







</script>


<table style="width: 688px;">    <%--height: 66px--%>
  <tr>
  <td style="width: 719px;">
    <table style="width: 686px;">
    <tr>
        <td class="tta" colspan="4" style=" width: 690px;">
            <span style="font-size: 10pt">Data Case Entry</span></td>
    </tr>
     <tr>
        <td colspan="4" style=" width: 690px; height: 11px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
          <asp:Label ID="Lblcount" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
        </td>
    </tr>

    <tr >
        <td style="width: 317px; height: 13px;" class="reportTitleIncome">
            <strong>Batch ID</strong></td>
        <td style="width: 225px; height: 13px;" class="Info">
            &nbsp;<asp:TextBox ID="txtbatchid" runat="server"  Width="135px" onkeydown="return Check(event)" Onchange ="return checkNumeric('ctl00_C1_txtbatchid');" SkinID="txtSkin" Font-Bold="True" ForeColor="Blue" ></asp:TextBox>&nbsp;</td>
        <td style="width: 320px; height: 13px;" class="reportTitleIncome" >
            <strong>Total No. of Cheque(s)</strong></td>
        <td style="width: 105px; height: 13px;" class="Info">
            &nbsp;
            <asp:TextBox ID="txttotalnocheque" runat="server" SkinID="txtSkin" Width="135px"  onkeydown = "return Check(event)"  Onchange ="return checkNumeric('ctl00_C1_txttotalnocheque');" onpaste = "return false;" Font-Bold="True" ForeColor="Blue"></asp:TextBox></td>
    </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 317px; height: 29px;">
                <strong>Card No.</strong></td>
            <td class="Info" style="width: 225px; height: 29px;">
            <asp:TextBox ID="txtcardno" runat="server" Width="140px"    onkeydown = "return Check(event)"  
Onchange ="return checkNumeric('ctl00_C1_txtcardno');"
  onpaste = "return false;" SkinID="txtSkin" MaxLength="16" ></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 320px; height: 29px;">
                <strong>Cheque No.</strong></td>
            <td class="Info" style="width: 105px; height: 29px;">
                <asp:TextBox ID="txtchequeno" runat="server" Width="140px"   onkeydown = "return Check(event)"  Onchange ="return checkNumeric('ctl00_C1_txtchequeno');" onpaste = "return false;"  SkinID="txtSkin" MaxLength="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 317px; height: 34px">
                <strong>Amount</strong></td>
            <td class="Info" 
             style="height: 34px" colspan="3">
                <asp:TextBox ID="txtamount" runat="server" Width="140px"    onkeydown = "return Check(event)"  Onchange ="return checkNumeric('ctl00_C1_txtamount');" onpaste = "return false;" SkinID="txtSkin"></asp:TextBox><strong></strong></td>
        </tr>

        <tr>
            <td class="Info" colspan="4" >
                <asp:Button ID="btnSAVE" runat="server" Text="Save" Width="84px" OnClick="btnSAVE_Click" />
            &nbsp; &nbsp;
            </td>
        </tr>
    
     
    </table>
     
  </td>
  </tr>
  </table>

    <br />
    <asp:HiddenField ID="hdnno" runat="server" />
    <br />

</asp:Content>

