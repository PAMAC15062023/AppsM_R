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

public partial class ERGO_ERGO_Invoice_Data_Updation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            if (Request.QueryString["UID"] != null)
            {
                hdnUID.Value = Request.QueryString["UID"].ToString();
                hdnBridgeCode.Value = Request.QueryString["Code"].ToString();
                //txtBridgeCode.Text = hdnBridgeCode.Value;
            }

            GetInvoiceProcessData(hdnUID.Value, hdnBridgeCode.Value);
        }
    }

    private void GetInvoiceProcessData(string pUID, string pBridgeCode)
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BillingDetails_For_Invoice";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlcmd;

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.VarChar;
            UID.Value = pUID;
            UID.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID);

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = pBridgeCode;
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblError.Text = "";
                Assign_BridgeCode_Details(dt);
            }
            else
            {
                lblError.Text = "No Records found!";
                lblError.CssClass = "ErrorMessage";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void Assign_BridgeCode_Details(DataTable dt)
    {
        txtBridgeCode.Text = dt.Rows[0]["Bridge_Code"].ToString();
        txtMonth.Text = dt.Rows[0]["Month"].ToString();
        txtBillNo.Text = dt.Rows[0]["Bill_No"].ToString();
        txtBillDate.Text = dt.Rows[0]["Bill_Date"].ToString();
        txtLocation.Text = dt.Rows[0]["Location"].ToString();
        //-txtChqNo.Text = dt.Rows[0]["Bank_Branch_Name"].ToString();
        txtAltPayeeName.Text = dt.Rows[0]["Payee_Name"].ToString();
        txtGrossFees.Text = dt.Rows[0]["Gross_Amt"].ToString();
        txtST.Text = dt.Rows[0]["ST"].ToString();
        txtStNo.Text = dt.Rows[0]["ServiceTaxNo"].ToString();

        ddlBisStatus.Text = dt.Rows[0]["BIS_Status"].ToString();
        ddlInvoiceStatus.Text = dt.Rows[0]["Invoice_Status"].ToString(); //Rupesh
        txtInvoiceDate.Text = dt.Rows[0]["Invoice_Rcvd_date"].ToString();
        ddlStComment.Text=dt.Rows[0]["ST_Copy_Rcvd"].ToString();
        txtChqNo.Text = dt.Rows[0]["Cheque_No"].ToString();
        txtChqDate.Text = dt.Rows[0]["Cheque_date"].ToString();
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

        

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_InvoiceDataProcess";
            sqlcmd.CommandTimeout = 0;

            //SqlParameter BillID = new SqlParameter();
            //BillID.SqlDbType = SqlDbType.Int;
            //BillID.Value = txtUID.Text.Trim();
            //BillID.ParameterName = "@BillID";
            //sqlcmd.Parameters.Add(BillID);

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = txtBridgeCode.Text.Trim();
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.VarChar;
            UID.Value = hdnUID.Value;
            UID.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID);

            SqlParameter Cheque_No = new SqlParameter();
            Cheque_No.SqlDbType = SqlDbType.VarChar;
            Cheque_No.Value = txtChqNo.Text.Trim();
            Cheque_No.ParameterName = "@Cheque_No";
            sqlcmd.Parameters.Add(Cheque_No);

            SqlParameter Cheque_Date = new SqlParameter();
            Cheque_Date.SqlDbType = SqlDbType.VarChar;
            Cheque_Date.Value =strDate(txtChqDate.Text.Trim());
            Cheque_Date.ParameterName = "@Cheque_Date";
            sqlcmd.Parameters.Add(Cheque_Date);

            SqlParameter Invoice_Date = new SqlParameter();
            Invoice_Date.SqlDbType = SqlDbType.VarChar;
            Invoice_Date.Value = strDate(txtInvoiceDate.Text.Trim());
            Invoice_Date.ParameterName = "@Invoice_Date";
            sqlcmd.Parameters.Add(Invoice_Date);

            SqlParameter PayoutDone = new SqlParameter();
            PayoutDone.SqlDbType = SqlDbType.VarChar;
            PayoutDone.Value = ddlPayoutDone.SelectedValue.ToString(); 
            PayoutDone.ParameterName = "@PayoutDone";
            sqlcmd.Parameters.Add(PayoutDone);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Session["Userid"].ToString();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblError.Visible = true;
                lblError.Text = "Record Save Successfuly";
                //GetInvoiceProcessData();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCan_Click1(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblError.CssClass = "ErrorMessage";
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
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
}
