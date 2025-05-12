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

public partial class EBC_New_EBC_New_EBC_CreditCheckVerification : System.Web.UI.Page
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
                
                    VeificationMaster();
                    CreditMainDataDetails();
                    SaveValidation();
            }
        }
    }
    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");
    }
    private void CreditMainDataDetails()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_MainDataDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseID = new SqlParameter();
        CaseID.SqlDbType = SqlDbType.VarChar;
        CaseID.ParameterName = "@CaseID";
        CaseID.Value = hdnCaseID.Value;  
        sqlcmd.Parameters.Add(CaseID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtEmpFname.Text = dt.Rows[0]["First_name"].ToString().Trim();
            txtEmpMname.Text = dt.Rows[0]["Middle_name"].ToString().Trim();
            txtEmpLname.Text = dt.Rows[0]["Last_Name"].ToString().Trim();
            txtRefNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
            txtRcvdDate.Text = dt.Rows[0]["RcvdDate"].ToString().Trim();
            txtFatFname.Text = dt.Rows[0]["Father_name"].ToString().Trim();
            txtDOB.Text = dt.Rows[0]["dob"].ToString().Trim();
        }
    }

    private void VeificationMaster()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_AllAddressSubVeriType";
        SqlDataAdapter sqlda = new SqlDataAdapter();

        SqlParameter CaseID = new SqlParameter();
        CaseID.SqlDbType = SqlDbType.VarChar;
        CaseID.Value = hdnCaseID.Value;
        CaseID.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseID);

        SqlParameter VeriId = new SqlParameter();
        VeriId.SqlDbType = SqlDbType.Int;
        VeriId.Value = hdnMainVerifyID.Value;  
        VeriId.ParameterName = "@VeriId";
        sqlcmd.Parameters.Add(VeriId);

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlSubVeriType.DataTextField = "Verification_Description";
        ddlSubVeriType.DataValueField = "sub_verification_type_id";
        ddlSubVeriType.DataSource = dt;
        ddlSubVeriType.DataBind();

        ddlSubVeriType.Items.Insert(0, "-Select-");
        ddlSubVeriType.SelectedIndex = 0;

    }

    private void ClearData()
    {
        ddlSubVeriType.SelectedIndex = 0;
        txtAddress.Text = "";
        txtPanNo.Text = ""; 
        txtCibil.Text = "";
        txtFeName.Text = "";
        txtRemark.Text = "";        
        txtSuperName.Text = "";
        txtVeriDate.Text = "";
        txtVeriTime.Text = "";
        ddlCrimRecord.SelectedIndex = 0;
        ddlVeriStat.SelectedIndex = 0;
        ddlDefaulter.SelectedIndex = 0; 

    }

    private void GetCreditVeriData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_CreditCheckVeriDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
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
            SubVerificationTypeID.Value = ddlSubVeriType.SelectedValue;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtCibil.Text = dt.Rows[0]["Cibil_Score"].ToString().Trim();
                ddlDefaulter.SelectedValue = dt.Rows[0]["Defaulter"].ToString().Trim();
                ddlCrimRecord.SelectedValue = dt.Rows[0]["Record_Found"].ToString().Trim();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
                ddlVeriStat.SelectedValue = dt.Rows[0]["Overall_Verification"].ToString().Trim();
                txtVeriDate.Text = dt.Rows[0]["Date_of_Verification"].ToString().Trim();
                txtVeriTime.Text = dt.Rows[0]["Time_of_Verification"].ToString().Trim();
                txtFeName.Text = dt.Rows[0]["FE_Name"].ToString().Trim();
                txtSuperName.Text = dt.Rows[0]["Supervisor_Name"].ToString().Trim();
                txtAddress.Text = dt.Rows[0]["Verification_Address"].ToString().Trim();
                txtPanNo.Text = dt.Rows[0]["PanNo"].ToString().Trim();

                string SendDate = "";
                SendDate = dt.Rows[0]["Send_Datetime"].ToString().Trim();
                if (SendDate != "")
                {
                    btnSave.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveCreditVeriData();
        IsCaseComplete();
        ClearData();
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

        SqlParameter MessageNO = new SqlParameter();
        MessageNO.SqlDbType = SqlDbType.VarChar;
        MessageNO.Value = "";
        MessageNO.ParameterName = "@MessageNO";
        sqlcmd.Parameters.Add(MessageNO);

        sqlcmd.ExecuteNonQuery();
        sqlcon.Close();
    }


    private void SaveCreditVeriData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_InsertCreditVerificationData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
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
            SubVerificationTypeID.Value = ddlSubVeriType.SelectedValue;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlParameter Defaulter = new SqlParameter();
            Defaulter.SqlDbType = SqlDbType.VarChar;
            Defaulter.ParameterName = "@Defaulter";
            Defaulter.Value = ddlDefaulter.Text.Trim();
            sqlcmd.Parameters.Add(Defaulter);

            SqlParameter Cibil_Score = new SqlParameter();
            Cibil_Score.SqlDbType = SqlDbType.VarChar;
            Cibil_Score.ParameterName = "@Cibil_Score";
            Cibil_Score.Value = txtCibil.Text.Trim();
            sqlcmd.Parameters.Add(Cibil_Score);

            SqlParameter Record_Found = new SqlParameter();
            Record_Found.SqlDbType = SqlDbType.VarChar;
            Record_Found.ParameterName = "@Record_Found";
            Record_Found.Value = ddlCrimRecord.Text.Trim();
            sqlcmd.Parameters.Add(Record_Found);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemark.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter Overall_Verification = new SqlParameter();
            Overall_Verification.SqlDbType = SqlDbType.VarChar;
            Overall_Verification.ParameterName = "@Overall_Verification";
            Overall_Verification.Value = ddlVeriStat.Text.Trim();
            sqlcmd.Parameters.Add(Overall_Verification);

            SqlParameter Date_of_Verification = new SqlParameter();
            Date_of_Verification.SqlDbType = SqlDbType.VarChar;
            Date_of_Verification.ParameterName = "@Date_of_Verification";
            Date_of_Verification.Value = txtVeriDate.Text.Trim();
            sqlcmd.Parameters.Add(Date_of_Verification);

            SqlParameter Time_of_Verification = new SqlParameter();
            Time_of_Verification.SqlDbType = SqlDbType.VarChar;
            Time_of_Verification.ParameterName = "@Time_of_Verification";
            Time_of_Verification.Value = txtVeriTime.Text.Trim();
            sqlcmd.Parameters.Add(Time_of_Verification);

            SqlParameter FE_Name = new SqlParameter();
            FE_Name.SqlDbType = SqlDbType.VarChar;
            FE_Name.ParameterName = "@FE_Name";
            FE_Name.Value = txtFeName.Text.Trim();
            sqlcmd.Parameters.Add(FE_Name);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            Supervisor_Name.Value = txtSuperName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisor_Name);

            Array newFileUpload1 = null;
            if (FileUpload1.FileBytes.Length > 0)
            {
                newFileUpload1 = FileUpload1.FileBytes;
            }

            SqlParameter UploadImg = new SqlParameter();
            UploadImg.SqlDbType = SqlDbType.Binary;
            UploadImg.ParameterName = "@UploadImg";
            UploadImg.Value = newFileUpload1;
            sqlcmd.Parameters.Add(UploadImg);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Record Save Successfuly";

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_New_VerificationView.aspx");  
    }
    protected void ddlSubVeriType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlSubVeriType.SelectedIndex != 0)
        {
            GetCreditVeriData();
        }
    }
}
