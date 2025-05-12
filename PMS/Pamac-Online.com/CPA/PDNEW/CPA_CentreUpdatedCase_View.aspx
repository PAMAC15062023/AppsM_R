<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPA_CentreUpdatedCase_View.aspx.cs" Inherits="CPA_PD_CPA_CentreUpdatedCase_View" StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Case Final Update</title>
    <script language="javascript" type="text/javascript">
    
    function Validate_Dropdown(Label1,Dropdown1)
    {
   
    
        var Label=document.getElementById(Label1);
        var Drpdown=document.getElementById(Dropdown1);        
        
        if ((Drpdown.value=='Yes'))
        {      
                 
            Label.className='DocumentUpdationYes';
        }
        else 
        {
             Label.className='DocumentUpdationNo';
        }
     }
        </script>
        
<script language="javascript" type="text/javascript">
  
        function JavaScriptValidation()
        {   
            var ddlPAN = document.getElementById("<%=ddlPAN.ClientID%>");
            var ddlTelephone = document.getElementById("<%=ddlTelephone.ClientID%>");
            var ddlMOA = document.getElementById("<%=ddlMOA.ClientID%>");
            var ddlElectricity = document.getElementById("<%=ddlElectricity.ClientID%>");
            var ddlPartnership = document.getElementById("<%=ddlPartnership.ClientID%>");
            var ddlSales = document.getElementById("<%=ddlSales.ClientID%>");
            var ddlDIC = document.getElementById("<%=ddlDIC.ClientID%>");
            var ddlCertificate = document.getElementById("<%=ddlCertificate.ClientID%>");
            var ddlLaws = document.getElementById("<%=ddlLaws.ClientID%>");
            var ddlITreturn = document.getElementById("<%=ddlITreturn.ClientID%>");
            var ddlSTreturn = document.getElementById("<%=ddlSTreturn.ClientID%>");
            var ddlISO = document.getElementById("<%=ddlISO.ClientID%>");
            var ddlCanCheque = document.getElementById("<%=ddlCanCheque.ClientID%>"); 
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>");         
                 
            var lblPAN = document.getElementById("<%=lblPAN.ClientID%>"); 
            var lblTelephone = document.getElementById("<%=lblTelephone.ClientID%>"); 
            var lblMOA = document.getElementById("<%=lblMOA.ClientID%>"); 
            var lblCertificateBuss = document.getElementById("<%=lblCertificateBuss.ClientID%>"); 
            var lblPartnership = document.getElementById("<%=lblPartnership.ClientID%>"); 
            var lblSales = document.getElementById("<%=lblSales.ClientID%>"); 
            var lblDIC = document.getElementById("<%=lblDIC.ClientID%>"); 
            var lblCertificateRegi = document.getElementById("<%=lblCertificateRegi.ClientID%>"); 
            var lblLaws = document.getElementById("<%=lblLaws.ClientID%>"); 
            var lblITreturn = document.getElementById("<%=lblITreturn.ClientID%>"); 
            var lblSTreturn = document.getElementById("<%=lblSTreturn.ClientID%>"); 
            var lblISO = document.getElementById("<%=lblISO.ClientID%>"); 
            var lblCheque = document.getElementById("<%=lblCheque.ClientID%>"); 

                 
                var ReturnValue=true;
                var ErrorMsg="";                     
                var CountData=0;
                
                    if(ddlPAN.selectedIndex!=0)
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
                    
 //////////////////////////////////////////////////////////////////////////////////////////////                   
                    
                    if(lblPAN.innerText=='Yes')
                    {
                        if(ddlPAN.value!=lblPAN.innerText)                    
                        {
                        ErrorMsg='Please select Valid PanCard';    
                        ddlPAN.focus();
                        }                        
                    }
                    else if(lblTelephone.innerText=='Yes')
                    {
                        if(ddlTelephone.value!=lblTelephone.innerText)                    
                        {
                        ErrorMsg='Please select Valid Telephone';    
                        ddlTelephone.focus();
                        }                        
                    }
                    else if(lblMOA.innerText=='Yes')
                    {
                        if(ddlMOA.value!=lblMOA.innerText)                    
                        {
                        ErrorMsg='Please select Valid MOA';    
                        ddlMOA.focus();
                        }                        
                    }
                    else if(lblCertificateBuss.innerText=='Yes')
                    {
                        if(ddlElectricity.value!=lblCertificateBuss.innerText)                    
                        {
                        ErrorMsg='Please select Valid Certificate of Bussiness';    
                        ddlElectricity.focus();
                        }                        
                    }
                    else if(lblPartnership.innerText=='Yes')
                    {
                        if(ddlPartnership.value!=lblPartnership.innerText)                    
                        {
                        ErrorMsg='Please select Valid Partnership';    
                        ddlPartnership.focus();
                        }                        
                    }
                    else if(lblSales.innerText=='Yes')
                    {
                        if(ddlSales.value!=lblSales.innerText)                    
                        {
                        ErrorMsg='Please select Valid Sales';    
                        ddlSales.focus();
                        }                        
                    }
                    else if(lblDIC.innerText=='Yes')
                    {
                        if(ddlDIC.value!=lblDIC.innerText)                    
                        {
                        ErrorMsg='Please select Valid DIC';    
                        ddlDIC.focus();
                        }                        
                    }
                    else if(lblCertificateRegi.innerText=='Yes')
                    {
                        if(ddlCertificate.value!=lblCertificateRegi.innerText)                    
                        {
                        ErrorMsg='Please select Valid Certificate of Registration';    
                        ddlCertificate.focus();
                        }                        
                    }
                    else if(lblLaws.innerText=='Yes')
                    {
                        if(ddlLaws.value!=lblLaws.innerText)                    
                        {
                        ErrorMsg='Please select Valid Laws';    
                        ddlLaws.focus();
                        }                        
                    }
                    else if(lblITreturn.innerText=='Yes')
                    {
                        if(ddlITreturn.value!=lblITreturn.innerText)                    
                        {
                        ErrorMsg='Please select Valid IT return';    
                        ddlITreturn.focus();
                        }                        
                    }
                    else if(lblSTreturn.innerText=='Yes')
                    {
                        if(ddlSTreturn.value!=lblSTreturn.innerText)                    
                        {
                        ErrorMsg='Please select Valid ST return';    
                        ddlSTreturn.focus();
                        }                        
                    }
                    else if(lblISO.innerText=='Yes')
                    {
                        if(ddlISO.value!=lblISO.innerText)                    
                        {
                        ErrorMsg='Please select Valid ISO';    
                        ddlISO.focus();
                        }                        
                    }
                    else if(lblCheque.innerText=='Yes')
                    {
                        if(ddlCanCheque.value!=lblCheque.innerText)                    
                        {
                        ErrorMsg='Please select Valid Cheque';    
                        ddlCanCheque.focus();
                        }                        
                    }            
                    if(ErrorMsg!='')
                    {               
                        window.scroll(0,0); 
                    }     
                                     
                        return ReturnValue; 
                }                
    </script>
    
    <link href="../../StyleSheet_EBC.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 15px">
                </td>
                <td class="reportTitleIncome" style="width: 100px">
                    <span style="font-size: 8pt">Reference No.</span></td>
                <td class="Info" style="font-size: 12pt">
                    <asp:Label ID="lblRefNo" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label><span
                        style="font-size: 8pt"></span></td>
                <td class="reportTitleIncome" style="font-size: 12pt; width: 100px; text-align: left">
                    <span style="font-size: 8pt">Case Id</span></td>
                <td class="Info" style="font-size: 12pt; width: 100px; text-align: left">
                    <asp:Label ID="lblCaseId" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
            </tr>
            <tr id="t1">
                <td style="width: 15px">
                </td>
                <td class="reportTitleIncome" style="width: 100px">
                    Applicant Name</td>
                <td class="reportTitleIncome" colspan="2" style="font-size: 12pt">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                     </td>
                <td class="Info" style="font-size: 12pt; width: 100px; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 15px; height: 17px;">
                </td>
                <td style="width: 100px; height: 17px;" class="reportTitleIncome">
                </td>
                <td style="width: 100px; height: 17px;" class="reportTitleIncome">
                </td>
                <td style="width: 104px; font-size: 12pt; height: 17px;" class="reportTitleIncome">
                    <strong><span style="font-size: 9pt">Centre Updation</span></strong></td>
                <td style="width: 100px; font-size: 12pt; text-align: center; height: 17px;" class="Info">
                    <strong><span style="font-size: 9pt; color: navy">HO Updation</span></strong></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 20px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 20px">
                    PAN card copy</td>
                <td style="width: 104px; height: 20px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblPAN" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 20px; text-align: center;" class="Info">
                     <asp:DropDownList ID="ddlPAN" runat="server" SkinID="ddlSkin">
                         <asp:ListItem>-Select-</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Copy of telephone / utility bill</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblTelephone" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                    <asp:DropDownList ID="ddlTelephone" runat="server" SkinID="ddlSkin">
                            <asp:ListItem>-Select-</asp:ListItem>
                           <asp:ListItem Value="No">No</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    MOA &amp; AOA / certificate of incorporation</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblMOA" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                 <asp:DropDownList ID="ddlMOA" runat="server" SkinID="ddlSkin">
                              <asp:ListItem>-Select-</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                              <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 21px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 21px">
                    Sales tax &amp; Excise registration</td>
                <td style="width: 104px; height: 21px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblSales" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 21px; text-align: center;" class="Info">
                   <asp:DropDownList ID="ddlSales" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Certification of commencement of business</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblCertificateBuss" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                  <asp:DropDownList ID="ddlElectricity" runat="server" SkinID="ddlSkin">
                               <asp:ListItem>-Select-</asp:ListItem>
                              <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Latest IT return</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblITreturn" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                 <asp:DropDownList ID="ddlITreturn" runat="server" SkinID="ddlSkin">
                                  <asp:ListItem>-Select-</asp:ListItem>
                                 <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Latest ST return</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblSTreturn" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                    <asp:DropDownList ID="ddlSTreturn" runat="server" SkinID="ddlSkin">
                              <asp:ListItem>-Select-</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Cancelled cheque</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblCheque" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                 <asp:DropDownList ID="ddlCanCheque" runat="server" SkinID="ddlSkin">
                                 <asp:ListItem>-Select-</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    ISO certificate</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblISO" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                 <asp:DropDownList ID="ddlISO" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem>-Select-</asp:ListItem>
                                   <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Partnership Deed</td>
                <td style="width: 104px; height: 23px; text-align: center;" class="reportTitleIncome">
                    <asp:Label ID="lblPartnership" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td style="width: 100px; height: 23px; text-align: center;" class="Info">
                 <asp:DropDownList ID="ddlPartnership" runat="server" SkinID="ddlSkin">
                              <asp:ListItem>-Select-</asp:ListItem>
                             <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    DIC / SSI / Shops &amp; Establishment</td>
                <td class="reportTitleIncome" style="width: 104px; height: 23px; text-align: center">
                    <asp:Label ID="lblDIC" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td class="Info" style="width: 100px; height: 23px; text-align: center">
                   <asp:DropDownList ID="ddlDIC" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>-Select-</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Certificate of registration</td>
                <td class="reportTitleIncome" style="width: 104px; height: 23px; text-align: center">
                    <asp:Label ID="lblCertificateRegi" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td class="Info" style="width: 100px; height: 23px; text-align: center">
                       <asp:DropDownList ID="ddlCertificate" runat="server" SkinID="ddlSkin">
                             <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 23px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 23px">
                    Bye Laws</td>
                <td class="reportTitleIncome" style="width: 104px; height: 23px; text-align: center">
                    <asp:Label ID="lblLaws" runat="server" Font-Bold="True" Font-Size="X-Small"></asp:Label></td>
                <td class="Info" style="width: 100px; height: 23px; text-align: center">
                    <asp:DropDownList ID="ddlLaws" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>-Select-</asp:ListItem>
                               <asp:ListItem Value="No">No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 15px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                    <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" OnClick="btnUpdate_Click"
                        Text="Update" Width="76px" /></td>
                <td style="width: 100px; height: 21px;">
                    <asp:Button ID="btnClose" runat="server" Font-Bold="True" 
                        Text="Close" Width="76px" OnClick="btnClose_Click" OnClientClick="return false, window.close()" /></td>
                <td style="width: 104px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 15px">
                </td>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                <td style="width: 104px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 15px">
                </td>
                <td colspan="2">
                </td>
                <td style="width: 104px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
