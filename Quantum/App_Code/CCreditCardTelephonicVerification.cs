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

/// <summary>
/// Summary description for CCreditCardTelephonicVerification
/// </summary>
public class CCreditCardTelephonicVerification
{
    private CCommon objCon;
    

    public CCreditCardTelephonicVerification()
    {
        objCon = new CCommon();
        //
        // TODO: Add constructor logic here
        //
    }
    #region Properties Declaration
    //Start of Properties for table CPV_CC_VERI_ATTEMPTS and in form for TELECALL LOG
    private string strCaseID;
    private string strVerificationType;
    private string strVerificationTypeID;
    private string strVerifierID;
    private string attemptDateTime;
    private string strRemark;
    private string strTelephoneNo;
    private string strEmpCode;
    //added by hemangi kambli on 01/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;

    private string sError;
    public string Error
    {
        get { return sError; }
        set { sError = value; }
    }
    //private string sNegativeCode;
    //public string NegativeCode
    //{
    //    get { return sNegativeCode; }
    //    set { sNegativeCode = value; }
    //}
    private string sBankName;
    public string BankName
    {
        get { return sBankName; }
        set { sBankName = value; }
    }
    private string dtIsCaseComp;

    public string IsCaseComp
    {
        get { return dtIsCaseComp; }
        set { dtIsCaseComp = value; }
    }
    private string sOffTel;
    public string OffTel
    {
        get { return sOffTel; }
        set { sOffTel = value; }
    }
    private string sNoOfCurrAdd;
    public string NoOfCurrAdd
    {
        get { return sNoOfCurrAdd;}
        set { sNoOfCurrAdd = value; }
    }
    private string sDirCheck;
    public string DirCheck
    {
        get { return sDirCheck;}
        set { sDirCheck = value; }
    }
    private string sAuthoSign;
    public string AuthoSign
    {
        get { return sAuthoSign; }
        set { sAuthoSign = value; }
    }

    //private string sInputterName;
    //public string InputterName
    //{
    //    get { return sInputterName; }
    //    set { sInputterName = value; }
    //}

    private string sDateofVerification;
    public string DateofVerification
    {
        get { return sDateofVerification; }
        set { sDateofVerification = value; }
    }

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
    public string CaseID
    {
        get
        {
            return strCaseID;
        }
        set
        {
            strCaseID = value;
        }
    }
    public string VerificationType
    {
        get
        {
            return strVerificationType;
        }
        set
        {
            strVerificationType = value;
        }
    }
    public string VerificationTypeID
    {
        get
        {
            return strVerificationTypeID;
        }
        set
        {
            strVerificationTypeID = value;
        }
    }
    public string VerifierID
    {
        get
        {
            return strVerifierID;
        }
        set
        {
            strVerifierID = value;
        }
    }

    public string AttemptDateTime
    {
        get
        {
            return attemptDateTime;
        }
        set
        {
            attemptDateTime = value;
        }
    }
    public string Remark
    {
        get
        {
            return strRemark;
        }
        set
        {
            strRemark = value;
        }
    }
    public string TelePhoneNo
    {
        get
        {
            return strTelephoneNo;
        }
        set
        {
            strTelephoneNo = value;
        }
    }
    //End of Properties for table CPV_CC_VERI_ATTEMPTS and in form for TELECALL LOG

    //Start of Properties for table CPV_CC_CASE_DETAILS and in form for RESIDENCE VERIFICATION REPORT 


    private string strApplicantName;
    private string strCMDReferanceNo;
    private string dateOfInitiation;
    private string strAgencyCode;
    private string strOfficePhone;

    public string OfficePhone
    {
        get
        {
            return strOfficePhone;
        }
        set
        {
            strOfficePhone = value;
        }
    }
    public string ApplicantName
    {
        get
        {
            return strApplicantName;
        }
        set
        {
            strApplicantName = value;
        }
    }
    public string CMDReferanceNo
    {
        get
        {
            return strCMDReferanceNo;
        }
        set
        {
            strCMDReferanceNo = value;
        }
    }
    public string DateOfInitiation
    {
        get
        {
            return dateOfInitiation;
        }
        set
        {
            dateOfInitiation = value;
        }
    }
    public string AgencyCode
    {
        get
        {
            return strAgencyCode;
        }
        set
        {
            strAgencyCode = value;
        }
    }

    //End of Properties for table CPV_CC_CASE_DETAILS and in form for RESIDENCE VERIFICATION REPORT 

    //Start Of Properties for table CPV_CC_CASE_DETAILS(ADDRESS DETAIL and OFFICE)
   
    private string strPersonContacted;
    private string strContectedNo;
    private string strPPNo;
    private string strDetails;
    private string strResiAddress;
    private string strPincode;
    private string strLandmarkOberservered;
    private string strPermanentAddress;
    private string strPPLocationAddress;
    private string strOfficeAddress;
    private string strExtnNo;
    private string strResiPhone;

    

    public string ResiPhone
    {
        get
        {
            return strResiPhone;
        }
        set
        {
            strResiPhone = value;
        }
    }
    public string PersonContacted
    {
        get
        {
            return strPersonContacted;
        }
        set
        {
            strPersonContacted = value;
        }
    }
    public string ContectedNo
    {
        get
        {
            return strContectedNo;
        }
        set
        {
            strContectedNo = value;
        }
    }
    public string PPNo
    {
        get
        {
            return strPPNo;
        }
        set
        {
            strPPNo = value;
        }
    }
    public string Details
    {
        get
        {
            return strDetails;
        }
        set
        {
            strDetails = value;
        }
    }
    private string strChangeAddress;
    //Santosh Shelar : Start//
    public string ChangeAddress
    {
        get
        {
            return strChangeAddress;
        }
        set
        {
            strChangeAddress = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public string strMISMATCH_RESI_ADD;
     public string MISMATCH_RESI_ADD
    {
        get
        {
            return strMISMATCH_RESI_ADD;
        }
        set
        {
            strMISMATCH_RESI_ADD = value;
        }
    }
    //Santosh Shelar : End//
    public string strVEHICLE_OTHER;
    public string VEHICLE_OTHER
    {
        get
        {
            return strVEHICLE_OTHER; 
        }
        set
        {
            strVEHICLE_OTHER = value;
        }
    }
    public string ResiAddress
    {
        get
        {
            return strResiAddress;
        }
        set
        {
            strResiAddress = value;
        }
    }
    public string Pincode
    {
        get
        {
            return strPincode;
        }
        set
        {
            strPincode = value;
        }
    }
    public string LandmarkOberservered
    {
        get
        {
            return strLandmarkOberservered;
        }
        set
        {
            strLandmarkOberservered = value;
        }
    }

    public string PermanentAddress
    {
        get
        {
            return strPermanentAddress;
        }
        set
        {
            strPermanentAddress = value;
        }
    }
    public string PPLocationAddress
    {
        get
        {
            return strPPLocationAddress;
        }
        set
        {
            strPPLocationAddress = value;
        }
    }
    public string OfficeAddress
    {
        get
        {
            return strOfficeAddress;
        }
        set
        {
            strOfficeAddress = value;
        }
    }
    public string ExtnNo
    {
        get
        {
            return strExtnNo;
        }
        set
        {
            strExtnNo = value;
        }
    }
    // End Of Properties for table CPV_CC_CASE_DETAILS(ADDRESS DETAIL)

    //Start Of Properties for table CPV_CC_VERI_DETAILS(IF APPLICANT HAS BEEN CONTACTED)
   
    private string strTimeAtCurrResi;
    private string strMailingAddress;
    private string strResidenceIs;
    private string strResiCumOffice;
    private string strOfficePhoneExtn;
    private string strNameOfCompany;
    private string strAppDesignation;
    private string strDesignation;
    private string strTimeAtCurrentEmployment;
    private string strNOB;
    
    private string strQualification;
    private string strTimeAtCurrEmpl;
    private string strIncomeDocsSubmittedWithApplication;    
    private string strResiPhoneNo;

    //Added by hemangi kambli on 14-May-2007 ----
    private string strAnyInfo;
    public string AnyOtherInfo
    {
        get
        {
            return strAnyInfo;
        }
        set
        {
            strAnyInfo = value;
        }
    }
    ///-------------------------------------------
    public string TimeAtCurrResi
    {
        get
        {
            return strTimeAtCurrResi;
        }
        set
        {
            strTimeAtCurrResi = value;
        }
    }
    public string MailingAddress
    {
        get
        {
            return strMailingAddress;
        }
        set
        {
            strMailingAddress = value;
        }
    }
    public string ResidenceIs
    {
        get
        {
            return strResidenceIs;
        }
        set
        {
            strResidenceIs = value;
        }
    }
    public string ResiCumOffice
    {
        get
        {
            return strResiCumOffice;
        }
        set
        {
            strResiCumOffice = value;
        }
    }
    public string OfficePhoneExtn
    {
        get
        {
            return strOfficePhoneExtn;
        }
        set
        {
            strOfficePhoneExtn = value;
        }
    }
    public string NameOfCompany
    {
        get
        {
            return strNameOfCompany;
        }
        set
        {
            strNameOfCompany = value;
        }
    }
    public string AppDesignation
    {
        get
        {
            return strAppDesignation;
        }
        set
        {
            strAppDesignation = value;
        }
    }
    public string Designation
    {
        get
        {
            return strDesignation;
        }
        set
        {
            strDesignation = value;
        }
    }
    public string TimeAtCurrentEmployment
    {
        get
        {
            return strTimeAtCurrentEmployment;
        }
        set
        {
            strTimeAtCurrentEmployment = value;
        }
    }
    public string NOB
    {
        get
        {
            return strNOB;
        }
        set
        {
            strNOB = value;
        }
    }
    public string Qualification
    {
        get
        {
            return strQualification;
        }
        set
        {
            strQualification = value;
        }
    }
    public string TimeAtCurrEmpl
    {
        get
        {
            return strTimeAtCurrEmpl;
        }
        set
        {
            strTimeAtCurrEmpl = value;
        }
    }
    public string IncomeDocsSubmittedWithApplication
    {
        get
        {
            return strIncomeDocsSubmittedWithApplication;
        }
        set
        {
            strIncomeDocsSubmittedWithApplication = value;
        }
    }
    public string ResiPhoneNo
    {
        get
        {
            return strResiPhoneNo;
        }
        set
        {
            strResiPhoneNo = value;
        }
    }
    // End Of Properties for table CPV_CC_VERI_DETAILS(IF APPLICANT HAS BEEN CONTACTED)

    //Start Of Properties for table CPV_CC_VERI_OTHER_DETAILS(IF SOMEONE OTHER THE APPLICANT IS CONTACTED) 
    private string strNameOfPersonContacted;
    private string strRelationship;
    //private DateTime strDOBofApplicant;
    private string strDOBofApplicant;
    private string strTimeAtCurrResiByOther;
    private string strApplicantAvailableAt;
    private string strVerifiersComments;
    private string strAgeApproxOfApplicant;
    private string strNewDetailsObt;
    private string strDesignationOfOtherContacted;
    private string strNatureOfBusiness;
    private string strTimeAtCurrEmplOfApplicant;
    private string strTeleComments;
    private string strOthersNatureOfBusiness;
    private string strOtherDesignation;
    private string strAppResiAdd;
    private string strNameofApplicantConfirmedatgivenPhoneNo1;
    private string strMisMatch;
    public string OtherDesignation
    {
        get
        {
            return strOtherDesignation;
        }
        set
        {
            strOtherDesignation = value;
        }
    }
    public string MisMatch
    {
        get
        {
            return strMisMatch; 
        }
        set
        {
            strMisMatch = value;
        }
    }
    public string OthersNatureOfBusiness
    {
        get
        {
            return strOthersNatureOfBusiness;
        }
        set
        {
            strOthersNatureOfBusiness = value;
        }
    }
    public string NameOfPersonContacted
    {
        get
        {
            return strNameOfPersonContacted;
        }
        set
        {
            strNameOfPersonContacted = value;
        }
    }
    public string Relationship
    {
        get
        {
            return strRelationship;
        }
        set
        {
            strRelationship = value;
        }
    }
    public string NameofApplicantConfirmedatgivenPhoneNo1
    {
        get
        {
            return strNameofApplicantConfirmedatgivenPhoneNo1; 
        }
        set
        {
            strNameofApplicantConfirmedatgivenPhoneNo1 = value;
        }
    }
    public string DOBofApplicant
    {
        get
        {
            return strDOBofApplicant;
        }
        set
        {
            strDOBofApplicant = value;
        }
    }
    public string TimeAtCurrResiByOther
    {
        get
        {
            return strTimeAtCurrResiByOther;
        }
        set
        {
            strTimeAtCurrResiByOther = value;
        }
    }
    public string ApplicantAvailableAt
    {
        get
        {
            return strApplicantAvailableAt;
        }
        set
        {
            strApplicantAvailableAt = value;
        }
    }
    public string VerifiersComments
    {
        get
        {
            return strVerifiersComments;
        }
        set
        {
            strVerifiersComments = value;
        }
    }
    public string AgeApproxOfApplicant
    {
        get
        {
            return strAgeApproxOfApplicant;
        }
        set
        {
            strAgeApproxOfApplicant = value;
        }
    }
    public string NewDetailsObt
    {
        get
        {
            return strNewDetailsObt;
        }
        set
        {
            strNewDetailsObt = value;
        }
    }
    public string DesignationOfOtherContacted
    {
        get
        {
            return strDesignationOfOtherContacted;
        }
        set
        {
            strDesignationOfOtherContacted = value;
        }
    }
    public string NatureOfBusiness
    {
        get
        {
            return strNatureOfBusiness;
        }
        set
        {
            strNatureOfBusiness = value;
        }
    }
    /// <summary>
    /// /////////add by santosh shelar 12-09-08///////////////////
    /// </summary>
    private string strOthNatureBuss;
    public string OthNatureBuss
    {
        get
        {
            return strOthNatureBuss; 
        }
        set
        {
            strOthNatureBuss = value;
        }
    }
    public string AppResiAdd
    {
        get
        {
            return strAppResiAdd; 
        }
        set
        {
            strAppResiAdd = value;
        }
    }
    /// <summary>
    /// ////////////
    /// </summary>
    public string TimeAtCurrEmplOfApplicant
    {
        get
        {
            return strTimeAtCurrEmplOfApplicant;
        }
        set
        {
            strTimeAtCurrEmplOfApplicant = value;
        }
    }
    public string TeleComments
    {
        get
        {
            return strTeleComments;
        }
        set
        {
            strTeleComments = value;
        }
    }
    // End Of Properties for table CPV_CC_VERI_OTHER_DETAILS(IF SOMEONE OTHER THE APPLICANT IS CONTACTED)

    //Start of Properties for table (RATING)
    private string strAddressConfirmation;
    private string strContactability;
    private string strConfirmApplication;
    private string strProfile;
    private string strReputation;
    private string strNegmatch;
    private string strDetailsNegmatch;
    //ADDED BY SUNNY CHAUHAN : START/////////
    private string strACTNUMBER;
    private string strACTNUMTYPE;
    //ADDITION ENDED : SUNNY CHAUHAN/////////
    private string strOverallAssessment;
    private string strReasonsAssessment;
    private string strFECode;
    private string strFEName;
    private string strCPVAgentName;
    private string verificationDate;
    private string strCPVAgentSig;

    public string AddressConfirmation
    {
        get
        {
            return strAddressConfirmation;
        }
        set
        {
            strAddressConfirmation = value;
        }
    }
    public string Contactability
    {
        get
        {
            return strContactability;
        }
        set
        {
            strContactability = value;
        }
    }
    public string ConfirmApplication
    {
        get
        {
            return strConfirmApplication;
        }
        set
        {
            strConfirmApplication = value;
        }
    }
    public string Profile
    {
        get
        {
            return strProfile;
        }
        set
        {
            strProfile = value;
        }
    }
    public string Reputation
    {
        get
        {
            return strReputation;
        }
        set
        {
            strReputation = value;
        }
    }
    public string Negmatch
    {
        get
        {
            return strNegmatch;
        }
        set
        {
            strNegmatch = value;
        }
    }
    public string DetailsNegmatch
    {
        get
        {
            return strDetailsNegmatch;
        }
        set
        {
            strDetailsNegmatch = value;
        }
    }
    public string OverallAssessment
    {
        get
        {
            return strOverallAssessment;
        }
        set
        {
            strOverallAssessment = value;
        }
    }
    public string ReasonsAssessment
    {
        get
        {
            return strReasonsAssessment;
        }
        set
        {
            strReasonsAssessment = value;
        }
    }
    public string ACTNUMTYPE
    {
        ////////ADDED BY SUNNY CHAUHAN : START//////////////////////
        get
        {
            return strACTNUMTYPE;
        }
        set
        {
            strACTNUMTYPE = value;
        }
    }
    public string ACTNUMBER
    {
        get
        {
            return strACTNUMBER;
        }
        set
        {
            strACTNUMBER = value;
        }
        //////ADDITION ENDED : SUNNY CHAUHAN///////////////
    }
    /// <summary>
    /// ////////add by santosh shelar declened reason 25-08-08////////////
    /// </summary>
    public string DeclineReason
    {
        get
        {
            return strDeclineReasons;
        }
        set
        {
            strDeclineReasons = value;
        }
    }

    public string FECode
    {
        get
        {
            return strFECode;
        }
        set
        {
            strFECode = value;
        }
    }
    public string FEName
    {
        get
        {
            return strFEName;
        }
        set
        {
            strFEName = value;
        }
    }
    public string CPVAgentName
    {
        get
        {
            return strCPVAgentName;
        }
        set
        {
            strCPVAgentName = value;
        }
    }
    public string VerificationDate
    {
        get
        {
            return verificationDate;
        }
        set
        {
            verificationDate = value;
        }
    }
    public string CPVAgentSig
    {
        get
        {
            return strCPVAgentSig;
        }
        set
        {
            strCPVAgentSig = value;
        }
    }

    //End of Properties for table (RATING)

    //Start of Properties for additionalField
    private string strSpecialInstructions;
    private string strIsOfficeAreaIsNegativeArea;
    private string strIsResidenceAddressIsNegativeArea;
    private string strNumberOfYearsAtCurrentAddress;
    private string strNumberOfResidentAtCurrentAddress;
    private string strEmployerAddress;
    private string strDesignationOfApplicantBusiness;
    private string strBusinessContactNo;
    private string strBusinessExtnNo;
    private string strDeptOfApplicant;
    private string strNameOfApplicantConfirmedAtGivenPhoneNo;
    private string strMismatchedInAddTelNo;
    private string strDirectoryCheck;
    private string strNoReason;////////Added By Sunny Chauhan//////////
    private string strTeleCallerName;
    private string strCalledUpOnResiTelNo;
    private string strSpkTo;
    private string strBusinessContactNoAndExtn;
    private string strResidenceStatus;
    private string strAnyOtherResiPhoneNo;
    private string strAdditionalRemark;
    private string strSupervisorRemark;
    private string strRecommendation;
    private string strNegativeCode;
    private string strPriorityCustomer;
    private string strSegmentation;
    private string strInfoRequired;
    private string strChangeInPhoneNumber;
    private string strReasonForChange;

    private string strTelecallerCode;
    private string strInputterCode;
    private string strInputterName;
    private string strDeclineReasons;
    private string strSupervisorCode;
    private string strSupervisorName;
    private string strCPVScore;
    private string strRegion;
    private string strDesigDeptOfContactedPerson;
    private string strEmployersName;
    private string strNoOfYearsAtCurrentEmployment;
    private string strResidencePhoneNo;
    private string strTeleCallerRemark;
    private string strCalledUpOnOffTelNo;
    private string strEmpConfirmedNotConfirmed;
    private string strYCR;
    private string strEmpPermanentTemp;
    private string strIncomeDoesSubmittedWithApplication;
    private string strCurrentResidencePeriod;
    private string strApplicantQualification;
    private string strForSelfEmployedTypeOfOrganisation;
    private string strTimeAtCurrResiYearMonth;
    private string strAppDOBApproxAge;
    private string strTimeAtCurrentEmplYearMonth;
    private string strTeleVerificationResult;

    public string TimeAtCurrentEmplYearMonth
    {
        get
        {
            return strTimeAtCurrentEmplYearMonth;
        }
        set
        {
            strTimeAtCurrentEmplYearMonth = value;
        }
    }

    public string AppDOBApproxAge
    {
        get
        {
            return strAppDOBApproxAge;
        }
        set
        {
            strAppDOBApproxAge = value;
        }
    }

    public string SpecialInstructions
    {
        get
        {
            return strSpecialInstructions;
        }
        set
        {
            strSpecialInstructions = value;
        }
    }
    public string IsOfficeAreaIsNegativeArea
    {
        get
        {
            return strIsOfficeAreaIsNegativeArea;
        }
        set
        {
            strIsOfficeAreaIsNegativeArea = value;
        }
    }
    public string IsResidenceAddressIsNegativeArea
    {
        get
        {
            return strIsResidenceAddressIsNegativeArea;
        }
        set
        {
            strIsResidenceAddressIsNegativeArea = value;
        }
    }
    public string NumberOfYearsAtCurrentAddress
    {
        get
        {
            return strNumberOfYearsAtCurrentAddress;
        }
        set
        {
            strNumberOfYearsAtCurrentAddress = value;
        }
    }
    public string NumberOfResidentAtCurrentAddress
    {
        get
        {
            return strNumberOfResidentAtCurrentAddress;
        }
        set
        {
            strNumberOfResidentAtCurrentAddress = value;
        }
    }
    public string EmployerAddress
    {
        get
        {
            return strEmployerAddress;
        }
        set
        {
            strEmployerAddress = value;
        }
    }
    public string DesignationOfApplicantBusiness
    {
        get
        {
            return strDesignationOfApplicantBusiness;
        }
        set
        {
            strDesignationOfApplicantBusiness = value;
        }
    }
    public string BusinessContactNo
    {
        get
        {
            return strBusinessContactNo;
        }
        set
        {
            strBusinessContactNo = value;
        }
    }
    public string BusinessExtnNo
    {
        get
        {
            return strBusinessExtnNo;
        }
        set
        {
            strBusinessExtnNo = value;
        }
    }
    public string DeptOfApplicant
    {
        get
        {
            return strDeptOfApplicant;
        }
        set
        {
            strDeptOfApplicant = value;
        }
    }
    public string NameOfApplicantConfirmedAtGivenPhoneNo
    {
        get
        {
            return strNameOfApplicantConfirmedAtGivenPhoneNo;
        }
        set
        {
            strNameOfApplicantConfirmedAtGivenPhoneNo = value;
        }
    }
    public string MismatchedInAddTelNo
    {
        get
        {
            return strMismatchedInAddTelNo;
        }
        set
        {
            strMismatchedInAddTelNo = value;
        }
    }
    public string DirectoryCheck
    {
        get
        {
            return strDirectoryCheck;
        }
        set
        {
            strDirectoryCheck = value;
        }
    }
    public string NoReason
    {
        /////Added By Sunny Chauhan : Start /////////
        get
        {
            return strNoReason;
        }
        set
        {
            strNoReason = value;
        }
        /////Added By Sunny Chauhan : End /////////
    }

    public string EmpCode
    {
        //////Added By Santosh Shelar : Start /////////
        get
        {
            return strEmpCode;
        }
        set
        {
            strEmpCode = value;
        }
        //////Added By Santosh Shelar : End ///////////
    }
    
    public string TeleCallerName
    {
        get
        {
            return strTeleCallerName;
        }
        set
        {
            strTeleCallerName = value;
        }
    }
    public string CalledUpOnResiTelNo
    {
        get
        {
            return strCalledUpOnResiTelNo;
        }
        set
        {
            strCalledUpOnResiTelNo = value;
        }
    }
    public string SpkTo
    {
        get
        {
            return strSpkTo;
        }
        set
        {
            strSpkTo = value;
        }
    }

    public string BusinessContactNoAndExtn
    {
        get
        {
            return strBusinessContactNoAndExtn;
        }
        set
        {
            strBusinessContactNoAndExtn = value;
        }
    }
    public string ResidenceStatus
    {
        get
        {
            return strResidenceStatus;
        }
        set
        {
            strResidenceStatus = value;
        }
    }
    public string AnyOtherResiPhoneNo
    {
        get
        {
            return strAnyOtherResiPhoneNo;
        }
        set
        {
            strAnyOtherResiPhoneNo = value;
        }
    }
    public string AdditionalRemark
    {
        get
        {
            return strAdditionalRemark;
        }
        set
        {
            strAdditionalRemark = value;
        }
    }
    public string SupervisorRemark
    {
        get
        {
            return strSupervisorRemark;
        }
        set
        {
            strSupervisorRemark = value;
        }
    }
    public string Recommendation
    {
        get
        {
            return strRecommendation;
        }
        set
        {
            strRecommendation = value;
        }
    }
    public string NegativeCode
    {
        get
        {
            return strNegativeCode;
        }
        set
        {
            strNegativeCode = value;
        }
    }


    // Added By Rupesh On 21-March-2013

    private string strpersoncontacted;
    public string personcontacted
    {
        get
        {
            return strpersoncontacted;
        }
        set
        {
            strpersoncontacted = value;
        }
    }

    private string strstatus;
    public string status
    {
        get
        {
            return strstatus;
        }
        set
        {
            strstatus = value;
        }
    }

    private string strResponse;
    public string Response
    {
        get
        {
            return strResponse;
        }
        set
        {
            strResponse = value;
        }
    }

    private string strReason;
    public string Reason
    {
        get
        {
            return strReason;
        }
        set
        {
            strReason = value;
        }
    }


    //Added By rupesh On 19-June-2013

    private string strAnswered;
    public string Answered
    {
        get
        {
            return strAnswered;
        }
        set
        {
            strAnswered = value;
        }
    }


     private string strHomeCountryNumber;
    public string HomeCountryNumber
    {
        get
        {
            return strHomeCountryNumber;
        }
        set
        {
            strHomeCountryNumber = value;
        }
    }
    
     private string strHomeCountryAddress;
    public string HomeCountryAddress
    {
        get
        {
            return strHomeCountryAddress;
        }
        set
        {
            strHomeCountryAddress = value;
        }
    }

     private string strLocalHomeAddress;
    public string LocalHomeAddress
    {
        get
        {
            return strLocalHomeAddress;
        }
        set
        {
            strLocalHomeAddress = value;
        }
    }

     private string strPOBox;
    public string POBox
    {
        get
        {
            return strPOBox;
        }
        set
        {
            strPOBox = value;
        }
    }


    private string strMothersmaidenname;
    public string Mothersmaidenname
    {
        get
        {
            return strMothersmaidenname;
        }
        set
        {
            strMothersmaidenname = value;
        }
    }



    //Added By rupesh On 19-June-2013




    private string strRESIDENCE_VERITYP;
    public string RESIDENCE_VERITYP
    {
        get
        {
            return strRESIDENCE_VERITYP;
        }
        set
        {
            strRESIDENCE_VERITYP = value;
        }
    }


    private string strAgency;
    public string Agency
    {
        get
        {
            return strAgency;
        }
        set
        {
            strAgency = value;
        }
    }

    // Added By Rupesh On 21-March-2013










    public string PriorityCustomer
    {
        get
        {
            return strPriorityCustomer;
        }
        set
        {
            strPriorityCustomer = value;
        }
    }
    public string Segmentation
    {
        get
        {
            return strSegmentation;
        }
        set
        {
            strSegmentation = value;
        }
    }
    public string InfoRequired
    {
        get
        {
            return strInfoRequired;
        }
        set
        {
            strInfoRequired = value;
        }
    }
    public string ChangeInPhoneNumber
    {
        get
        {
            return strChangeInPhoneNumber;
        }
        set
        {
            strChangeInPhoneNumber = value;
        }
    }
    public string ReasonForChange
    {
        get
        {
            return strReasonForChange;
        }
        set
        {
            strReasonForChange = value;
        }
    }
   
    public string TelecallerCode
    {
        get
        {
            return strTelecallerCode;
        }
        set
        {
            strTelecallerCode = value;
        }
    }
    public string InputterCode
    {
        get
        {
            return strInputterCode;
        }
        set
        {
            strInputterCode = value;
        }
    }
    public string InputterName
    {
        get
        {
            return strInputterName;
        }
        set
        {
            strInputterName = value;
        }
    }
    public string DeclineReasons
    {
        get
        {
            return strDeclineReasons;
        }
        set
        {
            strDeclineReasons = value;
        }
    }
    /////////////////add by santosh shelar////////////////////
    private string strSUPER_ID;
        public string SupervisorId
    {
        get
        {
            return strSUPER_ID; 
        }
        set
        {
            strSUPER_ID = value;
        }
    }
    public string SupervisorCode
    {
        get
        {
            return strSupervisorCode;
        }
        set
        {
            strSupervisorCode = value;
        }
    }
    public string SupervisorName
    {
        get
        {
            return strSupervisorName;
        }
        set
        {
            strSupervisorName = value;
        }
    }
    
    public string CPVScore
    {
        get
        {
            return strCPVScore;
        }
        set
        {
            strCPVScore = value;
        }
    }
    public string Region
    {
        get
        {
            return strRegion;
        }
        set
        {
            strRegion = value;
        }
    }
    public string DesigDeptOfContactedPerson
    {
        get
        {
            return strDesigDeptOfContactedPerson;
        }
        set
        {
            strDesigDeptOfContactedPerson = value;
        }
    }
    public string EmployersName
    {
        get
        {
            return strEmployersName;
        }
        set
        {
            strEmployersName = value;
        }
    }
    public string NoOfYearsAtCurrentEmployment
    {
        get
        {
            return strNoOfYearsAtCurrentEmployment;
        }
        set
        {
            strNoOfYearsAtCurrentEmployment = value;
        }
    }
    public string ResidencePhoneNo
    {
        get
        {
            return strResidencePhoneNo;
        }
        set
        {
            strResidencePhoneNo = value;
        }
    }
    public string TeleCallerRemark
    {
        get
        {
            return strTeleCallerRemark;
        }
        set
        {
            strTeleCallerRemark = value;
        }
    }
    public string CalledUpOnOffTelNo
    {
        get
        {
            return strCalledUpOnOffTelNo;
        }
        set
        {
            strCalledUpOnOffTelNo = value;
        }
    }
    public string EmpConfirmedNotConfirmed
    {
        get
        {
            return strEmpConfirmedNotConfirmed;
        }
        set
        {
            strEmpConfirmedNotConfirmed = value;
        }
    }
    public string YCR
    {
        get
        {
            return strYCR;
        }
        set
        {
            strYCR = value;
        }
    }
    public string EmpPermanentTemp
    {
        get
        {
            return strEmpPermanentTemp;
        }
        set
        {
            strEmpPermanentTemp = value;
        }
    }
    public string IncomeDoesSubmittedWithApplication
    {
        get
        {
            return strIncomeDoesSubmittedWithApplication;
        }
        set
        {
            strIncomeDoesSubmittedWithApplication = value;
        }
    }
    public string CurrentResidencePeriod
    {
        get
        {
            return strCurrentResidencePeriod;
        }
        set
        {
            strCurrentResidencePeriod = value;
        }
    }
    public string ApplicantQualification
    {
        get
        {
            return strApplicantQualification;
        }
        set
        {
            strApplicantQualification = value;
        }
    }
    public string ForSelfEmployedTypeOfOrganisation
    {
        get
        {
            return strForSelfEmployedTypeOfOrganisation;
        }
        set
        {
            strForSelfEmployedTypeOfOrganisation = value;
        }
    }
    public string TimeAtCurrResiYearMonth
    {
        get
        {
            return strTimeAtCurrResiYearMonth;
        }
        set
        {
            strTimeAtCurrResiYearMonth = value;
        }
    }
    public string TeleVerificationResult
    {
        get
        {
            return strTeleVerificationResult;
        }
        set
        {
            strTeleVerificationResult = value;
        }
    }

    //added by hemangi kambli on 07/09/2007------
    private string sSubRemark;
    public string SubRemark
    {
        get { return sSubRemark;}
        set { sSubRemark = value; }
    }
    private string sFeVisit;
    public string FeVisit
    {
        get { return sFeVisit; }
        set { sFeVisit = value; }
    }
    private string sFeName;
    public string FeName
    {
        get { return sFeName; }
        set { sFeName = value; }
    }
    private string sAddedBy;
    private string sModifiedBy;
    private DateTime dtAdded;
    private DateTime dtModify;
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
    //-----------------------------------------------
    //End of Properties for additionalField

    #endregion Properties Declaration

    #region InsertTeleCallLogDcr
    /// <summary>
    /// This method is used to Insert the Fields in the CPV_CC_VERI_ATTEMPTS
    /// </summary>
    /// <param name="arrTeleCallLog"></param>
    /// <returns></returns>
    /// 
    public String InsertTeleCallLogDcr(ArrayList arrTeleCallLog)
    {
        string strError = "";
        String returnValue = "";
        //string VerificationTypeID = "20";

        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        try
        {

            OleDbParameter[] paramDeleteAttempt = new OleDbParameter[11];

            paramDeleteAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
            paramDeleteAttempt[0].Value = "DELETE";

            paramDeleteAttempt[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[1].Value = CaseID;


            paramDeleteAttempt[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[2].Value = VerifierID;

            paramDeleteAttempt[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
            paramDeleteAttempt[3].Value = AttemptDateTime;

            paramDeleteAttempt[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
            paramDeleteAttempt[4].Value = Remark;

            paramDeleteAttempt[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
            paramDeleteAttempt[5].Value = TelePhoneNo;

            paramDeleteAttempt[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[6].Value = VerificationTypeID;

            paramDeleteAttempt[7] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
            paramDeleteAttempt[7].Value = SubRemark;

            paramDeleteAttempt[8] = new OleDbParameter("@FeVisit", OleDbType.VarChar, 300);
            paramDeleteAttempt[8].Value = FeVisit;

            paramDeleteAttempt[9] = new OleDbParameter("@FeName", OleDbType.VarChar, 300);
            paramDeleteAttempt[9].Value = FeName; 

            paramDeleteAttempt[10] = new OleDbParameter("@MessageNo", OleDbType.Integer);
            paramDeleteAttempt[10].Direction = ParameterDirection.Output;

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBTdcr", paramDeleteAttempt);

            if (arrTeleCallLog.Count > 0)
            {
                foreach (ArrayList item in arrTeleCallLog)
                {
                    AttemptDateTime = item[0].ToString();
                    Remark = item[1].ToString();
                    SubRemark = item[2].ToString();
                    TelePhoneNo = item[3].ToString();
                    VerifierID = item[4].ToString();
                    FeVisit = item[5].ToString();
                    FeName = item[6].ToString();
                    //VerificationTypeID = item[5].ToString();

                    OleDbParameter[] oledbParam = new OleDbParameter[11];

                    //////////////////////////////Inserting in table CPV_CC_VERI_ATTEMPTS(Residence)                 

                    oledbParam[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                    oledbParam[0].Direction = ParameterDirection.Input;
                    oledbParam[0].Value = "ADD";


                    oledbParam[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                    oledbParam[1].Direction = ParameterDirection.Input;
                    oledbParam[1].Value = CaseID;


                    oledbParam[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
                    oledbParam[2].Direction = ParameterDirection.Input;
                    oledbParam[2].Value = VerifierID;

                    oledbParam[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.DBTimeStamp, 8);
                    oledbParam[3].Direction = ParameterDirection.Input;
                    oledbParam[3].Value = AttemptDateTime;

                    oledbParam[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
                    oledbParam[4].Direction = ParameterDirection.Input;
                    oledbParam[4].Value = Remark;

                    oledbParam[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
                    oledbParam[5].Direction = ParameterDirection.Input;
                    oledbParam[5].Value = TelePhoneNo;

                    oledbParam[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParam[6].Direction = ParameterDirection.Input;
                    oledbParam[6].Value = VerificationTypeID;
                    
                    oledbParam[7] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
                    oledbParam[7].Direction = ParameterDirection.Input;
                    oledbParam[7].Value = SubRemark;

                    oledbParam[8] = new OleDbParameter("@FeVisit", OleDbType.VarChar, 300);
                    oledbParam[8].Direction = ParameterDirection.Input;
                    oledbParam[8].Value = FeVisit;

                    oledbParam[9] = new OleDbParameter("@FeName", OleDbType.VarChar, 300);
                    oledbParam[9].Direction = ParameterDirection.Input;
                    oledbParam[9].Value = FeName;  

                    oledbParam[10] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParam[10].Direction = ParameterDirection.Output;

                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBTdcr", oledbParam);
                    if (Convert.ToInt32(oledbParam[10].Value) == 3)
                    {
                        returnValue = "Record Deleted successfully.";

                    }
                    else if (Convert.ToInt32(oledbParam[10].Value) == 1)
                    {
                        returnValue = "Record Added successfully.";
                   }
                }
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
        return returnValue;

    }
     #endregion InsertTeleCallLogDcr

    public String InsertTeleCallLogDcr1(ArrayList arrTeleCallLog)
    {
        string strError = "";
        String returnValue = "";
        //string VerificationTypeID = "20";

        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

        try
        {

            OleDbParameter[] paramDeleteAttempt = new OleDbParameter[11];

            paramDeleteAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
            paramDeleteAttempt[0].Value = "DELETE";

            paramDeleteAttempt[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[1].Value = CaseID;


            paramDeleteAttempt[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[2].Value = VerifierID;

            paramDeleteAttempt[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
            paramDeleteAttempt[3].Value = AttemptDateTime;

            paramDeleteAttempt[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
            paramDeleteAttempt[4].Value = Remark;

            paramDeleteAttempt[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
            paramDeleteAttempt[5].Value = TelePhoneNo;

            paramDeleteAttempt[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
            paramDeleteAttempt[6].Value = VerificationTypeID;

            paramDeleteAttempt[7] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
            paramDeleteAttempt[7].Value = SubRemark;

            paramDeleteAttempt[8] = new OleDbParameter("@FeVisit", OleDbType.VarChar, 300);
            paramDeleteAttempt[8].Value = FeVisit;

            paramDeleteAttempt[9] = new OleDbParameter("@FeName", OleDbType.VarChar, 300);
            paramDeleteAttempt[9].Value = FeName;

            paramDeleteAttempt[10] = new OleDbParameter("@MessageNo", OleDbType.Integer);
            paramDeleteAttempt[10].Direction = ParameterDirection.Output;

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBTdcr", paramDeleteAttempt);

            if (arrTeleCallLog.Count > 0)
            {
                foreach (ArrayList item in arrTeleCallLog)
                {
                    AttemptDateTime = item[0].ToString();
                    Remark = item[1].ToString();
                    SubRemark = item[2].ToString();
                    TelePhoneNo = item[3].ToString();
                    VerifierID = item[4].ToString();
                    //FeVisit = item[5].ToString();
                    //FeName = item[6].ToString();
                    //VerificationTypeID = item[5].ToString();

                    OleDbParameter[] oledbParam = new OleDbParameter[11];

                    //////////////////////////////Inserting in table CPV_CC_VERI_ATTEMPTS(Residence)                 

                    oledbParam[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                    oledbParam[0].Direction = ParameterDirection.Input;
                    oledbParam[0].Value = "ADD";


                    oledbParam[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                    oledbParam[1].Direction = ParameterDirection.Input;
                    oledbParam[1].Value = CaseID;


                    oledbParam[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
                    oledbParam[2].Direction = ParameterDirection.Input;
                    oledbParam[2].Value = VerifierID;

                    oledbParam[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.DBTimeStamp, 8);
                    oledbParam[3].Direction = ParameterDirection.Input;
                    oledbParam[3].Value = AttemptDateTime;

                    oledbParam[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
                    oledbParam[4].Direction = ParameterDirection.Input;
                    oledbParam[4].Value = Remark;

                    oledbParam[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
                    oledbParam[5].Direction = ParameterDirection.Input;
                    oledbParam[5].Value = TelePhoneNo;

                    oledbParam[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParam[6].Direction = ParameterDirection.Input;
                    oledbParam[6].Value = VerificationTypeID;

                    oledbParam[7] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
                    oledbParam[7].Direction = ParameterDirection.Input;
                    oledbParam[7].Value = SubRemark;

                    oledbParam[8] = new OleDbParameter("@FeVisit", OleDbType.VarChar, 300);
                    oledbParam[8].Direction = ParameterDirection.Input;
                    oledbParam[8].Value = FeVisit;

                    oledbParam[9] = new OleDbParameter("@FeName", OleDbType.VarChar, 300);
                    oledbParam[9].Direction = ParameterDirection.Input;
                    oledbParam[9].Value = FeName;

                    oledbParam[10] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParam[10].Direction = ParameterDirection.Output;

                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBTdcr", oledbParam);
                    if (Convert.ToInt32(oledbParam[10].Value) == 3)
                    {
                        returnValue = "Record Deleted successfully.";

                    }
                    else if (Convert.ToInt32(oledbParam[10].Value) == 1)
                    {
                        returnValue = "Record Added successfully.";
                    }
                }
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
        return returnValue;

    }


    #region InsertTeleCallLog
    public String InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        string strError = "";
        String returnValue = "";
        
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    
        try
        {
   
               OleDbParameter[] paramDeleteAttempt = new OleDbParameter[8];

                paramDeleteAttempt[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                paramDeleteAttempt[0].Value = "DELETE";

                paramDeleteAttempt[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[1].Value = CaseID;


                paramDeleteAttempt[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[2].Value = VerifierID;

                paramDeleteAttempt[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
                paramDeleteAttempt[3].Value = AttemptDateTime;

                paramDeleteAttempt[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
                paramDeleteAttempt[4].Value = Remark;

                paramDeleteAttempt[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
                paramDeleteAttempt[5].Value = TelePhoneNo;

                paramDeleteAttempt[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramDeleteAttempt[6].Value = VerificationTypeID;

                paramDeleteAttempt[7] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramDeleteAttempt[7].Direction = ParameterDirection.Output;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBT", paramDeleteAttempt);

                if (arrTeleCallLog.Count > 0)
                {
                    foreach (ArrayList item in arrTeleCallLog)
                    {
                        AttemptDateTime = item[0].ToString();
                        Remark = item[1].ToString();
                        TelePhoneNo = item[2].ToString();
                        VerifierID = item[3].ToString();

                        OleDbParameter[] oledbParam = new OleDbParameter[8];

                        //////////////////////////////Inserting in table CPV_CC_VERI_ATTEMPTS(Residence)                 

                        oledbParam[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                        oledbParam[0].Direction = ParameterDirection.Input;
                        oledbParam[0].Value = "ADD";


                        oledbParam[1] = new OleDbParameter("@Case_ID", OleDbType.VarChar, 15);
                        oledbParam[1].Direction = ParameterDirection.Input;
                        oledbParam[1].Value = CaseID;


                        oledbParam[2] = new OleDbParameter("@VERIFIER_ID", OleDbType.VarChar, 15);
                        oledbParam[2].Direction = ParameterDirection.Input;
                        oledbParam[2].Value = VerifierID;

                        oledbParam[3] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.DBTimeStamp, 8);
                        oledbParam[3].Direction = ParameterDirection.Input;
                        oledbParam[3].Value = AttemptDateTime;

                        oledbParam[4] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
                        oledbParam[4].Direction = ParameterDirection.Input;
                        oledbParam[4].Value = Remark;

                        oledbParam[5] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
                        oledbParam[5].Direction = ParameterDirection.Input;
                        oledbParam[5].Value = TelePhoneNo;

                        oledbParam[6] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                        oledbParam[6].Direction = ParameterDirection.Input;
                        oledbParam[6].Value = VerificationTypeID;

                        oledbParam[7] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                        oledbParam[7].Direction = ParameterDirection.Output;

                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddDeleteCCAttemptRTBT", oledbParam);
                        if (Convert.ToInt32(oledbParam[7].Value) == 3)
                        {
                            returnValue = "Record Deleted successfully.";

                        }
                        else if (Convert.ToInt32(oledbParam[7].Value) == 1)
                        {
                            returnValue = "Record Added successfully.";
                        }


                    }
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
        return returnValue;

    }
    #endregion InsertTeleCallLog

    #region InsertResidenceVerificationDetails
    /// <summary>
    /// This Method is used for Insert the Fields OF Residence Telephonic to the DataBase.
    /// </summary>
    /// <returns></returns>
    public string InsertResidenceVerificationDetails()
    {
       

        
        String sqlQuery = "";
        string sRetVal = "";
        string strError = "";
       

        try
        {
            //This Checks that wether the vales to be inserted in RT is in Update mode or Insert mode.
            OleDbConnection oledbConn0 = new OleDbConnection(objCon.ConnectionString);
            oledbConn0.Open();
            OleDbTransaction oledbTrans0 = oledbConn0.BeginTransaction();
            OleDbParameter[] oledbParam0 = new OleDbParameter[3];
            oledbParam0[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            oledbParam0[0].Value = CaseID;
            oledbParam0[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
            oledbParam0[1].Value = VerificationTypeID;
            oledbParam0[2] = new OleDbParameter("@TableToEdit", OleDbType.VarChar, 15);
            oledbParam0[2].Direction = ParameterDirection.Output;


            OleDbHelper.ExecuteNonQuery(oledbTrans0, CommandType.StoredProcedure, "spTableToEdit", oledbParam0);
            string[] strTableToEditArray = oledbParam0[2].Value.ToString().Split(',');


            OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
            oledbConn.Open();
            OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
            //////////////////////////////Inserting in table CPV_CC_VERI_DESCRIPTION1(Residence)
            try
            {
                /////Array Increased by 1[33] by Sunny Chauhan//////////
          
                OleDbParameter[] oledbParam = new OleDbParameter[52];

                oledbParam[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParam[0].Direction = ParameterDirection.Input;
                 if (!(strTableToEditArray[1].Equals("1")))
                {
                    oledbParam[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParam[0].Value = "EDIT";

                }
                
                    oledbParam[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParam[1].Direction = ParameterDirection.Input;
                    oledbParam[1].Value = CaseID;

                    oledbParam[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParam[2].Direction = ParameterDirection.Input;
                    oledbParam[2].Value = VerificationTypeID;

                    oledbParam[3] = new OleDbParameter("@CONTACTED_PERSON_NAME", OleDbType.VarChar, 100);
                    oledbParam[3].Direction = ParameterDirection.Input;
                    oledbParam[3].Value = PersonContacted;

                    oledbParam[4] = new OleDbParameter("@COMPANY_NAME", OleDbType.VarChar, 100);
                    oledbParam[4].Direction = ParameterDirection.Input;
                    oledbParam[4].Value = NameOfCompany;

                    oledbParam[5] = new OleDbParameter("@MAILING_ADDRESS", OleDbType.VarChar, 255);
                    oledbParam[5].Direction = ParameterDirection.Input;
                    oledbParam[5].Value = MailingAddress;

                    oledbParam[6] = new OleDbParameter("@RESIDANCE_IS", OleDbType.VarChar, 20);
                    oledbParam[6].Direction = ParameterDirection.Input;
                    oledbParam[6].Value = ResidenceIs;

                    oledbParam[7] = new OleDbParameter("@DESIGNATION", OleDbType.VarChar, 100);
                    oledbParam[7].Direction = ParameterDirection.Input;
                    oledbParam[7].Value = Designation;

                    oledbParam[8] = new OleDbParameter("@NOB", OleDbType.VarChar, 15);
                    oledbParam[8].Direction = ParameterDirection.Input;
                    oledbParam[8].Value = NOB;

                    oledbParam[9] = new OleDbParameter("@DOB_APPLICANT", OleDbType.VarChar, 50);
                    oledbParam[9].Direction = ParameterDirection.Input;
                    oledbParam[9].Value = DOBofApplicant;

                    oledbParam[10] = new OleDbParameter("@APPLICANT_IS_AVAILABLE_AT", OleDbType.VarChar, 20);
                    oledbParam[10].Direction = ParameterDirection.Input;
                    oledbParam[10].Value = ApplicantAvailableAt;

                    oledbParam[11] = new OleDbParameter("@NEW_DETAILS_OBTAINED", OleDbType.VarChar, 100);
                    oledbParam[11].Direction = ParameterDirection.Input;
                    oledbParam[11].Value = NewDetailsObt;

                    oledbParam[12] = new OleDbParameter("@SPECIAL_INSTRUCTIONS", OleDbType.VarChar, 255);
                    oledbParam[12].Direction = ParameterDirection.Input;
                    oledbParam[12].Value = SpecialInstructions;

                    oledbParam[13] = new OleDbParameter("@IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA", OleDbType.VarChar, 50);
                    oledbParam[13].Direction = ParameterDirection.Input;
                    oledbParam[13].Value = IsOfficeAreaIsNegativeArea;

                    oledbParam[14] = new OleDbParameter("@EMPLOYER_ADD", OleDbType.VarChar, 255);
                    oledbParam[14].Direction = ParameterDirection.Input;
                    oledbParam[14].Value = EmployerAddress;

                    oledbParam[15] = new OleDbParameter("@APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO", OleDbType.VarChar, 20);
                    oledbParam[15].Direction = ParameterDirection.Input;
                    oledbParam[15].Value = NameOfApplicantConfirmedAtGivenPhoneNo;

                    oledbParam[16] = new OleDbParameter("@RESIDANCE_STATUS", OleDbType.VarChar, 50);
                    oledbParam[16].Direction = ParameterDirection.Input;
                    oledbParam[16].Value = ResidenceStatus;

                    oledbParam[17] = new OleDbParameter("@ANY_OTHER_RESIDANCE_PHONE_NO", OleDbType.VarChar, 50);
                    oledbParam[17].Direction = ParameterDirection.Input;
                    oledbParam[17].Value = AnyOtherResiPhoneNo;

                    oledbParam[18] = new OleDbParameter("@CHANGE_IN_PHONE_NO", OleDbType.VarChar, 50);
                    oledbParam[18].Direction = ParameterDirection.Input;
                    oledbParam[18].Value = ChangeInPhoneNumber;

                    oledbParam[19] = new OleDbParameter("@REASON_FOR_CHANGE", OleDbType.VarChar, 25);
                    oledbParam[19].Direction = ParameterDirection.Input;
                    oledbParam[19].Value = ReasonForChange;

                    oledbParam[20] = new OleDbParameter("@SEGMENTATION", OleDbType.VarChar, 15);
                    oledbParam[20].Direction = ParameterDirection.Input;
                    oledbParam[20].Value = Segmentation;

                    oledbParam[21] = new OleDbParameter("@DIRECTORY_CHECK", OleDbType.VarChar, 100);
                    oledbParam[21].Direction = ParameterDirection.Input;
                    oledbParam[21].Value = DirectoryCheck;

                    oledbParam[22] = new OleDbParameter("@PP_ADD_LOCATION", OleDbType.VarChar, 25);
                    oledbParam[22].Direction = ParameterDirection.Input;
                    oledbParam[22].Value = PPLocationAddress;

                    oledbParam[23] = new OleDbParameter("@TIME_AT_CURRENT_EMPLOYMENT", OleDbType.VarChar, 50);
                    oledbParam[23].Direction = ParameterDirection.Input;
                    oledbParam[23].Value = TimeAtCurrEmpl;

                    oledbParam[24] = new OleDbParameter("@SPK_TO", OleDbType.VarChar, 15);
                    oledbParam[24].Direction = ParameterDirection.Input;
                    oledbParam[24].Value = SpkTo;
                
                    oledbParam[25] = new OleDbParameter("@RESI_COMOFF_OWNED", OleDbType.VarChar, 20);
                    oledbParam[25].Direction = ParameterDirection.Input;
                    oledbParam[25].Value = ResiCumOffice;
                
                    oledbParam[26] = new OleDbParameter("@BUSINESS_CONTACT_EXTN", OleDbType.VarChar, 50);
                    oledbParam[26].Direction = ParameterDirection.Input;
                    oledbParam[26].Value = BusinessExtnNo;
                
                    oledbParam[27] = new OleDbParameter("@IS_RESI_ADD_IS_IN_NEGATIVE_AREA", OleDbType.VarChar, 50);
                    oledbParam[27].Direction = ParameterDirection.Input;
                    oledbParam[27].Value = IsResidenceAddressIsNegativeArea;
                
                    oledbParam[28] = new OleDbParameter("@CALLED_UP_ON_RESIDANCE_TEL_NO", OleDbType.VarChar, 15);
                    oledbParam[28].Direction = ParameterDirection.Input;
                    oledbParam[28].Value = CalledUpOnResiTelNo;
                
                    oledbParam[29] = new OleDbParameter("@NATURE_BUSINESS_RESI_CUM_OFF", OleDbType.VarChar, 200);
                    oledbParam[29].Direction = ParameterDirection.Input;
                    oledbParam[29].Value = NatureOfBusiness;

                    oledbParam[30] = new OleDbParameter("@NAME_OF_PERSON_CONTACTED", OleDbType.VarChar, 100);
                    oledbParam[30].Direction = ParameterDirection.Input;
                    oledbParam[30].Value = NameOfPersonContacted;

                    //////Added By Sunny Chauhan///////////////////////////////

                    oledbParam[31] = new OleDbParameter("@No_REason", OleDbType.VarChar, 150);
                    oledbParam[31].Direction = ParameterDirection.Input;
                    oledbParam[31].Value = NoReason;

                    //////Addition Ended Sunny Chauhan/////////////////////////

                    //////Added by santos shelar as emp code new field//////////////////////
                    oledbParam[32] = new OleDbParameter("@emp_code", OleDbType.VarChar, 50);
                    oledbParam[32].Direction = ParameterDirection.Input;
                    oledbParam[32].Value = EmpCode;

                    oledbParam[33] = new OleDbParameter("@Appli_Dept", OleDbType.VarChar, 100);
                    oledbParam[33].Direction = ParameterDirection.Input;
                    oledbParam[33].Value = DeptOfApplicant;

                    oledbParam[34] = new OleDbParameter("@Office_Ext", OleDbType.VarChar, 50);
                    oledbParam[34].Direction = ParameterDirection.Input;
                    oledbParam[34].Value = OffTel;

                    oledbParam[35] = new OleDbParameter("@no_of_years_at_current_employment", OleDbType.VarChar, 50);
                    oledbParam[35].Direction = ParameterDirection.Input;
                    oledbParam[35].Value = NoOfCurrAdd;

                    oledbParam[36] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 100);
                    oledbParam[36].Direction = ParameterDirection.Input;
                    oledbParam[36].Value = DirCheck;

                    oledbParam[37] = new OleDbParameter("@InputterName", OleDbType.VarChar, 500);
                    oledbParam[37].Direction = ParameterDirection.Input;
                    oledbParam[37].Value = InputterName;

                    oledbParam[38] = new OleDbParameter("@DateofVerification", OleDbType.VarChar, 500);
                    oledbParam[38].Direction = ParameterDirection.Input;
                    oledbParam[38].Value = DateofVerification;

                    // Added By Rupesh On 21-March-2013

                    oledbParam[39] = new OleDbParameter("@Response", OleDbType.VarChar, 50);
                    oledbParam[39].Direction = ParameterDirection.Input;
                    oledbParam[39].Value = Response;

                    oledbParam[40] = new OleDbParameter("@status", OleDbType.VarChar, 50);
                    oledbParam[40].Direction = ParameterDirection.Input;
                    oledbParam[40].Value =status;

                    oledbParam[41] = new OleDbParameter("@personcontacted", OleDbType.VarChar, 50);
                    oledbParam[41].Direction = ParameterDirection.Input;
                    oledbParam[41].Value =personcontacted;

                    oledbParam[42] = new OleDbParameter("@RESIDENCE_VERITYP", OleDbType.VarChar, 50);
                    oledbParam[42].Direction = ParameterDirection.Input;
                    oledbParam[42].Value = RESIDENCE_VERITYP;

                    oledbParam[43] = new OleDbParameter("@Agency", OleDbType.VarChar, 50);
                    oledbParam[43].Direction = ParameterDirection.Input;
                    oledbParam[43].Value = Agency;

                    oledbParam[44] = new OleDbParameter("@Reason", OleDbType.VarChar, 50);
                    oledbParam[44].Direction = ParameterDirection.Input;
                    oledbParam[44].Value = Reason;


                    oledbParam[45] = new OleDbParameter("@Answered", OleDbType.VarChar, 500);
                    oledbParam[45].Direction = ParameterDirection.Input;
                    oledbParam[45].Value = Answered;

                      oledbParam[46] = new OleDbParameter("@HomeCountryNumber", OleDbType.VarChar, 500);
                    oledbParam[46].Direction = ParameterDirection.Input;
                    oledbParam[46].Value = HomeCountryNumber;

                      oledbParam[47] = new OleDbParameter("@HomeCountryAddress", OleDbType.VarChar, 500);
                    oledbParam[47].Direction = ParameterDirection.Input;
                    oledbParam[47].Value = HomeCountryAddress;

                      oledbParam[48] = new OleDbParameter("@LocalHomeAddress", OleDbType.VarChar, 500);
                    oledbParam[48].Direction = ParameterDirection.Input;
                    oledbParam[48].Value = LocalHomeAddress;

                      oledbParam[49] = new OleDbParameter("@POBox", OleDbType.VarChar, 50);
                    oledbParam[49].Direction = ParameterDirection.Input;
                    oledbParam[49].Value = POBox;

                      oledbParam[50] = new OleDbParameter("@Mothersmaidenname", OleDbType.VarChar, 500);
                    oledbParam[50].Direction = ParameterDirection.Input;
                    oledbParam[50].Value = Mothersmaidenname;
                





                    // Added By Rupesh On 21-March-2013

                    ////oledbParam[37] = new OleDbParameter("@AuthoSign", OleDbType.VarChar, 100);
                    ////oledbParam[37].Direction = ParameterDirection.Input;
                    ////oledbParam[37].Value = AuthoSign;  
                    /////////Addition Ended : Santosh Shelar
                
                    oledbParam[51] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParam[51].Direction = ParameterDirection.Output;

                    //////Procedure Altered : Sunny Chauhan ///////////////////////

                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddEditCCDescription1RT", oledbParam);

                    ////// Message box parameter changed to [32] from [31] : Sunny Chauhan //////////////
                if (Convert.ToInt32(oledbParam[51].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParam[51].Value) == 2)
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
            //////////////////////////////Inserting in table CPV_CC_VERI_DESCRIPTION(Residence) 
            OleDbConnection oledbConn1 = new OleDbConnection(objCon.ConnectionString);
            oledbConn1.Open();
            OleDbTransaction oledbTrans1 = oledbConn1.BeginTransaction();
           
            try
            {
                 OleDbParameter[] oledbParamDesc = new OleDbParameter[23];

                oledbParamDesc[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamDesc[0].Direction = ParameterDirection.Input;
                 if (!(strTableToEditArray[0].Equals("1")))
                {
                    oledbParamDesc[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParamDesc[0].Value = "EDIT";

                }

                oledbParamDesc[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamDesc[1].Direction = ParameterDirection.Input;
                    oledbParamDesc[1].Value = CaseID;

                    oledbParamDesc[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamDesc[2].Direction = ParameterDirection.Input;
                    oledbParamDesc[2].Value = VerificationTypeID;

                    oledbParamDesc[3] = new OleDbParameter("@CONTACTABILITY", OleDbType.VarChar, 20);
                    oledbParamDesc[3].Direction = ParameterDirection.Input;
                    oledbParamDesc[3].Value = Contactability;

                    oledbParamDesc[4] = new OleDbParameter("@PROFILE", OleDbType.VarChar, 200);
                    oledbParamDesc[4].Direction = ParameterDirection.Input;
                    oledbParamDesc[4].Value = Profile;

                    oledbParamDesc[5] = new OleDbParameter("@REPUTATION", OleDbType.VarChar, 50);
                    oledbParamDesc[5].Direction = ParameterDirection.Input;
                    oledbParamDesc[5].Value = Reputation;

                    oledbParamDesc[6] = new OleDbParameter("@TIME_AT_CURR_RESIDANCE", OleDbType.VarChar, 15);
                    oledbParamDesc[6].Direction = ParameterDirection.Input;
                    oledbParamDesc[6].Value = TimeAtCurrResi;

                    oledbParamDesc[7] = new OleDbParameter("@INFO_REQUIRED", OleDbType.VarChar, 50);
                    oledbParamDesc[7].Direction = ParameterDirection.Input;
                    oledbParamDesc[7].Value = InfoRequired;

                    oledbParamDesc[8] = new OleDbParameter("@PRIORITY_CUSTOMER", OleDbType.VarChar, 10);
                    oledbParamDesc[8].Direction = ParameterDirection.Input;
                    oledbParamDesc[8].Value = PriorityCustomer;

                    oledbParamDesc[9] = new OleDbParameter("@ADRESS_CONFIRMATION", OleDbType.VarChar, 20);
                    oledbParamDesc[9].Direction = ParameterDirection.Input;
                    oledbParamDesc[9].Value = AddressConfirmation;

                    oledbParamDesc[10] = new OleDbParameter("@APPLICANT_AGE", OleDbType.VarChar, 50);
                    oledbParamDesc[10].Direction = ParameterDirection.Input;
                    oledbParamDesc[10].Value = AgeApproxOfApplicant;

                    oledbParamDesc[11] = new OleDbParameter("@MISMATCH_RESI_ADD", OleDbType.VarChar, 30);
                    oledbParamDesc[11].Direction = ParameterDirection.Input;
                    oledbParamDesc[11].Value = MismatchedInAddTelNo;

                    oledbParamDesc[12] = new OleDbParameter("@RECOMMENDATION", OleDbType.VarChar, 50);
                    oledbParamDesc[12].Direction = ParameterDirection.Input;
                    oledbParamDesc[12].Value = Recommendation;

                    oledbParamDesc[13] = new OleDbParameter("@ADDITIONAL_REMARK", OleDbType.VarChar, 250);
                    oledbParamDesc[13].Direction = ParameterDirection.Input;
                    oledbParamDesc[13].Value = AdditionalRemark;

                    oledbParamDesc[14] = new OleDbParameter("@TELE_CALLER_NAME", OleDbType.VarChar, 50);
                    oledbParamDesc[14].Direction = ParameterDirection.Input;
                    oledbParamDesc[14].Value = TeleCallerName;

                    oledbParamDesc[15] = new OleDbParameter("@BUSINESS_CONTACT_NO_EXTN", OleDbType.VarChar, 50);
                    oledbParamDesc[15].Direction = ParameterDirection.Input;
                    oledbParamDesc[15].Value = BusinessContactNoAndExtn;

                    oledbParamDesc[16] = new OleDbParameter("@FAMILY_MEMBERS", OleDbType.VarChar, 10);
                    oledbParamDesc[16].Direction = ParameterDirection.Input;
                    oledbParamDesc[16].Value = NumberOfResidentAtCurrentAddress;


                    oledbParamDesc[17] = new OleDbParameter("@CONFIRMATION_IF_APPLICANT_MET", OleDbType.VarChar, 50);
                    oledbParamDesc[17].Direction = ParameterDirection.Input;
                    oledbParamDesc[17].Value = ConfirmApplication;

                    oledbParamDesc[18] = new OleDbParameter("@TIME_AT_CURR_Y_M", OleDbType.VarChar, 10);
                    oledbParamDesc[18].Direction = ParameterDirection.Input;
                    oledbParamDesc[18].Value = TimeAtCurrResiYearMonth;

                    oledbParamDesc[19] = new OleDbParameter("@TPC_DETAILS", OleDbType.VarChar, 255);
                    oledbParamDesc[19].Direction = ParameterDirection.Input;
                    oledbParamDesc[19].Value = Details;
                    ////////Santosh Shelar : Start///////////////
                    oledbParamDesc[20] = new OleDbParameter("@SUPERVISOR_CODE", OleDbType.VarChar, 50);
                    oledbParamDesc[20].Direction = ParameterDirection.Input;
                    oledbParamDesc[20].Value = SupervisorCode;
               
                    oledbParamDesc[21] = new OleDbParameter("@CHANGE_IN_ADRESS", OleDbType.VarChar, 300);
                    oledbParamDesc[21].Direction = ParameterDirection.Input;
                    oledbParamDesc[21].Value = ChangeAddress;

                    ////oledbParamDesc[22] = new OleDbParameter("@vehicle_other", OleDbType.VarChar, 100);
                    ////oledbParamDesc[22].Direction = ParameterDirection.Input;
                    ////oledbParamDesc[22].Value = VEHICLE_OTHER;

                    ////oledbParamDesc[23] = new OleDbParameter("@bank_name", OleDbType.VarChar, 100);
                    ////oledbParamDesc[23].Direction = ParameterDirection.Input;
                    ////oledbParamDesc[23].Value = BankName;

                    ////oledbParamDesc[24] = new OleDbParameter("@name_society_board", OleDbType.VarChar, 100);
                    ////oledbParamDesc[24].Direction = ParameterDirection.Input;
                    ////oledbParamDesc[24].Value = NegativeCode;  
                    ////////Santosh Shelar : End/////////////////
                    
                    oledbParamDesc[22] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamDesc[22].Direction = ParameterDirection.Output;

                    OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.StoredProcedure, "spAddEditCCDescriptionRT", oledbParamDesc);

                if (Convert.ToInt32(oledbParamDesc[22].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParamDesc[22].Value) == 2)
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
            OleDbConnection oledbConn2 = new OleDbConnection(objCon.ConnectionString);
            oledbConn2.Open();
            OleDbTransaction oledbTrans2 = oledbConn2.BeginTransaction();
            //////////////////////////////////Inserting in table CPV_CC_VERI_OTHER_DETAILS(Residence) 
            try
            {
                OleDbParameter[] oledbParamOtherDetail = new OleDbParameter[8];

                oledbParamOtherDetail[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamOtherDetail[0].Direction = ParameterDirection.Input;
                 if (!(strTableToEditArray[2].Equals("1")))
                {
                    oledbParamOtherDetail[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParamOtherDetail[0].Value = "EDIT";

                }

                    oledbParamOtherDetail[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamOtherDetail[1].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[1].Value = CaseID;

                    oledbParamOtherDetail[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamOtherDetail[2].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[2].Value = VerificationTypeID;

                    oledbParamOtherDetail[3] = new OleDbParameter("@REL_WITH_APPLICANT", OleDbType.VarChar, 50);
                    oledbParamOtherDetail[3].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[3].Value = Relationship;

                    oledbParamOtherDetail[4] = new OleDbParameter("@PERMANENT_ADDRESS", OleDbType.VarChar, 255);
                    oledbParamOtherDetail[4].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[4].Value = PermanentAddress;

                    oledbParamOtherDetail[5] = new OleDbParameter("@applicant_home_country_phone", OleDbType.VarChar, 100);
                    oledbParamOtherDetail[5].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[5].Value = NameofApplicantConfirmedatgivenPhoneNo1;

                    oledbParamOtherDetail[6] = new OleDbParameter("@address_match", OleDbType.VarChar, 100);
                    oledbParamOtherDetail[6].Direction = ParameterDirection.Input;
                    oledbParamOtherDetail[6].Value = MisMatch; 

                    oledbParamOtherDetail[7] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamOtherDetail[7].Direction = ParameterDirection.Output;

                    OleDbHelper.ExecuteNonQuery(oledbTrans2, CommandType.StoredProcedure, "spAddEditCCVeriOtherDetailsRT", oledbParamOtherDetail);

                    if (Convert.ToInt32(oledbParamOtherDetail[7].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParamOtherDetail[7].Value) == 2)
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
            OleDbConnection oledbConn3 = new OleDbConnection(objCon.ConnectionString);
            oledbConn3.Open();
            OleDbTransaction oledbTrans3 = oledbConn3.BeginTransaction();
            //////////////////////////////Updating in table CPV_CC_CASE_DETAILS(Residence)
            try
            {
                OleDbParameter[] oledbParamCaseDetail = new OleDbParameter[4];


                oledbParamCaseDetail[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                oledbParamCaseDetail[0].Direction = ParameterDirection.Input;
                oledbParamCaseDetail[0].Value = CaseID;

                //oledbParamCaseDetail[1] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar, 300);
                //oledbParamCaseDetail[1].Direction = ParameterDirection.Input;
                //oledbParamCaseDetail[1].Value = ResiAddress;

                oledbParamCaseDetail[1] = new OleDbParameter("@RES_PIN_CODE", OleDbType.VarChar, 10);
                oledbParamCaseDetail[1].Direction = ParameterDirection.Input;
                oledbParamCaseDetail[1].Value = Pincode;

                oledbParamCaseDetail[2] = new OleDbParameter("@RES_LAND_MARK", OleDbType.VarChar, 50);
                oledbParamCaseDetail[2].Direction = ParameterDirection.Input;
                oledbParamCaseDetail[2].Value = LandmarkOberservered;

                //oledbParamCaseDetail[3] = new OleDbParameter("@DEPARTMENT", OleDbType.VarChar, 50);
                //oledbParamCaseDetail[3].Direction = ParameterDirection.Input;
                //oledbParamCaseDetail[3].Value = DeptOfApplicant;

                //oledbParamCaseDetail[3] = new OleDbParameter("@Is_Case_Complete", OleDbType.Char,1);
                //oledbParamCaseDetail[3].Direction = ParameterDirection.Input;
                //oledbParamCaseDetail[3].Value = IsCaseComp; 

                oledbParamCaseDetail[3] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                oledbParamCaseDetail[3].Direction = ParameterDirection.Output;


                OleDbHelper.ExecuteNonQuery(oledbTrans3, CommandType.StoredProcedure, "spEditCCCaseDetailsRT", oledbParamCaseDetail);

                if (Convert.ToInt32(oledbParamCaseDetail[3].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

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
            OleDbConnection oledbConn4 = new OleDbConnection(objCon.ConnectionString);
            oledbConn4.Open();
            OleDbTransaction oledbTrans4 = oledbConn4.BeginTransaction();
            //////////////////////////////////Inserting in table CPV_CC_VERI_DETAILS(Residence) 
            try
            {
                ///ARRAY INCREASED BY 2 FORM [13] TO [15] BY SUNNY CHAUHAN/////////
                OleDbParameter[] oledbParamVeriDetails = new OleDbParameter[16];


                oledbParamVeriDetails[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamVeriDetails[0].Direction = ParameterDirection.Input;
                 if (!(strTableToEditArray[3].Equals("1")))
                {
                    oledbParamVeriDetails[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParamVeriDetails[0].Value = "EDIT";

                }

                    oledbParamVeriDetails[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[1].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[1].Value = CaseID;

                    oledbParamVeriDetails[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[2].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[2].Value = VerificationTypeID;

                    oledbParamVeriDetails[3] = new OleDbParameter("@OVERALL_ASSESMENT", OleDbType.VarChar, 100);
                    oledbParamVeriDetails[3].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[3].Value = OverallAssessment;

                    oledbParamVeriDetails[4] = new OleDbParameter("@OVERALL_ASSESMENT_REASON", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[4].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[4].Value = ReasonsAssessment;

                    oledbParamVeriDetails[5] = new OleDbParameter("@SUPERVISOR_REMARKS", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[5].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[5].Value = SupervisorRemark;

                    oledbParamVeriDetails[6] = new OleDbParameter("@ANY_INFO", OleDbType.VarChar, 750);
                    oledbParamVeriDetails[6].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[6].Value = AnyOtherInfo;

                    oledbParamVeriDetails[7] = new OleDbParameter("@DECLINED_REASON", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[7].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[7].Value = DeclineReasons;

                    oledbParamVeriDetails[8] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 10);
                    oledbParamVeriDetails[8].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[8].Value = TeleVerificationResult;

                    oledbParamVeriDetails[9] = new OleDbParameter("@SUPERVISOR_ID", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[9].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[9].Value = SupervisorName;

                    oledbParamVeriDetails[10] = new OleDbParameter("@ADD_BY", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[10].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[10].Value = AddedBy;

                    oledbParamVeriDetails[11] = new OleDbParameter("@ADD_ON", OleDbType.DBTimeStamp);
                    oledbParamVeriDetails[11].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[11].Value = AddedOn;

                //////NEW ADDITION FOR INSERTING DATA SUNNY CHAUHAN : START /////////
                
                    oledbParamVeriDetails[12] = new OleDbParameter("@ACT_NUM_TYPE", OleDbType.VarChar,15);
                    oledbParamVeriDetails[12].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[12].Value = ACTNUMTYPE;

                    oledbParamVeriDetails[13] = new OleDbParameter("@ACTUAL_NUMBER", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[13].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[13].Value = ACTNUMBER;

                    oledbParamVeriDetails[14] = new OleDbParameter("@Docs", OleDbType.VarChar, 100);
                    oledbParamVeriDetails[14].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[14].Value = CPVAgentName;
                    
                //////////ADDITION ENDED : SUNNY CHAUHAN ///////////////////////////
                //////////PARAMETER VALUE CHANGED FROM [12] TO [14]
                    oledbParamVeriDetails[15] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamVeriDetails[15].Direction = ParameterDirection.Output;
                //////PROCEDURE ALTERED BY SUNNY CHAUHAN///////////////////////////
                    OleDbHelper.ExecuteNonQuery(oledbTrans4, CommandType.StoredProcedure, "spAddEditCCVeriDetailsRT", oledbParamVeriDetails);

                    if (Convert.ToInt32(oledbParamVeriDetails[15].Value) == 1)
                {
                    sRetVal = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParamVeriDetails[15].Value) == 2)
                {
                    sRetVal = "Record updated successfully.";
                }
                else
                {
                    sRetVal = "There is some error in Data entry .";

                }
               
                    oledbTrans4.Commit();
                    oledbConn4.Close();
            }
            catch (Exception ex)
            {
                oledbTrans4.Rollback();
                oledbConn4.Close();
                strError = ex.Message;
            }
            OleDbConnection oledbConn5 = new OleDbConnection(objCon.ConnectionString);
            oledbConn5.Open();
            OleDbTransaction oledbTrans5 = oledbConn5.BeginTransaction();
            try
            {
                //Start Insert into CASE_TRANSACTION_LOG -------------------
               

                OleDbParameter[] paramTransLog = new OleDbParameter[9];
                paramTransLog[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramTransLog[0].Direction = ParameterDirection.Input;
                paramTransLog[0].Value = CaseID;

                paramTransLog[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramTransLog[1].Direction = ParameterDirection.Input;
                paramTransLog[1].Value = VerificationTypeID;
                paramTransLog[2] = new OleDbParameter("@USER_ID", OleDbType.VarChar, 15);
                paramTransLog[2].Direction = ParameterDirection.Input;
                paramTransLog[2].Value = UserId;

                paramTransLog[3] = new OleDbParameter("@TRANS_START", OleDbType.DBTimeStamp);
                paramTransLog[3].Direction = ParameterDirection.Input;
                paramTransLog[3].Value = TransStart;
                paramTransLog[4] = new OleDbParameter("@TRANS_END", OleDbType.DBTimeStamp);
                paramTransLog[4].Direction = ParameterDirection.Input;
                paramTransLog[4].Value = TransEnd;
                paramTransLog[5] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 15);
                paramTransLog[5].Direction = ParameterDirection.Input;
                paramTransLog[5].Value = CentreId;
                paramTransLog[6] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                paramTransLog[6].Direction = ParameterDirection.Input;
                paramTransLog[6].Value = ProductId;
                paramTransLog[7] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
                paramTransLog[7].Direction = ParameterDirection.Input;
                paramTransLog[7].Value = ClientId;
                paramTransLog[8] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramTransLog[8].Direction = ParameterDirection.Output;



                OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddCaseTranscation", paramTransLog);

                //End  Insert into CASE_TRANSACTION_LOG --------------------

                //Update CPV_CC_Case_details with status 'Y' ---------------

               
                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////


                oledbTrans5.Commit();
                oledbConn5.Close();
                
            }
            catch (Exception ex)
            {
                oledbTrans5.Rollback();
                oledbConn5.Close();
                strError = ex.Message;

            }
            //Update CPV_CC_Case_details with status 'Y' ---------------

            OleDbConnection oledbConn6 = new OleDbConnection(objCon.ConnectionString);
            oledbConn6.Open();
            OleDbTransaction oledbTrans6 = oledbConn6.BeginTransaction();
            try
            {


                OleDbParameter[] isVerificationCompleted = new OleDbParameter[2];

                isVerificationCompleted[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                isVerificationCompleted[0].Direction = ParameterDirection.Input;
                isVerificationCompleted[0].Value = CaseID;
                

                isVerificationCompleted[1] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                isVerificationCompleted[1].Direction = ParameterDirection.Output;


                OleDbHelper.ExecuteNonQuery(oledbTrans6, CommandType.StoredProcedure, "spIsCCVerificationComplete", isVerificationCompleted);

                if (Convert.ToInt32(isVerificationCompleted[1].Value) == 1)
                {
                    sRetVal = "Case verification data entry completed.";

                }


                oledbTrans6.Commit();
                oledbConn6.Close();
            }
            catch (Exception ex)
            {
                oledbTrans6.Rollback();
                oledbConn6.Close();
                strError = ex.Message;
            }
        }
        
        catch 
        {
 
        }
        Error = strError;
        return sRetVal;
    }
    #endregion InsertResidenceVerificationDetails

    #region InsertBusinessVerificationDetails
    public string InsertBusinessVerificationDetails()
    {
        
        string sMsg = "";
        string strError = "";
        try
        {
            //This Checks that wether the vales to be inserted in BT is in Update mode or Insert mode.
            OleDbConnection oledbConn0 = new OleDbConnection(objCon.ConnectionString);
            oledbConn0.Open();
            OleDbTransaction oledbTrans0 = oledbConn0.BeginTransaction();
            OleDbParameter[] oledbParam0 = new OleDbParameter[3];
            oledbParam0[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            oledbParam0[0].Value = CaseID;
            oledbParam0[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
            oledbParam0[1].Value = VerificationTypeID;
            oledbParam0[2] = new OleDbParameter("@TableToEdit", OleDbType.VarChar, 15);
            oledbParam0[2].Direction = ParameterDirection.Output;


            OleDbHelper.ExecuteNonQuery(oledbTrans0, CommandType.StoredProcedure, "spTableToEdit", oledbParam0);
            string[] strTableToEditArray = oledbParam0[2].Value.ToString().Split(',');


            OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
            oledbConn.Open();
            OleDbTransaction oledbTrans = oledbConn.BeginTransaction();


            //////////////////////////////Inserting in table CPV_CC_VERI_DESCRIPTION1(Business)

            try
            {
                /////Array increased by 1 [36] [37] for variable DIRECTORY_CHK_ADD_REASON : Sunny Chauhan ///////////
                OleDbParameter[] oledbParam = new OleDbParameter[39];
                oledbParam[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParam[0].Direction = ParameterDirection.Input;
                if (!(strTableToEditArray[1].Equals("1")))
                {
                    oledbParam[0].Value = "ADD";
                }
                else
                {
                    oledbParam[0].Value = "EDIT";
                }
                
                    oledbParam[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParam[1].Direction = ParameterDirection.Input;
                    oledbParam[1].Value = CaseID;

                    oledbParam[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParam[2].Direction = ParameterDirection.Input;
                    oledbParam[2].Value = VerificationTypeID;

                    oledbParam[3] = new OleDbParameter("@CONTACTED_PERSON_NAME", OleDbType.VarChar, 100);
                    oledbParam[3].Direction = ParameterDirection.Input;
                    oledbParam[3].Value = PersonContacted;

                    oledbParam[4] = new OleDbParameter("@INCOME_DOC_SUBMITTED_WITH_APLICATION", OleDbType.VarChar, 20);
                    oledbParam[4].Direction = ParameterDirection.Input;
                    oledbParam[4].Value = IncomeDocsSubmittedWithApplication;

                    oledbParam[5] = new OleDbParameter("@TIME_AT_CURRENT_EMPLOYMENT", OleDbType.VarChar, 50);
                    oledbParam[5].Direction = ParameterDirection.Input;
                    oledbParam[5].Value = TimeAtCurrEmpl;

                    oledbParam[6] = new OleDbParameter("@OFFICE_EXT", OleDbType.VarChar, 5);
                    oledbParam[6].Direction = ParameterDirection.Input;
                    oledbParam[6].Value = ExtnNo;

                    oledbParam[7] = new OleDbParameter("@DESIGNATION", OleDbType.VarChar, 100);
                    oledbParam[7].Direction = ParameterDirection.Input;
                    oledbParam[7].Value = AppDesignation;

                    oledbParam[8] = new OleDbParameter("@DOB_APPLICANT", OleDbType.VarChar, 50);
                    oledbParam[8].Direction = ParameterDirection.Input;
                    oledbParam[8].Value = DOBofApplicant;

                    oledbParam[9] = new OleDbParameter("@APPLICANT_IS_AVAILABLE_AT", OleDbType.VarChar, 20);
                    oledbParam[9].Direction = ParameterDirection.Input;
                    oledbParam[9].Value = ApplicantAvailableAt;

                    oledbParam[10] = new OleDbParameter("@NEW_DETAILS_OBTAINED", OleDbType.VarChar, 100);
                    oledbParam[10].Direction = ParameterDirection.Input;
                    oledbParam[10].Value = NewDetailsObt;

                    oledbParam[11] = new OleDbParameter("@SPECIAL_INSTRUCTIONS", OleDbType.VarChar, 255);
                    oledbParam[11].Direction = ParameterDirection.Input;
                    oledbParam[11].Value = SpecialInstructions;

                    oledbParam[12] = new OleDbParameter("@IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA", OleDbType.VarChar, 50);
                    oledbParam[12].Direction = ParameterDirection.Input;
                    oledbParam[12].Value = IsOfficeAreaIsNegativeArea;

                    oledbParam[13] = new OleDbParameter("@BUSINESS_CONTACT_EXTN", OleDbType.VarChar, 50);
                    oledbParam[13].Direction = ParameterDirection.Input;
                    oledbParam[13].Value = BusinessExtnNo;

                    oledbParam[14] = new OleDbParameter("@APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO", OleDbType.VarChar, 20);
                    oledbParam[14].Direction = ParameterDirection.Input;
                    oledbParam[14].Value = NameOfApplicantConfirmedAtGivenPhoneNo;
                
                    oledbParam[15] = new OleDbParameter("@CHANGE_IN_PHONE_NO", OleDbType.VarChar, 50);
                    oledbParam[15].Direction = ParameterDirection.Input;
                    oledbParam[15].Value = ChangeInPhoneNumber;

                    oledbParam[16] = new OleDbParameter("@REASON_FOR_CHANGE", OleDbType.VarChar, 25);
                    oledbParam[16].Direction = ParameterDirection.Input;
                    oledbParam[16].Value = ReasonForChange;

                    oledbParam[17] = new OleDbParameter("@YCR", OleDbType.VarChar, 50);
                    oledbParam[17].Direction = ParameterDirection.Input;
                    oledbParam[17].Value = YCR;

                    oledbParam[18] = new OleDbParameter("@SEGMENTATION", OleDbType.VarChar, 15);
                    oledbParam[18].Direction = ParameterDirection.Input;
                    oledbParam[18].Value = Segmentation;

                    oledbParam[19] = new OleDbParameter("@DIRECTORY_CHECK", OleDbType.VarChar, 100);
                    oledbParam[19].Direction = ParameterDirection.Input;
                    oledbParam[19].Value = DirectoryCheck;

                    oledbParam[20] = new OleDbParameter("@SPK_TO", OleDbType.VarChar, 15);
                    oledbParam[20].Direction = ParameterDirection.Input;
                    oledbParam[20].Value = SpkTo;

                    oledbParam[21] = new OleDbParameter("@RESIDANCE_IS", OleDbType.VarChar, 20);
                    oledbParam[21].Direction = ParameterDirection.Input;
                    oledbParam[21].Value = ResidenceIs;

                    oledbParam[22] = new OleDbParameter("@MAILING_ADDRESS", OleDbType.VarChar, 255);
                    oledbParam[22].Direction = ParameterDirection.Input;
                    oledbParam[22].Value = MailingAddress;

                    oledbParam[23] = new OleDbParameter("@RESI_COMOFF_OWNED", OleDbType.VarChar, 20);
                    oledbParam[23].Direction = ParameterDirection.Input;
                    oledbParam[23].Value = ResiCumOffice;

                    oledbParam[24] = new OleDbParameter("@IS_RESI_ADD_IS_IN_NEGATIVE_AREA", OleDbType.VarChar, 50);
                    oledbParam[24].Direction = ParameterDirection.Input;
                    oledbParam[24].Value = IsResidenceAddressIsNegativeArea;

                    oledbParam[25] = new OleDbParameter("@DESIG_AND_DEPT_OF_CONTACTED_PERSON", OleDbType.VarChar, 50);
                    oledbParam[25].Direction = ParameterDirection.Input;
                    oledbParam[25].Value = DesigDeptOfContactedPerson;

                    oledbParam[26] = new OleDbParameter("@NATURE_BUSINESS_RESI_CUM_OFF", OleDbType.VarChar, 200);
                    oledbParam[26].Direction = ParameterDirection.Input;
                    oledbParam[26].Value = NatureOfBusiness;

                    oledbParam[27] = new OleDbParameter("@CALLED_UP_ON_OFFICE_TEL_NO", OleDbType.VarChar, 50);
                    oledbParam[27].Direction = ParameterDirection.Input;
                    oledbParam[27].Value = CalledUpOnOffTelNo;

                    oledbParam[28] = new OleDbParameter("@NO_OF_YEARS_AT_CURRENT_EMPLOYMENT", OleDbType.VarChar, 50);
                    oledbParam[28].Direction = ParameterDirection.Input;
                    oledbParam[28].Value = NoOfYearsAtCurrentEmployment;

                    oledbParam[29] = new OleDbParameter("@TELE_COMMENTS", OleDbType.VarChar, 50);
                    oledbParam[29].Direction = ParameterDirection.Input;
                    oledbParam[29].Value = TeleComments;

                    oledbParam[30] = new OleDbParameter("@TIME_AT_CURRENT_EMPL_Y_M", OleDbType.VarChar, 50);
                    oledbParam[30].Direction = ParameterDirection.Input;
                    oledbParam[30].Value = TimeAtCurrentEmplYearMonth;

                    oledbParam[31] = new OleDbParameter("@COMPANY_NAME", OleDbType.VarChar, 100);
                    oledbParam[31].Direction = ParameterDirection.Input;
                    oledbParam[31].Value = NameOfCompany;

                    oledbParam[32] = new OleDbParameter("@LAND_MARK_OBSERVED", OleDbType.VarChar, 25);
                    oledbParam[32].Direction = ParameterDirection.Input;
                    oledbParam[32].Value = LandmarkOberservered;

                    oledbParam[33] = new OleDbParameter("@CURRENT_RESIDENCE_PERIOD", OleDbType.VarChar, 50);
                    oledbParam[33].Direction = ParameterDirection.Input;
                    oledbParam[33].Value = CurrentResidencePeriod;

                    oledbParam[34] = new OleDbParameter("@APP_QUALIFICATION", OleDbType.VarChar, 50);
                    oledbParam[34].Direction = ParameterDirection.Input;
                    oledbParam[34].Value = ApplicantQualification;

                    ///////Added By Sunny Chauhan : Start //////////////////
                    oledbParam[35] = new OleDbParameter("@No_Reason", OleDbType.VarChar, 150);
                    oledbParam[35].Direction = ParameterDirection.Input;
                    oledbParam[35].Value = NoReason;

                    oledbParam[36] = new OleDbParameter("@Appli_Dept", OleDbType.VarChar, 100);
                    oledbParam[36].Direction = ParameterDirection.Input;
                    oledbParam[36].Value = DeptOfApplicant;

                    oledbParam[37] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 100);
                    oledbParam[37].Direction = ParameterDirection.Input;
                    oledbParam[37].Value = DirCheck;

                    ////oledbParam[38] = new OleDbParameter("@AuthoSign", OleDbType.VarChar, 100);
                    ////oledbParam[38].Direction = ParameterDirection.Input;
                    ////oledbParam[38].Value = AuthoSign;  
                    ///////Addition Ended : Sunny Chauhan //////////////////

                    oledbParam[38] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParam[38].Direction = ParameterDirection.Output;
                    
                    //////Modification in Procedure done by : Sunny Chauhan//////////////////
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.StoredProcedure, "spAddEditCCDescription1BT", oledbParam);
                
                ///////Message output changed to [36] from [35] : Sunny Chauhan//////////////////
                if (Convert.ToInt32(oledbParam[38].Value) == 1)
                {
                    sMsg = " Record added successfully .";

                }
                else if (Convert.ToInt32(oledbParam[38].Value) == 2)
                {
                    sMsg = "Record updated successfully.";
                }
                else
                {
                    sMsg = "There is some error in Data entry.";
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
            OleDbConnection oledbConn1 = new OleDbConnection(objCon.ConnectionString);
            oledbConn1.Open();
            OleDbTransaction oledbTrans1 = oledbConn1.BeginTransaction();

            //////////////////////////////Inserting in table CPV_CC_VERI_DESCRIPTION(Business)
            try
            {
                
                OleDbParameter[] oledbParamDesc = new OleDbParameter[29];
                oledbParamDesc[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamDesc[0].Direction = ParameterDirection.Input;
                if (!(strTableToEditArray[0].Equals("1")))
                {
                    oledbParamDesc[0].Value = "ADD";

                }
                else
                {
                    oledbParamDesc[0].Value = "EDIT";

                }



                    oledbParamDesc[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamDesc[1].Direction = ParameterDirection.Input;
                    oledbParamDesc[1].Value = CaseID;

                    oledbParamDesc[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamDesc[2].Direction = ParameterDirection.Input;
                    oledbParamDesc[2].Value = VerificationTypeID;

                    oledbParamDesc[3] = new OleDbParameter("@QUALIFICATION", OleDbType.VarChar, 50);
                    oledbParamDesc[3].Direction = ParameterDirection.Input;
                    oledbParamDesc[3].Value = Qualification;

                    oledbParamDesc[4] = new OleDbParameter("@CONTACTABILITY", OleDbType.VarChar, 20);
                    oledbParamDesc[4].Direction = ParameterDirection.Input;
                    oledbParamDesc[4].Value = Contactability;

                    oledbParamDesc[5] = new OleDbParameter("@PROFILE", OleDbType.VarChar, 200);
                    oledbParamDesc[5].Direction = ParameterDirection.Input;
                    oledbParamDesc[5].Value = Profile;

                    oledbParamDesc[6] = new OleDbParameter("@REPUTATION", OleDbType.VarChar, 50);
                    oledbParamDesc[6].Direction = ParameterDirection.Input;
                    oledbParamDesc[6].Value = Reputation;

                    oledbParamDesc[7] = new OleDbParameter("@INFO_REQUIRED", OleDbType.VarChar, 50);
                    oledbParamDesc[7].Direction = ParameterDirection.Input;
                    oledbParamDesc[7].Value = InfoRequired;

                    oledbParamDesc[8] = new OleDbParameter("@PRIORITY_CUSTOMER", OleDbType.VarChar, 10);
                    oledbParamDesc[8].Direction = ParameterDirection.Input;
                    oledbParamDesc[8].Value = PriorityCustomer;


                    oledbParamDesc[9] = new OleDbParameter("@ADRESS_CONFIRMATION", OleDbType.VarChar, 20);
                    oledbParamDesc[9].Direction = ParameterDirection.Input;
                    oledbParamDesc[9].Value = AddressConfirmation;

                    oledbParamDesc[10] = new OleDbParameter("@APPLICANT_AGE", OleDbType.VarChar, 50);
                    oledbParamDesc[10].Direction = ParameterDirection.Input;
                    oledbParamDesc[10].Value = AgeApproxOfApplicant;

                    oledbParamDesc[11] = new OleDbParameter("@TIME_AT_CURR_Y_M", OleDbType.VarChar, 10);
                    oledbParamDesc[11].Direction = ParameterDirection.Input;
                    oledbParamDesc[11].Value = TimeAtCurrResiYearMonth;

                    oledbParamDesc[12] = new OleDbParameter("@RECOMMENDATION", OleDbType.VarChar, 50);
                    oledbParamDesc[12].Direction = ParameterDirection.Input;
                    oledbParamDesc[12].Value = Recommendation;

                    oledbParamDesc[13] = new OleDbParameter("@CONFIRMATION_IF_APPLICANT_MET", OleDbType.VarChar, 50);
                    oledbParamDesc[13].Direction = ParameterDirection.Input;
                    oledbParamDesc[13].Value = ConfirmApplication;

                    oledbParamDesc[14] = new OleDbParameter("@TELE_CALLER_NAME", OleDbType.VarChar, 50);
                    oledbParamDesc[14].Direction = ParameterDirection.Input;
                    oledbParamDesc[14].Value = TeleCallerName;

                    oledbParamDesc[15] = new OleDbParameter("@FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION", OleDbType.VarChar, 50);
                    oledbParamDesc[15].Direction = ParameterDirection.Input;
                    oledbParamDesc[15].Value = ForSelfEmployedTypeOfOrganisation;

                    oledbParamDesc[16] = new OleDbParameter("@EMP_PERMANENT_TEMP", OleDbType.VarChar, 50);
                    oledbParamDesc[16].Direction = ParameterDirection.Input;
                    oledbParamDesc[16].Value = EmpPermanentTemp;

                    oledbParamDesc[17] = new OleDbParameter("@EMP_CONFIRMED_OR_NOT_CONFIRMED", OleDbType.VarChar, 50);
                    oledbParamDesc[17].Direction = ParameterDirection.Input;
                    oledbParamDesc[17].Value = EmpConfirmedNotConfirmed;

                    oledbParamDesc[18] = new OleDbParameter("@APP_DOB_APPROX_AGE", OleDbType.VarChar, 50);
                    oledbParamDesc[18].Direction = ParameterDirection.Input;
                    oledbParamDesc[18].Value = AppDOBApproxAge;

                    oledbParamDesc[19] = new OleDbParameter("@RSIDENCE_PHONE_NO", OleDbType.VarChar, 50);
                    oledbParamDesc[19].Direction = ParameterDirection.Input;
                    oledbParamDesc[19].Value = ResidencePhoneNo;

                    oledbParamDesc[20] = new OleDbParameter("@OTHER_CONTACTED_DESIGNATION", OleDbType.VarChar, 50);
                    oledbParamDesc[20].Direction = ParameterDirection.Input;
                    oledbParamDesc[20].Value = DesignationOfOtherContacted;

                    oledbParamDesc[21] = new OleDbParameter("@OTHER_NATURE_OF_BUSINESS", OleDbType.VarChar, 100);
                    oledbParamDesc[21].Direction = ParameterDirection.Input;
                    oledbParamDesc[21].Value = OthersNatureOfBusiness;

                //////////add by santosh shelar 12-09-08////////////////////////
                    oledbParamDesc[22] = new OleDbParameter("@Other_Nature_Buss", OleDbType.VarChar, 100);
                    oledbParamDesc[22].Direction = ParameterDirection.Input;
                    oledbParamDesc[22].Value = OthNatureBuss; 

                    oledbParamDesc[23] = new OleDbParameter("@ADDITIONAL_REMARK", OleDbType.VarChar, 250);
                    oledbParamDesc[23].Direction = ParameterDirection.Input;
                    oledbParamDesc[23].Value = AdditionalRemark;

                    oledbParamDesc[24] = new OleDbParameter("@EMPLOYERS_NAME", OleDbType.VarChar, 100);
                    oledbParamDesc[24].Direction = ParameterDirection.Input;
                    oledbParamDesc[24].Value = EmployersName;
                    /////////Santosh Shelar : Start///////////////
                    oledbParamDesc[25] = new OleDbParameter("@CHANGE_IN_ADRESS", OleDbType.VarChar, 800);
                    oledbParamDesc[25].Direction = ParameterDirection.Input;
                    oledbParamDesc[25].Value = ChangeAddress;

                    oledbParamDesc[26] = new OleDbParameter("@MISMATCH_RESI_ADD", OleDbType.VarChar, 100);
                    oledbParamDesc[26].Direction = ParameterDirection.Input;
                    oledbParamDesc[26].Value = MISMATCH_RESI_ADD;   
                    /////////Santosh Shelar : End/////////////////
                    ////////add by kamal matekar for resi add///////////////
                    oledbParamDesc[27] = new OleDbParameter("@VEHICLE_OTHER", OleDbType.VarChar, 100);
                    oledbParamDesc[27].Direction = ParameterDirection.Input;
                    oledbParamDesc[27].Value = VEHICLE_OTHER;    

                    oledbParamDesc[28] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamDesc[28].Direction = ParameterDirection.Output;

                    //////////Procedure altered by Sunny Chauhan////////////////////////////////////////

                    OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.StoredProcedure, "spAddEditCCDescriptionBT", oledbParamDesc);
                    if (Convert.ToInt32(oledbParamDesc[28].Value) == 1)
                {
                    sMsg = " Record added successfully .";

                }
                else if (Convert.ToInt32(oledbParamDesc[28].Value) == 2)
                {
                    sMsg = "Record updated successfully.";
                }
                else
                {
                    sMsg = "There is some error in Data entry.";
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
            OleDbConnection oledbConn2 = new OleDbConnection(objCon.ConnectionString);
            oledbConn2.Open();
            OleDbTransaction oledbTrans2 = oledbConn2.BeginTransaction();
            try
            {
                //////////////////////////////////Inserting in table CPV_CC_VERI_OTHER_DETAILS(Business) 

                OleDbParameter[] oledbParamOtherBDetail = new OleDbParameter[10];

                oledbParamOtherBDetail[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamOtherBDetail[0].Direction = ParameterDirection.Input;
                 if (!(strTableToEditArray[2].Equals("1")))
                {
                    oledbParamOtherBDetail[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParamOtherBDetail[0].Value = "EDIT";

                }

                    oledbParamOtherBDetail[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamOtherBDetail[1].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[1].Value = CaseID;

                    oledbParamOtherBDetail[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamOtherBDetail[2].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[2].Value = VerificationTypeID;

                    oledbParamOtherBDetail[3] = new OleDbParameter("@PERMANENT_ADDRESS", OleDbType.VarChar, 255);
                    oledbParamOtherBDetail[3].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[3].Value = PermanentAddress;

                    oledbParamOtherBDetail[4] = new OleDbParameter("@REL_WITH_APPLICANT", OleDbType.VarChar, 50);
                    oledbParamOtherBDetail[4].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[4].Value = Relationship;

                    oledbParamOtherBDetail[5] = new OleDbParameter("@OTHERS_DESIGNATION", OleDbType.VarChar, 50);
                    oledbParamOtherBDetail[5].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[5].Value = OtherDesignation;

                    oledbParamOtherBDetail[6] = new OleDbParameter("@ADDRESS_MATCH", OleDbType.VarChar, 300);
                    oledbParamOtherBDetail[6].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[6].Value = AppResiAdd;

                    oledbParamOtherBDetail[7] = new OleDbParameter("@applicant_home_country_phone", OleDbType.VarChar, 100);
                    oledbParamOtherBDetail[7].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[7].Value = NameofApplicantConfirmedatgivenPhoneNo1;

                    oledbParamOtherBDetail[8] = new OleDbParameter("@IS_RESIDANT", OleDbType.VarChar, 100);
                    oledbParamOtherBDetail[8].Direction = ParameterDirection.Input;
                    oledbParamOtherBDetail[8].Value = MisMatch;   

                    oledbParamOtherBDetail[9] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamOtherBDetail[9].Direction = ParameterDirection.Output;

                 
                OleDbHelper.ExecuteNonQuery(oledbTrans2, CommandType.StoredProcedure, "spAddEditCCVeriOtherDetailsBT", oledbParamOtherBDetail);

                if (Convert.ToInt32(oledbParamOtherBDetail[9].Value) == 1)
                {
                    sMsg = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParamOtherBDetail[9].Value) == 2)
                {
                    sMsg = "Record updated successfully.";
                }
                else
                {
                    sMsg = "There is some error in Data entry .";

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
            OleDbConnection oledbConn3 = new OleDbConnection(objCon.ConnectionString);
            oledbConn3.Open();
            OleDbTransaction oledbTrans3 = oledbConn3.BeginTransaction();
            try
            {
                //////////////////////////////Updating in table CPV_CC_CASE_DETAILS(Business)
                OleDbParameter[] oledbParamBCaseDetail = new OleDbParameter[3];


                oledbParamBCaseDetail[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                oledbParamBCaseDetail[0].Direction = ParameterDirection.Input;
                oledbParamBCaseDetail[0].Value = CaseID;

                //oledbParamBCaseDetail[1] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar, 300);
                //oledbParamBCaseDetail[1].Direction = ParameterDirection.Input;
                //oledbParamBCaseDetail[1].Value = OfficeAddress;

                //oledbParamBCaseDetail[2] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar, 100);
                //oledbParamBCaseDetail[2].Direction = ParameterDirection.Input;
                //oledbParamBCaseDetail[2].Value = ResiAddress;

                //oledbParamBCaseDetail[1] = new OleDbParameter("@DEPARTMENT", OleDbType.VarChar, 50);
                //oledbParamBCaseDetail[1].Direction = ParameterDirection.Input;
                //oledbParamBCaseDetail[1].Value = DeptOfApplicant;

                //oledbParamBCaseDetail[4] = new OleDbParameter("@RES_PHONE", OleDbType.VarChar, 50);
                //oledbParamBCaseDetail[4].Direction = ParameterDirection.Input;
                //oledbParamBCaseDetail[4].Value = ResiPhone;

                oledbParamBCaseDetail[1] = new OleDbParameter("@DESIGNATION", OleDbType.VarChar, 50);
                oledbParamBCaseDetail[1].Direction = ParameterDirection.Input;
                oledbParamBCaseDetail[1].Value = Designation;

                //oledbParamBCaseDetail[6] = new OleDbParameter("@OFF_PHONE", OleDbType.VarChar, 30);
                //oledbParamBCaseDetail[6].Direction = ParameterDirection.Input;
                //oledbParamBCaseDetail[6].Value = OfficePhone;

                oledbParamBCaseDetail[2] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                oledbParamBCaseDetail[2].Direction = ParameterDirection.Output;

                OleDbHelper.ExecuteNonQuery(oledbTrans3, CommandType.StoredProcedure, "spEditCCCaseDetailsBT", oledbParamBCaseDetail);

                if (Convert.ToInt32(oledbParamBCaseDetail[2].Value) == 1)
                {
                    sMsg = "Record added successfully.";

                }
                else
                {
                    sMsg = "There is some error in Data entry .";

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
            OleDbConnection oledbConn4 = new OleDbConnection(objCon.ConnectionString);
            oledbConn4.Open();
            OleDbTransaction oledbTrans4 = oledbConn4.BeginTransaction();


            //////////////////////////////////Inserting in table CPV_CC_VERI_DETAILS(Business) 
            try
            {
                //////ARRAY LENGTH CHANGED FROM [11] TO [13] : SUNNY CHAUHAN/////////
                OleDbParameter[] oledbParamVeriDetails = new OleDbParameter[15];

                oledbParamVeriDetails[0] = new OleDbParameter("@OperationType", OleDbType.VarChar, 10);
                oledbParamVeriDetails[0].Direction = ParameterDirection.Input;
                if (!(strTableToEditArray[3].Equals("1")))
                {
                    oledbParamVeriDetails[0].Value = "ADD";
                    
                }
                else
                
                {
                    oledbParamVeriDetails[0].Value = "EDIT";

                }

                    oledbParamVeriDetails[1] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[1].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[1].Value = CaseID;

                    oledbParamVeriDetails[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[2].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[2].Value = VerificationTypeID;

                    oledbParamVeriDetails[3] = new OleDbParameter("@SUPERVISOR_REMARKS", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[3].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[3].Value = SupervisorRemark;

                    oledbParamVeriDetails[4] = new OleDbParameter("@ANY_INFO", OleDbType.VarChar, 750);
                    oledbParamVeriDetails[4].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[4].Value = AnyOtherInfo;

                    oledbParamVeriDetails[5] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 10);
                    oledbParamVeriDetails[5].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[5].Value = TeleVerificationResult;

                    oledbParamVeriDetails[6] = new OleDbParameter("@ADD_BY", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[6].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[6].Value = AddedBy;

                    oledbParamVeriDetails[7] = new OleDbParameter("@ADD_DATE", OleDbType.DBTimeStamp);
                    oledbParamVeriDetails[7].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[7].Value = AddedOn;

                    oledbParamVeriDetails[8] = new OleDbParameter("@OVERALL_ASSESMENT", OleDbType.VarChar, 100);
                    oledbParamVeriDetails[8].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[8].Value = OverallAssessment;

                    oledbParamVeriDetails[9] = new OleDbParameter("@OVERALL_ASSESMENT_REASON", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[9].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[9].Value = ReasonsAssessment;

                /////////ADDED BY SUNNY CHAUHAN : START///////////////////////////////////////

                    oledbParamVeriDetails[10] = new OleDbParameter("@ACTNUMBER", OleDbType.VarChar, 255);
                    oledbParamVeriDetails[10].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[10].Value = ACTNUMTYPE;

                    oledbParamVeriDetails[11] = new OleDbParameter("@ACTNUMTYPE", OleDbType.VarChar, 15);
                    oledbParamVeriDetails[11].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[11].Value = ACTNUMBER;
                
                    ////////////////add by santosh shelar add declened reason in btv 25-08-08////////////////////
                    oledbParamVeriDetails[12] = new OleDbParameter("@Declined_Reason", OleDbType.VarChar, 300);
                    oledbParamVeriDetails[12].Direction = ParameterDirection.Input;
                    oledbParamVeriDetails[12].Value = DeclineReasons;
                
                
                    oledbParamVeriDetails[13] = new OleDbParameter("@SUPERVISOR_ID", OleDbType.VarChar, 50);
                    oledbParamVeriDetails[13].Direction = ParameterDirection.Input;
                     //commented by kamal matekar 
                    //oledbParamVeriDetails[13].Value = strSUPER_ID; 
                    oledbParamVeriDetails[13].Value = SupervisorName; 

                ////////ADDITION ENDED : SUNNY CHAUHAN///////////////////////////////////////

                    oledbParamVeriDetails[14] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                    oledbParamVeriDetails[14].Direction = ParameterDirection.Output;
                /////////PROCEDURE ALTERED BY SUNNY CHAUHAN////////////////
                    OleDbHelper.ExecuteNonQuery(oledbTrans4, CommandType.StoredProcedure, "spAddEditCCVeriDetailsBT", oledbParamVeriDetails);

                if (Convert.ToInt32(oledbParamVeriDetails[14].Value) == 1)
                {
                    sMsg = "Record added successfully.";

                }
                else if (Convert.ToInt32(oledbParamVeriDetails[14].Value) == 2)
                {
                    sMsg = "Record updated successfully.";
                }
                else
                {
                    sMsg = "There is some error in Data entry .";

                }
                
                oledbTrans4.Commit();
                oledbConn4.Close();

                
            }
            catch (Exception ex)
            {
                oledbTrans4.Rollback();
                oledbConn4.Close();
                strError = ex.Message;
            }
            //Start Insert into CASE_TRANSACTION_LOG -------------------
            
            OleDbConnection oledbConn5 = new OleDbConnection(objCon.ConnectionString);
            oledbConn5.Open();
            OleDbTransaction oledbTrans5 = oledbConn5.BeginTransaction();
            try
            {
                //Start Insert into CASE_TRANSACTION_LOG -------------------


                OleDbParameter[] paramTransLog = new OleDbParameter[9];
                paramTransLog[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramTransLog[0].Direction = ParameterDirection.Input;
                paramTransLog[0].Value = CaseID;
                paramTransLog[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
                paramTransLog[1].Direction = ParameterDirection.Input;
                paramTransLog[1].Value = VerificationTypeID;
                paramTransLog[2] = new OleDbParameter("@USER_ID", OleDbType.VarChar, 15);
                paramTransLog[2].Direction = ParameterDirection.Input;
                paramTransLog[2].Value = UserId;

                paramTransLog[3] = new OleDbParameter("@TRANS_START", OleDbType.DBTimeStamp);
                paramTransLog[3].Direction = ParameterDirection.Input;
                paramTransLog[3].Value = TransStart;
                paramTransLog[4] = new OleDbParameter("@TRANS_END", OleDbType.DBTimeStamp);
                paramTransLog[4].Direction = ParameterDirection.Input;
                paramTransLog[4].Value = TransEnd;
                paramTransLog[5] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 15);
                paramTransLog[5].Direction = ParameterDirection.Input;
                paramTransLog[5].Value = CentreId;
                paramTransLog[6] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                paramTransLog[6].Direction = ParameterDirection.Input;
                paramTransLog[6].Value = ProductId;
                paramTransLog[7] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
                paramTransLog[7].Direction = ParameterDirection.Input;
                paramTransLog[7].Value = ClientId;
                paramTransLog[8] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                paramTransLog[8].Direction = ParameterDirection.Output;



                OleDbHelper.ExecuteNonQuery(oledbTrans5, CommandType.StoredProcedure, "spAddCaseTranscation", paramTransLog);

                //End  Insert into CASE_TRANSACTION_LOG --------------------
                //Update CPV_CC_Case_details with status 'Y' ---------------
                
                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////


                oledbTrans5.Commit();
                oledbConn5.Close();
             
            }
            catch (Exception ex)
            {
                oledbTrans5.Rollback();
                oledbConn5.Close();
                strError = ex.Message;

            }
            //Update CPV_CC_Case_details with status 'Y' ---------------

            OleDbConnection oledbConn6 = new OleDbConnection(objCon.ConnectionString);
            oledbConn6.Open();
            OleDbTransaction oledbTrans6 = oledbConn6.BeginTransaction();
            try
            {


                OleDbParameter[] isVerificationCompleted = new OleDbParameter[2];

                isVerificationCompleted[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                isVerificationCompleted[0].Direction = ParameterDirection.Input;
                isVerificationCompleted[0].Value = CaseID;


                isVerificationCompleted[1] = new OleDbParameter("@MessageNo", OleDbType.Integer);
                isVerificationCompleted[1].Direction = ParameterDirection.Output;


                OleDbHelper.ExecuteNonQuery(oledbTrans6, CommandType.StoredProcedure, "spIsCCVerificationComplete", isVerificationCompleted);

                if (Convert.ToInt32(isVerificationCompleted[1].Value) == 1)
                {
                    sMsg = "Case verification data entry completed.";

                }


                oledbTrans6.Commit();
                oledbConn6.Close();
            }
            catch (Exception ex)
            {
                oledbTrans6.Rollback();
                oledbConn6.Close();
                strError = ex.Message;
            }
        }
        catch 
        {
 
        }
        Error = strError;
        return sMsg;
    }
    #endregion InsertBusinessVerificationDetails

    #region GetResidenceCaseDetail
    /// <summary>
    /// This Method is used to get Values for RT  from table CPV_CC_CASE_DETAILS.
    /// </summary>
    /// <param name="sCaseId"></param>
    /// <returns></returns>
    public OleDbDataReader GetResidenceCaseDetail(string sCaseId)
    {
        //////////add by santosh shelar off name 28-08-08/////////////////
        string sSql = "";
        sSql = "SELECT (isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME,REF_NO,MOBILE,MOBILE_1,TME_Name,Reference_Name,Case_REC_DATETIME,RES_ADD_LINE_1,RES_PIN_CODE,RES_LAND_MARK,RES_PHONE, " +
                " OFF_NAME,(isNull(Pmt_Add_Line_1,'')+' '+isnull(Pmt_Add_Line_2,'')+' '+isnull(Pmt_Add_Line_3,'')) as Permanent_ADDRESS " +
                "FROM CPV_CC_CASE_DETAILS where CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetResidenceCaseDetail

    #region GetVerificationResidenceOtherDetail
    /// <summary>
    /// This method is ued to get values  for RT  from table CPV_CC_VERI_OTHER_DETAILS
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetVerificationResidenceOtherDetail(string sCaseID,string sVerificationTypeID)
    {
        string sSql = "";
        sSql = "Select AGENCY_NAME,REL_WITH_APPLICANT,PERMANENT_ADDRESS,applicant_home_country_phone,address_match from CPV_CC_VERI_OTHER_DETAILS where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationResidenceOtherDetail

    #region GetResidenceVerificationDescription1
    /// <summary>
    /// This method is used to get the values  for RT  from table CPV_CC_VERI_DESCRIPTION1
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetResidenceVerificationDescription1(string sCaseID, string sVerificationTypeID)
    {
        //////////Select statement modified by Sunny Chauhan : Field Added DIRECTORY_CHK_ADD_REASON //////////////////
        /////////Select statement modified by Santosh Shelar : Field Added Emp_Code /////////////////////////////////
        string sSql = "";
        //////////sSql = "Select CONTACTED_PERSON_NAME,COMPANY_NAME,MAILING_ADDRESS,RESIDANCE_IS,DESIGNATION,NOB,DOB_APPLICANT,APPLICANT_IS_AVAILABLE_AT, " +
        //////////         " NEW_DETAILS_OBTAINED,SPECIAL_INSTRUCTIONS,IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA,EMPLOYER_ADD,DIRECTORY_CHK_ADD_REASON," +
        //////////         " APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO,RESIDANCE_STATUS,ANY_OTHER_RESIDANCE_PHONE_NO,CHANGE_IN_PHONE_NO,REASON_FOR_CHANGE,SEGMENTATION, " +
        //////////         " DIRECTORY_CHECK,PP_ADD_LOCATION,TIME_AT_CURRENT_EMPLOYMENT,SPK_TO,RESI_COMOFF_OWNED,BUSINESS_CONTACT_EXTN, "+
        //////////         "IS_RESI_ADD_IS_IN_NEGATIVE_AREA,CALLED_UP_ON_RESIDANCE_TEL_NO,NATURE_BUSINESS_RESI_CUM_OFF,NAME_OF_PERSON_CONTACTED from CPV_CC_VERI_DESCRIPTION1 " +
        //////////         " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        sSql = "Select a.CONTACTED_PERSON_NAME,a.COMPANY_NAME,a.MAILING_ADDRESS,a.RESIDANCE_IS,a.DESIGNATION,a.NOB,a.DOB_APPLICANT,a.APPLICANT_IS_AVAILABLE_AT, " +
                 " a.NEW_DETAILS_OBTAINED,a.SPECIAL_INSTRUCTIONS,a.IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA,a.EMPLOYER_ADD,a.DIRECTORY_CHK_ADD_REASON," +
                 " a.APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO,a.RESIDANCE_STATUS,a.ANY_OTHER_RESIDANCE_PHONE_NO,a.CHANGE_IN_PHONE_NO,a.REASON_FOR_CHANGE,a.SEGMENTATION, " +
                 " a.DIRECTORY_CHECK,a.PP_ADD_LOCATION,a.TIME_AT_CURRENT_EMPLOYMENT,a.SPK_TO,a.RESI_COMOFF_OWNED, " +
                 "a.IS_RESI_ADD_IS_IN_NEGATIVE_AREA,a.CALLED_UP_ON_RESIDANCE_TEL_NO,a.NATURE_BUSINESS_RESI_CUM_OFF,a.NAME_OF_PERSON_CONTACTED,a.office_ext,a.emp_code, " +
                 " a.appli_dept,a.no_of_years_at_current_employment,a.Dir_Check,a.Job_Desc,Other_1,Other_2,RESPONSE,STATUS,PERSONCONTACTED,RESIDENCE_VERITYP,AGENCY,Reason,Answered,HomeCountryNumber,HomeCountryAddress,LocalHomeAddress,POBox,Mothersmaidenname  from CPV_CC_VERI_DESCRIPTION1 a, cpv_cc_case_details b " +
                 " where b.case_id=a.case_id and b.CASE_ID='" + sCaseID + "'" + "and a.VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetResidenceVerificationDescription1

    #region GetResidenceVerificationDescription
    /// <summary>
    /// This method is used to get the values for RT from the table CPV_CC_VERI_DESCRIPTION.
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetResidenceVerificationDescription(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = "Select CONTACTABILITY,PROFILE,REPUTATION,TIME_AT_CURR_RESIDANCE,INFO_REQUIRED,PRIORITY_CUSTOMER, " +
               "ADRESS_CONFIRMATION,APPLICANT_AGE,MISMATCH_RESI_ADD,RECOMMENDATION,ADDITIONAL_REMARK,TELE_CALLER_NAME, "+
               "BUSINESS_CONTACT_NO_EXTN,FAMILY_MEMBERS,CONFIRMATION_IF_APPLICANT_MET,TIME_AT_CURR_Y_M,TPC_DETAILS, "+
               "SUPERVISOR_CODE,change_in_adress,vehicle_other,bank_name,name_society_board  from CPV_CC_VERI_DESCRIPTION " +
               " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
                
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetResidenceVerificationDescription

    #region GetResidenceVerificationDetail
    /// <summary>
    /// this method is used to get the values for RT from CPV_CC_VERI_DETAILS.
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetResidenceVerificationDetail(string sCaseID, string sVerificationTypeID)
    {
        //Select query column added actual_num_type, actual_number by Sunny Chauhan//
        string sSql = "";
        sSql = "Select Any_Info,OVERALL_ASSESMENT,ANY_INFO,OVERALL_ASSESMENT_REASON,SUPERVISOR_REMARKS,DECLINED_REASON, " +
               "CASE_STATUS_ID,SUPERVISOR_ID,ACTUAL_NUM_TYPE, ACTUAL_NUMBER,Docs from CPV_CC_VERI_DETAILS " +
               " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
                
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetResidenceVerificationDetail

    #region GetTeleCallLogDetail
    /// <summary>
    /// This method is used to get the records for RT from table CPV_CC_VERI_ATTEMPTS. 
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT ATTEMPT_DATE_TIME,REMARK ,TELEPHONE_NO,VERIFIER_ID from CPV_CC_VERI_ATTEMPTS " +
              " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "' order by ATTEMPT_DATE_TIME";
        
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetTeleCallLogDetail

    //////////////////////////////////For Business geting Records///////////////////////////////////

    #region GetBusinessCaseDetail
    /// <summary>
    /// This method is method is used to get records for BT from table CPV_CC_CASE_DETAILS
    /// </summary>
    /// <param name="sCaseId"></param>
    /// <returns></returns>
    public OleDbDataReader GetBusinessCaseDetail(string sCaseId)
    {
        ///////////add by santosh shelar off name 28-08-08///////////////////
        string sSql = "";
        sSql = "SELECT (isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME,REF_NO, Case_REC_DATETIME,OFF_ADD_LINE_1,MOBILE, DESIGNATION,OFF_PHONE,OFF_NAME FROM CPV_CC_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetBusinessCaseDetail

    #region GetVerificationBusinessOtherDetail
    /// <summary>
    /// This method is used to get the records for BT from table CPV_CC_VERI_OTHER_DETAILS 
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetVerificationBusinessOtherDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = "Select AGENCY_NAME,PERMANENT_ADDRESS,REL_WITH_APPLICANT,OTHERS_DESIGNATION,Address_Match,applicant_home_country_phone,IS_RESIDANT from CPV_CC_VERI_OTHER_DETAILS where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationBusinessOtherDetail

    #region GetBusinessVerificationDescription1
    /// <summary>
    /// This method is used to get the records for BT from table CPV_CC_VERI_DESCRIPTION1. 
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetBusinessVerificationDescription1(string sCaseID, string sVerificationTypeID)
    {
        ////////Select Statement modified column added DIRECTORY_CHK_ADD_REASON by Sunny Chauhan//////////////
        string sSql = "";
        sSql = "select CONTACTED_PERSON_NAME,INCOME_DOC_SUBMITTED_WITH_APLICATION,TIME_AT_CURRENT_EMPLOYMENT, " +
               "OFFICE_EXT,DESIGNATION,DOB_APPLICANT,APPLICANT_IS_AVAILABLE_AT,NEW_DETAILS_OBTAINED, " +
               "SPECIAL_INSTRUCTIONS,IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA,BUSINESS_CONTACT_EXTN, DIRECTORY_CHK_ADD_REASON, " +
               "APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO,CHANGE_IN_PHONE_NO,REASON_FOR_CHANGE,YCR,SEGMENTATION, " +
               "RESIDANCE_IS,MAILING_ADDRESS,RESI_COMOFF_OWNED,IS_RESI_ADD_IS_IN_NEGATIVE_AREA,DESIG_AND_DEPT_OF_CONTACTED_PERSON, " +
               "NATURE_BUSINESS_RESI_CUM_OFF,CALLED_UP_ON_OFFICE_TEL_NO,NO_OF_YEARS_AT_CURRENT_EMPLOYMENT,TELE_COMMENTS,TIME_AT_CURRENT_EMPL_Y_M, " +
               "COMPANY_NAME,LAND_MARK_OBSERVED,DIRECTORY_CHECK,SPK_TO,CURRENT_RESIDENCE_PERIOD,APP_QUALIFICATION,Appli_Dept,dir_check,Job_Desc " +
               "from CPV_CC_VERI_DESCRIPTION1 where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetBusinessVerificationDescription1

    #region GetBusinessVerificationDescription
    /// <summary>
    /// This method is used to get the records for BT from table CPV_CC_VERI_DESCRIPTION.
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetBusinessVerificationDescription(string sCaseID, string sVerificationTypeID)
    {
        //////////Select Modified By Sunny Chauhan. Add Column name Mismatch_Resi_Add//////////////
        ////////////add 1 value for command 12-09-08///////////////
        string sSql = "";
        sSql = "Select QUALIFICATION,CONTACTABILITY,PROFILE,REPUTATION, " +
               "INFO_REQUIRED,PRIORITY_CUSTOMER,ADRESS_CONFIRMATION,APPLICANT_AGE,TIME_AT_CURR_Y_M, "+
               "RECOMMENDATION, Mismatch_Resi_Add, CONFIRMATION_IF_APPLICANT_MET,TELE_CALLER_NAME,FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION, "+
               "EMP_PERMANENT_TEMP,EMP_CONFIRMED_OR_NOT_CONFIRMED,APP_DOB_APPROX_AGE,RSIDENCE_PHONE_NO,OTHER_CONTACTED_DESIGNATION, " +
               "OTHER_NATURE_OF_BUSINESS,ADDITIONAL_REMARK,EMPLOYERS_NAME,Other_Nature_Buss,change_in_adress,Vehicle_Other from CPV_CC_VERI_DESCRIPTION " + 
               "where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetBusinessVerificationDescription

    #region GetBusinessVerificationDetail
    /// <summary>
    /// This method is used to get records for BT from table CPV_CC_VERI_DETAILS.
    /// </summary>
    /// <param name="sCaseID"></param>
    /// <param name="sVerificationTypeID"></param>
    /// <returns></returns>
    public OleDbDataReader GetBusinessVerificationDetail(string sCaseID, string sVerificationTypeID)
    {
        //////Select statement edited by SUNNY CHAUHAN COLUMNS ADDED actual_num_type, actual_number///////
        /////add by santosh shelar supervisor id/////////////////////
        string sSql = "";
        sSql = "Select Any_Info,SUPERVISOR_REMARKS,CASE_STATUS_ID,OVERALL_ASSESMENT,OVERALL_ASSESMENT_REASON, ACTUAL_NUM_TYPE, ACTUAL_NUMBER,SUPERVISOR_ID,declined_reason from CPV_CC_VERI_DETAILS  " +
               " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }
    #endregion GetBusinessVerificationDetail
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="ProductId"></param>
    /// <returns></returns>
    
    public DataSet DataCaseStatusRemark(string UserId, string ProductId)
    {
        //////////////Modification done by Sunny Chauhan : Start/////////////////////
        /////////Modification done for showing TC Remarks for Telecaller login and Rest status codes for other logins////////////////

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string sSQLChk = "";
        sSQLChk = "select desig_code from employee_master a,user_master b, designation_master c where" +
            " a.emp_id = b.userid and a.designation_id = c.designation_id and b.userid = '" + UserId + "'";
        ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSQLChk);
        if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "TC")
        {
            string sSql = "";

            sSql = "SELECT CASE_STATUS_ID, STATUS_CODE FROM CASE_STATUS_MASTER WHERE case_status_id in (37,38,39,40,41)";
            ds1 = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
            return ds1;
            //DataTable dt = new DataTable();
            //DataRow dr;
            //dt.Columns.Add("Status_Code");
            //dt.Columns.Add("CASE_STATUS_ID");
            //    //dr = new DataRow();
            //    dt.Rows[0]["Status_Code"] = "TC Remark";
            //    dt.Rows[0]["CASE_STATUS_ID"] = "0";
            //    dt.Rows.Add(dr);
            //    //dr = new DataRow();
            //    dt.Rows[1]["Status_Code"] = "Pending / Incomplete";
            //    dt.Rows[1]["CASE_STATUS_ID"] = "1";
            //    //dt.Rows.Add(dr);

            //    ds = ((DataSet)ds.Tables.Add(dt));
            
        }
        else
        {
            string sSql = "";

            //sSql = "SELECT CASE_STATUS_ID, STATUS_CODE FROM CASE_STATUS_MASTER WHERE PRODUCT_ID = '" + ProductId + "' and case_status_id not in (37,38,39,40,41) ORDER BY STATUS_CODE";
            sSql = "SELECT CASE_STATUS_ID, STATUS_CODE FROM CASE_STATUS_MASTER WHERE PRODUCT_ID = '" + ProductId + "' ORDER BY STATUS_CODE";  //Rupesh Zodage--04/03/2013
            ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
            return ds;
        }

        //////////////////Modification ended. Sunny Chauhan//////////////////
    }

    #region GetTeleResults
    /// <summary>
    /// This method is used to get the record for BT from Table CASE_STATUS_MASTER.
    /// </summary>
    /// <returns></returns>
    public DataTable GetTeleResults()
    {
         string sSql = "";
        DataTable dt = new DataTable();
        sSql = "SELECT CASE_STATUS_ID,STATUS_CODE FROM CASE_STATUS_MASTER ORDER BY STATUS_CODE";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "CASE_STATUS_MASTER");
        dt = ds.Tables["CASE_STATUS_MASTER"];
        return dt;
    }
    #endregion GetTeleResults

    #region GetTeleCallerName
    /// <summary>
    /// This method is used to get records for BT from view TC_VW.
    /// </summary>
    /// <param name="strCentreId"></param>
    /// <returns></returns>
    /// 
    /// Modified by Sunny Chauhan : Start ////////
    /// Modification done for telecallername to be filled for telecaller login only. //////
    public DataTable GetTeleCallerName(string strCentreId, string UserId, string sCaseID, string sVerificationTypeID)
    {
           string sSql = "";
           DataTable dt = new DataTable();

        /////   sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "'";
        /////   OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        /////   DataSet ds = new DataSet();
        /////   oledbDa.Fill(ds, "TC_VW");
        /////   dt = ds.Tables["TC_VW"];
        /////   return dt;
        DataSet ds = new DataSet();
        /////DataSet ds1 = new DataSet();
       


        //string sSQLChk = "";
        //sSQLChk = "select desig_code from employee_master a,user_master b, designation_master c where" +
        //    " a.emp_id = b.userid and a.designation_id = c.designation_id and b.userid = '" + UserId + "'";
        //ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSQLChk);
        //if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "TC")
        //{
            sSql = "Select EMP_ID,FULLNAME from TC_VW ";
            //sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "' and user_id = '" + UserId + "'";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds1 = new DataSet();
            oledbDa.Fill(ds1, "TC_VW");
            dt = ds1.Tables["TC_VW"];
            return dt;
            /////OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
            /////return ds1; restart the server
            
        //}


        if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "SUP")
        {
            sSql = "exec TC_SUP_Fill '" + strCentreId + "','" + sCaseID + "','" + sVerificationTypeID + "'";
            OleDbDataAdapter oledbDa1 = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds2 = new DataSet();
            oledbDa.Fill(ds1, "TC_SUP_Fill");
            dt = ds2.Tables["TC_SUP_Fill"];
            return dt;
            /////OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
            /////return ds1;

        }
        else
        {
            sSql = "Select EMP_ID,FULLNAME from TC_VW ";
            //sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "'";
            OleDbDataAdapter oledbDa2 = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds3 = new DataSet();
            oledbDa.Fill(ds1, "TC_VW");
            dt = ds3.Tables["TC_VW"];
            return dt;
        }
    }
    /////////// End Modifications done by Sunny Chauhan /////// 
    #endregion GetTeleCallerName

    public DataTable GetTeleCallerNameDcr(string strCentreId, string UserId, string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";
        DataTable dt = new DataTable();

        /////   sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "'";
        /////   OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        /////   DataSet ds = new DataSet();
        /////   oledbDa.Fill(ds, "TC_VW");
        /////   dt = ds.Tables["TC_VW"];
        /////   return dt;
        DataSet ds = new DataSet();
        /////DataSet ds1 = new DataSet();



        string sSQLChk = "";
        sSQLChk = "select desig_code from employee_master a,user_master b, designation_master c where" +
            " a.emp_id = b.userid and a.designation_id = c.designation_id and b.userid = '" + UserId + "'";
        ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSQLChk);

        if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "TC")
        {
            sSql = "Select EMP_ID,FULLNAME from TC_VW_Dcr where emp_id = '" + UserId + "'";
            //sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "' and user_id = '" + UserId + "'";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds1 = new DataSet();
            oledbDa.Fill(ds1, "TC_VW");
            dt = ds1.Tables["TC_VW"];
            return dt;
        }
        else
        {
            //sSql = "Select EMP_ID,FULLNAME from TC_VW_Dcr ";
            //sSql = "select emp_id,fullname from employee_master a,CPV_DCR_VERI_ATTEMPTS b where a.emp_id=b.verifier_id and b.case_id='" + sCaseID + "'";
            sSql = "select emp_id,fullname from CPV_DCR_TC_CASE_MAPPING a left outer join employee_master b on a.tc_id=b.emp_id where a.case_id='" + sCaseID + "'";
            OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds1 = new DataSet();
            oledbDa.Fill(ds1, "TC_VW");
            dt = ds1.Tables["TC_VW"];
            return dt;
        }
        
        /////OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
        /////return ds1; restart the server

        //}


        if (ds.Tables[0].Rows[0]["desig_code"].ToString() == "SUP")
        {
            sSql = "exec TC_SUP_Fill '" + strCentreId + "','" + sCaseID + "','" + sVerificationTypeID + "'";
            OleDbDataAdapter oledbDa1 = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds2 = new DataSet();
            oledbDa1.Fill(ds2, "TC_SUP_Fill");
            dt = ds2.Tables["TC_SUP_Fill"];
            return dt;
            /////OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
            /////return ds1;

        }
        else
        {
            sSql = "Select EMP_ID,FULLNAME from TC_VW_Dcr ";
            //sSql = "Select EMP_ID,FULLNAME from TC_VW WHERE CENTRE_ID='" + strCentreId + "'";
            OleDbDataAdapter oledbDa2 = new OleDbDataAdapter(sSql, objCon.ConnectionString);
            DataSet ds3 = new DataSet();
            oledbDa2.Fill(ds3, "TC_VW");
            dt = ds3.Tables["TC_VW"];
            return dt;
        }
    }

    #region GetSupervisorName
    /// <summary>
    /// This method is used to get the records for BT fom view SUP_VW. 
    /// </summary>
    /// <param name="strCentreId"></param>
    /// <returns></returns>
    public DataTable GetSupervisorName(string strCentreId)
    {
        string sSql = "";
        DataTable dtSupervisorName = new DataTable();
        sSql = "Select EMP_ID,FULLNAME from SUP_VW WHERE CENTRE_ID='" + strCentreId + "'";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "SUP_VW");
        dtSupervisorName = ds.Tables["SUP_VW"];
        return dtSupervisorName;
    }

    public DataTable GetSupervisorName_Dcr(string strCentreId)
    {
        string sSql = "";
        DataTable dtSupervisorName = new DataTable();
        sSql = "Select EMP_ID,FULLNAME from SUP_VW_Dcr WHERE CENTRE_ID='" + strCentreId + "'";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "SUP_VW");
        dtSupervisorName = ds.Tables["SUP_VW"];
        return dtSupervisorName;
    }
    #endregion GetSupervisorName

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Gargi Srivastava
    //Create Date	   :   12 Nov 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = " Select case (select count(*) from CPV_CC_CASE_VERIFICATIONTYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from CPV_CC_CASE_OUTPUT_VW where case_id='" + sCaseId + "' and CASE_STATUS_ID<>'') " +
              " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }

    #endregion IsVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_CC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete
      
}
