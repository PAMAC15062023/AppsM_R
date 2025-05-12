using System;
using System.Data;
using System.Data.SqlClient;
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
    string verificationTypeid = "2";
    //
    private CCreditCard objCC = new CCreditCard();
    DataSet dsCC = new DataSet();
    DataSet dsAttempt = new DataSet();
    DataSet dsAttempt1 = new DataSet();

    //HiddenField hdnTransStart=new HiddenField();
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }

    protected void ddlEmpTypeDubai_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmpTypeDubai.SelectedIndex == 1)
        {
            ddlemptypesubtype.Enabled = true;
        }
        else
        {
            ddlemptypesubtype.SelectedIndex = 0;
            ddlemptypesubtype.Enabled = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["verification_code"] = verificationTypeid;

        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCaseStatus.ConnectionString = objConn.ConnectionString;  //Sir
        sdsOutcome.ConnectionString = objConn.ConnectionString;  //Sir

        if (Session["ClientId"].ToString() == "101310")
        {
            lblDateJoin.Text = "Date Of Birth";
        }
        if (Session["ClientId"].ToString() == "101335")
        {
            lblSupervisorReamarks.Text = "Describe Nature of Business & Activity observed :";
            ddlAddressvisted.Items.FindByValue("Yes").Enabled = false;
            ddlAddressvisted.Items.FindByValue("No").Enabled = false;

        }

        if (Session["CentreId"].ToString() == "10172")
        {
            PnlAreaname.Visible = false;
            ddlAreaname.Visible = false;
            txtAreapincode.Visible = false;
        }
        

        //nikhil addition for Emirates NBD 05 july 2013
        if (Session["ClientId"].ToString() == "101258" || Session["ClientID"].ToString() == "101339" || Session["ClientID"].ToString() == "101149")
        {
            // Added By Rupesh on 24-Oct-2013
            ddlBusinessActivity.Items.FindByValue("High").Enabled = false;
            ddlBusinessActivity.Items.FindByValue("Medium").Enabled = false;
            ddlBusinessActivity.Items.FindByValue("Very High Activity").Enabled = false;
            ddlBusinessActivity.Items.FindByValue("None").Enabled = false;

            ddlBusinessActivity.Items.FindByValue("Yes").Enabled = false; 
            ddlBusinessActivity.Items.FindByValue("No").Enabled = false;

            ddlVisibleNameBoard.Items.FindByValue("Visible").Enabled = false;
            ddlVisibleNameBoard.Items.FindByValue("Non Visible").Enabled = false;
            ddlVisibleNameBoard.Items.FindByValue("Others").Enabled = false;

            //Ended by MAnoj Jadhav for HDFC MERCHANT
            // Added By Rupesh on 24-Oct-2013
            ddlGenAppearance.Items.FindByValue("Poor").Enabled = false;
            ddlGenAppearance.Items.FindByValue("Fair").Enabled = false;
            ddlGenAppearance.Items.FindByValue("semifurnished").Enabled = false;
            ddlGenAppearance.Items.FindByValue("unfurnished").Enabled = false;
            ddlGenAppearance.Items.FindByValue("shabby").Enabled = false;
            

        }
        if (Session["ClientId"].ToString() == "101261")
        {
            labBuildingStatus.Text = "Building Status:  Showroom/ Shop/Multi Storey Bldg/ Warehouse cum office / Factory";
            lblBranch1Location.Text = "Branches of the business ( if any)& their locations";
            lblOfficeOutsidethenarea.Text = "Area of Business Premises in Sq Ft";
            lblSponsor1Address.Text = "Home country address of key partner ";
            lblSponsor1TelephoneNo.Text = "Home country Telphone No of key partner ";
            lblDetailsOfTradeLicense.Text = "Original License Sighted/ Verified ? ";
            lblDeatailsOfProofCollected.Text = "Documents Collected at Field Visit";
            lblTypeOfOrganization.Text = "Type of Business (Industry Main Type and Sub Type)";
        }
        if (Session["ClientId"].ToString() == "101296")
        {
            lblTPCDetail.Text = "Moblie No";
            lblNameofCompany.Text = "Office / Shop / Warehouse No ";
            lblBusinessNature.Text = "Building name";
            lblOthers1.Text = "Street name";
            lblOthers2.Text = "Location / Area";
            PnlAreaname.Visible = false;
            lblApproximateAppAge.Text = "No. of employees";
            lblBranches.Text = "Details of branches / warehouse / other locations";
            lblBranch1Location.Text = "Names & details of other Business entities";
            labNameofpersonwhoactivelymanages.Text = "Name (s) of key person(s) managing the business";
            lblNoOfYrCompany.Text = "No. of years in the same line of business";
            Labamountofdefault.Text = "Flat / House / Flat No";
            Label15.Text = "Street Name";
            Label14.Text = "Area";
            lblOfficeOutsidethenarea.Text = "City";
            lblExternalAuditor.Text = "Country";
            lblAppHomeCountryPhoneNo.Text = "Telephone No";
            lblAppReportToName.Text = "No of years in UAE";
            lblProductDealtWith.Text = "Products / Services";
            lblMainBusiOrCompanyActivity.Text = "Activity (eg. Wholesale trade, Retail Trade, etc.)";
            lblifbusactntseen.Text = "Sub-activity (eg. Textiles, Foodstuff, auto spare parts, etc.)";
            lblWhoareyourcustomer.Text = "Names of main customers";
            labNamesofkeysuppliers.Text = "Names of main suppliers";
            lblSegmentation.Text = "Names of main competitors";

            labtradingname.Text = "Countries to which exported";
            lblNoOfEmployeeTPC.Text = "No. of employees seen during the visit";
            lblCoAppName.Text = "Total value of company assets";
            lblStockType.Text = "Value of stocks";
            lblTypeOfLoan.Text = "Purpose of loan";
            labLoantenor.Text = "Tenor";
            lblCompBank.Text = "Name of Primary Bank";
            lblBankName1.Text = "Names of other bankers";
            lblPreviousEmploymentDetails.Text = "Cheque returns (if any) issued by the company and reasons";
            lblParticulars.Text = "Cheque returns (if any) in favour of the company and reasons";
            lblAddConfirmation.Text = "Name Board Sighted";
            lblContactability.Text = "Activity sighted";
            lblConfirmationApp.Text = "Customers sighted";
        }
        //END NBD


        if (hdnSupID.Value != "")
        {
            //GetSupervisorList();
            ddlSupervisorName.SelectedValue = hdnSupID.Value;
        }




        //pnlOutcome.Visible = false;
        //pnlDeclineReason.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            try
            {

                #region  Below Line Added By Avinash Wankhede Dated 17 June 2009
                //Will Check if Applicant is Self Employed or Salaried
                if ((Session["ClientId"].ToString().Trim() == "1013") || (Session["ClientId"].ToString().Trim() == "101154") || (Session["ClientId"].ToString().Trim() == "101118")) //101154
                {

                    if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "")
                    {
                        string strMode = "";
                        if (Context.Request.QueryString["Mode"] != null)
                        {
                            strMode = Context.Request.QueryString["Mode"];
                        }
                        Get_IsSalaried_SelfEmployed_Status(Context.Request.QueryString["CaseID"]);
                        Response.Redirect("CC_BusinessVerification_GESBI_SAL.aspx?CaseId=" + Context.Request.QueryString["CaseID"] + "&VerTypeId=" + Context.Request.QueryString["VerTypeId"] + "&Type=" + Hdn_OccupationType.Value + "&Mode=" + strMode, false);


                    }
                }
                #endregion


                GetSupervisorList();
                Get_Areaname();
                GetQueryCallLog();
                hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");

                          
                funShowPanel();
                if (Session["ClientId"].ToString() == "101296")
                {
                    pnlNameOfOwner.Visible = false;
                }
                

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
                    dsAttempt1 = objCCVer.GetAttemptDtl2(sCaseId, sVerifyTypeId);
                    //START Attempt Details------------------------------------
                    if (sCaseId != "")
                    {
                        txtAttemptDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtAttemptDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        if (dsAttempt.Tables[0].Rows.Count > 0)
                        {
                            ddlCaseStatus.DataBind();
                            if (dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString() == "")
                            {
                                ddlCaseStatus.SelectedIndex = 0;
                            }
                            else
                            {

                                ddlCaseStatus.SelectedValue = dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString();
                            }
                            
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

                                    if ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == null)))

                                    {
                                        ddlSubSat1.SelectedIndex = 0;
                                        
                                    }
                                    else{ 
                                        ddlSubSat1.SelectedValue = dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString();
                                    }
                                 }
                                if (i == 1)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType2.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark2.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                    if ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                                    {
                                        ddlSubSat2.SelectedIndex = 0; 
                                    }
                                    else {
                                   ddlSubSat2.SelectedValue = dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString();
                                  }
                                }
                                if (i == 2)
                                {
                                    string sTmp = dsAttempt.Tables[0].Rows[i]["Attempt_Date_Time"].ToString();
                                    string[] arrAttemptDateTime = sTmp.Split(' ');
                                    txtAttemptDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                                    txtAttemptTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                                    ddlAttemptTimeType3.SelectedValue = arrAttemptDateTime[2].ToString();
                                    txtAttemptRemark3.Text = dsAttempt.Tables[0].Rows[i]["Remark"].ToString();
                                    if ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == "") || ((dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString() == null)))
                                    {
                                        ddlSubSat3.SelectedIndex = 0;
                                    }
                                    else {
                                        ddlSubSat3.SelectedValue = dsAttempt.Tables[0].Rows[i]["SubRemark"].ToString();
                                    }

                                }
                            }

                            
                        }

                        if (dsAttempt1.Tables[0].Rows.Count > 0)
                        {
                            //ddlCaseStatus.SelectedValue = dsAttempt.Tables[0].Rows[0]["Case_Status_ID"].ToString();

                            for (int i = 0; i < dsAttempt1.Tables[0].Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    lblsat1.Text = dsAttempt1.Tables[0].Rows[i]["FullName"].ToString();

                                }
                                if (i == 1)
                                {
                                    lblsat2.Text = dsAttempt1.Tables[0].Rows[i]["FullName"].ToString();
                                }
                                if (i == 2)
                                {
                                    lblsat3.Text = dsAttempt1.Tables[0].Rows[i]["FullName"].ToString();
                                }
                            }

                        }

                       
                    }
                    //END Attempt Details ------------------------------------
                    ///START CASE DETAIL------------------------------------
                    OleDbDataReader oledbReadarea;
                    oledbReadarea = objCCVer.GetFE_Areadetalis_BV(Request.QueryString["CaseID"].ToString());
                    if (oledbReadarea.Read())
                    {
                        if (oledbReadarea["PincodeArea_Name"].ToString() == "")
                        {
                        }
                        else
                        {
                            btnPincode.Visible = false;
                            txtAreapincode.Visible = false;
                            ddlAreaname.Visible = true;
                            ddlAreaname.SelectedItem.Text = oledbReadarea["PincodeArea_Name"].ToString();
                        }
                    }
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

                        txtCompanyName.Text = oledbReadCaseDtl["OFF_NAME"].ToString();

                    }
                    oledbReadCaseDtl.Close();
                    ///END CASE DETAIL------------------------------------
                }

                //////START FOR BUSINESS VERIFICATION(CPV_CC_VERI_DESCRIPTION) CASE DETAIL------------------
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
                        ///For AssetVisible Checkboxes---------------------------------------------------
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
                        //For Proof of Visit Collected dropdown---------------------
                        string sVisitProof = oledbCaseDescRead["PROOF_OF_VISIT_COLLECTED"].ToString();
                        if (sVisitProof.Trim() != "")
                        {
                            string[] arrsVisitProof = sVisitProof.Split(':');
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
                        //NIKHIL for ADCB
                        TextBox1.Text = oledbCaseDescRead["Other_nature_of_business"].ToString();
                        //Nikhil end
                        
                        //Naresh End 13/05/2008

                        //added by kamal matekar
                        txtNameDisplayedInNameBoardOfTheSociety.Text = oledbCaseDescRead["NAME_SOCIETY_BOARD"].ToString();
                        ddlDoesTheApplicantWorkHere.SelectedValue = oledbCaseDescRead["APPLICANT_WORKS_AT"].ToString();
                        ddlShiftOfWork.SelectedValue = oledbCaseDescRead["WORKING"].ToString();
                        //end by kamal.............
                        //Added by Manoj for HDFC Merchant
                        txttradingname.Text = oledbCaseDescRead["Tradingname"].ToString();
                        txtNoofyearrelationship.Text = oledbCaseDescRead["Noofyearrelationship"].ToString();
                        txtNoOfEDCinshop.Text = oledbCaseDescRead["NoOfEDCinshop"].ToString();
                        txtNoOfpersonhandlingEDCmachine.Text = oledbCaseDescRead["NoOfpersonhandlingEDCmachine"].ToString();
                        txtMCCType.Text = oledbCaseDescRead["MCCType"].ToString();

                        txtMarketinformationchangebackhistroy.Text = oledbCaseDescRead["Marketinformationchangebackhistroy"].ToString();
                        ddlKnowledgelevalofstaff.SelectedValue = oledbCaseDescRead["Knowledgelevalofstaff"].ToString();
                        ddlpartofchain.SelectedValue = oledbCaseDescRead["partofchain"].ToString();
                        ddlAcceptingcard.SelectedValue = oledbCaseDescRead["Acceptingcard"].ToString();
                        ddlTypeOfcard.SelectedValue = oledbCaseDescRead["TypeOfcard"].ToString();
                        ddlHDFCBankcreditcard.SelectedValue = oledbCaseDescRead["HDFCBankcreditcard"].ToString();
                        txtCardetalis.Text = oledbCaseDescRead["carddetalis"].ToString();
                        txtcardlimit.Text = oledbCaseDescRead["cardlimit"].ToString();

                        //Ended by MAnoj Jadhav for HDFC MERCHANT

                    }
                   
                    oledbCaseDescRead.Close();




                    /////
                    //start for Cpv_Cc_Veri_ENBD

                    OleDbDataReader oledbCaseDesc12Read;
                    oledbCaseDesc12Read = objCCVer.GetCaseVerENBDBV(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseDesc12Read.Read())
                    {
                        txtregdetails1.Text = oledbCaseDesc12Read["registreddetails1"].ToString();

                        txtregdetails2.Text = oledbCaseDesc12Read["registreddetails2"].ToString();
                        txtregdetails3.Text = oledbCaseDesc12Read["registreddetails3"].ToString();
                        txtregdetails4.Text = oledbCaseDesc12Read["registreddetails4"].ToString();
                        txtregdetails5.Text = oledbCaseDesc12Read["registreddetails5"].ToString();
                        txtregdetails6.Text = oledbCaseDesc12Read["registreddetails6"].ToString();
                        Txtphysicaldetails1.Text = oledbCaseDesc12Read["physicaldetails1"].ToString();
                        Txtphysicaldetails2.Text = oledbCaseDesc12Read["physicaldetails2"].ToString();
                        Txtphysicaldetails3.Text = oledbCaseDesc12Read["physicaldetails3"].ToString();
                        Txtphysicaldetails4.Text = oledbCaseDesc12Read["physicaldetails4"].ToString();
                        Txtphysicaldetails5.Text = oledbCaseDesc12Read["physicaldetails5"].ToString();
                        Txtphysicaldetails6.Text = oledbCaseDesc12Read["physicaldetails6"].ToString();
                        Txtinternationaldetails1.Text = oledbCaseDesc12Read["Internationaldetails1"].ToString();
                        Txtinternationaldetails2.Text = oledbCaseDesc12Read["Internationaldetails2"].ToString();
                        Txtinternationaldetails3.Text = oledbCaseDesc12Read["Internationaldetails3"].ToString();
                        Txtinternationaldetails4.Text = oledbCaseDesc12Read["Internationaldetails4"].ToString();
                        Txtinternationaldetails5.Text = oledbCaseDesc12Read["Internationaldetails5"].ToString();
                        Txtinternationaldetails6.Text = oledbCaseDesc12Read["Internationaldetails6"].ToString();
                        TxtregisteredBusinessoffice1.Text = oledbCaseDesc12Read["registeredBusinessoffice1"].ToString();
                        TxtregisteredBusinessoffice2.Text = oledbCaseDesc12Read["registeredBusinessoffice2"].ToString();
                        TxtregisteredBusinessoffice3.Text = oledbCaseDesc12Read["registeredBusinessoffice3"].ToString();
                        TxtregisteredBusinessoffice4.Text = oledbCaseDesc12Read["registeredBusinessoffice4"].ToString();
                        TxtothersBussinessdetails1.Text = oledbCaseDesc12Read["PnlothersBussinessdetails1"].ToString();
                        TxtothersBussinessdetails2.Text = oledbCaseDesc12Read["PnlothersBussinessdetails2"].ToString();
                        TxtothersBussinessdetails3.Text = oledbCaseDesc12Read["PnlothersBussinessdetails3"].ToString();
                        TxtothersBussinessdetails4.Text = oledbCaseDesc12Read["PnlothersBussinessdetails4"].ToString();
                        Txtmob1.Text = oledbCaseDesc12Read["Proprietormob1"].ToString();
                        Txtmob2.Text = oledbCaseDesc12Read["Proprietormob2"].ToString();
                        Txtmob3.Text = oledbCaseDesc12Read["Proprietormob3"].ToString();
                        Txtmob4.Text = oledbCaseDesc12Read["Proprietormob4"].ToString();
                        Txtclient1.Text = oledbCaseDesc12Read["Ownershipclient1"].ToString();
                        Txtclient2.Text = oledbCaseDesc12Read["Ownershipclient2"].ToString();
                        Txtclient3.Text = oledbCaseDesc12Read["Ownershipclient3"].ToString();
                        Txtclient4.Text = oledbCaseDesc12Read["Ownershipclient4"].ToString();
                        Txtownership11.Text = oledbCaseDesc12Read["Ownership1"].ToString();
                        Txtownership12.Text = oledbCaseDesc12Read["Ownership2"].ToString();
                        Txtownership13.Text = oledbCaseDesc12Read["Ownership3"].ToString();
                        Txtownership14.Text = oledbCaseDesc12Read["Ownership4"].ToString();
                        Txtnationality1.Text = oledbCaseDesc12Read["Nationality1"].ToString();
                        Txtnationality2.Text = oledbCaseDesc12Read["Nationality2"].ToString();
                        Txtnationality3.Text = oledbCaseDesc12Read["Nationality3"].ToString();
                        Txtnationality4.Text = oledbCaseDesc12Read["Nationality4"].ToString();
                        ddlInvolvedInBussiness1.SelectedItem.Text = oledbCaseDesc12Read["InvolvedInBussiness1"].ToString();
                        ddlInvolvedInBussiness2.SelectedItem.Text = oledbCaseDesc12Read["InvolvedInBussiness2"].ToString();
                        ddlInvolvedInBussiness3.SelectedItem.Text = oledbCaseDesc12Read["InvolvedInBussiness3"].ToString();
                        ddlInvolvedInBussiness4.SelectedItem.Text = oledbCaseDesc12Read["InvolvedInBussiness4"].ToString();
                        txtDteailremark1.Text = oledbCaseDesc12Read["Detailremark1"].ToString();
                        txtDteailremark2.Text = oledbCaseDesc12Read["Detailremark2"].ToString();
                        txtDteailremark3.Text = oledbCaseDesc12Read["Detailremark3"].ToString();
                        txtDteailremark4.Text = oledbCaseDesc12Read["Detailremark4"].ToString();
                        TxtRegistration1.Text = oledbCaseDesc12Read["Registration1"].ToString();
                        TxtExpiryDate.Text = oledbCaseDesc12Read["ExpiryDate"].ToString();
                        TxtLineofBussiness.Text = oledbCaseDesc12Read["LineofBussiness"].ToString();
                        TxtIssuingAuthority.Text = oledbCaseDesc12Read["IssuingAuthority"].ToString(); ;
                        TxtTypeofProduct1.Text = oledbCaseDesc12Read["TypeofProduct1"].ToString();
                        TxtTypeofProduct2.Text = oledbCaseDesc12Read["TypeofProduct2"].ToString();
                        TxtTypeofProduct3.Text = oledbCaseDesc12Read["TypeofProduct3"].ToString();
                        TxtTypeofProduct4.Text = oledbCaseDesc12Read["TypeofProduct4"].ToString();
                        TxtTypeofProduct5.Text = oledbCaseDesc12Read["TypeofProduct5"].ToString();
                        TxttotalPOSPrevious1.Text = oledbCaseDesc12Read["SalesPOSPrevious1"].ToString();
                        TxttotalPOSPrevious2.Text = oledbCaseDesc12Read["SalesPOSPrevious2"].ToString();
                        TxttotalPOSCurrent1.Text = oledbCaseDesc12Read["SalesPOSCurrent1"].ToString();
                        TxttotalPOSCurrent2.Text = oledbCaseDesc12Read["SalesPOSCurrent2"].ToString();
                        TxtDirectorName1.Text = oledbCaseDesc12Read["DirectorName1"].ToString();
                        TxtDirectorName2.Text = oledbCaseDesc12Read["DirectorName2"].ToString();
                        TxtDirectorName3.Text = oledbCaseDesc12Read["DirectorName3"].ToString();
                        TxtDirectorName4.Text = oledbCaseDesc12Read["DirectorName4"].ToString();
                        TxtDirectorAdd1.Text = oledbCaseDesc12Read["DirectorresidenceAdd1"].ToString();
                        TxtDirectorAdd2.Text = oledbCaseDesc12Read["DirectorresidenceAdd2"].ToString();
                        TxtDirectorAdd3.Text = oledbCaseDesc12Read["DirectorresidenceAdd3"].ToString();
                        TxtDirectorAdd4.Text = oledbCaseDesc12Read["DirectorresidenceAdd4"].ToString();
                        TxtDirectorpermntAdd1.Text = oledbCaseDesc12Read["DirectorpermanentAdd1"].ToString();
                        TxtDirectorpermntAdd2.Text = oledbCaseDesc12Read["DirectorpermanentAdd2"].ToString();
                        TxtDirectorpermntAdd3.Text = oledbCaseDesc12Read["DirectorpermanentAdd3"].ToString();
                        TxtDirectorpermntAdd4.Text = oledbCaseDesc12Read["DirectorpermanentAdd4"].ToString();
                        ddlDirectorGender1.SelectedItem.Text = oledbCaseDesc12Read["DirectorGender1"].ToString();
                        ddlDirectorGender2.SelectedItem.Text = oledbCaseDesc12Read["DirectorGender2"].ToString();
                        ddlDirectorGender3.SelectedItem.Text = oledbCaseDesc12Read["DirectorGender3"].ToString();
                        ddlDirectorGender4.SelectedItem.Text = oledbCaseDesc12Read["DirectorGender4"].ToString();
                        TxtDirectorDOB1.Text = oledbCaseDesc12Read["DirectorDOB1"].ToString();
                        TxtDirectorDOB2.Text = oledbCaseDesc12Read["DirectorDOB2"].ToString();
                        TxtDirectorDOB3.Text = oledbCaseDesc12Read["DirectorDOB3"].ToString();
                        TxtDirectorDOB4.Text = oledbCaseDesc12Read["DirectorDOB4"].ToString();
                        Txteducation1.Text = oledbCaseDesc12Read["DirectorEducation1"].ToString();
                        Txteducation2.Text = oledbCaseDesc12Read["DirectorEducation2"].ToString();
                        Txteducation3.Text = oledbCaseDesc12Read["DirectorEducation3"].ToString();
                        Txteducation4.Text = oledbCaseDesc12Read["DirectorEducation4"].ToString();
                        Txtphone1.Text = oledbCaseDesc12Read["DirectorPhone1"].ToString();
                        Txtphone2.Text = oledbCaseDesc12Read["DirectorPhone2"].ToString();
                        Txtphone3.Text = oledbCaseDesc12Read["DirectorPhone3"].ToString(); ;
                        Txtphone4.Text = oledbCaseDesc12Read["DirectorPhone4"].ToString();
                        TxtMobile1.Text = oledbCaseDesc12Read["DirectorMobile1"].ToString();
                        TxtMobile2.Text = oledbCaseDesc12Read["DirectorMobile2"].ToString();
                        TxtMobile3.Text = oledbCaseDesc12Read["DirectorMobile3"].ToString();
                        TxtMobile4.Text = oledbCaseDesc12Read["DirectorMobile4"].ToString();
                        TxtPrimaryContact.Text = oledbCaseDesc12Read["PrimaryContact"].ToString();
                        TxtPrimaryContactDegignation.Text = oledbCaseDesc12Read["PrimaryContactDegignation"].ToString();
                        TxtContactDetails1.Text = oledbCaseDesc12Read["ContactDetails1"].ToString();
                        TxtContactDetails2.Text = oledbCaseDesc12Read["ContactDetails2"].ToString();




                    }
                    oledbCaseDesc12Read.Close();



                    //end for Cpv_Cc_Veri_ENBD//

                   







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

                        // SCB CC start 
                        txtNameofCompany.Text = oledbCaseDesc1Read["NAMEOFCOMPANY1"].ToString();
                        DdlVerification.SelectedValue = oledbCaseDesc1Read["Verification"].ToString();
                        txtreasonrecommended.Text = oledbCaseDesc1Read["ReasonVerification"].ToString();
                        ddlOfficersDecision.SelectedValue = oledbCaseDesc1Read["Officers_Decision"].ToString();
                        DdlCityLimitYN.SelectedValue = oledbCaseDesc1Read["CityLimitYN"].ToString();
                        txtOfficeOutsidethenarea.Text = oledbCaseDesc1Read["Outsidecitylimitarea"].ToString();
                        txtApplicantReport.Text = oledbCaseDesc1Read["Applicant_Report"].ToString();
                        txtNeighbourFeedback.Text = oledbCaseDesc1Read["AnyOtherFeedback"].ToString();
                        txtTotalYears.Text = oledbCaseDesc1Read["TotalYears"].ToString();

                        // SCB End

                        txtContactPersonName.Text = oledbCaseDesc1Read["CONTACTED_PERSON_NAME"].ToString();
                        txtContPersonDesgn.Text = oledbCaseDesc1Read["CONTACTED_PERSON_DESIGN"].ToString();
                        txtNoOfYrCompany.Text = oledbCaseDesc1Read["COMPANY_EXISTENCE_YEAR"].ToString();
                        ddlTypeOfJob.SelectedValue = oledbCaseDesc1Read["EMP_JOB_TYPE"].ToString();
                        ddlReputationOffice.Text = oledbCaseDesc1Read["OFFICE_REPUTATION"].ToString();
                        //For Qualification dropdown---------------------
                        string sBusiPermises = oledbCaseDesc1Read["BUSINESS_PERMISES"].ToString();
                        if (sBusiPermises.Trim() != "")
                        {
                            string[] arrBusiPermises = sBusiPermises.Split(':');
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
                        //////////string sOffIsIn = oledbCaseDesc1Read["OFFICE_IS_IN"].ToString();
                        //////////if (sOffIsIn.Trim() != "")
                        //////////{
                        //////////    string[] arrOffIsIn = sOffIsIn.Split('+');
                        //////////    if (arrOffIsIn.Length > 0)
                        //////////    {
                        //////////        if (arrOffIsIn[0].ToString() == "Others" && arrOffIsIn.Length > 1)
                        //////////        {
                        //////////            ddlOfficeIsIn.SelectedValue = "Others";
                        //////////            txtOtherOfficeIsIn.Text = arrOffIsIn[1].ToString();
                        //////////        }
                        //////////        else
                        //////////        {
                        //////////            ddlOfficeIsIn.SelectedValue = arrOffIsIn[0].ToString();
                        //////////        }
                        //////////    }
                        //////////}
                        ddlOfficeIsIn.SelectedItem.Text = oledbCaseDesc1Read["OFFICE_IS_IN"].ToString();  
                        //--------------------------------------------------        
                        //For Type of office dropdown---------------------
                        string sTypeOfOffice = oledbCaseDesc1Read["TYPE_OF_OFFICE"].ToString();
                        if (sTypeOfOffice.Trim() != "")
                        {
                            string[] arrTypeOfOffice = sTypeOfOffice.Split(':');
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
                            string[] arrAppWorkingAs = sAppWorkingAs.Split(':');
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
                            string[] arrLocalityOffice = sLocalityOffice.Split(':');
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

                        string sLocalityOfficeDubai = oledbCaseDesc1Read["OFFICE_LOCALITY_DUBAI"].ToString();
                        if (sLocalityOfficeDubai.Trim() != "")
                        {
                            string[] arrLocalityOfficeDubai = sLocalityOfficeDubai.Split(':');
                            if (arrLocalityOfficeDubai.Length > 0)
                            {
                                if (arrLocalityOfficeDubai[0].ToString() == "Others" && arrLocalityOfficeDubai.Length > 1)
                                {
                                    ddlLocalityOfficeDubai.SelectedValue = "Others";
                                    txtOtherLocalityOffice.Text = arrLocalityOfficeDubai[1].ToString();
                                }
                                else
                                {
                                    ddlLocalityOfficeDubai.SelectedValue = arrLocalityOfficeDubai[0].ToString();
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



                        //Added by abhijeet For ENBDSME//
                        ddlphysicaladdress.SelectedItem.Text = oledbCaseDesc1Read["physicaladdressnew"].ToString();
                        txtreasonsOfmailing.Text = oledbCaseDesc1Read["ReasonOfmailing"].ToString();
                        txtnatureofbussinessactivityobserved.Text = oledbCaseDesc1Read["natureofbussinessactivityobserved"].ToString();


                        //ended by abhijeet For ENBDSME//





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
                            string[] arrRelation = sRelation.Split(':');
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
                            string[] arrVerConductAt = sVerConductAt.Split(':');
                            if (arrVerConductAt.Length > 0)
                            {
                                if (arrVerConductAt[0].ToString() == "Others" && arrVerConductAt.Length > 1)
                                {
                                    ddlVerificationconductedat.SelectedValue = "Others";
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
                            string[] arrAppMetAt = sAppMetAt.Split(':');
                            if (arrAppMetAt.Length > 0)
                            {
                                if (arrAppMetAt[0].ToString() == "Others" && arrAppMetAt.Length > 1)
                                {
                                    ddlApplMetat.SelectedValue = "Others";
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
                            string[] arrBusiType = sBusiType.Split(':');
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
                        ////add by kamal matekar
                        ddlNeighbourReference.SelectedValue = oledbCaseDesc1Read["NEIGHBOUR_REFERENCE"].ToString();
                        txtEmail.Text = oledbCaseDesc1Read["MAILING_ADDRESS"].ToString();
                        ////////end by kamal

                        //Added by Manoj for Axis Change address

                        ddlApplicantfound.SelectedValue = oledbCaseDesc1Read["Applicantfound"].ToString();
                        txtApplicantdefaulted.Text = oledbCaseDesc1Read["Applicantdefaulted"].ToString();
                        txtProductdefault.Text = oledbCaseDesc1Read["Productdefault"].ToString();
                        txtdateofdefault.Text = oledbCaseDesc1Read["dateofdefault"].ToString();
                        txtamountofdefault.Text = oledbCaseDesc1Read["amountofdefault"].ToString();
                        ddlIscompanynegative.SelectedValue = oledbCaseDesc1Read["Iscompanynegative"].ToString();
                        ddlIsdesignationnagative.SelectedValue = oledbCaseDesc1Read["Isdesignationnagative"].ToString();
                        ddlfloorseparateresidence.SelectedValue = oledbCaseDesc1Read["Isfloorseparateresidence"].ToString();
                        ddlroomseparateresidence.SelectedValue = oledbCaseDesc1Read["Isroomseparateresidence"].ToString();
                        ddlentrancetoresidence.SelectedValue = oledbCaseDesc1Read["Isentranceresidence"].ToString();
                        ddlAddressvisted.SelectedValue = oledbCaseDesc1Read["Addressvisited"].ToString();
                        txtOtheraddressobtained.Text = oledbCaseDesc1Read["OtherAddress"].ToString();

                        ////////end by manoj
                        //nikhil sbi change address start
                        ddlApplicantConfirmation.SelectedValue = oledbCaseDesc1Read["ApplicationConfirmation"].ToString();
                        ddlSBItpc1.SelectedValue = oledbCaseDesc1Read["SBItpc1"].ToString();
                        ddlSBItpc2.SelectedValue = oledbCaseDesc1Read["SBItpc2"].ToString();
                        ddlEmploymentConf.SelectedValue = oledbCaseDesc1Read["EmploymentConfirmed"].ToString();
                        //end nikhil
                        //Added by Manoj for First Gulf Bank
                        txtBuildingStatus.Text = oledbCaseDesc1Read["BuildingStatus"].ToString();
                        txtLegalstructureofbusiness.Text = oledbCaseDesc1Read["Legalstructureofbusiness"].ToString();
                        txtRelatedpartyinfo.Text = oledbCaseDesc1Read["Relatedpartyinfo"].ToString();
                        txtNameofpersonwhoactivelymanages.Text = oledbCaseDesc1Read["Nameofpersonwhoactivelymanages"].ToString();
                        txtCurrentactivepartnerinvolvement.Text = oledbCaseDesc1Read["Currentactivepartnerinvolvement"].ToString();
                        txtDateofbusincorporation.Text = oledbCaseDesc1Read["Dateofbusincorporation"].ToString();
                        txtLoanamountapplied.Text = oledbCaseDesc1Read["Loanamountapplied"].ToString();
                        txtLoantenor.Text = oledbCaseDesc1Read["Loantenor"].ToString();
                        txtEnduseoffunds.Text = oledbCaseDesc1Read["Enduseoffunds"].ToString();
                        txtINTERVIEWERCONCERNS.Text = oledbCaseDesc1Read["INTERVIEWERCONCERNS"].ToString();
                        txtINTERVIEWERMITIGANTS.Text = oledbCaseDesc1Read["INTERVIEWERMITIGANTS"].ToString();
                        txtBusinesssupplier.Text = oledbCaseDesc1Read["Businesssupplier"].ToString();
                        txtSuppliercompanyname.Text = oledbCaseDesc1Read["Suppliercompanyname"].ToString();
                        txtSuplierlandline.Text = oledbCaseDesc1Read["Suplierlandline"].ToString();
                        txtsupplierremarks.Text = oledbCaseDesc1Read["supplierremarks"].ToString();
                        txtBusinesscustomername.Text = oledbCaseDesc1Read["Businesscustomername"].ToString();
                        txtCutomercompanyname.Text = oledbCaseDesc1Read["Cutomercompanyname"].ToString();
                        txtCustomermobile.Text = oledbCaseDesc1Read["Customermobile"].ToString();
                        txtCustomerRemark.Text = oledbCaseDesc1Read["CustomerRemark"].ToString();
                        txtPurchasesaveragepurchaseterms.Text = oledbCaseDesc1Read["Purchasesaveragepurchaseterms"].ToString();
                        txtPurchaseLocal.Text = oledbCaseDesc1Read["PurchaseLocal"].ToString();
                        txtPurchaseImport.Text = oledbCaseDesc1Read["PurchaseImport"].ToString();
                        txtCountriesimportedfrom.Text = oledbCaseDesc1Read["Countriesimportedfrom"].ToString();
                        txtTotalNoOfsupplier.Text = oledbCaseDesc1Read["TotalNoOfsupplier"].ToString();
                        txtNoOfactivesuppliers.Text = oledbCaseDesc1Read["NoOfactivesuppliers"].ToString();
                        txtNamesofkeysuppliers.Text = oledbCaseDesc1Read["Namesofkeysuppliers"].ToString();
                        txtAveragesalesterms.Text = oledbCaseDesc1Read["Averagesalesterms"].ToString();
                        txtLocalTransport.Text = oledbCaseDesc1Read["LocalTransport"].ToString();
                        txtOtherCountriesPercentage.Text = oledbCaseDesc1Read["OtherCountriesPercentage"].ToString();
                        txtOtherCountries.Text = oledbCaseDesc1Read["OtherCountries"].ToString();
                        txtTotalNoofcustomers.Text = oledbCaseDesc1Read["TotalNoofcustomers"].ToString();
                        txtNoofActivecustomers.Text = oledbCaseDesc1Read["NoofActivecustomers"].ToString();
                        txtNamesofkeycustomers.Text = oledbCaseDesc1Read["Namesofkeycustomers"].ToString();
                        txtCreditRemarksPostFieldVisit.Text = oledbCaseDesc1Read["CreditRemarksPostFieldVisit"].ToString();

                        //added by abhijeet for axis bank//

                        txtdocname1.Text = oledbCaseDesc1Read["Doccumentname1"].ToString();
                        txtdocname2.Text = oledbCaseDesc1Read["Doccumentname2"].ToString();
                        txtdocname3.Text = oledbCaseDesc1Read["Doccumentname3"].ToString();

                        Txtobs1.Text = oledbCaseDesc1Read["Fru_Observation1"].ToString();
                        Txtobs2.Text = oledbCaseDesc1Read["Fru_Observation2"].ToString();
                        Txtobs3.Text = oledbCaseDesc1Read["Fru_Observation3"].ToString();

                        Txtsetup.Text = oledbCaseDesc1Read["Setupcompany"].ToString();
                        Txtnegmarinfo.Text = oledbCaseDesc1Read["Negmarketinfo"].ToString();
                        Txtantisoc.Text = oledbCaseDesc1Read["Antisoc"].ToString();


                        txtracname.Text = oledbCaseDesc1Read["RACName"].ToString();
                        txtfileno.Text = oledbCaseDesc1Read["FileNo"].ToString();
                        txtdsacode.Text = oledbCaseDesc1Read["DSACode"].ToString();

                        txtsalesmanagercode.Text = oledbCaseDesc1Read["SalesManagerCode"].ToString();
                        txtfculocation.Text = oledbCaseDesc1Read["FcuLocation"].ToString();
                        txtproduct.Text = oledbCaseDesc1Read["Product"].ToString();

                        txtdsecode.Text = oledbCaseDesc1Read["DSECode"].ToString();
                        txtpickupprofile.Text = oledbCaseDesc1Read["Pickupprofile"].ToString();

                        txtsamplername.Text = oledbCaseDesc1Read["samplername"].ToString();
                        txtagencyremark.Text = oledbCaseDesc1Read["AgencyRemark"].ToString();

                        txtpickupdate.Text = oledbCaseDesc1Read["pickupdate"].ToString();
                        txtreportdate.Text = oledbCaseDesc1Read["Reportdate"].ToString();





                        ddlemptypesubtype.SelectedValue = oledbCaseDesc1Read["emptypesubtype"].ToString();

                        //ended by abhijeet//




                        //Ended by Manoj for First Gulf Bank 


                      
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
                            string[] arrVisibleNameBoard = sVisibleNameBoard.Split(':');
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
                        if (!(oledbCaseVerOtherDtlRead["TYPE_OF_LOAN"].ToString().Trim().Length.Equals(0)))
                            txtTypeOfLoan.Text = oledbCaseVerOtherDtlRead["TYPE_OF_LOAN"].ToString();

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
                            string[] arrIsTradeLicenseOfCompanyDisplayedOnPremises = sIsTradeLicenseOfCompanyDisplayedOnPremises.Split(':');
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

                        //Start fields for Dubai MB ADCB NIKHIL
                        if (!(oledbCaseVerOtherDtlRead["AuthorizedSignatoryName"].ToString().Trim().Length.Equals(0)))
                            txtAuthorizedSignatoryName.Text = oledbCaseVerOtherDtlRead["AuthorizedSignatoryName"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["NeighSecurityCheck"].ToString().Trim().Length.Equals(0)))
                            txtNeighSecurityCheck.Text = oledbCaseVerOtherDtlRead["NeighSecurityCheck"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["MinSalaryRange"].ToString().Trim().Length.Equals(0)))
                            txtMinSalaryDubai.Text = oledbCaseVerOtherDtlRead["MinSalaryRange"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["MaxSalaryRange"].ToString().Trim().Length.Equals(0)))
                            txtMaxSalaryDubai.Text = oledbCaseVerOtherDtlRead["MaxSalaryRange"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["ProductTypeDubai"].ToString().Trim().Length.Equals(0)))
                            ddlProductTypeDubai.SelectedValue = oledbCaseVerOtherDtlRead["ProductTypeDubai"].ToString();
                        else
                            ddlProductTypeDubai.SelectedValue = "NA";

                        //End fields for Dubai MB ADCB NIKHIL

                        //Start for Emirates NBD ....NIKHIL
                        
                        if (!(oledbCaseVerOtherDtlRead["SisterOrGroupCompanyDetails"].ToString().Trim().Length.Equals(0)))
                            txtSisterOrGroupCompanyDetails.Text = oledbCaseVerOtherDtlRead["SisterOrGroupCompanyDetails"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["ExternalAuditor"].ToString().Trim().Length.Equals(0)))
                            txtExternalAuditor.Text = oledbCaseVerOtherDtlRead["ExternalAuditor"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["AnnualRevenueAndProfit"].ToString().Trim().Length.Equals(0)))
                            txtAnnualRevenueAndProfit.Text = oledbCaseVerOtherDtlRead["AnnualRevenueAndProfit"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["ProfitPercentage"].ToString().Trim().Length.Equals(0)))
                            txtProfitPercentage.Text = oledbCaseVerOtherDtlRead["ProfitPercentage"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["DocsCollectedDubai"].ToString().Trim().Length.Equals(0)))
                            txtDocsCollectedDubai.Text = oledbCaseVerOtherDtlRead["DocsCollectedDubai"].ToString();

                        if (!(oledbCaseVerOtherDtlRead["OriginalSeenDubai"].ToString().Trim().Length.Equals(0)))
                            ddlOriginalSeenDubai.SelectedValue = oledbCaseVerOtherDtlRead["OriginalSeenDubai"].ToString();
                        else
                            ddlOriginalSeenDubai.SelectedValue = "NA";
                        //End NBD

                        //Start for SCB and CITI Dubai....NIKHIL
                        if (!(oledbCaseVerOtherDtlRead["EmpTypeDubai"].ToString().Trim().Length.Equals(0)))
                            ddlEmpTypeDubai.SelectedValue = oledbCaseVerOtherDtlRead["EmpTypeDubai"].ToString();
                        else
                            ddlEmpTypeDubai.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["PersonMetCooperative"].ToString().Trim().Length.Equals(0)))
                            ddlPersonMetCooperative.SelectedValue = oledbCaseVerOtherDtlRead["PersonMetCooperative"].ToString();
                        else
                            ddlPersonMetCooperative.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["SalaryConfirm"].ToString().Trim().Length.Equals(0)))
                            ddlSalaryConfirm.SelectedValue = oledbCaseVerOtherDtlRead["SalaryConfirm"].ToString();
                        else
                            ddlSalaryConfirm.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["ClientTypeCITI"].ToString().Trim().Length.Equals(0)))
                            ddlClientTypeCITI.SelectedValue = oledbCaseVerOtherDtlRead["ClientTypeCITI"].ToString();
                        else
                            ddlClientTypeCITI.SelectedValue = "NA";

                        if (!(oledbCaseVerOtherDtlRead["CompanyTypeDubai"].ToString().Trim().Length.Equals(0)))
                            ddlCompanyTypeDubai.SelectedValue = oledbCaseVerOtherDtlRead["CompanyTypeDubai"].ToString();
                        else
                             ddlCompanyTypeDubai.SelectedValue = "NA";
                        //End for SCB and CITI Dubai....NIKHIL

                        //For HSBC Bank-Dubai--new fields -------

                        //For Office cum Residence dropdown---------------------
                        string sOffCumResi = oledbCaseVerOtherDtlRead["OFFICE_CUM_RESIDENCE"].ToString();
                        if (sOffCumResi.Trim() != "")
                        {
                            string[] arrOffCumResi = sOffCumResi.Split(':');
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
                            string[] arrPhotographLocation = sPhotographLocation.Split(':');
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
                        /////add by kamal matekar
                        txtAddressApporch.Text = oledbCaseVerOtherDtlRead["Address_Apporch"].ToString();
                        txtIfAddressNotFound.Text = oledbCaseVerOtherDtlRead["If_address_not_found"].ToString();
                        ddlDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer.SelectedValue = oledbCaseVerOtherDtlRead["Do_Neighbour_Neighboring_shops_or_offices_know_the_customer"].ToString();
                        txtBriefJobResponsibilities.Text = oledbCaseVerOtherDtlRead["Brief_Job_Responsibilities"].ToString();
                        txtReasonForApplicantNotMet.Text = oledbCaseVerOtherDtlRead["Reason_for_applicant_not_met"].ToString();

                        txtTypeOfOrganization.Text = oledbCaseVerOtherDtlRead["Type_Of_Organization"].ToString();
                        txtIfOtherSpecify.Text = oledbCaseVerOtherDtlRead["If_Other_specify"].ToString();
                        txtTypeOfOccupation.Text = oledbCaseVerOtherDtlRead["Type_of_occupation"].ToString();
                        txtHeadOfficebranch.Text = oledbCaseVerOtherDtlRead["Head_office_branch"].ToString();
                        /////end by kamal matekar

                    }
                    
                    oledbCaseVerOtherDtlRead.Close();
                   
                    //////////////////////////////////////////////////////////////////////////////////////////

                    //////END FOR Business VERIFICATION(CPV_CC_VERI_OTHER_DETAILS) CASE DETAIL------------------
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
                        // Added by Rupesh
                        ddlSupervisorName.SelectedValue = oledbCaseVerDtlRead["Supervisor_ID"].ToString();
                        // Added by Rupesh
                        txtSupervisorRemark.Text = oledbCaseVerDtlRead["SUPERVISOR_REMARKS"].ToString();
                        ddlCityLimit.SelectedValue = oledbCaseVerDtlRead["Reason"].ToString();

                       
                    }
                   
                    oledbCaseVerDtlRead.Close();
                    //////END FOR RESIDENTIAL VERIFICATION(CPV_CC_VERI_DETAILS) CASE DETAIL------------------


                    /////////////start code for Mashrque Bank(Santosh S)////////////////////////
                    OleDbDataReader oledbCaseVerDtlReadSoc;
                    oledbCaseVerDtlReadSoc = objCCVer.GetCaseVerDtlBVSoc(Request.QueryString["CaseID"].ToString(), Request.QueryString["VerTypeId"].ToString());
                    if (oledbCaseVerDtlReadSoc.Read())
                    {
                        //Added by Manoj for FGB_SME
                        txtcash.Text = oledbCaseVerDtlReadSoc["Sellingcash"].ToString();
                        txtCredit.Text = oledbCaseVerDtlReadSoc["Sellingcredit"].ToString();
                        txtCreditperiod.Text = oledbCaseVerDtlReadSoc["Sellingcreditperiod"].ToString();

                        txtBuyingcash.Text = oledbCaseVerDtlReadSoc["Buyingcash"].ToString();
                        txtBuyingCredit.Text = oledbCaseVerDtlReadSoc["Buyingcredit"].ToString();
                        txtBuyCreditperiod.Text = oledbCaseVerDtlReadSoc["Buyingcreditperiod"].ToString();

                        txtKeyindicators1.Text = oledbCaseVerDtlReadSoc["Keyindicators1"].ToString();
                        txtKeyindicators2.Text = oledbCaseVerDtlReadSoc["Keyindicators2"].ToString();
                        txtKeyindicators3.Text = oledbCaseVerDtlReadSoc["Keyindicators3"].ToString();

                        txtAnnualTurnover1.Text = oledbCaseVerDtlReadSoc["AnnualTurnover1"].ToString();
                        txtAnnualTurnover2.Text = oledbCaseVerDtlReadSoc["AnnualTurnover2"].ToString();
                        txtAnnualTurnover3.Text = oledbCaseVerDtlReadSoc["AnnualTurnover3"].ToString();

                        txtProfitMargin1.Text = oledbCaseVerDtlReadSoc["ProfitMargin1"].ToString();
                        txtProfitMargin2.Text = oledbCaseVerDtlReadSoc["ProfitMargin2"].ToString();
                        txtProfitMargin3.Text = oledbCaseVerDtlReadSoc["ProfitMargin3"].ToString();

                        txtCapitalInvest1.Text = oledbCaseVerDtlReadSoc["CapitalInvest1"].ToString();
                        txtCapitalInvest2.Text = oledbCaseVerDtlReadSoc["CapitalInvest2"].ToString();
                        txtCapitalInvest3.Text = oledbCaseVerDtlReadSoc["CapitalInvest3"].ToString();

                        txtFacilityType.Text = oledbCaseVerDtlReadSoc["FacilityType"].ToString();
                        txtbankName.Text = oledbCaseVerDtlReadSoc["bankName"].ToString();
                        txtFacilityamount.Text = oledbCaseVerDtlReadSoc["Facilityamount"].ToString();
                        txtSecurity.Text = oledbCaseVerDtlReadSoc["BankSecurity"].ToString();
                        txtEMI.Text = oledbCaseVerDtlReadSoc["EMI"].ToString();

                        txtQueries.Text = oledbCaseVerDtlReadSoc["Queries"].ToString();
                        txtClarification.Text = oledbCaseVerDtlReadSoc["Clarification"].ToString();
                        //Ended by Manoj Jadhav 

                       


                        ddlCurrntAddInfo.SelectedValue = oledbCaseVerDtlReadSoc["CurrntAddInfo"].ToString();
                        txtMerchantCategry.Text = oledbCaseVerDtlReadSoc["MerchantCategory"].ToString();

                        txtInfrastructureRemarks.Text = oledbCaseVerDtlReadSoc["InfrastructureRemarks"].ToString();
                        ddlNgtvinfabtmerchant.SelectedValue = oledbCaseVerDtlReadSoc["NegativeMerchantInfo"].ToString();
                        ddlRecommendation.SelectedValue = oledbCaseVerDtlReadSoc["Recommendation"].ToString();
                        ddlNameBoardType.SelectedValue = oledbCaseVerDtlReadSoc["NameBoardType"].ToString();
                        txtifbusactntseen.Text = oledbCaseVerDtlReadSoc["ifbusactntseen"].ToString();

                        ///Axis Merchant Added by Rupesh

                        txtEmirates.Text = oledbCaseVerDtlReadSoc["Emirates"].ToString();
                        txtPoboxNo.Text = oledbCaseVerDtlReadSoc["Pobox_No"].ToString();
                        txtSignboardDoor.Text = oledbCaseVerDtlReadSoc["Signboard_Door"].ToString();
                        ddlModeSalary.SelectedValue = oledbCaseVerDtlReadSoc["Mode_Salary"].ToString();
                        txtBusiTo.Text = oledbCaseVerDtlReadSoc["Busi_To"].ToString();
                        txtCompClients.Text = oledbCaseVerDtlReadSoc["Comp_Clients"].ToString();
                        txtCompBank.Text = oledbCaseVerDtlReadSoc["Comp_Bank"].ToString();
                        txtOffice1.Text = oledbCaseVerDtlReadSoc["Office1"].ToString();
                        txtOffice2.Text = oledbCaseVerDtlReadSoc["Office2"].ToString();
                        txtOffice3.Text = oledbCaseVerDtlReadSoc["Office3"].ToString();
                        txtOffice4.Text = oledbCaseVerDtlReadSoc["Office4"].ToString();
                        txtDateJoin.Text = oledbCaseVerDtlReadSoc["Date_Join"].ToString();
                        txtApplicantReport.Text = oledbCaseVerDtlReadSoc["Applicant_Report"].ToString();
                        txtDesig.Text = oledbCaseVerDtlReadSoc["Desig"].ToString();
                        ddlApplicantOwner.SelectedValue = oledbCaseVerDtlReadSoc["Applicant_Owner"].ToString();
                        txtYesRelation.Text = oledbCaseVerDtlReadSoc["Yes_Relation"].ToString();
                        txtDetailsVerified.Text = oledbCaseVerDtlReadSoc["Details_Verified"].ToString();
                        txtLoanNumber.Text = oledbCaseVerDtlReadSoc["Loan_Number"].ToString();
                        ddlRefTelNumber.SelectedValue = oledbCaseVerDtlReadSoc["Ref_Tel_Number"].ToString();
                        txtRefCont.Text = oledbCaseVerDtlReadSoc["Ref_Cont"].ToString();
                        txtArea.Text = oledbCaseVerDtlReadSoc["Area"].ToString();
                        txtEmirate1.Text = oledbCaseVerDtlReadSoc["Emirate_1"].ToString();
                        ddlLoanAppli.SelectedValue = oledbCaseVerDtlReadSoc["Loan_Appli"].ToString();
                        txtLocation.Text = oledbCaseVerDtlReadSoc["Location"].ToString();

                        //---added by kamal matekar for SCB Bank----
                        ddlVisitingCard.SelectedValue = oledbCaseVerDtlReadSoc["VisitingCard"].ToString();
                        ddlBusinessOwnership.SelectedValue = oledbCaseVerDtlReadSoc["BusinessOwnership"].ToString();
                        ddlSeparateOfficeArea.SelectedValue = oledbCaseVerDtlReadSoc["SeparateOfficeArea"].ToString();
                        txtCommentOnBusinessActivity.Text = oledbCaseVerDtlReadSoc["CommentsOnBusinessActivities"].ToString();
                        ///---ended
                        ////added by kamal matekar for scb bank-----

                        ////added by kamal matekar for Mashreq bank-----
                        txtSponsor1Designation.Text = oledbCaseVerDtlReadSoc["desig1"].ToString();
                        txtSponsor2Designation.Text = oledbCaseVerDtlReadSoc["desig2"].ToString();
                        txtFavouritePlace.Text = oledbCaseVerDtlReadSoc["Fav_Place"].ToString();
                        txtReferenceNoInUAE.Text = oledbCaseVerDtlReadSoc["Ref_UAE"].ToString();
                        txtAnyOtherBankCcFinancialfacility.Text = oledbCaseVerDtlReadSoc["Other_Bank"].ToString();
                        txtVehicalOwned.Text = oledbCaseVerDtlReadSoc["Vehical_Own"].ToString();
                        txtVehicalFinanced.Text = oledbCaseVerDtlReadSoc["Vehical_Fin"].ToString();
                        txtBreakUpOfNumberOfEmployeesWithDesignations.Text = oledbCaseVerDtlReadSoc["Breakup_Emp"].ToString();
                        txtIstheOfficePremisesSharedWithAnyOtherOffice.Text = oledbCaseVerDtlReadSoc["Premise_Share"].ToString();
                        txtNameEmp.Text = oledbCaseVerDtlReadSoc["Type_Of_Society"].ToString();
                        txtResiBuss.Text = oledbCaseVerDtlReadSoc["Other_Facilities"].ToString();
                        txtDateTimeVisit.Text = oledbCaseVerDtlReadSoc["Market_Value"].ToString();
                        txtVisit.Text = oledbCaseVerDtlReadSoc["Builtup_Area"].ToString();
                        txtAddUpd.Text = oledbCaseVerDtlReadSoc["No_Of_Flats"].ToString();
                        txtDocVeri.Text = oledbCaseVerDtlReadSoc["Bedroom"].ToString();
                        txtVisitProofDet.Text = oledbCaseVerDtlReadSoc["Negative_Area"].ToString();

                        txtAddTrace.Text = oledbCaseVerDtlReadSoc["Tpc_Name"].ToString();
                        txtSpokeTo.Text = oledbCaseVerDtlReadSoc["Tpc_Phone"].ToString();
                        txtAddRec.Text = oledbCaseVerDtlReadSoc["History"].ToString();
                        txtAddDiff.Text = oledbCaseVerDtlReadSoc["No_Of_Employee"].ToString();
                        //ended by kamal matekar...........
                    }

                    oledbCaseVerDtlReadSoc.Close();
                    ////////////////////End Code//////////////////////////

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
    private void GetQueryCallLog()
    {

        DataSet dsTeleCallLog = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objCCVer.GetQueryCallLogDetail(sCaseId);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        txtQueries.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 1)
                    {
                        txtQueries1.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification1.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 2)
                    {
                        txtQueries2.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification2.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 3)
                    {
                        txtQueries3.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification3.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 4)
                    {
                        txtQueries4.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification4.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 5)
                    {
                        txtQueries5.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification5.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 6)
                    {
                        txtQueries6.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification6.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 7)
                    {
                        txtQueries7.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification7.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 8)
                    {
                        txtQueries8.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification8.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                    if (i == 9)
                    {
                        txtQueries9.Text = dsTeleCallLog.Tables[0].Rows[i]["Queries"].ToString();
                        txtClarification9.Text = dsTeleCallLog.Tables[0].Rows[i]["Clarification"].ToString();
                    }
                }
            }
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

            ddlSupervisorName.Items.Insert(0, "--Select--");
            ddlSupervisorName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {

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
        cmd.CommandText = "Get_Areaname_CC_BV";

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

            ddlAreaname.Items.Insert(0,new ListItem("--Select--","0"));
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

            ////added by kamal matekar
            objCCVer.NameDisplayedInNameBoardOfTheSociety = txtNameDisplayedInNameBoardOfTheSociety.Text.Trim();
            objCCVer.DoesTheApplicantWorkHere = ddlDoesTheApplicantWorkHere.SelectedItem.Text.Trim();
            objCCVer.ShiftOfWork = ddlShiftOfWork.SelectedItem.Text.Trim();
            //////end by kamal matekar

            ////Santosh Shelar : End///////////////////megha.meshram@omnitechglobal.com
            /////////////////////////////////////////////////////////////////////////////////
            ///////--------CPV_CC_VERI_DESCRIPTION1-------------------

            /////  SCB Start

            objCCVer.Verification = DdlVerification.SelectedItem.Text.Trim();
            objCCVer.ReasonVerification = txtreasonrecommended.Text.Trim();
            objCCVer.CityLimitYN = DdlCityLimitYN.SelectedItem.Text.Trim();
            objCCVer.Outsidecitylimitarea = txtOfficeOutsidethenarea.Text.Trim();
            objCCVer.Officers_Decision = ddlOfficersDecision.SelectedItem.Text.Trim();
            objCCVer.NameOfCompany1 = txtNameofCompany.Text.Trim();
            objCCVer.Applicant_Report = txtApplicantReport.Text.Trim();
            objCCVer.AnyOtherFeedback = txtNeighbourFeedback.Text.Trim();
            objCCVer.TotalYears = txtTotalYears.Text.Trim();
            /////  SCB End


            //Added By abhijeet For ENBD Dubai//
            objCCVer.registrddetails1 = txtregdetails1.Text.Trim();
            objCCVer.registrddetails2 = txtregdetails2.Text.Trim();
            objCCVer.registrddetails3 = txtregdetails3.Text.Trim();
            objCCVer.registrddetails4 = txtregdetails4.Text.Trim();
            objCCVer.registrddetails5 = txtregdetails5.Text.Trim();
            objCCVer.registrddetails6 = txtregdetails6.Text.Trim();
            objCCVer.physicaldetails1 = Txtphysicaldetails1.Text.Trim();
            objCCVer.physicaldetails2 = Txtphysicaldetails2.Text.Trim();
            objCCVer.physicaldetails3 = Txtphysicaldetails3.Text.Trim();
            objCCVer.physicaldetails4 = Txtphysicaldetails4.Text.Trim();
            objCCVer.physicaldetails5 = Txtphysicaldetails5.Text.Trim();
            objCCVer.physicaldetails6 = Txtphysicaldetails6.Text.Trim();
            objCCVer.Internationaldetails1 = Txtinternationaldetails1.Text.Trim();
            objCCVer.Internationaldetails2 = Txtinternationaldetails2.Text.Trim();
            objCCVer.Internationaldetails3 = Txtinternationaldetails3.Text.Trim();
            objCCVer.Internationaldetails4 = Txtinternationaldetails4.Text.Trim();
            objCCVer.Internationaldetails5 = Txtinternationaldetails5.Text.Trim();
            objCCVer.Internationaldetails6 = Txtinternationaldetails6.Text.Trim();
            objCCVer.registeredBusinessoffice1 = TxtregisteredBusinessoffice1.Text.Trim();
            objCCVer.registeredBusinessoffice2 = TxtregisteredBusinessoffice2.Text.Trim();
            objCCVer.registeredBusinessoffice3 = TxtregisteredBusinessoffice3.Text.Trim();
            objCCVer.registeredBusinessoffice4 = TxtregisteredBusinessoffice4.Text.Trim();
            objCCVer.PnlothersBussinessdetails1 = TxtothersBussinessdetails1.Text.Trim();
            objCCVer.PnlothersBussinessdetails2 = TxtothersBussinessdetails2.Text.Trim();
            objCCVer.PnlothersBussinessdetails3 = TxtothersBussinessdetails3.Text.Trim();
            objCCVer.PnlothersBussinessdetails4 = TxtothersBussinessdetails4.Text.Trim();
            objCCVer.Proprietormob1 = Txtmob1.Text.Trim();
            objCCVer.Proprietormob2 = Txtmob2.Text.Trim();
            objCCVer.Proprietormob3 = Txtmob3.Text.Trim();
            objCCVer.Proprietormob4 = Txtmob4.Text.Trim();
            objCCVer.Ownershipclient1 = Txtclient1.Text.Trim();
            objCCVer.Ownershipclient2 = Txtclient2.Text.Trim();
            objCCVer.Ownershipclient3 = Txtclient3.Text.Trim();
            objCCVer.Ownershipclient4 = Txtclient4.Text.Trim();
            objCCVer.Ownership1 = Txtownership11.Text.Trim();
            objCCVer.Ownership2 = Txtownership12.Text.Trim();
            objCCVer.Ownership3 = Txtownership13.Text.Trim();
            objCCVer.Ownership4 = Txtownership14.Text.Trim();
            objCCVer.Nationality1 = Txtnationality1.Text.Trim();
            objCCVer.Nationality2 = Txtnationality2.Text.Trim();
            objCCVer.Nationality3 = Txtnationality3.Text.Trim();
            objCCVer.Nationality4 = Txtnationality4.Text.Trim();
            objCCVer.InvolvedInBussiness1 = ddlInvolvedInBussiness1.SelectedItem.Text.Trim();
            objCCVer.InvolvedInBussiness2 = ddlInvolvedInBussiness2.SelectedItem.Text.Trim();
            objCCVer.InvolvedInBussiness3 = ddlInvolvedInBussiness3.SelectedItem.Text.Trim();
            objCCVer.InvolvedInBussiness4 = ddlInvolvedInBussiness4.SelectedItem.Text.Trim();
            objCCVer.Detailremark1 = txtDteailremark1.Text.Trim();
            objCCVer.Detailremark2 = txtDteailremark2.Text.Trim();
            objCCVer.Detailremark3 = txtDteailremark3.Text.Trim();
            objCCVer.Detailremark4 = txtDteailremark4.Text.Trim();
            objCCVer.Registration1 = TxtRegistration1.Text.Trim();
            objCCVer.ExpiryDate = TxtExpiryDate.Text.Trim();
            objCCVer.LineofBussiness = TxtLineofBussiness.Text.Trim();
            objCCVer.IssuingAuthority = TxtIssuingAuthority.Text.Trim();
            objCCVer.TypeofProduct1 = TxtTypeofProduct1.Text.Trim();
            objCCVer.TypeofProduct2 = TxtTypeofProduct2.Text.Trim();
            objCCVer.TypeofProduct3 = TxtTypeofProduct3.Text.Trim();
            objCCVer.TypeofProduct4 = TxtTypeofProduct4.Text.Trim();
            objCCVer.TypeofProduct5 = TxtTypeofProduct5.Text.Trim();
            objCCVer.SalesPOSPrevious1 = TxttotalPOSPrevious1.Text.Trim();
            objCCVer.SalesPOSPrevious2 = TxttotalPOSPrevious2.Text.Trim();
            objCCVer.SalesPOSCurrent1 = TxttotalPOSCurrent1.Text.Trim();
            objCCVer.SalesPOSCurrent2 = TxttotalPOSCurrent2.Text.Trim();
            objCCVer.DirectorName1 = TxtDirectorName1.Text.Trim();
            objCCVer.DirectorName2 = TxtDirectorName2.Text.Trim();
            objCCVer.DirectorName3 = TxtDirectorName3.Text.Trim();
            objCCVer.DirectorName4 = TxtDirectorName4.Text.Trim();
            objCCVer.DirectorresidenceAdd1 = TxtDirectorAdd1.Text.Trim();
            objCCVer.DirectorresidenceAdd2 = TxtDirectorAdd2.Text.Trim();
            objCCVer.DirectorresidenceAdd3 = TxtDirectorAdd3.Text.Trim();
            objCCVer.DirectorresidenceAdd4 = TxtDirectorAdd4.Text.Trim();
            objCCVer.DirectorpermanentAdd1 = TxtDirectorpermntAdd1.Text.Trim();
            objCCVer.DirectorpermanentAdd2 = TxtDirectorpermntAdd2.Text.Trim();
            objCCVer.DirectorpermanentAdd3 = TxtDirectorpermntAdd3.Text.Trim();
            objCCVer.DirectorpermanentAdd4 = TxtDirectorpermntAdd4.Text.Trim();
            objCCVer.DirectorGender1 = ddlDirectorGender1.SelectedItem.Text.Trim();
            objCCVer.DirectorGender2 = ddlDirectorGender2.SelectedItem.Text.Trim();
            objCCVer.DirectorGender3 = ddlDirectorGender3.SelectedItem.Text.Trim();
            objCCVer.DirectorGender4 = ddlDirectorGender4.SelectedItem.Text.Trim();
            objCCVer.DirectorDOB1 = TxtDirectorDOB1.Text.Trim();
            objCCVer.DirectorDOB2 = TxtDirectorDOB2.Text.Trim();
            objCCVer.DirectorDOB3 = TxtDirectorDOB3.Text.Trim();
            objCCVer.DirectorDOB4 = TxtDirectorDOB4.Text.Trim();
            objCCVer.DirectorEducation1 = Txteducation1.Text.Trim();
            objCCVer.DirectorEducation2 = Txteducation2.Text.Trim();
            objCCVer.DirectorEducation3 = Txteducation3.Text.Trim();
            objCCVer.DirectorEducation4 = Txteducation4.Text.Trim();
            objCCVer.DirectorPhone1 = Txtphone1.Text.Trim();
            objCCVer.DirectorPhone2 = Txtphone2.Text.Trim();
            objCCVer.DirectorPhone3 = Txtphone3.Text.Trim();
            objCCVer.DirectorPhone4 = Txtphone4.Text.Trim();
            objCCVer.DirectorMobile1 = TxtMobile1.Text.Trim();
            objCCVer.DirectorMobile2 = TxtMobile2.Text.Trim();
            objCCVer.DirectorMobile3 = TxtMobile3.Text.Trim();
            objCCVer.DirectorMobile4 = TxtMobile4.Text.Trim();
            objCCVer.PrimaryContact = TxtPrimaryContact.Text.Trim();
            objCCVer.PrimaryContactDegignation = TxtPrimaryContactDegignation.Text.Trim();
            objCCVer.ContactDetails1 = TxtContactDetails1.Text.Trim();
            objCCVer.ContactDetails2 = TxtContactDetails2.Text.Trim();

            //Ended By abhijeet For ENBD Dubai//



            //added by Abhijeet for ENBDSME//


            objCCVer.physicaladdressnew = ddlphysicaladdress.SelectedItem.Text.Trim();
            objCCVer.ReasonOfmailing = txtreasonsOfmailing.Text.Trim();
            objCCVer.natureofbussinessactivityobserved = txtnatureofbussinessactivityobserved.Text.Trim();



            //added by Abhijeet for ENBDSME//





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

            if (ddlLocalityOfficeDubai.SelectedItem.Text.Trim() == "Others")
                objCCVer.OfficeLocalityDubai = "Others" + ":" + txtOtherLocalityOffice.Text.Trim();
            else
                objCCVer.OfficeLocalityDubai = ddlLocalityOfficeDubai.SelectedItem.Text.Trim();
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

            if (ddlVerificationconductedat.SelectedItem.Text.Trim() == "Others")
                objCCVer.VerificationConductAt = "Others" + ":" + txtOtherVerificationconductedat.Text.Trim();
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

            if (ddlApplMetat.SelectedItem.Text.Trim() == "Others")
                objCCVer.AppMetAt = "Others" + ":" + txtOtherApplMetat.Text.Trim();
            else
                objCCVer.AppMetAt = ddlApplMetat.SelectedItem.Text.Trim();

            objCCVer.NameOfCompany1 = txtNameofCompany.Text.Trim();
            objCCVer.PrevEmpDetail = txtPreviousEmploymentDetails.Text.Trim();
            objCCVer.OfficeReputation = ddlReputationOffice.SelectedItem.Text.Trim();
            objCCVer.OfficeAddress = txtOfficeAddress.Text.Trim();
            objCCVer.PinCode = txtPincode.Text.TrimEnd();
            ////add by kamal
            objCCVer.NeighbourReferance = ddlNeighbourReference.SelectedItem.Text.Trim();
            objCCVer.Email = txtEmail.Text.Trim();
            ///////end by kamal matekar

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

            objCCVer.NoOfYearsInPresentAdd = Convert.ToDecimal(txtNoOfYrsPresentAddress.Text.Trim()); //Added By Rupesh-SCB
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
            ////start by NIKHIL for femu
            objCCVer.AuthorizedSignatoryName = txtAuthorizedSignatoryName.Text.Trim();
            objCCVer.NeighSecurityCheck = txtNeighSecurityCheck.Text.Trim();
            objCCVer.ProductTypeDubai = ddlProductTypeDubai.SelectedValue.Trim();

            objCCVer.ClientTypeCITI = ddlClientTypeCITI.SelectedValue.Trim();
            objCCVer.SalaryConfirm = ddlSalaryConfirm.SelectedValue.Trim();
            objCCVer.PersonMetCooperative = ddlPersonMetCooperative.SelectedValue.Trim();
            objCCVer.EmpTypeDubai = ddlEmpTypeDubai.SelectedValue.Trim();
            objCCVer.CompanyTypeDubai = ddlCompanyTypeDubai.SelectedValue.Trim();

            objCCVer.MinSalaryRange = txtMinSalaryDubai.Text.Trim();
            objCCVer.MaxSalaryRange = txtMaxSalaryDubai.Text.Trim();

            //Start NIKHIL for Emirates NBD
            objCCVer.SisterOrGroupCompanyDetails = txtSisterOrGroupCompanyDetails.Text.Trim();
            objCCVer.ExternalAuditor = txtExternalAuditor.Text.Trim();
            objCCVer.AnnualRevenueAndProfit = txtAnnualRevenueAndProfit.Text.Trim();
            objCCVer.ProfitPercentage = txtProfitPercentage.Text.Trim();
            objCCVer.DocsCollectedDubai = txtDocsCollectedDubai.Text.Trim();
            objCCVer.OriginalSeenDubai = ddlOriginalSeenDubai.SelectedValue.Trim();
            //End Emirates NBD
            ////End by NIKHIL for femu

            ////start by kamal matekar for femu
            objCCVer.AddressApporch = txtAddressApporch.Text.Trim();
            objCCVer.IfAddressNotFound = txtIfAddressNotFound.Text.Trim();
            objCCVer.DoNeighbourNeighboringshopsorofficesknowthecustomer = ddlDoNeighbourNeighboringShopsOrOfficesKnowTheCustomer.SelectedItem.Text.Trim();
            objCCVer.BriefJobResponsibilities = txtBriefJobResponsibilities.Text.Trim();
            objCCVer.ReasonforApplicantNotMet = txtReasonForApplicantNotMet.Text.Trim();
            objCCVer.TypeOfOrganization = txtTypeOfOrganization.Text.Trim();
            objCCVer.IfOtherSpecify = txtIfOtherSpecify.Text.Trim();
            objCCVer.TypeOfOccupation = txtTypeOfOccupation.Text.Trim();
            objCCVer.Headofficebranch = txtHeadOfficebranch.Text.Trim();

            //////end by kamal matekar
            ///////////////////add by Mashrque bank(Santosh S)////////////////////////////

            //// Axis Merchant Added By Rupesh ////

            objCCVer.InfrastructureRemarks = txtInfrastructureRemarks.Text.Trim();
            objCCVer.NegativeMerchantInfo = ddlNgtvinfabtmerchant.SelectedValue.Trim();
            objCCVer.Recommendation = ddlRecommendation.SelectedValue.Trim();
            objCCVer.NameBoardType = ddlNameBoardType.SelectedValue.Trim();

            objCCVer.CurrntAddInfo = ddlCurrntAddInfo.SelectedValue.Trim();
            objCCVer.MerchantCategory = txtMerchantCategry.Text.Trim();
            objCCVer.ifbusactntseen = txtifbusactntseen.Text.Trim();


            //// Axis Merchant Added By Rupesh



            objCCVer.Emirates = txtEmirates.Text.Trim();
            objCCVer.PoboxNo = txtPoboxNo.Text.Trim();
            objCCVer.SignboardDoor = txtSignboardDoor.Text.Trim();
            objCCVer.ModeSalary = ddlModeSalary.SelectedValue.Trim();
            objCCVer.BusiTo = txtBusiTo.Text.Trim();
            objCCVer.CompClients = txtCompClients.Text.Trim();
            objCCVer.CompBank = txtCompBank.Text.Trim();
            objCCVer.Office1 = txtOffice1.Text.Trim();
            objCCVer.Office2 = txtOffice2.Text.Trim();
            objCCVer.Office3 = txtOffice3.Text.Trim();
            objCCVer.Office4 = txtOffice4.Text.Trim();
            objCCVer.DateJoin = txtDateJoin.Text.Trim();
            objCCVer.ApplicantReport = txtApplicantReport.Text.Trim();
            objCCVer.Desig = txtDesig.Text.Trim();
            objCCVer.ApplicantOwner = ddlApplicantOwner.SelectedItem.Text.Trim();
            objCCVer.YesRelation = txtYesRelation.Text.Trim();
            objCCVer.DetailsVerified = txtDetailsVerified.Text.Trim();
            objCCVer.LoanNumber = txtLoanNumber.Text.Trim();
            objCCVer.RefTelNumber = ddlRefTelNumber.SelectedItem.Text.Trim();
            objCCVer.RefCont = txtRefCont.Text.Trim();
            objCCVer.Area = txtArea.Text.Trim();
            objCCVer.Emirate1 = txtEmirate1.Text.Trim();
            objCCVer.LoanAppli = ddlLoanAppli.SelectedItem.Text.Trim();
            objCCVer.Location = txtLocation.Text.Trim();
            objCCVer.TypeOfLoan = txtTypeOfLoan.Text.Trim();
            /////////////////////////////End Code//////////////////////////////////////////                     
             //End Properties Assiging for City Bank (Dubai)
            
            ////--added by kamal matekar on 29th Mar 2010---------
            objCCVer.Sponser1Designation = txtSponsor1Designation.Text.Trim();
            objCCVer.Sponser2Designation = txtSponsor2Designation.Text.Trim();
            objCCVer.FavouritePlace = txtFavouritePlace.Text.Trim();
            objCCVer.ReferenceNoInUAE = txtReferenceNoInUAE.Text.Trim();
            objCCVer.AnyOtherBankCcFinancialfacility = txtAnyOtherBankCcFinancialfacility.Text.Trim();
            objCCVer.VehicalOwned = txtVehicalOwned.Text.Trim();
            objCCVer.VehicalFinanced = txtVehicalFinanced.Text.Trim();
            objCCVer.BreakUpNumberOfEmployeesWithDesignations = txtBreakUpOfNumberOfEmployeesWithDesignations.Text.Trim();
            objCCVer.IsOfficePremisesSharedAnyOtherOffice = txtIstheOfficePremisesSharedWithAnyOtherOffice.Text.Trim();
            //added by kamal matekar for femu...Mashreq Bank..........
     
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
            objCCVer.Reason = ddlCityLimit.SelectedValue.ToString();

            objCCVer.NameEmp = txtNameEmp.Text.Trim();
            objCCVer.ResiBuss = txtResiBuss.Text.Trim();
            objCCVer.DateTimeVisit = txtDateTimeVisit.Text.Trim();
            objCCVer.Visit = txtVisit.Text.Trim();
            objCCVer.AddUpd = txtAddUpd.Text.Trim();
            objCCVer.DocVeri = txtDocVeri.Text.Trim();
            objCCVer.VisitProofDet = txtVisitProofDet.Text.Trim();

            objCCVer.AddTrace = txtAddTrace.Text.Trim();
            objCCVer.SpokeTo = txtSpokeTo.Text.Trim();
            objCCVer.AddRec = txtAddRec.Text.Trim();
            objCCVer.AddDiff = txtAddDiff.Text.Trim();

            objCCVer.EmploymentConfirmed = ddlEmploymentConf.SelectedItem.Text.Trim();
            objCCVer.ApplicationConfirmation = ddlApplicantConfirmation.SelectedItem.Text.ToString();
            objCCVer.SBItpc1 = ddlSBItpc1.SelectedItem.Text.Trim();
            objCCVer.SBItpc2 = ddlSBItpc2.SelectedItem.Text.Trim();

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
                    arrAttempt1.Add(ddlSubSat1.SelectedValue.ToString());  
                    arrAttempt.Add(arrAttempt1);
                }

                if (txtAttemptDate2.Text.Trim() != "" && txtAttemptTime2.Text.Trim() != "")
                {
                    arrAttempt2.Clear();
                    arrAttempt2.Add(objCmn.strDate(txtAttemptDate2.Text.Trim()) + " " + txtAttemptTime2.Text.Trim() + " " + ddlAttemptTimeType2.SelectedItem.Text.Trim());
                    arrAttempt2.Add(txtAttemptRemark2.Text.Trim());
                    arrAttempt2.Add(ddlSubSat2.SelectedValue.ToString());
                    arrAttempt.Add(arrAttempt2);
                }

                if (txtAttemptDate3.Text.Trim() != "" && txtAttemptTime3.Text.Trim() != "")
                {
                    arrAttempt3.Clear();
                    arrAttempt3.Add(objCmn.strDate(txtAttemptDate3.Text.Trim()) + " " + txtAttemptTime3.Text.Trim() + " " + ddlAttemptTimeType3.SelectedItem.Text.Trim());
                    arrAttempt3.Add(txtAttemptRemark3.Text.Trim());
                    arrAttempt3.Add(ddlSubSat3.SelectedValue.ToString());
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

                //-----added by kamal matekar----for SCB bank
                objCCVer.VisitingCard = ddlVisitingCard.SelectedValue.ToString();
                objCCVer.BusinessOwnership = ddlBusinessOwnership.SelectedValue.ToString();
                objCCVer.SeparateOfficeArea = ddlSeparateOfficeArea.SelectedValue.ToString();
                objCCVer.CommentOnBusinessActivity = txtCommentOnBusinessActivity.Text.Trim();


                //Added by Manoj for Axis bank Change address

                objCCVer.Applicantfound = ddlApplicantfound.SelectedValue.ToString();
                objCCVer.Applicantdefaulted = txtApplicantdefaulted.Text.Trim();
                objCCVer.Productdefault = txtProductdefault.Text.Trim();
                objCCVer.dateofdefault = txtdateofdefault.Text.Trim();
                objCCVer.amountofdefault = txtamountofdefault.Text.Trim();
                objCCVer.Iscompanynegative = ddlIscompanynegative.SelectedValue.ToString();
                objCCVer.Isdesignationnagative = ddlIsdesignationnagative.SelectedValue.ToString();
                objCCVer.Isfloorseparateresidence = ddlfloorseparateresidence.SelectedValue.ToString();
                objCCVer.Isroomseparateresidence = ddlroomseparateresidence.SelectedValue.ToString();
                objCCVer.Isentranceresidence = ddlentrancetoresidence.SelectedValue.ToString();
                objCCVer.Addressvisited = ddlAddressvisted.SelectedValue.ToString();
                objCCVer.OtherAddress = txtOtheraddressobtained.Text.Trim();
                //objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();
                if (ddlVisitProof.SelectedItem.Text.Trim() == "Others")
                    objCCVer.VisitProof = "Others" + ":" + txtOtherVisitProof.Text.Trim();
                else
                    objCCVer.VisitProof = ddlVisitProof.SelectedItem.Text.Trim();
                //Added by Manoj for HDFC Merchant
                objCCVer.Tradingname = txttradingname.Text.Trim();
                objCCVer.Noofyearrelationship = txtNoofyearrelationship.Text.Trim();
                objCCVer.NoOfEDCinshop = txtNoOfEDCinshop.Text.Trim();
                objCCVer.NoOfpersonhandlingEDCmachine = txtNoOfpersonhandlingEDCmachine.Text.Trim();
                objCCVer.MCCType = txtMCCType.Text.Trim();
                objCCVer.Cardetalis = txtCardetalis.Text.Trim();
                objCCVer.cardlimit = txtcardlimit.Text.Trim();
                objCCVer.Marketinformationchangebackhistroy = txtMarketinformationchangebackhistroy.Text.Trim();
                objCCVer.HDFCBankcreditcard = ddlHDFCBankcreditcard.SelectedValue.ToString();
                objCCVer.Knowledgelevalofstaff = ddlKnowledgelevalofstaff.SelectedValue.ToString();
                objCCVer.partofchain = ddlpartofchain.SelectedValue.ToString();
                objCCVer.Acceptingcard = ddlAcceptingcard.SelectedValue.ToString();
                objCCVer.TypeOfcard = ddlTypeOfcard.SelectedValue.ToString();
                //Ended by Manoj for HDFC Merchant
                //Added by Manoj for First Gulf Bank
                objCCVer.BuildingStatus = txtBuildingStatus.Text.Trim();
                objCCVer.Legalstructureofbusiness = txtLegalstructureofbusiness.Text.Trim();
                objCCVer.Relatedpartyinfo = txtRelatedpartyinfo.Text.Trim();
                objCCVer.Nameofpersonwhoactivelymanages = txtNameofpersonwhoactivelymanages.Text.Trim();
                objCCVer.Currentactivepartnerinvolvement = txtCurrentactivepartnerinvolvement.Text.Trim();
                objCCVer.Dateofbusincorporation = txtDateofbusincorporation.Text.Trim();
                objCCVer.Loanamountapplied = txtLoanamountapplied.Text.Trim();
                objCCVer.Loantenor = txtLoantenor.Text.Trim();
                objCCVer.Enduseoffunds = txtEnduseoffunds.Text.Trim();
                objCCVer.INTERVIEWERCONCERNS = txtINTERVIEWERCONCERNS.Text.Trim();
                objCCVer.INTERVIEWERMITIGANTS = txtINTERVIEWERMITIGANTS.Text.Trim();
                objCCVer.Businesssupplier = txtBusinesssupplier.Text.Trim();
                objCCVer.Suppliercompanyname = txtSuppliercompanyname.Text.Trim();
                objCCVer.Suplierlandline = txtSuplierlandline.Text.Trim();
                objCCVer.supplierremarks = txtsupplierremarks.Text.Trim();
                objCCVer.Businesscustomername = txtBusinesscustomername.Text.Trim();
                objCCVer.Cutomercompanyname = txtCutomercompanyname.Text.Trim();
                objCCVer.Customermobile = txtCustomermobile.Text.Trim();
                objCCVer.CustomerRemark = txtCustomerRemark.Text.Trim();
                objCCVer.Purchasesaveragepurchaseterms = txtPurchasesaveragepurchaseterms.Text.Trim();
                objCCVer.PurchaseLocal = txtPurchaseLocal.Text.Trim();
                objCCVer.PurchaseImport = txtPurchaseImport.Text.Trim();
                objCCVer.Countriesimportedfrom = txtCountriesimportedfrom.Text.Trim();
                objCCVer.TotalNoOfsupplier = txtTotalNoOfsupplier.Text.Trim();
                objCCVer.NoOfactivesuppliers = txtNoOfactivesuppliers.Text.Trim();
                objCCVer.Namesofkeysuppliers = txtNamesofkeysuppliers.Text.Trim();
                objCCVer.Averagesalesterms = txtAveragesalesterms.Text.Trim();
                objCCVer.LocalTransport = txtLocalTransport.Text.Trim();
                objCCVer.OtherCountriesPercentage = txtOtherCountriesPercentage.Text.Trim();
                objCCVer.OtherCountries = txtOtherCountries.Text.Trim();
                objCCVer.TotalNoofcustomers = txtTotalNoofcustomers.Text.Trim();
                objCCVer.NoofActivecustomers = txtNoofActivecustomers.Text.Trim();
                objCCVer.Namesofkeycustomers = txtNamesofkeycustomers.Text.Trim();
                objCCVer.CreditRemarksPostFieldVisit = txtCreditRemarksPostFieldVisit.Text.Trim();

                //Added by Manoj Jadhav for FGB_SME
                objCCVer.Sellingcash = txtcash.Text.Trim();
                objCCVer.Sellingcredit = txtCredit.Text.Trim();
                objCCVer.Sellingcreditperiod = txtCreditperiod.Text.Trim();

                objCCVer.Buyingcash = txtBuyingcash.Text.Trim();
                objCCVer.Buyingcredit = txtBuyingCredit.Text;
                objCCVer.Buyingcreditperiod = txtBuyCreditperiod.Text.Trim();

                objCCVer.Keyindicators1 = txtKeyindicators1.Text.Trim();
                objCCVer.Keyindicators2 = txtKeyindicators2.Text.Trim();
                objCCVer.Keyindicators3 = txtKeyindicators3.Text.Trim();

                objCCVer.AnnualTurnover1 = txtAnnualTurnover1.Text.Trim();
                objCCVer.AnnualTurnover2 = txtAnnualTurnover2.Text.Trim();
                objCCVer.AnnualTurnover3 = txtAnnualTurnover3.Text.Trim();

                objCCVer.ProfitMargin1 = txtProfitMargin1.Text.Trim();
                objCCVer.ProfitMargin2 = txtProfitMargin2.Text.Trim();
                objCCVer.ProfitMargin3 = txtProfitMargin3.Text.Trim();

                objCCVer.CapitalInvest1 = txtCapitalInvest1.Text.Trim();
                objCCVer.CapitalInvest2 = txtCapitalInvest2.Text.Trim();
                objCCVer.CapitalInvest3 = txtCapitalInvest3.Text.Trim();

                objCCVer.FacilityType = txtFacilityType.Text.Trim();
                objCCVer.bankName = txtbankName.Text.Trim();
                objCCVer.Facilityamount = txtFacilityamount.Text.Trim();
                objCCVer.BankSecurity = txtSecurity.Text.Trim();
                objCCVer.EMI = txtEMI.Text.Trim();

                objCCVer.Queries = txtQueries.Text.Trim();
                objCCVer.Clarification = txtClarification.Text.Trim();


                //Ended by Manoj Jadhav  for FGB_SME
                //added by abhijeet//
           
                //ended by abhijeet//

                //added by abhijeet for axis bank//
                objCCVer.Doccumentname1 = txtdocname1.Text.Trim();
                objCCVer.Doccumentname2 = txtdocname2.Text.Trim();
                objCCVer.Doccumentname3 = txtdocname3.Text.Trim();


                objCCVer.Fru_Observation1 = Txtobs1.Text.Trim();
                objCCVer.Fru_Observation2 = Txtobs2.Text.Trim();
                objCCVer.Fru_Observation3 = Txtobs3.Text.Trim();


                objCCVer.Setupcompany = Txtsetup.Text.Trim();
                objCCVer.Negmarketinfo = Txtnegmarinfo.Text.Trim();
                objCCVer.Antisoc = Txtantisoc.Text.Trim();



                objCCVer.RACName = txtracname.Text.Trim();
                objCCVer.DSACode = txtdsacode.Text.Trim();
                objCCVer.FileNo = txtfileno.Text.Trim();


                objCCVer.SalesManagerCode = txtsalesmanagercode.Text.Trim();
                objCCVer.FcuLocation = txtfculocation.Text.Trim();
                objCCVer.Product = txtproduct.Text.Trim();


                objCCVer.DSECode = txtdsecode.Text.Trim();
                objCCVer.Pickupprofile = txtpickupprofile.Text.Trim();




                objCCVer.samplername = txtsamplername.Text.Trim();
                objCCVer.AgencyRemark = txtagencyremark.Text.Trim();


                objCCVer.pickupdate = txtpickupdate.Text.Trim();
                objCCVer.Reportdate = txtreportdate.Text.Trim();
                objCCVer.emptypesubtype = ddlemptypesubtype.SelectedValue.Trim();

                if (ddlAreaname.SelectedValue.ToString() == "0")
                {
                    objCCVer.AreaID = txtAreapincode.Text.Trim();
                }
                else
                {
                    objCCVer.AreaID = ddlAreaname.SelectedValue.ToString();
                }

                // Added By Rupesh
                objCCVer.Supervisor_ID = ddlSupervisorName.SelectedValue;


                objCCVer.FileUpload1 = null;
                objCCVer.FileUpload2 = null;
                objCCVer.FileUpload3 = null;
                objCCVer.FileUpload4 = null;
                objCCVer.FileUpload5 = null;

                Array newFileUpload1 = null;
                if (FileUpload1.FileBytes.Length > 0)
                {
                    newFileUpload1=FileUpload1.FileBytes;
                }
                objCCVer.FileUpload1 = newFileUpload1;

                Array newFileUpload2 = null;
                if (FileUpload2.FileBytes.Length > 0)
                {
                    newFileUpload2 = FileUpload2.FileBytes;
                }
                objCCVer.FileUpload2 = newFileUpload2;

                Array newFileUpload3 = null;
                if (FileUpload3.FileBytes.Length > 0)
                {
                    newFileUpload3 = FileUpload3.FileBytes;
                }
                objCCVer.FileUpload3 = newFileUpload3;

                Array newFileUpload4 = null;
                if (FileUpload4.FileBytes.Length > 0)
                {
                    newFileUpload4 = FileUpload4.FileBytes;
                }
                objCCVer.FileUpload4 = newFileUpload4;

                Array newFileUpload5 = null;
                if (FileUpload5.FileBytes.Length > 0)
                {
                    newFileUpload5 = FileUpload5.FileBytes;
                }
                objCCVer.FileUpload5 = newFileUpload5;

         

 
                //}
                //sMsg = objCCVer.InsertUpdateCCBusiVerificationEntry(arrAttempt);
                sMsg = objCCVer.InsertUpdateCCBusiVerificationEntry(arrAttempt);
                InsertQueryelement();
                //InsertUpdateCCBusiVerificationEntry
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
    private void InsertQueryelement()
    {
        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1st = new ArrayList();
            ArrayList arrLog2nd = new ArrayList();
            ArrayList arrLog3rd = new ArrayList();
            ArrayList arrLog4th = new ArrayList();
            ArrayList arrLog5th = new ArrayList();
            ArrayList arrLog6th = new ArrayList();
            ArrayList arrLog7th = new ArrayList();
            ArrayList arrLog8th = new ArrayList();
            ArrayList arrLog9th = new ArrayList();
            ArrayList arrLog10th = new ArrayList();

            string strCaseID = Request.QueryString["CaseID"].ToString();
            objCC.CaseId = strCaseID;

            if (txtQueries.Text.Trim() != "" || txtClarification.Text.Trim() != "")
            {
                arrLog1st.Add(txtQueries.Text.Trim());
                arrLog1st.Add(txtClarification.Text.Trim());
                arrTeleCallLog.Add(arrLog1st);
            }
            if (txtQueries1.Text.Trim() != "" || txtClarification1.Text.Trim() != "")
            {
                arrLog2nd.Add(txtQueries1.Text.Trim());
                arrLog2nd.Add(txtClarification1.Text.Trim());
                arrTeleCallLog.Add(arrLog2nd);
            }
            if (txtQueries2.Text.Trim() != "" || txtClarification2.Text.Trim() != "")
            {
                arrLog3rd.Add(txtQueries2.Text.Trim());
                arrLog3rd.Add(txtClarification2.Text.Trim());
                arrTeleCallLog.Add(arrLog3rd);
            }
            if (txtQueries3.Text.Trim() != "" || txtClarification3.Text.Trim() != "")
            {
                arrLog4th.Add(txtQueries3.Text.Trim());
                arrLog4th.Add(txtClarification3.Text.Trim());
                arrTeleCallLog.Add(arrLog4th);
            }
            if (txtQueries4.Text.Trim() != "" || txtClarification4.Text.Trim() != "")
            {
                arrLog5th.Add(txtQueries4.Text.Trim());
                arrLog5th.Add(txtClarification4.Text.Trim());
                arrTeleCallLog.Add(arrLog5th);
            }
            if (txtQueries5.Text.Trim() != "" || txtClarification5.Text.Trim() != "")
            {
                arrLog6th.Add(txtQueries5.Text.Trim());
                arrLog6th.Add(txtClarification5.Text.Trim());
                arrTeleCallLog.Add(arrLog6th);
            }
            if (txtQueries6.Text.Trim() != "" || txtClarification6.Text.Trim() != "")
            {
                arrLog7th.Add(txtQueries6.Text.Trim());
                arrLog7th.Add(txtClarification6.Text.Trim());
                arrTeleCallLog.Add(arrLog7th);
            }
            if (txtQueries7.Text.Trim() != "" || txtClarification7.Text.Trim() != "")
            {
                arrLog8th.Add(txtQueries7.Text.Trim());
                arrLog8th.Add(txtClarification7.Text.Trim());
                arrTeleCallLog.Add(arrLog8th);
            }
            if (txtQueries8.Text.Trim() != "" || txtClarification8.Text.Trim() != "")
            {
                arrLog9th.Add(txtQueries8.Text.Trim());
                arrLog9th.Add(txtClarification8.Text.Trim());
                arrTeleCallLog.Add(arrLog9th);
            }
            if (txtQueries9.Text.Trim() != "" || txtClarification9.Text.Trim() != "")
            {
                arrLog10th.Add(txtQueries9.Text.Trim());
                arrLog10th.Add(txtClarification9.Text.Trim());
                arrTeleCallLog.Add(arrLog10th);
            }
            if (objCCVer.InsertOueryCallLog(arrTeleCallLog) == 1)
            {


            }
        }
        catch (Exception ex)
        {

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
        txtTypeOfLoan.Enabled = false;  

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
        ddlLocalityOfficeDubai.Enabled = false;
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

        //SCB Start
        txtreasonrecommended.Enabled = false;
        DdlVerification.Enabled = false;
        ddlOfficersDecision.Enabled = false;
        DdlCityLimitYN.Enabled = false;
        txtOfficeOutsidethenarea.Enabled = false;
        txtApplicantReport.Enabled = false;
        txtNeighbourFeedback.Enabled = false;
        txtTotalYears.Enabled = false;

        //SCb End


        //start for ENBD Dubai//

        txtregdetails1.Enabled = false;
        txtregdetails2.Enabled = false;
        txtregdetails3.Enabled = false;
        txtregdetails4.Enabled = false;
        txtregdetails5.Enabled = false;
        txtregdetails6.Enabled = false;
        Txtphysicaldetails1.Enabled = false;
        Txtphysicaldetails2.Enabled = false;
        Txtphysicaldetails3.Enabled = false;
        Txtphysicaldetails4.Enabled = false;
        Txtphysicaldetails5.Enabled = false;
        Txtphysicaldetails6.Enabled = false;
        Txtinternationaldetails1.Enabled = false;
        Txtinternationaldetails2.Enabled = false;
        Txtinternationaldetails3.Enabled = false;
        Txtinternationaldetails4.Enabled = false;
        Txtinternationaldetails5.Enabled = false;
        Txtinternationaldetails6.Enabled = false;
        TxtregisteredBusinessoffice1.Enabled = false;
        TxtregisteredBusinessoffice2.Enabled = false;
        TxtregisteredBusinessoffice3.Enabled = false;
        TxtregisteredBusinessoffice4.Enabled = false;
        TxtothersBussinessdetails1.Enabled = false;
        TxtothersBussinessdetails2.Enabled = false;
        TxtothersBussinessdetails3.Enabled = false;
        TxtothersBussinessdetails4.Enabled = false;
        Txtmob1.Enabled = false;
        Txtmob2.Enabled = false;
        Txtmob3.Enabled = false;
        Txtmob4.Enabled = false;
        Txtclient1.Enabled = false;
        Txtclient2.Enabled = false;
        Txtclient3.Enabled = false;
        Txtclient4.Enabled = false;
        Txtownership11.Enabled = false;
        Txtownership12.Enabled = false;
        Txtownership13.Enabled = false;
        Txtownership14.Enabled = false;
        Txtnationality1.Enabled = false;
        Txtnationality2.Enabled = false;
        Txtnationality3.Enabled = false;
        Txtnationality4.Enabled = false;
        ddlInvolvedInBussiness1.Enabled = false;
        ddlInvolvedInBussiness2.Enabled = false;
        ddlInvolvedInBussiness3.Enabled = false;
        ddlInvolvedInBussiness4.Enabled = false;
        txtDteailremark1.Enabled = false;
        txtDteailremark2.Enabled = false;
        txtDteailremark3.Enabled = false;
        txtDteailremark4.Enabled = false;
        TxtRegistration1.Enabled = false;
        TxtExpiryDate.Enabled = false;
        TxtLineofBussiness.Enabled = false;
        TxtIssuingAuthority.Enabled = false;
        TxtTypeofProduct1.Enabled = false;
        TxtTypeofProduct2.Enabled = false;
        TxtTypeofProduct3.Enabled = false;
        TxtTypeofProduct4.Enabled = false;
        TxtTypeofProduct5.Enabled = false;
        TxttotalPOSPrevious1.Enabled = false;
        TxttotalPOSPrevious2.Enabled = false;
        TxttotalPOSCurrent1.Enabled = false;
        TxttotalPOSCurrent2.Enabled = false;
        TxtDirectorName1.Enabled = false;
        TxtDirectorName2.Enabled = false;
        TxtDirectorName3.Enabled = false;
        TxtDirectorName4.Enabled = false;
        TxtDirectorAdd1.Enabled = false;
        TxtDirectorAdd2.Enabled = false;
        TxtDirectorAdd3.Enabled = false;
        TxtDirectorAdd4.Enabled = false;
        TxtDirectorpermntAdd1.Enabled = false;
        TxtDirectorpermntAdd2.Enabled = false;
        TxtDirectorpermntAdd3.Enabled = false;
        TxtDirectorpermntAdd4.Enabled = false;
        ddlDirectorGender1.Enabled = false;
        ddlDirectorGender2.Enabled = false;
        ddlDirectorGender3.Enabled = false;
        ddlDirectorGender4.Enabled = false;
        TxtDirectorDOB1.Enabled = false;
        TxtDirectorDOB2.Enabled = false;
        TxtDirectorDOB3.Enabled = false;
        TxtDirectorDOB4.Enabled = false;
        Txteducation1.Enabled = false;
        Txteducation2.Enabled = false;
        Txteducation3.Enabled = false;
        Txteducation4.Enabled = false;
        Txtphone1.Enabled = false;
        Txtphone2.Enabled = false;
        Txtphone3.Enabled = false;
        Txtphone4.Enabled = false;
        TxtMobile1.Enabled = false;
        TxtMobile2.Enabled = false;
        TxtMobile3.Enabled = false;
        TxtMobile4.Enabled = false;
        TxtPrimaryContact.Enabled = false;
        TxtPrimaryContactDegignation.Enabled = false;
        TxtContactDetails1.Enabled = false;
        TxtContactDetails2.Enabled = false;






        //End For ENBD Dubai //


        //added by abhijeet for ENBDSME//
        ddlphysicaladdress.Enabled = false;
        txtreasonsOfmailing.Enabled = false;
        txtnatureofbussinessactivityobserved.Enabled = false;


        //Ended By abhijeet for ENBDSME//












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
        ddlLocalityOfficeDubai.Enabled = false;
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
        ddlCityLimit.Enabled = false;  

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

        txtAddTrace.Enabled = false;
        txtSpokeTo.Enabled = false;
        txtAddRec.Enabled = false;
        txtAddDiff.Enabled = false;

        ddlApplicantConfirmation.Enabled = false;
        ddlEmploymentConf.Enabled = false;
        ddlSBItpc1.Enabled = false;
        ddlSBItpc2.Enabled = false;

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

        //nikhil femu start
            txtNeighSecurityCheck.Enabled = false;
            txtAuthorizedSignatoryName.Enabled = false;
            ddlProductTypeDubai.Enabled = false;
            ddlEmpTypeDubai.Enabled = false;
            ddlSalaryConfirm.Enabled = false;
            ddlClientTypeCITI.Enabled = false;
            ddlPersonMetCooperative.Enabled = false;
            ddlCompanyTypeDubai.Enabled = false;
            txtMinSalaryDubai.Enabled = false;
            txtMaxSalaryDubai.Enabled = false;

        //NBD start
            txtDocsCollectedDubai.Enabled = false;
            txtExternalAuditor.Enabled = false;
            txtProfitPercentage.Enabled = false;
            txtSisterOrGroupCompanyDetails.Enabled = false;
            txtAnnualRevenueAndProfit.Enabled = false;
            ddlOriginalSeenDubai.Enabled = false;
        //NBD End
        //nikhil femu end

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

        txtNameEmp.Enabled = false;
        txtResiBuss.Enabled = false;
        txtDateTimeVisit.Enabled = false;
        txtVisit.Enabled = false;
        txtAddUpd.Enabled = false;
        txtDocVeri.Enabled = false;
        txtVisitProofDet.Enabled = false;

        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;


        //Axis Merxhant Added By Rupesh

        ddlNameBoardType.Enabled = false;
        ddlRecommendation.Enabled = false;
        ddlNgtvinfabtmerchant.Enabled = false;
        txtInfrastructureRemarks.Enabled = false;

        ddlCurrntAddInfo.Enabled = false;
        txtMerchantCategry.Enabled = false;
        txtifbusactntseen.Enabled = false;

        //Axis Merxhant Added By Rupesh


        txtEmirates.Enabled = false;
        txtPoboxNo.Enabled = false;
        txtSignboardDoor.Enabled = false;
        ddlModeSalary.Enabled = false;
        txtBusiTo.Enabled = false;
        txtCompClients.Enabled = false;
        txtCompBank.Enabled = false;
        txtOffice1.Enabled = false;
        txtOffice2.Enabled = false;
        txtOffice3.Enabled = false;
        txtOffice4.Enabled = false;
        txtDateJoin.Enabled = false;
        txtApplicantReport.Enabled = false;
        txtDesig.Enabled = false;
        ddlApplicantOwner.Enabled = false; 
        txtYesRelation.Enabled = false;
        txtDetailsVerified.Enabled = false;
        txtLoanNumber.Enabled = false;
        ddlRefTelNumber.Enabled = false; 
        txtRefCont.Enabled = false;
        txtArea.Enabled = false;
        txtEmirate1.Enabled = false;
        ddlLoanAppli.Enabled = false;
        txtLocation.Enabled = false;
        //Added by Manoj for Axis bank Auto loan
        ddlApplicantfound.Enabled = false;
        txtApplicantdefaulted.Enabled = false;
        txtProductdefault.Enabled = false;
        txtamountofdefault.Enabled = false;
        ddlIscompanynegative.Enabled = false;
        ddlIsdesignationnagative.Enabled = false;
        ddlfloorseparateresidence.Enabled = false;
        ddlroomseparateresidence.Enabled = false;
        ddlentrancetoresidence.Enabled = false;
        ddlAddressvisted.Enabled = false;
        txtOtheraddress.Enabled = false;
        txtOtheraddressobtained.Enabled = false;
        txtdateofdefault.Enabled = false;
        txttradingname.Enabled = false;
        txtNoofyearrelationship.Enabled = false;
        txtNoOfEDCinshop.Enabled = false;
        txtNoOfpersonhandlingEDCmachine.Enabled = false;
        txtMCCType.Enabled = false;
        txtCardetalis.Enabled = false;
        txtcardlimit.Enabled = false;
        txtMarketinformationchangebackhistroy.Enabled = false;
        ddlKnowledgelevalofstaff.Enabled = false;
        ddlpartofchain.Enabled = false;
        ddlAcceptingcard.Enabled = false;
        ddlTypeOfcard.Enabled = false;
        ddlHDFCBankcreditcard.Enabled = false;
        //Added by Manoj for First Gulf Bank
        txtBuildingStatus.Enabled = false;
        txtLegalstructureofbusiness.Enabled = false;
        txtRelatedpartyinfo.Enabled = false;
        txtNameofpersonwhoactivelymanages.Enabled = false;
        txtCurrentactivepartnerinvolvement.Enabled = false;
        txtDateofbusincorporation.Enabled = false;
        txtLoanamountapplied.Enabled = false;
        txtLoantenor.Enabled = false;
        txtEnduseoffunds.Enabled = false;
        txtINTERVIEWERCONCERNS.Enabled = false;
        txtINTERVIEWERMITIGANTS.Enabled = false;
        txtBusinesssupplier.Enabled = false;
        txtSuppliercompanyname.Enabled = false;
        txtSuplierlandline.Enabled = false;
        txtsupplierremarks.Enabled = false;
        txtBusinesscustomername.Enabled = false;
        txtCutomercompanyname.Enabled = false;
        txtCustomermobile.Enabled = false;
        txtCustomerRemark.Enabled = false;
        txtPurchasesaveragepurchaseterms.Enabled = false;
        txtPurchaseLocal.Enabled = false;
        txtPurchaseImport.Enabled = false;
        txtCountriesimportedfrom.Enabled = false;
        txtTotalNoOfsupplier.Enabled = false;
        txtNoOfactivesuppliers.Enabled = false;
        txtNamesofkeysuppliers.Enabled = false;
        txtAveragesalesterms.Enabled = false;
        txtLocalTransport.Enabled = false;
        txtOtherCountriesPercentage.Enabled = false;
        txtOtherCountries.Enabled = false;
        txtTotalNoofcustomers.Enabled = false;
        txtNoofActivecustomers.Enabled = false;
        txtNamesofkeycustomers.Enabled = false;
        txtCreditRemarksPostFieldVisit.Enabled = false;

        //added by rupesh   
        
        ddlSupervisorName.Enabled = false;
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

    #region Below Function is Created for Getting Employee Status i.e. salaried or self :Created by Avinash Wankhede Date 2009 June 17
    private void Get_IsSalaried_SelfEmployed_Status(string pCaseId)
    {
        try
        {


            //sqlconnection sqlcon = new sqlconnection(ConfigurationManager.AppSettings["constring"]);
            CCommon objConn = new CCommon();SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString); //Sir

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = "Select Occupation from Cpv_CC_Case_Details Where Case_Id=@CaseId";
            sqlCom.CommandTimeout = 0;

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.ParameterName = "@CaseId";
            CaseId.Value = pCaseId;//1013;
            sqlCom.Parameters.Add(CaseId);

            Hdn_OccupationType.Value = sqlCom.ExecuteScalar().ToString();

            sqlcon.Close();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }


    }

    #endregion
}
