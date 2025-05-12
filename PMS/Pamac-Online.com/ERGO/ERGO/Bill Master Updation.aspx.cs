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


public partial class ERGO_ERGO_Bill_Master_Updation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {

            GetBillingProcessData_MaxLotWise();

        }

        RegisterControls_WithJavascript();

    }

    private void RegisterControls_WithJavascript()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Generate();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate_On_Save();");

    }

    private void GetBillingProcessData()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BillingProcessData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = txtBridgeCode.Text.Trim();
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value = txtLocation.Text.Trim();
            Location.ParameterName = "@Location";
            sqlcmd.Parameters.Add(Location);

            SqlParameter Alternate_Payee_Name = new SqlParameter();
            Alternate_Payee_Name.SqlDbType = SqlDbType.VarChar;
            Alternate_Payee_Name.Value = txtAltPayeeName.Text.Trim();
            Alternate_Payee_Name.ParameterName = "@Alternate_Payee_Name";
            sqlcmd.Parameters.Add(Alternate_Payee_Name);

            SqlParameter ServiceTaxApplicable = new SqlParameter();
            ServiceTaxApplicable.SqlDbType = SqlDbType.VarChar;
            ServiceTaxApplicable.Value = ddlSTapp.SelectedValue.Trim();
            ServiceTaxApplicable.ParameterName = "@ServiceTaxApplicable";
            sqlcmd.Parameters.Add(ServiceTaxApplicable);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GVBillUpd.DataSource = dt;
                GVBillUpd.DataBind();
                lblError.Text = "Total Records Found " + dt.Rows.Count;
            }
            else
            {
                GVBillUpd.DataSource = null;
                GVBillUpd.DataBind();
                lblError.Text = "No Records Found";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


    private void GetBillingProcessData_MaxLotWise()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_BillingProcessData_LotWise";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GVBillUpd.DataSource = dt;
                GVBillUpd.DataBind();
                lblError.Text = "Total Records Found " + dt.Rows.Count;
            }
            else
            {
                GVBillUpd.DataSource = null;
                GVBillUpd.DataBind();
                lblError.Text = "No Records Found";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void GVBillUpd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onclick", "javascript:GV_RowSelection('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "');");

        //}

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetBillingProcessData();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAltPayeeName.Text = "";
        txtBillDate.Text = "";
        txtBillNo.Text = "";
        txtBridgeCode.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtLocation.Text = "";
        GVBillUpd.DataSource = null;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVBillUpd.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)GVBillUpd.Rows[i].FindControl("chkSelect");
            if (chkSelect.Checked == true)
            {
                hdnUID.Value = GVBillUpd.Rows[i].Cells[12].Text.Trim();
                hdnBridgeCode.Value = GVBillUpd.Rows[i].Cells[1].Text.Trim();


                if (GVBillUpd.Rows[i].Cells[2].Text.Trim() == "&nbsp;")
                {
                    Insert_Billing_Details(hdnUID.Value, hdnBridgeCode.Value, GVBillUpd.Rows[i].Cells[4].Text.Trim(), GVBillUpd.Rows[i].Cells[5].Text.Trim(), GVBillUpd.Rows[i].Cells[9].Text.Trim(), GVBillUpd.Rows[i].Cells[13].Text.Trim(), GVBillUpd.Rows[i].Cells[14].Text.Trim());

                    lblError.Text = "Update Successfully!";
                    lblError.CssClass = "UpdateMessage";
                    lblError.Visible = true;

                }

                else
                {
                    lblError.Text = "Selected entry cannot modify!";
                    lblError.CssClass = "UpdateMessage";
                    lblError.Visible = true;

                }


            }
        }
        //GetBillingProcessData_MaxLotWise();

    }

    private void Insert_Billing_Details(string pUID, string pBridgeCode, string pPayeeName, string pPayLocation, string pGrossAmt, string pMonth, string plotNo)
    {
        try
        {


            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Ergo_InvoiceDetails_Billing";//"Update_Billing_Details";

            SqlParameter BridgeUID = new SqlParameter();
            BridgeUID.SqlDbType = SqlDbType.Int;
            BridgeUID.Value = pUID;
            BridgeUID.ParameterName = "@UID";
            sqlCom.Parameters.Add(BridgeUID);

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = pBridgeCode;
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlCom.Parameters.Add(Bridge_Code);

            SqlParameter Payee_Name = new SqlParameter();
            Payee_Name.SqlDbType = SqlDbType.VarChar;
            Payee_Name.Value = pPayeeName;
            Payee_Name.ParameterName = "@Payee_Name";
            sqlCom.Parameters.Add(Payee_Name);

            SqlParameter PayLocation = new SqlParameter();
            PayLocation.SqlDbType = SqlDbType.VarChar;
            PayLocation.Value = pPayLocation;
            PayLocation.ParameterName = "@PayLocation";
            sqlCom.Parameters.Add(PayLocation);

            SqlParameter GrossAmount = new SqlParameter();
            GrossAmount.SqlDbType = SqlDbType.VarChar;
            GrossAmount.Value = pGrossAmt;
            GrossAmount.ParameterName = "@GrossAmount";
            sqlCom.Parameters.Add(GrossAmount);

            SqlParameter Month = new SqlParameter();
            Month.SqlDbType = SqlDbType.VarChar;
            Month.Value = pMonth;
            Month.ParameterName = "@Month";
            sqlCom.Parameters.Add(Month);

            SqlParameter Bill_No = new SqlParameter();
            Bill_No.SqlDbType = SqlDbType.VarChar;
            Bill_No.Value = txtBillNo.Text.Trim();
            Bill_No.ParameterName = "@Bill_No";
            sqlCom.Parameters.Add(Bill_No);

            SqlParameter Bill_Date = new SqlParameter();
            Bill_Date.SqlDbType = SqlDbType.VarChar;
            Bill_Date.Value =strDate(txtBillDate.Text.Trim());
            Bill_Date.ParameterName = "@Bill_Date";
            sqlCom.Parameters.Add(Bill_Date);

            SqlParameter LotNo = new SqlParameter();
            LotNo.SqlDbType = SqlDbType.Int;
            LotNo.Value = plotNo;
            LotNo.ParameterName = "@LotNo";
            sqlCom.Parameters.Add(LotNo);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value =Session["Userid"].ToString();
            UserID.ParameterName = "@UserID";
            sqlCom.Parameters.Add(UserID);

            int SqlRow = 0;
            SqlRow = sqlCom.ExecuteNonQuery();
            sqlcon.Close();

            if (SqlRow > 0)
            {
                lblError.Text = "Update Successfully!";
                lblError.CssClass = "UpdateMessage";
                lblError.Visible = true;
            }
        }
        catch (Exception ex)
        {
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
