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

public partial class FRC_Employee_Background_Check_EBC_DrivingLicense_Verification : System.Web.UI.Page
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
                 Get_DrivingLicenceDetails();
            }
            
        }
        
    }
        private void Get_DrivingLicenceDetails()
        {
        try 
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_DrivingLicenceVerificationDetails";
            sqlcmd.CommandTimeout = 0;
        
            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.Int;
            CaseID.ParameterName = "@CaseID";
            CaseID.Value =hdnCaseID.Value;  
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = hdnMainVerifyID.Value;  
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter SubVerificationTypeID = new SqlParameter();
            SubVerificationTypeID.SqlDbType = SqlDbType.Int;
            SubVerificationTypeID.ParameterName ="@SubVerificationTypeID";
            SubVerificationTypeID.Value =hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //txtEmpFname.Text = dt.Rows[0]["Employee_Name"].ToString().Trim();
               // txtEmpMname.Text = dt.Rows[0]["Employee_Name"].ToString().Trim() ;
               // txtEmpLname.Text= dt.Rows[0]["Employee_Name"].ToString().Trim();
                txtHolderName.Text = dt.Rows[0]["Name_of_Holder"].ToString().Trim();
                txtLicenceNo.Text = dt.Rows[0]["Driving_Licence_No"].ToString().Trim();
                txtReceiptDate.Text = dt.Rows[0]["Date_Of_Recipt"].ToString().Trim();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
                txtSubDate.Text = dt.Rows[0]["Date_of_Submission"].ToString().Trim();
                txtSupName.Text = dt.Rows[0]["Supervisors_name"].ToString().Trim();
                txtValidity.Text = dt.Rows[0]["Validity_of_Licence"].ToString().Trim();
                txtVerDate.Text = dt.Rows[0]["Date_of_Verification"].ToString().Trim();
                txtVerName.Text = dt.Rows[0]["Verifiers_name"].ToString().Trim();
                ddlAddressMatch.SelectedValue = dt.Rows[0]["Address_match"].ToString().Trim();
                ddlClear.SelectedValue = dt.Rows[0]["Is_copy_of_licence_clear"].ToString().Trim();
                ddlLicenceMatch.SelectedValue = dt.Rows[0]["match_with_RTOrecords"].ToString().Trim();
                ddlNameMatch.SelectedValue = dt.Rows[0]["Name_match"].ToString().Trim();
                ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString().Trim();
                ddlValidityMatch.SelectedValue = dt.Rows[0]["Validity_match"].ToString().Trim();
               
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
            sqlcmd.CommandText = "Get_InsertDrivingLicenceVerificationData";
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
            SubVerificationTypeID.Value =hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            //SqlParameter Employee_Name = new SqlParameter();
            //Employee_Name.SqlDbType = SqlDbType.VarChar;
            //Employee_Name.ParameterName = "@E_name";
            //Employee_Name.Value = txtEmpFname.Text.Trim()+" "+txtEmpMname.Text.Trim()+" "+txtEmpLname.Text.Trim();
            //sqlcmd.Parameters.Add(Employee_Name);

            SqlParameter Date_Of_Recipt = new SqlParameter();
            Date_Of_Recipt.SqlDbType = SqlDbType.VarChar;
            Date_Of_Recipt.ParameterName = "@Date_Of_Recipt";
            Date_Of_Recipt.Value = txtReceiptDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_Of_Recipt);

            SqlParameter Driving_Licence_No = new SqlParameter();
            Driving_Licence_No.SqlDbType = SqlDbType.VarChar;
            Driving_Licence_No.ParameterName = "@Driving_Licence_No";
            Driving_Licence_No.Value = txtLicenceNo.Text.Trim();
            sqlcmd.Parameters.Add(Driving_Licence_No);

            SqlParameter Name_Of_Holder = new SqlParameter();
            Name_Of_Holder.SqlDbType = SqlDbType.VarChar;
            Name_Of_Holder.ParameterName = "@Name_Of_Holder";
            Name_Of_Holder.Value = txtHolderName.Text.Trim();
            sqlcmd.Parameters.Add(Name_Of_Holder);

            SqlParameter Validity_of_Licence = new SqlParameter();
            Validity_of_Licence.SqlDbType = SqlDbType.VarChar;
            Validity_of_Licence.ParameterName = "@Validity_of_Licence";
            Validity_of_Licence.Value = txtValidity.Text.Trim();
            sqlcmd.Parameters.Add(Validity_of_Licence);

            SqlParameter Is_copy_of_licence_clear = new SqlParameter();
            Is_copy_of_licence_clear.SqlDbType = SqlDbType.VarChar;
            Is_copy_of_licence_clear.ParameterName = "@Is_copy_of_licence_clear";
            Is_copy_of_licence_clear.Value = ddlClear.SelectedValue;
            sqlcmd.Parameters.Add(Is_copy_of_licence_clear);

            SqlParameter match_with_RTOrecords = new SqlParameter();
            match_with_RTOrecords.SqlDbType = SqlDbType.VarChar;
            match_with_RTOrecords.ParameterName = "@match_with_RTOrecords";
            match_with_RTOrecords.Value = ddlLicenceMatch.SelectedValue;
            sqlcmd.Parameters.Add(match_with_RTOrecords);

            SqlParameter Name_match = new SqlParameter();
            Name_match.SqlDbType = SqlDbType.VarChar;
            Name_match.ParameterName = "@Name_match";
            Name_match.Value = ddlNameMatch.SelectedValue;
            sqlcmd.Parameters.Add(Name_match);

            SqlParameter Address_match = new SqlParameter();
            Address_match.SqlDbType = SqlDbType.VarChar;
            Address_match.ParameterName = "@Address_match";
            Address_match.Value = ddlAddressMatch.SelectedValue;
            sqlcmd.Parameters.Add(Address_match);

            SqlParameter Validity_match = new SqlParameter();
            Validity_match.SqlDbType = SqlDbType.VarChar;
            Validity_match.ParameterName = "@Validity_match";
            Validity_match.Value = ddlValidityMatch.SelectedValue;
            sqlcmd.Parameters.Add(Validity_match);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.ParameterName = "@Status";
            Status.Value = ddlStatus.SelectedValue;
            sqlcmd.Parameters.Add(Status);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemark.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter Date_of_Submission = new SqlParameter();
            Date_of_Submission.SqlDbType = SqlDbType.VarChar;
            Date_of_Submission.ParameterName = "@Date_of_Submission";
            Date_of_Submission.Value = txtSubDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_of_Submission);

            SqlParameter Date_of_Verification = new SqlParameter();
            Date_of_Verification.SqlDbType = SqlDbType.VarChar;
            Date_of_Verification.ParameterName = "@Date_of_Verification";
            Date_of_Verification.Value = txtVerDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_of_Verification);

            SqlParameter Supervisors_name = new SqlParameter();
            Supervisors_name.SqlDbType = SqlDbType.VarChar;
            Supervisors_name.ParameterName = "@Supervisors_name ";
            Supervisors_name.Value = txtSupName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisors_name);

            SqlParameter Verifiers_name = new SqlParameter();
            Verifiers_name.SqlDbType = SqlDbType.VarChar;
            Verifiers_name.ParameterName = "@Verifiers_name";
            Verifiers_name.Value = txtVerName.Text.Trim();
            sqlcmd.Parameters.Add(Verifiers_name);

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
