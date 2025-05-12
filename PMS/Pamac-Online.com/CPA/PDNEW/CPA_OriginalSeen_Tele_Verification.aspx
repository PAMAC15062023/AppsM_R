<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="CPA_OriginalSeen_Tele_Verification.aspx.cs" Inherits="CPA_PD_CPA_OriginalSeenVisitVerification" Title="Original Seen Visit Verification" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js" >
</script>


 <script language="javascript" type="text/javascript">
 
function MainTab_Second_AddtoGrid()
    {
                debugger;  
                var MainTab=document.getElementById("MainTab_Second");                           
                var ddlStatus=document.getElementById("<%=ddlStatus.ClientID%>");
                var txtDate=document.getElementById("<%=txtDate.ClientID%>");
                var txtTime=document.getElementById("<%=txtTime.ClientID%>");
                var txtContactNo=document.getElementById("<%=txtContactNo.ClientID%>");
                var txtRemarkLogin=document.getElementById("<%=txtRemarkLogin.ClientID%>");
                
                var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
                
                var hdnEmplomentTypeId=document.getElementById("<%=hdnEmplomentTypeId.ClientID%>");
                    
                var Index=ddlStatus.selectedIndex;
       
                var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");
                        
                var strhdvValue="";     
                var strRemark="";       
                strhdvValue=hdnMainTab_Second.value;
                strhdvValue = strhdvValue+txtDate.value+" "+txtTime.value +"|"+txtContactNo.value +"|"+txtRemarkLogin.value+"|"+ddlStatus.options[Index].innerText+"^";
                
                strRemark=txtRemark.value;
                strRemark = strRemark+txtDate.value+" "+txtTime.value +" "+txtContactNo.value +" "+txtRemarkLogin.value+" "+ddlStatus.options[Index].innerText+" ;";
                                
                RenderTable(strhdvValue,MainTab.id,5);
                hdnMainTab_Second.value=strhdvValue;
                txtRemark.value=strRemark;
                ClearGrid_MainTab_Second();
                
        
        return false;
    }  
 
 
 function ClearGrid_MainTab_Second()
    {
    
           var ddlStatus=document.getElementById("<%=ddlStatus.ClientID%>");
                var txtDate=document.getElementById("<%=txtDate.ClientID%>");
                var txtTime=document.getElementById("<%=txtTime.ClientID%>");
                var txtContactNo=document.getElementById("<%=txtContactNo.ClientID%>");
                var txtRemarkLogin=document.getElementById("<%=txtRemarkLogin.ClientID%>");
                
                ddlStatus.selectedIndex = 0;   
                txtDate.value="";              
                txtTime.value="";
                txtContactNo.value="";
                txtRemarkLogin.value="";
     }
 
function Delete_MainTab(MainTab,hdnMainTab,VisibleLength)
        {      
            
            var hdnChequeDetails=document.getElementById(hdnMainTab);                                      
            var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
             
            var MainTab=document.getElementById(MainTab);                       
            var i=0;
            var strhdvValue="";
            var j=0;
           for(i = MainTab.rows.length - 1; i > 0; i--)
            {            
                var row = MainTab.rows[i];                
                var chkObj=row.cells[0].childNodes[0];              
               
                if (chkObj!=null)
                {
                    if (chkObj.checked==true)
                    {
                       
                        MainTab.deleteRow(i);
                        txtRemark.value="";
                        
                    }                    
                }
             }  
           hdnChequeDetails.value="";
           for(i=0;i<=MainTab.rows.length-1;i++)
           {                
                if (i==0)
                {
                }
                else
                {
                    for(j=0;j<=MainTab.rows[i].cells.length-1;j++)
                    {
                        
                        hdnChequeDetails.value="";   
                        
                        if (j!=0)
                        {
                            
                            if (j==MainTab.rows[i].cells.length-1)
                            {
                                strhdvValue=strhdvValue+MainTab.rows[i].cells[j].innerText+"^";
                            }
                            else
                            {
                                strhdvValue=strhdvValue+MainTab.rows[i].cells[j].innerText+"|";
                            }
                        }
                   }
                   hdnChequeDetails.value=strhdvValue;
                }            
            }                            
                
                RenderTable(strhdvValue,MainTab.id,VisibleLength);               
                return false; 
        }  
        
    function Edit_MainTab(MainTabID,hdnMainTab)
    { 
                debugger;             
                var MainTab=document.getElementById(MainTabID);
                var hdnChequeDetails=document.getElementById(hdnMainTab);
                
                for(i = MainTab.rows.length - 1; i > 0; i--)
                { 
                    var row = MainTab.rows[i];                
                    var chkObj=row.cells[0].childNodes[0];              

                    if (chkObj!=null)
                        {
                            if (chkObj.checked==true)
                            {
                             
                                  if (MainTab.id=="MainTab_Second")
                                {                             
                                     
                                    var txtDate=document.getElementById("<%=txtDate.ClientID%>");
                                    var txtTime=document.getElementById("<%=txtTime.ClientID%>");
                                    var txtContactNo=document.getElementById("<%=txtContactNo.ClientID%>");
                                    var txtRemarkLogin=document.getElementById("<%=txtRemarkLogin.ClientID%>");
                                    var ddlStatus=document.getElementById("<%=ddlStatus.ClientID%>");
                                    
                                    txtDate.value=row.cells[1].innerText;
                                    txtTime.value=row.cells[1].innerText;
                                    txtContactNo.value=row.cells[2].innerText;
                                    txtRemarkLogin.value=row.cells[3].innerText;
                                    ddlStatus.value=row.cells[4].innerText;
                                    
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,5);
                                 }      
                                                            
                            }
                        }                         
                }    
                return false;
    }
    
    function Page_load_validation()
    {
             
        var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");                                                 
        var MainTab2=document.getElementById("MainTab_Second");
            RenderTable(hdnMainTab_Second.value,MainTab2.id,5);
            
    }


    
    function RenderTable(strhdvValue,MainTabID,VisibleValue)
    {

        var MainTab=document.getElementById(MainTabID); 
        var Totalrows=MainTab.rows.length;
            for(i = MainTab.rows.length - 1; i > 0; i--)
            { 
                MainTab.deleteRow(i);
            }
            
        var strOutPut="";
        var strRowDetails="";
        var strColDetails="";

        strRowDetails=strhdvValue.split('^', strhdvValue.length); 
        var i=0;
        var j=0;
        var strRowlength=0;

            for (i=0;i<=strRowDetails.length-2;i++)            
            {
                var rowCount=MainTab.rows.length;

                rowCount=rowCount;
                var row=document.getElementById(MainTabID).insertRow(rowCount);

                strColDetails=strRowDetails[i];
                strColDetails=strColDetails.split('|', strColDetails.length);

                var ColChkObj=row.insertCell(0); 
                ColChkObj.innerHTML="<input id='Chk_"+rowCount + "' type='checkbox' />";                      
                ColChkObj.className="SubTable_Detail";
                for (j=0;j<=strColDetails.length-1;j++)            
                {                 
                         
                        ColChkObj=row.insertCell(j+1); 
                        ColChkObj.innerHTML=strColDetails[j];
                        ColChkObj.className="SubTable_Detail";
                        if (j>=VisibleValue) 
                        {
                            ColChkObj.style.display = "none";
                        } 
                }
            }              
    } 
    
    
    function SelectAll(MainTab,chkSelectAll)
        {

            var MainTab=document.getElementById(MainTab);
            var chkSelectAll=document.getElementById(chkSelectAll);            
            var i=0;

            for(i=0;i<=MainTab.rows.length-1;i++)
            {                  
                var row = MainTab.rows[i];                
                var chkObj=row.cells[0].childNodes[0];              
               
                if (chkObj!=null)
                {  
                     chkObj.checked= chkSelectAll.checked; 
                }
            }
             
        }
    

 function SaveValidationControl()
    {
        var ddlVeriStat=document.getElementById("<%=ddlVeriStat.ClientID%>");
        var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
        
        var txtAppointmentDate=document.getElementById("<%=txtAppointmentDate.ClientID%>");
        var ddlAssignToFE=document.getElementById("<%=ddlAssignToFE.ClientID%>");
        
        var lblMsg=document.getElementById("<%=lblMsg.ClientID%>"); 
        
        var ReturnValue=true;
        var ErrorMsg="";
        
        if(txtAppointmentDate.value!='')
        {
                if(ddlVeriStat.selectedIndex==0)
                {
                    ErrorMsg='Please Select Verification Status';
                    ReturnValue=false;
                    ddlVeriStat.focus();
                }
                if(txtRemark.value=='')
                {
                    ErrorMsg='Please Enter Remark';
                    ReturnValue=false;
                    txtRemark.focus();
                }  
                 if(ddlAssignToFE.selectedIndex=0)
                {
                    ErrorMsg='Please Select Assign to FE';
                    ReturnValue=false;
                    ddlAssignToFE.focus();
                }  
                     
        }
                     
        lblMsg.innerText=ErrorMsg;
        
        if(ErrorMsg!='')
        {
            window.scrollTo(0,0);
        }
               return ReturnValue; 
    }                       


    
</script>

<table border="0" cellpadding="0" cellspacing="0" width="99%">
   <tr>
            <td class="topbar" colspan="8" style="height: 28px">
               Original Visit Tele Verification </td>
        </tr>
<tr><td style="padding-left:10px">
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" class="bx">
<tr>
<td>
 <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="true">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label CssClass="ErrorMessage" ID="lblMsg" runat="server" ForeColor="Red" Width="724px" ></asp:Label>
        </td>        
        </tr>
       </table>
   </asp:Panel>  
   <asp:Table ID="tblTeleVeri" runat="server"  Width="70%" Height="16px">
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
    
       </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >

<asp:Panel ID="PnlMainDetails" runat="server" Width="100%" Visible="False">
<table class="bx" cellpadding="0" cellspacing="0" border="0" id="tblMainDetails" style="width:100%" runat="server" >
            <tr runat="server">
                  <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Case ID</td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtCaseID" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Reference No.</td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtRefNo" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            
            <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                <asp:Label ID="Label1" runat="server" Height="13px" Text="Name of Company" Width="146px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtEmpFname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtEmpMname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtEmpLname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        <tr runat="server">
          
            <td class="reportTitleIncome" style="width: 196px" runat="server">
            </td>
            <td class="Info" style="width: 100px; text-align: center" runat="server">
                First Name</td>
            <td class="Info" style="width: 100px; text-align: center" runat="server">
                Middle Name</td>
            <td class="Info" style="width: 100px; text-align: center" runat="server">
                Last Name</td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
        </tr>
          <tr id="Tr6" runat="server">
            
            <td id="Td40" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Address</td>
            <td id="Td41"  colspan='2' class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtAddress"  runat="server" Enabled="False" Width="300px" SkinID="txtSkin" TextMode ="MultiLine" > </asp:TextBox></td>
            <td id="Td42" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td43" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td44" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td45" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td46" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td47" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            
            <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                City</td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtCity" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
             <tr id="Tr1" runat="server">
            
            <td id="Td1" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                BD Person</td>
            <td id="Td2" class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtBDPerson" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td id="Td3" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td4" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td5" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td6" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td7" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td8" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
             <tr id="Tr2" runat="server">
            
            <td id="Td9" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Marketing Associate</td>
            <td id="Td10" class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtMarketingAssociate" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td id="Td11" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td12" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td13" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td14" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td15" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td16" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
             <tr id="Tr3" runat="server">
            
            <td id="Td17" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Contact Person</td>
            <td id="Td18" class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtContactPerson" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td id="Td19" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td20" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td21" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td22" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td23" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td24" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
          <tr id="Tr4" runat="server">
            
            <td id="Td25" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Phone no</td>
            <td id="Td26" class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:TextBox ID="txtPhoneNo" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
            <td id="Td27" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td28" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td29" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td30" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td31" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td32" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        
                 
          </table>
          </asp:Panel> 
          
 <asp:Panel ID="PnlLogin" runat="server" Width="100%" Visible="False">
                   <table class="bx" cellpadding="1" cellspacing="1" border="0" id="Table1" style="width:100%" runat="server" >
                         <tr runat="server">
                            <td class="topbar" colspan="8" runat="server">
                             Tele Log Details </td>
                          </tr>
                         <tr runat="server">
                            
                            <td class="reportTitleIncome" style="width: 85px; height: 16px" runat="server">
                                Login</td>
                            <td class="reportTitleIncome" style="height: 16px; text-align: center; width: 117px;" runat="server">
                                Date[dd/mm/yyyy]</td>
                            <td class="reportTitleIncome" style="height: 16px; text-align: center; width: 57px;" runat="server">
                                Time[hh:mm]</td>
                            <td class="reportTitleIncome" style="width: 99px; height: 16px; text-align: center" runat="server">
                                Contact No</td>
                            <td class="reportTitleIncome" colspan="3" style="width: 100px; height: 16px" runat="server">
                                Remark</td>
                            <td class="reportTitleIncome" style="width: 100px; height: 16px" runat="server">
                                Status</td>
                            <td style="width: 11px" runat="server">
                            </td>
                             <td style="width: 11px" runat="server">
                             </td>
                             <td runat="server">
                             </td>
                             <td runat="server">
                             </td>
                             <td runat="server">
                             </td>
                             <td runat="server">
                             </td>
                        </tr>
                        <tr runat="server">
                           
                            <td class="reportTitleIncome" style="height: 1px; width: 85px;" runat="server">
                                1<sup>st</sup>Log</td>
                            <td class="Info" style="height: 1px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt1stDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="height: 1px; width: 57px;" runat="server">
                                <asp:TextBox ID="txt1stTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="height: 1px; width: 99px;" runat="server">
                                <asp:TextBox ID="txt1stContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" style="height: 1px" colspan="3" runat="server">
                                <asp:TextBox ID="txt1stRemark" runat="server" SkinID="txtSkin" Height="16px" Width="201px"></asp:TextBox></td>
                            <td class="Info" style="height: 1px" runat="server">
                            <asp:DropDownList ID="ddlStatus1stCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td style="height: 1px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                          
                            <td class="reportTitleIncome" style="width: 85px; height: 1px" runat="server">
                                2<sup>nd</sup> Log</td>
                            <td class="Info" style="height: 1px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt2ndDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 1px" runat="server">
                                <asp:TextBox ID="txt2ndTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 1px" runat="server">
                                <asp:TextBox ID="txt2ndContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 1px" runat="server">
                                <asp:TextBox ID="txt2ndRemark" runat="server" SkinID="txtSkin" Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 1px" runat="server">
                                <asp:DropDownList ID="ddlStatus2ndCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 1px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                            <td style="height: 1px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                           
                            <td class="reportTitleIncome" style="width: 85px; height: 12px" runat="server">
                                3<sup>rd</sup> Log</td>
                            <td class="Info" style="height: 12px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt3rdDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img2"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 12px" runat="server">
                                <asp:TextBox ID="txt3rdTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 12px" runat="server">
                                <asp:TextBox ID="txt3rdContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 12px" runat="server">
                                <asp:TextBox ID="txt3rdRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 12px" runat="server">
                                <asp:DropDownList ID="ddlStatus3rdCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 12px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 12px" runat="server">
                            </td>
                            <td style="height: 12px" runat="server">
                            </td>
                            <td style="height: 12px" runat="server">
                            </td>
                            <td style="height: 12px" runat="server">
                            </td>
                            <td style="height: 12px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                          <td class="reportTitleIncome" style="width: 85px; height: 15px" runat="server">
                                4<sup>th</sup> Log</td>
                            <td class="Info" style="height: 15px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt4thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img3"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 15px" runat="server">
                                <asp:TextBox ID="txt4thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 15px" runat="server">
                                <asp:TextBox ID="txt4thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 15px" runat="server">
                                <asp:TextBox ID="txt4thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 15px" runat="server"><asp:DropDownList ID="ddlStatus4thCall" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                            </asp:DropDownList></td>
                            <td style="height: 15px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 15px" runat="server">
                            </td>
                            <td style="height: 15px" runat="server">
                            </td>
                            <td style="height: 15px" runat="server">
                            </td>
                            <td style="height: 15px" runat="server">
                            </td>
                            <td style="height: 15px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                           <td class="reportTitleIncome" style="width: 85px;" runat="server">
                                5<sup>th</sup> Log
                            </td>
                            <td class="Info" style="width: 117px;" runat="server">
                                <asp:TextBox ID="txt5thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img4"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px;" runat="server">
                                <asp:TextBox ID="txt5thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px;" runat="server">
                                <asp:TextBox ID="txt5thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px;" runat="server">
                                <asp:TextBox ID="txt5thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px;" runat="server">
                                <asp:DropDownList ID="ddlStatus5thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 11px" runat="server">
                            </td>
                            <td style="width: 11px" runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                           <td class="reportTitleIncome" style="width: 85px;" runat="server">
                                6<sup>th</sup> Log</td>
                            <td class="Info" style="width: 117px;" runat="server">
                                <asp:TextBox ID="txt6thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img5"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px;" runat="server">
                                <asp:TextBox ID="txt6thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px;" runat="server">
                                <asp:TextBox ID="txt6thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px;" runat="server">
                                <asp:TextBox ID="txt6thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px;" runat="server">
                                <asp:DropDownList ID="ddlStatus6thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 11px" runat="server">
                            </td>
                            <td style="width: 11px" runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                            <td runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                            <td class="reportTitleIncome" style="width: 85px; height: 2px" runat="server">
                                7<sup>th</sup> Log</td>
                            <td class="Info" style="height: 2px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt7thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img6"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 2px" runat="server">
                                <asp:TextBox ID="txt7thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 2px" runat="server">
                                <asp:TextBox ID="txt7thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 2px" runat="server">
                                <asp:TextBox ID="txt7thRemark" runat="server" SkinID="txtSkin"
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 2px" runat="server">
                                <asp:DropDownList ID="ddlStatus7thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 2px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 2px" runat="server">
                            </td>
                            <td style="height: 2px" runat="server">
                            </td>
                            <td style="height: 2px" runat="server">
                            </td>
                            <td style="height: 2px" runat="server">
                            </td>
                            <td style="height: 2px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                         <td class="reportTitleIncome" style="width: 85px; height: 8px" runat="server">
                                8<sup>th</sup> Log</td>
                            <td class="Info" style="height: 8px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt8thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img7"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 8px" runat="server">
                                <asp:TextBox ID="txt8thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 8px" runat="server">
                                <asp:TextBox ID="txt8thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 8px" runat="server">
                                <asp:TextBox ID="txt8thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 8px" runat="server">
                                <asp:DropDownList ID="ddlStatus8thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 8px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 8px" runat="server">
                            </td>
                            <td style="height: 8px" runat="server">
                            </td>
                            <td style="height: 8px" runat="server">
                            </td>
                            <td style="height: 8px" runat="server">
                            </td>
                            <td style="height: 8px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                          <td class="reportTitleIncome" style="width: 85px; height: 9px" runat="server">
                                9<sup>th</sup> Log</td>
                            <td class="Info" style="height: 9px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt9thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img8"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 9px" runat="server">
                                <asp:TextBox ID="txt9thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 9px" runat="server">
                                <asp:TextBox ID="txt9thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 9px" runat="server">
                                <asp:TextBox ID="txt9thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 9px" runat="server">
                                <asp:DropDownList ID="ddlStatus9thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 9px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 9px" runat="server">
                            </td>
                            <td style="height: 9px" runat="server">
                            </td>
                            <td style="height: 9px" runat="server">
                            </td>
                            <td style="height: 9px" runat="server">
                            </td>
                            <td style="height: 9px" runat="server">
                            </td>
                        </tr>
                        <tr runat="server">
                          
                            <td class="reportTitleIncome" style="width: 85px; height: 5px" runat="server">
                                10<sup>th</sup>Log</td>
                            <td class="Info" style="height: 5px; width: 117px;" runat="server">
                                <asp:TextBox ID="txt10thDate" runat="server" SkinID="txtSkin" Width="80px"></asp:TextBox><img id="Img9"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all., 'dd/mm/yyyy', 0, 0);" /></td>
                            <td class="Info" style="width: 57px; height: 5px" runat="server">
                                <asp:TextBox ID="txt10thTime" runat="server" SkinID="txtSkin" Width="53px"></asp:TextBox></td>
                            <td class="Info" style="width: 99px; height: 5px" runat="server">
                                <asp:TextBox ID="txt10thContact" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td class="Info" colspan="3" style="width: 100px; height: 5px" runat="server">
                                <asp:TextBox ID="txt10thRemark" runat="server" SkinID="txtSkin" 
                                    Width="201px"></asp:TextBox></td>
                            <td class="Info" style="width: 100px; height: 5px" runat="server">
                                <asp:DropDownList ID="ddlStatus10thCall" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                    <asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
                                    <asp:ListItem Text="NI" Value="NI"></asp:ListItem>
                                    <asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                    <asp:ListItem Text="Query" Value="Query"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                                    <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                    <asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
                                    <asp:ListItem Text="Out of station" Value="Out of station"></asp:ListItem>
                                    <asp:ListItem Text="Today appoinment" Value="Today appoinment"></asp:ListItem>
                                    <asp:ListItem Text="Tomorrow appoinment" Value="Tomorrow appoinment"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 5px; width: 11px;" runat="server">
                            </td>
                            <td style="width: 11px; height: 5px" runat="server">
                            </td>
                            <td style="height: 5px" runat="server">
                            </td>
                            <td style="height: 5px" runat="server">
                            </td>
                            <td style="height: 5px" runat="server">
                            </td>
                            <td style="height: 5px" runat="server">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
           
  <asp:Panel ID="pnlLoginDetails" runat="server" CssClass="tabbertab" Visible="false">
                            <table cellspacing="1" class="bx" style="width: 311px">
                            <tr>
                                <td class="tta" colspan="6" style="height: 16px">
                                    Tele Log Details</td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="height: 16px; text-align: center">
                                    Date[dd/mm/yyyy]</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Time[hh:mm]</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Contact No.</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Remark</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Status</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                               <td class="Info" style="width: 100px" >
                               <table cellspacing="1"  style="text-align: center">
                                   <tr>
                                      <td class="Info" >
                                       <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td class="Info" >
                                    <img id="Img10" alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                   </td>
                                   </tr>
                               </table>
                                     </td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtTime" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtRemarkLogin" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                   <td class="Info" style="width: 100px">
                                      <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Deffered</asp:ListItem>
                                        <asp:ListItem>Visit Done Docs Pending</asp:ListItem>
                                        <asp:ListItem>Visit Done</asp:ListItem>
                                        <asp:ListItem>Hold by Client</asp:ListItem>
                                        <asp:ListItem>Cheque Bounce Case</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Appt Fixed</asp:ListItem>
                                        <asp:ListItem>Assignment completed</asp:ListItem>
                                        <asp:ListItem>Not Interested</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                             
                                <td class="Info" style="width: 100px">
                                    <table>
                                        <tr>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Add" runat="server" SkinID="btn" Text="Add" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Del" runat="server" SkinID="btn" Text="Del" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Edit" runat="server" SkinID="btn" Text="Edit" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="height: 14px">
                                    <div id="Div2" style="overflow: scroll; width: 776px; height: 116px">
                                        <table id="MainTab_Second" cellpadding="2" cellspacing="1" style="width: 755px">
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 24px">
                                                    <input id="chkSelectAll_Second" onclick="javascript:SelectAll('MainTab_Second','chkSelectAll_Second');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Date Time</th>
                                                <%--<th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Time</th>--%>
                                                    <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                                    Contact No.</th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                    Remark</th>
                                                 <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                     Status</th>
                                                
                                                <th style="width: 15px; height: 24px">
                                                </th>
                                                <th style="width: 3px; height: 24px">
                                                </th>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdnEmplomentTypeId" runat="server" Value="51" />
                                    <asp:HiddenField ID="hdnMainTab_Second" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel> 
           
<asp:Panel ID="pnlFEConfirmation" runat="server" Width="100%" Visible="False">
  <table class="bx" cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server" >
            <tr runat="server">
             <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Appointment Date</td>
            <td class="Info" colspan="2" runat="server">
                <asp:TextBox ID="txtAppointmentDate" runat="server" SkinID="txtSkin" Width="103px"></asp:TextBox>
                <img id="Img11"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtAppointmentDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            <td class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
                Assign to FE</td>
            <td class="Info" style="width: 100px; height: 21px" runat="server">
                <asp:DropDownList ID="ddlAssignToFE" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                      </asp:DropDownList></td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
            <td style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>    
         <tr id="Tr5" runat="server">
             <td id="Td33" class="reportTitleIncome" style="width: 196px; height: 21px" runat="server">
               Next Follow up</td>
            <td id="Td34" class="Info" colspan="2" runat="server">
                <asp:TextBox ID="txtNextFollowup" runat="server" SkinID="txtSkin" Width="103px"></asp:TextBox>
                <img id="Img12"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtNextFollowup.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
            <td id="Td35" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td36" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td37" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td38" style="width: 100px; height: 21px" runat="server">
            </td>
            <td id="Td39" style="width: 100px; height: 21px" runat="server">
            </td>
        </tr>      
          </table>
          </asp:Panel>   
          
    
 <asp:Panel ID="PnlFinalDetails" runat="server" Width="100%" Visible="False">
      <table class="bx" cellpadding="0" cellspacing="0" border="0" id="tblFinalDetails" style="width:100%" runat="server" >

        <tr runat="server">
            <td class="reportTitleIncome" style="width: 196px" runat="server">
                Remarks / Feedback *</td>
            <td class="Info" colspan="4" runat="server">
                <asp:TextBox ID="txtRemark" runat="server" Height="48px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="613px"></asp:TextBox></td>
            <td style="width: 100px" runat="server">
            </td>
        </tr>
        <tr runat="server">
          
            <td class="reportTitleIncome" style="height: 30px" runat="server">
                Status *</td>
            <td class="Info" style="width: 100px; height: 30px" runat="server">
                <asp:DropDownList ID="ddlVeriStat" runat="server" SkinID="ddlSkin" Width="144px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Deffered</asp:ListItem>
                    <asp:ListItem>Visit Done Docs Pending</asp:ListItem>
                    <asp:ListItem>Visit Done</asp:ListItem>
                    <asp:ListItem>Hold by Client</asp:ListItem>
                    <asp:ListItem>Cheque Bounce Case</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Appt Fixed</asp:ListItem>
                    <asp:ListItem>Assignment completed</asp:ListItem>
                    <asp:ListItem>Not Interested</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 30px" runat="server">
            </td>
            <td style="width: 100px; height: 30px" runat="server">
            </td>
            <td style="width: 99px; height: 30px" runat="server">
            </td>
            <td style="width: 100px; height: 30px" runat="server">
            </td>
        </tr>
        <tr runat="server">
          
            <td class="reportTitleIncome" style="height: 16px" runat="server">
                Date of Verification</td>
            <td class="Info" style="width: 100px; height: 16px" runat="server">
                <table cellpadding="0" cellspacing="0" style="width: 152px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtVeriDate" runat="server" SkinID="txtSkin_New" Width="109px"></asp:TextBox></td>
                        <td style="width: 39px">
                            &nbsp;<img id="Image1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px" runat="server">
                Time of Verification</td>
            <td class="Info" style="width: 100px; height: 16px" runat="server">
                <asp:TextBox ID="txtVeriTime" runat="server" SkinID="txtSkin_New" Width="96px"></asp:TextBox></td>
            <td style="width: 99px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            
            <td class="reportTitleIncome" runat="server">
                Field Executive Name</td>
            <td class="Info" style="width: 100px" runat="server">
                <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px" runat="server">
                Supervisor Name</td>
            <td class="Info" style="width: 100px" runat="server">
                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 99px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            <td style="width: 47px; height: 16px" runat="server">
            </td>
            <td style="width: 196px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
            <td style="width: 100px; height: 16px" runat="server">
            </td>
        </tr>
        <tr runat="server">
            <td class="tta" colspan="6" style="height: 30px" runat="server">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" Font-Bold="True" OnClick="btnSave_Click"
                    SkinID="btn" Text="Save" Width="77px" />
                <asp:Button ID="btnCan" runat="server" Font-Bold="True" OnClick="btnCan_Click" SkinID="btn"
                    Text="Cancel" Width="91px" /></td>
        </tr>
        <tr runat="server">
            <td style="width: 47px" runat="server">
            </td>
            <td style="width: 196px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
            <td style="width: 100px" runat="server">
            </td>
        </tr>
    </table>
    </asp:Panel>
        
</asp:TableCell></asp:TableRow></asp:Table>
</td>
</tr>
<tr><td></td><td></td><td></td></tr>
</table>
    <asp:HiddenField ID="hdnVerificationTypeId" runat="server" />
     <asp:HiddenField ID="hdnCaseId" runat="server" Value="1012" />
    &nbsp;
    

</td></tr>
</table>

</asp:Content>

