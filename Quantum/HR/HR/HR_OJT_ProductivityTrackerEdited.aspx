<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_OJT_ProductivityTrackerEdited.aspx.cs" Inherits="HR_HR_HR_OJT_ProductivityTrackerEdited" Title="Untitled Page"  StylesheetTheme="SkinFile"%>
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
    
  <fieldset ><legend class="FormHeading">Daily Updation Performance / Productivity Tracker(Earlier
      Day)</legend>  
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
              <td style="width: 103px; height: 16px;">
              </td>
              <td align="right" style="height: 16px">
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
              <td style="width: 103px" class="reportTitleIncome" >
                  SubCenter Name</td>
                  <td align="right" class="Info">
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound" Width="123px">
                  </asp:DropDownList>
                  </td>
          </tr>
          <tr>
              <td class="reportTitleIncome"  >
                  PAMACian Code</td>
                  <td class="Info"  >
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
              
              <td class="reportTitleIncome" >
                  PAMACian First Name</td>
                  <td class="Info" >
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin" Width="120px"></asp:TextBox></td>
              <td align="right" class="Info" colspan="2">
              </td>
          </tr>
          <tr >
              <td class="Info" colspan="6">
                  &nbsp;
                  <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Search"
                      ValidationGroup="ValDate" Width="123px" /></td>
          </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="7" style="width: 934px" >
     <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort" AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" AllowPaging="True" PageSize="20" >
          <Columns>
           <asp:TemplateField>
                <HeaderTemplate>
                        <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />
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
          <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
              <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>                  
              <asp:BoundField DataField="DESIGNATION" HeaderText="Designation">
                  <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
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
                <asp:TemplateField HeaderText="InOut Time">
                    <ItemTemplate>
                            <asp:DropDownList ID="ddlInOut" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>                                        
                            </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Behaviour For Day">
                    <ItemTemplate>
                            <asp:DropDownList ID="ddlBehaviour" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Introvert</asp:ListItem>
                                        <asp:ListItem>Extrovert</asp:ListItem>                                        
                                        <asp:ListItem>Rude</asp:ListItem>                                        
                                        <asp:ListItem>Team player</asp:ListItem>                                        
                            </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cases Assigned">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCaseAssigned" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD"></asp:TextBox><asp:RegularExpressionValidator ID="REVCaseAssign" runat="server" ControlToValidate="txtCaseAssigned"
                            ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cases Completed">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCaseCompleted" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD" OnTextChanged="txtCaseCompleted_TextChanged" AutoPostBack="true"></asp:TextBox><asp:RegularExpressionValidator ID="REVCasecomp" runat="server" ControlToValidate="txtCaseCompleted"
                            ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Error Count">
                    <ItemTemplate>
                        <asp:TextBox ID="txtErrorCount" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExdfdfdpressionValidator1" runat="server"
                            ControlToValidate="txtErrorCount" ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
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
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Reason For Minimum Productivity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtReason" SkinID="txtSkin" Width="100px" runat="server" ValidationGroup="VLD" TextMode="MultiLine" ></asp:TextBox>                                              </ItemTemplate>
                </asp:TemplateField>
               
          </Columns>
      </asp:GridView>
                  <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click" />&nbsp;
                  <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" /></td>
          </tr>
      </table>
     
  
  
  </fieldset>
    
      <asp:SqlDataSource ID="sdsSubcetre" runat="server"  ProviderName="System.Data.OleDb">
      
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCentre" runat="server"  ProviderName="System.Data.OleDb">
          
      </asp:SqlDataSource>
    &nbsp;<asp:HiddenField ID="hdnEmpId" runat="server" />
    <asp:HiddenField ID="HdnDay" runat="server" />
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
        ValidationGroup="ValAddNew" DisplayMode="List" />
    &nbsp;&nbsp;&nbsp;
    
      <asp:SqlDataSource ID="sdsCluster" runat="server"  ProviderName="System.Data.OleDb" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME"></asp:SqlDataSource>
    <asp:HiddenField ID="hdndate" runat="server" />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:ValidationSummary ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False"  
        ValidationGroup="ValDate" />
    &nbsp;
  </asp:Content>

