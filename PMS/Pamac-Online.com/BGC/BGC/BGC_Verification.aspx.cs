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

public partial class BGC_BGC_BGC_Verification : System.Web.UI.Page
{
   // EBC_Verification objEBC = new EBC_Verification();
    BGC objEBC = new BGC();

    DataTable dt = new DataTable();
    int j = 0;
    bool boolAdd = true;
    ////OleDbDataReader oledbReadEBC;
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();

        SdsStatus.ConnectionString = objConn.ConnectionString;  //Sir


        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');

        //add by kanchan new
        if (ddlErrorLog.SelectedIndex == 0)
        {
        txtAccessbility.Enabled = false;
        }

        //----comp---//

        foreach (string str in strRole1)
        {
            if (!IsPostBack)
            {
                if (str == "2")
                {
                    lblAccessblity.Visible = true;
                    ddlErrorLog.Visible = true;
                    txtAccessbility.Visible = true;

                }
            }
        }


        if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
        {

            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            string sCaseId = Request.QueryString["CaseID"].ToString();

            Session["CaseID"] = Request.QueryString["CaseID"].ToString();

            hidCaseID.Value = sCaseId;

            if ((Request.QueryString["VerTypeId"] != null) && (Request.QueryString["VerTypeId"] != ""))
            {
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
            }
            if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
            {
                hidMode.Value = Request.QueryString["Mode"].ToString();
            }
            if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
            {
                hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
            }


            string VerificationID = objEBC.GetVerificationTypeID1(sCaseId);
            if ((VerificationID == "1") || (hidVerificationTypeID.Value == "RV"))
            {
                lblHead.Text = "Residence Verification";
            }
            if ((VerificationID == "15") || (hidVerificationTypeID.Value == "PV"))
            {
                lblHead.Text = "Police Verification";
            }
            if ((VerificationID == "16") || (hidVerificationTypeID.Value == "DGV"))
            {
                lblHead.Text = "Degree Verification";
            }
            if ((VerificationID == "17") || (hidVerificationTypeID.Value == "GV"))
            {
                lblHead.Text = "GAP Verification";
            }
            if ((VerificationID == "18") || (hidVerificationTypeID.Value == "EV"))
            {
                lblHead.Text = "Employment Verification";
            }
            if (!IsPostBack)
            {


                DataSet ds = new DataSet();
                ds = objEBC.GetEBCDetail(sCaseId);


                DataSet ds1 = new DataSet();
                ds1 = objEBC.GetCASEDetail(sCaseId);


                DataSet ds2 = new DataSet();
                ds2 = objEBC.GetFEName(sCaseId);


                if (ds2.Tables[0].Rows.Count > 0)
                {
                    txtVerificatorName.Text = ds2.Tables[0].Rows[0]["FullName"].ToString();
                }
                ////if (oledbCaseDtl.Read() == true)
                ////{


                if(ds1.Tables[0].Rows.Count>0)
                {
                    //for ref no
                    //txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtLanNo.Text = ds1.Tables[0].Rows[0]["REF_NO"].ToString();
                    //for CASE_REC_DATETIME
                    //txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtDateAndTime.Text = ds1.Tables[0].Rows[0]["CASE_REC_DATETIME"].ToString();

                    //for employee name
                    //txtEmpName.Text = oledbCaseDtl["NAME"].ToString();
                    txtEmpName.Text = ds1.Tables[0].Rows[0]["NAME"].ToString();

                    //not in use address
                    //txtAddress.Text = oledbCaseDtl["Address"].ToString();
                    txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();


                    //not in use address
                    //txtEmpECN.Text = oledbCaseDtl["Emp_code"].ToString();
                    txtEmpECN.Text = ds1.Tables[0].Rows[0]["Emp_code"].ToString();

                    //txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtDateAndTime.Text = ds1.Tables[0].Rows[0]["CASE_REC_DATETIME"].ToString();

                    //not in use
                    //txtDOB.Text = oledbCaseDtl["DOB"].ToString();
                    txtDOB.Text = ds1.Tables[0].Rows[0]["DOB"].ToString();

                }
                //if (oledbReadEBC.Read() == true)
                //{

                if(ds.Tables[0].Rows.Count>0)
                {
                   
                    //string sTmpDate = oledbReadEBC["VERIFICATION_DATETIME"].ToString();
                    string sTmpDate = ds.Tables[0].Rows[0]["VERIFICATION_DATETIME"].ToString();
                    if (sTmpDate != "")
                    {
                        string[] arrVerDateTime = sTmpDate.Split(' ');
                        if (arrVerDateTime[0].ToString() != "")
                            txtDateOfVerification.Text = arrVerDateTime[0].ToString();
                        if (arrVerDateTime[1].ToString() != "")
                            txtTimeOfVerification.Text = arrVerDateTime[1].ToString();
                        if (arrVerDateTime[2].ToString() != "")
                            ddlDateTimeOfVerification.SelectedValue = arrVerDateTime[2].ToString();
                    }



                    //not in use
                    //txtNameofPersonContacted.Text = oledbReadEBC["Contact_person"].ToString();
                    txtNameofPersonContacted.Text = ds.Tables[0].Rows[0]["Contact_person"].ToString();

                    //not in use
                    //txtRespondentDesignation.Text = oledbReadEBC["Contact_person_designation"].ToString();
                    txtRespondentDesignation.Text = ds.Tables[0].Rows[0]["Contact_person_designation"].ToString();

                    //not in use
                   // txtInstitutionName.Text = oledbReadEBC["Institute_name"].ToString();
                    txtInstitutionName.Text = ds.Tables[0].Rows[0]["Institute_name"].ToString();
 
                    //not in use
                    //txtEmpDates.Text = oledbReadEBC["Employment_Date"].ToString();
                    txtEmpDates.Text = ds.Tables[0].Rows[0]["Employment_Date"].ToString();
 
                    //for Report Sent date
                    //txtDatesdAttended.Text = oledbReadEBC["Date_attend"].ToString();
                    txtDatesdAttended.Text = ds.Tables[0].Rows[0]["Date_attend"].ToString();
 
                    //not in use
                    //txtQualificationGained.Text = oledbReadEBC["Qulaification_gained"].ToString();
                    txtQualificationGained.Text = ds.Tables[0].Rows[0]["Qulaification_gained"].ToString();

                    //not in use
                    //txtOrganisationName.Text = oledbReadEBC["Organization_name"].ToString();
                    txtOrganisationName.Text = ds.Tables[0].Rows[0]["Organization_name"].ToString();


                    //not in use
                    //txtLastPosition.Text = oledbReadEBC["Last_Position_Held"].ToString();
                    txtLastPosition.Text = ds.Tables[0].Rows[0]["Last_Position_Held"].ToString();

                    //not in use
                    //txtReportingManager.Text = oledbReadEBC["Reporting_Manager"].ToString();
                    txtReportingManager.Text = ds.Tables[0].Rows[0]["Reporting_Manager"].ToString();

                    //for family members
                    //txtGapIdentified.Text = oledbReadEBC["Gap_Identified"].ToString();
                    txtGapIdentified.Text = ds.Tables[0].Rows[0]["Gap_Identified"].ToString();

                    //for OCL and icl
                    //ddlOCL.SelectedValue = oledbReadEBC["Period_Of_Gap"].ToString();
                    ddlOCL.SelectedValue = ds.Tables[0].Rows[0]["Period_Of_Gap"].ToString();

                    //not in use
                    //txtReasonOfGap.Text = oledbReadEBC["Reason_Of_Gap"].ToString();
                    txtReasonOfGap.Text = ds.Tables[0].Rows[0]["Reason_Of_Gap"].ToString();


                    //txtAddressDuringGap.Text = oledbReadEBC["Address_Gap"].ToString();
                    txtAddressDuringGap.Text = ds.Tables[0].Rows[0]["Address_Gap"].ToString();

                    //txtpoliceVerification.Text = oledbReadEBC["Police_Verification"].ToString();
                    txtpoliceVerification.Text = ds.Tables[0].Rows[0]["Police_Verification"].ToString();

                    //txtPoliceVerificationGap.Text = oledbReadEBC["Police_Verification_GAP"].ToString();
                    txtPoliceVerificationGap.Text = ds.Tables[0].Rows[0]["Police_Verification_GAP"].ToString();

                    //txtTeleNo.Text = oledbReadEBC["Telephone_No"].ToString();
                    txtTeleNo.Text = ds.Tables[0].Rows[0]["Telephone_No"].ToString();

                    //for Period of stay
                    //txtNoOfYear.Text = oledbReadEBC["Year_At_Residence"].ToString();
                    txtNoOfYear.Text = ds.Tables[0].Rows[0]["Year_At_Residence"].ToString();

                    //for Residence Status
                    //ddlResidenceType.SelectedValue = oledbReadEBC["Residence_Type"].ToString();
                    ddlResidenceType.SelectedValue = ds.Tables[0].Rows[0]["Residence_Type"].ToString();

                    //for Landmark obtained
                    //txtLAndMark.Text = oledbReadEBC["Landmark"].ToString();
                    txtLAndMark.Text = ds.Tables[0].Rows[0]["Landmark"].ToString();

                    //for Relation with Candidate
                    //txtRelationshipToEmp.Text = oledbReadEBC["Relationship"].ToString();
                    txtRelationshipToEmp.Text = ds.Tables[0].Rows[0]["Relationship"].ToString();


                    //txtPermanentAdd.Text = oledbReadEBC["Permanent_Address"].ToString();
                    txtPermanentAdd.Text = ds.Tables[0].Rows[0]["Permanent_Address"].ToString();

                    //for "Neighbour  Confirmation 2
                    //txtNeighbourFeedBackOn2.Text = oledbReadEBC["Previous_job_Detail"].ToString();
                    txtNeighbourFeedBackOn2.Text = ds.Tables[0].Rows[0]["Previous_job_Detail"].ToString();


                    //ddlTypeOfAccomodation.SelectedValue = oledbReadEBC["Locality"].ToString();
                    ddlTypeOfAccomodation.SelectedValue = ds.Tables[0].Rows[0]["Locality"].ToString();


                    //txtneighbourName.Text = oledbReadEBC["Neighbour_Name"].ToString();
                    txtneighbourName.Text = ds.Tables[0].Rows[0]["Neighbour_Name"].ToString();

                    //for "Neighbour  Confirmation 1"
                    //txtNeighbourFeedBackOn.Text = oledbReadEBC["Neighbour_Feedback"].ToString();
                    txtNeighbourFeedBackOn.Text = ds.Tables[0].Rows[0]["Neighbour_Feedback"].ToString();

                    //txtTelNo.Text = oledbReadEBC["Tel_No2"].ToString();
                    txtTelNo.Text = ds.Tables[0].Rows[0]["Tel_No2"].ToString();

                    //for "Additional Comment"
                    //txtRemk.Text = oledbReadEBC["Remark"].ToString();
                    txtRemk.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                    //ddlStatus.SelectedValue = oledbReadEBC["CASE_STATUS_ID"].ToString();
                    ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["CASE_STATUS_ID"].ToString();

                    //ddlMarritalStatus.SelectedValue = oledbReadEBC["Marrital_Status"].ToString();
                    ddlMarritalStatus.SelectedValue = ds.Tables[0].Rows[0]["Marrital_Status"].ToString();

                    //txtApplicantAge.Text = oledbReadEBC["Applicant_Age"].ToString();
                    txtApplicantAge.Text = ds.Tables[0].Rows[0]["Applicant_Age"].ToString();
                    //for Error log
                    //txtAccessbility.Text = oledbReadEBC["Accessibility"].ToString();


                    //ddlErrorLog.SelectedValue = oledbReadEBC["ErrorLog"].ToString();
                    ddlErrorLog.SelectedValue = ds.Tables[0].Rows[0]["ErrorLog"].ToString();

                    //for error remark
                    //txtAccessbility.Text = oledbReadEBC["ErrorRemark"].ToString();
                    txtAccessbility.Text = ds.Tables[0].Rows[0]["ErrorRemark"].ToString();

                    //newFileUploadtest1 = (object)oledbReadEBC["UploadImg1"];   







                    OleDbDataReader dr;
                    dr = objEBC.GetRelationship(sCaseId);
                    ////DataSet ds4 = new DataSet();
                    ////ds4 = objEBC.GetRelationship(sCaseId);

                    dt.Columns.Add("Relationship");
                    dt.Columns.Add("Occupation");

                    DataRow row;
                    row = dt.NewRow();
                    while (dr.Read())
                    {
                    //while(ds.Tables[0].Rows.Count>0)
                    //{
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1]["Relationship"] = dr["RELATIONSHIP"].ToString();
                        dt.Rows[dt.Rows.Count - 1]["Occupation"] = dr["OCCUPATION"].ToString();
                        ////dt.Rows[dt.Rows.Count - 1]["Relationship"] = ds4.Tables[0].Rows[0]["RELATIONSHIP"].ToString();
                        ////dt.Rows[dt.Rows.Count - 1]["Occupation"] = ds4.Tables[0].Rows[0]["OCCUPATION"].ToString();  

                        ViewState["v1"] = dt;
                        gvRelationship.DataSource = dt;
                        gvRelationship.DataBind();
                    }
                }
                if (hidMode.Value == "View")
                {
                    ReadOnly();
                }
                if ((Request.QueryString["varMsg"] == "ErrorUpdate"))
                {
                    string strRole2 = Session["RoleID"].ToString();
                    string[] strRole3 = strRole2.Split(',');

                    foreach (string str in strRole3)
                    {
                        if (!IsPostBack)
                        {
                            if (str == "2")
                            {
                                ReadOnly();

                                ddlErrorLog.Items.Insert(0, new ListItem("No Error", "No Error"));
                                ddlErrorLog.SelectedIndex = 0;
                                txtAccessbility.Text = "";
                                txtAccessbility.Enabled = true;
                                btnEdit.Visible = true;

                            }
                        }
                    }


                }
            }
        }
    }
    public void SetProperty()
    {
        objEBC.VerificationDateTime = txtDateOfVerification.Text.Trim() + " " + txtTimeOfVerification.Text.Trim() + " " + ddlDateTimeOfVerification.SelectedItem.Text.Trim();
        objEBC.CaseID = Request.QueryString["CaseID"].ToString();

        objEBC.NameOfPersonContated = txtNameofPersonContacted.Text.Trim();
        objEBC.RespondentDesignation = txtRespondentDesignation.Text.Trim();
        objEBC.InstitutionName = txtInstitutionName.Text.Trim();
        objEBC.EmployeeDates = txtEmpDates.Text.Trim();
        objEBC.DatesAttended = txtDatesdAttended.Text.Trim();
        objEBC.QualificationGained = txtQualificationGained.Text.Trim();
        objEBC.OrganisationName = txtOrganisationName.Text.Trim();
        objEBC.LastPosition = txtLastPosition.Text.Trim();
        objEBC.ReportingManager = txtReportingManager.Text.Trim();
        objEBC.GapIdentified = txtGapIdentified.Text.Trim();
        objEBC.PeriodOfGap = ddlOCL.Text.Trim();
        objEBC.ReasoinOfGap = txtReasonOfGap.Text.Trim();
        objEBC.AddressDuringGap = txtAddressDuringGap.Text.Trim();

        objEBC.policaVerification = txtpoliceVerification.Text.Trim();
        objEBC.policaVerificationGap = txtPoliceVerificationGap.Text.Trim();
        objEBC.TelephoneNo1 = txtTeleNo.Text.Trim();
        objEBC.NumberOfYear = txtNoOfYear.Text.Trim();
        objEBC.ResidenceType = ddlResidenceType.SelectedValue;
        objEBC.LandMark = txtLAndMark.Text.Trim();
        objEBC.Accessbility = txtAccessbility.Text.Trim();

        objEBC.RelationshipToEmp = txtRelationshipToEmp.Text.Trim();
        objEBC.PemanentAdd = txtPermanentAdd.Text.Trim();
        objEBC.previosJobDetail = txtNeighbourFeedBackOn2.Text.Trim();
        objEBC.Locality = ddlTypeOfAccomodation.SelectedValue;
        objEBC.NeighbourName = txtneighbourName.Text.Trim();
        objEBC.NeighbourFeedBackOfEmp = txtNeighbourFeedBackOn.Text.Trim();
        objEBC.TelephoneNo2 = txtTelNo.Text.Trim();
        objEBC.Remark = txtRemk.Text.Trim();
        objEBC.Status = ddlStatus.SelectedValue.ToString();
        objEBC.MarritalStatus = ddlMarritalStatus.SelectedValue.ToString();
        objEBC.ApplicantAge = txtApplicantAge.Text.Trim();
        objEBC.ErrorLog = ddlErrorLog.SelectedValue;
        objEBC.ErrorRemark = txtAccessbility.Text.Trim();
        if (hdnTransStart.Value != "")
            objEBC.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objEBC.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objEBC.CentreId = Session["CentreId"].ToString();
        objEBC.ProductId = Session["ProductId"].ToString();
        objEBC.ClientId = Session["ClientId"].ToString();
        objEBC.UserId = Session["UserId"].ToString();

        //objEBC.FileUpload1 = newFileUploadtest1;


        objEBC.FileUpload1 = null;
        objEBC.FileUpload2 = null;
        objEBC.FileUpload3 = null;
        objEBC.FileUpload4 = null;
        objEBC.FileUpload5 = null;


        Array newFileUpload1 = null;
        if (FileUpload1.FileBytes.Length > 0)
        {
            newFileUpload1 = FileUpload1.FileBytes;
        }
        objEBC.FileUpload1 = newFileUpload1;

        Array newFileUpload2 = null;
        if (FileUpload2.FileBytes.Length > 0)
        {
            newFileUpload2 = FileUpload2.FileBytes;
        }
        objEBC.FileUpload2 = newFileUpload2;

        Array newFileUpload3 = null;
        if (FileUpload3.FileBytes.Length > 0)
        {
            newFileUpload3 = FileUpload3.FileBytes;
        }
        objEBC.FileUpload3 = newFileUpload3;

        Array newFileUpload4 = null;
        if (FileUpload4.FileBytes.Length > 0)
        {
            newFileUpload4 = FileUpload4.FileBytes;
        }
        objEBC.FileUpload4 = newFileUpload4;

        Array newFileUpload5 = null;
        if (FileUpload5.FileBytes.Length > 0)
        {
            newFileUpload5 = FileUpload5.FileBytes;
        }
        objEBC.FileUpload5 = newFileUpload5;



        ///------------------------------------------------------
    }
    public void ClearControl()
    {
        txtDateOfVerification.Text = "";
        txtTimeOfVerification.Text = "";
        txtNameofPersonContacted.Text = "";
        txtRespondentDesignation.Text = "";
        txtInstitutionName.Text = "";
        txtEmpDates.Text = "";
        txtDatesdAttended.Text = "";
        txtQualificationGained.Text = "";
        txtOrganisationName.Text = "";
        txtLastPosition.Text = "";
        txtReportingManager.Text = "";
        txtGapIdentified.Text = "";
        ddlOCL.Text = "";
        txtReasonOfGap.Text = "";
        txtAddressDuringGap.Text = "";
        txtpoliceVerification.Text = "";
        txtTeleNo.Text = "";
        txtNoOfYear.Text = "";
        ddlResidenceType.SelectedValue = "0";
        txtLAndMark.Text = "";
        ddlMarritalStatus.SelectedValue = "0";
        txtApplicantAge.Text = "";


        txtAccessbility.Text = "";

        txtRelationshipToEmp.Text = "";
        txtPermanentAdd.Text = "";
        txtNeighbourFeedBackOn2.Text = "";
        ddlTypeOfAccomodation.SelectedValue = "0";
        txtneighbourName.Text = "";
        txtNeighbourFeedBackOn.Text = "";
        txtTelNo.Text = "";
        txtRemk.Text = "";

    }
    private bool ValidateTextArea()
    {
        bool iValidate = true;
        string sPermanentAddress = "";

        string sNeighbourFeedBack = "";
        string sRemark = "";
        string sFamily = "";

        sPermanentAddress = txtPermanentAdd.Text;
        sNeighbourFeedBack = txtNeighbourFeedBackOn.Text;
        sRemark = txtRemk.Text;

        if (sPermanentAddress.Trim() != "")
        {
            if (sPermanentAddress.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Permanent Address should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sNeighbourFeedBack.Trim() != "")
        {
            if (sNeighbourFeedBack.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour  should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sRemark.Trim() != "")
        {
            if (sRemark.Length > 750)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 750 characters.";
                iValidate = false;
            }
        }

        return iValidate;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        string sMsg = "";
        try
        {
            if (ValidateTextArea() == true)
            {
                SetProperty();

                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');



                foreach (string str in strRole1)
                {
                    if (txtAccessbility.Text == "" && (ddlErrorLog.SelectedIndex == 1 || ddlErrorLog.SelectedIndex == 2 || ddlErrorLog.SelectedIndex == 3))
                    {
                        if (str == "2")
                        {
                            lblEM.Visible = true;
                            lblEM.Text = "Please Select ErrorLog And Enter Error Remark";
                            lblEM.Font.Bold = true;
                        }
                    }
                    else if (ddlErrorLog.SelectedIndex == 0)
                    {
                        if (ddlErrorLog.Visible == false && txtAccessbility.Visible == false)
                        {
                            objEBC.ErrorLog = null;
                            objEBC.ErrorRemark = null;
                            sMsg = objEBC.InsertEBCVerificationType();
                        }
                        else
                        {
                          
                            sMsg = objEBC.InsertEBCVerificationType();
                        }


                    }
                    else if (txtAccessbility.Text != "" && (ddlErrorLog.SelectedIndex == 1 || ddlErrorLog.SelectedIndex == 2 || ddlErrorLog.SelectedIndex == 3))
                    {
                       
                        sMsg = objEBC.InsertEBCVerificationType();
                    }



                }

            }


            if (sMsg != "")
            {
                pnlMsg.Visible = true;
                tblMsg.Visible = true;
                lblMsg.Text = sMsg.Trim();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                iCount = 1;
            }
        }

        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }

        try
        {
            dt = (DataTable)ViewState["v1"];
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
            {
                objEBC.DeleteRelatioship();
            }
            if (boolAdd)
            {
                if (ViewState["v1"] != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        objEBC.Relationship = dt.Rows[i]["Relationship"].ToString();
                        objEBC.Occupation = dt.Rows[i]["Occupation"].ToString();

                        objEBC.InsertFamilyRecord();
                    }
                }
            }
            dt = null;
            gvRelationship.DataBind();

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

        if (iCount == 1)
        {
           
            if ((Request.QueryString["varMsg"] == "ErrorUpdate"))
            {
                Response.Redirect("BGC_SendToClientFinal.aspx?varMsg=" + "verified");
            }
            else
            {
                Response.Redirect("BGC_VerificationView.aspx?Msg=" + lblMsg.Text);
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BGC_VerificationView.aspx");
    }
    protected void addbtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["v1"] != null)
            {
                dt = (DataTable)ViewState["v1"];
            }
            if (ViewState["v1"] != null && Session["Str"] == "Edit")
            {

                if (hidIndex1.Value != "")
                {
                    j = Convert.ToInt32(hidIndex1.Value);
                    dt.Rows[j].Delete();


                }

            }
            Session["Str"] = "";
            if (ViewState["v1"] == null)
            {
                dt.Columns.Add("Relationship");
                dt.Columns.Add("Occupation");

            }
            DataRow row;
            row = dt.NewRow();
            row["Relationship"] = txtRelation.Text.Trim();
            row["Occupation"] = txtOccupation.Text.Trim();

            dt.Rows.Add(row);

            ViewState["v1"] = dt;
            gvRelationship.DataSource = dt;
            gvRelationship.DataBind();
            txtRelation.Text = "";
            txtOccupation.Text = "";

            txtRelation.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void gvRelationship_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            txtRelation.Text = dt.Rows[e.NewEditIndex]["Relationship"].ToString();
            txtOccupation.Text = dt.Rows[e.NewEditIndex]["Occupation"].ToString();

            j = e.NewEditIndex;
            Session["Str"] = "Edit";
            hidIndex1.Value = j.ToString();

            gvRelationship.DataSource = dt;

            gvRelationship.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }

    }
    protected void gvRelationship_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["v1"];
            dt.Rows[e.RowIndex].Delete();
            gvRelationship.DataSource = dt;
            gvRelationship.DataBind();
            ViewState["v1"] = dt;
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
        }
    }
    public void Validation1()
    {

        if (txtRelation.Text != "" && txtOccupation.Text != "")
        {
            boolAdd = false;
            lblMsg.Visible = true;
            lblMsg.Text = "Please Enter data in table by Add New button.";
        }

    }
    private void ReadOnly()
    {

        txtLanNo.Enabled = false;
        txtDateAndTime.Enabled = false;
        txtEmpName.Enabled = false;
        txtAddress.Enabled = false;
        txtEmpECN.Enabled = false;
        txtDateAndTime.Enabled = false;
        txtDOB.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtTimeOfVerification.Enabled = false;
        ddlDateTimeOfVerification.Enabled = false;
        txtNameofPersonContacted.Enabled = false;
        txtRespondentDesignation.Enabled = false;
        txtInstitutionName.Enabled = false;
        txtEmpDates.Enabled = false;
        txtDatesdAttended.Enabled = false;
        txtQualificationGained.Enabled = false;
        txtOrganisationName.Enabled = false;
        txtLastPosition.Enabled = false;
        txtReportingManager.Enabled = false;
        txtGapIdentified.Enabled = false;
        ddlOCL.Enabled = false;
        txtReasonOfGap.Enabled = false;
        txtAddressDuringGap.Enabled = false;
        txtpoliceVerification.Enabled = false;
        txtPoliceVerificationGap.Enabled = false;
        txtTeleNo.Enabled = false;
        txtNoOfYear.Enabled = false;
        ddlResidenceType.Enabled = false;
        txtLAndMark.Enabled = false;
        txtAccessbility.Enabled = false;
        txtRelationshipToEmp.Enabled = false;
        txtPermanentAdd.Enabled = false;
        txtNeighbourFeedBackOn2.Enabled = false;
        ddlTypeOfAccomodation.Enabled = false;
        txtneighbourName.Enabled = false;
        txtNeighbourFeedBackOn.Enabled = false;
        txtTelNo.Enabled = false;
        txtRemk.Enabled = false;
        addbtn.Enabled = false;
        ddlStatus.Enabled = false;
        ddlMarritalStatus.Enabled = false;
        txtApplicantAge.Enabled = false;
        txtVerificatorName.Enabled = false;
        btnCancel.Enabled = true;
        btnSubmit.Enabled = true;
        txtRelation.Enabled = false;
        txtOccupation.Enabled = false;
        ddlErrorLog.Enabled = false;
        txtAccessbility.Enabled = false;

        gvRelationship.DataBind();
        gvRelationship.Columns[GridPosition.DELETE].Visible = false;
        gvRelationship.Columns[GridPosition.EDIT].Visible = false;


    }


    private struct GridPosition
    {
        public const int DELETE = 2;
        public const int EDIT = 3;
    }


    //----add by kanchan on 2/12/2014

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        WriteOnly();
        if (ddlErrorLog.SelectedIndex == 0)
        {
            txtAccessbility.Text = "";
            txtAccessbility.Enabled = true;
        }

    }

    private void WriteOnly()
    {

        txtLanNo.Enabled = true;
        txtDateAndTime.Enabled = true;
        txtEmpName.Enabled = true;
        txtAddress.Enabled = true;
        txtEmpECN.Enabled = true;
        txtDateAndTime.Enabled = true;
        txtDOB.Enabled = true;
        txtDateOfVerification.Enabled = true;
        txtTimeOfVerification.Enabled = true;
        ddlDateTimeOfVerification.Enabled = true;
        txtNameofPersonContacted.Enabled = true;
        txtRespondentDesignation.Enabled = true;
        txtInstitutionName.Enabled = true;
        txtEmpDates.Enabled = true;
        txtDatesdAttended.Enabled = true;
        txtQualificationGained.Enabled = true;
        txtOrganisationName.Enabled = true;
        txtLastPosition.Enabled = true;
        txtReportingManager.Enabled = true;
        txtGapIdentified.Enabled = true;
        ddlOCL.Enabled = true;
        txtReasonOfGap.Enabled = true;
        txtAddressDuringGap.Enabled = true;
        txtpoliceVerification.Enabled = true;
        txtPoliceVerificationGap.Enabled = true;
        txtTeleNo.Enabled = true;
        txtNoOfYear.Enabled = true;
        ddlResidenceType.Enabled = true;
        txtLAndMark.Enabled = true;
        txtAccessbility.Enabled = true;
        txtRelationshipToEmp.Enabled = true;
        txtPermanentAdd.Enabled = true;
        txtNeighbourFeedBackOn2.Enabled = true;
        ddlTypeOfAccomodation.Enabled = true;
        txtneighbourName.Enabled = true;
        txtNeighbourFeedBackOn.Enabled = true;
        txtTelNo.Enabled = true;
        txtRemk.Enabled = true;
        addbtn.Enabled = true;
        ddlStatus.Enabled = true;
        ddlMarritalStatus.Enabled = true;
        txtApplicantAge.Enabled = true;
        txtVerificatorName.Enabled = true;
        btnCancel.Enabled = true;
        btnSubmit.Enabled = true;
        txtRelation.Enabled = true;
        txtOccupation.Enabled = true;
        ddlErrorLog.Enabled = true;
        txtAccessbility.Enabled = true;

        ////gvRelationship.DataBind();
        ////gvRelationship.Columns[GridPosition.DELETE].Visible = true;
        ////gvRelationship.Columns[GridPosition.EDIT].Visible = true;


    }

    //----comp-----//



    protected void ddlErrorLog_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlErrorLog.SelectedIndex == 0)
        {
            txtAccessbility.Text = "";
            txtAccessbility.Enabled = false;
            lblEM.Visible = false;
        }
        else
        {
            txtAccessbility.Text = "";
            txtAccessbility.Enabled = true;
            lblEM.Visible = false;
        }
    }
}
