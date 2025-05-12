<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true"
    CodeFile="EBC_New_Educational_Check.aspx.cs" Inherits="EBC_New_EBC_New_EBC_New_Educational_Check"
    Title="Educational Check" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js">
 {

}
</script>

<script language="javascript" type="text/javascript">
   function openwindow(imgType)
        {        
            
           var hdnCaseID=document.getElementById("<%=hdnCaseID.ClientID%>");
           var hdnMainVerifyID=document.getElementById("<%=hdnMainVerifyID.ClientID%>");
           var hdnSubVerifyTypeID=document.getElementById("<%=ddlVerificationType.ClientID%>"); 
          
            window.open('EBC_RenderImage.aspx?CaseId='+hdnCaseID.value +'&Veri='+hdnMainVerifyID.value+'&SubVeri='+hdnSubVerifyTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
        function SaveValidationControl()
                {
                    var ddlStatus=document.getElementById("<%=ddlStatus.ClientID%>");
                    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
                    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
                    
                    var ReturnValue=true;
                    var ErrorMsg="";
                    
                    if(ddlStatus.selectedIndex==0)
                    {
                        ErrorMsg='Please Select Atleast one Verification Status......!!!!!';
                        ReturnValue=false;
                        ddlStatus.focus();
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
    
        <table id="TABLE1" class="bx" style="width: 100%" border="0" cellpadding="0" cellspacing="2"  >
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="ErrorMessage"></asp:Label></td>
            </tr>
            <tr>
                <td class="tta" colspan="6" style="height: 22px">
                    &nbsp;Education Background Check</td>
            </tr>
            <tr>
                <td colspan="6">
                <asp:Label ID="lblWait" runat="server" Width="152px" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td style="width: 150px" class="reportTitleIncome">
                    <asp:Label ID="Label1" runat="server" Text="Case ID" Width="163px"></asp:Label></td>
                <td class="Info">
                    <asp:TextBox ID="txtCaseID" runat="server" Width="250px" ReadOnly="True" TabIndex="4"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td style="width: 150px" class="reportTitleIncome">
                    Client Ref.Name</td>
                <td class="Info">
                    <asp:TextBox ID="txtClientRefNo" runat="server" Width="250px" ReadOnly="True" TabIndex="2"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td style="width: 150px" class="reportTitleIncome">
                    Name of Employee</td>
                <td class="Info">
                    <asp:TextBox ID="txtNameOfEmployee" runat="server" Width="250px" Height="15px" ReadOnly="True"
                        TabIndex="1" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="height: 23px; width: 9px;">
                </td>
                <td style="width: 150px; height: 23px;" class="reportTitleIncome">
                    Recieved Date</td>
                <td class="Info" style="height: 23px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 103px">
                        <tr>
                            <td style="width: 90px">
                    <asp:TextBox ID="txtDate" runat="server" Width="128px" ReadOnly="True" TabIndex="3"
                        SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 100px">
                    <img id="imgDate" alt="Calendar" src="../../Images/SmallCalendar.png"   /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 149px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 9px;">
                </td>
                <td class="reportTitleIncome" style="width: 150px; height: 30px;">
                    Sub
                    Verifcation Type</td>
                <td class="Info" style="height: 30px">
                    <asp:DropDownList ID="ddlVerificationType" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlVerificationType_SelectedIndexChanged" TabIndex="5"
                        SkinID="ddlSkin" Width="132px">
                    </asp:DropDownList></td>
                <td style="width: 149px; height: 30px;">
                </td>
                <td style="width: 100px; height: 30px;">
                </td>
                <td style="width: 100px; height: 30px;">
                </td>
            </tr>
            <tr>
                <td style="height: 20px;" class="tta" colspan="7">
                    &nbsp; Education Verfication Details</td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Institute / College / University Name</td>
                <td class="Info">
                    <asp:TextBox ID="txtCollegeName" runat="server" Width="250px" Height="17px" TabIndex="7"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Qualification</td>
                <td class="Info">
                    <asp:TextBox ID="txtQualification" runat="server" Width="250px" TabIndex="6" ReadOnly="True"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Registration Number</td>
                <td class="Info">
                    <asp:TextBox ID="txtRegistrator" runat="server" Height="17px" Width="250px" TabIndex="8"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Address</td>
                <td class="Info" colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="599px" TabIndex="9"
                        MaxLength="250" SkinID="txtSkin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Roll Number</td>
                <td class="Info">
                    <asp:TextBox ID="txtRollNumber" runat="server" Width="250px" TabIndex="10" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Passing Year</td>
                <td class="Info">
                    <asp:TextBox ID="txtYearOfPassing" runat="server" Width="250px" TabIndex="11" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="6" style="height: 22px">
                    &nbsp;Response Details</td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Respondent Name</td>
                <td class="Info">
                    <asp:TextBox ID="txtRespondentName" runat="server" Width="250px" TabIndex="12" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Respondent's Contact Number</td>
                <td class="Info">
                    <asp:TextBox ID="txtRespondentContactNo" runat="server" Width="250px" TabIndex="13"
                        SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Respondent's Designation</td>
                <td class="Info">
                    <asp:TextBox ID="txtRespondentDesig" runat="server" Width="250px" TabIndex="14" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Record Found</td>
                <td class="Info">
                    <asp:DropDownList ID="ddlRecordFound" runat="server" TabIndex="15"
                        SkinID="ddlSkin" Width="133px">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        <asp:ListItem Value="No">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 149px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome" style="width: 150px">
                    Remarks</td>
                <td class="Info" colspan="3">
                    <asp:TextBox ID="txtRemark" runat="server" Width="650px" TextMode="MultiLine" TabIndex="16" SkinID="txtSkin" Height="90px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 17px; width: 9px;">
                </td>
                <td class="reportTitleIncome" style="height: 17px;" rowspan="">
                    Date of Verification</td>
                <td class="Info" colspan="2" style="height: 17px">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 19px; width: 460px;">
                        <tr>
                            <td style="width: 171px">
                    <asp:TextBox ID="txtDateOfVerification" runat="server" Width="129px" TabIndex="17"
                        Height="17px" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgDateOfVerification" alt="Calendar" src="../../Images/SmallCalendar.png"
                        onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                            <td>
                    </td>
                            <td class="reportTitleIncome">
                    Time of Verification</td>
                            <td>
                    <asp:TextBox ID="txtTimeOfVerification" runat="server" Width="68px" TabIndex="18"
                        SkinID="txtSkin"></asp:TextBox>
                                [hh:mm]</td>
                        </tr>
                    </table>
                    &nbsp;</td>
                <td style="width: 100px; height: 17px;">
                    &nbsp;</td>
                <td style="width: 100px; height: 17px;">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 9px;">
                </td>
                <td class="reportTitleIncome" style="width: 150px; height: 18px">
                    FE Name</td>
                <td class="Info" style="height: 18px">
                    <asp:TextBox ID="txtFEName" runat="server" Width="250px" TabIndex="19" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 100px; height: 18px">
                </td>
                <td style="width: 100px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 9px;">
                </td>
                <td class="reportTitleIncome" style="width: 150px; height: 18px">
                    Supervisor's Name</td>
                <td class="Info" style="height: 18px">
                    <asp:TextBox ID="txtSupervisorName" runat="server" Width="250px" TabIndex="20" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 100px; height: 18px">
                </td>
                <td style="width: 100px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 18px; width: 9px;">
                </td>
                <td class="reportTitleIncome" style="width: 150px; height: 18px">
                    Overall Verification</td>
                <td class="Info" style="height: 18px">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="250px" TabIndex="21" SkinID="ddlSkin">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>
                        <asp:ListItem>Discrepant</asp:ListItem>
                        <asp:ListItem>UTV</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 18px">
                </td>
                <td style="width: 100px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px">
                </td>
                <td class="reportTitleIncome">
                                Upload Attachment</td>
                <td class="Info" colspan="3">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="77%" SkinID="flup" />
                    <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                    View Uploaded Attachment</span></a>
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="6" style="height: 18px">
                    &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="71px" OnClick="btnSave_Click"
                        TabIndex="22" Font-Bold="True" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="23"
                            OnClick="btnCancel_Click" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 18px">
                    <asp:HiddenField ID="hdnCaseID" runat="server" />
                    <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
                </td>
            </tr>
        </table>
        <br />
    
</asp:Content>
