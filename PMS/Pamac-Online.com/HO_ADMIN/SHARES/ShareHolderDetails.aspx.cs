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

public partial class HO_ADMIN_SHARES_ShareHolderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["1"] != null)
            {
                if (Request.QueryString["1"] == "0")
                {
                    btnSave.Visible = false;
                }
            }
            if (Request.QueryString["2"] != null)
            {
                hdnShareHolderID.Value = Request.QueryString["2"].ToString();
                 
            }

            GET_Header_Values();
            Register_Javascript_Controls();
        
        }
        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
    }
    private void GET_Header_Values() 
    {
        if (hdnShareHolderID.Value != "0")
        {
            Get_ShareHolderDetails_Modify(Convert.ToInt32(hdnShareHolderID.Value));
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_Admin_Equity_ShareHolderInfo();
    }
    private void Register_Javascript_Controls()
    {

        btnFamMemAdd.Attributes.Add("onclick", "javascript:return Add_ShareDetails();");
        btnFamMemDel.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab','" + hdnSharesDetails.ClientID + "','10');");
        btnFamMemEdit.Attributes.Add("onclick", "javascript:return Edit_MainTab('MainTab','" + hdnSharesDetails.ClientID + "');");
        

        btnSave.Attributes.Add("onclick", "javascript:return Validate_Save();");

        txtAmount.Attributes.Add("onblur", "javascript:Count_Amount();");
        txtRatePreShare.Attributes.Add("onblur", "javascript:Count_Amount();");
    }
    private void Insert_Admin_Equity_ShareHolderInfo()
    {
        try
        {


            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Admin_Equity_ShareHolderInfo";

            SqlParameter ShareHolderID = new SqlParameter();
            ShareHolderID.SqlDbType = SqlDbType.Int;
            ShareHolderID.Value =Convert.ToInt32(hdnShareHolderID.Value);
            ShareHolderID.ParameterName = "@ShareHolderID";
            sqlCom.Parameters.Add(ShareHolderID);

            SqlParameter Folio_No = new SqlParameter();
            Folio_No.SqlDbType = SqlDbType.VarChar;
            Folio_No.Value = txtFolioNo.Text.Trim();
            Folio_No.ParameterName = "@Folio_No";
            sqlCom.Parameters.Add(Folio_No);

            SqlParameter First_Name = new SqlParameter();
            First_Name.SqlDbType = SqlDbType.VarChar;
            First_Name.Value = txtFirstName.Text.Trim();
            First_Name.ParameterName = "@First_Name";
            sqlCom.Parameters.Add(First_Name);
             
            SqlParameter Middle_Name = new SqlParameter();
            Middle_Name.SqlDbType = SqlDbType.VarChar;
            Middle_Name.Value = txtMiddleName.Text.Trim();
            Middle_Name.ParameterName = "@Middle_Name";
            sqlCom.Parameters.Add(Middle_Name);

            SqlParameter Last_Name = new SqlParameter();
            Last_Name.SqlDbType = SqlDbType.VarChar;
            Last_Name.Value = txtLastName.Text.Trim();
            Last_Name.ParameterName = "@Last_Name";
            sqlCom.Parameters.Add(Last_Name);

            SqlParameter Father_Name = new SqlParameter();
            Father_Name.SqlDbType = SqlDbType.VarChar;
            Father_Name.Value = txtFatherName.Text.Trim();
            Father_Name.ParameterName = "@Father_Name";
            sqlCom.Parameters.Add(Father_Name); 
             
            SqlParameter Residence_Address = new SqlParameter();
            Residence_Address.SqlDbType = SqlDbType.VarChar;
            Residence_Address.Value = txtResidenceAddress.Text.Trim();
            Residence_Address.ParameterName = "@Residence_Address";
            sqlCom.Parameters.Add(Residence_Address); 
 
                     
            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value =Session["USERID"];
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            SqlParameter ShareHolderDetails = new SqlParameter();
            ShareHolderDetails.SqlDbType = SqlDbType.VarChar;
            ShareHolderDetails.Value = hdnSharesDetails.Value;
            ShareHolderDetails.ParameterName = "@ShareHolderDetails";
            sqlCom.Parameters.Add(ShareHolderDetails);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = "";
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            sqlCom.ExecuteNonQuery();
            int RowEffected = Convert.ToInt32(sqlCom.Parameters["@VarResult"].Value);

            sqlcon.Close();

           
            if (RowEffected != 0)
            {
                lblMessage.Text = " Successfully Saved! ";
                lblMessage.CssClass = "UpdateMessage";
                hdnShareHolderID.Value = RowEffected.ToString();
             }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMesaage";

        }


    }

    private void Clear_Controls()
    {

        txtAmount.Text = "";
        txtCertificateNo.Text = "";
        txtDateOfAllotment.Text = "";
        txtDistNo.Text = "";
        txtFatherName.Text = "";
        txtFirstName.Text = "";
        txtFolioNo.Text = "";
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtNoofShares.Text = "";
        txtRatePreShare.Text = "";
        txtRemark.Text = "";
        txtResidenceAddress.Text = "";
        hdnShareDetailID.Value = "0";
        hdnShareHolderID.Value = "0";
        hdnSharesDetails.Value = "0";


    
    }

    private void Get_ShareHolderDetails_Modify(int pBranchID)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ShareHolderDetails_Modify";

            SqlParameter ShareDetailID = new SqlParameter();
            ShareDetailID.SqlDbType = SqlDbType.Int;
            ShareDetailID.Value =Convert.ToInt32(hdnShareHolderID.Value.Trim());
            ShareDetailID.ParameterName = "@ShareDetailID";
            sqlCom.Parameters.Add(ShareDetailID); 

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlcon.Close();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                     hdnShareHolderID.Value = ds.Tables[0].Rows[0]["ShareHolder_ID"].ToString();

                    txtFatherName.Text = ds.Tables[0].Rows[0]["Father_Name"].ToString();

                    txtFirstName.Text = ds.Tables[0].Rows[0]["First_Name"].ToString();
                    txtMiddleName.Text = ds.Tables[0].Rows[0]["Middle_Name"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString();

                    txtFolioNo.Text = ds.Tables[0].Rows[0]["Folio_No"].ToString();                   
                    txtResidenceAddress.Text = ds.Tables[0].Rows[0]["Residence_Address"].ToString(); 
     
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string strTranasctionDetails = "";
                    for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                    {
                        strTranasctionDetails = strTranasctionDetails + ds.Tables[1].Rows[i]["ShareDetails"].ToString();
                    }

                   hdnSharesDetails.Value = strTranasctionDetails;
                }
            
            }
             
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Ho_Admin/SHARES/Default.aspx");
        
    }
}


