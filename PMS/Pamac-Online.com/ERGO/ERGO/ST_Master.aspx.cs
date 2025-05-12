
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
using System.IO;

public partial class ERGO_ERGO_ST_Master : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
   sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {

        }
        RegisterControls_WithJavascript();
    }

    private void RegisterControls_WithJavascript()
    {
        //btnInvoice.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        //btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        //sqlcmd.CommandText = "Get_ErgoMainBisData";
        sqlcmd.CommandText = "Get_InvoiceProcessData";
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

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GVSearchData.DataSource = dt;
            GVSearchData.DataBind();
            //btnExportEx.Visible = true; 

            lblError.Text = "Total Records Found " + dt.Rows.Count.ToString();
            lblError.CssClass = "SuccessMessage";

        }
        else
        {
            GVSearchData.DataSource = null;
            GVSearchData.DataBind();
            lblError.Text = "Record Not Found";
        }

    }


    protected void btnCan_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/pages/menu.aspx", true);
        }
        catch (Exception ex)
        {
            lblError.CssClass = "ErrorMessage";
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }

    protected void btnInvoice_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVSearchData.Rows.Count - 1; i++)
        {

            CheckBox chkSelect = (CheckBox)GVSearchData.Rows[i].FindControl("chkSelect");
            TextBox txtInvoiceDate = (TextBox)GVSearchData.Rows[i].FindControl("txtInvoiceDate");
            DropDownList ddlPrevSTRecd = (DropDownList)GVSearchData.Rows[i].FindControl("ddlPrevSTRecd");

            if (chkSelect.Checked == true)
            {
                hdnUID.Value = GVSearchData.Rows[i].Cells[17].Text.Trim();
                hdnBridgeCode.Value = GVSearchData.Rows[i].Cells[1].Text.Trim();

                if (GVSearchData.Rows[i].Cells[18].Text.Trim() == "Invoice Not Recd")
                {
                    updateST_ApplicableDetails(hdnUID.Value, hdnBridgeCode.Value, txtInvoiceDate.Text, ddlPrevSTRecd.SelectedItem.ToString().Trim());
                }
                else
                {
                    lblError.Text = "Selected entry cannot modify!";
                    lblError.CssClass = "UpdateMessage";
                    lblError.Visible = true;
                    
                }
            }


        }
    }


    private void updateST_ApplicableDetails(string sUID, string pBridgeCode, string sInvoiceDate, string sInvoiceStatus)
    {
        try
        {
          
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Update_STMasterDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter UID_No = new SqlParameter();
            UID_No.SqlDbType = SqlDbType.VarChar;
            UID_No.Value = sUID;
            UID_No.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID_No);

            SqlParameter Bridge_Code = new SqlParameter();
            Bridge_Code.SqlDbType = SqlDbType.VarChar;
            Bridge_Code.Value = pBridgeCode;
            Bridge_Code.ParameterName = "@Bridge_Code";
            sqlcmd.Parameters.Add(Bridge_Code);

            SqlParameter Invoice_Status = new SqlParameter();
            Invoice_Status.SqlDbType = SqlDbType.VarChar;
            Invoice_Status.Value = sInvoiceStatus;
            Invoice_Status.ParameterName = "@Invoice_Status";
            sqlcmd.Parameters.Add(Invoice_Status);

            SqlParameter Invoice_Recd_Date = new SqlParameter();
            Invoice_Recd_Date.SqlDbType = SqlDbType.VarChar;
            Invoice_Recd_Date.Value = sInvoiceDate;
            Invoice_Recd_Date.ParameterName = "@Invoice_Recd_Date";
            sqlcmd.Parameters.Add(Invoice_Recd_Date);

            SqlParameter Payout_Done = new SqlParameter();
            Payout_Done.SqlDbType = SqlDbType.VarChar;
            Payout_Done.Value = '1';
            Payout_Done.ParameterName = "@Payout_Done";
            sqlcmd.Parameters.Add(Payout_Done);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Session["Userid"].ToString();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblError.Visible = true;
                lblError.Text = "Record Save Successfuly";
            }

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image ImgInvoiceDate = (Image)e.Row.FindControl("ImgInvoiceDate");
            TextBox txtInvoiceDate = (TextBox)e.Row.FindControl("txtInvoiceDate");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");


            ImgInvoiceDate.Attributes.Add("onclick", "javascript:popUpCalendar(this," + txtInvoiceDate.ClientID + ",'dd/mm/yyyy',0,0);");
            //chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");



        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtBridgeCode.Text = "";
        txtLocation.Text = "";
        txtAltPayeeName.Text = "";
    }
    protected void btnViewInvoice_Click(object sender, EventArgs e)
    {

        for (int i = 0; i <= GVSearchData.Rows.Count - 1; i++)
        {

            CheckBox chkSelect = (CheckBox)GVSearchData.Rows[i].FindControl("chkSelect");
          

            if (chkSelect.Checked == true)
            {
                hdnUID.Value = GVSearchData.Rows[i].Cells[17].Text.Trim();
                hdnBridgeCode.Value = GVSearchData.Rows[i].Cells[1].Text.Trim();

               
               
            }


        }


        Response.Redirect("Invoice Data Updation.aspx?UID=" + hdnUID.Value.Trim() + "&Code=" + hdnBridgeCode.Value.Trim(), true);
    }
}
