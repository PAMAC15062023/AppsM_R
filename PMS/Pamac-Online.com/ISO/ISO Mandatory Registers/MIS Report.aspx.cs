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

public partial class ISO_ISO_Mandatory_Registers_MIS_Report : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
    }

    protected void BTNFIND_Click(object sender, EventArgs e)
    {
            sqlcon.Open();
            SqlCommand CMD2 = new SqlCommand();
            CMD2.Connection = sqlcon;
            CMD2.CommandType = CommandType.StoredProcedure;
            CMD2.CommandText = "ComplaintExportToExel";
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

            //Workbook Wb = new HSSFWorkbook(); //comment by Rutuja on 02/04/2025
            HSSFWorkbook Wb = new HSSFWorkbook(); //changes by Rutuja on 02/04/2025

            Sheet sheet1 = Wb.CreateSheet("Complaint");
            Sheet sheet2 = Wb.CreateSheet("Deviation");
            Sheet sheet3 = Wb.CreateSheet("Training");

            sheet1.DefaultRowHeight = 300;
            sheet2.DefaultRowHeight = 300;
            sheet3.DefaultRowHeight = 300;

        //add on 02/04/2025 by Rutuja <<
        // Get the path to the logo image (make sure the logo is in the correct path)
        var logoPath = HttpContext.Current.Server.MapPath("~/logo1.png");

        // Read the image into a byte array
        byte[] imageBytes = File.ReadAllBytes(logoPath);

        // Add the image to the workbook's image collection
        int pictureIndex = Wb.AddPicture(imageBytes, PictureType.PNG);

        // Create a drawing patriarch (used for drawing objects like images)
        var drawing1 = sheet1.CreateDrawingPatriarch();
        var drawing2 = sheet2.CreateDrawingPatriarch();
        var drawing3 = sheet3.CreateDrawingPatriarch();

       
        // Create an anchor to specify the image position
        // Here we will place the logo in the top-left corner (row 0, column 0)
        var anchor1 = new HSSFClientAnchor(0, 0, 0, 0, 0, 0, 2, 2); // (row 0, column 0, size 2 columns x 5 rows)
        var anchor2 = new HSSFClientAnchor(0, 0, 0, 0, 0, 0, 2, 2); //(0, 0, 0, 0, 0, 0, 2, 2)
        var anchor3 = new HSSFClientAnchor(0, 0, 0, 0, 0, 0, 2, 2);


        // Attach the image to the worksheets
        drawing1.CreatePicture(anchor1, pictureIndex);
        drawing2.CreatePicture(anchor2, pictureIndex);
        drawing3.CreatePicture(anchor3, pictureIndex);

        // Font for Title
        Font font1 = Wb.CreateFont();
        font1.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
        font1.FontName = "Arial";
        font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        Font font2 = Wb.CreateFont();
        font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        font2.FontName = "Arial";
        font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        // Create the title row beside the logo (starting from column 5)
        int rowIndx1 = 0; // Start on the first row (Row 0)
        Row rw21 = sheet1.CreateRow(rowIndx1);

        rw21.Height = 500;  //add on 03/04/2025

        Cell cell;
        
        // Cell for title text, starting from column 5 (which avoids overlap with the logo)
        cell = rw21.CreateCell(3); //3 Column 4 (E) to place the title beside the logo
        cell.SetCellValue("PAMAC Complaint Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
        cell.CellStyle = Wb.CreateCellStyle();
        cell.CellStyle.SetFont(font2);

        // Optional: Merge cells for the title if you want it to span multiple columns
        sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 3, 12)); // Merging cells D to K in row 1 (adjust columns as needed)

        // Create the data row (below the title)
        int rowIndexC1 = 1; // Start the content from row 1 (below the title)
        Row rowC = sheet1.CreateRow(rowIndexC1);

        // Adjust row height for row 1 (ensure it doesn't overlap with title/logo)
        sheet1.GetRow(1).Height = 3000; //800 // Row height for the data //changes on 03/04/2025
        sheet1.SetColumnWidth(0, 1000); //add on 03/04/2025
        //sheet1.SetColumnWidth(1, 500);  //add on 03/04/2025

        

        // Create some data for demonstration (starting from row 2)
        int rowIndex1 = 2; // Content starts from row 2
        Row row = sheet1.CreateRow(rowIndex1);
        //add on 02/04/2025 by Rutuja >>

        //comment start on 02/04/2025 by Rutuja >>
        //Cell cell;
        //    CellStyle style3 = Wb.CreateCellStyle();
        //    style3.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        //    style3.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_BLUE.index;

        //    Font font1 = Wb.CreateFont();
        //    font1.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
        //    font1.FontName = "Arial";
        //    font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        //    Font font2 = Wb.CreateFont();
        //    font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
        //    font2.FontName = "Arial";
        //    font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

        //int rowIndx1 = 5;//0;
        //    Row rw21 = sheet1.CreateRow(rowIndx1);

        //    cell = rw21.CreateCell(0);
        //    cell.SetCellValue("Complaint Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
        //    cell.CellStyle = Wb.CreateCellStyle();    
        //    cell.CellStyle.SetFont(font2);

        //    int rowIndexC1 = 1;
        //    Row rowC = sheet1.CreateRow(rowIndexC1);

        //    int rowIndex1 = 2;
        //    Row row = sheet1.CreateRow(rowIndex1);
        //<<comment end on 02/04/2025 by Rutuja 

            cell = row.CreateCell(0);
            cell.SetCellValue("Serial No");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.BorderBottom = CellBorderType.THIN;
            cell.CellStyle.BorderRight = CellBorderType.THIN;
            cell.CellStyle.BorderLeft = CellBorderType.THIN;
            cell.CellStyle.BorderTop = CellBorderType.THIN;

            cell = row.CreateCell(1);
            cell.SetCellValue("Location");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet1.SetColumnWidth(1, 20 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
         
            cell=row.CreateCell(2);
            cell.SetCellValue("Segment");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet1.SetColumnWidth(2, 10 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
       
            cell=row.CreateCell(3);
            cell.SetCellValue("Complaint Date");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet1.SetColumnWidth(3, 15 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
         
            cell=row.CreateCell(4);
            cell.SetCellValue("Client Name");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet1.SetColumnWidth(4, 20 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
    
            cell=row.CreateCell(5);
            cell.SetCellValue("Nature Of Complaint");
            sheet1.SetColumnWidth(5, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            
       
      
            cell=row.CreateCell(6);
            cell.SetCellValue("Root Cause");
            sheet1.SetColumnWidth(6, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
      

            cell = row.CreateCell(7);
            cell.SetCellValue("Correction");
            sheet1.SetColumnWidth(7, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
  
  
            cell=row.CreateCell(8);
            cell.SetCellValue("Corrective Action");
            sheet1.SetColumnWidth(8, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);


            cell = row.CreateCell(9);
            cell.SetCellValue("Effectiveness for Corrective Action");
            sheet1.SetColumnWidth(9, 31 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);

            
            cell=row.CreateCell(10);
            cell.SetCellValue("Preventive Action");
            sheet1.SetColumnWidth(10, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
      
            
            cell=row.CreateCell(11);
            cell.SetCellValue("Effectiveness for Preventive Action");
            sheet1.SetColumnWidth(11, 31 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
        
           
            cell=row.CreateCell(12);
            cell.SetCellValue("Closing Date");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet1.SetColumnWidth(12, 12 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
           
            rowIndex1++;
        
            for (int m= 1; m < DT.Columns.Count; m++)
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
                row.CreateCell(1).SetCellValue(DT.Rows[i]["Location"].ToString());
                row.CreateCell(2).SetCellValue(DT.Rows[i]["Segment"].ToString());
                row.CreateCell(3).SetCellValue(DT.Rows[i]["Date Of Complaint"].ToString());
                row.CreateCell(4).SetCellValue(DT.Rows[i]["Client Name"].ToString());
                row.CreateCell(5).SetCellValue(DT.Rows[i]["Nature Of Complaint"].ToString());
                row.CreateCell(6).SetCellValue(DT.Rows[i]["Root Cause"].ToString());
                row.CreateCell(7).SetCellValue(DT.Rows[i]["Correction"].ToString());
                row.CreateCell(8).SetCellValue(DT.Rows[i]["Corrective Action"].ToString());
                row.CreateCell(9).SetCellValue(DT.Rows[i]["Effectiveness for Corrective Action"].ToString());
                row.CreateCell(10).SetCellValue(DT.Rows[i]["Preventive Action"].ToString());
                row.CreateCell(11).SetCellValue(DT.Rows[i]["Effectiveness for Preventive Action"].ToString());
                row.CreateCell(12).SetCellValue(DT.Rows[i]["Closing Date"].ToString());
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
            CMD3.CommandText = "Deviation1ExportToExel";
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

            rww.Height = 500;  //add on 03/04/2025

            cell = rww.CreateCell(3); //cell = rww.CreateCell(0); //change on 02/04/2025 by Rutuja
            cell.SetCellValue("PAMAC Deviation Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font2);

        // Optional: Merge cells for the title if you want it to span multiple columns //add on 03/04/2025
        sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 3, 12)); // Merging cells D to K in row 1 (adjust columns as needed)

        int rowIndxD2 = 1;
        Row rrr21 = sheet2.CreateRow(rowIndxD2);//Row rrr21 = sheet2.CreateRow(1);

        // Adjust row height for row 1 (ensure it doesn't overlap with title/logo) //add on 02/04/2025
        sheet2.GetRow(1).Height = 3000; //800; // Row height for the data
        sheet2.SetColumnWidth(0, 1000); //add on 03/04/2025
        //sheet2.SetColumnWidth(1, 500);  //add on 03/04/2025

        int rowIndx2 = 2;
        Row rw2 = sheet2.CreateRow(rowIndx2);//Row rw2 = sheet2.CreateRow(2);

            cell = rw2.CreateCell(0);
            cell.SetCellValue("Serial No");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            //cell.CellStyle.WrapText = true;
            cell.CellStyle.BorderBottom = CellBorderType.THIN;
            cell.CellStyle.BorderRight = CellBorderType.THIN;
            cell.CellStyle.BorderLeft = CellBorderType.THIN;
            cell.CellStyle.BorderTop = CellBorderType.THIN;
       

            cell = rw2.CreateCell(1);
            cell.SetCellValue("Location");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet2.SetColumnWidth(1, 20 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        

            cell = rw2.CreateCell(2);
            cell.SetCellValue("Segment");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet2.SetColumnWidth(2, 15 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
     

            cell = rw2.CreateCell(3);
            cell.SetCellValue("Deviation Date");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet2.SetColumnWidth(3, 14 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
 

            cell = rw2.CreateCell(4);
            cell.SetCellValue("Client Name");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet2.SetColumnWidth(4, 20 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
     

            cell = rw2.CreateCell(5);
            cell.SetCellValue("Nature Of Deviation");
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            sheet2.SetColumnWidth(5, 25 * 265);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
        

            cell = rw2.CreateCell(6);
            cell.SetCellValue("Root Cause");
            sheet2.SetColumnWidth(6, 25 * 265);
            cell.CellStyle.WrapText = true;         
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
 

            cell = rw2.CreateCell(7);
            cell.SetCellValue("Correction");
            sheet2.SetColumnWidth(7, 25 * 265);
            cell.CellStyle.WrapText = true;         
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
     

            cell = rw2.CreateCell(8);
            cell.SetCellValue("Corrective Action");
            sheet2.SetColumnWidth(8, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
 

            cell = rw2.CreateCell(9);
            cell.SetCellValue("Effectiveness for Corrective Action");
            sheet2.SetColumnWidth(9, 31 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
           
            cell = rw2.CreateCell(10);
            cell.SetCellValue("Preventive Action");
            sheet2.SetColumnWidth(10, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
           

            cell = rw2.CreateCell(11);
            cell.SetCellValue("Effectiveness for Preventive Action");
            sheet2.SetColumnWidth(11, 31 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
           

            cell = rw2.CreateCell(12);
            cell.SetCellValue("Closing Date");
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
                row.CreateCell(1).SetCellValue(dt.Rows[j]["Location"].ToString());
                row.CreateCell(2).SetCellValue(dt.Rows[j]["Segment"].ToString());
                row.CreateCell(3).SetCellValue(dt.Rows[j]["Date Of Deviation"].ToString());
                row.CreateCell(4).SetCellValue(dt.Rows[j]["Client Name"].ToString());
                row.CreateCell(5).SetCellValue(dt.Rows[j]["Nature Of Deviation"].ToString());
                row.CreateCell(6).SetCellValue(dt.Rows[j]["Root Cause"].ToString());
                row.CreateCell(7).SetCellValue(dt.Rows[j]["Correction"].ToString());
                row.CreateCell(8).SetCellValue(dt.Rows[j]["Corrective Action"].ToString());
                row.CreateCell(9).SetCellValue(dt.Rows[j]["Effectiveness for Corrective Action"].ToString());
                row.CreateCell(10).SetCellValue(dt.Rows[j]["Preventive Action"].ToString());
                row.CreateCell(11).SetCellValue(dt.Rows[j]["Effectiveness for Preventive Action"].ToString());
                row.CreateCell(12).SetCellValue(dt.Rows[j]["Closing Date"].ToString());
                rowIndx2++;

                for (int p =1; p < dt.Columns.Count; p++)
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
            CMD4.CommandText = "TrainingExportToExel";
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

            rw23.Height = 500;  //add on 03/04/2025

            cell = rw23.CreateCell(3);  //cell = rw23.CreateCell(0); //changes by Rutuja on 02/04/2025
            cell.SetCellValue("PAMAC Training Register Report From: " + txtFromDate.Text + " To " + txtToDate.Text);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font2);

        // Optional: Merge cells for the title if you want it to span multiple columns //add on 03/04/2025
        sheet3.AddMergedRegion(new CellRangeAddress(0, 0, 3, 12)); // Merging cells D to K in row 1 (adjust columns as needed)

        int rowIndexT3 = 1;
            Row rw2TW = sheet3.CreateRow(rowIndexT3);

        // Adjust row height for row 1 (ensure it doesn't overlap with title/logo) //add on 02/04/2025 by Rutuja
        sheet3.GetRow(1).Height = 3000; //800; // Row height for the data
        sheet3.SetColumnWidth(0, 1000); //add on 03/04/2025
        //sheet3.SetColumnWidth(1, 500);  //add on 03/04/2025

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
            cell.SetCellValue("Location");
            sheet3.SetColumnWidth(1, 20 * 265);//sheet3.SetColumnWidth(1, 15 * 265); //change on 03/04/2025
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


            cell = rw2W.CreateCell(2);
            cell.SetCellValue("Unit");
            sheet3.SetColumnWidth(2, 15 * 265);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


            cell = rw2W.CreateCell(3);
            cell.SetCellValue("Training Date");
            sheet3.SetColumnWidth(3, 13 * 265);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
            

            cell = rw2W.CreateCell(4);
            cell.SetCellValue("Topic");
            sheet3.SetColumnWidth(4, 25* 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
               
          

            cell = rw2W.CreateCell(5);
            cell.SetCellValue("Trainer");
            sheet3.SetColumnWidth(5, 25 * 265);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;

            cell = rw2W.CreateCell(6);
            cell.SetCellValue("Name of Trainees ");
            sheet3.SetColumnWidth(6, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 
           


            cell = rw2W.CreateCell(7);
            cell.SetCellValue("Venue");
            sheet3.SetColumnWidth(7, 15 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 

            cell = rw2W.CreateCell(8);
            cell.SetCellValue("Duration_hrs");
            sheet3.SetColumnWidth(8, 12 * 265);
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


            cell = rw2W.CreateCell(9);
            cell.SetCellValue("Evaluation");
            sheet3.SetColumnWidth(9, 25 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
              

            cell = rw2W.CreateCell(10);
            cell.SetCellValue("Effectiveness Implementation");
            sheet3.SetColumnWidth(10, 28 * 265);
            cell.CellStyle.WrapText = true;
            cell.CellStyle = Wb.CreateCellStyle();
            cell.CellStyle.SetFont(font1);
            cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
            cell.CellStyle.Alignment = HorizontalAlignment.CENTER; 

            cell = rw2W.CreateCell(11);
            cell.SetCellValue("Training Mandays");
            sheet3.SetColumnWidth(11, 20* 265);
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
                row.CreateCell(1).SetCellValue(dt4.Rows[k]["Location"].ToString());
                row.CreateCell(2).SetCellValue(dt4.Rows[k]["Unit"].ToString());
                row.CreateCell(3).SetCellValue(dt4.Rows[k]["Training Date"].ToString());
                row.CreateCell(4).SetCellValue(dt4.Rows[k]["Topic"].ToString());
                row.CreateCell(5).SetCellValue(dt4.Rows[k]["Trainer"].ToString());
                row.CreateCell(6).SetCellValue(dt4.Rows[k]["Name of Trainees "].ToString());
                row.CreateCell(7).SetCellValue(dt4.Rows[k]["Venue"].ToString());
                row.CreateCell(8).SetCellValue(dt4.Rows[k]["Duration_hrs"].ToString());
                row.CreateCell(9).SetCellValue(dt4.Rows[k]["Evaluation"].ToString());
                row.CreateCell(10).SetCellValue(dt4.Rows[k]["Effectiveness Implementation"].ToString());
                row.CreateCell(11).SetCellValue(dt4.Rows[k]["Training Mandays"].ToString());
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

    //public bool FormatLastCell(bool Bold, int Width, int CellSpan, short FGColour, short BGColour, bool Border)
    //{
    //    HSSFCellStyle xlStyle = xlCell.CellStyle;
    //    if (xlStyle == null)
    //    {
    //        xlStyle = xlWorkbook.CreateCellStyle();
    //    }
    //    if (Bold || (FGColour != NPOI.HSSF.Util.HSSFColor.AUTOMATIC.index))
    //    {
    //        HSSFFont xlFont = xlWorkbook.CreateFont();
    //        if (FGColour != NPOI.HSSF.Util.HSSFColor.AUTOMATIC.index)
    //        {
    //            xlFont.Color = FGColour;
    //        }
    //        if (Bold)
    //        {
    //            xlFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;
    //        }
    //        xlStyle.SetFont(xlFont);
    //    }
    //    if (BGColour != NPOI.HSSF.Util.HSSFColor.AUTOMATIC.index)
    //    {
    //        if (BGColour != NPOI.HSSF.Util.HSSFColor.AUTOMATIC.index)
    //        {
    //            xlStyle.FillForegroundColor = BGColour;
    //        }
    //        xlStyle.FillPattern = CellFillPattern.SOLID_FOREGROUND;
    //    }
    //    if (Border)
    //    {
    //        xlStyle.BorderTop = CellBorderType.THIN;
    //        xlStyle.BorderLeft = CellBorderType.THIN;
    //        xlStyle.BorderRight = CellBorderType.THIN;
    //        xlStyle.BorderBottom = CellBorderType.THIN;
    //    }
    //    if (Align != CellHorizontalAlignment.GENERAL)
    //    {
    //        xlStyle.Alignment = Align;
    //    }
    //    xlCell.CellStyle = xlStyle;
    //    if (CellSpan > 1)
    //    {
    //        xlSheet.AddMergedRegion(new NPOI.HSSF.Util.Region(CurrentRow, CurrentColumn, CurrentRow, CurrentColumn + CellSpan));
    //    }
    //    xlSheet.SetColumnWidth(CurrentColumn, Width * 256);

    //    return true;
    //}

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

    protected void BTNCancel_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
    }

}
