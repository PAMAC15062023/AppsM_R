<%@ Page Language="C#" MasterPageFile="~/Master/Master/MasterPage.master" AutoEventWireup="true" CodeFile="FEPincodeMapping_Master.aspx.cs" Inherits="Master_Master_FEPincodeMapping_Master" Title="Untitled Page" Theme="SkinFile" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
    &nbsp; &nbsp;<fieldset><legend class="FormHeading">FE PINCODE MASTER</legend>
    <script type="text/javascript" language="javascript">
                
        function ValidationOnMandatoryField()
        { 
           var ReturnType = true;
           var ErrorMessage="";
           var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
           var txtPincodeNo=document.getElementById("<%=txtPincodeNo.ClientID%>");
           var txtICLRate=document.getElementById("<%=txtICLRate.ClientID%>");
           var txtOCLRate=document.getElementById("<%=txtOCLRate.ClientID%>");
           var txtAreaName=document.getElementById("<%=txtAreaName.ClientID%>");
           var ddlIsActive=document.getElementById("<%=ddlIsActive.ClientID%>");
           
            if(ddlIsActive.selectedIndex == 0)
            {
               ErrorMessage="Please Select Is Active";
               ReturnType=false;
               ddlIsActive.focus();      
            }
            
            if((txtICLRate.value=='' && txtOCLRate.value=='') || isNaN(txtICLRate.value) || isNaN(txtOCLRate.value))
            {
               ErrorMessage="Please Enter either ICL or OCL Rate";
               ReturnType=false; 
               txtICLRate.focus();  
            }
//            else if (txtOCLRate.value=='')
//            {
//               ErrorMessage="Either fill ICL OR OCL Rate";
//               ReturnType=false;
//            }

            if(txtAreaName.value=='')
            {
               ErrorMessage="Please Enter Area Name";
               ReturnType=false;    
               txtAreaName.focus(); 
            }
            
            if((txtPincodeNo.value=='') || isNaN(txtPincodeNo.value) || (txtPincodeNo.value.length !=6))
            { 
               ErrorMessage="Please Enter Valid 6 digit Pincode Number";
               ReturnType=false;   
               txtPincodeNo.focus(); 
            }            

           window.scrollTo(0,0);
           lblMessage.innerText=ErrorMessage;         
           return ReturnType;
        }
</script>



     
    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" Width="611px" ForeColor="Red" Font-Bold="true" Visible="true"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 5px; height: 26px;">
            </td>
            <td style="width: 77px; height: 26px;" class="label">
                Pincode No
                <asp:Label ID="lblS1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Larger"  Text="*" Width="8px"></asp:Label></td>
            <td style="width: 7px; height: 26px;">
                &nbsp;:</td>
            <td style="height: 26px;">
                <asp:TextBox ID="txtPincodeNo" runat="server" TabIndex="1" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>


            <td style="width: 77px; height: 26px;" class="label">
                Area Name</td>
            <td style="width: 7px; height: 26px;">
                &nbsp;:</td>
            <td>
                <asp:TextBox ID="txtAreaName" runat="server" TabIndex="9" CssClass="textbox" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 5px; height: 26px;">
            </td>
            <td style="width: 77px; height: 26px;" class="label">
                Fixed ICL Rate</td>
            <td style="width: 7px; height: 26px;">
                &nbsp;:</td>
            <td>
                <asp:TextBox ID="txtICLRate" runat="server" TabIndex="3" CssClass="textbox" SkinID="txtSkin"></asp:TextBox></td>
            <td class="label" style="height: 26px">
                Fixed OCL Rate</td>
            <td style="width: 7px; height: 26px;">
                &nbsp;:</td>
            <td style="width: 214px;">
                <asp:TextBox ID="txtOCLRate" runat="server" TabIndex="4" Width="152px" CssClass="textbox" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 5px; height: 26px;">
            </td>

            <td class="label" style="height: 26px">
                Is Active</td>
            <td style="width: 7px; height: 26px;">
                &nbsp;:</td>
            <td style="width: 214px;">
                <asp:DropDownList ID="ddlIsActive" runat="server" TabIndex="10" Width="100px" SkinID="ddlSkin">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 16px;" colspan="7">
                &nbsp;
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Larger" Text="*" Width="1px"></asp:Label>&nbsp;
                <strong>Indicate Mandatory Field</strong></td>
        </tr>
        <tr>
            <td align="left" colspan="7">
                &nbsp;<asp:Button ID="btnSubmit" runat="server" TabIndex="11" Text="SUBMIT" SkinID="btnSubmitSkin" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" TabIndex="12" Text="CANCEL" SkinID="btnCancelSkin" OnClick="btnCancel_Click" />
                <asp:Button ID="btnAdd" runat="server" TabIndex="13" Text="RESET" SkinID="btnresetskin" OnClick="btnAdd_Click" />
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btnexportskin"
                    Text="Export" Visible="true" /></td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="7">
                &nbsp;<asp:GridView ID="GvPaMis" runat="server" OnRowCommand="GvPaMis_RowCommand" SkinID="gridviewNoSort">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                &nbsp;<asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("UID") %>'
                                    CommandName="Ed"><img src="../../Images/icon_edit.gif"alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                
                <asp:GridView ID="GridExport" runat="server" AutoGenerateColumns="false" SkinID="gridviewNoSort" Visible="false">
                    <Columns>
                        <asp:BoundField DataField="Pincode No." HeaderText="Pincode No." />
                        <asp:BoundField DataField="Pincode Area Name" HeaderText="Area Name" />
                        <asp:BoundField DataField="Fixed ICL Rate" HeaderText="Fixed ICL Rate" />
                        <asp:BoundField DataField="Fixed OCL Rate" HeaderText="Fixed OCL Rate" />
                        <asp:BoundField DataField="Is Active" HeaderText="Is Active" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
        <asp:HiddenField ID="hdnPincode_Id" runat="server" Value="0" />
        <asp:HiddenField ID="HdnUpdate" runat="server" />
        <asp:HiddenField ID="HDNUID" runat="server" />
   </fieldset></td></tr></table>




</asp:Content>

