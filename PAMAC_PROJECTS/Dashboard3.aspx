<%@ Page Language="C#"   AutoEventWireup="true" CodeBehind="Dashboard3.aspx.cs" Inherits="Pamac_Projects.Dashboard3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
      <link href="../App_Assets/css/StyleSheet.css" rel="stylesheet" />
     
<head runat="server">
    <title>DASHBOARLSD CASE DETAILS</title>
    <style type="text/css">  
        body {  
            background-color: white;  
            font-family: Arial;  
            font-size: 10pt;  
            color: #444;  
            position:fixed ;
             top:0 ;
        }  

        .ParentMenu, .ParentMenu:hover {  
            width: 100px;  
            background-color: black;  
            color: #333;  
            text-align: center;  
            height: 30px;  
            line-height: 30px;  
            margin-right: 5px;  
            font-size:12px;
            color: white;
        }  
  
            .ParentMenu:hover {  
                background-color: #ccc;  
            }  
  
        .ChildMenu, .ChildMenu:hover {  
            width: 110px;  
            background-color: blue;  
            color: #333;  
            text-align: left;  
            height: 20px;  
            line-height: 20px;  
            margin-top: 5px;  
             font-size:12px
        }  
  
            .ChildMenu:hover {  
                background-color: #ccc;  
                font-size:14px;
            }  
  
        .selected, .selected:hover {  
            background-color: #A6A6A6 !important;  
            color: #fff;  
        }  
  
        .level2 {  
            background-color: #fff;  
        }  
  
    </style>  

</head>
    <script>
    function errorCheckChanged(chkBox){  
    var gridView = document.getElementById('<% =grdcases.ClientID %>');   
    var Elements = gridView.getElementsByTagName('input');   
    
    for(var i = 0; i < Elements.length; i++){
        if(Elements[i].type == 'checkbox' && Elements[i].id != chkBox.id && chkBox.checked)
            Elements[i].checked = false;
    }
        }
    </script>
    
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Height="16px"
                            Visible="True" Width="100%" Font-Bold="True"></asp:Label>
        </div>


        <table style="width: 688px;">
        <tr>
            <td>
                <span style="font-size: 13pt; font-weight: bold;">CASE&nbsp;DETAILS</span>
            </td>
        </tr>
            <tr> <td> </td> </tr>
            <tr><td> </td></tr>   <tr> <td> </td> </tr>   <tr><td> </td></tr>  <tr> <td> </td> </tr>
    </table>
        <table>
       <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblcaseid" runat="server" Text="CaseId"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtcaseid" runat="server"></asp:TextBox>
                </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblcreateddate" runat="server" Text="Created_date"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCreated_date" runat="server"></asp:TextBox>
                </td>
        </tr>
      <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblapplicants_name" runat="server" Text="applicants_name"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtapplicants_name" runat="server"></asp:TextBox>
                </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblapplicants_address" runat="server" Text="applicants_address"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtapplicants_address" runat="server"></asp:TextBox>
                </td>
        </tr>


         <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblveriftype_id" runat="server" Text="veriftype_id"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtveriftype_id" runat="server"></asp:TextBox>
                </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblfe_id" runat="server" Text="fe_id"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtFe_id" runat="server"></asp:TextBox>
                </td>
        </tr>
              <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblassign_date" runat="server" Text="assign_date"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtassign_date" runat="server"></asp:TextBox>
                </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblassign_status" runat="server" Text="assign_status"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtassign_status" runat="server"></asp:TextBox>
                </td>
        </tr>
             <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblassign_accept_date" runat="server" Text="assign_accept_date"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtassign_accept_date" runat="server"></asp:TextBox>
                </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblfe_submit_date" runat="server" Text="fe_submit_date"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtfe_submit_date" runat="server"></asp:TextBox>
                </td>
        </tr>

             <tr> <td> </td> </tr>
            <tr><td> </td></tr>   <tr> <td> </td> </tr>   <tr><td> </td></tr>  <tr> <td> </td> </tr>
</table>
    


           <asp:GridView ID="grdcases" runat="server" AutoGenerateColumns="true" Visible="true"   
                    CssClass="mGrid" Width="711px" Height="37px">
                  <%--  <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectALL" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" onclick="errorCheckChanged(this)" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click">GeneratePDF</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdelete" runat="server" Font-Bold="True" OnClick="lnkdelete_Click">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                      <%--  <asp:BoundField DataField="question" HeaderText="Question" />
                        <asp:BoundField DataField="Answer" HeaderText="Correct Answer" />
                        <asp:BoundField DataField="que_id" HeaderText="Question ID" />--%>
                    <%--</Columns>--%>
                </asp:GridView>
    </form>
</body>
</html>
