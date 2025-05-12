<%@ Page Language="C#" MasterPageFile="~/IDOC/IDOC/IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_finacialcheck.aspx.cs" Inherits="IDOC_IDOC_finacialcheck" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">


<script language="javascript" type="text/jscript">
function ValidateTextLength(DisplayName, ControlName, xLength)
{
    if (ControlName.value.length > parseInt(xLength))
    {
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
         ControlName.focus();   
    }      
}
function ClientValidate(source, arguments)
       {
          //alert(arguments.Value);Quadra InfoTech
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
      
        function NumberOnly(e) {


            var keyASCII = window.event.keyCode;


            if (keyASCII < 45 || keyASCII > 58 || keyASCII ==47) 
            {
                window.event.keyCode = 0;
                alert("Please Enter Only Decimal No eg.(12.00)");
            }
           
        }
        
       
     function ValidateDropDown() 
        {
        
        //txtAppName
        var txtAppName ="<%=txtAppName.ClientID%>";
         if (document.getElementById(txtAppName).value == "") 
        {
            alert("Enter Applicant Name . ");
            document.getElementById("<%=txtAppName.ClientID%>").focus();            
            return false;
        }
         //txtCPARefNo
         var txtCPARefNo ="<%=txtCPARefNo.ClientID%>";
         if (document.getElementById(txtCPARefNo).value == "") 
        {
            alert("Enter CPA Reference No.");
            document.getElementById("<%=txtCPARefNo.ClientID%>").focus();            
            return false;
        }
        
        //txtInitiationDate
         var txtInitiationDate ="<%=txtInitiationDate.ClientID %>";
         if (document.getElementById(txtInitiationDate).value == "") 
        {
            alert("Please Select InitiationDate.");
            document.getElementById("<%=txtInitiationDate.ClientID%>").focus();            
            return false;
        }
        
        //txtbankrefno
         var txtbankrefno ="<%=txtbankrefno.ClientID%>";
         if (document.getElementById(txtbankrefno).value == "") 
        {
            alert("Enter Bank Reference No.");
            document.getElementById("<%=txtbankrefno.ClientID%>").focus();            
            return false;
        }
        
         //txtclientname
         var txtclientname ="<%=txtclientname.ClientID%>";
         if (document.getElementById(txtclientname).value == "") 
        {
            alert("Enter Client Name.");
            document.getElementById("<%=txtclientname.ClientID%>").focus();            
            return false;
        }
        
         //txtprodname
         var txtprodname ="<%=txtprodname.ClientID%>";
         if (document.getElementById(txtprodname).value == "") 
        {
            alert("Enter Product Name.");
            document.getElementById("<%=txtprodname.ClientID%>").focus();            
            return false;
        }
        //txtpanno
        var txtpanno ="<%=txtpanno.ClientID%>";
         if (document.getElementById(txtpanno).value == "") 
        {
            alert("Enter Pan Number.");
            document.getElementById("<%=txtpanno.ClientID%>").focus();            
            return false;
        }
     
      //txtwhether
        var txtwhether = "<%=txtwhether.ClientID %>";
        if (document.getElementById(txtwhether).selectedIndex == 0) 
        {
            alert("Please Select Whether OK to send for field verification");
            document.getElementById("<%=txtwhether.ClientID%>").focus(); 
            return false;
        }
      
      //ddverification
        var ddverification = "<%=ddverification.ClientID %>";
        if (document.getElementById(ddverification).selectedIndex == 0) 
        {
            alert("Please Select Verification Done In");
            document.getElementById("<%=ddverification.ClientID%>").focus(); 
            return false;
        }
        
        
        //ddstatus
        var ddstatus = "<%=ddstatus.ClientID%>";
        if (document.getElementById(ddstatus).selectedIndex == 0) 
        {
            alert("Please Select Final Status");
            document.getElementById("<%=ddstatus.ClientID%>").focus(); 
            return false;
        }
         
         //txtremark
         
         var remark = "<%=txtremark.ClientID%>";
        if (document.getElementById(remark).value == "") 
        {
            alert("Please Enter Reamrk");
            document.getElementById("<%=txtremark.ClientID%>").focus(); 
            return false;
        }
        
        //txtassyear
         var assyear ="<%=txtassyear.ClientID%>";
         if (document.getElementById(assyear).value == "") 
        {
            alert("Please Enter Asst year.");
            document.getElementById("<%=txtassyear.ClientID%>").focus();            
            return false;
        }
        
       //ddlSupervisorName
        var cmbID = "<%=ddlSupervisorName.ClientID%>";
        if (document.getElementById(cmbID).selectedIndex == 0) 
        {
            alert("Please select Supervisor Name");
            document.getElementById("<%=ddlSupervisorName.ClientID%>").focus(); 
            return false;
        }
        
         //txtAreapincode
      //   var txtAreapincode ="<%=txtAreapincode.ClientID%>";
        // if (document.getElementById(txtAreapincode).value == "") 
       // {
        //    alert("Enter Area pincode Number and Click Search Pincode Button .");
          //  document.getElementById("<%=txtAreapincode.ClientID%>").focus();            
          //  return false;
   //     }
   
   
        
        var ddlCityLimit = "<%=ddlCityLimit.ClientID%>";
       if (document.getElementById(ddlCityLimit).selectedIndex == 0) 
        {
          alert("Please select City Limit");
            document.getElementById("<%=ddlCityLimit.ClientID%>").focus(); 
          return false;
        }
        
        
        //txtVerificationDate
         var txtVerificationDate ="<%=txtVerificationDate.ClientID %>";
         if (document.getElementById(txtVerificationDate).value == "") 
        {
            alert("Please Select Verification Date.");
            document.getElementById("<%=txtVerificationDate.ClientID%>").focus();            
            return false;
        }
           
}

   
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset ><legend class="FormHeading">FINANCIAL CHECK - VERIFIACTION REPORT</legend>
<table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblMain" style="background-color:#E7F6FF">
    <tr>
        <td ><asp:Label ID="lblMsg" runat="server" SkinID="lblSkin"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblBankStatement">
    <tr>
    <td style="width:18%; height: 26px;"><asp:Label SkinID="lblSkin" ID="lblAppName" runat="server">Applicant's Name(Mr./Ms./Mrs.)</asp:Label></td>        
        <td style="width:2%; height: 26px;">:</td>
        
    <td colspan="4" style="height: 26px"><asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="80%" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAppName"
            Display="None" ErrorMessage="Enter The Applicant's Name " SetFocusOnError="True"
            ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>    
    </tr>
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="bllRefNo" runat="server">CPA Reference No</asp:Label></td>
        <td>
            :</td>
    <td style="width: 256px"><asp:TextBox ID="txtCPARefNo" SkinID="txtSkin" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCPARefNo"
            Display="None" ErrorMessage="Enter  CPA Reference Number" SetFocusOnError="True"
            ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>    
    <td style="width: 117px"><asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server">Date of Initiation</asp:Label></td>
        <td style="width: 23px">
            :</td>
    <td><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtInitiationDate"
            Display="None" ErrorMessage="Please Select Date" SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
  
    </tr>
        <tr>
            <td style="height: 40px">
                <asp:Label ID="lblbankrefno" runat="server" SkinID="lblSkin">Bank Reference Number</asp:Label></td>
            <td style="height: 40px">
                :</td>
            <td style="width: 256px; height: 40px;">
                <asp:TextBox ID="txtbankrefno" runat="server" SkinID="txtSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbankrefno"
                    Display="None" ErrorMessage="Enter Bank Reference Number" SetFocusOnError="True"
                    ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
            <td style="width: 117px; height: 40px;">
                <asp:Label ID="lblcleintname" runat="server" SkinID="lblSkin">Client Name</asp:Label></td>
            <td style="width: 23px; height: 40px;">
                :</td>
            <td style="height: 40px">
                <asp:TextBox ID="txtclientname" runat="server" SkinID="txtSkin" Width="282px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtclientname"
                    Display="None" ErrorMessage="Enter Client Name" SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 40px">
                <asp:Label ID="lblprodname" runat="server" SkinID="lblSkin">Product Name</asp:Label></td>
            <td style="height: 40px">
                :</td>
            <td style="width: 256px; height: 40px;">
                <asp:TextBox ID="txtprodname" runat="server" SkinID="txtSkin" Width="205px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtprodname"
                    Display="None" ErrorMessage="Please Enter Product Name ." SetFocusOnError="True"
                    ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
            <td style="width: 117px; height: 40px;">
            </td>
            <td style="width: 23px; height: 40px;">
            </td>
            <td style="height: 40px">
            </td>
        </tr>
    </table>
    </td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblBankStatementDetail">
    <tr>
    <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" colspan="6">
            <asp:Label SkinID="lblSkin" ID="lblBankStatDtlHead" runat="server" ForeColor="blue" Text="Field Check" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="width:25%"><asp:Label SkinID="lblSkin" ID="lbltotsale" runat="server" >Total Sales as per Income Tax Record</asp:Label></td>
        <td style="width: 2%">:
        </td>
    <td colspan="4"> Rs. 
        <asp:TextBox SkinID="txtSkin" ID="txttotsale" runat="server" Width="21%" onkeypress = "NumberOnly();" >0</asp:TextBox>
        </td>
    </tr>
    <tr>
    <td><asp:Label SkinID="lblSkin" ID="lbltotcap" runat="server">Total Capital  as per income Tax Record </asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td colspan="4">
        Rs.
        <asp:TextBox ID="txttotcap" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
        </td>
    </tr>
    <tr>
    <td style="height: 26px"><asp:Label SkinID="lblSkin" ID="lblfixass" runat="server" >Total Fixed asst  as per income Tax Record </asp:Label></td>
         <td style="width: 2%; height: 26px;">:
        </td>
    <td colspan="4" style="height: 26px">
        Rs.
        <asp:TextBox ID="txtfixass" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
        </td>
    </tr>
    <tr>
    <td style="width:20%"><asp:Label SkinID="lblSkin" ID="llbldebtor" runat="server">Total Debtor  Amount as per income Tax Record </asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td colspan="4">
        Rs.
        <asp:TextBox ID="txtdebt" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
        </td>
    </tr>
    <tr>
    <td style="height: 17px"><asp:Label SkinID="lblSkin" ID="lblcreditor" runat="server">Total creditor   Amount as per income Tax Record </asp:Label></td>
        <td style="width: 2%; height: 17px;">:
        </td>
    <td style="height: 17px" colspan="4">
        Rs.
        <asp:TextBox ID="txtcreditor" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
        </td>
    </tr>
    
    <tr>
    <td style="height: 16px">
        <asp:Label ID="lblclosing" runat="server" SkinID="lblSkin">Total closing stock  Amount as per income Tax Record </asp:Label></td>
         <td style="width: 2%; height: 16px;">
             :</td>
    <td style="height: 16px" colspan="4">
        Rs.
        <asp:TextBox ID="txtclos" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
        </td>    
    </tr>    
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lbldep" runat="server" SkinID="lblSkin">Total Depreciation Amount as per income Tax Record</asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                Rs.
                <asp:TextBox ID="txtdep" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lbltotnet" runat="server" SkinID="lblSkin">Total Net Profit Amount as per income Tax Record </asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                Rs.
                <asp:TextBox ID="txtnetprof" runat="server" SkinID="txtSkin" Width="21%" onkeypress = "NumberOnly();">0</asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblpanno" runat="server" SkinID="lblSkin">Pan Number</asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:TextBox ID="txtpanno" runat="server" SkinID="txtSkin"
                    Width="21%" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtpanno"
                    Display="None" ErrorMessage="Enter Pan Number" SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblwhether" runat="server" SkinID="lblSkin">Whether OK to send for field verification</asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:DropDownList ID="txtwhether" runat="server">
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtwhether"
                    Display="None" ErrorMessage="Please Select Whether OK to send for field verification"
                    InitialValue="0" SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblverifiactiondone" runat="server" SkinID="lblSkin">Verification done In</asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:DropDownList ID="ddverification" runat="server">
                 <asp:ListItem Value="0">--select--</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddverification"
                    Display="None" ErrorMessage="Please Select Verification Done In" InitialValue="0"
                    ValidationGroup="grValidateDate" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 16px">
    <asp:Label SkinID="lblSkin" ID="lblfinalststus" runat="server">Final Status </asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:DropDownList ID="ddstatus" runat="server">
                 <asp:ListItem Value="0">--select--</asp:ListItem>
                    <asp:ListItem>Positive</asp:ListItem>
                    <asp:ListItem>Negative</asp:ListItem>
                    <asp:ListItem> Refer to Bank</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddstatus"
                    Display="None" ErrorMessage="Please Select Final Status" ValidationGroup="grValidateDate" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblremark" runat="server" SkinID="lblSkin" Width="40px">Remark</asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:TextBox ID="txtremark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="27%"></asp:TextBox>
               </td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:Label ID="lblassyear" runat="server" SkinID="lblSkin" Width="65px">Asst Year </asp:Label></td>
            <td style="width: 2%; height: 16px">
                :</td>
            <td colspan="4" style="height: 16px">
                <asp:TextBox ID="txtassyear" runat="server" Width="165px"></asp:TextBox></td>
        </tr>
    </table>    
    </td>
    </tr>
    <tr>
    <td>
    <table border="0" cellpadding="1" cellspacing="0" width="100%" id="tblFooter" >
    <tr>
    <td style="width:10%"><asp:Label SkinID="lblSkin" ID="lblFEName" runat="server">Name of FE</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td style="width:26%"> 
        <asp:TextBox SkinID="txtSkin"  ID="txtFEName" runat="server" ReadOnly="true" Width="243px"></asp:TextBox>        
    </td>
    <td style="width:10%"><asp:Label SkinID="lblSkin" ID="lblVerificationDate" runat="server">Date of Verification</asp:Label></td>
         <td style="width: 2%">:
        </td>
    <td style="width:25%">
      
        <asp:TextBox SkinID="txtSkin"  ID="txtVerificationDate" runat="server" MaxLength="10"></asp:TextBox> 
        <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtVerificationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
        </td>
        <td class="TDWidth" style="width: 7%">
            &nbsp;</td>
         <td style="width: 2%">
             &nbsp;</td>
                <td>                     &nbsp;
                </td>
    </tr>
        <tr>
            <td style="width: 10%; height: 33px;">
                <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Width="86px">Supervisor Name</asp:Label></td>
            <td style="width: 2%; height: 33px;">
                :</td>
            <td style="width: 26%; height: 33px;">
                <asp:DropDownList ID="ddlSupervisorName" runat="server"  AutoPostBack="true"
                    SkinID="ddlSkin" OnSelectedIndexChanged="ddlSupervisorName_SelectedIndexChanged" Width="102px">
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="cvSupervisorName" runat="server" ControlToValidate="ddlSupervisorName"
                    Display="None" ErrorMessage="Please Select Supervisor Name." InitialValue="0"
                    SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
            <td style="width: 10%; height: 33px;">
        
        
                    <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server" Text="Case Status"></asp:Label></td>
            <td style="width: 2%; height: 33px;">
                :</td>
            <td style="width: 25%; height: 33px;">
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server" DataSourceID="sdsCaseStatus"
                          DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID" >
                     </asp:DropDownList><asp:SqlDataSource ID="sdsCaseStatus" runat="server" 
                          ProviderName="System.Data.OleDb" 
                          SelectCommand="SELECT [CASE_STATUS_ID],[STATUS_NAME], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY CASE_STATUS_ID">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
                     </asp:SqlDataSource>
            </td>
            <td class="TDWidth" style="width: 7%; height: 33px;">
            </td>
            <td style="width: 2%; height: 33px;">
            </td>
            <td style="height: 33px">
            </td>
        </tr>
        <tr>
            <td style="width: 10%; height: 86px;">
                <asp:Label ID="labAreaname" runat="server" SkinID="lblSkin" Width="86px">Area Name</asp:Label></td>
            <td style="width: 2%; height: 86px;">
            </td>
            <td style="width: 26%; height: 86px;">
                <asp:DropDownList ID="ddlAreaname" runat="server"  AutoPostBack="true"
                    SkinID="ddlSkin" OnSelectedIndexChanged="ddlAreaname_SelectedIndexChanged">  
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlAreaname"
                    Display="None" ErrorMessage="Please Select Area Name" InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="grValidateDate"></asp:RequiredFieldValidator>
                      <asp:TextBox SkinID="txtSkin"  ID="txtAreapincode" runat="server" MaxLength="8" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAreapincode"
                    Display="None" ErrorMessage="Please Enter Pincode Number and Click Search Pincode Button"
                    SetFocusOnError="True" ValidationGroup="grValidateDate"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnPincode" runat="server"  Text="Search Pincode" OnClick="btnPincode_Click" />
                                     
               </td>
            <td style="width: 10%; height: 86px;">
            <%--<td class="TDWidth">--%>
        <asp:Label SkinID="lblSkin" ID="lblCityLimit" runat="server"  Text="City Limit"></asp:Label>
    </td><td style="width:2%; height: 86px;">:</td>
    <td style="height: 86px">                     
         <asp:DropDownList SkinID="ddlSkin"  ID="ddlCityLimit" runat="server" AutoPostBack="false">
                        <asp:ListItem Value="0">--select--</asp:ListItem>
                        <asp:ListItem>ICL</asp:ListItem>
                        <asp:ListItem>OCL</asp:ListItem>
                      <%--  <asp:ListItem>Beyound OCL</asp:ListItem>--%>
                     </asp:DropDownList>
    </td>
            <td style="width: 2%; height: 86px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCityLimit"
                    Display="None" ErrorMessage="Please Select City Limit" InitialValue="0" SetFocusOnError="True"
                    ValidationGroup="grValidateDate"></asp:RequiredFieldValidator></td>
            <td style="width: 25%; height: 86px;">
            </td>
            <td class="TDWidth" style="width: 7%; height: 86px;">
            </td>
            <td style="width: 2%; height: 86px;">
            </td>
            <td style="height: 86px">
            </td>
        <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtVerificationDate"
            Display="None" ErrorMessage="Please enter valid date format for verification date."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grValidateDate"></asp:RegularExpressionValidator><asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" />   
    <tr>
    <td align="center">
    <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" ValidationGroup="grValidateDate" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="javascript:return ValidateDropDown();"   />        
    <%--OnClientClick="javascript:return ValidateDropDown();"--%>
    
    <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
    </td>
    </tr>
    <tr><td>&nbsp;<asp:HiddenField ID="hdnTransStart" runat="server" />
        <asp:HiddenField ID="hdnSupID" runat="server" />
      
    </td></tr>
            
            
            </td>
        </tr>
    </table>
        </td>    
    </tr>
</table>


</asp:Content>

