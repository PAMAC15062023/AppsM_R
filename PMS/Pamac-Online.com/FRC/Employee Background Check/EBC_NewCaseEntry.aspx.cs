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

public partial class EBC_New_EBC_New_EBC_NewCaseEntry : System.Web.UI.Page
{
    //public string ConnectionString
    //{
    //    get
    //    {
    //        return (ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString());
    //    }
    //}


    CCommon objconn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetVerificationType();
            GetSubVerificationType();
            GetEmploymentSubVerificationType();
            GetRefSubVerificationType();
            //--Added By Kamal Matekar On 07Aug2012
            GetKnowYourCustomerType();
            //---Ended
            RegisterControls_WithJavascript();
            Validate_Verification();
        }
        
        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
    }
    private void RegisterControls_WithJavascript()
    {        
        btnFamMemAdd.Attributes.Add("onclick", "javascript:return MainTab_First_AddtoGrid();");
        btnFamMemDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_First','" + hdnMainTab_First.ClientID + "','5');");
        btnFamMemEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_First','" + hdnMainTab_First.ClientID + "');");

        btnEmp_Add.Attributes.Add("onclick", "javascript:return MainTab_Second_AddtoGrid();");
        btnEmp_Del.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "','4');");
        btnEmp_Edit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Second','" + hdnMainTab_Second.ClientID + "');");

        btnRefAdd.Attributes.Add("onclick", "javascript:return MainTab_Third_AddtoGrid();");
        btnRefDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Third','" + hdnMainTab_Third.ClientID + "','5');");
        btnRefEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Third','" + hdnMainTab_Third.ClientID + "');");

        //---Added by kamal matekar

        btnAddKYC.Attributes.Add("onclick", "javascript:return MainTab_Fourth_AddtoGrid();");
        btnKYCDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_Fourth','" + hdnMainTab_Fourth.ClientID + "','4');");
        btnKYCEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab_Fourth','" + hdnMainTab_Fourth.ClientID + "');");
        //--Ended  btnKYCEdit

        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();"); 
         
    }
    private void GetVerificationType()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_VerificationType";
        sqlcmd.CommandTimeout = 0;
        SqlDataAdapter sqlda = new SqlDataAdapter();

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close(); 

        chkVeriType.DataSource = dt;
        chkVeriType.DataValueField = "VERIFICATION_TYPE_CODE";
        chkVeriType.DataTextField = "VERIFICATION_TYPE";
        chkVeriType.DataBind();  
    }
    private void GetSubVerificationType()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubVerification_Type_ID_For_Search";
        sqlcmd.CommandTimeout = 0;
        SqlDataAdapter sqlda = new SqlDataAdapter();

        SqlParameter VeriId = new SqlParameter();
        VeriId.SqlDbType = SqlDbType.Int;
        VeriId.ParameterName = "@Verification_Type_ID"; 
        VeriId.Value = hdnEducationTypeId.Value;
        sqlcmd.Parameters.Add(VeriId);   

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlVerificationType.DataSource = dt;
        ddlVerificationType.DataValueField = "Sub_Verification_Type_ID";
        ddlVerificationType.DataTextField = "Verification_Code";
        ddlVerificationType.DataBind();

        ddlVerificationType.Items.Insert(0, "--Select--");
        ddlVerificationType.SelectedIndex = 0;

    }
    private void GetEmploymentSubVerificationType()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Emploment_SubVerification_Type_ID_For_Search";
        sqlcmd.CommandTimeout = 0;
        SqlDataAdapter sqlda = new SqlDataAdapter();

        SqlParameter VeriId = new SqlParameter();
        VeriId.SqlDbType = SqlDbType.Int;
        VeriId.ParameterName = "@Verification_Type_ID";
        VeriId.Value = hdnEmplomentTypeId.Value;
        sqlcmd.Parameters.Add(VeriId);

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlEmployment.DataSource = dt;
        ddlEmployment.DataValueField = "Sub_Verification_Type_ID";
        ddlEmployment.DataTextField = "Verification_Description";
        ddlEmployment.DataBind();

        ddlEmployment.Items.Insert(0, "--Select--");
        ddlEmployment.SelectedIndex = 0;

    }
    private void GetKnowYourCustomerType()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_KnowYourCustomer_Type_ID_For_Search";
        sqlcmd.CommandTimeout = 0;
        SqlDataAdapter sqlda = new SqlDataAdapter();

        SqlParameter VeriId = new SqlParameter();
        VeriId.SqlDbType = SqlDbType.Int;
        VeriId.ParameterName = "@Verification_Type_ID";
        VeriId.Value = hdnKYCID.Value;
        sqlcmd.Parameters.Add(VeriId);

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlKYC.DataSource = dt;
        ddlKYC.DataValueField = "Sub_Verification_Type_ID";
        ddlKYC.DataTextField = "Verification_Description";
        ddlKYC.DataBind();

        ddlKYC.Items.Insert(0, "--Select--");
        ddlKYC.SelectedIndex = 0;
    }

    private void GetRefSubVerificationType()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_RefCheck_SubVerification_Type_ID_For_Search";
        sqlcmd.CommandTimeout = 0;
        SqlDataAdapter sqlda = new SqlDataAdapter();

        SqlParameter VeriId = new SqlParameter();
        VeriId.SqlDbType = SqlDbType.Int;
        VeriId.ParameterName = "@Verification_Type_ID";
        VeriId.Value = hdnRefTypeId.Value;
        sqlcmd.Parameters.Add(VeriId);

        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlRefType.DataSource = dt;
        ddlRefType.DataValueField = "Sub_Verification_Type_ID";
        ddlRefType.DataTextField = "Verification_Description";
        ddlRefType.DataBind();

        ddlRefType.Items.Insert(0, "--Select--");
        ddlRefType.SelectedIndex = 0;

    }
    private void SaveNewEntryData()
    {
        try
        {

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_EBC_NEW_CASEDetails";
            sqlcmd.CommandTimeout = 0;
            
            string CaseId = hdnCaseId.Value; 
            if (hdnCaseId.Value == "")
            { 
             string strPrefix = "101";
             CaseId = GetUniqueID("CPV_EBC_CASE_DETAILS", strPrefix).ToString();
            }

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.VarChar;
            CaseID.Value = CaseId;
            CaseID.ParameterName = "@CaseID";
            sqlcmd.Parameters.Add(CaseID);

            ArrayList arrVerType = new ArrayList();
            string sVerTypeCode = "";
            if (chkVeriType.Items.Count > 0)
            {
                foreach (ListItem li in chkVeriType.Items)
                {
                    if (li.Selected == true)
                    {
                        arrVerType.Add(li.Value);
                        sVerTypeCode += li.Value.Trim() + "+";
                    }
                }
            }
            string VerificationCode = "";
            VerificationCode = sVerTypeCode.Trim() + "^";

            SqlParameter VerificationTypeCode = new SqlParameter();
            VerificationTypeCode.SqlDbType = SqlDbType.VarChar;
            VerificationTypeCode.Value = VerificationCode;
            VerificationTypeCode.ParameterName = "@VerificationTypeCode";
            sqlcmd.Parameters.Add(VerificationTypeCode);

            SqlParameter CLUSTER_ID = new SqlParameter();
            CLUSTER_ID.SqlDbType = SqlDbType.Int;
            CLUSTER_ID.Value = Session["ClusterId"].ToString();
            CLUSTER_ID.ParameterName = "@CLUSTER_ID";
            sqlcmd.Parameters.Add(CLUSTER_ID);

            SqlParameter CENTRE_ID = new SqlParameter();
            CENTRE_ID.SqlDbType = SqlDbType.Int;
            CENTRE_ID.Value = Session["CentreId"].ToString();
            CENTRE_ID.ParameterName = "@CENTRE_ID";
            sqlcmd.Parameters.Add(CENTRE_ID);

            SqlParameter Client_ID = new SqlParameter();
            Client_ID.SqlDbType = SqlDbType.Int;
            Client_ID.Value = Session["ClientId"].ToString();
            Client_ID.ParameterName = "@Client_ID";
            sqlcmd.Parameters.Add(Client_ID);

            SqlParameter RefNo = new SqlParameter();
            RefNo.SqlDbType = SqlDbType.VarChar;
            RefNo.Value = txtRefNo.Text.Trim();
            RefNo.ParameterName = "@REF_NO";
            sqlcmd.Parameters.Add(RefNo);

            SqlParameter FIRST_NAME = new SqlParameter();
            FIRST_NAME.SqlDbType = SqlDbType.VarChar;
            FIRST_NAME.Value = txtFirstName.Text.Trim();
            FIRST_NAME.ParameterName = "@FIRST_NAME";
            sqlcmd.Parameters.Add(FIRST_NAME);

            SqlParameter MIDDLE_NAME = new SqlParameter();
            MIDDLE_NAME.SqlDbType = SqlDbType.VarChar;
            MIDDLE_NAME.Value = txtMidName.Text.Trim();
            MIDDLE_NAME.ParameterName = "@MIDDLE_NAME";
            sqlcmd.Parameters.Add(MIDDLE_NAME);

            SqlParameter LAST_NAME = new SqlParameter();
            LAST_NAME.SqlDbType = SqlDbType.VarChar;
            LAST_NAME.Value = txtLastName.Text.Trim();
            LAST_NAME.ParameterName = "@LAST_NAME";
            sqlcmd.Parameters.Add(LAST_NAME);

            SqlParameter CASE_REC_DATETIME = new SqlParameter();
            CASE_REC_DATETIME.SqlDbType = SqlDbType.VarChar;
            CASE_REC_DATETIME.Value = txtRcvdDate.Text.Trim();
            CASE_REC_DATETIME.ParameterName = "@CASE_REC_DATETIME";
            sqlcmd.Parameters.Add(CASE_REC_DATETIME);

            SqlParameter FATHER_NAME = new SqlParameter();
            FATHER_NAME.SqlDbType = SqlDbType.VarChar;
            FATHER_NAME.Value = txtFatherName.Text.Trim();
            FATHER_NAME.ParameterName = "@FATHER_NAME";
            sqlcmd.Parameters.Add(FATHER_NAME);

            SqlParameter DOB = new SqlParameter();
            DOB.SqlDbType = SqlDbType.VarChar;
            DOB.Value = txtdob.Text.Trim();
            DOB.ParameterName = "@DOB";
            sqlcmd.Parameters.Add(DOB);

            SqlParameter Address = new SqlParameter();
            Address.SqlDbType = SqlDbType.VarChar;
            Address.Value = txtAddress.Text.Trim();
            Address.ParameterName = "@Address";
            sqlcmd.Parameters.Add(Address);

            SqlParameter PHONE = new SqlParameter();
            PHONE.SqlDbType = SqlDbType.VarChar;
            PHONE.Value = txtPhone.Text.Trim();
            PHONE.ParameterName = "@PHONE";
            sqlcmd.Parameters.Add(PHONE);

            SqlParameter OFFNAME = new SqlParameter();
            OFFNAME.SqlDbType = SqlDbType.VarChar;
            OFFNAME.Value = txtCompName.Text.Trim();
            OFFNAME.ParameterName = "@OFFNAME";
            sqlcmd.Parameters.Add(OFFNAME);

            //////////Resi Add//////////////////////////////////
            SqlParameter PreviousResidenceAddress = new SqlParameter();
            PreviousResidenceAddress.SqlDbType = SqlDbType.VarChar;
            PreviousResidenceAddress.Value = txtEarAdd.Text.Trim();
            PreviousResidenceAddress.ParameterName = "@PreviousResidenceAddress";
            sqlcmd.Parameters.Add(PreviousResidenceAddress);

            SqlParameter PresentResidenceAddress = new SqlParameter();
            PresentResidenceAddress.SqlDbType = SqlDbType.VarChar;
            PresentResidenceAddress.Value = txtCurrAdd.Text.Trim();
            PresentResidenceAddress.ParameterName = "@PresentResidenceAddress";
            sqlcmd.Parameters.Add(PresentResidenceAddress);

            SqlParameter PermanentResidenceAddress = new SqlParameter();
            PermanentResidenceAddress.SqlDbType = SqlDbType.VarChar;
            PermanentResidenceAddress.Value = txtPermAdd.Text.Trim();
            PermanentResidenceAddress.ParameterName = "@PermanentResidenceAddress";
            sqlcmd.Parameters.Add(PermanentResidenceAddress);

            //////////Criminal//////////////////////////////////
            SqlParameter PreviousCriminalAddress = new SqlParameter();
            PreviousCriminalAddress.SqlDbType = SqlDbType.VarChar;
            PreviousCriminalAddress.Value = txtCrim_EarAdd.Text.Trim();
            PreviousCriminalAddress.ParameterName = "@PreviousCriminalAddress";
            sqlcmd.Parameters.Add(PreviousCriminalAddress);

            SqlParameter PresentCriminalAddress = new SqlParameter();
            PresentCriminalAddress.SqlDbType = SqlDbType.VarChar;
            PresentCriminalAddress.Value = txtCrim_CurrAdd.Text.Trim();
            PresentCriminalAddress.ParameterName = "@PresentCriminalAddress";
            sqlcmd.Parameters.Add(PresentCriminalAddress);

            SqlParameter PermanentCriminalAddress = new SqlParameter();
            PermanentCriminalAddress.SqlDbType = SqlDbType.VarChar;
            PermanentCriminalAddress.Value = txtCrim_PerAdd.Text.Trim();
            PermanentCriminalAddress.ParameterName = "@PermanentCriminalAddress";
            sqlcmd.Parameters.Add(PermanentCriminalAddress);

            //////////Court//////////////////////////////////
            SqlParameter PreviousCourtAddress = new SqlParameter();
            PreviousCourtAddress.SqlDbType = SqlDbType.VarChar;
            PreviousCourtAddress.Value = txtCourt_EarAdd.Text.Trim();
            PreviousCourtAddress.ParameterName = "@PreviousCourtAddress";
            sqlcmd.Parameters.Add(PreviousCourtAddress);

            SqlParameter PresentCourtAddress = new SqlParameter();
            PresentCourtAddress.SqlDbType = SqlDbType.VarChar;
            PresentCourtAddress.Value = txtCourt_CurrAdd.Text.Trim();
            PresentCourtAddress.ParameterName = "@PresentCourtAddress";
            sqlcmd.Parameters.Add(PresentCourtAddress);

            SqlParameter PermanentCourtAddress = new SqlParameter();
            PermanentCourtAddress.SqlDbType = SqlDbType.VarChar;
            PermanentCourtAddress.Value = txtCourt_PerAdd.Text.Trim();
            PermanentCourtAddress.ParameterName = "@PermanentCourtAddress";
            sqlcmd.Parameters.Add(PermanentCourtAddress);

            //////////CreditCard//////////////////////////////////
            SqlParameter CurrentCreditAddress = new SqlParameter();
            CurrentCreditAddress.SqlDbType = SqlDbType.VarChar;
            CurrentCreditAddress.Value = txtCredit_CurrAdd.Text.Trim();
            CurrentCreditAddress.ParameterName = "@CurrentCreditAddress";
            sqlcmd.Parameters.Add(CurrentCreditAddress);

            SqlParameter PanNo = new SqlParameter();
            PanNo.SqlDbType = SqlDbType.VarChar;
            PanNo.Value = txtCredit_PANcard.Text.Trim();
            PanNo.ParameterName = "@PanNo";
            sqlcmd.Parameters.Add(PanNo);

            //////////Education//////////////////////////////////
            SqlParameter Education_Details = new SqlParameter();
            Education_Details.SqlDbType = SqlDbType.VarChar;
            Education_Details.Value = hdnMainTab_First.Value.ToString();
            Education_Details.ParameterName = "@Eduction_Details";
            sqlcmd.Parameters.Add(Education_Details);

            //////////Emploment_Details//////////////////////////////////
            SqlParameter Emploment_Details = new SqlParameter();
            Emploment_Details.SqlDbType = SqlDbType.VarChar;
            Emploment_Details.Value = hdnMainTab_Second.Value.ToString();
            Emploment_Details.ParameterName = "@Employment_Details";
            sqlcmd.Parameters.Add(Emploment_Details);

            //////////Reference_Details//////////////////////////////////
            SqlParameter Reference_Details = new SqlParameter();
            Reference_Details.SqlDbType = SqlDbType.VarChar;
            Reference_Details.Value = hdnMainTab_Third.Value.ToString();
            Reference_Details.ParameterName = "@Reference_Details";
            sqlcmd.Parameters.Add(Reference_Details);


            ////Added by kamal matekar for KYC Details/////
            SqlParameter KYCDetails = new SqlParameter();
            KYCDetails.SqlDbType = SqlDbType.VarChar;
            KYCDetails.Value = hdnMainTab_Fourth.Value.ToString();//hdnMainTab_Third.Value.ToString(); 
            KYCDetails.ParameterName = "@KYCDetails";
            sqlcmd.Parameters.Add(KYCDetails);


            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Session["UserID"].ToString();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);


            sqlcmd.ExecuteNonQuery();
            ClearControl();
            lblMessage.Text = "Case Save Successfully................!"; 
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    private void ClearControl()
    {
        txtRefNo.Text = "";
        txtFirstName.Text = "";
        txtMidName.Text = "";
        txtLastName.Text = "";
        txtFatherName.Text = "";
        txtCompName.Text = "";
        txtdob.Text = "";
        txtRcvdDate.Text = "";
        txtAddress.Text = "";
        txtPhone.Text = "";
        chkVeriType.SelectedIndex = -1;
        txtCurrAdd.Text = "";
        txtEarAdd.Text = "";
        txtPermAdd.Text = "";
        hdnMainTab_First.Value = "";
        hdnMainTab_Second.Value = "";
        hdnMainTab_Third.Value = "";
        hdnMainTab_Fourth.Value = "";
        txtCrim_CurrAdd.Text = "";
        txtCrim_EarAdd.Text = "";
        txtCrim_PerAdd.Text = "";
        txtCourt_CurrAdd.Text = "";
        txtCourt_EarAdd.Text = "";
        txtCourt_PerAdd.Text = "";
        txtCredit_CurrAdd.Text = "";
        txtCredit_PANcard.Text = "";
        txtKYCHolderName.Text = "";
        txtKYCNO.Text = "";
        Validate_Verification();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveNewEntryData();
        ClearControl();
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    public string GetUniqueID(string sTableNm, string sPrefix)
    {
        Int32 iUniqueId = 0;
        string sSql = "";
        sSql = "Select Last_id  from Last_detail where table_name='" + sTableNm + "'" +
             " and prefix ='" + sPrefix + "'";

        OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, sSql);
        if (sqlRead.Read())
            iUniqueId = Convert.ToInt32(sqlRead[0].ToString());
        else
        {
            sSql = "Insert Into Last_detail values ('" + sTableNm + "','" + sPrefix + "',1)";
            OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, sSql);
            iUniqueId = 1;
        }

        sqlRead.Close();
        sSql = "Update Last_detail set Last_id=" + (iUniqueId + 1) +
               "where table_name='" + sTableNm + "' and prefix='" + sPrefix + "'";

        OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, sSql);

        return sPrefix + iUniqueId;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SearchMainData();
            SearchResiAddressInfo();
            SearchCriminalVeriInfo();
            SearchCourtVeriInfo();
            SearchCreditCheckInfo();
            SearchEducationInfo();
            SearchEmplomentInfo();
            SearchRefrenceCheckInfo();
            //SearchKYCDetails();//--Passport 
            SearchKYCPanCardDetails();
            Validate_Verification();
          
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;  
        }
    }
    private void SearchMainData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SearchMainData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter RefNo = new SqlParameter();
        RefNo.SqlDbType = SqlDbType.VarChar;
        RefNo.Value = txtRefNo.Text.Trim();
        RefNo.ParameterName = "@Ref_No";
        sqlcmd.Parameters.Add(RefNo);

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.Value = Convert.ToInt32(Session["ClientID"]);
        ClientID.ParameterName = "@ClientID";
        sqlcmd.Parameters.Add(ClientID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            hdnCaseId.Value = dt.Rows[0]["Case_id"].ToString().Trim();
            txtFirstName.Text = dt.Rows[0]["first_name"].ToString().Trim();
            txtMidName.Text = dt.Rows[0]["middle_name"].ToString().Trim();
            txtLastName.Text = dt.Rows[0]["last_name"].ToString().Trim();
            txtFatherName.Text = dt.Rows[0]["father_name"].ToString().Trim();
            txtCompName.Text = dt.Rows[0]["offname"].ToString().Trim();
            txtdob.Text = dt.Rows[0]["dob"].ToString().Trim();
            txtRcvdDate.Text = dt.Rows[0]["RcvdDate"].ToString().Trim();
            txtAddress.Text = dt.Rows[0]["add_line_1"].ToString().Trim();
            txtPhone.Text = dt.Rows[0]["phone1"].ToString().Trim();

            string VeriCode = dt.Rows[0]["verification_code"].ToString().Trim();
            string[] arrVeriCode = VeriCode.Split('+');
            if (arrVeriCode.Length > 0)
            {
                for (int i = 0; i < arrVeriCode.Length; i++)
                {
                    foreach (ListItem li in chkVeriType.Items)
                    {
                        if (li.Value == arrVeriCode.GetValue(i).ToString())
                            li.Selected = true;
                    }

                }
            }

            string BtnCode = "";
            BtnCode = dt.Rows[0]["SEND_DATETIME"].ToString().Trim();
            if (BtnCode == "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        else
        {
            lblMessage.Text = "Record Not Found......."; 
        }
    }
    private void SearchResiAddressInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SearchResiAddressInfo";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;  
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtCurrAdd.Text = dt.Rows[0]["CurrAddress"].ToString().Trim();
            txtEarAdd.Text = dt.Rows[0]["EarAddress"].ToString().Trim();
            txtPermAdd.Text = dt.Rows[0]["PerAddress"].ToString().Trim();
        }
    }
    private void SearchCriminalVeriInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SearchCriminalVeriInfo";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtCrim_CurrAdd.Text = dt.Rows[0]["CurrAddress"].ToString().Trim();
            txtCrim_EarAdd.Text = dt.Rows[0]["EarAddress"].ToString().Trim();
            txtCrim_PerAdd.Text = dt.Rows[0]["PerAddress"].ToString().Trim();
        }
    }
    private void SearchCourtVeriInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SearchCourtVeriInfo";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtCourt_CurrAdd.Text = dt.Rows[0]["CurrAddress"].ToString().Trim();
            txtCourt_EarAdd.Text = dt.Rows[0]["EarAddress"].ToString().Trim();
            txtCourt_PerAdd.Text = dt.Rows[0]["PerAddress"].ToString().Trim();
        }
    }
    private void SearchCreditCheckInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SearchCreditCheckInfo";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseId";
        sqlcmd.Parameters.Add(CaseId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtCredit_CurrAdd.Text = dt.Rows[0]["Verification_Address"].ToString().Trim();
            txtCredit_PANcard.Text = dt.Rows[0]["PanNo"].ToString().Trim();
        }
    }
    private void SearchEducationInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EBC_EducationDetails_Modify";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnEducationTypeId.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string EduDetails = "";
            for(int i=0; i<=dt.Rows.Count -1; i++)
            {
                EduDetails = EduDetails + dt.Rows[i]["EducationDetails"].ToString();   
            }
            hdnMainTab_First.Value = EduDetails.Trim(); 
        }
    }
    private void SearchEmplomentInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EBC_EmploymentDetails_Modify";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnEducationTypeId.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string EmployDetails = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                EmployDetails = EmployDetails + dt.Rows[i]["EmploymentDetails"].ToString();
            }
            hdnMainTab_Second.Value = EmployDetails.Trim();
        }
    }

    //---Kamal Matekar

    //private void SearchKYCDetails()
    //{
    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_EBC_KYCDetails_Modify";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter CaseId = new SqlParameter();
    //    CaseId.SqlDbType = SqlDbType.VarChar;
    //    CaseId.Value = hdnCaseId.Value;
    //    CaseId.ParameterName = "@CaseID";
    //    sqlcmd.Parameters.Add(CaseId);

    //    SqlParameter VerificationID = new SqlParameter();
    //    VerificationID.SqlDbType = SqlDbType.VarChar;
    //    VerificationID.Value = hdnEducationTypeId.Value;
    //    VerificationID.ParameterName = "@VerificationID";
    //    sqlcmd.Parameters.Add(VerificationID);

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);

    //    if (dt.Rows.Count > 0)
    //    {
    //        string KYCDetails = "";
    //        for (int i = 0; i <= dt.Rows.Count - 1; i++)
    //        {
    //            KYCDetails = KYCDetails + dt.Rows[i]["KYCDetails"].ToString();
    //        }
    //        hdnMainTab_Fourth.Value = KYCDetails.Trim();
    //    }
    //}

    //--Added by kamal matekar for KYC Pancard details

    private void SearchKYCPanCardDetails()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EBC_KYCPanCardDetails_Modify";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnKYCID.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string KYCDetails = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                KYCDetails = KYCDetails + dt.Rows[i]["KYCDetails"].ToString();
            }
            hdnMainTab_Fourth.Value = KYCDetails.Trim();
        }
    }

    private void SearchRefrenceCheckInfo()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EBC_ReferenceDetails_Modify";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = hdnCaseId.Value;
        CaseId.ParameterName = "@CaseID";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter VerificationID = new SqlParameter();
        VerificationID.SqlDbType = SqlDbType.VarChar;
        VerificationID.Value = hdnRefTypeId.Value;
        VerificationID.ParameterName = "@VerificationID";
        sqlcmd.Parameters.Add(VerificationID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string RefChechk = "";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                RefChechk = RefChechk + dt.Rows[i]["ReferenceDetails"].ToString();
            }
            hdnMainTab_Third.Value = RefChechk.Trim();
        }
    }
    protected void chkVeriType_DataBound(object sender, EventArgs e)
    {
        for (int i=0;i<=chkVeriType.Items.Count-1;i++)
        {
            chkVeriType.Items[i].Attributes.Add("onclick", "javascript:Activate_Panels('" + chkVeriType.ClientID + "','" + chkVeriType.Items[i].Text + "','"+i.ToString()+"');");

            
        }
    }
    protected void chkVeriType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Validate_Verification();
    }
    private void Enable_Controls(string PanelID,bool value)
    {
        if (PanelID == "RAV")
        {
            pnlRvVerification.Enabled = value;

            if ((value == true) && (hdnCaseId.Value ==String.Empty))
            {
               txtCurrAdd.Text=txtAddress.Text.Trim();
               
            }
            else if ((value == false) && (hdnCaseId.Value ==String.Empty))
            {
                txtCrim_CurrAdd.Text = "";
                txtCrim_EarAdd.Text = "";
                txtCrim_PerAdd.Text = "";
            }
        
        }
        if (PanelID == "EBC")
        {
            pnl_EBC.Enabled = value;


         }
         if (PanelID == "EMV")
         {
             pnlEmployment.Enabled = value;

             
         }
         if (PanelID == "CRV")
         {
             pnlCriminal.Enabled = value;
             if ((value == true) && (hdnCaseId.Value==String.Empty))
             {
                 txtCrim_CurrAdd.Text = txtCurrAdd.Text;
                 txtCrim_EarAdd.Text = txtEarAdd.Text;
                 txtCrim_PerAdd.Text = txtPermAdd.Text;
             }
             else if ((value == false )&&(hdnCaseId.Value==String.Empty))
             {
                 txtCrim_CurrAdd.Text = "";
                 txtCrim_EarAdd.Text = "";
                 txtCrim_PerAdd.Text = "";
                 
             }

         }
         if (PanelID == "CCV")
         {

             pnlCourtLitigation.Enabled = value;

             if ((value == true) && (hdnCaseId.Value == String.Empty))
             {
                 txtCourt_CurrAdd.Text = txtCurrAdd.Text;
                 txtCourt_EarAdd.Text = txtEarAdd.Text;
                 txtCourt_PerAdd.Text = txtPermAdd.Text;
             }
             else if ((value == false) && (hdnCaseId.Value == String.Empty))
             {
                 txtCourt_CurrAdd.Text = "";
                 txtCourt_EarAdd.Text = "";
                 txtCourt_PerAdd.Text = "";
                 
             }
         }
         if (PanelID == "CRCV")
         {

             pnlCreditCheck.Enabled = value;

             

             if ((value == true) && (hdnCaseId.Value == String.Empty))
             {
                 txtCredit_CurrAdd.Text = txtCurrAdd.Text;
                 
             }
             else if ((value == false) && (hdnCaseId.Value == String.Empty))
             {
                 txtCredit_CurrAdd.Text = "";
              
                 
             }
         }
         if (PanelID == "Ref_Chk")
         {

             pnlReferenceCheck.Enabled = value;
         }

         if (PanelID == "KYC")
         {

             pnlKYC.Enabled = value;
         }
        

    }
    protected void chkVeriType_DataBound1(object sender, EventArgs e)
    {
        
    }
    private void Validate_Verification()
    {
        string veriType = "";
        for (int i = 0; i <= chkVeriType.Items.Count - 1; i++)
        {
            veriType = chkVeriType.Items[i].Value;

            Enable_Controls(veriType, chkVeriType.Items[i].Selected);

        }
    
    }


}
