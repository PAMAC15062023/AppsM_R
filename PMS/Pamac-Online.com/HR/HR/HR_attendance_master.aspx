<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_attendance_master.aspx.cs" Inherits="HR_HR_HR_attendance_master" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script language="javascript" type="text/javascript">
 function WidowOpen()   

{

           debugger;
        
            var strMessage="";
            var strstdINtime=document.getElementById("<%=ddltime.ClientID%>").value;            
            var strstdOutime=document.getElementById("<%=ddt_st_out.ClientID%>").value;             
            var strdevintimeoone=document.getElementById("<%=ddlDev_in_time1.ClientID%>").value;            
            var strdevintimetwo=document.getElementById("<%=dlDev_in_time2.ClientID%>").value;            
            var strdevouttime=document.getElementById("<%=ddl_Dev_out_time.ClientID%>").value;
            var strpenintime=document.getElementById("<%=ddl_time.ClientID%>").value;
            var strpenouttime=document.getElementById("<%=ddl_pen_out.ClientID%>").value;
            var strexecintimeone=document.getElementById("<%=exem_time1.ClientID%>").value;
            var strexecintimetwo=document.getElementById("<%=exem_time2.ClientID%>").value;
            var strexecouttime=document.getElementById("<%=exem_time3.ClientID%>").value;
            var strempcode=document.getElementById("<%=txtsearch.ClientID%>").value;
            
            if(strempcode=="")
           {
           alert("Please enter the Empolyee Code");
            strempcode.focus();
           } 
                    
            if(strstdINtime=="0")
           {
           alert("Please select the value of Standard IN Time");
            strstdINtime.focus();
           } 
                     
            if(strstdOutime=="0")
           {           
           alert("Please select the value of  Standard OutTime");
             strstdOutime.focus();            
           }    
                  
           if(strexecintimeone=="" )
            {
            alert("Please enter the Exemption for In Time by (default)values");
            strexecintimeone.focus();
            }
            if(strexecintimetwo=="" )
            {
             alert("Please enter the Exemption for  In time( basis of DCH approal) values");
           strexecintimetwo.focus();
           }
           if(strexecouttime=="" )
            {
             alert("Please enter the Exemption for out time values");
           strexecintimetwo.focus();
           }
           
            if(strdevintimeoone=="0")
           {
           alert("Please select the value of Devation In Time 1");
             strdevintimeoone.focus();
           }
           
           if(strdevintimetwo=="0")
           {
            alert("Please select the value of Devation In Time 2");
            strdevintimetwo.focus();
           }
           
           if(strdevouttime=="0")
           {
           salert("Please select the value of Devation Out Time");
            strdevouttime.focus();
           }
           
           if(strpenintime=="0")
           {
           alert("Please select the value of Penlty In Time");
            strpenintime.focus();
           }
           if(strpenouttime=="0")
           {
             alert("Please select the value of Penlty Out Time");
             strpenouttime.focus();
           }         
    }

</script> 

<asp:Panel ID="pnlhr" runat="server" Height="692px" Width="883px">

<fieldset style="width: 841px; height: 587px" >
<legend class="FormHeading">HR Attendance Entry</legend>  
    <table id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 275px; height: 35px">
            </td>
            <td style="width: 302px; height: 35px">
                <asp:Label ID="lblmsg" runat="server" Text="Label" ForeColor="red" Visible="false"></asp:Label></td>
            <td style="width: 138px; height: 35px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 35px">
                <asp:Label ID="lblsearch" runat="server" Text="Please Entre Code:"></asp:Label></td>
            <td style="width: 302px; height: 35px">
                <asp:TextBox ID="txtsearch" runat="server" Width="211px"></asp:TextBox></td>
            <td style="width: 138px; height: 35px">
                &nbsp;<asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search" ValidationGroup="validnumbers" /></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
               <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
            <td style="width: 302px; height: 30px">
                <asp:TextBox ID="txtname" runat="server" ReadOnly="true" Width="213px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
                <asp:Label ID="lblenm_code" runat="server" Text="Employee Code"></asp:Label></td>
            <td style="width: 302px; height: 30px">
                <asp:TextBox ID="txtcode" runat="server" ReadOnly="true" Width="210px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsearch"
                    Display="None" ErrorMessage="Please Enter the Employee Code" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
                <asp:Label ID="lblcentre" runat="server" Text="Center"></asp:Label></td>
            <td style="width: 302px; height: 30px">
               <asp:TextBox ID="txtcentre" runat="server" ReadOnly="true" Width="208px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
                <asp:Label ID="lblsubcentre" runat="server" Text="Subcentre"></asp:Label></td>
            <td style="width: 302px; height: 30px">
                <asp:TextBox ID="txtsubcentre" runat="server" ReadOnly="true" Width="206px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
                <asp:Label ID="lblunit" runat="server" Text="Unit"></asp:Label></td>
            <td style="width: 302px; height: 30px">
                <asp:TextBox ID="txtunit" runat="server" ReadOnly="true" Width="206px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
                <asp:Label ID="lbldesign" runat="server" Text="Designation"></asp:Label></td>
            <td style="width: 302px; height: 30px">
           <asp:TextBox ID="txtdesign" runat="server" ReadOnly="true" Width="204px"></asp:TextBox></td>
            <td style="width: 138px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 28px">
            <asp:Label ID="lbltime" runat="server" Text="Standard In time"></asp:Label></td>
            <td style="width: 302px; height: 28px">
            
            <asp:DropDownList ID="ddltime" runat="server">
          <%--  <asp:ListItem Value="0">--Select--</asp:ListItem>  --%>      
        <asp:ListItem>01:00:00</asp:ListItem>
        <asp:ListItem>01:30:00</asp:ListItem>
        <asp:ListItem>02:00:00</asp:ListItem>
        <asp:ListItem>02:30:00</asp:ListItem>
        <asp:ListItem>03:00:00</asp:ListItem>
        <asp:ListItem>03:30:00</asp:ListItem>
        <asp:ListItem>04:00:00</asp:ListItem>
        <asp:ListItem>04:30:00</asp:ListItem>
         <asp:ListItem>05:00:00</asp:ListItem> 
         <asp:ListItem>05:30:00</asp:ListItem>
         <asp:ListItem>06:00:00</asp:ListItem>
         <asp:ListItem>06:30:00</asp:ListItem>
         <asp:ListItem>07:00:00</asp:ListItem>
         <asp:ListItem>07:30:00</asp:ListItem>
         <asp:ListItem>08:00:00</asp:ListItem>
         <asp:ListItem>08:30:00</asp:ListItem>
         <asp:ListItem>09:00:00</asp:ListItem>
         <asp:ListItem>09:30:00</asp:ListItem>
         <asp:ListItem>10:00:00</asp:ListItem>
         <asp:ListItem>10:30:00</asp:ListItem>
         <asp:ListItem>11:00:00</asp:ListItem>
         <asp:ListItem>11:30:00</asp:ListItem>         
         <asp:ListItem>12:00:00</asp:ListItem>
         <asp:ListItem>12:30:00</asp:ListItem>
         
         <asp:ListItem>13:00:00</asp:ListItem>
        <asp:ListItem>13:30:00</asp:ListItem>
        <asp:ListItem>14:00:00</asp:ListItem>
        <asp:ListItem>14:30:00</asp:ListItem>
        <asp:ListItem>15:00:00</asp:ListItem>
        <asp:ListItem>15:30:00</asp:ListItem>
        <asp:ListItem>16:00:00</asp:ListItem>
        <asp:ListItem>16:30:00</asp:ListItem>
         <asp:ListItem>17:00:00</asp:ListItem> 
         <asp:ListItem>17:30:00</asp:ListItem>
         <asp:ListItem>18:00:00</asp:ListItem>
         <asp:ListItem>18:30:00</asp:ListItem>
         <asp:ListItem>19:00:00</asp:ListItem>
         <asp:ListItem>19:30:00</asp:ListItem>
         <asp:ListItem>20:00:00</asp:ListItem>
         <asp:ListItem>20:30:00</asp:ListItem>
         <asp:ListItem>21:00:00</asp:ListItem>
         <asp:ListItem>21:30:00</asp:ListItem>
         <asp:ListItem>22:00:00</asp:ListItem>
         <asp:ListItem>22:30:00</asp:ListItem>
         <asp:ListItem>23:00:00</asp:ListItem>
         <asp:ListItem>23:30:00</asp:ListItem>         
         <asp:ListItem>24:00:00</asp:ListItem>         
              </asp:DropDownList>
            </td>
            <td style="width: 138px; height: 28px">
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddltime"
                    Display="None" ErrorMessage="Please Select IN Time" SetFocusOnError="True" ValidationGroup="validnumbers"
                    Width="130px" InitialValue="0"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 28px">
            <asp:Label ID="Label2" runat="server" Text="Standard Out time"></asp:Label>
            </td>
            <td style="width: 302px; height: 28px">
            <asp:DropDownList ID="ddt_st_out" runat="server">
            <%--<asp:ListItem Value="0">--Select--</asp:ListItem>   --%>      
                  <asp:ListItem>01:00:00</asp:ListItem>
        <asp:ListItem>01:30:00</asp:ListItem>
        <asp:ListItem>02:00:00</asp:ListItem>
        <asp:ListItem>02:30:00</asp:ListItem>
        <asp:ListItem>03:00:00</asp:ListItem>
        <asp:ListItem>03:30:00</asp:ListItem>
        <asp:ListItem>04:00:00</asp:ListItem>
        <asp:ListItem>04:30:00</asp:ListItem>
         <asp:ListItem>05:00:00</asp:ListItem> 
         <asp:ListItem>05:30:00</asp:ListItem>
         <asp:ListItem>06:00:00</asp:ListItem>
         <asp:ListItem>06:30:00</asp:ListItem>
         <asp:ListItem>07:00:00</asp:ListItem>
         <asp:ListItem>07:30:00</asp:ListItem>
         <asp:ListItem>08:00:00</asp:ListItem>
         <asp:ListItem>08:30:00</asp:ListItem>
         <asp:ListItem>09:00:00</asp:ListItem>
         <asp:ListItem>09:30:00</asp:ListItem>
         <asp:ListItem>10:00:00</asp:ListItem>
         <asp:ListItem>10:30:00</asp:ListItem>
         <asp:ListItem>11:00:00</asp:ListItem>
         <asp:ListItem>11:30:00</asp:ListItem>         
         <asp:ListItem>12:00:00</asp:ListItem>
         <asp:ListItem>12:30:00</asp:ListItem>
         
         <asp:ListItem>13:00:00</asp:ListItem>
        <asp:ListItem>13:30:00</asp:ListItem>
        <asp:ListItem>14:00:00</asp:ListItem>
        <asp:ListItem>14:30:00</asp:ListItem>
        <asp:ListItem>15:00:00</asp:ListItem>
        <asp:ListItem>15:30:00</asp:ListItem>
        <asp:ListItem>16:00:00</asp:ListItem>
        <asp:ListItem>16:30:00</asp:ListItem>
         <asp:ListItem>17:00:00</asp:ListItem> 
         <asp:ListItem>17:30:00</asp:ListItem>
         <asp:ListItem>18:00:00</asp:ListItem>
         <asp:ListItem>18:30:00</asp:ListItem>
         <asp:ListItem>19:00:00</asp:ListItem>
         <asp:ListItem>19:30:00</asp:ListItem>
         <asp:ListItem>20:00:00</asp:ListItem>
         <asp:ListItem>20:30:00</asp:ListItem>
         <asp:ListItem>21:00:00</asp:ListItem>
         <asp:ListItem>21:30:00</asp:ListItem>
         <asp:ListItem>22:00:00</asp:ListItem>
         <asp:ListItem>22:30:00</asp:ListItem>
         <asp:ListItem>23:00:00</asp:ListItem>
         <asp:ListItem>23:30:00</asp:ListItem>         
         <asp:ListItem>24:00:00</asp:ListItem> 
              </asp:DropDownList>
            </td>
            <td style="width: 138px; height: 28px">
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddt_st_out"
                    Display="None" ErrorMessage="Please Select Out Time" ValidationGroup="validnumbers" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                    </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 30px">
               <asp:Label ID="lblexem_time" runat="server" Text="Exemption for In Time by (default)"></asp:Label></td>
            <td style="width: 302px; height: 30px">
               <asp:TextBox ID="exem_time1" runat="server">2</asp:TextBox>
                Days</td>
            <td style="width: 138px; height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="exem_time2"
                    ErrorMessage="Please Enter Number only" ValidationExpression="\d+" ValidationGroup="validnumbers" Display="None"></asp:RegularExpressionValidator>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="exem_time1"
                    Display="None" ErrorMessage="Enter The Execption  In Time" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 246px; height: 30px">
                &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="validnumbers" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 59px">
              <asp:Label ID="lblexem_time2" runat="server" Text="Exemption for  In time  ( basis of DCH approal)" Width="222px"></asp:Label></td>
            <td style="width: 302px; height: 59px">
                <asp:TextBox ID="exem_time2" runat="server">3</asp:TextBox> Days</td>
            <td style="width: 138px; height: 59px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="exem_time2"
                    ErrorMessage="Please Enter Number only" ValidationExpression="\d+" ValidationGroup="validnumbers" Display="None" SetFocusOnError="True"></asp:RegularExpressionValidator>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="exem_time2"
                    Display="None" ErrorMessage="Enter The Exection Values(DCH)" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 246px; height: 59px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 58px">
             <asp:Label ID="lblexem_time3" runat="server" Text="Exemption for  out  time"></asp:Label></td>
            <td style="width: 302px; height: 58px">
            <asp:TextBox ID="exem_time3" runat="server">3</asp:TextBox> Days</td>
            <td style="width: 138px; height: 58px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="exem_time3"
                    Display="None" ErrorMessage="Please Enter Number only" ValidationExpression="\d+"
                    ValidationGroup="validnumbers" SetFocusOnError="True"></asp:RegularExpressionValidator>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="exem_time3"
                    Display="None" ErrorMessage="Enter The Exemption Out Time" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 246px; height: 58px">
            </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 32px">
                <asp:Label ID="lbld_INtime" runat="server" Text="Deviation for IN time 1:"></asp:Label>
                </td>
            <td style="width: 302px; height: 32px">
                <asp:DropDownList ID="ddlDev_in_time1" runat="server">
               <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%> 
                <asp:ListItem>01:00:00</asp:ListItem>
        <asp:ListItem>01:30:00</asp:ListItem>
        <asp:ListItem>02:00:00</asp:ListItem>
        <asp:ListItem>02:30:00</asp:ListItem>
        <asp:ListItem>03:00:00</asp:ListItem>
        <asp:ListItem>03:30:00</asp:ListItem>
        <asp:ListItem>04:00:00</asp:ListItem>
        <asp:ListItem>04:30:00</asp:ListItem>
         <asp:ListItem>05:00:00</asp:ListItem> 
         <asp:ListItem>05:30:00</asp:ListItem>
         <asp:ListItem>06:00:00</asp:ListItem>
         <asp:ListItem>06:30:00</asp:ListItem>
         <asp:ListItem>07:00:00</asp:ListItem>
         <asp:ListItem>07:30:00</asp:ListItem>
         <asp:ListItem>08:00:00</asp:ListItem>
         <asp:ListItem>08:30:00</asp:ListItem>
         <asp:ListItem>09:00:00</asp:ListItem>
         <asp:ListItem>09:30:00</asp:ListItem>
         <asp:ListItem>10:00:00</asp:ListItem>
         <asp:ListItem>10:30:00</asp:ListItem>
         <asp:ListItem>11:00:00</asp:ListItem>
         <asp:ListItem>11:30:00</asp:ListItem>         
         <asp:ListItem>12:00:00</asp:ListItem>
         <asp:ListItem>12:30:00</asp:ListItem>
         
         <asp:ListItem>13:00:00</asp:ListItem>
        <asp:ListItem>13:30:00</asp:ListItem>
        <asp:ListItem>14:00:00</asp:ListItem>
        <asp:ListItem>14:30:00</asp:ListItem>
        <asp:ListItem>15:00:00</asp:ListItem>
        <asp:ListItem>15:30:00</asp:ListItem>
        <asp:ListItem>16:00:00</asp:ListItem>
        <asp:ListItem>16:30:00</asp:ListItem>
         <asp:ListItem>17:00:00</asp:ListItem> 
         <asp:ListItem>17:30:00</asp:ListItem>
         <asp:ListItem>18:00:00</asp:ListItem>
         <asp:ListItem>18:30:00</asp:ListItem>
         <asp:ListItem>19:00:00</asp:ListItem>
         <asp:ListItem>19:30:00</asp:ListItem>
         <asp:ListItem>20:00:00</asp:ListItem>
         <asp:ListItem>20:30:00</asp:ListItem>
         <asp:ListItem>21:00:00</asp:ListItem>
         <asp:ListItem>21:30:00</asp:ListItem>
         <asp:ListItem>22:00:00</asp:ListItem>
         <asp:ListItem>22:30:00</asp:ListItem>
         <asp:ListItem>23:00:00</asp:ListItem>
         <asp:ListItem>23:30:00</asp:ListItem>         
         <asp:ListItem>24:00:00</asp:ListItem> 
                </asp:DropDownList>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDev_in_time1"
                    Display="None" ErrorMessage="Select Devation IN Time 1" InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 138px; height: 32px">
                <asp:Label ID="lblp_intime" runat="server" Text="Penalty for IN time :"></asp:Label></td>
            <td style="width: 246px; height: 32px">
                <asp:DropDownList ID="ddl_time" runat="server">
            <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>  --%>   
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>35</asp:ListItem>
        <asp:ListItem>40</asp:ListItem> 
        <asp:ListItem>45</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
                </asp:DropDownList>%
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddl_time"
                    Display="None" ErrorMessage="Select Penalty IN Time" InitialValue="0" ValidationGroup="validnumbers" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                    </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 32px">
            <asp:Label ID="Label1" runat="server" Text="Deviation for IN time 2:"></asp:Label>
            </td>
            <td style="width: 302px; height: 32px">
                <asp:DropDownList ID="dlDev_in_time2" runat="server">
                <%--<asp:ListItem Value="0">--Select--</asp:ListItem> --%>
                 <asp:ListItem>01:00:00</asp:ListItem>
        <asp:ListItem>01:30:00</asp:ListItem>
        <asp:ListItem>02:00:00</asp:ListItem>
        <asp:ListItem>02:30:00</asp:ListItem>
        <asp:ListItem>03:00:00</asp:ListItem>
        <asp:ListItem>03:30:00</asp:ListItem>
        <asp:ListItem>04:00:00</asp:ListItem>
        <asp:ListItem>04:30:00</asp:ListItem>
         <asp:ListItem>05:00:00</asp:ListItem> 
         <asp:ListItem>05:30:00</asp:ListItem>
         <asp:ListItem>06:00:00</asp:ListItem>
         <asp:ListItem>06:30:00</asp:ListItem>
         <asp:ListItem>07:00:00</asp:ListItem>
         <asp:ListItem>07:30:00</asp:ListItem>
         <asp:ListItem>08:00:00</asp:ListItem>
         <asp:ListItem>08:30:00</asp:ListItem>
         <asp:ListItem>09:00:00</asp:ListItem>
         <asp:ListItem>09:30:00</asp:ListItem>
         <asp:ListItem>10:00:00</asp:ListItem>
         <asp:ListItem>10:30:00</asp:ListItem>
         <asp:ListItem>11:00:00</asp:ListItem>
         <asp:ListItem>11:30:00</asp:ListItem>         
         <asp:ListItem>12:00:00</asp:ListItem>
         <asp:ListItem>12:30:00</asp:ListItem>
         
         <asp:ListItem>13:00:00</asp:ListItem>
        <asp:ListItem>13:30:00</asp:ListItem>
        <asp:ListItem>14:00:00</asp:ListItem>
        <asp:ListItem>14:30:00</asp:ListItem>
        <asp:ListItem>15:00:00</asp:ListItem>
        <asp:ListItem>15:30:00</asp:ListItem>
        <asp:ListItem>16:00:00</asp:ListItem>
        <asp:ListItem>16:30:00</asp:ListItem>
         <asp:ListItem>17:00:00</asp:ListItem> 
         <asp:ListItem>17:30:00</asp:ListItem>
         <asp:ListItem>18:00:00</asp:ListItem>
         <asp:ListItem>18:30:00</asp:ListItem>
         <asp:ListItem>19:00:00</asp:ListItem>
         <asp:ListItem>19:30:00</asp:ListItem>
         <asp:ListItem>20:00:00</asp:ListItem>
         <asp:ListItem>20:30:00</asp:ListItem>
         <asp:ListItem>21:00:00</asp:ListItem>
         <asp:ListItem>21:30:00</asp:ListItem>
         <asp:ListItem>22:00:00</asp:ListItem>
         <asp:ListItem>22:30:00</asp:ListItem>
         <asp:ListItem>23:00:00</asp:ListItem>
         <asp:ListItem>23:30:00</asp:ListItem>         
         <asp:ListItem>24:00:00</asp:ListItem> 
                </asp:DropDownList>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dlDev_in_time2"
                    Display="None" ErrorMessage="Select Devation Time 2" InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 138px; height: 32px">
                <asp:Label ID="Label3" runat="server" Text="Penalty for IN time 2 :"></asp:Label></td>
            <td style="width: 246px; height: 32px">
            <asp:DropDownList ID="ddl_penIN_2" runat="server" Width="84px" >
           <%-- <asp:ListItem>--Select--</asp:ListItem>--%>
            <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>35</asp:ListItem>
        <asp:ListItem>40</asp:ListItem> 
        <asp:ListItem>45</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>%
                </td>
        </tr>
        <tr>
            <td style="width: 275px; height: 32px">
                <asp:Label ID="lblP_outtime" runat="server" Text="Deviation for Out time"></asp:Label></td>
            <td style="width: 302px; height: 32px">
             <%-- <asp:TextBox ID="txtd_outtime" runat="server"></asp:TextBox>--%>
             <asp:DropDownList ID="ddl_Dev_out_time" runat="server">
             <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>--%> 
             <asp:ListItem>01:00:00</asp:ListItem>
        <asp:ListItem>01:30:00</asp:ListItem>
        <asp:ListItem>02:00:00</asp:ListItem>
        <asp:ListItem>02:30:00</asp:ListItem>
        <asp:ListItem>03:00:00</asp:ListItem>
        <asp:ListItem>03:30:00</asp:ListItem>
        <asp:ListItem>04:00:00</asp:ListItem>
        <asp:ListItem>04:30:00</asp:ListItem>
         <asp:ListItem>05:00:00</asp:ListItem> 
         <asp:ListItem>05:30:00</asp:ListItem>
         <asp:ListItem>06:00:00</asp:ListItem>
         <asp:ListItem>06:30:00</asp:ListItem>
         <asp:ListItem>07:00:00</asp:ListItem>
         <asp:ListItem>07:30:00</asp:ListItem>
         <asp:ListItem>08:00:00</asp:ListItem>
         <asp:ListItem>08:30:00</asp:ListItem>
         <asp:ListItem>09:00:00</asp:ListItem>
         <asp:ListItem>09:30:00</asp:ListItem>
         <asp:ListItem>10:00:00</asp:ListItem>
         <asp:ListItem>10:30:00</asp:ListItem>
         <asp:ListItem>11:00:00</asp:ListItem>
         <asp:ListItem>11:30:00</asp:ListItem>         
         <asp:ListItem>12:00:00</asp:ListItem>
         <asp:ListItem>12:30:00</asp:ListItem>
         
         <asp:ListItem>13:00:00</asp:ListItem>
        <asp:ListItem>13:30:00</asp:ListItem>
        <asp:ListItem>14:00:00</asp:ListItem>
        <asp:ListItem>14:30:00</asp:ListItem>
        <asp:ListItem>15:00:00</asp:ListItem>
        <asp:ListItem>15:30:00</asp:ListItem>
        <asp:ListItem>16:00:00</asp:ListItem>
        <asp:ListItem>16:30:00</asp:ListItem>
         <asp:ListItem>17:00:00</asp:ListItem> 
         <asp:ListItem>17:30:00</asp:ListItem>
         <asp:ListItem>18:00:00</asp:ListItem>
         <asp:ListItem>18:30:00</asp:ListItem>
         <asp:ListItem>19:00:00</asp:ListItem>
         <asp:ListItem>19:30:00</asp:ListItem>
         <asp:ListItem>20:00:00</asp:ListItem>
         <asp:ListItem>20:30:00</asp:ListItem>
         <asp:ListItem>21:00:00</asp:ListItem>
         <asp:ListItem>21:30:00</asp:ListItem>
         <asp:ListItem>22:00:00</asp:ListItem>
         <asp:ListItem>22:30:00</asp:ListItem>
         <asp:ListItem>23:00:00</asp:ListItem>
         <asp:ListItem>23:30:00</asp:ListItem>         
         <asp:ListItem>24:00:00</asp:ListItem> 
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_Dev_out_time"
                    Display="None" ErrorMessage="Select Devation Out Time " InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="validnumbers"></asp:RequiredFieldValidator>--%></td>
            <td style="width: 138px; height: 32px">
               <asp:Label ID="lblpen_out" runat="server" Text="Penalty for Out time 1"></asp:Label></td>
            <td style="width: 246px; height: 32px">
               <%-- <asp:TextBox ID="txtpen_out" runat="server"></asp:TextBox>--%>
               <asp:DropDownList ID="ddl_pen_out" runat="server">
                <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%> 
               <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>35</asp:ListItem>
        <asp:ListItem>40</asp:ListItem> 
        <asp:ListItem>45</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
                </asp:DropDownList>%
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddl_pen_out"
                    Display="None" ErrorMessage="Select Penalty Out Time " InitialValue="0" ValidationGroup="validnumbers" SetFocusOnError="True"></asp:RequiredFieldValidator>--%></td>
        </tr>
        <tr>
            <td style="width: 275px; height: 32px">
                &nbsp;</td>
            <td style="width: 302px; height: 32px">
                </td>
            <td style="width: 138px; height: 32px">
                <asp:Label ID="Label4" runat="server" Text="Penalty for Out time 2"></asp:Label></td>
            <td style="width: 246px; height: 32px"><asp:DropDownList ID="ddl_pen_out_2" runat="server">
              <%--  <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>%</td>
        </tr>
        <tr>
            <td style="width: 275px; height: 32px">
            </td>
            <td style="width: 302px; height: 32px">
                <asp:Button ID="btnsave" runat="server" Text="Save" Width="121px" OnClick="btnsave_Click" ValidationGroup="validnumbers"/></td>
            <td style="width: 138px; height: 32px">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false" ForeColor="red"></asp:Label></td>
            <td style="width: 246px; height: 32px">
            </td>
        </tr>
    </table>

   </fieldset>
 
<fieldset style="width: 841px; height: 96px" >
<legend class="FormHeading">Import HR Attendance Entry</legend>  
    <table id="TABLE2" onclick="return TABLE1_onclick()">
       <tr >
        <td style="width: 177px; height: 1px;" >
            <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red" Visible="False">lable</asp:Label>
        <td style="width: 445px; height: 1px;" >
            
    </tr> 
        <tr >
        <td style="width: 177px; height: 1px;" >
            <strong>Upload File</strong></td>
        <td style="width: 445px; height: 1px;" >
            <asp:FileUpload ID="xslFileUpload" runat="server" Width="205px" />&nbsp;
            &nbsp;[Only *.xls]</td>
    </tr>
     <tr >
        <td style="width: 100px; height: 1px;"  colspan="7">
           <center><asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUpload_Click" ValidationGroup="validimport" Text="Import" />&nbsp;&nbsp;
               </center> 
          </td>
    </tr>
        <tr>
            <td colspan="7" style="width: 100px; height: 1px">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="validimport" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="xslFileUpload"
                    Display="None" ErrorMessage="Please Select File" SetFocusOnError="True" ValidationGroup="validimport"
                    Visible="False"></asp:RequiredFieldValidator></td>
        </tr>
       
    </table>

   </fieldset> 
</asp:Panel>                  
 
</asp:Content>

