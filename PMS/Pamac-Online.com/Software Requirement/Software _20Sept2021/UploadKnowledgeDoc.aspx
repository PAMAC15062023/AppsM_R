<%@ Page Language="C#" MasterPageFile="~/Software Requirement/Software/MasterPage.master" AutoEventWireup="true" CodeFile="UploadKnowledgeDoc.aspx.cs" Inherits="Software_Requirement_Software_UploadKnowledgeDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">


    <script language="javascript" type="text/javascript">

        function ValidateAddNew() {
            debugger
            var txttopic = document.getElementById("<%=txtTopic.ClientID%>").value;
            var id = document.getElementById("<%=hdnFileID.ClientID%>").value;
            var file = document.getElementById("<%=fuUpload.ClientID%>").value;

            if (id == "0" && txttopic == "") {
                alert("Please enter topic");
                return false;
            }

            if (file == "") {
                alert("Please select file");
                return false;
            }
            else {
                var fileExt = file.split('.').pop();
                if (fileExt.toUpperCase() != "PDF") {
                    alert("Please select pdf file only");
                    return false;
                }
            }


        }

    </script>


    <table style="width: 100%">
        <tr>
            <td class="TableGrid" colspan="9" style="height: 22px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span
                style="font-size: medium"> <span style="color: #FF0000">Upload Knowledge Documents </span>
            </span></strong>
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <asp:Button ID="btnNew" runat="server" Text="New File" OnClick="btnNew_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEdit" runat="server" Text="Edit File" OnClick="btnEdit_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 22px" align="right">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
            </td>
        </tr>

        <tr id="NewFile" runat="server">
            <td>Topic :
                <asp:TextBox ID="txtTopic" runat="server" autocomplete="off"></asp:TextBox>
                Select File To Upload :
    <asp:FileUpload ID="fuUpload" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClientClick="return ValidateAddNew();" OnClick="btnUpload_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td>
        </tr>

        <tr id="EditFile" runat="server">
            <td colspan="9">
                <asp:GridView ID="grdlos" runat="server" CssClass="mGrid" Height="40px" Width="1000px" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="true" OnCheckedChanged="chkbox_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Topic" HeaderText="Topic" />
                        <asp:BoundField DataField="FileName" HeaderText="FileName" />
                        <asp:BoundField DataField="CreateDate" HeaderText="Upload Date" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>

        <tr>
            <td>
                <asp:HiddenField ID="hdnFileID" runat="server" Value="0" />
                &nbsp;
            </td>
        </tr>

    </table>

</asp:Content>
