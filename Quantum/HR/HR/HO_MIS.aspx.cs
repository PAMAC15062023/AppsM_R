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
using System.Configuration;
using System.IO; 

public partial class HR_HR_HO_MIS : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        CCommon objConn = new CCommon();
        SDScluster.ConnectionString = objConn.ConnectionString;  //Sir

        if (!IsPostBack)
        {
            ValiDation_Search();

        }
    }
    protected void ValiDation_Search()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return OnSearch_Validation();");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        NewJoinMis();
    }
    private void NewJoinMis()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            string StoreProc = "";

            if (ddlMisType.SelectedIndex != 0)
            {
                StoreProc = ddlMisType.SelectedItem.Value.Trim();
            }

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = StoreProc;
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            SqlParameter ClustId = new SqlParameter();
            ClustId.SqlDbType = SqlDbType.VarChar;
            ClustId.Value = ddlCluster.SelectedValue.ToString();
            ClustId.ParameterName = "@ClusterId";
            sqlcmd.Parameters.Add(ClustId);

            SqlParameter CentName = new SqlParameter();
            CentName.SqlDbType = SqlDbType.VarChar;
            CentName.Value = ddlCenter.SelectedValue.ToString();
            CentName.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentName);

            SqlParameter SCentName = new SqlParameter();
            SCentName.SqlDbType = SqlDbType.VarChar;
            SCentName.Value = ddlSubcenter.SelectedValue.ToString();
            SCentName.ParameterName = "@SubcentreId";
            sqlcmd.Parameters.Add(SCentName);

            if (ddlMisType.SelectedItem.ToString() == "PAMACian Leave MIS")
            {
                SqlParameter EmpName = new SqlParameter();
                EmpName.SqlDbType = SqlDbType.VarChar;
                EmpName.Value = ddlEmpName.SelectedValue.ToString();
                EmpName.ParameterName = "@EmpName";
                sqlcmd.Parameters.Add(EmpName);
            }

            SqlParameter FrDate = new SqlParameter();
            FrDate.SqlDbType = SqlDbType.VarChar;
            FrDate.Value = txtFromDate.Text.Trim();
            FrDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FrDate);

            SqlParameter TDate = new SqlParameter();
            TDate.SqlDbType = SqlDbType.VarChar;
            TDate.Value = txtToDate.Text.Trim();
            TDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(TDate);

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total No of Record :" + dt.Rows.Count;
                GV.DataSource = dt;
                GV.DataBind();
            }
            else
            {
                lblMessage.Text = "Total No of Record :" + dt.Rows.Count;
                GV.DataSource = null;
                GV.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        //String attachment = "attachment; filename=Left Pamacian MIS.xls";
        //Response.AddHeader("content-disposition", attachment);
        //Response.ContentType = "application/ms-excel";
        //StringWriter sw = new System.IO.StringWriter();
        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //Table tblSpace = new Table();
        //TableRow tblRow = new TableRow();
        //TableCell tblCell = new TableCell();
        //tblCell.Text = " ";

        //TableRow tblRow1 = new TableRow();
        //TableCell tblCell1 = new TableCell();
        //tblCell1.ColumnSpan = 20;// 10;
        //tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
        //                "<b><font size='2' color='blue'> " + ddlMisType.SelectedItem.Text + " For Date : " + txtFromDate.Text + " To : " + txtToDate.Text + " </font></b> <br/>";
        //tblCell1.CssClass = "SuccessMessage";
        //tblRow.Cells.Add(tblCell);
        //tblRow1.Cells.Add(tblCell1);
        //tblRow.Height = 20;
        //tblSpace.Rows.Add(tblRow);
        //tblSpace.Rows.Add(tblRow1);
        //tblSpace.RenderControl(htw);

        //Table tbl = new Table();
        //GV.EnableViewState = false;
        //GV.GridLines = GridLines.Both;
        //tbExport.RenderControl(htw);
        //Response.Write(sw.ToString());

        //Response.End();

        String attachment = "attachment; filename="+ ddlMisType.SelectedItem.Text + ".xls";
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
                        "<b><font size='2' color='blue'> " + ddlMisType.SelectedItem.Text + " For Date : " + txtFromDate.Text + " To : " + txtToDate.Text + " </font></b> <br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);

        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GV.GridLines = GridLines.Both;
        GV.EnableViewState = false;
        GV.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();



    }


    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ddlCluster_DataBound(object sender, EventArgs e)
    {
        ddlCluster.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCentre();
        //ddlSubcenter.SelectedIndex = 0;

    }
    private void FillCentre()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_CentreName";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        SqlParameter CentName = new SqlParameter();
        CentName.SqlDbType = SqlDbType.VarChar;
        CentName.Value = ddlCluster.SelectedValue.ToString();
        CentName.ParameterName = "@ClusterId";
        sqlcmd.Parameters.Add(CentName);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCenter.DataTextField = "CENTRE_NAME";
            ddlCenter.DataValueField = "CENTRE_ID";
            ddlCenter.DataSource = dt;
            ddlCenter.DataBind();
        }

    }
    protected void ddlCenter_DataBound(object sender, EventArgs e)
    {
        ddlCenter.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlSubcenter_DataBound(object sender, EventArgs e)
    {
        ddlSubcenter.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubCentername";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        SqlParameter SCentName = new SqlParameter();
        SCentName.SqlDbType = SqlDbType.VarChar;
        SCentName.Value = ddlCenter.SelectedValue.ToString();
        SCentName.ParameterName = "@Centreid";
        sqlcmd.Parameters.Add(SCentName);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlSubcenter.DataTextField = "SubCentreName";
            ddlSubcenter.DataValueField = "SubCentreId";
            ddlSubcenter.DataSource = dt;
            ddlSubcenter.DataBind();

        }

    }
    protected void ddlMisType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMisType.SelectedItem.ToString() == "PAMACian Leave MIS")
        {
            lblEmpName.Visible = true;
            ddlEmpName.Visible = true;
        }
        else
        {
            lblEmpName.Visible = false;
            ddlEmpName.Visible = false;
        }
    }
    protected void ddlSubcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmpNameMaster";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        SqlParameter CentId = new SqlParameter();
        CentId.SqlDbType = SqlDbType.VarChar;
        CentId.Value = ddlCenter.SelectedValue.ToString();
        CentId.ParameterName = "@CentreId";
        sqlcmd.Parameters.Add(CentId);

        SqlParameter SubId = new SqlParameter();
        SubId.SqlDbType = SqlDbType.VarChar;
        SubId.Value = ddlSubcenter.SelectedValue.ToString();
        SubId.ParameterName = "@SubcentreId";
        sqlcmd.Parameters.Add(SubId);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlEmpName.DataTextField = "FullName";
            ddlEmpName.DataValueField = "Emp_code";
            ddlEmpName.DataSource = dt;
            ddlEmpName.DataBind();
        }
    }
    protected void ddlEmpName_DataBound(object sender, EventArgs e)
    {
        ddlEmpName.Items.Insert(0, new ListItem("All", "0"));
    }
}
