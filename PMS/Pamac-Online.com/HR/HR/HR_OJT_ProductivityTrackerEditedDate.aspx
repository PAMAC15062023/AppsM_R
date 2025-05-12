<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_OJT_ProductivityTrackerEditedDate.aspx.cs" Inherits="HR_HR_HR_OJT_ProductivityTrackerEditedDate" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<script language="javascript" type="text/javascript"src="popcalendar.js"></script>
    
    <script language="JAVASCRIPT" type="text/javascript"> 
       
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
    
  <fieldset ><legend class="FormHeading">Daily Updation Performance / Productivity Tracker(Date
      Wise Updation)</legend>  
      <table width="100%" >
          <tr>
              <td colspan="2" style="height: 16px">
                  <asp:Label ID="lbldate" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblSkin"></asp:Label>
                  &nbsp;&nbsp;
                  <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg" ForeColor="Crimson"></asp:Label></td>
              <td style="height: 16px">
              </td>
              <td style="width: 227px; height: 16px;">
                  </td>
          </tr>
          <tr>
              <td style="width: 92px" class="reportTitleIncome"  >
                  &nbsp;Cluster Name</td>
                  <td style="width: 228px" class="Info" >
                  <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" SkinID="ddlSkin" OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" OnDataBound="ddlCluter_DataBound" Width="123px">
                  </asp:DropDownList></td>
              <td class="reportTitleIncome" >
                  &nbsp;Centre Name</td>
                  <td style="width: 227px" class="Info" >
                  <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="123px">
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td class="reportTitleIncome"  >
                  SubCenter Name</td>
                  <td class="Info"  >
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound" Width="123px">
                  </asp:DropDownList></td>
              
              <td class="reportTitleIncome" >
                  PAMACian First Name</td>
                  <td class="Info" >
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
          </tr>
          <tr>
              <td class="reportTitleIncome">
                  PAMACian Code</td>
              <td class="Info">
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
              <td class="reportTitleIncome">
                  Date
              </td>
              <td class="Info">
                  <asp:TextBox ID="txtdate" runat="server" SkinID="txtSkin" Width="121px" ValidationGroup="ViewDate"></asp:TextBox>
                  <img alt="Calendar" height="16" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" style="width: 19px" />
                  [dd/MM/yyyy]
              </td>
          </tr>
          <tr >
              <td class="Info" colspan="4">
                  &nbsp;
                  <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Search"
                      ValidationGroup="ViewDate" Width="123px" />
                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RequiredFieldValidator
                      ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate" ErrorMessage="Please Enter The Date"
                      ForeColor="White" ValidationGroup="ViewDate">*</asp:RequiredFieldValidator>
                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
              </td>
          </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="5" style="width: 934px; height: 373px;" >
                  &nbsp;<asp:GridView ID="GV_EMP_VEIW" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                      OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" PageSize="20" SkinID="gridviewNoSort"
                      Width="100%">
                      <Columns>
                          <asp:TemplateField>
                              <HeaderTemplate>
                                  <input id="chkSelectAll" onclick="javascript:CheckAll();" type="checkbox" />
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <asp:CheckBox ID="chkSelect" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="EMP_ID" HeaderText="EMP ID">
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="EMP_CODE" HeaderText="PAMACian Code">
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="FullName" HeaderText="PAMACian">
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DOJ" DataFormatString="{0:dd/MM/yyyy}" HeaderText="DOJ"
                              HtmlEncode="False">
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="DESIGNATION" HeaderText="Designation">
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="In Time">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtintime" runat="server" SkinID="txtSkin" Width="50px"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Out Time">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtouttime" runat="server" SkinID="txtSkin" Width="50px"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Minimum Productivity">
                              <ItemTemplate>
                                  <asp:DropDownList ID="ddlMinProduct" runat="server" SkinID="ddlSkin">
                                      <asp:ListItem>NA</asp:ListItem>
                                      <asp:ListItem>15</asp:ListItem>
                                      <asp:ListItem>30</asp:ListItem>
                                      <asp:ListItem>35</asp:ListItem>
                                      <asp:ListItem>50</asp:ListItem>
                                      <asp:ListItem>60</asp:ListItem>
                                      <asp:ListItem>85</asp:ListItem>
                                      <asp:ListItem>45-50</asp:ListItem>
                                      <asp:ListItem>15-18 Visits</asp:ListItem>
                                      <asp:ListItem>85-100 Tele</asp:ListItem>
                                      <asp:ListItem>85-100 Cases</asp:ListItem>
                                      <asp:ListItem>85-100 Reports</asp:ListItem>
                                      <asp:ListItem>400 Dual Entry</asp:ListItem>
                                      <asp:ListItem>5-6 Dox Collection</asp:ListItem>
                                      <asp:ListItem>80-90 calls per day</asp:ListItem>
                                      <asp:ListItem>Depends on the Area 10 DropBox per person</asp:ListItem>
                                  </asp:DropDownList>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Behaviour For Day">
                              <ItemTemplate>
                                  <asp:DropDownList ID="ddlBehaviour" runat="server" SkinID="ddlSkin">
                                      <asp:ListItem>NA</asp:ListItem>
                                      <asp:ListItem>Excellent</asp:ListItem>
                                      <asp:ListItem>Non Co-operative</asp:ListItem>
                                  </asp:DropDownList>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Cases Assigned">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtCaseAssigned" runat="server" SkinID="txtSkin" ValidationGroup="VLD"
                                      Width="50px"></asp:TextBox><asp:RegularExpressionValidator ID="REVCaseAssign" runat="server"
                                          ControlToValidate="txtCaseAssigned" ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Cases Completed">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtCaseCompleted" runat="server" AutoPostBack="true" OnTextChanged="txtCaseCompleted_TextChanged"
                                      SkinID="txtSkin" ValidationGroup="VLD" Width="50px"></asp:TextBox><asp:RegularExpressionValidator
                                          ID="REVCasecomp" runat="server" ControlToValidate="txtCaseCompleted" ErrorMessage="*"
                                          ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Error Count">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtErrorCount" runat="server" SkinID="txtSkin" ValidationGroup="VLD"
                                      Width="50px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExdfdfdpressionValidator1"
                                          runat="server" ControlToValidate="txtErrorCount" ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Training">
                              <ItemTemplate>
                                  <asp:DropDownList ID="ddlTraining" runat="server" SkinID="ddlSkin">
                                      <asp:ListItem>NA</asp:ListItem>
                                      <asp:ListItem>Pre Training</asp:ListItem>
                                      <asp:ListItem>Post Training</asp:ListItem>
                                  </asp:DropDownList>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Edit">
                              <ItemTemplate>
                                  <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                      CommandName="Ed"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                              </ItemTemplate>
                              <ItemStyle Width="20px" />
                              <HeaderStyle HorizontalAlign="Center" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Reason For Minimum Productivity">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtReason" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                                      ValidationGroup="VLD" Width="100px"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                  </asp:GridView>
                  <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click" ValidationGroup="ViewDate" />&nbsp;
                  <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" /></td>
          </tr>
      </table>
     
  
  
  </fieldset>
    
      <asp:SqlDataSource ID="sdsSubcetre" runat="server"  ProviderName="System.Data.OleDb">
      
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCentre" runat="server"  ProviderName="System.Data.OleDb">
          
      </asp:SqlDataSource>
    &nbsp;<asp:HiddenField ID="hdnEmpId" runat="server" />
    <br />
    
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
        ValidationGroup="ViewDate" DisplayMode="List" />
    &nbsp;&nbsp;&nbsp;
    
      <asp:SqlDataSource ID="sdsCluster" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME"></asp:SqlDataSource>
    <asp:HiddenField ID="hdndate" runat="server" />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:ValidationSummary ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False"  
        ValidationGroup="ValDate" />
    &nbsp;
  </asp:Content>

