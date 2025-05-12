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


public partial class CPV_EBC_EBC_Standard_Output : System.Web.UI.Page
{
  CCommon objConn = new CCommon(); SqlConnection sqlcon;

    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsOutput.ConnectionString = objConn.ConnectionString;  //Sir

        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        txtFromDate.Focus();
        lblMsg.Text = "";
    }
    //search to fill database between from to SEND_DATETIME
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";
            //String strDateCriteria = "";
            string ToDate = "";
            string FromDate = "";
            //By Ashish...
            if (txtToDate.Text.Trim() != "")
                ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            if (txtFromDate.Text.Trim() != "")
                FromDate = objCmn.strDate(txtFromDate.Text.Trim());

            if (strCentreID != "" && strClientID != "")
            {
                hdFromDate.Value = FromDate;
                hdToDate.Value = ToDate;

                sdsOutput.SelectCommand = "SELECT distinct CD.[CASE_ID], ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS " +
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
                gvOutput.DataBind();
                if (gvOutput.Rows.Count > 0)
                {
                    lblCaseCount.Text = "Number of cases: " + gvOutput.Rows.Count;
                    pnlView.Visible = true;
                    lblMsg.Visible = false;
                }
                else
                {
                    lblCaseCount.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    pnlView.Visible = false;
                }

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
        //try
        //{
        //    //getting selected rows caseid
        //    HiddenField hdnCaseID;
        //    System.Web.UI.WebControls.CheckBox chkCaseID;
        //    String strSelectedCaseID = "";
        //    foreach (GridViewRow row in gvOutput.Rows)
        //    {
        //        hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
        //        chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
        //        if (chkCaseID.Checked)
        //        {
        //            strSelectedCaseID += hdnCaseID.Value + ",";
        //        }
        //    }
        //    //strSelectedCaseID ="101112938";// "101114613";
        //    if (strSelectedCaseID != "")
        //    {
        //        String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
        //        //passed caseid's in array to generate excel
        //        GenerateExcel(arrCaseID);
        //        lblMsg.Text = "Export completed successfully";
        //        hplDownload.Visible = true;
        //        hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC//" + Session["UserName"].ToString() + "//";
        //    }
        //    else
        //    {
        //        lblMsg.Text = "Please select case to assign";
        //        hplDownload.Visible = false;
        //        hplDownload.NavigateUrl = "";
        //    }
        //}
        //catch (Exception exp)
        //{
        //    lblMsg.Text = exp.Message;
        //    hplDownload.Visible = false;
        //    hplDownload.NavigateUrl = "";
        //}
    }

    protected void gvOutput_DataBound(object sender, System.EventArgs e)
    {
        // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        // Get the header CheckBox
        if (gvOutput.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvOutput.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in gvOutput.Rows)
            {
                // Get a programmatic reference to the CheckBox control
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkCaseId")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }

   

    protected void btnGenrate_Report_Click(object sender, EventArgs e)
    {
        int iCount = 0;

        CCommon con = new CCommon();
        EBC_StandardOutPut objStandardOutput = new EBC_StandardOutPut();
        string strId = "";
        string FinalwhereId = "";
        foreach (GridViewRow gvror in gvOutput.Rows)
        {
            System.Web.UI.WebControls.CheckBox chk = gvror.FindControl("chkCaseId") as System.Web.UI.WebControls.CheckBox;
            if (chk.Checked == true)
            {
                System.Web.UI.WebControls.Label CaseId = gvror.FindControl("Label1") as System.Web.UI.WebControls.Label;
                strId = CaseId.Text;
                if (FinalwhereId != "")
                {
                    FinalwhereId = FinalwhereId + "," + strId;
                }
                else
                {
                    FinalwhereId = strId;
                }
            }
        }


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
                    CMD2.CommandText = "SpGetKpmgExcelReport_Ebc12";
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

                    //SqlParameter Case_ID = new SqlParameter();
                    //Case_ID.SqlDbType = SqlDbType.VarChar;
                    //Case_ID.Value = strId;
                    //Case_ID.ParameterName = "@Case_ID";
                    //CMD2.Parameters.Add(Case_ID);

                    SqlParameter Verification_Type_id = new SqlParameter();
                    Verification_Type_id.SqlDbType = SqlDbType.VarChar;
                    Verification_Type_id.Value = strClientID;
                    Verification_Type_id.ParameterName = "@ClientId";
                    CMD2.Parameters.Add(Verification_Type_id);

                    SqlDataAdapter Sqlda = new SqlDataAdapter();
                    Sqlda.SelectCommand = CMD2;

                    DataTable DT = new DataTable();
                    Sqlda.Fill(DT);


                    // Create a new workbook and a sheet named "Complaint Register"

                    Workbook Wb = new HSSFWorkbook();
                    Sheet sheet1 = Wb.CreateSheet("Complaint");
                    Cell cell;

                    Font font1 = Wb.CreateFont();
                    font1.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
                    font1.FontName = "Arial";
                    font1.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

                    Font font2 = Wb.CreateFont();
                    font2.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
                    font2.FontName = "Arial";
                    font2.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

                    int rowIndex1 = 0;
                    Row row = sheet1.CreateRow(rowIndex1);
                    //row.Height = 50;

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

                    //Not Sure whether its working or not

                    cell.CellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.ORANGE.index;
                    cell.CellStyle.FillPattern = FillPatternType.NO_FILL;

                    //Not Sure whether its working or not

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

                    cell = row.CreateCell(9);
                    cell.SetCellValue("diffaddress");
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
                        row.CreateCell(9).SetCellValue(DT.Rows[i]["diffaddress"].ToString());


                      

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

}

        
