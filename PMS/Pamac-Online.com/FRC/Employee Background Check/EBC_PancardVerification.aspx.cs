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

public partial class FRC_Employee_Background_Check_EBC_PancardVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != null && Context.Request.QueryString["VerificationTypeID"] != "" && Context.Request.QueryString["SubVerificationTypeId"] != null && Context.Request.QueryString["SubVerificationTypeId"] != "")
            {
                hdnCaseID.Value = Context.Request.QueryString["CaseID"];
                hdnMainVerifyID.Value = Context.Request.QueryString["VerificationTypeID"];
                hdnSubVerifyTypeID.Value = Context.Request.QueryString["SubVerificationTypeId"];

                if (Context.Request.QueryString["Mode"] == "View")
                {

                    btnSave.Enabled = false;
                }
                  Get_PancardDetails();
            }
            
        }
    }
    private void Get_PancardDetails()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_PancardVerificationDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.Int;
            CaseID.ParameterName = "@CaseID";
            CaseID.Value = hdnCaseID.Value;  
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = hdnMainVerifyID.Value;  
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter SubVerificationTypeID = new SqlParameter();
            SubVerificationTypeID.SqlDbType = SqlDbType.Int;
            SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
            SubVerificationTypeID.Value = hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //txtEmpFname.Text = dt.Rows[0]["E_name"].ToString().Trim();
                // txtEmpMname.Text = dt.Rows[0]["E_name"].ToString().Trim() ;
                // txtEmpLname.Text= dt.Rows[0]["E_name"].ToString().Trim();
                txtBankRefNo.Text = dt.Rows[0]["BankRefNo"].ToString().Trim();
                txtCPArefNo.Text = dt.Rows[0]["CPArefNo"].ToString().Trim();
                txtDate.Text = dt.Rows[0]["Date_Of_Recipt"].ToString().Trim();
                txtDateTime.Text = dt.Rows[0]["Date_of_Visit"].ToString().Trim();
                txtName.Text = dt.Rows[0]["Holder_Name"].ToString().Trim();
                txtNameVerifier.Text = dt.Rows[0]["Verifiers_Name"].ToString().Trim();
                txtObservation.Text = dt.Rows[0]["Observation"].ToString().Trim();
                txtPANno.Text = dt.Rows[0]["Pancard_No"].ToString().Trim();
                txtRecord.Text = dt.Rows[0]["OkCase_as_per_record"].ToString().Trim();
                txtRemarks.Text = dt.Rows[0]["Remark"].ToString().Trim();
                txtSName.Text = dt.Rows[0]["Supervisors_Name"].ToString().Trim();
                txtStatus.Text = dt.Rows[0]["status"].ToString().Trim();
                ddlchk10digits.SelectedValue = dt.Rows[0]["DigitsChk"].ToString().Trim();
                ddlChkdigit4.SelectedValue = dt.Rows[0]["ChkDigit4"].ToString().Trim();
                ddlChkdigit6789.SelectedValue = dt.Rows[0]["ChkDigit6789"].ToString().Trim();
                ddlDOBMatch.SelectedValue = dt.Rows[0]["DOB_Match"].ToString().Trim();
                ddlIsAlphanum.SelectedValue = dt.Rows[0]["AlphanumDigit10"].ToString().Trim();
                ddlNameMatch.SelectedValue = dt.Rows[0]["Name_Match"].ToString().Trim();
                ddlPANcorrectness.SelectedValue = dt.Rows[0]["PANcorrectness"].ToString().Trim();
                ddlPanNoMAtch.SelectedValue = dt.Rows[0]["PanNoMatch"].ToString().Trim();
                ddlPanVerify.SelectedValue = dt.Rows[0]["PanDetailsVerified"].ToString().Trim();
                ddlRealtionMatch.SelectedValue = dt.Rows[0]["Relation_Match"].ToString().Trim();

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_InsertPancardVerificationData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.Int;
            CaseID.ParameterName = "@CaseID";
            CaseID.Value = hdnCaseID.Value;
            sqlcmd.Parameters.Add(CaseID);


            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = hdnMainVerifyID.Value;
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter SubVerificationTypeID = new SqlParameter();
            SubVerificationTypeID.SqlDbType = SqlDbType.Int;
            SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
            SubVerificationTypeID.Value = hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            //SqlParameter Employee_Name = new SqlParameter();
            //Employee_Name.SqlDbType = SqlDbType.VarChar;
            //Employee_Name.ParameterName = "@E_name";
            //Employee_Name.Value = txtEmpFname.Text.Trim() + " " + txtEmpMname.Text.Trim() + " " + txtEmpLname.Text.Trim();
            //sqlcmd.Parameters.Add(Employee_Name);

            SqlParameter Date_Of_Recipt = new SqlParameter();
            Date_Of_Recipt.SqlDbType = SqlDbType.VarChar;
            Date_Of_Recipt.ParameterName = "@Date_Of_Recipt";
            Date_Of_Recipt.Value = txtDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_Of_Recipt);

            SqlParameter CPArefNo = new SqlParameter();
            CPArefNo.SqlDbType = SqlDbType.VarChar;
            CPArefNo.ParameterName = "@CPArefNo";
            CPArefNo.Value = txtCPArefNo.Text.Trim();
            sqlcmd.Parameters.Add(CPArefNo);

            SqlParameter BankRefNo = new SqlParameter();
            BankRefNo.SqlDbType = SqlDbType.VarChar;
            BankRefNo.ParameterName = "@BankRefNo";
            BankRefNo.Value = txtBankRefNo.Text.Trim();
            sqlcmd.Parameters.Add(BankRefNo);

            SqlParameter Pancard_No = new SqlParameter();
            Pancard_No.SqlDbType = SqlDbType.VarChar;
            Pancard_No.ParameterName = "@Pancard_No";
            Pancard_No.Value = txtPANno.Text.Trim();
            sqlcmd.Parameters.Add(Pancard_No);

            SqlParameter Holder_Name = new SqlParameter();
            Holder_Name.SqlDbType = SqlDbType.VarChar;
            Holder_Name.ParameterName = "@Holder_Name";
            Holder_Name.Value = txtName.Text.Trim();
            sqlcmd.Parameters.Add(Holder_Name);

            SqlParameter PANcorrectness = new SqlParameter();
            PANcorrectness.SqlDbType = SqlDbType.VarChar;
            PANcorrectness.ParameterName = "@PANcorrectness";
            PANcorrectness.Value = ddlPANcorrectness.SelectedValue;
            sqlcmd.Parameters.Add(PANcorrectness);

            SqlParameter DigitsChk = new SqlParameter();
            DigitsChk.SqlDbType = SqlDbType.VarChar;
            DigitsChk.ParameterName = "@DigitsChk";
            DigitsChk.Value = ddlchk10digits.SelectedValue;
            sqlcmd.Parameters.Add(DigitsChk);

            SqlParameter AlphanumDigit10 = new SqlParameter();
            AlphanumDigit10.SqlDbType = SqlDbType.VarChar;
            AlphanumDigit10.ParameterName = "@AlphanumDigit10";
            AlphanumDigit10.Value = ddlchk10digits.SelectedValue;
            sqlcmd.Parameters.Add(AlphanumDigit10);

            SqlParameter ChkDigit6789 = new SqlParameter();
            ChkDigit6789.SqlDbType = SqlDbType.VarChar;
            ChkDigit6789.ParameterName = "@ChkDigit6789";
            ChkDigit6789.Value = ddlChkdigit6789.SelectedValue;
            sqlcmd.Parameters.Add(ChkDigit6789);

            SqlParameter ChkDigit4 = new SqlParameter();
            ChkDigit4.SqlDbType = SqlDbType.VarChar;
            ChkDigit4.ParameterName = "@ChkDigit4";
            ChkDigit4.Value = ddlChkdigit4.SelectedValue;
            sqlcmd.Parameters.Add(ChkDigit4);

            SqlParameter Observation = new SqlParameter();
            Observation.SqlDbType = SqlDbType.VarChar;
            Observation.ParameterName = "@Observation";
            Observation.Value = txtObservation.Text.Trim();
            sqlcmd.Parameters.Add(Observation);

            SqlParameter PanDetailsVerified = new SqlParameter();
            PanDetailsVerified.SqlDbType = SqlDbType.VarChar;
            PanDetailsVerified.ParameterName = "@PanDetailsVerified";
            PanDetailsVerified.Value = ddlPanVerify.SelectedValue;
            sqlcmd.Parameters.Add(PanDetailsVerified);

            SqlParameter PanNoMatch = new SqlParameter();
            PanNoMatch.SqlDbType = SqlDbType.VarChar;
            PanNoMatch.ParameterName = "@PanNoMatch";
            PanNoMatch.Value = ddlPanNoMAtch.SelectedValue;
            sqlcmd.Parameters.Add(PanNoMatch);

            SqlParameter Name_Match = new SqlParameter();
            Name_Match.SqlDbType = SqlDbType.VarChar;
            Name_Match.ParameterName = "@Name_Match";
            Name_Match.Value = ddlNameMatch.SelectedValue;
            sqlcmd.Parameters.Add(Name_Match);

            SqlParameter Relation_Match = new SqlParameter();
            Relation_Match.SqlDbType = SqlDbType.VarChar;
            Relation_Match.ParameterName = "@Relation_Match";
            Relation_Match.Value = ddlRealtionMatch.SelectedValue;
            sqlcmd.Parameters.Add(Relation_Match);

            SqlParameter DOB_Match = new SqlParameter();
            DOB_Match.SqlDbType = SqlDbType.VarChar;
            DOB_Match.ParameterName = "@DOB_Match";
            DOB_Match.Value = ddlDOBMatch.SelectedValue;
            sqlcmd.Parameters.Add(DOB_Match);

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.ParameterName = "@status";
            status.Value = txtStatus.Text.Trim();
            sqlcmd.Parameters.Add(status);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemarks.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter OkCase_as_per_record = new SqlParameter();
            OkCase_as_per_record.SqlDbType = SqlDbType.VarChar;
            OkCase_as_per_record.ParameterName = "@OkCase_as_per_record";
            OkCase_as_per_record.Value = txtRecord.Text.Trim();
            sqlcmd.Parameters.Add(OkCase_as_per_record);

            SqlParameter Date_of_Visit = new SqlParameter();
            Date_of_Visit.SqlDbType = SqlDbType.VarChar;
            Date_of_Visit.ParameterName = "@Date_of_Visit";
            Date_of_Visit.Value = txtDateTime.Text.Trim();
            sqlcmd.Parameters.Add(Date_of_Visit);

            SqlParameter Supervisors_Name = new SqlParameter();
            Supervisors_Name.SqlDbType = SqlDbType.VarChar;
            Supervisors_Name.ParameterName = "@Supervisors_Name";
            Supervisors_Name.Value = txtSName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisors_Name);

            SqlParameter Verifiers_Name = new SqlParameter();
            Verifiers_Name.SqlDbType = SqlDbType.VarChar;
            Verifiers_Name.ParameterName = "@Verifiers_Name";
            Verifiers_Name.Value = txtNameVerifier.Text.Trim();
            sqlcmd.Parameters.Add(Verifiers_Name);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblmsg.Text = "Record Save Successfuly";

            IsCaseComplete();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void IsCaseComplete()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "spIsEbcVerificationComplete";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CASE_ID = new SqlParameter();
        CASE_ID.SqlDbType = SqlDbType.VarChar;
        CASE_ID.Value = hdnCaseID.Value;
        CASE_ID.ParameterName = "@CASE_ID";
        sqlcmd.Parameters.Add(CASE_ID);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = "";
        VarResult.ParameterName = "@MessageNO";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add(VarResult);

        sqlcmd.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlcmd.Parameters["@MessageNO"].Value);

        if (RowEffected != "")
        {
            lblmsg.Text = RowEffected;
            lblmsg.CssClass = "SuccessMessage";
            lblmsg.Text = RowEffected;
            lblmsg.Visible = true;
        }

        sqlcon.Close();
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_New_VerificationView.aspx", false);  
    }
}