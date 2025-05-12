<%@ Page Language="C#" MasterPageFile="~/DCR/DCR/DCR_MasterPage.master" AutoEventWireup="true" CodeFile="REPORT.aspx.cs" Inherits="DCR_DCR_REPORT" Title="Untitled Page" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<asp:Panel ID="pnlCategory" runat="server" Height="50px" Width="800px">
<table style="width: 800px">
<tr>
            <td class="tta" colspan="8" style="width: 80%;">
                <span style="font-size: 10pt"> EXPORT REPORT&nbsp;</span></td>
                
        </tr>
    <tr>
        <td colspan="8" style="width: 80%; height: 19px">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Width="780px" ForeColor="Red" Font-Bold="True"></asp:Label></td>
    </tr>
        </table>
    <table style="width: 800px; height: 84px">
        <tr>
            <td align="left" valign="top" style="width: 100px;" class="Info">
            <asp:RadioButton ID="rdoFromToDate" runat="server" Checked="true" GroupName="SelectDateCriteria" Width="111px"
                /></td>
           
            <td style="width: 35px;" class="reportTitleIncome">
                <strong>From</strong></td>
        <td align="left" valign="top" class="Info" style="width: 172px;" >
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"  Width="70px"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]</td>
            <td style="width: 35px;" class="reportTitleIncome">
                <strong>To</strong></td>
            <td align="left" valign="top" class="Info" style="width: 172px;" >
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="70px"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]</td>       
        </tr>
        <tr>
                    <td align="left" valign="top" style="width: 100px;" class="Info" >
            <asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria" Width="111px"/></td>
            <td style="width: 35px;" class="reportTitleIncome">
                <strong>Date</strong></td>
           <td align="left" valign="top" class="Info" style="width: 172px;" >
            <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="70px" ></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]</td>
            <td style="width: 35px;" class="reportTitleIncome">
                <strong>Time</strong></td>
              <td align="left" valign="top" class="Info" style="width: 172px;" >
            <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Width="50px" ></asp:TextBox>
            <asp:DropDownList
                ID="ddlTimeType" runat="server" SkinID="ddlSkin" Height="17px"  Width="44px">
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList></td>&nbsp;&nbsp;
        </tr>
        <tr>
            <td align="left" class="Info" colspan="5" valign="top">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnsearch" runat="server" Text="Search" Width="113px" SkinID="btnSearchSkin" /></td>
        </tr>

    </table> <table id="tblViewDetail" runat="server" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="TDWidth" colspan="3" style="width: 946px">
                <table id="tblCaseCount" runat="server" visible="false" width="100%">
                    <tr><td colspan="4" style="height: 5px">
                    <asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink>
                    </td></tr>
                    <tr>
                        <td align="right" valign="top" colspan="4">
                            &nbsp;<strong>Select format:</strong>
                            <asp:DropDownList ID="ddlSelectFormat1" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat1"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="btnExport1" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a" /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:GridView ID="gvOutput" runat="server" Width="292px">
                            </asp:GridView>
                            <asp:GridView ID="grdvwFGB" runat="server" Width="290px">
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <strong>Select format : </strong><asp:DropDownList ID="ddlSelectFormat" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="btnExport" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a"   />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <asp:HiddenField ID="hdFromDate" runat="server" />
                            <asp:SqlDataSource ID="sdsSelectFormat" runat="server" 
               ProviderName="System.Data.OleDb"
              SelectCommand="SELECT '0' as TEMPLATE_ID,'Select' as TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER
                            UNION 
                            SELECT ETM.TEMPLATE_ID,TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER ETM INNER JOIN 
                            EXPORT_TEMPLATE_DETAIL ETD ON ETM.TEMPLATE_ID=ETD.TEMPLATE_ID                             
                            WHERE ([PRODUCT_ID] = ?) and ([CLIENT_ID] = ?)">
          <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
            <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" /> 
          </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsSelectFormat1" runat="server" 
              ProviderName="System.Data.OleDb"
              SelectCommand="SELECT '0' as TEMPLATE_ID,'Select' as TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER
                            UNION 
                            SELECT ETM.TEMPLATE_ID,TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER ETM INNER JOIN 
                            EXPORT_TEMPLATE_DETAIL ETD ON ETM.TEMPLATE_ID=ETD.TEMPLATE_ID                             
                            WHERE ([PRODUCT_ID] = ?) and ([CLIENT_ID] = ?)">
          <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
            <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" /> 
          </SelectParameters>
        </asp:SqlDataSource>
                            <asp:HiddenField ID="hdnDestPath" runat="server" />
                            <asp:HiddenField ID="hdToDate" runat="server" />
                            <asp:SqlDataSource ID="SqlDataSourceDate" runat="server"  
                            ProviderName="System.Data.OleDb"
                            SelectCommand="SELECT CASE_ID, replace(replace(REF_NO,'/','_'),'\','_') as[REF_NO], ISNULL(FIRST_NAME + ' ', '') + ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS APPLICANT_NAME, VERIFICATION_CODE, CONVERT (varchar(24), CASE_REC_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 3)) AS CASE_REC_DATETIME, CONVERT (varchar(24), SEND_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), SEND_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), SEND_DATETIME, 22), 3)) AS SEND_DATETIME,App_Type FROM CPV_RL_CASE_DETAILS WHERE (SEND_DATETIME IS NOT NULL) AND (CENTRE_ID = ?) AND (CLIENT_ID = ?) AND (SEND_DATETIME >= ?) AND (SEND_DATETIME < ?) ORDER BY Ref_No">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Centre_Id" SessionField="CentreId" />
                                    <asp:SessionParameter Name="Client_Id" SessionField="ClientId" />
                                    <asp:ControlParameter ControlID="hdFromDate" Name="FromDate" PropertyName="Value" />
                                    <asp:ControlParameter ControlID="hdToDate" Name="ToDate" PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
    
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport" />
        <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
            Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
            ID="revTime" runat="server" ControlToValidate="txtTime" Display="None" ErrorMessage="Please enter valid time format."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:CustomValidator ID="cvDateTime" runat="server" Display="None" ErrorMessage="Please select both date and time."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator><asp:CustomValidator ID="cvFromToDateTime" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td class="TDWidth" colspan="3" style="width: 946px">
        <asp:ValidationSummary ID="valSelectFormat1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport1" />
                &nbsp;
                <asp:CustomValidator ID="CustomValidator_Export" runat="server" ClientValidationFunction="ExportValidation"
                    Display="None" ErrorMessage="Select Format..." ValidationGroup="a"></asp:CustomValidator>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="a" />       
            </td>
        </tr>
    </table>
        </asp:Panel>



</asp:Content>
