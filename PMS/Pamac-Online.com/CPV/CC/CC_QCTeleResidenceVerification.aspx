<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" 
AutoEventWireup="true" CodeFile="CC_QCTeleResidenceVerification.aspx.cs" Inherits="CC_CC_QCTeleResidenceVerification"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server" >
<script type="text/javascript" language="javascript">

</script>
    <asp:Panel ID="PnlView" runat="server" Width="100%" Height="100%">  
    <table border="0" cellspacing="0" cellpadding="2" style="background-color:#E7F6FF">
         <tr>
            <td colspan="8" class="TableHeader" style="height: 14px">
               <asp:Label ID="lblhead" runat="server"></asp:Label>
               <asp:Label ID="lblMessage" runat="server" Width="100%" visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label>
           </td>
        </tr> 
        <tr>
            <td colspan="8" class="TableTitle" style="height: 15px">
                &nbsp;<strong>Applicant Details</strong></td>
        </tr>
        <tr>
            <td colspan="5" style="height: 20px">
                <asp:Label ID="lblMessage1" runat="server" BorderColor="White" Font-Bold="True" Font-Size="Larger"
                    ForeColor="Red" Width="661px"></asp:Label></td>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 100px; height: 20px;">
            </td>
            <td style="width: 12px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                <asp:Label ID="Label3" runat="server" Text="Case Id" Width="183px"></asp:Label></td>
            <td style="width: 160px">
                <asp:TextBox ID="txtCaseID" runat="server" ReadOnly="True" SkinID="txtSkin" Width="205px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 173px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 26px;">
            </td>
            <td style="height: 26px; width: 210px;">
                Reference No</td>
            <td style="width: 160px; height: 26px;">
                <asp:TextBox ID="txtReferenceNo" runat="server" ReadOnly="True" SkinID="txtSkin" Width="202px"></asp:TextBox></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 173px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="height: 26px; width: 12px;">
            </td>
        </tr>
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Applicant Name</td>
            <td colspan="5">
                <asp:TextBox ID="txtApplicantName" runat="server" ReadOnly="True" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
         <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Date of Verification</td>
            <td colspan="5">
                <asp:TextBox ID="txtDateOfVerification" runat="server" ReadOnly="True" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Time of Verification</td>
            <td colspan="5">
                <asp:TextBox ID="txtTimeOfVerification" runat="server" ReadOnly="True" SkinID="txtSkin" Width="203px"></asp:TextBox>
               
                </td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px; height: 14px;">
            </td>
            <td style="height: 14px; width: 210px;">
                Product Name</td>
            <td colspan="5" style="height: 14px">
                <asp:TextBox ID="txtProductName" runat="server" ReadOnly="True" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="height: 14px; width: 12px;">
            </td>
        </tr> 
         <tr>
            <td style="width: 56px;">
            </td>
            <td style="width: 210px;">
                FE Name</td>
            <td colspan="5">
                <asp:TextBox ID="txtFe" runat="server" ReadOnly="True" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px; height: 26px;">
            </td>
            <td style="width: 210px; height: 26px;">
                Phone No</td>
            <td colspan="5" style="height: 26px">
                <asp:TextBox ID="txtPhoneNo" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px; height: 26px;">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Place of Call</td>
            <td colspan="5">
            <asp:DropDownList ID="ddlPlaceOfCall" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Res</asp:ListItem>
                    <asp:ListItem>Off</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px; height: 28px;">
            </td>
            <td style="width: 210px; height: 28px;">
               Name of the person Met during the visit</td>
            <td colspan="5" style="height: 28px">
                <asp:TextBox ID="txtNameOfthePersonMet" runat="server" SkinID="txtSkin" Width="203px" ReadOnly="True"></asp:TextBox></td>
            <td style="height: 28px; width: 12px;">
            </td>
        </tr>
        
           <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
               Spoken to</td>
            <td colspan="5">
                <asp:TextBox ID="txtspokento" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
         <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
               Relationship</td>
            <td colspan="5">
                <asp:TextBox ID="txtRelationship" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
         <tr>
            <td style="width: 56px; height: 24px;">
            </td>
            <td style="width: 210px; height: 24px">
               Greeted the Applicant</td>
            <td style="width: 160px; height: 24px;">
                <asp:DropDownList ID="ddlGreetedtheApplicant" runat="server" SkinID="ddlSkin"  >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 173px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px; width: 12px;">
            </td>
        </tr>
        
         <tr>
            <td style="width: 56px; height: 14px;">
            </td>
            <td style="width: 210px; height: 14px;">
                Appearance</td>
            <td colspan="5" style="height: 14px">
                <asp:TextBox ID="txtAppearance" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px; height: 14px;">
            </td>
        </tr>
        
        
        <tr>
            <td style="width: 56px; height: 24px;">
            </td>
            <td style="height: 24px; width: 210px;">
                AID card Shown</td>
            <td style="width: 160px; height: 24px;">
                <asp:DropDownList ID="ddlAIDcardshown" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 173px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px; width: 12px;">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Over Questioning</td>
            <td colspan="5">
                <asp:TextBox ID="txtOverQuestioning" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Behaviour</td>
            <td colspan="5">
                <asp:TextBox ID="txtBehaviour" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Proof of visit obtained</td>
            <td style="width: 160px">
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                            <asp:DropDownList ID="ddlProofofVisitObtained" runat="server" SkinID="ddlSkin"  >
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList></td>
                  </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 173px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Form Filled in front</td>
            <td style="width: 160px">
                <asp:DropDownList ID="ddlFormFilledInFront" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 173px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 12px">
            </td>
        </tr>
        
        <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                Feedback if any</td>
            <td colspan="5">
                <asp:TextBox ID="txtFeedbackIfAny" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 18px;">
            </td>
            <td style="width: 210px; height: 18px;">
                Audit Tele Executive Name</td>
            <td colspan="5" style="height: 18px">
                <asp:TextBox ID="txtauditTele" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px; height: 18px;">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 18px">
            </td>
            <td style="width: 210px; height: 18px">
                DISCREPANCY</td>
            <td colspan="5" style="height: 18px">
                <asp:DropDownList ID="ddldiscrpency" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 12px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 18px">
            </td>
            <td style="width: 210px; height: 18px">
                Clarification given by FE</td>
            <td colspan="5" style="height: 18px">
                <asp:TextBox ID="txtClarification" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
            <td style="width: 12px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 18px">
            </td>
            <td style="width: 210px; height: 18px">
                Action Taken</td>
            <td colspan="5" style="height: 18px">
                <asp:TextBox ID="txtActiontake" runat="server" SkinID="txtSkin" Width="201px"></asp:TextBox></td>
            <td style="width: 12px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 56px; height: 18px">
            </td>
            <td style="width: 210px; height: 18px">
            </td>
            <td colspan="5" style="height: 18px">
            </td>
            <td style="width: 12px; height: 18px">
            </td>
        </tr>
        
         
         <tr>
            <td style="height: 25px" class="TableTitle" colspan="8">
                &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin" />&nbsp;&nbsp;&nbsp;
                &nbsp;<asp:Button
                    ID="btnCancel" runat="server" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
                    <asp:HiddenField ID="hidCaseID" runat="server" />
                    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
        </tr>
         <tr>
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
                </td>
            <td style="width: 160px; height: 16px">
                &nbsp;
                </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 173px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="height: 16px; width: 12px;">
            </td>
        </tr>
          <tr>
            <td colspan="8">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"  />
            </td>
        </tr>
        <tr>
         <asp:HiddenField ID="HiddenField1" runat="server" />
     <asp:HiddenField ID="hdnVeriTypeId" runat="server" />
     <asp:HiddenField ID="hidMode" runat="server" />
            <td style="width: 56px">
            </td>
            <td style="width: 210px">
            </td>
            <td style="width: 160px">
            </td>
            <td>
            </td>
            <td style="width: 173px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 12px">
            </td>
        </tr>
                    
        </table>
   
  </asp:Panel>  
</asp:Content>