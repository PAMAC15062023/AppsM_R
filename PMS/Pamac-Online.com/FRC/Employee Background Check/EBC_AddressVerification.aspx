<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_AddressVerification.aspx.cs" Inherits="EBC_New_EBC_New_EBC_AddressVerification" Title="Employee Address Verification" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="tabber.js" >
</script>

<script language="javascript" type="text/javascript">

 function openwindow(imgType)
        {        
            
           var hdnCaseID=document.getElementById("<%=hdnCaseID.ClientID%>");
           var hdnMainVerifyID=document.getElementById("<%=hdnMainVerifyID.ClientID%>");
           var hdnSubVerifyTypeID=document.getElementById("<%=ddlSubVeriType.ClientID%>"); 
          
            window.open('EBC_RenderImage.aspx?CaseId='+hdnCaseID.value +'&Veri='+hdnMainVerifyID.value+'&SubVeri='+hdnSubVerifyTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
    /*
    MainTab_First
    */
    function Page_load_validation()
    {
        var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");                                                 
        var MainTab1=document.getElementById("MainTab_First");
        RenderTable(hdnMainTab_First.value,MainTab1.id,4);
        
        var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");                                                 
        var MainTab2=document.getElementById("MainTab_Second");
        RenderTable(hdnMainTab_Second.value,MainTab2.id,7);
        
        var hdnMainTab_Third=document.getElementById("<%=hdnMainTab_Third.ClientID%>");                                                 
        var MainTab3=document.getElementById("MainTab_Third");
        RenderTable(hdnMainTab_Third.value,MainTab3.id,5);
        
        var hdnMainTab_Fourth=document.getElementById("<%=hdnMainTab_Fourth.ClientID%>");                                                 
        var MainTab4=document.getElementById("MainTab_Fourth");
        RenderTable(hdnMainTab_Fourth.value,MainTab4.id,3);  
    }
    function MainTab_Fouth_AddtoGrid()
    {  
        if (Validate_MainTab_Fourth())
        {
             var MainTab=document.getElementById("MainTab_Fourth");                           
             var txtOthPropTypeAssets=document.getElementById("<%=txtOthPropTypeAssets.ClientID%>");
             var txtOthPropDescrip=document.getElementById("<%=txtOthPropDescrip.ClientID%>");
             var txtOthPropMarkValue=document.getElementById("<%=txtOthPropMarkValue.ClientID%>");
             var hdnMainTab_Fourth=document.getElementById("<%=hdnMainTab_Fourth.ClientID%>");
              
            var strhdvValue="";            
            strhdvValue=hdnMainTab_Fourth.value;
            strhdvValue = strhdvValue + txtOthPropTypeAssets.value+"|"+txtOthPropDescrip.value +"|"+txtOthPropMarkValue.value +"|1|4^";
            RenderTable(strhdvValue,MainTab.id,3);
            hdnMainTab_Fourth.value=strhdvValue;
            ClearGrid_MainTab_Fourth();
        }
              return false;
    }
    function ClearGrid_MainTab_Fourth()
    {
             var txtOthPropTypeAssets=document.getElementById("<%=txtOthPropTypeAssets.ClientID%>");
             var txtOthPropDescrip=document.getElementById("<%=txtOthPropDescrip.ClientID%>");
             var txtOthPropMarkValue=document.getElementById("<%=txtOthPropMarkValue.ClientID%>");
                
             txtOthPropTypeAssets.value="";
             txtOthPropDescrip.value="";
             txtOthPropMarkValue.value="";
             
    }    
    function Validate_MainTab_Fourth()
    {
    
           
            var txtOthPropTypeAssets=document.getElementById("<%=txtOthPropTypeAssets.ClientID%>");
            var txtOthPropDescrip=document.getElementById("<%=txtOthPropDescrip.ClientID%>");
            var txtOthPropMarkValue=document.getElementById("<%=txtOthPropMarkValue.ClientID%>");
            
            var ErrorMessage="";      
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
     
            var ReturnValue=true;     
        
           if (txtOthPropTypeAssets.value=="")
              {
                ErrorMessage="Please Enter Other Value Details!";
                ReturnValue=false;
                txtOthPropTypeAssets.focus();
              }
            if (txtOthPropDescrip.value=="")
              {
                ErrorMessage="Please Enter Other Description Details!";
                ReturnValue=false;
                txtOthPropDescrip.focus();
              }
             if (txtOthPropMarkValue.value=="")
              {
                ErrorMessage="Please Enter Other Property Market value!";
                ReturnValue=false;
                txtOthPropMarkValue.focus();
              }
              
        
        if (ErrorMessage!="")
        {
            window.scroll(0,0);
            lblMessage.innerText=ErrorMessage;
        }
        
        return ReturnValue;        
    }   
                
    function MainTab_Third_AddtoGrid()
    {
        if (Validate_MainTab_Third())
        {
             
                var MainTab=document.getElementById("MainTab_Third");                           
                var txtHousingVill=document.getElementById("<%=txtHousingVill.ClientID%>");
                var txtHousingDescrip=document.getElementById("<%=txtHousingDescrip.ClientID%>");
                var txtHousingExten=document.getElementById("<%=txtHousingExten.ClientID%>");
                var txtHousingNoRoom=document.getElementById("<%=txtHousingNoRoom.ClientID%>");
                var txtHousingValue=document.getElementById("<%=txtHousingValue.ClientID%>");
                var hdnMainTab_Third=document.getElementById("<%=hdnMainTab_Third.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_Third.value;
                strhdvValue = strhdvValue + txtHousingVill.value+"|"+txtHousingDescrip.value +"|"+txtHousingExten.value +"|"+ txtHousingNoRoom.value+"|"+ txtHousingValue.value+"|1|3^";
                RenderTable(strhdvValue,MainTab.id,5);
                hdnMainTab_Third.value=strhdvValue;
                ClearGrid_MainTab_Third();
        }  
        return false;
    }   
    function Validate_MainTab_Third()
    {
            var txtHousingVill=document.getElementById("<%=txtHousingVill.ClientID%>");
            var txtHousingDescrip=document.getElementById("<%=txtHousingDescrip.ClientID%>");
            var txtHousingExten=document.getElementById("<%=txtHousingExten.ClientID%>");
            var txtHousingNoRoom=document.getElementById("<%=txtHousingNoRoom.ClientID%>");
            var txtHousingValue=document.getElementById("<%=txtHousingValue.ClientID%>");
            
            var ErrorMessage="";      
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
     
            var ReturnValue=true;     
        
           if (txtHousingValue.value=="")
              {
                ErrorMessage="Please Enter Value Details!";
                ReturnValue=false;
                txtHousingValue.focus();
              }
           if (txtHousingNoRoom.value=="")
            {
                ErrorMessage="Please Enter No of Rooms Details!";
                ReturnValue=false;
                txtHousingNoRoom.focus();
            }
             if (txtHousingExten.value=="")
            {
                ErrorMessage="Please Enter  Extend Details!";
                ReturnValue=false;
                txtHousingExten.focus();
            }
             if (txtHousingDescrip.value=="")
            {
                ErrorMessage="Please Enter  Descriptions Details!";
                ReturnValue=false;
                txtHousingDescrip.focus();
            }
                if (txtHousingVill.value=="")
            {
                ErrorMessage="Please Enter Village Details!";
                ReturnValue=false;
                txtHousingVill.focus();
            }
            
               
        lblMessage.innerText=ErrorMessage;      
        window.scroll(0,0);
        return ReturnValue;  
            
    }
    function ClearGrid_MainTab_Third()
    {
                var txtHousingVill=document.getElementById("<%=txtHousingVill.ClientID%>");
                var txtHousingDescrip=document.getElementById("<%=txtHousingDescrip.ClientID%>");
                var txtHousingExten=document.getElementById("<%=txtHousingExten.ClientID%>");
                var txtHousingNoRoom=document.getElementById("<%=txtHousingNoRoom.ClientID%>");
                var txtHousingValue=document.getElementById("<%=txtHousingValue.ClientID%>");

                
                txtHousingVill.value="";
                txtHousingDescrip.value="";
                txtHousingExten.value="";
                txtHousingNoRoom.value="";
                txtHousingValue.value="";
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
                                     
                                    var txtFamMemName=document.getElementById("<%=txtFamMemName.ClientID%>");
                                    var txtFamMemRelan=document.getElementById("<%=txtFamMemRelan.ClientID%>");
                                    var txtFamMemOccu=document.getElementById("<%=txtFamMemOccu.ClientID%>");
                                    var txtFamMemAnnInc=document.getElementById("<%=txtFamMemAnnInc.ClientID%>");
                                
                                    txtFamMemName.value=row.cells[1].innerText;
                                    txtFamMemRelan.value=row.cells[2].innerText;
                                    txtFamMemOccu.value=row.cells[3].innerText;
                                    txtFamMemAnnInc.value=row.cells[4].innerText;
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,4);
                                 }
                                 if (MainTab.id=="MainTab_Second")
                                 {
                                    
                                    var txtPropDetVill=document.getElementById("<%=txtPropDetVill.ClientID%>");
                                    var txtPropDetSurNo=document.getElementById("<%=txtPropDetSurNo.ClientID%>");
                                    var txtPropDetExten=document.getElementById("<%=txtPropDetExten.ClientID%>");
                                    var txtPropDetIrr=document.getElementById("<%=txtPropDetIrr.ClientID%>");
                                    var txtPropDetRenFed=document.getElementById("<%=txtPropDetRenFed.ClientID%>");
                                    var txtPropDetSource=document.getElementById("<%=txtPropDetSource.ClientID%>");
                                    var txtPropDetValue=document.getElementById("<%=txtPropDetValue.ClientID%>");                          
                                    
                                    txtPropDetVill.value=row.cells[1].innerText;
                                    txtPropDetSurNo.value=row.cells[2].innerText;
                                    txtPropDetExten.value=row.cells[3].innerText;
                                    txtPropDetIrr.value=row.cells[4].innerText;
                                    txtPropDetRenFed.value=row.cells[5].innerText;
                                    txtPropDetSource.value=row.cells[6].innerText;
                                    txtPropDetValue.value=row.cells[7].innerText;
                                    
                                    Delete_MainTab(MainTab.id,hdnChequeDetails.id,7);
                                 }
                                  if (MainTab.id=="MainTab_Third")
                                 {
                                        var txtHousingVill=document.getElementById("<%=txtHousingVill.ClientID%>");
                                        var txtHousingDescrip=document.getElementById("<%=txtHousingDescrip.ClientID%>");
                                        var txtHousingExten=document.getElementById("<%=txtHousingExten.ClientID%>");
                                        var txtHousingNoRoom=document.getElementById("<%=txtHousingNoRoom.ClientID%>");
                                        var txtHousingValue=document.getElementById("<%=txtHousingValue.ClientID%>");


                                        txtHousingVill.value=row.cells[1].innerText;
                                        txtHousingDescrip.value=row.cells[2].innerText;
                                        txtHousingExten.value=row.cells[3].innerText;
                                        txtHousingNoRoom.value=row.cells[4].innerText;
                                        txtHousingValue.value=row.cells[5].innerText;
                                       
                                        Delete_MainTab(MainTab.id,hdnChequeDetails.id,5);
                                 }
                                  if (MainTab.id=="MainTab_Fourth")
                                 {
                                        var txtOthPropTypeAssets=document.getElementById("<%=txtOthPropTypeAssets.ClientID%>");
                                        var txtOthPropDescrip=document.getElementById("<%=txtOthPropDescrip.ClientID%>");
                                        var txtOthPropMarkValue=document.getElementById("<%=txtOthPropMarkValue.ClientID%>");
            

                                        txtOthPropTypeAssets.value=row.cells[1].innerText;
                                        txtOthPropDescrip.value=row.cells[2].innerText;
                                        txtOthPropMarkValue.value=row.cells[3].innerText;
                                         
                                       
                                        Delete_MainTab(MainTab.id,hdnChequeDetails.id,3);
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
    
    function MainTab_First_AddtoGrid()
    {
        if (Validate_MainTab_First())
        {
                var MainTab=document.getElementById("MainTab_First");                           
                var txtFamMemName=document.getElementById("<%=txtFamMemName.ClientID%>");
                var txtFamMemRelan=document.getElementById("<%=txtFamMemRelan.ClientID%>");
                var txtFamMemOccu=document.getElementById("<%=txtFamMemOccu.ClientID%>");
                var txtFamMemAnnInc=document.getElementById("<%=txtFamMemAnnInc.ClientID%>");
                var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");
                        
                var strhdvValue="";            
                strhdvValue=hdnMainTab_First.value;
                strhdvValue = strhdvValue + txtFamMemName.value+"|"+txtFamMemRelan.value +"|"+txtFamMemOccu.value +"|"+ txtFamMemAnnInc.value+"|1|1^";
                RenderTable(strhdvValue,MainTab.id,4);
                hdnMainTab_First.value=strhdvValue;
                ClearGrid_MainTab_First();
        }  
        return false;
    }   
    function ClearGrid_MainTab_Second()
    {
                var txtPropDetVill=document.getElementById("<%=txtPropDetVill.ClientID%>");
                var txtPropDetSurNo=document.getElementById("<%=txtPropDetSurNo.ClientID%>");
                var txtPropDetExten=document.getElementById("<%=txtPropDetExten.ClientID%>");
                var txtPropDetIrr=document.getElementById("<%=txtPropDetIrr.ClientID%>");
                var txtPropDetRenFed=document.getElementById("<%=txtPropDetRenFed.ClientID%>");
                var txtPropDetSource=document.getElementById("<%=txtPropDetSource.ClientID%>");
                var txtPropDetValue=document.getElementById("<%=txtPropDetValue.ClientID%>");                          
                
                
                txtPropDetVill.value="";
                txtPropDetSurNo.value="";
                txtPropDetExten.value="";
                txtPropDetIrr.value="";
                txtPropDetRenFed.value="";
                txtPropDetSource.value="";
                txtPropDetValue.value="";
    }
    
    function ClearGrid_MainTab_First()
    {
            var txtFamMemName=document.getElementById("<%=txtFamMemName.ClientID%>");
            var txtFamMemRelan=document.getElementById("<%=txtFamMemRelan.ClientID%>");
            var txtFamMemOccu=document.getElementById("<%=txtFamMemOccu.ClientID%>");
            var txtFamMemAnnInc=document.getElementById("<%=txtFamMemAnnInc.ClientID%>");
          
            txtFamMemName.value="";
            txtFamMemRelan.value="";
            txtFamMemOccu.value="";
            txtFamMemAnnInc.value="";
            
            txtFamMemName.focus();
    }
    function MainTab_Second_AddtoGrid()
    {
        if (Validate_Main_Tab_Second())
        {

                var MainTab=document.getElementById("MainTab_Second");                     
                var txtPropDetVill=document.getElementById("<%=txtPropDetVill.ClientID%>");
                var txtPropDetSurNo=document.getElementById("<%=txtPropDetSurNo.ClientID%>");
                var txtPropDetExten=document.getElementById("<%=txtPropDetExten.ClientID%>");
                var txtPropDetIrr=document.getElementById("<%=txtPropDetIrr.ClientID%>");
                var txtPropDetRenFed=document.getElementById("<%=txtPropDetRenFed.ClientID%>");
                var txtPropDetSource=document.getElementById("<%=txtPropDetSource.ClientID%>");
                var txtPropDetValue=document.getElementById("<%=txtPropDetValue.ClientID%>");                          
                var hdnMainTab_Second=document.getElementById("<%=hdnMainTab_Second.ClientID%>");                          
                
                 
                var strhdvValue="";            
                strhdvValue=hdnMainTab_Second.value;
                strhdvValue = strhdvValue + txtPropDetVill.value+"|"+txtPropDetSurNo.value +"|"+txtPropDetExten.value +"|"+ txtPropDetIrr.value+"|"+txtPropDetRenFed.value+"|"+txtPropDetSource.value+"|"+txtPropDetValue.value+"|1|2^";
                RenderTable(strhdvValue,MainTab.id,7);
                hdnMainTab_Second.value=strhdvValue;
                ClearGrid_MainTab_Second();
        
        
        }
        
        return false;
    }    
    function Validate_Main_Tab_Second()
    {
      var MainTab=document.getElementById("MainTab_Second");                     
      var txtPropDetVill=document.getElementById("<%=txtPropDetVill.ClientID%>");
      var txtPropDetSurNo=document.getElementById("<%=txtPropDetSurNo.ClientID%>");
      var txtPropDetExten=document.getElementById("<%=txtPropDetExten.ClientID%>");
      var txtPropDetIrr=document.getElementById("<%=txtPropDetIrr.ClientID%>");
      var txtPropDetRenFed=document.getElementById("<%=txtPropDetRenFed.ClientID%>");
      var txtPropDetSource=document.getElementById("<%=txtPropDetSource.ClientID%>");
      var txtPropDetValue=document.getElementById("<%=txtPropDetValue.ClientID%>");
      
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
     
        var ReturnValue=true;     
        
           if (txtPropDetValue.value=="")
          {
            ErrorMessage="Please Enter Value Details!";
            ReturnValue=false;
            txtPropDetValue.focus();
          }
           if (txtPropDetSource.value=="")
          {
            ErrorMessage="Please Enter Source Details!";
            ReturnValue=false;
            txtPropDetSource.focus();
          }
         
    
        if (txtPropDetRenFed.value=="")
          {
            ErrorMessage="Please Enter Rain Fed Details!";
            ReturnValue=false;
            txtPropDetRenFed.focus();
          }
          
            if (txtPropDetIrr.value=="")
          {
            ErrorMessage="Please Enter Irrigation Details!";
            ReturnValue=false;
            txtPropDetIrr.focus();
          }
          
             if (txtPropDetExten.value=="")
          {
            ErrorMessage="Please Enter Extent Details!";
            ReturnValue=false;
            txtPropDetExten.focus();
          }          
         
           if (txtPropDetSurNo.value=="")
          {
            ErrorMessage="Please Enter Survey No!";
            ReturnValue=false;
            txtPropDetSurNo.focus();
          }
          
         if (txtPropDetVill.value=="")
          {
            ErrorMessage="Please Enter Village!";
            ReturnValue=false;
            txtPropDetVill.focus();
          }        
          
       lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
      return ReturnValue;  
    
    }     
    function Validate_MainTab_First()
    {
      var MainTab=document.getElementById("MainTab_First");                     
      var txtFamMemName=document.getElementById("<%=txtFamMemName.ClientID%>");
      var txtFamMemRelan=document.getElementById("<%=txtFamMemRelan.ClientID%>");
      var txtFamMemOccu=document.getElementById("<%=txtFamMemOccu.ClientID%>");
      var txtFamMemAnnInc=document.getElementById("<%=txtFamMemAnnInc.ClientID%>");
      
      var ErrorMessage="";      
      var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
     
      var ReturnValue=true;
      
       if (txtFamMemAnnInc.value=="")
      {
        ErrorMessage="Please Enter Family Member Annual Income!";
        ReturnValue=false;
        txtFamMemAnnInc.focus();
      }
        if (txtFamMemOccu.value=="")
      {
        ErrorMessage="Please Enter Family Member Occupation!";
        ReturnValue=false;
        txtFamMemOccu.focus();
      }
      if (txtFamMemRelan.value=="")
      {
        ErrorMessage="Please Enter Family Member Relationship!";
        ReturnValue=false;
        txtFamMemRelan.focus();
      }
      
    if (txtFamMemName.value=="")
      {
        ErrorMessage="Please Enter Family Member Name!";
        ReturnValue=false;
        txtFamMemName.focus();
      }
      
      lblMessage.innerText=ErrorMessage;
      
      window.scroll(0,0);
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
    
    function SaveValidation()
    {
        var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");  
        var ddlVeriStat=document.getElementById("<%=ddlVeriStat.ClientID%>")
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>") 
        
        var ReturnValue=true;
        var ErrorMsg="";
        
        if(txtRemark.value =='')
        {
            ErrorMsg='Please Enter Remark......!!!!!!';
            ReturnValue=false;
            txtRemark.focus();
        }
         if(ddlVeriStat.selectedIndex == 0)
        {
            ErrorMsg='Please Enter Atleast one Verification Status......!!!!!!';
            ReturnValue=false;
            ddlVeriStat.focus();
        }
        
        lblMessage.innerText=ErrorMsg;
                    if(ErrorMsg!='')
                    {
                        window.scrollTo(0,0);
                    }
                           return ReturnValue;          
    }
     //Common Function  
 

    </script>
    <table style="width: 883px" class="bx">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="6" style="height: 16px">
                Employee Address Verification</td>
        </tr>
        <tr>
            <td colspan="6">
                            <table style="width: 922px" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td class="reportTitle" colspan="1" style="width: 7px">
                                    </td>
                                    <td colspan="2" class="reportTitleIncome">
                                        <asp:Label ID="Label1" runat="server" Text="Name of Employee" Width="177px"></asp:Label></td>
                                    <td style="width: 155px" class="Info">
                                        <asp:TextBox ID="txtEmpFname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 100px" class="Info">
                                        <asp:TextBox ID="txtEmpMname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 98px" class="Info">
                                        <asp:TextBox ID="txtEmpLname" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
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
                                    <td style="width: 7px">
                                    </td>
                                    <td class="reportTitleIncome" colspan="2">
                                    </td>
                                    <td style="width: 155px; text-align: center" class="Info">
                                        First Name</td>
                                    <td style="width: 100px; text-align: center" class="Info">
                                         Middle Name</td>
                                    <td style="width: 98px; text-align: center" class="Info">
                                         Last Name</td>
                                    <td style="width: 100px;">
                                    </td>
                                    <td style="width: 100px;">
                                    </td>
                                    <td style="width: 100px;">
                                    </td>
                                    <td style="width: 100px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="reportTitle" colspan="1" style="width: 7px; height: 16px">
                                    </td>
                                    <td colspan="2" style="height: 16px" class="reportTitleIncome">
                                        
                                Client Ref. Name/No </td>
                                    <td class="Info" style="width: 155px">
                                        <asp:TextBox ID="txtRefNo" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 98px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="reportTitle" colspan="1" style="width: 7px">
                                    </td>
                                    <td colspan="2" class="reportTitleIncome">
                                Received Date</td>
                                    <td style="width: 155px" class="Info">
                                        <asp:TextBox ID="txtRcvdDate" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 98px">
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
                                    <td class="reportTitle" colspan="1" style="width: 7px; height: 16px">
                                    </td>
                                    <td colspan="2" style="height: 16px" class="reportTitleIncome">
                                Father's Name</td>
                                    <td colspan="2" style="height: 16px; text-align: left;" class="Info">
                                        <asp:TextBox ID="txtFatFname" runat="server" Enabled="False" SkinID="txtSkin" Width="291px"></asp:TextBox></td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="reportTitle" colspan="1" style="width: 7px; height: 16px">
                                    </td>
                                    <td colspan="2" style="height: 16px" class="reportTitleIncome">
                                        Date of Birth</td>
                                    <td style="height: 16px; text-align: left; width: 155px;" class="Info">
                                        <asp:TextBox ID="txtDOB" runat="server" Enabled="False" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                    <td style="width: 100px; height: 16px">
                                    </td>
                                </tr>
                            </table>
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="6" style="height: 8px">
                &nbsp;Address Verification Details</td>
        </tr>
        <tr>
            <td style="width: 10px; height: 22px;">
            </td>
            <td class="reportTitleIncome" style="height: 22px">
                <asp:Label ID="Label2" runat="server" Text="Sub Verification Type" Width="152px"></asp:Label></td>
            <td style="width: 100px; height: 22px;" class="Info">
                                <asp:DropDownList ID="ddlSubVeriType" runat="server" Width="153px" AutoPostBack="True" OnSelectedIndexChanged="ddlSubVeriType_SelectedIndexChanged" SkinID="ddlSkin">
                                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 22px;">
                Contact No.</td>
            <td style="width: 114px; height: 22px;" class="Info">
                                <asp:TextBox ID="txtContNo" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 99px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 12px">
            </td>
            <td class="reportTitleIncome" style="height: 12px">
                City</td>
            <td class="Info" style="width: 100px; height: 12px">
                <asp:TextBox ID="txtCity" runat="server" Width="122px" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 12px">
                Pincode</td>
            <td class="Info" style="width: 114px; height: 12px">
                <asp:TextBox ID="txtPincode" runat="server" Width="118px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 12px">
            </td>
            <td class="reportTitleIncome" style="height: 12px">
                Period of Stay</td>
            <td class="Info" style="width: 100px; height: 12px">
                <asp:TextBox ID="txtPeriodOfStay" runat="server" SkinID="txtSkin" Width="121px"></asp:TextBox></td>
            <td style="height: 12px">
            </td>
            <td style="width: 114px; height: 12px">
            </td>
            <td style="height: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                Employee Address</td>
            <td colspan="4" class="Info">
                                <asp:TextBox ID="txtEmpAdd" runat="server" TextMode="MultiLine" Width="574px" SkinID="txtSkin_New"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                Name of Respondent</td>
            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtNameRespo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 114px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                                Relationship</td>
            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtRelan" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 114px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                                Address of Respodent</td>
            <td colspan="4" class="Info">
                                <asp:TextBox ID="txtAddRespo" runat="server" TextMode="MultiLine" Width="573px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                Respondent Contact No</td>
            <td style="width: 100px" class="Info">
                                <asp:TextBox ID="txtContRespo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 114px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                                Residence Type<strong> </strong>
            </td>
            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlResiType" runat="server" Width="154px" SkinID="ddlSkin">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Owned</asp:ListItem>
                                    <asp:ListItem>Rented</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList></td>
            <td class="reportTitleIncome">
                                If Other,Then</td>
            <td style="width: 114px" class="Info">
                                <asp:TextBox ID="txtOthResiType" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="height: 23px">
                No Of Members in Family</td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:TextBox ID="txtNoOfFamilyMember" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 23px">
            </td>
            <td style="width: 114px; height: 23px">
                &nbsp;</td>
            <td style="width: 99px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="height: 23px">
                Building Type</td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:DropDownList ID="ddlBuildingType" runat="server" Width="127px" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Independent House</asp:ListItem>
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Chawl</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="height: 23px">
                BuildingType,if Others then</td>
            <td class="Info" style="width: 114px; height: 23px">
                <asp:TextBox ID="txtBuildingTypeOther" runat="server" SkinID="txtSkin" Width="119px"></asp:TextBox></td>
            <td style="width: 99px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="height: 23px">
                Presence of security personnel</td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:TextBox ID="txtPresenceOfSecurity" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 23px">
                Name as per Board</td>
            <td class="Info" style="width: 114px; height: 23px">
                <asp:TextBox ID="txtNameBoard" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 99px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 23px">
            </td>
            <td class="reportTitleIncome" style="height: 23px">
                Name of 1st Neighbour
                <br />
                &amp; Number</td>
            <td class="Info" style="width: 100px; height: 23px">
                <asp:TextBox ID="txtFirstNeigh" runat="server" Height="42px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="228px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 23px">
                Name of 2nd Neighbour
                <br />
                &amp; Number</td>
            <td class="Info" style="width: 114px; height: 23px">
                <asp:TextBox ID="txtSecondNeigh" runat="server" Height="42px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="228px"></asp:TextBox></td>
            <td style="width: 99px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px;">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                                Landmark 
            </td>
            <td style="width: 100px; height: 16px;" class="Info">
                                <asp:TextBox ID="txtLand" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="height: 16px">
                                Marital Status</td>
            <td style="width: 114px; height: 16px;" class="Info">
                <asp:DropDownList ID="ddlMariStat" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>Married</asp:ListItem>
                                <asp:ListItem>Single</asp:ListItem>
                            </asp:DropDownList></td>
            <td style="width: 99px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                <asp:Label ID="lblSpoketoApplicantatRes" runat="server" Text="Met / Spoke to applicant at Residence"
                    Width="190px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlMetToSpokeatResidence" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="height: 16px">
                <asp:Label ID="lblaceabilityOfResLoc" runat="server" Text="Traceability of Residence Location"
                    Width="169px"></asp:Label></td>
            <td class="Info" style="width: 114px; height: 16px">
                <asp:DropDownList ID="ddlaceabilityOfResLoc" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                    <asp:ListItem>Untraceable</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 99px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                <asp:Label ID="lblRationcard" runat="server" Text="Ration Card available for same address"
                    Width="195px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlRationcard" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="height: 16px">
                <asp:Label ID="lblConfirmationfromNeighbour" runat="server" Text="Confirmation from Neighbor"></asp:Label></td>
            <td class="Info" style="width: 114px; height: 16px">
                <asp:DropDownList ID="ddlConfirmationOfNeighbour" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 99px; height: 16px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="6" style="height: 16px">
            </td>
        </tr>
        <tr>
       
            <td colspan="6" style="height: 21px">
            <div class="tabber">
             <div id ="FamilyDetails" class="tabbertab">
             <h2> Family Details</h2>
                <table cellspacing="0" class="bx" style="width: 294px; height: 215px">
                    <tr>
                        <td class="reportTitle" style="height: 16px; text-align: center">
                            Name</td>
                        <td class="reportTitle" style="width: 100px; height: 16px; text-align: center">
                            <strong>&nbsp;</strong>Relation</td>
                        <td class="reportTitle" style="width: 100px; height: 16px; text-align: center">
                            Occupation</td>
                        <td class="reportTitle" style="width: 100px; height: 16px; text-align: center">
                            Annual Income</td>
                        <td class="reportTitleIncome" rowspan="2" style="width: 100px">
                            <table>
                                <tr>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemAdd" runat="server" Text="Add" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemEdit" runat="server" Text="Edit" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnFamMemDel" runat="server" Text="Del" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome">
                            <asp:TextBox ID="txtFamMemName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtFamMemRelan" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtFamMemOccu" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtFamMemAnnInc" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 14px">
                            <div id="dv1" style="overflow: scroll; width: 776px; height: 116px">
                                <table id="MainTab_First" cellpadding="2" cellspacing="1" style="width: 493px">
                                    <tr>
                                        <th class="SubTable_Header" style="width: 23px; height: 24px">
                                            <input id="chkSelectAll_first" onclick="javascript:SelectAll('MainTab_First','chkSelectAll_first');"
                                                type="checkbox" /></th>
                                        <th class="SubTable_Header" style="width: 104px; height: 24px; text-align: center">
                                            Name</th>
                                        <th class="SubTable_Header" style="height: 24px; text-align: center">
                                            Relation</th>
                                        <th class="SubTable_Header" style="width: 80px; height: 24px; text-align: center">
                                            Occupation</th>
                                        <th class="SubTable_Header" style="width: 175px; height: 24px; text-align: center">
                                                            Annual_Income</th>
                                        <th style="height: 24px">
                                        </th>
                                        <th style="width: 3px; height: 24px">
                                        </th>
                                    </tr>
                                </table>
                            </div>
                            <asp:HiddenField ID="hdnMainTab_First" runat="server" />
                        </td>
                    </tr>
                </table>
                </div>
             <div id ="Div4" class="tabbertab">
                  <h2> Agriculure Details</h2>
                <table cellpadding="1" cellspacing="1" class="bx" style="width: 209px; height: 261px">
                    <tr>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Village</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Sr No./SurveyNo.</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Extent</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Irrigated</td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetVill" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetSurNo" runat="server" Width="146px" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetExten" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetIrr" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Rain Fed</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Irrigation Source</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Value</td>
                        <td class="reportTitleIncome" rowspan="2" style="text-align: left">
                            <table style="width: 1px">
                                <tr>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnPropDetAdd" runat="server" Text="Add" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnPropDetEdit" runat="server" Text="Edit" /></td>
                                    <td style="width: 100px; height: 20px">
                                        <asp:Button ID="btnPropDetDel" runat="server" Text="Del" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetRenFed" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetSource" runat="server" SkinID="txtSkin_New" Width="146px"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px; text-align: center">
                            <asp:TextBox ID="txtPropDetValue" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 9px">
                            <div id="Div1" style="overflow: scroll; width: 816px; height: 96px">
                                <table id="MainTab_Second" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <th class="SubTable_Header" style="width: 23px">
                                            <input id="chkSelectAll_Second" onclick="javascript:SelectAll('MainTab_Second','chkSelectAll_Second');"
                                                type="checkbox" /></th>
                                        <th class="SubTable_Header" style="text-align: center">
                                            Village</th>
                                        <th class="SubTable_Header" style="width: 62px; text-align: center">
                                            SurveNo</th>
                                        <th class="SubTable_Header" style="width: 37px; text-align: center">
                                            Extent</th>
                                        <th class="SubTable_Header" style="width: 50px; text-align: left">
                                            Irrigated</th>
                                        <th class="SubTable_Header" style="width: 72px; text-align: left">
                                            RainFed</th>
                                        <th class="SubTable_Header" style="width: 133px; text-align: left">
                                            Irrigation Source</th>
                                        <th class="SubTable_Header" style="width: 46px; text-align: left">
                                            Value</th>
                                        <th style="width: 21px; text-align: left">
                                        </th>
                                        <th style="width: 11px; text-align: left">
                                        </th>
                                    </tr>
                                </table>
                            </div>
                            <asp:HiddenField ID="hdnMainTab_Second" runat="server" />
                        </td>
                    </tr>
                </table>
                </div>
             <div id ="Div5" class="tabbertab">
                  <h2> Housing Details</h2>
                <table class="bx" style="width: 173px">
                    <tr>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Village</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Door No</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Extent</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                                No. of Rooms</td>
                        <td class="reportTitle" style="width: 100px; text-align: center">
                            Value</td>
                        <td class="reportTitleIncome" rowspan="2" style="width: 100px">
                            <table>
                                <tr>
                                    <td style="width: 100px; height: 21px">
                                        <asp:Button ID="btnHousingAdd" runat="server" Text="Add" Width="41px" /></td>
                                    <td style="width: 100px; height: 21px">
                                        <asp:Button ID="btnHousingEdit" runat="server" Text="Edit" Width="41px" /></td>
                                    <td style="width: 97px; height: 21px">
                                        <asp:Button ID="btnHousingDelete" runat="server" Text="Del" Width="43px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtHousingVill" runat="server" Width="109px" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtHousingDescrip" runat="server" Width="107px" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtHousingExten" runat="server" Width="98px" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtHousingNoRoom" runat="server" Width="113px" SkinID="txtSkin_New"></asp:TextBox></td>
                        <td class="reportTitleIncome" style="width: 100px">
                            <asp:TextBox ID="txtHousingValue" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height: 81px">
                            <div id="Div2" style="overflow: scroll; width: 829px; height: 91px">
                                <table id="MainTab_Third" cellpadding="1" cellspacing="1" style="width: 545px">
                                    <tr>
                                        <th class="SubTable_Header" style="width: 23px; height: 24px">
                                            <input id="chkSelectAll_Third" onclick="javascript:SelectAll('MainTab_Third','chkSelectAll_Third');"
                                                type="checkbox" /></th>
                                        <th class="SubTable_Header" style="height: 24px; text-align: left">
                                            <span style="font-size: 9pt">Village</span></th>
                                        <th class="SubTable_Header" style="font-size: 9pt; height: 24px; text-align: left">
                                            &nbsp;Door No</th>
                                        <th class="SubTable_Header" style="height: 24px; text-align: left">
                                            &nbsp;Extent</th>
                                        <th class="SubTable_Header" style="width: 85px; height: 24px; text-align: left">
                                            <span style="font-size: 9pt">&nbsp;No of Room</span></th>
                                        <th class="SubTable_Header" style="font-size: 9pt; width: 47px; height: 24px">
                                            &nbsp;Value</th>
                                        <th style="font-size: 8pt; width: 26px; height: 24px; text-align: left">
                                        </th>
                                        <th style="font-size: 8pt; width: 28px; height: 24px; text-align: left">
                                        </th>
                                    </tr>
                                </table>
                            </div>
                            <asp:HiddenField ID="hdnMainTab_Third" runat="server" />
                        </td>
                    </tr>
                </table>
                </div>
             <div id ="Div6" class="tabbertab">
                  <h2> Property Details</h2>
                <table id="tab1" cellpadding="1" cellspacing="1" class="bx" style="width: 175px">
                    <tbody>
                        <tr style="font-size: 8pt">
                            <td class="reportTitle" style="height: 16px; text-align: center">
                                Type Of Assets</td>
                            <td class="reportTitle" style="width: 100px; height: 16px; text-align: center">
                                Description</td>
                            <td class="reportTitle" style="height: 16px; text-align: center; width: 214px;">
                                Market Value</td>
                            <td class="reportTitleIncome" colspan="2" rowspan="2">
                                <table style="width: 131px">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnOthProp_Add" runat="server" Text="Add" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnOthProp_Edit" runat="server" Text="Edit" /></td>
                                            <td style="width: 100px; height: 20px">
                                                <asp:Button ID="btnOthProp_Del" runat="server" Text="Del" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr style="font-size: 8pt">
                            <td class="reportTitleIncome" style="text-align: center">
                                <asp:TextBox ID="txtOthPropTypeAssets" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="width: 100px; text-align: center">
                                <asp:TextBox ID="txtOthPropDescrip" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                            <td class="reportTitleIncome" style="text-align: center; width: 214px;">
                                <asp:TextBox ID="txtOthPropMarkValue" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
                        </tr>
                        <tr style="font-size: 8pt">
                            <td colspan="5" style="text-align: left">
                                <div id="Div3" style="overflow: scroll; width: 837px; height: 106px">
                                    <table id="MainTab_Fourth" border="0" cellpadding="1" cellspacing="1" style="width: 519px">
                                        <tbody>
                                            <tr>
                                                <th class="SubTable_Header" style="width: 23px; height: 24px">
                                                    <input id="chkSelectAll_Fourth" onclick="javascript:SelectAll('MainTab_Fourth','chkSelectAll_Fourth');"
                                                        type="checkbox" /></th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                    Type of Assets</th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center">
                                                    Description</th>
                                                <th class="SubTable_Header" style="height: 24px; text-align: center; width: 157px;">
                                                    Market Value</th>
                                                <th style="width: 3px; height: 24px; text-align: center">
                                                </th>
                                                <th style="height: 24px; text-align: center">
                                                </th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <asp:HiddenField ID="hdnMainTab_Fourth" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                                Remarks / Feedback *</td>
            <td class="Info" colspan="4">
                                <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                    Width="650px" Height="90px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                Status *</td>
            <td style="width: 100px" class="Info">
                                <asp:DropDownList ID="ddlVeriStat" runat="server" Width="144px" SkinID="ddlSkin">
                                    <asp:ListItem>NA</asp:ListItem>
                                    <asp:ListItem>Positive</asp:ListItem>
                                    <asp:ListItem>Negative</asp:ListItem>
                                    <asp:ListItem>Discrepant</asp:ListItem>
                                    <asp:ListItem>UTV</asp:ListItem>
                                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 114px">
            </td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px; height: 16px;">
            </td>
            <td class="reportTitleIncome" style="height: 16px">
                Date of Verification</td>
            <td style="width: 100px; height: 16px;" class="Info">
                                <table style="width: 152px" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txtVeriDate" runat="server" Width="109px" SkinID="txtSkin_New"></asp:TextBox></td>
                                        <td style="width: 39px">
                                            &nbsp;<img id="Image1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                                src="../../Images/SmallCalendar.gif" /></td>
                                            
                                    </tr>
                                </table>
            </td>
            <td style="width: 100px; height: 16px;" class="reportTitleIncome">
                                Time of Verification</td>
            <td style="width: 114px; height: 16px;" class="Info">
                                <asp:TextBox ID="txtVeriTime" runat="server" Width="96px" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 99px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                                Field Executive Name</td>
            <td class="Info" style="width: 100px">
                                <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px">
                                Supervisor Name</td>
            <td class="Info" style="width: 114px">
                                <asp:TextBox ID="txtSupName" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 99px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="reportTitleIncome">
                Upload Attachment</td>
            <td colspan="3" class="info">
                <asp:FileUpload ID="FileUpload1" Width="70%"  runat="server" SkinID="flup" />
                 <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                     View Uploaded Attachment</span></a>            
            </td>
        </tr>
           
               
        <tr>
            <td class="tta" colspan="6" style="height: 30px">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" SkinID="btn" Text="Save" Width="77px" OnClick="btnSave_Click" Font-Bold="True" />
                <asp:Button ID="btnCan" runat="server" SkinID="btn" Text="Cancel" Width="91px" OnClick="btnCan_Click" Font-Bold="True" /></td>
        </tr>
        <tr>
            <td style="width: 10px; height: 9px;">
            </td>
            <td style="width: 100px; height: 9px;">
                                <asp:HiddenField ID="hdnCaseID" runat="server" />
                &nbsp;&nbsp;
            </td>
            <td style="width: 100px; height: 9px;">
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
            </td>
            <td style="width: 100px; height: 9px;">
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
            </td>
            <td style="width: 114px; height: 9px;">
            </td>
            <td style="width: 99px; height: 9px;">
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

