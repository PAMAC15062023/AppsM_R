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
/// Summary description for CRL_TelephonicVerification
/// </summary>
public class CRL_TelephonicVerification
{
    private CCommon objCon;
	public CRL_TelephonicVerification()
	{
        objCon = new CCommon();
		//
		// TODO: Add constructor logic here
		//
	}
    #region Properties Declaration
    //added by hemangi kambli on 01/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;


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
    //Start of Properties for table CPV_CC_VERI_ATTEMPTS and in form for TELECALL LOG
    private string strCaseID;
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
    private string strVerificationType;
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
    private string strVerificationTypeID;
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
    private string strVerifierID;
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
    private string attemptDateTime;
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
    private string strRemark;
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
    private string strTelephoneNo;

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


    //New added/Updated for CHOLA

    private string sApplicationDate;
    public string ApplicationDate
    {
        get { return sApplicationDate; }
        set { sApplicationDate = value; }
    }

    private string sAddrDiffConf;
    public string AddrDiffConf
    {
        get { return sAddrDiffConf; }
        set { sAddrDiffConf = value; }
    }

    private string sNeighbour1_Comments;
    public string Neighbour1_Comments
    {
        get { return sNeighbour1_Comments; }
        set { sNeighbour1_Comments = value; }
    }

    private string sNeighbour_Telephone2;
    public string Neighbour_Telephone2
    {
        get { return sNeighbour_Telephone2; }
        set { sNeighbour_Telephone2 = value; }
    }

    private string sNeighbour2_confirmation;
    public string Neighbour2_confirmation
    {
        get { return sNeighbour2_confirmation; }
        set { sNeighbour2_confirmation = value; }
    }

    private string sNeighbour2_Comments;
    public string Neighbour2_Comments
    {
        get { return sNeighbour2_Comments; }
        set { sNeighbour2_Comments = value; }
    }

    private string sLess1YrAddr;
    public string Less1YrAddr
    {
        get { return sLess1YrAddr; }
        set { sLess1YrAddr = value; }
    }

    private string sIs_address_same;
    public string Is_address_same
    {
        get { return sIs_address_same; }
        set { sIs_address_same = value; }
    }

    private string sName_Neighbour1;
    public string Name_Neighbour1
    {
        get { return sName_Neighbour1; }
        set { sName_Neighbour1 = value; }
    }

    private string sName_Neighbour2;
    public string Name_Neighbour2
    {
        get { return sName_Neighbour2; }
        set { sName_Neighbour2 = value; }
    }

    private string sTelephone_Exists;
    public string Telephone_Exists
    {
        get { return sTelephone_Exists; }
        set { sTelephone_Exists = value; }
    }

    private string sTele_whose_Name;
    public string Tele_whose_Name
    {
        get { return sTele_whose_Name; }
        set { sTele_whose_Name = value; }
    }

    private string sAddressCDROM;
    public string AddressCDROM
    {
        get { return sAddressCDROM; }
        set { sAddressCDROM = value; }
    }

    private string sDedupe_check;
    public string Dedupe_check
    {
        get { return sDedupe_check; }
        set { sDedupe_check = value; }
    }

    private string sCustomerCIFL;
    public string CustomerCIFL
    {
        get { return sCustomerCIFL; }
        set { sCustomerCIFL = value; }
    }

    //END for CHOLA


    private string strVerificationDateAndTime;
    public string VerificationDateAndTime
    {
        get
        {
            return strVerificationDateAndTime;
        }
        set
        {
            strVerificationDateAndTime = value;
        }
    }

    private string strDate;
    public string Date
    {
        get
        {
            return strDate;
        }
        set
        {
            strDate = value;
        }
    }
    private string strRefNo;
    public string RefNo
    {
        get
        {
            return strRefNo;
        }
        set
        {
            strRefNo = value;
        }
    }
    private string strArea;
    public string Area
    {
        get
        {
            return strArea;
        }
        set
        {
            strArea = value;
        }
    }
    private string strNameOfTheApplicant;
    public string NameOfTheApplicant
    {
        get
        {
            return strNameOfTheApplicant;
        }
        set
        {
            strNameOfTheApplicant = value;
        }
    }
    private string strResidencePhoneNo;
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

    private string strResidencePhoneNoBT;
    public string ResidencePhoneNoBT
    {
        get
        {
            return strResidencePhoneNoBT;
        }
        set
        {
            strResidencePhoneNoBT = value;
        }
    }

    private string strResidenceAddressAsPerApplication;
    public string ResidenceAddressAsPerApplication
    {
        get
        {
            return strResidenceAddressAsPerApplication;
        }
        set
        {
            strResidenceAddressAsPerApplication = value;
        }
    }


    private string strPersonContactedResiTeleConfirmsApplicantStaysAddress;
    public string PersonContactedResiTeleConfirmsApplicantStaysAddress
    {
        get
        {
            return strPersonContactedResiTeleConfirmsApplicantStaysAddress;
        }
        set
        {
            strPersonContactedResiTeleConfirmsApplicantStaysAddress = value;
        }
    }
    private string strPersonContactedOffiTeleConfirmsApplicantWorksAddress;
    public string PersonContactedOffiTeleConfirmsApplicantWorksAddress
    {
        get
        {
            return strPersonContactedOffiTeleConfirmsApplicantWorksAddress;
        }
        set
        {
            strPersonContactedOffiTeleConfirmsApplicantWorksAddress = value;
        }
    }

    private string strAddressDifferent;
    public string AddressDifferent 
    {
        get
        {
            return strAddressDifferent;
        }
        set
        {
            strAddressDifferent = value;
        }
    }

    private string strProdName;
    public string ProdName
    {
        get
        {
            return strProdName;
        }
        set
        {
            strProdName = value;
        }
    }

    private string strExtn;
    public string Extn
    {
        get
        {
            return strExtn;
        }
        set
        {
            strExtn = value;
        }
    }

    private string strAltPh;
    public string AltPh
    {
        get
        {
            return strAltPh; 
        }
        set
        {
            strAltPh = value;
        }
    }

    private string strrelantion;
    public string relantion
    {
        get
        {
            return strrelantion;
        }
        set
        {
            strrelantion = value;
        }
    }

    private string strPersonContacted;
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
    private string strRelationshipWithApplicant;
    public string RelationshipWithApplicant
    {
        get
        {
            return strRelationshipWithApplicant;
        }
        set
        {
            strRelationshipWithApplicant = value;
        }
    }
    private string strResidenceAddressAsPerCall;
    public string ResidenceAddressAsPerCall
    {
        get
        {
            return strResidenceAddressAsPerCall;
        }
        set
        {
            strResidenceAddressAsPerCall = value;
        }
    }
    private string strNumberofYearsAtResidence;
    public string NumberofYearsAtResidence
    {
        get
        {
            return strNumberofYearsAtResidence;
        }
        set
        {
            strNumberofYearsAtResidence = value;
        }
    }
    private string strNameOfEmployer;
    public string NameOfEmployer
    {
        get
        {
            return strNameOfEmployer;
        }
        set
        {
            strNameOfEmployer = value;
        }
    }
    private string strPermanentAddress;
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
    private string strOverallRemarks;
    public string OverallRemarks
    {
        get
        {
            return strOverallRemarks;
        }
        set
        {
            strOverallRemarks = value;
        }
    }
    private string strRating;
    public string Rating
    {
        get
        {
            return strRating;
        }
        set
        {
            strRating = value;
        }
    }

    private string strPerCon;
    public string PerCon
    {
        get
        {
            return strPerCon;
        }
        set
        {
            strPerCon = value;
        }
    }

    private string strOwnershipRESIDENCE;
    public string OwnershipRESIDENCE
    {
        get
        {
            return strOwnershipRESIDENCE;
        }
        set
        {
            strOwnershipRESIDENCE = value;
        }
    }

    private string strmake;
    public string make
    {
        get
        {
            return strmake;
        }
        set
        {
            strmake = value;
        }
    }
    private string strloanAmt;
    public string loanAmt
    {
        get
        {
            return strloanAmt;
        }
        set
        {
            strloanAmt = value;
        }
    }
    private string strtenure;
    public string tenure
    {
        get
        {
            return strtenure;
        }
        set
        {
            strtenure = value;
        }
    }
    private string strmonth;
    public string month
    {
        get
        {
            return strmonth;
        }
        set
        {
            strmonth = value;
        }
    }

    private string strStayingSince;
    public string StayingSince
    {
        get
        {
            return strStayingSince;
        }
        set
        {
            strStayingSince = value;
        }
    }

    private string strNameApp;
    public string NameApp
    {
        get
        {
            return strNameApp;
        }
        set
        {
            strNameApp = value;
        }
    }
    private string strAddRem;
    public string AddRem
    {
        get
        {
            return strAddRem;
        }
        set
        {
            strAddRem = value;
        }
    }
    private string strTeleRemark;
    public string TeleRemark
    {
        get
        {
            return strTeleRemark;
        }
        set
        {
            strTeleRemark = value;
        }
    }
    /// <summary>
    /// /////////////////////add ne column for deutch bank by santosh 14-july-2010/////////////
    /// </summary>
    /// 
    private string strRefName;
    public string RefName
    {
        get
        {
            return strRefName;
        }
        set
        {
            strRefName = value;
        }
    }
    private string strRefTel;
    public string RefTel
    {
        get
        {
            return strRefTel;
        }
        set
        {
            strRefTel = value;
        }
    }
    private string strRelRef;
    public string RelRef
    {
        get
        {
            return strRelRef;
        }
        set
        {
            strRelRef = value;
        }
    }
    private string strKnowGua;
    public string KnowGua
    {
        get
        {
            return strKnowGua;
        }
        set
        {
            strKnowGua = value;
        }
    }
    private string strKnowRef;
    public string KnowRef
    {
        get
        {
            return strKnowRef;
        }
        set
        {
            strKnowRef = value;
        }
    }
    private string strEmpDetGua;
    public string EmpDetGua
    {
        get
        {
            return strEmpDetGua;
        }
        set
        {
            strEmpDetGua = value;
        }
    }
    private string strEmpDetRef;
    public string EmpDetRef
    {
        get
        {
            return strEmpDetRef;
        }
        set
        {
            strEmpDetRef = value;
        }
    }
    private string strOthLoanGua;
    public string OthLoanGua
    {
        get
        {
            return strOthLoanGua;
        }
        set
        {
            strOthLoanGua = value;
        }
    }
    private string strOthLoanRef;
    public string OthLoanRef
    {
        get
        {
            return strOthLoanRef;
        }
        set
        {
            strOthLoanRef = value;
        }
    }
    private string strLibGua;
    public string LibGua
    {
        get
        {
            return strLibGua;
        }
        set
        {
            strLibGua = value;
        }
    }
    private string strLibRef;
    public string LibRef
    {
        get
        {
            return strLibRef;
        }
        set
        {
            strLibRef = value;
        }
    }
    private string strEmiGua;
    public string EmiGua
    {
        get
        {
            return strEmiGua;
        }
        set
        {
            strEmiGua = value;
        }
    }
    private string strEmiRef;
    public string EmiRef
    {
        get
        {
            return strEmiRef;
        }
        set
        {
            strEmiRef = value;
        }
    }

    private string strCouterDate;
    public string CouterDate
    {
        get
        {
            return strCouterDate;
        }
        set
        {
            strCouterDate = value;
        }
    }

    private string strAgency_Code;
    public string Agency_Code
    {
        get
        {
            return strAgency_Code;
        }
        set
        {
            strAgency_Code = value;
        }
    }
    private string strMonths_work_current_office;
    public string Months_work_current_office
    {
        get
        {
            return strMonths_work_current_office;
        }
        set
        {
            strMonths_work_current_office = value;
        }
    }
    private string strRegion;
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
    private string strEarningMembers;
    public string EarningMembers
    {
        get
        {
            return strEarningMembers;
        }
        set
        {
            strEarningMembers = value;
        }
    }
    private string strDependents;
    public string Dependents
    {
        get
        {
            return strDependents;
        }
        set
        {
            strDependents = value;
        }
    }
    private string strSpouseWorking;
    public string SpouseWorking
    {
        get
        {
            return strSpouseWorking;
        }
        set
        {
            strSpouseWorking = value;
        }
    }
    private string strParenteDetails;
    public string ParenteDetails
    {
        get
        {
            return strParenteDetails;
        }
        set
        {
            strParenteDetails = value;
        }
    }
    private string strReasonDecline;
    public string ReasonDecline
    {
        get
        {
            return strReasonDecline;
        }
        set
        {
            strReasonDecline = value;
        }
    }
    private string strResiIs;
    public string ResiIs
    {
        get
        {
            return strResiIs;
        }
        set
        {
            strResiIs = value;
        }
    }

    private string strAppDesignation;
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
    private string strNameOfCompany;
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

    private string strNameCoApp;
    public string NameCoApp
    {
        get
        {
            return strNameCoApp;
        }
        set
        {
            strNameCoApp = value;
        }
    }
    private string strCoAppDob;
    public string CoAppDob
    {
        get
        {
            return strCoAppDob;
        }
        set
        {
            strCoAppDob = value;
        }
    }
    private string strAddConf;
    public string AddConf
    {
        get
        {
            return strAddConf;
        }
        set
        {
            strAddConf = value;
        }
    }
    private string strNewHomeAddress;
    public string NewHomeAddress
    {
        get
        {
            return strNewHomeAddress;
        }
        set
        {
            strNewHomeAddress = value;
        }
    }
    private string strResiType;
    public string ResiType
    {
        get
        {
            return strResiType;
        }
        set
        {
            strResiType = value;
        }
    }
    private string strTranType;
    public string TranType
    {
        get
        {
            return strTranType;
        }
        set
        {
            strTranType = value;
        }
    }
    private string strApproxArea;
    public string ApproxArea
    {
        get
        {
            return strApproxArea;
        }
        set
        {
            strApproxArea = value;
        }
    }
    private string strTotalCost;
    public string TotalCost
    {
        get
        {
            return strTotalCost;
        }
        set
        {
            strTotalCost = value;
        }
    }
    private string strLoanAmt;
    public string LoanAmt
    {
        get
        {
            return strLoanAmt;
        }
        set
        {
            strLoanAmt = value;
        }
    }
    private string strPropBought;
    public string PropBought
    {
        get
        {
            return strPropBought;
        }
        set
        {
            strPropBought = value;
        }
    }
    private string strRelantionProp;
    public string RelantionProp
    {
        get
        {
            return strRelantionProp;
        }
        set
        {
            strRelantionProp = value;
        }
    }
    private string strOtherProp;
    public string OtherProp
    {
        get
        {
            return strOtherProp;
        }
        set
        {
            strOtherProp = value;
        }
    }
    private string strNameGuran1;
    public string NameGuran1
    {
        get
        {
            return strNameGuran1;
        }
        set
        {
            strNameGuran1 = value;
        }
    }
    private string strContactR1;
    public string ContactR1
    {
        get
        {
            return strContactR1;
        }
        set
        {
            strContactR1 = value;
        }
    }
    private string strContactO1;
    public string ContactO1
    {
        get
        {
            return strContactO1;
        }
        set
        {
            strContactO1 = value;
        }
    }
    private string strPersonCont1;
    public string PersonCont1
    {
        get
        {
            return strPersonCont1;
        }
        set
        {
            strPersonCont1 = value;
        }
    }
    private string strRelanApp1;
    public string RelanApp1
    {
        get
        {
            return strRelanApp1;
        }
        set
        {
            strRelanApp1 = value;
        }
    }
    private string strRelationship1;
    public string Relationship1
    {
        get
        {
            return strRelationship1;
        }
        set
        {
            strRelationship1 = value;
        }
    }
    private string strAddGurent1;
    public string AddGurent1
    {
        get
        {
            return strAddGurent1;
        }
        set
        {
            strAddGurent1 = value;
        }
    }
    private string strhowLong1;
    public string howLong1
    {
        get
        {
            return strhowLong1;
        }
        set
        {
            strhowLong1 = value;
        }
    }
    private string strReadyGua1;
    public string ReadyGua1
    {
        get
        {
            return strReadyGua1;
        }
        set
        {
            strReadyGua1 = value;
        }
    }
    private string strBeenGua1;
    public string BeenGua1
    {
        get
        {
            return strBeenGua1;
        }
        set
        {
            strBeenGua1 = value;
        }
    }
    private string strStatus1;
    public string Status1
    {
        get
        {
            return strStatus1;
        }
        set
        {
            strStatus1 = value;
        }
    }

    private string strNameGuran2;
    public string NameGuran2
    {
        get
        {
            return strNameGuran2;
        }
        set
        {
            strNameGuran2 = value;
        }
    }
    private string strContactR2;
    public string ContactR2
    {
        get
        {
            return strContactR2;
        }
        set
        {
            strContactR2 = value;
        }
    }
    private string strContactO2;
    public string ContactO2
    {
        get
        {
            return strContactO2;
        }
        set
        {
            strContactO2 = value;
        }
    }
    private string strPersonCont2;
    public string PersonCont2
    {
        get
        {
            return strPersonCont2;
        }
        set
        {
            strPersonCont2 = value;
        }
    }
    private string strRelanApp2;
    public string RelanApp2
    {
        get
        {
            return strRelanApp2;
        }
        set
        {
            strRelanApp2 = value;
        }
    }
    private string strRelationship2;
    public string Relationship2
    {
        get
        {
            return strRelationship2;
        }
        set
        {
            strRelationship2 = value;
        }
    }
    private string strAddGurent2;
    public string AddGurent2
    {
        get
        {
            return strAddGurent2;
        }
        set
        {
            strAddGurent2 = value;
        }
    }
    private string strhowLong2;
    public string howLong2
    {
        get
        {
            return strhowLong2;
        }
        set
        {
            strhowLong2 = value;
        }
    }
    private string strReadyGua2;
    public string ReadyGua2
    {
        get
        {
            return strReadyGua2;
        }
        set
        {
            strReadyGua2 = value;
        }
    }
    private string strBeenGua2;
    public string BeenGua2
    {
        get
        {
            return strBeenGua2;
        }
        set
        {
            strBeenGua2 = value;
        }
    }
    private string strStatus2;
    public string Status2
    {
        get
        {
            return strStatus2;
        }
        set
        {
            strStatus2 = value;
        }
    }
    private string strOffTelNo;
    public string OffTelNo
    {
        get
        {
            return strOffTelNo;
        }
        set
        {
            strOffTelNo = value;
        }
    }
    /// <summary>
    /// /////////////////////////////end code/////////////////////
    /// </summary>
    private string strTelecallersName;
    public string TelecallersName
    {
        get
        {
            return strTelecallersName;
        }
        set
        {
            strTelecallersName = value;
        }
    }
    private string strOfficeTelephoneNumber;
    public string OfficeTelephoneNumber
    {
        get
        {
            return strOfficeTelephoneNumber;
        }
        set
        {
            strOfficeTelephoneNumber = value;
        }
    }
    private string strExactCompanyname;
    public string ExactCompanyname
    {
        get
        {
            return strExactCompanyname;
        }
        set
        {
            strExactCompanyname = value;
        }
    }
    private string strExactCompanyAddress;
    public string ExactCompanyAddress
    {
        get
        {
            return strExactCompanyAddress;
        }
        set
        {
            strExactCompanyAddress = value;
        }
    }
    private string strDesignationOfPersonContacted;
    public string DesignationOfPersonContacted
    {
        get
        {
            return strDesignationOfPersonContacted;
        }
        set
        {
            strDesignationOfPersonContacted = value;
        }
    }
    private string strExactDesignationOfApplicant;
    public string ExactDesignationOfApplicant
    {
        get
        {
            return strExactDesignationOfApplicant;
        }
        set
        {
            strExactDesignationOfApplicant = value;
        }
    }
    private string strNoOfYearsWithTheCompany;
    public string NoOfYearsWithTheCompany
    {
        get
        {
            return strNoOfYearsWithTheCompany;
        }
        set
        {
            strNoOfYearsWithTheCompany = value;
        }
    }
    private string strNatureOfBusiness;
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
    private string strMainlineBusinessOfTheCompany;
    public string MainlineBusinessOfTheCompany
    {
        get
        {
            return strMainlineBusinessOfTheCompany;
        }
        set
        {
            strMainlineBusinessOfTheCompany = value;
        }
    }
    private string strCategoryOfCompany;
    public string CategoryOfCompany
    {
        get
        {
            return strCategoryOfCompany;
        }
        set
        {
            strCategoryOfCompany = value;
        }
    }

    private string strAppAge;
    public string AppAge
    {
        get
        {
            return strAppAge;
        }
        set
        {
            strAppAge = value;
        }
    }

    private string strMailAdd;
    public string MailAdd
    {
        get
        {
            return strMailAdd;
        }
        set
        {
            strMailAdd = value;
        }
    }

    private string strIncomeDoc;
    public string IncomeDoc
    {
        get
        {
            return strIncomeDoc;
        }
        set
        {
            strIncomeDoc = value;
        }
    }

    private string strOfficeBusinessAddressAsPerCall;
    public string OfficeBusinessAddressAsPerCall
    {
        get
        {
            return strOfficeBusinessAddressAsPerCall;
        }
        set
        {
            strOfficeBusinessAddressAsPerCall = value;
        }
    }
    private string strInBusinessSince;
    public string InBusinessSince
    {
        get
        {
            return strInBusinessSince;
        }
        set
        {
            strInBusinessSince = value;
        }
    }
    private string strUnsatisfactoryReason;
    public string UnsatisfactoryReason
    {
        get
        {
            return strUnsatisfactoryReason;
        }
        set
        {
            strUnsatisfactoryReason = value;
        }
    }

    //added by hemangi kambli on 07/09/2007------
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
//Naresh 16/06/08 Start
    private string StrStaying_Whom;
public string Staying_Whom
{
    get { return StrStaying_Whom;}
    set { StrStaying_Whom = value; }
}
    private string StrPP_Number;
public string PP_Number
{
    get { return StrPP_Number; }
    set { StrPP_Number = value; }
}
    private string StrAny_Other_Resi_Phone;
public string Any_Other_Resi_Phone
    {
        get { return StrAny_Other_Resi_Phone; }
        set { StrAny_Other_Resi_Phone = value; }
    }
    private string StrApplicant_Availbility;
public string Applicant_Availbility
{
    get { return StrApplicant_Availbility; }
    set { StrApplicant_Availbility = value; }
}
    private string StrDir_Check;
public string Dir_Check
{
    get { return StrDir_Check; }
    set { StrDir_Check = value; }
}
    private string StrName_of_Applicant_Conf;
public string Name_of_Applicant_Conf
{
    get { return StrName_of_Applicant_Conf; }
    set { StrName_of_Applicant_Conf = value; }
}
    private string StrMismatch_Add_Tel;
public string Mismatch_Add_Tel
{
    get { return StrMismatch_Add_Tel; }
    set { StrMismatch_Add_Tel = value; }
}
    private string Str_Years_At_Residence;
    public string Years_At_Residence
    {
        get { return Str_Years_At_Residence; }
        set { Str_Years_At_Residence = value; }
    }
    private string Str_Type_Office;
    public string Type_Office
    {
        get { return Str_Type_Office; }
        set { Str_Type_Office = value;}
    }
    private string Str_Ownership;
    public string Ownership
    {
        get { return Str_Ownership; }
        set { Str_Ownership = value; }
    }

    //Naresh 16/06/08 End

    //Added by kamal matekar for DhanLaxmi Bank On Dated 14th July 2011

    private string strBusinessNature;
    public string BusinessNature
    {
        get
        {
            return strBusinessNature;
        }
        set
        {
            strBusinessNature = value;
        }
    }

    private string strNoOfYearsAtSameAddress;
    public string NoOfYearsAtSameAddress
    {
        get
        {
            return strNoOfYearsAtSameAddress;
        }
        set
        {
            strNoOfYearsAtSameAddress = value;
        }
    }
    private string strLandmark;
    public string Landmark
    {
        get
        {
            return strLandmark;
        }
        set
        {
            strLandmark = value;
        }
    }

    private string strTotalNoOfEmployee;
    public string TotalNoOfEmployee
    {
        get
        {
            return strTotalNoOfEmployee;
        }
        set
        {
            strTotalNoOfEmployee = value;
        }
    }


    //Added By Rupesh on 03/05/2013

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

    private string strStatus;
    public string Status
    {
        get
        {
            return strStatus;
        }
        set
        {
            strStatus = value;
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

    private string strpersoncontactedRL;
    public string personcontactedRL 
    {
        get
        {
            return strpersoncontactedRL;
        }
        set
        {
            strpersoncontactedRL = value;
        }
    }

    private string strResvertyp;
    public string Resvertyp
    {
        get
        {
            return strResvertyp;
        }
        set
        {
            strResvertyp = value;
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

    //Added By Rupesh on 03/05/2013




    private string strWorkExp;
    public string WorkExp
    {
        get
        {
            return strWorkExp;
        }
        set
        {
            strWorkExp = value;
        }
    }

    private string strEmployerName;
    public string EmployerName
    {
        get
        {
            return strEmployerName;
        }
        set
        {
            strEmployerName = value;
        }
    }

    private string strExactCompanyName;
    public string ExactCompanyName
    {
        get
        {
            return strExactCompanyName;
        }
        set
        {
            strExactCompanyName = value;
        }
    }

    private string strOfficeTelephoneNo;
    public string OfficeTelephoneNo
    {
        get
        {
            return strOfficeTelephoneNo;
        }
        set
        {
            strOfficeTelephoneNo = value;
        }
    }
    //Added by Manoj for...YesbankautoLoan
    private string strLoanApplied;
    public string LoanApplied
    {
        get
        {
            return strLoanApplied;
        }
        set
        {
            strLoanApplied = value;
        }
    }
    private string strNoOfwhichTVRdone;
    public string NoOfwhichTVRdone
    {
        get
        {
            return strNoOfwhichTVRdone;
        }
        set
        {
            strNoOfwhichTVRdone = value;
        }
    }
    private string strLoanamount;
    public string Loanamount
    {
        get
        {
            return strLoanamount;
        }
        set
        {
            strLoanamount = value;
        }
    }
    private string strPurposeOf;
    public string PurposeOf
    {
        get
        {
            return strPurposeOf;
        }
        set
        {
            strPurposeOf = value;
        }
    }
    private string strProfileC;
    public string ProfileC
    {
        get
        {
            return strProfileC;
        }
        set
        {
            strProfileC = value;
        }
    }
    private string strIFRented;
    public string IFRented
    {
        get
        {
            return strIFRented;
        }
        set
        {
            strIFRented = value;
        }
    }
    private string strTurnOverB;
    public string TurnOverB
    {
        get
        {
            return strTurnOverB;
        }
        set
        {
            strTurnOverB = value;
        }
    }
    private string strCityStability;
    public string CityStability
    {
        get
        {
            return strCityStability;
        }
        set
        {
            strCityStability = value;
        }
    }
    private string strExistingcarownedbyClient;
    public string ExistingcarownedbyClient
    {
        get
        {
            return strExistingcarownedbyClient;
        }
        set
        {
            strExistingcarownedbyClient = value;
        }
    }
    private string strFinanced;
    public string Financed
    {
        get
        {
            return strFinanced;
        }
        set
        {
            strFinanced = value;
        }
    }
    private string strloannoifreqd;
    public string loannoifreqd
    {
        get
        {
            return strloannoifreqd;
        }
        set
        {
            strloannoifreqd = value;
        }
    }
    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }

    //---------------------------------------
    #endregion Properties Declaration

   
    public Int32 InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[6];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrTeleCallLog)
            {
                AttemptDateTime = item[0].ToString();
                Remark = item[1].ToString();
                TelePhoneNo = item[2].ToString();
                VerifierID = item[3].ToString();

                //////////////////////////////Inserting in table CPV_RL_VERIFICATION_ATTEMPT                 

                sqlQuery = "Insert into CPV_RL_VERIFICATION_ATTEMPT (Case_id,Attempt_Datetime,Attempt_Remark,TELEPHONE_NO,Verification_type_id,VERIFIER_ID)" +
                          "Values(?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                oledbParam[2].Value = Remark;

                oledbParam[3] = new OleDbParameter("@TelePhoneNo", OleDbType.VarChar, 50);
                oledbParam[3].Value = TelePhoneNo;

                oledbParam[4] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[4].Value = VerificationTypeID;

                oledbParam[5] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                oledbParam[5].Value = VerifierID;


                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
                


            }

            oledbTrans.Commit();
            oledbConn.Close();
            return returnValue;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During Insertion" + ex.Message);

        }

    }


    public string InsertResiTelephonicVerification()
    {
        //Updated By Rupesh On 03-May-2013


        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
        string sql = "";
        string msg = "";
        
        try
        {
            sqlQuery = " Select Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_RVRT " +
                       " where Case_ID = '" + CaseID + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);
            //Naresh  Start 14/03/08
            OleDbParameter[] oledbParam = new OleDbParameter[89];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIFICATION_RVRT (Case_ID,VERIFICATION_TYPE_ID,TEL_NO_TYPE_PHONE,Address_Confirmed," +
                       " PERSON_CONTACTED,Relationship,Address,YEARS_AT_RESIDENCE,Company_name,Permanent_address," +
                       " Verifier_Comments,Verification_status,Staying_Since,VERIFICATION_DATETIME,Area,Unsatisfactory_Reason,ADD_BY,ADD_DATE,Staying_Whom, " +
                       " PP_Number,Any_Other_Resi_Phone,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel,Ownership_RESIDENCE,make,loan_Amt,tenure,months,loan_amount, " +
                       " Name_CoApp,Co_AppDob,Address_Confirmed_New,Address_New,Type_of_House,Tran_Date,Area_of_House,Total_cost,loan_Amt_New,Prop_Brought,Relantion_prop,Other_Prop,Name_Guran1,ContactResi1,ContactOff1,PersonCont1,RelanApp1, " +
                       " Relationship1,AddGurent1,howLong1,ReadyGua1,BeenGua1,Status1,Name_Guran2,ContactResi2,ContactOff2,PersonCont2,RelanApp2,Relationship2,AddGurent2,howLong2,ReadyGua2,BeenGua2,Status2,other_feedback,SUPERVISOR_COMMENTS,Off_Tel_No,SPOUSE_DETAILS,Dob,Type,Response,Status,Reason,personcontactedRL,Resvertyp,Agency," +
                    //New added/Updated for CHOLA
                       "ApplicationDate,IFRented,Less1YrAddr,Is_address_same,AddrDiffConf,Name_Neighbour1,Name_Neighbour2,Telephone_Exists,Tele_whose_Name,AddressCDROM,Dedupe_check,CustomerCIFL) " +
                    //END

                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, " +
                       " ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";  //Updated By Rupesh

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@ResidencePhoneNo", OleDbType.VarChar, 100);
                oledbParam[2].Value = ResidencePhoneNo;

                oledbParam[3] = new OleDbParameter("@PersonContactedResiTeleConfirmsApplicantStaysAddress", OleDbType.VarChar, 50);
                oledbParam[3].Value = PersonContactedResiTeleConfirmsApplicantStaysAddress;

                oledbParam[4] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[4].Value = PersonContacted;

                oledbParam[5] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[5].Value = RelationshipWithApplicant;

                oledbParam[6] = new OleDbParameter("@ResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[6].Value = ResidenceAddressAsPerCall;

                oledbParam[7] = new OleDbParameter("@NumberofYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[7].Value = NumberofYearsAtResidence;

                oledbParam[8] = new OleDbParameter("@NameOfEmployer", OleDbType.VarChar, 100);
                oledbParam[8].Value = NameOfEmployer;

                oledbParam[9] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                oledbParam[9].Value = PermanentAddress;

                oledbParam[10] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[10].Value = OverallRemarks;

                oledbParam[11] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[11].Value = Rating;

                oledbParam[12] = new OleDbParameter("@StayingSince", OleDbType.VarChar, 50);
                oledbParam[12].Value = StayingSince;

                oledbParam[13] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[13].Value = VerificationDateAndTime;

                oledbParam[14] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[14].Value = Area;

                oledbParam[15] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[15].Value = UnsatisfactoryReason;

                oledbParam[16] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[16].Value = AddedBy;
                
                oledbParam[17] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                oledbParam[17].Value = AddedOn;

                oledbParam[18] = new OleDbParameter("@Staying_Whom", OleDbType.VarChar,50 );
                oledbParam[18].Value = Staying_Whom;

                oledbParam[19] = new OleDbParameter("@PP_Number", OleDbType.VarChar, 50);
                oledbParam[19].Value = PP_Number;

                oledbParam[20] = new OleDbParameter("@Any_Other_Resi_Phone", OleDbType.VarChar, 50);
                oledbParam[20].Value = Any_Other_Resi_Phone;

                oledbParam[21] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[21].Value = Applicant_Availbility;

                oledbParam[22] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 50);
                oledbParam[22].Value = Dir_Check;

                oledbParam[23] = new OleDbParameter("Name_of_Applicant_Conf", OleDbType.VarChar, 50);
                oledbParam[23].Value = Name_of_Applicant_Conf;

                oledbParam[24] = new OleDbParameter("@Mismatch_Add_Tel", OleDbType.VarChar, 150);
                oledbParam[24].Value = Mismatch_Add_Tel;

                oledbParam[25] = new OleDbParameter("@Ownership_RESIDENCE", OleDbType.VarChar, 150);
                oledbParam[25].Value = OwnershipRESIDENCE;

                oledbParam[26] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[26].Value = make;

                oledbParam[27] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[27].Value = loanAmt;

                oledbParam[28] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[28].Value = tenure; 

                oledbParam[29] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[29].Value = month;

                oledbParam[30] = new OleDbParameter("@NameApp", OleDbType.VarChar, 500);
                oledbParam[30].Value = NameApp;   

                ////////////////////add new code deutch bank 14-july-2010/////////////////////////////////////
                oledbParam[31] = new OleDbParameter("@NameCoApp", OleDbType.VarChar, 500);
                oledbParam[31].Value = NameCoApp;

                oledbParam[32] = new OleDbParameter("@CoAppDob", OleDbType.VarChar, 500);
                oledbParam[32].Value = CoAppDob;

                oledbParam[33] = new OleDbParameter("@AddConf", OleDbType.VarChar, 500);
                oledbParam[33].Value = AddConf;

                oledbParam[34] = new OleDbParameter("@NewHomeAddress", OleDbType.VarChar, 500);
                oledbParam[34].Value = NewHomeAddress;

                oledbParam[35] = new OleDbParameter("@ResiType", OleDbType.VarChar, 500);
                oledbParam[35].Value = ResiType;

                oledbParam[36] = new OleDbParameter("@TranType", OleDbType.VarChar, 500);
                oledbParam[36].Value = TranType;

                oledbParam[37] = new OleDbParameter("@ApproxArea", OleDbType.VarChar, 500);
                oledbParam[37].Value = ApproxArea;

                oledbParam[38] = new OleDbParameter("@TotalCost", OleDbType.VarChar, 500);
                oledbParam[38].Value = TotalCost;

                oledbParam[39] = new OleDbParameter("@LoanAmt", OleDbType.VarChar, 500);
                oledbParam[39].Value = LoanAmt;

                oledbParam[40] = new OleDbParameter("@PropBought", OleDbType.VarChar, 500);
                oledbParam[40].Value = PropBought;

                oledbParam[41] = new OleDbParameter("@RelantionProp", OleDbType.VarChar, 500);
                oledbParam[41].Value = RelantionProp;

                oledbParam[42] = new OleDbParameter("@OtherProp", OleDbType.VarChar, 500);
                oledbParam[42].Value = OtherProp;

                oledbParam[43] = new OleDbParameter("@NameGuran1", OleDbType.VarChar, 500);
                oledbParam[43].Value = NameGuran1;

                oledbParam[44] = new OleDbParameter("@ContactR1", OleDbType.VarChar, 500);
                oledbParam[44].Value = ContactR1;

                oledbParam[45] = new OleDbParameter("@ContactO1", OleDbType.VarChar, 500);
                oledbParam[45].Value = ContactO1;

                oledbParam[46] = new OleDbParameter("@PersonCont1", OleDbType.VarChar, 500);
                oledbParam[46].Value = PersonCont1;

                oledbParam[47] = new OleDbParameter("@RelanApp1", OleDbType.VarChar, 500);
                oledbParam[47].Value = RelanApp1;

                oledbParam[48] = new OleDbParameter("@Relationship1", OleDbType.VarChar, 500);
                oledbParam[48].Value = Relationship1;

                oledbParam[49] = new OleDbParameter("@AddGurent1", OleDbType.VarChar, 500);
                oledbParam[49].Value = AddGurent1;

                oledbParam[50] = new OleDbParameter("@howLong1", OleDbType.VarChar, 500);
                oledbParam[50].Value = howLong1;

                oledbParam[51] = new OleDbParameter("@ReadyGua1", OleDbType.VarChar, 500);
                oledbParam[51].Value = ReadyGua1;

                oledbParam[52] = new OleDbParameter("@BeenGua1", OleDbType.VarChar, 500);
                oledbParam[52].Value = BeenGua1;

                oledbParam[53] = new OleDbParameter("@Status1", OleDbType.VarChar, 500);
                oledbParam[53].Value = Status1;

                oledbParam[54] = new OleDbParameter("@NameGuran2", OleDbType.VarChar, 500);
                oledbParam[54].Value = NameGuran2;

                oledbParam[55] = new OleDbParameter("@ContactR2", OleDbType.VarChar, 500);
                oledbParam[55].Value = ContactR2;

                oledbParam[56] = new OleDbParameter("@ContactO2", OleDbType.VarChar, 500);
                oledbParam[56].Value = ContactO2;

                oledbParam[57] = new OleDbParameter("@PersonCont2", OleDbType.VarChar, 500);
                oledbParam[57].Value = PersonCont2;

                oledbParam[58] = new OleDbParameter("@RelanApp2", OleDbType.VarChar, 500);
                oledbParam[58].Value = RelanApp2;

                oledbParam[59] = new OleDbParameter("@Relationship2", OleDbType.VarChar, 500);
                oledbParam[59].Value = Relationship2;

                oledbParam[60] = new OleDbParameter("@AddGurent2", OleDbType.VarChar, 500);
                oledbParam[60].Value = AddGurent2;

                oledbParam[61] = new OleDbParameter("@howLong2", OleDbType.VarChar, 500);
                oledbParam[61].Value = howLong2;

                oledbParam[62] = new OleDbParameter("@ReadyGua2", OleDbType.VarChar, 500);
                oledbParam[62].Value = ReadyGua2;

                oledbParam[63] = new OleDbParameter("@BeenGua2", OleDbType.VarChar, 500);
                oledbParam[63].Value = BeenGua2;

                oledbParam[64] = new OleDbParameter("@Status2", OleDbType.VarChar, 500);
                oledbParam[64].Value = Status2;

                oledbParam[65] = new OleDbParameter("@AddRem", OleDbType.VarChar, 500);
                oledbParam[65].Value = AddRem;

                oledbParam[66] = new OleDbParameter("@TeleRemark", OleDbType.VarChar, 500);
                oledbParam[66].Value = TeleRemark;

                oledbParam[67] = new OleDbParameter("@OffTelNo", OleDbType.VarChar, 500);
                oledbParam[67].Value = OffTelNo;

                oledbParam[68] = new OleDbParameter("@SpouseWorking", OleDbType.VarChar, 500);
                oledbParam[68].Value = SpouseWorking;

                oledbParam[69] = new OleDbParameter("@CouterDate", OleDbType.VarChar, 500);
                oledbParam[69].Value = CouterDate;

                oledbParam[70] = new OleDbParameter("@ResiIs", OleDbType.VarChar, 500);
                oledbParam[70].Value = ResiIs;
                
                //Updated By Rupesh On 03-05-2015


                oledbParam[71] = new OleDbParameter("@Response", OleDbType.VarChar, 500);
                oledbParam[71].Value = Response;

                  oledbParam[72] = new OleDbParameter("@Status", OleDbType.VarChar, 500);
                oledbParam[72].Value = Status;

                  oledbParam[73] = new OleDbParameter("@Reason", OleDbType.VarChar, 500);
                oledbParam[73].Value = Reason;

                  oledbParam[74] = new OleDbParameter("@personcontactedRL", OleDbType.VarChar, 500);
                oledbParam[74].Value = personcontactedRL;

                  oledbParam[75] = new OleDbParameter("@Resvertyp", OleDbType.VarChar, 500);
                oledbParam[75].Value = Resvertyp;

                  oledbParam[76] = new OleDbParameter("@Agency", OleDbType.VarChar, 500);
                oledbParam[76].Value = Agency;

                //New added/Updated for CHOLA
                oledbParam[77] = new OleDbParameter("@ApplicationDate", OleDbType.VarChar, 50);
                oledbParam[77].Value = ApplicationDate;

                oledbParam[78] = new OleDbParameter("@IFRented", OleDbType.VarChar, 500);
                oledbParam[78].Value = IFRented;

                oledbParam[79] = new OleDbParameter("@Less1YrAddr", OleDbType.VarChar, 500);
                oledbParam[79].Value = Less1YrAddr;

                oledbParam[80] = new OleDbParameter("@Is_address_same", OleDbType.VarChar, 500);
                oledbParam[80].Value = Is_address_same;

                oledbParam[81] = new OleDbParameter("@AddrDiffConf", OleDbType.VarChar, 500);
                oledbParam[81].Value = AddrDiffConf;

                oledbParam[82] = new OleDbParameter("@Name_Neighbour1", OleDbType.VarChar, 500);
                oledbParam[82].Value = Name_Neighbour1;

                oledbParam[83] = new OleDbParameter("@Name_Neighbour2", OleDbType.VarChar, 500);
                oledbParam[83].Value = Name_Neighbour2;

                oledbParam[84] = new OleDbParameter("@Telephone_Exists", OleDbType.VarChar, 500);
                oledbParam[84].Value = Telephone_Exists;

                oledbParam[85] = new OleDbParameter("@Tele_whose_Name", OleDbType.VarChar, 500);
                oledbParam[85].Value = Tele_whose_Name;

                oledbParam[86] = new OleDbParameter("@AddressCDROM", OleDbType.VarChar, 500);
                oledbParam[86].Value = AddressCDROM;

                oledbParam[87] = new OleDbParameter("@Dedupe_check", OleDbType.VarChar, 500);
                oledbParam[87].Value = Dedupe_check;

                oledbParam[88] = new OleDbParameter("@CustomerCIFL", OleDbType.VarChar, 500);
                oledbParam[88].Value = CustomerCIFL;
                //END
                
                //////////////////////end code/////////////////////////////////////////////////////////////
                msg = "Record Added Sucessfully";
                              
                       
            }
            else
            {
                sql = "Update CPV_RL_VERIFICATION_RVRT Set TEL_NO_TYPE_PHONE=?,Address_Confirmed=?," +
                      " PERSON_CONTACTED=?,Relationship=?,Address=?,YEARS_AT_RESIDENCE=?,Company_name=?,Permanent_address=?," +
                      " Verifier_Comments=?,Verification_status=?,Staying_Since=?,VERIFICATION_DATETIME=?,Area=?,Unsatisfactory_Reason=?,MODIFY_BY=?,MODIFY_DATE=?,Staying_Whom=?,"+
                      " PP_Number=?,Any_Other_Resi_Phone=?,Applicant_Availbility=?,Dir_Check=?,Name_of_Applicant_Conf=?,Mismatch_Add_Tel=?,Ownership_RESIDENCE=?,make=?,loan_Amt=?,tenure=?,months=?,loan_amount=?, " +
                      " Name_CoApp=?,Co_AppDob=?,Address_Confirmed_New=?,Address_New=?,Type_of_House=?,Tran_Date=?,Area_of_House=?,Total_cost=?,loan_Amt_New=?,Prop_Brought=?,Relantion_prop=?,Other_Prop=?,Name_Guran1=?,ContactResi1=?,ContactOff1=?,PersonCont1=?,RelanApp1=?," +
                      " Relationship1=?,AddGurent1=?,howLong1=?,ReadyGua1=?,BeenGua1=?,Status1=?,Name_Guran2=?,ContactResi2=?,ContactOff2=?,PersonCont2=?,RelanApp2=?,Relationship2=?,AddGurent2=?,howLong2=?,ReadyGua2=?,BeenGua2=?,Status2=?,other_feedback=?,SUPERVISOR_COMMENTS=?,Off_Tel_No=?,SPOUSE_DETAILS=?,Dob=?,Type=?,Response=?,Status=?,Reason=?,personcontactedRL=?,Resvertyp=?,Agency=?, " +

                    //New added/Updated for CHOLA
                       "ApplicationDate=?,IFRented=?,Less1YrAddr=?,Is_address_same=?,AddrDiffConf=?,Name_Neighbour1=?,Name_Neighbour2=?,Telephone_Exists=?,Tele_whose_Name=?,AddressCDROM=?,Dedupe_check=?,CustomerCIFL=? " +
                    //END
                      
                      " where Case_ID=? and VERIFICATION_TYPE_ID=? ";
                //,Staying_Whom=?
                oledbParam[0] = new OleDbParameter("@ResidencePhoneNo", OleDbType.VarChar, 100);
                oledbParam[0].Value = ResidencePhoneNo;

                oledbParam[1] = new OleDbParameter("@PersonContactedResiTeleConfirmsApplicantStaysAddress", OleDbType.VarChar, 50);
                oledbParam[1].Value = PersonContactedResiTeleConfirmsApplicantStaysAddress;

                oledbParam[2] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[2].Value = PersonContacted;

                oledbParam[3] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[3].Value = RelationshipWithApplicant;

                oledbParam[4] = new OleDbParameter("@ResidenceAddressAsPerCall", OleDbType.VarChar, 255);
                oledbParam[4].Value = ResidenceAddressAsPerCall;

                oledbParam[5] = new OleDbParameter("@NumberofYearsAtResidence", OleDbType.VarChar, 20);
                oledbParam[5].Value = NumberofYearsAtResidence;

                oledbParam[6] = new OleDbParameter("@NameOfEmployer", OleDbType.VarChar, 100);
                oledbParam[6].Value = NameOfEmployer;

                oledbParam[7] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                oledbParam[7].Value = PermanentAddress;

                oledbParam[8] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[8].Value = OverallRemarks;

                oledbParam[9] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[9].Value = Rating;

                oledbParam[10] = new OleDbParameter("@StayingSince", OleDbType.VarChar, 50);
                oledbParam[10].Value = StayingSince;

                oledbParam[11] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[11].Value = VerificationDateAndTime;

                oledbParam[12] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[12].Value = Area;

                oledbParam[13] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[13].Value = UnsatisfactoryReason;

                oledbParam[14] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                oledbParam[14].Value = ModifyBy;

                oledbParam[15] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                oledbParam[15].Value = ModifyOn;

                oledbParam[16] = new OleDbParameter("@Staying_Whom", OleDbType.VarChar, 50);
                oledbParam[16].Value = Staying_Whom;


                oledbParam[17] = new OleDbParameter("@PP_Number", OleDbType.VarChar, 50);
                oledbParam[17].Value = PP_Number;

                oledbParam[18] = new OleDbParameter("@Any_Other_Resi_Phone", OleDbType.VarChar, 50);
                oledbParam[18].Value = Any_Other_Resi_Phone;

                oledbParam[19] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[19].Value = Applicant_Availbility;

                oledbParam[20] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 50);
                oledbParam[20].Value = Dir_Check;

                oledbParam[21] = new OleDbParameter("Name_of_Applicant_Conf", OleDbType.VarChar, 50);
                oledbParam[21].Value = Name_of_Applicant_Conf;

                oledbParam[22] = new OleDbParameter("@Mismatch_Add_Tel", OleDbType.VarChar, 150);
                oledbParam[22].Value = Mismatch_Add_Tel;

                oledbParam[23] = new OleDbParameter("@Ownership_RESIDENCE", OleDbType.VarChar, 150);
                oledbParam[23].Value = OwnershipRESIDENCE;

                oledbParam[24] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[24].Value = make;

                oledbParam[25] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[25].Value = loanAmt;

                oledbParam[26] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[26].Value = tenure;

                oledbParam[27] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[27].Value = month;

                oledbParam[28] = new OleDbParameter("@NameApp", OleDbType.VarChar, 500);
                oledbParam[28].Value = NameApp;

                ////////////////////add new code deutch bank 14-july-2010/////////////////////////////////////
                oledbParam[29] = new OleDbParameter("@NameCoApp", OleDbType.VarChar, 500);
                oledbParam[29].Value = NameCoApp;

                oledbParam[30] = new OleDbParameter("@CoAppDob", OleDbType.VarChar, 500);
                oledbParam[30].Value = CoAppDob;

                oledbParam[31] = new OleDbParameter("@AddConf", OleDbType.VarChar, 500);
                oledbParam[31].Value = AddConf;

                oledbParam[32] = new OleDbParameter("@NewHomeAddress", OleDbType.VarChar, 500);
                oledbParam[32].Value = NewHomeAddress;

                oledbParam[33] = new OleDbParameter("@ResiType", OleDbType.VarChar, 500);
                oledbParam[33].Value = ResiType;

                oledbParam[34] = new OleDbParameter("@TranType", OleDbType.VarChar, 500);
                oledbParam[34].Value = TranType;

                oledbParam[35] = new OleDbParameter("@ApproxArea", OleDbType.VarChar, 500);
                oledbParam[35].Value = ApproxArea;

                oledbParam[36] = new OleDbParameter("@TotalCost", OleDbType.VarChar, 500);
                oledbParam[36].Value = TotalCost;

                oledbParam[37] = new OleDbParameter("@LoanAmt", OleDbType.VarChar, 500);
                oledbParam[37].Value = LoanAmt;

                oledbParam[38] = new OleDbParameter("@PropBought", OleDbType.VarChar, 500);
                oledbParam[38].Value = PropBought;

                oledbParam[39] = new OleDbParameter("@RelantionProp", OleDbType.VarChar, 500);
                oledbParam[39].Value = RelantionProp;

                oledbParam[40] = new OleDbParameter("@OtherProp", OleDbType.VarChar, 500);
                oledbParam[40].Value = OtherProp;

                oledbParam[41] = new OleDbParameter("@NameGuran1", OleDbType.VarChar, 500);
                oledbParam[41].Value = NameGuran1;

                oledbParam[42] = new OleDbParameter("@ContactR1", OleDbType.VarChar, 500);
                oledbParam[42].Value = ContactR1;

                oledbParam[43] = new OleDbParameter("@ContactO1", OleDbType.VarChar, 500);
                oledbParam[43].Value = ContactO1;

                oledbParam[44] = new OleDbParameter("@PersonCont1", OleDbType.VarChar, 500);
                oledbParam[44].Value = PersonCont1;

                oledbParam[45] = new OleDbParameter("@RelanApp1", OleDbType.VarChar, 500);
                oledbParam[45].Value = RelanApp1;

                oledbParam[46] = new OleDbParameter("@Relationship1", OleDbType.VarChar, 500);
                oledbParam[46].Value = Relationship1;

                oledbParam[47] = new OleDbParameter("@AddGurent1", OleDbType.VarChar, 500);
                oledbParam[47].Value = AddGurent1;

                oledbParam[48] = new OleDbParameter("@howLong1", OleDbType.VarChar, 500);
                oledbParam[48].Value = howLong1;

                oledbParam[49] = new OleDbParameter("@ReadyGua1", OleDbType.VarChar, 500);
                oledbParam[49].Value = ReadyGua1;

                oledbParam[50] = new OleDbParameter("@BeenGua1", OleDbType.VarChar, 500);
                oledbParam[50].Value = BeenGua1;

                oledbParam[51] = new OleDbParameter("@Status1", OleDbType.VarChar, 500);
                oledbParam[51].Value = Status1;

                oledbParam[52] = new OleDbParameter("@NameGuran2", OleDbType.VarChar, 500);
                oledbParam[52].Value = NameGuran2;

                oledbParam[53] = new OleDbParameter("@ContactR2", OleDbType.VarChar, 500);
                oledbParam[53].Value = ContactR2;

                oledbParam[54] = new OleDbParameter("@ContactO2", OleDbType.VarChar, 500);
                oledbParam[54].Value = ContactO2;

                oledbParam[55] = new OleDbParameter("@PersonCont2", OleDbType.VarChar, 500);
                oledbParam[55].Value = PersonCont2;

                oledbParam[56] = new OleDbParameter("@RelanApp2", OleDbType.VarChar, 500);
                oledbParam[56].Value = RelanApp2;

                oledbParam[57] = new OleDbParameter("@Relationship2", OleDbType.VarChar, 500);
                oledbParam[57].Value = Relationship2;

                oledbParam[58] = new OleDbParameter("@AddGurent2", OleDbType.VarChar, 500);
                oledbParam[58].Value = AddGurent2;

                oledbParam[59] = new OleDbParameter("@howLong2", OleDbType.VarChar, 500);
                oledbParam[59].Value = howLong2;

                oledbParam[60] = new OleDbParameter("@ReadyGua2", OleDbType.VarChar, 500);
                oledbParam[60].Value = ReadyGua2;

                oledbParam[61] = new OleDbParameter("@BeenGua2", OleDbType.VarChar, 500);
                oledbParam[61].Value = BeenGua2;

                oledbParam[62] = new OleDbParameter("@Status2", OleDbType.VarChar, 500);
                oledbParam[62].Value = Status2;

                oledbParam[63] = new OleDbParameter("@AddRem", OleDbType.VarChar, 500);
                oledbParam[63].Value = AddRem;

                oledbParam[64] = new OleDbParameter("@TeleRemark", OleDbType.VarChar, 500);
                oledbParam[64].Value = TeleRemark;

                oledbParam[65] = new OleDbParameter("@OffTelNo", OleDbType.VarChar, 500);
                oledbParam[65].Value = OffTelNo;

                oledbParam[66] = new OleDbParameter("@SpouseWorking", OleDbType.VarChar, 500);
                oledbParam[66].Value = SpouseWorking;

                oledbParam[67] = new OleDbParameter("@CouterDate", OleDbType.VarChar, 500);
                oledbParam[67].Value = CouterDate;

                oledbParam[68] = new OleDbParameter("@ResiIs", OleDbType.VarChar, 500);
                oledbParam[68].Value = ResiIs;


                //Updated By Rupesh On 03-05-2015
                
                oledbParam[69] = new OleDbParameter("@Response", OleDbType.VarChar, 500);
                oledbParam[69].Value = Response;

                oledbParam[70] = new OleDbParameter("@Status", OleDbType.VarChar, 500);
                oledbParam[70].Value = Status;

                oledbParam[71] = new OleDbParameter("@Reason", OleDbType.VarChar, 500);
                oledbParam[71].Value = Reason;

                oledbParam[72] = new OleDbParameter("@personcontactedRL", OleDbType.VarChar, 500);
                oledbParam[72].Value = personcontactedRL;

                oledbParam[73] = new OleDbParameter("@Resvertyp", OleDbType.VarChar, 500);
                oledbParam[73].Value = Resvertyp;

                oledbParam[74] = new OleDbParameter("@Agency", OleDbType.VarChar, 500);
                oledbParam[74].Value = Agency;

                //New added/Updated for CHOLA
                oledbParam[75] = new OleDbParameter("@ApplicationDate", OleDbType.VarChar, 50);
                oledbParam[75].Value = ApplicationDate;

                oledbParam[76] = new OleDbParameter("@IFRented", OleDbType.VarChar, 500);
                oledbParam[76].Value = IFRented;

                oledbParam[77] = new OleDbParameter("@Less1YrAddr", OleDbType.VarChar, 500);
                oledbParam[77].Value = Less1YrAddr;

                oledbParam[78] = new OleDbParameter("@Is_address_same", OleDbType.VarChar, 500);
                oledbParam[78].Value = Is_address_same;

                oledbParam[79] = new OleDbParameter("@AddrDiffConf", OleDbType.VarChar, 500);
                oledbParam[79].Value = AddrDiffConf;

                oledbParam[80] = new OleDbParameter("@Name_Neighbour1", OleDbType.VarChar, 500);
                oledbParam[80].Value = Name_Neighbour1;

                oledbParam[81] = new OleDbParameter("@Name_Neighbour2", OleDbType.VarChar, 500);
                oledbParam[81].Value = Name_Neighbour2;

                oledbParam[82] = new OleDbParameter("@Telephone_Exists", OleDbType.VarChar, 500);
                oledbParam[82].Value = Telephone_Exists;

                oledbParam[83] = new OleDbParameter("@Tele_whose_Name", OleDbType.VarChar, 500);
                oledbParam[83].Value = Tele_whose_Name;

                oledbParam[84] = new OleDbParameter("@AddressCDROM", OleDbType.VarChar, 500);
                oledbParam[84].Value = AddressCDROM;

                oledbParam[85] = new OleDbParameter("@Dedupe_check", OleDbType.VarChar, 500);
                oledbParam[85].Value = Dedupe_check;

                oledbParam[86] = new OleDbParameter("@CustomerCIFL", OleDbType.VarChar, 500);
                oledbParam[86].Value = CustomerCIFL;
                //END
                //////////////////////end code/////////////////////////////////////////////////////////////

                oledbParam[87] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[87].Value = CaseID;

                oledbParam[88] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[88].Value = VerificationTypeID;

                //////////////////////end code/////////////////////////////////////////////////////////////
                

                msg = "Record Updated Sucessfully";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeID;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            //if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
            //{
            //    VerificationComplete(oledbTrans, CaseID);
            //    msg += " Case verification data entry completed.";
            //}
            
            if (VerificationTypeID == "25" || VerificationTypeID == "26" || VerificationTypeID == "27" || VerificationTypeID == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";

                }
            }
                       
           /////////////////////////////////////////////////////////////////////////////////////////////

            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }

    public string InsertResiTelephonicVerification_New()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
        string sql = "";
        string msg = "";

        try
        {
            sqlQuery = " Select Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIVICATION_RESBUSI " +
                       " where Case_ID = '" + CaseID + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);
            //Naresh  Start 14/03/08
            OleDbParameter[] oledbParam = new OleDbParameter[31];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIVICATION_RESBUSI (Case_ID,VERIFICATION_TYPE_ID,Name_Neighbour1,Address_Neighbour1,Neighbour1_confirmation, " + 
                      " Month_at_office,Month_Stay_Resi_Neigh1,Market_Reputation_Neighbour1,Office_self_owned1,Comments_Neighbour1,Name_Neighbour2, " +
                      " Address_Neighbour2,Neighbour1_confirmation2,Month_at_office1,Month_Stay_Resi_Neigh2,Agency_Code,Months_work_current_office,Person_contacted, " +
                      " Ward,TaxCal,TaxCalcu,TaxPaid,TazPay,SpouseDesg,Office_Name,LoanApplied,NoOfwhichTVRdone," +
                    //New added/Updated for CHOLA
                      "Neighbour1_Comments,Neighbour_Telephone2,Neighbour2_confirmation,Neighbour2_Comments)" +
                    //END
                      " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                oledbParam[2].Value = RefName;

                oledbParam[3] = new OleDbParameter("@RefTel", OleDbType.VarChar, 500);
                oledbParam[3].Value = RefTel;

                oledbParam[4] = new OleDbParameter("@RelRef", OleDbType.VarChar, 500);
                oledbParam[4].Value = RelRef;

                oledbParam[5] = new OleDbParameter("@KnowGua", OleDbType.VarChar, 500);
                oledbParam[5].Value = KnowGua;

                oledbParam[6] = new OleDbParameter("@KnowRef", OleDbType.VarChar, 500);
                oledbParam[6].Value = KnowRef;

                oledbParam[7] = new OleDbParameter("@EmpDetGua", OleDbType.VarChar, 500);
                oledbParam[7].Value = EmpDetGua;

                oledbParam[8] = new OleDbParameter("@EmpDetRef", OleDbType.VarChar, 500);
                oledbParam[8].Value = EmpDetRef;

                oledbParam[9] = new OleDbParameter("@OthLoanGua", OleDbType.VarChar, 500);
                oledbParam[9].Value = OthLoanGua;

                oledbParam[10] = new OleDbParameter("@OthLoanRef", OleDbType.VarChar, 500);
                oledbParam[10].Value = OthLoanRef;

                oledbParam[11] = new OleDbParameter("@LibGua", OleDbType.VarChar, 500);
                oledbParam[11].Value = LibGua;

                oledbParam[12] = new OleDbParameter("@LibRef", OleDbType.VarChar, 500);
                oledbParam[12].Value = LibRef;

                oledbParam[13] = new OleDbParameter("@EmiGua", OleDbType.VarChar, 500);
                oledbParam[13].Value = EmiGua;

                oledbParam[14] = new OleDbParameter("@EmiRef", OleDbType.VarChar, 500);
                oledbParam[14].Value = EmiRef;

                oledbParam[15] = new OleDbParameter("@Agency_Code", OleDbType.VarChar, 500);
                oledbParam[15].Value = Agency_Code;

                oledbParam[16] = new OleDbParameter("@Months_work_current_office", OleDbType.VarChar, 500);
                oledbParam[16].Value = Months_work_current_office;

                oledbParam[17] = new OleDbParameter("@PerCon", OleDbType.VarChar, 500);
                oledbParam[17].Value = PerCon;

                oledbParam[18] = new OleDbParameter("@Region", OleDbType.VarChar, 500);
                oledbParam[18].Value = Region;

                oledbParam[19] = new OleDbParameter("@EarningMembers", OleDbType.VarChar, 500);
                oledbParam[19].Value = EarningMembers;

                oledbParam[20] = new OleDbParameter("@Dependents", OleDbType.VarChar, 500);
                oledbParam[20].Value = Dependents;

                oledbParam[21] = new OleDbParameter("@ParenteDetails", OleDbType.VarChar, 500);
                oledbParam[21].Value = ParenteDetails;

                oledbParam[22] = new OleDbParameter("@ReasonDecline", OleDbType.VarChar, 500);
                oledbParam[22].Value = ReasonDecline;

                oledbParam[23] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 500);
                oledbParam[23].Value = AppDesignation;

                oledbParam[24] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 500);
                oledbParam[24].Value = NameOfCompany;

                oledbParam[25] = new OleDbParameter("@LoanApplied", OleDbType.VarChar, 500);
                oledbParam[25].Value = LoanApplied;

                oledbParam[26] = new OleDbParameter("@NoOfwhichTVRdone", OleDbType.VarChar, 500);
                oledbParam[26].Value = NoOfwhichTVRdone;

                //New added/Updated for CHOLA
                oledbParam[27] = new OleDbParameter("@Neighbour1_Comments", OleDbType.VarChar, 500);
                oledbParam[27].Value = Neighbour1_Comments;

                oledbParam[28] = new OleDbParameter("@Neighbour_Telephone2", OleDbType.VarChar, 500);
                oledbParam[28].Value = Neighbour_Telephone2;

                oledbParam[29] = new OleDbParameter("@Neighbour2_confirmation", OleDbType.VarChar, 500);
                oledbParam[29].Value = Neighbour2_confirmation;

                oledbParam[30] = new OleDbParameter("@Neighbour2_Comments", OleDbType.VarChar, 500);
                oledbParam[30].Value = Neighbour2_Comments;
                //END

                //////////////////////end code/////////////////////////////////////////////////////////////
                msg = "Record Added Sucessfully";
                
            }
            else
            {
                sql = "Update CPV_RL_VERIVICATION_RESBUSI Set Name_Neighbour1=?,Address_Neighbour1=?,Neighbour1_confirmation=?, " +
                      " Month_at_office=?,Month_Stay_Resi_Neigh1=?,Market_Reputation_Neighbour1=?,Office_self_owned1=?,Comments_Neighbour1=?, " +
                      " Name_Neighbour2=?,Address_Neighbour2=?,Neighbour1_confirmation2=?,Month_at_office1=?,Month_Stay_Resi_Neigh2=?,Agency_Code=?,Months_work_current_office=?, " +
                      " Person_contacted=?,Ward=?,TaxCal=?,TaxCalcu=?,TaxPaid=?,TazPay=?,SpouseDesg=?,Office_Name=?,LoanApplied=?,NoOfwhichTVRdone=?, " +
                    //New added/Updated for CHOLA
                      "Neighbour1_Comments=?,Neighbour_Telephone2=?,Neighbour2_confirmation=?,Neighbour2_Comments=? " +
                    //END
                      " where Case_ID=? and VERIFICATION_TYPE_ID=? ";
                //,Staying_Whom=?
                oledbParam[0] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                oledbParam[0].Value = RefName;

                oledbParam[1] = new OleDbParameter("@RefTel", OleDbType.VarChar, 500);
                oledbParam[1].Value = RefTel;

                oledbParam[2] = new OleDbParameter("@RelRef", OleDbType.VarChar, 500);
                oledbParam[2].Value = RelRef;

                oledbParam[3] = new OleDbParameter("@KnowGua", OleDbType.VarChar, 500);
                oledbParam[3].Value = KnowGua;

                oledbParam[4] = new OleDbParameter("@KnowRef", OleDbType.VarChar, 500);
                oledbParam[4].Value = KnowRef;

                oledbParam[5] = new OleDbParameter("@EmpDetGua", OleDbType.VarChar, 500);
                oledbParam[5].Value = EmpDetGua;

                oledbParam[6] = new OleDbParameter("@EmpDetRef", OleDbType.VarChar, 500);
                oledbParam[6].Value = EmpDetRef;

                oledbParam[7] = new OleDbParameter("@OthLoanGua", OleDbType.VarChar, 500);
                oledbParam[7].Value = OthLoanGua;

                oledbParam[8] = new OleDbParameter("@OthLoanRef", OleDbType.VarChar, 500);
                oledbParam[8].Value = OthLoanRef;

                oledbParam[9] = new OleDbParameter("@LibGua", OleDbType.VarChar, 500);
                oledbParam[9].Value = LibGua;

                oledbParam[10] = new OleDbParameter("@LibRef", OleDbType.VarChar, 500);
                oledbParam[10].Value = LibRef;

                oledbParam[11] = new OleDbParameter("@EmiGua", OleDbType.VarChar, 500);
                oledbParam[11].Value = EmiGua;

                oledbParam[12] = new OleDbParameter("@EmiRef", OleDbType.VarChar, 500);
                oledbParam[12].Value = EmiRef;

                oledbParam[13] = new OleDbParameter("@Agency_Code", OleDbType.VarChar, 500);
                oledbParam[13].Value = Agency_Code;

                oledbParam[14] = new OleDbParameter("@Months_work_current_office", OleDbType.VarChar, 500);
                oledbParam[14].Value = Months_work_current_office;

                oledbParam[15] = new OleDbParameter("@PerCon", OleDbType.VarChar, 500);
                oledbParam[15].Value = PerCon;

                oledbParam[16] = new OleDbParameter("@Region", OleDbType.VarChar, 500);
                oledbParam[16].Value = Region;

                oledbParam[17] = new OleDbParameter("@EarningMembers", OleDbType.VarChar, 500);
                oledbParam[17].Value = EarningMembers;

                oledbParam[18] = new OleDbParameter("@Dependents", OleDbType.VarChar, 500);
                oledbParam[18].Value = Dependents;

                oledbParam[19] = new OleDbParameter("@ParenteDetails", OleDbType.VarChar, 500);
                oledbParam[19].Value = ParenteDetails;

                oledbParam[20] = new OleDbParameter("@ReasonDecline", OleDbType.VarChar, 500);
                oledbParam[20].Value = ReasonDecline;

                oledbParam[21] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 500);
                oledbParam[21].Value = AppDesignation;

                oledbParam[22] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 500);
                oledbParam[22].Value = NameOfCompany;

                oledbParam[23] = new OleDbParameter("@LoanApplied", OleDbType.VarChar, 500);
                oledbParam[23].Value = LoanApplied;

                oledbParam[24] = new OleDbParameter("@NoOfwhichTVRdone", OleDbType.VarChar, 500);
                oledbParam[24].Value = NoOfwhichTVRdone;

                //New added/Updated for CHOLA
                oledbParam[25] = new OleDbParameter("@Neighbour1_Comments", OleDbType.VarChar, 500);
                oledbParam[25].Value = Neighbour1_Comments;

                oledbParam[26] = new OleDbParameter("@Neighbour_Telephone2", OleDbType.VarChar, 500);
                oledbParam[26].Value = Neighbour_Telephone2;

                oledbParam[27] = new OleDbParameter("@Neighbour2_confirmation", OleDbType.VarChar, 500);
                oledbParam[27].Value = Neighbour2_confirmation;

                oledbParam[28] = new OleDbParameter("@Neighbour2_Comments", OleDbType.VarChar, 500);
                oledbParam[28].Value = Neighbour2_Comments;
                //END

                oledbParam[29] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[29].Value = CaseID;

                oledbParam[30] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[30].Value = VerificationTypeID;
                    
                
                msg = "Record Updated Sucessfully";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);
            
            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeID;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

         


            if (VerificationTypeID == "25" || VerificationTypeID == "26" || VerificationTypeID == "27" || VerificationTypeID == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";

                }
            }


            /////////////////////////////////////////////////////////////////////////////////////////////

            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }

    public OleDbDataReader GetResiTelephonicVerification(string sCaseId, string sVerificationTypeID)
    {

        //Updated By Rupesh On 03-May-2013
        string sSql = "";
        sSql = " SELECT TEL_NO_TYPE_PHONE,Address_Confirmed," +
               " PERSON_CONTACTED,Relationship,Address,YEARS_AT_RESIDENCE,Company_name,Permanent_address," +
               " Verifier_Comments,Verification_status,Staying_Since,VERIFICATION_DATETIME,Area,Unsatisfactory_Reason,Staying_Whom,"+
               " PP_Number,Any_Other_Resi_Phone ,Applicant_Availbility,Dir_Check,Name_of_Applicant_Conf,Mismatch_Add_Tel,Ownership_RESIDENCE,make,loan_Amt, " +
               " tenure,months,loan_amount,Name_CoApp,Co_AppDob,Address_Confirmed_New,Address_New,Type_of_House,Tran_Date,Area_of_House,Total_cost,loan_Amt_new,Prop_Brought,Relantion_prop,Other_Prop, " +
               " Name_Guran1,ContactResi1,ContactOff1,PersonCont1,RelanApp1,Relationship1,AddGurent1,howLong1,ReadyGua1,BeenGua1,Status1,Name_Guran2,ContactResi2,ContactOff2,PersonCont2,RelanApp2,Relationship2,AddGurent2, " +
               " howLong2,ReadyGua2,BeenGua2,Status2,other_feedback,SUPERVISOR_COMMENTS,Off_Tel_No,SPOUSE_DETAILS,Dob,Type,Response,Status,Reason,personcontactedRL,Resvertyp,Agency,  " +
            //New added/Updated for CHOLA
            "ApplicationDate,IFRented,Less1YrAddr,Is_address_same,AddrDiffConf,Name_Neighbour1,Name_Neighbour2,Telephone_Exists,Tele_whose_Name,AddressCDROM,Dedupe_check,CustomerCIFL " +
            //END
               " From CPV_RL_VERIFICATION_RVRT where Case_ID='" + sCaseId + "'" + " and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }

    public OleDbDataReader GetResiTelephonicVerification_New(string sCaseId, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = " SELECT Name_Neighbour1,Address_Neighbour1,Neighbour1_confirmation,Month_at_office,Month_Stay_Resi_Neigh1, " +
               " Market_Reputation_Neighbour1,Office_self_owned1,Comments_Neighbour1,Name_Neighbour2,Address_Neighbour2, " +
               " Neighbour1_confirmation2,Month_at_office1,Month_Stay_Resi_Neigh2,Agency_Code,Months_work_current_office,Person_contacted, " +
               " Ward,TaxCal,TaxCalcu,TaxPaid,TazPay,SpouseDesg,Office_Name,LoanApplied,NoOfwhichTVRdone," +
            //New added/Updated for CHOLA
            "Neighbour1_Comments,Neighbour_Telephone2,Neighbour2_confirmation,Neighbour2_Comments " +
            //END
               " From CPV_RL_VERIVICATION_RESBUSI where Case_ID='" + sCaseId + "'" + " and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    }


    public OleDbDataReader GetResiCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT RES_PHONE,OFF_NAME,(isNull(RES_ADD_LINE_1,'')+' '+isnull(RES_ADD_LINE_2,'')+' '+isnull(RES_ADD_LINE_3,'')) as Residence_Address " +
                "  from CPV_RL_CASE_DETAILS where Case_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);


    }



    public OleDbDataReader GetCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT (isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME," +
                " REF_NO, CASE_REC_DATETIME,App_Type,Off_Name,DESIGNATION,DEPARTMENT,DOB " +
                " FROM CPV_RL_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public string InsertBusiTelephonicVerification()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        string sqlQuery = "";
        string sql = "";
        string msg = "";
       
        try
        {
            sqlQuery = " Select case_id,verification_type_id from CPV_RL_VERIFICATION_BVBT " +
                       " where Case_ID = '" + CaseID + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";

            oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);

            OleDbParameter[] oledbParam = new OleDbParameter[62];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_RL_VERIFICATION_BVBT (Case_ID,VERIFICATION_TYPE_ID," +
                       " Person_Contacted,Designation_contacted_person,Designation,No_year_service,Nature_Business," +
                       " Type_Industry,Type_Office,Office_Address,Remarks,Rating,In_Bussiness_since,PERSON_CONFIRM_ADDRESS," +
                       " Is_address_same,Unsatisfactory_Reason,VERIFICATION_DATETIME,Area,ADD_BY,ADD_DATE,Applicant_Availbility, " +
                       " Dir_Check,YEARS_AT_RESIDENCE,Office_Ownership,telephone_check,Relationship_applicant,make,loan_amt,tenure,months,Product_name, " +
                       " Verifier_Comment,Name_business,No_yrs_previous_Employment,Landmark,Total_No_employee,WorkExp,EmployerName,Age_applicant,Purpose_loan,IfFinanceNameOfBank, " +
                       " Office_Name,Type_oF_Phone,TYPE_OF_MOBILE,LoanApplied,Loanamount,PurposeOf,ProfileC,NoOfwhichTVRdone,IFRented,TurnOverB,CityStability,ExistingcarownedbyClient,Financed,loannoifreqd, " +
                    //New added/Updated for CHOLA
                "ApplicationDate,AddrDiffConf,Telephone_Exists,Tele_whose_Name,AddressCDROM," +
                    //END
                    //Added for SBI
                "Type_Organization,TazPay)" +
                    //END

                    
                    " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[1].Value = VerificationTypeID;

                oledbParam[2] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 50);
                oledbParam[2].Value = PersonContacted;

                oledbParam[3] = new OleDbParameter("@DesignationOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[3].Value = DesignationOfPersonContacted;

                oledbParam[4] = new OleDbParameter("@ExactDesignationOfApplicant", OleDbType.VarChar, 100);
                oledbParam[4].Value = ExactDesignationOfApplicant;

                oledbParam[5] = new OleDbParameter("@NoOfYearsWithTheCompany", OleDbType.VarChar, 50);
                oledbParam[5].Value = NoOfYearsWithTheCompany;

                oledbParam[6] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[6].Value = NatureOfBusiness;

                oledbParam[7] = new OleDbParameter("@MainlineBusinessOfTheCompany", OleDbType.VarChar, 100);
                oledbParam[7].Value = MainlineBusinessOfTheCompany;

                oledbParam[8] = new OleDbParameter("@CategoryOfCompany", OleDbType.VarChar, 50);
                oledbParam[8].Value = CategoryOfCompany;

                oledbParam[9] = new OleDbParameter("@OfficeBusinessAddressAsPerCall", OleDbType.VarChar, 100);
                oledbParam[9].Value = OfficeBusinessAddressAsPerCall;

                oledbParam[10] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[10].Value = OverallRemarks;

                oledbParam[11] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[11].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[11].Value = Rating;
                }

                oledbParam[12] = new OleDbParameter("@InBusinessSince", OleDbType.VarChar, 30);
                oledbParam[12].Value = InBusinessSince;

                oledbParam[13] = new OleDbParameter("@PersonContactedOffiTeleConfirmsApplicantWorksAddress", OleDbType.VarChar, 50);
                oledbParam[13].Value = PersonContactedOffiTeleConfirmsApplicantWorksAddress;

                oledbParam[14] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[14].Value = AddressDifferent;

                oledbParam[15] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[15].Value = UnsatisfactoryReason;

                oledbParam[16] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[16].Value = VerificationDateAndTime;

                oledbParam[17] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[17].Value = Area;

                oledbParam[18] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[18].Value = AddedBy;

                oledbParam[19] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                oledbParam[19].Value = AddedOn;

                oledbParam[20] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[20].Value = Applicant_Availbility;

                oledbParam[21] = new OleDbParameter("Dir_Check", OleDbType.VarChar, 50);
                oledbParam[21].Value = Dir_Check;

                oledbParam[22] = new OleDbParameter("@Years_At_Residence", OleDbType.VarChar, 50);
                oledbParam[22].Value = Years_At_Residence;

                oledbParam[23] = new OleDbParameter("@Ownership", OleDbType.VarChar, 50);
                oledbParam[23].Value = Ownership;

                oledbParam[24] = new OleDbParameter("@telephone_check", OleDbType.VarChar, 500);
                oledbParam[24].Value = Extn;

                oledbParam[25] = new OleDbParameter("@Relationship_applicant", OleDbType.VarChar, 50);
                oledbParam[25].Value = relantion;

                oledbParam[26] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[26].Value = make;

                oledbParam[27] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[27].Value = loanAmt;

                oledbParam[28] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[28].Value = tenure;

                oledbParam[29] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[29].Value = month;

                oledbParam[30] = new OleDbParameter("@ProdName", OleDbType.VarChar, 500);
                oledbParam[30].Value = ProdName;

                oledbParam[31] = new OleDbParameter("@TeleRemark", OleDbType.VarChar, 500);
                oledbParam[31].Value = TeleRemark;

                oledbParam[32] = new OleDbParameter("@BusinessNature", OleDbType.VarChar, 500);
                oledbParam[32].Value = BusinessNature;

                oledbParam[33] = new OleDbParameter("@NoOfYearsAtSameAddress", OleDbType.VarChar, 500);
                oledbParam[33].Value = NoOfYearsAtSameAddress;

                oledbParam[34] = new OleDbParameter("@Landmark", OleDbType.VarChar, 500);
                oledbParam[34].Value = Landmark;

                oledbParam[35] = new OleDbParameter("@TotalNoOfEmployee", OleDbType.VarChar, 500);
                oledbParam[35].Value = TotalNoOfEmployee;

                oledbParam[36] = new OleDbParameter("@WorkExp", OleDbType.VarChar, 500);
                oledbParam[36].Value = WorkExp;

                oledbParam[37] = new OleDbParameter("@EmployerName", OleDbType.VarChar, 500);
                oledbParam[37].Value = EmployerName;

                oledbParam[38] = new OleDbParameter("@AppAge", OleDbType.VarChar, 500);
                oledbParam[38].Value = AppAge;

                oledbParam[39] = new OleDbParameter("@MailAdd", OleDbType.VarChar, 500);
                oledbParam[39].Value = MailAdd;

                oledbParam[40] = new OleDbParameter("@IncomeDoc", OleDbType.VarChar, 500);
                oledbParam[40].Value = IncomeDoc;

                oledbParam[41] = new OleDbParameter("@ExactCompanyName", OleDbType.VarChar, 500);
                oledbParam[41].Value = ExactCompanyName;

                oledbParam[42] = new OleDbParameter("@OfficeTelephoneNo", OleDbType.VarChar, 500);
                oledbParam[42].Value = OfficeTelephoneNo;

                oledbParam[43] = new OleDbParameter("@ResidencePhoneNoBT", OleDbType.VarChar, 500);
                oledbParam[43].Value = ResidencePhoneNoBT;

                oledbParam[44] = new OleDbParameter("@LoanApplied", OleDbType.VarChar, 500);
                oledbParam[44].Value = LoanApplied;

                oledbParam[45] = new OleDbParameter("@Loanamount", OleDbType.VarChar, 500);
                oledbParam[45].Value = Loanamount;

                oledbParam[46] = new OleDbParameter("@PurposeOf", OleDbType.VarChar, 500);
                oledbParam[46].Value = PurposeOf;

                oledbParam[47] = new OleDbParameter("@ProfileC", OleDbType.VarChar, 500);
                oledbParam[47].Value = ProfileC;

                oledbParam[48] = new OleDbParameter("@NoOfwhichTVRdone", OleDbType.VarChar, 500);
                oledbParam[48].Value = NoOfwhichTVRdone;

                oledbParam[49] = new OleDbParameter("@IFRented", OleDbType.VarChar, 500);
                oledbParam[49].Value = IFRented;

                oledbParam[50] = new OleDbParameter("@TurnOverB", OleDbType.VarChar, 500);
                oledbParam[50].Value = TurnOverB;

                oledbParam[51] = new OleDbParameter("@CityStability", OleDbType.VarChar, 500);
                oledbParam[51].Value = CityStability;

                oledbParam[52] = new OleDbParameter("@ExistingcarownedbyClient", OleDbType.VarChar, 500);
                oledbParam[52].Value = ExistingcarownedbyClient;

                oledbParam[53] = new OleDbParameter("@Financed", OleDbType.VarChar, 500);
                oledbParam[53].Value = Financed;

                oledbParam[54] = new OleDbParameter("@loannoifreqd", OleDbType.VarChar, 500);
                oledbParam[54].Value = loannoifreqd;

                //New added/Updated for CHOLA
                oledbParam[55] = new OleDbParameter("@ApplicationDate", OleDbType.VarChar,50);
                oledbParam[55].Value = ApplicationDate;
                oledbParam[56] = new OleDbParameter("@AddrDiffConf", OleDbType.VarChar, 500);
                oledbParam[56].Value = AddrDiffConf;
                oledbParam[57] = new OleDbParameter("@Telephone_Exists", OleDbType.VarChar, 500);
                oledbParam[57].Value = Telephone_Exists;
                oledbParam[58] = new OleDbParameter("@Tele_whose_Name", OleDbType.VarChar, 500);
                oledbParam[58].Value = Tele_whose_Name;
                oledbParam[59] = new OleDbParameter("@AddressCDROM", OleDbType.VarChar, 500);
                oledbParam[59].Value = AddressCDROM;
                //END

                //Added for SBI
                oledbParam[60] = new OleDbParameter("@Type_Organization", OleDbType.VarChar, 50);
                oledbParam[60].Value = Type_Office;

                oledbParam[61] = new OleDbParameter("@ReasonDecline", OleDbType.VarChar, 50);
                oledbParam[61].Value = ReasonDecline;
                //END for SBI


                msg = "Record Added Sucessfully";
           
            }
            else
            {

                sql = "Update CPV_RL_VERIFICATION_BVBT Set Person_Contacted=?,Designation_contacted_person=?," +
                      " Designation=?,No_year_service=?,Nature_Business=?,Type_Industry=?,Type_Office=?,Office_Address=?," +
                      " Remarks=?,Rating=?,In_Bussiness_since=?,PERSON_CONFIRM_ADDRESS=?,Is_address_same=?,Unsatisfactory_Reason=?," +
                      " VERIFICATION_DATETIME=?,Area=?,MODIFY_BY=?,MODIFY_DATE=?,Applicant_Availbility=?,Dir_Check=?,YEARS_AT_RESIDENCE=?, " +
                      " Office_Ownership=?,telephone_check=?,Relationship_applicant=?,make=?,loan_amt=?,tenure=?,months=?,Product_name=?,Verifier_Comment=?, " +
                      " Name_business=?,No_yrs_previous_Employment=?,Landmark=?,Total_No_employee=?,WorkExp=?,EmployerName=?,Age_applicant=?,Purpose_loan=?,IfFinanceNameOfBank=?, " +
                      " Office_Name=?,Type_oF_Phone=?,TYPE_OF_MOBILE=?,LoanApplied=?,Loanamount=?,PurposeOf=?,ProfileC=?,NoOfwhichTVRdone=?,IFRented=?,TurnOverB=?,CityStability=?,ExistingcarownedbyClient=?,Financed=?,loannoifreqd=?," +
                    //New added/Updated for CHOLA
                      "ApplicationDate=?,AddrDiffConf=?,Telephone_Exists=?,Tele_whose_Name=?,AddressCDROM=?, " +
                    //END
                    //Added for SBI
                    "Type_Organization=?,TazPay=? " +
                    //END for SBI
                    " where Case_ID=? and VERIFICATION_TYPE_ID=? ";
                               
                oledbParam[0] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 50);
                oledbParam[0].Value = PersonContacted;

                oledbParam[1] = new OleDbParameter("@DesignationOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[1].Value = DesignationOfPersonContacted;

                oledbParam[2] = new OleDbParameter("@ExactDesignationOfApplicant", OleDbType.VarChar, 100);
                oledbParam[2].Value = ExactDesignationOfApplicant;

                oledbParam[3] = new OleDbParameter("@NoOfYearsWithTheCompany", OleDbType.VarChar, 50);
                oledbParam[3].Value = NoOfYearsWithTheCompany;

                oledbParam[4] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[4].Value = NatureOfBusiness;

                oledbParam[5] = new OleDbParameter("@MainlineBusinessOfTheCompany", OleDbType.VarChar, 100);
                oledbParam[5].Value = MainlineBusinessOfTheCompany;

                //oledbParam[6] = new OleDbParameter("Type_Office", OleDbType.VarChar, 50);
                //oledbParam[6].Value = Type_Office;

                oledbParam[6] = new OleDbParameter("@Type_Office", OleDbType.VarChar, 50);
                oledbParam[6].Value = CategoryOfCompany;

                oledbParam[7] = new OleDbParameter("@OfficeBusinessAddressAsPerCall", OleDbType.VarChar, 100);
                oledbParam[7].Value = OfficeBusinessAddressAsPerCall;

                oledbParam[8] = new OleDbParameter("@OverallRemarks", OleDbType.VarChar, 255);
                oledbParam[8].Value = OverallRemarks;

                oledbParam[9] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                if (Rating == "")
                {
                    oledbParam[9].Value = DBNull.Value;

                }
                else
                {
                    oledbParam[9].Value = Rating;
                }

                oledbParam[10] = new OleDbParameter("@InBusinessSince", OleDbType.VarChar, 30);
                oledbParam[10].Value = InBusinessSince;

                oledbParam[11] = new OleDbParameter("@PersonContactedOffiTeleConfirmsApplicantWorksAddress", OleDbType.VarChar, 50);
                oledbParam[11].Value = PersonContactedOffiTeleConfirmsApplicantWorksAddress;

                oledbParam[12] = new OleDbParameter("@AddressDifferent", OleDbType.VarChar, 50);
                oledbParam[12].Value = AddressDifferent;

                oledbParam[13] = new OleDbParameter("@UnsatisfactoryReason", OleDbType.VarChar, 255);
                oledbParam[13].Value = UnsatisfactoryReason;

                oledbParam[14] = new OleDbParameter("@VerificationDateAndTime", OleDbType.VarChar, 50);
                oledbParam[14].Value = VerificationDateAndTime;

                oledbParam[15] = new OleDbParameter("@Area", OleDbType.VarChar, 50);
                oledbParam[15].Value = Area;

                oledbParam[16] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                oledbParam[16].Value = ModifyBy;

                oledbParam[17] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                oledbParam[17].Value = ModifyOn;

                oledbParam[18] = new OleDbParameter("@Applicant_Availbility", OleDbType.VarChar, 50);
                oledbParam[18].Value = Applicant_Availbility;

                oledbParam[19] = new OleDbParameter("Dir_Check", OleDbType.VarChar, 50);
                oledbParam[19].Value = Dir_Check;

                oledbParam[20] = new OleDbParameter("@Years_At_Residence", OleDbType.VarChar, 50);
                oledbParam[20].Value = Years_At_Residence;

                oledbParam[21] = new OleDbParameter("@Ownership", OleDbType.VarChar, 50);
                oledbParam[21].Value = Ownership;

                oledbParam[22] = new OleDbParameter("@telephone_check", OleDbType.VarChar, 500);
                oledbParam[22].Value = Extn;

                oledbParam[23] = new OleDbParameter("@Relationship_applicant", OleDbType.VarChar, 50);
                oledbParam[23].Value = relantion;

                oledbParam[24] = new OleDbParameter("@make", OleDbType.VarChar, 150);
                oledbParam[24].Value = make;

                oledbParam[25] = new OleDbParameter("@loan_amt", OleDbType.VarChar, 150);
                oledbParam[25].Value = loanAmt;

                oledbParam[26] = new OleDbParameter("@tenure", OleDbType.VarChar, 150);
                oledbParam[26].Value = tenure;

                oledbParam[27] = new OleDbParameter("@month", OleDbType.VarChar, 150);
                oledbParam[27].Value = month;

                oledbParam[28] = new OleDbParameter("@ProdName", OleDbType.VarChar, 500);
                oledbParam[28].Value = ProdName;

                oledbParam[29] = new OleDbParameter("@TeleRemark", OleDbType.VarChar, 500);
                oledbParam[29].Value = TeleRemark;

                oledbParam[30] = new OleDbParameter("@BusinessNature", OleDbType.VarChar, 500);
                oledbParam[30].Value = BusinessNature;

                oledbParam[31] = new OleDbParameter("@NoOfYearsAtSameAddress", OleDbType.VarChar, 500);
                oledbParam[31].Value = NoOfYearsAtSameAddress;

                oledbParam[32] = new OleDbParameter("@Landmark", OleDbType.VarChar, 500);
                oledbParam[32].Value = Landmark;

                oledbParam[33] = new OleDbParameter("@TotalNoOfEmployee", OleDbType.VarChar, 500);
                oledbParam[33].Value = TotalNoOfEmployee;

                oledbParam[34] = new OleDbParameter("@WorkExp", OleDbType.VarChar, 500);
                oledbParam[34].Value = WorkExp;

                oledbParam[35] = new OleDbParameter("@EmployerName", OleDbType.VarChar, 500);
                oledbParam[35].Value = EmployerName;

                oledbParam[36] = new OleDbParameter("@AppAge", OleDbType.VarChar, 500);
                oledbParam[36].Value = AppAge;

                oledbParam[37] = new OleDbParameter("@MailAdd", OleDbType.VarChar, 500);
                oledbParam[37].Value = MailAdd;

                oledbParam[38] = new OleDbParameter("@IncomeDoc", OleDbType.VarChar, 500);
                oledbParam[38].Value = IncomeDoc;

                oledbParam[39] = new OleDbParameter("@ExactCompanyName", OleDbType.VarChar, 500);
                oledbParam[39].Value = ExactCompanyName;

                oledbParam[40] = new OleDbParameter("@OfficeTelephoneNo", OleDbType.VarChar, 500);
                oledbParam[40].Value = OfficeTelephoneNo;

                oledbParam[41] = new OleDbParameter("@ResidencePhoneNoBT", OleDbType.VarChar, 500);
                oledbParam[41].Value = ResidencePhoneNoBT;

                oledbParam[42] = new OleDbParameter("@LoanApplied", OleDbType.VarChar, 500);
                oledbParam[42].Value = LoanApplied;

                oledbParam[43] = new OleDbParameter("@Loanamount", OleDbType.VarChar, 500);
                oledbParam[43].Value = Loanamount;

                oledbParam[44] = new OleDbParameter("@PurposeOf", OleDbType.VarChar, 500);
                oledbParam[44].Value = PurposeOf;

                oledbParam[45] = new OleDbParameter("@ProfileC", OleDbType.VarChar, 500);
                oledbParam[45].Value = ProfileC;

                oledbParam[46] = new OleDbParameter("@NoOfwhichTVRdone", OleDbType.VarChar, 500);
                oledbParam[46].Value = NoOfwhichTVRdone;

                oledbParam[47] = new OleDbParameter("@IFRented", OleDbType.VarChar, 500);
                oledbParam[47].Value = IFRented;

                oledbParam[48] = new OleDbParameter("@TurnOverB", OleDbType.VarChar, 500);
                oledbParam[48].Value = TurnOverB;

                oledbParam[49] = new OleDbParameter("@CityStability", OleDbType.VarChar, 500);
                oledbParam[49].Value = CityStability;

                oledbParam[50] = new OleDbParameter("@ExistingcarownedbyClient", OleDbType.VarChar, 500);
                oledbParam[50].Value = ExistingcarownedbyClient;

                oledbParam[51] = new OleDbParameter("@Financed", OleDbType.VarChar, 500);
                oledbParam[51].Value = Financed;

                oledbParam[52] = new OleDbParameter("@loannoifreqd", OleDbType.VarChar, 500);
                oledbParam[52].Value = loannoifreqd;

                //New added/Updated for CHOLA
                oledbParam[53] = new OleDbParameter("@ApplicationDate", OleDbType.VarChar,50);
                oledbParam[53].Value = ApplicationDate;
                oledbParam[54] = new OleDbParameter("@AddrDiffConf", OleDbType.VarChar, 500);
                oledbParam[54].Value = AddrDiffConf;
                oledbParam[55] = new OleDbParameter("@Telephone_Exists", OleDbType.VarChar, 500);
                oledbParam[55].Value = Telephone_Exists;
                oledbParam[56] = new OleDbParameter("@Tele_whose_Name", OleDbType.VarChar, 500);
                oledbParam[56].Value = Tele_whose_Name;
                oledbParam[57] = new OleDbParameter("@AddressCDROM", OleDbType.VarChar, 500);
                oledbParam[57].Value = AddressCDROM;
                //END

                //Added for SBI
                oledbParam[58] = new OleDbParameter("@Type_Organization", OleDbType.VarChar, 50);
                oledbParam[58].Value = Type_Office;

                oledbParam[59] = new OleDbParameter("@ReasonDecline", OleDbType.VarChar, 50);
                oledbParam[59].Value = ReasonDecline;

                //END for SBI

                oledbParam[60] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[60].Value = CaseID;

                oledbParam[61] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[61].Value = VerificationTypeID;

                msg = "Record Updated Sucessfully";


            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeID;
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


            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

         

            if (VerificationTypeID == "25" || VerificationTypeID == "26" || VerificationTypeID == "27" || VerificationTypeID == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseID);
                    msg += " Case verification data entry completed.";

                }
            }





            /////////////////////////////////////////////////////////////////////////////////////////////
            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound During App_Code/CRl_TelephonicVerification.cs In InsertTelephonicVerification Method" + ex.Message);
        }
    }
    public OleDbDataReader GetBusiTelephonicVerification(string sCaseId, string sVerificationTypeID)
    {
        string sSql = "";
        sSql = "SELECT Type_oF_Phone,Office_Name,Office_Address,Person_Contacted,Designation_contacted_person," +
               " Designation,No_year_service,Name_business,Nature_Business,Type_Industry,Type_Office,Office_Address," +
               " Remarks,Rating,In_Bussiness_since,PERSON_CONFIRM_ADDRESS,Is_address_same,Unsatisfactory_Reason,"+
               "Applicant_Availbility,Dir_Check,YEARS_AT_RESIDENCE,Office_Ownership,product_name,Type_Office," +
               "VERIFICATION_DATETIME,Area,telephone_check,Relationship_applicant,make,loan_amt,tenure,months,Product_name, " +
               "telephone_check,Verifier_Comment,No_yrs_previous_Employment,Landmark,Total_No_employee,WorkExp,EmployerName,Age_applicant, " +
               " Purpose_loan,IfFinanceNameOfBank,TYPE_OF_MOBILE,LoanApplied,Loanamount,PurposeOf,ProfileC,NoOfwhichTVRdone,IFRented,TurnOverB,"+
               "CityStability,ExistingcarownedbyClient,Financed,loannoifreqd, "+
            //New added/Updated for CHOLA
                "ApplicationDate,AddrDiffConf,Telephone_Exists,Tele_whose_Name,AddressCDROM, " +
            //END
            //New added/Updated for SBI
                "TazPay " +
            //END

               " from CPV_RL_VERIFICATION_BVBT where Case_ID='" + sCaseId + "'" + " and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
        

    }

    public OleDbDataReader GetBusiCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "SELECT OFF_PHONE,OFF_NAME,(isNull(OFF_ADD_LINE_1,'')+' '+isnull(OFF_ADD_LINE_2,'')+' '+isnull(OFF_ADD_LINE_3,'')) as Office_Address  " +
                "  from CPV_RL_CASE_DETAILS where Case_ID='" + sCaseId + "'" ;
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);


    }

    public Int32 InsertTeleCallLog_SalarySlip_RL(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        string VerificationTypeID = "35";


        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[5];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseID + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrTeleCallLog)
            {
                AttemptDateTime = item[0].ToString();
                Remark = item[1].ToString();
                VerifierID = item[2].ToString();

                //////////////////////////////Inserting in table CPV_RL_VERIFICATION_ATTEMPT                 

                sqlQuery = "Insert into CPV_RL_VERIFICATION_ATTEMPT (Case_id,Attempt_Datetime,Attempt_Remark,Verification_type_id,VERIFIER_ID)" +
                          "Values(?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseID;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                oledbParam[2].Value = Remark;

                oledbParam[3] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[3].Value = VerificationTypeID;

                oledbParam[4] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                oledbParam[4].Value = VerifierID;

                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);
            }

            oledbTrans.Commit();
            oledbConn.Close();
            return returnValue;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error found During Insertion" + ex.Message);

        }

    }

    public DataSet GetTeleCallLogDetail_SalarySlip(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT Attempt_Datetime,Attempt_Remark ,TELEPHONE_NO,VERIFIER_ID from CPV_RL_VERIFICATION_ATTEMPT " +
              " where Case_id='" + sCaseID + "'" + "and Verification_type_id='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT Attempt_Datetime,Attempt_Remark ,TELEPHONE_NO,VERIFIER_ID from CPV_RL_VERIFICATION_ATTEMPT " +
              " where Case_id='" + sCaseID + "'" + "and Verification_type_id='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }

    public DataTable GetTeleCallerName()
    {
        string sSql = "";
        DataTable dt = new DataTable();
        sSql = "Select EMP_ID,FULLNAME from TC_VW ";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "TC_VW");
        dt = ds.Tables["TC_VW"];
        return dt;

    }

    public DataTable GetCaseStatus()
    {
        string sSql = "";
    
        DataTable dt = new DataTable();
        sSql = "SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] =  '" + HttpContext.Current.Session["ProductId"] + "' ) ORDER BY STATUS_CODE";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objCon.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "Status");
        dt = ds.Tables["Status"];
        return dt;

    }

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Gargi Srivastava
    //Create Date	   :   12 Nov 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        //sSql = " Select * from CPV_RL_CASE_STATUS_NULL " +
        //       " where case_id='" + sCaseId + "' and Client_id='" + sClientId + "'" +
        //       " and Centre_id='" + sCenterId + "'";

        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
               " where case_id='" + sCaseId + "') " +
               " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where CASE_STATUS_ID <>'' and case_id='" + sCaseId + "') " +
               " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }

    #endregion IsVerificationComplete

    #region IsQCVerificationComplete
    public string IsQCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
        " where case_id='" + sCaseId + "') " +
        " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where case_id='" + sCaseId + "' and CASE_STATUS_ID <> '' )" +
        " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }
    #endregion IsQCVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_RL_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete

    //added by kamal matekar.....for QC...
    #region QCVerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void QCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_QC_Case_Details SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion QCVerificationComplete



}