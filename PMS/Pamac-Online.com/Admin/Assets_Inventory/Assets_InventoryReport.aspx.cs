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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;

public partial class Admin_Assets_Inventory_Assets_InventoryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlreportpc.Visible = false;
            GetCentreList();
        }
    }

    private void GetCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "CPA_CentreNameList_New";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCenterList.DataTextField = "Centre_name";
            ddlCenterList.DataValueField = "centre_id";

            ddlCenterList.DataSource = dt;
            ddlCenterList.DataBind();

            ddlCenterList.Items.Insert(0, new ListItem("--All--", "--All--"));

            ddlsubcentrelist.Items.Insert(0, new ListItem("--All--", "--All--"));
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        String Procedure;


        Procedure = DdlSp.SelectedValue.ToString();


        if (Procedure == "Get_AssetsMISOwnedRented")
        {
            CountMIS();
        }
        else if (Procedure == "PC")
        {
            PCMIS();
        }
        else if (Procedure == "Get_AssetsMISOwnedRented_BranchWise")
        {
            CountMISBranch();
        }
        else if (Procedure == "SummaryMIS_ForAssets")
        {
            Get_SummaryMIS_ALLZone();

        }
        else if (Procedure == "Assets Status Report")
        {
            Get_AssetsStatus_Report();
        }
        else
        {
            try
            {
                CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = Procedure;
                sqlcmd.CommandTimeout = 0;

                SqlParameter CentreId = new SqlParameter();
                CentreId.SqlDbType = SqlDbType.VarChar;
                CentreId.Value = ddlCenterList.SelectedValue.ToString();
                CentreId.ParameterName = "@CentreId";
                sqlcmd.Parameters.Add(CentreId);

                SqlParameter SubCentreId = new SqlParameter();
                SubCentreId.SqlDbType = SqlDbType.VarChar;
                SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
                SubCentreId.ParameterName = "@Subcentre_id";
                sqlcmd.Parameters.Add(SubCentreId);

                //sqlcmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim());
                //sqlcmd.Parameters.AddWithValue("@ToDate", txtToDate.Text.Trim());

                //new added
                SqlParameter FromDate = new SqlParameter();
                FromDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
                FromDate.Value = strDate(txtFromDate.Text.Trim()); //txtFromDate.Text.Trim(); //strDate(txtFromDate.Text.Trim());
                FromDate.ParameterName = "@FromDate";
                sqlcmd.Parameters.Add(FromDate);

                SqlParameter ToDate = new SqlParameter();
                ToDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
                ToDate.Value = strDate(txtToDate.Text.Trim()); //txtToDate.Text.Trim(); //strDate(txtToDate.Text.Trim());
                ToDate.ParameterName = "@ToDate";
                sqlcmd.Parameters.Add(ToDate);

                ////comp

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
                    lblMessage.Text = "";
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblMessage.Text = "Record Not Found";
                    btnExportExcel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
    private void PCMIS()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = ddlreportpc.SelectedValue.ToString();
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
            SubCentreId.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(SubCentreId);

            //new added
            //if (ddlreportpc.SelectedValue == "Sp_GetAssetsTransferReportSCrap_All")
            //{
            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim()); //txtFromDate.Text.Trim(); //strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            ToDate.Value = strDate(txtToDate.Text.Trim()); //txtToDate.Text.Trim(); //strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

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
                lblMessage.Text = "";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Text = "Record Not Found";
                btnExportExcel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    private void Get_AssetsStatus_Report()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SP_AssetsDescriptoin13";
            sqlcmd.CommandTimeout = 0;


            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
            SubCentreId.ParameterName = "@Subcentre_id";
            sqlcmd.Parameters.Add(SubCentreId);

            //new added
            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim()); //txtFromDate.Text.Trim(); //strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            ToDate.Value = strDate(txtToDate.Text.Trim()); //txtToDate.Text.Trim(); //strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

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
                lblMessage.Text = "";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Text = "Record Not Found";
                btnExportExcel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void Get_SummaryMIS_ALLZone()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SummaryMIS_ForAssets";
            sqlcmd.CommandTimeout = 0;

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
                lblMessage.Text = "";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblMessage.Text = "Record Not Found";
                btnExportExcel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=Assets Inventory Report.xls";
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView1.RenderControl(htw);
        GridView1.GridLines = GridLines.Both;
        Response.Write(sw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");

    }

    protected void ddlCenterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlCenterList.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentrelist.DataTextField = "SubCentreName";
                ddlsubcentrelist.DataValueField = "SubCentreid";

                ddlsubcentrelist.DataSource = dt1;
                ddlsubcentrelist.DataBind();

                ddlsubcentrelist.Items.Insert(0, new ListItem("--All--", "--All--"));    /////   Imp
                ddlsubcentrelist.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
    }

    private void CountMIS()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand CMD2 = new SqlCommand();
        CMD2.Connection = sqlcon;
        CMD2.CommandType = CommandType.StoredProcedure;
        CMD2.CommandText = "Get_AssetsMISOwnedRented";
        CMD2.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCenterList.SelectedValue.ToString();
        CentreId.ParameterName = "@CentreId";
        CMD2.Parameters.Add(CentreId);

        SqlParameter SubCentreId = new SqlParameter();
        SubCentreId.SqlDbType = SqlDbType.VarChar;
        SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
        SubCentreId.ParameterName = "@Subcentre_id";
        CMD2.Parameters.Add(SubCentreId);

        //new added
        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.DateTime;
        FromDate.Value = strDate(txtFromDate.Text.Trim());
        FromDate.ParameterName = "@FromDate";
        CMD2.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.DateTime;
        ToDate.Value = strDate(txtToDate.Text.Trim());
        ToDate.ParameterName = "@ToDate";
        CMD2.Parameters.Add(ToDate);

        //comp

        SqlDataAdapter Sqlda = new SqlDataAdapter();
        Sqlda.SelectCommand = CMD2;

        DataTable DT = new DataTable();
        Sqlda.Fill(DT);

        Workbook Wb = new HSSFWorkbook();
        Sheet sheet1 = Wb.CreateSheet("Assets Description");

        sheet1.DefaultRowHeight = 300;

        Cell cell;
        CellStyle style3 = Wb.CreateCellStyle();
        //

        //HSSFDataFormat abc = new HSSFDataFormat();
        //DataFormat abc = HSSFDataFormat.GetBuiltinFormat(0);
        //currencyCellStyle.setDataFormat(HSSFDataFormat.getBuiltinFormat("0.00") 


        //style3.DataFormat(HSSFDataFormat.GetBuiltinFormat("0"));

        style3.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        style3.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_BLUE.index;

        Font font1 = Wb.CreateFont();
        font1.Color = NPOI.HSSF.Util.HSSFColor.RED.index;
        font1.FontName = "Arial";
        font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        Font font2 = Wb.CreateFont();
        font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        font2.FontName = "Arial";
        font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        int rowIndx1 = 0;
        Row rw21 = sheet1.CreateRow(rowIndx1);

        CellRangeAddress rng3 = new CellRangeAddress(2, 3, 0, 0);
        sheet1.AddMergedRegion(rng3);

        CellRangeAddress rng4 = new CellRangeAddress(2, 3, 1, 1);
        sheet1.AddMergedRegion(rng4);

        CellRangeAddress rng5 = new CellRangeAddress(2, 3, 2, 2);
        sheet1.AddMergedRegion(rng5);

        CellRangeAddress rng6 = new CellRangeAddress(2, 3, 3, 3);
        sheet1.AddMergedRegion(rng6);

        int rowIndexC1 = 2;
        Row rowT = sheet1.CreateRow(rowIndexC1);

        int rowIndex1 = 3;
        Row row = sheet1.CreateRow(rowIndex1);

        CellRangeAddress rng = new CellRangeAddress(2, 2, 4, 5);
        CellRangeAddress rng1 = new CellRangeAddress(2, 2, 6, 7);
        CellRangeAddress rng2 = new CellRangeAddress(2, 2, 8, 9);

        sheet1.AddMergedRegion(rng);
        sheet1.AddMergedRegion(rng1);
        sheet1.AddMergedRegion(rng2);

        cell = rowT.CreateCell(4);
        cell.SetCellValue("Chair");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rowT.CreateCell(6);
        cell.SetCellValue("PC");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(8);
        cell.SetCellValue("Scanner");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(0);
        cell.SetCellValue("Centre");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(2, 15 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(1);
        cell.SetCellValue("Sub Centre");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(1, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(2);
        cell.SetCellValue("Vertical");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(2, 15 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(3);
        cell.SetCellValue("Unit");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(3, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = row.CreateCell(4);
        cell.SetCellValue("Owned");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(4, 12 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");


        cell = row.CreateCell(5);
        cell.SetCellValue("Rented");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(5, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");


        cell = row.CreateCell(6);
        cell.SetCellValue("Owned");
        sheet1.SetColumnWidth(6, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        cell = row.CreateCell(7);
        cell.SetCellValue("Rented");
        sheet1.SetColumnWidth(7, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        cell = row.CreateCell(8);
        cell.SetCellValue("Owned");
        sheet1.SetColumnWidth(8, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        cell = row.CreateCell(9);
        cell.SetCellValue("Rented");
        sheet1.SetColumnWidth(9, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        rowIndex1++;

        int B = rowIndex1;

        for (int i = 0; i < DT.Rows.Count; i++)
        {
            row = sheet1.CreateRow(rowIndex1);


            row.CreateCell(0).SetCellValue(DT.Rows[i]["Centre"].ToString());
            row.CreateCell(1).SetCellValue(DT.Rows[i]["Sub Centre"].ToString());
            row.CreateCell(2).SetCellValue(DT.Rows[i]["Vertical"].ToString());
            row.CreateCell(3).SetCellValue(DT.Rows[i]["Unit"].ToString());
            row.CreateCell(4).SetCellValue(Convert.ToInt32(DT.Rows[i]["Ch_Owned"].ToString()));
            row.CreateCell(5).SetCellValue(Convert.ToInt32(DT.Rows[i]["Ch_Rented"].ToString()));
            row.CreateCell(6).SetCellValue(Convert.ToInt32(DT.Rows[i]["PC_Owned"].ToString()));
            row.CreateCell(7).SetCellValue(Convert.ToInt32(DT.Rows[i]["PC_Rented"].ToString()));
            row.CreateCell(8).SetCellValue(Convert.ToInt32(DT.Rows[i]["SC_Owned"].ToString()));
            row.CreateCell(9).SetCellValue(Convert.ToInt32(DT.Rows[i]["SC_Rented"].ToString()));
            cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            rowIndex1++;


            for (int j = 1; j < DT.Columns.Count; j++)
            {

                if (j == 6 || j == 7 || j == 8 || j == 9 || j == 10 || j == 11)
                {
                }
                else
                {
                    sheet1.AutoSizeColumn(j);
                }
            }

        }

        int A = rowIndex1;

        Row rowTOT = sheet1.CreateRow(rowIndex1);


        cell = rowTOT.CreateCell(0);
        cell.SetCellValue("Total");
        sheet1.SetColumnWidth(9, 12 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(4);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(E5:E" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rowTOT.CreateCell(5);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(F5:F" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(6);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(G5:G" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(7);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(H5:H" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(8);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(8,8)", B, A);
        cell.CellFormula = string.Format("SUM(I5:I" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(9);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(J5:J" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        CellRangeAddress rngTOT = new CellRangeAddress(A, A, 0, 3);
        sheet1.AddMergedRegion(rngTOT);

        sqlcon.Close();

        using (MemoryStream exportData = new MemoryStream())
        {
            Wb.Write(exportData);

            string saveAsFileName = string.Format("ISOExport-{0:d}.xls", DateTime.Now).Replace("/", "-");
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
            Response.ContentType = "application/vnd.ms-excel";

            Response.BinaryWrite(exportData.GetBuffer());
            Response.End();
        }
    }

    private void CountMISBranch()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand CMD2 = new SqlCommand();
        CMD2.Connection = sqlcon;
        CMD2.CommandType = CommandType.StoredProcedure;
        CMD2.CommandText = "Get_AssetsMISOwnedRented_BranchWise";
        CMD2.CommandTimeout = 0;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCenterList.SelectedValue.ToString();
        CentreId.ParameterName = "@CentreId";
        CMD2.Parameters.Add(CentreId);

        SqlParameter SubCentreId = new SqlParameter();
        SubCentreId.SqlDbType = SqlDbType.VarChar;
        SubCentreId.Value = ddlsubcentrelist.SelectedValue.ToString();
        SubCentreId.ParameterName = "@Subcentre_id";
        CMD2.Parameters.Add(SubCentreId);
        //new added
        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.DateTime;
        FromDate.Value = strDate(txtFromDate.Text.Trim());
        FromDate.ParameterName = "@FromDate";
        CMD2.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.DateTime;
        ToDate.Value = strDate(txtToDate.Text.Trim());
        ToDate.ParameterName = "@ToDate";
        CMD2.Parameters.Add(ToDate);

        //comp

        SqlDataAdapter Sqlda = new SqlDataAdapter();
        Sqlda.SelectCommand = CMD2;

        DataTable DT = new DataTable();
        Sqlda.Fill(DT);

        Workbook Wb = new HSSFWorkbook();
        Sheet sheet1 = Wb.CreateSheet("Assets Description");

        sheet1.DefaultRowHeight = 300;

        Cell cell;
        CellStyle style3 = Wb.CreateCellStyle();
        //

        //HSSFDataFormat abc = new HSSFDataFormat();
        //DataFormat abc = HSSFDataFormat.GetBuiltinFormat(0);
        //currencyCellStyle.setDataFormat(HSSFDataFormat.getBuiltinFormat("0.00") 


        //style3.DataFormat(HSSFDataFormat.GetBuiltinFormat("0"));

        style3.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        style3.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_BLUE.index;

        Font font1 = Wb.CreateFont();
        font1.Color = NPOI.HSSF.Util.HSSFColor.RED.index;
        font1.FontName = "Arial";
        font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        Font font2 = Wb.CreateFont();
        font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        font2.FontName = "Arial";
        font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        int rowIndx1 = 0;
        Row rw21 = sheet1.CreateRow(rowIndx1);

        CellRangeAddress rng3 = new CellRangeAddress(2, 3, 0, 0);
        sheet1.AddMergedRegion(rng3);

        CellRangeAddress rng4 = new CellRangeAddress(2, 3, 1, 1);
        sheet1.AddMergedRegion(rng4);

        //CellRangeAddress rng5 = new CellRangeAddress(2, 3, 2, 2);
        //sheet1.AddMergedRegion(rng5);

        //CellRangeAddress rng6 = new CellRangeAddress(2, 3, 3, 3);
        //sheet1.AddMergedRegion(rng6);

        int rowIndexC1 = 2;
        Row rowT = sheet1.CreateRow(rowIndexC1);

        int rowIndex1 = 3;
        Row row = sheet1.CreateRow(rowIndex1);

        CellRangeAddress rng = new CellRangeAddress(2, 2, 2, 3);
        //CellRangeAddress rng1 = new CellRangeAddress(2, 2, 6, 7);
        //CellRangeAddress rng2 = new CellRangeAddress(2, 2, 8, 9);

        sheet1.AddMergedRegion(rng);
        //sheet1.AddMergedRegion(rng1);
        //sheet1.AddMergedRegion(rng2);

        //cell = rowT.CreateCell(4);
        //cell.SetCellValue("Chair");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rowT.CreateCell(2);
        cell.SetCellValue("PC");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowT.CreateCell(8);
        //cell.SetCellValue("Scanner");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(0);
        cell.SetCellValue("Centre");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(2, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowT.CreateCell(1);
        cell.SetCellValue("Sub Centre");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(1, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowT.CreateCell(2);
        //cell.SetCellValue("Vertical");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //sheet1.SetColumnWidth(2, 15 * 265);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowT.CreateCell(3);
        //cell.SetCellValue("Unit");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //sheet1.SetColumnWidth(3, 20 * 265);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = row.CreateCell(2);
        //cell.SetCellValue("Owned");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //sheet1.SetColumnWidth(4, 12 * 265);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");


        //cell = row.CreateCell(3);
        //cell.SetCellValue("Rented");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //sheet1.SetColumnWidth(5, 20 * 265);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");


        cell = row.CreateCell(2);
        cell.SetCellValue("Owned");
        sheet1.SetColumnWidth(6, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        cell = row.CreateCell(3);
        cell.SetCellValue("Rented");
        sheet1.SetColumnWidth(7, 12 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        //cell = row.CreateCell(6);
        //cell.SetCellValue("Owned");
        //sheet1.SetColumnWidth(8, 12 * 265);
        //cell.CellStyle.WrapText = true;
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        //cell = row.CreateCell(7);
        //cell.SetCellValue("Rented");
        //sheet1.SetColumnWidth(9, 12 * 265);
        //cell.CellStyle.WrapText = true;
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        rowIndex1++;

        int B = rowIndex1;

        for (int i = 0; i < DT.Rows.Count; i++)
        {
            row = sheet1.CreateRow(rowIndex1);


            row.CreateCell(0).SetCellValue(DT.Rows[i]["Centre"].ToString());
            row.CreateCell(1).SetCellValue(DT.Rows[i]["Sub Centre"].ToString());
            //row.CreateCell(2).SetCellValue(DT.Rows[i]["Vertical"].ToString());
            //row.CreateCell(3).SetCellValue(DT.Rows[i]["Unit"].ToString());
            //row.CreateCell(2).SetCellValue(Convert.ToInt32(DT.Rows[i]["Ch_Owned"].ToString()));
            //row.CreateCell(3).SetCellValue(Convert.ToInt32(DT.Rows[i]["Ch_Rented"].ToString()));
            row.CreateCell(2).SetCellValue(Convert.ToInt32(DT.Rows[i]["PC_Owned"].ToString()));
            row.CreateCell(3).SetCellValue(Convert.ToInt32(DT.Rows[i]["PC_Rented"].ToString()));
            //row.CreateCell(6).SetCellValue(Convert.ToInt32(DT.Rows[i]["SC_Owned"].ToString()));
            //row.CreateCell(7).SetCellValue(Convert.ToInt32(DT.Rows[i]["SC_Rented"].ToString()));
            cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            rowIndex1++;


            for (int j = 1; j < DT.Columns.Count; j++)
            {

                if (j == 6 || j == 7 || j == 8 || j == 9 || j == 10 || j == 11)
                {
                }
                else
                {
                    sheet1.AutoSizeColumn(j);
                }
            }

        }

        int A = rowIndex1;

        Row rowTOT = sheet1.CreateRow(rowIndex1);


        cell = rowTOT.CreateCell(0);
        cell.SetCellValue("Total");
        sheet1.SetColumnWidth(9, 12 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowTOT.CreateCell(4);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        //cell.SetCellType(CellType.FORMULA);
        //cell.CellFormula = string.Format("SUM(E5:E" + A.ToString() + ")");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        //cell = rowTOT.CreateCell(4);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        //cell.SetCellType(CellType.FORMULA);
        //cell.CellFormula = string.Format("SUM(F5:F" + A.ToString() + ")");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(2);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(C5:C" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rowTOT.CreateCell(3);
        cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cell.SetCellType(CellType.FORMULA);
        cell.CellFormula = string.Format("SUM(D5:D" + A.ToString() + ")");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowTOT.CreateCell(8);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        //cell.SetCellType(CellType.FORMULA);
        //cell.CellFormula = string.Format("SUM(8,8)", B, A);
        //cell.CellFormula = string.Format("SUM(I5:I" + A.ToString() + ")");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //cell = rowTOT.CreateCell(9);
        //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        //cell.SetCellType(CellType.FORMULA);
        //cell.CellFormula = string.Format("SUM(J5:J" + A.ToString() + ")");
        //cell.CellStyle = Wb.CreateCellStyle();
        //cell.CellStyle.SetFont(font1);
        //cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        //cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        CellRangeAddress rngTOT = new CellRangeAddress(A, A, 0, 1);
        sheet1.AddMergedRegion(rngTOT);

        sqlcon.Close();

        using (MemoryStream exportData = new MemoryStream())
        {
            Wb.Write(exportData);

            string saveAsFileName = string.Format("ISOExport-{0:d}.xls", DateTime.Now).Replace("/", "-");

            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
            Response.BinaryWrite(exportData.GetBuffer());
            Response.End();
        }


    }

    protected void DdlSp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlSp.SelectedItem.Value == "PC")
        {
            ddlreportpc.Visible = true;
        }
        else
        {
            ddlreportpc.Visible = false;
        }
    }
}

