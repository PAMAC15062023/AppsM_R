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

public partial class FRC_Employee_Background_Check_EBC_KYC_CaseStatusView : System.Web.UI.Page
{
    CCaseStatusView objCaseStatus = new CCaseStatusView();
    protected void Page_Load(object sender, EventArgs e)
    {
        objCaseStatus.CaseID = Session["caseID"].ToString();
        objCaseStatus.CentreID = Session["CentreId"].ToString();
        objCaseStatus.ClientID = Session["ClientId"].ToString();
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != null && Context.Request.QueryString["VerificationTypeID"] != "" )
            {
                hdnCaseID.Value = Context.Request.QueryString["CaseID"];
                hdnName.Value = Context.Request.QueryString["Name"];
                hdnRefNo.Value = Context.Request.QueryString["RefNO"];

                GetSearchCases();
            }
        }
    }

    private void GetSearchCases()
    {

        //DataTable dt = new DataTable();
        ////string CentreId = Session["CentreId"].ToString();
        ////string ClientId = Session["ClientId"].ToString();
        //dt = objCaseStatus.EBCGetSearch_KYC();

      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "GetFRC_KYC_CaseStatusView";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseID = new SqlParameter();
        CaseID.SqlDbType = SqlDbType.VarChar;
        CaseID.ParameterName = "@Case_id";
        CaseID.Value = hdnCaseID.Value;
        sqlcmd.Parameters.Add(CaseID);

        SqlParameter Name_OF_Holder = new SqlParameter();
        Name_OF_Holder.SqlDbType = SqlDbType.VarChar;
        Name_OF_Holder.ParameterName = "@Name_OF_Holder";
        Name_OF_Holder.Value = hdnName.Value;//objCaseStatus.ApplicantName;
        sqlcmd.Parameters.Add(Name_OF_Holder);

        SqlParameter Ref_No = new SqlParameter();
        Ref_No.SqlDbType = SqlDbType.VarChar;
        Ref_No.ParameterName = "@Ref_No";
        Ref_No.Value = hdnRefNo.Value;//objCaseStatus.RefNO;
        sqlcmd.Parameters.Add(Ref_No);

        SqlParameter CENTRE_ID = new SqlParameter();
        CENTRE_ID.SqlDbType = SqlDbType.VarChar;
        CENTRE_ID.ParameterName = "@CENTRE_ID";
        CENTRE_ID.Value = objCaseStatus.CentreID;
        sqlcmd.Parameters.Add(CENTRE_ID);

        SqlParameter CLIENT_ID = new SqlParameter();
        CLIENT_ID.SqlDbType = SqlDbType.VarChar;
        CLIENT_ID.ParameterName = "@CLIENT_ID";
        CLIENT_ID.Value = objCaseStatus.ClientID;
        sqlcmd.Parameters.Add(CLIENT_ID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

     
        if (dt.Rows.Count > 0)
        {
            gvCaseStatusView.DataSource = dt;
            gvCaseStatusView.DataBind();
            gvCaseStatusView.Visible = true;
        }
        else
        {
            gvCaseStatusView.Visible = false;
            lblmsg.Text = "Records not found!";

        }
    }

    private struct GridPosition
    {
        public const int CASEID = 0;
        public const int REFNO = 1;
        public const int APPLICANTNAME = 2;
        public const int SUBVERIFICATIONTYPE = 3;
        public const int SELECTSUBVERIFICATIONTYPE = 4;
        


    }
    private void MatchSUBVERIFICATIONTYPE(GridViewRow gvRow, string SUBVERIFICATIONTYPECode, string caseID)
    {

        Label lblVI = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblVI");
        Label lblPP = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblPP");
        Label lblPC = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblPC");
        Label lblDLV = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblDLV");
        Label lblGDS = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblGDS");

        Label lblSlashVI = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblSlashVI");
        Label lblSlashPP = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblSlashPP");
        Label lblSlashPC = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblSlashPC");
        Label lblSlashDLV = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblSlashDLV");
        Label lblSlashGDS = (Label)gvRow.Cells[GridPosition.SELECTSUBVERIFICATIONTYPE].FindControl("lblSlashGDS");

        string verificationTypeCode = SUBVERIFICATIONTYPECode;
        switch (SUBVERIFICATIONTYPECode)
        {
            case "VI":
                string str7 = "EBC_VoterIDVerifaction.aspx?CaseID=" + caseID + "&VerificationTypeID=52&SubVerificationTypeId=24&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblVI.Text = "<A href='#' onClick=winOpen('" + str7 + "')>VI</A>";
                lblVI.Visible = true;
                lblSlashVI.Visible = true;
                break;

            case "PP":
                string str8 = "EBC_PassportVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=52&SubVerificationTypeId=25&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPP.Text = "<A href='#' onClick=winOpen('" + str8 + "')>PP</A>";
                lblPP.Visible = true;
                lblSlashPP.Visible = true;
                break;

            case "PC":
                string str9 = "EBC_PancardVerification.aspx?CaseID=" + caseID + "&VerificationTypeID=52&SubVerificationTypeId=26&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblPC.Text = "<A href='#' onClick=winOpen('" + str9 + "')>PC</A>";
                lblPC.Visible = true;
                lblSlashPC.Visible = true;
                break;

            case "DLV":
                string str10 = "EBC_DrivingLicense_Verification.aspx?CaseID=" + caseID + "&VerificationTypeID=52&SubVerificationTypeId=27&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblDLV.Text = "<A href='#' onClick=winOpen('" + str10 + "')>DLV</A>";
                lblDLV.Visible = true;
                lblSlashPC.Visible = true;
                break;

            case "GDS":
                string str11 = "EBC_GlobalDatabaseSearch.aspx?CaseID=" + caseID + "&VerificationTypeID=52&SubVerificationTypeId=28&VerificationTypeCode=" + verificationTypeCode + "&Mode=View";
                lblGDS.Text = "<A href='#' onClick=winOpen('" + str11 + "')>GDS</A>";
                lblGDS.Visible = true;
                lblSlashGDS.Visible = true;
                break;

        }

    }

    protected void gvCaseStatusView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in gvCaseStatusView.Rows)
        {
            string veriCode = row.Cells[GridPosition.SUBVERIFICATIONTYPE].Text;
            string strCaseID = row.Cells[GridPosition.CASEID].Text;

            for (Int32 rowTypeCount = 0; rowTypeCount < gvCaseStatusView.Rows.Count; rowTypeCount++)
            {
                GridViewRow gvRow = gvCaseStatusView.Rows[rowTypeCount];

                //string[] arrSUBVERIFICATIONTYPECode = veriCode.Split('+');
                //for (int i = 0; i < arrSUBVERIFICATIONTYPECode.Length; i++)
                //{
                //    if (arrSUBVERIFICATIONTYPECode[i].Length > 0)
                //    {

                MatchSUBVERIFICATIONTYPE(row, veriCode, strCaseID);

                //    }

                //}
            }

        }
    }
    protected void gvCaseStatusView_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvCaseStatusView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCaseStatusView.PageIndex = e.NewPageIndex;
        GetSearchCases();
    }
    protected void gvCaseStatusView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
