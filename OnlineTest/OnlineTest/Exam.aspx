<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineTestMasterPage.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="OnlineTest.Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <asp:Label ID="lblTimer" runat="server"></asp:Label>

    <asp:Panel ID="CounterPanel" runat="server">
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="Label3" runat="server" Text="Time Elapsed in Seconds" Font-Bold="true" Font-Size="Medium"></asp:Label>
                </td>
                <td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtCounter" runat="server" Enabled="false" Font-Bold="true" Font-Size="Medium"></asp:TextBox>
                            <asp:Timer ID="timer1" runat="server" Interval="1000" Enabled="False">
                            </asp:Timer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>



    <table>
        <tr>
            <td>
                <asp:Label ID="lblMsgXls" runat="server" SkinID="lblError" Font-Bold="True" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <%--  <tr>
            <td>
                <asp:Label ID="lblVertical" runat="server" Text="Select vertical :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlVertical" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblPriority" runat="server" Text="Select Priority :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <%-- <td>
                <asp:Label ID="lblClient" runat="server" Text="Select Client :"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlClient" runat="server"></asp:DropDownList>
            </td>--%>

            <%-- <td>        <td class="TableTitle"><strong><span style="font-size: small">Select Question paper</span></strong></td>--%>


            <td class="TableTitle"><strong><span style="font-size: small">Select Question paper</span></strong></td>
            </td>
            <td>
                <asp:DropDownList ID="ddlQuestionpaperList" runat="server" OnSelectedIndexChanged="ddlQuestionpaperList_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="TableTitle"><strong><span style="font-size: small">Total No.of Qns</span></strong></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtTotalNoQns" runat="server" Width="48px"></asp:TextBox>

            </td>
            <td class="TableTitle"><strong><span style="font-size: small">Total Marks</span></strong></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtTotalMarks" runat="server" Width="48px"></asp:TextBox>

            </td>
            <td class="TableTitle"><strong><span style="font-size: small">Duration HH:mm</span></strong></td>
            <td class="TableGrid">
                <asp:TextBox ID="txtDuration" runat="server" Width="48px" Text="00:00" ></asp:TextBox>
            </td>

        </tr>


        <tr>
            <td>
                <asp:Button ID="btnStart" runat="server" Text="Start Exam"
                    OnClick="btnStart_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
              
                <asp:HiddenField ID="hdnTotalTime" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 298px">
                <table>
                        <tr>
                            <td>
                                <b>
                                 <%--   <asp:Label ID="lblQuestion" runat="server"></asp:Label></b>--%>
           <asp:TextBox ID="txtque" runat="server" TextMode="MultiLine" Width="900" Enabled="false" Font-Size="X-Large"></asp:TextBox>
            
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblAnswer" runat="server"></asp:Label></b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblMarks" runat="server"></asp:Label></b>
                            </td>
                   </table>

   <asp:Panel ID="Pnloptions" runat="server">
        <table>
                <td class="TableHeader" colspan="4" style="font-size: small; text-decoration: underline"><strong>Options:</strong></td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 1:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="txtoption1" runat="server"  Width="348px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="width:130px"><strong><span style="font-size:small">Option 2:</span></strong>&nbsp;</td>
                <td class="TableGrid">
                    <asp:TextBox ID="txtoption2" runat="server" Width="348px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 3:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="txtoption3" runat="server" Width="348px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 4:</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="txtoption4" runat="server" Width="348px"></asp:TextBox>
                </td>

            </table>
    </asp:Panel>
    


        <asp:Panel ID="PnlCheckBox" runat="server">
               <table>
              
                 <td td class="TableGrid" style="width: 130px"><strong><span style="font-size: small">Option 1</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtChans1" runat="server" Width="348px"></asp:TextBox>
                </td>
                <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 2</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtChans2" runat="server" Width="348px"></asp:TextBox>
                </td>
                <tr>
                  <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 3</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtChans3" runat="server" Width="348px"></asp:TextBox>
                </td>
                <td td class="TableTitle" style="width: 130px"><strong><span style="font-size: small">Option 4</span></strong></td>
                <td class="TableGrid">
                    <asp:TextBox ID="TxtChans4" runat="server" Width="348px"></asp:TextBox>
                </td>
                </tr>
         </table>


        </asp:Panel>
                

           <asp:panel ID="PnlCorrectAns1" runat="server">
        <table>
         
        <td class="TableTitle" colspan="1"><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
        <td class="TableGrid" colspan="1"><%--<asp:TextBox ID="txtanswer" runat="server" Width="348px"></asp:TextBox>--%>
            <asp:DropDownList ID="DDlAns" runat="server" Width="442px">
            </asp:DropDownList>
        </td>
        </table>
        </asp:panel>

        <asp:panel ID="PnlCorrectAns2" runat="server">
          <table>

        <td class="TableTitle" colspan="1"><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
        <td class="TableGrid" colspan="1">
            
            <asp:DropDownList ID="DDlAns2" runat="server">
                <asp:ListItem Value="0"     Text="--Select--"></asp:ListItem>
                <asp:ListItem Value="True"  Text="True"></asp:ListItem>
                <asp:ListItem Value="False" Text="False"></asp:ListItem>
            </asp:DropDownList>
        </td>
               </table>
        </asp:panel>
        <asp:panel ID="PnlCorrectAns3" runat="server">
        <table>
            <td class="TableGrid" ><strong><span style="font-size: small">Correct Answer :</span></strong> </td>
     
      <td>
            <asp:CheckBoxList ID="chklistoptions" runat="server">  
                 <asp:ListItem Text="Option1">Option 1</asp:ListItem>  
                <asp:ListItem Text="Option2">Option 2</asp:ListItem>  
                <asp:ListItem Text="Option3">Option 3</asp:ListItem>  
                <asp:ListItem Text="Option4">Option 4</asp:ListItem>
           </asp:CheckBoxList> 
      </td>
        </table>
        </asp:panel>

            <asp:Panel ID="pnlQuestion" runat="server" Width="410px">
                    <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdboption" runat="server" Width="403px">

                                        <asp:ListItem Value="Option 1"></asp:ListItem>
                                        <asp:ListItem Value="Option 2"></asp:ListItem>
                                        <asp:ListItem Value="Option 3"></asp:ListItem>
                                        <asp:ListItem Value="Option 4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                </tr>  

                    </table>         
               
             </asp:Panel>
    <asp:Panel ID="Panelbuttons" runat="server" Width="410px">
                     <table>
                         <tr>
                            <td>
                                <asp:Button ID="btnprevious" runat="server" Text="<<Previous"
                                    OnClick="btnprevious_Click" />&nbsp;&nbsp;<asp:Button ID="btnNext"
                                        runat="server" Text="Next>>" OnClick="btnNext_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnEndExam" runat="server" OnClick="btnEndExam_Click" Text="End Exam" />
                                
                            </td>
                        </tr>
              </table>
           </asp:Panel>
                  
                
         <asp:Panel ID="Panelresults" runat="server" Width="410px">   
        <table>
        <tr>
            <td class="TableHeader" style="width: 354px">
                <b>RESULTS
                </b>
            </td>
        </tr>

        <tr>
            <td style="width: 354px">
                <asp:GridView ID="grdresults" runat="server" AutoGenerateColumns="true" Visible="true" 
                    CssClass="mGrid" Width="711px" Height="37px">
                </asp:GridView>
            </td>
        </tr>
        <asp:HiddenField ID="HdnPLtimer" runat="server" Value="30" />
        <asp:HiddenField ID="hdnserno" runat="server" />
        <asp:HiddenField ID="hdnqnid" runat="server" />
        <asp:HiddenField ID="hdnstartdate" runat="server" />
        <asp:HiddenField ID="hdnqntype" runat="server" />
        
    </table>
             </asp:Panel>
</asp:Content>
