<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_New_Employment_Verification.aspx.cs" Inherits="EBC_New_EBC_New_EBC_New_Employment_Verification" Title="Employment Verification" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function openwindow(imgType)
        {        
            
           var hdnCaseID=document.getElementById("<%=hdnCaseID.ClientID%>");
           var hdnMainVerifyID=document.getElementById("<%=hdnMainVerifyID.ClientID%>");
           var hdnSubVerifyTypeID=document.getElementById("<%=ddlSubVerificationType.ClientID%>"); 
          
            window.open('EBC_RenderImage.aspx?CaseId='+hdnCaseID.value +'&Veri='+hdnMainVerifyID.value+'&SubVeri='+hdnSubVerifyTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
        function SaveValidationControl()
                {
                    var ddlOverallVerification=document.getElementById("<%=ddlOverallVerification.ClientID%>");
                    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
                    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
                    
                    var ReturnValue=true;
                    var ErrorMsg="";
                    
                    if(ddlOverallVerification.selectedIndex==0)
                    {
                        ErrorMsg='Please Select Atleast one Verification Status......!!!!!';
                        ReturnValue=false;
                        ddlOverallVerification.focus();
                    }
                    if(txtRemark.value=='')
                    {
                        ErrorMsg='Please write Remark......!!!!!';
                        ReturnValue=false;
                        txtRemark.focus();
                    }
                    
                    lblMessage.innerText=ErrorMsg;
                   if(ErrorMsg!='')
                    {
                        window.scrollTo(0,0);
                    }
                           return ReturnValue;     
                }                       
</script>


    <table>
        <tr>
            <td colspan="9">
                &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 17px">
                &nbsp;Employee Basic Details</td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Case ID</td>
            <td colspan="2" class="Info">
                <asp:TextBox ID="txtCaseID" runat="server" Width="200px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Client Ref No</td>
            <td colspan="2" class="Info">
                <asp:TextBox ID="txtRefNo" runat="server" Width="200px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                <asp:Label ID="Label1" runat="server" Text="Name Of Employee" Width="148px"></asp:Label></td>
            <td colspan="2" class="Info">
                <asp:TextBox ID="txtNameofEmployee" runat="server" Width="200px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px; height: 8px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 8px;">
                Received Date</td>
            <td class="Info" colspan="2" style="height: 8px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 106px">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtCaseRecvDate" runat="server" Width="69px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 100px">
                            <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.png"  /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Sub Verification Type</td>
            <td class="Info" colspan="2">
                <asp:DropDownList ID="ddlSubVerificationType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubVerificationType_SelectedIndexChanged" Width="136px" SkinID="ddlSkin">
                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                </asp:DropDownList></td>
            <td colspan="5">
                <asp:Label ID="lblWait" runat="server" ForeColor="Red" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 16px;" class="tta" colspan="9">
                &nbsp;Verification Details</td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Comany Name</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtCompanyName" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 30px;">
                Company Contact</td>
            <td class="Info" colspan="2" style="height: 30px">
                <asp:TextBox ID="txtCompanyContact" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td style="width: 181px" class="reportTitleIncome">
                Company Address</td>
            <td class="Info" colspan="6">
                <asp:TextBox ID="txtCompanyAddress" runat="server" TextMode="MultiLine" Width="558px" SkinID="txtSkin" MaxLength="150"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 15px">
                &nbsp;Repondent Details</td>
        </tr>
        <tr>
            <td style="width: 9px">
                &nbsp;
            </td>
            <td style="width: 181px" class="reportTitleIncome">
                Respondent Name</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtRespondentName" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Respondent Designation</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtRespondentDesignation" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Respondent Contact Number</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtRespondentContactNumber" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Employee Designation</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtEmployeeDesignation" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Last CTC</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtLastCTC" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Period of Employment</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtPeriodofEmployment" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Reason for Leaving</td>
            <td class="Info" colspan="6">
                <asp:TextBox ID="txtReasonForLeaving" runat="server" Width="566px" SkinID="txtSkin" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Performance of the Employee</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtPerformanceOfTheEmployee" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Any Interigrity Issue</td>
            <td class="Info" colspan="2">
                <asp:TextBox ID="txtAnyInterigrityIssue" runat="server" Width="200px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Proper Releaving</td>
            <td class="Info" colspan="2">
                <asp:DropDownList ID="ddlProperReleaving" runat="server" Width="136px" SkinID="ddlSkin">
                <asp:ListItem>-Select-</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px">
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
            <td style="width: 9px">
            </td>
            <td class="reportTitleIncome" style="width: 181px">
                Remarks</td>
            <td class="Info" colspan="6">
            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="650px" SkinID="txtSkin" Height="90px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 27px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 27px;">
                Date Of Verification</td>
            <td class="Info" style="width: 96px; height: 27px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtDateOfVerification" runat="server" Width="150px" TabIndex="17" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 100px">
                            &nbsp;<img id="imgDateOfVerification"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" colspan="2" style="height: 27px">
                &nbsp;Time Of Verification</td>
            <td class="Info" colspan="3" style="height: 27px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 84px">
                    <tr>
                        <td style="width: 61px">
                <asp:TextBox ID="txtTimeOfVerification" runat="server" Width="32px" TabIndex="18" SkinID="txtSkin" MaxLength="6"></asp:TextBox></td>
                        <td style="width: 100px">
                [hh:mm]</td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 30px;">
            Overall Verification</td>
            <td class="Info" colspan="2" style="height: 30px">
            <asp:DropDownList ID="ddlOverallVerification" runat="server" Width="136px" SkinID="ddlSkin">
                <asp:ListItem>-Select-</asp:ListItem>
                <asp:ListItem>Positive</asp:ListItem>
                <asp:ListItem>Negative</asp:ListItem>
                <asp:ListItem>Discrepant</asp:ListItem>
                <asp:ListItem>UTV</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 27px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 27px;">
                Field Executive's Name</td>
            <td class="Info" colspan="2" style="height: 27px">
                <asp:TextBox ID="txtFEName" runat="server" Width="200px" TabIndex="19" Height="17px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
            <td style="width: 100px; height: 27px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 17px;">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 17px;">
                Supervisor's Name</td>
            <td class="Info" colspan="2" style="height: 17px">
                <asp:TextBox ID="txtSupervisorName" runat="server" Width="200px" TabIndex="20" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 17px;">
            </td>
            <td style="width: 100px; height: 17px;">
            </td>
            <td style="width: 100px; height: 17px;">
            </td>
            <td style="width: 100px; height: 17px;">
            </td>
            <td style="width: 100px; height: 17px;">
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 24px">
            </td>
            <td class="reportTitleIncome" style="width: 181px; height: 24px">
                            Upload Attachment</td>
            <td class="Info" colspan="7" style="height: 24px">
                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="70%" />
                <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                View Uploaded Attachment</span></a>
            </td>
        </tr>
        <tr>
            <td style="width: 9px; height: 21px;">
            </td>
            <td colspan="8" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="9" style="height: 30px">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Font-Bold="True" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Font-Bold="True" /></td>
        </tr>
        <tr>
            <td colspan="9" style="height: 93px">
            <asp:HiddenField ID="hdnCaseID" runat="server" />
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 9px">
            </td>
            <td style="width: 181px">
            </td>
            <td style="width: 96px">
            </td>
            <td style="width: 56px">
            </td>
            <td style="width: 100px">
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

</asp:Content>

