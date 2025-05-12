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
/// Summary description for CRL_VisitVerification
/// </summary>
public class CRL_VisitVerification
{
    CCommon objCmn = new CCommon();
	public CRL_VisitVerification()
	{
        objCmn = new CCommon();
    }

    #region common Property form RV & BV
    private string sSupervisorComment;
    public string SupervisorComment
    {
        get { return sSupervisorComment; }
        set { sSupervisorComment = value; }
    }

    private string sAttemptDateTime;
    public string AttemptDateTime
    {
        get { return sAttemptDateTime; }
        set { sAttemptDateTime = value; }
    }

    private string sRemark;
    public string Remark
    {
        get { return sRemark; }
        set { sRemark = value; }
    }

    private string sSubRemark;
    public string SubRemark
    {
        get { return sSubRemark; }
        set { sSubRemark = value; }
    }

    private string sVerifierID;
    public string VerifierID
    {
        get { return sVerifierID; }
        set { sVerifierID = value; }
    }

    private string sVerifier;
    public string Verifier
    {
        get { return sVerifier; }
        set { sVerifier = value; }
    }
    private string sRoofType;
    public string RoofType
    {
        get { return sRoofType; }
        set { sRoofType = value; }
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

    public string ModifyBy
    {
        get { return sModifiedBy; }
        set { sModifiedBy = value; }
    }
    //---------------------------------------
    //added by hemangi kambli on 01/10/2007 ----
    private string sTypeOfRoof;
    public string TypeOfRoof
    {
        get { return sTypeOfRoof; }
        set { sTypeOfRoof = value; }
    }
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

    private string sCaseId;
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }

    private string sVerificationTypeId;
    public string VerificationTypeId
    {
        get { return sVerificationTypeId; }
        set { sVerificationTypeId = value; }
    }

    private string sDateTimeOfVerification;
    public string DateTimeOfVerification
    {
        get { return sDateTimeOfVerification; }
        set { sDateTimeOfVerification = value; }
    }

    private string sVerifierName;
    public string VerifierName
    {
        get { return sVerifierName; }
        set { sVerifierName = value; }
    }
    private string sNameOfPersonMet;
    public string NameOfPersonMet
    {
        get { return sNameOfPersonMet; }
        set { sNameOfPersonMet = value; }
    }

    private string sLandmark;
    public string Landmark
    {
        get { return sLandmark; }
        set { sLandmark = value; }
    }

    private string sTeleNoType;
    public string TeleNoType
    {
        get { return sTeleNoType; }
        set { sTeleNoType = value; }
    }

    private string sMobileNoType;
    public string MobileNoType
    {
        get { return sMobileNoType; }
        set { sMobileNoType = value; }
    }

    private string sLoanAmount;
    public string LoanAmount
    {
        get { return sLoanAmount; }
        set { sLoanAmount = value; }
    }

    private string sUseOfLoan;
    public string UseOfLoan
    {
        get { return sUseOfLoan; }
        set { sUseOfLoan = value; }
    }

    private string sProduct;
    public string Product
    {
        get { return sProduct; }
        set { sProduct = value; }
    }

    private string sLocationOfProduct;
    public string LocationOfProduct
    {
        get { return sLocationOfProduct; }
        set { sLocationOfProduct = value; }
    }

    private string sDOB;
    public string DateOfBirth
    {
        get { return sDOB; }
        set { sDOB = value; }
    }

    private string sMaritalStatus;
    public string MaritalStatus
    {
        get { return sMaritalStatus; }
        set { sMaritalStatus = value; }
    }

    private string sEducation;
    public string Education
    {
        get { return sEducation; }
        set { sEducation = value; }
    }

    private string sLoanCancellation;
    public string LoanCancellation
    {
        get { return sLoanCancellation; }
        set { sLoanCancellation = value; }
    }

    private string sAnyCreditCard;
    public string AnyCreditCard
    {
        get { return sAnyCreditCard; }
        set { sAnyCreditCard = value; }
    }

    private string sAnyOtherLoan;
    public string AnyOtherLoan
    {
        get { return sAnyOtherLoan; }
        set { sAnyOtherLoan = value; }
    }

    private string sAssets;
    public string Assets
    {
        get { return sAssets; }
        set { sAssets = value; }
    }

    private string sVisibleItem;
    public string VisibleItem
    {
        get { return sVisibleItem; }
        set { sVisibleItem = value; }
    }

    private string sDetailsOfFurnitureSeen;
    public string DetailsOfFurnitureSeen
    {
        get { return sDetailsOfFurnitureSeen; }
        set { sDetailsOfFurnitureSeen = value; }
    }

    private string sLocality;
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }

    private string sNameOfNeighbour1;
    public string NameOfNeighbour1
    {
        get { return sNameOfNeighbour1; }
        set { sNameOfNeighbour1 = value; }
    }

    private string sAddressOfNeighbour1;
    public string AddressOfNeighbour1
    {
        get { return sAddressOfNeighbour1; }
        set { sAddressOfNeighbour1 = value; }
    }

    private string sDoesAppWorkHere1;
    public string DoesAppWorkHere1
    {
        get { return sDoesAppWorkHere1; }
        set { sDoesAppWorkHere1 = value; }
    }

    private string sMthsOfWorkAtOffice1;
    public string MthsOfWorkAtOffice1
    {
        get { return sMthsOfWorkAtOffice1; }
        set { sMthsOfWorkAtOffice1 = value; }
    }

    private string sNameOfNeighbour2;
    public string NameOfNeighbour2
    {
        get { return sNameOfNeighbour2; }
        set { sNameOfNeighbour2 = value; }
    }

    private string sAddressOfNeighbour2;
    public string AddressOfNeighbour2
    {
        get { return sAddressOfNeighbour2; }
        set { sAddressOfNeighbour2 = value; }
    }

    private string sDoesAppWorkHere2;
    public string DoesAppWorkHere2
    {
        get { return sDoesAppWorkHere2; }
        set { sDoesAppWorkHere2 = value; }
    }

    private string sMthsOfWorkAtOffice2;
    public string MthsOfWorkAtOffice2
    {
        get { return sMthsOfWorkAtOffice2; }
        set { sMthsOfWorkAtOffice2 = value; }
    }

    private string sTypeOfAccmodation;
    public string TypeOfAccmodation
    {
        get { return sTypeOfAccmodation; }
        set { sTypeOfAccmodation = value; }
    }

    private string sEntryPermitted;
    public string EntryPermitted
    {
        get { return sEntryPermitted; }
        set { sEntryPermitted = value; }
    }

    private string sIsIdentityProofSeen;
    public string IsIdentityProofSeen
    {
        get { return sIsIdentityProofSeen; }
        set { sIsIdentityProofSeen = value; }
    }

    private string sOtherInvestment;
    public string OtherInvestment
    {
        get { return sOtherInvestment; }
        set { sOtherInvestment = value; }
    }

    private string sPurposeOfLoanTaken;
    public string PurposeOfLoanTaken
    {
        get { return sPurposeOfLoanTaken; }
        set { sPurposeOfLoanTaken = value; }
    }

    private string sEducationalBackground;
    public string EducationalBackground
    {
        get { return sEducationalBackground; }
        set { sEducationalBackground = value; }
    }

    private string sClourOnDoor;
    public string ClourOnDoor
    {
        get { return sClourOnDoor; }
        set { sClourOnDoor = value; }
    }

    private string sMatchInNegativeList;
    public string MatchInNegativeList
    {
        get { return sMatchInNegativeList; }
        set { sMatchInNegativeList = value; }
    }

    private string sNeighbourhoodLocality;
    public string NeighbourhoodLocality
    {
        get { return sNeighbourhoodLocality; }
        set { sNeighbourhoodLocality = value; }
    }

    private string sIsAddOfAppSame;
    public string IsAddOfAppSame
    {
        get { return sIsAddOfAppSame; }
        set { sIsAddOfAppSame = value; }
    }

    private string sIsCompanyNameBoardSeen;
    public string IsCompanyNameBoardSeen
    {
        get { return sIsCompanyNameBoardSeen; }
        set { sIsCompanyNameBoardSeen = value; }
    }

    private string sNoOfMembers;
    public string NoOfMembers
    {
        get { return sNoOfMembers; }
        set { sNoOfMembers = value; }
    }

    private string sAgeOfApplicant;
    public string AgeOfApplicant
    {
        get { return sAgeOfApplicant; }
        set { sAgeOfApplicant = value; }
    }

    private string sNameAddOfThirdParty;
    public string NameAddOfThirdParty
    {
        get { return sNameAddOfThirdParty; }
        set { sNameAddOfThirdParty = value; }
    }

    private string sThirdPartyComments;
    public string ThirdPartyComments
    {
        get { return sThirdPartyComments; }
        set { sThirdPartyComments = value; }
    }

    private string sIsNegativeArea;
    public string IsNegativeArea
    {
        get { return sIsNegativeArea; }
        set { sIsNegativeArea = value; }
    }

    private string sIsAffilatedToPoliticalParty;
    public string IsAffilatedToPoliticalParty
    {
        get { return sIsAffilatedToPoliticalParty; }
        set { sIsAffilatedToPoliticalParty = value; }
    }

    private string sProfile;
    public string Profile
    {
        get { return sProfile; }
        set { sProfile = value; }
    }
       
    #endregion
    
    #region PropertyDeclaration for RV
    private string sSepBathroom;
    public string SeparateBathroom
    {
        get { return sSepBathroom; }
        set { sSepBathroom = value; }
    }

    private string sFamilySeen;
    public string FamilySeen
    {
        get { return sFamilySeen; }
        set { sFamilySeen = value; }
    }
    private string strNameOfPersonContacted;
    public string NameOfPersonContacted
    {
        get { return strNameOfPersonContacted; }
        set { strNameOfPersonContacted = value; }
    }
    private string strCaseID;
    public string CaseID
    {
        get { return strCaseID; }
        set { strCaseID = value; }
    }
    private string strStanForOrg;
    public string StanForOrg
    {
        get { return strStanForOrg; }
        set { strStanForOrg = value; }
    }
    private string sAppName;
    public string ApplicantName
    {
        get { return sAppName; }
        set { sAppName = value; }
    }
    private string strVeriDate;
    public string VeriDate
    {
        get { return strVeriDate; }
        set { strVeriDate = value; }
    }

    private string sFatherSpouseName;
    public string FatherSpouseName
    {
        get { return sFatherSpouseName; }
        set { sFatherSpouseName = value; }
    }

    private string sAgencyCode;
    public string AgencyCode
    {
        get { return sAgencyCode; }
        set { sAgencyCode = value; }
    }

    private string sIfDoctors;
    public string IfDoctors
    {
        get { return sIfDoctors; }
        set { sIfDoctors = value; }
    }
    private string sNoOfPatientsPerDay;
    public string NoOfPatientsPerDay
    {
        get { return sNoOfPatientsPerDay; }
        set { sNoOfPatientsPerDay = value; }
    }
    private string sAvgFeePerPatient;
    public string AvgFeePerPatient
    {
        get { return sAvgFeePerPatient; }
        set { sAvgFeePerPatient = value; }
    }
    private string sOtherClinicVisited;
    public string OtherClinicVisited
    {
        get { return sOtherClinicVisited; }
        set { sOtherClinicVisited = value; }
    }
    private string sNameOfClinic;
    public string NameOfClinic
    {
        get { return sNameOfClinic; }
        set { sNameOfClinic = value; }
    }
    private string sIfArchitectureCA;
    public string IfArchitectureCA
    {
        get { return sIfArchitectureCA; }
        set { sIfArchitectureCA = value; }
    }
    private string sIndependentlyYrs;
    public string IndependentlyYrs
    {
        get { return sIndependentlyYrs; }
        set { sIndependentlyYrs = value; }
    }
    private string sKeyClientName1;
    public string KeyClientName1
    {
        get { return sKeyClientName1; }
        set { sKeyClientName1 = value; }
    }
    private string sKeyClientName2;
    public string KeyClientName2
    {
        get { return sKeyClientName2; }
        set { sKeyClientName2 = value; }
    }
    private string sKeyClientName3;
    public string KeyClientName3
    {
        get { return sKeyClientName3; }
        set { sKeyClientName3 = value; }

    }
    private string sSocietyBoardSighted;
    public string SocietyBoardSighted
    {
        get { return sSocietyBoardSighted; }
        set { sSocietyBoardSighted = value; }
    }

    private string sMothersName;
    public string MothersName
    {
        get { return sMothersName; }
        set { sMothersName = value; }
    }

    private string sAddressOfCompany;
    public string AddressOfCompany
    {
        get { return sAddressOfCompany; }
        set { sAddressOfCompany = value; }
    }

    private string sNoOfEaringMembers;
    public string NoOfEaringMembers
    {
        get { return sNoOfEaringMembers; }
        set { sNoOfEaringMembers = value; }
    }

    private string sIfVehicleExist;
    public string IfVehicleExist
    {
        get { return sIfVehicleExist; }
        set { sIfVehicleExist = value; }
    }

    private string sVehicleType;
    public string VehicleType
    {
        get { return sVehicleType; }
        set { sVehicleType = value; }
    }


    private string sDoorLocked;
    public string DoorLocked
    {
        get { return sDoorLocked; }
        set { sDoorLocked = value; }
    }

    private string sRelationship;
    public string Relationship
    {
        get { return sRelationship; }
        set { sRelationship = value; }
    }

    private string sTotalYrsInCity;
    public string TotalYrsInCity
    {
        get { return sTotalYrsInCity; }
        set { sTotalYrsInCity = value; }
    }

    private string sNameAddOf1Reference;
    public string NameAddOf1Reference
    {
        get { return sNameAddOf1Reference; }
        set { sNameAddOf1Reference = value; }
    }
    private string strDesignationDepartment;
    public string Cont_DesignationDepartment
    {
        get { return strDesignationDepartment; }
        set { strDesignationDepartment = value; }
    }
    private string strDept_ConPer;
    public string Dept_ConPer
    {
        get { return strDept_ConPer; }
        set { strDept_ConPer = value; }
    }
    private string sParkingFacility;
    public string ParkingFacility
    {
        get { return sParkingFacility; }
        set { sParkingFacility = value; }
    }

    private string sLocationOfHouse;
    public string LocationOfHouse
    {
        get { return sLocationOfHouse; }
        set { sLocationOfHouse = value; }
    }

    private string sAddress;
    public string Address
    {
        get { return sAddress; }
        set { sAddress = value; }
    }

    private string sCity;
    public string City
    {
        get { return sCity; }
        set { sCity = value; }
    }

    private string sIdentityProofSeen;
    public string IdentityProofSeen
    {
        get { return sIdentityProofSeen; }
        set { sIdentityProofSeen = value; }
    }

    private string sApproachToResidence;
    public string ApproachToResidence
    {
        get { return sApproachToResidence; }
        set { sApproachToResidence = value; }
    }

    private string sPinCode;
    public string PinCode
    {
        get { return sPinCode; }
        set { sPinCode = value; }
    }
    
    private string sFamilyDetails;
    public string FamilyDetails
    {
        get { return sFamilyDetails; }
        set { sFamilyDetails = value; }
    }

    private string sDetailsOfWorkingMemberSpouse;
    public string DetailsOfWorkingMemberSpouse
    {
        get { return sDetailsOfWorkingMemberSpouse; }
        set { sDetailsOfWorkingMemberSpouse = value; }
    }

    private string sInteriorConditions;
    public string InteriorConditions
    {
        get { return sInteriorConditions; }
        set { sInteriorConditions = value; }
    }

    private string sDetailsOfWorkingMembersOthers;
    public string DetailsOfWorkingMembersOthers
    {
        get { return sDetailsOfWorkingMembersOthers; }
        set { sDetailsOfWorkingMembersOthers = value; }
    }

    private string sAreaOfHouse;
    public string AreaOfHouse
    {
        get { return sAreaOfHouse; }
        set { sAreaOfHouse = value; }
    }

    private string sCityLimit;
    public string CityLimit
    {
        get { return sCityLimit;}
        set { sCityLimit = value; }
    }
    private string sSeparateOffice;
    public string SeparateOffice
    {
        get { return sSeparateOffice;}
        set { sSeparateOffice = value; }
    }
    private string sCustomerSeen;
    public string CustomerSeen
    {
        get { return sCustomerSeen; }
        set { sCustomerSeen = value; }
    }

    private string sVehiOwn;
    public string VehiOwn
    {
        get { return sVehiOwn; }
        set { sVehiOwn = value; }
    }
    private string strFERemarks;
    public string FERemarks
    {
        get { return strFERemarks; }
        set { strFERemarks = value; }
    }
    private string strCpvRefNo;
    public string CpvRefNo
    {
        get { return strCpvRefNo; }
        set { strCpvRefNo = value; }
    }
    private string sBussPrem;
    public string BussPrem
    {
        get { return sBussPrem; }
        set { sBussPrem = value; }
    }

    private string sRefName;
    public string RefName
    {
        get { return sRefName; }
        set { sRefName = value; }
    }

    private string sRefAdd;
    public string RefAdd
    {
        get { return sRefAdd; }
        set { sRefAdd = value; }
    }

    private string sMonthTurn;
    public string MonthTurn
    {
        get { return sMonthTurn; }
        set { sMonthTurn = value; }
    }

    private string sNumberBed;
    public string NumberBed
    {
        get { return sNumberBed; }
        set { sNumberBed = value; }
    }

    private string sNeighCheck;
    public string NeighCheck
    {
        get { return sNeighCheck; }
        set { sNeighCheck = value; }
    }

    private string sClinicYear;
    public string ClinicYear
    {
        get { return sClinicYear; }
        set { sClinicYear = value; }
    }

    private string sSeparateResi;
    public string SeparateResi
    {
        get { return sSeparateResi; }
        set { sSeparateResi = value; }
    }

    private string sSeparateFactory;
    public string SeparateFactory
    {
        get { return sSeparateFactory; }
        set { sSeparateFactory = value; }
    }

    private string sSeparateEntrance;
    public string SeparateEntrance
    {
        get { return sSeparateEntrance; }
        set { sSeparateEntrance = value; }
    }

    private string sOfficeLimit;
    public string OfficeLimit
    {
        get { return sOfficeLimit; }
        set { sOfficeLimit = value; }
    }
    
    private string sSepOff;
    public string SepOff
    {
        get { return sSepOff; }
        set { sSepOff = value; }
    }
    private string sNamePerson2;
    public string NamePerson2
    {
        get { return sNamePerson2; }
        set { sNamePerson2 = value; }
    }
    private string sRelantionApp2;
    public string RelantionApp2
    {
        get { return sRelantionApp2; }
        set { sRelantionApp2 = value; }
    }
    private string sForm16;
    public string Form16
    {
        get { return sForm16; }
        set { sForm16 = value; }
    }
    private string sProfileConfIssu;
    public string ProfileConfIssu
    {
        get { return sProfileConfIssu; }
        set { sProfileConfIssu = value; }
    }
    private string sProfileConfColle;
    public string ProfileConfColle
    {
        get { return sProfileConfColle; }
        set { sProfileConfColle = value; }
    }
    private string sInfoProvide;
    public string InfoProvide
    {
        get { return sInfoProvide; }
        set { sInfoProvide = value; }
    }
    private string sCustAppPrev;
    public string CustAppPrev
    {
        get { return sCustAppPrev; }
        set { sCustAppPrev = value; }
    }
    private string sSalary;
    public string Salary
    {
        get { return sSalary; }
        set { sSalary = value; }
    }

    private string sNoDoctor;
    public string NoDoctor
    {
        get { return sNoDoctor; }
        set { sNoDoctor = value; }
    }
    private string sGrossReceipt;
    public string GrossReceipt
    {
        get { return sGrossReceipt; }
        set { sGrossReceipt = value; }
    }
    private string sMedicalShop;
    public string MedicalShop
    {
        get { return sMedicalShop; }
        set { sMedicalShop = value; }
    }
    private string sAmtRent;
    public string AmtRent
    {
        get { return sAmtRent; }
        set { sAmtRent = value; }
    }
    private string sNameHospital;
    public string NameHospital
    {
        get { return sNameHospital; }
        set { sNameHospital = value; }
    }
    private string sNameMachine;
    public string NameMachine
    {
        get { return sNameMachine; }
        set { sNameMachine = value; }
    }
    private string sAuditTax;
    public string AuditTax
    {
        get { return sAuditTax; }
        set { sAuditTax = value; }
    }
    private string sNoOfTax;
    public string NoOfTax
    {
        get { return sNoOfTax; }
        set { sNoOfTax = value; }
    }
    private string sGrossMonthReceipt;
    public string GrossMonthReceipt
    {
        get { return sGrossMonthReceipt; }
        set { sGrossMonthReceipt = value; }
    }
    private string strCaseStatusId;
    public string CaseStatusID
    {
        get { return strCaseStatusId; }
        set { strCaseStatusId = value; }
    }

    private string sNoOperation;
    public string NoOperation
    {
        get { return sNoOperation; }
        set { sNoOperation = value; }
    }
    private string sSoleOwner;
    public string SoleOwner
    {
        get { return sSoleOwner; }
        set { sSoleOwner = value; }
    }
    private string sAmtInvt;
    public string AmtInvt
    {
        get { return sAmtInvt; }
        set { sAmtInvt = value; }
    }
    private string sBussPremises;
    public string BussPremises
    {
        get { return sBussPremises; }
        set { sBussPremises = value; }
    }
    private string sFixAss;
    public string FixAss
    {
        get { return sFixAss; }
        set { sFixAss = value; }
    }
    private string sBussManuf;
    public string BussManuf
    {
        get { return sBussManuf; }
        set { sBussManuf = value; }
    }
    private string sRegiSale;
    public string RegiSale
    {
        get { return sRegiSale; }
        set { sRegiSale = value; }
    }
    private string sMajorClient;
    public string MajorClient
    {
        get { return sMajorClient; }
        set { sMajorClient = value; }
    }
    private string sAvgProfit;
    public string AvgProfit
    {
        get { return sAvgProfit; }
        set { sAvgProfit = value; }
    }
    private string sAvgSale;
    public string AvgSale
    {
        get { return sAvgSale; }
        set { sAvgSale = value; }
    }
    private string sSourceIncome;
    public string SourceIncome
    {
        get { return sSourceIncome; }
        set { sSourceIncome = value; }
    }
    
    private string sDatePrev;
    public string DatePrev
    {
        get { return sDatePrev; }
        set { sDatePrev = value; }
    }
    private string sOffDeci;
    public string OffDeci
    {
        get { return sOffDeci; }
        set { sOffDeci = value; }
    }
    private string sAppliCap;
    public string AppliCap
    {
        get { return sAppliCap; }
        set { sAppliCap = value; }
    }

    private string sTypeJob;
    public string TypeJob
    {
        get { return sTypeJob; }
        set { sTypeJob = value; }
    }

    private string sAppliWork;
    public string AppliWork
    {
        get { return sAppliWork; }
        set { sAppliWork = value; }
    }

    private string sAppliJobTrans;
    public string AppliJobTrans
    {
        get { return sAppliJobTrans; }
        set { sAppliJobTrans = value; }
    }

    private string sOffExit;
    public string OffExit
    {
        get { return sOffExit; }
        set { sOffExit = value; }
    }
/// <summary>
/// //////////////add code for hdfcNoc////////////////
    private string sSellConfMem;
    public string SellConfMem
    {
        get { return sSellConfMem; }
        set { sSellConfMem = value; }
    }

    private string sSellTran;
    public string SellTran
    {
        get { return sSellTran; }
        set { sSellTran = value; }
    }

    private string sSellProp;
    public string SellProp
    {
        get { return sSellProp; }
        set { sSellProp = value; }
    }

    private string sFlatNo;
    public string FlatNo
    {
        get { return sFlatNo; }
        set { sFlatNo = value; }
    }

    private string sNameBuy;
    public string NameBuy
    {
        get { return sNameBuy; }
        set { sNameBuy = value; }
    }

    private string sSellKnow;
    public string SellKnow
    {
        get { return sSellKnow; }
        set { sSellKnow = value; }
    }

    private string sSellLoan;
    public string SellLoan
    {
        get { return sSellLoan; }
        set { sSellLoan = value; }
    }

    private string sOutLoan;
    public string OutLoan
    {
        get { return sOutLoan; }
        set { sOutLoan = value; }
    }

    private string sSellMorg;
    public string SellMorg
    {
        get { return sSellMorg; }
        set { sSellMorg = value; }
    }

    private string sAuthen;
    public string Authen
    {
        get { return sAuthen; }
        set { sAuthen = value; }
    }

    private string sSellDoc;
    public string SellDoc
    {
        get { return sSellDoc; }
        set { sSellDoc = value; }
    }

    private string sSellPhoto;
    public string SellPhoto
    {
        get { return sSellPhoto; }
        set { sSellPhoto = value; }
    }
    /////////////end code
/// </summary>
/// 
    private string sTotalFamIncome;
    public string TotalFamIncome
    {
        get { return sTotalFamIncome; }
        set { sTotalFamIncome = value; }
    }

    private string sNoOfYrsAtResidence;
    public string NoOfYrsAtResidence
    {
        get { return sNoOfYrsAtResidence; }
        set { sNoOfYrsAtResidence = value; }
    }

    private string sOwnershipOfResidence;
    public string OwnershipOfResidence
    {
        get { return sOwnershipOfResidence; }
        set { sOwnershipOfResidence = value; }
    }

    private string sStayingWithWhom;
    public string StayingWithWhom
    {
        get { return sStayingWithWhom; }
        set { sStayingWithWhom = value; }
    }

    private string sDSA;
    public string DSA
    {
        get { return sDSA; }
        set { sDSA = value; }
    }

    private string sTenure;
    public string Tenure
    {
        get { return sTenure; }
        set { sTenure = value; }
    }

    private string sMonths;
    public string Months
    {
        get { return sMonths; }
        set { sMonths = value; }
    }

    private string sType;
    public string Type
    {
        get { return sType; }
        set { sType = value; }
    }

    private string sNameOnSocietyAddressBoard;
    public string NameOnSocietyAddressBoard
    {
        get { return sNameOnSocietyAddressBoard; }
        set { sNameOnSocietyAddressBoard = value; }
    }

    private string sNameplateOnDoor;
    public string NameplateOnDoor
    {
        get { return sNameplateOnDoor; }
        set { sNameplateOnDoor = value; }
    }
    private string sNameplateOnDoor1;
    public string NameplateOnDoor1
    {
        get { return sNameplateOnDoor1; }
        set { sNameplateOnDoor1 = value; }
    }

    private string sOwnershipDetail;
    public string OwnershipDetail
    {
        get { return sOwnershipDetail; }
        set { sOwnershipDetail = value; }
    }

    private string sPermanentAddress;
    public string PermanentAddress
    {
        get { return sPermanentAddress; }
        set { sPermanentAddress = value; }
    }

    private string sNoOfRooms;
    public string NoOfRooms
    {
        get { return sNoOfRooms; }
        set { sNoOfRooms = value; }
    }

    public string strIsAcctCorrect;
    public string IsAcctCorrect
    {
        get { return strIsAcctCorrect; }
        set { strIsAcctCorrect = value; }
    }

    private string sApproximateValue;
    public string ApproximateValue
    {
        get { return sApproximateValue; }
        set { sApproximateValue = value; }
    }

    private string sBachelorAccomodation;
    public string BachelorAccomodation
    {
        get { return sBachelorAccomodation; }
        set { sBachelorAccomodation = value; }
    }

    private string sVehiclesCurrentlyUsed;
    public string VehiclesCurrentlyUsed
    {
        get { return sVehiclesCurrentlyUsed; }
        set { sVehiclesCurrentlyUsed = value; }
    }

    private string sVehiclesFinancedNFinancerName;
    public string VehiclesFinancedNFinancerName
    {
        get { return sVehiclesFinancedNFinancerName; }
        set { sVehiclesFinancedNFinancerName = value; }
    }

    private string sDescribeExteriorPremises;
    public string DescribeExteriorPremises
    {
        get { return sDescribeExteriorPremises; }
        set { sDescribeExteriorPremises = value; }
    }
    private string strAmtSSSPSC;
    public string AmtSSSPSC
    {
        get { return strAmtSSSPSC; }
        set { strAmtSSSPSC = value; }
    }

    private string sDescribeInteriorPremises;
    public string DescribeInteriorPremises
    {
        get { return sDescribeInteriorPremises; }
        set { sDescribeInteriorPremises = value; }
    }

    private string sStatusOfResidence1;
    public string StatusOfResidence1
    {
        get { return sStatusOfResidence1; }
        set { sStatusOfResidence1 = value; }
    }

    private string sStatusOfResidence2;
    public string StatusOfResidence2
    {
        get { return sStatusOfResidence2; }
        set { sStatusOfResidence2 = value; }
    }
    
    private string sApplicantIncome;
    public string ApplicantIncome
    {
        get { return sApplicantIncome; }
        set { sApplicantIncome = value; }
    }

    private string sNameOfCompany;
    public string NameOfCompany
    {
        get { return sNameOfCompany; }
        set { sNameOfCompany = value; }
    }

    private string sOtherSourceOfIncome;
    public string OtherSourceOfIncome
    {
        get { return sOtherSourceOfIncome; }
        set { sOtherSourceOfIncome = value; }
    }

    private string sRoomType;
    public string RoomType
    {
        get { return sRoomType; }
        set { sRoomType = value; }
    }

    private string sTypeOfHouse;
    public string TypeOfHouse
    {
        get { return sTypeOfHouse; }
        set { sTypeOfHouse = value; }
    }

    private string sAnyOtherLoanOnApplicantName;
    public string AnyOtherLoanOnApplicantName
    {
        get { return sAnyOtherLoanOnApplicantName; }
        set { sAnyOtherLoanOnApplicantName = value; }
    }

    private string sVehiclesOwnership;
    public string VehiclesOwnership
    {
        get { return sVehiclesOwnership; }
        set { sVehiclesOwnership = value; }
    }

    private string sResiAddressIsWithInAreaLimit;
    public string ResiAddressIsWithInAreaLimit
    {
        get { return sResiAddressIsWithInAreaLimit; }
        set { sResiAddressIsWithInAreaLimit = value; }
    }

    private string sApporachToHouse;
    public string ApporachToHouse
    {
        get { return sApporachToHouse; }
        set { sApporachToHouse = value; }
    }

    private string sStandardOfLiving;
    public string StandardOfLiving
    {
        get { return sStandardOfLiving; }
        set { sStandardOfLiving = value; }
    }

    private string sWalls;
    public string Walls
    {
        get { return sWalls; }
        set { sWalls = value; }
    }

    private string sTypeOfResidence;
    public string TypeOfResidence
    {
        get { return sTypeOfResidence; }
        set { sTypeOfResidence = value; }
    }

    private string sFlooring;
    public string Flooring
    {
        get { return sFlooring; }
        set { sFlooring = value; }
    }

    private string sNoOfYrsOfCurrentResidence;
    public string NoOfYrsOfCurrentResidence
    {
        get { return sNoOfYrsOfCurrentResidence; }
        set { sNoOfYrsOfCurrentResidence = value; }
    }

    private string sTimeWhenAppIsHome;
    public string TimeWhenAppIsHome
    {
        get { return sTimeWhenAppIsHome; }
        set { sTimeWhenAppIsHome = value; }
    }

    private string sAddressProofSighted;
    public string AddressProofSighted
    {
        get { return sAddressProofSighted; }
        set { sAddressProofSighted = value; }
    }

    private string sTalliesWithCurrentAddress;
    public string TalliesWithCurrentAddress
    {
        get { return sTalliesWithCurrentAddress; }
        set { sTalliesWithCurrentAddress = value; }
    }

    private string sTypeOfAddProof;
    public string TypeOfAddProof
    {
        get { return sTypeOfAddProof; }
        set { sTypeOfAddProof = value; }
    }

    private string sResiOCL;
    public string ResiOCL
    {
        get { return sResiOCL; }
        set { sResiOCL = value; }
    }

    private string sBlackArea;
    public string BlackArea
    {
        get { return sBlackArea; }
        set { sBlackArea = value; }
    }

    private string sAddressConfirmed;
    public string AddressConfirmed
    {
        get { return sAddressConfirmed; }
        set { sAddressConfirmed = value; }
    }

    private string sHowCooperativeCustomer;
    public string HowCooperativeCustomer
    {
        get { return sHowCooperativeCustomer; }
        set { sHowCooperativeCustomer = value; }
    }

    private string sEaseOfLocation;
    public string EaseOfLocation
    {
        get { return sEaseOfLocation; }
        set { sEaseOfLocation = value; }
    }
    //added by kamal matekar for RV

    private Array sFileUpload1;
    public Array FileUpload1
    {
        get
        {
            return sFileUpload1;
        }
        set
        {
            sFileUpload1 = value;
        }

    }

    private string sPagerNo;
    public string PagerNo
    {
        get { return sPagerNo; }
        set { sPagerNo = value; }
    }
    private string sVisibleItems;
    public string VisibleItems
    {
        get { return sVisibleItems; }
        set { sVisibleItems = value; }
    }

    private string sNoOfWindow;
    public string NoOfWindow
    {
        get { return sNoOfWindow; }
        set { sNoOfWindow = value; }
    }
    private string sEmpDesignation;
    public string EmpDesignation
    {
        get { return sEmpDesignation; }
        set { sEmpDesignation = value; }
    }

    private string sChildren;
    public string Children
    {
        get { return sChildren; }
        set { sChildren = value; }
    }

    private string sCarPark;
    public string CarPark
    {
        get { return sCarPark; }
        set { sCarPark = value; }
    }

    private string sResiExti;
    public string ResiExti
    {
        get { return sResiExti; }
        set { sResiExti = value; }
    }

    private string sResiIntl;
    public string ResiIntl
    {
        get { return sResiIntl; }
        set { sResiIntl = value; }
    }

    private string sConsHouse;
    public string ConsHouse
    {
        get { return sConsHouse; }
        set { sConsHouse = value; }
    }

    private string sResiExt;
    public string ResiExt
    {
        get { return sResiExt; }
        set { sResiExt = value; }
    }

    private string sOthFeed;
    public string OthFeed
    {
        get { return sOthFeed; }
        set { sOthFeed = value; }
    }
    private string sCustPrev;
    public string CustPrev
    {
        get { return sCustPrev; }
        set { sCustPrev = value; }
    }
    
    private string sTranType;
    public string TranType
    {
        get { return sTranType; }
        set { sTranType = value; }
    }
    private string sPropBought;
    public string PropBought
    {
        get { return sPropBought; }
        set { sPropBought = value; }
    }
    private string sRelantionProp;
    public string RelantionProp
    {
        get { return sRelantionProp; }
        set { sRelantionProp = value; }
    }
    private string sOtherProp;
    public string OtherProp
    {
        get { return sOtherProp; }
        set { sOtherProp = value; }
    }
    //--added by kamal Matekar----for Barclays Finance PL
    private string sPlace_Of_Birth;
    public string Place_Of_Birth
    {
        get { return sPlace_Of_Birth; }
        set { sPlace_Of_Birth = value; }
    }
    private string sState;
    public string State
    {
        get { return sState; }
        set { sState = value; }
    }
    private string sName_Verified_From;
    public string Name_Verified_From
    {
        get { return sName_Verified_From; }
        set { sName_Verified_From = value; }
    }
    private string sApplicant_Category;
    public string Applicant_Category
    {
        get { return sApplicant_Category; }
        set { sApplicant_Category = value; }
    }
    private string sIf_Salaried_Designation;
    public string If_Salaried_Designation
    {
        get { return sIf_Salaried_Designation; }
        set { sIf_Salaried_Designation = value; }

    }
    private string sIf_SelfEmployee_Profession;
    public string If_SelfEmployee_Profession
    {
        get { return sIf_SelfEmployee_Profession; }
        set { sIf_SelfEmployee_Profession = value; }
    }
    private string sOff_Tel_No;
    public string Off_Tel_No
    {
        get { return sOff_Tel_No; }
        set { sOff_Tel_No = value; }
    }
    private string sNo_Emp_Seen;
    public string No_Emp_Seen
    {
        get { return sNo_Emp_Seen; }
        set { sNo_Emp_Seen = value; }
    }

    //--added by kamal matekar for Karvy Financial On dated 19th Nov 2010..
    private string sAddress_different;
    public string Address_different
    {
        get { return sAddress_different; }
        set { sAddress_different = value; }
    }
    private string sLessthan1Year_PreAdd;
    public string Lessthan1Year_PreAdd
    {
        get { return sLessthan1Year_PreAdd; }
        set { sLessthan1Year_PreAdd = value; }
    }
    private string sIfRented_PerMonth;
    public string IfRented_PerMonth
    {
        get { return sIfRented_PerMonth; }
        set { sIfRented_PerMonth = value; }
    }
    private string sIfFinanceNameOfBank;
    public string IfFinanceNameOfBank
    {
        get { return sIfFinanceNameOfBank; }
        set { sIfFinanceNameOfBank = value; }
    }
    private string sApplicant_NameVerifiedFrom;
    public string Applicant_NameVerifiedFrom
    {
        get { return sApplicant_NameVerifiedFrom; }
        set { sApplicant_NameVerifiedFrom = value; }
    }
    private string sYearOfConstruction;
    public string YearOfConstruction
    {
        get { return sYearOfConstruction; }
        set { sYearOfConstruction = value; }
    }
    private string sProperty_IsRented;
    public string Property_IsRented
    {
        get { return sProperty_IsRented; }
        set { sProperty_IsRented = value; }
    }
   
    private string sAppOccupation;
    public string AppOccupation
    {
        get { return sAppOccupation; }
        set { sAppOccupation = value; }
    }
    private string sNatureOfbusiness;
    public string NatureOfbusiness
    {
        get { return sNatureOfbusiness; }
        set { sNatureOfbusiness = value; }
    }
    private string sWorkingSince;
    public string WorkingSince
    {
        get { return sWorkingSince; }
        set { sWorkingSince = value; }
    }
    private string sProofOfIdentitySeen;
    public string ProofOfIdentitySeen
    {
        get { return sProofOfIdentitySeen; }
        set { sProofOfIdentitySeen = value; }
    }
    private string sAddressProofSeen;
    public string AddressProofSeen
    {
        get { return sAddressProofSeen; }
        set { sAddressProofSeen = value; }
    }


    //--Ended by kamal matekar...
    
    //---Ended by kamal matekar-----
    //----Added by kamal matekar On Dated 28 July 2010 For FederalFinance....
    private string sResiAdd_CoApp;
    public string ResiAdd_CoApp
    {
        get { return sResiAdd_CoApp; }
        set { sResiAdd_CoApp = value; }
    }
    private string sLandMark_CoApp;
    public string LandMark_CoApp
    {
        get { return sLandMark_CoApp; }
        set { sLandMark_CoApp = value; }
    }
    private string sTelNo_CoApp;
    public string TelNo_CoApp
    {
        get { return sTelNo_CoApp; }
        set { sTelNo_CoApp = value; }
    }
    private string sPersonContacted_CoApp;
    public string PersonContacted_CoApp
    {
        get { return sPersonContacted_CoApp; }
        set { sPersonContacted_CoApp = value; }
    }
    private string sRelationship_CoApp;
    public string Relationship_CoApp
    {
        get { return sRelationship_CoApp; }
        set { sRelationship_CoApp = value; }
    }
    private string sDatetime_Visit_CoApp;
    public string Datetime_Visit_CoApp
    {
        get { return sDatetime_Visit_CoApp; }
        set { sDatetime_Visit_CoApp = value; }
    }
    private string sDLNo;
    public string DLNo
    {
        get { return sDLNo; }
        set { sDLNo = value; }
    }
    private string sEillBillResi;
    public string EillBillResi
    {
        get { return sEillBillResi; }
        set { sEillBillResi = value; }
    }
   
    private string sPersonalAccount;
    public string PersonalAccount
    {
        get { return sPersonalAccount; }
        set { sPersonalAccount = value; }
    }
    private string sBranch;
    public string Branch
    {
        get { return sBranch; }
        set { sBranch = value; }
    }
    private string sPanNo;
    public string PanNo
    {
        get { return sPanNo; }
        set { sPanNo = value; }
    }
    private string sTeleBill;
    public string TeleBill
    {
        get { return sTeleBill; }
        set { sTeleBill = value; }
    }
    private string sODLimit;
    public string ODLimit
    {
        get { return sODLimit; }
        set { sODLimit = value; }
    }
    private string sAccountNo;
    public string AccountNo
    {
        get { return sAccountNo; }
        set { sAccountNo = value; }
    }
    private string sVoterId;
    public string VoterId
    {
        get { return sVoterId; }
        set { sVoterId = value; }
    }
    private string sRationCard;
    public string RationCard
    {
        get { return sRationCard; }
        set { sRationCard = value; }
    }
    private string sValueOfFlats;
    public string ValueOfFlats
    {
        get { return sValueOfFlats; }
        set { sValueOfFlats = value; }
    }
    private string sLevelMaintained;
    public string LevelMaintained
    {
        get { return sLevelMaintained; }
        set { sLevelMaintained = value; }
    }
    private string sPoliticsParty;
    public string PoliticsParty
    {
        get { return sPoliticsParty; }
        set { sPoliticsParty = value; }
    }
    private string sAssessment;
    public string Assessment
    {
        get { return sAssessment; }
        set { sAssessment = value; }
    }
    private string sRepoCollBy;
    public string RepoCollBy
    {
        get { return sRepoCollBy; }
        set { sRepoCollBy = value; }
    }
    private string sTVRDoneBy;
    public string TVRDoneBy
    {
        get { return sTVRDoneBy; }
        set { sTVRDoneBy = value; }
    }
    private string sQCDoneBy;
    public string QCDoneBy
    {
        get { return sQCDoneBy; }
        set { sQCDoneBy = value; }
    }
    private string sApprovingOfficer;
    public string ApprovingOfficer
    {
        get { return sApprovingOfficer; }
        set { sApprovingOfficer = value; }
    }
    private string sContentWriter;
    public string ContentWriter
    {
        get { return sContentWriter; }
        set { sContentWriter = value; }
    }
    private string sReportPreparedBy;
    public string ReportPreparedBy
    {
        get { return sReportPreparedBy; }
        set { sReportPreparedBy = value; }
    }
    private string sTVRDetails;
    public string TVRDetails
    {
        get { return sTVRDetails; }
        set { sTVRDetails = value; }
    }
    private string sTVR_Status;
    public string TVR_Status
    {
        get { return sTVR_Status; }
        set { sTVR_Status = value; }
    }
    private string sQC_Status;
    public string QC_Status
    {
        get { return sQC_Status; }
        set { sQC_Status = value; }
    }
    private string sRepoCollby_Status;
    public string RepoCollby_Status
    {
        get { return sRepoCollby_Status; }
        set { sRepoCollby_Status = value; }
    }
    private string sMaritalStatus_CoApp;
    public string MaritalStatus_CoApp
    {
        get { return sMaritalStatus_CoApp; }
        set { sMaritalStatus_CoApp = value; }
    }
    private string sDOB_CoApp;
    public string DOB_CoApp
    {
        get { return sDOB_CoApp; }
        set { sDOB_CoApp = value; }
    }
    private string sQualification_CoApp;
    public string Qualification_CoApp
    {
        get { return sQualification_CoApp; }
        set { sQualification_CoApp = value; }
    }
    private string sNoOfDependent_CoApp;
    public string NoOfDependent_CoApp
    {
        get { return sNoOfDependent_CoApp; }
        set { sNoOfDependent_CoApp = value; }
    }
    private string sFamilyStructure_CoApp;
    public string FamilyStructure_CoApp
    {
        get { return sFamilyStructure_CoApp; }
        set { sFamilyStructure_CoApp = value; }
    }
    private string sBackNum;
    public string BackNum
    {
        get { return sBackNum; }
        set { sBackNum = value; }
    }
    private string sRelAppForGua;
    public string RelAppForGua
    {
        get { return sRelAppForGua; }
        set { sRelAppForGua = value; }
    }
    private string sKnowApp;
    public string KnowApp
    {
        get { return sKnowApp; }
        set { sKnowApp = value; }
    }
    private string sLiabGua;
    public string LiabGua
    {
        get { return sLiabGua; }
        set { sLiabGua = value; }
    }
    private string sEmpDet;
    public string EmpDet
    {
        get { return sEmpDet; }
        set { sEmpDet = value; }
    }
    private string sCoAppName;
    public string CoAppName
    {
        get { return sCoAppName; }
        set { sCoAppName = value; }
    }
    private string sLoanNo;
    public string LoanNo
    {
        get { return sLoanNo; }
        set { sLoanNo = value; }
    }
    private string sAmbResi;
    public string AmbResi
    {
        get { return sAmbResi; }
        set { sAmbResi = value; }
    }
    private string sCheckDet;
    public string CheckDet
    {
        get { return sCheckDet; }
        set { sCheckDet = value; }
    }
    private string sNeCheck;
    public string NeCheck
    {
        get { return sNeCheck; }
        set { sNeCheck = value; }
    }
    private string sDocVeri;
    public string DocVeri
    {
        get { return sDocVeri; }
        set { sDocVeri = value; }
    }
    //---Ended by kamal matekar...

    private string sFamilyProp;
    public string FamilyProp
    {
        get { return sFamilyProp; }
        set { sFamilyProp = value; }
    }
    private string sSupName;
    public string SupName
    {
        get { return sSupName; }
        set { sSupName = value; }
    }
    private string sBankDetail;
    public string BankDetail
    {
        get { return sBankDetail; }
        set { sBankDetail = value; }
    }
    private string sCardType;
    public string CardType
    {
        get { return sCardType; }
        set { sCardType = value; }
    }

    #endregion
    
    #region PropertyDeclaration for BV
    private string sNameOfCollegue;
    public string NameOfCollegue
    {
        get { return sNameOfCollegue; }
        set { sNameOfCollegue = value; }
    }
    private string sDesgnDeptCollegue;
    public string DesgnDeptCollegue
    {
        get { return sDesgnDeptCollegue; }
        set { sDesgnDeptCollegue = value; }
    }
    private string sMthOfCompExistAtAddress;
    public string MthOfCompExistAtAddress
    {
        get { return sMthOfCompExistAtAddress; }
        set { sMthOfCompExistAtAddress = value; }
    }
    private string sProfileCoNeighbour;
    public string ProfileCoNeighbour
    {
        get { return sProfileCoNeighbour; }
        set { sProfileCoNeighbour = value; }
    }
    private string sAppNameVerifiedFrom;
    public string AppNameVerifiedFrom
    {
        get { return sAppNameVerifiedFrom; }
        set { sAppNameVerifiedFrom = value; }
    }
    
   //----
    private string sNameOfPersonMetDesgn;
    public string NameOfPersonMetDesgn
    {
        get { return sNameOfPersonMetDesgn; }
        set { sNameOfPersonMetDesgn = value; }
    }

    private string sApplicantWorkedAgGivenAddress;
    public string ApplicantWorkedAgGivenAddress
    {
        get { return sApplicantWorkedAgGivenAddress; }
        set { sApplicantWorkedAgGivenAddress = value; }
    }

    private string sNameOfBusiness;
    public string NameOfBusiness
    {
        get { return sNameOfBusiness; }
        set { sNameOfBusiness = value; }
    }

    private string sNoOfYrsInservice;
    public string NoOfYrsInservice
    {
        get { return sNoOfYrsInservice; }
        set { sNoOfYrsInservice = value; }
    }

    private string sAppDesignation;
    public string AppDesignation
    {
        get { return sAppDesignation; }
        set { sAppDesignation = value; }
    }

    private string sNoOfEmpSeen;
    public string NoOfEmployeeSeen
    {
        get { return sNoOfEmpSeen; }
        set { sNoOfEmpSeen = value; }
    }

    private string sConstitutencyOfBusiness;
    public string ConstitutencyOfBusiness
    {
        get { return sConstitutencyOfBusiness; }
        set { sConstitutencyOfBusiness = value; }
    }

    private string sTypeOfOffice;
    public string TypeOfOffice
    {
        get { return sTypeOfOffice; }
        set { sTypeOfOffice = value; }
    }

    private string sLocatingOffice;
    public string LocatingOffice
    {
        get { return sLocatingOffice; }
        set { sLocatingOffice = value; }
    }

    private string sIsResiCumOffice;
    public string IsResiCumOffice
    {
        get { return sIsResiCumOffice; }
        set { sIsResiCumOffice = value; }
    }

    private string sNameBoardSeen;
    public string NameBoardSeen
    {
        get { return sNameBoardSeen; }
        set { sNameBoardSeen = value; }
    }
        
    private string sIsBusinessActivityseen;
    public string IsBusinessActivityseen
    {
        get { return sIsBusinessActivityseen; }
        set { sIsBusinessActivityseen = value; }
    }
        
    private string sIsEuipStockSighted;
    public string IsEuipStockSighted
    {
        get { return sIsEuipStockSighted; }
        set { sIsEuipStockSighted = value; }
    }

    private string sNatureOfJob;
    public string NatureOfJob
    {
        get { return sNatureOfJob; }
        set { sNatureOfJob = value; }
    }

    private string sVisitCardAsProofOfVisit;
    public string VisitCardAsProofOfVisit
    {
        get { return sVisitCardAsProofOfVisit; }
        set { sVisitCardAsProofOfVisit = value; }
    }

    private string sRemarks;
    public string Remarks
    {
        get { return sRemarks; }
        set { sRemarks = value; }
    }

    private string sRating;
    public string Rating
    {
        get { return sRating; }
        set { sRating = value; }
    }
       

    private string sVerifierDate;
    public string VerifierDate
    {
        get { return sVerifierDate; }
        set { sVerifierDate = value; }
    }

    private string sVerifierTime;
    public string VerifierTime
    {
        get { return sVerifierTime; }
        set { sVerifierTime = value; }
    }

    private string sSupervisorName;
    public string SupervisorName
    {
        get { return sSupervisorName; }
        set { sSupervisorName = value; }
    }

    private string sSupervisorDate;
    public string SupervisorDate
    {
        get { return sSupervisorDate; }
        set { sSupervisorDate = value; }
    }

    private string sSupervisorTime;
    public string SupervisorTime
    {
        get { return sSupervisorTime; }
        set { sSupervisorTime = value; }
    }


    private string sNameOfBankDefaultedWith;
    public string NameOfBankDefaultedWith
    {
        get { return sNameOfBankDefaultedWith; }
        set { sNameOfBankDefaultedWith = value; }
    }

    private string sProductName;
    public string ProductName
    {
        get { return sProductName; }
        set { sProductName = value; }
    }

    private string sDefaultInWhichBucket;
    public string DefaultInWhichBucket
    {
        get { return sDefaultInWhichBucket; }
        set { sDefaultInWhichBucket = value; }
    }

    private string sAmountOfDefaultINR;
    public string AmountOfDefaultINR
    {
        get { return sAmountOfDefaultINR; }
        set { sAmountOfDefaultINR = value; }
    }

    private string sTeleCDRomCheck;
    public string TeleCDRomCheck
    {
        get { return sTeleCDRomCheck; }
        set { sTeleCDRomCheck = value; }
    }

    private string sOffTelNoInNameOf;
    public string OffTelNoInNameOf
    {
        get { return sOffTelNoInNameOf; }
        set { sOffTelNoInNameOf = value; }
    }

    private string sNoOfYrsAtPrevEmployment;
    public string NoOfYrsAtPrevEmployment
    {
        get { return sNoOfYrsAtPrevEmployment; }
        set { sNoOfYrsAtPrevEmployment = value; }
    }

    private string sOwnership;
    public string Ownership
    {
        get { return sOwnership; }
        set { sOwnership = value; }
    }

    private string sLocationOfOffice;
    public string LocationOfOffice
    {
        get { return sLocationOfOffice; }
        set { sLocationOfOffice = value; }
    }

    private string sApproachToOffice;
    public string ApproachToOffice
    {
        get { return sApproachToOffice; }
        set { sApproachToOffice = value; }
    }

    private string sAreaAroundOffice;
    public string AreaAroundOffice
    {
        get { return sAreaAroundOffice; }
        set { sAreaAroundOffice = value; }
    }

    private string sOfficeAmbience;
    public string OfficeAmbience
    {
        get { return sOfficeAmbience; }
        set { sOfficeAmbience = value; }
    }

    private string sOfficeOCL;
    public string OfficeOCL
    {
        get { return sOfficeOCL; }
        set { sOfficeOCL = value; }
    }

    private string sExteriorConditions;
    public string ExteriorConditions
    {
        get { return sExteriorConditions; }
        set { sExteriorConditions = value; }
    }


    private string sNoOfYrsAtCurrentOffice;
    public string NoOfYrsAtCurrentOffice
    {
        get { return sNoOfYrsAtCurrentOffice; }
        set { sNoOfYrsAtCurrentOffice = value; }
    }

    private string sTimeWhenAppIsInOffice;
    public string TimeWhenAppIsInOffice
    {
        get { return sTimeWhenAppIsInOffice; }
        set { sTimeWhenAppIsInOffice = value; }
    }

    
    private string sAgencyRecommandation;
    public string AgencyRecommandation
    {
        get { return sAgencyRecommandation; }
        set { sAgencyRecommandation = value; }
    }

    private string sScoretoolRecommandation;
    public string ScoretoolRecommandation
    {
        get { return sScoretoolRecommandation; }
        set { sScoretoolRecommandation = value; }
    }

    
    private string sMarketReputation1;
    public string MarketReputation1
    {
        get { return sMarketReputation1; }
        set { sMarketReputation1 = value; }
    }

    private string sIsOfficeSelfOwnedNeigh1;
    public string IsOfficeSelfOwnedNeigh1
    {
        get { return sIsOfficeSelfOwnedNeigh1; }
        set { sIsOfficeSelfOwnedNeigh1 = value; }
    }

    private string sIsOfficeSelfOwnedNeigh2;
    public string IsOfficeSelfOwnedNeigh2
    {
        get { return sIsOfficeSelfOwnedNeigh2; }
        set { sIsOfficeSelfOwnedNeigh2 = value; }
    }
    private string sCommentsOfNeighbour1;
    public string CommentsOfNeighbour1
    {
        get { return sCommentsOfNeighbour1; }
        set { sCommentsOfNeighbour1 = value; }
    }
        
    private string sMarketReputation2;
    public string MarketReputation2
    {
        get { return sMarketReputation2; }
        set { sMarketReputation2 = value; }
    }

    private string sCommentsOfNeighbour2;
    public string CommentsOfNeighbour2
    {
        get { return sCommentsOfNeighbour2; }
        set { sCommentsOfNeighbour2 = value; }
    }

    private string sAccessibility;
    public string Accessibility
    {
        get { return sAccessibility; }
        set { sAccessibility = value; }
    }

    private string sBusinessBoardSighted;
    public string BusinessBoardSighted
    {
        get { return sBusinessBoardSighted; }
        set { sBusinessBoardSighted = value; }
    }
        
    private string sApproxArea;
    public string ApproximateArea
    {
        get { return sApproxArea; }
        set { sApproxArea = value; }
    }

    private string sBriefJobResponsibilities;
    public string BriefJobResponsibilities
    {
        get { return sBriefJobResponsibilities; }
        set { sBriefJobResponsibilities = value; }
    }

    private string sBehavourOfPersonContact;
    public string BehavourOfPersonContact
    {
        get { return sBehavourOfPersonContact; }
        set { sBehavourOfPersonContact = value; }
    }
    
    private string sTypeOfIndustry;
    public string TypeOfIndustry
    {
        get { return sTypeOfIndustry; }
        set { sTypeOfIndustry = value; }
    }

    private string sNatureOfBusiness;
    public string NatureOfBusiness
    {
        get { return sNatureOfBusiness; }
        set { sNatureOfBusiness = value; }
    }

    private string sNoOfBranches;
    public string NoOfBranches
    {
        get { return sNoOfBranches; }
        set { sNoOfBranches = value; }
    }

    private string sNoOfCustomerPerDay;
    public string NoOfCustomerPerDay
    {
        get { return sNoOfCustomerPerDay; }
        set { sNoOfCustomerPerDay = value; }
    }

    private string sOfficeName;
    public string OfficeName
    {
        get { return sOfficeName; }
        set { sOfficeName = value; }
    }

    private string sOfficeAddress;
    public string OfficeAddress
    {
        get { return sOfficeAddress; }
        set { sOfficeAddress = value; }
    }

    private string sIsOfficeSelfOwned;
    public string IsOfficeSelfOwned
    {
        get { return sIsOfficeSelfOwned; }
        set { sIsOfficeSelfOwned = value; }
    }

    private string sTypeOfBusinessActivity;
    public string TypeOfBusinessActivity
    {
        get { return sTypeOfBusinessActivity; }
        set { sTypeOfBusinessActivity = value; }
    }

    private string sEntranceMotorable;
    public string EntranceMotorable
    {
        get { return sEntranceMotorable; }
        set { sEntranceMotorable = value; }
    }

    private string sRelationWithApplicant;
    public string RelationWithApplicant
    {
        get { return sRelationWithApplicant; }
        set { sRelationWithApplicant = value; }
    }   

    private string sDetailOfPreviousOccupation;
    public string DetailOfPreviousOccupation
    {
        get { return sDetailOfPreviousOccupation; }
        set { sDetailOfPreviousOccupation = value; }
    }

    private string sIsBusinessProofSeen;
    public string IsBusinessProofSeen
    {
        get { return sIsBusinessProofSeen; }
        set { sIsBusinessProofSeen = value; }
    }

    private string sResidenceAddress;
    public string ResidenceAddress
    {
        get { return sResidenceAddress; }
        set { sResidenceAddress = value; }
    }

    private string sProofOfBusinessActivity;
    public string ProofOfBusinessActivity
    {
        get { return sProofOfBusinessActivity; }
        set { sProofOfBusinessActivity = value; }
    }
    
    private string sTypeOfOrganization;
    public string TypeOfOrganization
    {
        get { return sTypeOfOrganization; }
        set { sTypeOfOrganization = value; }
    }

    private string sStatusOfOffice;
    public string StatusOfOffice
    {
        get { return sStatusOfOffice; }
        set { sStatusOfOffice = value; }
    }

    private string sShifOfWork;
    public string ShifOfWork
    {
        get { return sShifOfWork; }
        set { sShifOfWork = value; }
    }

    private string sVerifierComments;
    public string VerifierComments
    {
        get { return sVerifierComments; }
        set { sVerifierComments = value; }
    }

    private string sOverallVerification;
    public string OverallVerification
    {
        get { return sOverallVerification; }
        set { sOverallVerification = value; }
    }

    private string sTotalNoOfEmployees;
    public string TotalNoOfEmployees
    {
        get { return sTotalNoOfEmployees; }
        set { sTotalNoOfEmployees = value; }
    }

    private string sReasonNotCollectingVistingCard;
    public string ReasonNotCollectingVistingCard
    {
        get { return sReasonNotCollectingVistingCard; }
        set { sReasonNotCollectingVistingCard = value; }
    }

    private string sIsOfficeDoorLocked;
    public string IsOfficeDoorLocked
    {
        get { return sIsOfficeDoorLocked; }
        set { sIsOfficeDoorLocked = value; }
    }

    private string sWhereContacted;
    public string WhereContacted
    {
        get { return sWhereContacted; }
        set { sWhereContacted = value; }
    }

    private string sSendDate;
    public string SendDate
    {
        get { return sSendDate; }
        set { sSendDate = value; }
    }

    private string sNameOfBank;
    public string NameOfBank
    {
        get { return sNameOfBank; }
        set { sNameOfBank = value; }
    }

    private string sPrevEmploymentDesgn;
    public string PrevEmploymentDesgn
    {
        get { return sPrevEmploymentDesgn; }
        set { sPrevEmploymentDesgn = value; }
    }

    private string sConstructionOfOffice;
    public string ConstructionOfOffice
    {
        get { return sConstructionOfOffice; }
        set { sConstructionOfOffice = value; }
    }

    private string sEasyOfLocatingOffice;
    public string EasyOfLocatingOffice
    {
        get { return sEasyOfLocatingOffice; }
        set { sEasyOfLocatingOffice = value; }
    }

    private string sNegmatch;
    public string Negmatch
    {
        get { return sNegmatch; }
        set { sNegmatch = value; }
    }

    private string sReasonForNotRecomdNReferred;
    public string ReasonForNotRecomdNReferred
    {
        get { return sReasonForNotRecomdNReferred; }
        set { sReasonForNotRecomdNReferred = value; }
    }

    private string sIfOCLDistance;
    public string IfOCLDistance
    {
        get { return sIfOCLDistance; }
        set { sIfOCLDistance = value; }
    }
    //Newly added fields ----
    private string sLevelOfBusActivity;
    public string LevelOfBusActivity
    {
        get { return sLevelOfBusActivity; }
        set { sLevelOfBusActivity = value; }
    }

    private string sIsResiCumOfficeSelfOwned;
    public string IsResiCumOfficeSelfOwned
    {
        get { return sIsResiCumOfficeSelfOwned; }
        set { sIsResiCumOfficeSelfOwned = value; }
    }

    private string sStockSeen;
    public string StockSeen
    {
        get { return sStockSeen; }
        set { sStockSeen = value; }
    }

    private string sMthOfWorkCurrentOffice;
    public string MthOfWorkCurrentOffice
    {
        get { return sMthOfWorkCurrentOffice; }
        set { sMthOfWorkCurrentOffice = value; }
    }

    //added by kamal matekar..

    private string sMainlineBusiness;
    public string MainlineBusiness
    {
        get { return sMainlineBusiness; }
        set { sMainlineBusiness = value; }
    }

    private string sValueofNostocksighted;
    public string ValueofNostocksighted
    {
        get { return sValueofNostocksighted; }
        set { sValueofNostocksighted = value; }
    }

    private string sCategoryofCompany;
    public string CategoryofCompany
    {
        get { return sCategoryofCompany; }
        set { sCategoryofCompany = value; }
    }

    private string sNormalOfficeJob;
    public string NormalOfficeJob
    {
        get { return sNormalOfficeJob; }
        set { sNormalOfficeJob = value; }
    }

    //----------------Barclays Finance PL------------BV----------------------------------

    private string sPermanent_Address_If_Different;
    public string Permanent_Address_If_Different
    {
        get { return sPermanent_Address_If_Different; }
        set { sPermanent_Address_If_Different = value; }
    }
    private string sType_Of_Accomodation;
    public string Type_Of_Accomodation
    {
        get { return sType_Of_Accomodation; }
        set { sType_Of_Accomodation = value; }
    }
    private string sApprox_Time_When_App_Home;
    public string Approx_Time_When_App_Home
    {
        get { return sApprox_Time_When_App_Home; }
        set { sApprox_Time_When_App_Home = value; }
    }
    private string sSourcing_Dsa_Dealer;
    public string Sourcing_Dsa_Dealer
    {
        get { return sSourcing_Dsa_Dealer; }
        set { sSourcing_Dsa_Dealer = value; }
    }
    private string sExisting_Relationship_with_Barclays;
    public string Existing_Relationship_with_Barclays
    {
        get { return sExisting_Relationship_with_Barclays; }
        set { sExisting_Relationship_with_Barclays = value; }

    }
    private string sIf_Salaried_Employer_Name;
    public string If_Salaried_Employer_Name
    {
        get { return sIf_Salaried_Employer_Name; }
        set { sIf_Salaried_Employer_Name = value; }
    }
    private string sMain_Client;
    public string Main_Client
    {
        get { return sMain_Client; }
        set { sMain_Client = value; }
    }
    private string sSize_Of_Office;
    public string Size_Of_Office
    {
        get { return sSize_Of_Office; }
        set { sSize_Of_Office = value; }
    }
    private string sSelf_PM_Rent;
    public string Self_PM_Rent
    {
        get { return sSelf_PM_Rent; }
        set { sSelf_PM_Rent = value; }
    }
    private string sNoOfYrsAtCurrentOfficeAddress;
    public string NoOfYrsAtCurrentOfficeAddress
    {
        get { return sNoOfYrsAtCurrentOfficeAddress; }
        set { sNoOfYrsAtCurrentOfficeAddress = value; }
    }
    private string sOtherOfficeLocationDetails;
    public string OtherOfficeLocationDetails
    {
        get { return sOtherOfficeLocationDetails; }
        set { sOtherOfficeLocationDetails = value; }
    }
    private string sAutomation_Level;
    public string Automation_Level
    {
        get { return sAutomation_Level; }
        set { sAutomation_Level = value; }

    }
    private string sApproachability;
    public string Approachability
    {
        get { return sApproachability; }
        set { sApproachability = value; }
    }
    private string sWithin_Municipal_Limit;
    public string Within_Municipal_Limit
    {
        get { return sWithin_Municipal_Limit; }
        set { sWithin_Municipal_Limit = value; }
    }
    private string sAnyOtherFormOfbusiness;
    public string AnyOtherFormOfbusiness
    {
        get { return sAnyOtherFormOfbusiness; }
        set { sAnyOtherFormOfbusiness = value; }
    }
    private string sYearsAtCurrentAddress;
    public string YearsAtCurrentAddress
    {
        get { return sYearsAtCurrentAddress; }
        set { sYearsAtCurrentAddress = value; }
    }
    private string sNoOfYearsInCity;
    public string NoOfYearsInCity
    {
        get { return sNoOfYearsInCity; }
        set { sNoOfYearsInCity = value; }
    }
    private string sVehicalOwned;
    public string VehicalOwned
    {
        get { return sVehicalOwned; }
        set { sVehicalOwned = value; }

    }
    private string sAnyOtherAssets;
    public string AnyOtherAssets
    {
        get { return sAnyOtherAssets; }
        set { sAnyOtherAssets = value; }
    }
    private string sBankParticulars;
    public string BankParticulars
    {
        get { return sBankParticulars; }
        set { sBankParticulars = value; }
    }
    //------------------added by kamal matekar On dated 29/07/2010...
    private string sCompanyName_CoApp;
    public string CompanyName_CoApp
    {
        get { return sCompanyName_CoApp; }
        set { sCompanyName_CoApp = value; }
    }
    private string sOffAdd_CoApp;
    public string OffAdd_CoApp
    {
        get { return sOffAdd_CoApp; }
        set { sOffAdd_CoApp = value; }
    }
   
    private string sDesignation_CoApp;
    public string Designation_CoApp
    {
        get { return sDesignation_CoApp; }
        set { sDesignation_CoApp = value; }

    }
   
    private string sComStructure;
    public string ComStructure
    {
        get { return sComStructure; }
        set { sComStructure = value; }
    }
    private string sTurnOver;
    public string TurnOver
    {
        get { return sTurnOver; }
        set { sTurnOver = value; }
    }
    private string sStock;
    public string Stock
    {
        get { return sStock; }
        set { sStock = value; }
    }
    private string sITReturn;
    public string ITReturn
    {
        get { return sITReturn; }
        set { sITReturn = value; }
    }
    private string sProfitMargin;
    public string ProfitMargin
    {
        get { return sProfitMargin; }
        set { sProfitMargin = value; }
    }
    private string sDeptClaimed;
    public string DeptClaimed
    {
        get { return sDeptClaimed; }
        set { sDeptClaimed = value; }

    }
    private string sWife;
    public string Wife
    {
        get { return sWife; }
        set { sWife = value; }
    }
    private string sSon;
    public string Son
    {
        get { return sSon; }
        set { sSon = value; }
    }
    private string sLoanType;
    public string LoanType
    {
        get { return sLoanType; }
        set { sLoanType = value; }
    }
    private string sEMI;
    public string EMI
    {
        get { return sEMI; }
        set { sEMI = value; }
    }
    private string sPaid;
    public string Paid
    {
        get { return sPaid; }
        set { sPaid = value; }
    }
    private string sCrLimit;
    public string CrLimit
    {
        get { return sCrLimit; }
        set { sCrLimit = value; }
    }
    private string sCardNo;
    public string CardNo
    {
        get { return sCardNo; }
        set { sCardNo = value; }
    }

    private string sAssetsPurchase;
    public string AssetsPurchase
    {
        get { return sAssetsPurchase; }
        set { sAssetsPurchase = value; }
    }

    private string sAssetsLocated;
    public string AssetsLocated
    {
        get { return sAssetsLocated; }
        set { sAssetsLocated = value; }
    }

    private string sSpouseWork;
    public string SpouseWork
    {
        get { return sSpouseWork; }
        set { sSpouseWork = value; }
    }

    private string sSpouseDesg;
    public string SpouseDesg
    {
        get { return sSpouseDesg; }
        set { sSpouseDesg = value; }
    }
    private string sSpouseAdd;
    public string SpouseAdd
    {
        get { return sSpouseAdd; }
        set { sSpouseAdd = value; }
    }
    private string sUseOfAssets;
    public string UseOfAssets
    {
        get { return sUseOfAssets; }
        set { sUseOfAssets = value; }
    }
    private string sFaxNo;
    public string FaxNo
    {
        get { return sFaxNo; }
        set { sFaxNo = value; }
    }
    private string sFinanceCompName;
    public string FinanceCompName
    {
        get { return sFinanceCompName; }
        set { sFinanceCompName = value; }
    }
    /// <summary>
    /// //////////
    /// </summary>
    private string sPurpose1;
    public string Purpose1
    {
        get { return sPurpose1; }
        set { sPurpose1 = value; }
    }
    private string sOthPurpose1;
    public string OthPurpose1
    {
        get { return sOthPurpose1; }
        set { sOthPurpose1 = value; }
    }

    private string sFinanceVisible;
    public string FinanceVisible
    {
        get { return sFinanceVisible; }
        set { sFinanceVisible = value; }
    }

    private string sMunicipalLimit;
    public string MunicipalLimit
    {
        get { return sMunicipalLimit; }
        set { sMunicipalLimit = value; }
    }
    /// <summary>
    /// //
    /// </summary>
    private string sBranchName;
    public string BranchName
    {
        get { return sBranchName; }
        set { sBranchName = value; }
    }
    private string sBranchCode;
    public string BranchCode
    {
        get { return sBranchCode; }
        set { sBranchCode = value; }
    }
    private string sMonthSalary;
    public string MonthSalary
    {
        get { return sMonthSalary; }
        set { sMonthSalary = value; }
    }
    private string sOtherIncome;
    public string OtherIncome
    {
        get { return sOtherIncome; }
        set { sOtherIncome = value; }
    }
    private string sSourceOthIncome;
    public string SourceOthIncome
    {
        get { return sSourceOthIncome; }
        set { sSourceOthIncome = value; }
    }
    private string sVeriOtherIncome;
    public string VeriOtherIncome
    {
        get { return sVeriOtherIncome; }
        set { sVeriOtherIncome = value; }
    }
    private string sClubbedIncome;
    public string ClubbedIncome
    {
        get { return sClubbedIncome; }
        set { sClubbedIncome = value; }
    }
    private string sSourceClubIncome;
    public string SourceClubIncome
    {
        get { return sSourceClubIncome; }
        set { sSourceClubIncome = value; }
    }
    private string sVeriClub;
    public string VeriClub
    {
        get { return sVeriClub; }
        set { sVeriClub = value; }
    }
    private string sVeriThrough;
    public string VeriThrough
    {
        get { return sVeriThrough; }
        set { sVeriThrough = value; }
    }
    private string sLoanType1;
    public string LoanType1
    {
        get { return sLoanType1; }
        set { sLoanType1 = value; }
    }
    private string sLoanFinancier;
    public string LoanFinancier
    {
        get { return sLoanFinancier; }
        set { sLoanFinancier = value; }
    }
    private string sLoanAmt;
    public string LoanAmt
    {
        get { return sLoanAmt; }
        set { sLoanAmt = value; }
    }
    private string sLoanTenure;
    public string LoanTenure
    {
        get { return sLoanTenure; }
        set { sLoanTenure = value; }
    }
    private string sLoanEmi;
    public string LoanEmi
    {
        get { return sLoanEmi; }
        set { sLoanEmi = value; }
    }
    private string sLoanPaid;
    public string LoanPaid
    {
        get { return sLoanPaid; }
        set { sLoanPaid = value; }
    }
    private string sLoanType2;
    public string LoanType2
    {
        get { return sLoanType2; }
        set { sLoanType2 = value; }
    }
    private string sLoanFinancier2;
    public string LoanFinancier2
    {
        get { return sLoanFinancier2; }
        set { sLoanFinancier2 = value; }
    }
    private string sLoanAmt2;
    public string LoanAmt2
    {
        get { return sLoanAmt2; }
        set { sLoanAmt2 = value; }
    }
    private string sLoanTenure2;
    public string LoanTenure2
    {
        get { return sLoanTenure2; }
        set { sLoanTenure2 = value; }
    }
    private string sLoanEmi2;
    public string LoanEmi2
    {
        get { return sLoanEmi2; }
        set { sLoanEmi2 = value; }
    }
    private string sLoanPaid2;
    public string LoanPaid2
    {
        get { return sLoanPaid2; }
        set { sLoanPaid2 = value; }
    }
    private string sLoanType3;
    public string LoanType3
    {
        get { return sLoanType3; }
        set { sLoanType3 = value; }
    }
    private string sLoanFinancier3;
    public string LoanFinancier3
    {
        get { return sLoanFinancier3; }
        set { sLoanFinancier3 = value; }
    }
    private string sLoanAmt3;
    public string LoanAmt3
    {
        get { return sLoanAmt3; }
        set { sLoanAmt3 = value; }
    }
    private string sLoanTenure3;
    public string LoanTenure3
    {
        get { return sLoanTenure3; }
        set { sLoanTenure3 = value; }
    }
    private string sLoanEmi3;
    public string LoanEmi3
    {
        get { return sLoanEmi3; }
        set { sLoanEmi3 = value; }
    }
    private string sLoanPaid3;
    public string LoanPaid3
    {
        get { return sLoanPaid3; }
        set { sLoanPaid3 = value; }
    }

    private string sPurpose;
    public string Purpose
    {
        get { return sPurpose; }
        set { sPurpose = value; }
    }
    private string sOthPurpose;
    public string OthPurpose
    {
        get { return sOthPurpose; }
        set { sOthPurpose = value; }
    }


    private string sWorkExp;
    public string WorkExp
    {
        get { return sWorkExp; }
        set { sWorkExp = value; }
    }
    private string sOrgCov;
    public string OrgCov
    {
        get { return sOrgCov; }
        set { sOrgCov = value; }
    }
    private string sOemfName;
    public string OemfName
    {
        get { return sOemfName; }
        set { sOemfName = value; }
    }
    private string sOemfRelation;
    public string OemfRelation
    {
        get { return sOemfRelation; }
        set { sOemfRelation = value; }
    }
    private string sOemfOccu;
    public string OemfOccu
    {
        get { return sOemfOccu; }
        set { sOemfOccu = value; }
    }
    private string sOemfIncome;
    public string OemfIncome
    {
        get { return sOemfIncome; }
        set { sOemfIncome = value; }
    }
        
    private string sDependent;
    public string Dependent
    {
        get { return sDependent; }
        set { sDependent = value; }
    }
    private string sTwoWh;
    public string TwoWh
    {
        get { return sTwoWh; }
        set { sTwoWh = value; }
    }
    private string sFourWh;
    public string FourWh
    {
        get { return sFourWh; }
        set { sFourWh = value; }
    }
    private string sSignSeen;
    public string SignSeen
    {
        get { return sSignSeen; }
        set { sSignSeen = value; }
    }
    private string sFamilyMember;
    public string FamilyMember
    {
        get { return sFamilyMember; }
        set { sFamilyMember = value; }
    }
    private string sResiStatus;
    public string ResiStatus
    {
        get { return sResiStatus; }
        set { sResiStatus = value; }
    }
    private string sOtherFeedback;
    public string OtherFeedback
    {
        get { return sOtherFeedback; }
        set { sOtherFeedback = value; }
    }
    private string sOutstanding;
    public string Outstanding
    {
        get { return sOutstanding; }
        set { sOutstanding = value; }
    }
    //--Added by Manoj--BV
    private string sIfNegBankName;
    public string IfNegBankName
    {
        get { return sIfNegBankName; }
        set { sIfNegBankName = value; }
    }
    private string sIfNegProduct;
    public string IfNegProduct
    {
        get { return sIfNegProduct; }
        set { sIfNegProduct = value; }
    }
    private string sDefaultBucket;
    public string DefaultBucket
    {
        get { return sDefaultBucket; }
        set { sDefaultBucket = value; }
    }
    private string sDefaultAmt;
    public string DefaultAmt
    {
        get { return sDefaultAmt; }
        set { sDefaultAmt = value; }
    }

    //----
    private string sResidenceDetails;
    public string ResidenceDetails
    {
        get { return sResidenceDetails; }
        set { sResidenceDetails = value; }
    }
    private string sAccountType;
    public string AccountType
    {
        get { return sAccountType; }
        set { sAccountType = value; }
    }
    private string sBusinessConfirmed;
    public string BusinessConfirmed
    {
        get { return sBusinessConfirmed; }
        set { sBusinessConfirmed = value; }
    }
    private string sConfirmationSetup;
    public string ConfirmationSetup
    {
        get { return sConfirmationSetup; }
        set { sConfirmationSetup = value; }
    }
    private string sDedupMatchr;
    public string DedupMatchr
    {
        get { return sDedupMatchr; }
        set { sDedupMatchr = value; }
    }
    //--Ended by MAnoj--BV
    //Added by Manoj indiabulls--RV
    private string sEndUseOfTheFunds;
    public string EndUseOfTheFunds
    {
        get { return sEndUseOfTheFunds; }
        set { sEndUseOfTheFunds = value; }
    }
    private string sConfirmationRes;
    public string ConfirmationRes
    {
        get { return sConfirmationRes; }
        set { sConfirmationRes = value; }
    }

    private string sDedupMatch;
    public string DedupMatch
    {
        get { return sDedupMatch; }
        set { sDedupMatch = value; }
    }
    //Ended by MAnoj
    private string sReputationofneighbourhood;
    public string Reputationofneighbourhood
    {
        get { return sReputationofneighbourhood; }
        set { sReputationofneighbourhood = value; }
    }

    private string sNoOfPeople;
    public string NoOfPeople
    {
        get { return sNoOfPeople; }
        set { sNoOfPeople = value; }
    }

    private string sRegistrationNo;
    public string RegistrationNo
    {
        get { return sRegistrationNo; }
        set { sRegistrationNo = value; }
    }
    private string sGeneralAppearance;
    public string GeneralAppearance
    {
        get { return sGeneralAppearance; }
        set { sGeneralAppearance = value; }
    }
    private string sInducementoffered;
    public string Inducementoffered
    {
        get { return sInducementoffered; }
        set { sInducementoffered = value; }
    }

    private string sResTelOwnership;
    public string ResTelOwnership
    {
        get { return sResTelOwnership; }
        set { sResTelOwnership = value; }
    }
    private string sExactCompanyNameAddress;
    public string ExactCompanyNameAddress
    {
        get { return sExactCompanyNameAddress; }
        set { sExactCompanyNameAddress = value; }
    }

    //nikhil 12 march 2013 start
    private string sOfficeAmenities;
    public string OfficeAmenities
    {
        get { return sOfficeAmenities; }
        set { sOfficeAmenities = value; }
    }

    private string sMultipleCompFromPremises;
    public string MultipleCompFromPremises
    {
        get { return sMultipleCompFromPremises; }
        set { sMultipleCompFromPremises = value; }
    }
    private string sShadyOffice;
    public string ShadyOffice
    {
        get { return sShadyOffice; }
        set { sShadyOffice = value; }
    }

    private string sMetRecep;
    public string MetRecep
    {
        get { return sMetRecep; }
        set { sMetRecep = value; }
    }
    private string sMetColleague;
    public string MetColleague
    {
        get { return sMetColleague; }
        set { sMetColleague = value; }
    }
    private string sCustSameOffice;
    public string CustSameOffice
    {
        get { return sCustSameOffice; }
        set { sCustSameOffice = value; }
    }
    private string sOfficeOrStock;
    public string OfficeOrStock
    {
        get
        { return sOfficeOrStock; }
        set
        { sOfficeOrStock = value; }
    }


    //nikhil 12 march 2013 end

    private string sIncomeDocSub;
    public string IncomeDocSub
    {
        get { return sIncomeDocSub; }
        set { sIncomeDocSub = value; }
    }
    private string sNoOfpplseen;
    public string NoOfpplseen
    {
        get { return sNoOfpplseen; }
        set { sNoOfpplseen = value; }
    }
    private string stypeofloan;
    public string typeofloan
    {
        get { return stypeofloan; }
        set { stypeofloan = value; }
    }
    private string sremark;
    public string remark
    {
        get { return sremark; }
        set { sremark = value; }
    }
    //start nikhil 18 april 2013
    private string sPincodeAddMatch;
    public string PincodeAddMatch
    {
        get { return sPincodeAddMatch; }
        set { sPincodeAddMatch = value; }
    }

    private string sAddressSetup;
    public string AddressSetup
    {
        get { return sAddressSetup; }
        set { sAddressSetup = value; }
    }

    private string sMetCust;
    public string MetCust
    {
        get { return sMetCust; }
        set { sMetCust = value; }
    }

    private string sDesgnConf;
    public string DesgnConf
    {
        get { return sDesgnConf; }
        set { sDesgnConf = value; }
    }

    private string sMetSecurityGuard;
    public string MetSecurityGuard
    {
        get { return sMetSecurityGuard; }
        set { sMetSecurityGuard = value; }
    }

    private string sCommunityDominated;
    public string CommunityDominated
    {
        get { return sCommunityDominated; }
        set { sCommunityDominated = value; }
    }
    //end nikhil 18 april 2013
    //start nikhil 04 july 3013 for Ing Vysysa
    private string sLocalityType;
    public string LocalityType
    {
        get { return sLocalityType; }
        set { sLocalityType = value; }
    }

    private string sFamilyStructure;
    public string FamilyStructure
    {
        get { return sFamilyStructure; }
        set { sFamilyStructure = value; }
    }

    private string sExistingLoanDetails;
    public string ExistingLoanDetails
    {
        get { return sExistingLoanDetails; }
        set { sExistingLoanDetails = value; }
    }

    private string sExistingVehicleDetails;
    public string ExistingVehicleDetails
    {
        get { return sExistingVehicleDetails; }
        set { sExistingVehicleDetails = value; }
    }

    private string sVehicleRegNo;
    public string VehicleRegNo
    {
        get { return sVehicleRegNo; }
        set { sVehicleRegNo = value; }
    }

    private string sRouteMap;
    public string RouteMap
    {
        get { return sRouteMap; }
        set { sRouteMap = value; }
    }
    //end Ing Vysysa



    private string sDoesbranches;
    public string Doesbranches
    {
        get { return sDoesbranches; }
        set { sDoesbranches = value; }
    }
    private string sNeighbourCheck;
    public string NeighbourCheck
    {
        get { return sNeighbourCheck; }
        set { sNeighbourCheck = value; }
    }
    private string sNameVerifierNAme;
    public string NameVerifierNAme
    {
        get { return sNameVerifierNAme; }
        set { sNameVerifierNAme = value; }
    }
    private string sinteriorConditions;
    public string interiorConditions
    {
        get { return sinteriorConditions; }
        set { sinteriorConditions = value; }
    }
    private string sExteriors;
    public string Exteriors
    {
        get { return sExteriors; }
        set { sExteriors = value; }
    }
    private string sInteriors;
    public string Interiors
    {
        get { return sInteriors; }
        set { sInteriors = value; }
    }
    private string sNameverifiedfrom;
    public string Nameverifiedfrom
    {
        get { return sNameverifiedfrom; }
        set { sNameverifiedfrom = value; }
    }
    //Add by Manoj for city bank
    private string sNoOfstores;
    public string NoOfstores
    {
        get { return sNoOfstores; }
        set { sNoOfstores = value; }
    }

    private string sResidenceappear;
    public string Residenceappear
    {
        get { return sResidenceappear; }
        set { sResidenceappear = value; }
    }
    private string sDomestichelp;
    public string Domestichelp
    {
        get { return sDomestichelp; }
        set { sDomestichelp = value; }
    }

    private string swastheapplicantmetaresidence;
    public string wastheapplicantmetaresidence
    {
        get { return swastheapplicantmetaresidence; }
        set { swastheapplicantmetaresidence = value; }
    }
    private string sSecretary;
    public string Secretary
    {
        get { return sSecretary; }
        set { sSecretary = value; }
    }
    private string sFurnishingseen;
    public string Furnishingseen
    {
        get { return sFurnishingseen; }
        set { sFurnishingseen = value; }
    }
    private string sthereaphoneonhisdesk;
    public string thereaphoneonhisdesk
    {
        get { return sthereaphoneonhisdesk; }
        set { sthereaphoneonhisdesk = value; }
    }
    private string sEaringmembers;
    public string Earingmembers
    {
        get { return sEaringmembers; }
        set { sEaringmembers = value; }
    }
    private string sRelationshipe;
    public string Relationshipe
    {
        get { return sRelationshipe; }
        set { sRelationshipe = value; }
    }
    private string smonthlyearing;
    public string monthlyearing
    {
        get { return smonthlyearing; }
        set { smonthlyearing = value; }
    }
    private string sVerifierthrough;
    public string Verifierthrough
    {
        get { return sVerifierthrough; }
        set { sVerifierthrough = value; }
    }
    private string sApplicantstaandinginLocality;
    public string ApplicantstaandinginLocality
    {
        get { return sApplicantstaandinginLocality; }
        set { sApplicantstaandinginLocality = value; }
    }
    private string snamee;
    public string namee
    {
        get { return snamee; }
        set { snamee = value; }
    }
    private string sphonee;
    public string phonee
    {
        get { return sphonee; }
        set { sphonee = value; }
    }
    private string selaborateonthestanding;
    public string elaborateonthestanding
    {
        get { return selaborateonthestanding; }
        set { selaborateonthestanding = value; }
    }
    private string sBusinessdealingseen;
    public string Businessdealingseen
    {
        get { return sBusinessdealingseen; }
        set { sBusinessdealingseen = value; }
    }
    private string sFinancier;
    public string Financier
    {
        get { return sFinancier; }
        set { sFinancier = value; }
    }
    private string sFinanceAmount;
    public string FinanceAmount
    {
        get { return sFinanceAmount; }
        set { sFinanceAmount = value; }
    }
    private string sNegativeFeedbackFromFamily;
    public string NegativeFeedbackFromFamily
    {
        get { return sNegativeFeedbackFromFamily; }
        set { sNegativeFeedbackFromFamily = value; }
    }
    private string sNegativeFeedbackFromNeighbour;
    public string NegativeFeedbackFromNeighbour
    {
        get { return sNegativeFeedbackFromNeighbour; }
        set { sNegativeFeedbackFromNeighbour = value; }
    }
    private string sApplicantCapableOfMaintaining;
    public string ApplicantCapableOfMaintaining
    {
        get { return sApplicantCapableOfMaintaining; }
        set { sApplicantCapableOfMaintaining = value; }
    }
    private string sNoOfBranchtext;
    public string NoOfBranchtext
    {
        get { return sNoOfBranchtext; }
        set { sNoOfBranchtext = value; }
    }

    //ING VYSYA NIKHIL start 05 july 2013 BV

    private string sCoApplicantName;
    public string CoApplicantName
    {
        get { return sCoApplicantName; }
        set { sCoApplicantName = value; }
    }

    private string sAddressonfirmed;
    public string Addressonfirmed
    {
        get { return sAddressonfirmed; }
        set { sAddressonfirmed = value; }
    }

    private string sAverageBillingPerCustomer;
    public string AverageBillingPerCustomer
    {
        get { return sAverageBillingPerCustomer; }
        set { sAverageBillingPerCustomer = value; }
    }

    private string sPeakBusinessHours;
    public string PeakBusinessHours
    {
        get { return sPeakBusinessHours; }
        set { sPeakBusinessHours = value; }
    }

    private string sMarketHoliday;
    public string MarketHoliday
    {
        get { return sMarketHoliday; }
        set { sMarketHoliday = value; }
    }
    private string sVehicleFreeOrFinance;
    public string VehicleFreeOrFinance
    {
        get { return sVehicleFreeOrFinance; }
        set { sVehicleFreeOrFinance = value; }
    }

    private string sAnyConcerningIssue;
    public string AnyConcerningIssue
    {
        get { return sAnyConcerningIssue; }
        set { sAnyConcerningIssue = value; }
    }

    private string sReportingTo;
    public string ReportingTo
    {
        get { return sReportingTo; }
        set { sReportingTo = value; }
    }
    //End ING VYSYA BV
    private string sbuildingtype;
    public string buildingtype
    {
        get { return sbuildingtype; }
        set { sbuildingtype = value; }
    }
    //Added by Manoj
    private string sPickupdocument;
    public string Pickupdocument
    {
        get { return sPickupdocument; }
        set { sPickupdocument = value; }
    }
    private string sBusinessverification;
    public string Businessverification
    {
        get { return sBusinessverification; }
        set { sBusinessverification = value; }
    }
    private string sITRVerification;
    public string ITRVerification
    {
        get { return sITRVerification; }
        set { sITRVerification = value; }
    }
    private string sVoterIdverification;
    public string VoterIdverification
    {
        get { return sVoterIdverification; }
        set { sVoterIdverification = value; }
    }
    private string sbanksatatmentveri;
    public string banksatatmentveri
    {
        get { return sbanksatatmentveri; }
        set { sbanksatatmentveri = value; }
    }
    private string selectricitybillveri;
    public string electricitybillveri
    {
        get { return selectricitybillveri; }
        set { selectricitybillveri = value; }
    }
    #endregion   

    #region GetVerificationDetail()
    //Name              :   GetVerificationDetail
    //Create By			:	Hemangi Kambli
    //Create Date		:	3July,2007

    public OleDbDataReader GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CRL.Verification_type_id from  CPV_RL_CASE_DETAILS CD " +
               " INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE CRL ON CD.Case_ID=CRL.Case_ID " +
               " WHERE CRL.case_id='" + sCaseId + "' " +
               " And CRL.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetQCVerificationDetail()
    public OleDbDataReader GetQCVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        string sSql = "";
        sSql = "select CD.Case_Id,CCV.Verification_type_id from  CPV_QC_Case_Details CD " +
               " INNER JOIN CPV_QC_Case_VerificationType CCV ON CD.Case_ID=CCV.Case_ID " +
               " WHERE CCV.case_id='" + sCaseId + "' " +
               " And CCV.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.Case_SEND_DATE IS NULL ";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerificationDetail()

    #region GetVerifierID()
    public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_RL_CASE_FE_MAPPING where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerifierID()

    #region GetRVDetail()
    public OleDbDataReader GetRVDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select * from CPV_RL_VERIFICATION_RVRT where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetRVDetail()

    #region GetRVDetail_New()
    public OleDbDataReader GetRVDetail_New(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select * from CPV_RL_VERIVICATION_RESBUSI where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetRVDetail_New()

    #region GetBVDetail()
    public OleDbDataReader GetBVDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select * from CPV_RL_VERIFICATION_BVBT where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetBVDetail()

    #region GetCASEDetail()
    public OleDbDataReader GetCASEDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "SELECT CD.REF_NO," +
               " CONVERT(CHAR(10), cd.CASE_REC_DATETIME,103) + ' ' + " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.CASE_REC_DATETIME, 22), 10, 5) + " +
               " RIGHT(CONVERT(VARCHAR(20), cd.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
               " ISNULL(CD.FIRST_NAME,'') + ' ' + ISNULL(CD.MIDDLE_NAME,'')+ISNULL(CD.LAST_NAME,'') AS NAME, "+
               " ISNULL(CD.RES_ADD_LINE_1,'')+ ' ' + ISNULL(CD.RES_ADD_LINE_2,'')+ ' ' + ISNULL(CD.RES_ADD_LINE_3,'') " +
               " AS RESIADDRESS, CD.RES_CITY, CD.RES_PIN_CODE,CD.DOB,CD.RES_LAND_MARK,CD.EMPLOYEE_TYPE, " +
               " ISNULL(CD.OFF_ADD_LINE_1,'')+ ' ' + ISNULL(CD.OFF_ADD_LINE_2,'')+ ' ' + ISNULL(CD.OFF_ADD_LINE_3,'') + ' ' + " +
               " ISNULL(CD.OFF_CITY,'') + ISNULL(CD.OFF_PIN_CODE,'') AS OFFADDRESS, CD.OFF_PHONE,CD.OFF_LAND_MARK,CD.OFF_NAME,App_Type " +
               " FROM CPV_RL_CASE_DETAILS CD  INNER JOIN " +
               " CPV_RL_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID " +
               " where CV.case_id='" + sCaseId + "' " +
               " And CV.verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCASEDetail()

    public OleDbDataReader GetCASEDetail_Vend(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = " select File_No,Service_Center,Name_Seller_conf_neigh,Seller_aware,whom_sell_prop,buyer_name, " +
               " sell_get_know_buy,sell_finan_institution,out_loan,mortgage,poss_doc,photo_Iden,flat_no, " +
               " Authenticity from CPV_RL_VERIFICATION_REF where case_id='" + sCaseId + "' " +
               " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetCASEDetail_Noc(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = " select File_No,Service_Center,Name_Seller_conf_neigh,flat_no,Authenticity,Seller_aware, " +
               " sell_finan_institution from CPV_RL_VERIFICATION_REF where case_id='" + sCaseId + "' " +
               " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT ATTEMPT_DATETIME,Attempt_REMARK,VERIFIER_ID,SubRemark from CPV_RL_VERIFICATION_ATTEMPT a" +
              " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail1(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "select top 3 a.case_id,a.verification_type_id, c.fullname,a.ASSIGN_DATETIME from CPV_RL_CASE_FE_MAPPING a,employee_master c where " +
               " a.fe_id=c.emp_id and a.case_id='" + sCaseID + "' and a.verification_type_id='" + sVerificationTypeID + "' union all " +
               " select top 3 b.case_id,b.verification_type_id,c.fullname,b.DATE_TIME from cpv_rl_fe_case_mapping_history b,employee_master c " +
               " where b.fe_id=c.emp_id and b.case_id='" + sCaseID + "' and b.verification_type_id='" + sVerificationTypeID + "' order by ASSIGN_DATETIME asc";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public Int32 InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseId + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            objoledbDR = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[6];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_RL_VERIFICATION_ATTEMPT where CASE_ID='" + CaseId + "'" +
                           " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery);
            }
            foreach (ArrayList item in arrTeleCallLog)
            {
                AttemptDateTime = item[0].ToString();
                Remark = item[1].ToString();
                SubRemark = item[2].ToString();
                VerifierID = item[3].ToString();

                //////////////////////////////Inserting in table CPV_RL_VERIFICATION_ATTEMPT                 

                sqlQuery = "Insert into CPV_RL_VERIFICATION_ATTEMPT(CASE_ID,ATTEMPT_DATETIME,Attempt_REMARK,VERIFICATION_TYPE_ID,VERIFIER_ID,SubRemark) " +
                          "Values(?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseId;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 255);
                oledbParam[2].Value = Remark;

                oledbParam[3] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 15);
                oledbParam[3].Value = VerificationTypeId;

                oledbParam[4] = new OleDbParameter("@VerifierID", OleDbType.VarChar, 15);
                oledbParam[4].Value = VerifierID;

                oledbParam[5] = new OleDbParameter("@SubRemark", OleDbType.VarChar, 300);
                oledbParam[5].Value = SubRemark;


                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sqlQuery, oledbParam);

            }

            string sSql = "";
            sSql = "Update CPV_RL_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

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

    #region InsertUpdateRLResiVerificationEntry() Residence verification(RV)
    //Function Name    :   InsertUpdateRLResiVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   02 July 2007.
    //Remarks 		   :   This method is used to insert new verification entry for RL.

    public string InsertUpdateRLResiVerificationEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_RVRT " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[201];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_RVRT(CASE_ID,VERIFICATION_TYPE_ID,PERSON_CONTACTED,Relationship," +
                     "Address,CITY,PINCODE,Landmark,TEL_NO_TYPE_PHONE,Mobile_No_type_phone,Loan_Amount,Use_of_loan,Product,Location_Product," +
                     "DOB,MARITAL_STATUS,EDUCATION_BACKGROUND,FAMILY_DETAILS,SPOUSE_DETAILS,FAMILY_INCOME," +
                     "OTHER_DETAILS,Loan_Cancellation,CREDIT_CARD_LIMIT,OTHER_LOAN_DATAIL,YEARS_AT_RESIDENCE," +
                     "Area_of_House,ASSETS,DETAIL_FURNITURE_SEEN,Ownership_RESIDENCE,STAYING_WHOM,DSA,Tenure," +
                     "Months,Type,Name_Society_Board,Nameplate_on_door,Ownership_Details,Permanent_address," +
                     "Number_rooms,Approximate_Value,Bachelor_Accomodation,Locality,Vehicles_used,Vehicles_financed," +
                     "Exterior_Premises,interior_Premises,Name_Neighbour1,ADD_Neighbour1,CONFIRM_Neighbour1,RESSTATUS_Neighbour1," +
                     "Stay_Res_Neighbour1,Comments_Neighbour1,Name_Neighbour2,ADD_Neighbour2,CONFIRM_Neighbour2,RESSTATUS_Neighbour2," +
                     "Stay_Res_Neighbour2,Comments_Neighbour2,Type_Accmodation,Entry_Permitted,Identity_Proof_Seen," +
                     "Applicant_income,Company_name,Purpose_loan,other_source_income,Other_Investment,Colour_of_Door," +
                     "Room_Type,Type_of_House,loan_applicant_name,Vehicles_Ownership,Residence_address_negative," +
                     "Approch_Residence,Type_Roof,Telephone_check,Location_house,approch_to_house," +
                     "Standard_of_Living,Walls,Flooring,IS_appname_address,No_of_dependent,age_applicant,Name_add_third_party," +
                     "Time_app_at_home,Third_party_comment,Address_Proof_Sighted,Tallies_current_Address,Type_of_Add_Proof," +
                     "Resi_OCL,Affliated_Political_Party,Profile,Address_Confirmed,How_Cooperative,Locating_address," +
                     "Agency_Code,Accessibility,Entrance_Motorable,Society_Board_Sighted,Mother_Name,Address_Company," +
                     "Behavior_Person_Contacted,Verifier_Comments,Verification_status,No_of_earning_member,If_Vehicle_exist," +
                     "Vehicle_Type,Door_Locked,Sent_Datetime,Totals_Yrs_City,Name_add_Ref1,OCL_than_distance,Parking_Facility," +
                     "Neg_match,Reason_Notrecommended,Father_Spouse_Name,VERIFICATION_DATETIME,ADD_BY,ADD_DATE," +
                     "SEP_BATHROOM_SEEN,FAMILY_SEEN,SUPERVISOR_COMMENTS,ROOF_TYPE,Verifier,City_Limit,Pager_No,Visible_Items, " +
                     "No_of_Windows,Children,Emp_Designation,Car_Park,Resi_Exti,Resi_Intl,Cons_House,Resi_Ext,other_feedback,CustApp_Prev, " +
                     "Date_Prev,Tran_Date,Prop_Brought,Relantion_prop,Other_Prop,Off_Deci,Place_Of_Birth,State,Name_Verified_From,Applicant_Category,If_Salaried_Designation,If_SelfEmployee_Profession,Off_Tel_No,No_Emp_Seen, " +
                     "ResiAdd_CoApp,LandMark_CoApp,TelNo_CoApp,PersonContacted_CoApp,Relationship_CoApp,Datetime_Visit_CoApp,DLNo,EillBillResi," +
                     "PersonalAccount,Branch,PanNo,TeleBill,ODLimit,AccountNo,VoterId,RationCard,ValueOfFlats,LevelMaintained,PoliticsParty,Assessment, " +
                     "RepoCollBy,TVRDoneBy,QCDoneBy,ApprovingOfficer,ContentWriter,ReportPreparedBy,TVRDetails,TVR_Status,QC_Status,RepoCollby_Status,MaritalStatus_CoApp, " +
                     "DOB_CoApp,Qualification_CoApp,NoOfDependent_CoApp,FamilyStructure_CoApp,Address_different,Lessthan1Year_PreAdd,IfRented_PerMonth,IfFinanceNameOfBank,Applicant_NameVerifiedFrom," +
                     "YearOfConstruction,AppOccupation,NatureOfbusiness,WorkingSince,ProofOfIdentitySeen,AddressProofSeen,Property_IsRented,PP_Number,AppliCap,Name_of_Applicant_Conf) " +
                     "VALUES(" +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, " +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, " +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?," +
                     "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 100);
                paramRV[2].Value = NameOfPersonMet;
                paramRV[3] = new OleDbParameter("@Relationship", OleDbType.VarChar, 100);
                paramRV[3].Value = Relationship;
                paramRV[4] = new OleDbParameter("@Address", OleDbType.VarChar, 255);
                paramRV[4].Value = Address;
                paramRV[5] = new OleDbParameter("@City", OleDbType.VarChar, 100);
                paramRV[5].Value = City;
                paramRV[6] = new OleDbParameter("@PinCode", OleDbType.VarChar, 20);
                paramRV[6].Value = PinCode;
                paramRV[7] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramRV[7].Value = Landmark;
                paramRV[8] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramRV[8].Value = TeleNoType;
                paramRV[9] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramRV[9].Value = MobileNoType;
                paramRV[10] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramRV[10].Value = LoanAmount;
                paramRV[11] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 255);
                paramRV[11].Value = UseOfLoan;
                paramRV[12] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramRV[12].Value = Product;
                paramRV[13] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramRV[13].Value = LocationOfProduct;
                paramRV[14] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 30);
                paramRV[14].Value = DateOfBirth;
                paramRV[15] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramRV[15].Value = MaritalStatus;
                paramRV[16] = new OleDbParameter("@EducationalBackground", OleDbType.VarChar, 100);
                paramRV[16].Value = EducationalBackground;
                paramRV[17] = new OleDbParameter("@FamilyDetails", OleDbType.VarChar, 255);
                paramRV[17].Value = FamilyDetails;
                paramRV[18] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 255);
                paramRV[18].Value = DetailsOfWorkingMemberSpouse;
                paramRV[19] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[19].Value = TotalFamIncome;
                paramRV[20] = new OleDbParameter("@DetailsOfWorkingMembersOthers", OleDbType.VarChar, 255);
                paramRV[20].Value = DetailsOfWorkingMembersOthers;
                paramRV[21] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramRV[21].Value = LoanCancellation;
                paramRV[22] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 255);
                paramRV[22].Value = AnyCreditCard;
                paramRV[23] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 255);
                paramRV[23].Value = AnyOtherLoan;
                paramRV[24] = new OleDbParameter("@NoOfYrsAtResidence", OleDbType.VarChar, 20);
                paramRV[24].Value = NoOfYrsAtResidence;
                paramRV[25] = new OleDbParameter("@AreaOfHouse", OleDbType.VarChar, 20);
                paramRV[25].Value = AreaOfHouse;
                paramRV[26] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramRV[26].Value = Assets;
                paramRV[27] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 255);
                paramRV[27].Value = DetailsOfFurnitureSeen;
                paramRV[28] = new OleDbParameter("@OwnershipOfResidence", OleDbType.VarChar, 50);
                paramRV[28].Value = OwnershipOfResidence;
                paramRV[29] = new OleDbParameter("@StayingWithWhom", OleDbType.VarChar, 100);
                paramRV[29].Value = StayingWithWhom;
                paramRV[30] = new OleDbParameter("@DSA", OleDbType.VarChar, 50);
                paramRV[30].Value = DSA;
                paramRV[31] = new OleDbParameter("@Tenure", OleDbType.VarChar, 100);
                paramRV[31].Value = Tenure;
                paramRV[32] = new OleDbParameter("@Months", OleDbType.VarChar, 10);
                paramRV[32].Value = Months;
                paramRV[33] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[33].Value = Type;
                paramRV[34] = new OleDbParameter("@NameOnSocietyAddressBoard", OleDbType.VarChar, 100);
                paramRV[34].Value = NameOnSocietyAddressBoard;
                paramRV[35] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 50);
                paramRV[35].Value = NameplateOnDoor;
                paramRV[36] = new OleDbParameter("@OwnershipDetail", OleDbType.VarChar, 100);
                paramRV[36].Value = OwnershipDetail;
                paramRV[37] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                paramRV[37].Value = PermanentAddress;
                paramRV[38] = new OleDbParameter("@NoOfRooms", OleDbType.VarChar, 50);
                paramRV[38].Value = NoOfRooms;
                paramRV[39] = new OleDbParameter("@ApproximateValue", OleDbType.VarChar, 50);
                paramRV[39].Value = ApproximateValue;
                paramRV[40] = new OleDbParameter("@BachelorAccomodation", OleDbType.VarChar, 50);
                paramRV[40].Value = BachelorAccomodation;
                paramRV[41] = new OleDbParameter("@Locality", OleDbType.VarChar, 50);
                paramRV[41].Value = Locality;
                paramRV[42] = new OleDbParameter("@VehiclesCurrentlyUsed", OleDbType.VarChar, 100);
                paramRV[42].Value = VehiclesCurrentlyUsed;
                paramRV[43] = new OleDbParameter("@VehiclesFinancedNFinancerName", OleDbType.VarChar, 100);
                paramRV[43].Value = VehiclesFinancedNFinancerName;
                paramRV[44] = new OleDbParameter("@DescribeExteriorPremises", OleDbType.VarChar, 100);
                paramRV[44].Value = DescribeExteriorPremises;
                paramRV[45] = new OleDbParameter("@DescribeInteriorPremises", OleDbType.VarChar, 100);
                paramRV[45].Value = DescribeInteriorPremises;
                paramRV[46] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramRV[46].Value = NameOfNeighbour1;
                paramRV[47] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[47].Value = AddressOfNeighbour1;
                paramRV[48] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 100);
                paramRV[48].Value = DoesAppWorkHere1;
                paramRV[49] = new OleDbParameter("@StatusOfResidence1", OleDbType.VarChar, 50);
                paramRV[49].Value = StatusOfResidence1;
                paramRV[50] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                paramRV[50].Value = MthsOfWorkAtOffice1;
                paramRV[51] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[51].Value = CommentsOfNeighbour1;
                paramRV[52] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramRV[52].Value = NameOfNeighbour2;
                paramRV[53] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[53].Value = AddressOfNeighbour2;
                paramRV[54] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 100);
                paramRV[54].Value = DoesAppWorkHere2;
                paramRV[55] = new OleDbParameter("@StatusOfResidence2", OleDbType.VarChar, 50);
                paramRV[55].Value = StatusOfResidence2;
                paramRV[56] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                paramRV[56].Value = MthsOfWorkAtOffice2;
                paramRV[57] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[57].Value = CommentsOfNeighbour2;
                paramRV[58] = new OleDbParameter("@TypeOfAccmodation", OleDbType.VarChar, 100);
                paramRV[58].Value = TypeOfAccmodation;
                paramRV[59] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramRV[59].Value = EntryPermitted;
                paramRV[60] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                paramRV[60].Value = IdentityProofSeen;
                paramRV[61] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramRV[61].Value = ApplicantIncome;
                paramRV[62] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 100);
                paramRV[62].Value = NameOfCompany;
                paramRV[63] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramRV[63].Value = PurposeOfLoanTaken;
                paramRV[64] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 100);
                paramRV[64].Value = OtherSourceOfIncome;
                paramRV[65] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramRV[65].Value = OtherInvestment;
                paramRV[66] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramRV[66].Value = ClourOnDoor;
                paramRV[67] = new OleDbParameter("@RoomType", OleDbType.VarChar, 100);
                paramRV[67].Value = RoomType;
                paramRV[68] = new OleDbParameter("@TypeOfHouse", OleDbType.VarChar, 50);
                paramRV[68].Value = TypeOfHouse;
                paramRV[69] = new OleDbParameter("@AnyOtherLoanOnApplicantName", OleDbType.VarChar, 100);
                paramRV[69].Value = AnyOtherLoanOnApplicantName;
                paramRV[70] = new OleDbParameter("@VehiclesOwnership", OleDbType.VarChar, 100);
                paramRV[70].Value = VehiclesOwnership;
                paramRV[71] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 100);
                paramRV[71].Value = MatchInNegativeList;
                paramRV[72] = new OleDbParameter("@ApproachToResidence", OleDbType.VarChar, 100);
                paramRV[72].Value = ApproachToResidence;
                paramRV[73] = new OleDbParameter("@TypeOfRoof", OleDbType.VarChar, 100);
                paramRV[73].Value = TypeOfRoof;
                paramRV[74] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramRV[74].Value = TeleCDRomCheck;
                paramRV[75] = new OleDbParameter("@LocationOfHouse", OleDbType.VarChar, 100);
                paramRV[75].Value = LocationOfHouse;
                paramRV[76] = new OleDbParameter("@ApporachToHouse", OleDbType.VarChar, 50);
                paramRV[76].Value = ApporachToHouse;
                paramRV[77] = new OleDbParameter("@StandardOfLiving", OleDbType.VarChar, 100);
                paramRV[77].Value = StandardOfLiving;
                paramRV[78] = new OleDbParameter("@Walls", OleDbType.VarChar, 100);
                paramRV[78].Value = Walls;
                paramRV[79] = new OleDbParameter("@Flooring", OleDbType.VarChar, 100);
                paramRV[79].Value = Flooring;
                paramRV[80] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramRV[80].Value = IsAddOfAppSame;
                paramRV[81] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramRV[81].Value = NoOfMembers;
                paramRV[82] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramRV[82].Value = AgeOfApplicant;
                paramRV[83] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramRV[83].Value = NameAddOfThirdParty;
                paramRV[84] = new OleDbParameter("@TimeWhenAppIsHome", OleDbType.VarChar, 50);
                paramRV[84].Value = TimeWhenAppIsHome;
                paramRV[85] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramRV[85].Value = ThirdPartyComments;
                paramRV[86] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 50);
                paramRV[86].Value = AddressProofSighted;
                paramRV[87] = new OleDbParameter("@TalliesWithCurrentAddress", OleDbType.VarChar, 50);
                paramRV[87].Value = TalliesWithCurrentAddress;
                paramRV[88] = new OleDbParameter("@TypeOfAddProof", OleDbType.VarChar, 50);
                paramRV[88].Value = TypeOfAddProof;
                paramRV[89] = new OleDbParameter("@ResiOCL", OleDbType.VarChar, 50);
                paramRV[89].Value = ResiOCL;
                paramRV[90] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramRV[90].Value = IsAffilatedToPoliticalParty;
                paramRV[91] = new OleDbParameter("@Profile", OleDbType.VarChar, 255);
                paramRV[91].Value = Profile;
                paramRV[92] = new OleDbParameter("@AddressConfirmed", OleDbType.VarChar, 50);
                paramRV[92].Value = AddressConfirmed;
                paramRV[93] = new OleDbParameter("@HowCooperativeCustomer", OleDbType.VarChar, 100);
                paramRV[93].Value = HowCooperativeCustomer;
                paramRV[94] = new OleDbParameter("@EaseOfLocation", OleDbType.VarChar, 255);
                paramRV[94].Value = EaseOfLocation;
                paramRV[95] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramRV[95].Value = AgencyCode;
                paramRV[96] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                paramRV[96].Value = Accessibility;
                paramRV[97] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 50);
                paramRV[97].Value = EntranceMotorable;
                paramRV[98] = new OleDbParameter("@SocietyBoardSighted", OleDbType.VarChar, 50);
                paramRV[98].Value = SocietyBoardSighted;
                paramRV[99] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                paramRV[99].Value = MothersName;
                paramRV[100] = new OleDbParameter("@AddressOfCompany", OleDbType.VarChar, 255);
                paramRV[100].Value = AddressOfCompany;
                paramRV[101] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 100);
                paramRV[101].Value = BehavourOfPersonContact;
                paramRV[102] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramRV[102].Value = VerifierComments;
                paramRV[103] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 50);
                paramRV[103].Value = OverallVerification;
                paramRV[104] = new OleDbParameter("@NoOfEaringMembers", OleDbType.VarChar, 500);
                paramRV[104].Value = NoOfEaringMembers;
                paramRV[105] = new OleDbParameter("@IfVehicleExist", OleDbType.VarChar, 10);
                paramRV[105].Value = IfVehicleExist;
                paramRV[106] = new OleDbParameter("@VehicleType", OleDbType.VarChar, 50);
                paramRV[106].Value = VehicleType;
                paramRV[107] = new OleDbParameter("@DoorLocked", OleDbType.VarChar, 50);
                paramRV[107].Value = DoorLocked;
                paramRV[108] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramRV[108].Value = SendDate;
                paramRV[109] = new OleDbParameter("@TotalYrsInCity", OleDbType.VarChar, 50);
                paramRV[109].Value = TotalYrsInCity;
                paramRV[110] = new OleDbParameter("@NameAddOf1Reference", OleDbType.VarChar, 255);
                paramRV[110].Value = NameAddOf1Reference;
                paramRV[111] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramRV[111].Value = IfOCLDistance;
                paramRV[112] = new OleDbParameter("@ParkingFacility", OleDbType.VarChar, 50);
                paramRV[112].Value = ParkingFacility;
                paramRV[113] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 10);
                paramRV[113].Value = Negmatch;
                paramRV[114] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramRV[114].Value = ReasonForNotRecomdNReferred;
                paramRV[115] = new OleDbParameter("@FatherSpouseName", OleDbType.VarChar, 100);
                paramRV[115].Value = FatherSpouseName;
                paramRV[116] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramRV[116].Value = DateTimeOfVerification;
                paramRV[117] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramRV[117].Value = AddedBy;
                paramRV[118] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramRV[118].Value = AddedOn;
                paramRV[119] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                paramRV[119].Value = SeparateBathroom;
                paramRV[120] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                paramRV[120].Value = FamilySeen;
                paramRV[121] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramRV[121].Value = SupervisorComment;
                paramRV[122] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramRV[122].Value = RoofType;
                paramRV[123] = new OleDbParameter("@Verifier", OleDbType.VarChar, 100);
                paramRV[123].Value = Verifier;
                paramRV[124] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                paramRV[124].Value = CityLimit;
                //added by kamal matekar...
                paramRV[125] = new OleDbParameter("@Pager_No", OleDbType.VarChar, 100);
                paramRV[125].Value = PagerNo;
                paramRV[126] = new OleDbParameter("@Visible_Items", OleDbType.VarChar, 100);
                paramRV[126].Value = VisibleItems;
                paramRV[127] = new OleDbParameter("@No_of_Windows", OleDbType.VarChar, 100);
                paramRV[127].Value = NoOfWindow;
                paramRV[128] = new OleDbParameter("@Children", OleDbType.VarChar, 100);
                paramRV[128].Value = NoOfWindow;
                paramRV[129] = new OleDbParameter("@Emp_Designation", OleDbType.VarChar, 500);
                paramRV[129].Value = EmpDesignation;
                paramRV[130] = new OleDbParameter("@Car_Park", OleDbType.VarChar, 500);
                paramRV[130].Value = CarPark;
                paramRV[131] = new OleDbParameter("@Resi_Exti", OleDbType.VarChar, 500);
                paramRV[131].Value = ResiExti;
                paramRV[132] = new OleDbParameter("@Resi_Intl", OleDbType.VarChar, 500);
                paramRV[132].Value = ResiIntl;
                paramRV[133] = new OleDbParameter("@Cons_House", OleDbType.VarChar, 500);
                paramRV[133].Value = ConsHouse;
                paramRV[134] = new OleDbParameter("@Resi_Ext", OleDbType.VarChar, 500);
                paramRV[134].Value = ResiExt;
                paramRV[135] = new OleDbParameter("@OthFeed", OleDbType.VarChar, 500);
                paramRV[135].Value = OthFeed;
                paramRV[136] = new OleDbParameter("@CustPrev", OleDbType.VarChar, 500);
                paramRV[136].Value = CustPrev;
                paramRV[137] = new OleDbParameter("@DatePrev", OleDbType.VarChar, 500);
                paramRV[137].Value = DatePrev;
                paramRV[138] = new OleDbParameter("@TranType", OleDbType.VarChar, 500);
                paramRV[138].Value = TranType;
                paramRV[139] = new OleDbParameter("@PropBought", OleDbType.VarChar, 500);
                paramRV[139].Value = PropBought;
                paramRV[140] = new OleDbParameter("@RelantionProp", OleDbType.VarChar, 500);
                paramRV[140].Value = RelantionProp;
                paramRV[141] = new OleDbParameter("@OtherProp", OleDbType.VarChar, 500);
                paramRV[141].Value = OtherProp;
                paramRV[142] = new OleDbParameter("@OffDeci", OleDbType.VarChar, 500);
                paramRV[142].Value = OffDeci;
                //ended by kamal matekar...........
                //---added by kamal matekar for Barclay Finance PL
                paramRV[143] = new OleDbParameter("@Place_Of_Birth", OleDbType.VarChar, 500);
                paramRV[143].Value = Place_Of_Birth;
                paramRV[144] = new OleDbParameter("@State", OleDbType.VarChar, 500);
                paramRV[144].Value = State;
                paramRV[145] = new OleDbParameter("@Name_Verified_From", OleDbType.VarChar, 500);
                paramRV[145].Value = Name_Verified_From;
                paramRV[146] = new OleDbParameter("@Applicant_Category", OleDbType.VarChar, 500);
                paramRV[146].Value = Applicant_Category;
                paramRV[147] = new OleDbParameter("@If_Salaried_Designation", OleDbType.VarChar, 500);
                paramRV[147].Value = If_Salaried_Designation;
                paramRV[148] = new OleDbParameter("@If_SelfEmployee_Profession", OleDbType.VarChar, 500);
                paramRV[148].Value = If_SelfEmployee_Profession;
                paramRV[149] = new OleDbParameter("@Off_Tel_No", OleDbType.VarChar, 500);
                paramRV[149].Value = Off_Tel_No;
                paramRV[150] = new OleDbParameter("@No_Emp_Seen", OleDbType.VarChar, 500);
                paramRV[150].Value = No_Emp_Seen;
                //----federal finance...
                paramRV[151] = new OleDbParameter("@ResiAdd_CoApp", OleDbType.VarChar, 500);
                paramRV[151].Value = ResiAdd_CoApp;
                paramRV[152] = new OleDbParameter("@LandMark_CoApp", OleDbType.VarChar, 500);
                paramRV[152].Value = LandMark_CoApp;
                paramRV[153] = new OleDbParameter("@TelNo_CoApp", OleDbType.VarChar, 500);
                paramRV[153].Value = TelNo_CoApp;
                paramRV[154] = new OleDbParameter("@PersonContacted_CoApp", OleDbType.VarChar, 500);
                paramRV[154].Value = PersonContacted_CoApp;
                paramRV[155] = new OleDbParameter("@Relationship_CoApp", OleDbType.VarChar, 500);
                paramRV[155].Value = Relationship_CoApp;
                paramRV[156] = new OleDbParameter("@Datetime_Visit_CoApp", OleDbType.VarChar, 500);
                paramRV[156].Value = Datetime_Visit_CoApp;
                paramRV[157] = new OleDbParameter("@DLNo", OleDbType.VarChar, 500);
                paramRV[157].Value = DLNo;
                paramRV[158] = new OleDbParameter("@EillBillResi", OleDbType.VarChar, 500);
                paramRV[158].Value = EillBillResi;
                paramRV[159] = new OleDbParameter("@PersonalAccount", OleDbType.VarChar, 500);
                paramRV[159].Value = PersonalAccount;
                paramRV[160] = new OleDbParameter("@Branch", OleDbType.VarChar, 500);
                paramRV[160].Value = Branch;

                paramRV[161] = new OleDbParameter("@PanNo", OleDbType.VarChar, 500);
                paramRV[161].Value = PanNo;
                paramRV[162] = new OleDbParameter("@TeleBill", OleDbType.VarChar, 500);
                paramRV[162].Value = TeleBill;
                paramRV[163] = new OleDbParameter("@ODLimit", OleDbType.VarChar, 500);
                paramRV[163].Value = ODLimit;
                paramRV[164] = new OleDbParameter("@AccountNo", OleDbType.VarChar, 500);
                paramRV[164].Value = AccountNo;
                paramRV[165] = new OleDbParameter("@VoterId", OleDbType.VarChar, 500);
                paramRV[165].Value = VoterId;
                paramRV[166] = new OleDbParameter("@RationCard", OleDbType.VarChar, 500);
                paramRV[166].Value = RationCard;
                paramRV[167] = new OleDbParameter("@ValueOfFlats", OleDbType.VarChar, 500);
                paramRV[167].Value = ValueOfFlats;
                paramRV[168] = new OleDbParameter("@LevelMaintained", OleDbType.VarChar, 500);
                paramRV[168].Value = LevelMaintained;
                paramRV[169] = new OleDbParameter("@PoliticsParty", OleDbType.VarChar, 500);
                paramRV[169].Value = PoliticsParty;
                paramRV[170] = new OleDbParameter("@Assessment", OleDbType.VarChar, 500);
                paramRV[170].Value = Assessment;

                paramRV[171] = new OleDbParameter("@RepoCollBy", OleDbType.VarChar, 500);
                paramRV[171].Value = RepoCollBy;
                paramRV[172] = new OleDbParameter("@TVRDoneBy", OleDbType.VarChar, 500);
                paramRV[172].Value = TVRDoneBy;
                paramRV[173] = new OleDbParameter("@QCDoneBy", OleDbType.VarChar, 500);
                paramRV[173].Value = QCDoneBy;
                paramRV[174] = new OleDbParameter("@ApprovingOfficer", OleDbType.VarChar, 500);
                paramRV[174].Value = ApprovingOfficer;
                paramRV[175] = new OleDbParameter("@ContentWriter", OleDbType.VarChar, 500);
                paramRV[175].Value = ContentWriter;
                paramRV[176] = new OleDbParameter("@ReportPreparedBy", OleDbType.VarChar, 500);
                paramRV[176].Value = ReportPreparedBy;
                paramRV[177] = new OleDbParameter("@TVRDetails", OleDbType.VarChar, 500);
                paramRV[177].Value = TVRDetails;
                paramRV[178] = new OleDbParameter("@TVR_Status", OleDbType.VarChar, 500);
                paramRV[178].Value = TVR_Status;
                paramRV[179] = new OleDbParameter("@QC_Status", OleDbType.VarChar, 500);
                paramRV[179].Value = QC_Status;
                paramRV[180] = new OleDbParameter("@RepoCollby_Status", OleDbType.VarChar, 500);
                paramRV[180].Value = RepoCollby_Status;

                paramRV[181] = new OleDbParameter("@MaritalStatus_CoApp", OleDbType.VarChar, 500);
                paramRV[181].Value = MaritalStatus_CoApp;
                paramRV[182] = new OleDbParameter("@DOB_CoApp", OleDbType.VarChar, 500);
                paramRV[182].Value = DOB_CoApp;
                paramRV[183] = new OleDbParameter("@Qualification_CoApp", OleDbType.VarChar, 500);
                paramRV[183].Value = Qualification_CoApp;
                paramRV[184] = new OleDbParameter("@NoOfDependent_CoApp", OleDbType.VarChar, 500);
                paramRV[184].Value = NoOfDependent_CoApp;
                paramRV[185] = new OleDbParameter("@FamilyStructure_CoApp", OleDbType.VarChar, 500);
                paramRV[185].Value = FamilyStructure_CoApp;

                 //--ended by kamal matekar...

                //--Added by kamal matekar..for Karvy Financial 
                paramRV[186] = new OleDbParameter("@Address_different", OleDbType.VarChar, 200);
                paramRV[186].Value = Address_different;
                paramRV[187] = new OleDbParameter("@Lessthan1Year_PreAdd", OleDbType.VarChar, 200);
                paramRV[187].Value = Lessthan1Year_PreAdd;
                paramRV[188] = new OleDbParameter("@IfRented_PerMonth", OleDbType.VarChar, 200);
                paramRV[188].Value = IfRented_PerMonth;
                paramRV[189] = new OleDbParameter("@IfFinanceNameOfBank", OleDbType.VarChar, 200);
                paramRV[189].Value = IfFinanceNameOfBank;
                paramRV[190] = new OleDbParameter("@Applicant_NameVerifiedFrom", OleDbType.VarChar, 200);
                paramRV[190].Value = Applicant_NameVerifiedFrom;

                paramRV[191] = new OleDbParameter("@YearOfConstruction", OleDbType.VarChar, 200);
                paramRV[191].Value = YearOfConstruction;
                paramRV[192] = new OleDbParameter("@AppOccupation", OleDbType.VarChar, 200);
                paramRV[192].Value = AppOccupation;
                paramRV[193] = new OleDbParameter("@NatureOfbusiness", OleDbType.VarChar, 200);
                paramRV[193].Value = NatureOfbusiness;
                paramRV[194] = new OleDbParameter("@WorkingSince", OleDbType.VarChar, 200);
                paramRV[194].Value = WorkingSince;
                paramRV[195] = new OleDbParameter("@ProofOfIdentitySeen", OleDbType.VarChar, 200);
                paramRV[195].Value = ProofOfIdentitySeen;
                paramRV[196] = new OleDbParameter("@AddressProofSeen", OleDbType.VarChar, 200);
                paramRV[196].Value = AddressProofSeen;
                paramRV[197] = new OleDbParameter("@Property_IsRented", OleDbType.VarChar, 200);
                paramRV[197].Value = Property_IsRented;
                paramRV[198] = new OleDbParameter("@BackNum", OleDbType.VarChar, 500);
                paramRV[198].Value = BackNum;
                paramRV[199] = new OleDbParameter("@AppliCap", OleDbType.VarChar, 500);
                paramRV[199].Value = AppliCap;
                paramRV[200] = new OleDbParameter("@NameplateOnDoor1", OleDbType.VarChar, 500);
                paramRV[200].Value = NameplateOnDoor1;
                //--ended by kamal matekar...

                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_RVRT SET PERSON_CONTACTED=?,Relationship=?," +
                     "Address=?,CITY=?,PINCODE=?,Landmark=?,TEL_NO_TYPE_PHONE=?,Mobile_No_type_phone=?,Loan_Amount=?,Use_of_loan=?,Product=?,Location_Product=?," +
                     "DOB=?,MARITAL_STATUS=?,EDUCATION_BACKGROUND=?,FAMILY_DETAILS=?,SPOUSE_DETAILS=?,FAMILY_INCOME=?," +
                     "OTHER_DETAILS=?,Loan_Cancellation=?,CREDIT_CARD_LIMIT=?,OTHER_LOAN_DATAIL=?,YEARS_AT_RESIDENCE=?," +
                     "Area_of_House=?,ASSETS=?,DETAIL_FURNITURE_SEEN=?,Ownership_RESIDENCE=?,STAYING_WHOM=?,DSA=?,Tenure=?," +
                     "Months=?,Type=?,Name_Society_Board=?,Nameplate_on_door=?,Ownership_Details=?,Permanent_address=?," +
                     "Number_rooms=?,Approximate_Value=?,Bachelor_Accomodation=?,Locality=?,Vehicles_used=?,Vehicles_financed=?," +
                     "Exterior_Premises=?,interior_Premises=?,Name_Neighbour1=?,ADD_Neighbour1=?,CONFIRM_Neighbour1=?,RESSTATUS_Neighbour1=?," +
                     "Stay_Res_Neighbour1=?,Comments_Neighbour1=?,Name_Neighbour2=?,ADD_Neighbour2=?,CONFIRM_Neighbour2=?,RESSTATUS_Neighbour2=?," +
                     "Stay_Res_Neighbour2=?,Comments_Neighbour2=?,Type_Accmodation=?,Entry_Permitted=?,Identity_Proof_Seen=?," +
                     "Applicant_income=?,Company_name=?,Purpose_loan=?,other_source_income=?,Other_Investment=?,Colour_of_Door=?," +
                     "Room_Type=?,Type_of_House=?,loan_applicant_name=?,Vehicles_Ownership=?,Residence_address_negative=?," +
                     "Approch_Residence=?,Type_Roof=?,Telephone_check=?,Location_house=?,approch_to_house=?," +
                     "Standard_of_Living=?,Walls=?,Flooring=?,IS_appname_address=?,No_of_dependent=?,age_applicant=?,Name_add_third_party=?," +
                     "Time_app_at_home=?,Third_party_comment=?,Address_Proof_Sighted=?,Tallies_current_Address=?,Type_of_Add_Proof=?," +
                     "Resi_OCL=?,Affliated_Political_Party=?,Profile=?,Address_Confirmed=?,How_Cooperative=?,Locating_address=?," +
                     "Agency_Code=?,Accessibility=?,Entrance_Motorable=?,Society_Board_Sighted=?,Mother_Name=?,Address_Company=?," +
                     "Behavior_Person_Contacted=?,Verifier_Comments=?,Verification_status=?,No_of_earning_member=?,If_Vehicle_exist=?," +
                     "Vehicle_Type=?,Door_Locked=?,Sent_Datetime=?,Totals_Yrs_City=?,Name_add_Ref1=?,OCL_than_distance=?,Parking_Facility=?," +
                     "Neg_match=?,Reason_Notrecommended=?,Father_Spouse_Name=?,VERIFICATION_DATETIME=?,MODIFY_BY=?,MODIFY_DATE=?, " +
                     "SEP_BATHROOM_SEEN=?,FAMILY_SEEN=?,SUPERVISOR_COMMENTS=?,ROOF_TYPE=?,Verifier=?,City_Limit=?,Pager_No=?,Visible_Items=?, " +
                     "No_of_Windows=?,Children=?,Emp_Designation=?,Car_Park=?,Resi_Exti=?,Resi_Intl=?,Cons_House=?,Resi_Ext=?,other_feedback=?, " +
                     "CustApp_Prev=?,Date_Prev=?,Tran_Date=?,Prop_Brought=?,Relantion_prop=?,Other_Prop=?,Off_Deci=?, " +
                     "Place_Of_Birth=?,State=?,Name_Verified_From=?,Applicant_Category=?,If_Salaried_Designation=?,If_SelfEmployee_Profession=?,Off_Tel_No=?,No_Emp_Seen=?, " +
                     "ResiAdd_CoApp=?,LandMark_CoApp=?,TelNo_CoApp=?,PersonContacted_CoApp=?,Relationship_CoApp=?,Datetime_Visit_CoApp=?,DLNo=?,EillBillResi=?," +
                     "PersonalAccount=?,Branch=?,PanNo=?,TeleBill=?,ODLimit=?,AccountNo=?,VoterId=?,RationCard=?,ValueOfFlats=?,LevelMaintained=?,PoliticsParty=?,Assessment=?, " +
                     "RepoCollBy=?,TVRDoneBy=?,QCDoneBy=?,ApprovingOfficer=?,ContentWriter=?,ReportPreparedBy=?,TVRDetails=?,TVR_Status=?,QC_Status=?,RepoCollby_Status=?,MaritalStatus_CoApp=?, " +
                     "DOB_CoApp=?,Qualification_CoApp=?,NoOfDependent_CoApp=?,FamilyStructure_CoApp=?,Address_different=?,Lessthan1Year_PreAdd=?,IfRented_PerMonth=?,IfFinanceNameOfBank=?,Applicant_NameVerifiedFrom=?," +
                     "YearOfConstruction=?,AppOccupation=?,NatureOfbusiness=?,WorkingSince=?,ProofOfIdentitySeen=?,AddressProofSeen=?,Property_IsRented=?,PP_Number=?,AppliCap=?,Name_of_Applicant_Conf=? " +
                     "WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 100);
                paramRV[0].Value = NameOfPersonMet;
                paramRV[1] = new OleDbParameter("@Relationship", OleDbType.VarChar, 100);
                paramRV[1].Value = Relationship;
                paramRV[2] = new OleDbParameter("@Address", OleDbType.VarChar, 255);
                paramRV[2].Value = Address;
                paramRV[3] = new OleDbParameter("@City", OleDbType.VarChar, 100);
                paramRV[3].Value = City;
                paramRV[4] = new OleDbParameter("@PinCode", OleDbType.VarChar, 20);
                paramRV[4].Value = PinCode;
                paramRV[5] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramRV[5].Value = Landmark;
                paramRV[6] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramRV[6].Value = TeleNoType;
                paramRV[7] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramRV[7].Value = MobileNoType;
                paramRV[8] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramRV[8].Value = LoanAmount;
                paramRV[9] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 255);
                paramRV[9].Value = UseOfLoan;
                paramRV[10] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramRV[10].Value = Product;
                paramRV[11] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramRV[11].Value = LocationOfProduct;
                paramRV[12] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 30);
                paramRV[12].Value = DateOfBirth;
                paramRV[13] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramRV[13].Value = MaritalStatus;
                paramRV[14] = new OleDbParameter("@EducationalBackground", OleDbType.VarChar, 100);
                paramRV[14].Value = EducationalBackground;
                paramRV[15] = new OleDbParameter("@FamilyDetails", OleDbType.VarChar, 255);
                paramRV[15].Value = FamilyDetails;
                paramRV[16] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 255);
                paramRV[16].Value = DetailsOfWorkingMemberSpouse;
                paramRV[17] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[17].Value = TotalFamIncome;
                paramRV[18] = new OleDbParameter("@DetailsOfWorkingMembersOthers", OleDbType.VarChar, 255);
                paramRV[18].Value = DetailsOfWorkingMembersOthers;
                paramRV[19] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramRV[19].Value = LoanCancellation;
                paramRV[20] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 255);
                paramRV[20].Value = AnyCreditCard;
                paramRV[21] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 255);
                paramRV[21].Value = AnyOtherLoan;
                paramRV[22] = new OleDbParameter("@NoOfYrsAtResidence", OleDbType.VarChar, 20);
                paramRV[22].Value = NoOfYrsAtResidence;
                paramRV[23] = new OleDbParameter("@AreaOfHouse", OleDbType.VarChar, 20);
                paramRV[23].Value = AreaOfHouse;
                paramRV[24] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramRV[24].Value = Assets;
                paramRV[25] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 255);
                paramRV[25].Value = DetailsOfFurnitureSeen;
                paramRV[26] = new OleDbParameter("@OwnershipOfResidence", OleDbType.VarChar, 50);
                paramRV[26].Value = OwnershipOfResidence;
                paramRV[27] = new OleDbParameter("@StayingWithWhom", OleDbType.VarChar, 100);
                paramRV[27].Value = StayingWithWhom;
                paramRV[28] = new OleDbParameter("@DSA", OleDbType.VarChar, 50);
                paramRV[28].Value = DSA;
                paramRV[29] = new OleDbParameter("@Tenure", OleDbType.VarChar, 100);
                paramRV[29].Value = Tenure;
                paramRV[30] = new OleDbParameter("@Months", OleDbType.VarChar, 10);
                paramRV[30].Value = Months;
                paramRV[31] = new OleDbParameter("@TotalFamIncome", OleDbType.VarChar, 50);
                paramRV[31].Value = Type;
                paramRV[32] = new OleDbParameter("@NameOnSocietyAddressBoard", OleDbType.VarChar, 100);
                paramRV[32].Value = NameOnSocietyAddressBoard;
                paramRV[33] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 50);
                paramRV[33].Value = NameplateOnDoor;
                paramRV[34] = new OleDbParameter("@OwnershipDetail", OleDbType.VarChar, 100);
                paramRV[34].Value = OwnershipDetail;
                paramRV[35] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                paramRV[35].Value = PermanentAddress;
                paramRV[36] = new OleDbParameter("@NoOfRooms", OleDbType.VarChar, 50);
                paramRV[36].Value = NoOfRooms;
                paramRV[37] = new OleDbParameter("@ApproximateValue", OleDbType.VarChar, 50);
                paramRV[37].Value = ApproximateValue;
                paramRV[38] = new OleDbParameter("@BachelorAccomodation", OleDbType.VarChar, 50);
                paramRV[38].Value = BachelorAccomodation;
                paramRV[39] = new OleDbParameter("@Locality", OleDbType.VarChar, 50);
                paramRV[39].Value = Locality;
                paramRV[40] = new OleDbParameter("@VehiclesCurrentlyUsed", OleDbType.VarChar, 100);
                paramRV[40].Value = VehiclesCurrentlyUsed;
                paramRV[41] = new OleDbParameter("@VehiclesFinancedNFinancerName", OleDbType.VarChar, 100);
                paramRV[41].Value = VehiclesFinancedNFinancerName;
                paramRV[42] = new OleDbParameter("@DescribeExteriorPremises", OleDbType.VarChar, 100);
                paramRV[42].Value = DescribeExteriorPremises;
                paramRV[43] = new OleDbParameter("@DescribeInteriorPremises", OleDbType.VarChar, 100);
                paramRV[43].Value = DescribeInteriorPremises;
                paramRV[44] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramRV[44].Value = NameOfNeighbour1;
                paramRV[45] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[45].Value = AddressOfNeighbour1;
                paramRV[46] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 100);
                paramRV[46].Value = DoesAppWorkHere1;
                paramRV[47] = new OleDbParameter("@StatusOfResidence1", OleDbType.VarChar, 50);
                paramRV[47].Value = StatusOfResidence1;
                paramRV[48] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 50);
                paramRV[48].Value = MthsOfWorkAtOffice1;
                paramRV[49] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramRV[49].Value = CommentsOfNeighbour1;
                paramRV[50] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramRV[50].Value = NameOfNeighbour2;
                paramRV[51] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[51].Value = AddressOfNeighbour2;
                paramRV[52] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 100);
                paramRV[52].Value = DoesAppWorkHere2;
                paramRV[53] = new OleDbParameter("@StatusOfResidence2", OleDbType.VarChar, 50);
                paramRV[53].Value = StatusOfResidence2;
                paramRV[54] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 50);
                paramRV[54].Value = MthsOfWorkAtOffice2;
                paramRV[55] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramRV[55].Value = CommentsOfNeighbour2;
                paramRV[56] = new OleDbParameter("@TypeOfAccmodation", OleDbType.VarChar, 100);
                paramRV[56].Value = TypeOfAccmodation;
                paramRV[57] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramRV[57].Value = EntryPermitted;
                paramRV[58] = new OleDbParameter("@IdentityProofSeen", OleDbType.VarChar, 50);
                paramRV[58].Value = IdentityProofSeen;
                paramRV[59] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramRV[59].Value = ApplicantIncome;
                paramRV[60] = new OleDbParameter("@NameOfCompany", OleDbType.VarChar, 100);
                paramRV[60].Value = NameOfCompany;
                paramRV[61] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramRV[61].Value = PurposeOfLoanTaken;
                paramRV[62] = new OleDbParameter("@OtherSourceOfIncome", OleDbType.VarChar, 100);
                paramRV[62].Value = OtherSourceOfIncome;
                paramRV[63] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramRV[63].Value = OtherInvestment;
                paramRV[64] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramRV[64].Value = ClourOnDoor;
                paramRV[65] = new OleDbParameter("@RoomType", OleDbType.VarChar, 100);
                paramRV[65].Value = RoomType;
                paramRV[66] = new OleDbParameter("@TypeOfHouse", OleDbType.VarChar, 50);
                paramRV[66].Value = TypeOfHouse;
                paramRV[67] = new OleDbParameter("@AnyOtherLoanOnApplicantName", OleDbType.VarChar, 100);
                paramRV[67].Value = AnyOtherLoanOnApplicantName;
                paramRV[68] = new OleDbParameter("@VehiclesOwnership", OleDbType.VarChar, 100);
                paramRV[68].Value = VehiclesOwnership;
                paramRV[69] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 100);
                paramRV[69].Value = MatchInNegativeList;
                paramRV[70] = new OleDbParameter("@ApproachToResidence", OleDbType.VarChar, 100);
                paramRV[70].Value = ApproachToResidence;
                paramRV[71] = new OleDbParameter("@TypeOfRoof", OleDbType.VarChar, 100);
                paramRV[71].Value = TypeOfRoof;
                paramRV[72] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramRV[72].Value = TeleCDRomCheck;
                paramRV[73] = new OleDbParameter("@LocationOfHouse", OleDbType.VarChar, 100);
                paramRV[73].Value = LocationOfHouse;
                paramRV[74] = new OleDbParameter("@ApporachToHouse", OleDbType.VarChar, 50);
                paramRV[74].Value = ApporachToHouse;
                paramRV[75] = new OleDbParameter("@StandardOfLiving", OleDbType.VarChar, 100);
                paramRV[75].Value = StandardOfLiving;
                paramRV[76] = new OleDbParameter("@Walls", OleDbType.VarChar, 100);
                paramRV[76].Value = Walls;
                paramRV[77] = new OleDbParameter("@Flooring", OleDbType.VarChar, 100);
                paramRV[77].Value = Flooring;
                paramRV[78] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramRV[78].Value = IsAddOfAppSame;
                paramRV[79] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramRV[79].Value = NoOfMembers;
                paramRV[80] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramRV[80].Value = AgeOfApplicant;
                paramRV[81] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramRV[81].Value = NameAddOfThirdParty;
                paramRV[82] = new OleDbParameter("@TimeWhenAppIsHome", OleDbType.VarChar, 50);
                paramRV[82].Value = TimeWhenAppIsHome;
                paramRV[83] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramRV[83].Value = ThirdPartyComments;
                paramRV[84] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 50);
                paramRV[84].Value = AddressProofSighted;
                paramRV[85] = new OleDbParameter("@TalliesWithCurrentAddress", OleDbType.VarChar, 50);
                paramRV[85].Value = TalliesWithCurrentAddress;
                paramRV[86] = new OleDbParameter("@TypeOfAddProof", OleDbType.VarChar, 50);
                paramRV[86].Value = TypeOfAddProof;
                paramRV[87] = new OleDbParameter("@ResiOCL", OleDbType.VarChar, 50);
                paramRV[87].Value = ResiOCL;
                paramRV[88] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramRV[88].Value = IsAffilatedToPoliticalParty;
                paramRV[89] = new OleDbParameter("@Profile", OleDbType.VarChar, 255);
                paramRV[89].Value = Profile;
                paramRV[90] = new OleDbParameter("@AddressConfirmed", OleDbType.VarChar, 50);
                paramRV[90].Value = AddressConfirmed;
                paramRV[91] = new OleDbParameter("@HowCooperativeCustomer", OleDbType.VarChar, 100);
                paramRV[91].Value = HowCooperativeCustomer;
                paramRV[92] = new OleDbParameter("@EaseOfLocation", OleDbType.VarChar, 255);
                paramRV[92].Value = EaseOfLocation;
                paramRV[93] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramRV[93].Value = AgencyCode;
                paramRV[94] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 100);
                paramRV[94].Value = Accessibility;
                paramRV[95] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 50);
                paramRV[95].Value = EntranceMotorable;
                paramRV[96] = new OleDbParameter("@SocietyBoardSighted", OleDbType.VarChar, 50);
                paramRV[96].Value = SocietyBoardSighted;
                paramRV[97] = new OleDbParameter("@MothersName", OleDbType.VarChar, 100);
                paramRV[97].Value = MothersName;
                paramRV[98] = new OleDbParameter("@AddressOfCompany", OleDbType.VarChar, 255);
                paramRV[98].Value = AddressOfCompany;
                paramRV[99] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 100);
                paramRV[99].Value = BehavourOfPersonContact;
                paramRV[100] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramRV[100].Value = VerifierComments;
                paramRV[101] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 50);
                paramRV[101].Value = OverallVerification;
                paramRV[102] = new OleDbParameter("@NoOfEaringMembers", OleDbType.VarChar, 500);
                paramRV[102].Value = NoOfEaringMembers;
                paramRV[103] = new OleDbParameter("@IfVehicleExist", OleDbType.VarChar, 250);
                paramRV[103].Value = IfVehicleExist;
                paramRV[104] = new OleDbParameter("@VehicleType", OleDbType.VarChar, 50);
                paramRV[104].Value = VehicleType;
                paramRV[105] = new OleDbParameter("@DoorLocked", OleDbType.VarChar, 50);
                paramRV[105].Value = DoorLocked;
                paramRV[106] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramRV[106].Value = SendDate;
                paramRV[107] = new OleDbParameter("@TotalYrsInCity", OleDbType.VarChar, 50);
                paramRV[107].Value = TotalYrsInCity;
                paramRV[108] = new OleDbParameter("@NameAddOf1Reference", OleDbType.VarChar, 255);
                paramRV[108].Value = NameAddOf1Reference;
                paramRV[109] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramRV[109].Value = IfOCLDistance;
                paramRV[110] = new OleDbParameter("@ParkingFacility", OleDbType.VarChar, 50);
                paramRV[110].Value = ParkingFacility;
                paramRV[111] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 10);
                paramRV[111].Value = Negmatch;
                paramRV[112] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramRV[112].Value = ReasonForNotRecomdNReferred;
                paramRV[113] = new OleDbParameter("@FatherSpouseName", OleDbType.VarChar, 100);
                paramRV[113].Value = FatherSpouseName;
                paramRV[114] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramRV[114].Value = DateTimeOfVerification;
                paramRV[115] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramRV[115].Value = ModifyBy;
                paramRV[116] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramRV[116].Value = ModifyOn;
                paramRV[117] = new OleDbParameter("@SeparateBathroom", OleDbType.VarChar, 15);
                paramRV[117].Value = SeparateBathroom;
                paramRV[118] = new OleDbParameter("@FamilySeen", OleDbType.VarChar, 15);
                paramRV[118].Value = FamilySeen;
                paramRV[119] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramRV[119].Value = SupervisorComment;
                paramRV[120] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramRV[120].Value = RoofType;
                paramRV[121] = new OleDbParameter("@Verifier", OleDbType.VarChar, 100);
                paramRV[121].Value = Verifier;
                paramRV[122] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                paramRV[122].Value = CityLimit;
                //add by kamal matekar.....
                paramRV[123] = new OleDbParameter("@Pager_No", OleDbType.VarChar, 100);
                paramRV[123].Value = PagerNo;
                paramRV[124] = new OleDbParameter("@Visible_Items", OleDbType.VarChar, 100);
                paramRV[124].Value = VisibleItems;
                paramRV[125] = new OleDbParameter("@No_of_Windows", OleDbType.VarChar, 100);
                paramRV[125].Value = NoOfWindow;
                paramRV[126] = new OleDbParameter("@Children", OleDbType.VarChar, 100);
                paramRV[126].Value = Children;
                paramRV[127] = new OleDbParameter("@Emp_Designation", OleDbType.VarChar, 500);
                paramRV[127].Value = EmpDesignation;
                paramRV[128] = new OleDbParameter("@Car_Park", OleDbType.VarChar, 500);
                paramRV[128].Value = CarPark;
                paramRV[129] = new OleDbParameter("@Resi_Exti", OleDbType.VarChar, 500);
                paramRV[129].Value = ResiExti;
                paramRV[130] = new OleDbParameter("@Resi_Intl", OleDbType.VarChar, 500);
                paramRV[130].Value = ResiIntl;
                paramRV[131] = new OleDbParameter("@Cons_House", OleDbType.VarChar, 500);
                paramRV[131].Value = ConsHouse;
                paramRV[132] = new OleDbParameter("@Resi_Ext", OleDbType.VarChar, 500);
                paramRV[132].Value = ResiExt;

                paramRV[133] = new OleDbParameter("@OthFeed", OleDbType.VarChar, 500);
                paramRV[133].Value = OthFeed;
                paramRV[134] = new OleDbParameter("@CustPrev", OleDbType.VarChar, 500);
                paramRV[134].Value = CustPrev;
                paramRV[135] = new OleDbParameter("@DatePrev", OleDbType.VarChar, 500);
                paramRV[135].Value = DatePrev;
                paramRV[136] = new OleDbParameter("@TranType", OleDbType.VarChar, 500);
                paramRV[136].Value = TranType;
                paramRV[137] = new OleDbParameter("@PropBought", OleDbType.VarChar, 500);
                paramRV[137].Value = PropBought;
                paramRV[138] = new OleDbParameter("@RelantionProp", OleDbType.VarChar, 500);
                paramRV[138].Value = RelantionProp;
                paramRV[139] = new OleDbParameter("@OtherProp", OleDbType.VarChar, 500);
                paramRV[139].Value = OtherProp;
                paramRV[140] = new OleDbParameter("@OffDeci", OleDbType.VarChar, 500);
                paramRV[140].Value = OffDeci;
                //ended by kamal matekar........
                //---added by kamal matekar for Barclay Finance PL
                paramRV[141] = new OleDbParameter("@Place_Of_Birth", OleDbType.VarChar, 500);
                paramRV[141].Value = Place_Of_Birth;
                paramRV[142] = new OleDbParameter("@State", OleDbType.VarChar, 500);
                paramRV[142].Value = State;
                paramRV[143] = new OleDbParameter("@Name_Verified_From", OleDbType.VarChar, 500);
                paramRV[143].Value = Name_Verified_From;
                paramRV[144] = new OleDbParameter("@Applicant_Category", OleDbType.VarChar, 500);
                paramRV[144].Value = Applicant_Category;
                paramRV[145] = new OleDbParameter("@If_Salaried_Designation", OleDbType.VarChar, 500);
                paramRV[145].Value = If_Salaried_Designation;
                paramRV[146] = new OleDbParameter("@If_SelfEmployee_Profession", OleDbType.VarChar, 500);
                paramRV[146].Value = If_SelfEmployee_Profession;
                paramRV[147] = new OleDbParameter("@Off_Tel_No", OleDbType.VarChar, 500);
                paramRV[147].Value = Off_Tel_No;
                paramRV[148] = new OleDbParameter("@No_Emp_Seen", OleDbType.VarChar, 500);
                paramRV[148].Value = No_Emp_Seen;
                //--ended by kamal matekar...
                //--federal finance.............
                paramRV[149] = new OleDbParameter("@ResiAdd_CoApp", OleDbType.VarChar, 500);
                paramRV[149].Value = ResiAdd_CoApp;
                paramRV[150] = new OleDbParameter("@LandMark_CoApp", OleDbType.VarChar, 500);
                paramRV[150].Value = LandMark_CoApp;

                paramRV[151] = new OleDbParameter("@TelNo_CoApp", OleDbType.VarChar, 500);
                paramRV[151].Value = TelNo_CoApp;
                paramRV[152] = new OleDbParameter("@PersonContacted_CoApp", OleDbType.VarChar, 500);
                paramRV[152].Value = PersonContacted_CoApp;
                paramRV[153] = new OleDbParameter("@Relationship_CoApp", OleDbType.VarChar, 500);
                paramRV[153].Value = Relationship_CoApp;
                paramRV[154] = new OleDbParameter("@Datetime_Visit_CoApp", OleDbType.VarChar, 500);
                paramRV[154].Value = Datetime_Visit_CoApp;
                paramRV[155] = new OleDbParameter("@DLNo", OleDbType.VarChar, 500);
                paramRV[155].Value = DLNo;
                paramRV[156] = new OleDbParameter("@EillBillResi", OleDbType.VarChar, 500);
                paramRV[156].Value = EillBillResi;
                paramRV[157] = new OleDbParameter("@PersonalAccount", OleDbType.VarChar, 500);
                paramRV[157].Value = PersonalAccount;
                paramRV[158] = new OleDbParameter("@Branch", OleDbType.VarChar, 500);
                paramRV[158].Value = Branch;
                paramRV[159] = new OleDbParameter("@PanNo", OleDbType.VarChar, 500);
                paramRV[159].Value = PanNo;
                paramRV[160] = new OleDbParameter("@TeleBill", OleDbType.VarChar, 500);
                paramRV[160].Value = TeleBill;

                paramRV[161] = new OleDbParameter("@ODLimit", OleDbType.VarChar, 500);
                paramRV[161].Value = ODLimit;
                paramRV[162] = new OleDbParameter("@AccountNo", OleDbType.VarChar, 500);
                paramRV[162].Value = AccountNo;
                paramRV[163] = new OleDbParameter("@VoterId", OleDbType.VarChar, 500);
                paramRV[163].Value = VoterId;
                paramRV[164] = new OleDbParameter("@RationCard", OleDbType.VarChar, 500);
                paramRV[164].Value = RationCard;
                paramRV[165] = new OleDbParameter("@ValueOfFlats", OleDbType.VarChar, 500);
                paramRV[165].Value = ValueOfFlats;
                paramRV[166] = new OleDbParameter("@LevelMaintained", OleDbType.VarChar, 500);
                paramRV[166].Value = LevelMaintained;
                paramRV[167] = new OleDbParameter("@PoliticsParty", OleDbType.VarChar, 500);
                paramRV[167].Value = PoliticsParty;
                paramRV[168] = new OleDbParameter("@Assessment", OleDbType.VarChar, 500);
                paramRV[168].Value = Assessment;
                paramRV[169] = new OleDbParameter("@RepoCollBy", OleDbType.VarChar, 500);
                paramRV[169].Value = RepoCollBy;
                paramRV[170] = new OleDbParameter("@TVRDoneBy", OleDbType.VarChar, 500);
                paramRV[170].Value = TVRDoneBy;

                paramRV[171] = new OleDbParameter("@QCDoneBy", OleDbType.VarChar, 500);
                paramRV[171].Value = QCDoneBy;
                paramRV[172] = new OleDbParameter("@ApprovingOfficer", OleDbType.VarChar, 500);
                paramRV[172].Value = ApprovingOfficer;
                paramRV[173] = new OleDbParameter("@ContentWriter", OleDbType.VarChar, 500);
                paramRV[173].Value = ContentWriter;
                paramRV[174] = new OleDbParameter("@ReportPreparedBy", OleDbType.VarChar, 500);
                paramRV[174].Value = ReportPreparedBy;
                paramRV[175] = new OleDbParameter("@TVRDetails", OleDbType.VarChar, 500);
                paramRV[175].Value = TVRDetails;
                paramRV[176] = new OleDbParameter("@TVR_Status", OleDbType.VarChar, 500);
                paramRV[176].Value = TVR_Status;
                paramRV[177] = new OleDbParameter("@QC_Status", OleDbType.VarChar, 500);
                paramRV[177].Value = QC_Status;
                paramRV[178] = new OleDbParameter("@RepoCollby_Status", OleDbType.VarChar, 500);
                paramRV[178].Value = RepoCollby_Status;

                paramRV[179] = new OleDbParameter("@MaritalStatus_CoApp", OleDbType.VarChar, 500);
                paramRV[179].Value = MaritalStatus_CoApp;
                paramRV[180] = new OleDbParameter("@DOB_CoApp", OleDbType.VarChar, 500);
                paramRV[180].Value = DOB_CoApp;
                paramRV[181] = new OleDbParameter("@Qualification_CoApp", OleDbType.VarChar, 500);
                paramRV[181].Value = Qualification_CoApp;
                paramRV[182] = new OleDbParameter("@NoOfDependent_CoApp", OleDbType.VarChar, 500);
                paramRV[182].Value = NoOfDependent_CoApp;
                paramRV[183] = new OleDbParameter("@FamilyStructure_CoApp", OleDbType.VarChar, 500);
                paramRV[183].Value = FamilyStructure_CoApp;

                //--added by kamal matekar for Karvy financial On dated 19Nov2010 
                paramRV[184] = new OleDbParameter("@Address_different", OleDbType.VarChar, 200);
                paramRV[184].Value = Address_different;
                paramRV[185] = new OleDbParameter("@Lessthan1Year_PreAdd", OleDbType.VarChar, 200);
                paramRV[185].Value = Lessthan1Year_PreAdd;
                paramRV[186] = new OleDbParameter("@IfRented_PerMonth", OleDbType.VarChar, 200);
                paramRV[186].Value = IfRented_PerMonth;
                paramRV[187] = new OleDbParameter("@IfFinanceNameOfBank", OleDbType.VarChar, 200);
                paramRV[187].Value = IfFinanceNameOfBank;
                paramRV[188] = new OleDbParameter("@Applicant_NameVerifiedFrom", OleDbType.VarChar, 200);
                paramRV[188].Value = Applicant_NameVerifiedFrom;
                paramRV[189] = new OleDbParameter("@YearOfConstruction", OleDbType.VarChar, 200);
                paramRV[189].Value = YearOfConstruction;
                paramRV[190] = new OleDbParameter("@AppOccupation", OleDbType.VarChar, 200);
                paramRV[190].Value = AppOccupation;

                paramRV[191] = new OleDbParameter("@NatureOfbusiness", OleDbType.VarChar, 200);
                paramRV[191].Value = NatureOfbusiness;
                paramRV[192] = new OleDbParameter("@WorkingSince", OleDbType.VarChar, 200);
                paramRV[192].Value = WorkingSince;
                paramRV[193] = new OleDbParameter("@ProofOfIdentitySeen", OleDbType.VarChar, 200);
                paramRV[193].Value = ProofOfIdentitySeen;
                paramRV[194] = new OleDbParameter("@AddressProofSeen", OleDbType.VarChar, 200);
                paramRV[194].Value = AddressProofSeen;
                paramRV[195] = new OleDbParameter("@Property_IsRented", OleDbType.VarChar, 200);
                paramRV[195].Value = Property_IsRented;
                paramRV[196] = new OleDbParameter("@BackNum", OleDbType.VarChar, 500);
                paramRV[196].Value = BackNum;
                paramRV[197] = new OleDbParameter("@AppliCap", OleDbType.VarChar, 500);
                paramRV[197].Value = AppliCap;
                paramRV[198] = new OleDbParameter("@NameplateOnDoor1", OleDbType.VarChar, 500);
                paramRV[198].Value = NameplateOnDoor1;
                //---ended by kamal matekar
                paramRV[199] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[199].Value = CaseId;
                paramRV[200] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[200].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    public string InsertUpdateRLResiVerificationEntry_New()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIVICATION_RESBUSI " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[106];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIVICATION_RESBUSI(CASE_ID,VERIFICATION_TYPE_ID,Relationship,Months_stay_residencE, " +
                       " ROOF_TYPE,Verifier_Comments,Name_Neighbour1,Address_Neighbour1,Neighbour1_confirmation,Month_at_office, " +
                       " Market_Reputation_Neighbour1,DocVeri,Family_Property,Supervisor_Name,Bank_Detail,Card_Type,Card_No,AssetsPurchase, " +
                       " AssetsLocated,SpouseWork,SpouseDesg,FinanceVisible,MunicipalLimit, " +
                       " Branch_Name,Branch_Code,SalaryDect,Other_sources_income,SourceIncome,VeriOtherIncome,Detail_Income,SourceClubIncome,VeriClubIncome, " +
                       " VerifiedThrough,LoanType,LoanFinancier,LoanAmt,LoanTenure,LoanEmi,LoanPaid,LoanType2,LoanFinancier2,LoanAmt2,LoanTenure2,LoanEmi2,LoanPaid2,LoanType3, " +
                       " LoanFinancier3,LoanAmt3,LoanTenure3,LoanEmi3,LoanPaid3,Month_Stay_Resi_Neigh1,Office_self_owned1,ConfirmationRes,DedupMatch,EndUseOfTheFunds,"+
                       " Reputationofneighbourhood,NoOfPeople,RegistrationNo,ResTelOwnership,IncomeDocSub,NoOfpplseen,typeofloan,remark,PincodeAddMatch,AddressSetup,MetCust,DesgnConf,MetSecurityGuard,CommunityDominated,Nameverifiedfrom,interiorConditions,Exteriors,NoOfstores,Residenceappear,Domestichelp,wastheapplicantmetaresidence, " +
                       " Earingmembers,Relationshipe,monthlyearing,Verifierthrough,ApplicantstaandinginLocality,namee,phonee,elaborateonthestanding,NegativeFeedbackFromFamily,NegativeFeedbackFromNeighbour,ApplicantCapableOfMaintaining,IfNegBankName,IfNegProduct,DefaultBucket,DefaultAmt,buildingtype,LocalityType,FamilyStructure,ExistingLoanDetails,ExistingVehicleDetails,VehicleRegNo,RouteMap,FileUpload1,Pickupdocument,Businessverification,ITRVerification,VoterIdverification,banksatatmentveri,electricitybillveri) " +
                       " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@Relationship", OleDbType.VarChar, 500);
                paramRV[2].Value = RelAppForGua;
                paramRV[3] = new OleDbParameter("@Months_stay_residencE", OleDbType.VarChar, 500);
                paramRV[3].Value = KnowApp;
                paramRV[4] = new OleDbParameter("@ROOF_TYPE", OleDbType.VarChar, 500);
                paramRV[4].Value = LiabGua;
                paramRV[5] = new OleDbParameter("@EmpDet", OleDbType.VarChar, 500);
                paramRV[5].Value = EmpDet;
                paramRV[6] = new OleDbParameter("@CoAppName", OleDbType.VarChar, 500);
                paramRV[6].Value = CoAppName;
                paramRV[7] = new OleDbParameter("@LoanNo", OleDbType.VarChar, 500);
                paramRV[7].Value = LoanNo;
                paramRV[8] = new OleDbParameter("@AmbResi", OleDbType.VarChar, 500);
                paramRV[8].Value = AmbResi;
                paramRV[9] = new OleDbParameter("@CheckDet", OleDbType.VarChar, 500);
                paramRV[9].Value = CheckDet;
                paramRV[10] = new OleDbParameter("@NeCheck", OleDbType.VarChar, 500);
                paramRV[10].Value = NeCheck;
                paramRV[11] = new OleDbParameter("@DocVeri", OleDbType.VarChar, 500);
                paramRV[11].Value = DocVeri;

                //---Added by kamal Matekar
                paramRV[12] = new OleDbParameter("@FamilyProp", OleDbType.VarChar, 500);
                paramRV[12].Value = FamilyProp;
                paramRV[13] = new OleDbParameter("@SupName", OleDbType.VarChar, 500);
                paramRV[13].Value = SupName;
                paramRV[14] = new OleDbParameter("@BankDetail", OleDbType.VarChar, 500);
                paramRV[14].Value = BankDetail;
                paramRV[15] = new OleDbParameter("@CardType", OleDbType.VarChar, 500);
                paramRV[15].Value = CardType;
                paramRV[16] = new OleDbParameter("@CardNo", OleDbType.VarChar, 500);
                paramRV[16].Value = CardNo;
                paramRV[17] = new OleDbParameter("@AssetsPurchase", OleDbType.VarChar, 500);
                paramRV[17].Value = AssetsPurchase;
                paramRV[18] = new OleDbParameter("@AssetsLocated", OleDbType.VarChar, 500);
                paramRV[18].Value = AssetsLocated;
                paramRV[19] = new OleDbParameter("@SpouseWork", OleDbType.VarChar, 500);
                paramRV[19].Value = SpouseWork;
                paramRV[20] = new OleDbParameter("@SpouseDesg", OleDbType.VarChar, 500);
                paramRV[20].Value = SpouseDesg;
                paramRV[21] = new OleDbParameter("@FinanceVisible", OleDbType.VarChar, 500);
                paramRV[21].Value = FinanceVisible;
                paramRV[22] = new OleDbParameter("@MunicipalLimit", OleDbType.VarChar, 500);
                paramRV[22].Value = MunicipalLimit;

                paramRV[23] = new OleDbParameter("@BranchName", OleDbType.VarChar, 500);
                paramRV[23].Value = BranchName;
                paramRV[24] = new OleDbParameter("@BranchCode", OleDbType.VarChar, 500);
                paramRV[24].Value = BranchCode;
                paramRV[25] = new OleDbParameter("@MonthSalary", OleDbType.VarChar, 500);
                paramRV[25].Value = MonthSalary;
                paramRV[26] = new OleDbParameter("@OtherIncome", OleDbType.VarChar, 500);
                paramRV[26].Value = OtherIncome;
                paramRV[27] = new OleDbParameter("@SourceOthIncome", OleDbType.VarChar, 500);
                paramRV[27].Value = SourceOthIncome;
                paramRV[28] = new OleDbParameter("@VeriOtherIncome", OleDbType.VarChar, 500);
                paramRV[28].Value = VeriOtherIncome;
                paramRV[29] = new OleDbParameter("@ClubbedIncome", OleDbType.VarChar, 500);
                paramRV[29].Value = ClubbedIncome;
                paramRV[30] = new OleDbParameter("@SourceClubIncome", OleDbType.VarChar, 500);
                paramRV[30].Value = SourceClubIncome;
                paramRV[31] = new OleDbParameter("@VeriClub", OleDbType.VarChar, 500);
                paramRV[31].Value = VeriClub;
                paramRV[32] = new OleDbParameter("@VeriThrough", OleDbType.VarChar, 500);
                paramRV[32].Value = VeriThrough;
                paramRV[33] = new OleDbParameter("@LoanType1", OleDbType.VarChar, 500);
                paramRV[33].Value = LoanType1;
                paramRV[34] = new OleDbParameter("@LoanFinancier", OleDbType.VarChar, 500);
                paramRV[34].Value = LoanFinancier;
                paramRV[35] = new OleDbParameter("@LoanAmt", OleDbType.VarChar, 500);
                paramRV[35].Value = LoanAmt;
                paramRV[36] = new OleDbParameter("@LoanTenure", OleDbType.VarChar, 500);
                paramRV[36].Value = LoanTenure;
                paramRV[37] = new OleDbParameter("@LoanEmi", OleDbType.VarChar, 500);
                paramRV[37].Value = LoanEmi;
                paramRV[38] = new OleDbParameter("@LoanPaid", OleDbType.VarChar, 500);
                paramRV[38].Value = LoanPaid;
                paramRV[39] = new OleDbParameter("@LoanType2", OleDbType.VarChar, 500);
                paramRV[39].Value = LoanType2;
                paramRV[40] = new OleDbParameter("@LoanFinancier2", OleDbType.VarChar, 500);
                paramRV[40].Value = LoanFinancier2;
                paramRV[41] = new OleDbParameter("@LoanAmt2", OleDbType.VarChar, 500);
                paramRV[41].Value = LoanAmt2;
                paramRV[42] = new OleDbParameter("@LoanTenure2", OleDbType.VarChar, 500);
                paramRV[42].Value = LoanTenure2;
                paramRV[43] = new OleDbParameter("@LoanEmi2", OleDbType.VarChar, 500);
                paramRV[43].Value = LoanEmi2;
                paramRV[44] = new OleDbParameter("@LoanPaid2", OleDbType.VarChar, 500);
                paramRV[44].Value = LoanPaid2;
                paramRV[45] = new OleDbParameter("@LoanType3", OleDbType.VarChar, 500);
                paramRV[45].Value = LoanType3;
                paramRV[46] = new OleDbParameter("@LoanFinancier3", OleDbType.VarChar, 500);
                paramRV[46].Value = LoanFinancier3;
                paramRV[47] = new OleDbParameter("@LoanAmt3", OleDbType.VarChar, 500);
                paramRV[47].Value = LoanAmt3;
                paramRV[48] = new OleDbParameter("@LoanTenure3", OleDbType.VarChar, 500);
                paramRV[48].Value = LoanTenure3;
                paramRV[49] = new OleDbParameter("@LoanEmi3", OleDbType.VarChar, 500);
                paramRV[49].Value = LoanEmi3;
                paramRV[50] = new OleDbParameter("@LoanPaid3", OleDbType.VarChar, 500);
                paramRV[50].Value = LoanPaid3;
                paramRV[51] = new OleDbParameter("@Purpose", OleDbType.VarChar, 500);
                paramRV[51].Value = Purpose;
                paramRV[52] = new OleDbParameter("@OthPurpose", OleDbType.VarChar, 500);
                paramRV[52].Value = OthPurpose;
                paramRV[53] = new OleDbParameter("@ConfirmationRes", OleDbType.VarChar, 500);
                paramRV[53].Value = ConfirmationRes;
                paramRV[54] = new OleDbParameter("@DedupMatch", OleDbType.VarChar, 500);
                paramRV[54].Value = DedupMatch;
                paramRV[55] = new OleDbParameter("@EndUseOfTheFunds", OleDbType.VarChar, 500);
                paramRV[55].Value = EndUseOfTheFunds;
                paramRV[56] = new OleDbParameter("@Reputationofneighbourhood", OleDbType.VarChar, 500);
                paramRV[56].Value = Reputationofneighbourhood;
                paramRV[57] = new OleDbParameter("@NoOfPeople", OleDbType.VarChar, 500);
                paramRV[57].Value = NoOfPeople;
                paramRV[58] = new OleDbParameter("@RegistrationNo", OleDbType.VarChar, 500);
                paramRV[58].Value = RegistrationNo;
                paramRV[59] = new OleDbParameter("@ResTelOwnership", OleDbType.VarChar, 500);
                paramRV[59].Value = ResTelOwnership;
                paramRV[60] = new OleDbParameter("@IncomeDocSub", OleDbType.VarChar, 500);
                paramRV[60].Value = IncomeDocSub;
                paramRV[61] = new OleDbParameter("@NoOfpplseen", OleDbType.VarChar, 500);
                paramRV[61].Value = NoOfpplseen;
                paramRV[62] = new OleDbParameter("@typeofloan", OleDbType.VarChar, 500);
                paramRV[62].Value = typeofloan;
                paramRV[63] = new OleDbParameter("@remark", OleDbType.VarChar, 500);
                paramRV[63].Value = remark;

                paramRV[64] = new OleDbParameter("@PincodeAddMatch", OleDbType.VarChar, 500);
                paramRV[64].Value = PincodeAddMatch;
                paramRV[65] = new OleDbParameter("@AddressSetup", OleDbType.VarChar, 500);
                paramRV[65].Value = AddressSetup;
                paramRV[66] = new OleDbParameter("@MetCust", OleDbType.VarChar, 500);
                paramRV[66].Value = MetCust;
                paramRV[67] = new OleDbParameter("@DesgnConf", OleDbType.VarChar, 500);
                paramRV[67].Value = DesgnConf;
                paramRV[68] = new OleDbParameter("@MetSecurityGuard", OleDbType.VarChar, 500);
                paramRV[68].Value = MetSecurityGuard;
                paramRV[69] = new OleDbParameter("@CommunityDominated", OleDbType.VarChar, 500);
                paramRV[69].Value = CommunityDominated;
                paramRV[70] = new OleDbParameter("@Nameverifiedfrom", OleDbType.VarChar, 500);
                paramRV[70].Value = Nameverifiedfrom;
                paramRV[71] = new OleDbParameter("@interiorConditions", OleDbType.VarChar, 500);
                paramRV[71].Value = interiorConditions;
                paramRV[72] = new OleDbParameter("@Exteriors", OleDbType.VarChar, 500);
                paramRV[72].Value = Exteriors;
                paramRV[73] = new OleDbParameter("@NoOfstores", OleDbType.VarChar, 500);
                paramRV[73].Value = NoOfstores;
                paramRV[74] = new OleDbParameter("@Residenceappear", OleDbType.VarChar, 500);
                paramRV[74].Value = Residenceappear;
                paramRV[75] = new OleDbParameter("@Domestichelp", OleDbType.VarChar, 500);
                paramRV[75].Value = Domestichelp;
                paramRV[76] = new OleDbParameter("@wastheapplicantmetaresidence", OleDbType.VarChar, 500);
                paramRV[76].Value = wastheapplicantmetaresidence;

                paramRV[77] = new OleDbParameter("@Earingmembers", OleDbType.VarChar, 500);
                paramRV[77].Value = Earingmembers;
                paramRV[78] = new OleDbParameter("@Relationshipe", OleDbType.VarChar, 500);
                paramRV[78].Value = Relationshipe;
                paramRV[79] = new OleDbParameter("@monthlyearing", OleDbType.VarChar, 500);
                paramRV[79].Value = monthlyearing;
                paramRV[80] = new OleDbParameter("@Verifierthrough", OleDbType.VarChar, 500);
                paramRV[80].Value = Verifierthrough;
                paramRV[81] = new OleDbParameter("@ApplicantstaandinginLocality", OleDbType.VarChar, 500);
                paramRV[81].Value = ApplicantstaandinginLocality;
                paramRV[82] = new OleDbParameter("@namee", OleDbType.VarChar, 500);
                paramRV[82].Value = namee;
                paramRV[83] = new OleDbParameter("@phonee", OleDbType.VarChar, 500);
                paramRV[83].Value = phonee;
                paramRV[84] = new OleDbParameter("@elaborateonthestanding", OleDbType.VarChar, 500);
                paramRV[84].Value = elaborateonthestanding;
                paramRV[85] = new OleDbParameter("@NegativeFeedbackFromFamily", OleDbType.VarChar, 500);
                paramRV[85].Value = NegativeFeedbackFromFamily;
                paramRV[86] = new OleDbParameter("@NegativeFeedbackFromNeighbour", OleDbType.VarChar, 500);
                paramRV[86].Value = NegativeFeedbackFromNeighbour;
                paramRV[87] = new OleDbParameter("@ApplicantCapableOfMaintaining", OleDbType.VarChar, 500);
                paramRV[87].Value = ApplicantCapableOfMaintaining;
                paramRV[88] = new OleDbParameter("@IfNegBankName", OleDbType.VarChar, 500);
                paramRV[88].Value = IfNegBankName;
                paramRV[89] = new OleDbParameter("@IfNegProduct", OleDbType.VarChar, 500);
                paramRV[89].Value = IfNegProduct;
                paramRV[90] = new OleDbParameter("@DefaultBucket", OleDbType.VarChar, 500);
                paramRV[90].Value = DefaultBucket;
                paramRV[91] = new OleDbParameter("@DefaultAmt", OleDbType.VarChar, 500);
                paramRV[91].Value = DefaultAmt;
                paramRV[92] = new OleDbParameter("@buildingtype", OleDbType.VarChar, 500);
                paramRV[92].Value = buildingtype;

                paramRV[93] = new OleDbParameter("@LocalityType", OleDbType.VarChar, 500);
                paramRV[93].Value = LocalityType;
                paramRV[94] = new OleDbParameter("@FamilyStructure", OleDbType.VarChar, 500);
                paramRV[94].Value = FamilyStructure;
                paramRV[95] = new OleDbParameter("@ExistingLoanDetails", OleDbType.VarChar, 500);
                paramRV[95].Value = ExistingLoanDetails;
                paramRV[96] = new OleDbParameter("@ExistingVehicleDetails", OleDbType.VarChar, 500);
                paramRV[96].Value = ExistingVehicleDetails;
                paramRV[97] = new OleDbParameter("@VehicleRegNo", OleDbType.VarChar, 500);
                paramRV[97].Value = VehicleRegNo;
                paramRV[98] = new OleDbParameter("@RouteMap", OleDbType.VarChar, 500);
                paramRV[98].Value = RouteMap;
                paramRV[99] = new OleDbParameter("@FileUpload1", OleDbType.Binary);
                paramRV[99].Value = FileUpload1;

                paramRV[100] = new OleDbParameter("@Pickupdocument", OleDbType.VarChar, 500);
                paramRV[100].Value = Pickupdocument;
                paramRV[101] = new OleDbParameter("@Businessverification", OleDbType.VarChar, 2000);
                paramRV[101].Value = Businessverification;
                paramRV[102] = new OleDbParameter("@ITRVerification", OleDbType.VarChar, 2000);
                paramRV[102].Value = ITRVerification;
                paramRV[103] = new OleDbParameter("@VoterIdverification", OleDbType.VarChar, 2000);
                paramRV[103].Value = VoterIdverification;
                paramRV[104] = new OleDbParameter("@banksatatmentveri", OleDbType.VarChar, 2000);
                paramRV[104].Value = banksatatmentveri;
                paramRV[105] = new OleDbParameter("@electricitybillveri", OleDbType.VarChar, 2000);
                paramRV[105].Value = electricitybillveri;

                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIVICATION_RESBUSI SET Relationship=?,Months_stay_residencE=?," +
                     "ROOF_TYPE=?,Verifier_Comments=?,Name_Neighbour1=?,Address_Neighbour1=?,Neighbour1_confirmation=?, " +
                     "Month_at_office=?,Market_Reputation_Neighbour1=?,DocVeri=?,Family_Property=?,Supervisor_Name=?," +
                     "Bank_Detail=?,Card_Type=?,Card_No=?,AssetsPurchase=?,AssetsLocated=?,SpouseWork=?,SpouseDesg=?,FinanceVisible=?,MunicipalLimit=?, " +
                     "Branch_Name=?,Branch_Code=?,SalaryDect=?,Other_sources_income=?,SourceIncome=?,VeriOtherIncome=?,Detail_Income=?,SourceClubIncome=?,VeriClubIncome=?, " +
                     "VerifiedThrough=?,LoanType=?,LoanFinancier=?,LoanAmt=?,LoanTenure=?,LoanEmi=?,LoanPaid=?,LoanType2=?,LoanFinancier2=?,LoanAmt2=?,LoanTenure2=?,LoanEmi2=?,LoanPaid2=?, " +
                     "LoanType3=?,LoanFinancier3=?,LoanAmt3=?,LoanTenure3=?,LoanEmi3=?,LoanPaid3=?,Month_Stay_Resi_Neigh1=?,Office_self_owned1=?,ConfirmationRes=?,DedupMatch=?,EndUseOfTheFunds=?,"+
                     "Reputationofneighbourhood=?,NoOfPeople=?,RegistrationNo=? ,ResTelOwnership=?,IncomeDocSub=?,NoOfpplseen=?,typeofloan=?,remark=?,PincodeAddMatch=?,AddressSetup=?,MetCust=?,DesgnConf=?,MetSecurityGuard=?,CommunityDominated=?,Nameverifiedfrom=?,interiorConditions=?,Exteriors=?,NoOfstores=?,Residenceappear=?,Domestichelp=?,wastheapplicantmetaresidence=?,"+
                     "Earingmembers=?,Relationshipe=?,monthlyearing=?,Verifierthrough=?,ApplicantstaandinginLocality=?,namee=?,phonee=?,elaborateonthestanding=?,NegativeFeedbackFromFamily=?,NegativeFeedbackFromNeighbour=?,ApplicantCapableOfMaintaining=?,IfNegBankName=?,IfNegProduct=?,DefaultBucket=?,DefaultAmt=?,buildingtype=?,LocalityType=?,FamilyStructure=?,ExistingLoanDetails=?,ExistingVehicleDetails=?,VehicleRegNo=?,RouteMap=?,FileUpload1=?,Pickupdocument=?,Businessverification=?,ITRVerification=?,VoterIdverification=?,banksatatmentveri=?,electricitybillveri=?  WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@Relationship", OleDbType.VarChar, 500);
                paramRV[0].Value = RelAppForGua;
                paramRV[1] = new OleDbParameter("@Months_stay_residencE", OleDbType.VarChar, 500);
                paramRV[1].Value = KnowApp;
                paramRV[2] = new OleDbParameter("@ROOF_TYPE", OleDbType.VarChar, 500);
                paramRV[2].Value = LiabGua;
                paramRV[3] = new OleDbParameter("@EmpDet", OleDbType.VarChar, 500);
                paramRV[3].Value = EmpDet;
                paramRV[4] = new OleDbParameter("@CoAppName", OleDbType.VarChar, 500);
                paramRV[4].Value = CoAppName;
                paramRV[5] = new OleDbParameter("@LoanNo", OleDbType.VarChar, 500);
                paramRV[5].Value = LoanNo;
                paramRV[6] = new OleDbParameter("@AmbResi", OleDbType.VarChar, 500);
                paramRV[6].Value = AmbResi;
                paramRV[7] = new OleDbParameter("@CheckDet", OleDbType.VarChar, 500);
                paramRV[7].Value = CheckDet;
                paramRV[8] = new OleDbParameter("@NeCheck", OleDbType.VarChar, 500);
                paramRV[8].Value = NeCheck;
                paramRV[9] = new OleDbParameter("@DocVeri", OleDbType.VarChar, 500);
                paramRV[9].Value = DocVeri;

                paramRV[10] = new OleDbParameter("@FamilyProp", OleDbType.VarChar, 500);
                paramRV[10].Value = FamilyProp;
                paramRV[11] = new OleDbParameter("@SupName", OleDbType.VarChar, 500);
                paramRV[11].Value = SupName;
                paramRV[12] = new OleDbParameter("@BankDetail", OleDbType.VarChar, 500);
                paramRV[12].Value = BankDetail;
                paramRV[13] = new OleDbParameter("@CardType", OleDbType.VarChar, 500);
                paramRV[13].Value = CardType;
                paramRV[14] = new OleDbParameter("@CardNo", OleDbType.VarChar, 500);
                paramRV[14].Value = CardNo;
                paramRV[15] = new OleDbParameter("@AssetsPurchase", OleDbType.VarChar, 500);
                paramRV[15].Value = AssetsPurchase;
                paramRV[16] = new OleDbParameter("@AssetsLocated", OleDbType.VarChar, 500);
                paramRV[16].Value = AssetsLocated;
                paramRV[17] = new OleDbParameter("@SpouseWork", OleDbType.VarChar, 500);
                paramRV[17].Value = SpouseWork;
                paramRV[18] = new OleDbParameter("@SpouseDesg", OleDbType.VarChar, 500);
                paramRV[18].Value = SpouseDesg;
                paramRV[19] = new OleDbParameter("@FinanceVisible", OleDbType.VarChar, 500);
                paramRV[19].Value = FinanceVisible;
                paramRV[20] = new OleDbParameter("@MunicipalLimit", OleDbType.VarChar, 500);
                paramRV[20].Value = MunicipalLimit;

                paramRV[21] = new OleDbParameter("@BranchName", OleDbType.VarChar, 500);
                paramRV[21].Value = BranchName;
                paramRV[22] = new OleDbParameter("@BranchCode", OleDbType.VarChar, 500);
                paramRV[22].Value = BranchCode;
                paramRV[23] = new OleDbParameter("@MonthSalary", OleDbType.VarChar, 500);
                paramRV[23].Value = MonthSalary;
                paramRV[24] = new OleDbParameter("@OtherIncome", OleDbType.VarChar, 500);
                paramRV[24].Value = OtherIncome;
                paramRV[25] = new OleDbParameter("@SourceOthIncome", OleDbType.VarChar, 500);
                paramRV[25].Value = SourceOthIncome;
                paramRV[26] = new OleDbParameter("@VeriOtherIncome", OleDbType.VarChar, 500);
                paramRV[26].Value = VeriOtherIncome;
                paramRV[27] = new OleDbParameter("@ClubbedIncome", OleDbType.VarChar, 500);
                paramRV[27].Value = ClubbedIncome;
                paramRV[28] = new OleDbParameter("@SourceClubIncome", OleDbType.VarChar, 500);
                paramRV[28].Value = SourceClubIncome;
                paramRV[29] = new OleDbParameter("@VeriClub", OleDbType.VarChar, 500);
                paramRV[29].Value = VeriClub;
                paramRV[30] = new OleDbParameter("@VeriThrough", OleDbType.VarChar, 500);
                paramRV[30].Value = VeriThrough;
                paramRV[31] = new OleDbParameter("@LoanType1", OleDbType.VarChar, 500);
                paramRV[31].Value = LoanType1;
                paramRV[32] = new OleDbParameter("@LoanFinancier", OleDbType.VarChar, 500);
                paramRV[32].Value = LoanFinancier;
                paramRV[33] = new OleDbParameter("@LoanAmt", OleDbType.VarChar, 500);
                paramRV[33].Value = LoanAmt;
                paramRV[34] = new OleDbParameter("@LoanTenure", OleDbType.VarChar, 500);
                paramRV[34].Value = LoanTenure;
                paramRV[35] = new OleDbParameter("@LoanEmi", OleDbType.VarChar, 500);
                paramRV[35].Value = LoanEmi;
                paramRV[36] = new OleDbParameter("@LoanPaid", OleDbType.VarChar, 500);
                paramRV[36].Value = LoanPaid;
                paramRV[37] = new OleDbParameter("@LoanType2", OleDbType.VarChar, 500);
                paramRV[37].Value = LoanType2;
                paramRV[38] = new OleDbParameter("@LoanFinancier2", OleDbType.VarChar, 500);
                paramRV[38].Value = LoanFinancier2;
                paramRV[39] = new OleDbParameter("@LoanAmt2", OleDbType.VarChar, 500);
                paramRV[39].Value = LoanAmt2;
                paramRV[40] = new OleDbParameter("@LoanTenure2", OleDbType.VarChar, 500);
                paramRV[40].Value = LoanTenure2;
                paramRV[41] = new OleDbParameter("@LoanEmi2", OleDbType.VarChar, 500);
                paramRV[41].Value = LoanEmi2;
                paramRV[42] = new OleDbParameter("@LoanPaid2", OleDbType.VarChar, 500);
                paramRV[42].Value = LoanPaid2;
                paramRV[43] = new OleDbParameter("@LoanType3", OleDbType.VarChar, 500);
                paramRV[43].Value = LoanType3;
                paramRV[44] = new OleDbParameter("@LoanFinancier3", OleDbType.VarChar, 500);
                paramRV[44].Value = LoanFinancier3;
                paramRV[45] = new OleDbParameter("@LoanAmt3", OleDbType.VarChar, 500);
                paramRV[45].Value = LoanAmt3;
                paramRV[46] = new OleDbParameter("@LoanTenure3", OleDbType.VarChar, 500);
                paramRV[46].Value = LoanTenure3;
                paramRV[47] = new OleDbParameter("@LoanEmi3", OleDbType.VarChar, 500);
                paramRV[47].Value = LoanEmi3;
                paramRV[48] = new OleDbParameter("@LoanPaid3", OleDbType.VarChar, 500);
                paramRV[48].Value = LoanPaid3;
                paramRV[49] = new OleDbParameter("@Purpose", OleDbType.VarChar, 500);
                paramRV[49].Value = Purpose;
                paramRV[50] = new OleDbParameter("@OthPurpose", OleDbType.VarChar, 500);
                paramRV[50].Value = OthPurpose;
                paramRV[51] = new OleDbParameter("@ConfirmationRes", OleDbType.VarChar, 500);
                paramRV[51].Value = ConfirmationRes;

                paramRV[52] = new OleDbParameter("@DedupMatch", OleDbType.VarChar, 500);
                paramRV[52].Value = DedupMatch;

                paramRV[53] = new OleDbParameter("@EndUseOfTheFunds", OleDbType.VarChar, 500);
                paramRV[53].Value = EndUseOfTheFunds;

                paramRV[54] = new OleDbParameter("@Reputationofneighbourhood", OleDbType.VarChar, 500);
                paramRV[54].Value = Reputationofneighbourhood;

                paramRV[55] = new OleDbParameter("@NoOfPeople", OleDbType.VarChar, 500);
                paramRV[55].Value = NoOfPeople;

                paramRV[56] = new OleDbParameter("@RegistrationNo", OleDbType.VarChar, 500);
                paramRV[56].Value = RegistrationNo;

                paramRV[57] = new OleDbParameter("@ResTelOwnership", OleDbType.VarChar, 500);
                paramRV[57].Value = ResTelOwnership;
                paramRV[58] = new OleDbParameter("@IncomeDocSub", OleDbType.VarChar, 500);
                paramRV[58].Value = IncomeDocSub;
                paramRV[59] = new OleDbParameter("@NoOfpplseen", OleDbType.VarChar, 500);
                paramRV[59].Value = NoOfpplseen;
                paramRV[60] = new OleDbParameter("@typeofloan", OleDbType.VarChar, 500);
                paramRV[60].Value = typeofloan;
                paramRV[61] = new OleDbParameter("@remark", OleDbType.VarChar, 500);
                paramRV[61].Value = remark;


                paramRV[62] = new OleDbParameter("@PincodeAddMatch", OleDbType.VarChar, 500);
                paramRV[62].Value = PincodeAddMatch;
                paramRV[63] = new OleDbParameter("@AddressSetup", OleDbType.VarChar, 500);
                paramRV[63].Value = AddressSetup;
                paramRV[64] = new OleDbParameter("@MetCust", OleDbType.VarChar, 500);
                paramRV[64].Value = MetCust;
                paramRV[65] = new OleDbParameter("@DesgnConf", OleDbType.VarChar, 500);
                paramRV[65].Value = DesgnConf;
                paramRV[66] = new OleDbParameter("@MetSecurityGuard", OleDbType.VarChar, 500);
                paramRV[66].Value = MetSecurityGuard;
                paramRV[67] = new OleDbParameter("@CommunityDominated", OleDbType.VarChar, 500);
                paramRV[67].Value = CommunityDominated;

                paramRV[68] = new OleDbParameter("@Nameverifiedfrom", OleDbType.VarChar, 500);
                paramRV[68].Value = Nameverifiedfrom;

                paramRV[69] = new OleDbParameter("@interiorConditions", OleDbType.VarChar, 500);
                paramRV[69].Value = interiorConditions;

                paramRV[70] = new OleDbParameter("@Exteriors", OleDbType.VarChar, 500);
                paramRV[70].Value = Exteriors;

                paramRV[71] = new OleDbParameter("@NoOfstores", OleDbType.VarChar, 500);
                paramRV[71].Value = NoOfstores;
                paramRV[72] = new OleDbParameter("@Residenceappear", OleDbType.VarChar, 500);
                paramRV[72].Value = Residenceappear;
                paramRV[73] = new OleDbParameter("@Domestichelp", OleDbType.VarChar, 500);
                paramRV[73].Value = Domestichelp;
                paramRV[74] = new OleDbParameter("@wastheapplicantmetaresidence", OleDbType.VarChar, 500);
                paramRV[74].Value = wastheapplicantmetaresidence;

                paramRV[75] = new OleDbParameter("@Earingmembers", OleDbType.VarChar, 500);
                paramRV[75].Value = Earingmembers;
                paramRV[76] = new OleDbParameter("@Relationshipe", OleDbType.VarChar, 500);
                paramRV[76].Value = Relationshipe;
                paramRV[77] = new OleDbParameter("@monthlyearing", OleDbType.VarChar, 500);
                paramRV[77].Value = monthlyearing;
                paramRV[78] = new OleDbParameter("@Verifierthrough", OleDbType.VarChar, 500);
                paramRV[78].Value = Verifierthrough;
                paramRV[79] = new OleDbParameter("@ApplicantstaandinginLocality", OleDbType.VarChar, 500);
                paramRV[79].Value = ApplicantstaandinginLocality;
                paramRV[80] = new OleDbParameter("@namee", OleDbType.VarChar, 500);
                paramRV[80].Value = namee;
                paramRV[81] = new OleDbParameter("@phonee", OleDbType.VarChar, 500);
                paramRV[81].Value = phonee;
                paramRV[82] = new OleDbParameter("@elaborateonthestanding", OleDbType.VarChar, 500);
                paramRV[82].Value = elaborateonthestanding;
                paramRV[83] = new OleDbParameter("@NegativeFeedbackFromFamily", OleDbType.VarChar, 500);
                paramRV[83].Value = NegativeFeedbackFromFamily;
                paramRV[84] = new OleDbParameter("@NegativeFeedbackFromNeighbour", OleDbType.VarChar, 500);
                paramRV[84].Value = NegativeFeedbackFromNeighbour;
                paramRV[85] = new OleDbParameter("@ApplicantCapableOfMaintaining", OleDbType.VarChar, 500);
                paramRV[85].Value = ApplicantCapableOfMaintaining;

                paramRV[86] = new OleDbParameter("@IfNegBankName", OleDbType.VarChar, 500);
                paramRV[86].Value = IfNegBankName;
                paramRV[87] = new OleDbParameter("@IfNegProduct", OleDbType.VarChar, 500);
                paramRV[87].Value = IfNegProduct;
                paramRV[88] = new OleDbParameter("@DefaultBucket", OleDbType.VarChar, 500);
                paramRV[88].Value = DefaultBucket;
                paramRV[89] = new OleDbParameter("@DefaultAmt", OleDbType.VarChar, 500);
                paramRV[89].Value = DefaultAmt;
                paramRV[90] = new OleDbParameter("@buildingtype", OleDbType.VarChar, 500);
                paramRV[90].Value = buildingtype;

                paramRV[91] = new OleDbParameter("@LocalityType", OleDbType.VarChar, 500);
                paramRV[91].Value = LocalityType;
                paramRV[92] = new OleDbParameter("@FamilyStructure", OleDbType.VarChar, 500);
                paramRV[92].Value = FamilyStructure;
                paramRV[93] = new OleDbParameter("@ExistingLoanDetails", OleDbType.VarChar, 500);
                paramRV[93].Value = ExistingLoanDetails;
                paramRV[94] = new OleDbParameter("@ExistingVehicleDetails", OleDbType.VarChar, 500);
                paramRV[94].Value = ExistingVehicleDetails;
                paramRV[95] = new OleDbParameter("@VehicleRegNo", OleDbType.VarChar, 500);
                paramRV[95].Value = VehicleRegNo;
                paramRV[96] = new OleDbParameter("@RouteMap", OleDbType.VarChar, 500);
                paramRV[96].Value = RouteMap;
                paramRV[97] = new OleDbParameter("@FileUpload1", OleDbType.Binary);
                paramRV[97].Value = FileUpload1;

             

                paramRV[98] = new OleDbParameter("@Pickupdocument", OleDbType.VarChar, 500);
                paramRV[98].Value = Pickupdocument;
                paramRV[99] = new OleDbParameter("@Businessverification", OleDbType.VarChar, 2000);
                paramRV[99].Value = Businessverification;
                paramRV[100] = new OleDbParameter("@ITRVerification", OleDbType.VarChar, 2000);
                paramRV[100].Value = ITRVerification;
                paramRV[101] = new OleDbParameter("@VoterIdverification", OleDbType.VarChar, 2000);
                paramRV[101].Value = VoterIdverification;
                paramRV[102] = new OleDbParameter("@banksatatmentveri", OleDbType.VarChar, 2000);
                paramRV[102].Value = banksatatmentveri;
                paramRV[103] = new OleDbParameter("@electricitybillveri", OleDbType.VarChar, 2000);
                paramRV[103].Value = electricitybillveri;

                paramRV[104] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[104].Value = CaseId;
                paramRV[105] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[105].Value = VerificationTypeId;
                sRetVal = "Record updated successfully.";


            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);


            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    #endregion

    public string InsertUpdateRLResiVerificationEntry_Vend()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_REF " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[12];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_REF(CASE_ID,VERIFICATION_TYPE_ID,Name_Seller_conf_neigh,Seller_aware, " +
                       " whom_sell_prop,buyer_name,sell_get_know_buy,sell_finan_institution,out_loan,mortgage,poss_doc,photo_Iden) " +
                       " VALUES(?,?,?,?,?,?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[2].Value = SellConfMem;
                paramRV[3] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[3].Value = SellTran;
                paramRV[4] = new OleDbParameter("@SellProp", OleDbType.VarChar, 500);
                paramRV[4].Value = SellProp;
                paramRV[5] = new OleDbParameter("@NameBuy", OleDbType.VarChar, 500);
                paramRV[5].Value = NameBuy;
                paramRV[6] = new OleDbParameter("@SellKnow", OleDbType.VarChar, 500);
                paramRV[6].Value = SellKnow;
                paramRV[7] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[7].Value = SellLoan;
                paramRV[8] = new OleDbParameter("@OutLoan", OleDbType.VarChar, 500);
                paramRV[8].Value = OutLoan;
                paramRV[9] = new OleDbParameter("@SellMorg", OleDbType.VarChar, 500);
                paramRV[9].Value = SellMorg;
                paramRV[10] = new OleDbParameter("@SellDoc", OleDbType.VarChar, 500);
                paramRV[10].Value = SellDoc;
                paramRV[11] = new OleDbParameter("@SellPhoto", OleDbType.VarChar, 500);
                paramRV[11].Value = SellPhoto;
                
               sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_REF SET Name_Seller_conf_neigh=?,Seller_aware=?,whom_sell_prop=?, " +
                       " buyer_name=?,sell_get_know_buy=?,sell_finan_institution=?,out_loan=?,mortgage=?,poss_doc=?,photo_Iden=? " +
                       " WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[0].Value = SellConfMem;
                paramRV[1] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[1].Value = SellTran;
                paramRV[2] = new OleDbParameter("@SellProp", OleDbType.VarChar, 500);
                paramRV[2].Value = SellProp;
                paramRV[3] = new OleDbParameter("@NameBuy", OleDbType.VarChar, 500);
                paramRV[3].Value = NameBuy;
                paramRV[4] = new OleDbParameter("@SellKnow", OleDbType.VarChar, 500);
                paramRV[4].Value = SellKnow;
                paramRV[5] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[5].Value = SellLoan;
                paramRV[6] = new OleDbParameter("@OutLoan", OleDbType.VarChar, 500);
                paramRV[6].Value = OutLoan;
                paramRV[7] = new OleDbParameter("@SellMorg", OleDbType.VarChar, 500);
                paramRV[7].Value = SellMorg;
                paramRV[8] = new OleDbParameter("@SellDoc", OleDbType.VarChar, 500);
                paramRV[8].Value = SellDoc;
                paramRV[9] = new OleDbParameter("@SellPhoto", OleDbType.VarChar, 500);
                paramRV[9].Value = SellPhoto;
                paramRV[10] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[10].Value = CaseId;
                paramRV[11] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[11].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "31" || VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    public string InsertUpdateRLResiVerificationEntry_Noc()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_REF " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramRV = new OleDbParameter[7];

            if (oledbRead.Read() == false)
            {
                //insert query
                sSql = "INSERT INTO CPV_RL_VERIFICATION_REF(CASE_ID,VERIFICATION_TYPE_ID,Name_Seller_conf_neigh,flat_no,Authenticity, " +
                       " Seller_aware,sell_finan_institution) " +
                       " VALUES(?,?,?,?,?,?,?) ";

                paramRV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[0].Value = CaseId;
                paramRV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[1].Value = VerificationTypeId;
                paramRV[2] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[2].Value = SellConfMem;
                paramRV[3] = new OleDbParameter("@FlatNo", OleDbType.VarChar, 500);
                paramRV[3].Value = FlatNo;
                paramRV[4] = new OleDbParameter("@Authen", OleDbType.VarChar, 500);
                paramRV[4].Value = Authen;
                paramRV[5] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[5].Value = SellTran; 
                paramRV[6] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[6].Value = SellLoan;

                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_REF SET Name_Seller_conf_neigh=?,flat_no=?,Authenticity=?,Seller_aware=?, " +
                       " sell_finan_institution=? WHERE CASE_ID=? and VERIFICATION_TYPE_ID=? ";

                paramRV[0] = new OleDbParameter("@SellConfMem", OleDbType.VarChar, 500);
                paramRV[0].Value = SellConfMem;
                paramRV[1] = new OleDbParameter("@FlatNo", OleDbType.VarChar, 500);
                paramRV[1].Value = FlatNo;
                paramRV[2] = new OleDbParameter("@Authen", OleDbType.VarChar, 500);
                paramRV[2].Value = Authen;
                paramRV[3] = new OleDbParameter("@SellTran", OleDbType.VarChar, 500);
                paramRV[3].Value = SellTran;
                paramRV[4] = new OleDbParameter("@SellLoan", OleDbType.VarChar, 500);
                paramRV[4].Value = SellLoan;
                paramRV[5] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramRV[5].Value = CaseId;
                paramRV[6] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramRV[6].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "31" || VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            //End  Insert into CASE_TRANSACTION_LOG --------------------
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    #region InsertUpdateRLBusiVerificationEntry() Business verification(BV)
    //Function Name    :   InsertCCVerificationEntry
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   02 July 2007.
    //Remarks 		   :   This method is used to insert new verification entry for RL.

    public string InsertUpdateRLBusiVerificationEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;

            sSqlRead = "SELECT Case_ID,VERIFICATION_TYPE_ID from CPV_RL_VERIFICATION_BVBT " +
                       " WHERE Case_ID='" + CaseId + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramBV = new OleDbParameter[321];
            if (oledbRead.Read() == false)
            {
                sSql = "INSERT INTO CPV_RL_VERIFICATION_BVBT(CASE_ID, VERIFICATION_TYPE_ID, Person_Contacted,Designation_contacted_person,PERSON_CONFIRM_ADDRESS,  Name_business, " +
                      "No_year_service,Designation, No_of_emp_seen,Constitutency_business,Type_Office, Locating_Office, IS_res_com_office, Nam_Plate_sighted, " +
                      "Business_Activity_seen, Landmark, Equipment_Stock_sighted, Nature_Job, VisitingCard_obtained, Remarks, Rating,VERIFICATION_DATETIME, Verifier, Supervisor, " +
                      "Match_Negative_List, Name_bank_defaulted, Product_name, Default_which_bucket, AMT_DEFAULT_INR, Telephone_check, OFF_TELL_NO_NAME, " +
                      "Type_oF_Phone, TYPE_OF_MOBILE, Loan_Amount, USE_OF_LOAN, Product, Location_Product, DOB, Marital_Status, Education, Applicant_Income, " +
                      "No_yrs_previous_Employment, Loan_Cancellation, Any_credit_card, Any_other_Loan, Assets_Seen, Furniture_seen, Ownership, Location_OFFICE, " +
                      "Approach_office, Area_around_office, Office_Ambience, Office_OCL, Exterior_conditions, Interior_conditions, Company_Name_board_seen, " +
                      "Is_address_same, No_of_Members, No_of_current_office, Age_applicant, Name_add_third_party, TIME_APP_OFFICE, Third_party_Comment, " +
                      "Is_Negative_area, affilated_political_party, IS_black_area, Profile, Agency_Recommandation, Scoretool_Recommandation, Name_Neighbour1," +
                      "Address_Neighbour1, Confirmation_Neighbour1, Month_at_office1, Market_Reputaion_Neighbour1, Comments_Neighbour1, Name_Neighbour2, " +
                      "Address_Neighbour2, Confirmation_Neighbour2, Month_at_office2, Market_Reputaion_Neighbour2, Comments_Neighbour2, Locality, Accessibility, " +
                      "Business_board_sighted, entry_permited, Aprox_area, Brief_Job_Responsibilities, Behavour_person_contacted, Colour_Door, Type_Industry, " +
                      "Nature_Business, No_of_branches, customer_per_day, If_doctors, Patients_per_day, fees_per_Patient, clinic_visited, Name_Clinic, Architecture, " +
                      "How_long_praticing, Key_Client1, Key_Client2, key_Client3, Office_Address, Office_Name, Business_activity, Enterance_Motorable, " +
                      "Relationship_applicant, Identity_Proof_Seen, Type_Organization, Status_Office, WORK_SHIFT, Business_Proof_Seen, Residential_Address, " +
                      "Other_Investment, Verifier_Comment, Proof_Buss_Activity, Overall_Verification, Total_No_employee, Reason_not_collecting_VC, " +
                      "Office_Door_Locked, Where_Contacted, " +
                      "Sent_Date, Name_Bank, Previous_Employeement_Details, Previous_Emp_Designation, Construction_Office, Easy_Locating_Office, Neg_Match, " +
                      "Reason_Notrecommended, OCL_distance,Agency_name,IS_office_self_Neighbour1,IS_office_self_Neighbour2," +
                      "Level_Business_Activity,IS_res_cum_office_self_owned,Stock_Seen,Months_work_current_office,Purpose_loan,ADD_BY,ADD_DATE, " +
                      "NAME_COLLEGUE,DESGN_DEPT_COLLEGUE,MONTH_COMP_EXIST_ADDRESS,PROFILE_CO_NEIGHBOUR,APPLICANT_NAME_VERIFIED_FROM,ROOF_TYPE,SUPERVISOR_COMMENTS, " +
                      "City_Limit,MainlineBusiness,ValueofNostocksighted,CategoryofCompany,NormalOfficeJob,Customer_Seen,Type_Job,Appli_Work,Appli_JobTrans,Off_Exit, " +
                      "Vehi_Own,Buss_Prem,Ref_Name,Ref_Add,Month_Turn,Number_Bed,Neigh_Check,Clinic_Year,Separate_Resi,Separate_Factory,Separate_Entrance,Separate_Office, " +
                      "Name_Person_2,Relantion_App_2,Form_16,Profile_conf_issu,Profile_conf_colle,Info_provide,Cust_app_Prev,Date_Prev,Off_Deci,Office_Limit,Salary, " +
                      "No_Doctor,Gross_Receipt,Medical_shop,Amt_Rent,Name_Hospital,Name_Machine,Audit_Tax,NoOf_Tax,Gross_MonthReceipt,No_Operation,Sole_Owner,Amt_Invt, " +
                      "Buss_Premises,Fix_Ass,Buss_Manuf,Regi_Sale,Major_Client,Avg_Profit,Avg_Sale,Source_Income,Place_Of_Birth,State,Permanent_Address_If_Different, " +
                      "Type_Of_Accomodation,Approx_Time_When_App_Home,Sourcing_Dsa_Dealer,Existing_Relationship_with_Barclays,Applicant_Category,If_Salaried_Employer_Name, " +
                      "Main_Client,Size_Of_Office,Self_PM_Rent,NoOfYrsAtCurrentOfficeAddress,OtherOfficeLocationDetails,Automation_Level,Approachability, " +
                      "Within_Municipal_Limit,AnyOtherFormOfbusiness,YearsAtCurrentAddress,NoOfYearsInCity,VehicalOwned,AnyOtherAssets,BankParticulars," +
                      "OffAdd_CoApp,LandMark_CoApp,TelNo_CoApp,PersonContacted_CoApp,Designation_CoApp,Datetime_Visit_CoApp,ComStructure,TurnOver,Stock,ITReturn," +
                      "ProfitMargin,DeptClaimed,Wife,Son,LoanType,EMI,Paid,CrLimit,CardNo,CompanyName_CoApp,Dir_Check,WorkExp,OrgCov,OemfName,OemfRelation,OemfOccu,OemfIncome, " +
                      "Dependent,TwoWh,FourWh,SignSeen,FamilyMember,ResiStatus,Outstanding,OtherFeedback,IfFinanceNameOfBank,Property_IsRented,IfRented_PerMonth,SpouseWork, " +
                      "SpouseDesg,SPOUSE_DETAILS,SPOUSE_Address,UseOfAssets,Area,FinanceCompName,make,loan_amt,ResidenceDetails,AccountType,BusinessConfirmed,ConfirmationSetup, "+
                      "DedupMatchr,GeneralAppearance,Inducementoffered,ExactCompanyNameAddress,OfficeAmenities,MultipleCompFromPremises,ShadyOffice,AddressSetup,MetCust,MetRecep,MetColleague,DesgnConf,MetSecurityGuard,CustSameOffice,OfficeOrStock,Doesbranches,NeighbourCheck,NameVerifierNAme,Interiors,Secretary,Furnishingseen,thereaphoneonhisdesk, "+
                      "Earingmembers,Relationshipe,monthlyearing,Verifierthrough,ApplicantstaandinginLocality,namee,phonee,elaborateonthestanding,Businessdealingseen,Financier,FinanceAmount,NoOfBranchtext,CoApplicantName,Addressonfirmed,RouteMap,AverageBillingPerCustomer,PeakBusinessHours,MarketHoliday,VehicleRegNo,VehicleFreeOrFinance,ExistingLoanDetails,AnyConcerningIssue,ReportingTo,FileUpload1) " +
                      "VALUES(" +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?, ?, ?, ?, ?, ?," +
                      "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?,?,?,"+
                      "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                paramBV[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramBV[0].Value = CaseId;
                paramBV[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramBV[1].Value = VerificationTypeId;
                paramBV[2] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 50);
                paramBV[2].Value = NameOfPersonMet;
                paramBV[3] = new OleDbParameter("@NameOfPersonMetDesgn", OleDbType.VarChar, 100);
                paramBV[3].Value = NameOfPersonMetDesgn;
                paramBV[4] = new OleDbParameter("@ApplicantWorkedAgGivenAddress", OleDbType.VarChar, 50);
                paramBV[4].Value = ApplicantWorkedAgGivenAddress;
                paramBV[5] = new OleDbParameter("@NameOfBusiness", OleDbType.VarChar, 100);
                paramBV[5].Value = NameOfBusiness;
                paramBV[6] = new OleDbParameter("@NoOfYrsInservice", OleDbType.VarChar, 50);
                paramBV[6].Value = NoOfYrsInservice;
                paramBV[7] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 100);
                paramBV[7].Value = AppDesignation;
                paramBV[8] = new OleDbParameter("@NoOfEmployeeSeen", OleDbType.VarChar, 50);
                paramBV[8].Value = NoOfEmployeeSeen;
                paramBV[9] = new OleDbParameter("@ConstitutencyOfBusiness", OleDbType.VarChar, 100);
                paramBV[9].Value = ConstitutencyOfBusiness;
                paramBV[10] = new OleDbParameter("@TypeOfOffice", OleDbType.VarChar, 50);
                paramBV[10].Value = TypeOfOffice;
                paramBV[11] = new OleDbParameter("@LocatingOffice", OleDbType.VarChar, 100);
                paramBV[11].Value = LocatingOffice;
                paramBV[12] = new OleDbParameter("@IsResiCumOffice", OleDbType.VarChar, 10);
                paramBV[12].Value = IsResiCumOffice;
                paramBV[13] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 10);
                paramBV[13].Value = NameplateOnDoor;
                paramBV[14] = new OleDbParameter("@IsBusinessActivityseen", OleDbType.VarChar, 50);
                paramBV[14].Value = IsBusinessActivityseen;
                paramBV[15] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramBV[15].Value = Landmark;
                paramBV[16] = new OleDbParameter("@IsEuipStockSighted", OleDbType.VarChar, 100);
                paramBV[16].Value = IsEuipStockSighted;
                paramBV[17] = new OleDbParameter("@NatureOfJob", OleDbType.VarChar, 100);
                paramBV[17].Value = NatureOfJob;
                paramBV[18] = new OleDbParameter("@VisitCardAsProofOfVisit", OleDbType.VarChar, 100);
                paramBV[18].Value = VisitCardAsProofOfVisit;
                paramBV[19] = new OleDbParameter("@Remarks", OleDbType.VarChar, 2000);
                paramBV[19].Value = Remarks;
                paramBV[20] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                paramBV[20].Value = Rating;
                paramBV[21] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramBV[21].Value = DateTimeOfVerification;
                paramBV[22] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                paramBV[22].Value = VerifierName;
                paramBV[23] = new OleDbParameter("@SupervisorName", OleDbType.VarChar, 100);
                paramBV[23].Value = SupervisorName;
                paramBV[24] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 50);
                paramBV[24].Value = MatchInNegativeList;
                paramBV[25] = new OleDbParameter("@NameOfBankDefaultedWith", OleDbType.VarChar, 50);
                paramBV[25].Value = NameOfBankDefaultedWith;
                paramBV[26] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
                paramBV[26].Value = ProductName;
                paramBV[27] = new OleDbParameter("@DefaultInWhichBucket", OleDbType.VarChar, 50);
                paramBV[27].Value = DefaultInWhichBucket;
                paramBV[28] = new OleDbParameter("@AmountOfDefaultINR", OleDbType.VarChar, 50);
                paramBV[28].Value = AmountOfDefaultINR;
                paramBV[29] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramBV[29].Value = TeleCDRomCheck;
                paramBV[30] = new OleDbParameter("@OffTelNoInNameOf", OleDbType.VarChar, 100);
                paramBV[30].Value = OffTelNoInNameOf;
                paramBV[31] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramBV[31].Value = TeleNoType;
                paramBV[32] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramBV[32].Value = MobileNoType;
                paramBV[33] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramBV[33].Value = LoanAmount;
                paramBV[34] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 100);
                paramBV[34].Value = UseOfLoan;
                paramBV[35] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramBV[35].Value = Product;
                paramBV[36] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramBV[36].Value = LocationOfProduct;
                paramBV[37] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                paramBV[37].Value = DateOfBirth;
                paramBV[38] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramBV[38].Value = MaritalStatus;
                paramBV[39] = new OleDbParameter("@Education", OleDbType.VarChar, 100);
                paramBV[39].Value = Education;
                paramBV[40] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramBV[40].Value = ApplicantIncome;
                paramBV[41] = new OleDbParameter("@NoOfYrsAtPrevEmployment", OleDbType.VarChar, 50);
                paramBV[41].Value = NoOfYrsAtPrevEmployment;
                paramBV[42] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramBV[42].Value = LoanCancellation;
                paramBV[43] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 100);
                paramBV[43].Value = AnyCreditCard;
                paramBV[44] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 100);
                paramBV[44].Value = AnyOtherLoan;
                paramBV[45] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramBV[45].Value = Assets;
                paramBV[46] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 100);
                paramBV[46].Value = DetailsOfFurnitureSeen;
                paramBV[47] = new OleDbParameter("@Ownership", OleDbType.VarChar, 100);
                paramBV[47].Value = Ownership;
                paramBV[48] = new OleDbParameter("@LocationOfOffice", OleDbType.VarChar, 100);
                paramBV[48].Value = LocationOfOffice;
                paramBV[49] = new OleDbParameter("@ApproachToOffice", OleDbType.VarChar, 50);
                paramBV[49].Value = ApproachToOffice;
                paramBV[50] = new OleDbParameter("@AreaAroundOffice", OleDbType.VarChar, 50);
                paramBV[50].Value = AreaAroundOffice;
                paramBV[51] = new OleDbParameter("@OfficeAmbience", OleDbType.VarChar, 100);
                paramBV[51].Value = OfficeAmbience;
                paramBV[52] = new OleDbParameter("@OfficeOCL", OleDbType.VarChar, 50);
                paramBV[52].Value = OfficeOCL;
                paramBV[53] = new OleDbParameter("@ExteriorConditions", OleDbType.VarChar, 50);
                paramBV[53].Value = ExteriorConditions;
                paramBV[54] = new OleDbParameter("@InteriorConditions", OleDbType.VarChar, 50);
                paramBV[54].Value = InteriorConditions;
                paramBV[55] = new OleDbParameter("@IsCompanyNameBoardSeen", OleDbType.VarChar, 50);
                paramBV[55].Value = IsCompanyNameBoardSeen;
                paramBV[56] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramBV[56].Value = IsAddOfAppSame;
                paramBV[57] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramBV[57].Value = NoOfMembers;
                paramBV[58] = new OleDbParameter("@NoOfYrsAtCurrentOffice", OleDbType.VarChar, 50);
                paramBV[58].Value = NoOfYrsAtCurrentOffice;
                paramBV[59] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramBV[59].Value = AgeOfApplicant;
                paramBV[60] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramBV[60].Value = NameAddOfThirdParty;
                paramBV[61] = new OleDbParameter("@TimeWhenAppIsInOffice", OleDbType.VarChar, 50);
                paramBV[61].Value = TimeWhenAppIsInOffice;
                paramBV[62] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramBV[62].Value = ThirdPartyComments;
                paramBV[63] = new OleDbParameter("@IsNegativeArea", OleDbType.VarChar, 20);
                paramBV[63].Value = IsNegativeArea;
                paramBV[64] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramBV[64].Value = IsAffilatedToPoliticalParty;
                paramBV[65] = new OleDbParameter("@BlackArea", OleDbType.VarChar, 50);
                paramBV[65].Value = BlackArea;
                paramBV[66] = new OleDbParameter("@Profile", OleDbType.VarChar, 100);
                paramBV[66].Value = Profile;
                paramBV[67] = new OleDbParameter("@AgencyRecommandation", OleDbType.VarChar, 100);
                paramBV[67].Value = AgencyRecommandation;
                paramBV[68] = new OleDbParameter("@ScoretoolRecommandation", OleDbType.VarChar, 100);
                paramBV[68].Value = ScoretoolRecommandation;
                paramBV[69] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramBV[69].Value = NameOfNeighbour1;
                paramBV[70] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[70].Value = AddressOfNeighbour1;
                paramBV[71] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 50);
                paramBV[71].Value = DoesAppWorkHere1;
                paramBV[72] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 10);
                paramBV[72].Value = MthsOfWorkAtOffice1;
                paramBV[73] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                paramBV[73].Value = MarketReputation1;
                paramBV[74] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[74].Value = CommentsOfNeighbour1;
                paramBV[75] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramBV[75].Value = NameOfNeighbour2;
                paramBV[76] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 50);
                paramBV[76].Value = AddressOfNeighbour2;
                paramBV[77] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 50);
                paramBV[77].Value = DoesAppWorkHere2;
                paramBV[78] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 10);
                paramBV[78].Value = MthsOfWorkAtOffice2;
                paramBV[79] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                paramBV[79].Value = MarketReputation2;
                paramBV[80] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramBV[80].Value = CommentsOfNeighbour2;
                paramBV[81] = new OleDbParameter("@Locality", OleDbType.VarChar, 100);
                paramBV[81].Value = Locality;
                paramBV[82] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 50);
                paramBV[82].Value = Accessibility;
                paramBV[83] = new OleDbParameter("@BusinessBoardSighted", OleDbType.VarChar, 50);
                paramBV[83].Value = BusinessBoardSighted;
                paramBV[84] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramBV[84].Value = EntryPermitted;
                paramBV[85] = new OleDbParameter("@ApproximateArea", OleDbType.VarChar, 50);
                paramBV[85].Value = ApproximateArea;
                paramBV[86] = new OleDbParameter("@BriefJobResponsibilities", OleDbType.VarChar, 50);
                paramBV[86].Value = BriefJobResponsibilities;
                paramBV[87] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 50);
                paramBV[87].Value = BehavourOfPersonContact;
                paramBV[88] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramBV[88].Value = ClourOnDoor;
                paramBV[89] = new OleDbParameter("@TypeOfIndustry", OleDbType.VarChar, 100);
                paramBV[89].Value = TypeOfIndustry;
                paramBV[90] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                paramBV[90].Value = NatureOfBusiness;
                paramBV[91] = new OleDbParameter("@NoOfBranches", OleDbType.VarChar, 50);
                paramBV[91].Value = NoOfBranches;
                paramBV[92] = new OleDbParameter("@NoOfCustomerPerDay", OleDbType.VarChar, 50);
                paramBV[92].Value = NoOfCustomerPerDay;
                paramBV[93] = new OleDbParameter("@IfDoctors", OleDbType.VarChar, 10);
                paramBV[93].Value = IfDoctors;
                paramBV[94] = new OleDbParameter("@NoOfPatientsPerDay", OleDbType.VarChar, 10);
                paramBV[94].Value = NoOfPatientsPerDay;
                paramBV[95] = new OleDbParameter("@AvgFeePerPatient", OleDbType.VarChar, 10);
                paramBV[95].Value = AvgFeePerPatient;
                paramBV[96] = new OleDbParameter("@OtherClinicVisited", OleDbType.VarChar, 50);
                paramBV[96].Value = OtherClinicVisited;
                paramBV[97] = new OleDbParameter("@NameOfClinic", OleDbType.VarChar, 100);
                paramBV[97].Value = NameOfClinic;
                paramBV[98] = new OleDbParameter("@IfArchitectureCA", OleDbType.VarChar, 50);
                paramBV[98].Value = IfArchitectureCA;
                paramBV[99] = new OleDbParameter("@IndependentlyYrs", OleDbType.VarChar, 50);
                paramBV[99].Value = IndependentlyYrs;
                paramBV[100] = new OleDbParameter("@KeyClientName1", OleDbType.VarChar, 100);
                paramBV[100].Value = KeyClientName1;
                paramBV[101] = new OleDbParameter("@KeyClientName2", OleDbType.VarChar, 100);
                paramBV[101].Value = KeyClientName2;
                paramBV[102] = new OleDbParameter("@KeyClientName3", OleDbType.VarChar, 100);
                paramBV[102].Value = KeyClientName3;
                paramBV[103] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 100);
                paramBV[103].Value = OfficeAddress;
                paramBV[104] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                paramBV[104].Value = OfficeName;
                paramBV[105] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[105].Value = TypeOfBusinessActivity;
                paramBV[106] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                paramBV[106].Value = EntranceMotorable;
                paramBV[107] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 50);
                paramBV[107].Value = RelationWithApplicant;
                paramBV[108] = new OleDbParameter("@IsIdentityProofSeen", OleDbType.VarChar, 50);
                paramBV[108].Value = IsIdentityProofSeen;
                paramBV[109] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 100);
                paramBV[109].Value = TypeOfOrganization;
                paramBV[110] = new OleDbParameter("@StatusOfOffice", OleDbType.VarChar, 50);
                paramBV[110].Value = StatusOfOffice;
                paramBV[111] = new OleDbParameter("@ShifOfWork", OleDbType.VarChar, 50);
                paramBV[111].Value = ShifOfWork;
                paramBV[112] = new OleDbParameter("@IsBusinessProofSeen", OleDbType.VarChar, 50);
                paramBV[112].Value = IsBusinessProofSeen;
                paramBV[113] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 255);
                paramBV[113].Value = ResidenceAddress;
                paramBV[114] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramBV[114].Value = OtherInvestment;
                paramBV[115] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramBV[115].Value = VerifierComments;
                paramBV[116] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[116].Value = ProofOfBusinessActivity;
                paramBV[117] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                paramBV[117].Value = OverallVerification;
                paramBV[118] = new OleDbParameter("@TotalNoOfEmployees", OleDbType.VarChar, 10);
                paramBV[118].Value = TotalNoOfEmployees;
                paramBV[119] = new OleDbParameter("@ReasonNotCollectingVistingCard", OleDbType.VarChar, 100);
                paramBV[119].Value = ReasonNotCollectingVistingCard;
                paramBV[120] = new OleDbParameter("@IsOfficeDoorLocked", OleDbType.VarChar, 100);
                paramBV[120].Value = IsOfficeDoorLocked;
                paramBV[121] = new OleDbParameter("@WhereContacted", OleDbType.VarChar, 100);
                paramBV[121].Value = WhereContacted;
                paramBV[122] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramBV[122].Value = SendDate;
                paramBV[123] = new OleDbParameter("@NameOfBank", OleDbType.VarChar, 50);
                paramBV[123].Value = NameOfBank;
                paramBV[124] = new OleDbParameter("@DetailOfPreviousOccupation", OleDbType.VarChar, 255);
                paramBV[124].Value = DetailOfPreviousOccupation;
                paramBV[125] = new OleDbParameter("@PrevEmploymentDesgn", OleDbType.VarChar, 100);
                paramBV[125].Value = PrevEmploymentDesgn;
                paramBV[126] = new OleDbParameter("@ConstructionOfOffice", OleDbType.VarChar, 100);
                paramBV[126].Value = ConstructionOfOffice;
                paramBV[127] = new OleDbParameter("@EasyOfLocatingOffice", OleDbType.VarChar, 100);
                paramBV[127].Value = EasyOfLocatingOffice;
                paramBV[128] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 50);
                paramBV[128].Value = Negmatch;
                paramBV[129] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramBV[129].Value = ReasonForNotRecomdNReferred;
                paramBV[130] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramBV[130].Value = IfOCLDistance;
                paramBV[131] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramBV[131].Value = AgencyCode;
                paramBV[132] = new OleDbParameter("@IsOfficeSelfOwnedNeigh1", OleDbType.VarChar, 50);
                paramBV[132].Value = IsOfficeSelfOwnedNeigh1;
                paramBV[133] = new OleDbParameter("@IsOfficeSelfOwnedNeigh2", OleDbType.VarChar, 50);
                paramBV[133].Value = IsOfficeSelfOwnedNeigh2;
                paramBV[134] = new OleDbParameter("@LevelOfBusActivity", OleDbType.VarChar, 100);
                paramBV[134].Value = LevelOfBusActivity;
                paramBV[135] = new OleDbParameter("@IsResiCumOfficeSelfOwned", OleDbType.VarChar, 10);
                paramBV[135].Value = IsResiCumOfficeSelfOwned;
                paramBV[136] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                paramBV[136].Value = StockSeen;
                paramBV[137] = new OleDbParameter("@MthOfWorkCurrentOffice", OleDbType.VarChar, 50);
                paramBV[137].Value = MthOfWorkCurrentOffice;
                paramBV[138] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramBV[138].Value = PurposeOfLoanTaken;
                paramBV[139] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramBV[139].Value = AddedBy;
                paramBV[140] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramBV[140].Value = AddedOn;
                paramBV[141] = new OleDbParameter("@NameOfCollegue", OleDbType.VarChar, 50);
                paramBV[141].Value = NameOfCollegue;
                paramBV[142] = new OleDbParameter("@DesgnDeptCollegue", OleDbType.VarChar, 50);
                paramBV[142].Value = DesgnDeptCollegue;
                paramBV[143] = new OleDbParameter("@MthOfCompExistAtAddress", OleDbType.VarChar, 15);
                paramBV[143].Value = MthOfCompExistAtAddress;
                paramBV[144] = new OleDbParameter("@ProfileCoNeighbour", OleDbType.VarChar, 100);
                paramBV[144].Value = ProfileCoNeighbour;
                paramBV[145] = new OleDbParameter("@AppNameVerifiedFrom", OleDbType.VarChar, 50);
                paramBV[145].Value = AppNameVerifiedFrom;
                paramBV[146] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramBV[146].Value = RoofType;
                paramBV[147] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramBV[147].Value = SupervisorComment;
                paramBV[148] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 250);
                paramBV[148].Value = CityLimit;
                //added by kamal matekar for federal finance
                paramBV[149] = new OleDbParameter("@MainlineBusiness", OleDbType.VarChar, 250);
                paramBV[149].Value = MainlineBusiness;
                paramBV[150] = new OleDbParameter("@ValueofNostocksighted", OleDbType.VarChar, 250);
                paramBV[150].Value = ValueofNostocksighted;
                paramBV[151] = new OleDbParameter("@CategoryofCompany", OleDbType.VarChar, 250);
                paramBV[151].Value = CategoryofCompany;
                paramBV[152] = new OleDbParameter("@NormalOfficeJob", OleDbType.VarChar, 250);
                paramBV[152].Value = NormalOfficeJob;
                paramBV[153] = new OleDbParameter("@CustomerSeen", OleDbType.VarChar, 500);
                paramBV[153].Value = CustomerSeen;
                paramBV[154] = new OleDbParameter("@TypeJob", OleDbType.VarChar, 500);
                paramBV[154].Value = TypeJob;
                paramBV[155] = new OleDbParameter("@Appli_Work", OleDbType.VarChar, 500);
                paramBV[155].Value = AppliWork;
                paramBV[156] = new OleDbParameter("@Appli_JobTrans", OleDbType.VarChar, 500);
                paramBV[156].Value = AppliJobTrans;
                paramBV[157] = new OleDbParameter("@Off_Exit", OleDbType.VarChar, 500);
                paramBV[157].Value = OffExit;
                paramBV[158] = new OleDbParameter("@VehiOwn", OleDbType.VarChar, 500);
                paramBV[158].Value = VehiOwn;
                paramBV[159] = new OleDbParameter("@BussPrem", OleDbType.VarChar, 500);
                paramBV[159].Value = BussPrem;
                paramBV[160] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                paramBV[160].Value = RefName;
                paramBV[161] = new OleDbParameter("@RefAdd", OleDbType.VarChar, 500);
                paramBV[161].Value = RefAdd;
                paramBV[162] = new OleDbParameter("@MonthTurn", OleDbType.VarChar, 500);
                paramBV[162].Value = MonthTurn;
                paramBV[163] = new OleDbParameter("@NumberBed", OleDbType.VarChar, 500);
                paramBV[163].Value = NumberBed;
                paramBV[164] = new OleDbParameter("@NeighCheck", OleDbType.VarChar, 500);
                paramBV[164].Value = NeighCheck;
                paramBV[165] = new OleDbParameter("@ClinicYear", OleDbType.VarChar, 500);
                paramBV[165].Value = ClinicYear;
                paramBV[166] = new OleDbParameter("@SeparateResi", OleDbType.VarChar, 500);
                paramBV[166].Value = SeparateResi;
                paramBV[167] = new OleDbParameter("@SeparateFactory", OleDbType.VarChar, 500);
                paramBV[167].Value = SeparateFactory;
                paramBV[168] = new OleDbParameter("@SeparateEntrance", OleDbType.VarChar, 500);
                paramBV[168].Value = SeparateEntrance;
                paramBV[169] = new OleDbParameter("@SeparateOffice", OleDbType.VarChar, 500);
                paramBV[169].Value = SeparateOffice;
                paramBV[170] = new OleDbParameter("@OfficeLimit", OleDbType.VarChar, 500);
                paramBV[170].Value = OfficeLimit;

                paramBV[171] = new OleDbParameter("@NamePerson2", OleDbType.VarChar, 500);
                paramBV[171].Value = NamePerson2;
                paramBV[172] = new OleDbParameter("@RelantionApp2", OleDbType.VarChar, 500);
                paramBV[172].Value = RelantionApp2;
                paramBV[173] = new OleDbParameter("@Form16", OleDbType.VarChar, 500);
                paramBV[173].Value = Form16;
                paramBV[174] = new OleDbParameter("@ProfileConfIssu", OleDbType.VarChar, 500);
                paramBV[174].Value = ProfileConfIssu;
                paramBV[175] = new OleDbParameter("@ProfileConfColle", OleDbType.VarChar, 500);
                paramBV[175].Value = ProfileConfColle;
                paramBV[176] = new OleDbParameter("@InfoProvide", OleDbType.VarChar, 500);
                paramBV[176].Value = InfoProvide;
                paramBV[177] = new OleDbParameter("@CustAppPrev", OleDbType.VarChar, 500);
                paramBV[177].Value = CustAppPrev;
                paramBV[178] = new OleDbParameter("@DatePrev", OleDbType.VarChar, 500);
                paramBV[178].Value = DatePrev;
                paramBV[179] = new OleDbParameter("@OffDeci", OleDbType.VarChar, 500);
                paramBV[179].Value = OffDeci;
                paramBV[180] = new OleDbParameter("@Salary", OleDbType.VarChar, 500);
                paramBV[180].Value = Salary;

                paramBV[181] = new OleDbParameter("@NoDoctor", OleDbType.VarChar, 500);
                paramBV[181].Value = NoDoctor;
                paramBV[182] = new OleDbParameter("@GrossReceipt", OleDbType.VarChar, 500);
                paramBV[182].Value = GrossReceipt;
                paramBV[183] = new OleDbParameter("@MedicalShop", OleDbType.VarChar, 500);
                paramBV[183].Value = MedicalShop;
                paramBV[184] = new OleDbParameter("@AmtRent", OleDbType.VarChar, 500);
                paramBV[184].Value = AmtRent;
                paramBV[185] = new OleDbParameter("@NameHospital", OleDbType.VarChar, 500);
                paramBV[185].Value = NameHospital;
                paramBV[186] = new OleDbParameter("@NameMachine", OleDbType.VarChar, 500);
                paramBV[186].Value = NameMachine;
                paramBV[187] = new OleDbParameter("@AuditTax", OleDbType.VarChar, 500);
                paramBV[187].Value = AuditTax;
                paramBV[188] = new OleDbParameter("@NoOfTax", OleDbType.VarChar, 500);
                paramBV[188].Value = NoOfTax;
                paramBV[189] = new OleDbParameter("@GrossMonthReceipt", OleDbType.VarChar, 500);
                paramBV[189].Value = GrossMonthReceipt;

                paramBV[190] = new OleDbParameter("@NoOperation", OleDbType.VarChar, 500);
                paramBV[190].Value = NoOperation;
                paramBV[191] = new OleDbParameter("@SoleOwnert", OleDbType.VarChar, 500);
                paramBV[191].Value = SoleOwner;
                paramBV[192] = new OleDbParameter("@AmtInvt", OleDbType.VarChar, 500);
                paramBV[192].Value = AmtInvt;
                paramBV[193] = new OleDbParameter("@BussPremises", OleDbType.VarChar, 500);
                paramBV[193].Value = BussPremises;
                paramBV[194] = new OleDbParameter("@FixAss", OleDbType.VarChar, 500);
                paramBV[194].Value = FixAss;
                paramBV[195] = new OleDbParameter("@BussManuf", OleDbType.VarChar, 500);
                paramBV[195].Value = BussManuf;
                paramBV[196] = new OleDbParameter("@RegiSale", OleDbType.VarChar, 500);
                paramBV[196].Value = RegiSale;
                paramBV[197] = new OleDbParameter("@MajorClient", OleDbType.VarChar, 500);
                paramBV[197].Value = MajorClient;
                paramBV[198] = new OleDbParameter("@AvgProfit", OleDbType.VarChar, 500);
                paramBV[198].Value = AvgProfit;
                paramBV[199] = new OleDbParameter("@AvgSale", OleDbType.VarChar, 500);
                paramBV[199].Value = AvgSale;
                paramBV[200] = new OleDbParameter("@SourceIncome", OleDbType.VarChar, 500);
                paramBV[200].Value = SourceIncome;

                //added by kamal matekar...for Barclays Finance PL Pdf 
                paramBV[201] = new OleDbParameter("@Place_Of_Birth", OleDbType.VarChar, 500);
                paramBV[201].Value = Place_Of_Birth;
                paramBV[202] = new OleDbParameter("@State", OleDbType.VarChar, 500);
                paramBV[202].Value = State;
                paramBV[203] = new OleDbParameter("@Permanent_Address_If_Different", OleDbType.VarChar, 500);
                paramBV[203].Value = Permanent_Address_If_Different;
                paramBV[204] = new OleDbParameter("@Type_Of_Accomodation", OleDbType.VarChar, 500);
                paramBV[204].Value = Type_Of_Accomodation;
                paramBV[205] = new OleDbParameter("@Approx_Time_When_App_Home", OleDbType.VarChar, 500);
                paramBV[205].Value = Approx_Time_When_App_Home;
                paramBV[206] = new OleDbParameter("@Sourcing_Dsa_Dealer", OleDbType.VarChar, 500);
                paramBV[206].Value = Sourcing_Dsa_Dealer;
                paramBV[207] = new OleDbParameter("@Existing_Relationship_with_Barclays", OleDbType.VarChar, 500);
                paramBV[207].Value = Existing_Relationship_with_Barclays;
                paramBV[208] = new OleDbParameter("@Applicant_Category", OleDbType.VarChar, 500);
                paramBV[208].Value = Applicant_Category;
                paramBV[209] = new OleDbParameter("@If_Salaried_Employer_Name", OleDbType.VarChar, 500);
                paramBV[209].Value = If_Salaried_Employer_Name;
                paramBV[210] = new OleDbParameter("@Main_Client", OleDbType.VarChar, 500);
                paramBV[210].Value = Main_Client;

                paramBV[211] = new OleDbParameter("@Size_Of_Office", OleDbType.VarChar, 500);
                paramBV[211].Value = Size_Of_Office;
                paramBV[212] = new OleDbParameter("@Self_PM_Rent", OleDbType.VarChar, 500);
                paramBV[212].Value = Self_PM_Rent;
                paramBV[213] = new OleDbParameter("@NoOfYrsAtCurrentOfficeAddress", OleDbType.VarChar, 500);
                paramBV[213].Value = NoOfYrsAtCurrentOfficeAddress;
                paramBV[214] = new OleDbParameter("@OtherOfficeLocationDetails", OleDbType.VarChar, 500);
                paramBV[214].Value = OtherOfficeLocationDetails;
                paramBV[215] = new OleDbParameter("@Automation_Level", OleDbType.VarChar, 500);
                paramBV[215].Value = Automation_Level;
                paramBV[216] = new OleDbParameter("@Approachability", OleDbType.VarChar, 500);
                paramBV[216].Value = Approachability;
                paramBV[217] = new OleDbParameter("@Within_Municipal_Limit", OleDbType.VarChar, 500);
                paramBV[217].Value = Within_Municipal_Limit;
                paramBV[218] = new OleDbParameter("@AnyOtherFormOfbusiness", OleDbType.VarChar, 500);
                paramBV[218].Value = AnyOtherFormOfbusiness;
                paramBV[219] = new OleDbParameter("@YearsAtCurrentAddress", OleDbType.VarChar, 500);
                paramBV[219].Value = YearsAtCurrentAddress;
                paramBV[220] = new OleDbParameter("@NoOfYearsInCity", OleDbType.VarChar, 500);
                paramBV[220].Value = NoOfYearsInCity;

                paramBV[221] = new OleDbParameter("@VehicalOwned", OleDbType.VarChar, 500);
                paramBV[221].Value = VehicalOwned;
                paramBV[222] = new OleDbParameter("@AnyOtherAssets", OleDbType.VarChar, 500);
                paramBV[222].Value = AnyOtherAssets;
                paramBV[223] = new OleDbParameter("@BankParticulars", OleDbType.VarChar, 500);
                paramBV[223].Value = BankParticulars;

                //---added by kamal matekar for Federal finance On dated 29/07/2010 ...

                paramBV[224] = new OleDbParameter("@OffAdd_CoApp", OleDbType.VarChar, 522);
                paramBV[224].Value = OffAdd_CoApp;
                paramBV[225] = new OleDbParameter("@LandMark_CoApp", OleDbType.VarChar, 522);
                paramBV[225].Value = LandMark_CoApp;
                paramBV[226] = new OleDbParameter("@TelNo_CoApp", OleDbType.VarChar, 522);
                paramBV[226].Value = TelNo_CoApp;
                paramBV[227] = new OleDbParameter("@PersonContacted_CoApp", OleDbType.VarChar, 522);
                paramBV[227].Value = PersonContacted_CoApp;
                paramBV[228] = new OleDbParameter("@Designation_CoApp", OleDbType.VarChar, 522);
                paramBV[228].Value = Designation_CoApp;
                paramBV[229] = new OleDbParameter("@Datetime_Visit_CoApp", OleDbType.VarChar, 522);
                paramBV[229].Value = Datetime_Visit_CoApp;
                paramBV[230] = new OleDbParameter("@ComStructure", OleDbType.VarChar, 522);
                paramBV[230].Value = ComStructure;
                paramBV[231] = new OleDbParameter("@TurnOver", OleDbType.VarChar, 522);
                paramBV[231].Value = TurnOver;
                paramBV[232] = new OleDbParameter("@Stock", OleDbType.VarChar, 522);
                paramBV[232].Value = Stock;
                paramBV[233] = new OleDbParameter("@ITReturn", OleDbType.VarChar, 522);
                paramBV[233].Value = ITReturn;

                paramBV[234] = new OleDbParameter("@ProfitMargin", OleDbType.VarChar, 500);
                paramBV[234].Value = ProfitMargin;
                paramBV[235] = new OleDbParameter("@DeptClaimed", OleDbType.VarChar, 500);
                paramBV[235].Value = DeptClaimed;
                paramBV[236] = new OleDbParameter("@Wife", OleDbType.VarChar, 500);
                paramBV[236].Value = Wife;
                paramBV[237] = new OleDbParameter("@Son", OleDbType.VarChar, 500);
                paramBV[237].Value = Son;
                paramBV[238] = new OleDbParameter("@LoanType", OleDbType.VarChar, 500);
                paramBV[238].Value = LoanType;
                paramBV[239] = new OleDbParameter("@EMI", OleDbType.VarChar, 500);
                paramBV[239].Value = EMI;
                paramBV[240] = new OleDbParameter("@Paid", OleDbType.VarChar, 500);
                paramBV[240].Value = Paid;
                paramBV[241] = new OleDbParameter("@CrLimit", OleDbType.VarChar, 500);
                paramBV[241].Value = CrLimit;
                paramBV[242] = new OleDbParameter("@CardNo", OleDbType.VarChar, 500);
                paramBV[242].Value = CardNo;
                paramBV[243] = new OleDbParameter("@CompanyName_CoApp", OleDbType.VarChar, 500);
                paramBV[243].Value = CompanyName_CoApp;
                paramBV[244] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 500);
                paramBV[244].Value = SepOff;

                paramBV[245] = new OleDbParameter("@WorkExp", OleDbType.VarChar, 500);
                paramBV[245].Value = WorkExp;
                paramBV[246] = new OleDbParameter("@OrgCov", OleDbType.VarChar, 500);
                paramBV[246].Value = OrgCov;
                paramBV[247] = new OleDbParameter("@OemfName", OleDbType.VarChar, 500);
                paramBV[247].Value = OemfName;
                paramBV[248] = new OleDbParameter("@OemfRelation", OleDbType.VarChar, 500);
                paramBV[248].Value = OemfRelation;
                paramBV[249] = new OleDbParameter("@OemfOccu", OleDbType.VarChar, 500);
                paramBV[249].Value = OemfOccu;
                paramBV[250] = new OleDbParameter("@OemfIncome", OleDbType.VarChar, 500);
                paramBV[250].Value = OemfIncome;
                paramBV[251] = new OleDbParameter("@Dependent", OleDbType.VarChar, 500);
                paramBV[251].Value = Dependent;
                paramBV[252] = new OleDbParameter("@TwoWh", OleDbType.VarChar, 500);
                paramBV[252].Value = TwoWh;
                paramBV[253] = new OleDbParameter("@FourWh", OleDbType.VarChar, 500);
                paramBV[253].Value = FourWh;
                paramBV[254] = new OleDbParameter("@SignSeen", OleDbType.VarChar, 500);
                paramBV[254].Value = SignSeen;
                paramBV[255] = new OleDbParameter("@FamilyMember", OleDbType.VarChar, 500);
                paramBV[255].Value = FamilyMember;
                paramBV[256] = new OleDbParameter("@ResiStatus", OleDbType.VarChar, 500);
                paramBV[256].Value = ResiStatus;
                paramBV[257] = new OleDbParameter("@Outstanding", OleDbType.VarChar, 500);
                paramBV[257].Value = Outstanding;
                paramBV[258] = new OleDbParameter("@OtherFeedback", OleDbType.VarChar, 500);
                paramBV[258].Value = OtherFeedback;
                
                paramBV[259] = new OleDbParameter("@IfFinanceNameOfBank", OleDbType.VarChar, 500);
                paramBV[259].Value = IfFinanceNameOfBank;
                paramBV[260] = new OleDbParameter("@Property_IsRented", OleDbType.VarChar, 500);
                paramBV[260].Value = Property_IsRented;
                paramBV[261] = new OleDbParameter("@IfRented_PerMonth", OleDbType.VarChar, 500);
                paramBV[261].Value = IfRented_PerMonth;
                paramBV[262] = new OleDbParameter("@SpouseWork", OleDbType.VarChar, 500);
                paramBV[262].Value = SpouseWork;
                paramBV[263] = new OleDbParameter("@SpouseDesg", OleDbType.VarChar, 500);
                paramBV[263].Value = SpouseDesg;
                paramBV[264] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 500);
                paramBV[264].Value = DetailsOfWorkingMemberSpouse;
                paramBV[265] = new OleDbParameter("@SpouseAdd", OleDbType.VarChar, 500);
                paramBV[265].Value = SpouseAdd;
                paramBV[266] = new OleDbParameter("@UseOfAssets", OleDbType.VarChar, 500);
                paramBV[266].Value = UseOfAssets;
                paramBV[267] = new OleDbParameter("@FaxNo", OleDbType.VarChar, 500);
                paramBV[267].Value = FaxNo;
                paramBV[268] = new OleDbParameter("@FinanceCompName", OleDbType.VarChar, 500);
                paramBV[268].Value = FinanceCompName;
                paramBV[269] = new OleDbParameter("@Purpose1", OleDbType.VarChar, 500);
                paramBV[269].Value = Purpose1;
                paramBV[270] = new OleDbParameter("@OthPurpose1", OleDbType.VarChar, 500);
                paramBV[270].Value = OthPurpose1;
                paramBV[271] = new OleDbParameter("@ResidenceDetails", OleDbType.VarChar, 500);
                paramBV[271].Value = ResidenceDetails;
                paramBV[272] = new OleDbParameter("@AccountType", OleDbType.VarChar, 500);
                paramBV[272].Value = AccountType;
                paramBV[273] = new OleDbParameter("@BusinessConfirmed", OleDbType.VarChar, 500);
                paramBV[273].Value = BusinessConfirmed;
                paramBV[274] = new OleDbParameter("@ConfirmationSetup", OleDbType.VarChar, 500);
                paramBV[274].Value = ConfirmationSetup;
                paramBV[275] = new OleDbParameter("@DedupMatchr", OleDbType.VarChar, 500);
                paramBV[275].Value = DedupMatchr;
                paramBV[276] = new OleDbParameter("@GeneralAppearance", OleDbType.VarChar, 500);
                paramBV[276].Value = GeneralAppearance;
                paramBV[277] = new OleDbParameter("@Inducementoffered", OleDbType.VarChar, 500);
                paramBV[277].Value = Inducementoffered;
                paramBV[278] = new OleDbParameter("@ExactCompanyNameAddress", OleDbType.VarChar, 500);
                paramBV[278].Value = ExactCompanyNameAddress; 

                //nikhil start 18 april 2013 Deutsche Rtl
                paramBV[279] = new OleDbParameter("@OfficeAmenities", OleDbType.VarChar, 500);
                paramBV[279].Value = OfficeAmenities;
                paramBV[280] = new OleDbParameter("@MultipleCompFromPremises", OleDbType.VarChar, 500);
                paramBV[280].Value = MultipleCompFromPremises;
                paramBV[281] = new OleDbParameter("@ShadyOffice", OleDbType.VarChar, 500);
                paramBV[281].Value = ShadyOffice;
                paramBV[282] = new OleDbParameter("@AddressSetup", OleDbType.VarChar, 500);
                paramBV[282].Value = AddressSetup;
                paramBV[283] = new OleDbParameter("@MetColleague", OleDbType.VarChar, 500);
                paramBV[283].Value = MetColleague;
                paramBV[284] = new OleDbParameter("@MetCust", OleDbType.VarChar, 500);
                paramBV[284].Value = MetCust;
                paramBV[285] = new OleDbParameter("@MetRecep  ", OleDbType.VarChar, 500);
                paramBV[285].Value = MetRecep;
                paramBV[286] = new OleDbParameter("@MetSecurityGuard ", OleDbType.VarChar, 500);
                paramBV[286].Value = MetSecurityGuard;
                paramBV[287] = new OleDbParameter("@DesgnConf", OleDbType.VarChar, 500);
                paramBV[287].Value = DesgnConf;
                paramBV[288] = new OleDbParameter("@CustSameOffice", OleDbType.VarChar, 500);
                paramBV[288].Value = CustSameOffice;
                paramBV[289] = new OleDbParameter("@OfficeOrStock ", OleDbType.VarChar, 500);
                paramBV[289].Value = OfficeOrStock;
                paramBV[290] = new OleDbParameter("@Doesbranches ", OleDbType.VarChar, 500);
                paramBV[290].Value = Doesbranches;
                paramBV[291] = new OleDbParameter("@NeighbourCheck ", OleDbType.VarChar, 500);
                paramBV[291].Value = NeighbourCheck;
                paramBV[292] = new OleDbParameter("@NameVerifierNAme ", OleDbType.VarChar, 500);
                paramBV[292].Value = NameVerifierNAme;
                paramBV[293] = new OleDbParameter("@Interiors ", OleDbType.VarChar, 500);
                paramBV[293].Value = Interiors;
                paramBV[294] = new OleDbParameter("@Secretary ", OleDbType.VarChar, 500);
                paramBV[294].Value = Secretary;
                paramBV[295] = new OleDbParameter("@Furnishingseen ", OleDbType.VarChar, 500);
                paramBV[295].Value = Furnishingseen;
                paramBV[296] = new OleDbParameter("@thereaphoneonhisdesk ", OleDbType.VarChar, 500);
                paramBV[296].Value = thereaphoneonhisdesk;
                //nikhil end
                paramBV[297] = new OleDbParameter("@Earingmembers ", OleDbType.VarChar, 500);
                paramBV[297].Value = Earingmembers;
                paramBV[298] = new OleDbParameter("@Relationshipe ", OleDbType.VarChar, 500);
                paramBV[298].Value = Relationshipe;
                paramBV[299] = new OleDbParameter("@monthlyearing ", OleDbType.VarChar, 500);
                paramBV[299].Value = monthlyearing;
                paramBV[300] = new OleDbParameter("@Verifierthrough ", OleDbType.VarChar, 500);
                paramBV[300].Value = Verifierthrough;
                paramBV[301] = new OleDbParameter("@ApplicantstaandinginLocality ", OleDbType.VarChar, 500);
                paramBV[301].Value = ApplicantstaandinginLocality;
                paramBV[302] = new OleDbParameter("@namee ", OleDbType.VarChar, 500);
                paramBV[302].Value = namee;
                paramBV[303] = new OleDbParameter("@phonee ", OleDbType.VarChar, 500);
                paramBV[303].Value = phonee;
                paramBV[304] = new OleDbParameter("@elaborateonthestanding ", OleDbType.VarChar, 500);
                paramBV[304].Value = elaborateonthestanding;
                paramBV[305] = new OleDbParameter("@Businessdealingseen ", OleDbType.VarChar, 500);
                paramBV[305].Value = Businessdealingseen;
                paramBV[306] = new OleDbParameter("@Financier ", OleDbType.VarChar, 500);
                paramBV[306].Value = Financier;
                paramBV[307] = new OleDbParameter("@FinanceAmount ", OleDbType.VarChar, 500);
                paramBV[307].Value = FinanceAmount;
                paramBV[308] = new OleDbParameter("@NoOfBranchtext ", OleDbType.VarChar, 500);
                paramBV[308].Value = NoOfBranchtext;

                paramBV[309] = new OleDbParameter("@CoApplicantName ", OleDbType.VarChar, 500);
                paramBV[309].Value = CoApplicantName;
                paramBV[310] = new OleDbParameter("@Addressonfirmed ", OleDbType.VarChar, 500);
                paramBV[310].Value = Addressonfirmed;
                paramBV[311] = new OleDbParameter("@RouteMap ", OleDbType.VarChar, 500);
                paramBV[311].Value = RouteMap;
                paramBV[312] = new OleDbParameter("@AverageBillingPerCustomer ", OleDbType.VarChar, 500);
                paramBV[312].Value = AverageBillingPerCustomer;
                paramBV[313] = new OleDbParameter("@PeakBusinessHours ", OleDbType.VarChar, 500);
                paramBV[313].Value = PeakBusinessHours;
                paramBV[314] = new OleDbParameter("@MarketHoliday ", OleDbType.VarChar, 500);
                paramBV[314].Value = MarketHoliday;
                paramBV[315] = new OleDbParameter("@VehicleRegNo ", OleDbType.VarChar, 500);
                paramBV[315].Value = VehicleRegNo;
                paramBV[316] = new OleDbParameter("@VehicleFreeOrFinance ", OleDbType.VarChar, 500);
                paramBV[316].Value = VehicleFreeOrFinance;
                paramBV[317] = new OleDbParameter("@ExistingLoanDetails ", OleDbType.VarChar, 500);
                paramBV[317].Value = ExistingLoanDetails;
                paramBV[318] = new OleDbParameter("@AnyConcerningIssue ", OleDbType.VarChar, 500);
                paramBV[318].Value = AnyConcerningIssue;
                paramBV[319] = new OleDbParameter("@ReportingTo ", OleDbType.VarChar, 500);
                paramBV[319].Value = ReportingTo;
                paramBV[320] = new OleDbParameter("@FileUpload1 ", OleDbType.Binary);
                paramBV[320].Value = FileUpload1;
                
                //////////////////////////////////ended////////////////////////////////////////////////////////


                sRetVal = "Record added successfully.";
            }
            else
            {
                //update query
                sSql = "UPDATE CPV_RL_VERIFICATION_BVBT SET Person_Contacted=?,Designation_contacted_person=?,PERSON_CONFIRM_ADDRESS=?,  Name_business=?, " +
                      "No_year_service=?,Designation=?, No_of_emp_seen=?,Constitutency_business=?,Type_Office=?, Locating_Office=?, IS_res_com_office=?, Nam_Plate_sighted=?, " +
                      "Business_Activity_seen=?, Landmark=?, Equipment_Stock_sighted=?, Nature_Job=?, VisitingCard_obtained=?, Remarks=?, Rating=?, VERIFICATION_DATETIME=?,Verifier=?, Supervisor=?, " +
                      "Match_Negative_List=?, Name_bank_defaulted=?, Product_name=?, Default_which_bucket=?, AMT_DEFAULT_INR=?, Telephone_check=?, OFF_TELL_NO_NAME=?, " +
                      "Type_oF_Phone=?, TYPE_OF_MOBILE=?, Loan_Amount=?, USE_OF_LOAN=?, Product=?, Location_Product=?, DOB=?, Marital_Status=?, Education=?, Applicant_Income=?, " +
                      "No_yrs_previous_Employment=?, Loan_Cancellation=?, Any_credit_card=?, Any_other_Loan=?, Assets_Seen=?, Furniture_seen=?, Ownership=?, Location_OFFICE=?, " +
                      "Approach_office=?, Area_around_office=?, Office_Ambience=?, Office_OCL=?, Exterior_conditions=?, Interior_conditions=?, Company_Name_board_seen=?, " +
                      "Is_address_same=?, No_of_Members=?, No_of_current_office=?, Age_applicant=?, Name_add_third_party=?, TIME_APP_OFFICE=?, Third_party_Comment=?, " +
                      "Is_Negative_area=?, affilated_political_party=?, IS_black_area=?, Profile=?, Agency_Recommandation=?, Scoretool_Recommandation=?, Name_Neighbour1=?," +
                      "Address_Neighbour1=?, Confirmation_Neighbour1=?, Month_at_office1=?, Market_Reputaion_Neighbour1=?, Comments_Neighbour1=?, Name_Neighbour2=?, " +
                      "Address_Neighbour2=?, Confirmation_Neighbour2=?, Month_at_office2=?, Market_Reputaion_Neighbour2=?, Comments_Neighbour2=?, Locality=?, Accessibility=?, " +
                      "Business_board_sighted=?, entry_permited=?, Aprox_area=?, Brief_Job_Responsibilities=?, Behavour_person_contacted=?, Colour_Door=?, Type_Industry=?, " +
                      "Nature_Business=?, No_of_branches=?, customer_per_day=?, If_doctors=?, Patients_per_day=?, fees_per_Patient=?, clinic_visited=?, Name_Clinic=?, Architecture=?, " +
                      "How_long_praticing=?, Key_Client1=?, Key_Client2=?, key_Client3=?, Office_Address=?, Office_Name=?, Business_activity=?, Enterance_Motorable=?, " +
                      "Relationship_applicant=?, Identity_Proof_Seen=?, Type_Organization=?, Status_Office=?, WORK_SHIFT=?, Business_Proof_Seen=?, Residential_Address=?, " +
                      "Other_Investment=?, Verifier_Comment=?, Proof_Buss_Activity=?, Overall_Verification=?, Total_No_employee=?, Reason_not_collecting_VC=?, " +
                      "Office_Door_Locked=?, Where_Contacted=?, Sent_Date=?, Name_Bank=?, Previous_Employeement_Details=?, Previous_Emp_Designation=?, Construction_Office=?, Easy_Locating_Office=?, Neg_Match=?, " +
                      "Reason_Notrecommended=?, OCL_distance=?,Agency_name=?,IS_office_self_Neighbour1=?,IS_office_self_Neighbour2=?, " +
                      "Level_Business_Activity=?,IS_res_cum_office_self_owned=?,Stock_Seen=?,Months_work_current_office=?,Purpose_loan=?,MODIFY_BY=?,MODIFY_DATE=?, " +
                      "NAME_COLLEGUE=?,DESGN_DEPT_COLLEGUE=?,MONTH_COMP_EXIST_ADDRESS=?,PROFILE_CO_NEIGHBOUR=?,APPLICANT_NAME_VERIFIED_FROM=?,ROOF_TYPE=?,SUPERVISOR_COMMENTS=?, " +
                      "City_Limit=?,MainlineBusiness=?,ValueofNostocksighted=?,CategoryofCompany=?,NormalOfficeJob=?,Customer_Seen=?,Type_Job=?,Appli_Work=?,Appli_JobTrans=?, " +
                      "Off_Exit=?,Vehi_Own=?,Buss_Prem=?,Ref_Name=?,Ref_Add=?,Month_Turn=?,Number_Bed=?,Neigh_Check=?,Clinic_Year=?,Separate_Resi=?,Separate_Factory=?, " +
                      "Separate_Entrance=?,Separate_Office=?,Office_Limit=?,Name_Person_2=?,Relantion_App_2=?,Form_16=?,Profile_conf_issu=?,Profile_conf_colle=?,Info_provide=?, " +
                      "Cust_app_Prev=?,Date_Prev=?,Off_Deci=?,Salary=?,No_Doctor=?,Gross_Receipt=?,Medical_shop=?,Amt_Rent=?,Name_Hospital=?,Name_Machine=?,Audit_Tax=?,NoOf_Tax=?, " +
                      "Gross_MonthReceipt=?,No_Operation=?,Sole_Owner=?,Amt_Invt=?,Buss_Premises=?,Fix_Ass=?,Buss_Manuf=?,Regi_Sale=?,Major_Client=?,Avg_Profit=?,Avg_Sale=?,Source_Income=?, " +
                      "Place_Of_Birth=?,State=?,Permanent_Address_If_Different=?,Type_Of_Accomodation=?,Approx_Time_When_App_Home=?,Sourcing_Dsa_Dealer=?,Existing_Relationship_with_Barclays=?,Applicant_Category=?,If_Salaried_Employer_Name=?, " +
                      "Main_Client=?,Size_Of_Office=?,Self_PM_Rent=?,NoOfYrsAtCurrentOfficeAddress=?,OtherOfficeLocationDetails=?,Automation_Level=?,Approachability=?, " +
                      "Within_Municipal_Limit=?,AnyOtherFormOfbusiness=?,YearsAtCurrentAddress=?,NoOfYearsInCity=?,VehicalOwned=?,AnyOtherAssets=?,BankParticulars=?, " +
                      "OffAdd_CoApp=?,LandMark_CoApp=?,TelNo_CoApp=?,PersonContacted_CoApp=?,Designation_CoApp=?,Datetime_Visit_CoApp=?,ComStructure=?,TurnOver=?,Stock=?,ITReturn=?," +
                      "ProfitMargin=?,DeptClaimed=?,Wife=?,Son=?,LoanType=?,EMI=?,Paid=?,CrLimit=?,CardNo=?,CompanyName_CoApp=?,Dir_Check=?,WorkExp=?,OrgCov=?,OemfName=?,OemfRelation=?,OemfOccu=?, " +
                      "OemfIncome=?,Dependent=?,TwoWh=?,FourWh=?,SignSeen=?,FamilyMember=?,ResiStatus=?,Outstanding=?,OtherFeedback=?,IfFinanceNameOfBank=?,Property_IsRented=?,IfRented_PerMonth=?, " +
                      "SpouseWork=?,SpouseDesg=?,SPOUSE_DETAILS=?,SPOUSE_Address=?,UseOfAssets=?,Area=?,FinanceCompName=?,make=?,loan_amt=?, " +
                      "ResidenceDetails=?,AccountType=?,BusinessConfirmed=?,ConfirmationSetup=?,DedupMatchr=?,GeneralAppearance=?,Inducementoffered=?,ExactCompanyNameAddress=?, " +
                      "OfficeAmenities=?,MultipleCompFromPremises=?,ShadyOffice=?,AddressSetup=?,MetCust=?,MetRecep=?,MetColleague=?,DesgnConf=?,MetSecurityGuard=?,CustSameOffice=?,OfficeOrStock=?,Doesbranches=?,NeighbourCheck=?,NameVerifierNAme=?,Interiors=?,Secretary=?,Furnishingseen=?,thereaphoneonhisdesk=?, " +
                      "Earingmembers=?,Relationshipe=?,monthlyearing=?,Verifierthrough=?,ApplicantstaandinginLocality=?,namee=?,phonee=?,elaborateonthestanding=?,Businessdealingseen=?,Financier=?,FinanceAmount=?,NoOfBranchtext=?,CoApplicantName=?,Addressonfirmed=?,RouteMap=?,AverageBillingPerCustomer=?,PeakBusinessHours=?,MarketHoliday=?,VehicleRegNo=?,VehicleFreeOrFinance=?,ExistingLoanDetails=?,AnyConcerningIssue=?,ReportingTo=?,FileUpload1=? " +
                      "WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

                paramBV[0] = new OleDbParameter("@NameOfPersonMet", OleDbType.VarChar, 50);
                paramBV[0].Value = NameOfPersonMet;
                paramBV[1] = new OleDbParameter("@NameOfPersonMetDesgn", OleDbType.VarChar, 100);
                paramBV[1].Value = NameOfPersonMetDesgn;
                paramBV[2] = new OleDbParameter("@ApplicantWorkedAgGivenAddress", OleDbType.VarChar, 50);
                paramBV[2].Value = ApplicantWorkedAgGivenAddress;
                paramBV[3] = new OleDbParameter("@NameOfBusiness", OleDbType.VarChar, 100);
                paramBV[3].Value = NameOfBusiness;
                paramBV[4] = new OleDbParameter("@NoOfYrsInservice", OleDbType.VarChar, 50);
                paramBV[4].Value = NoOfYrsInservice;
                paramBV[5] = new OleDbParameter("@AppDesignation", OleDbType.VarChar, 100);
                paramBV[5].Value = AppDesignation;
                paramBV[6] = new OleDbParameter("@NoOfEmployeeSeen", OleDbType.VarChar, 50);
                paramBV[6].Value = NoOfEmployeeSeen;
                paramBV[7] = new OleDbParameter("@ConstitutencyOfBusiness", OleDbType.VarChar, 100);
                paramBV[7].Value = ConstitutencyOfBusiness;
                paramBV[8] = new OleDbParameter("@TypeOfOffice", OleDbType.VarChar, 50);
                paramBV[8].Value = TypeOfOffice;
                paramBV[9] = new OleDbParameter("@LocatingOffice", OleDbType.VarChar, 100);
                paramBV[9].Value = LocatingOffice;
                paramBV[10] = new OleDbParameter("@IsResiCumOffice", OleDbType.VarChar, 10);
                paramBV[10].Value = IsResiCumOffice;
                paramBV[11] = new OleDbParameter("@NameplateOnDoor", OleDbType.VarChar, 10);
                paramBV[11].Value = NameplateOnDoor;
                paramBV[12] = new OleDbParameter("@IsBusinessActivityseen", OleDbType.VarChar, 50);
                paramBV[12].Value = IsBusinessActivityseen;
                paramBV[13] = new OleDbParameter("@Landmark", OleDbType.VarChar, 100);
                paramBV[13].Value = Landmark;
                paramBV[14] = new OleDbParameter("@IsEuipStockSighted", OleDbType.VarChar, 100);
                paramBV[14].Value = IsEuipStockSighted;
                paramBV[15] = new OleDbParameter("@NatureOfJob", OleDbType.VarChar, 100);
                paramBV[15].Value = NatureOfJob;
                paramBV[16] = new OleDbParameter("@VisitCardAsProofOfVisit", OleDbType.VarChar, 100);
                paramBV[16].Value = VisitCardAsProofOfVisit;
                paramBV[17] = new OleDbParameter("@Remarks", OleDbType.VarChar, 2000);
                paramBV[17].Value = Remarks;
                paramBV[18] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                paramBV[18].Value = Rating;
                paramBV[19] = new OleDbParameter("@DateTimeOfVerification", OleDbType.VarChar, 50);
                paramBV[19].Value = DateTimeOfVerification;
                paramBV[20] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                paramBV[20].Value = VerifierName;
                paramBV[21] = new OleDbParameter("@SupervisorName", OleDbType.VarChar, 100);
                paramBV[21].Value = SupervisorName;
                paramBV[22] = new OleDbParameter("@MatchInNegativeList", OleDbType.VarChar, 50);
                paramBV[22].Value = MatchInNegativeList;
                paramBV[23] = new OleDbParameter("@NameOfBankDefaultedWith", OleDbType.VarChar, 50);
                paramBV[23].Value = NameOfBankDefaultedWith;
                paramBV[24] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
                paramBV[24].Value = ProductName;
                paramBV[25] = new OleDbParameter("@DefaultInWhichBucket", OleDbType.VarChar, 50);
                paramBV[25].Value = DefaultInWhichBucket;
                paramBV[26] = new OleDbParameter("@AmountOfDefaultINR", OleDbType.VarChar, 50);
                paramBV[26].Value = AmountOfDefaultINR;
                paramBV[27] = new OleDbParameter("@TeleCDRomCheck", OleDbType.VarChar, 50);
                paramBV[27].Value = TeleCDRomCheck;
                paramBV[28] = new OleDbParameter("@OffTelNoInNameOf", OleDbType.VarChar, 100);
                paramBV[28].Value = OffTelNoInNameOf;
                paramBV[29] = new OleDbParameter("@TeleNoType", OleDbType.VarChar, 100);
                paramBV[29].Value = TeleNoType;
                paramBV[30] = new OleDbParameter("@MobileNoType", OleDbType.VarChar, 100);
                paramBV[30].Value = MobileNoType;
                paramBV[31] = new OleDbParameter("@LoanAmount", OleDbType.VarChar, 50);
                paramBV[31].Value = LoanAmount;
                paramBV[32] = new OleDbParameter("@UseOfLoan", OleDbType.VarChar, 100);
                paramBV[32].Value = UseOfLoan;
                paramBV[33] = new OleDbParameter("@Product", OleDbType.VarChar, 100);
                paramBV[33].Value = Product;
                paramBV[34] = new OleDbParameter("@LocationOfProduct", OleDbType.VarChar, 100);
                paramBV[34].Value = LocationOfProduct;
                paramBV[35] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar, 50);
                paramBV[35].Value = DateOfBirth;
                paramBV[36] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                paramBV[36].Value = MaritalStatus;
                paramBV[37] = new OleDbParameter("@Education", OleDbType.VarChar, 100);
                paramBV[37].Value = Education;
                paramBV[38] = new OleDbParameter("@ApplicantIncome", OleDbType.VarChar, 50);
                paramBV[38].Value = ApplicantIncome;
                paramBV[39] = new OleDbParameter("@NoOfYrsAtPrevEmployment", OleDbType.VarChar, 50);
                paramBV[39].Value = NoOfYrsAtPrevEmployment;
                paramBV[40] = new OleDbParameter("@LoanCancellation", OleDbType.VarChar, 50);
                paramBV[40].Value = LoanCancellation;
                paramBV[41] = new OleDbParameter("@AnyCreditCard", OleDbType.VarChar, 100);
                paramBV[41].Value = AnyCreditCard;
                paramBV[42] = new OleDbParameter("@AnyOtherLoan", OleDbType.VarChar, 100);
                paramBV[42].Value = AnyOtherLoan;
                paramBV[43] = new OleDbParameter("@Assets", OleDbType.VarChar, 100);
                paramBV[43].Value = Assets;
                paramBV[44] = new OleDbParameter("@DetailsOfFurnitureSeen", OleDbType.VarChar, 100);
                paramBV[44].Value = DetailsOfFurnitureSeen;
                paramBV[45] = new OleDbParameter("@Ownership", OleDbType.VarChar, 100);
                paramBV[45].Value = Ownership;
                paramBV[46] = new OleDbParameter("@LocationOfOffice", OleDbType.VarChar, 100);
                paramBV[46].Value = LocationOfOffice;
                paramBV[47] = new OleDbParameter("@ApproachToOffice", OleDbType.VarChar, 50);
                paramBV[47].Value = ApproachToOffice;
                paramBV[48] = new OleDbParameter("@AreaAroundOffice", OleDbType.VarChar, 50);
                paramBV[48].Value = AreaAroundOffice;
                paramBV[49] = new OleDbParameter("@OfficeAmbience", OleDbType.VarChar, 100);
                paramBV[49].Value = OfficeAmbience;
                paramBV[50] = new OleDbParameter("@OfficeOCL", OleDbType.VarChar, 50);
                paramBV[50].Value = OfficeOCL;
                paramBV[51] = new OleDbParameter("@ExteriorConditions", OleDbType.VarChar, 50);
                paramBV[51].Value = ExteriorConditions;
                paramBV[52] = new OleDbParameter("@InteriorConditions", OleDbType.VarChar, 50);
                paramBV[52].Value = InteriorConditions;
                paramBV[53] = new OleDbParameter("@IsCompanyNameBoardSeen", OleDbType.VarChar, 50);
                paramBV[53].Value = IsCompanyNameBoardSeen;
                paramBV[54] = new OleDbParameter("@IsAddOfAppSame", OleDbType.VarChar, 50);
                paramBV[54].Value = IsAddOfAppSame;
                paramBV[55] = new OleDbParameter("@NoOfMembers", OleDbType.VarChar, 50);
                paramBV[55].Value = NoOfMembers;
                paramBV[56] = new OleDbParameter("@NoOfYrsAtCurrentOffice", OleDbType.VarChar, 50);
                paramBV[56].Value = NoOfYrsAtCurrentOffice;
                paramBV[57] = new OleDbParameter("@AgeOfApplicant", OleDbType.VarChar, 50);
                paramBV[57].Value = AgeOfApplicant;
                paramBV[58] = new OleDbParameter("@NameAddOfThirdParty", OleDbType.VarChar, 255);
                paramBV[58].Value = NameAddOfThirdParty;
                paramBV[59] = new OleDbParameter("@TimeWhenAppIsInOffice", OleDbType.VarChar, 50);
                paramBV[59].Value = TimeWhenAppIsInOffice;
                paramBV[60] = new OleDbParameter("@ThirdPartyComments", OleDbType.VarChar, 255);
                paramBV[60].Value = ThirdPartyComments;
                paramBV[61] = new OleDbParameter("@IsNegativeArea", OleDbType.VarChar, 20);
                paramBV[61].Value = IsNegativeArea;
                paramBV[62] = new OleDbParameter("@IsAffilatedToPoliticalParty", OleDbType.VarChar, 50);
                paramBV[62].Value = IsAffilatedToPoliticalParty;
                paramBV[63] = new OleDbParameter("@BlackArea", OleDbType.VarChar, 50);
                paramBV[63].Value = BlackArea;
                paramBV[64] = new OleDbParameter("@Profile", OleDbType.VarChar, 100);
                paramBV[64].Value = Profile;
                paramBV[65] = new OleDbParameter("@AgencyRecommandation", OleDbType.VarChar, 100);
                paramBV[65].Value = AgencyRecommandation;
                paramBV[66] = new OleDbParameter("@ScoretoolRecommandation", OleDbType.VarChar, 100);
                paramBV[66].Value = ScoretoolRecommandation;
                paramBV[67] = new OleDbParameter("@NameOfNeighbour1", OleDbType.VarChar, 100);
                paramBV[67].Value = NameOfNeighbour1;
                paramBV[68] = new OleDbParameter("@AddressOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[68].Value = AddressOfNeighbour1;
                paramBV[69] = new OleDbParameter("@DoesAppWorkHere1", OleDbType.VarChar, 50);
                paramBV[69].Value = DoesAppWorkHere1;
                paramBV[70] = new OleDbParameter("@MthsOfWorkAtOffice1", OleDbType.VarChar, 10);
                paramBV[70].Value = MthsOfWorkAtOffice1;
                paramBV[71] = new OleDbParameter("@MarketReputation1", OleDbType.VarChar, 100);
                paramBV[71].Value = MarketReputation1;
                paramBV[72] = new OleDbParameter("@CommentsOfNeighbour1", OleDbType.VarChar, 255);
                paramBV[72].Value = CommentsOfNeighbour1;
                paramBV[73] = new OleDbParameter("@NameOfNeighbour2", OleDbType.VarChar, 100);
                paramBV[73].Value = NameOfNeighbour2;
                paramBV[74] = new OleDbParameter("@AddressOfNeighbour2", OleDbType.VarChar, 50);
                paramBV[74].Value = AddressOfNeighbour2;
                paramBV[75] = new OleDbParameter("@DoesAppWorkHere2", OleDbType.VarChar, 50);
                paramBV[75].Value = DoesAppWorkHere2;
                paramBV[76] = new OleDbParameter("@MthsOfWorkAtOffice2", OleDbType.VarChar, 10);
                paramBV[76].Value = MthsOfWorkAtOffice2;
                paramBV[77] = new OleDbParameter("@MarketReputation2", OleDbType.VarChar, 100);
                paramBV[77].Value = MarketReputation2;
                paramBV[78] = new OleDbParameter("@CommentsOfNeighbour2", OleDbType.VarChar, 255);
                paramBV[78].Value = CommentsOfNeighbour2;
                paramBV[79] = new OleDbParameter("@Locality", OleDbType.VarChar, 100);
                paramBV[79].Value = Locality;
                paramBV[80] = new OleDbParameter("@Accessibility", OleDbType.VarChar, 50);
                paramBV[80].Value = Accessibility;
                paramBV[81] = new OleDbParameter("@BusinessBoardSighted", OleDbType.VarChar, 50);
                paramBV[81].Value = BusinessBoardSighted;
                paramBV[82] = new OleDbParameter("@EntryPermitted", OleDbType.VarChar, 50);
                paramBV[82].Value = EntryPermitted;
                paramBV[83] = new OleDbParameter("@ApproximateArea", OleDbType.VarChar, 50);
                paramBV[83].Value = ApproximateArea;
                paramBV[84] = new OleDbParameter("@BriefJobResponsibilities", OleDbType.VarChar, 50);
                paramBV[84].Value = BriefJobResponsibilities;
                paramBV[85] = new OleDbParameter("@BehavourOfPersonContact", OleDbType.VarChar, 50);
                paramBV[85].Value = BehavourOfPersonContact;
                paramBV[86] = new OleDbParameter("@ClourOnDoor", OleDbType.VarChar, 50);
                paramBV[86].Value = ClourOnDoor;
                paramBV[87] = new OleDbParameter("@TypeOfIndustry", OleDbType.VarChar, 100);
                paramBV[87].Value = TypeOfIndustry;
                paramBV[88] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                paramBV[88].Value = NatureOfBusiness;
                paramBV[89] = new OleDbParameter("@NoOfBranches", OleDbType.VarChar, 50);
                paramBV[89].Value = NoOfBranches;
                paramBV[90] = new OleDbParameter("@NoOfCustomerPerDay", OleDbType.VarChar, 50);
                paramBV[90].Value = NoOfCustomerPerDay;
                paramBV[91] = new OleDbParameter("@IfDoctors", OleDbType.VarChar, 10);
                paramBV[91].Value = IfDoctors;
                paramBV[92] = new OleDbParameter("@NoOfPatientsPerDay", OleDbType.VarChar, 10);
                paramBV[92].Value = NoOfPatientsPerDay;
                paramBV[93] = new OleDbParameter("@AvgFeePerPatient", OleDbType.VarChar, 10);
                paramBV[93].Value = AvgFeePerPatient;
                paramBV[94] = new OleDbParameter("@OtherClinicVisited", OleDbType.VarChar, 50);
                paramBV[94].Value = OtherClinicVisited;
                paramBV[95] = new OleDbParameter("@NameOfClinic", OleDbType.VarChar, 100);
                paramBV[95].Value = NameOfClinic;
                paramBV[96] = new OleDbParameter("@IfArchitectureCA", OleDbType.VarChar, 50);
                paramBV[96].Value = IfArchitectureCA;
                paramBV[97] = new OleDbParameter("@IndependentlyYrs", OleDbType.VarChar, 50);
                paramBV[97].Value = IndependentlyYrs;
                paramBV[98] = new OleDbParameter("@KeyClientName1", OleDbType.VarChar, 100);
                paramBV[98].Value = KeyClientName1;
                paramBV[99] = new OleDbParameter("@KeyClientName2", OleDbType.VarChar, 100);
                paramBV[99].Value = KeyClientName2;
                paramBV[100] = new OleDbParameter("@KeyClientName3", OleDbType.VarChar, 100);
                paramBV[100].Value = KeyClientName3;
                paramBV[101] = new OleDbParameter("@OfficeAddress", OleDbType.VarChar, 100);
                paramBV[101].Value = OfficeAddress;
                paramBV[102] = new OleDbParameter("@OfficeName", OleDbType.VarChar, 100);
                paramBV[102].Value = OfficeName;
                paramBV[103] = new OleDbParameter("@TypeOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[103].Value = TypeOfBusinessActivity;
                paramBV[104] = new OleDbParameter("@EntranceMotorable", OleDbType.VarChar, 100);
                paramBV[104].Value = EntranceMotorable;
                paramBV[105] = new OleDbParameter("@RelationWithApplicant", OleDbType.VarChar, 50);
                paramBV[105].Value = RelationWithApplicant;
                paramBV[106] = new OleDbParameter("@IsIdentityProofSeen", OleDbType.VarChar, 50);
                paramBV[106].Value = IsIdentityProofSeen;
                paramBV[107] = new OleDbParameter("@TypeOfOrganization", OleDbType.VarChar, 100);
                paramBV[107].Value = TypeOfOrganization;
                paramBV[108] = new OleDbParameter("@StatusOfOffice", OleDbType.VarChar, 50);
                paramBV[108].Value = StatusOfOffice;
                paramBV[109] = new OleDbParameter("@ShifOfWork", OleDbType.VarChar, 50);
                paramBV[109].Value = ShifOfWork;
                paramBV[110] = new OleDbParameter("@IsBusinessProofSeen", OleDbType.VarChar, 50);
                paramBV[110].Value = IsBusinessProofSeen;
                paramBV[111] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 255);
                paramBV[111].Value = ResidenceAddress;
                paramBV[112] = new OleDbParameter("@OtherInvestment", OleDbType.VarChar, 100);
                paramBV[112].Value = OtherInvestment;
                paramBV[113] = new OleDbParameter("@VerifierComments", OleDbType.VarChar, 2000);
                paramBV[113].Value = VerifierComments;
                paramBV[114] = new OleDbParameter("@ProofOfBusinessActivity", OleDbType.VarChar, 100);
                paramBV[114].Value = ProofOfBusinessActivity;
                paramBV[115] = new OleDbParameter("@OverallVerification", OleDbType.VarChar, 255);
                paramBV[115].Value = OverallVerification;
                paramBV[116] = new OleDbParameter("@TotalNoOfEmployees", OleDbType.VarChar, 10);
                paramBV[116].Value = TotalNoOfEmployees;
                paramBV[117] = new OleDbParameter("@ReasonNotCollectingVistingCard", OleDbType.VarChar, 100);
                paramBV[117].Value = ReasonNotCollectingVistingCard;
                paramBV[118] = new OleDbParameter("@IsOfficeDoorLocked", OleDbType.VarChar, 100);
                paramBV[118].Value = IsOfficeDoorLocked;
                paramBV[119] = new OleDbParameter("@WhereContacted", OleDbType.VarChar, 100);
                paramBV[119].Value = WhereContacted;
                paramBV[120] = new OleDbParameter("@SendDate", OleDbType.VarChar, 50);
                paramBV[120].Value = SendDate;
                paramBV[121] = new OleDbParameter("@NameOfBank", OleDbType.VarChar, 50);
                paramBV[121].Value = NameOfBank;
                paramBV[122] = new OleDbParameter("@DetailOfPreviousOccupation", OleDbType.VarChar, 255);
                paramBV[122].Value = DetailOfPreviousOccupation;
                paramBV[123] = new OleDbParameter("@PrevEmploymentDesgn", OleDbType.VarChar, 100);
                paramBV[123].Value = PrevEmploymentDesgn;
                paramBV[124] = new OleDbParameter("@ConstructionOfOffice", OleDbType.VarChar, 100);
                paramBV[124].Value = ConstructionOfOffice;
                paramBV[125] = new OleDbParameter("@EasyOfLocatingOffice", OleDbType.VarChar, 100);
                paramBV[125].Value = EasyOfLocatingOffice;
                paramBV[126] = new OleDbParameter("@Negmatch", OleDbType.VarChar, 50);
                paramBV[126].Value = Negmatch;
                paramBV[127] = new OleDbParameter("@ReasonForNotRecomdNReferred", OleDbType.VarChar, 255);
                paramBV[127].Value = ReasonForNotRecomdNReferred;
                paramBV[128] = new OleDbParameter("@IfOCLDistance", OleDbType.VarChar, 50);
                paramBV[128].Value = IfOCLDistance;
                paramBV[129] = new OleDbParameter("@AgencyCode", OleDbType.VarChar, 100);
                paramBV[129].Value = AgencyCode;
                paramBV[130] = new OleDbParameter("@IsOfficeSelfOwnedNeigh1", OleDbType.VarChar, 50);
                paramBV[130].Value = IsOfficeSelfOwnedNeigh1;
                paramBV[131] = new OleDbParameter("@IsOfficeSelfOwnedNeigh2", OleDbType.VarChar, 50);
                paramBV[131].Value = IsOfficeSelfOwnedNeigh2;
                paramBV[132] = new OleDbParameter("@LevelOfBusActivity", OleDbType.VarChar, 100);
                paramBV[132].Value = LevelOfBusActivity;
                paramBV[133] = new OleDbParameter("@IsResiCumOfficeSelfOwned", OleDbType.VarChar, 10);
                paramBV[133].Value = IsResiCumOfficeSelfOwned;
                paramBV[134] = new OleDbParameter("@StockSeen", OleDbType.VarChar, 200);
                paramBV[134].Value = StockSeen;
                paramBV[135] = new OleDbParameter("@MthOfWorkCurrentOffice", OleDbType.VarChar, 50);
                paramBV[135].Value = MthOfWorkCurrentOffice;
                paramBV[136] = new OleDbParameter("@PurposeOfLoanTaken", OleDbType.VarChar, 255);
                paramBV[136].Value = PurposeOfLoanTaken;
                paramBV[137] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramBV[137].Value = ModifyBy;
                paramBV[138] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramBV[138].Value = ModifyOn;
                paramBV[139] = new OleDbParameter("@NameOfCollegue", OleDbType.VarChar, 50);
                paramBV[139].Value = NameOfCollegue;
                paramBV[140] = new OleDbParameter("@DesgnDeptCollegue", OleDbType.VarChar, 50);
                paramBV[140].Value = DesgnDeptCollegue;
                paramBV[141] = new OleDbParameter("@MthOfCompExistAtAddress", OleDbType.VarChar, 15);
                paramBV[141].Value = MthOfCompExistAtAddress;
                paramBV[142] = new OleDbParameter("@ProfileCoNeighbour", OleDbType.VarChar, 100);
                paramBV[142].Value = ProfileCoNeighbour;
                paramBV[143] = new OleDbParameter("@AppNameVerifiedFrom", OleDbType.VarChar, 50);
                paramBV[143].Value = AppNameVerifiedFrom;
                paramBV[144] = new OleDbParameter("@RoofType", OleDbType.VarChar, 50);
                paramBV[144].Value = RoofType;
                paramBV[145] = new OleDbParameter("@SupervisorComment", OleDbType.VarChar, 250);
                paramBV[145].Value = SupervisorComment;
                paramBV[146] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 250);
                paramBV[146].Value = CityLimit;
                //added by kamal matekar....
                paramBV[147] = new OleDbParameter("@MainlineBusiness", OleDbType.VarChar, 250);
                paramBV[147].Value = MainlineBusiness;
                paramBV[148] = new OleDbParameter("@ValueofNostocksighted", OleDbType.VarChar, 250);
                paramBV[148].Value = ValueofNostocksighted;
                paramBV[149] = new OleDbParameter("@CategoryofCompany", OleDbType.VarChar, 250);
                paramBV[149].Value = CategoryofCompany;
                paramBV[150] = new OleDbParameter("@NormalOfficeJob", OleDbType.VarChar, 250);
                paramBV[150].Value = NormalOfficeJob;
                paramBV[151] = new OleDbParameter("@CustomerSeen", OleDbType.VarChar, 500);
                paramBV[151].Value = CustomerSeen;
                paramBV[152] = new OleDbParameter("@TypeJob", OleDbType.VarChar, 500);
                paramBV[152].Value = TypeJob;
                paramBV[153] = new OleDbParameter("@AppliWork", OleDbType.VarChar, 500);
                paramBV[153].Value = AppliWork;
                paramBV[154] = new OleDbParameter("@Appli_JobTrans", OleDbType.VarChar, 500);
                paramBV[154].Value = AppliJobTrans;
                paramBV[155] = new OleDbParameter("@OffExit", OleDbType.VarChar, 500);
                paramBV[155].Value = OffExit;
                paramBV[156] = new OleDbParameter("@VehiOwn", OleDbType.VarChar, 500);
                paramBV[156].Value = VehiOwn;
                paramBV[157] = new OleDbParameter("@BussPrem", OleDbType.VarChar, 500);
                paramBV[157].Value = BussPrem;
                paramBV[158] = new OleDbParameter("@RefName", OleDbType.VarChar, 500);
                paramBV[158].Value = RefName;
                paramBV[159] = new OleDbParameter("@RefAdd", OleDbType.VarChar, 500);
                paramBV[159].Value = RefAdd;
                paramBV[160] = new OleDbParameter("@MonthTurn", OleDbType.VarChar, 500);
                paramBV[160].Value = MonthTurn;
                paramBV[161] = new OleDbParameter("@NumberBed", OleDbType.VarChar, 500);
                paramBV[161].Value = NumberBed;
                paramBV[162] = new OleDbParameter("@NeighCheck", OleDbType.VarChar, 500);
                paramBV[162].Value = NeighCheck;
                paramBV[163] = new OleDbParameter("@ClinicYear", OleDbType.VarChar, 500);
                paramBV[163].Value = ClinicYear;
                paramBV[164] = new OleDbParameter("@SeparateResi", OleDbType.VarChar, 500);
                paramBV[164].Value = SeparateResi;
                paramBV[165] = new OleDbParameter("@SeparateFactory", OleDbType.VarChar, 500);
                paramBV[165].Value = SeparateFactory;
                paramBV[166] = new OleDbParameter("@SeparateEntrance", OleDbType.VarChar, 500);
                paramBV[166].Value = SeparateEntrance;
                paramBV[167] = new OleDbParameter("@SeparateOffice", OleDbType.VarChar, 500);
                paramBV[167].Value = SeparateOffice;
                paramBV[168] = new OleDbParameter("@OfficeLimit", OleDbType.VarChar, 500);
                paramBV[168].Value = OfficeLimit;

                paramBV[169] = new OleDbParameter("@NamePerson2", OleDbType.VarChar, 500);
                paramBV[169].Value = NamePerson2;
                paramBV[170] = new OleDbParameter("@RelantionApp2", OleDbType.VarChar, 500);
                paramBV[170].Value = RelantionApp2;
                paramBV[171] = new OleDbParameter("@Form16", OleDbType.VarChar, 500);
                paramBV[171].Value = Form16;
                paramBV[172] = new OleDbParameter("@ProfileConfIssu", OleDbType.VarChar, 500);
                paramBV[172].Value = ProfileConfIssu;
                paramBV[173] = new OleDbParameter("@ProfileConfColle", OleDbType.VarChar, 500);
                paramBV[173].Value = ProfileConfColle;
                paramBV[174] = new OleDbParameter("@InfoProvide", OleDbType.VarChar, 500);
                paramBV[174].Value = InfoProvide;
                paramBV[175] = new OleDbParameter("@CustAppPrev", OleDbType.VarChar, 500);
                paramBV[175].Value = CustAppPrev;
                paramBV[176] = new OleDbParameter("@DatePrev", OleDbType.VarChar, 500);
                paramBV[176].Value = DatePrev;
                paramBV[177] = new OleDbParameter("@OffDeci", OleDbType.VarChar, 500);
                paramBV[177].Value = OffDeci;
                paramBV[178] = new OleDbParameter("@Salary", OleDbType.VarChar, 500);
                paramBV[178].Value = Salary;

                paramBV[179] = new OleDbParameter("@NoDoctor", OleDbType.VarChar, 500);
                paramBV[179].Value = NoDoctor;
                paramBV[180] = new OleDbParameter("@GrossReceipt", OleDbType.VarChar, 500);
                paramBV[180].Value = GrossReceipt;
                paramBV[181] = new OleDbParameter("@MedicalShop", OleDbType.VarChar, 500);
                paramBV[181].Value = MedicalShop;
                paramBV[182] = new OleDbParameter("@AmtRent", OleDbType.VarChar, 500);
                paramBV[182].Value = AmtRent;
                paramBV[183] = new OleDbParameter("@NameHospital", OleDbType.VarChar, 500);
                paramBV[183].Value = NameHospital;
                paramBV[184] = new OleDbParameter("@NameMachine", OleDbType.VarChar, 500);
                paramBV[184].Value = NameMachine;
                paramBV[185] = new OleDbParameter("@AuditTax", OleDbType.VarChar, 500);
                paramBV[185].Value = AuditTax;
                paramBV[186] = new OleDbParameter("@NoOfTax", OleDbType.VarChar, 500);
                paramBV[186].Value = NoOfTax;
                paramBV[187] = new OleDbParameter("@GrossMonthReceipt", OleDbType.VarChar, 500);
                paramBV[187].Value = GrossMonthReceipt;

                paramBV[188] = new OleDbParameter("@NoOperation", OleDbType.VarChar, 500);
                paramBV[188].Value = NoOperation;
                paramBV[189] = new OleDbParameter("@SoleOwnert", OleDbType.VarChar, 500);
                paramBV[189].Value = SoleOwner;
                paramBV[190] = new OleDbParameter("@AmtInvt", OleDbType.VarChar, 500);
                paramBV[190].Value = AmtInvt;
                paramBV[191] = new OleDbParameter("@BussPremises", OleDbType.VarChar, 500);
                paramBV[191].Value = BussPremises;
                paramBV[192] = new OleDbParameter("@FixAss", OleDbType.VarChar, 500);
                paramBV[192].Value = FixAss;
                paramBV[193] = new OleDbParameter("@BussManuf", OleDbType.VarChar, 500);
                paramBV[193].Value = BussManuf;
                paramBV[194] = new OleDbParameter("@RegiSale", OleDbType.VarChar, 500);
                paramBV[194].Value = RegiSale;
                paramBV[195] = new OleDbParameter("@MajorClient", OleDbType.VarChar, 500);
                paramBV[195].Value = MajorClient;
                paramBV[196] = new OleDbParameter("@AvgProfit", OleDbType.VarChar, 500);
                paramBV[196].Value = AvgProfit;
                paramBV[197] = new OleDbParameter("@AvgSale", OleDbType.VarChar, 500);
                paramBV[197].Value = AvgSale;
                paramBV[198] = new OleDbParameter("@SourceIncome", OleDbType.VarChar, 500);
                paramBV[198].Value = SourceIncome;

                //added by kamal matekar...for Barclays Finance PL Pdf 
                paramBV[199] = new OleDbParameter("@Place_Of_Birth", OleDbType.VarChar, 500);
                paramBV[199].Value = Place_Of_Birth;
                paramBV[200] = new OleDbParameter("@State", OleDbType.VarChar, 500);
                paramBV[200].Value = State;
                paramBV[201] = new OleDbParameter("@Permanent_Address_If_Different", OleDbType.VarChar, 500);
                paramBV[201].Value = Permanent_Address_If_Different;
                paramBV[202] = new OleDbParameter("@Type_Of_Accomodation", OleDbType.VarChar, 500);
                paramBV[202].Value = Type_Of_Accomodation;
                paramBV[203] = new OleDbParameter("@Approx_Time_When_App_Home", OleDbType.VarChar, 500);
                paramBV[203].Value = Approx_Time_When_App_Home;
                paramBV[204] = new OleDbParameter("@Sourcing_Dsa_Dealer", OleDbType.VarChar, 500);
                paramBV[204].Value = Sourcing_Dsa_Dealer;
                paramBV[205] = new OleDbParameter("@Existing_Relationship_with_Barclays", OleDbType.VarChar, 500);
                paramBV[205].Value = Existing_Relationship_with_Barclays;
                paramBV[206] = new OleDbParameter("@Applicant_Category", OleDbType.VarChar, 500);
                paramBV[206].Value = Applicant_Category;
                paramBV[207] = new OleDbParameter("@If_Salaried_Employer_Name", OleDbType.VarChar, 500);
                paramBV[207].Value = If_Salaried_Employer_Name;
                paramBV[208] = new OleDbParameter("@Main_Client", OleDbType.VarChar, 500);
                paramBV[208].Value = Main_Client;

                paramBV[209] = new OleDbParameter("@Size_Of_Office", OleDbType.VarChar, 500);
                paramBV[209].Value = Size_Of_Office;
                paramBV[210] = new OleDbParameter("@Self_PM_Rent", OleDbType.VarChar, 500);
                paramBV[210].Value = Self_PM_Rent;
                paramBV[211] = new OleDbParameter("@NoOfYrsAtCurrentOfficeAddress", OleDbType.VarChar, 500);
                paramBV[211].Value = NoOfYrsAtCurrentOfficeAddress;
                paramBV[212] = new OleDbParameter("@OtherOfficeLocationDetails", OleDbType.VarChar, 500);
                paramBV[212].Value = OtherOfficeLocationDetails;
                paramBV[213] = new OleDbParameter("@Automation_Level", OleDbType.VarChar, 500);
                paramBV[213].Value = Automation_Level;
                paramBV[214] = new OleDbParameter("@Approachability", OleDbType.VarChar, 500);
                paramBV[214].Value = Approachability;
                paramBV[215] = new OleDbParameter("@Within_Municipal_Limit", OleDbType.VarChar, 500);
                paramBV[215].Value = Within_Municipal_Limit;
                paramBV[216] = new OleDbParameter("@AnyOtherFormOfbusiness", OleDbType.VarChar, 500);
                paramBV[216].Value = AnyOtherFormOfbusiness;
                paramBV[217] = new OleDbParameter("@YearsAtCurrentAddress", OleDbType.VarChar, 500);
                paramBV[217].Value = YearsAtCurrentAddress;
                paramBV[218] = new OleDbParameter("@NoOfYearsInCity", OleDbType.VarChar, 500);
                paramBV[218].Value = NoOfYearsInCity;
                paramBV[219] = new OleDbParameter("@VehicalOwned", OleDbType.VarChar, 500);
                paramBV[219].Value = VehicalOwned;

                paramBV[220] = new OleDbParameter("@AnyOtherAssets", OleDbType.VarChar, 500);
                paramBV[220].Value = AnyOtherAssets;
                paramBV[221] = new OleDbParameter("@BankParticulars", OleDbType.VarChar, 500);
                paramBV[221].Value = BankParticulars;
                //ended by kamal matekar....
                //---added by kamal matekar for Federal finance On dated 29/07/2010 ...

                paramBV[222] = new OleDbParameter("@OffAdd_CoApp", OleDbType.VarChar, 522);
                paramBV[222].Value = OffAdd_CoApp;
                paramBV[223] = new OleDbParameter("@LandMark_CoApp", OleDbType.VarChar, 522);
                paramBV[223].Value = LandMark_CoApp;
                paramBV[224] = new OleDbParameter("@TelNo_CoApp", OleDbType.VarChar, 522);
                paramBV[224].Value = TelNo_CoApp;
                paramBV[225] = new OleDbParameter("@PersonContacted_CoApp", OleDbType.VarChar, 522);
                paramBV[225].Value = PersonContacted_CoApp;
                paramBV[226] = new OleDbParameter("@Designation_CoApp", OleDbType.VarChar, 522);
                paramBV[226].Value = Designation_CoApp;
                paramBV[227] = new OleDbParameter("@Datetime_Visit_CoApp", OleDbType.VarChar, 522);
                paramBV[227].Value = Datetime_Visit_CoApp;
                paramBV[228] = new OleDbParameter("@ComStructure", OleDbType.VarChar, 522);
                paramBV[228].Value = ComStructure;
                paramBV[229] = new OleDbParameter("@TurnOver", OleDbType.VarChar, 522);
                paramBV[229].Value = TurnOver;
                paramBV[230] = new OleDbParameter("@Stock", OleDbType.VarChar, 522);
                paramBV[230].Value = Stock;

                paramBV[231] = new OleDbParameter("@ITReturn", OleDbType.VarChar, 522);
                paramBV[231].Value = ITReturn;
                paramBV[232] = new OleDbParameter("@ProfitMargin", OleDbType.VarChar, 500);
                paramBV[232].Value = ProfitMargin;
                paramBV[233] = new OleDbParameter("@DeptClaimed", OleDbType.VarChar, 500);
                paramBV[233].Value = DeptClaimed;
                paramBV[234] = new OleDbParameter("@Wife", OleDbType.VarChar, 500);
                paramBV[234].Value = Wife;
                paramBV[235] = new OleDbParameter("@Son", OleDbType.VarChar, 500);
                paramBV[235].Value = Son;
                paramBV[236] = new OleDbParameter("@LoanType", OleDbType.VarChar, 500);
                paramBV[236].Value = LoanType;
                paramBV[237] = new OleDbParameter("@EMI", OleDbType.VarChar, 500);
                paramBV[237].Value = EMI;
                paramBV[238] = new OleDbParameter("@Paid", OleDbType.VarChar, 500);
                paramBV[238].Value = Paid;
                paramBV[239] = new OleDbParameter("@CrLimit", OleDbType.VarChar, 500);
                paramBV[239].Value = CrLimit;
                paramBV[240] = new OleDbParameter("@CardNo", OleDbType.VarChar, 500);
                paramBV[240].Value = CardNo;
                paramBV[241] = new OleDbParameter("@CompanyName_CoApp", OleDbType.VarChar, 500);
                paramBV[241].Value = CompanyName_CoApp;
                paramBV[242] = new OleDbParameter("@Dir_Check", OleDbType.VarChar, 500);
                paramBV[242].Value = SepOff;
                paramBV[243] = new OleDbParameter("@WorkExp", OleDbType.VarChar, 500);
                paramBV[243].Value = WorkExp;
                paramBV[244] = new OleDbParameter("@OrgCov", OleDbType.VarChar, 500);
                paramBV[244].Value = OrgCov;
                paramBV[245] = new OleDbParameter("@OemfName", OleDbType.VarChar, 500);
                paramBV[245].Value = OemfName;
                paramBV[246] = new OleDbParameter("@OemfRelation", OleDbType.VarChar, 500);
                paramBV[246].Value = OemfRelation;
                paramBV[247] = new OleDbParameter("@OemfOccu", OleDbType.VarChar, 500);
                paramBV[247].Value = OemfOccu;
                paramBV[248] = new OleDbParameter("@OemfIncome", OleDbType.VarChar, 500);
                paramBV[248].Value = OemfIncome;
                paramBV[249] = new OleDbParameter("@Dependent", OleDbType.VarChar, 500);
                paramBV[249].Value = Dependent;
                paramBV[250] = new OleDbParameter("@TwoWh", OleDbType.VarChar, 500);
                paramBV[250].Value = TwoWh;
                paramBV[251] = new OleDbParameter("@FourWh", OleDbType.VarChar, 500);
                paramBV[251].Value = FourWh;
                paramBV[252] = new OleDbParameter("@SignSeen", OleDbType.VarChar, 500);
                paramBV[252].Value = SignSeen;
                paramBV[253] = new OleDbParameter("@FamilyMember", OleDbType.VarChar, 500);
                paramBV[253].Value = FamilyMember;
                paramBV[254] = new OleDbParameter("@ResiStatus", OleDbType.VarChar, 500);
                paramBV[254].Value = ResiStatus;
                paramBV[255] = new OleDbParameter("@Outstanding", OleDbType.VarChar, 500);
                paramBV[255].Value = Outstanding;
                paramBV[256] = new OleDbParameter("@OtherFeedback", OleDbType.VarChar, 500);
                paramBV[256].Value = OtherFeedback;
                
                paramBV[257] = new OleDbParameter("@IfFinanceNameOfBank", OleDbType.VarChar, 500);
                paramBV[257].Value = IfFinanceNameOfBank;
                paramBV[258] = new OleDbParameter("@Property_IsRented", OleDbType.VarChar, 500);
                paramBV[258].Value = Property_IsRented;
                paramBV[259] = new OleDbParameter("@IfRented_PerMonth", OleDbType.VarChar, 500);
                paramBV[259].Value = IfRented_PerMonth;
                paramBV[260] = new OleDbParameter("@SpouseWork", OleDbType.VarChar, 500);
                paramBV[260].Value = SpouseWork;
                paramBV[261] = new OleDbParameter("@SpouseDesg", OleDbType.VarChar, 500);
                paramBV[261].Value = SpouseDesg;
                paramBV[262] = new OleDbParameter("@DetailsOfWorkingMemberSpouse", OleDbType.VarChar, 500);
                paramBV[262].Value = DetailsOfWorkingMemberSpouse;
                paramBV[263] = new OleDbParameter("@SpouseAdd", OleDbType.VarChar, 500);
                paramBV[263].Value = SpouseAdd;
                paramBV[264] = new OleDbParameter("@UseOfAssets", OleDbType.VarChar, 500);
                paramBV[264].Value = UseOfAssets;
                paramBV[265] = new OleDbParameter("@FaxNo", OleDbType.VarChar, 500);
                paramBV[265].Value = FaxNo;
                paramBV[266] = new OleDbParameter("@FinanceCompName", OleDbType.VarChar, 500);
                paramBV[266].Value = FinanceCompName;
                paramBV[267] = new OleDbParameter("@Purpose1", OleDbType.VarChar, 500);
                paramBV[267].Value = Purpose1;
                paramBV[268] = new OleDbParameter("@OthPurpose1", OleDbType.VarChar, 500);
                paramBV[268].Value = OthPurpose1;
                paramBV[269] = new OleDbParameter("@ResidenceDetails", OleDbType.VarChar, 500);
                paramBV[269].Value = ResidenceDetails;
                paramBV[270] = new OleDbParameter("@AccountType", OleDbType.VarChar, 500);
                paramBV[270].Value = AccountType;
                paramBV[271] = new OleDbParameter("@BusinessConfirmed", OleDbType.VarChar, 500);
                paramBV[271].Value = BusinessConfirmed;
                paramBV[272] = new OleDbParameter("@ConfirmationSetup", OleDbType.VarChar, 500);
                paramBV[272].Value = ConfirmationSetup;
                paramBV[273] = new OleDbParameter("@DedupMatchr", OleDbType.VarChar, 500);
                paramBV[273].Value = DedupMatchr;
                paramBV[274] = new OleDbParameter("@GeneralAppearance", OleDbType.VarChar, 500);
                paramBV[274].Value = GeneralAppearance;
                paramBV[275] = new OleDbParameter("@Inducementoffered", OleDbType.VarChar, 500);
                paramBV[275].Value = Inducementoffered;
                paramBV[276] = new OleDbParameter("@ExactCompanyNameAddress", OleDbType.VarChar, 500);
                paramBV[276].Value = ExactCompanyNameAddress;

                //nikhil start 18 april 2013 deutscheRtl
                paramBV[277] = new OleDbParameter("@OfficeAmenities", OleDbType.VarChar, 500);
                paramBV[277].Value = OfficeAmenities;
                paramBV[278] = new OleDbParameter("@MultipleCompFromPremises", OleDbType.VarChar, 500);
                paramBV[278].Value = MultipleCompFromPremises;
                paramBV[279] = new OleDbParameter("@ShadyOffice", OleDbType.VarChar, 500);
                paramBV[279].Value = ShadyOffice;
                paramBV[280] = new OleDbParameter("@AddressSetup", OleDbType.VarChar, 500);
                paramBV[280].Value = AddressSetup;
                paramBV[281] = new OleDbParameter("@MetColleague", OleDbType.VarChar, 500);
                paramBV[281].Value = MetColleague;
                paramBV[282] = new OleDbParameter("@MetCust", OleDbType.VarChar, 500);
                paramBV[282].Value = MetCust;
                paramBV[283] = new OleDbParameter("@MetRecep", OleDbType.VarChar, 500);
                paramBV[283].Value = MetRecep;
                paramBV[284] = new OleDbParameter("@MetSecurityGuard ", OleDbType.VarChar, 500);
                paramBV[284].Value = MetSecurityGuard;
                paramBV[285] = new OleDbParameter("@DesgnConf ", OleDbType.VarChar, 500);
                paramBV[285].Value = DesgnConf;
                paramBV[286] = new OleDbParameter("@CustSameOffice", OleDbType.VarChar, 500);
                paramBV[286].Value = CustSameOffice;
                paramBV[287] = new OleDbParameter("@OfficeOrStock", OleDbType.VarChar, 500);
                paramBV[287].Value = OfficeOrStock;
                paramBV[288] = new OleDbParameter("@Doesbranches", OleDbType.VarChar, 500);
                paramBV[288].Value = Doesbranches;
                paramBV[289] = new OleDbParameter("@NeighbourCheck", OleDbType.VarChar, 500);
                paramBV[289].Value = NeighbourCheck;
                paramBV[290] = new OleDbParameter("@NameVerifierNAme", OleDbType.VarChar, 500);
                paramBV[290].Value = NameVerifierNAme;
                paramBV[291] = new OleDbParameter("@Interiors", OleDbType.VarChar, 500);
                paramBV[291].Value = Interiors;
                paramBV[292] = new OleDbParameter("@Secretary", OleDbType.VarChar, 500);
                paramBV[292].Value = Secretary;
                paramBV[293] = new OleDbParameter("@Furnishingseen", OleDbType.VarChar, 500);
                paramBV[293].Value = Furnishingseen;
                paramBV[294] = new OleDbParameter("@thereaphoneonhisdesk", OleDbType.VarChar, 500);
                paramBV[294].Value = thereaphoneonhisdesk;
                //nikhil Deutsche Rtl end
                paramBV[295] = new OleDbParameter("@Earingmembers ", OleDbType.VarChar, 500);
                paramBV[295].Value = Earingmembers;
                paramBV[296] = new OleDbParameter("@Relationshipe ", OleDbType.VarChar, 500);
                paramBV[296].Value = Relationshipe;
                paramBV[297] = new OleDbParameter("@monthlyearing ", OleDbType.VarChar, 500);
                paramBV[297].Value = monthlyearing;
                paramBV[298] = new OleDbParameter("@Verifierthrough ", OleDbType.VarChar, 500);
                paramBV[298].Value = Verifierthrough;
                paramBV[299] = new OleDbParameter("@ApplicantstaandinginLocality ", OleDbType.VarChar, 500);
                paramBV[299].Value = ApplicantstaandinginLocality;
                paramBV[300] = new OleDbParameter("@namee ", OleDbType.VarChar, 500);
                paramBV[300].Value = namee;
                paramBV[301] = new OleDbParameter("@phonee ", OleDbType.VarChar, 500);
                paramBV[301].Value = phonee;
                paramBV[302] = new OleDbParameter("@elaborateonthestanding ", OleDbType.VarChar, 500);
                paramBV[302].Value = elaborateonthestanding;
                paramBV[303] = new OleDbParameter("@Businessdealingseen ", OleDbType.VarChar, 500);
                paramBV[303].Value = Businessdealingseen;
                paramBV[304] = new OleDbParameter("@Financier ", OleDbType.VarChar, 500);
                paramBV[304].Value = Financier;
                paramBV[305] = new OleDbParameter("@FinanceAmount ", OleDbType.VarChar, 500);
                paramBV[305].Value = FinanceAmount;
                paramBV[306] = new OleDbParameter("@NoOfBranchtext ", OleDbType.VarChar, 500);
                paramBV[306].Value = NoOfBranchtext;
               
                paramBV[307] = new OleDbParameter("@CoApplicantName ", OleDbType.VarChar, 500);
                paramBV[307].Value = CoApplicantName;
                paramBV[308] = new OleDbParameter("@Addressonfirmed ", OleDbType.VarChar, 500);
                paramBV[308].Value = Addressonfirmed;
                paramBV[309] = new OleDbParameter("@RouteMap ", OleDbType.VarChar, 500);
                paramBV[309].Value = RouteMap;
                paramBV[310] = new OleDbParameter("@AverageBillingPerCustomer ", OleDbType.VarChar, 500);
                paramBV[310].Value = AverageBillingPerCustomer;
                paramBV[311] = new OleDbParameter("@PeakBusinessHours ", OleDbType.VarChar, 500);
                paramBV[311].Value = PeakBusinessHours;
                paramBV[312] = new OleDbParameter("@MarketHoliday ", OleDbType.VarChar, 500);
                paramBV[312].Value = MarketHoliday;
                paramBV[313] = new OleDbParameter("@VehicleRegNo ", OleDbType.VarChar, 500);
                paramBV[313].Value = VehicleRegNo;
                paramBV[314] = new OleDbParameter("@VehicleFreeOrFinance ", OleDbType.VarChar, 500);
                paramBV[314].Value = VehicleFreeOrFinance;
                paramBV[315] = new OleDbParameter("@ExistingLoanDetails ", OleDbType.VarChar, 500);
                paramBV[315].Value = ExistingLoanDetails;
                paramBV[316] = new OleDbParameter("@AnyConcerningIssue ", OleDbType.VarChar, 500);
                paramBV[316].Value = AnyConcerningIssue;
                paramBV[317] = new OleDbParameter("@ReportingTo ", OleDbType.VarChar, 500);
                paramBV[317].Value = ReportingTo;
                paramBV[318] = new OleDbParameter("@FileUpload1 ", OleDbType.Binary);
                paramBV[318].Value = FileUpload1;
                //////////////////////////////////ended///////////////////////

                paramBV[319] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                paramBV[319].Value = CaseId;
                paramBV[320] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 15);
                paramBV[320].Value = VerificationTypeId;


                sRetVal = "Record updated successfully.";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBV);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseId;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            /////added by kamal matekar.....
            if (VerificationTypeId == "25" || VerificationTypeId == "26" || VerificationTypeId == "27" || VerificationTypeId == "28")
            {
                if (IsQCVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId, ClientId, CentreId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    sRetVal += " Case verification data entry completed.";

                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }
    #endregion

    # region GetFEName()
    
    public OleDbDataReader GetFEName(string sCaseId, string sVeriTypeId)
    {
        string sSql = "";
        sSql = "select distinct fullname,FE_ID from fe_vw fv inner join CPV_RL_CASE_FE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "' and Verification_Type_id='" + sVeriTypeId + "' order by fv.fullname";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    #endregion GetFEName()

    public OleDbDataReader GetIDOCsCaseVerificationDetail(string sCaseId, string sVerifyTypeId)
    {
        string sSql = "";
        sSql = "SELECT Person_contacted,Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD, " +
               " AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID,Cpa_Ref,Dept_ConPer FROM CPV_RL_VERIFICATION_REF " +
               " WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE_ID='" + sVerifyTypeId + "'";

        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public string InsertUpdateBankStatement()
    {
        OleDbConnection oledbConn = new OleDbConnection(objCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sRetVal = "";
        try
        {
            string sSql = "";
            string sSqlRead = "";
            OleDbDataReader oledbRead;
            sSqlRead = "SELECT CASE_ID FROM CPV_RL_VERIFICATION_REF " +
                       " WHERE CASE_ID='" + CaseID + "'" +
                       " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

            OleDbParameter[] paramBankStat = new OleDbParameter[14];
            if (oledbRead.Read() == false)
            {
                sSql = "INSERT INTO CPV_RL_VERIFICATION_REF(CASE_ID,VERIFICATION_TYPE_ID,Person_contacted," +
                      "Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD,AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID," +
                      "ADD_BY,ADD_DATE,Cpa_Ref,Dept_ConPer) " +
                      " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                paramBankStat[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramBankStat[0].Value = CaseID;
                paramBankStat[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
                paramBankStat[1].Value = VerificationTypeId;
                paramBankStat[2] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
                paramBankStat[2].Value = NameOfPersonContacted;
                paramBankStat[3] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
                paramBankStat[3].Value = Cont_DesignationDepartment;
                paramBankStat[4] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
                paramBankStat[4].Value = IsAcctCorrect;
                paramBankStat[5] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
                paramBankStat[5].Value = StanForOrg;
                paramBankStat[6] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
                paramBankStat[6].Value = AmtSSSPSC;
                paramBankStat[7] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
                paramBankStat[7].Value = FERemarks;
                paramBankStat[8] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
                paramBankStat[8].Value = VeriDate;
                paramBankStat[9] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
                paramBankStat[9].Value = CaseStatusID;
                paramBankStat[10] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                paramBankStat[10].Value = AddedBy;
                paramBankStat[11] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
                paramBankStat[11].Value = AddedOn;
                paramBankStat[12] = new OleDbParameter("@CpvRefNo", OleDbType.VarChar, 150);
                paramBankStat[12].Value = CpvRefNo;
                paramBankStat[13] = new OleDbParameter("@Dept_ConPer", OleDbType.VarChar, 500);
                paramBankStat[13].Value = Dept_ConPer;



                sRetVal = "Record added successfully.";

            }
            else
            {
                sSql = "UPDATE CPV_RL_VERIFICATION_REF SET Person_contacted=?," +
                     " Cont_Designation_dept=?,ACCOUNT_CORRECT=?,DOCUMENT_AS_PER_STANDARD=?,AMOUNT_ON_DOC=?," +
                     " FE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,MODIFY_BY=?,MODIFY_DATE=?,Cpa_Ref=?,Dept_ConPer=? " +
                     " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

                paramBankStat[0] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
                paramBankStat[0].Value = NameOfPersonContacted;
                paramBankStat[1] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
                paramBankStat[1].Value = Cont_DesignationDepartment;
                paramBankStat[2] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
                paramBankStat[2].Value = IsAcctCorrect;
                paramBankStat[3] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
                paramBankStat[3].Value = StanForOrg;
                paramBankStat[4] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
                paramBankStat[4].Value = AmtSSSPSC;
                paramBankStat[5] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
                paramBankStat[5].Value = FERemarks;
                paramBankStat[6] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
                paramBankStat[6].Value = VeriDate;
                paramBankStat[7] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
                paramBankStat[7].Value = CaseStatusID;
                paramBankStat[8] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
                paramBankStat[8].Value = ModifyBy;
                paramBankStat[9] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
                paramBankStat[9].Value = ModifyOn;
                paramBankStat[10] = new OleDbParameter("@CpvRefNo", OleDbType.VarChar, 150);
                paramBankStat[10].Value = CpvRefNo;
                paramBankStat[11] = new OleDbParameter("@Dept_ConPer", OleDbType.VarChar, 500);
                paramBankStat[11].Value = Dept_ConPer;
                paramBankStat[12] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
                paramBankStat[12].Value = CaseID;
                paramBankStat[13] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 11);
                paramBankStat[13].Value = VerificationTypeId;

                sRetVal = "Record updated successfully.";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBankStat);
            //////////add by santosh shelar/////////////////////
            //sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + CaseID + "'";
            ///OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sSql = "";
            sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
                 "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            OleDbParameter[] paramTransLog = new OleDbParameter[8];
            paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            paramTransLog[0].Value = CaseID;
            paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            paramTransLog[1].Value = VerificationTypeId;
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //////////////////if (IsVerificationComplete(oledbTrans, CaseID) == "true")
            //////////////////{
            //////////////////    VerificationComplete(oledbTrans, CaseID);
            //////////////////    sRetVal += " Case verification data entry completed.";
            //////////////////}
            /////
            oledbTrans.Commit();
            oledbConn.Close();

            return sRetVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting Bank statement Detail " + ex.Message);
        }
    }

    public OleDbDataReader GetIDOCsCaseDetail(string sCaseId)
    {
        string sSql = "";
        sSql = "select ISNULL(TITLE,'')+' ' +ISNULL(FIRST_NAME,'')+' ' +ISNULL(MIDDLE_NAME,'')+ ' ' +ISNULL(LAST_NAME,'') AS [FULL NAME], " +
             " REF_NO,CASE_REC_DATETIME AS RECD_DATE,off_name as[BANK_NAME],off_add_line_1 as[BANK_ADDRESS],off_pin_code[BANK_PIN],off_city as[BANK_CITY] FROM CPV_RL_CASE_DETAILS " +
             " WHERE CASE_ID='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   05 Aug 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete="";
        //sSql = " Select * from CPV_RL_CASE_STATUS_NULL " +
        //       " where case_id='" + sCaseId + "' and Client_id='" + sClientId + "'" +
        //       " and Centre_id='" + sCenterId + "'";

        sSql = "Select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE " +
               " where case_id='" + sCaseId + "') " +
               " when (select count(*) from CPV_RL_CASE_STATUS_VIEW where case_id='" + sCaseId + "')" +
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
