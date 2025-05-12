<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master" AutoEventWireup="true" CodeFile="~/FRC/Employee Background Check/EBC_ReferenceCheck.aspx.cs" Inherits="EBC_New_EBC_New_EBC_ReferenceCheck" Title="Reference Check" StylesheetTheme="SkinFile" %>
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
        var ddlStatus=document.getElementById("<%=ddlStatus.ClientID%>");
        var txtRemarks=document.getElementById("<%=txtRemarks.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>"); 
        
        var ReturnValue=true;
        var ErrorMsg="";
        
        if(ddlStatus.selectedIndex==0)
        {
            ErrorMsg='Please Select Atleast one Verification Status......!!!!!';
            ReturnValue=false;
            ddlStatus.focus();
        }
        if(txtRemarks.value=='')
        {
            ErrorMsg='Please write Remark......!!!!!';
            ReturnValue=false;
            txtRemarks.focus();
        }
        
        lblMessage.innerText=ErrorMsg;
      if(ErrorMsg!='')
                    {
                        window.scrollTo(0,0);
                    }
                           return ReturnValue;     
    }     
</script>

    <table style="width: 100%;" class="bx">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 16px">
                  <span>Reference
                    Check Verification </td>
        </tr>
        <tr>
            <td style="width: 7px">
                &nbsp; &nbsp;
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                Case ID</td>
            <td class="Info" style="width: 22px">
                <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="180px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 168px">
            </td>
            <td style="width: 200px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                Client Ref No</td>
            <td class="Info" style="width: 22px">
                <asp:TextBox ID="txtClientRefNo" runat="server" SkinID="txtSkin" Width="180px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 168px">
            </td>
            <td style="width: 200px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                <asp:Label ID="Label1" runat="server" Text="Name Of Employee" Width="156px"></asp:Label></td>
            <td class="Info" style="width: 22px">
                <asp:TextBox ID="txtNameOfEmployee" runat="server" SkinID="txtSkin" Width="180px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 168px">
            </td>
            <td style="width: 200px">
            </td>
        </tr>
        <tr>
            <td style="height: 19px; width: 7px;">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 19px;">
                Date Of Birth</td>
            <td class="Info" style="width: 22px; height: 19px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 143px">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                <asp:TextBox ID="txtDOB" runat="server" SkinID="txtSkin" Width="120px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                <img id="imgDateOfVerification" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 168px; height: 19px;">
            </td>
            <td style="width: 200px; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="height: 10px; width: 7px;">
            </td>
            <td class="reportTitleIncome" style="width: 288px; height: 10px;">
                Case Recv Date</td>
            <td style="width: 22px; height: 10px;" class="Info">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 140px">
                    <tr>
                        <td style="width: 134px; height: 20px;">
                <asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" Width="119px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                            <img src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 168px; height: 10px;">
                &nbsp;</td>
            <td style="width: 200px; height: 10px;">
                </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                Father Name</td>
            <td style="width: 22px" class="Info">
                <asp:TextBox ID="txtFatherName" runat="server" SkinID="txtSkin" Width="180px" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 168px">
                &nbsp;</td>
            <td style="width: 200px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 36px; width: 7px;">
                &nbsp;</td>
            <td class="reportTitleIncome" style="width: 288px">
                Address
            </td>
            <td class="Info" colspan="3" style="width: 15px; height: 36px">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="489px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tta" colspan="5" style="height: 9px">
                &nbsp;Verification Details</td>
        </tr>
        <tr>
            <td style="height: 9px; width: 7px;">
            </td>
            <td class="reportTitleIncome" style="height: 9px; width: 288px;">
                Sub Verification TypeID</td>
            <td style="width: 22px; height: 9px" class="Info">
                <asp:DropDownList ID="ddlSubVerificationType" runat="server" Width="180px" SkinID="ddlSkin" OnSelectedIndexChanged="ddlSubVerificationType_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></td>
            <td style="height: 9px; width: 168px;">
            </td>
            <td style="width: 200px; height: 9px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                Reference Name</td>
            <td style="width: 22px" class="Info">
                <asp:TextBox ID="txtRef_Name" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="width: 168px">
            </td>
            <td style="width: 200px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Reference Relation</td>
            <td style="width: 22px; height: 16px;" class="Info">
                <asp:TextBox ID="txtRef_Relation" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 16px; width: 168px;">
            </td>
            <td style="width: 200px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Reference Contact Number</td>
            <td style="width: 22px; height: 16px" class="Info">
                <asp:TextBox ID="txtRef_ContactNo" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 16px; width: 168px;">
            </td>
            <td style="width: 200px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Reference Address</td>
            <td colspan="3" style="width: 15px; height: 16px" class="Info">
                <asp:TextBox ID="txt_Ref_Address" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="459px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Residence Address of Employee as Per Call / Visit</td>
            <td colspan="3" style="width: 15px; height: 16px" class="Info">
                <asp:TextBox ID="txtResidenceAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="458px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                Since how long the referencee is knowing to the candidate</td>
            <td style="width: 22px;" class="Info">
                <asp:TextBox ID="txtRef_Of_Candidate" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 168px">
                Number of Years at Residence</td>
            <td style="width: 200px;" class="Info">
                <asp:TextBox ID="txtNo_Of_Years_at_Residence" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Residence Status</td>
            <td style="width: 22px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlResiType" runat="server" SkinID="ddlSkin" Width="154px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px; width: 168px;" class="reportTitleIncome">
                Occupation Type</td>
            <td style="width: 200px; height: 16px" class="Info">
                <asp:TextBox ID="txtOccupation_Type" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 29px; width: 7px;">
            </td>
            <td style="height: 29px; width: 288px;" class="reportTitleIncome">
                Designation of the Employee</td>
            <td style="width: 22px; height: 29px" class="Info">
                <asp:TextBox ID="txtDesignation_Of_The_Employee" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 29px; width: 168px;" class="reportTitleIncome">
                Contact Number of the Employee</td>
            <td style="width: 200px; height: 29px" class="Info">
                <asp:TextBox ID="txtContact_No_Of_Employee" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Name of Employer of Employee</td>
            <td style="width: 22px; height: 16px" class="Info">
                <asp:TextBox ID="txtName_Of_Employer_Of_Employee" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 16px; width: 168px;">
                </td>
            <td style="width: 200px; height: 16px">
                </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Status</td>
            <td style="width: 22px; height: 16px" class="Info">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="156px" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>Positive</asp:ListItem>
                    <asp:ListItem>Negative</asp:ListItem>
                    <asp:ListItem>Discrepant</asp:ListItem>
                    <asp:ListItem>UTV</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px; width: 168px;">
            </td>
            <td style="width: 200px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Remarks</td>
            <td colspan="3" style="width: 15px; height: 16px" class="Info">
                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txtSkin" Width="650px" TextMode="MultiLine" Height="90px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 19px; width: 7px;" rowspan="">
            </td>
            <td style="height: 19px; width: 288px;" class="reportTitleIncome" rowspan="">
                Date of Verification</td>
            <td style="width: 22px; height: 19px;" class="Info" rowspan="">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 137px">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                <asp:TextBox ID="txtDateOfVerification" runat="server" SkinID="txtSkin" Width="116px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td class="reportTitleIncome" rowspan="" style="width: 168px; height: 19px;">
                Time of Verification</td>
            <td class="Info" style="height: 19px" rowspan="">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 116px">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                <asp:TextBox ID="txtTimeOfVerification" runat="server" SkinID="txtSkin" Width="61px"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                [hh:mm]</td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 7px;">
            </td>
            <td style="height: 16px; width: 288px;" class="reportTitleIncome">
                Field Executive's Name</td>
            <td style="width: 22px; height: 16px" class="Info">
                <asp:TextBox ID="txtFEName" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 16px; width: 168px;">
            </td>
            <td style="width: 5px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 7px; width: 7px;">
            </td>
            <td style="height: 7px; width: 288px;" class="reportTitleIncome">
                Supervisor's Name</td>
            <td style="width: 22px; height: 7px" class="Info">
                <asp:TextBox ID="txtSupervisorName" runat="server" SkinID="txtSkin" Width="180px"></asp:TextBox></td>
            <td style="height: 7px; width: 168px;">
            </td>
            <td style="width: 5px; height: 7px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="reportTitleIncome" style="width: 288px">
                            Upload Attachment</td>
            <td class="Info" colspan="3">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="70%" SkinID="flup" />
                <a href="javascript:openwindow('1');" title="View Uploaded Image1"><span style="text-decoration: underline">
                                View Uploaded Attachment</span></a>
            </td>
        </tr>
        <tr>
            <td style="height: 7px; width: 7px;">
            </td>
            <td colspan="4" style="height: 7px">
            </td>
        </tr>
        <tr>
            <td colspan="5" style="height: 41px" class="tta">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="77px" OnClick="btnSave_Click" Font-Bold="True" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="69px" OnClick="btnCancel_Click" Font-Bold="True" /></td>
        </tr>
        <tr>
            <td colspan="1" style="height: 16px; width: 7px;">
            </td>
            <td colspan="2" style="width: 180px; height: 16px">
                <asp:HiddenField ID="hdnMainVerifyID" runat="server" />
                <asp:HiddenField ID="hdnSubVerifyTypeID" runat="server" />
                <asp:HiddenField ID="hdnCaseID" runat="server" />
            </td>
            <td style="height: 16px; width: 168px;">
            </td>
            <td style="width: 200px; height: 16px">
            </td>
        </tr>
    </table>

</asp:Content>

