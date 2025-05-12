<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Admin_FeedBack_View" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    
      <script language="JAVASCRIPT" type="text/javascript"> 

    function Validate_Search()
    {  
        var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>");
        var txtToDate= document.getElementById("<%=txtToDate.ClientID%>");     
        var ddlcentre = document.getElementById("<%=ddlcentre.ClientID%>");
        var ddlsubcentre= document.getElementById("<%=ddlsubcentre.ClientID%>");
        
       var lblmsg=document.getElementById("<%=lblmsg.ClientID%>");       
       var ErrorMessage='';
       var ReturnValue=true;
       
       
                
            if (txtToDate.value =='')       
        { 
             ErrorMessage='Please Enter the To Date!';
             ReturnValue=false; 
             txtToDate.focus();
        }  
                
            if (txtFromDate.value ==0)       
        { 
             ErrorMessage='Please Enter The From Date!';
             ReturnValue=false; 
             txtFromDate.focus();
        }   
            
     
               if (ddlsubcentre.value ==0)       
        { 
             ErrorMessage='Please Select The SubCentre!';
             ReturnValue=false; 
             ddlsubcentre.focus();
        }   
        
               if (ddlcentre.value =='A')       
        { 
             ErrorMessage='Please Select The Centre!';
             ReturnValue=false; 
             ddlcentre.focus();
        }   
        
              window.scrollTo(0,0);    
         lblmsg.innerText=ErrorMessage;
         return ReturnValue;
         
    }  
    </script>
    
    
    <asp:Panel ID="Panel1" runat="server">
   
   
   
    <table style="width: 748px">
        <tr>
            <td colspan="6" class="tta">
                Feedback Update</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr style="color: #000000; font-family: Tahoma">
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                Centre Name</td>
            <td style="width: 100px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="150px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                Subcentre Name</td>
            <td style="width: 100px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlsubcentre" runat="server"
                    SkinID="ddlSkin" Width="150px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                &nbsp;&nbsp;
                </td>
            <td style="width: 100px; height: 20px;">
                <asp:HiddenField ID="HDNUPDATE" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 19px">
                From Date</td>
            <td class="Info" style="width: 100px; height: 19px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                    Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 19px">
                To Date</td>
            <td class="Info" style="width: 100px; height: 19px">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" ValidationGroup="vldGrp"
                    Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td style="width: 100px; height: 19px" class="reportTitleIncome">
                &nbsp;
                </td>
            <td style="width: 100px; height: 19px">
                <asp:HiddenField ID="HdnUID" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 21px;" colspan="6">
                <asp:Button ID="Btnsearch" runat="server" Height="23px" OnClick="Button1_Click" SkinID="btn"
                    Text="Search" Width="121px" />&nbsp;
                <asp:Button ID="BtnReset" runat="server" Height="23px" OnClick="BtnReset_Click" SkinID="btn"
                    Text="Reset" Width="121px" /></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="pnlGrd" runat="server" Height="162px" ScrollBars="Both" Width="900px">
                    <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort" Width="650px" OnRowCommand="GrdView_RowCommand">
                        <Columns>
                           <asp:TemplateField HeaderText="EDIT">
                                <ItemTemplate>
                             
                                       <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("Serial_no") %>'
                                CommandName="Edit1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                       
                                   
                                       
                                </ItemTemplate>
                            </asp:TemplateField>
                                
                                
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Width="907px">
        <table style="width: 904px">
            <tr>
                <td class="tta" colspan="6" style="height: 15px">
                    FeedBack Action Updation</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px" class="reportTitleIncome">
                    Employee Code</td>
                <td style="width: 77px" class="Info">
                    <asp:Label ID="lblEmpCode" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" class="reportTitleIncome">
                    First Name</td>
                <td style="width: 77px" class="Info">
                    <asp:Label ID="lblFrstName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px;" class="reportTitleIncome">
                    Last Name</td>
                <td style="width: 77px; height: 21px;" class="Info">
                    <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" class="reportTitleIncome">
                    Centre Name</td>
                <td style="width: 77px" class="Info">
                    <asp:Label ID="LblCentreName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" class="reportTitleIncome">
                    Subcentre Name</td>
                <td style="width: 77px" class="Info">
                    <asp:Label ID="lblSubcentreName" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" class="reportTitleIncome">
                    Feedback Date</td>
                <td style="width: 77px" class="Info">
                    <asp:Label ID="LblFeedbackdate" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 18px;" class="reportTitleIncome">
                    ApplicationUsed</td>
                <td style="width: 77px; height: 18px;" class="Info">
                    <asp:Label ID="lblApp" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 18px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px;" class="reportTitleIncome">
                    Rating this Tool</td>
                <td style="width: 77px; height: 19px;" class="Info">
                    <asp:Label ID="lblRating" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 19px;">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 21px">
                    Technical Problem</td>
                <td class="Info" style="width: 77px; height: 21px">
                    <asp:Label ID="lblProblem" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 21px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 21px">
                    SSU Team Support</td>
                <td class="Info" style="width: 77px; height: 21px">
                    <asp:Label ID="lblSSUSupport" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 21px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 21px">
                    Suggestion / Changes Required</td>
                <td class="Info" style="width: 77px; height: 21px">
                    <asp:Label ID="lblsuggestion" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 89px; height: 21px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 7px">
                    Action Date</td>
                <td class="Info" style="width: 77px;">
                    <asp:TextBox ID="txtActionDate" runat="server" Height="16px" Width="85px" SkinID="txtSkin"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtActionDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
                <td style="width: 89px; height: 7px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 100px; height: 21px">
                    Action Taken</td>
                <td class="Info" style="width: 77px; height: 21px">
                    <asp:TextBox ID="txtAction" runat="server" Height="51px" TextMode="MultiLine" Width="273px" SkinID="txtSkin"></asp:TextBox></td>
                <td style="width: 89px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px">
                    &nbsp;<asp:Button ID="BtnActionSave"
                        runat="server" Text="Save " SkinID="btn" Width="100px" OnClick="BtnActionSave_Click" />
                    <asp:Button ID="BtnReset12" runat="server" Text="Reset" SkinID="btn" Width="100px" /></td>
            </tr>
        </table>
    </asp:Panel>


   
   <script language="javascript" type="text/javascript" src="../../popcalendar.js">
</script>
</asp:Content>

