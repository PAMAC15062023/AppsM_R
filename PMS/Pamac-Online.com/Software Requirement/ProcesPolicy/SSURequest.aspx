<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master" AutoEventWireup="true" CodeFile="SSURequest.aspx.cs" Inherits="Software_Requirement_Software_SSURequest" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
   <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

   <script language="JAVASCRIPT" type="text/javascript"> 

{
  
    var strFromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
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
    
       if ( parseInt(dateDiff) <= 1) 
    {
         alert("Required Date should not be less then Requested  Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  
   
   
   function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
   
function Validate()
{  
    var ErrorMessage='';
    var ReturnValue=true;
    var Lblmsg=document.getElementById("<%=Lblmsg.ClientID%>")       
    var ddlvertical = document.getElementById("<%=ddlvertical.ClientID%>")
    var ddlverticalHead = document.getElementById("<%=ddlverticalHead.ClientID%>")
    var ddlreqtype = document.getElementById("<%=ddlreqtype.ClientID%>")
    var ddlrequirement = document.getElementById("<%=ddlrequirement.ClientID%>")
    var txtproblem= document.getElementById("<%=txtproblem.ClientID%>")
    var txtSuggestion = document.getElementById("<%=txtSuggestion.ClientID%>")
    
        if (txtSuggestion.value =='')       
        { 
             ErrorMessage='Please Enter The Suggestion!';
             ReturnValue=false; 
             txtSuggestion.focus();
        }   
     
        if (txtproblem.value =='')       
        { 
             ErrorMessage='Please Enter The Problem!';
             ReturnValue=false; 
             txtproblem.focus();
        }   
        
        if(ddlrequirement.selectedIndex == '0')
        {
            ErrorMessage = "Please Select Requirements  to continue.";
            ReturnValue = false;
            ddlrequirement.focus();
        }
  
       if(ddlreqtype.selectedIndex == '0')
        {
            ErrorMessage = "Please Select Requirement Type to continue.";
            ReturnValue = false;
            ddlreqtype.focus();
        }
  
       if(ddlverticalHead.selectedIndex == '0')
        {
            ErrorMessage = "Please Select Vertical Head to continue.";
            ReturnValue = false;
            ddlverticalHead.focus();
        }
  
      if(ddlvertical.selectedIndex == '0')
        {
            ErrorMessage = "Please Select Vertical to continue.";
            ReturnValue = false;
            ddlvertical.focus();
        }
           
        
     window.scrollTo(0,0);    
     Lblmsg.innerText=ErrorMessage;
     return ReturnValue;
}  

    
    </script>
   
   
    <asp:Panel ID="Pnlmain" runat="server" Width="900px"> 
    <table style="width: 700px; ">
            <tr>
            <td class="tta" colspan="6" style="width: 711px">
                <strong>Software Development Requirement 
          </strong></td>
               
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; width: 711px;">
                <asp:Label ID="Lblmsg" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblTicketNo" runat="server" ForeColor="Red" SkinID="lblError"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; width: 711px;">
           <asp:LinkButton ID="lnkststus" runat="server" Font-Bold="True" PostBackUrl="~/Software Requirement/Software/SSU_Status.aspx" Font-Size="Small" ForeColor="DeepSkyBlue">All Request Status</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="width: 249px" class="reportTitleIncome">
                <strong>
                Employee Code</strong></td>
            <td class="Info" colspan="3">
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" AutoPostBack="True" OnTextChanged="txtEmpCode_TextChanged" Width="150px"></asp:TextBox></td>
<%--            <td style="width: 3px" colspan="2" rowspan="8">
            </td>--%>
        </tr>
        <tr>
            <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                <strong>
                First Name</strong></td>
            <td style="width: 234px; height: 22px;" class="Info">
                <asp:TextBox ID="txtfirstname" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td style="width: 315px; height: 22px;" class="reportTitleIncome">
                <strong>
                Last Name</strong></td>
            <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtLastName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 22px;">
                <strong>
                Centre Name</strong></td>
            <td class="Info" style="width: 234px; height: 22px;">
                <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="true" SkinID="ddlSkin" Width="155px"   >
                </asp:DropDownList></td>
            <td style="width: 315px; height: 22px;" class="reportTitleIncome">
                <strong>
                Subcentre Name</strong></td>
            <td style="width: 104px; height: 22px;" class="Info">
                <asp:DropDownList ID="ddlsubcentre" runat="server" SkinID="ddlSkin" Width="155px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px">
                <strong>Vertical</strong></td>
            <td class="Info" style="width: 234px">
                <asp:DropDownList ID="ddlvertical" runat="server" SkinID="ddlSkin" OnSelectedIndexChanged="ddlvertical_SelectedIndexChanged"
                    Width="155px" AutoPostBack="True" ValidationGroup="grpSearch" >
                </asp:DropDownList></td>
            <td style="width: 315px" class="reportTitleIncome">
                <strong>
                Vertical Head</strong></td>
            <td style="width: 104px" class="Info">
                <asp:DropDownList ID="ddlverticalHead" runat="server" SkinID="ddlSkin" Width="155px">
                   
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>
                Request Date</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch"  Width="71px" ReadOnly="True"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /><br />
                [dd/mm/yyyy]</td>
            <td style="width: 315px; height: 23px" class="reportTitleIncome">
                <strong>
                To be required till date</strong></td>
            <td style="width: 104px; height: 23px" class="Info">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch" Width="71px"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /><br />
                [dd/mm/yyyy]</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>Application</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:DropDownList ID="ddlapplication" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>PMS</asp:ListItem>
                    <asp:ListItem>CALCULUS</asp:ListItem>
                    <asp:ListItem>TEAMSPACE</asp:ListItem>
                    <asp:ListItem>RSP</asp:ListItem>
                    <asp:ListItem>PAMAC WEBSITE</asp:ListItem>
                    <asp:ListItem>BDDOMESTIC</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 315px; height: 23px">
                <strong>
                Priority</strong></td>
            <td class="Info" style="width: 104px; height: 23px">
                <asp:DropDownList ID="ddlpriority" runat="server" SkinID="ddlSkin" Width="160px">
                    <asp:ListItem Value="3">Low</asp:ListItem>
                    <asp:ListItem Value="2">Medium</asp:ListItem>
                    <asp:ListItem Value="1">High</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>
                Requirement Type</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:DropDownList ID="ddlreqtype" runat="server" AutoPostBack="True" SkinID="ddlSkin" Width="155px" OnSelectedIndexChanged="ddlreqtype_SelectedIndexChanged"  ValidationGroup="grpSearch">
               
                     <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Software</asp:ListItem>
                    <asp:ListItem Value="2">Others</asp:ListItem>
   
                    
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 315px; height: 23px">
                <strong>
                Requirements</strong></td>
            <td class="Info" style="width: 104px; height: 23px">
                <asp:DropDownList ID="ddlrequirement" runat="server" AutoPostBack="true" SkinID="ddlSkin" Width="158px" OnSelectedIndexChanged="ddlrequirement_SelectedIndexChanged">
                
                
                
                
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>Deployement In</strong></td>
            <td class="Info" colspan="3" style="height: 23px; width: 234px;">
                <asp:DropDownList ID="ddllocations" runat="server" SkinID="ddlSkin" Width="155px" ValidationGroup="grpSearch" >
             
                    <asp:ListItem Value=" PANINDIA locations">PAN INDIA Locations</asp:ListItem>
                    <asp:ListItem>PMS BVU</asp:ListItem>
                    <asp:ListItem>PMS NORTH</asp:ListItem>
                    <asp:ListItem>PMS EAST</asp:ListItem>
                    <asp:ListItem>PMS SOUTH</asp:ListItem>
                    <asp:ListItem>PMS WEST</asp:ListItem>
                    <asp:ListItem>PMS DUBAI</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        </table>
       </asp:Panel>
       
       
          <asp:Panel ID="Pnlclientadd" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 181px; height: 23px" >
                <strong>Activity</strong></td>
            <td class="Info" style="width: 172px; height: 23px">
                <asp:DropDownList ID="ddlclientactivity" runat="server" AutoPostBack="true" SkinID="ddlSkin"  ddSkinID="ddlSkin"  Width="160px" OnSelectedIndexChanged="ddlclientactivity_SelectedIndexChanged">
                 
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 203px; height: 23px">
                <strong>Product
                </strong></td>
            <td class="Info" style="width: 93px; height: 23px">
                <asp:DropDownList ID="ddlclientproduct" runat="server" AutoPostBack="False"  SkinID="ddlSkin" Width="160px" >
                    
                </asp:DropDownList></td>
                
              <tr>    
            <td class="reportTitleIncome" style="width: 181px ; height: 23px">
                <strong>Client
                </strong></td>
         
                
               <td style="height: 22px;" class="Info" colspan="3">
                <asp:TextBox ID="txtclientadd" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>   
    
    
        <asp:Panel ID="pnlpassword" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 156px; height: 23px" >
                <strong>Employee Name</strong></td>
           <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtemp_name" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>

      
            <td class="reportTitleIncome" style="width: 203px; height: 23px">
                <strong>Emp code
                </strong></td>
             <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtemp_code" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>

                
              </tr>   
              <tr> 
            <td class="reportTitleIncome" style="width: 156px ; height: 23px">
                <strong>Location
                </strong></td>
         
                
               <td style="height: 22px;" class="Info" colspan="3">
                <asp:TextBox ID="txtemp_location" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>   
    
    <asp:Panel ID="pnlrightasiignment" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 181px; height: 23px" >
                <strong>Activity</strong></td>
            <td class="Info" style="width: 172px; height: 23px">
                <asp:DropDownList ID="ddlrightactivity" runat="server" AutoPostBack="true" SkinID="ddlSkin"  ddSkinID="ddlSkin" Width="160px" OnSelectedIndexChanged="ddlrightactivity_SelectedIndexChanged">
                 
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 203px; height: 23px">
                <strong>Product
                </strong></td>
            <td class="Info" style="width: 104px; height: 23px">
                <asp:DropDownList ID="ddlrightproduct" runat="server" AutoPostBack="True"  SkinID="ddlSkin" Width="160px" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged">
                    
                </asp:DropDownList></td>
                
              <tr>    
            <td class="reportTitleIncome" style="width: 181px ; height: 23px">
                <strong>Emp code
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtempployeecode" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                
                   <td class="reportTitleIncome" style="width: 165px ; height: 23px">
                <strong>Assign Right details
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtrightdetails" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>

            </tr>
        </table>
    </asp:Panel>   
    
    <asp:Panel ID="Pnldomain" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 144px ; height: 23px">
                <strong>Emp code
                </strong></td>
         
                
               <td style="width: 104px; height: 23px;" class="Info">
                <asp:TextBox ID="txtempdomanicode" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                
                <td class="reportTitleIncome" style="width: 165px ; height: 23px">
                <strong>Emp Name
                </strong></td>
         
                
               <td style="width: 104px; height: 23px;" class="Info">
                <asp:TextBox ID="txtdomainempname" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                
          </tr>
                
              <tr>    
            <td class="reportTitleIncome" style="width: 144px ; height: 23px">
                <strong>Emp Email ID
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtdomainemail" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                
                   <td class="reportTitleIncome" style="width: 165px ; height: 23px">
                <strong> Domain
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtdomainname" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>

            </tr>
        </table>
    </asp:Panel>   
    
    
     <asp:Panel ID="pnlautoreply" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 263px ; height: 23px">
                <strong>Emp code
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtempcodeautoreply" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                
                <td class="reportTitleIncome" style="width: 165px ; height: 23px">
                <strong> Auto Reply Remark
                </strong></td>
         
                
               <td style="width: 104px; height: 22px;" class="Info">
                <asp:TextBox ID="txtautoreplyremerk" runat="server" SkinID="txtSkin" TextMode="MultiLine"   Width="150px"></asp:TextBox></td>
                
          </tr>
                
              <tr>    
            <td class="reportTitleIncome" style="width: 263px ; height: 23px">
                <strong>Start From</strong></td>
         
                
              <td class="Info" style="width: 234px; height: 23px">
                <asp:TextBox ID="txtstartfrom" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch"  Width="71px"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtstartfrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /><br />
                [dd/mm/yyyy]</td>
                   <td class="reportTitleIncome" style="width: 165px ; height: 23px">
                <strong> End To</strong></td>
         
                
               <td class="Info" style="width: 234px; height: 23px">
                <asp:TextBox ID="txtendto" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch"  Width="71px"></asp:TextBox><img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtendto.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /><br />
                [dd/mm/yyyy]</td>
            </tr>
        </table>
    </asp:Panel>   
    
    
    


      
       <asp:Panel ID="pnlStatus" runat="server" Width="701px"> 
       <table  style="width: 698px; "   >
             <tr>
               <td class="reportTitleIncome" style="width: 178px; height: 23px" >
                <strong>Activity</strong></td>
            <td class="Info" style="width: 172px; height: 23px">
                <asp:DropDownList ID="ddlactivity" runat="server" AutoPostBack="true" SkinID="ddlSkin" OnSelectedIndexChanged="ddlactivity_SelectedIndexChanged" ddSkinID="ddlSkin" Width="160px">
                 
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 203px; height: 23px">
                <strong>Product
                </strong></td>
            <td class="Info" style="width: 93px; height: 23px">
                <asp:DropDownList ID="ddlproduct" runat="server" AutoPostBack="True"  SkinID="ddlSkin" Width="160px" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged">
                    
                </asp:DropDownList></td>
                
              <tr>    
            <td class="reportTitleIncome" style="width: 178px ; height: 23px">
                <strong>Client
                </strong></td>
            <td class="Info" style="width: 180px; height: 23px" colspan="3">
                <asp:DropDownList ID="ddlclient" runat="server" SkinID="ddlSkin" Width="160px">
                </asp:DropDownList></td>

            </tr>
        </table>
    </asp:Panel>   
            
   
            
         

        

      
       <asp:Panel ID="Pnlclient" runat="server" Width="900px"> 
       <table style="width: 700px; " >
       <tr>
       

            <td style="width: 151px; height: 21px;" class="reportTitleIncome">
                <strong>Process Flow</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="290px" /></td>
          </tr>
      
           <tr>
            <td class="reportTitleIncome" style="width: 151px; height: 21px">
                <strong>Import / Export</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload2" runat="server" SkinID="flup" Width="290px" /></td>
              </tr>
              
              
                    <tr>
  
            <td class="reportTitleIncome" style="width: 151px; height: 21px">
                <strong>MIS Tracker</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload3" runat="server" SkinID="flup" Width="290px" /></td>
          
                   </tr>
                   <tr>
            <td class="reportTitleIncome" style="width: 151px; height: 21px">
                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                    <font color="#000080"><span style="font-size: 8pt; width: 430px; color: black; height: 21px">
                        <strong>
                        Technical
                Problem / Issues in the Application</strong></span></font></p>
            </td>
               
            <td colspan="3" style="height: 21px" class="Info">
                <asp:TextBox ID="txtproblem" runat="server" Height="44px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="400px" ></asp:TextBox></td>
           </tr>
           <tr>
            <td style="width: 151px; height: 21px;" class="reportTitleIncome">
                <span style="font-size: 8pt; color: #000000; font-family: Tahoma; background-color: #e1e9ff;">
                    <strong>Requirement / Remark</strong></span></td>
            <td colspan="3" style="height: 21px" class="Info">
                <asp:TextBox ID="txtSuggestion" runat="server" SkinID="txtSkin" Height="44px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
        

        </tr>
          
        <tr>
            <td style="height: 21px; width : 249px "  class="Info" colspan="4" align="center">
               
                &nbsp; &nbsp;<asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" SkinID="btn" Text="Save"  ValidationGroup="grpSearch"
                    Width="100px" />
                &nbsp;
                <asp:Button ID="BtnReset" runat="server" SkinID="btn" Text="Reset" Width="100px" OnClick="BtnReset_Click"/>
                &nbsp;&nbsp; &nbsp;
            </td>
        </tr>
       

   
        </table>
           </asp:Panel>   
            
   
            
         

        
       
        
        
        
        
      <%--  <tr>
            <td style="height: 21px; width : 249px "  class="Info" colspan="4" align="center">
               
                &nbsp; &nbsp;<asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" SkinID="btn" Text="Save" ValidationGroup="grpSearch"
                    Width="100px" />
                &nbsp;
                <asp:Button ID="BtnReset" runat="server" SkinID="btn" Text="Reset" Width="100px" />
                &nbsp;&nbsp; &nbsp;
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
       --%>


     <asp:Panel ID="Palgrid" runat="server"  ScrollBars="Both" Width="924px" Height="287px"  > 
  <table style="width: 700px; " >
  
   <tr>
            <td colspan="8" style="width: 391px; height: 211px;">
                &nbsp;&nbsp;
                <asp:GridView ID="grdGrid" runat="server"   SkinID="gridviewSkin" OnRowDataBound="grdGrid_RowDataBound">
                
                 
           <Columns>
                
                   <asp:TemplateField>
                        <ItemTemplate>
                                  <asp:LinkButton ID="lnkClose" runat="server"  Text="UAT Confirmation" OnClick="lnkClose_Click"/>
                           </ItemTemplate>
                   </asp:TemplateField>
                   
                   </Columns>
                
                   <Columns>
                   
              <asp:TemplateField HeaderText="Remark">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtNewRemark" runat="server" SkinID="txtSkin" TextMode="SingleLine" Width="100px" ></asp:TextBox>
                               </ItemTemplate>
                          </asp:TemplateField>
           
        
             </Columns>
  
           
  
           
           
           
           
         <Columns>
        
          
              <asp:TemplateField HeaderText="Download">
           <ItemTemplate>
                <asp:LinkButton ID="lnkdownload" runat="server"   CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Developer Attchment")%>'
                 OnClick="lnkdownload_Click"  CommandName="download" ><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
           </ItemTemplate>
           </asp:TemplateField>
           </Columns>
                
                </asp:GridView>
            </td>
        </tr>
 
  
  
  </table>
  </asp:Panel>

  
  <%--  added by abhijeet--%>

   
   
  
<%--  ended by abhijeet--%>
                
                

   
     <asp:RequiredFieldValidator ID="reqCentre" runat="server" ControlToValidate="ddlcentre"
                Display="None" ErrorMessage="Please Select Centre." SetFocusOnError="True" InitialValue="A" 
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>    
                
            <asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtFromDate"
                Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True"
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
                
             <asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None"
                    ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
                    
              <asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtFromDate" Display="None"
                        ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
                        
              <asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txtToDate" Display="None"
                            ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
                            
              <asp:CustomValidator ID="cvDateSearch" runat="server" ClientValidationFunction="funValidateFromToDate"
                   ControlToValidate="txtToDate" Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator>        
        
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="grpSearch" />  
   
   
   <asp:CustomValidator ID="CVCcompany"
    runat="server" ErrorMessage="Please select the vertical " 
    ClientValidationFunction="ClientValidate" ControlToValidate="ddlvertical" 
    Display="None" SetFocusOnError="True" ValidationGroup="grpSearch"></asp:CustomValidator>
    
    
    
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlvertical"
                Display="None" ErrorMessage="Please select the vertical." SetFocusOnError="True" InitialValue="--Select--" 
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>    
   
 
</asp:Content>

