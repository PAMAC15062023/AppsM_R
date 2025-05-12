<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DAT_ENTRY.aspx.cs" Theme="SkinFile"
    MasterPageFile="HRMasterPage.master" Inherits="HR_HR_DAT_ENTRY" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>





    <fieldset>
        <legend class="FormHeading" style="color: #330000">Daily Attendance Entry</legend>
        <table width="100%">
        <tr>
          <td>
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False" Width="133px"></asp:Label></td>
        </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblHierChichy" runat="server" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#404040" SkinID="lblSkin"></asp:Label></td>
                <td>
                </td>
                <td style="width: 9px">
                </td>
                <td style="width: 109px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCluster" runat="server" Text="Cluster Name" Visible="False"></asp:Label></td>
                <td style="width: 2px; height: 24px;">
                    <asp:Label ID="lblClusterCo" runat="server" Text=":" Visible="False" Width="2px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCluster" runat="server" DataSourceID="sdsCluster" SkinID="ddlSkin"
                        OnDataBound="ddlCluster_DataBound" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged"
                        DataValueField="CLUSTER_ID" AutoPostBack="True" DataTextField="CLUSTER_NAME"
                        Visible="False">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="lblCentre" runat="server"  Text="Hub" Visible="False"></asp:Label></td>
                <td style="width: 10px">
                    <asp:Label ID="lblCentreCo" runat="server" Text=":" Visible="False" Width="2px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCentreName" runat="server" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME"
                        DataValueField="CENTRE_ID" OnDataBound="ddlCentreName_DataBound" OnSelectedIndexChanged="ddlCentreName_SelectedIndexChanged"
                        AutoPostBack="True" SkinID="ddlSkin" Visible="False">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="lblSubCentre" runat="server"  Visible="False">DD Payble Location</asp:Label></td>
                <td style="width: 9px">
                    <asp:Label ID="lblSubcentreCo" runat="server" Text=":" Visible="False" Width="2px"></asp:Label></td>
                <td style="width: 109px">
                    <asp:DropDownList ID="ddlSubCentre" runat="server" DataSourceID="sdsSubCentre" DataTextField="SubCentreName"
                        DataValueField="SubCentreId" SkinID="ddlSkin" OnDataBound="ddlSubCentre_DataBound"
                        Visible="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="ASM Name" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text=":"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SdsRsm" SkinID="ddlSkin"
                        DataValueField="emp_Code" AutoPostBack="True" DataTextField="fullname" Visible="False"
                        OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRM" runat="server" Text="SM Name" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcoRM" runat="server" Text=":"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRM" runat="server" DataSourceID="sdsRM" SkinID="ddlSkin"
                        DataValueField="emp_Code" AutoPostBack="True" DataTextField="fullname" Visible="False"
                        OnDataBound="ddlRM_DataBound2" OnSelectedIndexChanged="ddlRM_SelectedIndexChanged1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                   FOS Code</td>
                <td>
                    :</td>
                <td>
                    <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                <td>
                    FOS Name</td>
                <td style="width: 10px">
                    :</td>
                <td>
                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="Show" Visible="False" /></td>
                <td style="width: 9px">
                </td>
                <td align="left" style="width: 109px">
                    <asp:ImageButton ID="ImageButton1" runat="server" BackColor="#FFFFC0" Height="25px"
                        ImageUrl="~/Images/55.jpeg" OnClick="ImageButton1_Click" Width="100px" />
                </td>
            </tr>
            <tr>
                <td style="height: 63px">
                    From Date</td>
                <td style="height: 63px">
                    :
                </td>
                <td style="width: 11px; height: 63px;">
                    <asp:TextBox ID="txtRequestFromDate" runat="server" Width="122px" SkinID="txtSkin" OnTextChanged="txtRequestFromDate_TextChanged" AutoPostBack="true"
                        ></asp:TextBox>[dd/mm/yyyy] 
                </td>
                <td style="height: 63px">
                    To Date
                </td>
                <td style="height: 63px; width: 10px;">
                    :</td>
                <td style="width: 11px; height: 63px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="125px" SkinID="txtSkin" ></asp:TextBox>
                
                        [dd/mm/yyyy] 
                        </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="9" style="height: 21px">
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" ForeColor="#404040"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="9">
                    <asp:GridView ID="GVDE" runat="server" SkinID="grdMain" AutoGenerateColumns="False"
                        OnRowDataBound="GVDE_RowDataBound" AllowPaging="True" OnPageIndexChanging="GVDE_PageIndexChanging"
                        PageSize="50">
                        <Columns>
                            <asp:BoundField DataField="Emp Code" HeaderText="FOS Code" />
                             <asp:BoundField DataField="Pamecian" HeaderText="FOS Name" />
                             <asp:BoundField DataField="Designation" HeaderText="Designation" />
                            <asp:BoundField DataField="Centre_Name" HeaderText="HUB" />
                            <asp:BoundField DataField="SubcentreName" HeaderText="DD Payable Location" />
                           
                            <asp:BoundField DataField="Department" HeaderText="Department" Visible="false" />
                            
                            <%-- <asp:BoundField DataField="Unit" HeaderText="Unit" />--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl1" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl2" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hidEmpID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl3" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--  <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl4" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%-- <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl5" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl6" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl7" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl8" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl9" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl10" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl11" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl12" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl13" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl14" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddl15" runat="server" SkinID="ddlSkin">
                                        <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                        <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                           <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--    <asp:HiddenField ID="hidEmpID" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 10px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 9px">
                </td>
                <td align="left" style="width: 109px">
                    <asp:ImageButton ID="imgntnsave" runat="server" Height="25px" ImageUrl="~/Images/Sub.bmp"
                        OnClick="ImageButton2_Click" Width="100px" /></td>
            </tr>
            <tr>
                <td colspan="9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="9">
                    &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Button"
                        Visible="False" />&nbsp;
                </td>
            </tr>
        </table>
        <br />
        <asp:SqlDataSource ID="sdsSubCentre" runat="server" ProviderName="System.Data.OleDb">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsCentre" runat="server" ProviderName="System.Data.OleDb"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsCluster" runat="server" ProviderName="System.Data.OleDb"
            SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsRM" runat="server" ProviderName="System.Data.OleDb"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SdsRsm" runat="server" ProviderName="System.Data.OleDb"></asp:SqlDataSource>
    </fieldset>

    <script language="javascript" type="text/javascript">
    function test(){
    alert("hiiii")
    }
    </script>

</asp:Content>
