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

public partial class Admin_Operational_call_visit_Review_tracker_Operational_MIS : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {

        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            BtnFind.Visible = true;
            PnlGrid.Visible = false;
            BtnExportToExel.Visible = false;

            Get_ClientListsearch();
        }
    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        PnlExport.Visible = true;
        BtnExportToExel.Visible = true;
        PnlGrid.Visible = true;
        BtnFind.Visible = false;

        try
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand CMD2 = new SqlCommand();
            CMD2.Connection = sqlcon;
            CMD2.CommandType = CommandType.StoredProcedure;
            CMD2.CommandText = "Sp_operationalVisiExportToExel_new";
            CMD2.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            CMD2.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            CMD2.Parameters.Add(Todate);

            SqlParameter Client_Name = new SqlParameter();
            Client_Name.SqlDbType = SqlDbType.VarChar;
            Client_Name.Value = ddlVH.SelectedValue.ToString();
            Client_Name.ParameterName = "@Client_Id";
            CMD2.Parameters.Add(Client_Name);

            SqlParameter Vertical = new SqlParameter();
            Vertical.SqlDbType = SqlDbType.VarChar;
            Vertical.Value = DDLVerticalsearch.SelectedValue.ToString();
            Vertical.ParameterName = "@Vertical";
            CMD2.Parameters.Add(Vertical);

            sqlcon.Close();

            SqlDataAdapter Sqlda = new SqlDataAdapter();
            Sqlda.SelectCommand = CMD2;

            DataTable dt = new DataTable();
            Sqlda.Fill(dt);

            GridView2.DataSource = dt;
            GridView2.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblmessage.Text = "Total Count is: " + dt.Rows.Count;
            }
            else
            {
                lblmessage.Text = "Record Not Found";
            }

        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message;
        }
    }

    protected void BtnExportToExel_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=Client Meeting Tracker.xls";
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
                        "<b><font size='2'>Client Meeting Tracker FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GridView2.GridLines = GridLines.Both;
        GridView2.EnableViewState = false;
        GridView2.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    // IMP
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void BTReset_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lblmessage.Text = "";
        PnlGrid.Visible = false;
        BtnExportToExel.Visible = false;
        BtnFind.Visible = true;
        ddlVH.SelectedIndex = 0;
        DDLVerticalsearch.SelectedIndex = 0;
    }

    private void Get_ClientListsearch()
    {
        sqlcon.Open();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = sqlcon;
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "Get_ClientList";
        cmd1.CommandTimeout = 0;

        SqlDataAdapter sqlda1 = new SqlDataAdapter();
        sqlda1.SelectCommand = cmd1;

        DataTable dt1 = new DataTable();
        sqlda1.Fill(dt1);

        sqlcon.Close();

        if (dt1.Rows.Count > 0)
        {
            //DdlSearchClient.DataTextField = "Client_name";
            //DdlSearchClient.DataValueField = "Client_ID";

            //DdlSearchClient.DataSource = dt1;
            //DdlSearchClient.DataBind();

            //DdlSearchClient.Items.Insert(0, new ListItem("--ALL--", "0"));
            //DdlSearchClient.SelectedIndex = 0;
        }

    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

}
