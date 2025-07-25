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
        dt = objCaseStatus.GetSearch();
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
        Label lblPRTV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblPRTV");
        Label lblSS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSS");
        Label lblMT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblMT");

        Label lblSlashRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRV");
        Label lblSlashBV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBV");
        Label lblSlashRT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRT");
        Label lblSlashBT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashBT");
        Label lblSlashPRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashPRV");
        Label lblSlashSS = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashSS");
        Label lblSlashMT = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashMT");
        string verificationType = code;

        switch (code)
        {
            case "RV":
                string str = "CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=1&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRV.Text = "<A href='#' onClick=winOpen('" + str + "')>RV</A>";
                lblRV.Visible = true;
                lblSlashRV.Visible = true;
                break;
            case "BV":
                string str1 = "CC_BusinessVerification.aspx?CaseID=" + caseID + "&VerTypeId=2&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>BV</A>";
                lblBV.Visible = true;
                lblSlashBV.Visible = true;
                break;

            case "RT":
                string str2 = "CC_ResidenceVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=4&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRT.Text = "<A href='#' onClick=winOpen('"+ str2 + "')>RT</A>";
                lblRT.Visible = true;
                lblSlashRT.Visible = true;
                break;
            case "BT":
                string str3 = "CC_BusinessVerificationTelephonic.aspx?CaseID=" + caseID + "&VerTypeId=3&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblBT.Text = "<A href='#' onClick=winOpen('" + str3 + "')>BT</>";
                lblBT.Visible = true;
                lblSlashBT.Visible = true;
                break;

            case "PRV":
                string str4 = "CC_ResidenceVerification.aspx?CaseID=" + caseID + "&VerTypeId=10&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPRV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>PRV</A>";
                lblPRV.Visible = true;
                lblSlashPRV.Visible = true;
                break;

            case "SS":
                string str5 = "CC_SalarySlipVerification.aspx?CaseID=" + caseID + "&VerTypeId=35&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblSS.Text = "<A href='#' onClick=winOpen('" + str5 + "')>SS</A>";
                lblSS.Visible = true;
                lblSlashSS.Visible = true;
                break;



            case "MT":
                string str6 = "CC_MobileVerification.aspx?CaseID=" + caseID + "&VerTypeId=35&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblMT.Text = "<A href='#' onClick=winOpen('" + str6 + "')>MT</A>";
                lblMT.Visible = true;
                lblSlashMT.Visible = true;
                break;


            case "PRTV":
                lblPRTV.Visible = true;
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
