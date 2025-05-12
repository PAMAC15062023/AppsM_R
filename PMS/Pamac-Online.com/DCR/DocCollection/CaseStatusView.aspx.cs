using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class CPV_CC_CaseStatusView : System.Web.UI.Page
{
    CCaseStatusView objCaseStatus = new CCaseStatusView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }

    }
    private void GetSearchCases()
    {
        
        DataTable dt = new DataTable();
        dt = objCaseStatus.GetSearch_DCR();
        if (dt.Rows.Count > 0)
        {
            gvCaseStatusView.DataSource = dt;
            gvCaseStatusView.DataBind();
            gvCaseStatusView.Visible = true;
        }
        else
        {
            gvCaseStatusView.Visible = false;
            lblMessage.Text = "Records not found!";

        }
    }
    private void PropertySet()
    {
        objCaseStatus.CaseID = txtCaseID.Text.Trim().ToString();
        objCaseStatus.RefNO = txtRefNo.Text.Trim().ToString();
        objCaseStatus.ApplicantName = txtApplicantName.Text.Trim().ToString();
        objCaseStatus.CentreID = Session["CentreId"].ToString();
        objCaseStatus.ClientID = Session["ClientId"].ToString();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        PropertySet();
        GetSearchCases();

    }
    protected void gvCaseStatusView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int REFNO = 1;
        public const int APPLICANTNAME = 2;
        public const int VERIFICATIONTYPE = 3;
        public const int SELECTVERIFICATIONTYPE = 4;
        

    }
    protected void gvCaseStatusView_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void gvCaseStatusView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in gvCaseStatusView.Rows)
        {
            string veriCode = row.Cells[GridPosition.VERIFICATIONTYPE].Text;
            string strCaseID = row.Cells[GridPosition.CASEID].Text;

            for (Int32 rowTypeCount = 0; rowTypeCount < gvCaseStatusView.Rows.Count; rowTypeCount++)
            {
                GridViewRow gvRow = gvCaseStatusView.Rows[rowTypeCount];

                string[] arrVerificationTypeCode = veriCode.Split('+');
                for (int i = 0; i < arrVerificationTypeCode.Length; i++)
                {
                    if (arrVerificationTypeCode[i].Length > 0)
                    {

                        MatchVerificationType(arrVerificationTypeCode[i].ToString(), row, veriCode, strCaseID);
                        
                    }

                }
            }

        }

    }

    private void MatchVerificationType(string code, GridViewRow gvRow, string verificationTypeCode, string caseID)
    {
       
        Label lblRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRV");
        Label lblBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblBV");
        Label lblRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRT");
        Label lblBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblBT");
        Label lblPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblPRV");
        Label lblAegon = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblAegon");
        Label lblMetlife = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblMetlife");
        Label lblMetNor = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblMetNor");
        Label lblMetTopup = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblMetTopup");
        Label lblMetECS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblMetECS");
        Label lblPB = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblPB");
        
        Label lblSlashRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRV");
        Label lblSlashBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBV");
        Label lblSlashRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRT");
        Label lblSlashBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBT");
        Label lblSlashPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPRV");
        Label lblSlashAegon = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashAegon");
        Label lblSlashMetlife = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashMetlife");
        Label lblSlashMetNor = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashMetNor");
        Label lblSlashMetTopup = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashMetTopup");
        Label lblSlashMetECS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashMetECS");
        Label lblSlashPB = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPB");

        string verificationType = code;

        switch (code)
        {
            case "Altc":
                string str = "CC_DCR_ResiVeri.aspx?CaseID=" + caseID + "&VerTypeId=20&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href='#' onClick=winOpen('" + str + "')>Altc</A>";
                lblRV.Visible = true;
                lblSlashRV.Visible = true;
                break;
            case "PM":
                string str1 = "CC_DCR_ResiVeri.aspx?CaseID=" + caseID + "&VerTypeId=21&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>PM</A>";
                lblBV.Visible = true;
                lblSlashBV.Visible = true;
                break;
            case "Alop":
                string str2 = "CC_DCR_ResiVeri.aspx?CaseID=" + caseID + "&VerTypeId=22&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href='#' onClick=winOpen('" + str2 + "')>Alop</A>";
                lblRT.Visible = true;
                lblSlashRT.Visible = true;
                break;
            case "Blop":
                string str3 = "CC_DCR_ResiVeri.aspx?CaseID=" + caseID + "&VerTypeId=23&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href='#' onClick=winOpen('" + str3 + "')>Blop</A>";
                lblBT.Visible = true;
                lblSlashBT.Visible = true;
                break;
            case "Stock":
                string str4 = "CC_DCR_ResiVeri.aspx?CaseID=" + caseID + "&VerTypeId=24&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>Stock</A>";
                lblPRV.Visible = true;
                lblSlashPRV.Visible = true;
                break;
            case "Aegon":
                string str5 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=37&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblAegon.Text = "<A href='#' onClick=winOpen('" + str5 + "')>Aegon</A>";
                lblAegon.Visible = true;
                lblSlashAegon.Visible = true;
                break;
            case "Metlife":
                string str6 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=32&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblMetlife.Text = "<A href='#' onClick=winOpen('" + str6 + "')>Metlife</A>";
                lblMetlife.Visible = true;
                lblSlashMetlife.Visible = true;
                break;
            case "MetNor":
                string str7 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=38&VerificationTypeCode=" + verificationTypeCode + "";
                lblMetNor.Text = "<A href='#' onClick=winOpen('" + str7 + "')>MetNor</A>";
                lblMetNor.Visible = true;
                lblSlashMetNor.Visible = true;
                break;
            case "MetTopup":
                string str8 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=39&VerificationTypeCode=MetTop";
                lblMetTopup.Text = "<A href='#' onClick=winOpen('" + str8 + "')>MetTopup</A>";
                lblMetTopup.Visible = true;
                lblSlashMetTopup.Visible = true;
                break;
            case "MetECS":
                string str9 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=40&VerificationTypeCode=" + verificationTypeCode + "";
                lblMetECS.Text = "<A href='#' onClick=winOpen('" + str9 + "')>MetECS</A>";
                lblMetECS.Visible = true;
                lblSlashMetECS.Visible = true;
                break;
            case "PB":
                string str10 = "CC_DCR_ResiVeri_AegMet.aspx?CaseID=" + caseID + "&VerTypeId=41&VerificationTypeCode=" + verificationTypeCode + "";
                lblPB.Text = "<A href='#' onClick=winOpen('" + str10 + "')>PB</A>";
                lblPB.Visible = true;
                lblSlashPB.Visible = true;
                break;
            ////case "BV":
            ////    string str1 = "CC_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
            ////    lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>BV</A>";
            ////    lblBV.Visible = true;
            ////    lblSlashBV.Visible = true;
            ////    break;

            ////case "RT":
            ////    string str2 = "CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
            ////    lblRT.Text = "<A href='#' onClick=winOpen('"+ str2 + "')>RT</A>";
            ////    lblRT.Visible = true;
            ////    lblSlashRT.Visible = true;
            ////    break;
            ////case "BT":
            ////    string str3 = "CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
            ////    lblBT.Text = "<A href='#' onClick=winOpen('" + str3 + "')>BT</>";
            ////    lblBT.Visible = true;
            ////    lblSlashBT.Visible = true;
            ////    break;

            ////case "PRV":
            ////    string str4 = "CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=10&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
            ////    lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>PRV</A>";
            ////    lblPRV.Visible = true;
            ////    lblSlashPRV.Visible = true;
            ////    break;

            ////case "PRTV":
            ////    lblPRTV.Visible = true;
            ////    break;

        }

    }
    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        PropertySet();
        GetSearchCases();
    }
}
