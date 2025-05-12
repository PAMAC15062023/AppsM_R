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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Excel;
using Microsoft.Office.Core;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;

using System.Data.SqlClient;

public partial class CPV_KYC_KYC_EXPORT_ALL : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;

    CCommon objCmn = new CCommon();

   
    public ArrayList list = new ArrayList();
    public int listcount;

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
               
        sdsSelectFormat.ConnectionString = objConn.ConnectionString;  //Sir
        sdsSelectFormat1.ConnectionString = objConn.ConnectionString;  //Sir
        SqlDataSourceDate.ConnectionString = objConn.ConnectionString;  //Sir

        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        txtFromDate.Focus();
        lblMsg.Text = "";

        String strCentreID = Session["CentreId"].ToString(); //"1011";
        String strClientID = Session["ClientId"].ToString(); //"1013";

        if (Convert.ToInt32(strClientID) == 10160 && Convert.ToInt32(strCentreID) == 1012)
        {
            Button1.Visible = true;
        }
        else if (Convert.ToInt32(strClientID) == 101121 && Convert.ToInt32(strCentreID) == 1012)
        {
            Button1.Visible = true;
        }
        else
        {
            Button1.Visible = false;
        }


        if (Convert.ToInt32(strClientID) == 101259 || Convert.ToInt32(strClientID) == 101181 || Convert.ToInt32(strClientID) == 101193 || Convert.ToInt32(strClientID) == 101214 || Convert.ToInt32(strClientID) == 101234)
        {
            btnHDFC_Ergo_Excel.Visible = true;
        }
        else
        {
            btnHDFC_Ergo_Excel.Visible = false;
        }


        if (Convert.ToInt32(strClientID) == 101225)
        {
            btnPayZippy.Visible = true;
        }
        else
        {
            btnPayZippy.Visible = false;
        }

        if (Convert.ToInt32(strClientID) == 101324)
        {
            btnHDFCSales.Visible = true;
        }
        else
        {
            btnHDFCSales.Visible = false;
        }


        if (Convert.ToInt32(strClientID) == 101325)
        {
            btnHDFC_OneTime.Visible = true;
        }
        else
        {
            btnHDFC_OneTime.Visible = false;
        }

    
    
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            String strCentreID = Session["CentreId"].ToString(); //"1011";
            String strClientID = Session["ClientId"].ToString(); //"1013";
            //String strDateCriteria = "";
            string ToDate = "";
            string FromDate = "";
            //modified by hemangi kambli on 21-Aug-2007 --------------------------
     
            if (rdoFromToDate.Checked == true)
            {
                if (txtToDate.Text.Trim() != "")
                    ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

                if (txtFromDate.Text.Trim() != "")
                    FromDate = objCmn.strDate(txtFromDate.Text.Trim());
            }
            else if (rdoDateTime.Checked == true)
            {
                FromDate = objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim();
                ToDate = Convert.ToDateTime(objCmn.strDate(txtDate.Text.Trim()) + ' ' + txtTime.Text.Trim() + ' ' + ddlTimeType.SelectedItem.Text.Trim()).AddMinutes(1.0).ToString("dd-MMM-yyyy hh:mm tt");
            }
            hdFromDate.Value = FromDate;
            hdToDate.Value = ToDate;
            //----------------------------------------------------------------------------
     
            if (strCentreID != "" && strClientID != "")
            {
     
                string sSql = "SELECT Count(*) as TotalCount FROM [CPV_KYC_CASE_DETAILS] " +
                              "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";

                OleDbDataReader oledbRead;
                oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
                if (oledbRead.Read() == true)
                    lblCaseCount.Text = "Number of cases : " + oledbRead["TotalCount"].ToString();

                oledbRead.Close();
     
                gvOutput.DataBind();
                if (gvOutput.Rows.Count > 0)
                {
                    tblCaseCount.Visible = true;
                    lblMsg.Visible = false;
                }
                else
                {
                    tblCaseCount.Visible = false;
                    lblCaseCount.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found.";
              }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }

    protected void btnExport1_Click(object sender, EventArgs e)
    {
        try
        {
            //getting selected rows caseid
            HiddenField hdnCaseID;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID += hdnCaseID.Value + ",";
                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //passed caseid's in array to generate excel
                GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID);
                GetMergedPDF();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to Export.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
                gvOutput.DataBind();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            //getting selected rows caseid 
            HiddenField hdnCaseID;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    strSelectedCaseID += hdnCaseID.Value + ",";
                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //passed caseid's in array to generate excel
                GetExport(ddlSelectFormat.SelectedValue.ToString(), arrCaseID);
                GetMergedPDF();
           }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select case to Export.";
                hplDownload.Visible = false;
                hplDownload.NavigateUrl = "";
                gvOutput.DataBind();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    private void GetMergedPDF()
    {
        PDFMerger merge = new PDFMerger();

        for (int i = 0; i < listcount; i++)
        {
            merge.AddFile(list[i].ToString());
        }

        merge.DestinationFile = hdnDestPath.Value;
        merge.Execute();
    }

    public void GenerateYesBankExcelFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetYesBankRvInfo(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetYesBankBvInfo(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_YesBank_RV";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_YesBank_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_YesBank_Main.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_YesBank_Main.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.Excel, strMapPath + strDateTime + "/" + sCase_id + ".xls");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    
                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }



    //added by abhijeet for PAYZiPPY//
    public void Generatepayziipyormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationPay_zippy(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "KYC_PAY_ZIPPY";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("pay_zipy.rpt"));

                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("pay_zipy.rpt");

                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf",,strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }



    //ended by abhijeet//
    public void GenerateYesBankFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetYesBankRvInfo(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetYesBankBvInfo(arrCaseId[i].ToString());
                   
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_YesBank_RV";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_YesBank_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_YesBank_Main.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_YesBank_Main.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
   
    public void GenerateHdfcLiabFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                
                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    string sAppname = "";

                    OleDbDataReader oledbRead;
                    OleDbDataReader oledbReadNew;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();

                    oledbReadNew = objReport.GetAppnameBycaseIDKYC(arrCaseId[i].ToString());
                    if (oledbReadNew.Read())
                        sAppname = oledbReadNew["App_Name"].ToString();

                    oledbRead.Close();
             

                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc(arrCaseId[i].ToString());
                
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_Hdfc_Resi";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_Hdfc_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_Hdfc_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateHdfcWelcomeKitFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_Hdfc_Resi";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_Hdfc_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_Hdfc_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
   
    public void GenerateCRPTechnology_ClientSpecificFormat(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriKYC_CRP_ClientSpecific(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "CRP_Tech_ClientSpecific";
                                        
                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CRP_Technology_ClientSpecific.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("CRP_Technology_ClientSpecific.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
       
    public void GenerateCRPTechnology_Mahindra_AND_Mahindra(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriKYC_CRP_ClientSpecific(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "CRP_Tech_ClientSpecific";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CRP_MahindraANDMahindra_RV.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("CRP_MahindraANDMahindra_RV.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    
    public void GenerateCRPTechnology_IPru_AddressCheck(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriKYC_CRP_ClientSpecific(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "CRP_Tech_ClientSpecific";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("IPruAddresscheck.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("IPruAddresscheck.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateCRPTechnology_TCS_AND_ITS_Vendor(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriKYC_CRP_ClientSpecific(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "CRP_Tech_ClientSpecific";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CRP_TCS_Vendor.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("CRP_TCS_Vendor.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateHdfcLiabCurrFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    string sAppname = "";
                    OleDbDataReader oledbRead;
                    OleDbDataReader oledbReadNew;

                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();

                    oledbReadNew = objReport.GetAppnameBycaseIDKYC(arrCaseId[i].ToString());
                    if (oledbReadNew.Read())
                        sAppname = oledbReadNew["App_Name"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc_Curr(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc_Curr(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_Hdfc_Resi";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_HdfcCurr_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_HdfcCurr_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sAppname + ".pdf");
                                       //list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateAtomTech_Facilitator_Format(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtPOS_Merchant_Vetting_Verify = new System.Data.DataTable();
                System.Data.DataTable dtMOS_Merchant_Vetting_Verify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtPOS_Merchant_Vetting_Verify = objReport.GetBV_POS_Merchant_Vetting(arrCaseId[i].ToString());
                    dtMOS_Merchant_Vetting_Verify = objReport.GetBV_MOS_Merchant_Vetting(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtPOS_Merchant_Vetting_Verify);
                    dsStdOutput.Tables[1].TableName = "Kyc_AtomTech_BV_POS";

                    dsStdOutput.Tables.Add(dtMOS_Merchant_Vetting_Verify);
                    dsStdOutput.Tables[2].TableName = "Kyc_AtomTech_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_AtomTech_Main.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_AtomTech_Main.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end
            
                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtPOS_Merchant_Vetting_Verify.Clear();
                dtMOS_Merchant_Vetting_Verify.Clear();

                dtCaseId.Dispose();
                dtPOS_Merchant_Vetting_Verify.Dispose();
                dtMOS_Merchant_Vetting_Verify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    public void GenerateIndusandBvuFormat_PDFFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationIndusandKyc_Curr(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Indusandbank_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Indusindbank.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Indusindbank.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    //added by abhijeet //

    public void GenerateHdfcLiabFormat12(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    string sAppname = "";

                    OleDbDataReader oledbRead;
                    OleDbDataReader oledbReadNew;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();

                    oledbReadNew = objReport.GetAppnameBycaseIDKYC(arrCaseId[i].ToString());
                    if (oledbReadNew.Read())
                        sAppname = oledbReadNew["App_Name"].ToString();

                    oledbRead.Close();


                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_Hdfc_Resi";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_svc_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_svc_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    //added by abhijeet//


    //added by manswini
    public void GenerateKotakormatKYC(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    string sAppname = "";

                    OleDbDataReader oledbRead;
                    OleDbDataReader oledbReadNew;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();

                    oledbReadNew = objReport.GetAppnameBycaseIDKYC(arrCaseId[i].ToString());
                    if (oledbReadNew.Read())
                        sAppname = oledbReadNew["App_Name"].ToString();

                    oledbRead.Close();


                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());

                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc_BVnew(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc_kotak(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "kotak_mahindra_RV";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[2].TableName = "kotak_mahindra_BV";



                    if (dsStdOutput.Tables[2].Rows.Count > 0)
                    {
                        CrystalReportDocument myReportDocument;
                        myReportDocument = new CrystalReportDocument();
                        myReportDocument.Load(Server.MapPath("kotak_mahindra_BV.rpt"));
                        myReportDocument.SetDataSource(dsStdOutput);

                        Session["Path"] = Server.MapPath("kotak_mahindra_BV.rpt");
                        myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                        myReportDocument.Dispose();
                    }
                    else
                    {
                        CrystalReportDocument myReportDocument;
                        myReportDocument = new CrystalReportDocument();
                        myReportDocument.Load(Server.MapPath("kotak_mahindra_RV.rpt"));
                        myReportDocument.SetDataSource(dsStdOutput);

                        Session["Path"] = Server.MapPath("kotak_mahindra_RV.rpt");
                        myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                        myReportDocument.Dispose();
                    }


                    Session["Path"] = Server.MapPath("kotak_mahindra_RV.rpt");

                    list.Add(strMapPath + strDateTime + "/" + sAppname + ".pdf");

                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    GC.Collect();
                }
                listcount = list.Count;


                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();
                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();
                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    //added by Manswini //


    //added by abhijeet for ING 27 oct 2014//
    public void GenerateINGFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    string sAppname = "";

                    OleDbDataReader oledbRead;
                    OleDbDataReader oledbReadNew;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();

                    oledbReadNew = objReport.GetAppnameBycaseIDKYC(arrCaseId[i].ToString());
                    if (oledbReadNew.Read())
                        sAppname = oledbReadNew["App_Name"].ToString();

                    oledbRead.Close();


                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc123(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_Hdfc_Resi";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_ING_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);


                    Session["Path"] = Server.MapPath("KYC_ING_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sAppname + ".pdf");
                    //list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    //added by abhijeet for ING 27 oct 2014//

    public void GenerateDeuhbank_PDFFormat(string[] arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtPOS_Merchant_Vetting_Verify = new System.Data.DataTable();


                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtPOS_Merchant_Vetting_Verify = objReport.GetRV_Deuhchbankkyc_Vetting(arrCaseId[i].ToString());


                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtPOS_Merchant_Vetting_Verify);
                    dsStdOutput.Tables[1].TableName = "Deutschebank_BV";


                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("DeutscheBank.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("DeutscheBank.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtPOS_Merchant_Vetting_Verify.Clear();
                dtCaseId.Dispose();
                dtPOS_Merchant_Vetting_Verify.Dispose();
                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }



    //Added by abhijeet for hfdc bank//
    public void GenerateHdfcbanksalesFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                        sCase_id = oledbRead["Name"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationHDFCSALESkyc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationHDFCBANKSALES(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "HDFC_SALES_BV";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "HDFC_SALES_RV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("HDFCNEW.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("HDFCNEW.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    //ended by abhijeet ///
    public void GenerateIndusindFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                
                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc_Curr(arrCaseId[i].ToString());
                
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_Hdfc_Buss";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_Indusind_Main.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_Indusind_Main.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                
                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                
                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateTCMFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                
                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKycTCM(arrCaseId[i].ToString());
                   
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_tcm_Bv";
                    
                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Kyc_tcm_Export.rpt"));
                    
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Kyc_tcm_Export.rpt");
                    
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
              
                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
               
                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }

    public void GenerateScbAcOpFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                System.Data.DataTable dtCaVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusiVeriDtlKycScbAcOp(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriDtlKycScbAcOp(arrCaseId[i].ToString());
                    dtCaVerify = objReport.GetCaVeriDtlKycScbAcOp(arrCaseId[i].ToString());  
                    
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_ScbAC_Buss";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "Kyc_ScbAC_Resi";

                    dsStdOutput.Tables.Add(dtCaVerify);
                    dsStdOutput.Tables[3].TableName = "Kyc_ScbAC_CA";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("KYC_ScbAcOp_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("KYC_ScbAcOp_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                                       list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    public void GenerateHDFCERGOFormat_PDFFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationHDFCKyc_Curr(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationHDFCKyc_Curr(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "HDFCERGO_BV";


                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "HDFCERGO_RV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("HDFCERGO.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("HDFCERGO.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

                
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }



    //added by abhijeet for kotak//

    public void GenerateKotakFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    //dtResiVerify = objReport.GetYesBankRvInfo(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetKotakBV(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kotak_bank";

                    //dsStdOutput.Tables.Add(dtOfficeVerify);
                    //dsStdOutput.Tables[2].TableName = "Kyc_YesBank_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Kotak.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Kotak.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

                    //NIKHIL start 25 march 2013
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
                    ////
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;

                //NIKHIL end

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = "D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtOfficeVerify.Clear();
                dtResiVerify.Clear();

                dtCaseId.Dispose();
                dtOfficeVerify.Dispose();
                dtResiVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    //ended by abhijeet for kotak//
    public void GenerateKunvarji_RV_PDFFormat(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                //Added for Kunvarji BV
                System.Data.DataTable dtOfficeVerify = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/KYC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    string sRefNo = "";
                    string sCase_id = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    sCase_id = oledbRead["Case_id"].ToString();


                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());

                    dtResiVerify = objReport.GetResidenceVerificationKunvarji(arrCaseId[i].ToString());
                    //Added for Kunvarji BV
                    dtOfficeVerify = objReport.GetOfficeVerificationKunvarji(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "Kun_RV";

                    //Added for Kunvarji BV
                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[2].TableName = "Kun_BV";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    //myReportDocument.Load(Server.MapPath("rptKunvarji.rpt"));
                    myReportDocument.Load(Server.MapPath("Kunvarji.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    //Session["Path"] = Server.MapPath("rptKunvarji.rpt");
                    Session["Path"] = Server.MapPath("Kunvarji.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sCase_id + ".pdf");

              
                    list.Add(strMapPath + strDateTime + "/" + sCase_id + ".pdf");
        
                    if (i == 0)
                    {
                        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                        FileStream output = new FileStream(strMapPath + strDateTime + "/ConsolidatedPDF.pdf", FileMode.Create);
                        PdfWriter writer = PdfWriter.GetInstance(document, output);

                        document.Open();
                        document.Add(new Paragraph("My Test PDF"));
                        document.Close();

                        hdnDestPath.Value = strMapPath + strDateTime + "/ConsolidatedPDF.pdf";
                    }

                    myReportDocument.Dispose();
                    GC.Collect();
                }
                listcount = list.Count;


                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//KYC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();

                dtResiVerify.Clear();
                //Added for Kunvarji BV
                dtOfficeVerify.Clear();

                dtCaseId.Dispose();

                dtResiVerify.Dispose();
                //Added for Kunvarji BV
                dtOfficeVerify.Dispose();

                dsStdOutput.Clear();
                dsStdOutput.Dispose();
            }
        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    public void GetExport(string strFormat, String[] arrCaseID)
    {
        if (ddlSelectFormat.SelectedValue.ToString() == "5" || ddlSelectFormat1.SelectedValue.ToString() == "5")
            GenerateHdfcLiabFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "8" || ddlSelectFormat1.SelectedValue.ToString() == "8")
            GenerateScbAcOpFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "13" || ddlSelectFormat1.SelectedValue.ToString() == "13")
            GenerateTCMFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "15" || ddlSelectFormat1.SelectedValue.ToString() == "15")
            GenerateHdfcLiabCurrFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "16" || ddlSelectFormat1.SelectedValue.ToString() == "16")
            GenerateCRPTechnology_ClientSpecificFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "21" || ddlSelectFormat1.SelectedValue.ToString() == "21")
            GenerateCRPTechnology_Mahindra_AND_Mahindra(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "22" || ddlSelectFormat1.SelectedValue.ToString() == "22")
            GenerateCRPTechnology_TCS_AND_ITS_Vendor(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "23" || ddlSelectFormat1.SelectedValue.ToString() == "23")
            GenerateCRPTechnology_IPru_AddressCheck(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "26" || ddlSelectFormat1.SelectedValue.ToString() == "26")
            GenerateHdfcLiabFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "35" || ddlSelectFormat1.SelectedValue.ToString() == "35")
            GenerateYesBankFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "36" || ddlSelectFormat1.SelectedValue.ToString() == "36")
            GenerateYesBankExcelFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "37" || ddlSelectFormat1.SelectedValue.ToString() == "37")
            GenerateHdfcWelcomeKitFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "40" || ddlSelectFormat1.SelectedValue.ToString() == "40")
            GenerateIndusindFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "41" || ddlSelectFormat1.SelectedValue.ToString() == "41")
            GenerateAtomTech_Facilitator_Format(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "69" || ddlSelectFormat1.SelectedValue.ToString() == "69")
            GenerateDeuhbank_PDFFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "82" || ddlSelectFormat1.SelectedValue.ToString() == "82")
            GenerateIndusandBvuFormat_PDFFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "90" || ddlSelectFormat1.SelectedValue.ToString() == "90")
            GenerateHDFCERGOFormat_PDFFormat(arrCaseID);

        //    //added by abhijeet for Kunvarji south//
        //else if (ddlSelectFormat.SelectedValue.ToString() == "104" || ddlSelectFormat1.SelectedValue.ToString() == "104")
        //    GenerateKunvarji_RV_PDFFormat(arrCaseID);
        ////ended by abhijeet//

               //added by abhijeet for Kunvarji south//
        else if (ddlSelectFormat.SelectedValue.ToString() == "105" || ddlSelectFormat1.SelectedValue.ToString() == "105")
            Generatepayziipyormat(arrCaseID);
        //ended by abhijeet//

            //added by abhijeet for Kunvarji south//
        else if (ddlSelectFormat.SelectedValue.ToString() == "114" || ddlSelectFormat1.SelectedValue.ToString() == "114")
            GenerateHdfcbanksalesFormat(arrCaseID);
        //ended by abhijeet//

        //         //added by abhijeet for kotak//

        else if (ddlSelectFormat.SelectedValue.ToString() == "122" || ddlSelectFormat1.SelectedValue.ToString() == "122")
            GenerateKotakFormat(arrCaseID);
        //ended by abhijeet for kotak//


                 //         //added by abhijeet for ING 27 oct @014//

        else if (ddlSelectFormat.SelectedValue.ToString() == "126" || ddlSelectFormat1.SelectedValue.ToString() == "126")
            GenerateINGFormat(arrCaseID);
        //ended by abhijeet for ING 27 oct @014//




                     //added by manswini for Kotak//

        else if (ddlSelectFormat.SelectedValue.ToString() == "131" || ddlSelectFormat1.SelectedValue.ToString() == "131")
            GenerateKotakormatKYC(arrCaseID);
        //ended by manswini for kotak //




            //added by abhijeet for svc 13 april 2015//
        else if (ddlSelectFormat.SelectedValue.ToString() == "133" || ddlSelectFormat1.SelectedValue.ToString() == "133")
            GenerateHdfcLiabFormat12(arrCaseID);
        //ended by abhijeet//

             





        else if (ddlSelectFormat.SelectedValue.ToString() == "111" || ddlSelectFormat1.SelectedValue.ToString() == "111")
            GenerateKunvarji_RV_PDFFormat(arrCaseID);
        else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
        gvOutput.DataBind();
    }

    protected void cvSelectFormat_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
        }
    }

    protected void gvOutput_PageIndexChanged(object sender, EventArgs e)
    {
        gvOutput.DataBind();
    }

    protected void gvOutput_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOutput.DataBind();
    }

    protected void gvOutput_DataBound(object sender, System.EventArgs e)
    {
    //    // Each time the data is bound to the grid we need to build up the CheckBoxIDs array
    //    // Get the header CheckBox
        if (gvOutput.Rows.Count <= 0)
        {
            //lblMsg.Text = "No record found";
        }
        else
        {
            tblCaseCount.Visible = true;
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

    private void GenerateHDFCReport()
    {
        String strClientID = Session["ClientId"].ToString();

        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Hdfc_liab_Dump";
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
            CentreID.Value = Session["CentreId"].ToString();
            CentreID.ParameterName = "@Centreid";
            cmd.Parameters.Add(CentreID);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientId"].ToString();
            ClientId.ParameterName = "@ClientId";
            cmd.Parameters.Add(ClientId);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;


            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = "Total Count Is :" + ds.Tables[0].Rows.Count;

                grdvwFGB.DataSource = ds;
                grdvwFGB.DataBind();
                           


            }

        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }

        GenerateEXPORTFormat();
    }

    public void GenerateEXPORTFormat()
    {

        string attachment = "attachment; filename= Report.xls";

        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        grdvwFGB.RenderControl(htw);
        grdvwFGB.GridLines = GridLines.Both;
        Response.Write(sw.ToString());
        Response.End();

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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GenerateHDFCReport();
    }

    //added by SANKET for HDFC_Ergo
    protected void btnHDFC_Ergo_Excel_Click(object sender, EventArgs e)
    {
        GenerateHDFC_Ergo_Report();
    }

    private void GenerateHDFC_Ergo_Report()
    {
        String strClientID = Session["ClientId"].ToString();

        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_HDFC_Ergo_Excel";
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

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientId"].ToString();
            ClientId.ParameterName = "@ClientId";
            cmd.Parameters.Add(ClientId);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = "Total Count Is :" + ds.Tables[0].Rows.Count;

                grdvwFGB.DataSource = ds;
                grdvwFGB.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }
        GenerateEXPORTFormat();
    }
    //end by SANKET


    //added by Abhijeet for PayZippy
    private void GeneratePayZippy_Report()
    {
        String strClientID = Session["ClientId"].ToString();

        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetBusinessVerificationpay_zippy_EXCElREPORT";
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

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientId"].ToString();
            ClientId.ParameterName = "@ClientId";
            cmd.Parameters.Add(ClientId);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = "Total Count Is :" + ds.Tables[0].Rows.Count;

                grdvwFGB.DataSource = ds;
                grdvwFGB.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }
        GenerateEXPORTFormat();
    }

    protected void btnPayZippy_Click(object sender, EventArgs e)
    {
        GeneratePayZippy_Report();
    }
    //end by Abhijeet




    protected void btnHDFCSales_Click(object sender, EventArgs e)
    {
        GenerateHDFC_Sales_Report();
    }

    private void GenerateHDFC_Sales_Report()
    {
        String strClientID = Session["ClientId"].ToString();

        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_HDFC_SALES_Excel";
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

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientId"].ToString();
            ClientId.ParameterName = "@Client_ID";
            cmd.Parameters.Add(ClientId);

            SqlParameter Centreid = new SqlParameter();
            Centreid.SqlDbType = SqlDbType.VarChar;
            Centreid.Value = Session["Centreid"].ToString();
            Centreid.ParameterName = "@Centreid";
            cmd.Parameters.Add(Centreid);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            sqlcon.Open();

            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlcon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = "Total Count Is :" + ds.Tables[0].Rows.Count;

                grdvwFGB.DataSource = ds;
                grdvwFGB.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }
        GenerateEXPORTFormat();
    }


    protected void btnHDFC_OneTime_Click(object sender, EventArgs e)
    {
        GenerateHDFC_One_Time();
    }

    private void GenerateHDFC_One_Time()
    {
        String strClientID = Session["ClientId"].ToString();

        try
        {
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_HDFC_Lia_One_Time";
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

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.Value = Session["ClientId"].ToString();
            ClientId.ParameterName = "@Client_ID";
            cmd.Parameters.Add(ClientId);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            sqlcon.Open();

            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlcon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                lblMsg.Text = "Total Count Is :" + ds.Tables[0].Rows.Count;

                grdvwFGB.DataSource = ds;
                grdvwFGB.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMsg.Text = Ex.Message;
        }
        GenerateEXPORTFormat();
    }


}
