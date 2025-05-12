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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;



public partial class IDOC_IDOC_IDOC_EXPORT_ALL : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();

        sdsSelectFormat.ConnectionString = objConn.ConnectionString;  //Rupesh
        sdsSelectFormat1.ConnectionString = objConn.ConnectionString;  //Rupesh
        SqlDataSourceDate.ConnectionString = objConn.ConnectionString;  // Rupesh


        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        txtFromDate.Focus();
        lblMsg.Text = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            String strCentreID = Session["CentreId"].ToString(); 
            String strClientID = Session["ClientId"].ToString(); 
            
            string ToDate = "";
            string FromDate = "";
            
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

                string sSql = "SELECT Count(*) as TotalCount FROM [CPV_IDOC_CASE_DETAILS] " +
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
            HiddenField hdnCaseID;
            HiddenField hdnVeriTy;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            String verfiID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                hdnVeriTy = (HiddenField)row.FindControl("hidVeriType");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    //strSelectedCaseID = hdnCaseID.Value + ",";
                    strSelectedCaseID = hdnCaseID.Value;
                    verfiID = hdnVeriTy.Value;
                                      
                        if (verfiID == "ITR")
                        {
                            GenerateIdocItrFormat(strSelectedCaseID);
                        }
                        if (verfiID == "SC")
                        {
                            GenerateIdocSCFormat(strSelectedCaseID);
                        }
                        if (verfiID == "SalS")
                        {
                            GenerateIdocSSFormat(strSelectedCaseID);
                        }
                        if (verfiID == "BK")
                        {
                            GenerateIdocBSFormat(strSelectedCaseID);
                        }
                        if (verfiID == "F16")
                        {
                            GenerateIdocF16Format(strSelectedCaseID);
                        }
                        if (verfiID == "RC")
                        {
                            GenerateIdocRCFormat(strSelectedCaseID);
                        }

                    
                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //String[] verfiTY = (verfiID.TrimEnd(',')).Split(',');
                //GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID, verfiID);
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
            HiddenField hdnCaseID;
            HiddenField hdnVeriTy;
            System.Web.UI.WebControls.CheckBox chkCaseID;
            String strSelectedCaseID = "";
            String verfiID = "";
            foreach (GridViewRow row in gvOutput.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                hdnVeriTy = (HiddenField)row.FindControl("hidVeriType");
                chkCaseID = (System.Web.UI.WebControls.CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                {
                    //strSelectedCaseID = hdnCaseID.Value + ",";
                    strSelectedCaseID = hdnCaseID.Value;
                    verfiID = hdnVeriTy.Value;

                    if (verfiID == "ITR")
                    {
                        GenerateIdocItrFormat(strSelectedCaseID);
                    }
                    if (verfiID == "SC")
                    {
                        GenerateIdocSCFormat(strSelectedCaseID);
                    }
                    if (verfiID == "SalS")
                    {
                        GenerateIdocSSFormat(strSelectedCaseID);
                    }
                    if (verfiID == "BK")
                    {
                        GenerateIdocBSFormat(strSelectedCaseID);
                    }
                    if (verfiID == "F16")
                    {
                        GenerateIdocF16Format(strSelectedCaseID);
                    }
                    if (verfiID == "RC")
                    {
                        GenerateIdocRCFormat(strSelectedCaseID);
                    }


                }
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //String[] verfiTY = (verfiID.TrimEnd(',')).Split(',');
                //GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID, verfiID);
            }

            if (strSelectedCaseID != "")
            {
                String[] arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                //String[] veriTy = (verfiID.TrimEnd(',')).Split(',');
                //GetExport(ddlSelectFormat1.SelectedValue.ToString(), arrCaseID, verfiID);
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

    //public void GetExport(string strFormat, String[] arrCaseID,string veritype)
    //{
    //    if (ddlSelectFormat.SelectedValue.ToString() == "48" || ddlSelectFormat1.SelectedValue.ToString() == "48")
    //    {
    //       // string sVisitProof = veritype;
    //        //if (sVisitProof.Trim() != "")
    //        //{
    //        String[] arrsVisitProof = (veritype.TrimEnd(',')).Split(',');
    //        for (int i = 0;i<arrsVisitProof.Length;i++)
    //        {
    //            if (arrsVisitProof[i].ToString() == "ITR")
    //            {
    //                GenerateIdocItrFormat(arrCaseID);
    //            }
    //            if (arrsVisitProof[i].ToString() == "SC")
    //            {
    //                GenerateIdocSCFormat(arrCaseID);
    //            }
    //            if (arrsVisitProof[i].ToString() == "SalS")
    //            {
    //                GenerateIdocSSFormat(arrCaseID);
    //            }
    //            if (arrsVisitProof[i].ToString() == "BK")
    //            {
    //                GenerateIdocBSFormat(arrCaseID);
    //            }
    //            if (arrsVisitProof[i].ToString() == "F16")
    //            {
    //                GenerateIdocF16Format(arrCaseID);
    //            }
    //            if (arrsVisitProof[i].ToString() == "RC")
    //            {
    //                GenerateIdocRCFormat(arrCaseID);
    //            }
    //        }
    //        //}
        
            
    //        //GenerateIdocItrFormat(arrCaseID);
    //        //GenerateIdocSCFormat(arrCaseID);
    //        //GenerateIdocSSFormat(arrCaseID);
    //        //GenerateIdocF16Format(arrCaseID);
    //        //GenerateIdocBSFormat(arrCaseID);
    //        //GenerateIdocRCFormat(arrCaseID);
    //    }
    //    //else if (ddlSelectFormat.SelectedValue.ToString() == "8" || ddlSelectFormat1.SelectedValue.ToString() == "8")
    //    //    GenerateScbAcOpFormat(arrCaseID);

    //    else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
    //    {
    //        lblMsg.Visible = true;
    //        lblMsg.Text = "Please select format.";
    //        hplDownload.Visible = false;
    //        hplDownload.NavigateUrl = "";
    //    }
    //    gvOutput.DataBind();
    //}

    public void GenerateIdocSCFormat(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();

                System.Data.DataTable dtSalaryCertificate = new System.Data.DataTable();//---Salary Certificate
               
                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                    //---Added by kamal matekar

                    dtSalaryCertificate = objReport.getIDOCSalaryCertificate(arrCaseId.ToString());

                  
                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtSalaryCertificate);
                    dsStdOutput.Tables[1].TableName = "IDOC_SalaryCertificate";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Idoc_SC.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Idoc_SC.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
                //}

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString();
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
              
                dtCaseId.Clear();
                dtSalaryCertificate.Clear();

                dtCaseId.Dispose();
                dtSalaryCertificate.Dispose();

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
    public void GenerateIdocSSFormat(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();

                System.Data.DataTable dtSalarySlip = new System.Data.DataTable();//---Salary Slip

                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                dsStdOutput.Tables.Clear();
                dsStdOutput.Clear();
                string sRefNo = "";
                OleDbDataReader oledbRead;
                oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());
                if (oledbRead.Read())
                    sRefNo = oledbRead["Ref_No"].ToString();

                oledbRead.Close();
                dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                //---Added by kamal matekar

                dtSalarySlip = objReport.getIDOCSalarySlip(arrCaseId.ToString());

                dsStdOutput.Tables.Add(dtCaseId);
                dsStdOutput.Tables[0].TableName = "Main";

                dsStdOutput.Tables.Add(dtSalarySlip);
                dsStdOutput.Tables[1].TableName = "IDOC_SalarySlip";

                CrystalReportDocument myReportDocument;
                myReportDocument = new CrystalReportDocument();
                myReportDocument.Load(Server.MapPath("Idoc_SS.rpt"));
                myReportDocument.SetDataSource(dsStdOutput);

                Session["Path"] = Server.MapPath("Idoc_SS.rpt");
                myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                myReportDocument.Dispose();
                GC.Collect();


                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString();
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                dtCaseId.Clear();
                dtSalarySlip.Clear();

                dtCaseId.Dispose();
                dtSalarySlip.Dispose();

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
    //public void GenerateIdocItrFormat(string[] arrCaseId)
    public void GenerateIdocItrFormat(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();

                 System.Data.DataTable dtResiVerify = new System.Data.DataTable();//---ITR

                 //string strDate = DateTime.Now.ToString("ddMMMyyyy");

                 string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/" ;
                 string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
              
                   oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());

                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                    dtResiVerify = objReport.GetIdocIrtCase(arrCaseId.ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[1].TableName = "Idoc_ITR";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Idoc_ITR.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Idoc_ITR.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
              

                    myReportDocument.Dispose();
                    GC.Collect();
               

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
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
    public void GenerateIdocBSFormat(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();
                              
                System.Data.DataTable dtBS = new System.Data.DataTable();//---BS
               
                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                   dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                    dtBS = objReport.getIDOCBS(arrCaseId.ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtBS);
                    dsStdOutput.Tables[1].TableName = "IDOC_BankStat";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Idoc_BS.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Idoc_BS.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
               

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString();
                dtCaseId.Clear();
                dtBS.Clear();

                dtCaseId.Dispose();
                dtBS.Dispose();

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
    public void GenerateIdocF16Format(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();

                System.Data.DataTable dtForm16 = new System.Data.DataTable();//---Form 16

                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                    dtForm16 = objReport.getIDOCForm16(arrCaseId.ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtForm16);
                    dsStdOutput.Tables[1].TableName = "IDOC_Form16";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Idoc_F16.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Idoc_F16.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
              

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString();
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
              
                dtCaseId.Clear();
                dtForm16.Clear();

                dtCaseId.Dispose();
                dtForm16.Dispose();

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
    public void GenerateIdocRCFormat(string arrCaseId)
    {
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtCaseId = new System.Data.DataTable();

                System.Data.DataTable dtRC = new System.Data.DataTable();//---RC

                string strMapPath = Server.MapPath("../../ExportToUTI/IDOC/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhh");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdIdoc(arrCaseId.ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportIdoc(arrCaseId.ToString());

                    dtRC = objReport.getIDOCRC(arrCaseId.ToString());


                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtRC);
                    dsStdOutput.Tables[1].TableName = "IDOC_RC";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Idoc_RC.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Idoc_RC.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    myReportDocument.Dispose();
                    GC.Collect();
              
                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                //hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString();
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//IDOC//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
              
                dtCaseId.Clear();
                dtRC.Clear();

                dtCaseId.Dispose();
                dtRC.Dispose();

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
}
