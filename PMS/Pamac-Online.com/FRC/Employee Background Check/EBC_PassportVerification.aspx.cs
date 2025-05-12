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
public partial class FRC_Employee_Background_Check_EBC_PassportVerification : System.Web.UI.Page
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
               Get_PassportDetails();
            }
            
        }
    }
    private void Get_PassportDetails()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_PassportVerificationDetails";
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
               // txtEmpFname.Text = dt.Rows[0]["E_Name"].ToString().Trim();
                txtReceiptDate.Text = dt.Rows[0]["Date_Of_Recipt"].ToString().Trim();
                txtPassNo.Text = dt.Rows[0]["Passport_No"].ToString().Trim();
                txtHolderName.Text = dt.Rows[0]["Holder_Name"].ToString().Trim();
                txtValidity.Text = dt.Rows[0]["Validity_of_Passport"].ToString().Trim();
                ddlCopyMatch.SelectedValue = dt.Rows[0]["Is_copy_of_Passport_clear"].ToString().Trim();
                ddlPassportMatch.SelectedValue = dt.Rows[0]["Passport_Match"].ToString().Trim();
                ddlHolderMatch.SelectedValue = dt.Rows[0]["Name_Match"].ToString().Trim();
                ddlAddressMacth.SelectedValue = dt.Rows[0]["Address_Match"].ToString().Trim();
                ddlValidity.SelectedValue = dt.Rows[0]["Validity_Match"].ToString().Trim();
                ddlStatus.SelectedValue = dt.Rows[0]["status"].ToString().Trim();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
                txtSubDate.Text = dt.Rows[0]["Date_of_Submission"].ToString().Trim();
                txtVerDate.Text = dt.Rows[0]["Date_of_Verification"].ToString().Trim();
                txtSupName.Text = dt.Rows[0]["Supervisors_Name"].ToString().Trim();
                txtVerName.Text = dt.Rows[0]["Verifiers_Name"].ToString().Trim();

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
            sqlcmd.CommandText = "Get_InsertPassportVerificationData";
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

            //SqlParameter E_name = new SqlParameter();
            //E_name.SqlDbType = SqlDbType.VarChar;
            //E_name.ParameterName = "@E_name";
            //E_name.Value = txtEmpFname.Text.Trim() + " " + txtEmpMname.Text.Trim() + " " + txtEmpLname.Text.Trim();
            //sqlcmd.Parameters.Add(E_name);


            SqlParameter Date_Of_Recipt = new SqlParameter();
            Date_Of_Recipt.SqlDbType = SqlDbType.VarChar;
            Date_Of_Recipt.ParameterName = "@Date_Of_Recipt";
            Date_Of_Recipt.Value = txtReceiptDate.Text;
            sqlcmd.Parameters.Add(Date_Of_Recipt);

            SqlParameter Passport_No = new SqlParameter();
            Passport_No.SqlDbType = SqlDbType.VarChar;
            Passport_No.ParameterName = "@Passport_No";
            Passport_No.Value = txtPassNo.Text;
            sqlcmd.Parameters.Add(Passport_No);

            SqlParameter Holder_Name = new SqlParameter();
            Holder_Name.SqlDbType = SqlDbType.VarChar;
            Holder_Name.ParameterName = "@Holder_Name";
            Holder_Name.Value = txtHolderName.Text;
            sqlcmd.Parameters.Add(Holder_Name);

            SqlParameter Validity_of_Passport = new SqlParameter();
            Validity_of_Passport.SqlDbType = SqlDbType.VarChar;
            Validity_of_Passport.ParameterName = "@Validity_of_Passport";
            Validity_of_Passport.Value = txtValidity.Text;
            sqlcmd.Parameters.Add(Validity_of_Passport);

            SqlParameter Is_copy_of_Passport_clear = new SqlParameter();
            Is_copy_of_Passport_clear.SqlDbType = SqlDbType.VarChar;
            Is_copy_of_Passport_clear.ParameterName = "@Is_copy_of_Passport_clear";
            Is_copy_of_Passport_clear.Value = ddlCopyMatch.SelectedValue;
            sqlcmd.Parameters.Add(Is_copy_of_Passport_clear);



            SqlParameter Passport_Match = new SqlParameter();
            Passport_Match.SqlDbType = SqlDbType.VarChar;
            Passport_Match.ParameterName = "@Passport_Match";
            Passport_Match.Value = ddlPassportMatch.SelectedValue;
            sqlcmd.Parameters.Add(Passport_Match);

            SqlParameter Name_Match = new SqlParameter();
            Name_Match.SqlDbType = SqlDbType.VarChar;
            Name_Match.ParameterName = "@Name_Match";
            Name_Match.Value = ddlHolderMatch.SelectedValue;
            sqlcmd.Parameters.Add(Name_Match);

            SqlParameter Address_Match = new SqlParameter();
            Address_Match.SqlDbType = SqlDbType.VarChar;
            Address_Match.ParameterName = "@Address_Match";
            Address_Match.Value = ddlAddressMacth.SelectedValue;
            sqlcmd.Parameters.Add(Address_Match);

            SqlParameter Validity_Match = new SqlParameter();
            Validity_Match.SqlDbType = SqlDbType.VarChar;
            Validity_Match.ParameterName = "@Validity_Match";
            Validity_Match.Value = ddlValidity.SelectedValue;
            sqlcmd.Parameters.Add(Validity_Match);

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.ParameterName = "@status";
            status.Value = ddlStatus.SelectedValue;
            sqlcmd.Parameters.Add(status);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemark.Text;
            sqlcmd.Parameters.Add(Remark);

            SqlParameter Date_of_Submission = new SqlParameter();
            Date_of_Submission.SqlDbType = SqlDbType.VarChar;
            Date_of_Submission.ParameterName = "@Date_of_Submission";
            Date_of_Submission.Value = txtSubDate.Text;
            sqlcmd.Parameters.Add(Date_of_Submission);

            SqlParameter Date_of_Verification = new SqlParameter();
            Date_of_Verification.SqlDbType = SqlDbType.VarChar;
            Date_of_Verification.ParameterName = "@Date_of_Verification";
            Date_of_Verification.Value = txtVerDate.Text;
            sqlcmd.Parameters.Add(Date_of_Verification);

            SqlParameter Supervisors_Name = new SqlParameter();
            Supervisors_Name.SqlDbType = SqlDbType.VarChar;
            Supervisors_Name.ParameterName = "@Supervisors_Name";
            Supervisors_Name.Value = txtSupName.Text;
            sqlcmd.Parameters.Add(Supervisors_Name);

            SqlParameter Verifiers_Name = new SqlParameter();
            Verifiers_Name.SqlDbType = SqlDbType.VarChar;
            Verifiers_Name.ParameterName = "@Verifiers_Name";
            Verifiers_Name.Value = txtVerName.Text;
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
