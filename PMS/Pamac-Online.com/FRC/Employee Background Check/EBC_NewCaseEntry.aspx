<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true"
    CodeFile="~/FRC/Employee Background Check/EBC_NewCaseEntry.aspx.cs" Inherits="EBC_New_EBC_New_EBC_NewCaseEntry"
    Title="EBC New Case Entry" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script type="text/javascript" src="tabber.js"></script>

    <script language="javascript" type="text/javascript">
    /*
    MainTab_First
    */
    function Validate_Save()
    {
    
               // debugger;
                var txtRefNo=document.getElementById("<%=txtRefNo.ClientID%>");                                                 
                var txtFirstName=document.getElementById("<%=txtFirstName.ClientID%>");                                                 
                var txtMidName=document.getElementById("<%=txtMidName.ClientID%>");                                                 
                var txtLastName=document.getElementById("<%=txtLastName.ClientID%>");                                                 
                var txtFatherName=document.getElementById("<%=txtFatherName.ClientID%>");                                                 
                var txtCompName=document.getElementById("<%=txtCompName.ClientID%>");                                                 
                var txtCompName=document.getElementById("<%=txtCompName.ClientID%>");                                                 
                var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");                                                 
                
                var txtCredit_PANcard=document.getElementById("<%=txtCredit_PANcard.ClientID%>");                                                 
                var chkVeriType=document.getElementById("<%=chkVeriType.ClientID%>");                                                 
                var pnlRvVerification=document.getElementById("<%=pnlRvVerification.ClientID%>");                                                 
                var pnlEmployment=document.getElementById("<%=pnlEmployment.ClientID%>");                                                                  
                var tableBody = chkVeriType.childNodes[0];
                
                var CheckCount=0;    
                var ErrorMessage='';
                var ReturnValue=true;
                
                
                //debugger;
                
                for (var i=0;i<tableBody.childNodes.length; i++)
                {
                    var currentTd = tableBody.childNodes[i].childNodes[0];
                    var listControl = currentTd.childNodes[0];
                    
                    
                        if (listControl.checked==true)
                        {
                                if (currentTd.innerText=="Residence Address Verification")
                                 {
                                    var txtCurrAdd=document.getElementById("<%=txtCurrAdd.ClientID%>");                                                 
                                    var txtEarAdd=document.getElementById("<%=txtEarAdd.ClientID%>");                                                 
                                    var txtPermAdd=document.getElementById("<%=txtPermAdd.ClientID%>");                                                 
                   
                                        if ((txtCurrAdd.value=='')&&(txtEarAdd.value=='')&&(txtPermAdd.value==''))
                                        {
                                                    ErrorMessage="Please Enter atleast one Residence Verification Details!";                    
                                                    ReturnValue=false;
                                                    
                                        }
                                }
                                if (currentTd.innerText=="Education Background Check")
                                 {
                                        var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");                                                 
                                           
                                        if (hdnMainTab_First.value=="")
                                        {
                                            var ddlVerificationType=document.getElementById("<%=ddlVerificationType.ClientID%>");                                                 
                                            ErrorMessage="Please Enter atleast one Education Verification Details!";                    
                                            ReturnValue=false;
                                             
                                        }
                               
                                 }
                                 
                                 if (currentTd.innerText=="Employement Verification")
                                 {
                                        var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");                                                 
                                           
                                        if (hdnMainTab_Second.value=="")
                                        {
                                            var ddlEmployment=document.getElementById("<%=ddlEmployment.ClientID%>");                                                 
                                            ErrorMessage="Please Enter atleast one Employment Verification Details!";                    
                                            ReturnValue=false;
                                             
                                        }
                               
                                 }   
                                 
                                 if (currentTd.innerText=="Criminal Verification")
                                 {
                                        var txtCrim_CurrAdd=document.getElementById("<%=txtCrim_CurrAdd.ClientID%>");                                                 
                                        var txtCrim_EarAdd=document.getElementById("<%=txtCrim_EarAdd.ClientID%>");                                                 
                                        var txtCrim_PerAdd=document.getElementById("<%=txtCrim_PerAdd.ClientID%>");                                                 
      
                                        if ((txtCrim_CurrAdd.value=='')&&(txtCrim_EarAdd.value=='')&&(txtCrim_PerAdd.value==''))
                                        {                                             
                                            ErrorMessage="Please Enter atleast one Criminal Verification Details!";                    
                                            ReturnValue=false;
                                            
                                        }
                               
                                 }   
                                 if (currentTd.innerText=="CourtCheck Verification")
                                 {
                                        var txtCourt_CurrAdd=document.getElementById("<%=txtCourt_CurrAdd.ClientID%>");                                                 
                                        var txtCourt_EarAdd=document.getElementById("<%=txtCourt_EarAdd.ClientID%>");                                                 
                                        var txtCourt_PerAdd=document.getElementById("<%=txtCourt_PerAdd.ClientID%>");                                                 
      
                                        if ((txtCourt_CurrAdd.value=='')&&(txtCourt_EarAdd.value=='')&&(txtCourt_PerAdd.value==''))
                                        {                                             
                                            ErrorMessage="Please Enter atleast one Court Verification Details!";                    
                                            ReturnValue=false;
                                             
                                        }
                               
                                 }  
                                 
                                 if (currentTd.innerText=="CreditCheck Verification")
                                 {
                                        var txtCredit_CurrAdd=document.getElementById("<%=txtCredit_CurrAdd.ClientID%>");                                                 
                                        var txtCredit_PANcard=document.getElementById("<%=txtCredit_PANcard.ClientID%>");                                                 
                                        
                                        if (txtCredit_PANcard.value=='')
                                        {                                             
                                            ErrorMessage="Please Enter PAN Number!";                    
                                            ReturnValue=false;
                                             
                                        }
                                        if (txtCredit_CurrAdd.value=='')
                                        {
                                            ErrorMessage="Please Enter Credit Address!";                    
                                            ReturnValue=false;
                                                                                
                                        }
                                 }   
                                if (currentTd.innerText=="Reference Check")
                                 {
                                        var hdnMainTab_Third=document.getElementById("<%=hdnMainTab_Third.ClientID%>");                                                 
                                           
                                        if (hdnMainTab_Third.value=="")
                                        {
                                            var ddlRefType=document.getElementById("<%=ddlRefType.ClientID%>");                                                 
                                            ErrorMessage="Please Enter atleast one Reference Verification Details!";                    
                                            ReturnValue=false;
                                             
                                        }
                               
                                 }     
                                 if (currentTd.innerText=="KYC")
                                 {
                                        var hdnMainTab_Fourth=document.getElementById("<%=hdnMainTab_Fourth.ClientID%>");                                                 
                                           
                                        if (hdnMainTab_Fourth.value=="")
                                        {
                                            var ddlKYC=document.getElementById("<%=ddlKYC.ClientID%>");                                                 
                                            ErrorMessage="Please Enter atleast one KYC Verification Details!";                    
                                            ReturnValue=false;
                                             
                                        }
                               
                                 }     
                                 
                                    
                                 CheckCount=CheckCount+1;                                                        
                        }
                }    
                
               
              
                
                      
                
                if (CheckCount==0)
                {
                    ErrorMessage="Please Select atleast one verification type to continue !";                    
                    ReturnValue=false;
                    txtCompName.focus(); 
                
                }
                
                if (txtCredit_PANcard.value!='')
                {
                    var regex1=/^[A-Z]{5}\d{4}[A-Z]{1}$/;  //this is the pattern of regular expersion
                    if(regex1.test(txtCredit_PANcard.value)== false)
                    {
                        ErrorMessage="Please enter valid PAN number";
                        ReturnValue=false;
                             
                    }
                }
                if (txtCompName.value=='')
                {
                    ErrorMessage="Please enter Company Name to continue!";                    
                    ReturnValue=false;
                    txtCompName.focus();     
                }
                
                 
                if (txtFatherName.value=='')
                {
                    ErrorMessage="Please enter Fathers Name to continue!";                    
                    ReturnValue=false;
                    txtFatherName.focus();     
                }
                if (txtLastName.value=='')
                {
                    ErrorMessage="Please enter Last Name to continue!";                    
                    ReturnValue=false;
                    txtLastName.focus();     
                } 
                if (txtMidName.value=='')
                {
                    ErrorMessage="Please enter Middle Name to continue!";                    
                    ReturnValue=false;
                    txtMidName.focus();     
                }
                
                if (txtFirstName.value=='')
                {
                    ErrorMessage="Please enter First Name to continue!";                    
                    ReturnValue=false;
                    txtFirstName.focus();     
                }
                
                if (txtRefNo.value=='')
                {
                    ErrorMessage="Please enter Ref No/Client No to continue!";                    
                    ReturnValue=false;
                    txtRefNo.focus();     
                }
                
    
        lblMessage.innerText=ErrorMessage;
        window.scrollTo(0,0);      
        return ReturnValue;
    }    
    function Activate_Panels(chkVeriType1,Value,Index)
    {
     debugger;
     var chkVeriType=document.getElementById(chkVeriType1);                                                 
    
      
     var pnlRvVerification=document.getElementById("<%=pnlRvVerification.ClientID%>");                                                 
     var pnlEmployment=document.getElementById("<%=pnlEmployment.ClientID%>");                                                 
      var CheckValue=true;   
        var tableBody = chkVeriType.childNodes[0];
        //debugger;
        for (var i=0;i<tableBody.childNodes.length; i++)
        {
        var currentTd = tableBody.childNodes[i].childNodes[0];
        var listControl = currentTd.childNodes[0];

              
                   
                  
                  if ((Value=="Residence Address Verification")&&(Index==i) )
                  {      
                    
                    if (listControl.checked==true)
                    {
                    CheckValue=false;
                    }
                    else
                    {
                    CheckValue=true;
                    }        
                           
                     EnableDisableButtons(CheckValue,Value);
                  }
                  
                  
                  if ((Value=="Education Background Check")&&(Index==i)) 
                  {
                   if (listControl.checked==true)
                    {
                    CheckValue=false;
                    }
                    else
                    {
                    CheckValue=true;
                    }    
                    
                    pnlEmployment.disabled=listControl.checked;
                     EnableDisableButtons(CheckValue,Value);
                  }
             
        }
    }
    
    function EnableDisableButtons(Value,VerificationName)
    {
    
        var btnFamMemAdd=document.getElementById("<%=btnFamMemAdd.ClientID%>");                                                 
        var btnFamMemDel=document.getElementById("<%=btnFamMemDel.ClientID%>");                                                 
        var btnFamMemEdit=document.getElementById("<%=btnFamMemEdit.ClientID%>");                                                 

      
    
        if (VerificationName=='Education Background Check')
        {
            btnFamMemAdd.disabled=Value;
            btnFamMemDel.disabled=Value;
            btnFamMemEdit.disabled=Value;
                  
        }
    
    }
    
    function Validate_Search()
    {
       
       var txtRefNo=document.getElementById("<%=txtRefNo.ClientID%>");                                                 
       
       var ErrorMessage="";      
       var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");

       var ReturnValue=true;
       
        if (txtRefNo.value=="")
        {
            ErrorMessage="Please Enter Reference No To Continue!";
            ReturnValue=false;
            txtRefNo.focus();
            
        }
        
        window.scrollBy(0,0);
        lblMessage.innerText=ErrorMessage;
        return ReturnValue;
        
    
    }
    
    function Page_load_validation()
    {
        var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");                                                 
        var MainTab1=document.getElementById("MainTab_First");
            RenderTable(hdnMainTab_First.value,MainTab1.id,7);
            
        var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");                                                 
        var MainTab2=document.getElementById("MainTab_Second");
            RenderTable(hdnMainTab_Second.value,MainTab2.id,4);
            
        var hdnMainTab_Third=document.getElementById("<%=hdnMainTab_Third.ClientID%>");                                                 
        var MainTab2=document.getElementById("MainTab_Third");
            RenderTable(hdnMainTab_Third.value,MainTab2.id,5);
            
            
        var hdnMainTab_Fourth=document.getElementById("<%=hdnMainTab_Fourth.ClientID%>");                                                 
        var MainTab2=document.getElementById("MainTab_Fourth");
            RenderTable(hdnMainTab_Fourth.value,MainTab2.id,3);
            
        }
        
function MainTab_First_AddtoGrid()
    {
        if (Validate_MainTab_First())
        {
                var MainTab=document.getElementById("MainTab_First");                           
                var txtEdu_Institute=document.getElementById("<%=txtEdu_Institute.ClientID%>");
                var txtEdu_Qualification=document.getElementById("<%=txtEdu_Qualification.ClientID%>");
                var txtEdu_Address=document.getElementById("<%=txtEdu_Address.ClientID%>");
                var txtEdu_RegiNo=document.getElementById("<%=txtEdu_RegiNo.ClientID%>");
                var txtEdu_RollNo=document.getElementById("<%=txtEdu_RollNo.ClientID%>");
                var txtEdu_PassYear=document.getElementById("<%=txtEdu_PassYear.ClientID%>");
                var ddlVerificationType=document.getElementById("<%=ddlVerificationType.ClientID%>");
                var hdnEducationTypeId=document.getElementById("<%=hdnEducationTypeId.ClientID%>");
                    
                var Index=ddlVerificationType.selectedIndex;
       
                var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_First.value;
                strhdvValue = strhdvValue + ddlVerificationType.options[Index].innerText+"|" +txtEdu_Institute.value+"|"+txtEdu_Qualification.value +"|"+txtEdu_Address.value +"|"+ txtEdu_RegiNo.value+"|"+ txtEdu_RollNo.value+"|"+ txtEdu_PassYear.value+"|"+ddlVerificationType.value+"|"+hdnEducationTypeId.value+"^";
                RenderTable(strhdvValue,MainTab.id,7);
                hdnMainTab_First.value=strhdvValue;
                ClearGrid_MainTab_First();
        }  
        return false;
    }
      
function MainTab_Second_AddtoGrid()
    {
        if (Validate_MainTab_Second())
        {
                var MainTab=document.getElementById("MainTab_Second");                           
                var ddlEmployment=document.getElementById("<%=ddlEmployment.ClientID%>");
                var txtEmp_CompName=document.getElementById("<%=txtEmp_CompName.ClientID%>");
                var txtEmp_CompAdd=document.getElementById("<%=txtEmp_CompAdd.ClientID%>");
                var txtEmp_CompPh=document.getElementById("<%=txtEmp_CompPh.ClientID%>");
                var hdnEmplomentTypeId=document.getElementById("<%=hdnEmplomentTypeId.ClientID%>");
                    
                var Index=ddlEmployment.selectedIndex;
       
                var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_Second.value;
                strhdvValue = strhdvValue + ddlEmployment.options[Index].innerText+"|" +txtEmp_CompName.value+"|"+txtEmp_CompAdd.value +"|"+txtEmp_CompPh.value +"|"+ddlEmployment.value+"|"+hdnEmplomentTypeId.value+"^";
                RenderTable(strhdvValue,MainTab.id,4);
                hdnMainTab_Second.value=strhdvValue;
                ClearGrid_MainTab_Second();
        }  
        return false;
    }  
 
 function MainTab_Third_AddtoGrid()
    {
        if (Validate_MainTab_Third())
        {
                var MainTab=document.getElementById("MainTab_Third");                           
                var ddlRefType=document.getElementById("<%=ddlRefType.ClientID%>");
                var txtRefName=document.getElementById("<%=txtRefName.ClientID%>");
                var txtRefAdd=document.getElementById("<%=txtRefAdd.ClientID%>");
                var txtRefRel=document.getElementById("<%=txtRefRel.ClientID%>");
                var txtRefPH=document.getElementById("<%=txtRefPH.ClientID%>");
                var hdnRefTypeId=document.getElementById("<%=hdnRefTypeId.ClientID%>");
                    
                var Index=ddlRefType.selectedIndex;
       
                var hdnMainTab_Third=document.getElementById("<%=hdnMainTab_Third.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_Third.value;
                strhdvValue = strhdvValue + ddlRefType.options[Index].innerText+"|" +txtRefName.value+"|"+txtRefAdd.value +"|"+txtRefRel.value +"|"+txtRefPH.value +"|"+ddlRefType.value+"|"+hdnRefTypeId.value+"^";
                RenderTable(strhdvValue,MainTab.id,5);
                hdnMainTab_Third.value=strhdvValue;
                ClearGrid_MainTab_Third();
        }  
        return false;
    }  
    
     function MainTab_Fourth_AddtoGrid()
    {
    debugger;
        if (Validate_MainTab_Fourth())
        {
                var MainTab=document.getElementById("MainTab_Fourth");                           
                var ddlKYC=document.getElementById("<%=ddlKYC.ClientID%>");
                var txtKYCNO=document.getElementById("<%=txtKYCNO.ClientID%>");
                var txtKYCHolderName=document.getElementById("<%=txtKYCHolderName.ClientID%>");
               
                var hdnKYCID=document.getElementById("<%=hdnKYCID.ClientID%>");
                    
                var Index=ddlKYC.selectedIndex;
       
                var hdnMainTab_Fourth=document.getElementById("<%=hdnMainTab_Fourth.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_Fourth.value;
                strhdvValue = strhdvValue + ddlKYC.options[Index].innerText+"|" +txtKYCNO.value+"|"+txtKYCHolderName.value+"|"+ddlKYC.value+"|"+hdnKYCID.value+"^";
                RenderTable(strhdvValue,MainTab.id,3);
                hdnMainTab_Fourth.value=strhdvValue;
                ClearGrid_MainTab_Fourth();
        }  
        return false;
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

    
function ClearGrid_MainTab_First()
    {
            var txtEdu_Institute=document.getElementById("<%=txtEdu_Institute.ClientID%>");
                var txtEdu_Qualification=document.getElementById("<%=txtEdu_Qualification.ClientID%>");
                var txtEdu_Address=document.getElementById("<%=txtEdu_Address.ClientID%>");
                var txtEdu_RegiNo=document.getElementById("<%=txtEdu_RegiNo.ClientID%>");
                var txtEdu_RollNo=document.getElementById("<%=txtEdu_RollNo.ClientID%>");
                var txtEdu_PassYear=document.getElementById("<%=txtEdu_PassYear.ClientID%>");
                 var ddlVerificationType=document.getElementById("<%=ddlVerificationType.ClientID%>");
                 
                txtEdu_Institute.value="";
                txtEdu_Qualification.value="";
                txtEdu_Address.value="";
                txtEdu_RegiNo.value="";
                txtEdu_RollNo.value="";
                txtEdu_PassYear.value="";
                ddlVerificationType.selectedIndex = 0;
   }

function ClearGrid_MainTab_Second()
    {
                var ddlEmployment=document.getElementById("<%=ddlEmployment.ClientID%>");
                var txtEmp_CompName=document.getElementById("<%=txtEmp_CompName.ClientID%>");
                var txtEmp_CompAdd=document.getElementById("<%=txtEmp_CompAdd.ClientID%>");
                var txtEmp_CompPh=document.getElementById("<%=txtEmp_CompPh.ClientID%>");
                
                ddlEmployment.selectedIndex = 0;                 
                txtEmp_CompName.value="";
                txtEmp_CompAdd.value="";
                txtEmp_CompPh.value="";
     }

function ClearGrid_MainTab_Third()
    {
                var ddlRefType=document.getElementById("<%=ddlRefType.ClientID%>");
                var txtRefName=document.getElementById("<%=txtRefName.ClientID%>");
                var txtRefAdd=document.getElementById("<%=txtRefAdd.ClientID%>");
                var txtRefRel=document.getElementById("<%=txtRefRel.ClientID%>");
                var txtRefPH=document.getElementById("<%=txtRefPH.ClientID%>");
                
                ddlRefType.selectedIndex = 0;                 
                txtRefName.value="";
                txtRefAdd.value="";
                txtRefRel.value="";
                txtRefPH.value="";
     }
    
    function ClearGrid_MainTab_Fourth()
    {
                var ddlKYC=document.getElementById("<%=ddlKYC.ClientID%>");
                var txtKYCNO=document.getElementById("<%=txtKYCNO.ClientID%>");
                var txtKYCHolderName=document.getElementById("<%=txtKYCHolderName.ClientID%>");
                               
                ddlKYC.selectedIndex = 0;                 
                txtKYCNO.value="";
                txtKYCHolderName.value="";
               
     }
    
    
function Validate_MainTab_First()
    {
        var MainTab=document.getElementById("MainTab_First");                     
        var txtEdu_Institute=document.getElementById("<%=txtEdu_Institute.ClientID%>");
        var txtEdu_Qualification=document.getElementById("<%=txtEdu_Qualification.ClientID%>");
        var txtEdu_Address=document.getElementById("<%=txtEdu_Address.ClientID%>");
        var txtEdu_RegiNo=document.getElementById("<%=txtEdu_RegiNo.ClientID%>");
        var txtEdu_RollNo=document.getElementById("<%=txtEdu_RollNo.ClientID%>");
        var txtEdu_PassYear=document.getElementById("<%=txtEdu_PassYear.ClientID%>");
        var ddlVerificationType=document.getElementById("<%=ddlVerificationType.ClientID%>");
       
          
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
      var ReturnValue=true;
       
       if (txtEdu_Qualification.value=="")
      {
        ErrorMessage="Please Enter Qualification Gained!";
        ReturnValue=false;
        txtEdu_Qualification.focus();
      }
      if (txtEdu_Address.value=="")
      {
        ErrorMessage="Please Enter Education Address!";
        ReturnValue=false;
        txtEdu_Address.focus();
      }
       if (txtEdu_RegiNo.value=="")
      {
        ErrorMessage="Please Enter Registration No!";
        ReturnValue=false;
        txtEdu_RegiNo.focus();
      }           
   
       if (txtEdu_RollNo.value=="")
      {
        ErrorMessage="Please Enter RollNo!";
        ReturnValue=false;
        txtEdu_RollNo.focus();
      }
       if (txtEdu_PassYear.value=="")
      {
        ErrorMessage="Please Enter Passing Year!";
        ReturnValue=false;
        txtEdu_PassYear.focus();
      }
       if (txtEdu_Institute.value=="")
      {
        ErrorMessage="Please Enter Institute Name!";
        ReturnValue=false;
        txtEdu_Institute.focus();
      }
      
      if (ddlVerificationType.selectedIndex==0)
      {
        ErrorMessage="Please select Valid Education Type!";
        ReturnValue=false;
        ddlVerificationType.focus();
      }
      else
      {
        var Index=ddlVerificationType.selectedIndex;
        var Value=ddlVerificationType.options[Index].innerText;
        var i=0;
        for(i=0;i<=MainTab.rows.length-1;i++)
           { 
            if (MainTab.rows[i].cells[1].innerText==Value)
             {
              ErrorMessage='Entry already Added!';
              ddlVerificationType.focus();    
              ReturnValue=false;
             }
         }
      }         
      
      lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
     return ReturnValue;      
    }

function Validate_MainTab_Second()
    {
        var MainTab=document.getElementById("MainTab_Second");                     
        var ddlEmployment=document.getElementById("<%=ddlEmployment.ClientID%>");
        var txtEmp_CompName=document.getElementById("<%=txtEmp_CompName.ClientID%>");
        var txtEmp_CompAdd=document.getElementById("<%=txtEmp_CompAdd.ClientID%>");
        var txtEmp_CompPh=document.getElementById("<%=txtEmp_CompPh.ClientID%>");
                  
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
      var ReturnValue=true;
       
       if (txtEmp_CompPh.value=="")
      {
        ErrorMessage="Please Enter Contact No!";
        ReturnValue=false;
        txtEmp_CompPh.focus();
      }
       if (txtEmp_CompAdd.value=="")
      {
        ErrorMessage="Please Enter Company Address!";
        ReturnValue=false;
        txtEmp_CompAdd.focus();
      }
       if (txtEmp_CompName.value=="")
      {
        ErrorMessage="Please Enter Company Name!";
        ReturnValue=false;
        txtEmp_CompName.focus();
      }
      
      if (ddlEmployment.selectedIndex==0)
      {
        ErrorMessage="Please select Valid Employment Type!";
        ReturnValue=false;
        ddlEmployment.focus();
      }   
      else
      {
        var Index=ddlEmployment.selectedIndex;
        var Value=ddlEmployment.options[Index].innerText;
        var i=0;
        for(i=0;i<=MainTab.rows.length-1;i++)
           { 
            if (MainTab.rows[i].cells[1].innerText==Value)
             {
              ErrorMessage='Entry already Added!';
              ddlEmployment.focus();    
              ReturnValue=false;
             }
         }
      }   
      
      lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
     return ReturnValue;      
    }

function Validate_MainTab_Third()
    {
        var MainTab=document.getElementById("MainTab_Third");                     
        var ddlRefType=document.getElementById("<%=ddlRefType.ClientID%>");
        var txtRefName=document.getElementById("<%=txtRefName.ClientID%>");
        var txtRefAdd=document.getElementById("<%=txtRefAdd.ClientID%>");
        var txtRefRel=document.getElementById("<%=txtRefRel.ClientID%>");
        var txtRefPH=document.getElementById("<%=txtRefPH.ClientID%>");
                  
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
      var ReturnValue=true;
       
        if (txtRefPH.value=="")
      {
        ErrorMessage="Please Enter Referencee Phone!";
        ReturnValue=false;
        txtRefPH.focus();
      }
       if (txtRefRel.value=="")
      {
        ErrorMessage="Please Enter Referencee Relation!";
        ReturnValue=false;
        txtRefRel.focus();
      }
       if (txtRefAdd.value=="")
      {
        ErrorMessage="Please Enter Referencee Address!";
        ReturnValue=false;
        txtRefAdd.focus();
      }
       if (txtRefName.value=="")
      {
        ErrorMessage="Please Enter Referencee Name!";
        ReturnValue=false;
        txtRefName.focus();
      }
      
      if (ddlRefType.selectedIndex==0)
      {
        ErrorMessage="Please select Valid Reference Type!";
        ReturnValue=false;
        ddlRefType.focus();
      }   
      else
      {
        var Index=ddlRefType.selectedIndex;
        var Value=ddlRefType.options[Index].innerText;
        var i=0;
        for(i=0;i<=MainTab.rows.length-1;i++)
           { 
            if (MainTab.rows[i].cells[1].innerText==Value)
             {
              ErrorMessage='Entry already Added!';
              ddlRefType.focus();    
              ReturnValue=false;
             }
         }
      }   
      
      lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
     return ReturnValue;      
    }
    
    
function Validate_MainTab_Fourth()
    {
    debugger;
        var MainTab=document.getElementById("MainTab_Fourth");                     
        var ddlKYC=document.getElementById("<%=ddlKYC.ClientID%>");
        var txtKYCNO=document.getElementById("<%=txtKYCNO.ClientID%>");
        var txtKYCHolderName=document.getElementById("<%=txtKYCHolderName.ClientID%>");
       
                  
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
      var ReturnValue=true;
       
       if (txtKYCNO.value=="")
      {
        ErrorMessage="Please Enter KYC Number!";
        ReturnValue=false;
        txtKYCNO.focus();
      }
       if (txtKYCHolderName.value=="")
      {
        ErrorMessage="Please Enter Holder Name!";
        ReturnValue=false;
        txtKYCHolderName.focus();
      }
      
      if (ddlKYC.selectedIndex==0)
      {
        ErrorMessage="Please select Valid KYC Type!";
        ReturnValue=false;
        ddlKYC.focus();
      }   
      else
      {
        var Index=ddlKYC.selectedIndex;
        var Value=ddlKYC.options[Index].innerText;
        var i=0;
        for(i=0;i<=MainTab.rows.length-1;i++)
           { 
            if (MainTab.rows[i].cells[1].innerText==Value)
             {
              ErrorMessage='Entry already Added!';
              ddlKYC.focus();    
              ReturnValue=false;
             }
         }
      }   
      
      lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
     return ReturnValue;      
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
                                if (MainTab.id=="MainTab_First")
                                {
                                    var ddlVerificationType=document.getElementById("<%=ddlVerificationType.ClientID%>");
                                    var txtEdu_Institute=document.getElementById("<%=txtEdu_Institute.ClientID%>");
                                    var txtEdu_Qualification=document.getElementById("<%=txtEdu_Qualification.ClientID%>");
                                    var txtEdu_Address=document.getElementById("<%=txtEdu_Address.ClientID%>");
                                    var txtEdu_RegiNo=document.getElementById("<%=txtEdu_RegiNo.ClientID%>");
                                    var txtEdu_RollNo=document.getElementById("<%=txtEdu_RollNo.ClientID%>");
                                    var txtEdu_PassYear=document.getElementById("<%=txtEdu_PassYear.ClientID%>");               
                                 
                                    ddlVerificationType.value=row.cells[8].innerText;
                                    txtEdu_Institute.value=row.cells[2].innerText;
                                    txtEdu_Qualification.value=row.cells[3].innerText;
                                    txtEdu_Address.value=row.cells[4].innerText;
                                    txtEdu_RegiNo.value=row.cells[5].innerText;
                                    txtEdu_RollNo.value=row.cells[6].innerText;
                                    txtEdu_PassYear.value=row.cells[7].innerText;
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,7);
                                 }   
                                  if (MainTab.id=="MainTab_Second")
                                {                             
                                     
                                    var ddlEmployment=document.getElementById("<%=ddlEmployment.ClientID%>");
                                    var txtEmp_CompName=document.getElementById("<%=txtEmp_CompName.ClientID%>");
                                    var txtEmp_CompAdd=document.getElementById("<%=txtEmp_CompAdd.ClientID%>");
                                    var txtEmp_CompPh=document.getElementById("<%=txtEmp_CompPh.ClientID%>");
                                    
                                    ddlEmployment.value=row.cells[5].innerText;
                                    txtEmp_CompName.value=row.cells[2].innerText;
                                    txtEmp_CompAdd.value=row.cells[3].innerText;
                                    txtEmp_CompPh.value=row.cells[4].innerText;
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,5);
                                 }      
                                   if (MainTab.id=="MainTab_Third")
                                {
                                
                                     
                                    var ddlRefType=document.getElementById("<%=ddlRefType.ClientID%>");
                                    var txtRefName=document.getElementById("<%=txtRefName.ClientID%>");
                                    var txtRefAdd=document.getElementById("<%=txtRefAdd.ClientID%>");
                                    var txtRefRel=document.getElementById("<%=txtRefRel.ClientID%>");
                                    var txtRefPH=document.getElementById("<%=txtRefPH.ClientID%>");
                                    
                                    ddlRefType.value=row.cells[6].innerText;
                                    txtRefName.value=row.cells[2].innerText;
                                    txtRefAdd.value=row.cells[3].innerText;
                                    txtRefRel.value=row.cells[4].innerText;
                                    txtRefPH.value=row.cells[5].innerText;
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,6);
                                 }  
                                 
                                if (MainTab.id=="MainTab_Fourth")
                                {
                                
                                     
                                    var ddlKYC=document.getElementById("<%=ddlKYC.ClientID%>");
                                    var txtKYCNO=document.getElementById("<%=txtKYCNO.ClientID%>");
                                    var txtKYCHolderName=document.getElementById("<%=txtKYCHolderName.ClientID%>");
                                                                     
                                    ddlKYC.value=row.cells[4].innerText;
                                    txtKYCNO.value=row.cells[2].innerText;
                                    txtKYCHolderName.value=row.cells[3].innerText;
                                  
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,4);
                                 }                                   
                            }
                        }                         
                }    
                return false;
    }
    
  
 

    </script>

    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 25px" colspan="7" class="topbar">
                &nbsp;EBC New Case Entry
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
            <td colspan="6" rowspan="4" style="width: 893px">
                <table style="width: 904px; height: 130px" class="bx">
                    <tr>
                        <td colspan="3" style="width: 169px;" class="reportTitleIncome">
                            <span style="font-size: 8pt; font-family: Arial">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                                    Text="Client Ref Name / No." Width="126px"></asp:Label></span></td>
                        <td colspan="3" class="Info">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 213px">
                                <tr>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox></td>
                                    <td style="width: 100px">
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" Height="24px" OnClick="btnSearch_Click"
                                            SkinID="btnSearchSkin" Text="Search" Width="70px" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 100px;">
                            <asp:HiddenField ID="hdnCaseId" runat="server" />
                        </td>
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 100px;">
                        </td>
                        <td style="width: 100px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 24px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">
                                <asp:Label ID="Label1" runat="server" Text="Name of Employee" Width="122px"></asp:Label></span></strong></td>
                        <td style="width: 100px; height: 24px" class="Info">
                            <asp:TextBox ID="txtFirstName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                        <td style="width: 99px; height: 24px" class="Info">
                            <asp:TextBox ID="txtMidName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                        <td style="width: 100px; height: 24px" class="Info">
                            <asp:TextBox ID="txtLastName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 22px" class="reportTitleIncome">
                            <strong><span></span></strong>
                        </td>
                        <td style="width: 100px; height: 22px; text-align: center;" class="Info">
                            <strong><span style="font-size: 8pt; font-family: Arial">First Name</span></strong></td>
                        <td style="width: 99px; height: 22px; text-align: center;" class="Info">
                            <strong><span style="font-size: 8pt; font-family: Arial">Middle Name</span></strong></td>
                        <td style="width: 100px; height: 22px; text-align: center;" class="Info">
                            <strong><span style="font-size: 8pt; font-family: Arial">Last Name</span></strong></td>
                        <td style="width: 100px; height: 22px;">
                        </td>
                        <td style="width: 100px; height: 22px;">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 22px" class="reportTitleIncome">
                            <strong><span>Father Name</span></strong></td>
                        <td class="Info" colspan="4" style="height: 22px">
                            <asp:TextBox ID="txtFatherName" runat="server" SkinID="txtSkin" Width="165px"></asp:TextBox></td>
                        <td style="width: 100px; height: 22px">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 22px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">Company Name</span></strong></td>
                        <td class="Info" colspan="4" style="height: 22px">
                            <asp:TextBox ID="txtCompName" runat="server" SkinID="txtSkin" Width="165px"></asp:TextBox></td>
                        <td style="width: 100px; height: 22px">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                        <td style="width: 100px; height: 22px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="reportTitleIncome" style="height: 43px">
                            <strong><span style="font-size: 8pt; font-family: Arial">Date of Birth</span></strong></td>
                        <td colspan="4" class="Info" style="height: 43px">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 124px">
                                <tr>
                                    <td>
                            <asp:TextBox ID="txtdob" runat="server" SkinID="txtSkin" Width="65px" MaxLength="10"></asp:TextBox></td>
                                    <td style="width: 100px">
                                        &nbsp;<img id="Image1" alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtdob.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                </tr>
                            </table>
                        </td>
                        <%--<asp:Image ID="Image1" runat="server" alt="Calendar" ImageUrl="~/Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtdob.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>--%>
                        <td style="width: 100px; height: 43px;">
                        </td>
                        <td style="width: 100px; height: 43px;">
                        </td>
                        <td style="width: 100px; height: 43px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 20px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">Received Date</span></strong></td>
                        <td class="Info" colspan="4" style="height: 20px">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 127px">
                                <tr>
                                    <td style="width: 48px">
                            <asp:TextBox ID="txtRcvdDate" runat="server" SkinID="txtSkin" Width="63px" MaxLength="10"></asp:TextBox></td>
                                    <td style="width: 100px">
                                        &nbsp;<img id="Img1" alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtRcvdDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                        <td style="width: 100px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 24px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">Address</span></strong></td>
                        <td colspan="4" style="height: 24px" class="Info">
                            <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                Width="494px" MaxLength="200"></asp:TextBox></td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 24px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">Contact Number</span></strong></td>
                        <td class="Info" colspan="4" style="height: 24px">
                            <asp:TextBox ID="txtPhone" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                        <td style="width: 100px; height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 24px" class="reportTitleIncome">
                            <strong><span style="font-size: 8pt; font-family: Arial">Verification Type</span></strong></td>
                        <td colspan="7" style="height: 24px" class="Info">
                            <asp:CheckBoxList ID="chkVeriType" runat="server" RepeatDirection="Horizontal" SkinID="chkListSkin"
                                RepeatColumns="1" OnSelectedIndexChanged="chkVeriType_SelectedIndexChanged" AutoPostBack="True">
                            </asp:CheckBoxList></td>
                    </tr>
                </table>             
             
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 3px;">
            </td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td colspan="6" style="width: 893px" >
                <div class="tabber">
                    <asp:Panel ID="pnlRvVerification" runat="server" CssClass="tabbertab">
                        <h2>
                            Residence Address</h2>
                        <table id="TABLE1" style="width: 789px">
                            <tr>
                                <td class="tta" colspan="10" style="height: 16px">
                                    &nbsp;Residence Address Verification Details</td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 11px; height: 35px">
                                    &nbsp;
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 35px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Current Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 704px; height: 35px">
                                    <asp:TextBox ID="txtCurrAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px" MaxLength="200"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px; height: 36px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 36px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Earlier Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 704px; height: 36px">
                                    <asp:TextBox ID="txtEarAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px" MaxLength="200"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px; height: 44px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 44px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Permanent Address</span></strong></td>
                                <td class="Info" colspan="7">
                                    <asp:TextBox ID="txtPermAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px" MaxLength="200"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnl_EBC" runat="server" CssClass="tabbertab">
                        <h2>
                            Education Check</h2>
                        <table cellspacing="1" class="bx" style="width: 265px">
                            <tr>
                                <td class="tta" colspan="5" style="height: 16px">
                                    Enter Education Qulification / Certification Details</td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="width: 232px; height: 16px; text-align: center">
                                    Verification Type</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Institute / College / University Name</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    <strong>&nbsp;</strong>Qualification Gained</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Address</td>
                            </tr>
                            <tr>
                                <td class="Info" style="width: 232px">
                                    <asp:DropDownList ID="ddlVerificationType" runat="server" SkinID="ddlSkin" Width="125px">
                                    </asp:DropDownList></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEdu_Institute" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEdu_Qualification" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEdu_Address" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="width: 232px; text-align: center">
                                    Registration No</td>
                                <td class="reportTitleIncome" style="width: 100px; text-align: center">
                                    Roll Number</td>
                                <td class="reportTitleIncome" style="width: 100px">
                                    Passing Year</td>
                                <td class="Info" rowspan="2" style="width: 100px; text-align: center">
                                    <table>
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
                                <td class="Info" style="width: 232px; height: 22px">
                                    <asp:TextBox ID="txtEdu_RegiNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px; height: 22px">
                                    <asp:TextBox ID="txtEdu_RollNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px; height: 22px">
                                    <asp:TextBox ID="txtEdu_PassYear" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="5" style="height: 15px">
                                    <div id="dv1" style="overflow: scroll; width: 776px; height: 116px">
                                        <table id="MainTab_First" cellpadding="2" cellspacing="1" style="width: 755px">
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 24px">
                                                    <input id="chkSelectAll_first" onclick="javascript:SelectAll('MainTab_First','chkSelectAll_first');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Verification</th>
                                                <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Institute</th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                    Qualification</th>
                                                <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                                    Address</th>
                                                <th class="SubTable_Header" style="width: 175px; height: 24px; text-align: center">
                                                    Registration No</th>
                                                <th class="SubTable_Header" style="width: 175px; height: 24px; text-align: center">
                                                    Roll No</th>
                                                <th class="SubTable_Header" style="width: 175px; height: 24px; text-align: center">
                                                    Pass Year</th>
                                                <th style="height: 24px">
                                                </th>
                                                <th style="width: 3px; height: 24px">
                                                </th>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdnMainTab_First" runat="server" />
                                    <asp:HiddenField ID="hdnEducationTypeId" runat="server" Value="44" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlEmployment" runat="server" CssClass="tabbertab">
                        <h2>
                            Employment Check</h2>
                        <table cellspacing="1" class="bx" style="width: 311px">
                            <tr>
                                <td class="tta" colspan="6" style="height: 16px">
                                    Enter Employment Details</td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="height: 16px; text-align: center">
                                    Verification Type</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Company Name</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    <strong>&nbsp;</strong>Company Address</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Contact No.</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td class="Info">
                                    <asp:DropDownList ID="ddlEmployment" runat="server" SkinID="ddlSkin" Width="125px">
                                    </asp:DropDownList></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEmp_CompName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEmp_CompAdd" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtEmp_CompPh" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <table>
                                        <tr>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Add" runat="server" SkinID="btn" Text="Add" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Edit" runat="server" SkinID="btn" Text="Edit" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnEmp_Del" runat="server" SkinID="btn" Text="Del" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="height: 14px">
                                    <div id="Div1" style="overflow: scroll; width: 776px; height: 116px">
                                        <table id="MainTab_Second" cellpadding="2" cellspacing="1" style="width: 755px">
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 24px">
                                                    <input id="chkSelectAll_Second" onclick="javascript:SelectAll('MainTab_Second','chkSelectAll_Second');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Verification</th>
                                                <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                                    Company Name</th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                    Company Address</th>
                                                <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                                    Contact No.</th>
                                                <th style="width: 15px; height: 24px">
                                                </th>
                                                <th style="width: 3px; height: 24px">
                                                </th>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdnMainTab_Second" runat="server" />
                                    <asp:HiddenField ID="hdnEmplomentTypeId" runat="server" Value="45" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlCriminal" runat="server" CssClass="tabbertab">
                        <h2>
                            Criminal</h2>
                        <table id="TABLE2" style="width: 785px">
                            <tr>
                                <td class="tta" colspan="10" style="height: 14px">
                                    &nbsp;Criminal Background Verification Check Details</td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 11px; height: 35px">
                                    &nbsp;&nbsp;
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 35px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Current Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 35px">
                                    <asp:TextBox ID="txtCrim_CurrAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px; height: 36px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 36px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Earlier Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 36px">
                                    <asp:TextBox ID="txtCrim_EarAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px">
                                </td>
                                <td class="reportTitleIncome" colspan="2">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Permanent Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px">
                                    <asp:TextBox ID="txtCrim_PerAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlCourtLitigation" runat="server" CssClass="tabbertab">
                        <h2>
                            Court Litigation</h2>
                        <table style="width: 781px">
                            <tr>
                                <td class="tta" colspan="10" style="height: 11px">
                                    &nbsp; Court Litigation Verification Check Details</td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 11px; height: 35px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 35px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Current Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 35px">
                                    <asp:TextBox ID="txtCourt_CurrAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px; height: 36px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 36px">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Earlier Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 36px">
                                    <asp:TextBox ID="txtCourt_EarAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px">
                                </td>
                                <td class="reportTitleIncome" colspan="2">
                                    <strong><span style="font-size: 8pt; font-family: Arial">Permanent Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px">
                                    <asp:TextBox ID="txtCourt_PerAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlCreditCheck" runat="server" CssClass="tabbertab">
                        <h2>
                            Credit Check</h2>
                        <table style="width: 777px">
                            <tr>
                                <td class="tta" colspan="10" style="height: 15px">
                                    &nbsp; Credit Check Verifcation Details</td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 11px; height: 35px">
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 35px">
                                    <strong><span>Current Address</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 35px">
                                    <asp:TextBox ID="txtCredit_CurrAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                        Width="494px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 15px; height: 36px">
                                    &nbsp;
                                </td>
                                <td class="reportTitleIncome" colspan="2" style="height: 36px">
                                    <strong><span>PAN Card No.</span></strong></td>
                                <td class="Info" colspan="7" style="width: 677px; height: 36px">
                                    <asp:TextBox ID="txtCredit_PANcard" runat="server" SkinID="txtSkin"
                                        Width="88px" MaxLength="10"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlReferenceCheck" runat="server" CssClass="tabbertab">
                        <h2>
                            Reference Check</h2>
                        <table cellspacing="1">
                            <tr>
                                <td class="tta" colspan="7" style="height: 16px">
                                    Enter Referencee Details</td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="width: 18px; height: 16px; text-align: center">
                                    Reference Type</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Ref Name</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    <strong>&nbsp;</strong>Ref Address</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Ref Relation</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Ref Phone</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td class="Info" style="width: 18px">
                                    <asp:DropDownList ID="ddlRefType" runat="server" SkinID="ddlSkin" Width="125px">
                                    </asp:DropDownList></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtRefName" runat="server" SkinID="txtSkin" Width="106px"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtRefAdd" runat="server" SkinID="txtSkin" Width="108px"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtRefRel" runat="server" SkinID="txtSkin" Width="111px"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtRefPH" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <table>
                                        <tr>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnRefAdd" runat="server" SkinID="btn" Text="Add" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnRefEdit" runat="server" SkinID="btn" Text="Edit" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnRefDel" runat="server" SkinID="btn" Text="Del" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <div id="Div2" style="overflow: scroll; width: 776px; height: 116px">
                                        <table id="MainTab_Third" cellpadding="2" cellspacing="1" style="width: 828px">
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 14px">
                                                    <input id="chkSelectAll_Third" onclick="javascript:SelectAll('MainTab_Third','chkSelectAll_Third');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="width: 71px; height: 14px; text-align: center">
                                                    Ref Type</th>
                                                <th class="SubTable_Header" style="width: 73px; height: 14px; text-align: center">
                                                    Ref Name</th>
                                                <th class="SubTable_Header" style="width: 106px; height: 14px; text-align: center">
                                                    Ref Address</th>
                                                <th class="SubTable_Header" style="width: 80px; height: 14px; text-align: center">
                                                    Ref Relation</th>
                                                <th class="SubTable_Header" style="width: 80px; height: 14px; text-align: center">
                                                    Ref Phone</th>
                                                <th style="width: 15px; height: 14px">
                                                </th>
                                                <th style="width: 3px; height: 14px">
                                                </th>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdnMainTab_Third" runat="server" />
                                    <asp:HiddenField ID="hdnRefTypeId" runat="server" Value="49" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlKYC" runat="server" CssClass="tabbertab">
                        <h2>
                            KYC</h2>
                        <table cellspacing="1">
                            <tr>
                                <td class="tta" colspan="7" style="height: 16px; width: 772px;">
                                    Enter Customer Verification Details</td>
                            </tr>
                            <tr>
                                <td class="reportTitleIncome" style="width: 18px; height: 16px; text-align: center">
                                    Reference Type</td>
                                <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    Number</td>
                                <td class="reportTitleIncome" style="width: 95px; height: 16px; text-align: center">
                                    <strong>&nbsp;</strong>Holder Name</td>
                                     <td class="reportTitleIncome" style="width: 100px; height: 16px; text-align: center">
                                    </td>
                              </tr>
                            <tr>
                                <td class="Info" style="width: 18px">
                                    <asp:DropDownList ID="ddlKYC" runat="server" SkinID="ddlSkin" Width="148px">
                                    </asp:DropDownList></td>
                                <td class="Info" style="width: 100px">
                                    <asp:TextBox ID="txtKYCNO" runat="server" SkinID="txtSkin" Width="106px"></asp:TextBox></td>
                                <td class="Info" style="width: 95px">
                                    <asp:TextBox ID="txtKYCHolderName" runat="server" SkinID="txtSkin" Width="170px"></asp:TextBox></td>
                                <td class="Info" style="width: 100px">
                                    <table>
                                        <tr>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnAddKYC" runat="server" SkinID="btn" Text="Add" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnKYCEdit" runat="server" SkinID="btn" Text="Edit" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnKYCDel" runat="server" SkinID="btn" Text="Del" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7" style="width: 772px">
                                    <div id="Div3" style="overflow: scroll; width: 776px; height: 116px">
                                        <table id="MainTab_Fourth" cellpadding="2" cellspacing="1" style="width: 828px">
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 14px">
                                                    <input id="chkSelectAll_Fourth" onclick="javascript:SelectAll('MainTab_Fourth','chkSelectAll_Fourth');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="width: 71px; height: 14px; text-align: center">
                                                    Veri Type</th>
                                                <th class="SubTable_Header" style="width: 71px; height: 14px; text-align: center">
                                                    Number</th>
                                                <th class="SubTable_Header" style="width: 73px; height: 14px; text-align: center">
                                                    HolderName</th>
                                                <th style="width: 15px; height: 14px">
                                                </th>
                                                 <th style="width: 15px; height: 14px">
                                                </th>
                                                <th style="width: 15px; height: 14px">
                                                </th>
                                                <th style="width: 3px; height: 14px">
                                                </th>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:HiddenField ID="hdnMainTab_Fourth" runat="server" />
                                    <asp:HiddenField ID="hdnKYCID" runat="server" Value="56" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 32px" class="tta" colspan="7">
                &nbsp;<asp:Button ID="btnSave" runat="server" Height="25px" SkinID="btnSaveSkin"
                    Text="Save" Width="97px" OnClick="btnSave_Click" />
                <asp:Button ID="btnCan" runat="server" Height="25px" SkinID="btnCancelSkin" Text="Cancel"
                    Width="97px" OnClick="btnCan_Click" /></td>
        </tr>
        <tr>
            <td style="width: 3px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
