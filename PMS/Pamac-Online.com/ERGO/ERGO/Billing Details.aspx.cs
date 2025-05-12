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

public partial class ERGO_ERGO_Billing_Details : System.Web.UI.Page
{

    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        
       if (!IsPostBack)
        {
            Get_MaxLotWise_Date();
        }
    }

    //private void RegisterControls_WithJavascript()
    //{
    //    btnGetReport.Attributes.Add("onclick", "javascript:return Validate_Generate();");
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
            Response.Redirect("Default.aspx");
    }

    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        //GetDiscrepancy_Report();
        SearchRecord();
    }

    //private void GetDiscrepancy_Report()
    //{
    //    Object SaveUSERInfo = (Object)Session["UserInfo"];
    //    SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    
    //    sqlCon.Open();
    //    SqlCommand sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlCon;
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    sqlCom.CommandText = ddlReportSelection.SelectedItem.Value.ToString().Trim(); //"GetBilling_Report";

    //    SqlParameter FrmDate = new SqlParameter();
    //    FrmDate.SqlDbType = SqlDbType.VarChar;
    //    FrmDate.Value = txtFromDate.Text.Trim();
    //    FrmDate.ParameterName = "@FrmDate";
    //    sqlCom.Parameters.Add(FrmDate);

    //    SqlParameter ToDate = new SqlParameter();
    //    ToDate.SqlDbType = SqlDbType.VarChar;
    //    ToDate.Value = txtToDate.Text.Trim();
    //    ToDate.ParameterName = "@ToDate";
    //    sqlCom.Parameters.Add(ToDate);
    
    //    SqlDataAdapter sqlDA = new SqlDataAdapter();
    //    sqlDA.SelectCommand = sqlCom;
    //    DataTable dt = new DataTable();
    //    sqlDA.Fill(dt);
    //    sqlCon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();

    //        lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
    //        lblMessage.CssClass = "SuccessMessage";
    //    }
    //    else
    //    {

    //        GridView1.DataSource = null;
    //        GridView1.DataBind();

    //        lblMessage.Text = "No Record Found!";
    //        lblMessage.CssClass = "ErrorMessage";
    //    }

    //}
    
    private void Get_MaxLotWise_Date()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];


        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "GetBilling_Report_MaxLotWise_Null";

    
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
            lblMessage.CssClass = "SuccessMessage";
        }
        else
        {

            GridView1.DataSource = null;
            GridView1.DataBind();

            lblMessage.Text = "No Record Found!";
            lblMessage.CssClass = "ErrorMessage";
        }

    }

    protected void btnRetrive_Click(object sender, EventArgs e)
    {
        try
        {
            Generate_ExcelFile();

        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void Generate_ExcelFile()
    {
    //    String attachment = "attachment; filename=Master Report.xls";
    //    Response.AddHeader("content-disposition", attachment);
    //    Response.ContentType = "application/ms-excel";
    //    StringWriter sw = new System.IO.StringWriter();
    //    HtmlTextWriter htw = new HtmlTextWriter(sw);
    //    Table tblSpace = new Table();
    //    TableRow tblRow = new TableRow();
    //    TableCell tblCell = new TableCell();
    //    tblCell.Text = " ";

    //    TableRow tblRow1 = new TableRow();
    //    TableCell tblCell1 = new TableCell();
    //    tblCell1.ColumnSpan = 20;// 10;
    //    tblCell1.Text = "<b><font size='4'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
    //                    "<b><font size='2' color='blue'>Report</font></b> <br/>";
    //    tblCell1.CssClass = "SuccessMessage";
    //    tblRow.Cells.Add(tblCell);
    //    tblRow1.Cells.Add(tblCell1);
    //    tblRow.Height = 20;
    //    tblSpace.Rows.Add(tblRow);
    //    tblSpace.Rows.Add(tblRow1);
    //    tblSpace.RenderControl(htw);

    //    Table tbl = new Table();
    //    GridView1.EnableViewState = false;
    //    GridView1.GridLines = GridLines.Both;

    //    tbExport.RenderControl(htw);
    //    Response.Write(sw.ToString());

    //    Response.End();
        
        String attachment = "attachment; filename=Report.xls";
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Context.Response.AddHeader("content-disposition", attachment);
        Context.Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/>" +
        //                "<b><font size='2'>Client Call/Visit Tracker Report FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GridView1.GridLines = GridLines.Both;
        GridView1.EnableViewState = false;
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();


    }
    
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //txtFromDate.Text="";
        //txtToDate.Text="";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void ddlReportSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        SearchRecord();
    }
    
    private void SearchRecord()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        
        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = ddlReportSelection.SelectedItem.Value.ToString().Trim(); //"GetBilling_Report";

        if (ddlReportSelection.SelectedItem.Value.ToString() == "Get_InvoiceProcessData_New_Recd" || ddlReportSelection.SelectedItem.Value.ToString() == "GetBilling_Report_MaxLotWise" || ddlReportSelection.SelectedItem.Value.ToString() == "Get_InvoiceProcessData_New")
        {
            SqlParameter FrmDate = new SqlParameter();
            FrmDate.SqlDbType = SqlDbType.VarChar;
            FrmDate.Value = txtFromDate.Text.Trim();
            FrmDate.ParameterName = "@FrmDate";
            sqlCom.Parameters.Add(FrmDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);
        }
       
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblMessage.Text = "Total Records Found " + dt.Rows.Count.ToString();
            lblMessage.CssClass = "SuccessMessage";
        }
        else
        {

            GridView1.DataSource = null;
            GridView1.DataBind();

            lblMessage.Text = "No Record Found!";
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {

    }
}


