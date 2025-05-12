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

public partial class EBC_New_EBC_New_EBC_AddressVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Added by MAnoj
        String strClientID = Session["ClientId"].ToString();
        if (strClientID != "101244")
        {
            ddlaceabilityOfResLoc.Visible = false;
            lblaceabilityOfResLoc.Visible = false;
            ddlConfirmationOfNeighbour.Visible = false;
            lblConfirmationfromNeighbour.Visible = false;
            ddlMetToSpokeatResidence.Visible = false;

            lblSpoketoApplicantatRes.Visible = false;
            ddlRationcard.Visible = false;
            lblRationcard.Visible = false;
        }
        //ended by MAnoj
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
                EmpAddMainDataDetails();
                ResiAddMainDataDetails();
                RegisterControls_WithJavascript();

                if (hdnSubVerifyTypeID.Value != "0")
                {                   

                GetResiAddData();
               
              }
            }
                    
        }  
        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
    }
    
    private void GridDataDetails(int pDetailId)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Other_ResiDetails_Modify";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseID.Value;
        CaseId.ParameterName = "@Case_ID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnMainVerifyID.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlParameter Sub_VerificationID = new SqlParameter();
        Sub_VerificationID.SqlDbType = SqlDbType.VarChar;
        Sub_VerificationID.Value = hdnSubVerifyTypeID.Value;
        Sub_VerificationID.ParameterName = "@Sub_VerificationID";
        sqlcmd.Parameters.Add(Sub_VerificationID);

        SqlParameter DetailID = new SqlParameter();
        DetailID.SqlDbType = SqlDbType.Int  ;
        DetailID.Value = pDetailId;
        DetailID.ParameterName = "@DetailID";
        sqlcmd.Parameters.Add(DetailID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string strFamilyDetails = "";
            string strAgriDetails = "";
            string strHousingDetails = "";
            string strOthPropDetails = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if(pDetailId==1)
                {
                    strFamilyDetails = strFamilyDetails + dt.Rows[i]["FamilyDetails"].ToString();         
                }
                if (pDetailId == 2)
                {
                    strAgriDetails = strAgriDetails + dt.Rows[i]["AgriDetails"].ToString();
                }
                if (pDetailId == 3)
                {
                    strHousingDetails = strHousingDetails + dt.Rows[i]["HousingDetails"].ToString();
                }
                if (pDetailId == 4)
                {
                    strOthPropDetails = strOthPropDetails + dt.Rows[i]["OtherPropDetails"].ToString();
                }
           }
           if (pDetailId == 1)
           {
               hdnMainTab_First.Value = strFamilyDetails.Trim();
           }
           if (pDetailId == 2)
           {
               hdnMainTab_Second.Value = strAgriDetails.Trim();
           }
           if (pDetailId == 3)
           {
               hdnMainTab_Third.Value = strHousingDetails.Trim();
           }
           if (pDetailId == 4)
           {
               hdnMainTab_Fourth.Value = strOthPropDetails.Trim();
           }
         
          }  
       
    }

    private void RegisterControls_WithJavascript()
    {
        btnFamMemAdd.Attributes.Add("onclick", "javascript:return MainTab_First_AddtoGrid();");
        btnFamMemDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_First','" + hdnMainTab_First.ClientID + "','4');");
        btnFamMemEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_First','" + hdnMainTab_First.ClientID + "');");

        btnPropDetAdd.Attributes.Add("onclick", "javascript:return MainTab_Second_AddtoGrid();");
        btnPropDetDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "','7');");
        btnPropDetEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "');");

        btnHousingAdd.Attributes.Add("onclick", "javascript:return MainTab_Third_AddtoGrid();");
        btnHousingDelete.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Third','" + hdnMainTab_Third.ClientID + "','5');");
        btnHousingEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Third','" + hdnMainTab_Third.ClientID + "');");

        btnOthProp_Add.Attributes.Add("onclick", "javascript:return MainTab_Fouth_AddtoGrid();");
        btnOthProp_Del.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Fourth','" + hdnMainTab_Fourth.ClientID + "','3');");
        btnOthProp_Edit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Fourth','" + hdnMainTab_Fourth.ClientID + "');");

        btnSave.Attributes.Add("onclick", "javascript:return SaveValidation();");   
    }
    
    private void EmpAddMainDataDetails()
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

    private void ResiAddMainDataDetails()
    { 
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ResiAddDetails";
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
        SubVerificationTypeID.Value = hdnSubVerifyTypeID.Value;
        sqlcmd.Parameters.Add(SubVerificationTypeID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlSubVeriType.SelectedValue = hdnSubVerifyTypeID.Value;
            txtEmpAdd.Text = dt.Rows[0]["Verification_address"].ToString().Trim();
            txtNameRespo.Text = dt.Rows[0]["Name_of_respondent"].ToString().Trim();
            txtRelan.Text = dt.Rows[0]["relationship"].ToString().Trim();
            txtAddRespo.Text = dt.Rows[0]["Address_of_respondent"].ToString().Trim();
            txtContRespo.Text = dt.Rows[0]["contact_number_of_respondent"].ToString().Trim();
            ddlResiType.SelectedValue = dt.Rows[0]["residence_type"].ToString().Trim();
            txtOthResiType.Text = dt.Rows[0]["Other_ResiType"].ToString().Trim();
            txtLand.Text = dt.Rows[0]["Landmark"].ToString().Trim();
            ddlMariStat.SelectedValue = dt.Rows[0]["Marital_status"].ToString().Trim();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
            ddlVeriStat.SelectedValue = dt.Rows[0]["Overall_Verification"].ToString().Trim();
            txtVeriDate.Text = dt.Rows[0]["Date_of_verification"].ToString().Trim();
            txtVeriTime.Text = dt.Rows[0]["Time_of_verification"].ToString().Trim();
            txtFeName.Text = dt.Rows[0]["FE_Name"].ToString().Trim();
            txtSupName.Text = dt.Rows[0]["Supervisor_Name"].ToString().Trim();
        }

    }

    private void GetResiAddData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ResiAddDetails";
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
                txtVeriTime.Text = dt.Rows[0]["Time_of_Verification"].ToString().Trim();
                txtVeriDate.Text = dt.Rows[0]["Date_of_Verification"].ToString().Trim();
                txtSupName.Text = dt.Rows[0]["Supervisor_Name"].ToString().Trim();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
                txtRelan.Text = dt.Rows[0]["Relationship"].ToString().Trim();
                txtNameRespo.Text = dt.Rows[0]["Name_of_Respondent"].ToString().Trim();
                txtLand.Text = dt.Rows[0]["Landmark"].ToString().Trim();
                txtFeName.Text = dt.Rows[0]["FE_Name"].ToString().Trim();
                txtEmpAdd.Text = dt.Rows[0]["Verification_Address"].ToString().Trim();
                txtOthResiType.Text = dt.Rows[0]["Other_ResiType"].ToString().Trim();
                txtContRespo.Text = dt.Rows[0]["Contact_Number_of_Respondent"].ToString().Trim();
                txtContNo.Text = dt.Rows[0]["Contact_Number_of_Employee"].ToString().Trim();
                txtAddRespo.Text = dt.Rows[0]["Address_of_Respondent"].ToString().Trim();
                ddlMariStat.SelectedValue = dt.Rows[0]["Marital_Status"].ToString().Trim();
                ddlResiType.SelectedValue = dt.Rows[0]["Residence_Type"].ToString().Trim();
                ddlVeriStat.SelectedValue = dt.Rows[0]["Overall_Verification"].ToString().Trim();
                txtEmpAdd.Text = dt.Rows[0]["Verification_Address"].ToString().Trim();

                //-added by kamal matekar
                txtCity.Text = dt.Rows[0]["City"].ToString().Trim();
                txtPincode.Text = dt.Rows[0]["Pincode"].ToString().Trim();
                txtPeriodOfStay.Text = dt.Rows[0]["PeriodOfStay"].ToString().Trim();
                txtNoOfFamilyMember.Text = dt.Rows[0]["NoofFamilyMember"].ToString().Trim();
                ddlBuildingType.SelectedValue = dt.Rows[0]["BuildingType"].ToString().Trim();
                txtBuildingTypeOther.Text = dt.Rows[0]["BuildingTypeOther"].ToString().Trim();
                txtPresenceOfSecurity.Text = dt.Rows[0]["PresenceOfSecurity"].ToString().Trim();
                txtNameBoard.Text = dt.Rows[0]["NameBoard"].ToString().Trim();
                txtFirstNeigh.Text = dt.Rows[0]["First_Neighbour"].ToString().Trim();
                txtSecondNeigh.Text = dt.Rows[0]["Second_Neighbour"].ToString().Trim();
                //--Ended
                //--Added by MAnoj
                ddlMetToSpokeatResidence.SelectedValue = dt.Rows[0]["SpokeToapplicantRes"].ToString().Trim();
                ddlRationcard.SelectedValue = dt.Rows[0]["Rationcardavailable"].ToString().Trim();
                ddlaceabilityOfResLoc.SelectedValue = dt.Rows[0]["aceablityOfRes"].ToString().Trim();
                ddlConfirmationOfNeighbour.SelectedValue = dt.Rows[0]["ConfirmationfromNeigh"].ToString().Trim();
                //---End

                string SendDate = "";
                SendDate = dt.Rows[0]["Send_Datetime"].ToString().Trim(); 
                if(SendDate !="") 
                {
                    btnSave.Enabled = false;  
                }
                
            }
            for (int i = 1; i <= 4; i++)
            {
                GridDataDetails(i);
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;   
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveResiVeriData();
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
            lblMessage.Text =  RowEffected;
            lblMessage.CssClass = "SuccessMessage";
            lblMessage.Text = RowEffected;
            lblMessage.Visible = true;
        }

        sqlcon.Close();   
    }

    private void ClearData()
    {
        txtVeriTime.Text = "";
        txtVeriDate.Text = "";
        txtSupName.Text = "";
        txtRemark.Text = "";
        txtRelan.Text = "";
        txtPropDetVill.Text = "";
        txtPropDetValue.Text = "";
        txtPropDetSurNo.Text = "";
        txtPropDetSource.Text = "";
        txtPropDetRenFed.Text = "";
        txtPropDetIrr.Text = "";
        txtPropDetExten.Text = "";
        txtOthResiType.Text = "";
        txtOthPropTypeAssets.Text = "";
        txtOthPropMarkValue.Text = "";
        txtOthPropDescrip.Text = "";
        txtNameRespo.Text = "";
        txtLand.Text = "";
        txtOthResiType.Text = "";
        txtHousingVill.Text = "";
        txtHousingValue.Text = "";
        txtHousingNoRoom.Text = "";
        txtHousingExten.Text = "";
        txtHousingDescrip.Text = "";
        txtFeName.Text = "";
        txtFamMemRelan.Text = "";
        txtFamMemOccu.Text = "";
        txtFamMemName.Text = "";
        txtFamMemAnnInc.Text = "";
        txtEmpAdd.Text = "";
        txtContRespo.Text = "";
        txtContNo.Text = "";
        txtAddRespo.Text = "";
        ddlMariStat.SelectedIndex = 0;
        ddlResiType.SelectedIndex = 0;
        ddlVeriStat.SelectedIndex = 0;
        hdnMainTab_First.Value = "";
        hdnMainTab_Fourth.Value = "";
        hdnMainTab_Second.Value = "";
        hdnMainTab_Third.Value = ""; 
        
        //--Added by kamal matekar
        txtCity.Text = "";
        txtPincode.Text = "";
        txtPeriodOfStay.Text = "";
        txtNoOfFamilyMember.Text = "";
        ddlBuildingType.SelectedIndex = 0;
        txtBuildingTypeOther.Text = "";
        txtPresenceOfSecurity.Text = "";
        txtNameBoard.Text = "";
        txtFirstNeigh.Text = "";
        txtSecondNeigh.Text = "";
        //--Ended
        //--Added by MANoj
        ddlMetToSpokeatResidence.SelectedIndex = 0;
        ddlaceabilityOfResLoc.SelectedIndex = 0;
        ddlRationcard.SelectedIndex = 0;
        ddlConfirmationOfNeighbour.SelectedIndex = 0;

    }

    private void SaveResiVeriData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_EBC_AddressVerification";
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

            SqlParameter Contact_Number_of_Employee = new SqlParameter();
            Contact_Number_of_Employee.SqlDbType = SqlDbType.VarChar;
            Contact_Number_of_Employee.ParameterName = "@Contact_Number_of_Employee";
            Contact_Number_of_Employee.Value = txtContNo.Text.Trim();  
            sqlcmd.Parameters.Add(Contact_Number_of_Employee);

            SqlParameter Name_of_Respondent = new SqlParameter();
            Name_of_Respondent.SqlDbType = SqlDbType.VarChar;
            Name_of_Respondent.ParameterName = "@Name_of_Respondent";
            Name_of_Respondent.Value = txtNameRespo.Text.Trim();
            sqlcmd.Parameters.Add(Name_of_Respondent);

            SqlParameter Relationship = new SqlParameter();
            Relationship.SqlDbType = SqlDbType.VarChar;
            Relationship.ParameterName = "@Relationship";
            Relationship.Value = txtRelan.Text.Trim();
            sqlcmd.Parameters.Add(Relationship);

            SqlParameter Address_of_Respondent = new SqlParameter();
            Address_of_Respondent.SqlDbType = SqlDbType.VarChar;
            Address_of_Respondent.ParameterName = "@Address_of_Respondent";
            Address_of_Respondent.Value = txtAddRespo.Text.Trim();
            sqlcmd.Parameters.Add(Address_of_Respondent);

            SqlParameter Contact_Number_of_Respondent = new SqlParameter();
            Contact_Number_of_Respondent.SqlDbType = SqlDbType.VarChar;
            Contact_Number_of_Respondent.ParameterName = "@Contact_Number_of_Respondent";
            Contact_Number_of_Respondent.Value = txtContRespo.Text.Trim();
            sqlcmd.Parameters.Add(Contact_Number_of_Respondent);

            SqlParameter Residence_Type = new SqlParameter();
            Residence_Type.SqlDbType = SqlDbType.VarChar;
            Residence_Type.ParameterName = "@Residence_Type";
            Residence_Type.Value = ddlResiType.Text.Trim();
            sqlcmd.Parameters.Add(Residence_Type);

            SqlParameter Landmark = new SqlParameter();
            Landmark.SqlDbType = SqlDbType.VarChar;
            Landmark.ParameterName = "@Landmark";
            Landmark.Value = txtLand.Text.Trim();
            sqlcmd.Parameters.Add(Landmark);

            SqlParameter Marital_Status = new SqlParameter();
            Marital_Status.SqlDbType = SqlDbType.VarChar;
            Marital_Status.ParameterName = "@Marital_Status";
            Marital_Status.Value = ddlMariStat.Text.Trim();
            sqlcmd.Parameters.Add(Marital_Status);

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
            Supervisor_Name.Value = txtSupName.Text.Trim();
            sqlcmd.Parameters.Add(Supervisor_Name);

            SqlParameter Other_ResiType = new SqlParameter();
            Other_ResiType.SqlDbType = SqlDbType.VarChar;
            Other_ResiType.ParameterName = "@Other_ResiType";
            Other_ResiType.Value = txtOthResiType.Text.Trim();
            sqlcmd.Parameters.Add(Other_ResiType);

            SqlParameter Other_HousingDetails = new SqlParameter();
            Other_HousingDetails.SqlDbType = SqlDbType.VarChar;
            Other_HousingDetails.ParameterName = "@Other_HousingDetails";
            Other_HousingDetails.Value = hdnMainTab_Third.Value;
            sqlcmd.Parameters.Add(Other_HousingDetails);

            SqlParameter Other_FamilyDetails = new SqlParameter();
            Other_FamilyDetails.SqlDbType = SqlDbType.VarChar;
            Other_FamilyDetails.ParameterName = "@Other_FamilyDetails";
            Other_FamilyDetails.Value = hdnMainTab_First.Value;
            sqlcmd.Parameters.Add(Other_FamilyDetails);

            SqlParameter Other_AgriculturalDetails = new SqlParameter();
            Other_AgriculturalDetails.SqlDbType = SqlDbType.VarChar;
            Other_AgriculturalDetails.ParameterName = "@Other_AgriculturalDetails";
            Other_AgriculturalDetails.Value = hdnMainTab_Second.Value;
            sqlcmd.Parameters.Add(Other_AgriculturalDetails);

            SqlParameter Other_PropertyDetails = new SqlParameter();
            Other_PropertyDetails.SqlDbType = SqlDbType.VarChar;
            Other_PropertyDetails.ParameterName = "@Other_PropertyDetails";
            Other_PropertyDetails.Value = hdnMainTab_Fourth.Value;
            sqlcmd.Parameters.Add(Other_PropertyDetails);

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

            //--Added by kamal matekar

            SqlParameter City = new SqlParameter();
            City.SqlDbType = SqlDbType.VarChar;
            City.ParameterName = "@City";
            City.Value = txtCity.Text.Trim();
            sqlcmd.Parameters.Add(City);

            SqlParameter Pincode = new SqlParameter();
            Pincode.SqlDbType = SqlDbType.VarChar;
            Pincode.ParameterName = "@Pincode";
            Pincode.Value = txtPincode.Text.Trim();
            sqlcmd.Parameters.Add(Pincode);

            SqlParameter PeriodOfStay = new SqlParameter();
            PeriodOfStay.SqlDbType = SqlDbType.VarChar;
            PeriodOfStay.ParameterName = "@PeriodOfStay";
            PeriodOfStay.Value = txtPeriodOfStay.Text.Trim();
            sqlcmd.Parameters.Add(PeriodOfStay);

            SqlParameter NoofFamilyMember = new SqlParameter();
            NoofFamilyMember.SqlDbType = SqlDbType.VarChar;
            NoofFamilyMember.ParameterName = "@NoofFamilyMember";
            NoofFamilyMember.Value = txtNoOfFamilyMember.Text.Trim();
            sqlcmd.Parameters.Add(NoofFamilyMember);

            SqlParameter BuildingType = new SqlParameter();
            BuildingType.SqlDbType = SqlDbType.VarChar;
            BuildingType.ParameterName = "@BuildingType";
            BuildingType.Value = ddlBuildingType.Text.Trim();
            sqlcmd.Parameters.Add(BuildingType);

            SqlParameter BuildingTypeOther = new SqlParameter();
            BuildingTypeOther.SqlDbType = SqlDbType.VarChar;
            BuildingTypeOther.ParameterName = "@BuildingTypeOther";
            BuildingTypeOther.Value = txtBuildingTypeOther.Text.Trim();
            sqlcmd.Parameters.Add(BuildingTypeOther);

            SqlParameter PresenceOfSecurity = new SqlParameter();
            PresenceOfSecurity.SqlDbType = SqlDbType.VarChar;
            PresenceOfSecurity.ParameterName = "@PresenceOfSecurity";
            PresenceOfSecurity.Value = txtPresenceOfSecurity.Text.Trim();
            sqlcmd.Parameters.Add(PresenceOfSecurity);

            SqlParameter NameBoard = new SqlParameter();
            NameBoard.SqlDbType = SqlDbType.VarChar;
            NameBoard.ParameterName = "@NameBoard";
            NameBoard.Value = txtNameBoard.Text.Trim();
            sqlcmd.Parameters.Add(NameBoard);

            SqlParameter First_Neighbour = new SqlParameter();
            First_Neighbour.SqlDbType = SqlDbType.VarChar;
            First_Neighbour.ParameterName = "@First_Neighbour";
            First_Neighbour.Value = txtFirstNeigh.Text.Trim();
            sqlcmd.Parameters.Add(First_Neighbour);

            SqlParameter Second_Neighbour = new SqlParameter();
            Second_Neighbour.SqlDbType = SqlDbType.VarChar;
            Second_Neighbour.ParameterName = "@Second_Neighbour";
            Second_Neighbour.Value = txtSecondNeigh.Text.Trim();
            sqlcmd.Parameters.Add(Second_Neighbour);

            //---Ended
            //---Added by Manoj For PAMAC RES
            SqlParameter SpokeToapplicantRes = new SqlParameter();
            SpokeToapplicantRes.SqlDbType = SqlDbType.VarChar;
            SpokeToapplicantRes.ParameterName = "@SpokeToapplicantRes";
            SpokeToapplicantRes.Value = ddlMetToSpokeatResidence.SelectedItem.ToString();
            sqlcmd.Parameters.Add(SpokeToapplicantRes);


            SqlParameter aceablityOfRes = new SqlParameter();
            aceablityOfRes.SqlDbType = SqlDbType.VarChar;
            aceablityOfRes.ParameterName = "@aceablityOfRes";
            aceablityOfRes.Value = ddlaceabilityOfResLoc.SelectedItem.ToString();
            sqlcmd.Parameters.Add(aceablityOfRes);


            SqlParameter Rationcardavailable = new SqlParameter();
            Rationcardavailable.SqlDbType = SqlDbType.VarChar;
            Rationcardavailable.ParameterName = "@Rationcardavailable";
            Rationcardavailable.Value = ddlRationcard.SelectedItem.ToString();
            sqlcmd.Parameters.Add(Rationcardavailable);


            SqlParameter ConfirmationfromNeigh = new SqlParameter();
            ConfirmationfromNeigh.SqlDbType = SqlDbType.VarChar;
            ConfirmationfromNeigh.ParameterName = "@ConfirmationfromNeigh";
            ConfirmationfromNeigh.Value = ddlConfirmationOfNeighbour.SelectedItem.ToString();
            sqlcmd.Parameters.Add(ConfirmationfromNeigh);

            //---Ended
            
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();  
            lblMessage.Text = "Record Succefully Save";
  
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;   
        }
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {

        Response.Redirect("EBC_New_VerificationView.aspx");  
    
    }

    protected void ddlSubVeriType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearData();
        if (ddlSubVeriType.SelectedIndex != 0)
        {
            hdnSubVerifyTypeID.Value = ddlSubVeriType.SelectedItem.Value.ToString();
         
            GetResiAddData();
        }
    }
   
}
