<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_OriginalSeenVisitVerification.aspx.cs" Inherits="CPA_PD_CPA_OriginalSeenVisitVerification" Title="Original Seen Visit Verification" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>   
<script language="javascript" type="text/javascript" >
    function JavaScriptValidation()
    {    
        var ddlCompanyType=document.getElementById("<%=ddlCompanyType.ClientID%>");
        var txtRemark=document.getElementById("<%=txtRemark.ClientID%>") 
        var ddlVeriStat=document.getElementById("<%=ddlVeriStat.ClientID%>") 
        var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");    
        var hdnFeData = document.getElementById("<%=hdnFeAssignDate.ClientID%>");    
        var ddlDocReceivable = document.getElementById("<%=ddlDocReceivable.ClientID%>");    
        
        
        var ReturnValue=true;
        var ErrorMsg="";
         
    
       if((hdnFeData.value=='') && (ddlDocReceivable.selectedIndex!=0))
     {  
        var CountData=0;
        if(ddlPAN.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlCheque.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlTelephone.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlMOA.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlElectricity.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlPartnership.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlSales.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlDIC.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlCertificate.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlLaws.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlITreturn.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlSTreturn.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlISO.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlCanCheque.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
                
        if(CountData==0)
        {
            ErrorMsg='Please select Aleast One';    
            ReturnValue = false;    
        }
        lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {               
            window.scroll(0,0); 
        }       
    }    
///////////////////////////////////////////////////////

 if((hdnFeData.value!='') && (ddlDocReceivable.selectedIndex!=0))
     {  
        var CountData=0;
        if(ddlFieldPan.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldCheque.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldTelephone.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldMOA.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldElectricity.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldPartnership.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
        else if(ddlFieldSales.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlFieldDIC.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlFieldCertificate.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlFieldLaws.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlFieldITreturn.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
         else if(ddlFieldSTreturn.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlFieldISO.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
          else if(ddlFieldCanCheque.selectedIndex!=0)
        {
            CountData=CountData + 1;
        }
                
        if(CountData==0)
        {
            ErrorMsg='Please select Aleast One........!!!!!';    
            ReturnValue = false;    
        }
        lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {               
            window.scroll(0,0); 
        }       
    }    
/////////////////////////////////////////////////////////////////////    
             
             
             
     if(hdnFeData.value!='')
     {              
       if(ddlVeriStat.selectedIndex==0)
        {
           ErrorMsg='Please select Overall Status........!!!!!'
           ddlVeriStat.focus();
           ReturnValue=false; 
        }
        if(txtRemark.value=='')
        {
           ErrorMsg='Please write Remark'
           txtRemark.focus();
           ReturnValue=false; 
        }        
     }
     
      if(ddlCompanyType.selectedIndex==0)
        {
            ErrorMsg='Please select Company Type';
            ddlCompanyType.focus();
            ReturnValue = false;
        }
        if(ddlDocReceivable.selectedIndex==0)
        {
            ErrorMsg='Please select Document Received';
            ddlDocReceivable.focus();
            ReturnValue = false;
        }
        
      lblMessage.innerText=ErrorMsg;
        if(ErrorMsg!='')
        {               
            window.scroll(0,0); 
        }
        return ReturnValue;
        
        
  }      
        
        
</script>  
    <table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px; width: 854px;">
<fieldset style="width: 100%">
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" style="background-color:white">
    <tr>
        <td class="topbar" colspan="6">
            &nbsp;Original Seen Visit Verification</td>
    </tr>
<tr><td style="height: 22px; width: 100%;">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Font-Underline="True"></asp:Label></td></tr>
<tr><td style="height: 97px; width: 100%;">
 <!--Start ErrorMessgage-->

   <!--END ErrorMessgage-->  
   <!--Place holder Start-->
   <asp:Table ID="tblBusiVeri" runat="server"  Width="100%" Height="26px">
   <asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >  
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder21" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder22" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder23" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder24" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder25" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder26" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder27" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder28" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder29" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder30" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder31" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder32" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder33" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder34" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder35" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder36" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder37" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder38" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder39" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder40" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder41" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder42" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder43" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder44" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder45" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder46" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder47" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder48" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder49" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder50" runat="server"></asp:PlaceHolder>   
     </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >
    
       <asp:Panel ID="pnlMainImportData" runat="server"  Width="100%" Visible="False">
                    <table style="width: 100%">
                        <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 21px">
                Case ID</td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtCaseID" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 21px">
                Reference No.</td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtRefNo" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 21px">
                <asp:Label ID="Label12" runat="server" Height="13px" Text="Name of Company" Width="146px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtEmpFname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtEmpMname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtEmpLname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
                        </tr>
                        <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 23px;">
            </td>
            <td class="Info" style="width: 100px; text-align: center; height: 23px;">
                First Name</td>
            <td class="Info" style="width: 100px; text-align: center; height: 23px;">
                Middle Name</td>
            <td class="Info" style="width: 100px; text-align: center; height: 23px;">
                Last Name</td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
                        </tr>
            <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 21px">
                Address</td>
            <td class="Info" colspan='2' style="width: 150px; height: 30px">
                <asp:TextBox ID="txtAddress" runat="server" Width="300px" Enabled="False" SkinID="txtSkin"  TextMode="MultiLine" ></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            </tr>
            <tr>
            <td class="reportTitleIncome" style="width: 196px; height: 21px">
                City</td>
            <td class="Info" style="width: 100px; height: 21px">
                <asp:TextBox ID="txtCity" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
                        </tr>
                    </table>
                </asp:Panel>    
    
       <asp:Panel ID="pnlImportLevelData" runat="server" Width="100%" Visible="False">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Product</td>
                            <td class="Info" style="width: 106px; height: 15px">
                                <asp:TextBox ID="txtProduct" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                      <%--  <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Value</td>
                            <td class="Info" style="width: 106px; height: 15px">
                                <asp:TextBox ID="txtValue" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Level Eligibility</td>
                            <td class="Info" colspan="4" style="height: 15px">
                                <asp:TextBox ID="txtLevelEli" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 21px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 21px">
                                Level Verified</td>
                            <td class="Info" colspan="4" style="height: 21px">
                                <asp:TextBox ID="txtLevelVeri" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 21px">
                            </td>
                            <td style="width: 100px; height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Reverification</td>
                            <td class="Info" colspan="4" style="height: 15px">
                                <asp:TextBox ID="txtReveri" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>--%>
                       
                       
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                BD Person</td>
                            <td class="Info" style="width: 106px; height: 15px">
                                <asp:TextBox ID="txtBDPerson" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Marketing Associate</td>
                            <td class="Info" colspan="4" style="height: 15px">
                                <asp:TextBox ID="txtMarketingAssociate" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 21px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 21px">
                                Contact Person</td>
                            <td class="Info" colspan="4" style="height: 21px">
                                <asp:TextBox ID="txtContactPerson" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 21px">
                            </td>
                            <td style="width: 100px; height: 21px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 125px; height: 15px">
                                Contact Number</td>
                            <td class="Info" colspan="4" style="height: 15px">
                                <asp:TextBox ID="txtContactNumber" runat="server" Enabled="False" SkinID="txtSkin" Width="354px"></asp:TextBox></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                       
                       
                       
                       
                    </table>
                </asp:Panel>                    
    
       <asp:Panel ID="pnlDocData" runat="server" Width="100%" Visible="false">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 163px; height: 15px">
                                Doc Receivable</td>
                            <td class="Info" style="width: 137px; height: 15px">
                                <asp:DropDownList ID="ddlDocReceivable" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>-Select-</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>Incomplete</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                                    <tr>
                            <td style="width: 5px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 163px; height: 15px">
                              Incomplete Document Details</td>
                            <td class="Info" style="width: 137px; height: 15px">
                                <asp:TextBox ID="txtIncompleteDetails" runat="server" SkinID="txtSkin"></asp:TextBox>
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px; height: 30px">
                            </td>
                            <td class="reportTitleIncome" style="width: 163px; height: 30px">
                                Company Type</td>
                            <td class="Info" style="width: 137px; height: 30px">
                                <asp:DropDownList ID="ddlCompanyType" runat="server" SkinID="ddlSkin"  Width="118px">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Companies</asp:ListItem>
                                    <asp:ListItem>Partnership Firms</asp:ListItem>
                                    <asp:ListItem>Sole Proprietorship/HUF</asp:ListItem>
                                    <asp:ListItem>Trusts</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 30px">
                            </td>
                            <td style="width: 100px; height: 30px">
                            </td>
                            <td style="width: 100px; height: 30px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
      <%-- <asp:Panel ID="pnlMainDocDetails" runat="server" Width="100%" Visible="false">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="width: 47px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" colspan="1" style="height: 15px; text-align: center; width: 110px;">
                            </td>
                            <td class="reportTitleIncome" colspan="2" style="height: 15px; text-align: center">
                                Doc Type</td>
                            <td class="reportTitleIncome" style="width: 100px; height: 15px; text-align: center">
                                Field OSV</td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" rowspan="3" style="width: 47px; text-align: center">
                                Level 3*</td>
                            <td class="reportTitleIncome" rowspan="3" style="width: 110px">
                                Indenty Proof</td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                PAN Card</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlPAN" runat="server" SkinID="ddlSkin" >
                                 <asp:ListItem Value="NA">NA</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlFieldPan" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 14px">
                            </td>
                            <td class="reportTitleIncome" style="height: 14px; width: 230px;">
                                Cancel Cheque</td>
                            <td class="Info" style="width: 100px; height: 14px">
                                <asp:DropDownList ID="ddlCheque" runat="server" SkinID="ddlSkin" >
                                 <asp:ListItem Value="NA">NA</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 14px">
                                <asp:DropDownList ID="ddlFieldCheque" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 14px">
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 30px;">
                            </td>
                            <td class="reportTitleIncome" style="height: 30px; width: 230px;">
                                Telephone Bill</td>
                            <td class="Info" style="width: 100px; height: 30px;">
                                <asp:DropDownList ID="ddlTelephone" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                           <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 30px;">
                                <asp:DropDownList ID="ddlFieldTelephone" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                          <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 30px;">
                            </td>
                            <td style="width: 100px; height: 30px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" rowspan="7" style="width: 47px; text-align: center">
                                Level 2*</td>
                            <td class="reportTitleIncome" rowspan="7" style="width: 110px">
                                Business Proof</td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                MOA &amp; AOA/Certificate Inc.</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlMOA" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                            <asp:DropDownList ID="ddlFieldMOA" runat="server" SkinID="ddlSkin" >
                            <asp:ListItem Value="NA">NA</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                Certificate of commencement of Buss</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlElectricity" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlFieldElectricity" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                 <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                Partnership Deed</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlPartnership" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlFieldPartnership" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                              <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                            </td>
                            <td class="reportTitleIncome" style="width: 230px">
                                Sales Tax &amp; Excise registration</td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlSales" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlFieldSales" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                            </td>
                            <td class="reportTitleIncome" style="width: 230px">
                                DIC/SSI/Shops &amp; Establishment</td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlDIC" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlFieldDIC" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                          <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                            </td>
                            <td class="reportTitleIncome" style="width: 230px">
                                Certificate of registration</td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlCertificate" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlFieldCertificate" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                            </td>
                            <td class="reportTitleIncome" style="width: 230px">
                                Bye Laws</td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlLaws" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px">
                                <asp:DropDownList ID="ddlFieldLaws" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 21px;">
                            </td>
                            <td class="reportTitleIncome" rowspan="4" style="width: 47px; text-align: center">
                                Level 1*</td>
                            <td class="reportTitleIncome" rowspan="4" style="width: 110px">
                                Active Business Proof</td>
                            <td class="reportTitleIncome" style="height: 21px; width: 230px;">
                                IT Return</td>
                            <td class="Info" style="width: 100px; height: 21px;">
                                <asp:DropDownList ID="ddlITreturn" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 21px;">
                                <asp:DropDownList ID="ddlFieldITreturn" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 21px;">
                            </td>
                            <td style="width: 100px; height: 21px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 10px">
                            </td>
                            <td class="reportTitleIncome" style="height: 10px; width: 230px;">
                                ST Return</td>
                            <td class="Info" style="width: 100px; height: 10px">
                                <asp:DropDownList ID="ddlSTreturn" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 10px">
                                <asp:DropDownList ID="ddlFieldSTreturn" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 10px">
                            </td>
                            <td style="width: 100px; height: 10px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                ISO certificate</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlISO" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                   <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlFieldISO" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                   <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 15px">
                            </td>
                            <td class="reportTitleIncome" style="height: 15px; width: 230px;">
                                Cancelled cheque</td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlCanCheque" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td class="Info" style="width: 100px; height: 15px">
                                <asp:DropDownList ID="ddlFieldCanCheque" runat="server" SkinID="ddlSkin" >
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                                  <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 15px">
                            </td>
                            <td style="width: 100px; height: 15px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel> --%>       
                
       <asp:Panel ID="pnlRemarkInfo" runat="server" Width="100%" Visible="false">
                    <table style="width: 128%">
                        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 196px">
                Remarks / Feedback *</td>
            <td class="Info" colspan="4">
                <asp:TextBox ID="txtRemark" runat="server" Height="48px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="613px"></asp:TextBox></td>
                        </tr>
                        <tr>
            <td style="width: 7px; height: 30px">
            </td>
            <td class="reportTitleIncome" style="height: 30px">
                Status *</td>
            <td class="Info" style="width: 100px; height: 30px">
                <asp:DropDownList ID="ddlVeriStat" runat="server" SkinID="ddlSkin" Width="144px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Deffered</asp:ListItem>
                    <asp:ListItem>Visit Done Doc's Pending</asp:ListItem>
                    <asp:ListItem>Visit Done</asp:ListItem>
                    <asp:ListItem>Hold by Client</asp:ListItem>
                    
                    <asp:ListItem>Cheque Bounce Case</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Appt Fixed</asp:ListItem>
                    <asp:ListItem>Assignment completed</asp:ListItem>
                    <asp:ListItem>Not Interested</asp:ListItem>
                    
                    </asp:DropDownList></td>
            <td style="width: 100px; height: 30px">
            </td>
            <td style="width: 100px; height: 30px">
            </td>
            <td style="width: 100px; height: 30px">
            </td>
                        </tr>
                        <tr>
            <td style="width: 7px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Date of Verification</td>
            <td class="Info" style="width: 100px; height: 16px">
                <table cellpadding="0" cellspacing="0" style="width: 152px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtVeriDate" runat="server" SkinID="txtSkin_New" Width="109px"></asp:TextBox></td>
                        <td style="width: 39px">
                            &nbsp;<img id="Img4" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Time of Verification</td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:TextBox ID="txtVeriTime" runat="server" SkinID="txtSkin_New" Width="96px"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
            </td>
                        </tr>
                        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome">
                Field Executive Name</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px">
                Supervisor Name</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
                        </tr>
                    </table>
                </asp:Panel>
   
      <br />
         
         </asp:TableCell></asp:TableRow></asp:Table>
</td>
</tr>
<tr>
            <td class="tta" colspan="8" style="height: 30px">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" Font-Bold="True" OnClick="btnSave_Click"
                    SkinID="btn" Text="Save" Width="77px" />
                <asp:Button ID="btnCan" runat="server" Font-Bold="True" OnClick="btnCan_Click" SkinID="btn"
                    Text="Cancel" Width="91px" /></td>
        </tr>
         <tr>
            <td colspan="3" style="width: 100%; height: 67px">
                <asp:HiddenField ID="hdnCaseId" runat="server" />
                <asp:HiddenField ID="hdnVerificationTypeId" runat="server" />
                &nbsp;&nbsp;&nbsp;<asp:HiddenField ID="hdnFeAssignDate" runat="server" />
            </td>
        </tr>
</table>
       
</fieldset>
</td></tr></table>   
   
</asp:Content>

