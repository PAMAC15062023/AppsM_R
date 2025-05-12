<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="HRMasterPage.master"
    CodeFile="PhotoNotification.aspx.cs" Inherits="HR_HR_PhotoNotification" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <%--<script language="JAVASCRIPT" type="text/javascript"> 

 function compareDate(date1, date2)
            {
                k = date1.split('/');

                dayTo = k[0]; 
                yearTo = k[2];
                monthTo  = k[1];
                    var tempStartDate = new Date(yearTo,monthTo,dayTo);
                k = date2.split('/');
                dayFrom= k[0]; // javascript month range : 0- 11
                yearFrom = k[2];
                monthFrom = k[1];   
            
                var tempEndDate = new Date(yearFrom,monthFrom,dayFrom);

                if(tempStartDate > tempEndDate)
                {
                    //alert(msg);
                    if(tempStartDate != tempEndDate)
                    {
                     return false;
                    }
                }
                else
                {
                   return true;
                }
            }
function DateCompare(source, arguments)
{

var Fdate=document.getElementById("<%=txtFromDate.ClientID %>").value;
var Tdate= document.getElementById("<%=txtToDate.ClientID %>").value;
var Fdate1= Fdate.substring(0,10);
var Tdate1= Tdate.substring(0,10);
if(compareDate(Fdate1,Tdate1) == false)                      
arguments.IsValid=false;
else
arguments.IsValid=true;  
  	  
}


function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       function ValDate(source, arguments)
       {
      
       var strFromDt=document.getElementById("<%=txtFromDate.ClientID %>").value;
       var strTidt= document.getElementById("<%=txtToDate.ClientID %>").value;
       if(strFromDt=="" && strTidt!="")
       {
       arguments.IsValid=false;
       }
       else if(strFromDt!="" && strTidt=="")
       {
        arguments.IsValid=false;
       }
       else
       {
       arguments.IsValid=true;
       }
       }
       </script>--%>
    <table>
        <tr>
            <td align="center" colspan="1" style="height: 24px">
            </td>
            <td align="center" colspan="5" style="color: #000099; height: 24px">
                <strong>Welcome To Employee photo Download<strong></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <strong>From Date : </strong>
            </td>
            <td>
                <asp:TextBox ID="txtFromdate" runat="server"></asp:TextBox>
                 <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]
            </td>
            <td>
                <strong>To date : </strong>
            </td>
            <td>
                <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                 <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTodate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]
            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td colspan="1">
                <asp:Button ID="Btncancel" runat="server" Text="cancel" OnClick="Btncancel_Click"
                    Visible="false" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" Width="442px" OnRowCreated="GridView1_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdownload" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilePath")%>'
                                    CommandName="download" OnClick="lnkdownload_Click"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <asp:HiddenField ID="hdnempid" runat="server" />
    </table>
</asp:Content>
