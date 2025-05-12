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

public partial class CPV_RL_RL_CaseStatusView : System.Web.UI.Page
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
        dt = objCaseStatus.RLGetSearch();
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
        public const int APPTYPE = 4;
        public const int SELECTVERIFICATIONTYPE = 5;
        

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
        Label lblREF1 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblREF1");
        Label lblREF2 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblREF2");
        Label lblRCO = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRCO");
        Label lblNoc = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblNoc");
        Label lblVend = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblVend");
        Label lblITVR = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblITVR");
        Label lblSS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSS");
        Label lblPV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblPV");
        Label lblBS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblBS");

        Label lblSlashRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRV");
        Label lblSlashBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBV");
        Label lblSlashRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRT");
        Label lblSlashBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBT");
        Label lblSlashPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPRV");
        Label lblSlashREF1 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashREF1");
        Label lblSlashREF2 = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashREF2");
        Label lblSlashRCO = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRCO");
        Label lblSlashNoc = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashNoc");
        Label lblSlashVend = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashVend");
        Label lblSlashITVR = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashITVR");
        Label lblSlashSS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashSS");
        Label lblSlashPV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPV");
        Label lblSlashBS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBS");
       
        string verificationType = code;
        
        switch (code)
        {
            case "RV":
                string str = "RL_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href='#' onClick=winOpen('" + str + "')>RV</A>";
                lblRV.Visible = true;
                lblSlashRV.Visible = true;
                break;
            case "BV":
                string str1 = "RL_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>BV</A>";
                lblBV.Visible = true;
                lblSlashBV.Visible = true;
                break;

            case "RT":
                string str2 = "RL_ResidenceTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href='#' onClick=winOpen('"+ str2 + "')>RT</A>";
                lblRT.Visible = true;
                lblSlashRT.Visible = true;
                break;
            case "BT":
                string str3 = "RL_BusinessTelephonicVerification.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href='#' onClick=winOpen('" + str3 + "')>BT</>";
                lblBT.Visible = true;
                lblSlashBT.Visible = true;
                break;

            case "PRV":
                string str4 = "RL_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=10&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>PRV</A>";
                lblPRV.Visible = true;
                lblSlashPRV.Visible = true;
                break;

            case "REF1":
                string str5 = "RL_REF1Verification.aspx?CaseID=" + caseID + "&VerTypeId=12&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblREF1.Text = "<A href='#' onClick=winOpen('" + str5 + "')>REF1</A>";
                lblREF1.Visible = true;
                lblSlashREF1.Visible = true;
                break;

            case "REF2":
                string str6 = "RL_REF2Verification.aspx?CaseID=" + caseID + "&VerTypeId=13&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblREF2.Text = "<A href='#' onClick=winOpen('" + str6 + "')>REF2</A>";
                lblREF2.Visible = true;
                lblSlashREF2.Visible = true;
                break;

            case "RCO":
                string str7 = "RL_ResiCumBusiness.aspx?CaseID=" + caseID + "&VerTypeId=14&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRCO.Text = "<A href='#' onClick=winOpen('" + str7 + "')>RCO</A>";
                lblRCO.Visible = true;
                lblSlashRCO.Visible = true;
                break;

            case "Noc":
                string str8 = "RL_ResidenceVerification_Noc.aspx?CaseID=" + caseID + "&VerTypeId=32&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblNoc.Text = "<A href='#' onClick=winOpen('" + str8 + "')>Noc</A>";
                lblNoc.Visible = true;
                lblSlashNoc.Visible = true;
                break;

            case "Vend":
                string str9 = "RL_ResidenceVerification_Vend.aspx?CaseID=" + caseID + "&VerTypeId=31&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblVend.Text = "<A href='#' onClick=winOpen('" + str9 + "')>Vend</A>";
                lblVend.Visible = true;
                lblSlashVend.Visible = true;
                break;

            case "ITVR":
                string str10 = "RL_ITR.aspx?CaseID=" + caseID + "&VerTypeId=34&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblITVR.Text = "<A href='#' onClick=winOpen('" + str10 + "')>ITVR</A>";
                lblITVR.Visible = true;
                lblSlashITVR.Visible = true;
                break;

            case "SS":
                string str11 = "RL_SalarySlipVerification.aspx?CaseID=" + caseID + "&VerTypeId=35&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblSS.Text = "<A href='#' onClick=winOpen('" + str11 + "')>SS</A>";
                lblSS.Visible = true;
                lblSlashSS.Visible = true;
                break;

            case "PV":
                string str12 = "RL_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=36&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPV.Text = "<A href='#' onClick=winOpen('" + str12 + "')>PV</A>";
                lblPV.Visible = true;
                lblSlashPV.Visible = true;
                break;

            case "BS":
                string str13 = "RL_BankStatementVerification.aspx?CaseID=" + caseID + "&VerTypeId=42&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBS.Text = "<A href='#' onClick=winOpen('" + str13 + "')>BS</A>";
                lblBS.Visible = true;
                lblSlashBS.Visible = true;
                break;

        }

    }
    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        PropertySet();
        GetSearchCases();
    }
}

