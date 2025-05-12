<%@ Page Language="C#" MasterPageFile="~/Admin/Assets_Inventory/MasterPage.master" AutoEventWireup="true" CodeFile="Subassetdetailspc.aspx.cs" Inherits="Admin_Assets_Inventory_Subassetdetailspc" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 628px; background-color: #C5C6D0;">
        <tr>
            <td class="topbar" colspan="8" style="height: 28px; background-color: #7F7D9C; border: 5px double #ADADC9;
                text-align: center">
                Assets Inventory Sub Assets Details(PC)
            </td>
        </tr>
        <tr>
            <td style="width: 107px; height: 17px" class="Info">
                <strong>TransRefNo</strong></td>
            <td class="reportTitleIncome" style="width: 111px; height: 17px">
                <asp:TextBox ID="txtemptrans" runat="server"></asp:TextBox></td>
            <td class="Info" style="width: 128px; height: 17px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"
                    Style="height: 28px; background-color: #7F7D9C; border: 5px double #ADADC9; text-align: center"
                    BorderColor="#FFC080" Font-Bold="True" Font-Overline="False" ForeColor="Black" /></td>
            <td class="Info" style="width: 128px; height: 17px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="OrangeRed" SkinID="lblError"></asp:Label>
                <asp:Label ID="lblTransCode" runat="server" Font-Bold="True" ForeColor="RoyalBlue"
                    SkinID="lblError"></asp:Label>
                <asp:Label ID="Lblmessage2" runat="server" Font-Bold="True" ForeColor="SeaGreen"
                    SkinID="lblError"></asp:Label></td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 107px; height: 26px;">
                &nbsp;TransRefNo</td>
            <td class="Info" style="width: 111px; height: 26px;">
                <asp:Label ID="lbltransrefno" runat="server" Text="Label"></asp:Label></td>
            <td class="reportTitleIncome" style="width: 128px; height: 26px;">
                Employee Name</td>
            <td class="Info" style="width: 106px; height: 26px;">
                <asp:Label ID="lblempname" runat="server" Text="Label"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="reportTitleIncome" style="width: 107px; height: 24px;">
                &nbsp;Centre</td>
            <td class="Info" style="width: 111px; height: 24px;">
                <asp:Label ID="lblcentre" runat="server" Text="Label"></asp:Label></td>
            <td class="reportTitleIncome" style="width: 128px; height: 24px;">
                Sub Centre</td>
            <td class="Info" style="width: 106px; height: 24px;">
                <asp:Label ID="lblsubcentre" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="9">
            </td>
        </tr>
    </table>
    <%--added by prachi--%>
    <asp:Panel ID="pnlscrapMain" runat="server" Style="width: 628px; background-color: #C5C6D0;">
        <table style="width: 628px; background-color: #C5C6D0;">
            <tr>
                <td class="reportTitleIncome" style="width: 118px">
                    <strong><span style="font-size: 11pt">&nbsp;<span style="color: #3300ff">Want to Scrap:</span></span></strong></td>
                <td class="reportTitleIncome" style="width: 111px">
                    <strong><span style="font-size: 11pt">
                        <asp:DropDownList ID="ddlscrpatrnsfr" runat="server" AutoPostBack="True" SkinID="ddlSkin"
                            Width="140px" OnSelectedIndexChanged="ddlscrpatrnsfr_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Partial</asp:ListItem>
                            <asp:ListItem>Complete</asp:ListItem>
                        </asp:DropDownList></span></strong></td>
                <td class="reportTitleIncome" style="width: 111px">
                </td>
                <td class="reportTitleIncome" style="width: 111px">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--end by prachi--%>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 628px; background-color: #C5C6D0;">
            <tr>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <strong><span style="font-size: 11pt">&nbsp;<span style="color: #3300ff">Subasset&nbsp;
                        :</span></span></strong></td>
                <td class="reportTitleIncome" style="width: 111px">
                    <strong><span style="font-size: 11pt">Monitor&nbsp;
                        <asp:Label ID="lblmnsubprstatus" runat="server" ForeColor="Blue" Text="Label"></asp:Label></span></strong></td>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 11pt"><strong>&nbsp;Status</strong></span></td>
                <td class="reportTitleIncome" style="width: 107px">
                    &nbsp;<asp:DropDownList ID="ddlmonStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlmonStatus_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="140px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Scrap</asp:ListItem>
                        <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                        <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                        <asp:ListItem>Returned  to Vendor</asp:ListItem>
                        <asp:ListItem>Replace</asp:ListItem>
            </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 26px;">
                    <strong>&nbsp;</strong>SubTransRefNo</td>
                <td class="Info" style="width: 111px; height: 26px;">
                    <asp:Label ID="lblmonitorSubTrans" runat="server" Text="" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
                <td class="reportTitleIncome" style="width: 113px; height: 26px;">
                    Screen<strong> </strong>Type</td>
                <td class="Info" style="width: 106px; height: 26px;">
                    <asp:DropDownList ID="ddlscreentype" runat="server">
                        <asp:ListItem Value="TFT">TFT</asp:ListItem>
                        <asp:ListItem Value="CRT">CRT</asp:ListItem>
                        <asp:ListItem Value="LCD">LCD</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <strong>&nbsp;</strong>Company<strong> </strong>Name</td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <asp:TextBox ID="txtcompnamemonitor" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    Model<strong> </strong>Name</td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="txtmodelnamemonitor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    Cost</td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <asp:TextBox ID="txtmoncost" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    Replacement Date</td>
                <td class="Info" style="width: 106px; height: 23px;">
                    &nbsp;<asp:TextBox ID="txtreplacemntdatemon" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="9" style="height: 31px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 28px;">
                    <strong><span style="font-size: 11pt; color: #3300ff;">Subasset&nbsp; :</span></strong></td>
                <td class="reportTitleIncome" style="width: 111px; height: 28px;">
                    <strong><span style="font-size: 11pt">CPU&nbsp;
                        <asp:Label ID="lblcpuprstatus" runat="server" Text="" ForeColor="Blue"></asp:Label></span></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 28px;">
                    <strong><span style="font-size: 11pt">Status</span></strong></td>
                <td class="reportTitleIncome" style="width: 106px; height: 28px;">
                    <asp:DropDownList ID="ddlcpustatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcpustatus_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="140px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Scrap</asp:ListItem>
                        <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                        <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                        <asp:ListItem>Returned  to Vendor</asp:ListItem>
                        <asp:ListItem>Replace</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    &nbsp;SubTransRefNo</td>
                <td class="Info" style="width: 111px">
                    <asp:Label ID="lblSubTranscpu" runat="server" Text="" Font-Bold="True"></asp:Label></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <strong>&nbsp;</strong>Company<strong> </strong>Name</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtcompnamecpu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 34px;">
                    Model<strong> </strong>Name</td>
                <td class="Info" style="width: 111px; height: 34px;">
                    <strong>
                        <asp:TextBox ID="txtmodelnamecpu" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 34px;">
                    Processor Name</td>
                <td class="Info" style="width: 106px; height: 34px;">
                    <asp:TextBox ID="txtprocnamecpu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <strong>&nbsp;</strong>Processor</td>
                <td class="Info" style="width: 111px">
                    <strong>
                        <asp:TextBox ID="txtprocessorcpu" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    Ram</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtRam" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    Mother Board Make</td>
                <td class="Info" style="width: 111px">
                    <strong>
                        <asp:TextBox ID="txtmothernme" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    Cost</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtcostcpu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                </td>
                <td class="Info" style="width: 111px">
                    <strong></strong>
                </td>
                <td class="reportTitleIncome" style="width: 113px">
                    Replacement Date</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtreplacemntdatecpu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="9" style="height: 31px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <strong><span style="font-size: 11pt; color: #3300ff">Subasset&nbsp; :</span></strong></td>
                <td class="reportTitleIncome" style="width: 111px; height: 23px; font-size: 12pt;">
                    <strong>Hard Disc
                        <asp:Label ID="lblhddprstatus" runat="server" Text="" ForeColor="Blue"></asp:Label></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px; font-size: 12pt;">
                    <strong><span style="font-size: 11pt">Status</span></strong></td>
                <td class="reportTitleIncome" style="width: 106px; height: 23px;">
                    <asp:DropDownList ID="ddlhddstatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlhddstatus_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="140px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Scrap</asp:ListItem>
                        <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                        <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                        <asp:ListItem>Returned  to Vendor</asp:ListItem>
                        <asp:ListItem>Replace</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    &nbsp;SubTransRefNo</td>
                <td class="Info" style="width: 111px">
                    <asp:Label ID="lblSubTranshdd" runat="server" Text="" Font-Bold="True"></asp:Label></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <strong>&nbsp;</strong>Company<strong> </strong>Name</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtcompnamehdd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    &nbsp;Model Name</td>
                <td class="Info" style="width: 111px">
                    <asp:TextBox ID="txtmodelnamehdd" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <span style="background-color: #e1e9ff">Hard Disk Size</span></td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtharddisk" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    &nbsp;Cost</td>
                <td class="Info" style="width: 111px">
                    <asp:TextBox ID="hddcost" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <span style="background-color: #e1e9ff">Hard Disc Type</span></td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="hddtype" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 26px;">
                </td>
                <td class="Info" style="width: 111px; height: 26px;">
                </td>
                <td class="reportTitleIncome" style="width: 113px; height: 26px;">
                    <span style="background-color: #e1e9ff">Replacement Date</span></td>
                <td class="Info" style="width: 106px; height: 26px;">
                    <asp:TextBox ID="txtreplacemntharddiskm" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="9" style="height: 31px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <strong><span style="font-size: 11pt; color: #3300ff">Subasset&nbsp; :</span></strong></td>
                <td class="reportTitleIncome" style="width: 111px; height: 23px;">
                    <strong><span style="font-size: 11pt">Keyboard
                        <asp:Label ID="lblkbprstatus" runat="server" Text="" ForeColor="Blue"></asp:Label></span></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    <strong><span style="font-size: 11pt">Status</span></strong></td>
                <td class="reportTitleIncome" style="width: 106px; height: 23px;">
                    <asp:DropDownList ID="ddlkbstatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlkbstatus_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="140px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Scrap</asp:ListItem>
                        <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                        <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                        <asp:ListItem>Returned  to Vendor</asp:ListItem>
                        <asp:ListItem>Replace</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    SubTransRefNo</td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <strong>
                        <asp:Label ID="lblsubtranskb" runat="server" Text="" Font-Bold="True"></asp:Label></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    Company Name</td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="txtcompnamekb" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    Model Name</td>
                <td class="Info" style="width: 111px">
                    <strong>
                        <asp:TextBox ID="txtmodelnamekb" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    Cost</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtcostkb" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    Keyboard Type</td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <asp:TextBox ID="txtkbtype" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    Replacement Date</td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="9" style="height: 31px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 30px;">
                    <strong><span style="font-size: 11pt; color: #3300ff">Subasset&nbsp; :</span></strong></td>
                <td class="reportTitleIncome" style="width: 111px; height: 30px;">
                    <strong><span style="font-size: 11pt">Mouse
                        <asp:Label ID="lblmsprstatus" runat="server" Text="" ForeColor="Blue"></asp:Label></span></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 30px;">
                    <strong><span style="font-size: 11pt">Status</span></strong></td>
                <td class="reportTitleIncome" style="width: 106px; height: 30px;">
                    <asp:DropDownList ID="ddlsbmouse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsbmouse_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="140px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Scrap</asp:ListItem>
                        <asp:ListItem>Transferred to Other Branch</asp:ListItem>
                        <asp:ListItem>Transferred to other PAMACian</asp:ListItem>
                        <asp:ListItem>Returned  to Vendor</asp:ListItem>
                        <asp:ListItem>Replace</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <span style="font-size: 8pt; color: #000000">SubTransRefNo</span></td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <strong>
                        <asp:Label ID="lblsubtransmouse" runat="server" Text="" Font-Bold="True"></asp:Label></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    <span style="font-size: 8pt">Company Name</span></td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="txtcompnamemouse" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Company Name</span></td>
                <td class="Info" style="width: 111px">
                    <strong>
                        <asp:TextBox ID="txtmodelnamemouse" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    Cost</td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtcostms" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    Mouse Type</td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <asp:TextBox ID="txtmstype" runat="server"></asp:TextBox></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    Replacement Date</td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="txtreplacementdatems" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 111px; height: 33px;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnsave" runat="server" Text="Save" Width="91px" OnClick="btnsave_Click"
                        Style="height: 28px; background-color: #7F7D9C; border: 5px double #ADADC9; text-align: center"
                        BorderColor="#FFC080" Font-Bold="True" Font-Overline="False" ForeColor="Black" /></td>
                <td class="reportTitleIncome" style="width: 113px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 106px; height: 33px;">
                </td>
            </tr>
        </table>
        <%--<table style="width: 628px">
            <tr>
                <td class="reportTitleIncome" style="width: 87px; height: 29px;">
                    <strong><span style="font-size: 8pt; color: #000000">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </span></strong>
                </td>
                <td class="reportTitleIncome" style="width: 119px; height: 29px;">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </strong>
                </td>
                <td class="reportTitleIncome" style="width: 103px; height: 29px;">
                    <strong>&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </strong>
                </td>
                <td class="reportTitleIncome" style="width: 106px; height: 29px;">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>--%>
    </asp:Panel>
    <asp:Panel ID="pnlScrap" runat="server" Visible="false">
        <table style="width: 628px; background-color: #C5C6D0;">
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Scrap /Sold
                        / Return Approved By</span></td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtscrapby" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    <span style="background-color: #e1e9ff">Scrap / Sold &nbsp;&nbsp; &nbsp;Date</span></td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:TextBox ID="txtscrapdate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 47px;">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Amount Received</span></td>
                <td class="Info" style="width: 111px; height: 47px;">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtamt" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 47px;">
                    Vender Name</td>
                <td class="Info" style="width: 106px; height: 47px;">
                    <asp:TextBox ID="txtVendorName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Date Of Approval</span></td>
                <td class="Info" style="width: 111px">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:TextBox ID="txtDateApprvl" runat="server"></asp:TextBox></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                </td>
                <td class="Info" style="width: 106px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 111px; height: 33px;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Save" Width="91px" OnClick="Button1_Click"
                        Style="height: 28px; background-color: #7F7D9C; border: 5px double #ADADC9; text-align: center"
                        BorderColor="#FFC080" Font-Bold="True" Font-Overline="False" ForeColor="Black" /></td>
                <td class="reportTitleIncome" style="width: 113px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 106px; height: 33px;">
                </td>
            </tr>
            <tr>
                <td colspan="9" style="height: 31px">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlTransfer" runat="server" Visible="false">
        <table style="width: 628px; background-color: #C5C6D0;">
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 23px;">
                    <span style="color: #000000; background-color: #e1e9ff;">Cluster name</span></td>
                <td class="Info" style="width: 111px; height: 23px;">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:DropDownList ID="ddlclustername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclustername_SelectedIndexChanged"
                            SkinID="ddlSkin" Width="150px">
                        </asp:DropDownList></strong></td>
                <td class="reportTitleIncome" style="width: 113px; height: 23px;">
                    <span style="background-color: #e1e9ff">Name Of Branch</span></td>
                <td class="Info" style="width: 106px; height: 23px;">
                    <asp:DropDownList ID="ddlCenterList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCenterList_SelectedIndexChanged"
                        SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Sub Centre
                        Name</span></td>
                <td class="Info" style="width: 111px">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:DropDownList ID="ddlsubcentrename" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsubcentrename_SelectedIndexChanged"
                            SkinID="ddlSkin" Width="150px">
                        </asp:DropDownList></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <span style="background-color: #e1e9ff">Approved &nbsp;By</span></td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txttrfApprovby" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Enter Employee
                        Code to Search User</span></td>
                <td class="Info" style="width: 111px">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:TextBox ID="txtsearch2" runat="server" SkinID="txtSkin"></asp:TextBox><asp:Button
                            ID="Btnserachemp" runat="server" Font-Bold="True" ForeColor="Indigo" Height="25px"
                            OnClick="Btnserachemp_Click" SkinID="btn" Text="Search" Width="90px" /></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <span style="background-color: #e1e9ff"></span>
                </td>
                <td class="Info" style="width: 106px">
                </td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px">
                    <span style="font-size: 8pt; color: #000000; background-color: #e1e9ff;">Transfer To
                        Pamacian</span></td>
                <td class="Info" style="width: 111px">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:DropDownList ID="ddlpamaciantransfer" runat="server" OnSelectedIndexChanged="ddlpamaciantransfer_SelectedIndexChanged"
                            SkinID="ddlSkin" Width="150px">
                        </asp:DropDownList><asp:Label ID="Lbltraname" runat="server" Visible="False"></asp:Label></strong></td>
                <td class="reportTitleIncome" style="width: 113px">
                    <span style="background-color: #e1e9ff">Date Of Transfer</span></td>
                <td class="Info" style="width: 106px">
                    <asp:TextBox ID="txtdateofTrasfer" runat="server" SkinID="txtSkin" Width="140px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 107px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 111px; height: 33px;">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btntransfer" runat="server"
                        Text="Transfer" Width="95px" OnClick="btntransfer_Click" Style="height: 28px;
                        background-color: #7F7D9C; border: 5px double #ADADC9; text-align: center" BorderColor="#FFC080"
                        Font-Bold="True" Font-Overline="False" ForeColor="Black" /></td>
                <td class="reportTitleIncome" style="width: 113px; height: 33px;">
                </td>
                <td class="reportTitleIncome" style="width: 106px; height: 33px;">
                </td>
            </tr>
        </table>
        <%--<table style="width: 628px">
            <tr>
                <td class="reportTitleIncome" style="width: 87px">
                    <strong><span style="font-size: 8pt; color: #000000">&nbsp; &nbsp; </span></strong>
                </td>
                <td class="reportTitleIncome" style="width: 109px">
                    <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </strong>
                </td>
                <td class="reportTitleIncome" style="width: 103px">
                    <strong>&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp; </strong>
                </td>
                <td class="reportTitleIncome" style="width: 106px">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>--%>
        <table>
            <tr>
                <td style="width: 107px; height: 16px;">
                    <asp:HiddenField ID="hdnCentre" runat="server" />
                    <asp:HiddenField ID="HdnTransStatus" runat="server" />
                    <asp:HiddenField ID="hdnAssetType" runat="server" />
                    <asp:HiddenField ID="HdnTrsEMPCODE" runat="server" />
                    <asp:HiddenField ID="HdnTransEmpName" runat="server" />
                </td>
                <td style="width: 111px; height: 16px;">
                    &nbsp;
                </td>
                <td style="width: 100px; height: 16px;">
                    <asp:HiddenField ID="hdnSubcentre" runat="server" />
                    <asp:HiddenField ID="hdnTranRefNo" runat="server" />
                    <asp:HiddenField ID="hdnEmpCode" runat="server" />
                    <asp:HiddenField ID="hdnScrapStats" runat="server" />
                    <asp:HiddenField ID="hdnCluster" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnEmpCodeScrap" runat="server"></asp:HiddenField>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
