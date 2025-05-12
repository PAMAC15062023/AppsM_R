<%@ Page Language="C#" MasterPageFile="~/ISO/ISO Mandatory Registers/MasterPage.master" AutoEventWireup="true" CodeFile="ISO_ComplaintRagister.aspx.cs" Inherits="ISO_ISO_Mandatory_Registers_ISO_ComplaintRagister" Title="Complaint Ragister" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="ecmascript" type="text/javascript" src="../../popcalendar.js">
</script>

<script language="JAVASCRIPT" type="text/javascript"> 

    function Validate_Search()
    {  
        var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
        var txtdatecomplaint= document.getElementById("<%=txtdatecomplaint.ClientID%>");
        var ddlClientList= document.getElementById("<%=ddlClientList.ClientID%>");       
        var txtNatureComplaint= document.getElementById("<%=txtNatureComplaint.ClientID%>");
        var txtRootCause= document.getElementById("<%=txtRootCause.ClientID%>");    
        var txtCorrection= document.getElementById("<%=txtCorrection.ClientID%>");  
        var txtCorrActn= document.getElementById("<%=txtCorrActn.ClientID%>");     
        var txtEffctveCorrActn= document.getElementById("<%=txtEffctveCorrActn.ClientID%>");               
        var txtPreventiveAction= document.getElementById("<%=txtPreventiveAction.ClientID%>");
        var txtEffctvePrevActn= document.getElementById("<%=txtEffctvePrevActn.ClientID%>");       
        var txtclosingdate= document.getElementById("<%=txtclosingdate.ClientID%>");     
        var DDLSubcentre=document.getElementById("<%=DDLSubcentre.ClientID%>");    
        
       var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");       
       var ErrorMessage='';
       var ReturnValue=true;
                
            if (DDLSubcentre.value ==0)       
        { 
             ErrorMessage='Please Enter Subcentre Name!';
             ReturnValue=false; 
             DDLSubcentre.focus();
        }   
            
            if (txtclosingdate.value =='')       
        { 
             ErrorMessage='Please Enter Closing Date!';
             ReturnValue=false; 
             txtclosingdate.focus();
        }  
          if (txtEffctvePrevActn.value =='')       
        { 
             ErrorMessage='Please Enter Effectiveness for Preventive Action!';
             ReturnValue=false; 
             txtEffctvePrevActn.focus();
        }  
                    if (txtPreventiveAction.value =='')       
        { 
             ErrorMessage='Please Enter Preventive Action!';
             ReturnValue=false; 
             txtPreventiveAction.focus();
        }   
                    if (txtEffctveCorrActn.value =='')       
        { 
             ErrorMessage='Please Enter Effectiveness for Corrective Action!';
             ReturnValue=false; 
             txtEffctveCorrActn.focus();
        }   
                    if (txtCorrActn.value =='')       
        { 
             ErrorMessage='Please Enter Corrective Action!';
             ReturnValue=false; 
             txtCorrActn.focus();
        }   
               if (txtCorrection.value =='')       
        { 
             ErrorMessage='Please Enter Correction!';
             ReturnValue=false; 
             txtCorrection.focus();
        }   
                if (txtRootCause.value =='')       
        { 
             ErrorMessage='Please Enter Root Cause Of Complaint!';
             ReturnValue=false; 
             txtRootCause.focus();
        }   
                if (txtNatureComplaint.value =='')       
        { 
             ErrorMessage='Please Enter Nature of Complaint!';
             ReturnValue=false; 
             txtNatureComplaint.focus();
        }  
        
   
              if (txtdatecomplaint.value =='')       
       {
           ErrorMessage='Please Enter Complaint Date!';
            ReturnValue=false; 
            txtdatecomplaint.focus();
             
       }  
                   if (ddlClientList.value ==0)       
       {
             ErrorMessage='Please Select Client list!';
             ReturnValue=false;
             ddlClientList.focus();
       } 
       
              if (ddlVerticalName.value ==0)  
       {
            ErrorMessage='Please Select Vertical name!';
             ReturnValue=false; 
             ddlVerticalName.focus();
       }
       
         window.scrollTo(0,0);    
         lblMessage.innerText=ErrorMessage;
         return ReturnValue;
         
    }  
    </script>

<script language="javascript" type="text/javascript">

function Pro_selectRow(rowno, id)
     {
     
//        debugger
    
        rowno = (parseInt(rowno) + 1);                    // Increament By 1
         
        var GridView2= document.getElementById("<%=GridView2.ClientID%>");  //Imp
        var HdnUID = document.getElementById("<%=HdnUID.ClientID%>");       //Imp
        
        var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
        var txtdatecomplaint= document.getElementById("<%=txtdatecomplaint.ClientID%>");
        var ddlClientList= document.getElementById("<%=ddlClientList.ClientID%>");       
        var txtNatureComplaint= document.getElementById("<%=txtNatureComplaint.ClientID%>");
        var txtRootCause= document.getElementById("<%=txtRootCause.ClientID%>");    
        var txtCorrection= document.getElementById("<%=txtCorrection.ClientID%>");  
        var txtCorrActn= document.getElementById("<%=txtCorrActn.ClientID%>");     
        var txtEffctveCorrActn= document.getElementById("<%=txtEffctveCorrActn.ClientID%>");               
        var txtPreventiveAction= document.getElementById("<%=txtPreventiveAction.ClientID%>");
        var txtEffctvePrevActn= document.getElementById("<%=txtEffctvePrevActn.ClientID%>");       
        var txtclosingdate= document.getElementById("<%=txtclosingdate.ClientID%>");     
        var DDLSubcentre=document.getElementById("<%=DDLSubcentre.ClientID%>");     
      
        HdnUID.value=GridView2.rows[rowno].cells[0].innerText;
        ddlVerticalName.value = GridView2.rows[rowno].cells[1].innerText;        
        txtdatecomplaint.value = GridView2.rows[rowno].cells[2].innerText;
        ddlClientList.value=GridView2.rows[rowno].cells[13].innerText;
        txtNatureComplaint.value = GridView2.rows[rowno].cells[4].innerText;
        txtRootCause.value = GridView2.rows[rowno].cells[5].innerText;
        txtCorrection.value = GridView2.rows[rowno].cells[6].innerText;
        txtCorrActn.value = GridView2.rows[rowno].cells[7].innerText;
        txtEffctveCorrActn.value = GridView2.rows[rowno].cells[8].innerText;
        txtPreventiveAction.value = GridView2.rows[rowno].cells[9].innerText;
        txtEffctvePrevActn.value = GridView2.rows[rowno].cells[10].innerText;
        txtclosingdate.value = GridView2.rows[rowno].cells[11].innerText;       
        DDLSubcentre.value= GridView2.rows[rowno].cells[15].innerText;       

        var i = 0;                          

        for (i = 0; i <= GridView2.rows.length - 1; i++)
         {
             if (i != 0) 
            {
                if (HdnUID.value == GridView2.rows[i].cells[0].innerText) 
                {
                    GridView2.rows[i].style.backgroundColor = "SkyBlue";
                }
                else 
                {
                    GridView2.rows[i].style.backgroundColor = "LightYellow";
                }
            }
         }

      }
        
        
</script>
    <table style="width: 953px">
       <tr>
            <td class="tta" colspan="8" style="height: 25px">
                <span style="font-size: 10pt">&nbsp;Complaint Register Format</span></td>
        </tr>
        <tr>
            <td colspan="6">
                                <asp:Panel ID="PnlInsert" runat="server" Width="100px">


    <table style="width: 953px">
     
        <tr>
            <td style="width: 8px; height: 18px">
            </td>
            <td colspan="7" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Crimson"
                    SkinID="lblError"></asp:Label></td>
        </tr>
        <tr style="color: #000000; font-family: Tahoma; font-size: 12pt;">
            <td style="width: 8px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Segment</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:DropDownList ID="ddlVerticalName" runat="server" SkinID="ddlSkin" Width="130px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem>
                    <asp:ListItem>PCRU</asp:ListItem>
                    <asp:ListItem>ACCOUNT</asp:ListItem>
                    <asp:ListItem>ADMIN</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem> 
                    <asp:ListItem>RSP</asp:ListItem>
                     <asp:ListItem>RES</asp:ListItem>
                    
                    
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Client Name</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 30px;">
                </td>
            <td style="width: 40px; height: 30px;"></td>
            <td style="width: 62px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 36px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Date of Complaint</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtdatecomplaint" runat="server" SkinID="txtSkin" Width="74px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdatecomplaint.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Nature of Complaint</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtNatureComplaint" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td style="width: 100px; height: 36px;">
            </td>
            <td style="width: 40px; height: 36px;">
            </td>
            <td style="width: 62px; height: 36px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Root Cause</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:TextBox ID="txtRootCause" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Correction</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:TextBox ID="txtCorrection" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 40px; height: 30px;">
            </td>
            <td style="width: 62px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 36px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Corrective Action</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtCorrActn" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Effectiveness for Corrective Action</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtEffctveCorrActn" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td style="width: 100px; height: 36px;">
            </td>
            <td style="width: 40px; height: 36px;">
            </td>
            <td style="width: 62px; height: 36px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 31px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 31px;">
                Preventive Action</td>
            <td class="Info" style="width: 100px; height: 31px;">
                <asp:TextBox ID="txtPreventiveAction" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 31px;">
                Effectiveness for Preventive Action</td>
            <td class="Info" style="width: 100px; height: 31px;">
                &nbsp;<asp:TextBox ID="txtEffctvePrevActn" runat="server" SkinID="txtSkin" Width="130px"></asp:TextBox></td>
            <td style="width: 100px; height: 31px;">
            </td>
            <td style="width: 40px; height: 31px;">
            </td>
            <td style="width: 62px; height: 31px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Closing Date</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtclosingdate" runat="server" SkinID="txtSkin" Width="75px"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtclosingdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" /></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                SubCentre Name</td>
            <td style="width: 100px; height: 30px;" class="Info">
                &nbsp;<asp:DropDownList ID="DDLSubcentre" runat="server" SkinID="ddlSkin" Width="130px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 30px;">
                </td>
            <td style="width: 40px; height: 30px;">
                </td>
            <td style="width: 62px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px">
            </td>
            <td class="tta" colspan="4">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                    Text="Save" Width="100px"  />&nbsp;
                <asp:Button ID="BtnView" runat="server" SkinID="btnSaveSkin"
                    Text="View" Width="100px" OnClick="BtnView_Click" />
                <asp:Button ID="BtnUpdate" runat="server" SkinID="btnUploadSkin"
                    Text="Update" Width="100px" OnClick="BtnUpdate_Click" ValidationGroup="VldGrp" />
                <asp:Button ID="btnCancle" runat="server" SkinID="btnCancelSkin" Text="Cancel" Width="100px" OnClick="btnCancle_Click" />&nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 40px">
            </td>
            <td style="width: 62px; height: 30px">
            </td>
        </tr>
    </table>
                                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Width="100px">
                    <table style="width: 954px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 92px;">
                                Cemtre Name</td>
                            <td class="Info">
                                <asp:DropDownList ID="ddlCenterList" runat="server" SkinID="ddlSkin" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 70px;">
                                SubCentre Name</td>
                            <td class="Info" style="width: 75px;">
                                <asp:DropDownList ID="ddlSubCenterList" runat="server" SkinID="ddlSkin" Width="130px">
                                </asp:DropDownList></td>
                            <td style="width: 292px; height: 30px">
                            </td>
                            <td style="width: 100px; height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td class="tta" colspan="4">
                                <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click1" SkinID="btnSearchSkin"
                                    Text="Search" Width="100px" />&nbsp;<asp:Button ID="BtnReset" runat="server" 
                                        SkinID="btnResetSkin" Text="Reset" Width="100px" OnClick="BtnReset_Click" /></td>
                            <td style="width: 292px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblcount" runat="server" Font-Bold="True" ForeColor="#C00000" SkinID="lblSkin" Width="179px"></asp:Label></asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="PnlGridExport" runat="server" Width="950px" ScrollBars="Both" Height="281px">
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="false" SkinID="gridviewNoSort" AutoGenerateColumns="true"  Width="890px" OnRowDataBound="GridView2_RowDataBound">
                    </asp:GridView>
                                   
                </asp:Panel>
                &nbsp;<br />
                <asp:HiddenField ID="HdnUID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="VldGrp" />
                &nbsp;&nbsp;&nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

