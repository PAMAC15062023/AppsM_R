<%@ Page Language="C#" MasterPageFile="~/Admin/Agreement/MasterPage.master"AutoEventWireup="true" CodeFile="AGREEMENT.aspx.cs" Inherits="Admin_Agreement_Agreement" Title="Untitled Page" EnableEventValidation="false" Theme="SkinFile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script type="text/javascript" language="javascript">


  function Check(evt)
    {
        if(evt.keyCode == 32)
        {
            alert("Space not allowed");
            return false;
        }
        return true;
    }



function checkNumeric(textBox) 
{
    var textBox = document.getElementById(textBox); 
    if(isNaN(textBox.value)) 
    {
        alert("-Please provide a numeric value."); 
        textBox.value=""; 
        return false; 
    }
}

</script>

<table style="width: 160px">
    
        <tr>
            <td colspan="4">
    
    <asp:Panel ID="pnlCategory" runat="server" Width="861px">
<table style="width: 864px">
<tr>
            <td class="tta" colspan="8" style="height: 19px; width: 80%;">
                <span style="font-size: 10pt"> New Client Agreement </span></td>
        </tr>


    <tr>
     <td style="width: 601px; height: 32px;" align="center" class="reportTitleIncome">
         <center><strong>Category</strong></center></td>
    <td style="width: 601px; height: 32px;" align="center" class="Info">
        <asp:DropDownList  ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
        SkinID="ddlSkin" Width="178px">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>New Agreement</asp:ListItem>
        <asp:ListItem>Annexure</asp:ListItem>
    </asp:DropDownList></td>
    </tr>
    </table>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">



    <asp:Panel ID="pnlAgreementDetails" runat="server"  Width="864px" Visible="False">

    <table style="width: 866px">
      <tr>
            <td class="tta" colspan="8" style="height: 19px; width: 97%;">
                <span style="font-size: 10pt"> Agreement Details</span></td>
        </tr>
    
            <tr>
            <td colspan="8" style="height: 21px">
                <asp:Label ID="Lblmsg" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="#C00000" Width="664px"></asp:Label></td>
        </tr>
    

        <tr>
            <td style="width: 143px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Client</strong></td>
            <td style="width: 153px" class="Info">
                <asp:DropDownList ID="ddlClient" runat="server" Width="158px" SkinID="ddlSkin">
                </asp:DropDownList></td>
                 <td style="width: 143px; height: 32px;" align="right" class="reportTitleIncome">
                <strong> Agreemant Date&nbsp;</strong></td>
            <td style="width: 159px" class="Info">
                <asp:TextBox ID="txtagrmntstart" runat="server" Width="80px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtagrmntstart.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
         </tr>       
         <tr>  
            <td style="width: 143px" align="right" class="reportTitleIncome">
                <strong>Date Of Agreemt From</strong></td>
            <td style="width: 153px" class="Info">
                <asp:TextBox ID="txtDateOfAgreementFrom" runat="server" Width="80px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfAgreementFrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
            <td style="width: 131px" class="reportTitleIncome">
                <strong>Valid Upto</strong></td>
            <td style="width: 152px" class="Info">
                <asp:TextBox ID="txtDateOfAgreementValidUpto" runat="server" Width="80px" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfAgreementValidUpto.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                    src="../../Images/SmallCalendar.png" /></td>
         </tr>

        <tr>
          <td style="width: 143px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Contact Person Name</strong></td>
            <td style="width: 153px; height: 32px;" class="Info">
                <asp:TextBox ID="txtContactPersonName" runat="server" Width="151px" SkinID="txtSkin" OnKeyup=UpperLetter(this)></asp:TextBox></td>
            <td style="width: 131px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Contact Person Email-Id</strong></td>
            <td style="width: 84px; height: 32px;" class="Info">
                <asp:TextBox ID="Txtemailid" runat="server" Width="135px" SkinID="txtSkin" ></asp:TextBox></td>
            
               
        </tr>
        
         <tr>
        <td style="width: 131px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Company Name</strong></td>
            <td style="height: 32px;" class="Info" colspan="3">
                <asp:DropDownList ID="ddlcompany_name" runat="server" Width="228px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>PAMAC FinServe Pvt. Ltd.</asp:ListItem>
                    <asp:ListItem>TeamSpace Finance Service Pvt. Ltd.</asp:ListItem>
                       <asp:ListItem>Quantum Multipoint Services</asp:ListItem>
                        <asp:ListItem>Orion Consultancy Services</asp:ListItem>
                </asp:DropDownList><strong></strong></td>
        </tr>

        <tr>
            <td style="width: 143px; height: 31px;" align="right" class="reportTitleIncome">
                <strong>Status</strong></td>
            <td style="width: 153px; height: 31px;" class="Info">
                <asp:DropDownList ID="ddlstatus" runat="server" Width="140px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Present</asp:ListItem>
                    <asp:ListItem>Renew</asp:ListItem>
                    <asp:ListItem>Close</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 131px; height: 31px;" align="right" class="reportTitleIncome">
                <strong>Notice Period</strong></td>
            <td style="width: 152px; height: 31px;" class="Info">
                <asp:DropDownList ID="ddlnoticepd" runat="server" Width="140px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>1 Month</asp:ListItem>
                    <asp:ListItem>2 Months</asp:ListItem>
                    <asp:ListItem>3 Months</asp:ListItem>
                </asp:DropDownList></td>

        </tr>

        <tr>
            <td style="width: 143px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Leagal Check Done</strong></td>
            <td style="width: 153px; height: 32px;" class="Info">
                <asp:DropDownList ID="ddllcd" runat="server" Width="140px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 131px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Leagal Check Done By</strong></td>
            <td style="width: 152px; height: 32px;" class="Info">
                <asp:TextBox ID="txtLeagalCheckDoneBy" runat="server" Width="135px" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        
        
        <tr>
            <td style="width: 143px; height: 32px;" align="right" class="reportTitleIncome">
                <strong>Minimum Guarranty</strong></td>
            <td style="width: 153px; height: 32px;" class="Info">
                <asp:DropDownList ID="ddlmin_ga" runat="server" Width="140px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 131px; height: 26px;" align="right" class="reportTitleIncome">
                <strong>Amount</strong></td>
            <td style="width: 152px; height: 26px;" class="Info">
                <asp:TextBox ID="txtamount" runat="server" Width="135px" SkinID="txtSkin" onkeydown="return Check(event)" Onchange ="return checkNumeric('ctl00_C1_txtamount');"></asp:TextBox></td>
        </tr>

<tr>
            <td class="Info" colspan="6" rowspan="1" style="width: 764px; height: 45px;">
            <center><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnSaveSkin" Width="105px"/>
                <asp:Button ID="btnmis" runat="server" OnClick="btnmis_Click" SkinID="btn" Text="MIS"
                    Width="90px" />
                <asp:HiddenField ID="HdnAgreement_id" runat="server" />
            </center> 
                &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
    
        </tr>
    </table>
           <asp:GridView ID="grdmis" runat="server" SkinID="gridviewSkin" >
           </asp:GridView>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
    
    
       <asp:Panel ID="pnlRateDetails" runat="server"  Width="69px" Visible="False">
    <table style="width: 867px">
    <tr>
        <td colspan="9" style="height: 21px">
                <asp:Label ID="Lblmsg1" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="#C00000" Width="664px"></asp:Label></td>
    </tr>
    
    <tr>
        <td class="tta" colspan="8" style="height: 19px">
                <span style="font-size: 10pt"> Rate Details</span></td>
     </tr>
     <tr>
            <td class="reportTitleIncome" style="width: 202px; height: 34px">
                <strong>Centre</strong></td>
            <td class="Info" style="width: 289px; height: 34px">
                <asp:TextBox ID="txtcntre" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
            <td style="width: 236px; height: 34px" class="reportTitleIncome">
                <strong>Vertical</strong></td>
            <td style="width: 329px; height: 34px" class="Info">
                <asp:TextBox ID="txtvertical" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
     </tr>
     <tr>
            <td style="width: 202px; height: 33px" class="reportTitleIncome">
               <strong>Activity</strong></td>
            <td style="width: 289px; height: 33px" class="Info">
                <asp:TextBox ID="txtActivity" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
            <td style="width: 236px; height: 33px" class="reportTitleIncome">
               <strong>Product</strong></td>
            <td style="width: 329px; height: 33px" class="Info">
                <asp:TextBox ID="txtProduct" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>     
     </tr>       
     <tr>
            <td style="width: 202px; height: 28px" class="reportTitleIncome">
                 <strong>Rate</strong></td>
            <td style="width: 289px; height: 28px" class="Info">
                <asp:TextBox ID="txtRate" runat="server" SkinID="txtSkin" Width="160px" onkeydown="return Check(event)" Onchange ="return checkNumeric('ctl00_C1_txtRate');"></asp:TextBox></td>
            <td style="height: 28px; width: 236px;" class="reportTitleIncome">
               <strong>City Limit</strong></td>     
            <td style="height: 28px; width: 329px;" class="Info">
                <asp:DropDownList ID="ddlicl" runat="server" SkinID="ddlSkin" Width="160px">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>OCL</asp:ListItem>
                    <asp:ListItem>ICL</asp:ListItem>
                     <asp:ListItem>NA</asp:ListItem>
              
                   
                </asp:DropDownList></td>     
     </tr>    
     <tr>
            <td class="reportTitleIncome" style="width: 202px; height: 28px">
                <strong>TAT (hh:mm)</strong></td>
            <td class="Info" style="width: 289px; height: 28px">
                <asp:TextBox ID="txtRATETAT" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
            <td class="reportTitleIncome" style="width: 236px; height: 28px">
            </td>
            <td class="Info" style="width: 329px; height: 28px">
            </td>
        </tr>
     
     <tr>
     <td class="Info" rowspan="1" colspan="4" style="height: 33px">
                <center><asp:Button ID="btnSave1" runat="server" Text="Save" SkinID="btnSaveSkin"  Width="90px" OnClick="btnSave1_Click" />
                    <asp:HiddenField ID="hI" runat="server" />
                </center></td>
     </tr>    
    <tr></tr>
    </table>
           <asp:GridView ID="grv_agr" runat="server" SkinID="gridviewSkin">
           </asp:GridView>
    </asp:Panel>   
            </td>
        </tr>
        <tr>
            <td colspan="4">
    
        <asp:Panel ID="pnlAnnexure" runat="server"  Width="393px" Visible="False">

    <table style="width: 871px">
      <tr>
            <td class="tta" colspan="8" style="height: 19px; width: 97%;">
                <span style="font-size: 10pt">Annexure</span></td>
        </tr>
    
            <tr>
            <td colspan="8" style="height: 21px">
                <asp:Label ID="Lblmsg3" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="#C00000" Width="744px"></asp:Label></td>
        </tr>

        <tr>
            <td style="width: 189px; height: 29px;" align="right" class="reportTitleIncome">
                <strong>Client</strong></td>
            <td class="Info" colspan="6" style="height: 29px">
                <asp:DropDownList ID="ddlclientAnnexure" runat="server" Width="330px" AutoPostBack="True" SkinID="ddlSkin" OnSelectedIndexChanged="ddlclientAnnexure_SelectedIndexChanged">
                </asp:DropDownList></td>
         </tr>       
         <tr>
            <td class="reportTitleIncome" style="width: 197px; height: 29px">
                <strong>Centre</strong></td>
            <td class="Info" style="width: 492px; height: 29px">
                <asp:TextBox ID="txtcentre_annexure" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
            <td style="width: 470px; height: 29px" class="reportTitleIncome">
                <strong>Vertical</strong></td>
            <td style="width: 470px; height: 29px" class="Info">
                <asp:TextBox ID="txtvertical_annexure" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
         </tr>
         <tr>
            <td style="width: 174px; height: 31px" class="reportTitleIncome">
                <strong>Activity</strong></td>
            <td style="width: 492px; height: 31px" class="Info">
                <asp:TextBox ID="txtactivity_annexure" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
            <td style="width: 294px; height: 31px" class="reportTitleIncome">
                 <strong>Product</strong></td>
            <td style="width: 294px; height: 31px" class="Info">
                <asp:TextBox ID="txtproduct_annexure" runat="server" SkinID="txtSkin" Width="160px"></asp:TextBox></td>
         </tr>
         <tr>
            <td style="width: 492px; height: 32px" class="reportTitleIncome">
                 <strong>Rate</strong></td>
            <td style="width: 492px; height: 32px" class="Info">
                <asp:TextBox ID="txtrate_annexure" runat="server" SkinID="txtSkin" Width="160px" onkeydown="return Check(event)" Onchange ="return checkNumeric('ctl00_C1_txtrate_annexure');"></asp:TextBox></td>
            <td style="width: 374px; height: 32px" class="reportTitleIncome">
                <strong>ICL</strong></td>
            <td style="width: 374px; height: 32px" class="Info">
                <asp:DropDownList ID="ddlicl_annexure" runat="server" SkinID="ddlSkin" Width="160px">
                    <asp:ListItem>--Select--</asp:ListItem>
                  <asp:ListItem>OCL</asp:ListItem>
                    <asp:ListItem>ICL</asp:ListItem>
                       <asp:ListItem>NA</asp:ListItem>
                      </asp:DropDownList></td>
         </tr>
         <tr>
         <td class="reportTitleIncome">
             <strong>&nbsp;Upload File</strong></td>
         <td class="Info" colspan="3">
         <asp:FileUpload ID="FileUpload2" runat="server" Width="381px" />
         </td>
         </tr>  
        
         <tr> 
            <td class="Info" rowspan="1" colspan="4">
                <center><asp:Button ID="btnSave2" runat="server" Text="Save" SkinID="btnSaveSkin"  Width="90px" OnClick="btnSave2_Click" />
            <%--        <asp:Button ID="btnmis" runat="server" OnClick="btnmis_Click" Text="MIS" Width="80px" /></center></td>--%>
                  
        </tr>
         <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>

    </table>
           <asp:GridView ID="grv_annexure" runat="server" SkinID="gridviewNoSort"  Width="111px" OnRowCommand="grv_annexure_RowCommand1">
           <Columns>
           <asp:TemplateField HeaderText="EDIT">
           <ItemTemplate>
                <asp:LinkButton ID="lnkEditAnnexure" runat="server"  CommandArgument='<%#Eval("id")%>'
                 CommandName="Edit1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>

           </ItemTemplate>
          
           
           </asp:TemplateField>
          </Columns>
          
          
       <Columns>
           <asp:TemplateField HeaderText="Download">
           <ItemTemplate>
                <asp:LinkButton ID="lnkdownloadAnnexure" runat="server"  CommandArgument='<%#Eval("id")%>'
                 CommandName="download" ><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>

           </ItemTemplate>
          
           
           </asp:TemplateField>
          </Columns>
        
          
          
        
          
         </asp:GridView>

            <asp:HiddenField ID="hdnAnnexure" runat="server" />
            <asp:HiddenField ID="hdnAnnexureEdit" runat="server" />
            
            
            
            
         

    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            
     <asp:Panel ID="pnlPenaltyDetails" runat="server"  Width="868px" Visible="False">
        <table style="width: 868px; height: 139px" id="TABLE1" >
            <tr>
                <td colspan="8" style="height: 21px; width: 993px;">
                <asp:Label ID="Lblmsg2" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="#C00000" Width="664px"></asp:Label></td>
            </tr>
                <tr>
        <td class="tta" colspan="7" style="height: 19px">
                <span style="font-size: 10pt"> Penalty Details</span></td>
        </tr>

            <tr>
                <td style="width: 21px; height: 28px;" class="reportTitleIncome">
                    <strong> Penalty</strong></td>
                <td style="width: 46px; height: 28px;" class="reportTitleIncome">
                    <strong>Service Tax/Charge</strong></td>
                <td style="width: 48px; height: 28px;" class="reportTitleIncome">
                  <strong> Attachment</strong></td>
            </tr>
            <tr>
                <td class="Info" style="width: 21px; height: 14px">
                    <asp:TextBox ID="txtpenalty" runat="server" SkinID="txtSkin" Width="189px" TextMode="MultiLine"></asp:TextBox></td>
                <td class="Info" style="width: 46px; height: 14px">
                    <asp:TextBox ID="txtservice" runat="server" SkinID="txtSkin" Width="135px" onkeydown="return Check(event)" Onchange ="return checkNumeric('ctl00_C1_txtservice');"></asp:TextBox></td>
                <td class="Info" style="width: 48px; height: 14px">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="236px" /></td>
            </tr>
            <tr>
                <td class="Info" rowspan="1" colspan="4" style="height: 33px">
                <center><asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" SkinID="btnSaveSkin" Text="Add" Width="95px" /></center></td>
            </tr>
        </table>
    </asp:Panel>
    
    
       <asp:Panel ID="pnlSignature" runat="server"  Width="69px" Visible="False">
    <table style="width: 867px; height: 158px;">
    <tr>
        <td colspan="11" style="height: 21px">
                <asp:Label ID="Label12" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="#C00000" Width="664px"></asp:Label></td>
    </tr>
    
    <tr>
        <td class="tta" colspan="10" style="height: 19px">
                <span style="font-size: 10pt"> Signature Details</span></td>
     </tr>
     <tr>
            <td class="reportTitleIncome" style="width: 154px; height: 34px">
                <strong>Signature</strong></td>
  
          <td style="width: 135px; height: 32px" class="Info">
                <asp:DropDownList ID="ddlsignature" runat="server" SkinID="ddlSkin" Width="160px">
                     <asp:ListItem>--Select--</asp:ListItem>
                     <asp:ListItem>Client</asp:ListItem>
                     <asp:ListItem>Company</asp:ListItem>
                       <asp:ListItem>Both</asp:ListItem>
               
                    
                </asp:DropDownList></td>
         <td class="reportTitleIncome" style="width: 154px; height: 32px">
             <strong>Upload Scan Image</strong></td>
         <td class="Info" style="width: 154px; height: 32px"><asp:FileUpload ID="FileUpload3" runat="server" Width="381px" /></td>
                </tr>
    
     <tr>
     <td class="Info" rowspan="1" colspan="6" style="height: 24px">
                <center><asp:Button ID="Btnsave12" runat="server" Text="Save" SkinID="btnSaveSkin"  Width="90px" OnClick="Btnsave12_Click" />&nbsp;
                </center></td>
     </tr>    
    <tr></tr>
    </table>
           &nbsp;
    </asp:Panel>   
            </td>
        </tr>
    </table>
              
              
              <script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>

<script language="javascript" type="text/javascript">
function validate_Agreement_Details()
{
    var ReturnValue=true;
    var ErrorMessage="";
    var Lblmsg=document.getElementById("<%=Lblmsg.ClientID%>");

    var ddlClient=document.getElementById("<%=ddlClient.ClientID%>");
    var txtDateOfAgreementFrom=document.getElementById("<%=txtDateOfAgreementFrom.ClientID%>");
    var txtDateOfAgreementValidUpto=document.getElementById("<%=txtDateOfAgreementValidUpto.ClientID%>");
    var txtContactPersonName=document.getElementById("<%=txtContactPersonName.ClientID%>");
    var ddlcompany_name=document.getElementById("<%=ddlcompany_name.ClientID%>");
    var ddlstatus=document.getElementById("<%=ddlstatus.ClientID%>");
    var ddlnoticepd=document.getElementById("<%=ddlnoticepd.ClientID%>");
    var ddllcd=document.getElementById("<%=ddllcd.ClientID%>");
     
    if(ddllcd.selectedIndex==0)
    {
        ErrorMessage=("please select Leagal Check Done to continue!");
        ReturnValue=false;
        ddllcd.focus();
    }
    
     if(ddlnoticepd.selectedIndex==0)
    {
        ErrorMessage=("please select Notice Period to continue!");
        ReturnValue=false;
        ddlnoticepd.focus();
    }
   
    if(ddlstatus.selectedIndex==0)
    {
        ErrorMessage=("please select Status to continue!");
        ReturnValue=false;
        ddlstatus.focus();
    }
    
   if(ddlcompany_name.selectedIndex==0)
    {
        ErrorMessage=("please select Company name to continue!");
        ReturnValue=false;
        ddlcompany_name.focus();
    }
    
    if(txtContactPersonName.value=='')
    {
        ErrorMessage=("please select Conatct Person Name to continue!");
        ReturnValue=false;
        txtContactPersonName.focus();
    }
    
    if(txtDateOfAgreementValidUpto.value=='')
    {
        ErrorMessage=("please select Valid Upto Date to continue!");
        ReturnValue=false;
        txtDateOfAgreementValidUpto.focus();
    }
    
    if(txtDateOfAgreementFrom.value=='')
    {
        ErrorMessage=("please select Date of Agreement to continue!");
        ReturnValue=false;
        txtDateOfAgreementFrom.focus();
    }
    
    if(ddlClient.selectedIndex==0)
    {
        ErrorMessage=("please select Client name to continue!");
        ReturnValue=false;
        ddlClient.focus();
    }

    window.scrollTo(0,0);    
    Lblmsg.innerText=ErrorMessage;
    return ReturnValue;
}  


function UpperLetter(ID)
{
ID.value=ID.value.toUpperCase();
}

</script>

<script language="javascript" type="text/javascript">
function validate_Rate_Details()
{
    var ReturnValue=true;
    var ErrorMessage="";
    var Lblmsg1=document.getElementById("<%=Lblmsg1.ClientID%>");
    
    var txtcntre=document.getElementById("<%=txtcntre.ClientID%>");
    var txtvertical=document.getElementById("<%=txtvertical.ClientID%>");
    var txtActivity=document.getElementById("<%=txtActivity.ClientID%>");
    var txtProduct=document.getElementById("<%=txtProduct.ClientID%>");
    var txtRate=document.getElementById("<%=txtRate.ClientID%>");
    var ddlicl=document.getElementById("<%=ddlicl.ClientID%>");

    if(ddlicl.selectedIndex==0)
    {
        ErrorMessage=("Please Select ICL to continue!");
        ReturnValue=false;
        ddlicl.focus();
    }
    if(txtRate.value=='')
    {
        ErrorMessage=("please Enter Rate to continue!");
        ReturnValue=false;
        txtRate.focus();
    }
    if(txtProduct.value=='')
    {
        ErrorMessage=("please Enter Product to continue!");
        ReturnValue=false;
        txtProduct.focus();
    }
    if(txtActivity.value=='')
    {
        ErrorMessage=("please Enter Activity to continue!");
        ReturnValue=false;
        txtActivity.focus();
    }
    if(txtvertical.value=='')
    {
        ErrorMessage=("please Enter Vertical to continue!");
        ReturnValue=false;
        txtvertical.focus();
    }
    if(txtcntre.value=='')
    {
        ErrorMessage=("please Enter Centre to continue!");
        ReturnValue=false;
        txtcntre.focus();
    }
   
    window.scrollTo(0,0);    
    Lblmsg1.innerText=ErrorMessage;
    return ReturnValue;
}

</script>



<script language="javascript" type="text/javascript">
function validate_annexure_Details()
{
    var ReturnValue=true;
    var ErrorMessage="";
    var Lblmsg3=document.getElementById("<%=Lblmsg3.ClientID%>");
    
    var ddlclientAnnexure=document.getElementById("<%=ddlclientAnnexure.ClientID%>");
    var txtcentre_annexure=document.getElementById("<%=txtcentre_annexure.ClientID%>");
    var txtvertical_annexure=document.getElementById("<%=txtvertical_annexure.ClientID%>");
    var txtactivity_annexure=document.getElementById("<%=txtactivity_annexure.ClientID%>");
    var txtproduct_annexure=document.getElementById("<%=txtproduct_annexure.ClientID%>");
    var txtrate_annexure=document.getElementById("<%=txtrate_annexure.ClientID%>");
    var ddlicl_annexure=document.getElementById("<%=ddlicl_annexure.ClientID%>");

    
 
 
 
 
 
 
 
     if(ddlicl_annexure.selectedIndex==0)
    {
        ErrorMessage=("Please Select ICL to continue!");
        ReturnValue=false;
        ddlicl_annexure.focus();
    }
    if(txtrate_annexure.value=='')
    {
        ErrorMessage=("please Enter Rate to continue!");
        ReturnValue=false;
        txtrate_annexure.focus();
    }
    if(txtproduct_annexure.value=='')
    {
        ErrorMessage=("please Enter Product to continue!");
        ReturnValue=false;
        txtproduct_annexure.focus();
    }
    if(txtactivity_annexure.value=='')
    {
        ErrorMessage=("please Enter Activity to continue!");
        ReturnValue=false;
        txtactivity_annexure.focus();
    }
    if(txtvertical_annexure.value=='')
    {
        ErrorMessage=("please Enter Vertical to continue!");
        ReturnValue=false;
        txtvertical_annexure.focus();
    }
    if(txtcentre_annexure.value=='')
    {
        ErrorMessage=("please Enter Centre to continue!");
        ReturnValue=false;
        txtcentre_annexure.focus();
    }
    if(ddlclientAnnexure.selectedIndex==0)
    {
        ErrorMessage=("please select Client name to continue!");
        ReturnValue=false;
        ddlclientAnnexure.focus();
    }
    
    window.scrollTo(0,0);    
    Lblmsg3.innerText=ErrorMessage;
    return ReturnValue;
    
    }
  </script>
    
</asp:Content>

