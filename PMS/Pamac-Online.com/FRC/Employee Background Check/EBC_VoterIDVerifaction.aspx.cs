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
public partial class EBC_VoterIDVerifaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != null && Context.Request.QueryString["VerificationTypeID"] != "" && Context.Request.QueryString["SubVerificationTypeId"] != null && Context.Request.QueryString["SubVerificationTypeId"] != "")
            {
                hdnCaseID.Value = Context.Request.QueryString["CaseID"];
                hdnMainVerifyID.Value =Context.Request.QueryString["VerificationTypeID"];
                hdnSubVerifyTypeID.Value =Context.Request.QueryString["SubVerificationTypeId"];

                if (Context.Request.QueryString["Mode"] == "View")
                {

                    btnSave.Enabled = false;
                }
                Get_VoterIDDetails();
            }
            
        }
    }
        private void Get_VoterIDDetails()
        {
            try
            {
              CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Get_VoterIDVerificationDetails ";
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
                    //txtEmpFname.Text = dt.Rows[0]["E_Name"].ToString().Trim();
                    txtReceiptDate.Text = dt.Rows[0]["Date_Of_Recipt"].ToString().Trim();
                    txtVoterID.Text = dt.Rows[0]["VoterID"].ToString().Trim();
                    txtHolderName.Text= dt.Rows[0]["Name_Of_Holder"].ToString().Trim();
                    txtValidity.Text = dt.Rows[0]["Validity_of_VoterID"].ToString().Trim();
                    ddlVoterIDCopy.SelectedValue = dt.Rows[0]["Is_copy_of_VoterID_clear"].ToString().Trim();
                    ddlVoterIDMatch.SelectedValue = dt.Rows[0]["VoterID_Match"].ToString().Trim();
                    ddlVoterIDName.SelectedValue = dt.Rows[0]["Name_Match"].ToString().Trim();
                    ddlRelationName.SelectedValue = dt.Rows[0]["RelationName_Match"].ToString().Trim();
                    ddlAddress.SelectedValue = dt.Rows[0]["Address_Match"].ToString().Trim();
                    ddlValidity.SelectedValue = dt.Rows[0]["Validity_Match"].ToString().Trim();
                    ddlStatus.SelectedValue = dt.Rows[0]["Status"].ToString().Trim();
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
            sqlcmd.CommandText = "Get_InsertVoterIDVerificationData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.Int;
            CaseID.ParameterName = "@CaseID";
            CaseID.Value =hdnCaseID.Value;
            sqlcmd.Parameters.Add(CaseID);


            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value =hdnMainVerifyID.Value;
            sqlcmd.Parameters.Add(Verification_Type_ID);


            SqlParameter SubVerificationTypeID = new SqlParameter();
            SubVerificationTypeID.SqlDbType = SqlDbType.Int;
            SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
            SubVerificationTypeID.Value =hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            //SqlParameter E_name = new SqlParameter();
            //E_name.SqlDbType = SqlDbType.VarChar;
            //E_name.ParameterName = "@E_name";
            //E_name.Value = txtEmpFname.Text.Trim() + " " + txtEmpMname.Text.Trim() + " " + txtEmpLname.Text.Trim();
            //sqlcmd.Parameters.Add(E_name);

            SqlParameter Date_Of_Recipt = new SqlParameter();
            Date_Of_Recipt.SqlDbType = SqlDbType.VarChar;
            Date_Of_Recipt.ParameterName = "@Date_Of_Recipt";
            Date_Of_Recipt.Value = txtReceiptDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_Of_Recipt);

            SqlParameter VoterID = new SqlParameter();
            VoterID.SqlDbType = SqlDbType.VarChar;
            VoterID.ParameterName = "@VoterID";
            VoterID.Value = txtVoterID.Text.Trim();
            sqlcmd.Parameters.Add(VoterID);

            SqlParameter Name_Of_Holder = new SqlParameter();
            Name_Of_Holder.SqlDbType = SqlDbType.VarChar;
            Name_Of_Holder.ParameterName = "@Name_Of_Holder";
            Name_Of_Holder.Value = txtHolderName.Text.Trim();
            sqlcmd.Parameters.Add(Name_Of_Holder);

            SqlParameter Validity_of_VoterID = new SqlParameter();
            Validity_of_VoterID.SqlDbType = SqlDbType.VarChar;
            Validity_of_VoterID.ParameterName = "@Validity_of_VoterID";
            Validity_of_VoterID.Value = txtVoterID.Text.Trim();
            sqlcmd.Parameters.Add(Validity_of_VoterID);

            SqlParameter Is_copy_of_VoterID_clear = new SqlParameter();
            Is_copy_of_VoterID_clear.SqlDbType = SqlDbType.VarChar;
            Is_copy_of_VoterID_clear.ParameterName = "@Is_copy_of_VoterID_clear";
            Is_copy_of_VoterID_clear.Value = ddlVoterIDCopy.SelectedValue;
            sqlcmd.Parameters.Add(Is_copy_of_VoterID_clear);


            SqlParameter VoterID_Match = new SqlParameter();
            VoterID_Match.SqlDbType = SqlDbType.VarChar;
            VoterID_Match.ParameterName = "@VoterID_Match";
            VoterID_Match.Value = ddlVoterIDMatch.SelectedValue;
            sqlcmd.Parameters.Add(VoterID_Match);

            SqlParameter Name_Match = new SqlParameter();
            Name_Match.SqlDbType = SqlDbType.VarChar;
            Name_Match.ParameterName = "@Name_Match";
            Name_Match.Value = ddlVoterIDName.SelectedValue;
            sqlcmd.Parameters.Add(Name_Match);

            SqlParameter RelationName_Match = new SqlParameter();
            RelationName_Match.SqlDbType = SqlDbType.VarChar;
            RelationName_Match.ParameterName = "@RelationName_Match";
            RelationName_Match.Value = ddlRelationName.SelectedValue;
            sqlcmd.Parameters.Add(RelationName_Match);

            SqlParameter Address_Match = new SqlParameter();
            Address_Match.SqlDbType = SqlDbType.VarChar;
            Address_Match.ParameterName = "@Address_Match";
            Address_Match.Value = ddlAddress.SelectedValue;
            sqlcmd.Parameters.Add(Address_Match);

            SqlParameter Validity_Match = new SqlParameter();
            Validity_Match.SqlDbType = SqlDbType.VarChar;
            Validity_Match.ParameterName = "@Validity_Match";
            Validity_Match.Value = ddlVoterIDMatch.SelectedValue;
            sqlcmd.Parameters.Add(Validity_Match);

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

            SqlParameter Supervisors_Name = new SqlParameter();
            Supervisors_Name.SqlDbType = SqlDbType.VarChar;
            Supervisors_Name.ParameterName = "@Supervisors_Name";
            Supervisors_Name.Value = txtSupName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisors_Name);

            SqlParameter Verifiers_Name = new SqlParameter();
            Verifiers_Name.SqlDbType = SqlDbType.VarChar;
            Verifiers_Name.ParameterName = "@Verifiers_Name";
            Verifiers_Name.Value = txtVerName.Text.Trim();
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

