<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="DAT_MIS.aspx.cs" Inherits="HR_HR_DAT_MIS" Title="DAT MIS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="popcalendar.js"></script>    
 
 <script language="javascript" type="text/javascript">
    
        function OnSearch_Validation()
        {
            var ReturnValue=true;
            var ErrorMessage ='';
            var txtFromDate = document.getElementById("<%=txtFromDate.ClientID%>"); 
            var txtToDate = document.getElementById("<%=txtToDate.ClientID%>") 
            var ddlMisType = document.getElementById("<%=ddlMisType.ClientID%>")
            var lblMessage = document.getElementById("<%=lblMessage.ClientID%>") 
            
          if(txtFromDate.value == '')
          {
            ErrorMessage='Plz Select From Date';
            ReturnValue=false;
          }  
          
          if(txtToDate.value == '')
          {
            ErrorMessage='Plz Select To Date';
            ReturnValue=false;
          }
          
          if(ddlMisType.selectedIndex == 0)
          {
            ErrorMessage='Plz Select MIS';
            ReturnValue=false;
          }
          
          lblMessage.innerText = ErrorMessage;
          return ReturnValue;
          
        } 
 </script> 
    
    <table>
        <tr>
            <td style="width: 102px; height: 15px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="DAT MIS"
                    Width="85px" SkinID="lblSkin" ForeColor="#400040" Height="8px"></asp:Label></td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 53px; height: 15px">
            </td>
            <td style="width: 84px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 49px; height: 15px">
            </td>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 213px; height: 15px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px">
                <asp:Label ID="lblMessage" runat="server" SkinID="lblErrorMsg"  Width="98px" Font-Bold="True" ForeColor="#004000"></asp:Label></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 53px; height: 16px">
            </td>
            <td style="width: 84px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 49px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 213px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px">
                Cluster Name :</td>
            <td style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlCluster" runat="server" SkinID="ddlSkin" Width="154px" DataSourceID="SDScluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" OnDataBound="ddlCluster_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged">
                </asp:DropDownList><asp:SqlDataSource ID="SDScluster" runat="server" 
                    ProviderName="System.Data.OleDb" SelectCommand="Get_ClusterMaster;1"
                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </td>
            <td style="width: 53px; height: 16px">
            </td>
            <td style="width: 84px; height: 16px">
                Center Name :</td>
            <td style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlCenter" runat="server" Width="154px" AutoPostBack="True" OnDataBound="ddlCenter_DataBound" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 49px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
                Suncenter Name :</td>
            <td style="width: 213px; height: 16px">
                <asp:DropDownList ID="ddlSubcenter" runat="server" Width="209px" OnDataBound="ddlSubcenter_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlSubcenter_SelectedIndexChanged" SkinID="ddlSkin">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 102px; height: 26px;">
                From Date :</td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 53px; height: 26px;">
            <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 21px" height="0" width="0" />
            </td>
            <td style="width: 84px; height: 26px;">
                To Date :</td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin_New"></asp:TextBox></td>
            <td style="width: 49px; height: 26px;"><img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.png" style="width: 19px; height: 21px" height="0" width="0" /></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 213px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 102px; height: 16px;">
                Select MIS Type :</td>
            <td style="width: 100px; height: 16px;">
                <asp:DropDownList ID="ddlMisType" runat="server" Width="153px" AutoPostBack="True" OnSelectedIndexChanged="ddlMisType_SelectedIndexChanged" SkinID="ddlSkin">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem Value="Get_NewJoineeMIS">New Joinee MIS</asp:ListItem>
                    <asp:ListItem Value="Get_PAMACianLeftMIS">Employee Left MIS</asp:ListItem>
                    <asp:ListItem Value="Sp_DailyAttendance_Report">Employee Personal MIS</asp:ListItem>
                    <asp:ListItem Value="Get_MACDetailsMIS">Employee MACAddress Details</asp:ListItem>
                    <asp:ListItem Value="Sp_DATA_Entry">Cases Assignment MIS</asp:ListItem>
        
                </asp:DropDownList></td>
            <td style="width: 53px; height: 16px;">
            </td>
            <td style="width: 84px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 49px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px">
                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name :" Width="93px" Visible="False"></asp:Label></td>
            <td style="width: 213px; height: 16px"><asp:DropDownList ID="ddlEmpName" runat="server" Width="209px" OnDataBound="ddlEmpName_DataBound" Visible="False" SkinID="ddlSkin">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 102px; height: 21px;">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="96px" OnClick="btnSearch_Click" SkinID="btnSearchSkin" Visible="False" /></td>
            <td style="width: 100px; height: 21px;">
                <asp:Button ID="btnExportExcel" runat="server" Text="Export To Excel" Width="121px" OnClick="btnExportExcel_Click" SkinID="btnExpToExlSkin" Visible="False" /></td>
            <td style="width: 53px; height: 21px;">
            </td>
            <td style="width: 84px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 49px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 213px; height: 21px;">
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
                <asp:ImageButton ID="ImageButton1" runat="server" BackColor="#FFFFC0" Height="25px"
                    ImageUrl="~/Images/55.jpeg" OnClick="ImageButton1_Click" ValidationGroup="Valgrp"
                    Width="100px" /></td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 53px">
                </td>
            <td style="width: 84px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 49px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 213px" align="right">
                <asp:ImageButton ID="imgbtnExport" runat="server" Height="25px" ImageUrl="~/Images/down.jpeg"
                    Width="110px" OnClick="imgbtnExport_Click" /></td>
        </tr>
    </table>
    
    <asp:Panel ID="Panel1" runat="server" Height="345px" ScrollBars="Both" Width="966px">
     <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                    width="100%">
                    <tr>
                        <td>
   <asp:GridView ID="GV" runat="server" SkinID="grdMain" Width="946px" Height="326px" BackColor="White">
    </asp:GridView>
   </td>
   </tr> 
        </table> 
    </asp:Panel>
</asp:Content>

