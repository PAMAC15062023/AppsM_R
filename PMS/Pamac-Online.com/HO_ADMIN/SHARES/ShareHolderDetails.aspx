<%@ Page Language="C#" MasterPageFile="~/HO_ADMIN/SHARES/MasterPage.master" AutoEventWireup="true" CodeFile="ShareHolderDetails.aspx.cs" Inherits="HO_ADMIN_SHARES_ShareHolderDetails" Title="PAMAC ShareHolder Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <script type="text/javascript" src="../../popcalendar.js"></script>
    
    <script language="javascript"  type="text/jscript">
    
    function Page_load_validation()
    {
        var hdnSharesDetails=document.getElementById("<%=hdnSharesDetails.ClientID%>");                                                 
        var MainTab1=document.getElementById("MainTab");
        RenderTable(hdnSharesDetails.value,MainTab1.id,10);
        
       }
    function Count_Amount()
    {
        var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");  
        var txtNoofShares=document.getElementById("<%=txtNoofShares.ClientID%>");  
        var txtRatePreShare=document.getElementById("<%=txtRatePreShare.ClientID%>");  
       
        txtAmount.value=parseInt(txtNoofShares.value)* parseInt(txtRatePreShare.value);        
             
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
    
     function Edit_MainTab(MainTabID,hdnMainTab)
    {
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
                                if (MainTab.id=="MainTab")
                                {
                                    var ddlType=document.getElementById("<%=ddlType.ClientID%>");  
                                    var txtDateOfAllotment=document.getElementById("<%=txtDateOfAllotment.ClientID%>");  
                                    var txtCertificateNo=document.getElementById("<%=txtCertificateNo.ClientID%>");  
                                    var txtDistNo=document.getElementById("<%=txtDistNo.ClientID%>");  
                                    var txtNoofShares=document.getElementById("<%=txtNoofShares.ClientID%>");  
                                    var txtRatePreShare=document.getElementById("<%=txtRatePreShare.ClientID%>");  
                                    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
                                    var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");  

                            
                                    ddlType.value=row.cells[1].innerText;
                                    txtDateOfAllotment.value=row.cells[2].innerText;
                                    txtCertificateNo.value=row.cells[3].innerText;
                                    txtDistNo.value=row.cells[4].innerText;
                                    
                                    txtNoofShares.value=row.cells[5].innerText;
                                    txtRatePreShare.value=row.cells[6].innerText;
                                   
                                    txtAmount.value=row.cells[7].innerText;
                                    txtRemark.value=row.cells[8].innerText;
                                     
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,10);
                                 }
                             

                            }
                        }  
                        
                    }    
                return false;
    }
    
    
     function Delete_MainTab(MainTab,hdnMainTab,VisibleLength)
        {                
            var hdnChequeDetails=document.getElementById(hdnMainTab);                                      
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
   
    function Validate_ShareDetails_Add()
    {
        var ddlType=document.getElementById("<%=ddlType.ClientID%>");  
        var txtDateOfAllotment=document.getElementById("<%=txtDateOfAllotment.ClientID%>");  
        var txtCertificateNo=document.getElementById("<%=txtCertificateNo.ClientID%>");  
        var txtDistNo=document.getElementById("<%=txtDistNo.ClientID%>");  
        var txtNoofShares=document.getElementById("<%=txtNoofShares.ClientID%>");  
        var txtRatePreShare=document.getElementById("<%=txtRatePreShare.ClientID%>");  
        var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
        var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");  
        
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");   

                                                          
            var ReturnValue=true;
            var ErrorMessage=''; 
            
             if (txtRemark.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter Remarks!';
                txtRemark.focus();
            } 
             
            if (txtRatePreShare.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter Rate per Share!';
                txtRatePreShare.focus();
            }  
             if (txtDistNo.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter Dist No!';
                txtDistNo.focus();
            }  
            
             if (txtNoofShares.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter No of Shares!';
                txtNoofShares.focus();
            }   
             if (txtCertificateNo.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter Certificate No!';
                txtCertificateNo.focus();
            }  
             if (txtDateOfAllotment.value=='')
            {
                ReturnValue=false;   
                ErrorMessage='Please enter Date of Allotment!';
                txtDateOfAllotment.focus();
            }  
                
            if (ddlType.selectedIndex==0)
            {
                ReturnValue=false;   
                ErrorMessage='Please select Type to continue!';
                ddlType.focus();
            }
            
            
            lblMessage.innerText=ErrorMessage;
            
            window.scrollTo(0,0);            
            return ReturnValue; 
               
    }
    function Add_ShareDetails()
    {
            if (Validate_ShareDetails_Add())
            {
                
                var MainTab=document.getElementById("MainTab");                           
                var ddlType=document.getElementById("<%=ddlType.ClientID%>");  
                var txtDateOfAllotment=document.getElementById("<%=txtDateOfAllotment.ClientID%>");  
                var txtCertificateNo=document.getElementById("<%=txtCertificateNo.ClientID%>");  
                var txtDistNo=document.getElementById("<%=txtDistNo.ClientID%>");  
                var txtNoofShares=document.getElementById("<%=txtNoofShares.ClientID%>");  
                var txtRatePreShare=document.getElementById("<%=txtRatePreShare.ClientID%>");  
                var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
                var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");  
                       
                var hdnSharesDetails=document.getElementById("<%=hdnSharesDetails.ClientID%>");
                var TypeIndex=ddlType.selectedIndex;
                    
                    
               txtAmount.value=parseInt(txtNoofShares.value)* parseInt(txtRatePreShare.value);        
                var strhdvValue="";            
                strhdvValue=hdnSharesDetails.value;
                strhdvValue = strhdvValue + ddlType.options[TypeIndex].innerText+"|"+txtDateOfAllotment.value +"|"+txtCertificateNo.value +"|"+ txtDistNo.value+"|"+ txtNoofShares.value+"|"+txtRatePreShare.value+"|"+txtAmount.value+"|"+txtRemark.value+"^";
                RenderTable(strhdvValue,MainTab.id,10);
                hdnSharesDetails.value=strhdvValue;
                ClearGrid_MainTab();
                
            
            }
            return false;
    }
    function ClearGrid_MainTab()
    {
    
                var ddlType=document.getElementById("<%=ddlType.ClientID%>");  
                var txtDateOfAllotment=document.getElementById("<%=txtDateOfAllotment.ClientID%>");  
                var txtCertificateNo=document.getElementById("<%=txtCertificateNo.ClientID%>");  
                var txtDistNo=document.getElementById("<%=txtDistNo.ClientID%>");  
                var txtNoofShares=document.getElementById("<%=txtNoofShares.ClientID%>");  
                var txtRatePreShare=document.getElementById("<%=txtRatePreShare.ClientID%>");  
                var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
                var txtAmount=document.getElementById("<%=txtAmount.ClientID%>");  
            
                ddlType.selectedIndex=0;
                txtDateOfAllotment.value='';
                txtCertificateNo.value='';
                txtDistNo.value='';
                txtNoofShares.value='';
                txtRatePreShare.value='';
                txtRemark.value='';
                txtAmount.value='';
    }
    
    function Validate_Save()
    {
            var hdnSharesDetails=document.getElementById("<%=hdnSharesDetails.ClientID%>");                                                 
            var txtFirstName=document.getElementById("<%=txtFirstName.ClientID%>");                                                 
            var txtMiddleName=document.getElementById("<%=txtMiddleName.ClientID%>");                                                 
            var txtLastName=document.getElementById("<%=txtLastName.ClientID%>");                                                 
            var txtFatherName=document.getElementById("<%=txtFatherName.ClientID%>");                                                 
            var txtFolioNo=document.getElementById("<%=txtFolioNo.ClientID%>");                                                 
            var txtResidenceAddress=document.getElementById("<%=txtResidenceAddress.ClientID%>");                                                 
            var hdnSharesDetails=document.getElementById("<%=hdnSharesDetails.ClientID%>");                                                 
                var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");   

            var ReturnValue=true;
            var ErrorMessage='';
            
             if (hdnSharesDetails.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter atleast one Shares Details!';
                 
            }
            
            if (txtResidenceAddress.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter Residence Address!';
                txtResidenceAddress.focus();
            }
            
            if (txtFolioNo.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter Folio No!';
                txtFolioNo.focus();
            }
            
             if (txtFatherName.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter Father Name!';
                txtFatherName.focus();
            }
            
          
             if (txtLastName.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter Last Name!';
                txtLastName.focus();
            }
            
            if (txtMiddleName.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter Middle Name!';
                txtMiddleName.focus();
            }
              if (txtFirstName.value=='')
            {
                ReturnValue=false;
                ErrorMessage='Please enter First Name!';
                txtFirstName.focus();
            }
            
            
            window.scrollTo(0,0);
            lblMessage.innerText=ErrorMessage;
            
            return ReturnValue;
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
    
    
    </script>
    
    
    <table style="width: 100%" class="bx">
    
    
        <tr>
            <td colspan="9">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="9" style="height: 3px">
                &nbsp;Share Holder Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="reportTitleIncome" style="width: 180px">
                <asp:Label ID="Label1" runat="server" Text="Share Holder Name" Width="154px"></asp:Label></td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox></td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnShareHolderID" runat="server" Value="0" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 180px">
                &nbsp;</td>
            <td class="Info" style="width: 100px; text-align: center">
                First Name</td>
            <td class="Info" style="width: 100px; text-align: center">
                Middle Name</td>
            <td class="Info" style="width: 100px; text-align: center">
                Last Name</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="reportTitleIncome" style="width: 180px">
                Father /Husband Name</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="reportTitleIncome" style="width: 180px">
                Folio No</td>
            <td class="Info" style="width: 100px">
                <asp:TextBox ID="txtFolioNo" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="reportTitleIncome" style="width: 180px">
                Residence Address</td>
            <td class="Info" colspan="3">
                <asp:TextBox ID="txtResidenceAddress" runat="server" Height="63px" MaxLength="500"
                    TextMode="MultiLine" Width="452px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9">
                &nbsp;Shares Details</td>
        </tr>
        <tr>
            <td colspan="9">
                <table>
                    <tr>
                        <td class="reportTitleIncome" style="text-align: center">
                            Type</td>
                        <td class="reportTitleIncome" style="text-align: center">
                            Date of Allotment</td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            Certificate No</td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            Dist No</td>
                        <td class="reportTitleIncome" style="width: 313px; text-align: center">
                            No of Shares</td>
                       
                    </tr>
                    <tr>
                        <td class="Info" style="width: 100px">
                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem>Equity</asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="Info" style="width: 100px">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 97px">
                                <tr>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtDateOfAllotment" runat="server" MaxLength="10" Width="65px"></asp:TextBox></td>
                                    <td style="width: 100px; height: 24px">
                                        &nbsp;<img id="Image1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfAllotment.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                            src="../../Images/SmallCalendar.png" /></td>
                                </tr>
                            </table>
                        </td>
                        <td class="Info" style="width: 100px">
                            <asp:TextBox ID="txtCertificateNo" runat="server"></asp:TextBox></td>
                        <td class="Info" style="width: 100px">
                            <asp:TextBox ID="txtDistNo" runat="server"></asp:TextBox></td>
                        <td class="Info" style="width: 313px">
                            <asp:TextBox ID="txtNoofShares" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            Rate per Share</td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            Amount</td>
                        <td class="reportTitleIncome" colspan="2" style="text-align: center">
                            Remarks</td>
                        <td class="reportTitleIncome" style="width: 313px; text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="Info" style="width: 100px">
                            <asp:TextBox ID="txtRatePreShare" runat="server"></asp:TextBox></td>
                        <td class="Info" style="width: 100px">
                            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
                        <td class="Info" colspan="2">
                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="200" TextMode="MultiLine" Width="297px"></asp:TextBox></td>
                        <td class="Info" style="width: 313px">
                            <table style="width: 92px">
                                <tr>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemAdd" runat="server" SkinID="btn" Text="Add" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemEdit" runat="server" SkinID="btn" Text="Edit" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemDel" runat="server" SkinID="btn" Text="Del" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 61px">
                            <table id="MainTab" cellpadding="2" cellspacing="1" style="width: 755px">
                                <tr>
                                    <th class="SubTable_Header" style="width: 23px; height: 24px">
                                        <input id="chkSelectAll_first" onclick="javascript:SelectAll('MainTab','chkSelectAll_first');"
                                            type="checkbox" /></th>
                                    <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                        Type</th>
                                    <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                        Date Of Allotment</th>
                                    <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                        Certificate No</th>
                                    <th class="SubTable_Header" style="height: 24px; text-align: center">
                                        Dist No</th>
                                    <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                        No of Share</th>
                                    <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                        Rate Per Share</th>
                                    <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                        Amount</th>
                                    <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                        Remarks</th>
                                    <th style="width: 80px; height: 24px; text-align: center">
                                    </th>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="9" class="tta" style="height: 30px">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="66px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="66px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 180px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 180px">
                <asp:HiddenField ID="hdnSharesDetails" runat="server" />
            </td>
            <td style="width: 100px"><asp:HiddenField ID="hdnShareDetailID" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

