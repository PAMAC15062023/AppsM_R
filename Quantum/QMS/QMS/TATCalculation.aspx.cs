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


public partial class QMS_QMS_TATCalculation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    string report;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
    }

    //private void Get_SupportEngineerList()
    //{
    //    try
    //    {
    //        sqlcon.Open();

    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlcon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_QMS_User_2";
    //        sqlCom.CommandTimeout = 0;

    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;

    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlcon.Close();

    //        ddlSPOC.DataTextField = "Fullname";
    //        ddlSPOC.DataValueField = "Emp_Code";
    //        ddlSPOC.DataSource = dt;
    //        ddlSPOC.DataBind();

    //        ddlSPOC.Items.Insert(0, new ListItem("--ALL--", "A"));
    //        ddlSPOC.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}

    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        grvTAT.DataSource = null;
        grvTAT.DataBind();

        if (ddlreport.SelectedValue.ToString() == "Get_QMS_EmployeeWise")
        {
            ddlSPOC.Visible = true;
           // Get_SupportEngineerList();
        }
        else
        {
            ddlSPOC.Visible = false;
            ddlSPOC.Attributes.Clear();
            ddlSPOC.DataSource = null;
            ddlSPOC.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlreport.SelectedValue.ToString() == "Get_QMS_TAT")
        {
            report = "Get_QMS_TAT";
        }
        else if (ddlreport.SelectedValue.ToString() == "Get_QMS_EmployeeWise")
        {
            report = "Get_QMS_EmployeeWise";
        }
        else if (ddlreport.SelectedValue.ToString() == "Get_QMS_TAT_OutOFTAT")
        {
            report = "Get_QMS_TAT_OutOFTAT";
        }

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = report;
            cmd.CommandTimeout = 0;

            if (ddlreport.SelectedValue.ToString() == "Get_QMS_TAT")
            {
                ddlSPOC.DataSource = null;
                ddlSPOC.DataBind();

                SqlParameter FromDate = new SqlParameter();
                FromDate.SqlDbType = SqlDbType.VarChar;
                FromDate.ParameterName = "@FromDate";
                FromDate.Value = strDate(txtfromdate.Text.ToString());
                cmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar;
                ToDate.ParameterName = "@ToDate";
                ToDate.Value = strDate(txtToDate.Text.ToString());
                cmd.Parameters.Add(ToDate);
            }

            if (ddlreport.SelectedValue.ToString() == "Get_QMS_EmployeeWise")
            {
                SqlParameter FromDate = new SqlParameter();
                FromDate.SqlDbType = SqlDbType.VarChar;
                FromDate.ParameterName = "@FromDate";
                FromDate.Value = strDate(txtfromdate.Text.ToString());
                cmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar;
                ToDate.ParameterName = "@ToDate";
                ToDate.Value = strDate(txtToDate.Text.ToString());
                cmd.Parameters.Add(ToDate);

                SqlParameter SPOC = new SqlParameter();
                SPOC.SqlDbType = SqlDbType.VarChar;
                SPOC.ParameterName = "@Emp_Code";
                SPOC.Value = ddlSPOC.SelectedValue.ToString();
                cmd.Parameters.Add(SPOC);
            }


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                grvTAT.DataSource = dt;
                grvTAT.DataBind();

                btnExport.Visible = true;
                lblMsg.Text = "Total Records Founds: " + dt.Rows.Count;
            }
            else
            {
                grvTAT.DataSource = null;
                grvTAT.DataBind();

                btnExport.Visible = true;
                lblMsg.Text = "No Record Found";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }

    public override void VerifyRenderingInServerForm(Control control)
    { }

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

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=QMS_TAT_Report.xls";

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
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>QMS TAT Report.</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grvTAT.EnableViewState = false;
        grvTAT.GridLines = GridLines.Both;
        grvTAT.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }
}
