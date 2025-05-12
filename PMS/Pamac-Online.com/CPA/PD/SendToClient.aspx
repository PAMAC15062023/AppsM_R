<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="SendToClient.aspx.cs" Inherits="CPA_PD_SendToClient" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function funValidateFromToDate()
{
    debugger;
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
    var holiday_grv =document.getElementById('<%=gvSendTat.ClientID%>');
     
    if(gv.Visible=true)
    {    
        
        var length=gv.rows.length; 
        var bFlag=true;
        var diff;       
        var StdTAT=document.getElementById('<%=hdnStandardTAT.ClientID%>').value;
        //Send Date --------
        //alert("StdTAT-->"+StdTAT); 
        var strSendDate = document.getElementById("<%=txtSendDt.ClientID%>").value;
         
        var strSendTime = document.getElementById("<%=txtSendTm.ClientID%>").value; 
                     
        var strSendType = document.getElementById("<%=ddlSendTimeType.ClientID%>").value;
          
             
        var SendDate=strSendDate + " " + strSendTime + " " + strSendType
        
        //===split and fill into array
        var arSendDate = SendDate.split('/');
        //var arSendTime = SendDate.split('');
            
        //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
        var strNewSendDate = arSendDate[1]+"/"+arSendDate[0]+"/"+arSendDate[2];
        //var strNewSendDate = arSendDate[0]+"/"+arSendDate[1]+"/"+arSendDate[2];
        var strSendDate1=new Date(strNewSendDate);
       //alert("strSendDate1"+strSendDate1); 
  
   
        if(strSendDate!="" && strSendTime!="")
        {
         
            var strSend= new Date();        
            for(i=1;i<length;i++)
            {
                //Received Date -------------
                var strRecdDate=gv.rows[i].cells[10].innerText;
                //===split and fill into array
                
                // alert("strRecdDate gv--"+strRecdDate); 
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
                   //alert("Case_Id-->"+Case_Id); 
                    //Received Date -------------
                var strRecdDate=gv.rows[i].cells[10].innerText;
                //===split and fill into array
                
                 //alert("strRecdDate-->"+strRecdDate); 
                var arRecdDate = strRecdDate.split('/');
                var arRecdTime = strRecdDate.split('');
            
               
               var strNewRecdDate = arRecdDate[1]+"/"+arRecdDate[0]+"/"+arRecdDate[2];     
     
                var strRecdDate1 =new Date(strNewRecdDate); 
                 //alert("strRecdDate1-->"+strRecdDate1); 
                    
                    //ADD By :Akanksha      
                                    
                  var s = new Date(strRecdDate1);
                  
                  var e = new Date(strSendDate1);
                  
                    var a = [];
                    
                     //alert("a-->"+a); 
                   
                    var l=0;
                    var m =0;
                  
                    //Holiday
                    if(holiday_grv!=null)
                        {
                         var rowcount=holiday_grv.rows.length;  
                          //alert("rowcount-->"+rowcount);                         
                          for(var h = 1; h < rowcount;h++)
                          {                       
                            var holiday_date = holiday_grv.rows[h].cells[0].innerText;
                            var hddat = holiday_date.split('/');
                            var hdTime = holiday_date.split('');
                            var hddate = hddat[1]+"/"+hddat[0]+"/"+hddat[2];     
                            var h_date =new Date(hddate); 
                                                      
                             if (h_date>=s && h_date<=e) 
                             { 
                              m++;
                             }
                          }
                          }
                    //Weekend
                    while(s <= e) 
                    {
                    a.push(s);
                    var j = s.getDay();
                    
                                        
                      if(j==0)//only for SunDay
                      {
                     l++;
                      }                                 
                     s = new Date(s.setDate(s.getDate() + 1));
                      
            }

                diff=Math.abs(strSendDate1.getTime())- Math.abs(strRecdDate1.getTime());
                    
                
                
                    var hours = Math.floor(diff / (1000 * 60 * 60)); 
                   
                  
                    l=l*24;
                      
                    m=m*24;
                        
                    if(l>0)
                    {
                    hours=hours-l;
                  
                    }
                    if(m>0)
                    {
                     hours=hours-m;
                     
                    }
                    
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
                        hdnWithinTat.value=m;
                       
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

//--comp--//








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


function Validate()
{
    var ErrorMsg="";
    var ReturnValue=true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var ddlcenter = document.getElementById("<%=ddlcenter.ClientID%>");
        
    if(ddlcenter.selectedIndex == 'A')
    {
        ErrorMsg = "Please Select Centre.";
        ReturnValue = false;
        ddlcenter.focus();
    }
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}

</script>

<asp:Panel ID="pnlgrdTele" runat="server"  Width="800px"> 
<table style="width: 800px; height: 379px;">
     <tr>
        <td class="tta" colspan="5" style="width: 800px;">
            <span style="font-size: 10pt">SEND TO CLIENT</span></td>  <%--height: 19px;--%> 
    </tr>
    <tr>
        <td colspan="6" style="width: 800px; height: 21px;">
            <asp:Label runat="server" ID="lblMsg"  SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="688px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="reportTitleIncome" style="width: 164px; height: 16px">
            <strong>&nbsp;Cluster Name</strong></td>
        <td class="Info" style="width: 92px; height: 16px">
            <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                SkinID="ddlSkin" Width="120px" ValidationGroup="grpSearch">
            </asp:DropDownList></td>
        <td class="reportTitleIncome" style="width: 193px; height: 16px">
            <strong>Centre</strong></td>
        <td class="Info" style="width: 123px; height: 16px">
            <asp:DropDownList ID="ddlcenter" runat="server" SkinID="ddlSkin" Width="120px">
            </asp:DropDownList></td>
    </tr>

    <tr>
        <td style="width: 110px; height: 11px;" class="reportTitleIncome">
            <strong>From Date</strong></td>
        <td style="width: 110px; height: 11px;" class="Info">
            <asp:TextBox ID="txtfromdate" runat="server" MaxLength="10" SkinID="txtSkin" Width="70px"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" /></td>
        <td style="width: 110px; height: 11px;"  class="reportTitleIncome">
            <strong>To Date</strong></td>
        <td style="width: 110px; height: 11px;"  class="Info">
            <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="70px"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" /></td>
    </tr>
    <tr>
       <td style="width: 110px; height: 1px;" class="Info" colspan="4">
           <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin"  ValidationGroup="grpSearch" OnClick="btnSearch_Click" Text="Serach"/>  </td>
    </tr>
    <tr>
    <td colspan="5" style="height: 306px">
        <asp:Panel ID="pnlSendClient" runat="server" Width="100%" Visible="false">
        <table id="tblSendClient" runat="server" width="100%">
        <tr>
        <td colspan="6" style="height: 107px">
            &nbsp;<asp:GridView ID="gvSendTat" runat="server" AutoGenerateColumns="False" OnDataBound="gvSendTat_DataBound"
                SkinID="gridviewSkin" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="Chk" runat="server" />&nbsp;
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="ChkAll" runat="server" onClick="javascript:SelectAllCheckBox(this);" /><strong>Select All</strong>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="case_id" HeaderText="Case ID" SortExpression="case_id" />
                    <asp:BoundField DataField="File_Ref_No" HeaderText="File_Ref_No" />
                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer_Name" />
                    <asp:BoundField DataField="Company_Name" HeaderText="Company_Name" />
                    <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact_Person_Name" />
                    <asp:BoundField DataField="Contact_Number" HeaderText="Contact_Number" />
                    <asp:BoundField DataField="pamac_location" HeaderText="pamac_location" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation_Date" />
                      <asp:BoundField DataField="Add_date" HeaderText="Rec_Date" />
                    <asp:BoundField DataField="cluster_id" HeaderText="cluster" />
                    <asp:TemplateField HeaderText="Tat Hours">
                        <ItemTemplate>
                            <asp:Label ID="lblTat" runat="server" Text='<%# Bind("TAT_HRS") %>' Width="103px"></asp:Label>
                            <asp:HiddenField ID="hdTat" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Within TAT">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkTAT" runat="server" onClick="funOnClickCheckbox(this)" />
                            <asp:HiddenField ID="hdnWithinTat" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        </tr>
        <tr>
        <td colspan="6" style="height: 36px">
            <asp:Label ID="lblCount" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        
        <%--SANKET--%>
        </table>  
            <table id="Table1" runat="server" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblsenddate" runat="server" SkinID="lblSkin" Text="Send Date" Width="70px"></asp:Label>*</td>
                    <td style="width: 106px">
                        <asp:TextBox ID="txtSendDt" runat="server" CssClass="textbox" MaxLength="10" ReadOnly="true"
                            SkinID="txtSkin" ValidationGroup="grpSend" Width="93px"></asp:TextBox>
                        <asp:Label ID="lblsenddatefotmate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblsendtime" runat="server" SkinID="lblSkin" Text="Send Time "></asp:Label>*</td>
                    <td>
                        <asp:TextBox ID="txtSendTm" runat="server" CssClass="textbox" MaxLength="5" ReadOnly="true"
                            SkinID="txtSkin" ValidationGroup="grpSend" Width="79px"></asp:TextBox>
                        <asp:Label ID="lblhourandminformate" runat="server" SkinID="lblSkin" Text="[hh:mm]"></asp:Label>
                        <asp:DropDownList ID="ddlSendTimeType" runat="server" CssClass="combo" Enabled="false"
                            SkinID="ddlSkin">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="right">
                        <input id="btnCalcTat" onclick="funValidateSendToDate();" style="border-right: #476085 1px solid;
                            border-top: #476085 1px solid; font-weight: bold; font-size: 11px; visibility: visible;
                            border-left: #476085 1px solid; border-bottom: #476085 1px solid; font-family: Verdana"
                            type="button" value="TatCalculation" validationgroup="grpSend"  /></td>
                    <td id="TD1" runat="server" align="right">
                        &nbsp;<asp:Button ID="btnSentToClient" runat="server" 
                         OnClick="btnSentToClient_Click" SkinID="btnSendSkin" Font-Bold="True" Text="SendToClient" />&nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>      
    </td>   
    </tr>
    <tr>
        <td style="height: 55px;" colspan="2">
        <asp:RequiredFieldValidator ID="reqddlCluster" runat="server" ControlToValidate="ddlclustername" Display="None"
            ErrorMessage="Please select Cluster" SetFocusOnError="True" ValidationGroup="grpSearch" InitialValue="0"></asp:RequiredFieldValidator>
        
            <asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtfromdate"
                Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True"
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                    ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None"
                    ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="revFromDateSearch" runat="server" ControlToValidate="txtfromdate" Display="None"
                        ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpSearch"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                            ID="revToDateSearch" runat="server" ControlToValidate="txttoDate" Display="None"
                            ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpSearch"></asp:RegularExpressionValidator><asp:CustomValidator
                                ID="cvDateSearch" runat="server" ClientValidationFunction="funValidateFromToDate"
                                ControlToValidate="txtToDate" Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator><asp:RequiredFieldValidator
                                    ID="reqValSendDate" runat="server" ControlToValidate="txtSendDt" Display="None"
                                    ErrorMessage="Please enter Send Date" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                        ID="reqValSendTime" runat="server" ControlToValidate="txtSendTm" Display="None"
                                        ErrorMessage="Please enter Send Time" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revSendDate" runat="server" ControlToValidate="txtSendDt" Display="None"
                                            ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                            ValidationGroup="grpSend"></asp:RegularExpressionValidator><asp:CustomValidator ID="cvDate"
                                                runat="server" ClientValidationFunction="funValidateFromToDate" ControlToValidate="txtToDate"
                                                Display="None" SetFocusOnError="True" ValidationGroup="grpSend"></asp:CustomValidator><asp:CustomValidator
                                                    ID="cvSendDate" runat="server" ClientValidationFunction="funValidateSendToDate"
                                                    ControlToValidate="txtSendDt" Display="None" SetFocusOnError="True"></asp:CustomValidator><asp:RegularExpressionValidator
                                                        ID="revSendTime" runat="server" ControlToValidate="txtSendTm" Display="None"
                                                        ErrorMessage="Please enter valid Time Format for Send Time" SetFocusOnError="True"
                                                        ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpSend"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                                            ID="revFromDate" runat="server" ControlToValidate="txtfromdate" Display="None"
                                                            ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                                            ValidationGroup="grpSend"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                                                ID="revToDate" runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please enter valid Time Format for Send Time"
                                                                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                                                ValidationGroup="grpSend"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="grpSearch" />
            <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="grpSend" />
        </td>
        <td style="height: 55px;" colspan="3">
            <asp:CustomValidator ID="CustomValidatorChkAtLeastOne" runat="server" ClientValidationFunction="return ChkAtLeastOne()"
                Display="None" ErrorMessage="Select Case For Send To Client" SetFocusOnError="True"
                ValidationGroup="grpSend" Width="117px"></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidator_TatCalculation" runat="server" ClientValidationFunction="Validation_CalculateTAT"
                Display="None" ErrorMessage="First Calculate TAT" ValidationGroup="grpSend" Width="158px"
                SetFocusOnError="True" ></asp:CustomValidator>
            
            <asp:HiddenField ID="hdnStandardTAT" runat="server" />
            </td>

    </tr>
</table>

</asp:Panel>  

 
</asp:Content>

