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


public partial class EBC_New_EBC_New_EBC_New_Educational_Check : System.Web.UI.Page
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
                    Get_Educational_Sub_Verification_TypeDetails();
                    Get_Basic_Import_Data();
                    SaveValidation();
               
            }
        }
    }

    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");
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
                txtNameOfEmployee.Text = dt.Rows[0]["App_Name"].ToString().Trim();
                txtDate.Text = dt.Rows[0]["RecvDate"].ToString().Trim();
                txtClientRefNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
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
            sqlcmd.CommandText = "Insert_Educational_Record_IntoTable";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;
            CaseID.ParameterName = "@Case_ID";
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Sub_Verification_Type_ID = new SqlParameter();
            Sub_Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Sub_Verification_Type_ID.Value = ddlVerificationType.SelectedItem.Value;
            Sub_Verification_Type_ID.ParameterName = "@Sub_Verification_Type_ID";
            sqlcmd.Parameters.Add(Sub_Verification_Type_ID);

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.Value = hdnMainVerifyID.Value;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter Institute_Name = new SqlParameter();
            Institute_Name.SqlDbType = SqlDbType.VarChar;
            Institute_Name.Value = txtCollegeName.Text.Trim();
            Institute_Name.ParameterName = "@Institute_Name";
            sqlcmd.Parameters.Add(Institute_Name);

            SqlParameter Qualification = new SqlParameter();
            Qualification.SqlDbType = SqlDbType.VarChar;
            Qualification.Value = txtQualification.Text.Trim();
            Qualification.ParameterName = "@Qualification";
            sqlcmd.Parameters.Add(@Qualification);

            SqlParameter Institute_Address = new SqlParameter();
            Institute_Address.SqlDbType = SqlDbType.VarChar;
            Institute_Address.Value = txtAddress.Text.Trim();
            Institute_Address.ParameterName = "@Institute_Address";
            sqlcmd.Parameters.Add(Institute_Address);

            SqlParameter Registration_Number = new SqlParameter();
            Registration_Number.SqlDbType = SqlDbType.VarChar;
            Registration_Number.Value = txtRegistrator.Text.Trim();
            Registration_Number.ParameterName = "@Registration_Number";
            sqlcmd.Parameters.Add(Registration_Number);

            SqlParameter Roll_Number = new SqlParameter();
            Roll_Number.SqlDbType = SqlDbType.VarChar;
            Roll_Number.Value = txtRollNumber.Text.Trim();
            Roll_Number.ParameterName = "@Roll_Number";
            sqlcmd.Parameters.Add(Roll_Number);

            SqlParameter Passing_Year = new SqlParameter();
            Passing_Year.SqlDbType = SqlDbType.VarChar;
            Passing_Year.Value = txtYearOfPassing.Text.Trim();
            Passing_Year.ParameterName = "@Passing_Year";
            sqlcmd.Parameters.Add(Passing_Year);

            SqlParameter Respondent_Name = new SqlParameter();
            Respondent_Name.SqlDbType = SqlDbType.VarChar;
            Respondent_Name.Value = txtRespondentName.Text.Trim();
            Respondent_Name.ParameterName = "@Respondent_Name";
            sqlcmd.Parameters.Add(Respondent_Name);

            SqlParameter Respondent_Designation = new SqlParameter();
            Respondent_Designation.SqlDbType = SqlDbType.VarChar;
            Respondent_Designation.Value =txtRespondentDesig.Text.Trim();
            Respondent_Designation.ParameterName = "@Respondent_Designation";
            sqlcmd.Parameters.Add(Respondent_Designation);
      
            SqlParameter Respondent_Contact_Number = new SqlParameter();
            Respondent_Contact_Number.SqlDbType = SqlDbType.VarChar;
            Respondent_Contact_Number.Value = txtRespondentContactNo.Text.Trim();
            Respondent_Contact_Number.ParameterName = "@Respondent_Contact_Number";
            sqlcmd.Parameters.Add(Respondent_Contact_Number);

            SqlParameter Record_Found = new SqlParameter();
            Record_Found.SqlDbType = SqlDbType.VarChar;
            Record_Found.Value = ddlRecordFound.SelectedItem.ToString().Trim();
            Record_Found.ParameterName = "@Record_Found";
            sqlcmd.Parameters.Add(Record_Found);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);


            SqlParameter Date_of_Verification = new SqlParameter();
            Date_of_Verification.SqlDbType = SqlDbType.VarChar;
            Date_of_Verification.Value =txtDateOfVerification.Text.Trim();
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
            
            SqlParameter Overall_Verfication = new SqlParameter();
            Overall_Verfication.SqlDbType = SqlDbType.VarChar;
            Overall_Verfication.Value = ddlStatus.SelectedItem.ToString().Trim();
            Overall_Verfication.ParameterName = "@Overall_Verfication";
            sqlcmd.Parameters.Add(Overall_Verfication);

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
                ClearControl();
            }
            
        }
        catch(Exception ex)
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

    private void ClearControl()
    {
        txtQualification.Text = "";
        txtCollegeName.Text = "";
        txtRegistrator.Text = "";
        txtAddress.Text = "";
        txtDateOfVerification.Text = "";
        txtFEName.Text = "";
        txtRegistrator.Text = "";
        txtRemark.Text = "";
        txtRespondentContactNo.Text = "";
        txtRespondentDesig.Text = "";
        txtRespondentName.Text = "";
        txtRollNumber.Text = "";
        txtSupervisorName.Text = "";
        txtTimeOfVerification.Text = "";
        txtYearOfPassing.Text = "";
        ddlRecordFound.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
         
    }

    private void Get_Educational_Sub_Verification_TypeDetails()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Education_Sub_Verification_Type";
            
            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;//"101";
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

            ddlVerificationType.DataTextField = "Verification_Code";
            ddlVerificationType.DataValueField = "Sub_Verification_Type_ID";

            ddlVerificationType.DataSource = dt;
            ddlVerificationType.DataBind();

            ddlVerificationType.Items.Insert(0, "-Select");
            ddlVerificationType.SelectedIndex = 0;

            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }

    }

    protected void ddlVerificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlVerificationType.SelectedIndex != 0)
            {
                Get_SubVerificationType();
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

    private void Get_SubVerificationType()
    {
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "EBC_New_Get_Educational_Details";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = hdnCaseID.Value;
            CaseID.ParameterName = "@CaseId";
            sqlcmd.Parameters.Add(CaseID);

            SqlParameter Sub_Verification_Type_ID = new SqlParameter();
            Sub_Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Sub_Verification_Type_ID.Value = ddlVerificationType.SelectedItem.Value;
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
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    private void Assign_Values_To_SubTextBoxes(DataTable dr)
    {
        
        txtQualification.Text = dr.Rows[0]["Qualification"].ToString().Trim();
        txtCollegeName.Text = dr.Rows[0]["Institute_Name"].ToString().Trim();
        txtAddress.Text = dr.Rows[0]["Institute_Address"].ToString().Trim();
        txtRegistrator.Text = dr.Rows[0]["Registration_Number"].ToString().Trim();
        txtRollNumber.Text = dr.Rows[0]["Roll_Number"].ToString().Trim();
        txtRespondentName.Text = dr.Rows[0]["Respondent_Name"].ToString().Trim();
        txtRespondentContactNo.Text = dr.Rows[0]["Respondent_Contact_Number"].ToString().Trim();
        txtRemark.Text = dr.Rows[0]["Remark"].ToString().Trim();
        txtDateOfVerification.Text = dr.Rows[0]["Date_of_Verification"].ToString().Trim();
        txtFEName.Text = dr.Rows[0]["FE_Name"].ToString().Trim();
        ddlStatus.SelectedValue = dr.Rows[0]["Overall_Verfication"].ToString().Trim();
        txtYearOfPassing.Text = dr.Rows[0]["Passing_Year"].ToString().Trim();
        txtRespondentDesig.Text = dr.Rows[0]["Respondent_Designation"].ToString().Trim();
        ddlRecordFound.SelectedValue = dr.Rows[0]["Record_Found"].ToString().Trim();
        txtTimeOfVerification.Text = dr.Rows[0]["Time_of_Verification"].ToString().Trim();
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
       
        txtQualification.Text ="";
        txtCollegeName.Text="";
        txtAddress.Text="";
        txtRegistrator.Text="";
        txtRollNumber.Text="";
        txtRespondentName.Text="";
        txtRespondentContactNo.Text="";
        txtRemark.Text="";
        txtDateOfVerification.Text="";
        txtFEName.Text="";
        ddlStatus.SelectedIndex = 0;
        txtYearOfPassing.Text="";
        txtRespondentDesig.Text="";
        ddlRecordFound.SelectedIndex=0;
        txtTimeOfVerification.Text="";
        txtSupervisorName.Text = "";

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_New_VerificationView.aspx",false);  
    }
}
