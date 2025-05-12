<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/PTPU/PTPU/MasterPage.master" AutoEventWireup="true" CodeFile="Export.aspx.cs" Inherits="PTPU_PTPU_Export" Title="Untitled Page" StylesheetTheme="SkinFile" %>



<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">


  

    
    


function funValidateFromToDate()
{
    var strFromDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //===split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replacing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

    //==Converting the string to date format
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);

    //declaring the date variable
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
         alert("To Date should not be less than From Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  


</script>


<script language="javascript" type="text/javascript">

function validate()
{
    var ReturnValue=true;
    var ErrorMessage="";
    var lblMsgXls=document.getElementById("<%=lblMsgXls.ClientID%>");

  
    var txtDateFrom=document.getElementById("<%=txtDateFrom.ClientID%>");
    var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
//      var ddlcentre=document.getElementById("<%=ddlcentre.ClientID%>");
//    var txtbatchid=document.getElementById("<%=txtbatchid.ClientID%>");
    
    
    
    
//        if(txtbatchid.value=='')
//    {
//        ErrorMessage=("please select Batch to continue!");
//        ReturnValue=false;
//        txtbatchid.focus();
//    }
//    
//    
//      if(ddlcentre.selectedIndex==0)
//    {
//        ErrorMessage=("please select Centre to continue!");
//        ReturnValue=false;
//        ddlcentre.focus();
//    }
    
       if(txtToDate.value=='')
    {
        ErrorMessage=("please select To Date to continue!");
        ReturnValue=false;
        txtToDate.focus();
    }
    
    if(txtDateFrom.value=='')
    {
        ErrorMessage=("please select From Date to continue!");
        ReturnValue=false;
        txtDateFrom.focus();
    }
    
        window.scrollTo(0,0);    
    lblMsgXls.innerText=ErrorMessage;
    return ReturnValue;
}

</script>
<table style="width: 688px;">    <%--height: 66px--%>
  <tr>
  <td style="width: 719px; height: 194px;">
    <table style="width: 686px; height: 190px;">
    <tr>
        <td class="tta" colspan="4" style=" width: 690px;">
            <span style="font-size: 10pt">Export</span></td>
    </tr>
    <tr>
        <td colspan="4" style=" width: 690px;">
         <asp:Label ID="lblMsgXls" runat="server"  SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr >
        <td style="width: 150px;" class="reportTitleIncome">
            <strong>From Date</strong></td>
        <td style="width: 150px;" class="Info">
                <asp:TextBox ID="txtDateFrom" runat="server" Width="80px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateFrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>

        <td style="width: 150px;" class="reportTitleIncome" >
            <strong>To Date</strong></td>
        <td style="width: 150px;" class="Info">
            <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="80px"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" /></td>
    </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 150px;">
                <strong>Centre</strong></td>
            <td class="Info" style="width: 150px;">
                <asp:DropDownList ID="ddlcentre" runat="server" Width="103px" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 150px;">
                <strong>Batch ID</strong></td>
            <td class="Info" style="width: 150px;">
                <asp:TextBox ID="txtbatchid" runat="server" SkinID="txtSkin" Width="107px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="Info" colspan="4" >
                &nbsp; &nbsp;&nbsp;
                <asp:Button ID="Btnsearch" runat="server" OnClick="Btnsearch_Click" Text="Search" Width="105px" />
                <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="Export to Excel" /></td>
        </tr>
    
     
    </table>
      <asp:GridView ID="grdOcd" runat="server" SkinID="gridviewNoSort">
      </asp:GridView>
     
  </td>
  </tr>
  </table>

</asp:Content>

