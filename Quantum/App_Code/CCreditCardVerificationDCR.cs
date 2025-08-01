using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for CCreditCardVerificationDCR
/// </summary>
public class CCreditCardVerificationDCR
{
    private CCommon objCon;
	public CCreditCardVerificationDCR()
	{
        objCon = new CCommon();
    }


    #region GetAttemptDtl
    public DataSet GetAttemptDtl(string sCaseID,string sVerificationTypeId)
    {
        string sSql = "";

        sSql = "SELECT E.EMP_ID , E.FULLNAME,CSM.STATUS_CODE,CSM.STATUS_NAME,CD.Case_Status_ID,CD.DECLINED_CODE,CD.DECLINED_REASON, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK,cd.add_date " +
              " FROM CPV_CC_VERI_ATTEMPTS VAT LEFT OUTER JOIN CPV_CC_VERI_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID LEFT OUTER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " LEFT OUTER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID " +
              " WHERE CD.Case_ID='" + sCaseID + "' AND CD.Verification_type_ID='" + sVerificationTypeId + "'" +
              " and VAT.Verification_type_ID = CD.Verification_type_ID ";


        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public DataSet GetAttemptDtl1(string sCaseID, string sVerificationTypeId, string aa)
    {
        string sSql = "";

        if (aa == "8")
        {
            sSql = "SELECT E.EMP_ID , E.FULLNAME,''as 'STATUS_CODE','' as 'STATUS_NAME',''as 'Case_Status_ID',''as 'DECLINED_CODE',''as 'DECLINED_REASON' " +
                   ",VAT.ATTEMPT_DATE_TIME,VAT.REMARK,''as 'add_date',Vat.Telephone_no,Vat.SubRemark,Vat.FeVisit,Vat.FeName  FROM CPV_CC_VERI_ATTEMPTS VAT LEFT OUTER JOIN EMPLOYEE_MASTER E " +
                   "ON  E.EMP_ID=VAT.VERIFIER_ID  WHERE vat.Case_ID='" + sCaseID + "' AND vat.Verification_type_ID='" + sVerificationTypeId + "'";
           
        }
        else sSql = "SELECT E.EMP_ID , E.FULLNAME,CSM.STATUS_CODE,CSM.STATUS_NAME,CD.Case_Status_ID,CD.DECLINED_CODE,CD.DECLINED_REASON, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK,cd.add_date,Vat.Telephone_no,Vat.SubRemark,Vat.FeVisit,Vat.FeName " +
              " FROM CPV_CC_VERI_ATTEMPTS VAT LEFT OUTER JOIN CPV_CC_VERI_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID LEFT OUTER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " LEFT OUTER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID " +
              " WHERE CD.Case_ID='" + sCaseID + "' AND CD.Verification_type_ID='" + sVerificationTypeId + "'" +
              " and VAT.Verification_type_ID = CD.Verification_type_ID ";


        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetAttemptDtl1_DCR(string sCaseID, string sVerificationTypeId, string aa)
    {
        string sSql = "";

        if (aa == "8")
        {
            sSql = "SELECT E.EMP_ID , E.FULLNAME,''as 'STATUS_CODE','' as 'STATUS_NAME',''as 'Case_Status_ID',''as 'DECLINED_CODE',''as 'DECLINED_REASON' " +
                   ",VAT.ATTEMPT_DATE_TIME,VAT.REMARK,''as 'add_date',Vat.Telephone_no,Vat.SubRemark,Vat.FeVisit,Vat.FeName  FROM CPV_DCR_VERI_ATTEMPTS VAT LEFT OUTER JOIN EMPLOYEE_MASTER E " +
                   "ON  E.EMP_ID=VAT.VERIFIER_ID  WHERE vat.Case_ID='" + sCaseID + "' AND vat.Verification_type_ID='" + sVerificationTypeId + "'";

        }
        else sSql = "SELECT E.EMP_ID , E.FULLNAME,CSM.STATUS_CODE,CSM.STATUS_NAME,CD.Case_Status_ID,CD.DECLINED_CODE,CD.DECLINED_REASON, " +
              " VAT.ATTEMPT_DATE_TIME,VAT.REMARK,cd.add_date,Vat.Telephone_no,Vat.SubRemark,Vat.FeVisit,Vat.FeName " +
              " FROM CPV_DCR_VERI_ATTEMPTS VAT LEFT OUTER JOIN CPV_DCR_VERI_DETAILS CD " +
              " ON VAT.CASE_ID = CD.CASE_ID LEFT OUTER JOIN CASE_STATUS_MASTER CSM ON CSM.CASE_STATUS_ID=CD.CASE_STATUS_ID  " +
              " LEFT OUTER JOIN EMPLOYEE_MASTER E ON  E.EMP_ID=VAT.VERIFIER_ID " +
              " WHERE CD.Case_ID='" + sCaseID + "' AND CD.Verification_type_ID='" + sVerificationTypeId + "'" +
              " and VAT.Verification_type_ID = CD.Verification_type_ID ";


        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetAttemptDtl

    #region Property Declaration
    //added by Manoj Thakur on 17/12/2007------
    private string strTableToEdit;
    public string TableToEdit
    {
        get { return strTableToEdit; }
        set { strTableToEdit = value; }
    }
    //End
    private string sError;
    public string Error
    {
        get { return sError; }
        set { sError = value; }
    }
    private string sVerifierID;
    private string sVerificationTypeId;
    private string sAttemptDateTime;
    private string sAttemptRemark;
    private string sVerTypeId;
    //added by hemangi kambli on 07/09/2007------
    private string sAddedBy;
    private string sModifiedBy;
    private DateTime dtAdded;
    private DateTime dtModify;
    //added by hemangi kambli on 01/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;

    //fields for HSBC Bank(Dubai)-----
    private string sOffCumResi;
    public string OfficeCumResidence
    {
        get { return sOffCumResi; }
        set { sOffCumResi = value; }
    }
    private string sPhotographOfLocation;
    public string PhotographOfLocation
    {
        get { return sPhotographOfLocation; }
        set { sPhotographOfLocation = value; }
    }
    private string sEmirate;
    public string Emirate 
    {
        get { return sEmirate; }
        set { sEmirate = value; }
    }
    private string sAppReportToName;
    public string ApplicantReportToName
    {
        get { return sAppReportToName; }
        set { sAppReportToName = value; }
    }
    private string sAppReportToDesignation;
    public string AppReportToDesignation
    {
        get { return sAppReportToDesignation; }
        set { sAppReportToDesignation = value; }
    }
    private string sAppHomeCountryPhoneNo;
    public string ApplicantHomeCountryPhoneNo
    {
        get { return sAppHomeCountryPhoneNo; }
        set { sAppHomeCountryPhoneNo = value; }
    }
    private string sIsCompanyPartOfGroupCompanies ;
    public string IsCompanyPartOfGroupCompanies
    {
        get { return sIsCompanyPartOfGroupCompanies; }
        set { sIsCompanyPartOfGroupCompanies = value; }
    }
    private string sMainBusinessOrCompanyActivity;
    public string MainBusinessOrCompanyActivity
    {
        get { return sMainBusinessOrCompanyActivity; }
        set { sMainBusinessOrCompanyActivity = value; }
    }
    private string sNameOfOwner;
    public string NameOfOwner
    {
        get { return sNameOfOwner; }
        set { sNameOfOwner = value; }
    }
    private string sBranchesWareHouseCompanyHaveInUAE;
    public string BranchesWareHouseCompanyHaveInUAE
    {
        get { return sBranchesWareHouseCompanyHaveInUAE; }
        set { sBranchesWareHouseCompanyHaveInUAE = value; }
    }
    

    //---------------------------------------
    public DateTime TransStart
    {
        get { return dtTransStart; }
        set { dtTransStart = value; }
    }

    public DateTime TransEnd
    {
        get { return dtTransEnd; }
        set { dtTransEnd = value; }
    }

    public string UserId
    {
        get { return sUserId; }
        set { sUserId = value; }
    }

    public string CentreId
    {
        get { return sCentreId; }
        set { sCentreId = value; }
    }

    public string ProductId
    {
        get { return sProductId; }
        set { sProductId = value; }
    }

    public string ClientId
    {
        get { return sClientId; }
        set { sClientId = value; }
    }
    ////------------------------------------------------
    
    public DateTime AddedOn
    {
        get { return dtAdded; }
        set { dtAdded = value; }
    }

    public string AddedBy
    {
        get { return sAddedBy; }
        set { sAddedBy = value; }
    }

    public DateTime ModifyOn
    {
        get { return dtModify; }
        set { dtModify = value; }
    }

    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }
    //---------------------------------------
    public string VerifierID
    {
        get { return sVerifierID; }
        set { sVerifierID = value; }
    }

    public string AttemptDateTime
    {
        get { return sAttemptDateTime; }
        set { sAttemptDateTime = value; }
    }
    public string AttemptRemark
    {
        get { return sAttemptRemark; }
        set { sAttemptRemark = value; }
    }
    public string VerficationTypeID
    {
        get { return sVerTypeId; }
        set { sVerTypeId = value; }
    }
    private string sParticulars;
    public string Particulars
    {
        get { return sParticulars; }
        set { sParticulars = value; }
    }
    private string sResidenceIs;
    public string ResidenceIs
    {
        get { return sResidenceIs; }
        set { sResidenceIs = value; }
    }
    private string sNameOfCompany1;
    public string NameOfCompany1
    {
        get { return sNameOfCompany1; }
        set { sNameOfCompany1 = value; }
    }

    private string sPrevEmpDetail;
    public string PrevEmpDetail
    {
        get { return sPrevEmpDetail; }
        set { sPrevEmpDetail = value; }
    }
    private string sAppMetAt;
    public string AppMetAt
    {
        get { return sAppMetAt; }
        set { sAppMetAt = value; }
    }
    private string sTimeAtCurrResi;
    public string TimeAtCurrResi
    {
        get { return sTimeAtCurrResi; }
        set { sTimeAtCurrResi = value; }
    }
    private string sAnyOtherPhoneNo;
    public string AnyOtherPhoneNo
    {
        get { return sAnyOtherPhoneNo; }
        set { sAnyOtherPhoneNo = value; }
    }
    private string sChangeInPhone;
    public string ChangeInPhone
    {
        get { return sChangeInPhone; }
        set { sChangeInPhone = value; }
    }
    private string sRelationPerContacted;
    public string RelationPerContacted
    {
        get { return sRelationPerContacted; }
        set { sRelationPerContacted = value; }
    }
    private string sAvgMonthTurnOver;
    public string AvgMonthTurnOver
    {
        get { return sAvgMonthTurnOver; }
        set { sAvgMonthTurnOver = value; }
    }
    private string sCaseId;
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }
    private string sDeclineCode;
    public string DeclineCode
    {
        get { return sDeclineCode; }
        set { sDeclineCode = value; }
    }
    private string sCaseStatusId;
    public string CaseStatusId
    {
        get { return sCaseStatusId; }
        set { sCaseStatusId = value; }
    }
    private string sAgencyCode;
    public string AgencyCode
    {
        get { return sAgencyCode; }
        set { sAgencyCode = value; }
    }

    private string sDepoDate;
    public string DepoDate
    {
        get { return sDepoDate; }
        set { sDepoDate = value; }
    }
    private string sDispDate;
    public string DispDate
    {
        get { return sDispDate; }
        set { sDispDate = value; }
    }
    private string sDoc;
    public string Doc
    {
        get { return sDoc; }
        set { sDoc = value; }
    }
    
    private string sChequeDate;
    public string ChequeDate
    {
        get { return sChequeDate; }
        set { sChequeDate = value; }
    }
    private string sAgencyName;
    public string AgencyName
    {
        get { return sAgencyName; }
        set { sAgencyName = value; }
    }
    private string sPersonContName;
    public string PersonContName
    {
        get { return sPersonContName; }
        set { sPersonContName = value; }
    }
    private string sVerificationType;
    public string VerificationType
    {
        get { return sVerificationType; }
        set { sVerificationType = value; }
    }
    private string sApplicantName;
    public string ApplicantName
    {
        get { return sApplicantName; }
        set { sApplicantName = value; }
    }
    private string sPPNormal;
    public string PPNormal
    {
        get { return sPPNormal; }
        set { sPPNormal = value; }
    }
    private string sRefNo;
    public string CDMRefNo
    {
        get { return sRefNo; }
        set { sRefNo = value; }
    }

    private string sResiAddress;
    public string ResiAddress
    {
        get { return sResiAddress; }
        set { sResiAddress = value; }
    }
    private string sLandmarkObserved;

    public string LandmarkObserved
    {
        get { return sLandmarkObserved; }
        set { sLandmarkObserved = value; }
    }
    private string sPermanentAddress;
    public string PermanentAddress
    {
        get { return sPermanentAddress; }
        set { sPermanentAddress = value; }
    }
    private string sPinCode;
    public string PinCode
    {
        get { return sPinCode; }
        set { sPinCode = value; }
    }
    private string sPhoneNo;
    public string PhoneNo
    {
        get { return sPhoneNo; }
        set { sPhoneNo = value; }
    }
    private string dtDOB;

    public string DateOfBirth
    {
        get { return dtDOB; }
        set { dtDOB = value; }
    }
    private string dtIsCaseComp;

    public string IsCaseComp
    {
        get { return dtIsCaseComp;}
        set { dtIsCaseComp = value; }
    }
    private string sQualification;
    public string Qualification
    {
        get { return sQualification; }
        set { sQualification = value; }
    }
    private string sTimeCurrOfficeYrsMths;
    public string TimeCurrOfficeYrsMths
    {
        get { return sTimeCurrOfficeYrsMths; }
        set { sTimeCurrOfficeYrsMths = value; }
    }
    private decimal sNoOfYearsInPresentAdd;
    public decimal NoOfYearsInPresentAdd
    {
        get { return sNoOfYearsInPresentAdd; }
        set { sNoOfYearsInPresentAdd = value; }
    }
    private string sAddresssOnApplication;
    public string AddresssOnApplication
    {
        get { return sAddresssOnApplication; }
        set { sAddresssOnApplication = value; }
    }
    private string sTimeCurrYrsMths;
    public string TimeCurrYrsMths
    {
        get { return sTimeCurrYrsMths; }
        set { sTimeCurrYrsMths = value; }
    }
    
    private string sMaritalStatus;
    public string MaritalStatus
    {
        get { return sMaritalStatus; }
        set { sMaritalStatus = value; }
    }

    private string sSpouseWorking;
    public string SpouseWorking
    {
        get { return sSpouseWorking; }
        set { sSpouseWorking = value; }
    }
    /// <summary>
    /// /////add for DCR//////////
    /// </summary>
    private string sPickUpStatus1;
    public string PickUpStatus1
    {
        get { return sPickUpStatus1;}
        set { sPickUpStatus1 = value; }
    }
    private string sDate1;
    public string Date1
    {
        get { return sDate1; }
        set { sDate1 = value; }
    }
    private string sPickUpStatus2;
    public string PickUpStatus2
    {
        get { return sPickUpStatus2; }
        set { sPickUpStatus2 = value; }
    }
    private string sDate2;
    public string Date2
    {
        get { return sDate2; }
        set { sDate2 = value; }
    }
    private string sPickUpStatus3;
    public string PickUpStatus3
    {
        get { return sPickUpStatus3; }
        set { sPickUpStatus3 = value; }
    }
    private string sDate3;
    public string Date3
    {
        get { return sDate3; }
        set { sDate3 = value; }
    }
    private string sPickUpStatusFinal;
    public string PickUpStatusFinal
    {
        get { return sPickUpStatusFinal; }
        set { sPickUpStatusFinal = value; }
    }
    private string sPickedupDate;
    public string PickedupDate
    {
        get { return sPickedupDate; }
        set { sPickedupDate = value; }
    }
    private string sPickUpFeedback;
    public string PickUpFeedback
    {
        get { return sPickUpFeedback; }
        set { sPickUpFeedback = value; }
    }
    private string sReturnDate;
    public string ReturnDate
    {
        get { return sReturnDate; }
        set { sReturnDate = value; }
    }
    private string sDespatchDate;
    public string DespatchDate
    {
        get { return sDespatchDate; }
        set { sDespatchDate = value; }
    }
    private string sFEName;
    public string FEName
    {
        get { return sFEName; }
        set { sFEName = value; }
    }
    private string sFECODE;
    public string FECODE
    {
        get { return sFECODE; }
        set { sFECODE = value; }
    }
    private string sFEMobile;
    public string FEMobile
    {
        get { return sFEMobile; }
        set { sFEMobile = value; }
    }
    private string sTMEName;
    public string TMEName
    {
        get { return sTMEName; }
        set { sTMEName = value; }
    }
    /// <summary>
    /// //////edn for DCR
    /// </summary>
    private string sS_CompName;
    public string SpouseCompName
    {
        get { return sS_CompName; }
        set { sS_CompName = value; }
    }
    private string sTelSpouse;
    public string TelephoneSpouse
    {
        get { return sTelSpouse; }
        set { sTelSpouse = value; }
    }
    private string dSpouseSalary;
    public string SpouseSalary
    {
        get { return dSpouseSalary; }
        set { dSpouseSalary = value; }
    }
    private string sNoOfDependent;
    public string NoOfDependent
    {
        get { return sNoOfDependent; }
        set { sNoOfDependent = value; }
    }
    private string sDesgnAtOffice;
    public string DesgnAtOffice
    {
        get { return sDesgnAtOffice; }
        set { sDesgnAtOffice = value; }
    }
    private string sCoAppName;
    public string CoAppName
    {
        get { return sCoAppName; }
        set { sCoAppName = value; }
    }
    private string sOfficePhone;
    public string OfficePhone
    {
        get { return sOfficePhone; }
        set { sOfficePhone = value; }
    }
    private string sOfficeExtn;
    public string OfficeExtn
    {
        get { return sOfficeExtn; }
        set { sOfficeExtn = value; }
    }
    private string sOfficeAddress;
    public string OfficeAddress
    {
        get { return sOfficeAddress; }
        set { sOfficeAddress = value; }
    }
    private string sVehicleType;
    public string VehicleType
    {
        get { return sVehicleType; }
        set { sVehicleType = value; }
    }
    private string sVehicleMake;
    public string VehicleMake
    {
        get { return sVehicleMake; }
        set { sVehicleMake = value; }
    }
    private string sVehicleIs;
    public string VehicleIs
    {
        get { return sVehicleIs; }
        set { sVehicleIs = value; }
    }
    private string sWorking;
    public string Working
    {
        get { return sWorking; }
        set { sWorking = value; }
    }
    private string sChildren;
    public string Children
    {
        get { return sChildren; }
        set { sChildren = value; }
    }
    /// <summary>
    /// //////////Change Santosh Shelar 16th May 2008//////////////
    /// </summary>
    private string sAss_Vis_Tv;
    public string Ass_Vis_Tv
    {
        get { return sAss_Vis_Tv; }
        set { sAss_Vis_Tv = value; }
    }
    private string sAss_Vis_AC;
    public string Ass_Vis_AC
    {
        get { return sAss_Vis_AC; }
        set { sAss_Vis_AC = value; }
    }
    private string sAss_Vis_Refri;
    public string Ass_Vis_Refri
    {
        get { return sAss_Vis_Refri; }
        set { sAss_Vis_Refri = value; }
    }
    private string sAss_Vis_MusSys;
    public string Ass_Vis_MusSys
    {
        get { return sAss_Vis_MusSys; }
        set { sAss_Vis_MusSys = value; }
    }
    private string sAss_Vis_Comp;
    public string Ass_Vis_Comp
    {
        get { return sAss_Vis_Comp; }
        set { sAss_Vis_Comp = value; }
    }
    private string sAss_Vis_Cool;
    public string Ass_Vis_Cool
    {
        get { return sAss_Vis_Cool; }
        set { sAss_Vis_Cool = value; }
    }
    private string sAss_Vis_PH;
    public string Ass_Vis_PH
    {
        get { return sAss_Vis_PH; }
        set { sAss_Vis_PH = value; }
    }
    private string sAss_Vis_PhotCop;
    public string Ass_Vis_PhotCop
    {
        get { return sAss_Vis_PhotCop; }
        set { sAss_Vis_PhotCop = value; }
    }
    private string sAss_Vis_Print;
    public string Ass_Vis_Print
    {
        get { return sAss_Vis_Print; }
        set { sAss_Vis_Print = value; }
    }
    private string sAss_Vis_Fax;
    public string Ass_Vis_Fax
    {
        get { return sAss_Vis_Fax; }
        set { sAss_Vis_Fax = value; }
    }
    private string sother_nature_of_business;
    public string other_nature_of_business
    {
        get { return sother_nature_of_business; }
        set { sother_nature_of_business = value; }
    }
    /// <summary>
    /// /////////////////////
    /// </summary>
   
    private string sVehicleOther;
    public string VehicleOther
    {
        get { return sVehicleOther; }
        set { sVehicleOther = value; }
    }
    private string sIncomeDocs;
    public string IncomeDocs
    {
        get { return sIncomeDocs; }
        set { sIncomeDocs = value; }
    }
    private string sIsCreditCard;
    public string IsCreditCard
    {
        get { return sIsCreditCard; }
        set { sIsCreditCard = value; }
    }
    private string sCardType;
    public string CardType
    {
        get { return sCardType; }
        set { sCardType = value; }
    }
    private string sCardNo;
    public string CardNo
    {
        get { return sCardNo; }
        set { sCardNo = value; }
    }
    private string sCardLimit;
    public string CardLimit
    {
        get { return sCardLimit; }
        set { sCardLimit = value; }
    }
    private string sCardExpiry;
    public string CardExpiry
    {
        get { return sCardExpiry; }
        set { sCardExpiry = value; }
    }
    private string sAppAvailableAt;
    public string AppAvailableAt
    {
        get { return sAppAvailableAt; }
        set { sAppAvailableAt = value; }
    }
    private string sAppAvailableAtHome;
    public string AppAvailableAtHome
    {
        get { return sAppAvailableAtHome; }
        set { sAppAvailableAtHome = value; }
    }
    private string sTimeCurrResiYrsMths;
    public string TimeCurrResiYrsMths
    {
        get { return sTimeCurrResiYrsMths; }
        set { sTimeCurrResiYrsMths = value; }
    }
    
    private string sResiType;
    public string ResidenceType
    {
        get { return sResiType; }
        set { sResiType = value; }
    }
    private string sResiRentAmt;
    public string ResiRentAmt
    {
        get { return sResiRentAmt; }
        set { sResiRentAmt = value; }
    }
    private string sSpouseOfAppWorks;
    public string SpouseOfAppWorks
    {
        get { return sSpouseOfAppWorks; }
        set { sSpouseOfAppWorks = value; }
    }
    private string sAppWorksAt;
    public string AppWorksAt
    {
        get { return sAppWorksAt; }
        set { sAppWorksAt = value; }
    }
    private string sVerifiedFrom;
    public string VerifiedFrom
    {
        get { return sVerifiedFrom; }
        set { sVerifiedFrom = value; }
    }
    private string sApproxArea;
    public string ApproxArea
    {
        get { return sApproxArea; }
        set { sApproxArea = value; }
    }
    private string sGeneralAppear;
    public string GeneralAppearance
    {
        get { return sGeneralAppear; }
        set { sGeneralAppear = value; }
    }
    private string sLocality;
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }
    private string sLocatingAdd;
    public string LocatingAddress
    {
        get { return sLocatingAdd; }
        set { sLocatingAdd = value; }
    }
    private string sAssetsVisible;
    public string AssetsVisible
    {
        get { return sAssetsVisible; }
        set { sAssetsVisible = value; }
    }
    private string sPolLeadPortrait;
    public string PoliticalLeadderPortrait
    {
        get { return sPolLeadPortrait; }
        set { sPolLeadPortrait = value; }
    }
    private string sVisitProof;
    public string VisitProof
    {
        get { return sVisitProof; }
        set { sVisitProof = value; }
    }
    private string sRouteMap;
    public string RouteMap
    {
        get { return sRouteMap; }
        set { sRouteMap = value; }
    }
    private string sNegativeArea;
    public string NegativeArea
    {
        get { return sNegativeArea; }
        set { sNegativeArea = value; }
    }
    private string sOCL;
    public string OCL
    {
        get { return sOCL; }
        set { sOCL = value; }
    }

    private string sTPCDone;
    public string TPCDone
    {
        get { return sTPCDone; }
        set { sTPCDone = value; }
    }
    private string sTPCDtl;
    public string TPCDetail
    {
        get { return sTPCDtl; }
        set { sTPCDtl = value; }
    }
    private string sAnyInfo;
    public string AnyInformation
    {
        get { return sAnyInfo; }
        set { sAnyInfo = value; }
    }
    private string sNewInfo;
    public string NewInformation
    {
        get { return sNewInfo; }
        set { sNewInfo = value; }
    }
    private string sAddConfirm;
    public string  AddressConfirmation
    {
        get { return sAddConfirm; }
        set { sAddConfirm  = value; }
    }
    private string sContactability;
    public string Contactability
    {
        get { return sContactability; }
        set { sContactability = value; }
    }
    private string sApplicationConfirm;
    public string ApplicationConfirm
    {
        get { return sApplicationConfirm; }
        set { sApplicationConfirm = value; }
    }
    private string sProfile;
    public string Profile
    {
        get { return sProfile; }
        set { sProfile = value; }
    }
    private string sReputation;
    public string Reputation
    {
        get { return sReputation; }
        set { sReputation = value; }
    }
    private string sNegmatch;
    public string Negmatch
    {
        get { return sNegmatch; }
        set { sNegmatch = value; }
    }
    private string sNegmatchDtl;
    public string NegmatchDetail
    {
        get { return sNegmatchDtl; }
        set { sNegmatchDtl = value; }
    }
    private string sOverallAssesst;
    public string OverallAssessment
    {
        get { return sOverallAssesst; }
        set { sOverallAssesst = value; }
    }
    private string sAssesstReason;
    public string AssesstReason
    {
        get { return sAssesstReason; }
        set { sAssesstReason = value; }
    }
    private string sFECode;
    public string FECode
    {
        get { return sFECode; }
        set { sFECode = value; }
    }
    private string sFEName1;
    public string FEName1
    {
        get { return sFEName1; }
        set { sFEName1 = value; }
    }
    private DateTime dtVerify;
    public DateTime VerificationDate
    {
        get { return dtVerify; }
        set { dtVerify = value; }
    }
    private string sPersonContacted;
    public string PersonContacted
    {
        get { return sPersonContacted; }
        set { sPersonContacted = value; }
    }
    private string sRelationApp;
    public string RelationWithApplicant
    {
        get { return sRelationApp; }
        set { sRelationApp = value; }
    }
    private string sResiIsStatus;
    public string ResiIsStatus
    {
        get { return sResiIsStatus; }
        set { sResiIsStatus = value; }
    }
    private string sIssuingBank;
    public string IssuingBank
    {
        get { return sIssuingBank; }
        set { sIssuingBank = value; }
    }
    private string sCooperativeCust;
    public string CooperativeCus
    {
        get { return sCooperativeCust; }
        set { sCooperativeCust = value; }
    }
    private string sNeighbourRef;
    public string NeighbourReferance
    {
        get { return sNeighbourRef; }
        set { sNeighbourRef = value; }
    }
    private string sConstructionOfResi;
    public string ConstructionOfResi
    {
        get { return sConstructionOfResi; }
        set { sConstructionOfResi = value; }
    }
    private string sExteriorComments;
    public string ExteriorComments
    {
        get { return sExteriorComments; }
        set { sExteriorComments = value; }
    }
    private string sIsAppStay;
    public string IsApplicantStay
    {
        get { return sIsAppStay; }
        set { sIsAppStay = value; }
    }
    private string sApproxAgeOfApp;
    public string ApproxAgeOfApp
    {
        get { return sApproxAgeOfApp; }
        set { sApproxAgeOfApp = value; }
    }
    private string sNoOfFamilyMem;
    public string NoOfFamilyMem
    {
        get { return sNoOfFamilyMem; }
        set { sNoOfFamilyMem = value; }
    }
    private string sNameplateSighted;
    public string NameplateSighted
    {
        get { return sNameplateSighted; }
        set { sNameplateSighted = value; }
    }
    private string sAppNameOnDoor;
    public string AppNameOnDoor
    {
        get { return sAppNameOnDoor; }
        set { sAppNameOnDoor = value; }
    }
    private string sNameplate;
    public string Nameplate
    {
        get { return sNameplate; }
        set { sNameplate = value; }
    }
    private string sAppNameOnSocietyBoard;
    public string AppNameOnSocietyBoard
    {
        get { return sAppNameOnSocietyBoard; }
        set { sAppNameOnSocietyBoard = value; }
    }
   
    private string sSocietyBoard;
    public string SocietyBoard
    {
        get { return sSocietyBoard; }
        set { sSocietyBoard = value; }
    }
    private string sNeighbourName;
    public string NeighbourName
    {
        get { return sNeighbourName; }
        set { sNeighbourName = value; }
    }
    private string sNeighbourFor;
    public string NeighbourFor
    {
        get { return sNeighbourFor; }
        set { sNeighbourFor = value; }
    }
    private string sWatchmanName;
    public string WatchmanName
    {
        get { return sWatchmanName; }
        set { sWatchmanName = value; }
    }
    private string sWatchmanFor;
    public string WatchmanFor
    {
        get { return sWatchmanFor; }
        set { sWatchmanFor = value; }
    }
    private string sLandlordName;
    public string LandlordName
    {
        get { return sLandlordName; }
        set { sLandlordName = value; }
    }
    private string sLandlordFor;
    public string LandlordFor
    {
        get { return sLandlordFor; }
        set { sLandlordFor = value; }
    }
    private string sOffNameOnBoard;
    public string OffNameOnBoard
    {
        get { return sOffNameOnBoard; }
        set { sOffNameOnBoard = value; }
    }
    private string sOffStaff;
    public string OfficeStaff
    {
        get { return sOffStaff; }
        set { sOffStaff = value; }
    }
    private string sEmpSighted;
    public string EmpSighted
    {
        get { return sEmpSighted; }
        set { sEmpSighted = value; }
    }
    private string sOwnerResiApp1;
    public string OwnerResiApp1
    {
        get { return sOwnerResiApp1; }
        set { sOwnerResiApp1 = value; }
    }
    private string sEmpStatus1;
    public string EmpStatus1
    {
        get { return sEmpStatus1; }
        set { sEmpStatus1 = value; }
    }
    private string sEmpStatus2;
    public string EmpStatus2
    {
        get { return sEmpStatus2; }
        set { sEmpStatus2 = value; }
    }
    private string sOwnerResiApp2;
    public string OwnerResiApp2
    {
        get { return sOwnerResiApp2; }
        set { sOwnerResiApp2 = value; }
    }
    private string sBankNameCC;
    public string BankNameCC
    {
        get { return sBankNameCC; }
        set { sBankNameCC = value; }
    }

    private string sChequeNo;
    public string ChequeNo
    {
        get { return sChequeNo; }
        set { sChequeNo = value; }
    }
    private string sRECEIPTNO;
    public string RECEIPTNO
    {
        get { return sRECEIPTNO; }
        set { sRECEIPTNO = value; }
    }
    private string sAcknNo;
    public string AcknNo
    {
        get { return sAcknNo; }
        set { sAcknNo = value; }
    }
    private string sPraposal;
    public string Praposal
    {
        get { return sPraposal; }
        set { sPraposal = value; }
    }
    private string sRsendDate;
    public string RsendDate
    {
        get { return sRsendDate; }
        set { sRsendDate = value; }
    }
    private string sRrecDate;
    public string RrecDate
    {
        get { return sRrecDate; }
        set { sRrecDate = value; }
    }
    private string sOclVisit;
    public string OclVisit
    {
        get { return sOclVisit; }
        set { sOclVisit = value; }
    }

    private string sProductName;
    public string ProductName
    {
        get { return sProductName; }
        set { sProductName = value; }
    }
    private string sAmountDefult;
    public string AmountDefult
    {
        get { return sAmountDefult; }
        set { sAmountDefult = value; }
    }
    private string sRentAmount;
    public string RentAmount
    {
        get { return sRentAmount; }
        set { sRentAmount = value; }
    }
    private string sPriorityCustomer;
    public string PriorityCustomer
    {
        get { return sPriorityCustomer; }
        set { sPriorityCustomer = value; }
    }
    private string sSegment;
    public string Segment
    {
        get { return sSegment; }
        set { sSegment = value; }
    }
    private string sInfoRequired;
    public string InfoRequired
    {
        get { return sInfoRequired; }
        set { sInfoRequired = value; }
    }
    private string sChangeInAdd;
    public string ChangeInAdd
    {
        get { return sChangeInAdd; }
        set { sChangeInAdd = value; }
    }
    private string sReasonOfChange;
    public string ReasonOfChange
    {
        get { return sReasonOfChange; }
        set { sReasonOfChange = value; }
    }
    private string sNoOfPeopleInHouse;
    public string NoOfPeopleInHouse
    {
        get { return sNoOfPeopleInHouse; }
        set { sNoOfPeopleInHouse = value; }
    }
    private string sDeclineReason;
    public string DeclineReason
    {
        get { return sDeclineReason; }
        set { sDeclineReason = value; }
    }
    private string sOutcome;
    public string Outcome
    {
        get { return sOutcome; }
        set { sOutcome = value; }
    }
    private string sCPVScore;
    public string CPVScore
    {
        get { return sCPVScore; }
        set { sCPVScore = value; }
    }
    private string sTrackNo;
    public string TrackNo
    {
        get { return sTrackNo; }
        set { sTrackNo = value; }
    }
    private string sEntryPermit;
    public string EntryPermit
    {
        get { return sEntryPermit; }
        set { sEntryPermit = value; }
    }
    private string sAddConfBy;
    public string AddConfBy
    {
        get { return sAddConfBy; }
        set { sAddConfBy = value; }
    }
    private string sNoOfEarnFamMem;
    public string NoOfEarnFamMem
    {
        get { return sNoOfEarnFamMem; }
        set { sNoOfEarnFamMem = value; }
    }
    private string sOfficeTel;
    public string OfficeTelephone
    {
        get { return sOfficeTel; }
        set { sOfficeTel = value; }
    }
    private string sApproxValIfOwn;
    public string ApproxValIfOwn
    {
        get { return sApproxValIfOwn; }
        set { sApproxValIfOwn = value; }
    }
    private string sBankNameNegative;
    public string BankNameNegative
    {
        get { return sBankNameNegative; }
        set { sBankNameNegative = value; }
    }
    private string sBranch;
    public string Branch
    {
        get { return sBranch; }
        set { sBranch = value; }
    }
    private string sInfoRefused;
    public string InfoRefused
    {
        get { return sInfoRefused; }
        set { sInfoRefused = value; }
    }
    private string sTPC2;
    public string TPC2
    {
        get { return sTPC2; }
        set { sTPC2 = value; }
    }
    private string sPersonMet2;
    public string PersonMet2
    {
        get { return sPersonMet2; }
        set { sPersonMet2 = value; }
    }
    private string sAdd2;
    public string Add2
    {
        get { return sAdd2; }
        set { sAdd2 = value; }
    }
    private string sAppAvalAtHome2;
    public string AppAvalAtHome2
    {
        get { return sAppAvalAtHome2; }
        set { sAppAvalAtHome2 = value; }
    }
    private string sAppAge2;
    public string AppAge2
    {
        get { return sAppAge2; }
        set { sAppAge2 = value; }
    }
    private string sNoOfResiAtHome2;
    public string NoOfResiAtHome2
    {
        get { return sNoOfResiAtHome2; }
        set { sNoOfResiAtHome2 = value; }
    }
    private string sYrsLiveAtAdd2;
    public string YrsLiveAtAdd2
    {
        get { return sYrsLiveAtAdd2; }
        set { sYrsLiveAtAdd2 = value; }
    }
    private string sResiStatus2;
    public string ResiStatus2
    {
        get { return sResiStatus2; }
        set { sResiStatus2 = value; }
    }
    private string sAdditional_Remark;
    public string Additional_Remark
    {
        get { return sAdditional_Remark;}
        set { sAdditional_Remark = value; }
    }
    private string sOccupation2;
    public string Occupation2
    {
        get { return sOccupation2; }
        set { sOccupation2 = value; }
    }
    private string sReasonAddNotConfirm;
    public string ReasonAddNotConfirm
    {
        get { return sReasonAddNotConfirm; }
        set { sReasonAddNotConfirm = value; }
    }
    private string sUntraceableReason;
    public string UntraceableReason
    {
        get { return sUntraceableReason; }
        set { sUntraceableReason = value; }
    }
   
    private string sResultOfCalling;
    public string ResultOfCalling
    {
        get { return sResultOfCalling; }
        set { sResultOfCalling = value; }
    }
    private string sMismatchResiAdd;
    public string MismatchResiAdd
    {
        get { return sMismatchResiAdd; }
        set { sMismatchResiAdd = value; }
    }
    private string sIsAppKnown;
    public string IsAppKnown
    {
        get { return sIsAppKnown; }
        set { sIsAppKnown = value; }
    }
    private string sToWhomAddBelong;
    public string ToWhomAddBelong
    {
        get { return sToWhomAddBelong; }
        set { sToWhomAddBelong = value; }
    }
    private string sVerificationConductAt;
    public string VerificationConductAt
    {
        get { return sVerificationConductAt; }
        set { sVerificationConductAt = value; }
    }
    private string sAccomodation;
    public string Accomodation
    {
        get { return sAccomodation; }
        set { sAccomodation = value; }
    }
    private string sInterior;
    public string Interior
    {
        get { return sInterior; }
        set { sInterior = value; }
    }
    private string sExterior;
    public string Exterior
    {
        get { return sExterior; }
        set { sExterior = value; }
    }
    private string sTPCBy;
    public string TPCBy
    {
        get { return sTPCBy; }
        set { sTPCBy = value; }
    }
    private string sName;
    public string Name
    {
        get { return sName; }
        set { sName = value; }
    }
    private string sStay;
    public string Stay
    {
        get { return sStay; }
        set { sStay = value; }
    }
    private string sObservation;
    public string Observation
    {
        get { return sObservation; }
        set { sObservation = value; }
    }
    private string sSupUpdationAdd;
    public string SupUpdationAdd
    {
        get { return sSupUpdationAdd; }
        set { sSupUpdationAdd = value; }
    }
    private string sSupPhoneNo;
    public string SupPhoneNo
    {
        get { return sSupPhoneNo; }
        set { sSupPhoneNo = value; }
    }
    private string sSupEmploymentDtl;
    public string SupEmploymentDtl
    {
        get { return sSupEmploymentDtl; }
        set { sSupEmploymentDtl = value; }
    }
    private string sSupRecommendation;
    public string SupRecommendation
    {
        get { return sSupRecommendation; }
        set { sSupRecommendation = value; }
    }
    private string sSupDeclineCode;
    public string SupDeclineCode
    {
        get { return sSupDeclineCode; }
        set { sSupDeclineCode = value; }
    }
    private string sSupVerificationScore;
    public string SupVerificationScore
    {
        get { return sSupVerificationScore; }
        set { sSupVerificationScore = value; }
    }
    private string sSupDeoperator;
    public string SupDeoperator
    {
        get { return sSupDeoperator; }
        set { sSupDeoperator = value; }
    }
    private string sOfficePremises;
    public string OfficePremises
    {
        get { return sOfficePremises; }
        set { sOfficePremises = value; }
    }
    private string sMobileNo;
    public string MobileNo
    {
        get { return sMobileNo; }
        set { sMobileNo = value; }
    }
    private string sBusinessNature;
    public string BusinessNature
    {
        get { return sBusinessNature; }
        set { sBusinessNature = value; }
    }
    private string sNoOfYearINComp;
    public string NoOfYearINComp
    {
        get { return sNoOfYearINComp; }
        set { sNoOfYearINComp = value; }
    }
    private string sEmpJobType;
    public string EmpJobType
    {
        get { return sEmpJobType; }
        set { sEmpJobType = value; }
    }
    private string sReasonNonVisNameplate;
    public string ReasonNonVisNameplate
    {
        get { return sReasonNonVisNameplate; }
        set { sReasonNonVisNameplate = value; }
    }
    private string sOfficeSize;
    public string OfficeSize
    {
        get { return sOfficeSize; }
        set { sOfficeSize = value; }
    }
    private string sNoOfEmployee;
    public string NoOfEmployee
    {
        get { return sNoOfEmployee; }
        set { sNoOfEmployee = value; }
    }
    private string sOfficeLocality;
    public string OfficeLocality
    {
        get { return sOfficeLocality; }
        set { sOfficeLocality = value; }
    }
    private string sOfficeReputation;
    public string OfficeReputation
    {
        get { return sOfficeReputation; }
        set { sOfficeReputation = value; }
    }
    private string sLocatingOfficeAddress;
    public string LocatingOfficeAddress
    {
        get { return sLocatingOfficeAddress; }
        set { sLocatingOfficeAddress = value; }
    }
    private string sOfficeIsIn;
    public string OfficeIsIn
    {
        get { return sOfficeIsIn; }
        set { sOfficeIsIn = value; }
    }
    private string sTypeOfOffice;
    public string TypeOfOffice
    {
        get { return sTypeOfOffice; }
        set { sTypeOfOffice = value; }
    }

    private string sAppWorkingAs;
    public string AppWorkingAs
    {
        get { return sAppWorkingAs; }
        set { sAppWorkingAs = value; }
    }
    private string sTypeOfBusiness;
    public string TypeOfBusiness
    {
        get { return sTypeOfBusiness; }
        set { sTypeOfBusiness = value; }
    }
    private string sAffiPoliticalParty;
    public string AffiPoliticalParty
    {
        get { return sAffiPoliticalParty; }
        set { sAffiPoliticalParty = value; }
    }
    private string sEquipSightedInOff;
    public string EquipSightedInOff
    {
        get { return sEquipSightedInOff; }
        set { sEquipSightedInOff = value; }
    }
    private string sBusinessStockSeen;
    public string BusinessStockSeen
    {
        get { return sBusinessStockSeen; }
        set { sBusinessStockSeen = value; }
    }
    private string sStockType;
    public string StockType
    {
        get { return sStockType; }
        set { sStockType = value; }
    }
    private string sBusinessActivity;
    public string BusinessActivity
    {
        get { return sBusinessActivity; }
        set { sBusinessActivity = value; }
    }
    private string sTPCName;
    public string TPCName
    {
        get { return sTPCName; }
        set { sTPCName = value; }
    }
    private string sFERemark;
    public string FERemark
    {
        get { return sFERemark; }
        set { sFERemark = value; }
    }
    private string sNoOfCustPerDay;
    public string NoOfCustPerDay
    {
        get { return sNoOfCustPerDay; }
        set { sNoOfCustPerDay = value; }
    }
    private string sAppJobTransferable;
    public string AppJobTransferable
    {
        get { return sAppJobTransferable; }
        set { sAppJobTransferable = value; }
    }
    private string sYearsWorkIn;
    public string YearsWorkIn
    {
        get { return sYearsWorkIn; }
        set { sYearsWorkIn = value; }
    }
    private string sSalaryDrawn;
    public string SalaryDrawn
    {
        get { return sSalaryDrawn; }
        set { sSalaryDrawn = value; }
    }
    private string sConstructionOffice;
    public string ConstructionOffice
    {
        get { return sConstructionOffice; }
        set { sConstructionOffice = value; }
    }
    private string sNoOfCustSeen;
    public string NoOfCustSeen
    {
        get { return sNoOfCustSeen; }
        set { sNoOfCustSeen = value; }
    }
    private string sSegmentation;
    public string Segmentation
    {
        get { return sSegmentation; }
        set { sSegmentation = value; }
    }
    private string sDetailsProofCollected;
    public string DetailsProofCollected
    {
        get { return sDetailsProofCollected; }
        set { sDetailsProofCollected = value; }
    }
    private string sOther1;
    public string Other1
    {
        get { return sOther1; }
        set { sOther1 = value; }
    }
    private string sOther2;
    public string Other2
    {
        get { return sOther2; }
        set { sOther2 = value; }
    }

    private string sNature_Busi_Resi_Cum_Off;
    public string Nature_Busi_Resi_Cum_Off
    {
        get { return sNature_Busi_Resi_Cum_Off; }
        set { sNature_Busi_Resi_Cum_Off = value; }
    }

    private string sIsAppFullTime;
    public string IsAppFullTime
    {
        get { return sIsAppFullTime; }
        set { sIsAppFullTime = value; }
    }
    private string sResi_Cum_Off_Owned;
    public string Resi_Cum_Off_Owned
    {
        get { return sResi_Cum_Off_Owned; }
        set { sResi_Cum_Off_Owned = value; }
    }
    private string sSeperateForOffice;
    public string SeperateForOffice
    {
        get { return sSeperateForOffice; }
        set { sSeperateForOffice = value; }
    }
    private string sTypeOfAccomodation;
    public string TypeOfAccomodation
    {
        get { return sTypeOfAccomodation; }
        set { sTypeOfAccomodation = value; }
    }
    private string sTPCTypeCompany;
    public string TPCTypeCompany
    {
        get { return sTPCTypeCompany; }
        set { sTPCTypeCompany = value; }
    }
    private string sTPCTypeBusiness;
    public string TPCTypeBusiness
    {
        get { return sTPCTypeBusiness; }
        set { sTPCTypeBusiness = value; }
    }
    private string sDirectoryCheck;
    public string DirectoryCheck
    {
        get { return sDirectoryCheck; }
        set { sDirectoryCheck = value; }
    }
    private string sWhoAreYourCustomer;
    public string WhoAreYourCustomer
    {
        get { return sWhoAreYourCustomer; }
        set { sWhoAreYourCustomer = value; }
    }
    private string sNeighbour2Name;
    public string Neighbour2Name
    {
        get { return sNeighbour2Name; }
        set { sNeighbour2Name = value; }
    }
    private string sNeighbour2Add;
    public string Neighbour2Add
    {
        get { return sNeighbour2Add; }
        set { sNeighbour2Add = value; }
    }   
    private string sCoEstablishIn;
    public string CoEstablishIn
    {
        get { return sCoEstablishIn; }
        set { sCoEstablishIn = value; }
    }
    private string sCompanyName;
    public string CompanyName
    {
        get { return sCompanyName; }
        set { sCompanyName = value; }
    }    
    private string sSupervisorId;
    public string SupervisorId
    {
        get { return sSupervisorId; }
        set { sSupervisorId = value; }
    }
    private string sPersonContDesgn;
    public string PersonContDesgn
    {
        get { return sPersonContDesgn; }
        set { sPersonContDesgn = value; }
    }
    private string sSupervisorRemark;
    public string SupervisorRemark
    {
        get { return sSupervisorRemark; }
        set { sSupervisorRemark = value; }
    }

   // Start Property for New Added Fields for City Bank (Dubai)
    private string sFaxNumber;
    public string FaxNumber
    {
        get { return sFaxNumber; }
        set { sFaxNumber = value; }
    }
    private string sIsThereSecurityGuardForBuildingOffice;
    public string IsThereSecurityGuardForBuildingOffice
    {
        get { return sIsThereSecurityGuardForBuildingOffice; }
        set { sIsThereSecurityGuardForBuildingOffice = value; }
    }
    private string sIsThereReceptionDesk;
    public string IsThereReceptionDesk
    {
        get { return sIsThereReceptionDesk; }
        set { sIsThereReceptionDesk = value; }
    }
    private string sHowManyDesksWorkstationsTables;
    public string HowManyDesksWorkstationsTables
    {
        get { return sHowManyDesksWorkstationsTables; }
        set { sHowManyDesksWorkstationsTables = value; }
    }
    private string sIsTradeLicenseOfCompanyDisplayedOnPremises;
    public string IsTradeLicenseOfCompanyDisplayedOnPremises
    {
        get { return sIsTradeLicenseOfCompanyDisplayedOnPremises; }
        set { sIsTradeLicenseOfCompanyDisplayedOnPremises = value; }
    }
    private string sNumberOfEmployees;
    public string NumberOfEmployees
    {
        get { return sNumberOfEmployees; }
        set { sNumberOfEmployees = value; }
    }
    private string sBranch1Location;
    public string Branch1Location
    {
        get { return sBranch1Location; }
        set { sBranch1Location = value; }
    }
    private string sBranch1TelephoneNo;
    public string Branch1TelephoneNo
    {
        get { return sBranch1TelephoneNo; }
        set { sBranch1TelephoneNo = value; }
    }
    private string sBranch1RentalAmt;
    public string Branch1RentalAmt
    {
        get { return sBranch1RentalAmt; }
        set { sBranch1RentalAmt = value; }
    }
    private string sBranch1FaxNo;
    public string Branch1FaxNo
    {
        get { return sBranch1FaxNo; }
        set { sBranch1FaxNo = value; }
    }
    private string sBranch1ManagerName;
    public string Branch1ManagerName
    {
        get { return sBranch1ManagerName; }
        set { sBranch1ManagerName = value; }
    }
    private string sBranch2Location;
    public string Branch2Location
    {
        get { return sBranch2Location; }
        set { sBranch2Location = value; }
    }
    private string sBranch2TelephoneNo;
    public string Branch2TelephoneNo
    {
        get { return sBranch2TelephoneNo; }
        set { sBranch2TelephoneNo = value; }
    }
    private string sBranch2RentalAmt;
    public string Branch2RentalAmt
    {
        get { return sBranch2RentalAmt; }
        set { sBranch2RentalAmt = value; }
    }
    private string sBranch2FaxNo;
    public string Branch2FaxNo
    {
        get { return sBranch2FaxNo; }
        set { sBranch2FaxNo = value; }
    }
    private string sBranch2ManagerName;
    public string Branch2ManagerName
    {
        get { return sBranch2ManagerName; }
        set { sBranch2ManagerName = value; }
    }
    private string sBranch3Location;
    public string Branch3Location
    {
        get { return sBranch3Location; }
        set { sBranch3Location = value; }
    }
    private string sBranch3TelephoneNo;
    public string Branch3TelephoneNo
    {
        get { return sBranch3TelephoneNo; }
        set { sBranch3TelephoneNo = value; }
    }
    private string sBranch3RentalAmt;
    public string Branch3RentalAmt
    {
        get { return sBranch3RentalAmt; }
        set { sBranch3RentalAmt = value; }
    }
    private string sBranch3Faxno;
    public string Branch3Faxno
    {
        get { return sBranch3Faxno; }
        set { sBranch3Faxno = value; }
    }
    private string sBranch3ManagerName;
    public string Branch3ManagerName
    {
        get { return sBranch3ManagerName; }
        set { sBranch3ManagerName = value; }
    }
    //----
    private string sBranch4Location;
    public string Branch4Location
    {
        get { return sBranch4Location; }
        set { sBranch4Location = value; }
    }
    private string sBranch4TelephoneNo;
    public string Branch4TelephoneNo
    {
        get { return sBranch4TelephoneNo; }
        set { sBranch4TelephoneNo = value; }
    }
    private string sBranch4RentalAmt;
    public string Branch4RentalAmt
    {
        get { return sBranch4RentalAmt; }
        set { sBranch4RentalAmt = value; }
    }
    private string sBranch4FaxNo;
    public string Branch4FaxNo
    {
        get { return sBranch4FaxNo; }
        set { sBranch4FaxNo = value; }
    }
    private string sBranch4ManagerName;
    public string Branch4ManagerName
    {
        get { return sBranch4ManagerName; }
        set { sBranch4ManagerName = value; }
    }
    private string sApplicationNo;
    public string ApplicationNo
    {
        get { return sApplicationNo; }
        set { sApplicationNo = value; }
    }
    private string sNumberOfBranchesOfficeWarehouse;
    public string NumberOfBranchesOfficeWarehouse
    {
        get { return sNumberOfBranchesOfficeWarehouse; }
        set { sNumberOfBranchesOfficeWarehouse = value; }
    }


    private string sSponsor1Name;
    public string Sponsor1Name
    {
        get { return sSponsor1Name; }
        set { sSponsor1Name = value; }
    }
    private string sType1;
    public string Type1
    {
        get { return sType1; }
        set { sType1 = value; }
    }
    private string sSponsor1TelephoneNo;
    public string Sponsor1TelephoneNo
    {
        get { return sSponsor1TelephoneNo; }
        set { sSponsor1TelephoneNo = value; }
    }
    private string sSponsor1Address;
    public string Sponsor1Address
    {
        get { return sSponsor1Address; }
        set { sSponsor1Address = value; }
    }
    private string sSponsor2Name;
    public string Sponsor2Name
    {
        get { return sSponsor2Name; }
        set { sSponsor2Name = value; }
    }
    private string sType2;
    public string Type2
    {
        get { return sType2; }
        set { sType2 = value; }
    }
    private string sSponsor2TelephoneNo;
    public string Sponsor2TelephoneNo
    {
        get { return sSponsor2TelephoneNo; }
        set { sSponsor2TelephoneNo = value; }
    }
    private string sSponsor2Address;
    public string Sponsor2Address
    {
        get { return sSponsor2Address; }
        set { sSponsor2Address = value; }
    }
    private string sSponsor3Name;
    public string Sponsor3Name
    {
        get { return sSponsor3Name; }
        set { sSponsor3Name = value; }
    }
    private string sType3;
    public string Type3
    {
        get { return sType3; }
        set { sType3 = value; }
    }
    private string sSponsor3TelephoneNo;
    public string Sponsor3TelephoneNo
    {
        get { return sSponsor3TelephoneNo; }
        set { sSponsor3TelephoneNo = value; }
    }
    private string sSponsor3Address;
    public string Sponsor3Address
    {
        get { return sSponsor3Address; }
        set { sSponsor3Address = value; }
    }
    private string sNoOfEmpsInSeniorPosition;
    public string NoOfEmpsInSeniorPosition
    {
        get { return sNoOfEmpsInSeniorPosition; }
        set { sNoOfEmpsInSeniorPosition = value; }
    }
    private string sNatureOfBusinessSponsor;
    public string NatureOfBusinessSponsor
    {
        get { return sNatureOfBusinessSponsor; }
        set { sNatureOfBusinessSponsor = value; }
    }
    private string sProductDealtWith;
    public string ProductDealtWith
    {
        get { return sProductDealtWith; }
        set { sProductDealtWith = value; }
    }
    private string sBankName1;
    public string BankName1
    {
        get { return sBankName1; }
        set { sBankName1 = value; }
    }
    private string sTypeOfAccount1;
    public string TypeOfAccount1
    {
        get { return sTypeOfAccount1; }
        set { sTypeOfAccount1 = value; }
    }
    private string sFacilities1;
    public string Facilities1
    {
        get { return sFacilities1; }
        set { sFacilities1 = value; }
    }
    private string sBankName2;
    public string BankName2
    {
        get { return sBankName2; }
        set { sBankName2 = value; }
    }
    private string sTypeOfAccount2;
    public string TypeOfAccount2
    {
        get { return sTypeOfAccount2; }
        set { sTypeOfAccount2 = value; }
    }
    private string sFacilities2;
    public string Facilities2
    {
        get { return sFacilities2; }
        set { sFacilities2 = value; }
    }
    private string sBankName3;
    public string BankName3
    {
        get { return sBankName3; }
        set { sBankName3 = value; }
    }
    private string sTypeOfAccount3;
    public string TypeOfAccount3
    {
        get { return sTypeOfAccount3; }
        set { sTypeOfAccount3 = value; }
    }
    private string sFacilities3;
    public string Facilities3
    {
        get { return sFacilities3; }
        set { sFacilities3 = value; }
    }
    private string sSalesIn;
    public string SalesIn
    {
        get { return sSalesIn; }
        set { sSalesIn = value; }
    }
    private string sAvgMonthlyTurnover;
    public string AvgMonthlyTurnover
    {
        get { return sAvgMonthlyTurnover; }
        set { sAvgMonthlyTurnover = value; }
    }
    private string sClientList;
    public string ClientList
    {
        get { return sClientList; }
        set { sClientList = value; }
    }
    private string sImpressionOfOffice;
    public string ImpressionOfOffice
    {
        get { return sImpressionOfOffice; }
        set { sImpressionOfOffice = value; }
    }
    private string sCreditAnalystDecision;
    public string CreditAnalystDecision
    {
        get { return sCreditAnalystDecision; }
        set { sCreditAnalystDecision = value; }
    }
    private string sCreditAnalystName;
    public string CreditAnalystName
    {
        get { return sCreditAnalystName; }
        set { sCreditAnalystName = value; }
    }
    private string dtCreditAnalystDate;
    public string CreditAnalystDate
    {
        get { return dtCreditAnalystDate; }
        set { dtCreditAnalystDate = value; }
    }
    private string sOfficeVerificationNo;
    public string OfficeVerificationNo
    {
        get { return sOfficeVerificationNo; }
        set { sOfficeVerificationNo = value; }
    }
    private string sTelephoneBill;
    public string TelephoneBill
    {
        get { return sTelephoneBill; }
        set { sTelephoneBill = value; }
    }
    private string sEmploymentStatus;
    public string EmploymentStatus
    {
        get { return sEmploymentStatus; }
        set { sEmploymentStatus = value; }
    }
    private string sYearsInEmploymentBusiness;
    public string YearsInEmploymentBusiness
    {
        get { return sYearsInEmploymentBusiness; }
        set { sYearsInEmploymentBusiness = value; }
    }
    private string sCmDesign;
    public string CmDesign
    {
        get { return sCmDesign; }
        set { sCmDesign = value; }
    }
    private string sBasicSalary;
    public string BasicSalary
    {
        get { return sBasicSalary; }
        set { sBasicSalary = value; }
    }
    private string sTransportAllowance;
    public string TransportAllowance
    {
        get { return sTransportAllowance; }
        set { sTransportAllowance = value; }
    }
    private string sHouseRentAllowance;
    public string HouseRentAllowance
    {
        get { return sHouseRentAllowance; }
        set { sHouseRentAllowance = value; }
    }
    private string sFixedAllowance;
    public string FixedAllowance
    {
        get { return sFixedAllowance; }
        set { sFixedAllowance = value; }
    }
    private string sTotalFixedSalary;
    public string TotalFixedSalary
    {
        get { return sTotalFixedSalary; }
        set { sTotalFixedSalary = value; }
    }
    private string sAdditionalComments;
    public string AdditionalComments
    {
        get { return sAdditionalComments; }
        set { sAdditionalComments = value; }
    }
    private string sEmploymentConfirmedWith;
    public string EmploymentConfirmedWith
    {
        get { return sEmploymentConfirmedWith; }
        set { sEmploymentConfirmedWith = value; }
    }
    private string sEmploymentConfirmedWithDesignation;
    public string EmploymentConfirmedWithDesignation
    {
        get { return sEmploymentConfirmedWithDesignation; }
        set { sEmploymentConfirmedWithDesignation = value; }
    }
    private string sTypeOfApplicant;
    public string TypeOfApplicant
    {
        get { return sTypeOfApplicant; }
        set { sTypeOfApplicant = value; }
    }
    private string sTypeOfLoan;
    public string TypeOfLoan
    {
        get { return sTypeOfLoan; }
        set { sTypeOfLoan = value; }
    }
    private string sDetailsOfTradeLicense;
    public string DetailsOfTradeLicense
    {
        get { return sDetailsOfTradeLicense; }
        set { sDetailsOfTradeLicense = value; }
    }
    private string sTypeOfSalary;
    public string TypeOfSalary
    {
        get { return sTypeOfSalary; }
        set { sTypeOfSalary = value; }
    }
    //Naresh Start 13/05/2008
    private string sNatureBusiness;
    public string NatureBusiness
    {
        get { return sNatureBusiness; }
        set { sNatureBusiness = value; }
    }
    private string sServiceProvider;
    public string ServiceProvider
    {
        get { return sServiceProvider; }
        set { sServiceProvider = value; }
    }
    //Naresh End 13/05/2008
    
    //Added By Naresh Sabbani//

    private string sType_Of_Society;
    public string Type_Of_Society
    {
        get { return sType_Of_Society; }
        set { sType_Of_Society = value; }
    }

    private string sOther_Facilities;
    public string Other_Facilities
    {
        get { return sOther_Facilities; }
        set { sOther_Facilities = value; }
    }

    private string sMarket_Value;
    public string Market_Value
    {
        get { return sMarket_Value; }
        set { sMarket_Value = value; }
    }

    private string sBuiltup_Area;
    public string Builtup_Area
    {
        get { return sBuiltup_Area; }
        set { sBuiltup_Area = value; }
    }

    private string sNo_Of_Flats;
    public string No_Of_Flats
    {
        get { return sNo_Of_Flats; }
        set { sNo_Of_Flats = value; }
    }

    private string sBedroom;
    public string Bedroom
    {
        get { return sBedroom; }
        set { sBedroom = value; }
    }

    private string sNegative_Area;
    public string Negative_Area
    {
        get { return sNegative_Area; }
        set { sNegative_Area = value; }
    }

    private string sTpc_Name;
    public string Tpc_Name
    {
        get { return sTpc_Name; }
        set { sTpc_Name = value; }
    }

    private string sTpc_Phone;
    public string Tpc_Phone
    {
        get { return sTpc_Phone; }
        set { sTpc_Phone = value; }
    }

    private string sHistory;
    public string History
    {
        get { return sHistory; }
        set { sHistory = value; }
    }

    private string sNo_Of_Employee;
    public string No_Of_Employee
    {
        get { return sNo_Of_Employee; }
        set { sNo_Of_Employee = value; }
    }

    private string sRemark;
    public string Remark
    {
        get { return sRemark; }
        set { sRemark = value; }
    }

    //Addition Ended Naresh Sabbani//

    // End Property for New Added Fields for City Bank (Dubai)
    #endregion Property Declaration

    #region GetCaseVerSocietyRV
    //Name             :   GetCaseVerSocietyRV
    //Create By		:	Sabbani Naresh
    //Create Date		:	7th June 2008
    //Remarks 		    :	This returns Society verification records by passing caseid and verification type
    public OleDbDataReader GetCaseVerSocietyRV(string sCaseId, string sVeriType)
    {
        string sSql = "";
        sSql = "Select Type_Of_Society,Other_Facilities,Market_Value,Builtup_Area,No_Of_Flats,Bedroom,Negative_Area," +
               "Tpc_Name,Tpc_Phone,History,No_Of_Employee,Remark From Cpv_Cc_Veri_Society " +
               " WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetCaseVerSocietyRV_DCR(string sCaseId, string sVeriType)
    {
        string sSql = "";
        sSql = "Select Type_Of_Society,Other_Facilities,Market_Value,Builtup_Area,No_Of_Flats,Bedroom,Negative_Area," +
               "Tpc_Name,Tpc_Phone,History,No_Of_Employee,Remark From Cpv_DCR_Veri_Society " +
               " WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseVerSocietyRV

    #region GetCaseVerifyOtherDtl
    //Name              :   GetCaseVerifyOtherDtl
    //Create By			:	Hemangi Kambli
    //Create Date		:	27th April 2007
    //Remarks 		    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerifyOtherDtl(String sCaseId, string sVeriType)
    {
        string sSql = "";
        sSql = "SELECT CASE_ID,VERIFICATION_TYPE,ADDRESS_VISITED,REL_WITH_APPLICANT,PERSON_CONTACTED,IS_RESIDANT, " +
               "ADDRESS_MATCH, PERMANENT_ADDRESS,CONT_PERSON_REMARK,IS_NEGATIVE_AREA,IS_OCL,LOCALITY_TYPE,RES_TYPE, " +
               "ADD_ON_APPLIED,RES_YEAR,IS_APP_NAME_ON_DOOR,NAME_PLATE,IS_APP_NAME_ON_SOCIETY_BOARD,NAME_SOCIETY_BOARD, " +
               "DOC_PROFF,DUMMY_NO,NEIGHBOURS_NAME,NEIGHBOUR_FOR,WATCHMEN_NAME,WATCHMEN_FOR,LANDLORD_NAME,LANDLORD_FOR, " +
               "OFF_NAME_ON_BOARD,OFF_STAFF,EMP_SIGHTED,INFRASTRUCTUR,STOCK_SIGHTED,OFF_ACTIVITY_SIGHTED,IS_OFF_NEGATIVE_INFO, " +
               "OFF_NEGATIVE_INFO,BUSINESS_YEARS,BUSINESS_TYPE,OFF_ADDRESS_YEARS,OFF_LOCATION_TYPE,BUSINESS_CONSTITUENCY " +
               " FROM CPV_CC_VERI_OTHER_DETAILS WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE='" + sVeriType + "'";
               
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseVerifyOtherDtl

    #region GetCaseVerDescriptionRV
    //Name              :   GetCaseVerDescriptionRV
    //Create By			:	Hemangi Kambli
    //Create Date		:	27th April 2007
    //Remarks 		    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerDescriptionRV(string sCaseId, string sVeriType)
    {
         string sSql = "";

         sSql = "SELECT PP_NORMAL, QUALIFICATION, TIME_AT_CURR_Y_M, MARITAL_STATUS, IS_SPOUSE_WORKING, S_COMPANY_NAME, S_SALARY, S_TELEPHONE," +
              "NO_OF_DEPENDENT, VEHICLE_TYPE, VEHICLE_MAKE, VEHICLE_IS, VEHICLE_OTHER, IS_CREDIT_CARD, CARD_TYPE, CARD_NO, CARD_LIMIT, " +
              "CARD_EXPIRY, APPLICANT_AVAILABILITY, TIME_AT_CURR_RESIDANCE, APPLICANT_WORKS_AT, VERIFIED_NEIGHBOUR, APPROXIMATE_AREA, " +
              "GENRAL_APPEARANCE, LOCATING_ADDRESS, ASSETS_VISIBLE, PORTRAIT, PROOF_OF_VISIT_COLLECTED, ROUTE_MAP_DRAWN, TPC_DONE, " +
              "TPC_DETAILS, ANY_OTHER_INFO_OBT, ADRESS_CONFIRMATION, CONTACTABILITY, CONFIRMATION_IF_APPLICANT_MET, PROFILE, REPUTATION, " +
              "PERSON_CONTACTED_MET, ISSUING_BANK, CUSTOMER_COOPERATION, CONSTRUCTION_OF_RESIDANCE, COMMENTS_EXTERIORS, " +
              "APPLICANT_STAYED_RESIDANCE, APPLICANT_AGE, FAMILY_MEMBERS, NAMEPLATE_VISIBLE, OWNERSHIP_APPLICANT_RESIDANCE_1, " +
              "EMPLOYMENT_STATUS_1, OWNERSHIP_APPLICANT_RESIDANCE_2, EMPLOYMENT_STATUS_2," +
              "RENT_AMOUNT, PRIORITY_CUSTOMER, SEGMENT, INFO_REQUIRED, CHANGE_IN_ADRESS, REASON_FOR_CHANGE,TRACK_NO, " +
              "ENTRY_PERMITTED, ADDRESS_CONFIRMED_BY, NO_OF_EARNING_FAMILY_MEMBER, OFFICE_TELEPHONE, APROX_VALUE_IF_OWNED, BRANCH, " +
              "INFO_REFUSED, OCCUPATION, REASON_ADD_NOT_CONFIRM, LOCALITY, RESULT_CALLING, MISMATCH_RESI_ADD, IS_APP_KNOWN_PERSON, " +
              "ADDRESS_BELONG, VERIFICATION_CONDUCTED, ACCOMODATION, INTERIOR, EXTERIOR, TPC_BY, OBSERVATION, TPC2, PERSON_MET2, " +
              "ADDRESS2, APPLICANT_AGE2, NO_OF_RES_AT_HOME2, YEARS_LIVE_AT_ADD2,S_SALARY,RESIDANCE_STATUS2,WORKING,CHILDREN,App_dob_approx_Age,Additional_Remark  " +
              "FROM CPV_CC_VERI_DESCRIPTION " +
              "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }

    public OleDbDataReader GetCaseVerDescriptionRV_DCR(string sCaseId, string sVeriType)
    {
        string sSql = "";

        sSql = "SELECT PP_NORMAL, QUALIFICATION, TIME_AT_CURR_Y_M, MARITAL_STATUS, IS_SPOUSE_WORKING, S_COMPANY_NAME, S_SALARY, S_TELEPHONE," +
             "NO_OF_DEPENDENT, VEHICLE_TYPE, VEHICLE_MAKE, VEHICLE_IS, VEHICLE_OTHER, IS_CREDIT_CARD, CARD_TYPE, CARD_NO, CARD_LIMIT, " +
             "CARD_EXPIRY, APPLICANT_AVAILABILITY, TIME_AT_CURR_RESIDANCE, APPLICANT_WORKS_AT, VERIFIED_NEIGHBOUR, APPROXIMATE_AREA, " +
             "GENRAL_APPEARANCE, LOCATING_ADDRESS, ASSETS_VISIBLE, PORTRAIT, PROOF_OF_VISIT_COLLECTED, ROUTE_MAP_DRAWN, TPC_DONE, " +
             "TPC_DETAILS, ANY_OTHER_INFO_OBT, ADRESS_CONFIRMATION, CONTACTABILITY, CONFIRMATION_IF_APPLICANT_MET, PROFILE, REPUTATION, " +
             "PERSON_CONTACTED_MET, ISSUING_BANK, CUSTOMER_COOPERATION, CONSTRUCTION_OF_RESIDANCE, COMMENTS_EXTERIORS, " +
             "APPLICANT_STAYED_RESIDANCE, APPLICANT_AGE, FAMILY_MEMBERS, NAMEPLATE_VISIBLE, OWNERSHIP_APPLICANT_RESIDANCE_1, " +
             "EMPLOYMENT_STATUS_1, OWNERSHIP_APPLICANT_RESIDANCE_2, EMPLOYMENT_STATUS_2," +
             "RENT_AMOUNT, PRIORITY_CUSTOMER, SEGMENT, INFO_REQUIRED, CHANGE_IN_ADRESS, REASON_FOR_CHANGE,TRACK_NO, " +
             "ENTRY_PERMITTED, ADDRESS_CONFIRMED_BY, NO_OF_EARNING_FAMILY_MEMBER, OFFICE_TELEPHONE, APROX_VALUE_IF_OWNED, BRANCH, " +
             "INFO_REFUSED, OCCUPATION, REASON_ADD_NOT_CONFIRM, LOCALITY, RESULT_CALLING, MISMATCH_RESI_ADD, IS_APP_KNOWN_PERSON, " +
             "ADDRESS_BELONG, VERIFICATION_CONDUCTED, ACCOMODATION, INTERIOR, EXTERIOR, TPC_BY, OBSERVATION, TPC2, PERSON_MET2, " +
             "ADDRESS2, APPLICANT_AGE2, NO_OF_RES_AT_HOME2, YEARS_LIVE_AT_ADD2,S_SALARY,RESIDANCE_STATUS2,WORKING,CHILDREN,App_dob_approx_Age,Additional_Remark  " +
             "FROM CPV_DCR_VERI_DESCRIPTION " +
             "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
     #endregion GetCaseVerDescriptionRV
    
    #region GetCaseVerDescription1RV
     //Name             :   GetCaseVerDescriptionRV
     //Create By		:	Hemangi Kambli
     //Create Date		:	3rd May 2007
     //Remarks 		    :	This returns verification records by passing caseid and verification type

     public OleDbDataReader GetCaseVerDescription1RV(string sCaseId, string sVeriType)
     {
         string sSql = "";
         
         //sSql="SELECT CONTACTED_PERSON_NAME, CONTACTED_PERSON_DESIGN, BUSINESS_TYPE, COMPANY_EXISTENCE_YEAR, EMP_JOB_TYPE, "+
         //     "BUSINESS_PERMISES, INCOME_DOC_SUBMITTED_WITH_APLICATION, REASON_NONVISIBLE_NAMEPLATE, OFFICE_SIZE, NO_OF_EMP, "+
         //     "OFFICE_IS_IN, AFFILATION_POLITICAL_PARTY_SEEN, EQUIPMENT_SIGHTED_IN_OFFICE, BUSINESS_STOCK_SEEN, STOCK_TYPE, "+
         //     "BUSINESS_ACTIVITY_SEEN, TPC_NAME, FE_REMARK, CO_APP_NAME, NO_CUSTOMER_PERDAY, APPLICANT_JOB_TRANSFERABLE, "+
         //     "YEARS_WORKED, SALARY_DRAWN, CONSTRUCTION_OFFICE, NO_CUSTOMER_SEEN, PRIORITY_CUSTOMER, SEGMENTATION, INFO_REQUIRED, "+
         //     "RELATION_PERSON_CONTACTED, DETAILS_PROOF_COLLECTED, OTHER_1, OTHER_2, NATURE_BUSINESS_RESI_CUM_OFF, "+
         //     "RESI_COMOFF_OWNED, SEPARATE_FOR_OFF, IS_APPLICANT_FULL_TIME, TPC_TYPE_COMPANY, TPC_TYPE_BUSINESS, "+
         //     "IS_ADD_NOT_CONFIRMED, UNREACHABLE_REASON, VERIFICATION_CONDUCTED_AT, DIRECTORY_CHECK, WHO_ARE_YOUR_CUSTOMER, "+
         //     "NEIGHBOUR_NAME_2, NEIGHBOUR_ADD_2, CO_ESTABLISHED_IN, LAND_MARK_OBSERVED, PERMANENT_ADDRESS, PP_ADD_LOCATION, "+
         //     "COMPANY_NAME, TIME_AT_CURRENT_EMPLOYMENT, MAILING_ADDRESS, RESIDANCE_IS, OFFICE_EXT, DESIGNATION, NOB, DOB_APPLICANT, "+
         //     "APPLICANT_IS_AVAILABLE_AT, VERIFIER_COMMENTS, NEW_DETAILS_OBTAINED, SPECIAL_INSTRUCTIONS, "+
         //     "IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA, EMPLOYER_ADD, BUSINESS_CONTACT_NO, BUSINESS_CONTACT_EXTN,"+ 
         //     "APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO, CALLED_UP_ON_RESIDANCE_TEL_NO, SPK_TO, RESIDANCE_STATUS,"+ 
         //     "ANY_OTHER_RESIDANCE_PHONE_NO, CHANGE_IN_PHONE_NO, REASON_FOR_CHANGE, YCR, SELF_EMP_CODE_TYPE_ORGANIZATION, " +
         //     "FROM CPV_CC_VERI_DESCRIPTION1 " +
         //     "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";


         sSql="SELECT CONTACTED_PERSON_DESIGN, INCOME_DOC_SUBMITTED_WITH_APLICATION, FE_REMARK, CO_APP_NAME, PRIORITY_CUSTOMER, "+
              "INFO_REQUIRED, RELATION_PERSON_CONTACTED,RESIDANCE_IS,IS_ADD_NOT_CONFIRMED, UNREACHABLE_REASON, VERIFICATION_CONDUCTED_AT, " +
              "LAND_MARK_OBSERVED, PERMANENT_ADDRESS, COMPANY_NAME, OFFICE_EXT, DESIGNATION, DOB_APPLICANT, APPLICANT_IS_AVAILABLE_AT, "+
              "OFFICE_ADDRESS,RESIDANCE_STATUS,OFFICE_ADDRESS,STAY,NEIGHBOUR_NAME_2,NEIGHBOUR_REFERENCE,PINCODE,RESIDANCE_IS,PERMANENT_ADDRESS,LAND_MARK_OBSERVED,Affilation_Political_Party_Seen " +
              "FROM CPV_CC_VERI_DESCRIPTION1 " +
              "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }

    public OleDbDataReader GetCaseVerDescription1RV_DCR(string sCaseId, string sVeriType)
    {
        string sSql = "";
        
        sSql = "SELECT CONTACTED_PERSON_DESIGN, INCOME_DOC_SUBMITTED_WITH_APLICATION, FE_REMARK, CO_APP_NAME, PRIORITY_CUSTOMER, " +
             "INFO_REQUIRED, RELATION_PERSON_CONTACTED,RESIDANCE_IS,IS_ADD_NOT_CONFIRMED, UNREACHABLE_REASON, VERIFICATION_CONDUCTED_AT, " +
             "LAND_MARK_OBSERVED, PERMANENT_ADDRESS, COMPANY_NAME, OFFICE_EXT, DESIGNATION, DOB_APPLICANT, APPLICANT_IS_AVAILABLE_AT, " +
             "OFFICE_ADDRESS,RESIDANCE_STATUS,OFFICE_ADDRESS,STAY,NEIGHBOUR_NAME_2,NEIGHBOUR_REFERENCE,PINCODE,RESIDANCE_IS,PERMANENT_ADDRESS,LAND_MARK_OBSERVED,Affilation_Political_Party_Seen " +
             "FROM CPV_DCR_VERI_DESCRIPTION1 " +
             "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

     #endregion GetCaseVerDescription1RV

    #region GetCaseVerOtherDtlRV
     //Name             :   GetCaseVerOtherDtlRV
     //Create By		:	Hemangi Kambli
     //Create Date		:	3rd May 2007
     //Remarks 		    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerOtherDtlRV(string sCaseId, string sVeriType)
     {
         string sSql = "";

         sSql = "SELECT REL_WITH_APPLICANT, PERSON_CONTACTED, IS_RESIDANT, PERMANENT_ADDRESS, IS_NEGATIVE_AREA, "+
                "IS_OCL, LOCALITY_TYPE, RES_TYPE,IS_APP_NAME_ON_DOOR,AGENCY_NAME " +
                "FROM CPV_CC_VERI_OTHER_DETAILS "+
                "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }

    public OleDbDataReader GetCaseVerOtherDtlRV_DCR(string sCaseId, string sVeriType)
    {
        string sSql = "";

        sSql = "SELECT REL_WITH_APPLICANT, PERSON_CONTACTED, IS_RESIDANT, PERMANENT_ADDRESS, IS_NEGATIVE_AREA, " +
               "IS_OCL, LOCALITY_TYPE, RES_TYPE,IS_APP_NAME_ON_DOOR,AGENCY_NAME " +
               "FROM CPV_DCR_VERI_OTHER_DETAILS " +
               "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    #endregion GetCaseVerOtherDtlRV

    #region GetCaseVerDtlRV
     //Name             :   GetCaseVerDtlRV
     //Create By		:	Hemangi Kambli
     //Create Date		:	3rd May 2007
     //Remarks 		    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerDtlRV(string sCaseId, string sVeriType)
     {
         string sSql = "";

         sSql = "SELECT DECLINED_CODE,DECLINED_REASON,RATING,DEFAULTED_WITH,DEFAULTED_PRODUCT,DEFAULT_AMOUNT," +
                "SUPERVISOR_ID,SUPERVISOR_REMARKS,CASE_STATUS_ID,OVERALL_ASSESMENT,OVERALL_ASSESMENT_REASON,Deposit_Date, " +
                "Despatch_Date,Docs,Flooring,Roofing,spouse_occu,spouse_name,car_park,StanLiving,Entrance_Motorable " +
                "FROM CPV_CC_VERI_DETAILS " +                
                "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }

    public OleDbDataReader GetCaseVerDtlRV_DCR(string sCaseId, string sVeriType)
    {
        string sSql = "";

        sSql = "SELECT DECLINED_CODE,DECLINED_REASON,RATING,DEFAULTED_WITH,DEFAULTED_PRODUCT,DEFAULT_AMOUNT," +
               "SUPERVISOR_ID,SUPERVISOR_REMARKS,CASE_STATUS_ID,OVERALL_ASSESMENT,OVERALL_ASSESMENT_REASON,Deposit_Date, " +
               "Despatch_Date,Docs,Flooring,Roofing,spouse_occu,spouse_name,car_park,StanLiving,Entrance_Motorable,Actual_Number,Residence_Internal " +
               "FROM CPV_DCR_VERI_DETAILS " +
               "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
     #endregion GetCaseVerDtlRV

    #region GetCaseVerDescriptionBV
     //Name              :   GetCaseVerDescriptionBV
     //Create By			:	Hemangi Kambli
     //Create Date		:	27th April 2007
     //Remarks 		    :	This returns verification records by passing caseid and verification type

     public OleDbDataReader GetCaseVerDescriptionBV(string sCaseId, string sVeriType)
     {
         string sSql = "";

         sSql = "SELECT PP_NORMAL, QUALIFICATION,TIME_AT_CURR_Y_M, MARITAL_STATUS, IS_SPOUSE_WORKING, S_COMPANY_NAME, S_SALARY, S_TELEPHONE," +
              "NO_OF_DEPENDENT, VEHICLE_TYPE, VEHICLE_MAKE, VEHICLE_IS, VEHICLE_OTHER, IS_CREDIT_CARD, CARD_TYPE, CARD_NO, CARD_LIMIT, " +
              "CARD_EXPIRY, APPLICANT_AVAILABILITY, TIME_AT_CURR_RESIDANCE, APPLICANT_WORKS_AT, VERIFIED_NEIGHBOUR, APPROXIMATE_AREA, " +
              "GENRAL_APPEARANCE, LOCATING_ADDRESS, ASSETS_VISIBLE, PORTRAIT, PROOF_OF_VISIT_COLLECTED, ROUTE_MAP_DRAWN, TPC_DONE, " +
              "TPC_DETAILS, ANY_OTHER_INFO_OBT, ADRESS_CONFIRMATION, CONTACTABILITY, CONFIRMATION_IF_APPLICANT_MET, PROFILE, REPUTATION, " +
              "PERSON_CONTACTED_MET, ISSUING_BANK, CUSTOMER_COOPERATION, CONSTRUCTION_OF_RESIDANCE, COMMENTS_EXTERIORS, " +
              "APPLICANT_STAYED_RESIDANCE, APPLICANT_AGE, FAMILY_MEMBERS, NAMEPLATE_VISIBLE, OWNERSHIP_APPLICANT_RESIDANCE_1, " +
              "EMPLOYMENT_STATUS_1, OWNERSHIP_APPLICANT_RESIDANCE_2, EMPLOYMENT_STATUS_2," +
              "RENT_AMOUNT, PRIORITY_CUSTOMER, SEGMENT, INFO_REQUIRED, CHANGE_IN_ADRESS, REASON_FOR_CHANGE,TRACK_NO, " +
              "ENTRY_PERMITTED, ADDRESS_CONFIRMED_BY, NO_OF_EARNING_FAMILY_MEMBER, OFFICE_TELEPHONE, APROX_VALUE_IF_OWNED, BRANCH, " +
              "INFO_REFUSED, OCCUPATION, REASON_ADD_NOT_CONFIRM, LOCALITY, RESULT_CALLING, MISMATCH_RESI_ADD, IS_APP_KNOWN_PERSON, " +
              "ADDRESS_BELONG, VERIFICATION_CONDUCTED, ACCOMODATION, INTERIOR, EXTERIOR, TPC_BY, OBSERVATION, TPC2, PERSON_MET2, " +
              "ADDRESS2, APPLICANT_AGE2, NO_OF_RES_AT_HOME2, YEARS_LIVE_AT_ADD2,S_SALARY,RESIDANCE_STATUS2,INTERIOR,EXTERIOR,VERIFIED_NEIGHBOUR,Nature_Business,Service_Provider " +
              "FROM CPV_CC_VERI_DESCRIPTION " +
              "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }
     #endregion GetCaseVerDescriptionBV

    #region GetCaseVerDescription1BV
     //Name             :   GetCaseVerDescription1BV
     //Create By		:	Hemangi Kambli
     //Create Date		:	4th May 2007
     //Remarks 		    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerDescription1BV(string sCaseId, string sVeriType)
     {
         string sSql = "";

        sSql="SELECT CONTACTED_PERSON_NAME,TIME_AT_CURRENT_EMPLOYMENT,CONTACTED_PERSON_DESIGN, BUSINESS_TYPE, COMPANY_EXISTENCE_YEAR, EMP_JOB_TYPE, "+
             "BUSINESS_PERMISES, INCOME_DOC_SUBMITTED_WITH_APLICATION, REASON_NONVISIBLE_NAMEPLATE, OFFICE_SIZE, NO_OF_EMP, "+
             "OFFICE_IS_IN,TYPE_OF_OFFICE,APP_WORKING_AS,AFFILATION_POLITICAL_PARTY_SEEN, EQUIPMENT_SIGHTED_IN_OFFICE, BUSINESS_STOCK_SEEN, STOCK_TYPE, " +
             "BUSINESS_ACTIVITY_SEEN, TPC_NAME, FE_REMARK, CO_APP_NAME, NO_CUSTOMER_PERDAY, APPLICANT_JOB_TRANSFERABLE, "+
             "YEARS_WORKED, SALARY_DRAWN, CONSTRUCTION_OFFICE, NO_CUSTOMER_SEEN, PRIORITY_CUSTOMER, SEGMENTATION, INFO_REQUIRED, "+
             "RELATION_PERSON_CONTACTED, DETAILS_PROOF_COLLECTED, OTHER_1, OTHER_2, NATURE_BUSINESS_RESI_CUM_OFF, "+
             "RESI_COMOFF_OWNED, SEPARATE_FOR_OFF, IS_APPLICANT_FULL_TIME, TPC_TYPE_COMPANY, TPC_TYPE_BUSINESS, "+
             "IS_ADD_NOT_CONFIRMED, UNREACHABLE_REASON, VERIFICATION_CONDUCTED_AT, DIRECTORY_CHECK, WHO_ARE_YOUR_CUSTOMER, "+
             "NEIGHBOUR_NAME_2, NEIGHBOUR_ADD_2, CO_ESTABLISHED_IN, LAND_MARK_OBSERVED, PERMANENT_ADDRESS, COMPANY_NAME,NO_OF_EMP_SIGHTED_IN_PERMISES, " +
             "TIME_AT_CURRENT_EMPLOYMENT, OFFICE_LOCALITY,BUSINESS_NATURE,ANY_OTHER_RESIDANCE_PHONE_NO,CHANGE_IN_PHONE_NO,OFFICE_EXT, "+
             "DESIGNATION, DOB_APPLICANT, PARTICULARS, AVG_MONTH_TURNOVER,APP_MET_AT,NAMEOFCOMPANY1,PREVIOUS_EMP_DETAIL,OFFICE_REPUTATION,BUSINESS_TYPE " +
             "FROM CPV_CC_VERI_DESCRIPTION1 "+
             "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

         return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
     }
     #endregion GetCaseVerDescription1BV

    #region GetCaseVerOtherDtlBV
    //Name             :    GetCaseVerOtherDtlBV
    //Create By		   :	Hemangi Kambli
    //Create Date	   :	4th May 2007
    //Remarks 		   :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerOtherDtlBV(string sCaseId, string sVeriType)
    {
        string sSql = "";

        sSql="SELECT REL_WITH_APPLICANT, PERSON_CONTACTED, CONT_PERSON_REMARK, IS_NEGATIVE_AREA, IS_OCL, LOCALITY_TYPE, RES_TYPE, "+
             "ADD_ON_APPLIED, RES_YEAR, OFF_ADDRESS_YEARS,OFF_NAME_ON_BOARD, STOCK_SIGHTED, OFF_ACTIVITY_SIGHTED, BUSINESS_TYPE, OFF_LOCATION_TYPE, " +
             "AGENCY_NAME,BUSINESS_TYPE,FaxNumber,Is_Security_guard_building," +
             "Is_Reception_Desk,No_Desks_Workstations_Tables,Is_TradeLicense_Displayed,No_Of_Employees, " +
             "Branch1_Location,Branch1_TelephoneNo,Branch1_Rental_Amt,Branch1_FaxNo,Branch1_ManagerName," +
             "Branch2_Location,Branch2_TelephoneNo,Branch2_Rental_Amt,Branch2_FaxNo,Branch2_ManagerName," +
             "Branch3_Location,Branch3_TelephoneNo,Branch3_Rental_Amt,Branch3_FaxNo,Branch3_ManagerName," +
             "Branch4_Location,Branch4_TelephoneNo,Branch4_Rental_Amt,Branch4_FaxNo,Branch4_ManagerName," +
             "Sponsor1_Name,Type1,Sponsor1_TelephoneNo,Sponsor1_Address,Sponsor2_Name,Type2,Sponsor2_TelephoneNo," +
             "Sponsor2_Address,Sponsor3_Name,Type3,Sponsor3_TelephoneNo,Sponsor3_Address,No_Emps_SeniorPosition," +
             "Business_Nature,Product_Dealt_With,BankName1,Type_Of_Account1,Facilities1,BankName2,Type_Of_Account2," +
             "Facilities2,BankName3,Type_Of_Account3,Facilities3,Sales_In,Avg_Monthly_Turnover,Client_List," +
             "Impression_Of_Office,Credit_Analyst_Decision,Credit_Analyst_Name,Credit_Analyst_Date," +
             "Office_Verification_No,Telephone_Bill,Employment_Status,Years_In_Employment_Business," +
             "Cm_Design,Basic_Salary,Transport_Allowance,House_Rent_Allowance,Fixed_Allowance," +
             "Total_Fixed_Salary,Additional_Comments,Employment_Confirmed_With," +
             "Employment_Confirmed_With_Designation," +
             "Details_Of_Trade_License,Type_Of_Salary,Application_No,Number_Branches_Office_Warehouse," +
             "OFFICE_CUM_RESIDENCE,PHOTOGRAPH_LOCATION,EMIRATE,APPLICANT_REPORT_TO_NAME, " +
             "APPLICANT_REPORT_TO_DESGN,APPLICANT_HOME_COUNTRY_PHONE,IS_COMPANY_PART_GROUP_COMPANIES,MAIN_BUSINESS_COMPANY_ACTIVITY," +
             "NAME_OF_OWNER,BRANCHES_WARESHOUSE_COMPANY_IN_UAE " +
             "FROM CPV_CC_VERI_OTHER_DETAILS "+
             "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "' ";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseVerOtherDtlBV

    #region GetCaseVerDtlBV
    //Name          :   GetCaseVerDtlBV
    //Create By		:	Hemangi Kambli
    //Create Date	:	4th May 2007
    //Remarks 	    :	This returns verification records by passing caseid and verification type

    public OleDbDataReader GetCaseVerDtlBV(string sCaseId, string sVeriType)
    {
        string sSql = "";

        sSql = "SELECT DECLINED_CODE,DECLINED_REASON,CASE_STATUS_ID,OVERALL_ASSESMENT,OVERALL_ASSESMENT_REASON,RATING,SUPERVISOR_REMARKS,SUPERVISOR_ID " +
               "FROM CPV_CC_VERI_DETAILS " +
               "WHERE CASE_ID = '" + sCaseId + "' AND VERIFICATION_TYPE_ID = '" + sVeriType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseVerDtlBV

    #region GetCaseDetail
    public OleDbDataReader GetCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT (ISNULL(FIRST_NAME,'')+ ' ' + ISNULL(MIDDLE_NAME,'')+ ' ' +ISNULL(LAST_NAME,'')) AS FULL_NAME,REF_NO,(ISNULL(RES_ADD_LINE_1,'')+' ' +ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '+ISNULL(RES_CITY,'')) AS RES_ADDRESS, " +
               " (ISNULL(OFF_ADD_LINE_1,'')+' '+ISNULL(OFF_ADD_LINE_2,'')+' '+ISNULL(OFF_ADD_LINE_3,'')+' '+ISNULL(OFF_CITY,'')+' '+ISNULL(OFF_PIN_CODE,'')) AS OFFICE_ADDRESS, "+
               " (ISNULL(PMT_ADD_LINE_1,'')+' '+ISNULL(PMT_ADD_LINE_2,'')+' '+ISNULL(PMT_ADD_LINE_3,'')+' '+ISNULL(PMT_CITY,'')+' '+ISNULL(PMT_PIN_CODE,'')) AS Permanent_ADDRESS, " +
               " (ISNULL(OFF_PHONE,'')+ ' '+ISNULL(OFF_EXTN,'')) AS OFFICE_PHONEEXTN,DESIGNATION,Case_REC_DATETIME,OFF_PHONE,OFF_EXTN,OFF_PIN_CODE,OFF_NAME, " +
               " RES_PIN_CODE,RES_LAND_MARK,RES_PHONE,MOBILE,DOB,TYPE_OF_APPLICANT,FAX_NO,TYPE_OF_LOAN,Pick_Up_Status_1,Date_1,Pick_Up_Status_2,Date_2,Pick_Up_Status_3,Date_3,Pick_Up_Status_Final,Picked_up_Date,Pick_Up_Feedback,Return_Date,Despatch_Date,FE_Name,FE_CODE,FE_Mobile,TME_Name FROM CPV_CC_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseDetail

    #region GetCaseDetailDcr
    public OleDbDataReader GetCaseDetailDcr(string sCaseId)
    {
        string sSql = "";
        
        sSql = "SELECT (ISNULL(FIRST_NAME,'')+ ' ' + ISNULL(MIDDLE_NAME,'')+ ' ' +ISNULL(LAST_NAME,'')) AS FULL_NAME,case_details.REF_NO," +
              "RES_ADD_LINE_1 AS RES_ADDRESS,  (ISNULL(OFF_ADD_LINE_1,'')+' '+ISNULL(OFF_ADD_LINE_2,'')+' '+ISNULL(OFF_ADD_LINE_3,'')+' '+ISNULL(OFF_CITY,'')+' '+ISNULL(OFF_PIN_CODE,'')) AS " +
              "OFFICE_ADDRESS,  (ISNULL(PMT_ADD_LINE_1,'')+' '+ISNULL(PMT_ADD_LINE_2,'')+' '+ISNULL(PMT_ADD_LINE_3,'')+' '+ISNULL(PMT_CITY,'')+' '+ISNULL(PMT_PIN_CODE,'')) AS " +
              "Permanent_ADDRESS,  (ISNULL(OFF_PHONE,'')+ ' '+ISNULL(OFF_EXTN,'')) AS OFFICE_PHONEEXTN,DESIGNATION,Case_REC_DATETIME," +
              "OFF_PHONE,OFF_EXTN,OFF_PIN_CODE,OFF_NAME,  RES_PIN_CODE,RES_LAND_MARK,RES_PHONE,case_details.MOBILE,case_details.DOB,TYPE_OF_APPLICANT,FAX_NO, " +
              "TYPE_OF_LOAN,Pick_Up_Status_1,Date_1,Pick_Up_Status_2,Date_2,Pick_Up_Status_3,Date_3,Pick_Up_Status_Final, " +
              "Picked_up_Date,Pick_Up_Feedback,Return_Date,Despatch_Date,emp_details.fullname as FE_Name,emp_details.emp_code as FE_CODE, " +
              "emp_details.mobile as FE_Mobile,TME_Name,RES_ADD_LINE_1,RES_ADD_LINE_2,Pmt_Phone,RES_ADD_LINE_3, " +
              "OS_BALANCE,EMI,TENURE,ROI,Special_Remarks,New_Balance,Reversal_Amount,volm_Count,Dialed_No,Phone_1,Phone_2,Res_City,Off_Phone,Region,Off_Name " +
              "from CPV_DCR_CASE_DETAILS case_details left outer join CPV_DCR_FE_CASE_MAPPING Fe_Mapping on case_details.case_id=Fe_Mapping.case_id left outer join employee_master emp_details on " +
              "Fe_Mapping.fe_id=emp_details.emp_id where case_details.CASE_ID='" + sCaseId + "'";


        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCaseDetailDcr
    #region GetVerificationDetail()
    public OleDbDataReader GetVerificationDetail(string sCaseId,string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CCV.Verification_type_id from  CPV_CC_CASE_DETAILS CD " +
               " INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE CCV ON CD.Case_ID=CCV.Case_ID " +
               " WHERE CCV.case_id='" + sCaseId + "' " +
               " And CCV.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetVerifierID()
    public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_CC_FE_CASE_MAPPING where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetFERecords()
    public OleDbDataReader GetFERecords(string sCaseId, string sVerifyType, string sUserId)
    {
        string sSql = "";
        sSql = "select FE_ID,verification_type_id from CPV_CC_FE_CASE_MAPPING where case_id='" + sCaseId + "' " +
               " And verification_type_id='" + sVerifyType + "'" +
               " And FE_Id='" + sUserId + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetFERecords()

    #region InsertUpdateCCBusiVerificationEntry() Business verification(BV)
    //Function Name    :   InsertCCVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   26th April 2007
    //Remarks 		   :   This method is used to insert new verification entry.

    public string InsertUpdateCCBusiVerificationEntry(ArrayList arrAttempt)
    {

        string sRetVal = "";
        string strError = "";
        try
        {
            
            string sSql = "";

            //Added By		   :   sandeep khare
            //Create Date	   :   22 dec 2007
            //Remarks 		   :  this transaction is used for checking in which table we have to insert or update 

            OleDbConnection oledbConn0 = new OleDbConnection(objCon.ConnectionString);
            oledbConn0.Open();
            OleDbTransaction oledbTrans0 = oledbConn0.BeginTransaction();
            OleDbParameter[] oledbParam0 = new OleDbParameter[3];
            oledbParam0[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            oledbParam0[0].Value = CaseId;
            oledbParam0[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
            oledbParam0[1].Value = VerificationType;
            oledbParam0[2] = new OleDbParameter("@TableToEdit", OleDbType.VarChar, 15);
            oledbParam0[2].Direction = ParameterDirection.Output;

            //end
            //--------------------------
           
            //Modified By		   :   sandeep khare
            // Modified date       : 22 dec 2007
            // Remark              :we have taken saperate transaction for each table and we have used stored procedure 
            OleDbHelper.ExecuteNonQuery(oledbTrans0, CommandType.StoredProcedure, "spTableToEdit", oledbParam0);
            string[] strTableToEditArray = oledbParam0[2].Value.ToString().Split(',');

            
            OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
            oledbConn.Open();
            OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
            try
            {
                
                         


                /////--------CPV_CC_VERI_DESCRIPTION-------------------
                ///////////////////////for inserting in table CPV_CC_VERI_DESCRIPTION

                OleDbParameter[] paramCCVerDesc = new OleDbParameter[51];
                paramCCVerDesc[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[0].Equals("1")))
                {
                    paramCCVerDesc[0].Value = "ADD";
                    
                }
                else
                
                {
                    paramCCVerDesc[0].Value = "EDIT";

                }
                paramCCVerDesc[1] = new OleDbParameter("@Case_Id", OleDbType.VarChar, 15);
                paramCCVerDesc[1].Value = CaseId;
                paramCCVerDesc[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramCCVerDesc[2].Value = VerificationType;
                paramCCVerDesc[3] = new OleDbParameter("@PP_NORMAL", OleDbType.VarChar, 6);
                paramCCVerDesc[3].Value = PPNormal;
                paramCCVerDesc[4] = new OleDbParameter("@TIME_AT_CURR_Y_M", OleDbType.VarChar, 10);
                paramCCVerDesc[4].Value = TimeCurrYrsMths;
                paramCCVerDesc[5] = new OleDbParameter("@APPROXIMATE_AREA", OleDbType.VarChar, 50);
                paramCCVerDesc[5].Value = ApproxArea;
                paramCCVerDesc[6] = new OleDbParameter("@GENRAL_APPEARANCE", OleDbType.VarChar, 100);
                paramCCVerDesc[6].Value = GeneralAppearance;
                paramCCVerDesc[7] = new OleDbParameter("@ASSETS_VISIBLE", OleDbType.VarChar, 100);
                paramCCVerDesc[7].Value = AssetsVisible;
                paramCCVerDesc[8] = new OleDbParameter("@PROOF_OF_VISIT_COLLECTED", OleDbType.VarChar, 100);
                paramCCVerDesc[8].Value = VisitProof;
                paramCCVerDesc[9] = new OleDbParameter("@ROUTE_MAP_DRAWN", OleDbType.VarChar, 50);
                paramCCVerDesc[9].Value = RouteMap;
                paramCCVerDesc[10] = new OleDbParameter("@TPC_DONE", OleDbType.VarChar, 50);
                paramCCVerDesc[10].Value = TPCDone;
                paramCCVerDesc[11] = new OleDbParameter("@TPC_DETAILS ", OleDbType.VarChar, 255);
                paramCCVerDesc[11].Value = TPCDetail;
                paramCCVerDesc[12] = new OleDbParameter("@ANY_OTHER_INFO_OBT", OleDbType.VarChar, 100);
                paramCCVerDesc[12].Value = AnyInformation;
                paramCCVerDesc[13] = new OleDbParameter("@ADRESS_CONFIRMATION", OleDbType.VarChar, 20);
                paramCCVerDesc[13].Value = AddressConfirmation;
                paramCCVerDesc[14] = new OleDbParameter("@CONTACTABILITY", OleDbType.VarChar, 20);
                paramCCVerDesc[14].Value = Contactability;
                //paramCCVerDesc[14] = new OleDbParameter("@ApplicationConfirm", OleDbType.VarChar,1);
                paramCCVerDesc[15] = new OleDbParameter("@CONFIRMATION_IF_APPLICANT_MET", OleDbType.VarChar, 50);
                paramCCVerDesc[15].Value = ApplicationConfirm;
                paramCCVerDesc[16] = new OleDbParameter("@PROFILE", OleDbType.VarChar, 200);
                paramCCVerDesc[16].Value = Profile;
                paramCCVerDesc[17] = new OleDbParameter("@REPUTATION", OleDbType.VarChar, 50);
                paramCCVerDesc[17].Value = Reputation;
                paramCCVerDesc[18] = new OleDbParameter("@PERSON_CONTACTED_MET", OleDbType.VarChar, 100);
                paramCCVerDesc[18].Value = PersonContacted;
                paramCCVerDesc[19] = new OleDbParameter("@APPLICANT_AGE", OleDbType.VarChar, 50);
                paramCCVerDesc[19].Value = ApproxAgeOfApp;
                paramCCVerDesc[20] = new OleDbParameter("@PRIORITY_CUSTOMER", OleDbType.VarChar, 10);
                paramCCVerDesc[20].Value = PriorityCustomer;
                paramCCVerDesc[21] = new OleDbParameter("@INFO_REQUIRED ", OleDbType.VarChar, 10);
                paramCCVerDesc[21].Value = InfoRequired;
                paramCCVerDesc[22] = new OleDbParameter("@CHANGE_IN_ADRESS", OleDbType.VarChar, 50);
                paramCCVerDesc[22].Value = ChangeInAdd;
                paramCCVerDesc[23] = new OleDbParameter("@REASON_FOR_CHANGE", OleDbType.VarChar, 30);
                paramCCVerDesc[23].Value = ReasonOfChange;
                paramCCVerDesc[24] = new OleDbParameter("@OFFICE_TELEPHONE", OleDbType.VarChar, 20);
                paramCCVerDesc[24].Value = OfficePhone;
                paramCCVerDesc[25] = new OleDbParameter("@BRANCH", OleDbType.VarChar, 20);
                paramCCVerDesc[25].Value = Branch;
                paramCCVerDesc[26] = new OleDbParameter("@INFO_REFUSED", OleDbType.VarChar, 20);
                paramCCVerDesc[26].Value = InfoRefused;
                paramCCVerDesc[27] = new OleDbParameter("@REASON_ADD_NOT_CONFIRM", OleDbType.VarChar, 30);
                paramCCVerDesc[27].Value = ReasonAddNotConfirm;
                paramCCVerDesc[28] = new OleDbParameter("@LOCALITY", OleDbType.VarChar, 20);
                paramCCVerDesc[28].Value = Locality;
                paramCCVerDesc[29] = new OleDbParameter("@RESULT_CALLING", OleDbType.VarChar, 20);
                paramCCVerDesc[29].Value = ResultOfCalling;
                paramCCVerDesc[30] = new OleDbParameter("@MISMATCH_RESI_ADD", OleDbType.VarChar, 30);
                paramCCVerDesc[30].Value = MismatchResiAdd;
                //paramCCVerDesc[30] = new OleDbParameter("@IsAppKnown", OleDbType.VarChar,1);
                paramCCVerDesc[31] = new OleDbParameter("@IS_APP_KNOWN_PERSON", OleDbType.VarChar, 50);
                paramCCVerDesc[31].Value = IsAppKnown;
                paramCCVerDesc[32] = new OleDbParameter("@ADDRESS_BELONG", OleDbType.VarChar, 15);
                paramCCVerDesc[32].Value = ToWhomAddBelong;
                paramCCVerDesc[33] = new OleDbParameter("@ACCOMODATION", OleDbType.VarChar, 15);
                paramCCVerDesc[33].Value = Accomodation;
                paramCCVerDesc[34] = new OleDbParameter("@LOCATING_ADDRESS", OleDbType.VarChar, 50);
                paramCCVerDesc[34].Value = LocatingAddress;
                paramCCVerDesc[35] = new OleDbParameter("@FAMILY_MEMBERS", OleDbType.VarChar, 20);
                paramCCVerDesc[35].Value = NoOfFamilyMem;
                paramCCVerDesc[36] = new OleDbParameter("@ENTRY_PERMITTED", OleDbType.VarChar, 10);
                paramCCVerDesc[36].Value = EntryPermit;
                paramCCVerDesc[37] = new OleDbParameter("@TIME_AT_CURR_RESIDANCE", OleDbType.VarChar, 15);
                paramCCVerDesc[37].Value = TimeAtCurrResi;
                paramCCVerDesc[38] = new OleDbParameter("@INTERIOR", OleDbType.VarChar, 100);
                paramCCVerDesc[38].Value = Interior;
                paramCCVerDesc[39] = new OleDbParameter("@EXTERIOR", OleDbType.VarChar, 15);
                paramCCVerDesc[39].Value = Exterior;
                paramCCVerDesc[40] = new OleDbParameter("@VERIFIED_NEIGHBOUR", OleDbType.VarChar, 30);
                paramCCVerDesc[40].Value = VerifiedFrom;

                ////////////////////////////////Modified By Santosh Shelar 17th May 2008////////////////////
                paramCCVerDesc[41] = new OleDbParameter("@Ass_Vis_AC", OleDbType.VarChar, 50);
                paramCCVerDesc[41].Value = Ass_Vis_AC;
                paramCCVerDesc[42] = new OleDbParameter("@Ass_Vis_Comp", OleDbType.VarChar, 50);
                paramCCVerDesc[42].Value = Ass_Vis_Comp;
                paramCCVerDesc[43] = new OleDbParameter("@Ass_Vis_PH", OleDbType.VarChar, 50);
                paramCCVerDesc[43].Value = Ass_Vis_PH;
                paramCCVerDesc[44] = new OleDbParameter("@Ass_Vis_PhotCop", OleDbType.VarChar, 50);
                paramCCVerDesc[44].Value = Ass_Vis_PhotCop;
                paramCCVerDesc[45] = new OleDbParameter("@Ass_Vis_Fax", OleDbType.VarChar, 50);
                paramCCVerDesc[45].Value = Ass_Vis_Fax;
                paramCCVerDesc[46] = new OleDbParameter("@Ass_Vis_Print", OleDbType.VarChar, 50);
                paramCCVerDesc[46].Value = Ass_Vis_Print;
                /////Santosh Shelar : Start//////////
                paramCCVerDesc[47] = new OleDbParameter("@Other_nature_of_business", OleDbType.VarChar, 50);
                paramCCVerDesc[47].Value = other_nature_of_business;
                /////Santosh Shelar : End////////////
                //paramCCVerDesc[40].Value = null;
                ////////////////////////////////Modified By Santosh Shelar 17th May 2008 : End(BV)////////////////////
                //Naresh 13/05/2008 start
                paramCCVerDesc[48] = new OleDbParameter("@NatureBusiness", OleDbType.VarChar, 25);
                paramCCVerDesc[48].Value = NatureBusiness;
                paramCCVerDesc[49] = new OleDbParameter("@ServiceProvider", OleDbType.VarChar, 25);
                paramCCVerDesc[49].Value = ServiceProvider;

                paramCCVerDesc[50] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramCCVerDesc[50].Direction = ParameterDirection.Output;
                //Naresh 13/05/2008 End

                //paramCCVerDesc[40].Value = null;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddEditCCDescriptionBV",paramCCVerDesc);
                if (Convert.ToInt32( paramCCVerDesc[50].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(paramCCVerDesc[50].Value) == 2)
                {
                    sRetVal = "Record updated successfully.";
                }
                else
                {
                    sRetVal = "There is some error in Data entry .";
 
                }
                oledbTrans.Commit();
                oledbConn.Close();
            }
            catch(Exception ex)
            {
                 oledbTrans.Rollback();
                  oledbConn.Close();
                  strError = ex.Message;
            }
            
            //////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_DESCRIPTION1-------------------
            OleDbConnection oledbConn1 = new OleDbConnection(objCon.ConnectionString);
            oledbConn1.Open();
            OleDbTransaction oledbTrans1 = oledbConn1.BeginTransaction();
            try
            {
               
                sSql = "";
                OleDbParameter[] paramCCVerDesc1 = new OleDbParameter[68];
                paramCCVerDesc1[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[1].Equals("1")))
                {
                    paramCCVerDesc1[0].Value = "ADD";

                }
                else
                {
                    paramCCVerDesc1[0].Value = "EDIT";

                }

                    paramCCVerDesc1[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCCVerDesc1[1].Value = CaseId;
                    paramCCVerDesc1[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCCVerDesc1[2].Value = VerificationType;
                    paramCCVerDesc1[3] = new OleDbParameter("@PersonContName", OleDbType.VarChar, 100);
                    paramCCVerDesc1[3].Value = PersonContName;
                    paramCCVerDesc1[4] = new OleDbParameter("@PersonContDesgn", OleDbType.VarChar, 100);
                    paramCCVerDesc1[4].Value = PersonContDesgn;
                    paramCCVerDesc1[5] = new OleDbParameter("@TypeOfBusiness", OleDbType.VarChar, 100);
                    paramCCVerDesc1[5].Value = TypeOfBusiness;
                    paramCCVerDesc1[6] = new OleDbParameter("@NoOfYearINComp", OleDbType.VarChar, 50);
                    paramCCVerDesc1[6].Value = NoOfYearINComp;
                    paramCCVerDesc1[7] = new OleDbParameter("@EmpJobType", OleDbType.VarChar, 50);
                    paramCCVerDesc1[7].Value = EmpJobType;
                    paramCCVerDesc1[8] = new OleDbParameter("@OfficePremises", OleDbType.VarChar, 50);
                    paramCCVerDesc1[8].Value = OfficePremises;
                    paramCCVerDesc1[9] = new OleDbParameter("@IncomeDocs", OleDbType.VarChar, 20);
                    paramCCVerDesc1[9].Value = IncomeDocs;
                    paramCCVerDesc1[10] = new OleDbParameter("@ReasonNonVisNameplate", OleDbType.VarChar, 100);
                    paramCCVerDesc1[10].Value = ReasonNonVisNameplate;
                    paramCCVerDesc1[11] = new OleDbParameter("@OfficeSize", OleDbType.VarChar, 15);
                    paramCCVerDesc1[11].Value = OfficeSize;
                    paramCCVerDesc1[12] = new OleDbParameter("@NoOfEmployee", OleDbType.VarChar, 10);
                    paramCCVerDesc1[12].Value = NoOfEmployee;
                    paramCCVerDesc1[13] = new OleDbParameter("@OfficeIsIn", OleDbType.VarChar, 100);
                    paramCCVerDesc1[13].Value = OfficeIsIn;
                    paramCCVerDesc1[14] = new OleDbParameter("@AffiPoliticalParty", OleDbType.VarChar, 15);
                    paramCCVerDesc1[14].Value = AffiPoliticalParty;
                    paramCCVerDesc1[15] = new OleDbParameter("@EquipSightedInOff", OleDbType.VarChar, 100);
                    paramCCVerDesc1[15].Value = EquipSightedInOff;
                    paramCCVerDesc1[16] = new OleDbParameter("@BusinessStockSeen", OleDbType.VarChar, 20);
                    paramCCVerDesc1[16].Value = BusinessStockSeen;
                    paramCCVerDesc1[17] = new OleDbParameter("@StockType", OleDbType.VarChar, 15);
                    paramCCVerDesc1[17].Value = StockType;
                    paramCCVerDesc1[18] = new OleDbParameter("@BusinessActivity", OleDbType.VarChar, 20);
                    paramCCVerDesc1[18].Value = BusinessActivity;
                    paramCCVerDesc1[19] = new OleDbParameter("@TPCName", OleDbType.VarChar, 20);
                    paramCCVerDesc1[19].Value = TPCName;
                    paramCCVerDesc1[20] = new OleDbParameter("@FERemark", OleDbType.VarChar, 750);
                    paramCCVerDesc1[20].Value = FERemark;
                    paramCCVerDesc1[21] = new OleDbParameter("@CoAppName", OleDbType.VarChar, 100);
                    paramCCVerDesc1[21].Value = CoAppName;
                    paramCCVerDesc1[22] = new OleDbParameter("@NoOfCustPerDay", OleDbType.VarChar, 50);
                    paramCCVerDesc1[22].Value = NoOfCustPerDay;
                    paramCCVerDesc1[23] = new OleDbParameter("@AppJobTransferable", OleDbType.VarChar, 20);
                    paramCCVerDesc1[23].Value = AppJobTransferable;
                    paramCCVerDesc1[24] = new OleDbParameter("@YearsWorkIn", OleDbType.VarChar, 50);
                    paramCCVerDesc1[24].Value = YearsWorkIn;
                    paramCCVerDesc1[25] = new OleDbParameter("@SalaryDrawn", OleDbType.VarChar, 50);
                    paramCCVerDesc1[25].Value = SalaryDrawn;
                    paramCCVerDesc1[26] = new OleDbParameter("@ConstructionOffice", OleDbType.VarChar, 100);
                    paramCCVerDesc1[26].Value = ConstructionOffice;
                    paramCCVerDesc1[27] = new OleDbParameter("@NoOfCustSeen", OleDbType.VarChar, 50);
                    paramCCVerDesc1[27].Value = NoOfCustSeen;
                    paramCCVerDesc1[28] = new OleDbParameter("@Segmentation", OleDbType.VarChar, 15);
                    paramCCVerDesc1[28].Value = Segmentation;
                    paramCCVerDesc1[29] = new OleDbParameter("@RelationPerContacted", OleDbType.VarChar, 100);
                    paramCCVerDesc1[29].Value = RelationPerContacted;
                    paramCCVerDesc1[30] = new OleDbParameter("@DetailsProofCollected", OleDbType.VarChar, 100);
                    paramCCVerDesc1[30].Value = DetailsProofCollected;
                    paramCCVerDesc1[31] = new OleDbParameter("@Other1", OleDbType.VarChar, 100);
                    paramCCVerDesc1[31].Value = Other1;
                    paramCCVerDesc1[32] = new OleDbParameter("@Other2", OleDbType.VarChar, 100);
                    paramCCVerDesc1[32].Value = Other2;
                    paramCCVerDesc1[33] = new OleDbParameter("@Nature_Busi_Resi_Cum_Off", OleDbType.VarChar, 200);
                    paramCCVerDesc1[33].Value = Nature_Busi_Resi_Cum_Off;
                    paramCCVerDesc1[34] = new OleDbParameter("@Resi_Cum_Off_Owned", OleDbType.VarChar, 20);
                    paramCCVerDesc1[34].Value = Resi_Cum_Off_Owned;
                    paramCCVerDesc1[35] = new OleDbParameter("@SeperateForOffice", OleDbType.VarChar, 25);
                    paramCCVerDesc1[35].Value = SeperateForOffice;
                    //paramCCVerDesc1[35] = new OleDbParameter("@IsAppFullTime", OleDbType.VarChar,1);
                    paramCCVerDesc1[36] = new OleDbParameter("@IsAppFullTime", OleDbType.VarChar, 50);
                    paramCCVerDesc1[36].Value = IsAppFullTime;
                    paramCCVerDesc1[37] = new OleDbParameter("@TPCTypeCompany", OleDbType.VarChar, 20);
                    paramCCVerDesc1[37].Value = TPCTypeCompany;
                    paramCCVerDesc1[38] = new OleDbParameter("@TPCTypeBusiness", OleDbType.VarChar, 20);
                    paramCCVerDesc1[38].Value = TPCTypeBusiness;
                    paramCCVerDesc1[39] = new OleDbParameter("@UntraceableReason", OleDbType.VarChar, 100);
                    paramCCVerDesc1[39].Value = UntraceableReason;
                    paramCCVerDesc1[40] = new OleDbParameter("@VerificationConductAt", OleDbType.VarChar, 15);
                    paramCCVerDesc1[40].Value = VerificationConductAt;
                    paramCCVerDesc1[41] = new OleDbParameter("@DirectoryCheck", OleDbType.VarChar, 100);
                    paramCCVerDesc1[41].Value = DirectoryCheck;
                    paramCCVerDesc1[42] = new OleDbParameter("@WhoAreYourCustomer", OleDbType.VarChar, 100);
                    paramCCVerDesc1[42].Value = WhoAreYourCustomer;
                    paramCCVerDesc1[43] = new OleDbParameter("@Neighbour2Name", OleDbType.VarChar, 15);
                    paramCCVerDesc1[43].Value = Neighbour2Name;
                    paramCCVerDesc1[44] = new OleDbParameter("@Neighbour2Add", OleDbType.VarChar, 25);
                    paramCCVerDesc1[44].Value = Neighbour2Add;
                    paramCCVerDesc1[45] = new OleDbParameter("@CoEstablishIn", OleDbType.VarChar, 50);
                    paramCCVerDesc1[45].Value = CoEstablishIn;
                    paramCCVerDesc1[46] = new OleDbParameter("@LandmarkObserved", OleDbType.VarChar, 25);
                    paramCCVerDesc1[46].Value = LandmarkObserved;
                    paramCCVerDesc1[47] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                    paramCCVerDesc1[47].Value = PermanentAddress;
                    paramCCVerDesc1[48] = new OleDbParameter("@CompanyName", OleDbType.VarChar, 100);
                    paramCCVerDesc1[48].Value = CompanyName;
                    paramCCVerDesc1[49] = new OleDbParameter("@TimeCurrOfficeYrsMths", OleDbType.VarChar, 50);
                    paramCCVerDesc1[49].Value = TimeCurrOfficeYrsMths;
                    paramCCVerDesc1[50] = new OleDbParameter("@OfficeExtn", OleDbType.VarChar, 5);
                    paramCCVerDesc1[50].Value = OfficeExtn;
                    paramCCVerDesc1[51] = new OleDbParameter("@DesgnAtOffice", OleDbType.VarChar, 100);
                    paramCCVerDesc1[51].Value = DesgnAtOffice;
                    paramCCVerDesc1[52] = new OleDbParameter("@OfficeLocality", OleDbType.VarChar, 100);
                    paramCCVerDesc1[52].Value = OfficeLocality;
                    paramCCVerDesc1[53] = new OleDbParameter("@BusinessNature", OleDbType.VarChar, 100);
                    paramCCVerDesc1[53].Value = BusinessNature;
                    paramCCVerDesc1[54] = new OleDbParameter("@Particulars", OleDbType.VarChar, 100);
                    paramCCVerDesc1[54].Value = Particulars;
                    paramCCVerDesc1[55] = new OleDbParameter("@AvgMonthTurnOver", OleDbType.VarChar, 15);
                    paramCCVerDesc1[55].Value = AvgMonthTurnOver;
                    paramCCVerDesc1[56] = new OleDbParameter("@AnyOtherPhoneNo", OleDbType.VarChar, 15);
                    paramCCVerDesc1[56].Value = AnyOtherPhoneNo;
                    paramCCVerDesc1[57] = new OleDbParameter("@ChangeInPhone", OleDbType.VarChar, 15);
                    paramCCVerDesc1[57].Value = ChangeInPhone;
                    paramCCVerDesc1[58] = new OleDbParameter("@EmpSighted", OleDbType.VarChar, 15);
                    paramCCVerDesc1[58].Value = EmpSighted;
                    paramCCVerDesc1[59] = new OleDbParameter("@AppMetAt", OleDbType.VarChar, 50);
                    paramCCVerDesc1[59].Value = AppMetAt;
                    paramCCVerDesc1[60] = new OleDbParameter("@NameOfCompany1", OleDbType.VarChar, 50);
                    paramCCVerDesc1[60].Value = NameOfCompany1;
                    paramCCVerDesc1[61] = new OleDbParameter("@PrevEmpDetail", OleDbType.VarChar, 50);
                    paramCCVerDesc1[61].Value = PrevEmpDetail;
                    paramCCVerDesc1[62] = new OleDbParameter("@OfficeReputation", OleDbType.VarChar, 50);
                    paramCCVerDesc1[62].Value = OfficeReputation;
                    paramCCVerDesc1[63] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 255);
                    paramCCVerDesc1[63].Value = OfficeAddress;
                    paramCCVerDesc1[64] = new OleDbParameter("@PinCode", OleDbType.VarChar, 255);
                    paramCCVerDesc1[64].Value = PinCode;
                    paramCCVerDesc1[65] = new OleDbParameter("@TypeOfOffice", OleDbType.VarChar, 100);
                    paramCCVerDesc1[65].Value = TypeOfOffice;
                    paramCCVerDesc1[66] = new OleDbParameter("@AppWorkingAs", OleDbType.VarChar, 100);
                    paramCCVerDesc1[66].Value = AppWorkingAs;
                    paramCCVerDesc1[67] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCCVerDesc1[67].Direction = ParameterDirection.Output;
                
                    OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.StoredProcedure, "spAddEditCCDescription1BV", paramCCVerDesc1);
                    if (Convert.ToInt32(paramCCVerDesc1[67].Value) == 1)
                    {
                        sRetVal = " Record added successfully.";

                    }
                    else if (Convert.ToInt32(paramCCVerDesc1[67].Value) == 2)
                    {
                        sRetVal = " Record updated successfully.";
                    }
                    else
                    {
                        sRetVal = "There is some error  in Data entry .";
                    }
               
                oledbTrans1.Commit();
                oledbConn1.Close();
            }
            catch(Exception ex)
            {
                 oledbTrans1.Rollback();
                 oledbConn1.Close();
                 strError = ex.Message;

            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_OTHER_DETAILS-------------------
            OleDbConnection oledbConn2 = new OleDbConnection(objCon.ConnectionString);
            oledbConn2.Open();
            OleDbTransaction oledbTrans2 = oledbConn2.BeginTransaction();
            try
            {
               
                sSql = "";
                OleDbParameter[] paramCreditCardOtherDtl = new OleDbParameter[100];
                paramCreditCardOtherDtl[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[2].Equals("1")))
                {
                    paramCreditCardOtherDtl[0].Value = "ADD";

                }
                else
                {
                    paramCreditCardOtherDtl[0].Value = "EDIT";

                }

                    paramCreditCardOtherDtl[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[1].Value = CaseId;

                    paramCreditCardOtherDtl[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[2].Value = VerificationType;

                    paramCreditCardOtherDtl[3] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[3].Value = PersonContacted;

                    paramCreditCardOtherDtl[4] = new OleDbParameter("@FERemark", OleDbType.VarChar, 750);
                    paramCreditCardOtherDtl[4].Value = FERemark;

                    paramCreditCardOtherDtl[5] = new OleDbParameter("@NegativeArea", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[5].Value = NegativeArea;

                    paramCreditCardOtherDtl[6] = new OleDbParameter("@OCL", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[6].Value = OCL;

                    paramCreditCardOtherDtl[7] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[7].Value = ResidenceType;

                    paramCreditCardOtherDtl[8] = new OleDbParameter("@AddresssOnApplication", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[8].Value = AddresssOnApplication;

                    paramCreditCardOtherDtl[9] = new OleDbParameter("@NoOfYearsInPresentAdd", OleDbType.Decimal, 9);
                    paramCreditCardOtherDtl[9].Value = NoOfYearsInPresentAdd;

                    paramCreditCardOtherDtl[10] = new OleDbParameter("@BusinessStockSeen", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[10].Value = BusinessStockSeen;

                    paramCreditCardOtherDtl[11] = new OleDbParameter("@BusinessActivity", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[11].Value = BusinessActivity;

                    paramCreditCardOtherDtl[12] = new OleDbParameter("@OfficeLocality", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[12].Value = OfficeLocality;

                    paramCreditCardOtherDtl[13] = new OleDbParameter("@OffNameOnBoard", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[13].Value = OffNameOnBoard;

                    paramCreditCardOtherDtl[14] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[14].Value = AgencyCode;

                    //Start Parametre for News Added City Bank (Dubai)
                    paramCreditCardOtherDtl[15] = new OleDbParameter("@FaxNumber", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[15].Value = FaxNumber;

                    paramCreditCardOtherDtl[16] = new OleDbParameter("@IsThereSecurityGuardForBuildingOffice", OleDbType.VarChar, 50);
                    if (IsThereSecurityGuardForBuildingOffice == "")
                        paramCreditCardOtherDtl[16].Value = "";
                    else
                        paramCreditCardOtherDtl[16].Value = IsThereSecurityGuardForBuildingOffice;

                    paramCreditCardOtherDtl[17] = new OleDbParameter("@IsThereReceptionDesk", OleDbType.VarChar, 5);
                    if (IsThereReceptionDesk == "")
                        paramCreditCardOtherDtl[17].Value = "";
                    else
                        paramCreditCardOtherDtl[17].Value = IsThereReceptionDesk;

                    paramCreditCardOtherDtl[18] = new OleDbParameter("@HowManyDesksWorkstationsTables", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[18].Value = HowManyDesksWorkstationsTables;

                    paramCreditCardOtherDtl[19] = new OleDbParameter("@IsTradeLicenseOfCompanyDisplayedOnPremises", OleDbType.VarChar, 5);
                    if (IsTradeLicenseOfCompanyDisplayedOnPremises == "")
                        paramCreditCardOtherDtl[19].Value = "";
                    else
                        paramCreditCardOtherDtl[19].Value = IsTradeLicenseOfCompanyDisplayedOnPremises;

                    paramCreditCardOtherDtl[20] = new OleDbParameter("@NumberOfEmployees", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[20].Value = NumberOfEmployees;

                    paramCreditCardOtherDtl[21] = new OleDbParameter("@Branch1Location", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[21].Value = Branch1Location;

                    paramCreditCardOtherDtl[22] = new OleDbParameter("@Branch1TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[22].Value = Branch1TelephoneNo;

                    paramCreditCardOtherDtl[23] = new OleDbParameter("@Branch1RentalAmt", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[23].Value = Branch1RentalAmt;

                    paramCreditCardOtherDtl[24] = new OleDbParameter("@Branch1FaxNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[24].Value = Branch1FaxNo;

                    paramCreditCardOtherDtl[25] = new OleDbParameter("@Branch1ManagerName", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[25].Value = Branch1ManagerName;

                    paramCreditCardOtherDtl[26] = new OleDbParameter("@Branch2Location", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[26].Value = Branch2Location;

                    paramCreditCardOtherDtl[27] = new OleDbParameter("@Branch2TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[27].Value = Branch2TelephoneNo;

                    paramCreditCardOtherDtl[28] = new OleDbParameter("@Branch2RentalAmt", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[28].Value = Branch2RentalAmt;

                    paramCreditCardOtherDtl[29] = new OleDbParameter("@Branch2FaxNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[29].Value = Branch2FaxNo;

                    paramCreditCardOtherDtl[30] = new OleDbParameter("@Branch2ManagerName", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[30].Value = Branch2ManagerName;

                    paramCreditCardOtherDtl[31] = new OleDbParameter("@Branch3Location", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[31].Value = Branch3Location;

                    paramCreditCardOtherDtl[32] = new OleDbParameter("@Branch3TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[32].Value = Branch3TelephoneNo;

                    paramCreditCardOtherDtl[33] = new OleDbParameter("@Branch3RentalAmt", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[33].Value = Branch3RentalAmt;

                    paramCreditCardOtherDtl[34] = new OleDbParameter("@Branch3Faxno", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[34].Value = Branch3Faxno;

                    paramCreditCardOtherDtl[35] = new OleDbParameter("@Branch3ManagerName", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[35].Value = Branch3ManagerName;

                    paramCreditCardOtherDtl[36] = new OleDbParameter("@Sponsor1Name", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[36].Value = Sponsor1Name;

                    paramCreditCardOtherDtl[37] = new OleDbParameter("@Type1", OleDbType.VarChar, 20);
                    paramCreditCardOtherDtl[37].Value = Type1;

                    paramCreditCardOtherDtl[38] = new OleDbParameter("@Sponsor1TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[38].Value = Sponsor1TelephoneNo;

                    paramCreditCardOtherDtl[39] = new OleDbParameter("@Sponsor1Address", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[39].Value = Sponsor1Address;

                    paramCreditCardOtherDtl[40] = new OleDbParameter("@Sponsor2Name", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[40].Value = Sponsor2Name;

                    paramCreditCardOtherDtl[41] = new OleDbParameter("@Type2", OleDbType.VarChar, 20);
                    paramCreditCardOtherDtl[41].Value = Type2;

                    paramCreditCardOtherDtl[42] = new OleDbParameter("@Sponsor2TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[42].Value = Sponsor2TelephoneNo;

                    paramCreditCardOtherDtl[43] = new OleDbParameter("@Sponsor2Address", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[43].Value = Sponsor2Address;

                    paramCreditCardOtherDtl[44] = new OleDbParameter("@Sponsor3Name", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[44].Value = Sponsor3Name;

                    paramCreditCardOtherDtl[45] = new OleDbParameter("@Type3", OleDbType.VarChar, 20);
                    paramCreditCardOtherDtl[45].Value = Type3;

                    paramCreditCardOtherDtl[46] = new OleDbParameter("@Sponsor3TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[46].Value = Sponsor3TelephoneNo;

                    paramCreditCardOtherDtl[47] = new OleDbParameter("@Sponsor3Address", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[47].Value = Sponsor3Address;

                    paramCreditCardOtherDtl[48] = new OleDbParameter("@NoOfEmpsInSeniorPosition", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[48].Value = NoOfEmpsInSeniorPosition;

                    paramCreditCardOtherDtl[49] = new OleDbParameter("@NatureOfBusinessSponsor", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[49].Value = NatureOfBusinessSponsor;

                    paramCreditCardOtherDtl[50] = new OleDbParameter("@ProductDealtWith", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[50].Value = ProductDealtWith;

                    paramCreditCardOtherDtl[51] = new OleDbParameter("@BankName1", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[51].Value = BankName1;

                    paramCreditCardOtherDtl[52] = new OleDbParameter("@TypeOfAccount1", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[52].Value = TypeOfAccount1;

                    paramCreditCardOtherDtl[53] = new OleDbParameter("@Facilities1", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[53].Value = Facilities1;

                    paramCreditCardOtherDtl[54] = new OleDbParameter("@BankName2", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[54].Value = BankName2;

                    paramCreditCardOtherDtl[55] = new OleDbParameter("@TypeOfAccount2", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[55].Value = TypeOfAccount2;

                    paramCreditCardOtherDtl[56] = new OleDbParameter("@Facilities2", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[56].Value = Facilities2;

                    paramCreditCardOtherDtl[57] = new OleDbParameter("@BankName3", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[57].Value = BankName3;

                    paramCreditCardOtherDtl[58] = new OleDbParameter("@TypeOfAccount3", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[58].Value = TypeOfAccount3;

                    paramCreditCardOtherDtl[59] = new OleDbParameter("@Facilities3", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[59].Value = Facilities3;

                    paramCreditCardOtherDtl[60] = new OleDbParameter("@SalesIn", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[60].Value = SalesIn;

                    paramCreditCardOtherDtl[61] = new OleDbParameter("@AvgMonthlyTurnover", OleDbType.VarChar, 25);
                    paramCreditCardOtherDtl[61].Value = AvgMonthlyTurnover;

                    paramCreditCardOtherDtl[62] = new OleDbParameter("@ClientList", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[62].Value = ClientList;

                    paramCreditCardOtherDtl[63] = new OleDbParameter("@ImpressionOfOffice", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[63].Value = ImpressionOfOffice;

                    paramCreditCardOtherDtl[64] = new OleDbParameter("@CreditAnalystDecision", OleDbType.VarChar, 50);
                    if (CreditAnalystDecision == "")
                        paramCreditCardOtherDtl[64].Value = "";
                    else
                        paramCreditCardOtherDtl[64].Value = CreditAnalystDecision;

                    paramCreditCardOtherDtl[65] = new OleDbParameter("@CreditAnalystName", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[65].Value = CreditAnalystName;

                    paramCreditCardOtherDtl[66] = new OleDbParameter("@CreditAnalystDate", OleDbType.DBTimeStamp, 8);
                    if (CreditAnalystDate.Trim().Length == 0)
                    {
                        paramCreditCardOtherDtl[66].Value = DBNull.Value;
                    }
                    else
                    {
                        paramCreditCardOtherDtl[66].Value = CreditAnalystDate;
                    }

                    paramCreditCardOtherDtl[67] = new OleDbParameter("@OfficeVerificationNo", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[67].Value = OfficeVerificationNo;

                    paramCreditCardOtherDtl[68] = new OleDbParameter("@TelephoneBill", OleDbType.VarChar, 25);
                    paramCreditCardOtherDtl[68].Value = TelephoneBill;

                    paramCreditCardOtherDtl[69] = new OleDbParameter("@EmploymentStatus", OleDbType.VarChar, 35);
                    if (EmploymentStatus == "")
                        paramCreditCardOtherDtl[69].Value = "";
                    else
                        paramCreditCardOtherDtl[69].Value = EmploymentStatus;

                    paramCreditCardOtherDtl[70] = new OleDbParameter("@YearsInEmploymentBusiness", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[70].Value = YearsInEmploymentBusiness;

                    paramCreditCardOtherDtl[71] = new OleDbParameter("@CmDesign", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[71].Value = CmDesign;

                    paramCreditCardOtherDtl[72] = new OleDbParameter("@BasicSalary", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[72].Value = BasicSalary;

                    paramCreditCardOtherDtl[73] = new OleDbParameter("@TransportAllowance", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[73].Value = TransportAllowance;

                    paramCreditCardOtherDtl[74] = new OleDbParameter("@HouseRentAllowance", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[74].Value = HouseRentAllowance;

                    paramCreditCardOtherDtl[75] = new OleDbParameter("@FixedAllowance", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[75].Value = FixedAllowance;

                    paramCreditCardOtherDtl[76] = new OleDbParameter("@TotalFixedSalary", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[76].Value = TotalFixedSalary;

                    paramCreditCardOtherDtl[77] = new OleDbParameter("@AdditionalComments", OleDbType.VarChar, 250);
                    paramCreditCardOtherDtl[77].Value = AdditionalComments;

                    paramCreditCardOtherDtl[78] = new OleDbParameter("@EmploymentConfirmedWith", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[78].Value = EmploymentConfirmedWith;

                    paramCreditCardOtherDtl[79] = new OleDbParameter("@EmploymentConfirmedWithDesignation", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[79].Value = EmploymentConfirmedWithDesignation;

                    //paramCreditCardOtherDtl[79] = new OleDbParameter("@TypeOfApplicant", OleDbType.VarChar, 15);
                    //paramCreditCardOtherDtl[79].Value = TypeOfApplicant;

                    //paramCreditCardOtherDtl[79] = new OleDbParameter("@TypeOfLoan", OleDbType.VarChar, 15);
                    //paramCreditCardOtherDtl[79].Value = TypeOfLoan;

                    paramCreditCardOtherDtl[80] = new OleDbParameter("@DetailsOfTradeLicense", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[80].Value = DetailsOfTradeLicense;

                    paramCreditCardOtherDtl[81] = new OleDbParameter("@TypeOfSalary", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[81].Value = TypeOfSalary;

                    paramCreditCardOtherDtl[82] = new OleDbParameter("@ApplicationNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[82].Value = ApplicationNo;

                    paramCreditCardOtherDtl[83] = new OleDbParameter("@NumberOfBranchesOfficeWarehouse", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[83].Value = NumberOfBranchesOfficeWarehouse;

                    //////----
                    paramCreditCardOtherDtl[84] = new OleDbParameter("@Branch4Location", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[84].Value = Branch4Location;

                    paramCreditCardOtherDtl[85] = new OleDbParameter("@Branch4TelephoneNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[85].Value = Branch4TelephoneNo;

                    paramCreditCardOtherDtl[86] = new OleDbParameter("@Branch4RentalAmt", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[86].Value = Branch4RentalAmt;

                    paramCreditCardOtherDtl[87] = new OleDbParameter("@Branch4FaxNo", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[87].Value = Branch4FaxNo;

                    paramCreditCardOtherDtl[88] = new OleDbParameter("@Branch4ManagerName", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[88].Value = Branch4ManagerName;
                    //End Parametre for News Added City Bank (Dubai)

                    //Fields added for HSBC Dubai ------
                    paramCreditCardOtherDtl[89] = new OleDbParameter("@OfficeCumResidence", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[89].Value = OfficeCumResidence;

                    paramCreditCardOtherDtl[90] = new OleDbParameter("@PhotographOfLocation", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[90].Value = PhotographOfLocation;

                    paramCreditCardOtherDtl[91] = new OleDbParameter("@Emirate", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[91].Value = Emirate;

                    paramCreditCardOtherDtl[92] = new OleDbParameter("@ApplicantReportToName", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[92].Value = ApplicantReportToName;

                    paramCreditCardOtherDtl[93] = new OleDbParameter("@AppReportToDesignation", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[93].Value = AppReportToDesignation;

                    paramCreditCardOtherDtl[94] = new OleDbParameter("@ApplicantHomeCountryPhoneNo", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[94].Value = ApplicantHomeCountryPhoneNo;

                    paramCreditCardOtherDtl[95] = new OleDbParameter("@IsCompanyPartOfGroupCompanies", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[95].Value = IsCompanyPartOfGroupCompanies;

                    paramCreditCardOtherDtl[96] = new OleDbParameter("@MainBusinessOrCompanyActivity", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[96].Value = MainBusinessOrCompanyActivity;

                    paramCreditCardOtherDtl[97] = new OleDbParameter("@NameOfOwner", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[97].Value = NameOfOwner;

                    paramCreditCardOtherDtl[98] = new OleDbParameter("@BranchesWareHouseCompanyHaveInUAE", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[98].Value = BranchesWareHouseCompanyHaveInUAE;

                    paramCreditCardOtherDtl[99] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCreditCardOtherDtl[99].Direction = ParameterDirection.Output;


                    OleDbHelper.ExecuteNonQuery(oledbTrans2, CommandType.StoredProcedure, "spAddEditVeriOtherDetailsBV", paramCreditCardOtherDtl);
                    if (Convert.ToInt32(paramCreditCardOtherDtl[99].Value) == 1)
                    {
                        sRetVal = " Record added successfully .";

                    }
                    else if (Convert.ToInt32(paramCreditCardOtherDtl[99].Value) == 2)
                    {
                        sRetVal = "Record updated successfully.";
                    }
                    else
                    {
                        sRetVal = "There is some error  in Data entry.";
                    }
                
                oledbTrans2.Commit();
                oledbConn2.Close();
            }
            catch (Exception ex)
            {
                oledbTrans2.Rollback();
                oledbConn2.Close();
                strError = ex.Message;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_DETAILS-------------------
            OleDbConnection oledbConn3 = new OleDbConnection(objCon.ConnectionString);
            oledbConn3.Open();
            OleDbTransaction oledbTrans3 = oledbConn3.BeginTransaction();
            try
            {
                
                sSql = "";
                OleDbParameter[] paramCreditCardVerDtl = new OleDbParameter[14];
                paramCreditCardVerDtl[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[3].Equals("1")))
                {
                    paramCreditCardVerDtl[0].Value = "ADD";

                }
                else
                {
                    paramCreditCardVerDtl[0].Value = "EDIT";

                }

                    paramCreditCardVerDtl[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[1].Value = CaseId;
                    paramCreditCardVerDtl[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[2].Value = VerificationType;
                    paramCreditCardVerDtl[3] = new OleDbParameter("@DeclineReason", OleDbType.VarChar, 255);
                    paramCreditCardVerDtl[3].Value = DeclineReason;
                    paramCreditCardVerDtl[4] = new OleDbParameter("@OverallAssessment", OleDbType.VarChar, 100);
                    paramCreditCardVerDtl[4].Value = OverallAssessment;
                    paramCreditCardVerDtl[5] = new OleDbParameter("@AssesstReason", OleDbType.VarChar, 255);
                    paramCreditCardVerDtl[5].Value = AssesstReason;
                    paramCreditCardVerDtl[6] = new OleDbParameter("@DeclineCode", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[6].Value = DeclineCode;
                    paramCreditCardVerDtl[7] = new OleDbParameter("@CPVScore", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[7].Value = CPVScore;
                    paramCreditCardVerDtl[8] = new OleDbParameter("@SupervisorRemark", OleDbType.VarChar, 750);
                    paramCreditCardVerDtl[8].Value = SupervisorRemark;
                    paramCreditCardVerDtl[9] = new OleDbParameter("@CaseStatusId", OleDbType.VarChar, 10);
                    paramCreditCardVerDtl[9].Value = CaseStatusId;
                    paramCreditCardVerDtl[10] = new OleDbParameter("@SupervisorId", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[10].Value = SupervisorId;
                    paramCreditCardVerDtl[11] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[11].Value = AddedBy;
                    paramCreditCardVerDtl[12] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                    paramCreditCardVerDtl[12].Value = AddedOn;
                    paramCreditCardVerDtl[13] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCreditCardVerDtl[13].Direction = ParameterDirection.Output;


                    OleDbHelper.ExecuteNonQuery(oledbTrans3, CommandType.StoredProcedure, "spAddEditVeriDetailsBV", paramCreditCardVerDtl);
                    if (Convert.ToInt32(paramCreditCardVerDtl[13].Value) == 1)
                    {
                        sRetVal = " Record added successfully.";

                    }
                    else if (Convert.ToInt32(paramCreditCardVerDtl[13].Value) == 2)
                    {
                        sRetVal = " Record updated successfully .";
                    }
                    else
                    {
                        sRetVal = "There is some error in Data entry.";
                    }
               
                oledbTrans3.Commit();
                oledbConn3.Close();
            }
            catch (Exception ex)
            {
                oledbTrans3.Rollback();
                oledbConn3.Close();
                strError = ex.Message;
            }
            //oledbRead.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_CASE_DETAILS-------------------
            ////UPDATE CPV_CC_CASE_DETAILS------------------------------

            //OleDbConnection oledbConn4 = new OleDbConnection(objCon.ConnectionString);
            //oledbConn4.Open();
            //OleDbTransaction oledbTrans4 = oledbConn4.BeginTransaction();
            //try
            //{

            //    OleDbParameter[] paramCreditCardCaseDtl = new OleDbParameter[2];
            
            //    paramCreditCardCaseDtl[0] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
            //    paramCreditCardCaseDtl[0].Value = DateOfBirth;
            //    ////////////////paramCreditCardCaseDtl[1] = new OleDbParameter("@Is_case_complete", OleDbType.Char, 1);
            //    ////////////////paramCreditCardCaseDtl[1].Value = IsCaseComp; 
            //    paramCreditCardCaseDtl[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
            //    paramCreditCardCaseDtl[0].Value = CaseId;
            //    paramCreditCardCaseDtl[1] = new OleDbParameter("@MessageNo", OleDbType.Integer);
            //    paramCreditCardCaseDtl[1].Direction = ParameterDirection.Output;
              

            //    OleDbHelper.ExecuteNonQuery(oledbTrans4, CommandType.StoredProcedure, "spEditCCCaseDetailsBVRV", paramCreditCardCaseDtl);
               
            //    oledbTrans4.Commit();
            //    oledbConn4.Close();
            //}
            //catch (Exception ex)
            //{
             //   oledbTrans4.Rollback();
             //   oledbConn4.Close();
              //  strError = "1";
           // }
                ////START INSERT ATTEMPT DETAILS--------------------
            OleDbConnection oledbConn5 = new OleDbConnection(objCon.ConnectionString);
            oledbConn5.Open();
            OleDbTransaction oledbTrans5 = oledbConn5.BeginTransaction();
            try
            {

                OleDbParameter[] paramDeleteAttempt = new OleDbParameter[7];

                paramDeleteAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                paramDeleteAttempt[0].Value = "DELETE";
                paramDeleteAttempt[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramDeleteAttempt[1].Value = CaseId;
                paramDeleteAttempt[2] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                paramDeleteAttempt[2].Value = VerifierID;
                paramDeleteAttempt[3] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp, 8);
                paramDeleteAttempt[3].Value = AttemptDateTime;
                paramDeleteAttempt[4] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar, 255);
                paramDeleteAttempt[4].Value = AttemptRemark;
                paramDeleteAttempt[5] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
                paramDeleteAttempt[5].Value = VerficationTypeID;
                paramDeleteAttempt[6] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramDeleteAttempt[6].Direction = ParameterDirection.Output;

                OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddDeleteCCAttempt", paramDeleteAttempt);
               
                if (arrAttempt.Count > 0)
                {
                    foreach (ArrayList item in arrAttempt)
                    {
                        AttemptDateTime = item[0].ToString();
                        AttemptRemark = item[1].ToString();

                       
                        OleDbParameter[] paramAttempt = new OleDbParameter[7];
                        paramAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                        paramAttempt[0].Value = "ADD";
                        paramAttempt[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                        paramAttempt[1].Value = CaseId;
                        paramAttempt[2] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                        paramAttempt[2].Value = VerifierID;
                        paramAttempt[3] = new OleDbParameter("@AttemptDateTime", OleDbType.DBTimeStamp, 8);
                        paramAttempt[3].Value = AttemptDateTime;
                        paramAttempt[4] = new OleDbParameter("@AttemptRemark", OleDbType.VarChar, 255);
                        paramAttempt[4].Value = AttemptRemark;
                        paramAttempt[5] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
                        paramAttempt[5].Value = VerficationTypeID;
                        paramAttempt[6] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                        paramAttempt[6].Direction = ParameterDirection.Output;

                        OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddDeleteCCAttempt", paramAttempt);

                    }
                }
              
                oledbTrans5.Commit();
                oledbConn5.Close();
            }
            catch (Exception ex)
            {
                oledbTrans5.Rollback();
                oledbConn5.Close();
                strError = ex.Message;
            }
            ////END INSERT ATTEMPT DETAILS--------------------

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            OleDbConnection oledbConn6 = new OleDbConnection(objCon.ConnectionString);
            oledbConn6.Open();
            OleDbTransaction oledbTrans6 = oledbConn6.BeginTransaction();
            try
            {
                
                sSql = "";
               

                OleDbParameter[] paramTransLog = new OleDbParameter[9];
                paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramTransLog[0].Value = CaseId;
                paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
                paramTransLog[1].Value = VerficationTypeID;
                paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
                paramTransLog[2].Value = UserId;
                paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
                paramTransLog[3].Value = TransStart;
                paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
                paramTransLog[4].Value = TransEnd;
                paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
                paramTransLog[5].Value = CentreId;
                paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
                paramTransLog[6].Value = ProductId;
                paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
                paramTransLog[7].Value = ClientId;
                paramTransLog[8] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramTransLog[8].Direction = ParameterDirection.Output;
                OleDbHelper.ExecuteNonQuery(oledbTrans6, CommandType.StoredProcedure, "spAddCaseTranscation", paramTransLog);
                oledbTrans6.Commit();
                oledbConn6.Close();
            }
            catch (Exception ex)
            {
                oledbTrans6.Rollback();
                oledbConn6.Close();
                strError = ex.Message;
            }

              
                //Modified By		   :   sandeep khare
                // Modified date       : 22 dec 2007
                // Remark              : this transaction ,we use for the case is complete or not ,we have used stored procedure
                 OleDbConnection oledbConn7 = new OleDbConnection(objCon.ConnectionString);
                 oledbConn7.Open();
                 OleDbTransaction oledbTrans7 = oledbConn7.BeginTransaction();
                 try
                 {
                     
                     OleDbParameter[] paramIsCaseComplete = new OleDbParameter[2];
                     paramIsCaseComplete[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                     paramIsCaseComplete[0].Value = CaseId;
                     paramIsCaseComplete[1] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                     paramIsCaseComplete[1].Direction = ParameterDirection.Output;
                     OleDbHelper.ExecuteNonQuery(oledbTrans7, CommandType.StoredProcedure, "spIsCCVerificationComplete", paramIsCaseComplete);
                     if (Convert.ToInt32(paramIsCaseComplete[1].Value) == 1)
                     {
                         sRetVal += "Case verification data entry completed.";
                     }
                     oledbTrans7.Commit();
                     oledbConn7.Close();
                 }
                 catch (Exception ex)
                 {
                     oledbTrans7.Rollback();
                     oledbConn7.Close();
                 }

                /////////////////////////////////////////////////////////////////////////////////////////////            
               
           
        }
        catch 
        {
            
        }
        Error = strError;
        return sRetVal;
    }
    #endregion InsertUpdateCCBusiVerificationEntry() Business verification(BV)
    
    #region InsertUpdateCCResiVerificationEntry() Residence verification(RV)
    //Function Name    :   InsertCCVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   26th April 2007
    //Remarks 		   :   This method is used to insert new verification entry.

    public string InsertUpdateCCResiVerificationEntry(ArrayList arrAttempt)
    {
        
        string sRetVal = "";
      string strError ="";
        try
        {
            string sSql = "";
           
            //Added By		   :   sandeep khare
            //Create Date	   :   22 dec 2007
            //Remarks 		   :  this transaction is used for checking in which table we have to insert or update 
            
            OleDbConnection oledbConn0 = new OleDbConnection(objCon.ConnectionString);
            oledbConn0.Open();
            OleDbTransaction oledbTrans0 = oledbConn0.BeginTransaction();
            OleDbParameter[] oledbParam0 = new OleDbParameter[3];
            oledbParam0[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            oledbParam0[0].Value = CaseId;
            oledbParam0[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
            oledbParam0[1].Value = VerificationType;
            oledbParam0[2] = new OleDbParameter("@TableToEdit", OleDbType.VarChar, 15);
            oledbParam0[2].Direction = ParameterDirection.Output;
            // end
            //-------------------
            
            //Modified By		   :   sandeep khare
            // Modified date       :  22 dec 2007
            // Remark              :we have taken saperate transaction for each table and we have used stored procedure 
            OleDbHelper.ExecuteNonQuery(oledbTrans0, CommandType.StoredProcedure, "spTableToEdit_DCR", oledbParam0);
            string[] strTableToEditArray = oledbParam0[2].Value.ToString().Split(',');

            OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
            oledbConn.Open();
            OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
            

            /////--------CPV_CC_VERI_DESCRIPTION-------------------
            ///////////////////////for inserting in table CPV_CC_VERI_DESCRIPTION

            try
            {

                OleDbParameter[] paramCCVerDesc = new OleDbParameter[100];
                paramCCVerDesc[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[0].Equals("1")))
                {
                    paramCCVerDesc[0].Value = "ADD";

                }
                else
                {
                    paramCCVerDesc[0].Value = "EDIT";

                }
                    paramCCVerDesc[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCCVerDesc[1].Value = CaseId;
                    paramCCVerDesc[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCCVerDesc[2].Value = VerificationType;
                    paramCCVerDesc[3] = new OleDbParameter("@PPNormal", OleDbType.VarChar, 6);
                    paramCCVerDesc[3].Value = PPNormal;
                    paramCCVerDesc[4] = new OleDbParameter("@Qualification", OleDbType.VarChar, 50);
                    paramCCVerDesc[4].Value = Qualification;
                    paramCCVerDesc[5] = new OleDbParameter("@TimeCurrYrsMths", OleDbType.VarChar, 10);
                    paramCCVerDesc[5].Value = TimeCurrYrsMths;
                    paramCCVerDesc[6] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 10);
                    paramCCVerDesc[6].Value = MaritalStatus;
                    //paramCCVerDesc[6] = new OleDbParameter("@SpouseWorking", OleDbType.VarChar,1);
                    paramCCVerDesc[7] = new OleDbParameter("@SpouseWorking", OleDbType.VarChar, 50);
                    paramCCVerDesc[7].Value = SpouseWorking;
                    paramCCVerDesc[8] = new OleDbParameter("@SpouseCompName", OleDbType.VarChar, 100);
                    paramCCVerDesc[8].Value = SpouseCompName;
                    paramCCVerDesc[9] = new OleDbParameter("@TelephoneSpouse", OleDbType.VarChar, 20);
                    paramCCVerDesc[9].Value = TelephoneSpouse;
                    paramCCVerDesc[10] = new OleDbParameter("@NoOfDependent", OleDbType.VarChar, 10);
                    paramCCVerDesc[10].Value = NoOfDependent;
                    paramCCVerDesc[11] = new OleDbParameter("@VehicleType", OleDbType.VarChar, 50);
                    paramCCVerDesc[11].Value = VehicleType;
                    paramCCVerDesc[12] = new OleDbParameter("@VehicleMake", OleDbType.VarChar, 100);
                    paramCCVerDesc[12].Value = VehicleMake;
                    paramCCVerDesc[13] = new OleDbParameter("@VehicleIs", OleDbType.VarChar, 15);
                    paramCCVerDesc[13].Value = VehicleIs;
                    paramCCVerDesc[14] = new OleDbParameter("@VehicleOther", OleDbType.VarChar, 15);
                    paramCCVerDesc[14].Value = VehicleOther;
                    //paramCCVerDesc[14] = new OleDbParameter("@IsCreditCard", OleDbType.VarChar,1);
                    paramCCVerDesc[15] = new OleDbParameter("@IsCreditCard", OleDbType.VarChar, 50);
                    paramCCVerDesc[15].Value = IsCreditCard;
                    paramCCVerDesc[16] = new OleDbParameter("@CardType", OleDbType.VarChar, 50);
                    paramCCVerDesc[16].Value = CardType;
                    paramCCVerDesc[17] = new OleDbParameter("@CardNo", OleDbType.VarChar, 50);
                    paramCCVerDesc[17].Value = CardNo;
                    paramCCVerDesc[18] = new OleDbParameter("@CardLimit", OleDbType.VarChar, 10);
                    paramCCVerDesc[18].Value = CardLimit;
                    paramCCVerDesc[19] = new OleDbParameter("@CardExpiry", OleDbType.VarChar, 12);
                    paramCCVerDesc[19].Value = CardExpiry;
                    paramCCVerDesc[20] = new OleDbParameter("@APPLICANT_AVAILABILITY", OleDbType.VarChar, 12);
                    paramCCVerDesc[20].Value = AppAvailableAt;
                    paramCCVerDesc[21] = new OleDbParameter("@TimeCurrResiYrsMths", OleDbType.VarChar, 15);
                    paramCCVerDesc[21].Value = TimeCurrResiYrsMths;
                    paramCCVerDesc[22] = new OleDbParameter("@AppWorksAt", OleDbType.VarChar, 100);
                    paramCCVerDesc[22].Value = AppWorksAt;
                    paramCCVerDesc[23] = new OleDbParameter("@VerifiedFrom", OleDbType.VarChar, 100);
                    paramCCVerDesc[23].Value = VerifiedFrom;
                    paramCCVerDesc[24] = new OleDbParameter("@ApproxArea", OleDbType.VarChar, 50);
                    paramCCVerDesc[24].Value = ApproxArea;
                    paramCCVerDesc[25] = new OleDbParameter("@GeneralAppearance", OleDbType.VarChar, 100);
                    paramCCVerDesc[25].Value = GeneralAppearance;
                    paramCCVerDesc[26] = new OleDbParameter("@LocatingAddress", OleDbType.VarChar, 50);
                    paramCCVerDesc[26].Value = LocatingAddress;
                    paramCCVerDesc[27] = new OleDbParameter("@AssetsVisible", OleDbType.VarChar, 100);
                    paramCCVerDesc[27].Value = AssetsVisible;
                    //paramCCVerDesc[27] = new OleDbParameter("@PoliticalLeadderPortrait", OleDbType.VarChar,1);
                    paramCCVerDesc[28] = new OleDbParameter("@PoliticalLeadderPortrait", OleDbType.VarChar, 50);
                    paramCCVerDesc[28].Value = PoliticalLeadderPortrait;
                    //paramCCVerDesc[28] = new OleDbParameter("@VisitProof", OleDbType.VarChar,1);
                    //paramCCVerDesc[28].Value = VisitProof;
                    //paramCCVerDesc[29] = new OleDbParameter("@RouteMap", OleDbType.VarChar,1);
                    //paramCCVerDesc[29].Value = RouteMap;
                    //paramCCVerDesc[30] = new OleDbParameter("@TPCDone", OleDbType.VarChar,1);
                    //paramCCVerDesc[30].Value = TPCDone;
                    paramCCVerDesc[29] = new OleDbParameter("@VisitProof", OleDbType.VarChar, 50);
                    paramCCVerDesc[29].Value = VisitProof;
                    paramCCVerDesc[30] = new OleDbParameter("@RouteMap", OleDbType.VarChar, 50);
                    paramCCVerDesc[30].Value = RouteMap;
                    paramCCVerDesc[31] = new OleDbParameter("@TPCDone", OleDbType.VarChar, 50);
                    paramCCVerDesc[31].Value = TPCDone;

                    paramCCVerDesc[32] = new OleDbParameter("@TPCDetail", OleDbType.VarChar, 255);
                    paramCCVerDesc[32].Value = TPCDetail;
                    paramCCVerDesc[33] = new OleDbParameter("@AnyInformation", OleDbType.VarChar, 100);
                    paramCCVerDesc[33].Value = AnyInformation;
                    paramCCVerDesc[34] = new OleDbParameter("@AddresConfirmation", OleDbType.VarChar, 20);
                    paramCCVerDesc[34].Value = AddressConfirmation;
                    paramCCVerDesc[35] = new OleDbParameter("@Contactability", OleDbType.VarChar, 20);
                    paramCCVerDesc[35].Value = Contactability;
                    //paramCCVerDesc[35] = new OleDbParameter("@ApplicationConfirm", OleDbType.VarChar,1);
                    paramCCVerDesc[36] = new OleDbParameter("@ApplicationConfirm", OleDbType.VarChar, 50);
                    paramCCVerDesc[36].Value = ApplicationConfirm;
                    paramCCVerDesc[37] = new OleDbParameter("@Profile", OleDbType.VarChar, 200);
                    paramCCVerDesc[37].Value = Profile;
                    paramCCVerDesc[38] = new OleDbParameter("@Reputation", OleDbType.VarChar, 50);
                    paramCCVerDesc[38].Value = Reputation;
                    paramCCVerDesc[39] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 20);
                    paramCCVerDesc[39].Value = PersonContacted;
                    paramCCVerDesc[40] = new OleDbParameter("@IssuingBank", OleDbType.VarChar, 20);
                    paramCCVerDesc[40].Value = IssuingBank;
                    paramCCVerDesc[41] = new OleDbParameter("@CooperativeCus", OleDbType.VarChar, 15);
                    paramCCVerDesc[41].Value = CooperativeCus;
                    paramCCVerDesc[42] = new OleDbParameter("@ConstructionOfResi", OleDbType.VarChar, 15);
                    paramCCVerDesc[42].Value = ConstructionOfResi;
                    paramCCVerDesc[43] = new OleDbParameter("@ExteriorComments", OleDbType.VarChar, 100);
                    paramCCVerDesc[43].Value = ExteriorComments;
                    //paramCCVerDesc[43] = new OleDbParameter("@IsApplicantStay", OleDbType.VarChar, 1);
                    paramCCVerDesc[44] = new OleDbParameter("@IsApplicantStay", OleDbType.VarChar, 50);
                    paramCCVerDesc[44].Value = IsApplicantStay;
                    paramCCVerDesc[45] = new OleDbParameter("@ApproxAgeOfApp", OleDbType.VarChar, 50);
                    paramCCVerDesc[45].Value = ApproxAgeOfApp;
                    paramCCVerDesc[46] = new OleDbParameter("@NoOfFamilyMem", OleDbType.VarChar, 10);
                    paramCCVerDesc[46].Value = NoOfFamilyMem;
                    //paramCCVerDesc[46] = new OleDbParameter("@NameplateSighted", OleDbType.VarChar,1);
                    paramCCVerDesc[47] = new OleDbParameter("@NameplateSighted", OleDbType.VarChar, 50);
                    paramCCVerDesc[47].Value = NameplateSighted;
                    paramCCVerDesc[48] = new OleDbParameter("@OwnerResiApp1", OleDbType.VarChar, 10);
                    paramCCVerDesc[48].Value = OwnerResiApp1;
                    paramCCVerDesc[49] = new OleDbParameter("@EmpStatus1", OleDbType.VarChar, 50);
                    paramCCVerDesc[49].Value = EmpStatus1;
                    paramCCVerDesc[50] = new OleDbParameter("@OwnerResiApp2", OleDbType.VarChar, 10);
                    paramCCVerDesc[50].Value = OwnerResiApp2;
                    paramCCVerDesc[51] = new OleDbParameter("@EmpStatus2", OleDbType.VarChar, 50);
                    paramCCVerDesc[51].Value = EmpStatus2;
                    paramCCVerDesc[52] = new OleDbParameter("@RentAmount", OleDbType.VarChar, 15);
                    paramCCVerDesc[52].Value = RentAmount;
                    paramCCVerDesc[53] = new OleDbParameter("@PriorityCustomer", OleDbType.VarChar, 10);
                    paramCCVerDesc[53].Value = PriorityCustomer;
                    paramCCVerDesc[54] = new OleDbParameter("@Segment", OleDbType.VarChar, 10);
                    paramCCVerDesc[54].Value = Segment;
                    paramCCVerDesc[55] = new OleDbParameter("@InfoRequired", OleDbType.VarChar, 10);
                    paramCCVerDesc[55].Value = InfoRequired;
                    paramCCVerDesc[56] = new OleDbParameter("@ChangeInAdd", OleDbType.VarChar, 50);
                    paramCCVerDesc[56].Value = ChangeInAdd;
                    paramCCVerDesc[57] = new OleDbParameter("@ReasonOfChange", OleDbType.VarChar, 30);
                    paramCCVerDesc[57].Value = ReasonOfChange;
                    paramCCVerDesc[58] = new OleDbParameter("@TrackNo", OleDbType.VarChar, 20);
                    paramCCVerDesc[58].Value = TrackNo;
                    paramCCVerDesc[59] = new OleDbParameter("@EntryPermit", OleDbType.VarChar, 10);
                    paramCCVerDesc[59].Value = EntryPermit;
                    paramCCVerDesc[60] = new OleDbParameter("@AddConfBy", OleDbType.VarChar, 20);
                    paramCCVerDesc[60].Value = AddConfBy;
                    paramCCVerDesc[61] = new OleDbParameter("@NoOfEarnFamMem", OleDbType.VarChar, 20);
                    paramCCVerDesc[61].Value = NoOfEarnFamMem;
                    paramCCVerDesc[62] = new OleDbParameter("@OfficePhone", OleDbType.VarChar, 20);
                    paramCCVerDesc[62].Value = OfficePhone;
                    paramCCVerDesc[63] = new OleDbParameter("@ApproxValIfOwn", OleDbType.VarChar, 15);
                    paramCCVerDesc[63].Value = ApproxValIfOwn;
                    paramCCVerDesc[64] = new OleDbParameter("@Branch", OleDbType.VarChar, 20);
                    paramCCVerDesc[64].Value = Branch;
                    paramCCVerDesc[65] = new OleDbParameter("@InfoRefused", OleDbType.VarChar, 20);
                    paramCCVerDesc[65].Value = InfoRefused;
                    paramCCVerDesc[66] = new OleDbParameter("@Occupation2", OleDbType.VarChar, 15);
                    paramCCVerDesc[66].Value = Occupation2;
                    paramCCVerDesc[67] = new OleDbParameter("@ReasonAddNotConfirm", OleDbType.VarChar, 30);
                    paramCCVerDesc[67].Value = ReasonAddNotConfirm;
                    paramCCVerDesc[68] = new OleDbParameter("@Locality", OleDbType.VarChar, 100);
                    paramCCVerDesc[68].Value = Locality;
                    paramCCVerDesc[69] = new OleDbParameter("@ResultOfCalling", OleDbType.VarChar, 20);
                    paramCCVerDesc[69].Value = ResultOfCalling;
                    paramCCVerDesc[70] = new OleDbParameter("@MismatchResiAdd", OleDbType.VarChar, 30);
                    paramCCVerDesc[70].Value = MismatchResiAdd;
                    //paramCCVerDesc[70] = new OleDbParameter("@IsAppKnown", OleDbType.VarChar,1);
                    paramCCVerDesc[71] = new OleDbParameter("@IsAppKnown", OleDbType.VarChar, 50);
                    paramCCVerDesc[71].Value = IsAppKnown;
                    paramCCVerDesc[72] = new OleDbParameter("@ToWhomAddBelong", OleDbType.VarChar, 15);
                    paramCCVerDesc[72].Value = ToWhomAddBelong;
                    paramCCVerDesc[73] = new OleDbParameter("@VerificationConductAt", OleDbType.VarChar, 15);
                    paramCCVerDesc[73].Value = VerificationConductAt;
                    paramCCVerDesc[74] = new OleDbParameter("@Accomodation", OleDbType.VarChar, 15);
                    paramCCVerDesc[74].Value = Accomodation;
                    paramCCVerDesc[75] = new OleDbParameter("@Interior", OleDbType.VarChar, 100);
                    paramCCVerDesc[75].Value = Interior;
                    paramCCVerDesc[76] = new OleDbParameter("@Exterior", OleDbType.VarChar, 15);
                    paramCCVerDesc[76].Value = Exterior;
                    paramCCVerDesc[77] = new OleDbParameter("@TPCBy", OleDbType.VarChar, 15);
                    paramCCVerDesc[77].Value = TPCBy;
                    paramCCVerDesc[78] = new OleDbParameter("@Observation", OleDbType.VarChar, 30);
                    paramCCVerDesc[78].Value = Observation;
                    paramCCVerDesc[79] = new OleDbParameter("@TPC2", OleDbType.VarChar, 30);
                    paramCCVerDesc[79].Value = TPC2;
                    paramCCVerDesc[80] = new OleDbParameter("@PersonMet2", OleDbType.VarChar, 30);
                    paramCCVerDesc[80].Value = PersonMet2;
                    paramCCVerDesc[81] = new OleDbParameter("@Add2", OleDbType.VarChar, 30);
                    paramCCVerDesc[81].Value = Add2;
                    paramCCVerDesc[82] = new OleDbParameter("@AppAge2", OleDbType.VarChar, 30);
                    paramCCVerDesc[82].Value = AppAge2;
                    paramCCVerDesc[83] = new OleDbParameter("@NoOfResiAtHome2", OleDbType.VarChar, 30);
                    paramCCVerDesc[83].Value = NoOfResiAtHome2;
                    paramCCVerDesc[84] = new OleDbParameter("@YrsLiveAtAdd2", OleDbType.VarChar, 30);
                    paramCCVerDesc[84].Value = YrsLiveAtAdd2;
                    paramCCVerDesc[85] = new OleDbParameter("@SpouseSalary", OleDbType.VarChar, 30);
                    paramCCVerDesc[85].Value = SpouseSalary;
                    paramCCVerDesc[86] = new OleDbParameter("@ResiStatus2", OleDbType.VarChar, 50);
                    paramCCVerDesc[86].Value = ResiStatus2;
                    paramCCVerDesc[87] = new OleDbParameter("@Working", OleDbType.VarChar, 10);
                    paramCCVerDesc[87].Value = Working;
                    paramCCVerDesc[88] = new OleDbParameter("@Children", OleDbType.VarChar, 10);
                    paramCCVerDesc[88].Value = Children;

                    ///////////////////////modified by Santosh Shelar 17th May 2008//////////////////////// 
                    paramCCVerDesc[89] = new OleDbParameter("@Ass_Vis_Tv", OleDbType.VarChar, 50);
                    paramCCVerDesc[89].Value = Ass_Vis_Tv;
                    paramCCVerDesc[90] = new OleDbParameter("@Ass_Vis_AC", OleDbType.VarChar, 50);
                    paramCCVerDesc[90].Value = Ass_Vis_AC;
                    paramCCVerDesc[91] = new OleDbParameter("@Ass_Vis_Refri", OleDbType.VarChar, 50);
                    paramCCVerDesc[91].Value = Ass_Vis_Refri;
                    paramCCVerDesc[92] = new OleDbParameter("@Ass_Vis_MusSys", OleDbType.VarChar, 50);
                    paramCCVerDesc[92].Value = Ass_Vis_MusSys;
                    paramCCVerDesc[93] = new OleDbParameter("@Ass_Vis_Comp", OleDbType.VarChar, 50);
                    paramCCVerDesc[93].Value = Ass_Vis_Comp;
                    paramCCVerDesc[94] = new OleDbParameter("@Ass_Vis_Cool", OleDbType.VarChar, 50);
                    paramCCVerDesc[94].Value = Ass_Vis_Cool;
                    paramCCVerDesc[95] = new OleDbParameter("@Ass_Vis_PH", OleDbType.VarChar, 50);
                    paramCCVerDesc[95].Value = Ass_Vis_PH;
                    paramCCVerDesc[96] = new OleDbParameter("@Ass_Vis_PhotCop", OleDbType.VarChar, 50);
                    paramCCVerDesc[96].Value = Ass_Vis_PhotCop;
                    paramCCVerDesc[97] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                    paramCCVerDesc[97].Value = DateOfBirth;
                    paramCCVerDesc[98] = new OleDbParameter("@Additional_Remark", OleDbType.VarChar, 300);
                    paramCCVerDesc[98].Value = Additional_Remark; 
                    paramCCVerDesc[99] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCCVerDesc[99].Direction = ParameterDirection.Output;
                    ///////////////////////modified by Santosh Shelar 17th May 2008 END (RV)////////////////////////
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddEditCCDescriptionRVdcr", paramCCVerDesc);
                if (Convert.ToInt32(paramCCVerDesc[99].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(paramCCVerDesc[99].Value) == 2)
                {
                    sRetVal = "Record updated successfully.";
                }
                else
                {
                    sRetVal = "There is some error in Data entry .";

                }
                oledbTrans.Commit();
                oledbConn.Close();
            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                oledbConn.Close();
                strError = ex.Message;
            }
            //////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_DESCRIPTION1-------------------

            OleDbConnection oledbConn1 = new OleDbConnection(objCon.ConnectionString);
            oledbConn1.Open();
            OleDbTransaction oledbTrans1 = oledbConn1.BeginTransaction();

            sSql = "";
            try
            {
                OleDbParameter[] paramCCVerDesc1 = new OleDbParameter[29];
                paramCCVerDesc1[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[1].Equals("1")))
                {
                    paramCCVerDesc1[0].Value = "ADD";
                }
                else
                {
                    paramCCVerDesc1[0].Value = "EDIT";
 
                }
                    paramCCVerDesc1[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCCVerDesc1[1].Value = CaseId;
                    paramCCVerDesc1[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCCVerDesc1[2].Value = VerificationType;
                    paramCCVerDesc1[3] = new OleDbParameter("@IncomeDocs", OleDbType.VarChar, 20);
                    paramCCVerDesc1[3].Value = IncomeDocs;
                    paramCCVerDesc1[4] = new OleDbParameter("@FERemark", OleDbType.VarChar, 255);
                    paramCCVerDesc1[4].Value = FERemark;
                    paramCCVerDesc1[5] = new OleDbParameter("@CoAppName", OleDbType.VarChar, 20);
                    paramCCVerDesc1[5].Value = CoAppName;
                    paramCCVerDesc1[6] = new OleDbParameter("@PriorityCustomer", OleDbType.VarChar, 10);
                    paramCCVerDesc1[6].Value = PriorityCustomer;
                    paramCCVerDesc1[7] = new OleDbParameter("@InfoRequired", OleDbType.VarChar, 50);
                    paramCCVerDesc1[7].Value = InfoRequired;
                    paramCCVerDesc1[8] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 10);
                    paramCCVerDesc1[8].Value = RelationWithApplicant;
                    paramCCVerDesc1[9] = new OleDbParameter("@UntraceableReason", OleDbType.VarChar, 20);
                    paramCCVerDesc1[9].Value = UntraceableReason;
                    paramCCVerDesc1[10] = new OleDbParameter("@VerificationConductAt", OleDbType.VarChar, 15);
                    paramCCVerDesc1[10].Value = VerificationConductAt;
                    paramCCVerDesc1[11] = new OleDbParameter("@LandmarkObserved", OleDbType.VarChar, 25);
                    paramCCVerDesc1[11].Value = LandmarkObserved;
                    paramCCVerDesc1[12] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                    paramCCVerDesc1[12].Value = PermanentAddress;
                    paramCCVerDesc1[13] = new OleDbParameter("@CompanyName", OleDbType.VarChar, 100);
                    paramCCVerDesc1[13].Value = CompanyName;
                    paramCCVerDesc1[14] = new OleDbParameter("@OfficeExtn", OleDbType.VarChar, 5);
                    paramCCVerDesc1[14].Value = OfficeExtn;
                    paramCCVerDesc1[15] = new OleDbParameter("@DesgnAtOffice", OleDbType.VarChar, 100);
                    paramCCVerDesc1[15].Value = DesgnAtOffice;
                    paramCCVerDesc1[16] = new OleDbParameter("@APPLICANT_IS_AVAILABLE_AT", OleDbType.VarChar, 20);
                    paramCCVerDesc1[16].Value = AppAvailableAtHome;
                    paramCCVerDesc1[17] = new OleDbParameter("@ResiIsStatus", OleDbType.VarChar, 50);
                    paramCCVerDesc1[17].Value = ResiIsStatus;
                    paramCCVerDesc1[18] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 50);
                    paramCCVerDesc1[18].Value = OfficeAddress;
                    paramCCVerDesc1[19] = new OleDbParameter("@Stay", OleDbType.VarChar, 50);
                    paramCCVerDesc1[19].Value = Stay;
                    paramCCVerDesc1[20] = new OleDbParameter("@Neighbour2Name", OleDbType.VarChar, 50);
                    paramCCVerDesc1[20].Value = Neighbour2Name;
                    paramCCVerDesc1[21] = new OleDbParameter("@NeighbourReferance", OleDbType.VarChar, 50);
                    paramCCVerDesc1[21].Value = NeighbourReferance;
                    paramCCVerDesc1[22] = new OleDbParameter("@PinCode", OleDbType.VarChar, 15);
                    paramCCVerDesc1[22].Value = PinCode;
                    /////field size incresed from 20 to 21 by Sunny Chauhan////////////////////
                    paramCCVerDesc1[23] = new OleDbParameter("@ResidenceIs", OleDbType.VarChar, 21);
                    paramCCVerDesc1[23].Value = ResidenceIs;
                    paramCCVerDesc1[24] = new OleDbParameter("@NEIGHBOUR_ADD_2", OleDbType.VarChar, 500);
                    paramCCVerDesc1[24].Value = Neighbour2Add;
                    paramCCVerDesc1[25] = new OleDbParameter("@MAILING_ADDRESS", OleDbType.VarChar, 500);
                    paramCCVerDesc1[25].Value = ResidenceIs;
                    paramCCVerDesc1[26] = new OleDbParameter("@AVG_MONTH_TURNOVER", OleDbType.VarChar, 500);
                    paramCCVerDesc1[26].Value = AvgMonthlyTurnover;
                    paramCCVerDesc1[27] = new OleDbParameter("@BUSINESS_STOCK_SEEN", OleDbType.VarChar, 500);
                    paramCCVerDesc1[27].Value = BusinessStockSeen; 
                    paramCCVerDesc1[28] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCCVerDesc1[28].Direction = ParameterDirection.Output;
                    ///// procedure modified by Sunny Chauhan////////////////////
                    OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.StoredProcedure, "spAddEditCCDescription1RV_DCR", paramCCVerDesc1);

                    if (Convert.ToInt32(paramCCVerDesc1[28].Value) == 1)
                    {
                        sRetVal = "Record added successfully.";

                    }
                    else if (Convert.ToInt32(paramCCVerDesc1[28].Value) == 2)
                    {
                        sRetVal = "Record updated successfully.";
                    }
                    else
                    {
                        sRetVal = "There is some error in Data entry .";

                    }
               
                oledbTrans1.Commit();
                oledbConn1.Close();
            }
            catch (Exception ex)
            {
                oledbTrans1.Rollback();
                oledbConn1.Close();
                strError = ex.Message;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_OTHER_DETAILS-------------------

            OleDbConnection oledbConn2 = new OleDbConnection(objCon.ConnectionString);
            oledbConn2.Open();
            OleDbTransaction oledbTrans2 = oledbConn2.BeginTransaction();
            try
            {
                sSql = "";
                OleDbParameter[] paramCreditCardOtherDtl = new OleDbParameter[24];
                paramCreditCardOtherDtl[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[2].Equals("1")))
                {
                    paramCreditCardOtherDtl[0].Value = "ADD";

                }
                else
                {
                    paramCreditCardOtherDtl[0].Value = "EDIT";
 
                }
                    paramCreditCardOtherDtl[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[1].Value = CaseId;
                    paramCreditCardOtherDtl[2] = new OleDbParameter("@VerificationType", OleDbType.VarChar, 15);
                    paramCreditCardOtherDtl[2].Value = VerificationType;
                    paramCreditCardOtherDtl[3] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[3].Value = RelationWithApplicant;
                    paramCreditCardOtherDtl[4] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                    paramCreditCardOtherDtl[4].Value = PersonContacted;
                    
                    paramCreditCardOtherDtl[5] = new OleDbParameter("@IsApplicantStay", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[5].Value = IsApplicantStay;
                    paramCreditCardOtherDtl[6] = new OleDbParameter("@NegativeArea", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[6].Value = NegativeArea;
                    paramCreditCardOtherDtl[7] = new OleDbParameter("@OCL", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[7].Value = OCL; 
                    paramCreditCardOtherDtl[8] = new OleDbParameter("@Locality", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[8].Value = Locality;
                    paramCreditCardOtherDtl[9] = new OleDbParameter("@ResidenceType", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[9].Value = ResidenceType;
                    //paramCreditCardOtherDtl[9] = new OleDbParameter("@NameplateSighted", OleDbType.VarChar,1);
                    paramCreditCardOtherDtl[10] = new OleDbParameter("@NameplateSighted", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[10].Value = NameplateSighted;
                    paramCreditCardOtherDtl[11] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[11].Value = AgencyCode;
                    paramCreditCardOtherDtl[12] = new OleDbParameter("@Address_Apporch", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[12].Value = AddresssOnApplication;
                    paramCreditCardOtherDtl[13] = new OleDbParameter("@Applicant_lives_with", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[13].Value = ApplicantName;
                    paramCreditCardOtherDtl[14] = new OleDbParameter("@Additional_Comments", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[14].Value = AdditionalComments;
                    paramCreditCardOtherDtl[15] = new OleDbParameter("@Residence_Address_updatedbyFE", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[15].Value = ResiAddress;
                    paramCreditCardOtherDtl[16] = new OleDbParameter("@Address_of_Company", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[16].Value = AddresssOnApplication;
                    paramCreditCardOtherDtl[17] = new OleDbParameter("@Relationship_With_Bank", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[17].Value = RelationWithApplicant;
                    paramCreditCardOtherDtl[18] = new OleDbParameter("@Roof_Type", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[18].Value = ApplicantName;
                    paramCreditCardOtherDtl[19] = new OleDbParameter("@Number_of_Rooms", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[19].Value = No_Of_Flats;
                    paramCreditCardOtherDtl[20] = new OleDbParameter("@Family_Seen", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[20].Value = ApplicantReportToName;
                    paramCreditCardOtherDtl[21] = new OleDbParameter("@OFF_NAME_ON_BOARD", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[21].Value = OffNameOnBoard;
                    paramCreditCardOtherDtl[22] = new OleDbParameter("@NAME_PLATE", OleDbType.VarChar, 50);
                    paramCreditCardOtherDtl[22].Value = Nameplate; 
                    paramCreditCardOtherDtl[23] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCreditCardOtherDtl[23].Direction = ParameterDirection.Output;


                    OleDbHelper.ExecuteNonQuery(oledbTrans2, CommandType.StoredProcedure, "spAddEditCCVeriOtherDetailsRV_DCR", paramCreditCardOtherDtl);

                    if (Convert.ToInt32(paramCreditCardOtherDtl[23].Value) == 1)
                    {
                        sRetVal = "Record added successfully.";

                    }
                    else if (Convert.ToInt32(paramCreditCardOtherDtl[23].Value) == 2)
                    {
                        sRetVal = "Record updated successfully.";
                    }
                    else
                    {
                        sRetVal = "There is some error in Data entry .";

                    }
              
                oledbTrans2.Commit();
                oledbConn2.Close();
            }
            catch (Exception ex)
            {
                oledbTrans2.Rollback();
                oledbConn2.Close();
                strError = ex.Message;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            /////--------CPV_CC_VERI_DETAILS-------------------
            OleDbConnection oledbConn3 = new OleDbConnection(objCon.ConnectionString);
            oledbConn3.Open();
            OleDbTransaction oledbTrans3 = oledbConn3.BeginTransaction();
            try
            {
                sSql = "";
                OleDbParameter[] paramCreditCardVerDtl = new OleDbParameter[28];
                paramCreditCardVerDtl[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                if (!(strTableToEditArray[3].Equals("1")))
                {
                    paramCreditCardVerDtl[0].Value = "ADD";

                }
                else
                {
                    paramCreditCardVerDtl[0].Value = "EDIT";
                }
                    paramCreditCardVerDtl[1] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[1].Value = CaseId;
                    paramCreditCardVerDtl[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[2].Value = VerificationType;
                    paramCreditCardVerDtl[3] = new OleDbParameter("@DECLINED_REASON", OleDbType.VarChar, 255);
                    paramCreditCardVerDtl[3].Value = DeclineReason;
                    paramCreditCardVerDtl[4] = new OleDbParameter("@DEFAULTED_WITH", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[4].Value = BankNameCC;
                    paramCreditCardVerDtl[5] = new OleDbParameter("@DEFAULTED_PRODUCT", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[5].Value = ProductName;
                    paramCreditCardVerDtl[6] = new OleDbParameter("@DEFAULT_AMOUNT", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[6].Value = AmountDefult;
                    paramCreditCardVerDtl[7] = new OleDbParameter("@RATING", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[7].Value = CPVScore;
                    paramCreditCardVerDtl[8] = new OleDbParameter("@SUPERVISOR_ID", OleDbType.VarChar, 50);
                    paramCreditCardVerDtl[8].Value = SupervisorId;
                    paramCreditCardVerDtl[9] = new OleDbParameter("@SupervisorRemark", OleDbType.VarChar, 255);
                    paramCreditCardVerDtl[9].Value = SupervisorRemark;
                    paramCreditCardVerDtl[10] = new OleDbParameter("@DECLINED_CODE", OleDbType.VarChar, 10);
                    paramCreditCardVerDtl[10].Value = DeclineCode;
                    paramCreditCardVerDtl[11] = new OleDbParameter("@OVERALL_ASSESMENT", OleDbType.VarChar, 100);
                    paramCreditCardVerDtl[11].Value = OverallAssessment;
                    paramCreditCardVerDtl[12] = new OleDbParameter("@OVERALL_ASSESMENT_REASON", OleDbType.VarChar, 255);
                    paramCreditCardVerDtl[12].Value = AssesstReason;
                    paramCreditCardVerDtl[13] = new OleDbParameter("@CASE_STATUS_IDd", OleDbType.VarChar, 10);
                    paramCreditCardVerDtl[13].Value = CaseStatusId;
                    paramCreditCardVerDtl[14] = new OleDbParameter("@ADD_BY", OleDbType.VarChar, 15);
                    paramCreditCardVerDtl[14].Value = AddedBy;
                    paramCreditCardVerDtl[15] = new OleDbParameter("@ADD_DATE", OleDbType.DBTimeStamp);
                    paramCreditCardVerDtl[15].Value = AddedOn;
                    paramCreditCardVerDtl[16] = new OleDbParameter("@Reason", OleDbType.VarChar,100);
                    paramCreditCardVerDtl[16].Value = ReasonOfChange;
                    paramCreditCardVerDtl[17] = new OleDbParameter("@Flooring", OleDbType.VarChar, 100);
                    paramCreditCardVerDtl[17].Value = ChequeNo; 
                    paramCreditCardVerDtl[18] = new OleDbParameter("@Roofing", OleDbType.VarChar, 100);
                    paramCreditCardVerDtl[18].Value = RECEIPTNO;
                    paramCreditCardVerDtl[19] = new OleDbParameter("@Despatch_Date", OleDbType.VarChar, 100);
                    paramCreditCardVerDtl[19].Value = DispDate;
                    paramCreditCardVerDtl[20] = new OleDbParameter("@SpouseOccu", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[20].Value = AcknNo;
                    paramCreditCardVerDtl[21] = new OleDbParameter("@SpouseName", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[21].Value = Praposal;
                    paramCreditCardVerDtl[22] = new OleDbParameter("@CarPark", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[22].Value = RsendDate;
                    paramCreditCardVerDtl[23] = new OleDbParameter("@StanLiving", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[23].Value = RrecDate;
                    paramCreditCardVerDtl[24] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[24].Value = OclVisit;
                    paramCreditCardVerDtl[25] = new OleDbParameter("@Actual_Number", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[25].Value = ChequeDate;
                    paramCreditCardVerDtl[26] = new OleDbParameter("@ResidenceInternal", OleDbType.VarChar, 500);
                    paramCreditCardVerDtl[26].Value = DepoDate;   
                    paramCreditCardVerDtl[27] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramCreditCardVerDtl[27].Direction = ParameterDirection.Output;


                    OleDbHelper.ExecuteNonQuery(oledbTrans3, CommandType.StoredProcedure, "spAddEditCCVeriDetailsRVDcr", paramCreditCardVerDtl);

                if (Convert.ToInt32(paramCreditCardVerDtl[27].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(paramCreditCardVerDtl[27].Value) == 2)
                {
                    sRetVal = "Record updated successfully.";
                }
                else
                {
                    sRetVal = "There is some error in Data entry .";

                }
                oledbTrans3.Commit();
                oledbConn3.Close();
            }
            catch (Exception ex)
            {
                oledbTrans3.Rollback();
                oledbConn3.Close();
                strError = ex.Message;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            ///--------CPV_CC_CASE_DETAILS-------------------
            //UPDATE CPV_CC_CASE_DETAILS- For DCR-----------------------------

            OleDbConnection oledbConn4 = new OleDbConnection(objCon.ConnectionString);
            oledbConn4.Open();
            OleDbTransaction oledbTrans4 = oledbConn4.BeginTransaction();

            try
            {

                OleDbParameter[] paramCreditCardCaseDtl = new OleDbParameter[17];

                paramCreditCardCaseDtl[0] = new OleDbParameter("@PickUpStatus1", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[0].Value = PickUpStatus1;
                paramCreditCardCaseDtl[1] = new OleDbParameter("@Date1", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[1].Value = Date1;
                paramCreditCardCaseDtl[2] = new OleDbParameter("@PickUpStatus2", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[2].Value = PickUpStatus2;
                paramCreditCardCaseDtl[3] = new OleDbParameter("@Date2", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[3].Value = Date2;
                paramCreditCardCaseDtl[4] = new OleDbParameter("@PickUpStatus3", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[4].Value = PickUpStatus3;
                paramCreditCardCaseDtl[5] = new OleDbParameter("@Date3", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[5].Value = Date3;
                paramCreditCardCaseDtl[6] = new OleDbParameter("@PickUpStatusFinal", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[6].Value = PickUpStatusFinal;
                paramCreditCardCaseDtl[7] = new OleDbParameter("@PickedupDate", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[7].Value = PickedupDate;
                paramCreditCardCaseDtl[8] = new OleDbParameter("@PickUpFeedback", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[8].Value = PickUpFeedback;
                paramCreditCardCaseDtl[9] = new OleDbParameter("@ReturnDate", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[9].Value = ReturnDate;
                paramCreditCardCaseDtl[10] = new OleDbParameter("@DespatchDate", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[10].Value = DespatchDate;
                paramCreditCardCaseDtl[11] = new OleDbParameter("@FEName", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[11].Value = FEName1;
                paramCreditCardCaseDtl[12] = new OleDbParameter("@FECODE", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[12].Value = FECODE;
                paramCreditCardCaseDtl[13] = new OleDbParameter("@FEMobile", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[13].Value = FEMobile;
                paramCreditCardCaseDtl[14] = new OleDbParameter("@TMEName", OleDbType.VarChar, 50);
                paramCreditCardCaseDtl[14].Value = TMEName; 
                paramCreditCardCaseDtl[15] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                paramCreditCardCaseDtl[15].Value = CaseId;
                paramCreditCardCaseDtl[16] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramCreditCardCaseDtl[16].Direction = ParameterDirection.Output;


                //OleDbHelper.ExecuteNonQuery(oledbTrans4, CommandType.StoredProcedure, "spEditCCCaseDetailsBVRV", paramCreditCardCaseDtl);

                //oledbTrans4.Commit();
                oledbConn4.Close();
            }
            catch (Exception ex)
            {
                oledbTrans4.Rollback();
                oledbConn4.Close();
                strError = "1";
            }

            /////////////end of DCR/////////////

            OleDbConnection oledbConn5 = new OleDbConnection(objCon.ConnectionString);
            oledbConn5.Open();
            OleDbTransaction oledbTrans5 = oledbConn5.BeginTransaction();
            try
            {

                OleDbParameter[] paramDeleteAttempt = new OleDbParameter[7];

                paramDeleteAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                paramDeleteAttempt[0].Value = "DELETE";
                paramDeleteAttempt[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[1].Value = CaseId;
                paramDeleteAttempt[2] = new OleDbParameter("@Verifier_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[2].Value = VerifierID;
                paramDeleteAttempt[3] = new OleDbParameter("@Attempt_Date_Time", OleDbType.DBTimeStamp, 8);
                paramDeleteAttempt[3].Value = AttemptDateTime;
                paramDeleteAttempt[4] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                paramDeleteAttempt[4].Value = AttemptRemark;
                paramDeleteAttempt[5] = new OleDbParameter("@Verfication_Type_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[5].Value = VerficationTypeID;
                paramDeleteAttempt[6] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramDeleteAttempt[6].Direction = ParameterDirection.Output;

                OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddDeleteCCAttemptDcr", paramDeleteAttempt);

                if (arrAttempt.Count > 0)
                {
                    foreach (ArrayList item in arrAttempt)
                    {
                        AttemptDateTime = item[0].ToString();
                        AttemptRemark = item[1].ToString();


                        OleDbParameter[] paramAttempt = new OleDbParameter[7];
                        paramAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                        paramAttempt[0].Value = "ADD";
                        paramAttempt[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                        paramAttempt[1].Value = CaseId;
                        paramAttempt[2] = new OleDbParameter("@Verifier_ID", OleDbType.VarChar, 15);
                        paramAttempt[2].Value = VerifierID;
                        paramAttempt[3] = new OleDbParameter("@Attempt_Date_Time", OleDbType.DBTimeStamp, 8);
                        paramAttempt[3].Value = AttemptDateTime;
                        paramAttempt[4] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                        paramAttempt[4].Value = AttemptRemark;
                        paramAttempt[5] = new OleDbParameter("@Verfication_Type_ID", OleDbType.VarChar, 15);
                        paramAttempt[5].Value = VerficationTypeID;
                        paramAttempt[6] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                        paramAttempt[6].Direction = ParameterDirection.Output;

                        OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddDeleteCCAttemptDcr", paramAttempt);

                    }
                }

                oledbTrans5.Commit();
                oledbConn5.Close();
            }
            catch (Exception ex)
            {
                oledbTrans5.Rollback();
                oledbConn5.Close();
                strError = ex.Message;
            }
            OleDbConnection oledbConn6 = new OleDbConnection(objCon.ConnectionString);
            oledbConn6.Open();
            OleDbTransaction oledbTrans6 = oledbConn6.BeginTransaction();
            try
            {

                sSql = "";


                OleDbParameter[] paramTransLog = new OleDbParameter[9];
                paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramTransLog[0].Value = CaseId;
                paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
                paramTransLog[1].Value = VerficationTypeID;
                paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
                paramTransLog[2].Value = UserId;
                paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
                paramTransLog[3].Value = TransStart;
                paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
                paramTransLog[4].Value = TransEnd;
                paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
                paramTransLog[5].Value = CentreId;
                paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
                paramTransLog[6].Value = ProductId;
                paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
                paramTransLog[7].Value = ClientId;
                paramTransLog[8] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramTransLog[8].Direction = ParameterDirection.Output;
                OleDbHelper.ExecuteNonQuery(oledbTrans6, CommandType.StoredProcedure, "spAddCaseTranscation", paramTransLog);
                oledbTrans6.Commit();
                oledbConn6.Close();
            }
            catch (Exception ex)
            {
                oledbTrans6.Rollback();
                oledbConn6.Close();
                strError = ex.Message;
            }

                //End  Insert into CASE_TRANSACTION_LOG --------------------
               
                //Modified By		   :   sandeep khare
                // Modified date       : 22 dec 2007
                // Remark              : this transaction ,we use for the case is complete or not ,we have used stored procedure
                OleDbConnection oledbConn7 = new OleDbConnection(objCon.ConnectionString);
                oledbConn7.Open();
                OleDbTransaction oledbTrans7 = oledbConn7.BeginTransaction();

                try
                {

                    OleDbParameter[] paramIsCaseComplete = new OleDbParameter[2];
                    paramIsCaseComplete[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramIsCaseComplete[0].Value = CaseId;
                    paramIsCaseComplete[1] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramIsCaseComplete[1].Direction = ParameterDirection.Output;
                    OleDbHelper.ExecuteNonQuery(oledbTrans7, CommandType.StoredProcedure, "spIsCCVerificationComplete_DCR", paramIsCaseComplete);
                    if (Convert.ToInt32(paramIsCaseComplete[1].Value) == 1)
                    {
                        sRetVal += "Case verification data entry completed.";
                    }
                    oledbTrans7.Commit();
                    oledbConn7.Close();
                }
                catch (Exception ex)
                {
                    oledbTrans7.Rollback();
                    oledbConn7.Close();
                }

            /////////Added By Naresh Sabbani/////////////////////////////////////////////////////////

                OleDbConnection oledbConn8 = new OleDbConnection(objCon.ConnectionString);
                oledbConn8.Open();
                //OperationType
                OleDbTransaction oledbTrans8 = oledbConn8.BeginTransaction();
                try
                {
                    OleDbParameter[] paramSociety = new OleDbParameter[16];
                    paramSociety[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                    if (!(strTableToEditArray[3].Equals("1")))
                    {
                        paramSociety[0].Value = "ADD";
                    }
                    else
                    {
                        paramSociety[0].Value = "EDIT";
                    }
                    paramSociety[1] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                    paramSociety[1].Value = CaseId;

                    paramSociety[2] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
                    paramSociety[2].Value = VerficationTypeID;

                    paramSociety[3] = new OleDbParameter("@Type_Of_Society", OleDbType.VarChar, 100);
                    paramSociety[3].Value = Type_Of_Society;

                    paramSociety[4] = new OleDbParameter("@Other_Facilities", OleDbType.VarChar, 100);
                    paramSociety[4].Value = Other_Facilities;

                    paramSociety[5] = new OleDbParameter("@Market_Value", OleDbType.VarChar, 100);
                    paramSociety[5].Value = Market_Value;

                    paramSociety[6] = new OleDbParameter("@Builtup_Area", OleDbType.VarChar, 100);
                    paramSociety[6].Value = Builtup_Area;

                    paramSociety[7] = new OleDbParameter("@No_Of_Flats", OleDbType.VarChar, 100);
                    paramSociety[7].Value = No_Of_Flats;

                    paramSociety[8] = new OleDbParameter("@Bedroom", OleDbType.VarChar, 10);
                    paramSociety[8].Value = Bedroom;

                    paramSociety[9] = new OleDbParameter("@Negative_Area", OleDbType.VarChar, 10);
                    paramSociety[9].Value = Negative_Area;

                    paramSociety[10] = new OleDbParameter("@Tpc_Name", OleDbType.VarChar, 100);
                    paramSociety[10].Value = Tpc_Name;

                    paramSociety[11] = new OleDbParameter("@Tpc_Phone", OleDbType.VarChar, 100);
                    paramSociety[11].Value = Tpc_Phone;

                    paramSociety[12] = new OleDbParameter("@History", OleDbType.VarChar, 100);
                    paramSociety[12].Value = History;

                    paramSociety[13] = new OleDbParameter("@No_Of_Employee", OleDbType.VarChar, 25);
                    paramSociety[13].Value = No_Of_Employee;

                    paramSociety[14] = new OleDbParameter("@Remark", OleDbType.VarChar, 250);
                    paramSociety[14].Value = Remark;

                    paramSociety[15] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    paramSociety[15].Direction = ParameterDirection.Output;

                    OleDbHelper.ExecuteNonQuery(oledbTrans8, CommandType.StoredProcedure, "spAddEditSocietyTranscation_DCR", paramSociety);
                    oledbTrans8.Commit();
                    oledbConn8.Close();
                }
                catch (Exception ex)
                {
                    oledbTrans8.Rollback();
                    oledbConn8.Close();
                }
                //Sabbani Naresh End   08/07/2008
                /////////////////////////////////////////////////////////////////////////////////////////////


            /////////Addition Ended Naresh Sabbani///////////////////////////////////////////////////
                
        }
        catch
        {

        }
        Error = strError;
        return sRetVal;
    }
    #endregion InsertUpdateCCResiVerificationEntry() Residence verification(RV)

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   03 Aug 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete="";
        sSql= " Select case (select count(*) from CPV_CC_CASE_VERIFICATIONTYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from CPV_CC_CASE_OUTPUT_VW where case_id='" + sCaseId + "' and CASE_STATUS_ID<>'') " +
              " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if(oledbRead.Read()==true)
            bComplete=oledbRead["IsComplete"].ToString();
        
        return bComplete;
    }

    #endregion IsVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_DCR_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete

   

}
