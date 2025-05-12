<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true" CodeFile="Six hrs TAT MIS.aspx.cs" Inherits="QueryBuilder_Six_hrs_TAT_MIS" Title="Untitled Page" StylesheetTheme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 102px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 84px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 183px; height: 15px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 16px">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" SkinID="lblErrorMsg"
                    Width="814px"></asp:Label></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 102px; height: 16px">
                Cluster Name :</td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlCluster" runat="server" AutoPostBack="True" DataSourceID="SDScluster"
                    DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluster_DataBound"
                    OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged" SkinID="ddlSkin" Width="154px">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 84px; height: 16px">
                Center Name :</td>
            <td class="Info" colspan="1" rowspan="1">
                <asp:DropDownList ID="ddlCenter" runat="server" AutoPostBack="True" OnDataBound="ddlCenter_DataBound"
                    OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" SkinID="ddlSkin" Width="154px">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
                Suncenter Name :</td>
            <td class="Info" style="width: 183px; height: 16px">
                <asp:DropDownList ID="ddlSubcenter" runat="server" AutoPostBack="True" OnDataBound="ddlSubcenter_DataBound"
                    OnSelectedIndexChanged="ddlSubcenter_SelectedIndexChanged" SkinID="ddlSkin" Width="209px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 102px; height: 26px">
                From Date :</td>
            <td class="Info" style="width: 100px; height: 26px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="105px"></asp:TextBox><img
                    id="Img1" alt="Calendar" height="0" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.png" style="width: 19px; height: 21px" width="0" /></td>
            <td class="reportTitleIncome" style="width: 84px; height: 26px">
                To Date :</td>
            <td class="Info" style="width: 100px; height: 26px">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="105px"></asp:TextBox><img
                    id="Img2" alt="Calendar" height="0" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.png" style="width: 19px; height: 21px" width="0" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 26px">
                <asp:Label ID="lblEmpName" runat="server" SkinID="lblSkin" Text="Employee Name :"
                    Visible="False" Width="93px"></asp:Label></td>
            <td class="Info" style="width: 183px; height: 26px">
                <asp:DropDownList ID="ddlEmpName" runat="server" OnDataBound="ddlEmpName_DataBound"
                    SkinID="ddlSkin" Visible="False" Width="209px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 102px; height: 16px">
                Select MIS Type :</td>
            <td class="Info" style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlMisType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMisType_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="153px">    
                     <asp:ListItem>-Select-</asp:ListItem> 
                    <asp:ListItem Value="Sp_Count_SixHr">TAT MIS</asp:ListItem>
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 84px; height: 16px">
            </td>
            <td class="Info" style="width: 100px; height: 16px">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 16px">
            </td>
            <td class="Info" style="width: 183px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin"
                    Text="Search" Width="96px" /></td>
            <td style="width: 100px; height: 16px">
                <asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" SkinID="btnExpToExlSkin"
                    Text="Export To Excel" Width="121px" /></td>
            <td style="width: 84px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 183px; height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px">
                <asp:GridView ID="GV" runat="server" SkinID="gridviewNoSort" Width="766px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 40px">
            </td>
            <td style="width: 100px; height: 40px">
            </td>
            <td style="width: 84px; height: 40px">
            </td>
            <td style="width: 100px; height: 40px">
            </td>
            <td style="width: 100px; height: 40px">
            </td>
            <td style="width: 183px; height: 40px">
                <asp:SqlDataSource ID="SDScluster" runat="server" ProviderName="System.Data.OleDb"
                    SelectCommand="Get_ClusterMaster;1" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

