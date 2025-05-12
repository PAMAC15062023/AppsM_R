<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="~/FRC/Employee Background Check/EBC_CreditCheckVerification.aspx.cs" Inherits="EBC_New_EBC_New_EBC_CreditCheckVerification" Title="Credit Check Verification" StylesheetTheme="SkinFile" %>
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
        <table style="width: 100%" class="bx">
            <tr>
                <td colspan="8">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 14px">
                    Credit Check Verification</td>
            </tr>
            <tr>
                <td style="width: 9px">
                    &nbsp;</td>
                <td class="reportTitleIncome" colspan="2">
                    Name of Employee</td>
                <td class="Info" style="width: 157px">
                    <asp:TextBox ID="txtEmpFname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 100px">
                    <asp:TextBox ID="txtEmpMname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td class="Info" style="width: 100px">
                    <asp:TextBox ID="txtEmpLname" runat="server" SkinID="txtSkin" Enabled="False" Width="150px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px;">
                    &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
                <td colspan="2" class="reportTitleIncome" style="height: 16px">
                </td>
                <td class="Info" style="width: 157px; text-align: center; height: 16px;">
                    First Name</td>
                <td class="Info" style="width: 100px; text-align: center; height: 16px;">
                    Middle Name</td>
                <td class="Info" style="width: 100px; text-align: center; height: 16px;">
                    Last Name</td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Client Ref. Name / No</td>
                <td class="Info" style="width: 157px; height: 22px">
                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 16px">
                    Case
                    Received Date</td>
                <td class="Info" style="width: 157px; height: 16px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 151px">
                        <tr>
                            <td style="width: 150px; height: 20px;">
                    <asp:TextBox ID="txtRcvdDate" runat="server" SkinID="txtSkin" Enabled="False" Width="128px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px;">
                                <img src="../../Images/SmallCalendar.png" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 22px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 22px">
                    Father's Name</td>
                <td class="Info" style="width: 157px; height: 22px">
                    <asp:TextBox ID="txtFatFname" runat="server" SkinID="txtSkin" Enabled="False" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
                <td style="width: 100px; height: 22px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 10px;">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 10px">
                    Date of Birth</td>
                <td class="Info" style="width: 157px; height: 10px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 150px">
                        <tr>
                            <td style="width: 153px; height: 20px;">
                    <asp:TextBox ID="txtDOB" runat="server" Enabled="False" SkinID="txtSkin" Width="127px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px;">
                                <img src="../../Images/SmallCalendar.png" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
                <td style="width: 100px; height: 10px;">
                </td>
            </tr>
            <tr>
                <td class="tta" colspan="8" style="height: 13px">
                    &nbsp; Verification Details</td>
            </tr>
            <tr>
                <td style="width: 9px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    Sub Verification Type</td>
                <td style="width: 157px; height: 22px;" class="Info">
                    <asp:DropDownList ID="ddlSubVeriType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubVeriType_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px;">
                </td>
                <td colspan="2" class="reportTitleIncome">
                    Address</td>
                <td colspan="3" class="Info">
                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="350px" Enabled="False"></asp:TextBox></td>
                <td style="width: 100px;">
                </td>
                <td style="width: 84px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    PAN Number</td>
                <td style="height: 16px" class="Info">
                    <asp:TextBox ID="txtPanNo" runat="server" SkinID="txtSkin" Width="200px" Enabled="False" MaxLength="10"></asp:TextBox></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 84px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 23px;">
                </td>
                <td colspan="2" class="reportTitleIncome" style="height: 23px">
                    Defaulter</td>
                <td style="width: 157px; height: 23px;" class="Info"><asp:DropDownList ID="ddlDefaulter" runat="server" SkinID="ddlSkin" Width="150px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
                <td style="width: 100px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                </td>
                <td style="width: 100px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 22px;">
                </td>
                <td colspan="2" style="height: 22px" class="reportTitleIncome">
                    CIBIL Score</td>
                <td style="width: 157px; height: 22px;" class="Info">
                    <asp:TextBox ID="txtCibil" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
                <td style="width: 100px; height: 22px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px;">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Record Found</td>
                <td style="width: 157px; height: 16px;" class="Info">
                    <asp:DropDownList ID="ddlCrimRecord" runat="server" SkinID="ddlSkin" Width="150px">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 36px;">
                </td>
                <td colspan="2" style="height: 36px" class="reportTitleIncome">
                    Remarks</td>
                <td style="height: 36px;" colspan="3" class="Info">
                    <asp:TextBox ID="txtRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                        Width="650px" Height="90px"></asp:TextBox></td>
                <td style="width: 84px; height: 36px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px">
                </td>
                <td colspan="2" style="height: 16px" class="reportTitleIncome">
                    Overall Verification</td>
                <td style="width: 157px; height: 16px" class="Info">
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
                <td style="width: 9px; height: 13px">
                </td>
                <td colspan="2" style="height: 13px" class="reportTitleIncome">
                    Date of Verification</td>
                <td style="width: 157px; height: 13px;" class="Info">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 99px">
                        <tr>
                            <td style="width: 100px">
                    <asp:TextBox ID="txtVeriDate" runat="server" SkinID="txtSkin" Width="145px"></asp:TextBox></td>
                            <td style="width: 100px">
                               <img id="imgDateOfVerification"  alt="Calendar" src="../../Images/SmallCalendar.png" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 13px" class="reportTitleIncome">
                Time of Verification</td>
                <td class="Info" style="height: 13px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 96px">
                        <tr>
                            <td style="width: 60px; height: 20px">
                    <asp:TextBox ID="txtVeriTime" runat="server" SkinID="txtSkin" Width="57px"></asp:TextBox></td>
                            <td style="width: 100px; height: 20px">
                                &nbsp;[hh:mm]</td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px; height: 13px">
                </td>
                <td style="width: 100px; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 24px;">
                </td>
                <td colspan="2" style="height: 24px" class="reportTitleIncome">
                    Field Executive's Name</td>
                <td class="Info" colspan="2" style="height: 24px">
                    <asp:TextBox ID="txtFeName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 24px;">
                    </td>
                <td style="width: 100px; height: 24px;">
                </td>
                <td style="width: 100px; height: 24px;">
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 15px">
                </td>
                <td colspan="2" style="height: 15px" class="reportTitleIncome">
                    Supervisor's Name</td>
                <td class="Info" colspan="2" style="height: 15px">
                    <asp:TextBox ID="txtSuperName" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
                <td style="width: 100px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 14px; height: 17px">
                </td>
                <td class="reportTitleIncome" colspan="2" style="height: 17px">
                                Upload Attachment</td>
                <td class="Info" colspan="5" style="height: 17px">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="71%" SkinID="flup" />
                    <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                    View Uploaded Attachment</span></a>
                </td>
            </tr>
            <tr>
                <td style="width: 9px; height: 14px">
                </td>
                <td colspan="7" style="height: 14px">
                </td>
            </tr>
            <tr>
                <td style="height: 27px;" class="tta" colspan="8">
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Height="27px" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                        Text="Save" Width="87px" />
                    <asp:Button ID="btnCancel" runat="server" Height="27px" OnClick="btnCancel_Click"
                        SkinID="btnCancelSkin" Text="Cancel" Width="87px" /></td>
            </tr>
            <tr>
                <td style="width: 9px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                    <asp:HiddenField ID="hdnCaseID" runat="server" />
                    &nbsp;&nbsp;
                </td>
                <td style="width: 88px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                    <asp:HiddenField ID="hdnMainVerifyID" runat="server" Value="0" />
                </td>
                <td style="width: 100px; height: 16px;">
                    <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" Value="0" />
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
                <td style="width: 100px; height: 16px;">
                </td>
            </tr>
        </table>
    
</asp:Content>

