<%@ Page Language="C#" MasterPageFile="~/BGC/BGC/MasterPage.master" AutoEventWireup="true" CodeFile="BGC_Export.aspx.cs" Inherits="BGC_BGC_BGC_Export" Title="Untitled Page" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript">
      
         function openwindow(imgType)
        {        
            
           var hidCaseID=document.getElementById("<%=hidCaseID.ClientID%>");
           var hidVerificationTypeID=document.getElementById("<%=hidVerificationTypeID.ClientID%>");
          
            window.open('EBC_RenderImage.aspx?CaseId='+hidCaseID.value +'&Veri='+hidVerificationTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
        </script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td align="center" style="height: 269px">
<fieldset><legend class="FormHeading">Export</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td style="height: 14px">&nbsp; &nbsp; &nbsp; &nbsp;</td></tr>
<tr><td style="height: 6px">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
    <tr><td align="left" valign="top" style="width: 57px">From</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]</td>
    <td align="left" valign="top">To</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" style="width: 602px" >
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>       
    <td align="left" valign="top" >
        <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="vgrpExcelReport" Visible="False" />
        </td>
    </tr> 
    <tr>
        <td align="left" style="width: 57px; height: 22px" valign="top">
            Location</td>
        <td align="left" style="height: 22px" valign="top">
        </td>
        <td align="left" style="height: 22px" valign="top">
            <asp:DropDownList ID="ddrlocation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddrlocation_SelectedIndexChanged"
                SkinID="ddlSkin" Width="179px">
            </asp:DropDownList></td>
        <td align="left" style="height: 22px" valign="top">
            Client</td>
        <td align="left" style="height: 22px" valign="top">
        </td>
        <td align="left" style="width: 602px; height: 22px" valign="top">
            <asp:DropDownList ID="ddrclient" runat="server" SkinID="ddlSkin" Width="153px">
            </asp:DropDownList></td>
        <td align="left" style="height: 22px" valign="top">
        </td>
    </tr>
    <tr>
        <td align="left" style="width: 57px; height: 22px" valign="top">
            Report</td>
        <td align="left" style="height: 22px" valign="top">
        </td>
        <td align="left" style="height: 22px" valign="top">
            <asp:DropDownList ID="ddrreport" runat="server" Width="179px" AutoPostBack="True" SkinID="ddlSkin">
                <asp:ListItem Value="sp_EbcPendingReport">Pending Report</asp:ListItem>       
                <asp:ListItem Value="sp_EbcErrorReport">Error Report</asp:ListItem>
                <asp:ListItem Value="sp_OutputFormatEBC">Export Report</asp:ListItem>
                <asp:ListItem Value="sp_EbcTATMIS">TAT MIS</asp:ListItem>
                <asp:ListItem Value="sp_EbcTATMISDate">TAT MIS Datewise</asp:ListItem>
                <asp:ListItem Value="sp_EbcBillingMIS">FE Payout MIS</asp:ListItem>
                <asp:ListItem Value="sp_OutputFormatEBCPDF1">Export Images</asp:ListItem>             
                
                
            </asp:DropDownList></td>
        <td align="left" style="height: 22px" valign="top">
        </td>
        <td align="left" style="height: 22px" valign="top">
        </td>
        <td align="left" style="width: 602px; height: 22px" valign="top">
        <asp:Button ID="btnrpt" runat="server" OnClick="btnrpt_Click" Text="Generate Report"
            Width="110px" SkinID="btn" ValidationGroup="vgrpExcelReport" /></td>
        <td align="left" style="height: 22px" valign="top">
        </td>
    </tr>
    <tr><td colspan="7" align="left" style="height: 14px">
    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Text=""></asp:Label>
        </td></tr>  
    </table>
    <br />
    
<%--    <asp:Panel ID="pnlgrvannexure" runat="server" Height="50px" Width="125px">--%>
    <asp:GridView ID="grv_annexure" runat="server" OnRowCommand="grv_annexure_RowCommand1"
        SkinID="gridviewNoSort" Width="175px" >
        <Columns>
            <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdownloadAnnexure" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="download"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkimg1" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="image1" Text="Image1">                      
                        
                        
                        </asp:LinkButton>  
                        
                         <%--<a href="javascript:openwindow('1');" title="View Uploaded Image1">View Uploaded Image1</a>   --%>                
                        
                </ItemTemplate>
            </asp:TemplateField>
            
               <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkimg2" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="image2" Text="Image2">                       
                       
                        
                        </asp:LinkButton>  
                         <%-- <a href="javascript:openwindow('2');" title="View Uploaded Image2">View Uploaded Image2</a>  --%>
                                      
                        
                </ItemTemplate>
            </asp:TemplateField>
            
               <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                  <asp:LinkButton ID="lnkimg3" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="image3" Text="Image3">
                        
                      
                        
                        </asp:LinkButton>     
                           <%--<a href="javascript:openwindow('3');" title="View Uploaded Image3">View Uploaded Image3</a> --%>              
                        
                </ItemTemplate>
            </asp:TemplateField>
            
            
               <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkimg4" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="image4" Text="Image4">
                        
                        
                        
                        </asp:LinkButton>     
                        <%-- <a href="javascript:openwindow('4');" title="View Uploaded Image4">View Uploaded Image4</a>   --%>            
                        
                </ItemTemplate>
            </asp:TemplateField>
            
               <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkimg5" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                        CommandName="image5" Text="Image5">
                  
                        
                        </asp:LinkButton>    
                              
                        <%-- <a href="javascript:openwindow('5');" title="View Uploaded Image5">View Uploaded Image5</a> --%>              
                        
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>   
<%--    </asp:Panel>--%>
    
     <br />
     
    <%--<asp:Panel ID="pngrdvwFGB" runat="server" Height="50px" Width="125px">  --%>   
    <asp:GridView ID="grdvwFGB" runat="server">      
    </asp:GridView>
 <%--   </asp:Panel>--%>
    &nbsp; &nbsp;
    &nbsp;
    &nbsp;&nbsp;
    </td></tr>
    <asp:Panel ID="pnlView" runat="server" Visible="false">
    <tr><td align="left">
        <asp:Label ID="lblCaseCount" runat="server" Text="" Font-Bold="true"></asp:Label>
    </td></tr>
    <tr><td align="right">
        <asp:Button ID="btnGenrate_Report" runat="server" Text="Genrate Report"  SkinID="btnGenerateReportSkin"  OnClick="btnGenrate_Report_Click" ValidationGroup="vgrpExcelReport" />
        <asp:Button ID="btnReport1" runat="server" Text="Generate Excel Report" Visible="false" SkinID="btnGenerateExcelReportSkin" OnClick="btnReport_Click" ValidationGroup="vgrpExcelReport" /></td></tr>

    <tr><td>
     
        <asp:SqlDataSource ID="sdsOutput" runat="server" 
            SelectCommand="SELECT CD.[CASE_ID], ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [APPLICANT_NAME],  Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5)  + RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME],  Convert(varchar(24),CD.SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3))as [SEND_DATETIME],VM.VERIFICATION_TYPE_CODE AS VERIFICATION_CODE FROM [CPV_EBC_CASE_DETAILS] CD INNER JOIN CPV_EBC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID= VM.VERIFICATION_TYPE_ID  WHERE (SEND_DATETIME IS NOT NULL) AND (CD.CASE_STATUS_ID IS NOT NULL) AND (CENTRE_ID = ?) AND (CLIENT_ID = ?) AND (SEND_DATETIME >= ?) AND (SEND_DATETIME < ?) ORDER BY cd.CASE_ID" 
                    ProviderName="System.Data.OleDb">
            <SelectParameters>
                <asp:SessionParameter Name="CENTRE_ID" SessionField="CentreId" Type="String" />
                <asp:SessionParameter Name="CLIENT_ID" SessionField="ClientId" Type="String" /> 
                <asp:ControlParameter ControlID="hdFromDate" Name="FromDate" PropertyName="Value" />
                <asp:ControlParameter ControlID="hdToDate" Name="ToDate" PropertyName="Value" />                     
            </SelectParameters>
        </asp:SqlDataSource>
    </td></tr>
    
    <tr><td align="right">
        <asp:Button ID="btnGenrate_Report1"  runat="server" Text="Genrate Report" SkinID="btnGenerateReportSkin" OnClick="btnGenrate_Report_Click" ValidationGroup="vgrpExcelReport" />    
        <asp:Button ID="btnReport" runat="server" Visible="false"  Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnReport_Click" ValidationGroup="vgrpExcelReport" />
        <asp:HiddenField ID="hdFromDate" runat="server" />
        <asp:HiddenField ID="hdToDate" runat="server" />      
    </td></tr>
                            
 </asp:Panel>
</table></fieldset>
</td></tr>
</table>

    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter From Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter To Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>&nbsp;
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport" />
    <script type="text/javascript" language="javascript">
            <!--
               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }
            -->
    </script>

    &nbsp;&nbsp;
    <asp:HiddenField ID="hdnAnnexure" runat="server" />
    <asp:HiddenField ID="hdnDestPath" runat="server" />
    <asp:HiddenField ID="hidCaseID" runat="server" />
                                <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                <asp:HiddenField ID="hidMode" runat="server" />
                                <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
</asp:Content>

