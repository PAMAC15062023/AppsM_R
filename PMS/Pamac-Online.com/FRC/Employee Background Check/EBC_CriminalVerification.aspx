<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="EBC_CriminalVerification.aspx.cs" Theme="SkinFile" Inherits="EBC_New_EBC_New_EBC_CriminalVerification" Title="Criminal Verification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
 <script language="javascript" type="text/javascript" >
  function openwindow(imgType)
        {        
            
           var hdnCaseID=document.getElementById("<%=hdnCaseID.ClientID%>");
           var hdnMainVerifyID=document.getElementById("<%=hdnMainVerifyID.ClientID%>");
           var hdnSubVerifyTypeID=document.getElementById("<%=ddlSubVeriType.ClientID%>"); 
          
            window.open('EBC_RenderImage.aspx?CaseId='+hdnCaseID.value +'&Veri='+hdnMainVerifyID.value+'&SubVeri='+hdnSubVerifyTypeID.value+'&ImageType='+imgType , '_blank', 'height=350,width=700,status=yes,resizable=yes');
        } 
        
        function SaveValidationControl()
                {
                    var ddlVeriStat=document.getElementById("<%=ddlVeriStat.ClientID%>");
                    var txtRemark=document.getElementById("<%=txtRemark.ClientID%>");
                    var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
                    
                    var ReturnValue=true;
                    var ErrorMsg="";
                    
                    if(ddlVeriStat.selectedIndex==0)
                    {
                        ErrorMsg='Please Select Atleast one Verification Status......!!!!!';
                        ReturnValue=false;
                        ddlVeriStat.focus();
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

    <asp:Panel ID="pnlCrimUpdData" runat="server" Width="947px">
        <table style="width: 100%" class="bx">
            <tr>
                <td colspan="8" style="height: 22px">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" CssClass="ErrorMessage"></asp:Label></td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 17px">
                    Criminal Verification Details</td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Name of Employee</td>
                <td class="Info" style="width: 192px; height: 22px">
                    <asp:TextBox ID="txtEmpFname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 100px; height: 22px">
                    <asp:TextBox ID="txtEmpMname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 139px; height: 22px">
                    <asp:TextBox ID="txtEmpLname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                </td>
                <td class="Info" style="width: 192px; height: 22px; text-align: center">
                    First Name</td>
                <td class="Info" style="width: 100px; height: 22px; text-align: center">
                    Middle Name</td>
                <td class="Info" style="width: 139px; height: 22px; text-align: center">
                    Last Name</td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Client Ref. Name / No</td>
                <td class="Info" style="width: 192px; height: 22px">
                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 139px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Case
                    Received Date</td>
                <td class="Info" style="width: 192px; height: 22px">
                    <asp:TextBox ID="txtRcvdDate" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 139px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Father's Name</td>
                <td class="Info" style="width: 192px; height: 22px">
                    <asp:TextBox ID="txtFatFname" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 139px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Date of Birth</td>
                <td class="Info" style="width: 192px; height: 22px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 148px">
                        <tr>
                            <td style="width: 100px; height: 20px;">
                    <asp:TextBox ID="txtDOB" runat="server" Enabled="False" SkinID="txtSkin" Width="126px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px;">
                                <img src="../../Images/SmallCalendar.png" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 139px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 12px">
                    &nbsp; Verification Details</td>
            </tr>
            <tr>
                <td style="height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Sub Verification Type</td>
                <td style="width: 192px; height: 22px;" class="Info">
                    <asp:DropDownList ID="ddlSubVeriType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubVeriType_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 139px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="height: 22px">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Address</td>
                <td colspan="3" style="height: 22px" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="500px" Enabled="False"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Name of the Police Station</td>
                <td class="Info" colspan="3" style="height: 16px">
                    <asp:TextBox ID="txtNamePoliceSt" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Address of the Police Station</td>
                <td colspan="3" style="height: 16px" class="Info">
                    <asp:TextBox ID="txtAddPoliceSt" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="500px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 5px">
                    &nbsp; Respondent Details</td>
            </tr>
            <tr>
                <td style="height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Respondent's Name</td>
                <td style="height: 16px" class="Info">
                    <asp:TextBox ID="txtRespoName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 139px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Respondent's Designation</td>
                <td style="width: 192px; height: 22px;" class="Info">
                    <asp:TextBox ID="txtRespoDesig" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 139px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="height: 4px;">
                </td>
                <td colspan="2" style="height: 4px" class="reportTitleIncome">
                    Respondent's Contact Number</td>
                <td style="width: 192px; height: 4px;" class="Info">
                    <asp:TextBox ID="txtRespoNo" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 4px;">
                </td>
                <td style="width: 139px; height: 4px;">
                </td>
                <td style="width: 100px; height: 4px;">
                </td>
                <td style="width: 100px; height: 4px;">
                </td>
            </tr>
            <tr>
                <td style="height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Criminal Record</td>
                <td style="width: 192px; height: 16px;" class="Info">
                    <asp:DropDownList ID="ddlCrimRecord" runat="server" SkinID="ddlSkin" Width="150px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 139px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="height: 36px;">
                </td>
                <td colspan="2" style="height: 36px" class="reportTitleIncome">
                    Remark / Feedback</td>
                <td class="Info" colspan="5" style="height: 36px">
                    <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="650px" Height="90px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Overall Verification</td>
                <td style="width: 192px; height: 16px" class="Info">
                    <asp:DropDownList ID="ddlVeriStat" runat="server" SkinID="ddlSkin" Width="150px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>
                        <asp:ListItem>Discrepant</asp:ListItem>
                        <asp:ListItem>UTV</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2" style="height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="height: 19px">
                </td>
                <td colspan="2" style="height: 19px" class="reportTitleIncome">
                    Date of Verification</td>
                <td class="Info" style="width: 192px; height: 19px">
                    <br />
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 147px">
                        <tr>
                            <td style="width: 100px; height: 20px;">
                    <asp:TextBox ID="txtVeriDate" runat="server" SkinID="txtSkin" Width="124px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px;">
                               <img id="imgDate"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 19px" class="reportTitleIncome">
                Time of Verification</td>
                <td class="Info" style="height: 19px; width: 139px;">
                    &nbsp;<table border="0" cellpadding="0" cellspacing="0" style="width: 84px">
                        <tr>
                            <td style="width: 100px; height: 20px">
                    <asp:TextBox ID="txtVeriTime" runat="server" SkinID="txtSkin" Width="83px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px">
                    [hh:mm]</td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Field Executive's Name</td>
                <td style="width: 192px; height: 16px;" class="Info">
                    <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="height: 16px;" colspan="2">
                    </td>
                <td style="width: 100px; height: 16px;">
                    </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Supervisor's Name</td>
                <td style="width: 192px; height: 16px" class="Info">
                    <asp:TextBox ID="txtSuperName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td colspan="2" style="height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px">
                </td>
                <td class="reportTitleIncome" colspan="2">
                                Upload Attachment</td>
                <td class="Info" colspan="3">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="75%" SkinID="flup" />
                    <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                    View Uploaded Attachment</span></a>
                </td>
            </tr>
            <tr>
                <td style="height: 16px">
                </td>
                <td colspan="7" style="height: 16px">
                </td>
            </tr>
            <tr>
                <td style="height: 35px;" class="tta" colspan="8">
                    <asp:Button ID="btnSave" runat="server" Height="27px" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                        Text="Save" Width="87px" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Height="27px" OnClick="btnCancel_Click"
                        SkinID="btnCancelSkin" Text="Cancel" Width="87px" /></td>
            </tr>
            <tr>
                <td style="height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                    <asp:HiddenField ID="hdnCaseID" runat="server" />
                    &nbsp;&nbsp;
                </td>
                <td style="width: 97px; height: 21px;">
                </td>
                <td style="width: 192px; height: 21px;">
                    <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
                </td>
                <td style="width: 100px; height: 21px;">
                    <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
                </td>
                <td style="width: 139px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
                <td style="width: 100px; height: 21px;">
                </td>
            </tr>
        </table>
    </asp:Panel>
    
</asp:Content>

