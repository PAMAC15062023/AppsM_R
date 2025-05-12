<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileSharing.aspx.cs" Inherits="FTP_FTP_Dynamic_FileSharing" StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sharing File Window</title>
    <link href="../../StyleSheet_EBC.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">

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
            
    /////////////////////*****************************************///////////////////////////////////////////
    function Page_load_validation()
     {
        var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");                                                 
        var MainTab1=document.getElementById("MainTab_First");
        RenderTable(hdnMainTab_First.value,MainTab1.id,2);
     }
     
      function MainTab_First_AddtoGrid()
    {
        var ddlEmpName=document.getElementById("<%=ddlEmpName.ClientID%>");
             
        if (ValidateRowAdd())
        {
                var MainTab=document.getElementById("MainTab_First");                           
                var hdnMainTab_First=document.getElementById("<%=hdnMainTab_First.ClientID%>");                
                var Index=ddlEmpName.selectedIndex; 
                var strEmpDetails = ddlEmpName.value;                         
                
                var arrEmpValue=strEmpDetails.split(':',strEmpDetails.length);
                
                var strhdvValue="";            
                strhdvValue=hdnMainTab_First.value;               
                               
                strhdvValue = strhdvValue + arrEmpValue[1] +"|"+ddlEmpName.options[Index].innerText +"|"+arrEmpValue[0]+"^";
                RenderTable(strhdvValue,MainTab.id,2);
                hdnMainTab_First.value=strhdvValue;
                //ClearGrid_MainTab_First();
        }  
       
        return false;
    } 
        
        function ValidateRowAdd()
        {
         var MainTab=document.getElementById("MainTab_First");                                          
         var ddlEmpName=document.getElementById("<%=ddlEmpName.ClientID%>");
         var lblPnlErrorMessage=document.getElementById("<%=lblPnlErrorMessage.ClientID%>");
         var ReturnValue=true;
         var ErrorMessage="";
         
             
                if(ddlEmpName.selectedIndex==0)
                {
                    ErrorMessage= 'No Employee selected for Shared File!';
                    ReturnValue=false;
                    ddlEmpName.focus();

                }
                  else
                  {      for(i=0;i<=MainTab.rows.length-1;i++)
                            { 
                                //debugger;
                                    var strEmpDetails = ddlEmpName.value;                         
                
                                 var arrEmpValue=strEmpDetails.split(':',strEmpDetails.length);
                                var Value=arrEmpValue[1];
                                if (MainTab.rows[i].cells[1].innerText==Value)
                                {
                                    ErrorMessage='Entry already Added!';
                                    ddlEmpName.focus();    
                                    ReturnValue=false;
                                } 
                            } 
                }
                lblPnlErrorMessage.innerText=ErrorMessage;
                
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
    
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel2" runat="server" Height="150px" Width="200px">
                <table style="width: 530px" class="bx">
                    <tbody>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblPnlErrorMessage" runat="server" Width="100%" CssClass="ErrorMessage"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height: 16px" class="topbar" colspan="6">
                                &nbsp;File Sharing
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 6px; height: 3px">
                            </td>
                            <td style="height: 3px; width: 87px;" class="reportTitleIncome">
                                <asp:Label ID="Label2" runat="server" Text="File Name (Shared File)" Width="161px"></asp:Label></td>
                            <td style="height: 3px" class="Info" colspan="4">
                                <asp:TextBox ID="txtSharedFileName" runat="server" AutoPostBack="True" ReadOnly="True" Width="178px" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 6px; height: 1px">
                            </td>
                            <td style="height: 1px; width: 87px;" class="reportTitleIncome">
                                Employee Name</td>
                            <td style="height: 1px" class="Info" colspan="2">
                                <asp:DropDownList ID="ddlEmpName" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlEmpName_SelectedIndexChanged">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 1px" colspan="2">
                                &nbsp;
                                <table>
                                    <tr>
                                        <td style="width: 59px">
                                <asp:Button ID="btnAdd"  runat="server" Width="52px" Text="Add" Font-Bold="True" SkinID="btn">
                                </asp:Button></td>
                                        <td style="width: 71px">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Font-Bold="True" SkinID="btn"></asp:Button></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 3px" class="tta" colspan="6">
                                &nbsp;File Shared Employee</td>
                        </tr>
                        <tr>
                            <td style="width: 6px; height: 151px">
                            </td>
                            <td style="height: 151px" colspan="5">
                                <div style="overflow: scroll; width: 511px; height: 116px" id="dv1">
                                    <table style="width: 493px" id="MainTab_First" cellspacing="1" cellpadding="2">
                                        <tbody>
                                            <tr>
                                                <th style="width: 23px" class="SubTable_Header">
                                                    <input id="chkSelectAll_first" onclick="javascript:SelectAll('MainTab_First','chkSelectAll_first');"
                                                        type="checkbox" /></th>
                                                <th style="width: 104px; text-align: center" class="SubTable_Header">
                                                    Emp ID/Code</th>
                                                <th style="width: 192px; text-align: center" class="SubTable_Header">
                                                    Emp Name</th>
                                                <th>
                                                </th>
                                                <th style="width: 3px">
                                                </th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <asp:HiddenField ID="hdnMainTab_First" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdnFileID" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 6px; height: 20px">
                            </td>
                            <td colspan="2" style="height: 20px">
                                <asp:Button ID="btnSave" runat="server" Font-Bold="True" OnClick="btnSave_Click"
                                    Text="Save" SkinID="btn" />&nbsp;
                                <asp:Button ID="btnClear" runat="server" Font-Bold="True" OnClick="btnClear_Click"
                                    Text="Clear" SkinID="btn" /></td>
                            <td style="height: 20px">
                            </td>
                            <td style="width: 100px; height: 20px">
                            </td>
                            <td style="width: 94px; height: 20px">
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Underline="True"
                                    OnClientClick="window.close();">Close</asp:LinkButton></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
