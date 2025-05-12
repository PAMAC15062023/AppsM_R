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
using CrystalDecisions.ReportSource;


public partial class EBC_New_EBC_New_Export : System.Web.UI.Page
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
        //if (gvOutput.Rows.Count > 0)
        //{
        //    tbl.Visible = true;
        //}
        //else
        //{
        //    tbl.Visible = false;
        //}
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
            //modified by hemangi kambli on 21-Aug-2007 --------------------------
            //By Ashish...
            //if (txtToDate.Text.Trim() != "")
            //    ToDate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            //if (txtFromDate.Text.Trim() != "")
            //    FromDate = objCmn.strDate(txtFromDate.Text.Trim());

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
            //if (txtFromDate.Text != "")
            //{
            //    strDateCriteria = " AND convert(varchar,SEND_DATETIME,106)>='" + txtFromDate.Text.ToString().Trim() + "'";
            //}
            //if (txtToDate.Text != "")
            //{
            //    strDateCriteria = " AND convert(varchar,SEND_DATETIME,106)<'" + ToDate + "'";
            //}

            if (strCentreID != "" && strClientID != "")
            {
                string sSql = "SELECT Count(*) as TotalCount FROM [CPV_EBC_Case_details] " +
                              "WHERE (([SEND_DATETIME] IS NOT NULL) AND ([CENTRE_ID] = '" + strCentreID + "') AND ([CLIENT_ID] = '" + strClientID + "')and (SEND_DATETIME >='" + FromDate + "' and SEND_DATETIME<'" + ToDate + "' ))";

                OleDbDataReader oledbRead;
                oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
                if (oledbRead.Read() == true)
                    lblCaseCount.Text = "Number of cases : " + oledbRead["TotalCount"].ToString();

                //oledbRead.Close();

                gvOutput.DataBind();
                if (gvOutput.Rows.Count > 0)
                {
                    //lblCaseCount.Text = "Number of cases " + gvOutput.Rows.Count;
                    //pnlView.Visible = true;
                    tblCaseCount.Visible = true;
                    lblMsg.Visible = false;
                }
                else
                {
                    tblCaseCount.Visible = false;
                    lblCaseCount.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found.";
                    //pnlView.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while retreiving data: " + ex.Message;
        }
    }

    public string retYearMonth(string sField)
    {
        string sTmp = sField;
        string sYear = "";
        string sMonth = "";
        string sYrMth = "";

        if (sTmp.Trim() != "")
        {
            string[] arrYearMth = sTmp.Split('.');
            if (arrYearMth.Length > 0)
            {
                sYear = arrYearMth[0].ToString();
                if (sYear == "1")
                    sYrMth = sYear + " Year ";
                else if (sYear == "")
                    sYrMth += "";
                else
                    sYrMth = sYear + " Years ";

                if (arrYearMth.Length > 1)
                {
                    sMonth = arrYearMth[1].ToString();
                    if (sMonth == "1")
                        sYrMth += sMonth + " Month";
                    else if (sMonth == "")
                        sYrMth += "";
                    else
                        sYrMth += sMonth + " Months";

                }
                else
                    sYrMth += "";

            }
            else
            {
                sYrMth = "";
            }
        }
        else
            sYrMth = "";

        return sYrMth;
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
            tblCaseCount.Visible = true;
            System.Web.UI.WebControls.CheckBox cbHeader = ((System.Web.UI.WebControls.CheckBox)(gvOutput.HeaderRow.FindControl("HeaderLevelCheckBox")));
            cbHeader.Attributes["onclick"] = "ChangeAllCheckBoxStates(this.checked);";
            foreach (GridViewRow gvr in gvOutput.Rows)
            {
                // Get a programmatic reference to the CheckBox  
                System.Web.UI.WebControls.CheckBox cb = ((System.Web.UI.WebControls.CheckBox)(gvr.FindControl("chkCaseId")));
                ClientScript.RegisterArrayDeclaration("CheckBoxIDs", string.Concat("\'", cb.ClientID, "\'"));
            }
        }
    }

    public void GenerateEBC_NEW_Export(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();

                CReport objReport = new CReport();

                System.Data.DataTable dtSummaryDetails = new System.Data.DataTable();
                System.Data.DataTable dtSummaryDetails_Other = new System.Data.DataTable();
                System.Data.DataTable dtEducation_Verify = new System.Data.DataTable();
                System.Data.DataTable dtEducation_Verify_Img = new System.Data.DataTable();

                ////////////----For Sub details  of RV Current

                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify_Image = new System.Data.DataTable();

                //---Main Details 

                System.Data.DataTable dtOther_ResiDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails = new System.Data.DataTable();

                //---Current
                System.Data.DataTable dtOther_ResiDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_CurrentAddress = new System.Data.DataTable();

                ////------For Sub details  of RV Earlier
                System.Data.DataTable dtOther_ResiDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_Ear = new System.Data.DataTable();


                ///----For Permanant Address
                System.Data.DataTable dtOther_ResiDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_Permant = new System.Data.DataTable();

                ////---
                System.Data.DataTable dtReferenceCheck = new System.Data.DataTable();
                System.Data.DataTable dtReferenceCheck_Image = new System.Data.DataTable();

                System.Data.DataTable dtCreditCheck = new System.Data.DataTable();
                System.Data.DataTable dtCreditCheck_Image = new System.Data.DataTable();

                System.Data.DataTable dtEmployment = new System.Data.DataTable();
                System.Data.DataTable dtEmployment_Img = new System.Data.DataTable();

                System.Data.DataTable dtCriminalVerification = new System.Data.DataTable();
                System.Data.DataTable dtCriminalVerification_Image = new System.Data.DataTable();

                System.Data.DataTable dtCourtLitigation = new System.Data.DataTable();
                System.Data.DataTable dtCourtLitigation_Image = new System.Data.DataTable();

                System.Data.DataTable dtPassportVerification = new System.Data.DataTable();
                System.Data.DataTable dtPancardVerification = new System.Data.DataTable();
                System.Data.DataTable dtVoterIDVerification = new System.Data.DataTable();
                System.Data.DataTable dtDrivingLicenceVerification= new System.Data.DataTable();
                System.Data.DataTable dtGlobalDatabaseSearch = new System.Data.DataTable();


                //--Added by manoj


                string strMapPath = Server.MapPath("../../ExportToUTI/EBC_New/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string CaseID = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseId_Ebc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    CaseID = oledbRead["Case_ID"].ToString();

                    //--sRefNo = sRefNo.Replace("\\", "_");

                    oledbRead.Close();

                    dtSummaryDetails = objReport.Get_EBC_NEW_Details_Summary(arrCaseId[i].ToString());
                    dtSummaryDetails_Other = objReport.Get_EBC_NEW_Details_Summary_Other(arrCaseId[i].ToString());

                    dtResiVerify = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportResiAddressVeri");
                    dtResiVerify_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ResiAddressVeri_Image");


                    if (dtResiVerify.Rows.Count != 0)
                    {
                        int SubVerificationID;

                        for (int j = 0; j < dtResiVerify.Rows.Count; j++)
                        {

                            SubVerificationID = Convert.ToInt32(dtResiVerify.Rows[j]["Sub_Verification_Type_ID"].ToString().Trim());

                            if (SubVerificationID == 1)
                            {
                                dtOther_ResiDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");

                            }
                            else if (SubVerificationID == 2)
                            {
                                dtOther_ResiDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");

                            }
                            else if (SubVerificationID == 3)
                            {
                                dtOther_ResiDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");
                            }
                        }

                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_CurrentAddress);
                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_Ear);
                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_Permant);

                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_CurrentAddress);
                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_Ear);
                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_Permant);

                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_CurrentAddress);
                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_Ear);
                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_Permant);

                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_CurrentAddress);
                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_Ear);
                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_Permant);
                    }

                    dtEducation_Verify = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "EBC_Educational_Report_Details");
                    dtEducation_Verify_Img = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Employment_Image");

                    dtEmployment = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportEmploymentVeri");
                    dtEmployment_Img = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_EmploymentVeri_Image");

                    dtCreditCheck = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCreditCheck");
                    dtCreditCheck_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Credit_Check_Veri_Image");

                    dtCriminalVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCriminalVeri");
                    dtCriminalVerification_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_CriminalVerification_Image");

                    dtCourtLitigation = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCourtLitigation");
                    dtCourtLitigation_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Court_Litigation_Image");

                    dtReferenceCheck = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportReferenceCheck");
                    dtReferenceCheck_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ReferenceCheck_Veri_Image");
                    
                    //NIKHIL
                    
                    dtPassportVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportPassportveri");

                    dtPancardVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportPancardVerification");

                    dtVoterIDVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportVoterIDVerification");

                    dtDrivingLicenceVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_DrivingLicenseVerification");

                    dtGlobalDatabaseSearch = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportGlobalDatabaseSearch"); 
                    
                    dsStdOutput.Tables.Add(dtSummaryDetails);
                    dsStdOutput.Tables[0].TableName = "EBC_SummaryDetails";

                    dsStdOutput.Tables.Add(dtSummaryDetails_Other);
                    dsStdOutput.Tables[1].TableName = "EBC_SummaryDetails_Other";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[2].TableName = "ResiAddress_Verification";

                    dsStdOutput.Tables.Add(dtResiVerify_Image);
                    dsStdOutput.Tables[3].TableName = "Residence_Verification_Img1";

                    dsStdOutput.Tables.Add(dtOther_ResiDetails);
                    dsStdOutput.Tables[4].TableName = "Other_ResiDetails";

                    dsStdOutput.Tables.Add(dtOther_AgriculturalDetails);
                    dsStdOutput.Tables[5].TableName = "Other_AgriculturalDetails";

                    dsStdOutput.Tables.Add(dtOther_HousingDetails);
                    dsStdOutput.Tables[6].TableName = "Other_HousingDetails";

                    dsStdOutput.Tables.Add(dtOther_PropertyDetails);
                    dsStdOutput.Tables[7].TableName = "Other_PropertyDetails";

                    dsStdOutput.Tables.Add(dtEducation_Verify);
                    dsStdOutput.Tables[8].TableName = "Education_Details";

                    dsStdOutput.Tables.Add(dtEducation_Verify_Img);
                    dsStdOutput.Tables[9].TableName = "Education_Details_Img";

                    dsStdOutput.Tables.Add(dtEmployment);
                    dsStdOutput.Tables[10].TableName = "Employment_Verification";

                    dsStdOutput.Tables.Add(dtEmployment_Img);
                    dsStdOutput.Tables[11].TableName = "Employment_Details_Img1";

                    dsStdOutput.Tables.Add(dtCreditCheck);
                    dsStdOutput.Tables[12].TableName = "CreditCheck_Verification";

                    dsStdOutput.Tables.Add(dtCreditCheck_Image);
                    dsStdOutput.Tables[13].TableName = "Credit_Check_Img";

                    dsStdOutput.Tables.Add(dtCriminalVerification);
                    dsStdOutput.Tables[14].TableName = "Criminal_Verification";


                    dsStdOutput.Tables.Add(dtCriminalVerification_Image);
                    dsStdOutput.Tables[15].TableName = "Criminal_Verification_Img1";


                    dsStdOutput.Tables.Add(dtCourtLitigation_Image);
                    dsStdOutput.Tables[16].TableName = "Court_Verification_Img";


                    dsStdOutput.Tables.Add(dtCourtLitigation);
                    dsStdOutput.Tables[17].TableName = "Court_Verification";

                    dsStdOutput.Tables.Add(dtReferenceCheck);
                    dsStdOutput.Tables[18].TableName = "ReferenceCheck_Verification";               

                    dsStdOutput.Tables.Add(dtReferenceCheck_Image);
                    dsStdOutput.Tables[19].TableName = "Reference_Check_Img";

                    dsStdOutput.Tables.Add(dtPassportVerification);
                    dsStdOutput.Tables[20].TableName="Passport_Verification";

                    dsStdOutput.Tables.Add(dtPancardVerification);
                    dsStdOutput.Tables[21].TableName="Pancard_Verification";

                    dsStdOutput.Tables.Add(dtVoterIDVerification);
                    dsStdOutput.Tables[22].TableName = "VoterID_Verification";

                     dsStdOutput.Tables.Add(dtDrivingLicenceVerification);
                     dsStdOutput.Tables[23].TableName="DrivingLicence_Verification";

                    dsStdOutput.Tables.Add(dtGlobalDatabaseSearch);
                    dsStdOutput.Tables[24].TableName="GlobalDatabaseSearch";


                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("CrystalReport.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    //---------------
                    ////////////ExportOptions CrExportOptions;
                    ////////////DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    ////////////PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    ////////////CrDiskFileDestinationOptions.DiskFileName = "c:\\"+ sRefNo +".pdf";
                    ////////////CrExportOptions = myReportDocument.ExportOptions;
                    ////////////{
                    ////////////    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    ////////////    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    ////////////    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    ////////////    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    ////////////}
                    ////////////myReportDocument.Export();

                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC_New//" + Session["UserName"].ToString() + "//" + strDateTime + "//";

                dtEducation_Verify.Clear();
                dtResiVerify.Clear();
                dtReferenceCheck.Clear();
                dtCreditCheck.Clear();
                dtEmployment.Clear();
                dtCriminalVerification.Clear();
                dtCourtLitigation.Clear();
                dtEducation_Verify_Img.Clear();
                dtEmployment_Img.Clear();
                dtReferenceCheck_Image.Clear();
                dtCreditCheck_Image.Clear();
                dtCriminalVerification_Image.Clear();
                dtCourtLitigation_Image.Clear();
                dtResiVerify_Image.Clear();
                dtSummaryDetails.Clear();
                dtSummaryDetails_Other.Clear();

                dtOther_ResiDetails_Ear.Clear();
                dtOther_AgriculturalDetails_Ear.Clear();
                dtOther_HousingDetails_Ear.Clear();
                dtOther_PropertyDetails_Ear.Clear();

                dtOther_ResiDetails_Permant.Clear();
                dtOther_AgriculturalDetails_Permant.Clear();
                dtOther_HousingDetails_Permant.Clear();
                dtOther_PropertyDetails_Permant.Clear();

                dtOther_ResiDetails.Clear();
                dtOther_AgriculturalDetails.Clear();
                dtOther_HousingDetails.Clear();
                dtOther_PropertyDetails.Clear();

                dtPassportVerification.Clear();
                dtPancardVerification.Clear();
                dtVoterIDVerification.Clear();
                dtDrivingLicenceVerification.Clear();
                dtGlobalDatabaseSearch.Clear();

                dtEducation_Verify.Dispose();
                dtResiVerify.Dispose();
                dtReferenceCheck.Dispose();
                dtCreditCheck.Dispose();
                dtEmployment.Dispose();
                dtCriminalVerification.Dispose();
                dtCourtLitigation.Dispose();

                dtEducation_Verify_Img.Dispose();
                dtEmployment_Img.Dispose();
                dtReferenceCheck_Image.Dispose();
                dtCreditCheck_Image.Dispose();
                dtCriminalVerification_Image.Dispose();
                dtCourtLitigation_Image.Dispose();
                dtResiVerify_Image.Dispose();

                dtOther_ResiDetails_Ear.Dispose();
                dtOther_AgriculturalDetails_Ear.Dispose();
                dtOther_HousingDetails_Ear.Dispose();
                dtOther_PropertyDetails_Ear.Dispose();

                dtOther_ResiDetails_Permant.Dispose();
                dtOther_AgriculturalDetails_Permant.Dispose();
                dtOther_HousingDetails_Permant.Dispose();
                dtOther_PropertyDetails_Permant.Dispose();

                dtOther_ResiDetails.Dispose();
                dtOther_AgriculturalDetails.Dispose();
                dtOther_HousingDetails.Dispose();
                dtOther_PropertyDetails.Dispose();

                dtOther_ResiDetails_CurrentAddress.Dispose();
                dtOther_AgriculturalDetails_CurrentAddress.Dispose();
                dtOther_HousingDetails_CurrentAddress.Dispose();
                dtOther_PropertyDetails_CurrentAddress.Dispose();

                dtPassportVerification.Dispose();
                dtPancardVerification.Dispose();
                dtVoterIDVerification.Dispose();
                dtDrivingLicenceVerification.Dispose();
                dtGlobalDatabaseSearch.Dispose();

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

    public void GenerateBasix_Export(string[] arrCaseId)
    {
        int iCount = 0;
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();

                CReport objReport = new CReport();

                System.Data.DataTable dtSummaryDetails = new System.Data.DataTable();
                System.Data.DataTable dtSummaryDetails_Other = new System.Data.DataTable();
                System.Data.DataTable dtEducation_Verify = new System.Data.DataTable();
                System.Data.DataTable dtEducation_Verify_Img = new System.Data.DataTable();

                ////////////----For Sub details  of RV Current

                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                System.Data.DataTable dtResiVerify_Image = new System.Data.DataTable();

                //---Main Details 

                System.Data.DataTable dtOther_ResiDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails = new System.Data.DataTable();

                //---Current
                System.Data.DataTable dtOther_ResiDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_CurrentAddress = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_CurrentAddress = new System.Data.DataTable();

                ////------For Sub details  of RV Earlier
                System.Data.DataTable dtOther_ResiDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_Ear = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_Ear = new System.Data.DataTable();


                ///----For Permanant Address
                System.Data.DataTable dtOther_ResiDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_AgriculturalDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_HousingDetails_Permant = new System.Data.DataTable();
                System.Data.DataTable dtOther_PropertyDetails_Permant = new System.Data.DataTable();

                ////---
                System.Data.DataTable dtReferenceCheck = new System.Data.DataTable();
                System.Data.DataTable dtReferenceCheck_Image = new System.Data.DataTable();

                System.Data.DataTable dtCreditCheck = new System.Data.DataTable();
                System.Data.DataTable dtCreditCheck_Image = new System.Data.DataTable();

                System.Data.DataTable dtEmployment = new System.Data.DataTable();
                System.Data.DataTable dtEmployment_Img = new System.Data.DataTable();

                System.Data.DataTable dtCriminalVerification = new System.Data.DataTable();
                System.Data.DataTable dtCriminalVerification_Image = new System.Data.DataTable();

                System.Data.DataTable dtCourtLitigation = new System.Data.DataTable();
                System.Data.DataTable dtCourtLitigation_Image = new System.Data.DataTable();

                string strMapPath = Server.MapPath("../../ExportToUTI/EBC_New/") + Session["UserName"].ToString() + "/";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();
                    string sRefNo = "";
                    string CaseID = "";
                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseId_Ebc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    CaseID = oledbRead["Case_ID"].ToString();

                    //--sRefNo = sRefNo.Replace("\\", "_");

                    oledbRead.Close();

                    dtSummaryDetails = objReport.Get_EBC_NEW_Details_Summary(arrCaseId[i].ToString());
                    dtSummaryDetails_Other = objReport.Get_EBC_NEW_Details_Summary_Other(arrCaseId[i].ToString());

                    dtResiVerify = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportResiAddressVeri");
                    dtResiVerify_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ResiAddressVeri_Image");


                    if (dtResiVerify.Rows.Count != 0)
                    {
                        int SubVerificationID;

                        for (int j = 0; j < dtResiVerify.Rows.Count; j++)
                        {

                            SubVerificationID = Convert.ToInt32(dtResiVerify.Rows[j]["Sub_Verification_Type_ID"].ToString().Trim());

                            if (SubVerificationID == 1)
                            {
                                dtOther_ResiDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_CurrentAddress = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");

                            }
                            else if (SubVerificationID == 2)
                            {
                                dtOther_ResiDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_Ear = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");

                            }
                            else if (SubVerificationID == 3)
                            {
                                dtOther_ResiDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 1, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_AgriculturalDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 2, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_HousingDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 3, SubVerificationID, "Get_OtherDetails_ForReport");
                                dtOther_PropertyDetails_Permant = objReport.Get_EBC_Other_Details_For_RV(arrCaseId[i].ToString(), 43, 4, SubVerificationID, "Get_OtherDetails_ForReport");
                            }
                        }

                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_CurrentAddress);
                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_Ear);
                        dtOther_ResiDetails.Merge(dtOther_ResiDetails_Permant);

                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_CurrentAddress);
                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_Ear);
                        dtOther_AgriculturalDetails.Merge(dtOther_AgriculturalDetails_Permant);

                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_CurrentAddress);
                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_Ear);
                        dtOther_HousingDetails.Merge(dtOther_HousingDetails_Permant);

                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_CurrentAddress);
                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_Ear);
                        dtOther_PropertyDetails.Merge(dtOther_PropertyDetails_Permant);
                    }

                    dtEducation_Verify = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "EBC_Educational_Report_Details");
                    dtEducation_Verify_Img = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Employment_Image");

                    dtEmployment = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportEmploymentVeri");
                    dtEmployment_Img = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_EmploymentVeri_Image");

                    dtCreditCheck = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCreditCheck");
                    dtCreditCheck_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Credit_Check_Veri_Image");

                    dtCriminalVerification = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCriminalVeri");
                    dtCriminalVerification_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_CriminalVerification_Image");

                    dtCourtLitigation = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportCourtLitigation");
                    dtCourtLitigation_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_Court_Litigation_Image");

                    dtReferenceCheck = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ExportReferenceCheck");
                    dtReferenceCheck_Image = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_ReferenceCheck_Veri_Image");

                    dsStdOutput.Tables.Add(dtSummaryDetails);
                    dsStdOutput.Tables[0].TableName = "EBC_SummaryDetails";

                    dsStdOutput.Tables.Add(dtSummaryDetails_Other);
                    dsStdOutput.Tables[1].TableName = "EBC_SummaryDetails_Other";

                    dsStdOutput.Tables.Add(dtEducation_Verify);
                    dsStdOutput.Tables[2].TableName = "Education_Details";

                    dsStdOutput.Tables.Add(dtEmployment);
                    dsStdOutput.Tables[3].TableName = "Employment_Verification";

                    dsStdOutput.Tables.Add(dtCreditCheck);
                    dsStdOutput.Tables[4].TableName = "CreditCheck_Verification";

                    dsStdOutput.Tables.Add(dtCriminalVerification);
                    dsStdOutput.Tables[5].TableName = "Criminal_Verification";

                    dsStdOutput.Tables.Add(dtCourtLitigation);
                    dsStdOutput.Tables[6].TableName = "Court_Verification";

                    dsStdOutput.Tables.Add(dtReferenceCheck);
                    dsStdOutput.Tables[7].TableName = "ReferenceCheck_Verification";

                    dsStdOutput.Tables.Add(dtEducation_Verify_Img);
                    dsStdOutput.Tables[8].TableName = "Education_Details_Img";

                    dsStdOutput.Tables.Add(dtEmployment_Img);
                    dsStdOutput.Tables[9].TableName = "Employment_Details_Img1";

                    dsStdOutput.Tables.Add(dtReferenceCheck_Image);
                    dsStdOutput.Tables[10].TableName = "Reference_Check_Img";

                    dsStdOutput.Tables.Add(dtCreditCheck_Image);
                    dsStdOutput.Tables[11].TableName = "Credit_Check_Img";

                    dsStdOutput.Tables.Add(dtCriminalVerification_Image);
                    dsStdOutput.Tables[12].TableName = "Criminal_Verification_Img1";

                    dsStdOutput.Tables.Add(dtCourtLitigation_Image);
                    dsStdOutput.Tables[13].TableName = "Court_Verification_Img";

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[14].TableName = "ResiAddress_Verification";

                    dsStdOutput.Tables.Add(dtResiVerify_Image);
                    dsStdOutput.Tables[15].TableName = "Residence_Verification_Img1";

                    dsStdOutput.Tables.Add(dtOther_ResiDetails);
                    dsStdOutput.Tables[16].TableName = "Other_ResiDetails";

                    dsStdOutput.Tables.Add(dtOther_AgriculturalDetails);
                    dsStdOutput.Tables[17].TableName = "Other_AgriculturalDetails";

                    dsStdOutput.Tables.Add(dtOther_HousingDetails);
                    dsStdOutput.Tables[18].TableName = "Other_HousingDetails";

                    dsStdOutput.Tables.Add(dtOther_PropertyDetails);
                    dsStdOutput.Tables[19].TableName = "Other_PropertyDetails";


                    CrystalReportDocument myReportDocument;
                    myReportDocument = new CrystalReportDocument();
                    myReportDocument.Load(Server.MapPath("EBC_BasixReport.rpt"));
                    myReportDocument.SetDataSource(dsStdOutput);

                    myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");

                    //---------------
                    //////ExportOptions CrExportOptions;
                    //////DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    //////PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    //////CrDiskFileDestinationOptions.DiskFileName = "c:\\" + sRefNo + ".pdf";
                    //////CrExportOptions = myReportDocument.ExportOptions;
                    //////{
                    //////    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    //////    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    //////    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    //////    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    //////}
                    //////myReportDocument.Export();

                    //string popupScript = "<script language='javascript'>" + "window.open('c:\\EBCNewReport.pdf');</script>";

                    myReportDocument.Dispose();
                    GC.Collect();
                }

                lblMsg.Visible = true;
                lblMsg.Text = "Export Completed successfully.";
                hplDownload.Visible = true;
                hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC_New//" + Session["UserName"].ToString() + "//" + strDateTime + "//";

                dtEducation_Verify.Clear();
                dtResiVerify.Clear();
                dtReferenceCheck.Clear();
                dtCreditCheck.Clear();
                dtEmployment.Clear();
                dtCriminalVerification.Clear();
                dtCourtLitigation.Clear();
                dtEducation_Verify_Img.Clear();
                dtEmployment_Img.Clear();
                dtReferenceCheck_Image.Clear();
                dtCreditCheck_Image.Clear();
                dtCriminalVerification_Image.Clear();
                dtCourtLitigation_Image.Clear();
                dtResiVerify_Image.Clear();
                dtSummaryDetails.Clear();
                dtSummaryDetails_Other.Clear();

                dtOther_ResiDetails_Ear.Clear();
                dtOther_AgriculturalDetails_Ear.Clear();
                dtOther_HousingDetails_Ear.Clear();
                dtOther_PropertyDetails_Ear.Clear();

                dtOther_ResiDetails_Permant.Clear();
                dtOther_AgriculturalDetails_Permant.Clear();
                dtOther_HousingDetails_Permant.Clear();
                dtOther_PropertyDetails_Permant.Clear();

                dtOther_ResiDetails.Clear();
                dtOther_AgriculturalDetails.Clear();
                dtOther_HousingDetails.Clear();
                dtOther_PropertyDetails.Clear();

                dtEducation_Verify.Dispose();
                dtResiVerify.Dispose();
                dtReferenceCheck.Dispose();
                dtCreditCheck.Dispose();
                dtEmployment.Dispose();
                dtCriminalVerification.Dispose();
                dtCourtLitigation.Dispose();

                dtEducation_Verify_Img.Dispose();
                dtEmployment_Img.Dispose();
                dtReferenceCheck_Image.Dispose();
                dtCreditCheck_Image.Dispose();
                dtCriminalVerification_Image.Dispose();
                dtCourtLitigation_Image.Dispose();
                dtResiVerify_Image.Dispose();

                dtOther_ResiDetails_Ear.Dispose();
                dtOther_AgriculturalDetails_Ear.Dispose();
                dtOther_HousingDetails_Ear.Dispose();
                dtOther_PropertyDetails_Ear.Dispose();

                dtOther_ResiDetails_Permant.Dispose();
                dtOther_AgriculturalDetails_Permant.Dispose();
                dtOther_HousingDetails_Permant.Dispose();
                dtOther_PropertyDetails_Permant.Dispose();

                dtOther_ResiDetails.Dispose();
                dtOther_AgriculturalDetails.Dispose();
                dtOther_HousingDetails.Dispose();
                dtOther_PropertyDetails.Dispose();

                dtOther_ResiDetails_CurrentAddress.Dispose();
                dtOther_AgriculturalDetails_CurrentAddress.Dispose();
                dtOther_HousingDetails_CurrentAddress.Dispose();
                dtOther_PropertyDetails_CurrentAddress.Dispose();

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
    //----Added by Manoj Jadhav for PAmac Resistance
    public void GenerateResFormat_Export(string[] arrCaseId)
    {
        int iCount = 0;
        string sRefNo = "";
        string CaseID = "";
        string strDateTime = "";
        try
        {
            if (arrCaseId.Length > 0)
            {
                DataSet dsStdOutput = new DataSet();
                CReport objReport = new CReport();
                System.Data.DataTable dtResiVerify = new System.Data.DataTable();
                string strMapPath = Server.MapPath("../../ExportToUTI/EBC_New/") + Session["UserName"].ToString() + "/";
                strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (!Directory.Exists(strMapPath + strDateTime))
                    Directory.CreateDirectory(strMapPath + strDateTime);

                for (int i = 0; i < arrCaseId.Length; i++)
                {
                    dsStdOutput.Tables.Clear();
                    dsStdOutput.Clear();

                    OleDbDataReader oledbRead;
                    oledbRead = objReport.GetRefNoByCaseId_Ebc(arrCaseId[i].ToString());
                    if (oledbRead.Read())
                        sRefNo = oledbRead["Ref_No"].ToString();
                    CaseID = oledbRead["Case_ID"].ToString();
                    oledbRead.Close();
                    dtResiVerify = objReport.Get_EBC_NEW_Details(arrCaseId[i].ToString(), "Get_PamacResistanceVeri");

                    dsStdOutput.Tables.Add(dtResiVerify);
                    dsStdOutput.Tables[0].TableName = "PamacResSearch";
                }
                CrystalReportDocument myReportDocument;
                myReportDocument = new CrystalReportDocument();
                myReportDocument.Load(Server.MapPath("EmplResistVerification.rpt"));
                myReportDocument.SetDataSource(dsStdOutput);
                myReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, strMapPath + strDateTime + "/" + sRefNo + ".pdf");
                myReportDocument.Dispose();
                GC.Collect();
            }

            lblMsg.Visible = true;
            lblMsg.Text = "Export Completed successfully.";
            hplDownload.Visible = true;
            hplDownload.NavigateUrl = ConfigurationManager.AppSettings["FtpPath"] + "//EBC_New//" + Session["UserName"].ToString() + "//" + strDateTime + "//";
        }

        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.Text = exp.Message;
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
    }
    //-------Ended by MAnoj
    public void GetExport(string strFormat, String[] arrCaseID)
    {
        if (ddlSelectFormat.SelectedValue.ToString() == "44" || ddlSelectFormat1.SelectedValue.ToString() == "44")
            GenerateEBC_NEW_Export(arrCaseID);

        if (ddlSelectFormat.SelectedValue.ToString() == "45" || ddlSelectFormat1.SelectedValue.ToString() == "45")
            GenerateBasix_Export(arrCaseID);

        if (ddlSelectFormat.SelectedValue.ToString() == "60" || ddlSelectFormat1.SelectedValue.ToString() == "60")
            GenerateResFormat_Export(arrCaseID);

        else if (ddlSelectFormat.SelectedValue.ToString() == "0" && ddlSelectFormat1.SelectedValue.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
            hplDownload.Visible = false;
            hplDownload.NavigateUrl = "";
        }
        gvOutput.DataBind();
    }

    public void btnExport_Click(object sender, EventArgs e)
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

                //lblMsg.Visible = true;
                //lblMsg.Text = "Export completed successfully.";
                //hplDownload.Visible = true;                
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

    public void btnExport1_Click(object sender, EventArgs e)
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
                //lblMsg.Visible = true;
                //lblMsg.Text = "Export completed successfully.";
                //hplDownload.Visible = true;
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

    protected void cvSelectFormat_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select format.";
        }
    }

    //protected void ddlSelectFormat_DataBound(object sender, EventArgs e)
    //{
    //    ddlSelectFormat.Items.Insert(0, new ListItem("Select", "0"));
    //}
    protected void gvOutput_PageIndexChanged(object sender, EventArgs e)
    {
        gvOutput.DataBind();
    }

    protected void gvOutput_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOutput.DataBind();
    }
    
}
