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

public partial class CPV_KYC_KYC_BUSINESS_VERI : System.Web.UI.Page
{
    string verificationType = "BV";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }
    CKYCVerification objKYC = new CKYCVerification();

    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsFE.ConnectionString = objConn.ConnectionString;  //Sir

        if (Session["ClientId"].ToString() == "101160")
        {        
             lblTeleRemark.Text = "Special Remark";
        }
       
        if (!IsPostBack)
        {
            //To Show the Panels add By Manoj            
            //funShowPanel();
            //End 
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerTypeId"] != null && Context.Request.QueryString["VerTypeId"] != "")
            {
                //if (Session["isEdit"].ToString() != "1")
                //    ISEditFalse();
                txtPersonContacted.Focus();

                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                hidVerificationTypeID.Value = Request.QueryString["VerTypeId"].ToString();
                Session["CaseID"] = Request.QueryString["CaseID"].ToString();
                if ((Request.QueryString["Mode"] != null) && (Request.QueryString["Mode"] != ""))
                {
                    hidMode.Value = Request.QueryString["Mode"].ToString();
                }
                if ((Request.QueryString["VerificationTypeCode"] != null) && (Request.QueryString["VerificationTypeCode"] != ""))
                {
                    hidVerificationTypeCode.Value = Request.QueryString["VerificationTypeCode"].ToString();
                }
                OleDbDataReader oledbReadKYC;
                OleDbDataReader oledbCaseDtl;
                //oledbReadKYC = objKYC.GetBVDetail(sCaseId, sVerifyTypeId);
                oledbCaseDtl = objKYC.GetCASEDetail(hidCaseID.Value, hidVerificationTypeID.Value);

                if (oledbCaseDtl.Read() == true)
                {
                    txtRefNo.Text = oledbCaseDtl["REF_NO"].ToString();
                    txtInitiationDate.Text = oledbCaseDtl["CASE_REC_DATETIME"].ToString();
                    txtAppName.Text = oledbCaseDtl["NAME"].ToString();
                    

                    if (!(oledbCaseDtl["CASE_STATUS_ID"].ToString().Trim().Length.Equals(0)))
                        ddlStatus.SelectedValue = oledbCaseDtl["CASE_STATUS_ID"].ToString();
                }

               

                txtDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDate3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FillStatus();
                GetCaseDetail();
                GetCaseDetail1();
                GetKYCVerificationEntry();
                GetTeleCallLog();
                GetVerifierName();
                ////added by kamal matekar----
                GetKYCVerificationDetails();
                ////end
                if (hidMode.Value == "View")
                {
                    ReadOnly();
                    LikButtonVisibility();


                }


            }
        }
    }

    //added by kamal matekar...............
    private void GetKYCVerificationDetails()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseVerificationDetail(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {

            if (!(oledbDR["Type_Org"].ToString().Trim().Length.Equals(0)))
                ddlConstitution.SelectedValue = oledbDR["Type_Org"].ToString();

            if (!(oledbDR["Card_No"].ToString().Trim().Length.Equals(0)))
                ddlWhetherVisitingCardobtained.SelectedValue = oledbDR["Card_No"].ToString();

            if (!(oledbDR["Buss_Proof_Seen"].ToString().Trim().Length.Equals(0)))
                txtReasonfornothavingavalidBusinessproof.Text = oledbDR["Buss_Proof_Seen"].ToString();

            if (!(oledbDR["Locality_Type"].ToString().Trim().Length.Equals(0)))
                ddlLocalityType.SelectedValue = oledbDR["Locality_Type"].ToString();

            if (!(oledbDR["EquipmentSeen_OR_Shift_Arrangement"].ToString().Trim().Length.Equals(0)))
                txtfurniture.Text = oledbDR["EquipmentSeen_OR_Shift_Arrangement"].ToString();

            string sObserStatus = oledbDR["Observation_If_NotRecommended"].ToString();
            if (sObserStatus.Trim() != "")
            {
                string[] arrObserStatus = sObserStatus.Split(':');
                if (arrObserStatus.Length > 0)
                {
                    if (arrObserStatus[0].ToString() == "Others" && arrObserStatus.Length > 1)
                    {
                        ddlIfNotRecommended.SelectedValue = "Others";
                        txtIfOtherRecommended.Text = arrObserStatus[1].ToString();
                    }
                    else
                    {
                        ddlIfNotRecommended.SelectedValue = arrObserStatus[0].ToString();
                    }
                }
            }
                      

            if (!(oledbDR["Neigh_Shop"].ToString().Trim().Length.Equals(0)))
                ddlDoNeighbourShopsKnowTheCustomer.SelectedValue = oledbDR["Neigh_Shop"].ToString();

            if (!(oledbDR["Address_Neighbour"].ToString().Trim().Length.Equals(0)))
                txtAddressOfNeighbour.Text = oledbDR["Address_Neighbour"].ToString();


            if (!(oledbDR["Buss_Quip_Sight"].ToString().Trim().Length.Equals(0)))
            {
                string sBusinessEquipSightedfemu = oledbDR["Buss_Quip_Sight"].ToString();
                string[] arrBusinessEquipSightedfemu = sBusinessEquipSightedfemu.Split(',');
                int iOthersBusinessEquipSightedCtrfemu = 0;
                if (arrBusinessEquipSightedfemu.Length > 0)
                {
                    for (int i = 0; i < arrBusinessEquipSightedfemu.Length; i++)
                    {
                        foreach (ListItem li in chkOfficeEquipmentSeen.Items)
                        {
                            if (li.Value == arrBusinessEquipSightedfemu.GetValue(i).ToString())
                                li.Selected = true;
                            if (arrBusinessEquipSightedfemu.GetValue(i).ToString() == "Others")
                            {
                                iOthersBusinessEquipSightedCtrfemu = i;
                            }
                        }
                    }
                }
                for (int j = iOthersBusinessEquipSightedCtrfemu + 1; j < arrBusinessEquipSightedfemu.Length; j++)
                {
                    txtOfficeEquipmentSeenOther.Text += arrBusinessEquipSightedfemu.GetValue(j) + ",";
                }
            }

            if (!(oledbDR["TrigSVR"].ToString().Trim().Length.Equals(0)))
                ddlTrigSVR.SelectedValue = oledbDR["TrigSVR"].ToString();

            if (!(oledbDR["BranchName"].ToString().Trim().Length.Equals(0)))
                txtBranchName.Text = oledbDR["BranchName"].ToString();

            if (!(oledbDR["BranchCode"].ToString().Trim().Length.Equals(0)))
                txtBranchCode.Text = oledbDR["BranchCode"].ToString();

            if (!(oledbDR["RmName"].ToString().Trim().Length.Equals(0)))
                txtRmName.Text = oledbDR["RmName"].ToString();

            if (!(oledbDR["RmCode"].ToString().Trim().Length.Equals(0)))
                txtRmCode.Text = oledbDR["RmCode"].ToString();

            if (!(oledbDR["AccountNo"].ToString().Trim().Length.Equals(0)))
                txtAccountNo.Text = oledbDR["AccountNo"].ToString();

            if (!(oledbDR["RmFormat"].ToString().Trim().Length.Equals(0)))
                ddlRmFormat.SelectedValue = oledbDR["RmFormat"].ToString();

            if (!(oledbDR["BllCase"].ToString().Trim().Length.Equals(0)))
                ddlBllCase.SelectedValue = oledbDR["BllCase"].ToString();

            if (!(oledbDR["BllSvr"].ToString().Trim().Length.Equals(0)))
                ddlBllSvr.SelectedValue = oledbDR["BllSvr"].ToString();

            if (!(oledbDR["NocName"].ToString().Trim().Length.Equals(0)))
                txtNocName.Text = oledbDR["NocName"].ToString();

            if (!(oledbDR["TvTele"].ToString().Trim().Length.Equals(0)))
                txtTvTele.Text = oledbDR["TvTele"].ToString();

            if (!(oledbDR["TvPerson"].ToString().Trim().Length.Equals(0)))
                txtTvPerson.Text = oledbDR["TvPerson"].ToString();

            if (!(oledbDR["TvRelation"].ToString().Trim().Length.Equals(0)))
                txtTvRelation.Text = oledbDR["TvRelation"].ToString();

            if (!(oledbDR["TvConAdd"].ToString().Trim().Length.Equals(0)))
                txtTvConAdd.Text = oledbDR["TvConAdd"].ToString();

            if (!(oledbDR["TvCustId"].ToString().Trim().Length.Equals(0)))
                txtTvCustId.Text = oledbDR["TvCustId"].ToString();

            if (!(oledbDR["DesBuild"].ToString().Trim().Length.Equals(0)))
                ddlDesBuild.SelectedValue = oledbDR["DesBuild"].ToString();

            if (!(oledbDR["BspName"].ToString().Trim().Length.Equals(0)))
                txtBspName.Text = oledbDR["BspName"].ToString();

            if (!(oledbDR["Building"].ToString().Trim().Length.Equals(0)))
                ddlBuilding.SelectedValue = oledbDR["Building"].ToString();

            if (!(oledbDR["Buss_stock_seen"].ToString().Trim().Length.Equals(0)))
                ddlStock.SelectedValue = oledbDR["Buss_stock_seen"].ToString();
            //--ended---
            
            if (!(oledbDR["IfNamePLate"].ToString().Trim().Length.Equals(0)))
                txtIfNamePLate.Text = oledbDR["IfNamePLate"].ToString();

            if (!(oledbDR["NameOfficer"].ToString().Trim().Length.Equals(0)))
                txtNameOfficer.Text = oledbDR["NameOfficer"].ToString();

            if (!(oledbDR["SiteVerifier"].ToString().Trim().Length.Equals(0)))
                txtSiteVerifier.Text = oledbDR["SiteVerifier"].ToString();

            string sAccOpen = oledbDR["AccOpen"].ToString() + "";
            string[] arrAccOpen = sAccOpen.Split(',');
            int iAccOpen = 0;
            if (arrAccOpen.Length > 0)
            {
                for (int i = 0; i < arrAccOpen.Length; i++)
                {
                    foreach (ListItem li in ChkAccOpen.Items)
                    {
                        if (li.Value == arrAccOpen.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }

            string sRetDel = oledbDR["RetDel"].ToString() + "";
            string[] arrRetDel = sRetDel.Split(',');
            int iRetDel = 0;
            if (arrRetDel.Length > 0)
            {
                for (int i = 0; i < arrRetDel.Length; i++)
                {
                    foreach (ListItem li in ChkRetDel.Items)
                    {
                        if (li.Value == arrRetDel.GetValue(i).ToString())
                            li.Selected = true;
                    }
                }
            }

            if (!(oledbDR["Sign1"].ToString().Trim().Length.Equals(0)))
                txtSign1.Text = oledbDR["Sign1"].ToString();
            if (!(oledbDR["Sign2"].ToString().Trim().Length.Equals(0)))
                txtSign2.Text = oledbDR["Sign2"].ToString();
            if (!(oledbDR["Sign3"].ToString().Trim().Length.Equals(0)))
                txtSign3.Text = oledbDR["Sign3"].ToString();
            if (!(oledbDR["Sign4"].ToString().Trim().Length.Equals(0)))
                txtSign4.Text = oledbDR["Sign4"].ToString();
            if (!(oledbDR["Sign5"].ToString().Trim().Length.Equals(0)))
                txtSign5.Text = oledbDR["Sign5"].ToString();
            if (!(oledbDR["Sign6"].ToString().Trim().Length.Equals(0)))
                txtSign6.Text = oledbDR["Sign6"].ToString();
            if (!(oledbDR["DesgBO"].ToString().Trim().Length.Equals(0)))
                txtDesgBO.Text = oledbDR["DesgBO"].ToString();

            if (!(oledbDR["Father_Name"].ToString().Trim().Length.Equals(0)))
                ddlDocVeri.SelectedValue = oledbDR["Father_Name"].ToString();
            if (!(oledbDR["Father_Occupation"].ToString().Trim().Length.Equals(0)))
                ddlNeighAware.SelectedValue = oledbDR["Father_Occupation"].ToString();
            if (!(oledbDR["Mother_Name"].ToString().Trim().Length.Equals(0)))
                ddlAuthoSign.SelectedValue = oledbDR["Mother_Name"].ToString();
            //Added by manoj for..............indusand bank
            if (!(oledbDR["Confirmationaddress"].ToString().Trim().Length.Equals(0)))
                ddlconfirmation.SelectedValue = oledbDR["Confirmationaddress"].ToString();

            if (!(oledbDR["Thiredpartyconfirmation"].ToString().Trim().Length.Equals(0)))
                ddlThiredparty.SelectedValue = oledbDR["Thiredpartyconfirmation"].ToString();

            if (!(oledbDR["MetToapplicant"].ToString().Trim().Length.Equals(0)))
                ddlMettoapplicant.SelectedValue = oledbDR["MetToapplicant"].ToString();

            if (!(oledbDR["Rationcardavailable"].ToString().Trim().Length.Equals(0)))
                ddlRationcardavailable.SelectedValue = oledbDR["Rationcardavailable"].ToString();
            //Ended by Manoj 
        }
        oledbDR.Close();
    }
    //ended ..........

    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        DataSet dsTeleCallLog1 = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objKYC.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            dsTeleCallLog1 = objKYC.GetTeleCallLogDetail1(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType1.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark1.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
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
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType2.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark2.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
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
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["ATTEMPT_DATE_TIME"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTimeType3.SelectedValue = arrAttemptDateTime[2].ToString().Trim();
                        txtRemark3.Text = dsTeleCallLog.Tables[0].Rows[i]["REMARK"].ToString();
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

    /// <summary>
    ///  This Method is Used to  Insert the Records in the table CC_CPV_VERI_ATTAMPTS
    /// </summary>
    private void InsertTeleCallLog()
    {
        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objKYC.CaseId = strCaseID;


            objKYC.VerificationTypeId = Request.QueryString["VerTypeId"].ToString();
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


            if (objKYC.InsertTeleCallLog(arrTeleCallLog) == 1)
            {


            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }

    private void GetKYCVerificationEntry()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCVerificationEntry(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            string sTmp = oledbDR["sup_date_time"].ToString();
            if (sTmp != "")
            {
                string[] arrsupdatetime = sTmp.Split(' ');
                if (arrsupdatetime[0].ToString() != "")
                    txtSupervisorDate.Text = Convert.ToDateTime(arrsupdatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrsupdatetime[1].ToString() != "")
                    txtSupervisorTime.Text = Convert.ToDateTime(arrsupdatetime[1].ToString()).ToString("hh:mm");

                ddlSupervisorTimeType.SelectedValue = arrsupdatetime[2].ToString();
            }
            
            string sTmp1 = oledbDR["veri_date_time"].ToString();
            if (sTmp1 != "")
            {
                string[] arrveridatetime = sTmp1.Split(' ');
                if (arrveridatetime[0].ToString() != "")
                    txtVerifierDate.Text = Convert.ToDateTime(arrveridatetime[0].ToString()).ToString("dd/MM/yyyy");
                if (arrveridatetime[1].ToString() != "")
                    txtVerifierTime.Text = Convert.ToDateTime(arrveridatetime[1].ToString()).ToString("hh:mm");

                ddlVerifierTimeType.SelectedValue = arrveridatetime[2].ToString();
            }

            if (!(oledbDR["properietor_Partener_Met"].ToString().Trim().Length.Equals(0)))
                ddlproperietorpartener.SelectedValue = oledbDR["properietor_Partener_Met"].ToString();

            if (!(oledbDR["Tlele_Remark"].ToString().Trim().Length.Equals(0)))
                txtRemark.Text = oledbDR["Tlele_Remark"].ToString();

            if (!(oledbDR["supervisor_name"].ToString().Trim().Length.Equals(0)))
                txtSupervisorName.Text = oledbDR["supervisor_name"].ToString();

            if (!(oledbDR["Company_Type"].ToString().Trim().Length.Equals(0)))
                ddlCompanyType.SelectedValue = oledbDR["Company_Type"].ToString();


            if (!(oledbDR["Name_Firm"].ToString().Trim().Length.Equals(0)))
                txtNameOfFirm.Text = oledbDR["Name_Firm"].ToString();

            //////////////////if (!(oledbDR["Business_Address"].ToString().Trim().Length.Equals(0)))
            //////////////////    txtBusinessAddress.Text = oledbDR["Business_Address"].ToString();

            if (!(oledbDR["Business_Pincode"].ToString().Trim().Length.Equals(0)))
                txtBusinessPincode.Text = oledbDR["Business_Pincode"].ToString();


            if (!(oledbDR["Bussiness_tel_no"].ToString().Trim().Length.Equals(0)))
                txtBusinessTelNo.Text = oledbDR["Bussiness_tel_no"].ToString();

            if (!(oledbDR["ContactPerson"].ToString().Trim().Length.Equals(0)))
                if (oledbDR["ContactPerson"].ToString().Trim() != "Neighbour" && oledbDR["ContactPerson"].ToString().Trim() != "Watchman")
                {
                    ddlContactPerson.SelectedIndex = 3;
                    txtIfOtherProvideDetail.Text = oledbDR["ContactPerson"].ToString();

                }
                else
                {
                    ddlContactPerson.SelectedValue = oledbDR["ContactPerson"].ToString();
                }

            if (!(oledbDR["Name_person_contacted"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["Name_person_contacted"].ToString();



            if (!(oledbDR["Designation"].ToString().Trim().Length.Equals(0)))
                txtDesignation.Text = oledbDR["Designation"].ToString();

            if (!(oledbDR["Premise_Location"].ToString().Trim().Length.Equals(0)))
                ddlPremiseLocation.SelectedValue = oledbDR["Premise_Location"].ToString();

            if (!(oledbDR["Prominent_Landmark"].ToString().Trim().Length.Equals(0)))
                txtProminentLandmark.Text = oledbDR["Prominent_Landmark"].ToString();


            if (!(oledbDR["Address_Verified_is"].ToString().Trim().Length.Equals(0)))
                ddlAddressVerifiedIs.SelectedValue = oledbDR["Address_Verified_is"].ToString();

            if (!(oledbDR["How_long_Business"].ToString().Trim().Length.Equals(0)))
                txtHowLongInBusiness.Text = oledbDR["How_long_Business"].ToString();

            if (!(oledbDR["Area_Premises"].ToString().Trim().Length.Equals(0)))
                txtAreaPremises.Text = oledbDR["Area_Premises"].ToString();


            if (!(oledbDR["Ownership_Premises"].ToString().Trim().Length.Equals(0)))
            {
                if (oledbDR["Ownership_Premises"].ToString().Trim() != "Owned" && oledbDR["Ownership_Premises"].ToString().Trim() != "Rented")
                {
                    ddlOwnershipOfPremises.SelectedIndex = 3;
                    txtIfOtherPlzSpecify.Text = oledbDR["Ownership_Premises"].ToString();
                }
                else
                {
                    ddlOwnershipOfPremises.SelectedValue = oledbDR["Ownership_Premises"].ToString();
                }
            }
            if (!(oledbDR["Type_Premise"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfPremise.SelectedValue = oledbDR["Type_Premise"].ToString();

            if (!(oledbDR["Type_Premise_Other"].ToString().Trim().Length.Equals(0)))
                txtOtherTypeOfPremise.Text = oledbDR["Type_Premise_Other"].ToString();


            if (!(oledbDR["Nature_Business"].ToString().Trim().Length.Equals(0)))
                ddlNatureOfBusiness.SelectedValue = oledbDR["Nature_Business"].ToString();

            if (!(oledbDR["business_occupation_details"].ToString().Trim().Length.Equals(0)))
                txtNatureBuss.Text = oledbDR["business_occupation_details"].ToString();

            if (!(oledbDR["Firm_Signboard_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlFirmSignBoardSighted.SelectedValue = oledbDR["Firm_Signboard_Sighted"].ToString();

            if (!(oledbDR["Sign_Sighted_Remark"].ToString().Trim().Length.Equals(0)))
                txtSignBoardSightedRemark.Text = oledbDR["Sign_Sighted_Remark"].ToString();

            if (!(oledbDR["Type_Document_Sighted"].ToString().Trim().Length.Equals(0)))
                ddlTypeOfDocSighted.SelectedValue = oledbDR["Type_Document_Sighted"].ToString();

            if (!(oledbDR["Document_Sighted_Remark"].ToString().Trim().Length.Equals(0)))
                txtIfOtherDocSightedRemark.Text = oledbDR["Document_Sighted_Remark"].ToString();

            if (!(oledbDR["Used_Pages_Sighted_Date"].ToString().Trim().Length.Equals(0)))
                txtUsedPageSightDate.Text = oledbDR["Used_Pages_Sighted_Date"].ToString();

            if (!(oledbDR["Issued_to"].ToString().Trim().Length.Equals(0)))
                txtIssuedTo.Text = oledbDR["Issued_to"].ToString();


            if (!(oledbDR["Initial_Invoice_Sighted_No"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedNo.Text = oledbDR["Initial_Invoice_Sighted_No"].ToString();

            if (!(oledbDR["Initial_Invoice_Sighted_Date"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedDate.Text = oledbDR["Initial_Invoice_Sighted_Date"].ToString();

            if (!(oledbDR["Initial_Invoice_issued_to"].ToString().Trim().Length.Equals(0)))
                txtInitialInvoiceSightedIssuedTo.Text = oledbDR["Initial_Invoice_issued_to"].ToString();


            if (!(oledbDR["Third_Party_Invoice_No"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceNo.Text = oledbDR["Third_Party_Invoice_No"].ToString();

            if (!(oledbDR["Third_Party_Invoice_Date"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceDate.Text = oledbDR["Third_Party_Invoice_Date"].ToString();

            if (!(oledbDR["Third_Party_Invoice_Issued_by"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyInvoiceIssuedBy.Text = oledbDR["Third_Party_Invoice_Issued_by"].ToString();


            if (!(oledbDR["Third_Party_Address"].ToString().Trim().Length.Equals(0)))
                txtThirdPartyAddress.Text = oledbDR["Third_Party_Address"].ToString();

            if (!(oledbDR["Relationship_between"].ToString().Trim().Length.Equals(0)))
                if (oledbDR["Relationship_between"].ToString().Trim() != "Same Proprietor" && oledbDR["Relationship_between"].ToString().Trim() != "Common Partner")
                {
                    ddlRelationshipBtnEntity.SelectedIndex = 3;
                    txtIfOtherRelationship.Text = oledbDR["Relationship_between"].ToString();
                }
                else
                {
                    ddlRelationshipBtnEntity.SelectedValue = oledbDR["Relationship_between"].ToString();
                }

            if (!(oledbDR["Business_Ownership"].ToString().Trim().Length.Equals(0)))
                ddlBusinessOwnership.SelectedValue = oledbDR["Business_Ownership"].ToString();
            if (oledbDR["Business_Ownership"].ToString().Trim() != "Owned by Self" && oledbDR["Business_Ownership"].ToString().Trim() != "Family Owned")
            {
                ddlBusinessOwnership.SelectedIndex = 3;
                txtplsSpecify.Text = oledbDR["Business_Ownership"].ToString().Trim();
            }
            else
            {
                ddlBusinessOwnership.SelectedValue = oledbDR["Business_Ownership"].ToString().Trim();
            }

            if (!(oledbDR["Level_Business_Activity"].ToString().Trim().Length.Equals(0)))
                ddlLevelOfBusinessActivity.SelectedValue = oledbDR["Level_Business_Activity"].ToString();


            if (!(oledbDR["No_Employees"].ToString().Trim().Length.Equals(0)))
                txtNoOfEmployee.Text = oledbDR["No_Employees"].ToString();

            if (!(oledbDR["Business_Equipment_Sighted"].ToString().Trim().Length.Equals(0)))
            {
                string sBusinessEquipSighted = oledbDR["Business_Equipment_Sighted"].ToString();
                string[] arrBusinessEquipSighted = sBusinessEquipSighted.Split(',');
                int iOthersBusinessEquipSightedCtr = 0;
                if (arrBusinessEquipSighted.Length > 0)
                {
                    for (int i = 0; i < arrBusinessEquipSighted.Length; i++)
                    {
                        foreach (ListItem li in chklBusinessEquipSighted.Items)
                        {
                            if (li.Value == arrBusinessEquipSighted.GetValue(i).ToString())
                                li.Selected = true;
                            if (arrBusinessEquipSighted.GetValue(i).ToString() == "Others")
                            {
                                iOthersBusinessEquipSightedCtr = i;
                            }
                        }
                    }
                }
                for (int j = iOthersBusinessEquipSightedCtr + 1; j < arrBusinessEquipSighted.Length; j++)
                {
                    txtIfOtherBusinessEquipment.Text += arrBusinessEquipSighted.GetValue(j) + ",";
                }
            }

            if (!(oledbDR["Marital_Status"].ToString().Trim().Length.Equals(0)))
                ddlMaritalStatus.SelectedValue = oledbDR["Marital_Status"].ToString();


            if (!(oledbDR["Name_Displayed_Board"].ToString().Trim().Length.Equals(0)))
                ddlNamePlateDisplay.SelectedValue = oledbDR["Name_Displayed_Board"].ToString();

            if (!(oledbDR["Relationship_with_Applicant"].ToString().Trim().Length.Equals(0)))
                txtRelationshipWithApp.Text = oledbDR["Relationship_with_Applicant"].ToString();

            if (!(oledbDR["Staying_since_Resi"].ToString().Trim().Length.Equals(0)))
                txtStayingSinceAtResi.Text = oledbDR["Staying_since_Resi"].ToString();


            if (!(oledbDR["Status_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlStatusOfDematAcct.SelectedValue = oledbDR["Status_Demat_Account"].ToString();

            if (!(oledbDR["Name_Demat_Account"].ToString().Trim().Length.Equals(0)))
                txtNameOfDematAcct.Text = oledbDR["Name_Demat_Account"].ToString();

            if (!(oledbDR["Broking_through_other"].ToString().Trim().Length.Equals(0)))
                txtDoBrokeOtherThanSSKI.Text = oledbDR["Broking_through_other"].ToString();

            if (!(oledbDR["Attitude_Person_Contacted"].ToString().Trim().Length.Equals(0)))
                ddlAttituteOfContactPerson.SelectedValue = oledbDR["Attitude_Person_Contacted"].ToString();


            if (!(oledbDR["Rating"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Rating"].ToString();

            //if (!(oledbDR["Status"].ToString().Trim().Length.Equals(0)))
            //    ddlStatus.SelectedItem.Text = oledbDR["Status"].ToString();

            if (!(oledbDR["Email_ID"].ToString().Trim().Length.Equals(0)))
                txtEmail.Text = oledbDR["Email_ID"].ToString();

            if (!(oledbDR["Name_On_Sign_Board"].ToString().Trim().Length.Equals(0)))
                txtNameOnSignBoard.Text = oledbDR["Name_On_Sign_Board"].ToString();

            if (!(oledbDR["Concern_Is_Related"].ToString().Trim().Length.Equals(0)))
                ddlProprietorPartner.SelectedValue = oledbDR["Concern_Is_Related"].ToString();

            if (!(oledbDR["Concern_Related_Name"].ToString().Trim().Length.Equals(0)))
                txtName.Text = oledbDR["Concern_Related_Name"].ToString();

            if (!(oledbDR["Family_Member_Is"].ToString().Trim().Length.Equals(0)))
                ddlFamilyMemberIs.SelectedValue = oledbDR["Family_Member_Is"].ToString();

            if (!(oledbDR["Family_Member_Name"].ToString().Trim().Length.Equals(0)))
                txtNameIs.Text = oledbDR["Family_Member_Name"].ToString();

            if (!(oledbDR["Family_Member_Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipIs.Text = oledbDR["Family_Member_Relationship"].ToString();

            if (!(oledbDR["Other_Institution_Demat_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingDematAcwithOtherInstitution.SelectedValue = oledbDR["Other_Institution_Demat_Account"].ToString();

            if (!(oledbDR["Name_Of_DP"].ToString().Trim().Length.Equals(0)))
                txtIfYesThenNameOfDP.Text = oledbDR["Name_Of_DP"].ToString();


            if (!(oledbDR["Entity_Type"].ToString().Trim().Length.Equals(0)))
                ddlEntityType.SelectedValue = oledbDR["Entity_Type"].ToString();


            if (!(oledbDR["No_Years_Current_Employment"].ToString().Trim().Length.Equals(0)))
                txtNoOfYearsInCurrentEmployment.Text = oledbDR["No_Years_Current_Employment"].ToString();

            if (!(oledbDR["Other_Institution_SME_Account"].ToString().Trim().Length.Equals(0)))
                ddlHavingSMEAccountWithOtherInstitution.SelectedValue = oledbDR["Other_Institution_SME_Account"].ToString();

            if (!(oledbDR["Name_Of_Institution"].ToString().Trim().Length.Equals(0)))
                txtNameOfInstitution.Text = oledbDR["Name_Of_Institution"].ToString();
            if (!(oledbDR["Person_Contacted"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["Person_Contacted"].ToString();


            if (!(oledbDR["business_activity"].ToString().Trim().Length.Equals(0)))
                ddlbusinessActivity.SelectedValue = oledbDR["business_activity"].ToString();

            if (!(oledbDR["Remark"].ToString().Trim().Length.Equals(0)))
                txtoverallRemark.Text = oledbDR["Remark"].ToString();

            if (!(oledbDR["cerificate_person_confirm"].ToString().Trim().Length.Equals(0)))
                txtAnyOthDet.Text = oledbDR["cerificate_person_confirm"].ToString();

            if (!(oledbDR["City_Limit"].ToString().Trim().Length.Equals(0)))
               ddlCityLimit.SelectedValue = oledbDR["City_Limit"].ToString();

           if (!(oledbDR["Website"].ToString().Trim().Length.Equals(0)))
               txtwebsite.Text = oledbDR["Website"].ToString();

           if (!(oledbDR["CompRegiCheckSince"].ToString().Trim().Length.Equals(0)))
               txtCompRegiCheckSince.Text = oledbDR["CompRegiCheckSince"].ToString();

           if (!(oledbDR["CompRegiCheckSinceRegNo"].ToString().Trim().Length.Equals(0)))
               txtCompRegiCheckSinceRegNo.Text = oledbDR["CompRegiCheckSinceRegNo"].ToString();

           if (!(oledbDR["CompRegiCheckRemark"].ToString().Trim().Length.Equals(0)))
               txtCompRegiCheckRemark.Text = oledbDR["CompRegiCheckRemark"].ToString();

           if (!(oledbDR["Location_Profile"].ToString().Trim().Length.Equals(0)))
               txtLocProfile.Text = oledbDR["Location_Profile"].ToString();

           if (!(oledbDR["bldg_Profile"].ToString().Trim().Length.Equals(0)))
               txtbldgProfile.Text = oledbDR["bldg_Profile"].ToString();

           if (!(oledbDR["Flr_Profile"].ToString().Trim().Length.Equals(0)))
               txtFlrProfile.Text = oledbDR["Flr_Profile"].ToString();

           if (!(oledbDR["Flr_Profile_left_neigh"].ToString().Trim().Length.Equals(0)))
               txtFlrProfileLeftNeigh.Text = oledbDR["Flr_Profile_left_neigh"].ToString();

           if (!(oledbDR["Flr_Profile_Flr_above"].ToString().Trim().Length.Equals(0)))
               txtFlrProfileFlrAb.Text = oledbDR["Flr_Profile_Flr_above"].ToString();

           if (!(oledbDR["Flr_Profile_Flr_belwo"].ToString().Trim().Length.Equals(0)))
               txtFlrProfileFlrBl.Text = oledbDR["Flr_Profile_Flr_belwo"].ToString();

           if (!(oledbDR["Name_board_out_Office"].ToString().Trim().Length.Equals(0)))
               txtNameBoardOutOffice.Text = oledbDR["Name_board_out_Office"].ToString();

           if (!(oledbDR["Name_board_Lobby_area"].ToString().Trim().Length.Equals(0)))
               txtNameBoardLobbyArea.Text = oledbDR["Name_board_Lobby_area"].ToString();

           if (!(oledbDR["asso_company"].ToString().Trim().Length.Equals(0)))
               txtAssoCompany.Text = oledbDR["asso_company"].ToString();

           if (!(oledbDR["Gen_Interior"].ToString().Trim().Length.Equals(0)))
               txtGenInterior.Text = oledbDR["Gen_Interior"].ToString();

           if (!(oledbDR["No_workstations"].ToString().Trim().Length.Equals(0)))
               txtNoWorkstations.Text = oledbDR["No_workstations"].ToString();

           if (!(oledbDR["owner_cabin"].ToString().Trim().Length.Equals(0)))
               txtOwnerCabin.Text = oledbDR["owner_cabin"].ToString();

           if (!(oledbDR["landlord"].ToString().Trim().Length.Equals(0)))
               txtlandloard.Text = oledbDR["landlord"].ToString();

           if (!(oledbDR["Proppery_resi"].ToString().Trim().Length.Equals(0)))
               txtProperyResi.Text = oledbDR["Proppery_resi"].ToString();

           if (!(oledbDR["Proppery_comm"].ToString().Trim().Length.Equals(0)))
               txtProperyComm.Text = oledbDR["Proppery_comm"].ToString();

           if (!(oledbDR["Proppery_shop"].ToString().Trim().Length.Equals(0)))
               txtProperyShop.Text = oledbDR["Proppery_shop"].ToString();

           if (!(oledbDR["Locating_Address"].ToString().Trim().Length.Equals(0)))
               ddlLocatingAddress.SelectedValue = oledbDR["Locating_Address"].ToString();

           //---added by kamal matekar for Hdfc_Liab pdf format-----------

           if (!(oledbDR["locality"].ToString().Trim().Length.Equals(0)))
               ddlLocalityTypeForFemu.SelectedValue = oledbDR["locality"].ToString();

           if (!(oledbDR["Name_person_contacted"].ToString().Trim().Length.Equals(0)))
               txtNameOfPersonContacted.Text = oledbDR["Name_person_contacted"].ToString();

           if (!(oledbDR["How_long_Business"].ToString().Trim().Length.Equals(0)))
               txtHowLongInBusiness.Text = oledbDR["How_long_Business"].ToString();

            //////////add new code for Atom Tech releted by santosh Shelar  25/04/2011/////////////////
           if (!(oledbDR["Product"].ToString().Trim().Length.Equals(0)))
               txtProductSold.Text = oledbDR["Product"].ToString();

           if (!(oledbDR["Verification_Agent"].ToString().Trim().Length.Equals(0)))
               txtLargeCorporate.Text = oledbDR["Verification_Agent"].ToString();

           if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
               ddlCurrentAcq.SelectedValue = oledbDR["Residence_Address"].ToString();

           if (!(oledbDR["Resi_Pincode"].ToString().Trim().Length.Equals(0)))
               txtBankName.Text = oledbDR["Resi_Pincode"].ToString();

           if (!(oledbDR["Resi_Tel_no"].ToString().Trim().Length.Equals(0)))
               txtMID.Text = oledbDR["Resi_Tel_no"].ToString();

           if (!(oledbDR["Resi_Landmark"].ToString().Trim().Length.Equals(0)))
               txtPeriodRelationship.Text = oledbDR["Resi_Landmark"].ToString();

           if (!(oledbDR["Permanent_Address"].ToString().Trim().Length.Equals(0)))
               txtReasonChanges.Text = oledbDR["Permanent_Address"].ToString();

           if (!(oledbDR["Permanent_Pincode"].ToString().Trim().Length.Equals(0)))
               ddlNeighFeed.SelectedValue = oledbDR["Permanent_Pincode"].ToString();

           if (!(oledbDR["Permamnent_Tel_no"].ToString().Trim().Length.Equals(0)))
               txtNeighbourContact.Text = oledbDR["Permamnent_Tel_no"].ToString();

           if (!(oledbDR["Place_Visited"].ToString().Trim().Length.Equals(0)))
               txtNeighDesig.Text = oledbDR["Place_Visited"].ToString();

           if (!(oledbDR["Area_Residence"].ToString().Trim().Length.Equals(0)))
               txtNoOutlets.Text = oledbDR["Area_Residence"].ToString();

           if (!(oledbDR["Description_Res"].ToString().Trim().Length.Equals(0)))
               txtNoTerminals.Text = oledbDR["Description_Res"].ToString();

           if (!(oledbDR["Name_Account"].ToString().Trim().Length.Equals(0)))
               ddlCurrentAcqYes.SelectedValue = oledbDR["Name_Account"].ToString();

        }
        oledbDR.Close();
    }

    private void GetVerifierName()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetVerifierID(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["EMP_ID"].ToString().Trim().Length.Equals(0)))
                hidVerifierID.Value = oledbDR["EMP_ID"].ToString();

            if (!(oledbDR["FULLNAME"].ToString().Trim().Length.Equals(0)))
                txtVerifierName.Text = oledbDR["FULLNAME"].ToString();



        }
        oledbDR.Close();
    }

    private void GetCaseDetail1()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseDetail1(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["Applicant_Name"].ToString().Trim().Length.Equals(0)))
                txtAppName.Text = oledbDR["Applicant_Name"].ToString();


            if (!(oledbDR["off_name"].ToString().Trim().Length.Equals(0)))
                txtNameOfFirm.Text = oledbDR["off_name"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtBusinessAddress.Text = oledbDR["Address"].ToString();


           // if (!(oledbDR["off_PHONE"].ToString().Trim().Length.Equals(0)))
             //   txtBusinessTelNo.Text = oledbDR["off_PHONE"].ToString();

            

        }
        oledbDR.Close();
    }

    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objKYC.GetKYCCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["Applicant_Name"].ToString().Trim().Length.Equals(0)))
                txtAppName.Text = oledbDR["Applicant_Name"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtAddress.Text = oledbDR["Address"].ToString();

            if (!(oledbDR["CASE_REC_DATETIME"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = oledbDR["CASE_REC_DATETIME"].ToString();

            if (!(oledbDR["DOB"].ToString().Trim().Length.Equals(0)))
                txtDOB.Text = oledbDR["DOB"].ToString();

            if (!(oledbDR["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                txtPhone.Text = oledbDR["RES_PHONE"].ToString();

            if (!(oledbDR["MOBILE"].ToString().Trim().Length.Equals(0)))
                txtMobile.Text = oledbDR["MOBILE"].ToString();

            if (!(oledbDR["Tele_Status"].ToString().Trim().Length.Equals(0)))
                ddlEmpType.SelectedValue = oledbDR["Tele_Status"].ToString();
        }
        oledbDR.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CKYCVerification objKYC = new CKYCVerification();
        int iCount = 0;
        string sMsg = "";
        CCommon objCom = new CCommon();
        try
        {
            objKYC.CaseId = Request.QueryString["CaseId"].ToString();
            objKYC.VerificationTypeId = hidVerificationTypeID.Value;
            if (ddlCompanyType.SelectedIndex != 0)
            {
                objKYC.CompanyType = ddlCompanyType.SelectedItem.Text.Trim();
            }
            objKYC.NameOfFirm = txtNameOfFirm.Text.Trim();
            objKYC.BusinessAddress = txtBusinessAddress.Text.Trim();
            objKYC.BusinessPicode = txtBusinessPincode.Text.Trim();
            objKYC.BusinessTelNo = txtBusinessTelNo.Text.Trim();

            objKYC.PersonContacted = txtPersonContacted.Text.Trim();

            objKYC.NameOfPersonContacted = txtNameOfPersonContacted.Text.Trim();
            objKYC.Designation = txtDesignation.Text.Trim();
            objKYC.OverallRemark = txtoverallRemark.Text.Trim();
            objKYC.CityLimit = ddlCityLimit.SelectedValue.ToString();   

            if ((txtSupervisorDate.Text.Trim() != "" && txtSupervisorDate.Text.Trim() != null) && (txtSupervisorTime.Text != "" && txtSupervisorTime.Text != null))
            {
                objKYC.SupervisorDateTime = objCom.strDate(txtSupervisorDate.Text.Trim()) + " " + txtSupervisorTime.Text.Trim() + " " + ddlSupervisorTimeType.SelectedValue;
            }
            if (txtVerifierDate.Text.Trim() != "" && txtVerifierDate.Text.Trim() != null && txtVerifierTime.Text.Trim() != "" && txtVerifierTime.Text.Trim() != null)
            {
                objKYC.VerifierDatetime = objCom.strDate(txtVerifierDate.Text.Trim()) + " " + txtVerifierTime.Text.Trim() + " " + ddlVerifierTimeType.SelectedValue;
            }
            if (txtSupervisorName.Text.Trim() != "")
            {
                objKYC.SupervisorName = txtSupervisorName.Text.Trim();
            }
            if (ddlPremiseLocation.SelectedIndex != 0)
            {
                objKYC.PremiseLocation = ddlPremiseLocation.SelectedItem.Text.Trim();
            }
            objKYC.ProprietorPartenerMet = ddlproperietorpartener.SelectedValue.Trim().ToString();
            objKYC.ProminetLandmark = txtProminentLandmark.Text.Trim();
            objKYC.TeleRemark = txtRemark.Text.Trim();
            if (ddlAddressVerifiedIs.SelectedIndex != 0)
            {
                objKYC.AddressVerifiedIs = ddlAddressVerifiedIs.SelectedItem.Text.Trim();
            }
            objKYC.HowLongInBusiness = txtHowLongInBusiness.Text.Trim();
            objKYC.AreaOfPremises = txtAreaPremises.Text.Trim();
            if (ddlOwnershipOfPremises.SelectedIndex != 0)
            {
                objKYC.OwnershipOfPremises = ddlOwnershipOfPremises.SelectedItem.Text.Trim();
            }
            if (ddlOwnershipOfPremises.SelectedIndex == 3)
            {
                objKYC.OwnershipOfPremises = txtIfOtherPlzSpecify.Text.Trim();
            }
            if (ddlTypeOfPremise.SelectedIndex != 0)
            {
                objKYC.TypeOfPremises = ddlTypeOfPremise.SelectedItem.Text.Trim();
            }
            objKYC.IfOthersPremisespecify = txtOtherTypeOfPremise.Text.Trim();
            if (ddlContactPerson.SelectedIndex != 0)
            {
                objKYC.ContactPerson = ddlContactPerson.SelectedItem.Text.Trim();
            }
            if (ddlContactPerson.SelectedIndex == 3)
            {
                objKYC.ContactPerson = txtIfOtherProvideDetail.Text.Trim();
            }
            if (ddlNatureOfBusiness.SelectedIndex != 0)
            {
                objKYC.NatureOfBusiness = ddlNatureOfBusiness.SelectedItem.Text.Trim();
            }
            if (ddlFirmSignBoardSighted.SelectedIndex != 0)
            {
                objKYC.FirmSightedBoard = ddlFirmSignBoardSighted.SelectedItem.Text.Trim();
            }
            objKYC.SignBoardSightedRemark = txtSignBoardSightedRemark.Text.Trim();
            if (ddlTypeOfDocSighted.SelectedIndex != 0)
            {
                objKYC.TypeOfDocSighted = ddlTypeOfDocSighted.SelectedItem.Text.Trim();
            }
            objKYC.OtherDocSightedRemark = txtIfOtherDocSightedRemark.Text.Trim();
            objKYC.NatureBuss = txtNatureBuss.Text.Trim();    
            objKYC.UsedPagesSightedDate = txtUsedPageSightDate.Text.Trim();
            objKYC.IssuedTo = txtIssuedTo.Text.Trim();
            objKYC.InitialInvoiceSightedNo = txtInitialInvoiceSightedNo.Text.Trim();
            objKYC.InitialInvoiceSightedDate = txtInitialInvoiceSightedDate.Text.Trim();
            objKYC.InitialInvoiceSightedIssuedTo = txtInitialInvoiceSightedIssuedTo.Text.Trim();
            objKYC.ThirdPartyInvoiceNo = txtThirdPartyInvoiceNo.Text.Trim();
            objKYC.ThirdPartyInvoiceDate = txtThirdPartyInvoiceDate.Text.Trim();
            objKYC.ThirdPartyInvoiceIssuedBy = txtThirdPartyInvoiceIssuedBy.Text.Trim();
            objKYC.ThirdPartyAddress = txtThirdPartyAddress.Text.Trim();
            objKYC.ConfirmCACertificateIssued = txtAnyOthDet.Text.Trim();

            if (ddlLocatingAddress.SelectedIndex != 0)
            {
                objKYC.LocatingAddress = ddlLocatingAddress.SelectedItem.Text.Trim();
            }
            //////////added by santosh for TCM/////////////////////
            objKYC.Website = txtwebsite.Text.Trim();
            objKYC.CompRegiCheckSince = txtCompRegiCheckSince.Text.Trim();
            objKYC.CompRegiCheckSinceRegNo = txtCompRegiCheckSinceRegNo.Text.Trim();
            objKYC.CompRegiCheckRemark = txtCompRegiCheckRemark.Text.Trim();
            objKYC.Location_Profile = txtLocProfile.Text.Trim();
            objKYC.bldg_Profile = txtbldgProfile.Text.Trim();
            objKYC.Flr_Profile = txtFlrProfile.Text.Trim();
            objKYC.Flr_Profile_left_neigh = txtFlrProfileLeftNeigh.Text.Trim();
            objKYC.Flr_Profile_Flr_above = txtFlrProfileFlrAb.Text.Trim();
            objKYC.Flr_Profile_Flr_belwo = txtFlrProfileFlrBl.Text.Trim();
            objKYC.Name_board_out_Office = txtNameBoardOutOffice.Text.Trim();
            objKYC.Name_board_Lobby_area = txtNameBoardLobbyArea.Text.Trim();
            objKYC.asso_company = txtAssoCompany.Text.Trim();
            objKYC.Gen_Interior = txtGenInterior.Text.Trim();
            objKYC.No_workstations = txtNoWorkstations.Text.Trim();
            objKYC.owner_cabin = txtOwnerCabin.Text.Trim();
            objKYC.landlord = txtlandloard.Text.Trim();
            objKYC.Proppery_resi = txtProperyResi.Text.Trim();
            objKYC.Proppery_comm = txtProperyComm.Text.Trim();
            objKYC.Proppery_shop = txtProperyShop.Text.Trim();    
            ////////////////end///////////////////

            //added by kamal matekar...

            if (ddlNatureOfBusiness.SelectedItem.Text.Trim() == "Others")
                objKYC.NatureOfBusiness = "Others:"  + txtNatureBuss.Text.Trim();
            else
                objKYC.NatureOfBusiness = ddlNatureOfBusiness.SelectedItem.Text.Trim();

            objKYC.Type_Org = ddlConstitution.SelectedValue.ToString();
            objKYC.Card_No = ddlWhetherVisitingCardobtained.SelectedValue.ToString();
            objKYC.Buss_Proof_Seen = txtReasonfornothavingavalidBusinessproof.Text.Trim();
            objKYC.Locality_Type = ddlLocalityType.SelectedValue.ToString();
            objKYC.EquipmentSeen_OR_Shift_Arrangement = txtfurniture.Text.Trim();

            if (ddlIfNotRecommended.SelectedItem.Text.Trim() == "Others")
                objKYC.Observation_If_NotRecommended = "Others" + ":" + txtIfOtherRecommended.Text.Trim();
            else
                objKYC.Observation_If_NotRecommended = ddlIfNotRecommended.SelectedItem.Text.Trim();

            //ended by kamal matekar...

            if (ddlRelationshipBtnEntity.SelectedIndex != 0)
            {
                objKYC.RelationshipBTNEntity = ddlRelationshipBtnEntity.SelectedItem.Text.Trim();
            }
            if (ddlRelationshipBtnEntity.SelectedIndex == 3)
            {
                objKYC.RelationshipBTNEntity = txtIfOtherRelationship.Text.Trim();
            }
            if (ddlBusinessOwnership.SelectedIndex != 0)
            {
                objKYC.BusinessOwnership = ddlBusinessOwnership.SelectedItem.Text.Trim();
            }
            if (ddlBusinessOwnership.SelectedIndex == 3)
            {
                objKYC.BusinessOwnership = txtplsSpecify.Text.Trim();
            }
            if (ddlLevelOfBusinessActivity.SelectedIndex != 0)
            {
                objKYC.LevelOfBusinssActivity = ddlLevelOfBusinessActivity.SelectedItem.Text.Trim();
            }
            objKYC.NoOfEmployees = txtNoOfEmployee.Text.Trim();
            if (ddlEntityType.SelectedIndex != 0)
            {
                objKYC.EntityType = ddlEntityType.SelectedValue.Trim().ToString();
            }

            objKYC.NoOfYearsInCurrentEmployment = txtNoOfYearsInCurrentEmployment.Text.Trim().ToString();
            if (ddlbusinessActivity.SelectedIndex != 0)
            {
                objKYC.BusinessActivity = ddlbusinessActivity.SelectedValue.ToString().Trim();
            }

            string sBusinessEquipSighted = "";
            if (chklBusinessEquipSighted.Items.Count > 0)
            {
                foreach (ListItem li in chklBusinessEquipSighted.Items)
                {
                    if (li.Text.Trim() == "Others" && li.Selected == true)
                        sBusinessEquipSighted += li.Value + "," + txtIfOtherBusinessEquipment.Text.Trim();
                    else
                        if (li.Selected == true)
                            sBusinessEquipSighted += li.Value + ",";
                }
            }

            objKYC.BusinessEquipSighted = sBusinessEquipSighted.TrimEnd(',');
            objKYC.VerifierName = txtVerifierName.Text.Trim();

            objKYC.Address = txtAddress.Text.Trim();
            objKYC.PhoneNo = txtPhone.Text.Trim();
            objKYC.MobileNo = txtMobile.Text.Trim();
            objKYC.EmailId = txtEmail.Text.Trim();
            objKYC.DateOfBirth = txtDOB.Text.Trim();
            if (ddlMaritalStatus.SelectedIndex != 0)
            {
                objKYC.MaritalStatus = ddlMaritalStatus.SelectedItem.Text.Trim();
            }
            if (ddlNamePlateDisplay.SelectedIndex != 0)
            {
                objKYC.NameDisplayOnNameBoard = ddlNamePlateDisplay.SelectedItem.Text.Trim();
            }
            objKYC.RelationshipWithApplicant = txtRelationshipWithApp.Text.Trim();
            objKYC.StayingSinceAtResi = txtStayingSinceAtResi.Text.Trim();
            if (ddlStatusOfDematAcct.SelectedIndex != 0)
            {
                objKYC.StatusOfDematAcct = ddlStatusOfDematAcct.SelectedItem.Text.Trim();
            }
            objKYC.NameOfDematAcct = txtNameOfDematAcct.Text.Trim();
            objKYC.DoingBroken = txtDoBrokeOtherThanSSKI.Text.Trim();
            if (ddlAttituteOfContactPerson.SelectedIndex != 0)
            {
                objKYC.AttituteOfPersonContacted = ddlAttituteOfContactPerson.SelectedItem.Text.Trim();
            }
            if (ddlRating.SelectedIndex != 0)
            {
                objKYC.Rating = ddlRating.SelectedItem.Text.Trim();
            }

            objKYC.Status = ddlStatus.SelectedItem.Text.Trim();


            objKYC.CaseStatusId = ddlStatus.SelectedValue.ToString();

            objKYC.NameOnSignBoard = txtNameOnSignBoard.Text.Trim();
            if (ddlProprietorPartner.SelectedIndex != 0)
            {
                objKYC.HowTheConcernIsRelated = ddlProprietorPartner.SelectedValue.ToString();
            }
            objKYC.ConcernRelatedName = txtName.Text.Trim();
            if (ddlFamilyMemberIs.SelectedIndex != 0)
            {
                objKYC.FamilyMemberIs = ddlFamilyMemberIs.SelectedValue.ToString();
            }
            objKYC.FamilyMemberName = txtNameIs.Text.Trim();
            objKYC.FamilyMemberRelationship = txtRelationshipIs.Text.Trim();
            if (ddlHavingDematAcwithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingDematAccountWithOtherInstitution = ddlHavingDematAcwithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfDP = txtIfYesThenNameOfDP.Text.Trim();

            if (ddlHavingSMEAccountWithOtherInstitution.SelectedIndex != 0)
            {
                objKYC.HavingSMEAccountWithOtherInstitution = ddlHavingSMEAccountWithOtherInstitution.SelectedValue.ToString();
            }
            objKYC.NameOfInstitution = txtNameOfInstitution.Text.Trim();

            objKYC.TrigSVR = ddlTrigSVR.SelectedValue.ToString();
            objKYC.BranchCode = txtBranchCode.Text.Trim();
            objKYC.BranchName = txtBranchName.Text.Trim();
            objKYC.RmName = txtRmName.Text.Trim();
            objKYC.RmCode = txtRmCode.Text.Trim();
            objKYC.AccountNo = txtAccountNo.Text.Trim();
            objKYC.NameOfPersonContacted = txtNameOfPersonContacted.Text.Trim();
            objKYC.HowLongInBusiness = txtHowLongInBusiness.Text.Trim();
            objKYC.RmFormat = ddlRmFormat.SelectedValue.ToString();
            objKYC.BllCase = ddlBllCase.SelectedValue.ToString();
            objKYC.BllSvr = ddlBllSvr.SelectedValue.ToString();
            objKYC.NocName = txtNocName.Text.Trim();
            objKYC.TvTele = txtTvTele.Text.Trim();
            objKYC.TvPerson = txtTvPerson.Text.Trim();
            objKYC.TvRelation = txtTvRelation.Text.Trim();
            objKYC.TvConAdd = txtTvConAdd.Text.Trim();
            objKYC.TvCustId = txtTvCustId.Text.Trim();
            objKYC.DesBuild = ddlDesBuild.SelectedValue.ToString();
            objKYC.BspName = txtBspName.Text.Trim();
            objKYC.Building = ddlBuilding.SelectedValue.ToString();
            objKYC.IfNamePLate = txtIfNamePLate.Text.Trim();
            objKYC.NameOfficer = txtNameOfficer.Text.Trim();
            objKYC.SiteVerifier = txtSiteVerifier.Text.Trim();
            objKYC.Sign1 = txtSign1.Text.Trim();
            objKYC.Sign2 = txtSign2.Text.Trim();
            objKYC.Sign3 = txtSign3.Text.Trim();
            objKYC.Sign4 = txtSign4.Text.Trim();
            objKYC.Sign5 = txtSign5.Text.Trim();
            objKYC.Sign6 = txtSign6.Text.Trim();
            objKYC.DesgBO = txtDesgBO.Text.Trim();
            objKYC.Stock = ddlStock.SelectedValue.ToString();

            objKYC.Product = txtProductSold.Text.Trim();
            objKYC.NameOfVerifyAgent = txtLargeCorporate.Text.Trim();
            objKYC.ResidenceAddress = ddlCurrentAcq.SelectedValue.ToString();
            objKYC.ResiPincode = txtBankName.Text.Trim();
            objKYC.ResiTelNo = txtMID.Text.Trim();
            objKYC.ResiLandmark = txtPeriodRelationship.Text.Trim();
            objKYC.PermanentAddress = txtReasonChanges.Text.Trim();
            objKYC.PermanentPincode = ddlNeighFeed.SelectedValue.ToString();
            objKYC.PermanentTelNo = txtNeighbourContact.Text.Trim();
            objKYC.PlaceVisited = txtNeighDesig.Text.Trim();
            objKYC.AreaOfResidence = txtNoOutlets.Text.Trim();
            objKYC.DescriptionOfResi = txtNoTerminals.Text.Trim();
            objKYC.NameOfAccount = ddlCurrentAcqYes.SelectedValue.ToString();

            string sAccOpen = "";
            objKYC.AccOpen = "";
            if (ChkAccOpen.Items.Count > 0)
            {
                foreach (ListItem li in ChkAccOpen.Items)
                {
                    if (li.Selected == true)
                        sAccOpen += li.Value + ",";
                }
            }
            objKYC.AccOpen = sAccOpen.TrimEnd(',');

            string sRetDel = "";
            objKYC.RetDel = "";
            if (ChkRetDel.Items.Count > 0)
            {
                foreach (ListItem li in ChkRetDel.Items)
                {
                    if (li.Selected == true)
                        sRetDel += li.Value + ",";
                }
            }
            objKYC.RetDel = sRetDel.TrimEnd(',');


            //--added by kamal matekar for Hdfc_Liab pdf-----
            objKYC.Locality = ddlLocalityTypeForFemu.SelectedValue.ToString();
            objKYC.DoNeighbourKnowTheCustomerForFemu = ddlDoNeighbourShopsKnowTheCustomer.SelectedValue.ToString();
            objKYC.NameAddressNeighbour = txtAddressOfNeighbour.Text.Trim();
            objKYC.DocVeri = ddlDocVeri.SelectedValue.ToString();
            objKYC.NeighAware = ddlNeighAware.SelectedValue.ToString();
            objKYC.AuthoSign = ddlAuthoSign.SelectedValue.ToString();
            string sBusinessEquipSightedFemu = "";
            if (chkOfficeEquipmentSeen.Items.Count > 0)
            {
                foreach (ListItem li in chkOfficeEquipmentSeen.Items)
                {
                    if (li.Text.Trim() == "Others" && li.Selected == true)
                        sBusinessEquipSightedFemu += li.Value + "," + txtOfficeEquipmentSeenOther.Text.Trim();
                    else
                        if (li.Selected == true)
                            sBusinessEquipSightedFemu += li.Value + ",";
                }
            }
            objKYC.BusinessEquipSightedFemu = sBusinessEquipSightedFemu.TrimEnd(',');

            ////ended
            //Added by Manoj for....indusand bank
            objKYC.Confirmationaddress = ddlconfirmation.SelectedValue.ToString();
            objKYC.Thiredpartyconfirmation = ddlThiredparty.SelectedValue.ToString();

            objKYC.MetToapplicant = ddlMettoapplicant.SelectedValue.ToString();
            objKYC.Rationcardavailable = ddlRationcardavailable.SelectedValue.ToString();
            //Ended by Manoj

            //Added by hemangi kambli on 03/10/2007 
            if (hdnTransStart.Value != "")
                objKYC.TransStart = Convert.ToDateTime(hdnTransStart.Value);
            objKYC.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
            objKYC.CentreId = Session["CentreId"].ToString();
            objKYC.ProductId = Session["ProductId"].ToString();
            objKYC.ClientId = Session["ClientId"].ToString();
            objKYC.UserId = Session["UserId"].ToString();
            ///------------------------------------------------------
            //added by kamal matekar....
            objKYC.InsertKYCVerificationDetailEntry();
            //ended
            sMsg = objKYC.InsertKYCVerificationEntry();
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
        catch (Exception ex)
        {
            pnlMsg.Visible = true;
            tblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("KYC_VerificationView.aspx?Msg=" + lblMsg.Text);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_VerificationView.aspx");
    }

    private void FillStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objKYC.GetCaseStatus();
        ddlStatus.DataTextField = "STATUS_NAME";
        ddlStatus.DataValueField = "CASE_STATUS_ID";
        ddlStatus.DataSource = dtStatus;
        ddlStatus.DataBind();

        //ListItem lstItem1 = new ListItem("NA", "");
        //ddlStatus.Items.Insert(0, lstItem1);
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
                    objPlaceHolder = (PlaceHolder)(tblKYCVerification.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblKYCVerification.Rows[1].Cells[0].FindControl(strPanelName));
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
            case "CA":
                lbCA.Visible = true;
                break;

        }

    }

    protected void lbRV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_RV_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=1&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }

    protected void lbBV_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_BUSINESS_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=2&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }

    protected void lbCA_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CA_VERI.aspx?CaseID=" + hidCaseID.Value + "&VerTypeId=19&VerificationTypeCode=" + hidVerificationTypeCode.Value + "&Mode=View");
    }

    private void ReadOnly()
    {
        ddlThiredparty.Enabled = false;
        ddlconfirmation.Enabled = false;
        txtRefNo.Enabled = false;
        txtInitiationDate.Enabled = false;
        txtAppName.Enabled = false;
        ddlStatus.Enabled = false;
        txtDate1.Enabled = false;
        txtTime1.Enabled = false;
        ddlTimeType1.Enabled = false;
        txtRemark1.Enabled = false;
        txtDate2.Enabled = false;
        txtTime2.Enabled = false;
        ddlTimeType2.Enabled = false;
        txtRemark2.Enabled = false;
        txtDate3.Enabled = false;
        txtTime3.Enabled = false;
        ddlTimeType3.Enabled = false;
        txtRemark3.Enabled = false;
        txtSupervisorDate.Enabled = false;
        txtSupervisorTime.Enabled = false;
        ddlSupervisorTimeType.Enabled = false;
        txtVerifierDate.Enabled = false;
        txtVerifierTime.Enabled = false;
        ddlVerifierTimeType.Enabled = false;
        ddlproperietorpartener.Enabled = false;
        txtRemark.Enabled = false;
        ddlLocatingAddress.Enabled = false;
        txtSupervisorName.Enabled = false;
        ddlCompanyType.Enabled = false;
        txtNameOfFirm.Enabled = false;
        txtBusinessAddress.Enabled = false;
        txtBusinessPincode.Enabled = false;
        txtBusinessTelNo.Enabled = false;
        ddlContactPerson.Enabled = false;
        txtIfOtherProvideDetail.Enabled = false;
        txtNameOfPersonContacted.Enabled = false;
        txtDesignation.Enabled = false;
        ddlPremiseLocation.Enabled = false;
        txtProminentLandmark.Enabled = false;
        ddlAddressVerifiedIs.Enabled = false;
        txtHowLongInBusiness.Enabled = false;
        txtAreaPremises.Enabled = false;
        ddlOwnershipOfPremises.Enabled = false;
        txtIfOtherPlzSpecify.Enabled = false;
        ddlTypeOfPremise.Enabled = false;
        txtOtherTypeOfPremise.Enabled = false;
        ddlNatureOfBusiness.Enabled = false;
        txtNatureBuss.Enabled = false;  
        ddlFirmSignBoardSighted.Enabled = false;
        txtSignBoardSightedRemark.Enabled = false;
        ddlTypeOfDocSighted.Enabled = false;
        txtIfOtherDocSightedRemark.Enabled = false;
        txtUsedPageSightDate.Enabled = false;
        txtIssuedTo.Enabled = false;
        txtInitialInvoiceSightedNo.Enabled = false;
        txtInitialInvoiceSightedDate.Enabled = false;
        txtInitialInvoiceSightedIssuedTo.Enabled = false;
        txtThirdPartyInvoiceNo.Enabled = false;
        txtThirdPartyInvoiceDate.Enabled = false;
        txtThirdPartyInvoiceIssuedBy.Enabled = false;
        txtThirdPartyAddress.Enabled = false;
        ddlRelationshipBtnEntity.Enabled = false;
        txtIfOtherRelationship.Enabled = false;
        ddlBusinessOwnership.Enabled = false;
        ddlBusinessOwnership.Enabled = false;
        ddlCityLimit.Enabled = false;  
        txtplsSpecify.Enabled = false;
        ddlLevelOfBusinessActivity.Enabled = false;
        txtNoOfEmployee.Enabled = false;
        chklBusinessEquipSighted.Enabled = false;
        txtIfOtherBusinessEquipment.Enabled = false;
        ddlMaritalStatus.Enabled = false;
        ddlNamePlateDisplay.Enabled = false;
        txtRelationshipWithApp.Enabled = false;
        txtStayingSinceAtResi.Enabled = false;
        ddlStatusOfDematAcct.Enabled = false;
        txtNameOfDematAcct.Enabled = false;
        txtDoBrokeOtherThanSSKI.Enabled = false;
        ddlAttituteOfContactPerson.Enabled = false;
        ddlRating.Enabled = false;
        txtEmail.Enabled = false;
        txtNameOnSignBoard.Enabled = false;
        ddlProprietorPartner.Enabled = false;
        txtName.Enabled = false;
        ddlFamilyMemberIs.Enabled = false;
        txtNameIs.Enabled = false;
        txtRelationshipIs.Enabled = false;
        ddlHavingDematAcwithOtherInstitution.Enabled = false;
        txtIfYesThenNameOfDP.Enabled = false;
        ddlEntityType.Enabled = false;
        txtNoOfYearsInCurrentEmployment.Enabled = false;
        ddlHavingSMEAccountWithOtherInstitution.Enabled = false;
        txtNameOfInstitution.Enabled = false;
        txtPersonContacted.Enabled = false;
        ddlbusinessActivity.Enabled = false;
        txtVerifierName.Enabled = false;
        txtRefNo.Enabled = false;
        txtAppName.Enabled = false;
        txtAddress.Enabled = false;
        txtInitiationDate.Enabled = false;
        txtDOB.Enabled = false;
        txtPhone.Enabled = false;
        txtMobile.Enabled = false;
        btnSubmit.Enabled = false;
        btnCancel.Enabled = false;
        ddlTrigSVR.Enabled = false;
        txtBranchCode.Enabled = false;
        txtBranchName.Enabled = false;
        txtRmName.Enabled = false;
        txtRmCode.Enabled = false;
        txtAccountNo.Enabled = false;
        txtNameOfPersonContacted.Enabled = false;
        txtHowLongInBusiness.Enabled = false;
        ddlRmFormat.Enabled = false;
        ddlBllCase.Enabled = false;
        ddlBllSvr.Enabled = false;
        txtNocName.Enabled = false;
        txtTvTele.Enabled = false;
        txtTvPerson.Enabled = false;
        txtTvRelation.Enabled = false;
        txtTvConAdd.Enabled = false;
        txtTvCustId.Enabled = false;
        ddlDesBuild.Enabled = false;
        txtBspName.Enabled = false;
        ddlBuilding.Enabled = false;
        txtIfNamePLate.Enabled = false;
        txtNameOfficer.Enabled = false;
        txtSiteVerifier.Enabled = false;
        txtSign1.Enabled = false;
        txtSign2.Enabled = false;
        txtSign3.Enabled = false;
        txtSign4.Enabled = false;
        txtSign5.Enabled = false;
        txtSign6.Enabled = false;
        txtDesgBO.Enabled = false;
        txtProductSold.Enabled = false;
        txtLargeCorporate.Enabled = false;
        ddlCurrentAcq.Enabled = false;
        txtBankName.Enabled = false;
        txtMID.Enabled = false;
        txtPeriodRelationship.Enabled = false;
        txtReasonChanges.Enabled = false;
        ddlNeighFeed.Enabled = false;
        txtNeighbourContact.Enabled = false;
        txtNeighDesig.Enabled = false;
        txtNoOutlets.Enabled = false;
        txtNoTerminals.Enabled = false;
        ddlCurrentAcqYes.Enabled = false;
        ddlStock.Enabled = false;
        ddlLocalityType.Enabled = false;
        ddlLocalityTypeForFemu.Enabled = false;
        txtAddressOfNeighbour.Enabled = false;
        txtoverallRemark.Enabled = false;

        txtwebsite.Enabled = false;
        txtCompRegiCheckSince.Enabled = false;
        txtCompRegiCheckSinceRegNo.Enabled = false;
        txtCompRegiCheckRemark.Enabled = false;
        txtLocProfile.Enabled = false;
        txtbldgProfile.Enabled = false;
        txtFlrProfile.Enabled = false;
        txtFlrProfileLeftNeigh.Enabled = false;
        txtFlrProfileFlrAb.Enabled = false;
        txtFlrProfileFlrBl.Enabled = false;
        txtNameBoardOutOffice.Enabled = false;
        txtNameBoardLobbyArea.Enabled = false;
        txtAssoCompany.Enabled = false;
        txtGenInterior.Enabled = false;
        txtNoWorkstations.Enabled = false;
        txtOwnerCabin.Enabled = false;
        txtlandloard.Enabled = false;
        txtProperyResi.Enabled = false;
        txtProperyComm.Enabled = false;
        txtProperyShop.Enabled = false;

        ddlMettoapplicant.Enabled = false;
        ddlRationcardavailable.Enabled = false; 
    }
}
