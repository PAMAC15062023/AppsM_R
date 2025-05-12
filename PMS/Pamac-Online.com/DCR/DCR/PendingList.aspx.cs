using System;
using System.Data;
using System.Data.OleDb;
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
using Microsoft.Office.Core;
using System.Configuration.Assemblies;

public partial class DCR_DCR_PendingList : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string Report;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
           // Get_CentreList();
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

    private void Get_CentreList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_CentreList";
            cmd2.CommandTimeout = 0;


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

                //ddlcentre.Items.Insert(0, new ListItem("--ALL--", "0"));
                //ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }





    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        try
        {
            if (ddlReportType.SelectedValue.ToString() == "DCR_Get_Pending_Report")
            {
                Report = "DCR_Get_Pending_Report";
            }
            else if (ddlReportType.SelectedValue.ToString() == "stp_DCRTATByPickUpDate")
            {
                Report = "stp_DCRTATByPickUpDate";
            }
            else if (ddlReportType.SelectedValue.ToString() == "stp_OverALLTATMIS")
            {
                Report = "stp_OverALLTATMIS";
            }
            else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_PickUpToDepositTAT")
            {
                Report = "DCR_Get_PickUpToDepositTAT";
            }
            else if (ddlReportType.SelectedValue.ToString() == "stp_ChequeScanTATMIS")
            {
                Report = "stp_ChequeScanTATMIS";
            }
            else if (ddlReportType.SelectedValue.ToString() == "stp_DepositScanTATMIS")
            {
                Report = "stp_DepositScanTATMIS";
            }
            else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_Billing_MIS")
            {
                Report = "DCR_Get_Billing_MIS";
            }
            else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_MasterFile")
            {
                Report = "DCR_Get_MasterFile";
            }

            else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_Allclient_Report123")
            {
                Report = "DCR_Get_Allclient_Report123";
            }

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


            if (ddlReportType.SelectedValue.ToString()=="DCR_Get_Allclient_Report123")
            {
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




                //SqlParameter ClientID = new SqlParameter();
                //ClientID.SqlDbType = SqlDbType.VarChar;
                //ClientID.Value = Session["ClientID"].ToString().Trim();
                //ClientID.ParameterName = "@Client_ID";
                //cmd.Parameters.Add(ClientID);


                //if (ddlcentre.SelectedValue== "")
                //{
                 

                //    SqlParameter CentreID = new SqlParameter();
                //    CentreID.SqlDbType = SqlDbType.VarChar;
                //    CentreID.Value = Session["CentreID"].ToString().Trim();
                //    CentreID.ParameterName = "@Centre_ID";
                //    cmd.Parameters.Add(CentreID);
                //}
                //else
                //{
                //    SqlParameter CentreID = new SqlParameter();
                //    CentreID.SqlDbType = SqlDbType.VarChar;
                //    CentreID.Value =ddlcentre.SelectedValue.ToString();
                //    CentreID.ParameterName = "@Centre_ID";
                //    cmd.Parameters.Add(CentreID);

                
                //}

            }
            else if (ddlReportType.SelectedValue.ToString() == "DCR_Get_Pending_Report")
            {


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

                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.VarChar;
                ClientID.Value = Session["ClientID"].ToString().Trim();
                ClientID.ParameterName = "@Client_ID";
                cmd.Parameters.Add(ClientID);

                SqlParameter CentreID = new SqlParameter();
                CentreID.SqlDbType = SqlDbType.VarChar;
                CentreID.Value = Session["centreid"].ToString().Trim();
                CentreID.ParameterName = "@Centre_ID";
                cmd.Parameters.Add(CentreID);


                //if (ddlcentre.SelectedValue=="")
                //{


                //    SqlParameter CentreID = new SqlParameter();
                //    CentreID.SqlDbType = SqlDbType.VarChar;
                //    CentreID.Value = Session["CentreID"].ToString().Trim();
                //    CentreID.ParameterName = "@Centre_ID";
                //    cmd.Parameters.Add(CentreID);
                //}
                //else
                //{
                //    SqlParameter CentreID = new SqlParameter();
                //    CentreID.SqlDbType = SqlDbType.VarChar;
                //    CentreID.Value = ddlcentre.SelectedValue.ToString();
                //    CentreID.ParameterName = "@Centre_ID";
                //    cmd.Parameters.Add(CentreID);


                //}

            }
            else
            {


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




                SqlParameter ClientID = new SqlParameter();
                ClientID.SqlDbType = SqlDbType.VarChar;
                ClientID.Value = Session["ClientID"].ToString().Trim();
                ClientID.ParameterName = "@Client_ID";
                cmd.Parameters.Add(ClientID);
            
            
            
            
            }




            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                btnExport.Visible = true;
                lblMsg.Text = "Total Records Founds: " + dt.Rows.Count;
                grdExcelReport.DataSource = dt;
                grdExcelReport.DataBind();
            }
            else
            {
                btnExport.Visible = false;
                lblMsg.Text = "No Records Found...!!!";
                grdExcelReport.DataSource = null;
                grdExcelReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: " + ex.Message;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
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
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='3' color='red'>PAN India DCR Report.</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grdExcelReport.EnableViewState = false;
        grdExcelReport.GridLines = System.Web.UI.WebControls.GridLines.Both;
        grdExcelReport.RenderControl(htw);
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



}
