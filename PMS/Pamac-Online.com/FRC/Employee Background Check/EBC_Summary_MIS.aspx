<%@ Page Language="C#" MasterPageFile="~/FRC/Employee Background Check/EBC_MasterPage.master"  AutoEventWireup="true" CodeFile="~/FRC/Employee Background Check/EBC_Summary_MIS.aspx.cs" Inherits="EBC_New_EBC_New_EBC_Summary_MIS" Title="EBC Summary MIS" StylesheetTheme="SkinFile" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">

    function SummaryValidation()
    {
        var txtRefNo=document.getElementById("<%=txtRefNo.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>")   
        
        var ReturnValue=true;
        var ErroMag="";
        
        if(txtRefNo.value=='')
        {
           ErroMag='Please enter Reference No !!!!!!';
           ReturnValue=false; 
           txtRefNo.focus();
        }
        
        lblMessage.innerText=ErroMag;
        if(ErroMag!='')
        {
            window.scrollTo(0,0) 
        }
        return ReturnValue;
    }
    
     function SummaryOthValidation()
    {
        var txtCaseId=document.getElementById("<%=txtCaseId.ClientID%>");
        var ddlFinalStatus=document.getElementById("<%=ddlFinalStatus.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");       
        
        var ReturnValue=true;
        var ErroMag="";
        
        if(ddlFinalStatus.selectedIndex == 0)
        {
           ErroMag='Please select final status......!!!!!';
           ReturnValue=false; 
           ddlFinalStatus.focus();        
        }
        if(txtCaseId.value=='')
        {
           ErroMag='No Record Update ??????';
           ReturnValue=false; 
           txtCaseId.focus();
        }
               
        lblMessage.innerText=ErroMag;
        if(ErroMag!='')
        {
            window.scrollTo(0,0) 
        }
        return ReturnValue;
    }

</script>
    <table style="width: 100%" class="bx">
        <tr>
            <td colspan="10">
                <asp:Label ID="lblMessage" runat="server" Width="100%" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="10" style="height: 21px">
                            Summary MIS</td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px">
            </td>
            <td class="reportTitleIncome" style="height: 21px">
                Reference No.</td>
            <td class="Info" style="height: 21px">
                <asp:TextBox ID="txtRefNo" runat="server" MaxLength="30" SkinID="txtSkin" Width="155px"></asp:TextBox></td>
            <td style="width: 16px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin"
                    Text="Search" /></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                Applicant Name</td>
            <td style="height: 21px;" class="Info" colspan="2">
                <asp:TextBox ID="txtAppName" runat="server" MaxLength="10" SkinID="txtSkin" Width="187px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                Case ID</td>
            <td style="width: 100px; height: 21px;" class="Info">
                <asp:TextBox ID="txtCaseId" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                Recived Date</td>
            <td class="Info" colspan="2" style="height: 21px">
                <asp:TextBox ID="txtRcvdDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                Date of Birth</td>
            <td style="width: 100px; height: 21px;" class="Info">
                <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 11px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                Father Name</td>
            <td style="height: 21px;" class="Info" colspan="2">
                <asp:TextBox ID="txtFatherName" runat="server" MaxLength="10" SkinID="txtSkin" Width="186px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                PAN No.</td>
            <td style="width: 100px; height: 21px;" class="Info">
                <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox></td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px;" class="tta" colspan="10">
                Case Verification Details</td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td colspan="9" rowspan="3">
                <asp:GridView ID="GVSummaryStatus" runat="server" SkinID="gridviewSkin">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td class="reportTitleIncome" style="width: 100px">
                Final Status</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlFinalStatus" runat="server" SkinID="ddlSkin" Width="117px">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Green</asp:ListItem>
                    <asp:ListItem>Red</asp:ListItem>
                    <asp:ListItem>Yellow</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 16px">
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="tta" colspan="10" style="height: 26px">
                &nbsp;<asp:Button ID="btnSave" runat="server" SkinID="btnSaveSkin" Text="Save" OnClick="btnSave_Click1" Width="64px"/></td>
        </tr>
        <tr>
            <td style="width: 11px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 16px">
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

