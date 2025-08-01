<%@ Page Language="C#" MasterPageFile="~/HDFC/HDFC/MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="KYC_CaseView.aspx.cs" Inherits="KYC_KYC_CaseView"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function datevalidation()
{

var text1=(document.getElementById("<%=txtFromDate.ClientID%>")).value;
var text2=(document.getElementById("<%=txtToDate.ClientID%>")).value;

if(text1!="" && text2=="")
{
    alert("Please enter To date");
    return false;
}
if(text2!="" && text1=="")
{
    alert("Please enter From date");
    return false;
}
}
</script>
<fieldset ><legend class="FormHeading">View Cases</legend>
  <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
         
      <tr>
          <td>
          </td>
          <td>
          <table id="tblKYC" width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
              <td>
                </td>
          </tr> 
          <tr><td><br /><table border="0" cellpadding="0" cellspacing="0" id="tblCCSearch" width="100%">
              <tr>
                  <td >
                      </td>
                  <td>
                      <asp:TextBox ID="txtRefNo" MaxLength="50" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                  <td>
                      </td>
                  <td>
                      <asp:TextBox ID="txtName" MaxLength="200" runat="server" SkinID="txtSkin" Enabled="False" Visible="False"></asp:TextBox></td>
                  <td><asp:CheckBox id="chkName" runat="server"  SkinID="chkSkin" Text="Absolute" Visible="False" ></asp:CheckBox> </td>
                  <td>
                  </td>
              </tr>
              <tr>
                  <td>
                      From Date</td>
                  <td  >
                      <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                      <img id="imgRecDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                          src="../../Images/SmallCalendar.gif" />
                  </td>
                  <td>
                      To Date</td>
                  <td  >
                      <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                      <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                          src="../../Images/SmallCalendar.gif" /></td>
                  <td>
                      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="btnSearchSkin"
                          Text="Search" ValidationGroup="grpValidate" OnClientClick="return datevalidation();"/></td>
                  <td >
                      <asp:Button ID="btnNewCase" runat="server" OnClick="btnNewCase_Click" SkinID="btnAddNewSkin"
                          Text="New Case" />
                  </td>
              </tr>
          </table>
          </td>
          </tr>
              <tr>
                  <td>
                      <table id="tblKYCView" width="100%">
          <tr><td>
              <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label></td></tr>
          <tr><td>
              <asp:GridView ID="gvKYC" AllowPaging="True" PageSize="15" DataSourceID="sdsKYC" runat="server" AutoGenerateColumns="False" OnRowCommand="gvKYC_RowCommand" OnRowDataBound="gvKYC_RowDataBound" SkinID="gridviewSkin">
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID"  />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" />
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"/>
                      <asp:BoundField ReadOnly="True" DataField="Department" HeaderText="Department"  />
                      <asp:BoundField ReadOnly="True" DataField="Designation" HeaderText="Designation"  />
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditKYC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="Edit" meta:resourcekey="lnkEditKYCResource1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteKYC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="DeleteKYC" meta:resourcekey="lnkDeleteKYCResource1" Enabled="False" Visible="False" ><img src="../../Images/icon_delete.gif" alt="Delete" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                  </Columns>                 
              </asp:GridView>
              </td></tr>
                      </table>
                  </td>
              </tr>
              
              </table>
              
          </td>
          <td>
          </td>
      </tr>
                <tr>
                    <td >
                    </td>
                    <td >
                        <asp:SqlDataSource ID="sdsKYC" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT Case_ID,REF_NO,CASE_REC_DATETIME, TITLE, (isnull(FIRST_NAME,'')+' '+ isnull(MIDDLE_NAME,'')+' '+ isnull(LAST_NAME,'')) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT FROM CPV_KYC_CASE_DETAILS where  ([Centre_ID]=? and [Client_ID]=? and [Add_By]=? And Ref_no=?  And (Authorized='N' Or Authorized is NULL) And send_datetime is null) "
                     >
                        <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />  
               <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />                          
                            <asp:SessionParameter Name="Add_By" SessionField="UserID" />
                            <asp:SessionParameter Name="Ref_no" SessionField="Branch_Code" />
        </SelectParameters> 
                    </asp:SqlDataSource>
                        <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
                            Display="None" ErrorMessage="Please enter valid Date Format for From Date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate" ></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revT0Date" runat="server" ControlToValidate="txtToDate"
                            Display="None" ErrorMessage="Please enter valid Date Format for To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate" ></asp:RegularExpressionValidator></td>
                            <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                    <td >
                    </td>
                </tr>
            </table>
            </fieldset >
</asp:Content>


