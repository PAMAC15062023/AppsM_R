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

public partial class RL_QCBusinessVerification : System.Web.UI.Page
{
    string verificationType = "QBV";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    CRL_VisitVerification objBV = new CRL_VisitVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir

        if (!IsPostBack)
        {
            try
            {
                //To Show the Panels add By Manoj            
                funShowPanel();
                //End
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                CRL_VisitVerification objBV = new CRL_VisitVerification();
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {
                    //if (Session["isEdit"].ToString() != "1")
                    //    ISEditFalse();
                    if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                    {
                        hidMode.Value = Request.QueryString["Mode"].ToString();
                    }
                    if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                    {
                        hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                    }
                    txtPersonMet.Focus();
                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    hidCaseID.Value = sCaseId;
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    hidVerificationTypeID.Value = sVerifyTypeId;

                    Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                    OleDbDataReader oledbReadBV;
                    OleDbDataReader oledbCaseDtl;
                    oledbReadBV = objBV.GetBVDetail(sCaseId, sVerifyTypeId);
                    oledbCaseDtl = objBV.GetCASEDetail(sCaseId, sVerifyTypeId);

                    txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    
                    GetTeleCallLog();

                    if (oledbCaseDtl.Read() == true)
                    {
                        txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                        txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                        txtOfficeAddress.Text = oledbCaseDtl["OFFADDRESS"].ToString();
                        txtOfficeName.Text = oledbCaseDtl["OFF_NAME"].ToString();
                        string sEmpType = "";
                        sEmpType = oledbCaseDtl["EMPLOYEE_TYPE"].ToString();
                        lblHead.Text = "Business Verification" + "-" + sEmpType;

                    }
                    if (oledbReadBV.Read() == true)
                    {
                        txtPersonMet.Text = oledbReadBV["Person_Contacted"].ToString();
                        txtPersonMetDesgn.Text = oledbReadBV["Designation_contacted_person"].ToString();
                        txtAppConfirm.Text = oledbReadBV["PERSON_CONFIRM_ADDRESS"].ToString();
                        txtBusinessName.Text = oledbReadBV["Name_business"].ToString();
                        string sServiceYr = oledbReadBV["No_year_service"].ToString();
                        if (sServiceYr.Trim() != "")
                        {
                            string[] arrServiceYr = sServiceYr.Split('.');
                            txtServiceYear.Text = arrServiceYr[0].ToString();
                            if (arrServiceYr.Length > 1)
                                txtServiceMths.Text = arrServiceYr[1].ToString();
                        }

                        txtAppDesgn.Text = oledbReadBV["Designation"].ToString();
                        txtNumberOfEmployee.Text = oledbReadBV["No_of_emp_seen"].ToString();
                        txtBusinessConstitutency.Text = oledbReadBV["Constitutency_business"].ToString();
                        objBV.TypeOfOffice = oledbReadBV["Type_Office"].ToString();

                        if (objBV.TypeOfOffice != "Owned" && objBV.TypeOfOffice != "Rented" && objBV.TypeOfOffice != "Shared" &&
                            objBV.TypeOfOffice != "Business Cenre" && objBV.TypeOfOffice != "Independent Office" && objBV.TypeOfOffice != "Industry" &&
                            objBV.TypeOfOffice != "Resi cum Office" && objBV.TypeOfOffice != "Small scale/shed" && objBV.TypeOfOffice != "Office complex" && objBV.TypeOfOffice != "Shared Office" &&
                            objBV.TypeOfOffice != "Clinic" && objBV.TypeOfOffice != "Shop" && objBV.TypeOfOffice != "Undeveloped" && objBV.TypeOfOffice != "")
                        {
                            ddlOfficeType.SelectedValue = "Others";
                            txtOtherOfficeType.Text = objBV.TypeOfOffice;
                        }
                        else
                            ddlOfficeType.SelectedValue = objBV.TypeOfOffice;

                        txtLocatingOffice.Text = oledbReadBV["Locating_Office"].ToString();
                        ddlResiCumoff.SelectedValue = oledbReadBV["IS_res_com_office"].ToString();
                        ddlNameBoardSighted.SelectedValue = oledbReadBV["Nam_Plate_sighted"].ToString();
                        ddlBusinessActivity.SelectedValue = oledbReadBV["Business_Activity_seen"].ToString();
                        txtLandmark.Text = oledbReadBV["Landmark"].ToString();
                        txtEquipStockSighted.Text = oledbReadBV["Equipment_Stock_sighted"].ToString();
                        txtJobNature.Text = oledbReadBV["Nature_Job"].ToString();
                        ddlVisitCardProof.SelectedValue = oledbReadBV["VisitingCard_obtained"].ToString();
                        txtRemarks.Text = oledbReadBV["Remarks"].ToString();
                        ddlRating.SelectedValue = oledbReadBV["Rating"].ToString();
                        string sTmp = oledbReadBV["VERIFICATION_DATETIME"].ToString();
                        if (sTmp != "")
                        {
                            string[] arrVerDateTime = sTmp.Split(' ');
                            if (arrVerDateTime[0].ToString() != "")
                                txtDateOfVerification.Text = arrVerDateTime[0].ToString();
                            if (arrVerDateTime[1].ToString() != "")
                                txtTimeOfVerification.Text = arrVerDateTime[1].ToString();
                            if (arrVerDateTime[2].ToString() != "")
                                ddlDateTimeOfVerification.SelectedValue = arrVerDateTime[2].ToString();
                        }

                        txtVerifierName.Text = oledbReadBV["Verifier"].ToString();
                        txtSupervisorName.Text = oledbReadBV["Supervisor"].ToString();
                        ddlMatchinNegativeList.SelectedValue = oledbReadBV["Match_Negative_List"].ToString();
                        txtNameOfBankDefaultWith.Text = oledbReadBV["Name_bank_defaulted"].ToString();
                        txtProductName.Text = oledbReadBV["Product_name"].ToString();
                        txtDefaultInWhichBucket.Text = oledbReadBV["Default_which_bucket"].ToString();
                        txtAmountOfDefaultINR.Text = oledbReadBV["AMT_DEFAULT_INR"].ToString();
                        ddlTelCDRomCheck.SelectedValue = oledbReadBV["Telephone_check"].ToString();
                        txtOffTelNoInNameOf.Text = oledbReadBV["OFF_TELL_NO_NAME"].ToString();
                        txtTelNo.Text = oledbReadBV["Type_oF_Phone"].ToString();
                        txtMobileNo.Text = oledbReadBV["TYPE_OF_MOBILE"].ToString();
                        txtLoanAmount.Text = oledbReadBV["Loan_Amount"].ToString();
                        txtUseOfLoan.Text = oledbReadBV["USE_OF_LOAN"].ToString();
                        txtProduct.Text = oledbReadBV["Product"].ToString();
                        txtLocationOfProduct.Text = oledbReadBV["Location_Product"].ToString();
                        txtDOB.Text = oledbReadBV["DOB"].ToString();
                        ddlMaritalStatus.SelectedValue = oledbReadBV["Marital_Status"].ToString();
                        ddlEducation.SelectedValue = oledbReadBV["Education"].ToString();
                        txtApplicantIncome.Text = oledbReadBV["Applicant_Income"].ToString();
                        txtNoOfYrsAtPrevEmployment.Text = oledbReadBV["No_yrs_previous_Employment"].ToString();
                        txtLoanCancellation.Text = oledbReadBV["Loan_Cancellation"].ToString();
                        ddlAnyCreditCard.SelectedValue = oledbReadBV["Any_credit_card"].ToString();
                        txtAnyOtherLoan.Text = oledbReadBV["Any_other_Loan"].ToString();
                        ddlCityLimit.SelectedValue = oledbReadBV["City_Limit"].ToString();

                        ///For Asset Checkboxes---------------------------------------------------
                        string sTmpAsset = oledbReadBV["Assets_Seen"].ToString();
                        string[] arrAsset = sTmpAsset.Split(',');
                        int iOtherAssetCtr = 0;
                        if (arrAsset.Length > 0)
                        {
                            for (int i = 0; i < arrAsset.Length; i++)
                            {
                                foreach (ListItem li in chkAssets.Items)
                                {
                                    if (li.Value == arrAsset.GetValue(i).ToString())
                                        li.Selected = true;
                                    if (arrAsset.GetValue(i).ToString() == "Others")
                                    {
                                        iOtherAssetCtr = i;
                                    }
                                }
                            }
                        }
                        for (int j = iOtherAssetCtr + 1; j < arrAsset.Length; j++)
                        {
                            txtOtherAssets.Text += arrAsset.GetValue(j) + ",";
                        }
                        ////-------------------------------------------------------------------- 
                        txtDetailsOfFurniture.Text = oledbReadBV["Furniture_seen"].ToString();
                        objBV.Ownership = oledbReadBV["Ownership"].ToString();
                        if (objBV.Ownership != "Self Owned" && objBV.Ownership != "Family Owned" && objBV.Ownership != "Partnership" && objBV.Ownership != "")
                        {
                            ddlOwnership.SelectedValue = "Other";
                            txtOtherOwnership.Text = objBV.Ownership;
                        }
                        else
                            ddlOwnership.SelectedValue = objBV.Ownership;

                        txtLocationOfOffice.Text = oledbReadBV["Location_OFFICE"].ToString();
                        txtApproachToOffice.Text = oledbReadBV["Approach_office"].ToString();
                        txtAreaAroundOffice.Text = oledbReadBV["Area_around_office"].ToString();
                        txtOfficeAmbience.Text = oledbReadBV["Office_Ambience"].ToString();
                        txtOfficeOCL.Text = oledbReadBV["Office_OCL"].ToString();
                        ddlExteriorCondition.SelectedValue = oledbReadBV["Exterior_conditions"].ToString();
                        ddlInteriorCondition.SelectedValue = oledbReadBV["Interior_conditions"].ToString();
                        objBV.IsCompanyNameBoardSeen = oledbReadBV["Company_Name_board_seen"].ToString();
                        if (objBV.IsCompanyNameBoardSeen != "Yes" && objBV.IsCompanyNameBoardSeen != "No" && objBV.IsCompanyNameBoardSeen != "")
                        {
                            ddlCompanyNameBoardSeen.SelectedValue = "Other";
                            txtOtherCompanyNameBoardSeen.Text = objBV.IsCompanyNameBoardSeen;
                        }
                        else
                            ddlCompanyNameBoardSeen.SelectedValue = objBV.IsCompanyNameBoardSeen;

                        ddlIsAddOfAppSame.SelectedValue = oledbReadBV["Is_address_same"].ToString();
                        txtNoOfMember.Text = oledbReadBV["No_of_Members"].ToString();
                        txtNoOfYrsAtCurrentOffice.Text = oledbReadBV["No_of_current_office"].ToString();
                        txtAgeOfApplicant.Text = oledbReadBV["Age_applicant"].ToString();
                        txtNameAddressOfThirdParty.Text = oledbReadBV["Name_add_third_party"].ToString();
                        txtTimeWhenAppIsInOffice.Text = oledbReadBV["TIME_APP_OFFICE"].ToString();
                        txtThirdPartyComment.Text = oledbReadBV["Third_party_Comment"].ToString();
                        ddlIsNegativeArea.SelectedValue = oledbReadBV["Is_Negative_area"].ToString();
                        ddlIsAffilatedToPoliticalParty.SelectedValue = oledbReadBV["affilated_political_party"].ToString();
                        ddlIsBlackArea.SelectedValue = oledbReadBV["IS_black_area"].ToString();
                        txtProfile.Text = oledbReadBV["Profile"].ToString();
                        ddlAgencyRecommandation.SelectedValue = oledbReadBV["Agency_Recommandation"].ToString();
                        txtScoretoolRecomandation.Text = oledbReadBV["Scoretool_Recommandation"].ToString();
                        txtNeighbourName1.Text = oledbReadBV["Name_Neighbour1"].ToString();
                        txtAddOfNeighbour1.Text = oledbReadBV["Address_Neighbour1"].ToString();
                        ddlDoesApplicantWorkHere1.SelectedValue = oledbReadBV["Confirmation_Neighbour1"].ToString();
                        txtMthsOfWorkAtOffice1.Text = oledbReadBV["Month_at_office1"].ToString();
                        ddlMarketReputation1.SelectedValue = oledbReadBV["Market_Reputaion_Neighbour1"].ToString();
                        ddlIsOfficeSelfOwnNeigh1.SelectedValue = oledbReadBV["IS_office_self_Neighbour1"].ToString();
                        txtNeighbourComments1.Text = oledbReadBV["Comments_Neighbour1"].ToString();
                        txtNeighbourName2.Text = oledbReadBV["Name_Neighbour2"].ToString();
                        txtAddOfNeighbour2.Text = oledbReadBV["Address_Neighbour2"].ToString();
                        ddlDoesApplicantWorkHere2.SelectedValue = oledbReadBV["Confirmation_Neighbour2"].ToString();
                        txtMthsOfWorkAtOffice2.Text = oledbReadBV["Month_at_office2"].ToString();
                        ddlMarketReputation2.SelectedValue = oledbReadBV["Market_Reputaion_Neighbour2"].ToString();
                        ddlIsOfficeSelfOwnNeigh2.SelectedValue = oledbReadBV["IS_office_self_Neighbour2"].ToString();
                        txtNeighbourComments2.Text = oledbReadBV["Comments_Neighbour2"].ToString();
                        //ddlLocality.SelectedValue = oledbReadBV["Locality"].ToString();
                        objBV.Locality = oledbReadBV["Locality"].ToString();
                        if (objBV.Locality != "Slum" && objBV.Locality != "Lower Middle" && objBV.Locality != "Upper Class" &&
                            objBV.Locality != "Under developed" && objBV.Locality != "Middle Class" && objBV.Locality != "")
                        {
                            ddlLocality.SelectedValue = "Other";
                            txtOtherLocality.Text = objBV.Locality;
                        }
                        else
                            ddlLocality.SelectedValue = objBV.Locality;

                        ddlAccessibility.SelectedValue = oledbReadBV["Accessibility"].ToString();
                        ddlBusinesBoardSeen.SelectedValue = oledbReadBV["Business_board_sighted"].ToString();
                        ddlEntryPermitted.SelectedValue = oledbReadBV["entry_permited"].ToString();
                        txtApproxArea.Text = oledbReadBV["Aprox_area"].ToString();
                        txtBriefJobResponsibility.Text = oledbReadBV["Brief_Job_Responsibilities"].ToString();
                        ddlBehavourOfPersonContacted.SelectedValue = oledbReadBV["Behavour_person_contacted"].ToString();
                        txtColourOfDoor.Text = oledbReadBV["Colour_Door"].ToString();

                        objBV.TypeOfIndustry = oledbReadBV["Type_Industry"].ToString();
                        if (objBV.TypeOfIndustry != "Huf" && objBV.TypeOfIndustry != "Partnership" && objBV.TypeOfIndustry != "Propritorship" &&
                            objBV.TypeOfIndustry != "Pvt Ltd" && objBV.TypeOfIndustry != "PSU" && objBV.TypeOfIndustry != "")
                        {
                            ddlTypeOfIndustry.SelectedValue = "Other";
                            txtOtherTypeOfIndustry.Text = objBV.TypeOfIndustry;
                        }
                        else
                            ddlTypeOfIndustry.SelectedValue = objBV.TypeOfIndustry;

                        objBV.NatureOfBusiness = oledbReadBV["Nature_Business"].ToString();
                        if (objBV.NatureOfBusiness != "Manufacturing" && objBV.NatureOfBusiness != "Software" && objBV.NatureOfBusiness != "Trading" &&
                            objBV.NatureOfBusiness != "BPO" && objBV.NatureOfBusiness != "Services" && objBV.NatureOfBusiness != "")
                        {
                            ddlNatureOfBusiness.SelectedValue = "Other";
                            txtOtherNatureOfBusiness.Text = objBV.NatureOfBusiness;
                        }
                        else
                            ddlNatureOfBusiness.SelectedValue = objBV.NatureOfBusiness;

                        txtNoOfBranches.Text = oledbReadBV["No_of_branches"].ToString();
                        txtNoOfCustomerPerDay.Text = oledbReadBV["customer_per_day"].ToString();
                        objBV.IfDoctors = oledbReadBV["If_doctors"].ToString();
                        ddlIfDoctors.SelectedValue = objBV.IfDoctors;
                        if (objBV.IfDoctors == "Yes")
                        {
                            txtNoOfPatientsPerDay.Text = oledbReadBV["Patients_per_day"].ToString();
                            txtAvgFeesPerPatients.Text = oledbReadBV["fees_per_Patient"].ToString();
                        }

                        objBV.OtherClinicVisited = oledbReadBV["clinic_visited"].ToString();
                        ddlIfOtherClinicVisited.SelectedValue = objBV.OtherClinicVisited;
                        if (objBV.OtherClinicVisited == "Yes")
                            txtNameOfClinicVisted.Text = oledbReadBV["Name_Clinic"].ToString();

                        objBV.IfArchitectureCA = oledbReadBV["Architecture"].ToString();
                        ddlIfArchitectureCA.SelectedValue = objBV.IfArchitectureCA;
                        if (objBV.IfArchitectureCA == "Yes")
                        {
                            txtIndependentlyYrs.Text = oledbReadBV["How_long_praticing"].ToString();
                            txtKeyClientName1.Text = oledbReadBV["Key_Client1"].ToString();
                            txtKeyClientName2.Text = oledbReadBV["Key_Client2"].ToString();
                            txtKeyClientName3.Text = oledbReadBV["key_Client3"].ToString();
                        }

                        txtOfficeName.Text = oledbReadBV["Office_Name"].ToString();
                        txtOfficeAddress.Text = oledbReadBV["Office_Address"].ToString();
                        txtTypeOfBusinessActivity.Text = oledbReadBV["Business_activity"].ToString();
                        ddlEntraceMotorable.SelectedValue = oledbReadBV["Enterance_Motorable"].ToString();
                        txtRelationWithApplicant.Text = oledbReadBV["Relationship_applicant"].ToString();
                        ddlIdentityProof.SelectedValue = oledbReadBV["Identity_Proof_Seen"].ToString();
                        ddlBusinessProof.SelectedValue = oledbReadBV["Business_Proof_Seen"].ToString();
                        objBV.TypeOfOrganization = oledbReadBV["Type_Organization"].ToString();

                        if (objBV.TypeOfOrganization != "Govt." && objBV.TypeOfOrganization != "PSU" && objBV.TypeOfOrganization != "MNC" &&
                            objBV.TypeOfOrganization != "Pvt. Ltd" && objBV.TypeOfOrganization != "Public Ltd." && objBV.TypeOfOrganization != "Propertorship" &&
                            objBV.TypeOfOrganization != "Partnership" && objBV.TypeOfOrganization != "HUF" && objBV.TypeOfOrganization != "")
                        {
                            ddlTypeOfOrganization.SelectedValue = "Others";
                            txtOtherTypeOfOrganization.Text = objBV.TypeOfOrganization;
                        }
                        else
                            ddlTypeOfOrganization.SelectedValue = objBV.TypeOfOrganization;

                        objBV.OtherInvestment = oledbReadBV["Other_Investment"].ToString();
                        if (objBV.OtherInvestment != "FD" && objBV.OtherInvestment != "Shares" && objBV.OtherInvestment != "Mutual Funds" &&
                            objBV.OtherInvestment != "Jewelry" && objBV.OtherInvestment != "Real Estate" && objBV.OtherInvestment != "")
                        {
                            ddlOtherInvestment.SelectedValue = "Others";
                            txtOtherOtherInvestment.Text = objBV.OtherInvestment;
                        }
                        else
                            ddlOtherInvestment.SelectedValue = objBV.OtherInvestment;
                        txtResidenceAddress.Text = oledbReadBV["Residential_Address"].ToString();
                        txtProofOfBusinessActivity.Text = oledbReadBV["Proof_Buss_Activity"].ToString();


                        objBV.StatusOfOffice = oledbReadBV["Status_Office"].ToString();
                        if (objBV.StatusOfOffice != "Industrial" && objBV.StatusOfOffice != "Residential" && objBV.StatusOfOffice != "Small Shop / Shed" &&
                            objBV.StatusOfOffice != "Business Complex" && objBV.StatusOfOffice != "Underdeveloped" && objBV.StatusOfOffice != "Commercial" &&
                            objBV.StatusOfOffice != "Godown" && objBV.StatusOfOffice != "Plant" && objBV.StatusOfOffice != "")
                        {
                            ddlStatusOfOffice.SelectedValue = "Others";
                            txtOtherStatusOfOffice.Text = objBV.StatusOfOffice;
                        }
                        else
                            ddlStatusOfOffice.SelectedValue = objBV.StatusOfOffice;

                        ddlShiftOfWork.SelectedValue = oledbReadBV["WORK_SHIFT"].ToString();
                        txtVerifierComments.Text = oledbReadBV["Verifier_Comment"].ToString();
                        ddlOverallVerification.SelectedValue = oledbReadBV["Overall_Verification"].ToString();
                        txtTotalNoOfEmployees.Text = oledbReadBV["Total_No_employee"].ToString();
                        txtReasonNotCollectingVistingCard.Text = oledbReadBV["Reason_not_collecting_VC"].ToString();
                        ddlIsOfficeDoorLocked.SelectedValue = oledbReadBV["Office_Door_Locked"].ToString();
                        txtWhereContacted.Text = oledbReadBV["Where_Contacted"].ToString();
                        txtSendDate.Text = oledbReadBV["Sent_Date"].ToString();
                        txtNameOfBank.Text = oledbReadBV["Name_Bank"].ToString();
                        txtPrevOccupationDtl.Text = oledbReadBV["Previous_Employeement_Details"].ToString();
                        txtPrevEmploymentDesgn.Text = oledbReadBV["Previous_Emp_Designation"].ToString();
                        ddlConstructionOfOffice.SelectedValue = oledbReadBV["Construction_Office"].ToString();
                        ddlEasyOfLocatingOffice.SelectedValue = oledbReadBV["Easy_Locating_Office"].ToString();
                        ddlNegmatch.SelectedValue = oledbReadBV["Neg_Match"].ToString();
                        txtReasonForNotRecomdNReferred.Text = oledbReadBV["Reason_Notrecommended"].ToString();
                        txtIfOCLDistance.Text = oledbReadBV["OCL_distance"].ToString();
                        txtAgencyName.Text = oledbReadBV["Agency_name"].ToString();
                        //added new fields on 23-Aug-2007 -------------
                        ddlLevelOfBusinessActivity.SelectedValue = oledbReadBV["Level_Business_Activity"].ToString();
                        ddlIsResiCumOfficeSelfOwned.SelectedValue = oledbReadBV["IS_res_cum_office_self_owned"].ToString();
                        ddlStockSeen.SelectedValue = oledbReadBV["Stock_Seen"].ToString();
                        txtMonthsOfWorkatCurrentOffice.Text = oledbReadBV["Months_work_current_office"].ToString();
                        txtPurposeOfLoanTaken.Text = oledbReadBV["Purpose_loan"].ToString();
                        ///----------------------------------
                        ///added new fields on 03-Oct-2007---------
                        txtNameOfCollegue.Text = oledbReadBV["NAME_COLLEGUE"].ToString();
                        txtDesgnDeptOfCollegue.Text = oledbReadBV["DESGN_DEPT_COLLEGUE"].ToString();
                        string sMthCompExist = oledbReadBV["MONTH_COMP_EXIST_ADDRESS"].ToString();
                        if (sMthCompExist.Trim() != "")
                        {
                            string[] arrMthCompExist = sMthCompExist.Split('.');
                            txtYearOfCompExistance.Text = arrMthCompExist[0].ToString();
                            if (arrMthCompExist.Length > 1)
                                txtMthOfCompExistance.Text = arrMthCompExist[1].ToString();
                        }
                        txtProfileCoAsPerNeighbour.Text = oledbReadBV["PROFILE_CO_NEIGHBOUR"].ToString();
                        objBV.AppNameVerifiedFrom = oledbReadBV["APPLICANT_NAME_VERIFIED_FROM"].ToString();
                        if (objBV.AppNameVerifiedFrom != "Colleauge" && objBV.AppNameVerifiedFrom != "Receptionist" &&
                            objBV.AppNameVerifiedFrom != "Owner" && objBV.AppNameVerifiedFrom != "Guard" && objBV.AppNameVerifiedFrom != "")
                        {
                            ddlAppNameVerifiedFrom.SelectedValue = "Others";
                            txtOtherAppNameVerifiedFrom.Text = objBV.AppNameVerifiedFrom;
                        }
                        else
                            ddlAppNameVerifiedFrom.SelectedValue = objBV.AppNameVerifiedFrom;

                        ddlRoofType.SelectedValue = oledbReadBV["ROOF_TYPE"].ToString();
                        txtSupervisorComments.Text = oledbReadBV["SUPERVISOR_COMMENTS"].ToString();
                        //Added by Manoj Jadhav
                        ddlDifferncesfound.SelectedValue = oledbReadBV["Differncesfound"].ToString();
                        txtActiontaken.Text = oledbReadBV["Actiontaken"].ToString();
                        txtNATUREOFDSCREPANCY.Text = oledbReadBV["NATUREOFDSCREPANCY"].ToString();
                        /////--------------------------------------------------------------------------
                    }
                    oledbReadBV.Close();
                    oledbCaseDtl.Close();
                    if (hidMode.Value == "View")
                    {
                        IfIsEditFalse();
                        LikButtonVisibility();


                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error while retrieving data: " + ex.Message;
            }
        }
    }

    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        DataSet dsTeleCallLog1 = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objBV.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            dsTeleCallLog1 = objBV.GetTeleCallLogDetail1(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATETIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["Attempt_REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat1.SelectedIndex = 0;

                        }
                        else
                        {
                            ddlSubSat1.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATETIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType2.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark2.Text = dsTeleCallLog.Tables[0].Rows[i]["Attempt_REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat2.SelectedIndex = 0;

                        }
                        else
                        {
                            ddlSubSat2.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATETIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType3.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark3.Text = dsTeleCallLog.Tables[0].Rows[i]["Attempt_REMARK"].ToString();
                        if ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                        {
                            ddlSubSat3.SelectedIndex = 0;
                            
                        }
                        else
                        {
                            ddlSubSat3.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["SubRemark"].ToString();
                        }
                    }

                }
            }

            if (dsTeleCallLog1.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        lblsat1.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        lblsat2.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        lblsat3.Text = dsTeleCallLog1.Tables[0].Rows[i]["FullName"].ToString();
                        //ddlVerifierName.Text = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }

                }
            }
        }

    }

    private bool ValidateTextArea()
    {
        bool iValidate = true;
        string sRemark = "";
        string sCommentNeigh1 = "";
        string sCommentNeigh2 = "";
        string sVerifierComment = "";
        string sThirdPartyComment = "";
        sRemark = txtRemarks.Text;
        sCommentNeigh1 = txtNeighbourComments1.Text;
        sCommentNeigh2 = txtNeighbourComments2.Text;
        sVerifierComment = txtVerifierComments.Text;
        sThirdPartyComment = txtThirdPartyComment.Text;

        if (sRemark.Trim() != "")
        {
            if (sRemark.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 255 characters.";
                iValidate = false;
            }
        }

        if (sCommentNeigh1.Trim() != "")
        {
            if (sCommentNeigh1.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sCommentNeigh2.Trim() != "")
        {
            if (sCommentNeigh2.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        if (sVerifierComment.Trim() != "")
        {
            if (sVerifierComment.Length > 750)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Verifier comment should not be greater than 750 characters.";
                iValidate = false;
            }
        }
        if (sThirdPartyComment.Trim() != "")
        {
            if (sThirdPartyComment.Length > 255)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Third party comment should not be greater than 255 characters.";
                iValidate = false;
            }
        }
        return iValidate;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CRL_VisitVerification objBV = new CRL_VisitVerification();
        int iCount = 0;
        string sMsg = "";
        try
        {
            if (ValidateTextArea() == true)
            {
                objBV.CaseId = Request.QueryString["CaseId"].ToString();
                objBV.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
                objBV.NameOfPersonMet = txtPersonMet.Text.Trim();
                objBV.NameOfPersonMetDesgn = txtPersonMetDesgn.Text.Trim();
                objBV.ApplicantWorkedAgGivenAddress = txtAppConfirm.Text.Trim();
                objBV.NameOfBusiness = txtBusinessName.Text.Trim();
                objBV.NoOfYrsInservice = txtServiceYear.Text.Trim() + "." + txtServiceMths.Text.Trim();
                objBV.AppDesignation = txtAppDesgn.Text.Trim();
                objBV.NoOfEmployeeSeen = txtNumberOfEmployee.Text.Trim();
                objBV.ConstitutencyOfBusiness = txtBusinessConstitutency.Text.Trim();
                if (ddlOfficeType.SelectedValue.Trim() != "Others")
                    objBV.TypeOfOffice = ddlOfficeType.SelectedValue.Trim();
                else
                    objBV.TypeOfOffice = txtOtherOfficeType.Text.Trim();

                objBV.LocatingOffice = txtLocatingOffice.Text.Trim();
                objBV.IsResiCumOffice = ddlResiCumoff.SelectedValue.Trim();
                objBV.NameplateOnDoor = ddlNameBoardSighted.SelectedValue.Trim();
                objBV.IsBusinessActivityseen = ddlBusinessActivity.SelectedValue.Trim();
                objBV.Landmark = txtLandmark.Text.Trim();
                objBV.IsEuipStockSighted = txtEquipStockSighted.Text.Trim();
                objBV.NatureOfJob = txtJobNature.Text.Trim();
                objBV.VisitCardAsProofOfVisit = ddlVisitCardProof.SelectedValue.Trim();
                objBV.Remarks = txtRemarks.Text.Trim();
                objBV.Rating = ddlRating.SelectedValue.Trim();
                //CCommon objCmn = new CCommon();
                //string sDateOfVer = "";
                //if (txtDateOfVerification.Text.Trim() != "")
                //    sDateOfVer = objCmn.strDate(txtDateOfVerification.Text.Trim());
                objBV.DateTimeOfVerification = txtDateOfVerification.Text.Trim() + " " + txtTimeOfVerification.Text.Trim() + " " + ddlDateTimeOfVerification.SelectedValue.Trim();
                
                objBV.VerifierName = txtVerifierName.Text.Trim();
                objBV.SupervisorName = txtSupervisorName.Text.Trim();
                objBV.MatchInNegativeList = ddlMatchinNegativeList.SelectedValue.Trim();
                objBV.NameOfBankDefaultedWith = txtNameOfBankDefaultWith.Text.Trim();
                objBV.ProductName = txtProductName.Text.Trim();
                objBV.DefaultInWhichBucket = txtDefaultInWhichBucket.Text.Trim();
                objBV.AmountOfDefaultINR = txtAmountOfDefaultINR.Text.Trim();
                objBV.TeleCDRomCheck = ddlTelCDRomCheck.SelectedValue.Trim();
                objBV.OffTelNoInNameOf = txtOffTelNoInNameOf.Text.Trim();
                objBV.TeleNoType = txtTelNo.Text.Trim();
                objBV.MobileNoType = txtMobileNo.Text.Trim();
                objBV.LoanAmount = txtLoanAmount.Text.Trim();
                objBV.UseOfLoan = txtUseOfLoan.Text.Trim();
                objBV.Product = txtProduct.Text.Trim();
                objBV.LocationOfProduct = txtLocationOfProduct.Text.Trim();
                objBV.DateOfBirth = txtDOB.Text.Trim();
                objBV.MaritalStatus = ddlMaritalStatus.SelectedValue.Trim();
                objBV.Education = ddlEducation.SelectedValue.Trim();
                objBV.ApplicantIncome = txtApplicantIncome.Text.Trim();
                objBV.NoOfYrsAtPrevEmployment = txtNoOfYrsAtPrevEmployment.Text.Trim();
                objBV.LoanCancellation = txtLoanCancellation.Text.Trim();
                objBV.AnyCreditCard = ddlAnyCreditCard.SelectedValue.Trim();
                objBV.AnyOtherLoan = txtAnyOtherLoan.Text.Trim();
                objBV.CityLimit = ddlCityLimit.SelectedValue.Trim(); 

                string sAssets = "";
                if (chkAssets.Items.Count > 0)
                {
                    foreach (ListItem li in chkAssets.Items)
                    {
                        if (li.Text.Trim() == "Others" && li.Selected == true)
                            sAssets += li.Value + "," + txtOtherAssets.Text.Trim();
                        else
                            if (li.Selected == true)
                                sAssets += li.Value + ",";
                    }
                }
                objBV.Assets = sAssets.TrimEnd(',');
                objBV.DetailsOfFurnitureSeen = txtDetailsOfFurniture.Text.Trim();
                if (ddlOwnership.SelectedValue.Trim() != "Other")
                    objBV.Ownership = ddlOwnership.SelectedValue.Trim();
                else
                    objBV.Ownership = txtOtherOwnership.Text.Trim();

                objBV.LocationOfOffice = txtLocationOfOffice.Text.Trim();
                objBV.ApproachToOffice = txtApproachToOffice.Text.Trim();
                objBV.AreaAroundOffice = txtAreaAroundOffice.Text.Trim();

                objBV.OfficeAmbience = txtOfficeAmbience.Text.Trim();
                objBV.OfficeOCL = txtOfficeOCL.Text.Trim();
                objBV.ExteriorConditions = ddlExteriorCondition.SelectedValue.Trim();
                objBV.InteriorConditions = ddlInteriorCondition.SelectedValue.Trim();
                if (ddlCompanyNameBoardSeen.SelectedValue.Trim() != "Other")
                    objBV.IsCompanyNameBoardSeen = ddlCompanyNameBoardSeen.SelectedValue.Trim();
                else
                    objBV.IsCompanyNameBoardSeen = txtOtherCompanyNameBoardSeen.Text.Trim();
                objBV.IsAddOfAppSame = ddlIsAddOfAppSame.SelectedValue.Trim();
                objBV.NoOfMembers = txtNoOfMember.Text.Trim();
                objBV.NoOfYrsAtCurrentOffice = txtNoOfYrsAtCurrentOffice.Text.Trim();
                objBV.AgeOfApplicant = txtAgeOfApplicant.Text.Trim();
                objBV.NameAddOfThirdParty = txtNameAddressOfThirdParty.Text.Trim();
                objBV.TimeWhenAppIsInOffice = txtTimeWhenAppIsInOffice.Text.Trim();
                objBV.ThirdPartyComments = txtThirdPartyComment.Text.Trim();
                objBV.IsNegativeArea = ddlIsNegativeArea.SelectedValue.Trim();
                objBV.IsAffilatedToPoliticalParty = ddlIsAffilatedToPoliticalParty.SelectedValue.Trim();
                objBV.BlackArea = ddlIsBlackArea.SelectedValue.Trim();
                objBV.Profile = txtProfile.Text.Trim();
                objBV.AgencyRecommandation = ddlAgencyRecommandation.SelectedValue.Trim();
                objBV.ScoretoolRecommandation = txtScoretoolRecomandation.Text.Trim();
                objBV.NameOfNeighbour1 = txtNeighbourName1.Text.Trim();
                objBV.AddressOfNeighbour1 = txtAddOfNeighbour1.Text.Trim();
                objBV.DoesAppWorkHere1 = ddlDoesApplicantWorkHere1.SelectedValue.Trim();
                objBV.MthsOfWorkAtOffice1 = txtMthsOfWorkAtOffice1.Text.Trim();
                objBV.MarketReputation1 = ddlMarketReputation1.SelectedValue.Trim();
                objBV.IsOfficeSelfOwnedNeigh1 = ddlIsOfficeSelfOwnNeigh1.SelectedValue.Trim();
                objBV.CommentsOfNeighbour1 = txtNeighbourComments1.Text.Trim();
                objBV.NameOfNeighbour2 = txtNeighbourName2.Text.Trim();
                objBV.AddressOfNeighbour2 = txtAddOfNeighbour2.Text.Trim();
                objBV.DoesAppWorkHere2 = ddlDoesApplicantWorkHere2.SelectedValue.Trim();
                objBV.MthsOfWorkAtOffice2 = txtMthsOfWorkAtOffice2.Text.Trim();
                objBV.IsOfficeSelfOwnedNeigh2 = ddlIsOfficeSelfOwnNeigh2.SelectedValue.Trim();
                objBV.MarketReputation2 = ddlMarketReputation2.SelectedValue.Trim();
                objBV.CommentsOfNeighbour2 = txtNeighbourComments2.Text.Trim();
                //objBV.Locality = ddlLocality.SelectedItem.Text.Trim();
                if (ddlLocality.SelectedValue.Trim() != "Other")
                    objBV.Locality = ddlLocality.SelectedValue.Trim();
                else
                    objBV.Locality = txtOtherLocality.Text.Trim();

                objBV.Accessibility = ddlAccessibility.SelectedValue.Trim();
                objBV.BusinessBoardSighted = ddlBusinesBoardSeen.SelectedValue.Trim();
                objBV.EntryPermitted = ddlEntryPermitted.SelectedValue.Trim();
                objBV.ApproximateArea = txtApproxArea.Text.Trim();
                objBV.BriefJobResponsibilities = txtBriefJobResponsibility.Text.Trim();
                objBV.BehavourOfPersonContact = ddlBehavourOfPersonContacted.SelectedValue.Trim();
                objBV.ClourOnDoor = txtColourOfDoor.Text.Trim();
                if (ddlTypeOfIndustry.SelectedValue.Trim() != "Other")
                    objBV.TypeOfIndustry = ddlTypeOfIndustry.SelectedValue.Trim();
                else
                    objBV.TypeOfIndustry = txtOtherTypeOfIndustry.Text.Trim();
                if (ddlNatureOfBusiness.SelectedValue.Trim()!= "Other")
                    objBV.NatureOfBusiness = ddlNatureOfBusiness.SelectedValue.Trim();
                else
                    objBV.NatureOfBusiness = txtOtherNatureOfBusiness.Text.Trim();

                objBV.NoOfBranches = txtNoOfBranches.Text.Trim();
                objBV.NoOfCustomerPerDay = txtNoOfCustomerPerDay.Text.Trim();

                objBV.IfDoctors = ddlIfDoctors.SelectedValue.Trim();
                if (objBV.IfDoctors == "Yes")
                {
                    objBV.NoOfPatientsPerDay = txtNoOfPatientsPerDay.Text.Trim();
                    objBV.AvgFeePerPatient = txtAvgFeesPerPatients.Text.Trim();
                }
                objBV.OtherClinicVisited = ddlIfOtherClinicVisited.SelectedValue.Trim();
                if (objBV.OtherClinicVisited == "Yes")
                    objBV.NameOfClinic = txtNameOfClinicVisted.Text.Trim();

                objBV.IfArchitectureCA = ddlIfArchitectureCA.SelectedValue.Trim();
                if (objBV.IfArchitectureCA == "Yes")
                {
                    objBV.IndependentlyYrs = txtIndependentlyYrs.Text.Trim();
                    objBV.KeyClientName1 = txtKeyClientName1.Text.Trim();
                    objBV.KeyClientName2 = txtKeyClientName2.Text.Trim();
                    objBV.KeyClientName3 = txtKeyClientName3.Text.Trim();
                }
                objBV.OfficeName = txtOfficeName.Text.Trim();
                objBV.OfficeAddress = txtOfficeAddress.Text.Trim();
                objBV.TypeOfBusinessActivity = txtTypeOfBusinessActivity.Text.Trim();
                objBV.EntranceMotorable = ddlEntraceMotorable.SelectedValue.Trim();
                objBV.RelationWithApplicant = txtRelationWithApplicant.Text.Trim();
                objBV.IsIdentityProofSeen = ddlIdentityProof.SelectedValue.Trim();

                objBV.IsBusinessProofSeen = ddlBusinessProof.SelectedValue.Trim();
                if (ddlOtherInvestment.SelectedValue.Trim() != "Others")
                    objBV.OtherInvestment = ddlOtherInvestment.SelectedValue.Trim();
                else
                    objBV.OtherInvestment = txtOtherOtherInvestment.Text.Trim();

                objBV.ProofOfBusinessActivity = txtProofOfBusinessActivity.Text.Trim();
                objBV.ResidenceAddress = txtResidenceAddress.Text.Trim();
                //new added fields

                if (ddlTypeOfOrganization.SelectedValue.Trim() != "Others")
                    objBV.TypeOfOrganization = ddlTypeOfOrganization.SelectedValue.Trim();
                else
                    objBV.TypeOfOrganization = txtOtherTypeOfOrganization.Text.Trim();
                if (ddlStatusOfOffice.SelectedValue.Trim() != "Others")
                    objBV.StatusOfOffice = ddlStatusOfOffice.SelectedValue.Trim();
                else
                    objBV.StatusOfOffice = txtOtherStatusOfOffice.Text.Trim();

                objBV.ShifOfWork = ddlShiftOfWork.SelectedValue.Trim();
                objBV.IsBusinessProofSeen = ddlBusinessProof.SelectedValue.Trim();
                //objBV.OtherInvestment = ddlOtherInvestment.SelectedValue.Trim();
                objBV.VerifierComments = txtVerifierComments.Text.Trim();
                objBV.ProofOfBusinessActivity = txtProofOfBusinessActivity.Text.Trim();
                objBV.OverallVerification = ddlOverallVerification.SelectedValue.Trim();
                objBV.TotalNoOfEmployees = txtTotalNoOfEmployees.Text.Trim();
                objBV.ReasonNotCollectingVistingCard = txtReasonNotCollectingVistingCard.Text.Trim();
                objBV.IsOfficeDoorLocked = ddlIsOfficeDoorLocked.SelectedValue.Trim();
                objBV.WhereContacted = txtWhereContacted.Text.Trim();
                objBV.SendDate = txtSendDate.Text.Trim();
                objBV.NameOfBank = txtNameOfBank.Text.Trim();
                objBV.DetailOfPreviousOccupation = txtPrevOccupationDtl.Text.Trim();
                objBV.PrevEmploymentDesgn = txtPrevEmploymentDesgn.Text.Trim();
                objBV.ConstructionOfOffice = ddlConstructionOfOffice.SelectedValue.Trim();
                objBV.EasyOfLocatingOffice = ddlEasyOfLocatingOffice.SelectedValue.Trim();
                objBV.Negmatch = ddlNegmatch.SelectedValue.Trim();
                objBV.ReasonForNotRecomdNReferred = txtReasonForNotRecomdNReferred.Text.Trim();
                objBV.IfOCLDistance = txtIfOCLDistance.Text.Trim();
                objBV.AgencyCode = txtAgencyName.Text.Trim();
                //for new fields added--------
                objBV.LevelOfBusActivity = ddlLevelOfBusinessActivity.SelectedValue.Trim();
                objBV.IsResiCumOfficeSelfOwned = ddlIsResiCumOfficeSelfOwned.SelectedValue.Trim();
                objBV.StockSeen = ddlStockSeen.SelectedValue.Trim();
                objBV.MthOfWorkCurrentOffice = txtMonthsOfWorkatCurrentOffice.Text.Trim();
                objBV.PurposeOfLoanTaken = txtPurposeOfLoanTaken.Text.Trim();
                //added by hemangi kambli on 07/09/2007--------------
                objBV.AddedBy = Session["UserId"].ToString();
                objBV.AddedOn = DateTime.Now;
                objBV.ModifyBy = Session["UserId"].ToString();
                objBV.ModifyOn = DateTime.Now;
                ///------------------------------------------------------
                /// //Added by hemangi kambli on 01/10/2007 
                if (hdnTransStart.Value != "")
                    objBV.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objBV.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
                objBV.CentreId = Session["CentreId"].ToString();
                objBV.ProductId = Session["ProductId"].ToString();
                objBV.ClientId = Session["ClientId"].ToString();
                objBV.UserId = Session["UserId"].ToString();
                ///------------------------------------------------------
                ////// //Added by hemangi kambli on 03/10/2007 -----------
                objBV.NameOfCollegue = txtNameOfCollegue.Text.Trim();
                objBV.DesgnDeptCollegue = txtDesgnDeptOfCollegue.Text.Trim();
                objBV.MthOfCompExistAtAddress = txtYearOfCompExistance.Text.Trim() + "." + txtMthOfCompExistance.Text.Trim();
                objBV.ProfileCoNeighbour = txtProfileCoAsPerNeighbour.Text.Trim();
                if (ddlAppNameVerifiedFrom.SelectedValue.ToString() != "Others")
                    objBV.AppNameVerifiedFrom = ddlAppNameVerifiedFrom.SelectedValue.ToString();
                else
                    objBV.AppNameVerifiedFrom = txtOtherAppNameVerifiedFrom.Text.Trim();
                objBV.SupervisorComment = txtSupervisorComments.Text.Trim();
                objBV.RoofType = ddlRoofType.SelectedValue.ToString();
                //----------------------------------------------------------
                //Added by Manoj Jadhav
                objBV.Differncesfound = ddlDifferncesfound.SelectedValue.ToString();
                objBV.Actiontaken = txtActiontaken.Text.Trim();
                objBV.NATUREOFDSCREPANCY = txtNATUREOFDSCREPANCY.Text.Trim();
                //Ended by Manoj
                sMsg = objBV.InsertUpdateRLBusiVerificationEntry();
                InsertTeleCallLog();

                if (sMsg != "")
                {
                    pnlMsg.Visible = true;
                    tblMsg.Visible = true;
                    lblMsg.Text = sMsg.Trim();
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    iCount = 1;
                }
            }
        }
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }
    if (iCount == 1)
    {
        Response.Redirect("RL_QCVerificationView.aspx?Msg=" + lblMsg.Text);
    }

    }

    private void InsertTeleCallLog()
    {
        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objBV.CaseId = strCaseID;

            objBV.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            CCommon objCom = new CCommon();
            if (txtDate1.Text.Trim() != "" && txtTime1.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1.Text.Trim()) + " " + txtTime1.Text.Trim() + " " + ddlTimeType1.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtRemark1.Text.Trim());
                arrLog1stCall.Add(ddlSubSat1.SelectedValue.ToString());
                arrLog1stCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2.Text.Trim() != "" && txtTime2.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2.Text.Trim()) + " " + txtTime2.Text.Trim() + " " + ddlTimeType2.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(txtRemark2.Text.Trim());
                arrLog2ndCall.Add(ddlSubSat2.SelectedValue.ToString());
                arrLog2ndCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3.Text.Trim() != "" && txtTime3.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3.Text.Trim()) + " " + txtTime3.Text.Trim() + " " + ddlTimeType3.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(txtRemark3.Text.Trim());
                arrLog3rdCall.Add(ddlSubSat3.SelectedValue.ToString());
                arrLog3rdCall.Add(hidVerifierID.Value);
                arrTeleCallLog.Add(arrLog3rdCall);
            }


            if (objBV.InsertTeleCallLog(arrTeleCallLog) == 1)
            {


            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCVerificationView.aspx");
    }

    protected void ddlOverallVerification_DataBound(object sender, EventArgs e)
    {
        ddlOverallVerification.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void cvSelectddlOverallVerification_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please select Overall Verification.";
        }
    }

    public void funShowPanel()
    {
        CGet objCGet = new CGet();        
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
                    objPlaceHolder = (PlaceHolder)(tblBusiVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblBusiVerification.Rows[1].Cells[0].FindControl(strPanelName));
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
    private void LikButtonVisibility()
    {
        string verificationTypeCode = hidVerificationTypeCode.Value;
        string[] arrVerificationTypeCode = verificationTypeCode.Split(' ');
        for (int i = 0; i < arrVerificationTypeCode.Length; i++)
        {
            if (arrVerificationTypeCode[i].Length > 0)
            {
                if ( verificationType == arrVerificationTypeCode[i].ToString())
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
            case "QRV":
                lbRV.Visible = true;
                break;
            case "QBV":
                lbBV.Visible = true;
                break;
            case "QRT":
                lbRT.Visible = true;
                break;
            case "QBT":
                lbBT.Visible = true;
                break;
            case "PRV":
                lbPRV.Visible = true;
                break;
            case "REF1":
                lbREF1.Visible = true;
                break;
            case "REF2":
                lbREF2.Visible = true;
                break;
            case "RCO":
                lbRCO.Visible = true;
                break;

        }

    }
    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCBusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCResidenceTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_QCBusinessTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbPRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=10&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbREF1_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_REF1Verification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=12&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }
    protected void lbREF2_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_REF2Verification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=13&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");

    }

    protected void lbRCO_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResiCumBusiness.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=14&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    private void IfIsEditFalse()
    {
            txtLanNo.Enabled=false;
            txtAppName.Enabled=false;
            txtOfficeAddress.Enabled=false;
            txtOfficeName.Enabled=false;
            lblHead.Enabled=false;
            txtPersonMet.Enabled=false;
            txtPersonMetDesgn.Enabled=false;
            txtAppConfirm.Enabled=false;
            txtBusinessName.Enabled = false;
            txtServiceYear.Enabled=false;
            txtServiceMths.Enabled=false;
            txtAppDesgn.Enabled=false;
            txtNumberOfEmployee.Enabled=false;
            txtBusinessConstitutency.Enabled=false;
            ddlOfficeType.Enabled=false;
            txtOtherOfficeType.Enabled=false;
            txtLocatingOffice.Enabled=false;
            ddlResiCumoff.Enabled=false;
            ddlNameBoardSighted.Enabled=false;
            ddlBusinessActivity.Enabled=false;
            txtLandmark.Enabled=false;
            txtEquipStockSighted.Enabled=false;
            txtJobNature.Enabled=false;
            ddlVisitCardProof.Enabled=false;
            txtRemarks.Enabled=false;
            ddlRating.Enabled=false;
            ddlCityLimit.Enabled = false;
            txtDateOfVerification.Enabled=false;
            txtTimeOfVerification.Enabled=false;
            ddlDateTimeOfVerification.Enabled=false;
            txtVerifierName.Enabled=false;
            txtSupervisorName.Enabled=false;
            ddlMatchinNegativeList.Enabled=false;
            txtNameOfBankDefaultWith.Enabled=false;
            txtProductName.Enabled=false;
            txtDefaultInWhichBucket.Enabled=false;
            txtAmountOfDefaultINR.Enabled=false;
            ddlTelCDRomCheck.Enabled=false;
            txtOffTelNoInNameOf.Enabled=false;
            txtTelNo.Enabled=false;
            txtMobileNo.Enabled=false;
            txtLoanAmount.Enabled=false;
            txtUseOfLoan.Enabled=false;
            txtProduct.Enabled=false;
            txtLocationOfProduct.Enabled=false;
            txtDOB.Enabled=false;
            ddlMaritalStatus.Enabled=false;
            ddlEducation.Enabled=false;
            txtApplicantIncome.Enabled=false;
            txtNoOfYrsAtPrevEmployment.Enabled=false;
            txtLoanCancellation.Enabled=false;
            ddlAnyCreditCard.Enabled=false;
            txtAnyOtherLoan.Enabled=false;

            ///For Asset Checkboxes---------------------------------------------------
                    chkAssets.Enabled=false;
                txtOtherAssets.Enabled=false;
            ////-------------------------------------------------------------------- 
            txtDetailsOfFurniture.Enabled=false;
            ddlOwnership.Enabled=false;
            txtOtherOwnership.Enabled=false;
            ddlOwnership.Enabled=false;
            txtLocationOfOffice.Enabled=false;
            txtApproachToOffice.Enabled=false;
            txtAreaAroundOffice.Enabled=false;
            txtOfficeAmbience.Enabled=false;
            txtOfficeOCL.Enabled=false;
            ddlExteriorCondition.Enabled=false;
            ddlInteriorCondition.Enabled=false;
            ddlCompanyNameBoardSeen.Enabled=false;
            txtOtherCompanyNameBoardSeen.Enabled=false;
            ddlIsAddOfAppSame.Enabled=false;
            txtNoOfMember.Enabled=false;
            txtNoOfYrsAtCurrentOffice.Enabled=false;
            txtAgeOfApplicant.Enabled=false;
            txtNameAddressOfThirdParty.Enabled=false;
            txtTimeWhenAppIsInOffice.Enabled=false;
            txtThirdPartyComment.Enabled=false;
            ddlIsNegativeArea.Enabled=false;
            ddlIsAffilatedToPoliticalParty.Enabled=false;
            ddlIsBlackArea.Enabled=false;
            txtProfile.Enabled=false;
            ddlAgencyRecommandation.Enabled=false;
            txtScoretoolRecomandation.Enabled=false;
            txtNeighbourName1.Enabled=false;
            txtAddOfNeighbour1.Enabled=false;
            ddlDoesApplicantWorkHere1.Enabled=false;
            txtMthsOfWorkAtOffice1.Enabled=false;
            ddlMarketReputation1.Enabled=false;
            ddlIsOfficeSelfOwnNeigh1.Enabled=false;
            txtNeighbourComments1.Enabled=false;
            txtNeighbourName2.Enabled=false;
            txtAddOfNeighbour2.Enabled=false;
            ddlDoesApplicantWorkHere2.Enabled=false;
            txtMthsOfWorkAtOffice2.Enabled=false;
            ddlMarketReputation2.Enabled=false;
            ddlIsOfficeSelfOwnNeigh2.Enabled=false;
            txtNeighbourComments2.Enabled=false;
            ddlLocality.Enabled=false;
            txtOtherLocality.Enabled=false;
            ddlAccessibility.Enabled=false;
            ddlBusinesBoardSeen.Enabled=false;
            ddlEntryPermitted.Enabled=false;
            txtApproxArea.Enabled=false;
            txtBriefJobResponsibility.Enabled=false;
            ddlBehavourOfPersonContacted.Enabled=false;
            txtColourOfDoor.Enabled=false;
                ddlTypeOfIndustry.Enabled=false;
                txtOtherTypeOfIndustry.Enabled=false;
                ddlNatureOfBusiness.Enabled=false;
                txtOtherNatureOfBusiness.Enabled=false;
            txtNoOfBranches.Enabled=false;
            txtNoOfCustomerPerDay.Enabled=false;
            ddlIfDoctors.Enabled=false;
                txtNoOfPatientsPerDay.Enabled=false;
                txtAvgFeesPerPatients.Enabled=false;
            ddlIfOtherClinicVisited.Enabled=false;
           txtNameOfClinicVisted.Enabled=false;
            ddlIfArchitectureCA.Enabled=false;
            txtIndependentlyYrs.Enabled=false;
                txtKeyClientName1.Enabled=false;
                txtKeyClientName2.Enabled=false;
                txtKeyClientName3.Enabled=false;
            txtOfficeName.Enabled=false;
            txtOfficeAddress.Enabled=false;
            txtTypeOfBusinessActivity.Enabled=false;
            ddlEntraceMotorable.Enabled=false;
            txtRelationWithApplicant.Enabled=false;
            ddlIdentityProof.Enabled=false;
            ddlBusinessProof.Enabled=false;
                ddlTypeOfOrganization.Enabled=false;
                txtOtherTypeOfOrganization.Enabled=false;
                ddlTypeOfOrganization.Enabled=false;
                ddlOtherInvestment.Enabled=false;
                txtOtherOtherInvestment.Enabled=false;
            txtResidenceAddress.Enabled=false;
            txtProofOfBusinessActivity.Enabled=false;
                ddlStatusOfOffice.Enabled=false;
                txtOtherStatusOfOffice.Enabled=false;
            ddlShiftOfWork.Enabled=false;
            txtVerifierComments.Enabled=false;
            ddlOverallVerification.Enabled=false;
            txtTotalNoOfEmployees.Enabled=false;
            txtReasonNotCollectingVistingCard.Enabled=false;
            ddlIsOfficeDoorLocked.Enabled=false;
            txtWhereContacted.Enabled=false;
            txtSendDate.Enabled=false;
            txtNameOfBank.Enabled=false;
            txtPrevOccupationDtl.Enabled=false;
            txtPrevEmploymentDesgn.Enabled=false;
            ddlConstructionOfOffice.Enabled=false;
            ddlEasyOfLocatingOffice.Enabled=false;
            ddlNegmatch.Enabled=false;
            txtReasonForNotRecomdNReferred.Enabled=false;
            txtIfOCLDistance.Enabled=false;
            txtAgencyName.Enabled=false;
            //added new fields on 23-Aug-2007 -------------
            ddlLevelOfBusinessActivity.Enabled=false;
            ddlIsResiCumOfficeSelfOwned.Enabled=false;
            ddlStockSeen.Enabled=false;
            txtMonthsOfWorkatCurrentOffice.Enabled=false;
            txtPurposeOfLoanTaken.Enabled=false;
            ///----------------------------------
            ///added new fields on 03-Oct-2007---------
            txtNameOfCollegue.Enabled=false ;
            txtDesgnDeptOfCollegue.Enabled=false;
             txtYearOfCompExistance.Enabled=false;
                    txtMthOfCompExistance.Enabled=false;
            txtProfileCoAsPerNeighbour.Enabled=false;
          ddlAppNameVerifiedFrom.Enabled=false;
                txtOtherAppNameVerifiedFrom.Enabled=false;
            ddlRoofType.Enabled=false;
            txtSupervisorComments.Enabled = false;
            txtNATUREOFDSCREPANCY.Enabled = false;
            btnCancel.Enabled = false;
            btnSubmit.Enabled = false;
            /////--------------------------------------------------------------------------
        }
    }



