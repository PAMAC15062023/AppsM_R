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
using System.Text;
using System.IO;

public partial class BSC_BSC_BSCReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    CCommon con = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindClient();
        }
    }

    public void BindClient()
    {

        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "BSC_BindClient";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_code = new SqlParameter();
        Emp_code.SqlDbType = SqlDbType.VarChar;
        Emp_code.Value = Session["UserId"].ToString();
        Emp_code.ParameterName = "@Emp_Id";
        sqlcmd.Parameters.Add(Emp_code);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        ddlClientName.DataSource = dt;
        ddlClientName.DataTextField = "Client_Name";
        ddlClientName.DataValueField = "Client_Id";
        ddlClientName.DataBind();
        ddlClientName.Items.Insert(0, "--Select--");

        sqlcon.Close();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        if (txtFromDate.Text != "" && txtToDate.Text != "" && ddlReport.SelectedIndex != 0)
        {
            Report();
        }
        else
        {
            lblMsg.Text = "Please Select Proper Fileds.....!!!!!!";
            lblMsg.Visible = true;
        }
    }

    protected void Report()
    {
        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ddlReport.SelectedValue.ToString();
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

                SqlParameter ClientName = new SqlParameter();
                ClientName.SqlDbType = SqlDbType.VarChar;
                ClientName.Value = ddlClientName.SelectedItem.Text.ToString();
                ClientName.ParameterName = "@ClientName";
                cmd.Parameters.Add(ClientName);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }
        catch (SqlException sqlex)
        {
        }
        catch (SystemException ex)
        {
        }
        finally
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
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

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=" + ddlClientName.SelectedItem.ToString() + ".xls";
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";
        tblCell.ColumnSpan = 10;// 10;
        tblCell.Text = "<b> <font size='2' color='blue'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
        "<b><font size='2' color='blue'>From Date " + txtFromDate.Text + " To " + txtToDate.Text + " </font></b> <br/>";
        tblCell.CssClass = "SuccessMessage";
        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
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
        tbExport.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        if (GridView1.Rows.Count > 0)
        {
            Generate_ExcelFile();
        }
        else
        {
            lblMsg.Text = "No Records Found...!!!!!!";
            lblMsg.Visible = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
