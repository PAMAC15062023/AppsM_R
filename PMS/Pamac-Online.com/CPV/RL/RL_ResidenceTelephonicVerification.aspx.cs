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

public partial class CPV_RL_RL_ResidenceTelephonicVerification : System.Web.UI.Page
{
    CRL_TelephonicVerification objTeleVer = new CRL_TelephonicVerification();
    CGet objCGet = new CGet();
    CCommon objComm = new CCommon();
    string verificationType = "RT";
    protected void Page_Init(object sender, EventArgs e)
    {
        funShowPanel();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (!IsPostBack)
        {
            //To Show the Panels add By Manoj            
            funShowPanel();
            hdnTransStart.Value = DateTime.Now.ToString();//"dd/MM/yyyy hh:mm:ss tt");
            if ((Request.QueryString["CaseID"] != null) && (Request.QueryString["CaseID"] != ""))
            {
                if (Session["isEdit"].ToString() != "1")
                {


                }

                hidCaseID.Value = Request.QueryString["CaseID"].ToString();
                Session["CaseID"] = hidCaseID.Value;

            }
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
            txtDate1stCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate2ndCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate3rdCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate4thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDate5thCall.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillRatingStatus();
            GetTelephonicVerification();
            GetTelephonicVerification_New();
            GetCaseDetail();
            GetResiCaseDetail();
            FillTelecallerName();
            GetTeleCallLog();
            if (hidMode.Value == "View")
            {
                IfIsEditFalse();
                LikButtonVisibility();
            }
        }
    }
       
    private void GetTeleCallLog()
    {
        DataSet dsTeleCallLog = new DataSet();
        string sCaseId = hidCaseID.Value;
        if (sCaseId != "")
        {
            dsTeleCallLog = objTeleVer.GetTeleCallLogDetail(sCaseId, hidVerificationTypeID.Value);
            if (dsTeleCallLog.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsTeleCallLog.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime1stCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime1stCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo1stCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks1stCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 1)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime2ndCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime2ndCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo2ndCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks2ndCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 2)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime3rdCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime3rdCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo3rdCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks3rdCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 3)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime4thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime4thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo4thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks4thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                    if (i == 4)
                    {
                        string sAttemptDateTime = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Datetime"].ToString();
                        string[] arrAttemptDateTime = sAttemptDateTime.Split(' ');
                        txtDate5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[0].ToString()).ToString("dd/MM/yyyy");
                        txtTime5thCall.Text = Convert.ToDateTime(arrAttemptDateTime[1].ToString()).ToString("hh:mm");
                        ddlTime5thCall.SelectedValue = arrAttemptDateTime[2].ToString();
                        txtTelNo5thCall.Text = dsTeleCallLog.Tables[0].Rows[i]["TELEPHONE_NO"].ToString();
                        ddlRemarks5thCall.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["Attempt_Remark"].ToString();
                        ddlTeleCallersName.SelectedValue = dsTeleCallLog.Tables[0].Rows[i]["VERIFIER_ID"].ToString();
                    }
                }
            }
        }

    }

    private void GetTelephonicVerification()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetResiTelephonicVerification(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            //New added/Updated for CHOLA
            if (!(oledbDR["ApplicationDate"].ToString().Trim().Length.Equals(0)))
                txtApplicationDate.Text = oledbDR["ApplicationDate"].ToString();

            if (!(oledbDR["IFRented"].ToString().Trim().Length.Equals(0)))
                txtRentAmount.Text = oledbDR["IFRented"].ToString();

            if (!(oledbDR["Less1YrAddr"].ToString().Trim().Length.Equals(0)))
                txtLessthan1.Text = oledbDR["Less1YrAddr"].ToString();

            if (!(oledbDR["Is_address_same"].ToString().Trim().Length.Equals(0)))
                ddlAddressDifferent.SelectedValue = oledbDR["Is_address_same"].ToString();

            if (!(oledbDR["AddrDiffConf"].ToString().Trim().Length.Equals(0)))
                txtAddrDiffConf.Text = oledbDR["AddrDiffConf"].ToString();

            if (!(oledbDR["Name_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtRefName.Text = oledbDR["Name_Neighbour1"].ToString();

            if (!(oledbDR["Name_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtRef2Name.Text = oledbDR["Name_Neighbour2"].ToString();

            if (!(oledbDR["Telephone_Exists"].ToString().Trim().Length.Equals(0)))
                ddlTelephoneExist.SelectedValue = oledbDR["Telephone_Exists"].ToString();

            if (!(oledbDR["Tele_whose_Name"].ToString().Trim().Length.Equals(0)))
                txtTeleWhoseName.Text = oledbDR["Tele_whose_Name"].ToString();

            if (!(oledbDR["AddressCDROM"].ToString().Trim().Length.Equals(0)))
                txtAdderssCDROM.Text = oledbDR["AddressCDROM"].ToString();

            if (!(oledbDR["Dedupe_check"].ToString().Trim().Length.Equals(0)))
                ddlDedupe.SelectedValue = oledbDR["Dedupe_check"].ToString();

            if (!(oledbDR["CustomerCIFL"].ToString().Trim().Length.Equals(0)))
                ddlCustomerCIFL.SelectedValue = oledbDR["CustomerCIFL"].ToString();
            //END for CHOLA

            if (!(oledbDR["TEL_NO_TYPE_PHONE"].ToString().Trim().Length.Equals(0)))
                txtContactedNo.Text = oledbDR["TEL_NO_TYPE_PHONE"].ToString();

            if (!(oledbDR["Address_Confirmed"].ToString().Trim().Length.Equals(0)))
                ddlPersonContactedatResidencetelephoneConfirms.SelectedValue = oledbDR["Address_Confirmed"].ToString();

            if (!(oledbDR["PERSON_CONTACTED"].ToString().Trim().Length.Equals(0)))
                txtPersonContacted.Text = oledbDR["PERSON_CONTACTED"].ToString();

            if (!(oledbDR["Relationship"].ToString().Trim().Length.Equals(0)))
                txtRelationshipwithApplicant.Text = oledbDR["Relationship"].ToString();

            if (!(oledbDR["Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddressasperCall.Text = oledbDR["Address"].ToString();

            if (!(oledbDR["YEARS_AT_RESIDENCE"].ToString().Trim().Length.Equals(0)))
                txtNumberofYearsatResidence.Text = oledbDR["YEARS_AT_RESIDENCE"].ToString();

            if (!(oledbDR["Company_name"].ToString().Trim().Length.Equals(0)))
                txtNameOftheEmployer.Text = oledbDR["Company_name"].ToString();

            if (!(oledbDR["Permanent_address"].ToString().Trim().Length.Equals(0)))
                txtPermanentAddress.Text = oledbDR["Permanent_address"].ToString();

            if (!(oledbDR["Verifier_Comments"].ToString().Trim().Length.Equals(0)))
                txtOverallRemarks.Text = oledbDR["Verifier_Comments"].ToString();

            if (!(oledbDR["Verification_status"].ToString().Trim().Length.Equals(0)))
                ddlRating.SelectedValue = oledbDR["Verification_status"].ToString();

            if (!(oledbDR["Staying_Since"].ToString().Trim().Length.Equals(0)))
                txtStayingSince.Text = oledbDR["Staying_Since"].ToString();

            if (!(oledbDR["VERIFICATION_DATETIME"].ToString().Trim().Length.Equals(0)))
            {

                string sVerification = oledbDR["VERIFICATION_DATETIME"].ToString();
                if (sVerification != string.Empty)
                {
                    string[] sarrayVerification = sVerification.Split(' ');
                    if (sarrayVerification[0].ToString() != "")
                    {
                        txtDateOfVerification.Text = Convert.ToDateTime(sarrayVerification[0].ToString()).ToString("dd/MM/yyyy");
                    }
                    if (sarrayVerification[1].ToString() != "")
                    {
                        txtVerificationTime.Text = Convert.ToDateTime(sarrayVerification[1].ToString()).ToString("hh:mm");
                    }

                    ddlVerificationTimeType.SelectedValue = sarrayVerification[2].ToString();

                }

            }

            if (!(oledbDR["Area"].ToString().Trim().Length.Equals(0)))
                txtArea.Text = oledbDR["Area"].ToString();

            if (!(oledbDR["Unsatisfactory_Reason"].ToString().Trim().Length.Equals(0)))
                txtProvidereasonforunsatisfactoryrating.Text = oledbDR["Unsatisfactory_Reason"].ToString();
//Naresh 16/06/2008 Start
        if (!(oledbDR["Staying_Whom"].ToString().Trim().Length.Equals(0)))
            txtStaying.Text = oledbDR["Staying_Whom"].ToString();

        if (!(oledbDR["PP_Number"].ToString().Trim().Length.Equals(0)))
            txtPPNo.Text = oledbDR["PP_Number"].ToString();

        if (!(oledbDR["Any_Other_Resi_Phone"].ToString().Trim().Length.Equals(0)))
            txtAnyotherResiPhoneNo.Text = oledbDR["Any_Other_Resi_Phone"].ToString();

        if (!(oledbDR["Applicant_Availbility"].ToString().Trim().Length.Equals(0)))
            txtAppAvailable.Text = oledbDR["Applicant_Availbility"].ToString();

        if (!(oledbDR["Dir_Check"].ToString().Trim().Length.Equals(0)))
            txtDirectoryCheck.Text = oledbDR["Dir_Check"].ToString();

        if (!(oledbDR["Name_of_Applicant_Conf"].ToString().Trim().Length.Equals(0)))
            ddlNameofApplicantConfirmedatgivenPhoneNo.Text  = oledbDR["Name_of_Applicant_Conf"].ToString();

        if (!(oledbDR["Mismatch_Add_Tel"].ToString().Trim().Length.Equals(0)))
            ddlMismatchedInAddTelNo.Text = oledbDR["Mismatch_Add_Tel"].ToString();

            if (!(oledbDR["loan_amount"].ToString().Trim().Length.Equals(0)))
                txtNameoftheApplicant.Text = oledbDR["loan_amount"].ToString();

 ////////////////add new field for Deutch bank for santosh 14-july-2010/////////////////////////////
            if (!(oledbDR["Name_CoApp"].ToString().Trim().Length.Equals(0)))
                txtNameCoApp.Text = oledbDR["Name_CoApp"].ToString();

            if (!(oledbDR["Co_AppDob"].ToString().Trim().Length.Equals(0)))
                txtCoAppDob.Text = oledbDR["Co_AppDob"].ToString();

            if (!(oledbDR["Address_Confirmed_New"].ToString().Trim().Length.Equals(0)))
                ddlAddConf.SelectedValue = oledbDR["Address_Confirmed_New"].ToString();

            if (!(oledbDR["Address_New"].ToString().Trim().Length.Equals(0)))
                txtNewHomeAddress.Text = oledbDR["Address_New"].ToString();

            if (!(oledbDR["Type_of_House"].ToString().Trim().Length.Equals(0)))
                ddlResiType.SelectedValue = oledbDR["Type_of_House"].ToString();

            if (!(oledbDR["Tran_Date"].ToString().Trim().Length.Equals(0)))
                ddlTranType.SelectedValue = oledbDR["Tran_Date"].ToString();

            if (!(oledbDR["Area_of_House"].ToString().Trim().Length.Equals(0)))
                txtApproxArea.Text = oledbDR["Area_of_House"].ToString();

            if (!(oledbDR["Total_cost"].ToString().Trim().Length.Equals(0)))
                txtTotalCost.Text = oledbDR["Total_cost"].ToString();

            if (!(oledbDR["loan_Amt_New"].ToString().Trim().Length.Equals(0)))
                txtLoanAmt.Text = oledbDR["loan_Amt_New"].ToString();

            if (!(oledbDR["Prop_Brought"].ToString().Trim().Length.Equals(0)))
                ddlPropBought.SelectedValue = oledbDR["Prop_Brought"].ToString();

            if (!(oledbDR["Relantion_prop"].ToString().Trim().Length.Equals(0)))
                ddlRelantionProp.SelectedValue = oledbDR["Relantion_prop"].ToString();

            if (!(oledbDR["Other_Prop"].ToString().Trim().Length.Equals(0)))
                txtOtherProp.Text = oledbDR["Other_Prop"].ToString();

            if (!(oledbDR["Name_Guran1"].ToString().Trim().Length.Equals(0)))
                txtNameGuran1.Text = oledbDR["Name_Guran1"].ToString();

            if (!(oledbDR["ContactResi1"].ToString().Trim().Length.Equals(0)))
                txtContactR1.Text = oledbDR["ContactResi1"].ToString();

            if (!(oledbDR["ContactOff1"].ToString().Trim().Length.Equals(0)))
                txtContactO1.Text = oledbDR["ContactOff1"].ToString();

            if (!(oledbDR["PersonCont1"].ToString().Trim().Length.Equals(0)))
                txtPersonCont1.Text = oledbDR["PersonCont1"].ToString();

            if (!(oledbDR["RelanApp1"].ToString().Trim().Length.Equals(0)))
                txtRelanApp1.Text = oledbDR["RelanApp1"].ToString();

            if (!(oledbDR["Relationship1"].ToString().Trim().Length.Equals(0)))
                txtRelationship1.Text = oledbDR["Relationship1"].ToString();

            if (!(oledbDR["AddGurent1"].ToString().Trim().Length.Equals(0)))
                txtAddGurent1.Text = oledbDR["AddGurent1"].ToString();

            if (!(oledbDR["howLong1"].ToString().Trim().Length.Equals(0)))
                txthowLong1.Text = oledbDR["howLong1"].ToString();

            if (!(oledbDR["ReadyGua1"].ToString().Trim().Length.Equals(0)))
                ddlReadyGua1.SelectedValue = oledbDR["ReadyGua1"].ToString();

            if (!(oledbDR["BeenGua1"].ToString().Trim().Length.Equals(0)))
                ddlBeenGua1.SelectedValue = oledbDR["BeenGua1"].ToString();

            if (!(oledbDR["Status1"].ToString().Trim().Length.Equals(0)))
                ddlStatus1.SelectedValue = oledbDR["Status1"].ToString();

            if (!(oledbDR["Name_Guran2"].ToString().Trim().Length.Equals(0)))
                txtNameGuran2.Text = oledbDR["Name_Guran2"].ToString();

            if (!(oledbDR["ContactResi2"].ToString().Trim().Length.Equals(0)))
                txtContactR2.Text = oledbDR["ContactResi2"].ToString();

            if (!(oledbDR["ContactOff2"].ToString().Trim().Length.Equals(0)))
                txtContactO2.Text = oledbDR["ContactOff2"].ToString();

            if (!(oledbDR["PersonCont2"].ToString().Trim().Length.Equals(0)))
                txtPersonCont2.Text = oledbDR["PersonCont2"].ToString();

            if (!(oledbDR["RelanApp2"].ToString().Trim().Length.Equals(0)))
                txtRelanApp2.Text = oledbDR["RelanApp2"].ToString();

            if (!(oledbDR["Relationship2"].ToString().Trim().Length.Equals(0)))
                txtRelationship2.Text = oledbDR["Relationship2"].ToString();

            if (!(oledbDR["AddGurent2"].ToString().Trim().Length.Equals(0)))
                txtAddGurent2.Text = oledbDR["AddGurent2"].ToString();

            if (!(oledbDR["howLong2"].ToString().Trim().Length.Equals(0)))
                txthowLong2.Text = oledbDR["howLong2"].ToString();

            if (!(oledbDR["ReadyGua2"].ToString().Trim().Length.Equals(0)))
                ddlReadyGua2.SelectedValue = oledbDR["ReadyGua2"].ToString();

            if (!(oledbDR["BeenGua2"].ToString().Trim().Length.Equals(0)))
                ddlBeenGua2.SelectedValue = oledbDR["BeenGua2"].ToString();

            if (!(oledbDR["Status2"].ToString().Trim().Length.Equals(0)))
                ddlStatus2.SelectedValue = oledbDR["Status2"].ToString();

            if (!(oledbDR["other_feedback"].ToString().Trim().Length.Equals(0)))
                txtAdditionalRemark.Text = oledbDR["other_feedback"].ToString();

            if (!(oledbDR["SUPERVISOR_COMMENTS"].ToString().Trim().Length.Equals(0)))
                txtNewInfoObt.Text = oledbDR["SUPERVISOR_COMMENTS"].ToString();

            if (!(oledbDR["Off_Tel_No"].ToString().Trim().Length.Equals(0)))
                txtOfficePhoneNoExtn.Text = oledbDR["Off_Tel_No"].ToString();

            if (!(oledbDR["SPOUSE_DETAILS"].ToString().Trim().Length.Equals(0)))
                txtSpouseWorking.Text = oledbDR["SPOUSE_DETAILS"].ToString();

            if (!(oledbDR["Dob"].ToString().Trim().Length.Equals(0)))
                txtInitiationDate.Text = oledbDR["Dob"].ToString();

            if (!(oledbDR["Type"].ToString().Trim().Length.Equals(0)))
                ddlResiIs.SelectedValue = oledbDR["Type"].ToString();
/////////////////end code//////////////////////////////////////////////////////////////////////////
//Naresh 16/06/2008 End




            // Added By Rupesh On 03/05/2013

            if (!(oledbDR["Response"].ToString().Trim().Length.Equals(0)))
                ddlResponse.SelectedValue = oledbDR["Response"].ToString();

            if (!(oledbDR["Status"].ToString().Trim().Length.Equals(0)))
                ddlstatus.SelectedValue = oledbDR["Status"].ToString();

            if (!(oledbDR["Reason"].ToString().Trim().Length.Equals(0)))
                ddlReason.SelectedValue = oledbDR["Reason"].ToString();

            if (!(oledbDR["personcontactedRL"].ToString().Trim().Length.Equals(0)))
                ddlpersoncontactedRL.SelectedValue = oledbDR["personcontactedRL"].ToString();

            if (!(oledbDR["Resvertyp"].ToString().Trim().Length.Equals(0)))
                ddlResvertyp.SelectedValue = oledbDR["Resvertyp"].ToString();

            if (!(oledbDR["Agency"].ToString().Trim().Length.Equals(0)))
                ddlAgency.SelectedValue = oledbDR["Agency"].ToString();

            // Added By Rupesh On 03/05/2013



            }
        oledbDR.Close();
    }

    private void GetTelephonicVerification_New()  //busi
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetResiTelephonicVerification_New(hidCaseID.Value, hidVerificationTypeID.Value);
        if (oledbDR.Read())
        {
            //New added/Updated for CHOLA
            if (!(oledbDR["Neighbour1_Comments"].ToString().Trim().Length.Equals(0)))
                txtRef1Comments.Text = oledbDR["Neighbour1_Comments"].ToString();

            if (!(oledbDR["Neighbour_Telephone2"].ToString().Trim().Length.Equals(0)))
                txtRef2Telephone.Text = oledbDR["Neighbour_Telephone2"].ToString();

            if (!(oledbDR["Neighbour2_confirmation"].ToString().Trim().Length.Equals(0)))
                txtRef2Relantionship.Text = oledbDR["Neighbour2_confirmation"].ToString();

            if (!(oledbDR["Neighbour2_Comments"].ToString().Trim().Length.Equals(0)))
                txtRef2Comments.Text = oledbDR["Neighbour2_Comments"].ToString();

            //END for CHOLA

            if (!(oledbDR["Name_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtRefName.Text = oledbDR["Name_Neighbour1"].ToString();
            
            if (!(oledbDR["Address_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtRefTel.Text = oledbDR["Address_Neighbour1"].ToString();

            if (!(oledbDR["Neighbour1_confirmation"].ToString().Trim().Length.Equals(0)))
                txtRelRef.Text = oledbDR["Neighbour1_confirmation"].ToString();

            if (!(oledbDR["Month_at_office"].ToString().Trim().Length.Equals(0)))
                txtKnowGua.Text = oledbDR["Month_at_office"].ToString();

            if (!(oledbDR["Month_Stay_Resi_Neigh1"].ToString().Trim().Length.Equals(0)))
                txtKnowRef.Text = oledbDR["Month_Stay_Resi_Neigh1"].ToString();

            if (!(oledbDR["Market_Reputation_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtEmpDetGua.Text = oledbDR["Market_Reputation_Neighbour1"].ToString();

            if (!(oledbDR["Office_self_owned1"].ToString().Trim().Length.Equals(0)))
                txtEmpDetRef.Text = oledbDR["Office_self_owned1"].ToString();

            if (!(oledbDR["Comments_Neighbour1"].ToString().Trim().Length.Equals(0)))
                txtOthLoanGua.Text = oledbDR["Comments_Neighbour1"].ToString();

            if (!(oledbDR["Name_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtOthLoanRef.Text = oledbDR["Name_Neighbour2"].ToString();

            if (!(oledbDR["Address_Neighbour2"].ToString().Trim().Length.Equals(0)))
                txtLibGua.Text = oledbDR["Address_Neighbour2"].ToString();

           if (!(oledbDR["Neighbour1_confirmation2"].ToString().Trim().Length.Equals(0)))
               txtLibRef.Text = oledbDR["Neighbour1_confirmation2"].ToString();

            if (!(oledbDR["Month_at_office1"].ToString().Trim().Length.Equals(0)))
                txtEmiGua.Text = oledbDR["Month_at_office1"].ToString();
            
            if (!(oledbDR["Month_Stay_Resi_Neigh2"].ToString().Trim().Length.Equals(0)))
                txtEmiRef.Text = oledbDR["Month_Stay_Resi_Neigh2"].ToString();

            if (!(oledbDR["Agency_Code"].ToString().Trim().Length.Equals(0)))
                txtAgencyCode.Text = oledbDR["Agency_Code"].ToString();

            if (!(oledbDR["Months_work_current_office"].ToString().Trim().Length.Equals(0)))
                txtTimeCurrentEmploymentYrs.Text = oledbDR["Months_work_current_office"].ToString();

            if (!(oledbDR["Person_contacted"].ToString().Trim().Length.Equals(0)))
                txtNameOfPersonContacted.Text = oledbDR["Person_contacted"].ToString();

            if (!(oledbDR["Ward"].ToString().Trim().Length.Equals(0)))
                txtRegion.Text = oledbDR["Ward"].ToString();

            if (!(oledbDR["TaxCal"].ToString().Trim().Length.Equals(0)))
                txtEarningMembers.Text = oledbDR["TaxCal"].ToString();

            if (!(oledbDR["TaxCalcu"].ToString().Trim().Length.Equals(0)))
                txtDependents.Text = oledbDR["TaxCalcu"].ToString();

            if (!(oledbDR["TaxPaid"].ToString().Trim().Length.Equals(0)))
                txtParenteDetails.Text = oledbDR["TaxPaid"].ToString();

            if (!(oledbDR["TazPay"].ToString().Trim().Length.Equals(0)))
                txtReasonDecline.Text = oledbDR["TazPay"].ToString();

            if (!(oledbDR["SpouseDesg"].ToString().Trim().Length.Equals(0)))
                txtDesignation.Text = oledbDR["SpouseDesg"].ToString();

            if (!(oledbDR["Office_Name"].ToString().Trim().Length.Equals(0)))
                txtNameOfCompany.Text = oledbDR["Office_Name"].ToString();
            //add by Manoj Jadhav for yesbank auto loan
            if (!(oledbDR["LoanApplied"].ToString().Trim().Length.Equals(0)))
                txtNameOfCompany.Text = oledbDR["LoanApplied"].ToString();

            if (!(oledbDR["NoOfwhichTVRdone"].ToString().Trim().Length.Equals(0)))
                txtNameOfCompany.Text = oledbDR["NoOfwhichTVRdone"].ToString();



            
        }
        oledbDR.Close();
    }

    private void GetResiCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetResiCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["RES_PHONE"].ToString().Trim().Length.Equals(0)))
                txtResidentPhoneNo.Text = oledbDR["RES_PHONE"].ToString();

            if (!(oledbDR["OFF_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameOftheEmployer.Text = oledbDR["OFF_NAME"].ToString();

            if (!(oledbDR["Residence_Address"].ToString().Trim().Length.Equals(0)))
                txtResidenceAddressasperApplication.Text = oledbDR["Residence_Address"].ToString();


        }
        oledbDR.Close();
    }

    private void GetCaseDetail()
    {
        OleDbDataReader oledbDR;
        oledbDR = objTeleVer.GetCaseDetail(hidCaseID.Value);
        if (oledbDR.Read())
        {
            if (!(oledbDR["FULL_NAME"].ToString().Trim().Length.Equals(0)))
                txtNameoftheApplicant.Text = oledbDR["FULL_NAME"].ToString();

            if (!(oledbDR["REF_NO"].ToString().Trim().Length.Equals(0)))
                txtRefNo.Text = oledbDR["REF_NO"].ToString();

            if (!(oledbDR["App_Type"].ToString().Trim().Length.Equals(0)))
                ddlAppType.SelectedItem.Text = oledbDR["App_Type"].ToString();

            //if (!(oledbDR["Off_Name"].ToString().Trim().Length.Equals(0)))
            //    txtNameOfCompany.Text = oledbDR["Off_Name"].ToString();                      
            
            if (!(oledbDR["DEPARTMENT"].ToString().Trim().Length.Equals(0)))
                txtDept.Text = oledbDR["DEPARTMENT"].ToString();

            if (!(oledbDR["DOB"].ToString().Trim().Length.Equals(0)))
                txtDOBApp.Text = oledbDR["DOB"].ToString();

        }
        oledbDR.Close();
    }
       
    private void InsertTeleCallLog()
    {


        try
        {
            ArrayList arrTeleCallLog = new ArrayList();
            ArrayList arrLog1stCall = new ArrayList();
            ArrayList arrLog2ndCall = new ArrayList();
            ArrayList arrLog3rdCall = new ArrayList();
            ArrayList arrLog4thCall = new ArrayList();
            ArrayList arrLog5thCall = new ArrayList();

            string strCaseID = hidCaseID.Value;
            objTeleVer.CaseID = strCaseID;


            objTeleVer.VerificationType = "RVT";
            CCommon objCom = new CCommon();
            if (txtDate1stCall.Text.Trim() != "" && txtTime1stCall.Text.Trim() != "")
            {
                arrLog1stCall.Clear();
                arrLog1stCall.Add(objCom.strDate(txtDate1stCall.Text.Trim()) + " " + txtTime1stCall.Text.Trim() + " " + ddlTime1stCall.SelectedItem.Text.Trim());
                arrLog1stCall.Add(ddlRemarks1stCall.SelectedValue.ToString());
                arrLog1stCall.Add(txtTelNo1stCall.Text.Trim());
                arrLog1stCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog1stCall);
            }

            if (txtDate2ndCall.Text.Trim() != "" && txtTime2ndCall.Text.Trim() != "")
            {
                arrLog2ndCall.Clear();
                arrLog2ndCall.Add(objCom.strDate(txtDate2ndCall.Text.Trim()) + " " + txtTime2ndCall.Text.Trim() + " " + ddlTime2ndCall.SelectedItem.Text.Trim());
                arrLog2ndCall.Add(ddlRemarks2ndCall.SelectedValue.ToString());
                arrLog2ndCall.Add(txtTelNo2ndCall.Text.Trim());
                arrLog2ndCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog2ndCall);
            }

            if (txtDate3rdCall.Text.Trim() != "" && txtTime3rdCall.Text.Trim() != "")
            {
                arrLog3rdCall.Clear();
                arrLog3rdCall.Add(objCom.strDate(txtDate3rdCall.Text.Trim()) + " " + txtTime3rdCall.Text.Trim() + " " + ddlTime3rdCall.SelectedItem.Text.Trim());
                arrLog3rdCall.Add(ddlRemarks3rdCall.SelectedValue.ToString());
                arrLog3rdCall.Add(txtTelNo3rdCall.Text.Trim());
                arrLog3rdCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog3rdCall);
            }
            if (txtDate4thCall.Text.Trim() != "" && txtTime4thCall.Text.Trim() != "")
            {
                arrLog4thCall.Clear();
                arrLog4thCall.Add(objCom.strDate(txtDate4thCall.Text.Trim()) + " " + txtTime4thCall.Text.Trim() + " " + ddlTime4thCall.SelectedItem.Text.Trim());
                arrLog4thCall.Add(ddlRemarks4thCall.SelectedValue.ToString());
                arrLog4thCall.Add(txtTelNo4thCall.Text.Trim());
                arrLog4thCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog4thCall);
            }
            if (txtDate5thCall.Text.Trim() != "" && txtTime5thCall.Text.Trim() != "")
            {
                arrLog5thCall.Clear();
                arrLog5thCall.Add(objCom.strDate(txtDate5thCall.Text.Trim()) + " " + txtTime5thCall.Text.Trim() + " " + ddlTime5thCall.SelectedItem.Text.Trim());
                arrLog5thCall.Add(ddlRemarks5thCall.SelectedValue.ToString());
                arrLog5thCall.Add(txtTelNo5thCall.Text.Trim());
                arrLog5thCall.Add(ddlTeleCallersName.SelectedValue.Trim());
                arrTeleCallLog.Add(arrLog5thCall);
            }

            if (objTeleVer.InsertTeleCallLog(arrTeleCallLog) == 1)
            {


            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error found during Inserting records in TeleCallLog" + ex.Message);

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int iCount = 0;
        string msg = "";
       
        int itemcount =ddlRating.Items.Count;
        try
        {

            PropertySet();
            msg = objTeleVer.InsertResiTelephonicVerification_New();
            msg = objTeleVer.InsertResiTelephonicVerification();
            InsertTeleCallLog();
            iCount = 1;
            lblMessage.Text = msg;
        }
        catch (Exception ex)
        {
            //lblMessage.Visible = true;
            //lblMessage.ForeColor = System.Drawing.Color.Red;
            //lblMessage.Text = "Error:" + ex.Message;
        }
        if (iCount == 1)
        {
            Response.Redirect("RL_VerificationView.aspx?Msg=" + lblMessage.Text);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_VerificationView.aspx");
    }

    private void PropertySet()
    {
        objTeleVer.OwnershipRESIDENCE = "";
        objTeleVer.make = "";
        objTeleVer.loanAmt = "";
        objTeleVer.tenure = "";
        objTeleVer.month = "";
        //objTeleVer.OwnershipRESIDENCE = "";
        //objTeleVer.OwnershipRESIDENCE = "";

        objTeleVer.CaseID = hidCaseID.Value.ToString();
        objTeleVer.VerificationTypeID = hidVerificationTypeID.Value.ToString();
        objTeleVer.ResidencePhoneNo = txtContactedNo.Text.Trim().ToString();
        objTeleVer.PersonContactedResiTeleConfirmsApplicantStaysAddress = ddlPersonContactedatResidencetelephoneConfirms.SelectedValue.ToString();
        objTeleVer.PersonContacted = txtPersonContacted.Text.Trim().ToString();
        objTeleVer.RelationshipWithApplicant = txtRelationshipwithApplicant.Text.Trim().ToString();
        objTeleVer.ResidenceAddressAsPerCall = txtResidenceAddressasperCall.Text.Trim().ToString();
        objTeleVer.NumberofYearsAtResidence = txtNumberofYearsatResidence.Text.Trim().ToString();
        objTeleVer.NameOfEmployer = txtNameOftheEmployer.Text.Trim().ToString();
        objTeleVer.PermanentAddress = txtPermanentAddress.Text.Trim().ToString();
        objTeleVer.OverallRemarks = txtOverallRemarks.Text.Trim().ToString();
        objTeleVer.Rating = ddlRating.SelectedValue.ToString();
        objTeleVer.PerCon = txtNameOfPersonContacted.Text.Trim().ToString();
        objTeleVer.StayingSince = txtStayingSince.Text.Trim().ToString();
        objTeleVer.TelecallersName = ddlTeleCallersName.SelectedValue.ToString();
        objTeleVer.NameApp = txtNameoftheApplicant.Text.Trim().ToString();
        objTeleVer.AddRem = txtAdditionalRemark.Text.Trim().ToString();
        objTeleVer.TeleRemark = txtNewInfoObt.Text.Trim().ToString();

        ///////////////////////add new field for deutch bank by santosh 14-july-2010/////////////////////
        objTeleVer.NameCoApp = txtNameCoApp.Text.Trim().ToString();
        objTeleVer.CoAppDob = txtCoAppDob.Text.Trim().ToString();
        objTeleVer.AddConf = ddlAddConf.SelectedValue.ToString();
        objTeleVer.NewHomeAddress = txtNewHomeAddress.Text.Trim().ToString();
        objTeleVer.ResiType = ddlResiType.SelectedValue.ToString();
        objTeleVer.TranType = ddlTranType.SelectedValue.ToString();
        objTeleVer.ApproxArea = txtApproxArea.Text.Trim().ToString();
        objTeleVer.TotalCost = txtTotalCost.Text.Trim().ToString();
        objTeleVer.LoanAmt = txtLoanAmt.Text.Trim().ToString();
        objTeleVer.PropBought = ddlPropBought.SelectedValue.ToString();
        objTeleVer.RelantionProp = ddlRelantionProp.SelectedValue.ToString();
        objTeleVer.OtherProp = txtOtherProp.Text.Trim().ToString();

        objTeleVer.NameGuran1 = txtNameGuran1.Text.Trim().ToString();
        objTeleVer.ContactR1 = txtContactR1.Text.Trim().ToString();
        objTeleVer.ContactO1 = txtContactO1.Text.Trim().ToString();
        objTeleVer.PersonCont1 = txtPersonCont1.Text.Trim().ToString();
        objTeleVer.RelanApp1 = txtRelanApp1.Text.Trim().ToString();
        objTeleVer.Relationship1 = txtRelationship1.Text.Trim().ToString();
        objTeleVer.AddGurent1 = txtAddGurent1.Text.Trim().ToString();
        objTeleVer.howLong1 = txthowLong1.Text.Trim().ToString();
        objTeleVer.ReadyGua1 = ddlReadyGua1.SelectedValue.ToString();
        objTeleVer.BeenGua1 = ddlBeenGua1.SelectedValue.ToString();
        objTeleVer.Status1 = ddlStatus1.SelectedValue.ToString();

        objTeleVer.NameGuran2 = txtNameGuran2.Text.Trim().ToString();
        objTeleVer.ContactR2 = txtContactR2.Text.Trim().ToString();
        objTeleVer.ContactO2 = txtContactO2.Text.Trim().ToString();
        objTeleVer.PersonCont2 = txtPersonCont2.Text.Trim().ToString();
        objTeleVer.RelanApp2 = txtRelanApp2.Text.Trim().ToString();
        objTeleVer.Relationship2 = txtRelationship2.Text.Trim().ToString();
        objTeleVer.AddGurent2 = txtAddGurent2.Text.Trim().ToString();
        objTeleVer.howLong2 = txthowLong2.Text.Trim().ToString();
        objTeleVer.ReadyGua2 = ddlReadyGua2.SelectedValue.ToString();
        objTeleVer.BeenGua2 = ddlBeenGua2.SelectedValue.ToString();
        objTeleVer.Status2 = ddlStatus2.SelectedValue.ToString();
        objTeleVer.OffTelNo = txtOfficePhoneNoExtn.Text.Trim().ToString();
        objTeleVer.RefName = txtRefName.Text.Trim().ToString();
        objTeleVer.RefTel = txtRefTel.Text.Trim().ToString();
        objTeleVer.RelRef = txtRelRef.Text.Trim().ToString();
        objTeleVer.KnowGua = txtKnowGua.Text.Trim().ToString();
        objTeleVer.KnowRef = txtKnowRef.Text.Trim().ToString();
        objTeleVer.EmpDetGua = txtEmpDetGua.Text.Trim().ToString();
        objTeleVer.EmpDetRef = txtEmpDetRef.Text.Trim().ToString();
        objTeleVer.OthLoanGua = txtOthLoanGua.Text.Trim().ToString();
        objTeleVer.OthLoanRef = txtOthLoanRef.Text.Trim().ToString();
        objTeleVer.LibGua = txtLibGua.Text.Trim().ToString();
        objTeleVer.LibRef = txtLibRef.Text.Trim().ToString();
        objTeleVer.EmiGua = txtEmiGua.Text.Trim().ToString();
        objTeleVer.EmiRef = txtEmiRef.Text.Trim().ToString();
        objTeleVer.CouterDate = txtInitiationDate.Text.Trim().ToString();

        objTeleVer.Agency_Code = txtAgencyCode.Text.Trim().ToString();
        objTeleVer.Months_work_current_office = txtTimeCurrentEmploymentYrs.Text.Trim().ToString();
        objTeleVer.Region = txtRegion.Text.Trim().ToString();
        objTeleVer.EarningMembers = txtEarningMembers.Text.Trim().ToString();
        objTeleVer.Dependents = txtDependents.Text.Trim().ToString();
        objTeleVer.SpouseWorking = txtSpouseWorking.Text.Trim().ToString();
        objTeleVer.ParenteDetails = txtParenteDetails.Text.Trim().ToString();
        objTeleVer.ReasonDecline = txtReasonDecline.Text.Trim().ToString();
        objTeleVer.ResiIs = ddlResiIs.SelectedValue.ToString();
        objTeleVer.AppDesignation = txtDesignation.Text.Trim().ToString();
        objTeleVer.NameOfCompany = txtNameOfCompany.Text.Trim().ToString();

        /////////////////////////////////end code//////////////////////////////////////////////////

        if ((txtDateOfVerification.Text != string.Empty) && (txtVerificationTime.Text != string.Empty))
        {
            objTeleVer.VerificationDateAndTime = objComm.strDate(txtDateOfVerification.Text.Trim()) + " " + txtVerificationTime.Text.Trim() + " " + ddlVerificationTimeType.SelectedValue.Trim();

        }
        else
        {
            objTeleVer.VerificationDateAndTime = "";
        }
        objTeleVer.Area = txtArea.Text.Trim().ToString();


        //Changed for SBI

        //if (ddlRating.SelectedItem.Text == "UnSatisfactory")
        //{
        //    objTeleVer.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        //}
        if (ddlRating.SelectedValue == "18")
        {
            objTeleVer.UnsatisfactoryReason = txtProvidereasonforunsatisfactoryrating.Text.Trim().ToString();
        }
        else
        {
            objTeleVer.UnsatisfactoryReason = "";
        }
        //END for SBI



        //added by hemangi kambli on 07/09/2007--------------
        objTeleVer.AddedBy = Session["UserId"].ToString();
        objTeleVer.AddedOn = DateTime.Now;
        objTeleVer.ModifyBy = Session["UserId"].ToString();
        objTeleVer.ModifyOn = DateTime.Now;
        //Naresh 14/06/08
        objTeleVer.Staying_Whom = txtStaying.Text.Trim().ToString();

        objTeleVer.PP_Number = txtPPNo.Text.Trim().ToString();
        objTeleVer.Any_Other_Resi_Phone = txtAnyotherResiPhoneNo.Text.Trim().ToString();
        objTeleVer.Applicant_Availbility = txtAppAvailable.Text.Trim().ToString();
        objTeleVer.Dir_Check  = txtDirectoryCheck.Text.Trim().ToString();
        objTeleVer.Name_of_Applicant_Conf = ddlNameofApplicantConfirmedatgivenPhoneNo.Text.Trim().ToString();
        objTeleVer.Mismatch_Add_Tel=ddlMismatchedInAddTelNo.Text.Trim().ToString();
        //PP_Number,Any_Other_Resi_Phone,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel
        ///------------------------------------------------------
        /// //Added by hemangi kambli on 01/10/2007 
        if (hdnTransStart.Value != "")
            objTeleVer.TransStart = Convert.ToDateTime(hdnTransStart.Value);
        objTeleVer.TransEnd = Convert.ToDateTime(DateTime.Now.ToString());//"dd/MM/yyyy hh:mm:ss tt"));
        objTeleVer.CentreId = Session["CentreId"].ToString();
        objTeleVer.ProductId = Session["ProductId"].ToString();
        objTeleVer.ClientId = Session["ClientId"].ToString();
        objTeleVer.UserId = Session["UserId"].ToString();
        ///------------------------------------------------------
    
        //Added by Rupesh on 03/05/2013
        
        objTeleVer.Response = ddlResponse.SelectedValue.ToString();
        objTeleVer.Status = ddlstatus.SelectedValue.ToString();
        objTeleVer.Reason = ddlReason.SelectedValue.ToString();
        objTeleVer.personcontactedRL = ddlpersoncontactedRL.SelectedValue.ToString();
        objTeleVer.Resvertyp = ddlResvertyp.SelectedValue.ToString();
        objTeleVer.Agency = ddlAgency.SelectedValue.ToString();
        
        //Added by Rupesh on 03/05/2013
        //added by Manoj jadhav for yes bank auto loan
        objTeleVer.LoanApplied = ddlLoanapplied.SelectedValue.ToString();
        objTeleVer.NoOfwhichTVRdone = txtTvrdone.Text.Trim().ToString();


        //New added/Updated for CHOLA
        objTeleVer.ApplicationDate = txtApplicationDate.Text.Trim().ToString();
        objTeleVer.IFRented = txtRentAmount.Text.Trim().ToString();
        objTeleVer.Less1YrAddr = txtLessthan1.Text.Trim().ToString();
        objTeleVer.Is_address_same = ddlAddressDifferent.SelectedValue.ToString();
        objTeleVer.AddrDiffConf = txtAddrDiffConf.Text.Trim().ToString();
        objTeleVer.Neighbour1_Comments = txtRef1Comments.Text.Trim().ToString();
        objTeleVer.Name_Neighbour2 = txtRef2Name.Text.Trim().ToString();
        objTeleVer.Neighbour_Telephone2 = txtRef2Telephone.Text.Trim().ToString();
        objTeleVer.Neighbour2_confirmation = txtRef2Relantionship.Text.Trim().ToString();
        objTeleVer.Neighbour2_Comments = txtRef2Comments.Text.Trim().ToString();
        objTeleVer.Telephone_Exists = ddlTelephoneExist.SelectedValue.ToString();
        objTeleVer.Tele_whose_Name = txtTeleWhoseName.Text.Trim().ToString();
        objTeleVer.AddressCDROM = txtAdderssCDROM.Text.Trim().ToString();
        objTeleVer.Dedupe_check = ddlDedupe.SelectedValue.ToString();
        objTeleVer.CustomerCIFL = ddlCustomerCIFL.SelectedValue.ToString();

        //END for CHOLA

    }

    private void IfIsEditFalse()
    {
        //txtResidentPhoneNo.Enabled = false;
        ddlPersonContactedatResidencetelephoneConfirms.Enabled = false;
        txtPersonContacted.Enabled = false;
        txtRelationshipwithApplicant.Enabled = false;
        txtResidenceAddressasperCall.Enabled = false;
        txtNumberofYearsatResidence.Enabled = false;
        txtNameOftheEmployer.Enabled = false;
        txtPermanentAddress.Enabled = false;
        txtOverallRemarks.Enabled = false;
        ddlRating.Enabled = false;
        ddlStatus2.Enabled = false;
        txtStayingSince.Enabled = false;
        ddlTeleCallersName.Enabled = false;
        txtDateOfVerification.Enabled = false;
        txtVerificationTime.Enabled = false;
        txtAdditionalRemark.Enabled = false;
        txtNewInfoObt.Enabled = false;
        btnCancel.Enabled = false;
        btnSubmit.Enabled = false;
        //txtResidenceAddressasperApplication.Enabled = false;
        txtNameoftheApplicant.Enabled = false;
        //txtDateRecieved.Enabled = false;
        //txtRefNo.Enabled = false;
        txtArea.Enabled = false;
        txtDate1stCall.Enabled = false;
        txtTime1stCall.Enabled = false;
        ddlTime1stCall.Enabled = false;
        txtTelNo1stCall.Enabled = false;
        ddlRemarks1stCall.Enabled = false;
        txtDate2ndCall.Enabled = false;
        txtTime2ndCall.Enabled = false;
        ddlTime2ndCall.Enabled = false;
        txtTelNo2ndCall.Enabled = false;
        ddlRemarks2ndCall.Enabled = false;
        txtDate3rdCall.Enabled = false;
        txtTime3rdCall.Enabled = false;
        ddlTime3rdCall.Enabled = false;
        txtTelNo3rdCall.Enabled = false;
        ddlRemarks3rdCall.Enabled = false;
        txtDate4thCall.Enabled = false;
        txtTime4thCall.Enabled = false;
        ddlTime4thCall.Enabled = false;
        txtTelNo4thCall.Enabled = false;
        txtNewInfoObt.Enabled = false;
        txtDate5thCall.Enabled = false;
        txtTime5thCall.Enabled = false;
        ddlTime5thCall.Enabled = false;
        txtTelNo5thCall.Enabled = false;
        ddlRemarks5thCall.Enabled = false;
        ddlRemarks4thCall.Enabled = false;
        txtProvidereasonforunsatisfactoryrating.Enabled = false;
        ddlResiIs.Enabled = false; 

        txtRefName.Enabled = false;
        txtRefTel.Enabled = false;
        txtRelRef.Enabled = false;
        txtKnowGua.Enabled = false;
        txtKnowRef.Enabled = false;
        txtEmpDetGua.Enabled = false;
        txtEmpDetRef.Enabled = false;
        txtOthLoanGua.Enabled = false;
        txtOthLoanRef.Enabled = false;
        txtLibGua.Enabled = false;
        txtLibRef.Enabled = false;
        txtEmiGua.Enabled = false;
        txtEmiRef.Enabled = false;
        txtAgencyCode.Enabled = false;
        txtContactedNo.Enabled = false;
        txtTimeCurrentEmploymentYrs.Enabled = false;
        txtNameOfPersonContacted.Enabled = false;
        txtRegion.Enabled = false;
        txtEarningMembers.Enabled = false;
        txtDependents.Enabled = false;
        txtDependents.Enabled = false;
        txtSpouseWorking.Enabled = false;
        txtParenteDetails.Enabled = false;
        txtReasonDecline.Enabled = false;
        txtNameOfCompany.Enabled = false;
        ddlResponse.Enabled = false;
        ddlstatus.Enabled = false;
        ddlReason.Enabled = false;
        ddlpersoncontactedRL.Enabled = false;
        ddlResvertyp.Enabled = false;
        ddlAgency.Enabled = false; 
        ddlLoanapplied.Enabled = false;
        txtTvrdone.Enabled = false;

        //New added/Updated for CHOLA
        txtApplicationDate.Enabled = false;
        txtRentAmount.Enabled = false;
        txtLessthan1.Enabled = false;
        ddlAddressDifferent.Enabled = false;
        txtAddrDiffConf.Enabled = false;
        txtRef1Comments.Enabled = false;
        txtRef2Name.Enabled = false;
        txtRef2Telephone.Enabled = false;
        txtRef2Relantionship.Enabled = false;
        txtRef2Comments.Enabled = false;
        ddlTelephoneExist.Enabled = false;
        txtTeleWhoseName.Enabled = false;
        txtAdderssCDROM.Enabled = false;
        ddlDedupe.Enabled = false;
        ddlCustomerCIFL.Enabled = false;
        //END 

    }

    private void FillTelecallerName()
    {
        DataTable dtTeleCallerName = new DataTable();
        dtTeleCallerName = objTeleVer.GetTeleCallerName();
        ddlTeleCallersName.DataTextField = "FULLNAME";
        ddlTeleCallersName.DataValueField = "EMP_ID";
        ddlTeleCallersName.DataSource = dtTeleCallerName;
        ddlTeleCallersName.DataBind();

    }

    private void FillRatingStatus()
    {
        DataTable dtStatus = new DataTable();
        dtStatus = objTeleVer.GetCaseStatus();
        ddlRating.DataTextField = "STATUS_NAME";
        ddlRating.DataValueField = "CASE_STATUS_ID";
        ddlRating.DataSource = dtStatus;
        ddlRating.DataBind();
       
        ListItem lstItem1 = new ListItem("NA", "");
        ddlRating.Items.Insert(0, lstItem1);
    }  

    public void funShowPanel()
    {
        string strClientID = Session["ClientId"].ToString();
        string strActivityID = Session["ActivityId"].ToString();
        string strProductID = Session["ProductId"].ToString();
        string strVerificationType = "4";
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
                    objPlaceHolder = (PlaceHolder)(tblResiTelVeri.Rows[0].Cells[0].FindControl(strPlaceHolderName));
                    if (objPlaceHolder != null)
                    {

                        Panel objPanel = new Panel();
                        //objPanel.EnableViewState = false;
                        objPanel = (Panel)(tblResiTelVeri.Rows[1].Cells[0].FindControl(strPanelName));
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
}
