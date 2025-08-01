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

public partial class RL_ResidenceVerification_Noc : System.Web.UI.Page
{
    string verificationType = "Noc";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    CRL_VisitVerification objRV = new CRL_VisitVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;
        if (!IsPostBack)
        {
            try
            {
                //To Show the Panels add By Manoj            
                funShowPanel();

                //End
                GetSupervisorList();
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
                if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
                {

                    if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                    {
                        hidMode.Value = Request.QueryString["Mode"].ToString();
                    }
                    if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                    {
                        hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                    }
                    string sCaseId = Request.QueryString["CaseID"].ToString();
                    hidCaseID.Value = sCaseId;
                    string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
                    hidVerificationTypeID.Value = sVerifyTypeId;
                    if ((sVerifyTypeId == "32") || (sVerifyTypeId == "Noc"))  //for RV
                        lblHead.Text = "No Objection Certificate Verification";

                    else if (sVerifyTypeId == "10" || (sVerifyTypeId == "PRV")) //For PRV
                        lblHead.Text = "Permanent Residence Verification";

                    Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                    CRL_VisitVerification objRV = new CRL_VisitVerification();
                    OleDbDataReader oledbReadRV;
                    OleDbDataReader oledbCaseDtl;
                    OleDbDataReader oledbCaseDtl_Noc;
                    OleDbDataReader oledbFERead;
                    oledbReadRV = objRV.GetRVDetail(sCaseId, sVerifyTypeId);
                    oledbCaseDtl = objRV.GetCASEDetail(sCaseId, sVerifyTypeId);
                    oledbCaseDtl_Noc = objRV.GetCASEDetail_Noc(sCaseId, sVerifyTypeId);
                    oledbFERead = objRV.GetFEName(sCaseId, sVerifyTypeId);
                    
                    txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    GetTeleCallLog();



                    //Added by abhijeet 

                    if (hdnSupID.Value != "")
                    {
                        //GetSupervisorList();
                        ddlSupervisorName.SelectedValue = hdnSupID.Value;
                    }

                    //ended by abhijeet



                    if (oledbFERead.Read())
                    {
                        txtVerifiersName.Text = oledbFERead["FullName"].ToString();
                    }
                    if (oledbCaseDtl.Read() == true)
                    {
                        txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                        txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                        //txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                        //txtAddress.Text = oledbCaseDtl["RESIADDRESS"].ToString();
                        txtCity.Text = oledbCaseDtl["RES_CITY"].ToString();
                        txtPincode.Text = oledbCaseDtl["RES_PIN_CODE"].ToString();
                        txtDateOfBirth.Text = oledbCaseDtl["DOB"].ToString();
                        txtLandmark.Text = oledbCaseDtl["RES_LAND_MARK"].ToString();
                    }

                    /////////add code for Hdfc Noc////////////////////////
                    if (oledbCaseDtl_Noc.Read() == true)
                    {
                        ddlSellConfMem.SelectedValue = oledbCaseDtl_Noc["Name_Seller_conf_neigh"].ToString();
                        ddlSellTran.SelectedValue = oledbCaseDtl_Noc["Seller_aware"].ToString();
                        ddlFlatNo.SelectedValue = oledbCaseDtl_Noc["flat_no"].ToString();
                        ddlSellLoan.SelectedValue = oledbCaseDtl_Noc["sell_finan_institution"].ToString();
                        ddlAuthen.SelectedValue = oledbCaseDtl_Noc["Authenticity"].ToString();

                        /////////end code/////////////////////////////////////
                    }

                    if (oledbReadRV.Read() == true)
                    {
                        string sTmpDate = oledbReadRV["VERIFICATION_DATETIME"].ToString();
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
                        txtPersonContacted.Text = oledbReadRV["PERSON_CONTACTED"].ToString();
                        txtRelationship.Text = oledbReadRV["Relationship"].ToString();
                        txtAddress.Text = oledbReadRV["Address"].ToString();
                        txtCity.Text = oledbReadRV["CITY"].ToString();
                        txtPincode.Text = oledbReadRV["PINCODE"].ToString();
                        txtLandmark.Text = oledbReadRV["Landmark"].ToString();
                        txtTelNo.Text = oledbReadRV["TEL_NO_TYPE_PHONE"].ToString();
                        txtMobileNoOrTypeOfPhone.Text = oledbReadRV["Mobile_No_type_phone"].ToString();
                        txtLoanAmount.Text = oledbReadRV["Loan_Amount"].ToString();
                        txtUseOfLoan.Text = oledbReadRV["Use_of_loan"].ToString();
                        txtProduct.Text = oledbReadRV["Product"].ToString();
                        txtLocationOfProduct.Text = oledbReadRV["Location_Product"].ToString();
                        txtDateOfBirth.Text = oledbReadRV["DOB"].ToString();
                        ddlMaritalStatus.SelectedValue = oledbReadRV["MARITAL_STATUS"].ToString();
                        ddlEducationBackgroud.SelectedValue = oledbReadRV["EDUCATION_BACKGROUND"].ToString();
                        txtFamilyDetails.Text = oledbReadRV["FAMILY_DETAILS"].ToString();
                        txtDetailsOfWorkingMembersSpouse.Text = oledbReadRV["SPOUSE_DETAILS"].ToString();
                        txtTotalFamilyIncome.Text = oledbReadRV["FAMILY_INCOME"].ToString();
                        txtDetailsOfWorkingMembersOthers.Text = oledbReadRV["OTHER_DETAILS"].ToString();
                        ddlLoanCancellation.SelectedValue = oledbReadRV["Loan_Cancellation"].ToString();
                        txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text = oledbReadRV["CREDIT_CARD_LIMIT"].ToString();
                        txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text = oledbReadRV["OTHER_LOAN_DATAIL"].ToString();

                        //Added by abhijeet 
                        ddlSupervisorName.SelectedValue = oledbReadRV["Supervisorname"].ToString();
                        //ended by abhijeet
                     
                        string sTmp = oledbReadRV["YEARS_AT_RESIDENCE"].ToString();
                        if (sTmp.Trim() != "")
                        {
                            string[] arrNoOfCurrResi = sTmp.Split('.');
                            txtNoOfYrsAtCurrResi.Text = arrNoOfCurrResi[0].ToString();
                            if (arrNoOfCurrResi.Length > 1)
                                txtNoOfMthsAtCurrResi.Text = arrNoOfCurrResi[1].ToString();
                        }
                        //txtAreaOfHouse.Text = oledbReadRV["Area_of_House"].ToString();
                        //txtAssets.Text = oledbReadRV["ASSETS"].ToString();
                        ///For Asset Checkboxes---------------------------------------------------
                        string sTmpAsset = oledbReadRV["ASSETS"].ToString();
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
                        txtDetailsoffurnitureSeen.Text = oledbReadRV["DETAIL_FURNITURE_SEEN"].ToString();
                        txtOwnershipOfResidence.Text = oledbReadRV["Ownership_RESIDENCE"].ToString();
                        //txtStayingwithWhome.Text = oledbReadRV["STAYING_WHOM"].ToString();
                        objRV.StayingWithWhom = oledbReadRV["STAYING_WHOM"].ToString();
                        if (objRV.StayingWithWhom != "Parents" && objRV.StayingWithWhom != "Spouse" && objRV.StayingWithWhom != "Relatives" &&
                            objRV.StayingWithWhom != "Friends" && objRV.StayingWithWhom != "Collegue" && objRV.StayingWithWhom != "")
                        {
                            ddlApplicantLivesWith.SelectedValue = "Other";
                            txtOtherApplicantLivesWith.Text = objRV.StayingWithWhom;
                        }
                        else
                            ddlApplicantLivesWith.SelectedValue = objRV.StayingWithWhom;

                        txtDSA.Text = oledbReadRV["DSA"].ToString();
                        txtTenure.Text = oledbReadRV["Tenure"].ToString();
                        txtMonths.Text = oledbReadRV["Months"].ToString();
                        objRV.Type = oledbReadRV["Type"].ToString();
                        if (objRV.Type != "Ownership" && objRV.Type != "Parental" && objRV.Type != "Self Owned" &&
                            objRV.Type != "Relative Owned" && objRV.Type != "Friend Owned" && objRV.Type != "Bachelor Accomodation" &&
                            objRV.Type != "Rented" && objRV.Type != "Company Accomodation" && objRV.Type != "PG" && objRV.Type != "Govt,Quaters" && objRV.Type != "")
                        {
                            ddlType.SelectedValue = "Other";
                            txtOtherType.Text = objRV.Type;
                        }
                        else
                            ddlType.SelectedValue = objRV.Type;


                        txtNameontheSocietyAddressboard.Text = oledbReadRV["Name_Society_Board"].ToString();
                        ddlNamePlateonDoor.SelectedValue = oledbReadRV["Nameplate_on_door"].ToString();
                        txtOwnershipDetails.Text = oledbReadRV["Ownership_Details"].ToString();
                        //txtPermanentAddress.Text = oledbReadRV["Permanent_address"].ToString();
                        txtNumberofRooms.Text = oledbReadRV["Number_rooms"].ToString();
                        txtApproximateValue.Text = oledbReadRV["Approximate_Value"].ToString();
                        txtBachelorAccomodation.Text = oledbReadRV["Bachelor_Accomodation"].ToString();
                        objRV.Locality = oledbReadRV["Locality"].ToString();
                        if (objRV.Locality != "Posh" && objRV.Locality != "Upper Middle Class" && objRV.Locality != "Lower Middle Class" &&
                            objRV.Locality != "Middle Class" && objRV.Locality != "Poor" && objRV.Locality != "Slum" &&
                            objRV.Locality != "Under Developed" && objRV.Locality != "")
                        {
                            ddlLocality.SelectedValue = "Other";
                            txtOtherLocality.Text = objRV.Locality;
                        }
                        else
                            ddlLocality.SelectedValue = objRV.Locality;

                        txtVehicleCurrenlyUsed.Text = oledbReadRV["Vehicles_used"].ToString();
                        txtVehiclesFinancedNFinancerName.Text = oledbReadRV["Vehicles_financed"].ToString();
                        ddlDescribeExteriorPremises.SelectedValue = oledbReadRV["Exterior_Premises"].ToString();
                        ddlDescribeInteriorPremises.SelectedValue = oledbReadRV["interior_Premises"].ToString();
                        txtNameOfNeighbour1.Text = oledbReadRV["Name_Neighbour1"].ToString();
                        txtAddressOfNeighbour1.Text = oledbReadRV["ADD_Neighbour1"].ToString();
                        ddlDoesTheApplicantStayHere1.SelectedValue = oledbReadRV["CONFIRM_Neighbour1"].ToString();
                        ddlStatusofResidence1.SelectedValue = oledbReadRV["RESSTATUS_Neighbour1"].ToString();
                        txtMonthsOfStayAtresidence1.Text = oledbReadRV["Stay_Res_Neighbour1"].ToString();
                        txtCommentsOfNeighbour1.Text = oledbReadRV["Comments_Neighbour1"].ToString();
                        txtNameOfNeighbour2.Text = oledbReadRV["Name_Neighbour2"].ToString();
                        txtAddressOfNeighbour2.Text = oledbReadRV["ADD_Neighbour2"].ToString();
                        ddlDoestheApplicantStayHere2.SelectedValue = oledbReadRV["CONFIRM_Neighbour2"].ToString();
                        ddlStatusofResidence2.SelectedValue = oledbReadRV["RESSTATUS_Neighbour2"].ToString();
                        txtMonthsofStayatresidence2.Text = oledbReadRV["Stay_Res_Neighbour2"].ToString();
                        txtCommentsofNeighbour2.Text = oledbReadRV["Comments_Neighbour2"].ToString();
                        txtTypeOfAccmodation.Text = oledbReadRV["Type_Accmodation"].ToString();
                        ddlEntryPermitted.SelectedValue = oledbReadRV["Entry_Permitted"].ToString();
                        ddlIdentityProofSeen.SelectedValue = oledbReadRV["Identity_Proof_Seen"].ToString();
                        txtApplicantIncome.Text = oledbReadRV["Applicant_income"].ToString();
                        txtNameOfCompanyWhereAppEmployed.Text = oledbReadRV["Company_name"].ToString();
                        //txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text = oledbReadRV["Approximate_Value"].ToString();
                        //txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text = oledbReadRV["Approximate_Value"].ToString();
                        txtPurposeOfLoanTaken.Text = oledbReadRV["Purpose_loan"].ToString();
                        txtOtherSourceOfIncome.Text = oledbReadRV["other_source_income"].ToString();
                        ddlOtherInvestment.SelectedValue = oledbReadRV["Other_Investment"].ToString();
                        txtColourOfDoor.Text = oledbReadRV["Colour_of_Door"].ToString();
                        ddlRoomType.SelectedValue = oledbReadRV["Room_Type"].ToString();

                        objRV.TypeOfHouse = oledbReadRV["Type_of_House"].ToString();
                        if (objRV.TypeOfHouse != "Bungalow" && objRV.TypeOfHouse != "Flat" && objRV.TypeOfHouse != "Individual House" &&
                            objRV.TypeOfHouse != "Standing Chawl/Janata Flat" && objRV.TypeOfHouse != "Sitting Chawl/Hutment" && objRV.TypeOfHouse != "Slum" &&
                            objRV.TypeOfHouse != "Staff Quarters" && objRV.TypeOfHouse != "Lodge/Hotel" && objRV.TypeOfHouse != "Annexe To House" &&
                            objRV.TypeOfHouse != "Multi-Tenant House" && objRV.TypeOfHouse != "Small Independent House" && objRV.TypeOfHouse != "Chawl" &&
                            objRV.TypeOfHouse != "Kothi" && objRV.TypeOfHouse != "Temporary Shed" && objRV.TypeOfHouse != "Hutment" && objRV.TypeOfHouse != "Baitha Chawl" &&
                            objRV.TypeOfHouse != "Chawl Type Bldg with Common Toilet" && objRV.TypeOfHouse != "Cottage" && objRV.TypeOfHouse != "Row House" &&
                            objRV.TypeOfHouse != "Part of Indepandant Bunglow" && objRV.TypeOfHouse != "Bunglow / Villa" && objRV.TypeOfHouse != "")
                        {
                            ddlTypeOfHouse.SelectedValue = "Other";
                            txtOtherTypeOfHouse.Text = objRV.TypeOfHouse;
                        }
                        else
                            ddlTypeOfHouse.SelectedValue = objRV.TypeOfHouse;

                        txtAnyOtherLoanOnApplicantName.Text = oledbReadRV["loan_applicant_name"].ToString();
                        txtVehicleOwnership.Text = oledbReadRV["Vehicles_Ownership"].ToString();
                        ddlResiAddIsInNegativeArea.SelectedValue = oledbReadRV["Residence_address_negative"].ToString();
                        txtApproachToResidence.Text = oledbReadRV["Approch_Residence"].ToString();
                        txtTypeOfRoof.Text = oledbReadRV["Type_Roof"].ToString();
                        ddlTelCDRomCheck.SelectedValue = oledbReadRV["Telephone_check"].ToString();
                        txtLocationOfHouse.Text = oledbReadRV["Location_house"].ToString();
                        ddlCityLimit1.SelectedValue = oledbReadRV["City_Limit"].ToString();
                        ddlStandardOfLiving.SelectedValue = oledbReadRV["Standard_of_Living"].ToString();
                        txtWalls.Text = oledbReadRV["Walls"].ToString();
                        txtFlooring.Text = oledbReadRV["Flooring"].ToString();
                        ddlIsAddOfApplicantName.SelectedValue = oledbReadRV["IS_appname_address"].ToString();
                        txtNoOfMember.Text = oledbReadRV["No_of_dependent"].ToString();
                        txtAgeOfApplicant.Text = oledbReadRV["age_applicant"].ToString();
                        txtNameAddressOfThirdParty.Text = oledbReadRV["Name_add_third_party"].ToString();
                        txtTimeWhenAppIsInHome.Text = oledbReadRV["Time_app_at_home"].ToString();
                        txtThirdPartyComment.Text = oledbReadRV["Third_party_comment"].ToString();
                        ddlAddressProofSighted.SelectedValue = oledbReadRV["Address_Proof_Sighted"].ToString();
                        ddlTalliesWithCurrentAddress.SelectedValue = oledbReadRV["Tallies_current_Address"].ToString();
                        txtTypeOfAddProof.Text = oledbReadRV["Type_of_Add_Proof"].ToString();
                        ddlResiOCL.SelectedValue = oledbReadRV["Resi_OCL"].ToString();
                        ddlIsAffilatedToPoliticalParty.SelectedValue = oledbReadRV["Affliated_Political_Party"].ToString();
                        txtProfile.Text = oledbReadRV["Profile"].ToString();
                        ddlAddressConfirmed.SelectedValue = oledbReadRV["Address_Confirmed"].ToString();
                        ddlHowCooperativeCustomer.SelectedValue = oledbReadRV["How_Cooperative"].ToString();
                        objRV.EaseOfLocation = oledbReadRV["Locating_address"].ToString();
                        if (objRV.EaseOfLocation != "Easily Accessible" && objRV.EaseOfLocation != "Difficult" &&
                           objRV.EaseOfLocation != "Untraceable" && objRV.EaseOfLocation != "")
                        {
                            ddlEaseOfLocation.SelectedValue = "Other";
                            txtOtherEaseOfLocation.Text = objRV.EaseOfLocation;
                        }
                        else
                            ddlEaseOfLocation.SelectedValue = objRV.EaseOfLocation;

                        txtAgencyName.Text = oledbReadRV["Agency_Code"].ToString();
                        ddlAccessibility.SelectedValue = oledbReadRV["Accessibility"].ToString();
                        ddlEntranceMotorable.SelectedValue = oledbReadRV["Entrance_Motorable"].ToString();
                        ddlSocietyBoardSighted.SelectedValue = oledbReadRV["Society_Board_Sighted"].ToString();
                        txtMothersName.Text = oledbReadRV["Mother_Name"].ToString();
                        txtAddressOfCompany.Text = oledbReadRV["Address_Company"].ToString();
                        ddlBehavourOfPersonContacted.SelectedValue = oledbReadRV["Behavior_Person_Contacted"].ToString();
                        txtVerifierComments.Text = oledbReadRV["Verifier_Comments"].ToString();
                        ddlOverallVerification.SelectedValue = oledbReadRV["Verification_status"].ToString();
                        txtNoOfEaringMembers.Text = oledbReadRV["No_of_earning_member"].ToString();
                        ddlIfVehicleExist.SelectedValue = oledbReadRV["If_Vehicle_exist"].ToString();
                        ddlVehicleType.SelectedValue = oledbReadRV["Vehicle_Type"].ToString();
                        ddlDoorLocked.SelectedValue = oledbReadRV["Door_Locked"].ToString();
                        txtSendDate.Text = oledbReadRV["Sent_Datetime"].ToString();
                        txtTotalYrsInCity.Text = oledbReadRV["Totals_Yrs_City"].ToString();
                        txtNameAddOf1Reference.Text = oledbReadRV["Name_add_Ref1"].ToString();
                        txtIfOCLDistance.Text = oledbReadRV["OCL_than_distance"].ToString();
                        ddlParkingFacility.SelectedValue = oledbReadRV["Parking_Facility"].ToString();
                        ddlNegmatch.SelectedValue = oledbReadRV["Neg_match"].ToString();
                        txtReasonForNotRecomdNReferred.Text = oledbReadRV["Reason_Notrecommended"].ToString();
                        txtFatherSpouseName.Text = oledbReadRV["Father_Spouse_Name"].ToString();
                        ddlSepBathroom.SelectedValue = oledbReadRV["SEP_BATHROOM_SEEN"].ToString();
                        ddlFamilySeen.SelectedValue = oledbReadRV["FAMILY_SEEN"].ToString();
                        ddlRoofType.SelectedValue = oledbReadRV["ROOF_TYPE"].ToString();
                        txtSupervisorComments.Text = oledbReadRV["SUPERVISOR_COMMENTS"].ToString();
                        //added by kamal matekar.......
                        txtPagerNo.Text = oledbReadRV["Pager_No"].ToString();
                       // ddlVisibleItems.SelectedValue = oledbReadRV["Visible_Items"].ToString();
                        string sTmpVisibleItems = oledbReadRV["Visible_Items"].ToString();
                        string[] arrVisibleItems = sTmpVisibleItems.Split(',');
                       
                        if (arrVisibleItems.Length > 0)
                        {
                            for (int i = 0; i < arrVisibleItems.Length; i++)
                            {
                                foreach (ListItem li in chkvisibleItems.Items)
                                {
                                    if (li.Value == arrVisibleItems.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                       
                        txtNoOfWindow.Text = oledbReadRV["No_of_Windows"].ToString();
                        //ended..........

                    }
                    oledbCaseDtl.Close();
                    oledbReadRV.Close();
                    txtPersonContacted.Focus();
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
        if (sCaseId != "")//bpocareer@deltaindia.com, jobs@tecogis.com 
        {
            dsTeleCallLog = objRV.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            dsTeleCallLog1 = objRV.GetTeleCallLogDetail1(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATETIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtAttemptTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlAttemptTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtAttemptRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["Attempt_REMARK"].ToString();
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
        string sCommentNeigh1 = "";
        string sCommentNeigh2 = "";
        string sVerifierComment = "";
        string sThirdPartyComment = "";
        sCommentNeigh1 = txtCommentsOfNeighbour1.Text.Trim();
        sCommentNeigh2 = txtCommentsofNeighbour2.Text.Trim();
        sVerifierComment = txtVerifierComments.Text.Trim();
        sThirdPartyComment = txtThirdPartyComment.Text.Trim();

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
        int iCount = 0;
        string sMsg = "";
        string sMsg1 = "";
        try
        {
            if (ValidateTextArea() == true)
            {
                CRL_VisitVerification objRV = new CRL_VisitVerification();
                objRV.CaseId = Request.QueryString["CaseId"].ToString();
                objRV.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
                objRV.Verifier = txtVerifiersName.Text.Trim();    
                objRV.DateTimeOfVerification = txtDateOfVerification.Text.Trim() + " " + txtTimeOfVerification.Text.Trim() + " " + ddlDateTimeOfVerification.SelectedItem.Text.Trim();                                    
                objRV.NameOfPersonMet = txtPersonContacted.Text.Trim();
                objRV.Relationship = txtRelationship.Text.Trim();
                objRV.Address = txtAddress.Text.Trim();
                objRV.City = txtCity.Text.Trim();
                objRV.PinCode = txtPincode.Text.Trim();
                objRV.Landmark = txtLandmark.Text.Trim();
                objRV.TeleNoType = txtTelNo.Text.Trim();
                objRV.MobileNoType = txtMobileNoOrTypeOfPhone.Text.Trim();
                objRV.LoanAmount = txtLoanAmount.Text.Trim();
                objRV.UseOfLoan = txtUseOfLoan.Text.Trim();
                objRV.Product = txtProduct.Text.Trim();
                objRV.LocationOfProduct = txtLocationOfProduct.Text.Trim();
                objRV.DateOfBirth = txtDateOfBirth.Text.Trim();
                objRV.MaritalStatus = ddlMaritalStatus.SelectedValue.ToString();
                objRV.EducationalBackground = ddlEducationBackgroud.SelectedValue.ToString();
                objRV.FamilyDetails = txtFamilyDetails.Text.Trim();
                objRV.DetailsOfWorkingMemberSpouse = txtDetailsOfWorkingMembersSpouse.Text.Trim();
                objRV.TotalFamIncome = txtTotalFamilyIncome.Text.Trim();
                objRV.DetailsOfWorkingMembersOthers = txtDetailsOfWorkingMembersOthers.Text.Trim();
                objRV.LoanCancellation = ddlLoanCancellation.SelectedValue.ToString();
                objRV.AnyCreditCard = txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text.Trim();//-----
                objRV.AnyOtherLoan = txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text.Trim(); //-----
                objRV.NoOfYrsAtResidence = txtNoOfYrsAtCurrResi.Text.Trim() + "." + txtNoOfMthsAtCurrResi.Text.Trim();
                //objRV.AreaOfHouse = txtAreaOfHouse.Text.Trim();
                objRV.CityLimit = ddlCityLimit1.SelectedValue.ToString();    
                
                /////////////add code for hdfc noc///////////////////////
                objRV.SellConfMem = ddlSellConfMem.SelectedValue.ToString();
                objRV.SellTran = ddlSellTran.SelectedValue.ToString();
                objRV.FlatNo = ddlFlatNo.SelectedValue.ToString();
                objRV.SellLoan = ddlSellLoan.SelectedValue.ToString();
                objRV.Authen = ddlAuthen.SelectedValue.ToString();


                //Added by abhijeet 


                objRV.Supervisorname = ddlSupervisorName.SelectedValue.Trim();

                //ended by abhijeet

                /////////////end code////////////////////////////////////
                
                //objRV.Assets = txtAssets.Text.Trim();
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

                objRV.Assets = sAssets.TrimEnd(',');
                objRV.DetailsOfFurnitureSeen = txtDetailsoffurnitureSeen.Text.Trim();
                objRV.OwnershipOfResidence = txtOwnershipOfResidence.Text.Trim();
                objRV.StayingWithWhom = ddlApplicantLivesWith.SelectedValue.ToString();
                objRV.DSA = txtDSA.Text.Trim();
                objRV.Tenure = txtTenure.Text.Trim();
                objRV.Months = txtMonths.Text.Trim();
                if (ddlType.SelectedValue.ToString() != "Other")
                    objRV.Type = ddlType.SelectedValue.ToString();
                else
                    objRV.Type = txtOtherType.Text.Trim();

                objRV.NameOnSocietyAddressBoard = txtNameontheSocietyAddressboard.Text.Trim();
                objRV.NameplateOnDoor = ddlNamePlateonDoor.SelectedValue.ToString();
                objRV.OwnershipDetail = txtOwnershipDetails.Text.Trim();
                //objRV.PermanentAddress = txtPermanentAddress.Text.Trim();
                objRV.NoOfRooms = txtNumberofRooms.Text.Trim();
                objRV.ApproximateValue = txtApproximateValue.Text.Trim();
                objRV.BachelorAccomodation = txtBachelorAccomodation.Text.Trim();
                if (ddlLocality.SelectedValue.ToString() != "Other")
                    objRV.Locality = ddlLocality.SelectedValue.ToString();
                else
                    objRV.Locality = txtOtherLocality.Text.Trim();

                objRV.VehiclesCurrentlyUsed = txtVehicleCurrenlyUsed.Text.Trim();
                objRV.VehiclesFinancedNFinancerName = txtVehiclesFinancedNFinancerName.Text.Trim();
                objRV.DescribeExteriorPremises = ddlDescribeExteriorPremises.SelectedItem.ToString();
                objRV.DescribeInteriorPremises = ddlDescribeInteriorPremises.SelectedItem.ToString();  
                objRV.NameOfNeighbour1 = txtNameOfNeighbour1.Text.Trim();
                objRV.AddressOfNeighbour1 = txtAddressOfNeighbour1.Text.Trim();
                objRV.DoesAppWorkHere1 = ddlDoesTheApplicantStayHere1.SelectedValue.ToString();
                objRV.StatusOfResidence1 = ddlStatusofResidence1.SelectedValue.ToString();
                objRV.MthsOfWorkAtOffice1 = txtMonthsOfStayAtresidence1.Text.Trim();
                objRV.CommentsOfNeighbour1 = txtCommentsOfNeighbour1.Text.Trim();
                objRV.NameOfNeighbour2 = txtNameOfNeighbour2.Text.Trim();
                objRV.AddressOfNeighbour2 = txtAddressOfNeighbour2.Text.Trim();
                objRV.DoesAppWorkHere2 = ddlDoestheApplicantStayHere2.SelectedValue.ToString();
                objRV.StatusOfResidence2 = ddlStatusofResidence2.SelectedValue.ToString();
                objRV.MthsOfWorkAtOffice2 = txtMonthsofStayatresidence2.Text.Trim();
                objRV.CommentsOfNeighbour2 = txtCommentsofNeighbour2.Text.Trim();
                objRV.TypeOfAccmodation = txtTypeOfAccmodation.Text.Trim();
                objRV.EntryPermitted = ddlEntryPermitted.SelectedValue.ToString();
                objRV.IdentityProofSeen = ddlIdentityProofSeen.SelectedValue.ToString();
                objRV.ApplicantIncome = txtApplicantIncome.Text.Trim();
                objRV.NameOfCompany = txtNameOfCompanyWhereAppEmployed.Text.Trim();
                objRV.AnyCreditCard = txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text.Trim();
                objRV.AnyOtherLoan = txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text.Trim();
                objRV.PurposeOfLoanTaken = txtPurposeOfLoanTaken.Text.Trim();
                objRV.OtherSourceOfIncome = txtOtherSourceOfIncome.Text.Trim();
                objRV.OtherInvestment = ddlOtherInvestment.SelectedValue.ToString();
                objRV.ClourOnDoor = txtColourOfDoor.Text.Trim();
                objRV.RoomType = ddlRoomType.SelectedValue.ToString();
                if (ddlTypeOfHouse.SelectedValue.ToString() != "Other")
                    objRV.TypeOfHouse = ddlTypeOfHouse.SelectedValue.ToString();
                else
                    objRV.TypeOfHouse = txtOtherTypeOfHouse.Text.Trim();
                objRV.AnyOtherLoanOnApplicantName = txtAnyOtherLoanOnApplicantName.Text.Trim();
                objRV.VehiclesOwnership = txtVehicleOwnership.Text.Trim();
                objRV.MatchInNegativeList = ddlResiAddIsInNegativeArea.SelectedValue.ToString();

                //objRV.ResiAddressIsWithInAreaLimit = ddlResiAddIsWithInAreaLimit.SelectedItem.Text.Trim();
                objRV.ApproachToResidence = txtApproachToResidence.Text.Trim();
                objRV.TypeOfRoof = txtTypeOfRoof.Text.Trim();
                objRV.TeleCDRomCheck = ddlTelCDRomCheck.SelectedValue.ToString();
                objRV.LocationOfHouse = txtLocationOfHouse.Text.Trim();
                //objRV.ApporachToHouse = txtApproachToHouse.Text.Trim();
                objRV.StandardOfLiving = ddlStandardOfLiving.SelectedValue.ToString();
                objRV.Walls = txtWalls.Text.Trim();
                objRV.Flooring = txtFlooring.Text.Trim();
                objRV.IsAddOfAppSame = ddlIsAddOfApplicantName.SelectedValue.ToString();
                objRV.NoOfMembers = txtNoOfMember.Text.Trim();
                objRV.AgeOfApplicant = txtAgeOfApplicant.Text.Trim();
                objRV.NameAddOfThirdParty = txtNameAddressOfThirdParty.Text.Trim();
                objRV.TimeWhenAppIsHome = txtTimeWhenAppIsInHome.Text.Trim();
                objRV.ThirdPartyComments = txtThirdPartyComment.Text.Trim();
                objRV.AddressProofSighted = ddlAddressProofSighted.SelectedValue.ToString();
                objRV.TalliesWithCurrentAddress = ddlTalliesWithCurrentAddress.SelectedValue.ToString();
                objRV.TypeOfAddProof = txtTypeOfAddProof.Text.Trim();
                objRV.ResiOCL = ddlResiOCL.SelectedValue.ToString();
                objRV.IsAffilatedToPoliticalParty = ddlIsAffilatedToPoliticalParty.SelectedItem.ToString();  
                objRV.Profile = txtProfile.Text.Trim();
                objRV.AddressConfirmed = ddlAddressConfirmed.SelectedValue.ToString();
                objRV.HowCooperativeCustomer = ddlHowCooperativeCustomer.SelectedValue.ToString();

                if (ddlEaseOfLocation.SelectedValue.ToString() != "Other")
                    objRV.EaseOfLocation = ddlEaseOfLocation.SelectedValue.ToString();
                else
                    objRV.EaseOfLocation = txtOtherEaseOfLocation.Text.Trim();
                objRV.AgencyCode = txtAgencyName.Text.Trim();
                objRV.Accessibility = ddlAccessibility.SelectedValue.ToString();
                objRV.EntranceMotorable = ddlEntranceMotorable.SelectedValue.ToString();
                objRV.SocietyBoardSighted = ddlSocietyBoardSighted.SelectedValue.ToString();
                objRV.MothersName = txtMothersName.Text.Trim();
                objRV.AddressOfCompany = txtAddressOfCompany.Text.Trim();
                objRV.BehavourOfPersonContact = ddlBehavourOfPersonContacted.SelectedValue.ToString();
                objRV.VerifierComments = txtVerifierComments.Text.Trim();
                objRV.OverallVerification = ddlOverallVerification.SelectedValue.ToString();
                objRV.NoOfEaringMembers = txtNoOfEaringMembers.Text.Trim();
                objRV.IfVehicleExist = ddlIfVehicleExist.SelectedValue.ToString();
                objRV.VehicleType = ddlVehicleType.SelectedValue.ToString();
                objRV.DoorLocked = ddlDoorLocked.SelectedItem.ToString();  
                objRV.SendDate = txtSendDate.Text.Trim();
                objRV.TotalYrsInCity = txtTotalYrsInCity.Text.Trim();
                objRV.NameAddOf1Reference = txtNameAddOf1Reference.Text.Trim();
                objRV.IfOCLDistance = txtIfOCLDistance.Text.Trim();
                objRV.ParkingFacility = ddlParkingFacility.SelectedValue.ToString();
                objRV.Negmatch = ddlNegmatch.SelectedValue.ToString();
                objRV.ReasonForNotRecomdNReferred = txtReasonForNotRecomdNReferred.Text.Trim();
                objRV.FatherSpouseName = txtFatherSpouseName.Text.Trim();
                  
                //added by hemangi kambli on 07/09/2007--------------
                objRV.AddedBy = Session["UserId"].ToString();
                objRV.AddedOn = DateTime.Now;
                objRV.ModifyBy = Session["UserId"].ToString();
                objRV.ModifyOn = DateTime.Now;
                ///------------------------------------------------------
                //Added by hemangi kambli on 01/10/2007 
                if (hdnTransStart.Value != "")
                    objRV.TransStart = Convert.ToDateTime(hdnTransStart.Value);
                objRV.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
                objRV.CentreId = Session["CentreId"].ToString();
                objRV.ProductId = Session["ProductId"].ToString();
                objRV.ClientId = Session["ClientId"].ToString();
                objRV.UserId = Session["UserId"].ToString();
                ///------------------------------------------------------
                //Added by hemangi kambli on 03/10/2007 
                objRV.SeparateBathroom = ddlSepBathroom.SelectedValue.ToString();
                objRV.FamilySeen = ddlFamilySeen.SelectedValue.ToString();
                objRV.SupervisorComment = txtSupervisorComments.Text.Trim();
                objRV.RoofType = ddlRoofType.SelectedValue.ToString();
                //---------------------------------------------
                //added by kamal matekar for fedreal finance----
                objRV.PagerNo = txtPagerNo.Text.Trim();
              //  objRV.VisibleItems = ddlVisibleItems.SelectedValue.ToString();
                string sVisibleItems = "";
                if (chkvisibleItems.Items.Count > 0)
                {
                    foreach (ListItem li in chkvisibleItems.Items)
                    {
                        //if (li.Text.Trim() == "Others(P1. Specify)" && li.Selected == true)
                        //    VisibleItems += li.Value + "," + txtIfOtherInterior.Text.Trim();
                        //else
                            if (li.Selected == true)
                                sVisibleItems += li.Value + ",";
                    }
                }
                objRV.VisibleItems = sVisibleItems.TrimEnd(',');

                objRV.NoOfWindow = txtNoOfWindow.Text.Trim();
                ///ended----
                InsertTeleCallLog();
                sMsg = objRV.InsertUpdateRLResiVerificationEntry();
                sMsg1 = objRV.InsertUpdateRLResiVerificationEntry_Noc();
               

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
            objRV.CaseId = strCaseID;
            
            objRV.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
            CCommon objCom = new CCommon();
            if (txtDate1.Text.Trim() != "" && txtAttemptTime1.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1.Text.Trim()) + " " + txtAttemptTime1.Text.Trim() + " " + ddlAttemptTimeType1.SelectedItem.Text.Trim());
                arrLog1stCall.Add(txtAttemptRemark1.Text.Trim());
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

            if (objRV.InsertTeleCallLog(arrTeleCallLog) == 1)
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

    public void funShowPanel()
    {
        CGet objCGet = new CGet();
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "32";
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
                    objPlaceHolder = (PlaceHolder)(tblResiVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblResiVerification.Rows[1].Cells[0].FindControl(strPanelName));
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
            case "Noc":
                lbNoc.Visible = true;
                break;
            case "Vend":
                lbVend.Visible = true;
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
    
    protected void lbNoc_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceVerification_Noc.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=32&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    protected void lbVend_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_ResidenceVerification_Vend.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=31&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }
    private void IfIsEditFalse()
    {
        txtLanNo.Enabled = false;
        txtDateAndTime.Enabled = false;
        //txtAppName.Enabled = false;
        txtAddress.Enabled = false;
        txtCity.Enabled = false;
        txtPincode.Enabled = false;
        txtDateOfBirth.Enabled = false;
        txtLandmark.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtTimeOfVerification.Enabled = false;
        ddlDateTimeOfVerification.Enabled = false;
        txtPersonContacted.Enabled = false;
        txtRelationship.Enabled = false;
        //txtAddress.Enabled = false;
        txtCity.Enabled = false;
        txtPincode.Enabled = false;
        txtLandmark.Enabled = false;
        txtTelNo.Enabled = false;
        txtMobileNoOrTypeOfPhone.Enabled = false;
        txtLoanAmount.Enabled = false;
        txtUseOfLoan.Enabled = false;
        txtProduct.Enabled = false;
        txtLocationOfProduct.Enabled = false;
        txtDateOfBirth.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        ddlEducationBackgroud.Enabled = false;
        txtFamilyDetails.Enabled = false;
        txtDetailsOfWorkingMembersSpouse.Enabled = false;
        txtTotalFamilyIncome.Enabled = false;
        txtDetailsOfWorkingMembersOthers.Enabled = false;
        ddlLoanCancellation.Enabled = false;
        txtAnyCreditCardsIfYesProvidNameandLimitonEach.Enabled = false;
        txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Enabled = false;
        txtNoOfYrsAtCurrResi.Enabled = false;
        txtNoOfMthsAtCurrResi.Enabled = false;
        //txtAreaOfHouse.Enabled = false;
        ddlCityLimit1.Enabled = false;  
        ///For Asset Checkboxes---------------------------------------------------
        chkAssets.Enabled = false;
        txtOtherAssets.Enabled = false;
        ////--------------------------------------------------------------------  
        txtDetailsoffurnitureSeen.Enabled = false;
        txtOwnershipOfResidence.Enabled = false;
        ddlApplicantLivesWith.Enabled = false;
        txtOtherApplicantLivesWith.Enabled = false;
        txtDSA.Enabled = false;
        txtTenure.Enabled = false;
        txtMonths.Enabled = false;
        ddlType.Enabled = false;
        txtOtherType.Enabled = false;
        txtNameontheSocietyAddressboard.Enabled = false;
        ddlNamePlateonDoor.Enabled = false;
        txtOwnershipDetails.Enabled = false;
       // txtPermanentAddress.Enabled = false;
        txtNumberofRooms.Enabled = false;
        txtApproximateValue.Enabled = false;
        txtBachelorAccomodation.Enabled = false;
        ddlLocality.Enabled = false;
        txtOtherLocality.Enabled = false;
        ddlLocality.Enabled = false;
        txtVehicleCurrenlyUsed.Enabled = false;
        txtVehiclesFinancedNFinancerName.Enabled = false;
        ddlDescribeExteriorPremises.Enabled = false;
        ddlDescribeInteriorPremises.Enabled = false;
        txtNameOfNeighbour1.Enabled = false;
        txtAddressOfNeighbour1.Enabled = false;
        ddlDoesTheApplicantStayHere1.Enabled = false;
        ddlStatusofResidence1.Enabled = false;
        txtMonthsOfStayAtresidence1.Enabled = false;
        txtCommentsOfNeighbour1.Enabled = false;
        txtNameOfNeighbour2.Enabled = false;
        txtAddressOfNeighbour2.Enabled = false;
        ddlDoestheApplicantStayHere2.Enabled = false;
        ddlStatusofResidence2.Enabled = false;
        txtMonthsofStayatresidence2.Enabled = false;
        txtCommentsofNeighbour2.Enabled = false;
        txtTypeOfAccmodation.Enabled = false;
        ddlEntryPermitted.Enabled = false;
        ddlIdentityProofSeen.Enabled = false;
        txtApplicantIncome.Enabled = false;
        txtNameOfCompanyWhereAppEmployed.Enabled = false;
        txtPurposeOfLoanTaken.Enabled = false;
        txtOtherSourceOfIncome.Enabled = false;
        ddlOtherInvestment.Enabled = false;
        txtColourOfDoor.Enabled = false;
        ddlRoomType.Enabled = false;
        ddlTypeOfHouse.Enabled = false;
        txtOtherTypeOfHouse.Enabled = false;
        txtAnyOtherLoanOnApplicantName.Enabled = false;
        txtVehicleOwnership.Enabled = false;
        ddlResiAddIsInNegativeArea.Enabled = false;
        txtApproachToResidence.Enabled = false;
        txtTypeOfRoof.Enabled = false;
        ddlTelCDRomCheck.Enabled = false;
        txtLocationOfHouse.Enabled = false;
        ddlStandardOfLiving.Enabled = false;
        txtWalls.Enabled = false;
        txtFlooring.Enabled = false;
        ddlIsAddOfApplicantName.Enabled = false;
        txtNoOfMember.Enabled = false;
        txtAgeOfApplicant.Enabled = false;
        txtNameAddressOfThirdParty.Enabled = false;
        txtTimeWhenAppIsInHome.Enabled = false;
        txtThirdPartyComment.Enabled = false;
        ddlAddressProofSighted.Enabled = false;
        ddlTalliesWithCurrentAddress.Enabled = false;
        txtTypeOfAddProof.Enabled = false;
        ddlResiOCL.Enabled = false;
        ddlIsAffilatedToPoliticalParty.Enabled = false;
        txtProfile.Enabled = false;
        ddlAddressConfirmed.Enabled = false;
        ddlHowCooperativeCustomer.Enabled = false;
      
        ddlEaseOfLocation.Enabled = false;
        txtOtherEaseOfLocation.Enabled = false;
        txtAgencyName.Enabled = false;
        ddlAccessibility.Enabled = false;
        ddlEntranceMotorable.Enabled = false;
        ddlSocietyBoardSighted.Enabled = false;
        txtMothersName.Enabled = false;
        txtAddressOfCompany.Enabled = false;
        ddlBehavourOfPersonContacted.Enabled = false;
        txtVerifierComments.Enabled = false;
        ddlOverallVerification.Enabled = false;
        txtNoOfEaringMembers.Enabled = false;
        ddlIfVehicleExist.Enabled = false;
        ddlVehicleType.Enabled = false;
        ddlDoorLocked.Enabled = false;
        txtSendDate.Enabled = false;
        txtTotalYrsInCity.Enabled = false;
        txtNameAddOf1Reference.Enabled = false;
        txtIfOCLDistance.Enabled = false;
        ddlParkingFacility.Enabled = false;
        ddlNegmatch.Enabled = false;
        txtReasonForNotRecomdNReferred.Enabled = false;
        txtFatherSpouseName.Enabled = false;
        ddlSepBathroom.Enabled = false;
        ddlFamilySeen.Enabled = false;
        ddlRoofType.Enabled = false;
        txtSupervisorComments.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtVerifiersName.Enabled = false;

        ddlSellConfMem.Enabled = false;
        ddlSellLoan.Enabled = false;
        ddlSellTran.Enabled = false;
        ddlFlatNo.Enabled = false;
        ddlAuthen.Enabled = false;
        //added by abhijeet

        ddlSupervisorName.Enabled = false;

        //ended by abhijeet
        
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

    
}

