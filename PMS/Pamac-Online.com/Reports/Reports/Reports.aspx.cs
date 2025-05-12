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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;

public partial class Reports_Reports_Reports : System.Web.UI.Page
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
    public string strDate2(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        NewJoinMis();
    }

    private void ISOMIS()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        sqlcon.Open();
        SqlCommand CMD2 = new SqlCommand();
        CMD2.Connection = sqlcon;
        CMD2.CommandType = CommandType.StoredProcedure;
        CMD2.CommandText = "Sp_Consolidated_ComplaintExportToExelNew";//Sp_Consolidated_ComplaintExportToExel
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

        SqlParameter Verification_Type_id = new SqlParameter();
        Verification_Type_id.SqlDbType = SqlDbType.VarChar;
        Verification_Type_id.Value = "52";
        Verification_Type_id.ParameterName = "@Verification_Type_id";
        CMD2.Parameters.Add(Verification_Type_id);

        SqlDataAdapter Sqlda = new SqlDataAdapter();
        Sqlda.SelectCommand = CMD2;

        DataTable DT = new DataTable();
        Sqlda.Fill(DT);

        // Create a new workbook and a sheet named "Complaint Register"

        Workbook Wb = new HSSFWorkbook();

        Sheet sheet1 = Wb.CreateSheet("Complaint");
        Sheet sheet2 = Wb.CreateSheet("Deviation");
        Sheet sheet3 = Wb.CreateSheet("Training");

        sheet1.DefaultRowHeight = 300;
        sheet2.DefaultRowHeight = 300;
        sheet3.DefaultRowHeight = 300;


        Cell cell;
        CellStyle style3 = Wb.CreateCellStyle();
        style3.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        style3.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_BLUE.index;

        Font font1 = Wb.CreateFont();
        font1.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
        font1.FontName = "Arial";
        font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        Font font2 = Wb.CreateFont();
        font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        font2.FontName = "Arial";
        font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        int rowIndx1 = 0;
        Row rw21 = sheet1.CreateRow(rowIndx1);

        cell = rw21.CreateCell(0);
        cell.SetCellValue("Complaint Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font2);

        int rowIndexC1 = 1;
        Row rowC = sheet1.CreateRow(rowIndexC1);

        int rowIndex1 = 2;
        Row row = sheet1.CreateRow(rowIndex1);


        cell = row.CreateCell(0);
        cell.SetCellValue("Serial No");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.BorderBottom = CellBorderType.THIN;
        cell.CellStyle.BorderRight = CellBorderType.THIN;
        cell.CellStyle.BorderLeft = CellBorderType.THIN;
        cell.CellStyle.BorderTop = CellBorderType.THIN;

        cell = row.CreateCell(1);
        cell.SetCellValue("Cluster");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.BorderBottom = CellBorderType.THIN;
        cell.CellStyle.BorderRight = CellBorderType.THIN;
        cell.CellStyle.BorderLeft = CellBorderType.THIN;
        cell.CellStyle.BorderTop = CellBorderType.THIN;

        cell = row.CreateCell(2);
        cell.SetCellValue("Location");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(1, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = row.CreateCell(3);
        cell.SetCellValue("Segment");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(2, 10 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = row.CreateCell(4);
        cell.SetCellValue("Complaint Date");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(3, 15 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = row.CreateCell(5);
        cell.SetCellValue("Client Name");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(4, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = row.CreateCell(6);
        cell.SetCellValue("Nature Of Complaint");
        sheet1.SetColumnWidth(5, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);



        cell = row.CreateCell(7);
        cell.SetCellValue("Root Cause");
        sheet1.SetColumnWidth(6, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(8);
        cell.SetCellValue("Correction");
        sheet1.SetColumnWidth(7, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(9);
        cell.SetCellValue("Corrective Action");
        sheet1.SetColumnWidth(8, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(10);
        cell.SetCellValue("Effectiveness for Corrective Action");
        sheet1.SetColumnWidth(9, 31 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(11);
        cell.SetCellValue("Preventive Action");
        sheet1.SetColumnWidth(10, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(12);
        cell.SetCellValue("Effectiveness for Preventive Action");
        sheet1.SetColumnWidth(11, 31 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = row.CreateCell(13);
        cell.SetCellValue("Closing Date");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(12, 12 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        //Added by vaibhav
        cell = row.CreateCell(14);
        cell.SetCellValue("SubCentre Name");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet1.SetColumnWidth(12, 12 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        rowIndex1++;

        for (int m = 1; m < DT.Columns.Count; m++)
        {
            row.GetCell(m).CellStyle.BorderBottom = CellBorderType.THIN;
            row.GetCell(m).CellStyle.BorderRight = CellBorderType.THIN;
            row.GetCell(m).CellStyle.BorderLeft = CellBorderType.THIN;
            row.GetCell(m).CellStyle.BorderTop = CellBorderType.THIN;
            //sheet1.AutoSizeColumn(m);
        }

        for (int i = 0; i < DT.Rows.Count; i++)
        {
            row = sheet1.CreateRow(rowIndex1);
            row.CreateCell(0).SetCellValue(DT.Rows[i]["Serial No"].ToString());
            row.CreateCell(1).SetCellValue(DT.Rows[i]["Cluster"].ToString());
            row.CreateCell(2).SetCellValue(DT.Rows[i]["Location"].ToString());
            row.CreateCell(3).SetCellValue(DT.Rows[i]["Segment"].ToString());
            row.CreateCell(4).SetCellValue(DT.Rows[i]["Date Of Complaint"].ToString());
            row.CreateCell(5).SetCellValue(DT.Rows[i]["Client Name"].ToString());
            row.CreateCell(6).SetCellValue(DT.Rows[i]["Nature Of Complaint"].ToString());
            row.CreateCell(7).SetCellValue(DT.Rows[i]["Root Cause"].ToString());
            row.CreateCell(8).SetCellValue(DT.Rows[i]["Correction"].ToString());
            row.CreateCell(9).SetCellValue(DT.Rows[i]["Corrective Action"].ToString());
            row.CreateCell(10).SetCellValue(DT.Rows[i]["Effectiveness for Corrective Action"].ToString());
            row.CreateCell(11).SetCellValue(DT.Rows[i]["Preventive Action"].ToString());
            row.CreateCell(12).SetCellValue(DT.Rows[i]["Effectiveness for Preventive Action"].ToString());
            row.CreateCell(13).SetCellValue(DT.Rows[i]["Closing Date"].ToString());
            row.CreateCell(14).SetCellValue(DT.Rows[i]["SubCentre Name"].ToString());
            rowIndex1++;

            for (int j = 1; j < DT.Columns.Count; j++)
            {

                if (j == 6 || j == 7 || j == 8 || j == 9 || j == 10 || j == 11)
                {
                }
                else
                {
                    //sheet1.AutoSizeColumn(j);
                }
            }
        }

        //++++++++++++++++++++++++++Deviation+++++++++++++++++++++++++++++++++++++++++

        SqlCommand CMD3 = new SqlCommand();
        CMD3.Connection = sqlcon;
        CMD3.CommandType = CommandType.StoredProcedure;
        CMD3.CommandText = "Sp_Consolidated_Deviation1ExportToExelNew";
        CMD3.CommandTimeout = 0;

        SqlParameter FromDate3 = new SqlParameter();  /// IMP
        FromDate3.SqlDbType = SqlDbType.DateTime;
        FromDate3.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
        FromDate3.ParameterName = "@FromDate";
        CMD3.Parameters.Add(FromDate3);

        SqlParameter Todate3 = new SqlParameter();  /// IMP
        Todate3.SqlDbType = SqlDbType.DateTime;
        Todate3.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
        Todate3.ParameterName = "@Todate";
        CMD3.Parameters.Add(Todate3);

        SqlParameter Verification_Type_id3 = new SqlParameter();
        Verification_Type_id3.SqlDbType = SqlDbType.VarChar;
        Verification_Type_id3.Value = "53";
        Verification_Type_id3.ParameterName = "@Verification_Type_id";
        CMD3.Parameters.Add(Verification_Type_id3);

        SqlDataAdapter Sqlda3 = new SqlDataAdapter();
        Sqlda3.SelectCommand = CMD3;

        DataTable dt = new DataTable();
        Sqlda3.Fill(dt);

        int rowIndex2 = 0;
        Row rww = sheet2.CreateRow(rowIndex2);

        cell = rww.CreateCell(0);
        cell.SetCellValue("Deviation Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font2);

        int rowIndxD2 = 1;
        Row rrr21 = sheet2.CreateRow(1);

        int rowIndx2 = 2;
        Row rw2 = sheet2.CreateRow(2);

        cell = rw2.CreateCell(0);
        cell.SetCellValue("Serial No");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.BorderBottom = CellBorderType.THIN;
        cell.CellStyle.BorderRight = CellBorderType.THIN;
        cell.CellStyle.BorderLeft = CellBorderType.THIN;
        cell.CellStyle.BorderTop = CellBorderType.THIN;

        cell = rw2.CreateCell(1);
        cell.SetCellValue("Cluster");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(1, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rw2.CreateCell(2);
        cell.SetCellValue("Location");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(1, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(3);
        cell.SetCellValue("Segment");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(2, 15 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(4);
        cell.SetCellValue("Deviation Date");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(3, 14 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(5);
        cell.SetCellValue("Client Name");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(4, 20 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(6);
        cell.SetCellValue("Nature Of Deviation");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(5, 25 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(7);
        cell.SetCellValue("Root Cause");
        sheet2.SetColumnWidth(6, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(8);
        cell.SetCellValue("Correction");
        sheet2.SetColumnWidth(7, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(9);
        cell.SetCellValue("Corrective Action");
        sheet2.SetColumnWidth(8, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = rw2.CreateCell(10);
        cell.SetCellValue("Effectiveness for Corrective Action");
        sheet2.SetColumnWidth(9, 31 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);

        cell = rw2.CreateCell(11);
        cell.SetCellValue("Preventive Action");
        sheet2.SetColumnWidth(10, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = rw2.CreateCell(12);
        cell.SetCellValue("Effectiveness for Preventive Action");
        sheet2.SetColumnWidth(11, 31 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);


        cell = rw2.CreateCell(13);
        cell.SetCellValue("Closing Date");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(12, 12 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2.CreateCell(14);
        cell.SetCellValue("Subcentre Name");
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        sheet2.SetColumnWidth(12, 12 * 265);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        rowIndx2++;

        for (int i = 1; i < dt.Columns.Count; i++)
        {

            rw2.GetCell(i).CellStyle.BorderBottom = CellBorderType.THIN;
            rw2.GetCell(i).CellStyle.BorderRight = CellBorderType.THIN;
            rw2.GetCell(i).CellStyle.BorderLeft = CellBorderType.THIN;
            rw2.GetCell(i).CellStyle.BorderTop = CellBorderType.THIN;
        }

        for (int j = 0; j < dt.Rows.Count; j++)
        {
            row = sheet2.CreateRow(rowIndx2);
            row.CreateCell(0).SetCellValue(dt.Rows[j]["Serial No"].ToString());
            row.CreateCell(1).SetCellValue(dt.Rows[j]["Cluster"].ToString());
            row.CreateCell(2).SetCellValue(dt.Rows[j]["Location"].ToString());
            row.CreateCell(3).SetCellValue(dt.Rows[j]["Segment"].ToString());
            row.CreateCell(4).SetCellValue(dt.Rows[j]["Date Of Deviation"].ToString());
            row.CreateCell(5).SetCellValue(dt.Rows[j]["Client Name"].ToString());
            row.CreateCell(6).SetCellValue(dt.Rows[j]["Nature Of Deviation"].ToString());
            row.CreateCell(7).SetCellValue(dt.Rows[j]["Root Cause"].ToString());
            row.CreateCell(8).SetCellValue(dt.Rows[j]["Correction"].ToString());
            row.CreateCell(9).SetCellValue(dt.Rows[j]["Corrective Action"].ToString());
            row.CreateCell(10).SetCellValue(dt.Rows[j]["Effectiveness for Corrective Action"].ToString());
            row.CreateCell(11).SetCellValue(dt.Rows[j]["Preventive Action"].ToString());
            row.CreateCell(12).SetCellValue(dt.Rows[j]["Effectiveness for Preventive Action"].ToString());
            row.CreateCell(13).SetCellValue(dt.Rows[j]["Closing Date"].ToString());
            row.CreateCell(14).SetCellValue(dt.Rows[j]["Subcentre Name"].ToString());
            rowIndx2++;

            for (int p = 1; p < dt.Columns.Count; p++)
            {

                if (p == 6 || p == 7 || p == 8 || p == 9 || p == 10 || p == 11)
                {
                }
                else
                {
                    //sheet2.AutoSizeColumn(p);
                }


            }

        }

        //++++++++++++++++++++++++++++++Training++++++++++++++++++++++++++++++++++++++++++++++

        SqlCommand CMD4 = new SqlCommand();
        CMD4.Connection = sqlcon;
        CMD4.CommandType = CommandType.StoredProcedure;
        CMD4.CommandText = "Sp_Consolidated_TrainingExportToExel";
        CMD4.CommandTimeout = 0;

        SqlParameter FromDate4 = new SqlParameter();  /// IMP
        FromDate4.SqlDbType = SqlDbType.DateTime;
        FromDate4.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
        FromDate4.ParameterName = "@FromDate";
        CMD4.Parameters.Add(FromDate4);

        SqlParameter Todate4 = new SqlParameter();  /// IMP
        Todate4.SqlDbType = SqlDbType.DateTime;
        Todate4.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
        Todate4.ParameterName = "@Todate";
        CMD4.Parameters.Add(Todate4);

        SqlParameter Verification_Type_id4 = new SqlParameter();
        Verification_Type_id4.SqlDbType = SqlDbType.VarChar;
        Verification_Type_id4.Value = "54";
        Verification_Type_id4.ParameterName = "@Verification_Type_id";
        CMD4.Parameters.Add(Verification_Type_id4);

        SqlDataAdapter Sqlda4 = new SqlDataAdapter();
        Sqlda4.SelectCommand = CMD4;

        DataTable dt4 = new DataTable();
        Sqlda4.Fill(dt4);

        int rowIndx3 = 0;
        Row rw23 = sheet3.CreateRow(rowIndx3);

        cell = rw23.CreateCell(0);
        cell.SetCellValue("Training Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font2);

        int rowIndexT3 = 1;
        Row rw2TW = sheet3.CreateRow(rowIndexT3);

        int rowIndex3 = 2;
        Row rw2W = sheet3.CreateRow(rowIndex3);

        cell = rw2W.CreateCell(0);
        cell.SetCellValue("Serial No");
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.BorderBottom = CellBorderType.THIN;
        cell.CellStyle.BorderRight = CellBorderType.THIN;
        cell.CellStyle.BorderLeft = CellBorderType.THIN;
        cell.CellStyle.BorderTop = CellBorderType.THIN;

        cell = rw2W.CreateCell(1);
        cell.SetCellValue("Cluster");
        sheet3.SetColumnWidth(1, 15 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rw2W.CreateCell(2);
        cell.SetCellValue("Location");
        sheet3.SetColumnWidth(1, 15 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2W.CreateCell(3);
        cell.SetCellValue("Unit");
        sheet3.SetColumnWidth(2, 15 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2W.CreateCell(4);
        cell.SetCellValue("Training Date");
        sheet3.SetColumnWidth(3, 13 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2W.CreateCell(5);
        cell.SetCellValue("Topic");
        sheet3.SetColumnWidth(4, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;



        cell = rw2W.CreateCell(6);
        cell.SetCellValue("Trainer");
        sheet3.SetColumnWidth(5, 25 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rw2W.CreateCell(7);
        cell.SetCellValue("Name of Trainees ");
        sheet3.SetColumnWidth(6, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;



        cell = rw2W.CreateCell(8);
        cell.SetCellValue("Venue");
        sheet3.SetColumnWidth(7, 15 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rw2W.CreateCell(9);
        cell.SetCellValue("Duration_hrs");
        sheet3.SetColumnWidth(8, 12 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2W.CreateCell(10);
        cell.SetCellValue("Evaluation");
        sheet3.SetColumnWidth(9, 25 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


        cell = rw2W.CreateCell(11);
        cell.SetCellValue("Effectiveness Implementation");
        sheet3.SetColumnWidth(10, 28 * 265);
        cell.CellStyle.WrapText = true;
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

        cell = rw2W.CreateCell(12);
        cell.SetCellValue("Training Mandays");
        sheet3.SetColumnWidth(11, 20 * 265);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font1);
        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;



        rowIndex3++;

        for (int i = 1; i < dt4.Columns.Count; i++)
        {
            rw2W.GetCell(i).CellStyle.BorderBottom = CellBorderType.THIN;
            rw2W.GetCell(i).CellStyle.BorderRight = CellBorderType.THIN;
            rw2W.GetCell(i).CellStyle.BorderLeft = CellBorderType.THIN;
            rw2W.GetCell(i).CellStyle.BorderTop = CellBorderType.THIN;
        }

        for (int k = 0; k < dt4.Rows.Count; k++)
        {
            row = sheet3.CreateRow(rowIndex3);

            row.CreateCell(0).SetCellValue(dt4.Rows[k]["Serial No"].ToString());
            row.CreateCell(1).SetCellValue(dt4.Rows[k]["Cluster"].ToString());
            row.CreateCell(2).SetCellValue(dt4.Rows[k]["Location"].ToString());
            row.CreateCell(3).SetCellValue(dt4.Rows[k]["Unit"].ToString());
            row.CreateCell(4).SetCellValue(dt4.Rows[k]["Training Date"].ToString());
            row.CreateCell(5).SetCellValue(dt4.Rows[k]["Topic"].ToString());
            row.CreateCell(6).SetCellValue(dt4.Rows[k]["Trainer"].ToString());
            row.CreateCell(7).SetCellValue(dt4.Rows[k]["Name of Trainees "].ToString());
            row.CreateCell(8).SetCellValue(dt4.Rows[k]["Venue"].ToString());
            row.CreateCell(9).SetCellValue(dt4.Rows[k]["Duration_hrs"].ToString());
            row.CreateCell(10).SetCellValue(dt4.Rows[k]["Evaluation"].ToString());
            row.CreateCell(11).SetCellValue(dt4.Rows[k]["Effectiveness Implementation"].ToString());
            row.CreateCell(12).SetCellValue(dt4.Rows[k]["Training Mandays"].ToString());
            rowIndex3++;

            for (int r = 1; r < dt4.Columns.Count; r++)
            {

                if (r == 6)
                {
                }
                else
                {
                    //sheet3.AutoSizeColumn(1);

                }
            }

        }

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

            if (StoreProc == "ISOMIS")
            {
                ISOMIS();

            }
            else
            {

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = StoreProc;
                sqlcmd.CommandTimeout = 0;


                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcmd;


                if (ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCClient_WiseDetails_PFRC_backup" || ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCClient_WiseDetails_backup" || ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCFE_WiseDetails_Backup" || ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCFE_WiseDetails_PFRC_backup" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_ClientWise_Amount_26May2014_KanchanPFRCFinal1" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_clientWise_Amount_26May2014_KanchanPCPVFinal1" || ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCFE_WiseDetails_PFRC_backup" || ddlMisType.SelectedItem.Value.Trim() == "Sp_RCPCFE_WiseDetails" || ddlMisType.SelectedItem.Value.Trim() == "sp_idoc_rc_pc_PCPV" || ddlMisType.SelectedItem.Value.Trim() == "sp_idoc_rc_pc_PFRC" || ddlMisType.SelectedItem.Value.Trim() == "casewise_details_rc_pc_PCPV" || ddlMisType.SelectedItem.Value.Trim() == "casewise_details_rc_pc_pfrc" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_FEWise_Amount_26May2014_KanchanPFRCFinal1" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_FEWise_Amount_26May2014_KanchanPCPVFinal1" || ddlMisType.SelectedItem.Value.Trim() == "SP_GET_ITRCountMIS_FEWise_Amount_16Sep_PCPV" || ddlMisType.SelectedItem.Value.Trim() == "SP_GET_ITRCountMIS_FEWise_Amount_16Sep" || ddlMisType.SelectedItem.Value.Trim() == "SP_GET_ITRCountMIS_FEWise_Amount" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_FEWise_Amount_26May2014" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS" || ddlMisType.SelectedItem.Value.Trim() == "SP_ITRCountMIS_FEWise" || ddlMisType.SelectedItem.Value.Trim() == "ITR_case_wise_panindia")
                {
                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);

                }
                else if (ddlMisType.SelectedItem.Value.Trim() == "Sp_FinalConsolidatedTrackerALLURL")
                {
                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);

                    SqlParameter CentName = new SqlParameter();
                    CentName.SqlDbType = SqlDbType.VarChar;
                    CentName.Value = ddlCenter.SelectedValue.ToString();
                    CentName.ParameterName = "@CentreId";
                    sqlcmd.Parameters.Add(CentName);

                }
                else if (ddlMisType.SelectedItem.Value.Trim() == "sp_idoc_rc_pc_PCPV11" || ddlMisType.SelectedItem.Value.Trim() == "sp_idoc_rc_pc_PFRC11")
                {
                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);

                }
                else if (ddlMisType.SelectedItem.Value.Trim() == "Sp_operationalVisiExportToExel_AllPMS" || ddlMisType.SelectedItem.Value.Trim() == "Sp_operationalVisiExportToExel_AllPMS")
                {

                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);

                }
                else if (ddlMisType.SelectedItem.Value.Trim() == "Sp_GetAssetsTransferReportSCrap_PnIndia")
                {

                    SqlParameter CentName = new SqlParameter();
                    CentName.SqlDbType = SqlDbType.VarChar;
                    CentName.Value = ddlCenter.SelectedValue.ToString();
                    CentName.ParameterName = "@CentreId";
                    sqlcmd.Parameters.Add(CentName);

                    SqlParameter SCentName = new SqlParameter();
                    SCentName.SqlDbType = SqlDbType.VarChar;
                    SCentName.Value = ddlSubcenter.SelectedValue.ToString();
                    SCentName.ParameterName = "@Subcentre_id";
                    sqlcmd.Parameters.Add(SCentName);

                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);
                }
                else if (ddlMisType.SelectedItem.Value.Trim() == "SP_AssetsDescriptoinAllURL")
                {
                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate2(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate2(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);
                }
                else
                {


                    SqlParameter FrDate = new SqlParameter();
                    FrDate.SqlDbType = SqlDbType.VarChar;
                    FrDate.Value = strDate(txtFromDate.Text.Trim());
                    FrDate.ParameterName = "@FromDate";
                    sqlcmd.Parameters.Add(FrDate);

                    SqlParameter TDate = new SqlParameter();
                    TDate.SqlDbType = SqlDbType.VarChar;
                    TDate.Value = strDate(txtToDate.Text.Trim());
                    TDate.ParameterName = "@ToDate";
                    sqlcmd.Parameters.Add(TDate);


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

                }

                if (ddlMisType.SelectedItem.Value.Trim() == "Sp_FinalConsolidatedTrackerALLURL")
                {
                    DataSet Ds = new DataSet();
                    sqlda.Fill(Ds);

                    GV.DataSource = Ds.Tables[4];
                    GV.DataBind();
                }
                else
                {

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

        String attachment = "attachment; filename=" + ddlMisType.SelectedItem.Text + ".xls";
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
