<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="HR_HR_Update" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript"src="popcalendar.js"></script>
        
  <fieldset ><legend class="FormHeading">Daily Updation Performance / Productivity Tracker</legend>  
      <table style="width: 941px">
          <tr>
              <td colspan="6">
                  <asp:Label ID="lblmsg" runat="server" EnableViewState="False" ForeColor="Crimson"
                      SkinID="lblErrorMsg"></asp:Label></td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  Employee Code</td>
              <td class="Info" style="width: 100px">
                  <asp:Label ID="lblempcode" runat="server" Width="150px"></asp:Label></td>
              <td class="reportTitleIncome" style="width: 100px">
                  Case Assign</td>
              <td class="Info" style="width: 100px">
                  &nbsp;<asp:TextBox ID="txtCaseAssigned" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  Employee Name</td>
              <td class="Info" style="width: 100px">
                  <asp:Label ID="lblempname" runat="server"  Width="150px"></asp:Label></td>
              <td class="reportTitleIncome" style="width: 100px">
                  Case Complete</td>
              <td class="Info" style="width: 100px">
                  &nbsp;<asp:TextBox ID="txtCaseCompleted" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  Minimum Productivity</td>
              <td class="Info" style="width: 100px">
                  
                   <asp:Label ID="lblMinProduct" runat="server"  Width="150px"></asp:Label>
                  
                  
                    <%--<asp:DropDownList ID="ddlMinProduct" runat="server" SkinID="ddlSkin" Width="194px">
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
                      <asp:ListItem>Not Applicable</asp:ListItem>
                      <asp:ListItem>5-6 Dox Collection</asp:ListItem>
                      <asp:ListItem>80-90 calls per day</asp:ListItem>
                      <asp:ListItem>Depends on the Area 10 DropBox per person</asp:ListItem>
                  </asp:DropDownList>--%>
                  
                  
                  </td>
              <td class="reportTitleIncome" style="width: 100px">
                  Error Count</td>
              <td class="Info" style="width: 100px">
                  &nbsp;<asp:TextBox ID="txtErrorCount" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  In Time</td>
              <td class="Info" style="width: 100px">
                  <asp:TextBox ID="txtintime" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td class="reportTitleIncome" style="width: 100px">
                  Training</td>
              <td class="Info" style="width: 100px">
                  &nbsp;<asp:DropDownList ID="ddlTraining" runat="server" SkinID="ddlSkin" Width="150px">
                      <asp:ListItem>NA</asp:ListItem>
                      <asp:ListItem>Pre Training</asp:ListItem>
                      <asp:ListItem>Post Training</asp:ListItem>
                  </asp:DropDownList></td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  Out Time</td>
              <td class="Info" style="width: 100px">
                  <asp:TextBox ID="txtouttime" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td class="reportTitleIncome" style="width: 100px">
                  Induction Date</td>
              <td class="Info" style="width: 100px">
                  <asp:Label ID="lblindndate" runat="server"  Width="150px"></asp:Label></td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" style="width: 100px">
                  Emp_Behaviour</td>
              <td class="Info" style="width: 100px">
                  <asp:DropDownList ID="ddlBehaviour" runat="server" SkinID="ddlSkin" Width="150px">
                      <asp:ListItem>NA</asp:ListItem>
                      <asp:ListItem>Excellent</asp:ListItem>
                      <asp:ListItem>Non Co-operative</asp:ListItem>
              
                  </asp:DropDownList></td>
              <td class="reportTitleIncome" style="width: 100px">
                  </td>
              <td class="Info" style="width: 100px">
                  </td>
              <td style="width: 100px">
              </td>
              <td style="width: 100px">
              </td>
          </tr>
          <tr>
              <td class="reportTitleIncome" colspan="6">
                  <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" Width="100px" />
                  <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" Width="100px" />&nbsp;<asp:Button
                      ID="Btncurday" runat="server" OnClick="Btncurday_Click" Width="100px" />
                  <asp:Button ID="Btnpreday" runat="server" OnClick="Btnpreday_Click" Width="100px" /></td>
          </tr>
          <tr>
              <td colspan="6">
                  <asp:Panel ID="Panel1" runat="server">
                      <asp:GridView ID="GvPaMis" runat="server" SkinID="gridviewSkin" OnRowCommand="GvPaMis_RowCommand">
                      <Columns>
                        <asp:TemplateField HeaderText="Edit"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("UID") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                  <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
          </Columns>
                      </asp:GridView>
                  </asp:Panel>
                  <asp:HiddenField ID="HdnUID" runat="server" />
                  <asp:HiddenField ID="HdnUpdate" runat="server" />
                  <asp:HiddenField ID="HdnDate" runat="server" />
              </td>
          </tr>
      </table>
     
  
  
  </fieldset>
    &nbsp; &nbsp; &nbsp;<br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
  </asp:Content>


