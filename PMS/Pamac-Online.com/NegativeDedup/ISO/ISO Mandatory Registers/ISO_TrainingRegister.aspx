<%@ Page Language="C#" MasterPageFile="~/ISO/ISO Mandatory Registers/MasterPage.master" AutoEventWireup="true" CodeFile="ISO_TrainingRegister.aspx.cs" Inherits="ISO_ISO_Mandatory_Registers_ISO_TrainingRegister" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>

<script language="javascript" type="text/javascript">
       

function Pro_select(rowno, id)
{
     
        rowno = (parseInt(rowno) + 1);      

        var GrdShow= document.getElementById("<%=GrdShow.ClientID%>");
        var HdnUID = document.getElementById("<%=HdnUID.ClientID%>");
        var txtdate =document.getElementById("<%=txtdate.ClientID%>");
        var txtDuration=document.getElementById("<%=txtDuration.ClientID%>");
        var txtEftvImplntn=document.getElementById("<%=txtEftvImplntn.ClientID%>");
        var TxtEvaluation=document.getElementById("<%=TxtEvaluation.ClientID%>");
        var txtTopic=document.getElementById("<%=txtTopic.ClientID%>");
        var txtTrainer = document.getElementById("<%=txtTrainer.ClientID%>");
        var txttraineeNumber=document.getElementById("<%=txttraineeNumber.ClientID%>");
        var txtTraineesName =document.getElementById("<%=txtTraineesName.ClientID%>");
        var txttrangmndays=document.getElementById("<%=txttrangmndays.ClientID%>");
        var txtVenue=document.getElementById("<%=txtVenue.ClientID%>");
        var ddlvertical=document.getElementById("<%=ddlvertical.ClientID%>");
        var ddlSubCentreName=document.getElementById("<%=ddlSubCentreName.ClientID%>");
        var ddlLocation=document.getElementById("<%=ddlLocation.ClientID%>")
                
        HdnUID.value= GrdShow.rows[rowno].cells[0].innerText;
        ddlvertical.value=GrdShow.rows[rowno].cells[1].innerText;
        txtdate.value=GrdShow.rows[rowno].cells[2].innerText;        
        txtTopic.value=GrdShow.rows[rowno].cells[3].innerText;
        txtTrainer.value=GrdShow.rows[rowno].cells[4].innerText;
        txttraineeNumber.value=GrdShow.rows[rowno].cells[5].innerText;
        txtTraineesName.value=GrdShow.rows[rowno].cells[6].innerText;        
        txtVenue.value=GrdShow.rows[rowno].cells[7].innerText;
        txtDuration.value=GrdShow.rows[rowno].cells[8].innerText;       
        TxtEvaluation.value=GrdShow.rows[rowno].cells[9].innerText;       
        txtEftvImplntn.value=GrdShow.rows[rowno].cells[10].innerText;
        txttrangmndays.value=GrdShow.rows[rowno].cells[11].innerText;
        ddlLocation.value=GrdShow.rows[rowno].cells[12].innerText; 
        ddlSubCentreName.value=GrdShow.rows[rowno].cells[13].innerText;    
           
        var i = 0;
        
        for(i = 0;i <= GrdShow.rows.length-1; i++)
      {
        
        if(i != 0)
        { 
        if (HdnUID.value == GrdShow.rows[i].cells[0].innerText)
           {
            GrdShow.rows[i].style.backgroundColor = "SkyBlue";
           }
        else
           {
            GrdShow.rows[i].style.backgroundColor = "LightYellow";
           }
        }
      }

}

</script>

<script language="javascript" type="text/javascript">

    function Validate_Search()
    {

//debugger

        var txtdate =document.getElementById("<%=txtdate.ClientID%>");
        var txtDuration=document.getElementById("<%=txtDuration.ClientID%>");
        var txtEftvImplntn=document.getElementById("<%=txtEftvImplntn.ClientID%>");
        var TxtEvaluation=document.getElementById("<%=TxtEvaluation.ClientID%>");
        var txtTopic=document.getElementById("<%=txtTopic.ClientID%>");
        var txtTrainer = document.getElementById("<%=txtTrainer.ClientID%>");
        var txttraineeNumber=document.getElementById("<%=txttraineeNumber.ClientID%>");
        var txtTraineesName =document.getElementById("<%=txtTraineesName.ClientID%>");
        var txtVenue=document.getElementById("<%=txtVenue.ClientID%>");
        var ddlvertical=document.getElementById("<%=ddlvertical.ClientID%>");
        var ddlSubCentreName=document.getElementById("<%=ddlSubCentreName.ClientID%>");
        var ddlLocation=document.getElementById("<%=ddlLocation.ClientID%>")

        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        var ErrorMessage='';
        var ReturnValue=true;
        
                
        if(txtEftvImplntn.value=='')
        {
        ErrorMessage='Please Enter Effectiveness Implementation';
        ReturnValue=false;
        txtEftvImplntn.focus();
        }
        
        if(TxtEvaluation.value=='')
        {
        ErrorMessage='Please Enter Evaluation';
        ReturnValue=false;
        TxtEvaluation.focus();
        }
                        
        if(txtVenue.value=='')
        {
        ErrorMessage='Please Enter Venue';
        ReturnValue=false;
        txtVenue.focus();
        }
        
         if(txtTraineesName.value=='')
        {
        ErrorMessage='Please Enter The Trainees Names';
        ReturnValue=false;
        txtTraineesName.focus();
        }
        
        if(txtTrainer.value=='')
        {
        ErrorMessage='Please Enter The Trainer Name';
        ReturnValue=false;
        txtTrainer.focus();
        }
        
        if(txtdate.value=='')
        {
        ErrorMessage='Please Enter The Date Of Training';
        ReturnValue=false;
        txtdate.focus();
        }
        
         if(txttraineeNumber.value=='')
        {
        ErrorMessage='Please Enter The Number Of Trainees';
        ReturnValue=false;
        txttraineeNumber.focus();
        }
        
         if(txtDuration.value=='')
        {
        ErrorMessage='Please Enter The Training Duration';
        ReturnValue=false;
        txtDuration.focus();
        }
        
        if(txtTopic.value=='')
        {
        ErrorMessage='Please Enter The Topic';
        ReturnValue=false;
        txtTopic.focus();
        }
        
        if(ddlvertical.value==0)
        {
        ErrorMessage='Please Select Vertical Name';
        ReturnValue=false;
        ddlvertical.focus();
        }
        
        if(ddlSubCentreName.value==0)
        {
        ErrorMessage='Please Select SubCentre Name';
        ReturnValue=false;
        ddlSubCentreName.focus();
        }
              
        if(ddlLocation.value==0)
        {
        ErrorMessage='Please Select Location/Centre';
        ReturnValue=false;
        ddlLocation.focus();
        }
        
        window.scrollTo(0,0);
        lblMessage.innerText=ErrorMessage;
        return ReturnValue;
        
}



</script>
    <table style="width: 950px">
    <tr>
            <td class="tta" colspan="8" style="height: 25px">
                <span style="font-size: 10pt">&nbsp;Training Register Format</span></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 20px">
                <asp:Panel ID="PnlInsert" runat="server">
    <table style="width: 959px">
        
        <tr>
            <td style="width: 8px; height: 18px">
            </td>
            <td colspan="7" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Crimson"
                    SkinID="lblError"></asp:Label></td>
        </tr>
        <tr style="font-size: 8pt; color: #000000; font-family: Tahoma">
            <td style="width: 8px; height: 30px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                Location</td>
            <td class="Info" style="width: 100px; height: 30px">
                <asp:DropDownList ID="ddlLocation" runat="server" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="130px" AutoPostBack="True">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                SubCentre Name</td>
            <td class="Info" style="width: 100px; height: 30px">
                <asp:DropDownList ID="ddlSubCentreName" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList>&nbsp;</td>
            <td style="width: 22px; height: 30px">
            </td>
            <td style="width: 67px; height: 30px">
            </td>
            <td style="width: 39px; height: 30px">
            </td>
        </tr>
        <tr style="font-size: 8pt; color: #000000; font-family: Tahoma">
            <td style="width: 8px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Vertical</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:DropDownList ID="ddlvertical" runat="server" SkinID="ddlSkin" Width="130px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>ACCOUNT</asp:ListItem>
                    <asp:ListItem>ADMIN</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem>
               
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Topic</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:TextBox ID="txtTopic" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 22px; height: 30px;">
                </td>
            <td style="width: 67px; height: 30px;">
            </td>
            <td style="width: 39px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Duration (hrs.)</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtDuration" runat="server" SkinID="txtSkin" ValidationGroup="VldGrp"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Number Of Trainees</td>
            <td style="width: 100px; height: 30px;" class="Info">
                &nbsp;<asp:TextBox ID="txttraineeNumber" runat="server" 
                    SkinID="txtSkin" ValidationGroup="VldGrp"></asp:TextBox></td>
            <td style="width: 22px; height: 30px;">
                </td>
            <td style="width: 67px; height: 30px;">
            </td>
            <td style="width: 39px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                Date</td>
            <td class="Info" style="width: 100px; height: 30px">
                <asp:TextBox ID="txtdate" runat="server" SkinID="txtSkin" Width="69px" ValidationGroup="VldGrp"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                Trainer</td>
            <td class="Info" style="width: 100px; height: 30px">
                &nbsp;<asp:TextBox ID="txtTrainer" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 22px; height: 30px">
            </td>
            <td style="width: 67px; height: 30px">
            </td>
            <td style="width: 39px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
            Name of Trainees</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtTraineesName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Venue</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtVenue" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 22px; height: 30px;">
            </td>
            <td style="width: 67px; height: 30px;">
            </td>
            <td style="width: 39px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Evaluation</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="TxtEvaluation" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Effectiveness Implementation</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtEftvImplntn" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 22px; height: 30px;">
            </td>
            <td style="width: 67px; height: 30px;">
            </td>
            <td style="width: 39px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 40px">
                <asp:Label ID="Label1" runat="server" Height="21px" Text="Training Mandays" Width="105px"></asp:Label></td>
            <td class="Info" style="width: 100px; height: 40px">
                <asp:TextBox ID="txttrangmndays" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 40px">
                </td>
            <td class="Info" style="width: 100px; height: 40px">
                </td>
            <td style="width: 22px; height: 40px">
            </td>
            <td style="width: 67px; height: 40px">
            </td>
            <td style="width: 39px; height: 40px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px">
            </td>
            <td class="tta" colspan="4">
                <asp:Button ID="BtnSave" runat="server" SkinID="btnSaveSkin" Text="Save" Width="100px" OnClick="BtnSave_Click" ValidationGroup="VldGrp"  />&nbsp;<asp:Button
                        ID="BtnUpdate" runat="server" Text="Update" SkinID="btnUploadSkin" Width="100px" OnClick="BtnUpdate_Click1" ValidationGroup="VldGrp" />&nbsp;<asp:Button
                            ID="BtnView" runat="server" OnClick="BtnView_Click" SkinID="btnExportSkin" Text="View"
                            Width="100px" />&nbsp;
                <asp:Button
                    ID="BtnCancle" runat="server" SkinID="btnResetSkin" Text="Cancel" Width="100px" OnClick="BtnCancle_Click" /></td>
            <td style="width: 22px">
            </td>
            <td style="width: 67px">
            </td>
            <td style="width: 39px">
            </td>
        </tr>
    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 20px">
                <asp:Panel ID="PnlView" runat="server">
                    <table style="width: 967px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                Centre Name</td>
                            <td class="Info" style="width: 100px; height: 30px">
                <asp:DropDownList ID="ddlCenterList" runat="server" SkinID="ddlSkin" Width="130px" OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                SubCentre Name</td>
                            <td class="Info" style="width: 100px; height: 30px">
                <asp:DropDownList ID="ddlSubCenterList" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList></td>
                            <td style="width: 57px; height: 30px">
                            </td>
                            <td style="width: 35px; height: 30px">
                            </td>
                            <td style="width: 37px; height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td class="tta" colspan="4">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnSearchSkin" Width="100px" />&nbsp;
                                <asp:Button
                    ID="BTNReset" runat="server" SkinID="btnResetSkin" Text="Reset" Width="100px" OnClick="BTNReset_Click" /></td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                    <asp:Label ID="lblcount" runat="server" Font-Bold="True" ForeColor="#C00000" SkinID="lblSkin"></asp:Label></asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 152px">
                <asp:Panel ID="pnlgridsearch" runat="server" Width="900px" Height="280px" ScrollBars="Both">
                    <asp:GridView ID="GrdShow" runat="server" SkinID="gridviewNoSort" OnRowDataBound="GrdShow_RowDataBound1">
                    </asp:GridView>
                </asp:Panel>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 32px;" colspan="7">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HiddenField ID="HdnUID" runat="server" />
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
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

