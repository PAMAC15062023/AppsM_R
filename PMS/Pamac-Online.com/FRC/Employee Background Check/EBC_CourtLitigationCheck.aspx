<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="~/FRC/Employee Background Check/EBC_CourtLitigationCheck.aspx.cs" Inherits="EBC_New_EBC_New_EBC_CourtLitigationCheck" Title="Court Litigation Check Verification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
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
   
        <table class="bx" style="width: 100%;">
            <tr>
                <td colspan="8" style="height: 22px">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 21px">
                    Court Litigation Check Verifications</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px">
                    &nbsp;
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Name of Employee</td>
                <td class="Info" style="width: 131px; height: 22px">
                    <asp:TextBox ID="txtEmpFname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 100px; height: 22px">
                    <asp:TextBox ID="txtEmpMname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 100px; height: 22px">
                    <asp:TextBox ID="txtEmpLname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td style="width: 132px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td colspan="2" class="reportTitleIncome">
                </td>
                <td class="Info" style="width: 131px; text-align: center">
                    First Name</td>
                <td class="Info" style="width: 100px; text-align: center">
                    Middle Name</td>
                <td class="Info" style="width: 100px; text-align: center">
                    Last Name</td>
                <td style="width: 132px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Client Ref. Name / No</td>
                <td class="Info" style="width: 131px; height: 22px">
                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 132px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 10px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 10px">
                    Case
                    Received Date</td>
                <td class="Info" style="width: 131px; height: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 159px">
                        <tr>
                            <td style="width: 130px">
                    <asp:TextBox ID="txtRcvdDate" runat="server" SkinID="txtSkin" Enabled="False" Width="136px"></asp:TextBox></td>
                            <td style="width: 100px">
                                <img src="../../Images/SmallCalendar.png" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 132px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Fathers Name</td>
                <td class="Info" style="width: 131px; height: 22px">
                    <asp:TextBox ID="txtFatFname" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 132px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Date of Birth</td>
                <td class="Info" style="width: 131px; height: 22px">
                    <asp:TextBox ID="txtDOB" runat="server" Enabled="False" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 132px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 8px">
                    &nbsp;Verification Details</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Sub Verification Type</td>
                <td style="width: 131px; height: 22px;" class="Info">
                    <asp:DropDownList ID="ddlSubVeriType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubVeriType_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="141px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 132px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Address</td>
                <td colspan="3" style="height: 22px" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="407px" Enabled="False"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Name of the Court</td>
                <td style="height: 16px" class="Info">
                    <asp:TextBox ID="txtNameCourt" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Address of the Court</td>
                <td colspan="3" style="height: 16px" class="Info">
                    <asp:TextBox ID="txtAddCourt" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="405px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 2px">
                    &nbsp;Respondent's&nbsp; Details</td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Respondent's Name</td>
                <td style="height: 16px" class="Info">
                    <asp:TextBox ID="txtRespoName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px">
                </td>
                <td colspan="2" class="reportTitleIncome">
                    Respondent's Designation</td>
                <td style="width: 131px" class="Info">
                    <asp:TextBox ID="txtRespoDesig" runat="server" SkinID="txtSkin" Width="200px" Height="14px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 132px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Respondent's Contact Number</td>
                <td style="width: 131px; height: 22px;" class="Info">
                    <asp:TextBox ID="txtRespoNo" runat="server" SkinID="txtSkin" Width="200px" Height="14px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 132px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Record Found</td>
                <td style="width: 131px; height: 16px;" class="Info">
                    <asp:DropDownList ID="ddlCrimRecord" runat="server" SkinID="ddlSkin" Width="137px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 132px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 36px;">
                </td>
                <td colspan="2" style="height: 36px" class="reportTitleIncome">
                    Remarks</td>
                <td class="Info" colspan="5" style="height: 36px">
                    <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="650px" Height="90px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Overall Verification</td>
                <td style="width: 131px; height: 16px" class="Info">
                    <asp:DropDownList ID="ddlVeriStat" runat="server" SkinID="ddlSkin" Width="138px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>
                        <asp:ListItem>Discrepant</asp:ListItem>
                        <asp:ListItem>UTV</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="2" style="height: 16px">
                </td>
                <td style="width: 132px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 9px">
                </td>
                <td colspan="2" style="height: 9px" class="reportTitleIncome">
                    Date of Verification</td>
                <td style="width: 131px; height: 9px" class="Info">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 101px">
                        <tr>
                            <td style="width: 100px">
                    <asp:TextBox ID="txtVeriDate" runat="server" SkinID="txtSkin" Width="134px"></asp:TextBox></td>
                            <td style="width: 100px">
                               <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 9px" class="reportTitleIncome">
                    &nbsp;Time of Verification</td>
                <td style="width: 132px; height: 9px" class="Info">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 121px">
                        <tr>
                            <td style="width: 100px">
                    <asp:TextBox ID="txtVeriTime" runat="server" SkinID="txtSkin" Width="59px"></asp:TextBox></td>
                            <td style="width: 100px">
                                &nbsp;[hh:mm]</td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 9px">
                </td>
                <td style="width: 100px; height: 9px">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Field Executive's Name</td>
                <td class="Info" style="height: 16px">
                    <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 132px; height: 16px;">
                    </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Supervisor's Name</td>
                <td class="Info" style="height: 16px">
                    <asp:TextBox ID="txtSuperName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 132px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 14px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 14px">
                                Upload Attachment</td>
                <td class="Info" colspan="4" style="height: 14px">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="70%" SkinID="flup" />
                    <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                    View Uploaded Attachment</span></a>
                </td>
            </tr>
            <tr>
                <td style="width: 11px; height: 16px">
                </td>
                <td colspan="7" style="height: 16px">
                </td>
            </tr>
            <tr>
                <td style="height: 25px;" class="tta" colspan="8">
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Height="27px" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                        Text="Save" Width="87px" />
                    <asp:Button ID="btnCancel" runat="server" Height="27px" OnClick="btnCancel_Click"
                        SkinID="btnCancelSkin" Text="Cancel" Width="87px" /></td>
            </tr>
            <tr>
                <td style="width: 11px; height: 56px;">
                </td>
                <td style="width: 100px; height: 56px;">
                    <asp:HiddenField ID="hdnCaseID" runat="server" />
                    &nbsp;&nbsp;
                </td>
                <td style="width: 42px; height: 56px;">
                </td>
                <td style="width: 131px; height: 56px;">
                    <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
                </td>
                <td style="width: 100px; height: 56px;">
                    <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
                </td>
                <td style="width: 100px; height: 56px;">
                </td>
                <td style="width: 132px; height: 56px;">
                </td>
                <td style="width: 100px; height: 56px;">
                </td>
            </tr>
        </table>
    

</asp:Content>

