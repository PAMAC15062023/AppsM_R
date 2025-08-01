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

public partial class CPV_KYC_KYC_QC_EXPORT : System.Web.UI.Page
{
    CCommon objCmn = new CCommon();
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

                string sSql = "SELECT Count(*) as TotalCount FROM [CPV_Qc_CASE_DETAILS] " +
                              "WHERE (([case_SEND_DATE] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (case_SEND_DATE >='" + FromDate + "' and case_SEND_DATE<'" + ToDate + "' ))";

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

    public void GetExport(string strFormat, String[] arrCaseID)
    {
        //if (ddlSelectFormat.SelectedValue.ToString() == "1" || ddlSelectFormat1.SelectedValue.ToString() == "1")
        //    GenerateExcelStandardFormat(arrCaseID);
        //else if (ddlSelectFormat.SelectedValue.ToString() == "3" || ddlSelectFormat1.SelectedValue.ToString() == "3")
        //    GenerateExcelBarclaysFormat(arrCaseID);
        //else if (ddlSelectFormat.SelectedValue.ToString() == "2" || ddlSelectFormat1.SelectedValue.ToString() == "2")
        //    GeneratePDF(arrCaseID);

        //else if (ddlSelectFormat.SelectedValue.ToString() == "4" || ddlSelectFormat1.SelectedValue.ToString() == "4")
        //    GenerateExcelSBIFormat(arrCaseID);

        if (ddlSelectFormat.SelectedValue.ToString() == "5" || ddlSelectFormat1.SelectedValue.ToString() == "5")
            GenerateHdfcLiabFormat(arrCaseID);

        else if (ddlSelectFormat.SelectedValue.ToString() == "8" || ddlSelectFormat1.SelectedValue.ToString() == "8")
            GenerateScbAcOpFormat(arrCaseID);

        else if (ddlSelectFormat.SelectedValue.ToString() == "13" || ddlSelectFormat1.SelectedValue.ToString() == "13")
            GenerateTCMFormat(arrCaseID);

        else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
        gvOutput.DataBind();
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
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc_Qc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKyc_Qc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResidenceVerificationDtlKyc_Qc(arrCaseId[i].ToString());

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
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

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
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc_Qc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusinessVerificationDtlKycTCM_Qc(arrCaseId[i].ToString());

                    dsStdOutput.Tables.Add(dtCaseId);
                    dsStdOutput.Tables[0].TableName = "Main";

                    dsStdOutput.Tables.Add(dtOfficeVerify);
                    dsStdOutput.Tables[1].TableName = "Kyc_tcm_Bv";

                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("Kyc_tcm_Export.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    Session["Path"] = Server.MapPath("Kyc_tcm_Export.rpt");
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

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
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseIdKyc_Qc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();

                    oledbRead.Close();
                    dtCaseId = objReport.GetCaseIdforReportKyc(arrCaseId[i].ToString());
                    dtOfficeVerify = objReport.GetBusiVeriDtlKycScbAcOp_Qc(arrCaseId[i].ToString());
                    dtResiVerify = objReport.GetResiVeriDtlKycScbAcOp_Qc(arrCaseId[i].ToString());
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
                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                    //myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat,"D:\\Santosh\\Source\\PMS_CPV\\Application\\ExportToUTI" + "//KYC//" + strDateTime + "/" + sRefNo + ".pdf");

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

    protected void gvOutput_PageIndexChanged(object sender, EventArgs e)
    {
        gvOutput.DataBind();
    }
    
    protected void gvOutput_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOutput.DataBind();
    }

    protected void gvOutput_DataBound(object sender, EventArgs e)
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
