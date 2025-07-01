<%@ Page Title="" Language="C#" MasterPageFile="~/ENAM_Master.Master" AutoEventWireup="true" CodeBehind="mysample.aspx.cs" Inherits="Pamac_Projects.mysample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
    <link rel="Stylesheet" type="text/css" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" />
  
    <script language="javascript" type="text/javascript">

        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };
        //function DisableBackButton() {
        //    window.history.forward()
        //}
        //DisableBackButton();
        //window.onload = DisableBackButton;
        //window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        //window.onunload = function () { void (0) }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        $(function () {
              $(".datepicker").datepicker({
                  showOn: 'button',
                  buttonImageOnly: true,
                  buttonImage: 'SmallCalendar.gif',
                  dateFormat: 'dd/mm/yy'
                  
              });
            .scroll {
                min - height: 100 %;
                overflow: scroll;
            }
          });
    </script>       
    <link rel="stylesheet" href="MultiSelectDDL/bootstrap-multiselect.css2.css">
    <script src="MultiSelectDDL/bootstrap-multiselect.js2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lst]').multiselect({
                includeSelectAllOption: true
                // maxHeight: 5000;
            });
        });
    </script>
      

   
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100px">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="60%"></asp:Label>
            </td>
           
        </tr>
    </table>
       
     <asp:UpdatePanel ID="pnlArea" runat="server"  >
                <ContentTemplate>
                       <asp:PlaceHolder ID="PlaceholderControls" runat="server">
                       </asp:PlaceHolder> 
                </ContentTemplate>
                
  
       </asp:UpdatePanel>
             
    <tr>   </tr>   <tr>   </tr>   <tr>   </tr>    <tr>   </tr>   <tr>   </tr>   <tr>   </tr>       
    <tr>   </tr>       <tr>   </tr>       <tr>   </tr>      <tr>   </tr>   <tr>   </tr>    <tr>   </tr>   
    <tr>   </tr>       <tr>   </tr>      <tr>   </tr>   <tr>   </tr>       <tr>   </tr>

    <tr>
  <asp:GridView ID="grv1" runat="server"  CssClass="mGrid"  Visible="true" 
      AllowPaging="True" PageSize="20"  onpageindexchanging="grv1_PageIndexChanging">

                <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkWIP" runat="server" Font-Bold="True" OnClick="lnkWIP_Click" >
                                <img src="editing.jpg" /> </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                   </Columns>

                </asp:GridView>
         </tr>
    
   
 
     
</asp:Content>
