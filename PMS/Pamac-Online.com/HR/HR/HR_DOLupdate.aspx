<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_DOLupdate.aspx.cs" Inherits="HR_HR_HR_DOLupdate" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
  function validdate()  
  {
  
  debugger
    
  alert("hiiii");
     //var strFromDate = new Date.getTime();
      var strToDate = document.getElementById("<%=txtdate.ClientID%>").value;
      var strFromDate = document.getElementById("<%=TextBox1.ClientID%>").value;
      
       alert(strFromDate);
          alert(strToDate);
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
 
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];
     var fdate=new Date();
    
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);
    
       alert(dtFromDate);
      alert(dtToDate);
      
      
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();

    
    date1.setTime(dtFromDate.getTime());
    
    date2.setTime(dtToDate.getTime());
    
    
    var add_one_day = date2.getTime()+(1000 * 60 * 60 * 24);
    diff.setTime(Math.round(date1.getTime()+add_one_day));
    var dateDiff = diff.getTime();
    
    alert(dateDiff);
    if ( parseInt(dateDiff) > 3) 
    {
         alert("Required Date should not be less then Requested  Date");           
         return false;
    }
    else
    {            
         return true;
    }

  }

</script>



<asp:Panel ID="pnlhr" runat="server" Height="655px" Width="1024px">
    &nbsp;
    <fieldset style="width: 744px; height: 371px" >
<legend class="FormHeading">DOL UPDATE STAGE</legend>  
    <table style="height: 61px; width: 756px;">
        <tr>
            <td style="width: 105px; height: 11px">
            <%-- <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="red"></asp:Label>--%>
            </td>
            <td style="width: 337px; height: 11px">
                <asp:Label ID="lblmsg" runat="server" Text="Label" ForeColor="red" Visible="false"></asp:Label></td>
            <td style="width: 106px; height: 11px; color: #000000;">
            </td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 105px; height: 35px">
                <asp:Label ID="lblsearch" runat="server" Text="Please Entre Code:"></asp:Label></td>
            <td style="width: 337px; height: 35px">
                <asp:TextBox ID="txtsearch" runat="server" Width="211px"></asp:TextBox></td>
            <td style="width: 106px; height: 35px">
                &nbsp;<asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search" ValidationGroup="validcode"  />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsearch"
                    Display="None" ErrorMessage="Please Enter The Employee Code " SetFocusOnError="True"
                    ValidationGroup="validcode"></asp:RequiredFieldValidator></td>
            <td style="width: 106px; height: 35px">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Visible="False"></asp:TextBox></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 105px; height: 19px">
               <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
            <td style="width: 337px; height: 19px">
                <asp:TextBox ID="txtname" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
            <td style="width: 106px; height: 19px">
                <asp:Label ID="lblenm_code" runat="server" Text="Employee Code"></asp:Label></td>
            <td style="width: 106px; height: 19px">
                &nbsp;<asp:TextBox ID="txtcode" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px; height: 30px">
                <asp:Label ID="lblcentre" runat="server" Text="Centre"></asp:Label></td>
            <td style="width: 337px; height: 30px">
               <asp:TextBox ID="txtcentre" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
            <td style="width: 106px; height: 30px">
                <asp:Label ID="lblsubcentre" runat="server" Text="Subcentre"></asp:Label></td>
            <td style="width: 106px; height: 30px">
                <asp:TextBox ID="txtsubcentre" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px; height: 19px">
                <asp:Label ID="lblunit" runat="server" Text="Unit"></asp:Label></td>
            <td style="width: 337px; height: 19px">
                <asp:TextBox ID="txtunit" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
            <td style="width: 106px; height: 19px">
                <asp:Label ID="lbldesign" runat="server" Text="Designation"></asp:Label></td>
            <td style="width: 106px; height: 19px">
           <asp:TextBox ID="txtdesign" runat="server" ReadOnly="true" Width="211px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 105px; height: 21px">
                Date Of Resigned(DOR)</td>
            <td style="width: 337px; height: 21px">
                <asp:TextBox ID="txtresgndate" runat="server" Width="211px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtresgndate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]
            </td>
            <td style="width: 106px; height: 21px">
                Date Of Leaving(DOL)</td>
            <td style="width: 106px; height: 21px">
            <asp:TextBox ID="txtdate" runat="server" Width="211px"></asp:TextBox> 
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]
            </td>
        </tr>
        <tr>
            <td style="width: 105px; height: 18px">
                Notice Served</td>
            <td style="width: 337px; height: 18px">
                <asp:DropDownList ID="ddlNoticeServed" runat="server" Width="171px" SkinID="ddlSkin">
                <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 106px; height: 18px">
                Date Of Leaving(DOL) &nbsp;Reason</td>
            <td style="width: 106px; height: 18px">
                <asp:DropDownList ID="ddldolreason" runat="server" SkinID="ddlSkin" Width="170px">
                
                  <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem>Better opportunity</asp:ListItem>
                    <asp:ListItem>Personal Reason</asp:ListItem>
                    <asp:ListItem>Relocation</asp:ListItem>
                    <asp:ListItem>Health</asp:ListItem>
                    <asp:ListItem>Further studies</asp:ListItem>                  
                    <asp:ListItem>Absconding</asp:ListItem>
                    <asp:ListItem>Terminated - Disc Action</asp:ListItem>
                    <asp:ListItem>Terminated – Nonperformance</asp:ListItem>
                    <asp:ListItem>Deceased</asp:ListItem>
                    <asp:ListItem>Layoff</asp:ListItem>                
                   
                </asp:DropDownList></td>
        </tr>
        
        <tr>
            <td style="width: 105px; height: 32px">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            <td style="width: 337px; height: 32px">
                <asp:Button ID="btnsave" runat="server" Text="Save" Width="121px" OnClick="btnsave_Click" ValidationGroup="validdate" /></td>
            <td style="width: 106px; height: 32px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtresgndate"
                    Display="None" ErrorMessage="Please select resigned date" ValidationGroup="validdate"></asp:RequiredFieldValidator></td>
            <td style="width: 246px; height: 32px">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false" ForeColor="red"></asp:Label></td>
        </tr>
      
        <tr>
            <td style="width: 105px; height: 32px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlNoticeServed"
                    Display="None" ErrorMessage="Please Select Notice Served Value" InitialValue="0"
                    SetFocusOnError="True" ValidationGroup="validdate" Width="118px"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddldolreason"
                    Display="None" ErrorMessage="Please Select Dol Reason " InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="validdate"></asp:RequiredFieldValidator></td>
            <td style="width: 337px; height: 32px">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                    Display="None" ErrorMessage="Please Enter date" SetFocusOnError="True" ValidationGroup="validdate"></asp:RequiredFieldValidator></td>
            <td style="width: 106px; height: 32px">
                &nbsp;<asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="validcode" />
                </td>
            <td style="width: 246px; height: 32px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="validdate" Height="25px" Width="178px"  />
            </td>
        </tr>
    </table>
</fieldset>
<fieldset style="width: 838px; height: 68px">
 <legend class="FormHeading">Import DOL</legend>  
        <table>
            <tr>
                <td style="width: 158px; height: 12px">
                </td>
                <td style="width: 240px; height: 12px">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="width: 284px; height: 12px; color: #000000;">
                </td>
                <td style="width: 304px; color: #000000; height: 12px">
                </td>
                <td style="width: 280px; height: 12px; color: #000000;">
                </td>
            </tr>
       
        <tr style="color: #000000">
            <td style="width: 158px; height: 32px">
                DOL Import</td>
            <td style="width: 240px; height: 32px">
                &nbsp;<asp:FileUpload ID="xslFileUpload" runat="server" />
            </td>
            <td style="width: 284px; height: 32px">
                Select Zone</td>
            <td style="width: 304px; height: 32px">
                <asp:DropDownList ID="ddlZone" runat="server">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>BVU</asp:ListItem>
                    <asp:ListItem>EAST</asp:ListItem>
                    <asp:ListItem>NORTH</asp:ListItem>
                    <asp:ListItem>SOUTH</asp:ListItem>
                    <asp:ListItem>WEST</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 280px; height: 32px">
                <asp:Button ID="Button2" runat="server" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" OnClick="btnupload_Click" Text="Import" ValidationGroup="vsZone"
                    Width="105px" /></td>
        </tr>
        <tr>
            <td style="width: 158px; height: 24px">
            </td>
            <td style="width: 240px; height: 24px">
                &nbsp;&nbsp;
                <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="True" ValidationGroup="vsZone" ShowSummary="False" />
            </td>
            <td style="width: 284px; height: 24px">
            </td>
            <td style="width: 304px; height: 24px">
            </td>
            <td style="width: 280px; height: 24px">
                <asp:RequiredFieldValidator ID="rvZone" runat="server" Display="None"
                    ErrorMessage="Please Select Zone" ControlToValidate="ddlZone" InitialValue="0" ValidationGroup="vsZone"></asp:RequiredFieldValidator></td>
        </tr>
            
        <tr>
        </tr>
     </table>
       </fieldset>   
    
    <fieldset style="width: 838px; height: 68px">
        <legend class="FormHeading">OD Imoprt</legend>
        <table>
            <tr>
                <td style="width: 158px; height: 12px">
                </td>
                <td style="width: 240px; height: 12px">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="width: 284px; height: 12px; color: #000000;">
                </td>
                <td style="width: 304px; color: #000000; height: 12px">
                </td>
                <td style="width: 280px; height: 12px; color: #000000;">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 158px; height: 32px">
                    OD &nbsp;Import</td>
                <td style="width: 240px; height: 32px">
                    &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td style="width: 284px; height: 32px">
                    <asp:Button ID="Button1" runat="server" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" OnClick="Button1_Click" Text="Import"
                    Width="105px" /></td>
                <td style="width: 304px; height: 32px">
                </td>
                <td style="width: 280px; height: 32px">
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 24px">
                </td>
                <td style="width: 240px; height: 24px">
                    &nbsp;&nbsp;
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ValidationGroup="vsZone" ShowSummary="False" />
                </td>
                <td style="width: 284px; height: 24px">
                </td>
                <td style="width: 304px; height: 24px">
                </td>
                <td style="width: 280px; height: 24px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlZone"
                        Display="None" ErrorMessage="Please Select Zone" InitialValue="0" ValidationGroup="vsZone"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
    </fieldset>
    
   
    <fieldset style="width: 838px; height: 68px">
        <legend class="FormHeading">Sal Imoprt</legend>
        <table>
            <tr>
                <td style="width: 158px; height: 12px">
                </td>
                <td style="width: 240px; height: 12px">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="width: 284px; height: 12px; color: #000000;">
                </td>
                <td style="width: 304px; color: #000000; height: 12px">
                </td>
                <td style="width: 280px; height: 12px; color: #000000;">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 158px; height: 32px">
                    SAL &nbsp;Import</td>
                <td style="width: 240px; height: 32px">
                    &nbsp;<asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
                <td style="width: 284px; height: 32px">
                    <asp:Button ID="BtnSal" runat="server" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" OnClick="BtnSal_Click" Text="Import"
                    Width="105px" /></td>
                <td style="width: 304px; height: 32px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlZone"
                        Display="None" ErrorMessage="Please Select Zone" InitialValue="0" ValidationGroup="vsZone"></asp:RequiredFieldValidator></td>
                <td style="width: 280px; height: 32px">
                </td>
            </tr>
            <tr>
                <td style="width: 158px; height: 24px">
                </td>
                <td style="width: 240px; height: 24px">
                    &nbsp;&nbsp;
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True" ValidationGroup="vsZone" ShowSummary="False" />
                </td>
                <td style="width: 284px; height: 24px">
                </td>
                <td style="width: 304px; height: 24px">
                </td>
                <td style="width: 280px; height: 24px">
                    </td>
            </tr>
            
            
        </table>
    </fieldset>
    
      
   
</asp:Panel> 

</asp:Content>