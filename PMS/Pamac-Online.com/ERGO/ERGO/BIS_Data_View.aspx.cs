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

public partial class ERGO_ERGO_BIS_Data_View : System.Web.UI.Page
{

    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            GetBridgeCodeDetails();
            GetPayeeDetails();
            // btnExportEx.Visible = false;  
        }
        RegisterControls_WithJavascript();
    }

    private void RegisterControls_WithJavascript()
    {
        btnView.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");

    }
    private void GetBridgeCodeDetails()
    {
        try
        {

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Bridge_Code_And_Payee_Details";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlBridgeCode.DataTextField = "Bridge_Code";
            ddlBridgeCode.DataValueField = "Bridge_Code";
            ddlBridgeCode.DataSource = dt;
            ddlBridgeCode.DataBind();

            ddlBridgeCode.Items.Insert(0, "-Select-");
            ddlBridgeCode.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";

        }
    }
    private void GetPayeeDetails()
    {
        try
        {

            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_Bridge_Code_And_Payee_Details";
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            ddlPayeeName.DataTextField = "Alternate_Payee_Name";
            ddlPayeeName.DataValueField = "Alternate_Payee_Name";
            ddlPayeeName.DataSource = dt;
            ddlPayeeName.DataBind();

            ddlPayeeName.Items.Insert(0, "-Select-");
            ddlPayeeName.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
            lblError.CssClass = "ErrorMessage";

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        //sqlcmd.CommandText = "Get_ErgoMainBisData";
        sqlcmd.CommandText = "Get_Ergo_VenderMasterDetails";
        sqlcmd.CommandTimeout = 0;

        string intBridgeCode = "";
        if (ddlBridgeCode.SelectedIndex != 0)
        {
            intBridgeCode = ddlBridgeCode.SelectedItem.Value.Trim();
        }
        else
        {
            intBridgeCode = txtBridgeCode.Text.Trim();
        }

        SqlParameter Bridge_Code = new SqlParameter();
        Bridge_Code.SqlDbType = SqlDbType.VarChar;
        Bridge_Code.Value = intBridgeCode;
        Bridge_Code.ParameterName = "@Bridge_Code";
        sqlcmd.Parameters.Add(Bridge_Code);

        SqlParameter Bis_Recd_Date = new SqlParameter();
        Bis_Recd_Date.SqlDbType = SqlDbType.VarChar;
        Bis_Recd_Date.Value = txtBisDate.Text.Trim();
        Bis_Recd_Date.ParameterName = "@Bis_Recd_Date";
        sqlcmd.Parameters.Add(Bis_Recd_Date);

        SqlParameter Location = new SqlParameter();
        Location.SqlDbType = SqlDbType.VarChar;
        Location.Value = txtLocation.Text.Trim();
        Location.ParameterName = "@Location";
        sqlcmd.Parameters.Add(Location);

        string intPayeeName = "";
        if (ddlPayeeName.SelectedIndex != 0)
        {
            intPayeeName = ddlPayeeName.SelectedItem.Value.Trim();
        }

        SqlParameter Alternate_Payee_Name = new SqlParameter();
        Alternate_Payee_Name.SqlDbType = SqlDbType.VarChar;
        Alternate_Payee_Name.Value = intPayeeName;
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
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            lblError.CssClass = "ErrorMessage";
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlBridgeCode.SelectedIndex = 0;
        ddlPayeeName.SelectedIndex = 0;
        txtBisDate.Text = "";
        txtLocation.Text = "";

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("BIS_entry.aspx?&TID=" + hdnBridgeCode.Value.Trim(), true);

    }
    protected void hdnBridgeCode_ValueChanged(object sender, EventArgs e)
    {

    }
}
