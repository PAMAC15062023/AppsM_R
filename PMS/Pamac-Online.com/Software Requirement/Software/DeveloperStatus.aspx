<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master" AutoEventWireup="true" CodeFile="DeveloperStatus.aspx.cs" Inherits="Software_Requirement_Software_DeveloperStatus" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../popcalendar.js"></script>
    <script type="text/javascript">
        function check() {
            debugger;
            var a = document.getElementById('ctl00_C1_txttechnicalproblm').value;
            var b = document.getElementById('ctl00_C1_txtlRemark').value;
            if (a == '' && b == '') {
                alert('Please fill atleast one TextBox From Technical Problem and Remark');
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function funValidateFromToDate() {
            debugger;

            //   
            //    //===split and fill into array
            var arFromDate = strFromDate.split('/');
            var arToDate = strToDate.split('/');

            //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
            var strNewFromDate = arFromDate[1] + "/" + arFromDate[0] + "/" + arFromDate[2];
            var strNewToDate = arToDate[1] + "/" + arToDate[0] + "/" + arToDate[2];

            //==Converting the string to date format
            dtFromDate = new Date(strNewFromDate);
            dtToDate = new Date(strNewToDate);

            //declareing the date variable
            date1 = new Date();
            date2 = new Date();
            diff = new Date();
            //setTime 
            date1.setTime(dtFromDate.getTime());
            date2.setTime(dtToDate.getTime());
            var add_one_day = date2.getTime() + (1000 * 60 * 60 * 24);
            diff.setTime(Math.floor(add_one_day - date1.getTime()));
            var dateDiff = diff.getTime();

            if (parseInt(dateDiff) <= 0) {
                alert("To Date should not be less then From Date");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <%--<asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" ForeColor="Red"></asp:Label>--%>
  <asp:Panel ID="Panel1" runat="server" Height="900px">  
    <table style="width: 748px">
        <tr>
            <td colspan="4" class="tta">
                Software Requirement&nbsp; Developer Status</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg" ForeColor="Red"></asp:Label></td>
        </tr>
        <%--<tr style="color: #000000; font-family: Tahoma">
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                <strong>Cluster Name</strong></td>
            <td style="width: 181px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlcluster" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcluster_SelectedIndexChanged"
                    SkinID="ddlSkin" ValidationGroup="grpSearch" Width="150px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 20px;" class="reportTitleIncome">
                <strong>Centre Name</strong></td>
            <td style="width: 100px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged"
                    SkinID="ddlSkin" Width="150px" ValidationGroup="grpSearch">
                </asp:DropDownList></td>
            <td style="width: 98px; height: 20px;" class="reportTitleIncome">
                <strong>Subcentre Name</strong></td>
            <td style="width: 94px; height: 20px;" class="Info">
                <asp:DropDownList ID="ddlsubcentre" runat="server"
                    SkinID="ddlSkin" Width="150px">
                </asp:DropDownList></td>
        </tr>--%>
        <tr>
            <td class="reportTitleIncome" style="width: 100px; height: 19px">
                <strong>
                From Date</strong></td>
           <td class="Info" style="width: 181px; height: 19px">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch" 
                    Width="75px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td class="reportTitleIncome" style="width: 100px; height: 19px">
                <strong>To Date</strong></td>
           <td class="Info" style="width: 100px; height: 19px">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"  ValidationGroup="grpSearch" 
                    Width="74px"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <%--<td style="width: 98px; height: 19px" class="reportTitleIncome">
                &nbsp; <strong>
                AssignedTo
                &nbsp;&nbsp;&nbsp; </strong>
                </td>
            <td style="width: 94px; height: 19px" class="Info">
                &nbsp;<asp:DropDownList ID="ddldevlopername" runat="server"
                    SkinID="ddlSkin" Width="150px"  >
                    
                </asp:DropDownList></td>--%>
        </tr>
        <tr>
             <td class="reportTitleIncome" style="width: 100px; height: 19px">
                <strong> Status </strong></td>
            <td class="Info" style="width: 100px; height: 19px">
                <asp:DropDownList ID="ddloverallremark" runat="server" SkinID="ddlSkin" Width="150px">
                    <asp:ListItem>--ALL--</asp:ListItem>
                    <asp:ListItem>InProgress</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Sent For UAT</asp:ListItem>
                    <asp:ListItem>Closed</asp:ListItem>
                    <asp:ListItem>ReAssigned</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 21px;" colspan="4">
                <asp:Button ID="Btnsearch" runat="server" Height="23px"  SkinID="btn"
                    Text="Search" Width="121px"  ValidationGroup="grpSearch" OnClick="Btnsearch_Click1" />&nbsp;
                <asp:Button ID="BtnReset" runat="server" Height="23px"  SkinID="btn"
                    Text="Reset" Width="121px" /></td>
        </tr>
        <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort" Width="650px" OnRowCommand="GrdView_RowCommand"> 
                            <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("TicketNo") %>'
                                            CommandName="Edit1"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>



                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
        </table>
            </asp:Panel>
    <%--<asp:Panel ID="Panel12" runat="server" Height="900px">
      <table>
            <tr>
                <td colspan="6" style="height: 178px">                  
                    <asp:GridView ID="GrdView" runat="server" SkinID="gridviewNoSort" Width="650px" OnRowCommand="GrdView_RowCommand"> 
                            <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("TicketNo") %>'
                                            CommandName="Edit1"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>



                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
              </td>
            </tr>
        </table>
    </asp:Panel>--%>

    <asp:Panel ID="Panel2" runat="server" Width="907px">



        <table>
            <tr>
                <td class="tta" colspan="8">Software Status &nbsp;Details</td>

            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="Label1" runat="server" SkinID="lblError" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 249px; height: 30px;" class="reportTitleIncome">
                    <strong>Employee Code</strong></td>
                <td class="Info" colspan="3" style="height: 30px">
                    <asp:Label ID="lblEmpCode" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 30px;"></td>
                <asp:Label ID="lblTikectNo" runat="server" Text="Tikect No" Font-Bold="True"></asp:Label><td style="width: 100px; height: 30px;"></td>
                <td style="width: 100px; height: 30px;"></td>
                <td style="width: 100px; height: 30px;"></td>
            </tr>
            <tr>
                <td style="width: 249px; height: 22px;" class="reportTitleIncome">
                    <strong>First Name</strong></td>
                <td style="width: 234px; height: 22px;" class="Info">&nbsp;<asp:Label ID="lblFrstName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Last Name</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblLastName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 22px;">
                    <strong>Centre Name</strong></td>
                <td class="Info" style="width: 234px; height: 22px;">
                    <asp:Label ID="LblCentreName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 22px;" class="reportTitleIncome">
                    <strong>Subcentre Name</strong></td>
                <td style="width: 278px; height: 22px;" class="Info">
                    <asp:Label ID="lblSubcentreName" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
                <td style="width: 100px; height: 22px;"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px">
                    <strong>Vertical</strong></td>
                <td class="Info" style="width: 234px">
                    <asp:Label ID="Lblvertical" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px" class="reportTitleIncome">
                    <strong>Approver</strong></td>
                <td style="width: 278px" class="Info">
                    <asp:Label ID="lblverticalhead" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Request Date</strong></td>
                <td class="Info" style="width: 234px; height: 23px">
                    <asp:Label ID="lblreqest" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 214px; height: 23px" class="reportTitleIncome">
                    <strong>To be required till date</strong></td>
                <td style="width: 278px; height: 23px" class="Info">
                    <asp:Label ID="lblRequestedDate" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>New Requirement/Error</strong></td>
                <td class="Info" style="height: 23px" colspan="3">
                    <asp:Label ID="lblreqtype" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Application</strong></td>
                <td class="Info" colspan="1" style="height: 23px">
                    <asp:Label ID="lblApplication" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>

                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Estimated Development Time</strong></td>
                <td class="Info" colspan="1" style="height: 23px">
                    <asp:Label ID="lblEstimatedDevelopmentTime" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Priority</strong></td>
                <td class="Info" colspan="1" style="height: 23px">
                    <asp:Label ID="lblpriority" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Actual Spent Time</strong></td>
                <td class="Info" colspan="1" style="height: 23px">
                    <asp:Label ID="lblActualSpentTime" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Requirement</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lblrequirement" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Implemented At</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lblimplementedat" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <%--<tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Assignment Related Task :</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lbltask1" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Client Added Related Task :</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lbltask5" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Password&nbsp; Related Task :</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lbltask2" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Domain Related Task :</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lbltask3" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 23px">
                    <strong>Autoreply Related task</strong></td>
                <td class="Info" colspan="3" style="height: 23px">
                    <asp:Label ID="lbltask4" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
                <td style="width: 100px; height: 23px"></td>
            </tr>--%>

            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 25px">
                    <p class="MsoNormal" style="margin: 0in 0in 0pt">
                        <font color="#000080"><span style="font-size: 8pt; width: 430px; color: black; height: 21px">
                            <strong>Technical
                Problem / issues in the Application</strong></span></font>
                    </p>
                </td>
                <td colspan="3" style="height: 25px" class="Info">&nbsp;<asp:TextBox ID="txttechnicalproblm" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="450px" Enabled="false"></asp:TextBox></td>
                <td style="width: 100px; height: 25px"></td>
                <td style="width: 100px; height: 25px"></td>
                <td style="width: 100px; height: 25px"></td>
                <td style="width: 100px; height: 25px"></td>
            </tr>
            <tr>
                <td style="width: 249px; height: 21px;" class="reportTitleIncome">
                    <span style="font-size: 8pt; color: #000000; font-family: Tahoma; background-color: #e1e9ff;">
                        <strong>Requirement/Remark</strong></span></td>
                <td colspan="3" style="height: 21px" class="Info">
                    <br />
                    <%--<asp:Label ID="lblremark" runat="server" Text="Label" ></asp:Label>--%>
                    <asp:TextBox ID="txtlRemark" runat="server" Height="50px" SkinID="txtSkin" TextMode="MultiLine"
                        Width="450px" Enabled="false"></asp:TextBox></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Root Cause</strong></td>
                <td class="Info" colspan="3" style="height: 21px">
                    <asp:TextBox ID="txtrootcause" runat="server" SkinID="txtSkin" TextMode="multiLine" Width="448px" Enabled="false"></asp:TextBox></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Developer Remark</strong></td>
                <td class="Info" colspan="3" style="height: 21px">
                    <asp:TextBox ID="txtDeveloperremark" runat="server" SkinID="txtSkin" TextMode="multiLine" Width="447px" Enabled="false"></asp:TextBox></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <%--<td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Overall Remark</strong></td>
                <td class="Info" colspan="3" style="height: 21px">--%>
                    <%-- <asp:TextBox ID="Txtoverallremark" runat="server" SkinID="txtSkin"  TextMode="multiLine" Width="444px"></asp:TextBox>--%>
                    <%--<asp:DropDownList ID="ddloverallremark" runat="server" Enabled="false">
                        <asp:ListItem Text="Pending" Value="Pending" />
                        <asp:ListItem Text="InProgress" Value="InProgress" />
                        <asp:ListItem Text="Sought For More Clarification" Value="Sought For More Clarification" />
                        <asp:ListItem Text="Sent For UAT" Value="Sent For UAT" />
                        <asp:ListItem Text="UAT Completed" Value="UAT Completed" />
                        <asp:ListItem Text="Resolved" Value="Resolved" />
                        <asp:ListItem Text="On Hold" Value="On Hold" />
                        <asp:ListItem Text="Closed" Value="Closed" />
                    </asp:DropDownList>--%>

                </td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Attachment Download</strong></td>
                <td class="Info" colspan="3" style="height: 21px">
                    <asp:GridView ID="gvAttachment" runat="server" SkinID="gridviewNoSort" Width="650px" AutoGenerateColumns="false" OnRowCommand="gvAttachment_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" runat="server" CommandArgument='<%# Eval("ID") %>'
                                        CommandName="Download1">Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr id="FU" runat="server" visible="false">
                <td class="reportTitleIncome" style="width: 249px; height: 21px">
                    <strong>Output Attachment</strong></td>
                <td class="Info" colspan="3" style="height: 21px">
                    <asp:FileUpload ID="FileUpload1" runat="server" SkinID="flup" Width="290px" /></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr id="TRgrddwld" runat="server" visible="false">
                <td class="reportTitleIncome" colspan="4" style="height: 21px">
                    <asp:GridView ID="Grddwld" runat="server" SkinID="gridviewNoSort" Width="650px"
                        AutoGenerateColumns="false" OnRowDataBound="Grddwld_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Attachment_1" HeaderText="Attachment1" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Attachment1")%>'
                                        OnClick="lnkdownload_Click" CommandName="download"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Attachment_2" HeaderText="Attachment2" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Attachment2")%>'
                                        OnClick="lnkdownload2_Click" CommandName="download"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Attachment_3" HeaderText="Attachment3" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload3" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Attachment3")%>'
                                        OnClick="lnkdownload3_Click" CommandName="download"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
                <td style="width: 100px; height: 21px"></td>
            </tr>
            <tr>
                <td style="height: 21px;" class="Info" colspan="4" align="center">
                    <center>
                        <asp:Button ID="BtnActionSave" runat="server" Text="Submit" SkinID="btn" Width="100px" OnClick="BtnActionSave_Click1"
                            OnClientClick="return check()" Visible="false" />
                        &nbsp; &nbsp;<asp:Button ID="btnBack" runat="server" SkinID="btnBackSkin" Text="Back" Width="100px" />
                        &nbsp; &nbsp;<asp:Button ID="BtnReset12" runat="server" Text="Reset" SkinID="btn" Width="100px"
                            OnClick="BtnReset12_Click" Visible="false" /></center>
                </td>
                <td style="width: 100px; height: 21px;">&nbsp;</td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
                <td style="width: 100px; height: 21px;"></td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;  
                    <asp:HiddenField ID="hdnApproveto" runat="server" />
                    <asp:HiddenField ID="HDNUPDATE" runat="server" />
                    <asp:HiddenField ID="HdnUID" runat="server" />
                    <asp:HiddenField ID="hdnAttachmentID" runat="server" />
                    <asp:HiddenField ID="hdncluster" runat="server" />
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>


    </asp:Panel>



    <%--
<asp:RequiredFieldValidator ID="reqValFromDate" runat="server" ControlToValidate="txtFromDate"
                Display="None" ErrorMessage="Please enter From Date." SetFocusOnError="True"
                ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
             <asp:RequiredFieldValidator ID="reqValToDate" runat="server" ControlToValidate="txtTodate" Display="None"
                    ErrorMessage="Please enter To Date." SetFocusOnError="True" ValidationGroup="grpSearch"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revFromDateSearch" runat="server" ControlToValidate="txtFromDate" Display="None"
                        ErrorMessage="Please enter valid date Format for From Date." SetFocusOnError="True"
                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                        ValidationGroup="grpSearch"></asp:RegularExpressionValidator>
              <asp:RegularExpressionValidator ID="revToDateSearch" runat="server" ControlToValidate="txtToDate" Display="None"
                            ErrorMessage="Please enter valid date format To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpSearch"></asp:RegularExpressionValidator>--%>



    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="grpSearch" />

</asp:Content>

