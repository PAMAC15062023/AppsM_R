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

public partial class Admin_Assets_Inventory_Assets_InventoryUpdation : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAssetTypeMaster();
            Get_ClusterList();
            Get_EmployeeDetails();
            GetSubCentreList();
            GetCentreList();
            BindStatus();
            //add on 30/01/24>>
            //ddlStatus.Items[2].Enabled = false; //Declare Scrap
            ddlStatus.Items[3].Enabled = false; //Open
            ddlStatus.Items[4].Enabled = false; //Reject
            //ddlStatus.Items[5].Enabled = false; //Replace
            //ddlStatus.Items[6].Enabled = false; //Returned  to Vendor
            //ddlStatus.Items[7].Enabled = false; //Scrap
            //ddlStatus.Items[8].Enabled = false; //Sold
            //ddlStatus.Items[9].Enabled = false; //Transferred to Other Branch
            //ddlStatus.Items[10].Enabled = false; //Transferred to other PAMACian
            //<<add on 30/01/24
            BindAssetLocation();

            BtnTransfer.Visible = false;
            pnlTransfer.Visible = false;
            txtAmtRecvSale.Visible = true;
            txtAmtRecvSale.Text = "";
            //lblDepoDate.Visible = true;
            //txtDepositeDate.Visible = true;
            //txtDepositeDate.Text = "";
            lblBranchTrans.Visible = true;
            ddlCenterList.Visible = true;
            ddlCenterList.SelectedIndex = 0;
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;
            txtApprovalAuth.Text = "";
            txtSSRDate.Visible = true;


            // PnlRejectedAssets.Visible = false; Suhani 02/09/2024

            txtSSRDate.Enabled = true;
            txtSSRDate.Text = "";

            Pnlwrnt.Visible = false;

            string User = Session["Userid"].ToString();

            if (User == "101103516" || User == "101103517")//|| User == "101144683"
            {

            }
            else
            {
            }

            SaveValidation();

            ddlAssetsRating.Visible = false;
            lblAssetsRating.Visible = false;
            ddlSecurityRating.Visible = false;
            lblSecurityRating.Visible = false;

            BindAssetsRating();
            BindSecurityRating();

            if (Request.QueryString["Transrefno"] != null && Request.QueryString["Transrefno"] != "" && Request.QueryString["EMP_Code"] != null && Request.QueryString["EMP_Code"] != "")
            {
                txtsearchcode.Text = Request.QueryString["EMP_Code"];

                

                Get_EmployeeDetailsnew();
                ddlEmpName.SelectedValue = hdnEmployeeID.Value;
                GetEmpCode();
                GetGridData();
               
                //ClearData();
                pnlTransfer.Visible = false;
            }


        }



    }

    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");

    }

    protected void BindStatus()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_BindStatusMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlStatus.DataTextField = "Status";
                ddlStatus.DataValueField = "Status";
                ddlStatus.DataSource = ds.Tables[0];
                ddlStatus.DataBind();

                ddlStatus.Items.Insert(0, "--Select--");
                ddlStatus.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BindAssetLocation()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_BindAssetLocationMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlAssetLocation.DataTextField = "Location";
                ddlAssetLocation.DataValueField = "Location";
                ddlAssetLocation.DataSource = ds.Tables[0];
                ddlAssetLocation.DataBind();

                ddlAssetLocation.Items.Insert(0, "--Select--");
                ddlAssetLocation.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void Get_ClusterList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ClusterMaster";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlclustername.DataTextField = "CLUSTER_NAME";
            ddlclustername.DataValueField = "CLUSTER_ID";

            ddlclustername.DataSource = dt;
            ddlclustername.DataBind();

            ddlclustername.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    private void GetCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_CentreName1";//"Get_CentreName";
        sqlcmd.CommandTimeout = 0;

        SqlParameter ClusterID = new SqlParameter();
        ClusterID.SqlDbType = SqlDbType.VarChar;
        ClusterID.Value = ddlclustername.SelectedValue.ToString();
        ClusterID.ParameterName = "@ClusterID";
        sqlcmd.Parameters.Add(ClusterID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        sqlcon.Open();

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCenterList.DataTextField = "Centre_name";
            ddlCenterList.DataValueField = "centre_id";

            ddlCenterList.DataSource = dt;
            ddlCenterList.DataBind();

            ddlCenterList.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    private void GetSubCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.CommandText = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
        //sqlcmd.CommandText = "Get_SubCentername";
        sqlcmd.CommandTimeout = 0;


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlSubCentre.DataTextField = "SubCentreName";
            ddlSubCentre.DataValueField = "SubCentreId";

            ddlSubCentre.DataSource = dt;
            ddlSubCentre.DataBind();

            ddlSubCentre.Items.Insert(0, new ListItem("--All--", "0"));
        }

    }

    private void GetSubCentreName()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubCenternameReports";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Clusterid = new SqlParameter();
        Clusterid.SqlDbType = SqlDbType.VarChar;
        Clusterid.Value = ddlclustername.SelectedValue.ToString();
        Clusterid.ParameterName = "@Clusterid";
        sqlcmd.Parameters.Add(Clusterid);

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCenterList.SelectedValue.ToString();
        CentreId.ParameterName = "@Centreid";
        sqlcmd.Parameters.Add(CentreId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        sqlcon.Open();

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlsubcentrename.DataTextField = "SubCentreName";
            ddlsubcentrename.DataValueField = "SubCentreId";

            ddlsubcentrename.DataSource = dt;
            ddlsubcentrename.DataBind();

            ddlsubcentrename.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    private void Get_Empname()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Empname";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Centre_id = new SqlParameter();
        Centre_id.SqlDbType = SqlDbType.VarChar;
        Centre_id.Value = ddlCenterList.SelectedValue.ToString();
        Centre_id.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(Centre_id);

        SqlParameter Subcentre_id = new SqlParameter();
        Subcentre_id.SqlDbType = SqlDbType.VarChar;
        Subcentre_id.Value = ddlsubcentrename.SelectedValue.ToString();
        Subcentre_id.ParameterName = "@Subcentre_id";
        sqlcmd.Parameters.Add(Subcentre_id);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlpamaciantransfer.DataTextField = "fullname";
            ddlpamaciantransfer.DataValueField = "Emp_id";


            ddlpamaciantransfer.DataSource = dt;
            ddlpamaciantransfer.DataBind();
            ddlpamaciantransfer.SelectedIndex = 0;

        }
        else
        {
            ddlpamaciantransfer.DataSource = null;
            ddlpamaciantransfer.DataBind();
        }


    }

    private void Get_EmpnameNew()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmpnameNew"; //Get_Empsearch1//"Get_EmpnameNew1234";
        sqlcmd.CommandTimeout = 0;

        //SqlParameter Centre_id = new SqlParameter();
        //Centre_id.SqlDbType = SqlDbType.VarChar;
        //Centre_id.Value = ddlCenterList.SelectedValue.ToString();
        //Centre_id.ParameterName = "@Centre_id";
        //sqlcmd.Parameters.Add(Centre_id);

        SqlParameter emp_code = new SqlParameter();
        emp_code.SqlDbType = SqlDbType.VarChar;
        emp_code.Value = txtsearch2.Text.Trim();
        emp_code.ParameterName = "@emp_code";
        sqlcmd.Parameters.Add(emp_code);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlpamaciantransfer.DataTextField = "fullname";
            ddlpamaciantransfer.DataValueField = "Emp_id";


            ddlpamaciantransfer.DataSource = dt;
            ddlpamaciantransfer.DataBind();
            ddlpamaciantransfer.SelectedIndex = 0;
            HdnTransEmpName.Value = dt.Rows[0]["Fullname"].ToString();
        }
        else
        {
            ddlpamaciantransfer.DataSource = null;
            ddlpamaciantransfer.DataBind();
        }


    }

    private void Get_EmployeeDetails()
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails";//Get_EmployeeDetails
        sqlcmd.CommandTimeout = 0;

        //SqlParameter UserId = new SqlParameter();
        //UserId.SqlDbType = SqlDbType.VarChar;
        //UserId.Value = Session["CentreId"].ToString();
        //UserId.ParameterName = "@centreid";
        //sqlcmd.Parameters.Add(UserId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlEmpName.DataTextField = "fullname";
            ddlEmpName.DataValueField = "Emp_id";

            ddlEmpName.DataSource = dt;
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlEmpName.DataSource = null;
            ddlEmpName.DataBind();
        }

        //ddlEmpName.Items.Insert(0, new ListItem("--Select--", "0"));
        //ddlEmpName.Items.Insert(0, new ListItem("Other", "101146948"));
        //ddlEmpName.Items.Insert(1, new ListItem("AASSETS  TRANSFER", "101147511")); 

        //ddlEmpName.SelectedIndex = 0;  
    }

    protected bool CheckStatus()
    {
        string msg = string.Empty;
        bool validation = false;

        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand("PMS_CheckAssetStatus_SP", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@TransRefNo", hdnTransRefNo.Value);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds != null && ds.Tables.Count > 0)
        {
            msg = ds.Tables[0].Rows[0]["Status"].ToString();
            if (msg == "Declare Scrap")
            {
                validation = true;
            }
        }

        return validation;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool IsDeclareScrap = false;
        lblMessage.Text = "";

        try
        {

            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            string Proc;

            string msg = string.Empty;

            if (ddlStatus.SelectedItem.Text == "Scrap")
            {
                IsDeclareScrap = CheckStatus();
            }
            if (ddlStatus.SelectedItem.Text == "Scrap" && IsDeclareScrap == false)
            {
                lblMessage.Text = "Please first select declare scrap to select scrap";
                return;
            }


            if (ddlStatus.SelectedValue.ToString() == "--Select--")
            {
                msg = msg + "Please Select Status ";
            }

            if (ddlOwneName.SelectedItem.Text == "Owned")
            {
                if (txtPurchaseCost.Text.Trim() == "" || txtPurchaseCost.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Purchase Cost";
                }
                if (txtPurchaseDate.Text.Trim() == "" || txtPurchaseDate.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Purchase Date";
                }
            }
            if (ddlOwneName.SelectedItem.Text == "Rented")
            {
                if (txtRentAmt.Text.Trim() == "" || txtRentAmt.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Rented Amount";
                }
                if (txtVenderName.Text.Trim() == "" || txtVenderName.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Vender Name";
                }
                if (txtDate.Text.Trim() == "" || txtDate.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Rented Date";
                }
                if (txtVendorAssetNumber.Text.Trim() == "" || txtVendorAssetNumber.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Vendor Asset Number/Rental System Numbe";
                }

            }

            if (ddlEmpName.SelectedValue == "0" || ddlEmpName.SelectedValue == "" || ddlEmpName.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select User Name";
            }

            if (ddlAssetsType.SelectedValue == "-Select-")
            {
                msg = msg + "Please Select Assets Type";
            }
            if (ddlAssetLocation.SelectedValue.ToString() == "--Select--")
            {
                msg = msg + "Please Asset Location";
            }

            if (ddlStatus.SelectedValue.ToString() == "Available")
            {
                if (hdnIsITAssets.Value == "Yes")
                {
                    if (ddlAssetsRating.SelectedValue.ToString() == "--Select--")
                    {
                        msg = msg + "Please Select Assets Rating ";
                    }
                    if (ddlSecurityRating.SelectedValue.ToString() == "--Select--")
                    {
                        msg = msg + "Please Select Security Rating ";
                    }
                }
            }

            if(ddlOwneName.SelectedItem.Text == "Rented" && txtAmc.Text.Trim() == "")
            {
                msg = msg + "Please Enter Warranty/AMC";
            }

            if (ddlOwneName.SelectedItem.Text == "Rented" && txtAmcInfo.Text.Trim() == "")
            {
                msg = msg + "Please Enter AMC Info";
            }

            if (txtDateOfApproval.Text.Trim() == "" || txtDateOfApproval.Text.Trim() == null )
            {
                msg = msg + "Please Enter Date Of Approval.";
            }

            if (msg != "")
            {
                lblMessage.Text = msg;
                return;
            }

            if (ddlStatus.SelectedValue.ToString() == "Available")
            {
                Proc = "Insert_AssetsInventoryData";//"Insert_AssetsInventoryData1";//"Insert_AssetsInventoryData";
            }
            else if (ddlStatus.SelectedValue.ToString() == "Declare Scrap")
            {
                Proc = "Insert_AssetsInventoryDataDeclareScrap";
            }
            else
            {
                Proc = "Insert_AssetsInventoryDataScrap";
            }

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Proc;
            sqlcmd.CommandTimeout = 0;

            string sEmpId;
            string sEmpCode;
            string sTransrefno;




            if (ddlEmpName.SelectedValue == "101146948")
            {
                //sEmpId = ddlEmpName.SelectedValue.ToString() + '-' + ddlAssetsType.SelectedValue.ToString();
                //sEmpCode = "Test001";
                sEmpId = "101146948";
                sEmpCode = "Other" + ddlAssetsType.SelectedValue.ToString();
                sTransrefno = hdnTransRefNo.Value;

            }
            else
            {
                sEmpId = ddlEmpName.SelectedValue.ToString();
                sEmpCode = hdnEmpCode.Value;
                sTransrefno = hdnTransRefNo.Value;
            }

            if (sEmpId == "0" || sEmpId == "" || sEmpId == "--Select--")
            {
                msg = msg + "Please Select User Name";
            }

            if (msg != "")
            {
                lblMessage.Text = msg;
                return;
            }

            SqlParameter Emp_Id = new SqlParameter();
            Emp_Id.SqlDbType = SqlDbType.VarChar;
            Emp_Id.Value = sEmpId;
            Emp_Id.ParameterName = "@Emp_Id";
            sqlcmd.Parameters.Add(Emp_Id);

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = sEmpCode;
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = ddlEmpName.SelectedItem.ToString().Trim();
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter Vertical_Name = new SqlParameter();
            Vertical_Name.SqlDbType = SqlDbType.VarChar;
            Vertical_Name.Value = ddlVerticalName.SelectedValue.ToString().Trim();
            Vertical_Name.ParameterName = "@Vertical_Name";
            sqlcmd.Parameters.Add(Vertical_Name);

            SqlParameter Assets_Type = new SqlParameter();
            Assets_Type.SqlDbType = SqlDbType.VarChar;
            Assets_Type.Value = ddlAssetsType.SelectedValue.ToString();
            Assets_Type.ParameterName = "@Assets_Type";
            sqlcmd.Parameters.Add(Assets_Type);

            SqlParameter Purchase_Cost = new SqlParameter();
            Purchase_Cost.SqlDbType = SqlDbType.VarChar;
            Purchase_Cost.Value = txtPurchaseCost.Text.Trim();
            Purchase_Cost.ParameterName = "@Purchase_Cost";
            sqlcmd.Parameters.Add(Purchase_Cost);

            SqlParameter Purchase_Date = new SqlParameter();
            Purchase_Date.SqlDbType = SqlDbType.VarChar;//-----DateTime
            Purchase_Date.Value = txtPurchaseDate.Text.Trim();//strDate(txtPurchaseDate.Text.Trim());
            Purchase_Date.ParameterName = "@Purchase_Date";
            sqlcmd.Parameters.Add(Purchase_Date);

            SqlParameter Amc = new SqlParameter();
            Amc.SqlDbType = SqlDbType.VarChar;
            Amc.Value = txtAmc.Text.Trim();
            Amc.ParameterName = "@Amc";
            sqlcmd.Parameters.Add(Amc);

            SqlParameter Amc_Info = new SqlParameter();
            Amc_Info.SqlDbType = SqlDbType.VarChar;
            Amc_Info.Value = txtAmcInfo.Text.Trim();
            Amc_Info.ParameterName = "@Amc_Info";
            sqlcmd.Parameters.Add(Amc_Info);

            SqlParameter Owner_Name = new SqlParameter();
            Owner_Name.SqlDbType = SqlDbType.VarChar;
            Owner_Name.Value = ddlOwneName.SelectedValue.ToString();
            Owner_Name.ParameterName = "@Owner_Name";
            sqlcmd.Parameters.Add(Owner_Name);

            SqlParameter Rent_Amt = new SqlParameter();
            Rent_Amt.SqlDbType = SqlDbType.VarChar;
            Rent_Amt.Value = txtRentAmt.Text.Trim();
            Rent_Amt.ParameterName = "@Rent_Amt";
            sqlcmd.Parameters.Add(Rent_Amt);

            SqlParameter Vender_Name = new SqlParameter();
            Vender_Name.SqlDbType = SqlDbType.VarChar;
            Vender_Name.Value = txtVenderName.Text.Trim();
            Vender_Name.ParameterName = "@Vender_Name";
            sqlcmd.Parameters.Add(Vender_Name);

            SqlParameter Vender_Date = new SqlParameter();
            Vender_Date.SqlDbType = SqlDbType.VarChar;
            Vender_Date.Value = txtDate.Text.Trim();
            Vender_Date.ParameterName = "@Vender_Date";
            sqlcmd.Parameters.Add(Vender_Date);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = ddlStatus.SelectedValue.ToString();
            Status.ParameterName = "@Status";
            sqlcmd.Parameters.Add(Status);

            //SqlParameter Deposite_Date = new SqlParameter();
            //Deposite_Date.SqlDbType = SqlDbType.VarChar;
            //Deposite_Date.Value = txtDepositeDate.Text.Trim();
            //Deposite_Date.ParameterName = "@Deposite_Date";
            //sqlcmd.Parameters.Add(Deposite_Date);

            SqlParameter Transfer_Branch = new SqlParameter();
            Transfer_Branch.SqlDbType = SqlDbType.VarChar;
            Transfer_Branch.Value = ddlCenterList.SelectedValue.ToString();
            Transfer_Branch.ParameterName = "@Transfer_Branch";
            sqlcmd.Parameters.Add(Transfer_Branch);

            SqlParameter AppAuth_Name = new SqlParameter();
            AppAuth_Name.SqlDbType = SqlDbType.VarChar;
            AppAuth_Name.Value = txtApprovalAuth.Text.Trim();
            AppAuth_Name.ParameterName = "@AppAuth_Name";
            sqlcmd.Parameters.Add(AppAuth_Name);

            SqlParameter Unit = new SqlParameter();
            Unit.SqlDbType = SqlDbType.VarChar;
            Unit.Value = txtUnit.Text.Trim();
            Unit.ParameterName = "@Unit";
            sqlcmd.Parameters.Add(Unit);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = sTransrefno;
            TransactionID.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransactionID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = sTransrefno;
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            if (ddlCenterList.SelectedValue != "0")
            {
                SqlParameter CentreId = new SqlParameter();
                CentreId.SqlDbType = SqlDbType.VarChar;
                CentreId.Value = ddlCenterList.SelectedValue.ToString();
                CentreId.ParameterName = "@BranchID";
                sqlcmd.Parameters.Add(CentreId);
            }
            else
            {
                SqlParameter CentreId = new SqlParameter();
                CentreId.SqlDbType = SqlDbType.VarChar;
                CentreId.Value = Session["CentreID"].ToString();
                CentreId.ParameterName = "@BranchID";
                sqlcmd.Parameters.Add(CentreId);
            }

            SqlParameter Trans_Type = new SqlParameter();
            Trans_Type.SqlDbType = SqlDbType.VarChar;
            Trans_Type.Value = ddlAssetsType.SelectedValue.ToString();
            Trans_Type.ParameterName = "@Trans_Type";
            sqlcmd.Parameters.Add(Trans_Type);

            SqlParameter Centre_Name = new SqlParameter();
            Centre_Name.SqlDbType = SqlDbType.VarChar;
            Centre_Name.Value = txtLocation.Text.Trim();
            Centre_Name.ParameterName = "@Centre_Name";
            sqlcmd.Parameters.Add(Centre_Name);

            SqlParameter Subcentre_id = new SqlParameter();
            Subcentre_id.SqlDbType = SqlDbType.VarChar;
            Subcentre_id.Value = ddlSubCentre.SelectedValue.ToString();
            Subcentre_id.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(Subcentre_id);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = HdnTransStatus.Value;
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);

            SqlParameter Amt_RcvdSale = new SqlParameter();
            Amt_RcvdSale.SqlDbType = SqlDbType.VarChar;
            Amt_RcvdSale.Value = txtAmtRecvSale.Text.Trim();
            Amt_RcvdSale.ParameterName = "@Amt_RcvdSale";
            sqlcmd.Parameters.Add(Amt_RcvdSale);

            //SqlParameter Companyname = new SqlParameter();
            //Companyname.SqlDbType = SqlDbType.VarChar;
            //Companyname.Value = txtcompanyname.Text.ToString().Trim();
            //Companyname.ParameterName = "@Company_name";
            //sqlcmd.Parameters.Add(Companyname);

            SqlParameter Model_name = new SqlParameter();
            Model_name.SqlDbType = SqlDbType.VarChar;
            Model_name.Value = txtmodelname.Text.ToString().Trim();
            Model_name.ParameterName = "@Model_Name";
            sqlcmd.Parameters.Add(Model_name);

            SqlParameter DateOfApproval = new SqlParameter();
            DateOfApproval.SqlDbType = SqlDbType.VarChar;
            DateOfApproval.Value = txtDateOfApproval.Text.ToString().Trim();
            DateOfApproval.ParameterName = "@DateOfApproval";
            sqlcmd.Parameters.Add(DateOfApproval);

            ////SqlParameter Rental_system_no = new SqlParameter();
            ////Rental_system_no.SqlDbType = SqlDbType.VarChar;
            ////Rental_system_no.Value = txtrentalsystem.Text.ToString().Trim();
            ////Rental_system_no.ParameterName = "@Rental_system_No";
            ////sqlcmd.Parameters.Add(Rental_system_no);

            if (ddlStatus.SelectedValue.ToString() == "Available")
            {
                SqlParameter SSRDate = new SqlParameter();
                SSRDate.SqlDbType = SqlDbType.VarChar;
                SSRDate.Value = txtSSRDate.Text.Trim();
                SSRDate.ParameterName = "@Scrap_Date";
                sqlcmd.Parameters.Add(SSRDate);
            }
            else
            {
                SqlParameter SSRAprovBy = new SqlParameter();
                SSRAprovBy.SqlDbType = SqlDbType.VarChar;
                SSRAprovBy.Value = TxtSSRApproveBy.Text.Trim();
                SSRAprovBy.ParameterName = "@SSRAprovBy";
                sqlcmd.Parameters.Add(SSRAprovBy);

                SqlParameter SSRDate = new SqlParameter();
                SSRDate.SqlDbType = SqlDbType.VarChar;//-----DateTime//SqlDbType.DateTime;
                SSRDate.Value = txtSSRDate.Text.Trim();//strDate(txtSSRDate.Text.Trim());
                SSRDate.ParameterName = "@Scrap_Date";
                sqlcmd.Parameters.Add(SSRDate);

            }
            if (ddlAssetsType.SelectedValue.ToString() == "PSHM" || ddlAssetsType.SelectedValue.ToString() == "ELB")
            {
                SqlParameter Company_name = new SqlParameter();
                Company_name.SqlDbType = SqlDbType.VarChar;
                Company_name.Value = txtCompName.Text.ToString().Trim();

                Company_name.ParameterName = "@Company_name";
                sqlcmd.Parameters.Add(Company_name);

                SqlParameter Capacity = new SqlParameter();
                Capacity.SqlDbType = SqlDbType.VarChar;//-----DateTime//SqlDbType.DateTime;
                Capacity.Value = txtCapacity.Text.ToString().Trim();//strDate(txtSSRDate.Text.Trim());
                Capacity.ParameterName = "@Capacity";
                sqlcmd.Parameters.Add(Capacity);
            }
            else
            {
                SqlParameter Company_name = new SqlParameter();
                Company_name.SqlDbType = SqlDbType.NVarChar;
                //Company_name.Value = DBNull.Value;
                Company_name.Value = txtCompName.Text.ToString().Trim();

                Company_name.ParameterName = "@Company_name";
                sqlcmd.Parameters.Add(Company_name);

                SqlParameter Capacity = new SqlParameter();
                Capacity.SqlDbType = SqlDbType.NVarChar;//-----DateTime//SqlDbType.DateTime;
                Capacity.Value = DBNull.Value;//strDate(txtSSRDate.Text.Trim());
                Capacity.ParameterName = "@Capacity";
                sqlcmd.Parameters.Add(Capacity);

            }

            SqlParameter AssetLocation = new SqlParameter();
            AssetLocation.SqlDbType = SqlDbType.VarChar;
            AssetLocation.Value = ddlAssetLocation.SelectedValue.ToString();
            AssetLocation.ParameterName = "@AssetLocation";
            sqlcmd.Parameters.Add(AssetLocation);

            if (ddlStatus.SelectedValue.ToString() == "Available")
            {
                SqlParameter VendorAssetNumber = new SqlParameter();
                VendorAssetNumber.SqlDbType = SqlDbType.VarChar;
                VendorAssetNumber.Value = txtVendorAssetNumber.Text.Trim();
                VendorAssetNumber.ParameterName = "@VendorAssetNumber";
                sqlcmd.Parameters.Add(VendorAssetNumber);

                if (hdnIsITAssets.Value == "Yes")
                {
                    SqlParameter AssetsRating = new SqlParameter();
                    AssetsRating.SqlDbType = SqlDbType.VarChar;
                    AssetsRating.Value = ddlAssetsRating.SelectedValue;
                    AssetsRating.ParameterName = "@AssetsRating";
                    sqlcmd.Parameters.Add(AssetsRating);

                    SqlParameter SecurityRating = new SqlParameter();
                    SecurityRating.SqlDbType = SqlDbType.VarChar;
                    SecurityRating.Value = ddlSecurityRating.SelectedValue;
                    SecurityRating.ParameterName = "@SecurityRating";
                    sqlcmd.Parameters.Add(SecurityRating);
                }
                else
                {
                    SqlParameter AssetsRating = new SqlParameter();
                    AssetsRating.SqlDbType = SqlDbType.VarChar;
                    AssetsRating.Value = string.Empty;
                    AssetsRating.ParameterName = "@AssetsRating";
                    sqlcmd.Parameters.Add(AssetsRating);

                    SqlParameter SecurityRating = new SqlParameter();
                    SecurityRating.SqlDbType = SqlDbType.VarChar;
                    SecurityRating.Value = string.Empty;
                    SecurityRating.ParameterName = "@SecurityRating";
                    sqlcmd.Parameters.Add(SecurityRating);
                }
            }

            sqlcmd.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlcmd.Parameters["@VarResult"].Value);
            sqlcon.Close();
            ClearData();

            if (RowEffected != "")
            {
                if (RowEffected == "Duplicate Error")
                {
                    lblMessage.Text = "Either a PC or a laptop can be assigned, not both";
                    hdnTransactionID.Value = "";
                    hdnTransactionID.Value = "";
                }
                else
                {
                    lblMessage.Text = "Transaction Successfully Saved! Transaction ID : " + RowEffected;
                    hdnTransactionID.Value = RowEffected;
                    hdnTransactionID.Value = "";


                    string User_ID = Session["UserId"].ToString();

                    if (User_ID != "101103639" && User_ID != "101147499")
                    {
                        Response.Redirect("Assets_DescriptionFormat.aspx?TranRefNo=" + RowEffected);
                    }
                    //GetGridData();
                }
            }
            else
            {

                string User_ID = Session["UserId"].ToString();

                if (User_ID != "101103639" && User_ID != "101147499")
                {
                    Response.Redirect("Assets_DescriptionFormat.aspx?TranRefNo=" + sTransrefno);
                }
                else
                {

                    lblMessage.Text = sTransrefno + " Asset " + HdnTransStatus.Value + " Successfully";
                    //GetGridData();
                    hdnTransactionID.Value = "";
                    sTransrefno = "";
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        GetGridData();
        //ClearData(); //08/02/2024
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }

    private void ClearData()
    {
        txtUnit.Text = "";
        //txtSerialNo.Text = "";
        txtPurchaseDate.Text = "";
        ddlOwneName.SelectedIndex = 0;
        //txtMotherBoard.Text = "";
        //txtModelName.Text = "";
        //txtMakeBy.Text = "";
        //txtCompName.Text = "";
        txtAmcInfo.Text = "";
        txtAmc.Text = "";
        txtVenderName.Text = "";
        txtDate.Text = "";
        txtRentAmt.Text = "";
        ddlAssetsType.SelectedIndex = 0;
        //ddlHdd.SelectedIndex = 0;
        //ddlMonitor.SelectedIndex = 0;
        //ddlProcessor.SelectedIndex = 0;
        //ddlRam.SelectedIndex = 0;
        ddlVerticalName.SelectedIndex = 0;
        //ddlWarrantyType.SelectedIndex = 0; 
        txtPurchaseCost.Text = "";
        ddlOwneName.SelectedIndex = 0;
        ddlStatus.SelectedIndex = 0;
        ddlCenterList.SelectedIndex = 0;
        txtRentAmt.Text = "";
        txtVenderName.Text = "";
        txtAmtRecvSale.Text = "";
        txtApprovalAuth.Text = "";
        //txtDepositeDate.Text = "";
        txtSSRDate.Text = "";

        Lbltraname.Text = "";


    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    private void GetEmpCode()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails_EmpCode1";//Get_EmployeeDetails_EmpCode replace by prachi
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = Session["CentreID"].ToString();
        CentreId.ParameterName = "@CentreId";
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter Emp_Id = new SqlParameter();
        Emp_Id.SqlDbType = SqlDbType.VarChar;
        Emp_Id.Value = ddlEmpName.SelectedValue.ToString();
        Emp_Id.ParameterName = "@Emp_Id";
        sqlcmd.Parameters.Add(Emp_Id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            //hdnEmpCode.Value = "";
            //txtLocation.Text = "";
            hdnEmpCode.Value = dt.Rows[0]["Emp_Code"].ToString();
            txtLocation.Text = dt.Rows[0]["Centre_Name"].ToString();
        }



        lblMessage.Text = "";
    }

    private void GetGridData()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_AssetsInventoryDetailsUpdation";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = Session["CentreID"].ToString();
        CentreId.ParameterName = "@CentreId";
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter Emp_Id = new SqlParameter();
        Emp_Id.SqlDbType = SqlDbType.VarChar;
        Emp_Id.Value = ddlEmpName.SelectedValue.ToString();
        Emp_Id.ParameterName = "@Emp_code";
        sqlcmd.Parameters.Add(Emp_Id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            Panel1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Lblmessage2.Text = "Data Already Exit for : " + ddlEmpName.SelectedItem.ToString() + " Record Found: " + dt.Rows.Count;

            hdnTransRefNo.Value = "";
            Pnlwrnt.Visible = false;
            pnlTransfer.Visible = false;

        }
        else
        {
            Panel1.Visible = false;

            GridView1.DataSource = null;
            GridView1.DataBind();
            Lblmessage2.Text = "";
            Pnlwrnt.Visible = false;
            pnlTransfer.Visible = false;
        }
    }

    protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetEmpCode();
        GetGridData();
        ClearData();
        pnlTransfer.Visible = false;
        ddlStatus.SelectedItem.Text = "Available";

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");

        }


    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        ClearData();
        Panel1.Visible = false;
        GridView1.DataSource = null;
        GridView1.DataBind();
        lblMessage.Text = "";


    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue == "Available")
        {

            txtAmtRecvSale.Visible = true;
            txtAmtRecvSale.Text = "";
            //lblDepoDate.Visible = true;
            //txtDepositeDate.Visible = true;
            //txtDepositeDate.Text = "";
            //pnlDepoDate.Visible = true;
            lblBranchTrans.Visible = true;
            ddlCenterList.Visible = true;
            ddlCenterList.SelectedIndex = 0;
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;
            txtApprovalAuth.Text = "";

            txtSSRDate.Visible = true;
            txtSSRDate.Text = "";
            //pnlScrapDate.Visible = true;
            pnlTransfer.Visible = false;
            Pnlwrnt.Visible = false;
        }

        if (ddlStatus.SelectedValue == "Replace") //add on 08/02/2024
        {


            txtSSRDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Panel1.Visible = false;
            pnlTransfer.Visible = false;
            Pnlwrnt.Visible = true;
            lblMessage.Text = "";
            Lblmessage2.Text = "";

            btnSave.Visible = true;

            BtnTransfer.Visible = false;
            btnNew.Visible = false;

            btnCan.Visible = true;

            HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();

            txtAmtRecvSale.Visible = true;
            txtAmtRecvSale.Text = "";
            //lblDepoDate.Visible = true;
            //txtDepositeDate.Visible = true;
            //txtDepositeDate.Text = "";
            //pnlDepoDate.Visible = false;
            lblBranchTrans.Visible = true;
            ddlCenterList.Visible = true;
            ddlCenterList.SelectedIndex = 0;
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;
            txtApprovalAuth.Text = "";

            txtSSRDate.Enabled = true;
            txtSSRDate.Text = "";
        }

        if (ddlStatus.SelectedValue == "Returned  to Vendor")
        {


            txtSSRDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Panel1.Visible = false;
            pnlTransfer.Visible = false;
            Pnlwrnt.Visible = true;
            lblMessage.Text = "";
            Lblmessage2.Text = "";

            btnSave.Visible = true;

            BtnTransfer.Visible = false;
            btnNew.Visible = false;

            btnCan.Visible = true;

            HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();

            txtAmtRecvSale.Visible = true;
            txtAmtRecvSale.Text = "";
            //lblDepoDate.Visible = true;
            //txtDepositeDate.Visible = true;
            //txtDepositeDate.Text = "";
            //pnlDepoDate.Visible = false;
            lblBranchTrans.Visible = true;
            ddlCenterList.Visible = true;
            ddlCenterList.SelectedIndex = 0;
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;
            txtApprovalAuth.Text = "";

            txtSSRDate.Enabled = true;
            txtSSRDate.Text = "";
        }

        if (ddlStatus.SelectedValue == "Sold")
        {
            txtSSRDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Panel1.Visible = false;
            pnlTransfer.Visible = false;

            Pnlwrnt.Visible = true;
            lblMessage.Text = "";
            Lblmessage2.Text = "";

            btnSave.Visible = true;

            BtnTransfer.Visible = false;
            btnNew.Visible = false;
            btnCan.Visible = true;
            HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();

            //lblDepoDate.Enabled = false;
            //txtDepositeDate.Visible = true;
            txtAmtRecvSale.Text = "";
            //txtDepositeDate.Text = "";
            lblApprovalAuth.Enabled = true;
            txtApprovalAuth.Enabled = true;
            txtSSRDate.Enabled = true;
            txtAmtRecvSale.Enabled = true;


        }
        /////modify by Prachi///////////////////////
        if ((ddlStatus.SelectedValue == "Scrap") && (ddlAssetsType.SelectedValue == "PC"))
        {
            Response.Redirect("Subassetdetailspc.aspx?&TranRefNo=" + hdnTransRefNo.Value + " &PageSttaus=" + "ScrapPage");
        }
        if ((ddlStatus.SelectedValue == "Scrap") && (ddlAssetsType.SelectedValue != "PC"))//////////
        {
            txtSSRDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Panel1.Visible = false;
            pnlTransfer.Visible = false;

            Pnlwrnt.Visible = true;

            lblMessage.Text = "";
            Lblmessage2.Text = "";

            btnSave.Visible = true;

            BtnTransfer.Visible = false;
            btnNew.Visible = false;
            btnCan.Visible = true;
            HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;
            txtSSRDate.Visible = true;
            txtApprovalAuth.Text = "";
            txtSSRDate.Text = "";
            txtAmtRecvSale.Enabled = true;
            //lblDepoDate.Enabled = false;
            //txtDepositeDate.Enabled = false;


        }
        if (ddlStatus.SelectedValue == "Transferred to other PAMACian")
        {
            //if (ddlOwneName.SelectedValue == "Owned")
            //{
            ddlCenterList.SelectedIndex = 0;
            ddlclustername.SelectedIndex = 0;


            txtdateofTrasfer.Text = "";
            txttrfApprovby.Text = "";

            txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Pnlwrnt.Visible = false;
            Panel1.Visible = false;
            HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();
            lblMessage.Text = "";
            Lblmessage2.Text = "";

            string strRloeID = Session["RoleID"].ToString();
            string[] strRole1 = strRloeID.Split(',');

            foreach (string str in strRole1)
            {
                //if (str == "2" || str == "1" || str == "13" || str == "6" || str == "7" || str == "23" || str == "24" || str == "16")
                //{
                Pnlwrnt.Visible = false;
                Panel1.Visible = false;
                btnSave.Visible = false;
                btnNew.Visible = false;

                pnlTransfer.Visible = true;
                BtnTransfer.Visible = true;

                lblMessage.Text = "";
                lblTransCode.Text = "";

                //}

            }


            lblBranchTrans.Visible = true;
            ddlCenterList.Visible = true;
            ddlCenterList.SelectedIndex = 0;


            txtAmtRecvSale.Visible = true;
            //lblDepoDate.Visible = true;
            //txtDepositeDate.Visible = true;
            lblApprovalAuth.Visible = true;
            txtApprovalAuth.Visible = true;

            txtSSRDate.Visible = true;

            lblclustername.Visible = true;
            ddlclustername.Visible = true;
            lblpamaciantransfer.Visible = true;
            ddlpamaciantransfer.Visible = true;
            lbldateTransfer.Visible = true;
            txtdateofTrasfer.Visible = true;
            lblsubcentrename.Visible = true;
            ddlsubcentrename.Visible = true;
            Lbltraname.Visible = false;

            //}
            //else
            //{
            //    lblMessage.Text = "Given Asset is Rented not able to transfer";////////////
            //    return;
            //}
        }
        if (ddlStatus.SelectedValue == "Transferred to Other Branch")
        {
            if (ddlOwneName.SelectedValue == "Owned")
            {

                ddlCenterList.SelectedIndex = 0;
                ddlclustername.SelectedIndex = 0;
                txtdateofTrasfer.Text = "";
                txttrfApprovby.Text = "";
                txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

                HdnTransStatus.Value = ddlStatus.SelectedValue.ToString();
                lblpamaciantransfer.Visible = true;
                Lbltraname.Visible = false;
                ddlpamaciantransfer.Visible = true;
                Lbltraname.Text = ddlEmpName.SelectedItem.ToString();
                HdnEmp.Value = ddlEmpName.SelectedValue.ToString();
                lblMessage.Text = "";
                Lblmessage2.Text = "";

                string strRloeID = Session["RoleID"].ToString();
                string[] strRole1 = strRloeID.Split(',');


                foreach (string str in strRole1)
                {
                    //if (str == "2" || str == "1" || str == "13" || str == "6" || str == "7" || str == "23" || str == "24" || str == "16")
                    //{
                    Panel1.Visible = false;
                    Pnlwrnt.Visible = false;
                    btnSave.Visible = false;
                    btnNew.Visible = false;

                    pnlTransfer.Visible = true;
                    BtnTransfer.Visible = true;

                    lblMessage.Text = "";
                    lblTransCode.Text = "";

                    //}

                }

                lblBranchTrans.Visible = true;
                ddlCenterList.Visible = true;
                ddlCenterList.SelectedIndex = 0;
                txtAmtRecvSale.Visible = true;
                //lblDepoDate.Visible = true;
                //txtDepositeDate.Visible = true;
                lblApprovalAuth.Visible = true;
                txtApprovalAuth.Visible = true;
                txtSSRDate.Visible = true;
                lblclustername.Visible = true;
                ddlclustername.Visible = true;
                lblpamaciantransfer.Visible = true;
                lbldateTransfer.Visible = true;
                txtdateofTrasfer.Visible = true;
                lblsubcentrename.Visible = true;
                ddlsubcentrename.Visible = true;


            }
            else
            {
                pnlTransfer.Visible = false;
                BtnTransfer.Visible = false;
                lblMessage.Text = "Given Asset is Rented not able to transfer";/////////
                return;
            }
        }
    }

    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCentreList();
        //Get_Empname();
    }

    protected void ddlCenterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSubCentreName();


    }

    protected void ddlsubcentrename_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Get_Empname();

    }

    protected void BtnTransfer_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        string msg = string.Empty;

        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();



            if (ddlOwneName.SelectedItem.Text == "Owned")
            {
                if (txtPurchaseCost.Text.Trim() == "" || txtPurchaseCost.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Purchase Cost";
                }
                if (txtPurchaseDate.Text.Trim() == "" || txtPurchaseDate.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Purchase Date";
                }
            }
            if (ddlOwneName.SelectedItem.Text == "Rented")
            {
                if (txtRentAmt.Text.Trim() == "" || txtRentAmt.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Rented Amount";
                }
                if (txtVenderName.Text.Trim() == "" || txtVenderName.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Vender Name";
                }
                if (txtDate.Text.Trim() == "" || txtDate.Text.Trim() == null)
                {
                    msg = msg + "Please Enter Rented Date";
                }
            }


            if (msg != "")
            {
                lblMessage.Text = msg;
                return;
            }


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "UpdateTransfer_AssetsInventoryDatanew1";//UpdateTransfer_AssetsInventoryDatanew
            sqlcmd.CommandTimeout = 0;


            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = txtsearch2.Text.Trim();
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = HdnTransEmpName.Value;
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);


            SqlParameter Vertical_Name = new SqlParameter();
            Vertical_Name.SqlDbType = SqlDbType.VarChar;
            Vertical_Name.Value = ddlVerticalName.SelectedValue.ToString().Trim();
            Vertical_Name.ParameterName = "@Vertical_Name";
            sqlcmd.Parameters.Add(Vertical_Name);

            SqlParameter Assets_Type = new SqlParameter();
            Assets_Type.SqlDbType = SqlDbType.VarChar;
            Assets_Type.Value = ddlAssetsType.SelectedValue.ToString();
            Assets_Type.ParameterName = "@Assets_Type";
            sqlcmd.Parameters.Add(Assets_Type);

            SqlParameter Purchase_Cost = new SqlParameter();
            Purchase_Cost.SqlDbType = SqlDbType.VarChar;
            Purchase_Cost.Value = txtPurchaseCost.Text.Trim();
            Purchase_Cost.ParameterName = "@Purchase_Cost";
            sqlcmd.Parameters.Add(Purchase_Cost);

            SqlParameter Purchase_Date = new SqlParameter();
            Purchase_Date.SqlDbType = SqlDbType.VarChar;//-----DateTime
            Purchase_Date.Value = txtPurchaseDate.Text.Trim();//strDate(txtPurchaseDate.Text.Trim());
            Purchase_Date.ParameterName = "@Purchase_Date";
            sqlcmd.Parameters.Add(Purchase_Date);

            SqlParameter Amc = new SqlParameter();
            Amc.SqlDbType = SqlDbType.VarChar;
            Amc.Value = txtAmc.Text.Trim();
            Amc.ParameterName = "@Amc";
            sqlcmd.Parameters.Add(Amc);

            SqlParameter Amc_Info = new SqlParameter();
            Amc_Info.SqlDbType = SqlDbType.VarChar;
            Amc_Info.Value = txtAmcInfo.Text.Trim();
            Amc_Info.ParameterName = "@Amc_Info";
            sqlcmd.Parameters.Add(Amc_Info);

            SqlParameter Owner_Name = new SqlParameter();
            Owner_Name.SqlDbType = SqlDbType.VarChar;
            Owner_Name.Value = ddlOwneName.SelectedValue.ToString();
            Owner_Name.ParameterName = "@Owner_Name";
            sqlcmd.Parameters.Add(Owner_Name);

            SqlParameter Rent_Amt = new SqlParameter();
            Rent_Amt.SqlDbType = SqlDbType.VarChar;
            Rent_Amt.Value = txtRentAmt.Text.Trim();
            Rent_Amt.ParameterName = "@Rent_Amt";
            sqlcmd.Parameters.Add(Rent_Amt);

            SqlParameter Vender_Name = new SqlParameter();
            Vender_Name.SqlDbType = SqlDbType.VarChar;
            Vender_Name.Value = txtVenderName.Text.Trim();
            Vender_Name.ParameterName = "@Vender_Name";
            sqlcmd.Parameters.Add(Vender_Name);

            SqlParameter Vender_Date = new SqlParameter();
            Vender_Date.SqlDbType = SqlDbType.VarChar;
            Vender_Date.Value = txtDate.Text.Trim();
            Vender_Date.ParameterName = "@Vender_Date";
            sqlcmd.Parameters.Add(Vender_Date);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value = ddlStatus.SelectedValue.ToString(); //change on 07/02/24
            Status.ParameterName = "@Status";
            sqlcmd.Parameters.Add(Status);

            SqlParameter Amt_RcvdSale = new SqlParameter();
            Amt_RcvdSale.SqlDbType = SqlDbType.VarChar;
            Amt_RcvdSale.Value = txtAmtRecvSale.Text.Trim();
            Amt_RcvdSale.ParameterName = "@Amt_RcvdSale";
            sqlcmd.Parameters.Add(Amt_RcvdSale);

            //SqlParameter Deposite_Date = new SqlParameter();
            //Deposite_Date.SqlDbType = SqlDbType.VarChar;
            //Deposite_Date.Value = txtDepositeDate.Text.Trim();
            //Deposite_Date.ParameterName = "@Deposite_Date";
            //sqlcmd.Parameters.Add(Deposite_Date);

            SqlParameter Transfer_Branch = new SqlParameter();
            Transfer_Branch.SqlDbType = SqlDbType.VarChar;
            Transfer_Branch.Value = ddlCenterList.SelectedValue.ToString();
            Transfer_Branch.ParameterName = "@Transfer_Branch";
            sqlcmd.Parameters.Add(Transfer_Branch);

            SqlParameter AppAuth_Name = new SqlParameter();
            AppAuth_Name.SqlDbType = SqlDbType.VarChar;
            AppAuth_Name.Value = txtApprovalAuth.Text.Trim();
            AppAuth_Name.ParameterName = "@AppAuth_Name";
            sqlcmd.Parameters.Add(AppAuth_Name);

            SqlParameter Scrap_Date = new SqlParameter();
            Scrap_Date.SqlDbType = SqlDbType.VarChar;
            Scrap_Date.Value = txtSSRDate.Text.Trim();
            Scrap_Date.ParameterName = "@Scrap_Date";
            sqlcmd.Parameters.Add(Scrap_Date);

            SqlParameter Unit = new SqlParameter();
            Unit.SqlDbType = SqlDbType.VarChar;
            Unit.Value = txtUnit.Text.Trim();
            Unit.ParameterName = "@Unit";
            sqlcmd.Parameters.Add(Unit);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            SqlParameter TransactionID = new SqlParameter();
            TransactionID.SqlDbType = SqlDbType.VarChar;
            TransactionID.Value = HdnTransfer.Value;
            TransactionID.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransactionID);

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@BranchID";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter Trans_Type = new SqlParameter();
            Trans_Type.SqlDbType = SqlDbType.VarChar;
            Trans_Type.Value = ddlAssetsType.SelectedValue.ToString();
            Trans_Type.ParameterName = "@Trans_Type";
            sqlcmd.Parameters.Add(Trans_Type);

            SqlParameter Centre_Name = new SqlParameter();
            Centre_Name.SqlDbType = SqlDbType.VarChar;
            Centre_Name.Value = txtLocation.Text.Trim();
            Centre_Name.ParameterName = "@Centre_Name";
            sqlcmd.Parameters.Add(Centre_Name);

            SqlParameter Subcentre_id = new SqlParameter();
            Subcentre_id.SqlDbType = SqlDbType.VarChar;
            Subcentre_id.Value = ddlsubcentrename.SelectedValue.ToString();
            Subcentre_id.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(Subcentre_id);

            if (ddlStatus.SelectedValue == "Transferred to other PAMACian")
            {
                if (ddlpamaciantransfer.SelectedValue.ToString() != "")
                {
                    SqlParameter TransferToEmp_Id = new SqlParameter();
                    TransferToEmp_Id.SqlDbType = SqlDbType.VarChar;
                    TransferToEmp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                    TransferToEmp_Id.ParameterName = "@TransferToEmp_Id";
                    sqlcmd.Parameters.Add(TransferToEmp_Id);

                    SqlParameter Emp_Id = new SqlParameter();
                    Emp_Id.SqlDbType = SqlDbType.VarChar;
                    Emp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                    Emp_Id.ParameterName = "@Emp_Id";
                    sqlcmd.Parameters.Add(Emp_Id);
                }
                else
                {
                    lblMessage.Text = "Kindly Select Transfer To Pamacian..!!";
                    return;
                }
            }
            else
            {
                SqlParameter TransferToEmp_Id = new SqlParameter();
                TransferToEmp_Id.SqlDbType = SqlDbType.VarChar;
                TransferToEmp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                TransferToEmp_Id.ParameterName = "@TransferToEmp_Id";
                sqlcmd.Parameters.Add(TransferToEmp_Id);

                SqlParameter Emp_Id = new SqlParameter();
                Emp_Id.SqlDbType = SqlDbType.VarChar;
                Emp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                Emp_Id.ParameterName = "@Emp_Id";
                sqlcmd.Parameters.Add(Emp_Id);
            }

            SqlParameter TransferDate = new SqlParameter();
            TransferDate.SqlDbType = SqlDbType.VarChar;
            TransferDate.Value = txtdateofTrasfer.Text.Trim();
            TransferDate.ParameterName = "@TransferDate";
            sqlcmd.Parameters.Add(TransferDate);

            SqlParameter TransferAprvBy = new SqlParameter();
            TransferAprvBy.SqlDbType = SqlDbType.VarChar;
            TransferAprvBy.Value = txttrfApprovby.Text.Trim();
            TransferAprvBy.ParameterName = "@TransferAprvBy";
            sqlcmd.Parameters.Add(TransferAprvBy);

            SqlParameter TransferBy = new SqlParameter();
            TransferBy.SqlDbType = SqlDbType.VarChar;
            TransferBy.Value = Session["Userid"].ToString();
            TransferBy.ParameterName = "@TransferBy";
            sqlcmd.Parameters.Add(TransferBy);

            SqlParameter TransferToCluster = new SqlParameter();
            TransferToCluster.SqlDbType = SqlDbType.VarChar;
            TransferToCluster.Value = ddlclustername.SelectedValue.ToString();
            TransferToCluster.ParameterName = "@TransferToCluster";
            sqlcmd.Parameters.Add(TransferToCluster);

            SqlParameter TransferToCentre = new SqlParameter();
            TransferToCentre.SqlDbType = SqlDbType.VarChar;
            TransferToCentre.Value = ddlCenterList.SelectedValue.ToString();
            TransferToCentre.ParameterName = "@TransferToCentre";
            sqlcmd.Parameters.Add(TransferToCentre);

            SqlParameter TransferToSubcentre = new SqlParameter();
            TransferToSubcentre.SqlDbType = SqlDbType.VarChar;
            TransferToSubcentre.Value = ddlsubcentrename.SelectedValue.ToString();
            TransferToSubcentre.ParameterName = "@TransferToSubcentre";
            sqlcmd.Parameters.Add(TransferToSubcentre);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = HdnTransStatus.Value;
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);

            SqlParameter NewTransRefNo = new SqlParameter();
            NewTransRefNo.SqlDbType = SqlDbType.VarChar;
            NewTransRefNo.Value = "";
            NewTransRefNo.ParameterName = "@NewTransRefNo";
            sqlcmd.Parameters.Add(NewTransRefNo);

            SqlParameter AssetLocation = new SqlParameter();
            AssetLocation.SqlDbType = SqlDbType.VarChar;
            AssetLocation.Value = ddlAssetLocation.SelectedValue.ToString();
            AssetLocation.ParameterName = "@AssetLocation";
            sqlcmd.Parameters.Add(AssetLocation);

            int r = sqlcmd.ExecuteNonQuery();

            if (r > 0)
            {
                ClearData();

                lblMessage.Text = HdnTransfer.Value + " Assets Transfer To " + HdnTransEmpName.Value + " Successfully";
                ddlCenterList.SelectedIndex = 0;
                //ddlpamaciantransfer.SelectedIndex = 0;
                ddlclustername.SelectedIndex = 0;
                ddlSubCentre.SelectedIndex = 0;
                ddlpamaciantransfer.SelectedIndex = 0;
                txtdateofTrasfer.Text = "";
                txttrfApprovby.Text = "";
                Pnlwrnt.Visible = false;
                pnlTransfer.Visible = true;
            }



            sqlcon.Close();

            GetGridData();

            BtnTransfer.Visible = false; ;
            btnSave.Visible = true;
            btnNew.Visible = true;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void ddlpamaciantransfer_SelectedIndexChanged(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmpDetails2";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = ddlpamaciantransfer.SelectedValue.ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            HdnTrsEMPCODE.Value = dt.Rows[0]["Emp_code"].ToString();
            HdnTransEmpName.Value = dt.Rows[0]["Fullname"].ToString();

        }
    }

    protected void btnsearch_empcode_Click(object sender, EventArgs e)
    {
        Get_EmployeeDetailsnew();
    }

    private void Get_EmployeeDetailsnew()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetailsnew";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = Session["CentreID"].ToString();
        CentreId.ParameterName = "@CentreId";
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter emp_code = new SqlParameter();
        emp_code.SqlDbType = SqlDbType.VarChar;
        emp_code.Value = txtsearchcode.Text.Trim();
        emp_code.ParameterName = "@emp_code";
        sqlcmd.Parameters.Add(emp_code);



        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlEmpName.DataTextField = "fullname";
            ddlEmpName.DataValueField = "Emp_id";

            ddlEmpName.DataSource = dt;
            ddlEmpName.DataBind();

            hdnEmployeeID.Value = dt.Rows[0]["Emp_id"].ToString();
        }
        else
        {
            ddlEmpName.DataSource = null;
            ddlEmpName.DataBind();
        }

        ddlEmpName.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        //if (txtsearch2.Text == "")
        //{
        Get_EmpnameNew();
        //}
        //else
        //{
        //    GetEmpCodes();
        //}
    }


    public void GetEmpCodes()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetailsnew12new "; //Get_Empsearch_new_1//"Get_EmpnameNew1234";
        sqlcmd.CommandTimeout = 0;

        SqlParameter emp_code = new SqlParameter();
        emp_code.SqlDbType = SqlDbType.VarChar;
        emp_code.Value = txtsearch2.Text.Trim();
        emp_code.ParameterName = "@emp_code";
        sqlcmd.Parameters.Add(emp_code);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlpamaciantransfer.DataTextField = "fullname";
            ddlpamaciantransfer.DataValueField = "Emp_id";


            ddlpamaciantransfer.DataSource = dt;
            ddlpamaciantransfer.DataBind();
            ddlpamaciantransfer.SelectedIndex = 0;
            HdnTransEmpName.Value = dt.Rows[0]["Fullname"].ToString();
        }
        else
        {
            ddlpamaciantransfer.DataSource = null;
            ddlpamaciantransfer.DataBind();
        }
    }

    protected void ddlAssetsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAssetsType.SelectedItem.Text == "Headphone")
        {
            lblCompName.Visible = true;
            txtCompName.Visible = true;

            lblModelname.Visible = true;
            txtmodelname.Visible = true;

            //lblrentalsystem.Visible = false;
            //txtrentalsystem.Visible = false;

        }
        else if (ddlAssetsType.SelectedItem.Text == "PC")
        {
            //lblrentalsystem.Visible = true;
            //txtrentalsystem.Visible = true;

            lblCompName.Visible = false;
            txtCompName.Visible = false;

            lblModelname.Visible = false;
            txtmodelname.Visible = false;
        }
        else if (ddlAssetsType.SelectedItem.Text == "Laptop")
        {
            //lblrentalsystem.Visible = true;
            //txtrentalsystem.Visible = true;

            lblCompName.Visible = false;
            txtCompName.Visible = false;

            lblModelname.Visible = false;
            txtmodelname.Visible = false;
        }
        else
        {
            lblCompName.Visible = false;
            txtCompName.Visible = false;

            lblModelname.Visible = false;
            txtmodelname.Visible = false;

            //lblrentalsystem.Visible = false;
            //txtrentalsystem.Visible = false;
        }

        ToCheckIsITAssets(ddlAssetsType.SelectedValue);

        if (hdnIsITAssets.Value == "Yes")
        {
            ddlAssetsRating.Visible = true;
            lblAssetsRating.Visible = true;
            ddlSecurityRating.Visible = true;
            lblSecurityRating.Visible = true;
        }
        else
        {
            ddlAssetsRating.Visible = false;
            lblAssetsRating.Visible = false;
            ddlSecurityRating.Visible = false;
            lblSecurityRating.Visible = false;
        }
    }

    protected void ddlOwneName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtRentAmt.Enabled = true;
        txtDate.Enabled = true;
        txtVendorAssetNumber.Enabled = true;
        txtPurchaseDate.Enabled = true;
        txtPurchaseCost.Enabled = true;

        if (ddlOwneName.SelectedValue == "Owned")
        {
            txtRentAmt.Enabled = false;
            txtDate.Enabled = false;
            txtVendorAssetNumber.Enabled = false;
            txtAmc.Enabled = false;
            txtAmcInfo.Enabled = false;
            txtVendorAssetNumber.Enabled = false;
        }
        else if (ddlOwneName.SelectedValue == "Rented")
        {
            txtPurchaseDate.Enabled = false;
            txtPurchaseCost.Enabled = false;
            txtAmc.Enabled = true;
            txtAmcInfo.Enabled = true;
            txtVendorAssetNumber.Enabled = true;
        }
    }
    protected void BindAssetTypeMaster()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_BindAssetTyeMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlAssetsType.DataTextField = "Assets_Name";
                ddlAssetsType.DataValueField = "Assets_code";
                ddlAssetsType.DataSource = ds.Tables[0];
                ddlAssetsType.DataBind();

                ddlAssetsType.Items.Insert(0, "--Select--");
                ddlAssetsType.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ToCheckIsITAssets(string Assets_Code)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_ToCheck_IsITAssets_SP";
            sqlCom.CommandTimeout = 0;

            SqlParameter AssetsCode = new SqlParameter();
            AssetsCode.SqlDbType = SqlDbType.VarChar;
            AssetsCode.Value = Assets_Code;
            AssetsCode.ParameterName = "@AssetsCode";
            sqlCom.Parameters.Add(AssetsCode);

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                hdnIsITAssets.Value = ds.Tables[0].Rows[0]["Is_IT_Assets"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BindAssetsRating()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_BindAssetsRatingMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlAssetsRating.DataTextField = "AR_Description";
                ddlAssetsRating.DataValueField = "AR_Description";
                ddlAssetsRating.DataSource = ds.Tables[0];
                ddlAssetsRating.DataBind();

                ddlAssetsRating.Items.Insert(0, "--Select--");
                ddlAssetsRating.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }

    //protected void BindRejectedAssets()
    //{
    //    CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

    //    SqlCommand sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlcon;
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    sqlCom.CommandText = "Asset_GetRejectedInventoryDetails_SP";
    //    sqlCom.CommandTimeout = 0;

    //    SqlParameter UserID = new SqlParameter();
    //    UserID.SqlDbType = SqlDbType.VarChar;
    //    UserID.Value = Session["LoginName"].ToString(); ;
    //    UserID.ParameterName = "@UserID";
    //    sqlCom.Parameters.Add(UserID);

    //    sqlcon.Open();

    //    SqlDataAdapter sqlDA = new SqlDataAdapter();
    //    sqlDA.SelectCommand = sqlCom;

    //    DataTable dt = new DataTable();
    //    sqlDA.Fill(dt);

    //    sqlcon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        GVDetailsForAssetApprover.DataSource = dt;
    //        GVDetailsForAssetApprover.DataBind();

    //        //GVDetailsForAssetApprover.Rows[0].Cells[0].Enabled = false;
    //        //GVDetailsForAssetApprover.Rows[0].Cells[1].Enabled = false;
    //    }
    //    else
    //    {
    //        GVDetailsForAssetApprover.DataSource = null;
    //        GVDetailsForAssetApprover.DataBind();

    //        lblMessage.Visible = true;
    //        lblMessage.Text = "No Case Found";
    //    }
    //}
    protected void BindSecurityRating()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "PMS_BindSecurityRatingMaster_SP";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlSecurityRating.DataTextField = "SR_Description";
                ddlSecurityRating.DataValueField = "SR_Description";
                ddlSecurityRating.DataSource = ds.Tables[0];
                ddlSecurityRating.DataBind();

                ddlSecurityRating.Items.Insert(0, "--Select--");
                ddlSecurityRating.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {

        }
    }

}








