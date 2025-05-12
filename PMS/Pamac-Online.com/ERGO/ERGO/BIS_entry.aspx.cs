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

public partial class ERGO_ERGO_BIS_entry : System.Web.UI.Page
{

    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    string brgecode;

    
    protected void Page_Load(object sender, EventArgs e)
    {

        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            if (Request.QueryString["TID"] != null)
            {
                hdnBridgeCode.Value = Request.QueryString["TID"].ToString();
                // hdnPayeeName.Value = Request.QueryString["TName"].ToString();
                //Request.QueryString["TID"].ToString();
                txtBridgeCode.Text = hdnBridgeCode.Value;
                //txtPayeeName.Text = hdnPayeeName.Value;
                Get_Bridge_Code_Details(txtBridgeCode.Text.Trim());

            }

            RegisterControls_WithJavascript();
            //Get_Bridge_Code_Details(txtBridgeCode.Text.Trim());

        }

    }

    private void RegisterControls_WithJavascript()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate_Generate();");
        txtCityDistrict.Attributes.Add("onblur", "javascript:return CatchValuePayableLocation();");
        txtPayeeName.Attributes.Add("onblur", "javascript:return CatchValueDealerName();");
        //ddlBIS_Status.Attributes.Add("onblur", "javascript:return CatchValueDiscrepancy();");
    }

    private void Get_Bridge_Code_Details(string pBridgeCode)
    {

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_Ergo_BIS_BrigdeCodeDetails";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        SqlParameter Bridge_Code = new SqlParameter();
        Bridge_Code.SqlDbType = SqlDbType.VarChar;
        Bridge_Code.Value = pBridgeCode;
        Bridge_Code.ParameterName = "@Bridge_Code";
        sqlCom.Parameters.Add(Bridge_Code);

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblErrorMessage.Text = "";
            Assign_BridgeCode_Details(dt);
        }
        else
        {
            lblErrorMessage.Text = "No Records found!";
            lblErrorMessage.CssClass = "ErrorMessage";
        }
    }

    private void Assign_BridgeCode_Details(DataTable dt)
    {
        txtReceivedDate.Text = dt.Rows[0]["BIS_Recd_Date"].ToString();
        txtPanNo.Text = dt.Rows[0]["PAN_No"].ToString();
        ddlBIS_Status.SelectedValue = dt.Rows[0]["BIS_Status"].ToString();
        //txtTypeOfOrganisation.Text = dt.Rows[0]["Type_Of_Organisation"].ToString();
        ddlTypeOfOrganisation.SelectedValue = dt.Rows[0]["Type_Of_Organisation"].ToString();
        txtServiceTaxNo.Text = dt.Rows[0]["ServiceTaxNo"].ToString();
        txtMICRCode.Text = dt.Rows[0]["MICR_Code"].ToString();
        txtBranchName.Text = dt.Rows[0]["Bank_Branch_Name"].ToString();
        txtAccountNo.Text = dt.Rows[0]["Account_No"].ToString();
        txtApartmentName.Text = dt.Rows[0]["House_Apartment_Name"].ToString();
        txtStreetLocalityName.Text = dt.Rows[0]["Street_Locality_Name"].ToString();
        txtAreaVillage.Text = dt.Rows[0]["Area_Village"].ToString();
        txtBankName.Text = dt.Rows[0]["Bank_Name"].ToString();
        txtCityDistrict.Text = dt.Rows[0]["City_District"].ToString();
        txtDealerName.Text = dt.Rows[0]["Dealer_Name"].ToString();
        txtMobileNo.Text = dt.Rows[0]["Mobile_No"].ToString();
        txtPayableLocation.Text = dt.Rows[0]["Payable_Location"].ToString();
        txtPayeeName.Text = dt.Rows[0]["Alternate_Payee_Name"].ToString();
        txtPinCode.Text = dt.Rows[0]["DEALER_PIN_CODE"].ToString();
        ddlDiscrepancy.SelectedValue = dt.Rows[0]["Discrepancy"].ToString();
        ddlServiceTaxApplicable.SelectedValue = dt.Rows[0]["ServiceTaxApplicable"].ToString();
        ddlServiceTaxRecd.SelectedValue = dt.Rows[0]["ServiceCopyRecd"].ToString();
        ddlState.SelectedValue = dt.Rows[0]["State"].ToString();
        txtIFSCCode.Text = dt.Rows[0]["IFSC_CODE"].ToString();
        txtdiscrepancyType.Text = dt.Rows[0]["discrepancyType"].ToString();
        txtTDSRate.Text = dt.Rows[0]["TDS_Rate"].ToString();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_BIS_Data();
    }

    private void Insert_BIS_Data()
    {
        try
        {



            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_BIS_Master_Data";

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = txtBridgeCode.Text.Trim();
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlCom.Parameters.Add(Bridge_Code);

            SqlParameter BIS_Recd_Date = new SqlParameter();
            BIS_Recd_Date.SqlDbType = SqlDbType.VarChar;
            BIS_Recd_Date.Value = txtReceivedDate.Text.Trim();
            BIS_Recd_Date.ParameterName = "@BIS_Recd_Date";
            sqlCom.Parameters.Add(BIS_Recd_Date);

            SqlParameter Type_Of_Organisation = new SqlParameter();
            Type_Of_Organisation.SqlDbType = SqlDbType.VarChar;
            Type_Of_Organisation.Value = ddlTypeOfOrganisation.SelectedItem.Value.ToString().Trim();
            Type_Of_Organisation.ParameterName = "@Type_Of_Organisation";
            sqlCom.Parameters.Add(Type_Of_Organisation);

            SqlParameter PAN_No = new SqlParameter();
            PAN_No.SqlDbType = SqlDbType.VarChar;
            PAN_No.Value = txtPanNo.Text.Trim();
            PAN_No.ParameterName = "@PAN_No";
            sqlCom.Parameters.Add(PAN_No);

            SqlParameter Account_No = new SqlParameter();
            Account_No.SqlDbType = SqlDbType.VarChar;
            Account_No.Value = txtAccountNo.Text.Trim();
            Account_No.ParameterName = "@Account_No";
            sqlCom.Parameters.Add(Account_No);

            SqlParameter Mobile_No = new SqlParameter();
            Mobile_No.SqlDbType = SqlDbType.VarChar;
            Mobile_No.Value = txtMobileNo.Text.Trim();
            Mobile_No.ParameterName = "@Mobile_No";
            sqlCom.Parameters.Add(Mobile_No);


            SqlParameter Bank_Name = new SqlParameter();
            Bank_Name.SqlDbType = SqlDbType.VarChar;
            Bank_Name.Value = txtBankName.Text.Trim();
            Bank_Name.ParameterName = "@Bank_Name";
            sqlCom.Parameters.Add(Bank_Name);

            SqlParameter Bank_Branch_Name = new SqlParameter();
            Bank_Branch_Name.SqlDbType = SqlDbType.VarChar;
            Bank_Branch_Name.Value = txtBranchName.Text.Trim();
            Bank_Branch_Name.ParameterName = "@Bank_Branch_Name";
            sqlCom.Parameters.Add(Bank_Branch_Name);

            //int intMICR_Code = 0;
            //if (txtMICRCode.Text != "")
            //{
            //    intMICR_Code = Convert.ToInt32(txtMICRCode.Text.Trim());
            //}

            SqlParameter MICR_Code = new SqlParameter();
            MICR_Code.SqlDbType = SqlDbType.VarChar;
            MICR_Code.Value = txtMICRCode.Text.Trim();//intMICR_Code;
            MICR_Code.ParameterName = "@MICR_Code";
            sqlCom.Parameters.Add(MICR_Code);

            SqlParameter ServiceTaxApplicable = new SqlParameter();
            ServiceTaxApplicable.SqlDbType = SqlDbType.VarChar;
            ServiceTaxApplicable.Value = ddlServiceTaxApplicable.SelectedItem.Value.ToString().Trim();
            ServiceTaxApplicable.ParameterName = "@ServiceTaxApplicable";
            sqlCom.Parameters.Add(ServiceTaxApplicable);

            //int intServicetax = 0;
            //if (txtServiceTaxNo.Text != "")
            //{
            //    intServicetax = Convert.ToInt32(txtServiceTaxNo.Text.Trim());
            //}

            SqlParameter ServiceTaxNo = new SqlParameter();
            ServiceTaxNo.SqlDbType = SqlDbType.VarChar;
            ServiceTaxNo.Value = txtServiceTaxNo.Text.Trim();//intServicetax;
            ServiceTaxNo.ParameterName = "@ServiceTaxNo";
            sqlCom.Parameters.Add(ServiceTaxNo);

            SqlParameter ServiceCopyRecd = new SqlParameter();
            ServiceCopyRecd.SqlDbType = SqlDbType.VarChar;
            ServiceCopyRecd.Value = ddlServiceTaxRecd.SelectedItem.Value.ToString().Trim();
            ServiceCopyRecd.ParameterName = "@ServiceCopyRecd";
            sqlCom.Parameters.Add(ServiceCopyRecd);

            SqlParameter Alternate_Payee_Name = new SqlParameter();
            Alternate_Payee_Name.SqlDbType = SqlDbType.VarChar;
            Alternate_Payee_Name.Value = txtPayeeName.Text.Trim();
            Alternate_Payee_Name.ParameterName = "@Alternate_Payee_Name";
            sqlCom.Parameters.Add(Alternate_Payee_Name);

            SqlParameter Dealer_Name = new SqlParameter();
            Dealer_Name.SqlDbType = SqlDbType.VarChar;
            Dealer_Name.Value = txtDealerName.Text.Trim();
            Dealer_Name.ParameterName = "@Dealer_Name";
            sqlCom.Parameters.Add(Dealer_Name);

            SqlParameter House_Apartment_Name = new SqlParameter();
            House_Apartment_Name.SqlDbType = SqlDbType.VarChar;
            House_Apartment_Name.Value = txtApartmentName.Text.Trim();
            House_Apartment_Name.ParameterName = "@House_Apartment_Name";
            sqlCom.Parameters.Add(House_Apartment_Name);


            SqlParameter Street_Locality_Name = new SqlParameter();
            Street_Locality_Name.SqlDbType = SqlDbType.VarChar;
            Street_Locality_Name.Value = txtStreetLocalityName.Text.Trim();
            Street_Locality_Name.ParameterName = "@Street_Locality_Name";
            sqlCom.Parameters.Add(Street_Locality_Name);

            SqlParameter Area_Village = new SqlParameter();
            Area_Village.SqlDbType = SqlDbType.VarChar;
            Area_Village.Value = txtAreaVillage.Text.Trim();
            Area_Village.ParameterName = "@Area_Village";
            sqlCom.Parameters.Add(Area_Village);

            SqlParameter City_District = new SqlParameter();
            City_District.SqlDbType = SqlDbType.VarChar;
            City_District.Value = txtCityDistrict.Text.Trim();
            City_District.ParameterName = "@City_District";
            sqlCom.Parameters.Add(City_District);


            //int intPinCode = 0;
            //if (txtPinCode.Text != "")
            //{
            //    intPinCode = Convert.ToInt32(txtPinCode.Text.Trim());
            //}

            SqlParameter DEALER_PIN_CODE = new SqlParameter();
            DEALER_PIN_CODE.SqlDbType = SqlDbType.VarChar;
            DEALER_PIN_CODE.Value = txtPinCode.Text.Trim();//intPinCode;
            DEALER_PIN_CODE.ParameterName = "@DEALER_PIN_CODE";
            sqlCom.Parameters.Add(DEALER_PIN_CODE);

            SqlParameter State = new SqlParameter();
            State.SqlDbType = SqlDbType.VarChar;
            State.Value = ddlState.SelectedItem.Value.ToString().Trim();
            State.ParameterName = "@State";
            sqlCom.Parameters.Add(State);

            SqlParameter Payable_Location = new SqlParameter();
            Payable_Location.SqlDbType = SqlDbType.VarChar;
            Payable_Location.Value = txtPayableLocation.Text.Trim();
            Payable_Location.ParameterName = "@Payable_Location";
            sqlCom.Parameters.Add(Payable_Location);

            SqlParameter BIS_Status = new SqlParameter();
            BIS_Status.SqlDbType = SqlDbType.VarChar;
            BIS_Status.Value = ddlBIS_Status.SelectedItem.Value.ToString().Trim();
            BIS_Status.ParameterName = "@BIS_Status";
            sqlCom.Parameters.Add(BIS_Status);

            SqlParameter Discrepancy = new SqlParameter();
            Discrepancy.SqlDbType = SqlDbType.VarChar;
            Discrepancy.Value = ddlDiscrepancy.Text.Trim();
            Discrepancy.ParameterName = "@Discrepancy";
            sqlCom.Parameters.Add(Discrepancy);

            SqlParameter IFSC_CODE = new SqlParameter();
            IFSC_CODE.SqlDbType = SqlDbType.VarChar;
            IFSC_CODE.Value = txtIFSCCode.Text.Trim();
            IFSC_CODE.ParameterName = "@IFSC_CODE";
            sqlCom.Parameters.Add(IFSC_CODE);

            SqlParameter discrepancyType = new SqlParameter();
            discrepancyType.SqlDbType = SqlDbType.VarChar;
            discrepancyType.Value = txtdiscrepancyType.Text.Trim();
            discrepancyType.ParameterName = "@discrepancyType";
            sqlCom.Parameters.Add(discrepancyType);

            SqlParameter TDS_Rate = new SqlParameter();
            TDS_Rate.SqlDbType = SqlDbType.VarChar;
            TDS_Rate.Value = txtTDSRate.Text.Trim();
            TDS_Rate.ParameterName = "@TDS_Rate";
            sqlCom.Parameters.Add(TDS_Rate);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value =Session["Userid"].ToString();
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);
            hdnBridgeCode.Value = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);
            sqlcon.Close();

            if (RowEffected != "")
            {
                //Update_Ergo_Billing_Details_ifBISNotExist();Rupesh temp
                lblErrorMessage.CssClass = "SuccessMessage";
                lblErrorMessage.Text = RowEffected;
                lblErrorMessage.Visible = true;

            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;

        }

    }

    private void bgidge()
    {
          try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_bridgecode";//"Insert_BillingMasterData";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                brgecode = dt.Rows[k]["Bridge_code"].ToString();

                Update_Ergo_Billing_Details_ifBISNotExist(brgecode);
            }

            sqlcon.Close();
                          

        }       
          catch (Exception ex)
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = ex.Message;
        }

    }

    private void Update_Ergo_Billing_Details_ifBISNotExist(string brgecode)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            //sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Update_Ergo_Billing_Details";//"Insert_BillingMasterData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = brgecode;
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);


            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            //sqlcon.Close();

            if (RowEffected > 0)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Record Save Successfuly";
            }

        }
        catch (Exception ex)
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = ex.Message;
        }

    }



    protected void btnSearchExist_Click(object sender, EventArgs e)
    {
        if (txtBridgeCode.Text != "")
        {
            Get_BridgeCodeStatus(txtBridgeCode.Text.Trim());

        }
        else
        {
            lblErrorMessage.Text = "Please enter BridgeCode Continue;";
        }

    }

    private void Get_BridgeCodeStatus(string pApplicationNO)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];


            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Ergo_BriddeCode_Status";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = pApplicationNO;
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlCom.Parameters.Add(Bridge_Code);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.Int;
            Status.Value = 0;
            Status.ParameterName = "@Status";
            Status.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Status);

            sqlCom.ExecuteNonQuery();
            int RowEffected = Convert.ToInt32(sqlCom.Parameters["@Status"].Value);
            sqlcon.Close();

            if (RowEffected == 1)
            {
                txtBridgeCode.ReadOnly = false;
                lblErrorMessage.Text = "Bridge Code Already Exist!";
                Get_Bridge_Code_Details(txtBridgeCode.Text.Trim());
                //btnSave.Visible = false;
                ///btnDiscrepancy.Visible = false;
                lblErrorMessage.CssClass = "ErrorMessage";

            }
            else
            {
                lblErrorMessage.Text = "New Bridge Code!";
                btnSave.Visible = true;
                // btnDiscrepancy.Visible = true;
                txtBridgeCode.ReadOnly = true;
                lblErrorMessage.CssClass = "SuccessMessage";

            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.CssClass = "ErrorMessage";
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = ex.Message;

        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");

    }

    protected void btnDiscrepancy_Click(object sender, EventArgs e)
    {
        ////Response.Redirect("Discrepancy Data.aspx", true); 
        //Response.Redirect("Discrepancy_Data_New.aspx", true); Rupesh

        bgidge();
    }

    protected void txtPanNo_TextChanged(object sender, EventArgs e)
    {
        if (txtPanNo.Text != "")
        {
            if (txtPanNo.Text.Trim().Length <= 9)
            {
                lblApplicantPANno.Text = "Pan code should be 10 digit";
            }
            else
            {
                Get_PanNO_Status(txtPanNo.Text.Trim());
            }
        }

    }

    private void Get_PanNO_Status(string pPanNo)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];


            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Ergo_PanNO_Status";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter PanNO = new SqlParameter();
            PanNO.SqlDbType = SqlDbType.VarChar;
            PanNO.Value = pPanNo.Trim();
            PanNO.ParameterName = "@PanNO";
            sqlCom.Parameters.Add(PanNO);

            SqlParameter Message = new SqlParameter();
            Message.SqlDbType = SqlDbType.VarChar;
            Message.Value = pPanNo.Trim();
            Message.ParameterName = "@Message";
            Message.Size = 200;
            sqlCom.Parameters.Add(Message);
            Message.Direction = ParameterDirection.Output;

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@Message"].Value);

            sqlcon.Close();

            lblApplicantPANno.Text = RowEffected;


        }
        catch (Exception ex)
        {
            lblErrorMessage.CssClass = "ErrorMessage";
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = ex.Message;

        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        txtAccountNo.Text = "";
        txtApartmentName.Text = "";
        txtAreaVillage.Text = "";
        txtBankName.Text = "";
        txtBranchName.Text = "";
        txtBridgeCode.Text = "";
        txtCityDistrict.Text = "";
        txtDealerName.Text = "";
        txtdiscrepancyType.Text = "";
        txtIFSCCode.Text = "";
        txtMICRCode.Text = "";
        txtMobileNo.Text = "";
        txtPanNo.Text = "";
        txtPayableLocation.Text = "";
        txtPayeeName.Text = "";
        txtPinCode.Text = "";
        txtReceivedDate.Text = "";
        txtServiceTaxNo.Text = "";
        txtStreetLocalityName.Text = "";
        ddlBIS_Status.SelectedIndex = 0;
        ddlDiscrepancy.SelectedIndex = 0;
        ddlServiceTaxApplicable.SelectedIndex = 0;
        ddlServiceTaxRecd.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlTypeOfOrganisation.SelectedIndex = 0;

    }
}
