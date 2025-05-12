<%@ Page Language="C#" MasterPageFile="~/FE/FE/CC_MasterPage.master" AutoEventWireup="true" CodeFile="Consolid_LabelPrint.aspx.cs" Inherits="FE_FE_Consolid_LabelPrint" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
    <fieldset>
       <legend class="FormHeading">Label Printing</legend>
        <table style="width: 1166px">
            <tr>
                <td style="width: 70px; height: 15px">
                </td>
                <td style="width: 169px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
                <td style="width: 175px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                    From Date<span style="color: #ff0000">*</span></td>
                <td style="width: 169px">
                    <asp:TextBox ID="txtfrom" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtfrom, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy</td>
                <td style="width: 100px">
                    To Date<span style="color: #ff0000">*</span></td>
                <td style="width: 175px">
                    <asp:TextBox ID="txtto" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox><img
                        alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtto, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy</td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 16px">
                    FE Name
                </td>
                <td style="width: 169px; height: 16px">
                    <asp:DropDownList ID="ddlFEName" runat="server" DataSourceID="sdsSearchFE" DataTextField="FULLNAME"
                        DataValueField="EMP_ID" OnSelectedIndexChanged="ddlverify_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px">
                    Product Type</td>
                <td style="width: 175px; height: 16px">
                    <asp:DropDownList ID="ddlproduct_ID" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Product_NAME" DataValueField="Product_id" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 16px">
                    <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" SkinID="btnSearchSkin"
                        Text="Search" Width="85px" /></td>
                <td style="width: 169px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 175px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 16px">
                    Verification Type<span style="color: #ff0000">*</span><span style="color: #ff0000"></span></td>
                <td style="width: 169px; height: 16px">
                    <asp:DropDownList ID="ddlverify" runat="server" OnDataBound="ddlverify_DataBound"
                        SkinID="ddlSkin" Width="170px">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 16px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="btnGenrateLabel"
                        Text="Generate Label" Width="120px" /></td>
                <td style="width: 175px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 16px">
                    <span style="color: #ff0033">*</span>Indicate&nbsp; mandatory fields.</td>
                <td style="width: 169px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 175px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; height: 16px">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="237px"></asp:Label></td>
                <td style="width: 169px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
                <td style="width: 175px; height: 16px">
                </td>
                <td style="width: 100px; height: 16px">
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GV" runat="server" AllowSorting="false" OnSorting="GV_Sorting"
                        SkinID="gridviewSkin" Width="100%">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                </td>
                <td style="width: 169px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 175px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MumbaiConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:MumbaiConnectionString.ProviderName %>" SelectCommand=" SELECT DISTINCT   Product_id,Product_NAME  FROM  product_Master &#13;&#10;where product_id in (1011,1012,1015,1016,1018)">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsSearchFE" runat="server"
                        ProviderName="<%$ ConnectionStrings:MumbaiConnectionString.ProviderName %>" SelectCommand="SELECT '0' as [EMP_ID],'--All--' as [FULLNAME]  UNION   SELECT DISTINCT  EMP_ID,FULLNAME  FROM  FE_VW &#13;&#10; where ([Centre_ID]=?) order by FULLNAME ">
                        <SelectParameters>
                            <asp:SessionParameter Name="Centre_ID" SessionField="CentreId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="width: 169px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
                        ErrorMessage="Enter From Date"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
                        ErrorMessage="Enter To Date"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlverify"
                        ErrorMessage="Select Verification Type"></asp:RequiredFieldValidator></td>
                <td style="width: 100px">
                    </td>
                <td style="width: 175px">
                    </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    
    </fieldset>
        </td></tr>
</table> 
</asp:Content>

