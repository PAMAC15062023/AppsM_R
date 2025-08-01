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

public partial class CC_CC_BusinessVerification : System.Web.UI.Page
{
    CGet objCGet = new CGet();
    CCreditCardVerification objCCVer = new CCreditCardVerification();
    string verificationType = "BV";
    //
    private CCreditCard objCC = new CCreditCard();
    DataSet dsCC = new DataSet();
    DataSet dsAttempt = new DataSet();
    //HiddenField hdnTransStart=new HiddenField();
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsOutcome.ConnectionString = objConn.ConnectionString;  //Sir

        //pnlOutcome.Visible = false;
        //pnlDeclineReason.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {

                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

                //To Show the Panels add By Manoj            
                funShowPanel();
                //End

                //Modified By Gargi Srivastava on 31-May-2007
                //if (Session["isAdd"].ToString() != "1")
                //    Response.Redirect("NoAccess.aspx");
                //End

                txtNoOfYrsPresentAddress.Text = "0";
                txtYearsWorkedIn.Text = "0";

                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    //Modified By Gargi at 31-May-2007
                    if (Session["isEdit"].ToString() != "1")
                        ISEditFalse();
                    //Response.Redirect("NoAccess.aspx");

                    txtAgencyCode.Focus();

                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    hidCaseID.Value = sCaseId;
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    hidVerificationTypeID.Value = sVerifyTypeId;

                    Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                    //End
                    dsCC = objCC.GetCreditCaseEntry(sCaseId, Session["CentreId"].ToString(), Session["ClientId"].ToString());
                    dsAttempt = objCCVer.GetAttemptDtl(sCaseId, sVerifyTypeId);
                    //START Attempt Details ------------------------------------
                    if (sCaseId != "")
                    {
                        txtAttemptDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        if (dsAttempt.Tables[0].Rows.Count > 0)
                        {
                            ddlCaseStatus.DataBind();
                            ddlCaseStatus.SelectedValue = dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString();
                            ///////////
                            for (int i = 0; i < dsAttempt.Tables[0].Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType1.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark1.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                                if (i == 1)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark2.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                                if (i == 2)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark3.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                }
                            }

                            
                        }

                       
                    }
                    //END Attempt Details ------------------------------------
                    ///START CASE DETAIL------------------------------------
                    OleDbDataReader oledbReadCaseDtl;
                    oledbReadCaseDtl = objCCVer.GetCaseDetail(Request.QueryString["CaseID"].ToString());
                    if (oledbReadCaseDtl.Read())
                    {
                        txtAppName.Text = oledbReadCaseDtl["Full_Name"].ToString();
                        txtRefNo.Text = oledbReadCaseDtl["Ref_No"].ToString();
                        if (oledbReadCaseDtl["Case_Rec_DateTime"].ToString().Trim() != "")
                            txtInitiationDate.Text = Convert.ToDateTime(oledbReadCaseDtl["Case_Rec_DateTime"].ToString()).ToString("dd/MM/yyyy");
                        else
                            txtInitiationDate.Text = "";
                        txtOfficeAddress.Text = oledbReadCaseDtl["OFFICE_ADDRESS"].ToString();
                        txtPincode.Text = oledbReadCaseDtl["OFF_PIN_CODE"].ToString();
                        //txtLandmark.Text = oledbReadCaseDtl["RES_LAND_MARK"].ToString();
                        txtOfficeTel.Text = oledbReadCaseDtl["OFF_PHONE"].ToString();
                        txtMobile.Text = oledbReadCaseDtl["MOBILE"].ToString();
                        txtFaxNumber.Text = oledbReadCaseDtl["FAX_NO"].ToString();
                        //if (oledbReadCaseDtl["DOB"].ToString().Trim() != "")
                        //    txtDOB.Text = Convert.ToDateTime(oledbReadCaseDtl["DOB"].ToString()).ToString("dd-MMM-yyyy");
                        //else
                        //    txtDOB.Text = "";
                        txtDOB.Text = oledbReadCaseDtl["DOB"].ToString();
                        txtDesgnOfApplicant.Text = oledbReadCaseDtl["DESIGNATION"].ToString();

                        if (!(oledbReadCaseDtl["TYPE_OF_APPLICANT"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfApplicant.Text = oledbReadCaseDtl["TYPE_OF_APPLICANT"].ToString();

                        if (!(oledbReadCaseDtl["TYPE_OF_LOAN"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfLoan.Text = oledbReadCaseDtl["TYPE_OF_LOAN"].ToString();

                        txtCompanyName.Text = oledbReadCaseDtl["OFF_NAME"].ToString();

                    }
                    oledbReadCaseDtl.Close();
                    ///END CASE DETAIL------------------------------------
                }

                //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION) CASE DETAIL------------------
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    OleDbDataReader oledbCaseDescRead;
                    oledbCaseDescRead = objCCVer.GetCaseVerDescriptionBV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseDescRead.Read())
                    {
                        //////////////////////////////////////                
                        ddlPPNormal.SelectedValue = oledbCaseDescRead["PP_NORMAL"].ToString();
                        txtApproxArea.Text = oledbCaseDescRead["APPROXIMATE_AREA"].ToString();
                        ddlGenAppearance.SelectedValue = oledbCaseDescRead["GENRAL_APPEARANCE"].ToString();
                        //ddlLocatingOfficeAdd.SelectedValue = oledbCaseDescRead["APPROXIMATE_AREA"].ToString();                   
                        ///For AssetVisible Checkboxes-----------------------
                        string sTmpAssetVisible = oledbCaseDescRead["ASSETS_VISIBLE"].ToString();
                        string[] arrAssetVisible = sTmpAssetVisible.Split(',');
                        int iOtherAssetCtr = 0;
                        if (arrAssetVisible.Length > 0)
                        {
                            for (int i = 0; i < arrAssetVisible.Length; i++)
                            {
                                foreach (ListItem li in chkAssetsSeen.Items)
                                {
                                    if (li.Value == arrAssetVisible.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrAssetVisible.GetValue(i).ToString() == "Others(specify)")
                                    {
                                        iOtherAssetCtr = i;
                                    }
                                }
                            }
                        }
                        for (int j = iOtherAssetCtr + 1; j < arrAssetVisible.Length; j++)
                        {
                            txtOtherAssestSeen.Text += arrAssetVisible.GetValue(j) + ",";
                        }
                        ////--------------------------------------------------------------------
                        //ddlVisitProof.SelectedValue = oledbCaseDescRead["PROOF_OF_VISIT_COLLECTED"].ToString();
                        //For Proof of Visit Collected dropdown--------
                        string sVisitProof = oledbCaseDescRead["PROOF_OF_VISIT_COLLECTED"].ToString();
                        if (sVisitProof.Trim() != "")
                        {
                            string[] arrsVisitProof = sVisitProof.Split('+');
                            if (arrsVisitProof.Length > 0)
                            {
                                if (arrsVisitProof[0].ToString() == "Others" && arrsVisitProof.Length > 1)
                                {
                                    ddlVisitProof.SelectedValue = "Others";
                                    txtOtherVisitProof.Text = arrsVisitProof[1].ToString();
                                }
                                else
                                {
                                    ddlVisitProof.SelectedValue = arrsVisitProof[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------    
                        ddlRouteMap.SelectedValue = oledbCaseDescRead["ROUTE_MAP_DRAWN"].ToString();
                        ddlTPCDone.SelectedValue = oledbCaseDescRead["TPC_DONE"].ToString();
                        txtTPCDetail.Text = oledbCaseDescRead["TPC_DETAILS"].ToString();
                        txtAnyInfo.Text = oledbCaseDescRead["ANY_OTHER_INFO_OBT"].ToString();
                        ddlAddConfirmation.SelectedValue = oledbCaseDescRead["ADRESS_CONFIRMATION"].ToString();
                        ddlContactability.SelectedValue = oledbCaseDescRead["CONTACTABILITY"].ToString();
                        ddlConfirmationApp.SelectedValue = oledbCaseDescRead["CONFIRMATION_IF_APPLICANT_MET"].ToString();
                        ddlProfile.SelectedValue = oledbCaseDescRead["PROFILE"].ToString();
                        ddlReputationTPC.Text = oledbCaseDescRead["REPUTATION"].ToString();
                        txtPersonContact.Text = oledbCaseDescRead["PERSON_CONTACTED_MET"].ToString();
                        ddlConstructionOfOffice.SelectedValue = oledbCaseDescRead["CONSTRUCTION_OF_RESIDANCE"].ToString();
                        txtApproximateAppAge.Text = oledbCaseDescRead["APPLICANT_AGE"].ToString();
                        txtPriorityCustomer.Text = oledbCaseDescRead["PRIORITY_CUSTOMER"].ToString();
                        txtInfoRequired.Text = oledbCaseDescRead["INFO_REQUIRED"].ToString();
                        ddlChangeAddress.SelectedItem.Text = oledbCaseDescRead["CHANGE_IN_ADRESS"].ToString();
                        txtReasonForChanges.Text = oledbCaseDescRead["REASON_FOR_CHANGE"].ToString();
                        txtOfficeTel.Text = oledbCaseDescRead["OFFICE_TELEPHONE"].ToString();
                        txtBranches.Text = oledbCaseDescRead["BRANCH"].ToString();
                        txtInformationRefused.Text = oledbCaseDescRead["INFO_REFUSED"].ToString();
                        ddlResonsAddrnotconfirmed.SelectedItem.Text = oledbCaseDescRead["REASON_ADD_NOT_CONFIRM"].ToString();
                        ddlLocality.SelectedValue = oledbCaseDescRead["LOCALITY"].ToString();
                        txtResultofCalling.Text = oledbCaseDescRead["RESULT_CALLING"].ToString();
                        txtMismatchresidenceadd.Text = oledbCaseDescRead["MISMATCH_RESI_ADD"].ToString();
                        ddlIsApplicantknowntotheperson.SelectedItem.Text = oledbCaseDescRead["IS_APP_KNOWN_PERSON"].ToString();
                        txtwhomdoesaddbelong.Text = oledbCaseDescRead["ADDRESS_BELONG"].ToString();
                        ddlTypeofacco.SelectedItem.Text = oledbCaseDescRead["ACCOMODATION"].ToString();
                        ddlLocatingOfficeAdd.SelectedValue = oledbCaseDescRead["LOCATING_ADDRESS"].ToString();
                        txtNoofResidents.Text = oledbCaseDescRead["FAMILY_MEMBERS"].ToString();
                        ddlEntryRestricted.SelectedValue = oledbCaseDescRead["ENTRY_PERMITTED"].ToString();
                        txtNoofYrsatthisAdd.Text = oledbCaseDescRead["TIME_AT_CURR_RESIDANCE"].ToString();
                        //START Added new fields 11-May-2007----------------------------------------------
                        ///For Interior Checkboxes---------------------------------------------------
                        string sTmpInterior = oledbCaseDescRead["INTERIOR"].ToString();
                        string[] arrInterior = sTmpInterior.Split(',');
                        int iOtherInterior = 0;
                        if (arrInterior.Length > 0)
                        {
                            for (int i = 0; i < arrInterior.Length; i++)
                            {
                                foreach (ListItem li in chkInterior.Items)
                                {
                                    if (li.Value == arrInterior.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrInterior.GetValue(i).ToString() == "Others(P1. Specify)")
                                    {
                                        iOtherInterior = i;
                                    }
                                }
                            }
                        }
                        for (int k = iOtherInterior + 1; k < arrInterior.Length; k++)
                        {
                            txtIfOtherInterior.Text += arrInterior.GetValue(k) + ",";
                        }
                        //For Exterior--------------
                        ddlExterior.SelectedValue = oledbCaseDescRead["EXTERIOR"].ToString();
                        //For verified from--------
                        ddlVerifiedFrom.SelectedValue = oledbCaseDescRead["VERIFIED_NEIGHBOUR"].ToString();
                        //END Added new fields 11-May-2007------------------------------------------------
                        //Naresh Start 13/05/2008
                        DDLNatureOfBusiness.SelectedValue = oledbCaseDescRead["Nature_Business"].ToString();
                        DDLServiceProvider.SelectedValue = oledbCaseDescRead["Service_Provider"].ToString();
                        //Naresh End 13/05/2008
                        
                    }
                   
                    oledbCaseDescRead.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION) CASE DETAIL------------------
                   /////
                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION1) CASE DETAIL------------------
                    OleDbDataReader oledbCaseDesc1Read;
                    oledbCaseDesc1Read = objCCVer.GetCaseVerDescription1BV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseDesc1Read.Read())
                    {
                        string sTmp = oledbCaseDesc1Read["TIME_AT_CURRENT_EMPLOYMENT"].ToString();
                        if (sTmp.Trim() != "")
                        {
                            string[] arrTimeAtCurrY_M = sTmp.Split('.');
                            txtTimeCurrOffYrs.Text = arrTimeAtCurrY_M[0].ToString();
                            if (arrTimeAtCurrY_M.Length > 1)
                                txtTimeCurrOffMths.Text = arrTimeAtCurrY_M[1].ToString();
                        }
                        txtContactPersonName.Text = oledbCaseDesc1Read["CONTACTED_PERSON_NAME"].ToString();
                        txtContPersonDesgn.Text = oledbCaseDesc1Read["CONTACTED_PERSON_DESIGN"].ToString();
                        txtNoOfYrCompany.Text = oledbCaseDesc1Read["COMPANY_EXISTENCE_YEAR"].ToString();
                        ddlTypeOfJob.SelectedValue = oledbCaseDesc1Read["EMP_JOB_TYPE"].ToString();
                        ddlReputationOffice.Text = oledbCaseDesc1Read["OFFICE_REPUTATION"].ToString();
                        //For Qualification dropdown---------------------
                        string sBusiPermises = oledbCaseDesc1Read["BUSINESS_PERMISES"].ToString();
                        if (sBusiPermises.Trim() != "")
                        {
                            string[] arrBusiPermises = sBusiPermises.Split('+');
                            if (arrBusiPermises.Length > 0)
                            {
                                if (arrBusiPermises[0].ToString() == "Others(specify)" && arrBusiPermises.Length > 1)
                                {
                                    ddlOffPrmises.SelectedValue = "Others(specify)";
                                    txtOtherOffPrmises.Text = arrBusiPermises[1].ToString();
                                }
                                else
                                {
                                    ddlOffPrmises.SelectedValue = arrBusiPermises[0].ToString();
                                    //ddlOffPrmises.SelectedValue = oledbCaseDesc1Read["BUSINESS_PERMISES"].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        ddlIncomeDoc.SelectedItem.Text = oledbCaseDesc1Read["INCOME_DOC_SUBMITTED_WITH_APLICATION"].ToString();
                        txtNonVisibleReason.Text = oledbCaseDesc1Read["REASON_NONVISIBLE_NAMEPLATE"].ToString();
                        ddlOfficeSize.SelectedValue = oledbCaseDesc1Read["OFFICE_SIZE"].ToString();
                        txtNoOfEmployee.Text = oledbCaseDesc1Read["NO_OF_EMP"].ToString();

                        //For OFFICE_IS_IN dropdown---------------------
                        string sOffIsIn = oledbCaseDesc1Read["OFFICE_IS_IN"].ToString();
                        if (sOffIsIn.Trim() != "")
                        {
                            string[] arrOffIsIn = sOffIsIn.Split('+');
                            if (arrOffIsIn.Length > 0)
                            {
                                if (arrOffIsIn[0].ToString() == "Others" && arrOffIsIn.Length > 1)
                                {
                                    ddlOfficeIsIn.SelectedValue = "Others";
                                    txtOtherOfficeIsIn.Text = arrOffIsIn[1].ToString();
                                }
                                else
                                {
                                    ddlOfficeIsIn.SelectedValue = arrOffIsIn[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------        
                        //For Type of office dropdown---------------------
                        string sTypeOfOffice = oledbCaseDesc1Read["TYPE_OF_OFFICE"].ToString();
                        if (sTypeOfOffice.Trim() != "")
                        {
                            string[] arrTypeOfOffice = sTypeOfOffice.Split('+');
                            if (arrTypeOfOffice.Length > 0)
                            {
                                if (arrTypeOfOffice[0].ToString() == "Others" && arrTypeOfOffice.Length > 1)
                                {
                                    ddlTypeOfOffice.SelectedValue = "Others";
                                    txtOtherTypeOfOffice.Text = arrTypeOfOffice[1].ToString();
                                }
                                else
                                {
                                    ddlTypeOfOffice.SelectedValue = arrTypeOfOffice[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------     

                        //For Applicant working as dropdown---------------------
                        string sAppWorkingAs = oledbCaseDesc1Read["APP_WORKING_AS"].ToString();
                        if (sAppWorkingAs.Trim() != "")
                        {
                            string[] arrAppWorkingAs = sAppWorkingAs.Split('+');
                            if (arrAppWorkingAs.Length > 0)
                            {
                                if (arrAppWorkingAs[0].ToString() == "Others" && arrAppWorkingAs.Length > 1)
                                {
                                    ddlApplicantWorkingAs.SelectedValue = "Others";
                                    txtOtherApplicantWorkingAs.Text = arrAppWorkingAs[1].ToString();
                                }
                                else
                                {
                                    ddlApplicantWorkingAs.SelectedValue = arrAppWorkingAs[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------   

                        //Modification done by hemangi kambli on 14-July-2007
                        //For Locality of office dropdown---------------------
                        //ddlLocalityOffice.SelectedValue = oledbCaseDesc1Read["OFFICE_LOCALITY"].ToString();
                        string sLocalityOffice = oledbCaseDesc1Read["OFFICE_LOCALITY"].ToString();
                        if (sLocalityOffice.Trim() != "")
                        {
                            string[] arrLocalityOffice = sLocalityOffice.Split('+');
                            if (arrLocalityOffice.Length > 0)
                            {
                                if (arrLocalityOffice[0].ToString() == "Others" && arrLocalityOffice.Length > 1)
                                {                                                    
                                    ddlLocalityOffice.SelectedValue = "Others";
                                    txtOtherLocalityOffice.Text = arrLocalityOffice[1].ToString();
                                }
                                else
                                {
                                    ddlLocalityOffice.SelectedValue = arrLocalityOffice[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        ddlAffPolParty.SelectedValue = oledbCaseDesc1Read["AFFILATION_POLITICAL_PARTY_SEEN"].ToString();
                        ///For Equipments In Office Checkboxes---------------------------------------------------
                        string sEquipInOffice = oledbCaseDesc1Read["EQUIPMENT_SIGHTED_IN_OFFICE"].ToString();
                        string[] arrEquipInOffice = sEquipInOffice.Split(',');
                        int iOtherEquipCtr = 0;
                        if (arrEquipInOffice.Length > 0)
                        {
                            for (int i = 0; i < arrEquipInOffice.Length; i++)
                            {
                                foreach (ListItem li in chkEquipInOffice.Items)
                                {
                                    if (li.Value == arrEquipInOffice.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrEquipInOffice.GetValue(i).ToString() == "Others(specify)")
                                    {
                                        iOtherEquipCtr = i;
                                    }
                                }
                            }
                        }
                        for (int j = iOtherEquipCtr + 1; j < arrEquipInOffice.Length; j++)
                        {
                            txtOtherEquipInOffice.Text += arrEquipInOffice.GetValue(j) + ",";
                        }
                        ////--------------------------------------------------------------------                    
                        ddlBusinessStock.SelectedValue = oledbCaseDesc1Read["BUSINESS_STOCK_SEEN"].ToString();
                        txtStockType.Text = oledbCaseDesc1Read["STOCK_TYPE"].ToString();
                        ddlBusinessActivity.SelectedValue = oledbCaseDesc1Read["BUSINESS_ACTIVITY_SEEN"].ToString();
                        txtTPCNameCompanyName.Text = oledbCaseDesc1Read["TPC_NAME"].ToString();
                        txtFERemark.Text = oledbCaseDesc1Read["FE_REMARK"].ToString();
                        txtCoAppName.Text = oledbCaseDesc1Read["CO_APP_NAME"].ToString();
                        txtNoCustomersPerDay.Text = oledbCaseDesc1Read["NO_CUSTOMER_PERDAY"].ToString();
                        ddlApplicantJobTransferable.SelectedValue = oledbCaseDesc1Read["APPLICANT_JOB_TRANSFERABLE"].ToString();
                        //txtApplicantJobTransferable.Text = oledbCaseDesc1Read["APPLICANT_JOB_TRANSFERABLE"].ToString();

                        string sYrsWorkedIn = oledbCaseDesc1Read["YEARS_WORKED"].ToString();
                        if (sYrsWorkedIn.Trim() != "")
                        {
                            string[] arrYrsWorkedIn = sYrsWorkedIn.Split('.');
                            txtYearsWorkedIn.Text = arrYrsWorkedIn[0].ToString();
                            if (arrYrsWorkedIn.Length > 1)
                                txtMthsWorkedIn.Text = arrYrsWorkedIn[1].ToString();
                        }

                        //txtYearsWorkedIn.Text = oledbCaseDesc1Read["YEARS_WORKED"].ToString();

                        txtSalaryDrawn.Text = oledbCaseDesc1Read["SALARY_DRAWN"].ToString();
                        ddlConstructionOfOffice.SelectedValue = oledbCaseDesc1Read["CONSTRUCTION_OFFICE"].ToString();
                        txtNoOfCustomersSeen.Text = oledbCaseDesc1Read["NO_CUSTOMER_SEEN"].ToString();
                        txtSegmentation.Text = oledbCaseDesc1Read["SEGMENTATION"].ToString();
                        txtInfoRequired.Text = oledbCaseDesc1Read["INFO_REQUIRED"].ToString();

                        //For RELATION_PERSON_CONTACTED dropdown---------------------
                        string sRelation = oledbCaseDesc1Read["RELATION_PERSON_CONTACTED"].ToString();
                        if (sRelation.Trim() != "")
                        {
                            string[] arrRelation = sRelation.Split('+');
                            if (arrRelation.Length > 0)
                            {
                                if (arrRelation[0].ToString() == "Others(Pl.Specify)" && arrRelation.Length > 1)
                                {
                                    ddlRelationofPersonContacted.SelectedValue = "Others(Pl.Specify)";
                                    txtOtherRelation.Text = arrRelation[1].ToString();
                                }
                                else
                                {
                                    ddlRelationofPersonContacted.SelectedValue = arrRelation[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        txtDeatailsOfProofCollected.Text = oledbCaseDesc1Read["DETAILS_PROOF_COLLECTED"].ToString();
                        txtOthers1.Text = oledbCaseDesc1Read["OTHER_1"].ToString();
                        txtOthers2.Text = oledbCaseDesc1Read["OTHER_2"].ToString();
                        ddlResiCumoff.SelectedValue = oledbCaseDesc1Read["NATURE_BUSINESS_RESI_CUM_OFF"].ToString();
                        ddlResicomoffOwned.SelectedValue = oledbCaseDesc1Read["RESI_COMOFF_OWNED"].ToString();
                        ddlSeparateareforOff.SelectedValue = oledbCaseDesc1Read["SEPARATE_FOR_OFF"].ToString();
                        ddlIfAppFullTimeEmp.SelectedValue = oledbCaseDesc1Read["IS_APPLICANT_FULL_TIME"].ToString();
                        ddlTPCTypeofCompany.SelectedValue = oledbCaseDesc1Read["TPC_TYPE_COMPANY"].ToString();
                        ddlTPCTypeofBusiness.SelectedValue = oledbCaseDesc1Read["TPC_TYPE_BUSINESS"].ToString();
                        txtUntreaceablereason.Text = oledbCaseDesc1Read["UNREACHABLE_REASON"].ToString();

                        //For VERIFICATION_CONDUCTED_AT dropdown---------------------
                        string sVerConductAt = oledbCaseDesc1Read["VERIFICATION_CONDUCTED_AT"].ToString();
                        if (sVerConductAt.Trim() != "")
                        {
                            string[] arrVerConductAt = sVerConductAt.Split('+');
                            if (arrVerConductAt.Length > 0)
                            {
                                if (arrVerConductAt[0].ToString() == "Other" && arrVerConductAt.Length > 1)
                                {
                                    ddlVerificationconductedat.SelectedValue = "Other";
                                    txtOtherVerificationconductedat.Text = arrVerConductAt[1].ToString();
                                }
                                else
                                {
                                    ddlVerificationconductedat.SelectedValue = arrVerConductAt[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        ///For DirectoryCheck In Office Checkboxes---------------------------------------------------
                        string sDirectoryCheck = oledbCaseDesc1Read["DIRECTORY_CHECK"].ToString();
                        string[] arrDirectoryCheck = sDirectoryCheck.Split(',');
                        if (arrDirectoryCheck.Length > 0)
                        {
                            for (int i = 0; i < arrDirectoryCheck.Length; i++)
                            {
                                foreach (ListItem li in chkDirectoryCheck.Items)
                                {
                                    if (li.Value == arrDirectoryCheck.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        ////--------------------------------------------------------------------                                 
                        txtWhoareyourcustomer.Text = oledbCaseDesc1Read["WHO_ARE_YOUR_CUSTOMER"].ToString();
                        txtNeighbour2Name.Text = oledbCaseDesc1Read["NEIGHBOUR_NAME_2"].ToString();
                        txtNeighbour2Add.Text = oledbCaseDesc1Read["NEIGHBOUR_ADD_2"].ToString();
                        txtCoEstabilshedIn.Text = oledbCaseDesc1Read["CO_ESTABLISHED_IN"].ToString();
                        txtLandmark.Text = oledbCaseDesc1Read["LAND_MARK_OBSERVED"].ToString();
                        txtPerAddress.Text = oledbCaseDesc1Read["PERMANENT_ADDRESS"].ToString();
                        if (oledbCaseDesc1Read["COMPANY_NAME"].ToString() != "")
                            txtCompanyName.Text = oledbCaseDesc1Read["COMPANY_NAME"].ToString();
                        txtOfficeExtn.Text = oledbCaseDesc1Read["OFFICE_EXT"].ToString();
                        txtDesgnOfApplicant.Text = oledbCaseDesc1Read["DESIGNATION"].ToString();
                        txtBusinessNature.Text = oledbCaseDesc1Read["BUSINESS_NATURE"].ToString();
                        txtParticulars.Text = oledbCaseDesc1Read["PARTICULARS"].ToString();
                        txtAverageMonthlyTurnover.Text = oledbCaseDesc1Read["AVG_MONTH_TURNOVER"].ToString();
                        txtVerPhoneNo.Text = oledbCaseDesc1Read["ANY_OTHER_RESIDANCE_PHONE_NO"].ToString(); ;
                        txtPhOnApplication.Text = oledbCaseDesc1Read["CHANGE_IN_PHONE_NO"].ToString();
                        txtNoOfEmployeeTPC.Text = oledbCaseDesc1Read["NO_OF_EMP_SIGHTED_IN_PERMISES"].ToString();

                        //For APP_MET_AT dropdown---------------------
                        string sAppMetAt = oledbCaseDesc1Read["APP_MET_AT"].ToString();
                        if (sAppMetAt.Trim() != "")
                        {
                            string[] arrAppMetAt = sAppMetAt.Split('+');
                            if (arrAppMetAt.Length > 0)
                            {
                                if (arrAppMetAt[0].ToString() == "Other" && arrAppMetAt.Length > 1)
                                {
                                    ddlApplMetat.SelectedValue = "Other";
                                    txtOtherApplMetat.Text = arrAppMetAt[1].ToString();
                                }
                                else
                                {
                                    ddlApplMetat.SelectedValue = arrAppMetAt[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        txtNameofCompany.Text = oledbCaseDesc1Read["NAMEOFCOMPANY1"].ToString();
                        txtPreviousEmploymentDetails.Text = oledbCaseDesc1Read["PREVIOUS_EMP_DETAIL"].ToString();

                        //For BUSINESS_TYPE dropdown---------------------
                        string sBusiType = oledbCaseDesc1Read["BUSINESS_TYPE"].ToString();
                        if (sBusiType.Trim() != "")
                        {
                            string[] arrBusiType = sBusiType.Split('+');
                            if (arrBusiType.Length > 0)
                            {
                                if (arrBusiType[0].ToString() == "Others" && arrBusiType.Length > 1)
                                {
                                    ddlBusinessType.SelectedValue = "Others";
                                    txtOtherBusinessType.Text = arrBusiType[1].ToString();
                                }
                                else
                                {
                                    ddlBusinessType.SelectedValue = arrBusiType[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------                    

                        
                    }
                   
                    oledbCaseDesc1Read.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DESCRIPTION1) CASE DETAIL------------------

                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_OTHER_DETAILS) CASE DETAIL------------------
                    OleDbDataReader oledbCaseVerOtherDtlRead;
                    oledbCaseVerOtherDtlRead = objCCVer.GetCaseVerOtherDtlBV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseVerOtherDtlRead.Read())
                    {

                        txtPersonContact.Text = oledbCaseVerOtherDtlRead["PERSON_CONTACTED"].ToString();
                        ///txtFERemark.Text = oledbCaseVerOtherDtlRead["CONT_PERSON_REMARK"].ToString();
                        ddlNegativeArea.SelectedValue = oledbCaseVerOtherDtlRead["IS_NEGATIVE_AREA"].ToString();
                        ddlOCL.SelectedValue = oledbCaseVerOtherDtlRead["IS_OCL"].ToString();
                        ddlTypeofResi.SelectedValue = oledbCaseVerOtherDtlRead["RES_TYPE"].ToString();
                        txtAddOnApplication.Text = oledbCaseVerOtherDtlRead["ADD_ON_APPLIED"].ToString();
                        txtNoOfYrsPresentAddress.Text = oledbCaseVerOtherDtlRead["OFF_ADDRESS_YEARS"].ToString();

                        //For Type of office dropdown---------------------
                        string sVisibleNameBoard = oledbCaseVerOtherDtlRead["OFF_NAME_ON_BOARD"].ToString();
                        if (sVisibleNameBoard.Trim() != "")
                        {
                            string[] arrVisibleNameBoard = sVisibleNameBoard.Split('+');
                            if (arrVisibleNameBoard.Length > 0)
                            {
                                if (arrVisibleNameBoard[0].ToString() == "Others" && arrVisibleNameBoard.Length > 1)
                                {
                                    ddlVisibleNameBoard.SelectedValue = "Others";
                                    txtOtherVisibleNameBoard.Text = arrVisibleNameBoard[1].ToString();
                                }
                                else
                                {
                                    ddlVisibleNameBoard.SelectedValue = arrVisibleNameBoard[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------     


                        ddlBusinessStock.SelectedValue = oledbCaseVerOtherDtlRead["STOCK_SIGHTED"].ToString();
                        ddlBusinessActivity.SelectedValue = oledbCaseVerOtherDtlRead["OFF_ACTIVITY_SIGHTED"].ToString();
                        txtAgencyCode.Text = oledbCaseVerOtherDtlRead["AGENCY_NAME"].ToString();

                        //Start Reading of fields for City Bank(Dubai)
                        if (txtFaxNumber.Text.Trim() == "")
                        {
                            if (!(oledbCaseVerOtherDtlRead["FaxNumber"].ToString().Trim().Length.Equals(0)))
                                txtFaxNumber.Text = oledbCaseVerOtherDtlRead["FaxNumber"].ToString();
                        }
                        if (!(oledbCaseVerOtherDtlRead["Is_Security_guard_building"].ToString().Trim().Length.Equals(0)))
                            ddlIsThereSecurityGuardForBuildingOffice.SelectedValue = oledbCaseVerOtherDtlRead["Is_Security_guard_building"].ToString();
                        else
                            ddlIsThereSecurityGuardForBuildingOffice.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["Is_Reception_Desk"].ToString().Trim().Length.Equals(0)))
                            ddlIsThereReceptionDesk.SelectedValue = oledbCaseVerOtherDtlRead["Is_Reception_Desk"].ToString();
                        else
                            ddlIsThereReceptionDesk.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["No_Desks_Workstations_Tables"].ToString().Trim().Length.Equals(0)))
                            txtHowManyDesksWorkStationsTables.Text = oledbCaseVerOtherDtlRead["No_Desks_Workstations_Tables"].ToString();

                        //if (!(oledbCaseVerOtherDtlRead["Is_TradeLicense_Displayed"].ToString().Trim().Length.Equals(0)))
                        //    ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedValue=oledbCaseVerOtherDtlRead["Is_TradeLicense_Displayed"].ToString();
                        //else
                        //    ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedValue = "NA";

                        //For Type of office dropdown---------------------
                        string sIsTradeLicenseOfCompanyDisplayedOnPremises = oledbCaseVerOtherDtlRead["Is_TradeLicense_Displayed"].ToString();
                        if (sIsTradeLicenseOfCompanyDisplayedOnPremises.Trim() != "")
                        {
                            string[] arrIsTradeLicenseOfCompanyDisplayedOnPremises = sIsTradeLicenseOfCompanyDisplayedOnPremises.Split('+');
                            if (arrIsTradeLicenseOfCompanyDisplayedOnPremises.Length > 0)
                            {
                                if (arrIsTradeLicenseOfCompanyDisplayedOnPremises[0].ToString() == "Others" && arrIsTradeLicenseOfCompanyDisplayedOnPremises.Length > 1)
                                {
                                    ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedValue = "Others";
                                    txtOtherIsTradeLicenseOfCompanyDisplayedOnPremises.Text = arrIsTradeLicenseOfCompanyDisplayedOnPremises[1].ToString();
                                }
                                else
                                {
                                    ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedValue = arrIsTradeLicenseOfCompanyDisplayedOnPremises[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------     

                        if (!(oledbCaseVerOtherDtlRead["No_Of_Employees"].ToString().Trim().Length.Equals(0)))
                            txtNumberOfEmployees.Text = oledbCaseVerOtherDtlRead["No_Of_Employees"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch1_Location"].ToString().Trim().Length.Equals(0)))
                            txtBranch1Location.Text = oledbCaseVerOtherDtlRead["Branch1_Location"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch1_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch1Telephoneno.Text = oledbCaseVerOtherDtlRead["Branch1_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch1_Rental_Amt"].ToString().Trim().Length.Equals(0)))
                            txtBranch1RentalAmt.Text = oledbCaseVerOtherDtlRead["Branch1_Rental_Amt"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch1_FaxNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch1Faxno.Text = oledbCaseVerOtherDtlRead["Branch1_FaxNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch1_ManagerName"].ToString().Trim().Length.Equals(0)))
                            txtBranch1ManagerName.Text = oledbCaseVerOtherDtlRead["Branch1_ManagerName"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch2_Location"].ToString().Trim().Length.Equals(0)))
                            txtBranch2Location.Text = oledbCaseVerOtherDtlRead["Branch2_Location"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch2_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch2TelephoneNo.Text = oledbCaseVerOtherDtlRead["Branch2_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch2_Rental_Amt"].ToString().Trim().Length.Equals(0)))
                            txtBranch2RentalAmt.Text = oledbCaseVerOtherDtlRead["Branch2_Rental_Amt"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch2_FaxNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch2Faxno.Text = oledbCaseVerOtherDtlRead["Branch2_FaxNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch2_ManagerName"].ToString().Trim().Length.Equals(0)))
                            txtBranch2ManagerName.Text = oledbCaseVerOtherDtlRead["Branch2_ManagerName"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch3_Location"].ToString().Trim().Length.Equals(0)))
                            txtBranch3Location.Text = oledbCaseVerOtherDtlRead["Branch3_Location"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch3_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch3TelephoneNo.Text = oledbCaseVerOtherDtlRead["Branch3_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch3_Rental_Amt"].ToString().Trim().Length.Equals(0)))
                            txtBranch3RentalAmt.Text = oledbCaseVerOtherDtlRead["Branch3_Rental_Amt"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch3_FaxNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch3Faxno.Text = oledbCaseVerOtherDtlRead["Branch3_FaxNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch3_ManagerName"].ToString().Trim().Length.Equals(0)))
                            txtBranch3ManagerName.Text = oledbCaseVerOtherDtlRead["Branch3_ManagerName"].ToString();

                        /////////////------------------
                        if (!(oledbCaseVerOtherDtlRead["Branch4_Location"].ToString().Trim().Length.Equals(0)))
                            txtBranch4Location.Text = oledbCaseVerOtherDtlRead["Branch4_Location"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch4_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch4Telephoneno.Text = oledbCaseVerOtherDtlRead["Branch4_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch4_Rental_Amt"].ToString().Trim().Length.Equals(0)))
                            txtBranch4RentalAmt.Text = oledbCaseVerOtherDtlRead["Branch4_Rental_Amt"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch4_FaxNo"].ToString().Trim().Length.Equals(0)))
                            txtBranch4Faxno.Text = oledbCaseVerOtherDtlRead["Branch4_FaxNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Branch4_ManagerName"].ToString().Trim().Length.Equals(0)))
                            txtBranch4ManagerName.Text = oledbCaseVerOtherDtlRead["Branch4_ManagerName"].ToString();

                        //Add two New Fields

                        if (!(oledbCaseVerOtherDtlRead["Application_No"].ToString().Trim().Length.Equals(0)))
                            txtApplicationNo.Text = oledbCaseVerOtherDtlRead["Application_No"].ToString();

                        //if (!(oledbCaseVerOtherDtlRead["Number_Branches_Office_Warehouse"].ToString().Trim().Length.Equals(0)))
                          //  txtNumberOfBranchesOfficeWarehouse.Text = oledbCaseVerOtherDtlRead["Number_Branches_Office_Warehouse"].ToString();
                        
                        if (!(oledbCaseVerOtherDtlRead["Number_Branches_Office_Warehouse"].ToString().Trim().Length.Equals(0)))
                            txtBranches.Text = oledbCaseVerOtherDtlRead["Number_Branches_Office_Warehouse"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor1_Name"].ToString().Trim().Length.Equals(0)))
                            txtSponsor1Name.Text = oledbCaseVerOtherDtlRead["Sponsor1_Name"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type1"].ToString().Trim().Length.Equals(0)))
                            txtType1.Text = oledbCaseVerOtherDtlRead["Type1"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor1_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtSponsor1TelephoneNo.Text = oledbCaseVerOtherDtlRead["Sponsor1_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor1_Address"].ToString().Trim().Length.Equals(0)))
                            txtSponsor1Address.Text = oledbCaseVerOtherDtlRead["Sponsor1_Address"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor2_Name"].ToString().Trim().Length.Equals(0)))
                            txtSponsor2Name.Text = oledbCaseVerOtherDtlRead["Sponsor2_Name"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type2"].ToString().Trim().Length.Equals(0)))
                            txtType2.Text = oledbCaseVerOtherDtlRead["Type2"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor2_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtSponsor2TelephoneNo.Text = oledbCaseVerOtherDtlRead["Sponsor2_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor2_Address"].ToString().Trim().Length.Equals(0)))
                            txtSponsor2Address.Text = oledbCaseVerOtherDtlRead["Sponsor2_Address"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor3_Name"].ToString().Trim().Length.Equals(0)))
                            txtSponsor3Name.Text = oledbCaseVerOtherDtlRead["Sponsor3_Name"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type3"].ToString().Trim().Length.Equals(0)))
                            txtType3.Text = oledbCaseVerOtherDtlRead["Type3"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor3_TelephoneNo"].ToString().Trim().Length.Equals(0)))
                            txtSponsor3TelephoneNo.Text = oledbCaseVerOtherDtlRead["Sponsor3_TelephoneNo"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Sponsor3_Address"].ToString().Trim().Length.Equals(0)))
                            txtSponsor3Address.Text = oledbCaseVerOtherDtlRead["Sponsor3_Address"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["No_Emps_SeniorPosition"].ToString().Trim().Length.Equals(0)))
                            txtNoOfEmpsInSeniorPosition.Text = oledbCaseVerOtherDtlRead["No_Emps_SeniorPosition"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Business_Nature"].ToString().Trim().Length.Equals(0)))
                            txtNatureOfBusinessSponsor.Text = oledbCaseVerOtherDtlRead["Business_Nature"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Product_Dealt_With"].ToString().Trim().Length.Equals(0)))
                            txtProductDealtWith.Text = oledbCaseVerOtherDtlRead["Product_Dealt_With"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["BankName1"].ToString().Trim().Length.Equals(0)))
                            txtBankName1.Text = oledbCaseVerOtherDtlRead["BankName1"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type_Of_Account1"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfAccount1.Text = oledbCaseVerOtherDtlRead["Type_Of_Account1"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Facilities1"].ToString().Trim().Length.Equals(0)))
                            txtFacilities1.Text = oledbCaseVerOtherDtlRead["Facilities1"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["BankName2"].ToString().Trim().Length.Equals(0)))
                            txtBankName2.Text = oledbCaseVerOtherDtlRead["BankName2"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type_Of_Account2"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfAccount2.Text = oledbCaseVerOtherDtlRead["Type_Of_Account2"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Facilities2"].ToString().Trim().Length.Equals(0)))
                            txtFacilities2.Text = oledbCaseVerOtherDtlRead["Facilities2"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["BankName3"].ToString().Trim().Length.Equals(0)))
                            txtBankName3.Text = oledbCaseVerOtherDtlRead["BankName3"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type_Of_Account3"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfAccount3.Text = oledbCaseVerOtherDtlRead["Type_Of_Account3"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Facilities3"].ToString().Trim().Length.Equals(0)))
                            txtFacilities3.Text = oledbCaseVerOtherDtlRead["Facilities3"].ToString();

                        ///For CityBank In SalesIn Checkboxes---------------------------------------------------
                        ///
                        if (!(oledbCaseVerOtherDtlRead["Sales_In"].ToString().Trim().Length.Equals(0)))
                        {
                            string sSalesIn = oledbCaseVerOtherDtlRead["Sales_In"].ToString();
                            string[] arrSalesIn = sSalesIn.Split(',');
                            if (arrSalesIn.Length > 0)
                            {
                                for (int i = 0; i < arrSalesIn.Length; i++)
                                {
                                    foreach (ListItem li in chkSalesIn.Items)
                                    {
                                        if (li.Value == arrSalesIn.GetValue(i).ToString())
                                            li.Selected = true;
                                    }
                                }
                            }
                        }
                        ////-------------------------------------------------------------------- 

                        if (!(oledbCaseVerOtherDtlRead["Avg_Monthly_Turnover"].ToString().Trim().Length.Equals(0)))
                            txtAvgMonthlyTurnover.Text = oledbCaseVerOtherDtlRead["Avg_Monthly_Turnover"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Client_List"].ToString().Trim().Length.Equals(0)))
                            txtClientList.Text = oledbCaseVerOtherDtlRead["Client_List"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Impression_Of_Office"].ToString().Trim().Length.Equals(0)))
                            txtImpressionOfOffice.Text = oledbCaseVerOtherDtlRead["Impression_Of_Office"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Credit_Analyst_Decision"].ToString().Trim().Length.Equals(0)))
                            ddlCreditAnalystDecision.SelectedValue = oledbCaseVerOtherDtlRead["Credit_Analyst_Decision"].ToString();
                        else
                            ddlCreditAnalystDecision.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["Credit_Analyst_Name"].ToString().Trim().Length.Equals(0)))
                            txtCreditAnalystName.Text = oledbCaseVerOtherDtlRead["Credit_Analyst_Name"].ToString();

                        if (oledbCaseVerOtherDtlRead["Credit_Analyst_Date"].ToString().Trim() != "")
                            txtCreditAnalystDate.Text = Convert.ToDateTime(oledbCaseVerOtherDtlRead["Credit_Analyst_Date"].ToString()).ToString("dd/MM/yyyy");
                        else
                            txtCreditAnalystDate.Text = "";

                        if (!(oledbCaseVerOtherDtlRead["Office_Verification_No"].ToString().Trim().Length.Equals(0)))
                            txtOfficeVerificationNo.Text = oledbCaseVerOtherDtlRead["Office_Verification_No"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Telephone_Bill"].ToString().Trim().Length.Equals(0)))
                            txtTelephoneBill.Text = oledbCaseVerOtherDtlRead["Telephone_Bill"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Employment_Status"].ToString().Trim().Length.Equals(0)))
                            ddlEmploymentStatus.SelectedValue = oledbCaseVerOtherDtlRead["Employment_Status"].ToString();
                        else
                            ddlEmploymentStatus.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["Years_In_Employment_Business"].ToString().Trim().Length.Equals(0)))
                            txtYearsInEmploymentBusiness.Text = oledbCaseVerOtherDtlRead["Years_In_Employment_Business"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Cm_Design"].ToString().Trim().Length.Equals(0)))
                            txtCmDesign.Text = oledbCaseVerOtherDtlRead["Cm_Design"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Basic_Salary"].ToString().Trim().Length.Equals(0)))
                            txtBasicSalary.Text = oledbCaseVerOtherDtlRead["Basic_Salary"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Transport_Allowance"].ToString().Trim().Length.Equals(0)))
                            txtTransportAllowance.Text = oledbCaseVerOtherDtlRead["Transport_Allowance"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["House_Rent_Allowance"].ToString().Trim().Length.Equals(0)))
                            txtHouseRentAllowance.Text = oledbCaseVerOtherDtlRead["House_Rent_Allowance"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Fixed_Allowance"].ToString().Trim().Length.Equals(0)))
                            txtFixedAllowance.Text = oledbCaseVerOtherDtlRead["Fixed_Allowance"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Total_Fixed_Salary"].ToString().Trim().Length.Equals(0)))
                            txtTotalFixedSalary.Text = oledbCaseVerOtherDtlRead["Total_Fixed_Salary"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Additional_Comments"].ToString().Trim().Length.Equals(0)))
                            txtAdditionalComments.Text = oledbCaseVerOtherDtlRead["Additional_Comments"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Employment_Confirmed_With"].ToString().Trim().Length.Equals(0)))
                            txtEmploymentConfirmedWith.Text = oledbCaseVerOtherDtlRead["Employment_Confirmed_With"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Employment_Confirmed_With_Designation"].ToString().Trim().Length.Equals(0)))
                            txtEmploymentConfirmedWithDesignation.Text = oledbCaseVerOtherDtlRead["Employment_Confirmed_With_Designation"].ToString();

                        //if (!(oledbCaseVerOtherDtlRead["Type_of_Applicant"].ToString().Trim().Length.Equals(0)))
                        //    txtTypeOfApplicant.Text=oledbCaseVerOtherDtlRead["Type_of_Applicant"].ToString();


                        if (!(oledbCaseVerOtherDtlRead["Details_Of_Trade_License"].ToString().Trim().Length.Equals(0)))
                            txtDetailsOfTradeLicense.Text = oledbCaseVerOtherDtlRead["Details_Of_Trade_License"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["Type_Of_Salary"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfSalary.Text = oledbCaseVerOtherDtlRead["Type_Of_Salary"].ToString();

                        //End Reading of fields for City Bank(Dubai) 

                        //For HSBC Bank-Dubai--new fields -------

                        //For Office cum Residence dropdown---------------------
                        string sOffCumResi = oledbCaseVerOtherDtlRead["OFFICE_CUM_RESIDENCE"].ToString();
                        if (sOffCumResi.Trim() != "")
                        {
                            string[] arrOffCumResi = sOffCumResi.Split('+');
                            if (arrOffCumResi.Length > 0)
                            {
                                if (arrOffCumResi[0].ToString() == "Others" && arrOffCumResi.Length > 1)
                                {
                                    ddlOfficeCumResidence.SelectedValue = "Others";
                                    txtOtherOfficeCumResidence.Text = arrOffCumResi[1].ToString();
                                }
                                else
                                {
                                    ddlOfficeCumResidence.SelectedValue = arrOffCumResi[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        //For Photograph Location dropdown---------------------
                        string sPhotographLocation = oledbCaseVerOtherDtlRead["PHOTOGRAPH_LOCATION"].ToString();
                        if (sPhotographLocation.Trim() != "")
                        {
                            string[] arrPhotographLocation = sPhotographLocation.Split('+');
                            if (arrPhotographLocation.Length > 0)
                            {
                                if (arrPhotographLocation[0].ToString() == "Others" && arrPhotographLocation.Length > 1)
                                {
                                    ddlPhotographOfLocation.SelectedValue = "Others";
                                    txtOtherPhotographOfLocation.Text = arrPhotographLocation[1].ToString();
                                }
                                else
                                {
                                    ddlPhotographOfLocation.SelectedValue = arrPhotographLocation[0].ToString();
                                }
                            }
                        }
                        //--------------------------------------------------

                        txtEmirate.Text = oledbCaseVerOtherDtlRead["EMIRATE"].ToString();
                        txtAppReportToName.Text = oledbCaseVerOtherDtlRead["APPLICANT_REPORT_TO_NAME"].ToString();
                        txtAppReportToDesignation.Text = oledbCaseVerOtherDtlRead["APPLICANT_REPORT_TO_DESGN"].ToString();
                        txtAppHomeCountryPhoneNo.Text = oledbCaseVerOtherDtlRead["APPLICANT_HOME_COUNTRY_PHONE"].ToString();
                        txtIsCompanyPartOfGroupCompanies.Text = oledbCaseVerOtherDtlRead["IS_COMPANY_PART_GROUP_COMPANIES"].ToString();
                        txtMainBusiOrCompanyActivity.Text = oledbCaseVerOtherDtlRead["MAIN_BUSINESS_COMPANY_ACTIVITY"].ToString();
                        txtNameOfOwner.Text = oledbCaseVerOtherDtlRead["NAME_OF_OWNER"].ToString();
                        txtBranchesWareHouseCompanyHaveInUAE.Text = oledbCaseVerOtherDtlRead["BRANCHES_WARESHOUSE_COMPANY_IN_UAE"].ToString();

                        
                    }
                    
                    oledbCaseVerOtherDtlRead.Close();
                   
                    //////////////////////////////////////////////////////////////////////////////////////////

                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_OTHER_DETAILS) CASE DETAIL------------------
                    //////START FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DETAILS) CASE DETAIL------------------

                    OleDbDataReader oledbCaseVerDtlRead;
                    oledbCaseVerDtlRead = objCCVer.GetCaseVerDtlBV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseVerDtlRead.Read())
                    {
                        txtDeclineReason.Text = oledbCaseVerDtlRead["DECLINED_REASON"].ToString();
                        txtOverallAsst.Text = oledbCaseVerDtlRead["OVERALL_ASSESMENT"].ToString();
                        txtAsstReason.Text = oledbCaseVerDtlRead["OVERALL_ASSESMENT_REASON"].ToString();
                        //txtOutcome.Text = oledbCaseVerDtlRead["DECLINED_CODE"].ToString();
                        /**/
                        ddlCaseStatus.DataBind();
                        ddlCaseStatus.SelectedValue = oledbCaseVerDtlRead["CASE_STATUS_ID"].ToString();
                        ddlOutcome.DataBind();
                        if (oledbCaseVerDtlRead["DECLINED_CODE"].ToString().Trim() == "")
                            ddlOutcome.SelectedValue = "0";
                        else
                            ddlOutcome.SelectedValue = oledbCaseVerDtlRead["DECLINED_CODE"].ToString();

                        txtCPVscore.Text = oledbCaseVerDtlRead["RATING"].ToString();
                        txtSupervisorName.Text = oledbCaseVerDtlRead["SUPERVISOR_ID"].ToString();
                        txtSupervisorRemark.Text = oledbCaseVerDtlRead["SUPERVISOR_REMARKS"].ToString();

                       
                    }
                   
                    oledbCaseVerDtlRead.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DETAILS) CASE DETAIL------------------
                    
                }
                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }

                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                if (hidMode.Value == "View")
                {
                    btnCancel.Enabled = false;
                    btnSubmit.Enabled = false;
                    LikButtonVisibility();

                }
                dsCC.Clear();
                dsCC.Dispose();
                dsAttempt.Clear();
                dsAttempt.Dispose();
            }
            catch (Exception ex)
            {
                pnlMsg.Visible = true;
                tblMsg.Visible = true;                
                lblMsg.Text = "Error while retrieving data: " + ex.Message;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        CCommon objCmn = new CCommon();
        try
        {

            //////--------(+) has been replaced by (:) for all objects in Others Specify case.--------////////

            /////--------CPV_CC_VERI_DESCRIPTION-------------------

           
            objCCVer.CaseId = Request.QueryString["CaseId"].ToString();
            objCCVer.VerificationType = Request.QueryString["VerTypeId"].ToString();
            objCCVer.VerficationTypeID = Request.QueryString["VerTypeId"].ToString();
            objCCVer.PPNormal = ddlPPNormal.SelectedItem.Text.Trim();
            objCCVer.ApproxArea = txtApproxArea.Text.Trim();
            objCCVer.GeneralAppearance = ddlGenAppearance.SelectedItem.Text.Trim();
             objCCVer.LocatingAddress = ddlLocatingOfficeAdd.SelectedItem.Text.Trim();
            
            ///////////////////////Modified by Santosh Shelar 17th may 2008/////////////////////////////
            string sAssetSeen = "";
            string sAss_Vis_AC = "";
            string sAss_Vis_Comp = "";
            string sAss_Vis_PH = "";
            string sAss_Vis_PhotCop = "";
            string sAss_Vis_Fax = "";
            string sAss_Vis_Print = "";

            if (chkAssetsSeen.Items.Count > 0)
            {
                foreach (ListItem li in chkAssetsSeen.Items)
                {
                    if (li.Text.Trim() == "AC" && li.Selected == true)
                    {
                        sAss_Vis_AC = "Yes";
                    }

                    else if (li.Text.Trim() == "PC" && li.Selected == true)
                    {
                        sAss_Vis_Comp = "Yes";
                    }

                    else if (li.Text.Trim() == "Telephone" && li.Selected == true)
                    {
                        sAss_Vis_PH = "Yes";
                    }

                    else if (li.Text.Trim() == "Xerox" && li.Selected == true)
                    {
                        sAss_Vis_PhotCop = "Yes";
                    }

                    else if (li.Text.Trim() == "Fax" && li.Selected == true)
                    {
                        sAss_Vis_Fax = "Yes";
                    }

                    else if (li.Text.Trim() == "Printer" && li.Selected == true)
                    {
                        sAss_Vis_Print = "Yes";
                    }

                    if (li.Text.Trim() == "Others(specify)" && li.Selected == true)
                        sAssetSeen += li.Value + "," + txtOtherAssestSeen.Text.Trim();
                    else
                        if (li.Selected == true)
                            sAssetSeen += li.Value + ",";
                }
            }        
            if (sAss_Vis_AC == "")
            {
                sAss_Vis_AC = "N/C";
            }
            if (sAss_Vis_Comp == "")
            {
                sAss_Vis_Comp = "N/C";
            }
            if (sAss_Vis_PH == "")
            {
                sAss_Vis_PH = "N/C";
            }
            if (sAss_Vis_PhotCop == "")
            {
                sAss_Vis_PhotCop = "N/C";
            }
            if (sAss_Vis_Fax == "")
            {
                sAss_Vis_Fax = "N/C";
            }
            if (sAss_Vis_Print == "")
            {
                sAss_Vis_Print = "N/C";
            }
    
            objCCVer.AssetsVisible = sAssetSeen.TrimEnd(',');
            objCCVer.Ass_Vis_AC = sAss_Vis_AC.TrimEnd();  
            objCCVer.Ass_Vis_Comp = sAss_Vis_Comp.TrimEnd();  
            objCCVer.Ass_Vis_PH = sAss_Vis_PH.TrimEnd();  
            objCCVer.Ass_Vis_PhotCop = sAss_Vis_PhotCop.TrimEnd();  
            objCCVer.Ass_Vis_Fax = sAss_Vis_Fax.TrimEnd();  
            objCCVer.Ass_Vis_Print = sAss_Vis_Print.TrimEnd();  
            /////////////////////////////////////////////////////////////////////////////////////////////////
            //objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();
            objCCVer.RouteMap = ddlRouteMap.SelectedItem.Text.Trim();
            objCCVer.TPCDone = ddlTPCDone.SelectedItem.Text.Trim();
            objCCVer.TPCDetail = txtTPCDetail.Text.Trim();
            objCCVer.AnyInformation = txtAnyInfo.Text.Trim();
            objCCVer.AddressConfirmation = ddlAddConfirmation.SelectedItem.Text.Trim();
            objCCVer.Contactability = ddlContactability.SelectedItem.Text.Trim();
            objCCVer.ApplicationConfirm = ddlConfirmationApp.SelectedItem.Text.Trim();
            objCCVer.Profile = ddlProfile.SelectedItem.Text.Trim();
            objCCVer.Reputation = ddlReputationTPC.SelectedItem.Text.Trim();
            objCCVer.PersonContacted = txtPersonContact.Text.Trim();
            objCCVer.ConstructionOffice = ddlConstructionOfOffice.SelectedItem.Text.Trim(); //not in database
            objCCVer.ApproxAgeOfApp = txtApproximateAppAge.Text.Trim();
            objCCVer.PriorityCustomer = txtPriorityCustomer.Text.Trim();
            objCCVer.InfoRequired = txtInfoRequired.Text.Trim();
            objCCVer.ChangeInAdd = ddlChangeAddress.SelectedItem.Text.Trim();
            objCCVer.ReasonOfChange = txtReasonForChanges.Text.Trim();
            //objCCVer.Outcome = txtOutcome.Text.Trim();            
            objCCVer.OfficePhone = txtOfficeTel.Text.Trim();
            objCCVer.Branch = txtBranches.Text.Trim();
            objCCVer.InfoRefused = txtInformationRefused.Text.Trim();
            objCCVer.ReasonAddNotConfirm = ddlResonsAddrnotconfirmed.SelectedItem.Text.Trim();
            //objCCVer.Locality = ddlLocalityOffice.Text.Trim();
            objCCVer.Locality = ddlLocality.SelectedItem.Text.Trim();
            objCCVer.ResultOfCalling = txtResultofCalling.Text.Trim();
            objCCVer.MismatchResiAdd = txtMismatchresidenceadd.Text.Trim();
            objCCVer.IsAppKnown = ddlIsApplicantknowntotheperson.SelectedItem.Text.Trim();
            objCCVer.ToWhomAddBelong = txtwhomdoesaddbelong.Text.Trim();
            objCCVer.Accomodation = ddlTypeofacco.SelectedItem.Text.Trim();
            objCCVer.NoOfFamilyMem = txtNoofResidents.Text.Trim();
            objCCVer.EntryPermit = ddlEntryRestricted.SelectedItem.Text.Trim();
            objCCVer.TimeAtCurrResi = txtNoofYrsatthisAdd.Text.Trim();
            //START Added new fields-----------------------11-May-2007            
            ///For Interior Checkboxes---------------------------------------------------
            string sInterior = "";
            if (chkInterior.Items.Count > 0)
            {
                foreach (ListItem li in chkInterior.Items)
                {
                    if (li.Text.Trim() == "Others(P1. Specify)" && li.Selected == true)
                        sInterior += li.Value + "," + txtIfOtherInterior.Text.Trim();
                    else
                        if (li.Selected == true)
                            sInterior += li.Value + ",";
                }
            }
            objCCVer.Interior = sInterior.TrimEnd(',');
            ///For Exterior Dropdown---------------------------------------------------           
            objCCVer.Exterior = ddlExterior.SelectedItem.Text.Trim();
            if (ddlVerifiedFrom.SelectedItem.Text.Trim() == "Others(specify)")
                objCCVer.VerifiedFrom = txtOtherVerified.Text.Trim();
            else
                objCCVer.VerifiedFrom = ddlVerifiedFrom.SelectedItem.Text.Trim();
            //END Added new fields-----------------------11-May-2007
            //Naresh Start 13/05/2008
            objCCVer.NatureBusiness = DDLNatureOfBusiness.SelectedItem.Text.Trim();
            objCCVer.ServiceProvider = DDLServiceProvider.SelectedItem.Text.Trim();
            //Naresh End 13/05/2008
            ////Santosh Shelar : Start/////////////////
            objCCVer.other_nature_of_business = TextBox1.Text.Trim();
            ////Santosh Shelar : End///////////////////
            /////////////////////////////////////////////////////////////////////////////////
            ///////--------CPV_CC_VERI_DESCRIPTION1-------------------
            objCCVer.PersonContName = txtContactPersonName.Text.Trim();
            objCCVer.PersonContDesgn = txtContPersonDesgn.Text.Trim();
            if (ddlBusinessType.SelectedItem.Text.Trim() == "Others")
                objCCVer.TypeOfBusiness = "Others" + ":" + txtOtherBusinessType.Text.Trim();
            else
                objCCVer.TypeOfBusiness = ddlBusinessType.SelectedItem.Text.Trim();

            objCCVer.NoOfYearINComp = txtNoOfYrCompany.Text.Trim();
            objCCVer.EmpJobType = ddlTypeOfJob.SelectedItem.Text.Trim();
            if (ddlOffPrmises.SelectedItem.Text.Trim() == "Others(specify)")
                objCCVer.OfficePremises = "Others(specify)" + ":" + txtOtherOffPrmises.Text.Trim();
            else
                objCCVer.OfficePremises = ddlOffPrmises.SelectedItem.Text.Trim();

            objCCVer.IncomeDocs = ddlIncomeDoc.SelectedItem.Text.Trim();
            objCCVer.ReasonNonVisNameplate = txtNonVisibleReason.Text.Trim();
            objCCVer.OfficeSize = ddlOfficeSize.SelectedItem.Text.Trim();
            objCCVer.NoOfEmployee = txtNoOfEmployee.Text.Trim();
            //Modified by hemangi kambli on 14-July-2007 ---------
            //objCCVer.OfficeLocality = ddlLocalityOffice.SelectedItem.Text.Trim();
            if (ddlLocalityOffice.SelectedItem.Text.Trim() == "Others")
                objCCVer.OfficeLocality = "Others" + ":" + txtOtherLocalityOffice.Text.Trim();
            else
                objCCVer.OfficeLocality = ddlLocalityOffice.SelectedItem.Text.Trim();
            //-----------------------------------------------------

            if (ddlOfficeIsIn.SelectedItem.Text.Trim() == "Others")
                objCCVer.OfficeIsIn = "Others" + ":" + txtOtherOfficeIsIn.Text.Trim();
            else
                objCCVer.OfficeIsIn = ddlOfficeIsIn.SelectedItem.Text.Trim();
            //For type of office dropdown----02/08/2007---
            if (ddlTypeOfOffice.SelectedItem.Text.Trim() == "Others")
                objCCVer.TypeOfOffice = "Others" + ":" + txtOtherTypeOfOffice.Text.Trim();
            else
                objCCVer.TypeOfOffice = ddlTypeOfOffice.SelectedItem.Text.Trim();
            //-----------------------
            //For applicant working as dropdown----02/08/2007---
            if (ddlApplicantWorkingAs.SelectedItem.Text.Trim() == "Others")
                objCCVer.AppWorkingAs = "Others" + ":" + txtOtherApplicantWorkingAs.Text.Trim();
            else
                objCCVer.AppWorkingAs = ddlApplicantWorkingAs.SelectedItem.Text.Trim();
            //-----------------------

            objCCVer.AffiPoliticalParty = ddlAffPolParty.SelectedItem.Text.Trim();
            ///////////------------------
            string sEquipInOffice = "";
            if (chkEquipInOffice.Items.Count > 0)
            {
                foreach (ListItem li in chkEquipInOffice.Items)
                {
                    if (li.Text.Trim() == "Others(specify)" && li.Selected == true)
                        sEquipInOffice += li.Value + "," + txtOtherEquipInOffice.Text.Trim();
                    else
                        if (li.Selected == true)
                            sEquipInOffice += li.Value + ",";
                }
            }

            objCCVer.EquipSightedInOff = sEquipInOffice.TrimEnd(',');
            ///////////------------------
            objCCVer.BusinessStockSeen = ddlBusinessStock.SelectedItem.Text.Trim();
            objCCVer.StockType = txtStockType.Text.Trim();
            objCCVer.BusinessActivity = ddlBusinessActivity.SelectedItem.Text.Trim();
            objCCVer.TPCName = txtTPCNameCompanyName.Text.Trim();
            objCCVer.FERemark = txtFERemark.Text.Trim();
            objCCVer.CoAppName = txtCoAppName.Text.Trim();
            objCCVer.NoOfCustPerDay = txtNoCustomersPerDay.Text.Trim();
            //objCCVer.AppJobTransferable = txtApplicantJobTransferable.Text.Trim();
            objCCVer.AppJobTransferable = ddlApplicantJobTransferable.SelectedValue.ToString();
            //objCCVer.YearsWorkIn = Convert.ToDecimal(txtYearsWorkedIn.Text.Trim());
            //modified by hemangi kambli on 30-July-2007 ------------
            objCCVer.YearsWorkIn = txtYearsWorkedIn.Text.Trim() + "." + txtMthsWorkedIn.Text.Trim();
            ///----------------------------------------------------------
            objCCVer.SalaryDrawn = txtSalaryDrawn.Text.Trim();
            objCCVer.ConstructionOffice = ddlConstructionOfOffice.SelectedItem.Text.Trim();
            objCCVer.NoOfCustSeen = txtNoOfCustomersSeen.Text.Trim();
            //objCCVer.PriorityCustomer = txtPriorityCustomer.Text.Trim();
            objCCVer.Segmentation = txtSegmentation.Text.Trim();
            //objCCVer.InfoRequired = txtInfoRequired.Text.Trim();            
            //objCCVer.RelationPerContacted = ddlRelationofPersonContacted.SelectedItem.Text.Trim();
            if (ddlRelationofPersonContacted.SelectedItem.Text.Trim() == "Others(Pl.Specify)")
                objCCVer.RelationPerContacted = "Others(Pl.Specify)" + ":" + txtOtherRelation.Text.Trim();
            else
                objCCVer.RelationPerContacted = ddlRelationofPersonContacted.SelectedItem.Text.Trim();

            objCCVer.DetailsProofCollected = txtDeatailsOfProofCollected.Text.Trim();
            objCCVer.Other1 = txtOthers1.Text.Trim();
            objCCVer.Other2 = txtOthers2.Text.Trim();
            objCCVer.Nature_Busi_Resi_Cum_Off = ddlResiCumoff.SelectedItem.Text.Trim();
            objCCVer.Resi_Cum_Off_Owned = ddlResicomoffOwned.SelectedItem.Text.Trim();
            objCCVer.SeperateForOffice = ddlSeparateareforOff.SelectedItem.Text.Trim();
            objCCVer.IsAppFullTime = ddlIfAppFullTimeEmp.SelectedItem.Text.Trim();
            objCCVer.TPCTypeCompany = ddlTPCTypeofCompany.SelectedItem.Text.Trim();
            objCCVer.TPCTypeBusiness = ddlTPCTypeofBusiness.SelectedItem.Text.Trim();
            //objCCVer.AddressConfirmation = ddlAddConfirmation.SelectedItem.Text.Trim();
            objCCVer.UntraceableReason = txtUntreaceablereason.Text.Trim();

            if (ddlVerificationconductedat.SelectedItem.Text.Trim() == "Other")
                objCCVer.VerificationConductAt = "Other" + ":" + txtOtherVerificationconductedat.Text.Trim();
            else
                objCCVer.VerificationConductAt = ddlVerificationconductedat.SelectedItem.Text.Trim();

            string sDirectoryCheck = "";
            if (chkDirectoryCheck.Items.Count > 0)
            {
                foreach (ListItem li in chkDirectoryCheck.Items)
                {
                    if (li.Selected == true)
                        sDirectoryCheck += li.Value + ",";
                }
            }
            objCCVer.DirectoryCheck = sDirectoryCheck.TrimEnd(',');
            objCCVer.WhoAreYourCustomer = txtWhoareyourcustomer.Text.Trim();
            objCCVer.Neighbour2Name = txtNeighbour2Name.Text.Trim();
            objCCVer.Neighbour2Add = txtNeighbour2Add.Text.Trim();
            objCCVer.CoEstablishIn = txtCoEstabilshedIn.Text.Trim();
            objCCVer.LandmarkObserved = txtLandmark.Text.Trim();
            objCCVer.PermanentAddress = txtPerAddress.Text.Trim();
            objCCVer.CompanyName = txtCompanyName.Text.Trim();
            objCCVer.TimeCurrOfficeYrsMths = txtTimeCurrOffYrs.Text.Trim() + "." + txtTimeCurrOffMths.Text.Trim();
            objCCVer.OfficeExtn = txtOfficeExtn.Text.Trim();
            objCCVer.DesgnAtOffice = txtDesgnOfApplicant.Text.Trim();
            //if (txtDOB.Text.Trim() != "")
            //    objCCVer.DateOfBirth = Convert.ToDateTime(txtDOB.Text.Trim());
            objCCVer.DateOfBirth = txtDOB.Text.Trim();
            objCCVer.BusinessNature = txtBusinessNature.Text.Trim();
            objCCVer.Particulars = txtParticulars.Text.Trim();
            objCCVer.AvgMonthTurnOver = txtAverageMonthlyTurnover.Text.Trim();
            objCCVer.AnyOtherPhoneNo = txtVerPhoneNo.Text.Trim();
            objCCVer.ChangeInPhone = txtPhOnApplication.Text.Trim();
            objCCVer.EmpSighted = txtNoOfEmployeeTPC.Text.Trim();

            if (ddlApplMetat.SelectedItem.Text.Trim() == "Other")
                objCCVer.AppMetAt = "Other" + ":" + txtOtherApplMetat.Text.Trim();
            else
                objCCVer.AppMetAt = ddlApplMetat.SelectedItem.Text.Trim();

            objCCVer.NameOfCompany1 = txtNameofCompany.Text.Trim();
            objCCVer.PrevEmpDetail = txtPreviousEmploymentDetails.Text.Trim();
            objCCVer.OfficeReputation = ddlReputationOffice.SelectedItem.Text.Trim();
            objCCVer.OfficeAddress = txtOfficeAddress.Text.Trim();
            objCCVer.PinCode = txtPincode.Text.TrimEnd();
            //////////////////////////////////////////////////////////////////////////////////////////

            ///////---CPV_CC_VERI_OTHER_DETAILS----------------------------------
            //objCCVer.RelationWithApplicant = ddlRelationofPersonContacted.SelectedItem.Text.Trim();
            objCCVer.PersonContacted = txtPersonContact.Text.Trim();
            objCCVer.PermanentAddress = txtPerAddress.Text.Trim();
            objCCVer.FERemark = txtFERemark.Text.Trim();
            objCCVer.NegativeArea = ddlNegativeArea.SelectedItem.Text.Trim();
            objCCVer.OCL = ddlOCL.SelectedItem.Text.Trim();
            //objCCVer.Locality = ddlLocality.SelectedItem.Text.Trim();
            objCCVer.ResidenceType = ddlTypeofResi.SelectedItem.Text.Trim();
            objCCVer.AddresssOnApplication = txtAddOnApplication.Text.Trim();
            ////comment by santosh shelar//////////
           //objCCVer.NoOfYearsInPresentAdd = Convert.ToDecimal(txtNoOfYrsPresentAddress.Text.Trim());
            /////////end code/////////
            //objCCVer.OffNameOnBoard = ddlVisibleNameBoard.SelectedItem.Text.Trim();
            if (ddlVisibleNameBoard.SelectedItem.Text.Trim() == "Others")
                objCCVer.OffNameOnBoard = "Others" + ":" + txtOtherVisibleNameBoard.Text.Trim();
            else
                objCCVer.OffNameOnBoard = ddlVisibleNameBoard.SelectedItem.Text.Trim();
            objCCVer.BusinessStockSeen = ddlBusinessStock.SelectedItem.Text.Trim();
            objCCVer.BusinessActivity = ddlBusinessActivity.SelectedItem.Text.Trim();
            //objCCVer.TypeOfBusiness = ddlBusinessType.SelectedItem.Text.Trim();            
            //objCCVer.OfficeLocality = ddlLocalityOffice.SelectedItem.Text.Trim();         
            objCCVer.AgencyCode = txtAgencyCode.Text.Trim();

            ///Properties assigned for City Bank (Dubai)

            objCCVer.FaxNumber=txtFaxNumber.Text.Trim();

            if (ddlIsThereSecurityGuardForBuildingOffice.SelectedItem.Text.Trim() == "NA")
                objCCVer.IsThereSecurityGuardForBuildingOffice = "";
            else
                objCCVer.IsThereSecurityGuardForBuildingOffice = ddlIsThereSecurityGuardForBuildingOffice.SelectedItem.Text.Trim();

                if (ddlIsThereReceptionDesk.SelectedItem.Text.Trim() == "NA")
                    objCCVer.IsThereReceptionDesk = "";
                else
                objCCVer.IsThereReceptionDesk = ddlIsThereReceptionDesk.SelectedItem.Text.Trim();

            objCCVer.HowManyDesksWorkstationsTables=txtHowManyDesksWorkStationsTables.Text.Trim();

            if (ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedItem.Text.Trim() == "Others")
                objCCVer.IsTradeLicenseOfCompanyDisplayedOnPremises = "Others" + ":" + txtOtherIsTradeLicenseOfCompanyDisplayedOnPremises.Text.Trim();
            else
                objCCVer.IsTradeLicenseOfCompanyDisplayedOnPremises = ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedItem.Text.Trim();

            //if (ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedItem.Text.Trim() == "NA")
            //    objCCVer.IsTradeLicenseOfCompanyDisplayedOnPremises = "";
            //else
            //objCCVer.IsTradeLicenseOfCompanyDisplayedOnPremises=ddlIsTradeLicenseOfCompanyDisplayedOnPremises.SelectedItem.Text.Trim();

            objCCVer.NumberOfEmployees=txtNumberOfEmployees.Text.Trim();
            objCCVer.Branch1Location=txtBranch1Location.Text.Trim();
            objCCVer.Branch1TelephoneNo=txtBranch1Telephoneno.Text.Trim();
            objCCVer.Branch1RentalAmt=txtBranch1RentalAmt.Text.Trim();
            objCCVer.Branch1FaxNo=txtBranch1Faxno.Text.Trim();
            objCCVer.Branch1ManagerName=txtBranch1ManagerName.Text.Trim();
            objCCVer.Branch2Location=txtBranch2Location.Text.Trim();
            objCCVer.Branch2TelephoneNo=txtBranch2TelephoneNo.Text.Trim();
            objCCVer.Branch2RentalAmt=txtBranch2RentalAmt.Text.Trim();
            objCCVer.Branch2FaxNo=txtBranch2Faxno.Text.Trim();
            objCCVer.Branch2ManagerName=txtBranch2ManagerName.Text.Trim();
            objCCVer.Branch3Location=txtBranch3Location.Text.Trim();
            objCCVer.Branch3TelephoneNo=txtBranch3TelephoneNo.Text.Trim();
            objCCVer.Branch3RentalAmt=txtBranch3RentalAmt.Text.Trim();
            objCCVer.Branch3Faxno=txtBranch3Faxno.Text.Trim();
            objCCVer.Branch3ManagerName=txtBranch3ManagerName.Text.Trim();
            ///------
            objCCVer.Branch4Location = txtBranch4Location.Text.Trim();
            objCCVer.Branch4TelephoneNo = txtBranch4Telephoneno.Text.Trim();
            objCCVer.Branch4RentalAmt = txtBranch4RentalAmt.Text.Trim();
            objCCVer.Branch4FaxNo = txtBranch4Faxno.Text.Trim();
            objCCVer.Branch4ManagerName = txtBranch4ManagerName.Text.Trim();
            //Add Two new Fields
            objCCVer.ApplicationNo = txtApplicationNo.Text.Trim();
            objCCVer.NumberOfBranchesOfficeWarehouse = txtNumberOfBranchesOfficeWarehouse.Text.Trim();

            objCCVer.Sponsor1Name=txtSponsor1Name.Text.Trim();
            objCCVer.Type1=txtType1.Text.Trim();
            objCCVer.Sponsor1TelephoneNo=txtSponsor1TelephoneNo.Text.Trim();
            objCCVer.Sponsor1Address=txtSponsor1Address.Text.Trim();
            objCCVer.Sponsor2Name=txtSponsor2Name.Text.Trim();
            objCCVer.Type2=txtType2.Text.Trim();
            objCCVer.Sponsor2TelephoneNo=txtSponsor2TelephoneNo.Text.Trim();
            objCCVer.Sponsor2Address=txtSponsor2Address.Text.Trim();
            objCCVer.Sponsor3Name=txtSponsor3Name.Text.Trim();
            objCCVer.Type3=txtType3.Text.Trim();
            objCCVer.Sponsor3TelephoneNo=txtSponsor3TelephoneNo.Text.Trim();
            objCCVer.Sponsor3Address=txtSponsor3Address.Text.Trim();
            objCCVer.NoOfEmpsInSeniorPosition=txtNoOfEmpsInSeniorPosition.Text.Trim();
            objCCVer.NatureOfBusinessSponsor=txtNatureOfBusinessSponsor.Text.Trim();
            objCCVer.ProductDealtWith=txtProductDealtWith.Text.Trim();
            objCCVer.BankName1=txtBankName1.Text.Trim();
            objCCVer.TypeOfAccount1=txtTypeOfAccount1.Text.Trim();
            objCCVer.Facilities1=txtFacilities1.Text.Trim();
            objCCVer.BankName2=txtBankName2.Text.Trim();
            objCCVer.TypeOfAccount2=txtTypeOfAccount2.Text.Trim();
            objCCVer.Facilities2=txtFacilities2.Text.Trim();
            objCCVer.BankName3=txtBankName3.Text.Trim();
            objCCVer.TypeOfAccount3=txtTypeOfAccount3.Text.Trim();
            objCCVer.Facilities3=txtFacilities3.Text.Trim();
            //Assigning Chkbox List value to Property of Sales In
            string sSalesIn = "";
            if (chkSalesIn.Items.Count > 0)
            {
                foreach (ListItem li in chkSalesIn.Items)
                {
                    if (li.Selected == true)
                        sSalesIn += li.Value + ",";
                }
            }
           
            objCCVer.SalesIn = sSalesIn.TrimEnd(',');
           //////////////////////////////////////////////////////End
            objCCVer.AvgMonthlyTurnover=txtAvgMonthlyTurnover.Text.Trim();
            objCCVer.ClientList=txtClientList.Text.Trim();
            objCCVer.ImpressionOfOffice=txtImpressionOfOffice.Text.Trim();

            if (ddlCreditAnalystDecision.SelectedItem.Text.Trim() == "NA")
                objCCVer.CreditAnalystDecision = "";
            else
            objCCVer.CreditAnalystDecision=ddlCreditAnalystDecision.SelectedItem.Text.Trim();

            objCCVer.CreditAnalystName=txtCreditAnalystName.Text.Trim();
            if (txtCreditAnalystDate.Text.Trim().Length == 0)
            {
                objCCVer.CreditAnalystDate = "";
            }
            else
            {
                objCCVer.CreditAnalystDate = objCmn.strDate(txtCreditAnalystDate.Text.Trim().ToString());
            }
            objCCVer.OfficeVerificationNo=txtOfficeVerificationNo.Text.Trim();
            objCCVer.TelephoneBill=txtTelephoneBill.Text.Trim();

            if (ddlEmploymentStatus.SelectedItem.Text.Trim() == "NA")
                objCCVer.EmploymentStatus = "";
            else
            objCCVer.EmploymentStatus=ddlEmploymentStatus.SelectedItem.Text.Trim();

            objCCVer.YearsInEmploymentBusiness=txtYearsInEmploymentBusiness.Text.Trim();
            objCCVer.CmDesign=txtCmDesign.Text.Trim();
            objCCVer.BasicSalary=txtBasicSalary.Text.Trim();
            objCCVer.TransportAllowance=txtTransportAllowance.Text.Trim();
            objCCVer.HouseRentAllowance=txtHouseRentAllowance.Text.Trim();
            objCCVer.FixedAllowance=txtFixedAllowance.Text.Trim();
            objCCVer.TotalFixedSalary=txtTotalFixedSalary.Text.Trim();
            objCCVer.AdditionalComments=txtAdditionalComments.Text.Trim();
            objCCVer.EmploymentConfirmedWith=txtEmploymentConfirmedWith.Text.Trim();
            objCCVer.EmploymentConfirmedWithDesignation=txtEmploymentConfirmedWithDesignation.Text.Trim();
            objCCVer.TypeOfApplicant=txtTypeOfApplicant.Text.Trim();
            
            objCCVer.DetailsOfTradeLicense=txtDetailsOfTradeLicense.Text.Trim();
            objCCVer.TypeOfSalary=txtTypeOfSalary.Text.Trim();
                     
             ///End Properties Assiging for City Bank (Dubai)

            //////////////////////////////////////////////////////////////////////////////////////////

            ////////for CPV_CC_VERI_DETAILS table--------------------
            
            objCCVer.OverallAssessment = txtOverallAsst.Text.Trim();
            objCCVer.AssesstReason = txtAsstReason.Text.Trim();
            //objCCVer.DeclineCode = txtOutcome.Text.Trim();
            objCCVer.CaseStatusId = ddlCaseStatus.SelectedValue.ToString();            
            objCCVer.DeclineCode = ddlOutcome.SelectedValue.ToString();
            objCCVer.DeclineReason = txtDeclineReason.Text.Trim();            
            objCCVer.CPVScore = txtCPVscore.Text.Trim();
            objCCVer.SupervisorId = txtSupervisorName.Text.Trim();
            objCCVer.SupervisorRemark = txtSupervisorRemark.Text.Trim();

            /////////////////////////////////////////////////////////////////////////
            //objCCVer.Negmatch = ddlNegatch.SelectedItem.Text.Trim();    //
            //objCCVer.NegmatchDetail = txtDetailNegmatch.Text.Trim();    //           
            //objCCVer.VerificationDate = Convert.ToDateTime(txtVerificationDate.Text.Trim()); 
            /////////////////////////////////////////////////////////////////////////
            
            ////START Attempt Details
            ArrayList arrAttempt = new ArrayList();
            ArrayList arrAttempt1 = new ArrayList();
            ArrayList arrAttempt2 = new ArrayList();
            ArrayList arrAttempt3 = new ArrayList();
            if (IsValidAttempt() == true)
            {
                string strCaseID = Request.QueryString["CaseID"].ToString();
                objCC.CaseId = strCaseID;

                //objCC.VerifierID = ddlVerifier.SelectedValue.ToString();
                ////objCC.VerificationTypeID = ddlVeriType.SelectedValue.ToString();

                //objCC.CaseStatusID = ddlCaseStatus.SelectedValue.ToString();
                //if (ddlCaseStatus.SelectedItem.Text.ToString() == "NEGATIVE")
                //    objCC.DeclineCode = ddlDeclinedCode.SelectedValue.ToString();
                //else
                //    objCC.DeclineCode = "";

                //objCC.DeclineReason = txtDeclineReason.Text.Trim();

                //CCommon objCmn = new CCommon();
                if (txtAttemptDate1.Text.Trim() != "" && txtAttemptTime1.Text.Trim() != "")
                {
                    arrAttempt1.Clear();
                    arrAttempt1.Add(objCmn.strDate(txtAttemptDate1.Text.Trim()) + " " + txtAttemptTime1.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
                    arrAttempt1.Add(txtAttemptRemark1.Text.Trim());
                    arrAttempt.Add(arrAttempt1);
                }

                if (txtAttemptDate2.Text.Trim() != "" && txtAttemptTime2.Text.Trim() != "")
                {
                    arrAttempt2.Clear();
                    arrAttempt2.Add(objCmn.strDate(txtAttemptDate2.Text.Trim()) + " " + txtAttemptTime2.Text.Trim() + " " + ddlAttemptTimeType2.SelectedItem.Text.Trim());
                    arrAttempt2.Add(txtAttemptRemark2.Text.Trim());
                    arrAttempt.Add(arrAttempt2);
                }

                if (txtAttemptDate3.Text.Trim() != "" && txtAttemptTime3.Text.Trim() != "")
                {
                    arrAttempt3.Clear();
                    arrAttempt3.Add(objCmn.strDate(txtAttemptDate3.Text.Trim()) + " " + txtAttemptTime3.Text.Trim() + " " + ddlAttemptTimeType3.SelectedItem.Text.Trim());
                    arrAttempt3.Add(txtAttemptRemark3.Text.Trim());
                    arrAttempt.Add(arrAttempt3);
                }
                ///End Attempt Details--------------------
                ////////Call insert/update function-------------------------- 
                string IsCase = "Y";
                objCCVer.IsCaseComp = IsCase.ToString();

                string sMsg = "";
                
                objCCVer.VerifierID = Request.QueryString["VerifierId"].ToString();
                //added by hemangi kambli on 07/09/2007--------------
                objCCVer.AddedBy = Session["UserId"].ToString();
                objCCVer.AddedOn = DateTime.Now;
                objCCVer.ModifyBy = Session["UserId"].ToString();
                objCCVer.ModifyOn = DateTime.Now;
                //Added by hemangi kambli on 01/10/2007 
                if (hdnTransStart.Value != "")
                    objCCVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objCCVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
                objCCVer.CentreId = Session["CentreId"].ToString();
                objCCVer.ProductId = Session["ProductId"].ToString();
                objCCVer.ClientId = Session["ClientId"].ToString();
                objCCVer.UserId = Session["UserId"].ToString();
                ///------------------------------------------------------
                ///added by hemangi kambli on 13-Oct-2007 for additional fields of HSBC_Dubai------
                if (ddlOfficeCumResidence.SelectedItem.Text.Trim() == "Others")
                    objCCVer.OfficeCumResidence = "Others" + ":" + txtOtherOfficeCumResidence.Text.Trim();
                else
                    objCCVer.OfficeCumResidence = ddlOfficeCumResidence.SelectedItem.Text.Trim();

                if (ddlPhotographOfLocation.SelectedItem.Text.Trim() == "Others")
                    objCCVer.PhotographOfLocation = "Others" + ":" + txtOtherPhotographOfLocation.Text.Trim();
                else
                    objCCVer.PhotographOfLocation = ddlPhotographOfLocation.SelectedItem.Text.Trim();

                objCCVer.Emirate = txtEmirate.Text.Trim();
                objCCVer.ApplicantReportToName = txtAppReportToName.Text.Trim();
                objCCVer.AppReportToDesignation = txtAppReportToDesignation.Text.Trim();
                objCCVer.ApplicantHomeCountryPhoneNo = txtAppHomeCountryPhoneNo.Text.Trim();
                objCCVer.IsCompanyPartOfGroupCompanies = txtIsCompanyPartOfGroupCompanies.Text.Trim();
                objCCVer.MainBusinessOrCompanyActivity = txtMainBusiOrCompanyActivity.Text.Trim();
                objCCVer.NameOfOwner = txtNameOfOwner.Text.Trim();
                objCCVer.BranchesWareHouseCompanyHaveInUAE = txtBranchesWareHouseCompanyHaveInUAE.Text.Trim();

                //objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();
                if (ddlVisitProof.SelectedItem.Text.Trim() == "Others")
                    objCCVer.VisitProof = "Others" + ":" + txtOtherVisitProof.Text.Trim();
                else
                    objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();

                ///----------------------------------------------------------
                sMsg = objCCVer.InsertUpdateCCBusiVerificationEntry(arrAttempt);
                if ((objCCVer.Error != "") && (objCCVer.Error != null))
                {
                    
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.Text = objCCVer.Error;
                }

                else
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.Text = sMsg.Trim();                    
                    iCount = 1;
                }
                ///-------------------------------------------------------------
            }
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
           
            lblMsg.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            //Response.Write("alert('Verification completed.')");
            Response.Redirect("CC_VerificationView.aspx?Msg=" + lblMsg.Text);
            
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    string sCaseId = txtCaseId.Text.Trim();
    //    string sVerifyType = ddlVerifyType.SelectedValue.ToString();
    //    OleDbDataReader oledbRead;
    //    oledbRead = objCCVer.GetVerificationDetail(txtCaseId.Text.Trim(), ddlVerifyType.SelectedValue.ToString());
    //    switch (sVerifyType)
    //    {
    //        case "1":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
    //            break;
    //        case "10":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_PermanentResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
    //            break;
    //        case "2":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
    //            break;
    //        case "3":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
    //            break;
    //        case "4":
    //            if (oledbRead.Read() == true)
    //                Response.Redirect("CC_ResidenceVerificationTelephonic.aspx");
    //            break;
    //    }

    //}
    //protected void ddlVerifyType_DataBound(object sender, EventArgs e)
    //{
    //    ddlVerifyType.Items.Insert(0, new ListItem("Select", "0"));
    //}

    //protected void cvSelectVerifyType_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    if (source.ToString() == "0")
    //    {
    //        lblMsg.Visible = true;
    //        lblMsg.Text = "Please select verification Type.";
    //    }
    //}

    protected void ddlOutcome_DataBound(object sender, EventArgs e)
    {
        ddlOutcome.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddlCaseStatus_DataBound(object sender, EventArgs e)
    {
        ddlCaseStatus.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void cvSelectCaseStatus_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;            
            lblMsg.Text = "Please select case status.";
        }
    }
    private bool IsValidAttempt()
    {
        bool IsValid = true;
        try
        {
            if (txtAttemptTime1.Text.Trim() != "" && IsValid == true)
            {
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                //Modified By Gargi at 31-May-2007
                //if (txtAttemptRemark1.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in first attempt.";
                //    txtAttemptRemark1.Focus();
                //}
                //End
            }
            if (txtAttemptRemark1.Text.Trim() != "" && IsValid == true)
            {
            
                if (txtAttemptDate1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in first attempt.";
                    txtAttemptDate1.Focus();
                }
                if (txtAttemptTime1.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter time in first attempt.";
                    txtAttemptTime1.Focus();
                }
                if (txtAttemptRemark1.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Remark should not be greater than 255 characters in first attempt.";
                    txtAttemptRemark1.Focus();
                }

            }

            if (txtAttemptTime2.Text != "" && IsValid == true)
            {
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                //Modified By Gargi at 31-May-2007
                //if (txtAttemptRemark2.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in second attempt.";
                //    txtAttemptRemark2.Focus();
                //}
                //End
            }

            if (txtAttemptRemark2.Text != "" && IsValid == true)
            {
            
                if (txtAttemptDate2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in second attempt.";
                    txtAttemptDate2.Focus();
                }
                if (txtAttemptTime2.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter time in second attempt.";
                    txtAttemptTime2.Focus();
                }
                if (txtAttemptRemark2.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Remark should not be greater than 255 characters in second attempt.";
                    txtAttemptRemark2.Focus();
                }
            }

            if (txtAttemptTime3.Text != "" && IsValid == true)
            {
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                //Modified By Gargi at 31-May-2007
                //if (txtAttemptRemark3.Text == "")
                //{
                //    IsValid = false;
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Enter remark in third attempt.";
                //    txtAttemptRemark3.Focus();
                //}
                //End

            }

            if (txtAttemptRemark3.Text != "" && IsValid == true)
           {
               
                if (txtAttemptDate3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Enter date in third attempt.";
                    txtAttemptDate3.Focus();
                }
                if (txtAttemptTime3.Text == "")
                {
                    IsValid = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Enter time in third attempt.";
                    txtAttemptTime3.Focus();
                }
                
               
                if (txtAttemptRemark3.Text.Length > 500)
                {
                    IsValid = false;
                    lblMsg.Visible = true;                    
                    lblMsg.Text = "Remark should not be greater than 255 characters in third attempt.";
                    txtAttemptRemark3.Focus();
                }
          
            }
            //if (txtAddress1.Text != "")
            //{
            //    if (txtAddress1.Text.Length > 500)
            //    {
            //        IsValid = false;
            //        lblMsg.Visible = true;
            //        lblMsg.Text = "Billing address should not be greater than 500 characters.";
            //        txtattAddress1.Focus();
            //    }
            //}
            if (txtAttemptTime1.Text.Trim() == "" && txtAttemptTime2.Text.Trim() == "" && txtAttemptTime3.Text.Trim() == "")
            {
                pnlMsg.Visible = true;
                IsValid = false;
                lblMsg.Visible = true;                
                lblMsg.Text = "Enter atleast one record for attempt.";
                txtAttemptTime1.Focus();
            }
            
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;            
            lblMsg.Text = "Error:" + ex.Message;
        }
        return IsValid;
    }

    protected void ddlCaseStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCaseStatus.SelectedItem.Text.Trim() == "NEGATIVE")
        //{
        //    pnlOutcome.Visible = true;
        //    pnlDeclineReason.Visible = true;
        //}
        //else
        //{
        //    pnlOutcome.Visible = false;
        //    pnlDeclineReason.Visible = false;
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_VerificationView.aspx");
    }
    public void funShowPanel()
    {
        try
        {
            string strClientID = Session["ClientId"].ToString();
            string strActivityID = Session["ActivityId"].ToString();
            string strProductID = Session["ProductId"].ToString();
            string strVerificationType = "2";
            string strPanelName = "";
            string strPlaceHolderName = "";
            int nCount = 1;

            DataSet dsPanel = objCGet.getPanels(strActivityID, strProductID, strClientID, strVerificationType);
            if (dsPanel != null)
            {
                if (dsPanel.Tables[0].Rows.Count != 0)
                {

                    for (int i = 0; i < dsPanel.Tables[0].Rows.Count; i++)
                    {
                        //CountBonusRows += 1;
                        strPanelName = dsPanel.Tables[0].Rows[i]["PANEL_NAME"].ToString();
                        strPlaceHolderName = "PlaceHolder" + nCount.ToString();


                        PlaceHolder objPlaceHolder = new PlaceHolder();
                        objPlaceHolder = (PlaceHolder)(tblBusiVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                        if (objPlaceHolder != null)
                        {

                            Panel objPanel = new Panel();
                            //objPanel.EnableViewState = false;
                            objPanel = (Panel)(tblBusiVeri.Rows[1].Cells[0].FindControl(strPanelName));
                            if (objPanel != null)
                            {
                                objPanel.Visible = true;

                                objPlaceHolder.Controls.Add(objPanel);
                            }
                        }
                        //ViewState["strPlaceHolder"+nCount.ToString()] = objPlaceHolder;
                        nCount++;

                    }

                }
            }
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;            
            lblMsg.Text = "Error while setting panels:" + ex.Message;
        }
    }
    private void ISEditFalse()
    {

         txtAppName.Enabled = false;
         txtRefNo.Enabled = false;
         txtInitiationDate.Enabled = false;
        /////--------CPV_CC_VERI_DESCRIPTION-------------------

        ddlPPNormal.Enabled = false;
        txtApproxArea.Enabled = false;
        ddlGenAppearance.Enabled = false;
        ddlLocatingOfficeAdd.Enabled = false;
        chkAssetsSeen.Enabled = false;
        txtOtherAssestSeen.Enabled = false;


        ddlVisitProof.SelectedItem.Enabled = false;
        ddlRouteMap.SelectedItem.Enabled = false;
        ddlTPCDone.SelectedItem.Enabled = false;
        txtTPCDetail.Enabled = false;
        txtAnyInfo.Enabled = false;
        ddlAddConfirmation.Enabled = false;
        ddlContactability.Enabled = false;
        ddlConfirmationApp.Enabled = false;
        ddlProfile.Enabled = false;
        ddlReputationTPC.Enabled = false;
        txtPersonContact.Enabled = false;
        ddlConstructionOfOffice.Enabled = false; //not in database
        txtApproximateAppAge.Enabled = false;
        txtPriorityCustomer.Enabled = false;
        txtInfoRequired.Enabled = false;
        ddlChangeAddress.Enabled = false;
        txtReasonForChanges.Enabled = false;

        txtOfficeTel.Enabled = false;
        txtBranches.Enabled = false;
        txtInformationRefused.Enabled = false;
        ddlResonsAddrnotconfirmed.Enabled = false;

        ddlLocality.Enabled = false;
        txtResultofCalling.Enabled = false;
        txtMismatchresidenceadd.Enabled = false;
        ddlIsApplicantknowntotheperson.Enabled = false;
        txtwhomdoesaddbelong.Enabled = false;
        ddlTypeofacco.Enabled = false;
        txtNoofResidents.Enabled = false;
        ddlEntryRestricted.Enabled = false;
        txtNoofYrsatthisAdd.Enabled = false;


        chkInterior.Enabled = false; ;

        txtIfOtherInterior.Enabled = false;



        ddlExterior.Enabled = false;
        ddlVerifiedFrom.Enabled = false;
        txtOtherVerified.Enabled = false;

        ddlVerifiedFrom.Enabled = false;
           

           
            ///////--------CPV_CC_VERI_DESCRIPTION1-------------------
        txtContactPersonName.Enabled = false;
        txtContPersonDesgn.Enabled = false;
        ddlBusinessType.Enabled = false;
        txtOtherBusinessType.Enabled = false;
        ddlBusinessType.Enabled = false;
        txtNoOfYrCompany.Enabled = false;
        ddlTypeOfJob.SelectedItem.Enabled = false;
        ddlOffPrmises.SelectedItem.Enabled = false;
        txtOtherOffPrmises.Enabled = false;
        ddlOffPrmises.Enabled = false;

        ddlIncomeDoc.Enabled = false;
        txtNonVisibleReason.Enabled = false;
        ddlOfficeSize.Enabled = false;
        txtNoOfEmployee.Enabled = false;
        ddlLocalityOffice.Enabled = false;
        ddlOfficeIsIn.Enabled = false;
        txtOtherOfficeIsIn.Enabled = false;
        ddlOfficeIsIn.Enabled = false;

        ddlAffPolParty.Enabled = false;
        chkEquipInOffice.Enabled = false; ;

        txtOtherEquipInOffice.Enabled = false;


        ddlBusinessStock.Enabled = false;
        txtStockType.Enabled = false;
        ddlBusinessActivity.Enabled = false;
        txtTPCNameCompanyName.Enabled = false;
        txtFERemark.Enabled = false;
        txtCoAppName.Enabled = false;
        txtNoCustomersPerDay.Enabled = false;

        ddlApplicantJobTransferable.Enabled = false;
        txtYearsWorkedIn.Enabled = false;
        txtSalaryDrawn.Enabled = false;
        ddlConstructionOfOffice.Enabled = false;
        txtNoOfCustomersSeen.Enabled = false;
        txtSegmentation.Enabled = false;


        ddlRelationofPersonContacted.Enabled = false;
        txtOtherRelation.Enabled = false;
        ddlRelationofPersonContacted.Enabled = false;

        txtDeatailsOfProofCollected.Enabled = false;
        txtOthers1.Enabled = false;
        txtOthers2.Enabled = false;
        ddlResiCumoff.Enabled = false;
        ddlResicomoffOwned.Enabled = false;
        ddlSeparateareforOff.Enabled = false;
        ddlIfAppFullTimeEmp.Enabled = false;
        ddlTPCTypeofCompany.Enabled = false;
        ddlTPCTypeofBusiness.Enabled = false;

        txtUntreaceablereason.Enabled = false;

        ddlVerificationconductedat.Enabled = false;
        txtOtherVerificationconductedat.Enabled = false;
        ddlVerificationconductedat.Enabled = false;


        chkDirectoryCheck.Enabled = false; ;


        txtWhoareyourcustomer.Enabled = false;
        txtNeighbour2Name.Enabled = false;
        txtNeighbour2Add.Enabled = false;
        txtCoEstabilshedIn.Enabled = false;
        txtLandmark.Enabled = false;
        txtPerAddress.Enabled = false;
        txtCompanyName.Enabled = false;
        txtTimeCurrOffYrs.Enabled = false;
        txtTimeCurrOffMths.Enabled = false;
        txtOfficeExtn.Enabled = false;
        txtDesgnOfApplicant.Enabled = false;

        txtBusinessNature.Enabled = false;
        txtParticulars.Enabled = false;
        txtAverageMonthlyTurnover.Enabled = false;
        txtVerPhoneNo.Enabled = false;
        txtPhOnApplication.Enabled = false;
        txtNoOfEmployeeTPC.Enabled = false;

        ddlApplMetat.Enabled = false; ;
        txtOtherApplMetat.Enabled = false;
        ddlApplMetat.Enabled = false;

        txtNameofCompany.Enabled = false;
        txtPreviousEmploymentDetails.Enabled = false;
        ddlReputationOffice.Enabled = false;
        txtOfficeAddress.Enabled = false;
        txtPincode.Enabled = false;
           

            ///////---CPV_CC_VERI_OTHER_DETAILS----------------------------------

        txtPersonContact.Enabled = false;
        txtPerAddress.Enabled = false;
        txtFERemark.Enabled = false;
        ddlNegativeArea.Enabled = false;
        ddlOCL.Enabled = false;

        ddlTypeofResi.Enabled = false;
        txtAddOnApplication.Enabled = false;
        txtNoOfYrsPresentAddress.Enabled = false;
        ddlVisibleNameBoard.Enabled = false;
        ddlBusinessStock.Enabled = false;
        ddlBusinessActivity.Enabled = false;

        ddlLocalityOffice.Enabled = false;
        txtAgencyCode.Enabled = false;

        ddlVisitProof.Enabled = false;
        ddlTypeOfJob.Enabled = false;
        ddlTPCDone.Enabled = false;
        txtMobile.Enabled = false;


           
            ////////for CPV_CC_VERI_DETAILS table--------------------

        txtOverallAsst.Enabled = false;
        txtAsstReason.Enabled = false;

        ddlCaseStatus.Enabled = false;
        ddlOutcome.Enabled = false;
        txtDeclineReason.Enabled = false;
        txtCPVscore.Enabled = false;
        txtSupervisorName.Enabled = false;
        txtSupervisorRemark.Enabled = false;

        txtAttemptDate1.Enabled = false;
        txtAttemptTime1.Enabled = false;
        ddlAttemptTimeType1.Enabled = false;
        txtAttemptRemark1.Enabled = false;

        txtAttemptDate2.Enabled = false;
        txtAttemptTime2.Enabled = false;
        ddlAttemptTimeType2.Enabled = false;
        txtAttemptRemark2.Enabled = false;
        txtAttemptDate3.Enabled = false;
        txtAttemptTime3.Enabled = false;
        ddlAttemptTimeType3.Enabled = false;
        txtAttemptRemark3.Enabled = false;



        //Start Reading of fields for City Bank(Dubai)
        
        txtFaxNumber.Enabled=false ;
       
            
            ddlIsThereSecurityGuardForBuildingOffice.Enabled=false;

        
            ddlIsThereReceptionDesk.Enabled=false;

        
            txtHowManyDesksWorkStationsTables.Enabled=false;

        
            ddlIsTradeLicenseOfCompanyDisplayedOnPremises.Enabled=false;

        
            txtNumberOfEmployees.Enabled=false;

        
            txtBranch1Location.Enabled=false;

        
            txtBranch1Telephoneno.Enabled=false;

        
            txtBranch1RentalAmt.Enabled=false;

        
            txtBranch1Faxno.Enabled=false;

        
            txtBranch1ManagerName.Enabled=false;

        
            txtBranch2Location.Enabled=false;

        
            txtBranch2TelephoneNo.Enabled=false;

        
            txtBranch2RentalAmt.Enabled=false;

        
            txtBranch2Faxno.Enabled=false;

        
            txtBranch2ManagerName.Enabled=false;

        
            txtBranch3Location.Enabled=false;

        
            txtBranch3TelephoneNo.Enabled=false;

        
            txtBranch3RentalAmt.Enabled=false;

        
            txtBranch3Faxno.Enabled=false;

        
            txtBranch3ManagerName.Enabled=false;

        //Add two New Fields

        
            txtApplicationNo.Enabled=false;

        
            txtNumberOfBranchesOfficeWarehouse.Enabled=false;

        
            txtSponsor1Name.Enabled=false;

        
            txtType1.Enabled=false;

        
            txtSponsor1TelephoneNo.Enabled=false;

        
            txtSponsor1Address.Enabled=false;

        
            txtSponsor2Name.Enabled=false;

        
            txtType2.Enabled=false;

        
            txtSponsor2TelephoneNo.Enabled=false;
        
            txtSponsor2Address.Enabled=false;

        
            txtSponsor3Name.Enabled=false;

       
            txtType3.Enabled=false;

       
            txtSponsor3TelephoneNo.Enabled=false;

       
            txtSponsor3Address.Enabled=false;

       
            txtNoOfEmpsInSeniorPosition.Enabled=false;

       
            txtNatureOfBusinessSponsor.Enabled=false;

       
            txtProductDealtWith.Enabled=false;
       
            txtBankName1.Enabled=false;

       
            txtTypeOfAccount1.Enabled=false;

       
            txtFacilities1.Enabled=false;

       
            txtBankName2.Enabled=false;

       
            txtTypeOfAccount2.Enabled=false;

       
            txtFacilities2.Enabled=false;

       
            txtBankName3.Enabled=false;

       
            txtTypeOfAccount3.Enabled=false;
       
            txtFacilities3.Enabled=false;

        ///For CityBank In SalesIn Checkboxes---------------------------------------------------

            chkSalesIn.Enabled=false;
        ////-------------------------------------------------------------------- 

        
            txtAvgMonthlyTurnover.Enabled=false;

        
            txtClientList.Enabled=false;

        
            txtImpressionOfOffice.Enabled=false;

       
            ddlCreditAnalystDecision.Enabled=false;

        
            txtCreditAnalystName.Enabled=false;

            txtCreditAnalystDate.Enabled=false;

        
            txtOfficeVerificationNo.Enabled=false;

        
            txtTelephoneBill.Enabled=false;

        
            ddlEmploymentStatus.Enabled=false;

        
            txtYearsInEmploymentBusiness.Enabled=false;

        
            txtCmDesign.Enabled=false;

        
            txtBasicSalary.Enabled=false;

        
            txtTransportAllowance.Enabled=false;

        
            txtHouseRentAllowance.Enabled=false;

        
            txtFixedAllowance.Enabled=false;

        
            txtTotalFixedSalary.Enabled=false;

        
            txtAdditionalComments.Enabled=false;

        
            txtEmploymentConfirmedWith.Enabled=false;

        
            txtEmploymentConfirmedWithDesignation.Enabled=false;

  
            txtDetailsOfTradeLicense.Enabled=false;


            txtTypeOfSalary.Enabled = false;


        //End Reading of fields for City Bank(Dubai) 
        txtPPNormal.Enabled = false;
        txtDOB.Enabled = false;
        txtOtherVisibleNameBoard.Enabled = false;
        txtOtherLocalityOffice.Enabled = false;
        ddlRouteMap.Enabled = false;
        txtExtNo.Enabled = false;
        txtMthsWorkedIn.Enabled = false;
        ddlTypeOfOffice.Enabled = false;
        txtOtherTypeOfOffice.Enabled = false;
        ddlApplicantWorkingAs.Enabled = false;
        txtOtherApplicantWorkingAs.Enabled = false;
        txtOtherIsTradeLicenseOfCompanyDisplayedOnPremises.Enabled = false;
        txtBranch4Location.Enabled = false;
        txtBranch4Telephoneno.Enabled = false;
        txtBranch4RentalAmt.Enabled = false;
        txtBranch4Faxno.Enabled = false;
        txtBranch4ManagerName.Enabled = false;

        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;
                    
               
    }
    private void LikButtonVisibility()
    {
        string verificationTypeCode = hidVerificationTypeCode.Value;
        string[] arrVerificationTypeCode = verificationTypeCode.Split(' ');
        for (int i = 0; i < arrVerificationTypeCode.Length; i++)
        {
            if (arrVerificationTypeCode[i].Length > 0)
            {
                if (verificationType == arrVerificationTypeCode[i].ToString())
                {
                }
                else
                     MatchVerificationType(arrVerificationTypeCode[i].ToString());

            }

        }
    }
    private void MatchVerificationType(string code)
    {
        switch (code)
        {
            case "RV":
                lbRV.Visible = true;
                break;
            case "BV":
                lbBV.Visible = true;
                break;
            case "RT":
                lbRT.Visible = true;
                break;
            case "BT":
                lbBT.Visible = true;
                break;
            case "PRV":
                lbPRV.Visible = true;
                break;
            case "PRTV":
                lbPRTV.Visible = true;
                break;

        }

    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
        
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_BusinessVerificationTelephonic.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbPRTV_Click(object sender, EventArgs e)
    {

    }

    protected void ValidateDeclineCaseStatus(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            if (ddlCaseStatus.SelectedItem.Text.Trim().ToLower() == "decline" || ddlCaseStatus.SelectedItem.Text.Trim().ToLower() == "negative")
            {
                if (ddlOutcome.SelectedItem.Text.Trim().ToLower() == "select")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;                    
                    lblMsg.Text = "Please select Decline code/Outcome.";
                }
                if (txtDeclineReason.Text.Trim() == "")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;                    
                    lblMsg.Text = "Please enter Supervisor Remark.";
                }
            }

        }
    }
}
