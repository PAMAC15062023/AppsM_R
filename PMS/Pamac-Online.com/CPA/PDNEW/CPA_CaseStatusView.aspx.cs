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
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class CPA_PD_CPA_CaseStatusView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            validationControl();
        }
       
    }

    private void validationControl()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return validationControl();");
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchData();
    }

   
    private void SearchData()
    {


        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_GetCaseStatusView";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlcmd.Parameters.Add(CentreID);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtCaseReceivedDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtTodate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = Convert.ToInt32(Session["ClientID"]);
            ClientID.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientID);

            SqlParameter CASE_ID = new SqlParameter();
            CASE_ID.SqlDbType = SqlDbType.VarChar;
            CASE_ID.Value = txtCase_ID.Text.Trim();
            CASE_ID.ParameterName = "@CASE_ID";
            sqlcmd.Parameters.Add(CASE_ID);

            SqlParameter Ref_No = new SqlParameter();
            Ref_No.SqlDbType = SqlDbType.VarChar;
            Ref_No.Value = txtRef_No.Text.Trim();
            Ref_No.ParameterName = "@Ref_No";
            sqlcmd.Parameters.Add(Ref_No);

            SqlParameter ApplicantName = new SqlParameter();
            ApplicantName.SqlDbType = SqlDbType.VarChar;
            ApplicantName.Value = txtApplicant_Name.Text.Trim();
            ApplicantName.ParameterName = "@ApplicantName";
            sqlcmd.Parameters.Add(ApplicantName);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                gvCaseStatusView.DataSource = dt;
                gvCaseStatusView.DataBind();
            }
            else
            {
                lblMessage.Text = "Record not Found....!!!!";
                gvCaseStatusView.DataSource = null;
                gvCaseStatusView.DataBind();
            }
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int REFNO = 1;
        public const int APPLICANTNAME = 2;
        public const int VERIFICATIONTYPE = 3;
        public const int SELECTVERIFICATIONTYPE = 4;


    }

    private void MatchVerificationType(string code, GridViewRow gvRow, string verificationTypeCode, string caseID)
    {

        Label lblOSVV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblOSVV");
        Label lblOSTV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblOSTV");

        Label lblSlashOSVV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashOSVV");
        Label lblSlashOSTV = (Label)gvRow.Cells[GridPosition.SELECTVERIFICATIONTYPE].FindControl("lblSlashOSTV");
       
        string verificationType = code;
        switch (code)
        {
            case "OSVV":
                string str = "CPA_OriginalSeenVisitVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=50&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblOSVV.Text = "<A href='#' onClick=winOpen('" + str + "')>OSVV</A>";
                lblOSVV.Visible = true;
                lblSlashOSVV.Visible = true;
                break;

            case "OSTV":
                string str1 = "CPA_OriginalSeen_Tele_Verification.aspx?CaseID=" + caseID + "&VerificationTypeID=51&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblOSTV.Text = "<A href='#' onClick=winOpen('" + str1 + "')>OSTV</A>";
                lblOSTV.Visible = true;
                lblSlashOSTV.Visible = true;
                break;


        }//// 

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

    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        SearchData();
    }
    protected void gvCaseStatusView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvCaseStatusView_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
}
