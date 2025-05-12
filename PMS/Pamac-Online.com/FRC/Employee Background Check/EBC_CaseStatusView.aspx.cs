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

public partial class CPV_EBC_EBC_CaseStatusView : System.Web.UI.Page
{
    CCaseStatusView objCaseStatus = new CCaseStatusView();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void GetSearchCases()
    {
        
        DataTable dt = new DataTable();
        dt = objCaseStatus.EBCGetSearch_New();
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
        Session["caseID"] = txtCaseID.Text.Trim().ToString();
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

        Label lblRAV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRAV");
        Label lblEBC = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblEBC");
        Label lblEMV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblEMV");
        Label lblCRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblCRV");
        Label lblCCV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblCCV");
        Label lblCRCV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblCRCV");
        Label lblRef_Chk = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblRef_Chk");
        Label lblKYC = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblKYC");

        Label lblSlashRAV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRAV");
        Label lblSlashEBC = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashEBC");
        Label lblSlashEMV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashEMV");
        Label lblSlashCRV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashCRV");
        Label lblSlashCCV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashCCV");
        Label lblSlashCRCV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashCRCV");
        Label lblSlashRef_Chk = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashRef_Chk");
        Label lblSlashKYC = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashKYC");

        string verificationType = code;
        switch (code)
        {
            case "RAV":
                string str = "EBC_AddressVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=43&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRAV.Text = "<A href='#' onClick=winOpen('" + str + "')>RAV</A>";
                lblRAV.Visible = true;
                lblSlashRAV.Visible = true;
                break;

            case "EBC":
                string str1 = "EBC_New_Educational_Check.aspx?CaseID=" + caseID + "&VerificationTypeID=44&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblEBC.Text = "<A href='#' onClick=winOpen('" + str1 + "')>EBC</A>";
                lblEBC.Visible = true;
                lblSlashEBC.Visible = true;
                break;

            case "EMV":
                string str2 = "EBC_New_Employment_Verification.aspx?CaseID=" + caseID + "&VerificationTypeID=45&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblEMV.Text = "<A href='#' onClick=winOpen('" + str2 + "')>EMV</A>";
                lblEMV.Visible = true;
                lblSlashEMV.Visible = true;
                break;

            case "CRV":
                string str3 = "EBC_CriminalVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=46&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblCRV.Text = "<A href='#' onClick=winOpen('" + str3 + "')>CRV</>";
                lblCRV.Visible = true;
                lblSlashCRV.Visible = true;
                break;

            case "CCV":
                string str4 = "EBC_CourtLitigationCheck.aspx?CaseID=" + caseID + "&VerificationTypeID=47&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblCCV.Text = "<A href='#' onClick=winOpen('" + str4 + "')>CCV</A>";
                lblCCV.Visible = true;
                lblSlashCCV.Visible = true;
                break;

            case "CRCV":
                string str5 = "EBC_CreditCheckVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=48&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblCRCV.Text = "<A href='#' onClick=winOpen('" + str5 + "')>CRCV</A>";
                lblCRCV.Visible = true;
                lblSlashCRCV.Visible = true;
                break;

            case "Ref_Chk":
                string str6 = "EBC_ReferenceCheck.aspx?CaseID=" + caseID + "&VerificationTypeID=49&SubVerificationTypeId=0&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblRef_Chk.Text = "<A href='#' onClick=winOpen('" + str6 + "')>Ref_Chk</A>";
                lblRef_Chk.Visible = true;
                lblSlashRef_Chk.Visible = true;
                break;

            case "KYC":
                string str7 = "EBC_KYC_CaseStatusView.aspx?CaseID=" + caseID + "&VerificationTypeID=52&VerificationTypeCode=" + verificationTypeCode + "&Name=" + txtApplicantName.Text.Trim().ToString() + "&RefNO=" + txtRefNo.Text.Trim().ToString() + "&Mode=View";
                lblKYC.Text = "<A href='#' onClick=winOpen('" + str7 + "')>KYC</A>";
                lblKYC.Visible = true;
                lblSlashKYC.Visible = true;
                break;
        }

    }
    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        PropertySet();
        GetSearchCases();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }
}
