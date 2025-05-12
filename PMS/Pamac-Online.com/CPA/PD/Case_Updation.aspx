<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Case_Updation.aspx.cs" Inherits="CPA_PD_Case_Updation" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>

<script language="javascript" type="text/javascript">
function Validate()
{
    var ErrorMsg = "";
    var ReturnValue = true;
    var lblMsg = document.getElementById("<%=lblMsg.ClientID%>");
    var ddlclustername = document.getElementById("<%=ddlclustername.ClientID%>");
    var ddlcenter = document.getElementById("<%=ddlcenter.ClientID%>");
  
    if(txtCaseReceivedTime.value == '')
    {
        ErrorMsg = "Please Select Case-Received Time.";
        ReturnValue = false;
        txtCaseReceivedTime.focus();
    }    
    if(txtCaseReceivedDate.value == '')
    {
        ErrorMsg = "Please Select Case-Received Date.";
        ReturnValue = false;
        txtCaseReceivedDate.focus();
    }    
 
    if(isNaN(txtAmount.value))
    {
        ErrorMsg = "Please Enter Valid Amount.";
        ReturnValue = false;
        txtAmount.focus();
    }
    
    if(ddlLeadType.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Lead Type.";
        ReturnValue = false;
        ddlLeadType.focus();
    }
    if(txtInitiationDate.value == '')
    {
        ErrorMsg = "Please Select Initiation Date.";
        ReturnValue = false;
        txtInitiationDate.focus();
    }    
    
    if(isNaN(txtContactNo.value))
    {
        ErrorMsg = "Enter Valid Contact No.";
        ReturnValue = false;
        txtContactNo.focus(); 
    }
    if((txtPincode.value == '') || isNaN(txtPincode.value) || (txtPincode.value.length !=6))
    {
        ErrorMsg = "Please Enter Valid 6 digit Pincode.";
        ReturnValue = false;
        txtPincode.focus();
    }
    if(ddlverificationtype.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Verification Type.";
        ReturnValue = false;
        ddlverificationtype.focus();
    }
    if(ddlcenter.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Location.";
        ReturnValue = false;
        ddlcenter.focus();
    }
    if(ddlclustername.selectedIndex == 0)
    {
        ErrorMsg = "Please Select Cluster Name.";
        ReturnValue = false;
        ddlclustername.focus();
    }
        
    window.scrollTo(0,0);
    lblMsg.innerText = ErrorMsg;
    return ReturnValue;
}
</script>


<asp:Panel ID="pnlCaseEntry" runat="server" Width="800px" Height="351px">
    <table style="width: 800px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red" Width="880px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tta" style="height: 30px">
                <span style="font-size: 10pt">CASE UPDATION</span>
            </td>
        </tr>
 <tr>
            <td class="reportTitleIncome" style="width: 283px; height: 16px">
                <strong>Cluster Name</strong></td>        
            <td style="width: 105px" class="Info" colspan="3">
                <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="120px">
                </asp:DropDownList>                
            </td>
        </tr>
        <tr>
            <td style="width: 283px; height: 22px;" class="reportTitleIncome">
                <strong>Location</strong></td>
            <td style="height: 22px;" class="Info" colspan="3">
                <asp:DropDownList ID="ddlcenter" runat="server" SkinID="ddlSkin" Width="166px">
                </asp:DropDownList><strong></strong></td>
        </tr>
        <tr>
            <td style="width: 283px" class="reportTitleIncome">
                <strong>File Ref No</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtfilerefno" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Customer Name</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtcustname" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px" class="reportTitleIncome">
                <strong>Company Name</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtCompname" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong>Contact Person Name</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtcontactpersonname" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px" class="reportTitleIncome">
                <strong>Contact No</strong></td>
            <td style="width: 400px" class="Info">
                <asp:TextBox ID="txtcontactno" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px" class="reportTitleIncome">
                <strong> Address</strong></td>
            <td style="width: 125px" class="Info">
                <asp:TextBox ID="txtAddress" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 283px; height: 34px;" class="reportTitleIncome">
                <strong>Pamac location</strong></td>
            <td style="width: 400px; height: 34px;" class="Info">
                <asp:TextBox ID="txtPamaclocation" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 701px; height: 34px;" class="reportTitleIncome">
                <strong>Allocation Date</strong></td>
            <td style="width: 125px; height: 34px;" class="Info">
                <asp:TextBox ID="txtAllocationdate" runat="server" SkinID="txtSkin" Width="71px" ToolTip="[dd/mm/yyyy]"></asp:TextBox><img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAllocationdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.png" />&nbsp; [dd/mm/yyyy]</td>
        </tr>
        <tr>
            <td class="Info" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="Save" SkinID="btnsaveskin" OnClick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div style="overflow: scroll; width: 880px; height: 300px">
                   &nbsp;<asp:GridView ID="grdTele" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                        Height="100px" OnRowCommand="grdTele_RowCommand" OnRowEditing="grdTele_RowEditing"
                        OnSorting="grdTele_Sorting" SkinID="gridviewSkin">
                        <Columns>
                            <asp:TemplateField HeaderText="EDIT">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditTele" runat="server" CommandArgument='<%#Eval("Case_id")%>'
                                        CommandName="Edit"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0"/></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="case_id" HeaderText="Case ID" SortExpression="case_id" />
                            <asp:BoundField DataField="File_Ref_No" HeaderText="File_Ref_No" />
                            <asp:BoundField DataField="Customer_Name" HeaderText="Customer_Name" />
                            <asp:BoundField DataField="Company_Name" HeaderText="Company_Name" />
                            <asp:BoundField DataField="Contact_Person_Name" HeaderText="Contact_Person_Name" />
                            <asp:BoundField DataField="Contact_Number" HeaderText="Contact_Number" />
                            <asp:BoundField DataField="pamac_location" HeaderText="pamac_location" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Allocation_Date" HeaderText="Allocation_Date" />
                            <asp:BoundField DataField="cluster_id" HeaderText="cluster" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:HiddenField ID="HdnclusterID" runat="server" />    
                <asp:HiddenField ID="HdnCentreID" runat="server" />
                <asp:HiddenField ID="HdnCaseID" runat="server" />    
                <asp:HiddenField ID="HdnID" runat="server" />    
            </td>
        </tr>
    </table>

</asp:Panel>

</asp:Content>

