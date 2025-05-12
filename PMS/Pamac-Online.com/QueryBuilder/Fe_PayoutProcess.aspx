<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true" CodeFile="Fe_PayoutProcess.aspx.cs" Inherits="QueryBuilder_Fe_PayoutProcess" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../popcalendar.js"></script>
<script language="javascript" type="text/javascript">

function checkSelected2(CaseId,lblFixedIcl,lblFixedOCL,txtSpecialRate,lblTotalPay,txtPenelaty,chkSelect,ProductCode,VeriType)
{
        //debugger;
        var hdnPayoutData=document.getElementById("<%=hdnPayoutData.ClientID%>");
        var hdnFEID=document.getElementById("<%=hdnFEID.ClientID%>");
               
        var TotalPay = parseFloat(lblFixedIcl.innerText) + parseFloat(lblFixedOCL.innerText) + parseFloat(txtSpecialRate.value);
        var TotalPenelaty = 0;
        
        if(txtPenelaty.value != "")
        {
            TotalPenelaty= parseFloat(txtPenelaty.value)
        }           
           
        

        lblTotalPay.innerText = (TotalPay -TotalPenelaty);
       
        
        
        var strPayOutDetails=CaseId+"|"+ProductCode+"|"+VeriType+"|"+hdnFEID.value+"||"+parseFloat(lblFixedIcl.innerText)+"|"+parseFloat(lblFixedOCL.innerText)+"|"+parseFloat(txtSpecialRate.value)+"|"+parseFloat(txtPenelaty.value)+"|"+parseFloat(lblTotalPay.innerText)+"||^";
        
        hdnPayoutData.value=hdnPayoutData.value+""+strPayOutDetails;
        Validate_FEPayout(CaseId,chkSelect.checked,VeriType);
        
        var lblMessage=document.getElementById("<%=lblMsg.ClientID%>");
        var ReturnValue=true;
        var ErrorMessage='';  
         
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);
        return ReturnValue; 

}


function checkSelected(CaseId,lblFixedIcl,lblFixedOCL,txtSpecialRate,lblTotalPay,txtPenelaty,chkSelect,ProductCode,VeriType)
{
        //debugger;
        var hdnPayoutData=document.getElementById("<%=hdnPayoutData.ClientID%>");
        var hdnFEID=document.getElementById("<%=hdnFEID.ClientID%>");
               
        var TotalPay = parseFloat(lblFixedIcl.innerText) + parseFloat(lblFixedOCL.innerText) + parseFloat(txtSpecialRate.value);
        var TotalPenelaty = 0;
        
        if(txtPenelaty.value != "")
        {
            TotalPenelaty= parseFloat(txtPenelaty.value)
        }           
           
//        if (chkSelect.checked == true)
//        {

            lblTotalPay.innerText = (TotalPay -TotalPenelaty);
//            
//        }
//        else        
//        {
//         lblTotalPay.innerText="0.00";
//        }
        
        
        var strPayOutDetails=CaseId+"|"+ProductCode+"|"+VeriType+"|"+hdnFEID.value+"||"+parseFloat(lblFixedIcl.innerText)+"|"+parseFloat(lblFixedOCL.innerText)+"|"+parseFloat(txtSpecialRate.value)+"|"+parseFloat(txtPenelaty.value)+"|"+parseFloat(lblTotalPay.innerText)+"||^";
        
        hdnPayoutData.value=hdnPayoutData.value+""+strPayOutDetails;
        Validate_FEPayout(CaseId,chkSelect.checked,VeriType);
        
        var lblMessage=document.getElementById("<%=lblMsg.ClientID%>");
        var ReturnValue=true;
        var ErrorMessage='';  
         
        lblMessage.innerText=ErrorMessage;
        window.scroll(0,0);
        return ReturnValue; 

}

        function Validate_FEPayout(CaseID,Checked,strVeriType)
        {
            var hdnPayoutData=document.getElementById("<%=hdnPayoutData.ClientID%>");
            var strFEData=hdnPayoutData.value;
        
            var strOutPut="";
                            var strRowDetails="";
                            var strColDetails="";

                            strRowDetails=strFEData.split('^', strFEData.length); 
                            
                            var i=0;
                            var j=0;
                            var strRowlength=0;

                                for (i=0;i<=strRowDetails.length-2;i++)            
                                {                 
                                 strColDetails=strRowDetails[i];
                                 strColDetails=strColDetails.split('|', strColDetails.length);

                                                
                                    if ((CaseID==strColDetails[0])&& (Checked==false)&&(strVeriType==strColDetails[2]))
                                    {
                                            strOutPut=strOutPut+"";                          
                                    }
                                    else
                                    {
                                     strOutPut=strOutPut+strRowDetails[i]+"^";     
                                    }
                                  
                                } 
                               
                        hdnPayoutData.value= strOutPut;
        }

</script>  
    <table>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 8px">
            </td>
            <td style="width: 73px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 8px">
            </td>
            <td style="width: 73px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
        <tr>
            <td colspan="1" style="width: 7px">
            </td>
            <td colspan="3">
                <strong><span style="font-size: 10pt">FE - PAYOUT PROCESS</span></strong></td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 16px">
            </td>
            <td colspan="3" style="height: 16px">
                <asp:Label ID="lblMsg" runat="server" BackColor="White" Font-Bold="True" Font-Size="Larger"
                    ForeColor="Red" Width="301px"></asp:Label></td>
            <td style="width: 24px; height: 16px">
            </td>
            <td style="width: 217px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 16px">
            </td>
            <td style="width: 24px; height: 16px">
                Product Name :</td>
            <td style="width: 100px; height: 16px">
                Fe Name :</td>
            <td style="width: 73px; height: 16px">
                </td>
            <td style="height: 16px; width: 142px;">
                From Date :</td>
            <td colspan="1" style="width: 217px; height: 16px">
                To Date :</td>
        </tr>
        <tr>
            <td style="width: 7px; height: 38px">
            </td>
            <td style="width: 24px; height: 38px">
                <asp:DropDownList ID="ddlProductName" runat="server" Width="97px">
                </asp:DropDownList></td>
            <td colspan="2" style="height: 38px">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtFeName" runat="server" Width="98px"></asp:TextBox></td>
                        <td style="width: 31px">
                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text=">>" /></td>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlFeName" runat="server" >
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList></td>
                    </tr>
                </table>
            </td>
            <td style="width: 142px; height: 38px">
                <table>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtFromDate" runat="server" Width="104px"></asp:TextBox></td>
                        <td style="width: 100px; height: 26px;">
                            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 217px; height: 38px; text-align: left;">
                <table>
                    <tr>
                        <td style="width: 100px; height: 27px;">
                            <asp:TextBox ID="txtToDate" runat="server" Width="104px"></asp:TextBox></td>
                        <td style="width: 29px; height: 27px;">
                            <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.png" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 26px;">
            </td>
            <td style="width: 24px; height: 26px;">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Width="102px" Font-Bold="True" /></td>
            <td style="width: 100px; height: 26px;">
                </td>
            <td style="width: 73px; height: 26px;">
                <asp:Button ID="btnExportExc" runat="server" Font-Bold="True" OnClick="Button1_Click"
                    Text="Case Wise Count" /></td>
            <td style="width: 142px; height: 26px;">
                <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click1"
                    Text="PANINDIA MIS" /></td>
            <td style="width: 217px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td colspan="5" rowspan="3">
                <asp:Panel ID="Panel1" runat="server" Height="212px" Width="908px" ScrollBars="Both">
                    <asp:GridView ID="GV1" runat="server" Width="797px" AutoGenerateColumns="False" OnRowDataBound="GV1_RowDataBound" BackColor="#FFFFC0" BorderColor="Blue" BorderStyle="Outset" ForeColor="Maroon">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Product" HeaderText="Product" />
                            <asp:BoundField DataField="Case_Id" HeaderText="Case Id" />
                            <asp:BoundField DataField="Ref_No" HeaderText="Referance No" />
                            <asp:BoundField DataField="AppliName" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Verification_type_code" HeaderText="Verification Code" />
                            <asp:BoundField DataField="Client_Name" HeaderText="Client Name" />
                            <asp:BoundField DataField="FeName" HeaderText="FE Name" />
                            <asp:BoundField DataField="Area_Name" HeaderText="Area" />
                            <asp:TemplateField HeaderText="Fixed ICL">
                                <ItemTemplate>
                                    <asp:Label ID="lblFixedIcl" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Fixed_ICLRate"))%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fixed OCL">
                                <ItemTemplate>
                                    <asp:Label ID="lblFixedOCL" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Fixed_OCLRate"))%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Special Rates">
                                <ItemTemplate>
                                    &nbsp;
                                    <asp:TextBox ID="txtSpecialRate" runat="server" Text='0.00'
                                        Width="48px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Penelaty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPenelaty" runat="server" Width="48px" Text='0.00'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Pay">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPay" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"TotalPay"))%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Authorise By" DataField="AuthorizeBy"/>
                            <asp:BoundField HeaderText="Authorise Date" DataField="AuthorizeDate"/>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:HiddenField ID="hdnPayoutData" runat="server" /><asp:HiddenField ID="hdnFEID" runat="server" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 91px;">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 18px;">
            </td>
            <td style="width: 24px; height: 18px;">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="107px" Font-Bold="True" /></td>
            <td style="width: 8px; height: 18px;">
                <asp:Button ID="btnExport" runat="server" Font-Bold="True" OnClick="btnExport_Click"
                    Text="Export Preauthorise MIS" Width="187px" Enabled="False" Visible="False" /></td>
            <td style="width: 73px; height: 18px;">
            </td>
            <td style="width: 24px; height: 18px;">
            </td>
            <td style="width: 217px; height: 18px;">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 8px;">
            </td>
            <td style="width: 24px; height: 8px;">
                <asp:Button ID="btnCan" runat="server" Font-Bold="True" OnClick="btnCan_Click" Text="Cancel"
                    Width="107px" /></td>
            <td style="width: 8px; height: 8px;">
            </td>
            <td style="width: 73px; height: 8px;">
            </td>
            <td style="width: 24px; height: 8px;">
            </td>
            <td style="width: 217px; height: 8px;">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 8px">
            </td>
            <td style="width: 73px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 24px">
                </td>
            <td style="width: 8px">
            </td>
            <td style="width: 73px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 24px">
                <asp:GridView ID="GV2" runat="server">
                </asp:GridView>
                &nbsp;
            </td>
            <td style="width: 8px">
                <asp:GridView ID="GV3" runat="server">
                </asp:GridView>
            </td>
            <td style="width: 73px">
            </td>
            <td style="width: 24px">
            </td>
            <td style="width: 217px">
            </td>
        </tr>
    </table>
</asp:Content>

