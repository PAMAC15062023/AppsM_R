<%@ Page Language="C#" MasterPageFile="~/CPA/PD/MasterPage.master" AutoEventWireup="true" CodeFile="Case_Status_View.aspx.cs" Inherits="CPA_PD_Case_Status_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
<script language="javascript" type="text/javascript">
function winOpen(strURL)
{
    window.open(strURL);
}
function TABLE1_onclick() 
{
}
</script>
    
<table style="width:900px;">    
<tr>
<td style="width: 900px;">
    <asp:Panel ID="pnlCategory" runat="server" Width="900px">  <%--Height="132px" --%>
    <table style="width: 690px" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td class="tta" colspan="4" style="width: 80%;">
                <span style="font-size: 10pt">CASE STATUS VIEW</span></td>
        </tr>
        <tr>
            <td colspan="4" style="width: 80%; height: 21px;">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Width="685px" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
                    <td style="width: 129px; height: 11px;" class="reportTitleIncome">
                        <strong>Case ID</strong></td>
                    <td style="width: 100px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtCaseID" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 117px; height: 11px;" class="reportTitleIncome">
                        <strong>File Ref No</strong></td>
                    <td style="width: 105px; height: 11px;" class="Info">
                        <asp:TextBox ID="txtfilerefno" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Customer Name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtCustomerName" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Company Name</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtCompanynae" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Contact person name</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtcontactperson" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Contact Number</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtcontactno" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                
                   
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Pamac Location</strong></td>
                    <td style="width: 100px; height: 20px;" class="Info">
                        <asp:TextBox ID="txtpamacloc" runat="server" SkinID="txtSkin" Width="150px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 114px; height: 1px;" class="reportTitleIncome">
                        <strong>Address</strong></td>
                    <td style="width: 100px; height: 1px;" class="Info">
                        <asp:TextBox ID="txtaddress" runat="server" SkinID="txtSkin" Width="150px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
                </tr>
                
                  <tr>
                    <td style="width: 129px; height: 20px;" class="reportTitleIncome">
                        <strong>Allocation Date</strong></td>

                      <td class="Info" colspan="2" style="height: 20px">
                        <strong>
                            <asp:TextBox ID="txtallocationdate" runat="server" SkinID="txtSkin" Width="70px" ReadOnly="True"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtallocationdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="../../Images/SmallCalendar.png" />[dd/mm/yyyy]</strong></td>
                
               </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 142px">
                <strong></strong></td>
            <td class="Info" style="width: 200px">
                </td>
            <td class="Info" colspan="2" >
                   <center><asp:Button ID="btnSearch" runat="server" Text="Search" Width="102px" SkinID="btnSearchSkin" OnClick="btnSearch_Click" /></center> 
            </td>
        </tr>
    <tr>
       <td colspan="4" >    <%--style="height: 107px"--%>
            <div style="overflow: scroll; width: 900px; height: 500px">
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
                <asp:HiddenField ID="hdnTeleCaseID" runat="server" />
                <asp:HiddenField ID="hdnID" runat="server" />
                <asp:HiddenField ID="HdnCluster" runat="server" />
                <asp:HiddenField ID="Hdnmaster" runat="server" />
                <asp:HiddenField ID="HdnVeri" runat="server" />
            </div>
        </td>
    </tr>
    </table>
    </asp:Panel>
</td>
    <asp:HiddenField ID="hidCurrentIndex" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"  />
</tr>
</table>

</asp:Content>

