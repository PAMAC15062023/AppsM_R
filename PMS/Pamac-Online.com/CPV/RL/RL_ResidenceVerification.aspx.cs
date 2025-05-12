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

public partial class RL_ResidenceVerification : System.Web.UI.Page
{
    string verificationType = "RV";
    protected void Page_Init(object sender, EventArgs e)
    {
        //added by Sanket during CHOLA
        string sVerifyTypeId = Request.QueryString["VerTypeId"].ToString();
        hidVerificationTypeID.Value = sVerifyTypeId;
        //END

        funShowPanel();
    }
    CRL_VisitVerification objRV = new CRL_VisitVerification();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir

        //NIKHIL 29 august 2013 : adding to change text in reqd panels
        if (Session["ClientId"].ToString() == "101240" && Session["zone"].ToString() == "Mumbai")
        {
            lblMonthsOfStayAtresidence1.Text = "Yrs of stay in city";
            lblExteriors.Text = "Exteriors of Residence";
            lblDedupMatchRemarks.Text = "If Yes,Remarks";
            lblOffDeci.Text = "SHFL officers decision";
        }
        //NIKHIL END

        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }
        if (!IsPostBack)
        {
            try
            {
                Get_Areaname(); 
                GetSupervisorList();
                //To Show the Panels add By Manoj            
                funShowPanel();
                //End
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
                    if ((sVerifyTypeId == "1") || (sVerifyTypeId == "RV"))  //for RV
                        lblHead.Text = "Residence Verification";

                    else if (sVerifyTypeId == "10" || (sVerifyTypeId == "PRV")) //For PRV
                        lblHead.Text = "Permanent Residence Verification";
                    else if (sVerifyTypeId == "36" || (sVerifyTypeId == "PV")) //For PRV
                        lblHead.Text = "Property Verification";

                    Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                    CRL_VisitVerification objRV = new CRL_VisitVerification();
                    OleDbDataReader oledbReadRV;
                    OleDbDataReader oledbReadRV_New;
                    OleDbDataReader oledbCaseDtl;
                    OleDbDataReader oledbFERead;
                    OleDbDataReader oledbFEArea;

                    oledbFEArea = objRV.GetFEAreaName(sCaseId, sVerifyTypeId);
                    oledbReadRV = objRV.GetRVDetail(sCaseId, sVerifyTypeId);
                    oledbReadRV_New = objRV.GetRVDetail_New(sCaseId, sVerifyTypeId);
                    oledbCaseDtl = objRV.GetCASEDetail(sCaseId, sVerifyTypeId);
                    oledbFERead = objRV.GetFEName(sCaseId, sVerifyTypeId);
                    
                    txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    GetTeleCallLog();

                    if (oledbFEArea.Read())
                    {


                        if (oledbFEArea["PincodeArea_Name"].ToString() == "")
                        {
                        }
                        else
                        {
                            btnPincode.Visible = true;
                            txtAreapincode.Visible = true;
                            ddlAreaname.Visible = true;
                          ddlAreaname.SelectedItem.Text = oledbFEArea["PincodeArea_Name"].ToString();

                           // txtAreapincode.Visible = true;
                            // btnPincode.Visible = true;
                        
                        }


                    }
                    if (oledbFERead.Read())
                    {
                        txtVerifiersName.Text = oledbFERead["FullName"].ToString();
                    }
                    if (oledbCaseDtl.Read() == true)
                    {
                        txtLanNo.Text = oledbCaseDtl["REF_NO"].ToString();
                        txtDateAndTime.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                        txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                        txtAddress.Text = oledbCaseDtl["RESIADDRESS"].ToString();
                        txtCity.Text = oledbCaseDtl["RES_CITY"].ToString();
                        txtPincode.Text = oledbCaseDtl["RES_PIN_CODE"].ToString();
                        txtDateOfBirth.Text = oledbCaseDtl["DOB"].ToString();
                        txtLandmark.Text = oledbCaseDtl["RES_LAND_MARK"].ToString();
                        ddlAppType.SelectedItem.Text = oledbCaseDtl["App_Type"].ToString();
                    }
                    if (oledbReadRV.Read() == true)
                    {
                        //New added/Updated for Capri Global
                        txtPhotoIDdetails.Text = oledbReadRV["PhotoIDdetails"].ToString();
                        txtAddrProofdetails.Text = oledbReadRV["AddrProofdetails"].ToString();
                        txtIncomeProofdetails.Text = oledbReadRV["IncomeProofdetails"].ToString();
                        txtSupportingDoc.Text = oledbReadRV["SupportingDoc"].ToString();
                        //END

                        //New added/Updated for CHOLA
                        ddlNameProperty.SelectedValue = oledbReadRV["NamePropertyAsOn"].ToString();
                        txtPhoneNeighbour1.Text = oledbReadRV["PhoneNeighbour1"].ToString();
                        txtOwnerVisitProperty.Text = oledbReadRV["OwnerVisitProperty"].ToString();
                        //END

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

                        //commented by nikhil  23 august 2013:To avoid confusion in multiple fileds for landmark
                        txtLandmark.Text = oledbReadRV["Landmark"].ToString();
                        txtTelNo.Text = oledbReadRV["TEL_NO_TYPE_PHONE"].ToString();
                        txtMobileNoOrTypeOfPhone.Text = oledbReadRV["Mobile_No_type_phone"].ToString();
                        txtLoanAmount.Text = oledbReadRV["Loan_Amount"].ToString();
                        txtUseOfLoan.Text = oledbReadRV["Use_of_loan"].ToString();
                        txtProduct.Text = oledbReadRV["Product"].ToString();
                        txtLocationOfProduct.Text = oledbReadRV["Location_Product"].ToString();
                        txtDateOfBirth.Text = oledbReadRV["DOB"].ToString();
                        ddlMaritalStatus.SelectedValue = oledbReadRV["MARITAL_STATUS"].ToString();
                        //ddlEducationBackgroud.SelectedValue = oledbReadRV["EDUCATION_BACKGROUND"].ToString();
                        string sDed = oledbReadRV["EDUCATION_BACKGROUND"].ToString();
                        if (sDed.Trim() != "")
                        {
                            string[] arrssDed = sDed.Split(':');
                            if (arrssDed.Length > 0)
                            {
                                if (arrssDed[0].ToString() == "Other" && arrssDed.Length > 1)
                                {
                                    ddlEducationBackgroud.SelectedValue = "Other";
                                    txtEducationBackgroud.Text = arrssDed[1].ToString();
                                }
                                else
                                {
                                    ddlEducationBackgroud.SelectedValue = arrssDed[0].ToString();
                                }
                            }
                        }
                        txtFamilyDetails.Text = oledbReadRV["FAMILY_DETAILS"].ToString();
                        txtDetailsOfWorkingMembersSpouse.Text = oledbReadRV["SPOUSE_DETAILS"].ToString();
                        txtTotalFamilyIncome.Text = oledbReadRV["FAMILY_INCOME"].ToString();
                        txtDetailsOfWorkingMembersOthers.Text = oledbReadRV["OTHER_DETAILS"].ToString();
                        ddlLoanCancellation.SelectedValue = oledbReadRV["Loan_Cancellation"].ToString();
                        txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text = oledbReadRV["CREDIT_CARD_LIMIT"].ToString();
                        txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text = oledbReadRV["OTHER_LOAN_DATAIL"].ToString();
                        /////////////add for new changes 13/02/2010///////////////////////////////////
                        txtChildren.Text = oledbReadRV["Children"].ToString();
                        txtDesigation.Text = oledbReadRV["Emp_Designation"].ToString();
                        ddlCarPark.SelectedValue = oledbReadRV["Car_Park"].ToString();
                        ddlResiExti.SelectedValue = oledbReadRV["Resi_Exti"].ToString();
                        ddlResiIntl.SelectedValue = oledbReadRV["Resi_Intl"].ToString();
                        ddlConsHouse.SelectedValue = oledbReadRV["Cons_House"].ToString();
                        ddlExteriorPremises.SelectedValue = oledbReadRV["Resi_Ext"].ToString();

                        txtOthFeed.Text = oledbReadRV["other_feedback"].ToString();
                        ddlCustPrev.SelectedValue = oledbReadRV["CustApp_Prev"].ToString();
                        txtDatePrev.Text = oledbReadRV["Date_Prev"].ToString();
                        ddlTranType.Text = oledbReadRV["Tran_Date"].ToString();
                        ddlPropBought.SelectedValue = oledbReadRV["Prop_Brought"].ToString();
                        ddlRelantionProp.SelectedValue = oledbReadRV["Relantion_prop"].ToString();
                        txtOtherProp.Text = oledbReadRV["Other_Prop"].ToString();
                        ddlOffDeci.SelectedValue = oledbReadRV["Off_Deci"].ToString();
                        
                        ///////////////////end code/////////////////////////////////////////////////
                        string sTmp = oledbReadRV["YEARS_AT_RESIDENCE"].ToString();
                        if (sTmp.Trim() != "")
                        {
                            string[] arrNoOfCurrResi = sTmp.Split('.');
                            txtNoOfYrsAtCurrResi.Text = arrNoOfCurrResi[0].ToString();
                            if (arrNoOfCurrResi.Length > 1)
                                txtNoOfMthsAtCurrResi.Text = arrNoOfCurrResi[1].ToString();
                        }
                        txtAreaOfHouse.Text = oledbReadRV["Area_of_House"].ToString();
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
                        ddlOwnershipOfResidence.SelectedValue = oledbReadRV["Ownership_RESIDENCE"].ToString();
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
                        //objRV.Type = oledbReadRV["Type"].ToString();
                        //if (objRV.Type != "Ownership" && objRV.Type != "Parental" && objRV.Type != "Self Owned" &&
                        //    objRV.Type != "Relative Owned" && objRV.Type != "Friend Owned" && objRV.Type != "Bachelor Accomodation" &&
                        //    objRV.Type != "Rented" && objRV.Type != "Company Accomodation" && objRV.Type != "PG" && objRV.Type != "Govt,Quaters" && objRV.Type != "Pagadi" && objRV.Type != "")
                        //{
                        //    ddlType.SelectedValue = "Other";
                        //    txtOtherType.Text = objRV.Type;
                        //}
                        //else
                        //    ddlType.SelectedValue = objRV.Type;


                        string sType = oledbReadRV["Type"].ToString();
                        if (sType.Trim() != "")
                        {
                            string[] arrsType = sType.Split(':');
                            if (arrsType.Length > 0)
                            {
                                if (arrsType[0].ToString() == "Other" && arrsType.Length > 1)
                                {
                                    ddlType.SelectedValue = "Other";
                                    txtOtherType.Text = arrsType[1].ToString();
                                }
                                else
                                {
                                    ddlType.SelectedValue = arrsType[0].ToString();
                                }
                            }
                        }

                        txtNameontheSocietyAddressboard.Text = oledbReadRV["Name_Society_Board"].ToString();
                        ddlNamePlateonDoor.SelectedValue = oledbReadRV["Nameplate_on_door"].ToString();
                        //Added by Manoj Jadhav
                        string sNamePlateonDoor = oledbReadRV["Nameplate_on_door"].ToString();
                        if (sType.Trim() != "")
                        {
                            string[] arrsNamePlateonDoor = sNamePlateonDoor.Split(':');
                            if (arrsNamePlateonDoor.Length > 0)
                            {
                                if (arrsNamePlateonDoor[0].ToString() == "Yes" && arrsNamePlateonDoor.Length > 1)
                                {
                                    ddlNamePlateonDoor.SelectedValue = "Yes";
                                    txtNameOnNamePlate.Text = arrsNamePlateonDoor[1].ToString();
                                }
                                else
                                {
                                    ddlNamePlateonDoor.SelectedValue = arrsNamePlateonDoor[0].ToString();
                                }
                            }
                        }

                        //Ended by Manoj
                        if (txtOwnershipDetails.Text == "")
                        {
                            //ddlOwnershipDetails.SelectedValue = oledbReadRV["Ownership_Details"].ToString();
                        }
                        else
                        {
                            txtOwnershipDetails.Text = oledbReadRV["Ownership_Details"].ToString();
                        }                        
                        txtPermanentAddress.Text = oledbReadRV["Permanent_address"].ToString();
                        txtNumberofRooms.Text = oledbReadRV["Number_rooms"].ToString();
                        txtApproximateValue.Text = oledbReadRV["Approximate_Value"].ToString();
                        txtBachelorAccomodation.Text = oledbReadRV["Bachelor_Accomodation"].ToString();
                        //objRV.Locality = oledbReadRV["Locality"].ToString();
                        //if (objRV.Locality != "Posh" && objRV.Locality != "Upper Middle Class" && objRV.Locality != "Lower Middle Class" &&
                        //    objRV.Locality != "Middle Class" && objRV.Locality != "Poor" && objRV.Locality != "Slum" &&
                        //    objRV.Locality != "Residential" && objRV.Locality != "Commercial" && objRV.Locality != "Village area" &&
                        //    objRV.Locality != "Negative Area" && objRV.Locality != "Hilly Tekdi" && objRV.Locality != "Communited Dominated" &&
                        //    objRV.Locality != "Under Developed" && objRV.Locality != "Small/Medium sized shops" && objRV.Locality != "Big Housing Complex" && objRV.Locality != "")
                        //{
                        //    ddlLocality.SelectedValue = "Other";
                        //    txtOtherLocality.Text = objRV.Locality;
                        //}
                        //else
                        //    ddlLocality.SelectedValue = objRV.Locality;

                        objRV.Locality = oledbReadRV["Locality"].ToString();
                        string sDed1 = oledbReadRV["Locality"].ToString();
                        if (sDed.Trim() != "")
                        {
                            string[] arrssDed = sDed1.Split(':');
                            if (arrssDed.Length > 0)
                            {
                                if (arrssDed[0].ToString() == "Other" && arrssDed.Length > 1)
                                {
                                    ddlLocality.SelectedValue = "Other";
                                    txtOtherLocality.Text = arrssDed[1].ToString();
                                }
                                else
                                {
                                    ddlLocality.SelectedValue = arrssDed[0].ToString();
                                }
                            }
                        }

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
                        ddlPurposeOfLoanTaken.SelectedValue = oledbReadRV["Purpose_loan"].ToString();
                        txtOtherSourceOfIncome.Text = oledbReadRV["other_source_income"].ToString();
                        ddlOtherInvestment.SelectedValue = oledbReadRV["Other_Investment"].ToString();
                        txtColourOfDoor.Text = oledbReadRV["Colour_of_Door"].ToString();
                        ddlRoomType.SelectedValue = oledbReadRV["Room_Type"].ToString();

                        //objRV.TypeOfHouse = oledbReadRV["Type_of_House"].ToString();
                        //if (objRV.TypeOfHouse != "Bungalow" && objRV.TypeOfHouse != "Flat" && objRV.TypeOfHouse != "Individual House" &&
                        //    objRV.TypeOfHouse != "Standing Chawl/Janata Flat" && objRV.TypeOfHouse != "Sitting Chawl/Hutment" && objRV.TypeOfHouse != "Slum" &&
                        //    objRV.TypeOfHouse != "Staff Quarters" && objRV.TypeOfHouse != "Lodge/Hotel" && objRV.TypeOfHouse != "Annexe To House" &&
                        //    objRV.TypeOfHouse != "Multi-Tenant House" && objRV.TypeOfHouse != "Small Independent House" && objRV.TypeOfHouse != "Chawl" && objRV.TypeOfHouse != "")
                        //{
                        //    ddlTypeOfHouse.SelectedValue = "Other";
                        //    txtOtherTypeOfHouse.Text = objRV.TypeOfHouse;
                        //}
                        //else
                        //    ddlTypeOfHouse.SelectedValue = objRV.TypeOfHouse;
                        string sTypeOfHouse = oledbReadRV["Type_of_House"].ToString();
                        if (sTypeOfHouse.Trim() != "")
                        {
                            string[] arrsTypeOfHouse = sTypeOfHouse.Split(':');
                            if (arrsTypeOfHouse.Length > 0)
                            {
                                if (arrsTypeOfHouse[0].ToString() == "Other" && arrsTypeOfHouse.Length > 1)
                                {
                                    ddlTypeOfHouse.SelectedValue = "Other";
                                    txtOtherTypeOfHouse.Text = arrsTypeOfHouse[1].ToString();
                                }
                                else
                                {
                                    ddlTypeOfHouse.SelectedValue = arrsTypeOfHouse[0].ToString();
                                }
                            }
                        }

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
                        //ddlAddressProofSighted.SelectedValue = oledbReadRV["Address_Proof_Sighted"].ToString();
                        //update by Manoj
                        string sAdd = oledbReadRV["Address_Proof_Sighted"].ToString();
                        if (sAdd.Trim() != "")
                        {
                            string[] arrsAdds = sAdd.Split(':');
                            if (arrsAdds.Length > 0)
                            {
                                if (arrsAdds[0].ToString() == "Yes" && arrsAdds.Length > 1)
                                {
                                    ddlAddressProofSighted.SelectedValue = "Yes";
                                    txtResDetails.Text = arrsAdds[1].ToString();
                                }
                                else
                                {
                                    ddlAddressProofSighted.SelectedValue = arrsAdds[0].ToString();
                                }
                            }
                        }
                        //End by Manoj
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
                        txtBackNum.Text = oledbReadRV["PP_Number"].ToString();
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
                        //added by kamal matekar ...for Barclays finance PL.
                        txtPlaceOfBirth.Text = oledbReadRV["Place_Of_Birth"].ToString();
                        txtstate.Text = oledbReadRV["State"].ToString();
                        ddlNameVerifiedForm.SelectedValue = oledbReadRV["Name_Verified_From"].ToString();
                        ddlApplicantCategory.SelectedValue = oledbReadRV["Applicant_Category"].ToString();
                        txtIfSalariedDesignation.Text = oledbReadRV["If_Salaried_Designation"].ToString();
                        txtIfSelfEmployed.Text = oledbReadRV["If_SelfEmployee_Profession"].ToString();
                        txtOfficeTelNumber.Text = oledbReadRV["Off_Tel_No"].ToString();
                        txtNoOfEmployeesSeen.Text = oledbReadRV["No_Emp_Seen"].ToString();
                        //added by kamal matekar for Federal Finance---
                        txtResiAddCoApp.Text = oledbReadRV["ResiAdd_CoApp"].ToString();
                        txtLandMarkCoApp.Text = oledbReadRV["LandMark_CoApp"].ToString();
                        txtTelNoCoApp.Text = oledbReadRV["TelNo_CoApp"].ToString();
                        txtPerCotCoApp.Text = oledbReadRV["PersonContacted_CoApp"].ToString();
                        txtRelationshipCoApp.Text = oledbReadRV["Relationship_CoApp"].ToString();
                        txtDateofVisitCoApp.Text = oledbReadRV["Datetime_Visit_CoApp"].ToString();
                        txtDLNo.Text = oledbReadRV["DLNo"].ToString();
                        txtEillBillResi.Text = oledbReadRV["EillBillResi"].ToString();
                        txtPerAccBankName.Text = oledbReadRV["PersonalAccount"].ToString();
                        txtBranch.Text = oledbReadRV["Branch"].ToString();
                        txtPanNo.Text = oledbReadRV["PanNo"].ToString();
                        txtTeleBill.Text = oledbReadRV["TeleBill"].ToString();
                        txtODLimit.Text = oledbReadRV["ODLimit"].ToString();
                        txtAcNo.Text = oledbReadRV["AccountNo"].ToString();
                        txtVoterId.Text = oledbReadRV["VoterId"].ToString();
                        txtRationCard.Text = oledbReadRV["RationCard"].ToString();
                        txtValueRentAmountFlat.Text = oledbReadRV["ValueOfFlats"].ToString();
                        txtLevelofMaintained.Text = oledbReadRV["LevelMaintained"].ToString();
                        txtPolitics.Text = oledbReadRV["PoliticsParty"].ToString();
                        txtAssessmentOff.Text = oledbReadRV["Assessment"].ToString();
                        txtRepoCallBy.Text = oledbReadRV["RepoCollBy"].ToString();
                        txtTVRDONEBY.Text = oledbReadRV["TVRDoneBy"].ToString();
                        txtQcDoneBy.Text = oledbReadRV["QCDoneBy"].ToString();
                        txtApprovingOfficer.Text = oledbReadRV["ApprovingOfficer"].ToString();
                        txtContentWriter.Text = oledbReadRV["ContentWriter"].ToString();
                        txtReportPreparedBy.Text = oledbReadRV["ReportPreparedBy"].ToString();
                        txtTVRDetails.Text = oledbReadRV["TVRDetails"].ToString();
                        txtRepoCallStatus.Text = oledbReadRV["TVR_Status"].ToString();
                        txtTVRStatus.Text = oledbReadRV["QC_Status"].ToString();
                        txtQcStatus.Text = oledbReadRV["RepoCollby_Status"].ToString();
                        txtMaritalStatusCoApp.Text = oledbReadRV["MaritalStatus_CoApp"].ToString();
                        txtDOBCoApp.Text = oledbReadRV["DOB_CoApp"].ToString();
                        txtQualificationCoApp.Text = oledbReadRV["Qualification_CoApp"].ToString();
                        txtNoOfDependentCoApp.Text = oledbReadRV["NoOfDependent_CoApp"].ToString();
                        txtFamilyStrCoApp.Text = oledbReadRV["FamilyStructure_CoApp"].ToString();

                        //added by kamal matekar for Karvy Financial ...
                        txtAddDiff.Text = oledbReadRV["Address_different"].ToString();
                        txtPrevAdd.Text = oledbReadRV["Lessthan1Year_PreAdd"].ToString();
                        txtRentPerMonth.Text = oledbReadRV["IfRented_PerMonth"].ToString();
                        txtFinanceBank.Text = oledbReadRV["IfFinanceNameOfBank"].ToString();
                        ddlAppNameVerifiedFrom.Text = oledbReadRV["Applicant_NameVerifiedFrom"].ToString();
                        txtYearOfConstruction.Text = oledbReadRV["YearOfConstruction"].ToString();
                        ddlProperty.SelectedValue = oledbReadRV["Property_IsRented"].ToString();
                        ddlAppOccupation.Text = oledbReadRV["AppOccupation"].ToString();
                        txtNatureofbusiness.Text = oledbReadRV["NatureOfbusiness"].ToString();
                        txtWorkingsince.Text = oledbReadRV["WorkingSince"].ToString();
                                               
                        //txtProofOfIdentityOther.Text =oledbReadRV["ProofOfIdentitySeen"].ToString();
                        //ddlAddressProofSeen.SelectedValue=oledbReadRV["AddressProofSeen"].ToString();
                        //txtAddressProofOther.Text = oledbReadRV["AddressProofSeen"].ToString();

                        string sProofOfIdentitySeen = oledbReadRV["ProofOfIdentitySeen"].ToString();
                        if (sProofOfIdentitySeen.Trim() != "")
                        {
                            string[] arrsProofOfIdentitySeen = sProofOfIdentitySeen.Split(':');
                            if (arrsProofOfIdentitySeen.Length > 0)
                            {
                                if (arrsProofOfIdentitySeen[0].ToString() == "Others" && arrsProofOfIdentitySeen.Length > 1)
                                {
                                    ddlProofOfIdentitySeen.SelectedValue = "Others";
                                    txtProofOfIdentityOther.Text = arrsProofOfIdentitySeen[1].ToString();
                                }
                                else
                                {
                                    ddlProofOfIdentitySeen.SelectedValue = arrsProofOfIdentitySeen[0].ToString();
                                }
                            }
                        }

                        string sAddressProofSeen = oledbReadRV["AddressProofSeen"].ToString();
                        if (sAddressProofSeen.Trim() != "")
                        {
                            string[] arrsAddressProofSeen = sAddressProofSeen.Split(':');
                            if (arrsAddressProofSeen.Length > 0)
                            {
                                if (arrsAddressProofSeen[0].ToString() == "Others" && arrsAddressProofSeen.Length > 1)
                                {
                                    ddlAddressProofSeen.SelectedValue = "Others";
                                    txtAddressProofOther.Text = arrsAddressProofSeen[1].ToString();
                                }
                                else
                                {
                                    ddlAddressProofSeen.SelectedValue = arrsAddressProofSeen[0].ToString();
                                }
                            }
                        }
                        
                        //--Ended by kamal matekar....                                                        
                                                                
                    }

                    if (oledbReadRV_New.Read() == true)
                    {
                        ddlcrossinformation.SelectedValue = oledbReadRV_New["Crossverifiedinformation"].ToString();
                        txtBusinessverification.Text = oledbReadRV_New["Businessverification"].ToString();
                        txtITR.Text = oledbReadRV_New["ITRVerification"].ToString();
                        txtVoterIDVer.Text = oledbReadRV_New["VoterIdverification"].ToString();
                        txtbanksatatment.Text = oledbReadRV_New["banksatatmentveri"].ToString();
                        txtelectricitybill.Text = oledbReadRV_New["electricitybillveri"].ToString();
                        string sTmpPickupdocument = oledbReadRV_New["Pickupdocument"].ToString();
                        string[] arrPickupdocument = sTmpPickupdocument.Split(',');
                        string[] arrsTmpPickupdocument1 = sTmpPickupdocument.Split(':');

                        if (arrPickupdocument.Length > 0)
                        {
                            for (int i = 0; i < arrPickupdocument.Length; i++)
                            {
                                foreach (ListItem li in chkPickupdocument.Items)
                                {
                                    if (li.Value == arrPickupdocument.GetValue(i).ToString())
                                        li.Selected = true;

                                }
                            }
                        }
                        for (int j = 0; j < arrsTmpPickupdocument1.Length; j++)
                        {
                            txtother.Text = arrsTmpPickupdocument1.GetValue(j) + "";
                        }
                        //////////New requirement for client add by santosh 11/10/2010////////////////
                        txtRelAppForGua.Text = oledbReadRV_New["Relationship"].ToString();
                        txtKnowApp.Text = oledbReadRV_New["Months_stay_residencE"].ToString();
                        txtLiabGua.Text = oledbReadRV_New["ROOF_TYPE"].ToString();
                        txtEmpDet.Text = oledbReadRV_New["Verifier_Comments"].ToString();
                        txtCoAppName.Text = oledbReadRV["coappname"].ToString();
                        txtLoanNo.Text = oledbReadRV_New["Address_Neighbour1"].ToString();
                        txtAmbResi.Text = oledbReadRV_New["Neighbour1_confirmation"].ToString();
                        txtCheckDet.Text = oledbReadRV_New["Month_at_office"].ToString();
                        ddlNeighCheck.SelectedValue = oledbReadRV_New["Market_Reputation_Neighbour1"].ToString();

                        string sTmpDocVeri = oledbReadRV_New["DocVeri"].ToString();
                        string[] arrDocVeri = sTmpDocVeri.Split(',');

                        if (arrDocVeri.Length > 0)
                        {
                            for (int i = 0; i < arrDocVeri.Length; i++)
                            {
                                foreach (ListItem li in chkDocVeri.Items)
                                {
                                    if (li.Value == arrDocVeri.GetValue(i).ToString())
                                        li.Selected = true;
                                }
                            }
                        }
                       //--Added by Kamal Matekar...for HDFC_HL_RL 

                        txtFamilyProperty.Text = oledbReadRV_New["Family_Property"].ToString();
                        txtSupervisorName.Text = oledbReadRV_New["Supervisor_Name"].ToString();
                        ddlSupervisorName.SelectedValue = oledbReadRV_New["Supervisor_sign"].ToString();
                        txtBankDetail.Text = oledbReadRV_New["Bank_Detail"].ToString();
                        txtCreditCardType.Text = oledbReadRV_New["Card_Type"].ToString();
                        txtCreditCardNo.Text = oledbReadRV_New["Card_No"].ToString();
                        txtAssetsPurchase.Text = oledbReadRV_New["AssetsPurchase"].ToString();
                        txtAssetsLocated.Text = oledbReadRV_New["AssetsLocated"].ToString();
                        ddlSpouseWork.SelectedValue = oledbReadRV_New["SpouseWork"].ToString();
                        txtSpouseDesg.Text = oledbReadRV_New["SpouseDesg"].ToString();
                        ddlFinanceVisible.SelectedValue = oledbReadRV_New["FinanceVisible"].ToString();
                        ddlMunicipalLimit.SelectedValue = oledbReadRV_New["MunicipalLimit"].ToString();
                        
                        ////----Fulloton Releted santosh -------//////
                        txtBranchName.Text = oledbReadRV_New["Branch_Name"].ToString();
                        txtBranchCode.Text = oledbReadRV_New["Branch_Code"].ToString();
                        txtMonthSalary.Text = oledbReadRV_New["SalaryDect"].ToString();
                        txtOtherIncome.Text = oledbReadRV_New["Other_sources_income"].ToString();
                        ddlSourceIncome.SelectedValue = oledbReadRV_New["SourceIncome"].ToString();
                        ddlVeriOther.SelectedValue = oledbReadRV_New["VeriOtherIncome"].ToString();
                        txtClubbedIncome.Text = oledbReadRV_New["Total_IncomeAmt"].ToString();
                        ddlSourceClubIncome.SelectedValue = oledbReadRV_New["SourceClubIncome"].ToString();
                        ddlVeriClub.SelectedValue = oledbReadRV_New["VeriClubIncome"].ToString();
                        txtVeriThrough.Text = oledbReadRV_New["VerifiedThrough"].ToString();                        
                        txtLoanType1.Text = oledbReadRV_New["LoanType"].ToString();
                        txtLoanFinancier1.Text = oledbReadRV_New["LoanFinancier"].ToString();
                        txtLoanAmt1.Text = oledbReadRV_New["LoanAmt"].ToString();
                        txtLoanTenure1.Text = oledbReadRV_New["LoanTenure"].ToString();
                        txtLoanEmi1.Text = oledbReadRV_New["LoanEmi"].ToString();
                        txtLoanPaid1.Text = oledbReadRV_New["LoanPaid"].ToString();
                        txtLoanType2.Text = oledbReadRV_New["LoanType2"].ToString();
                        txtLoanFinancier2.Text = oledbReadRV_New["LoanFinancier2"].ToString();
                        txtLoanAmt2.Text = oledbReadRV_New["LoanAmt2"].ToString();
                        txtLoanTenure2.Text = oledbReadRV_New["LoanTenure2"].ToString();
                        txtLoanEmi2.Text = oledbReadRV_New["LoanEmi2"].ToString();
                        txtLoanPaid2.Text = oledbReadRV_New["LoanPaid2"].ToString();
                        txtLoanType3.Text = oledbReadRV_New["LoanType3"].ToString();
                        txtLoanFinancier3.Text = oledbReadRV_New["LoanFinancier3"].ToString();
                        txtLoanAmt3.Text = oledbReadRV_New["LoanAmt3"].ToString();
                        txtLoanTenure3.Text = oledbReadRV_New["LoanTenure3"].ToString();
                        txtLoanEmi3.Text = oledbReadRV_New["LoanEmi3"].ToString();
                        txtLoanPaid3.Text = oledbReadRV_New["LoanPaid3"].ToString();


                        ddlPurpose.SelectedValue = oledbReadRV_New["Month_Stay_Resi_Neigh1"].ToString();
                        txtPurpose.Text = oledbReadRV_New["Office_self_owned1"].ToString();
                     

                
                        string sConf = oledbReadRV_New["ConfirmationRes"].ToString();
                        if (sConf.Trim() != "")
                        {
                            string[] arrsConf = sConf.Split(':');
                            if (arrsConf.Length > 0)
                            {
                                if (arrsConf[0].ToString() == "No" && arrsConf.Length > 1)
                                {
                                    ddlConfirmationResid.SelectedValue = "No";
                                    txtResRemarks.Text = arrsConf[1].ToString();
                                }
                                else
                                {
                                    ddlConfirmationResid.SelectedValue = arrsConf[0].ToString();
                                }
                            }
                        }
                        string sDed = oledbReadRV_New["DedupMatch"].ToString();
                        if (sDed.Trim() != "")
                        {
                            string[] arrssDed = sDed.Split(':');
                            if (arrssDed.Length > 0)
                            {
                                if (arrssDed[0].ToString() == "Yes" && arrssDed.Length > 1)
                                {
                                    ddlDedupMatch.SelectedValue = "Yes";
                                    txtDedupMatchRemaks.Text = arrssDed[1].ToString();
                                }
                                else
                                {
                                    ddlDedupMatch.SelectedValue = arrssDed[0].ToString();
                                }
                            }
                        }
                        txtEndUseOfTheFunds.Text = oledbReadRV_New["EndUseOfTheFunds"].ToString();
                        txtpeople.Text = oledbReadRV_New["NoOfPeople"].ToString();
                        txtRegiationNo.Text = oledbReadRV_New["RegistrationNo"].ToString();
                        ddlReputationofneighbourhood.SelectedValue = oledbReadRV_New["Reputationofneighbourhood"].ToString();
                        ddlResTelOwnership.SelectedValue = oledbReadRV_New["ResTelOwnership"].ToString();
                        txtIncomeDocsSub.Text = oledbReadRV_New["IncomeDocSub"].ToString();
                        txtNoOfPplSeenResidence.Text = oledbReadRV_New["NoOfpplseen"].ToString();
                        ddlTypeOfLoan.SelectedValue = oledbReadRV_New["typeofloan"].ToString();
                        txtRemarks.Text = oledbReadRV_New["remark"].ToString();
                 
                        //nikhil
                        //txtSplInstr.Text = oledbReadRV_New["Spl_Instr"].ToString;
                        ////added by nikhil:spl_Instr
                        ddlPincodeAddMatch.SelectedValue = oledbReadRV_New["PincodeAddMatch"].ToString();
                        ddlAddressSetup.SelectedValue = oledbReadRV_New["AddressSetup"].ToString();
                        ddlMetCust.SelectedValue = oledbReadRV_New["MetCust"].ToString();
                        ddlDesgnConf.SelectedValue = oledbReadRV_New["DesgnConf"].ToString();
                        ddlMetSecurityGuard.SelectedValue = oledbReadRV_New["MetSecurityGuard"].ToString();
                        ddlCommunityDominated.SelectedValue = oledbReadRV_New["CommunityDominated"].ToString();

                        //nikhil- Ing Vysysa start
                        ddlLocalityType.SelectedValue = oledbReadRV_New["LocalityType"].ToString();
                        ddlFamilyStructure.SelectedValue = oledbReadRV_New["FamilyStructure"].ToString();
                        txtExistingLoanDetails.Text = oledbReadRV_New["ExistingLoanDetails"].ToString();
                        txtExistingVehicleDetails.Text = oledbReadRV_New["ExistingVehicleDetails"].ToString();
                        txtVehicleRegNo.Text = oledbReadRV_New["VehicleRegNo"].ToString();
                        txtRouteMap.Text = oledbReadRV_New["RouteMap"].ToString();
                        //end Ing Vysysa


                        txtnameverifedfrom.Text = oledbReadRV_New["Nameverifiedfrom"].ToString();

                        string sTmpinteroir = oledbReadRV_New["interiorConditions"].ToString();
                        string[] arrinteroir = sTmpinteroir.Split(',');
                        string[] arrinteroir1 = sTmpinteroir.Split(':');
                        int iOtherAssetCtr = 0;
                        if (arrinteroir.Length > 0)
                        {
                            for (int i = 0; i < arrinteroir.Length; i++)
                            {
                                foreach (ListItem li in ChkInteriorConditions.Items)
                                {
                                    if (li.Value == arrinteroir.GetValue(i).ToString())
                                        li.Selected = true;

                                    if (arrinteroir.GetValue(i).ToString() == "Others")
                                    {
                                        ChkInteriorConditions.Items[7].Selected = true;
                                        iOtherAssetCtr = i;
                                    }
                                }
                            }
                        }
                        for (int j = 0; j < arrinteroir1.Length; j++)
                        {
                            txtInteriorConditions.Text = arrinteroir1.GetValue(j) + "";
                        }


                        string sTmpExteriors = oledbReadRV_New["Exteriors"].ToString();
                        string[] arrExteriors = sTmpExteriors.Split(',');
                        string[] arrExteriors1 = sTmpExteriors.Split(':');

                        if (arrExteriors.Length > 0)
                        {
                            for (int i = 0; i < arrExteriors.Length; i++)
                            {
                                foreach (ListItem li in ChkExteriors.Items)
                                {
                                    if (li.Value == arrExteriors.GetValue(i).ToString())
                                        li.Selected = true;

                                }
                            }
                        }
                        for (int j = 0; j < arrExteriors1.Length; j++)
                        {
                            txtExteriors.Text = arrExteriors1.GetValue(j) + "";
                        }
                    
                        txtCreditCardName.Text = oledbReadRV_New["IfYesCreditCardName"].ToString();
                        txtSplInstr.Text = oledbReadRV_New["Spl_Instr"].ToString();
                        txtNoOfstores.Text = oledbReadRV_New["NoOfstores"].ToString();
                        ddlresidenceappear.SelectedValue = oledbReadRV_New["Residenceappear"].ToString();
                        ddlDomestichelp.SelectedValue = oledbReadRV_New["Domestichelp"].ToString();
                        ddlwastheapplicantmetaresidence.SelectedValue = oledbReadRV_New["wastheapplicantmetaresidence"].ToString();

                        txtEaringmembers.Text = oledbReadRV_New["Earingmembers"].ToString();
                        txtRelationshipe.Text = oledbReadRV_New["Relationshipe"].ToString();
                        txtmonthlyearing.Text = oledbReadRV_New["monthlyearing"].ToString();
                        txtVerifierthrough.Text = oledbReadRV_New["Verifierthrough"].ToString();

                        ddlApplicantstaandinginLocality.SelectedValue = oledbReadRV_New["ApplicantstaandinginLocality"].ToString();
                        txtnamee.Text = oledbReadRV_New["namee"].ToString();
                        txtphonee.Text = oledbReadRV_New["phonee"].ToString();
                        txtelaborateonthestanding.Text = oledbReadRV_New["elaborateonthestanding"].ToString();
                    
                        txtyear.Text = oledbReadRV_New["yearOfneighbour"].ToString();
                        txtDependentAdults.Text = oledbReadRV_New["Dependent_Adults"].ToString();
                        txtNegativeFeedbackFromFamily.Text = oledbReadRV_New["NegativeFeedbackFromFamily"].ToString();
                        txtNegativeFeedbackFromNeighbour.Text = oledbReadRV_New["NegativeFeedbackFromNeighbour"].ToString();
                        ddlApplicantCapableOfMaintaining.SelectedValue = oledbReadRV_New["ApplicantCapableOfMaintaining"].ToString();

                        txtIfNegBankName.Text = oledbReadRV_New["IfNegBankName"].ToString();
                        txtNegProduct.Text = oledbReadRV_New["IfNegProduct"].ToString();
                        txtDefaultBucket.Text = oledbReadRV_New["DefaultBucket"].ToString();
                        txtDefaultAmount.Text = oledbReadRV_New["DefaultAmt"].ToString();
                        txtbuildingtype.Text = oledbReadRV_New["buildingtype"].ToString();

                        ddlIfCCYes.SelectedValue = oledbReadRV_New["IfCCYes"].ToString();
                        ddlCreditCardOwnershipSCB.SelectedValue = oledbReadRV_New["CreditCardOwnershipSCB"].ToString();
                        txtPermAddTelNo.Text = oledbReadRV_New["PermAddTelNo"].ToString();
                        ddlFlooringType.SelectedValue = oledbReadRV_New["FlooringType"].ToString();
                        ddlEarlierVisited.SelectedValue = oledbReadRV_New["EarlierVisited"].ToString();
                        txtNearnessToNegArea.Text = oledbReadRV_New["NearnessToNegArea"].ToString();
                        txtVehicleTypeAndDetails.Text = oledbReadRV_New["VehicleTypeAndDetails"].ToString();


                        //New added/Updated for CHOLA
                        txtIssueBank.Text = oledbReadRV_New["IssuingBank"].ToString();
                        txtExpiryBank.Text = oledbReadRV_New["ExpiryBank"].ToString();
                        ddlAssetUser.SelectedValue = oledbReadRV_New["AssetUser"].ToString();
                        ddlAssetLocation.SelectedValue = oledbReadRV_New["AssetLocation"].ToString();
                        txtPlaceRegis.Text = oledbReadRV_New["Regis_Place"].ToString();
                        txtPropertyAddress.Text = oledbReadRV_New["PropertyAddress"].ToString();
                        ddlPropertyIdentify.SelectedValue = oledbReadRV_New["PropertyIdentify"].ToString();
                        ddlPropertyType.SelectedValue = oledbReadRV_New["PropertyType"].ToString();
                        ddlBuildingQuality.SelectedValue = oledbReadRV_New["BuildingQuality"].ToString();
                        txtPropertyArea.Text = oledbReadRV_New["PropertyArea"].ToString();
                        ddlBankMortgage.SelectedValue = oledbReadRV_New["BankMortgage"].ToString();
                        txtBankMortgage.Text = oledbReadRV_New["Name_BankMortgage"].ToString();
                        txtDist_Railway.Text = oledbReadRV_New["Dist_Railway"].ToString();
                        txtDist_Highway.Text = oledbReadRV_New["Dist_Highway"].ToString();
                        txtDist_Bus.Text = oledbReadRV_New["Dist_Bus"].ToString();
                        txtDist_TarRoad.Text = oledbReadRV_New["Dist_TarRoad"].ToString();
                        ddlAssociateProperty.SelectedValue = oledbReadRV_New["AssociateProperty"].ToString();
                        txtPropertyAge.Text = oledbReadRV_New["PropertyAge"].ToString();
                        txtPropertyDisputes.Text = oledbReadRV_New["PropertyDisputes"].ToString();
                        ddlPropertyDemand.SelectedValue = oledbReadRV_New["PropertyDemand"].ToString();
                        ddlRating.SelectedValue = oledbReadRV_New["Rating"].ToString();
                        //END for CHOLA
                    }

                    ///////////////End Code///////////////////////////////////////////

                    oledbCaseDtl.Close();
                    oledbReadRV.Close();
                    oledbReadRV_New.Close();
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
        cmd.CommandText = "Get_Areaname";

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
            ddlAreaname.SelectedIndex = 0;
        }
        else
        {
            ddlAreaname.DataTextField = "pincodeArea_Name";
            ddlAreaname.DataValueField = "PincodeArea_ID";

            ddlAreaname.DataSource = dt;
            ddlAreaname.DataBind();
            ddlAreaname.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAreaname.SelectedIndex = 0;
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
        int iCount = 0;
        string sMsg = "";
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
                if (ddlEducationBackgroud.SelectedItem.Text.Trim() == "Other")
                    objRV.EducationalBackground = "Other" + ":" + txtEducationBackgroud.Text.Trim();
                else
                    objRV.EducationalBackground = ddlEducationBackgroud.SelectedItem.Text.Trim();

                objRV.FamilyDetails = txtFamilyDetails.Text.Trim();
                objRV.DetailsOfWorkingMemberSpouse = txtDetailsOfWorkingMembersSpouse.Text.Trim();
                objRV.TotalFamIncome = txtTotalFamilyIncome.Text.Trim();
                objRV.DetailsOfWorkingMembersOthers = txtDetailsOfWorkingMembersOthers.Text.Trim();
                objRV.LoanCancellation = ddlLoanCancellation.SelectedValue.ToString();
                objRV.AnyCreditCard = txtAnyCreditCardsIfYesProvidNameandLimitonEach.Text.Trim();//-----
                objRV.AnyOtherLoan = txtAnyOtherLoansIfYesProvideDetailsOfAmountCompanyandEMI.Text.Trim(); //-----
                if (txtNoOfYrsAtCurrResi.Text == "" && txtNoOfMthsAtCurrResi.Text == "")
                {
                    txtNoOfYrsAtCurrResi.Text = Convert.ToString(0);
                    txtNoOfMthsAtCurrResi.Text = Convert.ToString(0);
                    objRV.NoOfYrsAtResidence = txtNoOfYrsAtCurrResi.Text + "." + txtNoOfMthsAtCurrResi.Text;
                }
                objRV.NoOfYrsAtResidence = txtNoOfYrsAtCurrResi.Text.Trim() + "." + txtNoOfMthsAtCurrResi.Text.Trim();
                objRV.AreaOfHouse = txtAreaOfHouse.Text.Trim();
                objRV.CityLimit = ddlCityLimit1.SelectedValue.ToString();
                /////////////add for client rquirement 13/02/2010//////////////////////////////
                objRV.Children = txtChildren.Text.Trim();
                objRV.EmpDesignation = txtDesigation.Text.Trim();
                objRV.CarPark = ddlCarPark.SelectedValue.ToString();
                objRV.ResiExti = ddlResiExti.SelectedValue.ToString();
                objRV.ResiIntl = ddlResiIntl.SelectedValue.ToString();
                objRV.ConsHouse = ddlConsHouse.SelectedValue.ToString();
                objRV.ResiExt = ddlExteriorPremises.SelectedValue.ToString();

                objRV.OthFeed = txtOthFeed.Text.Trim();
                objRV.CustPrev = ddlCustPrev.SelectedValue.ToString();
                objRV.DatePrev = txtDatePrev.Text.Trim();
                objRV.TranType = ddlTranType.SelectedValue.ToString();
                objRV.PropBought = ddlPropBought.SelectedValue.ToString();
                objRV.RelantionProp = ddlRelantionProp.SelectedValue.ToString();
                objRV.OtherProp = txtOtherProp.Text.Trim();
                objRV.OffDeci = ddlOffDeci.SelectedValue.ToString();

                ////////////////////////end code//////////////////////////////////////////////
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
                ///////////////////////Visible Item////////////////////////////////////////////////////////
                string VisibleItem = "";
                if (chkvisibleItems.Items.Count > 0)
                {
                    foreach (ListItem li in chkvisibleItems.Items)
                    {
                        //if (li.Text.Trim() == "Others" && li.Selected == true)
                        //    sAssets += li.Value + "," + txtOtherAssets.Text.Trim();
                        //else
                        if (li.Selected == true)
                            VisibleItem += li.Value + ",";
                    }
                }

                ///////////////////////Document Verified////////////////////////////////////////////////////////
                string DocVeri = "";
                if (chkDocVeri.Items.Count > 0)
                {
                    foreach (ListItem li in chkDocVeri.Items)
                    {
                        if (li.Selected == true)
                            DocVeri += li.Value + ",";
                    }
                }

                objRV.Assets = sAssets.TrimEnd(',');
                objRV.VisibleItems = VisibleItem.TrimEnd(',');
                objRV.DocVeri = DocVeri.TrimEnd(',');
                objRV.DetailsOfFurnitureSeen = txtDetailsoffurnitureSeen.Text.Trim();

                if (txtOwnershipOfResidence.Text == "")
                {
                    objRV.OwnershipOfResidence = ddlOwnershipOfResidence.SelectedValue.ToString();
                }
                else
                {
                    objRV.OwnershipOfResidence = txtOwnershipOfResidence.Text.Trim();
                }                
                objRV.StayingWithWhom = ddlApplicantLivesWith.SelectedValue.ToString();
                objRV.DSA = txtDSA.Text.Trim();
                objRV.Tenure = txtTenure.Text.Trim();
                objRV.Months = txtMonths.Text.Trim();

                //if (ddlType.SelectedValue.ToString() != "Other")
                //    objRV.Type = ddlType.SelectedValue.ToString();
                //else
                //    objRV.Type = txtOtherType.Text.Trim();

                if (ddlType.SelectedItem.Text.Trim() == "Other")
                    objRV.Type = "Other" + ":" + txtOtherType.Text.Trim();
                else
                    objRV.Type = ddlType.SelectedItem.Text.Trim();

                objRV.NameOnSocietyAddressBoard = txtNameontheSocietyAddressboard.Text.Trim();
                //objRV.NameplateOnDoor = ddlNamePlateonDoor.SelectedValue.ToString();
                if (ddlNamePlateonDoor.SelectedItem.Text.Trim() == "Yes")
                {
                    objRV.NameplateOnDoor = "Yes" + ":" + txtNameOnNamePlate.Text.Trim();
                }
                else
                {
                    objRV.NameplateOnDoor = ddlNamePlateonDoor.SelectedValue.ToString();
                }
                objRV.OwnershipDetail = txtOwnershipDetails.Text.Trim();
                //objRV.OwnershipDetail = ddlOwnershipDetails.SelectedValue.ToString();
                objRV.PermanentAddress = txtPermanentAddress.Text.Trim();
                objRV.NoOfRooms = txtNumberofRooms.Text.Trim();
                objRV.ApproximateValue = txtApproximateValue.Text.Trim();
                objRV.BachelorAccomodation = txtBachelorAccomodation.Text.Trim();
                //if (ddlLocality.SelectedValue.ToString() != "Other")
                //    objRV.Locality = ddlLocality.SelectedValue.ToString();
                //else
                //    objRV.Locality = txtOtherLocality.Text.Trim();
                objRV.Locality = ddlLocality.SelectedValue.ToString();
                if (ddlLocality.SelectedItem.Text.Trim() == "Other")
                    objRV.Locality = "Other" + ":" + txtOtherLocality.Text.Trim();
                else
                    objRV.Locality = ddlLocality.SelectedItem.Text.Trim();

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
                objRV.PurposeOfLoanTaken = ddlPurposeOfLoanTaken.Text.Trim();
                objRV.OtherSourceOfIncome = txtOtherSourceOfIncome.Text.Trim();
                objRV.OtherInvestment = ddlOtherInvestment.SelectedValue.ToString();
                objRV.ClourOnDoor = txtColourOfDoor.Text.Trim();
                objRV.RoomType = ddlRoomType.SelectedValue.ToString();
                if (ddlTypeOfHouse.SelectedValue.ToString() != "Other")
                    objRV.TypeOfHouse = ddlTypeOfHouse.SelectedValue.ToString();
                else
                    objRV.TypeOfHouse = "Other" + ":" + txtOtherTypeOfHouse.Text.Trim();
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
                //objRV.AddressProofSighted = ddlAddressProofSighted.SelectedValue.ToString();
                //Update by MAnoj
                if (ddlAddressProofSighted.SelectedItem.Text.Trim() == "Yes")
                {
                    objRV.AddressProofSighted = "Yes" + ":" + txtResDetails.Text.Trim();
                }
                else
                {
                    objRV.AddressProofSighted = ddlAddressProofSighted.SelectedItem.Text.Trim();
                }
                //End the update
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
                //--added by kamal matekar on dated 24/07/2010
                objRV.Place_Of_Birth = txtPlaceOfBirth.Text.ToString();
                objRV.State = txtstate.Text.ToString();
                objRV.Name_Verified_From = ddlNameVerifiedForm.SelectedValue.ToString();
                objRV.Applicant_Category = ddlApplicantCategory.SelectedValue.ToString();
                objRV.If_Salaried_Designation = txtIfSalariedDesignation.Text.ToString();
                objRV.If_SelfEmployee_Profession = txtIfSelfEmployed.Text.ToString();
                objRV.Off_Tel_No = txtOfficeTelNumber.Text.ToString();
                objRV.No_Emp_Seen = txtNoOfEmployeesSeen.Text.ToString();
                //---End
                //----added by kamal matekar for Federal Finance On dated 28 July 2010...
                objRV.ResiAdd_CoApp = txtResiAddCoApp.Text.ToString();
                objRV.LandMark_CoApp = txtLandMarkCoApp.Text.ToString();
                objRV.TelNo_CoApp = txtTelNoCoApp.Text.ToString();
                objRV.PersonContacted_CoApp = txtPerCotCoApp.Text.ToString();
                objRV.Relationship_CoApp = txtRelationshipCoApp.Text.ToString();
                objRV.Datetime_Visit_CoApp = txtDateofVisitCoApp.Text.ToString();
                objRV.DLNo = txtDLNo.Text.ToString();
                objRV.EillBillResi = txtEillBillResi.Text.ToString();
                objRV.PersonalAccount = txtPerCotCoApp.Text.ToString();
                objRV.Branch = txtBranch.Text.ToString();
                objRV.PanNo = txtPanNo.Text.ToString();
                objRV.TeleBill = txtTeleBill.Text.ToString();
                objRV.ODLimit = txtODLimit.Text.ToString();
                objRV.AccountNo = txtAcNo.Text.ToString();
                objRV.VoterId = txtVoterId.Text.ToString();
                objRV.RationCard = txtRationCard.Text.ToString();
                objRV.ValueOfFlats = txtValueRentAmountFlat.Text.ToString();
                objRV.LevelMaintained = txtLevelofMaintained.Text.ToString();
                objRV.PoliticsParty = txtPolitics.Text.ToString();
                objRV.Assessment = txtAssessmentOff.Text.ToString();
                objRV.RepoCollBy = txtRepoCallBy.Text.ToString();
                objRV.RepoCollby_Status = txtRepoCallStatus.Text.ToString();
                objRV.ReportPreparedBy = txtReportPreparedBy.Text.ToString();
                objRV.TVRDoneBy = txtTVRDONEBY.Text.ToString();
                objRV.QCDoneBy = txtQcDoneBy.Text.ToString();
                objRV.ApprovingOfficer = txtApprovingOfficer.Text.ToString();
                objRV.ContentWriter = txtContentWriter.Text.ToString();
                objRV.TVRDetails = txtTVRDetails.Text.ToString();
                objRV.TVR_Status = txtTVRStatus.Text.ToString();
                objRV.QC_Status = txtQcStatus.Text.ToString();
                objRV.MaritalStatus_CoApp = txtMaritalStatusCoApp.Text.ToString();
                objRV.DOB_CoApp = txtDOBCoApp.Text.ToString();
                objRV.Qualification_CoApp = txtQualificationCoApp.Text.ToString();
                objRV.NoOfDependent_CoApp = txtNoOfDependentCoApp.Text.ToString();
                objRV.FamilyStructure_CoApp = txtFamilyStrCoApp.Text.ToString();
                objRV.BackNum = txtBackNum.Text.ToString();

                //---Added by kamal matekar for karvy financial on dated 19th Nov 2010
                objRV.Address_different = txtAddDiff.Text.ToString();
                objRV.Lessthan1Year_PreAdd = txtPrevAdd.Text.ToString();
                objRV.IfRented_PerMonth = txtRentPerMonth.Text.ToString();
                objRV.IfFinanceNameOfBank = txtFinanceBank.Text.ToString();
                objRV.Applicant_NameVerifiedFrom = ddlAppNameVerifiedFrom.SelectedValue.ToString();
                objRV.YearOfConstruction = txtYearOfConstruction.Text.ToString();
                objRV.Property_IsRented = ddlProperty.SelectedValue.ToString();
                objRV.AppOccupation = ddlAppOccupation.SelectedValue.ToString();
                objRV.NatureOfbusiness = txtNatureofbusiness.Text.ToString();
                objRV.WorkingSince = txtWorkingsince.Text.ToString();
                objRV.PagerNo = txtPagerNo.Text.ToString();
                objRV.NoOfWindow = txtNoOfWindow.Text.ToString();

                //---added by kamal matekar for HDFC_HL_RL

                objRV.FamilyProp = txtFamilyProperty.Text.ToString();
                objRV.SupName = txtSupervisorName.Text.ToString();
                objRV.Supervisor_sign = ddlSupervisorName.SelectedValue.Trim();
                objRV.BankDetail = txtBankDetail.Text.ToString();
                objRV.CardType = txtCreditCardType.Text.ToString();

                //---Ended for the same...
                if (ddlProofOfIdentitySeen.SelectedItem.Text.Trim() == "Others")
                    objRV.ProofOfIdentitySeen = "Others" + ":" + txtProofOfIdentityOther.Text.Trim();
                else
                    objRV.ProofOfIdentitySeen = ddlProofOfIdentitySeen.SelectedItem.Text.Trim();

                if (ddlAddressProofSeen.SelectedItem.Text.Trim() == "Others")
                    objRV.AddressProofSeen = "Others" + ":" + txtAddressProofOther.Text.Trim();
                else
                    objRV.AddressProofSeen = ddlAddressProofSeen.SelectedItem.Text.Trim();


                //////////////////add new 11/10/2010////////////////////////////////////////////////
                objRV.RelAppForGua = txtRelAppForGua.Text.ToString();
                objRV.KnowApp = txtKnowApp.Text.ToString();
                objRV.LiabGua = txtLiabGua.Text.ToString();
                objRV.EmpDet = txtEmpDet.Text.ToString();
                objRV.CoAppName = txtCoAppName.Text.ToString();
                objRV.LoanNo = txtLoanNo.Text.ToString();
                objRV.AmbResi = txtAmbResi.Text.ToString();
                objRV.CheckDet = txtCheckDet.Text.ToString();
                objRV.NeCheck = ddlNeighCheck.SelectedValue.ToString();
                objRV.CardNo = txtCreditCardNo.Text.ToString();
                objRV.AssetsPurchase = txtAssetsPurchase.Text.ToString();
                objRV.AssetsLocated = txtAssetsLocated.Text.ToString();
                objRV.SpouseWork = ddlSpouseWork.SelectedValue.ToString();
                objRV.SpouseDesg = txtSpouseDesg.Text.ToString();
                objRV.FinanceVisible = ddlFinanceVisible.SelectedValue.ToString();
                objRV.MunicipalLimit = ddlMunicipalLimit.SelectedValue.ToString();

                objRV.BranchName = txtBranchName.Text.ToString();
                objRV.BranchCode = txtBranchCode.Text.ToString();
                objRV.MonthSalary = txtMonthSalary.Text.ToString();
                objRV.OtherIncome = txtOtherIncome.Text.ToString();
                objRV.SourceOthIncome = ddlSourceIncome.SelectedValue.ToString();
                objRV.VeriOtherIncome = ddlVeriOther.SelectedValue.ToString();
                objRV.ClubbedIncome = txtClubbedIncome.Text.ToString();
                objRV.SourceClubIncome = ddlSourceClubIncome.SelectedValue.ToString();
                objRV.VeriClub = ddlVeriClub.SelectedValue.ToString();
                objRV.VeriThrough = txtVeriThrough.Text.ToString();
                objRV.LoanType1 = txtLoanType1.Text.ToString();
                objRV.LoanFinancier = txtLoanFinancier1.Text.ToString();
                objRV.LoanAmt = txtLoanAmt1.Text.ToString();
                objRV.LoanTenure = txtLoanTenure1.Text.ToString();
                objRV.LoanEmi = txtLoanEmi1.Text.ToString();
                objRV.LoanPaid = txtLoanPaid1.Text.ToString();
                objRV.LoanType2 = txtLoanType2.Text.ToString();
                objRV.LoanFinancier2 = txtLoanFinancier2.Text.ToString();
                objRV.LoanAmt2 = txtLoanAmt2.Text.ToString();
                objRV.LoanTenure2 = txtLoanTenure2.Text.ToString();
                objRV.LoanEmi2 = txtLoanEmi2.Text.ToString();
                objRV.LoanPaid2 = txtLoanPaid2.Text.ToString();
                objRV.LoanType3 = txtLoanType3.Text.ToString();
                objRV.LoanFinancier3 = txtLoanFinancier3.Text.ToString();
                objRV.LoanAmt3 = txtLoanAmt3.Text.ToString();
                objRV.LoanTenure3 = txtLoanTenure3.Text.ToString();
                objRV.LoanEmi3 = txtLoanEmi3.Text.ToString();
                objRV.LoanPaid3 = txtLoanPaid3.Text.ToString();

                objRV.Purpose = ddlPurpose.SelectedValue.ToString();
                objRV.OthPurpose = txtPurpose.Text.ToString();
             
        
                if (ddlConfirmationResid.SelectedItem.Text.Trim() == "No")
                {
                    objRV.ConfirmationRes = "No" + ":" + txtResRemarks.Text.Trim();
                }
                else
                {
                    objRV.ConfirmationRes = ddlConfirmationResid.SelectedItem.Text.Trim();
                }
                if (ddlDedupMatch.SelectedItem.Text.Trim() == "Yes")
                {
                    objRV.DedupMatch = "Yes" + ":" + txtDedupMatchRemaks.Text.Trim();
                }
                else
                {
                    objRV.DedupMatch = ddlDedupMatch.SelectedItem.Text.Trim();
                }

                objRV.EndUseOfTheFunds = txtEndUseOfTheFunds.Text.Trim();

                objRV.Reputationofneighbourhood = ddlReputationofneighbourhood.SelectedValue.ToString();
                objRV.NoOfPeople = txtpeople.Text.Trim();
                objRV.RegistrationNo = txtRegiationNo.Text.Trim();
                objRV.ResTelOwnership = ddlResTelOwnership.SelectedValue.ToString();
                objRV.IncomeDocSub = txtIncomeDocsSub.Text.Trim();
                objRV.NoOfpplseen = txtNoOfPplSeenResidence.Text.Trim();
                objRV.typeofloan = ddlTypeOfLoan.SelectedValue.ToString();
                objRV.remark = txtRemarks.Text.Trim();
                objRV.Spl_Instr = txtSplInstr.Text.Trim();
         

                objRV.PincodeAddMatch = ddlPincodeAddMatch.SelectedValue.ToString();
                objRV.AddressSetup = ddlAddressSetup.SelectedValue.ToString();
                objRV.MetCust = ddlMetCust.SelectedValue.ToString();
                objRV.DesgnConf = ddlDesgnConf.SelectedValue.ToString();
                objRV.MetSecurityGuard = ddlMetSecurityGuard.SelectedValue.ToString();
                objRV.CommunityDominated = ddlCommunityDominated.SelectedValue.ToString();

                //nikhil- start ING Vysysa
                objRV.FamilyStructure = ddlFamilyStructure.SelectedValue.ToString();
                objRV.LocalityType = ddlLocalityType.SelectedValue.ToString();
                objRV.ExistingLoanDetails = txtExistingLoanDetails.Text.Trim();
                objRV.ExistingVehicleDetails = txtExistingVehicleDetails.Text.Trim();
                objRV.VehicleRegNo = txtVehicleRegNo.Text.Trim();
                objRV.RouteMap = txtRouteMap.Text.Trim();

                //End ING Vysysa

                objRV.Nameverifiedfrom = txtnameverifedfrom.Text.Trim();

                string sInterior = "";
                if (ChkInteriorConditions.Items.Count > 0)
                {
                    foreach (ListItem li in ChkInteriorConditions.Items)
                    {
                        if (li.Text.Trim() == "Others" && li.Selected == true)
                            sInterior += li.Value + ":" + txtInteriorConditions.Text.Trim();
                        else
                            if (li.Selected == true)
                                sInterior += li.Value + ",";
                    }
                }
                objRV.interiorConditions = sInterior.TrimEnd(',');



                string sExteriors = "";
                if (ChkExteriors.Items.Count > 0)
                {
                    foreach (ListItem li in ChkExteriors.Items)
                    {
                        if (li.Text.Trim() == "Others" && li.Selected == true)
                            sExteriors += li.Value + ":" + txtExteriors.Text.Trim();
                        else
                            if (li.Selected == true)
                                sExteriors += li.Value + ",";
                    }
                }
                objRV.Exteriors = sExteriors.TrimEnd(',');


             
                objRV.NoOfstores = txtNoOfstores.Text.Trim();
                objRV.Residenceappear = ddlresidenceappear.SelectedValue.ToString();
                objRV.Domestichelp = ddlDomestichelp.SelectedValue.ToString();
                objRV.wastheapplicantmetaresidence = ddlwastheapplicantmetaresidence.SelectedValue.ToString();

           

                objRV.Earingmembers = txtEaringmembers.Text.Trim();
                objRV.Relationshipe = txtRelationshipe.Text.Trim();
                objRV.monthlyearing = txtmonthlyearing.Text.Trim();
                objRV.Verifierthrough = txtVerifierthrough.Text.Trim();

                objRV.ApplicantstaandinginLocality = ddlApplicantstaandinginLocality.SelectedValue.ToString();
                objRV.namee = txtnamee.Text.Trim();
                objRV.phonee = txtphonee.Text.Trim();
                objRV.elaborateonthestanding = txtelaborateonthestanding.Text.Trim();
           
                objRV.NegativeFeedbackFromFamily = txtNegativeFeedbackFromFamily.Text.Trim();
                objRV.NegativeFeedbackFromNeighbour = txtNegativeFeedbackFromNeighbour.Text.Trim();
                objRV.ApplicantCapableOfMaintaining = ddlApplicantCapableOfMaintaining.SelectedValue.ToString();
              
                objRV.IfNegBankName = txtIfNegBankName.Text.Trim();
                objRV.IfNegProduct = txtNegProduct.Text.Trim();
                objRV.DefaultBucket = txtDefaultBucket.Text.Trim();
                objRV.DefaultAmt = txtDefaultAmount.Text.Trim();
                objRV.buildingtype = txtbuildingtype.Text.Trim();
                objRV.Crossverifiedinformation = ddlcrossinformation.SelectedValue.ToString();
                objRV.Dependent_Adults = txtDependentAdults.Text.Trim();
                objRV.yearOfneighbour = txtyear.Text.Trim();
                objRV.IfYesCreditCardName = txtCreditCardName.Text.Trim();

                //Start SCB HL 31 october
                objRV.IfCCYes = ddlIfCCYes.SelectedValue.ToString();
                objRV.PermAddTelNo = txtPermAddTelNo.Text.Trim();
                objRV.CreditCardOwnershipSCB = ddlCreditCardOwnershipSCB.SelectedValue.ToString();
                objRV.Flooring = ddlFlooringType.SelectedValue.ToString();
                objRV.EarlierVisited = ddlEarlierVisited.SelectedValue.ToString();
                objRV.NearnessToNegArea = txtNearnessToNegArea.Text.Trim();
                objRV.VehicleTypeAndDetails = txtVehicleTypeAndDetails.Text.Trim();
                //End SCB HL 31 october

                string sPickupdocument = "";
                if (chkPickupdocument.Items.Count > 0)
                {
                    foreach (ListItem li in chkPickupdocument.Items)
                    {
                        if (li.Text.Trim() == "Others" && li.Selected == true)
                            sPickupdocument += li.Value + ":" + txtother.Text.Trim();
                        else
                            if (li.Selected == true)
                                sPickupdocument += li.Value + ",";
                    }
                }
                objRV.Pickupdocument = sPickupdocument.TrimEnd(',');

                objRV.Businessverification = txtBusinessverification.Text.Trim();
                objRV.ITRVerification = txtITR.Text.Trim();
                objRV.VoterIdverification = txtVoterIDVer.Text.Trim();
                objRV.banksatatmentveri = txtbanksatatment.Text.Trim();
                objRV.electricitybillveri = txtelectricitybill.Text.Trim();

                           

                if (ddlAreaname.SelectedValue.ToString() == "0")
                {
                    objRV.AreaID = txtAreapincode.Text.Trim();
                }
                else
                {
                    objRV.AreaID = ddlAreaname.SelectedValue.ToString();
                }


                objRV.FileUpload1 = null;
                Array newFileUpload1 = null;
                if (FileUpload1.FileBytes.Length > 0)
                {
                    newFileUpload1 = FileUpload1.FileBytes;
                }
                objRV.FileUpload1 = newFileUpload1;



                //New added/Updated for CHOLA
                objRV.IssuingBank = txtIssueBank.Text.ToString().Trim();
                objRV.ExpiryBank = txtExpiryBank.Text.ToString().Trim();
                objRV.AssetUser = ddlAssetUser.SelectedValue.ToString();
                objRV.AssetLocation = ddlAssetLocation.SelectedValue.ToString();
                objRV.Regis_Place = txtPlaceRegis.Text.ToString().Trim();
                objRV.PropertyAddress = txtPropertyAddress.Text.ToString().Trim();
                objRV.PropertyIdentify = ddlPropertyIdentify.SelectedValue.ToString();
                objRV.PropertyType = ddlPropertyType.SelectedValue.ToString();
                objRV.BuildingQuality = ddlBuildingQuality.SelectedValue.ToString();
                objRV.PropertyArea = txtPropertyArea.Text.ToString().Trim();
                objRV.BankMortgage = ddlBankMortgage.SelectedValue.ToString();
                objRV.NameBankMortgage = txtBankMortgage.Text.ToString().Trim();
                objRV.Dist_Railway = txtDist_Railway.Text.ToString().Trim();
                objRV.Dist_Highway = txtDist_Highway.Text.ToString().Trim();
                objRV.Dist_Bus = txtDist_Bus.Text.ToString().Trim();
                objRV.Dist_TarRoad = txtDist_TarRoad.Text.ToString().Trim();
                objRV.AssociateProperty = ddlAssociateProperty.SelectedValue.ToString();
                objRV.PropertyAge = txtPropertyAge.Text.ToString().Trim();
                objRV.PropertyDisputes = txtPropertyDisputes.Text.ToString().Trim();
                objRV.PropertyDemand = ddlPropertyDemand.SelectedValue.ToString();
                objRV.Rating = ddlRating.SelectedValue.ToString();
                objRV.NamePropertyAsOn = ddlNameProperty.SelectedValue.ToString();
                objRV.PhoneNeighbour1 = txtPhoneNeighbour1.Text.ToString().ToString();
                objRV.OwnerVisitProperty = txtOwnerVisitProperty.Text.ToString().ToString();

                //END for CHOLA 

                //New added/Updated for Capri Global
                objRV.PhotoIDdetails = txtPhotoIDdetails.Text.Trim();
                objRV.AddrProofdetails = txtAddrProofdetails.Text.Trim();
                objRV.IncomeProofdetails = txtIncomeProofdetails.Text.Trim();
                objRV.SupportingDoc = txtSupportingDoc.Text.Trim();
                //END


                InsertTeleCallLog();
                sMsg = objRV.InsertUpdateRLResiVerificationEntry();
                sMsg = objRV.InsertUpdateRLResiVerificationEntry_New();


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

        //Added by Sanket for CHOLA
        string strVerificationType = "";

        if ((hidVerificationTypeID.Value == "1") || (hidVerificationTypeID.Value == "RV"))
        {
            strVerificationType = "1";
        }
        if ((hidVerificationTypeID.Value == "36") || (hidVerificationTypeID.Value == "PV"))
        {
            strVerificationType = "36";
        }
        //End for CHOLA

        //string strVerificationType = "1";
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
        txtLanNo.Enabled = false;
        txtDateAndTime.Enabled = false;
        txtAppName.Enabled = false;
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
        txtAddress.Enabled = false;
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
        txtAreaOfHouse.Enabled = false;
        ddlCityLimit1.Enabled = false;
        txtChildren.Enabled = false;
        txtDesigation.Enabled = false;
        ddlCarPark.Enabled = false;
        ddlResiExti.Enabled = false;
        ddlResiIntl.Enabled = false;
        ddlExteriorPremises.Enabled = false;
        txtPagerNo.Enabled = false; 
        ///For Asset Checkboxes---------------------------------------------------
        chkAssets.Enabled = false;
        chkDocVeri.Enabled = false;
        txtOtherAssets.Enabled = false;
        ////--------------------------------------------------------------------  
        txtDetailsoffurnitureSeen.Enabled = false;
        txtOwnershipOfResidence.Enabled = false;
        ddlOwnershipOfResidence.Enabled = false;
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
        //ddlOwnershipDetails.Enabled = false;
        txtPermanentAddress.Enabled = false;
        txtNumberofRooms.Enabled = false;
        txtBackNum.Enabled = false;
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
        ddlPurposeOfLoanTaken.Enabled = false;
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
        txtOthFeed.Enabled = false;
        ddlCustPrev.Enabled = false;
        txtDatePrev.Enabled = false;
        ddlTranType.Enabled = false;
        ddlPropBought.Enabled = false;
        ddlRelantionProp.Enabled = false;
        txtOtherProp.Enabled = false;
        ddlOffDeci.Enabled = false;
        txtCreditCardNo.Enabled = false;
        txtAssetsPurchase.Enabled = false;
        txtAssetsLocated.Enabled = false;
        txtSpouseDesg.Enabled = false;
        ddlFinanceVisible.Enabled = false;
        ddlMunicipalLimit.Enabled = false;
        ddlSpouseWork.Enabled = false;

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
        txtSupervisorName.Enabled = false;
        ddlSupervisorName.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        txtVerifiersName.Enabled = false;
        txtAddDiff.Enabled = false;
        txtPrevAdd.Enabled = false;
        txtRentPerMonth.Enabled = false;
        txtFinanceBank.Enabled = false;
        ddlAppNameVerifiedFrom.Enabled = false;
        txtYearOfConstruction.Enabled = false;
        ddlProperty.Enabled = false;
        ddlAppOccupation.Enabled = false;
        txtNatureofbusiness.Enabled = false;
        txtWorkingsince.Enabled = false;
        ddlProofOfIdentitySeen.Enabled = false;
        txtProofOfIdentityOther.Enabled = false;
        ddlAddressProofSeen.Enabled = false;
        txtAddressProofOther.Enabled = false;
        txtNoOfWindow.Enabled = false;
        txtRelAppForGua.Enabled = false;
        txtKnowApp.Enabled = false;
        txtLiabGua.Enabled = false;
        txtEmpDet.Enabled = false;
        txtCoAppName.Enabled = false;
        txtLoanNo.Enabled = false;
        txtAmbResi.Enabled = false;
        txtCheckDet.Enabled = false;
        ddlNeighCheck.Enabled = false;
        txtBranchName.Enabled = false;
        txtBranchCode.Enabled = false;
        txtMonthSalary.Enabled = false;
        txtOtherIncome.Enabled = false;
        ddlSourceIncome.Enabled = false;
        ddlVeriOther.Enabled = false;
        txtClubbedIncome.Enabled = false;
        ddlSourceClubIncome.Enabled = false;
        ddlVeriClub.Enabled = false;
        txtVeriThrough.Enabled = false;
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

        ddlPurpose.Enabled = false;
        txtPurpose.Enabled = false;
      
        txtEndUseOfTheFunds.Enabled = false;
        ddlConfirmationResid.Enabled = false;
        ddlDedupMatch.Enabled = false;
        txtResDetails.Enabled = false;
        txtpeople.Enabled = false;
        txtRegiationNo.Enabled = false;
        ddlReputationofneighbourhood.Enabled = false;
        ddlResTelOwnership.Enabled = false;
        txtIncomeDocsSub.Enabled = false;
        txtNoOfPplSeenResidence.Enabled = false;
        ddlTypeOfLoan.Enabled = false;
        txtRemarks.Enabled = false;

        ddlLocalityType.Enabled = false;
        ddlFamilyStructure.Enabled = false;
        txtExistingLoanDetails.Enabled = false;
        txtExistingVehicleDetails.Enabled = false;
        txtVehicleRegNo.Enabled = false;
        txtRouteMap.Enabled = false;

        ddlPincodeAddMatch.Enabled = false;
        ddlAddressSetup.Enabled = false;
        ddlMetCust.Enabled = false;
        ddlMetSecurityGuard.Enabled = false;
        ddlDesgnConf.Enabled = false;
        ddlCommunityDominated.Enabled = false;
     
        txtnameverifedfrom.Enabled = false;
        txtNoOfstores.Enabled = false;
        ddlresidenceappear.Enabled = false;
        ddlDomestichelp.Enabled = false;
        ddlwastheapplicantmetaresidence.Enabled = false;

        txtEaringmembers.Enabled = false;
        txtRelationshipe.Enabled = false;
        txtmonthlyearing.Enabled = false;
        txtVerifierthrough.Enabled = false;
        ddlApplicantstaandinginLocality.Enabled = false;
        txtnamee.Enabled = false;
        txtphonee.Enabled = false;
        txtelaborateonthestanding.Enabled = false;
        txtNegativeFeedbackFromFamily.Enabled = false;
        txtNegativeFeedbackFromNeighbour.Enabled = false;
        ddlApplicantCapableOfMaintaining.Enabled = false;
        txtbuildingtype.Enabled = false;
        txtCreditCardName.Enabled = false;
        chkPickupdocument.Enabled = false;
        txtother.Enabled = false;
        txtBusinessverification.Enabled = false;
        txtITR.Enabled = false;
        txtVoterIDVer.Enabled = false;
        txtbanksatatment.Enabled = false;
        txtelectricitybill.Enabled = false;

        //New added/Updated for CHOLA
        txtIssueBank.Enabled = false;
        txtExpiryBank.Enabled = false;
        ddlAssetUser.Enabled = false;
        ddlAssetLocation.Enabled = false;
        txtPlaceRegis.Enabled = false;
        txtPropertyAddress.Enabled = false;
        ddlPropertyIdentify.Enabled = false;
        ddlPropertyType.Enabled = false;
        ddlBuildingQuality.Enabled = false;
        txtPropertyArea.Enabled = false;
        ddlBankMortgage.Enabled = false;
        txtBankMortgage.Enabled = false;
        txtDist_Railway.Enabled = false;
        txtDist_Highway.Enabled = false;
        txtDist_Bus.Enabled = false;
        txtDist_TarRoad.Enabled = false;
        ddlAssociateProperty.Enabled = false;
        txtPropertyAge.Enabled = false;
        txtPropertyDisputes.Enabled = false;
        ddlPropertyDemand.Enabled = false;
        ddlRating.Enabled = false;
        ddlNameProperty.Enabled = false;
        txtPhoneNeighbour1.Enabled = false;
        txtOwnerVisitProperty.Enabled = false;
        //END for CHOLA 

        //New added/Updated for Capri Global
        txtPhotoIDdetails.Enabled = false;
        txtAddrProofdetails.Enabled = false;
        txtIncomeProofdetails.Enabled = false;
        txtSupportingDoc.Enabled = false;
        //END

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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupervisorName.SelectedIndex != 0)
        {
            hdnSupID.Value = ddlSupervisorName.SelectedValue.ToString();
            // Session["SupID"] = ddlSupervisorName.SelectedValue.ToString();
        }
    }
}

