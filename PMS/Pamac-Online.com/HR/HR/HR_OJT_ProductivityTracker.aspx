<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true"
    CodeFile="HR_OJT_ProductivityTracker.aspx.cs" Inherits="HR_HR_HR_OJT_ProductivityTracker"
    Title="Daily Updation Productivity Tracker" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>

    <script language="JAVASCRIPT" type="text/javascript"> 



        function CheckAll() 
        {
        
        debugger
        
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

    <fieldset>
        <legend class="FormHeading">Daily Updation Performance / Productivity Tracker</legend>
        <table width="100%">
            <tr>
                <td colspan="2" style="height: 16px">
                    <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"
                        ForeColor="Crimson"></asp:Label></td>
                <td style="height: 16px">
                </td>
                <td style="width: 227px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 92px; height: 21px;">
                    Cluster Name</td>
                <td class="Info" style="width: 228px; height: 21px;">
                    <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster"
                        DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluter_DataBound"
                        OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" SkinID="ddlSkin" Width="164px"
                        Visible="False">
                    </asp:DropDownList><asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged" SkinID="ddlSkin"
                        Width="120px" ValidationGroup="ValDate">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="height: 21px">
                    Centre Name</td>
                <td class="Info" style="width: 227px; height: 21px;">
                    <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre"
                        DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" OnDataBound="ddlCentre_DataBound"
                        OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" SkinID="ddlSkin" Width="164px"
                        ValidationGroup="ValDate">
                    </asp:DropDownList></td>
                <td class="reportTitleIncome" style="width: 103px; height: 21px;">
                    SubCenter Name</td>
                <td align="right" class="Info" style="height: 21px">
                    <asp:DropDownList ID="ddlSubcentre" runat="server" DataSourceID="sdsSubcetre" DataTextField="SubCentreName"
                        DataValueField="SubCentreId" OnDataBound="ddlSubcentre_DataBound" SkinID="ddlSkin"
                        Width="164px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    From Date</td>
                <td class="Info">
                    <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="128px"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
                <td class="reportTitleIncome">
                    To Date</td>
                <td class="Info">
                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="128px"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
                <td align="right">
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome">
                    PAMACian Code</td>
                <td class="Info">
                    <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                <td class="reportTitleIncome">
                    PAMACian Name</td>
                <td class="Info">
                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td align="right">
                </td>
                <td align="right">
                    <asp:Button ID="Button1" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Show"
                        ValidationGroup="ValDate" Width="60px" Visible="False" />&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="Info" colspan="4">
                    &nbsp;
                    <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Search"
                        ValidationGroup="ValDate" Width="123px" />&nbsp;
                    <asp:Button ID="Btnchk" runat="server" OnClick="Btnchk_Click" SkinID="btn" Text="Check Status" />
                    &nbsp; &nbsp;<asp:Button ID="Date" runat="server" Text="Date wise Updation" OnClick="Date_Click"
                        SkinID="btn" Width="147px" Visible="False" />
                    &nbsp; &nbsp;<asp:Button ID="BtnPreviousday" runat="server" OnClick="BtnPreviousday_Click"
                        SkinID="btn" Text="Previous Day" Width="123px" />
                    &nbsp;
                    <asp:Button ID="btnBackUp" runat="server" OnClick="btnBackUp_Click" SkinID="btnSearchSkin"
                        Text="Back Up" ValidationGroup="ValDate" /></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="5" style="width: 934px;">
                    <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort"
                        AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging"
                        AllowPaging="True" PageSize="20">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <!-- <input id="chkSelectAll" type="checkbox" onclick="javascript:CheckAll();" />-->
                                    <input id="chkSelectAll" type="checkbox" />
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
                            <asp:BoundField DataField="Emp_Name" HeaderText="PAMACian">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy}">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESIGNATION" HeaderText="Designation">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Attendence">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlattendance" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlattendance_SelectedIndexChanged" >
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Absent</asp:ListItem>
                                        <asp:ListItem>Leave</asp:ListItem>
                                        <asp:ListItem>Attrited</asp:ListItem>
                                        <asp:ListItem>Present</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Time">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtintime" SkinID="txtSkin" Width="50px" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Time">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtouttime" SkinID="txtSkin" Width="50px" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--New Added--%>
                            <asp:TemplateField HeaderText="Minimum Productivity" ControlStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMinProduct" SkinID="txtSkin" Enabled="false" runat="server" Text='<%#Eval("Min_Productivity") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--END--%>
                            <%--<asp:TemplateField HeaderText="Minimum Productivity">
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
                </asp:TemplateField>--%>
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
                                    <asp:TextBox ID="txtCaseAssigned" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="REVCaseAssign" runat="server" ControlToValidate="txtCaseAssigned" ErrorMessage="*"
                                        ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cases Completed">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCaseCompleted" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD"
                                        OnTextChanged="txtCaseCompleted_TextChanged" AutoPostBack="true"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="REVCasecomp" runat="server" ControlToValidate="txtCaseCompleted" ErrorMessage="*"
                                            ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Error Count">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtErrorCount" SkinID="txtSkin" Width="50px" runat="server" ValidationGroup="VLD"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="RegularExdfdfdpressionValidator1" runat="server" ControlToValidate="txtErrorCount"
                                        ErrorMessage="*" ValidationExpression=".{0,}[0-9].{0,}"></asp:RegularExpressionValidator>
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
                                    <asp:TextBox ID="txtReason" SkinID="txtSkin" Width="100px" runat="server" ValidationGroup="VLD"
                                        TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" OnClick="btnSave_Click"
                        ValidationGroup="VLD" />&nbsp;
                    <asp:Button ID="btnCan" runat="server" Font-Bold="True" Text="Cancel" OnClick="btnCan_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:SqlDataSource ID="sdsSubcetre" runat="server" ProviderName="System.Data.OleDb">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCentre" runat="server" ProviderName="System.Data.OleDb"></asp:SqlDataSource>
    <asp:HiddenField ID="hdnEmpId" runat="server" />
    <asp:HiddenField ID="hdnEmpCode" runat="server" />
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
    <asp:SqlDataSource ID="sdsCluster" runat="server" ProviderName="System.Data.OleDb"
        SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME">
    </asp:SqlDataSource>
    &nbsp; &nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="ReqCluster" runat="server" ErrorMessage="Please select the Cluster"
        ControlToValidate="ddlclustername" Display="None" SetFocusOnError="True" ValidationGroup="ValDate"
        InitialValue="0">
    </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="ReqCentre" runat="server" ErrorMessage="Please select the Centre"
        ControlToValidate="ddlCentre" Display="None" SetFocusOnError="True" ValidationGroup="ValDate"
        InitialValue="0">
    </asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="ValDate" />
    <%--ValidationGroup="VLD"--%>
    &nbsp;
</asp:Content>
