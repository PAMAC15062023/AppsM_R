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

public partial class EBC_New_EBC_New_EBC_ReferenceCheck : System.Web.UI.Page
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
                    Get_ReferenceCheck_Sub_Verification_TypeDetails();
                    Get_Basic_Import_Data();
                    SaveValidation();
                }
            
        }
    }

    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");   
    }

    private void Get_ReferenceCheck_Sub_Verification_TypeDetails()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ReferenceCheck_Sub_Verification_Type";

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

            //SqlParameter SubVerificationTypeID = new SqlParameter();
            //SubVerificationTypeID.SqlDbType = SqlDbType.VarChar;
            //SubVerificationTypeID.Value = hdnSubVerifyTypeID.Value;
            //SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
            //sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            DA.Fill(dt);
            sqlcon.Close();

            ddlSubVerificationType.DataTextField = "Verification_Description";
            ddlSubVerificationType.DataValueField = "Sub_Verification_Type_ID";

            ddlSubVerificationType.DataSource = dt;
            ddlSubVerificationType.DataBind();

            ddlSubVerificationType.Items.Insert(0, "-Select-");
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
                txtNameOfEmployee.Text = dt.Rows[0]["App_Name"].ToString().Trim();
                txtDate.Text = dt.Rows[0]["RecvDate"].ToString().Trim();
                txtClientRefNo.Text = dt.Rows[0]["Ref_No"].ToString().Trim();
                txtFatherName.Text = dt.Rows[0]["Father_Name"].ToString().Trim();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString().Trim();
                txtAddress.Text = dt.Rows[0]["ADD_1"].ToString().Trim();
            
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
            sqlcmd.CommandText = "Insert_Reference_Check_IntoTable";
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

            SqlParameter Address = new SqlParameter();
            Address.SqlDbType = SqlDbType.VarChar;
            Address.Value = txtAddress.Text.Trim();
            Address.ParameterName = "@Address";
            sqlcmd.Parameters.Add(Address);

            SqlParameter Reference_Name = new SqlParameter();
            Reference_Name.SqlDbType = SqlDbType.VarChar;
            Reference_Name.Value = txtRef_Name.Text.Trim();
            Reference_Name.ParameterName = "@Reference_Name";
            sqlcmd.Parameters.Add(Reference_Name);

            SqlParameter Reference_Relation = new SqlParameter();
            Reference_Relation.SqlDbType = SqlDbType.VarChar;
            Reference_Relation.Value = txtRef_Relation.Text.Trim();
            Reference_Relation.ParameterName = "@Reference_Relation";
            sqlcmd.Parameters.Add(Reference_Relation);

            SqlParameter Reference_Address = new SqlParameter();
            Reference_Address.SqlDbType = SqlDbType.VarChar;
            Reference_Address.Value = txt_Ref_Address.Text.Trim();
            Reference_Address.ParameterName = "@Reference_Address";
            sqlcmd.Parameters.Add(Reference_Address);

            SqlParameter Reference_Contact_Number = new SqlParameter();
            Reference_Contact_Number.SqlDbType = SqlDbType.VarChar;
            Reference_Contact_Number.Value = txtRef_ContactNo.Text.Trim();
            Reference_Contact_Number.ParameterName = "@Reference_Contact_Number";
            sqlcmd.Parameters.Add(Reference_Contact_Number);

            SqlParameter Residence_Address = new SqlParameter();
            Residence_Address.SqlDbType = SqlDbType.VarChar;
            Residence_Address.Value = txtResidenceAddress.Text.Trim();
            Residence_Address.ParameterName = "@Residence_Address_of_Employee_as_Per_Call_Visit";
            sqlcmd.Parameters.Add(Residence_Address);

            SqlParameter Since_reference_candidate = new SqlParameter();
            Since_reference_candidate.SqlDbType = SqlDbType.VarChar;
            Since_reference_candidate.Value = txtRef_Of_Candidate.Text.Trim();
            Since_reference_candidate.ParameterName = "@Since_how_long_the_referencee_is_knowing_to_the_candidate";
            sqlcmd.Parameters.Add(Since_reference_candidate);

            SqlParameter Number_of_Years_at_Residence = new SqlParameter();
            Number_of_Years_at_Residence.SqlDbType = SqlDbType.VarChar;
            Number_of_Years_at_Residence.Value = txtNo_Of_Years_at_Residence.Text.Trim();
            Number_of_Years_at_Residence.ParameterName = "@Number_of_Years_at_Residence";
            sqlcmd.Parameters.Add(Number_of_Years_at_Residence);

            SqlParameter Residence_Status = new SqlParameter();
            Residence_Status.SqlDbType = SqlDbType.VarChar;
            Residence_Status.Value = ddlResiType.SelectedItem.ToString().Trim();
            Residence_Status.ParameterName = "@Residence_Status";
            sqlcmd.Parameters.Add(Residence_Status);

            SqlParameter Occupation_Type = new SqlParameter();
            Occupation_Type.SqlDbType = SqlDbType.VarChar;
            Occupation_Type.Value = txtOccupation_Type.Text.Trim();
            Occupation_Type.ParameterName = "@Occupation_Type";
            sqlcmd.Parameters.Add(Occupation_Type);

            SqlParameter Name_of_Employer_of_Employee = new SqlParameter();
            Name_of_Employer_of_Employee.SqlDbType = SqlDbType.VarChar;
            Name_of_Employer_of_Employee.Value = txtName_Of_Employer_Of_Employee.Text.Trim();
            Name_of_Employer_of_Employee.ParameterName = "@Name_of_Employer_of_Employee";
            sqlcmd.Parameters.Add(Name_of_Employer_of_Employee);
            
            SqlParameter Designation_of_the_Employee = new SqlParameter();
            Designation_of_the_Employee.SqlDbType = SqlDbType.VarChar;
            Designation_of_the_Employee.Value = txtDesignation_Of_The_Employee.Text.Trim();
            Designation_of_the_Employee.ParameterName = "@Designation_of_the_Employee";
            sqlcmd.Parameters.Add(Designation_of_the_Employee);

            SqlParameter Contact_Number_of_the_Employee = new SqlParameter();
            Contact_Number_of_the_Employee.SqlDbType = SqlDbType.VarChar;
            Contact_Number_of_the_Employee.Value = txtContact_No_Of_Employee.Text.Trim();
            Contact_Number_of_the_Employee.ParameterName = "@Contact_Number_of_the_Employee";
            sqlcmd.Parameters.Add(Contact_Number_of_the_Employee);

            SqlParameter Remarks_Feedback = new SqlParameter();
            Remarks_Feedback.SqlDbType = SqlDbType.VarChar;
            Remarks_Feedback.Value = txtRemarks.Text.Trim();
            Remarks_Feedback.ParameterName = "@Remarks_Feedback";
            sqlcmd.Parameters.Add(Remarks_Feedback);


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

            SqlParameter Overall_Verfication = new SqlParameter();
            Overall_Verfication.SqlDbType = SqlDbType.VarChar;
            Overall_Verfication.Value = ddlStatus.SelectedItem.ToString().Trim();
            Overall_Verfication.ParameterName = "@Overall_Verification";
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
            UploadImg.SqlDbType = SqlDbType.Binary;
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
            else
            {

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
    protected void ddlSubVerificationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlSubVerificationType.SelectedIndex != 0)
            {
                Get_SubVerificationType_For_Reference();
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

    private void Get_SubVerificationType_For_Reference()
    {
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "EBC_New_Get_Reference_Check_Details";
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
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    private void Assign_Values_To_SubTextBoxes(DataTable dr)
    {

        txtRef_Name.Text = dr.Rows[0]["Reference_Name"].ToString().Trim();
        txtRef_Relation.Text = dr.Rows[0]["Reference_Relation"].ToString().Trim();
        txtRef_ContactNo.Text = dr.Rows[0]["Reference_Contact_Number"].ToString().Trim();
        txt_Ref_Address.Text = dr.Rows[0]["Reference_Address"].ToString().Trim();
        txtResidenceAddress.Text = dr.Rows[0]["Residence_Address_of_Employee_as_Per_Call_Visit"].ToString().Trim();
        txtRef_Of_Candidate.Text = dr.Rows[0]["Since_how_long_the_referencee_is_knowing_to_the_candidate"].ToString().Trim();
        txtNo_Of_Years_at_Residence.Text = dr.Rows[0]["Number_of_Years_at_Residence"].ToString().Trim();
        ddlResiType.SelectedValue = dr.Rows[0]["Residence_Status"].ToString().Trim();
        txtDesignation_Of_The_Employee.Text = dr.Rows[0]["Designation_of_the_Employee"].ToString().Trim();
        txtOccupation_Type.Text = dr.Rows[0]["Occupation_Type"].ToString().Trim();
        txtContact_No_Of_Employee.Text = dr.Rows[0]["Contact_Number_of_the_Employee"].ToString().Trim();
        txtName_Of_Employer_Of_Employee.Text = dr.Rows[0]["Name_of_Employer_of_Employee"].ToString().Trim();
        txtRemarks.Text = dr.Rows[0]["Remarks_Feedback"].ToString().Trim();
        ddlStatus.SelectedValue = dr.Rows[0]["Overall_Verification"].ToString().Trim();
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
            txtRef_Name.Text ="";
            txtRef_Relation.Text ="";
            txtRef_ContactNo.Text ="";
            txt_Ref_Address.Text ="";
            txtResidenceAddress.Text ="";
            txtRef_Of_Candidate.Text ="";
            txtNo_Of_Years_at_Residence.Text ="";
            ddlResiType.SelectedIndex = 0;
            txtDesignation_Of_The_Employee.Text ="";
            txtOccupation_Type.Text ="";
            txtContact_No_Of_Employee.Text ="";
            txtName_Of_Employer_Of_Employee.Text ="";
            txtRemarks.Text ="";
            ddlStatus.SelectedIndex=0;
            txtDateOfVerification.Text ="";
            txtTimeOfVerification.Text ="";
            txtFEName.Text ="";
            txtSupervisorName.Text = "";
    }
}
    