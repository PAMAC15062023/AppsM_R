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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;
using Microsoft.Office.Core;
using System.Text;
using System.Data.SqlClient;
using iTextSharp.text;
using CrystalDecisions.Shared;
using iTextSharp.text.pdf;
using System.Threading;

public partial class BGC_BGC_BGC_Export : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    BGC objEBC = new BGC();
    CCommon objCmn = new CCommon();
    string verificationType = "RV";
   

    public ArrayList list = new ArrayList();
    public int listcount;
    protected void Page_Load(object sender, EventArgs e)
    {


        CCommon objConn = new CCommon();
        sdsOutput.ConnectionString = objConn.ConnectionString;  //Sir

        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        txtFromDate.Focus();
        lblMsg.Text = "";



        if (!IsPostBack)
        {
            Get_LocationList();
            ddrclient.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));
            ddrclient.SelectedIndex = 0;

            //Get_ClientList();
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";

            string ToDate = "";
            string FromDate = "";

            if (txtToDate.Text.Trim() != "")
                ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            if (txtFromDate.Text.Trim() != "")
                FromDate = objCmn.strDate(txtFromDate.Text.Trim());

            if (strCentreID != "" && strClientID != "")
            {
                hdFromDate.Value = FromDate;
                hdToDate.Value = ToDate;

                sdsOutput.SelectCommand = "SELECT CD.[CASE_ID], ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS " +
                                           "[APPLICANT_NAME],  Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' + " +
                                           "LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5)  + " +
                                          " RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME],  Convert(varchar(24),CD.SEND_DATETIME,103)" +
                                           "+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) " +
                                          " + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3))as [SEND_DATETIME],VM.VERIFICATION_TYPE_CODE AS VERIFICATION_CODE" +
                                          " FROM [CPV_EBC_CASE_DETAILS] CD INNER JOIN " +
                                          " CPV_EBC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID= VM.VERIFICATION_TYPE_ID" +
                                          " WHERE ((CD.[SEND_DATETIME] IS NOT NULL) AND (CD.CASE_STATUS_ID IS NOT NULL)" +
                                           "AND (CD.[CENTRE_ID] = '" + strCentreID + "') AND (CD.[CLIENT_ID] = '" + strClientID + "')AND " +
                                           "(CD.SEND_DATETIME >='" + FromDate + "' and CD.SEND_DATETIME<'" + ToDate + "' ))";
                

            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        //try catch is added by supriya on 15th Nov2007 
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {

    }

    protected void gvOutput_DataBound(object sender, System.EventArgs e)
    {
        
    }

    protected void btnGenrate_Report_Click(object sender, EventArgs e)
    {
        try
        {
            int iCount = 0;

            CCommon con = new CCommon();
            //EBC_StandardOutPut objStandardOutput = new EBC_StandardOutPut();
            BGC objStandardOutput = new BGC();
            string strId = "";
            string FinalwhereId = "";



            string[] arrCaseId = FinalwhereId.Split(',');

            {

                {
                    String strCentreID = Session["CentreId"].ToString(); //"1011";"1011";
                    String strClientID = Session["ClientId"].ToString(); //"1013";"10111";
                    if (strCentreID != "" && strClientID != "")
                    {


                        string ToDate = "";
                        string FromDate = "";
                        //By Ashish...
                        if (txtToDate.Text.Trim() != "")
                            ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                        if (txtFromDate.Text.Trim() != "")
                            FromDate = objCmn.strDate(txtFromDate.Text.Trim());

                        sqlcon.Open();
                        SqlCommand CMD2 = new SqlCommand();
                        CMD2.Connection = sqlcon;
                        CMD2.CommandType = CommandType.StoredProcedure;
                        CMD2.CommandText = "SpGetKpmgExcelReport_Ebc";
                        CMD2.CommandTimeout = 0;

                        SqlParameter FromDate1 = new SqlParameter();  /// IMP
                        FromDate1.SqlDbType = SqlDbType.DateTime;
                        FromDate1.Value = FromDate;//txtclosingdate.Text.ToString();
                        FromDate1.ParameterName = "@FromDate";
                        CMD2.Parameters.Add(FromDate1);

                        SqlParameter Todate = new SqlParameter();  /// IMP
                        Todate.SqlDbType = SqlDbType.DateTime;
                        Todate.Value = ToDate;//txtclosingdate.Text.ToString();
                        Todate.ParameterName = "@Todate";
                        CMD2.Parameters.Add(Todate);

                        SqlParameter Verification_Type_id = new SqlParameter();
                        Verification_Type_id.SqlDbType = SqlDbType.VarChar;
                        Verification_Type_id.Value = strClientID;
                        Verification_Type_id.ParameterName = "@ClientId";
                        CMD2.Parameters.Add(Verification_Type_id);

                        SqlDataAdapter Sqlda = new SqlDataAdapter();
                        Sqlda.SelectCommand = CMD2;

                        DataTable DT = new DataTable();
                        Sqlda.Fill(DT);



                        Workbook Wb = new HSSFWorkbook();
                        Sheet sheet1 = Wb.CreateSheet("Complaint");
                        Cell cell;

                        NPOI.SS.UserModel.Font font1 = Wb.CreateFont();
                        font1.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
                        font1.FontName = "Arial";
                        font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

                        NPOI.SS.UserModel.Font font2 = Wb.CreateFont();
                        font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
                        font2.FontName = "Arial";
                        font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

                        int rowIndex1 = 0;
                        Row row = sheet1.CreateRow(rowIndex1);

                        sheet1.DefaultRowHeight = 50;


                        cell = row.CreateCell(0);
                        cell.SetCellValue("Sr No");
                        cell.CellStyle.WrapText = true;
                        CellStyle style1 = cell.CellStyle;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.BorderBottom = CellBorderType.THIN;
                        cell.CellStyle.BorderRight = CellBorderType.THIN;
                        cell.CellStyle.BorderLeft = CellBorderType.THIN;
                        cell.CellStyle.BorderTop = CellBorderType.THIN;

                        cell.CellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.ORANGE.index;
                        cell.CellStyle.FillPattern = FillPatternType.NO_FILL;

                        cell = row.CreateCell(1);
                        cell.SetCellValue("Recvd Date & Time");
                        sheet1.SetColumnWidth(1, 9 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


                        cell = row.CreateCell(2);
                        cell.SetCellValue("Case ID");
                        sheet1.SetColumnWidth(2, 9 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


                        cell = row.CreateCell(3);
                        cell.SetCellValue("Ref No");
                        sheet1.SetColumnWidth(3, 15 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


                        cell = row.CreateCell(4);
                        cell.SetCellValue("Applicant Name");
                        sheet1.SetColumnWidth(4, 12 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


                        cell = row.CreateCell(5);
                        cell.SetCellValue("Verification Type");
                        sheet1.SetColumnWidth(5, 20 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;


                        cell = row.CreateCell(6);
                        cell.SetCellValue("Address");
                        sheet1.SetColumnWidth(6, 20 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.GENERAL;


                        cell = row.CreateCell(7);
                        cell.SetCellValue("Remarks");
                        sheet1.SetColumnWidth(7, 45 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;



                        cell = row.CreateCell(8);
                        cell.SetCellValue("Visit Date & Time");
                        sheet1.SetColumnWidth(8, 20 * 265);
                        cell.CellStyle.WrapText = true;
                        cell.CellStyle.VerticalAlignment = VerticalAlignment.BOTTOM;
                        cell.CellStyle.Alignment = HorizontalAlignment.CENTER;
                        cell.CellStyle = Wb.CreateCellStyle();
                        cell.CellStyle.SetFont(font1);

                        rowIndex1++;

                        for (int m = 1; m < DT.Columns.Count; m++)
                        {
                            row.GetCell(m).CellStyle.BorderBottom = CellBorderType.THIN;
                            row.GetCell(m).CellStyle.BorderRight = CellBorderType.THIN;
                            row.GetCell(m).CellStyle.BorderLeft = CellBorderType.THIN;
                            row.GetCell(m).CellStyle.BorderTop = CellBorderType.THIN;
                        }


                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            row = sheet1.CreateRow(rowIndex1);
                            row.CreateCell(0).SetCellValue(DT.Rows[i]["Sr_No"].ToString());
                            row.CreateCell(1).SetCellValue(DT.Rows[i]["Recvd Date & Time"].ToString());
                            row.CreateCell(2).SetCellValue(DT.Rows[i]["Case_id"].ToString());
                            row.CreateCell(3).SetCellValue(DT.Rows[i]["Ref_No"].ToString());
                            row.CreateCell(4).SetCellValue(DT.Rows[i]["Applicant Name"].ToString());
                            row.CreateCell(5).SetCellValue(DT.Rows[i]["Verification Type"].ToString());
                            row.CreateCell(6).SetCellValue(DT.Rows[i]["Address"].ToString());
                            row.CreateCell(7).SetCellValue(DT.Rows[i]["Remarks"].ToString());
                            row.CreateCell(8).SetCellValue(DT.Rows[i]["Visit Date & Time"].ToString());




                            rowIndex1++;

                            for (int j = 1; j < DT.Columns.Count; j++)
                            {
                                if (j == 6 || j == 7)
                                {

                                }
                                else
                                {
                                    sheet1.AutoSizeColumn(j);

                                }

                            }
                        }


                        sqlcon.Close();


                        using (MemoryStream exportData = new MemoryStream())
                        {
                            Wb.Write(exportData);

                            string saveAsFileName = string.Format("EPMG_EBC-{0:d}.xls", DateTime.Now).Replace("/", "-");

                            Response.ClearHeaders();
                            Response.ClearContent();
                            Response.Clear();
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));

                            Response.BinaryWrite(exportData.GetBuffer());
                            Response.End();
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void Download_record()
    {
        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";


            string ToDate = "";
            string FromDate = "";


            hdFromDate.Value = FromDate;
            hdToDate.Value = ToDate;


            using (SqlConnection con = new SqlConnection(objConn.AppConnectionString))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_OutputFormatEBCPDF1";
                cmd.CommandTimeout = 0;

                SqlParameter FromDate1 = new SqlParameter();  /// IMP
                FromDate1.SqlDbType = SqlDbType.DateTime;
                FromDate1.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
                FromDate1.ParameterName = "@FromDate";
                cmd.Parameters.Add(FromDate1);

                SqlParameter Todate = new SqlParameter();  /// IMP
                Todate.SqlDbType = SqlDbType.DateTime;
                Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
                Todate.ParameterName = "@Todate";
                cmd.Parameters.Add(Todate);

                SqlParameter CentreID = new SqlParameter();
                CentreID.SqlDbType = SqlDbType.VarChar;
                CentreID.Value = ddrlocation.SelectedValue.ToString();
                CentreID.ParameterName = "@centre_id";
                cmd.Parameters.Add(CentreID);

                SqlParameter client_id = new SqlParameter();
                client_id.SqlDbType = SqlDbType.VarChar;
                client_id.Value = ddrclient.SelectedValue.ToString();
                client_id.ParameterName = "@client_id";
                cmd.Parameters.Add(client_id);

                SqlParameter Cluster_id = new SqlParameter();
                Cluster_id.SqlDbType = SqlDbType.VarChar;
                Cluster_id.Value = Session["Clusterid"].ToString(); ;
                Cluster_id.ParameterName = "@Cluster_id";
                cmd.Parameters.Add(Cluster_id);


                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataSet MyDataSet = new DataSet();
                sda.Fill(MyDataSet);

                con.Close();


                grv_annexure.DataSource = MyDataSet;
                grv_annexure.DataBind();

                if (grv_annexure.Rows.Count <= 0)
                {
                    lblMsg.Text = "No record found";
                }
                else
                {


                    lblMsg.Text = "Total Cases Found Is " + grv_annexure.Rows.Count;
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    public void GetPDFExport(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
               // CReport objReport = new CReport();
                BGC objReport = new BGC();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtGetImage = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../BGC/UploadFiles/") + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                ////string strDateTimeNew = DateTime.Now.ToString("dd-MMM-yyyy");

                ////if (!Directory.Exists(strMapPath + strDateTime))
                ////    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    dtGetImage = objReport.GetPDFReportNew(arrCaseId[i].ToString());

                    //new add by kanchan
                    DataSet dsPDF = new DataSet();

                    dsPDF=objReport.GetPDFName(arrCaseId[i].ToString());


                    string pdfname = dsPDF.Tables[0].Rows[0]["pdfname"].ToString() ;
                    //----comp---//

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtGetImage);
                    dsStdOutput.Tables[1].TableName = "GetImage";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();

                    myReportDocument.Load(Server.MapPath("CrystalReport.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("CrystalReport.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + "/" + pdfname + ".pdf");

                   // list.Add(strMapPath + "/" + arrCaseId[i].ToString() + ".pdf");
                    list.Add(strMapPath + "/" + pdfname + ".pdf");



                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                dtCaseId.Clear();

                dtCaseId.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            //lblMsg.Visible = true;
            //lblMsg.Text = exp.Message;
            //hplDownload.Visible = false;
            //hplDownload.NavigateUrl = "";
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    public void GenerateFGBHomeFormat()
    {
        grdvwFGB.Visible = true;
        grv_annexure.Visible = false; 
        string attachment = "attachment; filename= Report.xls";

        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdvwFGB.RenderControl(htw);
        grdvwFGB.GridLines = System.Web.UI.WebControls.GridLines.Both;
        Response.Write(sw.ToString());
        Response.End();


    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void grv_annexure_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        for (int i = 0; i <= grv_annexure.Rows.Count - 1; i++)
        {

            string rateid = e.CommandArgument.ToString();

            hdnAnnexure.Value = grv_annexure.Rows[i].Cells[6].Text.Trim();

            string sCaseId = hdnAnnexure.Value;

            if (e.CommandName == "download")
            {
                if (rateid == hdnAnnexure.Value)
                {

                    string strMapPath = Server.MapPath("~/BGC/UploadFiles/") + grv_annexure.Rows[i].Cells[15].Text.Trim();

                    String attachment = "attachment; filename=" + grv_annexure.Rows[i].Cells[15].Text.Trim();

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Clear();

                    Context.Response.AddHeader("content-disposition", attachment);
                    Context.Response.ContentType = "application/PDF";

                    Response.WriteFile(strMapPath);
                    Response.End();
                }

            }
            else if (e.CommandName == "image1")
            {

           
                    if (rateid == sCaseId)
                    {                      
                       
                        string sVerifyType = "1";
                        Response.Redirect("EBC_renderimage.aspx?CaseID=" + sCaseId + "&Veri=" + sVerifyType + "&ImageType=1");
                    }
               
            }
            else if (e.CommandName == "image2")
            {
               
               
                    if (rateid == sCaseId)
                    {
                        string sVerifyType = "1";
                        Response.Redirect("EBC_renderimage.aspx?CaseID=" + sCaseId+ "&Veri=" + sVerifyType + "&ImageType=2");
                    }
               
            }

            else if (e.CommandName == "image3")
            {
                
              
                    if (rateid == sCaseId)
                    {
                        string sVerifyType = "1";
                        Response.Redirect("EBC_renderimage.aspx?CaseID=" + sCaseId + "&Veri=" + sVerifyType + "&ImageType=3");
                    }
               
            }

            else if (e.CommandName == "image4")
            {
               
    
                    if (rateid == sCaseId)
                    {
                string sVerifyType = "1";
                Response.Redirect("EBC_renderimage.aspx?CaseID=" + sCaseId + "&Veri=" + sVerifyType + "&ImageType=4");
          
                 }
            }
            else if (e.CommandName == "image5")
            {
                
           
                    if (rateid == sCaseId)
                    {
                        string sVerifyType = "1";
                        Response.Redirect("EBC_renderimage.aspx?CaseID=" + sCaseId + "&Veri=" + sVerifyType + "&ImageType=5");
                    }
               
            }


        }
    }

    protected void btnrpt_Click(object sender, EventArgs e)
    {
        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ddrreport.SelectedValue.ToString();
            cmd.CommandTimeout = 0;

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

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddrlocation.SelectedValue.ToString();
            CentreID.ParameterName = "@centre_id";
            cmd.Parameters.Add(CentreID);

            SqlParameter client_id = new SqlParameter();
            client_id.SqlDbType = SqlDbType.VarChar;
            client_id.Value = ddrclient.SelectedValue.ToString();
            client_id.ParameterName = "@client_id";
            cmd.Parameters.Add(client_id);

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = Session["Clusterid"].ToString(); ;
            Cluster_id.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(Cluster_id);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;


            DataTable dt = new DataTable();
            da.Fill(dt);

            grdvwFGB.DataSource = dt;
            grdvwFGB.DataBind();

            if (dt.Rows.Count > 0)
            {
                // grdvwFGB.Visible = false; given by sir
                lblMsg.Text = "Total Record Found :" + dt.Rows.Count;

                if (ddrreport.SelectedValue.ToString() == "sp_OutputFormatEBCPDF1")
                {
                    String strSelectedCaseID = "";
                    grdvwFGB.Visible=false;
                    grv_annexure.Visible = true;
                    //pngrdvwFGB.Visible = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //pngrdvwFGB.Visible = false;

                        strSelectedCaseID += dt.Rows[i]["CASE_ID"].ToString() + ",";



                    }
                    String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                    GetPDFExport(arrCaseID);
                    Download_record();
                }
                else
                {
                    //pngrdvwFGB.Visible = true;
                            
                    GenerateFGBHomeFormat();

                }



            }
            else
            {
                lblMsg.Text = "Record not found";
            }

        }
        catch (ThreadAbortException)
        {
            throw;
        }

    }

    private void Get_LocationList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlcon;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "GetEBC_ClientCentreList";
            cmd1.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = "0";
            CentreID.ParameterName = "@centre_id";
            cmd1.Parameters.Add(CentreID);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd1;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddrlocation.DataTextField = "Centre_name";
                ddrlocation.DataValueField = "centre_Id";

                ddrlocation.DataSource = dt1;
                ddrlocation.DataBind();

                ddrlocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));
                ddrlocation.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }

    private void Get_ClientList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlcon;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "GetEBC_ClientList";
            cmd1.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddrlocation.SelectedValue.ToString();
            CentreID.ParameterName = "@centre_id";
            cmd1.Parameters.Add(CentreID);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd1;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddrclient.DataTextField = "Client_name";
                ddrclient.DataValueField = "Client_Id";

                ddrclient.DataSource = dt1;
                ddrclient.DataBind();

                ddrclient.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));
                ddrclient.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error : " + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void ddrlocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_ClientList();
    }


    
}
