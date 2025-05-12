using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;
public partial class CPA_PD_PendingListMIS : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string Report;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        grddemo.Visible = false;

        //Search12();
        if (!IsPostBack)
        {
          //  grdExcelReport.Columns[16].Visible = true;
           // grdExcelReport.Columns[17].Visible = false;

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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        try
        {
            if (ddlReportType.SelectedValue.ToString() == "get_pd_pending_data123")
            {
                Report = "get_pd_pending_data123";
            }
            else if (ddlReportType.SelectedValue.ToString() == "sp_BillingMis")
            {
                Report = "sp_BillingMis";
            }
            else if (ddlReportType.SelectedValue.ToString() == "sp_PD_FEProductivity_mis")
            {
                Report = "sp_PD_FEProductivity_mis";
            }
            //else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_PickUpToDepositTAT")
            //{
            //    Report = "DCR_Get_PickUpToDepositTAT";
            //}
            //else if (ddlReportType.SelectedValue.ToString() == "stp_ChequeScanTATMIS")
            //{
            //    Report = "stp_ChequeScanTATMIS";
            //}
            //else if (ddlReportType.SelectedValue.ToString() == "stp_DepositScanTATMIS")
            //{
            //    Report = "stp_DepositScanTATMIS";
            //}
            //else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_Billing_MIS")
            //{
            //    Report = "DCR_Get_Billing_MIS";
            //}
            //else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_MasterFile")
            //{
            //    Report = "DCR_Get_MasterFile";
            //}

            else
            {
                lblMsg.Text = "No Records Found.";
            }

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Report;
            cmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            cmd.Parameters.Add(ToDate);

            SqlParameter centre_id = new SqlParameter();
            centre_id.SqlDbType = SqlDbType.VarChar;
            centre_id.Value = Session["Centreid"].ToString().Trim();
            centre_id.ParameterName = "@centre_ID";
            cmd.Parameters.Add(centre_id);

            SqlParameter client_id = new SqlParameter();
            client_id.SqlDbType = SqlDbType.VarChar;
            client_id.Value = Session["ClientID"].ToString().Trim();
            client_id.ParameterName = "@Client_ID";
            cmd.Parameters.Add(client_id);



            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                btnExport.Visible = true;
                lblMsg.Text = "Total Records Founds: " + dt.Rows.Count;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                btnExport.Visible = false;
                lblMsg.Text = "No Records Found...!!!";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: " + ex.Message;
        }
    }



    //private void Search12()
    //{
    //    try
    //    {
    //        sqlcon.Open();

    //        SqlCommand cmd = new SqlCommand();
    //        cmd.Connection = sqlcon;
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "client_name";
    //        cmd.CommandTimeout = 0;

    //        //SqlParameter FromDate = new SqlParameter();
    //        //FromDate.SqlDbType = SqlDbType.VarChar;
    //        //FromDate.Value = strDate(txtFromDate.Text.Trim());
    //        //FromDate.ParameterName = "@FromDate";
    //        //cmd.Parameters.Add(FromDate);

    //        //SqlParameter ToDate = new SqlParameter();
    //        //ToDate.SqlDbType = SqlDbType.VarChar;
    //        //ToDate.Value = strDate(txtToDate.Text.Trim());
    //        //ToDate.ParameterName = "@ToDate";
    //        //cmd.Parameters.Add(ToDate);

    //        //SqlParameter centre_id = new SqlParameter();
    //        //centre_id.SqlDbType = SqlDbType.VarChar;
    //        //centre_id.Value = Session["Centreid"].ToString().Trim();
    //        //centre_id.ParameterName = "@centre_ID";
    //        //cmd.Parameters.Add(centre_id);

    //        SqlParameter client_id = new SqlParameter();
    //        client_id.SqlDbType = SqlDbType.VarChar;
    //        client_id.Value = Session["ClientID"].ToString().Trim();
    //        client_id.ParameterName = "@Client_ID";
    //        cmd.Parameters.Add(client_id);



    //        SqlDataAdapter da = new SqlDataAdapter();
    //        da.SelectCommand = cmd;

    //        DataTable dt = new DataTable();
    //        da.Fill(dt);

    //        string value = da;

    //        sqlcon.Close();

    //        if (dt.Rows.Count > 0)
    //        {
    //            btnExport.Visible = true;
    //            lblMsg.Text = "Total Records Founds: " + dt.Rows.Count;
    //            grddemo.DataSource = dt;
    //            grddemo.DataBind();
    //        }
    //        else
    //        {
    //            btnExport.Visible = false;
    //            lblMsg.Text = "No Records Found...!!!";
    //            grddemo.DataSource = null;
    //            grddemo.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "Error: " + ex.Message;
    //    }
    //}


    protected void btnExport_Click(object sender, EventArgs e)
    {
        Search();
        Generate_ExcelFile();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    public void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=DCR_Report.xls";

        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        int i=0;
       // string values = GridView1.Rows[i].Cells[16].Text.Trim();
        //tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
        //                "<b><font size='3' color='red'> PD Report.</font></b> <br/>";
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/>" +
                        "<b><font size='2'>Tracker Report FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>" +
                          "<b><font size='2'>Client Name :   </font></b> <br/><br/><br/>";
         
                       //"<b><font size='2'>Client Name : " + values +  " </font></b> <br/><br/><br/>";
     

       
        //"<b><font size='2'>Tracker Report FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        //"<b><font size='2'>Client Name : " + values + " </font></b> <br/><br/><br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        GridView1.EnableViewState = false;
        GridView1.GridLines = GridLines.Both;
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    //protected void grdExcelReport_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //}
    //protected void grdExcelReport_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}
