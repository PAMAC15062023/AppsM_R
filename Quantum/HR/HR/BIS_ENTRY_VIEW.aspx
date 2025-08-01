<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="HRMasterPage.master"  CodeFile="BIS_ENTRY_VIEW.aspx.cs" Inherits="HR_BIS_ENTRY_VIEW" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript"src="popcalendar.js"></script>
<script language="JAVASCRIPT" type="text/javascript"> 

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
       </script>
        
  <fieldset ><legend class="FormHeading" style="color: #330000">BIS-ENTRY-VIEW</legend>  
      <table width="100%" >
          <tr>
              <td style="width: 92px">
              </td>
              <td style="width: 6px">
              </td>
              <td style="width: 228px">
              </td>
              <td>
              </td>
              <td style="width: 4px">
              </td>
              <td style="width: 227px">
                  <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"></asp:Label></td>
              <td style="width: 103px">
              </td>
              <td align="right" style="width: 9px">
              </td>
              <td align="right">
                  <asp:Label ID="Label1" runat="server" Font-Bold="True" SkinID="lblSkin" Text="[View]"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 92px"  >
                  
                  <asp:Label ID="lblCluster" runat="server" Text="Cluster Name" Visible="False" Width="89px"></asp:Label>
                  </td>
              <td style="width: 6px">
                  <asp:Label ID="lblClusterCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td style="width: 228px" >
                  <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" SkinID="ddlSkin" Visible="False" OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" OnDataBound="ddlCluter_DataBound" Width="164px">
                  </asp:DropDownList></td>
              <td >
                
                  <asp:Label ID="lblCentre" runat="server" Text="Hub" Visible="False" Width="78px"></asp:Label>
                  </td>
              <td style="width: 4px">
                  <asp:Label ID="lblCentreCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td style="width: 227px" >
                  <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Visible="False" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="164px">
                  </asp:DropDownList></td>
              <td style="width: 103px" >
                  
                  <asp:Label ID="lblSubcentre" runat="server" Text="DD Payble Location" Width="100px" Visible="False"></asp:Label></td>
              <td align="right" style="width: 9px">
                  <asp:Label ID="lblSubcentreCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td align="right">
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" Visible="False" OnDataBound="ddlSubcentre_DataBound" Width="164px">
                  </asp:DropDownList>
                  </td>
          </tr>
          <tr>
              <td  >
                  From Date 
                  </td>
              <td style="width: 6px">
                  :</td>
                  <td  >
                  <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              
              <td >
              
                  To Date 
                  </td>
              <td style="width: 2px">
                  :</td>
                  <td >
                  <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              <td align="right"   >
                  &nbsp;
                  </td>
              <td align="left" >
              </td>
                  
                  <td align="right" >
                      &nbsp;
                      </td>
          </tr>
          <tr >
              <td >
                  FOS Code</td>
              <td style="width: 6px">
                  :</td>
              <td >
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
              <td>
                  FOS Name</td>
              <td style="width: 2px">
                  :</td>
              <td >
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td align="right" >
              </td>
              <td align="left" >
              </td>
              <td align="left">
                  <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Show" ValidationGroup="ValDate" Width="60px" BackColor="#996633" ForeColor="White" />
                  <asp:Button ID="btAddNew" runat="server" SkinID="btn" Text="Add New" OnClick="btAddNew_Click" ValidationGroup="ValAddNew" Width="100px" ForeColor="White" />
                  &nbsp;
              </td>
          </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="10" >
      <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="grdMain" AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" AllowPaging="True" PageSize="20" OnRowCommand="GV_EMP_VEIW_RowCommand" >
          <Columns>
              <asp:BoundField DataField="EMP CODE" HeaderText="FOS Code">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="PAMACIAN" HeaderText="FOS Name">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
          <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
              <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="DOL" HeaderText="DOL" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
              <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
              <asp:BoundField DataField="DEPARTMENT" HeaderText="Department">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESIGNATION" HeaderText="Designation">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="UNIT" HeaderText="Unit">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
               <asp:BoundField DataField="CLUSTER_NAME" HeaderText="Cluster Name">
                   <ItemStyle HorizontalAlign="Left" />
               </asp:BoundField>
               <asp:BoundField DataField="CENTRE_NAME" HeaderText="Hub">
                   <ItemStyle HorizontalAlign="Left" />
               </asp:BoundField>
               <asp:BoundField DataField="SubCentreName" HeaderText="DD Payble Location">
                   <ItemStyle HorizontalAlign="Left" />
               </asp:BoundField>
              <asp:TemplateField HeaderText="Edit"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
          </Columns>
      </asp:GridView>
              </td>
          </tr>
      </table>
     
  
  
  </fieldset>
    
      <asp:SqlDataSource ID="sdsSubcetre" runat="server"  ProviderName="System.Data.OleDb">
      
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCentre" runat="server"  ProviderName="System.Data.OleDb">
          
      </asp:SqlDataSource>
    
    <asp:CustomValidator ID="ValCluster" runat="server" ControlToValidate="ddlCluter"
        Display="None" ErrorMessage="Please select the Cluster" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValCentre" runat="server" ControlToValidate="ddlCentre"
        Display="None" ErrorMessage="Please select the centre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValSubcentre" runat="server" ControlToValidate="ddlSubcentre"
        Display="None" ErrorMessage="Please select the SubCentre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:ValidationSummary ID="ValSummarry" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="ValAddNew" DisplayMode="List" />
    &nbsp;&nbsp;&nbsp;
    
      <asp:SqlDataSource ID="sdsCluster" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME"></asp:SqlDataSource>
    &nbsp;
    <asp:RegularExpressionValidator ID="RegFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="ValDate"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegToDate" runat="server" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
    ErrorMessage="Please enter valid date format for DOB."  ValidationGroup="ValDate" ControlToValidate="txtToDate" Display="None" SetFocusOnError="True"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False"  
        ValidationGroup="ValDate" />
    <asp:CustomValidator ID="ValDate1" runat="server" ErrorMessage="Please put the both From Date  and To Date" ClientValidationFunction="ValDate" Display="None" SetFocusOnError="True" ValidationGroup="ValDate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValFromToDate" runat="server" Display="None" ErrorMessage="From Date should not be greater then To Date"
        SetFocusOnError="True" ValidationGroup="ValDate" ClientValidationFunction="DateCompare"></asp:CustomValidator>
  </asp:Content>
  
