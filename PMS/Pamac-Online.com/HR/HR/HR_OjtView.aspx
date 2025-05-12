<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_OjtView.aspx.cs" Inherits="HR_HR_HR_OjtView" Title="OJT View" StylesheetTheme="SkinFile" %>
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
       
        function CheckAll() 
        {
        chequeBoxSelectedCount = 0;
        var GV_EMP_VEIW = document.getElementById("<%=GV_EMP_VEIW.ClientID%>");
        var chkSelectAll = document.getElementById('chkSelectAll');
        var cell;
        for (i = 0; i <= GV_EMP_VEIW.rows.length - 1; i++) 
        {
            cell = GV_EMP_VEIW.rows[i].cells[0];
            if (cell != null) 
            {
                for (j = 0; j < cell.childNodes.length; j++) 
                {

                    if (cell.childNodes[j].type == "checkbox") 
                    {
                        cell.childNodes[j].checked = chkSelectAll.checked;
                        chequeBoxSelectedCount = chequeBoxSelectedCount + 1;
                    }
                }
            }
        }
   }
       </script>
        
  <fieldset ><legend class="FormHeading">Induction Training Confirmation Form</legend>  
      <table width="100%" >
          <tr>
              <td colspan="2" style="height: 16px">
                  <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg" ForeColor="Crimson" Visible="False"></asp:Label></td>
              <td style="height: 16px">
              </td>
              <td style="width: 227px; height: 16px;">
                  </td>
              <td style="width: 103px; height: 16px;">
              </td>
              <td align="right" style="height: 16px">
                  </td>
          </tr>
          <tr>
              <td style="width: 92px" class="reportTitleIncome"  >
                  &nbsp;Cluster Name</td>
                  <td style="width: 228px" class="Info" >
                  <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" SkinID="ddlSkin" OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" OnDataBound="ddlCluter_DataBound" Width="164px">
                  </asp:DropDownList></td>
              <td class="reportTitleIncome" >
                  Centre Name</td>
                  <td style="width: 227px" class="Info" >
                  <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="164px">
                  </asp:DropDownList></td>
              <td style="width: 103px" class="reportTitleIncome" >
                  SubCenter Name</td>
                  <td align="right" class="Info">
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound" Width="164px">
                  </asp:DropDownList>
                  </td>
          </tr>
          <tr>
              <td class="reportTitleIncome"  >
                  From Date 
                  </td>
                  <td class="Info"  >
                  <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              
              <td class="reportTitleIncome" >
              
                  To Date 
                  </td>
                  <td class="Info" >
                  <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              <td align="right"   >
                  &nbsp;
                  </td>
                  
                  <td align="right" >
                      &nbsp;
                      </td>
          </tr>
          <tr >
              <td class="reportTitleIncome" >
                  PAMACian Code</td>
              <td class="Info" >
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
              <td class="reportTitleIncome">
                  PAMACian Name</td>
              <td class="Info" >
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td align="right" >
              </td>
              <td align="right">
                  &nbsp;<asp:Button ID="btntat" runat="server" Text="Calculate TAT" OnClick="btntat_Click" SkinID="btn" />&nbsp;
                  <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Show" ValidationGroup="ValDate" Width="60px" />&nbsp;
              </td>
          </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="7" >
      <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort" AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" AllowPaging="True" PageSize="20" OnRowCommand="GV_EMP_VEIW_RowCommand" >
          <Columns>
           <asp:TemplateField>
                <HeaderTemplate>
                        <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
                    </HeaderTemplate>
                   <ItemTemplate>
                       <asp:CheckBox ID="chkSelect" runat="server" />
                   </ItemTemplate>
               </asp:TemplateField>
              <asp:BoundField DataField="EMP_CODE" HeaderText="PAMACian Code" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="FullName" HeaderText="PAMACian" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DESIGNATION" HeaderText="Designation" ItemStyle-HorizontalAlign="left"/> 
              <asp:BoundField DataField="Mou_Issue_Date" HeaderText="MOU Issue Date" ItemStyle-HorizontalAlign="left"/> 
              <asp:TemplateField HeaderText="Date Of Training">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDateTrain" SkinID="txtSkin" Width="60px" runat="server"></asp:TextBox>
                        <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.png" />
                    </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Induction Trainer Name">
                    <ItemTemplate>                            
                            <asp:TextBox ID="txtInductionTrainer" runat="server" SkinID="txtSkin"></asp:TextBox>                                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QMS Trainer Name">
                    <ItemTemplate>                            
                            <asp:TextBox ID="txtQmsTrainer" runat="server" SkinID="txtSkin"></asp:TextBox>                                                                                
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Induction Training Given">
                     <ItemTemplate>
                                <asp:DropDownList ID="ddlInducTrain" runat="server" SkinID="ddlSkin">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem>Not applicable</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>                       
                               
                    </ItemTemplate>
                </asp:TemplateField>
        
                <asp:TemplateField HeaderText="Remark">
                <ItemTemplate>
             <asp:TextBox  ID="txtremark" SkinID="txtSkin" runat="server"></asp:TextBox>
                </ItemTemplate>
                
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="TAT Calculation">
                            <ItemTemplate>
                            <asp:Label ID="lbltat" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                             
              <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            
                            
          </Columns>
      </asp:GridView>
                  <asp:Button ID="btnSave" runat="server" Font-Bold="True" OnClick="btnSave_Click"
                      Text="Save" />
                  &nbsp;
                  <asp:Button ID="btnCan" runat="server" Font-Bold="True" OnClick="btnCan_Click" Text="Cancel" /></td>
          </tr>
      </table>
     
  
  
  </fieldset>
    
      <asp:SqlDataSource ID="sdsSubcetre" runat="server"  ProviderName="System.Data.OleDb">
      
      </asp:SqlDataSource>
    <asp:HiddenField ID="HiddenField1" runat="server" />
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

