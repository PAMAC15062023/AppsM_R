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

public partial class EBC_New_EBC_New_EBC_New_Employment_Verification : System.Web.UI.Page
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
                    Get_Employment_Sub_Verification_TypeDetails();
                    Get_Basic_Import_Data();////
                    SaveValidation();
            }
        }
     }

    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");
    }

   
    protected void ddlSubVerificationType_SelectedIndexChanged(object sender, EventArgs e)
    {  
        try
        {
            if(ddlSubVerificationType.SelectedIndex!=0)
            {
                Get_SubType();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Plz Select Sub Verification Type";
                ClearAllField();
            }   
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

        private void Get_SubType()
        {
            try
            {
              CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "EBC_New_Get_Employment_Details";
                sqlcmd.CommandTimeout = 0;

                SqlParameter CaseID = new SqlParameter();
                CaseID.SqlDbType = SqlDbType.VarChar;
                CaseID.Value = hdnCaseID.Value;
                CaseID.ParameterName = "@CaseId";
                sqlcmd.Parameters.Add(CaseID);

                SqlParameter Sub_Verification_Type_ID = new SqlParameter();
                Sub_Verification_Type_ID.SqlDbType = SqlDbType.Int;
                Sub_Verification_Type_ID.Value = ddlSubVerificationType.SelectedItem.Value;
                Sub_Verification_Type_ID.ParameterName = "@SubVerificationTypeID";
                sqlcmd.Parameters.Add(Sub_Verification_Type_ID);

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = sqlcmd;
                DataTable dt = new DataTable();
                DA.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count > 0)
                {
                    Assign_Values_To_SubTextBoxes(dt);
                    //lblMessage.Visible = false;

                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Record Found";
                    ClearAllField();
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;

            }
         }
         
 
    private void Assign_Values_To_SubTextBoxes(DataTable dr)
    {
        txtCompanyName.Text = dr.Rows[0]["Company_Name"].ToString().Trim();
        txtCompanyContact.Text = dr.Rows[0]["Company_Contact_Number"].ToString().Trim();
        txtCompanyAddress.Text = dr.Rows[0]["Company_Address"].ToString().Trim();
        txtRespondentName.Text = dr.Rows[0]["Respondent_Name"].ToString().Trim();
        txtRespondentDesignation.Text = dr.Rows[0]["Respondent_Designation"].ToString().Trim();
        txtRespondentName.Text = dr.Rows[0]["Respondent_Name"].ToString().Trim();
        txtRespondentContactNumber.Text = dr.Rows[0]["Respondent_Contact_Number"].ToString().Trim();
        txtEmployeeDesignation.Text = dr.Rows[0]["Employee_Designation"].ToString().Trim();
        txtLastCTC.Text = dr.Rows[0]["Last_CTC"].ToString().Trim();
        txtPeriodofEmployment.Text = dr.Rows[0]["Period_Of_Employment"].ToString().Trim();
        txtReasonForLeaving.Text = dr.Rows[0]["Reason_for_Leaving"].ToString().Trim();
        txtAnyInterigrityIssue.Text = dr.Rows[0]["Any_Interigrity_Issue"].ToString().Trim();
        txtPerformanceOfTheEmployee.Text = dr.Rows[0]["Performance_of_the_Employee"].ToString().Trim();
        ddlProperReleaving.SelectedValue = dr.Rows[0]["Proper_Releaving"].ToString().Trim();
        txtRemark.Text = dr.Rows[0]["Remark"].ToString().Trim();
        ddlOverallVerification.SelectedValue = dr.Rows[0]["Overall_Verification"].ToString().Trim();
        txtDateOfVerification.Text = dr.Rows[0]["Date_of_Verification"].ToString().Trim();
        txtTimeOfVerification.Text = dr.Rows[0]["Time_of_Verification"].ToString().Trim();
        txtFEName.Text = dr.Rows[0]["FE_Name"].ToString().Trim();
        txtSupervisorName.Text = dr.Rows[0]["Supervisor_Name"].ToString().Trim();

        string SendDate = "";
        SendDate = dr.Rows[0]["Send_Datetime"].ToString().Trim();
        if (SendDate != "")
        {
            btnSave.Enabled = false;
        }

    }

    private void ClearAllField()
    {               
            txtCompanyName.Text ="";
            txtCompanyContact.Text ="";
            txtCompanyAddress.Text = "";
            txtRespondentName.Text ="";
            txtRespondentDesignation.Text ="";
            txtRespondentContactNumber.Text ="";
            txtEmployeeDesignation.Text ="";
            txtLastCTC.Text ="";
            txtPeriodofEmployment.Text ="";
            txtReasonForLeaving.Text ="";
            txtAnyInterigrityIssue.Text ="";
            txtPerformanceOfTheEmployee.Text ="";
            ddlProperReleaving.SelectedIndex = 0;
            txtRemark.Text ="";
            ddlOverallVerification.SelectedIndex = 0;
            txtDateOfVerification.Text ="";
            txtTimeOfVerification.Text ="";
            txtFEName.Text ="";
            txtSupervisorName.Text = "";
    }
    
    private void Get_Employment_Sub_Verification_TypeDetails()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Employment_Sub_Verification_Type";

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;
            CaseID.ParameterName = "@CaseID";
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter VerificationTypeID = new SqlParameter();
            VerificationTypeID.SqlDbType = SqlDbType.VarChar;
            VerificationTypeID.Value = hdnMainVerifyID.Value;
            VerificationTypeID.ParameterName = "@VerificationTypeID";
            sqlcmd.Parameters.Add(VerificationTypeID);

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            DA.Fill(dt);
            sqlcon.Close();

            ddlSubVerificationType.DataTextField = "Verification_Description";
            ddlSubVerificationType.DataValueField = "Sub_Verification_Type_ID";

            ddlSubVerificationType.DataSource = dt;
            ddlSubVerificationType.DataBind();

            ddlSubVerificationType.Items.Insert(0, "-Select");
            ddlSubVerificationType.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }

    }

    private void Get_Basic_Import_Data()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Main_EBC_Case_Details";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;
            CaseID.ParameterName = "@CaseID";
            sqlcmd.Parameters.Add(CaseID);

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            DA.Fill(dt);
            sqlcon.Close();


            if (dt.Rows.Count > 0)
            {
                txtCaseID.Text = dt.Rows[0]["case_id"].ToString().Trim();
                txtNameofEmployee.Text = dt.Rows[0]["App_Name"].ToString().Trim();
                txtCaseRecvDate.Text = dt.Rows[0]["RecvDate"].ToString().Trim();
                txtRefNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
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
            sqlcmd.CommandText = "Insert_Employment_Record_IntoTable";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;
            CaseID.ParameterName = "@Case_ID";
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Sub_Verification_Type_ID = new SqlParameter();
            Sub_Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Sub_Verification_Type_ID.Value = ddlSubVerificationType.SelectedItem.Value;
            Sub_Verification_Type_ID.ParameterName = "@Sub_Verification_Type_ID";
            sqlcmd.Parameters.Add(Sub_Verification_Type_ID);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.Value = hdnMainVerifyID.Value;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter Company_Name = new SqlParameter();
            Company_Name.SqlDbType = SqlDbType.VarChar;
            Company_Name.Value = txtCompanyName.Text.Trim();
            Company_Name.ParameterName = "@Company_Name";
            sqlcmd.Parameters.Add(Company_Name);

            SqlParameter Company_Address = new SqlParameter();
            Company_Address.SqlDbType = SqlDbType.VarChar;
            Company_Address.Value = txtCompanyAddress.Text.Trim();
            Company_Address.ParameterName = "@Company_Address";
            sqlcmd.Parameters.Add(Company_Address);

            SqlParameter Company_Contact_Number = new SqlParameter();
            Company_Contact_Number.SqlDbType = SqlDbType.VarChar;
            Company_Contact_Number.Value = txtCompanyContact.Text.Trim();
            Company_Contact_Number.ParameterName = "@Company_Contact_Number";
            sqlcmd.Parameters.Add(Company_Contact_Number);

            SqlParameter Respondent_Name = new SqlParameter();
            Respondent_Name.SqlDbType = SqlDbType.VarChar;
            Respondent_Name.Value = txtRespondentName.Text.Trim();
            Respondent_Name.ParameterName = "@Respondent_Name";
            sqlcmd.Parameters.Add(Respondent_Name);

            SqlParameter Respondent_Designation = new SqlParameter();
            Respondent_Designation.SqlDbType = SqlDbType.VarChar;
            Respondent_Designation.Value = txtRespondentDesignation.Text.Trim();
            Respondent_Designation.ParameterName = "@Respondent_Designation";
            sqlcmd.Parameters.Add(Respondent_Designation);

            SqlParameter Respondent_Contact_Number = new SqlParameter();
            Respondent_Contact_Number.SqlDbType = SqlDbType.VarChar;
            Respondent_Contact_Number.Value = txtRespondentContactNumber.Text.Trim();
            Respondent_Contact_Number.ParameterName = "@Respondent_Contact_Number";
            sqlcmd.Parameters.Add(Respondent_Contact_Number);

            SqlParameter Employee_Designation = new SqlParameter();
            Employee_Designation.SqlDbType = SqlDbType.VarChar;
            Employee_Designation.Value = txtEmployeeDesignation.Text.Trim();
            Employee_Designation.ParameterName = "@Employee_Designation";
            sqlcmd.Parameters.Add(Employee_Designation);

            SqlParameter Last_CTC = new SqlParameter();
            Last_CTC.SqlDbType = SqlDbType.VarChar;
            Last_CTC.Value = txtLastCTC.Text.Trim();
            Last_CTC.ParameterName = "@Last_CTC";
            sqlcmd.Parameters.Add(Last_CTC);

            SqlParameter Period_Of_Employment = new SqlParameter();
            Period_Of_Employment.SqlDbType = SqlDbType.VarChar;
            Period_Of_Employment.Value = txtPeriodofEmployment.Text.Trim();
            Period_Of_Employment.ParameterName = "@Period_Of_Employment";
            sqlcmd.Parameters.Add(Period_Of_Employment);

            SqlParameter Reason_for_Leaving = new SqlParameter();
            Reason_for_Leaving.SqlDbType = SqlDbType.VarChar;
            Reason_for_Leaving.Value = txtReasonForLeaving.Text.ToString().Trim();
            Reason_for_Leaving.ParameterName = "@Reason_for_Leaving";
            sqlcmd.Parameters.Add(Reason_for_Leaving);

            SqlParameter Any_Interigrity_Issue = new SqlParameter();
            Any_Interigrity_Issue.SqlDbType = SqlDbType.VarChar;
            Any_Interigrity_Issue.Value = txtAnyInterigrityIssue.Text.Trim();
            Any_Interigrity_Issue.ParameterName = "@Any_Interigrity_Issue";
            sqlcmd.Parameters.Add(Any_Interigrity_Issue);
            

            SqlParameter Performance_of_the_Employee = new SqlParameter();
            Performance_of_the_Employee.SqlDbType = SqlDbType.VarChar;
            Performance_of_the_Employee.Value = txtPerformanceOfTheEmployee.Text.Trim();
            Performance_of_the_Employee.ParameterName = "@Performance_of_the_Employee";
            sqlcmd.Parameters.Add(Performance_of_the_Employee);

            SqlParameter Proper_Releaving = new SqlParameter();
            Proper_Releaving.SqlDbType = SqlDbType.VarChar;
            Proper_Releaving.Value = ddlProperReleaving.SelectedItem.ToString().Trim();
            Proper_Releaving.ParameterName = "@Proper_Releaving";
            sqlcmd.Parameters.Add(Proper_Releaving);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);          
                      
            SqlParameter Overall_Verfication = new SqlParameter();
            Overall_Verfication.SqlDbType = SqlDbType.VarChar;
            Overall_Verfication.Value = ddlOverallVerification.SelectedItem.ToString().Trim();
            Overall_Verfication.ParameterName = "@Overall_Verification";
            sqlcmd.Parameters.Add(Overall_Verfication);
            
            SqlParameter Date_of_Verification = new SqlParameter();
            Date_of_Verification.SqlDbType = SqlDbType.VarChar;
            Date_of_Verification.Value = txtDateOfVerification.Text.Trim();
            Date_of_Verification.ParameterName = "@Date_of_Verification";
            sqlcmd.Parameters.Add(Date_of_Verification);
            
            SqlParameter Time_of_Verification = new SqlParameter();
            Time_of_Verification.SqlDbType = SqlDbType.VarChar;
            Time_of_Verification.Value = txtTimeOfVerification.Text.Trim();
            Time_of_Verification.ParameterName = "@Time_of_Verification";
            sqlcmd.Parameters.Add(Time_of_Verification);

            SqlParameter FE_Name = new SqlParameter();
            FE_Name.SqlDbType = SqlDbType.VarChar;
            FE_Name.Value = txtFEName.Text.Trim();
            FE_Name.ParameterName = "FE_Name";
            sqlcmd.Parameters.Add(FE_Name);

            SqlParameter Supervisor_Name = new SqlParameter();
            Supervisor_Name.SqlDbType = SqlDbType.VarChar;
            Supervisor_Name.Value = txtSupervisorName.Text.Trim();
            Supervisor_Name.ParameterName = "@Supervisor_Name";
            sqlcmd.Parameters.Add(Supervisor_Name);

            Array newFileUpload1 = null;
            if (FileUpload1.FileBytes.Length > 0)
            {
                newFileUpload1 = FileUpload1.FileBytes;
            }

            SqlParameter UploadImg = new SqlParameter();
            UploadImg.SqlDbType = SqlDbType.Image;
            UploadImg.ParameterName = "@UploadImg";
            UploadImg.Value = newFileUpload1;
            sqlcmd.Parameters.Add(UploadImg);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Record Save Successfuly";
                IsCaseComplete();
                ClearAllField();
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
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

        SqlParameter MessageNO = new SqlParameter();
        MessageNO.SqlDbType = SqlDbType.VarChar;
        MessageNO.Value = "";
        MessageNO.ParameterName = "@MessageNO";
        sqlcmd.Parameters.Add(MessageNO);

        sqlcmd.ExecuteNonQuery();
        sqlcon.Close();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_New_VerificationView.aspx", false);  
    }
}
