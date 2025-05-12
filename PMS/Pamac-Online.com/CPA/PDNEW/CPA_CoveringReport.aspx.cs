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

public partial class CPA_PD_CPA_CoveringReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ControlValidation();
        }
    }

    private void ControlValidation()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return ValidControl();");   
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Session["CentreId"].ToString() == "1011")
        {
            HoSearchData();
        }
        else
        {
            CentreSearchData();
        }
    }

    private void HoSearchData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_CoveringReport_HO";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@Fromdate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();
            Todate.SqlDbType = SqlDbType.VarChar;
            Todate.Value = txtToDate.Text.Trim();
            Todate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(Todate);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientID"].ToString();
            ClientId.ParameterName = "@CleintId";
            sqlcmd.Parameters.Add(ClientId);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnExportExcel.Visible = true;
                lblMessage.Text = "Total Count : " + dt.Rows.Count;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                btnExportExcel.Visible = false;
                lblMessage.Text = "Record Not Found.......!!!!!";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    
    }

    private void CentreSearchData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_CoveringReport_Centre";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@Fromdate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();
            Todate.SqlDbType = SqlDbType.VarChar;
            Todate.Value = txtToDate.Text.Trim();
            Todate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(Todate);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientID"].ToString();
            ClientId.ParameterName = "@ClientID";
            sqlcmd.Parameters.Add(ClientId);

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = Session["CentreId"].ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnExportExcel.Visible = true;
                lblMessage.Text = "Total Count : " + dt.Rows.Count;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                btnExportExcel.Visible = false;
                lblMessage.Text = "Record Not Found.......!!!!!";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=Covering Report.xls";
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
                        "<b><font size='2'>Covering Report FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";     
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
        
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

}
