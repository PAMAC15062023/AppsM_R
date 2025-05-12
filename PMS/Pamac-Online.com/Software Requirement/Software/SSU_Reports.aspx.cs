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

public partial class Software_Requirement_Software_SSU_Reports : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            try
            {
                lblmsg.Visible = true;
                //Searchload();
                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                Get_ClusterList();
            }
            catch (Exception Ex)
            {
                lblmsg.Text = Ex.Message;
            }
            finally
            {

            }
        }
    }
    private void Get_ClusterList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_ClusterList1";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcluster.DataTextField = "Cluster_Name";
                ddlcluster.DataValueField = "Cluster_id";

                ddlcluster.DataSource = dt1;
                ddlcluster.DataBind();

                ddlcluster.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlcluster.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    private void Get_CentreList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_CentreList1";
            cmd2.CommandTimeout = 0;


            SqlParameter ClusterId = new SqlParameter();
            ClusterId.SqlDbType = SqlDbType.VarChar;
            ClusterId.SqlValue = ddlcluster.SelectedValue.ToString();
            ClusterId.ParameterName = "@Cluster_Id";
            cmd2.Parameters.Add(ClusterId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcentre.DataTextField = "Centre_Name";
                ddlcentre.DataValueField = "Centre_id";

                ddlcentre.DataSource = dt1;
                ddlcentre.DataBind();

                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList1";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentre.DataTextField = "SubCentreName";
                ddlsubcentre.DataValueField = "SubCentreid";

                ddlsubcentre.DataSource = dt1;
                ddlsubcentre.DataBind();

                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlsubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;

        }
    }
    protected void ddlcluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_CentreList();
    }

    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
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
    protected void Grdexport_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lblmsg.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();

        //Response.Redirect("Default.aspx");
    }
    private void Generate_ExcelFile()
    {
        DataTable dt = new DataTable();

        dt = Session["Report_Export_ssu"] as DataTable;

        DataTable dt_copy = new DataTable();

        dt_copy = dt.Copy();
        

        //lblmsg.Text = dt.ToString();
        string filename = "SSU TEAM STATUS Report" + DateTime.Now + ".xls";
        String attachment = "attachment; filename=SSU_Team_Status.xls";

        Response.Clear();

        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename= " + filename);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;

        tblCell.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>SSU TEAM STATUS Report.</font></b> <br/>";


        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 10;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(new HtmlTextWriter(Response.Output));
        GrdView.GridLines = GridLines.Both;

        GrdView.DataSource = dt_copy;
        GrdView.DataBind();

        GrdView.RenderControl(new HtmlTextWriter(Response.Output));
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    { }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }

    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        Search();
    }
    private void Search()
    {
        //Note By Yasir ;- Old SP(Get_SSU_STATUS12) New SP (USP_Get_All_SSU_Report)
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "USP_GetAllSSUReport_SP";
            cmd.CommandTimeout = 0;

            SqlParameter Clusterid = new SqlParameter();
            Clusterid.SqlDbType = SqlDbType.VarChar;
            Clusterid.Value = ddlcluster.SelectedValue.ToString();
            Clusterid.ParameterName = "@clusterid";
            cmd.Parameters.Add(Clusterid);

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlcentre.SelectedValue.ToString();
            CentreID.ParameterName = "@CentreID";
            cmd.Parameters.Add(CentreID);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentre.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd.Parameters.Add(SubCentreId);


            SqlParameter overallremark = new SqlParameter();
            overallremark.SqlDbType = SqlDbType.VarChar;
            overallremark.Value = ddloverallremark.SelectedValue.ToString();
            overallremark.ParameterName = "@overallremark";
            cmd.Parameters.Add(overallremark);


            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();



            

            if (dt.Rows.Count > 0)
            { 

                GrdView.DataSource = dt;
                GrdView.DataBind();
                Session["Report_Export_ssu"] = dt;
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = null;
                GrdView.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }
}