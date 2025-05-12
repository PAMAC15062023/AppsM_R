<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" CodeFile="HR_SalaryView.aspx.cs" Inherits="HR_HR_HR_SalaryView" Title="Salary Status View" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset><legend class="FormHeading">Salary Status View</legend>

    <table>
        <tr>
            <td colspan="9" style="text-align: left">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 14px; height: 44px;">
            </td>
            <td style="width: 93px; height: 44px;" class="TDBGColor">
                <strong>Month </strong>
            </td>
            <td style="width: 100px; height: 44px;">
                <asp:DropDownList ID="ddlMonth" runat="server" Width="140px" SkinID="ddlSkin">
                    <asp:ListItem Value="00">--All--</asp:ListItem>
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 44px;">
            </td>
            <td style="width: 102px; height: 44px;">
                &nbsp;<asp:DropDownList ID="ddlEmpName" runat="server" AutoPostBack="True" CssClass="combo"
                    DataSourceID="sdsEmp" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlEmpName_DataBound" SkinID="ddlSkin" Width="152px" Visible="False">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 44px;">
                <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" /></td>
            <td style="width: 100px; height: 44px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="False" /></td>
            <td style="width: 100px; height: 44px;">
                <asp:SqlDataSource ID="sdsEmp" runat="server" ProviderName="System.Data.OleDb" SelectCommand="SELECT EMP_ID, EMP_CODE, (Emp_Code +'  '+ FULLNAME) as FULLNAME FROM EMPLOYEE_MASTER WHERE (CENTRE_ID = ?)  and dol is null ORDER BY FULLNAME">
                    <SelectParameters>
                        <asp:SessionParameter Name="?" SessionField="CENTREID" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td style="width: 100px; height: 44px;">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 16px">
            </td>
            <td style="width: 93px; height: 16px" class="TDBGColor">
                <strong>Year</strong></td>
            <td style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlYear" runat="server" DataTextField="Year" DataValueField="Year" SkinID="ddlSkin" Width="139px">
                
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 102px; height: 16px">
                <strong><asp:LinkButton ID="linkInc" runat="server" OnClick="linkInc_Click" Visible="False">Increment Letter</asp:LinkButton></strong></td>

            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 36px">
                &nbsp;<asp:Button ID="btnFind" runat="server" Text="Search" Width="127px" OnClick="btnFind_Click1" Font-Bold="True" Height="36px" SkinID="btnSearchSkin" BackColor="Silver"/></td>
        </tr>
        <tr>
            <td colspan="9" style="height: 17px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" style="width: 14px">
            </td>
            <td colspan="8">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="930px" Height="226px">
                    &nbsp;<asp:GridView ID="GV1" runat="server" Width="731px" AutoGenerateColumns="False" OnRowDataBound="GV1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" SkinID="gridviewExportSkin">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" ToolTip="Select for Salary Print Request" />
                            </ItemTemplate>
                          
                            <FooterStyle ForeColor="White" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Print">
                            <ItemTemplate>
                      <asp:LinkButton ID="lnkPrint" CommandArgument='<%# (DataBinder.Eval(Container.DataItem,"UID"))%>'  runat="server" OnClick="lnkPrint_Click">Print</asp:LinkButton>
                            </ItemTemplate>
                              
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emp_Code" HeaderText="Emp Code" >
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="Month_of_PaySlip" HeaderText="Month of PaySlip" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Salary_Year" HeaderText="Salary Year" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Earning_Basic_Earned" HeaderText="Basic Salary" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Days_In_Month" HeaderText="Day of Month" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Present" HeaderText="Present" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Absent" HeaderText="Absent" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Remaining_PL" HeaderText="PL" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Remaining_SL" HeaderText="SL" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Remaining_CL" HeaderText="CL" >
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="Adjusted__PL" HeaderText="Adj-PL" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Adjusted_SL" HeaderText="Adj-SL" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Adjusted_CL" HeaderText="Adj-CL" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Basic_Earned" HeaderText="Basic Earn" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="DA_Earned" HeaderText="DA" >
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="HRA_Earned" HeaderText="HRA" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Convenyance_Allowance" HeaderText="Convenyance" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Derived_Incentives" HeaderText="Derived Incentives" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Other_Allowance" HeaderText="Other Allowance" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="LTA" HeaderText="LTA" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="OT_Earning" HeaderText="OT" >
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="Provident_Fund" HeaderText="PF" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="ESIC" HeaderText="ESIC" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="Professional_Tax" HeaderText="PT" >
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="Income_Tax" HeaderText="IT" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="TDS" HeaderText="TDS" >
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="Salary_Advance" HeaderText="Adv Salary" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Other_Deduction" HeaderText="Oth Deduction" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Loan_Deduction" HeaderText="Loan Deduc" >
                        
                        </asp:BoundField>
                        <asp:BoundField DataField="Insurance_Deduction" HeaderText="Insurance Deduc" >
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="Fix_Deduction" HeaderText="Fix Deduc" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="LWF" HeaderText="LWF" >
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Gross_Earning" HeaderText="Gross Earn" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="Gross_Deduction" HeaderText="Gross Deduc" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="Net_Salary" HeaderText="Net Salary" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="Designation" HeaderText="Designation" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PF_No" HeaderText="PF No" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="OTWorking" HeaderText="OT" >
                            
                        </asp:BoundField>
                         <asp:BoundField DataField="Medical_Reimbush" HeaderText="MedicalReimbush" >
                            
                        </asp:BoundField>
                         <asp:BoundField DataField="Washing" HeaderText="Washing" >
                            
                        </asp:BoundField>
                         <asp:BoundField DataField="Net_Salary_In_Word" HeaderText="Net_Salary_In_Word" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="Emp_Type" HeaderText="Category" >
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="RequestDate" HeaderText="RequestDate">
                            
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 93px" class="TDBGColor">
                &nbsp; <strong>Remark</strong></td>
            <td colspan="3">
                <asp:TextBox ID="txtAppReq" runat="server" Width="418px" Height="35px" MaxLength="100" TextMode="MultiLine" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnAppReq" runat="server" Text="Request For Print" Width="146px" OnClick="btnAppReq_Click" Font-Bold="True" Height="36px" BackColor="Silver" /></td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
                <asp:Button ID="btnGen" runat="server" OnClick="btnGen_Click" Text="Genrate Excel" BackColor="Silver" Font-Bold="True" Height="36px" Width="140px" Visible="False" /></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px; height: 52px;">
            </td>
            <td style="width: 93px; height: 52px;">
                &nbsp;<asp:HiddenField ID="HFuid" runat="server"/>
            </td>
            <td style="width: 100px; height: 52px;">
                <asp:HiddenField ID="hdnempid" runat="server" />
            </td>
            <td style="width: 100px; height: 52px;">
            </td>
            <td style="width: 102px; height: 52px;">
            </td>
            <td style="width: 100px; height: 52px;">
            </td>
            <td style="width: 100px; height: 52px;">
            </td>
            <td style="width: 100px; height: 52px;">
            </td>
            <td style="width: 100px; height: 52px;">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 93px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 102px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 93px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 102px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 93px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 102px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 14px">
            </td>
            <td style="width: 93px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 102px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    
    </fieldset> 
<table border="0" id="tblExport" runat="server"  visible="true" width="100%">
<tr><td>
    &nbsp;&nbsp;
    <asp:GridView ID="GV2" runat="server" Visible="false" AutoGenerateColumns="True" SkinID="gridviewNoSort"
        Width="99%">
    </asp:GridView>
</td>
</tr>
</table>  
</asp:Content>

