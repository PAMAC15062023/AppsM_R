<%@ Page Language="C#" MasterPageFile="~/CPA/PDNEW/CPA_MasterPage.master" AutoEventWireup="true" CodeFile="SendToClient_Final.aspx.cs" Inherits="CPA_PD_SendToClient_Final" Theme="skinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function funValidateFromToDate()
{

    var strFromDate = document.getElementById("<%=txtfromdate.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //===split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

    //==Converting the string to date format
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);

    //declareing the date variable
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();
    //setTime 
    date1.setTime(dtFromDate.getTime());
    date2.setTime(dtToDate.getTime());
    var add_one_day = date2.getTime()+(1000 * 60 * 60 * 24);
    diff.setTime(Math.floor(add_one_day-date1.getTime()));
    var dateDiff = diff.getTime();
    
    if (parseInt(dateDiff) <= 0) 
    {
         alert("To Date should not be less then From Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  

function funOnClickCheckbox(strID)
{    
    CHKID = strID.id;
    var getID = strID.id;
    getID = getID.replace(/ChkTAT/,"hdnWithinTat");
    if(document.getElementById(CHKID).checked)
    {
        document.getElementById(getID).value="1";
    }
    else
    {
        document.getElementById(getID).value="0";
    }
}

function funValidateSendToDate()
{    
    var flagChkFotTat=false;
    var gv=document.getElementById('<%=gvSendTat.ClientID%>');    
    if(gv.Visible=true)
    {        
        var length=gv.rows.length; 
        var bFlag=true;
        var diff;       
        var StdTAT=document.getElementById('<%=hdnStandardTAT.ClientID%>').value;
        //Send Date --------
        var strSendDate = document.getElementById("<%=txtSendDt.ClientID%>").value;
        var strSendTime = document.getElementById("<%=txtSendTm.ClientID%>").value;              
        var strSendType = document.getElementById("<%=ddlSendTimeType.ClientID%>").value;         
        var SendDate=strSendDate + " " + strSendTime + " " + strSendType
        //===split and fill into array
        var arSendDate = SendDate.split('/');
        //var arSendTime = SendDate.split('');
            
        //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
        var strNewSendDate = arSendDate[1]+"/"+arSendDate[0]+"/"+arSendDate[2];
        var strSendDate1=new Date(strNewSendDate);
        
        if(strSendDate!="" && strSendTime!="")
        {
            var strSend= new Date();        
            for(i=1;i<length;i++)
            {
                //Received Date -------------
                var strRecdDate=gv.rows[i].cells[4].innerText;
                //===split and fill into array
                var arRecdDate = strRecdDate.split('/');
                //var arRecdTime = strRecdDate.split('');
            
                //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
                var strNewRecdDate = arRecdDate[1]+"/"+arRecdDate[0]+"/"+arRecdDate[2];        
                
                var strRecdDate1 =new Date(strNewRecdDate);              
                //Difference between Recd Date and Send Date --------
                diff=Math.abs(strSendDate1.getTime())- Math.abs(strRecdDate1.getTime());
                if (parseInt(diff) <= 0) 
                {
                   bFlag=false;                                                             
                }                      
            }   
                            
            if(bFlag==true)     //If send date is greater than Recd date then calculate TAT hours...
            {
             for(i=1;i<length;i++)
              {                
                var Case_Id=gv.rows[i].cells[1].innerText;
                    //Received Date -------------
                var strRecdDate=gv.rows[i].cells[4].innerText;
                //===split and fill into array
                var arRecdDate = strRecdDate.split('/');
                var arRecdTime = strRecdDate.split('');
            
                //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
                var strNewRecdDate = arRecdDate[1]+"/"+arRecdDate[0]+"/"+arRecdDate[2];        
                
                var strRecdDate1 =new Date(strNewRecdDate);              
                //Difference between Recd Date and Send Date --------
                diff=Math.abs(strSendDate1.getTime())- Math.abs(strRecdDate1.getTime());
                var hours = Math.floor(diff / (1000 * 60 * 60)); 
                    diff -= hours * (1000 * 60 * 60);
                    var mins = Math.floor(diff / (1000 * 60));                   
                    var hdnWithinTat;
                    
                    if(i<9)
                    {
                        var TatRow=document.getElementById("ctl00_C1_gvSendTat_ctl0"+parseInt(i+1)+"_lblTat"); 
                        TatRow.innerText =hours+':'+mins;
                        Calculated_Tat=hours+'.'+mins;
        
                    
                        var TatRow_hd=document.getElementById("ctl00_C1_gvSendTat_ctl0"+parseInt(i+1)+"_hdTat"); 
                        TatRow_hd.value=hours+':'+mins; 
                        
                        var r=document.getElementById("ctl00_C1_gvSendTat_ctl0"+parseInt(i+1)+"_ChkTAT"); 
                        hdnWithinTat=document.getElementById("ctl00_C1_gvSendTat_ctl0"+parseInt(i+1)+"_hdnWithinTAT");                     
                    }
                    else
                    {
                        var TatRow=document.getElementById("ctl00_C1_gvSendTat_ctl"+parseInt(i+1)+"_lblTat"); 
                        TatRow.innerText =hours+':'+mins;
                        Calculated_Tat=hours+'.'+mins;
                    
                        var TatRow_hd=document.getElementById("ctl00_C1_gvSendTat_ctl"+parseInt(i+1)+"_hdTat"); 
                        TatRow_hd.value=hours+':'+mins; 
                        
                        var r=document.getElementById("ctl00_C1_gvSendTat_ctl"+parseInt(i+1)+"_ChkTAT"); 
                        hdnWithinTat=document.getElementById("ctl00_C1_gvSendTat_ctl"+parseInt(i+1)+"_hdnWithinTAT");                     
                    }                  
                    
                    
                    if(parseFloat(StdTAT)>= parseFloat(Calculated_Tat))
                    {
                        
                        r.checked=true;
                        r.disabled = true;
                        hdnWithinTat.value=1;
                    }
                    else
                    {   
                        
                        r.checked=false;
                        r.disabled = false;
                        hdnWithinTat.value=0;
                    }             
                }       
            }   
            else
            {
                alert("Send Date should not be less then Received Date"); 
            }   
        }      
        else
        {
            alert('Please Select Send Date and Time');
        }
    }   
} 

function ChkAtLeastOne(source,arguments)
{        
        var flag;
        var gv=document.getElementById('<%=gvSendTat.ClientID %>');
        var n = document.getElementById('<%=gvSendTat.ClientID %>').rows.length;
        var i,j=0;
        for(i=2;i<=n;i++)
        {
            if(i<10)
            {
               var r=document.getElementById("ctl00_C1_gvSendTat_ctl0"+i+"_Chk");               
               if(r.checked)
               { 
                ++j; 
                flag=true;  
                break;              
               }
               else
               {
               flag=false;
               }              
            }                      
            else
            {
               var r=document.getElementById("ctl00_C1_gvSendTat_ctl"+i+"_Chk");               
               if(r.checked)
               { 
                 ++j; 
                 flag= true;
               }              
            }
        }
        if(j<1)
         {          
            flag= false;
         }
         arguments.IsValid=flag;
}

function Validation_CalculateTAT(source,arguments)
{        
        var flag;
        var gv=document.getElementById('<%=gvSendTat.ClientID %>');
        var n = document.getElementById('<%=gvSendTat.ClientID %>').rows.length;
        var TatHrs=gv.rows[0].cells[5].innerText;
        if(gv.rows[1].cells[5].innerText == " " ||gv.rows[1].cells[5].innerText==null)
           {                    
             flag=false;
            }
          else
            {
             flag= true;
            }
         arguments.IsValid=flag;
}


               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }



</script>
<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>   
<table id="tblMain" runat="server" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td></td><td>
<fieldset>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">  
    <tr>
        <td class="topbar" colspan="13" style="height: 35px">
            &nbsp;Send To Client</td>
    </tr>
    <tr>
        <td style="width: 37px; height: 17px;">
        </td>
        <td style="width: 115px; height: 17px;">
        </td>
        <td style="width: 334px; height: 17px;">
        </td>
        <td style="height: 17px; width: 140px;">
        </td>
        <td style="height: 17px; width: 91px;">
        </td>
        <td style="height: 17px; width: 273px;">
        </td>
    </tr>
<tr>
    <td class="reportTitleIncome" colspan="2" style="height: 46px">
        From Date:* 
    </td>
<td class="Info" style="width: 334px; height: 46px;"><asp:TextBox id="txtfromdate" runat="server" MaxLength="10" SkinID="txtSkin" Width="92px"></asp:TextBox>
    <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.png" />
    <asp:Label id="lblfromdateformate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label></td>
    <td style="width: 140px; height: 46px">
    </td>
<td class="reportTitleIncome" style="height: 46px">To Date:* </td>
<td class="Info" style="height: 46px; width: 273px;"><asp:TextBox id="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="98px"></asp:TextBox>
    <img id="Img4" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.png" />
    <asp:Label id="Label1" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label></td>
    <td style="height: 46px; width: 75px;">
        <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpSearch"/></td>
</tr>
    <tr>
        <td colspan="6">&nbsp;<asp:Label ID="lblMsg" ForeColor="Red" Font-Bold="True" runat="server" Visible="False" Width="616px"></asp:Label></td>
    </tr>
<tr>
<td colspan="6">
    <asp:Panel ID="pnlSendClient" runat="server" Width="100%" Visible="false">
    <table id="tblSendClient" runat="server" width="100%">
    <tr>
    <td colspan="6">
    <asp:GridView id="gvSendTat" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False" Width="100%" OnDataBound="gvSendTat_DataBound">
    <Columns>
        <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:CheckBox ID="Chk" runat="server" />
            </ItemTemplate>
            <HeaderTemplate>
                <asp:CheckBox ID="ChkAll" runat="server"  onClick="javascript:SelectAllCheckBox(this);" /><strong>Select All</strong>
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CaseId"   HeaderText="CaseId" ></asp:BoundField>
        <asp:BoundField DataField="REF_NO"   HeaderText="Reference No" ></asp:BoundField>
        <asp:BoundField DataField="APPLICANT_NAME"  HeaderText="Company Name" ></asp:BoundField>
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:BoundField DataField="REC_DATE" HeaderText="Received Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" HtmlEncode="False" ></asp:BoundField>
        <asp:BoundField DataField="TAT_HRS"  HeaderText="TAT" ></asp:BoundField>
        <asp:BoundField DataField="Centre_Name"  HeaderText="Centre" ></asp:BoundField>
        <asp:TemplateField HeaderText="Within TAT">
            <ItemTemplate>                
                <asp:CheckBox ID="ChkTAT" runat="server" onClick="funOnClickCheckbox(this)"/> 
                <asp:HiddenField ID="hdnWithinTat" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>    
    </td>
    </tr>
    <tr>
    <td colspan="6">
        <asp:Label ID="lblCount" runat="server" Visible="False" Font-Bold="True" Width="198px"></asp:Label>
        &nbsp; &nbsp;
        <asp:HiddenField ID="hdnStandardTAT" runat="server" />
        &nbsp;
    </td>
    </tr>
    <tr id="TRTAT" runat="server">
    <td class="reportTitleIncome" style="width: 612px"><asp:Label id="lblsenddate"  runat="server" SkinID="lblSkin" Text="Send Date" ></asp:Label>*</td>
    <td class="Info"><asp:TextBox id="txtSendDt" ReadOnly="true" runat="server" ValidationGroup="grpSend" MaxLength="10" SkinID="txtSkin"  CssClass="textbox"></asp:TextBox>&nbsp;
        <asp:Label id="lblsenddatefotmate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]" ></asp:Label>
    </td>
    <td class="reportTitleIncome" style="width: 1215px"><asp:Label id="lblsendtime" runat="server" SkinID="lblSkin" Text="Send Time "></asp:Label>*</td>
    <td class="Info" style="width: 225px">
    <asp:TextBox id="txtSendTm" ReadOnly="true" runat="server" ValidationGroup="grpSend" MaxLength="5" SkinID="txtSkin"  CssClass="textbox"></asp:TextBox>
    <asp:Label id="lblhourandminformate" runat="server" SkinID="lblSkin" Text="[hh:mm]" ></asp:Label>
    <asp:DropDownList id="ddlSendTimeType" runat="server" SkinID="ddlSkin" CssClass="combo" Enabled="false">
                       <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList></td>
        <td align="right">
    
    <input id="btnCalcTat" type="button" value="TatCalculation" onclick="funValidateSendToDate();"         
        style="border-color:#476085; border-style:solid; border-width:1px;font-family:Verdana;font-size:11px;font-weight:bold; visibility: visible;" disabled="disabled"/></td>
    <td align="right"  id="TD1" runat="server">
        &nbsp;<asp:Button ID="btnSentToClient" runat="server" SkinID="btnSendSkin" OnClick="btnSentToClient_Click" ValidationGroup="grpSend"/>&nbsp;
    </td>
    </tr>
    </table>  </asp:Panel>      
</td>        
</tr>

<tr><td style="height: 42px; width: 37px;"></td>
    <td style="width: 115px; height: 42px">
    </td>
    <td style="height: 42px; width: 334px;">
<asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtfromdate" Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None" ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtfromdate"
        Display="None" ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txttoDate"
            Display="None" ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpSearch"></asp:RegularExpressionValidator>    
    <asp:CustomValidator ID="cvDateSearch" runat="server" ClientValidationFunction="funValidateFromToDate"
        ControlToValidate="txtToDate" Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" 
    ShowSummary="False" ValidationGroup="grpSearch" />
        </td><td style="height: 42px; width: 140px;"></td><td style="height: 42px; width: 91px;">
    <br />
    <asp:CustomValidator ID="CustomValidatorChkAtLeastOne" runat="server" ClientValidationFunction="ChkAtLeastOne"
        Display="None" SetFocusOnError="True" ValidationGroup="grpSend"
        Width="117px" ErrorMessage="Select Case For Send To Client"></asp:CustomValidator><br />
    </td>
    <td style="height: 42px; width: 273px;" >
    </td>
</tr>
    <tr>
        <td style="width: 37px" >
        </td>
        <td style="width: 115px">
        </td>
        <td style="width: 334px" >

<asp:RequiredFieldValidator ID="reqValSendDate" runat="server" ControlToValidate="txtSendDt" Display="None" ErrorMessage="Please enter Send Date" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="reqValSendTime" runat="server" ControlToValidate="txtSendTm" Display="None" ErrorMessage="Please enter Send Time" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator>&nbsp;
    
<asp:RegularExpressionValidator ID="revSendDate" runat="server" ControlToValidate="txtSendDt" Display="None" 
    ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True" 
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"  ValidationGroup="grpSend"></asp:RegularExpressionValidator>
<asp:CustomValidator ID="cvDate" runat="server" ControlToValidate="txtToDate" ClientValidationFunction="funValidateFromToDate"
     Display="None" SetFocusOnError="True" ValidationGroup="grpSend"></asp:CustomValidator>


<asp:CustomValidator ID="cvSendDate" runat="server" ControlToValidate="txtSendDt" ClientValidationFunction="funValidateSendToDate"
     Display="None" SetFocusOnError="True"></asp:CustomValidator>
            <asp:RegularExpressionValidator ID="revSendTime" runat="server" ControlToValidate="txtSendTm"
                Display="None" ErrorMessage="Please enter valid Time Format for Send Time" SetFocusOnError="True"
                ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpSend"></asp:RegularExpressionValidator>&nbsp;

<asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtfromdate" Display="None" 
    ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True" 
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"  ValidationGroup="grpSend"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate" Display="None" 
    ErrorMessage="Please enter valid Time Format for Send Time" SetFocusOnError="True" 
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="grpSend"></asp:RegularExpressionValidator>

<asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="List" ShowMessageBox="True" 
    ShowSummary="False" ValidationGroup="grpSend" /> 
        </td>
        <td style="width: 140px" >
        </td>
        <td style="width: 91px" >
        </td>
        <td style="width: 273px" >
        </td>
    </tr>
</table>
</fieldset>
</td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
</table>


</asp:Content>

