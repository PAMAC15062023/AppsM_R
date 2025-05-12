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

public partial class RL_BusinessVerification : System.Web.UI.Page
{
    string verificationType = "BV";
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
        
        //NIKHIL 29 august 2013 : adding to change text in reqd panels
        if (Session["ClientId"].ToString() == "101240" && Session["zone"].ToString() == "Mumbai")
        {
            lblThirdPartyComment.Text = "Negative Feedback from colleague ";
            lblOffDeci.Text = "SHFL officers decision";
        }

        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }
        //NIKHIL END
        if (!IsPostBack)
        {
            try
            {
                Get_Areaname();
                GetSupervisorList();//Added by nikhil 17 oct 2013 to get supervisor names in ddl
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
                    OleDbDataReader oledbarea;


                    oledbarea = objBV.GetFEArea(sCaseId, sVerifyTypeId);
                    oledbReadBV = objBV.GetBVDetail(sCaseId, sVerifyTypeId);
                    oledbCaseDtl = objBV.GetCASEDetail(sCaseId, sVerifyTypeId);

                    txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    
                    GetTeleCallLog();


                    if (oledbarea.Read() == true)
                    {


                        if (oledbarea["PincodeArea_Name"].ToString() == "")
                        {
                        }
                        else
                        {
                            btnPincode.Visible = false;
                            txtAreapincode.Visible = false;
                            ddlAreaname.Visible = true;
                            ddlAreaname.SelectedItem.Text = oledbarea["PincodeArea_Name"].ToString();
                        }

                    }
                    if (oledbCaseDtl.Read() == true)
                    {
                        txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                        txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                        txtOfficeAddress.Text = oledbCaseDtl["OFFADDRESS"].ToString();
                        txtOfficeName.Text = oledbCaseDtl["OFF_NAME"].ToString();
                        string sEmpType = "";
                        sEmpType = oledbCaseDtl["EMPLOYEE_TYPE"].ToString();
                        lblHead.Text = "Business Verification" + "-" + sEmpType;
                        ddlAppType.SelectedItem.Text = oledbCaseDtl["App_Type"].ToString();

                    }
                    if (oledbReadBV.Read() == true)
                    {
                        ddlcrossinformation.SelectedValue = oledbReadBV["Crossverifiedinformation"].ToString();
                        txtIfNegProduct.Text = oledbReadBV["IfNegProduct"].ToString();
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
                        //ddlNumberOfEmployee.SelectedValue = oledbReadBV["No_of_emp_seen"].ToString();

                        //new add
                        string sNumberOfEmployee = oledbReadBV["No_of_emp_seen"].ToString();
                        if (sNumberOfEmployee.Trim() != "")
                        {
                            string[] arrNumberOfEmployee = sNumberOfEmployee.Split(':');
                            if (arrNumberOfEmployee.Length > 0)
                            {
                                if (arrNumberOfEmployee[0].ToString() == "others" && arrNumberOfEmployee.Length > 1)
                                {
                                    ddlNumberOfEmployee.SelectedValue = "others";
                                    txtotherNumberOfEmployee.Text = arrNumberOfEmployee[1].ToString();
                                }
                                else
                                {
                                    ddlNumberOfEmployee.SelectedValue = arrNumberOfEmployee[0].ToString();
                                }
                            }
                        }

                        //comp
                        txtBusinessConstitutency.Text = oledbReadBV["Constitutency_business"].ToString();
                        //---Commented by kamal matekar ....
                        //objBV.TypeOfOffice = oledbReadBV["Type_Office"].ToString();

                        //if (objBV.TypeOfOffice != "Owned" && objBV.TypeOfOffice != "Rented" && objBV.TypeOfOffice != "Shared" &&
                        //    objBV.TypeOfOffice != "Business Centre" && objBV.TypeOfOffice != "Independent Office" && objBV.TypeOfOffice != "Industry" &&
                        //    objBV.TypeOfOffice != "Resi cum Office" && objBV.TypeOfOffice != "Small scale/shed" && objBV.TypeOfOffice != "Office complex" && objBV.TypeOfOffice != "Shared Office" &&
                        //    objBV.TypeOfOffice != "Clinic" && objBV.TypeOfOffice != "Showroom" && objBV.TypeOfOffice != "Shop" && objBV.TypeOfOffice != "Undeveloped" && objBV.TypeOfOffice != "")
                        //{
                        //    ddlOfficeType.SelectedValue = "Others";
                        //    txtOtherOfficeType.Text = objBV.TypeOfOffice;
                        //}
                        //else
                        //    ddlOfficeType.SelectedValue = objBV.TypeOfOffice;

                        string sTypeOffice = oledbReadBV["Type_Office"].ToString();
                        if (sTypeOffice.Trim() != "")
                        {
                            string[] arrTypeOffice = sTypeOffice.Split(':');
                            if (arrTypeOffice.Length > 0)
                            {
                                if (arrTypeOffice[0].ToString() == "Other" && arrTypeOffice.Length > 1)
                                {
                                    ddlOfficeType.SelectedValue = "Others";
                                    txtOtherOfficeType.Text = arrTypeOffice[1].ToString();
                                }
                                else
                                {
                                    ddlOfficeType.SelectedValue = arrTypeOffice[0].ToString();
                                }
                            }
                        }

                        ddlLocatingOffice.SelectedValue = oledbReadBV["Locating_Office"].ToString();
                        ddlResiCumoff.SelectedValue = oledbReadBV["IS_res_com_office"].ToString();
                        ddlNameBoardSighted.SelectedValue = oledbReadBV["Nam_Plate_sighted"].ToString();
                        ddlBusinessActivity.SelectedValue = oledbReadBV["Business_Activity_seen"].ToString();
                        txtLandmark.Text = oledbReadBV["Landmark"].ToString();
                        txtEquipStockSighted.Text = oledbReadBV["Equipment_Stock_sighted"].ToString();
                        txtJobNature.Text = oledbReadBV["Nature_Job"].ToString();
                        ddlVisitCardProof.SelectedValue = oledbReadBV["VisitingCard_obtained"].ToString();
                        txtRemarks.Text = oledbReadBV["Remarks"].ToString();
                        ddlRating.SelectedValue = oledbReadBV["Rating"].ToString();
                        txtproductdealingin.Text = oledbReadBV["particulars"].ToString();

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
                        //age_applicant,education,type_office,market_reputaion_neighbour1,assets_seen,off_name,customer_seen 
                        txtVerifierName.Text = oledbReadBV["Verifier"].ToString();
                        ddlSupervisorName.SelectedValue = oledbReadBV["Supervisor_sign"].ToString();
                        txtSupervisorName.Text = oledbReadBV["Supervisor"].ToString();
                        txtNeighbourCheckedBy.Text = oledbReadBV["NeighbourCheckedBy"].ToString();
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
                        //ddlEducation.SelectedValue = oledbReadBV["Education"].ToString();
                        string sDed = oledbReadBV["Education"].ToString();
                        if (sDed.Trim() != "")
                        {
                            string[] arrssDed = sDed.Split(':');
                            if (arrssDed.Length > 0)
                            {
                                if (arrssDed[0].ToString() == "Other" && arrssDed.Length > 1)
                                {
                                    ddlEducation.SelectedValue = "Other";
                                    txtEducationBackgroud.Text = arrssDed[1].ToString();
                                }
                                else
                                {
                                    ddlEducation.SelectedValue = arrssDed[0].ToString();
                                }
                            }
                        }
                        txtApplicantIncome.Text = oledbReadBV["Applicant_Income"].ToString();
                        txtNoOfYrsAtPrevEmployment.Text = oledbReadBV["No_yrs_previous_Employment"].ToString();
                        txtLoanCancellation.Text = oledbReadBV["Loan_Cancellation"].ToString();
                        ddlAnyCreditCard.SelectedValue = oledbReadBV["Any_credit_card"].ToString();
                        txtAnyOtherLoan.Text = oledbReadBV["Any_other_Loan"].ToString();
                        ddlCityLimit.SelectedValue = oledbReadBV["City_Limit"].ToString();
                        txtSeparateOffice.Text = oledbReadBV["Dir_Check"].ToString();

                        //////////add by new requirement as santosh//////////////////////////
                        ddlCustomerSeen.SelectedValue = oledbReadBV["Customer_Seen"].ToString();
                        ddlTypeJob.SelectedValue = oledbReadBV["Type_Job"].ToString();
                        ddlAplliWork.SelectedValue = oledbReadBV["Appli_Work"].ToString();
                        ddlAppliJobTrans.SelectedValue = oledbReadBV["Appli_JobTrans"].ToString();
                        ddlOffExit.SelectedValue = oledbReadBV["Off_Exit"].ToString();
                        txtVehiOwn.Text = oledbReadBV["Vehi_Own"].ToString();
                        ddlBussPrem.SelectedValue = oledbReadBV["Buss_Prem"].ToString();
                        txtRefName.Text = oledbReadBV["Ref_Name"].ToString();
                        txtRefAdd.Text = oledbReadBV["Ref_Add"].ToString();
                        txtMonthTurnover.Text = oledbReadBV["Month_Turn"].ToString();
                        txtNumberBeds.Text = oledbReadBV["Number_Bed"].ToString();
                        txtNeighChek.Text = oledbReadBV["Neigh_Check"].ToString();
                        txtClinicYear.Text = oledbReadBV["Clinic_Year"].ToString();
                        //ddlSeparateResi.SelectedValue = oledbReadBV["Separate_Resi"].ToString();
                        //--Update by MAnoj
                        string sSeparateResi = oledbReadBV["Separate_Resi"].ToString();
                        if (sSeparateResi.Trim() != "")
                        {
                            string[] arrsssSeparateResi = sSeparateResi.Split(':');
                            if (arrsssSeparateResi.Length > 0)
                            {
                                if (arrsssSeparateResi[0].ToString() == "Yes" && arrsssSeparateResi.Length > 1)
                                {
                                    ddlSeparateResi.SelectedValue = "Yes";
                                    txtPrimisesRem.Text = arrsssSeparateResi[1].ToString();
                                }
                                else
                                {
                                    ddlSeparateResi.SelectedValue = arrsssSeparateResi[0].ToString();
                                }
                            }
                        }
                        //--Ended by MAnoj
                        ddlSeparateFactory.SelectedValue = oledbReadBV["Separate_Factory"].ToString();
                        ddlSeparateEntrance.SelectedValue = oledbReadBV["Separate_Entrance"].ToString();
                        ddlSeparateOffice.SelectedValue = oledbReadBV["Separate_Office"].ToString();
                        ddlOfficeLimit.SelectedValue = oledbReadBV["Office_Limit"].ToString();

                        txtNamePerson2.Text = oledbReadBV["Name_Person_2"].ToString();
                        txtRelantionApp2.Text = oledbReadBV["Relantion_App_2"].ToString();
                        txtForm16.Text = oledbReadBV["Form_16"].ToString();
                        ddlProfileConfIssu.SelectedValue = oledbReadBV["Profile_conf_issu"].ToString();
                        ddlProfileConfColle.SelectedValue = oledbReadBV["Profile_conf_colle"].ToString();
                        txtInfoProvide.Text = oledbReadBV["Info_provide"].ToString();
                        ddlCustAppPrev.SelectedValue = oledbReadBV["Cust_app_Prev"].ToString();
                        txtDatePrev.Text = oledbReadBV["Date_Prev"].ToString();
                        ddlOffDeci.SelectedValue = oledbReadBV["Off_Deci"].ToString();
                        txtSalary.Text = oledbReadBV["Salary"].ToString();

                        txtNoDoctor.Text = oledbReadBV["No_Doctor"].ToString();
                        txtGrossReceipt.Text = oledbReadBV["Gross_Receipt"].ToString();
                        txtMedicalShop.Text = oledbReadBV["Medical_shop"].ToString();
                        txtAmtRent.Text = oledbReadBV["Amt_Rent"].ToString();
                        txtNameHospital.Text = oledbReadBV["Name_Hospital"].ToString();
                        txtNameMachine.Text = oledbReadBV["Name_Machine"].ToString();
                        txtAuditTax.Text = oledbReadBV["Audit_Tax"].ToString();
                        txtNoOfTax.Text = oledbReadBV["NoOf_Tax"].ToString();
                        txtGrossMonthReceipt.Text = oledbReadBV["Gross_MonthReceipt"].ToString();

                        txtNoOperation.Text = oledbReadBV["No_Operation"].ToString();
                        txtSoleOwner.Text = oledbReadBV["Sole_Owner"].ToString();
                        txtAmtInvt.Text = oledbReadBV["Amt_Invt"].ToString();
                        txtBussPremises.Text = oledbReadBV["Buss_Premises"].ToString();
                        txtFixAss.Text = oledbReadBV["Fix_Ass"].ToString();
                        txtBussManuf.Text = oledbReadBV["Buss_Manuf"].ToString();
                        txtRegiSale.Text = oledbReadBV["Regi_Sale"].ToString();
                        txtMajorClient.Text = oledbReadBV["Major_Client"].ToString();
                        txtAvgProfit.Text = oledbReadBV["Avg_Profit"].ToString();
                        txtAvgSale.Text = oledbReadBV["Avg_Sale"].ToString();
                        txtSourceIncome.Text = oledbReadBV["Source_Income"].ToString();

                        ///////////end code/////////////////////////////////////////////////
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

                        //objBV.Ownership = oledbReadBV["Ownership"].ToString();
                        //if (objBV.Ownership != "Self Owned" && objBV.Ownership != "Family Owned" && objBV.Ownership != "Partnership" && objBV.Ownership != "")
                        //{
                        //    ddlOwnership.SelectedValue = "Other";
                        //    txtOtherOwnership.Text = objBV.Ownership;
                        //}
                        //else
                        //    ddlOwnership.SelectedValue = objBV.Ownership;
                        string sOwnership = oledbReadBV["Ownership"].ToString();
                        if (sOwnership.Trim() != "")
                        {
                            string[] arrsssOwnership = sOwnership.Split(':');
                            if (arrsssOwnership.Length > 0)
                            {
                                if (arrsssOwnership[0].ToString() == "Other" && arrsssOwnership.Length > 1)
                                {
                                    ddlOwnership.SelectedValue = "Other";
                                    txtOtherOwnership.Text = arrsssOwnership[1].ToString();
                                }
                                else
                                {
                                    ddlOwnership.SelectedValue = arrsssOwnership[0].ToString();
                                }
                            }
                        }

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
                        ////objBV.Locality = oledbReadBV["Locality"].ToString();
                        ////if (objBV.Locality != "Slum" && objBV.Locality != "Lower Middle" && objBV.Locality != "Upper Class" &&
                        ////    objBV.Locality != "Under developed" && objBV.Locality != "Middle Class" && objBV.Locality != "")
                        ////{   
                        ////    ddlLocality.SelectedValue.ToString();// = "Other";
                        ////    txtOtherLocality.Text = objBV.Locality;
                        ////}
                        ////else
                        ////    ddlLocality.SelectedValue = objBV.Locality;

                        string sLocality = oledbReadBV["Locality"].ToString();
                        if (sLocality.Trim() != "")
                        {
                            string[] arrLocality = sLocality.Split(':');
                            if (arrLocality.Length > 0)
                            {
                                if (arrLocality[0].ToString() == "Other" && arrLocality.Length > 1)
                                {
                                    ddlLocality.SelectedValue = "Other";
                                    txtOtherLocality.Text = arrLocality[1].ToString();
                                }
                                else
                                {
                                    ddlLocality.SelectedValue = arrLocality[0].ToString();
                                }
                            }
                        }
                        ddlAccessibility.SelectedValue = oledbReadBV["Accessibility"].ToString();
                        ddlBusinesBoardSeen.SelectedValue = oledbReadBV["Business_board_sighted"].ToString();
                        //ddlEntryPermitted.SelectedValue = oledbReadBV["entry_permited"].ToString();
                        //Update by MAnoj
                        string sentrypermited = oledbReadBV["entry_permited"].ToString();
                        if (sentrypermited.Trim() != "")
                        {
                            string[] arrsssentrypermited = sentrypermited.Split(':');
                            if (arrsssentrypermited.Length > 0)
                            {
                                if (arrsssentrypermited[0].ToString() == "No" && arrsssentrypermited.Length > 1)
                                {
                                    ddlEntryPermitted.SelectedValue = "No";
                                    txtEntryPermittedRemaks.Text = arrsssentrypermited[1].ToString();
                                }
                                else
                                {
                                    ddlEntryPermitted.SelectedValue = arrsssentrypermited[0].ToString();
                                }
                            }
                        }
                        //End by MAnoj
                        txtApproxArea.Text = oledbReadBV["Aprox_area"].ToString();
                        txtBriefJobResponsibility.Text = oledbReadBV["Brief_Job_Responsibilities"].ToString();
                        ddlBehavourOfPersonContacted.SelectedValue = oledbReadBV["Behavour_person_contacted"].ToString();
                        txtColourOfDoor.Text = oledbReadBV["Colour_Door"].ToString();

                        //objBV.TypeOfIndustry = oledbReadBV["Type_Industry"].ToString();
                        //if (objBV.TypeOfIndustry != "Huf" && objBV.TypeOfIndustry != "Partnership" && objBV.TypeOfIndustry != "Propritorship" && objBV.TypeOfIndustry != "Govt." &&
                        //    objBV.TypeOfIndustry != "Pvt Ltd" && objBV.TypeOfIndustry != "PSU" && objBV.TypeOfIndustry != "MNC" && objBV.TypeOfIndustry != "Public Ltd" && objBV.TypeOfIndustry != "")
                        //{
                        //    ddlTypeOfIndustry.SelectedValue = "Other";
                        //    txtOtherTypeOfIndustry.Text = objBV.TypeOfIndustry;
                        //}
                        //else
                        //    ddlTypeOfIndustry.SelectedValue = objBV.TypeOfIndustry;
                        string sDed1 = oledbReadBV["Type_Industry"].ToString();
                        if (sDed.Trim() != "")
                        {
                            string[] arrssDed = sDed1.Split(':');
                            if (arrssDed.Length > 0)
                            {
                                if (arrssDed[0].ToString() == "Other" && arrssDed.Length > 1)
                                {
                                    ddlTypeOfIndustry.SelectedValue = "Other";
                                    txtOtherTypeOfIndustry.Text = arrssDed[1].ToString();
                                }
                                else
                                {
                                    ddlTypeOfIndustry.SelectedValue = arrssDed[0].ToString();
                                }
                            }
                        }
   

                        //string sNatureOfBusiness = oledbReadBV["Nature_Business"].ToString();
                        //if (sNatureOfBusiness.Trim() != "")
                        //{
                        //    string[] arrNatureOfBusiness = sNatureOfBusiness.Split('+');
                        //    if (arrNatureOfBusiness.Length > 0)
                        //    {
                        //        if (arrNatureOfBusiness[0].ToString() == "Other" && arrNatureOfBusiness.Length > 1)
                        //        {
                        //            ddlNatureOfBusiness.SelectedValue = "Other";
                        //            txtOtherNatureOfBusiness.Text = arrNatureOfBusiness[1].ToString();
                        //        }
                        //        else
                        //        {
                        //            ddlNatureOfBusiness.SelectedValue = arrNatureOfBusiness[0].ToString();
                        //        }
                        //    }
                        //}
                        ////string sDed2 = oledbReadBV["Nature_Business"].ToString();
                        ////if (sDed.Trim() != "")
                        ////{
                        ////    string[] arrssDed = sDed2.Split(':');
                        ////    if (arrssDed.Length > 0)
                        ////    {
                        ////        if (arrssDed[0].ToString() == "Other" && arrssDed.Length > 1)
                        ////        {
                        ////            ddlNatureOfBusiness.SelectedValue = "Other";
                        ////            txtOtherNatureOfBusiness.Text = arrssDed[1].ToString();
                        ////        }
                        ////        else
                        ////        {
                        ////            ddlNatureOfBusiness.SelectedValue = arrssDed[0].ToString();
                        ////        }
                        ////    }
                        ////}

                        //new added
                        ddlNatureOfBusiness.SelectedValue = oledbReadBV["Nature_Business"].ToString();
                        ddlServiceProvider.SelectedValue = oledbReadBV["service_provider"].ToString();
                        txtOtherNatureOfBusiness.Text = oledbReadBV["Other_service_provider"].ToString();

                        //comp

                        ddlNoOfBranches.SelectedValue = oledbReadBV["No_of_branches"].ToString();
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
                            objBV.TypeOfOrganization != "Partnership" && objBV.TypeOfOrganization != "HUF" && objBV.TypeOfOrganization != "Family Business" && objBV.TypeOfOrganization != "")
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
                            objBV.StatusOfOffice != "Godown" && objBV.StatusOfOffice != "Plant" && objBV.StatusOfOffice != "Independent office" && objBV.StatusOfOffice != "Clinic" && 
                            objBV.StatusOfOffice != "")
                        {
                            ddlStatusOfOffice.SelectedValue = "Others";
                            txtOtherStatusOfOffice.Text = objBV.StatusOfOffice;
                        }
                        else
                            ddlStatusOfOffice.SelectedValue = objBV.StatusOfOffice;

                        ddlShiftOfWork.SelectedValue = oledbReadBV["WORK_SHIFT"].ToString();
                        txtVerifierComments.Text = oledbReadBV["Verifier_Comment"].ToString();
                        ddlOverallVerification.SelectedValue = oledbReadBV["Overall_Verification"].ToString();
                        //ddlTotalNoOfEmployees.SelectedValue = oledbReadBV["Total_No_employee"].ToString();
                        //new add
                        string sVisibleNameBoard = oledbReadBV["Total_No_employee"].ToString();
                        if (sVisibleNameBoard.Trim() != "")
                        {
                            string[] arrVisibleNameBoard = sVisibleNameBoard.Split(':');
                            if (arrVisibleNameBoard.Length > 0)
                            {
                                if (arrVisibleNameBoard[0].ToString() == "others" && arrVisibleNameBoard.Length > 1)
                                {
                                    ddlTotalNoOfEmployees.SelectedValue = "others";
                                    txtotherTotalNoOfEmployees.Text = arrVisibleNameBoard[1].ToString();
                                }
                                else
                                {
                                    ddlTotalNoOfEmployees.SelectedValue = arrVisibleNameBoard[0].ToString();
                                }
                            }
                        }
                        //Comp

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
                        ddlMonthsOfWorkatCurrentOffice.SelectedValue = oledbReadBV["Months_work_current_office"].ToString();
                        txtPurposeOfLoanTaken.Text = oledbReadBV["Purpose_loan"].ToString();
                        ///----------------------------------
                        //Added by MAnoj
                        txtResidenceDetails.Text = oledbReadBV["ResidenceDetails"].ToString();
                        txtAccountType.Text = oledbReadBV["AccountType"].ToString();
                        string sBusinessConfirmed = oledbReadBV["BusinessConfirmed"].ToString();
                        if (sBusinessConfirmed.Trim() != "")
                        {
                            string[] arrssBusiness = sBusinessConfirmed.Split(':');
                            if (arrssBusiness.Length > 0)
                            {
                                if (arrssBusiness[0].ToString() == "No" && arrssBusiness.Length > 1)
                                {
                                    ddlBusinessConfirmed.SelectedValue = "No";
                                    txtBusinessConfirmedRem.Text = arrssBusiness[1].ToString();
                                }
                                else
                                {
                                    ddlBusinessConfirmed.SelectedValue = arrssBusiness[0].ToString();
                                }
                            }
                        }
                        string sConfirmationSetup = oledbReadBV["ConfirmationSetup"].ToString();
                        if (sConfirmationSetup.Trim() != "")
                        {
                            string[] arrssConfirmation = sConfirmationSetup.Split(':');
                            if (arrssConfirmation.Length > 0)
                            {
                                if (arrssConfirmation[0].ToString() == "No" && arrssConfirmation.Length > 1)
                                {
                                    ddlConfirmationSetup.SelectedValue = "No";
                                    txtConfirmationSetup.Text = arrssConfirmation[1].ToString();
                                }
                                else
                                {
                                    ddlConfirmationSetup.SelectedValue = arrssConfirmation[0].ToString();
                                }
                            }
                        }
                        string sDedupMatch = oledbReadBV["DedupMatchr"].ToString();
                        if (sDedupMatch.Trim() != "")
                        {
                            string[] arrsssDedupMatch = sDedupMatch.Split(':');
                            if (arrsssDedupMatch.Length > 0)
                            {
                                if (arrsssDedupMatch[0].ToString() == "Yes" && arrsssDedupMatch.Length > 1)
                                {
                                    ddlDedupMatch.SelectedValue = "Yes";
                                    txtDedupMatch.Text = arrsssDedupMatch[1].ToString();
                                }
                                else
                                {
                                    ddlDedupMatch.SelectedValue = arrsssDedupMatch[0].ToString();
                                }
                            }
                        }
                        //Ended by MAnoj

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
                        /////added by kamal matekar.....for frderal finance..........
                        

                        //SANKET
                        txtMainlineBusiness.Text = oledbReadBV["MainlineBusiness"].ToString();

                        //ddlMainlineBusiness.SelectedValue = oledbReadBV["MainlineBusiness"].ToString();
                        txtValueofNostocksighted.Text = oledbReadBV["ValueofNostocksighted"].ToString();
                        ddlCategoryofCompany.SelectedValue = oledbReadBV["CategoryofCompany"].ToString();
                        ddlNormalOfficeJob.SelectedValue = oledbReadBV["NormalOfficeJob"].ToString();

                        //----added by kamal matekar for Barclays Finance PL PDF Format......
                        txtPlaceOfBirth.Text = oledbReadBV["Place_Of_Birth"].ToString();
                        txtstate.Text = oledbReadBV["State"].ToString();
                        txtPermanentAddressIfDifferent.Text = oledbReadBV["Permanent_Address_If_Different"].ToString();
                        txtTypeOfAccomodation.Text = oledbReadBV["Type_Of_Accomodation"].ToString();
                        txtApproxTimeWhenAppIsAvailableatHome.Text = oledbReadBV["Approx_Time_When_App_Home"].ToString();
                        txtSourcingDsaDealer.Text = oledbReadBV["Sourcing_Dsa_Dealer"].ToString();
                        txtExistingRelationshipwithBarclays.Text = oledbReadBV["Existing_Relationship_with_Barclays"].ToString();
                        ddlApplicantCategory.SelectedValue = oledbReadBV["Applicant_Category"].ToString();
                        txtIfSalariedEmployerName.Text = oledbReadBV["If_Salaried_Employer_Name"].ToString();
                        txtMainClient.Text = oledbReadBV["Main_Client"].ToString();
                        ddlSizeOfOffice.SelectedValue = oledbReadBV["Size_Of_Office"].ToString();
                        txtSelfOwnedRentedIfRentedPMRent.Text = oledbReadBV["Self_PM_Rent"].ToString();
                        txtNoOfYrsAtCurrentOfficeAddress.Text = oledbReadBV["NoOfYrsAtCurrentOfficeAddress"].ToString();
                        txtOtherOfficeLocationDetails.Text = oledbReadBV["OtherOfficeLocationDetails"].ToString();
                        
                        //ddlAutomationLevel.SelectedValue = oledbReadBV["Automation_Level"].ToString();
                        string sAutomationLevel = oledbReadBV["Automation_Level"].ToString();
                        string[] arrAutomationLevel = sAutomationLevel.Split(',');

                        if (arrAutomationLevel.Length > 0)
                        {
                            for (int i = 0; i < arrAutomationLevel.Length; i++)
                            {
                                foreach (ListItem li in chkAutomationLevel.Items)
                                {
                                    if (li.Value == arrAutomationLevel.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }

                        ddlAPPROACHABILITY.SelectedValue =oledbReadBV["Approachability"].ToString();
                        txtWithinMunicipalLimit.Text = oledbReadBV["Within_Municipal_Limit"].ToString();
                        txtAnyOtherFormOfbusiness.Text = oledbReadBV["AnyOtherFormOfbusiness"].ToString();
                        txtYearsAtCurrentAddress.Text = oledbReadBV["YearsAtCurrentAddress"].ToString();
                        txtNoOfYearsInCity.Text = oledbReadBV["NoOfYearsInCity"].ToString();
                        ddlVehicalOwned.SelectedValue = oledbReadBV["VehicalOwned"].ToString();
                        txtAnyOtherAssets.Text = oledbReadBV["AnyOtherAssets"].ToString();
                        txtBankParticular.Text = oledbReadBV["BankParticulars"].ToString();
                        /////--------------------------------------------------------------------------
                        //----Added by kamal matekar for Federal Finance ----
                        txtComapnyNameCoApp.Text = oledbReadBV["CompanyName_CoApp"].ToString();
                        txtOffAddCoApp.Text = oledbReadBV["OffAdd_CoApp"].ToString();
                        txtLandMarkCoApp.Text = oledbReadBV["LandMark_CoApp"].ToString();
                        txtTelNoCoApp.Text = oledbReadBV["TelNo_CoApp"].ToString();
                        txtPerCotCoApp.Text = oledbReadBV["PersonContacted_CoApp"].ToString();
                        txtDesignationCoApp.Text = oledbReadBV["Designation_CoApp"].ToString();
                        txtDateofVisitCoApp.Text = oledbReadBV["Datetime_Visit_CoApp"].ToString();
                        txtComStructure.Text = oledbReadBV["ComStructure"].ToString();
                        txtTurnOver.Text = oledbReadBV["TurnOver"].ToString();
                        ddlStock.SelectedValue = oledbReadBV["Stock"].ToString();
                        txtITReturn.Text = oledbReadBV["ITReturn"].ToString();
                        txtProfitMargin.Text = oledbReadBV["ProfitMargin"].ToString();
                        txtDeptClaimed.Text = oledbReadBV["DeptClaimed"].ToString();
                        txtWife.Text = oledbReadBV["Wife"].ToString();
                        txtSon.Text = oledbReadBV["Son"].ToString();
                        txtLoanType.Text = oledbReadBV["LoanType"].ToString();
                        txtEMI.Text = oledbReadBV["EMI"].ToString();
                        txtPaid.Text = oledbReadBV["Paid"].ToString();
                        txtCrLimit.Text = oledbReadBV["CrLimit"].ToString();
                        txtCardNo.Text = oledbReadBV["CardNo"].ToString();

                        txtWorkExp.Text = oledbReadBV["WorkExp"].ToString();
                        ddlOrgCov.SelectedValue = oledbReadBV["OrgCov"].ToString();
                        txtOemfName.Text = oledbReadBV["OemfName"].ToString();
                        txtOemfRelation.Text = oledbReadBV["OemfRelation"].ToString();
                        txtOemfOccu.Text = oledbReadBV["OemfOccu"].ToString();
                        txtOemfIncome.Text = oledbReadBV["OemfIncome"].ToString();
                        txtDependent.Text = oledbReadBV["Dependent"].ToString();
                        txtTwoWh.Text = oledbReadBV["TwoWh"].ToString();
                        txtFourWh.Text = oledbReadBV["FourWh"].ToString();
                        ddlSignSeen.SelectedValue = oledbReadBV["SignSeen"].ToString();
                        txtFamilyMember.Text = oledbReadBV["FamilyMember"].ToString();
                        txtOutstanding.Text = oledbReadBV["Outstanding"].ToString();
                        ddlResiStatus.SelectedValue = oledbReadBV["ResiStatus"].ToString();
                        txtOtherFeedback.Text = oledbReadBV["OtherFeedback"].ToString();

                        txtFinanceBank.Text = oledbReadBV["IfFinanceNameOfBank"].ToString();
                        ddlProperty.SelectedValue = oledbReadBV["Property_IsRented"].ToString();
                        txtRentPerMonth.Text = oledbReadBV["IfRented_PerMonth"].ToString();
                        ddlSpouseWork.SelectedValue = oledbReadBV["SpouseWork"].ToString();
                        txtSpouseDesg.Text = oledbReadBV["SpouseDesg"].ToString();
                        txtDetailsOfWorkingMembersSpouse.Text = oledbReadBV["SPOUSE_DETAILS"].ToString();
                        txtSpouseAdd.Text = oledbReadBV["SPOUSE_Address"].ToString();
                        ddlUseOfAssets.SelectedValue = oledbReadBV["UseOfAssets"].ToString();
                        txtFaxNo.Text = oledbReadBV["Area"].ToString();
                        txtFinanceCompName.Text = oledbReadBV["FinanceCompName"].ToString();
                        ddlPurpose.SelectedValue = oledbReadBV["make"].ToString();
                        txtPurpose.Text = oledbReadBV["loan_amt"].ToString();
                        ddlGeneralAppearance.SelectedValue = oledbReadBV["GeneralAppearance"].ToString();
                        ddlInducementoffered.SelectedValue = oledbReadBV["Inducementoffered"].ToString();
                        txtExactCompanyNameAddress.Text = oledbReadBV["ExactCompanyNameAddress"].ToString();

                        ddlCustSameOffice.SelectedValue = oledbReadBV["CustSameOffice"].ToString();
                        txtOfficeOrStock.Text = oledbReadBV["OfficeOrStock"].ToString();
                        ddlMultiCompanyFromPremises.SelectedValue = oledbReadBV["MultipleCompFromPremises"].ToString();
                        ddlShadyOffice.SelectedValue = oledbReadBV["ShadyOffice"].ToString();
                        ddlAddressSetup.SelectedValue = oledbReadBV["AddressSetup"].ToString();
                        ddlMetCust.SelectedValue = oledbReadBV["MetCust"].ToString();
                        ddlMetRecep.SelectedValue = oledbReadBV["MetRecep"].ToString();
                        ddlMetColleague.SelectedValue = oledbReadBV["MetColleague"].ToString();
                        ddlDesgnConf.SelectedValue = oledbReadBV["DesgnConf"].ToString();
                        ddlMetSecurityGuard.SelectedValue = oledbReadBV["MetSecurityGuard"].ToString();

                        ddlDoesbranches.SelectedValue = oledbReadBV["Doesbranches"].ToString();
                        ddlNeighbourCheck.SelectedValue = oledbReadBV["NeighbourCheck"].ToString();
                        txtNameVerifierNAme.Text = oledbReadBV["NameVerifierNAme"].ToString();

                        string sInteriors = oledbReadBV["Interiors"].ToString();
                        string[] arrsInteriors = sInteriors.Split(',');

                        if (arrsInteriors.Length > 0)
                        {
                            for (int i = 0; i < arrsInteriors.Length; i++)
                            {
                                foreach (ListItem li in chkInteriors.Items)
                                {
                                    if (li.Value == arrsInteriors.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                        ddlFurnishingseen.SelectedValue = oledbReadBV["Furnishingseen"].ToString();
                        ddlSecretary.SelectedValue = oledbReadBV["Secretary"].ToString();
                        ddlthereaphoneonhisdesk.SelectedValue = oledbReadBV["thereaphoneonhisdesk"].ToString();
                        //--Added by Manoj for futurebank
                        //--Added by abhijeet for fulltrn

                        TxtFamilyStructure.Text = oledbReadBV["FamilyStructure1"].ToString();
                        txtsalescredit.Text = oledbReadBV["salescredit"].ToString();
                        txtsalesconcentration.Text = oledbReadBV["salesconcentration"].ToString();
                        TxtBusinessCycledebtors.Text = oledbReadBV["BusinessCycledebtors"].ToString();
                        TxtBusinessCyclecreditors.Text = oledbReadBV["BusinessCyclecreditors"].ToString();
                        Txtstockvaluation.Text = oledbReadBV["stockvaluation"].ToString();
                        TxtGrossMargin.Text = oledbReadBV["GrossMargin"].ToString();
                        TxtMonthlyNetSaving.Text = oledbReadBV["MonthlyNetSaving"].ToString();
                        TxtNameofSuppliers1.Text = oledbReadBV["NameofSuppliers1"].ToString();
                        TxtNameofSuppliers2.Text = oledbReadBV["NameofSuppliers2"].ToString();
                        TxtcontactNoSuppliers1.Text = oledbReadBV["contactNoSuppliers1"].ToString();
                        TxtcontactNoSuppliers2.Text = oledbReadBV["contactNoSuppliers2"].ToString();
                        TxtNameofbuyers1.Text = oledbReadBV["Nameofbuyers1"].ToString();
                        TxtNameofbuyers2.Text = oledbReadBV["Nameofbuyers2"].ToString();
                        TxtcontactNobuyers1.Text = oledbReadBV["contactNobuyers1"].ToString();
                        TxtcontactNobuyers2.Text = oledbReadBV["contactNobuyers2"].ToString();
                        TxtApplicabilityofVAT.Text = oledbReadBV["ApplicabilityofVAT"].ToString();
                        TxtLatestQtrVAT.Text = oledbReadBV["LatestQtrVAT"].ToString();
                        TxtIstheentityinvolvedinanycommercialpestcontrol.Text = oledbReadBV["Istheentityinvolvedinanycommercialpestcontrol"].ToString();
                        TxtDoestheentityinvolveinChildorforcedLabour.Text = oledbReadBV["DoestheentityinvolveinChildorforcedLabour"].ToString();
                        TxtDoesestablishmentfromStatepollutioncontrol.Text = oledbReadBV["DoesestablishmentfromStatepollutioncontrol"].ToString();
                        txtDoesairwaternoisepollutants.Text = oledbReadBV["Doesairwaternoisepollutants"].ToString();
                        TxtDoestheEntitycomplywiththeaboveESSguidelines.Text = oledbReadBV["DoestheEntitycomplywiththeaboveESSguidelines"].ToString();
                        TxtVintageofaccount1.Text = oledbReadBV["Vintageofaccount1"].ToString();
                        TxtVintageofaccount2.Text = oledbReadBV["Vintageofaccount2"].ToString();
                        TxtIfCCODlimitwhatislimit1.Text = oledbReadBV["IfCCODlimitwhatislimit1"].ToString();
                        TxtIfCCODlimitwhatislimit2.Text = oledbReadBV["IfCCODlimitwhatislimit2"].ToString();
                        ddlCustomerBehavior.SelectedValue = oledbReadBV["CustomerBehavior"].ToString();
                        TxtDetailedpurposeEnduseofLoanAmount.Text = oledbReadBV["DetailedpurposeEnduseofLoanAmount"].ToString();
                        TxtDetailedobservation.Text = oledbReadBV["Detailedobservation"].ToString();
                        TxtDirectorName1.Text = oledbReadBV["DirectorName1"].ToString();
                        TxtDirectorName2.Text = oledbReadBV["DirectorName2"].ToString();
                        TxtDirectorName3.Text = oledbReadBV["DirectorName3"].ToString();
                        TxtDirectorName4.Text = oledbReadBV["DirectorName4"].ToString();
                        txtBankName1.Text = oledbReadBV["bankname1"].ToString();
                        txtBankName2.Text = oledbReadBV["bankname2"].ToString();
                        txtTypeOfAccount1.Text = oledbReadBV["Typeofaccount1"].ToString();
                        txtTypeOfAccount2.Text = oledbReadBV["Typeofaccount2"].ToString();
                        ddlTypeofcustmor.SelectedValue = oledbReadBV["Typeofcustmor"].ToString();


                        txtLoanType1.Text = oledbReadBV["LoanType1"].ToString();
                        txtLoanFinancier1.Text = oledbReadBV["LoanFinancier"].ToString();
                        txtLoanAmt1.Text = oledbReadBV["LoanAmt"].ToString();
                        txtLoanTenure1.Text = oledbReadBV["LoanTenure"].ToString();
                        txtLoanEmi1.Text = oledbReadBV["LoanEmi"].ToString();
                        txtLoanPaid1.Text = oledbReadBV["LoanPaid"].ToString();
                        txtLoanType2.Text = oledbReadBV["LoanType2"].ToString();
                        txtLoanFinancier2.Text = oledbReadBV["LoanFinancier2"].ToString();
                        txtLoanAmt2.Text = oledbReadBV["LoanAmt2"].ToString();
                        txtLoanTenure2.Text = oledbReadBV["LoanTenure2"].ToString();
                        txtLoanEmi2.Text = oledbReadBV["LoanEmi2"].ToString();
                        txtLoanPaid2.Text = oledbReadBV["LoanPaid2"].ToString();
                        txtLoanType3.Text = oledbReadBV["LoanType3"].ToString();
                        txtLoanFinancier3.Text = oledbReadBV["LoanFinancier3"].ToString();
                        txtLoanAmt3.Text = oledbReadBV["LoanAmt3"].ToString();
                        txtLoanTenure3.Text = oledbReadBV["LoanTenure3"].ToString();
                        txtLoanEmi3.Text = oledbReadBV["LoanEmi3"].ToString();
                        txtLoanPaid3.Text = oledbReadBV["LoanPaid3"].ToString();



                        //--ended by abhijeet for fulltrn
                        



                        txtEaringmembers.Text = oledbReadBV["Earingmembers"].ToString();
                        txtRelationshipe.Text = oledbReadBV["Relationshipe"].ToString();
                        txtmonthlyearing.Text = oledbReadBV["monthlyearing"].ToString();
                        txtVerifierthrough.Text = oledbReadBV["Verifierthrough"].ToString();

                        ddlApplicantstaandinginLocality.SelectedValue = oledbReadBV["ApplicantstaandinginLocality"].ToString();
                        txtnamee.Text = oledbReadBV["namee"].ToString();
                        txtphonee.Text = oledbReadBV["phonee"].ToString();
                        txtelaborateonthestanding.Text = oledbReadBV["elaborateonthestanding"].ToString();

                        ddlBusinessdealingseen.SelectedValue = oledbReadBV["Businessdealingseen"].ToString();
                        txtFinancier.Text = oledbReadBV["Financier"].ToString();
                        txtFinanceAmount.Text = oledbReadBV["FinanceAmount"].ToString();
                        txtNoOfbranch.Text = oledbReadBV["NoOfBranchtext"].ToString();
                        ////ING Vysya Nikhil Start 25 sept 2013
                        txtReportingTo.Text = oledbReadBV["ReportingTo"].ToString();
                        txtAnyConcerningIssue.Text = oledbReadBV["AnyConcerningIssue"].ToString();
                        txtExistingLoanDetails.Text = oledbReadBV["ExistingLoanDetails"].ToString();
                        txtVehicleFreeOrFinance.Text = oledbReadBV["VehicleFreeOrFinance"].ToString();
                        txtVehicleRegNo.Text = oledbReadBV["VehicleRegNo"].ToString();
                        txtMarketHoliday.Text = oledbReadBV["MarketHoliday"].ToString();
                        txtPeakBusinessHours.Text = oledbReadBV["PeakBusinessHours"].ToString();
                        txtAverageBillingPerCustomer.Text = oledbReadBV["AverageBillingPerCustomer"].ToString();
                        txtRouteMap.Text = oledbReadBV["RouteMap"].ToString();
                        txtCoApplicantName.Text = oledbReadBV["CoApplicantName"].ToString();
                        //End Nikhil

                        //New added/Updated for CHOLA
                        //txtAddressonfirmed.Text = oledbReadBV["Addressonfirmed"].ToString();
                        ddlAddressConfirmed.SelectedValue = oledbReadBV["Addressonfirmed"].ToString();
                        txtSalaryDrawn.Text = oledbReadBV["Salary_Drawn"].ToString();
                        //END

                        //New added/Updated for Capri Global
                        txtNatureOfBusiness.Text = oledbReadBV["Nature_Business_Details"].ToString();
                        txtPhotoIDdetails.Text = oledbReadBV["PhotoIDdetails"].ToString();
                        txtAddrProofdetails.Text = oledbReadBV["AddrProofdetails"].ToString();
                        txtIncomeProofdetails.Text = oledbReadBV["IncomeProofdetails"].ToString();
                        txtSupportingDoc.Text = oledbReadBV["SupportingDoc"].ToString();
                        //END 
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


    private void Get_Areaname()
    {
        string sCaseId1 = Request.QueryString["CaseID"].ToString();
        hidCaseID.Value = sCaseId1;

        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_BV";

        SqlParameter AreaID = new SqlParameter();
        AreaID.SqlDbType = SqlDbType.VarChar;
        AreaID.Value = hidCaseID.Value;
        AreaID.ParameterName = "@Case_id";
        cmd.Parameters.Add(AreaID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 1)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlAreaname.SelectedIndex = 0;
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();
            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    private void GetSupervisorList()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EmployeeNameListSUP";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();


            ddlSupervisorName.DataTextField = "FullName";

            ddlSupervisorName.DataValueField = "EMP_ID";
            ddlSupervisorName.DataSource = dt;
            ddlSupervisorName.DataBind();

            ddlSupervisorName.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlSupervisorName.Items.Insert(0, "--Select--");
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

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
            if (sRemark.Length > 2000)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Remark should not be greater than 2000 characters.";
                iValidate = false;
            }
        }

        if (sCommentNeigh1.Trim() != "")
        {
            if (sCommentNeigh1.Length > 2000)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour should not be greater than 2000 characters.";
                iValidate = false;
            }
        }
        if (sCommentNeigh2.Trim() != "")
        {
            if (sCommentNeigh2.Length > 2000)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Comments of neighbour should not be greater than 2000 characters.";
                iValidate = false;
            }
        }
        if (sVerifierComment.Trim() != "")
        {
            if (sVerifierComment.Length > 2000)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Verifier comment should not be greater than 2000 characters.";
                iValidate = false;
            }
        }
        if (sThirdPartyComment.Trim() != "")
        {
            if (sThirdPartyComment.Length > 2000)
            {
                pnlMsg.Visible = true;
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Third party comment should not be greater than 2000 characters.";
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
                objBV.IfNegProduct = txtIfNegProduct.Text.Trim();
                objBV.NameOfPersonMetDesgn = txtPersonMetDesgn.Text.Trim();
                objBV.ApplicantWorkedAgGivenAddress = txtAppConfirm.Text.Trim();
                objBV.NameOfBusiness = txtBusinessName.Text.Trim();
                if (txtServiceYear.Text == "" && txtServiceMths.Text == "")
                {
                    txtServiceYear.Text = Convert.ToString(0);
                    txtServiceMths.Text = Convert.ToString(0);
                    objBV.NoOfYrsAtResidence = txtServiceYear.Text + "." + txtServiceMths.Text;
                }
                objBV.NoOfYrsInservice = txtServiceYear.Text.Trim() + "." + txtServiceMths.Text.Trim();
                objBV.AppDesignation = txtAppDesgn.Text.Trim();
                //objBV.NoOfEmployeeSeen = ddlNumberOfEmployee.SelectedValue.Trim();

                //new add
                if (ddlNumberOfEmployee.SelectedItem.Text.Trim() == "others")
                    objBV.NoOfEmployeeSeen = "others" + ":" + txtotherNumberOfEmployee.Text.Trim();
                else
                    objBV.NoOfEmployeeSeen = ddlNumberOfEmployee.SelectedItem.Text.Trim();

                //comp
                objBV.ConstitutencyOfBusiness = txtBusinessConstitutency.Text.Trim();
                if (ddlOfficeType.SelectedValue.Trim() == "Others")
                {
                    objBV.TypeOfOffice = "Others" + ":" + txtOtherOfficeType.Text.Trim();
                }
                else
                {
                    objBV.TypeOfOffice = ddlOfficeType.SelectedValue.Trim();
                }
                objBV.LocatingOffice = ddlLocatingOffice.SelectedValue.Trim();
                objBV.IsResiCumOffice = ddlResiCumoff.SelectedValue.Trim();
                objBV.NameplateOnDoor = ddlNameBoardSighted.SelectedValue.Trim();
                objBV.IsBusinessActivityseen = ddlBusinessActivity.SelectedValue.Trim();
                objBV.Landmark = txtLandmark.Text.Trim();
                objBV.IsEuipStockSighted = txtEquipStockSighted.Text.Trim();
                objBV.NatureOfJob = txtJobNature.Text.Trim();
                objBV.VisitCardAsProofOfVisit = ddlVisitCardProof.SelectedValue.Trim();
                objBV.Remarks = txtRemarks.Text.Trim();
                objBV.Rating = ddlRating.SelectedValue.Trim();
                objBV.particulars = txtproductdealingin.Text.Trim();
                //CCommon objCmn = new CCommon();
                //string sDateOfVer = "";
                //if (txtDateOfVerification.Text.Trim() != "")
                //    sDateOfVer = objCmn.strDate(txtDateOfVerification.Text.Trim());
                objBV.DateTimeOfVerification = txtDateOfVerification.Text.Trim() + " " + txtTimeOfVerification.Text.Trim() + " " + ddlDateTimeOfVerification.SelectedValue.Trim();
                
                objBV.VerifierName = txtVerifierName.Text.Trim();
                objBV.SupervisorName = txtSupervisorName.Text.Trim();
                objBV.Supervisor_sign = ddlSupervisorName.SelectedValue.Trim();
                objBV.NeighbourCheckedBy = txtNeighbourCheckedBy.Text.Trim();
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
                if (ddlEducation.SelectedItem.Text.Trim() == "Other")
                    objBV.Education = "Other" + ":" + txtEducationBackgroud.Text.Trim();
                else
                    objBV.Education = ddlEducation.SelectedItem.Text.Trim();

                objBV.ApplicantIncome = txtApplicantIncome.Text.Trim();
                objBV.NoOfYrsAtPrevEmployment = txtNoOfYrsAtPrevEmployment.Text.Trim();
                objBV.LoanCancellation = txtLoanCancellation.Text.Trim();
                objBV.AnyCreditCard = ddlAnyCreditCard.SelectedValue.Trim();
                objBV.AnyOtherLoan = txtAnyOtherLoan.Text.Trim();
                objBV.CityLimit = ddlCityLimit.SelectedValue.Trim();
                objBV.SeparateOffice = ddlSeparateOffice.SelectedValue.Trim();
                //////////////add code as per new requirment//////////////////////////////////////////////////////////
                objBV.CustomerSeen = ddlCustomerSeen.SelectedValue.Trim();
                objBV.TypeJob = ddlTypeJob.SelectedValue.Trim();
                objBV.AppliWork = ddlAplliWork.SelectedValue.Trim();
                objBV.AppliJobTrans = ddlAppliJobTrans.SelectedValue.Trim();
                objBV.OffExit = ddlOffExit.SelectedValue.Trim();
                objBV.VehiOwn = txtVehiOwn.Text.Trim();///
                objBV.BussPrem = ddlBussPrem.SelectedValue.Trim();
                objBV.RefName = txtRefName.Text.Trim();
                objBV.RefAdd = txtRefAdd.Text.Trim();
                objBV.MonthTurn = txtMonthTurnover.Text.Trim();
                objBV.NumberBed = txtNumberBeds.Text.Trim();
                objBV.NeighCheck = txtNeighChek.Text.Trim();
                objBV.ClinicYear = txtClinicYear.Text.Trim();
                // objBV.SeparateResi = ddlSeparateResi.SelectedValue.Trim();
                //---Update by MAnoj
                if (ddlSeparateResi.SelectedItem.Text.Trim() == "Yes")
                {
                    objBV.SeparateResi = "Yes" + ":" + txtPrimisesRem.Text.Trim();
                }
                else
                {
                    objBV.SeparateResi = ddlSeparateResi.SelectedItem.Text.Trim();
                }
                //--End by MAnoj
                objBV.SeparateFactory = ddlSeparateFactory.SelectedValue.Trim();
                objBV.SeparateEntrance = ddlSeparateEntrance.SelectedValue.Trim();
                objBV.OfficeLimit = ddlOfficeLimit.SelectedValue.Trim();
                objBV.SepOff = txtSeparateOffice.Text.Trim();

                objBV.NamePerson2 = txtNamePerson2.Text.Trim();
                objBV.RelantionApp2 = txtRelantionApp2.Text.Trim();
                objBV.Form16 = txtForm16.Text.Trim();
                objBV.ProfileConfIssu = ddlProfileConfIssu.SelectedValue.Trim();
                objBV.ProfileConfColle = ddlProfileConfColle.SelectedValue.Trim();
                objBV.InfoProvide = txtInfoProvide.Text.Trim();
                objBV.CustAppPrev = ddlCustAppPrev.SelectedValue.Trim();
                objBV.DatePrev = txtDatePrev.Text.Trim();
                objBV.OffDeci = ddlOffDeci.SelectedValue.Trim();
                objBV.Salary = txtSalary.Text.Trim();

                objBV.NoDoctor = txtNoDoctor.Text.Trim();
                objBV.GrossReceipt = txtGrossReceipt.Text.Trim();
                objBV.MedicalShop = txtMedicalShop.Text.Trim();
                objBV.AmtRent = txtAmtRent.Text.Trim();
                objBV.NameHospital = txtNameHospital.Text.Trim();
                objBV.NameMachine = txtNameMachine.Text.Trim();
                objBV.AuditTax = txtAuditTax.Text.Trim();
                objBV.NoOfTax = txtNoOfTax.Text.Trim();
                objBV.GrossMonthReceipt = txtGrossMonthReceipt.Text.Trim();

                objBV.NoOperation = txtNoOperation.Text.Trim();
                objBV.SoleOwner = txtSoleOwner.Text.Trim();
                objBV.AmtInvt = txtAmtInvt.Text.Trim();
                objBV.BussPremises = txtBussPremises.Text.Trim();
                objBV.FixAss = txtFixAss.Text.Trim();
                objBV.BussManuf = txtBussManuf.Text.Trim();
                objBV.RegiSale = txtRegiSale.Text.Trim();
                objBV.MajorClient = txtMajorClient.Text.Trim();
                objBV.AvgProfit = txtAvgProfit.Text.Trim();
                objBV.AvgSale = txtAvgSale.Text.Trim();
                objBV.SourceIncome = txtSourceIncome.Text.Trim();
                objBV.SpouseWork = ddlSpouseWork.SelectedValue.ToString();
                objBV.SpouseDesg = txtSpouseDesg.Text.ToString();
                objBV.DetailsOfWorkingMemberSpouse = txtDetailsOfWorkingMembersSpouse.Text.Trim();
                objBV.SpouseAdd = txtSpouseAdd.Text.ToString();

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
                    objBV.Ownership = "Other" + ":" + txtOtherOwnership.Text.Trim();

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
                    objBV.Locality = "Other" + ":" + txtOtherLocality.Text.Trim();

                objBV.Accessibility = ddlAccessibility.SelectedValue.Trim();
                objBV.BusinessBoardSighted = ddlBusinesBoardSeen.SelectedValue.Trim();
                //objBV.EntryPermitted = ddlEntryPermitted.SelectedValue.Trim();
                //--Update by MAnoj
                if (ddlEntryPermitted.SelectedValue.Trim() == "No")
                {
                    objBV.EntryPermitted = "No" + ":" + txtEntryPermittedRemaks.Text.Trim();
                }
                else
                {
                    objBV.EntryPermitted = ddlEntryPermitted.SelectedValue.Trim();
                }
                //--Ended by MAnoj
                objBV.ApproximateArea = txtApproxArea.Text.Trim();
                objBV.BriefJobResponsibilities = txtBriefJobResponsibility.Text.Trim();
                objBV.BehavourOfPersonContact = ddlBehavourOfPersonContacted.SelectedValue.Trim();
                objBV.ClourOnDoor = txtColourOfDoor.Text.Trim();
                //if (ddlTypeOfIndustry.SelectedValue.Trim() != "Other")
                //    objBV.TypeOfIndustry = ddlTypeOfIndustry.SelectedValue.Trim();
                //else
                //    objBV.TypeOfIndustry = txtOtherTypeOfIndustry.Text.Trim();
                if (ddlTypeOfIndustry.SelectedValue.Trim() == "Other")
                {
                    objBV.TypeOfIndustry = "Other" + ":" + txtOtherTypeOfIndustry.Text.Trim();
                }
                else
                {
                    objBV.TypeOfIndustry = ddlTypeOfIndustry.SelectedValue.Trim();

                }

                //if (ddlNatureOfBusiness.SelectedValue.Trim()!= "Other")
                //    objBV.NatureOfBusiness = ddlNatureOfBusiness.SelectedValue.Trim();
                //else
                //    objBV.NatureOfBusiness = txtOtherNatureOfBusiness.Text.Trim();

                objBV.NatureOfBusiness = ddlNatureOfBusiness.SelectedValue.Trim();

                if (ddlServiceProvider.SelectedValue.Trim() == "Other")
                {
                    objBV.service_provider = "Other" + ":" + txtOtherNatureOfBusiness.Text.Trim();
                }
                else
                {
                    objBV.service_provider = ddlServiceProvider.SelectedValue.Trim();
                }
                objBV.service_provider = ddlServiceProvider.SelectedValue.Trim();
                objBV.service_providerOther = txtOtherNatureOfBusiness.Text.Trim();

                //if (ddlNatureOfBusiness.SelectedValue.Trim() == "Other")
                //{
                //    objBV.NatureOfBusiness = "Other" + ":" + txtOtherNatureOfBusiness.Text.Trim();
                //}
                //else
                //{
                //    objBV.NatureOfBusiness = ddlNatureOfBusiness.SelectedValue.Trim();
                //}

                //objBV.NoOfBranches = ddlNoOfBranches.SelectedValue.Trim();
                //objBV.NoOfCustomerPerDay = txtNoOfCustomerPerDay.Text.Trim();

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
                //objBV.TotalNoOfEmployees = ddlTotalNoOfEmployees.SelectedValue.Trim();
                //new add
                if (ddlTotalNoOfEmployees.SelectedItem.Text.Trim() == "others")
                    objBV.TotalNoOfEmployees = "others" + ":" + txtotherTotalNoOfEmployees.Text.Trim();
                else
                    objBV.TotalNoOfEmployees = ddlTotalNoOfEmployees.SelectedItem.Text.Trim();
                //comp
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
                objBV.MthOfWorkCurrentOffice = ddlMonthsOfWorkatCurrentOffice.SelectedValue.Trim();
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
                ////// //Added by hemangi kambli on 03/10/2007 -----------parel-24229905/23024076-MumCen
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
                ///added by kamal matekar fro ferderal finance.....

                objBV.MainlineBusiness = txtMainlineBusiness.Text.Trim();
                //objBV.MainlineBusiness = ddlMainlineBusiness.SelectedValue.ToString();
                objBV.ValueofNostocksighted = txtValueofNostocksighted.Text.Trim();
                objBV.CategoryofCompany = ddlCategoryofCompany.SelectedValue.ToString();
                objBV.NormalOfficeJob = ddlNormalOfficeJob.SelectedValue.ToString();
                //---------------------Barclays finance PL On dated 24/07/2010-------------------------------
                objBV.Place_Of_Birth=txtPlaceOfBirth.Text.Trim();
                objBV.State = txtstate.Text.Trim();
                objBV.Permanent_Address_If_Different = txtPermanentAddressIfDifferent.Text.Trim();
                objBV.Type_Of_Accomodation = txtTypeOfAccomodation.Text.Trim();
                objBV.Approx_Time_When_App_Home = txtApproxTimeWhenAppIsAvailableatHome.Text.Trim();
                objBV.Sourcing_Dsa_Dealer = txtSourcingDsaDealer.Text.Trim();
                objBV.Existing_Relationship_with_Barclays = txtExistingRelationshipwithBarclays.Text.Trim();
                objBV.Applicant_Category = ddlApplicantCategory.SelectedValue.ToString();
                objBV.If_Salaried_Employer_Name = txtIfSalariedEmployerName.Text.Trim();
                objBV.Main_Client = txtMainClient.Text.Trim();
                objBV.Size_Of_Office = ddlSizeOfOffice.SelectedValue.ToString();
                objBV.Self_PM_Rent = txtSelfOwnedRentedIfRentedPMRent.Text.Trim();
                objBV.NoOfYrsAtCurrentOfficeAddress = txtNoOfYrsAtCurrentOfficeAddress.Text.Trim();
                objBV.OtherOfficeLocationDetails = txtOtherOfficeLocationDetails.Text.Trim();
                
                //objBV.Automation_Level = ddlAutomationLevel.SelectedValue.ToString();
                string AutomationLevel = "";///
                if (chkAutomationLevel.Items.Count > 0)
                {
                    foreach (ListItem li in chkAutomationLevel.Items)
                    {
                          if (li.Selected == true)
                          AutomationLevel += li.Value + ",";
                    }
                }

                objBV.Automation_Level = AutomationLevel.TrimEnd(',');

                objBV.Approachability = ddlAPPROACHABILITY.SelectedValue.ToString();
                objBV.Within_Municipal_Limit = txtWithinMunicipalLimit.Text.Trim();
                objBV.AnyOtherFormOfbusiness = txtAnyOtherFormOfbusiness.Text.Trim();
                objBV.YearsAtCurrentAddress = txtYearsAtCurrentAddress.Text.Trim();
                objBV.NoOfYearsInCity = txtNoOfYearsInCity.Text.Trim();
                objBV.VehicalOwned = ddlVehicalOwned.SelectedValue.ToString();
                objBV.AnyOtherAssets = txtAnyOtherAssets.Text.Trim();
                objBV.BankParticulars = txtBankParticular.Text.Trim();
                //--------------Ended 
                //---added by kamal matekar for federal finance On dated 29/07/2010---
                objBV.CompanyName_CoApp = txtComapnyNameCoApp.Text.ToString();
                objBV.OffAdd_CoApp = txtOffAddCoApp.Text.ToString();
                objBV.LandMark_CoApp = txtLandMarkCoApp.Text.ToString();
                objBV.TelNo_CoApp = txtTelNoCoApp.Text.ToString();
                objBV.PersonContacted_CoApp = txtPerCotCoApp.Text.ToString();
                objBV.Designation_CoApp = txtDesignationCoApp.Text.ToString();
                objBV.Datetime_Visit_CoApp = txtDateofVisitCoApp.Text.ToString();
                objBV.ComStructure = txtComStructure.Text.ToString();
                objBV.TurnOver = txtTurnOver.Text.ToString();
                objBV.Stock = ddlStock.SelectedValue.ToString();
                objBV.ITReturn = txtITReturn.Text.ToString();
                objBV.ProfitMargin = txtProfitMargin.Text.ToString();
                objBV.DeptClaimed = txtDeptClaimed.Text.ToString();
                objBV.Wife = txtWife.Text.ToString();
                objBV.Son = txtSon.Text.ToString();
                objBV.LoanType = txtLoanType.Text.ToString();
                objBV.EMI = txtEMI.Text.ToString();
                objBV.Paid = txtPaid.Text.ToString();
                objBV.CrLimit = txtCrLimit.Text.ToString();
                objBV.CardNo = txtCardNo.Text.ToString();

                objBV.WorkExp = txtWorkExp.Text.ToString();
                objBV.OrgCov = ddlOrgCov.SelectedValue.ToString();
                objBV.OemfName = txtOemfName.Text.ToString();
                objBV.OemfRelation = txtOemfRelation.Text.ToString();
                objBV.OemfOccu = txtOemfOccu.Text.ToString();
                objBV.OemfIncome = txtOemfIncome.Text.ToString();
                objBV.Dependent = txtDependent.Text.ToString();
                objBV.TwoWh = txtTwoWh.Text.ToString();
                objBV.FourWh = txtFourWh.Text.ToString();
                objBV.SignSeen = ddlSignSeen.SelectedValue.ToString();
                objBV.FamilyMember = txtFamilyMember.Text.ToString();
                objBV.Outstanding = txtOutstanding.Text.ToString();
                objBV.ResiStatus = ddlResiStatus.SelectedValue.ToString();
                objBV.OtherFeedback = txtOtherFeedback.Text.ToString();

                objBV.IfFinanceNameOfBank = txtFinanceBank.Text.ToString();
                objBV.Property_IsRented = ddlProperty.SelectedValue.ToString();
                objBV.IfRented_PerMonth = txtRentPerMonth.Text.ToString();
                objBV.SpouseWork = ddlSpouseWork.SelectedValue.ToString();
                objBV.SpouseDesg = txtSpouseDesg.Text.ToString();
                objBV.DetailsOfWorkingMemberSpouse = txtDetailsOfWorkingMembersSpouse.Text.Trim();
                objBV.SpouseAdd = txtSpouseAdd.Text.ToString();
                objBV.UseOfAssets = ddlUseOfAssets.SelectedValue.ToString();
                objBV.FaxNo = txtFaxNo.Text.ToString();
                objBV.FinanceCompName = txtFinanceCompName.Text.ToString();

                objBV.Purpose1 = ddlPurpose.SelectedValue.ToString();
                objBV.OthPurpose1 = txtPurpose.Text.ToString();
                objBV.ExactCompanyNameAddress = txtExactCompanyNameAddress.Text.ToString();

                //nikhil start
                objBV.OfficeAmenities = ddlOfficeAmenities.SelectedValue.ToString();
                objBV.MultipleCompFromPremises = ddlMultiCompanyFromPremises.SelectedValue.ToString();
                objBV.ShadyOffice = ddlShadyOffice.SelectedValue.ToString();
                objBV.AddressSetup = ddlAddressSetup.SelectedValue.ToString();
                objBV.MetColleague = ddlMetColleague.SelectedValue.ToString();
                objBV.MetCust = ddlMetCust.SelectedValue.ToString();
                objBV.MetRecep = ddlMetRecep.SelectedValue.ToString();
                objBV.MetSecurityGuard = ddlMetSecurityGuard.SelectedValue.ToString();
                objBV.DesgnConf = ddlDesgnConf.SelectedValue.ToString();
                objBV.CustSameOffice = ddlCustSameOffice.SelectedValue.ToString();
                objBV.OfficeOrStock = txtOfficeOrStock.Text.ToString();
                //nikhil end

                //----Added by MAnoj
                objBV.ResidenceDetails = txtResidenceDetails.Text.Trim();
                objBV.AccountType = txtAccountType.Text.Trim();

                if (ddlBusinessConfirmed.SelectedItem.Text.Trim() == "No")
                {
                    objBV.BusinessConfirmed = "No" + ":" + txtBusinessConfirmedRem.Text.Trim();
                }
                else
                {
                    objBV.BusinessConfirmed = ddlBusinessConfirmed.SelectedItem.Text.Trim();
                }
                if (ddlConfirmationSetup.SelectedItem.Text.Trim() == "No")
                {
                    objBV.ConfirmationSetup = "No" + ":" + txtConfirmationSetup.Text.Trim();
                }
                else
                {
                    objBV.ConfirmationSetup = ddlConfirmationSetup.SelectedItem.Text.Trim();
                }
                if (ddlDedupMatch.SelectedItem.Text.Trim() == "Yes")
                {
                    objBV.DedupMatchr = "Yes" + ":" + txtDedupMatch.Text.Trim();
                }
                else
                {
                    objBV.DedupMatchr = ddlDedupMatch.SelectedItem.Text.Trim();
                }
                objBV.GeneralAppearance = ddlGeneralAppearance.SelectedValue.ToString();
                objBV.Inducementoffered = ddlInducementoffered.SelectedValue.ToString();

                objBV.Doesbranches = ddlDoesbranches.SelectedValue.ToString();
                objBV.NeighbourCheck = ddlNeighbourCheck.SelectedValue.ToString();
                objBV.NameVerifierNAme = txtNameVerifierNAme.Text.ToString();
                string Interiors1 = "";
                if (chkInteriors.Items.Count > 0)
                {
                    foreach (ListItem li in chkInteriors.Items)
                    {
                        if (li.Selected == true)
                            Interiors1 += li.Value + ",";
                    }
                }

                objBV.Interiors = Interiors1.TrimEnd(',');
                //--Added by MAnoj for city bank


                //added by abhijeet for Fulltrn//

                objBV.FamilyStructure1 = TxtFamilyStructure.Text.Trim();
                objBV.salescredit = txtsalescredit.Text.Trim();
                objBV.salesconcentration = txtsalesconcentration.Text.Trim();
                objBV.BusinessCycledebtors = TxtBusinessCycledebtors.Text.Trim();
                objBV.BusinessCyclecreditors = TxtBusinessCyclecreditors.Text.Trim();
                objBV.BusinessCyclecreditors = TxtBusinessCyclecreditors.Text.Trim();
                objBV.stockvaluation = Txtstockvaluation.Text.Trim();
                objBV.GrossMargin = TxtGrossMargin.Text.Trim();
                objBV.MonthlyNetSaving = TxtMonthlyNetSaving.Text.Trim();
                objBV.NameofSuppliers1 = TxtNameofSuppliers1.Text.Trim();
                objBV.NameofSuppliers2 = TxtNameofSuppliers2.Text.Trim();
                objBV.contactNoSuppliers1 = TxtcontactNoSuppliers1.Text.Trim();
                objBV.contactNoSuppliers2 = TxtcontactNoSuppliers2.Text.Trim();
                objBV.Nameofbuyers1 = TxtNameofbuyers1.Text.Trim();
                objBV.Nameofbuyers2 = TxtNameofbuyers2.Text.Trim();
                objBV.contactNobuyers1 = TxtcontactNobuyers1.Text.Trim();
                objBV.contactNobuyers2 = TxtcontactNobuyers2.Text.Trim();
                objBV.ApplicabilityofVAT = TxtApplicabilityofVAT.Text.Trim();
                objBV.LatestQtrVAT = TxtLatestQtrVAT.Text.Trim();
                objBV.Istheentityinvolvedinanycommercialpestcontrol = TxtIstheentityinvolvedinanycommercialpestcontrol.Text.Trim();
                objBV.DoestheentityinvolveinChildorforcedLabour = TxtDoestheentityinvolveinChildorforcedLabour.Text.Trim();
                objBV.DoesestablishmentfromStatepollutioncontrol = TxtDoesestablishmentfromStatepollutioncontrol.Text.Trim();
                objBV.Doesairwaternoisepollutants = txtDoesairwaternoisepollutants.Text.Trim();
                objBV.DoestheEntitycomplywiththeaboveESSguidelines = TxtDoestheEntitycomplywiththeaboveESSguidelines.Text.Trim();
                objBV.Vintageofaccount1 = TxtVintageofaccount1.Text.Trim();
                objBV.Vintageofaccount2 = TxtVintageofaccount2.Text.Trim();
                objBV.IfCCODlimitwhatislimit1 = TxtIfCCODlimitwhatislimit1.Text.Trim();
                objBV.IfCCODlimitwhatislimit2 = TxtIfCCODlimitwhatislimit2.Text.Trim();
                objBV.CustomerBehavior = ddlCustomerBehavior.SelectedValue.ToString();
                objBV.DetailedpurposeEnduseofLoanAmount = TxtDetailedpurposeEnduseofLoanAmount.Text.Trim();
                objBV.Detailedobservation = TxtDetailedobservation.Text.Trim();
                objBV.DirectorName1 = TxtDirectorName1.Text.Trim();
                objBV.DirectorName2 = TxtDirectorName2.Text.Trim();
                objBV.DirectorName3 = TxtDirectorName3.Text.Trim();
                objBV.DirectorName4 = TxtDirectorName4.Text.Trim();
                objBV.bankname1 = txtBankName1.Text.Trim();
                objBV.bankname2 = txtBankName2.Text.Trim();
                objBV.Typeofaccount1 = txtTypeOfAccount1.Text.Trim();
                objBV.Typeofaccount2 = txtTypeOfAccount2.Text.Trim();
                objBV.Typeofcustmor = ddlTypeofcustmor.SelectedValue.ToString();

                objBV.LoanType1 = txtLoanType1.Text.ToString();
                objBV.LoanFinancier = txtLoanFinancier1.Text.ToString();
                objBV.LoanAmt = txtLoanAmt1.Text.ToString();
                objBV.LoanTenure = txtLoanTenure1.Text.ToString();
                objBV.LoanEmi = txtLoanEmi1.Text.ToString();
                objBV.LoanPaid = txtLoanPaid1.Text.ToString();
                objBV.LoanType2 = txtLoanType2.Text.ToString();
                objBV.LoanFinancier2 = txtLoanFinancier2.Text.ToString();
                objBV.LoanAmt2 = txtLoanAmt2.Text.ToString();
                objBV.LoanTenure2 = txtLoanTenure2.Text.ToString();
                objBV.LoanEmi2 = txtLoanEmi2.Text.ToString();
                objBV.LoanPaid2 = txtLoanPaid2.Text.ToString();
                objBV.LoanType3 = txtLoanType3.Text.ToString();
                objBV.LoanFinancier3 = txtLoanFinancier3.Text.ToString();
                objBV.LoanAmt3 = txtLoanAmt3.Text.ToString();
                objBV.LoanTenure3 = txtLoanTenure3.Text.ToString();
                objBV.LoanEmi3 = txtLoanEmi3.Text.ToString();
                objBV.LoanPaid3 = txtLoanPaid3.Text.ToString();





                //ended by abhijeet for fulltrn//
                objBV.Secretary = ddlSecretary.SelectedValue.ToString();
                objBV.Furnishingseen = ddlFurnishingseen.SelectedValue.ToString();
                objBV.thereaphoneonhisdesk = ddlthereaphoneonhisdesk.SelectedValue.ToString();

                objBV.Earingmembers = txtEaringmembers.Text.Trim();
                objBV.Relationshipe = txtRelationshipe.Text.Trim();
                objBV.monthlyearing = txtmonthlyearing.Text.Trim();
                objBV.Verifierthrough = txtVerifierthrough.Text.Trim();

                objBV.ApplicantstaandinginLocality = ddlApplicantstaandinginLocality.SelectedValue.ToString();
                objBV.namee = txtnamee.Text.Trim();
                objBV.phonee = txtphonee.Text.Trim();
                objBV.elaborateonthestanding = txtelaborateonthestanding.Text.Trim();

                objBV.Businessdealingseen = ddlBusinessdealingseen.SelectedValue.ToString();
                objBV.Financier = txtFinancier.Text.Trim();
                objBV.FinanceAmount = txtFinanceAmount.Text.Trim();
                objBV.NoOfBranchtext = txtNoOfbranch.Text.Trim();

                //ING VYSYA NIKHIL 05 july 2013 start
                objBV.ReportingTo = txtReportingTo.Text.Trim();
                objBV.AnyConcerningIssue = txtAnyConcerningIssue.Text.Trim();
                objBV.ExistingLoanDetails = txtExistingLoanDetails.Text.Trim();
                objBV.VehicleFreeOrFinance = txtVehicleFreeOrFinance.Text.Trim();
                objBV.VehicleRegNo = txtVehicleRegNo.Text.Trim();
                objBV.MarketHoliday = txtMarketHoliday.Text.Trim();
                objBV.PeakBusinessHours = txtPeakBusinessHours.Text.Trim();
                objBV.AverageBillingPerCustomer = txtAverageBillingPerCustomer.Text.Trim();
                objBV.RouteMap = txtRouteMap.Text.Trim();
                objBV.CoApplicantName = txtCoApplicantName.Text.Trim();
                objBV.FileUpload1 = null;
                Array newFileUpload1 = null;
                if (FileUpload1.FileBytes.Length > 0)
                {
                    newFileUpload1 = FileUpload1.FileBytes;
                }
                objBV.FileUpload1 = newFileUpload1;
                //ING End
                objBV.Crossverifiedinformation = ddlcrossinformation.SelectedValue.ToString();


            

                if (ddlAreaname.SelectedValue.ToString() == "0")
                {
                    objBV.AreaID = txtAreapincode.Text.Trim();
                }
                else
                {
                    objBV.AreaID = ddlAreaname.SelectedValue.ToString();
                }

                //New added/Updated for CHOLA
                //objBV.Addressonfirmed = txtAddressonfirmed.Text.Trim();
                objBV.Addressonfirmed = ddlAddressConfirmed.SelectedValue.Trim();
                objBV.SalaryDrawn = txtSalaryDrawn.Text.Trim();
                //END

                //New added/Updated for Capri Global
                objBV.NatureOfBusinessDetails = txtNatureOfBusiness.Text.Trim();
                objBV.PhotoIDdetails = txtPhotoIDdetails.Text.Trim();
                objBV.AddrProofdetails = txtAddrProofdetails.Text.Trim();
                objBV.IncomeProofdetails = txtIncomeProofdetails.Text.Trim();
                objBV.SupportingDoc = txtSupportingDoc.Text.Trim();
                //END
                
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
        Response.Redirect("RL_VerificationView.aspx?Msg=" + lblMsg.Text);
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
        Response.Redirect("RL_VerificationView.aspx");
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

    protected void cvSelectddlSupervisorName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please select Supervisor Name";
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
        Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_BusinessVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbRT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=4&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbBT_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_BusinessTelephonicVerification.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=3&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
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
        txtNoOfbranch.Enabled = false;
        txtLanNo.Enabled=false;
        txtAppName.Enabled=false;
        txtOfficeAddress.Enabled=false;
        txtOfficeName.Enabled=false;
        lblHead.Enabled=false;
        txtPersonMet.Enabled=false;
        txtIfNegProduct.Enabled = false;
        txtPersonMetDesgn.Enabled=false;
        txtAppConfirm.Enabled=false;
        txtBusinessName.Enabled=false;
        txtServiceYear.Enabled=false;
        txtServiceMths.Enabled=false;
        txtAppDesgn.Enabled=false;
        ddlNumberOfEmployee.Enabled=false;
        txtBusinessConstitutency.Enabled=false;
        ddlOfficeType.Enabled=false;
        txtOtherOfficeType.Enabled=false;
        ddlLocatingOffice.Enabled = false;
        ddlResiCumoff.Enabled=false;
        ddlNameBoardSighted.Enabled=false;
        ddlBusinessActivity.Enabled=false;
        txtLandmark.Enabled=false;
        txtEquipStockSighted.Enabled=false;
        txtJobNature.Enabled=false;
        ddlVisitCardProof.Enabled=false;
        txtRemarks.Enabled=false;
        ddlRating.Enabled=false;
        txtproductdealingin.Enabled = false;
        ddlCityLimit.Enabled = false;
        txtDateOfVerification.Enabled=false;
        txtTimeOfVerification.Enabled=false;
        ddlDateTimeOfVerification.Enabled=false;
        txtVerifierName.Enabled=false;
        txtSupervisorName.Enabled=false;
        ddlSupervisorName.Enabled = false;
        txtNeighbourCheckedBy.Enabled = false;
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
        txtNamePerson2.Enabled=false;
        txtRelantionApp2.Enabled=false;
        txtForm16.Enabled=false;
        ddlProfileConfIssu.Enabled=false;
        ddlProfileConfColle.Enabled=false;
        txtInfoProvide.Enabled=false;
        ddlCustAppPrev.Enabled=false;
        txtDatePrev.Enabled=false;
        ddlOffDeci.Enabled = false;
        txtSalary.Enabled = false;
        txtOtherFeedback.Enabled = false;
        txtFaxNo.Enabled = false;
        txtFinanceCompName.Enabled = false;

        txtNoDoctor.Enabled = false;
        txtGrossReceipt.Enabled = false;
        txtMedicalShop.Enabled = false;
        txtAmtRent.Enabled = false;
        txtNameHospital.Enabled = false;
        txtNameMachine.Enabled = false;
        txtAuditTax.Enabled = false;
        txtNoOfTax.Enabled = false;
        txtGrossMonthReceipt.Enabled = false;
        txtWorkExp.Enabled = false;
        ddlOrgCov.Enabled = false;
        txtOemfName.Enabled = false;
        txtOemfRelation.Enabled = false;
        txtOemfOccu.Enabled = false;
        txtOemfIncome.Enabled = false;
        txtDependent.Enabled = false;
        txtTwoWh.Enabled = false;
        txtFourWh.Enabled = false;
        ddlSignSeen.Enabled = false;
        txtFinanceBank.Enabled = false;
        ddlProperty.Enabled = false;
        txtRentPerMonth.Enabled = false;
        ddlSpouseWork.Enabled = false;
        txtSpouseDesg.Enabled = false;
        txtDetailsOfWorkingMembersSpouse.Enabled = false;
        txtSpouseAdd.Enabled = false;
        ddlUseOfAssets.Enabled = false;

        txtNoOperation.Enabled = false;
        txtSoleOwner.Enabled = false;
        txtAmtInvt.Enabled = false;
        txtBussPremises.Enabled = false;
        txtFixAss.Enabled = false;
        txtBussManuf.Enabled = false;
        txtRegiSale.Enabled = false;
        txtMajorClient.Enabled = false;
        txtAvgProfit.Enabled = false;
        txtAvgSale.Enabled = false;
        txtSourceIncome.Enabled = false;
        txtSeparateOffice.Enabled = false;
        txtFamilyMember.Enabled = false;
        txtOutstanding.Enabled = false;
        ddlResiStatus.Enabled = false;

        ddlCustomerSeen.Enabled = false;
        ddlTypeJob.Enabled = false;
        ddlAppliJobTrans.Enabled = false;
        ddlOffExit.Enabled = false;
        txtVehiOwn.Enabled = false;
        ddlBussPrem.Enabled = false;
        txtRefAdd.Enabled = false;
        txtRefName.Enabled = false;
        txtMonthTurnover.Enabled = false;
        txtNumberBeds.Enabled = false;
        txtNeighChek.Enabled = false;
        txtClinicYear.Enabled = false;
        ddlSeparateOffice.Enabled = false;
        ddlSeparateEntrance.Enabled = false;
        ddlSeparateFactory.Enabled = false;
        ddlSeparateResi.Enabled = false;
        ddlOfficeLimit.Enabled = false;
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
        ddlNoOfBranches.Enabled=false;
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
        ddlTotalNoOfEmployees.Enabled=false;
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
        ddlMonthsOfWorkatCurrentOffice.Enabled=false;
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
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        chkAutomationLevel.Enabled = false;
        ddlPurpose.Enabled = false;
        txtPurpose.Enabled = false;
        txtExactCompanyNameAddress.Enabled = false;

        ddlOfficeAmenities.Enabled = false;
        ddlMultiCompanyFromPremises.Enabled = false;
        ddlShadyOffice.Enabled = false;
        ddlAddressSetup.Enabled = false;
        ddlMetCust.Enabled = false;
        txtAppDesgn.Enabled = false;
        ddlMetRecep.Enabled = false;
        ddlMetColleague.Enabled = false;
        ddlDesgnConf.Enabled = false;
        ddlMetSecurityGuard.Enabled = false;
        ddlCustSameOffice.Enabled = false;
        txtOfficeOrStock.Enabled = false;

        //nikhil end

        //---Added by MAnoj
        txtResidenceDetails.Enabled = false;
        txtAccountType.Enabled = false;
        ddlBusinessConfirmed.Enabled = false;
        txtBusinessConfirmedRem.Enabled = false;
        ddlConfirmationSetup.Enabled = false;
        txtConfirmationSetup.Enabled = false;
        ddlDedupMatch.Enabled = false;
        txtDedupMatch.Enabled = false;
        ddlGeneralAppearance.Enabled = false;
        ddlInducementoffered.Enabled = false;
        ddlDoesbranches.Enabled = false;
        ddlNeighbourCheck.Enabled = false;
        txtNameVerifierNAme.Enabled = false;
        chkInteriors.Enabled = false;

        ddlSecretary.Enabled = false;
        ddlFurnishingseen.Enabled = false;
        ddlthereaphoneonhisdesk.Enabled = false;

        txtEaringmembers.Enabled = false;
        txtRelationshipe.Enabled = false;
        txtmonthlyearing.Enabled = false;
        txtVerifierthrough.Enabled = false;

        //added by abhijeet Fulltrn//
        TxtFamilyStructure.Enabled = false;
        txtsalescredit.Enabled = false;
        txtsalesconcentration.Enabled = false;
        TxtBusinessCycledebtors.Enabled = false;
        TxtBusinessCyclecreditors.Enabled = false;
        Txtstockvaluation.Enabled = false;
        TxtGrossMargin.Enabled = false;
        TxtMonthlyNetSaving.Enabled = false;
        TxtNameofSuppliers1.Enabled = false;
        TxtNameofSuppliers2.Enabled = false;
        TxtcontactNoSuppliers1.Enabled = false;
        TxtcontactNoSuppliers2.Enabled = false;
        TxtNameofbuyers1.Enabled = false;
        TxtNameofbuyers2.Enabled = false;
        TxtcontactNobuyers1.Enabled = false;
        TxtcontactNobuyers2.Enabled = false;
        TxtApplicabilityofVAT.Enabled = false;
        TxtLatestQtrVAT.Enabled = false;
        TxtIstheentityinvolvedinanycommercialpestcontrol.Enabled = false;
        TxtDoestheentityinvolveinChildorforcedLabour.Enabled = false;
        TxtDoesestablishmentfromStatepollutioncontrol.Enabled = false;
        txtDoesairwaternoisepollutants.Enabled = false;
        TxtVintageofaccount1.Enabled = false;
        TxtVintageofaccount2.Enabled = false;
        TxtIfCCODlimitwhatislimit1.Enabled = false;
        TxtIfCCODlimitwhatislimit2.Enabled = false;
        TxtDetailedpurposeEnduseofLoanAmount.Enabled = false;
        TxtDetailedobservation.Enabled = false;
        ddlCustomerBehavior.Enabled = false;
        TxtDirectorName1.Enabled = false;
        TxtDirectorName2.Enabled = false;
        TxtDirectorName3.Enabled = false;
        TxtDirectorName4.Enabled = false;
        txtBankName1.Enabled = false;
        txtBankName2.Enabled = false;
        txtTypeOfAccount1.Enabled = false;
        txtTypeOfAccount2.Enabled = false;
        ddlTypeofcustmor.Enabled = false;


        txtLoanType1.Enabled = false;
        txtLoanFinancier1.Enabled = false;
        txtLoanAmt1.Enabled = false;
        txtLoanTenure1.Enabled = false;
        txtLoanEmi1.Enabled = false;
        txtLoanPaid1.Enabled = false;
        txtLoanType2.Enabled = false;
        txtLoanFinancier2.Enabled = false;
        txtLoanAmt2.Enabled = false;
        txtLoanTenure2.Enabled = false;
        txtLoanEmi2.Enabled = false;
        txtLoanPaid2.Enabled = false;
        txtLoanType3.Enabled = false;
        txtLoanFinancier3.Enabled = false;
        txtLoanAmt3.Enabled = false;
        txtLoanTenure3.Enabled = false;
        txtLoanEmi3.Enabled = false;
        txtLoanPaid3.Enabled = false;



        //ended by abhijeet Fulltrn//


        ddlApplicantstaandinginLocality.Enabled = false;
        txtnamee.Enabled = false;
        txtphonee.Enabled = false;
        txtelaborateonthestanding.Enabled = false;
        ddlBusinessdealingseen.Enabled = false;
        txtFinancier.Enabled = false;
        txtFinanceAmount.Enabled = false;

        txtReportingTo.Enabled = false;
        txtAnyConcerningIssue.Enabled = false;
        txtExistingLoanDetails.Enabled = false;
        txtVehicleFreeOrFinance.Enabled = false;
        txtVehicleRegNo.Enabled = false;
        txtMarketHoliday.Enabled = false;
        txtPeakBusinessHours.Enabled = false;
        txtAverageBillingPerCustomer.Enabled = false;
        txtRouteMap.Enabled = false;
        txtCoApplicantName.Enabled = false;

        //New added/Updated for CHOLA
        //txtAddressonfirmed.Enabled = false;
        ddlAddressConfirmed.Enabled = false;
        txtSalaryDrawn.Enabled = false;
        //END

        //New added/Updated for Capri Global
        txtNatureOfBusiness.Enabled = false;
        txtPhotoIDdetails.Enabled = false;
        txtAddrProofdetails.Enabled = false;
        txtIncomeProofdetails.Enabled = false;
        txtSupportingDoc.Enabled = false;
        //END
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupervisorName.SelectedIndex != 0)
        {
            hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
            // Session["SupID"] = ddlSupervisorName.SelectedValue.ToString();
        }
    }
    protected void btnPincode_Click(object sender, EventArgs e)
    {
        Getdata();
    }

    private void Getdata()
    {
        CCommon objConn = new CCommon();
        SqlConnection conn = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_Areaname_name";
        cmd.CommandTimeout = 0;

        SqlParameter Pincode = new SqlParameter();
        Pincode.SqlDbType = SqlDbType.VarChar;
        Pincode.Value = txtAreapincode.Text.Trim();
        Pincode.ParameterName = "@Pincode_no";
        cmd.Parameters.Add(Pincode);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();

            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    }



