<%@ Page Language="C#" MasterPageFile="~/ISO/ISO Mandatory Registers/MasterPage.master" AutoEventWireup="true" CodeFile="ISO_DeviationRegister.aspx.cs" Inherits="ISO_ISO_Mandatory_Registers_DeviationRegister" Title="Untitled Page" StylesheetTheme="SkinFile"%>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="ecmascript" type="text/javascript" src="../../popcalendar.js">
</script>


<script language="JAVASCRIPT" type="text/javascript"> 

  
    function Validate_Search()
    {
    
        
//  debugger 
  
        var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
        var txtdateDeviation= document.getElementById("<%=txtdateDeviation.ClientID%>");
        var ddlClientList= document.getElementById("<%=ddlClientList.ClientID%>");       
        var txtNatureDeviation= document.getElementById("<%=txtNatureDeviation.ClientID%>");
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
             ErrorMessage='Please Enter Root Cause Of Deviation!';
             ReturnValue=false; 
             txtRootCause.focus();
        }   
                if (txtNatureDeviation.value =='')       
        { 
             ErrorMessage='Please Enter Nature of Deviatin!';
             ReturnValue=false; 
             txtNatureDeviation.focus();
        }  
        
   
              if (txtdateDeviation.value =='')       
       {
           ErrorMessage='Please Enter Deviation Date!';
            ReturnValue=false; 
            txtdateDeviation.focus();
             
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
     
//    debugger
    
         rowno = (parseInt(rowno) + 1);                    // Increament By 1
         
        var GridView2= document.getElementById("<%=GridView2.ClientID%>");  //Imp
        var HdnUID = document.getElementById("<%=HdnUID.ClientID%>");       //Imp
        
        var ddlVerticalName = document.getElementById("<%=ddlVerticalName.ClientID%>");
        var txtdateDeviation= document.getElementById("<%=txtdateDeviation.ClientID%>");
        var ddlClientList= document.getElementById("<%=ddlClientList.ClientID%>");       
        var txtNatureDeviation= document.getElementById("<%=txtNatureDeviation.ClientID%>");
        var txtRootCause= document.getElementById("<%=txtRootCause.ClientID%>");    
        var txtCorrection= document.getElementById("<%=txtCorrection.ClientID%>");  
        var txtCorrActn= document.getElementById("<%=txtCorrActn.ClientID%>");     
        var txtEffctveCorrActn= document.getElementById("<%=txtEffctveCorrActn.ClientID%>");               
        var txtPreventiveAction= document.getElementById("<%=txtPreventiveAction.ClientID%>");
        var txtEffctvePrevActn= document.getElementById("<%=txtEffctvePrevActn.ClientID%>");       
        var  txtclosingdate= document.getElementById("<%=txtclosingdate.ClientID%>");
        var DDLSubcentre= document.getElementById("<%=DDLSubcentre.ClientID%>");
       
      
        HdnUID.value=GridView2.rows[rowno].cells[0].innerText;
        ddlVerticalName.value = GridView2.rows[rowno].cells[1].innerText;        
        txtdateDeviation.value = GridView2.rows[rowno].cells[2].innerText;
        ddlClientList.value=GridView2.rows[rowno].cells[13].innerText;
        txtNatureDeviation.value = GridView2.rows[rowno].cells[4].innerText;
        txtRootCause.value = GridView2.rows[rowno].cells[5].innerText;
        txtCorrection.value = GridView2.rows[rowno].cells[6].innerText;
        txtCorrActn.value = GridView2.rows[rowno].cells[7].innerText;
        txtEffctveCorrActn.value = GridView2.rows[rowno].cells[8].innerText;
        txtPreventiveAction.value = GridView2.rows[rowno].cells[9].innerText;
        txtEffctvePrevActn.value = GridView2.rows[rowno].cells[10].innerText;
        txtclosingdate.value = GridView2.rows[rowno].cells[11].innerText;       
        DDLSubcentre.value = GridView2.rows[rowno].cells[15].innerText;      


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
       
    <table style="width: 950px">
    
    <tr>
            <td class="tta" colspan="8" style="height: 25px">
                <span style="font-size: 10pt">Deviation Register Format</span></td>
        </tr>
        
        <tr>
            <td colspan="7">
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
                <asp:DropDownList ID="ddlVerticalName" runat="server" SkinID="ddlSkin" Width="130px" >
                    <asp:ListItem>--Select--</asp:ListItem>
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
                <asp:DropDownList ID="ddlClientList" runat="server" SkinID="ddlSkin" Width="130px" TabIndex="1">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 30px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtclosingdate"
                    ErrorMessage="Please Enter Complete Information" ValidationGroup="VldGrp">*</asp:RequiredFieldValidator></td>
            <td style="width: 36px; height: 30px;"></td>
            <td style="width: 7px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 36px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Date of Deviation</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtdateDeviation" runat="server" SkinID="txtSkin" Width="74px" ValidationGroup="VldGrp" TabIndex="2"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdateDeviation.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Nature of Deviation</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtNatureDeviation" runat="server" SkinID="txtSkin" Width="130px" TabIndex="3"></asp:TextBox></td>
            <td style="width: 100px; height: 36px;">
            </td>
            <td style="width: 36px; height: 36px;">
            </td>
            <td style="width: 7px; height: 36px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Root Cause</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:TextBox ID="txtRootCause" runat="server" SkinID="txtSkin" Width="130px" TabIndex="4"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 30px;">
                Correction</td>
            <td class="Info" style="width: 100px; height: 30px;">
                <asp:TextBox ID="txtCorrection" runat="server" SkinID="txtSkin" Width="130px" TabIndex="5"></asp:TextBox></td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 36px; height: 30px;">
            </td>
            <td style="width: 7px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 36px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Corrective Action</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtCorrActn" runat="server" SkinID="txtSkin" Width="130px" TabIndex="6"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 36px;">
                Effectiveness for Corrective Action</td>
            <td class="Info" style="width: 100px; height: 36px;">
                <asp:TextBox ID="txtEffctveCorrActn" runat="server" SkinID="txtSkin" Width="130px" TabIndex="7"></asp:TextBox></td>
            <td style="width: 100px; height: 36px;">
            </td>
            <td style="width: 36px; height: 36px;">
            </td>
            <td style="width: 7px; height: 36px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 31px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 31px;">
                Preventive Action</td>
            <td class="Info" style="width: 100px; height: 31px;">
                <asp:TextBox ID="txtPreventiveAction" runat="server" SkinID="txtSkin" Width="130px" TabIndex="8"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 100px; height: 31px;">
                Effectiveness for Preventive Action</td>
            <td class="Info" style="width: 100px; height: 31px;">
                &nbsp;<asp:TextBox ID="txtEffctvePrevActn" runat="server" SkinID="txtSkin" Width="130px" TabIndex="9"></asp:TextBox></td>
            <td style="width: 100px; height: 31px;">
            </td>
            <td style="width: 36px; height: 31px;">
            </td>
            <td style="width: 7px; height: 31px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                Closing Date</td>
            <td style="width: 100px; height: 30px;" class="Info">
                <asp:TextBox ID="txtclosingdate" runat="server" SkinID="txtSkin" Width="75px" ValidationGroup="VldGrp" TabIndex="10"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtclosingdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td style="width: 100px; height: 30px;" class="reportTitleIncome">
                SubCentre Name</td>
            <td style="width: 100px; height: 30px;" class="Info">
                &nbsp;<asp:DropDownList ID="DDLSubcentre" runat="server" SkinID="ddlSkin" Width="130px" ValidationGroup="VldGrp" TabIndex="11">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 30px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdateDeviation"
                    ErrorMessage="Please Enter Complete Information" ValidationGroup="VldGrp">*</asp:RequiredFieldValidator></td>
            <td style="width: 36px; height: 30px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDLSubcentre"
                    ErrorMessage="Please Select SubCentre Name" ValidationGroup="VldGrp" InitialValue="0">*</asp:RequiredFieldValidator></td>
            <td style="width: 7px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 30px">
            </td>
            <td class="tta" colspan="4">
                <asp:Button ID="btnSave" runat="server" SkinID="btnSaveSkin"
                    Text="Save" Width="109px" OnClick="btnSave_Click" ValidationGroup="VldGrp" TabIndex="12" />&nbsp;
                <asp:Button ID="BtnView" runat="server" SkinID="btnSaveSkin"
                    Text="View" Width="120px" OnClick="BtnView_Click" TabIndex="13"  />
                <asp:Button ID="BtnUpdate" runat="server" SkinID="btnUploadSkin"
                    Text="Update" Width="120px" OnClick="BtnUpdate_Click" TabIndex="14"  />
                <asp:Button ID="btnCancle" runat="server" SkinID="btnCancelSkin" Text="Cancel" Width="123px" OnClick="btnCancle_Click" TabIndex="15"  />&nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 36px">
            </td>
            <td style="width: 7px; height: 30px">
            </td>
        </tr>
    </table>
                                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 20px">
              <asp:Panel ID="Panel1" runat="server" Width="100px">
                    <table style="width: 954px">
                        <tr>
                            <td class="reportTitleIncome" style="width: 100px; height: 30px">
                                Centre Name</td>
                            <td class="Info" style="width: 100px; height: 30px">
                                <asp:DropDownList ID="ddlCenterList" runat="server" SkinID="ddlSkin" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged" TabIndex="17">
                                </asp:DropDownList></td>
                            <td class="reportTitleIncome" style="width: 107px; height: 30px">
                                SubCentre Name</td>
                            <td class="Info" style="width: 100px; height: 30px">
                                <asp:DropDownList ID="ddlSubCenterList" runat="server" SkinID="ddlSkin" Width="130px" TabIndex="18">
                                </asp:DropDownList></td>
                            <td style="width: 35px; height: 30px">
                            </td>
                            <td style="width: 100px; height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td class="tta" colspan="4">
                                <asp:Button ID="BtnSearch" runat="server"  SkinID="btnSearchSkin"
                                    Text="Search" Width="100px" OnClick="BtnSearch_Click" />&nbsp;<asp:Button ID="BtnReset" runat="server" 
                                        SkinID="btnResetSkin" Text="Reset" Width="100px" OnClick="BtnReset_Click"  /></td>
                            <td style="width: 35px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                  <asp:Label ID="lblcount" runat="server" Font-Bold="True" ForeColor="#C00000" SkinID="lblSkin" Width="128px"></asp:Label></asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 152px">
               <asp:Panel ID="PnlGridExport" runat="server" Width="930px" Height="280px" ScrollBars="Both">
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="false" SkinID="gridviewNoSort"  AllowPaging="false" AutoGenerateColumns="true"  Width="100px" OnRowDataBound="GridView2_RowDataBound">
                    </asp:GridView>
                                   
                </asp:Panel>
                &nbsp;&nbsp;
                <asp:HiddenField ID="HdnUID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="VldGrp" />
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

