<%@ Page Language="C#" MasterPageFile="~/Admin/FeedBack/MasterPage.master" AutoEventWireup="true" CodeFile="Form.aspx.cs" Inherits="Admin_FeedBack_Form" Title="Untitled Page" StylesheetTheme="SkinFile"%>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
   <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>   
    <script language="JAVASCRIPT" type="text/javascript"> 

    function Validate_Search()
    {  
        
        var txtproblem= document.getElementById("<%=txtproblem.ClientID%>");     
        var txtSuggestion = document.getElementById("<%=txtSuggestion.ClientID%>");
    
        
       var Lblmsg=document.getElementById("<%=Lblmsg.ClientID%>");       
       var ErrorMessage='';
       var ReturnValue=true;
       
       
                

            if (txtSuggestion.value ==0)       
        { 
             ErrorMessage='Please Enter The Suggestion!';
             ReturnValue=false; 
             txtSuggestion.focus();
        }   
            
     
               if (txtproblem.value ==0)       
        { 
             ErrorMessage='Please Enter The Problem!';
             ReturnValue=false; 
             txtproblem.focus();
        }   
        
           
        
         window.scrollTo(0,0);    
         Lblmsg.innerText=ErrorMessage;
         return ReturnValue;
         
    }  
    
   function UpperCase(ID)
{

ID.value=ID.value.toUpperCase();

}
    
    </script>
   
   
   
   
   
   

   
    <table>
            <tr>
            <td class="tta" colspan="8">
                <strong>Software Request Form</strong></td>
               
        </tr>
        <tr>
            <td colspan="8">
                <asp:Label ID="Lblmsg" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblTicketNo" runat="server" ForeColor="Red" SkinID="lblError"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 249px" class="reportTitleIncome">
                <strong>
                Employee Code</strong></td>
            <td class="Info" colspan="3">
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" AutoPostBack="True" ReadOnly="true" OnTextChanged="txtEmpCode_TextChanged" Width="150px"></asp:TextBox></td>
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
            <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                <strong>
                First Name</strong></td>
            <td style="width: 234px; height: 22px;" class="Info">
                <asp:TextBox ID="txtfirstname" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td style="width: 346px; height: 22px;" class="reportTitleIncome">
                <strong>
                Last Name</strong></td>
            <td style="width: 250px; height: 22px;" class="Info">
                <asp:TextBox ID="txtLastName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
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
            <td class="reportTitleIncome" style="width: 249px; height: 22px;">
                <strong>
                Centre Name</strong></td>
            <td class="Info" style="width: 234px; height: 22px;">
                <asp:DropDownList ID="ddlcentre" runat="server"
                    SkinID="ddlSkin" Width="155px">
                </asp:DropDownList></td>
            <td style="width: 346px; height: 22px;" class="reportTitleIncome">
                <strong>
                Subcentre Name</strong></td>
            <td style="width: 250px; height: 22px;" class="Info">
                <asp:DropDownList ID="ddlsubcentre" runat="server" SkinID="ddlSkin" Width="155px">
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
            <td class="reportTitleIncome" style="width: 249px">
                <strong>Vertical</strong></td>
            <td class="Info" style="width: 234px">
                <asp:DropDownList ID="ddlvertical" runat="server" SkinID="ddlSkin" TabIndex="6" ValidationGroup="VLDGRP"
                    Width="155px" AutoPostBack="True" OnSelectedIndexChanged="ddlvertical_SelectedIndexChanged">
                    
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem>PCPV</asp:ListItem>
                    <asp:ListItem>PCPA</asp:ListItem>
                    <asp:ListItem>PTPU</asp:ListItem>
                    <asp:ListItem>PDCR</asp:ListItem>
                    <asp:ListItem>PFRC</asp:ListItem>
                    <asp:ListItem>PCRU</asp:ListItem>
                    <asp:ListItem>ADMIN</asp:ListItem>
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>ACCOUNT</asp:ListItem>
                    <asp:ListItem>HSU</asp:ListItem>
                    <asp:ListItem>SSU</asp:ListItem>
                    
                </asp:DropDownList></td>
            <td style="width: 346px" class="reportTitleIncome">
                <strong>
                Vertical Head / DCH</strong></td>
            <td style="width: 250px" class="Info">
                <asp:DropDownList ID="ddlverticalHead" runat="server" SkinID="ddlSkin" Width="155px">
                    <asp:ListItem>Murugan Odiyar</asp:ListItem>
                </asp:DropDownList></td>
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
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>Request Date</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:TextBox ID="txtdate" runat="server" SkinID="txtSkin" Width="71px" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                <img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td style="width: 346px; height: 23px" class="reportTitleIncome">
                <strong>Required Till Date</strong></td>
            <td style="width: 250px; height: 23px" class="Info">
                <asp:TextBox ID="TextBox1" runat="server" SkinID="txtSkin" Width="71px" ToolTip="[dd/mm/yyyy]"></asp:TextBox>
                <img
                    alt="Calendar" onclick="popUpCalendar(this, document.all.<%=TextBox1.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />
                [dd/mm/yyyy]</td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>Application</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:DropDownList ID="ddlapplication" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>PMS</asp:ListItem>
                    <asp:ListItem>CALCULUS</asp:ListItem>
                    <asp:ListItem>TEAMSPACE</asp:ListItem>
                    <asp:ListItem>RSP</asp:ListItem>
                    <asp:ListItem>PAMAC WEBSITE</asp:ListItem>
                    <asp:ListItem>PAMCAL WEBSITE</asp:ListItem>
                    <asp:ListItem>BDDOMESTIC</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 346px; height: 23px">
                <strong>
                Priority</strong></td>
            <td class="Info" style="width: 250px; height: 23px">
                <asp:DropDownList ID="ddlpriority" runat="server" SkinID="ddlSkin" Width="160px">
                    <asp:ListItem Value="3">Low</asp:ListItem>
                    <asp:ListItem Value="2">Medium</asp:ListItem>
                    <asp:ListItem Value="1">High</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 23px">
                <strong>
                New Requirement / Enhancement / Error</strong></td>
            <td class="Info" style="width: 234px; height: 23px">
                <asp:DropDownList ID="ddlreqtype" runat="server" SkinID="ddlSkin" Width="155px" >
                    <asp:ListItem Value="1">New Requirement</asp:ListItem>
                    <asp:ListItem Value="2">Error</asp:ListItem>
                    <asp:ListItem Value="3">Enhancement</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 346px; height: 23px">
                <strong>
                Requirement Type</strong></td>
            <td class="Info" style="width: 250px; height: 23px">
                <asp:DropDownList ID="ddlrequirement" runat="server" SkinID="ddlSkin" Width="158px">
                 <asp:ListItem Value="1">Rights Assignment</asp:ListItem>
                    <asp:ListItem Value="2">Client ADD</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 21px">
                <strong>
                Implementing At</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:DropDownList ID="ddllocations" runat="server" SkinID="ddlSkin" Width="155px">
                    <asp:ListItem Value=" PANINDIA locations">PAN INDIA Locations</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 249px; height: 21px;" class="reportTitleIncome">
                <strong>
                Process Flow</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="290px" />&nbsp;</td>
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
            <td class="reportTitleIncome" style="width: 249px; height: 21px">
                <strong>
                Import / Export</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload2" runat="server" SkinID="flup" Width="290px" /></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 21px">
                <strong>
                MIS Tracker</strong></td>
            <td class="Info" colspan="3" style="height: 21px">
                <asp:FileUpload ID="FileUpload3" runat="server" SkinID="flup" Width="290px" /></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 249px; height: 21px">
                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                    <font color="#000080"><span style="font-size: 8pt; width: 430px; color: black; height: 21px">
                        <strong>
                        Technical
                Problem / Issues in the Application</strong></span></font></p>
            </td>
            <td colspan="3" style="height: 21px" class="Info">
                <asp:TextBox ID="txtproblem" runat="server" Height="44px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="400px" OnKeyup="UpperCase(this);"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 249px; height: 21px;" class="reportTitleIncome">
                <span style="font-size: 8pt; color: #000000; font-family: Tahoma; background-color: #e1e9ff;">
                    <strong>Requirement / Remark</strong></span></td>
            <td colspan="3" style="height: 21px" class="Info">
                <asp:TextBox ID="txtSuggestion" runat="server" SkinID="txtSkin" Height="44px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
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
            <td style="height: 21px;" class="Info" colspan="4" align="center">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;<asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" SkinID="btn" Text="Save"
                    Width="100px" />
                &nbsp;
                <asp:Button ID="BtnReset" runat="server" SkinID="btn" Text="Reset" Width="100px" />
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
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
            <td colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/FeedBack/EmpDetailsView.aspx">HyperLink</asp:HyperLink>
                <asp:HiddenField ID="hdnApproveto" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

